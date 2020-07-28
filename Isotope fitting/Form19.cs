using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Form19 : Form
    {
        Form2 frm2;
        bool help = false;
        public Form19(Form2 f, bool h = false)
        {
            InitializeComponent();
            frm2 = f;
            help = h;
            ignore_ppm_chkBox.Checked=frm2.ignore_ppm_refresh;
            ppm_numUD.TextChanged += new EventHandler(ppm_numUD_TextChanged);
            fragGrps_numUD.TextChanged += new EventHandler(fragGrps_numUD_TextChanged);
            thre_numUD.TextChanged += new EventHandler(thre_numUD_TextChanged);
            ppm_numUD.Value = (decimal)frm2.ppmError;
            fragGrps_numUD.Value = (decimal)frm2.frag_mzGroups;
            update_peakSelection_rule(true);
            foreach (RadioButton rdBtn in entire_grpBx.Controls.OfType<RadioButton>()) rdBtn.CheckedChanged += (s, e) => { if (rdBtn.Checked) update_peakSelection_rule(); };
            entire_chkBx.Checked = frm2.entire_spectrum;
            regions_chkBx.Checked = !frm2.entire_spectrum;
            thre_numUD.Value = (decimal)frm2.threshold;
            //ppm region controls
            num_min_1.TextChanged += new EventHandler(num_min_1_TextChanged);
            num_min_2.TextChanged += new EventHandler(num_min_2_TextChanged);
            num_min_3.TextChanged += new EventHandler(num_min_3_TextChanged);
            num_min_4.TextChanged += new EventHandler(num_min_4_TextChanged);
            num_min_5.TextChanged += new EventHandler(num_min_5_TextChanged);
            num_min_6.TextChanged += new EventHandler(num_min_6_TextChanged);
            num_max_1.TextChanged += new EventHandler(num_max_1_TextChanged);
            num_max_2.TextChanged += new EventHandler(num_max_2_TextChanged);
            num_max_3.TextChanged += new EventHandler(num_max_3_TextChanged);
            num_max_4.TextChanged += new EventHandler(num_max_4_TextChanged);
            num_max_5.TextChanged += new EventHandler(num_max_5_TextChanged);
            num_max_6.TextChanged += new EventHandler(num_max_6_TextChanged);
            ppm_1.TextChanged += new EventHandler(ppm_1_TextChanged);
            ppm_2.TextChanged += new EventHandler(ppm_2_TextChanged);
            ppm_3.TextChanged += new EventHandler(ppm_3_TextChanged);
            ppm_4.TextChanged += new EventHandler(ppm_4_TextChanged);
            ppm_5.TextChanged += new EventHandler(ppm_5_TextChanged);
            ppm_6.TextChanged += new EventHandler(ppm_6_TextChanged);
            update_specific_region();

            FormClosed += (s, e) => { f.save_preferences(); };
        }
        void thre_numUD_TextChanged(object sender, EventArgs e)
        {
            if (thre_numUD.ActiveControl != null && !string.IsNullOrEmpty(thre_numUD.ActiveControl.Text))
            {
                frm2.threshold = double.Parse(thre_numUD.ActiveControl.Text);
            }
        }
        private void save_Btn_Click(object sender, EventArgs e)
        {
            frm2.save_preferences();
            //this.Close();
        }
        private void regions_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            entire_chkBx.Checked = !regions_chkBx.Checked;
            region_grpBox.Enabled = regions_chkBx.Checked;
            frm2.entire_spectrum = !regions_chkBx.Checked;
        }
        private void entire_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            regions_chkBx.Checked = !entire_chkBx.Checked;
            frm2.entire_spectrum= entire_chkBx.Checked;
        }
        
        #region entire spectrum
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
            List<RadioButton> rdBtns = GetControls(entire_grpBx).OfType<RadioButton>().ToList();
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
        #endregion
        
        #region specific regions
        private void update_specific_region()
        {
            num_min_1.Value = (decimal)frm2.ppm_regions[0].Min;
            num_min_2.Value = (decimal)frm2.ppm_regions[1].Min;
            num_min_3.Value = (decimal)frm2.ppm_regions[2].Min;
            num_min_4.Value = (decimal)frm2.ppm_regions[3].Min;
            num_min_5.Value = (decimal)frm2.ppm_regions[4].Min;
            num_min_6.Value = (decimal)frm2.ppm_regions[5].Min;
            num_max_1.Value = (decimal)frm2.ppm_regions[0].Max;
            num_max_2.Value = (decimal)frm2.ppm_regions[1].Max;
            num_max_3.Value = (decimal)frm2.ppm_regions[2].Max;
            num_max_4.Value = (decimal)frm2.ppm_regions[3].Max;
            num_max_5.Value = (decimal)frm2.ppm_regions[4].Max;
            num_max_6.Value = (decimal)frm2.ppm_regions[5].Max;
            ppm_1.Value = (decimal)frm2.ppm_regions[0].Max_ppm;
            ppm_2.Value = (decimal)frm2.ppm_regions[1].Max_ppm;
            ppm_3.Value = (decimal)frm2.ppm_regions[2].Max_ppm;
            ppm_4.Value = (decimal)frm2.ppm_regions[3].Max_ppm;
            ppm_5.Value = (decimal)frm2.ppm_regions[4].Max_ppm;
            ppm_6.Value = (decimal)frm2.ppm_regions[5].Max_ppm;
            chkBx_1.Checked = frm2.ppm_regions[0].Chk;
            chkBx_2.Checked = frm2.ppm_regions[1].Chk;
            chkBx_3.Checked = frm2.ppm_regions[2].Chk;
            chkBx_4.Checked = frm2.ppm_regions[3].Chk;
            chkBx_5.Checked = frm2.ppm_regions[4].Chk;
            chkBx_6.Checked = frm2.ppm_regions[5].Chk;
            selection_list_1.SelectedIndex = frm2.ppm_regions[0].Rule;
            selection_list_2.SelectedIndex = frm2.ppm_regions[1].Rule;
            selection_list_3.SelectedIndex = frm2.ppm_regions[2].Rule;
            selection_list_4.SelectedIndex = frm2.ppm_regions[3].Rule;
            selection_list_5.SelectedIndex = frm2.ppm_regions[4].Rule;
            selection_list_6.SelectedIndex = frm2.ppm_regions[5].Rule;

        }

        //region check
        private void chkBx_1_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[0].Chk=num_min_1.Enabled = num_max_1.Enabled = ppm_1.Enabled = selection_list_1.Enabled = chkBx_1.Checked;           
        }
        private void chkBx_2_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[1].Chk = num_min_2.Enabled = num_max_2.Enabled = ppm_2.Enabled = selection_list_2.Enabled = chkBx_2.Checked;
        }
        private void chkBx_3_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[2].Chk = num_min_3.Enabled = num_max_3.Enabled = ppm_3.Enabled = selection_list_3.Enabled = chkBx_3.Checked;
        }
        private void chkBx_4_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[3].Chk = num_min_4.Enabled = num_max_4.Enabled = ppm_4.Enabled = selection_list_4.Enabled = chkBx_4.Checked;
        }
        private void chkBx_5_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[4].Chk = num_min_5.Enabled = num_max_5.Enabled = ppm_5.Enabled = selection_list_5.Enabled = chkBx_5.Checked;
        }
        private void chkBx_6_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[5].Chk = num_min_6.Enabled = num_max_6.Enabled = ppm_6.Enabled = selection_list_6.Enabled = chkBx_6.Checked;
        }

        //min mz
        void num_min_1_TextChanged(object sender, EventArgs e)
        {
            if (num_min_1.ActiveControl != null && !string.IsNullOrEmpty(num_min_1.ActiveControl.Text))
            {
                frm2.ppm_regions[0].Min = Double.Parse(num_min_1.ActiveControl.Text);
            }
        }
        void num_min_2_TextChanged(object sender, EventArgs e)
        {
            if (num_min_2.ActiveControl != null && !string.IsNullOrEmpty(num_min_2.ActiveControl.Text))
            {
                frm2.ppm_regions[1].Min = Double.Parse(num_min_2.ActiveControl.Text);
            }
        }
        void num_min_3_TextChanged(object sender, EventArgs e)
        {
            if (num_min_3.ActiveControl != null && !string.IsNullOrEmpty(num_min_3.ActiveControl.Text))
            {
                frm2.ppm_regions[2].Min = Double.Parse(num_min_3.ActiveControl.Text);
            }
        }
        void num_min_4_TextChanged(object sender, EventArgs e)
        {
            if (num_min_4.ActiveControl != null && !string.IsNullOrEmpty(num_min_4.ActiveControl.Text))
            {
                frm2.ppm_regions[3].Min = Double.Parse(num_min_4.ActiveControl.Text);
            }
        }
        void num_min_5_TextChanged(object sender, EventArgs e)
        {
            if (num_min_5.ActiveControl != null && !string.IsNullOrEmpty(num_min_5.ActiveControl.Text))
            {
                frm2.ppm_regions[4].Min = Double.Parse(num_min_5.ActiveControl.Text);
            }
        }
        void num_min_6_TextChanged(object sender, EventArgs e)
        {
            if (num_min_6.ActiveControl != null && !string.IsNullOrEmpty(num_min_6.ActiveControl.Text))
            {
                frm2.ppm_regions[5].Min = Double.Parse(num_min_6.ActiveControl.Text);
            }
        }

        //max mz 
        void num_max_1_TextChanged(object sender, EventArgs e)
        {
            if (num_max_1.ActiveControl != null && !string.IsNullOrEmpty(num_max_1.ActiveControl.Text))
            {
                frm2.ppm_regions[0].Max = Double.Parse(num_max_1.ActiveControl.Text);
            }
        }
        void num_max_2_TextChanged(object sender, EventArgs e)
        {
            if (num_max_2.ActiveControl != null && !string.IsNullOrEmpty(num_max_2.ActiveControl.Text))
            {
                frm2.ppm_regions[1].Max = Double.Parse(num_max_2.ActiveControl.Text);
            }
        }
        void num_max_3_TextChanged(object sender, EventArgs e)
        {
            if (num_max_3.ActiveControl != null && !string.IsNullOrEmpty(num_max_3.ActiveControl.Text))
            {
                frm2.ppm_regions[2].Max = Double.Parse(num_max_3.ActiveControl.Text);
            }
        }
        void num_max_4_TextChanged(object sender, EventArgs e)
        {
            if (num_max_4.ActiveControl != null && !string.IsNullOrEmpty(num_max_4.ActiveControl.Text))
            {
                frm2.ppm_regions[3].Max = Double.Parse(num_max_4.ActiveControl.Text);
            }
        }
        void num_max_5_TextChanged(object sender, EventArgs e)
        {
            if (num_max_5.ActiveControl != null && !string.IsNullOrEmpty(num_max_5.ActiveControl.Text))
            {
                frm2.ppm_regions[4].Max = Double.Parse(num_max_5.ActiveControl.Text);
            }
        }
        void num_max_6_TextChanged(object sender, EventArgs e)
        {
            if (num_max_6.ActiveControl != null && !string.IsNullOrEmpty(num_max_6.ActiveControl.Text))
            {
                frm2.ppm_regions[5].Max = Double.Parse(num_max_6.ActiveControl.Text);
            }
        }

        //ppm
        void ppm_1_TextChanged(object sender, EventArgs e)
        {
            if (ppm_1.ActiveControl != null && !string.IsNullOrEmpty(ppm_1.ActiveControl.Text))
            {
                frm2.ppm_regions[0].Max_ppm = Double.Parse(ppm_1.ActiveControl.Text);
            }
        }
        void ppm_2_TextChanged(object sender, EventArgs e)
        {
            if (ppm_2.ActiveControl != null && !string.IsNullOrEmpty(ppm_2.ActiveControl.Text))
            {
                frm2.ppm_regions[1].Max_ppm = Double.Parse(ppm_2.ActiveControl.Text);
            }
        }
        void ppm_3_TextChanged(object sender, EventArgs e)
        {
            if (ppm_3.ActiveControl != null && !string.IsNullOrEmpty(ppm_3.ActiveControl.Text))
            {
                frm2.ppm_regions[2].Max_ppm = Double.Parse(ppm_3.ActiveControl.Text);
            }
        }
        void ppm_4_TextChanged(object sender, EventArgs e)
        {
            if (ppm_4.ActiveControl != null && !string.IsNullOrEmpty(ppm_4.ActiveControl.Text))
            {
                frm2.ppm_regions[3].Max_ppm = Double.Parse(ppm_4.ActiveControl.Text);
            }
        }
        void ppm_5_TextChanged(object sender, EventArgs e)
        {
            if (ppm_5.ActiveControl != null && !string.IsNullOrEmpty(ppm_5.ActiveControl.Text))
            {
                frm2.ppm_regions[4].Max_ppm = Double.Parse(ppm_5.ActiveControl.Text);
            }
        }
        void ppm_6_TextChanged(object sender, EventArgs e)
        {
            if (ppm_6.ActiveControl != null && !string.IsNullOrEmpty(ppm_6.ActiveControl.Text))
            {
                frm2.ppm_regions[5].Max_ppm = Double.Parse(ppm_6.ActiveControl.Text);
            }
        }

        //selection rule
        private void selection_list_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[0].Rule= selection_list_1.SelectedIndex;
        }
        private void selection_list_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[1].Rule = selection_list_2.SelectedIndex;
        }
        private void selection_list_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[2].Rule = selection_list_3.SelectedIndex;
        }
        private void selection_list_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[3].Rule = selection_list_4.SelectedIndex;
        }
        private void selection_list_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[4].Rule = selection_list_5.SelectedIndex;
        }
        private void selection_list_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            frm2.ppm_regions[5].Rule = selection_list_6.SelectedIndex;
        }
        #endregion

        private void Form19_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void exclusionList_Btn_Click(object sender, EventArgs e)
        {
            Form21 frm21 = new Form21(frm2);            
            frm21.ShowDialog();
        }
       
        private void ignore_ppm_chkBox_Click(object sender, EventArgs e)
        {
            frm2.ignore_ppm_refresh = ignore_ppm_chkBox.Checked;
        }
    }
}
