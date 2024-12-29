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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cleargroupBox = new System.Windows.Forms.GroupBox();
            this.ChangeDics_Click = new System.Windows.Forms.Button();
            this.cleartemp = new System.Windows.Forms.Button();
            this.convertgroupBox = new System.Windows.Forms.GroupBox();
            this.getdanacode = new System.Windows.Forms.Button();
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
            this.canid = new System.Windows.Forms.Label();
            this.tBoxcanid = new System.Windows.Forms.TextBox();
            this.logtoout = new System.Windows.Forms.Button();
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
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 340);
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
            this.tabPage1.Size = new System.Drawing.Size(570, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // cleargroupBox
            // 
            this.cleargroupBox.Controls.Add(this.ChangeDics_Click);
            this.cleargroupBox.Controls.Add(this.cleartemp);
            this.cleargroupBox.Location = new System.Drawing.Point(6, 178);
            this.cleargroupBox.Name = "cleargroupBox";
            this.cleargroupBox.Size = new System.Drawing.Size(122, 130);
            this.cleargroupBox.TabIndex = 2;
            this.cleargroupBox.TabStop = false;
            this.cleargroupBox.Text = "CDics,TClear";
            // 
            // ChangeDics_Click
            // 
            this.ChangeDics_Click.Location = new System.Drawing.Point(6, 48);
            this.ChangeDics_Click.Name = "ChangeDics_Click";
            this.ChangeDics_Click.Size = new System.Drawing.Size(75, 23);
            this.ChangeDics_Click.TabIndex = 1;
            this.ChangeDics_Click.Text = "ChangeDics";
            this.ChangeDics_Click.UseVisualStyleBackColor = true;
            this.ChangeDics_Click.Click += new System.EventHandler(this.ChangeDics_Click_Click);
            // 
            // cleartemp
            // 
            this.cleartemp.Location = new System.Drawing.Point(6, 19);
            this.cleartemp.Name = "cleartemp";
            this.cleartemp.Size = new System.Drawing.Size(75, 23);
            this.cleartemp.TabIndex = 0;
            this.cleartemp.Text = "Clear Temp";
            this.cleartemp.UseVisualStyleBackColor = true;
            this.cleartemp.Click += new System.EventHandler(this.cleartemp_Click);
            // 
            // convertgroupBox
            // 
            this.convertgroupBox.Controls.Add(this.getdanacode);
            this.convertgroupBox.Controls.Add(this.convertclear);
            this.convertgroupBox.Controls.Add(this.groupBox1);
            this.convertgroupBox.Controls.Add(this.converttextBox);
            this.convertgroupBox.Location = new System.Drawing.Point(134, 6);
            this.convertgroupBox.Name = "convertgroupBox";
            this.convertgroupBox.Size = new System.Drawing.Size(430, 302);
            this.convertgroupBox.TabIndex = 1;
            this.convertgroupBox.TabStop = false;
            this.convertgroupBox.Text = "Convert";
            // 
            // getdanacode
            // 
            this.getdanacode.Location = new System.Drawing.Point(7, 275);
            this.getdanacode.Name = "getdanacode";
            this.getdanacode.Size = new System.Drawing.Size(97, 23);
            this.getdanacode.TabIndex = 7;
            this.getdanacode.Text = "Get Dana Codes";
            this.getdanacode.UseVisualStyleBackColor = true;
            this.getdanacode.Click += new System.EventHandler(this.getdanacode_Click);
            // 
            // convertclear
            // 
            this.convertclear.Location = new System.Drawing.Point(349, 273);
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
            this.groupBox1.Controls.Add(this.convertbutton);
            this.groupBox1.Location = new System.Drawing.Point(88, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 32);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Format";
            // 
            // hexradioButton
            // 
            this.hexradioButton.AutoSize = true;
            this.hexradioButton.Location = new System.Drawing.Point(180, 10);
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
            this.binaryradioButton.Location = new System.Drawing.Point(280, 10);
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
            this.asciiradioButton.Location = new System.Drawing.Point(228, 10);
            this.asciiradioButton.Name = "asciiradioButton";
            this.asciiradioButton.Size = new System.Drawing.Size(46, 17);
            this.asciiradioButton.TabIndex = 3;
            this.asciiradioButton.TabStop = true;
            this.asciiradioButton.Text = "ascii";
            this.asciiradioButton.UseVisualStyleBackColor = true;
            // 
            // convertbutton
            // 
            this.convertbutton.Location = new System.Drawing.Point(75, 7);
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
            this.converttextBox.MaxLength = 999999999;
            this.converttextBox.Multiline = true;
            this.converttextBox.Name = "converttextBox";
            this.converttextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.converttextBox.Size = new System.Drawing.Size(418, 221);
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
            this.infogroupBox.Size = new System.Drawing.Size(122, 166);
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
            this.label7F.Location = new System.Drawing.Point(16, 139);
            this.label7F.Name = "label7F";
            this.label7F.Size = new System.Drawing.Size(25, 13);
            this.label7F.TabIndex = 3;
            this.label7F.Text = "7F :";
            // 
            // textBox7F
            // 
            this.textBox7F.Location = new System.Drawing.Point(47, 136);
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
            this.tabPage2.Size = new System.Drawing.Size(570, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Frame";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonsctosim);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 72);
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
            this.groupBox3.Location = new System.Drawing.Point(9, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 224);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "none";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.canid);
            this.groupBox2.Controls.Add(this.tBoxcanid);
            this.groupBox2.Controls.Add(this.logtoout);
            this.groupBox2.Location = new System.Drawing.Point(141, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 72);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Converter";
            // 
            // canid
            // 
            this.canid.AutoSize = true;
            this.canid.Location = new System.Drawing.Point(15, 19);
            this.canid.Name = "canid";
            this.canid.Size = new System.Drawing.Size(43, 13);
            this.canid.TabIndex = 2;
            this.canid.Text = "CAN ID";
            // 
            // tBoxcanid
            // 
            this.tBoxcanid.Location = new System.Drawing.Point(64, 16);
            this.tBoxcanid.Name = "tBoxcanid";
            this.tBoxcanid.Size = new System.Drawing.Size(353, 20);
            this.tBoxcanid.TabIndex = 1;
            // 
            // logtoout
            // 
            this.logtoout.Location = new System.Drawing.Point(342, 42);
            this.logtoout.Name = "logtoout";
            this.logtoout.Size = new System.Drawing.Size(75, 23);
            this.logtoout.TabIndex = 0;
            this.logtoout.Text = "Go";
            this.logtoout.UseVisualStyleBackColor = true;
            this.logtoout.Click += new System.EventHandler(this.logtoout_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(570, 314);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "File";
            // 
            // resultlabel
            // 
            this.resultlabel.AutoSize = true;
            this.resultlabel.Location = new System.Drawing.Point(13, 345);
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
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.resultlabel);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Mehad Tools v1.03";
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.GroupBox cleargroupBox;
        public System.Windows.Forms.GroupBox convertgroupBox;
        public System.Windows.Forms.GroupBox infogroupBox;
        public System.Windows.Forms.Button cleartemp;
        public System.Windows.Forms.Label resultlabel;
        public System.Windows.Forms.Button convertbutton;
        public System.Windows.Forms.TextBox converttextBox;
        public System.Windows.Forms.RadioButton binaryradioButton;
        public System.Windows.Forms.RadioButton asciiradioButton;
        public System.Windows.Forms.RadioButton hexradioButton;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button convertclear;
        public System.Windows.Forms.Button obdconnector;
        public System.Windows.Forms.Button ecuid;
        public System.Windows.Forms.TextBox textBox7F;
        public System.Windows.Forms.Label label7F;
        public System.Windows.Forms.Button initpinbtn;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Button buttonsctosim;
        public System.Windows.Forms.FolderBrowserDialog folderBrowser1;
        public System.Windows.Forms.OpenFileDialog openFile1;
        public System.Windows.Forms.Button frmlen;
        public System.Windows.Forms.Button ChangeDics_Click;
        public System.Windows.Forms.Button logtoout;
        public System.Windows.Forms.Label canid;
        public System.Windows.Forms.TextBox tBoxcanid;
        public System.Windows.Forms.Button getdanacode;
    }
}

