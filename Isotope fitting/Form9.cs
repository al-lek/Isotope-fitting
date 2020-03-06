using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;
using System.Globalization;

namespace Isotope_fitting
{
    public partial class Form9 : Form
    {
        Form2 frm2;
        private double ppmError9=8.0;        
        private bool[] selection_rule9 = new bool[] { true, false, false, false, false, false };
        private ListViewItemComparer _lvwItemComparer;
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        public static List<FragForm> Fragments3 = new List<FragForm>();
        public static int selected_idx = 0;
        public static bool now=false;
        Object _locker = new Object();
        delegate void CalcFrag3Completed();
        event CalcFrag3Completed OnCalcFrag3Completed;
        bool first = true;
        

        public Form9(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            OnCalcFrag3Completed += () => { Fragments3_to_listview(); };
            ppm9_numUD.TextChanged += new EventHandler(ppm9_numUD_TextChanged);
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();

            //ppm9_numUD.ValueChanged += (s, e) => 
            //{
            //    ppmError9 = (double)ppm9_numUD.Value;
            //};
            ppm9_numUD.Value =(decimal)ppmError9;

            one_rdBtn9.CheckedChanged += (s, e) => { selection_rule9[0]=one_rdBtn9.Checked; };
            two_rdBtn.CheckedChanged += (s, e) => { selection_rule9[1] =two_rdBtn.Checked; };
            three_rdBtn.CheckedChanged += (s, e) => { selection_rule9[2] =three_rdBtn.Checked; };
            half_rdBtn.CheckedChanged += (s, e) => { selection_rule9[3] = half_rdBtn.Checked; };
            half_minus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[4] =half_minus_rdBtn.Checked; };
            half_plus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[5] =half_plus_rdBtn.Checked; };
            one_rdBtn9.Checked = selection_rule9[0]; 
            two_rdBtn.Checked = selection_rule9[1];
            three_rdBtn.Checked = selection_rule9[2];
            half_rdBtn.Checked = selection_rule9[3];
            half_minus_rdBtn.Checked = selection_rule9[4];
            half_plus_rdBtn.Checked = selection_rule9[5];
            internal_lstBox.MouseClick += (s, e) => { internal_lstBox.Focus(); };
            addin_lstBox.MouseClick += (s, e) => { addin_lstBox.Focus(); };
            a_lstBox.MouseClick += (s, e) => { a_lstBox.Focus(); };
            b_lstBox.MouseClick += (s, e) => { b_lstBox.Focus(); };
            c_lstBox.MouseClick += (s, e) => { c_lstBox.Focus(); };
            dvw_lstBox.MouseClick += (s, e) => { dvw_lstBox.Focus(); };
            internal_lstBox.MouseClick += (s, e) => { internal_lstBox.Focus(); };
            M_lstBox.MouseClick += (s, e) => { M_lstBox.Focus(); };
            x_lstBox.MouseClick += (s, e) => { x_lstBox.Focus(); };
            y_lstBox.MouseClick += (s, e) => { y_lstBox.Focus(); };
            z_lstBox.MouseClick += (s, e) => { z_lstBox.Focus(); };
            ppm9_numUD.MouseClick += (s, e) => { ppm9_numUD.Focus(); };
            chargeMax_Box.MouseClick += (s, e) => { chargeMax_Box.Focus(); };
            chargeMin_Box.MouseClick += (s, e) => { chargeMin_Box.Focus(); };
            idxFrom_Box.MouseClick += (s, e) => { idxFrom_Box.Focus(); };
            idxPr_Box.MouseClick += (s, e) => { idxPr_Box.Focus(); };
            idxTo_Box.MouseClick += (s, e) => { idxTo_Box.Focus(); };
            mzMax_Box.MouseClick += (s, e) => { mzMax_Box.Focus(); };
            mzMin_Box.MouseClick += (s, e) => { mzMin_Box.Focus(); };
        }

        private void initialize_data()
        {
            if (Fragments3.Count > 0) Fragments3.Clear();
            first = true; now = false; selected_idx = 0; 
        }

        #region listview UI
        private void Initialize_listviewComparer()
        {
            fragListView9.ListViewItemSorter = _lvwItemComparer;
        }
        private void fragListView9_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            //ensure that the focus is mainly on numeric up down box in the factor_panel9 
            if (factor_panel9.Visible)
            {
                factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus();
            }
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

        private void Fragments3_to_listview()
        {
            fragListView9.BeginUpdate();
            fragListView9.Items.Clear();
            foreach (FragForm fra in Fragments3)
            {
                var listviewitem = new ListViewItem(fra.Name);
                if (fra.Ion_type.StartsWith("inter")) { listviewitem.SubItems.Add(fra.Index + "-" + fra.IndexTo); }
                else { listviewitem.SubItems.Add(fra.Index); }
                listviewitem.SubItems.Add(fra.Mz);
                listviewitem.SubItems.Add(fra.Charge.ToString());
                listviewitem.SubItems.Add(fra.InputFormula.ToString());
                listviewitem.SubItems.Add(fra.Counter.ToString());
                listviewitem.SubItems.Add(fra.PPM_Error.ToString("0.##"));

                fragListView9.Items.Add(listviewitem);
            }
            fragListView9.EndUpdate();
        }
        private void fragListView9_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue != CheckState.Checked)
            {
                foreach (ListViewItem lili in fragListView9.Items)
                {
                    lili.Checked = false;
                }
            }
        }
        private void fragListView9_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            now = true;
            //if (factor_panel9.Controls.Count > 0) { factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus(); }
            if (e.IsSelected)
            {
                selected_idx = System.Convert.ToInt32(e.Item.SubItems[5].Text);
                if (first)
                {
                    // pass the envelope (profile) of each NEW fragment in Fragment2 to all data
                    if (all_data.Count == 0) { all_data.Add(new List<double[]>()); Form2.custom_colors.Clear(); custom_colors.Add(OxyColors.Black.ToColor().ToArgb()); }
                    custom_colors.Add(Fragments3[selected_idx].Color.ToColor().ToArgb());
                }
                else
                {
                    all_data.RemoveAt(all_data.Count - 1); custom_colors.RemoveAt(custom_colors.Count - 1);
                }
                all_data.Add(new List<double[]>());
                for (int p = 0; p < Fragments3[selected_idx].Profile.Count; p++)
                {
                    all_data.Last().Add(new double[] { Fragments3[selected_idx].Profile[p].X, Fragments3[selected_idx].Profile[p].Y });
                }
                custom_colors.Add(Fragments3[selected_idx].Color.ToColor().ToArgb());
                first = false; now = true;
                try
                {
                    frm2.recalc_frm9(Fragments3[selected_idx].Profile[0].X, Fragments3[selected_idx].Profile.Last().X); adjust_height();
                }
                catch
                {
                    MessageBox.Show("This fragment doesn't belong to the experimental data!");
                    first = true; now = false; selected_idx = 0;
                    frm2.ending_frm9();
                }
            }           
        }
        private void adjust_height()
        {
            double frag_intensity = Fragments3[selected_idx].Factor * Fragments3[selected_idx].Max_intensity;
            factor_panel9.Visible = true;
            factor_panel9.Controls.Clear();
            Label factor_lbl = new Label { Text = Fragments3[selected_idx].Name, Location = new Point(5, 10), AutoSize = true };
            NumericUpDown numUD = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1e8M,
                Value = (decimal)Math.Round(frag_intensity, 1),
                Increment = (decimal)Math.Round(frag_intensity) / 50,
                Location = new Point(275, 7),
                Size = new Size(60, 20),TabIndex=0
            };
            numUD.ValueChanged += (s, e) =>
            {
                // manualy adjust height. We have also to maualy call refresh plot
                Fragments3[selected_idx].Factor = Convert.ToDouble(numUD.Value) / Fragments3[selected_idx].Max_intensity;
                frm2.refresh_frm9();
            };
            numUD.Focus();           
            //ensure that the focus is mainly on numeric up down box in the factor_panel9 
            //that way when the user clicks a fragment from the listview the focus is not on the listview but on the numeric up down
            //and can control height of the fragment instantly from the buttons "up" "down"
            numUD.Leave += (s, e) => { if (!panel_calc.Focused) { numUD.Focus(); } };
             factor_panel9.Controls.AddRange(new Control[] { factor_lbl, numUD });
            factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus();
        }
        #endregion

        #region isotopic distributions calculations
        private void calc_Btn_Click(object sender, EventArgs e)
        {
            if (Fragments3.Count > 0) Fragments3.Clear();
            //the basic algorithm with small changes for the specific form9
            fragments_and_calculations_sequence_A_frm9();
        }
        private void fragments_and_calculations_sequence_A_frm9()
        {
            // this the main sequence after loading data
            // 1. select fragments according to UI            
            sw1.Reset(); sw1.Start();
            List<ChemiForm> selected_fragments = new List<ChemiForm>();
            if (string.IsNullOrEmpty(chemForm_txtBox.Text.ToString())) { if (ChemFormulas == null || ChemFormulas.Count == 0) { MessageBox.Show("You must first load an MS Product file for this action."); return; } selected_fragments = select_fragments2_frm9(); }
            else { selected_fragments = check_chem_inputs(); }
             
            if (selected_fragments == null) return;
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            calculate_fragments_resolution_frm9(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments3.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties_frm9(selected_fragments));
            envipat_properties.Start();
        } 
        private List<ChemiForm> check_chem_inputs()
        {
            string s = frm2.Peptide;
            List<ChemiForm> res = new List<ChemiForm>();
            string chem_form = string.Empty;
            List<int> charge = new List<int>();
            string ion = string.Empty;
            string index = string.Empty;
            string indexTo = string.Empty;
            if (heavy_ChkBox.Checked)
            {
                if (string.IsNullOrEmpty(frm2.heavy_chain)) { MessageBox.Show("Heavy Chain sequence is not loaded"); return res; }
                s = frm2.heavy_chain;
            }
            else if (Light_chkBox.Checked)
            {
                if (string.IsNullOrEmpty(frm2.light_chain)) { MessageBox.Show("Light Chain sequence is not loaded"); return res; }
                s = frm2.light_chain;
            }            

            if (ion_txtBox.Text.Contains("M")) { index = "0";indexTo = s.Length.ToString(); }
            else if ((string.IsNullOrEmpty(minCharge_txtBox.Text) && string.IsNullOrEmpty(maxCharge_txtBox.Text)) || string.IsNullOrEmpty(ion_txtBox.Text) || (string.IsNullOrEmpty(primary_txtBox.Text) && string.IsNullOrEmpty(internal_txtBox.Text))) { return res; }
            
            chem_form = chemForm_txtBox.Text.Replace(Environment.NewLine, " ").ToString();
            chem_form = chem_form.Replace("\t", "");
            chem_form = chem_form.Replace(" ", "");
            ion = ion_txtBox.Text.Replace(Environment.NewLine, " ").ToString();
            ion = ion.Replace("\t", "");
            ion = ion.Replace(" ", "");
            if (ion.Contains("internal") && !string.IsNullOrEmpty(primary_txtBox.Text)  )
            {
                MessageBox.Show("You have inserted an internal ion type, with a primary type index. For internal ion types insert the index number in the corresponding field.");
                return res;
            }          
            else if (!ion.Contains("internal") && !string.IsNullOrEmpty(internal_txtBox.Text))
            {
                MessageBox.Show("You have inserted a primary ion type, with an internal type index. For primary ion types insert the index number in the corresponding field.");
                return res;
            }
            else if (!string.IsNullOrEmpty(primary_txtBox.Text))
            {
                index = primary_txtBox.Text.Replace("\t", "");
                index=index.Replace(" ", "");
                indexTo =index;
            }
            else if (!string.IsNullOrEmpty(internal_txtBox.Text))
            {
                try
                {
                    string[] int_index = new string[2];
                    int_index = internal_txtBox.Text.Split('-');
                    index = int_index[0].Replace("\t", "");
                    index = index.Replace(" ", "");
                    indexTo = int_index[1].Replace("\t", "");
                    indexTo = indexTo.Replace(" ", "");
                }
                catch
                {
                    MessageBox.Show("Internal indexes are inserted with '-'. Example: 5-9");return res;
                }               
            }
            double qMin = txt_to_d(minCharge_txtBox);
            if (double.IsNaN(qMin)) qMin =1;
            double qMax = txt_to_d(maxCharge_txtBox);
            if (double.IsNaN(qMax)) qMax = 25;
            
            for(int c=(int)qMin;c<= qMax; c++ )
            {
                res.Add(new ChemiForm
                {
                    InputFormula = chem_form,
                    Adduct = string.Empty,
                    Deduct = string.Empty,
                    Multiplier = 1,
                    Mz = string.Empty,
                    Ion = ion,
                    Index = index,
                    IndexTo = indexTo,
                    Error = false,
                    Elements_set = new List<Element_set>(),
                    Iso_total_amount = 0,
                    Monoisotopic = new CompoundMulti(),
                    Points = new List<PointPlot>(),
                    Machine = string.Empty,
                    Resolution = new double(),
                    Combinations = new List<Combination_1>(),
                    Profile = new List<PointPlot>(),
                    Centroid = new List<PointPlot>(),
                    Intensoid = new List<PointPlot>(),
                    Combinations4 = new List<Combination_4>(),
                    FinalFormula = string.Empty,
                    Factor = 1.0,
                    Fixed = false,
                    PrintFormula = chem_form,
                    Max_man_int = 0,
                    Charge=c,
                    Ion_type=ion
                });
                res.Last().Adduct = "H" + c.ToString();
                if (res.Last().Ion.StartsWith("d") || res.Last().Ion.StartsWith("w") || res.Last().Ion.StartsWith("v")) res.Last().Color = OxyColors.Turquoise;
                else if (res.Last().Ion.StartsWith("a")) res.Last().Color = OxyColors.Green;
                else if (res.Last().Ion.StartsWith("b")) res.Last().Color = OxyColors.Blue;
                else if (res.Last().Ion.StartsWith("x")) res.Last().Color = OxyColors.LimeGreen;
                else if (res.Last().Ion.StartsWith("y")) res.Last().Color = OxyColors.DodgerBlue;
                else if (res.Last().Ion.StartsWith("z")) res.Last().Color = OxyColors.Tomato;
                else if (res.Last().Ion.StartsWith("c")) res.Last().Color = OxyColors.Firebrick;
                else if (res.Last().Ion.Contains("internal") && res.Last().Ion.Contains("b")) res.Last().Color = OxyColors.MediumOrchid;
                else if (res.Last().Ion.Contains("internal") ) res.Last().Color = OxyColors.DarkViolet;
                else if (res.Last().Ion.StartsWith("M")) res.Last().Color = OxyColors.DarkRed;
                else res.Last().Color = OxyColors.PaleGoldenrod;

                string lbl = "";
                if (res.Last().Ion.Contains("internal"))
                {                   
                    lbl = res.Last().Ion + "[" + res.Last().Index + "-" + res.Last().IndexTo + "]";
                    res.Last().Radio_label = lbl;
                    if (res.Last().Charge > 0) res.Last().Name = lbl + "_" + res.Last().Charge.ToString() + "+";
                    else res.Last().Name = lbl + "_" + Math.Abs(res.Last().Charge).ToString() + "-";
                }
                else if (res.Last().Ion_type.StartsWith("M"))
                {
                    lbl =ion;
                    res.Last().Radio_label = lbl;
                    if (res.Last().Charge > 0) res.Last().Name = lbl + "_" + res.Last().Charge.ToString() + "+";
                    else res.Last().Name = lbl + "_" + Math.Abs(res.Last().Charge).ToString() + "-";
                }
                else
                {
                    if (res.Last().Ion_type.Length == 1) { lbl = res.Last().Ion_type + res.Last().Index; }
                    else { lbl = "(" + res.Last().Ion_type + ")" + res.Last().Index; }
                    res.Last().Radio_label = lbl;
                    if (res.Last().Charge > 0) res.Last().Name = lbl + "_" + res.Last().Charge.ToString() + "+";
                    else res.Last().Name = lbl + "_" + Math.Abs(res.Last().Charge).ToString() + "-";                    
                }
                if (heavy_ChkBox.Checked) { res.Last().Radio_label += "_H"; res.Last().Name += "_H"; }
                else if (Light_chkBox.Checked) { res.Last().Radio_label += "_L"; res.Last().Name += "_L"; }
            }
            return res;
        }
        
        private List<ChemiForm> select_fragments2_frm9()
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
            if (double.IsNaN(qMax)) qMax = 25.0;

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

        private void calculate_fragments_resolution_frm9(List<ChemiForm> selected_fragments)
        {
            foreach (ChemiForm chem in selected_fragments)
            {
                chem.Machine = "Elite_R60000@400";
            }
        }

        private void calculate_fragment_properties_frm9(List<ChemiForm> selected_fragments)
        {
            // main routine for parallel calculation of fragments properties and filtering by ppm and peak rules
            sw1.Reset(); sw1.Start(); int progress = 0;
            progress9_display_start(selected_fragments.Count, "Calculating fragment isotopic distributions...");
            try
            {
                Parallel.For(0, selected_fragments.Count, (i, state) =>
                {
                    Envipat_Calcs_and_filter_byPPM_frm9(selected_fragments[i]);


                    Interlocked.Increment(ref progress);
                    if (progress % 10 == 0 && progress > 0)
                    {
                        progress_display_update(progress);
                    };
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            };

            // sort by mz the fragments list (global) beause it is mixed by multi-threading
            Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k; }
            progress_display_stop();
            sw1.Stop(); Debug.WriteLine("Envipat_Calcs_and_filter_byPPM(M): " + sw1.ElapsedMilliseconds.ToString());
            Debug.WriteLine("PPM(): " + sw2.ElapsedMilliseconds.ToString()); sw2.Reset();
            if (!string.IsNullOrEmpty(chemForm_txtBox.Text)) { MessageBox.Show("Chemical formulas profile calculation is completed!"); }
            else { MessageBox.Show("From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments3.Count.ToString() + " were within ppm filter.", "Fragment selection results"); }                
            Invoke(new Action(() => OnCalcFrag3Completed()));
        }
        private void Envipat_Calcs_and_filter_byPPM_frm9(ChemiForm chem)
        {
            ChemiForm.CheckChem(chem);      // will also generate chem.FinalFormula

            if (chem.Resolution == 0)
            {
                if (String.IsNullOrEmpty(chem.Machine.ToString()))
                {
                    chem.Error = true;
                }
                else
                {
                    ChemiForm.Get_R(chem);

                    if (chem.Resolution == 0) chem.Error = true;                    
                }
            }

            if (chem.Error)
            {
                string message = "Formula with m/z:" + chem.Mz + " and ion type:" + chem.Ion + " encountered an error";
                MessageBox.Show(message, "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            // Calculate isoPattern, then the envelope (heavy on cpu!!!) then centroids used for ppm_error.
            // default algorithm for isotopic patern is 1. Switch to 2 if there are more than 100C
            short algo = 2;
            int idx = chem.FinalFormula.IndexOf("C");
            if (Char.IsNumber(chem.FinalFormula[idx + 2]) == true && Char.IsNumber(chem.FinalFormula[idx + 3]) == true) algo = 2;
            ChemiForm.Isopattern(chem, 1000000, algo, 0, 0.01);

            ChemiForm.Envelope(chem);
            ChemiForm.Vdetect(chem);
            double emass = 0.00054858;
            List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
            chem.Points= chem.Points.OrderBy(p => p.X).ToList();
            chem.Mz = Math.Round((chem.Monoisotopic.Mass-emass*chem.Charge) / chem.Charge, 4).ToString(); 
            // MAIN decesion algorithm 
            bool fragment_is_canditate = decision_algorithm_frm9(chem, cen);

            // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
            
            if (fragment_is_canditate)
            {
                chem.Profile.Clear();
                ChemiForm.Envelope(chem);
                add_fragment_to_Fragments3(chem,cen);return;
            }
            else if (ignore_ppm_form9.Checked)
            {
                //chem.Profile.Clear();
                //ChemiForm.Envelope(chem);               
                //MessageBox.Show(chem.Name+ " is out of ppm bounds.");
                add_fragment_to_Fragments3(chem, cen);
                return;

            }
            else
            {
                chem.Points.Clear(); chem.Profile.Clear();
            }
        }

        private void add_fragment_to_Fragments3(ChemiForm chem, List<PointPlot> cen)
        {
            // adds safely a matched fragment to Fragments3, and releases memory
            lock (_locker)
            {                
                Fragments3.Add(new FragForm()
                {
                    Adduct = chem.Adduct,
                    Charge = chem.Charge,
                    FinalFormula = chem.FinalFormula,
                    Deduct = chem.Deduct,
                    Error = chem.Error,
                    PPM_Error = chem.PPM_Error,
                    Index = chem.Index,
                    IndexTo = chem.IndexTo,
                    InputFormula = chem.InputFormula,
                    Ion = chem.Ion,
                    Ion_type = chem.Ion_type,
                    Machine = chem.Machine,
                    Multiplier = chem.Multiplier,
                    Mz = chem.Mz,
                    Radio_label = chem.Radio_label,
                    Resolution = chem.Resolution,
                    Factor = chem.Factor,
                    Counter = 0,
                    To_plot = false,
                    Color = chem.Color,
                    Name = chem.Name,
                    ListName = new string[4],
                    Fix = 1.0,
                    Max_intensity = 0.0,
                    Fixed = chem.Fixed,
                    maxPPM_Error=chem.maxPPM_Error,
                    minPPM_Error=chem.minPPM_Error
                });               
                Fragments3.Last().Centroid = cen.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);
                
                if (chem.Charge > 0) Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                else Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                double pt0 = 0.1*Form2.max_exp;
                if (all_data[0].Count > 0 && all_data[0][0][0] < Fragments3.Last().Profile[0].X && all_data[0].Last()[0] > Fragments3.Last().Profile.Last().X)
                {
                    try
                    {
                        pt0 = all_data[0].FindAll(x => (x[0] >= Fragments3.Last().Centroid[0].X-2 && x[0] < Fragments3.Last().Centroid[0].X+2)).Max(k => k[1]);
                    }
                    catch
                    {
                        pt0 = 0.1 * Form2.max_exp;
                    }
                }
                Fragments3.Last().Factor = pt0 / Fragments3.Last().Max_intensity;
                // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                // Profile is stored already in Fragments3, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                chem.Profile.Clear();
                chem.Points.Clear();
            }
        }
        private bool decision_algorithm_frm9(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;
            double max_error = 0.0;
            // deceide how many peaks will be involved in the selection process
            // results = {[resol1, ppm1], [resol2, ppm2], ....}
            List<double[]> results = new List<double[]>();

            int total_peaks = cen.Count;
            int contrib_peaks = 0;
            int rule_idx = Array.IndexOf(selection_rule9, true);

            if (rule_idx < 3) contrib_peaks = rule_idx + 1;   // hard limit, one two or three peaks
            else
            {
                if (rule_idx == 3) contrib_peaks = total_peaks / 2;                 // Total 8, use 4. Total 7, use 3
                else if (rule_idx == 4) contrib_peaks = total_peaks / 2 - 1;        // Total 8, use 3. Total 7, use 2
                else if (rule_idx == 5) contrib_peaks = total_peaks / 2 + 1;        // Total 8, use 5. Total 7, use 4
            }

            // sanity check. No matter what, check at least most intense peak!
            if (contrib_peaks == 0) contrib_peaks = 1;

            for (int i = 0; i < contrib_peaks; i++)
            {
                double[] tmp = ppm_calculator(cen[i].X);

                if (Math.Abs(tmp[0])< ppmError9) results.Add(tmp);
                else { fragment_is_canditate = false; break; }
            }

            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate) {  return false; }           
            chem.PPM_Error = results.Average(p => p[0]);
            //foreach (double[] pp in results)
            //{
            //    if (Math.Abs(pp[0])>Math.Abs(max_error)) { max_error = pp[0]; }
            //}
            //if (max_error < 0) { chem.PPM_Error = -chem.PPM_Error; }
            chem.Resolution = (double)results.Average(p => p[1]);

            return fragment_is_canditate;
        }
        #endregion

        #region progress display
        private void progress9_display_start(int barMax, string info)
        {
            statusStrpFrm9.Invoke(new Action(() => statusStrpFrm9.Visible = true));
            statusStrpFrm9.Invoke(new Action(() => progressLabel9.Text = info));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.ProgressBar.Maximum = barMax));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.ProgressBar.Value = 0));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.Visible = true));   //thread safe call                     
        }
        private void progress_display_stop()
        {
            statusStrpFrm9.Invoke(new Action(() => statusStrpFrm9.Visible = false));   //thread safe call           
        }
        private void progress_display_update(int idx)
        {
            statusStrpFrm9.Invoke(new Action(() => progressLabel9.Invalidate()));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.ProgressBar.Value = idx));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.ProgressBar.Value = idx - 1));
            statusStrpFrm9.Invoke(new Action(() => ProgressBar9.ProgressBar.Update()));   //thread safe call
        }



        #endregion

        #region insert fragment to Fragments2
        private void insert_Btn_Click(object sender, EventArgs e)
        {
            insert_frag_to_Fragments2();
        }
        private void insert_frag_to_Fragments2()
        {
            if (fragListView9.SelectedItems.Count == 1)
            {
                //set now to false in order to let refresh_iso_plot follow the basic algorithm 
                now = false;
                Fragments2.Add(new FragForm()
                {
                    Adduct = Fragments3[selected_idx].Adduct,
                    Charge = Fragments3[selected_idx].Charge,
                    FinalFormula = Fragments3[selected_idx].FinalFormula,
                    Deduct = Fragments3[selected_idx].Deduct,
                    Error = Fragments3[selected_idx].Error,
                    PPM_Error = Fragments3[selected_idx].PPM_Error,
                    Index = Fragments3[selected_idx].Index,
                    IndexTo = Fragments3[selected_idx].IndexTo,
                    InputFormula = Fragments3[selected_idx].InputFormula,
                    Ion = Fragments3[selected_idx].Ion,
                    Ion_type = Fragments3[selected_idx].Ion_type,
                    Machine = Fragments3[selected_idx].Machine,
                    Multiplier = Fragments3[selected_idx].Multiplier,
                    Mz = Fragments3[selected_idx].Mz,
                    Radio_label = Fragments3[selected_idx].Radio_label,
                    Resolution = Fragments3[selected_idx].Resolution,
                    Factor = Fragments3[selected_idx].Factor,
                    Counter = 0,
                    To_plot = true,
                    Color = Fragments3[selected_idx].Color,
                    Name = Fragments3[selected_idx].Name,
                    ListName = new string[4],
                    Fix = 1.0,
                    Max_intensity = 0.0,
                    Fixed = false,
                    maxPPM_Error= Fragments3[selected_idx].maxPPM_Error,
                    minPPM_Error= Fragments3[selected_idx].minPPM_Error
                });

                Fragments2.Last().Centroid = Fragments3[selected_idx].Centroid.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Profile = Fragments3[selected_idx].Profile.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Counter = Fragments3.Count;
                Fragments2.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);

                // sort by mz the fragments list (global) 
                Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
                // also restore indexes to match array position
                for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
                frm2.add_frag_frm9();

                //remove fragment from the current listview
                Fragments3.RemoveAt(selected_idx);
                // sort by mz the fragments list 
                Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
                // also restore indexes to match array position
                for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k ; }
                //refresh listview 
                Fragments3_to_listview();
                //important step otherwise when the user clicks another fragment from the new listview the algorithm will remove the last element of all_data in order to all the new fragment 
                first = true; 
                factor_panel9.Visible = false;selected_idx = 0;
            }
            else
            {
                MessageBox.Show("There isn't any selected fragment.");
            }
            
        }
        #endregion
               

        #region UI
        private void check_all_boxBtn_Click(object sender, EventArgs e)
        {
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
            {
                for (int i = 0; i < lstBox.Items.Count; i++)
                {
                    lstBox.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void uncheck_all_boxBtn_Click(object sender, EventArgs e)
        {
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
            {
                foreach (int i in lstBox.CheckedIndices)
                {
                    lstBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
             
        private void minCharge_txtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(minCharge_txtBox.Text))
            {
                if (minCharge_txtBox.Text != "-")
                {
                    try
                    {
                        double.Parse(minCharge_txtBox.Text, NumberStyles.Integer);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numbers.");
                        minCharge_txtBox.Text = minCharge_txtBox.Text.Remove(minCharge_txtBox.Text.Length - 1);
                        minCharge_txtBox.SelectionStart = minCharge_txtBox.Text.Length;
                        minCharge_txtBox.SelectionLength = 0;
                    }
                }
            }
        }

        private void maxCharge_txtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maxCharge_txtBox.Text))
            {
                if (maxCharge_txtBox.Text != "-")
                {

                    try
                    {
                        double.Parse(maxCharge_txtBox.Text, NumberStyles.Integer);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numbers.");
                        maxCharge_txtBox.Text = maxCharge_txtBox.Text.Remove(maxCharge_txtBox.Text.Length - 1);
                        maxCharge_txtBox.SelectionStart = maxCharge_txtBox.Text.Length;
                        maxCharge_txtBox.SelectionLength = 0;
                    }
                }
            }
        }

        private void internal_txtBox_TextChanged(object sender, EventArgs e)
        {
            primary_txtBox.Text = null;
        }

        private void ion_txtBox_TextChanged(object sender, EventArgs e)
        {

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

        private void primary_txtBox_TextChanged(object sender, EventArgs e)
        {
            internal_txtBox.Text = null;
        }
        private void heavy_ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (heavy_ChkBox.Checked)
            {
                Light_chkBox.Checked = false;
            }
        }

        private void Light_chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Light_chkBox.Checked)
            {
                heavy_ChkBox.Checked = false;
            }
        }

        #endregion

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            //when closing the form public data from this form are restored in their initial values
            initialize_data();
            //when the form closes we refresh all_data , all_data_aligned etc... list anyway based on Fragments2 list
            //we don't want to refresh fragment trees in the basic form
            frm2.ending_frm9();
        }
        
        private void chemForm_tab_Click(object sender, EventArgs e)
        {
            panel_calc.Focus();
        }

        private void Frag_tab_Click(object sender, EventArgs e)
        {
            panel_calc.Focus();
        }

        void ppm9_numUD_TextChanged(object sender, EventArgs e)
        {
            if (ppm9_numUD.ActiveControl!=null && !string.IsNullOrEmpty(ppm9_numUD.ActiveControl.Text))
            {
                ppmError9 = double.Parse(ppm9_numUD.ActiveControl.Text);
            }
        }
    }
}
