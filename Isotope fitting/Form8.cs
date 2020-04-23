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
    public partial class Form8 : Form
    {
        Form2 frm2;
        public Form8(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            //minIntensity_numUD.TextChanged += new EventHandler(minIntensity_numUD_TextChanged);
            minIntensity_numUD.Value = (decimal)frm2.min_intes;
            constRes_radBtn.Checked = frm2.is_deconv_const_resolution;
            listRes_radBtn.Checked = !constRes_radBtn.Checked;
        }

        //private void minIntensity_numUD_ValueChanged(object sender, EventArgs e)
        //{
        //    Form2.min_intes = (double)minIntensity_numUD.Value;
        //}
        //void minIntensity_numUD_TextChanged(object sender, EventArgs e)
        //{
        //    if (minIntensity_numUD.ActiveControl != null && !string.IsNullOrEmpty(minIntensity_numUD.ActiveControl.Text))
        //    {
        //        Form2.min_intes = double.Parse(minIntensity_numUD.ActiveControl.Text);
        //    }
        //}

        private void Form8_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if ((constRes_radBtn.Checked && selection_list_1.SelectedIndex == -1) ||(listRes_radBtn.Checked && resolution_list_combBox.SelectedIndex == -1))
            {
                MessageBox.Show("First select resolution and then press 'save' button!"); return;

            }
            else if (constRes_radBtn.Checked)
            {
                frm2.deconv_machine = selection_list_1.SelectedItem.ToString();
                frm2.is_deconv_const_resolution=true;
            }
            else
            {
                frm2.deconv_machine = resolution_list_combBox.SelectedItem.ToString();
                frm2.is_deconv_const_resolution =false;
            }
        }

        private void save_peak_btn_Click(object sender, EventArgs e)
        {
            frm2.min_intes = (double)minIntensity_numUD.Value;
        }

        private void recalc_Exp_Btn_Click(object sender, EventArgs e)
        {
            frm2.post_load_actions();
        }

        private void listRes_radBtn_CheckedChanged(object sender, EventArgs e)
        {
            resolution_list_combBox.Enabled = listRes_radBtn.Checked;
        }

        private void constRes_radBtn_CheckedChanged(object sender, EventArgs e)
        {
            selection_list_1.Enabled = constRes_radBtn.Checked;
        }
    }
}
