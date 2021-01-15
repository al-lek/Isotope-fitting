using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;
using static Isotope_fitting.Helpers;

namespace Isotope_fitting._2.Calculators._2.a.Peptides
{
    public partial class UltimateFragmentorCalc : Form
    {
        Form2 frm2;
        public UltimateFragmentorCalc(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
        }

        private void UltimateFragmentorCalc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
