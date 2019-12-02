using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;

namespace Isotope_fitting
{
    public partial class Form9 : Form
    {
        private double ppmError9=8.0;        
        private bool[] selection_rule9 = new bool[] { true, false, false, false, false, false };
        private ListViewItemComparer _lvwItemComparer;
        public Form9()
        {
            InitializeComponent();
            ppm9_numUD.ValueChanged += (s, e) => { ppmError9 = (double)ppm9_numUD.Value; };
            one_rdBtn9.CheckedChanged += (s, e) => { selection_rule9[0]=one_rdBtn9.Checked; };
            two_rdBtn.CheckedChanged += (s, e) => { selection_rule9[0] =two_rdBtn.Checked; };
            three_rdBtn.CheckedChanged += (s, e) => { selection_rule9[0] =three_rdBtn.Checked; };
            half_rdBtn.CheckedChanged += (s, e) => { selection_rule9[0] = half_rdBtn.Checked; };
            half_minus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[0] =half_minus_rdBtn.Checked; };
            half_plus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[0] =half_plus_rdBtn.Checked; };
            one_rdBtn9.Checked = selection_rule9[0]; 
            two_rdBtn.Checked = selection_rule9[1];
            three_rdBtn.Checked = selection_rule9[2];
            half_rdBtn.Checked = selection_rule9[3];
            half_minus_rdBtn.Checked = selection_rule9[4];
            half_plus_rdBtn.Checked = selection_rule9[5];

        }

        private void fragListView9_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == SortOrder.Ascending)
                {
                    _lvwItemComparer.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwItemComparer.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.fragListView9.Sort();
        }
    }
}
