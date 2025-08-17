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
            f.main_sc_tosim();

        }//convert script to simulator
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
