namespace FileAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.paneltitlebar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btninfo = new System.Windows.Forms.Button();
            this.btnbin = new System.Windows.Forms.Button();
            this.btnhex = new System.Windows.Forms.Button();
            this.btns28 = new System.Windows.Forms.Button();
            this.btnConvDown = new System.Windows.Forms.Button();
            this.infopanel = new System.Windows.Forms.Panel();
            this.infolable1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CDpanel1 = new System.Windows.Forms.Panel();
            this.CDgrpBox1 = new System.Windows.Forms.GroupBox();
            this.CDbtn1 = new System.Windows.Forms.Button();
            this.s28panel = new System.Windows.Forms.Panel();
            this.hexpanel = new System.Windows.Forms.Panel();
            this.hexCDgrpBox1 = new System.Windows.Forms.GroupBox();
            this.hexbtnanalyz = new System.Windows.Forms.Button();
            this.binpanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.paneltitlebar.SuspendLayout();
            this.infopanel.SuspendLayout();
            this.CDpanel1.SuspendLayout();
            this.CDgrpBox1.SuspendLayout();
            this.hexpanel.SuspendLayout();
            this.hexCDgrpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltitlebar
            // 
            this.paneltitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.paneltitlebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.paneltitlebar.Controls.Add(this.label1);
            this.paneltitlebar.Controls.Add(this.btnminimize);
            this.paneltitlebar.Controls.Add(this.btnexit);
            this.paneltitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltitlebar.Location = new System.Drawing.Point(0, 0);
            this.paneltitlebar.Name = "paneltitlebar";
            this.paneltitlebar.Size = new System.Drawing.Size(600, 28);
            this.paneltitlebar.TabIndex = 0;
            this.paneltitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(258, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Analyzer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnminimize
            // 
            this.btnminimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnminimize.BackgroundImage")));
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Location = new System.Drawing.Point(528, 3);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(25, 21);
            this.btnminimize.TabIndex = 1;
            this.btnminimize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnexit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexit.BackgroundImage")));
            this.btnexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Location = new System.Drawing.Point(560, 3);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(25, 21);
            this.btnexit.TabIndex = 1;
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btninfo
            // 
            this.btninfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btninfo.FlatAppearance.BorderSize = 0;
            this.btninfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btninfo.ForeColor = System.Drawing.Color.White;
            this.btninfo.Location = new System.Drawing.Point(0, 308);
            this.btninfo.Name = "btninfo";
            this.btninfo.Size = new System.Drawing.Size(114, 25);
            this.btninfo.TabIndex = 4;
            this.btninfo.Text = "INFO";
            this.btninfo.UseVisualStyleBackColor = false;
            this.btninfo.Click += new System.EventHandler(this.btninfo_Click);
            // 
            // btnbin
            // 
            this.btnbin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnbin.FlatAppearance.BorderSize = 0;
            this.btnbin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbin.ForeColor = System.Drawing.Color.White;
            this.btnbin.Location = new System.Drawing.Point(0, 223);
            this.btnbin.Name = "btnbin";
            this.btnbin.Size = new System.Drawing.Size(114, 25);
            this.btnbin.TabIndex = 3;
            this.btnbin.Text = "hide";
            this.btnbin.UseVisualStyleBackColor = false;
            this.btnbin.Visible = false;
            this.btnbin.Click += new System.EventHandler(this.btnbin_Click);
            // 
            // btnhex
            // 
            this.btnhex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnhex.FlatAppearance.BorderSize = 0;
            this.btnhex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhex.ForeColor = System.Drawing.Color.White;
            this.btnhex.Location = new System.Drawing.Point(0, 186);
            this.btnhex.Name = "btnhex";
            this.btnhex.Size = new System.Drawing.Size(114, 25);
            this.btnhex.TabIndex = 2;
            this.btnhex.Text = "hide";
            this.btnhex.UseVisualStyleBackColor = false;
            this.btnhex.Visible = false;
            this.btnhex.Click += new System.EventHandler(this.btnhex_Click);
            // 
            // btns28
            // 
            this.btns28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btns28.FlatAppearance.BorderSize = 0;
            this.btns28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btns28.ForeColor = System.Drawing.Color.White;
            this.btns28.Location = new System.Drawing.Point(0, 263);
            this.btns28.Name = "btns28";
            this.btns28.Size = new System.Drawing.Size(114, 25);
            this.btns28.TabIndex = 1;
            this.btns28.Text = "hide";
            this.btns28.UseVisualStyleBackColor = false;
            this.btns28.Visible = false;
            this.btns28.Click += new System.EventHandler(this.btns28_Click);
            // 
            // btnConvDown
            // 
            this.btnConvDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnConvDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConvDown.FlatAppearance.BorderSize = 0;
            this.btnConvDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvDown.ForeColor = System.Drawing.Color.White;
            this.btnConvDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvDown.Location = new System.Drawing.Point(0, 71);
            this.btnConvDown.Name = "btnConvDown";
            this.btnConvDown.Size = new System.Drawing.Size(114, 25);
            this.btnConvDown.TabIndex = 0;
            this.btnConvDown.Text = "Convert Download";
            this.btnConvDown.UseVisualStyleBackColor = false;
            this.btnConvDown.Click += new System.EventHandler(this.btnConvDown_Click);
            // 
            // infopanel
            // 
            this.infopanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.infopanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.infopanel.Controls.Add(this.infolable1);
            this.infopanel.Location = new System.Drawing.Point(140, 71);
            this.infopanel.Name = "infopanel";
            this.infopanel.Size = new System.Drawing.Size(448, 320);
            this.infopanel.TabIndex = 2;
            this.infopanel.Visible = false;
            // 
            // infolable1
            // 
            this.infolable1.AutoSize = true;
            this.infolable1.ForeColor = System.Drawing.Color.White;
            this.infolable1.Location = new System.Drawing.Point(151, 141);
            this.infolable1.Name = "infolable1";
            this.infolable1.Size = new System.Drawing.Size(147, 39);
            this.infolable1.TabIndex = 0;
            this.infolable1.Text = "Release date: 2025/03/23\r\nDeveloper: Mohsen Heshmati\r\nLast update: 2025/03/26\r\n";
            this.infolable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ver 00.00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CDpanel1
            // 
            this.CDpanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.CDpanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CDpanel1.Controls.Add(this.CDgrpBox1);
            this.CDpanel1.Location = new System.Drawing.Point(140, 71);
            this.CDpanel1.Name = "CDpanel1";
            this.CDpanel1.Size = new System.Drawing.Size(448, 320);
            this.CDpanel1.TabIndex = 3;
            this.CDpanel1.Visible = false;
            // 
            // CDgrpBox1
            // 
            this.CDgrpBox1.BackColor = System.Drawing.Color.Transparent;
            this.CDgrpBox1.Controls.Add(this.CDbtn1);
            this.CDgrpBox1.ForeColor = System.Drawing.Color.White;
            this.CDgrpBox1.Location = new System.Drawing.Point(2, 2);
            this.CDgrpBox1.Margin = new System.Windows.Forms.Padding(2);
            this.CDgrpBox1.Name = "CDgrpBox1";
            this.CDgrpBox1.Size = new System.Drawing.Size(444, 316);
            this.CDgrpBox1.TabIndex = 1;
            this.CDgrpBox1.TabStop = false;
            this.CDgrpBox1.Text = "Input Convert Data";
            // 
            // CDbtn1
            // 
            this.CDbtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CDbtn1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CDbtn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.CDbtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CDbtn1.ForeColor = System.Drawing.Color.Black;
            this.CDbtn1.Location = new System.Drawing.Point(338, 280);
            this.CDbtn1.Name = "CDbtn1";
            this.CDbtn1.Size = new System.Drawing.Size(100, 30);
            this.CDbtn1.TabIndex = 0;
            this.CDbtn1.Text = "Go";
            this.CDbtn1.UseVisualStyleBackColor = true;
            this.CDbtn1.Click += new System.EventHandler(this.CDbtn1_Click);
            // 
            // s28panel
            // 
            this.s28panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.s28panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.s28panel.Location = new System.Drawing.Point(140, 71);
            this.s28panel.Name = "s28panel";
            this.s28panel.Size = new System.Drawing.Size(448, 320);
            this.s28panel.TabIndex = 0;
            this.s28panel.Visible = false;
            // 
            // hexpanel
            // 
            this.hexpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.hexpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hexpanel.Controls.Add(this.hexCDgrpBox1);
            this.hexpanel.Location = new System.Drawing.Point(140, 71);
            this.hexpanel.Name = "hexpanel";
            this.hexpanel.Size = new System.Drawing.Size(448, 320);
            this.hexpanel.TabIndex = 1;
            this.hexpanel.Visible = false;
            // 
            // hexCDgrpBox1
            // 
            this.hexCDgrpBox1.Controls.Add(this.hexbtnanalyz);
            this.hexCDgrpBox1.ForeColor = System.Drawing.Color.White;
            this.hexCDgrpBox1.Location = new System.Drawing.Point(25, 10);
            this.hexCDgrpBox1.Name = "hexCDgrpBox1";
            this.hexCDgrpBox1.Size = new System.Drawing.Size(408, 52);
            this.hexCDgrpBox1.TabIndex = 0;
            this.hexCDgrpBox1.TabStop = false;
            this.hexCDgrpBox1.Text = "Analyz hex";
            // 
            // hexbtnanalyz
            // 
            this.hexbtnanalyz.ForeColor = System.Drawing.Color.White;
            this.hexbtnanalyz.Location = new System.Drawing.Point(205, 12);
            this.hexbtnanalyz.Name = "hexbtnanalyz";
            this.hexbtnanalyz.Size = new System.Drawing.Size(105, 31);
            this.hexbtnanalyz.TabIndex = 0;
            this.hexbtnanalyz.Text = "Go Analyz";
            this.hexbtnanalyz.UseVisualStyleBackColor = true;
            this.hexbtnanalyz.Click += new System.EventHandler(this.hexbtnanalyz_Click);
            // 
            // binpanel
            // 
            this.binpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.binpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.binpanel.Location = new System.Drawing.Point(140, 71);
            this.binpanel.Name = "binpanel";
            this.binpanel.Size = new System.Drawing.Size(448, 320);
            this.binpanel.TabIndex = 1;
            this.binpanel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.CDpanel1);
            this.Controls.Add(this.infopanel);
            this.Controls.Add(this.hexpanel);
            this.Controls.Add(this.s28panel);
            this.Controls.Add(this.binpanel);
            this.Controls.Add(this.btnConvDown);
            this.Controls.Add(this.btns28);
            this.Controls.Add(this.btnhex);
            this.Controls.Add(this.btnbin);
            this.Controls.Add(this.btninfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.paneltitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.paneltitlebar.ResumeLayout(false);
            this.paneltitlebar.PerformLayout();
            this.infopanel.ResumeLayout(false);
            this.infopanel.PerformLayout();
            this.CDpanel1.ResumeLayout(false);
            this.CDgrpBox1.ResumeLayout(false);
            this.hexpanel.ResumeLayout(false);
            this.hexCDgrpBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paneltitlebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Panel infopanel;
        private System.Windows.Forms.Button btnConvDown;
        private System.Windows.Forms.Button btnbin;
        private System.Windows.Forms.Button btnhex;
        private System.Windows.Forms.Button btns28;
        private System.Windows.Forms.Button btninfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label infolable1;
        private System.Windows.Forms.Panel CDpanel1;
        private System.Windows.Forms.Panel s28panel;
        private System.Windows.Forms.Panel hexpanel;
        private System.Windows.Forms.Panel binpanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox CDgrpBox1;
        private System.Windows.Forms.Button CDbtn1;
        private System.Windows.Forms.GroupBox hexCDgrpBox1;
        private System.Windows.Forms.Button hexbtnanalyz;
    }
}

