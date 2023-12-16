namespace IKCO_Codification
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.showresult = new System.Windows.Forms.Label();
            this.configcode = new System.Windows.Forms.Button();
            this.diagnosticcode = new System.Windows.Forms.Button();
            this.opencodificationfile = new System.Windows.Forms.OpenFileDialog();
            this.codiftextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(560, 332);
            this.textBox1.TabIndex = 0;
            // 
            // showresult
            // 
            this.showresult.AutoSize = true;
            this.showresult.Location = new System.Drawing.Point(13, 388);
            this.showresult.Name = "showresult";
            this.showresult.Size = new System.Drawing.Size(32, 13);
            this.showresult.TabIndex = 1;
            this.showresult.Text = "result";
            // 
            // configcode
            // 
            this.configcode.Location = new System.Drawing.Point(12, 12);
            this.configcode.Name = "configcode";
            this.configcode.Size = new System.Drawing.Size(103, 23);
            this.configcode.TabIndex = 2;
            this.configcode.Text = "Config Code";
            this.configcode.UseVisualStyleBackColor = true;
            this.configcode.Click += new System.EventHandler(this.configcode_Click);
            // 
            // diagnosticcode
            // 
            this.diagnosticcode.Location = new System.Drawing.Point(121, 12);
            this.diagnosticcode.Name = "diagnosticcode";
            this.diagnosticcode.Size = new System.Drawing.Size(103, 23);
            this.diagnosticcode.TabIndex = 3;
            this.diagnosticcode.Text = "Diagnostic Code";
            this.diagnosticcode.UseVisualStyleBackColor = true;
            this.diagnosticcode.Click += new System.EventHandler(this.diagnosticcode_Click);
            // 
            // opencodificationfile
            // 
            this.opencodificationfile.FileName = "opencodificationfile";
            // 
            // codiftextBox
            // 
            this.codiftextBox.Location = new System.Drawing.Point(230, 14);
            this.codiftextBox.Name = "codiftextBox";
            this.codiftextBox.Size = new System.Drawing.Size(342, 20);
            this.codiftextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(462, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Updated To Ver_90";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codiftextBox);
            this.Controls.Add(this.diagnosticcode);
            this.Controls.Add(this.configcode);
            this.Controls.Add(this.showresult);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 450);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "Form1";
            this.Text = "IKCO Codification v1.05";
            this.Load += new System.EventHandler(this.load_form);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label showresult;
        private System.Windows.Forms.Button configcode;
        private System.Windows.Forms.Button diagnosticcode;
        public System.Windows.Forms.OpenFileDialog opencodificationfile;
        private System.Windows.Forms.TextBox codiftextBox;
        private System.Windows.Forms.Label label1;
    }
}

