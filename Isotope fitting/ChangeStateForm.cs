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
    public partial class ChangeStateForm : Form
    {
        Form2 frm2;
        bool temp_riken = false;
        public ChangeStateForm(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            temp_riken= frm2.is_riken;
            if (frm2.is_riken) oligonoucl_state_Btn.BackColor =Color.LightBlue;
            else peptide_state_Btn.BackColor = Color.LightBlue;
        }

        private void oligonoucl_state_Btn_Click(object sender, EventArgs e)
        {
            oligonoucl_state_Btn.BackColor = Color.LightBlue;
            peptide_state_Btn.BackColor = Color.Transparent;
            temp_riken = true;
        }

        private void peptide_state_Btn_Click(object sender, EventArgs e)
        {
            peptide_state_Btn.BackColor = Color.LightBlue;
            oligonoucl_state_Btn.BackColor = Color.Transparent;
            temp_riken = false;
        }

        private void peptide_state_Lbl_Click(object sender, EventArgs e)
        {
            peptide_state_Btn.BackColor = Color.LightBlue;
            oligonoucl_state_Btn.BackColor = Color.Transparent;
            temp_riken = false;
        }

        private void oligonoucl_state_Lbl_Click(object sender, EventArgs e)
        {
            oligonoucl_state_Btn.BackColor = Color.LightBlue;
            peptide_state_Btn.BackColor = Color.Transparent;
            temp_riken = true;            
        }

        private void save_stateBtn_Click(object sender, EventArgs e)
        {
            if (frm2.is_riken==temp_riken) { frm2.change_state(false); }
            else
            {                
                frm2.is_riken = temp_riken;
                frm2.change_state();
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
