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
            fitBunch_numUD.Value = (decimal)Form2.fit_bunch;
            fitCover_numUD.Value = (decimal)Form2.fit_cover;
        }

        private void fitBunch_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.fit_bunch = (int)fitBunch_numUD.Value;
        }

        private void fitCover_numUD_ValueChanged(object sender, EventArgs e)
        {
            Form2.fit_cover = (int)fitCover_numUD.Value;
        }
    }
}
