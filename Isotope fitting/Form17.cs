﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form17 : Form
    {
        Form2 frm2;
        string message ="";
        public Form17(/*Form2 f*/string m)
        {
            InitializeComponent();
            //frm2 = f;
            message = m;
            textBox1.Text = message;
        }

        private void Form17_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
