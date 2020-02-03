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

namespace Isotope_fitting
{
    public partial class Form16 : Form
    {
        Form2 frm2;
        string user_txt;
        string output_txt;
        bool active_txt = false;
        public Form16(Form2 f)
        {
            frm2 =f;
            InitializeComponent();
            if (!String.IsNullOrEmpty(frm2.Peptide)) { seq_BoxFrm16.Text = frm2.Peptide.ToString(); }

        }

        private void seq_Btn_Click(object sender, EventArgs e)
        {
            frm2.Peptide = seq_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.Peptide= frm2.Peptide.Replace("\t", "");
            frm2.Peptide = frm2.Peptide.Replace(" ", "");
            this.Close();
        }

        private void seq_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (seq_BoxFrm16.Text.Length>10 && !active_txt)
            {
                active_txt = true;
                user_txt = seq_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt =Regex.Replace(user_txt, @".{10}(?!$)", "$0  "); 

                seq_BoxFrm16.Text= output_txt;
                seq_BoxFrm16.SelectionStart = seq_BoxFrm16.Text.Length;
                seq_BoxFrm16.SelectionLength = 0;

            }
            active_txt = false;
        }
    }
}
