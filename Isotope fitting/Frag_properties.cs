using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Frag_properties : Form
    {
        FragForm initial_fra = new FragForm();
        FragForm new_fra = new FragForm();
        Form2 frm2;
        int index_list;
        private System.Windows.Forms.TextBox editBox;
        public Frag_properties(FragForm fra, int i, Form2 f)
        {
            InitializeComponent();
            initialize_labels();
            frm2 = f;
            index_list = i;
            initial_fra = new FragForm()
            {
                Name = fra.Name,
                Index = fra.Index,
                IndexTo = fra.IndexTo,
                SortIdx = fra.SortIdx,
                Ion_type = fra.Ion_type,
                Has_adduct = fra.Has_adduct,
                Fixed = fra.Fixed,
            };
            initialize_List(initial_fra);
        }
        private void initialize_labels()
        {
            label1.Text = "Name";
            label2.Text = "Ion Type";
            label3.Text = "Index in AA sequence \n(start)";
            label4.Text = "Index in AA sequence \n(end)";
            label5.Text = "Index in AA sequence \n(count from left)";
            label6.Text = "Saved";
            label7.Text = "Modified";
        }
        private void initialize_List(FragForm fra)
        {
            textBox1.Text = fra.Name.ToString();
            textBox2.Text = fra.Ion_type.ToString();
            textBox3.Text = fra.Index.ToString();
            textBox4.Text = fra.IndexTo.ToString();
            textBox5.Text = fra.SortIdx.ToString();
            checkBox1.Checked = fra.Fixed;
            checkBox2.Checked = fra.Has_adduct;
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            bool is_ok = false;
            is_ok = int.TryParse(textBox3.Text.ToString(), out int index);
            if (!is_ok || index < 0) { MessageBox.Show("Index (start) input is not in the correct format. Please enter only intergers"); return; }
            is_ok = int.TryParse(textBox4.Text.ToString(), out int indexto);
            if (!is_ok || indexto < 0) { MessageBox.Show("Index (end) input is not in the correct format. Please enter only intergers"); return; }
            is_ok = int.TryParse(textBox5.Text.ToString(), out int indexsort);
            if (!is_ok || indexsort < 0) { MessageBox.Show("Index (count from left) input is not in the correct format. Please enter only intergers"); return; }

            initial_fra = new FragForm()
            {
                Name = textBox1.Text.ToString(),
                Index = index.ToString(),
                IndexTo = indexto.ToString(),
                SortIdx = indexsort,
                Ion_type = textBox2.Text.ToString(),
                Has_adduct = checkBox2.Checked,
                Fixed = checkBox1.Checked
            };
            frm2.change_Fragment(initial_fra, index_list);
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            initialize_List(initial_fra);
        }
    }
}
