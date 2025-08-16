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
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

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

        //=================================================================


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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show("downtxt_file fail!");
                return 0;
            }
        }

        //=================================================================
        //=================================================================
        //=================================================================
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
            catch (Exception ex)
            {
                MessageBox.Show("new_write_data2bin fail!");
                return 0;
            }
}
        //=================================================================
        private bool readDowntxt(string inName)
        {
            string datNam = null, str = null, okstr = null;
            long lcount = 0, c = 0;
            byte[] dtc = { 0, 0, 0, 0 }, code = { 0, 0, 0, 0 };
            int linenum = 0;
            byte wr = 0;
            Regex rex = new Regex("[^0-9a-fA-F]");
            lcount = File.ReadAllLines(inName).Count();
            FileStream inLog = new FileStream(inName, FileMode.Open, FileAccess.Read);
            StreamReader logReader = new StreamReader(inLog);
            int lengn = inName.Length - (inName.LastIndexOf('\\') + 20);
            datNam = "final.dat";
            FileStream outdat = new FileStream(datNam, FileMode.Create, FileAccess.Write);
            BinaryWriter datwriter = new BinaryWriter(outdat);
            try
            {
                wr = (byte)(lcount % 256);
                datwriter.Write(wr);
                wr = (byte)(lcount / 256);
                datwriter.Write(wr);
                for (c = 0; c < lcount; c++)
                {
                    Console.WriteLine(c.ToString());
                    Console.WriteLine(lcount.ToString());
                    str = logReader.ReadLine();
                    str = str.Replace("0x", String.Empty);
                    okstr = rex.Replace(str, String.Empty);
                    linenum = (okstr.Length) / 2;
                    wr = (byte)(linenum % 256);
                    datwriter.Write(wr);
                    wr = (byte)(linenum / 256);
                    datwriter.Write(wr);
                    byte[] hexStr = str2BytArry(okstr);
                    datwriter.Write(hexStr);
                    okstr = null;
                }
                lcount = 0;
                str = null;
                okstr = null;
                linenum = 0;
                logReader.Close();
                inLog.Close();
                datNam = null;
                datwriter.Close();
                outdat.Close();
                return true;
            }
            catch
            {
                lcount = 0;
                str = null;
                okstr = null;
                linenum = 0;
                logReader.Close();
                inLog.Close();
                datNam = null;
                datwriter.Close();
                outdat.Close();
                return false;
            }
        }



        //=================================================================
        // INPUT S19 FILE =================================================
        //=================================================================
        //=================================================================
        //=================================================================
        private void s19btn1_Click(object sender, EventArgs e)
        {
            try
            {
                //lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
                string s19filepath = file_path("S19|*.s19");
                if (s19filepath == null)
                    return;

                s19_read_file(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("read file done");
                s19_file_data(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("write data to txt done");
                s19_create_FFbin(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("create FF bin done");
                s19_write_tobin(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("write to bin done");
                s19_check_block_add(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("check block address done");
                s19_bin_totxt(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("bin to txt done");

            }
            catch(Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "s19 btn error";
            }

        }
        private void s19btn2_Click(object sender, EventArgs e)
        {
            try
            {
                //lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
                string s19filepath = file_path("TXT|*file4.txt");
                if (s19filepath == null)
                    return;

                s19_make_dataframe(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("read file done");
                

            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "s19 btn error";
            }
        }
        private void s19_read_file(string s19path)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                byte[] fileBytes = File.ReadAllBytes(s19path);
                string s19data = Encoding.UTF8.GetString(fileBytes);

                string directoryPath = Path.GetDirectoryName(s19path);
                s19data = s19data.Replace(":", "");
                File.WriteAllText(directoryPath + "\\file1.txt", s19data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "read s19 file done";
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "read s19 file error";
            }
        }
        private void s19_file_data(string s19path)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string data = "";
                UInt32 add = 0;

                string directoryPath = Path.GetDirectoryName(s19path);
                StreamReader reader = new StreamReader(s19path);
                while ((line = reader.ReadLine()) != null)
                {
                    string type = line.Substring(0, 2);
                    if (type == "S0")// file info
                    {
                    }
                    if (type == "S1")// 2byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 4), 16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(8, (line.Length - 10)) + "\r\n";
                    }
                    else if (type == "S2")// 3byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 6),16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(10, (line.Length - 12)) + "\r\n";
                    }
                    else if (type == "S3")// 4byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 8), 16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(12, (line.Length - 14)) + "\r\n";
                    }
                    else if (type == "S5")// data counter
                    {
                    }
                    else if (type == "S7" || type == "S8" || type == "S9")// end data
                    {
                    }
                }
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file2.txt", data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data in file done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data in file error";
            }
        }
        private void s19_create_FFbin(string s19path)
        {
            byte[] free = { 0xFF };
            ulong i = 0;

            string directoryPath = Path.GetDirectoryName(s19path);
            i = (ulong)(Convert.ToInt32(textBox1.Text, 16));
            FileStream outbin = new FileStream(directoryPath + "\\binfile1.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter binwriter = new BinaryWriter(outbin);
            while (i <= (ulong)(0xFFFFFF))
            {
                binwriter.Write(free);
                i++;
            }
           binwriter.Close();
        }
        private void s19_write_tobin(string s19path)
        {
            try
            {
                int i = 0;
                string line = "";

                string directoryPath = Path.GetDirectoryName(s19path);
                FileStream outbin = new FileStream(directoryPath + "\\binfile1.bin", FileMode.Open, FileAccess.Write);
                BinaryWriter binwriter = new BinaryWriter(outbin);
                StreamReader reader = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    binwriter.Seek(Convert.ToInt32(line.Substring(2,8),16), SeekOrigin.Begin);
                    line = line.Remove(0, 12);
                    byte[] byteArray = HexStringToByteArray(line);
                    binwriter.Write(byteArray);
                }
                binwriter.Close();
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data to bin file done";
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data to bin file error";
            }
        }
        private void s19_check_block_add(string s19path)
        {
            try
            {
                int i = 0, j = 0, k = 0;
                string line = "";
                string data = "";
                string add_1 = "";
                UInt32[,] addbyte = new UInt32[2,50];
                addbyte = null;
                string directoryPath = Path.GetDirectoryName(s19path);
                StreamReader reader = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    if (k==0)
                        data = data + line.Substring(2, 8);
                    else if(line.Substring(7, 3) == "000")
                    {
                        data = data + "::" + add_1 + "\r\n" + line.Substring(2, 8);
                    }
                    add_1 = line.Substring(2, 8);
                    k++;
                }
                data = data + "::" + add_1 + "\r\n";
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file3.txt", data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write address in file done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write address in file error";
            }
        }
        private void s19_bin_totxt(string s19path)
        {
            try
            {
                int i = 0;
                string line = "";
                int startadd = 0, endadd = 0;
                string data = "",data2 = "";

                string directoryPath = Path.GetDirectoryName(s19path);
                StreamReader reader = new StreamReader(directoryPath + "\\file3.txt");
                FileStream binreader = new FileStream(directoryPath + "\\binfile1.bin", FileMode.Open, FileAccess.Read);
                while ((line = reader.ReadLine()) != null)
                {
                    startadd = Convert.ToInt32(line.Substring(0, 8), 16);
                    endadd = Convert.ToInt32(line.Substring(10, 8), 16);
                    int readlen = (endadd|0x000000FF) - startadd + 1;
                    byte[] buffer = new byte[readlen];
                    binreader.Position = startadd;
                    binreader.Read(buffer, 0, readlen);
                    data = ByteArrayToHexString(buffer);
                    data2 = data2 + "::start::0x" + startadd.ToString("X8") + "\r\n" + data + "\r\n" + "::end::0x" + (endadd | 0x000000FF).ToString("X8") + "\r\n";
                }
                reader.Dispose();
                binreader.Close();
                File.WriteAllText(directoryPath + "\\file4.txt", data2);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "read data from bin and write to txt done";
                this.Refresh();
            }
            catch(Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "read data from bin and write to txt error";
            }
        }
        private void s19_make_dataframe(string s19path)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string Linestart = "";
                int i = 0, numofcrc = 0;
                string frmhexdata = "", frmhexdata2 = "", frmhexdata3 = "";
                byte crc0 = 0, crc1 = 0, crc2 = 0, crc3 = 0;
                bool flgcrc = false, flgcnt = false;
                UInt32 crc = 0;
                byte frmcnt = 0;

                string directoryPath = Path.GetDirectoryName(s19path);
                StreamReader reader = new StreamReader(s19path);

                short frmLen = (short)Convert.ToInt16(textBox4.Text, 16);
                string SID = textBox5.Text;
                
                if (textBox14.Text != null && textBox14.Text != string.Empty)//crc
                {
                    numofcrc = Convert.ToByte(textBox14.Text);
                    frmLen = (short)(frmLen - numofcrc);
                    flgcrc = true;
                }
                if (textBox15.Text != null && textBox15.Text != string.Empty)//cnt
                {
                    frmcnt = Convert.ToByte(textBox15.Text);
                    frmLen = (short)(frmLen - frmcnt);
                    flgcnt = true;
                }
                
                while ((line = reader.ReadLine()) != null)
                {
                    Linestart = line.Substring(0, 2);
                    if (Linestart != "0x" && Linestart != "::" && Linestart != "\r\n" && Linestart != "\t")
                    {
                        while ((line.Length/2) >= frmLen)
                        {
                            frmhexdata = frmhexdata + SID;//SID
                            if (flgcnt == true)
                                frmhexdata = frmhexdata + frmcnt.ToString("X2");
                            frmhexdata = frmhexdata + line.Substring(0, (frmLen - 1) * 2);
                            if (flgcrc == true)
                            {
                                string data = frmhexdata.Substring(0, (frmLen) * 2);
                                byte[] bytes = new byte[data.Length / 2];
                                for (i = 0; i < bytes.Length; i++)
                                {
                                    bytes[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
                                }
                                switch (comboBox3.SelectedIndex)
                                {
                                    case 1: crc = calccs(bytes); break;             //CHECKSUM
                                    case 2: crc = CalculateCRC8(bytes); break;      //CRC8
                                    case 3: crc = calccrc16(bytes); break;          //CRC16
                                    case 4: crc = Crc32(bytes); break;              //CRC32(1)
                                    case 5: crc = calccrc32(bytes); break;          //CRC32(2)
                                    case 6: crc = nccitt(bytes); break;             //NCCITT
                                    case 7: crc = ccitt(bytes); break;              //CCITT
                                    case 8: crc = crc16_ccitt_false(bytes); break;  //CCITT FALSE
                                    default: break;
                                }
                                crc0 = (byte)(crc >> 24);
                                crc1 = (byte)(crc >> 16);
                                crc2 = (byte)(crc >> 8);
                                crc3 = (byte)(crc);
                                
                                if (numofcrc == 1)
                                    frmhexdata = frmhexdata + crc3.ToString("X2");
                                else if (numofcrc == 2)
                                    frmhexdata = frmhexdata + crc2.ToString("X2") + crc3.ToString("X2");
                                else if (numofcrc == 4)
                                    frmhexdata = frmhexdata + crc.ToString("X8");
                            }
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length / 2).ToString("X4") + frmhexdata + "\r\n";
                            line = line.Remove(0, (frmLen - 1) * 2);
                            frmhexdata = "";
                            frmcnt++;
                        }
                        if (line.Length < frmLen && line.Length != 0)
                        {
                            frmhexdata = frmhexdata + SID;//SID
                            if (flgcnt == true)
                                frmhexdata = frmhexdata + frmcnt.ToString("X2");
                            frmhexdata = frmhexdata + line.Substring(0, (Convert.ToInt16(line.Length)));
                            if (flgcrc == true)
                            {
                                string data = frmhexdata;
                                byte[] bytes = new byte[data.Length / 2];
                                for (i = 0; i < bytes.Length; i++)
                                {
                                    bytes[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
                                }
                                switch (comboBox3.SelectedIndex)
                                {
                                    case 1: crc = calccs(bytes); break;             //CHECKSUM
                                    case 2: crc = CalculateCRC8(bytes); break;      //CRC8
                                    case 3: crc = calccrc16(bytes); break;          //CRC16
                                    case 4: crc = Crc32(bytes); break;              //CRC32(1)
                                    case 5: crc = calccrc32(bytes); break;          //CRC32(2)
                                    case 6: crc = nccitt(bytes); break;             //NCCITT
                                    case 7: crc = ccitt(bytes); break;              //CCITT
                                    case 8: crc = crc16_ccitt_false(bytes); break;  //CCITT FALSE
                                    default: break;
                                }
                                crc0 = (byte)(crc >> 24);
                                crc1 = (byte)(crc >> 16);
                                crc2 = (byte)(crc >> 8);
                                crc3 = (byte)(crc);

                                if (numofcrc == 1)
                                    frmhexdata = frmhexdata + crc3.ToString("X2");
                                else if (numofcrc == 2)
                                    frmhexdata = frmhexdata + crc2.ToString("X2") + crc3.ToString("X2");
                                else if (numofcrc == 4)
                                    frmhexdata = frmhexdata + crc.ToString("X8");
                            }
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length / 2).ToString("X4") + frmhexdata + "\r\n";
                            line = "";
                            frmhexdata = "";
                        }
                        if (line.Length == 0)
                            frmhexdata2 = frmhexdata2 + "\r\n\r\n";
                        frmhexdata3 = frmhexdata3 + frmhexdata2;
                        frmhexdata2 = "";
                        if (flgcnt == true)
                            frmcnt = Convert.ToByte(textBox15.Text);
                    }
                }
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file5.txt", frmhexdata3);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "make data frame done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "make data frame error";
            }
        }

        
        static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
            }
            return hex.ToString();
        }
        //=================================================================
        // INPUT S28 FILE =================================================
        //=================================================================
        //=================================================================
        //=================================================================
        private void s28btn1_Click(object sender, EventArgs e)
        {
            try
            {
                //lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
                string s28filepath = file_path("S28|*.s28");
                if (s28filepath == null)
                    return;

                s28_read_file(s28filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("read file done");
                s28_file_data(s28filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("write data to txt done");
                s28_create_FFbin(s28filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("create FF bin done");
                s28_write_tobin(s28filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("write to bin done");
                s28_check_block_add(s28filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("check block address done");
                /*s19_bin_totxt(s19filepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("bin to txt done");*/

            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "s19 btn error";
            }
        }


        private void s28_read_file(string s28path)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                byte[] fileBytes = File.ReadAllBytes(s28path);
                string s19data = Encoding.UTF8.GetString(fileBytes);

                string directoryPath = Path.GetDirectoryName(s28path);
                s19data = s19data.Replace(":", "");
                File.WriteAllText(directoryPath + "\\file1.txt", s19data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "read s28 file done";
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "read s28 file error";
            }
        }
        private void s28_file_data(string s28path)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string data = "";
                UInt32 add = 0, lastadd = 0;

                string directoryPath = Path.GetDirectoryName(s28path);
                StreamReader reader = new StreamReader(s28path);
                while ((line = reader.ReadLine()) != null)
                {
                    string type = line.Substring(0, 2);
                    if (type == "S0")// file info
                    {
                    }
                    if (type == "S1")// 2byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 4), 16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(8, (line.Length - 10)) + "\r\n";
                        lastadd = (UInt32)(add + (line.Substring(8, (line.Length - 10))).Length/2);
                    }
                    else if (type == "S2")// 3byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 6), 16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(10, (line.Length - 12)) + "\r\n";
                        lastadd = (UInt32)(add + (line.Substring(10, (line.Length - 12))).Length/2);
                    }
                    else if (type == "S3")// 4byte address
                    {
                        add = Convert.ToUInt32(line.Substring(4, 8), 16);
                        data = data + "0x" + add.ToString("X8") + "::" + line.Substring(12, (line.Length - 14)) + "\r\n";
                        lastadd = (UInt32)(add + (line.Substring(12, (line.Length - 14))).Length/2);
                    }
                    else if (type == "S5")// data counter
                    {
                    }
                    else if (type == "S7" || type == "S8" || type == "S9")// end data
                    {
                        data = data + "::0x" + lastadd.ToString("X8") + "\r\n";
                    }
                }
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file2.txt", data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data in file done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data in file error";
            }
        }
        private void s28_create_FFbin(string s28path)
        {
            try
            {
                byte[] free = { 0xFF };
                ulong i = 0;

                string directoryPath = Path.GetDirectoryName(s28path);
                i = (ulong)(Convert.ToInt32(textBox1.Text, 16));
                FileStream outbin = new FileStream(directoryPath + "\\binfile1.bin", FileMode.Create, FileAccess.Write);
                BinaryWriter binwriter = new BinaryWriter(outbin);
                while (i <= (ulong)(0xFFFFFF))
                {
                    binwriter.Write(free);
                    i++;
                }
                binwriter.Close();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data in bin done";
                this.Refresh();
            }
            catch(Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data in bin error";
            }
        }
        private void s28_write_tobin(string s28path)
        {
            try
            {
                int i = 0;
                string line = "";

                string directoryPath = Path.GetDirectoryName(s28path);
                FileStream outbin = new FileStream(directoryPath + "\\binfile1.bin", FileMode.Open, FileAccess.Write);
                BinaryWriter binwriter = new BinaryWriter(outbin);
                StreamReader reader = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    binwriter.Seek(Convert.ToInt32(line.Substring(2, 8), 16), SeekOrigin.Begin);
                    line = line.Remove(0, 12);
                    byte[] byteArray = HexStringToByteArray(line);
                    binwriter.Write(byteArray);
                }
                binwriter.Close();
                reader.Dispose();
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write data to bin file done";
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data to bin file error";
            }
        }
        private void s28_check_block_add(string s28path)
        {
            try
            {
                int i = 0, j = 0, k = 0;
                string line = "";
                string data = "";
                string add_1 = "";
                UInt32 start = 0, linelen = 0;
                UInt32[,] addbyte = new UInt32[2, 50];
                addbyte = null;
                string directoryPath = Path.GetDirectoryName(s28path);
                StreamReader reader = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    start = Convert.ToUInt32(line.Substring(2, 8));
                    linelen = (UInt32)line.Length - 12;

                    data = data + "::" + start.ToString("X8") + (start + linelen).ToString("X8") + "\r\n";

                    /*if (line.Substring(7, 3) == "000" && k == 0)
                        data = data + line.Substring(2, 8);
                    else if (line.Substring(7, 3) == "000")
                    {
                        data = data + "::" + add_1 + "\r\n" + line.Substring(2, 8);
                    }
                    add_1 = line.Substring(2, 8);
                    k++;*/
                }
                data = data + "::" + add_1 + "\r\n";
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file3.txt", data);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "write address in file done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write address in file error";
            }
        }











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
            try
            {
                string hexfilepath = file_path("HEX|*.hex");
                if (hexfilepath == null)
                    return;

                /*hex_read_file(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("read file done");
                //hex_print_terminal(hexfilepath);
                //if (globalcheckbox1.Checked == true) MessageBox.Show("read file done");
                hex_file_data(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("write data to txt done");
                hex_data_block_len(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("data block len done");
                hex_integrated_data(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("integrated data done");
                hex_integrated_file(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("integrated file done");
                //if (comboBox1.SelectedItem != null)
                    //hex_calc_allcrc(hexfilepath);
                //if (globalcheckbox1.Checked == true) MessageBox.Show("calc all crc done");
                hex_make_dataframe(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("make data frame done");
                hex_calc_crc(hexfilepath);
                if (globalcheckbox1.Checked == true) MessageBox.Show("calc block crc done");
                //hex_delete_allfiles(hexfilepath);
                //if (globalcheckbox1.Checked == true) MessageBox.Show("delete all files done");*/
                hex_bsd_crouse(hexfilepath);



            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "hex btn error";
            }

        }
        private void hex_read_file(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "read hex file error";
            }
        }
        private void hex_file_data(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data in file error";
            }
        }
        private void hex_data_block_len(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write data block len in file error";
            }
        }
        private void hex_integrated_data(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write integrated hex data in file error";
            }
        }
        private void hex_integrated_file(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "write integrated hex file error";
            }
        }
        private void hex_make_dataframe(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                string Linestart = "";
                int i = 0, numofcrc = 0;
                string frmhexdata = "", frmhexdata2 = "", frmhexdata3 = "";

                string directoryPath = Path.GetDirectoryName(hexpath);
                StreamReader reader = new StreamReader(directoryPath + "\\file5.txt");
                short frmLen = (short)(Convert.ToInt16(textBox10.Text, 16)-1-numofcrc);
                string SID = textBox11.Text;
                byte frmcnt = Convert.ToByte(textBox12.Text);

                while ((line = reader.ReadLine()) != null)
                {
                    Linestart = line.Substring(0,2);
                    if (Linestart != "0x")
                    {
                        while (line.Length >= frmLen)
                        {
                            frmhexdata = SID + frmcnt.ToString("X2") + line.Substring(0, (frmLen - 1) * 2);
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length/2).ToString("X4") + frmhexdata + "\r\n";
                            line = line.Remove(0, (frmLen - 1) * 2);
                            frmcnt++;
                        }
                        if (line.Length < frmLen && line.Length != 0)
                        {
                            frmhexdata = SID + frmcnt.ToString("X2") + line;
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length / 2).ToString("X4") + frmhexdata + "\r\n";
                            line = "";
                        }
                        if(line.Length == 0)
                            frmhexdata2 = frmhexdata2 + "\r\n\r\n";
                        frmhexdata3 = frmhexdata3 + frmhexdata2;
                        frmhexdata2 = "";
                        frmcnt = Convert.ToByte(textBox12.Text);
                    }
                }
                reader.Dispose();
                File.WriteAllText(directoryPath + "\\file6.txt", frmhexdata3);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "make data frame done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "make data frame error";
            }
        }
        private void hex_calc_crc(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                UInt32 crc = 0;
                string datablockcrc = "",dataallcrc = "";

                string directoryPath = Path.GetDirectoryName(hexpath);
                StreamReader reader = new StreamReader(directoryPath + "\\file5.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Substring(0, 2) != "0x")
                    {
                        byte[] bytes = new byte[line.Length / 2];
                        dataallcrc = dataallcrc + line;
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
                        }
                        switch (comboBox1.SelectedIndex)
                        {
                            case 1: crc = calccs(bytes); break;//CHECKSUM
                            case 2: crc = CalculateCRC8(bytes); break;//CRC8
                            case 3: crc = calccrc16(bytes); break;//CRC16
                            case 4: crc = Crc32(bytes); break;//CRC32(1)
                            case 5: crc = calccrc32(bytes); break;//CRC32(2)
                            case 6: crc = nccitt(bytes); break;//NCCITT
                            case 7: crc = ccitt(bytes); break;//CCITT
                            case 8: crc = crc16_ccitt_false(bytes); break;//CCITT FALSE
                            default: break;
                        }
                        datablockcrc = datablockcrc + line + "\r\n::crc::0x" + crc.ToString("X8") + "\r\n";
                        bytes = null;
                    }
                }
                reader.Dispose();
                byte[] allbytes = new byte[dataallcrc.Length / 2];
                for (int i = 0; i < allbytes.Length; i++)
                {
                    allbytes[i] = Convert.ToByte(dataallcrc.Substring(i * 2, 2), 16);
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 1: crc = calccs(allbytes); break;//CHECKSUM
                    case 2: crc = CalculateCRC8(allbytes); break;//CRC8
                    case 3: crc = calccrc16(allbytes); break;//CRC16
                    case 4: crc = Crc32(allbytes); break;//CRC32(1)
                    case 5: crc = calccrc32(allbytes); break;//CRC32(2)
                    case 6: crc = nccitt(allbytes); break;//NCCITT
                    case 7: crc = ccitt(allbytes); break;//CCITT
                    case 8: crc = crc16_ccitt_false(allbytes); break;//CCITT FALSE
                    default: break;
                }
                datablockcrc = datablockcrc + "\r\n::allcrc::0x" + crc.ToString("X8") + "\r\n";
                File.WriteAllText(directoryPath + "\\file7.txt", datablockcrc);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "calculate block data crc done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "calculate block data crc error";
            }
        }
        /*private void hex_calc_allcrc(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string line = "";
                UInt32 crc = 0;

                string directoryPath = Path.GetDirectoryName(hexpath);
                line = File.ReadAllText(directoryPath + "\\file2.txt");
                line = line.Replace("\r\n", "");
                byte[] bytes = new byte[line.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 1: crc = calccs(bytes); break;//CHECKSUM
                    case 2: crc = CalculateCRC8(bytes); break;//CRC8
                    case 3: crc = calccrc16(bytes); break;//CRC16
                    case 4: crc = Crc32(bytes); break;//CRC32(1)
                    case 5: crc = calccrc32(bytes); break;//CRC32(2)
                    case 6: crc = nccitt(bytes); break;//NCCITT
                    case 7: crc = ccitt(bytes); break;//CCITT
                    case 8: crc = crc16_ccitt_false(bytes); break;//CCITT FALSE
                    default: break;
                }
                File.WriteAllText(directoryPath + "\\file6.txt", "0x" + crc.ToString("X8") + "\r\n" + line);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "calculate all data crc done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "calculate all data crc error";
            }
        }*/

        private void hex_bsd_crouse(string hexpath)
        {
            int d = 0;
            try
            {
                byte[] fileBytes = File.ReadAllBytes(hexpath);
                string hexdata = Encoding.UTF8.GetString(fileBytes);

                string directoryPath = Path.GetDirectoryName(hexpath);
                hexdata = hexdata.Replace(":", "");
                File.WriteAllText(directoryPath + "\\file1.txt", hexdata);
                /*=========================================================================*/
                string line = "";
                string hexdata2 = "";
                bool enterflag = false;
                hexdata = "";
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
                        hexdata2 = hexdata2.Replace("\r\n", "");
                        File.WriteAllText(directoryPath + "\\file2.txt", hexdata2);
                    }
                }
                reader.Dispose();
                /*=========================================================================*/
                line = "";
                string calclen = "";
                StreamReader reader1 = new StreamReader(directoryPath + "\\file2.txt");
                while ((line = reader1.ReadLine()) != null)
                {
                    calclen = calclen + "0x" + (line.Length / 2).ToString("X2") + "\r\n" + line + "\r\n";
                }
                File.WriteAllText(directoryPath + "\\file3.txt", calclen);
                reader1.Dispose();
                /*=========================================================================*/
                line = "";
                string line_1 = "";
                hexdata = "";
                hexdata2 = "";

                StreamReader reader2 = new StreamReader(hexpath);
                while ((line = reader2.ReadLine()) != null)
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
                        if (hexdata != "")
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
                reader2.Dispose();
                /*=========================================================================*/
                line = "";
                string lineid = "";
                hexdata = "";
                hexdata2 = "";
                UInt32 Hadd = 0, Ladd = 0;
                calclen = "";

                StreamReader reader3 = new StreamReader(directoryPath + "\\file4.txt");
                while ((line = reader3.ReadLine()) != null)
                {
                    byte ttline = byte.Parse(line.Substring(8, 2));
                    lineid = line.Substring(0, 2);
                    if (lineid == "::")
                    {
                        if (ttline == 1)
                        {
                            hexdata2 = hexdata2 + hexdata;
                            File.WriteAllText(directoryPath + "\\file5.txt", hexdata2);
                            break;
                        }
                        if (Hadd + 1 == Convert.ToUInt32(line.Substring(10, 4), 16) && Ladd == 0xFFF0)
                        {
                            hexdata2 = hexdata2 + hexdata;
                        }
                        else if (hexdata2 != "")
                        {
                            hexdata2 = hexdata2 + hexdata + "\r\n";
                        }
                        Hadd = Convert.ToUInt32(line.Substring(10, 4), 16);
                        hexdata = reader3.ReadLine();
                        line = reader3.ReadLine();
                        Ladd = Convert.ToUInt32(line.Substring(4, 4), 16);
                    }
                }
                reader3.Dispose();
                /*=========================================================================*/
                line = "";
                string Linestart = "";
                int i = 0, numofcrc = 0;
                string frmhexdata = "", frmhexdata2 = "", frmhexdata3 = "";


                StreamReader reader4 = new StreamReader(directoryPath + "\\file5.txt");
                int frmLen = (short)((Convert.ToInt16(textBox10.Text, 16) - 1 - numofcrc)*2);
                string SID = textBox11.Text;
                byte frmcnt = Convert.ToByte(textBox12.Text);

                while ((line = reader4.ReadLine()) != null)
                {
                    Linestart = line.Substring(0, 2);
                    if (Linestart != "0x")
                    {
                        while (line.Length >= (frmLen))
                        {
                            frmhexdata = SID + frmcnt.ToString("X2") + line.Substring(0, (frmLen - 2));
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length / 2).ToString("X4") + frmhexdata + "\r\n";
                            line = line.Remove(0, (frmLen - 1));
                            frmcnt++;
                            if (frmcnt == 0x15) d++;
                        }
                        if (line.Length < frmLen && line.Length != 0)
                        {
                            frmhexdata = SID + frmcnt.ToString("X2") + line;
                            frmhexdata2 = frmhexdata2 + (frmhexdata.Length / 2).ToString("X4") + frmhexdata + "\r\n";
                            line = "";
                        }
                        if (line.Length == 0)
                            frmhexdata2 = frmhexdata2 + "\r\n\r\n";
                        frmhexdata3 = frmhexdata3 + frmhexdata2;
                        frmhexdata2 = "";
                        frmcnt = Convert.ToByte(textBox12.Text);
                    }
                }
                reader4.Dispose();
                File.WriteAllText(directoryPath + "\\file6.txt", frmhexdata3);
                /*=========================================================================*/
                line = "";
                UInt32 crc = 0;
                string datablockcrc = "", dataallcrc = "";

                StreamReader reader5 = new StreamReader(directoryPath + "\\file5.txt");
                while ((line = reader5.ReadLine()) != null)
                {
                    if (line.Substring(0, 2) != "0x")
                    {
                        byte[] bytes = new byte[line.Length / 2];
                        dataallcrc = dataallcrc + line;
                        for (i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
                        }
                        crc = calccs(bytes); //CHECKSUM
                        
                        datablockcrc = datablockcrc + line + "\r\n::crc::0x" + crc.ToString("X8") + "\r\n";
                        bytes = null;
                    }
                }
                reader5.Dispose();
                byte[] allbytes = new byte[dataallcrc.Length / 2];
                for (i = 0; i < allbytes.Length; i++)
                {
                    allbytes[i] = Convert.ToByte(dataallcrc.Substring(i * 2, 2), 16);
                }
                crc = calccs(allbytes); //CHECKSUM
                
                datablockcrc = datablockcrc + "\r\n::allcrc::0x" + crc.ToString("X8") + "\r\n";
                File.WriteAllText(directoryPath + "\\file7.txt", datablockcrc);
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "calculate block data crc done";
                this.Refresh();
                /*=========================================================================*/
                /*=========================================================================*/
                /*=========================================================================*/
                /*=========================================================================*/
                /*=========================================================================*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(d.ToString("X2"));
            }
        }




        private void hex_print_terminal(string hexpath)
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
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "print in terminal error";
            }
        }
        private void hex_delete_allfiles(string hexpath)
        {
            lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
            try
            {
                string directoryPath = Path.GetDirectoryName(hexpath);
                File.Delete(directoryPath + "\\file1.txt");
                File.Delete(directoryPath + "\\file2.txt");
                File.Delete(directoryPath + "\\file3.txt");
                File.Delete(directoryPath + "\\file4.txt");
                File.Delete(directoryPath + "\\file5.txt");
                //File.Delete(directoryPath + "\\file6.txt");
                File.Delete(directoryPath + "\\file7.txt");
                File.Delete(directoryPath + "\\file8.txt");

                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "delete all files done";
                this.Refresh();
            }
            catch (Exception ex)
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
            s19btn1.Cursor = Cursors.WaitCursor;
            s19btn1.Enabled = false;
            string fileName = null;
            OpenFileDialog Openn = new OpenFileDialog();
            Openn.Title = "انتخاب فایل";
            Openn.Filter = extend;
            if (Openn.ShowDialog() == DialogResult.OK)
            {
                fileName = Openn.FileName.ToString();
                //ecomux(fileName);
            }
            s19btn1.Cursor = Cursors.Default;
            s19btn1.Enabled = true;
            global_filepath = fileName;
            return fileName;
        }
        static byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("طول رشته هگز باید زوج باشد.");
            }

            byte[] byteArray = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return byteArray;
        }
        //=================================================================
        //=================================================================
        // CALC CRC =======================================================
        //=================================================================
        private void crcbtn1_Click(object sender, EventArgs e)
        {
            string fpath = null, sout = null;
            int i = 0, siz = 0;
            byte cs = 0;
            byte[] areab;

            fpath = file_path("S19|*.s19|S28|*.s28|HEX|*.hex");
            if (fpath != null && fpath != string.Empty)
            {
                load_file(fpath);
                areab = get_byte_area();
                while (i < areab.Length)
                {
                    cs = (byte)(cs + areab[i]);
                    i++;
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
        private void crcbtn2_Click(object sender, EventArgs e)
        {
            try
            {
                string line = "";
                UInt32 crc = 0;

                if (textBox8.Text == null || textBox8.Text == string.Empty || comboBox2.SelectedIndex == 0)
                    return;
                lblshowresult.BackColor = Color.Yellow; lblshowresult.Text = "plz wait..."; this.Refresh();
                line = textBox8.Text;
                line = line.Replace("0x", "");
                line = line.Replace(" ", "");
                line = line.Replace(",", "");
                line = line.Replace("\r\n", "");
                byte[] bytes = new byte[line.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(line.Substring(i * 2, 2), 16);
                }
                switch (comboBox2.SelectedIndex)
                {
                    case 1: crc = calccs(bytes); break;             //CHECKSUM
                    case 2: crc = CalculateCRC8(bytes); break;      //CRC8
                    case 3: crc = calccrc16(bytes); break;          //CRC16
                    case 4: crc = Crc32(bytes); break;              //CRC32(1)
                    case 5: crc = calccrc32(bytes); break;          //CRC32(2)
                    case 6: crc = nccitt(bytes); break;             //NCCITT
                    case 7: crc = ccitt(bytes); break;              //CCITT
                    case 8: crc = crc16_ccitt_false(bytes); break;  //CCITT FALSE
                    default: break;
                }
                //MessageBox.Show("0x" + crc.ToString("X8"));
                textBox9.Text = "0x" + crc.ToString("X8");
                lblshowresult.BackColor = Color.LightGreen;
                lblshowresult.Text = "calculate txt data crc done";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblshowresult.BackColor = Color.Red;
                lblshowresult.Text = "calculate txt data crc error";
            }
        }
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
            UInt32 i;
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
        public UInt16 crc16_ccitt_false(byte[] array)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < array.Length; i++)
            {
                crc ^= (ushort)(array[i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) > 0)
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    else
                        crc <<= 1;
                }
            }
            return crc;
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
        //=================================================================
        // TERMINAL FUNCTION ===============================================
        //=================================================================
        private void btnterminal_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            globalterminal = null;
        }
        private void btninfo_Click(object sender, EventArgs e)
        {
            try
            {
                string info = "";
                int i = 1;

                textBox9.Clear();

                info = info + i++.ToString().PadLeft(3, '0') + ". " + "SPCO DENA AT ICN (CCITT)" + "\r\n";
                info = info + i++.ToString().PadLeft(3, '0') + ". " + "CROUSE LCCBM (CCITT)" + "\r\n";
                info = info + i++.ToString().PadLeft(3, '0') + ". " + "CROUSE CWC (CRC32(1))" + "\r\n";


                textBox9.Text = info;

            }
            catch(Exception ex)
            {

            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.Red,
                Color.Black,
                LinearGradientMode.Vertical);
            g.FillRectangle(brush, rect);
        }
    }
}
