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
    public partial class Form16 : Form
    {
        Form2 frm2;
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
    }
}
