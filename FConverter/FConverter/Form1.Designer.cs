namespace FConverter
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
            this.btnGo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lbldownsid = new System.Windows.Forms.Label();
            this.lblframelen = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblBlocksize = new System.Windows.Forms.Label();
            this.lblEndadd = new System.Windows.Forms.Label();
            this.lblStartadd = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hexbtn1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbleaddress = new System.Windows.Forms.Label();
            this.lblsaddress = new System.Windows.Forms.Label();
            this.Calccrc = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblshowresult = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnterminal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(28, 352);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.lbldownsid);
            this.groupBox1.Controls.Add(this.lblframelen);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.lblBlocksize);
            this.groupBox1.Controls.Add(this.lblEndadd);
            this.groupBox1.Controls.Add(this.lblStartadd);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(46, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "s19";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(83, 131);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "36";
            // 
            // lbldownsid
            // 
            this.lbldownsid.AutoSize = true;
            this.lbldownsid.Location = new System.Drawing.Point(10, 134);
            this.lbldownsid.Name = "lbldownsid";
            this.lbldownsid.Size = new System.Drawing.Size(76, 13);
            this.lbldownsid.TabIndex = 9;
            this.lbldownsid.Text = "Download SID";
            // 
            // lblframelen
            // 
            this.lblframelen.AutoSize = true;
            this.lblframelen.Location = new System.Drawing.Point(10, 106);
            this.lblframelen.Name = "lblframelen";
            this.lblframelen.Size = new System.Drawing.Size(57, 13);
            this.lblframelen.TabIndex = 8;
            this.lblframelen.Text = "Frame Len";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "F3";
            // 
            // lblBlocksize
            // 
            this.lblBlocksize.AutoSize = true;
            this.lblBlocksize.Location = new System.Drawing.Point(10, 78);
            this.lblBlocksize.Name = "lblBlocksize";
            this.lblBlocksize.Size = new System.Drawing.Size(55, 13);
            this.lblBlocksize.TabIndex = 6;
            this.lblBlocksize.Text = "Bock Size";
            // 
            // lblEndadd
            // 
            this.lblEndadd.AutoSize = true;
            this.lblEndadd.Location = new System.Drawing.Point(10, 51);
            this.lblEndadd.Name = "lblEndadd";
            this.lblEndadd.Size = new System.Drawing.Size(67, 13);
            this.lblEndadd.TabIndex = 5;
            this.lblEndadd.Text = "End Address";
            // 
            // lblStartadd
            // 
            this.lblStartadd.AutoSize = true;
            this.lblStartadd.Location = new System.Drawing.Point(10, 25);
            this.lblStartadd.Name = "lblStartadd";
            this.lblStartadd.Size = new System.Drawing.Size(70, 13);
            this.lblStartadd.TabIndex = 4;
            this.lblStartadd.Text = "Start Address";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(83, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "4000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "FFFF";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1000";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 429);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnGo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "s19*s28";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hexbtn1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "bin*hex";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hexbtn1
            // 
            this.hexbtn1.Location = new System.Drawing.Point(35, 360);
            this.hexbtn1.Name = "hexbtn1";
            this.hexbtn1.Size = new System.Drawing.Size(75, 23);
            this.hexbtn1.TabIndex = 1;
            this.hexbtn1.Text = "Go";
            this.hexbtn1.UseVisualStyleBackColor = true;
            this.hexbtn1.Click += new System.EventHandler(this.hexbtn1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 222);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "frame len";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(73, 55);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(91, 20);
            this.textBox11.TabIndex = 1;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(73, 29);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(91, 20);
            this.textBox10.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbleaddress);
            this.tabPage3.Controls.Add(this.lblsaddress);
            this.tabPage3.Controls.Add(this.Calccrc);
            this.tabPage3.Controls.Add(this.textBox8);
            this.tabPage3.Controls.Add(this.textBox7);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(342, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "cs*crc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbleaddress
            // 
            this.lbleaddress.AutoSize = true;
            this.lbleaddress.Location = new System.Drawing.Point(11, 34);
            this.lbleaddress.Name = "lbleaddress";
            this.lbleaddress.Size = new System.Drawing.Size(53, 13);
            this.lbleaddress.TabIndex = 5;
            this.lbleaddress.Text = "e address";
            // 
            // lblsaddress
            // 
            this.lblsaddress.AutoSize = true;
            this.lblsaddress.Location = new System.Drawing.Point(11, 8);
            this.lblsaddress.Name = "lblsaddress";
            this.lblsaddress.Size = new System.Drawing.Size(52, 13);
            this.lblsaddress.TabIndex = 4;
            this.lblsaddress.Text = "s address";
            // 
            // Calccrc
            // 
            this.Calccrc.Location = new System.Drawing.Point(256, 17);
            this.Calccrc.Name = "Calccrc";
            this.Calccrc.Size = new System.Drawing.Size(75, 23);
            this.Calccrc.TabIndex = 3;
            this.Calccrc.Text = "Calc";
            this.Calccrc.UseVisualStyleBackColor = true;
            this.Calccrc.Click += new System.EventHandler(this.Calccrc_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(6, 58);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(325, 174);
            this.textBox8.TabIndex = 2;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(70, 31);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(105, 20);
            this.textBox7.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(69, 5);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(105, 20);
            this.textBox6.TabIndex = 0;
            // 
            // lblshowresult
            // 
            this.lblshowresult.AutoSize = true;
            this.lblshowresult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblshowresult.Location = new System.Drawing.Point(11, 439);
            this.lblshowresult.Name = "lblshowresult";
            this.lblshowresult.Size = new System.Drawing.Size(62, 13);
            this.lblshowresult.TabIndex = 3;
            this.lblshowresult.Text = "Show result";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(6, 19);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox9.Size = new System.Drawing.Size(300, 359);
            this.textBox9.TabIndex = 4;
            this.textBox9.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnterminal);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Location = new System.Drawing.Point(360, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 427);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "terminal";
            // 
            // btnterminal
            // 
            this.btnterminal.Location = new System.Drawing.Point(127, 398);
            this.btnterminal.Name = "btnterminal";
            this.btnterminal.Size = new System.Drawing.Size(75, 23);
            this.btnterminal.TabIndex = 5;
            this.btnterminal.Text = "Clear";
            this.btnterminal.UseVisualStyleBackColor = true;
            this.btnterminal.Click += new System.EventHandler(this.btnterminal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblshowresult);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.Text = "FConverter.v.1.04";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBlocksize;
        private System.Windows.Forms.Label lblEndadd;
        private System.Windows.Forms.Label lblStartadd;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblframelen;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lbldownsid;
        private System.Windows.Forms.Label lblshowresult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbleaddress;
        private System.Windows.Forms.Label lblsaddress;
        private System.Windows.Forms.Button Calccrc;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button hexbtn1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnterminal;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

