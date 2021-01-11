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
    public partial class Exp_set_Form : Form
    {
        Form2 frm2;
        bool help = false;
        public Exp_set_Form(Form2 f,bool h=false)
        {
            InitializeComponent();
            frm2 = f;
            help = h;
            //minIntensity_numUD.TextChanged += new EventHandler(minIntensity_numUD_TextChanged);
            minIntensity_numUD.Value = (decimal)frm2.min_intes;
            constRes_radBtn.Checked = frm2.is_deconv_const_resolution;
            listRes_radBtn.Checked = !constRes_radBtn.Checked;
        }
       

        private void Form8_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

       

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Saves resolution value.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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
            if (help) { MessageBox.Show("Saves minimum intensity value. To recreate the peak list based on the new minimum intensity value the user needs to click the 'Recalculate peak list' button.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            frm2.min_intes = (double)minIntensity_numUD.Value;
        }

        private void recalc_Exp_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Recalculate the experimental profile based on the current 'saved' resolution value.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!frm2.is_exp_deconvoluted) { MessageBox.Show("Applies only for deconvoluted spectra. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
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

        private void recalc_peakBtn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Recalculate the peak list based on the current 'saved' minimum intensity value.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            frm2.recalc_peaks();
        }

        private void minIntensity_lbl_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set the minimum intensity value for which a peak in the experimental spectrum is considered a peak and is added to the 'Peak List'.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void selection_list_1_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set resolution as a constant value irrespective of m/z.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void resolution_list_combBox_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Select a resolution list that corresponds to a specific Machine. Each list consists of pairs of m/z and resolution values.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void save_decovBtn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Save Experimental profile (m/z intensity) in a .txt file. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!frm2.is_exp_deconvoluted) { MessageBox.Show("Applies only for deconvoluted spectra. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            SaveFileDialog save = new SaveFileDialog() { Title = "Save Experimental Profile", FileName = frm2.file_name +"_profile", Filter = "Data Files (*.txt)|*.txt", DefaultExt = "txt", OverwritePrompt = true, AddExtension = true };            
            if (save.ShowDialog() == DialogResult.OK) { frm2.Project_save_experimental(save.FileName); }           
        }
    }
}
