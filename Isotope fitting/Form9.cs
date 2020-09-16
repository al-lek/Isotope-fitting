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
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Form9 : Form
    {
        #region parameters
        Form2 frm2;
        bool has_adduct = false;
        string extra_adduct = "";
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
        bool is_in_calc_mode = false;
        bool help = false;
        int duplicates = 0;
        #endregion
        public Form9(Form2 f,bool h=false)
        {
            frm2 = f;
            help = h;
            InitializeComponent();
            OnCalcFrag3Completed += () => { Fragments3_to_listview(); };
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();
            initialize_calculator_UI();
            initialize_basic_selection__UI();
            initialize_riken_selection_UI();
            initialize_Fragment_List_UI();
            if (frm2.is_riken){FragCalc_TabControl.TabPages.Remove(chemForm_tab);FragCalc_TabControl.TabPages.Remove(Frag_tab);}
            else{FragCalc_TabControl.TabPages.Remove(fragTab_riken); FragCalc_TabControl.TabPages.Remove(chemForm_tab_riken); }
        }

        #region Initialisation
        private void Form9_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
        private void initialize_calculator_UI()
        {
            ppm9_numUD.MouseClick += (s, e) => { ppm9_numUD.Focus(); };
            ppm9_numUD.TextChanged += new EventHandler(ppm9_numUD_TextChanged);
            thre_numUD.TextChanged += new EventHandler(thre_numUD_TextChanged);
            ppm9_numUD.Value = (decimal)ppmError9;
            thre_numUD.Value = (decimal)thres9;
            one_rdBtn9.CheckedChanged += (s, e) => { selection_rule9[0] = one_rdBtn9.Checked; };
            two_rdBtn.CheckedChanged += (s, e) => { selection_rule9[1] = two_rdBtn.Checked; };
            three_rdBtn.CheckedChanged += (s, e) => { selection_rule9[2] = three_rdBtn.Checked; };
            half_rdBtn.CheckedChanged += (s, e) => { selection_rule9[3] = half_rdBtn.Checked; };
            half_minus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[4] = half_minus_rdBtn.Checked; };
            half_plus_rdBtn.CheckedChanged += (s, e) => { selection_rule9[5] = half_plus_rdBtn.Checked; };
            one_rdBtn9.Checked = selection_rule9[0];
            two_rdBtn.Checked = selection_rule9[1];
            three_rdBtn.Checked = selection_rule9[2];
            half_rdBtn.Checked = selection_rule9[3];
            half_minus_rdBtn.Checked = selection_rule9[4];
            half_plus_rdBtn.Checked = selection_rule9[5];
        }
        private void initialize_basic_selection__UI()
        {
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
            chargeMax_Box.MouseClick += (s, e) => { chargeMax_Box.Focus(); };
            chargeMin_Box.MouseClick += (s, e) => { chargeMin_Box.Focus(); };
            idxFrom_Box.MouseClick += (s, e) => { idxFrom_Box.Focus(); };
            idxPr_Box.MouseClick += (s, e) => { idxPr_Box.Focus(); };
            idxTo_Box.MouseClick += (s, e) => { idxTo_Box.Focus(); };
            mzMax_Box.MouseClick += (s, e) => { mzMax_Box.Focus(); };
            mzMin_Box.MouseClick += (s, e) => { mzMin_Box.Focus(); };
        }
        private void initialize_riken_selection_UI()
        {            
            a_lstBox_riken.MouseClick += (s, e) => { a_lstBox_riken.Focus(); };
            b_lstBox_riken.MouseClick += (s, e) => { b_lstBox_riken.Focus(); };
            c_lstBox_riken.MouseClick += (s, e) => { c_lstBox_riken.Focus(); };
            d_lstBox_riken.MouseClick += (s, e) => { c_lstBox_riken.Focus(); };
            w_lstBox_riken.MouseClick += (s, e) => { c_lstBox_riken.Focus(); };
            x_lstBox_riken.MouseClick += (s, e) => { x_lstBox_riken.Focus(); };
            y_lstBox_riken.MouseClick += (s, e) => { y_lstBox_riken.Focus(); };
            z_lstBox_riken.MouseClick += (s, e) => { z_lstBox_riken.Focus(); };
            M_lstBox_riken.MouseClick += (s, e) => { M_lstBox_riken.Focus(); };
            known_lstBox.MouseClick += (s, e) => { known_lstBox.Focus(); };
            internal_lstBox_riken.MouseClick += (s, e) => { internal_lstBox_riken.Focus(); };
            chargeMax_Box_riken.MouseClick += (s, e) => { chargeMax_Box_riken.Focus(); };
            chargeMin_Box_riken.MouseClick += (s, e) => { chargeMin_Box_riken.Focus(); };
            idxFrom_Box_riken.MouseClick += (s, e) => { idxFrom_Box_riken.Focus(); };
            idxPr_Box_riken.MouseClick += (s, e) => { idxPr_Box_riken.Focus(); };
            idxTo_Box_riken.MouseClick += (s, e) => { idxTo_Box_riken.Focus(); };
            mzMax_Box_riken.MouseClick += (s, e) => { mzMax_Box_riken.Focus(); };
            mzMin_Box_riken.MouseClick += (s, e) => { mzMin_Box_riken.Focus(); };
        }
        private void initialize_Fragment_List_UI()
        {
            ContextMenu ctxMn1 = new ContextMenu() { };
            MenuItem colorSelection = new MenuItem("Fragment color", colorSelectionList);
            MenuItem remFrag = new MenuItem("Remove fragment", delete_frag);
            MenuItem clearall = new MenuItem("Clear all", delete_all);
            MenuItem copy_frag = new MenuItem("Copy fragment", copy_fragment);
            MenuItem zoom_frag = new MenuItem("Zoom to fragment", zoom_to_fragment);           

            ctxMn1.MenuItems.AddRange(new MenuItem[] { zoom_frag, copy_frag, colorSelection, remFrag, clearall  });
            fragListView9.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn1; } };
        }
        #endregion

        #region UI
        #region calc UI     
        void ppm9_numUD_TextChanged(object sender, EventArgs e)
        {
            if (ppm9_numUD.ActiveControl != null && !string.IsNullOrEmpty(ppm9_numUD.ActiveControl.Text))
            {
                try
                {
                    ppmError9 = double.Parse(ppm9_numUD.ActiveControl.Text);
                }
                catch
                {
                    MessageBox.Show("Oops you have inserted a wrong format. Please try again!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
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
        void thre_numUD_TextChanged(object sender, EventArgs e)
        {
            if (thre_numUD.ActiveControl != null && !string.IsNullOrEmpty(thre_numUD.ActiveControl.Text))
            {
                thres9 = Double.Parse(thre_numUD.ActiveControl.Text);
            }
        }
        #endregion

        #region basic tabs UI
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
        private void clear_allBtn_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(Frag_tab);
            set_textboxes_checks_empty(Frag_tab);
        }
        private void check_all_boxBtn_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(Frag_tab, true);
        }

        private void uncheck_all_boxBtn_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(Frag_tab);
        }

        private void minCharge_txtBox_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(minCharge_txtBox, true, true);
        }

        private void maxCharge_txtBox_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(maxCharge_txtBox, true, true);
        }

        private void internal_txtBox_TextChanged(object sender, EventArgs e)
        {
            primary_txtBox.Text = null;
        }
        private void primary_txtBox_TextChanged(object sender, EventArgs e)
        {
            internal_txtBox.Text = null;
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
        #endregion

        #region riken tabs UI
        private void check_all_boxBtn_riken_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(fragTab_riken, true);
        }
        private void uncheck_all_boxBtn_riken_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(fragTab_riken, false);
        }
        private void clear_allBtn_riken_Click(object sender, EventArgs e)
        {
            un_check_all_checkboxes_ListBx(fragTab_riken, false);
            set_textboxes_checks_empty(fragTab_riken);
        }

        private void mzMin_Box_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(mzMin_Box_riken, false, false);
        }

        private void mzMax_Box_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(mzMax_Box_riken, false, false);
        }

        private void chargeMin_Box_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(chargeMin_Box_riken, true, true);
        }

        private void chargeMax_Box_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(chargeMax_Box_riken, true, true);
        }

        private void chargeAll_Btn_riken_Click(object sender, EventArgs e)
        {
            chargeMin_Box_riken.Text = string.Empty;
            chargeMax_Box_riken.Text = string.Empty;
        }
        private void minCharge_txtBox_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(minCharge_txtBox_riken, true, true);
        }

        private void maxCharge_txtBox_riken_TextChanged(object sender, EventArgs e)
        {
            check_textBox_entry(maxCharge_txtBox_riken, true, true);
        }

        private void clear_single_chem_Btn_riken_Click(object sender, EventArgs e)
        {
            set_textboxes_checks_empty(chemForm_tab_riken);
        }
        private void AdductBtn_CheckedChanged(object sender, EventArgs e)
        {
            adduct_txtBx.Enabled = AdductBtn.Checked;

        }
        #endregion
        
        #region help
        private void chemForm_Lbl_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Set chemical formula. Formulas are case sensitive and contain only letters, numbers and square brackets(for the individual isotopes)." +
        " No space characters,pseudoelements, peptide or amino-acid codes are are accepted.    ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void chemFormula_charge_Lbl_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set the charge range for which each chemical formula will be calculated.  Use minus sign for a negative charge. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

        }

        private void chem_ion_Lbl_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set the ion type of the fragment. Space characters are not accepted.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void chem_index_Lbl_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void ignore_ppm_form9_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("During calculation a ppm filter is applied to refine the list from fragments whose most abundant centroid differs from the nearest experimental peak " +
                    "by ppm larger than the user-specified bound maximum ppm. This filter distinguishes the candidate fragments from the incorrect.  " +
                    "\r\nWhen 'ignore ppm' is checked the fragments that are out of ppm bounds are displayed to the user in red color. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void ppm9_Lbl_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Indicates the maximum ppm error that a fragment can have in order to be inserted to Fragment List.\r\n" +
                    "During calculation a ppm filter is applied to refine the list from fragments whose most abundant centroid differs from the nearest experimental peak " +
           "by ppm larger than the user-specified bound maximum ppm. This filter distinguishes the candidate fragments from the incorrect." +
           " Ere initiating the calculation process the user can select from the 'Filter' panel, the desired maximum ppm error and customize" +
                "its application method. For instance, if the user selects the '2 most intense' option, the fragments " +
                "whose 2 most intense centroids are within the ppm bounds pass the filter. On the other hand, " +
                "if the user selects the 'half most intense' option, fragments whose half" +
                "of the most intense centroids are within the ppm bounds pass the filter.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void res_label1_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set a custom resolution value for the fragments that are not within ppm error.\r\n(applied only when 'ignore ppm' is checked)  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void extension_label9_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Set the extension and the chain type of the corresponding sequence, if there are any.\r\n\r\n" +
                   "Peak Finder supports multiple sequences processing.\r\nIn order to succeed the distinction of the fragments of the different sequences from each other,\r\nan extension is defined for each sequence. This extension is added to the fragment name.\r\nFor the General Sequence no extension is defined.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void extension_rik_label23_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Set the extension of the corresponding sequence, if there is any.\r\n\r\n" +
                              "Peak Finder supports multiple sequences processing.\r\nIn order to succeed the distinction of the fragments of the different sequences from each other,\r\nan extension is defined for each sequence. This extension is added to the fragment name.\r\nFor the General Sequence no extension is defined.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void mz_Label_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set the m/z range condition to be met when selecting the fragments for calculation. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void charge_Label_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Set the charge range condition to be met when selecting the fragments for calculation.  Use minus sign for a negative charge. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void Index_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Set the index range condition to be met when selecting the fragments for calculation. " +
        "When the checkbox is checked: the index of w, x, y, z is counted as for the a, b, c, d fragments.   ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        private void sortIdx_chkBx_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("When checked: the index of w, x, y, z is counted as for the a, b, c, d fragments.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (help)
            {
                MessageBox.Show("Minimum abundance of isotope pattern peaks to be retained during calculation,\r\n" +
                "given as a percentageof the most abundant peak.\r\nWarning:\r\n(1)Omitting too abundant peaks may distort the profile shape.\r\n(2)Including too many peaks may lead to computational problems for very large molecules.\r\n" +
                "Set to 0 to calculate all possible isotope pattern peaks.\r\n(From Envipat website)\r\nFor large molecule it is suggested to set to 1.00 in order to minimize the calculation time.\r\nDefault:0.01" +
                "", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, "https://www.envipat.eawag.ch/", "keyword");
                return;
            }
        }
        #endregion

        #endregion

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
            selected_idx = 0;
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
                Location = new Point(factor_panel9.Width-65, 7),
                Size = new Size(60, 20),TabIndex=0,
                Anchor =AnchorStyles.Right|AnchorStyles.Top
            };
            numUD.ValueChanged += (s, e) =>
            {
                if (frm2.is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
                // manualy adjust height. We have also to maualy call refresh plot
                Fragments3[selected_idx].Factor = Convert.ToDouble(numUD.Value) / Fragments3[selected_idx].Max_intensity;
                frm2.external_refresh_isoplot();
            };
            numUD.Focus();           
            //ensure that the focus is mainly on numeric up down box in the factor_panel9 
            //that way when the user clicks a fragment from the listview the focus is not on the listview but on the numeric up down
            //and can control height of the fragment instantly from the buttons "up" "down"
            //numUD.Leave += (s, e) => { if (!panel_calc.Focused) { numUD.Focus(); } };
             factor_panel9.Controls.AddRange(new Control[] { factor_lbl, numUD });
            //factor_panel9.Controls.OfType<NumericUpDown>().ToArray()[0].Focus();
        }

        private void delete_all(object sender, EventArgs e)
        {
            if (frm2.is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            during_calc(true);
            int count = last_plotted.Count;
            if ((sender as MenuItem).Text == "Clear all")
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
                factor_panel9.Visible = false;
            }
            during_calc(false);
        }
        private void delete_frag(object sender, EventArgs e)
        {
            if (frm2.is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            int count_last_plotted = last_plotted.Count;
            if (fragListView9.SelectedIndices.Count == 0) { MessageBox.Show("First select the fragment and then press delete!"); return; }
            during_calc(true);
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            if ((sender as MenuItem).Text == "Remove fragment" && selectedItems.Count > 0)
            {
                now = false;
                int count = 0;
                foreach (ListViewItem item in fragListView9.SelectedItems)
                {
                    int frag_idx = System.Convert.ToInt32(item.SubItems[5].Text);
                    //remove fragment from the current listview
                    Fragments3.RemoveAt(frag_idx - count); count++;
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
            during_calc(false);
            plot_checked(true, count_last_plotted);
        }
        private void colorSelectionList(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            if ((sender as MenuItem).Text == "Fragment color" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in fragListView9.SelectedItems)
                {
                    int frag_idx = System.Convert.ToInt32(item.SubItems[5].Text);
                    ColorDialog clrDlg = new ColorDialog();
                    if (clrDlg.ShowDialog() == DialogResult.OK) { Fragments3[frag_idx].Color = OxyColor.FromUInt32((uint)clrDlg.Color.ToArgb()); }
                }
            }
        }
        private void copy_fragment(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            StringBuilder sb = new StringBuilder();
            if ((sender as MenuItem).Text == "Copy fragment" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in fragListView9.SelectedItems)
                {
                    int i = System.Convert.ToInt32(item.SubItems[5].Text);                    
                    if (Fragments3[i].Name.Contains("intern") || Fragments3[i].Ion_type.Contains("intern"))
                        sb.AppendLine(Fragments3[i].Name + "\t" + Fragments3[i].Index + "\t" + Fragments3[i].IndexTo + "\t" + Fragments3[i].Charge.ToString() + "\t" + Fragments3[i].Mz + "\t" + Fragments3[i].InputFormula +
                                                    "\t" + Fragments3[i].PPM_Error.ToString("0.##") + "\t" + (Fragments3[i].Factor * Fragments3[i].Max_intensity).ToString("0"));
                    else
                        sb.AppendLine(Fragments3[i].Name + "\t" + Fragments3[i].Index + "\t" + Fragments3[i].Charge.ToString() + "\t" + Fragments3[i].Mz + "\t" + Fragments3[i].InputFormula +
                                                    "\t" + Fragments3[i].PPM_Error.ToString("0.##") + "\t" + (Fragments3[i].Factor * Fragments3[i].Max_intensity).ToString("0"));
                }
                Clipboard.Clear();
                if (sb != null && sb.Length > 0) Clipboard.SetText(sb.ToString());
            }
           
        }
        private void zoom_to_fragment(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = fragListView9.SelectedItems;
            if ((sender as MenuItem).Text == "Zoom to fragment" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in fragListView9.SelectedItems)
                {
                    int i = System.Convert.ToInt32(item.SubItems[5].Text);
                    double max_x =Fragments3[i].Profile.Last().X;
                    double min_x =Fragments3[i].Profile[0].X;
                    frm2.zoom_to_frag_frm9(min_x, max_x);
                }                
            }

        }
        private void initialize_data()
        {
            if (Fragments3.Count > 0) Fragments3.Clear();
            first = true; now = false; selected_idx = 0;
        }

        #endregion

        #region isotopic distributions calculations
        private void calc_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Initiates the calculation procedure:\r\nfor each of the loaded fragments, the algorithm checks whether they possess " +
                "the desired properties and selects the candidates. Following the selected fragments' “enviPat” properties profile calculation, if 'ignore ppm'" +
                " is not checked a filter is applied to refine the list from fragments whose most abundant centroid differs from the nearest experimental peak " +
                "by ppm larger than the user-specified bound maximum ppm. This filter distinguishes the candidate fragments from the incorrect.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            calc_Btn.Enabled = false;
            duplicates = 0;
            if (frm2.is_frag_calc_recalc || is_in_calc_mode) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); calc_Btn.Enabled = true; return; }
            Remove_plotted();
            during_calc(true);
            if (Fragments3.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Clear List before proceeding with calculation?", "Fragment Calculator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);           
                if (dialogResult == DialogResult.Cancel) { during_calc(false); calc_Btn.Enabled = true; return; }
                if (dialogResult == DialogResult.Yes) { Fragments3.Clear(); Fragments3_to_listview(); }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Proceed with calculation?", "Fragment Calculator", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.OK) { during_calc(false); calc_Btn.Enabled = true; return; }              
            }
            factor_panel9.Visible = false;
            calc_Btn.Enabled = true;
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
            if (frm2.is_riken)
            {
                if (FragCalc_TabControl.SelectedTab == FragCalc_TabControl.TabPages["chemForm_tab_riken"])
                {
                    if ((string.IsNullOrEmpty(minCharge_txtBox_riken.Text) && string.IsNullOrEmpty(maxCharge_txtBox_riken.Text)) || string.IsNullOrEmpty(ion_txtBox_riken.Text)) { MessageBox.Show("You must first set the charge range and the ion type or name of the fragment for this action.", "Chemical Formula Calculation"); during_calc(false); return; }
                    else { selected_fragments = check_chem_inputs_riken(); }
                }
                else
                {
                    if (ChemFormulas == null || ChemFormulas.Count == 0) { MessageBox.Show("You must first load an Riken file for this action."); during_calc(false); return; }
                    selected_fragments = select_fragments2_frm9_riken();
                }                    
            }
            else
            {
                if (FragCalc_TabControl.SelectedTab == FragCalc_TabControl.TabPages["Frag_tab"])
                {
                    if (ChemFormulas == null || ChemFormulas.Count == 0) { MessageBox.Show("You must first load an MS Product file for this action."); during_calc(false); return; }
                    selected_fragments = select_fragments2_frm9();
                }
                else if (mult_loaded != null && mult_loaded.Count > 0)
                {
                    selected_fragments = mult_loaded;
                }
                else if ((string.IsNullOrEmpty(minCharge_txtBox.Text) && string.IsNullOrEmpty(maxCharge_txtBox.Text)) || string.IsNullOrEmpty(ion_txtBox.Text)) { MessageBox.Show("You must first set the charge range and the ion type or name of the fragment for this action.", "Chemical Formula Calculation"); during_calc(false); return; }
                else { selected_fragments = check_chem_inputs(); }
            }           

            if (selected_fragments.Count == 0) { MessageBox.Show("No fragments found"); during_calc(false); return; } 
            if(selected_fragments.Count>1000)
            {
                DialogResult dialogResult = MessageBox.Show("The Selected fragments are " + selected_fragments.Count.ToString() + ". Are you sure you want to proceed with calculation?", "Fragment Calculator", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.OK) { during_calc(false); return; }
            }
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            calculate_fragments_resolution_frm9(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments3.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties_frm9(selected_fragments));
            envipat_properties.Start();
        } 
        private void during_calc(bool set=true)
        {
             is_in_calc_mode = set;
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
            if (heavy_ChkBox.Checked && Light_chkBox.Checked) { MessageBox.Show("Oops..Both heavy and light chain are checked. Please select only one chain type."); return res; }
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
                DialogResult dd = MessageBox.Show("There is no sequence for the extension type you have inserted." , "Wrong Input", MessageBoxButtons.OK);
                 return res; 
            }
            if (ion_txtBox.Text.Contains("M"))
            {
                if (!ext_exists && string.IsNullOrEmpty(internal_txtBox.Text))
                {
                    DialogResult dd= MessageBox.Show("There is no sequence for the extension type you have inserted." +
                        " This will affect the index numbers for the precursor ion you have inserted." +
                        "If you want to stop the calcuations and insert the correct indexes in the internal indexes section select 'Cancel'. " +
                        "If you want to proceed with the calculations press 'Ok'","Wrong Input",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dd!=DialogResult.OK) { return res; }                   
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
            else if(string.IsNullOrEmpty(index))
            {
                DialogResult dd = MessageBox.Show("Hmm, its seems that you have not inserted an index. The calculations will proceed as for index=0" +
                    "If you want to proceed with the calculations press 'Ok', otherwise select 'Cancel'. ", "Wrong Input", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dd != DialogResult.OK) { return res; }
                index = "0"; indexTo = "0";
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
                    Chain_type=chain_type,
                    maxFactor=0.0
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
                else if (res.Last().Ion.Contains("internal")) res.Last().Color = OxyColors.DarkViolet;
                else if (res.Last().Ion.StartsWith("M")) res.Last().Color = OxyColors.DarkRed;
                else res.Last().Color = OxyColors.Orange;

                string lbl = "";
                if (res.Last().Ion.Contains("internal"))
                {                   
                    lbl = res.Last().Ion + "[" + res.Last().Index + "-" + res.Last().IndexTo + "]";                    
                }
                else if (res.Last().Ion_type.StartsWith("M"))
                {
                    lbl =ion;                    
                }
                else
                {
                    if (res.Last().Ion_type.Length == 1) { lbl = res.Last().Ion_type + res.Last().Index; }
                    else { lbl = "(" + res.Last().Ion_type + ")" + res.Last().Index; }                                     
                }
                res.Last().Radio_label = lbl + extension;
                if (c > 0) res.Last().Name = lbl + "_" +c.ToString() + "+" + extension;
                else if (c < 0) res.Last().Name = lbl + "_" + Math.Abs(c).ToString() + "-"+extension;
                else res.Last().Name = lbl + "_" + c.ToString() +  extension;

                if (res.Last().Ion.StartsWith("w") || res.Last().Ion.StartsWith("v") || res.Last().Ion.StartsWith("x") || res.Last().Ion.StartsWith("y") || res.Last().Ion.StartsWith("z") || res.Last().Ion.StartsWith("(x") || res.Last().Ion.StartsWith("(y") || res.Last().Ion.StartsWith("(z") || res.Last().Ion.StartsWith("(v") || res.Last().Ion.StartsWith("(w"))
                {
                    res.Last().SortIdx = s.Length - Int32.Parse(res.Last().Index);
                }
                else
                {
                    res.Last().SortIdx = Int32.Parse(res.Last().Index);
                }
            }
            return res;
        }
        private List<ChemiForm> check_chem_inputs_riken()
        {
            List<string> other_frag_types = new List<string> { "acp3Y", "dRp" };
            List<ChemiForm> res = new List<ChemiForm>();
            bool ext_exists = true;
            string chem_form = string.Empty;
            List<int> charge = new List<int>();
            string ion = string.Empty;
            string ion_type = string.Empty;
            string s = frm2.Peptide;
            string extension = extensionBox1_riken.Text.ToString();
            string Index = "0";
            string IndexTo = "0";
            int sortIdx = 0;
            int chain_type = 0;
            OxyColor clr = OxyColors.Orange; 
            if (!string.IsNullOrEmpty(extension))
            {
                ext_exists = false;
                foreach (SequenceTab seq in frm2.sequenceList)
                {
                    if (seq.Extension.Equals(extension)) { s = seq.Sequence; ext_exists = true; break; }
                }
                extension = "_" + extension;
            }
            if (!ext_exists)
            {
                DialogResult dd = MessageBox.Show("There is no sequence for the extension type you have inserted.", "Wrong Input", MessageBoxButtons.OK);
                return res;
            }
            chem_form = chemForm_txtBox_riken.Text.Replace(Environment.NewLine, " ").ToString();
            chem_form = chem_form.Replace("\t", "");
            chem_form = chem_form.Replace(" ", "");
            ion = ion_txtBox_riken.Text.Replace(Environment.NewLine, " ").ToString();
            ion = ion.Replace("\t", "");
            ion = ion.Replace(" ", "");     
            double qMin = txt_to_d(minCharge_txtBox_riken);
            if (double.IsNaN(qMin)) qMin = 1;
            double qMax = txt_to_d(maxCharge_txtBox_riken);
            if (double.IsNaN(qMax)) qMax = qMin;
            string[] substring = ion.Split('-');
            if (char.IsLower(ion[0]))
            {
                // normal fragment
                bool primary_present = false;
                if (ion.StartsWith("a") && !ion.StartsWith("acp3Y")) { clr = OxyColors.Green; primary_present = true; }
                else if (ion.StartsWith("b")) { clr = OxyColors.Blue; primary_present = true; }
                else if (ion.StartsWith("c")) { clr = OxyColors.Firebrick; primary_present = true; }
                else if (ion.StartsWith("d") && !ion.StartsWith("dRp")) { clr = OxyColors.DeepPink; primary_present = true; }
                else if (ion.StartsWith("w")) { clr = OxyColors.LimeGreen; primary_present = true; }
                else if (ion.StartsWith("x")) { clr = OxyColors.DodgerBlue; primary_present = true; }
                else if (ion.StartsWith("y")) { clr = OxyColors.Tomato; primary_present = true; }
                else if (ion.StartsWith("z")) { clr = OxyColors.HotPink; primary_present = true; }
                else clr = OxyColors.Orange;
                if (primary_present && (substring.Length == 1 || (substring.Length == 2 && substring[1].StartsWith("B("))))
                {
                    ion_type = substring[0][0].ToString();
                    bool is_number = Int32.TryParse(substring[0].Remove(0, 1), out int index);
                    if (is_number)
                    {
                        Index = index.ToString();
                        if (ion.StartsWith("w") || ion.StartsWith("x") || ion.StartsWith("y") || ion.StartsWith("z") || ion.StartsWith("(w") || ion.StartsWith("(x") || ion.StartsWith("(y") || ion.StartsWith("(z"))
                        {
                            sortIdx = s.Length - index;
                        }
                        else
                        {
                            sortIdx = index;
                        }
                        IndexTo = Index;
                    }
                    else
                    {
                        MessageBox.Show("Error with fragment " + ion + ".No index found. ");
                        return res;
                    }

                    for (int c = 1; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                }
                else if (primary_present)
                {
                    clr = OxyColors.Violet;
                    ion_type = "internal";
                    int[] index_values = new int[2];
                    for (int c = 0; c < 2; c++)
                    {
                        bool is_number = Int32.TryParse(substring[c].Remove(0, 1), out int index);
                        if (is_number)
                        {
                            index_values[c] = index;
                            if (substring[c].StartsWith("w") || substring[c].StartsWith("x") || substring[c].StartsWith("y") || substring[c].StartsWith("z") || substring[c].StartsWith("(w") || substring[c].StartsWith("(x") || substring[c].StartsWith("(y") || substring[c].StartsWith("(z"))
                            {
                                index_values[c] = (s.Length - index_values[c]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error with fragment " + ion + ".No index found. ");
                            return res;
                        }
                    }
                    sortIdx = index_values[0];
                    Index = index_values[0].ToString();
                    IndexTo = index_values[1].ToString();
                    for (int c = 2; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                }
                else
                {
                    ion_type = "known MS2";
                    sortIdx = 0;
                    Index = "0";
                    IndexTo = "0";
                    for (int c = 1; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                }
            }
            else if (ion.StartsWith("B("))//base fragments are not followed by losses ex B(G) or B(m7G)
            {
                string sub = ion.Substring(2, ion.Length - 2);
                ion_type = "B()";
                clr = OxyColors.DarkSalmon;
                sortIdx = 0;
                Index = "0";
                IndexTo = "0";
            }
            else
            {
                if (substring[0].StartsWith("M") && c_is_precursor(chem_form))
                {
                    ion_type = "M";
                    clr = OxyColors.DarkRed;
                    sortIdx = 0;
                    Index = "0";
                    IndexTo = (s.Length - 1).ToString();
                }
                else
                {
                    ion_type = "known MS2";
                    clr = OxyColors.Orange;
                    sortIdx = 0;
                    Index = "0";
                    IndexTo = "0";

                }
                for (int c = 1; c < substring.Length; c++)
                {
                    if (substring[c].StartsWith("B")) ion_type += "-B()";
                    else ion_type += "-" + substring[c];
                }
            }
            for (int c = (int)qMin; c <= qMax; c++)
            {
                res.Add(new ChemiForm
                {
                    InputFormula = chem_form,
                    Adduct = string.Empty,
                    Deduct = string.Empty,
                    Multiplier = 1,
                    Mz = string.Empty,
                    Ion = ion,
                    Index = Index,
                    IndexTo = IndexTo,
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
                    Charge = c,
                    Ion_type = ion_type,
                    Extension = extension,
                    Chain_type = chain_type,
                    Color=clr,
                    SortIdx=sortIdx,
                    maxFactor=0.0
                });
                string lbl = "";
                lbl = ion;
                res.Last().Radio_label = lbl + extension;
                //res.Last().InputFormula= res.Last().PrintFormula= fix_formula(chem_form, true, res.Last().Charge);
                if (c > 0)
                {
                    res.Last().Adduct = "H" + c.ToString();
                    res.Last().Name = lbl + "_" + res.Last().Charge.ToString() + "+" + extension;
                }
                else if(c < 0)
                {
                    res.Last().Deduct = "H" + Math.Abs(c).ToString();
                    res.Last().Name = lbl + "_" + Math.Abs(c).ToString() + "-" + extension;
                }
                else
                {
                    res.Last().Name = lbl + "_" + c.ToString() +  extension;
                }
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
            foreach (CheckedListBox lstBox in GetControls(Frag_tab).OfType<CheckedListBox>().Where(l => l.TabIndex < 20))
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
                double range = 0;
                if (is_primary) range = 2* 1.007825/ curr_q;
                // drop frag by mz and charge rules
                if (curr_mz < mzMin - range || curr_mz > mzMax+ range || curr_q < qMin || curr_q > qMax) continue;

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
                    int index1 = chem.SortIdx;
                    if (sortIdx_chkBx.Checked) { index1 = Int32.Parse(chem.Index); }                    
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
                    if (types_primary.Contains(curr_type)&& curr_mz >= mzMin && curr_mz <= mzMax) res.Add(chem.DeepCopy());                   

                    // this code is only for MSProduct that does not provide primary with H gain/loss by default.
                    // Whenever a primary is detected, we have to check if Hydrogen adducts or losses are requested and GENERATE ions (i.e y-2) respective ions
                    if (types_primary_Hyd.Any(t => t.StartsWith(curr_type)))
                    {
                        foreach (string hyd_mod in types_primary_Hyd.Where(t => t.StartsWith(curr_type)))
                        {
                            double hyd_num = 0.0;
                            if (hyd_mod.Contains('+')) hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('+')));
                            else hyd_num = Convert.ToDouble(hyd_mod.Substring(hyd_mod.IndexOf('-')));
                            double mz = Math.Round(curr_mz + hyd_num * 1.007825 / curr_q, 4);
                            // add the primary and modify it according to gain or loss of H
                            if (mz >= mzMin && mz <= mzMax)
                            {
                                res.Add(chem.DeepCopy());
                                int curr_idx = res.Count - 1;
                                bool is_error = false;
                                string new_type = "(" + hyd_mod + ")";
                                res[curr_idx].Ion_type = new_type;
                                res[curr_idx].Radio_label = new_type + res[curr_idx].Radio_label.Remove(0, 1);
                                res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);
                                res[curr_idx].Mz = mz.ToString();
                                res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error, res[curr_idx].InputFormula, true, (int)hyd_num);
                                if (is_error) { MessageBox.Show("Error with fragment " + res[curr_idx].Ion + ",with m/z " + res[curr_idx].Mz + " . Don't worry the remaining calculations will continue normally."); res.RemoveAt(curr_idx); }
                            }
                        }
                    }
                }
            }
            return res;
        }       
        
        private List<ChemiForm> select_fragments2_frm9_riken()
        {
            has_adduct = AdductBtn.Checked;
            bool add = true;
            bool extra_mz_error = false;
            double extra_mz = 0;
            string extra_name = "";
            if (has_adduct)
            {
                extra_adduct = adduct_txtBx.Text.Replace(Environment.NewLine, " ").ToString();
                extra_adduct = extra_adduct.Replace("\t", "");
                extra_adduct = extra_adduct.Replace(" ", "");
                if (String.IsNullOrEmpty(extra_adduct)) { has_adduct = false; AdductBtn.Checked = false; noAddBtn.Checked = true; }
                else
                {
                    if ( extra_adduct[0].Equals('-')) { extra_adduct = extra_adduct.Remove(0, 1); add = false; }
                    if (extra_adduct[0].Equals('+')) { extra_adduct = extra_adduct.Remove(0, 1); add = true; }                    
                }
                extra_name = extra_adduct.ToString();
                if (extra_adduct.Contains("B(A)")) { extra_adduct = extra_adduct.Replace("B(A)", "C5H5N5"); }
                else if (extra_adduct.Contains("B(G)")) { extra_adduct = extra_adduct.Replace("B(G)", "C5H5N5O1"); }
                else if (extra_adduct.Contains("B(T)")) { extra_adduct = extra_adduct.Replace("B(T)", "C5H6N2O2"); }
            }   
            List<ChemiForm> res = new List<ChemiForm>();
            if (has_adduct) extra_mz = calc_m(out extra_mz_error, extra_adduct);
            if (extra_mz_error) { MessageBox.Show("Adduct chemical is not in the correct format", "Error"); return res; }
            if (has_adduct && !add) { extra_mz= - extra_mz; }
            List<string> primary = new List<string> { "a", "b", "c", "d", "x", "y", "z", "w" };
            //other types are M, internal and known MS2
            // 1. get mz and charge limits (if any)
            double mzMin = txt_to_d(mzMin_Box_riken);
            if (double.IsNaN(mzMin)) mzMin = dParser(ChemFormulas.First().Mz);

            double mzMax = txt_to_d(mzMax_Box_riken);
            if (double.IsNaN(mzMax)) mzMax = dParser(ChemFormulas.Last().Mz);

            double qMin = txt_to_d(chargeMin_Box_riken);
            if (double.IsNaN(qMin)) qMin = -100.0;

            double qMax = txt_to_d(chargeMax_Box_riken);
            if (double.IsNaN(qMax)) qMax = 100.0;
          

            if (frm2.is_exp_deconvoluted) { qMin = -1; qMax = 1; }
            // 2. get checked types
            List<string> types = new List<string>();
            foreach (CheckedListBox lstBox in GetControls(fragTab_riken).OfType<CheckedListBox>())
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
            if (!string.IsNullOrEmpty(idxPr_Box_riken.Text.ToString())) add_to_indexes_list(idxPr_Box_riken.Text, primary_indexes);

            //5. index internal
            List<int[]> internal_indexesFrom = new List<int[]>();
            List<int[]> internal_indexesTo = new List<int[]>();
            if (!string.IsNullOrEmpty(idxFrom_Box_riken.Text.ToString())) add_to_indexes_list(idxFrom_Box_riken.Text, internal_indexesFrom);
            if (!string.IsNullOrEmpty(idxTo_Box_riken.Text.ToString())) add_to_indexes_list(idxTo_Box_riken.Text, internal_indexesTo);
            if (internal_indexesTo.Count != internal_indexesFrom.Count)
            {
                MessageBox.Show("Wrong format in internal indexes"); internal_indexesTo.Clear(); internal_indexesFrom.Clear();
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
                bool is_B = curr_type.StartsWith("B(");
                double range = 0;
                if (is_primary && types_primary_Hyd.Count > 0) range = 2 * 1.007825 / Math.Abs(curr_q);
                if (is_primary && types_primary_H2O.Count > 0) range = 19 / Math.Abs(curr_q);
                double extra_mz_temp = extra_mz / Math.Abs(curr_q);
                // drop frag by mz and charge rules
                if (curr_mz+ extra_mz_temp < mzMin- range || curr_mz + extra_mz_temp > mzMax+range || curr_q < qMin || curr_q > qMax) continue;
                
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
                else if (!is_precursor && !is_known_MS2 && !is_B && primary_indexes.Count > 0)
                {
                    int index1 = chem.SortIdx;
                    bool in_bounds=false;
                    if (sortIdx_chkBx_riken.Checked) { index1 = Int32.Parse(chem.Index); }
                    for (int k = 0; k < primary_indexes.Count; k++)
                    {
                        if (index1 >= primary_indexes[k][0] && index1 <= primary_indexes[k][1])
                        {
                            in_bounds = true; break;
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
                            check_adduct(chem, add, res, extra_name, true);
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
                            check_adduct(chem, add, res, extra_name, true);
                        }
                        else { res.Add(chem.DeepCopy()); }
                    }
                    continue;
                }
                if (is_B)
                {
                    if (types_B.Contains(curr_type))
                    {
                        if (has_adduct)
                        {
                            check_adduct(chem, add, res, extra_name, true);
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
                            check_adduct(chem, add, res, extra_name, true);
                        }
                        else { res.Add(chem.DeepCopy()); }
                    }
                    continue;
                }
                if (is_known_MS2)
                {
                    if (types_known_MS2.Contains(curr_type))
                    {
                        if (has_adduct)
                        {
                            check_adduct(chem, add, res, extra_name, true);
                        }
                        else { res.Add(chem.DeepCopy()); }
                    }
                    continue;
                }
                if (is_primary)
                {
                    if (types_primary.Contains(curr_type) && curr_mz + extra_mz_temp >= mzMin && curr_mz + extra_mz_temp <= mzMax)
                    {
                        if (has_adduct)
                        {
                            check_adduct(chem, add, res, extra_name, true);
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
                            if (mz + extra_mz_temp >= mzMin && mz + extra_mz_temp <= mzMax)
                            {
                                // add the primary and modify it according to gain or loss of H
                                if (has_adduct)
                                {
                                    is_error = check_adduct(chem, add, res, extra_name);
                                }
                                else { res.Add(chem.DeepCopy()); }
                                if (is_error) continue;
                                int curr_idx = res.Count - 1;

                                string new_type = "(" + hyd_mod;
                                if (has_adduct)
                                {
                                    if (add) { new_type += "+" + extra_name; }
                                    else { new_type += "-" + extra_name; }
                                }
                                new_type += ")";
                                res[curr_idx].Ion_type = new_type;
                                res[curr_idx].Radio_label = new_type + res[curr_idx].Radio_label.Remove(0, 1);
                                res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);
                                res[curr_idx].Has_adduct = has_adduct;
                                if (extra_name.Equals("B(A)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(A)", "B()"); }
                                else if (extra_name.Equals("B(G)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(G)", "B()"); }
                                else if (extra_name.Equals("B(T)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(T)", "B()"); }
                                res[curr_idx].Mz = mz.ToString();
                                res[curr_idx].PrintFormula = res[curr_idx].InputFormula = fix_formula(out is_error, res[curr_idx].InputFormula, true, (int)hyd_num);

                                if (is_error) { MessageBox.Show("Error with fragment " + res[curr_idx].Ion + ",with m/z " + res[curr_idx].Mz + " . Don't worry the remaining calculations will continue normally."); res.RemoveAt(curr_idx); }

                            }
                        }
                    }
                    if (types_primary_H2O.Any(t => t.StartsWith(curr_type)))
                    {
                        foreach (string hyd_mod in types_primary_H2O.Where(t => t.StartsWith(curr_type)))
                        {
                            bool is_error = false;
                            // add the primary and modify it according to gain or loss of H2O
                            double mz;
                            if (hyd_mod.Contains('+')) mz = Math.Round(curr_mz + 18.01056468 / Math.Abs(curr_q), 4);
                            else mz = Math.Round(curr_mz - 18.01056468 / Math.Abs(curr_q), 4);
                            if (mz + extra_mz_temp >= mzMin && mz + extra_mz_temp <= mzMax)
                            {
                                if (has_adduct)
                                {
                                    is_error = check_adduct(chem, add, res, extra_name);
                                }
                                else { res.Add(chem.DeepCopy()); }
                                if (is_error) continue;

                                int curr_idx = res.Count - 1;
                                string new_type = "(" + hyd_mod;
                                if (has_adduct)
                                {
                                    if (add) { new_type += "+" + extra_name; }
                                    else { new_type += "-" + extra_name; }
                                }
                                new_type += ")";
                                res[curr_idx].Ion_type = new_type;
                                res[curr_idx].Radio_label = new_type + res[curr_idx].Radio_label.Remove(0, 1);
                                res[curr_idx].Name = new_type + res[curr_idx].Name.Remove(0, 1);
                                res[curr_idx].Has_adduct = has_adduct;
                                if (extra_name.Equals("B(A)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(A)", "B()"); }
                                else if (extra_name.Equals("B(G)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(G)", "B()"); }
                                else if (extra_name.Equals("B(T)")) { res[curr_idx].Has_adduct = false; res[curr_idx].Ion_type = res[curr_idx].Ion_type.Replace("B(T)", "B()"); }
                                if (hyd_mod.Contains('+'))
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
                }
            }
            return res;
        }
        private bool check_adduct(ChemiForm chem, bool add, List<ChemiForm> res, string extra_name, bool name = false)
        {
            bool error = true;
            ChemiForm temp_chem = chem.DeepCopy();
            try
            {
                if (add) { temp_chem.Adduct =/* temp_chem.Adduct +*/ extra_adduct; temp_chem.Deduct = ""; }
                else { temp_chem.Deduct =/* temp_chem.Deduct +*/ extra_adduct; temp_chem.Adduct = ""; }
                ChemiForm.CheckChem(temp_chem);
            }
            catch (Exception eee) { return error; }
            if (!temp_chem.Error)
            {
                error = false;
                ChemiForm last_chem = chem.DeepCopy();
                last_chem.InputFormula = last_chem.PrintFormula = temp_chem.FinalFormula;
                //last_chem.Mz = temp_chem.Mz;
                if (name)
                {
                    string new_type = "(" + temp_chem.Ion_type;
                    string add_type = "";
                    if (has_adduct)
                    {
                        if (add) { new_type += "+" + extra_name; add_type = "+" + extra_name; }
                        else { new_type += "-" + extra_name; add_type = "-" + extra_name; }
                    }
                    new_type += ")";
                    string[] str = temp_chem.Name.Split('_');
                    int s = temp_chem.Name.IndexOf('_');
                    last_chem.Ion = str[0].Replace(temp_chem.Ion, temp_chem.Ion + add_type);
                    last_chem.Name = last_chem.Ion + temp_chem.Name.Remove(0, s);
                    last_chem.Radio_label = last_chem.Name;
                    last_chem.Ion_type = new_type;
                    last_chem.Has_adduct = has_adduct;
                    if (extra_name.Equals("B(A)")) { last_chem.Has_adduct = false; last_chem.Ion_type = last_chem.Ion_type.Replace("B(A)", "B()"); }
                    else if (extra_name.Equals("B(G)")) { last_chem.Has_adduct = false; last_chem.Ion_type = last_chem.Ion_type.Replace("B(G)", "B()"); }
                    else if (extra_name.Equals("B(T)")) { last_chem.Has_adduct = false; last_chem.Ion_type = last_chem.Ion_type.Replace("B(T)", "B()"); }
                    res.Add(last_chem);
                }
                else res.Add(last_chem);
            }
            return error;
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
                machine = frm2.deconv_machine;
                double res = 0.0;
                if (frm2.is_deconv_const_resolution)
                {
                    res = dParser(machine);
                    foreach (ChemiForm chem in selected_fragments)
                    {
                        chem.Resolution = res;
                    }
                    if (res == 0 || res.Equals(double.NaN)) { res = 280000; }
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
                Debug.WriteLine(ex); during_calc(false);
            };
            during_calc(false);
            // sort by mz the fragments list (global) beause it is mixed by multi-threading
            Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k; }
            progress_display_stop();
            sw1.Stop(); Debug.WriteLine("Envipat_Calcs_and_filter_byPPM(M): " + sw1.ElapsedMilliseconds.ToString());
            Debug.WriteLine("PPM(): " + sw2.ElapsedMilliseconds.ToString()); sw2.Reset();
            if (!string.IsNullOrEmpty(chemForm_txtBox.Text)) { MessageBox.Show("Chemical formulas profile calculation is completed!From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments3.Count.ToString() + " were within ppm filter.", "Chemical formula calculation results"); }
            else { MessageBox.Show("From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments3.Count.ToString() + " were within ppm filter and "+duplicates.ToString()+" were duplicate with Fragment List's fragments.", "Fragment selection results"); }
            Invoke(new Action(() => OnCalcFrag3Completed()));
        }
        private void Envipat_Calcs_and_filter_byPPM_frm9(ChemiForm chem)
        {
            ChemiForm.CheckChem(chem);      // will also generate chem.FinalFormula

            if (chem.Resolution.Equals(double.NaN) ||chem.Resolution == 0)
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
            chem.Mz = Math.Round((chem.Monoisotopic.Mass-emass*chem.Charge) / Math.Abs(chem.Charge), 4).ToString();
            if (!insert_exp ) { add_fragment_to_Fragments3(chem, cen); return; }
            // MAIN decesion algorithm 
            bool fragment_is_canditate = decision_algorithm_frm9(chem, cen);          
        }

        private void add_fragment_to_Fragments3(ChemiForm chem, List<PointPlot> cen, bool candidate=true)
        {
            // adds safely a matched fragment to Fragments3, and releases memory
            lock (_locker)
            {
                if (frm2.check_duplicates_Fragments2(chem))
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
                        Fix = 1.0,
                        Max_intensity = 0.0,
                        Fixed = chem.Fixed,
                        maxPPM_Error = chem.maxPPM_Error,
                        minPPM_Error = chem.minPPM_Error,
                        Candidate = candidate,
                        Extension = chem.Extension,
                        Chain_type = chem.Chain_type,
                        SortIdx = chem.SortIdx,
                        Has_adduct = chem.Has_adduct,
                        maxFactor = chem.maxFactor
                    });
                    Fragments3.Last().Centroid = cen.Select(point => point.DeepCopy()).ToList();
                    Fragments3.Last().Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                    Fragments3.Last().Max_intensity = Fragments3.Last().Profile.Max(p => p.Y);
                    double pt0 = 0.1 * max_exp;
                    if (peak_points.Count > 0)
                    {
                        double exp_cen, curr_diff;
                        double centroid = Fragments3.Last().Centroid[0].X;
                        double min_diff = Math.Abs(peak_points[0][1] + peak_points[0][4] - centroid);
                        int closest_idx = 0;
                        for (int i = 1; i < peak_points.Count; i++)
                        {
                            exp_cen = peak_points[i][1] + peak_points[i][4];
                            curr_diff = Math.Abs(exp_cen - centroid);
                            if (curr_diff < min_diff) { min_diff = curr_diff; closest_idx = i; }
                            else
                                break;
                        }
                        pt0 = peak_points[closest_idx][2] + peak_points[closest_idx][5];
                    }
                    Fragments3.Last().maxFactor = pt0 / Fragments3.Last().Max_intensity;
                    Fragments3.Last().Factor = pt0 / Fragments3.Last().Max_intensity;
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments3, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear();
                    chem.Points.Clear();
                    chem.Centroid.Clear(); chem.Intensoid.Clear();
                }
                else
                {
                    duplicates++;
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments3, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear();
                    chem.Points.Clear();
                    chem.Centroid.Clear(); chem.Intensoid.Clear();
                }                
            }
        }
        private bool decision_algorithm_frm9(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is candidate for fitting
            bool fragment_is_canditate = true;
            double max_error = ppmError9;
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
                if (Math.Abs(tmp[0])> max_error) 
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
            if (fragment_is_canditate /*&& !frm2.is_exp_deconvoluted*/ &&!is_res_user_defined)
            {
                chem.Resolution = (double)results.Average(p => p[1]);
                results = new List<double[]>();
                chem.Profile.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
                // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
                ChemiForm.Envelope(chem);
                ChemiForm.Vdetect(chem);
                cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
                if (contrib_peaks > cen.Count) { contrib_peaks = cen.Count; }
                for (int i = 0; i < contrib_peaks; i++)
                {
                    double[] tmp = ppm_calculator(cen[i].X);
                    results.Add(tmp);
                    if (Math.Abs(tmp[0]) > max_error) { fragment_is_canditate = false; }
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
            if (help) { MessageBox.Show("Inserts to Fragment List the checked fragments of this window.   ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (Fragments3.Count == 0) return;
            insert_Btn.Enabled = false;
            if (frm2.is_frag_calc_recalc || is_in_calc_mode) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); insert_Btn.Enabled = true; return; }
            insert_frag_to_Fragments2();
            insert_Btn.Enabled = true;
        }
        private void insert_frag_to_Fragments2()
        {
            if (fragListView9.CheckedIndices.Count == 0) { MessageBox.Show("First check the desired fragments and then press insert!"); return; }
            foreach (ListViewItem item in fragListView9.CheckedItems)
            {
                int new_fragin = System.Convert.ToInt32(item.SubItems[5].Text);
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
                    Fix = 1.0,
                    Max_intensity = 0.0,
                    Fixed = false,
                    maxPPM_Error= Fragments3[new_fragin].maxPPM_Error,
                    minPPM_Error= Fragments3[new_fragin].minPPM_Error,
                    Extension = Fragments3[new_fragin].Extension,
                    Chain_type = Fragments3[new_fragin].Chain_type,
                    SortIdx = Fragments3[new_fragin].SortIdx,
                    Candidate = Fragments3[new_fragin].Candidate,
                    Has_adduct = Fragments3[new_fragin].Has_adduct,
                    maxFactor= Fragments3[new_fragin].maxFactor
                });

                Fragments2.Last().Centroid = Fragments3[new_fragin].Centroid.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Profile = Fragments3[new_fragin].Profile.Select(point => point.DeepCopy()).ToList();
                Fragments2.Last().Counter = Fragments3.Count;
                Fragments2.Last().Max_intensity = Fragments3[new_fragin].Max_intensity;
            }
            // sort by mz the fragments list (global) 
            Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
            last_plotted.Clear();
            //important step otherwise when the user clicks another fragment from the new listview the algorithm will remove the last element of all_data in order to all the new fragment 
            first = true;
            frm2.add_frag_frm9();
            int count = 0;
            foreach (ListViewItem item in fragListView9.CheckedItems)
            {
                int new_fragin = System.Convert.ToInt32(item.SubItems[5].Text);
                //remove fragment from the current listview
                Fragments3.RemoveAt(new_fragin- count); count++;
            }                
            // sort by mz the fragments list 
            Fragments3 = Fragments3.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments3.Count; k++) { Fragments3[k].Counter = k; }           
            //refresh listview 
            Fragments3_to_listview();            
            factor_panel9.Visible = false; selected_idx = 0;
        }
        #endregion
              
        #region plot, un-plot fragments
        private void plot_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Inserts to the graph the checked fragments of this window.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (frm2.is_frag_calc_recalc || is_in_calc_mode ) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
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
            foreach (ListViewItem item in fragListView9.CheckedItems)            
            {
                int frag_idx = System.Convert.ToInt32(item.SubItems[5].Text);
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
            }
        }
        private void rem_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Clears graph from fragments inserted from this window.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Remove_plotted();
        }
        private void Remove_plotted(bool recalc=true)
        {
            if (frm2.is_frag_calc_recalc || is_in_calc_mode) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            int count = last_plotted.Count;
            if (count == 0) return;
            else
            {
                all_data.RemoveRange(all_data.Count - last_plotted.Count, last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - last_plotted.Count, last_plotted.Count);
                last_plotted.Clear();
               if(recalc) frm2.recalc_frm9(count, last_plotted.Count);
            }
        }
        #endregion

        #region chemical formulas file
        private void load_chems_file_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Accepts a tab delimited .txt file with fragments' chemical formula and name. Before loading the file the user must have set the charge range of the calculation.  ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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
                DialogResult dd = MessageBox.Show("Oops..There is no sequence for the extension type you have inserted.", "Wrong Input", MessageBoxButtons.OK);
                return; 
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
                                Extension=extension,
                                Has_adduct=false,
                                maxFactor = 1.0
                            });
                            mult_loaded.Last().Adduct = "H" + c.ToString();
                        }
                    }
                    catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); mult_loaded.Clear(); return; }

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

        private void checkall_ListBtn_Click(object sender, EventArgs e)
        {
            if (frm2.is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            fragListView9.BeginUpdate();
            foreach (ListViewItem item in fragListView9.Items)
            {
                if (!item.Checked) item.Checked = true;
            }
            fragListView9.EndUpdate();
            factor_panel9.Visible = false;
        }

        private void uncheckall_ListBtn_Click(object sender, EventArgs e)
        {
            if (frm2.is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            fragListView9.BeginUpdate();
            foreach (ListViewItem item in fragListView9.Items)
            {
                if (item.Checked) item.Checked = false;
            }
            fragListView9.EndUpdate();
            factor_panel9.Visible = false;
        }
    }
}
