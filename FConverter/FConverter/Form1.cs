using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FConverter
{
    public partial class Form1 : Form
    {
        //byte[] frame = { 0x36,0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x6A, 0xA6, 0xE6, 0xF4, 0x75, 0x60, 0x71, 0xC9, 0x00, 0x13, 0x00, 0x26, 0x09, 0x23, 0xFF, 0xFF, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B };//1E7E
        //byte[] frame1 = { 0x36, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x6A, 0x29, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x09, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x69, 0x6D, 0x0B, 0x06, 0x69, 0x3E, 0x0B, 0x06, 0x69, 0x9C, 0x0B, 0x06, 0x69, 0xCB, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x68, 0xB1, 0x0B, 0x06, 0x68, 0x82, 0x0B, 0x06, 0x68, 0xE0, 0x0B, 0x06, 0x69, 0x0F, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x69, 0xFA, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B, 0x06, 0x70, 0x08, 0x0B };
        //byte[] frame = { 0x36, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };//4DD4
        string[] linetype = new string[20000];
        Int32[] linelen = new Int32[20000];
        ulong[] datalen = new ulong[30000];
        ulong[] lineaddress = new ulong[20000];
        byte[,] linedata = new byte[20000, 50];
        string global_filepath;
        ulong[] difflen = new ulong[20000];
        ulong[] startindex = new ulong[10];
        UInt32 lastlineaddres = 0;
        ulong linecnt = 0;
        int lastlinelen = 0;
        string globalterminal = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(file_path());
            //MessageBox.Show(calccrc16(0xE0, frame).ToString("X2"));
            //MessageBox.Show(calccrc32(0xE0, frame).ToString("X2"));
            //MessageBox.Show(nccitt(frame).ToString("X2"));//this is true
            lblshowresult.BackColor = Color.Yellow;
            lblshowresult.Text = "Show result";
            clear_allvalue();
            string N = file_path("S19|*.s19|S28|*.s28");
            if (N != null && N != string.Empty)
            {
                load_file(N);
                creat_newbinfile();
                new_write_data2bin();
                write_txt_file();
                downtxt_file();
                //create_FFbin();
                //write_data_2bin();
                //read_bin_file();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "Success";
            }
            else
            {
                lblshowresult.BackColor = Color.Yellow;
                lblshowresult.Text = "Show result";
            }

        }
        //=================================================================
        
        //=================================================================
        private void btnterminal_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            globalterminal = null;
        }
        //=================================================================
        byte load_file(string S1)
        {
            string type = null;
            string s19line = null;
            byte[] lineb;

            FileStream s19file = new FileStream(S1, FileMode.Open, FileAccess.Read);
            StreamReader s19string = new StreamReader(s19file);
            while ((s19line = s19string.ReadLine()) != null)
            {
                //MessageBox.Show(s19line);
                type = s19line.Substring(0, 2);
                /*if (type == "S0")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = ulong.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = linelen[linecnt];
                    lineaddress[linecnt] = 0;
                    lineb = strfrm2bytearray(s19line.Substring(4, (int)(2 * linelen[linecnt])));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }

                }*/
                if (type == "S1")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = Int32.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = (ulong)linelen[linecnt] - 3;
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(8, (int)(2 * linelen[linecnt] - 4)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 3;//all len - address+crc
                    linecnt++;
                }
                else if (type == "S2")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = Int32.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    int kb = (int)linelen[linecnt];
                    datalen[linecnt] = (ulong)linelen[linecnt] - 4;
                    int kt = (int)datalen[linecnt];
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 6), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(10, (int)(2 * linelen[linecnt] - 6)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 4;//all len - address+crc
                    linecnt++;
                }
                else if (type == "S3")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = Int32.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = (ulong)linelen[linecnt] - 5;
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 8), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(12, (int)(2 * linelen[linecnt] - 8)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 5;//all len - address+crc
                    linecnt++;
                }
                /*else if (type == "S9")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = ulong.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = linelen[linecnt];
                    lineaddress[linecnt] = 0;
                    lineb = strfrm2bytearray(s19line.Substring(4, (int)(2 * linelen[linecnt])));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                }*/
                else { }
                s19line = null;
                lineb = null;
            }
            lastlineaddres = (UInt32)lineaddress[linecnt - 1];
            if (linetype[linecnt - 2] == "S1")
                lastlinelen = linelen[linecnt - 1] - 3;
            else if (linetype[linecnt - 2] == "S2")
                lastlinelen = linelen[linecnt - 1] - 4;
            else if (linetype[linecnt - 2] == "S3")
                lastlinelen = linelen[linecnt - 1] - 5;
            return 0;
        }
        //=================================================================
        byte creat_newbinfile()
        {
            string fpath;
            byte[] free = { 0xFF };
            ulong i = 0;
            try
            {
                i = (ulong)(Convert.ToInt32(textBox1.Text, 16));
                fpath = Path.GetDirectoryName(global_filepath);
                FileStream outbin = new FileStream(fpath + "\\1.bin", FileMode.Create, FileAccess.Write);
                BinaryWriter binwriter = new BinaryWriter(outbin);
                while (i < (ulong)(lastlineaddres + lastlinelen))
                {
                    binwriter.Write(free);
                    i++;
                }
                binwriter.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("creat_newbinfile fail!");
                return 0;
            }
        }
        //=================================================================
        bool write_data_2bin()
        {
            string fpath;
            UInt32 i = 0, x = 0;
            bool flg = false;
            //byte[] data = new byte[1000];

            fpath = Path.GetDirectoryName(global_filepath);
            FileStream outbin = new FileStream(fpath + "\\1.bin", FileMode.Open, FileAccess.Write);
            BinaryWriter binwriter = new BinaryWriter(outbin);
            //x = (UInt32)(Convert.ToInt32(textBox1.Text, 16));
            while (i < lastlineaddres)
            {
                if ((int)(lineaddress[x]) > (UInt32)(Convert.ToInt32(textBox1.Text, 16)))
                {
                    for (UInt32 j = 0; j < (long)datalen[x]; j++)
                    {
                        binwriter.Seek((int)(lineaddress[x] + j), SeekOrigin.Begin);
                        binwriter.Write(linedata[x, j]);
                    }
                    if (lineaddress[x] == lastlineaddres)
                        break;
                    x++;
                    flg = true;
                }
                i++;
                if (flg == false)
                    x = i;

            }
            binwriter.Close();

            /*while (lineaddress[i] < (ulong)(Convert.ToInt32(textBox2.Text, 16)))
            {
                if ((lineaddress[i] >= (ulong)(Convert.ToInt32(textBox1.Text, 16)) && (lineaddress[i] < (ulong)(Convert.ToInt32(textBox2.Text, 16)))))
                {
                    if (linetype[i] == "S1" || linetype[i] == "S2" || linetype[i] == "S3")
                    {
                        for (int j = 0; j <= (long)datalen[i]; j++)
                        {
                            binwriter.Write(linedata[i, j]);
                        }
                    }
                }
                if (lineaddress[i] == startindex[1])
                    break;
                i++;
            }
            binwriter.Close();*/
            return true;
        }
        //=================================================================
        byte write_txt_file()
        {
            string fpath, S1 = "";
            int i = 0;
            try
            {
                fpath = Path.GetDirectoryName(global_filepath);
                FileStream outfram = new FileStream(fpath + "\\1.txt", FileMode.Append, FileAccess.Write);
                StreamWriter finaltxt = new StreamWriter(outfram);
                while (linelen[i] != 0)
                {
                    for (int j = 0; j < (Int32)(linelen[i] - (Int32)difflen[i]); j++)
                    {
                        if (linelen[i] == 0)
                            break;
                        S1 = S1 + linedata[i, j].ToString("X2");
                    }
                    if (linetype[i] != "S0" && linetype[i] != "S9")
                    {
                        if (lineaddress[i] > (ulong)(Convert.ToInt32(textBox2.Text, 16)))
                            break;
                        if ((lineaddress[i] >= (ulong)(Convert.ToInt32(textBox1.Text, 16)) && (lineaddress[i] < (ulong)(Convert.ToInt32(textBox2.Text, 16)))))
                            finaltxt.WriteLine(S1);
                    }
                    S1 = "";
                    i++;
                }
                finaltxt.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("write_txt_file fail!");
                return 0;
            }
        }
        //=================================================================
        byte downtxt_file()
        {
            string fpath, S1 = "", S2 = "", sfinal = "";
            int i = 0,k = 0;

            try
            {
                fpath = Path.GetDirectoryName(global_filepath);
                FileStream outfram = new FileStream(fpath + "\\downtxt.txt", FileMode.Append, FileAccess.Write);
                StreamWriter downtxt = new StreamWriter(outfram);
                while (linelen[i] != 0)
                {
                    for (int j = 0; j < (Int32)(linelen[i] - (Int32)difflen[i]); j++)
                    {
                        if (linelen[i] == 0)
                            break;
                        S1 = S1 + linedata[i, j].ToString("X2");
                    }
                    if (linetype[i] != "S0" && linetype[i] != "S9")
                    {
                        if (lineaddress[i] > (ulong)(Convert.ToInt32(textBox2.Text, 16)))
                            break;
                        if ((lineaddress[i] < (ulong)(Convert.ToInt32(textBox1.Text, 16)) && (lineaddress[i] > (ulong)(Convert.ToInt32(textBox2.Text, 16)))))
                            break;
                    }
                    i++;
                }
                i = 0;
                UInt32 lenfrm = (UInt32)(Convert.ToInt32(textBox4.Text, 16));
                UInt32 frlen = 0;
                byte[] len = { 0, 0 };
                while (i < ((S1.Length)))
                {
                    S2 = S2 + S1.Substring(i, 2) + " ";
                    i += 2;
                    frlen++;
                    if (frlen == lenfrm)
                    {
                        len[0] = (byte)((frlen >> 8) & 0xFF);
                        len[1] = (byte)(frlen & 0xFF);
                        sfinal = sfinal + len[0].ToString("X2") + " " + len[1].ToString("X2") + " " + S2 + "\r\n";
                        frlen = 0;
                        S2 = "";
                    }
                }
                if(frlen < lenfrm)
                {
                    len[0] = (byte)((frlen >> 8) & 0xFF);
                    len[1] = (byte)(frlen & 0xFF);
                    sfinal = sfinal + len[0].ToString("X2") + " " + len[1].ToString("X2") + " " + S2 + "\r\n";
                    S2 = "";
                    frlen = 0;
                }
                downtxt.WriteLine(sfinal);
                downtxt.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("downtxt_file fail!");
                return 0;
            }
        }

        //=================================================================
        //=================================================================
        //=================================================================
        //=================================================================
        private void Calccrc_Click(object sender, EventArgs e)
        {
            string fpath = null, sout = null;
            int i = 0, siz = 0;
            byte cs = 0;
            byte[] areab;

            /*Calccrc.Cursor = Cursors.WaitCursor;
            Calccrc.Enabled = false;
            OpenFileDialog Openn = new OpenFileDialog();
            Openn.Title = "انتخاب فایل";
            Openn.Filter = "bin|*.bin|hex|*.hex";
            if (Openn.ShowDialog() == DialogResult.OK)
            {
                fpath = Openn.FileName.ToString();
            }
            Calccrc.Cursor = Cursors.Default;
            Calccrc.Enabled = true;
            lblshowresult.BackColor = Color.Yellow;
            lblshowresult.Text = "please wait...";*/
            fpath = file_path("S19|*.s19|S28|*.s28|HEX|*.hex");
            if (fpath != null && fpath != string.Empty)
            {
                load_file(fpath);
                /*FileStream inbin = new FileStream(fpath, FileMode.Open, FileAccess.Read);
                BinaryReader binreader = new BinaryReader(inbin);
                siz = (int)(Convert.ToInt32(textBox7.Text, 16) - Convert.ToInt32(textBox6.Text, 16));
                binreader.ReadBytes(Convert.ToInt32(textBox6.Text, 16));*/
                //areab = binreader.ReadBytes(siz);
                areab = get_byte_area();
                while (i < areab.Length)
                {
                    cs = (byte)(cs + areab[i]);
                    i++;
                    /*lblshowresult.Text = i.ToString();
                    if(i%10000 ==0)
                        Refresh();*/
                }
                sout = sout + "cs   :  " + cs.ToString("X2") + "\n\n";
                sout = sout + "calccrc16    :   " + calccrc16(areab).ToString("X2") + "\n\n";
                sout = sout + "calccrc32    :   " + calccrc32(areab).ToString("X2") + "\n\n";
                sout = sout + "nccitt   :   " + nccitt(areab).ToString("X2") + "\n\n";
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "Success";
                MessageBox.Show(sout);
            }
        }
        //=================================================================
        byte read_bin_file()
        {
            string fpath;
            int siz = 0;
            byte len0 = 0, len1 = 0;
            byte crc1 = 0, crc2 = 0;
            ulong crc = 0;
            int x = 0;
            string str = null, allcrc = null;

            x = Convert.ToInt32(textBox4.Text, 16) - 3;
            siz = (int)(Convert.ToInt32(textBox2.Text, 16) - Convert.ToInt32(textBox1.Text, 16));

            fpath = Path.GetDirectoryName(global_filepath);
            FileStream inbin = new FileStream(fpath + "\\1.bin", FileMode.Open, FileAccess.Read);
            BinaryReader binreader = new BinaryReader(inbin);
            FileStream outfram = new FileStream(fpath + "\\final.txt", FileMode.Create, FileAccess.Write);
            StreamWriter framWriter = new StreamWriter(outfram);
            binreader.ReadBytes(Convert.ToInt32(textBox1.Text, 16));
            siz -= Convert.ToInt32(textBox1.Text, 16);
            while (siz > x)
            {
                byte[] byt = binreader.ReadBytes(x);
                siz -= x;
                str = BitConverter.ToString(byt);
                str = str.Replace("-", "");

                str = textBox5.Text + str;
                byte[] log = str2BytArry(str);
                crc = calccrc16(log);
                crc1 = (byte)(crc & 0xFF);
                crc2 = (byte)((crc >> 8) & 0xFF);
                len0 = (byte)((x + 3) / 256);
                len1 = (byte)((x + 3) % 256);
                str = len0.ToString("X2") + len1.ToString("X2") + str + crc2.ToString("X2") + crc1.ToString("X2");
                framWriter.WriteLine(str);
            }
            if (siz > 0)
            {
                byte[] byt = binreader.ReadBytes((int)siz);
                str = BitConverter.ToString(byt);
                str = str.Replace("-", "");
                allcrc = allcrc + str;
                str = textBox5.Text + str;
                byte[] log = str2BytArry(str);
                crc = calccrc16(log);
                str = str + crc.ToString("X4");
                len0 = (byte)((siz + 3) / 256);
                len1 = (byte)((siz + 3) % 256);
                str = len0.ToString("X2") + len1.ToString("X2") + str;
                framWriter.WriteLine(str);
            }
            siz = 0;
            x = 0;
            str = null;
            framWriter.Close();
            outfram.Close();
            inbin.Close();
            return 1;
        }
        //=================================================================
        private byte[] str2BytArry(string fix)
        {
            if ((fix.Length % 2) != 0)
                fix = "0" + fix;
            return Enumerable.Range(0, fix.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(fix.Substring(x, 2), 16)).ToArray();
        }
        //=================================================================
        bool create_FFbin()
        {
            string fpath;
            byte[] free = { 0xFF };
            ulong i = 0, endaddress = 0;

            i = (ulong)(Convert.ToInt32(textBox1.Text, 16));
            fpath = Path.GetDirectoryName(global_filepath);
            FileStream outbin = new FileStream(fpath + "\\1.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter binwriter = new BinaryWriter(outbin);
            while (i <= (ulong)(Convert.ToInt32(textBox2.Text, 16)))
            {
                if (i > (ulong)(Convert.ToInt32(textBox2.Text, 16)))
                    break;
                if ((i >= (ulong)(Convert.ToInt32(textBox1.Text, 16)) && (i < (ulong)(Convert.ToInt32(textBox2.Text, 16)))))
                    binwriter.Write(free);
                i++;
            }
            binwriter.Close();
            return false;
        }
        //=================================================================
        bool bin_default_value()
        {
            int i = 0;
            //while(i < 0)
            {

            }
            return true;
        }
        //=================================================================
        byte[] get_byte_area()
        {
            int i = 0, k = 0;
            byte[] bt=new byte[10000000];

            uint stadd = (uint)(Convert.ToInt32(textBox6.Text, 16));
            uint enadd = (uint)(Convert.ToInt32(textBox7.Text, 16));
            while (linelen[i] != 0)
            {
                if (lineaddress[i] >= stadd && lineaddress[i] <= enadd)
                {
                    for (int j = 0; j < (Int32)(linelen[i] - (Int32)difflen[i]); j++)
                    {
                        if (linelen[i] == 0)
                            return bt;
                        bt[k] = linedata[i, j];
                        k++;
                    }
                }
                i++;
            }
            return bt;
        }
        //=================================================================
        public static byte[] strfrm2bytearray(string hex)
        {
            //hex = hex.Replace(",",string.Empty);
            //hex = hex.Replace("0x", string.Empty);

            return Enumerable.Range(0, hex.Length)
                                .Where(x => x % 2 == 0)
                                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                .ToArray();
        }//convert hex string to byte array 
        //=================================================================
        bool clear_allvalue()
        {
            global_filepath = "";
            linecnt = 0;
            Array.Clear(linetype, 0, 20000);
            Array.Clear(linelen, 0, 20000);
            Array.Clear(datalen, 0, 30000);
            Array.Clear(lineaddress, 0, 20000);
            Array.Clear(linedata, 0, 20000);
            Array.Clear(difflen, 0, 20000);
            Array.Clear(startindex, 0, 10);

            return true;
        }
        //=================================================================
        byte new_write_data2bin()
        {
            string fpath;
            UInt32 i = 0;
            try
            {
                fpath = Path.GetDirectoryName(global_filepath);
                FileStream outbin = new FileStream(fpath + "\\1.bin", FileMode.Open, FileAccess.Write);
                BinaryWriter binwriter = new BinaryWriter(outbin);
                while (i < lastlineaddres)
                {
                    for (UInt32 j = 0; j < (long)datalen[i]; j++)
                    {
                        binwriter.Seek((int)(lineaddress[i] + j), SeekOrigin.Begin);
                        binwriter.Write(linedata[i, j]);
                    }
                    if (lineaddress[i] == lastlineaddres)
                        break;
                    i++;
                }
                binwriter.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("new_write_data2bin fail!");
                return 0;
            }
}
        //=================================================================
        



        //=================================================================
        // INPUT S19 FILE =================================================
        //=================================================================
        //=================================================================
        //=================================================================

        //=================================================================
        // INPUT S28 FILE =================================================
        //=================================================================
        //=================================================================
        //=================================================================

        //=================================================================
        // INPUT S37 FILE =================================================
        //=================================================================
        //=================================================================
        //=================================================================



        //=================================================================
        // INPUT HEX FILE =================================================
        //=================================================================
        private void hexbtn1_Click(object sender, EventArgs e)
        {
            
            string hexfilepath = file_path("HEX|*.hex");
            read_hex_file(hexfilepath);
            //print_add_terminal(hexfilepath);
            hexfile_data(hexfilepath);
            data_block_len(hexfilepath);
            integrated_hexdata(hexfilepath);
            integrated_hexfile(hexfilepath);
            if(comboBox1.SelectedItem != null)
                calc_allcrc(hexfilepath);
            //delete_allfiles(hexfilepath);
            
        }




        private void read_hex_file(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                byte[] fileBytes = File.ReadAllBytes(hexpath);
                string hexdata = Encoding.UTF8.GetString(fileBytes);

                string directoryPath = Path.GetDirectoryName(hexpath);
                hexdata = hexdata.Replace(":", "");
                File.WriteAllText(directoryPath + "\\file1.txt", hexdata);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "read hex file done";
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "read hex file error";
            }
        }
        private void hexfile_data(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string hexdata = "", hexdata2="";
                bool enterflag = false;
                string directoryPath = Path.GetDirectoryName(hexpath);

                StreamReader reader = new StreamReader(hexpath);
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(":", "");
                    byte ttline = byte.Parse(line.Substring(6, 2));
                    if (ttline == 0)
                    {
                        hexdata = hexdata + line.Substring(8, (line.Length - 10));
                        enterflag = true;
                    }
                    else if (ttline == 4 && enterflag == true)
                    {
                        hexdata2 = hexdata2 + hexdata + "\r\n";
                        hexdata = null;
                    }
                    else if (ttline == 1)
                    {
                        hexdata2 = hexdata2 + hexdata;
                        File.WriteAllText(directoryPath + "\\file2.txt", hexdata2);
                    }
                }
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data in file done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data in file error";
            }
        }
        private void data_block_len(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string calclen = "";
                string directoryPath = Path.GetDirectoryName(hexpath);
                StreamReader reader = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    calclen = calclen + "0x" + (line.Length / 2).ToString("X2") + "\r\n" + line + "\r\n";
                }
                File.WriteAllText(directoryPath + "\\file3.txt", calclen);
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data block len in file done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data block len in file error";
            }
        }
        private void integrated_hexdata(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string line_1 = "";
                string hexdata = "", hexdata2 = "";

                string directoryPath = Path.GetDirectoryName(hexpath);
                StreamReader reader = new StreamReader(hexpath);
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(":", "");
                    byte ttline = byte.Parse(line.Substring(6, 2));
                    if (ttline == 0)
                    {
                        hexdata = hexdata + line.Substring(8, (line.Length - 10));
                        line_1 = line;
                    }
                    else if (ttline == 4)
                    {
                        if(hexdata != "")
                            hexdata2 = hexdata2 + hexdata + "\r\n::" + line_1 + "\r\n::" + line + "\r\n";
                        else
                            hexdata2 = "::" + line + "\r\n";
                        hexdata = null;
                    }
                    else if (ttline == 1)
                    {
                        hexdata2 = hexdata2 + hexdata + "\r\n::" + line_1 + "\r\n::" + line + "\r\n";
                        File.WriteAllText(directoryPath + "\\file4.txt", hexdata2);
                    }
                }
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write integrated hex data in file done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write integrated hex data in file error";
            }
        }
        private void integrated_hexfile(string hexpath)
        {
            try
            {
                string line = "";
                string lineid = "";
                string hexdata = "", hexdata2 = "";
                UInt32 Hadd = 0, Ladd = 0;
                string calclen = "";

                string directoryPath = Path.GetDirectoryName(hexpath);
                StreamReader reader = new StreamReader(directoryPath + "\\file4.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    //line = line.Replace(":", "");
                    byte ttline = byte.Parse(line.Substring(8, 2));
                    lineid = line.Substring(0, 2);
                    if (lineid == "::")
                    {
                        if(ttline == 1)
                        {
                            hexdata2 = hexdata2 + hexdata;
                            File.WriteAllText(directoryPath + "\\file5.txt", hexdata2);
                            break;
                        }
                        if (Hadd + 1 == Convert.ToUInt32(line.Substring(10, 4), 16) && Ladd == 0xFFF0)
                        {
                            hexdata2 = hexdata2 + hexdata;
                        }
                        else if(hexdata2 != "")
                        {
                            hexdata2 = hexdata2 +  hexdata + "\r\n";
                        }
                        Hadd = Convert.ToUInt32(line.Substring(10, 4),16);
                        hexdata = reader.ReadLine();
                        line = reader.ReadLine();
                        Ladd = Convert.ToUInt32(line.Substring(4, 4), 16);
                    }
                }
                reader.Dispose();
                StreamReader reader5 = new StreamReader(directoryPath + "\\file5.txt");
                while ((line = reader5.ReadLine()) != null)
                {
                    calclen = calclen + "0x" + (line.Length / 2).ToString("X2") + "\r\n" + line + "\r\n";
                }
                reader5.Dispose();
                File.Delete(directoryPath + "\\file5.txt");
                File.WriteAllText(directoryPath + "\\file5.txt", calclen);





                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write integrated hex file done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write integrated hex file error";
            }
        }


        private void calc_allcrc(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                UInt32 crc = 0;

                string directoryPath = Path.GetDirectoryName(hexpath);
                line = File.ReadAllText(directoryPath + "\\file2.txt");
                line = line.Replace("\r\n","");
                byte[] bytes = new byte[line.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 1://CHECKSUM
                        crc = calccs(bytes);
                        break;
                    case 2://CRC8
                        crc = CalculateCRC8(bytes);
                        break;
                    case 3://CRC16
                        crc = calccrc16(bytes);
                        break;
                    case 4://CRC32(1)
                        crc = Crc32(bytes);
                        break;
                    case 5://CRC32(2)
                        crc = calccrc32(bytes);
                        break;
                    case 6://NCCITT
                        crc = nccitt(bytes);
                        break;
                    case 7://CCITT
                        crc = ccitt(bytes);
                        break;
                    default:
                        break;
                }
                File.WriteAllText(directoryPath + "\\file6.txt", "0x" + crc.ToString("X8") + "\r\n" + line);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "calculate all data crc done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "calculate all data crc error";
            }
        }


        private void print_add_terminal(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            string terminal = null;
            try
            {
                StreamReader reader = new StreamReader(hexpath);
                string line;
                string beforettline = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(":", "");
                    string ttline = line.Substring(6, 2);
                    if (ttline == "04" || ttline == "01" || ttline == "05")
                    {
                        terminal = terminal + beforettline + "\r\n\r\n" + line + "\r\n";
                    }
                    beforettline = null;
                    if (ttline == "00")
                        beforettline = line;
                }
                textBox9.Text = terminal;
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "print in terminal done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "print in terminal error";
            }
        }
        private void delete_allfiles(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string directoryPath = Path.GetDirectoryName(hexpath);
                File.Delete(directoryPath + "\\file1.txt");
                File.Delete(directoryPath + "\\file2.txt");
                File.Delete(directoryPath + "\\file3.txt");

                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "delete all files done";
                this.Refresh();
            }
            catch (Exception e)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "delete all files error";
            }
        }
        //=================================================================
        //=================================================================




            

        //=================================================================
        // GENERAL FUNCTION ===============================================
        //=================================================================
        string file_path(string extend)
        {
            btnGo.Cursor = Cursors.WaitCursor;
            btnGo.Enabled = false;
            string fileName = null;
            OpenFileDialog Openn = new OpenFileDialog();
            Openn.Title = "انتخاب فایل";
            Openn.Filter = extend;
            if (Openn.ShowDialog() == DialogResult.OK)
            {
                fileName = Openn.FileName.ToString();
                //ecomux(fileName);
            }
            btnGo.Cursor = Cursors.Default;
            btnGo.Enabled = true;
            global_filepath = fileName;
            return fileName;
        }
        //=================================================================
        //=================================================================

        //=================================================================
        // CALC CRC =======================================================
        //=================================================================
        private uint Crc32(byte[] array)
        {
            uint crc = 0xFFFFFFFF;
            uint i;
            for (i = 0; i < array.Length; i++)
            {
                uint bite = array[i];
                crc = crc ^ bite;
                int j;
                for (j = 7; j >= 0; j--)
                {
                    long mask = -(crc & 1);
                    crc = (crc >> 1) ^ (0xEDB88320 & ((UInt32)mask));
                }
            }
            return ~crc;
        }
        //=================================================================
        private UInt16 calccrc16(byte[] pData)
        {
            UInt16 CRCbuffer = 0;
            UInt16 ByteCounter = 0;
            byte BitCounter = 0;

            CRCbuffer = 0xFFFF;

            for (ByteCounter = 0; ByteCounter < pData.Length; ByteCounter++)
            {
                for (BitCounter = 0; BitCounter < 8; BitCounter++)
                {
                    CRCbuffer = (UInt16)(CRCbuffer >> 1);
                    if (((byte)((CRCbuffer & 0x01) ^ ((pData[ByteCounter] >> BitCounter) & 0x01))) != 0)
                    {
                        CRCbuffer = (UInt16)(CRCbuffer ^ 0x8408);//0x8408
                    }
                }
            }
            CRCbuffer = (UInt16)(~CRCbuffer);
            return CRCbuffer;
        }
        //=================================================================
        UInt32 calccrc32( byte[] pData)
        {
            UInt16 i;
            byte BitCounter;
            UInt32 Checksum32 = 0xFFFFFFFF;


            for (i = 0; i < pData.Length; i++)
            {
                for (BitCounter = 0; BitCounter < 8; BitCounter++)
                {
                    Checksum32 >>= 1;
                    if (((UInt32)(Checksum32 & 0x01) ^ ((pData[i] >> BitCounter) & 0x01)) != 0)
                    {
                        Checksum32 ^= 0x8408;//0x8408
                    }
                }
            }
            return Checksum32;
        }
        //=================================================================
        private uint nccitt(byte[] array)
        {
            ushort num7 = 0x8408;
            ushort num8 = 0xffff;
            int length = array.Length;
            ushort num = num8;
            for (uint i = 0; i < length; i++)
            {
                byte num6 = array[i];
                for (byte j = 0; j < 8; j = (byte)(j + 1))
                {
                    byte num4 = (byte)((num6 >> j) & 1);
                    byte num5 = (byte)((num & 1) ^ num4);
                    num = (ushort)(num >> 1);
                    if (num5 != 0)
                    {
                        num = (ushort)(num ^ num7);
                    }
                }
            }
            return (ushort)(num ^ 0xffff);
        }
        //=================================================================
        private uint ccitt(byte[] array)
        {
            uint num = 0xffff;
            uint num2 = 0x1021; //0x8404;//
            uint length = (uint)array.Length;
            byte[] buffer = new byte[2];
            this.reverseBits(array);
            for (uint i = 0; i < length; i++)
            {
                for (uint j = 0; j < 8; j++)
                {
                    byte num5 = (byte)(7 - j);
                    num5 = (byte)(array[i] >> num5);
                    num5 = (byte)(num5 & 1);
                    byte num6 = (byte)(num >> 15);
                    num6 = (byte)(num6 & 1);
                    num = num << 1;
                    if ((num6 ^ num5) != 0)
                    {
                        num ^= num2;
                    }
                }
            }
            num &= 0xffff;
            buffer[0] = (byte)(num & 0xff);
            buffer[1] = (byte)((num >> 8) & 0xff);
            this.reverseBits(buffer);
            buffer[0] = (byte)(buffer[0] ^ 0xff);
            buffer[1] = (byte)(buffer[1] ^ 0xff);
            this.reverseBits(array);
            uint num8 = (uint)((buffer[1] << 8) + buffer[0]);
            return num8;
        }
        //=================================================================
        static byte CalculateCRC8(byte[] array)
        {
            byte crc = 0x00;
            byte polynomial = 0x07;

            foreach (byte b in array)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x80) != 0)
                    {
                        crc = (byte)((crc << 1) ^ polynomial);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return crc;
        }
        //=================================================================
        private UInt32 calccs(byte[] array)
        {
            uint sum = 0;

            foreach (byte value in array)
            {
                sum += value;
            }
            return sum;
        }
        //=================================================================
        //=================================================================
        //=================================================================
        private void reverseBits(byte[] array)
        {
            uint length = (uint)array.Length;
            for (uint i = 0; i < length; i++)
            {
                byte num3 = 0;
                byte num4 = 1;
                for (byte j = 0; j < 8; j++)
                {
                    if ((array[i] & num4) != 0)
                    {
                        num3 = (byte)(num3 | ((byte)(((int)1) << (7 - j))));
                    }
                    num4 = (byte)(num4 << 1);
                }
                array[i] = num3;
            }
        }



    }
}
