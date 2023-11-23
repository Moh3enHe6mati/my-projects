namespace Mehad_Tools
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cleargroupBox = new System.Windows.Forms.GroupBox();
            this.cleartemp = new System.Windows.Forms.Button();
            this.convertgroupBox = new System.Windows.Forms.GroupBox();
            this.convertclear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hexradioButton = new System.Windows.Forms.RadioButton();
            this.binaryradioButton = new System.Windows.Forms.RadioButton();
            this.asciiradioButton = new System.Windows.Forms.RadioButton();
            this.convertbutton = new System.Windows.Forms.Button();
            this.converttextBox = new System.Windows.Forms.TextBox();
            this.infogroupBox = new System.Windows.Forms.GroupBox();
            this.frmlen = new System.Windows.Forms.Button();
            this.initpinbtn = new System.Windows.Forms.Button();
            this.label7F = new System.Windows.Forms.Label();
            this.textBox7F = new System.Windows.Forms.TextBox();
            this.ecuid = new System.Windows.Forms.Button();
            this.obdconnector = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonsctosim = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.resultlabel = new System.Windows.Forms.Label();
            this.folderBrowser1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cleargroupBox.SuspendLayout();
            this.convertgroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.infogroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 287);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGreen;
            this.tabPage1.Controls.Add(this.cleargroupBox);
            this.tabPage1.Controls.Add(this.convertgroupBox);
            this.tabPage1.Controls.Add(this.infogroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // cleargroupBox
            // 
            this.cleargroupBox.Controls.Add(this.cleartemp);
            this.cleargroupBox.Location = new System.Drawing.Point(6, 200);
            this.cleargroupBox.Name = "cleargroupBox";
            this.cleargroupBox.Size = new System.Drawing.Size(122, 55);
            this.cleargroupBox.TabIndex = 2;
            this.cleargroupBox.TabStop = false;
            this.cleargroupBox.Text = "Clear";
            // 
            // cleartemp
            // 
            this.cleartemp.Location = new System.Drawing.Point(25, 19);
            this.cleartemp.Name = "cleartemp";
            this.cleartemp.Size = new System.Drawing.Size(75, 23);
            this.cleartemp.TabIndex = 0;
            this.cleartemp.Text = "Clear Temp";
            this.cleartemp.UseVisualStyleBackColor = true;
            this.cleartemp.Click += new System.EventHandler(this.cleartemp_Click);
            // 
            // convertgroupBox
            // 
            this.convertgroupBox.Controls.Add(this.convertclear);
            this.convertgroupBox.Controls.Add(this.groupBox1);
            this.convertgroupBox.Controls.Add(this.convertbutton);
            this.convertgroupBox.Controls.Add(this.converttextBox);
            this.convertgroupBox.Location = new System.Drawing.Point(134, 6);
            this.convertgroupBox.Name = "convertgroupBox";
            this.convertgroupBox.Size = new System.Drawing.Size(412, 249);
            this.convertgroupBox.TabIndex = 1;
            this.convertgroupBox.TabStop = false;
            this.convertgroupBox.Text = "Convert";
            // 
            // convertclear
            // 
            this.convertclear.Location = new System.Drawing.Point(87, 19);
            this.convertclear.Name = "convertclear";
            this.convertclear.Size = new System.Drawing.Size(75, 23);
            this.convertclear.TabIndex = 6;
            this.convertclear.Text = "Clear";
            this.convertclear.UseVisualStyleBackColor = true;
            this.convertclear.Click += new System.EventHandler(this.convertclear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hexradioButton);
            this.groupBox1.Controls.Add(this.binaryradioButton);
            this.groupBox1.Controls.Add(this.asciiradioButton);
            this.groupBox1.Location = new System.Drawing.Point(177, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 32);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Format";
            // 
            // hexradioButton
            // 
            this.hexradioButton.AutoSize = true;
            this.hexradioButton.Location = new System.Drawing.Point(74, 10);
            this.hexradioButton.Name = "hexradioButton";
            this.hexradioButton.Size = new System.Drawing.Size(42, 17);
            this.hexradioButton.TabIndex = 2;
            this.hexradioButton.TabStop = true;
            this.hexradioButton.Text = "hex";
            this.hexradioButton.UseVisualStyleBackColor = true;
            // 
            // binaryradioButton
            // 
            this.binaryradioButton.AutoSize = true;
            this.binaryradioButton.Location = new System.Drawing.Point(174, 10);
            this.binaryradioButton.Name = "binaryradioButton";
            this.binaryradioButton.Size = new System.Drawing.Size(53, 17);
            this.binaryradioButton.TabIndex = 4;
            this.binaryradioButton.TabStop = true;
            this.binaryradioButton.Text = "binary";
            this.binaryradioButton.UseVisualStyleBackColor = true;
            // 
            // asciiradioButton
            // 
            this.asciiradioButton.AutoSize = true;
            this.asciiradioButton.Location = new System.Drawing.Point(122, 10);
            this.asciiradioButton.Name = "asciiradioButton";
            this.asciiradioButton.Size = new System.Drawing.Size(46, 17);
            this.asciiradioButton.TabIndex = 3;
            this.asciiradioButton.TabStop = true;
            this.asciiradioButton.Text = "ascii";
            this.asciiradioButton.UseVisualStyleBackColor = true;
            // 
            // convertbutton
            // 
            this.convertbutton.Location = new System.Drawing.Point(6, 19);
            this.convertbutton.Name = "convertbutton";
            this.convertbutton.Size = new System.Drawing.Size(75, 23);
            this.convertbutton.TabIndex = 1;
            this.convertbutton.Text = "Convert";
            this.convertbutton.UseVisualStyleBackColor = true;
            this.convertbutton.Click += new System.EventHandler(this.convertbutton_Click);
            // 
            // converttextBox
            // 
            this.converttextBox.Location = new System.Drawing.Point(6, 48);
            this.converttextBox.Multiline = true;
            this.converttextBox.Name = "converttextBox";
            this.converttextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.converttextBox.Size = new System.Drawing.Size(400, 195);
            this.converttextBox.TabIndex = 0;
            // 
            // infogroupBox
            // 
            this.infogroupBox.Controls.Add(this.frmlen);
            this.infogroupBox.Controls.Add(this.initpinbtn);
            this.infogroupBox.Controls.Add(this.label7F);
            this.infogroupBox.Controls.Add(this.textBox7F);
            this.infogroupBox.Controls.Add(this.ecuid);
            this.infogroupBox.Controls.Add(this.obdconnector);
            this.infogroupBox.Location = new System.Drawing.Point(6, 6);
            this.infogroupBox.Name = "infogroupBox";
            this.infogroupBox.Size = new System.Drawing.Size(122, 188);
            this.infogroupBox.TabIndex = 0;
            this.infogroupBox.TabStop = false;
            this.infogroupBox.Text = "Information";
            // 
            // frmlen
            // 
            this.frmlen.Location = new System.Drawing.Point(6, 107);
            this.frmlen.Name = "frmlen";
            this.frmlen.Size = new System.Drawing.Size(107, 23);
            this.frmlen.TabIndex = 5;
            this.frmlen.Text = "Frm Len";
            this.frmlen.UseVisualStyleBackColor = true;
            this.frmlen.Click += new System.EventHandler(this.frmlen_Click);
            // 
            // initpinbtn
            // 
            this.initpinbtn.Location = new System.Drawing.Point(6, 48);
            this.initpinbtn.Name = "initpinbtn";
            this.initpinbtn.Size = new System.Drawing.Size(107, 23);
            this.initpinbtn.TabIndex = 4;
            this.initpinbtn.Text = "Initial Pin";
            this.initpinbtn.UseVisualStyleBackColor = true;
            this.initpinbtn.Click += new System.EventHandler(this.initpinbtn_Click);
            // 
            // label7F
            // 
            this.label7F.AutoSize = true;
            this.label7F.Location = new System.Drawing.Point(3, 165);
            this.label7F.Name = "label7F";
            this.label7F.Size = new System.Drawing.Size(25, 13);
            this.label7F.TabIndex = 3;
            this.label7F.Text = "7F :";
            // 
            // textBox7F
            // 
            this.textBox7F.Location = new System.Drawing.Point(47, 162);
            this.textBox7F.Name = "textBox7F";
            this.textBox7F.Size = new System.Drawing.Size(66, 20);
            this.textBox7F.TabIndex = 2;
            this.textBox7F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7F.TextChanged += new System.EventHandler(this.textBox7F_TextChanged);
            // 
            // ecuid
            // 
            this.ecuid.Location = new System.Drawing.Point(6, 77);
            this.ecuid.Name = "ecuid";
            this.ecuid.Size = new System.Drawing.Size(107, 23);
            this.ecuid.TabIndex = 1;
            this.ecuid.Text = "ECU ID";
            this.ecuid.UseVisualStyleBackColor = true;
            this.ecuid.Click += new System.EventHandler(this.ecuid_Click);
            // 
            // obdconnector
            // 
            this.obdconnector.Location = new System.Drawing.Point(6, 19);
            this.obdconnector.Name = "obdconnector";
            this.obdconnector.Size = new System.Drawing.Size(107, 23);
            this.obdconnector.TabIndex = 0;
            this.obdconnector.Text = "OBD";
            this.obdconnector.UseVisualStyleBackColor = true;
            this.obdconnector.Click += new System.EventHandler(this.obdconnector_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Frame";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonsctosim);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 249);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sim";
            // 
            // buttonsctosim
            // 
            this.buttonsctosim.Location = new System.Drawing.Point(28, 19);
            this.buttonsctosim.Name = "buttonsctosim";
            this.buttonsctosim.Size = new System.Drawing.Size(75, 23);
            this.buttonsctosim.TabIndex = 0;
            this.buttonsctosim.Text = "SC To SIM";
            this.buttonsctosim.UseVisualStyleBackColor = true;
            this.buttonsctosim.Click += new System.EventHandler(this.buttonsctosim_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(141, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 122);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KWP";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(141, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CAN";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(552, 261);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "File";
            // 
            // resultlabel
            // 
            this.resultlabel.AutoSize = true;
            this.resultlabel.Location = new System.Drawing.Point(13, 304);
            this.resultlabel.Name = "resultlabel";
            this.resultlabel.Size = new System.Drawing.Size(32, 13);
            this.resultlabel.TabIndex = 1;
            this.resultlabel.Text = "result";
            // 
            // openFile1
            // 
            this.openFile1.FileName = "openFile1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 360);
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "Form1";
            this.Text = "Mehad Tools v1.01";
            this.Load += new System.EventHandler(this.First_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cleargroupBox.ResumeLayout(false);
            this.convertgroupBox.ResumeLayout(false);
            this.convertgroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.infogroupBox.ResumeLayout(false);
            this.infogroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox cleargroupBox;
        private System.Windows.Forms.GroupBox convertgroupBox;
        private System.Windows.Forms.GroupBox infogroupBox;
        public System.Windows.Forms.Button cleartemp;
        public System.Windows.Forms.Label resultlabel;
        public System.Windows.Forms.Button convertbutton;
        public System.Windows.Forms.TextBox converttextBox;
        public System.Windows.Forms.RadioButton binaryradioButton;
        public System.Windows.Forms.RadioButton asciiradioButton;
        public System.Windows.Forms.RadioButton hexradioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button convertclear;
        public System.Windows.Forms.Button obdconnector;
        public System.Windows.Forms.Button ecuid;
        public System.Windows.Forms.TextBox textBox7F;
        public System.Windows.Forms.Label label7F;
        public System.Windows.Forms.Button initpinbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Button buttonsctosim;
        public System.Windows.Forms.FolderBrowserDialog folderBrowser1;
        public System.Windows.Forms.OpenFileDialog openFile1;
        private System.Windows.Forms.Button frmlen;
    }
}

