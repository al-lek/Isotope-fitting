using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;

namespace Isotope_fitting
{
    public partial class Form4 : Form
    {
        double m = 0.0;
        double Dm = 0.0;
        double mDm = 0.0;
        double mcent = 0.0;
        List<float> current_mz = new List<float>();
        List<float> current_R = new List<float>();
        List<float> current_Dm = new List<float>();

        private ListViewItemComparer _lvwItemComparer;
        public static  bool active = false;
        public static int machine_enum = 0;
        public static string new_machine = "no";
        bool changed = true;
        string loaded_res_name = "";

        public Form4()
        {
            this.Focus();
            active = true;
            InitializeComponent();
            m_Box.Focus();
            m_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) mDm_Box.Focus(); };
            mDm_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) Dm_Box.Focus(); };
            Dm_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) centBox.Focus(); };
            centBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) addR_button.Focus(); };
            _lvwItemComparer = new ListViewItemComparer();
            resListView.ListViewItemSorter = _lvwItemComparer;
            _lvwItemComparer.SortColumn = 0;
            _lvwItemComparer.Order = SortOrder.Ascending;
            machine_enum++;
            Initialize_variables();
            current_mz.Clear();
            current_R.Clear();
            ContextMenu ctxMn4 = new ContextMenu() { };
            MenuItem delete_item = new MenuItem("Delete", delete_listitem);
            ctxMn4.MenuItems.AddRange(new MenuItem[] { delete_item });
            resListView.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn4; } };
        }


        #region UI
        private void MDmBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Dm_Box.Text)) { Dm_Box.Text = null; Dm = 0.0; }

            if (!string.IsNullOrEmpty(mDm_Box.Text))
            {
                try
                {
                    double.Parse(mDm_Box.Text, NumberStyles.AllowDecimalPoint);

                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    mDm_Box.Text = mDm_Box.Text.Remove(startIndex: mDm_Box.Text.Length - 1);
                }
            }
        }

        private void DmBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mDm_Box.Text)) { mDm_Box.Text = null; mDm = 0.0; }
            if (!string.IsNullOrEmpty(Dm_Box.Text))
            {
                try
                {
                    double.Parse(Dm_Box.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    Dm_Box.Text = Dm_Box.Text.Remove(startIndex: Dm_Box.Text.Length - 1);
                }
            }
        }

        private void CentBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(centBox.Text))
            {
                try
                {
                    double.Parse(centBox.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    centBox.Text = centBox.Text.Remove(centBox.Text.Length - 1);
                }
            }
        }

        private void MBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_Box.Text))
            {
                try
                {
                    double.Parse(m_Box.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    m_Box.Text = m_Box.Text.Remove(startIndex: m_Box.Text.Length - 1);
                }
            }
        }
        #endregion
        private void delete_listitem(object sender, EventArgs e)
        {
            List<int> to_delete_idx = new List<int>();
            ListView.SelectedListViewItemCollection selectedItems = resListView.SelectedItems;
            if ((sender as MenuItem).Text == "Delete" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    resListView.Items.Remove(item);
                }
            }
            if (loaded_res_name!="")
            {
                changed = true;
            }
        }

        private void Initialize_variables()
        {
            m = 0.0;
            Dm = 0.0;
            mDm = 0.0;
            mcent = 0.0;
            Dm_Box.Text = null;
            m_Box.Text = null;
            mDm_Box.Text = null;
            centBox.Text = null;
        }

        

        private void AddR_button_Click(object sender, EventArgs e)
        {
            double res = 0.0f;
            if (!string.IsNullOrEmpty(centBox.Text) && !string.IsNullOrEmpty(m_Box.Text)&&(!string.IsNullOrEmpty(Dm_Box.Text) || !string.IsNullOrEmpty(mDm_Box.Text)))
            {                
                mcent = double.Parse(centBox.Text, NumberStyles.AllowDecimalPoint);
                m = double.Parse(m_Box.Text, NumberStyles.AllowDecimalPoint);                
                if (!string.IsNullOrEmpty(mDm_Box.Text)) { mDm = double.Parse(mDm_Box.Text, NumberStyles.AllowDecimalPoint); Dm = mDm - m;}
                else {Dm = double.Parse(Dm_Box.Text, NumberStyles.AllowDecimalPoint); mDm = m + Dm; }
                if (mcent.Equals(0) || Dm.Equals(0))
                {
                    MessageBox.Show("Centroid and Dm cannot be equal to zero.", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Initialize_variables();return;
                }
                if (mcent<m || mcent>mDm)
                {
                    MessageBox.Show("This inequality should apply:  m < Centroid < m+Dm ", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Initialize_variables(); return;
                }
                res = mcent / Dm;               
                resListView.BeginUpdate();
                var listViewItem = new ListViewItem(mcent.ToString());
                listViewItem.SubItems.Add(res.ToString());
                resListView.Items.Add(listViewItem);
                resListView.EndUpdate();
                Initialize_variables();
                m_Box.Focus();
                if (loaded_res_name != "")
                {
                    changed = true;
                }
            }
            else
            {
                MessageBox.Show("Not enough input variables!Please complete m,Dm,Centroid or m,m+Dm,Centroid", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }  
        }
      
        private void Complete_Btn_Click(object sender, EventArgs e)
        {
            double[] tmp1 =new double[resListView.Items.Count];
            double[] tmp2 = new double[resListView.Items.Count];           

            try
            {
                for (int c = 0; c < resListView.Items.Count; c++)
                {
                    tmp1[c] = double.Parse(resListView.Items[c].SubItems[0].Text, CultureInfo.InvariantCulture.NumberFormat);
                    tmp2[c] = double.Parse(resListView.Items[c].SubItems[1].Text, CultureInfo.InvariantCulture.NumberFormat);
                }
                Array.Sort(tmp1, tmp2);
            }
            catch { MessageBox.Show("Error in input values! Please try again.", "Error!"); return; }

            if (changed)
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save 'Custom Resolution' data", FileName = "Custom" + machine_enum.ToString(), Filter = "Data Files (*.cr)|*.cr", DefaultExt = "cr", OverwritePrompt = true, AddExtension = true };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                    file.WriteLine("Mode:\tCustom Resolution");
                    for (int r = 0; r < tmp1.Count(); r++) file.WriteLine(tmp1[r] + "\t" + tmp2[r]);
                    new_machine = Path.GetFileNameWithoutExtension(save.FileName);
                    file.Flush(); file.Close(); file.Dispose();
                    Resolution_List.L.Add(new_machine, new Resolution_List.MachineR(tmp1, tmp2));
                    active = false;
                    this.Close();
                }
            }
            else
            {
                //var result = tmp2.Select(n => n * 1.5f);
                //tmp2 = result.ToArray();
                new_machine = loaded_res_name;
                Resolution_List.L.Add(new_machine, new Resolution_List.MachineR(tmp1, tmp2));
                active = false;
                this.Close();
            }
        }

        private void loadRes_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";
            loadData.Title = "Load 'Custom Resolution' data"; loadData.FileName = "";
            loadData.Filter = "data file|*.cr|All files|*.*";

            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                fullPath = loadData.FileName;
                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);
                loaded_res_name = Path.GetFileNameWithoutExtension(fullPath);
                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();
                int arrayPositionIndex = 0;

                for (int j = 0; j != (lista.Count); j++)
                {
                    string[] str = new string[3];
                    try
                    {
                        str = lista[j].Split('\t');
                        if (j == 0 && !str[1].Equals("Custom Resolution")) { MessageBox.Show("Error! not a 'Custom Resolution' file!", "Error!"); return; }
                        if (lista[j] == "") continue;
                        else if (lista[j].StartsWith("Mode")) continue;
                        else
                        {
                            current_mz.Add(float.Parse(str[0], CultureInfo.InvariantCulture.NumberFormat));
                            current_R.Add(float.Parse(str[1], CultureInfo.InvariantCulture.NumberFormat));                            
                        }
                        arrayPositionIndex++;
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                }
            }
            resListView.BeginUpdate();
            for (int r=0;r<current_mz.Count() ;r++)
            {
                var listViewItem = new ListViewItem(current_mz[r].ToString());
                listViewItem.SubItems.Add(current_R[r].ToString());
                resListView.Items.Add(listViewItem);
            }
            resListView.EndUpdate();
            changed = false;
        }

        private void Form4_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
