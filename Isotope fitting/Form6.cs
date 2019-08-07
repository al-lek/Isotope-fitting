using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            ppm_txtBox.Text =Form2.ppmError.ToString();
            minInt_TxtBox.Text= Form2.min_intes.ToString();
        }

        private void ppm_txtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ppm_txtBox.Text))
            {
                try
                {
                   double.Parse(ppm_txtBox.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    ppm_txtBox.Text = ppm_txtBox.Text.Remove(ppm_txtBox.Text.Length - 1);
                }
            }
        }

        private void saveppmBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(minInt_TxtBox.Text))
            {
                Form2.min_intes = double.Parse(minInt_TxtBox.Text, NumberStyles.AllowDecimalPoint);
            }
            if (!string.IsNullOrEmpty(ppm_txtBox.Text))
            {
                Form2.ppmError = double.Parse(ppm_txtBox.Text, NumberStyles.AllowDecimalPoint);
            }
            this.Hide();
        }

        private void minInt_TxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(minInt_TxtBox.Text))
            {
                try
                {
                    double.Parse(minInt_TxtBox.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    minInt_TxtBox.Text = minInt_TxtBox.Text.Remove(minInt_TxtBox.Text.Length - 1);
                }
            }
        }
    }
}
