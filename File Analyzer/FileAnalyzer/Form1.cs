using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileAnalyzer
{
    public partial class Form1 : Form
    {
        string global_filepath;

        public Form1()
        {
            InitializeComponent();
        }
        /* form customize ===========================================
         ============================================================*/
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 50;
            
            path.AddArc(0, 0, radius, radius, 180, 90); // گوشه بالا-چپ
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // گوشه بالا-راست
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // گوشه پایین-راست
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // گوشه پایین-چپ
            this.Region = new Region(path);

            //btnConvDown.Text = "Click Me";
            //btnConvDown.Location = new Point(100, 100);
            CDbtn1.Size = new Size(100, 30);
            CDbtn1.BackColor = Color.FromArgb(0x2E,0x00,0xA0);
            CDbtn1.ForeColor = Color.White;
            CDbtn1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            //btnConvDown.CornerRadius = 15; // لبه های گرد
            //btnConvDown.HoverColor = Color.FromArgb(135, 206, 250); // LightSkyBlue
        }

        /* titlebar control =========================================
         ============================================================*/
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /* tab control ================================================
         ==============================================================*/
        private void btnConvDown_Click(object sender, EventArgs e)
        {

            btnConvDown.BackColor = Color.FromArgb(35, 35, 79);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            
            btnConvDown.Size = new System.Drawing.Size(140, 25);
            btninfo.Size = new System.Drawing.Size(115, 25);

            CDpanel1.Visible = true;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btns28_Click(object sender, EventArgs e)
        {
            btns28.BackColor = Color.FromArgb(35, 35, 79);
            btnConvDown.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            CDpanel1.Visible = false;
            s28panel.Visible = true;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btnhex_Click(object sender, EventArgs e)
        {
            btnhex.BackColor = Color.FromArgb(35, 35, 79);
            btnConvDown.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            CDpanel1.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = true;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btnbin_Click(object sender, EventArgs e)
        {
            btnbin.BackColor = Color.FromArgb(35, 35, 79);
            btnConvDown.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            CDpanel1.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = true;
            infopanel.Visible = false;
        }
        private void btninfo_Click(object sender, EventArgs e)
        {
            btninfo.BackColor = Color.FromArgb(35, 35, 79);
            btnConvDown.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);

            btnConvDown.Size = new System.Drawing.Size(115, 25);
            btninfo.Size = new System.Drawing.Size(140, 25);

            CDpanel1.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = true;
        }


        /* s19 function ===========================================
         ==============================================================*/
        private void CDbtn1_Click(object sender, EventArgs e)
        {
            global_filepath = LoadFile();
            ConvertS19ToFile(global_filepath);
            ExtractDataOnly();
            SplitHexFile(0x202);//frm len is 0x204
            AddHexCounterToFile(1);//start frm counter
            AddHexPrefixToFile("36");//frm sid
            //AddCheckSumToFile();//calc frm cs
            AddLengthPrefixToFile();//add frm len
            CalculateAndSaveFileCRC();//calc crc
            //ExtractAddressesFromFile01();
            ExtractAddressesWithJumps();
            CreateAndWriteBinaryFile();
            ScanAndExportNonFFBlocks();
        }
        /*========================================================*/
        public static bool ConvertS19ToFile(string inputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath) || !File.Exists(inputFilePath))
            {
                Console.WriteLine("Invalid file path or file does not exist.");
                return false;
            }

            try
            {
                // گرفتن پوشه فایل ورودی
                string folderPath = Path.GetDirectoryName(inputFilePath);

                // ساخت مسیر خروجی در همان پوشه
                string outputFilePath = Path.Combine(folderPath, "file01.txt");

                // خواندن خطوط فایل ورودی
                string[] lines = File.ReadAllLines(inputFilePath);

                // نوشتن در فایل خروجی
                File.WriteAllLines(outputFilePath, lines);

                Console.WriteLine($"File saved successfully to: {outputFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
                return false;
            }
        }
        /*========================================================*/
        public void ExtractDataOnly()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file01.txt");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: file01.txt not found in folder: {sRecordFolderPath}");
                return;
            }

            try
            {
                List<string> dataList = new List<string>();

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("S"))
                        continue;

                    char recordType = line[1];

                    // فقط خطوط S1, S2, S3 شامل داده هستند
                    if (recordType != '1' && recordType != '2' && recordType != '3')
                        continue;

                    // محاسبه طول آدرس براساس نوع رکورد
                    int addressLength = recordType == '1' ? 4 :
                                        recordType == '2' ? 6 :
                                        recordType == '3' ? 8 : 0;

                    // header = Sx(2) + Count(2) + Address(addressLength*2)
                    int headerLength = 2 + 2 + addressLength;

                    // CRC آخر خط = 2 کاراکتر
                    int crcLength = 2;

                    int dataStartIndex = headerLength;
                    int dataEndIndex = line.Length - crcLength;

                    if (dataEndIndex <= dataStartIndex)
                        continue;

                    string dataOnly = line.Substring(dataStartIndex, dataEndIndex - dataStartIndex);
                    dataList.Add(dataOnly);
                }

                string outputFilePath = Path.Combine(sRecordFolderPath, "file02.txt");
                File.WriteAllLines(outputFilePath, dataList);

                Console.WriteLine($"Processed data saved to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void SplitHexFile(int bytesPerLine)
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file02.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file03.txt");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: file02.txt not found in folder: {sRecordFolderPath}");
                return;
            }
            try
            {
                // خواندن تمام خطوط و ترکیب آن‌ها به یک رشته Hex واحد
                StringBuilder fullHexData = new StringBuilder();
                foreach (var line in File.ReadAllLines(inputPath))
                {
                    fullHexData.Append(line.Trim());
                }
                string hexString = fullHexData.ToString();
                //bytesPerLine = 0x201;
                int charsPerLine = bytesPerLine * 2; // هر بایت = 2 کاراکتر Hex
                List<string> outputLines = new List<string>();

                for (int i = 0; i < hexString.Length; i += charsPerLine)
                {
                    if (i + charsPerLine > hexString.Length)
                    {
                        // اگر بیشتر از طول نبود، فقط باقی‌مانده رو بگیر
                        outputLines.Add(hexString.Substring(i));
                    }
                    else
                    {
                        outputLines.Add(hexString.Substring(i, charsPerLine));
                    }
                }

                // نوشتن در فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);

                Console.WriteLine($"Split data saved to: {outputFilePath}");
                Console.WriteLine($"Total lines written: {outputLines.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void AddHexCounterToFile(int startValue = 0)
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file03.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file04.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file03.txt not found.");
                return;
            }
            try
            {
                List<string> outputLines = new List<string>();

                byte counter = (byte)startValue; // کانتر با مقدار شروع کاربر

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    // اضافه کردن کانتر به صورت Hex دو رقمی
                    string hexCounter = counter.ToString("X2"); // مثل "0A" یا "FF"

                    // ساخت خط جدید: [counter][data]
                    string newLine = hexCounter + line.Trim();

                    outputLines.Add(newLine);

                    // افزایش کانتر (خودکار wrap around به دلیل نوع byte)
                    counter++;
                }
                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);

                Console.WriteLine($"Total lines processed: {outputLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void AddHexPrefixToFile(string prefixHex)
        {
            if (string.IsNullOrWhiteSpace(prefixHex) || prefixHex.Length != 2)
            {
                Console.WriteLine("Error: Prefix must be a 2-character hex string (e.g., 'A5').");
                return;
            }
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file04.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file05.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file04.txt not found.");
                return;
            }

            try
            {
                List<string> outputLines = new List<string>();

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    string trimmedLine = line.Trim();

                    // اضافه کردن پیشوند به ابتدای خط
                    string newLine = prefixHex + trimmedLine;

                    outputLines.Add(newLine);
                }

                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);

                Console.WriteLine($"Total lines processed: {outputLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void AddCheckSumToFile()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file05.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file06.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file05.txt not found.");
                return;
            }

            try
            {
                List<string> outputLines = new List<string>();

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    string trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine)) continue;

                    // تبدیل رشته Hex به آرایه بایت
                    byte[] bytes = HexStringToByteArray(trimmedLine);

                    // محاسبه CheckSum: جمع تمام بایت‌ها و معکوس کردن
                    byte sum = 0;
                    foreach (byte b in bytes)
                    {
                        sum += b;
                    }

                    byte checkSum = (byte)(-sum); // Two's complement
                                                  // یا استفاده از ~(sum - 1) یا (~sum + 1) برای بعضی استانداردها

                    // تبدیل CheckSum به رشته Hex دو کاراکتری
                    string checkSumHex = checkSum.ToString("X2");

                    // اضافه کردن CheckSum به انتهای خط
                    string newLine = trimmedLine + checkSumHex;

                    outputLines.Add(newLine);
                }

                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);

                Console.WriteLine($"Total lines processed: {outputLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void AddLengthPrefixToFile()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file05.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file07.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file06.txt not found.");
                return;
            }

            try
            {
                List<string> outputLines = new List<string>();

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    string trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine)) continue;

                    // محاسبه طول داده به صورت بایت
                    int byteCount = trimmedLine.Length / 2;

                    // تبدیل به دو بایت Big Endian
                    byte[] lengthBytes = new byte[2];
                    lengthBytes[0] = (byte)((byteCount >> 8) & 0xFF); // High byte
                    lengthBytes[1] = (byte)(byteCount & 0xFF);       // Low byte

                    // تبدیل به رشته Hex 4 کاراکتری
                    string lengthHex = lengthBytes[0].ToString("X2") + lengthBytes[1].ToString("X2");

                    // اضافه کردن طول به ابتدای خط
                    string newLine = lengthHex + trimmedLine;

                    outputLines.Add(newLine);
                }

                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);

                Console.WriteLine($"Total lines processed: {outputLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void CalculateAndSaveFileCRC()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file03.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file08CRC.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file03.txt not found.");
                return;
            }

            try
            {
                // خواندن تمام خطوط و ترکیب آن‌ها به یک رشته Hex واحد
                StringBuilder fullHexData = new StringBuilder();
                foreach (var line in File.ReadAllLines(inputPath))
                {
                    fullHexData.Append(line.Trim());
                }

                string hexString = fullHexData.ToString();

                if (string.IsNullOrEmpty(hexString))
                {
                    Console.WriteLine("Error: No valid hex data found in file03.txt.");
                    return;
                }

                // تبدیل Hex String به آرایه بایت
                byte[] dataBytes = HexStringToByteArray(hexString);

                // محاسبه CRC-32
                uint crc = Crc32(dataBytes);

                // تبدیل CRC به رشته Hex با 8 کاراکتر (مثل AABBCCDD)
                string crcHex = crc.ToString("X8");

                // ذخیره CRC در فایل
                File.WriteAllText(outputFilePath, crcHex);

                Console.WriteLine($"CRC32 calculated: {crcHex}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void ExtractAddressesFromFile01()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file01.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file09.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file01.txt not found.");
                return;
            }

            try
            {
                List<string> addressLines = new List<string>();

                foreach (var line in File.ReadAllLines(inputPath))
                {
                    string trimmedLine = line.Trim();

                    if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.StartsWith("S"))
                        continue;

                    char recordType = trimmedLine.Length > 1 ? trimmedLine[1] : '0';

                    int addressLengthBytes = 0;

                    switch (recordType)
                    {
                        case '1': addressLengthBytes = 2; break; // 16-bit Address -> 2 بایت → 4 کاراکتر
                        case '2': addressLengthBytes = 3; break; // 24-bit Address → 3 بایت → 6 کاراکتر
                        case '3': addressLengthBytes = 4; break; // 32-bit Address → 4 بایت → 8 کاراکتر
                        default:
                            continue; // فقط خطوط شامل داده رو پردازش می‌کنیم
                    }

                    int addressStartIndex = 2 + 2; // Sx(2) + Length(2)

                    // محاسبه طول آدرس به صورت کاراکتر
                    int addressLengthChars = addressLengthBytes * 2;

                    if (addressStartIndex + addressLengthChars > trimmedLine.Length)
                        continue;

                    string rawAddressHex = trimmedLine.Substring(addressStartIndex, addressLengthChars);

                    // تبدیل به 4 بایتی (uint)
                    uint addressValue = 0;

                    // اگر کمتر از 8 کاراکتر بود، با صفر پر کنیم
                    string paddedHex = rawAddressHex.PadLeft(8, '0');

                    bool success = uint.TryParse(paddedHex, System.Globalization.NumberStyles.HexNumber, null, out addressValue);

                    if (!success)
                        continue;

                    // ذخیره آدرس به صورت Hex 8 کاراکتری
                    string fullAddressHex = addressValue.ToString("X8"); // مثل "0000000F"

                    addressLines.Add(fullAddressHex);
                }

                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, addressLines);

                Console.WriteLine($"Total addresses extracted: {addressLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void ExtractAddressesWithJumps()
        {
            uint currentAddress;
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file01.txt");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file09.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file01.txt not found.");
                return;
            }

            try
            {
                List<string> addressLines = new List<string>();
                uint previousEndAddress = 0;
                bool firstLine = true;

                // خواندن تمام خطوط برای محاسبه ماکزیمم طول
                string[] allLines = File.ReadAllLines(inputPath);

                int maxDataLength = 0;

                foreach (var line in allLines)
                {
                    string trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.StartsWith("S"))
                        continue;

                    char recordType = trimmedLine.Length > 1 ? trimmedLine[1] : '0';

                    int addressLengthBytes = 0;
                    switch (recordType)
                    {
                        case '1': addressLengthBytes = 2; break;
                        case '2': addressLengthBytes = 3; break;
                        case '3': addressLengthBytes = 4; break;
                        default:
                            continue;
                    }

                    int dataStartIndex = 2 + 2 + addressLengthBytes * 2;
                    int dataEndIndex = trimmedLine.Length - 2; // حذف CRC

                    if (dataEndIndex <= dataStartIndex)
                        continue;

                    int dataCharCount = dataEndIndex - dataStartIndex;
                    int dataByteCount = dataCharCount / 2;

                    if (dataByteCount > maxDataLength)
                    {
                        maxDataLength = dataByteCount;
                    }
                }

                Console.WriteLine($"Max Data Length: {maxDataLength} bytes");

                // استخراج آدرس‌ها
                foreach (var line in allLines)
                {
                    string trimmedLine = line.Trim();

                    if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.StartsWith("S"))
                        continue;

                    char recordType = trimmedLine.Length > 1 ? trimmedLine[1] : '0';

                    int addressLengthBytes = 0;
                    switch (recordType)
                    {
                        case '1': addressLengthBytes = 2; break;
                        case '2': addressLengthBytes = 3; break;
                        case '3': addressLengthBytes = 4; break;
                        default:
                            continue;
                    }

                    int addressStartIndex = 2 + 2; // Sx(2) + Length(2)
                    int addressLengthChars = addressLengthBytes * 2;

                    if (addressStartIndex + addressLengthChars > trimmedLine.Length)
                        continue;

                    string rawAddressHex = trimmedLine.Substring(addressStartIndex, addressLengthChars);
                    string paddedHex = rawAddressHex.PadLeft(8, '0');

                    if (!uint.TryParse(paddedHex, System.Globalization.NumberStyles.HexNumber, null, out currentAddress))
                        continue;

                    // محاسبه آدرس پایانی با توجه به maxDataLength
                    uint expectedNextAddress = currentAddress + (uint)maxDataLength;

                    // اضافه کردن دو خط خالی اگر پرش آدرس داشتیم
                    if (!firstLine && currentAddress != previousEndAddress)
                    {
                        addressLines.Add(string.Empty); // خط خالی ۱
                        addressLines.Add(string.Empty); // خط خالی ۲
                    }

                    // اضافه کردن آدرس فعلی
                    addressLines.Add(currentAddress.ToString("X8")); // مثل "0000000F"

                    // به روز کردن آدرس قبلی
                    previousEndAddress = expectedNextAddress;
                    firstLine = false;
                }

                // ذخیره نتیجه در فایل
                File.WriteAllLines(outputFilePath, addressLines);

                Console.WriteLine($"Total addresses extracted: {addressLines.Count}");
                Console.WriteLine($"File saved successfully to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void CreateAndWriteBinaryFile()
        {
            uint currentAddress = 0;
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "file01.txt");
            string outputPath = Path.Combine(sRecordFolderPath, "data.bin");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputPath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file01.txt not found.");
                return;
            }

            try
            {
                uint binlen = 0;
                bool lastAddressFound = false;

                // --- مرحله ۱: پیدا کردن آخرین آدرس و طول برای محاسبه binlen ---
                foreach (var line in File.ReadLines(inputPath))
                {
                    string trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.StartsWith("S"))
                        continue;

                    char recordType = trimmedLine.Length > 1 ? trimmedLine[1] : '0';

                    int addressLengthBytes = 0;
                    switch (recordType)
                    {
                        case '1': addressLengthBytes = 2; break;
                        case '2': addressLengthBytes = 3; break;
                        case '3': addressLengthBytes = 4; break;
                        default:
                            continue;
                    }

                    int addressStartIndex = 2 + 2; // Sx(2) + Length(2)
                    int addressLengthChars = addressLengthBytes * 2;

                    if (addressStartIndex + addressLengthChars > trimmedLine.Length)
                        continue;

                    string rawAddressHex = trimmedLine.Substring(addressStartIndex, addressLengthChars);
                    string paddedHex = rawAddressHex.PadLeft(8, '0');

                    if (!uint.TryParse(paddedHex, System.Globalization.NumberStyles.HexNumber, null, out currentAddress))
                        continue;

                    // محاسبه تعداد بایت داده
                    int dataStartIndex = addressStartIndex + addressLengthChars;
                    int dataEndIndex = trimmedLine.Length - 2; // بدون CRC

                    if (dataEndIndex <= dataStartIndex)
                        continue;

                    int dataByteCount = (dataEndIndex - dataStartIndex) / 2;

                    // به روز کردن binlen
                    binlen = currentAddress + (uint)dataByteCount;
                    lastAddressFound = true;
                }

                if (!lastAddressFound)
                {
                    Console.WriteLine("Error: No valid records with address found in file01.txt");
                    return;
                }

                Console.WriteLine($"Total binary length: 0x{binlen:X8} bytes");

                // --- مرحله ۲: ساخت فایل data.bin با پرشور FF ---
                using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    fs.SetLength(binlen); // تنظیم طول فایل
                    byte[] buffer = new byte[1024];
                    for (int i = 0; i < buffer.Length; i++)
                        buffer[i] = 0xFF;

                    long remaining = binlen;
                    while (remaining > 0)
                    {
                        int bytesToWrite = (int)Math.Min(remaining, buffer.Length);
                        fs.Write(buffer, 0, bytesToWrite);
                        remaining -= bytesToWrite;
                    }
                }

                Console.WriteLine("Binary file created and filled with 0xFF.");

                // --- مرحله ۳: نوشتن داده‌ها در آدرس‌های مربوطه ---
                using (var fs = new FileStream(outputPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    foreach (var line in File.ReadLines(inputPath))
                    {
                        string trimmedLine = line.Trim();
                        if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.StartsWith("S"))
                            continue;

                        char recordType = trimmedLine[1];

                        int addressLengthBytes = 0;
                        switch (recordType)
                        {
                            case '1': addressLengthBytes = 2; break;
                            case '2': addressLengthBytes = 3; break;
                            case '3': addressLengthBytes = 4; break;
                            default:
                                continue;
                        }

                        int addressStartIndex = 2 + 2; // Sx(2) + Length(2)
                        int addressLengthChars = addressLengthBytes * 2;

                        if (addressStartIndex + addressLengthChars > trimmedLine.Length)
                            continue;

                        string rawAddressHex = trimmedLine.Substring(addressStartIndex, addressLengthChars);
                        string paddedHex = rawAddressHex.PadLeft(8, '0');

                        if (!uint.TryParse(paddedHex, System.Globalization.NumberStyles.HexNumber, null, out currentAddress))
                            continue;

                        // محاسبه موقعیت داده و طول
                        int dataStartIndex = addressStartIndex + addressLengthChars;
                        int dataEndIndex = trimmedLine.Length - 2; // بدون CRC

                        if (dataEndIndex <= dataStartIndex)
                            continue;

                        string dataHex = trimmedLine.Substring(dataStartIndex, dataEndIndex - dataStartIndex);

                        // تبدیل داده Hex به بایت‌ها
                        byte[] data = HexStringToByteArray(dataHex);

                        // نوشتن داده در آدرس مربوطه
                        fs.Seek(currentAddress, SeekOrigin.Begin);
                        fs.Write(data, 0, data.Length);
                    }
                }

                Console.WriteLine($"Binary data written successfully to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        public void ScanAndExportNonFFBlocks()
        {
            string sRecordFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(sRecordFolderPath, "data.bin");
            string outputFilePath = Path.Combine(sRecordFolderPath, "file10.txt");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputFilePath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: data.bin not found.");
                return;
            }

            try
            {
                List<string> outputLines = new List<string>();
                int blockSize = 0x4000; // 16384 بایت
                bool firstBlock = true;

                using (FileStream fs = File.OpenRead(inputPath))
                {
                    byte[] buffer = new byte[blockSize];
                    long position = 0;

                    while (position < fs.Length)
                    {
                        int bytesRead = fs.Read(buffer, 0, (int)Math.Min(blockSize, fs.Length - position));

                        // فقط اولین 3 بایت رو چک می‌کنیم
                        bool hasValidData = false;
                        for (int i = 0; i < 16 && i < bytesRead; i++)
                        {
                            if (buffer[i] != 0xFF)
                            {
                                hasValidData = true;
                                break;
                            }
                        }

                        // اگر داده غیر از FF وجود داشت، کل بلاک رو به فایل اضافه کن
                        if (hasValidData)
                        {
                            // اضافه کردن دو خط خالی قبل از بلاک جدید (به جز اولین بلاک)
                            if (!firstBlock)
                            {
                                outputLines.Add(string.Empty);
                                outputLines.Add(string.Empty);
                            }

                            // تبدیل بلاک به رشته Hex
                            string hexLine = ByteArrayToHexString(buffer, bytesRead);
                            outputLines.Add(hexLine);

                            firstBlock = false;
                        }

                        position += blockSize;
                    }
                }

                // نوشتن فایل خروجی
                File.WriteAllLines(outputFilePath, outputLines);
                Console.WriteLine($"Exported {outputLines.Count} valid data blocks to: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }

        /* s28 function ===========================================
         ==============================================================*/


        /* hex function ===========================================
         ==============================================================*/
        private void hexbtnanalyz_Click(object sender, EventArgs e)
        {
            global_filepath = LoadFile();
            LoadHexFileAndSaveToFile01();
            CreateAndWrBinFile();
        }
        /*========================================================*/
        public void LoadHexFileAndSaveToFile01()
        {
            string folderPath = Path.GetDirectoryName(global_filepath);
            string outputFilePath = Path.Combine(folderPath, "file01.txt");
            try
            {
                // خواندن تمام خطوط فایل .hex
                List<string> lines = new List<string>();
                foreach (var line in File.ReadAllLines(global_filepath))
                {
                    lines.Add(line);
                }
                // نوشتن در فایل خروجی
                File.WriteAllLines(outputFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading/writing file: " + ex.Message, "Error");
            }
        }
        /*========================================================*/
        public void CreateAndWrBinFile()
        {
            string hexFolderPath = Path.GetDirectoryName(global_filepath);
            string inputPath = Path.Combine(hexFolderPath, "file01.txt");
            string outputPath = Path.Combine(hexFolderPath, "data.bin");

            Console.WriteLine("Input file: " + inputPath);
            Console.WriteLine("Output file: " + outputPath);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: file01.txt not found.");
                return;
            }

            try
            {
                uint binlen = 0;
                bool lastAddressFound = false;

                // --- مرحله ۱: پیدا کردن آخرین آدرس و محاسبه binlen ---
                foreach (var line in File.ReadAllLines(inputPath))
                {
                    if (string.IsNullOrWhiteSpace(line) || !line.StartsWith(":"))
                        continue;

                    if (line.Length < 11) // حداقل طول یک رکورد معتبر ":10010000..." = 11 کاراکتر
                        continue;

                    int byteCount = Convert.ToByte(line.Substring(1, 2), 16);
                    int address = Convert.ToUInt16(line.Substring(3, 4), 16);
                    int recordType = Convert.ToByte(line.Substring(7, 2), 16);

                    // فقط خطوط داده (record type == 0x00) قابل پردازش هستند
                    if (recordType != 0x00)
                        continue;

                    int dataCharCount = byteCount * 2;
                    int dataStartIndex = 9;
                    if (dataStartIndex + dataCharCount > line.Length)
                        continue;

                    binlen = (uint)(address + byteCount);
                    lastAddressFound = true;
                }

                if (!lastAddressFound)
                {
                    Console.WriteLine("Error: No valid data records with address found in file01.txt");
                    return;
                }

                Console.WriteLine($"Total binary length: 0x{binlen:X8} bytes");

                // --- مرحله ۲: ساخت فایل data.bin با پرشور FF ---
                using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    fs.SetLength(binlen); // تنظیم اندازه فایل
                    byte[] buffer = new byte[1024];
                    for (int i = 0; i < buffer.Length; i++)
                        buffer[i] = 0xFF;

                    long remaining = binlen;
                    while (remaining > 0)
                    {
                        int bytesToWrite = (int)Math.Min(remaining, buffer.Length);
                        fs.Write(buffer, 0, bytesToWrite);
                        remaining -= bytesToWrite;
                    }
                }

                Console.WriteLine("Binary file created and filled with 0xFF.");

                // --- مرحله ۳: نوشتن داده‌ها در آدرس‌های مربوطه ---
                using (var fs = new FileStream(outputPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    foreach (var line in File.ReadLines(inputPath))
                    {
                        if (string.IsNullOrWhiteSpace(line) || !line.StartsWith(":"))
                            continue;

                        if (line.Length < 11)
                            continue;

                        int byteCount = Convert.ToByte(line.Substring(1, 2), 16);
                        int address = Convert.ToUInt16(line.Substring(3, 4), 16);
                        int recordType = Convert.ToByte(line.Substring(7, 2), 16);

                        // فقط خطوط داده (record type == 0x00) قابل پردازش هستند
                        if (recordType != 0x00)
                            continue;

                        int dataCharCount = byteCount * 2;
                        int dataStartIndex = 9;

                        if (dataStartIndex + dataCharCount > line.Length)
                            continue;

                        string dataHex = line.Substring(dataStartIndex, dataCharCount);

                        // تبدیل Hex به بایت
                        byte[] dataBytes = HexStringToByteArray(dataHex);

                        // نوشتن داده در فایل باینری
                        fs.Seek(address, SeekOrigin.Begin);
                        fs.Write(dataBytes, 0, dataBytes.Length);
                    }
                }

                Console.WriteLine($"Binary data written successfully to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + ex.Message);
            }
        }
        /*========================================================*/
        /*========================================================*/
        /*========================================================*/
        /*========================================================*/
        /*========================================================*/





        /* crc function ===========================================
        ==============================================================*/
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
        /*========================================================*/
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
        /*========================================================*/
        UInt32 calccrc32(byte[] pData)
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
        /*========================================================*/
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
        /*========================================================*/
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
        /*========================================================*/
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
        /*========================================================*/
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
        /*========================================================*/
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
        /*========================================================*/
        private UInt32 calccs(byte[] array)
        {
            uint sum = 0;

            foreach (byte value in array)
            {
                sum += value;
            }
            return sum;
        }
        /* general function ===========================================
         ==============================================================*/
        /* general function ===========================================
         ==============================================================*/
        /* general function ===========================================
        ==============================================================*/
        public static string LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // تنظیم فیلتر پسوندها
            openFileDialog.Filter =
                "Supported Files (*.s19, *.s28, *.s37, *.hex, *.bin)|*.s19;*.s28;*.s37;*.hex;*.bin|" +
                "Motorola S-Record (*.s19, *.s28, *.s37)|*.s19;*.s28;*.s37|" +
                "Intel HEX (*.hex)|*.hex|" +
                "Binary Files (*.bin)|*.bin|" +
                "All Files (*.*)|*.*";

            // عنوان پنجره
            openFileDialog.Title = "Select a File to Load";

            // نمایش پنجره و بررسی اینکه آیا کاربر فایلی انتخاب کرد؟
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // خواندن تمام محتوای فایل (به صورت باینری یا متنی)
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    // می‌تونی این بایت‌ها رو برای پردازش بیشتر استفاده کنی
                    Console.WriteLine($"File loaded: {filePath}");
                    Console.WriteLine($"Size: {fileBytes.Length} bytes");
                    // بازگشت مسیر فایل (یا می‌توانی بایت‌ها را بازگردانی کنی)
                    return filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }

            return null; // اگر فایلی انتخاب نشد یا خطا داشت
        }
        /*========================================================*/
        string file_path(string extend)
        {
            string fileName = null;
            OpenFileDialog Openn = new OpenFileDialog();
            Openn.Title = "انتخاب فایل";
            Openn.Filter = extend;
            if (Openn.ShowDialog() == DialogResult.OK)
            {
                fileName = Openn.FileName.ToString();
                //ecomux(fileName);
            }
            global_filepath = fileName;
            return fileName;
        }
        /*========================================================*/
        private static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
        /*========================================================*/
        private string ByteArrayToHexString(byte[] bytes, int length)
        {
            char[] hexChars = "0123456789ABCDEF".ToCharArray();
            char[] result = new char[length * 2];

            for (int i = 0; i < length; i++)
            {
                int value = bytes[i];
                result[i * 2] = hexChars[value >> 4];
                result[i * 2 + 1] = hexChars[value & 0x0F];
            }

            return new string(result);
        }
        /*========================================================*/







    }
}
