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
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using static alglib;
using System.Runtime.InteropServices;


namespace Isotope_fitting
{
    public partial class Form2 : Form
    {
        int iiiiiiii = 0;

        #region PARAMETER SET TAB FIT

        #region old new calculations
        bool plot_rem_Btns = false;
        bool refresh_all = false;
        int exp_res = 0;
        public int neues = 0;
        public bool mark_neues = false;
        public static bool insert_exp = false;
        public static bool segmented_graph = false;
        public static bool loaded_window = false;
        public static string file_name = "";
        public bool calc_resolution = true;
        public bool recalc = true;

        public static List<ChemiForm> ChemFormulas = new List<ChemiForm>();
        public string Peptide =String.Empty;
        //List<string> ionItems = new List<string>();
        //List<string> selectedFrag = new List<string>();
        List<ChemiForm> selectedIons = new List<ChemiForm>();
        //List<int> selectedCharges = new List<int>();

        //List<string> selectedMz = new List<string>();
        //List<int> stepIndeces =new List<int>();            
        public static List<FragForm> Fragments2 = new List<FragForm>();
        public List<int> selectedFragments = new List<int>();
        int start_idx = 0;
        int end_idx = 0;
        public static double max_exp = 0.0;
        public static List<WindowSet> windowList = new List<WindowSet>();
        public static int window_count = 1;
        public static int selected_window = 1000000;

        private ListViewItemComparer _lvwItemComparer;
        #region colours
        PlotView iso_plot;
        PlotView res_plot;
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
        public static List<int> custom_colors = new List<int>();
      
        const double H_mass = 1.008;
        OxyPlot.ScreenPoint charge_center;
        bool is_loading = false; //indicates if loading is active
        bool is_applying_fit = false;
        private bool is_calc = false;

        public static List<double[]> peak_points = new List<double[]>();
        /// <summary>
        /// previous clicked point on iso plot
        /// </summary>
        OxyPlot.ScreenPoint previous_point;
        /// <summary>
        /// distance between two points on screen
        /// </summary>
        double point_distance;
        bool count_distance = false;
        
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        ProgressBar tlPrgBr;
        Label prg_lbl;
        string precursor_carbons = "C0";
        Object _locker = new Object();
        delegate void EnvelopeCalcCompleted();
        delegate void FittingCalcCompleted();
        delegate void Recalculate_completed();

        event EnvelopeCalcCompleted OnEnvelopeCalcCompleted;
        event FittingCalcCompleted OnFittingCalcCompleted;
        event Recalculate_completed OnRecalculate_completed;

        public static List<List<double[]>> all_fitted_results;
        List<List<int[]>> all_fitted_sets;
        MyTreeView fit_tree;
        MyTreeView frag_tree = new MyTreeView() { Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
           BorderStyle = BorderStyle.FixedSingle,
            CheckBoxes = true,
            HideSelection = false,
            Location = new System.Drawing.Point(2, 76),
            Name = "frag_tree",
            Size = new System.Drawing.Size(354, 391),
            TabIndex = 10000011,
            Visible = false ,ShowNodeToolTips=false};
        string root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();

        string loaded_lists="";
        #endregion

        #region parameters
        /// <summary>
        /// max ppm error
        /// </summary>
        public double ppmError = 8.0;
        /// <summary>
        /// peak detect min intensity
        /// </summary>
        public static double min_intes = 50.0;
        /// <summary>
        /// size of fragments groups
        /// </summary>
        public int frag_mzGroups = 40;
        /// <summary>
        /// size of fit group
        /// </summary>
        static public int fit_bunch = 6;
        /// <summary>
        /// size of fit overlap
        /// </summary>
        static public int fit_cover = 2;
        /// <summary>
        /// [1 most intence,2 most intence,3 most intence,half most intence,half(-) most intence,half(+) most intence]
        /// </summary>
        bool[] selection_rule = new bool[] { true, false, false, false, false, false };
        bool block_plot_refresh = false;
        bool block_fit_refresh = false;
        /// <summary>
        /// max ppm error used in di and ei calculation during fitting
        /// </summary>
        static public double ppmDi = 8.0;

        private TreeNode _currentNode = new TreeNode();
        #endregion

        #region fit results sorting parameteres
        /// <summary>
        /// [Ai sort,A sort,di sort,sse sort, ei sort, dinew sort](6)
        /// </summary>
        public static bool[] fit_sort = new bool[] { true,false,false ,false, false, false };
        /// <summary>
        /// [Ai thres,A thres,di thres,ei thres,dinew thres](5)
        /// </summary>
        public static double[] fit_thres = new double[] {100.0,100.0,100.0,100.0, 100.0 };
        /// <summary>
        /// [Ai coef,A coef,di coef,sse coef,ei coef,dinew coef](6)
        /// </summary>
        public static double[] a_coef = new double[] { 1.0,0.0,0.0,0.0,0.0, 0.0 };
        public static int visible_results =100;
        public static int best_num_results = 1;

        /// <summary>
        /// list [Ai sort,A sort,di sort,sse sort, ei sort, dinew sort](6)
        /// </summary>
        public static List<bool[]> tab_node=new List<bool[]>();
        /// <summary>
        /// list [Ai coef,A coef,di coef,sse coef,ei coef,dinew coef](6)
        /// </summary>
        public static List<double[]> tab_coef = new List<double[]>();
        /// <summary>
        ///list [Ai thres,A thres,di thres,ei thres,dinew thres](5)
        /// </summary>
        public static List<double[]> tab_thres = new List<double[]>();
        List<string> labels_checked = new List<string>();
        #endregion

        #region  Constants for the SendMessage() method.
        private const int WM_HSCROLL = 276;
        private const int SB_LEFT = 6;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg,
                                          int wParam, int lParam);

        #endregion

        #region tooltip tree_view

        private ToolTip toolTip_fit = new ToolTip() { InitialDelay=1,IsBalloon=false,ReshowDelay=1,UseFading=true,AutoPopDelay=10000};      
        string tool_text = "";
        #endregion

        #region plot area format 
        // tab1 line isoplot
        public OxyColor fit_color = OxyColors.Black;
        public int exp_color = OxyColors.Black.ToColor().ToArgb();
        public OxyColor peak_color = OxyColors.Crimson;
        public LineStyle fit_style = LineStyle.Dot;
        public LineStyle exper_style = LineStyle.Solid;
        public LineStyle frag_style = LineStyle.Solid;
        public double exp_width = 1;
        public double frag_width = 2;
        public double fit_width = 1;
        public double peak_width = 1;
        public double cen_width = 1;
        // tab2 axis isoplot
        public LineStyle Xmajor_grid = LineStyle.Solid;
        public LineStyle Xminor_grid = LineStyle.None;
        public LineStyle Ymajor_grid = LineStyle.Solid;
        public LineStyle Yminor_grid = LineStyle.None;
        public OxyPlot.Axes.TickStyle X_tick = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_tick = OxyPlot.Axes.TickStyle.Outside;
        public double x_interval = 50;
        public double y_interval = 50;        
        public string x_format = "G";
        public string y_format = "G";
        public string x_numformat = "0";
        public string y_numformat = "0";        

        //primary tab plots

        //intensity
        public LineStyle Xmajor_grid12 = LineStyle.Solid;
        public LineStyle Xminor_grid12 = LineStyle.None;
        public LineStyle Ymajor_grid12 = LineStyle.Solid;
        public LineStyle Yminor_grid12 = LineStyle.None;
        public double y_interval12 = 50;
        public OxyPlot.Axes.TickStyle X_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public string y_format12 = "G";
        public string y_numformat12 = "0";
        public double x_majorStep12 = 5;
        public double x_minorStep12 = 1;
        public double bar_width = 1;
        //charge
        public LineStyle Xmajor_charge_grid12 = LineStyle.Solid;
        public LineStyle Xminor_charge_grid12 = LineStyle.None;
        public LineStyle Ymajor_charge_grid12 = LineStyle.Solid;
        public LineStyle Yminor_charge_grid12 = LineStyle.None;   
        public OxyPlot.Axes.TickStyle X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public double y_charge_majorStep12 = 2;
        public double y_charge_minorStep12 = 1;
        public double x_charge_majorStep12 = 5;
        public double x_charge_minorStep12 = 1;

        //internal tab plots
        public LineStyle Xint_major_grid13 = LineStyle.Solid;
        public LineStyle Xint_minor_grid13 = LineStyle.None;
        public LineStyle Yint_major_grid13 = LineStyle.Solid;
        public LineStyle Yint_minor_grid13 = LineStyle.None;
        public string x_format13= "G";
        public string x_numformat13 = "0";
        public double x_interval13 = 50;
        public OxyPlot.Axes.TickStyle Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;
        public double xINT_majorStep13 = 5;
        public double xINT_minorStep13 = 1;
        public double yINT_majorStep13 = 5;
        public double yINT_minorStep13 = 1;
        public double int_width = 1;
        #endregion

        #region Fragments File aka FF parameters
        /// <summary>
        /// max ppm error for Fragments File Calculation (Form 14)
        /// </summary>
        public double ppmErrorFF = 100.0;
        public bool calc_FF = false;
        public bool ignore_ppm = false;
        public bool calc_form14 = false;
        #endregion

        #endregion

        #region PARAMETER SET TAB DIAGRAMS
        List<ion> IonDraw = new List<ion>();
        List<ion> IonDrawIndex = new List<ion>();
        List<ion> IonDrawIndexTo = new List<ion>();
        //Graphics g = null;
        Pen p = new Pen(Color.Black);

        PlotView ax_plot;
        PlotView by_plot;
        PlotView cz_plot;
        PlotView axCharge_plot;
        PlotView byCharge_plot;
        PlotView czCharge_plot;
        PlotView index_plot;
        PlotView indexto_plot;
        PlotView indexIntensity_plot;
        PlotView indextoIntensity_plot;
        PlotView ppm_plot;


        #endregion

        public Form2()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            InitializeComponent();

            // declare event to continue calculations after Fragments2 are complete
            OnEnvelopeCalcCompleted += () => { fragments_and_calculations_sequence_B(); };

            // declare event to plot fit results after fitting calculations are complete
            OnFittingCalcCompleted += () => { update_sorting_parameters_lists(); generate_fit_results(); };


            OnRecalculate_completed += () => { refresh_iso_plot(); };

            frag_listView.Visible = frag_listView.Enabled = false;            
            load_preferences();
            reset_all();
            splitContainer2.Panel2.Controls.Add(frag_tree);

        }
        
        private void EnsureVisibleWithoutRightScrolling(TreeNode node)
        {
            if (!block_fit_refresh)
            {
                // we do the standard call.. 
                node.EnsureVisible();

                // ..and afterwards we scroll to the left again!
                SendMessage(frag_tree.Handle, WM_HSCROLL, SB_LEFT, 0);
            }           
        }

        /// <summary>
        /// TreeView class that disables double click in checkboxes
        /// </summary>
        class MyTreeView : TreeView
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x0203)
                {
                    m.Result = IntPtr.Zero;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams parms = base.CreateParams;
                    parms.Style |= 0x80;  // Turn on TVS_NOTOOLTIPS
                    return parms;
                }
            }
        }

        #region TAB FIT
        // UI UncheckAll()
        // UI Initialize_fit_UI()
        // UI merge textBox input control
        // Debug.WriteLine("peak thread id: " + Thread.CurrentThread.ManagedThreadId);

        #region 0. Preferences and params
        private void optionBtn_Click(object sender, EventArgs e)
        {    
            params_form();
        }

        private void params_form()
        {
            Form params_and_pref = new Form { Text = "Fragment selection filters", FormBorderStyle = FormBorderStyle.FixedDialog, AutoSize = false, Size = new Size(300,220), MaximizeBox = false, MinimizeBox = false };
            Label ppm_lbl = new Label { Name = "ppm_lbl", Text = "max ppm error: ", Location = new Point(10, 8), AutoSize = true };
            NumericUpDown ppm_numUD = new NumericUpDown { Name = "ppm_numUD", Minimum = 1, Increment = 0.1M, DecimalPlaces = 1, Value = (decimal)ppmError, Location = new Point(140, 5), Size = new Size(40, 20), TextAlign = System.Windows.Forms.HorizontalAlignment.Center };
            ppm_numUD.ValueChanged += (s, e) => { ppmError = (double)ppm_numUD.Value; save_preferences(); };

            Label fragGrps_lbl = new Label { Name = "fragGrps_lbl", Text = "size of fragment group: ", Location = new Point(10, 38), AutoSize = true };
            NumericUpDown fragGrps_numUD = new NumericUpDown { Name = "fragGrps_numUD", Minimum = 10, Value = frag_mzGroups, Location = new Point(140, 35), Size = new Size(40, 20), TextAlign = System.Windows.Forms.HorizontalAlignment.Center };
            fragGrps_numUD.ValueChanged += (s, e) => { frag_mzGroups = (int)fragGrps_numUD.Value; save_preferences(); };

            RadioButton one_rdBtn = new RadioButton { Name = "one_rdBtn", Text = "1 most intense", Location = new Point(10, 88), AutoSize = true, Checked = selection_rule[0], TabIndex = 0 };
            RadioButton two_rdBtn = new RadioButton { Name = "two_rdBtn", Text = "2 most intense", Location = new Point(10, 113), AutoSize = true, Checked = selection_rule[1], TabIndex = 1 };
            RadioButton three_rdBtn = new RadioButton { Name = "three_rdBtn", Text = "3 most intense", Location = new Point(10,138), AutoSize = true, Checked = selection_rule[2], TabIndex = 2 };
            RadioButton half_rdBtn = new RadioButton { Name = "half_rdBtn", Text = "half most intense", Location = new Point(130, 88), AutoSize = true, Checked = selection_rule[3], TabIndex = 3 };
            RadioButton half_minus_rdBtn = new RadioButton { Name = "half_minus_rdBtn", Text = "half(-) most intense", Location = new Point(130, 113), AutoSize = true, Checked = selection_rule[4], TabIndex = 4 };
            RadioButton half_plus_rdBtn = new RadioButton { Name = "half_plus_rdBtn", Text = "half(+) most intense", Location = new Point(130, 138), AutoSize = true, Checked = selection_rule[5], TabIndex = 5 };

            params_and_pref.Controls.AddRange(new Control[] { ppm_lbl, ppm_numUD,  fragGrps_lbl, fragGrps_numUD, one_rdBtn, two_rdBtn, three_rdBtn, half_rdBtn, half_minus_rdBtn, half_plus_rdBtn });            
            foreach (RadioButton rdBtn in params_and_pref.Controls.OfType<RadioButton>()) rdBtn.CheckedChanged += (s, e) => { if (rdBtn.Checked) update_peakSelection_rule(params_and_pref); };
            params_and_pref.ShowDialog();
        }

        private void update_peakSelection_rule(Form options_form)
        {
            // update selection rule from all radiobuttons
            List<RadioButton> rdBtns = GetControls(options_form).OfType<RadioButton>().ToList();

            foreach (RadioButton rdBtn in rdBtns)
                selection_rule[rdBtn.TabIndex] = rdBtn.Checked;

            save_preferences();
        }

        private void load_preferences()
        {
            // will look for the preferences file and load last session state
            if (File.Exists(root_path + "\\preferences.txt"))
            {
                try
                {
                    // get text in string[] and remove space after semicollon
                    string[] preferences = File.ReadAllLines(root_path + "\\preferences.txt");
                    for (int i = 0; i < preferences.Length; i++) preferences[i] = preferences[i].Replace(": ", ":");

                    // general pref
                    ppmError = Convert.ToDouble(preferences[0].Split(':')[1]);
                    min_intes = Convert.ToDouble(preferences[1].Split(':')[1]);
                    frag_mzGroups = Convert.ToInt32(preferences[2].Split(':')[1]);
                    fit_bunch = Convert.ToInt32(preferences[3].Split(':')[1]);
                    fit_cover = Convert.ToInt32(preferences[4].Split(':')[1]);

                    selection_rule[0] = string_to_bool(preferences[5].Split(':')[1]);
                    selection_rule[1] = string_to_bool(preferences[6].Split(':')[1]);
                    selection_rule[2] = string_to_bool(preferences[7].Split(':')[1]);
                    selection_rule[3] = string_to_bool(preferences[8].Split(':')[1]);
                    selection_rule[4] = string_to_bool(preferences[9].Split(':')[1]);
                    selection_rule[5] = string_to_bool(preferences[10].Split(':')[1]);

                    fit_sort[0] = string_to_bool(preferences[11].Split(':')[1]);
                    fit_sort[1] = string_to_bool(preferences[12].Split(':')[1]);
                    fit_sort[2] = string_to_bool(preferences[13].Split(':')[1]);
                    fit_sort[3] = string_to_bool(preferences[14].Split(':')[1]);
                    fit_sort[4] = string_to_bool(preferences[15].Split(':')[1]);
                    fit_sort[5] = string_to_bool(preferences[16].Split(':')[1]);


                    a_coef[0] = Convert.ToDouble(preferences[17].Split(':')[1]);
                    a_coef[1] = Convert.ToDouble(preferences[18].Split(':')[1]);
                    a_coef[2] = Convert.ToDouble(preferences[19].Split(':')[1]);
                    a_coef[3] = Convert.ToDouble(preferences[20].Split(':')[1]);
                    a_coef[4] = Convert.ToDouble(preferences[21].Split(':')[1]);
                    a_coef[5] = Convert.ToDouble(preferences[22].Split(':')[1]);

                    visible_results = Convert.ToInt32(preferences[23].Split(':')[1]);
                    fit_thres[0]= Convert.ToDouble(preferences[24].Split(':')[1]); 
                    fit_thres[1] = Convert.ToDouble(preferences[25].Split(':')[1]); 
                    fit_thres[2] = Convert.ToDouble(preferences[26].Split(':')[1]);
                    fit_thres[3] = Convert.ToDouble(preferences[27].Split(':')[1]);
                    fit_thres[4] = Convert.ToDouble(preferences[28].Split(':')[1]);

                    ppmDi = Convert.ToDouble(preferences[29].Split(':')[1]);

                    // tab1 line isoplot
                    exp_width = Convert.ToDouble(preferences[30].Split(':')[1]);
                    frag_width = Convert.ToDouble(preferences[31].Split(':')[1]);
                    fit_width = Convert.ToDouble(preferences[32].Split(':')[1]);
                    peak_width = Convert.ToDouble(preferences[33].Split(':')[1]);
                    cen_width = Convert.ToDouble(preferences[34].Split(':')[1]);

                    // tab2 axis isoplot
                    if (string_to_bool(preferences[35].Split(':')[1])) { Xmajor_grid = LineStyle.Solid; }
                    else { Xmajor_grid = LineStyle.None; }
                    if (string_to_bool(preferences[36].Split(':')[1])) { Xminor_grid = LineStyle.Solid; }
                    else { Xminor_grid = LineStyle.None; }
                    if (string_to_bool(preferences[37].Split(':')[1])) { Ymajor_grid = LineStyle.Solid; }
                    else { Ymajor_grid = LineStyle.None; }
                    if (string_to_bool(preferences[38].Split(':')[1])) { Yminor_grid = LineStyle.Solid; }
                    else { Yminor_grid = LineStyle.None; }
                    //preferences[0] += X_tick = OxyPlot.Axes.TickStyle.Outside;
                    //preferences[0] += Y_tick = OxyPlot.Axes.TickStyle.Outside;
                    x_interval = Convert.ToDouble(preferences[39].Split(':')[1]);
                    y_interval = Convert.ToDouble(preferences[40].Split(':')[1]);
                    x_format = preferences[41].Split(':')[1].ToString();
                    y_format = preferences[42].Split(':')[1].ToString();
                    x_numformat=preferences[43].Split(':')[1].ToString();
                    y_numformat = preferences[44].Split(':')[1].ToString();

                    //primary tab plots

                    //intensity
                    if (string_to_bool(preferences[45].Split(':')[1])) { Xmajor_grid12 = LineStyle.Solid; }
                    else { Xmajor_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[46].Split(':')[1])) { Xminor_grid12 = LineStyle.Solid; }
                    else { Xminor_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[47].Split(':')[1])) { Ymajor_grid12 = LineStyle.Solid; }
                    else { Ymajor_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[48].Split(':')[1])) { Yminor_grid12 = LineStyle.Solid; }
                    else { Yminor_grid12 = LineStyle.None; }
                    y_interval12 = Convert.ToDouble(preferences[49].Split(':')[1]);
                    //preferences[0] += X_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    //preferences[0] += Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    y_format12 = preferences[50].Split(':')[1].ToString();
                    y_numformat12 = preferences[51].Split(':')[1].ToString();
                    x_majorStep12 = Convert.ToDouble(preferences[52].Split(':')[1]);
                    x_minorStep12 = Convert.ToDouble(preferences[53].Split(':')[1]);
                    bar_width = Convert.ToDouble(preferences[54].Split(':')[1]);

                    //charge
                    if (string_to_bool(preferences[55].Split(':')[1])) { Xmajor_charge_grid12 = LineStyle.Solid; }
                    else { Xmajor_charge_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[56].Split(':')[1])) { Xminor_charge_grid12 = LineStyle.Solid; }
                    else { Xminor_charge_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[57].Split(':')[1])) { Ymajor_charge_grid12 = LineStyle.Solid; }
                    else { Ymajor_charge_grid12 = LineStyle.None; }
                    if (string_to_bool(preferences[58].Split(':')[1])) { Yminor_charge_grid12 = LineStyle.Solid; }
                    else { Yminor_charge_grid12 = LineStyle.None; }
                    //preferences[0] += X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    //preferences[0] += Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    y_charge_majorStep12 = Convert.ToDouble(preferences[59].Split(':')[1]);
                    y_charge_minorStep12 = Convert.ToDouble(preferences[60].Split(':')[1]);
                    x_charge_majorStep12 = Convert.ToDouble(preferences[61].Split(':')[1]);
                    x_charge_minorStep12 = Convert.ToDouble(preferences[62].Split(':')[1]);

                    //internal tab plots
                    if (string_to_bool(preferences[63].Split(':')[1])) { Xint_major_grid13 = LineStyle.Solid; }
                    else { Xint_major_grid13 = LineStyle.None; }
                    if (string_to_bool(preferences[64].Split(':')[1])) { Xint_minor_grid13 = LineStyle.Solid; }
                    else { Xint_minor_grid13 = LineStyle.None; }
                    if (string_to_bool(preferences[65].Split(':')[1])) { Yint_major_grid13 = LineStyle.Solid; }
                    else { Yint_major_grid13 = LineStyle.None; }
                    if (string_to_bool(preferences[66].Split(':')[1])) { Yint_minor_grid13 = LineStyle.Solid; }
                    else { Yint_minor_grid13 = LineStyle.None; }
                    x_format13 = preferences[67].Split(':')[1].ToString();
                    x_numformat13 = preferences[68].Split(':')[1].ToString();
                    x_interval13 = Convert.ToDouble(preferences[69].Split(':')[1]);
                    //preferences[0] += Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
                    //preferences[0] += Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;
                    xINT_majorStep13 = Convert.ToDouble(preferences[70].Split(':')[1]);
                    xINT_minorStep13 = Convert.ToDouble(preferences[71].Split(':')[1]);
                    yINT_majorStep13 = Convert.ToDouble(preferences[72].Split(':')[1]);
                    yINT_minorStep13 = Convert.ToDouble(preferences[73].Split(':')[1]);
                    int_width = Convert.ToDouble(preferences[74].Split(':')[1]);
                }
                catch
                {
                    MessageBox.Show("Error!", "Corrupted preferences file! Preferences not loaded!");
                    ppmError = 8.0; min_intes = 50.0; frag_mzGroups = 40; fit_bunch = 6; fit_cover = 2;selection_rule = new bool[] { false, true, false, false, false, false };
                    fit_sort = new bool[] { true, false, false, false, false, false }; a_coef = new double[] { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0 }; visible_results = 100; fit_thres = new double[] { 100.0, 100.0, 100.0, 100.0, 100.0 }; ppmDi = 8.0;
                    fit_color = OxyColors.Black;exp_color = OxyColors.Black.ToColor().ToArgb();peak_color = OxyColors.Crimson;fit_style = LineStyle.Dot;exper_style = LineStyle.Solid;frag_style = LineStyle.Solid;exp_width = 1;frag_width = 2;fit_width = 1;
                    peak_width = 1;cen_width = 1;Xmajor_grid = LineStyle.Solid;Xminor_grid = LineStyle.None;Ymajor_grid = LineStyle.Solid;Yminor_grid = LineStyle.None;X_tick = OxyPlot.Axes.TickStyle.Outside;Y_tick = OxyPlot.Axes.TickStyle.Outside;x_interval = 50;
                    y_interval = 50;x_format = "G";y_format = "G";x_numformat = "0";y_numformat = "0";Xmajor_grid12 = LineStyle.Solid;Xminor_grid12 = LineStyle.None;Ymajor_grid12 = LineStyle.Solid;Yminor_grid12 = LineStyle.None;y_interval12 = 50;
                    X_tick12 = OxyPlot.Axes.TickStyle.Outside;Y_tick12 = OxyPlot.Axes.TickStyle.Outside;y_format12 = "G";y_numformat12 = "0";x_majorStep12 = 5;x_minorStep12 = 1;bar_width = 1;Xmajor_charge_grid12 = LineStyle.Solid;Xminor_charge_grid12 = LineStyle.None;
                    Ymajor_charge_grid12 = LineStyle.Solid;Yminor_charge_grid12 = LineStyle.None;X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;y_charge_majorStep12 = 2;y_charge_minorStep12 = 1;x_charge_majorStep12 = 5;
                    x_charge_minorStep12 = 1;Xint_major_grid13 = LineStyle.Solid;Xint_minor_grid13 = LineStyle.None;Yint_major_grid13 = LineStyle.Solid;Yint_minor_grid13 = LineStyle.None;x_format13 = "G";x_numformat13 = "0";x_interval13 = 50;Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
                    Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;xINT_majorStep13 = 5;xINT_minorStep13 = 1;yINT_majorStep13 = 5;yINT_minorStep13 = 1;int_width = 1;
                }
            }           
        }

        public void save_preferences()
        {
            // will save user preferences in file
            string[] preferences = new string[1];

            // Set the path, and create if not existing 
            DirectoryInfo di = new DirectoryInfo(root_path);
            if (di.Exists != true) di.Create();

            preferences[0] += "max ppm error: " + ppmError.ToString() + "\r\n";
            preferences[0] += "peak detect min intensity: " + min_intes.ToString() + "\r\n";
            preferences[0] += "size of fragments groups: " + frag_mzGroups.ToString() + "\r\n";
            preferences[0] += "size of fit group: " + fit_bunch.ToString() + "\r\n";
            preferences[0] += "size of fit overlap: " + fit_cover.ToString() + "\r\n";

            preferences[0] += "1 most intence: " + selection_rule[0].ToString() + "\r\n";
            preferences[0] += "2 most intence: " + selection_rule[1].ToString() + "\r\n";
            preferences[0] += "3 most intence: " + selection_rule[2].ToString() + "\r\n";
            preferences[0] += "half most intence: " + selection_rule[3].ToString() + "\r\n";
            preferences[0] += "half(-) most intence: " + selection_rule[4].ToString() + "\r\n";
            preferences[0] += "half(+) most intence: " + selection_rule[5].ToString() + "\r\n";

            preferences[0] += "fit results sorting by Ai: " + fit_sort[0].ToString() + "\r\n";
            preferences[0] += "fit results sorting by A: " + fit_sort[1].ToString() + "\r\n";
            preferences[0] += "fit results sorting by di: " + fit_sort[2].ToString() + "\r\n";
            preferences[0] += "fit results sorting by sse: " + fit_sort[3].ToString() + "\r\n";
            preferences[0] += "fit results sorting by ei: " + fit_sort[4].ToString() + "\r\n";
            preferences[0] += "fit results sorting by di': " + fit_sort[5].ToString() + "\r\n";

            preferences[0] += "Ai coefficient: " + a_coef[0].ToString() + "\r\n";
            preferences[0] += "A coefficient: " + a_coef[1].ToString() + "\r\n";
            preferences[0] += "di coefficient: " + a_coef[2].ToString() + "\r\n";
            preferences[0] += "sse coefficient: " + a_coef[3].ToString() + "\r\n";
            preferences[0] += "ei coefficient: " + a_coef[4].ToString() + "\r\n";
            preferences[0] += "di' coefficient: " + a_coef[5].ToString() + "\r\n";

            preferences[0] += "Amount of best solutions presented: " + visible_results.ToString() + "\r\n";
            preferences[0] += "Ai score threshold: " + fit_thres[0].ToString() + "\r\n";
            preferences[0] += "A score threshold: " + fit_thres[1].ToString() + "\r\n";
            preferences[0] += "di score threshold: " + fit_thres[2].ToString() + "\r\n";
            preferences[0] += "ei score threshold: " + fit_thres[3].ToString() + "\r\n";
            preferences[0] += "di' score threshold: " + fit_thres[4].ToString() + "\r\n";

            preferences[0] += "max ppm error for di ei calculation: " + ppmDi.ToString() + "\r\n";

            // tab1 line isoplot

            preferences[0] += "Spectrum line width: " + exp_width.ToString() + "\r\n";
            preferences[0] += "Fragment line width: " + frag_width.ToString() + "\r\n";
            preferences[0] += "Fit line width: " + fit_width.ToString() + "\r\n";
            preferences[0] += "Experimental peak line width: " + peak_width.ToString() + "\r\n";
            preferences[0] += "Centroid line width: " + cen_width.ToString() + "\r\n";
            // tab2 axis isoplot
            if (Xmajor_grid == LineStyle.Solid) { preferences[0] += "Xmajor_grid: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xmajor_grid: " + false + "\r\n"; }
            if (Xminor_grid == LineStyle.Solid) { preferences[0] += "Xminor_grid: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xminor_grid: " + false + "\r\n"; }
            if (Ymajor_grid == LineStyle.Solid) { preferences[0] += "Ymajor_grid: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Ymajor_grid: " + false + "\r\n"; }
            if (Yminor_grid == LineStyle.Solid) { preferences[0] += "Yminor_grid: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yminor_grid: " + false + "\r\n"; }          
            //preferences[0] += X_tick = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Y_tick = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "x interval in iso_plot: " + x_interval.ToString() + "\r\n";
            preferences[0] += "y interval in iso_plot: " + y_interval.ToString() + "\r\n";           
            preferences[0] += "x number1 format in iso_plot: " + x_format.ToString() + "\r\n";
            preferences[0] += "y number1 format in iso_plot: " + y_format.ToString() + "\r\n";
            preferences[0] += "x number2 format in iso_plot: " + x_numformat.ToString() + "\r\n"; 
            preferences[0] += "y number2 format in iso_plot: " + y_numformat.ToString() + "\r\n";

            //primary tab plots

            //intensity
            if (Xmajor_grid12 == LineStyle.Solid) { preferences[0] += "Xmajor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xmajor_grid12: " + false + "\r\n"; }
            if (Xminor_grid12 == LineStyle.Solid) { preferences[0] += "Xminor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xminor_grid12: " + false + "\r\n"; }
            if (Ymajor_grid12 == LineStyle.Solid) { preferences[0] += "Ymajor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Ymajor_grid12: " + false + "\r\n"; }
            if (Yminor_grid12 == LineStyle.Solid) { preferences[0] += "Yminor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yminor_grid12: " + false + "\r\n"; }
            preferences[0] += "y interval in primary intensity plot: " + y_interval12.ToString() + "\r\n";
            //preferences[0] += X_tick12 = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "y number1 format in primary intensity plot: " + y_format12.ToString() + "\r\n";
            preferences[0] += "y number2 format in primary intensity plot: "+ y_numformat12.ToString() + "\r\n";
            preferences[0] += "x major step in primary intensity plot: " + x_majorStep12.ToString() + "\r\n";
            preferences[0] += "x minor step in primary intensity plot: " + x_minorStep12.ToString() + "\r\n";
            preferences[0] += "bar width in primary intensity plot: " + bar_width.ToString() + "\r\n";
            //charge
            if (Xmajor_charge_grid12 == LineStyle.Solid) { preferences[0] += "Xmajor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xmajor_charge_grid12: " + false + "\r\n"; }
            if (Xminor_charge_grid12 == LineStyle.Solid) { preferences[0] += "Xminor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xminor_charge_grid12: " + false + "\r\n"; }
            if (Ymajor_charge_grid12 == LineStyle.Solid) { preferences[0] += "Ymajor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Ymajor_charge_grid12: " + false + "\r\n"; }
            if (Yminor_charge_grid12 == LineStyle.Solid) { preferences[0] += "Yminor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yminor_charge_grid12: " + false + "\r\n"; }       
            //preferences[0] += X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "y major step in primary charge plot: " + y_charge_majorStep12.ToString() + "\r\n";
            preferences[0] += "y minor step in primary charge plot: " + y_charge_minorStep12.ToString() + "\r\n";
            preferences[0] += "x major step in primary charge plot: "+ x_charge_majorStep12.ToString() + "\r\n"; 
            preferences[0] += "x minor step in primary charge plot: " + x_charge_minorStep12.ToString() + "\r\n";

            //internal tab plots
            if (Xint_major_grid13 == LineStyle.Solid) { preferences[0] += "Xint_major_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xint_major_grid13: " + false + "\r\n"; }
            if (Xint_minor_grid13 == LineStyle.Solid) { preferences[0] += "Xint_minor_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xint_minor_grid13: " + false + "\r\n"; }
            if (Yint_major_grid13 == LineStyle.Solid) { preferences[0] += "Yint_major_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yint_major_grid13: " + false + "\r\n"; }
            if (Yint_minor_grid13 == LineStyle.Solid) { preferences[0] += "Yint_minor_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yint_minor_grid13: " + false + "\r\n"; }
            preferences[0] += "x number1 format in internal intensity plot: " + x_format13.ToString() + "\r\n";
            preferences[0] += "x number2 format in internal intensity plot: " + x_numformat13.ToString() + "\r\n";
            preferences[0] += "x interval in internal intensity plot: " + x_interval13.ToString() + "\r\n";
            //preferences[0] += Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "x major step in internal  plot: " + xINT_majorStep13.ToString() + "\r\n";
            preferences[0] += "x minor step in internal  plot: " + xINT_minorStep13.ToString() + "\r\n";
            preferences[0] += "y major step in internal  plot: " + yINT_majorStep13.ToString() + "\r\n";
            preferences[0] += "y minor step in internal  plot: " + yINT_minorStep13.ToString() + "\r\n";
            preferences[0] += "line width in internal  plot: " + int_width.ToString() + "\r\n";


            // save to default file
            File.WriteAllLines(root_path + "\\preferences.txt", preferences);
        }

        #endregion

        #region 1.a Import data
        private void loadExp_Btn_Click(object sender, EventArgs e)
        {
            loadExp_Btn.Enabled = false;
            try
            {
                load_experimental_sequence();
            }
            catch
            {
                MessageBox.Show("Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading experimental data");
            }

            finally
            {
                loadExp_Btn.Enabled = true;
            }
           
        }

        private void load_experimental_sequence()
        {
            // load experimental and break if not loaded ok
            if (!load_experimental()) return;            

            sw1.Reset(); sw1.Start();
            post_load_actions();
            sw1.Stop(); Debug.WriteLine("post_load_actions: " + sw1.ElapsedMilliseconds.ToString());

            Thread peak_detection = new Thread(peakDetect_and_resolutionRef);
            peak_detection.Start();
            plotCentr_chkBox.Enabled = true;
        }

        private bool load_experimental()
        {
            if (!is_loading && !is_calc)
            {
                OpenFileDialog expData = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Title = "Load experimental data", FileName = "", Filter = "data file|*.txt|All files|*.*" };
                List<string> lista = new List<string>();                
                if (expData.ShowDialog() != DialogResult.Cancel)
                {                    
                    sw1.Reset(); sw1.Start();
                    StreamReader objReader = new StreamReader(expData.FileName);
                    file_name = expData.SafeFileName.Remove(expData.SafeFileName.Length - 4);
                    do { lista.Add(objReader.ReadLine()); }
                    while (objReader.Peek() != -1);
                    objReader.Close();

                    experimental.Clear();

                    //add toolstrip progress bar
                    progress_display_start(lista.Count, "Loading experimental data...");
                    max_exp = 0.0;
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] tmp_str = lista[j].Split('\t');
                            if (tmp_str.Length == 2) experimental.Add(new double[] { dParser(tmp_str[0]), dParser(tmp_str[1]) });
                            if (max_exp < dParser(tmp_str[1])) max_exp = dParser(tmp_str[1]);
                        }
                        catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); return false; }

                        if (j % 10000 == 0 && j > 0) progress_display_update(j);
                    }
                    sw1.Stop(); Debug.WriteLine("load_experimental: " + sw1.ElapsedMilliseconds.ToString());
                    progress_display_stop();
                    plotExp_chkBox.Enabled = true;
                    filename_txtBx.Text = file_name;
                    return true;
                }
                else return false;
            }
            else { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false; }
        }

        private void post_load_actions()
        {
            insert_exp = true;
            recalc = true;

            // post load actions
            enable_UIcontrols("post load");

            //selected_window = 1000000;
            //fitMin_Box.Text = experimental[0][0].ToString();
            //fitMax_Box.Text = experimental[experimental.Count - 1][0].ToString();

            // set experimental line color to black
            if (custom_colors.Count > 0) custom_colors[0] = exp_color;
            else custom_colors.Add(exp_color);

            // copy experimental to all_data
            experimental_to_all_data();
            recalculate_all_data_aligned();

            ////// add experimental to plot
            //refresh_iso_plot();

            start_idx = 0;
            end_idx = experimental.Count;
        }

        private void peakDetect_and_resolutionRef()
        {
            // run peak detection and add new resolution map from experimental
            if (experimental.Count() > 0)
            {
                peak_detect();

                if (peak_points.Count() > 0)
                {
                    displayPeakList_btn.Invoke(new Action(() => displayPeakList_btn.Enabled = true));   //thread safe call
                    exp_res++;
                    //plot_peak(); 
                    List<double> tmp1 = new List<double>();
                    List<double> tmp2 = new List<double>();
                    foreach (double[] peak in peak_points)
                    {
                        if (peak[5] > 200000)
                        {
                            tmp1.Add((double)(peak[1] + peak[4]));
                            tmp2.Add((double)peak[3]);
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

        #region 1.b Import fragment list
        private void LoadMS_Btn_Click(object sender, EventArgs e)
        {
            loadMS_Btn.Enabled = false;
            if (String.IsNullOrEmpty(Peptide)) { MessageBox.Show("First insert Sequence. Then load a fragment file.", "No sequence found."); loadMS_Btn.Enabled = true;return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure you have first inserted the correct sequence?", "Sequence Editor", MessageBoxButtons.YesNo);
            if (dialogResult==DialogResult.No)
            {
                Form16 frm16 = new Form16(this);
                frm16.ShowDialog();
            }
            try
            {
                import_fragments();
            }
            catch
            {
                MessageBox.Show("Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading Fragments");
            }

            finally
            {
                loadMS_Btn.Enabled = true;
            }
            
        }

        private void import_fragments()
        {
            OpenFileDialog fragment_import = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Filter = "txt files (*.txt)|*.txt", FilterIndex = 2, RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true };
            List<string> lista = new List<string>();

            if (fragment_import.ShowDialog() != DialogResult.Cancel)
            {
                sw1.Reset(); sw1.Start();
                StreamReader objReader = new StreamReader(fragment_import.FileName);
                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                ChemFormulas.Clear();               
                peptide_textBox1.Text = Path.GetFileNameWithoutExtension(fragment_import.FileName);
                lista.RemoveAt(0);
                get_precursor_carbons(lista.Last());
                progress_display_start(lista.Count, "Importing fragments list...");

                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');
                        if (tmp_str.Length == 5) assign_resolve_fragment(tmp_str);
                        else if(calc_FF) assign_manually_pro_fragment(tmp_str);
                    }
                    catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error!"); return; }

                    if (j % 1000 == 0 && j > 0) progress_display_update(j);
                }
                progress_display_stop();
                post_import_fragments();
                sw1.Stop(); Debug.WriteLine("Import frags and generate X: " + sw1.ElapsedMilliseconds.ToString());
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
                Resolution = new double(),
                Combinations = new List<Combination_1>(),
                Profile = new List<PointPlot>(),
                Centroid = new List<PointPlot>(),
                Combinations4 = new List<Combination_4>(),
                FinalFormula = string.Empty, 
                Factor=1.0,
                Fixed=false,
                PrintFormula= frag_info[4],
                Max_man_int = 0
            });

            int i = ChemFormulas.Count - 1;

            // Note on formulas
            // InputFormula is the text from MSProduct. It has 1 more H. We remove it, and we store at the same variable ONCE, on loading of the text file.
            // So, we need to add Adduct H. They are exactly the same amount with the charge.
            // PrintFormula is the same and it should be redundant. FinalFormula is all elements together and it is not used outside of enviPat code.
            // Example: a13 +3 Ubiquitin
            // MSProduct -> C67 H117 N16 O16 S1 --- InputFormula (before fix) C67 H117 N16 O16 S1, Adduct 0
            // InputFormula (after fix) C67 H116 N16 O16 S1, Adduct H3 --- FinalFormula C67 H119 N16 O16 S1 Adduct ? (FinalFormula is not used)

            if(!calc_FF)ChemFormulas[i].PrintFormula = ChemFormulas[i].InputFormula = fix_formula(ChemFormulas[i].InputFormula);
            ChemFormulas[i].Charge = Int32.Parse(frag_info[3]);

            // all ions have as many H in Adduct as their charge
            ChemFormulas[i].Adduct = "H" + ChemFormulas[i].Charge.ToString();

            if (char.IsLower(frag_info[1][0]))
            {
                // normal fragment
                ChemFormulas[i].Ion_type = ChemFormulas[i].Ion;
                if (ChemFormulas[i].Ion.StartsWith("d") || ChemFormulas[i].Ion.StartsWith("w") || ChemFormulas[i].Ion.StartsWith("v")) ChemFormulas[i].Color = OxyColors.Turquoise;
                else if (ChemFormulas[i].Ion.StartsWith("a")) ChemFormulas[i].Color = OxyColors.Green;
                else if (ChemFormulas[i].Ion.StartsWith("b")) ChemFormulas[i].Color = OxyColors.Blue;
                else if (ChemFormulas[i].Ion.StartsWith("x")) ChemFormulas[i].Color = OxyColors.LimeGreen;
                else if (ChemFormulas[i].Ion.StartsWith("y")) ChemFormulas[i].Color = OxyColors.DodgerBlue;
                else if (ChemFormulas[i].Ion.StartsWith("z")) ChemFormulas[i].Color = OxyColors.Tomato;
                else if (ChemFormulas[i].Ion.StartsWith("c")) ChemFormulas[i].Color = OxyColors.Firebrick;
                else ChemFormulas[i].Color = OxyColors.PaleGoldenrod;

                string lbl = "";
                if (ChemFormulas[i].Ion_type.Length==1) { lbl = ChemFormulas[i].Ion_type + ChemFormulas[i].Index; }
                else { lbl ="(" +ChemFormulas[i].Ion_type +")"+ChemFormulas[i].Index; }
                ChemFormulas[i].Radio_label = lbl;
                if(ChemFormulas[i].Charge>0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
            }
            else
            {
                // internal fragment or precursor (KIQDKEGIP-H2O-NH3, MH-H2O)
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
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
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
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                }
                else
                {
                    ChemFormulas[i].Ion_type = "internal b" + substring[1];
                    ChemFormulas[i].Color = OxyColors.MediumOrchid;
                    ChemFormulas[i].Index = (Peptide.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (Peptide.IndexOf(substring[0]) + substring[0].Length).ToString();

                    string lbl = "internal_b" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                    ChemFormulas[i].Radio_label = lbl;
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                }
            }
        }
        private void assign_manually_pro_fragment(string[] frag_info)
        {
            //frag_info 0:m/z monoisotopic , 1:ion type , 2:index  ,3:index to ,4:charge ,5:formula ,6: iso_ amount
            ChemFormulas.Add(new ChemiForm
            {
                InputFormula = frag_info[5],
                Adduct = string.Empty,
                Deduct = string.Empty,
                Multiplier = 1,
                Mz = frag_info[0],
                Ion = frag_info[1],
                Index = frag_info[2],
                IndexTo = frag_info[3],
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
                Combinations4 = new List<Combination_4>(),
                FinalFormula = string.Empty,
                Factor = 1.0,
                Fixed = false,
                PrintFormula = frag_info[5],
                Max_man_int=0
            });

            int i = ChemFormulas.Count - 1;

            // Note on formulas
            // InputFormula is the text from MSProduct. It has 1 more H. We remove it, and we store at the same variable ONCE, on loading of the text file.
            // So, we need to add Adduct H. They are exactly the same amount with the charge.
            // PrintFormula is the same and it should be redundant. FinalFormula is all elements together and it is not used outside of enviPat code.
            // Example: a13 +3 Ubiquitin
            // MSProduct -> C67 H117 N16 O16 S1 --- InputFormula (before fix) C67 H117 N16 O16 S1, Adduct 0
            // InputFormula (after fix) C67 H116 N16 O16 S1, Adduct H3 --- FinalFormula C67 H119 N16 O16 S1 Adduct ? (FinalFormula is not used)

            ChemFormulas[i].Charge = Int32.Parse(frag_info[4]);
            if (frag_info.Length>6) { ChemFormulas[i].Max_man_int = dParser(frag_info[6]); }            
            // all ions have as many H in Adduct as their charge
            ChemFormulas[i].Adduct = "H" + ChemFormulas[i].Charge.ToString();

            if (char.IsLower(frag_info[1][0]))
            {
                // normal fragment
                ChemFormulas[i].Ion_type = ChemFormulas[i].Ion;
                if (ChemFormulas[i].Ion.StartsWith("d") || ChemFormulas[i].Ion.StartsWith("w") || ChemFormulas[i].Ion.StartsWith("v")) ChemFormulas[i].Color = OxyColors.Turquoise;
                else if (ChemFormulas[i].Ion.StartsWith("a")) ChemFormulas[i].Color = OxyColors.Green;
                else if (ChemFormulas[i].Ion.StartsWith("b")) ChemFormulas[i].Color = OxyColors.Blue;
                else if (ChemFormulas[i].Ion.StartsWith("x")) ChemFormulas[i].Color = OxyColors.LimeGreen;
                else if (ChemFormulas[i].Ion.StartsWith("y")) ChemFormulas[i].Color = OxyColors.DodgerBlue;
                else if (ChemFormulas[i].Ion.StartsWith("z")) ChemFormulas[i].Color = OxyColors.Tomato;
                else if (ChemFormulas[i].Ion.StartsWith("c")) ChemFormulas[i].Color = OxyColors.Firebrick;
                else if(ChemFormulas[i].Ion.Contains("int") && ChemFormulas[i].Ion.Contains("b")) ChemFormulas[i].Color = OxyColors.MediumOrchid;
                else if (ChemFormulas[i].Ion.Contains("int")) ChemFormulas[i].Color = OxyColors.DarkViolet;
                else ChemFormulas[i].Color = OxyColors.PaleGoldenrod;

                string lbl = "";
                if (ChemFormulas[i].Ion.StartsWith("int"))//for internal fragments
                {
                    string[] substring = new string[2] { "", "" };
                    int dash_idx = ChemFormulas[i].Ion.IndexOf('-');
                    if (dash_idx != -1)
                    {
                        substring[0] = ChemFormulas[i].Ion.Substring(0, dash_idx);
                        substring[1] = ChemFormulas[i].Ion.Substring(dash_idx);
                    }
                    else substring[0] = ChemFormulas[i].Ion;

                    if (ChemFormulas[i].Ion.Contains("b"))//internal b
                    {
                        ChemFormulas[i].Ion_type = "internal b" + substring[1];                       

                        lbl = "internal_b" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                        ChemFormulas[i].Radio_label = lbl;
                        if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                        else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                    }
                    else//internal a
                    {
                        ChemFormulas[i].Ion_type = "internal a" + substring[1];                        
                        lbl = "internal_a" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                        ChemFormulas[i].Radio_label = lbl;
                        if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                        else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                    }
                }
                else//for primary fragments
                {
                    if (ChemFormulas[i].Ion_type.Length == 1) { lbl = ChemFormulas[i].Ion_type + ChemFormulas[i].Index; }
                    else { lbl = "(" + ChemFormulas[i].Ion_type + ")" + ChemFormulas[i].Index; }
                    ChemFormulas[i].Radio_label = lbl;
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                }
               
            }
            else
            {
                // internal fragment or precursor (KIQDKEGIP-H2O-NH3, MH-H2O)
                // split string in two parts, [0] main [1]adduct (if any)
                string[] substring = new string[2] { "", "" };
                int dash_idx = ChemFormulas[i].Ion.IndexOf('-');
                if (dash_idx != -1)
                {
                    substring[0] = ChemFormulas[i].Ion.Substring(0, dash_idx);
                    substring[1] = ChemFormulas[i].Ion.Substring(dash_idx);
                }
                else substring[0] = ChemFormulas[i].Ion;

                if (substring[0].StartsWith("MH")/* && ChemFormulas[i].InputFormula.StartsWith(precursor_carbons)*/)  // an internal b could be MHQRP for example, so check also carbons
                {
                    ChemFormulas[i].Ion_type = "M" + substring[1];
                    ChemFormulas[i].Color = OxyColors.DarkRed;
                    ChemFormulas[i].Index = 0.ToString();
                    ChemFormulas[i].IndexTo = (Peptide.Length - 1).ToString();

                    string lbl = ChemFormulas[i].Ion_type;
                    ChemFormulas[i].Radio_label = lbl;
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
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
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                }
                else
                {
                    ChemFormulas[i].Ion_type = "internal b" + substring[1];
                    ChemFormulas[i].Color = OxyColors.MediumOrchid;
                    ChemFormulas[i].Index = (Peptide.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (Peptide.IndexOf(substring[0]) + substring[0].Length).ToString();

                    string lbl = "internal_b" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                    ChemFormulas[i].Radio_label = lbl;
                    if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+";
                    else ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-";
                }
            }
        }
        private void post_import_fragments()
        {
            // MS-product does not generate charge states for x fragments. We have to calculate and add them and sort by mz
            if(!calc_FF)generate_x();
            ChemFormulas = ChemFormulas.OrderBy(o => Double.Parse(o.Mz)).ToList();

            mzMin_Box.Text = ChemFormulas.First().Mz.ToString();
            mzMax_Box.Text = ChemFormulas.Last().Mz.ToString();

            enable_UIcontrols("post import fragments");
        }

        private void generate_x()
        {
            // this adds all x fragments msProduct does not generate (x multiCharged and x with adducts)

            // PROG: Example of deadlock!!! ChemFormulas.Count CANNOT be used in for loop, it is augmented inside the loop and loop will never end if continue to add y_type!!!!!
            int total_fragments_fromFile = ChemFormulas.Count;

            for (int i = 0; i < total_fragments_fromFile; i++)
            {
                if (ChemFormulas[i].Ion.StartsWith("y"))
                {
                    bool adduct = ChemFormulas[i].Ion.Contains("-");
                    int charge = ChemFormulas[i].Charge;

                    if (adduct || (!adduct && charge > 1))
                    {
                        // x have +CO -2H compared to y. BUT!!!! we have to build the inputFormula as if it was from MSProduct (that has +1H) so we will remove only 1H!!!!
                        string mz = Math.Round(Convert.ToDouble(ChemFormulas[i].Mz) + (11.99945142 + 15.99436604 - 2 * 1.007276452) / Convert.ToDouble(charge), 4).ToString();
                        string ion = ChemFormulas[i].Ion.Replace('y', 'x');
                        string index = ChemFormulas[i].Index;
                        string charges = ChemFormulas[i].Charge.ToString();

                        string[] tmp = ChemFormulas[i].InputFormula.Split(' ');
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            if (tmp[j].StartsWith("C")) tmp[j] = "C" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) + 1).ToString();          //+C
                            else if (tmp[j].StartsWith("O")) tmp[j] = "O" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) + 1).ToString();     //+O
                            else if (tmp[j].StartsWith("H")) tmp[j] = "H" + (Convert.ToInt16(tmp[j].Substring(1, tmp[j].Length - 1)) - 1).ToString();     //-1H
                        }
                        string inputFormula = string.Join(" ", tmp);

                        string[] frag_info = new string[] { mz, ion, index, charges, inputFormula };
                        assign_resolve_fragment(frag_info);
                    }
                }
            }
        }
        #endregion

        #region 2.a Select fragments and calculate their envelopes
        private void Calc_Btn_Click(object sender, EventArgs e)
        {
            calc_Btn.Enabled = false;
            try
            {
                try
                {
                    clearList();
                }
                catch
                {

                }
                finally
                {
                    fragments_and_calculations_sequence_A();
                }

            }
            catch
            {
                MessageBox.Show("Please close the program and restart the procedure.", "Error in calculations!");
            }

            finally
            {
                calc_Btn.Enabled = true;
            }
            
        }

        private void fragments_and_calculations_sequence_A()
        {
            // this the main sequence after loadind data
            // 1. select fragments according to UI
            Fragments2.Clear();
            selectedFragments.Clear();
            custom_colors.Clear();
            custom_colors.Add(exp_color);
            sw1.Reset(); sw1.Start();
            List<ChemiForm> selected_fragments = select_fragments2();
            if (selected_fragments == null) return;
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            calculate_fragments_resolution(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments2.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties(selected_fragments));
            envipat_properties.Start();
            plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true; 
        }

        public void fragments_and_calculations_sequence_B()
        {
            calc_FF = false;
            GC.Collect();
            if (all_data.Count > 1)
            {
                all_data.RemoveRange(1, all_data.Count - 1);
                custom_colors.RemoveRange(1, custom_colors.Count - 1);
            }
            
            all_data_aligned.Clear();
            GC.Collect();
            sw1.Reset(); sw1.Start();
            // 1. Pass Fragments info to all_data array (experimetal have already been added, in after loading actions)
            add_fragments_to_all_data();
            sw1.Stop(); Debug.WriteLine("Init frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. rebuild frag_listView in UI
            populate_frag_treeView();
            populate_fragtypes_treeView();
            sw1.Stop(); Debug.WriteLine("Populate frag tree: " + sw1.ElapsedMilliseconds.ToString());
            // 3. build the all_data_alligned structure
            recalculate_all_data_aligned();
            enable_UIcontrols("post calculations");
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
            calc_resolution = true;
            recalc = true;
            neues = Fragments2.Count();

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

        private void calculate_fragment_properties(List<ChemiForm> selected_fragments)
        {
            // main routine for parallel calculation of fragments properties and filtering by ppm and peak rules
            sw1.Reset(); sw1.Start();
            int progress = 0;
            progress_display_start(selected_fragments.Count, "Calculating fragment isotopic distributions...");            
            try
            {
                Parallel.For(0, selected_fragments.Count, (i, state) =>
                {
                    Envipat_Calcs_and_filter_byPPM(selected_fragments[i]);                    
                    // safelly keep track of progress
                    Interlocked.Increment(ref progress);
                    if (progress % 10 == 0 && progress > 0) { progress_display_update(progress); }
                });
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex); MessageBox.Show("Incorrect Data Format. Check your Fragment File.");
            };
            progress_display_stop();            
            // sort by mz the fragments list (global) beause it is mixed by multi-threading
            Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();            
            // also restore indexes to match array position
            for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }

            is_calc = false;
            sw1.Stop(); Debug.WriteLine("Envipat_Calcs_and_filter_byPPM(M): " + sw1.ElapsedMilliseconds.ToString());
            if (selected_fragments.Count > 0 && !selected_fragments[0].Fixed)
            {
                Debug.WriteLine("PPM(): " + sw2.ElapsedMilliseconds.ToString()); sw2.Reset();
                MessageBox.Show("From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments2.Count.ToString() + " were within ppm filter.", "Fragment selection results");
            }
            else MessageBox.Show( selected_fragments.Count.ToString() + " fragments added from file. " , "Fitted fragments file");
            // thread safely fire event to continue calculations
            if (selected_fragments.Count>0) { Invoke(new Action(() => OnEnvelopeCalcCompleted())); }            
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
                    ChemiForm.Get_R(chem, calc_resolution);

                    if (chem.Resolution == 0) chem.Error = true;
                    calc_resolution = false;//the resolution matrix is calculated only once for the forst fragment, and is constant for the other fragments
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

            // case where there is no experimental data OR fitted list's fragments are inserted with their resolution in order to decrease calculations in half(ptofile is calculated once!!!!)
            if (!insert_exp|| chem.Fixed ) { add_fragment_to_Fragments2(chem, cen); return; }
            // MAIN decesion algorithm
            bool fragment_is_canditate = true;
            if (calc_FF)
            {
                fragment_is_canditate = decision_algorithmFF(chem, cen);
                if (ignore_ppm)
                {
                    chem.Profile.Clear();
                    // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
                    ChemiForm.Envelope(chem);
                    add_fragment_to_Fragments2(chem, cen);
                    iiiiiiii++;
                }
                else if (fragment_is_canditate)
                {
                    chem.Profile.Clear();
                    // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
                    ChemiForm.Envelope(chem);
                    add_fragment_to_Fragments2(chem, cen);
                }                
            }
            else
            {
                fragment_is_canditate = decision_algorithm(chem, cen);
                if (fragment_is_canditate)
                {
                    chem.Profile.Clear();
                    // only if the frag is candidate we have to re-calculate Envelope (time costly method) with the new resolution (the matched from experimental peak)
                    ChemiForm.Envelope(chem);
                    add_fragment_to_Fragments2(chem, cen);
                }
            }                  
        }

        private void add_fragment_to_Fragments2(ChemiForm chem, List<PointPlot> cen)
        {
            // adds safely a matched fragment to Fragments2, and releases memory
            lock (_locker)
            {
                if (check_duplicates_Fragments2(chem.Mz, chem.Name, chem.Factor))
                {
                    Fragments2.Add(new FragForm()
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

                    Fragments2.Last().Centroid = cen.Select(point => point.DeepCopy()).ToList();
                    Fragments2.Last().Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                    Fragments2.Last().Counter = Fragments2.Count;
                    Fragments2.Last().Max_intensity = Fragments2.Last().Profile.Max(p => p.Y);
                    //when manually processed data is added sometimes they don't want to fit the data to create the plots in the other tabs,
                    // so factor is calculated based on the input txt the user add that in the last position has the intensity of the fragment
                    if (chem.Max_man_int != 0) { Fragments2.Last().Factor = chem.Max_man_int / Fragments2.Last().Max_intensity; }
                    else if (!Fragments2.Last().Fixed && max_exp > 0) Fragments2.Last().Factor = 0.1 * max_exp / Fragments2.Last().Max_intensity; // start all fragments at 10% of the main experimental peak (one order of mag. less)
                    
                    if (chem.Charge > 0) Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
                    else Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments2, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear();
                    chem.Points.Clear();
                }
                else
                {
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments2, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear();
                    chem.Points.Clear();
                }       
            }
        }
        private bool check_duplicates_Fragments2(string mz,string name, double factor)
        {
            if (Fragments2.Count>0)
            {
                foreach (FragForm fra in Fragments2)
                {
                    if (fra.Mz.Equals(mz) && fra.Name.Equals(name) && Math.Round(fra.Factor,3)== Math.Round(factor, 3) )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void add_fragments_to_all_data()
        {
            // pass the envelope (profile) of each NEW fragment in Fragment2 to all data
            if (all_data.Count == 0) { all_data.Add(new List<double[]>()); custom_colors.Clear(); custom_colors.Add(exp_color); }

            // !!!needs rework for recalculating
            int existing_fragments = all_data.Count - 1;
            int new_fragments = Fragments2.Count - existing_fragments;

            int all_data_start_idx = all_data.Count;
            int all_data_stop_idx = Fragments2.Count;

            for (int i = all_data_start_idx; i < all_data_stop_idx + 1; i++)
            {
                custom_colors.Add(Fragments2[i - 1].Color.ToColor().ToArgb());

                all_data.Add(new List<double[]>());
                for (int p = 0; p < Fragments2[i - 1].Profile.Count; p++)
                    all_data[i].Add(new double[] { Fragments2[i - 1].Profile[p].X, Fragments2[i - 1].Profile[p].Y });
            }
        }

        private void populate_frag_treeView()
        {
            frag_listView.Visible = false;             
            if (frag_tree.Nodes.Count>0)
            {
                frag_tree.Nodes.Clear();
            }
            else
            {
                frag_tree.AfterCheck += (s, e) => {  frag_node_checkChanged(e.Node, e.Node.Checked); };
                frag_tree.NodeMouseClick += (s, e) => { if (!string.IsNullOrEmpty(e.Node.Name)) { singleFrag_manipulation(e.Node); } };
                frag_tree.ContextMenu = new ContextMenu(new MenuItem[5] {new MenuItem("Copy Only Selected", (s, e) => { copyTree_toClip(frag_tree, false,true); }),
                                                                      new MenuItem("Copy Checked", (s, e) => { copyTree_toClip(frag_tree, false); }),
                                                                      new MenuItem("Copy All", (s, e) => { copyTree_toClip(frag_tree, true); }),
                                                                      new MenuItem("Save to File", (s, e) => { saveTree_toFile(frag_tree); }),
                                                                      new MenuItem("Remove", (s, e) => {if(frag_tree.SelectedNode!=null){ remove_node(frag_tree.SelectedNode); } })
                });

            }
            //frag_tree.ContextMenu = new ContextMenu(new MenuItem[1] { new MenuItem("Remove", (s, e) => { remove_node(frag_tree.SelectedNode.Index); }) });

            // interpret fitted results
            frag_tree.BeginUpdate();

            for (int i = 0; i < Fragments2.Count; i++)
            {
                bool newfrag = Fragments2[i].Fixed;
                //if (Fragments2[i].Factor != 1.0) { newfrag = true; }
                // group in mz windows
                // first fragment in group, opens a new ggroup, and contributes to the group title
                if (i % frag_mzGroups == 0) frag_tree.Nodes.Add(Fragments2[i].Mz + " - ");
                // last fragment in group, or last in general, contributes to the group title
                if (i % frag_mzGroups == (frag_mzGroups - 1) || i == Fragments2.Count - 1) frag_tree.Nodes[i / frag_mzGroups].Text += Fragments2[i].Mz;

                frag_tree.Nodes[i / frag_mzGroups].Nodes.Add(new_fragTreeNode(i));
            }

            frag_tree.EndUpdate();
            frag_tree.Visible = true;
        }
        private void remove_node(TreeNode node)
        {
            if (string.IsNullOrEmpty(node.Name)) return;
            int idx = Convert.ToInt32(node.Name);
            fitted_results.Clear();
            if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
            fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            if (fit_tree != null) { selectedFragments.Clear(); fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed. Fit results are disposed."); }
            if (Fragments2.Count > 0)
            {
                factor_panel.Visible = false;
                Fragments2.RemoveAt(idx); // thread safely fire event to continue calculations
                Invoke(new Action(() => OnEnvelopeCalcCompleted()));
            }
        }
        private void singleFrag_manipulation(TreeNode node)
        {
            // will handle the height of frag. Automaticaly by solo fit, or manualy
            int frag_idx = Convert.ToInt32(node.Name);
            double frag_intensity = Fragments2[frag_idx].Factor * Fragments2[frag_idx].Max_intensity;
            factor_panel.Visible = true;
            factor_panel.Controls.Clear();
            Label factor_lbl = new Label { Text = Fragments2[frag_idx].Name, Location = new Point(5, 10), AutoSize = true};
            Button btn_solo = new Button { Text = "fit", Location = new Point(200, 6), Size = new Size(60, 23) };
            NumericUpDown numUD = new NumericUpDown { Minimum =0, Maximum = 1e8M, Value = (decimal)Math.Round(frag_intensity, 1), Increment = (decimal)Math.Round(frag_intensity) / 50,
                                                        Location = new Point(275, 7), Size = new Size(60, 20) };
            btn_solo.Click += (s, e) => 
            {
                if (experimental.Count == 0) { MessageBox.Show("You have to load the experimental data first in order to perform fit!"); return; }
                // run solo fit. Fit calls refresh plot.
                (List<double[]> res, List<int[]> set) = fit_distros_parallel2(new List<int> { frag_idx + 1 }); // selected fragments have +1 index comparing to Fragments2

                Fragments2[frag_idx].Factor = res[0][0];
                node.Checked = true;
                node.Text = node.Text.Remove(node.Text.LastIndexOf(' ')) + " " + (Fragments2[frag_idx].Factor * Fragments2[frag_idx].Max_intensity).ToString("#######");
                numUD.Value = (decimal)Math.Round(Fragments2[frag_idx].Factor * Fragments2[frag_idx].Max_intensity, 1);
            };
            numUD.ValueChanged += (s, e) => 
            {
                // manualy adjust height. We have also to maualy call refresh plot
                Fragments2[frag_idx].Factor = Convert.ToDouble(numUD.Value) / Fragments2[frag_idx].Max_intensity;
                node.Text = node.Text.Remove(node.Text.LastIndexOf(' ')) + " " + (Fragments2[frag_idx].Factor * Fragments2[frag_idx].Max_intensity).ToString("#######");
                refresh_iso_plot();
            };            

            factor_panel.Controls.AddRange(new Control[] { factor_lbl, btn_solo, /*btn_ok,*/ numUD });            
        }      
        private void populate_fragtypes_treeView()
        {
            // create a new tree
            //fragTypes_tree = null;
            //if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Dispose(); }        // for GC?

            //fragTypes_tree = new TreeView() { CheckBoxes = true, Location = new Point(555, 560), Name = "fragType_tree", Size = new Size(338, 420), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right };
            //user_grpBox.Controls.Add(fragTypes_tree);
            //fragTypes_tree.BringToFront();
            if (fragTypes_tree.Nodes.Count>0) { fragTypes_tree.Nodes.Clear(); }
            fragTypes_tree.ContextMenu = new ContextMenu(new MenuItem[3] { new MenuItem("Copy", (s, e) => { copyTree_toClip(fragTypes_tree, false); }),
                                                                           new MenuItem("Copy All", (s, e) => { copyTree_toClip(fragTypes_tree, true); }),
                                                                           new MenuItem("Save to File", (s, e) => { saveTree_toFile(fragTypes_tree); }) });

            fragTypes_tree.BeginUpdate();
            for (int i = 0; i < Fragments2.Count; i++)
            {
                string ion_type = Fragments2[i].Ion_type;
                bool added = false;
                if (Fragments2[i].Fixed)
                {
                    // check if base node corresponding to type already exists and add fragment. Else make a new base node 
                    foreach (TreeNode baseNode in fragTypes_tree.Nodes)
                    {
                        if (baseNode.Text == ion_type)
                        {
                            // insert at sorted position. Get index of already added fragment
                            for (int j = 0; j < baseNode.Nodes.Count; j++)
                            {
                                int inTree_frag_idx = Convert.ToInt32(baseNode.Nodes[j].Name);
                                int inTree_num = Convert.ToInt32(Fragments2[inTree_frag_idx].Index);
                                int inTree_charge = Fragments2[inTree_frag_idx].Charge;
                                int curr_num = Convert.ToInt32(Fragments2[i].Index);
                                int curr_charge = Fragments2[i].Charge;

                                // case where curr_frag 
                                if (curr_num < inTree_num)
                                {
                                    baseNode.Nodes.Insert(j, new_fragTreeNode(i));
                                    added = true; break;
                                }

                                else if (curr_num == inTree_num)
                                {
                                    for (int k = j; k < baseNode.Nodes.Count; k++)
                                    {
                                        if (curr_charge < Fragments2[Convert.ToInt32(baseNode.Nodes[k].Name)].Charge ||
                                            curr_num < Convert.ToInt32(Fragments2[Convert.ToInt32(baseNode.Nodes[k].Name)].Index))
                                        {
                                            baseNode.Nodes.Insert(k, new_fragTreeNode(i));
                                            added = true; break;
                                        }
                                        else if (k == baseNode.Nodes.Count - 1)
                                        {
                                            baseNode.Nodes.Add(new_fragTreeNode(i));
                                            added = true; break;
                                        }
                                    }
                                    break;
                                }
                            }

                            if (!added)
                            {
                                baseNode.Nodes.Add(new_fragTreeNode(i));
                                added = true;
                            }
                        }
                    }

                    if (!added)
                    {
                        TreeNode tr_inner = new_fragTreeNode(i);
                        TreeNode tr_base = new TreeNode { Text = ion_type };
                        tr_base.Nodes.Add(tr_inner);
                        fragTypes_tree.Nodes.Add(tr_base);
                    }
                }   
            }
            fragTypes_tree.EndUpdate();
            fragTypes_tree.Visible = true; fragStorage_Lbl.Visible = true;

        }

        private TreeNode new_fragTreeNode(int idx)
        {
            TreeNode tr = new TreeNode
            {
                Text = Fragments2[idx].Name + "  -  " + Fragments2[idx].Mz + "  -  " + Fragments2[idx].InputFormula + "  -  " + Fragments2[idx].PPM_Error.ToString("0.##") + "  -  " +
                                       (Fragments2[idx].Factor * Fragments2[idx].Max_intensity).ToString("0"),
                Name = idx.ToString(),
                Tag = Fragments2[idx].Counter.ToString(),
                Checked = Fragments2[idx].To_plot
            };
            //this extra line is added in case of extra fragments are added while the user has already loaded and checked some other
            //one example is when the user adds an extra fragments from the fragment calculator
            if (Fragments2[idx].To_plot) { if (!selectedFragments.Contains(idx + 1)) { selectedFragments.Add(idx + 1); } }
            if (Fragments2[idx].Fixed)
            {
                tr.ForeColor = Color.DarkGreen;
            }
            selectedFragments = selectedFragments.OrderBy(p => p).ToList();
            return tr;
        }

        private void copyTree_toClip(TreeView tree, bool all_nodes,bool only_selected=false)
        {
            StringBuilder sb = new StringBuilder();
            if (only_selected && tree.SelectedNode !=null)
            {
                TreeNode subNode = tree.SelectedNode;
                if (string.IsNullOrEmpty(subNode.Name))
                {
                    foreach (TreeNode nn in subNode.Nodes)
                    {
                        int i = Convert.ToInt32(nn.Name);
                        if (Fragments2[i].Name.Contains("intern"))
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].IndexTo + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                        else
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                    }
                }
                else
                {
                    int i = Convert.ToInt32(subNode.Name);
                    if (Fragments2[i].Name.Contains("intern"))
                        sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].IndexTo + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                    "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                    else
                        sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                    "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                }               
            }
            else
            {
                foreach (TreeNode baseNode in tree.Nodes)
                {
                    foreach (TreeNode subNode in baseNode.Nodes)
                    {
                        // determine if all nodes, or only the checked ones will be saved
                        if (!all_nodes)
                            if (!subNode.Checked) continue;

                        int i = Convert.ToInt32(subNode.Name);
                        if (Fragments2[i].Name.Contains("intern"))
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].IndexTo + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                        else
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                    }
                }
            }           
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());
        }

        private void saveTree_toFile(TreeView tree)
        {
            // to be implemented
        }

        private void frag_node_checkChanged(TreeNode node, bool is_checked)
        {
            this.Cursor= System.Windows.Forms.Cursors.WaitCursor;
            // this event is called from the fragTree directly, but also from the fitTree indirectly

            // if it is a base node, (un)check all subNodes
            if (string.IsNullOrEmpty(node.Name))
            {
                block_plot_refresh = true;
                foreach (TreeNode subNode in node.Nodes)
                {
                    if (subNode.Checked != node.Checked)
                    {
                        subNode.Checked = node.Checked;
                    }                   
                }                   
                block_plot_refresh = false;
                if (!block_fit_refresh) { refresh_iso_plot(); }
            }
            else
            {
                int idx = Convert.ToInt32(node.Name);
                if (Fragments2[idx].To_plot != is_checked)
                {
                    frag_tree.BeginUpdate();
                    if (is_checked)
                    {
                        node.BackColor = Color.Gainsboro; EnsureVisibleWithoutRightScrolling(node); Fragments2[idx].To_plot = is_checked;
                        // selectedFragments list starts with 1, Fragments2 start with 0. Also first check if it is already checked (avoid entering the same frag multiple times)
                        if (!selectedFragments.Contains(idx + 1)) selectedFragments.Add(idx + 1);
                    }
                    else
                    {
                        node.BackColor = Color.Transparent; Fragments2[idx].To_plot = is_checked;
                        // selectedFragments list starts with 1, Fragments2 start with 0.
                        selectedFragments.Remove(idx + 1);
                    }

                    selectedFragments = selectedFragments.OrderBy(p => p).ToList();

                    int k = node.Parent.Text.IndexOf('(');
                    if (k > 0) { node.Parent.Text = node.Parent.Text.Remove(k); }
                    int node_count = Find_selected_subnodes(node.Parent);
                    node.Parent.Text += "(" + node_count.ToString() + ")";
                    // do not refresh if frag check is caused by selecting a fit. It will cut unecessary calls for each of the many fragments in fit set
                    if (!block_plot_refresh && !block_fit_refresh) refresh_iso_plot();
                    frag_tree.EndUpdate();                    
                }              
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private int Find_selected_subnodes(TreeNode node)
        {
            int count = 0;
            foreach(TreeNode nn in node.Nodes)
            {
                if (nn.Checked) count++;
            }
            return count;
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
            int rule_idx = Array.IndexOf(selection_rule, true);

            if (rule_idx < 3) contrib_peaks = rule_idx + 1;   // hard limit, one two or three peaks
            else
            {
                if (rule_idx == 3) contrib_peaks = total_peaks / 2;                 // Total 8, use 4. Total 7, use 3
                else if (rule_idx == 4) contrib_peaks = total_peaks / 2 - 1;        // Total 8, use 3. Total 7, use 2
                else if (rule_idx == 5) contrib_peaks = total_peaks / 2 + 1;        // Total 8, use 5. Total 7, use 4
            }            

            // sanity check. No matter what, check at least most intense peak!
            if (contrib_peaks == 0) contrib_peaks = 1;

            for (int i = 0; i < contrib_peaks; i ++)
            {
                double[] tmp = ppm_calculator(cen[i].X);

                if (tmp[0] < ppmError) results.Add(tmp);
                else
                {
                    fragment_is_canditate = false; break;
                }
            }

            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate) { chem.Profile.Clear(); chem.Points.Clear(); return false; }

            chem.PPM_Error = results.Average(p => p[0]);
            chem.Resolution = (double)results.Average(p => p[1]);

            return fragment_is_canditate;
        }

        public static double[] ppm_calculator(double centroid)
        {
            // find the closest experimental peak, and return calculated ppm and resolution
            double exp_cen, curr_diff, ppm;

            int closest_idx = 0;
            double min_diff = Math.Abs(peak_points[0][1] + peak_points[0][4] - centroid);

            for (int i = 1; i < peak_points.Count; i++)
            {
                exp_cen = peak_points[i][1] + peak_points[i][4];
                curr_diff = Math.Abs(exp_cen - centroid);

                if (curr_diff < min_diff) { min_diff = curr_diff; closest_idx = i; }
                else
                    break;
            }

            exp_cen = peak_points[closest_idx][1] + peak_points[closest_idx][4];
            ppm = Math.Abs(exp_cen - centroid) * 1e6 / (exp_cen);

            return new double[] { ppm, peak_points[closest_idx][3] };
        }
      
        #endregion

        #region 3.a Recalculate data aligned

        private void recalculate_all_data_aligned()
        {
            // will generate a 2D array, first column is experimental, and a full column foreach fragment
            // it will start from the first fragment, if any

            // method can be called with no fragments, for some fragments, and some new additional fragments
            // when single threaded we could add only the new fragments. In multi thread Fragments have to be resorted every time by mass, so their relative position (idxs) changes on every new addition
            //int start = 1; bool add = false; if (all_data_aligned.Count > 0 && (all_data_aligned[0].Count() < Fragments2.Count + 1)) { start = all_data_aligned[0].Count(); add = true; }
            //fix_experimental_gaps2020();

            List<int> idxs = new List<int>();
            for (int i = 1; i < all_data.Count; i++) { idxs.Add(i); }

            Thread allign = new Thread(() => align_distros(idxs));
            allign.Start();
            recalc = false;
        }

        private List<double[]> align_distros(List<int> distro_fragm_idxs)
        {
            sw1.Reset(); sw1.Start();

            all_data_aligned.Clear();
            List<double[]> aligned_intensities = new List<double[]>();
            List<int> aux_idx = new List<int>();

            progress_display_start(all_data[0].Count, "Preparing data for fit...");

            // generate alligned (in m/z) isotope distributions at the same step as the experimental
            // pickup each point in experimental and find (interpolate) the intensity of each fragment
            int progress = 0;
            Parallel.For(0, all_data[0].Count, (i, state) =>
            {
                // one by one for all points
                List<double> one_aligned_point = new List<double>();

                //// when adding new fragments, we dont need to start from the first. Just copy the already aligned frags.  
                //if (add)
                //    foreach (double o in all_data_aligned[i])
                //        one_aligned_point.Add(o);
                //else
                //    one_aligned_point.Add(all_data[0][i][1]);
                one_aligned_point.Add(all_data[0][i][1]);

                double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo ta experimental ola ta x-->m/z

                for (int j = 0; j < distro_fragm_idxs.Count; j++)
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
                            //aligned_value = interpolate(all_data[distro_idx][k][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], Fragments2[distro_idx - 1].Fix * all_data[distro_idx][k + 1][1], mz_toInterp);
                            aligned_value = interpolate(all_data[distro_idx][k][0], all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], all_data[distro_idx][k + 1][1], mz_toInterp);
                            break;
                        }
                    }
                    one_aligned_point.Add(aligned_value);
                }
                lock (_locker) { aligned_intensities.Add(one_aligned_point.ToArray()); aux_idx.Add(i); }
                try
                {
                    lock (_locker)
                    {
                        Interlocked.Increment(ref progress); if (progress % 5000 == 0 && i > 0) progress_display_update(progress);
                    }                    
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("progress: " + progress.ToString() + "  " + i.ToString() + " X " + all_data[0][i][0].ToString() + " Y " + all_data[0][i][1].ToString()+"  "+ex);
                }
               
            });
            // sort by mz the aligned intensities list (global) beause it is mixed by multi-threading
            int sort_idx = 0;
            all_data_aligned = aligned_intensities.OrderBy(d => aux_idx[sort_idx++]).ToList();
            sw1.Stop(); Debug.WriteLine("All data aligned(M): " + sw1.ElapsedMilliseconds.ToString());

            progress_display_stop();
            Invoke(new Action(() => OnRecalculate_completed()));
            return aligned_intensities;
        }

        private List<double[]> subset_of_aligned_distros(int[] distro_fragm_idxs)
        {
            // will return the requested subset of aligned_intensities for the given fragments, it is called only from the fiting algorithm
            // it is VARIABLE in length for each subset, because it SCANS and discards points where ALL given fragments are zero
            // Improves memory demands and speed in fitting! List is much smaller, it contains only the points where fragments exist.
            // subset_of_aligned_intensities = [m/z point] {exp, frag1, frag2, frag3, ... }

            List<double[]> subset_of_aligned_intensities = new List<double[]>();
            int no_of_selected = distro_fragm_idxs.Count();

            for (int i = 0; i < all_data_aligned.Count; i++)
            {
                List<double> one_aligned_point = new List<double>();
                bool zero_point = true;

                // build the point with exp and all frag, but keep it only if any frag is NON zero
                one_aligned_point.Add(all_data_aligned[i][0]);

                for (int k = 0; k < no_of_selected; k++)
                {
                    one_aligned_point.Add(all_data_aligned[i][distro_fragm_idxs[k]]);
                    if (all_data_aligned[i][distro_fragm_idxs[k]] != 0.0) zero_point = zero_point & false;
                }

                if (!zero_point) subset_of_aligned_intensities.Add(one_aligned_point.ToArray());
            }            
            return subset_of_aligned_intensities;
        }

        private double interpolate(double x1, double y1, double x2, double y2, double x_inter)
        {
            // linear interpolation
            return ((x_inter - x1) * y2 + (x2 - x_inter) * y1) / (x2 - x1);
        }

        private void fix_experimental_gaps2020()
        {
            List<double> all_cen = new List<double>();
            foreach (FragForm fra in Fragments2)
            {
                foreach (PointPlot p in fra.Centroid)
                {
                    if (p.Y>min_intes)
                    {
                        all_cen.Add(p.X);
                    }
                }
            }
            if (all_cen.Count>0)
            {
                all_cen.OrderBy(p => p);
                List<double[]> new_exp = new List<double[]>();
                double step = experimental[1][0] - experimental[0][0];
                int last_int = 0;
                new_exp.Add(new double[] { experimental[0][0], experimental[0][1] });
                for (int i = 1; i < experimental.Count; i++)
                {
                    if (experimental[i][0] - new_exp.Last()[0] > step + 0.0001 && experimental[i][1]<1 && new_exp.Last()[0] < 1)
                    {
                        for (int k = last_int; k < all_cen.Count; k++)
                        {
                            if (all_cen[k] > experimental[i][0] - step - 0.0001) { last_int =k; break; }
                            if (all_cen[k] > new_exp.Last()[0] + step + 0.0001)
                            {                               
                                double step_in =  0.05;
                                while (all_cen[k] > new_exp.Last()[0] + step_in)
                                {
                                    new_exp.Add(new double[] { new_exp.Last()[0]+step_in, 0.0 });
                                }
                                new_exp.Add(new double[] { all_cen[k], 0.0 });                              
                               
                                while (experimental[i][0] - new_exp.Last()[0] > step_in)
                                {
                                    new_exp.Add(new double[] { new_exp.Last()[0] + step_in, 0.0 }); 
                                }                                
                            }
                        }
                    }
                    new_exp.Add(new double[] { experimental[i][0], experimental[i][1] });
                }
                new_exp.OrderBy(p => p[0]);
                current_experimental.Clear();                
                all_data[0] = new_exp;
            }            
        }

        #endregion

        #region fitting

        private void fit_Btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Perform fit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (experimental.Count == 0) { MessageBox.Show("You have to load the experimental data first in order to perform fit!"); return; }                
                // initialize a new background thread for fit 
                Thread fit;

                if ((sender as Button) == fit_Btn) fit = new Thread(() => main_fit(true));
                else fit = new Thread(() => main_fit(false));

                fit.Start();

                saveFit_Btn.Enabled = true;
                fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
           
        }

        private void auto_fit()
        {
            bool last_bunch = false;

            progress_display_start(Fragments2.Count + 1, "Calculating fragment fit...");
            sw1.Reset(); sw1.Start();

            all_fitted_results = new List<List<double[]>>();
            all_fitted_sets = new List<List<int[]>>();

            // auto all fragments
            for (int i = 0; i < Fragments2.Count; i += fit_bunch - fit_cover)
            {
                // this is only for the last run, where the last remaining frags can be less than the bunch
                if (i + fit_bunch > Fragments2.Count)
                {
                    fit_bunch = Fragments2.Count - i;
                    last_bunch = true;
                }

                // select the fragments indexs
                List<int> idx = new List<int>();
                for (int j = 0; j < fit_bunch; j++)
                    idx.Add(j + i + 1);

                // run the fit
                (List<double[]> res, List<int[]> set) = fit_distros_parallel2(idx);
                all_fitted_results.Add(res);
                all_fitted_sets.Add(set);

                progress_display_update(i + 1);
                if (last_bunch) break;
            }
            sw1.Stop(); Debug.WriteLine("Fitting(M): " + sw1.ElapsedMilliseconds.ToString());
            progress_display_stop();

            // 5. display results
            Invoke(new Action(() => OnFittingCalcCompleted()));
        }

        private void main_fit(bool all_fragments)
        {
            bool last_bunch = false;
            int fit_bunch_temp = fit_bunch;
            int total_fragments = 0;
            if (all_fragments) total_fragments = Fragments2.Count;
            else total_fragments = selectedFragments.Count;

            progress_display_start(total_fragments + 1, "Calculating fragment fit...");
            sw1.Reset(); sw1.Start();
            if(all_fitted_results!=null) all_fitted_results.Clear();
            if(all_fitted_sets!=null) all_fitted_sets.Clear();
            all_fitted_results = new List<List<double[]>>();
            all_fitted_sets = new List<List<int[]>>();

            // auto all fragments
            for (int i = 0; i < total_fragments; i += fit_bunch_temp - fit_cover)
            {
                // this is only for the last run, where the last remaining frags can be less than the bunch
                if (i + fit_bunch_temp > total_fragments)
                {
                    fit_bunch_temp = total_fragments - i;
                    last_bunch = true;
                }

                // select the fragments indexs. Total fragments are in order, indexes are consequtive and in order. Selected fragments will have non consequtive indexes [12, 23, 29,...]
                List<int> idx = new List<int>();
                if (all_fragments)
                    for (int j = 0; j < fit_bunch_temp; j++)
                        idx.Add(j + i + 1);
                else
                    for (int j = 0; j < fit_bunch_temp; j++)
                        idx.Add(selectedFragments[j + i]);

                // run the fit
                (List<double[]> res, List<int[]> set) = fit_distros_parallel2(idx);
                all_fitted_results.Add(res);
                all_fitted_sets.Add(set);

                progress_display_update(i + 1);
                if (last_bunch) break;
            }
            sw1.Stop(); Debug.WriteLine("Fitting(M): " + sw1.ElapsedMilliseconds.ToString());
            progress_display_stop();

            // 5. display results
            Invoke(new Action(() => OnFittingCalcCompleted()));
        }

        private (List<double[]>, List<int[]>) fit_distros_parallel2(List<int> selectedFragments)
        {
            List<double[]> res = new List<double[]>();
            List<int[]> set = new List<int[]>();

            // this is all the logic of how many time the fitting should run
            // we want to fit every possible combination to get the best result (minimum SSE)
            // 1. generate the powerSet. It contains only fragment permutations
            set = FastPowerSet(selectedFragments.ToArray()).ToList();
            set.RemoveAt(0);//remove the {0} set
            List<int[]> set_copy = new List<int[]>();

            // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
            //progress_display_start(powerSet.Count + 1, "Calculating fragment fit...");

            //cxalculate experimental surface area in the current fit region
            double experimental_max = all_data_aligned[0].Max();
            double experimental_sum = 0.0;
            int[] exp_boundaries = find_set_boundaries(set.Last().ToArray());
            for (int i = exp_boundaries[0]; i < exp_boundaries[1] + 1; i++) { experimental_sum += experimental[i][1]; }
            
            
            Parallel.For(0, set.Count, (i, state) =>
            {
                // generate a new list containing only the fragments intensities of the subSet, and the experimental
                // intensities are fixed in alligned_intensities for all. Fragments height is regulated by each one's Factor
                List<double[]> aligned_intensities_subSet = subset_of_aligned_distros(set[i].ToArray());

                // get the intensities of the fragments, to pass them to the optimizer as a better starting point
                List<double> UI_intensities = get_UI_intensities(set[i]);
                try
                {
                    // call optimizer for the specific subset of fragments
                    double[] tmp = estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities, experimental_sum);
               
                    lock (_locker)
                    {
                        centroid_LSE(set[i].ToArray(), tmp);
                        di_aligned(set[i].ToArray(), tmp);
                        res.Add(tmp);
                        set_copy.Add(set[i]);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });
            
           
            
            // sort res and powerSet by least SSE
            // res is a list of doubles. res = [frag1_factor, frag2_factor,...., SSE,centroid LSE,%of total area,%of fragment's area]. 
            double[][] tmp1 = res.ToArray();
            //int[][] tmp2 = powerSet.ToArray();
            int[][] tmp2 = set_copy.ToArray();

            ////array is sorted in descending fit coverage !!!
            //IComparer myComparer = new lastElement();
            //Array.Sort(tmp1, tmp2, myComparer);

            res = tmp1.ToList();
            set = tmp2.ToList();
            //remove_lse_1(res,set);
            return (res, set);
        }
        private void remove_lse_1(List<double[]>res, List<int[]>set)
        {
            List<int> rem_fra = new List<int>();
            HashSet<int> rem_solutions = new HashSet<int>();
            for (int f= set.Count()-1; f>-1; f--)
            {
                if (set[f].Count() == 1 && Math.Round(res[f][2], 3) == 1.000)
                {
                    rem_fra.Add(set[f][0]);
                }
            }
            for (int s=0;s< set.Count(); s++)
            {
                for (int f=0;f< rem_fra.Count(); f++)
                {
                    int idx = Array.IndexOf(set[s], rem_fra[f]);
                    if (idx > -1) { rem_solutions.Add(s); break; }
                }                
            }
            int counter = 0;
            foreach (int sol in rem_solutions)
            {
                res.RemoveAt(sol-counter);
                set.RemoveAt(sol-counter);
                counter++;
            }
        }
        /// <summary>
        /// Calculate di score and ei score
        /// </summary>
        private void centroid_LSE(int[] set_array, double[] tmp)
        {
            double lse = 0.0;           
            List<double[]> lse_fragments = new List<double[]>();
            
            for (int ss=0;ss< set_array.Length; ss++)
            {
                int frag_index = set_array[ss]-1;
                double frag_factor = tmp[ss];
                int absent_isotope = 0;
                double absent_factor =0.0;
                List<PointPlot> sorted_cen = new List<PointPlot>();
                double max_cen = Fragments2[frag_index].Centroid[0].Y;
                sorted_cen = Fragments2[frag_index].Centroid.OrderBy(p => p.X).ToList();
                double summ = 0.0;                
                foreach (PointPlot p in sorted_cen)
                {
                    summ += p.Y;
                }
                lse_fragments.Add(new double[3]);
                double iso_lse_sum=0.0;
                int start_idx = 1;
                double[] tmp_error = new double[sorted_cen.Count()];
                for (int c = 0; c < sorted_cen.Count(); c++)
                {
                    double exp_cen, curr_diff, ppm,exp_intensity;
                    int closest_idx = 0;
                    double min_diff = Math.Abs(peak_points[0][1] + peak_points[0][4] - sorted_cen[c].X);
                    for (int i = start_idx; i < peak_points.Count; i++)
                    {
                        exp_cen = peak_points[i][1] + peak_points[i][4];
                        curr_diff = Math.Abs(exp_cen - sorted_cen[c].X);

                        if (curr_diff < min_diff) { min_diff = curr_diff; closest_idx = i; }
                        else { start_idx = i; break; }
                    }
                    exp_cen = peak_points[closest_idx][1] + peak_points[closest_idx][4];                   
                    ppm = Math.Abs(exp_cen - sorted_cen[c].X) * 1e6 / (exp_cen);
                    exp_intensity = peak_points[closest_idx][5];
                    if (ppm < ppmDi)
                    {
                        double ee1 = Math.Abs(exp_intensity - sorted_cen[c].Y * frag_factor) /Math.Max(sorted_cen[c].Y * frag_factor, exp_intensity);
                        //if (ee > 1) ee = Math.Abs(exp_intensity - sorted_cen[c].Y * frag_factor) / (exp_intensity);
                        double ee = ee1 * sorted_cen[c].Y;
                        iso_lse_sum += ee; tmp_error[c]= ee1;
                        //double ee = exp_intensity / (sorted_cen[c].Y * frag_factor);
                        //double eee = ee * max_cen / sorted_cen[c].Y;
                        //if (eee > 1) { eee = 1 / eee; }
                        //iso_lse_sum +=eee;                        
                    }
                    else
                    {
                        tmp_error[c] = 1.0 ;
                        iso_lse_sum += tmp_error[c] * sorted_cen[c].Y; absent_factor += tmp_error[c] * sorted_cen[c].Y;   absent_isotope++;     
                    }
                }               
                lse_fragments.Last()[0] = 100 * absent_isotope / sorted_cen.Count();
                lse_fragments.Last()[1] = iso_lse_sum / summ;
                lse_fragments.Last()[2] = (iso_lse_sum-absent_isotope) / (sorted_cen.Count()- absent_isotope);
                lse += lse_fragments.Last()[1];
                double sd = 0.0;
                for(int d=0; d< tmp_error.Length; d++)
                {
                    sd += sorted_cen[d].Y*Math.Pow((tmp_error [d]- lse_fragments.Last()[1]),2);
                }
                tmp[ss+ 2*set_array.Length] = 100.00* Math.Sqrt(sd /(summ));
                tmp[ss +  set_array.Length] = 100.00 *lse_fragments.Last()[1];
                tmp[ss + 3*set_array.Length] = 100.00 * absent_factor /summ;
            }
            lse = 100.00 * lse / set_array.Length;            
            tmp[6 * set_array.Length+2] = lse;
            return;
        }
        /// <summary>
        /// Calculate di' or dinew score
        /// </summary>
        private void di_aligned(int[] set_array, double[] tmp)
        {                      
            List<double[]> lse_fragments = new List<double[]>();
            double dinew_average = 0.0; double ei_average =0.0;
            /// <summary>
            /// for each fragment [exp m/z, exp intensity, centroid*factor,weight,fragment index in tmp,multiplicity,di]
            /// </summary>
            List<double[]> frag_info = new List<double[]>();
            List<double[]> frag_info_sorted = new List<double[]>();
            for (int ss = 0; ss < set_array.Length; ss++)
            {
                int frag_index = set_array[ss] - 1;
                double frag_factor = tmp[ss];               
                double absent_factor = 0.0;
                List<PointPlot> sorted_cen = new List<PointPlot>();                
                sorted_cen = Fragments2[frag_index].Centroid.OrderBy(p => p.X).ToList();
                double summ = 0.0;
                foreach (PointPlot p in sorted_cen){summ += p.Y;}                
                int start_idx = 1;
                double[] tmp_error = new double[sorted_cen.Count()];
                for (int c = 0; c < sorted_cen.Count(); c++)
                {                   
                    double exp_cen, curr_diff, ppm, exp_intensity;
                    int closest_idx = 0;
                    double min_diff = Math.Abs(peak_points[0][1] + peak_points[0][4] - sorted_cen[c].X);
                    for (int i = start_idx; i < peak_points.Count; i++)
                    {
                        exp_cen = peak_points[i][1] + peak_points[i][4];
                        curr_diff = Math.Abs(exp_cen - sorted_cen[c].X);

                        if (curr_diff < min_diff) { min_diff = curr_diff; closest_idx = i; }
                        else { start_idx = i; break; }
                    }
                    exp_cen = peak_points[closest_idx][1] + peak_points[closest_idx][4];
                    ppm = Math.Abs(exp_cen - sorted_cen[c].X) * 1e6 / (exp_cen);
                    exp_intensity = peak_points[closest_idx][5];
                    if (ppm > ppmDi)
                    {
                        exp_intensity = 0;exp_cen = 0; absent_factor += sorted_cen[c].Y / summ;
                    }                   
                    frag_info.Add(new double[]{ exp_cen, exp_intensity, sorted_cen[c].Y * frag_factor, sorted_cen[c].Y / summ, ss ,1, sorted_cen[c].Y / summ }) ;
                } 
                tmp[ss + 3 * set_array.Length] = 100.00 * absent_factor;
                ei_average += absent_factor;
            }
            frag_info_sorted = frag_info.OrderBy(p => p[0]).ToList(); //sorted by m/z
            for(int a = 0; a < frag_info_sorted.Count; a++)
            {                
                if (frag_info_sorted[a][0]!=0)
                {
                    if (a == frag_info_sorted.Count - 1)
                    {
                        frag_info_sorted[a][6] = Math.Abs(frag_info_sorted[a][1] - frag_info_sorted[a][2]) * frag_info_sorted[a][3] / Math.Max(frag_info_sorted[a][1], frag_info_sorted[a][2]) / frag_info_sorted[a][5];
                        break;
                    }
                    for (int b = a+1; b < frag_info_sorted.Count; b++)
                    {
                        if (a!=b)
                        {
                            if (frag_info_sorted[a][0] == frag_info_sorted[b][0])
                            {
                                frag_info_sorted[a][5]++; frag_info_sorted[b][5]++;
                            }
                            else if(frag_info_sorted[a][0] < frag_info_sorted[b][0])
                            {
                                frag_info_sorted[a][6]=Math.Abs(frag_info_sorted[a][1] - frag_info_sorted[a][2])* frag_info_sorted[a][3] / Math.Max(frag_info_sorted[a][1], frag_info_sorted[a][2])/ frag_info_sorted[a][5];
                                break;
                            }                            
                        }                        
                    }
                }               
            }            
            frag_info= frag_info_sorted.OrderBy(p => p[4]).ToList(); //sorted by fragment index in tmp-->ss 
            //di' aka dinew calculation and dinew_average calculation
            for (int a = 0; a < frag_info.Count; a++)
            {
                dinew_average += frag_info[a][6];
                tmp[(int)frag_info[a][4] + 4*set_array.Length] += frag_info[a][6];                
            }
            dinew_average =dinew_average*100/ set_array.Length;
            ei_average = ei_average * 100 / set_array.Length;
            tmp[6 * set_array.Length]= dinew_average;
            tmp[6 * set_array.Length+1] = ei_average;

            //sdi' calcalculation
            for (int a = 0; a < frag_info.Count; a++)
            {
                tmp[(int)frag_info[a][4] + 5* set_array.Length] += frag_info[a][3] * Math.Pow((Math.Abs(frag_info[a][1] - frag_info[a][2])/ Math.Max(frag_info[a][1], frag_info[a][2]) / frag_info[a][5])- (tmp[(int)frag_info[a][4] + 4 * set_array.Length]/*/ frag_info[a][3]*/), 2);
            }
            for (int ss = 0; ss < set_array.Length; ss++)
            {
                tmp[ss + 5 * set_array.Length] = 100.00 * Math.Sqrt(tmp[ss + 5 * set_array.Length]);
                tmp[ss + 4 * set_array.Length] = 100.00 * tmp[ss + 4 * set_array.Length];
            }
            
            return;
        }
        /// <summary>
        /// Find fit groups' boundaries 
        /// </summary>
        private int[] find_set_boundaries(int[] set)
        {
            int[] set_index = new int[2];
            int start = all_data_aligned.Count()-1;
            int end = all_data_aligned.Count() - 1;
            for (int i = 0; i <start; i++)
            {               
                for (int k = 0; k < set.Count(); k++)
                {
                    if (all_data_aligned[i][set[k]] != 0.0) { start = i; break; }
                }               
            }
            for (int i = start; i < all_data_aligned.Count; i++)
            {               
                bool zero_point = true;
                for (int k = 0; k < set.Count(); k++)
                {                    
                    if (all_data_aligned[i][set[k]] != 0.0) zero_point = zero_point & false;
                }
                if (!zero_point)
                {
                    end = i;
                }
            }
            set_index[0]=start;set_index[1]=end;
            return set_index;
        }
        private double calc_surface_area(int[] boundaries)
        {
            double temp = 0;
            for (int i = boundaries[0]; i < boundaries[1]+1; i++)
            {
                if (i != boundaries[1])
                {
                    double mulA = experimental[i][0] * experimental[i + 1][1];
                    double mulB = experimental[i + 1][0] * experimental[i][1];
                    temp = temp + (mulA - mulB);
                }
                else
                {
                    double mulA = experimental[i][0] * experimental[0][1];
                    double mulB = experimental[0][0] * experimental[i][1];
                    temp = temp + (mulA - mulB);
                }
            }
            temp *= 0.5f;
            return Math.Abs(temp);
        }
        private double[] estimate_fragment_height_multiFactor(List<double[]> aligned_intensities_subSet, List<double> UI_intensities,double experimental_sum)
        {
            // 1. initialize needed params
            // in coefficients[0] refers to 1st frag, and in aligned_intensities[0] refers to experimental
            // UI_intensities is initial values to make a starting point
            int distros_num = aligned_intensities_subSet[0].Length - 1;//osa kai ta fragments pou einai sto subset

            double[] coeficients = UI_intensities.ToArray();
            double[] bndl = new double[distros_num];
            double[] bndh = new double[distros_num];
            for (int i = 0; i < distros_num; i++) { bndl[i] = coeficients[i] * 1e-5; bndh[i] = coeficients[i] * 1e2; }

            double epsx = 0.000001;
            int maxits = 10000;
            alglib.minlmstate state;
            alglib.minlmreport rep;

            alglib.minlmcreatev(distros_num, coeficients, 0.001, out state);
            alglib.minlmsetbc(state, bndl, bndh);                                            // boundary conditions
            alglib.minlmsetcond(state, epsx, maxits);
            alglib.minlmoptimize(state, sse_multiFactor, null, aligned_intensities_subSet);
            alglib.minlmresults(state, out coeficients, out rep);

            // 2. save result
            // save all the coefficients and last cell is the minimized value of SSE. result = [frag1_int, frag2_int,....,di, SSE,Ai,A]
            double[] result = new double[6*distros_num +6];
            for (int i = 0; i < distros_num; i++) { result[i] = coeficients[i]; result[i + 4*distros_num] = 0; result[i +5* distros_num] = 0; } //initialize di error and sd
            result[6*distros_num+3] = state.fi[0];
            (result[6*distros_num+4] , result[6*distros_num + 5]) = per_cent_fit_coverage(aligned_intensities_subSet, coeficients,experimental_sum);

            //einai kati pou dokimaza mh dwseis shmasia, apla eipa na to krathsw mpas kai xreiastei, an thes diegrapse to endelws kai auto kai tis synarthseis
            //result[distros_num + 2] = KolmogorovSmirnovTest(aligned_intensities_subSet, coefficients);
            //result[distros_num + 3] = (result[distros_num])+ result[distros_num + 2] +(10/result[distros_num + 1]);

            return result;
        }

        #region unused code, extra test attempt--> not useful, delete it if you like
        private double KolmogorovSmirnovTest(List<double[]>aligned_subData,double[]sub_coeficients)
        {
            int cand_frag = sub_coeficients.Length;
            double[] error = new double[cand_frag];
            for (int j = 1; j < aligned_subData[0].Length; j++)
            {
                List<double[]> dissimilarity = new List<double[]>();
                double max = 0.0;double min = aligned_subData[1][0];
                for (int i = 0; i < aligned_subData.Count; i++)
                {
                    if (aligned_subData[i][j] * sub_coeficients[j - 1] > 1)        // envelopes have a lot of garbage upFront and in tail ( < 1e-2)
                    {
                        if (aligned_subData[i][j] * sub_coeficients[j - 1]> max) max= aligned_subData[i][j] * sub_coeficients[j - 1];
                        if (aligned_subData[i][j] * sub_coeficients[j - 1]< min) min=aligned_subData[i][j] * sub_coeficients[j - 1];
                        if (aligned_subData[i][0]> max) max= aligned_subData[i][0];
                        if (aligned_subData[i][0]< min) min= aligned_subData[i][0];
                        dissimilarity.Add(new double[2] { aligned_subData[i][0], aligned_subData[i][j] * sub_coeficients[j - 1] });
                    }
                }
                error[j-1]=GetScalingError(dissimilarity, max, min);
            }
            return error.Sum() / cand_frag;
        }
        private double GetScalingError(List<double[]> dis,double dis_max,double dis_min)
        {
            double min =0.1;
            double max =1;
            double m = (max - min) / (dis_max - dis_min);
            double c = min - dis_min * m;
            var newarr = new double[dis.Count];
            int k = 0;
            double frag_sub = 0.0;
            double exp_sub = 0.0;
            foreach (double[] ss in dis)
            {
                ss[0] = m * ss[0] + c; ss[1] = m * ss[1] + c;
                frag_sub += ss[1];
                exp_sub += ss[0];
                newarr[k] = Math.Abs(exp_sub- frag_sub);
                k++;
            }
            return newarr.Max();
        }
        #endregion

        private (double,double) per_cent_fit_coverage(List<double[]> aligned_intensities_subSet, double[] coeficients,double exp_sum)
        {
            double exp_frag_sum = 0.0, frag_sum = 0.0;
            
            for (int i = 0; i < aligned_intensities_subSet.Count; i++)
            {
                double tmp = 0.0;
                for (int j = 1; j < aligned_intensities_subSet[0].Length; j++)
                {
                    tmp += aligned_intensities_subSet[i][j] * coeficients[j-1];
                }

                if (tmp > 1)        // envelopes have a lot of garbage upFront and in tail ( < 1e-2)
                {
                    frag_sum += tmp;
                    exp_frag_sum += aligned_intensities_subSet[i][0];
                }
            }
            double res = exp_sum / frag_sum ;
            double res_frag= exp_frag_sum / frag_sum ;
            if (res >= 1)
            {
                res = (frag_sum / exp_sum);
            }
            if (res_frag >= 1)
            {
                res_frag = (frag_sum / exp_frag_sum);
            }

            res =( 1 - res)*100; res_frag =(1-res_frag)*100;
            return (res_frag,res);
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

                // Pearson's chi-squared test
                //double factor = 1.0;
                //if (exp_and_distros[i][0] != 0.0) factor = exp_and_distros[i][0];
                //else if (distros_sum != 0.0) factor = distros_sum;
                //func[0] += (Math.Pow((exp_and_distros[i][0] - distros_sum), 2) / factor);
            }
        }
        //**
        private void generate_fit_results()
        {
            sw1.Reset(); sw1.Start();
            // clear panel
            foreach (Control ctrl in bigPanel.Controls) { bigPanel.Controls.Remove(ctrl); ctrl.Dispose(); }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            // init tree view
            fit_tree = new MyTreeView() { CheckBoxes = true, Location = new Point(3, 3), Name = "fit_tree", Size = new Size(bigPanel.Size.Width - 10, bigPanel.Size.Height - 10), ShowNodeToolTips = false, HideSelection = false, TreeViewNodeSorter = new NodeSorter() };
            bigPanel.Controls.Add(fit_tree);
            fit_tree.AfterCheck += (s, e) => { fit_node_checkChanged(e.Node); };
            //fit_tree.ContextMenu = new ContextMenu(new MenuItem[1] { new MenuItem("Copy", (s, e) => { copy_fitTree_toClipBoard(); }) });
            fit_tree.BeforeCheck += (s, e) => { node_beforeCheck(s, e); };
            fit_tree.BeforeSelect += (s, e) => { node_beforeCheck(s, e); };
            fit_tree.AfterSelect += (s, e) => { if (string.IsNullOrEmpty(e.Node.Name)) { toolTip_fit.Hide(fit_tree); fit_set_graph_zoomed(e.Node); } else { select_check(e.Node); } };
            ContextMenu ctxMn_fit_grp = new ContextMenu(new MenuItem[2] { new MenuItem("Sort & Filter node", (s, e) => { fitnode_Re_Sort(fit_tree.SelectedNode); }), new MenuItem("Refresh node", (s, e) => {/*uncheckall_Frag();*/refresh_fitnode_sorting(fit_tree.SelectedNode); }) });
            ContextMenu ctxMn_fit_grp_solution = new ContextMenu(new MenuItem[3] { new MenuItem("Error", (s, e) => { show_error(_currentNode); }), new MenuItem("Copy Solution's Scores", (s, e) => { copy_solution_scorestoClipBoard(_currentNode); }), new MenuItem("Copy Solution Fragments' Scores", (s, e) => { copy_solution_fragments_toClipBoard(_currentNode); }) });
            fit_tree.NodeMouseClick += (s, e) =>
            {
                if(fit_tree != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (string.IsNullOrEmpty(e.Node.Name)) { fit_tree.SelectedNode = e.Node; fit_tree.ContextMenu = ctxMn_fit_grp; }
                        else { _currentNode = e.Node; fit_tree.ContextMenu = ctxMn_fit_grp_solution; }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(e.Node.Name))
                        { fit_set_graph_zoomed(e.Node); }
                    }
                }
               
            };           
            

            //fit_tree.ContextMenu = new ContextMenu(new MenuItem[3] { new MenuItem("Sort & Filter node", (s, e) => { fitnode_Re_Sort(fit_tree.SelectedNode); }), new MenuItem("Refresh node", (s, e) => {/*uncheckall_Frag();*/refresh_fitnode_sorting(fit_tree.SelectedNode); }), new MenuItem("error", (s, e) => { show_error(fit_tree.SelectedNode); }) });
            fit_tree.NodeMouseHover += (s, e) => {toolTip_fit.Hide(fit_tree); fit_tree_tooltip(e.Node); };
            fit_tree.MouseLeave += (s, e) =>{toolTip_fit.Hide(fit_tree);};
            fit_tree.MouseHover += (s, e) => { toolTip_fit.Hide(fit_tree); };

            // interpret fitted results
            fit_tree.BeginUpdate();
            for (int i = 0; i < all_fitted_results.Count; i++)
            {
                // get first and last mz of this fit, from the array that contains all the indexes (the longest)
                int[] longest = all_fitted_sets[i].OrderBy(x => x.Length).Last();
                fit_tree.Nodes.Add(Fragments2[longest.First() - 1].Mz + " - " + Fragments2[longest.Last() - 1].Mz);

                //double[] tree_index = new double[all_fitted_results[i].Count];
                //double[] tree_sse = new double[all_fitted_results[i].Count];
                            
                for (int j = 0; j < all_fitted_results[i].Count; j++)
                {
                    if (all_fitted_results[i][j][all_fitted_results[i][j].Length - 2] <tab_thres[i][0] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 1] < tab_thres[i][1] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 4]< tab_thres[i][2] && all_fitted_results[i][j][all_fitted_results[i][j].Length -5] < tab_thres[i][3] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 6] < tab_thres[i][4])
                    {
                        bool print = true;
                        for (int k = 0; k < all_fitted_sets[i][j].Length; k++)
                        {
                            if (all_fitted_results[i][j][k + all_fitted_sets[i][j].Length]> tab_thres[i][2] || all_fitted_results[i][j][k + 3 * all_fitted_sets[i][j].Length] > tab_thres[i][3] || all_fitted_results[i][j][k + 4 * all_fitted_sets[i][j].Length] > tab_thres[i][4] || Fragments2[all_fitted_sets[i][j][k] - 1].Max_intensity * all_fitted_sets[i][j][k]<= min_intes+0.1) { print = false; }
                        }
                        if (print)
                        {
                            StringBuilder sb = new StringBuilder();
                           
                            string tmp = "";
                            tmp += "SSE:" + all_fitted_results[i][j][all_fitted_results[i][j].Length - 3].ToString("0.###e0" + " ");
                            tmp += "di:" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 4], 3).ToString() + "% ";

                            //sb.AppendLine("A:" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 1], 2).ToString() + "%" + "    " + "Ai:" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 2], 2).ToString() + "%" + "    " + "ei:" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 5], 2).ToString() + "%" + "    " + "di':" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 6], 2).ToString() + "%");
                            //sb.AppendLine();                           
                            //for (int k = 0; k < all_fitted_sets[i][j].Length; k++)
                            //{
                            //    string pp1,pp2,pp3,pp4,pp5,pp6,pp7;                                
                            //    pp1 = Fragments2[all_fitted_sets[i][j][k] - 1].Name.PadRight(30);//fragment name
                            //    pp2 = "(m/z)"+ Fragments2[all_fitted_sets[i][j][k] - 1].Mz.PadRight(20);//fragments m/z
                            //    pp3 = "(di)"+(Math.Round(all_fitted_results[i][j][k + all_fitted_sets[i][j].Length], 3).ToString() + "%").PadRight(20);//fragment's di
                            //    pp4 = "(sd)"+("±" + Math.Round(all_fitted_results[i][j][k + all_fitted_sets[i][j].Length * 2], 2).ToString()).PadRight(20);//fragment's sd
                            //    pp5 = "(ei)"+ (Math.Round(all_fitted_results[i][j][k + all_fitted_sets[i][j].Length * 3], 2).ToString() + "%").PadRight(20);//fragment's ei
                            //    pp6 = "(di')"+(Math.Round(all_fitted_results[i][j][k + all_fitted_sets[i][j].Length*4], 3).ToString() + "%").PadRight(20);//fragment's di'
                            //    pp7 = "(sd')"+Math.Round(all_fitted_results[i][j][k + all_fitted_sets[i][j].Length * 5], 3).ToString().PadRight(20);//fragment's sd'
                            //    sb.AppendLine(pp1 + pp2 + pp3 + pp4 +pp5+pp6+pp7);
                            //}
                            TreeNode tr = new TreeNode
                            {
                                Text = tmp,
                                Name = i.ToString() + " " + j.ToString()
                                //ToolTipText = sb.ToString()
                            };                            
                            fit_tree.Nodes[i].Nodes.Add(tr);
                        }                       
                    }                   
                }
               //find_min_SSE(fit_tree.Nodes[i], tree_index, tree_sse);
            }          
            fit_tree.EndUpdate();
            remove_child_nodes();            
            sw1.Stop(); Debug.WriteLine("Fit treeView populate: " + sw1.ElapsedMilliseconds.ToString());
            uncheckall_Frag();
        }
        /// <summary>
        /// Custom tooltip for each fit group solution node
        /// </summary>
        private void fit_tree_tooltip(TreeNode fitnode)
        {
            string idx_str = fitnode.Name;
            if (string.IsNullOrEmpty(idx_str)) return;
            string[] idx_str_arr = idx_str.Split(' ');
            int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
            int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);  // identifies a fit combination in this set

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 1], 2).ToString() + "%" + "    " + "Ai:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 2], 2).ToString() + "%" + "    " + "ei:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 5], 2).ToString() + "%" + "    " + "di':" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 6], 2).ToString() + "%");
            sb.AppendLine();
            for (int k = 0; k < all_fitted_sets[set_idx][set_pos_idx].Length; k++)
            {
                string pp1, pp2, pp3, pp4, pp5, pp6, pp7;
                pp1 = Fragments2[all_fitted_sets[set_idx][set_pos_idx][k] - 1].Name.PadRight(30);//fragment name
                pp2 = "(m/z)" + Fragments2[all_fitted_sets[set_idx][set_pos_idx][k] - 1].Mz.PadRight(15);//fragments m/z
                pp3 = "(di)" + (Math.Round(all_fitted_results[set_idx][set_pos_idx][k + all_fitted_sets[set_idx][set_pos_idx].Length], 3).ToString() + "%").PadRight(15);//fragment's di
                pp4 = "(sd)" + ("±" + Math.Round(all_fitted_results[set_idx][set_pos_idx][k + all_fitted_sets[set_idx][set_pos_idx].Length * 2], 2).ToString()).PadRight(13);//fragment's sd
                pp5 = "(ei)" + (Math.Round(all_fitted_results[set_idx][set_pos_idx][k + all_fitted_sets[set_idx][set_pos_idx].Length * 3], 2).ToString() + "%").PadRight(13);//fragment's ei
                pp6 = "(di')" + (Math.Round(all_fitted_results[set_idx][set_pos_idx][k + all_fitted_sets[set_idx][set_pos_idx].Length * 4], 3).ToString() + "%").PadRight(15);//fragment's di'
                pp7 = "(sd')" + Math.Round(all_fitted_results[set_idx][set_pos_idx][k + all_fitted_sets[set_idx][set_pos_idx].Length * 5], 3).ToString();//fragment's sd'
                sb.AppendLine(pp1 + pp2 + pp3 + pp4 + pp5 + pp6 + pp7);
            }
            tool_text = sb.ToString();   
           
            // Node location in treeView coordinates.
            Point loc = fitnode.Bounds.Location;

            // Node location in form client coordinates.
            loc.Offset(fit_tree.Location);
           
            if (show_Btn.Visible == true)
            {
                // Make balloon point to upper left corner of the node.
                loc.Offset(0, fitnode.Bounds.Height+10);
            }
            else
            {
                // Make balloon point to upper right corner of the node.
                loc.Offset(fitnode.Bounds.Width, 0);
            }

            toolTip_fit.Show(tool_text, fit_tree, loc);
           
        }
        /// <summary>
        /// removes the nodes of each fit group that are not within the user results bound
        /// </summary>
        private void remove_child_nodes()
        {
            if (fit_tree != null)
            {
                foreach (TreeNode node in fit_tree.Nodes)
                {
                    if (node.Nodes.Count <= visible_results) continue;
                    else
                    {
                        while (visible_results < node.Nodes.Count)
                        {
                            node.Nodes[visible_results].Remove();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// shows the scores(A,Ai,di,ei,di') of  each fragment in the right clicked solution node in a fit group solution
        /// </summary>
        private void show_error(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            StringBuilder sb = new StringBuilder();
            double lse = 0.0;           
            List<double[]> lse_fragments = new List<double[]>();
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group. First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }

            else
            {
                string idx_str = node.Name;
                string[] idx_str_arr = idx_str.Split(' ');
                int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
                int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);  // identifies a fit combination in this set
                List<TreeNode> all_nodes = get_all_nodes(frag_tree);
                for (int f = 0; f < all_fitted_sets[set_idx][set_pos_idx].Length; f++)
                {
                    int frag_index = all_fitted_sets[set_idx][set_pos_idx][f] - 1;
                    double frag_factor = all_fitted_results[set_idx][set_pos_idx][f];
                    int absent_isotope = 0;
                    double absent_factor = 0.0;
                    List<PointPlot> sorted_cen = new List<PointPlot>();
                    double max_cen = Fragments2[frag_index].Centroid[0].Y;
                    sorted_cen = Fragments2[frag_index].Centroid.OrderBy(p => p.X).ToList();
                    double summ = 0.0;
                    foreach (PointPlot p in sorted_cen)
                    {
                        summ += p.Y;
                    }
                    lse_fragments.Add(new double[3]);
                    double iso_lse_sum = 0.0;
                    int start_idx = 1;
                    double[] tmp_error = new double[sorted_cen.Count()];
                    sb.AppendLine("Fragment: " + Fragments2[frag_index].Name.ToString());
                    for (int c = 0; c < sorted_cen.Count(); c++)
                    {
                        double exp_cen, curr_diff, ppm, exp_intensity;
                        int closest_idx = 0;
                        double min_diff = Math.Abs(peak_points[0][1] + peak_points[0][4] - sorted_cen[c].X);
                        for (int i = start_idx; i < peak_points.Count; i++)
                        {
                            exp_cen = peak_points[i][1] + peak_points[i][4];
                            curr_diff = Math.Abs(exp_cen - sorted_cen[c].X);

                            if (curr_diff < min_diff) { min_diff = curr_diff; closest_idx = i; }
                            else { start_idx = i; break; }
                        }
                        exp_cen = peak_points[closest_idx][1] + peak_points[closest_idx][4];
                        ppm = Math.Abs(exp_cen - sorted_cen[c].X) * 1e6 / (exp_cen);
                        exp_intensity = peak_points[closest_idx][5];
                        if (ppm < ppmDi)
                        {
                            double ee1 = Math.Abs(exp_intensity - sorted_cen[c].Y * frag_factor) / Math.Max(sorted_cen[c].Y * frag_factor, exp_intensity);
                            //if (ee > 1) ee = Math.Abs(exp_intensity - sorted_cen[c].Y * frag_factor) / (exp_intensity);
                            double ee = ee1 * sorted_cen[c].Y / summ;
                            iso_lse_sum += ee; tmp_error[c] = ee1;
                            //double ee = exp_intensity / (sorted_cen[c].Y * frag_factor);
                            //double eee = ee * max_cen / sorted_cen[c].Y;
                            //if (eee > 1) { eee = 1 / eee; }
                            //iso_lse_sum +=eee;       
                            sb.AppendLine("Centroid " + (c + 1).ToString() + " error:" + Math.Round(ee1, 10).ToString() + " , adjusted to:" + Math.Round(ee, 10).ToString());
                        }
                        else
                        {
                            tmp_error[c] = 1.0;               
                            iso_lse_sum += tmp_error[c] * sorted_cen[c].Y / summ; absent_factor += tmp_error[c] * sorted_cen[c].Y/summ; absent_isotope++;
                            sb.AppendLine("Centroid " + (c + 1).ToString() + " error: 1.0" + " , adjusted to:" + Math.Round(tmp_error[c] * sorted_cen[c].Y / summ, 10).ToString() + " (absent isotope)");
                        }
                    }

                    lse_fragments.Last()[0] = 100 * absent_isotope / sorted_cen.Count();
                    lse_fragments.Last()[1] = iso_lse_sum;
                    lse_fragments.Last()[2] = (iso_lse_sum - absent_isotope) / (sorted_cen.Count() - absent_isotope);
                    lse += lse_fragments.Last()[1];
                    double sd = 0.0;
                    for (int d = 0; d < tmp_error.Length; d++)
                    {
                        sd += sorted_cen[d].Y * Math.Pow((tmp_error[d] - lse_fragments.Last()[1]), 2);
                    }
                    sd = Math.Sqrt(sd / (summ));
                    sb.AppendLine(Math.Round(lse_fragments.Last()[0], 2).ToString() + "% of the centroids were absent |with ei= "+ Math.Round(absent_factor, 4).ToString()  + " | the average error is " + Math.Round(lse_fragments.Last()[1], 5).ToString()+ " | sd: " + Math.Round(sd, 4).ToString());
                    sb.AppendLine();
                }
                MessageBox.Show(sb.ToString());
            }
           
        }
        private void node_beforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if ((e.Action== TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard) && !string.IsNullOrEmpty(e.Node.Name) && !e.Node.Checked)
            {
                // for all the nodes in the tree which are not the freshly checked one uncheck them
                block_fit_refresh = true;
                foreach (TreeNode cur_node in e.Node.Parent.Nodes)
                {
                    if (cur_node.Checked) cur_node.Checked = false;
                }
                block_fit_refresh = false;
                refresh_iso_plot();
            }
        }
        private void find_min_SSE(TreeNode node, double[] tree_index, double[] tree_sse)
        {
            Array.Sort( tree_sse, tree_index);
            int best_count =(int)(0.3* tree_index.Length);
            while (best_count<tree_sse.Length - 2) { if (tree_sse[best_count] == tree_sse[best_count + 1]) { best_count++; } else { break; } }
            for (int n=0;n<best_count; n++)
            {
                node.Nodes[(int)tree_index[n]].ForeColor = Color.SteelBlue;
            }            
        }
        private void copy_solution_fragments_toClipBoard(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group. First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            DialogResult dialogResult = MessageBox.Show("Do you want to add headers to the copied data ?", "Headers", MessageBoxButtons.YesNo);
            bool header = true;
            if (dialogResult == DialogResult.No) { header = false; }
            StringBuilder sb = new StringBuilder();
            string idx_str = node.Name;
            string[] idx_str_arr = idx_str.Split(' ');
            int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
            int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);  // identifies a fit combination in this set
            List<TreeNode> all_nodes = get_all_nodes(frag_tree);
            if (header) sb.AppendLine("Fragments" + "\t" + "m/z" + "\t" + "di" + "\t" + "ei" + "\t" + "di'" + "\t" + "ppm" + "\t" + "Intensity");
            for (int i = 0; i < all_fitted_sets[set_idx][set_pos_idx].Length; i++)
            {
                int curr_idx = all_fitted_sets[set_idx][set_pos_idx][i] - 1;               
                double factor = all_fitted_results[set_idx][set_pos_idx][i];
                string intensity = (factor * Fragments2[curr_idx].Max_intensity).ToString("#######");
                sb.AppendLine(Fragments2[curr_idx].Name + "\t" + Fragments2[curr_idx].Mz + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length], 3).ToString() + "%" + "\t"+ Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length * 3], 2).ToString() + "%" + "\t"+ Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length * 4], 3).ToString() + "%" + "\t"+ Fragments2[curr_idx].PPM_Error.ToString()+ "\t" +intensity);               
            }
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());
        }
        private void copy_solution_scorestoClipBoard(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group. First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            DialogResult dialogResult = MessageBox.Show("Do you want to add headers to the copied data ?", "Headers", MessageBoxButtons.YesNo);
            bool header = true;
            if (dialogResult==DialogResult.No) { header = false; }            
            StringBuilder sb = new StringBuilder();
            string idx_str = node.Name;
            string[] idx_str_arr = idx_str.Split(' ');
            int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
            int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);  // identifies a fit combination in this set
            List<TreeNode> all_nodes = get_all_nodes(frag_tree);
            string Name = "";
            for (int i = 0; i < all_fitted_sets[set_idx][set_pos_idx].Length; i++)
            {
                int curr_idx = all_fitted_sets[set_idx][set_pos_idx][i] - 1;
                Name+=Fragments2[curr_idx].Name +"   ";      
            }
            if(header)sb.AppendLine("Fragments" + "\t" + "A" + "\t" + "Ai"  + "\t" + "di" + "\t" + "ei" +  "\t" + "di'" +  "\t" + "SSE");
            sb.AppendLine(Name + "\t"+Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 1], 2).ToString() + "%" + "\t"+  Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 2], 2).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 4], 3).ToString() + "% " + "\t" +  Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 5], 2).ToString() + "%" + "\t" +  Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 6], 3).ToString() + "%" + "\t"+  all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 3].ToString("0.###e0" + " "));
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());
        }
        private void copy_fitTree_toClipBoard()
        {
            StringBuilder sb = new StringBuilder();

            List<TreeNode> fit_nodes = get_all_nodes(fit_tree);

            //foreach (TreeNode fit_node in fit_nodes)
            //{
            //    int fit_idx = Convert.ToInt32(fit_node.Name);

            //    all_fitted_results;

            //    for (int j = 0; j < all_fitted_sets[fit_idx].Count; j++)
            //    {
            //        for (int k = 0; k < )
            //        sb.AppendLine();
            //    }
            //}
            //foreach (TreeNode baseNode in tree.Nodes)
            //{
            //    foreach (TreeNode subNode in baseNode.Nodes)
            //    {
            //        int i = Convert.ToInt32(subNode.Name);
            //        if (Fragments2[i].Name.Contains("intern"))
            //            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].IndexTo + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].FinalFormula +
            //                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
            //        else
            //            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].FinalFormula +
            //                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
            //    }
            //}



            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());

        }
        private void fit_node_checkChanged(TreeNode fitnode)
        {
            // will search in fragments tree to find and enable the corresponding fragments
            // Performance: avoid unecessary multiple replots, if selected fit has 2 or more fragments
            block_plot_refresh = true;
            string idx_str = fitnode.Name;
            bool is_checked = fitnode.Checked;
            if (string.IsNullOrEmpty(idx_str))
            {
                if (is_checked) { fitnode.ForeColor = Color.DarkRed; }
                else { fitnode.ForeColor = Color.Black; }
                return;
            }

            else
            {
                if (!block_fit_refresh) frag_tree.BeginUpdate();
                string[] idx_str_arr = idx_str.Split(' ');
                int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
                int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);  // identifies a fit combination in this set
                //labels_checked[set_idx] = idx_str;
                // find respective fragments in frag_tree and check or uncheck them
                // also pass the fitted height o both Fragments2 and the node on the UI
                List<TreeNode> all_nodes = get_all_nodes(frag_tree);
                for (int i = 0; i < all_fitted_sets[set_idx][set_pos_idx].Length; i++)
                {
                    int curr_idx = all_fitted_sets[set_idx][set_pos_idx][i] - 1;

                    TreeNode curr_node = all_nodes.FirstOrDefault(n => n.Name == (curr_idx).ToString());
                    double factor = all_fitted_results[set_idx][set_pos_idx][i];

                    Fragments2[curr_idx].Factor = factor;
                    curr_node.Checked = is_checked;
                    curr_node.Text = curr_node.Text.Remove(curr_node.Text.LastIndexOf(' ')) + " " + (Fragments2[curr_idx].Factor * Fragments2[curr_idx].Max_intensity).ToString("#######");
                }
                if (!block_fit_refresh) frag_tree.EndUpdate();
            }
            block_plot_refresh = false;

            // normaly, refresh is called from fragments list, but because of multiple checked events it was disabled
            // it will be called once, now that all coresponding fragments are checked
            if(!block_fit_refresh)refresh_iso_plot();
        }
        /// <summary>
        /// It was used to recheck the nodes as the user has left them before altering a specific node. Its is currently not used
        /// </summary>
        private void checked_labels()
        {
            if (fit_tree != null && fit_tree.Nodes.Count==labels_checked.Count)
            {
                block_plot_refresh = true;block_fit_refresh = true;
                for (int nd=0;nd< fit_tree.Nodes.Count ;nd++)
                {
                    foreach (TreeNode node in fit_tree.Nodes[nd].Nodes){ if (node.Name==labels_checked[nd]) { node.Checked = true; }}
                }
                block_plot_refresh = false;block_fit_refresh = false;
                // because of multiple checked events it was disabled
                // it will be called once, now that all coresponding fragments are checked
            }
        }
        private List<TreeNode> get_all_nodes(TreeView tree)
        {
            // will return a list with all nodes of a tree. Works only for 2-level depth
            List<TreeNode> res = new List<TreeNode>();

            foreach (TreeNode base_node in tree.Nodes)
                foreach (TreeNode sub_node in base_node.Nodes)
                    res.Add(sub_node);

            return res;
        }
        private List<double> get_UI_intensities(int[] subSet)
        {
            // is called from fit to pass a good starting height to the optimizer
            List<double> UI_intensities = new List<double>();

            for (int i = 0; i < subSet.Length; i++)
                UI_intensities.Add(Fragments2[subSet[i] - 1].Factor * Fragments2[subSet[i] - 1].Max_intensity);

            return UI_intensities;
        }
        private void sortSettings_Btn_Click(object sender, EventArgs e)
        {
            sort_fit_results_form(true);
        }        
        private void sort_fit_results_form(bool btn=false)
        {
            Form6 sort_fit_results = new Form6 (false,1);
            sort_fit_results.FormClosed += (s, f) => { save_preferences();};
            sort_fit_results.ShowDialog();
          
        }
        private void refresh_fitRes_Btn_Click(object sender, EventArgs e)
        {
            uncheckall_Frag();
            refresh_fit_tree_sorting();
        }
        /// <summary>
        /// Command to refresh the node sorting in all fit groups in the fit tree
        /// </summary>
        private void refresh_fit_tree_sorting()
        {           
            if (all_fitted_results != null)
            {
                frag_tree.BeginUpdate();
                update_sorting_parameters_lists();
                generate_fit_results();
                //best_checked();
                frag_tree.EndUpdate();
                refresh_iso_plot();
            }
        }
        /// <summary>
        /// Command to Refresh the node sorting in a specific fit group in the fit tree
        /// </summary>
        private void fitnode_Re_Sort(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            if (string.IsNullOrEmpty(node.Name))
            {
                form_sort_fitnode(node.Index);
            }
            else
            {
                MessageBox.Show("'Sort & Filter node' command is implemented on nodes that represent a fit group and not a specific solution of the fit group. First make sure you have selected the desired node and then right-clicked on it.", " None selected node to perform task.");
            }
        }
        /// <summary>
        /// Refresh the node sorting in a specific fit group in the fit tree
        /// </summary>
        private void refresh_fitnode_sorting(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node to perform task."); return; }
            int node_index = node.Index;
            foreach (TreeNode tnn in fit_tree.Nodes[node_index].Nodes)
            {
                if (tnn.Checked) tnn.Checked = false;
            }
            if (all_fitted_results != null && string.IsNullOrEmpty(node.Name))
            {
                frag_tree.BeginUpdate();
                //generate_fit_results();
                //best_checked(true, node.Index);
                //checked_labels();
                fit_tree.BeginUpdate();
                if (fit_tree.Nodes[node_index].Nodes.Count > 0) fit_tree.Nodes[node_index].Nodes.Clear();
                for (int j = 0; j < all_fitted_results[node_index].Count; j++)
                {
                    if (all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 2] < tab_thres[node_index][0] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 1] < tab_thres[node_index][1] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 4] < tab_thres[node_index][2] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 5] < tab_thres[node_index][3] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 6] < tab_thres[node_index][4])
                    {
                        bool print = true;
                        for (int k = 0; k < all_fitted_sets[node_index][j].Length; k++)
                        {
                            if (all_fitted_results[node_index][j][k + all_fitted_sets[node_index][j].Length] > tab_thres[node_index][2] || all_fitted_results[node_index][j][k + 3 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][3] || all_fitted_results[node_index][j][k + 4 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][4]) { print = false; }
                        }
                        if (print)
                        {
                            StringBuilder sb = new StringBuilder();

                            string tmp = "";
                            tmp += "SSE:" + all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 3].ToString("0.###e0" + " ");
                            tmp += "di:" + Math.Round(all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 4], 3).ToString() + "% ";

                            TreeNode tr = new TreeNode
                            {
                                Text = tmp,
                                Name = node_index.ToString() + " " + j.ToString()
                            };
                            fit_tree.Nodes[node_index].Nodes.Add(tr);
                        }
                    }
                }
                fit_tree.Nodes[node_index].Expand();
                refresh_iso_plot();
                fit_tree.EndUpdate();
                frag_tree.EndUpdate();
            }
            else
            {
                MessageBox.Show("'Refresh node' command is implemented on nodes that represent a fit group and not a specific solution of the fit group. First make sure you have selected the desired node and then right-clicked on it.", " None selected node to perform task.");
            }
        }
        /// <summary>
        /// Updated the user preferences for each node sorting and score thresholds
        /// </summary>
        private void update_sorting_parameters_lists()
        {
            if (tab_node != null) { tab_node.Clear(); tab_coef.Clear(); tab_thres.Clear(); labels_checked.Clear(); }
            for (int n = 0; n < all_fitted_results.Count; n++)
            {
                tab_node.Add(new bool[] { fit_sort[0], fit_sort[1], fit_sort[2], fit_sort[3], fit_sort[4], fit_sort[5] }); tab_coef.Add(new double[] { a_coef[0], a_coef[1], a_coef[2], a_coef[3], a_coef[4], a_coef[5] } );
                tab_thres.Add(new double[] { fit_thres[0], fit_thres[1], fit_thres[2], fit_thres[3], fit_thres[4] });labels_checked.Add("");
            }
            return;
        }
        private void form_sort_fitnode(int index)
        {
            Form6 sort_node = new Form6(true,index);            
            sort_node.ShowDialog();           
        }
        
        public class NodeSorter : IComparer
        {
            // Compare the length of the strings, or the strings
            // themselves, if they are the same length.
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;
                if (string.IsNullOrEmpty(tx.Name) || string.IsNullOrEmpty(ty.Name))
                {
                    string[] mz_x = tx.Text.Split(' ');
                    string[] mz_y = ty.Text.Split(' ');
                    decimal mz1 = Convert.ToDecimal(mz_x[0]);
                    decimal mz2 = Convert.ToDecimal(mz_y[0]);
                    return Decimal.Compare(mz1, mz2); 
                }
                string[] tx_idx_str_arr = tx.Name.Split(' ');
                int tx_set_idx = Convert.ToInt32(tx_idx_str_arr[0]);      // identifies the set or group of ions
                int tx_set_pos_idx = Convert.ToInt32(tx_idx_str_arr[1]);
                int tx_compare_item_idx = all_fitted_results[tx_set_idx][tx_set_pos_idx].Length;
                string[] ty_idx_str_arr = ty.Name.Split(' ');
                int ty_set_idx = Convert.ToInt32(ty_idx_str_arr[0]);      // identifies the set or group of ions
                int ty_set_pos_idx = Convert.ToInt32(ty_idx_str_arr[1]);
                int ty_compare_item_idx = all_fitted_results[ty_set_idx][ty_set_pos_idx].Length;
                int compare_result = 0;
                // value to compare--->sse_coef*sse+Ai_coef*Ai+A_coef*A+di_coef*di+ei_coef*ei+dinew_coef+dinew
                double value1 = (tab_coef[tx_set_idx][3] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 3]) + (tab_coef[tx_set_idx][0] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 2]) + (tab_coef[tx_set_idx][1] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 1]) +(tab_coef[tx_set_idx][2]  * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 4]) + (tab_coef[tx_set_idx][4] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 5]) + (tab_coef[tx_set_idx][5] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 6]);
                double value2 = (tab_coef[tx_set_idx][3] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 3]) + (tab_coef[tx_set_idx][0] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 2]) + (tab_coef[tx_set_idx][1] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 1]) + (tab_coef[tx_set_idx][2]  * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 4]) + (tab_coef[tx_set_idx][4] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 5]) + (tab_coef[tx_set_idx][5] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 6]);
                compare_result = Decimal.Compare((decimal)value1, (decimal)value2);                
                return compare_result;
            }
        }
        private void select_check(TreeNode node)
        {
            if (node.Checked) {  node.Checked = false; }
            else { node.Checked = true; toolTip_fit.Hide(fit_tree); fit_tree_tooltip(node); }
        }
        /// <summary>
        /// ZOOM at the graph region the selected fit tree node is about
        /// </summary>
        private void fit_set_graph_zoomed(TreeNode node)
        {
            if (plotExp_chkBox.Checked || plotCentr_chkBox.Checked || plotCentr_chkBox.Checked || plotFragCent_chkBox.Checked)
            {
                string[] idx_str_arr = new string[2];
                string idx_str = node.Name;
                if (string.IsNullOrEmpty(idx_str)) idx_str_arr = node.Text.Split('-');
                else idx_str_arr = node.Parent.Text.Split('-');
                double min_border = dParser(idx_str_arr[0]);
                double max_border = dParser(idx_str_arr[1]);
                iso_plot.Model.Axes[1].Zoom(min_border - 3, max_border + 10);
                if ((iso_plot.Model.Series[0] as LineSeries).Points.Count > 0 && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked))
                {
                    try
                    {
                        double pt0 = (iso_plot.Model.Series[0] as LineSeries).Points.FindAll(x => (x.X >= min_border && x.X < max_border)).Max(k => k.Y);
                        iso_plot.Model.Axes[0].Zoom(-100, pt0 * 1.2);
                    }
                    catch
                    {

                    }
                    
                }
                iso_plot.Refresh();
                invalidate_all();
            }                     
        }
        /// <summary>
        /// BUTTON unckeck all fit nodes 
        /// </summary>
        private void uncheckFit_Btn_Click(object sender, EventArgs e)
        {
            uncheck_all(fit_tree, false);
        }
        /// <summary>
        /// BUTTON select best fit solution in each fit group 
        /// </summary>
        private void check_bestBtn_Click(object sender, EventArgs e)
        {
            best_checked();
        }
        /// <summary>
        /// unckeck all fit nodes 
        /// </summary>
        private void uncheck_all(TreeView tree, bool check)
        {
            if (tree != null)
            {
                fit_tree.Cursor = System.Windows.Forms.Cursors.Default;
                uncheckall_Frag();
                fit_tree.BeginUpdate();frag_tree.BeginUpdate();
                block_plot_refresh = true; block_fit_refresh = true;
                foreach (TreeNode node in tree.Nodes)
                {
                    if(node.Checked != check) node.Checked = check;
                    foreach (TreeNode nn in node.Nodes)
                    {
                        if(nn.Checked!= check) nn.Checked = check;
                    }
                }
                fit_tree.EndUpdate(); frag_tree.EndUpdate();
                block_plot_refresh = false; block_fit_refresh = false;
                refresh_iso_plot();
            }
        }
        /// <summary>
        /// select best fit solution in each fit group(individual=false) or in a specific group only(individual=true)
        /// </summary>
        private void best_checked(bool individual = false, int node_index = 1)
        {            
            if (fit_tree != null)
            {
                fit_tree.Cursor = System.Windows.Forms.Cursors.Default;
                uncheckall_Frag();
                block_plot_refresh = true; block_fit_refresh = true;
                fit_tree.BeginUpdate();frag_tree.BeginUpdate();
                if (best_num_results==1)
                {
                    if (individual && fit_tree.Nodes.Count > node_index && fit_tree.Nodes[node_index].Nodes.Count > 0)
                    {
                        fit_tree.Nodes[node_index].Nodes[0].Checked = true;
                    }
                    else
                    {
                        foreach (TreeNode node in fit_tree.Nodes)
                        {
                            if (node.Nodes.Count > 0) { node.Nodes[0].Checked = true; }
                        }
                    }
                }
                else
                {
                    int best1 = best_num_results-1;
                    if (individual && fit_tree.Nodes.Count > node_index && fit_tree.Nodes[node_index].Nodes.Count > 0)
                    {
                        if(fit_tree.Nodes[node_index].Nodes.Count< best_num_results) { best1 = fit_tree.Nodes[node_index].Nodes.Count-1; }
                        for (int i=best1; i>-1;i--)
                        {
                            fit_tree.Nodes[node_index].Nodes[i].Checked = true;
                        }
                    }
                    else
                    {
                        foreach (TreeNode node in fit_tree.Nodes)
                        {
                            best1 = best_num_results-1;
                            if (node.Nodes.Count > 0)
                            {
                                if (node.Nodes.Count < best_num_results) { best1 = node.Nodes.Count-1; }

                                for (int i = best1; i > -1; i--)
                                {
                                    node.Nodes[i].Checked = true;
                                }                                
                            }
                        }
                    }
                    fit_tree.Cursor = System.Windows.Forms.Cursors.No;
                }
                block_plot_refresh = false; block_fit_refresh = false;
                fit_tree.EndUpdate(); frag_tree.EndUpdate();
                refresh_iso_plot();
            }
        }
        private void fitSettings_Btn_Click(object sender, EventArgs e)
        {
            Form7 fit_settings = new Form7();
            fit_settings.FormClosed += (s, f) => { save_preferences(); };
            fit_settings.ShowDialog();
        }
        //FIT CHECKED GROUPS
        /// <summary>
        /// fit checked groups' fragments in a common fit group, the new fit group can contain either all the fragments in the checked fit groups(all_frag=true) or only the checked fragments in the checked fit groups(all_frag=false)
        /// </summary>
        private void fit_checked_groups(bool all_frag=true)
        {
            if (fit_tree != null)
            {
                List<int> grp_nodes = new List<int>();
                List<int> frgmts = new List<int>();
                List<TreeNode> all_nodes = get_all_nodes(frag_tree);
                foreach (TreeNode t in fit_tree.Nodes)
                {
                    if (t.Checked)
                    {
                        grp_nodes.Add(t.Index);                        
                        int[] all = all_fitted_sets[t.Index].OrderBy(x => x.Length).Last();
                        if (all_frag)
                        {
                            foreach (TreeNode tnn in t.Nodes)
                            {
                                if (tnn.Checked) tnn.Checked = false;
                            }
                            foreach (int idx in all)
                            {
                                if (!frgmts.Contains(idx)) frgmts.Add(idx);
                                TreeNode curr_node = all_nodes.FirstOrDefault(n => n.Name == (idx - 1).ToString());
                                if (curr_node.Checked) { curr_node.Checked = false; }
                            }                           
                        }
                        else
                        {
                            foreach (int idx in all)
                            {                                
                                TreeNode curr_node = all_nodes.FirstOrDefault(n => n.Name == (idx - 1).ToString());
                                if (curr_node.Checked) { if (!frgmts.Contains(idx)) { frgmts.Add(idx); } curr_node.Checked = false; }
                            }
                            foreach (TreeNode tnn in t.Nodes)
                            {
                                if (tnn.Checked) tnn.Checked = false;
                            }
                        }
                        
                    }
                }
                if (grp_nodes.Count == 0 || frgmts.Count == 0) return;
                if (frgmts.Count > 12) { MessageBox.Show("The maximum amount of fragments in each group iteration is 12! Please try again with fewer or smaller fit groups."); return; }
                if (frgmts.Count > 11) { DialogResult dialogResult= MessageBox.Show("Τhe process takes about 8 minutes to complete. Are you sure you would like to continue?","Attention", MessageBoxButtons.YesNo);if (dialogResult == DialogResult.No) { return; } }
                if (frgmts.Count > 10) { DialogResult dialogResult = MessageBox.Show("Τhe process takes about 4 minutes to complete. Are you sure you would like to continue?", "Attention", MessageBoxButtons.YesNo); if (dialogResult == DialogResult.No) { return; } }
                (List<double[]> res, List<int[]> set) = fit_distros_parallel2(frgmts);
                grp_nodes.OrderBy(g => g); frgmts.OrderBy(f => f);
                all_fitted_results.RemoveRange(grp_nodes[0], grp_nodes.Count());
                all_fitted_sets.RemoveRange(grp_nodes[0], grp_nodes.Count());
                all_fitted_sets.Insert(grp_nodes[0], set);
                all_fitted_results.Insert(grp_nodes[0], res);
                tab_node.RemoveRange(grp_nodes[0], grp_nodes.Count());
                tab_thres.RemoveRange(grp_nodes[0], grp_nodes.Count());
                tab_coef.RemoveRange(grp_nodes[0], grp_nodes.Count());
                labels_checked.RemoveRange(grp_nodes[0], grp_nodes.Count());
                tab_node.Insert(grp_nodes[0], new bool[] { fit_sort[0], fit_sort[1], fit_sort[2], fit_sort[3], fit_sort[4], fit_sort[5] });
                tab_thres.Insert(grp_nodes[0], new double[] { fit_thres[0], fit_thres[1], fit_thres[2], fit_thres[3], fit_thres[4] });
                tab_coef.Insert(grp_nodes[0], new double[] { a_coef[0], a_coef[1], a_coef[2], a_coef[3], a_coef[4], a_coef[5] });
                labels_checked.Insert(grp_nodes[0], "");
                int counter = 0;
                foreach (int g in grp_nodes)
                {
                    fit_tree.Nodes.RemoveAt(g - counter); counter++;
                }
                fit_tree.BeginUpdate();
                TreeNode node_new = new TreeNode();
                int[] longest =set.OrderBy(x => x.Length).Last();
                node_new.Text = Fragments2[longest.First() - 1].Mz + " - " + Fragments2[longest.Last() - 1].Mz;
                
                for (int j = 0; j < res.Count; j++)
                {
                    if (res[j][res[j].Length - 2] <fit_thres[0] && res[j][res[j].Length - 1] < fit_thres[1] && res[j][res[j].Length - 4] < fit_thres[2] && res[j][res[j].Length - 5] < fit_thres[3] && res[j][res[j].Length - 6] < fit_thres[4])
                    {
                        bool print = true;
                        for (int k = 0; k < set[j].Length; k++)
                        {
                            if (res[j][k + set[j].Length] > fit_thres[2] || res[j][k + 3 * set[j].Length] > fit_thres[3] || res[j][k + 4 * set[j].Length] > fit_thres[4]) { print = false; }
                        }
                        if (print)
                        {
                            StringBuilder sb = new StringBuilder();

                            string tmp = "";
                            tmp += "SSE:" + res[j][res[j].Length - 3].ToString("0.###e0" + " ");
                            tmp += "di:" + Math.Round(res[j][res[j].Length - 4], 3).ToString() + "% ";
                            TreeNode tr = new TreeNode
                            {
                                Text = tmp,
                                Name = grp_nodes[0].ToString() + " " + j.ToString()                             
                            };
                           node_new.Nodes.Add(tr);
                        }
                    }
                }
                fit_tree.Nodes.Insert(grp_nodes[0], node_new);
                for (int k= grp_nodes[0]+1;k< fit_tree.Nodes.Count; k++)
                {
                    foreach (TreeNode nn in fit_tree.Nodes[k].Nodes )
                    {
                        string[] idx_str_arr = nn.Name.Split(' ');
                        int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
                        nn.Name = (set_idx- grp_nodes.Count()+1).ToString()+ " " + idx_str_arr[1];
                    }
                }
                fit_tree.EndUpdate();
                remove_child_nodes();                
                if (fit_tree.Nodes[grp_nodes[0]].Nodes.Count>0){ fit_tree.Nodes[grp_nodes[0]].Nodes[0].EnsureVisible(); fit_tree.Nodes[grp_nodes[0]].Nodes[0].Checked = true;}
            }
        }
        private void fit_chkGrpsBtn_Click(object sender, EventArgs e)
        {
            fit_checked_groups();
        }
        private void fit_chkGrpsChkFragBtn_Click_1(object sender, EventArgs e)
        {
            fit_checked_groups(false);
        }

        #endregion

        #region UI control
        private void enable_UIcontrols(string status)
        {
            if (status == "post load")
            {
                fitMin_Box.Enabled = fitMax_Box.Enabled = fitStep_Box.Enabled = Fitting_chkBox.Enabled = true;
                Fitting_chkBox.Checked = loadFit_Btn.Enabled = false;
            }
            else if (status == "post import fragments")
            {
                clearCalc_Btn.Enabled = mzMax_Box.Enabled = mzMin_Box.Enabled = mzMax_Label.Enabled = mzMin_Label.Enabled = chargeMax_Box.Enabled = true;
                chargeMin_Box.Enabled = chargeAll_Btn.Enabled = idxPr_Box.Enabled = idxTo_Box.Enabled = idxFrom_Box.Enabled = resolution_Box.Enabled = true;
                machine_listBox.Enabled = calc_Btn.Enabled =fragCalc_Btn.Enabled= true;
                loadFit_Btn.Enabled = false;
            }
            else if (status == "post calculations")
            {
                saveCalc_Btn.Enabled = clearCalc_Btn.Enabled = calc_Btn.Enabled = fit_Btn.Enabled = fit_sel_Btn.Enabled = true;
                loadFit_Btn.Enabled = false;
            }
        }

        #endregion

        #region refresh plot
        private void refresh_iso_plot()
        {
            //// 0.a gather info on which fragments are selected to plot, and their respective intensities
            //List<int> to_plot = selectedFragments.ToList(); // deep copy, don't mess selectedFragments
            List<int> to_plot = new List<int>();
            //0.a add only the desired fragments to to_plot
            foreach (int idx in selectedFragments)
            {
                string ion = Fragments2[idx - 1].Ion_type;
                if (ion.StartsWith("a")|| ion.StartsWith("(a"))
                {
                    if (disp_a.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("b")|| ion.StartsWith("(b"))
                {
                    if (disp_b.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("c")|| ion.StartsWith("(c"))
                {
                    if (disp_c.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("x")|| ion.StartsWith("(x"))
                {
                    if (disp_x.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("y")|| ion.StartsWith("(y"))
                {
                    if (disp_y.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("z")|| ion.StartsWith("(z"))
                {
                    if (disp_z.Checked) { to_plot.Add(idx); }
                }
                else if (ion.Contains("inter"))
                {
                    if (disp_internal.Checked) { to_plot.Add(idx); }
                }
                else
                {
                    to_plot.Add(idx);
                }

            }
            // 0.b. reset iso plot
            reset_iso_plot();

            // 1.a rerun calculations for fit and residual
            recalculate_fitted_residual(to_plot);

            // 1.b Add the experimental to plot if selected
            if (plotExp_chkBox.Checked && all_data.Count>0)
            {
                (iso_plot.Model.Series[0] as LineSeries).Title = "Exp";
                for (int j = 0; j < all_data[0].Count; j++)
                    (iso_plot.Model.Series[0] as LineSeries).Points.Add(new DataPoint(all_data[0][j][0], 1.0 * all_data[0][j][1]));
            }

            // 2. replot all isotopes
            if (plotFragProf_chkBox.Checked && all_data.Count > 0)
            {
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Fragments2[curr_idx - 1].Name;
                        (iso_plot.Model.Series[curr_idx] as LineSeries).Title = name_str;

                        // paint frag aligned
                        //for (int j = 0; j < all_data[0].Count; j++)
                        //(iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new DataPoint(all_data[0][j][0], Fragments2[curr_idx - 1].Factor * all_data_aligned[j][curr_idx]));

                        // paint frag envelope
                        for (int j = 0; j < all_data[curr_idx].Count; j++)
                            (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new DataPoint(all_data[curr_idx][j][0], Fragments2[curr_idx - 1].Factor * all_data[curr_idx][j][1]));
                    }
                }
                if (Form9.now)
                {
                    string name_str = Form9.Fragments3[Form9.selected_idx].Name;
                    (iso_plot.Model.Series[Fragments2.Count+1] as LineSeries).Title = name_str;
                    for (int j = 0; j < all_data.Last().Count; j++)
                        (iso_plot.Model.Series[Fragments2.Count+1] as LineSeries).Points.Add(new DataPoint(all_data.Last()[j][0], Form9.Fragments3[Form9.selected_idx].Factor * all_data.Last()[j][1]));
                }
            }
            if (plotFragCent_chkBox.Checked && all_data.Count > 0)
            {
                int help=Convert.ToInt32(Form9.now);
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Fragments2[curr_idx - 1].Name;
                        (iso_plot.Model.Series[curr_idx + Fragments2.Count+help] as LinearBarSeries).Title = name_str;

                        // paint frag envelope
                        for (int j = 0; j < Fragments2[curr_idx - 1].Centroid.Count; j++)
                        {
                            List<PointPlot> cenn = Fragments2[curr_idx - 1].Centroid.OrderBy(p => p.X).ToList();
                            (iso_plot.Model.Series[curr_idx + Fragments2.Count + help] as LinearBarSeries).Points.Add(new DataPoint(cenn[j].X, Fragments2[curr_idx - 1].Factor * cenn[j].Y));

                        }
                    }
                }
                if (Form9.now)
                {
                    int curr_idx = Form9.selected_idx;
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Form9.Fragments3[curr_idx].Name;
                        (iso_plot.Model.Series[2*Fragments2.Count+2] as LinearBarSeries).Title = name_str;

                        // paint frag envelope
                        for (int j = 0; j < Form9.Fragments3[curr_idx ].Centroid.Count; j++)
                        {
                            List<PointPlot> cenn = Form9.Fragments3[curr_idx ].Centroid.OrderBy(p => p.X).ToList();
                            (iso_plot.Model.Series[2 * Fragments2.Count + 2] as LinearBarSeries).Points.Add(new DataPoint(cenn[j].X, Form9.Fragments3[curr_idx ].Factor * cenn[j].Y));
                        }
                    }
                }
            }          
            // 3. fitted plot
            if (summation.Count > 0 )
                if (Fitting_chkBox.Checked)
                    for (int j = 0; j < summation.Count; j++)
                        (iso_plot.Model.Series[(all_data.Count*2)-1] as LineSeries).Points.Add(new DataPoint(summation[j][0], summation[j][1]));

            // 4. residual plot
            if (residual.Count > 0)
            {
                for (int j = 0; j < residual.Count; j++)
                    (res_plot.Model.Series[0] as LineSeries).Points.Add(new DataPoint(residual[j][0], residual[j][1]));
                
            }                         

            // 5. centroid (bar)
            if (plotCentr_chkBox.Checked)
            {
                foreach (double[] peak in peak_points)
                {
                    double mz = peak[1] + peak[4];
                    double inten = peak[5];
                    //(iso_plot.Model.Series.Last() as RectangleBarSeries).Items.Add(new RectangleBarItem(mz - 1e-4, 0, mz + 1e-4, inten));
                    (iso_plot.Model.Series.Last() as LinearBarSeries).Points.Add(new DataPoint(mz, inten));
                }
            }

            // 6. fragment annotations
            frag_annotation(to_plot);
            
            invalidate_all();
        }
        private void reset_iso_plot()
        {
            iso_plot.Model.Series.Clear();
            for (int i = 0; i < all_data.Count; i++)
            {
                OxyColor cc;
                if (Form9.now == true && i == all_data.Count - 1)
                {
                    cc = Form9.Fragments3[Form9.selected_idx].Color;                    
                }
                else
                {
                    cc = get_fragment_color(i);
                }
                LineSeries tmp = new LineSeries() { StrokeThickness = frag_width, Color = cc, LineStyle = frag_style };
                if (i == 0) { tmp.StrokeThickness = exp_width; tmp.LineStyle = exper_style; }
                iso_plot.Model.Series.Add(tmp);
            }            
            for (int i = 1; i < all_data.Count; i++)
            {
                if (Form9.now == true && i==all_data.Count-1 )
                {
                    OxyColor cc = Form9.Fragments3[Form9.selected_idx].Color;
                    LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1, StrokeColor = cc, FillColor = cc, BarWidth = cen_width };
                    iso_plot.Model.Series.Add(bar);
                    break;
                }
                else
                {
                    OxyColor cc = get_fragment_color(i);
                    LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1, StrokeColor = cc, FillColor = cc, BarWidth = cen_width };
                    iso_plot.Model.Series.Add(bar);
                }
               
            }
            if (insert_exp == true)
            {
                LineSeries fit = new LineSeries() { StrokeThickness = fit_width, Color = fit_color, LineStyle = fit_style };
                iso_plot.Model.Series.Add(fit);
            }
            res_plot.Model.Series.Clear();
            if (insert_exp == true)
            {
                LineSeries res = new LineSeries() { StrokeThickness = 1, Color = OxyColors.Black };
                res_plot.Model.Series.Add(res);
            }
            if(plotCentr_chkBox.Checked)
            {
                //RectangleBarSeries bar = new RectangleBarSeries { StrokeColor = OxyColors.Crimson, FillColor = OxyColors.Crimson };
                //iso_plot.Model.Series.Add(bar);
                LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1,StrokeColor = peak_color, FillColor = peak_color,BarWidth= peak_width };
                iso_plot.Model.Series.Add(bar);
            }
            
        }
        private void recalculate_fitted_residual(List<int> to_plot)
        {
            // calculate addition of selected fragments, and the respective residual
            // it is always called on every refresh of the plot 
            // if it is called from a selected fit change, no need to seek info from fit results. Results are already on the UI (checkbox.checked, and factor textBox)
            // to_plot and UI_intensities may also contain experimental index that is not necessary for sum or residual and has to be removed for coding brevity
            // shallow copy to_plot and UI_intensities so as not to fuck up original Lists

            List<int> plot_idxs = new List<int>(to_plot);
            summation.Clear();
            residual.Clear();

            // 1. calculate addition of fragments and residual
            for (int i = 0; i < all_data_aligned.Count; i++)//(M)gia osa einai ta peiramatika dedomena
            {
                double intensity = 0.0;

                for (int j = 0; j < plot_idxs.Count; j++)
                    intensity += all_data_aligned[i][plot_idxs[j]] * Fragments2[plot_idxs[j] - 1].Factor;       // all_data_alligned contain experimental, Fragments2 are one idx position back
                if (Form9.now) { intensity += all_data_aligned[i].Last() *Form9.Fragments3[Form9.selected_idx].Factor; }
                summation.Add(new double[] { all_data[0][i][0], intensity });
                if (rel_res_chkBx.Checked)
                {
                    if (all_data[0][i][1]==0 || intensity==0)
                    {
                        residual.Add(new double[] { all_data[0][i][0], 1 });
                    }
                    else
                    {
                        residual.Add(new double[] { all_data[0][i][0], (all_data[0][i][1] - intensity) / all_data[0][i][1] });
                    }                    
                }
                else
                {
                    residual.Add(new double[] { all_data[0][i][0], all_data[0][i][1] - intensity });
                }
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

        #region OxyPlot
        private void Initialize_Oxy()
        {
            // isotopes plot
            if (iso_plot != null) iso_plot.Dispose();

            iso_plot = new PlotView() { Name = "iso_plot", Location = new Point(5, 185), Size = new Size(1310, 570), BackColor = Color.White, Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom, Dock = System.Windows.Forms.DockStyle.Fill };
            fit_grpBox.Controls.Add(iso_plot);
            iso_plot.MouseLeave += (s, e) => { if (!fragPlotLbl_chkBx.Checked && !fragPlotLbl_chkBx2.Checked) { iso_plot.Model.Annotations.Clear(); invalidate_all(); } };
            PlotModel iso_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = legend_chkBx.Checked, LegendPosition = LegendPosition.TopRight, LegendFontSize = 13, TitleFontSize = 11 }; // Title = "",
            iso_plot.Model = iso_model;           
            iso_model.Updating += (s, e) =>
            {
                if (iso_model.Series.Count > 15) iso_model.LegendFontSize = 9;
                else if (iso_model.Series.Count > 40) iso_model.LegendFontSize = 5;
                else iso_model.LegendFontSize = 13;
            };
            iso_model.TrackerChanged += (s, e) =>
            {
                if (count_distance || cursor_chkBx.Checked) iso_plot.HideTracker();  
                
            };
             //////iso_model.TrackerChanged += (s, e) => { e.HitResult.Position.X };
             //////iso_model.MouseDown += (s, e) =>
             //////{
             //////    OxyPlot.Axes.Axis x; OxyPlot.Axes.Axis y;
             //////    iso_model.GetAxesFromPoint(e.Position, out x, out y);
             //////    DataPoint p = OxyPlot.Axes.Axis.InverseTransform(e.Position, x, y);
             //////};

             iso_plot.Controller = new CustomPlotController();
            //ContextMenu ctxMn = new ContextMenu() { };
            //MenuItem showPoints = new MenuItem("Show charge ruler", manage_charge_points);
            //MenuItem clearPoints = new MenuItem("Clear charge ruler", manage_charge_points);
            //MenuItem copyImage = new MenuItem("Copy image", export_chartImage);
            //MenuItem exportImage = new MenuItem("Export image to file", export_chartImage);
            //ctxMn.MenuItems.AddRange(new MenuItem[] { showPoints, clearPoints, copyImage, exportImage });
            
            //iso_model.MouseDown += (s, e) => { if (e.ChangedButton == OxyMouseButton.Right) { charge_center = e.Position; ContextMenu = ctxMn; } };
            iso_model.MouseDown += (s, e) => 
            { 
                if (cursor_chkBx.Checked && e.ChangedButton == OxyMouseButton.Left && e.IsShiftDown == true)
                {
                    if (count_distance) { cersor_distance(previous_point, e.Position); }
                    else { previous_point = e.Position; count_distance = true; }
                }
                else if (e.ChangedButton == OxyMouseButton.Left)
                {
                    count_distance = false;/* cersor_distance(e.Position, e.Position);*/
                }               
            };
            iso_model.MouseMove += (s, e) => {if (count_distance && e.IsShiftDown == true) { cersor_distance(previous_point, e.Position); } else { cersor_distance(e.Position, e.Position); } };
            iso_model.MouseUp += (s, e) =>{ count_distance = false;};

            //////iso_plot.MouseWheel += (s, e) => { if (e.Delta > 0 && e.ToMouseEventArgs(OxyModifierKeys.Control).IsControlDown) iso_model.DefaultXAxis.ZoomAtCenter(2) ; };
            //////bool isControlDown = System.Windows.Input Keyboard.IsKeyDown(Key.LeftCtrl);
            //////var m = new ZoomStepManipulator(this, e.Delta * 0.001, isControlDown);
            //////iso_plot.MouseWheel += (s, e) =>
            //////{
            //////    if (e.Delta > 0) iso_plot.Model.DefaultXAxis.ZoomAtCenter(1);
            //////};

            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { StringFormat = y_format + y_numformat, IntervalLength = y_interval, TickStyle = Y_tick, MajorGridlineStyle = Ymajor_grid,MinorGridlineStyle=Yminor_grid, FontSize = 10, AxisTitleDistance = 10, TitleFontSize = 11, Title = "Intensity" };
            iso_model.Axes.Add(linearAxis1);

            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format+x_numformat, IntervalLength = x_interval, TickStyle = X_tick, MajorGridlineStyle =Xmajor_grid, MinorGridlineStyle = Xminor_grid, FontSize = 10, AxisTitleDistance = 10, TitleFontSize = 11, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            iso_model.Axes.Add(linearAxis2);

            // residual plot
            if (res_plot != null) res_plot.Dispose();
            res_plot = new OxyPlot.WindowsForms.PlotView() { Name = "res_plot", Location = new Point(5, 760), Size = new Size(1310, 150), BackColor = Color.White, Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left, Dock = System.Windows.Forms.DockStyle.Fill };
            res_grpBox.Controls.Add(res_plot);

            //(M)create a view model--> res_model
            PlotModel res_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = false, LegendPosition = LegendPosition.TopRight, LegendFontSize = 11, TitleFontSize = 11 }; // Title = "",
            res_plot.Model = res_model;

            var linearAxis1r = new OxyPlot.Axes.LinearAxis() { StringFormat =y_format + y_numformat, IntervalLength = y_interval, TickStyle = Y_tick, MajorGridlineStyle = Ymajor_grid, MinorGridlineStyle = Yminor_grid, FontSize = 10, AxisTitleDistance = 10, TitleFontSize = 11, Title = "Intensity" };
            res_model.Axes.Add(linearAxis1r);
            var linearAxis2r = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format + x_numformat, IntervalLength = x_interval, TickStyle = X_tick, MajorGridlineStyle = Xmajor_grid, MinorGridlineStyle = Xminor_grid, FontSize = 10, AxisTitleDistance =10, TitleFontSize = 11, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            res_model.Axes.Add(linearAxis2r);

            res_plot.Controller = new CustomPlotController();

            // bind the 2 x-axes :D
            linearAxis2.AxisChanged += (s, e) => { linearAxis2r.Zoom(linearAxis2.ActualMinimum, linearAxis2.ActualMaximum);  res_plot.InvalidatePlot(true); };            
            iso_model.Updated += (s, e) => 
            {
                res_plot.Model.Axes[1].Zoom(iso_plot.Model.Axes[1].ActualMinimum,  iso_plot.Model.Axes[1].ActualMaximum);
                if (residual.Count > 0 && (plotExp_chkBox.Checked || plotCentr_chkBox.Checked))
                {
                    double pt0 = (res_plot.Model.Series[0] as LineSeries).Points.FindAll(x => (x.X >= iso_plot.Model.Axes[1].ActualMinimum && x.X < iso_plot.Model.Axes[1].ActualMaximum)).Max(k => k.Y);
                    double pt1 = (res_plot.Model.Series[0] as LineSeries).Points.FindAll(x => (x.X >= iso_plot.Model.Axes[1].ActualMinimum && x.X < iso_plot.Model.Axes[1].ActualMaximum)).Min(k => k.Y);
                    res_plot.Model.Axes[0].Zoom(pt1, pt0);
                }
                double max_iso = 200;
                if (iso_plot.Model.Series.Count>0 && autoscale_Btn.Checked)
                {
                    if ((iso_plot.Model.Series[0] as LineSeries).Points.Count > 0)
                    {
                        double iso_1 = (iso_plot.Model.Series[0] as LineSeries).Points.FindAll(x => (x.X >= iso_plot.Model.Axes[1].ActualMinimum && x.X < iso_plot.Model.Axes[1].ActualMaximum)).Max(k => k.Y);
                        if (iso_1 > max_iso) max_iso = iso_1;
                    }
                    if (all_data.Count>1 && (iso_plot.Model.Series[(all_data.Count * 2) - 1] as LineSeries).Points.Count > 0)
                    {
                        double iso_1 = (iso_plot.Model.Series[(all_data.Count * 2) - 1] as LineSeries).Points.FindAll(x => (x.X >= iso_plot.Model.Axes[1].ActualMinimum && x.X < iso_plot.Model.Axes[1].ActualMaximum)).Max(k => k.Y);
                        if (iso_1 > max_iso) max_iso = iso_1;
                    }
                    iso_plot.Model.Axes[0].Zoom(-max_iso * 0.2, max_iso * 1.2);
                }                

            };
            iso_plot.MouseDoubleClick += (s, e) => { iso_model.ResetAllAxes(); invalidate_all(); };
        }
        
        private void cersor_distance(ScreenPoint a, ScreenPoint b)
        {
            if (cursor_chkBx.Checked && insert_exp && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked|| plotExp_chkBox.Checked || plotCentr_chkBox.Checked))
            {
                iso_plot.Model.Annotations.Clear();

                double mz_a = iso_plot.Model.DefaultXAxis.InverseTransform(a.X);
                double h_a = iso_plot.Model.DefaultYAxis.InverseTransform(a.Y);               
                if (count_distance)
                {

                    double mz_b = iso_plot.Model.DefaultXAxis.InverseTransform(b.X);
                    point_distance = mz_a - mz_b;
                    iso_plot.Model.Annotations.Add(new PointAnnotation()
                    {
                        X = mz_a,
                        Y = h_a,
                        Size = 4,
                        Text = "distance: " + Math.Round(Math.Abs(point_distance), 4).ToString(),
                        Fill = OxyColors.Black,
                        Shape = MarkerType.None,
                        TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Right,
                        TextVerticalAlignment = VerticalAlignment.Bottom
                    });
                    iso_plot.Model.Annotations.Add(new LineAnnotation { X = mz_a, Type = LineAnnotationType.Vertical });
                    iso_plot.Model.Annotations.Add(new LineAnnotation { Y = h_a, Type = LineAnnotationType.Horizontal });

                    //iso_plot.Model.Annotations.Add(new RectangleAnnotation { MinimumX = min_border, MaximumX = min_border+ point_distance, Fill = OxyColor.FromAColor(99, OxyColors.Gainsboro) });
                    if (point_distance < 0) iso_plot.Model.Annotations.Add(new RectangleAnnotation { MinimumX = mz_a, MaximumX = mz_a + Math.Abs(point_distance), Fill = OxyColor.FromAColor(99, OxyColors.LightSalmon) });
                    else iso_plot.Model.Annotations.Add(new RectangleAnnotation { MinimumX = mz_a - point_distance, MaximumX = mz_a, Fill = OxyColor.FromAColor(99, OxyColors.LightSalmon) });

                    iso_plot.Model.Annotations.Add(new LineAnnotation { X = mz_a - point_distance, Type = LineAnnotationType.Vertical });
                }
                else
                {
                    ////TrackerManipulator kkk = new TrackerManipulator(iso_plot) { PointsOnly=false,Snap=true,LockToInitialSeries};
                    //iso_plot.Model.Annotations.Add(new PointAnnotation()
                    //{
                    //    X = mz_a,
                    //    Y = h_a,
                    //    Size = 4,
                    //    Text = "I:" + Math.Round(h_a, 0).ToString() + " , m/z:" + Math.Round(mz_a, 4).ToString(),
                    //    Fill = OxyColors.Black,
                    //    Shape = MarkerType.None,
                    //    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Right,
                    //    TextColor=OxyColors.Crimson,
                    //    TextVerticalAlignment = VerticalAlignment.Bottom
                    //});

                    iso_plot.Model.Annotations.Add(new TextAnnotation()
                    {
                        TextPosition = new DataPoint(mz_a, h_a),
                        TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Right,
                        Background = OxyColors.Gainsboro,
                        Text = "I:" + Math.Round(h_a, 0).ToString() + " , m/z:" + Math.Round(mz_a, 4).ToString(),
                        Layer = AnnotationLayer.AboveSeries,
                        Stroke = OxyColors.Black,
                        TextColor = OxyColors.Black,
                        FontWeight = 100
                    });
                    iso_plot.Model.Annotations.Add(new LineAnnotation { X = mz_a, Type = LineAnnotationType.Vertical });
                    iso_plot.Model.Annotations.Add(new LineAnnotation { Y = h_a, Type = LineAnnotationType.Horizontal });
                    invalidate_all();
                }
                invalidate_all();
            }            
        }
        private void legend_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            iso_plot.Model.IsLegendVisible = legend_chkBx.Checked;
            invalidate_all();
        }

        private void frag_annotation(List<int> to_plot)
        {
            if ((fragPlotLbl_chkBx.Checked || fragPlotLbl_chkBx2.Checked) && !cursor_chkBx.Checked && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked) )
            {
                List<int> plot_idxs = new List<int>(to_plot);
                iso_plot.Model.Annotations.Clear();
                foreach (int p in plot_idxs)
                {
                    if ((fragPlotLbl_chkBx.Checked && !Fragments2[p - 1].Ion_type.StartsWith("inte")) || (fragPlotLbl_chkBx2.Checked && Fragments2[p - 1].Ion_type.StartsWith("inte")))
                    {
                        iso_plot.Model.Annotations.Add(new TextAnnotation()
                        {
                            TextPosition = new DataPoint(Fragments2[p - 1].Centroid[0].X, Fragments2[p - 1].Centroid[0].Y * Fragments2[p - 1].Factor),
                            TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Right,
                            TextVerticalAlignment = VerticalAlignment.Bottom,
                            TextRotation = 270,
                            Background = OxyColors.Transparent,
                            Text = Fragments2[p - 1].Name.ToString(),
                            Layer = AnnotationLayer.AboveSeries,
                            Stroke = OxyColors.Transparent,
                            TextColor = Fragments2[p - 1].Color,
                            FontWeight = 100
                        });
                    }                    
                }
            }
        }
        private void cursor_chkBx_Click(object sender, EventArgs e)
        {
            if (!cursor_chkBx.Checked) { iso_plot.Model.Annotations.Clear(); invalidate_all(); }
            else { fragPlotLbl_chkBx.Checked=false; fragPlotLbl_chkBx2.Checked = false; }
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
                this.BindMouseWheel(OxyModifierKeys.Control, PlotCommands.ZoomWheel);
            }
        }

        #endregion

        #region Toolbar control
        /// <summary>
        /// Initialize Progress Bar (as invisible).
        /// </summary>
        private void progress_display_init()
        {
            tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(599, 20), Style = 0, Minimum = 0, Value = 0, Size = new Size(292, 21), AutoSize = false, Visible = false,Anchor=AnchorStyles.Right | AnchorStyles.Top };
            prg_lbl = new Label { Name = "prg_lbl", Location = new Point(608,3), AutoSize = true, Visible = false, Anchor = AnchorStyles.Right | AnchorStyles.Top };
            user_grpBox.Controls.AddRange(new Control[] { tlPrgBr, prg_lbl });
            prg_lbl.BringToFront(); tlPrgBr.BringToFront();

        }

        /// <summary>
        /// Display Progress Bar.
        /// </summary>
        private void progress_display_start(int barMax, string info)
        {
            prg_lbl.Invoke(new Action(() => prg_lbl.Visible = true));   //thread safe call
            prg_lbl.Invoke(new Action(() => prg_lbl.Text = info));   //thread safe call
            //Blink
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Maximum = barMax));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = 0));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Visible = true));   //thread safe call         
        }

        private void progress_display_stop()
        {
            prg_lbl.Invoke(new Action(() => prg_lbl.Visible = false));   //thread safe call
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Visible = false));   //thread safe call          
        }

        private void progress_display_update(int idx)                                                                                                           
        {
            prg_lbl.Invoke(new Action(() => prg_lbl.Invalidate(true)));   //thread safe call
            if (idx< tlPrgBr.Maximum)
            {
                tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = idx));   //thread safe call
                tlPrgBr.Invoke(new Action(() => tlPrgBr.Value = idx - 1));   //thread safe call
            }
            else
            {
                Debug.WriteLine("TOOLPROGRESSERROR "+idx+" > " + tlPrgBr.Maximum);
            }
            tlPrgBr.Invoke(new Action(() => tlPrgBr.Update()));   //thread safe call
        }

        private async void Blink()
        {
            while (prg_lbl.Visible)
            {
                await Task.Delay(250);
                prg_lbl.BeginInvoke(new Action(() => prg_lbl.BackColor = prg_lbl.BackColor == Color.Red ? Color.Green : Color.Red));
            }
        }
        #endregion

        #region peak detection

        private void peak_detect()
        {
            sw1.Reset(); sw1.Start();
            peak_points.Clear();
            peak_points = LIMPIC_parallel();
            //peak_points = LIMPIC_mod();
            // it has to be sorted because of paralellism
            peak_points = peak_points.OrderBy(m => m[1] + m[4]).ToList();
            //peak_points = peak_points.OrderBy(m => m[1]).ToList();
            sw1.Stop(); Debug.WriteLine("peak detect(M): " + sw1.ElapsedMilliseconds.ToString());
        }

        private List<double[]> LIMPIC_parallel()
        {
            progress_display_start(experimental.Count, "Detecting peaks in experimental spectrum...");

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
            int progress = 0;
            Parallel.For(starting_points_to_omit, len - peak_width - 1, (i, state) =>
            {
                // safelly keep track of progress
                lock (_locker) { Interlocked.Increment(ref progress); }

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

                        lock (_locker) { temp_peaks.Add(point); }
                    }
                }
                try
                {
                    if (progress % 5000 == 0 && progress > 0) progress_display_update(progress);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                };
            });
            progress_display_stop();

            return temp_peaks;
        }

        private List<double[]> LIMPIC_mod()
        {
            progress_display_start(experimental.Count, "Detecting peaks in experimental spectrum...");

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
            // resolution , adjusted relative time , adjusted height ,  FWHM dt [bins]
            double[] d = new double[4] { res_norm, normal[1] * bin_size, normal[2], normal[0] };
            return d;
        }

        private double[] estimate_alglib_normal(int locMax_index, double[] dataX, double[] dataY)
        {
            double height = dataY[locMax_index];
            object data = new object[2] { dataY, locMax_index };

            // 2. initialize needed params
            double[] coeficients = new double[] { 2.0, 0.0, 1.1 * height };
            double epsx = 0.0000000001;
            int maxits = 100000;
            double[] bndl = new double[3] { 1e-1, -1, 1.00 * height };
            double[] bndh = new double[3] { 10, 1, 1.2 * height };
            double[] scale = new double[3] { 1, 0.5, 0.1 * height };

            alglib.minlmstate state;
            alglib.minlmreport rep;

            alglib.minlmcreatev(2, coeficients, 0.001, out state);
            alglib.minlmsetbc(state, bndl, bndh);                                            // boundary conditions
            alglib.minlmsetcond(state, epsx, maxits);
            alglib.minlmsetscale(state, scale);
            alglib.minlmoptimize(state, function, null, data);
            alglib.minlmresults(state, out coeficients, out rep);

            // 4. save result
            double[] minimum = new double[3] { coeficients[0], coeficients[1], coeficients[2] };
            return minimum;
        }

        public void function(double[] x, double[] func, object data)
        {
            func[0] = 0;
            double gauss_point, temp, temp2;

            double[] dataY = ((double[])((object[])data)[0]);
            int idx = ((int)((object[])data)[1]);

            for (int i = 8; i < 13; i++)
            {
                temp2 = ((double)i - 10.0 - x[1]) / (1.4142 * x[0]);
                gauss_point = x[2] * Math.Exp(-1.0 * temp2 * temp2);
                temp = dataY[idx + (i - 10)] - gauss_point;
                func[0] += temp * temp;
            }
        }

        private void display_peakList()
        {            
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }
        private void settingsPeak_Btn_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.FormClosed += (s, f) => { save_preferences(); };
            frm8.ShowDialog();
        }

        #endregion

        #region Data manipulation Clear
        private void experimental_to_all_data(bool selected_part = false)
        {
            // copy experimental to all data. After loading the whole range. After cahnge in fit range, only selected region
            if (all_data.Count < 1) all_data.Add(new List<double[]>());
            all_data[0].Clear();

            if (selected_part)
                foreach (double[] exp in selected_all_data[0])
                    all_data[0].Add(exp);
            else
                foreach (double[] exp in experimental)
                    all_data[0].Add(exp);
        }


        #endregion

        #region Helpers
        public static IEnumerable<Control> GetControls(Control c)
        {
            return new[] { c }.Concat(c.Controls.OfType<Control>().SelectMany(x => GetControls(x)));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                //saveToolStripButton.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                loadExp_Btn.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.N))
            {
                //newToolStripButton.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        public static double dParser(string t)
        {
            if (double.TryParse(t, out double d)) return d;

            return double.NaN;
        }

        public static double txt_to_d(TextBox txtBox)
        {
            if (double.TryParse(txtBox.Text, out double d)) return d;

            return double.NaN;
        }

        private int iParser(string t)
        {
            // will reurn 0 on error
            if (int.TryParse(t, out int i)) return i;
            return i;
        }

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
                else if (ColumnToSort == 0 || ColumnToSort == 4 || ColumnToSort == 1)
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
                int compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
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

        public long estimate_memory(object o)
        {
            // estimates memory size of objects. Returns size in MB
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }

            return size / 1048576;
        }

        private void display_objects_memory()
        {
            Debug.WriteLine("Memory of experimental: " + estimate_memory(experimental).ToString());
            Debug.WriteLine("Memory of all_data: " + estimate_memory(all_data).ToString());
            Debug.WriteLine("Memory of all_data_aligned: " + estimate_memory(all_data_aligned).ToString());
        }

        private bool string_to_bool(string str)
        {
            if (str == "True") return true;
            else return false;
        }

        private int FindClosestPoint(double val, List<Double> list)
        {
            int max = list.Count;
            int min = 0;
            int index = max / 2;

            while (max - min > 1)
            {
                if (val < list[index])
                    max = index;
                else if (val > list[index])
                    min = index;
                else
                    return index;

                index = (max - min) / 2 + min;
            }

            if (max != list.Count &&
                    Math.Abs(list[max] - val) < Math.Abs(list[min] - val))
            {
                return max;
            }
            return min;
        }

        #endregion

        #region SAVE-LOAD list fragments
        
        private void saveList(List<int> fragToSave)
        {
            SaveFileDialog save = new SaveFileDialog() { Title = "Save fitted list", FileName = "fragment ", Filter = "Data Files (*.fit)|*.fit", DefaultExt = "fit", OverwritePrompt = true, AddExtension = true };

            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                file.WriteLine("Mode:\tFitted List");
                file.WriteLine("AA Sequence:\t" + Peptide);
                file.WriteLine("Fitted isotopes:\t" + fragToSave.Count());
                file.WriteLine("[m/z[Da]\tIntensity]");
                file.WriteLine();
                file.WriteLine("Name\tIon Type\tIndex\t->to Index\tCharge\tm/z\tMax Intensity\tFactor\tPPM Error\tInput Formula\tAdduct\tDeduct\tColor\tResolution");
                //file.WriteLine("Name:\tExp");
                //foreach (double[] p in Form2.selected_all_data[0]) file.WriteLine(p[0] + "\t" + p[1]);
                //file.WriteLine();
                if(IonDraw.Count>0) IonDraw.Clear();
                foreach (int indexS in fragToSave)
                {
                    Form2.Fragments2[indexS - 1].Fixed = true;
                    file.WriteLine(Form2.Fragments2[indexS - 1].Name+ "\t" + Form2.Fragments2[indexS - 1].Ion_type+"\t" + Form2.Fragments2[indexS - 1].Index + "\t" + Form2.Fragments2[indexS - 1].IndexTo + "\t"+ Form2.Fragments2[indexS - 1].Charge + "\t" + Form2.Fragments2[indexS - 1].Mz + "\t" + Form2.Fragments2[indexS - 1].Max_intensity + "\t"+ Form2.Fragments2[indexS - 1].Factor + "\t"+ Form2.Fragments2[indexS - 1].PPM_Error + "\t"+ Form2.Fragments2[indexS - 1].InputFormula + "\t"+ Form2.Fragments2[indexS - 1].Adduct + "\t"+ Form2.Fragments2[indexS - 1].Deduct + "\t" + Form2.Fragments2[indexS - 1].Color.ToUint() + "\t" + Form2.Fragments2[indexS - 1].Resolution);
                    IonDraw.Add(new ion() {Name= Form2.Fragments2[indexS - 1].Name, Mz = Form2.Fragments2[indexS - 1].Mz, PPM_Error= Fragments2[indexS - 1].PPM_Error, Charge =Fragments2[indexS - 1].Charge, Index=Int32.Parse( Fragments2[indexS - 1].Index),IndexTo=Int32.Parse(Fragments2[indexS - 1].IndexTo), Ion_type= Fragments2[indexS - 1].Ion_type,Max_intensity= Fragments2[indexS - 1].Max_intensity* Fragments2[indexS - 1].Factor, Color= Fragments2[indexS - 1].Color.ToColor()});
                    if (IonDraw.Last().Ion_type.StartsWith("x") || IonDraw.Last().Ion_type.StartsWith("y") || IonDraw.Last().Ion_type.StartsWith("z")||IonDraw.Last().Ion_type.StartsWith("(x") || IonDraw.Last().Ion_type.StartsWith("(y") || IonDraw.Last().Ion_type.StartsWith("(z"))
                    {
                        IonDraw.Last().SortIdx = Peptide.Length - IonDraw.Last().Index;
                    }
                    else
                    {
                        IonDraw.Last().SortIdx = IonDraw.Last().Index;
                    }
                }
                populate_fragtypes_treeView();
                file.Flush(); file.Close(); file.Dispose();
                MessageBox.Show("completed");
            }
        }
        private void loadList()
        {            
            OpenFileDialog loadData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";
            loadData.Title = "Load fitting data"; loadData.FileName = "";
            loadData.Filter = "data file|*.fit|All files|*.*";
            List<ChemiForm> fitted_chem = new List<ChemiForm>();
            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(loaded_lists);
                sb.AppendLine(Path.GetFileNameWithoutExtension(loadData.FileName));
                loaded_lists = sb.ToString();
                show_files_Btn.ToolTipText = loaded_lists;
                is_loading = true;  // performance
                fullPath = loadData.FileName;

                #region UI & data                 
                fit_Btn.Enabled = true; fit_sel_Btn.Enabled = true;
                plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;
                saveFit_Btn.Enabled = true;
                loadExp_Btn.Enabled = true;
                loadFit_Btn.Enabled = false;                         
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
                    string[] str = new string[15];
                    try
                    {
                        str = lista[j].Split('\t');

                        if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z")) continue; // comments
                        else if (lista[j].StartsWith("Mode")) continue; // to be implemented
                        else if (lista[j].StartsWith("AA")) { Peptide = str[1];  }                        
                        else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                        else if (lista[j].StartsWith("Name")) continue;
                        else
                        {
                            int[] check_mate= check_for_duplicates(str[0], dParser(str[7]));                            
                            if (check_mate[0]!=3)
                            {
                                // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                                isotope_count++;
                                if (isotope_count == 0 && all_data.Count == 0)//in case experimental is not added yet
                                {
                                    all_data.Add(new List<double[]>());
                                    if (custom_colors.Count > 0) custom_colors[0] = exp_color;
                                    else custom_colors.Add(exp_color);
                                }
                                f++;
                                fitted_chem.Add(new ChemiForm
                                {
                                    InputFormula =str[9],
                                    Adduct = str[10],
                                    Deduct = str[11],
                                    Multiplier = 1,
                                    Mz = str[5],
                                    Ion = string.Empty,
                                    Index = str[2],
                                    IndexTo = str[3],
                                    Error = false,
                                    Elements_set = new List<Element_set>(),
                                    Iso_total_amount = 0,
                                    Monoisotopic = new CompoundMulti(),
                                    Points = new List<PointPlot>(),
                                    Machine = string.Empty,
                                    Resolution = double.Parse(str[13]),
                                    Combinations = new List<Combination_1>(),
                                    Profile = new List<PointPlot>(),
                                    Centroid = new List<PointPlot>(),
                                    Combinations4 = new List<Combination_4>(),
                                    FinalFormula = string.Empty,
                                    Color=new OxyColor(),
                                    Charge = Int32.Parse(str[4]),
                                    Ion_type = str[1],
                                    PPM_Error=dParser(str[8]),
                                    PrintFormula= str[9],
                                    Name= str[0],
                                    Radio_label= string.Empty,         
                                    Factor= dParser(str[7]),
                                    Fixed=true,
                                    Max_man_int = 0
                                });
                                if (UInt32.TryParse(str[12], out uint result_color)) fitted_chem.Last().Color = OxyColor.FromUInt32(result_color);
                                IonDraw.Add(new ion() { Name = str[0], Mz = str[5], PPM_Error= dParser(str[8]), Charge = Int32.Parse(str[4]), Index = Int32.Parse(str[2]), IndexTo = Int32.Parse(str[3]), Ion_type = str[1], Max_intensity =dParser(str[6])* dParser(str[7]), Color = fitted_chem.Last().Color.ToColor() });
                                if (str[1].StartsWith("x") || str[1].StartsWith("y") || str[1].StartsWith("z")|| str[1].StartsWith("(x") || str[1].StartsWith("(y") || str[1].StartsWith("(z")) IonDraw.Last().SortIdx = Peptide.Length - IonDraw.Last().Index;
                                else IonDraw.Last().SortIdx = IonDraw.Last().Index;
                            }
                        }                       
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                    arrayPositionIndex++;
                }

                Thread envipat_fitted = new Thread(() => calculate_fragment_properties(fitted_chem));
                envipat_fitted.Start();               
                refresh_iso_plot();
                is_loading = false;
                fitted_results.Clear();
                if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
                if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
                fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            }
        }
        private int[] check_for_duplicates(string name,double factor)
        {
            int[] a = new int[] {1,1};
            if(Fragments2.Count<1) return new int[] { 1, 1 };
            foreach (FragForm fra in Fragments2)
            {
                if (fra.Name==name && fra.Factor==factor) return new int[] { 3, 1 }; 
                if (fra.Name==name) return new int[] { 2, Fragments2.IndexOf(fra) }; 
            }    
            return new int[] { 1, 1 };
        }
        private void clearList()
        {
            plotExp_chkBox.Checked = false; plotCentr_chkBox.Checked = false; plotFragProf_chkBox.Checked = false; plotFragCent_chkBox.Checked = false;
             loaded_lists = ""; show_files_Btn.ToolTipText = "";
            if (Fragments2.Count == 0 || all_data.Count<2) return;
            if (IonDraw.Count > 0) IonDraw.Clear();
            selectedFragments.Clear();
            Fragments2.Clear();
            plotFragProf_chkBox.Enabled = false; plotFragCent_chkBox.Enabled = false;
            custom_colors.Clear();custom_colors.Add(exp_color);
            aligned_intensities.Clear();
            all_data_aligned.Clear();
            fitted_results.Clear();
            if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
            fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            powerSet.Clear();powerSet_distroIdx.Clear();
            summation.Clear();residual.Clear();
            all_data.RemoveRange(1, all_data.Count - 1);
            if (frag_tree != null) { frag_tree.Nodes.Clear(); frag_tree.Visible = false; }
            if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Visible = false; fragStorage_Lbl.Visible = false; }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            fit_sel_Btn.Enabled = false; fit_Btn.Enabled =  false; fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            Initialize_Oxy();
            initialize_tabs();
            factor_panel.Controls.Clear();
        }
        private void saveListBtn1_Click(object sender, EventArgs e)
        {
            saveList(selectedFragments);
        }
        private void loadListBtn1_Click(object sender, EventArgs e)
        {
            loadList();            
        }
        private void clearListBtn1_Click(object sender, EventArgs e)
        {
            clearList();
        }
        #endregion

        #region FILTER list fragments
        private void frag_sort_Btn_Click(object sender, EventArgs e)
        {
            params_form();
        }
        private void refresh_frag_Btn_Click(object sender, EventArgs e)
        {
            int initial_count = Fragments2.Count;            
            int rr = 0;
            if (Fragments2.Count>0)
            {
                while (rr < Fragments2.Count)
                {
                    if (!decision_algorithm2(Fragments2[rr])) { Fragments2.RemoveAt(rr); }
                    else { rr++; }
                }
                // thread safely fire event to continue calculations
                Invoke(new Action(() => OnEnvelopeCalcCompleted()));
            }
            if (initial_count == Fragments2.Count) { MessageBox.Show("Fragment list hasn't changed."); return; }
            else
            {
                fitted_results.Clear();
                if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
                if (fit_tree != null)
                {
                    selectedFragments.Clear(); fit_tree.Dispose(); MessageBox.Show("Fragment list have changed. Fit results are disposed.");                    
                }
                fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            }                  
        }
        private bool decision_algorithm2(FragForm fra)
        {
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;
            // deceide how many peaks will be involved in the selection process
            // results = {[resol1, ppm1], [resol2, ppm2], ....}
            List<double[]> results = new List<double[]>();

            int total_peaks = fra.Centroid.Count;
            int contrib_peaks = 0;
            int rule_idx = Array.IndexOf(selection_rule, true);

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
                double[] tmp = ppm_calculator(fra.Centroid[i].X);

                if (tmp[0] < ppmError) results.Add(tmp);
                else { fragment_is_canditate = false; break; }
            }

            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate) { fra.Profile.Clear(); return false; }

            //fra.PPM_Error = results.Average(p => p[0]);
            //fra.Resolution = (float)results.Average(p => p[1]);

            return fragment_is_canditate;
        }
        #endregion


        #region FORM 9 fragment calculator
        private void fragCalc_Btn_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool open = false;
            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "Form9")
                {
                    open = true; frm.BringToFront(); break;
                }
            }
            if (!open)
            {
                Form9 frag_Calc_form = new Form9(this);
                frag_Calc_form.Show();
            }
            else
            {

                return;
            }
        }
        public void recalc_frm9()
        {
            recalculate_all_data_aligned();
        }
        public void refresh_frm9()
        {
            refresh_iso_plot();
        }
        public void add_frag_frm9()
        {
            selectedFragments.Clear();
            Invoke(new Action(() => OnEnvelopeCalcCompleted()));
            plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;

            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed. Fit results are disposed."); }
        }
        private void styleFormatBtn_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10(this);
            frm10.ShowDialog();
        }
        public void ending_frm9()
        {
            all_data.RemoveRange(1, all_data.Count - 1); custom_colors.RemoveRange(1, custom_colors.Count - 1);
            add_fragments_to_all_data();
            recalculate_all_data_aligned();
        }


        #endregion

        #region FORM 10 plot settings
        public void oxy_changes()
        {
            iso_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid;
            iso_plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid;
            iso_plot.Model.Axes[0].TickStyle = Y_tick;
            iso_plot.Model.Axes[0].IntervalLength = y_interval;
            iso_plot.Model.Axes[0].StringFormat = y_format + y_numformat;

            iso_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid;
            iso_plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid;
            iso_plot.Model.Axes[1].TickStyle = X_tick;
            iso_plot.Model.Axes[1].IntervalLength = x_interval;
            iso_plot.Model.Axes[1].StringFormat = x_format + x_numformat;

            res_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid;
            res_plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid;
            res_plot.Model.Axes[0].TickStyle = Y_tick;
            res_plot.Model.Axes[0].IntervalLength = y_interval;
            res_plot.Model.Axes[0].StringFormat = y_format + y_numformat;

            res_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid;
            res_plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid;
            res_plot.Model.Axes[1].TickStyle = X_tick;
            res_plot.Model.Axes[1].IntervalLength = x_interval;
            res_plot.Model.Axes[1].StringFormat = x_format + x_numformat;

            invalidate_all();
        }
        #endregion

        #region load MS/MS file
        private void loadFF_Btn_Click(object sender, EventArgs e)
        {
            loadFF_Btn.Enabled = false;
            if (String.IsNullOrEmpty(Peptide)) { MessageBox.Show("First insert Sequence. Then load a fragment file.", "No sequence found."); loadFF_Btn.Enabled = true; return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure you have first inserted the correct sequence?", "Sequence Editor", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                Form16 frm16 = new Form16(this);
                frm16.ShowDialog();
            }
            try
            {
                calc_FF = true;
                clearList();
                import_fragments();
                if (ChemFormulas.Count > 0)
                {
                    Form14 frm14 = new Form14(this);
                    frm14.Show();
                    frm14.FormClosed += (s, f) => { if (calc_form14) { calc_form14 = false; FF_sequence_a(); } };
                }
                else
                {
                    calc_FF = false;
                }
            }
            catch
            {
                MessageBox.Show("Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading Fragments");
            }

            finally
            {
                loadFF_Btn.Enabled = true;
            }
        }

        public void FF_sequence_a()
        {
            // this the main sequence after loadind data
            // 1. select fragments according to UI
            Fragments2.Clear();
            selectedFragments.Clear();
            custom_colors.Clear();
            custom_colors.Add(exp_color);
            sw1.Reset(); sw1.Start();
            List<ChemiForm> selected_fragments = new List<ChemiForm>();
            foreach (ChemiForm chem in ChemFormulas)
            {
                selected_fragments.Add(chem.DeepCopy());
            }
            if (selected_fragments == null) return;
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            calculate_fragments_resolution(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments2.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties(selected_fragments));
            envipat_properties.Start();
            plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;
        }
        private bool decision_algorithmFF(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;

            // deceide how many peaks will be involved in the selection process
            // results = {[resol1, ppm1], [resol2, ppm2], ....}
            List<double[]> results = new List<double[]>();

            int total_peaks = cen.Count;

            double[] tmp = ppm_calculator(cen[0].X);

            if (tmp[0] < ppmErrorFF) results.Add(tmp);
            else
            {
                results.Add(tmp);
                fragment_is_canditate = false;
            }


            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate && !ignore_ppm) { chem.Profile.Clear(); chem.Points.Clear(); return false; }

            chem.PPM_Error = results.Average(p => p[0]);
            chem.Resolution = (double)results.Average(p => p[1]);

            return fragment_is_canditate;
        }
        #endregion


        #region UI
        private void Initialize_UI()
        {
            plotExp_chkBox.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            plotCentr_chkBox.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            plotFragCent_chkBox.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            plotFragProf_chkBox.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            fitMax_Box.Click += (s, e) => { fitMax_Box.SelectAll(); };
            fitMin_Box.Click += (s, e) => { fitMin_Box.SelectAll(); };
            fitMin_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true, false, true); };
            fitMax_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true, false, true); };
            //fitStep_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) { step_Fitting(); if (!is_loading && !is_calc) { if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); } refresh_iso_plot(); } } };
            //step_rangeBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) { step_Fitting(); if (!is_loading && !is_calc) { if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); } refresh_iso_plot(); } } };
            mzMin_Box.KeyPress += (s, e) => { if (e.KeyChar == (char)13) mzMax_Box.Focus(); };
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();
            machine_listBox.SelectedIndex = 2;
            ContextMenu ctxMn1 = new ContextMenu() { };
            MenuItem copyRow = new MenuItem("Copy items", copyRowList);
            MenuItem colorSelection = new MenuItem("Fragment color", colorSelectionList);
            ctxMn1.MenuItems.AddRange(new MenuItem[] { copyRow, colorSelection });
            frag_listView.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right) { ContextMenu = ctxMn1; } };
            filename_txtBx.Text = file_name;
            displayPeakList_btn.Click += (s, e) => { display_peakList(); };
            progress_display_init();
            disp_a.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_b.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_c.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_x.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_y.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_z.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_internal.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            disp_a.Checked=true;
            disp_b.Checked = true;
            disp_c.Checked = true;
            disp_x.Checked = true;
            disp_y.Checked = true;
            disp_z.Checked = true;
            disp_internal.Checked = true;

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
            var pngExporter = new PngExporter { Width = iso_plot.Width, Height = iso_plot.Height, Background = OxyColors.White ,Resolution=200};

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
            foreach (int i in addin_lstBox.CheckedIndices)
            {
                addin_lstBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in dvw_lstBox.CheckedIndices)
            {
                dvw_lstBox.SetItemCheckState(i, CheckState.Unchecked);
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
        private void exportImage_Btn_Click(object sender, EventArgs e)
        {
            export_copy_plot(false, iso_plot);
        }
        private void copyImage_Btn_Click(object sender, EventArgs e)
        {
            export_copy_plot(true,iso_plot);
        }
        private void export_copy_plot(bool copy,PlotView plot)
        {                        
            if (copy)
            {
                var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Height, Background = OxyColors.White, Resolution = 200 };
                var bitmap = pngExporter.ExportToBitmap(plot.Model);
                Clipboard.SetImage(bitmap);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("The default image format is png. Do you want svg format?", "File Format", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Cancel) return;
                else if (dialogResult == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog() { Title = "Save plot image", FileName = "", Filter = "image file|*.svg|all files|*.*", OverwritePrompt = true, AddExtension = true };
                    var svgExporter = new OxyPlot.WindowsForms.SvgExporter { Width = plot.Width, Height = plot.Height };
                    if (save.ShowDialog() == DialogResult.OK) { svgExporter.ExportToFile(plot.Model, save.FileName); }
                }
                else
                {
                    SaveFileDialog save = new SaveFileDialog() { Title = "Save plot image", FileName = "", Filter = "image file|*.png|all files|*.*", OverwritePrompt = true, AddExtension = true };
                    var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Height, Background = OxyColors.White, Resolution = 200 };
                    if (save.ShowDialog() == DialogResult.OK) { pngExporter.ExportToFile(plot.Model, save.FileName); }
                }
            }
        }
        private void saveListBtn11_Click(object sender, EventArgs e)
        {
            saveList(selectedFragments.ToList());
        }

        private void loadListBtn11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure? When 'Fragment list' changes 'Fit results' are automatically disposed.", "Load Fragment List", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loadList();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void clearListBtn11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Clear Fragment List", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                clearList();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void toggle_toolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (frag_tree != null)
            {
                if (toggle_toolStripButton.Checked)
                {
                    frag_tree.ExpandAll();
                }
                else
                {
                    frag_tree.CollapseAll();
                }
            }
        }

        private void checkall_Frag_Btn_Click(object sender, EventArgs e)
        {
            if (frag_tree != null)
            {
                frag_tree.BeginUpdate();
                block_plot_refresh = true; block_fit_refresh = true;
                foreach (TreeNode node in frag_tree.Nodes)
                {
                    node.Checked = true; 
                }
                block_plot_refresh = false; block_fit_refresh = false;
                frag_tree.EndUpdate();
                refresh_iso_plot();
            }
        }

        private void uncheckall_Frag_Btn_Click(object sender, EventArgs e)
        {
            if(fit_tree!=null) uncheck_all(fit_tree, false);
            else uncheckall_Frag();
        }
        private void uncheckall_Frag()
        {
            if (frag_tree != null)
            {
                frag_tree.BeginUpdate();
                block_plot_refresh = true; block_fit_refresh = true;
                foreach (TreeNode node in frag_tree.Nodes)
                {
                    node.Checked = false;
                }
                block_plot_refresh = false; block_fit_refresh = false;
                frag_tree.EndUpdate();
                refresh_iso_plot();
            }
        }
        private void clear_toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Clear all data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                plotExp_chkBox.Checked = false;plotCentr_chkBox.Checked = false;plotFragCent_chkBox.Checked = false;plotFragProf_chkBox.Checked = false;
                loaded_lists = ""; show_files_Btn.ToolTipText = "";                
                displayPeakList_btn.Enabled = false;
                Peptide = String.Empty; peptide_textBox1.Text = "";
                insert_exp = false;
                plotExp_chkBox.Enabled = false; plotCentr_chkBox.Enabled = false; plotFragProf_chkBox.Enabled = false; plotFragCent_chkBox.Enabled = false; saveFit_Btn.Enabled = false;
                loadMS_Btn.Enabled = true; loadFit_Btn.Enabled = true;
                clearCalc_Btn.Enabled = false; calc_Btn.Enabled = false; fragCalc_Btn.Enabled = false; fitMin_Box.Enabled = false; fitMax_Box.Enabled = false;
                fitMin_Box.Text = null; fitMax_Box.Text = null; fitStep_Box.Text = null; step_rangeBox.Text = null;
                Fitting_chkBox.Checked = false;
                Fitting_chkBox.Enabled = false; fitStep_Box.Enabled = false;
                Fragments2.Clear();ChemFormulas.Clear();
                selectedFragments.Clear();
                frag_listView.Items.Clear();
                UncheckAll_calculationPanel();
                 resolution_Box.Text = null;
                machine_listBox.ClearSelected();
                machine_listBox.SelectedIndex = 2;
                loadExp_Btn.Enabled = true;
                selected_window = 1000000;
                bigPanel.Controls.Clear();
                factor_Box.Text = null;
                candidate_fragments = 1;
                mzMax_Box.Enabled = false; mzMin_Box.Enabled = false; mzMax_Label.Enabled = false; mzMin_Label.Enabled = false; chargeMax_Box.Enabled = false; chargeMin_Box.Enabled = false; chargeAll_Btn.Enabled = false;
                idxPr_Box.Enabled = false; idxTo_Box.Enabled = false; idxFrom_Box.Enabled = false; resolution_Box.Enabled= false; machine_listBox.Enabled = false;
                fit_sel_Btn.Enabled = false; saveWd_Btn.Enabled = false;
                windowList.Clear();
                mark_neues = false; loaded_window = false;
                neues = 0;               
                Form4.active = false;
                if (frag_tree != null) { frag_tree.Nodes.Clear(); frag_tree.Visible = false; }
                if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Visible = false; fragStorage_Lbl.Visible = false; }
                if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
                factor_panel.Controls.Clear();
                //other tabs
                if (IonDraw.Count > 0) IonDraw.Clear();
                if (IonDrawIndex.Count > 0) IonDrawIndex.Clear();
                if (IonDrawIndexTo.Count > 0) IonDrawIndexTo.Clear();
                reset_all();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }            
        }
        private void show_files_Btn_Click(object sender, EventArgs e)
        {

        }
        private void fragPlotLbl_chkBx_Click(object sender, EventArgs e)
        {
            if (fragPlotLbl_chkBx.Checked) { cursor_chkBx.Checked = false; refresh_iso_plot(); }
            else if (fragPlotLbl_chkBx2.Checked) { iso_plot.Model.Annotations.Clear(); invalidate_all(); refresh_iso_plot(); }
            else { iso_plot.Model.Annotations.Clear(); invalidate_all(); }
        }

        private void fragPlotLbl_chkBx2_Click(object sender, EventArgs e)
        {
            if (fragPlotLbl_chkBx2.Checked) { cursor_chkBx.Checked = false; refresh_iso_plot(); }
            else if (fragPlotLbl_chkBx.Checked) { iso_plot.Model.Annotations.Clear(); invalidate_all(); refresh_iso_plot(); }
            else { iso_plot.Model.Annotations.Clear(); invalidate_all(); }
        }

        private void rel_res_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            refresh_iso_plot();
        }
        private void extractPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plotview_rebuild();
        }
        private void seqBtn_Click(object sender, EventArgs e)
        {
            Form16 frm16 = new Form16(this);
            frm16.ShowDialog();
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
            initialize_tabs();

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
            file_name = "";
            if (all_fitted_results!=null) {all_fitted_results.Clear(); all_fitted_sets.Clear();}
            fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            fit_color = OxyColors.Black; exp_color = OxyColors.Black.ToColor().ToArgb();
            fit_style = LineStyle.Dot;exper_style = LineStyle.Solid;frag_style = LineStyle.Solid;
            exp_width = 1;frag_width = 2;fit_width = 1;
    }
        private List<double> get_UI_intensities2(int[] subSet, double max = 1.0, bool optimizer_default = false, bool window = false, int w = 1)
        {
            //(Μ)to subset einai to to_plot se array to opoio perieei touw indexes tvn epilegmenvn fragments

            // optimizer_default = true is for the optimizer
            // will return some default values in case factor textbox is empty or wrong

            // optimizer_default = false is for the normal replot
            // will return whatever is on textBox or 0.0 on wrong value

            List<double> UI_intensities = new List<double>();

            for (int i = 0; i < subSet.Length; i++)
            {
                int index = subSet[i];
                //pairnei th timh tou ekastote factor pou oristhke gia kathe fragment
                if (window)
                {
                    index = windowList[w].Checked_mono_fragments[index - 1];
                }
                double tmpD = 1.0;
                if (index != 0) { tmpD = Fragments2[index - 1].Factor; }
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
        private void select_from_experimental(string start_txt, string stop_txt, bool text_box_entry = false, bool later = false, bool fix = false)
        {
            // will seach for the closest experimental mass to the input value and refresh distribution 0.
            double start = dParser(start_txt) - step_range;
            double end = dParser(stop_txt) + step_range;

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
            for (int i = start_idx; i < end_idx + 1; i++)
            {
                selected_all_data[0].Add(new double[] { experimental[i][0], experimental[i][1] });
            }

            experimental_to_all_data(true); // WHY?

            if (fix)
            {
                max_exp = selected_all_data[0].Select(d => d[1]).Max();
                if (Fragments2.Count() > 0) refix_data_to_max_exp();
            }
            if (later == false && recalc)
            {
                recalculate_all_data_aligned();
                //refresh_iso_plot();
                recalc = false;
            }

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

        #endregion

        #region Fitting + Windows
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
                pnl.Click += (s, e) => { selected_window = pnl.TabIndex; window_colors(pnl.TabIndex); pnl.BackColor = Color.LightSteelBlue; window_graph(pnl.TabIndex); highlight_selected(pnl.TabIndex); };
                Label window_tab = new Label() { TabIndex = 1000, Dock = DockStyle.Top, Text = windowList[j].Code.ToString(), Font = new Font(DefaultFont, FontStyle.Bold), AutoSize = true };
                pnl.Controls.Add(window_tab);
                pnl.MouseEnter += (s, e) => { pnl.Focus(); };
                ContextMenu ctxMn3 = new ContextMenu() { };
                MenuItem copyRow = new MenuItem("Copy fitted fragments", copyRowList);
                ctxMn3.MenuItems.AddRange(new MenuItem[] { copyRow });
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
                    item.BackColor = Color.LightSteelBlue;
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
            iso_plot.Model.Annotations.Add(new RectangleAnnotation { MinimumX = min_border, MaximumX = max_border, Fill = OxyColor.FromAColor(99, OxyColors.Gainsboro) });
            invalidate_all();
        }
        private void window_colors(int w)
        {
            for (int p = 0; p < window_count; p++)
            {
                if (p != w) { Panel pnlk = GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == p); if (pnlk != null) { pnlk.BackColor = Color.White; pnlk.Invalidate(); } }

            }

        }
        private int[] check_windows_borders(int starting, int ending, List<FragForm> Fragments3)
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
                if (check_amount > 5) { array = new int[] { item_code, check_amount }; return array; }
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
            array[1] = check_amount;
            return array;
        }

        private void find_window_checked_fragments(int window)
        {
            windowList[window].Fragments.Clear();
            windowList[window].Checked_mono_fragments.Clear();
            ListView.CheckedListViewItemCollection checkedItems = frag_listView.CheckedItems;
            foreach (ListViewItem item in checkedItems)
            {
                double mass = double.Parse(item.SubItems[1].Text, NumberStyles.AllowDecimalPoint);
                int item_code = Int32.Parse(item.SubItems[5].Text, NumberStyles.Integer);
                if (mass >= all_data[0][windowList[window].Starting][0] && mass <= all_data[0][windowList[window].Ending][0])
                {
                    windowList[window].Fragments.Add(item_code); windowList[window].Checked_mono_fragments.Add(item_code);
                }
                else if (all_data[item_code].Last()[0] >= all_data[0][windowList[window].Starting][0] && all_data[item_code].Last()[0] <= all_data[0][windowList[window].Ending][0])
                {
                    windowList[window].Fragments.Add(item_code);
                }
            }
            if (window > 1) check_mono_duplicate(window);
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
            if (windowList[w].Checked_mono_fragments.Count == 0) { return; }
            if (windowList[w - 1].Checked_mono_fragments.Count == 0) { return; }
            List<int> list1 = windowList[w - 1].Checked_mono_fragments;
            List<int> list2 = windowList[w].Checked_mono_fragments;
            List<int> rem = new List<int>();

            for (int v = 0; v < list1.Count; v++)
            {
                for (int q = 0; q < list2.Count; q++)
                {
                    if (list1[v] == list2[q])
                    {
                        rem.Add(q); break;
                    }
                    else if (list1[v] < list2[q])
                    {
                        break;
                    }
                }
            }
            if (rem.Count > 0)
            {
                foreach (int index in rem)
                {
                    windowList[w].Checked_mono_fragments.RemoveAt(index);
                }
            }
        }
        private void refresh_fit_results(List<double[]> fitted_results)
        {
            if (selectedFragments.Count < 1) { MessageBox.Show("Select at least 1 fragment to perform fitting!"); return; }

            if (window_count == 1)//praktika o kvdikas opvw htan prin
            {
                // 1. clear previous results (UI ctrls and chart)            
                try { bigPanel.Controls.Clear(); }
                catch { }

                Panel pnl = new Panel() { Location = new Point(5, 40), Size = new Size(200, 600), AutoScroll = true };
                pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
                                                                //grpBox.Controls.Add(pnl);

                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
                // we have to convert powerSet to the actual index number of each fragment!!!
                //powerSet_to_distroIdx(selectedFragments.OrderBy(p => p).ToList());
                for (int i = 0; i < fitted_results.Count; i++)
                {
                    if (i > 200) { break; }
                    //double[] fit_info in fitted_results
                    Label tmp_lbl = new Label() { TabIndex = i, Location = new Point(5, (i + 1) * 15), AutoSize = true };
                    string txt = "";

                    foreach (int value in powerSet[i]) txt += value.ToString() + " ";
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
                try { pnl = GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == selected_window); }
                catch { MessageBox.Show("Error!Panel not found!"); return; }
                //Panel pnl = new Panel() { Size = new Size(50, 200), AutoScroll = true, BorderStyle = BorderStyle.FixedSingle, TabIndex = selected_window };
                //pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
                try { pnl.Controls.Clear(); }
                catch { }
                Label window_tab = new Label() { TabIndex = 1000, Dock = DockStyle.Top, Text = windowList[pnl.TabIndex].Code.ToString(), Font = new Font(DefaultFont, FontStyle.Bold), AutoSize = true };
                pnl.Controls.Add(window_tab);
                // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
                // we have to convert powerSet to the actual index number of each fragment!!!
                powerSet_to_distroIdx(windowList[selected_window].Checked_mono_fragments, true);
                //for (int i = 0; i < fitted_results.Count; i++)
                for (int i = 0; i < fitted_results.Count; i++)
                {
                    if (i > 200) { break; }
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
            if (window_count == 1)
            {
                // 1. adjust corresponding fragment heights
                double[] intensities = fitted_results[tmp_lbl.TabIndex];
                int[] distroIdxs = powerSet[tmp_lbl.TabIndex];
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
                if (refresh_all == false) refresh_iso_plot();

            }
        }
        private void powerSet_to_distroIdx(List<int> distro_idxs, bool window = false)
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
        public class lastElement : IComparer
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare((y as double[]).Last(), (x as double[]).Last()));
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
                List<int> sel_idx = new List<int>();
                //sel_idx.RemoveAt(0);
                int panel_count = window_count;
                //try { panel_count = GetControls(bigPanel).OfType<Panel>().Count(); }
                //catch { }
                if (panel_count > 0)
                {
                    for (int p = 0; p < panel_count; p++)
                    {
                        if (bigPanel.Controls[p].Focused)
                        {
                            sel_idx = windowList[p].Checked_mono_fragments;
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
                                    if (Fragments2[item_code - 1].Factor != 0)
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

                if (e.Item.Checked == true) selectedFragments.Add(item_code);
                else selectedFragments.Remove(item_code);

                selectedFragments = selectedFragments.OrderBy(p => p).ToList();
                Fragments2[item_code - 1].To_plot = e.Item.Checked;

                if (plot_rem_Btns == false) refresh_iso_plot();
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
                        item.SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
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
                        frag_listView.SelectedItems[0].SubItems[6].Text = (Fragments2[item_code - 1].Factor * Fragments2[item_code - 1].Fix * Fragments2[item_code - 1].Centroid[0].Y).ToString();
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
        private void Fitting_chkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            refresh_iso_plot();
        }
        private void loadFit_Btn_Click(object sender, EventArgs e)
        {
            reset_all();
            experimental.Clear();
            Fragments2.Clear();
            ChemFormulas.Clear();
            selectedFragments.Clear();
            windowList.Clear();
            selected_all_data.Clear();     
            UncheckAll_calculationPanel();
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
                UncheckAll_calculationPanel();
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
                        else if (lista[j].StartsWith("AA")) { Peptide = str[1];  }
                        else if (lista[j].StartsWith("Window")) { loaded_window = true; fit_sel_Btn.Enabled = true; windowList.Add(new WindowSet() { Code = Int32.Parse(str[1], NumberStyles.Integer), Aligned = new List<double[]>(), All_data = new List<List<double[]>>(), Checked_mono_fragments = new List<int>(), Ending = new int(), Fitted = new List<double[]>(), Fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Starting = new int() }); }
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
                                if (custom_colors.Count > 0) custom_colors[0] = exp_color;
                                else custom_colors.Add(exp_color);
                            }
                            else if (isotope_count == 0)//experimental
                            {
                                all_data.Add(new List<double[]>());
                                if (custom_colors.Count > 0) custom_colors[0] = exp_color;
                                else custom_colors.Add(exp_color);
                            }
                            else//fragments
                            {
                                f++;
                                Fragments2.Add(new FragForm() { Name = str[1], Centroid = new List<PointPlot>(), Factor = 1.0, Fix = 1.0, Charge = 0, Mz = "", Radio_label = "", ListName = new string[4], Color = new OxyColor(), To_plot = false, Counter = f, Fixed = false });
                                all_data.Add(new List<double[]>());
                                if (loaded_window == true) { windowList.Last().Mono_fragments.Add(f); }
                            }
                        }
                        else if (lista[j].StartsWith("Factor")) { Fragments2.Last().Factor = dParser(str[1]); }
                        else if (lista[j].StartsWith("Fix")) { Fragments2.Last().Fix = dParser(str[1]); }
                        else if (lista[j].StartsWith("Cen")) { Fragments2.Last().Centroid.Add(new PointPlot { Y = dParser(str[2]), X = dParser(str[1]) }); }
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
                // post load actions                                
                recalculate_all_data_aligned();
                //refresh_iso_plot();
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
                //refresh_iso_plot();

            }

        }
        private void new_Btn_Click(object sender, EventArgs e)
        {
            reset_all();
            Peptide = String.Empty; peptide_textBox1.Text = "";
            insert_exp = false;
            plotExp_chkBox.Enabled = false; plotCentr_chkBox.Enabled = false; plotFragProf_chkBox.Enabled = false; plotFragCent_chkBox.Enabled = false;
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
            frag_listView.Items.Clear();
            UncheckAll_calculationPanel();
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
            fit_sel_Btn.Enabled = false;
            neues = 0;
            mark_neues = false;
            Form4.active = false;
            if (frag_tree != null) { frag_tree.Nodes.Clear(); frag_tree.Visible = false; }
            if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Visible = false; fragStorage_Lbl.Visible = false; }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            factor_panel.Controls.Clear();
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
                UncheckAll_calculationPanel();
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
                fit_sel_Btn.Enabled = true;
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
                        else if (lista[j].StartsWith("AA")) { Peptide = str[1]; }
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
                                if (custom_colors.Count > 0) custom_colors[0] = exp_color;
                                else custom_colors.Add(exp_color);
                            }
                            else if (isotope_count == 0)//experimental
                            {
                                all_data.Add(new List<double[]>());
                                if (custom_colors.Count > 0) custom_colors[0] = exp_color;
                                else custom_colors.Add(exp_color);
                            }
                            else//fragments
                            {
                                f++;
                                Fragments2.Add(new FragForm() { Name = str[1], Factor = 1.0, Fix = 1.0, Charge = 0, Mz = "", Radio_label = "", ListName = new string[4], Color = new OxyColor(), To_plot = false, Counter = f, Fixed = false });
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
                //refresh_iso_plot();
            }
        }
        private double ppm_calculator3(double centroid)
        {
            double res = 0;
            double ppm = 0.0;
            double diff = 0.0;
            int d = 1;
            if (peak_points[peak_points.Count() - 1][1] - centroid < 0)
            {
                ppm = Math.Abs(peak_points[0][1] + peak_points[0][4] - centroid) * 1000000 / (peak_points[0][1] + peak_points[0][4]);
                if (ppm < ppmError) { res = (double)peak_points[0][3]; return res; }
                else return res;
            }

            do
            {
                diff = peak_points[d][1] + peak_points[d][4] - centroid;
                while (diff < 0)
                {
                    d++;
                    diff = peak_points[d][1] + peak_points[d][4] - centroid;
                }
                diff = peak_points[d][1] + peak_points[d][4] - centroid;
                if (diff >= 0)
                {
                    ppm = Math.Abs(diff) * 1000000 / (peak_points[d][1] + peak_points[d][4]);
                    if (ppm < ppmError) { res = (double)peak_points[d][3]; return res; }
                    ppm = Math.Abs(peak_points[d - 1][1] + peak_points[d - 1][4] - centroid) * 1000000 / (peak_points[d - 1][1] + peak_points[d - 1][4]);
                    if (ppm < ppmError) { res = (double)peak_points[d - 1][3]; return res; }
                    else return res;
                }

            } while (d < peak_points[0].Count() - 1);
            return res;
        }

        #endregion

        #region Calculation Options
        private void ClearCalc_Btn_Click(object sender, EventArgs e)
        {
            UncheckAll_calculationPanel();
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

        public static string fix_formula(string input, bool simple = true, int h = -1, int h2o = 0, int nh3 = 0)
        {
            string formula = "";
            if (simple == true) { formula = find_index_fix_formula(input, h); return formula; }
            if (h2o > 0)
            {
                input = find_index_fix_formula(input, -2 * h2o, 'H');
                input = find_index_fix_formula(input, -h2o, 'O');
            }
            if (nh3 > 0)
            {
                input = find_index_fix_formula(input, -3 * h2o, 'H');
                input = find_index_fix_formula(input, -nh3, 'N');
            }
            formula = input;
            return formula;
        }
        public static string find_index_fix_formula(string input, int amount = -1, char element = 'H')
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

        private void Form2_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void hide_Btn_Click(object sender, EventArgs e)
        {
            
            panel_calc.Hide(); splitContainer2.Panel1Collapsed = true;
            Size initial_splitcontSize = splitContainer2.Size;
            splitContainer2.Size = new Size(initial_splitcontSize.Width - panel_calc.Size.Width, initial_splitcontSize.Height);
            Size initial_ug_size = user_grpBox.Size;
            user_grpBox.Size = new Size(initial_ug_size.Width - panel_calc.Size.Width, initial_ug_size.Height);
            Point initial_ug_loc = user_grpBox.Location;
            user_grpBox.Location = new Point(initial_ug_loc.X + panel_calc.Size.Width, initial_ug_loc.Y);
            Size initial_plot_size = plots_grpBox.Size;
            plots_grpBox.Size = new Size(initial_plot_size.Width + panel_calc.Size.Width, initial_plot_size.Height);
            show_Btn.Visible = true; show_Btn.BringToFront();
            splitContainer2.Invalidate();

        }

        private void show_Btn_Click(object sender, EventArgs e)
        {
            panel_calc.Show(); splitContainer2.Panel1Collapsed = false;
            Size initial_splitcontSize = splitContainer2.Size;
            splitContainer2.Size = new Size(initial_splitcontSize.Width + panel_calc.Size.Width, initial_splitcontSize.Height);
            Size initial_ug_size = user_grpBox.Size;
            user_grpBox.Size = new Size(initial_ug_size.Width + panel_calc.Size.Width, initial_ug_size.Height);
            Point initial_ug_loc = user_grpBox.Location;
            user_grpBox.Location = new Point(initial_ug_loc.X - panel_calc.Size.Width, initial_ug_loc.Y);
            Size initial_plot_size = plots_grpBox.Size;
            plots_grpBox.Size = new Size(initial_plot_size.Width - panel_calc.Size.Width, initial_plot_size.Height);
            splitContainer2.SplitterDistance = 302;
            splitContainer2.Invalidate();
            hide_Btn.Visible = true; hide_Btn.BringToFront();
            show_Btn.Visible = false;
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

        #region unused_code
        //private void auto_fit_single()
        //{
        //    progress_display_start(Fragments2.Count + 1, "Calculating fragment fit...");
        //    sw1.Reset(); sw1.Start();

        //    all_fitted_results = new List<List<double[]>>();

        //    // auto single
        //    for (int i = 0; i < Fragments2.Count; i++)
        //    {
        //        // select only one frag
        //        List<int> idx = new List<int>() { i + 1 };
        //        all_fitted_results.Add(fit_distros2(idx));
        //        progress_display_update(i + 1);
        //    }

        //    sw1.Stop(); Debug.WriteLine("Fitting: " + sw1.ElapsedMilliseconds.ToString());
        //    progress_display_stop();

        //    // 5. display results
        //    Invoke(new Action(() => OnFittingCalcCompleted()));
        //}
        //private void start_fit()
        //{
        //    if (window_count == 1)
        //    {
        //        if (selectedFragments.Count > 14) { MessageBox.Show("The maximum amount of selected fragments is 14. The fitting algoritm can't operate on more than 14 selected fragments in each fitting section.", "Wrong selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

        //        // 0. Clear globals
        //        powerSet.Clear();
        //        powerSet_distroIdx.Clear();

        //        // 1. check data integrity
        //        if (!validate_data()) return;

        //        // 2. initiate fitting procedure
        //        fitted_results.Clear();
        //        fitted_results = fit_distros_parallel(selectedFragments);

        //        // 5. display results
        //        Invoke(new Action(() => OnFittingCalcCompleted()));
        //    }
        //    else if (selected_window == 1000000) { MessageBox.Show("Select a window first and then attempt to perform fit! "); return; }
        //    else
        //    {
        //        windowList[selected_window].PowerSet.Clear();
        //        windowList[selected_window].PowerSetTodistro.Clear();

        //        // 1. check data integrity
        //        if (!validate_data()) return;

        //        // 2. find selected distros for fitting
        //        find_window_checked_fragments(selected_window);
        //        if (windowList[selected_window].Checked_mono_fragments.Count > 14) { MessageBox.Show("The maximum amount of selected monoisotopic fragments for each window is 14. The fitting algoritm can't operate on more than 14 selected fragments in each fitting section.", "Wrong selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        //        // 3. align all data to the experimental all_data[0]
        //        // [m/z point 0] {exp, frag1, frag2, frag3, ... }
        //        // will be also needed later for plot               
        //        windowList[selected_window].Aligned.Clear();
        //        windowList[selected_window].Aligned = align_distros(windowList[selected_window].Checked_mono_fragments);

        //        //4.initiate fitting procedure
        //        windowList[selected_window].Fitted.Clear();
        //        windowList[selected_window].Fitted = fit_distros(windowList[selected_window].Aligned);
        //        //Fitted is a list of doubles[]:such as res = [frag1_int, frag2_int,...., SSE] sorted according to SSE

        //        // 5. display results
        //        refresh_fit_results(windowList[selected_window].Fitted);
        //    }
        //}
        //private List<double[]> fit_distros_parallel(List<int> selectedFragments)
        //{
        //    List<double[]> res = new List<double[]>();

        //    // this is all the logic of how many time the fitting should run
        //    // we want to fit every possible combination to get the best result (minimum SSE)
        //    // 1. generate the powerSet. It contains only fragment permutations
        //    powerSet.Clear();
        //    powerSet = FastPowerSet(selectedFragments.ToArray()).ToList();
        //    powerSet.RemoveAt(0);//remove the {0} set
        //    List<int[]> powerSet_copy = new List<int[]>();

        //    // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
        //    progress_display_start(powerSet.Count + 1, "Calculating fragment fit...");

        //    sw1.Reset(); sw1.Start();

        //    double experimental_max = all_data_aligned[0].Max();

        //    //int progress = 0;
        //    //Parallel.ForEach (powerSet, subSet =>
        //    //{
        //    //    // generate a new list containing only the fragments intensities of the subSet, and the experimental
        //    //    List<double[]> aligned_intensities_subSet = subset_of_aligned_distros(subSet.ToArray());

        //    //    // get the intensities of the fragments, to pass them to the optimizer as a better starting point
        //    //    List<double> UI_intensities = get_UI_intensities(subSet, experimental_max, true);

        //    //    // call optimizer for the specific subset of fragments
        //    //    double[] tmp = estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities);
        //    //    lock (_locker) { res.Add(tmp); powerSet_copy.Add(subSet); }

        //    //    // safelly keep track of progress
        //    //    Interlocked.Increment(ref progress);

        //    //    progress_display_update(progress);
        //    //});

        //    int progress = 0;
        //    Parallel.For(0, powerSet.Count - 1, (i, state) =>
        //    {
        //        // generate a new list containing only the fragments intensities of the subSet, and the experimental
        //        List<double[]> aligned_intensities_subSet = subset_of_aligned_distros(powerSet[i].ToArray());

        //        // get the intensities of the fragments, to pass them to the optimizer as a better starting point
        //        List<double> UI_intensities = get_UI_intensities(powerSet[i]);

        //        // call optimizer for the specific subset of fragments
        //        double[] tmp = estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities);
        //        lock (_locker) { res.Add(tmp); powerSet_copy.Add(powerSet[i]); }

        //        // safelly keep track of progress
        //        Interlocked.Increment(ref progress);

        //        progress_display_update(progress);
        //    });


        //    sw1.Stop(); Debug.WriteLine("Fitting(M): " + sw1.ElapsedMilliseconds.ToString());
        //    progress_display_stop();

        //    // sort res and powerSet by least SSE
        //    // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
        //    double[][] tmp1 = res.ToArray();
        //    //int[][] tmp2 = powerSet.ToArray();
        //    int[][] tmp2 = powerSet_copy.ToArray();

        //    IComparer myComparer = new lastElement();
        //    Array.Sort(tmp1, tmp2, myComparer);

        //    res = tmp1.ToList();
        //    powerSet = tmp2.ToList();

        //    return res;
        //}
        //private bool validate_data()
        //{
        //    // validity controls

        //    // 1. empty experimental
        //    if (all_data[0].Count < 10) { MessageBox.Show("Not enough experimental points! (distribution 0)", "Error!"); return false; };

        //    // 2. none selected or selected is empty distribution to fit
        //    bool any_selected = false, selected_is_empty = false;
        //    if (selectedFragments.Count > 0)
        //    {
        //        any_selected = true;
        //        foreach (int i in selectedFragments)
        //        {
        //            if (all_data[i].Count < 10) selected_is_empty = true;
        //        }
        //    }

        //    if (!any_selected) { MessageBox.Show("No distribution selected to perform fit!", "Error!"); return false; };
        //    if (selected_is_empty) { MessageBox.Show("Selected distribution has inadequate data points to perform fit!", "Error!"); return false; };

        //    return true;
        //}

        //private void fit_all_Btn_Click(object sender, EventArgs e)
        //{

        //    if (windowList.Count == 0) { MessageBox.Show("There isn't any window to perform multiple fit", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        //    if (bigPanel.Controls.Count == 0) { MessageBox.Show("Something went wrong.Please close the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        //    if (selectedFragments.Count() < 1) { MessageBox.Show("Select at least 1 fragment to perform fitting!"); return; }
        //    Fitting_chkBox.Checked = true;
        //    if (window_count == 1 && !string.IsNullOrEmpty(fitStep_Box.Text)) { step_Fitting(); if (!is_loading && !is_calc) { refresh_iso_plot(); } }

        //    refresh_all = true;
        //    for (int w = 0; w < windowList.Count; w++)
        //    {
        //        selected_window = w;
        //        window_colors(w);
        //        GetControls(bigPanel).OfType<Panel>().FirstOrDefault(l => l.TabIndex == w).BackColor = Color.LightSteelBlue;
        //        window_graph(w); highlight_selected(w);
        //        start_fit();
        //    }
        //    refresh_iso_plot();
        //    refresh_all = false;

        //    saveFit_Btn.Enabled = true;
        //}

        //private void step_Fitting()
        //{
        //    if (!string.IsNullOrEmpty(fitStep_Box.Text))
        //    {
        //        fit_step = double.Parse(fitStep_Box.Text, NumberStyles.AllowDecimalPoint);
        //        max_border = double.Parse(fitMax_Box.Text, NumberStyles.AllowDecimalPoint);
        //        min_border = double.Parse(fitMin_Box.Text, NumberStyles.AllowDecimalPoint);
        //        if (max_border < min_border) { MessageBox.Show("'max' can't be lower than 'min'", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        //        else if ((max_border - min_border) < fit_step) { MessageBox.Show("Fitting step too large for the m/z section selected! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        //        //na prosthsw ki allo elegxo gia to an einai katallhlo to input tou step
        //        segmented_graph = true;
        //        iso_plot.Model.Annotations.Clear();
        //        if (recalc) select_from_experimental(fitMin_Box.Text, fitMax_Box.Text, true, true, false);
        //        if (fit_step == 0) step_play(true);
        //        else step_play();
        //        if (Fragments2.Count > 0)
        //        {
        //            find_windows_mono_fragments();
        //            create_step_panels();
        //            fix_window_to_max_exp();
        //            fit_all_Btn.Enabled = true;
        //        }

        //        recalculate_all_data_aligned();
        //        refresh_iso_plot();
        //    }
        //}

        //private void step_play(bool window_1 = false)
        //{
        //    //stepIndeces.Clear();
        //    if (selected_all_data.Count == 0)
        //    {
        //        selected_all_data.Add(new List<double[]>());
        //        selected_all_data[0] = all_data[0];
        //    }
        //    List<FragForm> Fragments3 = Fragments2.OrderBy(o => Double.Parse(o.Mz)).ToList();
        //    windowList.Clear();
        //    if (window_1 == false)
        //    {
        //        window_count = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / fit_step) + 1;
        //        //if (window_count > 40)
        //        //{
        //        //    MessageBox.Show("The programm can handle till 40 windows, the inserted fit step= " + fit_step.ToString() + "ends up in" + window_count.ToString() + "windows.");
        //        //    fit_step = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / 40.0);
        //        //    fitStep_Box.Text = fit_step.ToString();
        //        //    window_count = (int)((selected_all_data[0].Last()[0] - selected_all_data[0][0][0]) / fit_step) + 1;
        //        //}
        //    }
        //    else
        //    {
        //        window_count = 1;
        //    }

        //    double left = selected_all_data[0][0][0];
        //    double right = left + fit_step;
        //    if (left < 0.0) left = 0.0;
        //    if (right > selected_all_data[0].Last()[0]) right = selected_all_data[0].Last()[0];
        //    int dot = 1;
        //    int starting = 0;
        //    int ending = 0;
        //    //ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = window_count, Size = new Size(227, 23), AutoSize = false };
        //    //user_grpBox.Controls.Add(tlPrgBr);
        //    int k = 0;
        //    bool last = false;
        //    do
        //    {
        //        for (int i = dot; i < selected_all_data[0].Count; i++) { if (left - step_range < selected_all_data[0][i][0]) { starting = i - 1; dot = i - 1; break; } }

        //        for (int i = dot; i < selected_all_data[0].Count; i++) { if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; } }

        //        int[] check = check_windows_borders(starting, ending, Fragments3);
        //        if (check[0] == -1)
        //        {
        //            if (check[1] < 2)
        //            {
        //                if (windowList.Count() > 0)
        //                {
        //                    check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
        //                    if (check[0] == -1)
        //                    {
        //                        windowList.Last().Ending = ending;
        //                        windowList.Last().All_data[0].Clear();
        //                        windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
        //                        windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                    }
        //                    else
        //                    {
        //                        windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                        windowList.Last().All_data.Add(new List<double[]>());
        //                        windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                        windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                        k++;
        //                    }
        //                    left = right;
        //                    right = left + fit_step;
        //                }
        //                else
        //                {
        //                    right = right + fit_step / 2;
        //                }
        //            }
        //            else
        //            {
        //                windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                windowList.Last().All_data.Add(new List<double[]>());
        //                windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                k++;
        //                left = right;
        //                right = left + fit_step;
        //            }
        //            if (last) window_count = windowList.Count();

        //            if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
        //            //tlPrgBr.Value++;
        //        }
        //        else
        //        {
        //            window_count++;
        //            //double ps1 = 4 * Fragments2[check[0] - 1].Centroid.Count() / 5;
        //            //int ps =(int)Math.Round(ps1,0);
        //            //right = Fragments2[check[0] - 1].Centroid.OrderBy(o=>o.X).ToList()[ps].X+1;
        //            right = Fragments2[check[0] - 1].Centroid[0].X + 1;
        //            for (int i = dot; i < selected_all_data[0].Count; i++)
        //                if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; }
        //            check = check_windows_borders2(starting, ending, Fragments3);
        //            if (check[0] == -1)
        //            {
        //                if (check[1] < 2)
        //                {
        //                    if (windowList.Count() > 0)
        //                    {
        //                        check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
        //                        if (check[0] == -1)
        //                        {
        //                            windowList.Last().Ending = ending;
        //                            windowList.Last().All_data[0].Clear();
        //                            windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
        //                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                            left = right;
        //                            right = left + fit_step;
        //                        }
        //                        else
        //                        {
        //                            windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                            windowList.Last().All_data.Add(new List<double[]>());
        //                            windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                            k++;
        //                            left = right;
        //                            right = left + fit_step;
        //                        }
        //                    }
        //                    else { right = right + fit_step / 2; }
        //                }
        //                else
        //                {
        //                    windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                    windowList.Last().All_data.Add(new List<double[]>());
        //                    windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                    k++;
        //                    left = right;
        //                    right = left + fit_step;
        //                }
        //                if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
        //            }
        //            else
        //            {
        //                right = left + (right - left) / 2;
        //                for (int i = dot; i < selected_all_data[0].Count; i++)
        //                    if (right + step_range <= selected_all_data[0][i][0]) { ending = i; break; }
        //                check = check_windows_borders2(starting, ending, Fragments3);
        //                if (check[1] < 2)
        //                {
        //                    if (windowList.Count() > 0)
        //                    {
        //                        check = check_windows_borders2(windowList.Last().Starting, ending, Fragments3);
        //                        if (check[0] == -1)
        //                        {
        //                            windowList.Last().Ending = ending;
        //                            windowList.Last().All_data[0].Clear();
        //                            windowList.Last().All_data[0] = all_data[0].GetRange(windowList.Last().Starting, windowList.Last().Ending - windowList.Last().Starting + 1);
        //                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                        }
        //                        else
        //                        {
        //                            windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                            windowList.Last().All_data.Add(new List<double[]>());
        //                            windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                            windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                            k++;
        //                        }
        //                        left = right;
        //                        right = left + fit_step;
        //                    }
        //                    else { right = right + fit_step / 2; }
        //                }
        //                else
        //                {
        //                    windowList.Add(new WindowSet() { Starting = starting, Ending = ending, All_data = new List<List<double[]>>(), Fragments = new List<int>(), PowerSet = new List<int[]>(), PowerSetTodistro = new List<int[]>(), Aligned = new List<double[]>(), Fitted = new List<double[]>(), Checked_mono_fragments = new List<int>(), Max_exp = new double(), Mono_fragments = new List<int>(), Code = k + 1 });
        //                    windowList.Last().All_data.Add(new List<double[]>());
        //                    windowList.Last().All_data[0] = all_data[0].GetRange(starting, ending - starting + 1);
        //                    windowList.Last().Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //                    left = right;
        //                    right = left + fit_step;
        //                    k++;
        //                }
        //                if (right > selected_all_data[0].Last()[0]) { last = true; right = selected_all_data[0].Last()[0]; }
        //            }
        //        }
        //    } while (k < window_count);
        //    int[] check_last = check_windows_borders2(windowList.Last().Starting, windowList.Last().Ending, Fragments3);
        //    if (check_last[1] < 2)
        //    {
        //        windowList[windowList.Count - 2].Ending = windowList.Last().Ending;
        //        windowList[windowList.Count - 2].All_data[0].Clear();
        //        windowList[windowList.Count - 2].All_data[0] = all_data[0].GetRange(windowList[windowList.Count - 2].Starting, windowList[windowList.Count - 2].Ending - windowList[windowList.Count - 2].Starting + 1);
        //        windowList[windowList.Count - 2].Max_exp = windowList.Last().All_data[0].Max(element => element[1]);
        //        windowList.RemoveAt(windowList.Count - 1);
        //        window_count--;
        //    }
        //    //tlPrgBr.Dispose();
        //}

        //private List<double[]> fit_distros(List<double[]> aligned_intensities)
        //{
        //    List<double[]> res = new List<double[]>();

        //    // this is all the logic of how many time the fitting should run
        //    // we want to fit every possible combination to get the best result (minimum SSE)
        //    if (window_count == 1)
        //    {
        //        // 1. generate the powerSet. It contains only fragment permutations
        //        powerSet.Clear();
        //        //powerSet = generatePowerSet(aligned_intensities[0].Length);

        //        // build list with numbers
        //        int total = aligned_intensities[0].Length - 1;
        //        int[] seq = new int[total];
        //        for (int i = 0; i < total; i++) seq[i] = i + 1;
        //        powerSet = FastPowerSet(seq).ToList();
        //        powerSet.RemoveAt(0);//remove the {0} set

        //        // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
        //        ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = powerSet.Count, Size = new Size(227, 23), AutoSize = false };
        //        user_grpBox.Controls.Add(tlPrgBr);

        //        sw1.Reset(); sw1.Start();

        //        double experimental_max = aligned_intensities.Max(element => element[0]);

        //        foreach (int[] subSet in powerSet)
        //        {
        //            tlPrgBr.Value++;
        //            // generate a new list containing only the fragments intensities of the subSet, and the experimental
        //            List<double[]> aligned_intensities_subSet = new List<double[]>();//lista tvn tmp gia kathe i

        //            for (int i = 0; i < aligned_intensities.Count; i++)//to i einai arithmos metrhshs
        //            {
        //                // first add experimental
        //                double[] tmp = new double[subSet.Length + 1];//tmp=[exp[i] frag1[i] frag2[i] ...]
        //                tmp[0] = aligned_intensities[i][0];

        //                // then all respective fragments
        //                for (int j = 0; j < subSet.Length; j++) tmp[j + 1] = aligned_intensities[i][subSet[j]];

        //                aligned_intensities_subSet.Add(tmp);
        //            }
        //            // get the intensities of the fragments, to pass them to the optimizer as a better starting point
        //            List<double> UI_intensities = get_UI_intensities(subSet);

        //            // call optimizer for the specific subset of fragments
        //            res.Add(estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities));
        //        }

        //        sw1.Stop(); Debug.WriteLine("Fitting: " + sw1.ElapsedMilliseconds.ToString());
        //        tlPrgBr.Dispose();

        //        // sort res and powerSet by least SSE
        //        // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
        //        double[][] tmp1 = res.ToArray();
        //        int[][] tmp2 = powerSet.ToArray();

        //        IComparer myComparer = new lastElement();
        //        Array.Sort(tmp1, tmp2, myComparer);

        //        res = tmp1.ToList();
        //        powerSet = tmp2.ToList();
        //    }
        //    else
        //    {
        //        //aligned intensities are about ONLY the checked_mono_fragments
        //        int w = selected_window;
        //        int start = windowList[w].Starting;
        //        int end = windowList[w].Ending;
        //        // 1. generate the powerSet. It contains only fragment permutations
        //        windowList[w].PowerSet.Clear();
        //        //powerSet = generatePowerSet(aligned_intensities[0].Length);

        //        // build list with numbers
        //        int total = aligned_intensities[0].Length - 1;
        //        int[] seq = new int[total];
        //        for (int i = 0; i < total; i++) seq[i] = i + 1;
        //        windowList[w].PowerSet = FastPowerSet(seq).ToList();
        //        windowList[w].PowerSet.RemoveAt(0);//remove the {0} set

        //        // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities

        //        ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = windowList[w].PowerSet.Count, Size = new Size(227, 23), AutoSize = false };
        //        user_grpBox.Controls.Add(tlPrgBr);

        //        double experimental_max = aligned_intensities.Max(element => element[0]);

        //        foreach (int[] subSet in windowList[w].PowerSet)
        //        {
        //            tlPrgBr.Value++;
        //            // generate a new list containing only the fragments intensities of the subSet, and the experimental
        //            List<double[]> aligned_intensities_subSet = new List<double[]>();//lista tvn tmp gia kathe i

        //            for (int i = 0; i < aligned_intensities.Count; i++)//to i einai arithmos metrhshs
        //            {
        //                // first add experimental
        //                double[] tmp = new double[subSet.Length + 1];//tmp=[exp[i] frag1[i] frag2[i] ...]
        //                tmp[0] = aligned_intensities[i][0];

        //                // then all respective fragments
        //                for (int j = 0; j < subSet.Length; j++) tmp[j + 1] = aligned_intensities[i][subSet[j]];

        //                aligned_intensities_subSet.Add(tmp);
        //            }
        //            // get the intensities of the fragments, to pass them to the optimizer as a better starting point
        //            //List<double> UI_intensities = get_UI_intensities(subSet, experimental_max, true, true, w);
        //            List<double> UI_intensities = get_UI_intensities(subSet);

        //            // call optimizer for the specific subset of fragments
        //            res.Add(estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities));
        //        }
        //        tlPrgBr.Dispose();

        //        // sort res and powerSet by least SSE
        //        // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
        //        double[][] tmp1 = res.ToArray();
        //        int[][] tmp2 = windowList[w].PowerSet.ToArray();

        //        IComparer myComparer = new lastElement();
        //        Array.Sort(tmp1, tmp2, myComparer);

        //        res = tmp1.ToList();
        //        windowList[w].PowerSet = tmp2.ToList();
        //    }


        //    return res;
        //}

        //private List<double[]> fit_distros2(List<int> selectedFragments)
        //{
        //    List<double[]> res = new List<double[]>();

        //    // this is all the logic of how many times the fitting should run
        //    // we want to fit every possible combination of the given fragments to get the best result (minimum SSE)
        //    // 1. generate the powerSet. It contains only fragment permutations
        //    powerSet.Clear();
        //    powerSet = FastPowerSet(selectedFragments.ToArray()).ToList();
        //    powerSet.RemoveAt(0);//remove the {0} set

        //    // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
        //    //progress_display_start(powerSet.Count + 1, "Calculating fragment fit...");

        //    //sw1.Reset(); sw1.Start();

        //    double experimental_max = all_data_aligned[0].Max();

        //    int count = 0;
        //    foreach (int[] subSet in powerSet)
        //    {
        //        // generate a new list containing only the fragments intensities of the subSet, and the experimental
        //        List<double[]> aligned_intensities_subSet = subset_of_aligned_distros(subSet.ToArray());

        //        // get the intensities of the fragments, to pass them to the optimizer as a better starting point
        //        List<double> UI_intensities = get_UI_intensities(subSet);

        //        // call optimizer for the specific subset of fragments
        //        res.Add(estimate_fragment_height_multiFactor(aligned_intensities_subSet, UI_intensities));

        //        count++;
        //        //progress_display_update(count);
        //    }

        //    //sw1.Stop(); Debug.WriteLine("Fitting: " + sw1.ElapsedMilliseconds.ToString());
        //    //progress_display_stop();

        //    // sort res and powerSet by least SSE
        //    // res is a list of doubles. res = [frag1_int, frag2_int,...., SSE]
        //    double[][] tmp1 = res.ToArray();
        //    int[][] tmp2 = powerSet.ToArray();

        //    IComparer myComparer = new lastElement();
        //    Array.Sort(tmp1, tmp2, myComparer);

        //    res = tmp1.ToList();
        //    powerSet = tmp2.ToList();

        //    return res;
        //}

        //private void populate_frag_listView()
        //{
        //    // adds all matched fragments to frag_listView, rebuilds it from sctatch
        //    frag_listView.BeginUpdate();
        //    frag_listView.Items.Clear();

        //    for (int i = 0; i < Fragments2.Count; i++)
        //    {
        //        var listViewItem = new ListViewItem(Fragments2[i].ListName);
        //        listViewItem.SubItems.Add("1.0");//"factor" column
        //        listViewItem.SubItems.Add(Fragments2[i].Counter.ToString());// "No" (aka code) column
        //        listViewItem.SubItems.Add(Fragments2[i].Centroid[0].Y.ToString());// max centroid

        //        frag_listView.Items.Add(listViewItem);
        //    }
        //    frag_listView.EndUpdate();
        //}

        //private void Calc_Btn_Click2()
        //{
        //    sw1.Reset(); sw1.Start();
        //    is_calc = true;
        //    #region check if resolution inputs are correct and then calculate
        //    if (string.IsNullOrEmpty(resolution_Box.Text) && machine_listBox.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("You need to set a Resolution value. " +
        //                                "You can either select the machine used or complete the 'Resolution' text box.");

        //    }
        //    else if (machine_listBox.SelectedItems.Count == 0 && float.Parse(resolution_Box.Text, CultureInfo.InvariantCulture.NumberFormat) < 1)
        //    {
        //        MessageBox.Show("Please choose a resolution higher or equal to 1");
        //    }
        //    else
        //    {
        //        List<ChemiForm> Selected_options = new List<ChemiForm>();
        //        Selected_options = ChemFormulas;
        //        List<int[]> selectedIndex1 = new List<int[]>();
        //        List<int[]> selectedIndex2 = new List<int[]>();
        //        HashSet<int> selectedPrimaryIndex = new HashSet<int>();
        //        #region m/z boundaries opptions
        //        if (!string.IsNullOrEmpty(mzMax_Box.Text) && !string.IsNullOrEmpty(mzMin_Box.Text))
        //        {
        //            List<ChemiForm> keeplistitem = new List<ChemiForm>();
        //            double max = Double.Parse(Selected_options.Last().Mz, CultureInfo.InvariantCulture.NumberFormat);
        //            double min = 0.0;
        //            if (!string.IsNullOrEmpty(mzMax_Box.Text))
        //            {
        //                max = Double.Parse(mzMax_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
        //            }
        //            if (!string.IsNullOrEmpty(mzMin_Box.Text))
        //            {
        //                min = Double.Parse(mzMin_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
        //            }
        //            foreach (ChemiForm chem in Selected_options)
        //            {
        //                double mz = Double.Parse(chem.Mz, CultureInfo.InvariantCulture.NumberFormat);
        //                if (mz <= max && mz >= min)
        //                {
        //                    keeplistitem.Add(chem);
        //                }
        //                else if (mz > max)
        //                {
        //                    break;
        //                }
        //            }
        //            Selected_options = keeplistitem;
        //        }
        //        #endregion

        //        #region charge options
        //        if (!string.IsNullOrEmpty(chargeMax_Box.Text) || !string.IsNullOrEmpty(chargeMin_Box.Text))
        //        {
        //            List<ChemiForm> keeplistitem = new List<ChemiForm>();
        //            double max = 25;
        //            double min = 0.0;
        //            if (!string.IsNullOrEmpty(chargeMax_Box.Text))
        //            {
        //                max = Double.Parse(chargeMax_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
        //            }
        //            if (!string.IsNullOrEmpty(chargeMin_Box.Text))
        //            {
        //                min = Double.Parse(chargeMin_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
        //            }
        //            foreach (ChemiForm chem in Selected_options)
        //            {
        //                int charge = chem.Charge;
        //                if (charge <= max && charge >= min)
        //                {
        //                    keeplistitem.Add(chem);
        //                }
        //            }
        //            Selected_options = keeplistitem;
        //        }
        //        #endregion

        //        #region ion mode options            
        //        if (addin_lstBox.SelectedItems.Count > 0 || a_lstBox.SelectedItems.Count > 0 || b_lstBox.SelectedItems.Count > 0 || c_lstBox.SelectedItems.Count > 0 || x_lstBox.SelectedItems.Count > 0 || y_lstBox.SelectedItems.Count > 0 || z_lstBox.SelectedItems.Count > 0 || internal_lstBox.SelectedItems.Count > 0 || dvw_lstBox.SelectedItems.Count > 0)
        //        {
        //            List<ChemiForm> keeplistitem = new List<ChemiForm>();
        //            //add-in list box
        //            if (addin_lstBox.CheckedItems.Count > 0)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    string ion_type_sub = chem.Ion_type.Substring(0, 1);
        //                    if (chem.Ion_type.Length > 4)
        //                    {
        //                        foreach (string ion in addin_lstBox.CheckedItems)
        //                        {
        //                            string form = ion.Substring(0, 1);
        //                            if (ion.Contains("H2O") && ion.Contains("NH3"))
        //                            {
        //                                if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("NH3") && chem.Ion_type.Contains("H2O"))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy()); break;
        //                                }
        //                            }
        //                            else if (ion.Contains("H2O"))
        //                            {
        //                                if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("H2O") && !chem.Ion_type.Contains("NH3"))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy()); break;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (ion_type_sub.Equals(form) && chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy()); break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //a list box
        //            if (a_lstBox.CheckedItems.Count > 0)
        //            {

        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("a"))
        //                    {
        //                        foreach (string ion in a_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);
        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Adduct = "H" + c.ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";

        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("a", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("a", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);

        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("a", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("a", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //b list box
        //            if (b_lstBox.CheckedItems.Count > 0)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("b"))
        //                    {
        //                        foreach (string ion in b_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Adduct = "H" + c.ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("b", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("b", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("b", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("b", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //c list box
        //            if (c_lstBox.CheckedItems.Count > 0)
        //            {

        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("c"))
        //                    {
        //                        foreach (string ion in c_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Adduct = "H" + c.ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("c", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("c", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("c", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("c", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //y list box
        //            if (y_lstBox.CheckedItems.Count > 0)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("y"))
        //                    {
        //                        foreach (string ion in y_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("y", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("y", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("y", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("y", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //x list box
        //            if (x_lstBox.CheckedItems.Count > 0)
        //            {

        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("x"))
        //                    {
        //                        foreach (string ion in x_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Adduct = "H" + c.ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("x", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("x", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("x", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("x", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //z list box
        //            if (z_lstBox.CheckedItems.Count > 0)
        //            {

        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Equals("z"))
        //                    {
        //                        foreach (string ion in z_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("+"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                if (keeplistitem.Last().Charge > 1)
        //                                {
        //                                    int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + (c * 1.007825)).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, c);

        //                                    c += keeplistitem.Last().Charge - 1;
        //                                    keeplistitem.Last().Adduct = "H" + c.ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                }
        //                                else
        //                                {
        //                                    keeplistitem.Last().Adduct = "H" + ion[2].ToString();
        //                                    keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                    keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) + 1.007825).ToString();
        //                                    keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, 1);

        //                                }
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("z", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("z", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString1;

        //                            }
        //                            else if (ion.Contains("-"))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                                keeplistitem.Last().Deduct += "H" + ion[2];
        //                                keeplistitem.Last().Ion_type = "(" + ion + ")";
        //                                int c = Int32.Parse(ion[2].ToString(), NumberStyles.Integer);
        //                                keeplistitem.Last().Mz = (double.Parse(keeplistitem.Last().Mz, NumberStyles.AllowDecimalPoint) - (c * 1.007825)).ToString();
        //                                keeplistitem.Last().PrintFormula = fix_formula(keeplistitem.Last().PrintFormula, true, -c);
        //                                var radioString = keeplistitem.Last().Radio_label;
        //                                var radioBuider = new StringBuilder(radioString);
        //                                radioBuider.Replace("z", "(" + ion + ")");
        //                                radioString = radioBuider.ToString();
        //                                keeplistitem.Last().Radio_label = radioString;
        //                                var radioString1 = keeplistitem.Last().Name;
        //                                var radioBuider1 = new StringBuilder(radioString1);
        //                                radioBuider1.Replace("z", "(" + ion + ")");
        //                                radioString1 = radioBuider1.ToString();
        //                                keeplistitem.Last().Name = radioString;

        //                            }
        //                            else
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //internal list box
        //            if (internal_lstBox.CheckedItems.Count > 0)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Ion_type.Length > 8 && chem.Ion_type.Contains("int"))
        //                    {
        //                        foreach (string ion in internal_lstBox.CheckedItems)
        //                        {
        //                            if (ion.Contains("b") && chem.Ion_type.Contains("b"))
        //                            {
        //                                if (ion.Contains("H2O"))
        //                                {
        //                                    if (chem.Ion_type.Contains("H2O"))
        //                                    {
        //                                        if (ion.Contains("NH3"))
        //                                        {
        //                                            if (chem.Ion_type.Contains("NH3"))
        //                                            {
        //                                                keeplistitem.Add(chem.DeepCopy()); break;
        //                                            }
        //                                        }
        //                                        else if (!chem.Ion_type.Contains("NH3"))
        //                                        {
        //                                            keeplistitem.Add(chem.DeepCopy()); break;
        //                                        }
        //                                    }

        //                                }
        //                                else if (ion.Contains("NH3"))
        //                                {
        //                                    if (chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
        //                                    {
        //                                        keeplistitem.Add(chem.DeepCopy()); break;
        //                                    }
        //                                }
        //                                else if (!chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy()); break;
        //                                }
        //                            }
        //                            else if (chem.Ion_type.Contains(" a"))
        //                            {
        //                                if (ion.Contains("H2O"))
        //                                {
        //                                    if (chem.Ion_type.Contains("H2O"))
        //                                    {
        //                                        if (ion.Contains("NH3"))
        //                                        {
        //                                            if (chem.Ion_type.Contains("NH3"))
        //                                            {
        //                                                keeplistitem.Add(chem.DeepCopy()); break;
        //                                            }
        //                                        }
        //                                        else if (!chem.Ion_type.Contains("NH3"))
        //                                        {
        //                                            keeplistitem.Add(chem.DeepCopy()); break;
        //                                        }
        //                                    }
        //                                }
        //                                else if (ion.Contains("NH3"))
        //                                {
        //                                    if (chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
        //                                    {
        //                                        keeplistitem.Add(chem.DeepCopy()); break;
        //                                    }
        //                                }
        //                                else if (!chem.Ion_type.Contains("NH3") && !chem.Ion_type.Contains("H2O"))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy()); break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //            //dvw list box               
        //            if (dvw_lstBox.CheckedItems.Count > 0)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    foreach (string ion in dvw_lstBox.CheckedItems)
        //                    {
        //                        if (chem.Ion_type.Equals(ion))
        //                        {
        //                            keeplistitem.Add(chem.DeepCopy()); break;
        //                        }
        //                    }
        //                }

        //            }
        //            Selected_options = keeplistitem;
        //        }
        //        #endregion

        //        #region index options //--> prepei na rwtisw
        //        if (!string.IsNullOrEmpty(idxPr_Box.Text) || !string.IsNullOrEmpty(idxTo_Box.Text) || !string.IsNullOrEmpty(idxFrom_Box.Text))
        //        {
        //            //primary index --> 1 input number that indicates the min index number that the formula must have to be calculated 
        //            List<ChemiForm> keeplistitem = new List<ChemiForm>();
        //            if (!string.IsNullOrEmpty(idxPr_Box.Text))
        //            {
        //                string[] inputs = Regex.Split(idxPr_Box.Text, ",");
        //                string[] my_ions = new string[] { "a", "b", "c", "x", "y", "z", "d", "v", "w" };

        //                if (my_ions.Any(inputs[0].Contains))
        //                {
        //                    foreach (string word in inputs)
        //                    {
        //                        string type = word[0].ToString();
        //                        string primin = word.Substring(1);
        //                        if (primin.Contains("-"))
        //                        {
        //                            string[] wordTo = Regex.Split(primin, "-");
        //                            int pr1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
        //                            int pr2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
        //                            int pr_ = pr1;
        //                            while (pr_ <= pr2)
        //                            {
        //                                selectedPrimaryIndex.Add(pr_);
        //                                pr_++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            int to = int.Parse(primin, CultureInfo.InvariantCulture.NumberFormat);
        //                            while (to <= Peptide.Length)
        //                            {
        //                                selectedPrimaryIndex.Add(to); to++;
        //                            }
        //                        }
        //                        foreach (ChemiForm chem in Selected_options)
        //                        {
        //                            if (chem.Ion_type.Equals(type))
        //                            {
        //                                int index = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
        //                                int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
        //                                if (index == indexTo && selectedPrimaryIndex.Contains(index))
        //                                {
        //                                    keeplistitem.Add(chem.DeepCopy());
        //                                }
        //                            }
        //                        }
        //                        selectedPrimaryIndex.Clear();
        //                        selectedPrimaryIndex.TrimExcess();
        //                    }
        //                }
        //                else
        //                {
        //                    foreach (string word in inputs)
        //                    {
        //                        if (word.Contains("-"))
        //                        {
        //                            string[] wordTo = Regex.Split(word, "-");
        //                            int pr1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
        //                            int pr2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
        //                            int pr_ = pr1;
        //                            while (pr_ <= pr2)
        //                            {
        //                                selectedPrimaryIndex.Add(pr_); pr_++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            int to = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat);
        //                            while (to <= Peptide.Length)
        //                            {
        //                                selectedPrimaryIndex.Add(to); to++;
        //                            }
        //                        }
        //                    }
        //                    foreach (ChemiForm chem in Selected_options)
        //                    {
        //                        int index = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
        //                        int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
        //                        if (index == indexTo)
        //                        {
        //                            if (selectedPrimaryIndex.Contains(index))
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy());
        //                            }
        //                        }
        //                    }
        //                    selectedPrimaryIndex.Clear();
        //                    selectedPrimaryIndex.TrimExcess();
        //                }
        //            }
        //            if (!string.IsNullOrEmpty(idxTo_Box.Text) && !string.IsNullOrEmpty(idxFrom_Box.Text))
        //            {
        //                string[] inputsTo = Regex.Split(idxTo_Box.Text, ",");
        //                string[] inputsFrom = Regex.Split(idxFrom_Box.Text, ",");
        //                foreach (string word in inputsTo)
        //                {
        //                    List<int> indeces = new List<int>();
        //                    if (word.Contains("-"))
        //                    {
        //                        string[] wordTo = Regex.Split(word, "-");
        //                        int to1 = int.Parse(wordTo[0], CultureInfo.InvariantCulture.NumberFormat);
        //                        int to2 = int.Parse(wordTo[1], CultureInfo.InvariantCulture.NumberFormat);
        //                        int to_ = to1;
        //                        while (to_ <= to2)
        //                        {
        //                            indeces.Add(to_);
        //                            to_++;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        int to = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat);
        //                        indeces.Add(to);
        //                    }
        //                    selectedIndex2.Add(indeces.ToArray());
        //                }
        //                foreach (string word in inputsFrom)
        //                {
        //                    List<int> indeces = new List<int>();
        //                    if (word.Contains("-"))
        //                    {
        //                        string[] wordFrom = Regex.Split(word, "-");
        //                        int from1 = int.Parse(wordFrom[0], CultureInfo.InvariantCulture.NumberFormat);
        //                        int from2 = int.Parse(wordFrom[1], CultureInfo.InvariantCulture.NumberFormat);
        //                        int from_ = from1;
        //                        while (from_ <= from2) { indeces.Add(from_); from_++; }
        //                    }
        //                    else
        //                    {
        //                        int from = int.Parse(word, CultureInfo.InvariantCulture.NumberFormat); indeces.Add(from);
        //                    }
        //                    selectedIndex1.Add(indeces.ToArray());
        //                }
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    int indexFrom = int.Parse(chem.Index, CultureInfo.InvariantCulture.NumberFormat);
        //                    int indexTo = int.Parse(chem.IndexTo, CultureInfo.InvariantCulture.NumberFormat);
        //                    if (indexFrom != indexTo)
        //                    {
        //                        for (int d = 0; d < selectedIndex1.Count(); d++)
        //                        {
        //                            int idx1 = Array.IndexOf(selectedIndex1[d], indexFrom);
        //                            int idx2 = Array.IndexOf(selectedIndex2[d], indexTo);
        //                            if (idx1 > -1 && idx2 > -1)
        //                            {
        //                                keeplistitem.Add(chem.DeepCopy()); break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            Selected_options = keeplistitem;
        //        }

        //        #endregion

        //        #region Last check if items in Selected_options are already included in Fragments 2
        //        if (Fragments2.Count != 0)
        //        {
        //            List<ChemiForm> duplicateItem = new List<ChemiForm>();
        //            foreach (FragForm fra in Fragments2)
        //            {
        //                foreach (ChemiForm chem in Selected_options)
        //                {
        //                    if (chem.Mz.Equals(fra.Mz) && chem.Radio_label.Equals(fra.Radio_label) && chem.Adduct.Equals(fra.Adduct) && chem.Deduct.Equals(fra.Deduct))
        //                    {
        //                        duplicateItem.Add(chem);
        //                    }
        //                }
        //            }
        //            foreach (ChemiForm chem in duplicateItem)
        //            {
        //                Selected_options.Remove(chem);
        //            }
        //        }
        //        #endregion

        //        if (Selected_options.Count != 0)
        //        {
        //            calc_resolution = true;
        //            recalc = true;
        //            neues = Fragments2.Count();
        //            ProgressBar tlPrgBr = new ProgressBar() { Name = "tlPrgBr", Location = new Point(660, 21), Style = 0, Minimum = 0, Value = 0, Maximum = Selected_options.Count, Size = new Size(227, 23), AutoSize = false };
        //            user_grpBox.Controls.Add(tlPrgBr);

        //            calc_Btn.Enabled = false;
        //            frag_listView.BeginUpdate();

        //            #region Calculation                    
        //            foreach (ChemiForm chem in Selected_options)
        //            {
        //                #region Resolution
        //                if (machine_listBox.SelectedItems.Count > 0)
        //                {
        //                    chem.Machine = machine_listBox.SelectedItem.ToString();
        //                }
        //                else
        //                {
        //                    chem.Resolution = float.Parse(resolution_Box.Text, CultureInfo.InvariantCulture.NumberFormat);
        //                }
        //                #endregion

        //                ChemiForm.CheckChem(chem);
        //                if (chem.Resolution == 0)
        //                {
        //                    if (String.IsNullOrEmpty(chem.Machine.ToString()))
        //                    {
        //                        chem.Error = true;
        //                    }
        //                    else
        //                    {
        //                        ChemiForm.Get_R(chem, calc_resolution);
        //                        if (chem.Resolution == 0) chem.Error = true;
        //                        calc_resolution = false;//the resolution matrix is calculated only once for the forst fragment, and is constant for the other fragments
        //                    }
        //                }
        //                if (chem.Error == false)
        //                {
        //                    algo = 1;
        //                    int idx = chem.FinalFormula.IndexOf("C");
        //                    if (Char.IsNumber(chem.FinalFormula[idx + 2]) != true) algo = 1;
        //                    else if (Char.IsNumber(chem.FinalFormula[idx + 3]) == true) algo = 2;

        //                    if (algo == 1)
        //                    {
        //                        ChemiForm.Isopattern(chem, 1000000, 1, 0, 0.01);
        //                    }
        //                    else
        //                    {
        //                        ChemiForm.Isopattern(chem, 1000000, 2, 0, 0.01);
        //                    }
        //                    ChemiForm.Envelope(chem);
        //                }

        //                if (chem.Error == false)
        //                {
        //                    ChemiForm.Vdetect(chem);
        //                    List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
        //                    if (insert_exp == true)
        //                    {
        //                        //Console.WriteLine(chem.Centroid[cen_int].X.ToString());
        //                        chem.Resolution = ppm_calculator2(cen[0].X);
        //                        if (chem.Resolution != 0f)
        //                        {
        //                            if (ppm_calculator2(cen[1].X) != 0f || (cen.Count() > 2 && ppm_calculator2(cen[2].X) != 0f))
        //                            {
        //                                chem.Profile.Clear();
        //                                ChemiForm.Envelope(chem);
        //                                counter++;//o counter antistoixei ston index tou fragment sto all_data
        //                                Fragments2.Add(new FragForm() { Centroid = cen, Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution, Factor = 1.0, Counter = counter, To_plot = false, Color = chem.Color, Name = chem.Name, ListName = new string[4], Fix = 1.0, Max_intensity = new double() });
        //                                Debug.WriteLine(Fragments2.Count.ToString());
        //                                initialize_fragments();
        //                                if (chem.Charge > 0) Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
        //                                else Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
        //                                var listViewItem = new ListViewItem(Fragments2.Last().ListName);
        //                                listViewItem.SubItems.Add("1.0");//"factor" column
        //                                listViewItem.SubItems.Add(counter.ToString());// "No" (aka code) column
        //                                listViewItem.SubItems.Add(cen[0].Y.ToString());// max centroid
        //                                frag_listView.Items.Add(listViewItem);

        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        counter++;//o counter antistoixei ston index tou fragment sto all_data
        //                        Fragments2.Add(new FragForm() { Centroid = cen, Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution, Factor = 1.0, Counter = counter, To_plot = false, Color = chem.Color, Name = chem.Name, ListName = new string[4], Fix = 1.0, Max_intensity = new double() });
        //                        initialize_fragments();
        //                        if (chem.Charge > 0) Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, "+" + chem.Charge.ToString(), chem.PrintFormula };
        //                        else Fragments2.Last().ListName = new string[] { chem.Radio_label, chem.Mz, chem.Charge.ToString(), chem.PrintFormula };
        //                        var listViewItem = new ListViewItem(Fragments2.Last().ListName);
        //                        listViewItem.SubItems.Add("1.0");//"factor" column
        //                        listViewItem.SubItems.Add(counter.ToString());// "No" (aka code) column
        //                        listViewItem.SubItems.Add(cen[0].Y.ToString());// max centroid
        //                        frag_listView.Items.Add(listViewItem);
        //                    }
        //                    //Console.WriteLine(tlPrgBr.Value);

        //                    tlPrgBr.Value++;
        //                }
        //                else
        //                {
        //                    string message = "Formula with m/z:" + chem.Mz + " and ion type:" + chem.Ion + " encountered an error";
        //                    MessageBox.Show(message, "Error Detected in Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //                }

        //            }
        //            #endregion
        //            tlPrgBr.Dispose();
        //            frag_listView.EndUpdate();

        //            sw1.Stop(); Debug.WriteLine("Pre allign: " + sw1.ElapsedMilliseconds.ToString());
        //            sw1.Reset(); sw1.Start();

        //            if (counter != Fragments2.Count)
        //            {
        //                MessageBox.Show("Error in 'Fragments2'!Restart the program!");
        //            }
        //            else
        //            {
        //                if (insert_exp) step_Fitting();
        //                if (!is_loading)
        //                {
        //                    if (string.IsNullOrEmpty(fitStep_Box.Text)) { recalculate_all_data_aligned(); }
        //                    refresh_iso_plot();
        //                }

        //                // j = 0; to be removed
        //                saveCalc_Btn.Enabled = true;
        //                clearCalc_Btn.Enabled = true;
        //                calc_Btn.Enabled = true;
        //                fit_Btn.Enabled = true;
        //                loadFit_Btn.Enabled = false;

        //                sw1.Stop(); Debug.WriteLine("Post allign: " + sw1.ElapsedMilliseconds.ToString());

        //                MessageBox.Show("Done!");


        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("There is no match to your research.Please try again!");
        //            clearCalc_Btn.Enabled = true;
        //        }
        //    }
        //    #endregion            
        //    is_calc = false;


        //}

        //private float ppm_calculator2(double centroid)
        //{
        //    float res = 0f;
        //    double ppm = 0.0;
        //    double diff = 0.0;
        //    int d = 1;
        //    if (peak_points[peak_points.Count() - 1][1] - centroid < 0)
        //    {
        //        ppm = Math.Abs(peak_points[0][1] + peak_points[0][4] - centroid) * 1000000 / (peak_points[0][1] + peak_points[0][4]);
        //        if (ppm < ppmError) { res = (float)peak_points[0][3]; return res; }
        //        else return res;
        //    }

        //    do
        //    {
        //        diff = peak_points[d][1] + peak_points[d][4] - centroid;
        //        while (diff < 0)
        //        {
        //            d++;
        //            diff = peak_points[d][1] + peak_points[d][4] - centroid;
        //        }
        //        diff = peak_points[d][1] + peak_points[d][4] - centroid;
        //        if (diff >= 0)
        //        {
        //            ppm = Math.Abs(diff) * 1000000 / (peak_points[d][1] + peak_points[d][4]);
        //            if (ppm < ppmError) { res = (float)peak_points[d][3]; return res; }
        //            ppm = Math.Abs(peak_points[d - 1][1] + peak_points[d - 1][4] - centroid) * 1000000 / (peak_points[d - 1][1] + peak_points[d - 1][4]);
        //            if (ppm < ppmError) { res = (float)peak_points[d - 1][3]; return res; }
        //            else return res;
        //        }

        //    } while (d < peak_points[0].Count() - 1);
        //    return res;
        //}

        //private void save_data()
        //{

        //    SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = "window" + windowList[selected_window].Code.ToString(), Filter = "Data Files (*.wnd)|*.wnd", DefaultExt = "wnd", OverwritePrompt = true, AddExtension = true };

        //    //save.InitialDirectory = Application.StartupPath + "\\Data";
        //    //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
        //    //if (di.Exists != true) di.Create();

        //    if (save.ShowDialog() == DialogResult.OK)
        //    {
        //        System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

        //        file.WriteLine("Mode:\texternal data");
        //        file.WriteLine("AA Sequence:\t" + Peptide);
        //        file.WriteLine("Window:\t" + windowList[selected_window].Code.ToString());
        //        file.WriteLine("Fitted isotopes:\t" + candidate_fragments.ToString());
        //        file.WriteLine("m/z[Da]\tIntensity");
        //        file.WriteLine();

        //        for (int i = 0; i < windowList[selected_window].Fragments.Count; i++)
        //        {
        //            int indexS = windowList[selected_window].Fragments[i];
        //            if (indexS == 0)
        //            {
        //                file.WriteLine("Name:\t" + "Exp");
        //                file.WriteLine("Factor:\t" + "1.0");
        //            }
        //            else
        //            {
        //                file.WriteLine("Name:\t" + Fragments2[indexS - 1].Name);
        //                file.WriteLine("Factor:\t" + Fragments2[indexS - 1].Factor);
        //                file.WriteLine("ListViewItems:\t" + Fragments2[indexS - 1].ListName[0].ToString() + "\t" + Fragments2[indexS - 1].ListName[1].ToString() + "\t" + Fragments2[indexS - 1].ListName[2].ToString() + "\t" + Fragments2[indexS - 1].ListName[3].ToString() + "\t" + Fragments2[indexS - 1].ListName[4].ToString());
        //                file.WriteLine("Selected:\t" + Fragments2[indexS - 1].To_plot.ToString());
        //                file.WriteLine("Color:\t" + Fragments2[indexS - 1].Color.ToColor().ToArgb());
        //            }
        //            foreach (double[] p in all_data[indexS]) file.WriteLine(p[0] + "\t" + p[1]);
        //        }
        //        file.Flush(); file.Close(); file.Dispose();
        //    }


        //}
        ////private void indexForm(object sender, EventArgs e)
        ////{
        ////    List<int> fromItems = new List<int>();
        ////    fromItems = ChemFormulas.Select(x => Int32.Parse(x.Index)).Distinct().OrderBy(p => p).ToList();
        ////    if ((sender as MenuItem).Text == "Index")
        ////    {
        ////        if (a_lstBox.Focused)
        ////        {
        ////            foreach (ChemiForm chem in ChemFormulas)
        ////            {
        ////                if (chem.Ion_type.Equals("a"))
        ////                {
        ////                    selectedIons.Add(chem);
        ////                }
        ////            }
        ////        }
        ////        if (b_lstBox.Focused) { MessageBox.Show("b"); }
        ////        if (c_lstBox.Focused) { MessageBox.Show("c"); }
        ////        if (x_lstBox.Focused) { MessageBox.Show("x"); }
        ////        if (y_lstBox.Focused) { MessageBox.Show("y"); }
        ////        if (z_lstBox.Focused) { MessageBox.Show("z"); }
        ////        if (dvw_lstBox.Focused) { MessageBox.Show("dvw"); }
        ////        if (addin_lstBox.Focused) { MessageBox.Show("addin"); }

        ////    }

        ////}
        //private void ChemToFrag(List<ChemiForm> initial, ref List<FragForm> final)
        //{
        //    foreach (ChemiForm chem in ChemFormulas)
        //    {
        //        if (chem.Error == false)
        //        {
        //            final.Add(new FragForm() { Adduct = chem.Adduct, Charge = chem.Charge, FinalFormula = chem.FinalFormula, Deduct = chem.Deduct, Error = chem.Error, Index = chem.Index, IndexTo = chem.IndexTo, InputFormula = chem.InputFormula, Ion = chem.Ion, Ion_type = chem.Ion_type, Machine = chem.Machine, Multiplier = chem.Multiplier, Mz = chem.Mz, Profile = chem.Profile, Radio_label = chem.Radio_label, Resolution = chem.Resolution });
        //        }
        //    }
        //}
        //private void fix_data_to_max_exp(double max_intensity, int candidate_fragments)
        //{
        //    List<double[]> new_data = new List<double[]>();
        //    double factor = 0.2 * max_exp / max_intensity;
        //    foreach (double[] d in all_data[candidate_fragments])
        //    {
        //        new_data.Add(new double[] { d[0], d[1] * factor });
        //    }
        //    all_data[candidate_fragments].Clear();
        //    all_data[candidate_fragments] = new_data;
        //}
        //private void fix_experimental_gaps()
        //{
        //    List<double[]> new_exp = new List<double[]>();
        //    double step = experimental[1][0] - experimental[0][0];
        //    new_exp.Add(new double[] { experimental[0][0], experimental[0][1] });
        //    for (int i = 1; i < experimental.Count; i++)
        //    {
        //        while (experimental[i][0] - new_exp.Last()[0] > step + 0.0001)
        //        {
        //            new_exp.Add(new double[] { new_exp.Last()[0] + step, 0.0 });
        //        }
        //        new_exp.Add(new double[] { experimental[i][0], experimental[i][1] });
        //    }
        //    current_experimental.Clear();
        //    current_experimental = new_exp;
        //}
        //private void fix_experimentalTo_100(double max_exp)
        //{
        //    List<double[]> new_exp = new List<double[]>();
        //    foreach (double[] exp in experimental)
        //    {
        //        new_exp.Add(new double[] { exp[0], exp[1] * 100 / max_exp });
        //    }
        //    experimental.Clear();
        //    experimental = new_exp;
        //}
        //private void add_x(ChemiForm chem, int max_charge, int list_index)
        //{
        //    double mass = double.Parse(chem.Mz, NumberStyles.AllowDecimalPoint);
        //    double mass_h = 1.007825;
        //    double mz = 0.0;
        //    int index = Convert.ToInt32(chem.Index);
        //    if (index <= 4 && max_charge > 2) max_charge = 2;
        //    else if (index <= 11 && index >= 5 && max_charge > 5) max_charge = 5;
        //    else if (index <= 22 && index >= 12 && max_charge > 8) max_charge = 8;
        //    else if (index <= 53 && index >= 23 && max_charge > 12) max_charge = 12;
        //    else if (index <= 75 && index >= 54 && max_charge > 15) max_charge = 15;
        //    else if (index <= 100 && index >= 76 && max_charge > 20) max_charge = 20;

        //    for (int c = 2; c <= max_charge; c++)
        //    {
        //        mz = (mass + (c - 1) * mass_h) / c;
        //        ChemFormulas.Add(new ChemiForm
        //        {
        //            InputFormula = chem.InputFormula,
        //            Adduct = 'H' + (c - 1).ToString(),
        //            Deduct = chem.Deduct,
        //            Multiplier = chem.Multiplier,
        //            Charge = c,
        //            Mz = mz.ToString(),
        //            Ion = chem.Ion,
        //            Ion_type = chem.Ion_type,
        //            Index = chem.Index,
        //            IndexTo = chem.IndexTo,
        //            Error = false,
        //            Elements_set = new List<Element_set>(),
        //            Iso_total_amount = 0,
        //            Monoisotopic = new CompoundMulti(),
        //            Points = new List<PointPlot>(),
        //            Machine = string.Empty,
        //            Resolution = new float(),
        //            Combinations = new List<Combination_1>(),
        //            Profile = new List<PointPlot>(),
        //            Centroid = new List<PointPlot>(),
        //            Combinations4 = new List<Combination_4>(),
        //            FinalFormula = string.Empty,
        //            PrintFormula = chem.PrintFormula,
        //            Radio_label = chem.Radio_label,
        //            Color = chem.Color,
        //            Name = string.Empty
        //        });

        //        var radioString = chem.Radio_label;
        //        var radio_name = string.Empty;
        //        if (ChemFormulas.Last().Charge > 0) radio_name = radioString + "_+" + ChemFormulas.Last().Charge.ToString();
        //        else radio_name = radioString + "_" + ChemFormulas.Last().Charge.ToString();
        //        ChemFormulas.Last().Name = radio_name;
        //    }
        //}
        //private void generate_x_multiChraged_withoutAducts()
        //{
        //    // max charge depends on lenght of the fragment. We will follow y-type rules
        //    // will run through all frags once to find x_idxs and max_charge for each y of different length

        //    List<int> x_idxs = new List<int>();
        //    List<int[]> max_charge_y = new List<int[]>();
        //    int tempo = 0;
        //    for (int i = 0; i < ChemFormulas.Count; i++)
        //    {
        //        if (ChemFormulas[i].Ion.StartsWith("x")) x_idxs.Add(i); //store x indexes
        //        else if (ChemFormulas[i].Ion.StartsWith("y"))
        //        {
        //            tempo++;
        //            int y_num = Convert.ToInt16(ChemFormulas[i].Index);
        //            int charge = ChemFormulas[i].Charge;

        //            if (max_charge_y.Count == 0 || max_charge_y.Find(p => p[0] == y_num) == null)
        //            {
        //                max_charge_y.Add(new int[] { y_num, charge });
        //            }
        //            else if (max_charge_y[max_charge_y.FindIndex(p => p[0] == y_num)][1] < charge)
        //            {
        //                max_charge_y[max_charge_y.FindIndex(p => p[0] == y_num)][1] = charge;
        //            }
        //        }
        //    }

        //    int temp = 0;

        //    for (int i = 0; i < x_idxs.Count; i++)
        //    {
        //        int x_num = Convert.ToInt16(ChemFormulas[i].Index);
        //        int max_charge = max_charge_y[max_charge_y.FindIndex(p => p[0] == x_num)][1];

        //        for (int j = 2; j < max_charge + 1; j++)
        //        {
        //            //add_fragment(); temp++;
        //        }
        //    }

        //    // copy results to clipboard
        //    max_charge_y = max_charge_y.OrderBy(p => p[0]).ToList();
        //    string export = "";
        //    for (int i = 0; i < max_charge_y.Count; i++)
        //    {
        //        export += max_charge_y[i][0] + " " + max_charge_y[i][1] + "\r\n";
        //    }
        //    Clipboard.SetText(export);
        //}

        //private void plot_peak()
        //{

        //    iso_plot.Model.Series.Add(new LineSeries() { StrokeThickness = 2, Color = OxyColors.Red, LineStyle = LineStyle.Dash });
        //    (iso_plot.Model.Series[2] as LineSeries).Title = "Peak";
        //    for (int j = 0; j < peak_points.Count; j++)
        //    {
        //        (iso_plot.Model.Series[2] as LineSeries).Points.Add(new OxyPlot.DataPoint(peak_points[j][1], peak_points[j][2]));
        //    }
        //    iso_plot.Model.InvalidatePlot(true);
        //}

        #endregion

        #endregion


        #region TAB DIAGRAMS
        public class CustomDataPoint : IScatterPointProvider
        {
            public double X { get; set; }
            public double Y { get; set; }
            public string Xreal { get; set; }
            public string Text { get; set; }
            public string Name { get; set; }
            public ScatterPoint GetScatterPoint() => new ScatterPoint(X, Y);
            public CustomDataPoint(double x, double y, string xreal, string t,string n)
            {
                X = x;
                Y = y;
                Xreal = xreal;
                Text = t;
                Name = n;
            }
        }
        public class CustomDataPointIndex : IDataPointProvider
        {
            public double X { get; set; }
            public double Y { get; set; }
            public string Ion { get; set; }
            public string Index { get; set; }
            public string Charge { get; set; }
            public string Intensity { get; set; }


            public DataPoint GetDataPoint() => new DataPoint(X, Y);
            public CustomDataPointIndex(double x, double y, string ionreal, string t,string c,string i)
            {
                X = x;
                Y = y;
                Ion = ionreal;
                Index = t;
                Charge = c;
                Intensity = i;
            }
        }

        private void tabFit_Leave(object sender, EventArgs e)
        {
            initialize_ions_todraw(); initialize_plot_tabs();
        }
        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12(this);
            frm12.ShowDialog();
        }

        private void style_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12(this);
            frm12.ShowDialog();
        }

        private void styleToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13(this);
            frm13.ShowDialog();
        }


        #region sequence
        

        private void ax_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ax_chBx.Checked)
            {
                ax_chBx.ForeColor = Color.ForestGreen;
                if (los_chkBox.Checked) { by_chBx.Checked = false;cz_chBx.Checked = false; intB_chBx.Checked = false; intA_chBx.Checked = false; }
            }
            else
            {
                ax_chBx.ForeColor = Control.DefaultForeColor;
            }
        }
        private void by_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (by_chBx.Checked)
            {
                by_chBx.ForeColor = Color.Blue;
                if (los_chkBox.Checked) { ax_chBx.Checked = false; cz_chBx.Checked = false; intB_chBx.Checked = false; intA_chBx.Checked = false; }

            }
            else
            {
                by_chBx.ForeColor = Control.DefaultForeColor;
            }
        }
        private void cz_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (cz_chBx.Checked)
            {
                cz_chBx.ForeColor = Color.Crimson;
                if (los_chkBox.Checked) { ax_chBx.Checked = false; by_chBx.Checked = false; intB_chBx.Checked = false; intA_chBx.Checked = false; }

            }
            else
            {
                cz_chBx.ForeColor = Control.DefaultForeColor;
            }
        }
        private void draw_Btn_Click(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh();
        }
        private void sequence_Pnl_Resize(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh();
        }
        private void sequence_draw(Graphics g)
        {
            //g = pnl.CreateGraphics();
            Pen p = new Pen(Color.Black);           
            int point_x, point_y;
            point_y =20;
            point_x = 3;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            Point pp = new Point(point_x, point_y);
            int grp_num = 25;
            if (rdBtn50.Checked) grp_num = 50;
            for (int idx = 0; idx < Peptide.Length; idx++)
            {
                g.DrawString(Peptide[idx].ToString(), sequence_Pnl.Font, sb, pp);                
                foreach (ion nn in IonDraw)
                {
                    Point temp_p = pp;
                    if (pp.X + 40 >= sequence_Pnl.Width) { temp_p.X = 3-18; temp_p.Y = temp_p.Y + 50; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = 3-18; temp_p.Y = temp_p.Y + 50; }
                    if (ax_chBx.Checked && (nn.Ion_type.StartsWith("a")|| nn.Ion_type.StartsWith("(a")) && nn.Index== idx + 1 )
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O")|| nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true,4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Green, g);
                            }
                        }
                        else if(!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))                          
                        {
                            draw_line(pp, true, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBx.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true,4,Color.DodgerBlue, g);
                            }
                            else
                            {
                                draw_line(pp, true,0,Color.Blue, g);
                            }
                        }
                        else if(!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBx.Checked &&( nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 8, nn.Color, g);
                        }
                    }
                    else if (ax_chBx.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) &&  (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Green, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBx.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.DodgerBlue, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Blue, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBx.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 8, nn.Color, g);
                        }
                    }
                    else if (nn.Ion_type.StartsWith("inter") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                    {
                        if (!los_chkBox.Checked)
                        {
                            if (intA_chBx.Checked && !nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                            else if (intB_chBx.Checked && nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                        }                        
                    }                    
                }
                pp.X = pp.X + 20;
                if (pp.X + 20 >= sequence_Pnl.Width){pp.X = 3; pp.Y =pp.Y+50;}
                if ((idx+1)% grp_num == 0) { pp.X = 3; pp.Y = pp.Y + 50; }
            }           

            return;
        }        
        private void draw_line(Point pf, bool up, int step, Color color_draw, Graphics g, bool inter = false)
        {
            int x1, x2, x3, y1, y2, y3;            
            Pen mypen = new Pen(color_draw,2F);
            if (inter){ x1 = pf.X +18; x2 = x1; y1 = pf.Y; y2 = y1 + 15; x3 = x2; y3 = y2;}
            else if (up) { x1 = pf.X +18; x2 = x1; y1 = pf.Y - step+3; y2 =y1 - 5 ; y3 = y2; x3 = x2 - 10;  }
            else { x1 = pf.X + 18; x2 = x1; y1 = pf.Y+14 + step+2; y2 =y1 +5; y3 = y2; x3 = x2 + 10;}
            Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            g.DrawLines(mypen,points);
        }
       
        private void sequence_Pnl_Paint(object sender, PaintEventArgs e)
        {
            
            /*if (IonDraw.Count > 0) {*/ sequence_draw(e.Graphics); /*}*/
        }

        private void rdBtn25_CheckedChanged(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh();
        }

        private void rdBtn50_CheckedChanged(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh();
        }
        private void los_chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (los_chkBox.Checked) { ax_chBx.Checked = false; by_chBx.Checked = false; cz_chBx.Checked = false; intB_chBx.Checked = false; intA_chBx.Checked = false; intB_chBx.Enabled = false; intA_chBx.Enabled = false; }
            else { intB_chBx.Enabled = true; intA_chBx.Enabled = true; }

        }
        #endregion

        #region sequence panels copies
        #region sequence copy 1
        private void ax_chBxCopy1_CheckedChanged(object sender, EventArgs e)
        {
            if (ax_chBxCopy1.Checked)
            {
                ax_chBxCopy1.ForeColor = Color.ForestGreen;
                if (los_chkBoxCopy1.Checked) { by_chBxCopy1.Checked = false; cz_chBxCopy1.Checked = false; intB_chBxCopy1.Checked = false; intA_chBxCopy1.Checked = false; }
            }
            else
            {
                ax_chBxCopy1.ForeColor = Control.DefaultForeColor;
            }
        }
        private void by_chBxCopy1_CheckedChanged(object sender, EventArgs e)
        {
            if (by_chBxCopy1.Checked)
            {
                by_chBxCopy1.ForeColor = Color.Blue;
                if (los_chkBoxCopy1.Checked) { ax_chBxCopy1.Checked = false; cz_chBxCopy1.Checked = false; intB_chBxCopy1.Checked = false; intA_chBxCopy1.Checked = false; }

            }
            else
            {
                by_chBxCopy1.ForeColor = Control.DefaultForeColor;
            }
        }
        private void cz_chBxCopy1_CheckedChanged(object sender, EventArgs e)
        {
            if (cz_chBxCopy1.Checked)
            {
                cz_chBxCopy1.ForeColor = Color.Crimson;
                if (los_chkBoxCopy1.Checked) { by_chBxCopy1.Checked = false; ax_chBxCopy1.Checked = false; intB_chBxCopy1.Checked = false; intA_chBxCopy1.Checked = false; }

            }
            else
            {
                cz_chBxCopy1.ForeColor = Control.DefaultForeColor;
            }
        }
        private void draw_BtnCopy1_Click(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh();
        }
        private void rdBtn25Copy1_CheckedChanged(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh();
        }

        private void rdBtn50Copy1_CheckedChanged(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh();
        }
        private void sequence_PnlCopy1_Paint(object sender, PaintEventArgs e)
        {
            sequence_drawCopy1(e.Graphics);
        }
        private void sequence_drawCopy1(Graphics g)
        {
            //g = pnl.CreateGraphics();
            Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = 20;
            point_x = 3;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            Point pp = new Point(point_x, point_y);
            int grp_num = 25;
            if (rdBtn50Copy1.Checked) grp_num = 50;
            for (int idx = 0; idx < Peptide.Length; idx++)
            {
                g.DrawString(Peptide[idx].ToString(), sequence_PnlCopy1.Font, sb, pp);
                foreach (ion nn in IonDraw)
                {
                    Point temp_p = pp;
                    if (pp.X + 40 >= sequence_Pnl.Width) { temp_p.X = 3 - 18;  temp_p.Y = temp_p.Y + 50; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = 3 - 18;  temp_p.Y = temp_p.Y + 50; }
                    if (ax_chBxCopy1.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Green, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBxCopy1.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.DodgerBlue, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Blue, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBxCopy1.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 8, nn.Color, g);
                        }
                    }
                    else if (ax_chBxCopy1.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Green, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBxCopy1.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.DodgerBlue, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Blue, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBxCopy1.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 8, nn.Color, g);
                        }
                    }
                    else if (nn.Ion_type.StartsWith("inter") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                    {
                        if (!los_chkBoxCopy1.Checked)
                        {
                            if (intA_chBxCopy1.Checked && !nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                            else if (intB_chBxCopy1.Checked && nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                        }                           
                    }
                }
                pp.X = pp.X + 20;
                if (pp.X + 20 >= sequence_PnlCopy1.Width) { pp.X = 3; pp.Y = pp.Y + 50; }
                if ((idx + 1) % grp_num == 0) { pp.X = 3; pp.Y = pp.Y + 50; }
            }

            return;
        }
        private void sequence_PnlCopy1_Resize(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh();
        }
        private void delele_sequencePnl1_Click(object sender, EventArgs e)
        {
            draw_sequence_panelCopy1.Visible = false;
        }
        private void los_chkBoxCopy1_CheckedChanged(object sender, EventArgs e)
        {
            if (los_chkBoxCopy1.Checked) { ax_chBxCopy1.Checked = false; by_chBxCopy1.Checked = false; cz_chBxCopy1.Checked = false; intB_chBxCopy1.Checked = false; intA_chBxCopy1.Checked = false; intB_chBxCopy1.Enabled = false; intA_chBxCopy1.Enabled = false; }
            else { intB_chBxCopy1.Enabled = true; intA_chBxCopy1.Enabled = true; }
        }

        #endregion

        #region sequence copy 2
        private void ax_chBxCopy2_CheckedChanged(object sender, EventArgs e)
        {
            if (ax_chBxCopy2.Checked)
            {
                ax_chBxCopy2.ForeColor = Color.ForestGreen;
                if (los_chkBoxCopy2.Checked) { by_chBxCopy2.Checked = false; cz_chBxCopy2.Checked = false; intB_chBxCopy2.Checked = false; intA_chBxCopy2.Checked = false; }
            }
            else
            {
                ax_chBxCopy2.ForeColor = Control.DefaultForeColor;
            }
        }
        private void by_chBxCopy2_CheckedChanged(object sender, EventArgs e)
        {
            if (by_chBxCopy2.Checked)
            {
                by_chBxCopy2.ForeColor = Color.Blue;
                if (los_chkBoxCopy2.Checked) { ax_chBxCopy2.Checked = false; cz_chBxCopy2.Checked = false; intB_chBxCopy2.Checked = false; intA_chBxCopy2.Checked = false; }

            }
            else
            {
                by_chBxCopy2.ForeColor = Control.DefaultForeColor;
            }
        }

        private void cz_chBxCopy2_CheckedChanged(object sender, EventArgs e)
        {
            if (cz_chBxCopy2.Checked)
            {
                cz_chBxCopy2.ForeColor = Color.Crimson;
                if (los_chkBoxCopy2.Checked) { by_chBxCopy2.Checked = false; ax_chBxCopy2.Checked = false; intB_chBxCopy2.Checked = false; intA_chBxCopy2.Checked = false; }

            }
            else
            {
                cz_chBxCopy2.ForeColor = Control.DefaultForeColor;
            }
        }
        private void draw_BtnCopy2_Click(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh();
        }

        private void rdBtn25Copy2_CheckedChanged(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh();
        }

        private void rdBtn50Copy2_CheckedChanged(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh();
        }

        private void sequence_PnlCopy2_Paint(object sender, PaintEventArgs e)
        {
            sequence_drawCopy2(e.Graphics);
        }

        private void sequence_drawCopy2(Graphics g)
        {
            //g = pnl.CreateGraphics();
            Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = 20;
            point_x = 3;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            int grp_num = 25;
            Point pp = new Point(point_x, point_y);
            if (rdBtn50Copy2.Checked) grp_num = 50;

            for (int idx = 0; idx < Peptide.Length; idx++)
            {
                g.DrawString(Peptide[idx].ToString(), sequence_PnlCopy2.Font, sb, pp);
                foreach (ion nn in IonDraw)
                {
                    Point temp_p = pp;
                    if (pp.X + 40 >= sequence_Pnl.Width) { temp_p.X = 3 - 18; temp_p.Y = temp_p.Y + 50; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = 3 - 18; temp_p.Y = temp_p.Y + 50; }
                    if (ax_chBxCopy2.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy2.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Green, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBxCopy2.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy2.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.DodgerBlue, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Blue, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBxCopy2.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBoxCopy2.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(pp, true, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(pp, true, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(pp, true, 8, nn.Color, g);
                        }
                    }
                    else if (ax_chBxCopy2.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy2.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.LimeGreen, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Green, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 0, nn.Color, g);
                        }
                    }
                    else if (by_chBxCopy2.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy2.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.DodgerBlue, g);

                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Blue, g);

                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 4, nn.Color, g);
                        }
                    }
                    else if (cz_chBxCopy2.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (Peptide.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBoxCopy1.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3"))
                            {
                                draw_line(temp_p, false, 4, Color.Tomato, g);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0, Color.Firebrick, g);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3"))
                        {
                            draw_line(temp_p, false, 8, nn.Color, g);
                        }
                    }
                    else if (nn.Ion_type.StartsWith("inter") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                    {
                        if (!los_chkBoxCopy2.Checked)
                        {
                            if (intA_chBxCopy2.Checked && !nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                            else if (intB_chBxCopy2.Checked && nn.Ion_type.Contains("b"))
                            {
                                draw_line(pp, false, 0, nn.Color, g, true);
                            }
                        }                            
                    }
                }
                pp.X = pp.X + 20;
                if (pp.X + 20 >= sequence_PnlCopy2.Width) { pp.X = 3; pp.Y = pp.Y + 50; }
                if ((idx + 1) % grp_num == 0) { pp.X = 3; pp.Y = pp.Y + 50; }
            }

            return;
        }
        private void sequence_PnlCopy2_Resize(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh();
        }


        private void delele_sequencePnl2_Click(object sender, EventArgs e)
        {
            draw_sequence_panelCopy2.Visible = false;
        }

        private void los_chkBoxCopy2_CheckedChanged(object sender, EventArgs e)
        {
            if (los_chkBoxCopy2.Checked) { ax_chBxCopy2.Checked = false; by_chBxCopy2.Checked = false; cz_chBxCopy2.Checked = false; intB_chBxCopy2.Checked = false; intA_chBxCopy2.Checked = false; intB_chBxCopy2.Enabled = false; intA_chBxCopy2.Enabled = false; }
            else { intB_chBxCopy2.Enabled = true; intA_chBxCopy2.Enabled = true; }
        }
        #endregion

        private void add_sequencePanel1_Click(object sender, EventArgs e)
        {
            if (draw_sequence_panelCopy1.Visible != true) { draw_sequence_panelCopy1.Visible = true; }
            else { draw_sequence_panelCopy2.Visible = true; }
        }

        #endregion

        #region fragments' diagrams
        private void initialize_tabs()
        {
            #region plotview initilization
            // ax plot
            if (ax_plot != null) ax_plot.Dispose();
            ax_plot = new PlotView() { Name = "ax_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            ax_Pnl.Controls.Add(ax_plot);
            PlotModel ax_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "a - x  fragments", TitleColor = OxyColors.Green};
            ax_plot.Model = ax_model;
            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12,TickStyle=Y_tick12, StringFormat = y_format12 + y_numformat12,IntervalLength=y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            ax_model.Axes.Add(linearAxis1);
            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12,MinorStep=x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            ax_model.Axes.Add(linearAxis2);
            //ax_model.Updated += (s, e) => { if (Math.Abs(linearAxis1.ActualMaximum) > Math.Abs(linearAxis1.ActualMinimum)) { linearAxis1.Zoom(-Math.Abs(linearAxis1.ActualMaximum), Math.Abs(linearAxis1.ActualMaximum)); } else { linearAxis1.Zoom(-Math.Abs(linearAxis1.ActualMinimum), Math.Abs(linearAxis1.ActualMinimum)); } ax_plot.InvalidatePlot(true); };
            ax_plot.MouseDoubleClick += (s, e) => { ax_model.ResetAllAxes(); ax_plot.InvalidatePlot(true); };

            // by plot
            if (by_plot != null) by_plot.Dispose();
            by_plot = new PlotView() { Name = "by_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            by_Pnl.Controls.Add(by_plot);
            PlotModel by_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "b - y  fragments", TitleColor = OxyColors.Blue };
            by_plot.Model = by_model;
            var linearAxis3 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            by_model.Axes.Add(linearAxis3);
            var linearAxis4 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            by_model.Axes.Add(linearAxis4);
            //by_model.Updated += (s, e) => { if (Math.Abs(linearAxis3.ActualMaximum) > Math.Abs(linearAxis3.ActualMinimum)) { linearAxis3.Zoom(-Math.Abs(linearAxis3.ActualMaximum), Math.Abs(linearAxis3.ActualMaximum)); } else { linearAxis3.Zoom(-Math.Abs(linearAxis3.ActualMinimum), Math.Abs(linearAxis3.ActualMinimum)); } by_plot.InvalidatePlot(true); };
            by_plot.MouseDoubleClick += (s, e) => { by_model.ResetAllAxes(); by_plot.InvalidatePlot(true); };

            // cz plot
            if (cz_plot != null) cz_plot.Dispose();
            cz_plot = new PlotView() { Name = "cz_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            cz_Pnl.Controls.Add(cz_plot);
            PlotModel cz_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "c - z  fragments", TitleColor = OxyColors.Red };
            cz_plot.Model = cz_model;
            var linearAxis5 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            cz_model.Axes.Add(linearAxis5);
            var linearAxis6 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            cz_model.Axes.Add(linearAxis6);
            //cz_model.Updated += (s, e) => { if (Math.Abs(linearAxis5.ActualMaximum) > Math.Abs(linearAxis5.ActualMinimum)) { linearAxis5.Zoom(-Math.Abs(linearAxis5.ActualMaximum), Math.Abs(linearAxis5.ActualMaximum)); } else { linearAxis5.Zoom(-Math.Abs(linearAxis5.ActualMinimum), Math.Abs(linearAxis5.ActualMinimum)); } cz_plot.InvalidatePlot(true); };
            cz_plot.MouseDoubleClick += (s, e) => { cz_model.ResetAllAxes(); cz_plot.InvalidatePlot(true); };

            // ax charge plot
            if (axCharge_plot != null) axCharge_plot.Dispose();
            axCharge_plot = new PlotView() { Name = "axCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            axCharge_Pnl.Controls.Add(axCharge_plot);
            PlotModel axCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true,LegendOrientation=LegendOrientation.Horizontal,LegendPosition=LegendPosition.TopCenter,LegendPlacement=LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "a - x  fragments", TitleColor = OxyColors.Green };
            axCharge_plot.Model = axCharge_model;
            var linearAxis15 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle =Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            axCharge_model.Axes.Add(linearAxis15);
            var linearAxis16 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize =10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            axCharge_model.Axes.Add(linearAxis16);
            axCharge_plot.MouseDoubleClick += (s, e) => { axCharge_model.ResetAllAxes(); axCharge_plot.InvalidatePlot(true); };

            // by charge plot
            if (byCharge_plot != null) byCharge_plot.Dispose();
            byCharge_plot = new PlotView() { Name = "byCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            byCharge_Pnl.Controls.Add(byCharge_plot);
            PlotModel byCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "b - y  fragments", TitleColor = OxyColors.Blue };
            byCharge_plot.Model = byCharge_model;
            var linearAxis17 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            byCharge_model.Axes.Add(linearAxis17);
            var linearAxis18 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            byCharge_model.Axes.Add(linearAxis18);
            byCharge_plot.MouseDoubleClick += (s, e) => { byCharge_model.ResetAllAxes(); byCharge_plot.InvalidatePlot(true); };

            // cz charge plot
            if (czCharge_plot != null) czCharge_plot.Dispose();
            czCharge_plot = new PlotView() { Name = "czCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            czCharge_Pnl.Controls.Add(czCharge_plot);
            PlotModel czCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "c - z  fragments", TitleColor = OxyColors.Red };
            czCharge_plot.Model = czCharge_model;
            var linearAxis19 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            czCharge_model.Axes.Add(linearAxis19);
            var linearAxis20 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            czCharge_model.Axes.Add(linearAxis20);
            czCharge_plot.MouseDoubleClick += (s, e) => { czCharge_model.ResetAllAxes(); czCharge_plot.InvalidatePlot(true); };

            //internal fragments plots
            // index plot
            if (index_plot != null) index_plot.Dispose();
            index_plot = new PlotView() { Name = "index_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxPnl1.Controls.Add(index_plot);
            PlotModel index_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "internal  fragments' plot sorted by #AA initial", TitleColor = OxyColors.Teal };
            index_plot.Model = index_model;
            var linearAxis7 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13,MinorGridlineStyle=Yint_minor_grid13,MajorStep=yINT_majorStep13,MinorStep=yINT_minorStep13,TickStyle=Yint_tick13, FontSize =10, AxisTitleDistance = 7, MinimumMinorStep = 1.0, TitleFontSize = 11, Title = " # fragments" };
            index_model.Axes.Add(linearAxis7);
            var linearAxis8 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, MajorStep = xINT_majorStep13, MinorStep = xINT_minorStep13, TickStyle = Xint_tick13, FontSize =10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            index_model.Axes.Add(linearAxis8);
            index_plot.MouseDoubleClick += (s, e) => { index_model.ResetAllAxes(); index_plot.InvalidatePlot(true); };
            // index intensity plot
            if (indexIntensity_plot != null) indexIntensity_plot.Dispose();
            indexIntensity_plot = new PlotView() { Name = "indexIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxInt_Pnl1.Controls.Add(indexIntensity_plot);
            PlotModel indexIntensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial",  IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            indexIntensity_plot.Model = indexIntensity_model;
            var linearAxis11 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0, Position = OxyPlot.Axes.AxisPosition.Left };
            indexIntensity_model.Axes.Add(linearAxis11);
            var linearAxis12 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength=x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            indexIntensity_model.Axes.Add(linearAxis12);
            indexIntensity_plot.MouseDoubleClick += (s, e) => { indexIntensity_model.ResetAllAxes(); indexIntensity_plot.InvalidatePlot(true); };
            //bind the 2 axes
            linearAxis7.AxisChanged += (s, e) => { linearAxis11.Zoom(linearAxis7.ActualMinimum, linearAxis7.ActualMaximum); indexIntensity_plot.InvalidatePlot(true); };
            index_model.Updated += (s, e) => { indexIntensity_plot.Model.Axes[0].Zoom(index_plot.Model.Axes[0].ActualMinimum, index_plot.Model.Axes[0].ActualMaximum); };

            // indexTo plot
            if (indexto_plot != null) indexto_plot.Dispose();
            indexto_plot = new PlotView() { Name = "indexto_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxPnl2.Controls.Add(indexto_plot);
            PlotModel indexto_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "internal  fragments' plot sorted by #AA terminal", TitleColor = OxyColors.Teal };
            indexto_plot.Model = indexto_model;
            var linearAxis9 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0, AxisTitleDistance = 7, TitleFontSize = 11, Title = "# fragments" };
            indexto_model.Axes.Add(linearAxis9);
            var linearAxis10 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, MajorStep = xINT_majorStep13, MinorStep = xINT_minorStep13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            indexto_model.Axes.Add(linearAxis10);
            indexto_plot.MouseDoubleClick += (s, e) => { indexto_model.ResetAllAxes(); indexto_plot.InvalidatePlot(true); };
            // indexTo intensity plot
            if (indextoIntensity_plot != null) indextoIntensity_plot.Dispose();
            indextoIntensity_plot = new PlotView() { Name = "indextoIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxInt_Pnl2.Controls.Add(indextoIntensity_plot);
            PlotModel indextoIntensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            indextoIntensity_plot.Model = indextoIntensity_model;
            var linearAxis13 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0};
            indextoIntensity_model.Axes.Add(linearAxis13);
            var linearAxis14 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength = x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            indextoIntensity_model.Axes.Add(linearAxis14);
            indextoIntensity_plot.MouseDoubleClick += (s, e) => { indextoIntensity_model.ResetAllAxes(); indextoIntensity_plot.InvalidatePlot(true); };
            //bind the 2 axes
            linearAxis9.AxisChanged += (s, e) => { linearAxis13.Zoom(linearAxis9.ActualMinimum, linearAxis9.ActualMaximum); indextoIntensity_plot.InvalidatePlot(true); };
            indexto_model.Updated += (s, e) => { indextoIntensity_plot.Model.Axes[0].Zoom(indexto_plot.Model.Axes[0].ActualMinimum, indexto_plot.Model.Axes[0].ActualMaximum); };


            //PPM plot
            if (ppm_plot != null) ppm_plot.Dispose();
            ppm_plot = new PlotView() { Name = "ppm_plot", BackColor = Color.White, Dock=DockStyle.Fill};
            ppm_panel.Controls.Add(ppm_plot);
            PlotModel ppm_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "ppm Error of each fragment", TitleColor = OxyColors.Teal,SubtitleFontSize=10,SubtitleFont = "Arial" };
            ppm_plot.Model = ppm_model;
            var linearAxis21 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "ppm Error" };
            ppm_model.Axes.Add(linearAxis21);
            var linearAxis22 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, FontSize = 10, MinimumMinorStep = 1.0, AxisTitleDistance = 7, TitleFontSize = 11, Title = "# fragments", Position = OxyPlot.Axes.AxisPosition.Bottom };
            ppm_model.Axes.Add(linearAxis22);
            ppm_plot.MouseDoubleClick += (s, e) => { ppm_model.ResetAllAxes(); ppm_plot.InvalidatePlot(true); };

            #endregion

            #region toolstrip save-copy etc initiliazation
            axSave_Btn.Click += (s, e) => { export_copy_plot(false, ax_plot); }; axCopy_Btn.Click += (s, e) => { export_copy_plot(true, ax_plot); };
            bySave_Btn.Click += (s, e) => { export_copy_plot(false, by_plot); }; byCopy_Btn.Click += (s, e) => { export_copy_plot(true, by_plot); };
            czSave_Btn.Click += (s, e) => { export_copy_plot(false, cz_plot); }; czCopy_Btn.Click += (s, e) => { export_copy_plot(true, cz_plot); };

            axChargeSave_Btn.Click += (s, e) => { export_copy_plot(false, axCharge_plot); }; axChargeCopy_Btn.Click += (s, e) => { export_copy_plot(true, axCharge_plot); };
            byChargeSave_Btn.Click += (s, e) => { export_copy_plot(false, byCharge_plot); }; byChargeCopy_Btn.Click += (s, e) => { export_copy_plot(true, byCharge_plot); };
            czChargeSave_Btn.Click += (s, e) => { export_copy_plot(false, czCharge_plot); }; czChargeCopy_Btn.Click += (s, e) => { export_copy_plot(true, czCharge_plot); };

            a_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };
            b_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };
            c_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };
            x_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };
            y_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };
            z_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(); };

            //sequence
            seqSave_Btn.Click += (s, e) => { export_panel(false, sequence_Pnl); };
            seqCopy_Btn.Click += (s, e) => { export_panel(true, sequence_Pnl); };
            //sequence copy1
            seqSave_BtnCopy1.Click += (s, e) => { export_panel(false, sequence_PnlCopy1); };
            seqCopy_BtnCopy1.Click += (s, e) => { export_panel(true, sequence_PnlCopy1); };
            //sequence copy2
            seqSave_BtnCopy2.Click += (s, e) => { export_panel(false, sequence_PnlCopy2); };
            seqCopy_BtnCopy2.Click += (s, e) => { export_panel(true, sequence_PnlCopy2); };

            int_IdxCopy_Btn.Click += (s, e) => { export_panel(true, panel1_intIdx); };
            int_IdxSave_Btn.Click += (s, e) => { export_panel(false, panel1_intIdx); };

            int_IdxToCopy_Btn.Click += (s, e) => { export_panel(true, panel1_intIdx); };
            int_IdxToSave_Btn.Click += (s, e) => { export_panel(false, panel1_intIdx); };

            ppmSave_Btn.Click += (s, e) => { export_copy_plot(false, ppm_plot); }; ppmCopy_Btn.Click += (s, e) => { export_copy_plot(true, ppm_plot); };
            #endregion

        }

        private void initialize_ions_todraw()
        {
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            check_duplicate_ions();
        }

        private void initialize_plot_tabs()
        {           

            #region initialize graphics
            if (ax_plot.Model.Series != null) { ppm_plot.Model.Series.Clear(); ax_plot.Model.Series.Clear(); by_plot.Model.Series.Clear(); cz_plot.Model.Series.Clear(); axCharge_plot.Model.Series.Clear(); byCharge_plot.Model.Series.Clear(); czCharge_plot.Model.Series.Clear(); }

            if (index_plot.Model.Series != null) { ppm_plot.Model.Series.Clear(); index_plot.Model.Series.Clear(); indexto_plot.Model.Series.Clear(); indexIntensity_plot.Model.Series.Clear(); indextoIntensity_plot.Model.Series.Clear(); }
            //
            LinearBarSeries a_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.Green, FillColor = OxyColors.Green, BarWidth = bar_width };
            LinearBarSeries x_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.LimeGreen, FillColor = OxyColors.LimeGreen, BarWidth = bar_width };
            LinearBarSeries b_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.Blue, FillColor = OxyColors.Blue, BarWidth = bar_width };
            LinearBarSeries y_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.DodgerBlue, FillColor = OxyColors.DodgerBlue, BarWidth = bar_width };
            LinearBarSeries c_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.Firebrick, FillColor = OxyColors.Firebrick, BarWidth = bar_width };
            LinearBarSeries z_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.Tomato, FillColor = OxyColors.Tomato, BarWidth = bar_width };            
            ax_plot.Model.Series.Add(a_bar); ax_plot.Model.Series.Add(x_bar); by_plot.Model.Series.Add(b_bar); by_plot.Model.Series.Add(y_bar); cz_plot.Model.Series.Add(c_bar); cz_plot.Model.Series.Add(z_bar);
            //
            ScatterSeries ppm_series = new ScatterSeries() { MarkerSize = 2, Title = "ppm_series", MarkerType = MarkerType.Circle, MarkerFill = OxyColors.Teal };
             
            //
            ScatterSeries a_10 = new ScatterSeries() { MarkerSize = 2, Title = "a 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Green).ToOxyColor() };
            ScatterSeries a_100 = new ScatterSeries() { MarkerSize = 3, Title = "a 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Green).ToOxyColor() };
            ScatterSeries a_1000 = new ScatterSeries() { MarkerSize = 4, Title = "a 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Green).ToOxyColor() };
            ScatterSeries a_10000 = new ScatterSeries() { MarkerSize = 5, Title = "a 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Green).ToOxyColor() };
            ScatterSeries a_100000 = new ScatterSeries() { MarkerSize =6, Title = "a 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Green).ToOxyColor() };
            ScatterSeries a_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "a 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Green).ToOxyColor() };
            ScatterSeries a_10000000 = new ScatterSeries() { MarkerSize =8, Title = "a 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Green).ToOxyColor() };
            ScatterSeries a_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "a 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Green).ToOxyColor() };
            ScatterSeries a_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "a 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Green).ToOxyColor() };
            ScatterSeries a_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "a 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Green).ToOxyColor() }; 
            ScatterSeries b_10 = new ScatterSeries() { MarkerSize = 2, Title = "b 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Blue).ToOxyColor() };
            ScatterSeries b_100 = new ScatterSeries() { MarkerSize = 3, Title = "b 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Blue).ToOxyColor() };
            ScatterSeries b_1000 = new ScatterSeries() { MarkerSize = 4, Title = "b 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Blue).ToOxyColor() };
            ScatterSeries b_10000 = new ScatterSeries() { MarkerSize = 5, Title = "b 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Blue).ToOxyColor() };
            ScatterSeries b_100000 = new ScatterSeries() { MarkerSize = 6, Title = "b 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Blue).ToOxyColor() };
            ScatterSeries b_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "b 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Blue).ToOxyColor() };
            ScatterSeries b_10000000 = new ScatterSeries() { MarkerSize =8, Title = "b 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Blue).ToOxyColor() };
            ScatterSeries b_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "b 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Blue).ToOxyColor() };
            ScatterSeries b_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "b 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Blue).ToOxyColor() };
            ScatterSeries b_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "b 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Blue).ToOxyColor() };
            ScatterSeries c_10 = new ScatterSeries() { MarkerSize = 2, Title = "c 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_100 = new ScatterSeries() { MarkerSize = 3, Title = "c 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_1000 = new ScatterSeries() { MarkerSize = 4, Title = "c 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_10000 = new ScatterSeries() { MarkerSize = 5, Title = "c 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_100000 = new ScatterSeries() { MarkerSize = 6, Title = "c 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "c 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "c 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "c 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "c 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Firebrick).ToOxyColor() };
            ScatterSeries c_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "c 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Firebrick).ToOxyColor() };
            ScatterSeries x_10 = new ScatterSeries() { MarkerSize = 2, Title = "x 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_100 = new ScatterSeries() { MarkerSize = 3, Title = "x 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_1000 = new ScatterSeries() { MarkerSize = 4, Title = "x 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_10000 = new ScatterSeries() { MarkerSize = 5, Title = "x 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_100000 = new ScatterSeries() { MarkerSize =6, Title = "x 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "x 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_10000000 = new ScatterSeries() { MarkerSize =8, Title = "x 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_100000000 = new ScatterSeries() { MarkerSize =9, Title = "x 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "x 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.LimeGreen).ToOxyColor() };
            ScatterSeries x_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "x 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.LimeGreen).ToOxyColor() };
            ScatterSeries y_10 = new ScatterSeries() { MarkerSize = 2, Title = "y 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_100 = new ScatterSeries() { MarkerSize = 3, Title = "y 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_1000 = new ScatterSeries() { MarkerSize = 4, Title = "y 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_10000 = new ScatterSeries() { MarkerSize = 5, Title = "y 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_100000 = new ScatterSeries() { MarkerSize = 6, Title = "y 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "y 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "y 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "y 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "y 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries y_10000000000 = new ScatterSeries() { MarkerSize =11, Title = "y 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.DodgerBlue).ToOxyColor() };
            ScatterSeries z_10 = new ScatterSeries() { MarkerSize = 2, Title = "z 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Tomato).ToOxyColor() };
            ScatterSeries z_100 = new ScatterSeries() { MarkerSize = 3, Title = "z 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Tomato).ToOxyColor() };
            ScatterSeries z_1000 = new ScatterSeries() { MarkerSize = 4, Title = "z 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Tomato).ToOxyColor() };
            ScatterSeries z_10000 = new ScatterSeries() { MarkerSize = 5, Title = "z 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Tomato).ToOxyColor() };
            ScatterSeries z_100000 = new ScatterSeries() { MarkerSize = 6, Title = "z 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Tomato).ToOxyColor() };
            ScatterSeries z_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "z 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Tomato).ToOxyColor() };
            ScatterSeries z_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "z 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Tomato).ToOxyColor() };
            ScatterSeries z_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "z 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Tomato).ToOxyColor() };
            ScatterSeries z_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "z 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Tomato).ToOxyColor() };
            ScatterSeries z_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "z 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Tomato).ToOxyColor() };
            #endregion

            int iondraw_count = IonDraw.Count;
            double max_i = 0.0;
            List<CustomDataPoint> points_index = new List<CustomDataPoint>();
            List<CustomDataPoint> points_indexTo = new List<CustomDataPoint>();
            List<double[]> merged_a = new List<double[]>();
            List<double[]> merged_b = new List<double[]>();
            List<double[]> merged_c = new List<double[]>();
            List<double[]> merged_x = new List<double[]>();
            List<double[]> merged_y = new List<double[]>();
            List<double[]> merged_z = new List<double[]>();
            List<ion> charge_merged_a = new List<ion>();
            List<ion> charge_merged_b = new List<ion>();
            List<ion> charge_merged_c = new List<ion>();
            List<ion> charge_merged_x = new List<ion>();
            List<ion> charge_merged_y = new List<ion>();
            List<ion> charge_merged_z = new List<ion>();
            if (IonDrawIndexTo.Count > 0) { IonDrawIndexTo.Clear(); }
            double max_a = 5000, max_b = 5000, max_c = 5000;
            double maxcharge_a = 0, maxcharge_b = 0, maxcharge_c = 0;
            var ppmpoints =new CustomDataPoint[iondraw_count];
            List<CustomDataPoint> points_a_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_a_10000000000 = new List<CustomDataPoint>();
            List<CustomDataPoint> points_b_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_b_10000000000 = new List<CustomDataPoint>();
            List<CustomDataPoint> points_c_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_c_10000000000 = new List<CustomDataPoint>();
            List<CustomDataPoint> points_x_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_x_10000000000 = new List<CustomDataPoint>();
            List<CustomDataPoint> points_y_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_y_10000000000 = new List<CustomDataPoint>();
            List<CustomDataPoint> points_z_10 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_100 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_1000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_10000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_100000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_1000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_10000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_100000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_1000000000 = new List<CustomDataPoint>();            List<CustomDataPoint> points_z_10000000000 = new List<CustomDataPoint>();
            //fill the list with the correct ions
            for (int i=0;i< iondraw_count ; i++)
            {
                ion nn = IonDraw[i];
                ppmpoints[i]=new CustomDataPoint(i+1, nn.PPM_Error, nn.Index.ToString(), nn.Mz,nn.Name);
                if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                {
                    if((!nn.Ion_type.Contains("H2O")&& !nn.Ion_type.Contains("NH3")) || search_primary("a", nn.SortIdx))
                    {
                        if (merged_a.Count == 0 || (int)merged_a.Last()[0] != nn.SortIdx)
                        {
                            merged_a.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                            charge_merged_a.Add(new ion {SortIdx= nn.SortIdx, Charge=nn.Charge,Index= nn.Index, Mz = nn.Mz, Max_intensity= nn.Max_intensity, Name=nn.Name });
                        }                       
                        else
                        {
                            merged_a.Last()[1] += nn.Max_intensity;
                            if (charge_merged_a.Last().Charge==nn.Charge) { charge_merged_a.Last().Max_intensity += nn.Max_intensity; charge_merged_a.Last().Mz +=" , "+ nn.Mz; charge_merged_a.Last().Name += " , " + nn.Name; }
                            else { charge_merged_a.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_a < merged_a.Last()[1]) { max_a = merged_a.Last()[1]; }
                        if (maxcharge_a < nn.Charge) { maxcharge_a = nn.Charge; }
                    }                    
                }
                else if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("b", nn.SortIdx))
                    {                       
                        if (merged_b.Count == 0 || (int)merged_b.Last()[0] != nn.SortIdx)
                        {
                            merged_b.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                            charge_merged_b.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name });
                        }
                        else
                        {
                            merged_b.Last()[1] += nn.Max_intensity;
                            if (charge_merged_b.Last().Charge == nn.Charge) { charge_merged_b.Last().Max_intensity += nn.Max_intensity; charge_merged_b.Last().Mz += " , " + nn.Mz; charge_merged_b.Last().Name += " , " + nn.Name; }
                            else { charge_merged_b.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_b < merged_b.Last()[1]) { max_b = merged_b.Last()[1]; }
                        if (maxcharge_b < nn.Charge) { maxcharge_b = nn.Charge; }
                    }                    
                }
                else if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("c", nn.SortIdx))
                    {                        
                        if (merged_c.Count == 0 || (int)merged_c.Last()[0] != nn.SortIdx)
                        {
                            merged_c.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                            charge_merged_c.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name });
                        }
                        else
                        {
                            merged_c.Last()[1] += nn.Max_intensity;
                            if (charge_merged_c.Last().Charge == nn.Charge) { charge_merged_c.Last().Max_intensity += nn.Max_intensity; charge_merged_c.Last().Mz += " , " + nn.Mz; charge_merged_c.Last().Name += " , " + nn.Name; }
                            else { charge_merged_c.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_c < merged_c.Last()[1]) { max_c = merged_c.Last()[1]; }
                        if (maxcharge_c < nn.Charge) { maxcharge_c = nn.Charge; }
                    }                    
                }
                else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("x", nn.SortIdx))
                    {                        
                        if (merged_x.Count == 0 || (int)merged_x.Last()[0] != nn.SortIdx)
                        {
                            merged_x.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                            charge_merged_x.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name });
                        }
                        else
                        {
                            merged_x.Last()[1] -= nn.Max_intensity;
                            if (charge_merged_x.Last().Charge == nn.Charge) { charge_merged_x.Last().Max_intensity += nn.Max_intensity; charge_merged_x.Last().Mz += " , " + nn.Mz; charge_merged_x.Last().Name += " , " + nn.Name; }
                            else { charge_merged_x.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_a < -merged_x.Last()[1]) { max_a = -merged_x.Last()[1]; }
                        if (maxcharge_a < nn.Charge) { maxcharge_a = nn.Charge; }
                    }                    
                }
                else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("y", nn.SortIdx))
                    {                        
                        if (merged_y.Count == 0 || (int)merged_y.Last()[0] != nn.SortIdx)
                        {
                            merged_y.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                            charge_merged_y.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name });
                        }
                        else
                        {
                            merged_y.Last()[1] -= nn.Max_intensity;
                            if (charge_merged_y.Last().Charge == nn.Charge) { charge_merged_y.Last().Max_intensity += nn.Max_intensity; charge_merged_y.Last().Mz += " , " + nn.Mz; charge_merged_y.Last().Name += " , " + nn.Name; }
                            else { charge_merged_y.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_b < -merged_y.Last()[1]) { max_b = -merged_y.Last()[1]; }
                        if (maxcharge_b < nn.Charge) { maxcharge_b = nn.Charge; }
                    }                    
                }
                else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("z", nn.SortIdx))
                    {                        
                        if (merged_z.Count == 0 || (int)merged_z.Last()[0] != nn.SortIdx)
                        {
                            merged_z.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                            charge_merged_z.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name });
                        }
                        else
                        {
                            merged_z.Last()[1] -= nn.Max_intensity;
                            if (charge_merged_z.Last().Charge == nn.Charge) { charge_merged_z.Last().Max_intensity += nn.Max_intensity; charge_merged_z.Last().Mz += " , " + nn.Mz; charge_merged_z.Last().Name += " , " + nn.Name; }
                            else { charge_merged_z.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name }); }
                        }
                        if (max_c < -merged_z.Last()[1]) { max_c = -merged_z.Last()[1]; }
                        if (maxcharge_c < nn.Charge) { maxcharge_c = nn.Charge; }
                    }                   
                }
                else if (nn.Ion_type.StartsWith("inter"))
                {
                    if (nn.Ion_type.Contains("b")) { IonDrawIndexTo.Add(new ion() { Ion_type = nn.Ion_type, Index = nn.Index, IndexTo = nn.IndexTo,Charge=nn.Charge, Color = Color.Blue, Max_intensity = nn.Max_intensity }); }
                    else { IonDrawIndexTo.Add(new ion() { Ion_type = nn.Ion_type, Index = nn.Index, IndexTo = nn.IndexTo, Color = Color.Green, Charge = nn.Charge, Max_intensity = nn.Max_intensity }); }
                }
            }
            foreach (ion nn in charge_merged_a)
            {

                if (nn.Max_intensity / 10 < 10) { points_a_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_a_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_a_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_a_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_a_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_a_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_a_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_a_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_a_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_a_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            foreach (ion nn in charge_merged_b)
            {
                if (nn.Max_intensity / 10 < 10) { points_b_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_b_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_b_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_b_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_b_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_b_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_b_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_b_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_b_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_b_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            foreach (ion nn in charge_merged_c)
            {
                if (nn.Max_intensity / 10 < 10) { points_c_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_c_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_c_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_c_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_c_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_c_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_c_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_c_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_c_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_c_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            foreach (ion nn in charge_merged_x)
            {               
                if (nn.Max_intensity / 10 < 10) { points_x_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_x_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_x_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_x_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_x_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_x_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_x_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_x_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_x_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_x_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            foreach (ion nn in charge_merged_y)
            {
                if (nn.Max_intensity / 10 < 10) { points_y_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_y_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_y_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_y_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_y_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_y_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_y_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_y_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_y_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_y_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            foreach (ion nn in charge_merged_z)
            {
                if (nn.Max_intensity / 10 < 10) { points_z_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100 < 10) { points_z_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000 < 10) { points_z_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000 < 10) { points_z_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000 < 10) { points_z_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000 < 10) { points_z_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 10000000 < 10) { points_z_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 100000000 < 10) { points_z_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else if (nn.Max_intensity / 1000000000 < 10) { points_z_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                else { points_z_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
            }
            ppm_series.ItemsSource = ppmpoints;
            //default TrackerFormatString: "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}"
            // { 0} = Title of Series { 1} = Title of X-Axis { 2} = X Value { 3} = Title of Y-Axis { 4} = Y Value            
            ppm_series.TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nName:{Name}"; 
            ppm_plot.Model.Series.Add(ppm_series);
            ppm_plot.Model.TrackerChanged += (s, e) =>
            {                
                ppm_plot.Model.Subtitle = e.HitResult != null ?  e.HitResult.Text : null;
                ppm_plot.Model.InvalidatePlot(false);
            };
            a_10.ItemsSource = points_a_10;a_100.ItemsSource = points_a_100;a_1000.ItemsSource = points_a_1000;a_10000.ItemsSource = points_a_10000;a_100000.ItemsSource = points_a_100000;a_1000000.ItemsSource = points_a_1000000;            a_10000000.ItemsSource = points_a_10000000;            a_100000000.ItemsSource = points_a_100000000;            a_1000000000.ItemsSource = points_a_1000000000;            a_10000000000.ItemsSource = points_a_10000000000;
            b_10.ItemsSource = points_b_10;b_100.ItemsSource = points_b_100;b_1000.ItemsSource = points_b_1000;b_10000.ItemsSource = points_b_10000;b_100000.ItemsSource = points_b_100000;b_1000000.ItemsSource = points_b_1000000;            b_10000000.ItemsSource = points_b_10000000;            b_100000000.ItemsSource = points_b_100000000;            b_1000000000.ItemsSource = points_b_1000000000;            b_10000000000.ItemsSource = points_b_10000000000;
            c_10.ItemsSource = points_c_10;c_100.ItemsSource = points_c_100;c_1000.ItemsSource = points_c_1000;c_10000.ItemsSource = points_c_10000;c_100000.ItemsSource = points_c_100000;c_1000000.ItemsSource = points_c_1000000;            c_10000000.ItemsSource = points_c_10000000;            c_100000000.ItemsSource = points_c_100000000;            c_1000000000.ItemsSource = points_c_1000000000;            c_10000000000.ItemsSource = points_c_10000000000;
            x_10.ItemsSource = points_x_10;x_100.ItemsSource = points_x_100;x_1000.ItemsSource = points_x_1000;x_10000.ItemsSource = points_x_10000;x_100000.ItemsSource = points_x_100000;x_1000000.ItemsSource = points_x_1000000;            x_10000000.ItemsSource = points_x_10000000;            x_100000000.ItemsSource = points_x_100000000;            x_1000000000.ItemsSource = points_x_1000000000;            x_10000000000.ItemsSource = points_x_10000000000;
            y_10.ItemsSource = points_y_10;y_100.ItemsSource = points_y_100;y_1000.ItemsSource = points_y_1000;y_10000.ItemsSource = points_y_10000;y_100000.ItemsSource = points_y_100000;y_1000000.ItemsSource = points_y_1000000;            y_10000000.ItemsSource = points_y_10000000;            y_100000000.ItemsSource = points_y_100000000;            y_1000000000.ItemsSource = points_y_1000000000;            y_10000000000.ItemsSource = points_y_10000000000;
            z_10.ItemsSource = points_z_10;z_100.ItemsSource = points_z_100;z_1000.ItemsSource = points_z_1000;z_10000.ItemsSource = points_z_10000;z_100000.ItemsSource = points_z_100000;z_1000000.ItemsSource = points_z_1000000;            z_10000000.ItemsSource = points_z_10000000;            z_100000000.ItemsSource = points_z_100000000;            z_1000000000.ItemsSource = points_z_1000000000;            z_10000000000.ItemsSource = points_z_10000000000;

            a_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            a_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";
            b_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";             b_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            b_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";
            c_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";           c_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";            c_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}";
            x_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            x_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";
            y_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            y_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";
            z_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";            z_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}";

            if (a_Btn.Checked && x_Btn.Checked)
            {
                axCharge_plot.Model.Title ="a - x  fragments";
                if (points_a_10000000000.Count > 0) axCharge_plot.Model.Series.Add(a_10000000000);
                if (points_x_10000000000.Count > 0) axCharge_plot.Model.Series.Add(x_10000000000);
                if (points_a_1000000000.Count > 0) axCharge_plot.Model.Series.Add(a_1000000000);
                if (points_x_1000000000.Count > 0) axCharge_plot.Model.Series.Add(x_1000000000);
                if (points_a_100000000.Count > 0) axCharge_plot.Model.Series.Add(a_100000000);
                if (points_x_100000000.Count > 0) axCharge_plot.Model.Series.Add(x_100000000);
                if (points_a_10000000.Count > 0) axCharge_plot.Model.Series.Add(a_10000000);
                if (points_x_10000000.Count > 0) axCharge_plot.Model.Series.Add(x_10000000);
                if (points_a_1000000.Count > 0) axCharge_plot.Model.Series.Add(a_1000000);
                if (points_x_1000000.Count > 0) axCharge_plot.Model.Series.Add(x_1000000);
                if (points_a_100000.Count > 0) axCharge_plot.Model.Series.Add(a_100000);
                if (points_x_100000.Count > 0) axCharge_plot.Model.Series.Add(x_100000);
                if (points_a_10000.Count > 0) axCharge_plot.Model.Series.Add(a_10000);
                if (points_x_10000.Count > 0) axCharge_plot.Model.Series.Add(x_10000);
                if (points_a_1000.Count > 0) axCharge_plot.Model.Series.Add(a_1000);
                if (points_x_1000.Count > 0) axCharge_plot.Model.Series.Add(x_1000);
                if (points_a_100.Count > 0) axCharge_plot.Model.Series.Add(a_100);
                if (points_x_100.Count > 0) axCharge_plot.Model.Series.Add(x_100);
                if (points_a_10.Count > 0) axCharge_plot.Model.Series.Add(a_10);
                if (points_x_10.Count > 0) axCharge_plot.Model.Series.Add(x_10);
            }
            else if (a_Btn.Checked)
            {
                axCharge_plot.Model.Title = "a fragments";
                if (points_a_10000000000.Count > 0) axCharge_plot.Model.Series.Add(a_10000000000);
                if (points_a_1000000000.Count > 0) axCharge_plot.Model.Series.Add(a_1000000000);
                if (points_a_100000000.Count > 0) axCharge_plot.Model.Series.Add(a_100000000);
                if (points_a_10000000.Count > 0) axCharge_plot.Model.Series.Add(a_10000000);
                if (points_a_1000000.Count > 0) axCharge_plot.Model.Series.Add(a_1000000);
                if (points_a_100000.Count > 0) axCharge_plot.Model.Series.Add(a_100000);
                if (points_a_10000.Count > 0) axCharge_plot.Model.Series.Add(a_10000);
                if (points_a_1000.Count > 0) axCharge_plot.Model.Series.Add(a_1000);
                if (points_a_100.Count > 0) axCharge_plot.Model.Series.Add(a_100);
                if (points_a_10.Count > 0) axCharge_plot.Model.Series.Add(a_10);
            }
            else if (x_Btn.Checked)
            {
               axCharge_plot.Model.Title = "x fragments";
                if (points_x_10000000000.Count > 0) axCharge_plot.Model.Series.Add(x_10000000000);
                if (points_x_1000000000.Count > 0) axCharge_plot.Model.Series.Add(x_1000000000);
                if (points_x_100000000.Count > 0) axCharge_plot.Model.Series.Add(x_100000000);
                if (points_x_10000000.Count > 0) axCharge_plot.Model.Series.Add(x_10000000);
                if (points_x_1000000.Count > 0) axCharge_plot.Model.Series.Add(x_1000000);
                if (points_x_100000.Count > 0) axCharge_plot.Model.Series.Add(x_100000);
                if (points_x_10000.Count > 0) axCharge_plot.Model.Series.Add(x_10000);
                if (points_x_1000.Count > 0) axCharge_plot.Model.Series.Add(x_1000);
                if (points_x_100.Count > 0) axCharge_plot.Model.Series.Add(x_100);
                if (points_x_10.Count > 0) axCharge_plot.Model.Series.Add(x_10);
            }
            else
            {
                axCharge_plot.Model.Title = "a - x  fragments";
            }
            if (b_Btn.Checked && y_Btn.Checked)
            {
                byCharge_plot.Model.Title = "b - y  fragments";
                if (points_b_10000000000.Count > 0) byCharge_plot.Model.Series.Add(b_10000000000);
                if (points_y_10000000000.Count > 0) byCharge_plot.Model.Series.Add(y_10000000000);
                if (points_b_1000000000.Count > 0) byCharge_plot.Model.Series.Add(b_1000000000);
                if (points_y_1000000000.Count > 0) byCharge_plot.Model.Series.Add(y_1000000000);
                if (points_b_100000000.Count > 0) byCharge_plot.Model.Series.Add(b_100000000);
                if (points_y_100000000.Count > 0) byCharge_plot.Model.Series.Add(y_100000000);
                if (points_b_10000000.Count > 0) byCharge_plot.Model.Series.Add(b_10000000);
                if (points_y_10000000.Count > 0) byCharge_plot.Model.Series.Add(y_10000000);
                if (points_b_1000000.Count > 0) byCharge_plot.Model.Series.Add(b_1000000);
                if (points_y_1000000.Count > 0) byCharge_plot.Model.Series.Add(y_1000000);
                if (points_b_100000.Count > 0) byCharge_plot.Model.Series.Add(b_100000);
                if (points_y_100000.Count > 0) byCharge_plot.Model.Series.Add(y_100000);
                if (points_b_10000.Count > 0) byCharge_plot.Model.Series.Add(b_10000);
                if (points_y_10000.Count > 0) byCharge_plot.Model.Series.Add(y_10000);
                if (points_b_1000.Count > 0) byCharge_plot.Model.Series.Add(b_1000);
                if (points_y_1000.Count > 0) byCharge_plot.Model.Series.Add(y_1000);
                if (points_b_100.Count > 0) byCharge_plot.Model.Series.Add(b_100);
                if (points_y_100.Count > 0) byCharge_plot.Model.Series.Add(y_100);
                if (points_b_10.Count > 0) byCharge_plot.Model.Series.Add(b_10);
                if (points_y_10.Count > 0) byCharge_plot.Model.Series.Add(y_10);
            }
            else if (b_Btn.Checked)
            {
                byCharge_plot.Model.Title = "b  fragments";
                if (points_b_10000000000.Count > 0) byCharge_plot.Model.Series.Add(b_10000000000);
                if (points_b_1000000000.Count > 0) byCharge_plot.Model.Series.Add(b_1000000000);
                if (points_b_100000000.Count > 0) byCharge_plot.Model.Series.Add(b_100000000);
                if (points_b_10000000.Count > 0) byCharge_plot.Model.Series.Add(b_10000000);
                if (points_b_1000000.Count > 0) byCharge_plot.Model.Series.Add(b_1000000);
                if (points_b_100000.Count > 0) byCharge_plot.Model.Series.Add(b_100000);
                if (points_b_10000.Count > 0) byCharge_plot.Model.Series.Add(b_10000);
                if (points_b_1000.Count > 0) byCharge_plot.Model.Series.Add(b_1000);
                if (points_b_100.Count > 0) byCharge_plot.Model.Series.Add(b_100);
                if (points_b_10.Count > 0) byCharge_plot.Model.Series.Add(b_10);
            }
            else if (y_Btn.Checked)
            {
                byCharge_plot.Model.Title = "y  fragments";
                if (points_y_10000000000.Count > 0) byCharge_plot.Model.Series.Add(y_10000000000);
                if (points_y_1000000000.Count > 0) byCharge_plot.Model.Series.Add(y_1000000000);
                if (points_y_100000000.Count > 0) byCharge_plot.Model.Series.Add(y_100000000);
                if (points_y_10000000.Count > 0) byCharge_plot.Model.Series.Add(y_10000000);
                if (points_y_1000000.Count > 0) byCharge_plot.Model.Series.Add(y_1000000);
                if (points_y_100000.Count > 0) byCharge_plot.Model.Series.Add(y_100000);
                if (points_y_10000.Count > 0) byCharge_plot.Model.Series.Add(y_10000);
                if (points_y_1000.Count > 0) byCharge_plot.Model.Series.Add(y_1000);
                if (points_y_100.Count > 0) byCharge_plot.Model.Series.Add(y_100);
                if (points_y_10.Count > 0) byCharge_plot.Model.Series.Add(y_10);
            }
            else
            {
                byCharge_plot.Model.Title = "b - y  fragments";
            }
            if (c_Btn.Checked && z_Btn.Checked)
            {
                czCharge_plot.Model.Title = "c - z  fragments";
                if (points_c_10000000000.Count > 0) czCharge_plot.Model.Series.Add(c_10000000000);
                if (points_z_10000000000.Count > 0) czCharge_plot.Model.Series.Add(z_10000000000);
                if (points_c_1000000000.Count > 0) czCharge_plot.Model.Series.Add(c_1000000000);
                if (points_z_1000000000.Count > 0) czCharge_plot.Model.Series.Add(z_1000000000);
                if (points_c_100000000.Count > 0) czCharge_plot.Model.Series.Add(c_100000000);
                if (points_z_100000000.Count > 0) czCharge_plot.Model.Series.Add(z_100000000);
                if (points_c_10000000.Count > 0) czCharge_plot.Model.Series.Add(c_10000000);
                if (points_z_10000000.Count > 0) czCharge_plot.Model.Series.Add(z_10000000);
                if (points_c_1000000.Count > 0) czCharge_plot.Model.Series.Add(c_1000000);
                if (points_z_1000000.Count > 0) czCharge_plot.Model.Series.Add(z_1000000);
                if (points_c_100000.Count > 0) czCharge_plot.Model.Series.Add(c_100000);
                if (points_z_100000.Count > 0) czCharge_plot.Model.Series.Add(z_100000);
                if (points_c_10000.Count > 0) czCharge_plot.Model.Series.Add(c_10000);
                if (points_z_10000.Count > 0) czCharge_plot.Model.Series.Add(z_10000);
                if (points_c_1000.Count > 0) czCharge_plot.Model.Series.Add(c_1000);
                if (points_z_1000.Count > 0) czCharge_plot.Model.Series.Add(z_1000);
                if (points_c_100.Count > 0) czCharge_plot.Model.Series.Add(c_100);
                if (points_z_100.Count > 0) czCharge_plot.Model.Series.Add(z_100);
                if (points_c_10.Count > 0) czCharge_plot.Model.Series.Add(c_10);
                if (points_z_10.Count > 0) czCharge_plot.Model.Series.Add(z_10);
            }
            else if (c_Btn.Checked)
            {
                czCharge_plot.Model.Title = "c fragments";
                if (points_c_10000000000.Count > 0) czCharge_plot.Model.Series.Add(c_10000000000);
                if (points_c_1000000000.Count > 0) czCharge_plot.Model.Series.Add(c_1000000000);
                if (points_c_100000000.Count > 0) czCharge_plot.Model.Series.Add(c_100000000);
                if (points_c_10000000.Count > 0) czCharge_plot.Model.Series.Add(c_10000000);
                if (points_c_1000000.Count > 0) czCharge_plot.Model.Series.Add(c_1000000);
                if (points_c_100000.Count > 0) czCharge_plot.Model.Series.Add(c_100000);
                if (points_c_10000.Count > 0) czCharge_plot.Model.Series.Add(c_10000);
                if (points_c_1000.Count > 0) czCharge_plot.Model.Series.Add(c_1000);
                if (points_c_100.Count > 0) czCharge_plot.Model.Series.Add(c_100);
                if (points_c_10.Count > 0) czCharge_plot.Model.Series.Add(c_10);
            }
            else if (z_Btn.Checked)
            {
                czCharge_plot.Model.Title = "z fragments";
                if (points_z_10000000000.Count > 0) czCharge_plot.Model.Series.Add(z_10000000000);
                if (points_z_1000000000.Count > 0) czCharge_plot.Model.Series.Add(z_1000000000);
                if (points_z_100000000.Count > 0) czCharge_plot.Model.Series.Add(z_100000000);
                if (points_z_10000000.Count > 0) czCharge_plot.Model.Series.Add(z_10000000);
                if (points_z_1000000.Count > 0) czCharge_plot.Model.Series.Add(z_1000000);
                if (points_z_100000.Count > 0) czCharge_plot.Model.Series.Add(z_100000);
                if (points_z_10000.Count > 0) czCharge_plot.Model.Series.Add(z_10000);
                if (points_z_1000.Count > 0) czCharge_plot.Model.Series.Add(z_1000);
                if (points_z_100.Count > 0) czCharge_plot.Model.Series.Add(z_100);
                if (points_z_10.Count > 0) czCharge_plot.Model.Series.Add(z_10);
            }
            else
            {
                czCharge_plot.Model.Title = "c - z  fragments";
            }

            foreach (double[] pp in merged_a) { (ax_plot.Model.Series[0] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_b) { (by_plot.Model.Series[0] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_c) { (cz_plot.Model.Series[0] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_x) { (ax_plot.Model.Series[1] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_y) { (by_plot.Model.Series[1] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_z) { (cz_plot.Model.Series[1] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }

            var s1a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red, };var s2a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            var s1b = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red };var s2b = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            var s1c = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red }; var s2c = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            for (int cc = 0; cc < Peptide.Length; cc++)
            {
                if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                {
                    s1a.Points.Add(new ScatterPoint(cc + 1, -max_a *1.3)); s1b.Points.Add(new ScatterPoint(cc + 1, -max_b * 1.3)); s1c.Points.Add(new ScatterPoint(cc + 1, -max_c * 1.3));
                }
                else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                {
                    s2a.Points.Add(new ScatterPoint(cc + 1, max_a * 1.3)); s2b.Points.Add(new ScatterPoint(cc + 1, max_b * 1.3)); s2c.Points.Add(new ScatterPoint(cc + 1, max_c * 1.3));
                }
            }
            ax_plot.Model.Series.Add(s1a); ax_plot.Model.Series.Add(s2a); by_plot.Model.Series.Add(s1b); by_plot.Model.Series.Add(s2b); cz_plot.Model.Series.Add(s1c); cz_plot.Model.Series.Add(s2c);
            ax_plot.Model.Axes[0].AxisChanged += (s, e) => 
            {
                s1a.Points.Clear(); s2a.Points.Clear();
                for (int cc = 0; cc < Peptide.Length; cc++)
                {
                    if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                    {
                        s1a.Points.Add(new ScatterPoint(cc + 1, ax_plot.Model.Axes[0].ActualMinimum)); 
                    }
                    else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                    {
                        s2a.Points.Add(new ScatterPoint(cc + 1, ax_plot.Model.Axes[0].ActualMaximum)); 
                    }
                }
                ax_plot.Model.Series[2] = s1a;ax_plot.Model.Series[3] = s2a;ax_plot.InvalidatePlot(true);
            };
            by_plot.Model.Axes[0].AxisChanged += (s, e) =>
            {
                s1b.Points.Clear(); s2b.Points.Clear();
                for (int cc = 0; cc < Peptide.Length; cc++)
                {
                    if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                    {
                        s1b.Points.Add(new ScatterPoint(cc + 1, by_plot.Model.Axes[0].ActualMinimum));
                    }
                    else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                    {
                        s2b.Points.Add(new ScatterPoint(cc + 1, by_plot.Model.Axes[0].ActualMaximum));
                    }
                }
                by_plot.Model.Series[2] = s1b; by_plot.Model.Series[3] = s2b; by_plot.InvalidatePlot(true);
            };
            cz_plot.Model.Axes[0].AxisChanged += (s, e) =>
            {
                s1c.Points.Clear(); s2c.Points.Clear();
                for (int cc = 0; cc < Peptide.Length; cc++)
                {
                    if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                    {
                        s1c.Points.Add(new ScatterPoint(cc + 1, cz_plot.Model.Axes[0].ActualMinimum));
                    }
                    else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                    {
                        s2c.Points.Add(new ScatterPoint(cc + 1, cz_plot.Model.Axes[0].ActualMaximum));
                    }
                }
                cz_plot.Model.Series[2] = s1c; cz_plot.Model.Series[3] = s2c; cz_plot.InvalidatePlot(true);
            };
            ax_plot.Model.Axes[1].Minimum = by_plot.Model.Axes[1].Minimum = cz_plot.Model.Axes[1].Minimum = 0;            
            axCharge_plot.Model.Axes[1].Minimum = byCharge_plot.Model.Axes[1].Minimum = czCharge_plot.Model.Axes[1].Minimum = 0;
            ax_plot.Model.Axes[1].Maximum = by_plot.Model.Axes[1].Maximum = cz_plot.Model.Axes[1].Maximum =axCharge_plot.Model.Axes[1].Maximum = byCharge_plot.Model.Axes[1].Maximum = czCharge_plot.Model.Axes[1].Maximum = Peptide.Length;
            axCharge_plot.Model.Axes[0].Minimum = byCharge_plot.Model.Axes[0].Minimum = czCharge_plot.Model.Axes[0].Minimum = 0;
            axCharge_plot.Model.Axes[0].Maximum = maxcharge_a+1; byCharge_plot.Model.Axes[0].Maximum = maxcharge_b+1; czCharge_plot.Model.Axes[0].Maximum = maxcharge_c+1;          
            axCharge_plot.InvalidatePlot(true); byCharge_plot.InvalidatePlot(true); czCharge_plot.InvalidatePlot(true); ax_plot.InvalidatePlot(true); by_plot.InvalidatePlot(true); cz_plot.InvalidatePlot(true);
            ppm_plot.Model.Axes[1].Maximum = iondraw_count + 1; ppm_plot.Model.Axes[1].Minimum = 0;
            ppm_plot.InvalidatePlot(true);

            if (IonDrawIndexTo.Count() > 0)
            {               
                CI_indexTo com1 = new CI_indexTo(); IonDrawIndexTo.Sort(com1);
                int k = 1;
                foreach (ion nn in IonDrawIndexTo)
                {
                    List<CustomDataPointIndex> custom_Index = new List<CustomDataPointIndex>();
                    List<CustomDataPointIndex> custom_IndIntensity = new List<CustomDataPointIndex>();
                    if (nn.Charge > 0)
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }
                    else
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }
                    LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    tmp.ItemsSource = custom_Index;
                    tmp.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";

                    indexto_plot.Model.Series.Add(tmp);

                    custom_IndIntensity.Add(new CustomDataPointIndex(0, k, nn.Ion_type,"["+ nn.Index.ToString() + "-"+ nn.IndexTo.ToString() + "]", nn.Charge.ToString(),nn.Max_intensity.ToString("0.###")));
                    custom_IndIntensity.Add(new CustomDataPointIndex(nn.Max_intensity, k, nn.Ion_type , "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(),nn.Max_intensity.ToString("0.###")));
                    LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    bar.ItemsSource = custom_IndIntensity;
                    bar.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";
                    indextoIntensity_plot.Model.Series.Add(bar);
                    k++;
                    if (nn.Max_intensity > max_i) max_i = nn.Max_intensity;
                    //LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, Color = nn.Color.ToOxyColor() };
                    //tmp.Points.Add(new DataPoint(nn.Index, k));tmp.Points.Add(new DataPoint(nn.IndexTo, k));
                    //indexto_plot.Model.Series.Add(tmp);
                    //LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, Color = nn.Color.ToOxyColor() };
                    //bar.Points.Add(new DataPoint(0, k));bar.Points.Add(new DataPoint(nn.Max_intensity, k));
                    //indextoIntensity_plot.Model.Series.Add(bar);
                    //k++;
                    //if (nn.Max_intensity > max_i) max_i = nn.Max_intensity;
                }
                CI_index com2 = new CI_index(); IonDrawIndexTo.Sort(com2);
                k = 1;
                foreach (ion nn in IonDrawIndexTo)
                {
                    List<CustomDataPointIndex> custom_Index = new List<CustomDataPointIndex>();
                    List<CustomDataPointIndex> custom_IndIntensity = new List<CustomDataPointIndex>();
                    if (nn.Charge>0)
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }
                    else
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }
                    
                    LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    tmp.ItemsSource = custom_Index;
                    tmp.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";

                    index_plot.Model.Series.Add(tmp);

                    custom_IndIntensity.Add(new CustomDataPointIndex(0, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    custom_IndIntensity.Add(new CustomDataPointIndex(nn.Max_intensity, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    bar.ItemsSource = custom_IndIntensity;
                    bar.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";
                    indexIntensity_plot.Model.Series.Add(bar);
                    k++;
                    //LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, Color = nn.Color.ToOxyColor() };
                    //tmp.Points.Add(new DataPoint(nn.Index, k)); tmp.Points.Add(new DataPoint(nn.IndexTo, k));
                    //index_plot.Model.Series.Add(tmp);
                    //LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, Color = nn.Color.ToOxyColor() };
                    //bar.Points.Add(new DataPoint(0, k)); bar.Points.Add(new DataPoint(nn.Max_intensity, k));
                    //indexIntensity_plot.Model.Series.Add(bar);
                    //k++;
                }
                indexIntensity_plot.Model.Axes[1].Maximum =indextoIntensity_plot.Model.Axes[1].Maximum =max_i*1.2;
                indexIntensity_plot.Model.Axes[0].Minimum =indextoIntensity_plot.Model.Axes[0].Minimum =0;
                indexto_plot.Model.Axes[1].Minimum = index_plot.Model.Axes[1].Minimum = 0;
                indexto_plot.Model.Axes[1].Maximum = index_plot.Model.Axes[1].Maximum = Peptide.Length ;
                indexto_plot.Model.Axes[0].Minimum = index_plot.Model.Axes[0].Minimum = 0;
                if (IonDrawIndexTo.Count > 200) { yINT_minorStep13 = 25; yINT_majorStep13 = 50; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count > 150) { yINT_minorStep13 = 15; yINT_majorStep13 = 30; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count > 100) { yINT_minorStep13 = 10; yINT_majorStep13 = 20; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count >50) { yINT_minorStep13 = 5; yINT_majorStep13 = 10; internal_plots_refresh(); }
                indexto_plot.Model.Axes[0].Maximum = index_plot.Model.Axes[0].Maximum = indexIntensity_plot.Model.Axes[0].Maximum = indextoIntensity_plot.Model.Axes[0].Maximum = IonDrawIndexTo.Count + yINT_minorStep13/2;
                indexto_plot.Model.Axes[0].Minimum = index_plot.Model.Axes[0].Minimum = indexIntensity_plot.Model.Axes[0].Minimum = indextoIntensity_plot.Model.Axes[0].Minimum = - yINT_minorStep13/2;
            }
            indexto_plot.InvalidatePlot(true); indextoIntensity_plot.InvalidatePlot(true); indexIntensity_plot.InvalidatePlot(true); index_plot.InvalidatePlot(true);
        }
        private bool search_primary(string type, int idx)
        {            
            foreach (ion nn in IonDraw)
            {
                if (nn.SortIdx > idx) break;
                else if (nn.SortIdx == idx && !nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && (nn.Ion_type.StartsWith(type) || nn.Ion_type.StartsWith("(" + type))) return true;                
            }
            return false;
        }
        private void check_duplicate_ions()
        {            
            int i = 0;
            while (i < IonDraw.Count - 1)
            {
                int jj = i + 1;
                while (jj < IonDraw.Count)
                {
                    if (IonDraw[i].Ion_type == IonDraw[jj].Ion_type && IonDraw[i].Index == IonDraw[jj].Index && IonDraw[i].IndexTo == IonDraw[jj].IndexTo &&  IonDraw[i].Mz == IonDraw[jj].Mz)
                    {
                        IonDraw.RemoveAt(jj);
                    }
                    else jj++;
                }
                i++;
            }
        }

        class CI : IComparer<ion>
        {
            public int Compare(ion x, ion y)
            {

                //if (x.Ion_type == y.Ion_type)
                //{
                if (x.SortIdx== y.SortIdx)
                {
                    if (x.Charge == y.Charge)
                    {
                        return Decimal.Compare((decimal)x.Max_intensity, (decimal)y.Max_intensity);
                    }
                    else
                    {
                        return -Decimal.Compare((decimal)x.Charge, (decimal)y.Charge);
                    }
                }
                else
                {
                    return Decimal.Compare(x.SortIdx, y.SortIdx);
                }
                //}
                //else
                //{
                //    return String.Compare(x.Ion_type, y.Ion_type);
                //}
            }
        }

        class CI_indexTo : IComparer<ion>
        {
            public int Compare(ion x, ion y)
            {
                return -Decimal.Compare(x.IndexTo, y.IndexTo);
            }
        }
        class CI_index : IComparer<ion>
        {
            public int Compare(ion x, ion y)
            {
                return -Decimal.Compare(x.Index, y.Index);
            }
        }

        #region export and resize panels

        private void export_panel(bool copy, Panel pnl)
        {
            int width = pnl.Size.Width;
            int height = pnl.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            pnl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));            
            if (copy)
            {
                Clipboard.SetImage(bm);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save image", FileName = "", Filter = "image file|*.png|all files|*.*", OverwritePrompt = true, AddExtension = true };
                if (save.ShowDialog() == DialogResult.OK) { bm.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png); }
            }
        }

        private void ax_Pnl_Resize(object sender, EventArgs e)
        {
            ax_X_Box.Text = ax_Pnl.Size.Width.ToString();
            ax_Y_Box.Text = ax_Pnl.Size.Height.ToString();
        }

        private void by_Pnl_Resize(object sender, EventArgs e)
        {
            by_X_Box.Text = by_Pnl.Size.Width.ToString();
            by_Y_Box.Text = by_Pnl.Size.Height.ToString();
        }

        private void cz_Pnl_Resize(object sender, EventArgs e)
        {
            cz_X_Box.Text = cz_Pnl.Size.Width.ToString();
            cz_Y_Box.Text = cz_Pnl.Size.Height.ToString();
        }

        private void axCharge_Pnl_Resize(object sender, EventArgs e)
        {
            axcharge_X_Box.Text = axCharge_Pnl.Size.Width.ToString();
            axcharge_Y_Box.Text = axCharge_Pnl.Size.Height.ToString();
        }

        private void byCharge_Pnl_Resize(object sender, EventArgs e)
        {
            bycharge_X_Box.Text = byCharge_Pnl.Size.Width.ToString();
            bycharge_Y_Box.Text = byCharge_Pnl.Size.Height.ToString();
        }

        private void czCharge_Pnl_Resize(object sender, EventArgs e)
        {
            czcharge_X_Box.Text = czCharge_Pnl.Size.Width.ToString();
            czcharge_Y_Box.Text = czCharge_Pnl.Size.Height.ToString();
        }

        #endregion

        #endregion

        #region FORM 12 plot settings
        public void primary_plots_refresh(bool charge =false)
        {
            if (!charge)
            {
                ax_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid12;
                ax_plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid12;
                ax_plot.Model.Axes[0].TickStyle = Y_tick12;
                ax_plot.Model.Axes[0].IntervalLength = y_interval12;
                ax_plot.Model.Axes[0].StringFormat = y_format12 + y_numformat12;
                ax_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid12;
                ax_plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid12;
                ax_plot.Model.Axes[1].TickStyle = X_tick12;
                ax_plot.Model.Axes[1].MajorStep = x_majorStep12;
                ax_plot.Model.Axes[1].MinorStep = x_minorStep12;
                ax_plot.InvalidatePlot(true);
                by_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid12;
                by_plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid12;
                by_plot.Model.Axes[0].TickStyle = Y_tick12;
                by_plot.Model.Axes[0].IntervalLength = y_interval12;
                by_plot.Model.Axes[0].StringFormat = y_format12 + y_numformat12;
                by_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid12;
                by_plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid12;
                by_plot.Model.Axes[1].TickStyle = X_tick12;
                by_plot.Model.Axes[1].MajorStep = x_majorStep12;
                by_plot.Model.Axes[1].MinorStep = x_minorStep12;
                by_plot.InvalidatePlot(true);
                cz_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid12;
                cz_plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid12;
                cz_plot.Model.Axes[0].TickStyle = Y_tick12;
                cz_plot.Model.Axes[0].IntervalLength = y_interval12;
                cz_plot.Model.Axes[0].StringFormat = y_format12 + y_numformat12;
                cz_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid12;
                cz_plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid12;
                cz_plot.Model.Axes[1].TickStyle = X_tick12;
                cz_plot.Model.Axes[1].MajorStep = x_majorStep12;
                cz_plot.Model.Axes[1].MinorStep = x_minorStep12;
                cz_plot.InvalidatePlot(true);
            }
            else
            {
                axCharge_plot.Model.Axes[0].MajorGridlineStyle =Ymajor_charge_grid12 ;
                axCharge_plot.Model.Axes[0].MinorGridlineStyle =Yminor_charge_grid12 ;
                axCharge_plot.Model.Axes[0].TickStyle = Y_charge_tick12;
                axCharge_plot.Model.Axes[0].MajorStep = y_charge_majorStep12;
                axCharge_plot.Model.Axes[0].MinorStep = y_charge_minorStep12 ;
                axCharge_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_charge_grid12;
                axCharge_plot.Model.Axes[1].MinorGridlineStyle = Xminor_charge_grid12;
                axCharge_plot.Model.Axes[1].TickStyle = X_charge_tick12;
                axCharge_plot.Model.Axes[1].MajorStep = x_charge_majorStep12;
                axCharge_plot.Model.Axes[1].MinorStep = x_charge_minorStep12;
                axCharge_plot.InvalidatePlot(true);
                byCharge_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_charge_grid12;
                byCharge_plot.Model.Axes[0].MinorGridlineStyle = Yminor_charge_grid12;
                byCharge_plot.Model.Axes[0].TickStyle = Y_charge_tick12;
                byCharge_plot.Model.Axes[0].MajorStep = y_charge_majorStep12;
                byCharge_plot.Model.Axes[0].MinorStep = y_charge_minorStep12;
                byCharge_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_charge_grid12;
                byCharge_plot.Model.Axes[1].MinorGridlineStyle = Xminor_charge_grid12;
                byCharge_plot.Model.Axes[1].TickStyle = X_charge_tick12;
                byCharge_plot.Model.Axes[1].MajorStep = x_charge_majorStep12;
                byCharge_plot.Model.Axes[1].MinorStep = x_charge_minorStep12;
                byCharge_plot.InvalidatePlot(true);
                czCharge_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_charge_grid12;
                czCharge_plot.Model.Axes[0].MinorGridlineStyle = Yminor_charge_grid12;
                czCharge_plot.Model.Axes[0].TickStyle = Y_charge_tick12;
                czCharge_plot.Model.Axes[0].MajorStep = y_charge_majorStep12;
                czCharge_plot.Model.Axes[0].MinorStep = y_charge_minorStep12;
                czCharge_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_charge_grid12;
                czCharge_plot.Model.Axes[1].MinorGridlineStyle = Xminor_charge_grid12;
                czCharge_plot.Model.Axes[1].TickStyle = X_charge_tick12;
                czCharge_plot.Model.Axes[1].MajorStep = x_charge_majorStep12;
                czCharge_plot.Model.Axes[1].MinorStep = x_charge_minorStep12;
                czCharge_plot.InvalidatePlot(true);
            }
           
        }
        public void tabs_plots_replot()
        {
            initialize_plot_tabs();
        }

        #endregion

        #region FORM 13 plot settings
        public void internal_plots_refresh()
        {
            //index plot
            index_plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            index_plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            index_plot.Model.Axes[0].TickStyle = Yint_tick13;
            index_plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            index_plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            index_plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            index_plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            index_plot.Model.Axes[1].TickStyle = Xint_tick13;
            index_plot.Model.Axes[1].MajorStep = xINT_majorStep13;
            index_plot.Model.Axes[1].MinorStep = xINT_minorStep13;
            index_plot.InvalidatePlot(true);

            //indexTo plot
            indexto_plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            indexto_plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            indexto_plot.Model.Axes[0].TickStyle = Yint_tick13;
            indexto_plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            indexto_plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            indexto_plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            indexto_plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            indexto_plot.Model.Axes[1].TickStyle = Xint_tick13;
            indexto_plot.Model.Axes[1].MajorStep = xINT_majorStep13;
            indexto_plot.Model.Axes[1].MinorStep = xINT_minorStep13;
            indexto_plot.InvalidatePlot(true);

            //indexIntensity plot
            indexIntensity_plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            indexIntensity_plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            indexIntensity_plot.Model.Axes[0].TickStyle = Yint_tick13;
            indexIntensity_plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            indexIntensity_plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            indexIntensity_plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            indexIntensity_plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            indexIntensity_plot.Model.Axes[1].TickStyle = Xint_tick13;
            indexIntensity_plot.Model.Axes[1].StringFormat = x_format13 + x_numformat13;
            indexIntensity_plot.Model.Axes[1].IntervalLength = x_interval13;
            indexIntensity_plot.InvalidatePlot(true);

            //indextoIntensity plot
            indextoIntensity_plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            indextoIntensity_plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            indextoIntensity_plot.Model.Axes[0].TickStyle = Yint_tick13;
            indextoIntensity_plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            indextoIntensity_plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            indextoIntensity_plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            indextoIntensity_plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            indextoIntensity_plot.Model.Axes[1].TickStyle = Xint_tick13;
            indextoIntensity_plot.Model.Axes[1].StringFormat = x_format13 + x_numformat13;
            indextoIntensity_plot.Model.Axes[1].IntervalLength = x_interval13;
            indextoIntensity_plot.InvalidatePlot(true);
        }


        #endregion

        #endregion


        #region FORM 11 extract plot isoplot
        public void plotview_rebuild()
        {
            PlotView temp_plot = new PlotView() { Name = "temp_plot", Location = new Point(5, 185), Size = new Size(1310, 570), BackColor = Color.White, Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = legend_chkBx.Checked, LegendPosition = LegendPosition.TopRight, LegendFontSize = 13, TitleFontSize = 11 }; 
            temp_plot.Model = temp_model;
            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { StringFormat = y_format + y_numformat, IntervalLength = y_interval, TickStyle = Y_tick, MajorGridlineStyle = Ymajor_grid, MinorGridlineStyle = Yminor_grid, FontSize = 10, AxisTitleDistance = 10, TitleFontSize = 11, Title = "Intensity" };
            temp_model.Axes.Add(linearAxis1);
            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format + x_numformat, IntervalLength = x_interval, TickStyle = X_tick, MajorGridlineStyle = Xmajor_grid, MinorGridlineStyle = Xminor_grid, FontSize = 10, AxisTitleDistance = 10, TitleFontSize = 11, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            temp_model.Axes.Add(linearAxis2);
            temp_plot.Controller = new CustomPlotController();
            temp_model.Updated += (s, e) =>
            {
                if (autoscale_Btn.Checked)
                {
                    double max_iso = 200;
                    if (temp_plot.Model.Series.Count > 0 && plotExp_chkBox.Checked)
                    {
                        if ((temp_plot.Model.Series[0] as LineSeries).Points.Count > 0)
                        {
                            double iso_1 = (temp_plot.Model.Series[0] as LineSeries).Points.FindAll(x => (x.X >= temp_plot.Model.Axes[1].ActualMinimum && x.X < temp_plot.Model.Axes[1].ActualMaximum)).Max(k => k.Y);
                            if (iso_1 > max_iso) max_iso = iso_1;
                        }
                        if (all_data.Count > 0 && (temp_plot.Model.Series[(all_data.Count * 2) - 1] as LineSeries).Points.Count > 0)
                        {
                            double iso_1 = (temp_plot.Model.Series[(all_data.Count * 2) - 1] as LineSeries).Points.FindAll(x => (x.X >= temp_plot.Model.Axes[1].ActualMinimum && x.X < temp_plot.Model.Axes[1].ActualMaximum)).Max(k => k.Y);
                            if (iso_1 > max_iso) max_iso = iso_1;
                        }
                        temp_plot.Model.Axes[0].Zoom(-100, max_iso * 1.2);
                    }
                }                
            };
            temp_plot.MouseDoubleClick += (s, e) => { temp_model.ResetAllAxes(); temp_plot.InvalidatePlot(true); };
            refresh_temp_plot(temp_plot);
            temp_plot.Model.Axes[1].Zoom(iso_plot.Model.Axes[1].ActualMinimum, iso_plot.Model.Axes[1].ActualMaximum);
            temp_plot.Model.Axes[0].Zoom(iso_plot.Model.Axes[0].ActualMinimum, iso_plot.Model.Axes[0].ActualMaximum);

            Form11 frm11 = new Form11(temp_plot);
            frm11.Show();
        }

        private void refresh_temp_plot(PlotView temp_plot)
        {
            //// 0.a gather info on which fragments are selected to plot, and their respective intensities
            //List<int> to_plot = selectedFragments.ToList(); // deep copy, don't mess selectedFragments
            List<int> to_plot = new List<int>();
            //0.a add only the desired fragments to to_plot
            foreach (int idx in selectedFragments)
            {
                string ion = Fragments2[idx - 1].Ion_type;
                if (ion.StartsWith("a") || ion.StartsWith("(a"))
                {
                    if (disp_a.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                {
                    if (disp_b.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                {
                    if (disp_c.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                {
                    if (disp_x.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                {
                    if (disp_y.Checked) { to_plot.Add(idx); }
                }
                else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                {
                    if (disp_z.Checked) { to_plot.Add(idx); }
                }
                else if (ion.Contains("inter"))
                {
                    if (disp_internal.Checked) { to_plot.Add(idx); }
                }
                else
                {
                    to_plot.Add(idx);
                }

            }
            // 0.b. reset iso plot
            reset_temp_plot(temp_plot);

            // 1.a rerun calculations for fit and residual
            recalculate_fitted_residual(to_plot);

            // 1.b Add the experimental to plot if selected
            if (plotExp_chkBox.Checked && all_data.Count > 0)
            {
                (temp_plot.Model.Series[0] as LineSeries).Title = "Exp";
                for (int j = 0; j < all_data[0].Count; j++)
                    (temp_plot.Model.Series[0] as LineSeries).Points.Add(new DataPoint(all_data[0][j][0], 1.0 * all_data[0][j][1]));
            }

            // 2. replot all isotopes
            if (plotFragProf_chkBox.Checked && all_data.Count > 0)
            {
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Fragments2[curr_idx - 1].Name;
                        (temp_plot.Model.Series[curr_idx] as LineSeries).Title = name_str;
                        
                        // paint frag envelope
                        for (int j = 0; j < all_data[curr_idx].Count; j++)
                            (temp_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new DataPoint(all_data[curr_idx][j][0], Fragments2[curr_idx - 1].Factor * all_data[curr_idx][j][1]));
                    }
                }
                if (Form9.now)
                {
                    string name_str = Form9.Fragments3[Form9.selected_idx].Name;
                    (temp_plot.Model.Series[Fragments2.Count + 1] as LineSeries).Title = name_str;
                    for (int j = 0; j < all_data.Last().Count; j++)
                        (temp_plot.Model.Series[Fragments2.Count + 1] as LineSeries).Points.Add(new DataPoint(all_data.Last()[j][0], Form9.Fragments3[Form9.selected_idx].Factor * all_data.Last()[j][1]));
                }
            }
            if (plotFragCent_chkBox.Checked && all_data.Count > 0)
            {
                int help = Convert.ToInt32(Form9.now);
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Fragments2[curr_idx - 1].Name;
                        (temp_plot.Model.Series[curr_idx + Fragments2.Count + help] as LinearBarSeries).Title = name_str;

                        // paint frag envelope
                        for (int j = 0; j < Fragments2[curr_idx - 1].Centroid.Count; j++)
                        {
                            List<PointPlot> cenn = Fragments2[curr_idx - 1].Centroid.OrderBy(p => p.X).ToList();
                            (temp_plot.Model.Series[curr_idx + Fragments2.Count + help] as LinearBarSeries).Points.Add(new DataPoint(cenn[j].X, Fragments2[curr_idx - 1].Factor * cenn[j].Y));

                        }
                    }
                }
                if (Form9.now)
                {
                    int curr_idx = Form9.selected_idx;
                    if (all_data.Count != 0)
                    {
                        // get name of each line to be ploted
                        string name_str = Form9.Fragments3[curr_idx].Name;
                        (temp_plot.Model.Series[2 * Fragments2.Count + 2] as LinearBarSeries).Title = name_str;

                        // paint frag envelope
                        for (int j = 0; j < Form9.Fragments3[curr_idx].Centroid.Count; j++)
                        {
                            List<PointPlot> cenn = Form9.Fragments3[curr_idx].Centroid.OrderBy(p => p.X).ToList();
                            (temp_plot.Model.Series[2 * Fragments2.Count + 2] as LinearBarSeries).Points.Add(new DataPoint(cenn[j].X, Form9.Fragments3[curr_idx].Factor * cenn[j].Y));
                        }
                    }
                }
            }
            // 3. fitted plot
            if (summation.Count > 0)
                if (Fitting_chkBox.Checked)
                    for (int j = 0; j < summation.Count; j++)
                        (temp_plot.Model.Series[(all_data.Count * 2) - 1] as LineSeries).Points.Add(new DataPoint(summation[j][0], summation[j][1]));

            // 4. residual plot
            if (residual.Count > 0)
            {
                for (int j = 0; j < residual.Count; j++)
                    (res_plot.Model.Series[0] as LineSeries).Points.Add(new DataPoint(residual[j][0], residual[j][1]));

            }

            // 5. centroid (bar)
            if (plotCentr_chkBox.Checked)
            {
                foreach (double[] peak in peak_points)
                {
                    double mz = peak[1] + peak[4];
                    double inten = peak[5];
                    (temp_plot.Model.Series.Last() as LinearBarSeries).Points.Add(new DataPoint(mz, inten));
                }
            }

            
            invalidate_all();
        }

        private void reset_temp_plot(PlotView temp_plot)
        {
            temp_plot.Model.Series.Clear();
            for (int i = 0; i < all_data.Count; i++)
            {
                OxyColor cc;
                if (Form9.now == true && i == all_data.Count - 1)
                {
                    cc = Form9.Fragments3[Form9.selected_idx].Color;
                }
                else
                {
                    cc = get_fragment_color(i);
                }
                LineSeries tmp = new LineSeries() { StrokeThickness = frag_width, Color = cc, LineStyle = frag_style };
                if (i == 0) { tmp.StrokeThickness = exp_width; tmp.LineStyle = exper_style; }
                temp_plot.Model.Series.Add(tmp);
            }
            for (int i = 1; i < all_data.Count; i++)
            {
                if (Form9.now == true && i == all_data.Count - 1)
                {
                    OxyColor cc = Form9.Fragments3[Form9.selected_idx].Color;
                    LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1, StrokeColor = cc, FillColor = cc, BarWidth = cen_width };
                    temp_plot.Model.Series.Add(bar);
                    break;
                }
                else
                {
                    OxyColor cc = get_fragment_color(i);
                    LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1, StrokeColor = cc, FillColor = cc, BarWidth = cen_width };
                    temp_plot.Model.Series.Add(bar);
                }

            }
            if (insert_exp == true)
            {
                LineSeries fit = new LineSeries() { StrokeThickness = fit_width, Color = fit_color, LineStyle = fit_style };
                temp_plot.Model.Series.Add(fit);
            }
            res_plot.Model.Series.Clear();
            if (insert_exp == true)
            {
                LineSeries res = new LineSeries() { StrokeThickness = 1, Color = OxyColors.Black };
                res_plot.Model.Series.Add(res);
            }
            if (plotCentr_chkBox.Checked)
            {                
                LinearBarSeries bar = new LinearBarSeries() { StrokeThickness = 1, StrokeColor = peak_color, FillColor = peak_color, BarWidth = peak_width };
                temp_plot.Model.Series.Add(bar);
            }

        }

        #endregion

        #region FORM 15 extract internal fragments plot
        private void extractPlotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            internal_panel_plotview_rebuild();
        }
        private void internal_panel_plotview_rebuild(bool indexTo=false)
        {
            // index plot            
            PlotView temp_index_plot = new PlotView() { Name = "tempi_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_indexModel = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "internal  fragments' plot sorted by #AA initial", TitleColor = OxyColors.Teal };
            temp_index_plot.Model = temp_indexModel;
            var linearAxis7 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, AxisTitleDistance = 7, MinimumMinorStep = 1.0, TitleFontSize = 11, Title = " # fragments" };
            temp_indexModel.Axes.Add(linearAxis7);
            var linearAxis8 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, MajorStep = xINT_majorStep13, MinorStep = xINT_minorStep13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            temp_indexModel.Axes.Add(linearAxis8);
            temp_index_plot.MouseDoubleClick += (s, e) => { temp_indexModel.ResetAllAxes(); temp_index_plot.InvalidatePlot(true); };
            // index intensity plot            
            PlotView tempindex_Intensity_plot = new PlotView() { Name = "tempiIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_index_Intensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            tempindex_Intensity_plot.Model = temp_index_Intensity_model;
            var linearAxis11 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0, Position = OxyPlot.Axes.AxisPosition.Left };
            temp_index_Intensity_model.Axes.Add(linearAxis11);
            var linearAxis12 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength = x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            temp_index_Intensity_model.Axes.Add(linearAxis12);
            tempindex_Intensity_plot.MouseDoubleClick += (s, e) => { temp_index_Intensity_model.ResetAllAxes(); tempindex_Intensity_plot.InvalidatePlot(true); };
            //bind the 2 axes
            linearAxis7.AxisChanged += (s, e) => { linearAxis11.Zoom(linearAxis7.ActualMinimum, linearAxis7.ActualMaximum); tempindex_Intensity_plot.InvalidatePlot(true); };
            temp_indexModel.Updated += (s, e) => { tempindex_Intensity_plot.Model.Axes[0].Zoom(temp_index_plot.Model.Axes[0].ActualMinimum, temp_index_plot.Model.Axes[0].ActualMaximum); };
            if (indexTo)
            {
                CI_indexTo com1 = new CI_indexTo(); IonDrawIndexTo.Sort(com1);
                temp_indexModel.Title = "internal  fragments' plot sorted by #AA terminal";
                temp_index_plot.Model.Axes[1].Zoom(indexto_plot.Model.Axes[1].ActualMinimum, indexto_plot.Model.Axes[1].ActualMaximum);
                temp_index_plot.Model.Axes[0].Zoom(indexto_plot.Model.Axes[0].ActualMinimum, indexto_plot.Model.Axes[0].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[1].Zoom(indextoIntensity_plot.Model.Axes[1].ActualMinimum, indextoIntensity_plot.Model.Axes[1].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[0].Zoom(indextoIntensity_plot.Model.Axes[0].ActualMinimum, indextoIntensity_plot.Model.Axes[0].ActualMaximum);
            }
            else
            {
                CI_index com2 = new CI_index(); IonDrawIndexTo.Sort(com2);
                temp_index_plot.Model.Axes[1].Zoom(index_plot.Model.Axes[1].ActualMinimum, index_plot.Model.Axes[1].ActualMaximum);
                temp_index_plot.Model.Axes[0].Zoom(index_plot.Model.Axes[0].ActualMinimum, index_plot.Model.Axes[0].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[1].Zoom(indexIntensity_plot.Model.Axes[1].ActualMinimum, indexIntensity_plot.Model.Axes[1].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[0].Zoom(indexIntensity_plot.Model.Axes[0].ActualMinimum, indexIntensity_plot.Model.Axes[0].ActualMaximum);
            }           


            refresh_temp_internal(temp_index_plot, tempindex_Intensity_plot);
            Form15 frm15 = new Form15(temp_index_plot, tempindex_Intensity_plot);
            frm15.Show();
        }
        private void refresh_temp_internal(PlotView temp_index_plot,PlotView tempindex_Intensity_plot)
        {
            if (IonDrawIndexTo.Count() > 0)
            {
                int  k = 1;
                foreach (ion nn in IonDrawIndexTo)
                {
                    List<CustomDataPointIndex> custom_Index = new List<CustomDataPointIndex>();
                    List<CustomDataPointIndex> custom_IndIntensity = new List<CustomDataPointIndex>();
                    if (nn.Charge > 0)
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", "+" + nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }
                    else
                    {
                        custom_Index.Add(new CustomDataPointIndex(nn.Index, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                        custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    }

                    LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    tmp.ItemsSource = custom_Index;
                    tmp.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";
                    temp_index_plot.Model.Series.Add(tmp);

                    custom_IndIntensity.Add(new CustomDataPointIndex(0, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    custom_IndIntensity.Add(new CustomDataPointIndex(nn.Max_intensity, k, nn.Ion_type, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", nn.Charge.ToString(), nn.Max_intensity.ToString("0.###")));
                    LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    bar.ItemsSource = custom_IndIntensity;
                    bar.TrackerFormatString = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}";
                    tempindex_Intensity_plot.Model.Series.Add(bar);
                    k++;
                }                
            }
            tempindex_Intensity_plot.InvalidatePlot(true); temp_index_plot.InvalidatePlot(true);
        }
        private void extractPlotToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            internal_panel_plotview_rebuild(true);
        }

        #endregion

        #region extract primary fragments plot

        private void extractPlotToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(1, ax_plot);
        }

        public void primary_plotview_rebuild(int fplot_type, PlotView original_plotview)
        {
            //plot type 1=ax intensity plot, 2=by intensity plot,3=cz intensity plot, 4=ax charge plot ,5= by charge plot,6=cz charge plot
            PlotView temp_plot = new PlotView() { Name = "temp_plot ", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial" };
            if (fplot_type > 3)
            {
                temp_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial" };
            }
            if (fplot_type == 1|| fplot_type == 4) { temp_model.Title = "a - x  fragments"; temp_model.TitleColor = OxyColors.Green; }
            else if (fplot_type == 2|| fplot_type == 5) { temp_model.Title = "b - y  fragments"; temp_model.TitleColor = OxyColors.Blue; }
            else { temp_model.Title = "c - z  fragments"; temp_model.TitleColor = OxyColors.Red; }           
            temp_plot.Model = temp_model;
            if (fplot_type<4)
            {  
                var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
                temp_model.Axes.Add(linearAxis1);
                var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                temp_model.Axes.Add(linearAxis2);
            }
            else
            {               
                var linearAxis15 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = y_charge_majorStep12, MinorStep = y_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
                temp_model.Axes.Add(linearAxis15);
                var linearAxis16 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                temp_model.Axes.Add(linearAxis16);
            }
            temp_plot.MouseDoubleClick += (s, e) => { temp_model.ResetAllAxes(); temp_plot.InvalidatePlot(true); };
            refresh_temp_primary_plots(temp_plot, fplot_type);
            temp_plot.Model.Axes[1].Zoom(original_plotview.Model.Axes[1].ActualMinimum, original_plotview.Model.Axes[1].ActualMaximum);
            temp_plot.Model.Axes[0].Zoom(original_plotview.Model.Axes[0].ActualMinimum, original_plotview.Model.Axes[0].ActualMaximum);
            Form11 frm11 = new Form11(temp_plot);
            frm11.Show();
        }

        public void refresh_temp_primary_plots(PlotView temp_plot, int fplot_type)
        {
            int iondraw_count = IonDraw.Count;
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            double max_i = 0.0; 
            double max_int = 5000;
            double maxcharge = 0;
            if (fplot_type<4)
            {
                List<double[]> merged_up = new List<double[]>();
                List<double[]> merged_down = new List<double[]>();
                var s1a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red, }; var s2a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
                LinearBarSeries tempUp_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.Green, FillColor = OxyColors.Green, BarWidth = bar_width };
                LinearBarSeries tempDown_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = OxyColors.LimeGreen, FillColor = OxyColors.LimeGreen, BarWidth = bar_width };
                temp_plot.Model.Series.Add(tempUp_bar);
                temp_plot.Model.Series.Add(tempDown_bar);
                if (fplot_type == 1)
                {
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];
                        if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("a", nn.SortIdx))
                            {                                
                                if (merged_up.Count == 0 || (int)merged_up.Last()[0] != nn.SortIdx)
                                {
                                    merged_up.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                                }
                                else
                                {
                                    merged_up.Last()[1] += nn.Max_intensity;
                                }
                                if (max_int < merged_up.Last()[1]) { max_int = merged_up.Last()[1]; }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }                      
                        else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("x", nn.SortIdx))
                            {                               
                                if (merged_down.Count == 0 || (int)merged_down.Last()[0] != nn.SortIdx)
                                {
                                    merged_down.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                                }
                                else
                                {
                                    merged_down.Last()[1] -= nn.Max_intensity;
                                }
                                if (max_int < -merged_down.Last()[1]) { max_int = -merged_down.Last()[1]; }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }           
                    }
                }
                else if (fplot_type ==2)
                {
                    tempUp_bar.StrokeColor = OxyColors.Blue; tempUp_bar.FillColor = OxyColors.Blue;
                    tempDown_bar.StrokeColor = OxyColors.DodgerBlue; tempDown_bar.FillColor = OxyColors.DodgerBlue;
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];                        
                        if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("b", nn.SortIdx))
                            {                              

                                if (merged_up.Count == 0 || (int)merged_up.Last()[0] != nn.SortIdx)
                                {
                                    merged_up.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                                }
                                else
                                {
                                    merged_up.Last()[1] += nn.Max_intensity;
                                }
                                if (max_int < merged_up.Last()[1]) { max_int = merged_up.Last()[1]; }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }                        
                        else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("y", nn.SortIdx))
                            {
                                if (merged_down.Count == 0 || (int)merged_down.Last()[0] != nn.SortIdx)
                                {
                                    merged_down.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                                }
                                else
                                {
                                    merged_down.Last()[1] -= nn.Max_intensity;
                                }
                                if (max_int < -merged_down.Last()[1]) { max_int = -merged_down.Last()[1]; }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }                        
                    }
                }
                else if (fplot_type ==3)
                {
                    tempUp_bar.StrokeColor = OxyColors.Firebrick; tempUp_bar.FillColor = OxyColors.Firebrick;
                    tempDown_bar.StrokeColor = OxyColors.Tomato; tempDown_bar.FillColor = OxyColors.Tomato;
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];                       
                        if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("c", nn.SortIdx))
                            {                                
                                if (merged_up.Count == 0 || (int)merged_up.Last()[0] != nn.SortIdx)
                                {
                                    merged_up.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                                }
                                else
                                {
                                    merged_up.Last()[1] += nn.Max_intensity;
                                }
                                if (max_int < merged_up.Last()[1]) { max_int = merged_up.Last()[1]; }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }                        
                        else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                        {                           
                            if (merged_down.Count == 0 || (int)merged_down.Last()[0] != nn.SortIdx)
                            {
                                merged_down.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                            }
                            else
                            {
                                merged_down.Last()[1] -= nn.Max_intensity;
                            }
                            if (max_int < -merged_down.Last()[1]) { max_int = -merged_down.Last()[1]; }
                            if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                        }
                    }
                }
                foreach (double[] pp in merged_up) { (temp_plot.Model.Series[0] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
                foreach (double[] pp in merged_down) { (temp_plot.Model.Series[1] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
                for (int cc = 0; cc < Peptide.Length; cc++)
                {
                    if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                    {
                        s1a.Points.Add(new ScatterPoint(cc + 1, -max_int * 1.3));
                    }
                    else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                    {
                        s2a.Points.Add(new ScatterPoint(cc + 1, max_int * 1.3));
                    }
                }
                temp_plot.Model.Series.Add(s1a); temp_plot.Model.Series.Add(s2a);
                temp_plot.Model.Axes[0].AxisChanged += (s, e) =>
                {
                    s1a.Points.Clear(); s2a.Points.Clear();
                    for (int cc = 0; cc < Peptide.Length; cc++)
                    {
                        if (Peptide.ToArray()[cc].Equals('D') || Peptide[cc].Equals('E'))
                        {
                            s1a.Points.Add(new ScatterPoint(cc + 1, temp_plot.Model.Axes[0].ActualMinimum));
                        }
                        else if (Peptide.ToArray()[cc].Equals('H') || Peptide[cc].Equals('R') || Peptide[cc].Equals('K'))
                        {
                            s2a.Points.Add(new ScatterPoint(cc + 1, temp_plot.Model.Axes[0].ActualMaximum));
                        }
                    }
                    temp_plot.Model.Series[2] = s1a; temp_plot.Model.Series[3] = s2a; temp_plot.InvalidatePlot(true);
                };
            }
            else
            {
                List<CustomDataPoint> points_up_10 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_100 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_1000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_10000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_100000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_1000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_10000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_100000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_1000000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_up_10000000000 = new List<CustomDataPoint>();
                List<CustomDataPoint> points_down_10 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_100 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_1000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_10000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_100000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_1000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_10000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_100000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_1000000000 = new List<CustomDataPoint>(); List<CustomDataPoint> points_down_10000000000 = new List<CustomDataPoint>();
                List<ion> charge_merged_up = new List<ion>();
                List<ion> charge_merged_down = new List<ion>();
                if (fplot_type == 4)
                {
                    ScatterSeries tempUp_10 = new ScatterSeries() { MarkerSize = 2, Title = "a 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_100 = new ScatterSeries() { MarkerSize = 3, Title = "a 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_1000 = new ScatterSeries() { MarkerSize = 4, Title = "a 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_10000 = new ScatterSeries() { MarkerSize = 5, Title = "a 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_100000 = new ScatterSeries() { MarkerSize = 6, Title = "a 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "a 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "a 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "a 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "a 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Green).ToOxyColor() };
                    ScatterSeries tempUp_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "a 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Green).ToOxyColor() };
                    ScatterSeries tempDown_10 = new ScatterSeries() { MarkerSize = 2, Title = "x 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_100 = new ScatterSeries() { MarkerSize = 3, Title = "x 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_1000 = new ScatterSeries() { MarkerSize = 4, Title = "x 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_10000 = new ScatterSeries() { MarkerSize = 5, Title = "x 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_100000 = new ScatterSeries() { MarkerSize = 6, Title = "x 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "x 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "x 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "x 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "x 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.LimeGreen).ToOxyColor() };
                    ScatterSeries tempDown_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "x 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.LimeGreen).ToOxyColor() };
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];
                        if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("a", nn.SortIdx))
                            {
                                if (charge_merged_up.Count != 0 && charge_merged_up.Last().SortIdx == nn.SortIdx && charge_merged_up.Last().Charge == nn.Charge)
                                {
                                    charge_merged_up.Last().Max_intensity += nn.Max_intensity; charge_merged_up.Last().Mz += " , " + nn.Mz;
                                }
                                else
                                {
                                    charge_merged_up.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }
                        else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("x", nn.SortIdx))
                            {
                                if (charge_merged_down.Count != 0 && charge_merged_down.Last().SortIdx == nn.SortIdx && charge_merged_down.Last().Charge == nn.Charge)
                                {
                                    charge_merged_down.Last().Max_intensity += nn.Max_intensity; charge_merged_down.Last().Mz += " , " + nn.Mz;
                                }
                                else
                                {
                                    charge_merged_down.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }
                    }
                    foreach (ion nn in charge_merged_up)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_up_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_up_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_up_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_up_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_up_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_up_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_up_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_up_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_up_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_up_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    foreach (ion nn in charge_merged_down)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_down_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_down_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_down_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_down_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_down_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_down_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_down_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_down_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_down_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_down_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    tempUp_10.ItemsSource = points_up_10; tempUp_100.ItemsSource = points_up_100; tempUp_1000.ItemsSource = points_up_1000; tempUp_10000.ItemsSource = points_up_10000; tempUp_100000.ItemsSource = points_up_100000; tempUp_1000000.ItemsSource = points_up_1000000; tempUp_10000000.ItemsSource = points_up_10000000; tempUp_100000000.ItemsSource = points_up_100000000; tempUp_1000000000.ItemsSource = points_up_1000000000; tempUp_10000000000.ItemsSource = points_up_10000000000;
                    tempDown_10.ItemsSource = points_down_10; tempDown_100.ItemsSource = points_down_100; tempDown_1000.ItemsSource = points_down_1000; tempDown_10000.ItemsSource = points_down_10000; tempDown_100000.ItemsSource = points_down_100000; tempDown_1000000.ItemsSource = points_down_1000000; tempDown_10000000.ItemsSource = points_down_10000000; tempDown_100000000.ItemsSource = points_down_100000000; tempDown_1000000000.ItemsSource = points_down_1000000000; tempDown_10000000000.ItemsSource = points_down_10000000000;
                    tempUp_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}";
                    tempDown_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}";
                    if (a_Btn.Checked && x_Btn.Checked)
                    {
                        temp_plot.Model.Title = "a - x  fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);
                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else if (a_Btn.Checked)
                    {
                        temp_plot.Model.Title = "a fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);

                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                    }
                    else if (x_Btn.Checked)
                    {
                        temp_plot.Model.Title = "x fragments";
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);

                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else
                    {
                        temp_plot.Model.Title = "a - x  fragments";
                    }
                }
                else if (fplot_type==5)
                {
                    ScatterSeries tempUp_10 = new ScatterSeries() { MarkerSize = 2, Title = "b 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_100 = new ScatterSeries() { MarkerSize = 3, Title = "b 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_1000 = new ScatterSeries() { MarkerSize = 4, Title = "b 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_10000 = new ScatterSeries() { MarkerSize = 5, Title = "b 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_100000 = new ScatterSeries() { MarkerSize = 6, Title = "b 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "b 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "b 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "b 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "b 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Blue).ToOxyColor() };
                    ScatterSeries tempUp_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "b 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Blue).ToOxyColor() };
                    ScatterSeries tempDown_10 = new ScatterSeries() { MarkerSize = 2, Title = "y 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_100 = new ScatterSeries() { MarkerSize = 3, Title = "y 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_1000 = new ScatterSeries() { MarkerSize = 4, Title = "y 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_10000 = new ScatterSeries() { MarkerSize = 5, Title = "y 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_100000 = new ScatterSeries() { MarkerSize = 6, Title = "y 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "y 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "y 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "y 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "y 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.DodgerBlue).ToOxyColor() };
                    ScatterSeries tempDown_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "y 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.DodgerBlue).ToOxyColor() };                   
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];
                        if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("b", nn.SortIdx))
                            {
                                if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("b", nn.SortIdx))
                                {
                                    if(charge_merged_up.Count != 0 && charge_merged_up.Last().SortIdx == nn.SortIdx && charge_merged_up.Last().Charge == nn.Charge)
                                    {
                                        charge_merged_up.Last().Max_intensity += nn.Max_intensity; charge_merged_up.Last().Mz += " , " + nn.Mz;
                                    }
                                    else
                                    {
                                        charge_merged_up.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                    }
                                    if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                                }
                            }
                        }
                        else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("y", nn.SortIdx))
                            {
                                if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("y", nn.SortIdx))
                                {
                                    if (charge_merged_down.Count != 0 && charge_merged_down.Last().SortIdx == nn.SortIdx && charge_merged_down.Last().Charge == nn.Charge)
                                    {
                                        charge_merged_down.Last().Max_intensity += nn.Max_intensity; charge_merged_down.Last().Mz += " , " + nn.Mz;
                                    }
                                    else
                                    {
                                        charge_merged_down.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                    }
                                    if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                                }
                            }
                        }
                    }
                    foreach (ion nn in charge_merged_up)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_up_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_up_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_up_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_up_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_up_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_up_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_up_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_up_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_up_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_up_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    foreach (ion nn in charge_merged_down)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_down_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_down_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_down_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_down_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_down_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_down_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_down_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_down_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_down_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_down_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    tempUp_10.ItemsSource = points_up_10; tempUp_100.ItemsSource = points_up_100; tempUp_1000.ItemsSource = points_up_1000; tempUp_10000.ItemsSource = points_up_10000; tempUp_100000.ItemsSource = points_up_100000; tempUp_1000000.ItemsSource = points_up_1000000; tempUp_10000000.ItemsSource = points_up_10000000; tempUp_100000000.ItemsSource = points_up_100000000; tempUp_1000000000.ItemsSource = points_up_1000000000; tempUp_10000000000.ItemsSource = points_up_10000000000;
                    tempDown_10.ItemsSource = points_down_10; tempDown_100.ItemsSource = points_down_100; tempDown_1000.ItemsSource = points_down_1000; tempDown_10000.ItemsSource = points_down_10000; tempDown_100000.ItemsSource = points_down_100000; tempDown_1000000.ItemsSource = points_down_1000000; tempDown_10000000.ItemsSource = points_down_10000000; tempDown_100000000.ItemsSource = points_down_100000000; tempDown_1000000000.ItemsSource = points_down_1000000000; tempDown_10000000000.ItemsSource = points_down_10000000000;
                    tempUp_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}";
                    tempDown_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}";
                    if (b_Btn.Checked && y_Btn.Checked)
                    {
                        temp_plot.Model.Title = "b - y  fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);

                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else if (b_Btn.Checked)
                    {
                        temp_plot.Model.Title = "b  fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);

                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                    }
                    else if (y_Btn.Checked)
                    {
                        temp_plot.Model.Title = "y  fragments";
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);
                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else
                    {
                        temp_plot.Model.Title = "b - y  fragments";
                    }
                }
                else if (fplot_type == 6)
                {
                    ScatterSeries tempUp_10 = new ScatterSeries() { MarkerSize = 2, Title = "c 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_100 = new ScatterSeries() { MarkerSize = 3, Title = "c 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_1000 = new ScatterSeries() { MarkerSize = 4, Title = "c 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_10000 = new ScatterSeries() { MarkerSize = 5, Title = "c 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_100000 = new ScatterSeries() { MarkerSize = 6, Title = "c 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "c 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "c 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "c 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "c 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempUp_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "c 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Firebrick).ToOxyColor() };
                    ScatterSeries tempDown_10 = new ScatterSeries() { MarkerSize = 2, Title = "z 10^1", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(255, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_100 = new ScatterSeries() { MarkerSize = 3, Title = "z 10^2", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(230, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_1000 = new ScatterSeries() { MarkerSize = 4, Title = "z 10^3", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(205, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_10000 = new ScatterSeries() { MarkerSize = 5, Title = "z 10^4", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(180, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_100000 = new ScatterSeries() { MarkerSize = 6, Title = "z 10^5", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(155, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_1000000 = new ScatterSeries() { MarkerSize = 7, Title = "z 10^6", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(130, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_10000000 = new ScatterSeries() { MarkerSize = 8, Title = "z 10^7", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(105, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_100000000 = new ScatterSeries() { MarkerSize = 9, Title = "z 10^8", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(80, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_1000000000 = new ScatterSeries() { MarkerSize = 10, Title = "z 10^9", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(55, Color.Tomato).ToOxyColor() };
                    ScatterSeries tempDown_10000000000 = new ScatterSeries() { MarkerSize = 11, Title = "z 10^10", MarkerType = MarkerType.Circle, MarkerFill = Color.FromArgb(30, Color.Tomato).ToOxyColor() };
                   
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = IonDraw[i];
                        if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("c", nn.SortIdx))
                            {
                                if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("c", nn.SortIdx))
                                {
                                    if (charge_merged_up.Count != 0 && charge_merged_up.Last().SortIdx == nn.SortIdx && charge_merged_up.Last().Charge == nn.Charge)
                                    {
                                        charge_merged_up.Last().Max_intensity += nn.Max_intensity; charge_merged_up.Last().Mz += " , " + nn.Mz;
                                    }
                                    else
                                    {
                                        charge_merged_up.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                    }
                                    if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                                }
                            }
                        }
                        else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3")) || search_primary("z", nn.SortIdx))
                            {
                                if (charge_merged_down.Count != 0 && charge_merged_down.Last().SortIdx == nn.SortIdx && charge_merged_down.Last().Charge == nn.Charge)
                                {
                                    charge_merged_down.Last().Max_intensity += nn.Max_intensity; charge_merged_down.Last().Mz += " , " + nn.Mz;
                                }
                                else
                                {
                                    charge_merged_down.Add(new ion { SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity });
                                }
                                if (maxcharge < nn.Charge) { maxcharge = nn.Charge; }
                            }
                        }
                    }
                    foreach (ion nn in charge_merged_up)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_up_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_up_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_up_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_up_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_up_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_up_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_up_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_up_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_up_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_up_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    foreach (ion nn in charge_merged_down)
                    {
                        if (nn.Max_intensity / 10 < 10) { points_down_10.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100 < 10) { points_down_100.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000 < 10) { points_down_1000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000 < 10) { points_down_10000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000 < 10) { points_down_100000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000 < 10) { points_down_1000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 10000000 < 10) { points_down_10000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 100000000 < 10) { points_down_100000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else if (nn.Max_intensity / 1000000000 < 10) { points_down_1000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                        else { points_down_10000000000.Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name)); }
                    }
                    tempUp_10.ItemsSource = points_up_10; tempUp_100.ItemsSource = points_up_100; tempUp_1000.ItemsSource = points_up_1000; tempUp_10000.ItemsSource = points_up_10000; tempUp_100000.ItemsSource = points_up_100000; tempUp_1000000.ItemsSource = points_up_1000000; tempUp_10000000.ItemsSource = points_up_10000000; tempUp_100000000.ItemsSource = points_up_100000000; tempUp_1000000000.ItemsSource = points_up_1000000000; tempUp_10000000000.ItemsSource = points_up_10000000000;
                    tempDown_10.ItemsSource = points_down_10; tempDown_100.ItemsSource = points_down_100; tempDown_1000.ItemsSource = points_down_1000; tempDown_10000.ItemsSource = points_down_10000; tempDown_100000.ItemsSource = points_down_100000; tempDown_1000000.ItemsSource = points_down_1000000; tempDown_10000000.ItemsSource = points_down_10000000; tempDown_100000000.ItemsSource = points_down_100000000; tempDown_1000000000.ItemsSource = points_down_1000000000; tempDown_10000000000.ItemsSource = points_down_10000000000;
                    tempUp_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}"; tempUp_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}";
                    tempDown_10.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_100000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_1000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}"; tempDown_10000000000.TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}";
                    if (c_Btn.Checked && z_Btn.Checked)
                    {
                        temp_plot.Model.Title = "c - z  fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);
                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else if (c_Btn.Checked)
                    {
                        temp_plot.Model.Title = "c fragments";
                        if (points_up_10000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000000);
                        if (points_up_1000000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000000);
                        if (points_up_100000000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000000);
                        if (points_up_10000000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000000);

                        if (points_up_1000000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000000);
                        if (points_up_100000.Count > 0) temp_plot.Model.Series.Add(tempUp_100000);
                        if (points_up_10000.Count > 0) temp_plot.Model.Series.Add(tempUp_10000);
                        if (points_up_1000.Count > 0) temp_plot.Model.Series.Add(tempUp_1000);
                        if (points_up_100.Count > 0) temp_plot.Model.Series.Add(tempUp_100);
                        if (points_up_10.Count > 0) temp_plot.Model.Series.Add(tempUp_10);
                    }
                    else if (z_Btn.Checked)
                    {
                        temp_plot.Model.Title = "z fragments";
                        if (points_down_10000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000000);
                        if (points_down_1000000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000000);
                        if (points_down_100000000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000000);
                        if (points_down_10000000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000000);
                        if (points_down_1000000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000000);
                        if (points_down_100000.Count > 0) temp_plot.Model.Series.Add(tempDown_100000);
                        if (points_down_10000.Count > 0) temp_plot.Model.Series.Add(tempDown_10000);
                        if (points_down_1000.Count > 0) temp_plot.Model.Series.Add(tempDown_1000);
                        if (points_down_100.Count > 0) temp_plot.Model.Series.Add(tempDown_100);
                        if (points_down_10.Count > 0) temp_plot.Model.Series.Add(tempDown_10);
                    }
                    else
                    {
                        temp_plot.Model.Title = "c - z  fragments";
                    }
                }               
                temp_plot.Model.Axes[0].Minimum =  0;
                temp_plot.Model.Axes[0].Maximum = maxcharge + 1; 
            }
            temp_plot.Model.Axes[1].Minimum = 0;
            temp_plot.Model.Axes[1].Maximum = Peptide.Length;
            temp_plot.InvalidatePlot(true);
        }

        private void extractPlotToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(2, by_plot);
        }

        private void extractPlotToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(3, cz_plot);
        }

        private void extractPlotToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(4, axCharge_plot);
        }

        private void extractPlotToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(5, byCharge_plot);
        }

        private void extractPlotToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(6, czCharge_plot);
        }

        #endregion

    }
}