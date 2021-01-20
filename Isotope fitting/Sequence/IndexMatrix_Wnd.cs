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
    public partial class IndexMatrix_Wnd : Form
    {
        public IndexMatrix_Wnd(List<string[]> frags)
        {
            InitializeComponent();
            fill_peak_listView(frags);
        }
        private void fill_peak_listView(List<string[]> frags)
        {
            frag_listView.BeginUpdate();
            frag_listView.Items.Clear();
            foreach (string[] frag in frags)
            {
                ListViewItem listviewitem = new ListViewItem(new string[] { frag[0], frag[1], frag[2], frag[3] });
                frag_listView.Items.Add(listviewitem);
            }           
            frag_listView.EndUpdate();
        }
    }
}
