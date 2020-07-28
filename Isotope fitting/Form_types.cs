using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Form_types : Form
    {
        Form2 frm2;
        bool is_view = false;
        bool changed = false;
        public Form_types(Form2 f,bool v)
        {
            InitializeComponent();
            frm2 = f;
            is_view = v;
            create_checkboxes();
        }
        private void create_checkboxes()
        {
            foreach (string s in frm2.frag)
            {
                CheckBox chk = new CheckBox() {Text=s ,AutoSize=true};
                if (is_view && frm2.view_frag.Any(p=>p.Equals(s))) {chk.Checked = true; }
                else if(!is_view && frm2.label_frag.Any(p => p.Equals(s))) { chk.Checked = true; }
                flowPanel.Controls.Add(chk);
            }
            changed = false;
        }
        private Color give_color()
        {
            Color clr = Color.Orange;
            return clr;
        }
        private void ok_btn_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (CheckBox chk in flowPanel.Controls)
            {
                if (chk.Checked) temp.Add(chk.Text.ToString());
            }
            if (is_view) { frm2.view_frag = temp.ToArray(); }
            else { frm2.label_frag = temp.ToArray(); }
            changed = true;
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            flowPanel.Controls.Clear();
            create_checkboxes();
        }

        private void check_allBtn_Click(object sender, EventArgs e)
        {
            changed = true;
            un_check_all_checkboxes(flowPanel, true);
        }

        private void uncheck_allBtn_Click(object sender, EventArgs e)
        {
            changed = true;
            un_check_all_checkboxes(flowPanel, false);
        }

        private void Form_types_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changed) frm2.external_refresh_isoplot();
        }
    }
}
