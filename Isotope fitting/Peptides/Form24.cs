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
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Form24 : Form
    {
        Form2 frm2;
        //ListBox temp_machine;
        public Form24(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
            if (!string.IsNullOrEmpty(frm2.res_string_24)) resolution_Box.Text = frm2.res_string_24;
            //else if(frm2.machine_sel_index!=-1) machine_listBox.SelectedIndex = frm2.machine_sel_index;
            //else machine_listBox.SelectedIndex = 9;
            //temp_machine = machine_listBox;
            panel_calc.Controls.Add(machine_listBox);
            if (!machine_listBox_eventAddedFlag)
            {
                machine_listBox.SelectedIndexChanged += new System.EventHandler(this.machine_listBox_SelectedIndexChanged);
                machine_listBox_eventAddedFlag = true;
            }

        }

        private void mzMin_Box_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(mzMin_Box, false, false);
        }

        private void mzMax_Box_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(mzMax_Box, false, false);
        }

        private void chargeMin_Box_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(chargeMin_Box, true, true);
        }

        private void chargeMax_Box_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(chargeMax_Box, true, true);
        }

        private void chargeAll_Btn_Click(object sender, EventArgs e)
        {
            chargeMin_Box.Text = string.Empty;
            chargeMax_Box.Text = string.Empty;
        }

        private void resolution_Box_TextChanged(object sender, EventArgs e)
        {
            machine_listBox.ClearSelected();
            check_textBox_entry(resolution_Box, false, false);
            frm2.res_string_24 = resolution_Box.Text;
        }

        private void machine_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resolution_Box.Text != string.Empty) resolution_Box.Text = string.Empty;
            frm2.machine_sel_index = machine_listBox.SelectedIndex;
        }
        private void UncheckAll_calculationPanel()
        {
            set_textboxes_checks_empty(this);
            un_check_all_checkboxes(this);
        }
       
        private List<ChemiForm> select_fragments2()
        {
            List<ChemiForm> res = new List<ChemiForm>();
            List<string> primary = new List<string> { "a", "b", "c", "x", "y", "z" };
            List<string> side_chain = new List<string> { "d", "w", "v" };

            // 1. get mz and charge limits (if any)
            double mzMin = txt_to_d(mzMin_Box);
            if (double.IsNaN(mzMin)) mzMin = dParser(ChemFormulas.First().Mz);

            double mzMax = txt_to_d(mzMax_Box);
            if (double.IsNaN(mzMax)) mzMax = dParser(ChemFormulas.Last().Mz);

            double qMin = txt_to_d(chargeMin_Box);
            if (double.IsNaN(qMin)) qMin = 0.0;

            double qMax = txt_to_d(chargeMax_Box);
            if (double.IsNaN(qMax)) qMax = 100.0;

            if (frm2.is_exp_deconvoluted) { qMin = 0; qMax = 1; }
            // 2. get checked types
            List<string> types = new List<string>();
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
                foreach (var item in lstBox.CheckedItems)
                    types.Add(item.ToString());

            // 3. seperate checked types by type
            List<string> types_precursor = types.Where(t => t.StartsWith("M")).ToList();                                                        // M, M-H2O...
            List<string> types_side_chain = types.Where(t => t.StartsWith("d") | t.StartsWith("v") | t.StartsWith("w")).ToList();               // da, wb, v....
            List<string> types_internal = types.Where(t => t.StartsWith("internal")).ToList();                                                  // internal a, internal b-2H2O...
            List<string> types_neutral_loss = types.Where(t => primary.Contains(t[0].ToString()) && t.Contains("H")).ToList();                  // primary with neutral loss a-H2O, b-NH3, ...
            List<string> types_primary = types.Where(t => primary.Contains(t[0].ToString()) && t.Length == 1).ToList();                         // a, b, y.....
            List<string> types_primary_Hyd = types.Where(t => primary.Contains(t[0].ToString()) && !t.Contains("H") && t.Length > 1).ToList();  // a+1, y-2....

            //4.index primary
            List<int[]> primary_indexes = new List<int[]>();
            if (!string.IsNullOrEmpty(idxPr_Box.Text.ToString())) add_to_indexes_list(idxPr_Box.Text, primary_indexes);

            //5. index internal
            List<int[]> internal_indexesFrom = new List<int[]>();
            List<int[]> internal_indexesTo = new List<int[]>();
            if (!string.IsNullOrEmpty(idxFrom_Box.Text.ToString())) add_to_indexes_list(idxFrom_Box.Text, internal_indexesFrom);
            if (!string.IsNullOrEmpty(idxTo_Box.Text.ToString())) add_to_indexes_list(idxTo_Box.Text, internal_indexesTo);
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
                bool is_side_chain = side_chain.Any(curr_type.StartsWith);
                bool is_internal = curr_type.StartsWith("internal");
                bool is_neutral_loss = primary.Any(curr_type.StartsWith) && curr_type.Contains("H");
                bool is_primary = primary.Contains(curr_type);
                bool is_primary_Hyd = primary.Any(curr_type.StartsWith) && !curr_type.Contains("H") && curr_type.Length > 1;

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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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
                            if ((ext.Extension != "" && recognise_extension(chem.Extension, ext.Extension)) || (ext.Extension == "" && chem.Extension == ""))
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

                if (is_side_chain)
                {
                    if (types_side_chain.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_internal)
                {
                    if (types_internal.Contains(curr_type)) res.Add(chem.DeepCopy());
                    continue;
                }

                if (is_neutral_loss)
                {
                    if (types_neutral_loss.Contains(curr_type)) res.Add(chem.DeepCopy());
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
                            bool is_error = false;
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
                            res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error,res[curr_idx].InputFormula, true, (int)hyd_num);
                            if (is_error) { MessageBox.Show("Error with fragment " + res[curr_idx].Ion + ",with m/z " + res[curr_idx].Mz + " . Don't worry the remaining calculations will continue normally."); res.RemoveAt(curr_idx); }
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
            //this.Close();
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
                    if (machine_listBox.SelectedItems.Count > 0)
                    {
                        chem.Machine = machine_listBox.SelectedItem.ToString();
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

        private void clear_allBtn_Click(object sender, EventArgs e)
        {
            UncheckAll_calculationPanel();
            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
        }

        private void check_all_boxBtn_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes(this,true);
        }

        private void uncheck_all_boxBtn_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes(this, false);
        }

        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
