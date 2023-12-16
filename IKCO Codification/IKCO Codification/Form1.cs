using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace IKCO_Codification
{
    public partial class Form1 : Form
    {
        string s1 = null;
        int i1 = 0,sheet = 0;
        string[,] odistable = new string[32, 61];
        string str,filepath=null,readexcel=null,finalresult;
        string lastpathload= @"C:\";
        byte[] codifbyte = { 0 };
        Excel.Application xlApp;
        Excel.Workbook xlBook;
        Excel.Worksheet xlSheet;
        Excel.Worksheet xlSheet1;
        
        
        //=========================================================================================
        public Form1()
        {
            InitializeComponent();
        }
        //=========================================================================================
        public void load_form(object sender, EventArgs e)
        {
            xlApp = new Excel.Application();
        }
        //=========================================================================================
        private void configcode_Click(object sender, EventArgs e)
        {
            showresult.BackColor = Color.Yellow;
            showresult.Text = "Loading...";
            finalresult = null;
            filepath = null;
            textBox1.Clear();
            filepath = loadexcelfile();
            if (filepath == null)
            {
                if (codiftextBox.Text != string.Empty)
                {
                    showresult.BackColor = Color.LimeGreen;
                    showresult.Text = "result";
                }
                else
                {
                    showresult.BackColor = Color.Red;
                    showresult.Text = "Invalid Codification!";
                }
                return;
            }
            xlBook = xlApp.Workbooks.Open(filepath);
            codificationtobyte();
                
            if (codifbyte.Length==30)
            {
                sheet = 1;
                finalresult = finalresult + "===================================================" + "///ODIS(1)(" + codiftextBox.Text.Substring(0,1) + ")\r\n";
                char_1(0);//code type
                finalresult = finalresult + "===================================================" + "///ODIS(2)(" + codiftextBox.Text.Substring(1, 1) + ")\r\n";
                char_2(1);//vehicle type
                finalresult = finalresult + "===================================================" + "///ODIS(3)(" + codiftextBox.Text.Substring(2, 1) + ")\r\n";
                char_3(2);//ems type
                finalresult = finalresult + "===================================================" + "///ODIS(4)(" + codiftextBox.Text.Substring(3, 1) + ")\r\n";
                char_4(3);//cluster(icn)
                finalresult = finalresult + "===================================================" + "///ODIS(5)(" + codiftextBox.Text.Substring(4, 1) + ")\r\n";
                char_5(4);//abs
                finalresult = finalresult + "===================================================" + "///ODIS(6)(" + codiftextBox.Text.Substring(5, 1) + ")\r\n";
                char_6(5);//gearbox
                finalresult = finalresult + "===================================================" + "///ODIS(7)(" + codiftextBox.Text.Substring(6, 1) + ")\r\n";
                char_7(6);//tyre
                finalresult = finalresult + "===================================================" + "///ODIS(8)(" + codiftextBox.Text.Substring(7, 1) + ")\r\n";
                char_8(7);//option_1
                finalresult = finalresult + "===================================================" + "///ODIS(9)(" + codiftextBox.Text.Substring(8, 1) + ")\r\n";
                finalresult = finalresult + "===================================================" + "///ODIS(10)(" + codiftextBox.Text.Substring(9, 1) + ")\r\n";
                char_10(9);//airbag config
                finalresult = finalresult + "===================================================" + "///ODIS(11)(" + codiftextBox.Text.Substring(10, 1) + ")\r\n";
                char_11(10);//option_2
                finalresult = finalresult + "===================================================" + "///ODIS(12)(" + codiftextBox.Text.Substring(11, 1) + ")\r\n";
                char_12(11);//option_3
                finalresult = finalresult + "===================================================" + "///ODIS(13)(" + codiftextBox.Text.Substring(12, 1) + ")\r\n";
                char_13(12);//radio
                finalresult = finalresult + "===================================================" + "///ODIS(14)(" + codiftextBox.Text.Substring(13, 1) + ")\r\n";
                char_14(13);//fuel type
                finalresult = finalresult + "===================================================" + "///ODIS(15)(" + codiftextBox.Text.Substring(14, 1) + ")\r\n";
                char_15(14);//option_4
                finalresult = finalresult + "===================================================" + "///ODIS(16)(" + codiftextBox.Text.Substring(15, 1) + ")\r\n";
                char_16(15);//calender type
                finalresult = finalresult + "===================================================" + "///ODIS(17)(" + codiftextBox.Text.Substring(16, 1) + ")\r\n";
                char_17(16);//ee protocol
                finalresult = finalresult + "===================================================" + "///ODIS(18)(" + codiftextBox.Text.Substring(17, 1) + ")\r\n";
                char_18(17);//option_5
                finalresult = finalresult + "===================================================" + "///ODIS(19)(" + codiftextBox.Text.Substring(18, 1) + ")\r\n";
                char_19(18);//airbag type
                finalresult = finalresult + "===================================================" + "///ODIS(20)(" + codiftextBox.Text.Substring(19, 1) + ")\r\n";
                char_20(19);//option_6
                finalresult = finalresult + "===================================================" + "///ODIS(21)(" + codiftextBox.Text.Substring(20, 1) + ")\r\n";
                char_21(20);//immobilizer
                finalresult = finalresult + "===================================================" + "///ODIS(22)(" + codiftextBox.Text.Substring(21, 1) + ")\r\n";
                char_22(21);//fn(front node)
                finalresult = finalresult + "===================================================" + "///ODIS(23)(" + codiftextBox.Text.Substring(22, 1) + ")\r\n";
                char_23(22);//dn(door node)
                finalresult = finalresult + "===================================================" + "///ODIS(24)(" + codiftextBox.Text.Substring(23, 1) + ")\r\n";
                char_24(23);//ccn node
                finalresult = finalresult + "===================================================" + "///ODIS(25)(" + codiftextBox.Text.Substring(24, 1) + ")\r\n";
                char_25(24);//mfd
                finalresult = finalresult + "===================================================" + "///ODIS(26)(" + codiftextBox.Text.Substring(25, 1) + ")\r\n";
                char_26(25);//option_8
                finalresult = finalresult + "===================================================" + "///ODIS(27)(" + codiftextBox.Text.Substring(26, 1) + ")\r\n";
                char_27(26);//option_7
                finalresult = finalresult + "===================================================" + "///ODIS(28)(" + codiftextBox.Text.Substring(27, 1) + ")\r\n";
                char_28(27);//antithef
                finalresult = finalresult + "===================================================" + "///ODIS(29)(" + codiftextBox.Text.Substring(28, 1) + ")\r\n";
                char_29(28);//eps
                finalresult = finalresult + "===================================================" + "///ODIS(30)(" + codiftextBox.Text.Substring(29, 1) + ")\r\n";
                char_30(29);//tpms
                textBox1.Text = finalresult;
                showresult.BackColor = Color.GreenYellow;
                showresult.Text = "Load File Complete.";
            }
            else
            {
                //MessageBox.Show("Invalid Codification!");
                showresult.BackColor = Color.Red;
                showresult.Text = "Invalid Odise Codification!";
            }
            xlBook.Close();
            xlApp.Quit();
        }
        //=========================================================================================
        private void diagnosticcode_Click(object sender, EventArgs e)
        {
            showresult.BackColor = Color.Yellow;
            showresult.Text = "Loading...";
            finalresult = null;
            filepath = null;
            textBox1.Clear();
            filepath = loadexcelfile();
            if (filepath == null)
            {
                if (codiftextBox.Text != string.Empty)
                {
                    showresult.BackColor = Color.LimeGreen;
                    showresult.Text = "result";
                }
                else
                {
                    showresult.BackColor = Color.Red;
                    showresult.Text = "Invalid Codification!";
                }
                return;
            }
            xlBook = xlApp.Workbooks.Open(filepath);
            codificationtobyte();
            if (codifbyte.Length == 27)
            {
                sheet = 2;
                finalresult = finalresult + "===================================================" + "///CONTIV(1)(" + codiftextBox.Text.Substring(0, 1) + ")\r\n";
                char_1(0);//code type
                finalresult = finalresult + "===================================================" + "///CONTIV(2)(" + codiftextBox.Text.Substring(1, 1) + ")\r\n";
                char_2(1);//vehicle type
                finalresult = finalresult + "===================================================" + "///CONTIV(3)(" + codiftextBox.Text.Substring(2, 1) + ")\r\n";
                contivchar_3(2);//ems type
                finalresult = finalresult + "===================================================" + "///CONTIV(4)(" + codiftextBox.Text.Substring(3, 1) + ")\r\n";
                contivchar_4(3);//injection ecu
                finalresult = finalresult + "===================================================" + "///CONTIV(5)(" + codiftextBox.Text.Substring(4, 1) + ")\r\n";
                char_5(4);//abs
                finalresult = finalresult + "===================================================" + "///CONTIV(6)(" + codiftextBox.Text.Substring(5, 1) + ")\r\n";
                char_6(5);//gearbox
                finalresult = finalresult + "===================================================" + "///CONTIV(7)(" + codiftextBox.Text.Substring(6, 1) + ")\r\n";
                char_4(6);//cluster(icn)
                finalresult = finalresult + "===================================================" + "///CONTIV(8)(" + codiftextBox.Text.Substring(7, 1) + ")\r\n";
                finalresult = finalresult + "===================================================" + "///CONTIV(9)(" + codiftextBox.Text.Substring(8, 1) + ")\r\n";
                contivchar_5(8);//option_1
                finalresult = finalresult + "===================================================" + "///CONTIV(10)(" + codiftextBox.Text.Substring(9, 1) + ")\r\n";
                char_10(9);//airbag config
                finalresult = finalresult + "===================================================" + "///CONTIV(11)(" + codiftextBox.Text.Substring(10, 1) + ")\r\n";
                char_14(10);//fuel type
                finalresult = finalresult + "===================================================" + "///CONTIV(12)(" + codiftextBox.Text.Substring(11, 1) + ")\r\n";
                contivchar_6(11);//mux type
                finalresult = finalresult + "===================================================" + "///CONTIV(13)(" + codiftextBox.Text.Substring(12, 1) + ")\r\n";
                char_13(12);//radio
                finalresult = finalresult + "===================================================" + "///CONTIV(14)(" + codiftextBox.Text.Substring(13, 1) + ")\r\n";
                contivchar_7(13);//option_2
                finalresult = finalresult + "===================================================" + "///CONTIV(15)(" + codiftextBox.Text.Substring(14, 1) + ")\r\n";
                contivchar_8(14);//a/c type(hvac)
                finalresult = finalresult + "===================================================" + "///CONTIV(16)(" + codiftextBox.Text.Substring(15, 1) + ")\r\n";
                char_19(15);//airbag type
                finalresult = finalresult + "===================================================" + "///CONTIV(17)(" + codiftextBox.Text.Substring(16, 1) + ")\r\n";
                contivchar_9(16);//option_3
                finalresult = finalresult + "===================================================" + "///CONTIV(18)(" + codiftextBox.Text.Substring(17, 1) + ")\r\n";
                char_8(17);//option_4
                finalresult = finalresult + "===================================================" + "///CONTIV(19)(" + codiftextBox.Text.Substring(18, 1) + ")\r\n";
                char_29(18);//eps
                finalresult = finalresult + "===================================================" + "///CONTIV(20)(" + codiftextBox.Text.Substring(19, 1) + ")\r\n";
                contivchar_11(19);//electrical windows
                finalresult = finalresult + "===================================================" + "///CONTIV(21)(" + codiftextBox.Text.Substring(20, 1) + ")\r\n";
                contivchar_10(20);//option_5
                finalresult = finalresult + "===================================================" + "///CONTIV(22)(" + codiftextBox.Text.Substring(21, 1) + ")\r\n";
                char_21(21);//immobilizer/peps
                finalresult = finalresult + "===================================================" + "///CONTIV(23)(" + codiftextBox.Text.Substring(22, 1) + ")\r\n";
                char_22(22);//fn(front node)
                finalresult = finalresult + "===================================================" + "///CONTIV(24)(" + codiftextBox.Text.Substring(23, 1) + ")\r\n";
                char_23(23);//doors
                finalresult = finalresult + "===================================================" + "///CONTIV(25)(" + codiftextBox.Text.Substring(24, 1) + ")\r\n";
                char_24(24);//ccn node
                finalresult = finalresult + "===================================================" + "///CONTIV(26)(" + codiftextBox.Text.Substring(25, 1) + ")\r\n";
                char_25(25);//mfd
                finalresult = finalresult + "===================================================" + "///CONTIV(27)(" + codiftextBox.Text.Substring(26, 1) + ")\r\n";
                char_26(26);//option_6
                textBox1.Text = finalresult;
                showresult.BackColor = Color.GreenYellow;
                showresult.Text = "Load File Complete.";
            }
            else
            {
                //MessageBox.Show("Invalid Codification!");
                showresult.BackColor = Color.Red;
                showresult.Text = "Invalid Contiv Codification!";
            }
            xlBook.Close();
            xlApp.Quit();
        }
        //=========================================================================================
        public string loadexcelfile()
        {
            if (codiftextBox.Text != string.Empty)
            {
                OpenFileDialog openexcel = new OpenFileDialog();
                openexcel.Title = "Browse Excel Files";
                openexcel.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openexcel.InitialDirectory = "@" + lastpathload;
                if (openexcel.ShowDialog() == DialogResult.OK)
                {
                    lastpathload = openexcel.FileName.ToString();
                }
                else
                    return null;
            }
            else
            {
                showresult.BackColor = Color.Red;
                showresult.Text = "Invalid Codification!";
                return null;
            }
            return lastpathload;
        }
        //=========================================================================================
        public string readcell(int x,int y,int sheet,string path)
        {
            str = "";
            
            //xlApp.Visible = true;
            xlSheet = xlBook.Sheets[sheet];
            //xlSheet = xlBook.ActiveSheet;
            if (xlSheet.UsedRange.Cells[x, y].Value != null)
            {
                str = xlSheet.UsedRange.Cells[x, y].Value.ToString();
            }
            else
            {
                //showresult.BackColor = Color.GreenYellow;
                //showresult.Text = "cell is null!";
            }
            return str;
        }
        //=========================================================================================
        public void codificationtobyte()
        {
            s1=null;
            codifbyte = null;
            
            s1 = codiftextBox.Text;
            codifbyte = ASCIIEncoding.Default.GetBytes(s1);
        }
        //=========================================================================================
        public void char_1(int codeindex)//code type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if(i1 !=200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Code Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Vehicle Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Code Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_2(int codeindex)//vehicle type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Vehicle Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Vehicle Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Vehicle Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_3(int codeindex)//ems type
        {
            int i2 = 0;
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                //s1 = readcell(i1, 10, sheet, filepath);
                i2 = codifbyte[8] - 0x30;
                s1 = readcell(i1 + i2, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "EMS Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "EMS Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "EMS Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_4(int codeindex)//cluster(icn)
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "ICN: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "ICN: Invalid\r\n";
            }
            else
                finalresult = finalresult + "ICN: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_5(int codeindex)//esc/abs
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "ESC/ABS: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "ESC/ABS: Invalid\r\n";
            }
            else
                finalresult = finalresult + "ESC/ABS: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_6(int codeindex)//gearbox
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "GearBox: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "GearBox: Invalid\r\n";
            }
            else
                finalresult = finalresult + "GearBox: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_7(int codeindex)//tyre size
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Tyre Size: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Tyre Size: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Tyre Size: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_8(int codeindex)//option_1
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Absent\r\nClock: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Absent\r\nClock: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Present\r\nClock: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Present\r\nClock: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Absent\r\nClock: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Absent\r\nClock: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Present\r\nClock: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nFront Fog Lamp: Absent\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Present\r\nClock: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Absent\r\nClock: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Absent\r\nClock: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Present\r\nClock: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Absent\r\nRear Fog Lamp(Right): Present\r\nClock: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Absent\r\nClock: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Absent\r\nClock: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Present\r\nClock: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nFront Fog Lamp: Present\r\nRear Fog Lamp(Left): Present\r\nRear Fog Lamp(Right): Present\r\nClock: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                if(codeindex==17)
                    finalresult = finalresult + "Option_4: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Option_1: " + s1 + "\r\n";
            }
            else
            {
                if (codeindex == 17)
                    finalresult = finalresult + "Option_4: Invalid\r\n";
                else
                    finalresult = finalresult + "Option_1: Invalid\r\n";
            }
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_9(int codeindex)//ems type
        {

        }
        //=========================================================================================
        public void char_10(int codeindex)//airbag config
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Airbag Config: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Airbag Config: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Airbag Config: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_11(int codeindex)//option_2
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Present\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Present\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Present\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nMulti Media: Absent\r\nRear Day Light(Position Lamp): Present\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Absent\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Present\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Present\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Present\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nMulti Media: Present\r\nRear Day Light(Position Lamp): Present\r\nReserve: Present\r\nReserve: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_2: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_2: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_12(int codeindex)//option_3
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Simple\r\nFolding Mirror: Absent\r\nOutside Temp: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Simple\r\nFolding Mirror: Absent\r\nOutside Temp: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Simple\r\nFolding Mirror: Present\r\nOutside Temp: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Simple\r\nFolding Mirror: Present\r\nOutside Temp: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Auto\r\nFolding Mirror: Absent\r\nOutside Temp: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Auto\r\nFolding Mirror: Absent\r\nOutside Temp: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Auto\r\nFolding Mirror: Present\r\nOutside Temp: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nDay Light(DRL): Absent\r\nHVAC Type: Auto\r\nFolding Mirror: Present\r\nOutside Temp: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Simple\r\nFolding Mirror: Absent\r\nOutside Temp: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Simple\r\nFolding Mirror: Absent\r\nOutside Temp: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Simple\r\nFolding Mirror: Present\r\nOutside Temp: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Simple\r\nFolding Mirror: Present\r\nOutside Temp: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Auto\r\nFolding Mirror: Absent\r\nOutside Temp: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Auto\r\nFolding Mirror: Absent\r\nOutside Temp: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Auto\r\nFolding Mirror: Present\r\nOutside Temp: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nDay Light(DRL): Present\r\nHVAC Type: Auto\r\nFolding Mirror: Present\r\nOutside Temp: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_3: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_3: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_13(int codeindex)//radio
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Radio: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Radio: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Radio: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_14(int codeindex)//fuel type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Fuel Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Fuel Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Fuel Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_15(int codeindex)//option_4
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x31://1
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Active";
                        break;
                    case 0x32://2
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x33://3
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Active";
                        break;
                    case 0x34://4
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x35://5
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Active";
                        break;
                    case 0x36://6
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x37://7
                        s1 = "\r\nSpeed Locking: Non Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Active";
                        break;
                    case 0x38://8
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x39://9
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Active";
                        break;
                    case 0x41://A
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x42://B
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Non Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Active";
                        break;
                    case 0x43://C
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x44://D
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Non Active\r\nShock Sensor: Active";
                        break;
                    case 0x45://E
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Non Active";
                        break;
                    case 0x46://F
                        s1 = "\r\nSpeed Locking: Active\r\nLeft Reverse Lamp: Active\r\nRight Reverse Lamp: Active\r\nShock Sensor: Active";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_4: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_4: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_16(int codeindex)//calender type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Calender Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Calender Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Calender Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_17(int codeindex)//HVAC Type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "HVAC Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "HVAC Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "HVAC Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_18(int codeindex)//option_5
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: Standard\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x31://1
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: Standard\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x32://2
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: Standard\r\nSide Lamp Rear: LED";
                        break;
                    case 0x33://3
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: Standard\r\nSide Lamp Rear: LED";
                        break;
                    case 0x34://4
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: LED\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x35://5
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: LED\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x36://6
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: LED\r\nSide Lamp Rear: LED";
                        break;
                    case 0x37://7
                        s1 = "\r\nGSI: Not Active\r\nSide Lamp Front: Standard\r\nStop Lamp: LED\r\nSide Lamp Rear: LED";
                        break;
                    case 0x38://8
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: Standard\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x39://9
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: Standard\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x41://A
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: Standard\r\nSide Lamp Rear: LED";
                        break;
                    case 0x42://B
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: Standard\r\nSide Lamp Rear: LED";
                        break;
                    case 0x43://C
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: LED\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x44://D
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: LED\r\nSide Lamp Rear: Standard";
                        break;
                    case 0x45://E
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: LED\r\nSide Lamp Rear: LED";
                        break;
                    case 0x46://F
                        s1 = "\r\nGSI: Active\r\nSide Lamp Front: LED\r\nStop Lamp: LED\r\nSide Lamp Rear: LED";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_5: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_5: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_19(int codeindex)//airbag type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Airbag Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Airbag Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Airbag Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_20(int codeindex)//option_6
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Absent\r\nReverse Sensor: Absent\r\nAnti Trap: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Absent\r\nReverse Sensor: Absent\r\nAnti Trap: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Absent\r\nReverse Sensor: Present\r\nAnti Trap: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Absent\r\nReverse Sensor: Present\r\nAnti Trap: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Present\r\nReverse Sensor: Absent\r\nAnti Trap: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Present\r\nReverse Sensor: Absent\r\nAnti Trap: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Present\r\nReverse Sensor: Present\r\nAnti Trap: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nSun Roof: Absent\r\nCrouse Control: Present\r\nReverse Sensor: Present\r\nAnti Trap: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Absent\r\nReverse Sensor: Absent\r\nAnti Trap: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Absent\r\nReverse Sensor: Absent\r\nAnti Trap: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Absent\r\nReverse Sensor: Present\r\nAnti Trap: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Absent\r\nReverse Sensor: Present\r\nAnti Trap: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Present\r\nReverse Sensor: Absent\r\nAnti Trap: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Present\r\nReverse Sensor: Absent\r\nAnti Trap: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Present\r\nReverse Sensor: Present\r\nAnti Trap: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nSun Roof: Present\r\nCrouse Control: Present\r\nReverse Sensor: Present\r\nAnti Trap: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_6: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_6: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_21(int codeindex)//immobilizer/PEPS
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Immobilizer/PEPS: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Immobilizer/PEPS: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Immobilizer/PEPS: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_22(int codeindex)//fn(front node)
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "FN(Front Node): " + s1 + "\r\n";
                else
                    finalresult = finalresult + "FN(Front Node): Invalid\r\n";
            }
            else
                finalresult = finalresult + "FN(Front Node): Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_23(int codeindex)//door node
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Door Node: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Door Node: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Door Node: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_24(int codeindex)//ccn node
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "CCN Node: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "CCN Node: Invalid\r\n";
            }
            else
                finalresult = finalresult + "CCN Node: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_25(int codeindex)//mfd
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "MFD: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "MFD: Invalid\r\n";
            }
            else
                finalresult = finalresult + "MFD: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_26(int codeindex)//option_8
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nSAS: Absent\r\nReserve: Absent\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nSAS: Absent\r\nReserve: Absent\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nSAS: Absent\r\nReserve: Absent\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nSAS: Absent\r\nReserve: Absent\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nSAS: Absent\r\nReserve: Present\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nSAS: Absent\r\nReserve: Present\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nSAS: Absent\r\nReserve: Present\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nSAS: Absent\r\nReserve: Present\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nSAS: Present\r\nReserve: Absent\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nSAS: Present\r\nReserve: Absent\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nSAS: Present\r\nReserve: Absent\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nSAS: Present\r\nReserve: Absent\r\nReserve: Present\r\nReserve: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nSAS: Present\r\nReserve: Present\r\nReserve: Absent\r\nReserve: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nSAS: Present\r\nReserve: Present\r\nReserve: Absent\r\nReserve: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nSAS: Present\r\nReserve: Present\r\nReserve: Present\r\nReserve: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nSAS: Present\r\nReserve: Present\r\nReserve: Present\r\nReserve: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_8: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_8: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_27(int codeindex)//Option_7
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Absent\r\nRain Sensor: Absent\r\nLight Sensor: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Absent\r\nRain Sensor: Absent\r\nLight Sensor: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Absent\r\nRain Sensor: Present\r\nLight Sensor: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Absent\r\nRain Sensor: Present\r\nLight Sensor: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Present\r\nRain Sensor: Absent\r\nLight Sensor: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Present\r\nRain Sensor: Absent\r\nLight Sensor: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Present\r\nRain Sensor: Present\r\nLight Sensor: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nVacum Pump: Absent\r\nEPS: Present\r\nRain Sensor: Present\r\nLight Sensor: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Absent\r\nRain Sensor: Absent\r\nLight Sensor: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Absent\r\nRain Sensor: Absent\r\nLight Sensor: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Absent\r\nRain Sensor: Present\r\nLight Sensor: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Absent\r\nRain Sensor: Present\r\nLight Sensor: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Present\r\nRain Sensor: Absent\r\nLight Sensor: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Present\r\nRain Sensor: Absent\r\nLight Sensor: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Present\r\nRain Sensor: Present\r\nLight Sensor: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nVacum Pump: Present\r\nEPS: Present\r\nRain Sensor: Present\r\nLight Sensor: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_7: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_7: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_28(int codeindex)//antithef
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Antithef: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Antithef: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Antithef: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_29(int codeindex)//eps
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex+2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "EPS: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "EPS: Invalid\r\n";
            }
            else
                finalresult = finalresult + "EPS: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void char_30(int codeindex)//tpms type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "TPMS Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "TPMS Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "TPMS Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public int rownum(byte b1)
        {
            int row = 0;

            switch (b1)
            {
                case 0x30://0
                    row = 4;
                    break;
                case 0x31://1
                    row = 5;
                    break;
                case 0x32://2
                    row = 6;
                    break;
                case 0x33://3
                    row = 7;
                    break;
                case 0x34://4
                    row = 8;
                    break;
                case 0x35://5
                    row = 9;
                    break;
                case 0x36://6
                    row = 10;
                    break;
                case 0x37://7
                    row = 11;
                    break;
                case 0x38://8
                    row = 12;
                    break;
                case 0x39://9
                    row = 13;
                    break;
                case 0x41://A
                    row = 14;
                    break;
                case 0x42://B
                    row = 24;
                    break;
                case 0x43://C
                    row = 34;
                    break;
                case 0x44://D
                    row = 38;
                    break;
                case 0x45://E
                    row = 39;
                    break;
                case 0x46://F
                    row = 40;
                    break;
                case 0x47://G
                    row = 41;
                    break;
                case 0x48://H
                    row = 42;
                    break;
                case 0x49://I
                    row = 43;
                    break;
                case 0x4A://J
                    row = 44;
                    break;
                case 0x4B://K
                    row = 45;
                    break;
                case 0x4C://L
                    row = 46;
                    break;
                case 0x4D://M
                    row = 47;
                    break;
                case 0x4E://N
                    row = 48;
                    break;
                case 0x4F://O
                    row = 49;
                    break;
                case 0x50://P
                    row = 50;
                    break;
                case 0x51://Q
                    row = 51;
                    break;
                case 0x52://R
                    row = 52;
                    break;
                case 0x53://S
                    row = 53;
                    break;
                case 0x54://T
                    row = 54;
                    break;
                case 0x55://U
                    row = 55;
                    break;
                case 0x56://V
                    row = 56;
                    break;
                case 0x57://W
                    row = 57;
                    break;
                case 0x58://X
                    row = 58;
                    break;
                case 0x59://Y
                    row = 59;
                    break;
                case 0x5A://Z
                    row = 60;
                    break;
                default:
                    row = 200;
                    break;
            }
            return row;
        }
        //=========================================================================================
        public void contivchar_3(int codeindex)//ems type
        {
            int i2 = 0;
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                //s1 = readcell(i1, 10, sheet, filepath);
                i2 = codifbyte[7] - 0x30;
                s1 = readcell(i1 + i2, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "EMS Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "EMS Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "EMS Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_4(int codeindex)//injection ecu
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(4, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Injection ECU: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Injection ECU: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Injection ECU: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_5(int codeindex)//option_1
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Present\r\nDoors Lamp: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Present\r\nDoors Lamp: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Present\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Present\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Present\r\nElectrical Mirrors: Present\r\nDoors Lamp: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nCrouse Control: Absent\r\nElectrical Seat: Present\r\nElectrical Mirrors: Present\r\nDoors Lamp: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Present\r\nDoors Lamp: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Absent\r\nElectrical Mirrors: Present\r\nDoors Lamp: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Present\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Present\r\nElectrical Mirrors: Absent\r\nDoors Lamp: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Present\r\nElectrical Mirrors: Present\r\nDoors Lamp: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nCrouse Control: Present\r\nElectrical Seat: Present\r\nElectrical Mirrors: Present\r\nDoors Lamp: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_1: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_1: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_6(int codeindex)//mux type
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "MUX Type: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "MUX Type: Invalid\r\n";
            }
            else
                finalresult = finalresult + "MUX Type: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_7(int codeindex)//option_2
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Present\r\nShock Sensor: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Present\r\nShock Sensor: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Present\r\nShock Sensor: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nSpeed Locking: Absent\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Present\r\nShock Sensor: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Present\r\nShock Sensor: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Absent\r\nRight Reverse Lamp: Present\r\nShock Sensor: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Absent\r\nShock Sensor: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Present\r\nShock Sensor: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nSpeed Locking: Present\r\nLeft Reverse Lamp: Present\r\nRight Reverse Lamp: Present\r\nShock Sensor: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_2: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_2: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_8(int codeindex)//a/c type(hvac)
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "A/C Type(HVAC): " + s1 + "\r\n";
                else
                    finalresult = finalresult + "A/C Type(HVAC): Invalid\r\n";
            }
            else
                finalresult = finalresult + "A/C Type(HVAC): Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_9(int codeindex)//option_3
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Absent\r\nSunroof: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Absent\r\nSunroof: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Present\r\nSunroof: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Present\r\nSunroof: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Absent\r\nSunroof: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Absent\r\nSunroof: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Present\r\nSunroof: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nTPMS: Absent\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Present\r\nSunroof: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Absent\r\nSunroof: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Absent\r\nSunroof: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Present\r\nSunroof: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Absent\r\nReverse Gear Sensor: Present\r\nSunroof: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Absent\r\nSunroof: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Absent\r\nSunroof: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Present\r\nSunroof: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nTPMS: Present\r\nDirection On Mirrors: Present\r\nReverse Gear Sensor: Present\r\nSunroof: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_3: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_3: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_10(int codeindex)//option_5
        {
            s1 = null;

            if (codifbyte[codeindex] <= 0x46)
            {
                switch (codifbyte[codeindex])
                {
                    case 0x30://0
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Absent\r\nFolding Mirrors: Absent\r\nHooshmand: Absent";
                        break;
                    case 0x31://1
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Absent\r\nFolding Mirrors: Absent\r\nHooshmand: Present";
                        break;
                    case 0x32://2
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Absent\r\nFolding Mirrors: Present\r\nHooshmand: Absent";
                        break;
                    case 0x33://3
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Absent\r\nFolding Mirrors: Present\r\nHooshmand: Present";
                        break;
                    case 0x34://4
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Present\r\nFolding Mirrors: Absent\r\nHooshmand: Absent";
                        break;
                    case 0x35://5
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Present\r\nFolding Mirrors: Absent\r\nHooshmand: Present";
                        break;
                    case 0x36://6
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Present\r\nFolding Mirrors: Present\r\nHooshmand: Absent";
                        break;
                    case 0x37://7
                        s1 = "\r\nReserve: Absent\r\nVacum Pump: Present\r\nFolding Mirrors: Present\r\nHooshmand: Present";
                        break;
                    case 0x38://8
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Absent\r\nFolding Mirrors: Absent\r\nHooshmand: Absent";
                        break;
                    case 0x39://9
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Absent\r\nFolding Mirrors: Absent\r\nHooshmand: Present";
                        break;
                    case 0x41://A
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Absent\r\nFolding Mirrors: Present\r\nHooshmand: Absent";
                        break;
                    case 0x42://B
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Absent\r\nFolding Mirrors: Present\r\nHooshmand: Present";
                        break;
                    case 0x43://C
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Present\r\nFolding Mirrors: Absent\r\nHooshmand: Absent";
                        break;
                    case 0x44://D
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Present\r\nFolding Mirrors: Absent\r\nHooshmand: Present";
                        break;
                    case 0x45://E
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Present\r\nFolding Mirrors: Present\r\nHooshmand: Absent";
                        break;
                    case 0x46://F
                        s1 = "\r\nReserve: Present\r\nVacum Pump: Present\r\nFolding Mirrors: Present\r\nHooshmand: Present";
                        break;
                    default:
                        s1 = "Invalid";
                        break;
                }
                finalresult = finalresult + "Option_5: " + s1 + "\r\n";
            }
            else
                finalresult = finalresult + "Option_5: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
        public void contivchar_11(int codeindex)//electrical windows
        {
            s1 = null;
            i1 = 0;

            i1 = rownum(codifbyte[codeindex]);
            if (i1 != 200)
            {
                s1 = readcell(i1, codeindex + 2, sheet, filepath);
                if ((s1 != null) && (s1 != string.Empty))
                    finalresult = finalresult + "Electrical Windows: " + s1 + "\r\n";
                else
                    finalresult = finalresult + "Electrical Windows: Invalid\r\n";
            }
            else
                finalresult = finalresult + "Electrical Windows: Invalid\r\n";
            showresult.BackColor = Color.Yellow;
            showresult.Text = s1;
        }
        //=========================================================================================
    }
}
