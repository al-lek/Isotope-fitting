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
using System.Text.RegularExpressions;
using System.IO;

namespace Isotope_fitting
{
    public partial class Form9 : Form
    {
        Form2 frm2;
        private double ppmError9=8.0;
        private double thres9 = 0.01;
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
        bool is_res_user_defined = false;
        public static List<int> last_plotted = new List<int>();
        List<ChemiForm> mult_loaded = new List<ChemiForm>();

        public Form9(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            OnCalcFrag3Completed += () => { Fragments3_to_listview(); };
            ppm9_numUD.TextChanged += new EventHandler(ppm9_numUD_TextChanged);
            thre_numUD.TextChanged += new EventHandler(thre_numUD_TextChanged);
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();
            ppm9_numUD.Value =(decimal)ppmError9;
            thre_numUD.Value = (decimal)thres9;
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
            ContextMenu ctxMn1 = new ContextMenu() { };            
            MenuItem colorSelection = new MenuItem("Fragment color", colorSelectionList);
            MenuItem remFrag = new MenuItem("Delete fragment", delete_frag);
            MenuItem clearall = new MenuItem("Clear all", delete_all);


            ctxMn1.MenuItems.AddRange(new MenuItem[] {colorSelection, remFrag, clearall });
            fragListView9.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn1; } };
        }
        private void Form9_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void delete_all(object sender, EventArgs e)
        {
            fragListView9.Enabled=false;
            int count = last_plotted.Count;
            if ((sender as MenuItem).Text == "Clear all" )
            {
                //when closing the form public data from this form are restored in their initial values
                initialize_data();
                fragListView9.BeginUpdate();
                fragListView9.Items.Clear();               
                fragListView9.EndUpdate();
                if (count != 0)
                {
                    all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                    last_plotted.Clear();
                    frm2.recalc_frm9(count, last_plotted.Count);
                }
                //when the form closes we refresh all_data , all_data_aligned etc... list anyway based on Fragments2 list
                //we don't want to refresh fragment trees in the basic form
                //frm2.ending_frm9();

            }
            fragListView9.Enabled = true;
        }
        private void delete_frag(object sender, EventArgs e)
        {
            int count_last_plotted = last_plotted.Count;

            if (fragListView9.SelectedIndices.Count == 0) { MessageBox.Show("First select the fragment and then press delete!"); return; }
            fragListView9.Enabled = false;
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            if ((sender as MenuItem).Text == "Delete fragment" && selectedItems.Count > 0)
            {
                now = false;
                int count = 0;
                foreach (int item in fragListView9.SelectedIndices)
                {
                    //remove fragment from the current listview
                    Fragments3.RemoveAt(item - count); count++;                   
                }
                // sort by mz the fragments list 
                Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
                // also restore indexes to match array position
                for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k; }
                //refresh listview 
                Fragments3_to_listview();
                //if (count_last_plotted != 0)
                //{
                //    all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                //    last_plotted.Clear();
                //}
                //important step otherwise when the user clicks another fragment from the new listview the algorithm will remove the last element of all_data in order to all the new fragment 
                first = true;
                factor_panel9.Visible = false; selected_idx = 0;
                //frm2.ending_frm9();                
            }
            fragListView9.Enabled = true;
            plot_checked(true,count_last_plotted);
        }
        private void colorSelectionList(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            if ((sender as MenuItem).Text == "Fragment color" && selectedItems.Count > 0)
            {
                foreach (int item in fragListView9.SelectedIndices)
                {
                    ColorDialog clrDlg = new ColorDialog();
                    if (clrDlg.ShowDialog() == DialogResult.OK) {  Fragments3[item].Color = OxyColor.FromUInt32((uint)clrDlg.Color.ToArgb()); }
                }
            }
        }
        void thre_numUD_TextChanged(object sender, EventArgs e)
        {
            if (thre_numUD.ActiveControl != null && !string.IsNullOrEmpty(thre_numUD.ActiveControl.Text))
            {
                thres9 = Double.Parse(thre_numUD.ActiveControl.Text);
            }
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
            ////ensure that the focus is mainly on numeric up down box in the factor_panel9 
            //if (factor_panel9.Visible)
            //{
            //    factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus();
            //}
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
                if (fra.Ion_type.StartsWith("int")) { listviewitem.SubItems.Add(fra.Index + "-" + fra.IndexTo); }
                else { listviewitem.SubItems.Add(fra.Index); }
                listviewitem.SubItems.Add(fra.Mz);
                listviewitem.SubItems.Add(fra.Charge.ToString());
                listviewitem.SubItems.Add(fra.InputFormula.ToString());
                listviewitem.SubItems.Add(fra.Counter.ToString());
                listviewitem.SubItems.Add(fra.PPM_Error.ToString("0.##"));
                if (!fra.Candidate) { listviewitem.ForeColor = Color.Red; }
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
            if (last_plotted.Count==0) { return; }
            now = true;
            //if (factor_panel9.Controls.Count > 0) { factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus(); }
            if (e.IsSelected)
            {
                selected_idx = System.Convert.ToInt32(e.Item.SubItems[5].Text);
                now = true;
                adjust_height();

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
            //numUD.Leave += (s, e) => { if (!panel_calc.Focused) { numUD.Focus(); } };
             factor_panel9.Controls.AddRange(new Control[] { factor_lbl, numUD });
            //factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus();
        }
        #endregion

        #region isotopic distributions calculations
        private void calc_Btn_Click(object sender, EventArgs e)
        {
            if (Fragments3.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Clear List before proceeding with calculation?", "Fragment Calculator", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) Fragments3.Clear();
            }            
            //the basic algorithm with small changes for the specific form9
            fragments_and_calculations_sequence_A_frm9();
        }
        private void fragments_and_calculations_sequence_A_frm9()
        {
            // this the main sequence after loading data
            // 1. select fragments according to UI            
            sw1.Reset(); sw1.Start();
            is_res_user_defined = false;
            List<ChemiForm> selected_fragments = new List<ChemiForm>();
            if (FragCalc_TabControl.SelectedTab == FragCalc_TabControl.TabPages["Frag_tab"])
            {
                if (ChemFormulas == null || ChemFormulas.Count == 0) { MessageBox.Show("You must first load an MS Product file for this action."); return; }
                selected_fragments = select_fragments2_frm9();
            }
            else if (mult_loaded!=null && mult_loaded.Count>0)
            {
                selected_fragments = mult_loaded;
            }
            else if ((string.IsNullOrEmpty(minCharge_txtBox.Text) && string.IsNullOrEmpty(maxCharge_txtBox.Text)) || string.IsNullOrEmpty(ion_txtBox.Text)) { MessageBox.Show("You must first set the charge range and the ion type or name of the fragment for this action.", "Chemical Formula Calculation"); return; }
            else { selected_fragments = check_chem_inputs(); }

            if (selected_fragments.Count == 0) { MessageBox.Show("No fragments found"); return; } 
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
            List<ChemiForm> res = new List<ChemiForm>();
            bool ext_exists = true;
            string chem_form = string.Empty;
            List<int> charge = new List<int>();
            string ion = string.Empty;
            string index = string.Empty;
            string indexTo = string.Empty;
            string s = frm2.Peptide;
            string extension = extensionBox1.Text.ToString();
            int chain_type = 0;
            if (heavy_ChkBox.Checked && Light_chkBox.Checked) { MessageBox.Show("Both heavy ald light chain are checked. Please select only one chain type."); return res; }
            else if (heavy_ChkBox.Checked) { chain_type = 1; }
            else if (Light_chkBox.Checked) { chain_type = 2; }
            if (!string.IsNullOrEmpty(extension))
            {
                ext_exists = false;
                foreach (SequenceTab seq in frm2.sequenceList)
                {
                   if(seq.Extension.Equals(extension)) { s = seq.Sequence; ext_exists = true; break; }
                }
                extension = "_" + extension;
            }
            if (!ext_exists)
            {
                DialogResult dd = MessageBox.Show("There is no sequence for the extension type you have inserted." +                   
                    "If you want to stop the calcuations select 'No'. " +
                    "If you want to proceed with the calculations press 'Yes'", "Wrong Input", MessageBoxButtons.YesNo);
                if (dd == DialogResult.No || dd == DialogResult.None) { return res; }
            }
            if (ion_txtBox.Text.Contains("M"))
            {
                if (!ext_exists && string.IsNullOrEmpty(internal_txtBox.Text))
                {
                    DialogResult dd= MessageBox.Show("There is no sequence for the extension type you have inserted." +
                        " This will affect the index numbers for the precursor ion you have inserted." +
                        "If you want to stop the calcuations and insert the correct indexes in the internal indexes section select 'No'. " +
                        "If you want to proceed with the calculations press 'Yes'","Wrong Input",MessageBoxButtons.YesNo);
                    if (dd==DialogResult.No || dd == DialogResult.None) { return res; }                   
                }
                index = "0";indexTo = s.Length.ToString();
            }   
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
            if (double.IsNaN(qMax)) qMax = qMin;
            
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
                    Ion_type=ion,
                    Extension=extension,
                    Chain_type=chain_type
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
                res.Last().Radio_label += extension; res.Last().Name += extension;
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
            if (double.IsNaN(qMax)) qMax = 100.0;

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
                bool is_side_chain = side_chain.Any(curr_type.StartsWith);
                bool is_internal = curr_type.StartsWith("internal");
                bool is_neutral_loss = primary.Any(curr_type.StartsWith) && curr_type.Contains("H");
                bool is_primary = primary.Contains(curr_type);
                bool is_primary_Hyd = primary.Any(curr_type.StartsWith) && !curr_type.Contains("H") && curr_type.Length > 1;

                // drop frag by mz and charge rules
                if (curr_mz < mzMin || curr_mz > mzMax || curr_q < qMin || curr_q > qMax) continue;

                if (is_internal && internal_indexesTo.Count > 0 && internal_indexesTo.Count > 0)
                {
                    int index1 = Int32.Parse(chem.Index);
                    int index2 = Int32.Parse(chem.IndexTo);
                    bool in_bounds = false;
                    for (int k = 0; k < internal_indexesTo.Count; k++)
                    {
                        if (index2 >= internal_indexesTo[k][0] && index2 <= internal_indexesTo[k][1] && index1 >= internal_indexesFrom[k][0] && index1 <= internal_indexesFrom[k][1])
                        {
                            in_bounds = true; break;
                        }
                    }
                    if (!in_bounds) continue;
                }
                else if (!is_precursor && primary_indexes.Count > 0)
                {
                    int index1 = Int32.Parse(chem.Index);
                    if (sortIdx_chkBx.Checked) { index1 = chem.SortIdx; }                    
                    bool in_bounds = false;
                    for (int k = 0; k < primary_indexes.Count; k++)
                    {
                        if (index1 >= primary_indexes[k][0] && index1 <= primary_indexes[k][1])
                        {
                            in_bounds = true; break;
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
            if (!string.IsNullOrEmpty(resolution_Box.Text) && resolution_Box.Enabled)
            {
                is_res_user_defined = true;
                try
                {
                    double res = (double)dParser(resolution_Box.Text.ToString());
                    foreach (ChemiForm chem in selected_fragments)
                    {
                        chem.Resolution = res;
                    }
                }
                catch
                {
                    is_res_user_defined = false;
                }                
            }
            if (is_res_user_defined) return;
            else if (frm2.is_exp_deconvoluted)
            {
                string machine = "";
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
                    chem.Machine = "Q-Exactive,ExactivePlus_280K@200";
                }
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
            if (!string.IsNullOrEmpty(chemForm_txtBox.Text)) { MessageBox.Show("Chemical formulas profile calculation is completed!From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments3.Count.ToString() + " were within ppm filter.", "Chemical formula calculation results"); }
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
            short algo = 1;
            int idx = chem.FinalFormula.IndexOf("C");
            if (Char.IsNumber(chem.FinalFormula[idx + 2]) == true && Char.IsNumber(chem.FinalFormula[idx + 3]) == true) algo = 2;
            ChemiForm.Isopattern(chem, 1000000, algo, 0, thres9);

            ChemiForm.Envelope(chem);
            ChemiForm.Vdetect(chem);
            double emass = 0.00054858;
            List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
            chem.Centroid.Clear(); chem.Intensoid.Clear();
            chem.Points= chem.Points.OrderBy(p => p.X).ToList();
            chem.Mz = Math.Round((chem.Monoisotopic.Mass-emass*chem.Charge) / chem.Charge, 4).ToString();
            if (!insert_exp ) { add_fragment_to_Fragments3(chem, cen); return; }
            // MAIN decesion algorithm 
            bool fragment_is_canditate = decision_algorithm_frm9(chem, cen);

            //// only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)            
            //if (fragment_is_canditate)
            //{
            //    chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
            //    ChemiForm.Envelope(chem);
            //    ChemiForm.Vdetect(chem);
            //    cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
            //    chem.Centroid.Clear(); chem.Intensoid.Clear();
            //    add_fragment_to_Fragments3(chem,cen);return;
            //}
            //else if (ignore_ppm_form9.Checked)
            //{
            //    //chem.Profile.Clear();
            //    //ChemiForm.Envelope(chem);               
            //    //MessageBox.Show(chem.Name+ " is out of ppm bounds.");
            //    chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
            //    ChemiForm.Envelope(chem);
            //    ChemiForm.Vdetect(chem);
            //    cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
            //    chem.Centroid.Clear(); chem.Intensoid.Clear();
            //    add_fragment_to_Fragments3(chem, cen,false);
            //    return;
            //}
            //else
            //{
            //    chem.Points.Clear(); chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
            //}
        }

        private void add_fragment_to_Fragments3(ChemiForm chem, List<PointPlot> cen, bool candidate=true)
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
                    minPPM_Error=chem.minPPM_Error,
                    Candidate=candidate,
                    Extension = chem.Extension,
                    Chain_type = chem.Chain_type,
                    SortIdx = chem.SortIdx
                });               
                Fragments3.Last().Centroid = cen.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                Fragments3.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);
                
                if (chem.Charge > 0) Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                else Fragments3.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                if (insert_exp)
                {
                    double pt0 = 0.1 * Form2.max_exp;
                    if (all_data[0].Count > 0 && all_data[0][0][0] < Fragments3.Last().Profile[0].X && all_data[0].Last()[0] > Fragments3.Last().Profile.Last().X)
                    {
                        try
                        {
                            pt0 = all_data[0].FindAll(x => (x[0] >= Fragments3.Last().Centroid[0].X - 2 && x[0] < Fragments3.Last().Centroid[0].X + 2)).Max(k => k[1]);
                        }
                        catch
                        {
                            pt0 = 0.1 * Form2.max_exp;
                        }
                    }
                    Fragments3.Last().Factor = pt0 / Fragments3.Last().Max_intensity;
                }               
                // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                // Profile is stored already in Fragments3, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                chem.Profile.Clear();
                chem.Points.Clear();
                chem.Centroid.Clear(); chem.Intensoid.Clear();
            }
        }
        private bool decision_algorithm_frm9(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is candidate for fitting
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
            if (contrib_peaks > cen.Count) { contrib_peaks = cen.Count; }
            //round 1 , to find the correct resolution 
            //for the deconvoluted spectra the resolution is not derived from the experimental therefore there is only round 1
            for (int i = 0; i < contrib_peaks; i++)
            {
                double[] tmp = ppm_calculator(cen[i].X);
                results.Add(tmp);
                if (Math.Abs(tmp[0])> ppmError9) 
                {
                    //fragment_is_canditate = false;
                    try
                    {
                        if (is_res_user_defined || frm2.is_exp_deconvoluted)
                        {
                            fragment_is_canditate = false;
                            break;
                        }                       
                    }
                    catch { }                   
                }
            }
            if (!fragment_is_canditate && !ignore_ppm_form9.Checked) { return false; }
            if (fragment_is_canditate && !frm2.is_exp_deconvoluted &&!is_res_user_defined)
            {
                chem.Resolution = (double)results.Average(p => p[1]);
                results = new List<double[]>();
                chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
                // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
                ChemiForm.Envelope(chem);
                ChemiForm.Vdetect(chem);
                cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
                for (int i = 0; i < contrib_peaks; i++)
                {
                    double[] tmp = ppm_calculator(cen[i].X);
                    results.Add(tmp);
                    if (Math.Abs(tmp[0]) > ppmError9) { fragment_is_canditate = false; }
                }
            }                
            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate && !ignore_ppm_form9.Checked) { return false; }
            chem.PPM_Error = results.Average(p => p[0]);
            if (results.Count > 1) { chem.maxPPM_Error = results.Max(p => p[0]); chem.minPPM_Error = results.Min(p => p[0]); }
            else { chem.maxPPM_Error = 0.0; chem.minPPM_Error = 0.0; }
            if (fragment_is_canditate){add_fragment_to_Fragments3(chem, cen);}
            else if (ignore_ppm_form9.Checked){add_fragment_to_Fragments3(chem, cen, false);}
            else{chem.Points.Clear(); chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();}
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
            if (fragListView9.CheckedIndices.Count == 0) { MessageBox.Show("First check the desired fragments and then press insert!"); return; }
            foreach (int new_fragin in fragListView9.CheckedIndices)
            {
                //set now to false in order to let refresh_iso_plot follow the basic algorithm 
                now = false;
                Fragments2.Add(new FragForm()
                {
                    Adduct = Fragments3[new_fragin].Adduct,
                    Charge = Fragments3[new_fragin].Charge,
                    FinalFormula = Fragments3[new_fragin].FinalFormula,
                    Deduct = Fragments3[new_fragin].Deduct,
                    Error = Fragments3[new_fragin].Error,
                    PPM_Error = Fragments3[new_fragin].PPM_Error,
                    Index = Fragments3[new_fragin].Index,
                    IndexTo = Fragments3[new_fragin].IndexTo,
                    InputFormula = Fragments3[new_fragin].InputFormula,
                    Ion = Fragments3[new_fragin].Ion,
                    Ion_type = Fragments3[new_fragin].Ion_type,
                    Machine = Fragments3[new_fragin].Machine,
                    Multiplier = Fragments3[new_fragin].Multiplier,
                    Mz = Fragments3[new_fragin].Mz,
                    Radio_label = Fragments3[new_fragin].Radio_label,
                    Resolution = Fragments3[new_fragin].Resolution,
                    Factor = Fragments3[new_fragin].Factor,
                    Counter = 0,
                    To_plot = true,
                    Color = Fragments3[new_fragin].Color,
                    Name = Fragments3[new_fragin].Name,
                    ListName = new string[4],
                    Fix = 1.0,
                    Max_intensity = 0.0,
                    Fixed = false,
                    maxPPM_Error= Fragments3[new_fragin].maxPPM_Error,
                    minPPM_Error= Fragments3[new_fragin].minPPM_Error,
                    Extension = Fragments3[new_fragin].Extension,
                    Chain_type = Fragments3[new_fragin].Chain_type,
                    SortIdx = Fragments3[new_fragin].SortIdx,
                    Candidate = Fragments3[new_fragin].Candidate
                });

                Fragments2.Last().Centroid = Fragments3[new_fragin].Centroid.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Profile = Fragments3[new_fragin].Profile.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Counter = Fragments3.Count;
                Fragments2.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);
            }
            // sort by mz the fragments list (global) 
            Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
            frm2.add_frag_frm9();

            int count = 0;
            foreach (int new_fragin in fragListView9.CheckedIndices)
            {
                //remove fragment from the current listview
                Fragments3.RemoveAt(new_fragin- count); count++;
            }                
            // sort by mz the fragments list 
            Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k; }
            //refresh listview 
            Fragments3_to_listview();
            last_plotted.Clear();
            //important step otherwise when the user clicks another fragment from the new listview the algorithm will remove the last element of all_data in order to all the new fragment 
            first = true;
            factor_panel9.Visible = false; selected_idx = 0;
        }
        #endregion


        #region UI
        private void clear_single_chem_Btn_Click(object sender, EventArgs e)
        {
            heavy_ChkBox.Checked = false;
            Light_chkBox.Checked = false;
            chemForm_txtBox.Text = string.Empty;
            maxCharge_txtBox.Text = string.Empty;
            minCharge_txtBox.Text = string.Empty;
            extensionBox1.Text = string.Empty;
            ion_txtBox.Text = string.Empty;
            primary_txtBox.Text = string.Empty;
            internal_txtBox.Text = string.Empty;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (CheckedListBox lstBox in GetControls(this).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
            {
                foreach (int i in lstBox.CheckedIndices)
                {
                    lstBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            mzMin_Box.Text = string.Empty;
            mzMax_Box.Text = string.Empty;
            chargeMin_Box.Text = string.Empty;
            chargeMax_Box.Text = string.Empty;
            idxPr_Box.Text = string.Empty;
            idxFrom_Box.Text = string.Empty;
            idxTo_Box.Text = string.Empty;
            sortIdx_chkBx.Checked = false;
        }
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

        #endregion


        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            int count = last_plotted.Count;
            //when closing the form public data from this form are restored in their initial values
            initialize_data();
            if (count != 0)
            {
                all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                last_plotted.Clear();
                frm2.recalc_frm9(count, last_plotted.Count);
            }
            ////when the form closes we refresh all_data , all_data_aligned etc... list anyway based on Fragments2 list
            ////we don't want to refresh fragment trees in the basic form
            //frm2.ending_frm9();
        }
                
        void ppm9_numUD_TextChanged(object sender, EventArgs e)
        {
            if (ppm9_numUD.ActiveControl!=null && !string.IsNullOrEmpty(ppm9_numUD.ActiveControl.Text))
            {
                ppmError9 = double.Parse(ppm9_numUD.ActiveControl.Text);
            }
        }

        private void resolution_Box_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(resolution_Box.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                resolution_Box.Text = resolution_Box.Text.Remove(resolution_Box.Text.Length - 1);
                resolution_Box.SelectionStart = resolution_Box.Text.Length;
                resolution_Box.SelectionLength = 0;
            }
        }

        private void ignore_ppm_form9_CheckedChanged(object sender, EventArgs e)
        {
            resolution_Box.Enabled = ignore_ppm_form9.Checked;
        }


        #region plot, un-plot fragments
        private void plot_Btn_Click(object sender, EventArgs e)
        {
            plot_checked();
        }
        private void plot_checked(bool from_delete = false,int count_last_plotted=0)
        {
            int count = last_plotted.Count;
            if (from_delete) { count = count_last_plotted; }
            if (count != 0)
            {
                all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                last_plotted.Clear();
            }
            foreach (int frag_idx in fragListView9.CheckedIndices)
            {
                if (first)
                {
                    // pass the envelope (profile) of each NEW fragment in Fragment2 to all data
                    if (all_data.Count == 0) { all_data.Add(new List<double[]>()); Form2.custom_colors.Clear(); custom_colors.Add(OxyColors.Black.ToColor().ToArgb()); }
                    //custom_colors.Add(Fragments3[selected_idx].Color.ToColor().ToArgb());
                }
                all_data.Add(new List<double[]>());
                for (int p = 0; p < Fragments3[frag_idx].Profile.Count; p++)
                {
                    all_data.Last().Add(new double[] { Fragments3[frag_idx].Profile[p].X, Fragments3[frag_idx].Profile[p].Y });
                }
                custom_colors.Add(Fragments3[frag_idx].Color.ToColor().ToArgb());
                first = false; now = true;
                last_plotted.Add(frag_idx);
            }
            if (last_plotted.Count != 0 || count!=0)
            {
                frm2.recalc_frm9(count, last_plotted.Count);
                //frm2.recalc_frm9(count, last_plotted.Count);               
            }
        }
        private void rem_Btn_Click(object sender, EventArgs e)
        {
            int count = last_plotted.Count;
            if (count == 0) return;
            else
            {
                all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                last_plotted.Clear();
                frm2.recalc_frm9(count, last_plotted.Count);
            }
        }
        #endregion

        #region chemical formulas file
        private void load_chems_file_Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(multChem_min_charge.Text) ) { MessageBox.Show("You need to set first the charge range "); return; }
            string extension = extensionBox2.Text.ToString();
            if (!string.IsNullOrEmpty(extension)) { extension ="_"+ extension; }
            int chain_type = 0;
            bool ext_exists = true;
            if (mult_heavy_ChkBox.Checked && mult_Light_chkBox.Checked){ MessageBox.Show("Both heavy ald light chain are checked. Please select only one chain type."); return; }
            else if(mult_heavy_ChkBox.Checked) { chain_type = 1; }
            else if (mult_Light_chkBox.Checked) { chain_type = 2; }
            if (!string.IsNullOrEmpty(extension))
            {
                ext_exists = false;
                foreach (SequenceTab seq in frm2.sequenceList)
                {
                    if (seq.Extension.Equals(extension)) {ext_exists = true; break; }
                }
                extension = "_" + extension;
            }
            if (!ext_exists)
            {
                DialogResult dd = MessageBox.Show("There is no sequence for the extension type you have inserted." +
                    "If you want to stop the calcuations select 'No'. " +
                    "If you want to proceed with the calculations press 'Yes'", "Wrong Input", MessageBoxButtons.YesNo);
                if (dd == DialogResult.No || dd == DialogResult.None) { return; }
            }
            double qMin = txt_to_d(multChem_min_charge);
            if (double.IsNaN(qMin)) qMin = 1;
            double qMax = txt_to_d(multChem_max_charge);
            if (double.IsNaN(qMax)) qMax = qMin;
            OpenFileDialog multChems = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Title = "Load experimental data", FileName = "", Filter = "data file|*.txt|All files|*.*" };
            List<string> lista = new List<string>();
            if (multChems.ShowDialog() != DialogResult.Cancel)
            {
                sw1.Reset(); sw1.Start();
                StreamReader objReader = new StreamReader(multChems.FileName);
                filename_txtBx.Text = multChems.SafeFileName.Remove(multChems.SafeFileName.Length - 4).ToString();
                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');

                        for (int c = (int)qMin; c <= qMax; c++)
                        {
                            mult_loaded.Add(new ChemiForm()
                            {
                                Color = OxyColors.Orange,
                                InputFormula = tmp_str[0],
                                PrintFormula = tmp_str[0],
                                Adduct = string.Empty,
                                Deduct = string.Empty,
                                Multiplier = 1,
                                Mz = string.Empty,
                                Ion = "extra",
                                Index = string.Empty,
                                IndexTo = string.Empty,
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
                                Max_man_int = 0,
                                Ion_type = "extra",
                                Name = tmp_str[1]+extension,
                                Radio_label = string.Empty,
                                maxPPM_Error = 0,
                                minPPM_Error = 0,
                                Charge = c,
                                Chain_type=chain_type,
                                Extension=extension
                            });
                            mult_loaded.Last().Adduct = "H" + c.ToString();
                        }
                    }
                    catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); }

                }
            }
            else { return; }
            MessageBox.Show(mult_loaded.Count().ToString() + " chemical formulas have been added!");
        }
        private void multChem_min_charge_TextChanged(object sender, EventArgs e)
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

        private void multChem_max_charge_TextChanged(object sender, EventArgs e)
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

        private void clear_multiple_chem_Btn_Click(object sender, EventArgs e)
        {
            multChem_max_charge.Text = string.Empty;
            extensionBox2.Text = string.Empty;
            multChem_min_charge.Text = string.Empty;
            mult_heavy_ChkBox.Checked = false;
            mult_Light_chkBox.Checked = false;
            if (mult_loaded.Count != 0) { mult_loaded.Clear(); filename_txtBx.Text = string.Empty; }
        }


        #endregion

    }
}
