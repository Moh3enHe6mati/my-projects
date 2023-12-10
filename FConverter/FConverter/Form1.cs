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
        ulong[] linelen = new ulong[20000];
        ulong[] datalen = new ulong[30000];
        ulong[] lineaddress = new ulong[2000000];
        byte[,] linedata = new byte[20000, 300];
        string global_filepath;
        ulong[] difflen = new ulong[20000];
        ulong[] startindex = new ulong[10];
        ulong linecnt = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(file_path());
            //MessageBox.Show(CalcCRC16(0xE0, frame).ToString("X2"));
            //MessageBox.Show(CalcCRC32(0xE0, frame).ToString("X2"));
            //MessageBox.Show(Nccitt(frame).ToString("X2"));//this is true
            load_file(file_path());
            write_txt_file();
            create_bin_file();
            write_data_2bin();
            read_bin_file();
        }
        //=================================================================
        byte read_bin_file()
        {
            string fpath;
            byte[] buffer = new byte[2000000];
            int siz = 0;
            byte len0 = 0, len1 = 0;
            byte crc1 = 0, crc2 = 0;
            ulong crc = 0;
            int x = 0;
            string str = null, allcrc = null;

            
            x = Convert.ToInt32(textBox4.Text, 16)-3;
            siz = (int)(Convert.ToInt32(textBox2.Text, 16) - Convert.ToInt32(textBox1.Text, 16));

            fpath = Path.GetDirectoryName(global_filepath);
            FileStream inbin = new FileStream(fpath + "\\1.bin", FileMode.Open, FileAccess.Read);
            BinaryReader binreader = new BinaryReader(inbin);
            FileStream outfram = new FileStream(fpath + "\\final.txt", FileMode.Create, FileAccess.Write);
            StreamWriter framWriter = new StreamWriter(outfram);

            while (siz > x)
            {
                byte[] byt = binreader.ReadBytes(x);
                siz -= x;
                str = BitConverter.ToString(byt);
                str = str.Replace("-", "");

                str = textBox5.Text + str;
                byte[] log = str2BytArry(str);
                crc = Nccitt(log);
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
                crc = Nccitt(log);
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
                if (type == "S0")
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

                }
                else if (type == "S1")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = ulong.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = linelen[linecnt] - 4;
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(8, (int)(2 * linelen[linecnt] - 4)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 3;//all len - address+crc
                }
                else if (type == "S2")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = ulong.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = linelen[linecnt] - 6;
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 6), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(10, (int)(2 * linelen[linecnt] - 6)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 4;//all len - address+crc
                }
                else if (type == "S3")
                {
                    linetype[linecnt] = type;
                    linelen[linecnt] = ulong.Parse(s19line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    datalen[linecnt] = linelen[linecnt] - 8;
                    lineaddress[linecnt] = ulong.Parse(s19line.Substring(4, 8), System.Globalization.NumberStyles.HexNumber);
                    lineb = strfrm2bytearray(s19line.Substring(12, (int)(2 * linelen[linecnt] - 8)));
                    for (int i = 0; i < lineb.Length; i++)
                    {
                        linedata[linecnt, i] = lineb[i];
                    }
                    difflen[linecnt] = 5;//all len - address+crc
                }
                else if (type == "S9")
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
                }
                else { }
                s19line = null;
                lineb = null;
                linecnt++;
            }
            startindex[0] = lineaddress[1];
            startindex[1] = lineaddress[linecnt - 2];
            if (linetype[linecnt - 2] == "S1")
                startindex[2] = linelen[linecnt - 2] - 3;
            else if (linetype[linecnt - 2] == "S2")
                startindex[2] = linelen[linecnt - 2] - 4;
            else if (linetype[linecnt - 2] == "S3")
                startindex[2] = linelen[linecnt - 2] - 5;
            return 0;
        }
        //=================================================================
        bool write_data_2bin()
        {
            string fpath;
            UInt32 i = 1;
            //byte[] data = new byte[1000];

            fpath = Path.GetDirectoryName(global_filepath);
            FileStream outbin = new FileStream(fpath + "\\1.bin", FileMode.Open, FileAccess.Write);
            BinaryWriter binwriter = new BinaryWriter(outbin);
            //for (ulong i = 1; i < linecnt; i++)
            //i = (UInt32)(Convert.ToInt32(textBox1.Text, 16));
            while (lineaddress[i] < (ulong)(Convert.ToInt32(textBox2.Text, 16)))
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
            binwriter.Close();
            return true;
        }
        //=================================================================
        bool create_bin_file()
        {
            string fpath;
            byte[] free = { 0xFF };
            ulong i = 0, endaddress = 0;
            ulong ul = 0;
            uint flashblock = 0;

            /*if (textBox3.Text != string.Empty)
                flashblock = uint.Parse(textBox3.Text, System.Globalization.NumberStyles.HexNumber);
            ul = (startindex[1] + startindex[2]) % flashblock;
            if (ul == 0)
            {
                endaddress = startindex[1] + startindex[2];
            }
            else
            {
                endaddress = (((startindex[1] + startindex[2]) / flashblock) + 1) * flashblock;
            }*/
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
        byte write_txt_file()
        {
            string fpath, S1 = "";
            int i = 0;

            fpath = Path.GetDirectoryName(global_filepath);
            while (linelen[i] != 0)
            {
                for (int j = 0; j < (int)(linelen[i] - difflen[i]); j++)
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
                        File.AppendAllText(fpath + "\\1.txt", S1 + "\r\n");
                }
                S1 = "";
                i++;
            }
            return 0;
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
        string file_path()
        {
            btnGo.Cursor = Cursors.WaitCursor;
            btnGo.Enabled = false;
            string fileName = null;
            OpenFileDialog Openn = new OpenFileDialog();
            Openn.Title = "انتخاب فایل";
            Openn.Filter = "S19|*.s19|S28|*.s28";
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
        bool clear_allvalue()
        {
            int a = 0, b = 0;
            for (a = 0; a < 20000; a++)
            {
                for (b = 0; b < 300; b++)
                    linedata[a, b] = 0;
                linetype[a] = "";
                linelen[a] = 0;
                lineaddress[a] = 0;
                difflen[a] = 0;
            }
            return true;
        }
        //=================================================================
        //=================================================================
        private UInt16 CalcCRC16(int Size, byte[] pData)
        {
            UInt16 CRCbuffer = 0;
            UInt16 ByteCounter = 0;
            byte BitCounter = 0;

            CRCbuffer = 0xFFFF;

            for (ByteCounter = 0; ByteCounter < Size; ByteCounter++)
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
        ulong CalcCRC32(int Size, byte[] pData)
        {
            UInt16 i;
            byte BitCounter;
            ulong Checksum32 = 0xFFFFFFFF;

            for (i = 0; i < Size; i++)
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
        private uint Nccitt(byte[] array)
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
    }
}
