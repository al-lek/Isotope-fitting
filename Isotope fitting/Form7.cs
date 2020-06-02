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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            fitBunch_numUD.TextChanged += new EventHandler(fitBunch_numUD_TextChanged);
            fitCover_numUD.TextChanged += new EventHandler(fitCover_numUD_TextChanged);
            ppmDi_numUD.TextChanged += new EventHandler(ppmDi_numUD_TextChanged);

            fitBunch_numUD.Value = Form2.fit_bunch;
            fitCover_numUD.Value = Form2.fit_cover;
            ppmDi_numUD.Value = (decimal)Form2.ppmDi;
        }

        void fitBunch_numUD_TextChanged(object sender, EventArgs e)
        {
            if (fitBunch_numUD.ActiveControl != null && !string.IsNullOrEmpty(fitBunch_numUD.ActiveControl.Text))
            {
                Form2.fit_bunch = int.Parse(fitBunch_numUD.ActiveControl.Text);
            }
        }
        void fitCover_numUD_TextChanged(object sender, EventArgs e)
        {
            if (fitCover_numUD.ActiveControl != null && !string.IsNullOrEmpty(fitCover_numUD.ActiveControl.Text))
            {
                Form2.fit_cover = int.Parse(fitCover_numUD.ActiveControl.Text);
            }
        }
        void ppmDi_numUD_TextChanged(object sender, EventArgs e)
        {
            if (ppmDi_numUD.ActiveControl != null && !string.IsNullOrEmpty(ppmDi_numUD.ActiveControl.Text))
            {
                Form2.ppmDi = double.Parse(ppmDi_numUD.ActiveControl.Text);
            }
        }
        
        private void fitBunch_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.fit_bunch = (int)fitBunch_numUD.Value;
        }

        private void fitCover_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.fit_cover = (int)fitCover_numUD.Value;
        }

        private void ppmDi_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.ppmDi = (double)ppmDi_numUD.Value;
        }

        private void Form7_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
