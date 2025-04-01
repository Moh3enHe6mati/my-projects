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
            this.btns19 = new System.Windows.Forms.Button();
            this.infopanel = new System.Windows.Forms.Panel();
            this.infolable1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.s19panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.s19gBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.s28panel = new System.Windows.Forms.Panel();
            this.hexpanel = new System.Windows.Forms.Panel();
            this.binpanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.paneltitlebar.SuspendLayout();
            this.infopanel.SuspendLayout();
            this.s19panel.SuspendLayout();
            this.s19gBox1.SuspendLayout();
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
            this.btninfo.Location = new System.Drawing.Point(0, 219);
            this.btninfo.Name = "btninfo";
            this.btninfo.Size = new System.Drawing.Size(85, 25);
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
            this.btnbin.Location = new System.Drawing.Point(0, 182);
            this.btnbin.Name = "btnbin";
            this.btnbin.Size = new System.Drawing.Size(85, 25);
            this.btnbin.TabIndex = 3;
            this.btnbin.Text = "BIN";
            this.btnbin.UseVisualStyleBackColor = false;
            this.btnbin.Click += new System.EventHandler(this.btnbin_Click);
            // 
            // btnhex
            // 
            this.btnhex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btnhex.FlatAppearance.BorderSize = 0;
            this.btnhex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhex.ForeColor = System.Drawing.Color.White;
            this.btnhex.Location = new System.Drawing.Point(0, 145);
            this.btnhex.Name = "btnhex";
            this.btnhex.Size = new System.Drawing.Size(85, 25);
            this.btnhex.TabIndex = 2;
            this.btnhex.Text = "HEX";
            this.btnhex.UseVisualStyleBackColor = false;
            this.btnhex.Click += new System.EventHandler(this.btnhex_Click);
            // 
            // btns28
            // 
            this.btns28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btns28.FlatAppearance.BorderSize = 0;
            this.btns28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btns28.ForeColor = System.Drawing.Color.White;
            this.btns28.Location = new System.Drawing.Point(0, 108);
            this.btns28.Name = "btns28";
            this.btns28.Size = new System.Drawing.Size(85, 25);
            this.btns28.TabIndex = 1;
            this.btns28.Text = "S28";
            this.btns28.UseVisualStyleBackColor = false;
            this.btns28.Click += new System.EventHandler(this.btns28_Click);
            // 
            // btns19
            // 
            this.btns19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(12)))), ((int)(((byte)(108)))));
            this.btns19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btns19.FlatAppearance.BorderSize = 0;
            this.btns19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btns19.ForeColor = System.Drawing.Color.White;
            this.btns19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btns19.Location = new System.Drawing.Point(0, 71);
            this.btns19.Name = "btns19";
            this.btns19.Size = new System.Drawing.Size(85, 25);
            this.btns19.TabIndex = 0;
            this.btns19.Text = "S19";
            this.btns19.UseVisualStyleBackColor = false;
            this.btns19.Click += new System.EventHandler(this.btns19_Click);
            // 
            // infopanel
            // 
            this.infopanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.infopanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.infopanel.Controls.Add(this.infolable1);
            this.infopanel.Location = new System.Drawing.Point(84, 71);
            this.infopanel.Name = "infopanel";
            this.infopanel.Size = new System.Drawing.Size(516, 330);
            this.infopanel.TabIndex = 2;
            this.infopanel.Visible = false;
            // 
            // infolable1
            // 
            this.infolable1.AutoSize = true;
            this.infolable1.ForeColor = System.Drawing.Color.White;
            this.infolable1.Location = new System.Drawing.Point(174, 141);
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
            // s19panel
            // 
            this.s19panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.s19panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.s19panel.Controls.Add(this.groupBox1);
            this.s19panel.Controls.Add(this.s19gBox1);
            this.s19panel.Location = new System.Drawing.Point(84, 71);
            this.s19panel.Name = "s19panel";
            this.s19panel.Size = new System.Drawing.Size(516, 330);
            this.s19panel.TabIndex = 3;
            this.s19panel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(25, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 204);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom format";
            // 
            // s19gBox1
            // 
            this.s19gBox1.BackColor = System.Drawing.Color.Transparent;
            this.s19gBox1.Controls.Add(this.button1);
            this.s19gBox1.ForeColor = System.Drawing.Color.White;
            this.s19gBox1.Location = new System.Drawing.Point(25, 3);
            this.s19gBox1.Margin = new System.Windows.Forms.Padding(2);
            this.s19gBox1.Name = "s19gBox1";
            this.s19gBox1.Size = new System.Drawing.Size(488, 107);
            this.s19gBox1.TabIndex = 1;
            this.s19gBox1.TabStop = false;
            this.s19gBox1.Text = "Input s19 file";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(247, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Analyze file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // s28panel
            // 
            this.s28panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.s28panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.s28panel.Location = new System.Drawing.Point(84, 71);
            this.s28panel.Name = "s28panel";
            this.s28panel.Size = new System.Drawing.Size(516, 330);
            this.s28panel.TabIndex = 0;
            this.s28panel.Visible = false;
            // 
            // hexpanel
            // 
            this.hexpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.hexpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hexpanel.Location = new System.Drawing.Point(84, 71);
            this.hexpanel.Name = "hexpanel";
            this.hexpanel.Size = new System.Drawing.Size(516, 330);
            this.hexpanel.TabIndex = 1;
            this.hexpanel.Visible = false;
            // 
            // binpanel
            // 
            this.binpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(79)))));
            this.binpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.binpanel.Location = new System.Drawing.Point(84, 71);
            this.binpanel.Name = "binpanel";
            this.binpanel.Size = new System.Drawing.Size(516, 330);
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
            this.Controls.Add(this.s19panel);
            this.Controls.Add(this.s28panel);
            this.Controls.Add(this.hexpanel);
            this.Controls.Add(this.binpanel);
            this.Controls.Add(this.infopanel);
            this.Controls.Add(this.btns19);
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
            this.s19panel.ResumeLayout(false);
            this.s19gBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paneltitlebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Panel infopanel;
        private System.Windows.Forms.Button btns19;
        private System.Windows.Forms.Button btnbin;
        private System.Windows.Forms.Button btnhex;
        private System.Windows.Forms.Button btns28;
        private System.Windows.Forms.Button btninfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label infolable1;
        private System.Windows.Forms.Panel s19panel;
        private System.Windows.Forms.Panel s28panel;
        private System.Windows.Forms.Panel hexpanel;
        private System.Windows.Forms.Panel binpanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox s19gBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

