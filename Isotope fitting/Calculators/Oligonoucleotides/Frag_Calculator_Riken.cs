﻿using System;
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
    public partial class Frag_Calculator_Riken : Form
    {
        Form2 frm2;
         bool has_adduct = false;
         string extra_adduct = "";

        public Frag_Calculator_Riken(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            if (ChemFormulas.Count > 0)
            {
                mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
                mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
            }
            if (!string.IsNullOrEmpty(frm2.res_string_24)) resolution_Box.Text = frm2.res_string_24;
           
            panel_calc.Controls.Add(machine_listBox1);
            if (!machine_listBox1_eventAddedFlag)
            {
                machine_listBox1.SelectedIndexChanged += new System.EventHandler(this.machine_listBox_SelectedIndexChanged);
                machine_listBox1_eventAddedFlag = true;
            }
            noAddBtn.Checked = !has_adduct;
            AdductBtn.Checked = has_adduct;

        }

        #region UI    
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
            machine_listBox1.ClearSelected();
            check_textBox_entry(resolution_Box, false, false);
            frm2.res_string_24 = resolution_Box.Text;
        }
        private void machine_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resolution_Box.Text != string.Empty) resolution_Box.Text = string.Empty;
            frm2.machine_sel_index = machine_listBox1.SelectedIndex;
        }
        private void UncheckAll_calculationPanel()
        {
            set_textboxes_checks_empty(this);
            un_check_all_checkboxes_ListBx(this);
        }
        private void mzMin_Box_Click(object sender, EventArgs e)
        {
            mzMin_Box.SelectAll();
            if (frm2.is_help) { MessageBox.Show("Set the m/z range condition to be met when selecting the fragments for calculation. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void mzMax_Box_Click(object sender, EventArgs e)
        {
            mzMax_Box.SelectAll();
            if (frm2.is_help) { MessageBox.Show("Set the m/z range condition to be met when selecting the fragments for calculation. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
        private void clear_allBtn_riken_Click(object sender, EventArgs e)
        {
            UncheckAll_calculationPanel();
            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
        }

        private void uncheck_all_boxBtn_riken_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(this, false);
        }

        private void check_all_boxBtn_riken_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(this, true);
        }
        private void mz_Label_Click(object sender, EventArgs e)
        {
            if (frm2.is_help) { MessageBox.Show("Set the m/z range condition to be met when selecting the fragments for calculation. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void charge_Label_Click(object sender, EventArgs e)
        {
            if (frm2.is_help) { MessageBox.Show("Set the charge range condition to be met when selecting the fragments for calculation.  Use minus sign for a negative charge. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (frm2.is_help)
            {
                MessageBox.Show("Set the index range condition to be met when selecting the fragments for calculation. When the checkbox is checked: the index of w, x, y, z is counted as for the a, b, c, d fragments.   ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void sortIdx_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (frm2.is_help) { MessageBox.Show("When checked: the index of w, x, y, z is counted as for the a, b, c, d fragments.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void resolution_Label_Click(object sender, EventArgs e)
        {
            if (frm2.is_help)
            {
                MessageBox.Show("Set the initial resolution for the profile calculation of the fragments. In case there is an experimental spectrum, the resolution of the nearest experimental point to the " +
                    "fragment’s most abundant centroid is computed. This resolution is used for an additional profile calculation of the fragments that have passed all filters.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void machine_Label_Click(object sender, EventArgs e)
        {
            if (frm2.is_help)
            {
                MessageBox.Show("A wide range of instrument's resolution related to m/z measurements is integrated into the software. Choose the resolution of your instrument to perform the profile calculation of the fragments. In case there is an experimental spectrum, the resolution of the nearest experimental point to the " +
                    "fragment’s most abundant centroid is computed. This resolution is used for an additional profile calculation of the fragments that have passed all filters.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void AdductBtn_CheckedChanged(object sender, EventArgs e)
        {
            adduct_txtBx.Enabled = AdductBtn.Checked;
            aks_modifChk.Visible = AdductBtn.Checked;
            aks_modifChk.Checked = AdductBtn.Checked;
        }
        #endregion


        private List<ChemiForm> select_fragments_riken()
        {
            string pattern = @"^[+-][1-9][0-9]?(?![(])";
            string pattern_H2 = @"^[+-][H][1-9][0-9]?(?![a-zA-Z])";
            List<ChemiForm> res = new List<ChemiForm>();          
            double extra_mz = 0;
            bool extra_mz_error = false;
            string extra_name = "";
            string deduct = "";
            string adduct = ""; 
            if (has_adduct)
            {
                extra_name = extra_adduct.ToString();
                Match matches = Regex.Match(extra_name, pattern);
                if (matches.Success)
                {
                    extra_adduct = extra_adduct.Insert(1, "H");
                }
                Match matches_H2 = Regex.Match(extra_name, pattern_H2);
                if (matches_H2.Success)
                {
                    extra_name = extra_name.Remove(1,1);                   
                }
                extra_adduct = extra_adduct.Replace("B(A)", "C5H5N5").Replace("B(G)", "C5H5N5O1").Replace("B(T)", "C5H6N2O2");
                bool add_ = true;
                for (int i=0; i< extra_adduct.Length; i++)
                {                    
                    if (extra_adduct[i].Equals('-')) { add_ = false; }
                    else if (extra_adduct[i].Equals('+')) { add_ = true; }
                    else if (add_) { adduct += extra_adduct[i]; }
                    else { deduct += extra_adduct[i]; }
                }
                adduct = square_brackets_formula(adduct);
                deduct = square_brackets_formula(deduct);
                double m_ded =calc_m(out extra_mz_error, deduct);
                if (extra_mz_error) { MessageBox.Show("Adduct chemical formula is not in the correct format", "Error"); return res; }
                double m_add = calc_m(out extra_mz_error, adduct);
                if (extra_mz_error) { MessageBox.Show("Adduct chemical formula is not in the correct format", "Error"); return res; }
                extra_mz = m_add- m_ded;   
            }            
            List<string> primary = new List<string> { "a", "b", "c", "d", "x", "y", "z", "w" };
            //other types are M, internal and known MS2
            // 1. get mz and charge limits (if any)
            double mzMin = txt_to_d(mzMin_Box);
            if (double.IsNaN(mzMin)) mzMin = dParser(ChemFormulas.First().Mz);

            double mzMax = txt_to_d(mzMax_Box);
            if (double.IsNaN(mzMax)) mzMax = dParser(ChemFormulas.Last().Mz);

            double qMin = txt_to_d(chargeMin_Box);
            if (double.IsNaN(qMin)) qMin =- 100.0;

            double qMax = txt_to_d(chargeMax_Box);
            if (double.IsNaN(qMax)) qMax = 100.0;

            if (frm2.is_exp_deconvoluted) { qMin = 0; qMax = 1; }

            // 2. get checked types
            List<string> types = new List<string>();
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>())
                foreach (var item in lstBox.CheckedItems)
                    types.Add(item.ToString());

            // 3. seperate checked types by type
            List<string> types_precursor = types.Where(t => t.StartsWith("M")).ToList();// M, M-H2O...
            List<string> types_internal = types.Where(t => t.StartsWith("internal")).ToList();// internal a, internal b-2H2O...
            List<string> types_B_loss = types.Where(t => primary.Contains(t[0].ToString()) && t.Contains("B")).ToList();// primary with neutral loss a-H2O, b-NH3, ...
            List<string> types_primary = types.Where(t => primary.Contains(t[0].ToString()) && t.Length == 1).ToList();// a, b, y.....
            List<string> types_primary_Hyd = types.Where(t => primary.Contains(t[0].ToString()) && t.Length == 3).ToList();  // a+1, y-2....
            List<string> types_primary_H2O = types.Where(t => primary.Contains(t[0].ToString()) && t.Length == 5 && t.Contains("H2O")).ToList();  // a+H2O, y-H2O....
            List<string> types_known_MS2 = types.Where(t => t.StartsWith("known")).ToList();  // known MS2 fragments....
            List<string> types_B = types.Where(t => t.StartsWith("B(")).ToList();  // B() fragments....

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
                int curr_q = chem.Charge;
                string curr_type = chem.Ion_type;
                string curr_type_first = curr_type.Substring(0, 1);
                bool is_precursor = curr_type.StartsWith("M");
                bool is_internal = curr_type.StartsWith("internal");
                bool is_B_loss = primary.Any(curr_type.StartsWith) && curr_type.Contains("B(");
                bool is_primary = primary.Contains(curr_type.ToArray()[0].ToString()) && curr_type.Length == 1;
                bool is_primary_Hyd = primary.Any(curr_type.StartsWith) && !curr_type.Contains("B(") && curr_type.Length > 1;
                bool is_known_MS2 = curr_type.StartsWith("known"); 
                bool is_B= curr_type.StartsWith("B(");
                double range = 0;
                if (is_primary && types_primary_Hyd.Count > 0) range = 2*1.007825 / Math.Abs(curr_q);
                if (is_primary && types_primary_H2O.Count>0) range = 19 / Math.Abs(curr_q);
                double extra_mz_temp = extra_mz / Math.Abs(curr_q);
                double extra_B_temp = 0; // 151.0494098 is the mass of B(G), which is the biggest of the B()
                if (is_primary && types_B_loss.Count > 0) { extra_B_temp = 151.0494098 / Math.Abs(curr_q); }// 151.0494098 is the mass of B(G), which is the biggest of the B() 
                // drop frag by mz and charge rules
                if (curr_mz + extra_mz_temp < mzMin - range- 0.05 || curr_mz + extra_mz_temp > mzMax + range+ extra_B_temp + 0.05 || curr_q < qMin || curr_q > qMax) continue;
                if (!extra_name.Contains("B(")|| check_ion_for_base(chem, extra_name, frm2.sequenceList))
                {
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
                    else if (!is_precursor && !is_known_MS2 && !is_B)
                    {
                        int index1 = chem.SortIdx;
                        bool in_bounds = true;
                        if (primary_indexes.Count > 0)
                        {
                            in_bounds = false;
                            if (sortIdx_chkBx.Checked) { index1 = Int32.Parse(chem.Index); }
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
                        else if (chem.Ion.StartsWith("d") && frm2.exclude_d_indexes.Count > 0)
                        {
                            foreach (ExcludeTypes ext in frm2.exclude_d_indexes)
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
                        else if (chem.Ion.StartsWith("w") && frm2.exclude_w_indexes.Count > 0)
                        {
                            foreach (ExcludeTypes ext in frm2.exclude_w_indexes)
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
                    if (is_precursor)
                    {
                        if (types_precursor.Contains(curr_type))
                        {                            
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c=check_adduct(out is_error,chem, adduct,deduct,  extra_name, aks_modifChk.Checked, true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        continue;
                    }
                    if (is_internal)
                    {
                        if (types_internal.Contains(curr_type))
                        {                            
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked, true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        continue;
                    }
                    if (is_B && !extra_name.Contains("B("))
                    {
                        if (types_B.Contains(curr_type))
                        {                            
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked,  true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        continue;
                    }
                    if (is_B_loss)
                    {
                        if (types_B_loss.Contains(curr_type))
                        {                            
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked, true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        continue;
                    }
                    if (is_known_MS2 && !extra_name.Contains("B("))
                    {
                        if (types_known_MS2.Contains(curr_type))
                        {                            
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked, true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        continue;
                    }
                    if (is_primary)
                    {
                        if (types_primary.Contains(curr_type) && curr_mz + extra_mz_temp >= mzMin- 0.05 && curr_mz + extra_mz_temp <= mzMax+ 0.05)
                        {
                            if (has_adduct)
                            {
                                bool is_error;
                                ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked, true, is_riken: true);
                                if (!is_error) res.Add(c);
                                else continue;
                            }
                            else { res.Add(chem.DeepCopy()); }
                        }
                        // this code is only for MSProduct that does not provide primary with H gain/loss by default.
                        // Whenever a primary is detected, we have to check if Hydrogen adducts or losses are requested and GENERATE ions (i.e y-2) respective ions
                        if (types_primary_Hyd.Any(t => t.StartsWith(curr_type)))
                        {
                            foreach (string hyd_mod in types_primary_Hyd.Where(t => t.StartsWith(curr_type)))
                            {
                                bool is_error = false;
                                double hyd_num = 0.0;
                                if (hyd_mod.Contains('+')) hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('+')));
                                else hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('-')));
                                double mz = Math.Round(curr_mz + hyd_num * 1.007825 / Math.Abs(curr_q), 4);
                                if (mz + extra_mz_temp >= mzMin- 0.05 && mz + extra_mz_temp <= mzMax+ 0.05)
                                {
                                    // add the primary and modify it according to gain or loss of H
                                    if (has_adduct)
                                    {
                                        ChemiForm c = check_adduct(out is_error,chem, adduct, deduct,  extra_name, aks_modifChk.Checked, is_riken: true);
                                        if (!is_error) res.Add(c);
                                        else continue;
                                    }
                                    else { res.Add(chem.DeepCopy()); }                                  
                                    int curr_idx = res.Count - 1;
                                    string new_type = "(" + hyd_mod;
                                    if (has_adduct)
                                    {
                                        new_type += extra_name;
                                    }
                                    new_type += ")";
                                    res[curr_idx].Ion_type = new_type;
                                    res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);
                                    res[curr_idx].Has_adduct = has_adduct;
                                    if (has_adduct) res[curr_idx].Has_adduct = aks_modifChk.Checked;
                                    res[curr_idx].Mz = mz.ToString();
                                    res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error, res[curr_idx].InputFormula, true, (int)hyd_num);
                                    if (extra_name.Contains("B(A)")) { res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(A)", "B()"); }
                                    if (extra_name.Contains("B(G)")) { res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(G)", "B()"); }
                                    if (extra_name.Contains("B(T)")) { res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(T)", "B()"); }
                                    if (is_error) { MessageBox.Show("Error with fragment " + res[curr_idx].Ion + ",with m/z " + res[curr_idx].Mz + " . Don't worry the remaining calculations will continue normally."); res.RemoveAt(curr_idx); }

                                }
                            }
                        }
                        if (types_primary_H2O.Any(t => t.StartsWith(curr_type)))
                        {
                            foreach (string h2o_mod in types_primary_H2O.Where(t => t.StartsWith(curr_type)))
                            {
                                bool is_error = false;
                                double mz;
                                if (h2o_mod.Contains('+')) mz = Math.Round(curr_mz + 18.01056468 / Math.Abs(curr_q), 4);
                                else mz = Math.Round(curr_mz - 18.01056468 / Math.Abs(curr_q), 4);
                                if (mz + extra_mz_temp >= mzMin- 0.05 && mz + extra_mz_temp <= mzMax+ 0.05)
                                {
                                    // add the primary and modify it according to gain or loss of H2O
                                    if (has_adduct)
                                    {
                                        ChemiForm c = check_adduct(out is_error, chem, adduct, deduct, extra_name, aks_modifChk.Checked, is_riken: true);
                                        if (!is_error) res.Add(c);
                                        else continue;
                                    }
                                    else { res.Add(chem.DeepCopy()); }
                                    int curr_idx = res.Count - 1;
                                    string new_type = "(" + h2o_mod;
                                    if (has_adduct)
                                    {
                                        new_type += extra_name;
                                    }
                                    new_type += ")";
                                    res[curr_idx].Ion_type = new_type;
                                    res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);
                                    res[curr_idx].Has_adduct = has_adduct;
                                    if (has_adduct) res[curr_idx].Has_adduct = aks_modifChk.Checked;
                                    if (extra_name.Contains("B(A)")) { res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(A)", "B()"); }
                                    if (extra_name.Contains("B(G)")) { res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(G)", "B()"); }
                                    if (extra_name.Contains("B(T)")) {res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(T)", "B()"); }
                                    if (h2o_mod.Contains('+'))
                                    {
                                        res[curr_idx].Mz = mz.ToString();
                                        res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error, res[curr_idx].InputFormula, false, 0, 1);
                                    }
                                    else
                                    {
                                        res[curr_idx].Mz = mz.ToString();
                                        res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error, res[curr_idx].InputFormula, false, 0, -1);
                                    }
                                    if (is_error) { MessageBox.Show("Error with fragment " + res[curr_idx].Ion + ",with m/z " + res[curr_idx].Mz + " . Don't worry the remaining calculations will continue normally."); res.RemoveAt(curr_idx); }
                                }
                            }
                        }
                        if (types_B_loss.Count > 0 && types_B_loss.Any(t => t.StartsWith(curr_type)))
                        {
                            foreach (string b_loss in types_B_loss.Where(t => t.StartsWith(curr_type)))
                            {
                                bool is_error = false;
                                double mz;
                                string[] name =new string[] { "-B(A)","-B(G)","-B(T)"};
                                string[] formula = new string[] { "C5H5N5", "C5H5N5O1", "C5H6N2O2" };
                                double[] mass = new double[] { 135.0544952, 151.0494098, 126.0429275 };
                                for (int f=0;f<3 ;f++)
                                {
                                    if (check_ion_for_base(chem, name[f], frm2.sequenceList))
                                    {
                                        mz = Math.Round(curr_mz - mass[f] / Math.Abs(curr_q), 4);
                                        if (mz + extra_mz_temp >= mzMin- 0.05 && mz + extra_mz_temp <= mzMax+ 0.05)
                                        {
                                            ChemiForm c = check_adduct(out is_error, chem, "", formula[f], name[f], false, true, is_riken: true);
                                            if (is_error) continue;
                                            c.Has_adduct = false;
                                            if (has_adduct)
                                            {
                                                ChemiForm c1 = check_adduct(out is_error, c, adduct, deduct, extra_name, aks_modifChk.Checked, true, is_riken: true);
                                                if (!is_error && check_duplicates_SelectedFragments(c1,res)) res.Add(c1);
                                                else continue;
                                            }
                                            else if (check_duplicates_SelectedFragments(c, res)) { res.Add(c); }
                                        }
                                    }                                   
                                } 
                            }
                        }
                    }
                }
                else continue;
            }
            return res;
        }
        
        private void frag_sort_Btn2_Click(object sender, EventArgs e)
        {
            if (frm2.is_help)
            {
                MessageBox.Show("Displays 'Filter' panel.\r\n" +
                "Ere initiating the calculation process the user can select from the 'Filter' panel, the desired maximum ppm error and customize" +
                "its application method.For instance, if the user selects the “2 most intense” option, the fragments " +
                "whose 2 most intense centroids are within the ppm bounds pass the Peak Detection" +
                "filter.On the hand, if the user selects the “half most intense” option, fragments whose half" +
                "of most intense centroids are within the ppm bounds are promoted to the “Selected" +
                "Fragments” list. Moreover, Fragment selection filter can also be applied on the Fragment" +
                "List after the calculation method, on any step of the mass spectrum interpretation process," +
                "irrespective of the data origin, for example fitted results file or manual processed file.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Show the Fragment Selection Filters Form
            Filters_Form frm19 = new Filters_Form(frm2, frm2.is_help);
            frm19.ShowDialog();
        }
        private void calcBtn_Click(object sender, EventArgs e)
        {
            if (frm2.is_help) { MessageBox.Show("Initiates the calculation procedure:\r\nfor each of the loaded fragments, the algorithm checks whether they possess " +
                "the desired properties and selects the candidates. Following the selected fragments' “enviPat” properties profile calculation, a filter is applied " +
                "to refine the list from fragments whose most abundant centroid differs from the nearest experimental peak by ppm larger than the user-specified bound" +
                " maximum ppm. This filter distinguishes the candidate fragments from the incorrect.\r\n", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            calcBtn.Enabled = false;
            if (ChemFormulas.Count == 0) { MessageBox.Show("First load MS Product File and then press 'Calculate'", "Error in calculations!"); calcBtn.Enabled = true; return; }
            has_adduct = AdductBtn.Checked;
            if (has_adduct)
            {
                extra_adduct = adduct_txtBx.Text.Replace(Environment.NewLine, " ").ToString();
                extra_adduct = extra_adduct.Replace("\t", "");
                extra_adduct =extra_adduct.Replace(" ", "");
                if (String.IsNullOrEmpty(extra_adduct)){ has_adduct = false; AdductBtn.Checked = false; noAddBtn.Checked = true; }
                if (extra_adduct[0] != '+' && extra_adduct[0] != '-') { extra_adduct = "+" + extra_adduct; }
            }
            List<ChemiForm> selected_fragments = select_fragments_riken();
            if (selected_fragments == null) return;
            calculate_fragments_resolution(selected_fragments);
            frm2.calculate_procedure(selected_fragments);
            calcBtn.Enabled = true;
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
                    if (machine_listBox1.SelectedItems.Count > 0)
                    {
                        chem.Machine = machine_listBox1.SelectedItem.ToString();
                    }
                    else
                    {
                        bool success = double.TryParse(resolution_Box.Text,NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out double result);
                        if (success) { chem.Resolution = result; }
                        else { machine_listBox1.SelectedIndex = machine_listBox1.Items.Count - 1;  chem.Machine= machine_listBox1.SelectedItem.ToString(); }
                          
                    }
                }
            }

        }         
        private void Frag_Calculator_Riken_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void aks_modifChk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = sender as CheckBox;
            if (temp.Checked) temp.ForeColor = Color.DarkViolet;
            else temp.ForeColor = Color.Black;
        }
    }
}