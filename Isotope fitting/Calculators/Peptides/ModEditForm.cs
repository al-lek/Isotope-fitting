using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isotope_fitting._2.Calculators._2.a.Peptides
{
    public partial class ModEditForm : Form
    {
        public List<string> inputVals { get; set; }
        public ModEditForm()
        {
            InitializeComponent();
           
        }

        private void modEditOKBtn_Click(object sender, EventArgs e)
        {
            inputVals = new List<string>
            {
                txtName.Text,
                txtLoss.Text,
                txtGain.Text,               
                txtAR.Text,
                txtAI.Text,
                txtAP.Text,
                txtDesc.Text
            };
            
            this.Close();
        }
    }
}
