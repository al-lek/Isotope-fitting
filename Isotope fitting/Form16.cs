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
            if (!String.IsNullOrEmpty(frm2.heavy_chain)) { heavy_BoxFrm16.Text = frm2.heavy_chain.ToString(); }
            if (!String.IsNullOrEmpty(frm2.light_chain)) { light_BoxFrm16.Text = frm2.light_chain.ToString(); }
        }

        private void seq_Btn_Click(object sender, EventArgs e)
        {
            frm2.Peptide = seq_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.Peptide= frm2.Peptide.Replace("\t", "");
            frm2.Peptide = frm2.Peptide.Replace(" ", "");
            frm2.heavy_chain = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.heavy_chain = frm2.heavy_chain.Replace("\t", "");
            frm2.heavy_chain = frm2.heavy_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.heavy_chain)) { frm2.heavy_present = false; }
            else { frm2.heavy_present = true; }
            frm2.light_chain = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.light_chain = frm2.light_chain.Replace("\t", "");
            frm2.light_chain = frm2.light_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.light_chain)) { frm2.light_present = false; }
            else { frm2.light_present = true; }
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

        private void heavy_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (heavy_BoxFrm16.Text.Length > 10 && !active_txt)
            {
                active_txt = true;
                user_txt = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                heavy_BoxFrm16.Text = output_txt;
                heavy_BoxFrm16.SelectionStart = heavy_BoxFrm16.Text.Length;
                heavy_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        private void heavy_Btn_Click(object sender, EventArgs e)
        {
            frm2.heavy_chain = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.heavy_chain = frm2.heavy_chain.Replace("\t", "");
            frm2.heavy_chain = frm2.heavy_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.heavy_chain)) { frm2.heavy_present = false; }
            else { frm2.heavy_present = true; }
            this.Close();
        }

        private void light_BoxFrm16_TextChanged(object sender, EventArgs e)
        {

            if (light_BoxFrm16.Text.Length > 10 && !active_txt)
            {
                active_txt = true;
                user_txt = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                light_BoxFrm16.Text = output_txt;
                light_BoxFrm16.SelectionStart = light_BoxFrm16.Text.Length;
                light_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        private void light_Btn_Click(object sender, EventArgs e)
        {
            frm2.light_chain = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.light_chain = frm2.light_chain.Replace("\t", "");
            frm2.light_chain = frm2.light_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.light_chain)) { frm2.light_present = false; }
            else { frm2.light_present = true; }
            this.Close();
        }

        private void Form16_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
