﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mehad_Tools
{
    public partial class Form1 : Form
    {
        private functions f;
        //=========================================================================================
        public Form1()
        {
            InitializeComponent();
        }
        //=========================================================================================
        private void First_Load(object sender, EventArgs e)
        {
            f = new functions(this);
        }//first load form
        //=========================================================================================
        private void cleartemp_Click(object sender, EventArgs e)
        {
            resultlabel.Text = "Please Wait Clear Temp ...";
            resultlabel.BackColor = Color.Red;
            this.Refresh();
            f.cleartemp();
        }//clear temp content
        //=========================================================================================
        private void convertbutton_Click(object sender, EventArgs e)
        {
            resultlabel.BackColor = Color.Yellow;
            resultlabel.Text = "Processing...";
            this.Refresh();
            if(converttextBox.Text==string.Empty)
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

        }//
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
        }
        //=========================================================================================
        //test
        //=========================================================================================
        //=========================================================================================
        //=========================================================================================
        //=========================================================================================
        //=========================================================================================
    }
}
