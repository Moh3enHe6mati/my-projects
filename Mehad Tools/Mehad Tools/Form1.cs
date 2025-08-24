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
using System.Security;
using System.Globalization;
using static Mehad_Tools.Form1;

namespace Mehad_Tools
{
    public partial class Form1 : Form
    {
        private functions f;
        string selectedFilePath = null;
        string globalPath = null;
        string globalFolderPath = null;
        private HashSet<string> addedItems = new HashSet<string>();
        private List<string> filePathsArray = new List<string>(); // آرایه ذخیره مسیر فایل‌ها
        //=========================================================================================
        public Form1()
        {
            InitializeComponent();
        }
        


        //=========================================================================================
        private void First_Load(object sender, EventArgs e)
        {
            f = new functions(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Width = 600;
            this.Height = 400;
            tabControl1.Width = 576;
            tabControl1.Height = 340;
            
            // تنظیم double click event برای listBox1
            listBox1.DoubleClick += ListBox1_DoubleClick;
            
            // تست سریع X={4} functionality در startup
            // TestX4Functionality();
        }//first load form
        //=========================================================================================
        private void cleartemp_Click(object sender, EventArgs e)
        {
            resultlabel.Text = "Please Wait Clear Temp ...";
            resultlabel.BackColor = Color.Red;
            this.Refresh();
            f.cleartemp();
            f.clearout();
        }//clear temp content
        //=========================================================================================
        private void ChangeDics_Click_Click(object sender, EventArgs e)
        {
            resultlabel.Text = "Please Wait Change Dictionary ...";
            resultlabel.BackColor = Color.Red;
            this.Refresh();
            f.changedics();
        }
        //=========================================================================================
        private void convertbutton_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();
            if (converttextBox.Text == string.Empty)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "Input Data Invalid";
            }
            else
                f.converthexasciibin();
        }//convert hex ascii binary to each other
        //=========================================================================================
        private void convertclear_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            converttextBox.Clear();
            resultlabel.BackColor = Color.GreenYellow;
            resultlabel.Text = "Clear Convert Textbox";
            this.Refresh();
        }//clear convert text box
        //=========================================================================================
        private void obdconnector_Click(object sender, EventArgs e)
        {
            converttextBox.Clear();
            converttextBox.Text = f.obdconnector();
        }//print OBD Connector Pinout
        //=========================================================================================
        private void ecuid_Click(object sender, EventArgs e)
        {
            converttextBox.Clear();
            converttextBox.Text = f.ecuidsupport();
        }//all ecu ID supported
        //=========================================================================================
        private void textBox7F_TextChanged(object sender, EventArgs e)
        {
            converttextBox.Clear();
            converttextBox.Text = f.list7F();
        }//print 7f response description
        //=========================================================================================
        private void initpinbtn_Click(object sender, EventArgs e)
        {
            converttextBox.Clear();
            converttextBox.Text = f.initialpin();
        }//print all pin initial value
        //=========================================================================================
        private void buttonsctosim_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();

            // انتخاب پوشه حاوی فایل‌های .jc
            string folderPath = SelectFolderPath();
            if (string.IsNullOrEmpty(folderPath))
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "No folder selected";
                return;
            }

            // پیدا کردن فایل‌های .jc
            string[] jcFiles = Directory.GetFiles(folderPath, "*.jc", SearchOption.AllDirectories);
            if (jcFiles.Length == 0)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "No .jc files found";
                return;
            }

            // انتخاب مسیر ذخیره برای هر دو فایل
            string outputDir = SelectSaveDirectory();
            if (string.IsNullOrEmpty(outputDir))
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "No save directory selected";
                return;
            }

            // پردازش فایل‌ها و استخراج خطوط initial
            List<string> initialLines = ProcessJcFiles(jcFiles, outputDir);
            if (initialLines.Count == 0)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "No initial( lines found";
                return;
            }

            try
            {
                // ذخیره فایل اول (scriptosim.frm)
                string frmPath = Path.Combine(outputDir, "scriptosim.frm");
                File.WriteAllLines(frmPath, initialLines);
                
                resultlabel.BackColor = Color.GreenYellow;
                resultlabel.Text = $"Saved files to: {outputDir}";
            }
            catch (Exception ex)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "Error saving files: " + ex.Message;
            }

        }//convert script to simulator
        //=========================================================================================
        
        // متد انتخاب پوشه
        private string SelectFolderPath()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder containing .jc files";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
                return null;
            }
        }

        // متد انتخاب مسیر ذخیره فایل‌ها
        private string SelectSaveDirectory()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select directory to save both files";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
                return null;
            }
        }

        // متد تشخیص نوع پروتکل بر اساس initial ها
        private string DetectProtocolType(List<string> initialLines)
        {
            foreach (string line in initialLines)
            {
                if (line.Contains("initial(") && line.Contains("57600"))
                {
                    return "CAN"; // CAN protocol detected (any initial with 57600)
                }
            }
            return "KWP"; // Default to KWP
        }

        // متد تشخیص اینکه آیا فریم CAN است یا نه
        private bool IsCANFrame(string line)
        {
            string cleanedLine = CleanLine(line);
            
            // بررسی شروع با CAN({
            if (cleanedLine.Contains("CAN({"))
                return true;
            
            // بررسی بایت اول 0x00 (فقط برای send)
            if (cleanedLine.Contains("send({0x00") || cleanedLine.Contains("send({00"))
                return true;
                
            return false;
        }

        // متد تشخیص اینکه آیا فریم CAN است بر اساس محتوای آرایه
        private bool IsCANFrameByContent(string byteArray)
        {
            if (string.IsNullOrEmpty(byteArray))
                return false;
            
            // اگر بایت اول 0x00 است، CAN است
            string cleaned = byteArray.Replace("0x", "").Replace(" ", "").Replace("{", "").Replace("}", "");
            string[] bytes = cleaned.Split(',');
            
            if (bytes.Length > 0)
            {
                string firstByte = bytes[0].Trim();
                if (firstByte.Equals("00", StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            
            return false;
        }

        // متد بررسی فریم‌های GOTO CAN MODE که نباید در sim استفاده شوند
        private bool IsGotoCANModeFrame(string line)
        {
            string cleanedLine = CleanLine(line).Replace(" ", "").Replace("0x", "");
            
            // بررسی الگوی شروع: 55,47,4F,54,4F,43,41,4E,4D,4F,44
            string gotoPattern = "55,47,4F,54,4F,43,41,4E,4D,4F,44";
            string gotoPatternNoComma = "55474F544F43414E4D4F44";
            
            return cleanedLine.Contains(gotoPattern) || cleanedLine.Contains(gotoPatternNoComma);
        }

        // کلاس برای ذخیره اطلاعات CAN
        public class CANInfo
        {
            public string ResponseID { get; set; }
            public string RequestID { get; set; }
            public int Baudrate { get; set; }
            public bool Is29Bit { get; set; }
        }

        // متد ایجاد default CAN info
        private CANInfo GetDefaultCANInfo()
        {
            return new CANInfo
            {
                RequestID = "07,E0",    // default request ID
                ResponseID = "07,E8",   // default response ID  
                Is29Bit = false,        // default to 11-bit
                Baudrate = 500000
            };
        }

        // متد اعتبارسنجی که آیا بایت هگز معتبر است یا نه
        private bool IsValidHexByte(string byteStr)
        {
            if (string.IsNullOrEmpty(byteStr))
                return false;
            
            byteStr = byteStr.Trim();
            
            // بررسی الگوی هگز (00-FF)
            if (byteStr.Length != 2)
                return false;
                
            // بررسی اینکه فقط کاراکترهای هگز باشد
            foreach (char c in byteStr)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                    return false;
            }
            
            return true;
        }

        // متد استخراج اطلاعات CAN از فریم GOTO
        private CANInfo ExtractCANInfoFromGotoFrame(string line)
        {
            try
            {
                CANInfo canInfo = new CANInfo();
                
                // پیدا کردن آرایه بایت
                string byteArray = ExtractOnlyBytes(line);
                if (string.IsNullOrEmpty(byteArray))
                    return null;
                
                // حذف 0x و تقسیم بر اساس کاما
                string cleaned = byteArray.Replace("0x", "");
                string[] bytes = cleaned.Split(',');
                
                if (bytes.Length < 27) // حداقل 27 بایت نیاز داریم
                    return null;
                
                // استخراج CAN IDs (bytes 14-17 for response, 18-21 for request) - شمارش از 1
                // بایت های 14 تا 17 برای Response ID (اندیس 13-16 در آرایه)
                string responseByte1 = bytes[12].Trim(); // بایت 12
                string responseByte2 = bytes[13].Trim(); // بایت 13
                string responseByte3 = bytes[14].Trim(); // بایت 14
                string responseByte4 = bytes[15].Trim(); // بایت 15
                
                // بایت های 18 تا 21 برای Request ID (اندیس 17-20 در آرایه)
                string requestByte1 = bytes[16].Trim(); // بایت 16
                string requestByte2 = bytes[17].Trim(); // بایت 17
                string requestByte3 = bytes[18].Trim(); // بایت 18
                string requestByte4 = bytes[19].Trim(); // بایت 19
                
                // اعتبارسنجی آدرس‌های CAN - اگر معتبر نباشند، null برگردان
                if (!IsValidHexByte(responseByte1) || !IsValidHexByte(responseByte2) || 
                    !IsValidHexByte(responseByte3) || !IsValidHexByte(responseByte4) ||
                    !IsValidHexByte(requestByte1) || !IsValidHexByte(requestByte2) || 
                    !IsValidHexByte(requestByte3) || !IsValidHexByte(requestByte4))
                {
                    return null; // آدرس معتبر نیست
                }
                
                // تبدیل 4 بایت CAN ID به عدد 32 بیتی برای تشخیص نوع CAN
                int responseCANID = (Convert.ToInt32(responseByte1, 16) << 24) |
                                   (Convert.ToInt32(responseByte2, 16) << 16) |
                                   (Convert.ToInt32(responseByte3, 16) << 8) |
                                   Convert.ToInt32(responseByte4, 16);

                int requestCANID = (Convert.ToInt32(requestByte1, 16) << 24) |
                                  (Convert.ToInt32(requestByte2, 16) << 16) |
                                  (Convert.ToInt32(requestByte3, 16) << 8) |
                                  Convert.ToInt32(requestByte4, 16);

                // تشخیص 11-bit یا 29-bit بر اساس مقدار CAN ID
                // اگر CAN ID < 0x07FF (2047) باشد، CAN 11-bit است
                if (responseCANID < 0x07FF && requestCANID < 0x07FF)
                {
                    // CAN 11-bit - فقط 2 بایت کم ارزش (بایت های 3 و 4)
                    canInfo.Is29Bit = false;
                    canInfo.ResponseID = responseByte3 + "," + responseByte4;
                    canInfo.RequestID = requestByte3 + "," + requestByte4;
                }
                else
                {
                    // CAN 29-bit - تمام 4 بایت
                    canInfo.Is29Bit = true;
                    canInfo.ResponseID = responseByte1 + "," + responseByte2 + "," + responseByte3 + "," + responseByte4;
                    canInfo.RequestID = requestByte1 + "," + requestByte2 + "," + requestByte3 + "," + requestByte4;
                }
                
                // استخراج baudrate از بایت های 25 و 26
                string baudByte1 = bytes[25].Trim();
                string baudByte2 = bytes[26].Trim();
                
                // اعتبارسنجی baudrate
                if (!IsValidHexByte(baudByte1) || !IsValidHexByte(baudByte2))
                {
                    return null; // baudrate معتبر نیست
                }
                
                // تبدیل هگز به دسیمال
                int baudHex = Convert.ToInt32(baudByte1, 16) * 256 + Convert.ToInt32(baudByte2, 16);
                canInfo.Baudrate = baudHex * 1000; // معمولاً در کیلوبیت است
                
                return canInfo;
            }
            catch
            {
                return null;
            }
        }

        // متد پردازش فایل‌های .jc و استخراج خطوط initial
        private List<string> ProcessJcFiles(string[] jcFiles, string outputDir = null)
        {
            List<string> initialLines = new List<string>();
            List<string> functionLines = new List<string>();
            List<string> xscriptLines = new List<string>(); // برای فایل xscriptosim.sim
            CANInfo currentCANInfo = null; // برای نگهداری اطلاعات CAN فعلی
            
            // عبارات مورد نظر برای جستجو
            string[] targetFunctions = { "send({", "CAN({", "KWP({", "KWP2000({", "sendAndReceive({", "autoHandshake({", "signal(" };
            
            foreach (string filePath in jcFiles)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        
                        // تمیز کردن خط از فاصله‌ها، تب‌ها و کامنت‌ها
                        string cleanedLine = CleanLine(line);
                        
                        // بررسی وجود "initial(" در خط تمیز شده
                        if (cleanedLine.Contains("initial("))
                        {
                            // حذف تمام فاصله‌ها از خط و اضافه کردن به لیست
                            string lineWithoutSpaces = line.Replace(" ", "").Replace("\t", "");
                            initialLines.Add(lineWithoutSpaces);
                        }
                        
                        // بررسی وجود عبارات target functions
                        foreach (string targetFunc in targetFunctions)
                        {
                            if (cleanedLine.Contains(targetFunc))
                            {
                                // برای همه توابع شامل autoHandshake کل خط را اضافه کن
                                string funcLineWithoutSpaces = line.Replace(" ", "").Replace("\t", "");
                                
                                // تمیز کردن محتوای فریم قبل از اضافه کردن به فایل .frm
                                string sanitizedLine = SanitizeFrameContent(funcLineWithoutSpaces);
                                functionLines.Add(sanitizedLine);
                                
                                // بررسی اینکه آیا این فریم GOTO CAN MODE است یا نه
                                bool isGotoFrame = IsGotoCANModeFrame(line);
                                
                                if (isGotoFrame)
                                {
                                    // استخراج اطلاعات CAN از فریم GOTO و به‌روزرسانی اطلاعات فعلی
                                    CANInfo newCANInfo = ExtractCANInfoFromGotoFrame(line);
                                    if (newCANInfo != null)
                                    {
                                        // آدرس معتبر است، به‌روزرسانی کن
                                        currentCANInfo = newCANInfo;
                                    }
                                    // اگر آدرس معتبر نباشد، از آخرین آدرس معتبر استفاده کن (currentCANInfo تغییر نمی‌کند)
                                }
                                else
                                {
                                    // پیدا کردن آرایه بایت بعد از تابع از خط تمیز شده
                                    string byteArray = FindByteArrayAfterFunction(new string[] { sanitizedLine }, 0, targetFunc);
                                    if (string.IsNullOrEmpty(byteArray))
                                    {
                                        // اگر از خط تمیز شده پیدا نشد، از خط اصلی استفاده کن
                                        byteArray = FindByteArrayAfterFunction(lines, i, targetFunc);
                                    }
                                    
                                if (!string.IsNullOrEmpty(byteArray))
                                    {
                                        // تمیز کردن محتوای آرایه بایت نیز
                                        string sanitizedByteArray = SanitizeFrameContent(byteArray);
                                        
                                        // بررسی خاص برای autoHandshake
                                        if (cleanedLine.Contains("autoHandshake({"))
                                        {
                                            // برای autoHandshake از هر دو آرایه استفاده کن
                                            List<string> bothArrays = ExtractBothArraysFromAutoHandshake(sanitizedByteArray);
                                            if(bothArrays.Count==2)
                                                bothArrays[1] = null;//delete secound array in handshake
                                            foreach (string arrayContent in bothArrays)
                                            {
                                                string cleanBytes = ExtractOnlyBytes(arrayContent);
                                                if (!string.IsNullOrEmpty(cleanBytes))
                                                {
                                                    // تشخیص نوع پروتکل و تبدیل مناسب
                                                    bool isCanFrame = IsCANFrame(line) || IsCANFrameByContent(cleanBytes);
                                                    List<string> xscriptFormats;
                                                    
                                                    if (isCanFrame)
                                                    {
                                                        // استفاده از آدرس CAN فعلی یا default
                                                        CANInfo canInfoToUse = currentCANInfo ?? GetDefaultCANInfo();
                                                        xscriptFormats = ConvertToCANFormat(cleanBytes, canInfoToUse);
                                                    }
                                                    else
                                                    {
                                                        // فریم KWP
                                                        // تشخیص نوع فریم بر اساس محتوای خط اصلی
                                                        string frameType = "send"; // پیش‌فرض
                                                        if (line.Contains("KWP({"))
                                                        {
                                                            frameType = "KWP";
                                                        }
                                                        xscriptFormats = ConvertToXscriptFormat(cleanBytes, frameType);
                                                    }
                                                    
                                                    foreach (string format in xscriptFormats)
                                                    {
                                                        xscriptLines.Add(format);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                {
                                    // استخراج فقط بایت‌ها (بدون پرانتز و data)
                                            string cleanBytes = ExtractOnlyBytes(sanitizedByteArray);
                                    if (!string.IsNullOrEmpty(cleanBytes))
                                    {
                                                // تشخیص نوع پروتکل و تبدیل مناسب
                                                bool isCanFrame = IsCANFrame(line) || IsCANFrameByContent(cleanBytes);
                                                List<string> xscriptFormats;
                                                
                                                if (isCanFrame)
                                                {
                                                    // استفاده از آدرس CAN فعلی یا default
                                                    CANInfo canInfoToUse = currentCANInfo ?? GetDefaultCANInfo();
                                                    xscriptFormats = ConvertToCANFormat(cleanBytes, canInfoToUse);
                                                }
                                                else
                                                {
                                                    // فریم KWP
                                                    // تشخیص نوع فریم بر اساس محتوای خط اصلی
                                                    string frameType = "send"; // پیش‌فرض
                                                    if (line.Contains("KWP({"))
                                                    {
                                                        frameType = "KWP";
                                                    }
                                                    xscriptFormats = ConvertToXscriptFormat(cleanBytes, frameType);
                                                }
                                                
                                        foreach (string format in xscriptFormats)
                                        {
                                            xscriptLines.Add(format);
                                                }
                                            }
                                        }
                                    }
                                }
                                break; // فقط اولین تطبیق را در نظر بگیر
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // در صورت خطا در خواندن فایل، ادامه دادن به فایل بعدی
                    // چاپ خطا فقط در صورت لزوم (می‌توان حذف کرد)
                }
            }
            
            // ذخیره فایل xscriptosim.sim اگر آرایه‌ای وجود دارد
            if (xscriptLines.Count > 0 && !string.IsNullOrEmpty(outputDir))
            {
                SaveXscriptFileWithInitials(xscriptLines, initialLines, outputDir, currentCANInfo);
            }
            
            // ترکیب کردن نتایج: ابتدا initial ها، سپس function ها
            List<string> allResults = new List<string>();
            allResults.AddRange(initialLines);
            
            // اضافه کردن خط فاصله بین دو بخش اگر هر دو وجود دارند
            if (initialLines.Count > 0 && functionLines.Count > 0)
            {
                allResults.Add("");
            }
            
            allResults.AddRange(functionLines);
            
            return allResults;
        }

        // متد تمیز کردن خط از فاصله‌ها، تب‌ها و کامنت‌ها
        private string CleanLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return string.Empty;
            
            string cleaned = line;
            
            // حذف کامنت‌های // 
            int commentIndex = cleaned.IndexOf("//");
            if (commentIndex >= 0)
            {
                cleaned = cleaned.Substring(0, commentIndex);
            }
            
            // حذف کامنت‌های /* */ 
            while (cleaned.Contains("/*"))
            {
                int startComment = cleaned.IndexOf("/*");
                int endComment = cleaned.IndexOf("*/", startComment);
                if (endComment >= 0)
                {
                    cleaned = cleaned.Remove(startComment, endComment - startComment + 2);
                }
                else
                {
                    // اگر کامنت بسته نشده، از ابتدای کامنت تا انتها حذف کن
                    cleaned = cleaned.Substring(0, startComment);
                    break;
                }
            }
            
            // حذف فاصله‌ها و تب‌ها از ابتدا و انتها
            cleaned = cleaned.Trim();
            
            // حذف فاصله‌ها و تب‌های اضافی از داخل متن
            cleaned = System.Text.RegularExpressions.Regex.Replace(cleaned, @"\s+", " ");
            
            return cleaned;
        }

        // متد پیدا کردن آرایه بایت بعد از تابع
        private string FindByteArrayAfterFunction(string[] lines, int functionLineIndex, string targetFunction)
        {
            // بررسی خود خط تابع برای آرایه بایت (بعد از تابع)
            string functionLine = lines[functionLineIndex];
            string byteArrayInSameLine = ExtractByteArrayAfterFunction(functionLine, targetFunction);
            if (!string.IsNullOrEmpty(byteArrayInSameLine))
            {
                // اعمال منطق خاص برای autoHandshake و signal
                if (targetFunction == "autoHandshake({")
                {
                    byteArrayInSameLine = ExtractFirstArrayOnly(byteArrayInSameLine);
                }
                else if (targetFunction == "signal(")
                {
                    byteArrayInSameLine = ExtractSecondArrayOnly(byteArrayInSameLine);
                }
                return byteArrayInSameLine;
            }
            
            // بررسی تا 3 خط بعد از تابع برای پیدا کردن آرایه بایت
            for (int i = functionLineIndex + 1; i < Math.Min(lines.Length, functionLineIndex + 4); i++)
            {
                string line = lines[i];
                string cleanedLine = CleanLine(line);
                
                // الگوهای مختلف آرایه بایت
                if (IsLineContainsByteArray(cleanedLine))
                {
                    string result = line.Replace(" ", "").Replace("\t", "");
                    
                    // برای autoHandshake فقط اولین آرایه را برگردان
                    if (targetFunction == "autoHandshake({")
                    {
                        result = ExtractFirstArrayOnly(result);
                    }
                    // برای signal فقط دومین آرایه را برگردان
                    else if (targetFunction == "signal(")
                    {
                        result = ExtractSecondArrayOnly(result);
                    }
                    
                    return result;
                }
            }
            
            return string.Empty;
        }

        // متد استخراج آرایه بایت از همان خط تابع (بعد از تابع)
        private string ExtractByteArrayAfterFunction(string line, string targetFunction)
        {
            string cleanedLine = CleanLine(line);
            int funcIndex = cleanedLine.IndexOf(targetFunction);
            if (funcIndex >= 0)
            {
                // بررسی بخش بعد از تابع در همان خط
                int afterFuncStart = funcIndex + targetFunction.Length;
                if (afterFuncStart < cleanedLine.Length)
                {
                    string afterFunction = cleanedLine.Substring(afterFuncStart).Trim();
                    if (IsLineContainsByteArray(afterFunction))
                    {
                        // پیدا کردن قسمت بعد از تابع در خط اصلی
                        int originalAfterStart = line.IndexOf(targetFunction) + targetFunction.Length;
                        if (originalAfterStart < line.Length)
                        {
                            string originalAfter = line.Substring(originalAfterStart).Trim();
                            return originalAfter.Replace(" ", "").Replace("\t", "");
                        }
                    }
                }
            }
            return string.Empty;
        }

        // متد بررسی وجود آرایه بایت در خط
        private bool IsLineContainsByteArray(string line)
        {
            if (string.IsNullOrEmpty(line)) return false;
            
            // الگوهای مختلف آرایه بایت
            // مثال: {0x01, 0x02}, [0x01, 0x02], 0x01,0x02, 01 02 03
            
            // بررسی وجود 0x و کاما یا فاصله
            if (line.Contains("0x") && (line.Contains(",") || line.Contains(" ")))
                return true;
                
            // بررسی آرایه با { }
            if (line.Contains("{") && line.Contains("}") && line.Contains("0x"))
                return true;
                
            // بررسی آرایه با [ ]
            if (line.Contains("[") && line.Contains("]") && line.Contains("0x"))
                return true;
                
            // بررسی الگوی hex بدون 0x (مثل: 01 02 03 یا 01,02,03)
            if (System.Text.RegularExpressions.Regex.IsMatch(line, @"[0-9A-Fa-f]{2}[\s,]+[0-9A-Fa-f]{2}"))
                return true;
                
            return false;
        }

        // متد تمیز کردن محتوای فریم و جایگزینی غیر-بایت ها با 0x00
        private string SanitizeFrameContent(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            try
            {
                // الگوهای مختلف متغیرها و عبارات غیر-بایت
                string[] patterns = {
                    @"code\[\d+\]",           // code[0], code[1], etc.
                    @"data\[\d+\]",           // data[0], data[1], etc.
                    @"buffer\[\d+\]",         // buffer[0], buffer[1], etc.
                    @"key\[\d+\]",            // key[0], key[1], etc.
                    @"seed\[\d+\]",           // seed[0], seed[1], etc.
                    @"param\[\d+\]",          // param[0], param[1], etc.
                    @"value\[\d+\]",          // value[0], value[1], etc.
                    @"addr\[\d+\]",           // addr[0], addr[1], etc.
                    @"checksum\[\d+\]",       // checksum[0], checksum[1], etc.
                    @"response\[\d+\]",       // response[0], response[1], etc.
                    @"\b[a-zA-Z_][a-zA-Z0-9_]*\[\d+\]", // هر متغیر با اندیس
                };

                string result = input;
                
                // فقط محتوای داخل آرایه‌ها را تمیز کن، نه متغیرهای بیرون آرایه
                // الگوی جستجو برای آرایه‌ها: {محتوای آرایه}
                var arrayMatches = System.Text.RegularExpressions.Regex.Matches(result, @"\{([^}]*)\}");
                
                foreach (System.Text.RegularExpressions.Match match in arrayMatches)
                {
                    string arrayContent = match.Groups[1].Value;
                    string sanitizedContent = arrayContent;
                    
                    // اعمال الگوها فقط روی محتوای آرایه
                    foreach (string pattern in patterns)
                    {
                        sanitizedContent = System.Text.RegularExpressions.Regex.Replace(sanitizedContent, pattern, "0x00", 
                            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    }
                    
                    // جایگزینی محتوای تمیز شده
                    if (sanitizedContent != arrayContent)
                    {
                        result = result.Replace(match.Value, "{" + sanitizedContent + "}");
                    }
                }
                
                // همچنین الگوی جستجو برای آرایه‌های با براکت: [محتوای آرایه]
                var bracketMatches = System.Text.RegularExpressions.Regex.Matches(result, @"\[([^\]]*)\]");
                
                foreach (System.Text.RegularExpressions.Match match in bracketMatches)
                {
                    string arrayContent = match.Groups[1].Value;
                    string sanitizedContent = arrayContent;
                    
                    // اعمال الگوها فقط روی محتوای آرایه
                    foreach (string pattern in patterns)
                    {
                        sanitizedContent = System.Text.RegularExpressions.Regex.Replace(sanitizedContent, pattern, "0x00", 
                            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    }
                    
                    // جایگزینی محتوای تمیز شده
                    if (sanitizedContent != arrayContent)
                    {
                        result = result.Replace(match.Value, "[" + sanitizedContent + "]");
                    }
                }

                return result;
            }
            catch
            {
                return input;
            }
        }

        // متد استخراج فقط بایت‌ها از آرایه (حذف کامل پرانتز و data)
        private string ExtractOnlyBytes(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // حذف فاصله‌ها و تب‌ها
            string cleaned = input.Replace(" ", "").Replace("\t", "");
            
            // 1. جستجو برای الگوی {بایت‌ها}
            var bracesMatch = System.Text.RegularExpressions.Regex.Match(cleaned, @"\{([^}]*0x[^}]*)\}");
            if (bracesMatch.Success)
            {
                string inside = bracesMatch.Groups[1].Value;
                
                // حذف },data یا ,data از انتها
                if (inside.Contains("},data"))
                {
                    inside = inside.Substring(0, inside.IndexOf("},data"));
                }
                else if (inside.Contains(",data"))
                {
                    inside = inside.Substring(0, inside.IndexOf(",data"));
                }
                
                return inside;
            }
            
            // 2. جستجو برای الگوی [بایت‌ها]
            var bracketsMatch = System.Text.RegularExpressions.Regex.Match(cleaned, @"\[([^\]]*0x[^\]]*)\]");
            if (bracketsMatch.Success)
            {
                string inside = bracketsMatch.Groups[1].Value;
                
                // حذف ],data یا ,data از انتها
                if (inside.Contains("],data"))
                {
                    inside = inside.Substring(0, inside.IndexOf("],data"));
                }
                else if (inside.Contains(",data"))
                {
                    inside = inside.Substring(0, inside.IndexOf(",data"));
                }
                
                return inside;
            }
            
            // 3. اگر پرانتز نیست، مستقیماً بایت‌ها را پیدا کن
            if (cleaned.Contains("0x"))
            {
                // استخراج تمام 0x پترن‌ها تا قبل از data
                var hexMatches = System.Text.RegularExpressions.Regex.Matches(cleaned, @"0x[0-9A-Fa-f]+");
                if (hexMatches.Count > 0)
                {
                    var bytes = new List<string>();
                    foreach (System.Text.RegularExpressions.Match match in hexMatches)
                    {
                        bytes.Add(match.Value);
                    }
                    
                    return string.Join(",", bytes);
                }
            }
            
            return string.Empty;
        }

        // متد پارس کردن اینیشیال ها و تبدیل به فرمت I={}
        private List<string> ParseInitialsAndConvert(List<string> initialLines)
        {
            List<string> convertedInitials = new List<string>();
            var kwpMapping = GetKWPInitialMapping();
            var can11Mapping = GetCAN11BitInitialMapping();
            var can29Mapping = GetCAN29BitInitialMapping();

            foreach (string line in initialLines)
            {
                if (line.Contains("initial("))
                {
                    string converted = ConvertInitialToIFormat(line, kwpMapping, can11Mapping, can29Mapping);
                    if (!string.IsNullOrEmpty(converted))
                    {
                        convertedInitials.Add(converted);
                    }
                }
            }

            return convertedInitials;
        }

        // متد تبدیل یک خط initial به فرمت I={}
        private string ConvertInitialToIFormat(string initialLine, 
            Dictionary<int, string> kwpMapping, 
            Dictionary<int, string> can11Mapping, 
            Dictionary<int, string> can29Mapping)
        {
            try
            {
                // استخراج پارامترها از initial(param1,param2,param3,param4,param5)
                int startParen = initialLine.IndexOf('(');
                int endParen = initialLine.LastIndexOf(')');
                
                if (startParen < 0 || endParen < 0 || endParen <= startParen)
                    return string.Empty;

                string paramString = initialLine.Substring(startParen + 1, endParen - startParen - 1);
                string[] parameters = paramString.Split(',');
                
                if (parameters.Length < 3)
                    return string.Empty;

                // پارس کردن پارامترها
                int baudrate = int.Parse(parameters[0].Trim());
                
                // بررسی نوع پروتکل بر اساس baudrate ابتدا
                if (baudrate == 57600)
                {
                    // هر initial با 57600 را CAN در نظر بگیر
                    if (parameters.Length == 5)
                    {
                        int lastParam = int.Parse(parameters[4].Trim());
                        
                        // CAN 11-bit (parameters[4] = 1,2,3)
                        if (can11Mapping.ContainsKey(lastParam))
                        {
                            return can11Mapping[lastParam];
                        }
                    }
                    else if (parameters.Length == 1)
                    {
                        // CAN with 3 parameters - treat as CAN 29-bit
                        return can29Mapping[1];
                    }
                }
                else if (parameters.Length == 3)
                {
                    // KWP Protocol (only if baudrate is not 57600)
                    string param2 = parameters[1].Trim();
                    int pinValue;
                    
                    // حذف 0x اگر وجود دارد
                    if (param2.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                        param2 = param2.Substring(2);
                    
                    if (int.TryParse(param2, System.Globalization.NumberStyles.HexNumber, null, out pinValue))
                    {
                        if (kwpMapping.ContainsKey(pinValue))
                        {
                            return kwpMapping[pinValue].Replace("{BAUDRATE}", baudrate.ToString());
                        }
                    }
                }
            }
            catch
            {
                // در صورت خطا، خط خالی برگردان
                return string.Empty;
            }

            return string.Empty;
        }

        // متد تبدیل آرایه بایت به فرمت CAN
        private List<string> ConvertToCANFormat(string byteArray, CANInfo canInfo = null)
        {
            List<string> result = new List<string>();
            
            if (string.IsNullOrEmpty(byteArray))
                return result;

            // حذف 0x از همه جا
            string cleaned = byteArray.Replace("0x", "");
            
            // تقسیم بر اساس کاما و تمیز کردن
            string[] bytes = cleaned.Split(',');
            List<string> cleanBytes = new List<string>();
            
            foreach (string b in bytes)
            {
                string trimmed = b.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    cleanBytes.Add(trimmed);
                }
            }
            
            // حذف دو بایت اول (length) از فریم
            if (cleanBytes.Count >= 2)
            {
                cleanBytes.RemoveRange(0, 2); // حذف 2 بایت اول
            }
            
            // ترکیب با کاما و اضافه کردن C={ و R={
            if (cleanBytes.Count > 0)
            {
                string byteString = string.Join(",", cleanBytes);
                
                // ساخت فریم CAN با ساختار صحیح
                string canRequest = FormatCANFrame(byteString, canInfo, true); // request
                result.Add("C={" + canRequest + "};");
                
                // تولید response واقعی برای CAN
                string responseBytes = GenerateCANResponse(byteString, canInfo);
                string canResponse = FormatCANFrame(responseBytes, canInfo, false); // response
                result.Add("R={" + canResponse + "};");
            }
            
            return result;
        }

        // متد قالب‌بندی فریم CAN بر اساس نوع 11-bit یا 29-bit
        private string FormatCANFrame(string dataBytes, CANInfo canInfo, bool isRequest)
        {
            if (canInfo == null)
                return dataBytes; // اگر اطلاعات CAN نداریم، همان data را برگردان
            
            try
            {
                string canId = isRequest ? canInfo.RequestID : canInfo.ResponseID;
                
                // تقسیم data bytes به آرایه
                string[] dataArray = dataBytes.Split(',');
                
                if (canInfo.Is29Bit)
                {
                    // CAN 29-bit: CAN_ID (4 bytes) + SID + Data
                    // ساختار: آدرس (4 بایت) + SID + باقی data
                    if (dataArray.Length >= 1)
                    {
                        // اولین بایت SID است، باقی data هستند
                        string sid = dataArray[0].Trim();
                        
                        List<string> remainingData = new List<string>();
                        for (int i = 1; i < dataArray.Length; i++)
                        {
                            remainingData.Add(dataArray[i].Trim());
                        }
                        
                        string finalData = remainingData.Count > 0 ? "," + string.Join(",", remainingData) : "";
                        return canId + "," + sid + finalData;
                    }
                    else
                    {
                        return canId;
                    }
                }
                else
                {
                    // CAN 11-bit: CAN_ID (2 bytes) + SID + Data
                    // ساختار: آدرس (2 بایت) + SID + باقی data
                    if (dataArray.Length >= 1)
                    {
                        // اولین بایت SID است، باقی data هستند
                        string sid = dataArray[0].Trim();
                        
                        List<string> remainingData = new List<string>();
                        for (int i = 1; i < dataArray.Length; i++)
                        {
                            remainingData.Add(dataArray[i].Trim());
                        }
                        
                        string finalData = remainingData.Count > 0 ? "," + string.Join(",", remainingData) : "";
                        return canId + "," + sid + finalData;
                    }
                    else
                    {
                        return canId;
                    }
                }
            }
            catch
            {
                return dataBytes;
            }
        }

        // متد تبدیل آرایه بایت به فرمت xscriptosim
        private List<string> ConvertToXscriptFormat(string byteArray, string frameType = "send")
        {
            List<string> result = new List<string>();
            
            if (string.IsNullOrEmpty(byteArray))
                return result;

            // حذف 0x از همه جا
            string cleaned = byteArray.Replace("0x", "");
            
            // تقسیم بر اساس کاما و تمیز کردن
            string[] bytes = cleaned.Split(',');
            List<string> cleanBytes = new List<string>();
            
            foreach (string b in bytes)
            {
                string trimmed = b.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    cleanBytes.Add(trimmed);
                }
            }
            
            // اگر frameType = "KWP" باشد، فریم را بدون تغییر بفرست
            if (frameType == "KWP")
            {
            if (cleanBytes.Count > 0)
            {
                string byteString = string.Join(",", cleanBytes);
                result.Add("C={" + byteString + "};");
                
                    // تولید response برای KWP frame
                    string responseBytes = GenerateKWPResponseForKWPFrame(byteString);
                result.Add("R={" + responseBytes + "};");
                }
                return result;
            }
            
            // برای send({...}) frames، تشخیص نوع KWP و پردازش مناسب
            if (cleanBytes.Count > 0)
            {
                // تشخیص نوع مدل KWP از فریم اصلی (قبل از حذف بایت‌ها)
                int kwpModel = DetectKWPModel(cleanBytes.ToArray());
                
                string byteString;
                string responseBytes;
                
                switch (kwpModel)
                {
                    case 1: // Model 1: (0x80+Length) + target + source + SID + data + checksum
                        // برای Model 1 هیچ بایتی حذف نمی‌شود - کل فریم حفظ می‌شود
                        byteString = string.Join(",", cleanBytes);
                        result.Add("C={" + byteString + "};");
                        
                        // تولید response برای مدل 1 - استفاده از فریم اصلی برای تشخیص
                        responseBytes = GenerateKWPResponseModel1(cleanBytes.ToArray());
                        result.Add("R={" + responseBytes + "};");
                        break;
                        
                    case 2: // Model 2: (0x80) + target + source + Length + SID + data + checksum
                        // برای Model 2 هیچ بایتی حذف نمی‌شود - کل فریم حفظ می‌شود
                        byteString = string.Join(",", cleanBytes);
                        result.Add("C={" + byteString + "};");

                        // تولید response برای مدل 2 - استفاده از فریم اصلی برای تشخیص
                        responseBytes = GenerateKWPResponseModel2(cleanBytes.ToArray());
                        result.Add("R={" + responseBytes + "};");
                        break;
                        
                    case 3: // Model 3: Length + SID + data + checksum
                    default:
                        // برای Model 3 دو بایت اول (length) حذف می‌شود
                        /*if (cleanBytes.Count >= 2)
                        {
                            cleanBytes.RemoveRange(0, 2);
                        }*/
                        byteString = string.Join(",", cleanBytes);
                        result.Add("C={" + byteString + "};");
                        
                        // تولید response برای مدل 3 - استفاده از فریم اصلی برای تشخیص
                        responseBytes = GenerateKWPResponseModel3(cleanBytes.ToArray());
                        result.Add("R={" + responseBytes + "};");
                        break;
                }
            }
            
            return result;
        }

        // متد ذخیره فایل xscriptosim.sim
        private void SaveXscriptFile(List<string> xscriptLines, string outputDir)
        {
            try
            {
                // حذف فریم‌های تکراری
                List<string> uniqueLines = RemoveDuplicateFrames(xscriptLines);
                
                // اضافه کردن اینتر بعد از هر خط R={
                List<string> finalLines = AddLineBreaksAfterR(uniqueLines);
                
                string simPath = Path.Combine(outputDir, "xscriptosim.sim");
                File.WriteAllLines(simPath, finalLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving xscript file: " + ex.Message);
            }
        }

        // متد ذخیره فایل xscriptosim.sim با initial ها
        private void SaveXscriptFileWithInitials(List<string> xscriptLines, List<string> initialLines, string outputDir, CANInfo canInfo)
        {
            try
            {
                // حذف فریم‌های تکراری
                List<string> uniqueLines = RemoveDuplicateFrames(xscriptLines);
                
                // اضافه کردن اینتر بعد از هر خط R={
                List<string> finalLines = AddLineBreaksAfterR(uniqueLines);
                
                // پارس کردن اینیشیال ها و تبدیل به فرمت I={}
                List<string> convertedInitials = ParseInitialsAndConvert(initialLines);
                
                // حذف اینیشیال های تکراری
                convertedInitials = RemoveDuplicateInitials(convertedInitials);
                
                // ترکیب اینیشیال ها در ابتدا + فریم ها
                List<string> completeFileContent = new List<string>();
                
                // اضافه کردن اینیشیال ها بدون فاصله
                completeFileContent.AddRange(convertedInitials);
                
                // اضافه کردن یک خط خالی اگر هم اینیشیال و هم فریم وجود دارند
                if (convertedInitials.Count > 0 && finalLines.Count > 0)
                {
                    completeFileContent.Add("");
                }
                
                // اضافه کردن فریم ها
                completeFileContent.AddRange(finalLines);

                // تنظیم initial مناسب بر اساس نوع CAN
                if (completeFileContent.Count > 0 && canInfo != null)
                {
                    if (canInfo.Is29Bit)
                    {
                        // برای CAN 29-bit از initial مناسب استفاده کن
                        completeFileContent[0] = "I={7,1,250000,0,0};";
                    }
                }

                string simPath = Path.Combine(outputDir, "xscriptosim.sim");
                File.WriteAllLines(simPath, completeFileContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving xscript file with initials: " + ex.Message);
            }
        }

        // متد حذف اینیشیال های تکراری
        private List<string> RemoveDuplicateInitials(List<string> initialLines)
        {
            HashSet<string> seenInitials = new HashSet<string>();
            List<string> uniqueInitials = new List<string>();
            
            foreach (string initial in initialLines)
            {
                if (!seenInitials.Contains(initial))
                {
                    seenInitials.Add(initial);
                    uniqueInitials.Add(initial);
                }
            }
            
            return uniqueInitials;
        }

        // متد حذف فریم‌های تکراری
        private List<string> RemoveDuplicateFrames(List<string> xscriptLines)
        {
            List<string> result = new List<string>();
            HashSet<string> seenPairs = new HashSet<string>();
            
            for (int i = 0; i < xscriptLines.Count; i += 2)
            {
                if (i + 1 < xscriptLines.Count)
                {
                    string cLine = xscriptLines[i];
                    string rLine = xscriptLines[i + 1];
                    
                    // استخراج محتوای داخل { } برای مقایسه
                    string cContent = ExtractContent(cLine);
                    string rContent = ExtractContent(rLine);
                    
                    // ایجاد کلید یونیک برای جفت C و R
                    string pairKey = cContent + "|" + rContent;
                    
                    if (!seenPairs.Contains(pairKey))
                    {
                        seenPairs.Add(pairKey);
                        result.Add(cLine);
                        result.Add(rLine);
                    }
                }
                else
                {
                    // اگر فقط یک خط باقی مانده، اضافه کن
                    result.Add(xscriptLines[i]);
                }
            }
            
            return result;
        }

        // متد استخراج محتوای داخل { }
        private string ExtractContent(string line)
        {
            int startIndex = line.IndexOf('{');
            int endIndex = line.IndexOf('}');
            
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return line.Substring(startIndex + 1, endIndex - startIndex - 1);
            }
            
            return line;
        }

        // متد اضافه کردن اینتر بعد از خطوط R={
        private List<string> AddLineBreaksAfterR(List<string> lines)
        {
            List<string> result = new List<string>();
            
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                result.Add(line);
                
                // اگر خط با R={ شروع شود، یک خط خالی اضافه کن
                if (line.StartsWith("R={"))
                {
                    // بررسی اینکه آیا این فریم SID خاصی دارد که نیاز به X={4}; دارد
                    if (i > 0 && lines[i - 1].StartsWith("C={"))
                    {
                        string cLine = lines[i - 1];
                        string rLine = line;
                        
                        // استخراج SID از فریم C={...};
                        int sid = ExtractSIDFromFrame(cLine);
                        
                        // اگر SID در لیست SIDهای خاص باشد، X={4}; اضافه کن
                        if (IsSpecialSID(sid))
                        {
                            result.Add("X={4};");
                        }
                    }
                    
                    result.Add("");
                }
            }
            
            return result;
        }

        // متد استخراج SID از فریم C={...};
        private int ExtractSIDFromFrame(string cLine)
        {
            try
            {
                // حذف C={ و };
                string content = cLine.Replace("C={", "").Replace("};", "");
                
                // تقسیم بر اساس کاما
                string[] bytes = content.Split(',');
                
                // بررسی اینکه آیا این فریم CAN است (بایت اول آدرس CAN است)
                if (IsCANFrameByContent("{" + content + "}"))
                {
                    // برای CAN: بایت سوم (index 2) SID است
                    if (bytes.Length > 2)
                    {
                        string sidStr = bytes[2].Trim();
                        if (int.TryParse(sidStr, NumberStyles.HexNumber, null, out int sid))
                        {
                            return sid;
                        }
                    }
                }
                else
                {
                    // برای KWP: تشخیص نوع مدل و استخراج SID مناسب
                    if (bytes.Length > 0)
                    {
                        // تشخیص مدل بر اساس ساختار C-frame
                        // Model 1 C-frame: (0x80+Length) + target + source + SID + data
                        // Model 2 C-frame: (0x80) + target + source + Length + SID + data
                        // Model 3 C-frame: SID + data
                        
                        // بررسی Model 1: اگر بایت اول >= 0x80 باشد
                        if (bytes.Length > 0 && int.TryParse(bytes[0].Trim(), NumberStyles.HexNumber, null, out int firstByte) && firstByte >= 0x80)
                        {
                            // Model 1: SID در index 3
                            if (bytes.Length > 3)
                            {
                                string sidStr = bytes[3].Trim();
                                if (int.TryParse(sidStr, NumberStyles.HexNumber, null, out int sid))
                                {
                                    return sid;
                                }
                            }
                        }
                        // بررسی Model 2: اگر بایت اول == 0x80 باشد
                        else if (bytes.Length > 0 && int.TryParse(bytes[0].Trim(), NumberStyles.HexNumber, null, out int firstByteCheck) && firstByteCheck == 0x80)
                        {
                            // Model 2: SID در index 4 (بعد از 0x80 + target + source + Length)
                            if (bytes.Length > 4)
                            {
                                string sidStr = bytes[4].Trim();
                                if (int.TryParse(sidStr, NumberStyles.HexNumber, null, out int sid))
                                {
                                    return sid;
                                }
                            }
                        }
                        // Model 3: SID در index 0
                        else if (bytes.Length > 0)
                        {
                            string sidStr = bytes[0].Trim();
                            if (int.TryParse(sidStr, NumberStyles.HexNumber, null, out int sid))
                            {
                                return sid;
                            }
                        }
                    }
                }
            }
            catch
            {
                // در صورت خطا، 0 برگردان
            }
            
            return 0;
        }

        // متد بررسی اینکه آیا SID در لیست SIDهای خاص است
        private bool IsSpecialSID(int sid)
        {
            // لیست SIDهای خاص که نیاز به X={4}; دارند
            int[] specialSIDs = { 0x27, 0x30, 0x31, 0x3B, 0x2E, 0x2F, 0x34, 0x36 };
            
            return Array.Exists(specialSIDs, s => s == sid);
        }

        // متد استخراج هر دو آرایه از autoHandshake برای CAN
        private List<string> ExtractBothArraysFromAutoHandshake(string line)
        {
            List<string> arrays = new List<string>();
            
            if (string.IsNullOrEmpty(line))
                return arrays;

            try
            {
                int currentPos = 0;
                
                // پیدا کردن تمام آرایه‌ها
                while (currentPos < line.Length)
                {
                    int braceStart = line.IndexOf('{', currentPos);
                    if (braceStart < 0) break;
                    
                    int braceCount = 0;
                    int braceEnd = -1;
                    
                    for (int i = braceStart; i < line.Length; i++)
                    {
                        if (line[i] == '{')
                            braceCount++;
                        else if (line[i] == '}')
                        {
                            braceCount--;
                            if (braceCount == 0)
                            {
                                braceEnd = i;
                                break;
                            }
                        }
                    }
                    
                    if (braceEnd >= 0)
                    {
                        // آرایه کامل پیدا شد
                        string array = line.Substring(braceStart, braceEnd - braceStart + 1);
                        arrays.Add(array);
                        currentPos = braceEnd + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                // در صورت خطا، لیست خالی برگردان
            }
            
            return arrays;
        }

        // متد استخراج فقط اولین آرایه از خط (برای autoHandshake)
        private string ExtractFirstArrayOnly(string line)
        {
            if (string.IsNullOrEmpty(line))
                return string.Empty;

            // پیدا کردن اولین {
            line = "{" + line;
            int startBrace = line.IndexOf('{');
            if (startBrace >= 0)
            {
                int braceCount = 0;
                for (int i = startBrace; i < line.Length; i++)
                {
                    if (line[i] == '{')
                        braceCount++;
                    else if (line[i] == '}')
                    {
                        braceCount--;
                        if (braceCount == 0)
                        {
                            // اولین آرایه کامل پیدا شد - شامل { و }
                            string firstArray = line.Substring(startBrace, i - startBrace + 1);
                            
                            // مثال: از autoHandshake({0x81,0x20,0xF1,0x3E,0xD0},{0x81,0xF1,0x20,0x7E,0x10})
                            // برمی‌گرداند: {0x81,0x20,0xF1,0x3E,0xD0}
                            return firstArray;
                        }
                    }
                }
            }

            return string.Empty; // اگر آرایه پیدا نشد
        }

        // متد استخراج فقط دومین آرایه از خط (برای signal)
        private string ExtractSecondArrayOnly(string line)
        {
            if (string.IsNullOrEmpty(line))
                return string.Empty;

            // مثال: signal({25,25},0,0,0,1,{0x81,0x20,0xF1,0x81,0x13});
            // باید {0x81,0x20,0xF1,0x81,0x13} را برگرداند

            List<string> arrays = new List<string>();
            int currentPos = 0;
            
            // پیدا کردن تمام آرایه‌ها
            while (currentPos < line.Length)
            {
                int braceStart = line.IndexOf('{', currentPos);
                if (braceStart < 0) break;
                
                int braceCount = 0;
                int braceEnd = -1;
                
                for (int i = braceStart; i < line.Length; i++)
                {
                    if (line[i] == '{')
                        braceCount++;
                    else if (line[i] == '}')
                    {
                        braceCount--;
                        if (braceCount == 0)
                        {
                            braceEnd = i;
                            break;
                        }
                    }
                }
                
                if (braceEnd >= 0)
                {
                    // آرایه کامل پیدا شد
                    string array = line.Substring(braceStart, braceEnd - braceStart + 1);
                    arrays.Add(array);
                    currentPos = braceEnd + 1;
                }
                else
                {
                    break;
                }
            }
            
            // برگرداندن دومین آرایه (اگر وجود دارد)
            if (arrays.Count >= 2)
            {
                return arrays[1]; // دومین آرایه
            }
            
            return string.Empty; // اگر دومین آرایه پیدا نشد
        }

        // Dictionary برای mapping اینیشیال های KWP
        private Dictionary<int, string> GetKWPInitialMapping()
        {
            var kwpMapping = new Dictionary<int, string>
            {
                { 0x00, "I={1,7,{BAUDRATE},0,0};" },
                { 0x01, "I={2,12,{BAUDRATE},0,0};" },
                { 0x11, "I={2,13,{BAUDRATE},0,0};" },
                { 0x21, "I={2,6,{BAUDRATE},0,0};" },
                { 0x10, "I={1,4,{BAUDRATE},0,0};" },
                { 0x30, "I={1,5,{BAUDRATE},0,0};" },
                { 0x40, "I={1,2,{BAUDRATE},0,0};" },
                { 0x41, "I={1,3,{BAUDRATE},0,0};" },
                { 0x04, "I={2,11,{BAUDRATE},0,0};" },
                { 0x08, "I={2,8,{BAUDRATE},0,0};" },
                { 0x0C, "I={1,9,{BAUDRATE},0,0};" }
            };
            return kwpMapping;
        }

        // Dictionary برای mapping اینیشیال های CAN 11-bit
        private Dictionary<int, string> GetCAN11BitInitialMapping()
        {
            var can11Mapping = new Dictionary<int, string>
            {
                { 1, "I={3,1,500000,0,0};" },
                { 2, "I={3,2,500000,0,0};" },
                { 3, "I={3,3,500000,0,0};" }
            };
            return can11Mapping;
        }

        // Dictionary برای mapping اینیشیال های CAN 29-bit
        private Dictionary<int, string> GetCAN29BitInitialMapping()
        {
            var can29Mapping = new Dictionary<int, string>
            {
                { 1, "I={7,1,250000,0,0};" },
                { 2, "I={7,2,250000,0,0};" },
                { 3, "I={7,3,250000,0,0};" }
            };
            return can29Mapping;
        }

        // Dictionary برای ذخیره داده‌های پاسخ CAN 11-bit
        private Dictionary<int, string[]> GetCAN11BitResponseData()
        {
            var responses = new Dictionary<int, string[]>
            {
                // 0x10 : Start Diagnostic Session
                { 0x10, new string[] { "50", "01" } },
                
                // 0x11 : ECU Reset  
                { 0x11, new string[] { "51", "01" } },
                
                // 0x12 : Read Freeze Frame Data
                { 0x12, new string[] { "52", "01", "02", "03", "04", "05" } },
                
                // 0x13 : Read Diagnostic Trouble Codes
                { 0x13, new string[] { "53", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x14 : Clear Diagnostic Information
                { 0x14, new string[] { "54" } },
                
                // 0x17 : Read Status Of Diagnostic Trouble Codes
                { 0x17, new string[] { "57", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x18 : Read Diagnostic Trouble Codes By Status
                { 0x18, new string[] { "58", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x19 : Read Diagnostic Trouble Codes By Status
                { 0x19, new string[] { "59", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },

                // 0x1A : Read Ecu Id
                { 0x1A, new string[] { "5A", "31", "32", "34", "35", "36", "37", "38", "39", "30", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A" } },
                
                // 0x20 : Stop Diagnostic Session
                { 0x20, new string[] { "60" } },
                
                // 0x21 : Read Data By Local Id
                { 0x21, new string[] { "61", "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x22 : Read Data By Common Id
                { 0x22, new string[] { "62", "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x23 : Read Memory By Address
                { 0x23, new string[] { "63", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x25 : Stop Repeated Data Transmission
                { 0x25, new string[] { "65", "01" } },
                
                // 0x26 : Set Data Rates
                { 0x26, new string[] { "66", "01" } },
                
                // 0x27 : Security Access
                { 0x27, new string[] { "67", "12", "34", "56", "78" } },
                
                // 0x2C : Dynamically Define Local Id
                { 0x2C, new string[] { "6C", "01" } },
                
                // 0x2E : Write Data By Common Id
                { 0x2E, new string[] { "6E", "01" } },
                
                // 0x2F : Input Output Control By Common Id
                { 0x2F, new string[] { "6F", "01", "02" } },
                
                // 0x30 : Input Output Control By Local Id
                { 0x30, new string[] { "70", "01", "02" } },
                
                // 0x31 : Start Routine By Local ID
                { 0x31, new string[] { "71", "01", "F4" } },
                
                // 0x32 : Stop Routine By Local ID
                { 0x32, new string[] { "72", "01" } },
                
                // 0x33 : Request Routine Results By Local Id
                { 0x33, new string[] { "73", "01", "00", "FF" } },
                
                // 0x34 : Request Download
                { 0x34, new string[] { "74", "01", "01", "01" } },
                
                // 0x35 : Request Upload
                { 0x35, new string[] { "75", "20", "04", "00" } },
                
                // 0x36 : Transfer data
                { 0x36, new string[] { "76", "01" } },
                
                // 0x37 : Request transfer exit
                { 0x37, new string[] { "77" } },
                
                // 0x38 : Start Routine By Address
                { 0x38, new string[] { "78", "01", "F4" } },
                
                // 0x39 : Stop Routine By Address
                { 0x39, new string[] { "79", "01" } },
                
                // 0x3A : Request Routine Results By Address
                { 0x3A, new string[] { "7A", "01", "00", "FF" } },
                
                // 0x3B : Write Data By Local Id
                { 0x3B, new string[] { "7B", "01" } },
                
                // 0x3D : Write Memory By Address
                { 0x3D, new string[] { "7D", "01" } },
                
                // 0x3E : Tester Present
                { 0x3E, new string[] { "7E", "00" } },
                
                // 0x81 : Start Communication
                { 0x81, new string[] { "C1", "F8", "50", "FF" } },
                
                // 0x82 : Stop Communication
                { 0x82, new string[] { "C2", "01" } },
                
                // 0x83 : Access Timing Parameters
                { 0x83, new string[] { "C3", "01", "02", "03" } },
                
                // 0x85 : Start Programming Mode
                { 0x85, new string[] { "C5", "34", "12" } },

                // OBD-II PIDs
                { 0x01, new string[] { "41", "01", "BE", "1F", "B8", "13" } },
                { 0x02, new string[] { "42", "02", "44", "00" } },
                { 0x03, new string[] { "43", "03", "00", "01", "02" } },
                { 0x04, new string[] { "44", "04", "55", "AA" } },
                { 0x05, new string[] { "45", "05", "FF", "00", "AA", "BB" } },
                { 0x06, new string[] { "46", "06", "00", "00", "00", "32" } },
                { 0x07, new string[] { "47", "07", "00", "00", "00", "00", "00", "00" } },
                { 0x08, new string[] { "48", "08", "00", "00", "00", "00" } },
                { 0x09, new string[] { "49", "09", "02", "01", "00", "00", "00" } },
                { 0x0A, new string[] { "4A", "0A", "80" } }
            };
            return responses;
        }

        // Dictionary برای ذخیره داده‌های پاسخ CAN 29-bit
        private Dictionary<int, string[]> GetCAN29BitResponseData()
        {
            var responses = new Dictionary<int, string[]>
            {
                // 0x10 : Start Diagnostic Session
                { 0x10, new string[] { "50", "01" } },
                
                // 0x11 : ECU Reset  
                { 0x11, new string[] { "51", "01" } },
                
                // 0x12 : Read Freeze Frame Data
                { 0x12, new string[] { "52", "01", "02", "03", "04", "05" } },
                
                // 0x13 : Read Diagnostic Trouble Codes
                { 0x13, new string[] { "53", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x14 : Clear Diagnostic Information
                { 0x14, new string[] { "54" } },
                
                // 0x17 : Read Status Of Diagnostic Trouble Codes
                { 0x17, new string[] { "57", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x18 : Read Diagnostic Trouble Codes By Status
                { 0x18, new string[] { "58", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x19 : Read Diagnostic Trouble Codes By Status
                { 0x19, new string[] { "59", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },

                // 0x1A : Read Ecu Id
                { 0x1A, new string[] { "5A", "31", "32", "34", "35", "36", "37", "38", "39", "30", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A" } },
                
                // 0x20 : Stop Diagnostic Session
                { 0x20, new string[] { "60" } },
                
                // 0x21 : Read Data By Local Id
                { 0x21, new string[] { "61", "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x22 : Read Data By Common Id
                { 0x22, new string[] { "62", "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x23 : Read Memory By Address
                { 0x23, new string[] { "63", "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x25 : Stop Repeated Data Transmission
                { 0x25, new string[] { "65", "01" } },
                
                // 0x26 : Set Data Rates
                { 0x26, new string[] { "66", "01" } },
                
                // 0x27 : Security Access
                { 0x27, new string[] { "67", "12", "34", "56", "78" } },
                
                // 0x2C : Dynamically Define Local Id
                { 0x2C, new string[] { "6C", "01" } },
                
                // 0x2E : Write Data By Common Id
                { 0x2E, new string[] { "6E", "01" } },
                
                // 0x2F : Input Output Control By Common Id
                { 0x2F, new string[] { "6F", "01", "02" } },
                
                // 0x30 : Input Output Control By Local Id
                { 0x30, new string[] { "70", "01", "02" } },
                
                // 0x31 : Start Routine By Local ID
                { 0x31, new string[] { "71", "01", "F4" } },
                
                // 0x32 : Stop Routine By Local ID
                { 0x32, new string[] { "72", "01" } },
                
                // 0x33 : Request Routine Results By Local Id
                { 0x33, new string[] { "73", "01", "00", "FF" } },
                
                // 0x34 : Request Download
                { 0x34, new string[] { "74", "01", "01", "01" } },
                
                // 0x35 : Request Upload
                { 0x35, new string[] { "75", "20", "04", "00" } },
                
                // 0x36 : Transfer data
                { 0x36, new string[] { "76", "01" } },
                
                // 0x37 : Request transfer exit
                { 0x37, new string[] { "77" } },
                
                // 0x38 : Start Routine By Address
                { 0x38, new string[] { "78", "01", "F4" } },
                
                // 0x39 : Stop Routine By Address
                { 0x39, new string[] { "79", "01" } },
                
                // 0x3A : Request Routine Results By Address
                { 0x3A, new string[] { "7A", "01", "00", "FF" } },
                
                // 0x3B : Write Data By Local Id
                { 0x3B, new string[] { "7B", "01" } },
                
                // 0x3D : Write Memory By Address
                { 0x3D, new string[] { "7D", "01" } },
                
                // 0x3E : Tester Present
                { 0x3E, new string[] { "7E", "00" } },
                
                // 0x81 : Start Communication
                { 0x81, new string[] { "C1", "F8", "50", "FF" } },
                
                // 0x82 : Stop Communication
                { 0x82, new string[] { "C2", "01" } },
                
                // 0x83 : Access Timing Parameters
                { 0x83, new string[] { "C3", "01", "02", "03" } },
                
                // 0x85 : Start Programming Mode
                { 0x85, new string[] { "C5", "34", "12" } },

                // OBD-II PIDs
                { 0x01, new string[] { "41", "01", "BE", "1F", "B8", "13" } },
                { 0x02, new string[] { "42", "02", "44", "00" } },
                { 0x03, new string[] { "43", "03", "00", "01", "02" } },
                { 0x04, new string[] { "44", "04", "55", "AA" } },
                { 0x05, new string[] { "45", "05", "FF", "00", "AA", "BB" } },
                { 0x06, new string[] { "46", "06", "00", "00", "00", "32" } },
                { 0x07, new string[] { "47", "07", "00", "00", "00", "00", "00", "00" } },
                { 0x08, new string[] { "48", "08", "00", "00", "00", "00" } },
                { 0x09, new string[] { "49", "09", "02", "01", "00", "00", "00" } },
                { 0x0A, new string[] { "4A", "0A", "80" } }
            };
            return responses;
        }

        // Dictionary برای ذخیره داده‌های پاسخ هر SID
        private Dictionary<int, string[]> GetKWPResponseData()
        {
            var responses = new Dictionary<int, string[]>
            {
                // 0x10 : Start Diagnostic Session
                { 0x10, new string[] { "01" } },
                
                // 0x11 : ECU Reset  
                { 0x11, new string[] { "01" } },
                
                // 0x12 : Read Freeze Frame Data
                { 0x12, new string[] { "01", "02", "03", "04", "05" } },
                
                // 0x13 : Read Diagnostic Trouble Codes
                { 0x13, new string[] { "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x14 : Clear Diagnostic Information
                { 0x14, new string[] { "FF" } },
                
                // 0x17 : Read Status Of Diagnostic Trouble Codes
                { 0x17, new string[] { "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x18 : Read Diagnostic Trouble Codes By Status
                { 0x18, new string[] { "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x19 : Read Diagnostic Trouble Codes By Status
                { 0x19, new string[] { "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },

                // 0x1A : Read Ecu Id
                { 0x1A, new string[] { "31", "32", "34", "35", "36", "37", "38", "39", "30", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A" } },
                
                // 0x20 : Stop Diagnostic Session
                { 0x20, new string[] { "01" } },
                
                // 0x21 : Read Data By Local Id
                { 0x21, new string[] { "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x22 : Read Data By Common Id
                { 0x22, new string[] { "31", "32", "34", "35", "36", "37", "38", "39", "30" } },
                
                // 0x23 : Read Memory By Address
                { 0x23, new string[] { "31", "32", "33", "34", "35", "36", "37", "38", "35", "36", "37", "38" } },
                
                // 0x25 : Stop Repeated Data Transmission
                { 0x25, new string[] { "01" } },
                
                // 0x26 : Set Data Rates
                { 0x26, new string[] { "01" } },
                
                // 0x27 : Security Access
                { 0x27, new string[] { "12", "34", "56", "78" } },
                
                // 0x2C : Dynamically Define Local Id
                { 0x2C, new string[] { "01" } },
                
                // 0x2E : Write Data By Common Id
                { 0x2E, new string[] { "01" } },
                
                // 0x2F : Input Output Control By Common Id
                { 0x2F, new string[] { "01", "02" } },
                
                // 0x30 : Input Output Control By Local Id
                { 0x30, new string[] { "01", "02" } },
                
                // 0x31 : Start Routine By Local ID
                { 0x31, new string[] { "01", "F4" } },
                
                // 0x32 : Stop Routine By Local ID
                { 0x32, new string[] { "01" } },
                
                // 0x33 : Request Routine Results By Local Id
                { 0x33, new string[] { "01", "00", "FF" } },
                
                // 0x34 : Request Download
                { 0x34, new string[] { "01", "01", "01" } },
                
                // 0x35 : Request Upload
                { 0x35, new string[] { "20", "04", "00" } },
                
                // 0x36 : Transfer data
                { 0x36, new string[] { "01" } },
                
                // 0x37 : Request transfer exit
                { 0x37, new string[] { "01" } },
                
                // 0x38 : Start Routine By Address
                { 0x38, new string[] { "01", "F4" } },
                
                // 0x39 : Stop Routine By Address
                { 0x39, new string[] { "01" } },
                
                // 0x3A : Request Routine Results By Address
                { 0x3A, new string[] { "01", "00", "FF" } },
                
                // 0x3B : Write Data By Local Id
                { 0x3B, new string[] { "01" } },
                
                // 0x3D : Write Memory By Address
                { 0x3D, new string[] { "01" } },
                
                // 0x3E : Tester Present
                { 0x3E, new string[] { "00" } },
                
                // 0x81 : Start Communication
                { 0x81, new string[] { "F8", "50", "FF" } },
                
                // 0x82 : Stop Communication
                { 0x82, new string[] { "01" } },
                
                // 0x83 : Access Timing Parameters
                { 0x83, new string[] { "01", "02", "03" } },
                
                // 0x85 : Start Programming Mode
                { 0x85, new string[] { "34", "12" } },

                // 0xA3 : Unknown SID
                { 0xA3, new string[] { "34", "12" } }
            };
            
            return responses;
        }

        // متد تولید response واقعی CAN
        private string GenerateCANResponse(string requestBytes, CANInfo canInfo = null)
        {
            try
            {
                // پارس کردن request
                string[] requestHex = requestBytes.Split(',');
                if (requestHex.Length < 1) return requestBytes;
                
                // اولین بایت در data معمولاً service ID است
                int service = Convert.ToInt32(requestHex[0], 16);
                
                // انتخاب Dictionary بر اساس نوع CAN
                Dictionary<int, string[]> responseDataDict;
                if (canInfo != null && canInfo.Is29Bit)
                {
                    responseDataDict = GetCAN29BitResponseData();
                }
                else
                {
                    responseDataDict = GetCAN11BitResponseData();
                }
                
                string[] responseData = responseDataDict.ContainsKey(service) 
                    ? responseDataDict[service] 
                    : new string[] { (service + 0x40).ToString("X2"), "AA", "BB", "CC" }; // پیش‌فرض
                
                return string.Join(",", responseData);
            }
            catch
            {
                return requestBytes;
            }
        }

        // متد تشخیص نوع مدل KWP
        private int DetectKWPModel(string[] requestBytes)
        {
            try
            {
                if (requestBytes.Length < 1) return 3; // Default to Model 3

                int firstByte = Convert.ToInt32(requestBytes[0], 16);

                // Model 2: (0x80) + target + source + Length + SID + data + checksum
                if (firstByte == 0x80 && requestBytes.Length >= 5)
                {
                    return 2;
                }

                // Model 1: (0x80+Length) + target + source + SID + data + checksum
                if (firstByte > 0x80 && requestBytes.Length >= 4)
                {
                    return 1;
                }

                // Model 3: Length + SID + data + checksum
                return 3;
            }
            catch
            {
                return 3; // Default to Model 3
            }
        }

        // متد تولید response برای مدل 1 KWP
        private string GenerateKWPResponseModel1(string[] requestBytes)
        {
            try
            {
                if (requestBytes.Length < 4) return string.Join(",", requestBytes);
                
                // استخراج اجزای فریم: (0x80+Length) + target + source + SID + data + checksum
                int lengthByte = Convert.ToInt32(requestBytes[0], 16);
                int target = Convert.ToInt32(requestBytes[1], 16);
                int source = Convert.ToInt32(requestBytes[2], 16);
                int service = Convert.ToInt32(requestBytes[3], 16);
                
                // محاسبه length واقعی
                int actualLength = lengthByte - 0x80;
                
                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData = responseDataDict.ContainsKey(service) 
                    ? responseDataDict[service] 
                    : new string[] { "30", "45", "56" }; // پیش‌فرض
                
                // ساخت response: (0x80+Length) + source + target + (SID+0x40) + data + checksum
                List<string> response = new List<string>();
                
                // محاسبه length جدید برای response
                int responseLength = 1 + responseData.Length; // (SID+0x40) + data
                response.Add((0x80 + responseLength).ToString("X2")); // (0x80+Length)
                response.Add(source.ToString("X2")); // Source و Target جابجا
                response.Add(target.ToString("X2"));
                response.Add((service + 0x40).ToString("X2")); // Positive response
                response.AddRange(responseData); // Data
                
                // محاسبه checksum (XOR همه بایت‌ها)
                int checksum = 0;
                foreach (string byteStr in response)
                {
                    if (int.TryParse(byteStr, NumberStyles.HexNumber, null, out int byteVal))
                    {
                        checksum ^= byteVal;
                    }
                }
                response.Add(checksum.ToString("X2")); // Checksum در انتها
                
                return string.Join(",", response);
            }
            catch
            {
                return string.Join(",", requestBytes);
            }
        }

        // متد تولید response برای مدل 2 KWP
        private string GenerateKWPResponseModel2(string[] requestBytes)
        {
            try
            {
                if (requestBytes.Length < 5) return string.Join(",", requestBytes);
                
                // استخراج اجزای فریم: (0x80) + target + source + Length + SID + data + checksum
                int target = Convert.ToInt32(requestBytes[1], 16);
                int source = Convert.ToInt32(requestBytes[2], 16);
                int length = Convert.ToInt32(requestBytes[3], 16);
                int service = Convert.ToInt32(requestBytes[4], 16);
                
                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData = responseDataDict.ContainsKey(service) 
                    ? responseDataDict[service] 
                    : new string[] { "30", "45", "56" }; // پیش‌فرض
                
                // ساخت response: (0x80) + source + target + Length + (SID+0x40) + data + checksum
                List<string> response = new List<string>();
                
                response.Add("80"); // (0x80)
                response.Add(source.ToString("X2")); // Source (swapped)
                response.Add(target.ToString("X2")); // Target (swapped)
                
                // محاسبه length جدید برای response
                int responseLength = 1 + responseData.Length; // SID + data
                response.Add(responseLength.ToString("X2")); // Length
                response.Add((service + 0x40).ToString("X2")); // Positive response
                response.AddRange(responseData); // Data
                
                // محاسبه checksum (XOR همه بایت‌ها)
                int checksum = 0;
                foreach (string byteStr in response)
                {
                    if (int.TryParse(byteStr, NumberStyles.HexNumber, null, out int byteVal))
                    {
                        checksum ^= byteVal;
                    }
                }
                response.Add(checksum.ToString("X2")); // Checksum در انتها
                
                return string.Join(",", response);
            }
            catch
            {
                return string.Join(",", requestBytes);
            }
        }

        // متد تولید response برای مدل 3 KWP
                private string GenerateKWPResponseModel3(string[] requestBytes)
        {
            try
            {
                if (requestBytes.Length < 1) return string.Join(",", requestBytes);

                // استخراج اجزای فریم: SID + data (بعد از حذف length در ConvertToXscriptFormat)
                int service = Convert.ToInt32(requestBytes[0], 16);

                // Debug: برای بررسی مقادیر
                // System.Diagnostics.Debug.WriteLine($"KWP Model 3 - Service: {service:X2}, Length: {requestBytes.Length}");

                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData;

                // برای همه SID های KWP مدل 3، داده‌های پاسخ باید شامل پارامترهای درخواست باشه
                if (requestBytes.Length > 1)
                {
                    // داده‌های پاسخ = پارامترهای درخواست + داده‌های پیش‌فرض
                    string[] requestData = new string[requestBytes.Length - 1];
                    for (int i = 1; i < requestBytes.Length; i++)
                    {
                        requestData[i - 1] = requestBytes[i]; // کپی داده‌های درخواست
                    }

                    // اضافه کردن داده‌های پاسخ: پارامترهای درخواست + داده‌های اضافی
                    responseData = new string[requestData.Length + 3]; // request data + 3 bytes
                    Array.Copy(requestData, responseData, requestData.Length); // کپی پارامترهای درخواست

                    // تبدیل SID به SID+0x40 برای پاسخ
                    int sidValue = Convert.ToInt32(responseData[0], 16);
                    //int sidPlus40 = sidValue + 0x40;
                    //responseData[0] = sidPlus40.ToString("X2");
                    service = sidValue;
                    responseData[requestData.Length] = "45"; // اضافه کردن داده‌های اضافی
                    responseData[requestData.Length + 1] = "30";
                    responseData[requestData.Length + 2] = "45";
                }
                else
                {
                    responseData = responseDataDict.ContainsKey(service)
                        ? responseDataDict[service]
                        : new string[] { "30", "45", "56" }; // پیش‌فرض
                }

                // ساخت response: Length + (SID+0x40) + data + checksum
                List<string> response = new List<string>();

                // محاسبه length جدید برای response
                int responseLength = 1 + responseData.Length; // (SID+0x40) + data
                response.Add(responseLength.ToString("X2")); // Length
                response.Add((service + 0x40).ToString("X2")); // Positive response (SID+0x40)
                response.AddRange(responseData); // Data

                // محاسبه checksum (XOR همه بایت‌ها)
                int checksum = 0;
                foreach (string byteStr in response)
                {
                    if (int.TryParse(byteStr, NumberStyles.HexNumber, null, out int byteVal))
                    {
                        checksum ^= byteVal;
                    }
                }
                response.Add(checksum.ToString("X2")); // Checksum در انتها

                return string.Join(",", response);
            }
            catch
            {
                return string.Join(",", requestBytes);
            }
        }

        // متد تولید response واقعی KWP - جدید
        private string GenerateKWPResponse(string requestBytes, bool isKWPWithAddressing)
        {
            try
            {
                // پارس کردن request
                string[] requestHex = requestBytes.Split(',');
                if (requestHex.Length < 1) return requestBytes;
                
                // تشخیص نوع مدل KWP
                int kwpModel = DetectKWPModel(requestHex);
                
                switch (kwpModel)
                {
                    case 1:
                        return GenerateKWPResponseModel1(requestHex);
                    case 2:
                        return GenerateKWPResponseModel2(requestHex);
                    case 3:
                    default:
                        return GenerateKWPResponseModel3(requestHex);
                }
            }
            catch
            {
                return requestBytes;
            }
        }

        // متد تولید response برای KWP با target/source addressing - قدیمی (حذف شود)
        private string GenerateKWPResponseWithAddressing(string[] requestHex)
        {
            try
            {
                if (requestHex.Length < 3) return string.Join(",", requestHex);
                
                // استخراج اجزای KWP از request (که قبلاً length حذف شده)
                int target = Convert.ToInt32(requestHex[0], 16);
                int source = Convert.ToInt32(requestHex[1], 16);
                int service = Convert.ToInt32(requestHex[2], 16);
                
                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData = responseDataDict.ContainsKey(service) 
                    ? responseDataDict[service] 
                    : new string[] { "F8", "50", "FF" }; // پیش‌فرض
                
                // ساخت response ساده: target, source, positive service, data
                List<string> response = new List<string>();
                response.Add(source.ToString("X2")); // Source و Target جابجا
                response.Add(target.ToString("X2"));
                response.Add((service + 0x40).ToString("X2")); // Positive response
                
                // اضافه کردن داده‌های پاسخ
                response.AddRange(responseData);
                
                return string.Join(",", response);
            }
            catch
            {
                return string.Join(",", requestHex);
            }
        }

        // متد تولید response برای KWP بدون target/source addressing - قدیمی (حذف شود)
        private string GenerateKWPResponseWithoutAddressing(string[] requestHex)
        {
            try
            {
                if (requestHex.Length < 1) return string.Join(",", requestHex);
                
                // استخراج service ID (که قبلاً length حذف شده)
                int service = Convert.ToInt32(requestHex[0], 16);
                
                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData = responseDataDict.ContainsKey(service) 
                    ? responseDataDict[service] 
                    : new string[] { "30", "45", "56" }; // پیش‌فرض
                
                // ساخت response کامل: length + positive service + data + checksum
                List<string> response = new List<string>();
                
                // اضافه کردن positive service + data
                response.Add((service + 0x40).ToString("X2")); // Positive response
                response.AddRange(responseData); // Data
                
                // محاسبه length (تعداد بایت‌های data + 1 برای service)
                int length = response.Count;
                response.Insert(0, length.ToString("X2")); // Length در ابتدا
                
                // محاسبه checksum (XOR همه بایت‌ها)
                int checksum = 0;
                foreach (string byteStr in response)
                {
                    if (int.TryParse(byteStr, NumberStyles.HexNumber, null, out int byteVal))
                    {
                        checksum ^= byteVal;
                    }
                }
                response.Add(checksum.ToString("X2")); // Checksum در انتها
                
                return string.Join(",", response);
            }
            catch
            {
                return string.Join(",", requestHex);
            }
        }

        // متد تولید response برای KWP frame (بدون تغییر در فریم اصلی)
        private string GenerateKWPResponseForKWPFrame(string requestBytes)
        {
            try
            {
                string[] requestHex = requestBytes.Split(',');
                if (requestHex.Length < 1) return requestBytes;

                // استخراج service ID (اولین بایت)
                int service = Convert.ToInt32(requestHex[1], 16);

                // دریافت داده‌های پاسخ برای این SID
                var responseDataDict = GetKWPResponseData();
                string[] responseData = responseDataDict.ContainsKey(service)
                    ? responseDataDict[service]
                    : new string[] { "30", "45", "56" }; // پیش‌فرض

                // ساخت response: Length + (SID+0x40) + data + checksum
                List<string> response = new List<string>();

                // محاسبه length: (SID+0x40) + data (checksum جدا حساب میشه)
                int responseLength = 1 + responseData.Length; // (SID+0x40) + تعداد بایت داده
                response.Add(responseLength.ToString("X2")); // Length byte
                response.Add((service + 0x40).ToString("X2")); // Positive response (SID+0x40)
                response.AddRange(responseData); // Data

                // محاسبه checksum (XOR همه بایت‌ها به جز خود checksum)
                int checksum = 0;
                foreach (string byteStr in response)
                {
                    if (int.TryParse(byteStr, NumberStyles.HexNumber, null, out int byteVal))
                    {
                        checksum ^= byteVal;
                    }
                }
                response.Add(checksum.ToString("X2")); // Checksum در انتها

                return string.Join(",", response);
            }
            catch
            {
                return requestBytes;
            }
        }

        //=========================================================================================
        private void frmlen_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();
            if (converttextBox.Text == string.Empty)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "Input Data Invalid";
            }
            else
                f.frm_len(converttextBox.Text);
        }//find frame len
        //=========================================================================================
        private void logtoout_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();
            if (tBoxcanid.Text != string.Empty)
            {
                f.convertlog(1);
                //resultlabel.BackColor = Color.Red;
                //resultlabel.Text = "Input Data Invalid";
            }
            else
            {
                f.convertlog(2);
            }
        }//convert log file to other file format
        //=========================================================================================
        private void getdanacode_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();
            if (converttextBox.Text == string.Empty)
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "Input Data Invalid";
            }
            else
            {
                f.danacodes();
            }
        }
        
        //=========================================================================================
        //=================================== LOG FILTER ==========================================
        //=========================================================================================
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // بررسی می‌کند که آیا تب سوم (اندیس 2) انتخاب شده است
            if (tabControl1.SelectedIndex == 2 || tabControl1.SelectedIndex == 3)
            {
                this.Width = 900;
                this.Height = 600;
                resultlabel.Visible = false;
                tabControl1.Width = 875;
                tabControl1.Height = 540;
            }
            else
            {
                this.Width = 600;
                this.Height = 400;
                resultlabel.Visible = true;
                tabControl1.Width = 576;
                tabControl1.Height = 340;
            }
        }
        private void btnloadfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            //openFile1.Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*";
            openFile1.Filter = "All Text Files|*.txt;*.log;*.csv;*.csv;*.c;*.h;*.json|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (!string.IsNullOrEmpty(globalPath))
                openFile1.InitialDirectory = Path.GetDirectoryName(globalPath);
            else
                openFile1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            openFile1.FileName = Path.GetFileName(globalPath);

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    globalPath = openFile1.FileName;
                    var lines = File.ReadAllLines(globalPath);
                    StringBuilder contentWithLineNumbers = new StringBuilder();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        contentWithLineNumbers.AppendLine($"({i + 1})\t{lines[i]}");
                    }
                    txtbshowdata.Text = contentWithLineNumbers.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error read file:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsetfilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbinputdata.Text))
            {
                string[] lines = txtbinputdata.Text.Split(new char[] { '\n' }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine))
                    {
                        if (addedItems.Add(trimmedLine))
                        {
                            listbadddata.Items.Add(trimmedLine);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a keyword.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EnsureFileSelected())
            {
                // بررسی وضعیت چک‌باکس‌ها و اعمال عملکرد مناسب
                ApplyCurrentFilter();
            }
        }

        private void btnremovefilter_Click(object sender, EventArgs e)
        {
            if (listbadddata.SelectedItem != null)
            {
                string selectedItem = listbadddata.SelectedItem.ToString();
                listbadddata.Items.Remove(listbadddata.SelectedItem);
                addedItems.Remove(selectedItem); // حذف از HashSet برای امکان اضافه کردن مجدد

                // دوباره جستجو کن و نتایج رو به‌روز کن
                if (chboxshowfil.Checked && !string.IsNullOrEmpty(globalPath))
                {
                    PerformSearch(globalPath);
                }
                else if (chboxhidefil.Checked && !string.IsNullOrEmpty(globalPath))
                {
                    RemoveLinesWithPhrases(globalPath);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool EnsureFileSelected()
        {
            if (!string.IsNullOrEmpty(globalPath))
                return true;

            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*";

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFile1.FileName;
                return true;
            }

            return false;
        }
        private void PerformSearch(string filePath)
        {
            try
            {
                txtbshowdata.Clear();
                txtbshowdata.Text = "plz wait...";
                this.Refresh();
                var allLines = File.ReadAllLines(filePath);
                List<string> matchedLinesWithNumber = new List<string>();

                if (listbadddata.Items.Count == 0)
                {
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        matchedLinesWithNumber.Add($"({i + 1})\t{allLines[i]}");
                    }
                }
                else
                {
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        string line = allLines[i];

                        foreach (string keyword in listbadddata.Items)
                        {
                            if (line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                matchedLinesWithNumber.Add($"({i + 1})\t{line}");
                                break;
                            }
                        }
                    }
                }

                txtbshowdata.Lines = matchedLinesWithNumber.ToArray();

                if (matchedLinesWithNumber.Count == 0)
                {
                    txtbshowdata.Text = "No matching lines found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        private void RemoveLinesWithPhrases(string filePath)
        {
            try
            {
                txtbshowdata.Clear();
                txtbshowdata.Text = "Please wait...";
                this.Refresh();
                var allLines = File.ReadAllLines(filePath);
                List<string> remainingLinesWithNumber = new List<string>();
                for (int i = 0; i < allLines.Length; i++)
                {
                    string line = allLines[i];
                    bool containsPhrase = false;
                    foreach (string phrase in listbadddata.Items)
                    {
                        if (line.IndexOf(phrase.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            containsPhrase = true;
                            break;
                        }
                    }
                    if (!containsPhrase)
                    {
                        remainingLinesWithNumber.Add($"({i + 1})\t{line}");
                    }
                }
                txtbshowdata.Lines = remainingLinesWithNumber.ToArray();

                if (remainingLinesWithNumber.Count == 0)
                {
                    txtbshowdata.Text = "No lines left after removal.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing file: " + ex.Message);
            }
        }

        private void btnlimitshow_Click(object sender, EventArgs e)
        {
            /*string input = txtbinputdata.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                listbadddata.Items.Add(input);
                txtbinputdata.Clear();
                txtbinputdata.Focus();
            }*/
            if (!string.IsNullOrEmpty(txtbinputdata.Text))
            {
                string[] lines = txtbinputdata.Text.Split(new char[] { '\n' }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine))
                    {
                        if (addedItems.Add(trimmedLine))
                        {
                            listbadddata.Items.Add(trimmedLine);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a keyword.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EnsureFileSelected())
            {
                RemoveLinesWithPhrases(globalPath);
            }
        }

        private void btnclearallfilter_Click(object sender, EventArgs e)
        {
            if (listbadddata.Items.Count > 0)
            {
                listbadddata.Items.Clear();
                addedItems.Clear(); // پاک کردن HashSet برای امکان اضافه کردن مجدد آیتم‌ها
                if (!string.IsNullOrEmpty(globalPath))
                {
                    PerformSearch(globalPath);
                }
            }
            else
            {
                MessageBox.Show("The filter list is already empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chboxshowfil_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxshowfil.Checked)
            {
                // غیرفعال کردن چک‌باکس مخالف
                chboxhidefil.Checked = false;
                // اعمال فیلتر نمایش
                ApplyCurrentFilter();
            }
            else
            {
                // اگر هر دو چک‌باکس غیرفعال شدند، نمایش کل داده‌ها
                if (!chboxhidefil.Checked)
                {
                    ShowAllData();
                }
            }
        }

        private void chboxhidefil_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxhidefil.Checked)
            {
                // غیرفعال کردن چک‌باکس مخالف
                chboxshowfil.Checked = false;
                // اعمال فیلتر مخفی‌سازی
                ApplyCurrentFilter();
            }
            else
            {
                // اگر هر دو چک‌باکس غیرفعال شدند، نمایش کل داده‌ها
                if (!chboxshowfil.Checked)
                {
                    ShowAllData();
                }
            }
        }

        private void ApplyCurrentFilter()
        {
            if (!string.IsNullOrEmpty(globalPath))
            {
                if (chboxshowfil.Checked)
                {
                    // نمایش فقط خطوط دارای فیلتر
                    PerformSearch(globalPath);
                }
                else if (chboxhidefil.Checked)
                {
                    // مخفی کردن خطوط دارای فیلتر
                    RemoveLinesWithPhrases(globalPath);
                }
                else
                {
                    // اگر هیچ چک‌باکسی فعال نیست، نمایش کل داده‌ها
                    ShowAllData();
                }
            }
        }

        private void ShowAllData()
        {
            if (!string.IsNullOrEmpty(globalPath))
            {
                try
                {
                    txtbshowdata.Clear();
                    txtbshowdata.Text = "Loading all data...";
                    this.Refresh();
                    
                    // خواندن کل فایل بدون فیلتر
                    var allLines = File.ReadAllLines(globalPath);
                    List<string> allLinesWithNumber = new List<string>();

                    for (int i = 0; i < allLines.Length; i++)
                    {
                        allLinesWithNumber.Add($"({i + 1})\t{allLines[i]}");
                    }

                    txtbshowdata.Lines = allLinesWithNumber.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading all data: " + ex.Message);
                }
            }
        }

        //=========================================================================================
        //===================================== FIND DTC ==========================================
        //=========================================================================================
        private void btnfinddtc_Click(object sender, EventArgs e)
        {
            List<string> jcfile_path = new List<string>();
            if (!string.IsNullOrEmpty(globalFolderPath))
            {
                jcfile_path = get_alljc_path(globalFolderPath, textBox4.Text);//"fault.jc"
                SaveListToFile(jcfile_path, globalFolderPath);
                SearchInFaultFiles(textBox3.Text, globalFolderPath);
                File.Delete(globalFolderPath + "\\file01.txt");
                ExportDTCsToFile();
            }
            else
            {
                MessageBox.Show("Please Select Script Path!");
            }
        }
        private void btnalldtc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(globalFolderPath))
            {
                SearchAllDTC(globalFolderPath);
                File.Delete(globalFolderPath + "\\file01.txt");
            }
            else
            {
                MessageBox.Show("Please Select Script Path!");
            }
        }

        private void btnFolderPath_Click(object sender, EventArgs e)
        {
            globalFolderPath = select_folderbrowser();
        }

        public string select_folderbrowser()
        {
            FolderBrowserDialog jcfile = new FolderBrowserDialog();
            string path = "";
            //-----------------------------------
            if (jcfile.ShowDialog() == DialogResult.OK)
            {
                jcfile.Description = "Please Select Script Path!";
                //jcfile.SelectedPath = @"C:\";
                path = jcfile.SelectedPath;
            }
            else
            {
                resultlabel.BackColor = Color.Red;
                resultlabel.Text = "Cancel Script To Sim Proccess";
                return null;
            }

            return path;
        }//select folder browser path
        
        public List<string> get_alljc_path(string s1, string s2)
        {
            List<string> jcfile_path = new List<string>();
            string scpath = s1;
            //-----------------------------------
            try
            {
                jcfile_path.AddRange(Directory.GetFiles(scpath, s2, SearchOption.AllDirectories));
                return jcfile_path;
            }
            catch
            {
                MessageBox.Show("Input file name or extension invalid!");
                return null;
            }
        }//get all .jc path

        public void SaveListToFile(List<string> items, string folderPath)
        {
            if (items == null || items.Count == 0)
            {
                MessageBox.Show("Path List is Empty!");
                return;
            }

            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Path Invalid!");
                return;
            }

            try
            {
                string filePath = Path.Combine(folderPath, "file01.txt");

                // ذخیره لیست خط به خط در فایل
                File.WriteAllLines(filePath, items);

                //MessageBox.Show($"فایل با موفقیت در مسیر زیر ذخیره شد:\n{filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in File Saving: " + ex.Message);
            }
        }

        public void SearchInFaultFiles(string searchText, string folderPath)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Plz wait...");
            this.Refresh();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please Input Search Data");
                return;
            }

            string file01Path = Path.Combine(folderPath, "file01.txt");

            if (!File.Exists(file01Path))
            {
                MessageBox.Show("Can Not Find file01.txt");
                return;
            }

            try
            {
                List<string> foundResults = new List<string>();
                string[] filePaths = File.ReadAllLines(file01Path);
                int totalMatches = 0;
                
                // پاک کردن لیست باکس و آرایه مسیرها
                listBox1.Items.Clear();
                filePathsArray.Clear();

                foreach (string filePath in filePaths)
                {
                    if (!File.Exists(filePath))
                    {
                        continue;
                    }

                    string[] lines = File.ReadAllLines(filePath);
                    bool fileHasMatch = false;
                    StringBuilder fileMatches = new StringBuilder();

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            // اضافه کردن مسیر فایل به آرایه
                            filePathsArray.Add(filePath);
                            
                            if (!fileHasMatch)
                            {
                                fileHasMatch = true;
                            }
                            // حذف تب‌ها از خط
                            string cleanLine = lines[i].Replace("\t", "");
                            cleanLine = cleanLine.Replace(": ", ":");
                            cleanLine = cleanLine.Replace(" :", ":");
                            fileMatches.AppendLine($"({totalMatches + 1}) Line {i + 1}: {cleanLine}");
                            totalMatches++;
                        }
                    }

                    if (fileHasMatch)
                    {
                        foundResults.Add(fileMatches.ToString());
                    }
                }

                if (foundResults.Count > 0)
                {
                    // اضافه کردن نتایج مستقیماً به listBox1
                    AddResultsToListBox(foundResults);
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("رشته مورد نظر در هیچ کدام از فایل‌ها یافت نشد.");
                    filePathsArray.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در انجام عملیات: " + ex.Message);
            }
        }

        public void SearchAllDTC(string folderPath)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Plz wait...");
            this.Refresh();

            try
            {
                List<string> foundResults = new List<string>();
                int totalMatches = 0;
                
                // پاک کردن لیست باکس و آرایه مسیرها
                listBox1.Items.Clear();
                filePathsArray.Clear();

                // پیدا کردن تمام فایل‌های fault.jc
                string[] faultFiles = Directory.GetFiles(folderPath, "fault.jc", SearchOption.AllDirectories);

                foreach (string filePath in faultFiles)
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool fileHasMatch = false;
                    StringBuilder fileMatches = new StringBuilder();

                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i].Trim();
                        // بررسی وجود ":" و عدم وجود الگوهای ناخواسته
                        if (line.Contains(":") && 
                            !line.Contains("select(") && 
                            !line.Contains("if(") && 
                            !line.Contains("while(") && 
                            !line.Contains("for(") && 
                            !line.Contains("function(") &&
                            !line.Contains("return") &&
                            !line.Contains("break") &&
                            !line.Contains("continue")&&
                            !line.Contains(":\"P\"")&&
                            !line.Contains(":\"C\"")&&
                            !line.Contains(":\"B\"")&&
                            !line.Contains(":\"U\"")&&
                            !line.Contains(":\"P0\"") &&
                            !line.Contains(":\"P1\"") &&
                            !line.Contains(":\"P2\"") &&
                            !line.Contains(":\"P3\"") &&
                            !line.Contains(":\"C0\"") &&
                            !line.Contains(":\"C1\"") &&
                            !line.Contains(":\"C2\"") &&
                            !line.Contains(":\"C3\"") &&
                            !line.Contains(":\"B0\"") &&
                            !line.Contains(":\"B1\"") &&
                            !line.Contains(":\"B2\"") &&
                            !line.Contains(":\"B3\"") &&
                            !line.Contains(":\"U0\"") &&
                            !line.Contains(":\"U1\"") &&
                            !line.Contains(":\"U2\"") &&
                            !line.Contains(":\"U3\"") &&
                            !line.Contains(":\"0\"") &&
                            !line.Contains(":\"1\"") &&
                            !line.Contains(":\"2\"") &&
                            !line.Contains(":\"3\"") &&
                            !line.Contains(":\"4\"") &&
                            !line.Contains(":\"5\"") &&
                            !line.Contains(":\"6\"") &&
                            !line.Contains(":\"7\"") &&
                            !line.Contains(":\"8\"") &&
                            !line.Contains(":\"9\"") &&
                            !line.Contains(":\"A\"") &&
                            !line.Contains(":\"D\"") &&
                            !line.Contains(":\"E\"") &&
                            !line.Contains(":\"F\""))
                        {
                            // اضافه کردن مسیر فایل به آرایه
                            filePathsArray.Add(filePath);

                            if (!fileHasMatch)
                            {
                                fileHasMatch = true;
                            }

                            // حذف تب‌ها و فضاهای اضافی
                            string cleanLine = line.Replace("\t", "");
                            cleanLine = cleanLine.Replace(": ", ":");
                            cleanLine = cleanLine.Replace(" :", ":");
                            fileMatches.AppendLine($"({totalMatches + 1}) Line {i + 1}: {cleanLine}");
                            totalMatches++;
                        }
                    }

                    if (fileHasMatch)
                    {
                        foundResults.Add(fileMatches.ToString());
                    }
                }

                if (foundResults.Count > 0)
                {
                    // اضافه کردن نتایج مستقیماً به listBox1
                    AddResultsToListBox(foundResults);
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Can Not Find DTC");
                    filePathsArray.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        //=========================================================================================
        //=========================================================================================
        //=========================================================================================


        //=========================================================================================
        //=============================== LOG CONVERTER AREA ======================================
        //=========================================================================================
        //=========================================================================================
        //=============================== EXPORT DTCs TO FILE ====================================
        //=========================================================================================
        public void ExportDTCsToFile()
        {
            if (!chBox1.Checked) return;
            try
            {
                // Desktop path
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "DTC_Export.txt");

                // Get suffix from textBox5 (if empty, no suffix will be added)
                string suffix = textBox5.Text.Trim();
                
                // Validate suffix (max 2 bytes = 4 hex chars)
                if (!string.IsNullOrEmpty(suffix))
                {
                    // Remove 0x prefix if exists
                    if (suffix.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                        suffix = suffix.Substring(2);
                    
                    // Check if valid hex and max 4 characters (2 bytes)
                    if (suffix.Length > 4 || !Regex.IsMatch(suffix, @"^[0-9A-Fa-f]*$"))
                    {
                        MessageBox.Show("مقدار textBox5 باید حداکثر 2 بایت (4 کاراکتر هگز) باشد!");
                        return;
                    }
                }

                // تحلیل فایل‌ها و استخراج کدهای خطا
                var lines = new List<string>();
                var processedFiles = new HashSet<string>(); // برای جلوگیری از تکرار فایل‌ها

                // پردازش هر آیتم در لیست‌باکس
                for (int i = 0; i < listBox1.Items.Count && i < filePathsArray.Count; i++)
                {
                    string currentFilePath = filePathsArray[i];
                    
                    // اگر این فایل قبلاً پردازش شده، رد کن
                    if (processedFiles.Contains(currentFilePath))
                        continue;
                        
                    // اضافه کردن به فایل‌های پردازش شده
                    processedFiles.Add(currentFilePath);
                    
                    // تحلیل فایل و استخراج کدهای خطا
                    var fileDTCs = AnalyzeFileForDTCs(currentFilePath, suffix);
                    
                    if (fileDTCs.Count > 0)
                    {
                        // ایجاد کامنت از مسیر کامل فایل
                        lines.Add($"//{currentFilePath}");
                        
                        // اضافه کردن کدهای خطا در یک خط
                        lines.Add(string.Join(",", fileDTCs));
                        lines.Add(""); // خط خالی برای جداسازی
                    }
                }

                // اگر هیچ کدی پیدا نشد
                if (lines.Count == 0)
                {
                    lines.Add("// No DTC codes found in any files");
                }

                File.WriteAllLines(filePath, lines);
                MessageBox.Show($"فایل DTC با موفقیت در دسکتاپ ذخیره شد:\n{filePath}", "Export DTC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ذخیره فایل DTC: " + ex.Message);
            }
        }

        //=========================================================================================
        //=============================== LISTBOX HELPER METHODS ===============================
        //=========================================================================================
        
        private string GetListBoxContentAsString()
        {
            try
            {
                StringBuilder content = new StringBuilder();
                
                foreach (var item in listBox1.Items)
                {
                    content.AppendLine(item.ToString());
                }
                
                return content.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private void AddResultsToListBox(List<string> foundResults)
        {
            try
            {
                // پاک کردن لیست باکس
                listBox1.Items.Clear();
                
                // اضافه کردن هر نتیجه به listBox1
                foreach (string result in foundResults)
                {
                    // تقسیم نتیجه به خطوط
                    string[] lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            listBox1.Items.Add(line.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding results to listBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<string> FormatDTCCodes(List<string> codes, int codesPerLine)
        {
            var formattedLines = new List<string>();
            
            try
            {
                for (int i = 0; i < codes.Count; i += codesPerLine)
                {
                    // گرفتن تا 50 کد (یا باقی‌مانده کدها)
                    var chunk = codes.Skip(i).Take(codesPerLine);
                    
                    // ترکیب کدها با کاما
                    string line = string.Join(",", chunk);
                    
                    formattedLines.Add(line);
                }
            }
            catch (Exception ex)
            {
                // در صورت خطا، همه کدها را در یک خط قرار بده
                formattedLines.Add(string.Join(",", codes));
            }
            
            return formattedLines;
        }

        private List<string> AnalyzeFileForDTCs(string filePath, string suffix)
        {
            var dtcCodes = new List<string>();
            
            try
            {
                if (!File.Exists(filePath))
                    return dtcCodes;

                string[] lines = File.ReadAllLines(filePath);
                
                foreach (string line in lines)
                {
                    // جستجوی pattern کدهای خطا: 0x....:
                    var matches = Regex.Matches(line, @"0x([0-9A-Fa-f]{4,8}):");
                    
                    foreach (Match match in matches)
                    {
                        string hex = match.Groups[1].Value;
                        // اضافه کردن suffix اگر وجود دارد
                        string code = hex + suffix;
                        
                        // اضافه کردن کد اگر تکراری نباشد
                        if (!dtcCodes.Contains(code))
                        {
                            dtcCodes.Add(code);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // در صورت خطا، کدهای خالی برگردان
                return new List<string>();
            }
            
            return dtcCodes;
        }


        //=========================================================================================
        //=============================== LISTBOX DOUBLE CLICK =================================
        //=========================================================================================
        

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // بررسی اینکه آیا آیتمی انتخاب شده یا نه
                if (listBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select an item first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // گرفتن ایندکس آیتم انتخاب شده
                int selectedIndex = listBox1.SelectedIndex;
                
                // بررسی اینکه آیا ایندکس در محدوده آرایه است
                if (selectedIndex >= 0 && selectedIndex < filePathsArray.Count)
                {
                    string filePath = filePathsArray[selectedIndex];
                    
                    // بررسی وجود فایل
                    if (File.Exists(filePath))
                    {
                        // باز کردن فایل در نوتپد
                        OpenFileInNotepad(filePath);
                    }
                    else
                    {
                        MessageBox.Show($"File not found:\n{filePath}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid selection or no corresponding file path.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFileInNotepad(string filePath)
        {
            try
            {
                // اولویت اول: Notepad++ 
                if (TryOpenWithNotepadPlusPlus(filePath))
                {
                    return; // اگر Notepad++ موفق بود، خروج
                }
                
                // اولویت دوم: Notepad معمولی ویندوز
                System.Diagnostics.Process.Start("notepad.exe", $"\"{filePath}\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open file:\n{ex.Message}", "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TryOpenWithNotepadPlusPlus(string filePath)
        {
            try
            {
                // مسیرهای احتمالی Notepad++
                string[] possiblePaths = {
                    @"C:\Program Files\Notepad++\notepad++.exe",
                    @"C:\Program Files (x86)\Notepad++\notepad++.exe",
                    @"C:\Users\" + Environment.UserName + @"\AppData\Local\Notepad++\notepad++.exe",
                    "notepad++.exe" // اگر در PATH باشد
                };

                foreach (string path in possiblePaths)
                {
                    try
                    {
                        if (path == "notepad++.exe")
                        {
                            // تست اینکه آیا notepad++ در PATH است
                            System.Diagnostics.Process.Start(path, $"\"{filePath}\"");
                            return true;
                        }
                        else if (File.Exists(path))
                        {
                            // اگر فایل وجود دارد، اجرا کن
                            System.Diagnostics.Process.Start(path, $"\"{filePath}\"");
                            return true;
                        }
                    }
                    catch
                    {
                        // اگر این مسیر کار نکرد، مسیر بعدی را امتحان کن
                        continue;
                    }
                }
                
                return false; // هیچ مسیری کار نکرد
            }
            catch
            {
                return false; // خطا در تلاش برای باز کردن Notepad++
            }
        }


    }
}
