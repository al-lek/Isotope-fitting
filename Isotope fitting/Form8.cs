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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            minIntensity_numUD.TextChanged += new EventHandler(minIntensity_numUD_TextChanged);
            minIntensity_numUD.Value = (decimal)Form2.min_intes;
        }

        private void minIntensity_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.min_intes = (double)minIntensity_numUD.Value;
        }
        void minIntensity_numUD_TextChanged(object sender, EventArgs e)
        {
            if (minIntensity_numUD.ActiveControl != null && !string.IsNullOrEmpty(minIntensity_numUD.ActiveControl.Text))
            {
                Form2.min_intes = double.Parse(minIntensity_numUD.ActiveControl.Text);
            }
        }
    }
}
