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
    public partial class Form17 : Form
    {
        Form2 frm2;
        public Form17(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            textBox1.Text =frm2.error_string;
        }

        private void Form17_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
