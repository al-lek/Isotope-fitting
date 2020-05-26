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
    public partial class Form18 : Form
    {
        Form2 frm2;
        public Form18(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.ms_heavy_chain = false;
            frm2.ms_light_chain = false;
            this.Close();
        }

        private void HeavyradioButton_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ms_heavy_chain = true;
            frm2.ms_light_chain = false;
        }

        private void LightradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            frm2.ms_heavy_chain = false;
            frm2.ms_light_chain = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form18_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
