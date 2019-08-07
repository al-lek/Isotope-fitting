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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            peak_listView.BeginUpdate();
            peak_listView.Items.Clear();
            foreach (double[] peak in Form2.peak_points)
            {
                ListViewItem listviewitem = new ListViewItem(new string[] { Math.Round((peak[1] + peak[4]), 6).ToString(), Math.Round((peak[5]), 2).ToString(), Math.Round((peak[3]), 0).ToString() });
                peak_listView.Items.Add(listviewitem);                
            }
            peak_listView.EndUpdate();
        }
    }
}
