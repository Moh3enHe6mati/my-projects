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
        private void Form1_Load(object sender,EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 50;

            path.AddArc(0, 0, radius, radius, 180, 90); // گوشه بالا-چپ
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // گوشه بالا-راست
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // گوشه پایین-راست
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // گوشه پایین-چپ
            this.Region = new Region(path);
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
        private void btns19_Click(object sender, EventArgs e)
        {
            
            btns19.BackColor = Color.FromArgb(35, 35, 79);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            s19panel.Visible = true;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btns28_Click(object sender, EventArgs e)
        {
            btns28.BackColor = Color.FromArgb(35, 35, 79);
            btns19.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            s19panel.Visible = false;
            s28panel.Visible = true;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btnhex_Click(object sender, EventArgs e)
        {
            btnhex.BackColor = Color.FromArgb(35, 35, 79);
            btns19.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            s19panel.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = true;
            binpanel.Visible = false;
            infopanel.Visible = false;
        }
        private void btnbin_Click(object sender, EventArgs e)
        {
            btnbin.BackColor = Color.FromArgb(35, 35, 79);
            btns19.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btninfo.BackColor = Color.FromArgb(35, 12, 108);
            s19panel.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = true;
            infopanel.Visible = false;
        }
        private void btninfo_Click(object sender, EventArgs e)
        {
            btninfo.BackColor = Color.FromArgb(35, 35, 79);
            btns19.BackColor = Color.FromArgb(35, 12, 108);
            btns28.BackColor = Color.FromArgb(35, 12, 108);
            btnhex.BackColor = Color.FromArgb(35, 12, 108);
            btnbin.BackColor = Color.FromArgb(35, 12, 108);
            s19panel.Visible = false;
            s28panel.Visible = false;
            hexpanel.Visible = false;
            binpanel.Visible = false;
            infopanel.Visible = true;
        }
        /* general function ===========================================
         ==============================================================*/

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

        /* general function ===========================================
         ==============================================================*/

        /* general function ===========================================
         ==============================================================*/

        /* general function ===========================================
         ==============================================================*/


        /* general function ===========================================
         ==============================================================*/








    }
}
