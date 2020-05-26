using System;
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
    public partial class Form14 : Form
    {
        Form2 frm2;

        public Form14(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            ppmUD14.Value = (decimal)frm2.ppmErrorFF;
            ppmUD14.Enabled = ppm_Lbl14.Enabled = !frm2.ignore_ppm_FF;
            ignore_ppm_ChkBx.Checked= frm2.ignore_ppm_FF;
        }

        private void ppmUD14_ValueChanged(object sender, EventArgs e)
        {
            frm2.ppmErrorFF = (double)ppmUD14.Value;
        }

        private void calcBtn14_Click(object sender, EventArgs e)
        {
            frm2.calc_form14 = true;
            this.Close();
        }

        private void ignore_ppm_ChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ignore_ppm_ChkBx.Checked)
            {
                ppmUD14.Enabled = false;
                ppm_Lbl14.Enabled = false;
                frm2.ignore_ppm_FF = true;
            }
            else
            {
                ppmUD14.Enabled = true;
                ppm_Lbl14.Enabled = true;
                frm2.ignore_ppm_FF = false;
            }
        }

        private void Form14_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
