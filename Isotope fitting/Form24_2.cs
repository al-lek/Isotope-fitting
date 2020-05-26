using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;


namespace Isotope_fitting
{
    public partial class Form24_2 : Form
    {
        Form2 frm2;

        public Form24_2(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
            if (!string.IsNullOrEmpty(frm2.res_string_24)) resolution_Box.Text = frm2.res_string_24;
            else if (frm2.machine_sel_index != -1) Form24.machine_listBox.SelectedIndex = frm2.machine_sel_index;
            else Form24.machine_listBox.SelectedIndex = 9;
        }

        private void mzMin_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mzMin_Box.Text))
            {
                try
                {
                    double.Parse(mzMin_Box.Text, NumberStyles.AllowDecimalPoint);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    mzMin_Box.Text = mzMin_Box.Text.Remove(mzMin_Box.Text.Length - 1);
                    mzMin_Box.SelectionStart = mzMin_Box.Text.Length;
                    mzMin_Box.SelectionLength = 0;
                }
            }
        }

        private void mzMax_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mzMax_Box.Text))
            {
                try
                {
                    double.Parse(mzMax_Box.Text, NumberStyles.AllowDecimalPoint);
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    mzMax_Box.Text = mzMax_Box.Text.Remove(mzMax_Box.Text.Length - 1);
                    mzMax_Box.SelectionStart = mzMax_Box.Text.Length;
                    mzMax_Box.SelectionLength = 0;
                }
            }
        }

        private void chargeMin_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chargeMin_Box.Text))
            {
                if (chargeMin_Box.Text != "-")
                {
                    try
                    {
                        double.Parse(chargeMin_Box.Text, NumberStyles.Integer);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numbers.");
                        chargeMin_Box.Text = chargeMin_Box.Text.Remove(chargeMin_Box.Text.Length - 1);
                        chargeMin_Box.SelectionStart = chargeMin_Box.Text.Length;
                        chargeMin_Box.SelectionLength = 0;
                    }
                }
            }
        }

        private void chargeMax_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chargeMax_Box.Text))
            {
                if (chargeMax_Box.Text != "-")
                {

                    try
                    {
                        double.Parse(chargeMax_Box.Text, NumberStyles.Integer);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numbers.");
                        chargeMax_Box.Text = chargeMax_Box.Text.Remove(chargeMax_Box.Text.Length - 1);
                        chargeMax_Box.SelectionStart = chargeMax_Box.Text.Length;
                        chargeMax_Box.SelectionLength = 0;
                    }
                }
            }
        }

        private void chargeAll_Btn_Click(object sender, EventArgs e)
        {
            chargeMin_Box.Text = null;
            chargeMax_Box.Text = null;
        }

        private void resolution_Box_TextChanged(object sender, EventArgs e)
        {
            Form24.machine_listBox.ClearSelected();
            if (Regex.IsMatch(resolution_Box.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                resolution_Box.Text = resolution_Box.Text.Remove(resolution_Box.Text.Length - 1);
                resolution_Box.SelectionStart = resolution_Box.Text.Length;
                resolution_Box.SelectionLength = 0;
            }
            frm2.res_string_24 = resolution_Box.Text;
        }

        private void machine_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resolution_Box.Text = null;
            frm2.machine_sel_index = Form24_2.machine_listBox.SelectedIndex;
        }
        private void UncheckAll_calculationPanel()
        {
            foreach (int i in a_lstBox.CheckedIndices)
            {
                a_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in b_lstBox.CheckedIndices)
            {
                b_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in c_lstBox.CheckedIndices)
            {
                c_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in x_lstBox.CheckedIndices)
            {
                x_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in y_lstBox.CheckedIndices)
            {
                y_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in z_lstBox.CheckedIndices)
            {
                z_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in M_lstBox.CheckedIndices)
            {
                M_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in d_lstBox.CheckedIndices)
            {
                d_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in w_lstBox.CheckedIndices)
            {
                w_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in internal_lstBox.CheckedIndices)
            {
                internal_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            a_lstBox.ClearSelected();
            b_lstBox.ClearSelected();
            c_lstBox.ClearSelected();
            x_lstBox.ClearSelected();
            y_lstBox.ClearSelected();
            z_lstBox.ClearSelected();
            M_lstBox.ClearSelected();
            d_lstBox.ClearSelected();
            internal_lstBox.ClearSelected();
            w_lstBox.ClearSelected();
            mzMax_Box.Text = null;
            mzMin_Box.Text = null;
            chargeMin_Box.Text = null;
            chargeMax_Box.Text = null;
            idxFrom_Box.Text = null;
            idxTo_Box.Text = null;
            idxPr_Box.Text = null;
            sortIdx_chkBx.Checked = false;
        }

        private List<ChemiForm> select_fragments2()
        {
            List<ChemiForm> res = new List<ChemiForm>();
            List<string> primary = new List<string> { "a", "b", "c", "d", "x", "y", "z", "w" };

            // 1. get mz and charge limits (if any)
            double mzMin = txt_to_d(mzMin_Box);
            if (double.IsNaN(mzMin)) mzMin = dParser(ChemFormulas.First().Mz);

            double mzMax = txt_to_d(mzMax_Box);
            if (double.IsNaN(mzMax)) mzMax = dParser(ChemFormulas.Last().Mz);

            double qMin = txt_to_d(chargeMin_Box);
            if (double.IsNaN(qMin)) qMin = 0.0;

            double qMax = txt_to_d(chargeMax_Box);
            if (double.IsNaN(qMax)) qMax = 100.0;

            if (frm2.is_exp_deconvoluted) { qMax = 1; }
            // 2. get checked types
            List<string> types = new List<string>();
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
                foreach (var item in lstBox.CheckedItems)
                    types.Add(item.ToString());

            // 3. seperate checked types by type
            List<string> types_precursor = types.Where(t => t.StartsWith("M")).ToList();                                                        // M, M-H2O...
            List<string> types_internal = types.Where(t => t.StartsWith("internal")).ToList();                                                  // internal a, internal b-2H2O...
            List<string> types_B_loss = types.Where(t => primary.Contains(t[0].ToString()) && t.Contains("B")).ToList();                  // primary with neutral loss a-H2O, b-NH3, ...
            List<string> types_primary = types.Where(t => primary.Contains(t[0].ToString()) && t.Length == 1).ToList();                         // a, b, y.....
            List<string> types_primary_Hyd = types.Where(t => primary.Contains(t[0].ToString()) && !t.Contains("B(") && t.Length == 3).ToList();  // a+1, y-2....

            //4.index primary
            List<int[]> primary_indexes = new List<int[]>();
            if (!string.IsNullOrEmpty(idxPr_Box.Text.ToString()))
            {
                string text = idxPr_Box.Text.Replace(" ", "");
                string[] str = text.Split(',');
                for (int a = 0; a < str.Length; a++)
                {
                    string[] str2 = str[a].Split('-');
                    if (str2.Length == 2) { primary_indexes.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                    if (str2.Length == 1) { primary_indexes.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                }
            }
            //5. index internal
            List<int[]> internal_indexesFrom = new List<int[]>();
            List<int[]> internal_indexesTo = new List<int[]>();
            if (!string.IsNullOrEmpty(idxFrom_Box.Text.ToString()))
            {
                string text = idxFrom_Box.Text.Replace(" ", "");
                string[] str = text.Split(',');
                for (int a = 0; a < str.Length; a++)
                {
                    string[] str2 = str[a].Split('-');
                    if (str2.Length == 2) { internal_indexesFrom.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                    if (str2.Length == 1) { internal_indexesFrom.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                }
            }
            if (!string.IsNullOrEmpty(idxTo_Box.Text.ToString()))
            {
                string text = idxTo_Box.Text.Replace(" ", "");
                string[] str = text.Split(',');
                for (int a = 0; a < str.Length; a++)
                {
                    string[] str2 = str[a].Split('-');
                    if (str2.Length == 2) { internal_indexesTo.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                    if (str2.Length == 1) { internal_indexesTo.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                }
            }
            if (internal_indexesTo.Count != internal_indexesTo.Count)
            {
                MessageBox.Show("Wrong format in internal indexes"); internal_indexesTo.Clear(); internal_indexesTo.Clear();
            }
            // main selection routine
            foreach (ChemiForm chem in ChemFormulas)
            {
                double curr_mz = dParser(chem.Mz);
                double curr_q = chem.Charge;
                string curr_type = chem.Ion_type;
                string curr_type_first = curr_type.Substring(0, 1);

                bool is_precursor = curr_type.StartsWith("M");
                bool is_internal = curr_type.StartsWith("internal");
                bool is_B_loss = primary.Any(curr_type.StartsWith) && curr_type.Contains("B(");
                bool is_primary = primary.Contains(curr_type.ToArray()[0].ToString()) && curr_type.Length == 1;
                bool is_primary_Hyd = primary.Any(curr_type.StartsWith) && !curr_type.Contains("B(") && curr_type.Length > 1;

                // drop frag by mz and charge rules
                if (curr_mz < mzMin || curr_mz > mzMax || curr_q < qMin || curr_q > qMax) continue;

                if (is_internal)
                {
                    bool in_bounds = true;
                    int index1 = Int32.Parse(chem.Index);
                    int index2 = Int32.Parse(chem.IndexTo);
                    if (internal_indexesTo.Count > 0 && internal_indexesTo.Count > 0)
                    {
                        in_bounds = false;
                        for (int k = 0; k < internal_indexesTo.Count; k++)
                        {
                            if (index2 >= internal_indexesTo[k][0] && index2 <= internal_indexesTo[k][1] && index1 >= internal_indexesFrom[k][0] && index1 <= internal_indexesFrom[k][1])
                            {
                                in_bounds = true; break;
                            }
                        }
                        if (!in_bounds) continue;
                    }
                    if (frm2.exclude_internal_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_internal_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index2 >= ext.Index2[k][0] && index2 <= ext.Index2[k][1] && index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (!in_bounds) continue;

                }
                else if (!is_precursor)
                {
                    int index1 = chem.SortIdx;
                    bool in_bounds = true;
                    if (primary_indexes.Count > 0)
                    {
                        in_bounds = false;
                        if (sortIdx_chkBx.Checked) { index1 = chem.SortIdx; }
                        for (int k = 0; k < primary_indexes.Count; k++)
                        {
                            if (index1 >= primary_indexes[k][0] && index1 <= primary_indexes[k][1])
                            {
                                in_bounds = true; break;
                            }
                        }
                        if (!in_bounds) continue;
                    }
                    index1 = Int32.Parse(chem.Index);
                    if (chem.Ion.StartsWith("a") && frm2.exclude_a_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_a_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (chem.Ion.StartsWith("b") && frm2.exclude_b_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_b_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (chem.Ion.StartsWith("c") && frm2.exclude_c_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_c_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (chem.Ion.StartsWith("x") && frm2.exclude_x_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_x_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (chem.Ion.StartsWith("y") && frm2.exclude_y_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_y_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (chem.Ion.StartsWith("z") && frm2.exclude_z_indexes.Count > 0)
                    {
                        foreach (ExcludeTypes ext in frm2.exclude_z_indexes)
                        {
                            if ((ext.Extension != "" && frm2.recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
                            {
                                for (int k = 0; k < ext.Index1.Count; k++)
                                {
                                    if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                                    {
                                        in_bounds = false; break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (!in_bounds) continue;
                }

                //// drop frag if type is not selected, 
                //if (!types.Contains(curr_type) && !types.Any(t => t.StartsWith(curr_type_first))) continue;

                if (is_precursor)
                {
                    if (types_precursor.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_internal)
                {
                    if (types_internal.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_B_loss)
                {
                    if (types_B_loss.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_primary_Hyd) // this should hit, we do not request this type from msProduct
                {
                    if (types_primary_Hyd.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_primary)
                {
                    if (types_primary.Contains(curr_type)) res.Add(chem.DeepCopy());

                    // this code is only for MSProduct that does not provide primary with H gain/loss by default.
                    // Whenever a primary is detected, we have to check if Hydrogen adducts or losses are requested and GENERATE ions (i.e y-2) respective ions
                    if (types_primary_Hyd.Any(t => t.StartsWith(curr_type)))
                    {
                        foreach (string hyd_mod in types_primary_Hyd.Where(t => t.StartsWith(curr_type)))
                        {
                            // add the primary and modify it according to gain or loss of H
                            res.Add(chem.DeepCopy());
                            int curr_idx = res.Count - 1;

                            string new_type = "(" + hyd_mod + ")";
                            res[curr_idx].Ion_type = new_type;
                            res[curr_idx].Radio_label = new_type + res[curr_idx].Radio_label.Remove(0, 1);
                            res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);

                            double hyd_num = 0.0;
                            if (hyd_mod.Contains('+')) hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('+')));
                            else hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('-')));

                            res[curr_idx].Mz = Math.Round(curr_mz + hyd_num * 1.007825 / curr_q, 4).ToString();
                            res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(res[curr_idx].InputFormula, true, (int)hyd_num);
                        }
                    }
                }
            }
            return res;
        }

        private void frag_sort_Btn2_Click(object sender, EventArgs e)
        {
            Form19 frm19 = new Form19(frm2);
            frm19.ShowDialog();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            calcBtn.Enabled = false;
            if (ChemFormulas.Count == 0) { MessageBox.Show("First load MS Product File and then press 'Calculate'", "Error in calculations!"); calcBtn.Enabled = true; return; }
            List<ChemiForm> selected_fragments = select_fragments2();
            if (selected_fragments == null) return;
            calculate_fragments_resolution(selected_fragments);
            frm2.calculate_procedure(selected_fragments);
            calcBtn.Enabled = true;
            this.Close();
        }
        private void calculate_fragments_resolution(List<ChemiForm> selected_fragments)
        {
            frm2.calc_resolution = true;
            frm2.recalc = true;
            frm2.neues = Fragments2.Count();
            if (frm2.is_exp_deconvoluted)
            {
                string machine = frm2.deconv_machine;
                double res = 0.0;
                if (frm2.is_deconv_const_resolution)
                {
                    res = dParser(machine);
                    foreach (ChemiForm chem in selected_fragments)
                    {
                        chem.Resolution = res;
                    }
                }
                else
                {
                    machine = frm2.deconv_machine;
                    foreach (ChemiForm chem in selected_fragments)
                    {
                        chem.Machine = machine;
                    }
                }
            }
            else
            {
                foreach (ChemiForm chem in selected_fragments)
                {
                    if (Form24.machine_listBox.SelectedItems.Count > 0)
                    {
                        chem.Machine = Form24.machine_listBox.SelectedItem.ToString();
                    }
                    else
                    {
                        chem.Resolution = double.Parse(resolution_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                }
            }

        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            UncheckAll_calculationPanel();

        }

        private void mzMin_Box_Click(object sender, EventArgs e)
        {
            mzMin_Box.SelectAll();
        }

        private void mzMax_Box_Click(object sender, EventArgs e)
        {
            mzMax_Box.SelectAll();
        }
    }
}
