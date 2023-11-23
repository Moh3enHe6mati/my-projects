using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mehad_Tools
{
    public class functions
    {
        private Form1 mt;
        string scpath = @"C:\", frmpath = @"C:\", initial = "", path = "";


        byte[] info;
        byte[] address = { 0x07, 0xE0, 0xFF, 0xFF, 0x07, 0xE8, 0xFF, 0xFF };
        byte[] kaddress = { 0xFF, 0xFF };
        byte[] baudrate = { 0x00, 0x00 };
        byte[,] bcr = new byte[1000000 , 10];
        string[,] scr = new string[1000000, 12];
        public functions(Form1 entry)
        {
            mt = entry;
        }
        //=========================================================================================
        public void danacodes()
        {
            int i = 0, j = 0;
            string str = "", line = "", S1 = "";
            string[,] sarray = new string[100, 1000];
            bool findflag = false;
            try
            {
                str = mt.converttextBox.Text;
                StringReader reader = new StringReader(str);
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "جستجو: ")
                    {
                        line = reader.ReadLine();
                        sarray[i, j] = line;
                        reader.ReadLine();
                        findflag = true;
                    }
                    else if (findflag == true)
                    {
                        Regex regfindcode = new Regex(@"\W.*----");//SCH98----
                        if ((regfindcode != null) && (line != null))
                        {
                            Match match = regfindcode.Match(line);
                            if (match.Success)
                            {
                                j = 0;
                                i++;
                                sarray[i, j] = match.ToString().Replace("\t", "");
                                sarray[i, j] = sarray[i, j].Replace("----", "");
                            }
                            else
                            {
                                j++;
                                sarray[i, j] = line;
                            }
                        }
                    }
                }
                for (int u = 1; u < 100; u++)//dana code
                {
                    for (int k = 1; k < 1000; k++)//ecu list
                    {
                        if ((sarray[u, 0] == null) || (sarray[u, k] == null))
                            break;
                        if (sarray[0, 0] == sarray[u, k])
                        {
                            S1 = S1 + sarray[u, 0] + "-";
                        }
                    }
                    if (sarray[u, 0] == null)
                        break;
                }
                mt.converttextBox.Clear();
                mt.converttextBox.Text = S1.Substring(0, S1.Length - 1);
                Clipboard.SetText(mt.converttextBox.Text);
                mt.resultlabel.BackColor = Color.LimeGreen;
                mt.resultlabel.Text = "Find Code Complete.";
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "App Error! Please Check ECU Name.";
            }
        }//get dana code
        //=========================================================================================
        public void convertlog()
        {
            byte[] brlog= { };
            byte logprot = 0;

            path = loadfile();
            if(path != null)
            {
                logprot = pro_detector(path);
                if (logprot == 1)//can11
                {
                    log_can11(path);
                }
                else if (logprot == 2)//can29
                {
                    log_can29(path);
                }
                else if (logprot == 3)//kwp
                {
                    log_kwp(path);
                }
                else
                {
                    mt.resultlabel.BackColor = Color.Red;
                    mt.resultlabel.Text = "Protocol Not Detected!";
                }
            }
        }
        //=========================================================================================
        public byte log_kwp(string path)
        {
            string line = "", S1 = "";
            Int32 Noline = 0, k = 0, m = 0;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sReader = new StreamReader(file, Encoding.UTF8);
            //***read data and copy to string matrix****
            while ((line = sReader.ReadLine()) != null)
            {
                Noline++;
                if ((line == string.Empty) || (line.Substring(0, 1) == "*") || (line.Substring(0, 1) == "-"))
                    continue;
                if ((line.Length < 9)||(line.Substring(0,1) != "8"))
                {
                    mt.resultlabel.BackColor = Color.Red;
                    mt.resultlabel.Text = "Line " + Noline.ToString() + " Error!";
                    return 0;
                }
                for (int j = 0; j < 769; j++)
                {
                    if (line.Substring(j, 1) == "-")
                        break;
                    S1 = S1 + line.Substring(j, 1);
                    if ((line.Substring(j, 1) == " ") || (j == 45))
                    {
                        S1.Replace("-","");
                        scr[m, k] = S1;
                        S1 = "";
                        k++;
                    }
                }
                k = 0;
                m++;
            }
            //***copy string to byte matrix****
            for (int n = 0; n < m; n++)
            {
                for (int d = 2; d < 12; d++)
                {
                    bcr[n, d - 2] = byte.Parse(scr[n, d], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
            }
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Convert Log CAN29 Complete";

            return 1;
        }
        //=========================================================================================
        public byte log_can29(string path)
        {
            string line = "", S1 = "";
            Int32 Noline = 0, k = 0, m = 0;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sReader = new StreamReader(file, Encoding.UTF8);
            //***read data and copy to string matrix****
            while ((line = sReader.ReadLine()) != null)
            {
                Noline++;
                if (line == string.Empty)
                    continue;
                if (line.Length != 46)
                {
                    mt.resultlabel.BackColor = Color.Red;
                    mt.resultlabel.Text = "Line " + Noline.ToString() + " Error!";
                    return 0;
                }
                for (int j = 0; j < 46; j++)
                {
                    S1 = S1 + line.Substring(j, 1);
                    if ((line.Substring(j, 1) == " ") || (j == 45))
                    {
                        scr[m, k] = S1;
                        S1 = "";
                        k++;
                    }
                }
                k = 0;
                m++;
            }
            //***copy string to byte matrix****
            for (int n = 0; n < m; n++)
            {
                for (int d = 2; d < 12; d++)
                {
                    bcr[n, d - 2] = byte.Parse(scr[n, d], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
            }
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Convert Log CAN29 Complete";

            return 1;
        }
        //=========================================================================================
        public byte log_can11(string path)
        {
            string line = "", S1 = "";
            Int32 Noline = 0, k = 0, m = 0;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sReader = new StreamReader(file, Encoding.UTF8);
            //***read data and copy to string matrix****
            while ((line = sReader.ReadLine()) != null)
            {
                Noline++;
                if (line == string.Empty)
                    continue;
                if(line.Length != 40)
                {
                    mt.resultlabel.BackColor = Color.Red;
                    mt.resultlabel.Text = "Line " + Noline.ToString() + " Error!";
                    return 0;
                }
                for (int j = 0; j < 40; j++)
                {
                    S1 = S1 + line.Substring(j, 1);
                    if((line.Substring(j, 1) == " ")||(j == 39))
                    {
                        scr[m,k] = S1;
                        S1 = "";
                        k++;
                    }
                }
                k = 0;
                m++;
            }
            //***copy string to byte matrix****
            for (int n = 0; n < m; n++)
            {
                for (int d = 2; d < 10; d++)
                {
                    bcr[n, d - 2] = byte.Parse(scr[n, d], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
            }
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Convert Log CAN11 Complete";

            return 1;
        }
        //=========================================================================================
        public byte pro_detector(string path)
        {
            string line = "";
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sReader = new StreamReader(file, Encoding.UTF8);
            //***read data and copy to string matrix****
            while ((line = sReader.ReadLine()) != null)
            {
                if (line == string.Empty)
                    continue;
                if (line.Length == 40)
                {
                    return 1;
                }
                else if (line.Length == 46)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
                return 0;
        }
        //=========================================================================================
        public void cleartemp()
        {
            int i = 0;
            string Temp = @"C:\\MehadCo\\DiagLab\\temp";
            string S1 = @"C:\\MehadCo\\DiagLab\\temp";
            List<string> fs1 = new List<string>();
            //string Out = @"C:\\MehadCo\\DiagLab\\Out";
            try
            {
                fs1.AddRange(Directory.GetFiles(S1, "*.msg", SearchOption.AllDirectories));
                fs1.AddRange(Directory.GetFiles(S1, "*.xlsx", SearchOption.AllDirectories));
                fs1.AddRange(Directory.GetFiles(S1, "*.xls", SearchOption.AllDirectories));
                for (i = 0; i < fs1.Count; i++)
                    File.SetAttributes(fs1[i], File.GetAttributes(fs1[i]) & ~FileAttributes.ReadOnly);
                while (Directory.Exists(Temp) == true)
                {
                    Directory.Delete(Temp, true);
                    while (Directory.Exists(Temp) == true) ;
                }
                while (Directory.Exists(Temp) == false)
                {
                    Directory.CreateDirectory(Temp);
                    while (Directory.Exists(Temp) == false) ;
                }
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Clear Temp Complete";
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Could Not Find File Path";
            }
        }//clear temp content
        //=========================================================================================
        public void changedics()
        {
            try
            {
                if ((Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsFull")) && (Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsKavo")))
                {
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\Dics", @"C:\\MehadCo\\DiagLab\\DicsNull");
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\DicsFull", @"C:\\MehadCo\\DiagLab\\Dics");
                    mt.resultlabel.BackColor = Color.GreenYellow;
                    mt.resultlabel.Text = "Full Dics Selected";
                }
                else if ((Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsNull")) && (Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsKavo")))
                {
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\Dics", @"C:\\MehadCo\\DiagLab\\DicsFull");
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\DicsKavo", @"C:\\MehadCo\\DiagLab\\Dics");
                    mt.resultlabel.BackColor = Color.GreenYellow;
                    mt.resultlabel.Text = "Kavosh Dics Selected";
                }
                else if ((Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsNull")) && (Directory.Exists(@"C:\\MehadCo\\DiagLab\\DicsFull")))
                {
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\Dics", @"C:\\MehadCo\\DiagLab\\DicsKavo");
                    Directory.Move(@"C:\\MehadCo\\DiagLab\\DicsNull", @"C:\\MehadCo\\DiagLab\\Dics");
                    mt.resultlabel.BackColor = Color.GreenYellow;
                    mt.resultlabel.Text = "Null Dics Selected";
                }
                else
                {
                    mt.resultlabel.BackColor = Color.Red;
                    mt.resultlabel.Text = "Can Not Find Dics";
                }
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "App Error!";
            }
        }//change dictionary
        //=========================================================================================
        public void converthexasciibin()
        {
            bool hex = false, ascii = false, bin = false;
            string s1 = "", s2 = "";

            int i = 0;

            s1 = mt.converttextBox.Text;

            if (mt.hexradioButton.Checked)
            {
                mt.converttextBox.Text = inputhex(mt.converttextBox.Text);
            }
            else if (mt.asciiradioButton.Checked)
            {
                mt.converttextBox.Text = inputascii(mt.converttextBox.Text);
            }
            else if (mt.binaryradioButton.Checked)
            {
                mt.converttextBox.Text = inputbinary(mt.converttextBox.Text);
            }
            else
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Select Hex Ascii Bin Format";
            }
        }//convert hex ascii binary to each other
        //=========================================================================================
        public void main_sc_tosim()
        {
            List<string> jcfile_path = new List<string>();
            List<string> frmlist = new List<string>();
            List<string> uniqueList = new List<string>();
            bool b1 = false;
            //-----------------------------------
            scpath = select_folderbroser("Select The Script Folder");
            if (scpath != null)
            {
                frmpath = select_folderbroser("Select Output File Location");

                //FileStream frmfile = null;
                if (frmpath != null)
                {
                    jcfile_path = get_alljc_path(scpath, "*.jc");
                    if (jcfile_path != null)
                    {
                        frmlist = read_all_frm_form_script(jcfile_path);
                        if (frmlist != null)
                        {
                            b1 = write_orgin_frm_readed_tofile(frmlist);
                            if (b1 == true)
                            {
                                uniqueList = check_strfrm(frmlist);
                                if (uniqueList != null)
                                {
                                    b1 = make_sim_from_sc(uniqueList);
                                    if (b1 == true)
                                    {
                                        lable_message("Convert Script To Sim Complete", Color.GreenYellow);
                                        return;
                                    }
                                    else
                                    {
                                        lable_message("Convert Script To Sim Error!", Color.Red);
                                        return;
                                    }
                                }
                                else
                                {
                                    lable_message("Check String Frame List Error!", Color.Red);
                                    return;
                                }
                            }
                            else
                            {
                                lable_message("Write Orgin Frame To File Failed", Color.Red);
                                return;
                            }
                        }
                        else
                        {
                            lable_message("Read All Frame From jc Failed", Color.Red);
                            return;
                        }
                    }
                    else
                    {
                        lable_message("Read All .jc Path Failed", Color.Red);
                        return;
                    }
                }
                else
                {
                    lable_message("Cancel Script To Sim Proccess", Color.Red);
                    return;
                }
            }
            else
            {
                lable_message("Cancel Script To Sim Proccess", Color.Red);
                return;
            }
        }//main convert script to sim
        //=========================================================================================
        public string inputhex(string txtbox)
        {
            int i = 0;
            string s1 = "", s2 = "", hex1 = "0123456789ABCDEF";
            string outf = "", out1 = "", out2 = "", out3 = "", out4 = "", out5 = "";
            //-----------------------------------
            txtbox = txtbox.Replace("=", string.Empty);
            txtbox = txtbox.Replace("*", string.Empty);
            txtbox = txtbox.Replace(" ", string.Empty);
            txtbox = txtbox.Replace(",", string.Empty);
            txtbox = txtbox.Replace("0x", string.Empty);
            txtbox = txtbox.Replace("0X", string.Empty);
            txtbox = txtbox.Replace("\r\n", string.Empty);
            //-----------------------------------
            if (txtbox == string.Empty)
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Input Data Invalid";
                return null;
            }
            //-----------------------------------
            try
            {
                txtbox = txtbox.ToUpper();
                for (i = 0; i < txtbox.Length - 1; i++)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(txtbox.Substring(i, 1));
                    if (((bytes[0] < 0x30) || (bytes[0] > 0x46)) && ((bytes[0] < 0x61) || (bytes[0] > 0x66)))
                    {
                        mt.resultlabel.BackColor = Color.Red;
                        mt.resultlabel.Text = "Input Data Invalid";
                        return null;
                    }
                }
                //-----------------------------------
                if ((txtbox.Length % 2) != 0)
                {
                    txtbox = "0" + txtbox;
                    out1 = out1 + txtbox;
                }
                else
                    out1 = txtbox;
                out1 = out1 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out2 = out2 + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out2 = out2 + ",";
                }
                out2 = out2 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out3 = out3 + "0x" + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out3 = out3 + ",";
                }
                out3 = out3 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length; i += 2)
                {
                    s1 = txtbox.Substring(i, 2);
                    if (s1 != "00")
                    {
                        s2 = s2 + txtbox.Substring(i, 2);

                        if (i + 2 < txtbox.Length)
                            s2 = s2 + " ";
                    }
                }
                if (s2 != string.Empty)
                {
                    string[] tokens = s2.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    foreach (string token in tokens)
                        sb.Append((char)(hex1.IndexOf(token[0]) * 16 + hex1.IndexOf(token[1])));
                    s2 = sb.ToString();
                }
                out4 = s2 + "\r\n====================================***\r\n";
                //-----------------------------------
                s2 = "";
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    s2 = txtbox.Substring(i, 2);
                    out5 = out5 + String.Join(String.Empty, s2.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                    out5 = out5 + " ";
                }
                //-----------------------------------
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Convert Hex Complete";
                outf = out1 + out2 + out3 + out4 + out5;
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Input Data Invalid";
            }
            return outf;
        }//input hex format data convert to all supported format
        //=========================================================================================
        public string inputascii(string txtbox)
        {
            int i = 0;
            string s1 = "", s2 = "", hex1 = "0123456789ABCDEF";
            string outf = "", out1 = "", out2 = "", out3 = "", out4 = "", out5 = "";
            //-----------------------------------
            if (txtbox == string.Empty)
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Input Data Invalid";
                return null;
            }
            //-----------------------------------
            try
            {
                txtbox = string.Join(string.Empty, txtbox.Select(c => ((int)c).ToString("X")).ToArray());
                //-----------------------------------
                txtbox = txtbox.Replace("=", string.Empty);
                txtbox = txtbox.Replace("*", string.Empty);
                txtbox = txtbox.Replace(" ", string.Empty);
                txtbox = txtbox.Replace(",", string.Empty);
                txtbox = txtbox.Replace("0x", string.Empty);
                txtbox = txtbox.Replace("0X", string.Empty);
                txtbox = txtbox.Replace("\r\n", string.Empty);
                //-----------------------------------
                out1 = txtbox;
                out1 = out1 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out2 = out2 + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out2 = out2 + ",";
                }
                out2 = out2 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out3 = out3 + "0x" + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out3 = out3 + ",";
                }
                out3 = out3 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length; i += 2)
                {
                    s1 = txtbox.Substring(i, 2);
                    if (s1 != "00")
                    {
                        s2 = s2 + txtbox.Substring(i, 2);

                        if (i + 2 < txtbox.Length)
                            s2 = s2 + " ";
                    }
                }
                if (s2 != string.Empty)
                {
                    string[] tokens = s2.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    foreach (string token in tokens)
                        sb.Append((char)(hex1.IndexOf(token[0]) * 16 + hex1.IndexOf(token[1])));
                    s2 = sb.ToString();
                }
                out4 = s2 + "\r\n====================================***\r\n";
                //-----------------------------------
                s2 = "";
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    s2 = txtbox.Substring(i, 2);
                    out5 = out5 + String.Join(String.Empty, s2.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                    out5 = out5 + " ";
                }
                //-----------------------------------
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Convert Ascii Complete";
                outf = out1 + out2 + out3 + out4 + out5;
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Input Data Invalid";
            }
            return outf;
        }//input ascii format data convert to all supported format
        //=========================================================================================
        public string inputbinary(string txtbox)
        {
            int i = 0;
            string s1 = "", s2 = "", hex1 = "0123456789ABCDEF";
            string outf = "", out1 = "", out2 = "", out3 = "", out4 = "", out5 = "";
            //-----------------------------------
            txtbox = txtbox.Replace("=", string.Empty);
            txtbox = txtbox.Replace("*", string.Empty);
            txtbox = txtbox.Replace(" ", string.Empty);
            txtbox = txtbox.Replace(",", string.Empty);
            txtbox = txtbox.Replace("0x", string.Empty);
            txtbox = txtbox.Replace("0X", string.Empty);
            txtbox = txtbox.Replace("\r\n", string.Empty);
            //-----------------------------------
            try
            {
                for (i = 0; i < txtbox.Length - 1; i++)//check binary or ascii format
                {
                    if ((txtbox.Substring(i, 1) != "0") && (txtbox.Substring(i, 1) != "1"))
                    {
                        mt.resultlabel.BackColor = Color.Red;
                        mt.resultlabel.Text = "Input Data Invalid";
                        return null;
                    }
                }
                //-----------------------------------
                if ((txtbox.Length % 4) == 1)
                {
                    txtbox = "000" + txtbox;
                }
                else if ((txtbox.Length % 4) == 2)
                {
                    txtbox = "00" + txtbox;
                }
                else if ((txtbox.Length % 4) == 3)
                {
                    txtbox = "0" + txtbox;
                }
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 4)
                {
                    s2 = txtbox.Substring(i, 4);
                    out1 = out1 + Convert.ToInt64(s2, 2).ToString("X");
                }
                txtbox = out1;
                s2 = "";
                out1 = "";
                //-----------------------------------
                if ((txtbox.Length % 2) != 0)
                {
                    txtbox = "0" + txtbox;
                    out1 = out1 + txtbox;
                }
                else
                    out1 = txtbox;
                out1 = out1 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out2 = out2 + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out2 = out2 + ",";
                }
                out2 = out2 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    out3 = out3 + "0x" + txtbox.Substring(i, 2);
                    if (i != txtbox.Length - 2)
                        out3 = out3 + ",";
                }
                out3 = out3 + "\r\n====================================***\r\n";
                //-----------------------------------
                for (i = 0; i < txtbox.Length; i += 2)
                {
                    s1 = txtbox.Substring(i, 2);
                    if (s1 != "00")
                    {
                        s2 = s2 + txtbox.Substring(i, 2);

                        if (i + 2 < txtbox.Length)
                            s2 = s2 + " ";
                    }
                }
                if (s2 != string.Empty)
                {
                    string[] tokens = s2.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    foreach (string token in tokens)
                        sb.Append((char)(hex1.IndexOf(token[0]) * 16 + hex1.IndexOf(token[1])));
                    s2 = sb.ToString();
                }
                out4 = s2 + "\r\n====================================***\r\n";
                //-----------------------------------
                s2 = "";
                for (i = 0; i < txtbox.Length - 1; i += 2)
                {
                    s2 = txtbox.Substring(i, 2);
                    out5 = out5 + String.Join(String.Empty, s2.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                    out5 = out5 + " ";
                }
                //-----------------------------------
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Convert Binary Complete";
                outf = out1 + out2 + out3 + out4 + out5;
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Input Data Invalid";
            }
            return outf;
        }//input binary format data convert to all supported format
        //=========================================================================================
        public string obdconnector()
        {
            string outf = "", out1 = "";
            //-----------------------------------
            out1 = out1 + "                            OBDII";
            out1 = out1 + "\r\n  ###########################";
            out1 = out1 + "\r\n   ##    1    2    3    4    5    6    7    8   ##";
            out1 = out1 + "\r\n    ##   9  10  11  12  13  14  15  16  ##";
            out1 = out1 + "\r\n     ########################";
            out1 = out1 + "\r\n\r\n1.Blank			9.Blank";
            out1 = out1 + "\r\n2.J1850 Bus+		10.J1850 Bus";
            out1 = out1 + "\r\n3.Blank			11.Blank";
            out1 = out1 + "\r\n4.Chassis Ground		12.Blank";
            out1 = out1 + "\r\n5.Signal Ground		13.Signal Ground";
            out1 = out1 + "\r\n6.CAN (J-2234) High	14.CAN (J-2234) Low";
            out1 = out1 + "\r\n7.ISO 9141-2 K-Line	15.ISO 9141-2 Low";
            out1 = out1 + "\r\n8.Blank			16.Battery Power";
            //-----------------------------------
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Print OBDII Pinout Complete";
            outf = out1;
            return outf;
        }//print obdii pinout
        //=========================================================================================
        public string ecuidsupport()
        {
            string outf = "", out1 = "";
            //-----------------------------------
            out1 = "==========START==========\r\n";
            out1 = out1 + "0x10 : Start Diagnostic Session\r\n";
            out1 = out1 + "0x11 : ECU Reset\r\n";
            out1 = out1 + "0x12 : Read Freeze Frame Data\r\n";
            out1 = out1 + "0x13 : Read Diagnostic Trouble Codes\r\n";
            out1 = out1 + "0x14 : Clear Diagnostic Information\r\n";
            out1 = out1 + "0x17 : Read Status Of Diagnostic Trouble Codes\r\n";
            out1 = out1 + "0x18 : Read Diagnostic Trouble Codes By Status\r\n";
            out1 = out1 + "0x1A : Read Ecu Id\r\n";
            out1 = out1 + "0x20 : Stop Diagnostic Session\r\n";
            out1 = out1 + "0x21 : Read Data By Local Id\r\n";
            out1 = out1 + "0x22 : Read Data By Common Id\r\n";
            out1 = out1 + "0x23 : Read Memory By Address\r\n";
            out1 = out1 + "0x25 : Stop Repeated Data Transmission\r\n";
            out1 = out1 + "0x26 : Set Data Rates\r\n";
            out1 = out1 + "0x27 : Security Access\r\n";
            out1 = out1 + "0x2C : Dynamically Define Local Id\r\n";
            out1 = out1 + "0x2E : Write Data By Common Id\r\n";
            out1 = out1 + "0x2F : Input Output Control By Common Id\r\n";
            out1 = out1 + "0x30 : Input Output Control By Local Id\r\n";
            out1 = out1 + "0x31 : Start Routine By Local ID\r\n";
            out1 = out1 + "0x32 : Stop Routine By Local ID\r\n";
            out1 = out1 + "0x33 : Request Routine Results By Local Id\r\n";
            out1 = out1 + "0x34 : Request Download\r\n";
            out1 = out1 + "0x35 : Request Upload\r\n";
            out1 = out1 + "0x36 : Transfer data\r\n";
            out1 = out1 + "0x37 : Request transfer exit\r\n";
            out1 = out1 + "0x38 : Start Routine By Address\r\n";
            out1 = out1 + "0x39 : Stop Routine By Address\r\n";
            out1 = out1 + "0x3A : Request Routine Results By Address\r\n";
            out1 = out1 + "0x3B : Write Data By Local Id\r\n";
            out1 = out1 + "0x3D : Write Memory By Address\r\n";
            out1 = out1 + "0x3E : Tester Present\r\n";
            out1 = out1 + "0x81 : Start Communication\r\n";
            out1 = out1 + "0x82 : Stop Communication\r\n";
            out1 = out1 + "0x83 : Access Timing Parameters\r\n";
            out1 = out1 + "0x85 : Start Programming Mode\r\n";
            out1 = out1 + "==========END==========";
            //-----------------------------------
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Print ECU ID Complete";
            outf = out1;
            return outf;
        }//All ECU ID Supported
        //=========================================================================================
        public string list7F()
        {
            string outf = "", out1 = "", str = "";
            int value = 0;
            //-----------------------------------
            try
            {
                if (mt.textBox7F.Text != string.Empty)
                {
                    mt.textBox7F.Text = mt.textBox7F.Text.ToUpper();
                    str = "0x" + mt.textBox7F.Text;
                    value = Convert.ToInt32(mt.textBox7F.Text, 16);
                    switch (value)
                    {
                        case 0x00:
                            out1 = "Positive Response\r\nThe 0x00 is a special and initiative value that can not be used for ant NRC. It is this parameter value reserved for several internal code implementation reason.";
                            break;
                        case 0x10:
                            out1 = "General Reject\r\nIf there is none of the NRC is available in UDS standard document to meet the needs of the implementation, then you can use this NRC for your ECU.";
                            break;
                        case 0x11:
                            out1 = "Service Not Supported\r\nSuppose the client has sent a request with a Service Identifier. That is not supporting in your ECU by your OEM. Even if you can also say as per the requirement or as per the OEM. But the service engineer or client has requested that unknown SID request to the server. Then the server will send the 0x11 NRC response message to the client that it is an unknown Service Identifier.";
                            break;
                        case 0x12:
                            out1 = "Sub - function Not Supported\r\nSuppose the client has sent a valid and known Service identifier. But the Sub-function Identifier is unknown or invalid. then the server will send 0x12 Negative Response Code to the client.";
                            break;
                        case 0x13:
                            out1 = "Incorrect Message Length Or Invalid Format\r\nIf the client has sent any diagnostic request message whose length or the frame format does not match with the prescribed length or the format for that specified service (SID), then the server will send this NRC.";
                            break;
                        case 0x14:
                            out1 = "Response Too Long\r\nIf the client has sent a diagnostic request and the response message length is more than the Transport protocol maximum length, then the server will send this NRC. The CAN-TP has 4096 bytes has a maximum length, if the server will send more than that, then this NRC will be sent by the server to the client. Ex: suppose you requested more number of DIDs at a time to read the data if it will cross that limit, then this NRC will get generated by the server.";
                            break;
                        case 0x21:
                            out1 = "Busy Repeat Request\r\nIf the server is too busy with some other operation or you can say any other client request in a multi-client environment, then the server will send this NRC to the client. This NRC is supported by each SID.\r\nEx: Suppose there are two clients connected to your vehicle simultaneously. One client has already requested a service that is under process means incomplete and the second client is requesting another request to the server then the server will send the NRC 0x21 to the second server to wait for some time. This time will be defined in the document that you need to check.";
                            break;
                        case 0x22:
                            out1 = "Conditions Not Correct\r\nBefore proceeding any service from the client, the server will check for prerequisite conditions are met or not. If not then the server will send this NRC.\r\nEx: you can say the ECU operational low threshold or high threshold voltage, temperature, etc.";
                            break;
                        case 0x23:
                            out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            break;
                        case 0x24:
                            out1 = "Request Sequence Error\r\nIf the client will send the diagnostic message non-sequentially, then the server will send this NRC to the client.\r\nEx: Suppose in security access SID, the client sent security key first and then seed request, then the server will send this NRC.because in this 0x27 service, the client should send the seed request first and then the security key.";
                            break;
                        case 0x25:
                            out1 = "No Response From Sub-net Component\r\nSuppose the diagnostic request service sent by the client to the server, but the received ECU is not the target ECU and it is a gateway. So that the Gateway ECU will send this request to the target ECU and that should perform the operation and send back the response message to the Gateway ECU, and then it will send the response message. If the Gateway ECU does not receive the response message from that target ECU or server then the Gateway ECU will send this NRC to the client.\r\nThis NRC supported by each SID.";
                            break;
                        case 0x26:
                            out1 = "Failure Prevents Execution Of Requested Action\r\nIf the client requested service and at that time a fault occurred in server ECU after receiving of this ECU so that at least one DTC status bit for TestFailed, Pending, Confirmed or TestFailedSinceLastClear set to 1, then the server will send this NRC to the client. Basically this failure condition prevents the server from performing the requested action so that the server will not able to execute the client request.";
                            break;
                        case 0x31:
                            out1 = "Request Out Of Range\r\nIf the server received a client request with a parameter (DID, RID) that is out of range, then the server will send this NRC. Suppose in your ECU, the DID or RID having some range used and the client requesting it which is not supported in your ECU or might be not supported in this active session, it will send this NRC.";
                            break;
                        case 0x32:
                            out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            break;
                        case 0x33:
                            out1 = "Security Access Denied\r\nThe server will send this NRC if the security strategy is not satisfied with the server. The Server will send this NRC if any of the below conditions will not satisfy:\r\nServer test conditions are not met.\r\nService message sequence(first diagnostic session and then security access service request).\r\nThe server needs to unlock by the client for some read or write access to the server, but without unlock, a client trying to access the protected memory.";
                            break;
                        case 0x34:
                            out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            break;
                        case 0x35:
                            out1 = "Invalid Key\r\nIf the server received a security key from the client that is not matching with the server-generated key, then the server will send this NRC.";
                            break;
                        case 0x36:
                            out1 = "exceed Number Of Attempts\r\nBasically, in each server, there will be a security retrieval counter and it will be having a limit like 3 or 5 times. So if a client will send the wrong security key more than the defined counter value, the server will send this NRC to the client.";
                            break;
                        case 0x37:
                            out1 = "Required Time Delay Not Expired\r\nOnce the client will send a wrong security key, client should wait the defined time, and then it should send the key again. But if the client will send the security key before that then the server will send this NRC.";
                            break;
                        case 0x70:
                            out1 = "Upload Download Not Accepted\r\nSometimes due to some fault conditions in the server or server memory, it will not accept any upload or download request from the client.";
                            break;
                        case 0x71:
                            out1 = "Transfer Data Suspended\r\nDuring the data transfer, sometimes due to some failure of any kind of fault, the server will not able to write data onto the memory. So in that situation, the server will send this NRC to the client.";
                            break;
                        case 0x72:
                            out1 = "General Programming Failure\r\nIf the server detects an error during the erasing or programming of the memory location of permanent memory (e.g. NVM/Flash/EEPROM), then the server will send this NRC to the client.";
                            break;
                        case 0x73:
                            out1 = "Wrong Block Sequence Counter\r\nBasically whenever a multi-frame consecutive data packets sent by the client to server. In the Consecutive Frame, there will be a Frame index that will increase in each next frame. The server also receives that and compares it with the previous value that should be +1 in each current frame received. If there is any miss match, the server will send this NRC to the client.";
                            break;
                        case 0x78:
                            out1 = "Request Correctly Received-Response Pending\r\nThis NRC indicates that the request message from client successfully received by the server. All the requested parameters are also valid. But the server is not ready or due to busy or it is taking some more time to execute the client request in the defined server parameter. So if the client sends another request or the server P2 Client time out happened, the server will send this NRC to the client to inform that to wait for some more time period nothing but the P2* Client timing value. After the execution, the server will send either a positive or negative response message.";
                            break;
                        case 0x7E:
                            out1 = "Sub-function Not Supported In Active Session\r\nThis NRC will return by the server if the requested sub-function Identifier is not supported in this session. basically, in UDS protocol there are 3 sessions. In each session what services and their sub-functions will support it will be decided by the OEM. If the tester will request a service with a correct subfunction for this service Identifier but that is not supported in this session, then obviously the server will send this NRC to the client. But remember there might be a possibility that the same sub-function and service Identifier will support in any other session.";
                            break;
                        case 0x7F:
                            out1 = "Service Not Supported In Active Session\r\nThis NRC will return by the server if the requested service identifier is not supported in this session.";
                            break;
                        case 0x80:
                            out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            break;
                        case 0x81:
                            out1 = "Rpm Too High\r\nThis NRC indicates that the requested action sent by the client will not be taken because the server prerequisite condition for RPM is higher than the defined value in ECU or server.";
                            break;
                        case 0x82:
                            out1 = "Rpm Too Low\r\nThis NRC indicates that the requested action sent by the client will not be taken because the server prerequisite condition for RPM is lower than the defined value in ECU or server.";
                            break;
                        case 0x83:
                            out1 = "Engine Is Running";
                            break;
                        case 0x84:
                            out1 = "Engine Is Not Running";
                            break;
                        case 0x85:
                            out1 = "Engine Run Time Too Low";
                            break;
                        case 0x86:
                            out1 = "Temperature is Too High";
                            break;
                        case 0x87:
                            out1 = "Temperature is Too Low";
                            break;
                        case 0x88:
                            out1 = "Vehicle Speed is Too High";
                            break;
                        case 0x89:
                            out1 = "Vehicle Speed is Too Low";
                            break;
                        case 0x8A:
                            out1 = "Throttle/Pedal is Too High";
                            break;
                        case 0x8B:
                            out1 = "Throttle/Pedal IS Too Low";
                            break;
                        case 0x8C:
                            out1 = "Transmission Range Is Not In Neutral";
                            break;
                        case 0x8D:
                            out1 = "Transmission Range is Not In Gear";
                            break;
                        case 0x8E:
                            out1 = "ISO SAE Reserved";
                            break;
                        case 0x8F:
                            out1 = "Brake Switch(es) Not Closed (Brake Pedal not pressed or not applied)";
                            break;
                        case 0x90:
                            out1 = "Shifter Lever Not In Park";
                            break;
                        case 0x91:
                            out1 = "Torque Converter Clutch is Locked";
                            break;
                        case 0x92:
                            out1 = "Voltage is Too High";
                            break;
                        case 0x93:
                            out1 = "Voltage Too Low";
                            break;
                        case 0xFF:
                            out1 = "ISO SAE Reserved";
                            break;
                        default:
                            if ((value >= 0x01) && (value <= 0x0F))
                                out1 = "ISO SAE Reserved\r\nThis range of NRC is reserved for the future definition that maybe increase the diagnostic functionality more.";
                            else if ((value >= 0x15) && (value <= 0x20))
                                out1 = "ISO SAE Reserved\r\nThis range of NRC is also reserved for the future definition that maybe increase the diagnostic functionality more.";
                            else if ((value >= 0x27) && (value <= 0x30))
                                out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            else if ((value >= 0x38) && (value <= 0x4F))
                                out1 = "Reserved By Extended Data Link Security Document\r\nThis is reserved for future implementation of security layer related NRC";
                            else if ((value >= 0x50) && (value <= 0x6F))
                                out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            else if ((value >= 0x74) && (value <= 0x77))
                                out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            else if ((value >= 0x79) && (value <= 0x7D))
                                out1 = "ISO SAE Reserved\r\nThis NRC is also reserved for the future definition.";
                            else if ((value >= 0x94) && (value <= 0xEF))
                                out1 = "Reserved For Specific Conditions Not Correct";
                            else if ((value >= 0xF0) && (value <= 0xFE))
                                out1 = "Vehicle Manufacturer Specific Conditions Not Correct";
                            else
                                out1 = "7F Undefined";
                            break;
                    }
                }
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Print 7F Description Complete";
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Print 7F Description Failed";
            }
            //-----------------------------------

            outf = out1;
            return outf;
        }//print 7f response description
        //=========================================================================================
        public string initialpin()
        {
            string outf = "", out1 = "";
            //-----------------------------------
            out1 = "initial(Baudrate, k, state);\r\n";
            out1 = out1 + "Line======= k === DB15 === OBD\r\n";
            out1 = out1 + "EMS	   0x00	    7	    7\r\n";
            out1 = out1 + "BSI	   0x01	   12	    11\r\n";
            out1 = out1 + "AIRBAG	   0x11	   13	    13\r\n";
            out1 = out1 + "CPH	   0x21	    6	     6\r\n";
            out1 = out1 + "ABS	   0x10	    4	    12\r\n";
            out1 = out1 + "K5	   0x30	    5	    14\r\n";
            out1 = out1 + "K8	   0x40	    2	     2\r\n";
            out1 = out1 + "K9	   0x41	    3	    10\r\n";
            out1 = out1 + "OBD3	   0x04	   11	     3\r\n";
            out1 = out1 + "OBD8	   0x08	    8	     8\r\n";
            out1 = out1 + "OBD9	   0x0C	    9	     9\r\n\r\n";
            out1 = out1 + "======= state ===== DB15 ==== OBD\r\n";
            out1 = out1 + "KWP	   0\r\n";
            out1 = out1 + "CAN	   1	     5,6	      14,6\r\n";
            out1 = out1 + "CAN	   2	    12,11	      11,3\r\n";
            out1 = out1 + "CAN	   3	     8,11	      8,11";
            //-----------------------------------
            mt.resultlabel.BackColor = Color.GreenYellow;
            mt.resultlabel.Text = "Print Initial Pin Complete";
            outf = out1;
            return outf;
        }//print all pin initial value
        //=========================================================================================
        public bool make_sim_from_sc(List<string> uniqueList)
        {
            int i = 0;
            byte protocoltype = 0;
            string s1 = "", s2 = "";
            string outf = "", out1 = "";
            string str = "";
            //-----------------------------------
            try
            {
                for (i = 0; i < uniqueList.Count; i++)
                {
                    info = strfrm2bytearray(uniqueList[i]);
                    if (info.Length > 13)
                    {
                        if ((info[10] == 0x44) && (info[11] == 0x46))
                        {
                            address[0] = info[16];
                            address[1] = info[17];
                            address[2] = info[18];
                            address[3] = info[19];
                            address[4] = info[12];
                            address[5] = info[13];
                            address[6] = info[14];
                            address[7] = info[15];
                            baudrate[0] = info[24];
                            baudrate[1] = info[25];
                        }
                    }
                }
                for (i = 0; i <= uniqueList.Count - 1; i++)
                {
                    info = strfrm2bytearray(uniqueList[i]);
                    if ((info[0] == 0x55) && (info[1] == 0x47))
                    { }
                    else
                    {
                        protocoltype = detect_protocol(info);
                        if (protocoltype == 0x00)//KWP1
                        {
                            str = str + kwp1_response_lib(info);
                        }
                        else if (protocoltype == 0x01)//KWP2
                        {
                            str = str + kwp2_response_lib(info);
                        }
                        else if (protocoltype == 0x10)//CAN11
                        {
                            str = str + can1_response_lib(info);
                        }
                        else if (protocoltype == 0x20)//CAN29
                        {
                            //can29_response_lib(info);
                        }
                        else if (protocoltype == 0xFF)//Undefined
                        {

                        }
                    }

                    /*if (info[0] == 0x18)
                    {
                        info[0] = address[0];
                        info[1] = address[1];
                        info[2] = address[2];
                        info[3] = address[3];
                    }
                    else if ((info[0] * 256 + info[1]) <= 0x1FFF)
                    {
                        info[0] = address[2];
                        info[1] = address[3];
                    }
                    else if (info[0] >= 0x80)
                    {
                        kaddress[0] = 0;
                        kaddress[1] = 0;
                    }
                    if ((info[0] != 0x55) && (info[1] != 0x47))
                    {
                        str = str + "C={" + BitConverter.ToString(info).Replace("-", ",") + "};\r\n";
                        str = str + make_response_frm(info);
                    }*/
                }
                if (File.Exists(frmpath + "\\scsim.sim"))
                {
                    File.Delete(frmpath + "\\scsim.sim");
                }
                str = sim_initial(info) + str;
                File.AppendAllText(frmpath + "\\scsim.sim", str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=========================================================================================
        public static byte[] strfrm2bytearray(string hex)
        {
            byte[] b1 = { 0, 0, 0, 0, 0, 0, 0 };
            string s1;
            int j = 0, k = 0;
            //hex = hex.Replace(",",string.Empty);
            hex = hex.Replace("0x", string.Empty);

            return Enumerable.Range(0, hex.Length)
                                .Where(x => x % 2 == 0)
                                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                .ToArray();
        }//convert hex string to byte array 
        //=========================================================================================
        public List<string> get_alljc_path(string s1, string s2)
        {
            List<string> jcfile_path = new List<string>();
            //-----------------------------------
            try
            {
                jcfile_path.AddRange(Directory.GetFiles(scpath, s2, SearchOption.AllDirectories));
                return jcfile_path;
            }
            catch
            {
                return null;
            }
        }//get all .jc path
        //=========================================================================================
        public List<string> read_all_frm_form_script(List<string> jcpath)
        {
            //byte[] rddata = { 0 };
            string linestr = "";
            string outf = "", out1 = "", s1 = "";
            int i = 0, j = 0;
            List<string> frmlist = new List<string>();
            //-----------------------------------
            try
            {
                frmlist.Clear();
                for (int cntpath = 0; cntpath < jcpath.Count; cntpath++)
                {
                    StreamReader file = new System.IO.StreamReader(jcpath[cntpath]);
                    while ((linestr = file.ReadLine()) != null)
                    {
                        linestr = linestr.Replace(" ", string.Empty);
                        linestr = linestr.Replace("\t", string.Empty);
                        if (linestr.Length > 16)
                        {
                            if ((linestr.Substring(0, 6) == "send({") || (linestr.Substring(0, 5) == "CAN({") || (linestr.Substring(0, 5) == "KWP({") || (linestr.Substring(0, 9) == "KWP2000({") || (linestr.Substring(0, 16) == "sendAndReceive({") || (linestr.Substring(0, 15) == "autoHandshake({"))
                            {
                                linestr = linestr.Replace("send({", string.Empty);
                                linestr = linestr.Replace("CAN({", string.Empty);
                                linestr = linestr.Replace("KWP({", string.Empty);
                                linestr = linestr.Replace("KWP2000({", string.Empty);
                                linestr = linestr.Replace("sendAndReceive({", string.Empty);
                                linestr = linestr.Replace("autoHandshake({", string.Empty);
                                for (i = 0; i < linestr.Length - 1; i++)
                                {
                                    s1 = linestr.Substring(i, 1);
                                    if (s1 == "}")
                                        break;
                                    out1 = out1 + s1;
                                }
                                frmlist.Add(out1);
                                out1 = "";
                                s1 = "";
                            }
                            /*else if (bytestr.Substring(0, 15) == "autoHandshake({")
                            {
                                bytestr = bytestr.Replace("autoHandshake({", string.Empty);
                                for (i = 0; i < bytestr.Length - 1; i++)
                                {
                                    s1 = bytestr.Substring(i, 1);
                                    if (s1 == "}")
                                        break;
                                    out1 = out1 + s1;
                                }
                                frmlist.Add(out1);
                                outf = outf + out1 + "\r\n";
                                out1 = "";
                                for (i = i + 3; i < bytestr.Length - 1; i++)
                                {
                                    s1 = bytestr.Substring(i, 1);
                                    if (s1 == "}")
                                        break;
                                    out1 = out1 + s1;
                                }
                                frmlist.Add(out1);
                                outf = outf + out1 + "\r\n";
                            }*/
                            else if (linestr.Substring(0, 8) == "signal({")
                            {
                                linestr = linestr.Replace("signal({", string.Empty);
                                for (i = 0; i < linestr.Length - 1; i++)
                                {
                                    s1 = linestr.Substring(i, 1);
                                    if (s1 == "{")
                                    {
                                        break;
                                    }
                                }
                                for (i = i + 1; i < linestr.Length - 1; i++)
                                {
                                    s1 = linestr.Substring(i, 1);
                                    if (s1 == "}")
                                    {
                                        break;
                                    }
                                    out1 = out1 + s1;
                                }
                                if (out1 != "0")
                                    frmlist.Add(out1);
                                out1 = "";
                                s1 = "";
                            }
                        }
                    }
                }
                return frmlist;
            }
            catch
            {
                return null;
            }
        }//read all frame from script
        //=========================================================================================
        public bool write_orgin_frm_readed_tofile(List<string> frmlist)
        {
            string str = "";
            //-----------------------------------
            try
            {
                for (int i = 0; i < frmlist.Count - 1; i++)
                {
                    str = str + frmlist[i] + "\r\n";
                }
                if (File.Exists(frmpath + "\\allfrm.frm"))
                {
                    File.Delete(frmpath + "\\allfrm.frm");
                }
                File.AppendAllText(frmpath + "\\allfrm.frm", str);
                return true;
            }
            catch
            {
                return false;
            }
        }//write original frame in file.frm
        //=========================================================================================
        public List<string> check_strfrm(List<string> ls1)
        {
            List<string> strlist = new List<string>();
            List<string> uniqueList = new List<string>();
            string str = "", s1 = "", s2 = "";
            //-----------------------------------
            try
            {
                uniqueList = ls1.Distinct().ToList();
                for (int i = 0; i < uniqueList.Count; i++)
                {
                    strlist.Clear();
                    str = uniqueList[i];
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str.Substring(j, 1) == ",")
                        {
                            strlist.Add(s1);
                            s1 = "";
                            j++;
                        }
                        s1 = s1 + str.Substring(j, 1);
                    }
                    strlist.Add(s1);
                    str = "";
                    for (int k = 0; k < strlist.Count; k++)
                    {
                        s1 = strlist[k];
                        if (s1.Substring(0, 2) != "0x")
                            strlist[k] = "0x00";
                        s2 = s2 + strlist[k];
                    }
                    uniqueList[i] = s2;
                    s1 = s2 = "";
                }
                for(int i=0;i< uniqueList.Count;i++)
                {
                    if((uniqueList[i].Substring(0,8)== "0x550x47")&&(uniqueList[i].Substring(44, 4) == "0x46"))
                    {
                        if ((uniqueList[i].Substring(56, 4) == "0x00") || (uniqueList[i].Substring(60, 4) == "0x00"))
                        {
                            uniqueList.RemoveAt(i);
                        }
                    }
                }
                mt.resultlabel.BackColor = Color.GreenYellow;
                mt.resultlabel.Text = "Check Frame String Complete";
                return uniqueList;
            }
            catch
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Check Frame String Failed";
                return null;
            }
        }//check frm structure
        //=========================================================================================
        public string make_response_frm(byte[] inf)
        {
            string s = "R={";
            byte b1 = 0, b2 = 0;
            //-----------------------------------
            try
            {
                if (info[0] >= 80)//KWP
                {
                    initial = "I={1,7,10400,0,0};\r\n\r\n";
                    if (info[0] == 0x80)
                    {
                        info[4] = Convert.ToByte(info[4] + 0x40);
                        b1 = info[1];
                        b2 = info[2];
                        info[1] = b2;
                        info[2] = b1;
                        s = "R={" + BitConverter.ToString(info).Replace("-", ",") + "};\r\n\r\n";
                    }
                    else if (info[0] > 0x80)
                    {
                        info[3] = Convert.ToByte(info[3] + 0x40);
                        b1 = info[1];
                        b2 = info[2];
                        info[1] = b2;
                        info[2] = b1;
                        s = "R={" + BitConverter.ToString(info).Replace("-", ",") + "};\r\n\r\n";
                    }
                }
                else if ((address[0] == 0x00) && (address[1] == 0x00))//CAN11
                {
                    initial = "I={3,1,500000,0,0};\r\n\r\n";
                    //s = s + frm_response_lib(inf,2);
                    info[2] = Convert.ToByte(info[2] + 0x40);
                    info[0] = address[6];
                    info[1] = address[7];
                    s = "R={" + BitConverter.ToString(info).Replace("-", ",") + "};\r\n\r\n";

                }
                else if ((address[0] != 0x00) || (address[1] != 0x00))//CAN29
                {
                    initial = "I={3,1,250000,0,0};\r\n\r\n";
                    info[2] = Convert.ToByte(info[2] + 0x40);
                    info[0] = address[6];
                    info[1] = address[7];
                    s = "R={" + "18,DA," + BitConverter.ToString(info).Replace("-", ",") + "};\r\n\r\n";
                }
                else
                {
                    s = "R={" + "00,00,00,00,00,00,00};\r\n\r\n";
                }
            }
            catch
            {
                s = "R={" + "00,00,00,00,00,00,00};\r\n\r\n";
            }

            return s;
        }
        //=========================================================================================
        public byte detect_protocol(byte[] ba)
        {
            byte[] b1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A };
            int a = 0;
            byte protocoltype = 0xFF;
            //-----------------------------------
            if (ba[0] >= 0x80)
            {
                if (ba[0] > 0x80)
                {
                    protocoltype = 0x00;
                }
                else if (ba[0] == 0x80)
                {
                    protocoltype = 0x01;
                }
            }
            else if ((address[0] == 0x00) && (address[1] == 0x00))//CAN11
            {
                protocoltype = 0x10;
            }
            else if ((address[0] != 0x00) || (address[1] != 0x00))//CAN29
            {
                protocoltype = 0x20;
            }
            else
            {
                protocoltype = 0xFF;
            }
            return protocoltype;
        }//detect protocol
        //=========================================================================================
        public string select_folderbroser(string s1)
        {
            FolderBrowserDialog jcfile = new FolderBrowserDialog();
            string path = "";
            //-----------------------------------
            jcfile.Description = s1;
            jcfile.SelectedPath = @"C:\MehadCo\DiagLab\Projects";
            //jcfile.SelectedPath = path;
            if (jcfile.ShowDialog() == DialogResult.OK)
            {
                path = jcfile.SelectedPath;
            }
            else
            {
                mt.resultlabel.BackColor = Color.Red;
                mt.resultlabel.Text = "Cancel Script To Sim Proccess";
                return null;
            }

            return path;
        }//select folder browser path
        //=========================================================================================
        public bool lable_message(string s1, Color color1)
        {
            //-----------------------------------
            mt.resultlabel.BackColor = color1;
            mt.resultlabel.Text = s1;
            return true;
        }//show message at the bottom of the form
        //=========================================================================================
        public string kwp1_response_lib(byte[] ba)
        {
            byte[] f21 = { 0xBE, 0x00, 0x00, 0x61, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x00 };
            byte[] f22XX = { 0x87, 0x00, 0x00, 0x62, 0x00, 0x00, 0x34, 0x35, 0x36, 0x37, 0x00 };
            byte[] f31 = { 0x85, 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] f22F1 = { 0x95, 0x00, 0x00, 0x62, 0xF1, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x00 };
            byte[] f2E3B = { 0x83, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00 };
            byte[] f3436 = { 0x82, 0x00, 0x00, 0x76, 0x00, 0x00 };
            byte[] f2701 = { 0x86, 0x00, 0x00, 0x67, 0x00, 0x01, 0x02, 0x03, 0x04, 0x00 };
            byte[] f2702 = { 0x82, 0x00, 0x00, 0x67, 0x00, 0x00 };
            byte[] general = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            string sout = "";
            int a = 0,i=0;
            //-----------------------------------
            sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
            if (ba[3] == 0x21)
            {
                //f21[0] = 0xBE;//len
                f21[2] = ba[1];
                f21[1] = ba[2];
                f21[3] = Convert.ToByte(ba[3] + 0x40);
                f21[4] = ba[4];
                for (i = 0; i < f21.Length - 1; i++)
                {
                    f21[f21.Length - 1] = (byte)(f21[f21.Length - 1] + f21[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f21).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[3] == 0x22) && (ba[4] == 0xF1))
            {
                //f22F1[0] = 0x95;//len
                f22F1[2] = ba[1];
                f22F1[1] = ba[2];
                f22F1[3] = Convert.ToByte(ba[3] + 0x40);
                f22F1[4] = ba[4];
                for (i = 0; i < f22F1.Length - 1; i++)
                {
                    f22F1[f22F1.Length - 1] = (byte)(f22F1[f22F1.Length - 1] + f22F1[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if (ba[3] == 0x1A)
            {
                //f22F1[0] = 0x95;//len
                f22F1[2] = ba[1];
                f22F1[1] = ba[2];
                f22F1[3] = Convert.ToByte(ba[3] + 0x40);
                f22F1[4] = ba[4];
                for (i = 0; i < f22F1.Length - 1; i++)
                {
                    f22F1[f22F1.Length - 1] = (byte)(f22F1[f22F1.Length - 1] + f22F1[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[3] == 0x2E) || (ba[3] == 0x3B))
            {
                //f2E3B[0] = 0x83;//len
                f2E3B[2] = ba[1];
                f2E3B[1] = ba[2];
                f2E3B[3] = Convert.ToByte(ba[3] + 0x40);
                f2E3B[4] = ba[4];
                f2E3B[5] = ba[5];
                for (i = 0; i < f2E3B.Length - 1; i++)
                {
                    f2E3B[f2E3B.Length - 1] = (byte)(f2E3B[f2E3B.Length - 1] + f2E3B[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2E3B).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else if ((ba[3] == 0x34) || (ba[3] == 0x36))
            {
                //f3436[0] = 0x83;//len
                f3436[2] = ba[1];
                f3436[1] = ba[2];
                f3436[3] = Convert.ToByte(ba[3] + 0x40);
                f3436[4] = ba[4];
                f3436[5] = ba[5];
                for (i = 0; i < f3436.Length - 1; i++)
                {
                    f3436[f3436.Length - 1] = (byte)(f3436[f3436.Length - 1] + f3436[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f3436).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else if ((ba[3] == 0x27) && ((ba[4] == 0x01) || (ba[4] == 0x03) || (ba[4] == 0x05) || (ba[4] == 0x07) || (ba[4] == 0x09)))
            {
                f2701[2] = ba[1];
                f2701[1] = ba[2];
                f2701[3] = Convert.ToByte(ba[3] + 0x40);
                f2701[4] = ba[4];
                for (i = 0; i < f2701.Length - 1; i++)
                {
                    f2701[f2701.Length - 1] = (byte)(f2701[f2701.Length - 1] + f2701[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2701).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[3] == 0x27) && ((ba[4] == 0x02) || (ba[4] == 0x04) || (ba[4] == 0x06) || (ba[4] == 0x08) || (ba[4] == 0x0A)))
            {
                f2702[2] = ba[1];
                f2702[1] = ba[2];
                f2702[3] = Convert.ToByte(ba[3] + 0x40);
                f2702[4] = ba[4];
                for (i = 0; i < f2702.Length - 1; i++)
                {
                    f2702[f2702.Length - 1] = (byte)(f2702[f2702.Length - 1] + f2702[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2702).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else
            {
                general[2] = ba[1];
                general[1] = ba[2];
                ba[1] = general[1];
                ba[2] = general[2];
                ba[3] = Convert.ToByte(ba[3] + 0x40);
                for (i=0;i< ba.Length-1;i++)
                {
                    ba[ba.Length - 1] = (byte)(ba[ba.Length - 1] + ba[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n\r\n";
            }

            return sout;
        }//create kwp1 response frame for sim
        //=========================================================================================
        public string kwp2_response_lib(byte[] ba)
        {
            byte[] f21 = { 0x80, 0x00, 0x00, 0x3E, 0x61, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x00 };
            byte[] f22XX = { 0x80, 0x00, 0x00, 0x07, 0x62, 0x00, 0x00, 0x34, 0x35, 0x36, 0x37, 0x00 };
            byte[] f31 = { 0x80, 0x00, 0x00, 0x05, 0x71, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] f22F1 = { 0x80, 0x00, 0x00, 0x15, 0x62, 0xF1, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x00 };
            byte[] f2E3B = { 0x80, 0x00, 0x00, 0x03, 0x6E, 0x00, 0x00, 0x00 };
            byte[] f3436 = { 0x80, 0x00, 0x00, 0x02, 0x76, 0x00, 0x00 };
            byte[] f2701 = { 0x80, 0x00, 0x00, 0x06, 0x67, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] f2702 = { 0x80, 0x00, 0x00, 0x02, 0x67, 0x00, 0x00 };
            byte[] general = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00 };
            string sout = "";
            int a = 0, i = 0;
            //-----------------------------------
            sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
            if (ba[4] == 0x21)
            {
                f21[2] = ba[1];
                f21[1] = ba[2];
                f21[4] = Convert.ToByte(ba[4] + 0x40);
                f21[5] = ba[5];
                for (i = 0; i < f21.Length - 1; i++)
                {
                    f21[f21.Length - 1] = (byte)(f21[f21.Length - 1] + f21[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f21).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[4] == 0x22) && (ba[5] == 0xF1))
            {
                f22F1[2] = ba[1];
                f22F1[1] = ba[2];
                f22F1[4] = Convert.ToByte(ba[4] + 0x40);
                f22F1[5] = ba[5];
                for (i = 0; i < f22F1.Length - 1; i++)
                {
                    f22F1[f22F1.Length - 1] = (byte)(f22F1[f22F1.Length - 1] + f22F1[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if (ba[4] == 0x1A)
            {
                f22F1[2] = ba[1];
                f22F1[1] = ba[2];
                f22F1[4] = Convert.ToByte(ba[4] + 0x40);
                f22F1[5] = ba[5];
                for (i = 0; i < f22F1.Length - 1; i++)
                {
                    f22F1[f22F1.Length - 1] = (byte)(f22F1[f22F1.Length - 1] + f22F1[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if (ba[4] == 0x22)
            {
                f22XX[2] = ba[1];
                f22XX[1] = ba[2];
                f22XX[4] = Convert.ToByte(ba[4] + 0x40);
                f22XX[5] = ba[5];
                for (i = 0; i < f22XX.Length - 1; i++)
                {
                    f22XX[f22XX.Length - 1] = (byte)(f22XX[f22XX.Length - 1] + f22XX[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f22XX).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[4] == 0x2E) || (ba[4] == 0x3B))
            {
                f2E3B[2] = ba[1];
                f2E3B[1] = ba[2];
                f2E3B[4] = Convert.ToByte(ba[4] + 0x40);
                f2E3B[5] = ba[5];
                f2E3B[6] = ba[6];
                for (i = 0; i < f2E3B.Length - 1; i++)
                {
                    f2E3B[f2E3B.Length - 1] = (byte)(f2E3B[f2E3B.Length - 1] + f2E3B[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2E3B).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else if ((ba[4] == 0x34) || (ba[4] == 0x36))
            {
                f3436[2] = ba[1];
                f3436[1] = ba[2];
                f3436[4] = Convert.ToByte(ba[4] + 0x40);
                f3436[5] = ba[5];
                f3436[6] = ba[6];
                for (i = 0; i < f3436.Length - 1; i++)
                {
                    f3436[f3436.Length - 1] = (byte)(f3436[f3436.Length - 1] + f3436[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f3436).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else if ((ba[4] == 0x27) && ((ba[5] == 0x01) || (ba[5] == 0x03) || (ba[5] == 0x05) || (ba[5] == 0x07) || (ba[5] == 0x09)))
            {
                f2701[2] = ba[1];
                f2701[1] = ba[2];
                f2701[4] = Convert.ToByte(ba[4] + 0x40);
                f2701[5] = ba[5];
                for (i = 0; i < f2701.Length - 1; i++)
                {
                    f2701[f2701.Length - 1] = (byte)(f2701[f2701.Length - 1] + f2701[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2701).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[4] == 0x27) && ((ba[5] == 0x02) || (ba[5] == 0x04) || (ba[5] == 0x06) || (ba[5] == 0x08) || (ba[5] == 0x0A)))
            {
                f2702[2] = ba[1];
                f2702[1] = ba[2];
                f2702[4] = Convert.ToByte(ba[4] + 0x40);
                f2702[5] = ba[5];
                for (i = 0; i < f2702.Length - 1; i++)
                {
                    f2702[f2702.Length - 1] = (byte)(f2702[f2702.Length - 1] + f2702[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(f2702).Replace("-", ",") + "};\r\n";
                sout = sout + "X={5};\r\n\r\n";
            }
            else
            {
                general[2] = ba[1];
                general[1] = ba[2];
                ba[1] = general[1];
                ba[2] = general[2];
                ba[4] = Convert.ToByte(ba[4] + 0x40);
                for (i = 0; i < ba.Length - 1; i++)
                {
                    ba[ba.Length - 1] = (byte)(ba[ba.Length - 1] + ba[i]);
                }
                sout = sout + "R={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n\r\n";
            }

            return sout;
        }//create kwp1 response frame for sim
        //=========================================================================================
        public string can1_response_lib(byte[] ba)
        {
            byte[] f21 = { 0x00, 0x00, 0x61, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51 };
            byte[] f22XX = { 0x00, 0x00, 0x62, 0x00, 0x00, 0x34, 0x35, 0x36, 0x37, 0x38 };
            byte[] f31 = { 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] f22F1 = { 0x00, 0x00, 0x62, 0xF1, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x50 };
            byte[] f2E3B = { 0x00, 0x00, 0x6E, 0x00 };
            byte[] f3436 = { 0x00, 0x00, 0x76, 0x00 };
            byte[] f2701 = { 0x00, 0x00, 0x67, 0x00, 0x01, 0x02, 0x03, 0x04 };
            byte[] f2702 = { 0x00, 0x00, 0x67, 0x00 };
            byte[] general = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            string sout = "";
            int a = 0, i = 0;
            //-----------------------------------
            //sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
            if (ba[2] == 0x21)
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f21[0] = address[6];
                f21[1] = address[7];
                f21[2] = Convert.ToByte(ba[2] + 0x40);
                f21[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f21).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[2] == 0x22) && (ba[3] == 0xF1))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f22F1[0] = address[6];
                f22F1[1] = address[7];
                f22F1[2] = Convert.ToByte(ba[2] + 0x40);
                f22F1[3] = ba[3];
                f22F1[4] = ba[4];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if (ba[2] == 0x1A)
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f22F1[0] = address[6];
                f22F1[1] = address[7];
                f22F1[2] = Convert.ToByte(ba[2] + 0x40);
                f22F1[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f22F1).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[2] == 0x22))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f22XX[0] = address[6];
                f22XX[1] = address[7];
                f22XX[2] = Convert.ToByte(ba[2] + 0x40);
                f22XX[3] = ba[3];
                f22XX[4] = ba[4];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f22XX).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[2] == 0x2E) || (ba[2] == 0x3B))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f2E3B[0] = address[6];
                f2E3B[1] = address[7];
                f2E3B[2] = Convert.ToByte(ba[2] + 0x40);
                f2E3B[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f2E3B).Replace("-", ",") + "};\r\n";
                sout = sout + "X={4};\r\n\r\n";
            }
            else if ((ba[2] == 0x34) || (ba[2] == 0x36))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f3436[0] = address[6];
                f3436[1] = address[7];
                f3436[2] = Convert.ToByte(ba[2] + 0x40);
                f3436[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f3436).Replace("-", ",") + "};\r\n";
                sout = sout + "X={4};\r\n\r\n";
            }
            else if ((ba[2] == 0x27)&&((ba[3] == 0x01) || (ba[3] == 0x03) || (ba[3] == 0x05) || (ba[3] == 0x07) || (ba[3] == 0x09)))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f2701[0] = address[6];
                f2701[1] = address[7];
                f2701[2] = Convert.ToByte(ba[2] + 0x40);
                f2701[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f2701).Replace("-", ",") + "};\r\n\r\n";
            }
            else if ((ba[2] == 0x27) && ((ba[3] == 0x02) || (ba[3] == 0x04) || (ba[3] == 0x06) || (ba[3] == 0x08) || (ba[3] == 0x0A)))
            {
                ba[0] = address[2];
                ba[1] = address[3];
                f2702[0] = address[6];
                f2702[1] = address[7];
                f2702[2] = Convert.ToByte(ba[2] + 0x40);
                f2702[3] = ba[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                sout = sout + "R={" + BitConverter.ToString(f2702).Replace("-", ",") + "};\r\n";
                sout = sout + "X={4};\r\n\r\n";
            }
            else
            {
                ba[0] = address[2];
                ba[1] = address[3];
                sout = "C={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n";
                ba[0] = address[6];
                ba[1] = address[7];
                ba[2] = Convert.ToByte(ba[2] + 0x40);
                sout = sout + "R={" + BitConverter.ToString(ba).Replace("-", ",") + "};\r\n\r\n";
            }

            return sout;
        }
        //=========================================================================================
        public string sim_initial(byte[] ba)
        {
            string sout = "";
            //-----------------------------------
            if((ba[0] & 0x80) == 0x80)
            {
                sout = "I={1,7,10400,0,0};\r\n\r\n";
            }
            else
            {
                sout = "I={3,1,500000,0,0};\r\n\r\n";
            }
            return sout;
        }
        //=========================================================================================
        public bool frm_len(string txtbox)
        {
            string s2 = "";
            int len = 0;
            //-----------------------------------
            txtbox = txtbox.Replace("=", string.Empty);
            txtbox = txtbox.Replace("*", string.Empty);
            txtbox = txtbox.Replace(" ", string.Empty);
            txtbox = txtbox.Replace(",", string.Empty);
            txtbox = txtbox.Replace("0x", string.Empty);
            txtbox = txtbox.Replace("0X", string.Empty);
            txtbox = txtbox.Replace("\r\n", string.Empty);
            txtbox = txtbox.Replace("{", string.Empty);
            txtbox = txtbox.Replace("}", string.Empty);
            txtbox = txtbox.Replace("(", string.Empty);
            txtbox = txtbox.Replace(")", string.Empty);
            txtbox = txtbox.Replace(";", string.Empty);
            if ((txtbox.Length)%2 == 0)
            {
                len = txtbox.Length / 2;
                mt.converttextBox.Clear();
                s2 = "Dec Len = " + len.ToString() + "\r\n";
                mt.converttextBox.Text = s2 + "Hex Len = " + len.ToString("X2");
                lable_message("Calculate Frame Len Success", Color.GreenYellow);
                return true;
            }
            else
            {
                lable_message("Input Data Invalid", Color.Red);
                return false;
            }
        }
        //=========================================================================================
        public string loadfile()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Browse bin Files";
            openfile.Filter = "(*.log)|*.log|(*.dat)|*.dat|All files (*.*)|*.*";
            openfile.InitialDirectory = "@" + path;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                path = openfile.FileName.ToString();
            }
            else
                return null;
            return path;
        }
        //=========================================================================================
    }
}
