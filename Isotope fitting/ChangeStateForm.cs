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
    public partial class ChangeStateForm : Form
    {
        Form2 frm2;
        bool temp_riken = false;
        public ChangeStateForm(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            this.Text = frm2.Text;
            temp_riken= frm2.is_riken;
            if (frm2.is_riken) oligonoucl_state_Btn.BackColor =Color.LightBlue;
            else peptide_state_Btn.BackColor = Color.LightBlue;
            RNA_Btn.Visible = DNA_Btn.Visible = temp_riken;
            RNA_Btn.Checked = frm2.is_rna;
            DNA_Btn.Checked = !frm2.is_rna;
        }

        private void oligonoucl_state_Btn_Click(object sender, EventArgs e)
        {
            oligonoucl_state_Btn.BackColor = Color.LightBlue;
            peptide_state_Btn.BackColor = Color.Transparent;
            temp_riken = true;
            RNA_Btn.Visible = DNA_Btn.Visible = temp_riken;
        }

        private void peptide_state_Btn_Click(object sender, EventArgs e)
        {
            peptide_state_Btn.BackColor = Color.LightBlue;
            oligonoucl_state_Btn.BackColor = Color.Transparent;
            temp_riken = false;
            RNA_Btn.Visible = DNA_Btn.Visible = temp_riken;
        }

        private void peptide_state_Lbl_Click(object sender, EventArgs e)
        {
            peptide_state_Btn.BackColor = Color.LightBlue;
            oligonoucl_state_Btn.BackColor = Color.Transparent;
            temp_riken = false;
            RNA_Btn.Visible = DNA_Btn.Visible = temp_riken;
        }

        private void oligonoucl_state_Lbl_Click(object sender, EventArgs e)
        {
            oligonoucl_state_Btn.BackColor = Color.LightBlue;
            peptide_state_Btn.BackColor = Color.Transparent;
            temp_riken = true;      
            RNA_Btn.Visible = DNA_Btn.Visible = temp_riken;
        }

        private void save_stateBtn_Click(object sender, EventArgs e)
        {
            if (temp_riken &&! RNA_Btn.Checked && !DNA_Btn.Checked) { MessageBox.Show("Please select base sequence type (RNA,DNA).");return; }
            if (temp_riken) frm2.is_rna = RNA_Btn.Checked;
            else frm2.is_rna = false;
            if (frm2.is_riken==temp_riken) { frm2.change_application(false); }
            else
            {                
                frm2.is_riken = temp_riken;
                frm2.change_application();
            }
            this.Close();
        }


     
    }
}
