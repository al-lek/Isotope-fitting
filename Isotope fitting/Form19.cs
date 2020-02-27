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
    public partial class Form19 : Form
    {
        Form2 frm2;
        public Form19(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            ppm_numUD.TextChanged += new EventHandler(ppm_numUD_TextChanged);
            fragGrps_numUD.TextChanged += new EventHandler(fragGrps_numUD_TextChanged);
            ppm_numUD.Value = (decimal)frm2.ppmError;
            fragGrps_numUD.Value = (decimal)frm2.frag_mzGroups;
            update_peakSelection_rule(true);
            foreach (RadioButton rdBtn in entire_grpBx.Controls.OfType<RadioButton>()) rdBtn.CheckedChanged += (s, e) => { if (rdBtn.Checked) update_peakSelection_rule(); };
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            region_grpBox.Enabled = regions_chkBx.Checked;
        }

        void ppm_numUD_TextChanged(object sender, EventArgs e)
        {
            if (ppm_numUD.ActiveControl != null && !string.IsNullOrEmpty(ppm_numUD.ActiveControl.Text))
            {
                frm2.ppmError = double.Parse(ppm_numUD.ActiveControl.Text);
            }
        }
        void fragGrps_numUD_TextChanged(object sender, EventArgs e)
        {
            if (fragGrps_numUD.ActiveControl != null && !string.IsNullOrEmpty(fragGrps_numUD.ActiveControl.Text))
            {
                frm2.frag_mzGroups = int.Parse(fragGrps_numUD.ActiveControl.Text);
            }
        }
        private void update_peakSelection_rule(bool initial=false)
        {
            // update selection rule from all radiobuttons
            List<RadioButton> rdBtns = Form2.GetControls(entire_grpBx).OfType<RadioButton>().ToList();
            if (initial)
            {
                foreach (RadioButton rdBtn in rdBtns)
                    rdBtn.Checked= frm2.selection_rule[rdBtn.TabIndex];
            }
            else
            {
                foreach (RadioButton rdBtn in rdBtns)
                    frm2.selection_rule[rdBtn.TabIndex] = rdBtn.Checked;
            }            
        }

        private void num_min_1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkBx_1_CheckedChanged(object sender, EventArgs e)
        {
            num_min_1.Enabled = num_max_1.Enabled = ppm_1.Enabled = selection_list_1.Enabled = chkBx_1.Checked;           
        }

        private void chkBx_2_CheckedChanged(object sender, EventArgs e)
        {
            num_min_2.Enabled = num_max_2.Enabled = ppm_2.Enabled = selection_list_2.Enabled = chkBx_2.Checked;
        }

        private void chkBx_3_CheckedChanged(object sender, EventArgs e)
        {
            num_min_3.Enabled = num_max_3.Enabled = ppm_3.Enabled = selection_list_3.Enabled = chkBx_3.Checked;
        }

        private void chkBx_4_CheckedChanged(object sender, EventArgs e)
        {
            num_min_4.Enabled = num_max_4.Enabled = ppm_4.Enabled = selection_list_4.Enabled = chkBx_4.Checked;
        }

        private void chkBx_5_CheckedChanged(object sender, EventArgs e)
        {
            num_min_5.Enabled = num_max_5.Enabled = ppm_5.Enabled = selection_list_5.Enabled = chkBx_5.Checked;
        }

        private void chkBx_6_CheckedChanged(object sender, EventArgs e)
        {
            num_min_6.Enabled = num_max_6.Enabled = ppm_6.Enabled = selection_list_6.Enabled = chkBx_6.Checked;
        }
    }
}
