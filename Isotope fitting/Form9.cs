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

            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();

            ppm9_numUD.ValueChanged += (s, e) => { ppmError9 = (double)ppm9_numUD.Value; };
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
        }

       
        #region listview UI
        private void Initialize_listviewComparer()
        {
            fragListView9.ListViewItemSorter = _lvwItemComparer;
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
                listviewitem.SubItems.Add(fra.FinalFormula.ToString());
                listviewitem.SubItems.Add(fra.Counter.ToString());

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
            selected_idx = System.Convert.ToInt32(e.Item.SubItems[5].Text);
            if (first)
            {
                // pass the envelope (profile) of each NEW fragment in Fragment2 to all data
                if (all_data.Count == 0) { all_data.Add(new List<double[]>()); Form2.custom_colors.Clear(); custom_colors.Add(OxyColors.Black.ToColor().ToArgb()); }
                custom_colors.Add(Fragments3[selected_idx].Color.ToColor().ToArgb());                
            }
            else
            {
                all_data.RemoveAt(all_data.Count-1); custom_colors.RemoveAt(custom_colors.Count-1);
            }
            all_data.Add(new List<double[]>());
            for (int p = 0; p < Fragments3[selected_idx].Profile.Count; p++)
                all_data.Last().Add(new double[] { Fragments3[selected_idx].Profile[p].X, Fragments3[selected_idx].Profile[p].Y });
            custom_colors.Add(Fragments3[selected_idx].Color.ToColor().ToArgb());
            first = false;now = true;
            frm2.do_it();
        }
        private void clear_FragListview9()
        {

        }
        #endregion



        #region isotopic distributions calculations
        private void calc_Btn_Click(object sender, EventArgs e)
        {
            if (Fragments3.Count > 0) Fragments3.Clear();
            fragments_and_calculations_sequence_A();
        }
        private void fragments_and_calculations_sequence_A()
        {
            // this the main sequence after loadind data
            // 1. select fragments according to UI            
            sw1.Reset(); sw1.Start();
            List<ChemiForm> selected_fragments = select_fragments2();
            if (selected_fragments == null) return;
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            calculate_fragments_resolution(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments3.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties(selected_fragments));
            envipat_properties.Start();
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

        private void calculate_fragments_resolution(List<ChemiForm> selected_fragments)
        {
            foreach (ChemiForm chem in selected_fragments)
            {
                chem.Machine = "Elite_R60000@400";
            }
        }

        private void calculate_fragment_properties(List<ChemiForm> selected_fragments)
        {
            // main routine for parallel calculation of fragments properties and filtering by ppm and peak rules
            sw1.Reset(); sw1.Start(); int progress = 0;
            progress9_display_start(selected_fragments.Count, "Calculating fragment isotopic distributions...");
            try
            {
                Parallel.For(0, selected_fragments.Count, (i, state) =>
                {
                    Envipat_Calcs_and_filter_byPPM(selected_fragments[i]);


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
            MessageBox.Show("From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments3.Count.ToString() + " were within ppm filter.", "Fragment selection results");
            Invoke(new Action(() => OnCalcFrag3Completed()));
        }
        private void Envipat_Calcs_and_filter_byPPM(ChemiForm chem)
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
            short algo = 1;
            int idx = chem.FinalFormula.IndexOf("C");
            if (Char.IsNumber(chem.FinalFormula[idx + 2]) == true && Char.IsNumber(chem.FinalFormula[idx + 3]) == true) algo = 2;
            ChemiForm.Isopattern(chem, 1000000, algo, 0, 0.01);

            ChemiForm.Envelope(chem);
            ChemiForm.Vdetect(chem);
            List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();

            // MAIN decesion algorithm
            bool fragment_is_canditate = decision_algorithm(chem, cen);

            // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
            if (fragment_is_canditate)
            {
                chem.Profile.Clear();
                ChemiForm.Envelope(chem);
                add_fragment_to_Fragments3(chem,cen);
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
                });               
                Fragments3.Last().Centroid = cen.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);
                Fragments3.Last().Factor = 0.1 * Form2.max_exp / Fragments3.Last().Max_intensity;        // start all fragments at 10% of the main experimental peak (one order of mag. less)

                if (chem.Charge > 0) Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                else Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                
                // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                // Profile is stored already in Fragments3, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                chem.Profile.Clear();
                chem.Points.Clear();
            }
        }
        private bool decision_algorithm(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;

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

                if (tmp[0] < ppmError9) results.Add(tmp);
                else { fragment_is_canditate = false; break; }
            }

            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate) { chem.Profile.Clear(); chem.Points.Clear(); return false; }

            chem.PPM_Error = results.Average(p => p[0]);
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

        
    }
}
