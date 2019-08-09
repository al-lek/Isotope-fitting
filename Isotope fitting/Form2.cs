using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Isotope_fitting
{
    public partial class Form2 : Form
    {
        #region parameter set
     
        bool plot_rem_Btns = false;
        bool refresh_all = false;
        int algo = 1;        
        int exp_res = 0;
        public int neues = 0;
        public bool mark_neues = false;
        public static bool insert_exp = false;
        public static bool segmented_graph =false;
        public static bool loaded_window = false;
        public static string file_name="";
        public bool calc_resolution = true;
        public  bool recalc = true;

        public static List<ChemiForm> ChemFormulas = new List<ChemiForm>();
        public static string Peptide = "";
        //List<string> ionItems = new List<string>();
        //List<string> selectedFrag = new List<string>();
        List<ChemiForm> selectedIons = new List<ChemiForm>();
        //List<int> selectedCharges = new List<int>();
       
        //List<string> selectedMz = new List<string>();
        //List<int> stepIndeces =new List<int>();            
        public static List<FragForm> Fragments2 = new List<FragForm>();
        //public List<string> checkedItems = new List<string>();
        public static HashSet<int> selectedFragments = new HashSet<int>();
        int counter = 0;
        int start_idx = 0;
        int end_idx = 0;
        double max_exp = 0.0;
        public static List<WindowSet> windowList = new List<WindowSet>();
        public static int window_count = 1;
        public static int selected_window = 1000000;
        
        private ListViewItemComparer _lvwItemComparer;
        #region colours
        OxyPlot.WindowsForms.PlotView iso_plot;
        OxyPlot.WindowsForms.PlotView res_plot;
        OxyColor[] data_colors = new OxyColor[21] { OxyColors.Black, OxyColors.Green, OxyColors.IndianRed, OxyColors.Turquoise, OxyColors.DarkViolet, OxyColors.SlateGray, OxyColors.DarkRed, OxyColors.DarkOliveGreen, OxyColors.DarkSlateBlue,
            OxyColors.DarkKhaki, OxyColors.DimGray, OxyColors.DeepPink, OxyColors.Ivory, OxyColors.Tan, OxyColors.PaleGoldenrod, OxyColors.Olive, OxyColors.MistyRose, OxyColors.Moccasin, OxyColors.MediumOrchid, OxyColors.LimeGreen, OxyColors.LightGoldenrodYellow};

        OxyColor[] charge_colors = new OxyColor[21] { OxyColors.Black, OxyColors.Green, OxyColors.IndianRed, OxyColors.Turquoise, OxyColors.DarkViolet, OxyColors.SlateGray, OxyColors.DarkRed, OxyColors.DarkOliveGreen, OxyColors.DarkSlateBlue,
            OxyColors.DarkKhaki, OxyColors.DimGray, OxyColors.DeepPink, OxyColors.Ivory, OxyColors.Tan, OxyColors.PaleGoldenrod, OxyColors.Olive, OxyColors.MistyRose, OxyColors.Moccasin, OxyColors.MediumOrchid, OxyColors.LimeGreen, OxyColors.LightGoldenrodYellow};

        OxyColor[] b_colors = new OxyColor[3] { OxyColors.Blue, OxyColors.Blue, OxyColors.Blue }; //OxyColors.Navy
        OxyColor[] y_colors = new OxyColor[3] { OxyColors.DodgerBlue, OxyColors.DodgerBlue, OxyColors.DodgerBlue };
        OxyColor[] c_colors = new OxyColor[3] { OxyColors.Firebrick, OxyColors.Firebrick, OxyColors.Firebrick }; //, OxyColors.OrangeRed
        OxyColor[] z_colors = new OxyColor[3] { OxyColors.Tomato, OxyColors.Tomato, OxyColors.Tomato };
        OxyColor[] a_colors = new OxyColor[3] { OxyColors.Green, OxyColors.Green, OxyColors.Green }; //, OxyColors.OliveDrab
        OxyColor[] x_colors = new OxyColor[3] { OxyColors.LimeGreen, OxyColors.LimeGreen, OxyColors.LimeGreen };

        //OxyColors.Brown, OxyColors.RosyBrown, OxyColors.SaddleBrown, OxyColors.SandyBrown, OxyColors.Sienna, OxyColors.BurlyWood
        //OxyColors.Gray, OxyColors.DarkGray, OxyColors.SlateGray, OxyColors.LightSlateGray, OxyColors.DarkSlateGray, OxyColors.LightGray
        #endregion
        public static List<List<double[]>> all_data = new List<List<double[]>>();
        public static int candidate_fragments = 1;
        double keyStep = 0.002;
        double fit_step = 0.0;//m/z step selected in fitting options box 
        double min_border = 0.0;//minimum m/z selected in fitting options box
        double max_border = 0.0;//maximum m/z selected in fitting options box 
        double step_range = 0.0;

        List<double[]> experimental = new List<double[]>();
        List<double[]> current_experimental = new List<double[]>();

        List<double[]> all_data_aligned = new List<double[]>();
        public static List<List<double[]>> selected_all_data = new List<List<double[]>>();

        List<double[]> aligned_intensities = new List<double[]>();
        List<double[]> fitted_results = new List<double[]>();
        List<int[]> powerSet = new List<int[]>();
        List<int[]> powerSet_distroIdx = new List<int[]>();
        List<double[]> summation = new List<double[]>();
        List<double[]> residual = new List<double[]>();
        List<int> custom_colors = new List<int>();

        const double H_mass = 1.008;
        OxyPlot.ScreenPoint charge_center;
        bool is_loading = false; //indicates if loading is active
        bool is_applying_fit = false;       
        private bool is_calc=false;
        
        int current_peak_index;
        public static List<double[]> peak_points = new List<double[]>();

        public static double ppmError = 8.0;
        public static double min_intes = 50.0;

        public System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw3 = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw4 = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw5 = new System.Diagnostics.Stopwatch();
        public System.Diagnostics.Stopwatch sw6 = new System.Diagnostics.Stopwatch();
        ProgressBar tlPrgBr;
        int max_fragment_charge = 0;
        string precursor_carbons = "C0";

        Form6 frm6 = new Form6();
        #endregion
        public Form2()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            InitializeComponent();

            reset_all();
        }

        // UI UncheckAll()
        // UI Initialize_fit_UI()
        // UI merge textBox input control
        // Debug.WriteLine("peak thread id: " + Thread.CurrentThread.ManagedThreadId);



        #region Import data
        private void loadExp_Btn_Click(object sender, EventArgs e)
        {
            load_experimental_sequence();
        }

        private void load_experimental_sequence()
        {
            sw1.Reset(); sw1.Start();
            load_experimental();
            sw1.Stop(); Debug.WriteLine("load_experimental: " + sw1.ElapsedMilliseconds.ToString());

            sw1.Reset(); sw1.Start();
            post_load_actions();
            sw1.Stop(); Debug.WriteLine("post_load_actions: " + sw1.ElapsedMilliseconds.ToString());

            Thread peak_detection = new Thread(peakDetect_and_resolutionRef);
            peak_detection.Start();
        }

        private void load_experimental()
        {
            if (!is_loading && !is_calc)
            {
                OpenFileDialog expData = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Title = "Load experimental data", FileName = "", Filter = "data file|*.txt|All files|*.*" };
                List<string> lista = new List<string>();

                if (expData.ShowDialog() != DialogResult.Cancel)
                {
                    StreamReader objReader = new StreamReader(expData.FileName);
                    file_name = expData.SafeFileName.Remove(expData.SafeFileName.Length - 4);
                    do { lista.Add(objReader.ReadLine()); }
                    while (objReader.Peek() != -1);
                    objReader.Close();

                    experimental.Clear();

                    //add toolstrip progress bar
                    progress_display_start(lista.Count);
                    max_exp = 0.0;
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] tmp_str = lista[j].Split('\t');
                            if (tmp_str.Length == 2) experimental.Add(new double[] { dParser(tmp_str[0]), dParser(tmp_str[1]) });
                            if (max_exp < dParser(tmp_str[1])) max_exp = dParser(tmp_str[1]);
                        }
                        catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); return; }

                        if (j % 10000 == 0 && j > 0) progress_display_update(j);
                    }
                    progress_display_stop();
                }
            }
            else { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
        }

        private void post_load_actions()
        {
            insert_exp = true;
            recalc = true;

            // post load actions
            fitMin_Box.Enabled = fitMax_Box.Enabled = fitStep_Box.Enabled = Fitting_chkBox.Enabled = true;
            Fitting_chkBox.Checked = false;

            selected_window = 1000000;
            fitMin_Box.Text = experimental[0][0].ToString();
            fitMax_Box.Text = experimental[experimental.Count - 1][0].ToString();
            //fix_experimentalTo_100(max_exp);

            parse_data(0);

            if (custom_colors.Count > 0) custom_colors[0] = OxyColors.Black.ToColor().ToArgb();
            else custom_colors.Add(OxyColors.Black.ToColor().ToArgb());

            //add experimental to plot
            selectedFragments.Add(0);
            if (all_data.Count > 1) { refix_data_to_max_exp(); step_Fitting(); }
            if (!is_loading && !is_calc)
            {
                if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); }
                refresh_iso_plot();
            }
            start_idx = 0;
            end_idx = experimental.Count;
            //fix_experimental_gaps(max_exp);                
            loadFit_Btn.Enabled = false;
        }

        private void peakDetect_and_resolutionRef()
        {
            if (experimental.Count() > 0)
            {
                peak_detect();
                
                if (peak_points.Count() > 0)
                {
                    displayPeakList_btn.Invoke(new Action(() => displayPeakList_btn.Enabled = true));   //thread safe call
                    exp_res++;
                    //plot_peak(); 
                    List<float> tmp1 = new List<float>();
                    List<float> tmp2 = new List<float>();
                    foreach (double[] peak in peak_points)
                    {
                        if (peak[5] > 200000)
                        {
                            tmp1.Add((float)(peak[1] + peak[4]));
                            tmp2.Add((float)peak[3]);
                        }
                    }
                    if (tmp1.Count > 0)
                    {
                        Resolution_List.L.Add("resolution from file" + exp_res.ToString(), new Resolution_List.MachineR(tmp1.ToArray(), tmp2.ToArray()));
                        add_machine(true);
                    }
                }
            }
        }
        #endregion

        #region Import fragment list
        private void LoadMS_Btn_Click(object sender, EventArgs e)
        {
            import_fragments();
        }

        private void import_fragments()
        {
            OpenFileDialog fragment_import = new OpenFileDialog() { InitialDirectory = "c:\\", Filter = "txt files (*.txt)|*.txt", FilterIndex = 2, RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true };
            List<string> lista = new List<string>();

            if (fragment_import.ShowDialog() != DialogResult.Cancel)
            {
                StreamReader objReader = new StreamReader(fragment_import.FileName);
                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                ChemFormulas.Clear();
                Peptide = Path.GetFileNameWithoutExtension(fragment_import.FileName);

                lista.RemoveAt(0);
                get_precursor_carbons(lista.Last());
                progress_display_start(lista.Count);

                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');
                        if (tmp_str.Length == 5) assign_resolve_fragment(tmp_str);
                    }
                    catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); return; }

                    if (j % 5000 == 0 && j > 0) progress_display_update(j);
                }
                progress_display_stop();
                post_import_fragments();
            }
        }

        private void get_precursor_carbons(string last_line)
        {
            //
            string[] tmp_str = last_line.Split('\t');

            if (tmp_str[1] == "MH")
                precursor_carbons = tmp_str[4].Split(' ').First();
        }

        private void assign_resolve_fragment(string[] frag_info)
        {
            ChemFormulas.Add(new ChemiForm
            {
                InputFormula = frag_info[4],
                Adduct = string.Empty,
                Deduct = string.Empty,
                Multiplier = 1,                
                Mz = frag_info[0],
                Ion = frag_info[1],
                Index = frag_info[2],
                IndexTo = frag_info[2],
                Error = false,
                Elements_set = new List<Element_set>(),
                Iso_total_amount = 0,
                Monoisotopic = new CompoundMulti(),
                Points = new List<PointPlot>(),
                Machine = string.Empty,
                Resolution = new float(),
                Combinations = new List<Combination_1>(),
                Profile = new List<PointPlot>(),
                Centroid = new List<PointPlot>(),
                Combinations4 = new List<Combination_4>(),
                FinalFormula = string.Empty,
            });

            int i = ChemFormulas.Count - 1;

            ChemFormulas[i].PrintFormula = fix_formula(ChemFormulas[i].InputFormula);
            ChemFormulas[i].Charge = Int32.Parse(frag_info[3]);

            if (ChemFormulas[i].Charge > max_fragment_charge) max_fragment_charge = ChemFormulas[i].Charge;
            if (ChemFormulas[i].Charge > 1) ChemFormulas[i].Adduct = "H" + (ChemFormulas[i].Charge - 1);

            if (char.IsLower(frag_info[1][0]))      
            {
                // normal fragment
                ChemFormulas[i].Ion_type = ChemFormulas[i].Ion;
                if (ChemFormulas[i].Ion.StartsWith("d") || ChemFormulas[i].Ion.StartsWith("w") || ChemFormulas[i].Ion.StartsWith("v")) ChemFormulas[i].Color = OxyColors.Turquoise;
                else if (ChemFormulas[i].Ion.StartsWith("a")) ChemFormulas[i].Color = OxyColors.Green;
                else if (ChemFormulas[i].Ion.StartsWith("b")) ChemFormulas[i].Color = OxyColors.Blue;
                else if (ChemFormulas[i].Ion.StartsWith("x")) { ChemFormulas[i].Color = OxyColors.LimeGreen; }// x_index.Add(i); }
                else if (ChemFormulas[i].Ion.StartsWith("y")) ChemFormulas[i].Color = OxyColors.DodgerBlue;
                else if (ChemFormulas[i].Ion.StartsWith("y")) ChemFormulas[i].Color = OxyColors.Tomato;
                else if (ChemFormulas[i].Ion.StartsWith("c")) ChemFormulas[i].Color = OxyColors.Firebrick;
                else ChemFormulas[i].Color = OxyColors.PaleGoldenrod;

                string lbl = ChemFormulas[i].Ion_type + ChemFormulas[i].Index;
                ChemFormulas[i].Radio_label = lbl;
                ChemFormulas[i].Name = lbl + "_+" + ChemFormulas[i].Charge.ToString();
            }
            else 
            {
                // internal fragment or precursor
                // split string in two parts, [0] main [1]adduct (if any)
                string[] substring = new string[2] { "", "" };
                int dash_idx = ChemFormulas[i].Ion.IndexOf('-');
                if (dash_idx != -1)
                {
                    substring[0] = ChemFormulas[i].Ion.Substring(0, dash_idx);
                    substring[1] = ChemFormulas[i].Ion.Substring(dash_idx);
                }
                else substring[0] = ChemFormulas[i].Ion;

                if (substring[0].StartsWith("MH") && ChemFormulas[i].InputFormula.StartsWith(precursor_carbons))  // an internal b could be MHQRP for example, so check also carbons
                {
                    ChemFormulas[i].Ion_type = "M" + substring[1];
                    ChemFormulas[i].Color = OxyColors.DarkRed;
                    ChemFormulas[i].Index = 0.ToString();
                    ChemFormulas[i].IndexTo = (Peptide.Length - 1).ToString();

                    string lbl = ChemFormulas[i].Ion_type;
                    ChemFormulas[i].Radio_label = lbl;
                    ChemFormulas[i].Name = lbl + "_+" + ChemFormulas[i].Charge.ToString();
                }
                else if (substring[1].Contains("-CO"))
                {
                    substring[1] = substring[1].Replace("-CO", "");

                    ChemFormulas[i].Ion_type = "internal a" + substring[1];
                    ChemFormulas[i].Color = OxyColors.DarkViolet;
                    ChemFormulas[i].Index = (Peptide.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (Peptide.IndexOf(substring[0]) + substring[0].Length).ToString();

                    string lbl = "internal_a" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                    ChemFormulas[i].Radio_label = lbl;
                    ChemFormulas[i].Name = lbl + "_+" + ChemFormulas[i].Charge.ToString();
                }
                else
                {
                    ChemFormulas[i].Ion_type = "internal b" + substring[1];
                    ChemFormulas[i].Color = OxyColors.MediumOrchid;
                    ChemFormulas[i].Index = (Peptide.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (Peptide.IndexOf(substring[0]) + substring[0].Length).ToString();

                    string lbl = "internal_b" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                    ChemFormulas[i].Radio_label = lbl;
                    ChemFormulas[i].Name = lbl + "_+" + ChemFormulas[i].Charge.ToString();
                }
            }
        }

        private void post_import_fragments()
        {
            // MS-product does not generate charge states for x fragments. We have to calculate and add them and sort by mz
            generate_x();
            ChemFormulas = ChemFormulas.OrderBy(o => Double.Parse(o.Mz)).ToList();

            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();                

            clearCalc_Btn.Enabled = true;
            mzMax_Box.Enabled = true;
            mzMin_Box.Enabled = true;
            mzMax_Label.Enabled = true;
            mzMin_Label.Enabled = true;
            chargeMax_Box.Enabled = true;
            chargeMin_Box.Enabled = true;
            chargeAll_Btn.Enabled = true;
            idxPr_Box.Enabled = true;
            idxTo_Box.Enabled = true;
            idxFrom_Box.Enabled = true;
            resolution_Box.Enabled = true;
            machine_listBox.Enabled = true;
            calc_Btn.Enabled = true;
            loadFit_Btn.Enabled = false;
        }

        private void generate_x()
        {
            // this adds all x fragments msProduct does not generate (x multiCharged and x with adducts)

            // PROG: Very rare deadlock!!! ChemFormulas.Count CANNOT be used in for loop, it is augmented inside the loop and loop will never end!!!!!
            int total_fragments_fromFile = ChemFormulas.Count;

            for (int i = 0; i < total_fragments_fromFile; i++)
            {
                if (ChemFormulas[i].Ion.StartsWith("y"))
                {
                    bool adduct = ChemFormulas[i].Ion.Contains("-");
                    int charge = ChemFormulas[i].Charge;

                    if (adduct || (!adduct && charge > 1))
                    {
                        // x have +CO -2H
                        string mz = Math.Round(Convert.ToDouble(ChemFormulas[i].Mz) + (11.99945142 + 15.99436604 - 2 * 1.007276452) / Convert.ToDouble(charge), 4).ToString();
                        string ion = ChemFormulas[i].Ion.Replace('y', 'x');
                        string index = ChemFormulas[i].Index;
                        string charges = ChemFormulas[i].Charge.ToString();

                        string[] tmp = ChemFormulas[i].InputFormula.Split(' ');
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            if (tmp[j].StartsWith("C")) tmp[j] = "C" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) + 1).ToString();          //+C
                            else if (tmp[j].StartsWith("O")) tmp[j] = "O" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) + 1).ToString();     //+O
                            else if (tmp[j].StartsWith("H")) tmp[j] = "H" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) - 2).ToString();     //-2H
                        }
                        string InputFormula = string.Join(" ", tmp);

                        string[] frag_info = new string[] { ChemFormulas[i].Mz, ChemFormulas[i].Ion, ChemFormulas[i].Index, ChemFormulas[i].Charge.ToString(), ChemFormulas[i].InputFormula };
                        assign_resolve_fragment(frag_info);                        
                    }
                }
            }
        }


        private void add_x(ChemiForm chem, int max_charge, int list_index)
        {
            double mass = double.Parse(chem.Mz, NumberStyles.AllowDecimalPoint);
            double mass_h = 1.007825;
            double mz = 0.0;
            int index = Convert.ToInt32(chem.Index);
            if (index <= 4 && max_charge > 2) max_charge = 2;
            else if (index <= 11 && index >= 5 && max_charge > 5) max_charge = 5;
            else if (index <= 22 && index >= 12 && max_charge > 8) max_charge = 8;
            else if (index <= 53 && index >= 23 && max_charge > 12) max_charge = 12;
            else if (index <= 75 && index >= 54 && max_charge > 15) max_charge = 15;
            else if (index <= 100 && index >= 76 && max_charge > 20) max_charge = 20;

            for (int c = 2; c <= max_charge; c++)
            {
                mz = (mass + (c - 1) * mass_h) / c;
                ChemFormulas.Add(new ChemiForm
                {
                    InputFormula = chem.InputFormula,
                    Adduct = 'H' + (c - 1).ToString(),
                    Deduct = chem.Deduct,
                    Multiplier = chem.Multiplier,
                    Charge = c,
                    Mz = mz.ToString(),
                    Ion = chem.Ion,
                    Ion_type = chem.Ion_type,
                    Index = chem.Index,
                    IndexTo = chem.IndexTo,
                    Error = false,
                    Elements_set = new List<Element_set>(),
                    Iso_total_amount = 0,
                    Monoisotopic = new CompoundMulti(),
                    Points = new List<PointPlot>(),
                    Machine = string.Empty,
                    Resolution = new float(),
                    Combinations = new List<Combination_1>(),
                    Profile = new List<PointPlot>(),
                    Centroid = new List<PointPlot>(),
                    Combinations4 = new List<Combination_4>(),
                    FinalFormula = string.Empty,
                    PrintFormula = chem.PrintFormula,
                    Radio_label = chem.Radio_label,
                    Color = chem.Color,
                    Name = string.Empty
                });

                var radioString = chem.Radio_label;
                var radio_name = string.Empty;
                if (ChemFormulas.Last().Charge > 0) radio_name = radioString + "_+" + ChemFormulas.Last().Charge.ToString();
                else radio_name = radioString + "_" + ChemFormulas.Last().Charge.ToString();
                ChemFormulas.Last().Name = radio_name;
            }
        }

        #endregion




        #region OxyPlot
        private void Initialize_Oxy()
        {
            // isotopes plot
            if (iso_plot != null) iso_plot.Dispose();

            iso_plot = new OxyPlot.WindowsForms.PlotView() { Name = "iso_plot", Location = new Point(5, 185), Size = new Size(1310, 570), BackColor = Color.WhiteSmoke, Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom, Dock = System.Windows.Forms.DockStyle.Fill };
            fit_grpBox.Controls.Add(iso_plot);

            //(M)create a view model--> iso_model
            PlotModel iso_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendPosition = LegendPosition.TopRight, LegendFontSize = 13, TitleFontSize = 11 }; // Title = "",
            iso_plot.Model = iso_model;

            //////iso_model.TrackerChanged += (s, e) => { e.HitResult.Position.X };
            //////iso_model.MouseDown += (s, e) =>
            //////{
            //////    OxyPlot.Axes.Axis x; OxyPlot.Axes.Axis y;
            //////    iso_model.GetAxesFromPoint(e.Position, out x, out y);
            //////    DataPoint p = OxyPlot.Axes.Axis.InverseTransform(e.Position, x, y);
            //////};

            iso_plot.Controller = new CustomPlotController();

            ContextMenu ctxMn = new ContextMenu() { };
            MenuItem showPoints = new MenuItem("Show charge ruler", manage_charge_points);
            MenuItem clearPoints = new MenuItem("Clear charge ruler", manage_charge_points);
            MenuItem copyImage = new MenuItem("Copy image", export_chartImage);
            MenuItem exportImage = new MenuItem("Export image to file", export_chartImage);
            ctxMn.MenuItems.AddRange(new MenuItem[] { showPoints, clearPoints, copyImage, exportImage });
            iso_model.MouseDown += (s, e) => { if (e.ChangedButton == OxyMouseButton.Right) { charge_center = e.Position; ContextMenu = ctxMn; } };

            //////iso_plot.MouseWheel += (s, e) => { if (e.Delta > 0 && e.ToMouseEventArgs(OxyModifierKeys.Control).IsControlDown) iso_model.DefaultXAxis.ZoomAtCenter(2) ; };
            //////bool isControlDown = System.Windows.Input Keyboard.IsKeyDown(Key.LeftCtrl);
            //////var m = new ZoomStepManipulator(this, e.Delta * 0.001, isControlDown);
            //////iso_plot.MouseWheel += (s, e) => 
            //////{
            //////    if (e.Delta > 0) iso_plot.Model.DefaultXAxis.ZoomAtCenter(1);
            //////    };

            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "intensity" };
            iso_model.Axes.Add(linearAxis1);

            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            iso_model.Axes.Add(linearAxis2);

            // residual plot
            if (res_plot != null) res_plot.Dispose();
            res_plot = new OxyPlot.WindowsForms.PlotView() { Name = "res_plot", Location = new Point(5, 760), Size = new Size(1310, 150), BackColor = Color.WhiteSmoke, Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left, Dock = System.Windows.Forms.DockStyle.Fill };
            res_grpBox.Controls.Add(res_plot);

            //(M)create a view model--> res_model
            PlotModel res_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = false, LegendPosition = LegendPosition.TopRight, LegendFontSize = 11, TitleFontSize = 11 }; // Title = "",
            res_plot.Model = res_model;

            var linearAxis1r = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "intensity", MinorGridlineStyle = LineStyle.Solid };
            //linearAxis1r.MajorStep = linearAxis1r.ActualMaximum / 2.0;
            res_model.Axes.Add(linearAxis1r);

            var linearAxis2r = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            res_model.Axes.Add(linearAxis2r);

            // bind the 2 x-axes :D
            linearAxis2.AxisChanged += (s, e) => { linearAxis2r.Zoom(linearAxis2.ActualMinimum, linearAxis2.ActualMaximum); res_plot.InvalidatePlot(true); };
            iso_model.Updated += (s, e) => { res_plot.Model.Axes[1].Zoom(iso_plot.Model.Axes[1].ActualMinimum, iso_plot.Model.Axes[1].ActualMaximum); };
            iso_plot.MouseDoubleClick += (s, e) => { iso_model.ResetAllAxes(); invalidate_all(); };
            iso_plot.MouseHover += (s, e) => { iso_plot.Focus(); };
            res_plot.MouseHover += (s, e) => { res_plot.Focus(); };
        }

        public class CustomPlotController : PlotController
        {
            public CustomPlotController()
            {
                //this.UnbindAll();

                //this.BindKeyDown(OxyKey.Left, PlotCommands.PanRight);
                //this.BindKeyDown(OxyKey.Right, PlotCommands.PanLeft);

                //this.BindMouseDown(OxyMouseButton.Left, OxyModifierKeys.Control | OxyModifierKeys.Alt, PlotCommands.ZoomRectangle);                
                this.BindMouseDown(OxyMouseButton.Left, PlotCommands.ZoomRectangle);
                //this.BindMouseWheel(OxyModifierKeys.Control, PlotCommands.ZoomIn);
            }
        }

        #endregion

        #region UI
        private void Initialize_UI()
        {
            fitMax_Box.Click += (s, e) => { fitMax_Box.SelectAll(); };
            fitMin_Box.Click += (s, e) => { fitMin_Box.SelectAll(); };
            fitMin_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true,false,true); };
            fitMax_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true,false,true); };
            fitStep_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) { step_Fitting(); if (!is_loading && !is_calc) { if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); } refresh_iso_plot(); } } };
            step_rangeBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) { step_Fitting(); if (!is_loading && !is_calc) { if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); } refresh_iso_plot(); } } };
            mzMin_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) mzMax_Box.Focus(); };
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();
            machine_listBox.SelectedIndex = 2;
            ContextMenu ctxMn1 = new ContextMenu() { };
            MenuItem copyRow = new MenuItem("Copy items", copyRowList);
            MenuItem colorSelection = new MenuItem("Fragment color", colorSelectionList);
            ctxMn1.MenuItems.AddRange(new MenuItem[] { copyRow, colorSelection });
            frag_listView.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn1; } };

            displayPeakList_btn.Click += (s, e) => { display_peakList(); };
            progress_display_init();
            

            #region unused
            ////index menu for fragment type ckeckboxes
            //ContextMenu ctxMn2 = new ContextMenu() { };
            //MenuItem indexOpt = new MenuItem("Index", indexForm);
            //ctxMn2.MenuItems.AddRange(new MenuItem[] { indexOpt });
            //a_lstBox.MouseEnter += (s, e) => { a_lstBox.Focus(); };
            //b_lstBox.MouseEnter += (s, e) => { b_lstBox.Focus(); };
            //c_lstBox.MouseEnter += (s, e) => { c_lstBox.Focus(); };
            //x_lstBox.MouseEnter += (s, e) => { x_lstBox.Focus(); };
            //y_lstBox.MouseEnter += (s, e) => { y_lstBox.Focus(); };
            //z_lstBox.MouseEnter += (s, e) => { z_lstBox.Focus(); };
            //dvw_lstBox.MouseEnter += (s, e) => { dvw_lstBox.Focus(); };           
            //addin_lstBox.MouseEnter += (s, e) => { addin_lstBox.Focus(); };
            //a_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //b_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //c_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //x_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //y_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //z_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            //dvw_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };            
            //addin_lstBox.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn2; } };
            #endregion
        }
        private void Initialize_listviewComparer()
        {
            frag_listView.ListViewItemSorter = _lvwItemComparer;
        }
        private void Initialize_fit_UI()
        {

        }
        private void manage_charge_points(object sender, EventArgs e)
        {
            double chargeMin = 1;
            double chargeMax = 10;
            double[] range = new double[2] { -1, 1 };

            iso_plot.Model.Annotations.Clear();

            if ((sender as MenuItem).Text == "Show charge ruler")
            {
                double mz = iso_plot.Model.DefaultXAxis.InverseTransform(charge_center.X);
                double h = iso_plot.Model.DefaultYAxis.InverseTransform(charge_center.Y);

                for (double i = chargeMin; i < chargeMax + 1; i++)
                    foreach (double j in range)
                        iso_plot.Model.Annotations.Add(new PointAnnotation() { X = (j * H_mass / i) + mz, Y = h, Size = 2, Text = Math.Round((j * H_mass / i) + mz, 4).ToString() + "(" + i.ToString() + ")", Fill = charge_colors[(int)i], TextRotation = -45, TextVerticalAlignment = VerticalAlignment.Top });
            }
            iso_plot.InvalidatePlot(true);
        }
        private void export_chartImage(object sender, EventArgs e)
        {
            var pngExporter = new PngExporter { Width = iso_plot.Width, Height = iso_plot.Height, Background = OxyColors.White };

            if ((sender as MenuItem).Text == "Copy image")
            {
                var bitmap = pngExporter.ExportToBitmap(iso_plot.Model);
                Clipboard.SetImage(bitmap);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save plot image", FileName = "", Filter = "image file|*.png|all files|*.*", OverwritePrompt = true, AddExtension = true };
                if (save.ShowDialog() == DialogResult.OK) { pngExporter.ExportToFile(iso_plot.Model, save.FileName); }
            }
        }
        private void UncheckAll()
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
            foreach (int i in dvw_lstBox.CheckedIndices)
            {
                dvw_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in addin_lstBox.CheckedIndices)
            {
                addin_lstBox.SetItemCheckState(i, CheckState.Unchecked);
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
            dvw_lstBox.ClearSelected();
            internal_lstBox.ClearSelected();
            addin_lstBox.ClearSelected();
            mzMax_Box.Text = null;
            mzMin_Box.Text = null;
            chargeMin_Box.Text = null;
            chargeMax_Box.Text = null;
            idxFrom_Box.Text = null;
            idxTo_Box.Text = null;
            idxPr_Box.Text = null;
        }
        private void mzMin_Label_Click(object sender, EventArgs e)
        {
            mzMin_Box.Text = null;
            mzMin_Box.Text = ChemFormulas.FirstOrDefault().Mz.ToString();
        }
        private void mzMax_Label_Click(object sender, EventArgs e)
        {
            mzMax_Box.Text = null;
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();
        }
        private void mzMin_Box_Click(object sender, EventArgs e)
        {
            mzMin_Box.SelectAll();
        }
        private void mzMax_Box_Click(object sender, EventArgs e)
        {
            mzMax_Box.SelectAll();
        }
        private void chargeAll_Btn_Click(object sender, EventArgs e)
        {
            chargeMin_Box.Text = null;
            chargeMax_Box.Text = null;
        }
        private void Resolution_Box_TextChanged(object sender, EventArgs e)
        {
            // Clear all selections in the ListBox.
            machine_listBox.ClearSelected();
            if (Regex.IsMatch(resolution_Box.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                resolution_Box.Text = resolution_Box.Text.Remove(resolution_Box.Text.Length - 1);
            }
        }
        private void Machine_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resolution_Box.Text = null;
        }
        private void MzMin_Box_TextChanged(object sender, EventArgs e)
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
                }
            }

            //if (insert_file == false && Regex.IsMatch(mzMin_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    mzMin_Box.Text = mzMin_Box.Text.Remove(mzMin_Box.Text.Length - 1);
            //}
        }
        private void MzMax_Box_TextChanged(object sender, EventArgs e)
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
                }
            }
            //if (insert_file == false && Regex.IsMatch(mzMax_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    mzMax_Box.Text = mzMax_Box.Text.Remove(mzMax_Box.Text.Length - 1);
            //}
        }
        private void ChargeMin_Box_TextChanged(object sender, EventArgs e)
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
                    }
                }
            }
            //if (Regex.IsMatch(chargeMin_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    chargeMin_Box.Text = chargeMin_Box.Text.Remove(chargeMin_Box.Text.Length - 1);
            //}
        }
        private void ChargeMax_Box_TextChanged(object sender, EventArgs e)
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
                    }
                }
            }
            //if (Regex.IsMatch(chargeMax_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    chargeMax_Box.Text = chargeMax_Box.Text.Remove(chargeMax_Box.Text.Length - 1);
            //}
        }
        private void IdxPr_Box_TextChanged(object sender, EventArgs e)
        {
            //if (Regex.IsMatch(idxPr_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    idxPr_Box.Text = idxPr_Box.Text.Remove(idxPr_Box.Text.Length - 1);
            //}
        }
        private void IdxFrom_Box_TextChanged(object sender, EventArgs e)
        {
            //if (Regex.IsMatch(idxFrom_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    idxFrom_Box.Text = idxFrom_Box.Text.Remove(idxFrom_Box.Text.Length - 1);
            //}

        }
        private void IdxTo_Box_TextChanged(object sender, EventArgs e)
        {
            //if (Regex.IsMatch(idxTo_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    idxTo_Box.Text = idxTo_Box.Text.Remove(idxTo_Box.Text.Length - 1);
            //}
        }
        private void step_rangeBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(step_rangeBox.Text))
            {
                try
                {
                    step_range = double.Parse(step_rangeBox.Text, NumberStyles.AllowDecimalPoint);
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    step_rangeBox.Text = step_rangeBox.Text.Remove(step_rangeBox.Text.Length - 1);
                }
            }
        }
        private void FitStep_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fitStep_Box.Text))
            {
                try
                {
                    double.Parse(fitStep_Box.Text, NumberStyles.AllowDecimalPoint);
                    stepRange_Lbl.Visible = true;
                    step_rangeBox.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    fitStep_Box.Text = fitStep_Box.Text.Remove(fitStep_Box.Text.Length - 1);
                }
            }
            else
            {
                stepRange_Lbl.Visible = false;
                step_rangeBox.Visible = false;
            }
            //if (Regex.IsMatch(fitStep_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    fitStep_Box.Text = fitStep_Box.Text.Remove(fitStep_Box.Text.Length - 1);
            //}
        }
        private void FitMax_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fitMax_Box.Text))
            {
                try
                {
                    max_border = double.Parse(fitMax_Box.Text, NumberStyles.AllowDecimalPoint);
                    recalc = true;
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    fitMax_Box.Text = fitMax_Box.Text.Remove(fitMax_Box.Text.Length - 1);
                }
            }
            //if (Regex.IsMatch(fitMax_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    fitMax_Box.Text = fitMax_Box.Text.Remove(fitMax_Box.Text.Length - 1);
            //}
        }
        private void FitMin_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fitMin_Box.Text))
            {
                try
                {
                    min_border = double.Parse(fitMin_Box.Text, NumberStyles.AllowDecimalPoint);
                    recalc = true;
                }
                catch
                {
                    MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                    fitMin_Box.Text = fitMin_Box.Text.Remove(fitMin_Box.Text.Length - 1);
                }
            }
            //if (Regex.IsMatch(fitMin_Box.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    fitMin_Box.Text = fitMin_Box.Text.Remove(fitMin_Box.Text.Length - 1);
            //}  
        }
        #endregion

        #region Data manipulation
        private void reset_all()
        {
            //FormWindowState curr_state = this.WindowState;
            //Size curr_size = this.Size;

            //this.WindowState = FormWindowState.Normal;
            //this.Size = new Size(2200, 925);           

            Initialize_data_struct();
            Initialize_UI();
            Initialize_Oxy();
            Initialize_fit_UI();

            //this.WindowState = curr_state;
            //this.Size = curr_size;
        }
        private void Initialize_data_struct()
        {
            aligned_intensities.Clear();
            all_data_aligned.Clear();
            fitted_results.Clear();
            powerSet.Clear();
            powerSet_distroIdx.Clear();
            summation.Clear();
            residual.Clear();
            custom_colors.Clear();
            all_data.Clear();
        }
        private List<double> get_UI_intensities(int[] subSet, double max = 1.0, bool optimizer_default = false,bool window=false,int w=1)
        {
            //(Μ)to subset einai to to_plot se array to opoio perieei touw indexes tvn epilegmenvn fragments

            // optimizer_default = true is for the optimizer
            // will return some default values in case factor textbox is empty or wrong

            // optimizer_default = false is for the normal replot
            // will return whatever is on textBox or 0.0 on wrong value

            List<double> UI_intensities = new List<double>();

            for (int i = 0; i < subSet.Length; i++)
            {
                int index =  subSet[i];
                //pairnei th timh tou ekastote factor pou oristhke gia kathe fragment
                if (window)
                {
                    index = windowList[w].Checked_mono_fragments[index - 1];
                }
                double tmpD = 1.0;
                if (index!=0 ) { tmpD = Fragments2[index - 1].Factor; }                 
                if (double.IsNaN(tmpD))
                {
                    if (optimizer_default) UI_intensities.Add(max * 0.01);
                    else UI_intensities.Add(0.0);
                }
                else if (tmpD == 0.0 && optimizer_default) UI_intensities.Add(0.001);
                else UI_intensities.Add(tmpD);
            }
            return UI_intensities;
        }
        
        private double dParser(string t)
        {
            if (double.TryParse(t, out double d)) return d;

            return double.NaN;
        }
        private void parse_data(int idx,bool replace=false)
        {
            // reset data
            while (all_data.Count<=idx) { all_data.Add(new List<double[]>()); }
            all_data[idx].Clear();
            if (idx == 0 && replace==true)//region of experimental data
            {
                if (selected_all_data[idx].Count > 0) foreach (double[] exp in selected_all_data[idx]) { all_data[idx].Add(exp); }                
                else { MessageBox.Show("Error! Selected experimental data region couldn't be parsed","Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }                
            }
            else if (idx == 0)//exprimental data
            {
                foreach (double[] exp in experimental) { all_data[idx].Add(exp); }
            }
            else//for fragment data
            {
                if (all_data.Count == idx + 1)
                {
                    foreach (PointPlot p in Fragments2[idx - 1].Profile)
                    {
                        all_data[idx].Add(new double[] { p.X, p.Y });                        
                    }
                    custom_colors.Add(Fragments2[idx-1].Color.ToColor().ToArgb());
                }
                else if (custom_colors.Count == idx + 1) custom_colors[idx] = Fragments2[idx-1].Color.ToColor().ToArgb();
                else MessageBox.Show(Text="Data parsing wasn't successful", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }   
        }
        private void select_from_experimental(string start_txt, string stop_txt,bool text_box_entry=false,bool later=false,bool fix=false)
        {            
            // will seach for the closest experimental mass to the input value and refresh distribution 0.
            double start = dParser(start_txt)-step_range;
            double end = dParser(stop_txt)+step_range;

            // check validity
            if (double.IsNaN(start) || double.IsNaN(end)) { MessageBox.Show("Input value is not a number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start <= 0 || end <= 0) { MessageBox.Show("Negative values detected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start >= end) { MessageBox.Show("Start value is larger than the end value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start < experimental[0][0]) { MessageBox.Show("Value out of range!\r\nStart value is smaller than the experimental start m/z!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (end > experimental[experimental.Count - 1][0]) { MessageBox.Show("Value out of range!\r\nEnd value is larger than the experimental end m/z!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; };

            //create the first element of the list select_all_data that contains the selected m/z range
            selected_all_data.Clear();
            selected_all_data.Add(new List<double[]>());
            // find closest experimental m/z
            start_idx = 0;
            for (int i = 1; i < experimental.Count; i++)
                if (start < experimental[i][0]) { if (text_box_entry) { fitMin_Box.Text = experimental[i - 1][0].ToString(); } start_idx = i - 1; break; }

            end_idx = 0;
            for (int i = experimental.Count - 1; i > 1; i--)
                if (end > experimental[i][0]) { if (text_box_entry) { fitMax_Box.Text = experimental[i + 1][0].ToString(); } end_idx = i + 1; break; }

            // copy experimental data range to distribution 0
            StringBuilder strBldr = new StringBuilder();
            for (int i = start_idx; i < end_idx + 1; i++)
            {
                selected_all_data[0].Add(new double[] {experimental[i][0], experimental[i][1]});
            }            
            parse_data(0,true);
            if (fix)
            {
                max_exp = selected_all_data[0].Select(d => d[1]).Max();
                if (Fragments2.Count() > 0) refix_data_to_max_exp();
            }
            if (later == false && recalc)
            {                
                recalculate_all_data_aligned();
                refresh_iso_plot();
                recalc = false;
            }            
           
        }
        #endregion

        #region Fitting + Windows

        private void step_Fitting()
        {
            if (!string.IsNullOrEmpty(fitStep_Box.Text))
            {                
                fit_step = double.Parse(fitStep_Box.Text, NumberStyles.AllowDecimalPoint);
                max_border = double.Parse(fitMax_Box.Text, NumberStyles.AllowDecimalPoint);
                min_border = double.Parse(fitMin_Box.Text, NumberStyles.AllowDecimalPoint);
                if (max_border < min_border) { MessageBox.Show("'max' can't be lower than 'min'","Error!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return; }
                else if ((max_border-min_border)<fit_step) { MessageBox.Show("Fitting step too large for the m/z section selected! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                //na prosthsw ki allo elegxo gia to an einai katallhlo to input tou step
                segmented_graph = true;
                iso_plot.Model.Annotations.Clear();
                if (recalc) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true,true,false);               
                if (fit_step==0) step_play(true);  
                else step_play();                
                if (Fragments2.Count>0)
                {
                    find_windows_mono_fragments();
                    create_step_panels();
                    fix_window_to_max_exp();
                    fit_all_Btn.Enabled = true;
                }

                recalculate_all_data_aligned();
                refresh_iso_plot();
            }
        }
        private void fix_window_to_max_exp()
        {
            //it is called in each 'fit' call after 'find window fragments' or when clicking the window tab 
            ////foreach window w find the max expeimental then find the factor that all_data have to be multplied to in order to be 20% of the max_exp of the specified window
            foreach (WindowSet w in windowList)
            {
                foreach (int f in w.Mono_fragments)
                {
                    Fragments2[f - 1].Fix = 0.2 * w.Max_exp / Fragments2[f - 1].Max_intensity;
                }
            }
            foreach (ListViewItem item in frag_listView.Items)
            {
                int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
            }
        }
        private void create_step_panels()
        {
            // 1. clear previous results (UI ctrls and chart)            
            try { bigPanel.Controls.Clear(); }
            catch { }

            for (int j = 0; j < window_count; j++)
            {
                Panel pnl = new Panel() { Size = new Size(175, 100), AutoScroll = true, BorderStyle = BorderStyle.FixedSingle, TabIndex = j };
                pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
                pnl.Click += (s, e) => { selected_window = pnl.TabIndex; window_colors(pnl.TabIndex); pnl.BackColor = Color.LightSteelBlue; window_graph(pnl.TabIndex);highlight_selected(pnl.TabIndex); };
                Label window_tab = new Label() { TabIndex = 1000, Dock=DockStyle.Top,Text=windowList[j].Code.ToString(), Font = new Font(DefaultFont, FontStyle.Bold), AutoSize = true };
                pnl.Controls.Add(window_tab);
                pnl.MouseEnter += (s, e) => { pnl.Focus(); };
                ContextMenu ctxMn3 = new ContextMenu() { };
                MenuItem copyRow = new MenuItem("Copy fitted fragments", copyRowList);
                ctxMn3.MenuItems.AddRange(new MenuItem[] { copyRow});
                pnl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn3; } };
                bigPanel.Controls.Add(pnl);
            }
            saveWd_Btn.Enabled = true;
            bigPanel.Invalidate();
            return;
        }
        
        private void highlight_selected(int window)
        {
            foreach (ListViewItem item in frag_listView.Items)
            {
                double mass = double.Parse(item.SubItems[1].Text, NumberStyles.AllowDecimalPoint);
                if (mass >= all_data[0][windowList[window].Starting][0] && mass <= all_data[0][windowList[window].Ending][0])
                {
                    item.ForeColor = Color.White;
                    item.BackColor =Color.LightSteelBlue;
                }
                else 
                {
                    item.ForeColor = Color.Black;
                    item.BackColor = Color.White;

                }
            }            
        }
        private void window_graph(int index)
        {
            iso_plot.Model.Annotations.Clear();
            double min_border = selected_all_data[0][windowList[index].Starting][0];
            double max_border = selected_all_data[0][windowList[index].Ending][0];
            iso_plot.Model.Annotations.Add(new RectangleAnnotation { MinimumX = min_border, MaximumX = max_border,  Fill = OxyColor.FromAColor(99, OxyColors.Gainsboro) });
            invalidate_all();
        }
        private void window_colors(int w)
        {
            for(int p=0;p<window_count ;p++)
            {
                if (p!=w) { Panel pnlk = GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == p); if (pnlk != null) { pnlk.BackColor = Color.White; pnlk.Invalidate(); } }
                
            }
            
        }
        private void step_play(bool window_1=false)
        {
            //stepIndeces.Clear();
            if (selected_all_data.Count == 0)
            {
                selected_all_data.Add(new List<double[]>());
                selected_all_data[0] =all_data[0];
            }
            List<FragForm> Fragments3 = Fragments2.OrderBy(o => Double.Parse(o.Mz)).ToList(); 
            windowList.Clear();
            if (window_1==false)
            {
                window_count = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / fit_step) + 1;
                //if (window_count > 40)
                //{
                //    MessageBox.Show("The programm can handle till 40 windows, the inserted fit step= " + fit_step.ToString() + "ends up in" + window_count.ToString() + "windows.");
                //    fit_step = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / 40.0);
                //    fitStep_Box.Text = fit_step.ToString();
                //    window_count = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / fit_step) + 1;
                //}
            }
            else
            {
                window_count = 1;
            }
            
            double left = selected_all_data[0][0][0];
            double right = left + fit_step;
            if (left < 0.0) left = 0.0;
            if (right > selected_all_data[0].Last()[0]) right = selected_all_data[0].Last()[0];
            int dot = 1;
            int starting = 0;
            int ending = 0;
            //ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = window_count, Size = new Size(227, 23), AutoSize = false };
            //user_grpBox.Controls.Add(tlPrgBr);
            int k = 0;
            bool last = false;
            do
            {                
                for (int i = dot; i < selected_all_data[0].Count; i++) { if (left - step_range < selected_all_data[0][i][0]) { starting = i - 1; dot = i - 1; break; } }
                   
                for (int i = dot; i < selected_all_data[0].Count; i++) { if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; } }

                int[] check = check_windows_borders(starting, ending,Fragments3);
                if (check[0] == -1)
                {
                    if (check[1] < 2)
                    {
                        if (windowList.Count() > 0)
                        {
                            check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
                            if (check[0] == -1)
                            {
                                windowList.Last().Ending = ending;
                                windowList.Last().All_data[0].Clear();
                                windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
                                windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);                                
                            }
                            else
                            {
                                windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                                windowList.Last().All_data.Add(new List<double[]>());
                                windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                                windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                                k++;                               
                            }
                            left = right;
                            right = left + fit_step;
                        }
                        else
                        {
                            right = right + fit_step / 2;
                        }
                    }
                    else
                    {
                        windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                        windowList.Last().All_data.Add(new List<double[]>());
                        windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                        windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                        k++;
                        left = right;
                        right = left + fit_step;
                    }
                    if (last) window_count = windowList.Count();
                    
                    if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
                    //tlPrgBr.Value++;
                }
                else
                {
                    window_count++;
                    //double ps1 = 4 * Fragments2[check[0] - 1].Centroid.Count() / 5;
                    //int ps =(int)Math.Round(ps1,0);
                    //right = Fragments2[check[0] - 1].Centroid.OrderBy(o=>o.X).ToList()[ps].X+1;
                    right = Fragments2[check[0] - 1].Centroid[0].X + 1;
                    for (int i = dot; i < selected_all_data[0].Count; i++)
                        if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; }
                    check = check_windows_borders2(starting, ending,Fragments3);
                    if (check[0]==-1)
                    {
                        if (check[1] <2)
                        {
                            if (windowList.Count()>0)
                            {
                                check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
                                if (check[0] ==-1)
                                {
                                    windowList.Last().Ending = ending;
                                    windowList.Last().All_data[0].Clear();
                                    windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
                                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                                    left = right;
                                    right = left + fit_step;
                                }
                                else
                                {
                                    windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                                    windowList.Last().All_data.Add(new List<double[]>());
                                    windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                                    k++;
                                    left = right;
                                    right = left + fit_step;
                                }                                   
                            }
                            else{right = right + fit_step/2;}                           
                        }
                        else
                        {
                            windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                            windowList.Last().All_data.Add(new List<double[]>());
                            windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                            k++;
                            left = right;
                            right = left + fit_step;
                        }
                        if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
                    }
                    else
                    {
                        right = left + (right-left)/2;
                        for (int i = dot; i < selected_all_data[0].Count; i++)
                            if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; }
                        check = check_windows_borders2(starting, ending, Fragments3);
                        if (check[1] < 2)
                        {
                            if (windowList.Count() > 0)
                            {
                                check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
                                if (check[0] == -1)
                                {
                                    windowList.Last().Ending = ending;
                                    windowList.Last().All_data[0].Clear();
                                    windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
                                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);                                    
                                }
                                else
                                {
                                    windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                                    windowList.Last().All_data.Add(new List<double[]>());
                                    windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);                                   
                                    k++;
                                }
                                left = right;
                                right = left + fit_step;
                            }
                            else{right = right + fit_step / 2;}
                        }
                        else
                        {
                            windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
                            windowList.Last().All_data.Add(new List<double[]>());
                            windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                            left = right;
                            right = left + fit_step;
                            k++;
                        }
                        if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
                    }                   
                }
            } while (k < window_count) ;
            int []check_last = check_windows_borders2(windowList.Last().Starting, windowList.Last().Ending, Fragments3);
            if (check_last[1]<2)
            {
                windowList[windowList.Count-2].Ending = windowList.Last().Ending;
                windowList[windowList.Count - 2].All_data[0].Clear();
                windowList[windowList.Count - 2].All_data[0] = all_data[0].GetRange(windowList[windowList.Count - 2].Starting, windowList[windowList.Count - 2].Ending - windowList[windowList.Count - 2].Starting + 1);
                windowList[windowList.Count - 2].Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
                windowList.RemoveAt(windowList.Count - 1);
                window_count--;
            }
            //tlPrgBr.Dispose();
        }
        private int[] check_windows_borders(int starting,int ending,List<FragForm> Fragments3)
        {
            //if the amount of the monoisotopic fragments is less than 7 then the output is {-1,1 }, -1 indicates that there is not any problem
            //if the amount of the monoisotopic fragments is more than 6 then the output is {last item code, amount of monoisotopic fragments}
            //as there is not any code equal to -1 the first element of the array indicates if there is a problem
            List<int> mono = new List<int>();
            int[] array = new int[] {-1,1 };
            int check_amount = 0; //monoisotopic fragments' in current window           
            foreach (FragForm fra in Fragments3)
            {
                double mass = double.Parse(fra.Mz, NumberStyles.AllowDecimalPoint);
                int item_code = fra.Counter;
                
                if (mass >= selected_all_data[0][starting][0] && mass <= selected_all_data[0][ending][0])
                {
                    mono.Add(item_code);
                    check_amount++;
                }
                if (check_amount >5) { array = new int[] { item_code, check_amount }; return array; }
                //if (mass > selected_all_data[0][ending][0]) break;
            }
            return array;
        }
        private int[] check_windows_borders2(int starting, int ending, List<FragForm> Fragments3)
        {
            //if the amount of the monoisotopic fragments is less than 7 then the output is {-1,1 }, -1 indicates that there is not any problem
            //if the amount of the monoisotopic fragments is more than 6 then the output is {last item code, amount of monoisotopic fragments}
            //as there is not any code equal to -1 the first element of the array indicates if there is a problem
            List<int> mono = new List<int>();
            int[] array = new int[] { -1, 1 };
            int check_amount = 0; //monoisotopic fragments' in current window           
            foreach (FragForm fra in Fragments3)
            {
                double mass = double.Parse(fra.Mz, NumberStyles.AllowDecimalPoint);
                int item_code = fra.Counter;

                if (mass >= selected_all_data[0][starting][0] && mass <= selected_all_data[0][ending][0])
                {
                    mono.Add(item_code);
                    check_amount++;
                }
                if (check_amount > 7) { array = new int[] { item_code, check_amount }; return array; }
                //if (mass > selected_all_data[0][ending][0]) break;
            }
            array[1] =check_amount;
            return array;
        }
        private void start_fit()
        {
            //generateAlphaNumeric();
            //return;
            if (window_count==1)
            {
                if (selectedFragments.Count > 14) { MessageBox.Show("The maximum amount of selected fragments is 14. The fitting algoritm can't operate on more than 14 selected fragments in each fitting section.", "Wrong selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                //generateAlphaNumeric();
                //return;
                // 0. Clear globals
                powerSet.Clear();
                powerSet_distroIdx.Clear();

                // 1. check data integrity
                if (!validate_data()) return;

                // 2. find selected distros for fitting
                List<int> distro_idxs = selectedFragments.OrderBy(p => p).ToList();
                //distro_idxs.RemoveAt(0);

                // 3. align all data to the experimental all_data[0]
                // [m/z point 0] {exp, frag1, frag2, frag3, ... }
                // will be also needed later for plot
                aligned_intensities.Clear();
                aligned_intensities = align_distros(distro_idxs);

                // 4. initiate fitting procedure
                fitted_results.Clear();
                fitted_results = fit_distros(aligned_intensities);

                // 5. display results
                refresh_fit_results(fitted_results);
            }
            //if selected window==1000000 then no window is selected             
            else if (selected_window==1000000)
            {
                MessageBox.Show("Select a window first and then attempt to perform fit! ");
                return;
            }
            else
            {
                windowList[selected_window].PowerSet.Clear();
                windowList[selected_window].PowerSetTodistro.Clear();

                // 1. check data integrity
                if (!validate_data()) return;

                // 2. find selected distros for fitting
                List<int> distro_idxs = selectedFragments.OrderBy(p => p).ToList();
                //distro_idxs.RemoveAt(0);
                find_window_checked_fragments(selected_window);
                if (windowList[selected_window].Checked_mono_fragments.Count>14) { MessageBox.Show("The maximum amount of selected monoisotopic fragments for each window is 14. The fitting algoritm can't operate on more than 14 selected fragments in each fitting section.", "Wrong selection",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return; }
                // 3. align all data to the experimental all_data[0]
                // [m/z point 0] {exp, frag1, frag2, frag3, ... }
                // will be also needed later for plot               
                windowList[selected_window].Aligned.Clear();
                windowList[selected_window].Aligned = align_distros(windowList[selected_window].Checked_mono_fragments);

                //4.initiate fitting procedure
                windowList[selected_window].Fitted.Clear();
                windowList[selected_window].Fitted = fit_distros(windowList[selected_window].Aligned);
                //Fitted is a list of doubles[]:such as res = [frag1_int, frag2_int,...., SSE] sorted according to SSE

                // 5. display results
                refresh_fit_results(windowList[selected_window].Fitted);
            }           
        }

        private void find_window_checked_fragments(int window)
        {            
            windowList[window].Fragments.Clear();
            windowList[window].Checked_mono_fragments.Clear();
            ListView.CheckedListViewItemCollection checkedItems = frag_listView.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                double mass = double.Parse(item.SubItems[1].Text, NumberStyles.AllowDecimalPoint);
                int item_code= Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                if (mass >= all_data[0][windowList[window].Starting][0] && mass <= all_data[0][windowList[window].Ending][0])
                {
                    windowList[window].Fragments.Add(item_code); windowList[window].Checked_mono_fragments.Add(item_code);
                }
                else if (all_data[item_code].Last()[0] >= all_data[0][windowList[window].Starting][0] && all_data[item_code].Last()[0] <= all_data[0][windowList[window].Ending][0])
                {
                    windowList[window].Fragments.Add(item_code);
                }
            }            
            if(window > 1) check_mono_duplicate(window);
        }
        private void find_windows_mono_fragments()
        {
            foreach (FragForm fra in Fragments2)
            {
                double mass = double.Parse(fra.Mz, NumberStyles.AllowDecimalPoint);
                foreach (WindowSet w in windowList)
                {                    
                    int item_code = fra.Counter;
                    if (mass >= all_data[0][w.Starting][0] && mass <= all_data[0][w.Ending][0])
                    {
                        w.Mono_fragments.Add(item_code);
                        break;
                    }
                }
            }
            while (windowList.Last().Mono_fragments.Count() == 0)
            {
                windowList.RemoveAt(windowList.Count() - 1);
                window_count -= 1;

            } 


        }

        private void check_mono_duplicate(int w)
        {            
            if (windowList[w].Checked_mono_fragments.Count==0) { return; }
            if (windowList[w-1].Checked_mono_fragments.Count == 0) { return; }
            List<int> list1 = windowList[w-1].Checked_mono_fragments;
                List<int> list2 = windowList[w].Checked_mono_fragments;
                List<int> rem = new List<int>();
                
                for (int v = 0; v < list1.Count; v++)
                {
                    for (int q = 0; q < list2.Count; q++)
                    {
                        if (list1[v]==list2[q])
                        {
                            rem.Add(q);break;                        
                        }
                        else if (list1[v]<list2[q])
                        {
                            break;
                        }
                    }
                }
                if (rem.Count>0)
                {
                    foreach (int index in rem)
                    {
                        windowList[w].Checked_mono_fragments.RemoveAt(index);
                    }
                }              
        }
        private void refresh_fit_results(List<double[]> fitted_results)
        {
            if (selectedFragments.Count < 3)
            {
                MessageBox.Show("Select at least 2 fragments to perform fitting!");
                return;
            }
            if ( window_count==1)//praktika o kvdikas opvw htan prin
            {
                // 1. clear previous results (UI ctrls and chart)            
                try { bigPanel.Controls.Clear(); }
                catch { }

                Panel pnl = new Panel() { Location = new Point(5, 40), Size = new Size(200, 600), AutoScroll = true };
                pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
                                                                //grpBox.Controls.Add(pnl);

                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
                // we have to convert powerSet to the actual index number of each fragment!!!
                powerSet_to_distroIdx(selectedFragments.OrderBy(p => p).ToList());
                for (int i = 0; i < fitted_results.Count; i++)
                {
                    if (i > 200) { break; }
                    //double[] fit_info in fitted_results
                    Label tmp_lbl = new Label() { TabIndex = i, Location = new Point(5, (i + 1) * 15), AutoSize = true };
                    string txt = "";

                    foreach (int value in powerSet_distroIdx[i]) txt += value.ToString() + " ";
                    txt += "    " + fitted_results[i].Last().ToString("0.###e0" + "  ");
                    for (int j = 0; j < fitted_results[i].Length - 1; j++) txt += "    " + fitted_results[i][j].ToString("0.##e0" + "  ");
                    tmp_lbl.Text = txt;

                    tmp_lbl.Click += (s, e) => { reset_fit_lbl_colors(pnl); tmp_lbl.ForeColor = Color.Red; plot_selected_fit(tmp_lbl); };

                    pnl.Controls.Add(tmp_lbl);
                }

                bigPanel.Controls.Add(pnl);

                // mark with blue the best fit
                Label minSSE_lbl = GetControls(pnl).OfType<Label>().FirstOrDefault(l => l.TabIndex == 0);
                //moy petakse error edw
                minSSE_lbl.ForeColor = Color.Blue;

                plot_selected_fit(minSSE_lbl);
                return;
            }            
            else //a window is selected
            {
                if (windowList[selected_window].Checked_mono_fragments.Count < 2)
                {
                    MessageBox.Show("Select at least 2 fragments to perform fitting!");
                    return;
                }
                // 1. clear previous results (UI ctrls and chart)            

                Panel pnl;
                try {  pnl= GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == selected_window); }
                catch { MessageBox.Show("Error!Panel not found!");return; }
                //Panel pnl = new Panel() { Size = new Size(50, 200), AutoScroll = true, BorderStyle = BorderStyle.FixedSingle, TabIndex = selected_window };
                //pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
                try { pnl.Controls.Clear(); }
                catch { }
                Label window_tab = new Label() { TabIndex = 1000, Dock = DockStyle.Top, Text = windowList[pnl.TabIndex].Code.ToString(),Font = new Font(DefaultFont, FontStyle.Bold), AutoSize = true };
                pnl.Controls.Add(window_tab);
                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
                // we have to convert powerSet to the actual index number of each fragment!!!
                powerSet_to_distroIdx(windowList[selected_window].Checked_mono_fragments,true);
                //for (int i = 0; i < fitted_results.Count; i++)
                for (int i = 0; i < fitted_results.Count; i++)
                {
                    if (i>200) { break; }
                    //double[] fit_info in fitted_results
                    Label tmp_lbl = new Label() { TabIndex = i, Location = new Point(5, (i + 1) * 15), AutoSize = true };
                    string txt = "";
                    foreach (int value in windowList[selected_window].PowerSetTodistro[i]) txt += value.ToString() + " ";
                    txt += "    " + fitted_results[i].Last().ToString("0.###e0" + "  ");
                    for (int j = 0; j < fitted_results[i].Length - 1; j++) txt += "    " + fitted_results[i][j].ToString("0.##e0" + "  ");
                    tmp_lbl.Text = txt;

                    tmp_lbl.DoubleClick += (s, e) => { reset_fit_lbl_colors(pnl); tmp_lbl.ForeColor = Color.Red; plot_selected_fit(tmp_lbl); };

                    pnl.Controls.Add(tmp_lbl);
                }
                pnl.Invalidate();
               

                // mark with blue the best fit
                Label minSSE_lbl = GetControls(pnl).OfType<Label>().FirstOrDefault(l => l.TabIndex == 0);
                //moy petakse error edw
                minSSE_lbl.ForeColor = Color.Blue;
                plot_selected_fit(minSSE_lbl);
                
                return;
            }                      
            
        }
        private void plot_selected_fit(Label tmp_lbl)
        {
            if (window_count==1)
            {
                // 1. adjust corresponding fragment heights
                double[] intensities = fitted_results[tmp_lbl.TabIndex];
                int[] distroIdxs = powerSet_distroIdx[tmp_lbl.TabIndex];
                int[] powerSetIdxs = powerSet[tmp_lbl.TabIndex];
                ListView.CheckedListViewItemCollection checkedItems = frag_listView.CheckedItems;
                // Performance: flag to disable refresh_plot multiple calls from factors_textChanged
                is_applying_fit = true;
                foreach (ListViewItem item in checkedItems)
                {
                    int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                    // run all fragments. If a frag exists in fit then adjust, else set to zero.
                    int idx = Array.IndexOf(distroIdxs, item_code);
                    if (idx > -1) { Fragments2[distroIdxs[idx] - 1].Factor = intensities[idx]; }
                    else { Fragments2[item_code - 1].Factor = 0.0; }
                    item.SubItems[4].Text = Fragments2[item_code - 1].Factor.ToString();
                    item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
                }
               
                is_applying_fit = false;

                // enable disable plot  ???

                refresh_iso_plot();
            }
            else
            {
                //Control pnl_container = tmp_lbl.Parent;
                // 1. adjust corresponding fragment heights

                double[] intensities = windowList[tmp_lbl.Parent.TabIndex].Fitted[tmp_lbl.TabIndex];
                int[] distroIdxs = windowList[tmp_lbl.Parent.TabIndex].PowerSetTodistro[tmp_lbl.TabIndex];
                int[] powerSetIdxs = windowList[tmp_lbl.Parent.TabIndex].PowerSet[tmp_lbl.TabIndex];

                // Performance: flag to disable refresh_plot multiple calls from factors_textChanged
                is_applying_fit = true;
                for (int i = 0; i < windowList[tmp_lbl.Parent.TabIndex].Checked_mono_fragments.Count; i++)
                {
                    int current_counter = windowList[tmp_lbl.Parent.TabIndex].Checked_mono_fragments[i];
                    // run all fragments. If a frag exists in fit then adjust, else set to zero.
                    int idx = Array.IndexOf(distroIdxs, current_counter);
                    if (idx > -1) Fragments2[distroIdxs[idx] - 1].Factor = intensities[idx];
                    else Fragments2[current_counter - 1].Factor = 0.0;
                    foreach (ListViewItem item in frag_listView.Items)
                    {
                        if (item.SubItems[5].Text == current_counter.ToString())
                        {
                            item.SubItems[4].Text = Fragments2[current_counter - 1].Factor.ToString();
                            item.SubItems[6].Text = (Fragments2[current_counter - 1].Factor * Fragments2[current_counter - 1].Fix * Fragments2[current_counter - 1].Centroid[0].Y).ToString();
                            break;
                        }
                    }
                }
                is_applying_fit = false;

                // enable disable plot  ???
                if(refresh_all==false) refresh_iso_plot();

            }
        }
        private void powerSet_to_distroIdx(List<int> distro_idxs,bool window=false)
        {
            if (window)
            {               
                for (int i = 0; i < windowList[selected_window].PowerSet.Count; i++)
                {
                    windowList[selected_window].PowerSetTodistro.Add(new int[windowList[selected_window].PowerSet[i].Length]);

                    for (int j = 0; j < windowList[selected_window].PowerSet[i].Length; j++)
                        windowList[selected_window].PowerSetTodistro[i][j] = distro_idxs[windowList[selected_window].PowerSet[i][j] - 1];
                }
            }
            else
            {
                distro_idxs.RemoveAt(0);
                for (int i = 0; i < powerSet.Count; i++)
                {
                    powerSet_distroIdx.Add(new int[powerSet[i].Length]);

                    for (int j = 0; j < powerSet[i].Length; j++)
                        powerSet_distroIdx[i][j] = distro_idxs[powerSet[i][j] - 1];
                }
            }
            
        }

        private void reset_fit_lbl_colors(Panel pnl)
        {
            //// reset all to black and paint best fit to blue
            Label[] tmp_lbl = GetControls(pnl).OfType<Label>().ToArray();
            foreach (Label lbl in tmp_lbl) lbl.ForeColor = Color.Black;
            tmp_lbl.FirstOrDefault(l => l.TabIndex == 0).ForeColor = Color.Blue;
        }
        private List<double[]> fit_distros(List<double[]> aligned_intensities)
        {
            List<double[]> res = new List<double[]>();

            // this is all the logic of how many time the fitting should run
            // we want to fit every possible combination to get the best result (minimum SSE)
            if (window_count == 1)
            {
                // 1. generate the powerSet. It contains only fragment permutations
                powerSet.Clear();
                //powerSet = generatePowerSet(aligned_intensities[0].Length);

                // build list with numbers
                int total = aligned_intensities[0].Length - 1;
                int[] seq = new int[total];
                for (int i = 0; i < total; i++) seq[i] = i + 1;
                powerSet = FastPowerSet(seq).ToList();
                powerSet.RemoveAt(0);//remove the {0} set

                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities

                ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = powerSet.Count, Size = new Size(227, 23), AutoSize = false };
                user_grpBox.Controls.Add(tlPrgBr);

                double experimental_max = aligned_intensities.Max(element => element[0]);

                foreach (int[] subSet in powerSet)
                {
                    tlPrgBr.Value++;
                    // generate a new list containing only the fragments intensities of the subSet, and the experimental
                    List<double[]> aligned_intensities_subSet = new List<double[]>();//lista tvn tmp gia kathe i

                    for (int i = 0; i < aligned_intensities.Count; i++)//to i einai arithmos metrhshs
                    {
                        // first add experimental
                        double[] tmp = new double[subSet.Length + 1];//tmp=[exp[i] frag1[i] frag2[i] ...]
                        tmp[0] = aligned_intensities[i][0];

                        // then all respective fragments
                        for (int j = 0; j < subSet.Length; j++) tmp[j + 1] = aligned_intensities[i][subSet[j]];

                        aligned_intensities_subSet.Add(tmp);
                    }
                    // get the intensities of the fragments, to pass them to the optimizer as a better starting point
                    List<double> UI_intensities = get_UI_intensities(subSet, experimental_max, true);

                    // call optimizer for the specific subset of fragments
                    res.Add(estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities));
                }
                tlPrgBr.Dispose();

                // sort res and powerSet by least SSE
                // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
                double[][] tmp1 = res.ToArray();
                int[][] tmp2 = powerSet.ToArray();

                IComparer myComparer = new lastElement();
                Array.Sort(tmp1, tmp2, myComparer);

                res = tmp1.ToList();
                powerSet = tmp2.ToList();
            }
            else
            {
                //aligned intensities are about ONLY the checked_mono_fragments
                int w = selected_window;
                int start = windowList[w].Starting;
                int end = windowList[w].Ending;
                // 1. generate the powerSet. It contains only fragment permutations
                windowList[w].PowerSet.Clear();
                //powerSet = generatePowerSet(aligned_intensities[0].Length);

                // build list with numbers
                int total = aligned_intensities[0].Length - 1;
                int[] seq = new int[total];
                for (int i = 0; i < total; i++) seq[i] = i + 1;
                windowList[w].PowerSet = FastPowerSet(seq).ToList();
                windowList[w].PowerSet.RemoveAt(0);//remove the {0} set

                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities

                ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = windowList[w].PowerSet.Count, Size = new Size(227, 23), AutoSize = false };
                user_grpBox.Controls.Add(tlPrgBr);

                double experimental_max = aligned_intensities.Max(element => element[0]);

                foreach (int[] subSet in windowList[w].PowerSet)
                {
                    tlPrgBr.Value++;
                    // generate a new list containing only the fragments intensities of the subSet, and the experimental
                    List<double[]> aligned_intensities_subSet = new List<double[]>();//lista tvn tmp gia kathe i

                    for (int i = 0; i < aligned_intensities.Count; i++)//to i einai arithmos metrhshs
                    {
                        // first add experimental
                        double[] tmp = new double[subSet.Length + 1];//tmp=[exp[i] frag1[i] frag2[i] ...]
                        tmp[0] = aligned_intensities[i][0];

                        // then all respective fragments
                        for (int j = 0; j < subSet.Length; j++) tmp[j + 1] = aligned_intensities[i][subSet[j]];

                        aligned_intensities_subSet.Add(tmp);
                    }
                    // get the intensities of the fragments, to pass them to the optimizer as a better starting point
                    List<double> UI_intensities = get_UI_intensities(subSet, experimental_max, true,true,w);

                    // call optimizer for the specific subset of fragments
                    res.Add(estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities));
                }
                tlPrgBr.Dispose();

                // sort res and powerSet by least SSE
                // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
                double[][] tmp1 = res.ToArray();
                int[][] tmp2 = windowList[w].PowerSet.ToArray();

                IComparer myComparer = new lastElement();
                Array.Sort(tmp1, tmp2, myComparer);

                res = tmp1.ToList();
                windowList[w].PowerSet = tmp2.ToList();
            }
           

            return res;
        }
        public class lastElement : IComparer
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare((x as double[]).Last(), (y as double[]).Last()));
            }

        }

        private double[] estimate_fragment_height_multiFactor(List<double[]> aligned_intensities, List<double> UI_intensities)
        {
            // 1. initialize needed params
            // in coeficients[0] refers to 1st frag, and in aligned_intensities[0] refers to experimental
            // UI_intensities is initial values to make a starting point
            int distros_num = aligned_intensities[0].Length - 1;//osa kai ta fragments pou einai sto subset

            double[] coeficients = UI_intensities.ToArray();
            double[] bndl = new double[distros_num];
            double[] bndh = new double[distros_num];
            for (int i = 0; i < distros_num; i++) { bndl[i] = coeficients[i] * 0.01; bndh[i] = coeficients[i] * 1000.0; }

            double epsx = 0.000001;
            int maxits = 10000;
            alglib.minlmstate state;
            alglib.minlmreport rep;

            alglib.minlmcreatev(distros_num, coeficients, 0.001, out state);
            alglib.minlmsetbc(state, bndl, bndh);                                            // boundary conditions
            alglib.minlmsetcond(state, epsx, maxits);
            alglib.minlmoptimize(state, sse_multiFactor, null, aligned_intensities);
            alglib.minlmresults(state, out coeficients, out rep);

            // 2. save result
            // save all the coefficients and last cell is the minimized value of SSE. result = [frag1_int, frag2_int,...., SSE]
            double[] result = new double[distros_num + 1];
            for (int i = 0; i < distros_num; i++) result[i] = coeficients[i];
            result[distros_num] = state.fi[0];

            return result;
        }
        public void sse_multiFactor(double[] x, double[] func, object aligned_intensities)
        {
            // SSE, objective to minimize
            func[0] = 0;

            List<double[]> exp_and_distros = aligned_intensities as List<double[]>;

            for (int i = 0; i < exp_and_distros.Count; i++)
            {
                double distros_sum = 0.0;

                // get the sum of all distros * the respective factor
                // in params to fit x[0] refers to 1st frag, and in aligned_intensities[0] refers to experimental
                for (int j = 0; j < x.Length; j++)
                    distros_sum += x[j] * exp_and_distros[i][j + 1];

                // SSE
                func[0] += Math.Pow((exp_and_distros[i][0] - distros_sum), 2);
            }
        }

        public T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set
            for (int i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; q++)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

        private bool validate_data()
        {
            // validity controls

            // 1. empty experimental
            if (all_data[0].Count < 10) { MessageBox.Show("Not enough experimental points! (distribution 0)", "Error!"); return false; };

            // 2. none selected or selected is empty distribution to fit
            bool any_selected = false, selected_is_empty = false;
            if (selectedFragments.Count>0)
            {
                any_selected = true;
                foreach (int i in selectedFragments)
                {
                    if (all_data[i].Count < 10) selected_is_empty = true;
                }
            }  
            

            if (!any_selected) { MessageBox.Show("No distribution selected to perform fit!", "Error!"); return false; };
            if (selected_is_empty) { MessageBox.Show("Selected distribution has inadequate data points to perform fit!", "Error!"); return false; };

            return true;
        }
        #endregion

        #region Column Sort
        // This class is an implementation of the 'IComparer' interface.
        public class ListViewItemComparer : IComparer
        {
            // Specifies the column to be sorted
            private int ColumnToSort;

            // Specifies the order in which to sort (i.e. 'Ascending').
            private SortOrder OrderOfSort;

            // Case insensitive comparer object
            private CaseInsensitiveComparer ObjectCompare;

            // Class constructor, initializes various elements
            public ListViewItemComparer()
            {
                // Initialize the column to '1'
                ColumnToSort = 1;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            // This method is inherited from the IComparer interface.
            //
            // x: First object to be compared
            // y: Second object to be compared
            //
            // The result of the comparison. "0" if equal,
            // negative if 'x' is less than 'y' and
            // positive if 'x' is greater than 'y'
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Determine the type being compared  //  Columns: 0:Ion type, 1:m/z, 2:charge ,3:Chemical Formula,4:factor,5:code,6:intensity
                if (Form4.active)
                {
                    try
                    {
                        compareResult = CompareDecimal(listviewX, listviewY);
                    }
                    catch
                    {
                        compareResult = CompareString(listviewX, listviewY);
                    }
                }
                else if (ColumnToSort==0 || ColumnToSort==3)
                {
                    compareResult = CompareString(listviewX, listviewY);
                }
                else
                {
                    try
                    {
                        compareResult = CompareDecimal(listviewX, listviewY);
                    }
                    catch
                    {
                        compareResult = CompareString(listviewX, listviewY);
                    }
                } 

                // Simple String Compare
                // compareResult = String.Compare (
                //  listviewX.SubItems[ColumnToSort].Text,
                //  listviewY.SubItems[ColumnToSort].Text
                // );

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }
            public int CompareDecimal(ListViewItem listviewX, ListViewItem listviewY)
            {
           
                System.Decimal firstValue = Decimal.Parse(listviewX.SubItems[ColumnToSort].Text);
                System.Decimal secondValue = Decimal.Parse(listviewY.SubItems[ColumnToSort].Text);

                // Compare the two dates.
                int compareResult = Decimal.Compare(firstValue, secondValue);
                return compareResult;
            }
            public int CompareString(ListViewItem listviewX, ListViewItem listviewY)
            {
                // Case Insensitive Compare
                int compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text );
                return compareResult;
            }

            // Gets or sets the number of the column to which to
            // apply the sorting operation (Defaults to '0').
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
            // Gets or sets the order of sorting to apply
            // (for example, 'Ascending' or 'Descending').
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }

        #endregion

        #region Fragments' List

        private void copyRowList(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = frag_listView.SelectedItems;
            var text = string.Empty;
            var add = string.Empty;
            if ((sender as MenuItem).Text == "Copy items" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    for (int n = 0; n < 4; n++)
                    {                        
                        add = item.SubItems[n].Text;
                        text += add + "\t";
                    }
                    add = item.SubItems[6].Text;
                    text += add;
                    text += Environment.NewLine;
                }
                Clipboard.SetText(text);
            }
            else if ((sender as MenuItem).Text == "Copy fitted fragments")
            {
                //List<int> sel_idx = selectedFragments.OrderBy(p => p).ToList();
                List<int> sel_idx = new List<int>();
                //sel_idx.RemoveAt(0);
                int panel_count =  window_count;
                //try { panel_count = GetControls(bigPanel).OfType<Panel>().Count(); }
                //catch { }
                if (panel_count > 0)
                {
                    for (int p = 0; p < panel_count; p++)
                    {
                        if (bigPanel.Controls[p].Focused)
                        {
                            sel_idx=windowList[p].Checked_mono_fragments;
                            //int[] panel_frag = new int[windowList[p].PowerSetTodistro[0].Count()];
                            //for (int f = 0; f < windowList[p].PowerSetTodistro[0].Count(); f++)
                            //{
                            //    panel_frag[f] = sel_idx[windowList[p].PowerSetTodistro[0][f]];
                            //}
                            int[] panel_frag = windowList[p].Mono_fragments.ToArray();
                            
                            foreach (ListViewItem item in selectedItems)
                            {
                                int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                                int idx = Array.IndexOf(panel_frag, item_code);
                                if (idx >= 0)
                                {
                                    if (Fragments2[item_code-1].Factor!=0)
                                    {
                                        for (int n = 0; n < 4; n++)
                                        {
                                            add = item.SubItems[n].Text;
                                            text += add + "\t";
                                        }
                                        add = item.SubItems[6].Text;
                                        text += add;
                                        text += Environment.NewLine;
                                    }                                    
                                }
                            }
                            Clipboard.SetText(text);
                            break;
                        }
                    }
                }
            }
        }
        private void colorSelectionList(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = frag_listView.SelectedItems;
            if ((sender as MenuItem).Text == "Fragment color" && selectedItems.Count > 0)
            {
                foreach (ListViewItem item in frag_listView.SelectedItems)
                {
                    ColorDialog clrDlg = new ColorDialog();
                    int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                    if (clrDlg.ShowDialog() == DialogResult.OK) { custom_colors[item_code] = clrDlg.Color.ToArgb(); Fragments2[item_code - 1].Color = OxyColor.FromUInt32((uint)custom_colors[item_code]); refresh_iso_plot(); }
                }
            }
        }
        private void frag_listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // disable 
            if (!is_calc)
            {
                int item_code = Int32.Parse(e.Item.SubItems[5].Text, NumberStyles.Integer);
                if (e.Item.Checked == true)
                {
                    selectedFragments.Add(item_code); Fragments2[item_code - 1].To_plot = true; 
                }
                else
                {
                    selectedFragments.Remove(item_code); Fragments2[item_code - 1].To_plot = false; 
                }

                if (plot_rem_Btns == false)refresh_iso_plot();
            }
        }
        private void factor_Box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(factor_Box.Text))
            {
                if (factor_Box.Text != "-")
                {
                    try
                    {
                        double.Parse(factor_Box.Text, NumberStyles.Number);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Please enter only numbers.Decimal point is inserted with '.'.");
                        factor_Box.Text = null;
                    }
                }

            }
        }
        private void factor_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ListView.SelectedListViewItemCollection items = this.frag_listView.SelectedItems;
                List<int> to_change = new List<int>();
                if (Fragments2.Count > 0)
                {
                    foreach (ListViewItem item in frag_listView.SelectedItems)
                    {
                        int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                        Fragments2[item_code - 1].Factor = double.Parse(factor_Box.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                        factor_Box.Text = Fragments2[item_code - 1].Factor.ToString();
                        item.SubItems[4].Text = Fragments2[item_code - 1].Factor.ToString();
                        item.SubItems[6].Text = (Fragments2[item_code - 1].Factor* Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
                    }
                    if (!is_loading && !is_applying_fit) refresh_iso_plot();
                }
                else
                {
                    MessageBox.Show("List doesn't contain fragments!");
                }
            }

        }
        private void selFrag_Label_Click(object sender, EventArgs e)
        {
            if (Fragments2.Count > 0)
            {
                foreach (ListViewItem item in frag_listView.Items)
                {
                    item.Selected = true;
                }
            }
        }
        private void mark_label_Click(object sender, EventArgs e)
        {
            if (neues > 0)
            {
                if (mark_neues == false)
                {
                    foreach (ListViewItem item in frag_listView.Items)
                    {
                        int item_no = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                        if (item_no > neues)
                        {
                            item.ForeColor = Color.White; item.BackColor = Color.Green;
                        }
                        else
                        {
                            item.ForeColor = Color.Black; item.BackColor = Color.White;
                        }
                    }
                    mark_neues = true;
                }
                else
                {
                    foreach (ListViewItem item in frag_listView.Items)
                    {
                        item.ForeColor = Color.Black; item.BackColor = Color.White;
                    }
                    mark_neues = false;
                }
            }
        }
        private void plot_Btn_Click(object sender, EventArgs e)
        {
            plot_rem_Btns = true;
            ListView.SelectedIndexCollection indeces = frag_listView.SelectedIndices;
            List<FragForm> duplicate = new List<FragForm>();
            foreach (int index in indeces) { frag_listView.Items[index].Checked = true; }
            refresh_iso_plot();
            plot_rem_Btns = false;
        }

        private void remPlot_Btn_Click(object sender, EventArgs e)
        {
            plot_rem_Btns = true;
            ListView.SelectedListViewItemCollection items = this.frag_listView.SelectedItems;
            foreach (ListViewItem item in items) { item.Checked = false; }
            refresh_iso_plot();
            plot_rem_Btns = false;
        }

        private void factor_Box_KeyDown(object sender, KeyEventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.frag_listView.SelectedIndices;
            List<int> to_change = new List<int>();
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                if (Fragments2.Count > 0)
                {
                    if (frag_listView.SelectedItems.Count == 1)
                    {
                        int item_code = Int32.Parse(frag_listView.SelectedItems[0].SubItems[5].Text, NumberStyles.Integer);
                        factor_Box.Text = Fragments2[item_code - 1].Factor.ToString();
                        if (e.KeyData == Keys.Up) { Fragments2[item_code - 1].Factor += keyStep; }
                        else if (e.KeyData == Keys.Down) { Fragments2[item_code - 1].Factor -= keyStep; }
                        factor_Box.Text = Fragments2[item_code - 1].Factor.ToString();
                        frag_listView.SelectedItems[0].SubItems[4].Text = Fragments2[item_code - 1].Factor.ToString();
                        frag_listView.SelectedItems[0].SubItems[6].Text = (Fragments2[item_code - 1].Factor* Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
                        if (!is_loading && !is_applying_fit) { refresh_iso_plot(); }
                    }
                    else
                    {
                        foreach (ListViewItem item in frag_listView.SelectedItems)
                        {
                            int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                            if (e.KeyData == Keys.Up)
                            {
                                Fragments2[item_code - 1].Factor += keyStep;
                                factor_Box.Text = "+" + keyStep.ToString();
                                item.SubItems[4].Text = Fragments2[item_code - 1].Factor.ToString();
                                item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
                                if (!is_loading && !is_applying_fit) refresh_iso_plot();
                            }
                            else if (e.KeyData == Keys.Down)
                            {
                                Fragments2[item_code - 1].Factor -= keyStep;
                                factor_Box.Text = "-" + keyStep.ToString();
                                item.SubItems[4].Text = Fragments2[item_code - 1].Factor.ToString();
                                item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
                                if (!is_loading && !is_applying_fit) refresh_iso_plot();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("List doesn't contain fragments!");
                }
            }
        }

        private void frag_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            factor_Box.Text = null;
            ListView.SelectedIndexCollection indexes = this.frag_listView.SelectedIndices;
            if (Fragments2.Count != 0 && indexes.Count == 1)
            {
                int item_code = Int32.Parse(frag_listView.Items[indexes[0]].SubItems[5].Text, NumberStyles.Integer);
                factor_Box.Text = Fragments2[item_code - 1].Factor.ToString();
            }
        }

        private void frag_listView_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.frag_listView.Sort();
        }
        #endregion

        #region Fitting Options
        private void Fitting_chkBox_CheckedChanged(object sender, EventArgs e)
        {
            refresh_iso_plot();
        }
        
        private void fit_Btn_Click(object sender, EventArgs e)
        {
            Fitting_chkBox.Checked = true;
            if (window_count == 1 && !string.IsNullOrEmpty(fitStep_Box.Text)) { step_Fitting(); if (!is_loading && !is_calc) { /*recalculate_all_data_aligned();*/ refresh_iso_plot(); } }
            start_fit();
            saveFit_Btn.Enabled = true;
        }
        private void fit_all_Btn_Click(object sender, EventArgs e)
        {
            
            if (windowList.Count == 0) { MessageBox.Show("There isn't any window to perform multiple fit", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (bigPanel.Controls.Count == 0) { MessageBox.Show("Something went wrong.Please close the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (selectedFragments.Count() < 3) { MessageBox.Show("Select at least 2 fragments to perform fitting!"); return; }
            Fitting_chkBox.Checked = true;
            if (window_count == 1 && !string.IsNullOrEmpty(fitStep_Box.Text)) { step_Fitting(); if (!is_loading && !is_calc) { /*recalculate_all_data_aligned();*/ refresh_iso_plot(); } }
            
            refresh_all = true;
            for (int w = 0; w < windowList.Count; w++)
            {
                selected_window = w;
                window_colors(w);
                GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == w).BackColor = Color.LightSteelBlue;
                window_graph(w); highlight_selected(w);
                start_fit();
            }
            refresh_iso_plot();
            refresh_all = false;

            saveFit_Btn.Enabled = true;
        }
        private void loadFit_Btn_Click(object sender, EventArgs e)
        {
            clear_data();
            experimental.Clear();
            Fragments2.Clear();
            ChemFormulas.Clear();
            selectedFragments.Clear();
            selectedFragments.TrimExcess();
            windowList.Clear();
            selected_all_data.Clear();
            pep_Box.Text = null;
            UncheckAll();
            clearCalc_Btn.Enabled = false;
            calc_Btn.Enabled = false;
            fitMin_Box.Enabled = false;
            fitMax_Box.Enabled = false;
            fitStep_Box.Enabled = false;
            resolution_Box.Text = null;
            resolution_Box.Enabled = false;
            machine_listBox.Enabled = false;
            machine_listBox.ClearSelected();
            fit_Btn.Enabled = true;
            saveFit_Btn.Enabled = true;
            Fitting_chkBox.Enabled = false;
            loadExp_Btn.Enabled = true;
            loadFit_Btn.Enabled = false;
            loadMS_Btn.Enabled = false;
            loadWd_Btn.Enabled = false;
            saveWd_Btn.Enabled = true;
            neues = 0;
            mark_neues = false;
            load_data();

        }
        private void clear_data()
        {
            reset_all();
        }
        private void load_data()
        {

            OpenFileDialog loadData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";
            loadData.Title = "Load fitting data"; loadData.FileName = "";
            loadData.Filter = "data file|*.wf;*.fit|All files|*.*";

            if (loadData.ShowDialog() != DialogResult.Cancel)
            {

                is_loading = true;  // performance
                fullPath = loadData.FileName;

                #region UI & data                
                experimental.Clear();
                ChemFormulas.Clear();
                pep_Box.Text = null;
                UncheckAll();
                clearCalc_Btn.Enabled = false;
                calc_Btn.Enabled = false;
                resolution_Box.Text = null;
                resolution_Box.Enabled = false;
                machine_listBox.Enabled = false;
                machine_listBox.ClearSelected();
                fit_Btn.Enabled = true;
                saveFit_Btn.Enabled = true;
                loadExp_Btn.Enabled = true;
                loadFit_Btn.Enabled = false;
                loadMS_Btn.Enabled = false;
                selected_all_data.Clear();
                selected_all_data.Add(new List<double[]>());
                loaded_window = false;
                insert_exp = true;
                #endregion
                //if (loadData.DefaultExt== "wf") { loaded_window = true; }

                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);

                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                int arrayPositionIndex = 0;
                int isotope_count = -1;
                int f = Fragments2.Count();

                for (int j = 0; j != (lista.Count); j++)
                {
                    string[] str = new string[5];
                    try
                    {
                        str = lista[j].Split('\t');

                        if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("m/z")) continue; // comments
                        else if (lista[j].StartsWith("Mode")) continue; // to be implemented
                        else if (lista[j].StartsWith("AA")) { Peptide = str[1]; pep_Box.Text = Peptide; }
                        else if (lista[j].StartsWith("Window")) { loaded_window = true; fit_all_Btn.Enabled = true; windowList.Add(new WindowSet() { Code = Int32.Parse(str[1], NumberStyles.Integer), Aligned = new List<double[]>(), All_data = new List<List<double[]>>(), Checked_mono_fragments = new List<int>(), Ending = new int(), Fitted = new List<double[]>(), Fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Starting = new int() }); }
                        else if (lista[j].StartsWith("Starting")) windowList.Last().Starting = Int32.Parse(str[1], NumberStyles.Integer);
                        else if (lista[j].StartsWith("Ending")) windowList.Last().Ending = Int32.Parse(str[1], NumberStyles.Integer);
                        else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                        else if (lista[j].StartsWith("Name"))
                        {
                            // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                            isotope_count++;
                            if (isotope_count == 0 && all_data.Count > 0)//experimental
                            {
                                all_data[0].Clear();
                                if (custom_colors.Count > 0) custom_colors[0] = OxyColors.Black.ToColor().ToArgb();
                                else custom_colors.Add(OxyColors.Black.ToColor().ToArgb());
                            }
                            else if (isotope_count == 0)//experimental
                            {
                                all_data.Add(new List<double[]>());
                                if (custom_colors.Count > 0) custom_colors[0] = OxyColors.Black.ToColor().ToArgb();
                                else custom_colors.Add(OxyColors.Black.ToColor().ToArgb());
                            }
                            else//fragments
                            {
                                f++;
                                Fragments2.Add(new FragForm() { Name = str[1], Centroid = new List<PointPlot>(), Factor = 1.0, Fix = 1.0, Charge = 0, Mz = "", Radio_label = "", ListName = new string[4], Color = new OxyColor(), To_plot = false, Counter = f });
                                all_data.Add(new List<double[]>());
                                if (loaded_window == true) { windowList.Last().Mono_fragments.Add(f); }
                            }
                        }
                        else if (lista[j].StartsWith("Factor")) { Fragments2.Last().Factor = dParser(str[1]); }
                        else if (lista[j].StartsWith("Fix")) { Fragments2.Last().Fix = dParser(str[1]); }
                        else if (lista[j].StartsWith("Cen")) { Fragments2.Last().Centroid.Add(new PointPlot { Y = dParser(str[2]) ,X = dParser(str[1]) }); }
                        else if (lista[j].StartsWith("ListViewItems"))
                        {
                            Fragments2.Last().ListName = new string[] { str[1], str[2], str[3], str[4] };
                            Fragments2.Last().Mz = Fragments2.Last().ListName[1].ToString();
                            Fragments2.Last().Charge = Int32.Parse(Fragments2.Last().ListName[2]);
                            Fragments2.Last().Radio_label = Fragments2.Last().ListName[0].ToString();
                        }
                        else if (lista[j].StartsWith("Selected"))
                        {
                            Fragments2.Last().To_plot = str[1] == "True";
                        }
                        else if (lista[j].StartsWith("Color")) { custom_colors.Add(Convert.ToInt32(str[1])); Fragments2.Last().Color = OxyColor.FromUInt32((uint)custom_colors.Last()); }
                        else if (isotope_count == 0) { experimental.Add(new double[] { dParser(str[0]), dParser(str[1]) }); all_data[0].Add(new double[] { dParser(str[0]), dParser(str[1]) }); selected_all_data[0].Add(new double[] { dParser(str[0]), dParser(str[1]) }); }
                        else { all_data[isotope_count].Add(new double[] { dParser(str[0]), dParser(str[1]) }); }
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                    arrayPositionIndex++;
                }
                if (loaded_window == true) { window_count = windowList.Count; }
                fitMin_Box.Enabled = false;
                fitMax_Box.Enabled = false;
                fitStep_Box.Enabled = false;
                fitMin_Box.Text = experimental[0][0].ToString();
                fitMax_Box.Text = experimental[all_data[0].Count - 1][0].ToString();
                //_lvwItemComparer = new ListViewItemComparer();
                //Initialize_listviewComparer();                                

                is_loading = false;
                //add experimental to plot
                selectedFragments.Add(0);
                // post load actions                                
                recalculate_all_data_aligned();
                refresh_iso_plot();
                //listview
                frag_listView.BeginUpdate();
                frag_listView.Items.Clear();
                foreach (FragForm fra in Fragments2)
                {
                    var listviewitem = new ListViewItem(fra.ListName);
                    listviewitem.SubItems.Add(fra.Factor.ToString());
                    listviewitem.SubItems.Add(fra.Counter.ToString());
                    listviewitem.SubItems.Add((fra.Factor * fra.Fix * fra.Centroid[0].Y).ToString());
                    if (fra.To_plot == true) { listviewitem.Checked = true; }
                    frag_listView.Items.Add(listviewitem);
                }

                if (loaded_window == true)
                {
                    //create panels
                    iso_plot.Model.Annotations.Clear();
                    create_step_panels();
                }
                if (loaded_window == false)
                {
                    fitMin_Box.Enabled = true;
                    fitMax_Box.Enabled = true;
                    fitStep_Box.Enabled = true;
                }

                frag_listView.EndUpdate();
                Fitting_chkBox.Enabled = true;
                // post load actions                                
                recalculate_all_data_aligned();
                refresh_iso_plot();

            }

        }
        private void new_Btn_Click(object sender, EventArgs e)
        {
            clear_data();
            insert_exp = false;
            saveFit_Btn.Enabled = false;
            loadMS_Btn.Enabled = true;
            loadFit_Btn.Enabled = true;
            clearCalc_Btn.Enabled = false;
            calc_Btn.Enabled = false;
            fitMin_Box.Enabled = false;
            fitMin_Box.Text = null;
            fitMax_Box.Enabled = false;
            fitMax_Box.Text = null;
            fitStep_Box.Enabled = false;
            fitStep_Box.Text = null;
            step_rangeBox.Text = null;
            Fitting_chkBox.Checked = false;
            Fitting_chkBox.Enabled = false;
            Fragments2.Clear();
            ChemFormulas.Clear();
            selectedFragments.Clear();
            selectedFragments.TrimExcess();
            pep_Box.Text = null;
            counter = 0;
            frag_listView.Items.Clear();
            UncheckAll();
            resolution_Box.Text = null;
            machine_listBox.ClearSelected();
            machine_listBox.SelectedIndex = 2;
            loadExp_Btn.Enabled = true;
            selected_window = 1000000;
            bigPanel.Controls.Clear();
            factor_Box.Text = null;
            candidate_fragments = 1;
            mzMax_Box.Enabled = false;
            mzMin_Box.Enabled = false;
            mzMax_Label.Enabled = false;
            mzMin_Label.Enabled = false;
            chargeMax_Box.Enabled = false;
            chargeMin_Box.Enabled = false;
            chargeAll_Btn.Enabled = false;
            idxPr_Box.Enabled = false;
            idxTo_Box.Enabled = false;
            idxFrom_Box.Enabled = false;
            resolution_Box.Enabled = false;
            machine_listBox.Enabled = false;
            saveWd_Btn.Enabled = false;
            windowList.Clear();
            loaded_window = false;
            fit_all_Btn.Enabled = false;
            neues = 0;
            mark_neues = false;
            Form4.active = false;
        }
        private void saveFit_Btn_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            //save_data();
        }
        private void saveWd_Btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = file_name + "_w" + windowList[selected_window].Code.ToString(), Filter = "Data Files (*.wnd)|*.wnd", DefaultExt = "wnd", OverwritePrompt = true, AddExtension = true };

            //save.InitialDirectory = Application.StartupPath + "\\Data";
            //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
            //if (di.Exists != true) di.Create();

            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                file.WriteLine("Mode:\texternal data");
                file.WriteLine("AA Sequence:\t" + Peptide);
                file.WriteLine("Window:\t" + windowList[selected_window].Code.ToString());
                file.WriteLine("Starting:\t" + windowList[selected_window].Starting);
                file.WriteLine("Ending:\t" + windowList[selected_window].Ending);
                file.WriteLine("Fitted isotopes:\t" + candidate_fragments.ToString());
                file.WriteLine("m/z[Da]\tIntensity");
                file.WriteLine();
                file.WriteLine("Name:\tExp");
                foreach (double[] p in selected_all_data[0]) file.WriteLine(p[0] + "\t" + p[1]);
                for (int i = 0; i < windowList[selected_window].Fragments.Count; i++)
                {
                    int indexS = windowList[selected_window].Fragments[i];
                    file.WriteLine("Name:\t" + Fragments2[indexS - 1].Name);
                    file.WriteLine("Factor:\t" + Fragments2[indexS - 1].Factor);
                    file.WriteLine("Fix:\t" + Fragments2[indexS - 1].Fix);
                    file.WriteLine("ListViewItems:\t" + Fragments2[indexS - 1].ListName[0].ToString() + "\t" + Fragments2[indexS - 1].ListName[1].ToString() + "\t" + Fragments2[indexS - 1].ListName[2].ToString() + "\t" + Fragments2[indexS - 1].ListName[3].ToString());
                    file.WriteLine("Selected:\t" + Fragments2[indexS - 1].To_plot.ToString());
                    file.WriteLine("Color:\t" + Fragments2[indexS - 1].Color.ToColor().ToArgb());
                    foreach (double[] p in all_data[indexS]) file.WriteLine(p[0] + "\t" + p[1]);
                }
                file.Flush(); file.Close(); file.Dispose();
            }
        }
        private void loadWd_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";
            loadData.Title = "Load fitting data"; loadData.FileName = "";
            loadData.Filter = "data file|*.wnd|All files|*.*";

            if (loadData.ShowDialog() != DialogResult.Cancel)
            {

                is_loading = true;  // performance
                fullPath = loadData.FileName;

                #region UI & data                
                experimental.Clear();
                ChemFormulas.Clear();
                pep_Box.Text = null;
                UncheckAll();
                clearCalc_Btn.Enabled = false;
                calc_Btn.Enabled = false;
                resolution_Box.Text = null;
                resolution_Box.Enabled = false;
                machine_listBox.Enabled = false;
                machine_listBox.ClearSelected();
                fit_Btn.Enabled = true;
                saveFit_Btn.Enabled = true;
                loadExp_Btn.Enabled = true;
                loadFit_Btn.Enabled = false;
                loadMS_Btn.Enabled = false;
                selected_all_data.Clear();
                selected_all_data.Add(new List<double[]>());
                loaded_window = false;
                insert_exp = true;
                fit_all_Btn.Enabled = true;
                #endregion

                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);

                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                int arrayPositionIndex = 0;
                int isotope_count = -1;
                int f = Fragments2.Count();

                for (int j = 0; j != (lista.Count); j++)
                {
                    string[] str = new string[5];
                    try
                    {
                        str = lista[j].Split('\t');

                        if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("m/z")) continue; // comments
                        else if (lista[j].StartsWith("Mode")) continue; // to be implemented
                        else if (lista[j].StartsWith("AA")) { Peptide = str[1]; pep_Box.Text = Peptide; }
                        else if (lista[j].StartsWith("Window")) { windowList.Add(new WindowSet() { Code = Int32.Parse(str[1], NumberStyles.Integer), Aligned = new List<double[]>(), All_data = new List<List<double[]>>(), Checked_mono_fragments = new List<int>(), Ending = new int(), Fitted = new List<double[]>(), Fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Starting = new int() }); }
                        else if (lista[j].StartsWith("Starting")) windowList.Last().Starting = Int32.Parse(str[1], NumberStyles.Integer);
                        else if (lista[j].StartsWith("Ending")) windowList.Last().Ending = Int32.Parse(str[1], NumberStyles.Integer);
                        else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                        else if (lista[j].StartsWith("Name"))
                        {
                            // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                            isotope_count++;
                            if (isotope_count == 0 && all_data.Count > 0)//experimental
                            {
                                all_data[0].Clear();
                                if (custom_colors.Count > 0) custom_colors[0] = OxyColors.Black.ToColor().ToArgb();
                                else custom_colors.Add(OxyColors.Black.ToColor().ToArgb());
                            }
                            else if (isotope_count == 0)//experimental
                            {
                                all_data.Add(new List<double[]>());
                                if (custom_colors.Count > 0) custom_colors[0] = OxyColors.Black.ToColor().ToArgb();
                                else custom_colors.Add(OxyColors.Black.ToColor().ToArgb());
                            }
                            else//fragments
                            {
                                f++;
                                Fragments2.Add(new FragForm() { Name = str[1], Factor = 1.0, Fix = 1.0, Charge = 0, Mz = "", Radio_label = "", ListName = new string[4], Color = new OxyColor(), To_plot = false, Counter = f });
                                all_data.Add(new List<double[]>());
                                windowList.Last().Fragments.Add(f);
                            }
                        }
                        else if (lista[j].StartsWith("Factor")) { Fragments2.Last().Factor = dParser(str[1]); }
                        else if (lista[j].StartsWith("Fix")) { Fragments2.Last().Fix = dParser(str[1]); }
                        else if (lista[j].StartsWith("Cen")) { Fragments2.Last().Centroid.Add(new PointPlot { Y = dParser(str[2]), X = dParser(str[1]) }); }
                        else if (lista[j].StartsWith("ListViewItems"))
                        {
                            Fragments2.Last().ListName = new string[] { str[1], str[2], str[3], str[4] };

                        }
                        else if (lista[j].StartsWith("Selected"))
                        {
                            int c = frag_listView.Items.Count;
                            if (str[1] == "True") { selectedFragments.Add(f); Fragments2.Last().To_plot = true; }
                        }
                        else if (lista[j].StartsWith("Color")) { custom_colors.Add(Convert.ToInt32(str[1])); Fragments2.Last().Color = OxyColor.FromUInt32((uint)custom_colors.Last()); }
                        else if (isotope_count == 0) { experimental.Add(new double[] { dParser(str[0]), dParser(str[1]) }); all_data[0].Add(new double[] { dParser(str[0]), dParser(str[1]) }); selected_all_data[0].Add(new double[] { dParser(str[0]), dParser(str[1]) }); }
                        else { all_data[isotope_count].Add(new double[] { dParser(str[0]), dParser(str[1]) }); }
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                    arrayPositionIndex++;
                }
                window_count = windowList.Count;
                fitMin_Box.Enabled = false;
                fitMax_Box.Enabled = false;
                fitStep_Box.Enabled = false;
                Fitting_chkBox.Enabled = true;
                fitMin_Box.Text = experimental[0][0].ToString();
                fitMax_Box.Text = experimental[all_data[0].Count - 1][0].ToString();
                //_lvwItemComparer = new ListViewItemComparer();
                //Initialize_listviewComparer();                                

                is_loading = false;
                //add experimental to plot
                selectedFragments.Add(0);
                //listview
                frag_listView.BeginUpdate();
                frag_listView.Items.Clear();
                foreach (FragForm fra in Fragments2)
                {
                    var listviewitem = new ListViewItem(fra.ListName);
                    listviewitem.SubItems.Add(fra.Factor.ToString());
                    listviewitem.SubItems.Add(fra.Counter.ToString());
                    listviewitem.SubItems.Add((fra.Factor* fra.Fix * fra.Centroid[0].Y).ToString());
                    if (fra.To_plot == true) { listviewitem.Checked = true; }
                    frag_listView.Items.Add(listviewitem);
                    fra.Mz = fra.ListName[1];
                    fra.Charge = Int32.Parse(fra.ListName[2]);
                    fra.Radio_label = fra.ListName[0];
                }
                frag_listView.EndUpdate();
                //create panels
                iso_plot.Model.Annotations.Clear();                
                find_windows_mono_fragments();
                create_step_panels();
                // post load actions                                
                recalculate_all_data_aligned();
                refresh_iso_plot();
            }
        }


        #endregion

        #region Calculation Options
        private void ClearCalc_Btn_Click(object sender, EventArgs e)
        {
            UncheckAll();
        }

        private void SaveCalc_Btn_Click(object sender, EventArgs e)
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            folderName = Path.Combine(folderName, "EnviPat_Results");
            System.IO.Directory.CreateDirectory(folderName);
            string fileProfile = Peptide + ".txt";
            folderName = Path.Combine(folderName, fileProfile);
            using (StreamWriter writer = new StreamWriter(folderName, append: true))
            {
                writer.WriteLine("Spectrum calculation");
                writer.WriteLine("Peptide Sequence:" + Peptide);
                int v = 1;
                foreach (FragForm chem in Fragments2)
                {
                    writer.WriteLine("Fragment " + v.ToString() + " " + Peptide);
                    foreach (PointPlot p in chem.Profile)
                    {
                        writer.WriteLine(p.X + " " + p.Y);
                    }
                    v++;
                }
            }
            saveCalc_Btn.Enabled = false;
        }

        private void refix_data_to_max_exp()
        {
            foreach (FragForm fra in Fragments2)
            {
                fra.Fix = 0.2 * max_exp / fra.Max_intensity;
            }
            foreach (ListViewItem item in frag_listView.Items)
            {
                int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
            }

        }
        private void plot_peak()
        {

            iso_plot.Model.Series.Add(new LineSeries() { StrokeThickness = 2, Color = OxyColors.Red, LineStyle = LineStyle.Dash });
            (iso_plot.Model.Series[2] as LineSeries).Title = "Peak";
            for (int j = 0; j < peak_points.Count; j++)
            {
                (iso_plot.Model.Series[2] as LineSeries).Points.Add(new OxyPlot.DataPoint(peak_points[j][1], peak_points[j][2]));
            }
            iso_plot.Model.InvalidatePlot(true);
        }
        private string fix_formula(string input, bool simple = true,int h=-1, int h2o = 0, int nh3 = 0)
        {
            string formula = "";
            if (simple == true) { formula = find_index_fix_formula(input,h); return formula; }
            if (h2o > 0)
            {
                input = find_index_fix_formula(input,- 2 * h2o, 'H');
                input = find_index_fix_formula(input, -h2o, 'O');
            }
            if (nh3 > 0)
            {
                input = find_index_fix_formula(input, -3 * h2o,'H');
                input = find_index_fix_formula(input,- nh3,'N');
            }
            formula = input;
            return formula;
        }
        private string find_index_fix_formula(string input, int amount = -1, char element = 'H')
        {
            int idx = input.IndexOf(element);
            var theString = input;
            var aStringBuilder = new StringBuilder(theString);
            if (Char.IsNumber(input[idx + 2]))
            {
                if (Char.IsNumber(input[idx + 3]))
                {
                    Int32.TryParse(theString.Substring(idx + 1, 3), out int result);
                    aStringBuilder.Remove(idx + 1, 3);
                    aStringBuilder.Insert(idx + 1, (result + amount).ToString());
                    theString = aStringBuilder.ToString();
                    input = theString;
                }
                else
                {
                    Int32.TryParse(theString.Substring(idx + 1, 2), out int result);
                    aStringBuilder.Remove(idx + 1, 2);
                    aStringBuilder.Insert(idx + 1, (result + amount).ToString());
                    theString = aStringBuilder.ToString();
                    input = theString;
                }
            }
            else
            {
                Int32.TryParse(theString.Substring(idx + 1, 1), out int result);
                aStringBuilder.Remove(idx + 1, 1);
                aStringBuilder.Insert(idx + 1, (result + amount).ToString());
                theString = aStringBuilder.ToString();
                input = theString;
            }

            return input;
        }
        private void customRes_Btn_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            frm4.FormClosing += (s, f) => { add_machine(false); };
        }
        private void add_machine(bool exp_resolution = false)
        {
            string name = "";
            if (exp_resolution == true)
            {
                name = "resolution from file" + exp_res.ToString();
            }
            else if (!Form4.new_machine.Equals("no"))
            {
                name = Form4.new_machine;
            }
            else return;
            for (int i1 = 0; i1 < machine_listBox.Items.Count; i1++)
            {
                string m = (string)machine_listBox.Items[i1];
                if (m.Equals(name)) { return; }
            }

            machine_listBox.Invoke(new Action(() => machine_listBox.ClearSelected()));   //thread safe call
            machine_listBox.Invoke(new Action(() => machine_listBox.Items.Add(name)));   //thread safe call
            machine_listBox.Invoke(new Action(() => machine_listBox.SelectedItem = name));   //thread safe call
        }


        

        #endregion

        #region Calculate
        private void Calc_Btn_Click(object sender, EventArgs e)
        {
            sw1.Reset(); sw1.Start();
            is_calc = true;
            #region check if resolution inputs are correct and then calculate
            if (string.IsNullOrEmpty(resolution_Box.Text) && machine_listBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("You need to set a Resolution value. " +
                                        "You can either select the machine used or complete the 'Resolution' text box.");

            }
            else if (machine_listBox.SelectedItems.Count == 0 && float.Parse(resolution_Box.Text, CultureInfo.InvariantCulture.NumberFormat) < 1)
            {
                MessageBox.Show("Please choose a resolution higher or equal to 1");
            }
            else
            {
                List<ChemiForm> Selected_options = new List<ChemiForm>();
                Selected_options = ChemFormulas;
                List<int[]> selectedIndex1 = new List<int[]>();
                List<int[]> selectedIndex2 = new List<int[]>();
                HashSet<int> selectedPrimaryIndex = new HashSet<int>();
                #region m/z boundaries opptions
                if (!string.IsNullOrEmpty(mzMax_Box.Text) && !string.IsNullOrEmpty(mzMin_Box.Text))
                {
                    List<ChemiForm> keeplistitem = new List<ChemiForm>();
                    double max = Double.Parse(Selected_options.Last().Mz, CultureInfo.InvariantCulture.NumberFormat);
                    double min = 0.0;
                    if (!string.IsNullOrEmpty(mzMax_Box.Text))
                    {
                        max = Double.Parse(mzMax_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    if (!string.IsNullOrEmpty(mzMin_Box.Text))
                    {
                        min = Double.Parse(mzMin_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    foreach (ChemiForm chem in Selected_options)
                    {
                        double mz = Double.Parse(chem.Mz, CultureInfo.InvariantCulture.NumberFormat);
                        if (mz <= max && mz >= min)
                        {
                            keeplistitem.Add(chem);
                        }
                        else if (mz>max)
                        {
                            break;
                        }
                    }
                    Selected_options = keeplistitem;
                }
                #endregion

                #region charge options
                if (!string.IsNullOrEmpty(chargeMax_Box.Text) || !string.IsNullOrEmpty(chargeMin_Box.Text))
                {
                    List<ChemiForm> keeplistitem = new List<ChemiForm>();
                    double max = 25;
                    double min = 0.0;
                    if (!string.IsNullOrEmpty(chargeMax_Box.Text))
                    {
                        max = Double.Parse(chargeMax_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    if (!string.IsNullOrEmpty(chargeMin_Box.Text))
                    {
                        min = Double.Parse(chargeMin_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    foreach (ChemiForm chem in Selected_options)
                    {
                        int charge = chem.Charge;
                        if (charge <= max && charge >= min)
                        {
                            keeplistitem.Add(chem);
                        }
                    }
                    Selected_options = keeplistitem;
                }
                #endregion

                #region ion mode options            
                if (addin_lstBox.SelectedItems.Count > 0 || a_lstBox.SelectedItems.Count > 0 || b_lstBox.SelectedItems.Count > 0 || c_lstBox.SelectedItems.Count > 0 || x_lstBox.SelectedItems.Count > 0 || y_lstBox.SelectedItems.Count > 0 || z_lstBox.SelectedItems.Count > 0 || internal_lstBox.SelectedItems.Count > 0 || dvw_lstBox.SelectedItems.Count > 0)
                {
                    List<ChemiForm> keeplistitem = new List<ChemiForm>();
                    //add-in list box
                    if (addin_lstBox.CheckedItems.Count > 0)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            string ion_type_sub = chem.Ion_type.Substring(0, 1);
                            if (chem.Ion_type.Length > 4)
                            {
                                foreach (string ion in addin_lstBox.CheckedItems)
                                {
                                    string form = ion.Substring(0, 1);
                                    if (ion.Contains("H2O") && ion.Contains("NH3"))
                                    {
                                        if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("NH3") && chem.Ion_type.Contains("H2O"))
                                        {
                                            keeplistitem.Add(chem.DeepCopy()); break;
                                        }
                                    }
                                    else if (ion.Contains("H2O"))
                                    {
                                        if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("H2O") && !chem.Ion_type.Contains("NH3"))
                                        {
                                            keeplistitem.Add(chem.DeepCopy()); break;
                                        }
                                    }
                                    else
                                    {
                                        if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("NH3") &&!chem.Ion_type.Contains("H2O"))
                                        {
                                            keeplistitem.Add(chem.DeepCopy()); break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    //a list box
                    if (a_lstBox.CheckedItems.Count > 0)
                    {

                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("a"))
                            {
                                foreach (string ion in a_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);
                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Adduct = "H" + c.ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";

                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("a", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("a", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);

                                        keeplistitem.Last().Ion_type="("+ion+")";
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("a", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("a", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //b list box
                    if (b_lstBox.CheckedItems.Count > 0)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("b"))
                            {
                                foreach (string ion in b_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Adduct = "H" + c.ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";                                           
                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";     
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("b", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("b", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        keeplistitem.Last().Ion_type = "(" + ion + ")";
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("b", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("b", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //c list box
                    if (c_lstBox.CheckedItems.Count > 0)
                    {

                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("c"))
                            {
                                foreach (string ion in c_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Adduct = "H" + c.ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";                                            
                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";     
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("c", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("c", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        keeplistitem.Last().Ion_type = "(" + ion + ")";
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("c", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("c", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //y list box
                    if (y_lstBox.CheckedItems.Count > 0)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("y"))
                            {
                                foreach (string ion in y_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";                                            
                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";             
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("y", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("y", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        keeplistitem.Last().Ion_type = "(" + ion + ")";
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true,-c);
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("y", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("y", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //x list box
                    if (x_lstBox.CheckedItems.Count > 0)
                    {

                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("x"))
                            {
                                foreach (string ion in x_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Adduct = "H" + c.ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";                                            
                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";       
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("x", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("x", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        keeplistitem.Last().Ion_type = "(" + ion + ")";
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("x", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("x", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //z list box
                    if (z_lstBox.CheckedItems.Count > 0)
                    {

                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Equals("z"))
                            {
                                foreach (string ion in z_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("+"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        if (keeplistitem.Last().Charge > 1)
                                        {
                                            int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

                                            c += keeplistitem.Last().Charge - 1;
                                            keeplistitem.Last().Adduct = "H" + c.ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";                                            
                                        }
                                        else
                                        {
                                            keeplistitem.Last().Adduct = "H" + ion[2].ToString();
                                            keeplistitem.Last().Ion_type = "(" + ion + ")";      
                                            keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint)+ 1.007825).ToString() ;
                                            keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

                                        }
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("z", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("z", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString1;

                                    }
                                    else if (ion.Contains("-"))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                        keeplistitem.Last().Deduct += "H" + ion[2];
                                        keeplistitem.Last().Ion_type = "(" + ion + ")";
                                        int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
                                        keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c* 1.007825)).ToString();
                                        keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
                                        var radioString = keeplistitem.Last().Radio_label;
                                        var radioBuider = new StringBuilder(radioString);
                                        radioBuider.Replace("z", "(" + ion + ")");
                                        radioString = radioBuider.ToString();
                                        keeplistitem.Last().Radio_label = radioString;
                                        var radioString1 = keeplistitem.Last().Name;
                                        var radioBuider1 = new StringBuilder(radioString1);
                                        radioBuider1.Replace("z", "(" + ion + ")");
                                        radioString1 = radioBuider1.ToString();
                                        keeplistitem.Last().Name = radioString;

                                    }
                                    else
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                        }

                    }
                    //internal list box
                    if (internal_lstBox.CheckedItems.Count > 0)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Ion_type.Length > 8 && chem.Ion_type.Contains("int"))
                            {
                                foreach (string ion in internal_lstBox.CheckedItems)
                                {
                                    if (ion.Contains("b") && chem.Ion_type.Contains("b"))
                                    {
                                        if (ion.Contains("H2O") )
                                        {
                                            if (chem.Ion_type.Contains("H2O"))
                                            {
                                                if (ion.Contains("NH3"))
                                                {
                                                    if (chem.Ion_type.Contains("NH3"))
                                                    {
                                                        keeplistitem.Add(chem.DeepCopy()); break;
                                                    }
                                                }
                                                else if(!chem.Ion_type.Contains("NH3"))
                                                {
                                                    keeplistitem.Add(chem.DeepCopy()); break;
                                                }
                                            }
                                            
                                        }
                                        else if (ion.Contains("NH3"))
                                        {
                                            if (chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
                                            {
                                                keeplistitem.Add(chem.DeepCopy()); break;
                                            }                                            
                                        }
                                        else if(!chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
                                        {
                                            keeplistitem.Add(chem.DeepCopy()); break;
                                        }
                                    }
                                    else if (chem.Ion_type.Contains(" a"))
                                    {
                                        if (ion.Contains("H2O") )
                                        {
                                            if (chem.Ion_type.Contains("H2O"))
                                            {
                                                if (ion.Contains("NH3"))
                                                {
                                                    if (chem.Ion_type.Contains("NH3"))
                                                    {
                                                        keeplistitem.Add(chem.DeepCopy()); break;
                                                    }
                                                }
                                                else if(!chem.Ion_type.Contains("NH3"))
                                                {
                                                    keeplistitem.Add(chem.DeepCopy()); break;
                                                }
                                            }                                            
                                        }
                                        else if (ion.Contains("NH3"))
                                        {
                                            if (chem.Ion_type.Contains("NH3")&&!chem.Ion_type.Contains("H2O"))
                                            {
                                                keeplistitem.Add(chem.DeepCopy()); break;
                                            }                                           
                                        }
                                        else if(!chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
                                        {
                                            keeplistitem.Add(chem.DeepCopy()); break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    //dvw list box               
                    if (dvw_lstBox.CheckedItems.Count > 0)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            foreach (string ion in dvw_lstBox.CheckedItems)
                            {
                                if (chem.Ion_type.Equals(ion))
                                {
                                    keeplistitem.Add(chem.DeepCopy()); break;
                                }
                            }
                        }

                    }
                    Selected_options = keeplistitem;
                }
                #endregion

                #region index options //--> prepei na rwtisw
                if (!string.IsNullOrEmpty(idxPr_Box.Text) || !string.IsNullOrEmpty(idxTo_Box.Text) || !string.IsNullOrEmpty(idxFrom_Box.Text))
                {
                    //primary index --> 1 input number that indicates the min index number that the formula must have to be calculated 
                    List<ChemiForm> keeplistitem = new List<ChemiForm>();
                    if (!string.IsNullOrEmpty(idxPr_Box.Text))
                    {
                        string[] inputs = Regex.Split(idxPr_Box.Text, ",");
                        string[] my_ions = new string[] { "a", "b", "c", "x", "y", "z", "d", "v", "w" };

                        if (my_ions.Any(inputs[0].Contains))
                        {
                            foreach (string word in inputs)
                            {
                                string type = word[0].ToString();
                                string primin = word.Substring(1);
                                if (primin.Contains("-"))
                                {
                                    string[] wordTo = Regex.Split(primin, "-");
                                    int pr1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
                                    int pr2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
                                    int pr_ = pr1;
                                    while (pr_ <= pr2)
                                    {
                                        selectedPrimaryIndex.Add(pr_);
                                        pr_++;
                                    }
                                }
                                else
                                {
                                    int to = int.Parse(primin, CultureInfo.InvariantCulture.NumberFormat);
                                    while (to <= Peptide.Length)
                                    {
                                        selectedPrimaryIndex.Add(to); to++;
                                    }
                                }
                                foreach (ChemiForm chem in Selected_options)
                                {
                                    if (chem.Ion_type.Equals(type))
                                    {
                                        int index = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
                                        int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
                                        if (index == indexTo && selectedPrimaryIndex.Contains(index))
                                        {
                                            keeplistitem.Add(chem.DeepCopy());
                                        }
                                    }
                                }
                                selectedPrimaryIndex.Clear();
                                selectedPrimaryIndex.TrimExcess();
                            }
                        }
                        else
                        {
                            foreach (string word in inputs)
                            {
                                if (word.Contains("-"))
                                {
                                    string[] wordTo = Regex.Split(word, "-");
                                    int pr1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
                                    int pr2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
                                    int pr_ = pr1;
                                    while (pr_ <= pr2)
                                    {
                                        selectedPrimaryIndex.Add(pr_); pr_++;
                                    }
                                }
                                else
                                {
                                    int to = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat);
                                    while (to <= Peptide.Length)
                                    {
                                        selectedPrimaryIndex.Add(to); to++;
                                    }
                                }
                            }
                            foreach (ChemiForm chem in Selected_options)
                            {
                                int index = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
                                int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
                                if (index == indexTo)
                                {
                                    if (selectedPrimaryIndex.Contains(index))
                                    {
                                        keeplistitem.Add(chem.DeepCopy());
                                    }
                                }
                            }
                            selectedPrimaryIndex.Clear();
                            selectedPrimaryIndex.TrimExcess();
                        }
                    }
                    if (!string.IsNullOrEmpty(idxTo_Box.Text) && !string.IsNullOrEmpty(idxFrom_Box.Text))
                    {
                        string[] inputsTo = Regex.Split(idxTo_Box.Text, ",");
                        string[] inputsFrom = Regex.Split(idxFrom_Box.Text, ",");
                        foreach (string word in inputsTo)
                        {
                            List<int> indeces = new List<int>();
                            if (word.Contains("-"))
                            {
                                string[] wordTo = Regex.Split(word, "-");
                                int to1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
                                int to2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
                                int to_ = to1;
                                while (to_ <= to2)
                                {
                                    indeces.Add(to_);
                                    to_++;
                                }
                            }
                            else
                            {
                                int to = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat);
                                indeces.Add(to);
                            }
                            selectedIndex2.Add(indeces.ToArray());
                        }
                        foreach (string word in inputsFrom)
                        {
                            List<int> indeces = new List<int>();
                            if (word.Contains("-"))
                            {
                                string[] wordFrom = Regex.Split(word, "-");
                                int from1 = int.Parse(wordFrom[0], CultureInfo.InvariantCulture.NumberFormat);
                                int from2 = int.Parse(wordFrom[1], CultureInfo.InvariantCulture.NumberFormat);
                                int from_ = from1;
                                while (from_ <= from2) { indeces.Add(from_); from_++; }
                            }
                            else
                            {
                                int from = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat); indeces.Add(from);
                            }
                            selectedIndex1.Add(indeces.ToArray());
                        }
                        foreach (ChemiForm chem in Selected_options)
                        {
                            int indexFrom = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
                            int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
                            if (indexFrom != indexTo)
                            {
                                for (int d = 0; d < selectedIndex1.Count(); d++)
                                {
                                    int idx1 = Array.IndexOf(selectedIndex1[d], indexFrom);
                                    int idx2 = Array.IndexOf(selectedIndex2[d], indexTo);
                                    if (idx1 > -1 && idx2 > -1)
                                    {
                                        keeplistitem.Add(chem.DeepCopy()); break;
                                    }
                                }
                            }
                        }
                    }
                    Selected_options = keeplistitem;
                }

                #endregion

                #region Last check if items in Selected_options are already included in Fragments 2
                if (Fragments2.Count != 0)
                {
                    List<ChemiForm> duplicateItem = new List<ChemiForm>();
                    foreach (FragForm fra in Fragments2)
                    {
                        foreach (ChemiForm chem in Selected_options)
                        {
                            if (chem.Mz.Equals(fra.Mz) && chem.Radio_label.Equals(fra.Radio_label) && chem.Adduct.Equals(fra.Adduct) && chem.Deduct.Equals(fra.Deduct))
                            {
                                duplicateItem.Add(chem);
                            }
                        }
                    }
                    foreach (ChemiForm chem in duplicateItem)
                    {
                        Selected_options.Remove(chem);
                    }
                }
                #endregion

                if (Selected_options.Count != 0)
                {
                    calc_resolution = true;
                    recalc = true;
                    neues = Fragments2.Count();
                    ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = Selected_options.Count, Size = new Size(227, 23), AutoSize = false };
                    user_grpBox.Controls.Add(tlPrgBr);

                    calc_Btn.Enabled = false;
                    frag_listView.BeginUpdate();
                    
                    #region Calculation                    
                    foreach (ChemiForm chem in Selected_options)
                    {
                        #region Resolution
                        if (machine_listBox.SelectedItems.Count > 0)
                        {
                            chem.Machine = machine_listBox.SelectedItem.ToString();
                        }
                        else
                        {
                            chem.Resolution = float.Parse(resolution_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
                        }
                        #endregion
                       
                        ChemiForm.CheckChem(chem);
                        if (chem.Resolution == 0)
                        {
                            if (String.IsNullOrEmpty(chem.Machine.ToString()))
                            {
                                chem.Error = true;
                            }
                            else
                            {
                                ChemiForm.Get_R(chem,calc_resolution);
                                if (chem.Resolution == 0) chem.Error = true;
                                calc_resolution = false;//the resolution matrix is calculated only once for the forst fragment, and is constant for the other fragments
                            }
                        }
                        if (chem.Error == false)
                        {
                            algo = 1;
                            int idx = chem.FinalFormula.IndexOf("C");
                            if (Char.IsNumber(chem.FinalFormula[idx + 2]) != true) algo = 1;
                            else if (Char.IsNumber(chem.FinalFormula[idx + 3]) == true) algo = 2;

                            if (algo == 1)
                            {
                                ChemiForm.Isopattern(chem, 1000000, 1, 0, 0.01);
                            }
                            else
                            {
                                ChemiForm.Isopattern(chem, 1000000, 2, 0, 0.01);
                            }
                            ChemiForm.Envelope(chem);
                        }
                        
                        if (chem.Error == false)
                        {
                            ChemiForm.Vdetect(chem);
                            List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
                            if (insert_exp==true)
                            {
                                //Console.WriteLine(chem.Centroid[cen_int].X.ToString());
                                chem.Resolution = ppm_calculator(cen[0].X);
                                if (chem.Resolution != 0f)
                                {
                                    if (ppm_calculator(cen[1].X) != 0f || (cen.Count() > 2 && ppm_calculator(cen[2].X) != 0f))
                                    {
                                        chem.Profile.Clear();
                                        ChemiForm.Envelope(chem);
                                        counter++;//o counter antistoixei ston index tou fragment sto all_data
                                        Fragments2.Add(new FragForm() { Centroid = cen, Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution, Factor = 1.0, Counter = counter, To_plot = false, Color = chem.Color, Name = chem.Name, ListName = new string[4], Fix = 1.0, Max_intensity = new double() });
                                        Initialize_Fragments();
                                        if (chem.Charge > 0) Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                                        else Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                                        var listViewItem = new ListViewItem(Fragments2.Last().ListName);
                                        listViewItem.SubItems.Add("1.0");//"factor" column
                                        listViewItem.SubItems.Add(counter.ToString());// "No" (aka code) column
                                        listViewItem.SubItems.Add(cen[0].Y.ToString());// max centroid
                                        frag_listView.Items.Add(listViewItem);

                                    }
                                }                                
                            }
                            else
                            {                               
                                counter++;//o counter antistoixei ston index tou fragment sto all_data
                                Fragments2.Add(new FragForm() { Centroid = cen, Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution, Factor = 1.0, Counter = counter, To_plot = false, Color = chem.Color, Name = chem.Name, ListName = new string[4], Fix = 1.0, Max_intensity = new double() });
                                Initialize_Fragments();
                                if (chem.Charge > 0) Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                                else Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                                var listViewItem = new ListViewItem(Fragments2.Last().ListName);
                                listViewItem.SubItems.Add("1.0");//"factor" column
                                listViewItem.SubItems.Add(counter.ToString());// "No" (aka code) column
                                listViewItem.SubItems.Add(cen[0].Y.ToString());// max centroid
                                frag_listView.Items.Add(listViewItem);                               
                            }
                            //Console.WriteLine(tlPrgBr.Value);

                            tlPrgBr.Value++;
                        }
                        else
                        {
                            string message = "Formula with m/z:" + chem.Mz + " and ion type:" + chem.Ion + " encountered an error";
                            MessageBox.Show(message, "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                        }                       

                    }
                    #endregion
                    tlPrgBr.Dispose();
                    frag_listView.EndUpdate();

                    sw1.Stop(); Debug.WriteLine("Pre allign: " + sw1.ElapsedMilliseconds.ToString());
                    sw1.Reset(); sw1.Start();

                    if (counter != Fragments2.Count)
                    {
                        MessageBox.Show("Error in 'Fragments2'!Restart the program!");
                    }
                    else
                    {
                        if (insert_exp) step_Fitting();
                        if (!is_loading)
                        {
                            if (string.IsNullOrEmpty(fitStep_Box.Text)){ recalculate_all_data_aligned(); }
                            refresh_iso_plot();
                        }

                        // j = 0; to be removed
                        saveCalc_Btn.Enabled = true;
                        clearCalc_Btn.Enabled = true;
                        calc_Btn.Enabled = true;
                        fit_Btn.Enabled = true;
                        loadFit_Btn.Enabled = false;

                        sw1.Stop(); Debug.WriteLine("Post allign: " + sw1.ElapsedMilliseconds.ToString());

                        MessageBox.Show("Done!");

                        
                    }

                }
                else
                {
                    MessageBox.Show("There is no match to your research.Please try again!");
                    clearCalc_Btn.Enabled = true;
                }
            }
            #endregion            
            is_calc = false;


        }

        private float ppm_calculator(double centroid)
        {
            float res = 0f;
            double ppm = 0.0;            
            double diff = 0.0;
            int d = 1;
            if (peak_points[peak_points.Count()-1][1] - centroid < 0)
            {
                ppm = Math.Abs(peak_points[0][1]+ peak_points[0][4] - centroid) * 1000000 / (peak_points[0][1] + peak_points[0][4]);
                if (ppm < ppmError) { res = (float)peak_points[0][3]; return res; }
                else return res;
            }
                       
            do
            {
                diff = peak_points[d][1] + peak_points[d][4] - centroid;
                while (diff<0)
                {
                    d++;
                    diff = peak_points[d][1] + peak_points[d][4] - centroid;                    
                }
                diff = peak_points[d][1] + peak_points[d][4] - centroid;
                if (diff>=0)
                {
                    ppm = Math.Abs(diff) * 1000000 / (peak_points[d][1] + peak_points[d][4]);
                    if (ppm < ppmError) { res = (float)peak_points[d][3]; return res; }
                    ppm = Math.Abs(peak_points[d-1][1] + peak_points[d-1][4] - centroid) * 1000000 / (peak_points[d-1][1] + peak_points[d-1][4]);
                    if (ppm < ppmError) { res = (float)peak_points[d-1][3]; return res; }
                    else  return res; 
                }

            } while (d< peak_points[0].Count()-1);
            return res;
        }
        private void Initialize_Fragments()
        {
            if (all_data.Count == 0) { all_data.Add(new List<double[]>()); custom_colors.Add(OxyColors.Black.ToColor().ToArgb()); }

            if (candidate_fragments == all_data.Count)
            {
                for (int i = candidate_fragments - 1; i < Fragments2.Count; i++)
                {
                    custom_colors.Add(Fragments2[i].Color.ToColor().ToArgb());
                    all_data.Add(new List<double[]>());
                    all_data[candidate_fragments].Add(new double[] { Fragments2[i].Profile[0].X, Fragments2[i].Profile[0].Y });
                    double max_intensity = 0.0;
                    for (int p = 1; p < Fragments2[i].Profile.Count; p++)
                    {
                        if (Fragments2[i].Profile[p].X == Fragments2[i].Profile[p - 1].X)
                        {
                            all_data[candidate_fragments].Last()[1] += Fragments2[i].Profile[p].Y;
                        }
                        else { all_data[candidate_fragments].Add(new double[] { Fragments2[i].Profile[p].X, Fragments2[i].Profile[p].Y }); }
                        if (all_data[candidate_fragments].Last()[1] > max_intensity)
                        {
                            max_intensity = all_data[candidate_fragments].Last()[1];
                        }
                    }
                    Fragments2[i].Max_intensity = max_intensity;
                    if (insert_exp) { Fragments2[i].Fix = 0.2 * max_exp / max_intensity; /*fix_data_to_max_exp(max_intensity, candidate_fragments);*/ }
                    candidate_fragments++;
                }
            }
            else
            {
                //error
                MessageBox.Show("Error! all_data structure has encountered an error. Stop the program");
            }
        }

        #endregion
      
        #region Recalculate data aligned

        private void recalculate_all_data_aligned()
        {
            //kaleitai kathe fora pou prostithetai neo stoixeio sto all_data
            List<int> idxs = new List<int>();//einai mia lista 0 1 2 3..osa kai ta stoixeia tou all data
            int start = 0;
            // will recalculate all data aligned                      
            if (all_data_aligned.Count >0)
            {
                if (all_data_aligned[0].Count()<Fragments2.Count+1)
                {
                    start = all_data_aligned[0].Count();
                    for (int i = start; i < all_data.Count; i++) { idxs.Add(i); }
                    all_data_aligned = align_distros(idxs, true,true);
                    recalc = false;
                    return;
                }
            }
            for (int i = start; i < all_data.Count; i++) { idxs.Add(i); }
            //(M)praktika einai lista me pinakes kai seires osa ta peiramatika dedomena 
            //(M)kathe pinakas exei to arxiko peiramatiko dedomeno kai to interpolated tou kathe fragment, an den yphrxe exei 0
            all_data_aligned = align_distros(idxs, true);            
            recalc = false;
            
        }
        private List<double[]> align_distros(List<int> distro_fragm_idxs, bool initial = false,bool add=false,bool Lbl=true)
        {
            List<double[]> aligned_intensities = new List<double[]>();//(M)praktika einai lista me pinakes kai seires osa ta peiramatika dedomena 
                                                                      //(M)kathe pinakas exei to arxiko peiramatiko dedomeno kai to interpolated tou kathe fragment, an den yphrxe exei 0

            ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = all_data[0].Count, Size = new Size(227, 23), AutoSize = false };
            //user_grpBox.Controls.Add(tlPrgBr);
            if (add && initial)
            {
                // generate alligned (in m/z) isotope distributions at the same step as the experimental
                // pickup each point in experimental and find (interpolate) the intensity of each fragment
                for (int i = 0; i < all_data[0].Count; i++) //(M)loop for all the experimental points count
                {
                    // one by one for all points
                    List<double> one_aligned_point = new List<double>();
                    foreach (double o in all_data_aligned[i])
                    {
                        one_aligned_point.Add(o);
                    }
                    double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo  ta experimental ola ta x-->m/z
                    int so_far = all_data_aligned[0].Count();
                    for (int j = 0; j < distro_fragm_idxs.Count; j++)
                    {
                        int distro_idx = distro_fragm_idxs[j];

                        // interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                        double aligned_value = 0.0;
                        
                        for (int k = 0; k < all_data[distro_idx].Count - 1; k++)
                        {
                            if (k==0 && mz_toInterp > all_data[distro_idx][all_data[distro_idx].Count - 1][0])
                            {
                                aligned_value = 0.0; break;
                            }
                            if (k == 0 && mz_toInterp < all_data[distro_idx][k][0])
                            {
                                aligned_value = 0.0; break;
                            }
                            if (mz_toInterp >= all_data[distro_idx][k][0] && mz_toInterp <= all_data[distro_idx][k + 1][0])
                            {
                                aligned_value = interpolate(all_data[distro_idx][k][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k + 1][1], mz_toInterp);
                                break;
                            }                            
                        }
                        one_aligned_point.Add(aligned_value);
                    }
                    aligned_intensities.Add(one_aligned_point.ToArray());
                    //Console.WriteLine(tlPrgBr.Value);
                    tlPrgBr.Value++;
                }
            }
            else if (window_count == 1 || initial)
            {               
                // generate alligned (in m/z) isotope distributions at the same step as the experimental
                // pickup each point in experimental and find (interpolate) the intensity of each fragment
                for (int i = 0; i < all_data[0].Count; i++) //(M)loop for all the experimental points count
                {
                    // one by one for all points
                    List<double> one_aligned_point = new List<double>();

                    // add experimental
                    one_aligned_point.Add(all_data[0][i][1]);//(M)prosthetei apo ta experimental data ola ta y-->intensity

                    double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo  ta experimental ola ta x-->m/z

                    for (int j = 1; j < distro_fragm_idxs.Count; j++)
                    {
                        int distro_idx = distro_fragm_idxs[j];

                        // interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                        double aligned_value = 0.0;

                        for (int k = 0; k < all_data[distro_idx].Count - 1; k++)
                        {
                            if (k == 0 && mz_toInterp > all_data[distro_idx][all_data[distro_idx].Count - 1][0])
                            {
                                aligned_value = 0.0; break;
                            }
                            if (k == 0 && mz_toInterp < all_data[distro_idx][k][0])
                            {
                                aligned_value = 0.0; break;
                            }
                            if (mz_toInterp >= all_data[distro_idx][k][0] && mz_toInterp <= all_data[distro_idx][k + 1][0])
                            {
                                aligned_value = interpolate(all_data[distro_idx][k][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k + 1][1], mz_toInterp);
                                break;
                            }
                        }
                        one_aligned_point.Add(aligned_value);
                    }
                    aligned_intensities.Add(one_aligned_point.ToArray());
                    //Console.WriteLine(tlPrgBr.Value);
                    tlPrgBr.Value++;
                }               
            }
            else
            {

                
                //efarmozetai MONO sta checked_mono_fragments
                //start-->starting index in each window
                //end-->ending index in each window
                int w = selected_window;
                int start = windowList[w].Starting;
                int end = windowList[w].Ending;               
                // generate alligned (in m/z) isotope distributions at the same step as the experimental
                // pickup each point in experimental and find (interpolate) the intensity of each fragment
                for (int i = start; i < end + 1; i++) //(M)loop for all the experimental points count
                {
                    // one by one for all points
                    List<double> one_aligned_point = new List<double>();

                    // add experimental
                    one_aligned_point.Add(all_data[0][i][1]);//(M)prosthetei apo ta experimental data ola ta y-->intensity

                    //double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo ola ta experimental ola ta x-->m/z

                    for (int j = 0; j < distro_fragm_idxs.Count; j++)
                    {
                        int distro_idx = distro_fragm_idxs[j];
                        double aligned_value = all_data_aligned[i][distro_idx];
                        //// interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                        //double aligned_value = 0.0;

                        //for (int k = 0; k < all_data[distro_idx].Count - 1; k++)
                        //{
                        //    if (mz_toInterp >= all_data[distro_idx][k][0] && mz_toInterp <= all_data[distro_idx][k + 1][0])
                        //    {
                        //        aligned_value = interpolate(all_data[distro_idx][k][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k + 1][1], mz_toInterp);
                        //        break;
                        //    }
                        //}
                        one_aligned_point.Add(aligned_value);
                    }
                    aligned_intensities.Add(one_aligned_point.ToArray());
                    tlPrgBr.Value++;
                }
                
            }
            tlPrgBr.Dispose();
            return aligned_intensities;
        }
        private double interpolate(double x1, double y1, double x2, double y2, double x_inter)
        {
            return ((x_inter - x1) * y2 + (x2 - x_inter) * y1) / (x2 - x1);
        }

        #endregion

        #region refresh plot
        private void refresh_iso_plot()
        {
            //(M) to text box pou dexetai einai ekeino pou tou exoun ginei paste ta data pou tha plotaroume

            // 0. gather info on which fragments are selected to plot, and their respective intensities
            List<int> to_plot = selectedFragments.OrderBy(p => p).ToList();//(M) vriskei poia indexes tou all_data einai checked
            List<double> UI_intensities = get_UI_intensities(to_plot.ToArray()); //(M)epistrefei list me tous factors

            // to_plot and UI_intensities contain ONLY the selected indexes and intensities

            // 1b. reset iso plot
            reset_iso_plot();//(M)ftiaxnei series gia OLA ta stoixeia tou all_data(experimental kai fragments2) , to fit kai to residual

            if (insert_exp == false)
            {
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        if (curr_idx == 0) { }
                        else
                        {
                            string name_str = Fragments2[curr_idx - 1].Name;
                            (iso_plot.Model.Series[curr_idx] as LineSeries).Title = name_str;
                            for (int j = 0; j < all_data[curr_idx].Count; j++)
                                (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[curr_idx][j][0], Fragments2[curr_idx - 1].Fix * UI_intensities[i] * all_data[curr_idx][j][1]));
                        }
                    }
                }
                invalidate_all();
                return;
            }
            if (to_plot.Count == 0) return;

            // 1a. rerun calculations for fit and residual

            //(M)ola ta 'to_plot' thelw na tou valw,apo ola ta parathira
            recalculate_fitted_residual(to_plot, UI_intensities);

            ////for experimental data only
            //(iso_plot.Model.Series[0] as LineSeries).Title ="Exp" ;
            //for (int j = 0; j < all_data_aligned.Count; j++)
            //    (iso_plot.Model.Series[0] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[0][j][0], UI_intensities[i] * all_data_aligned[j][0]));

            // 2. replot all isotopes
            for (int i = 0; i < to_plot.Count; i++)
            {
                int curr_idx = to_plot[i];
                if (all_data.Count != 0)
                {
                    // get name of each line to be ploted
                    if (curr_idx == 0)
                    {
                        (iso_plot.Model.Series[0] as LineSeries).Title = "Exp";
                        for (int j = 0; j < all_data[curr_idx].Count; j++)
                        {
                            (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[curr_idx][j][0], UI_intensities[i] * all_data[curr_idx][j][1]));
                        }
                    }
                    else
                    {
                        string name_str = Fragments2[curr_idx - 1].Name;
                        (iso_plot.Model.Series[curr_idx] as LineSeries).Title = name_str;
                        if (Fitting_chkBox.Checked)
                        {
                            for (int j = 0; j < all_data[0].Count; j++)
                                (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[0][j][0], UI_intensities[i] * all_data_aligned[j][curr_idx]));
                        }
                        else
                        {
                            for (int j = 0; j < all_data[curr_idx].Count; j++)
                            {
                                (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[curr_idx][j][0], Fragments2[curr_idx - 1].Fix * UI_intensities[i] * all_data[curr_idx][j][1]));
                            }
                        }
                    }

                }


            }

            // 3. fitted plot (if more than 2 fragments(except the experimental))
            if (summation.Count > 0)//(M)to summation ypologizetai mono otan to_plot.Count>=2
                if (Fitting_chkBox.Checked)
                    for (int j = 0; j < summation.Count; j++)
                        (iso_plot.Model.Series[all_data.Count] as LineSeries).Points.Add(new OxyPlot.DataPoint(summation[j][0], summation[j][1]));

            // 4. residual plot
            if (residual.Count > 0)
                for (int j = 0; j < residual.Count; j++)
                    (res_plot.Model.Series[0] as LineSeries).Points.Add(new OxyPlot.DataPoint(residual[j][0], residual[j][1]));

            invalidate_all();
        }

        private void reset_iso_plot()
        {
            iso_plot.Model.Series.Clear();

            for (int i = 0; i < all_data.Count; i++)
            {
                LineSeries tmp = new LineSeries() { StrokeThickness = 2, Color = get_fragment_color(i) };
                if (i == 0) tmp.StrokeThickness = 1;
                iso_plot.Model.Series.Add(tmp);
            }
            if (insert_exp == true)
            {
                LineSeries fit = new LineSeries() { StrokeThickness = 2, Color = OxyColors.Black, LineStyle = LineStyle.Dot };
                iso_plot.Model.Series.Add(fit);
            }
            res_plot.Model.Series.Clear();
            if (insert_exp == true)
            {
                LineSeries res = new LineSeries() { StrokeThickness = 2, Color = OxyColors.Black };
                res_plot.Model.Series.Add(res);
            }
        }
        private void recalculate_fitted_residual(List<int> to_plot, List<double> UI_intensities)
        {
            // calculate addition of selected fragments, and the respective residual
            // it is always called on every refresh of the plot 
            // if it is called from a selected fit change, no need to seek info from fit results. Results are already on the UI (checkbox.checked, and factor textBox)
            // to_plot and UI_intensities may also contain experimental index that is not necessary for sum or residual and has to be removed for coding brevity
            // shallow copy to_plot and UI_intensities so as not to fuck up original Lists

            //
            //(M)edw lew na tou vazw ola ta dedomena apo ola ta parathira na ta plotarei,eksallou apla me factors paizei
            //

            List<int> plot_idxs = new List<int>(to_plot);
            List<double> intensities = new List<double>(UI_intensities);
            if (plot_idxs[0] == 0) { plot_idxs.RemoveAt(0); intensities.RemoveAt(0); }
            // 1. calculate addition of fragments
            summation.Clear();
            if (plot_idxs.Count >= 2)
            {
                for (int i = 0; i < all_data_aligned.Count; i++)//(M)gia osa einai ta peiramatika dedomena
                {
                    double intensity = 0.0;

                    for (int j = 0; j < plot_idxs.Count; j++)
                        intensity += all_data_aligned[i][plot_idxs[j]] * intensities[j];

                    summation.Add(new double[] { all_data[0][i][0], intensity });
                }
            }

            // 3. calculate residual
            residual.Clear();
            if (plot_idxs.Count >= 2)
            {
                // this case is for many fragmants (addition)
                for (int i = 0; i < summation.Count; i++)
                    residual.Add(new double[] { summation[i][0], all_data_aligned[i][0] - summation[i][1] });
            }
            else if (plot_idxs.Count == 1)
            {
                // this case is for one fragment only
                for (int i = 0; i < all_data_aligned.Count; i++)
                    residual.Add(new double[] { all_data[0][i][0], all_data_aligned[i][0] - all_data_aligned[i][plot_idxs[0]] * intensities[0] });
            }
        }
        private void invalidate_all()
        {
            iso_plot.InvalidatePlot(true);
            res_plot.InvalidatePlot(true);
        }
        private OxyColor get_fragment_color(int idx)
        {
            //idx is the all_data structure index not the Fragments2 index
            OxyColor clr = OxyColor.FromUInt32((uint)custom_colors[idx]);
            return clr;
        }
        #endregion

        #region peak detection

        private void peak_detect()
        {
            sw1.Reset(); sw1.Start();
            peak_points.Clear();
            peak_points = LIMPIC_mod();
            sw1.Stop(); Debug.WriteLine("peak detect: " + sw1.ElapsedMilliseconds.ToString());
        }

        private List<double[]> LIMPIC_mod()
        {
            progress_display_start(experimental.Count);

            // ALL detection calculations are in time domain, all time is in μs, results also in time
            // will return List { [0]index of data array, [1]time_raw, [2]intensity_raw, [3]Res_fit, [4]time_diff_fit, [5]intensity_fit, [6]σ_fit,    }
            bool hard_flag;

            List<double[]> temp_peaks = new List<double[]>();
            int peak_width = 2;

            double[] dataX, dataY;

            dataX = experimental.Select(a => a[0]).ToArray();
            dataY = experimental.Select(a => a[1]).ToArray();

            int len = dataY.Length;

            //double hard_threshold = Convert.ToDouble(hardThres_txtBox.Text);
            double hard_threshold = min_intes;

            double[] diff_y = new double[len - 1];
            for (int i = 0; i < dataY.Length - 1; i++)
                diff_y[i] = dataY[i + 1] - dataY[i];

            int starting_points_to_omit = 0;
            int last_detected_index = 0;

            for (int i = starting_points_to_omit; i < len - peak_width - 2; i++)
            {
                // check intensity restriction
                hard_flag = dataY[i + 1] > hard_threshold;

                if (hard_flag)
                {
                    // detect local maxima
                    bool local_max = false;

                    if (diff_y[i] >= 0 & diff_y[i + 1] <= 0)
                    {
                        local_max = true;

                        for (int j = i - peak_width + 1; j < i; j++)
                            if (diff_y[j] < 0) local_max = false;

                        for (int j = i + 2; j < i + peak_width + 1; j++)
                            if (diff_y[j] > 0) local_max = false;
                    }

                    if (local_max)
                    {
                        double[] point = new double[8];
                        point[0] = i + 1;                           // index
                        point[1] = dataX[i + 1];                    // experimental time
                        point[2] = dataY[i + 1];                    // experimental height

                        var pair = find_centroid(i + 1, dataX, dataY, dataX[i + 1] - dataX[i]);
                        point[3] = pair[0];             // resolution
                        point[4] = pair[1];             // adjusted relative time
                        point[5] = pair[2];             // adjusted height
                        point[6] = pair[3];             // FWHM dt [bins]

                        temp_peaks.Add(point);
                        last_detected_index = i;
                    }
                }
                if (i % 10000 == 0 && i > 0) progress_display_update(i); 
            }
            progress_display_stop();
            return temp_peaks;
        }

        private double[] find_centroid(int pos, double[] dataX, double[] dataY, double bin_size)
        {
            double height = dataY[pos];
            var normal = estimate_alglib_normal(pos, dataX, dataY);

            double fwhm_norm = 2.3548 * normal[0] * bin_size;
            double res_norm = dataX[pos] / fwhm_norm;

            double[] d = new double[4] { res_norm, normal[1] * bin_size, normal[2], normal[0] };
            return d;
        }

        private double[] estimate_alglib_normal(int locMax_index, double[] dataX, double[] dataY)
        {
            current_peak_index = locMax_index;
            double height = dataY[locMax_index];

            // 2. initialize needed params
            double[] coeficients = new double[] { 2.0, 0.0, 1.1 * height };
            double epsx = 0.0000000001;
            int maxits = 100000;
            double[] bndl = new double[3] { 1, -1, 1.00 * height };
            double[] bndh = new double[3] { 10, 1, 1.2 * height };
            double[] scale = new double[3] { 1, 0.5, 0.1 * height };

            alglib.minlmstate state;
            alglib.minlmreport rep;

            alglib.minlmcreatev(2, coeficients, 0.001, out state);
            alglib.minlmsetbc(state, bndl, bndh);                                            // boundary conditions
            alglib.minlmsetcond(state, epsx, maxits);
            alglib.minlmsetscale(state, scale);
            alglib.minlmoptimize(state, function, null, dataY);
            alglib.minlmresults(state, out coeficients, out rep);

            // 4. save result
            double[] minimum = new double[3] { coeficients[0], coeficients[1], coeficients[2] };
            return minimum;
        }

        public void function(double[] x, double[] func, object dataY)
        {
            func[0] = 0;
            double gauss_point, temp, temp2;

            for (int i = 5; i < 16; i++)
            {
                temp2 = ((double)i - 10.0 - x[1]) / (1.4142 * x[0]);
                gauss_point = x[2] * Math.Exp(-1.0 * temp2 * temp2);
                temp = (dataY as double[])[current_peak_index + (i - 10)] - gauss_point;
                func[0] += temp * temp;
            }
        }

        private void display_peakList()
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        #endregion

        #region Toolbar control
        private void progress_display_init()
        {
            tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Size = new Size(227, 23), AutoSize = false, Visible = false };
            user_grpBox.Controls.Add(tlPrgBr);
        }

        private void progress_display_start(int barMax)
        {
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Maximum = barMax));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = 0));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Visible = true));   //thread safe call
        }

        private void progress_display_stop()
        {
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Visible = false));   //thread safe call
        }
        private void progress_display_update(int idx)
        {
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = idx - 1));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = idx - 2));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Update()));   //thread safe call
        }


        #endregion

        #region Helpers
        public IEnumerable<Control> GetControls(Control c)
        {
            return new[] { c }.Concat(c.Controls.OfType<Control>().SelectMany(x => GetControls(x)));
        }


        #endregion

        #region unused_code
        private void save_data()
        {

            SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = "window" + windowList[selected_window].Code.ToString(), Filter = "Data Files (*.wnd)|*.wnd", DefaultExt = "wnd", OverwritePrompt = true, AddExtension = true };

            //save.InitialDirectory = Application.StartupPath + "\\Data";
            //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
            //if (di.Exists != true) di.Create();

            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                file.WriteLine("Mode:\texternal data");
                file.WriteLine("AA Sequence:\t" + Peptide);
                file.WriteLine("Window:\t" + windowList[selected_window].Code.ToString());
                file.WriteLine("Fitted isotopes:\t" + candidate_fragments.ToString());
                file.WriteLine("m/z[Da]\tIntensity");
                file.WriteLine();

                for (int i = 0; i < windowList[selected_window].Fragments.Count; i++)
                {
                    int indexS = windowList[selected_window].Fragments[i];
                    if (indexS == 0)
                    {
                        file.WriteLine("Name:\t" + "Exp");
                        file.WriteLine("Factor:\t" + "1.0");
                    }
                    else
                    {
                        file.WriteLine("Name:\t" + Fragments2[indexS - 1].Name);
                        file.WriteLine("Factor:\t" + Fragments2[indexS - 1].Factor);
                        file.WriteLine("ListViewItems:\t" + Fragments2[indexS - 1].ListName[0].ToString() + "\t" + Fragments2[indexS - 1].ListName[1].ToString() + "\t" + Fragments2[indexS - 1].ListName[2].ToString() + "\t" + Fragments2[indexS - 1].ListName[3].ToString() + "\t" + Fragments2[indexS - 1].ListName[4].ToString());
                        file.WriteLine("Selected:\t" + Fragments2[indexS - 1].To_plot.ToString());
                        file.WriteLine("Color:\t" + Fragments2[indexS - 1].Color.ToColor().ToArgb());
                    }
                    foreach (double[] p in all_data[indexS]) file.WriteLine(p[0] + "\t" + p[1]);
                }
                file.Flush(); file.Close(); file.Dispose();
            }


        }
        //private void indexForm(object sender, EventArgs e)
        //{
        //    List<int> fromItems = new List<int>();
        //    fromItems = ChemFormulas.Select(x => Int32.Parse(x.Index)).Distinct().OrderBy(p => p).ToList();
        //    if ((sender as MenuItem).Text == "Index")
        //    {
        //        if (a_lstBox.Focused)
        //        {
        //            foreach (ChemiForm chem in ChemFormulas)
        //            {
        //                if (chem.Ion_type.Equals("a"))
        //                {
        //                    selectedIons.Add(chem);
        //                }
        //            }
        //        }
        //        if (b_lstBox.Focused) { MessageBox.Show("b"); }
        //        if (c_lstBox.Focused) { MessageBox.Show("c"); }
        //        if (x_lstBox.Focused) { MessageBox.Show("x"); }
        //        if (y_lstBox.Focused) { MessageBox.Show("y"); }
        //        if (z_lstBox.Focused) { MessageBox.Show("z"); }
        //        if (dvw_lstBox.Focused) { MessageBox.Show("dvw"); }
        //        if (addin_lstBox.Focused) { MessageBox.Show("addin"); }

        //    }

        //}
        private void ChemToFrag(List<ChemiForm> initial, ref List<FragForm> final)
        {
            foreach (ChemiForm chem in ChemFormulas)
            {
                if (chem.Error == false)
                {
                    final.Add(new FragForm() { Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution });
                }
            }
        }
        private void fix_data_to_max_exp(double max_intensity, int candidate_fragments)
        {
            List<double[]> new_data = new List<double[]>();
            double factor = 0.2 * max_exp / max_intensity;
            foreach (double[] d in all_data[candidate_fragments])
            {
                new_data.Add(new double[] { d[0], d[1] * factor });
            }
            all_data[candidate_fragments].Clear();
            all_data[candidate_fragments] = new_data;
        }
        private void fix_experimental_gaps()
        {
            List<double[]> new_exp = new List<double[]>();
            double step = experimental[1][0] - experimental[0][0];
            new_exp.Add(new double[] { experimental[0][0], experimental[0][1] });
            for (int i = 1; i < experimental.Count; i++)
            {
                while (experimental[i][0] - new_exp.Last()[0] > step + 0.0001)
                {
                    new_exp.Add(new double[] { new_exp.Last()[0] + step, 0.0 });
                }
                new_exp.Add(new double[] { experimental[i][0], experimental[i][1] });
            }
            current_experimental.Clear();
            current_experimental = new_exp;
        }
        private void fix_experimentalTo_100(double max_exp)
        {
            List<double[]> new_exp = new List<double[]>();
            foreach (double[] exp in experimental)
            {
                new_exp.Add(new double[] { exp[0], exp[1] * 100 / max_exp });
            }
            experimental.Clear();
            experimental = new_exp;
        }

        private void generate_x_multiChraged_withoutAducts()
        {
            // max charge depends on lenght of the fragment. We will follow y-type rules
            // will run through all frags once to find x_idxs and max_charge for each y of different length

            List<int> x_idxs = new List<int>();
            List<int[]> max_charge_y = new List<int[]>();
            int tempo = 0;
            for (int i = 0; i < ChemFormulas.Count; i++)
            {
                if (ChemFormulas[i].Ion.StartsWith("x")) x_idxs.Add(i); //store x indexes
                else if (ChemFormulas[i].Ion.StartsWith("y"))
                {
                    tempo++;
                    int y_num = Convert.ToInt16(ChemFormulas[i].Index);
                    int charge = ChemFormulas[i].Charge;

                    if (max_charge_y.Count == 0 || max_charge_y.Find(p => p[0] == y_num) == null)
                    {
                        max_charge_y.Add(new int[] { y_num, charge });
                    }
                    else if (max_charge_y[max_charge_y.FindIndex(p => p[0] == y_num)][1] < charge)
                    {
                        max_charge_y[max_charge_y.FindIndex(p => p[0] == y_num)][1] = charge;
                    }
                }
            }

            int temp = 0;

            for (int i = 0; i < x_idxs.Count; i++)
            {
                int x_num = Convert.ToInt16(ChemFormulas[i].Index);
                int max_charge = max_charge_y[max_charge_y.FindIndex(p => p[0] == x_num)][1];

                for (int j = 2; j < max_charge + 1; j++)
                {
                    //add_fragment(); temp++;
                }
            }

            // copy results to clipboard
            max_charge_y = max_charge_y.OrderBy(p => p[0]).ToList();
            string export = "";
            for (int i = 0; i < max_charge_y.Count; i++)
            {
                export += max_charge_y[i][0] + " " + max_charge_y[i][1] + "\r\n";
            }
            Clipboard.SetText(export);
        }

        #endregion

        private void optionBtn_Click(object sender, EventArgs e)
        {            
            frm6.Show();            
        }

        private void bigPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
        
    


