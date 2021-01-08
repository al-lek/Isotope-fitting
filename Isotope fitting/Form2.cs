﻿using OxyPlot;
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
using static Isotope_fitting.Helpers;

using Arction.WinForms.Charting;
using Arction.WinForms.Charting.Axes;
using Arction.WinForms.Charting.SeriesXY;
using Arction.WinForms.Charting.EventMarkers;
using Arction.WinForms.Charting.Titles;
using Arction.WinForms.Charting.Views.ViewXY;
using Arction.WinForms.Charting.Annotations;
using System.ComponentModel;
using OxyPlot.Axes;
using Newtonsoft.Json;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Isotope_fitting
{   
    public partial class Form2 : Form
    {
        public static ColorDialog clrDlg = new ColorDialog();
        Calculator_input _data = new Calculator_input();
        bool is_ult_fragmentor_file = false;

        #region PARAMETER SET TAB FIT
        private Form24 frm24;
        private Form24_2 frm24_2;        
        public bool is_help = false;
        public bool is_riken = false;
        public bool is_rna = false;
        bool is_polarity_negative = false;
        public static ListBox machine_listBox = new ListBox();
        public static ListBox machine_listBox1 = new ListBox();
        public static bool machine_listBox_eventAddedFlag = false;
        public static bool machine_listBox1_eventAddedFlag = false;
        
        BackgroundWorker _bw_save_envipat = new BackgroundWorker();
        LightningChartUltimate LC_1 = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { Dock = DockStyle.Fill, ColorTheme = ColorTheme.LightGray, AutoScaleMode = AutoScaleMode.Inherit };
        LightningChartUltimate LC_2 = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { Dock = DockStyle.Fill, ColorTheme = ColorTheme.LightGray, AutoScaleMode = AutoScaleMode.Inherit };
        bool x_charged = false;
        public double threshold = 0.01;
        public List<SequenceTab> sequenceList = new List<SequenceTab>();
        public bool tab_mode = false;
        int duplicate_count = 0;
        public int machine_sel_index = 9;
        public string res_string_24 = "";
        int added = 0;
        public bool is_frag_calc_recalc = false;
        bool is_recalc_res = false;
        #region deconvoluted
        public bool is_exp_deconvoluted = false;
        int dec_charge =1;
        public string deconv_machine = "";
        public bool is_deconv_const_resolution = false;
        List<List<double[]>> experimental_dec = new List<List<double[]>>();
        BackgroundWorker _bw_deconcoluted_exp_resolution = new BackgroundWorker();
        #endregion

        #region exclude indexes
        public List<ExcludeTypes> exclude_a_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_b_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_c_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_x_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_y_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_z_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_d_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_w_indexes = new List<ExcludeTypes>();
        public List<ExcludeTypes> exclude_internal_indexes = new List<ExcludeTypes>();
        public List<string[]> list_21 = new List<string[]>();
        #endregion

        #region SAVE-LOAD PROJECT
        int all = 0;
        string project_experimental = "";
        //save
        BackgroundWorker _bw_save_project_frag = new BackgroundWorker();
        BackgroundWorker _bw_save_project_peaks = new BackgroundWorker();
        BackgroundWorker _bw_save_project_fit_results = new BackgroundWorker();
        //load
        BackgroundWorker _bw_load_project_exp = new BackgroundWorker();
        BackgroundWorker _bw_load_project_peaks = new BackgroundWorker();
        BackgroundWorker _bw_load_project_fragments = new BackgroundWorker();
        BackgroundWorker _bw_load_project_fit_results = new BackgroundWorker();
        //parameters
        bool dont_refresh_frag_tree = false;
        #endregion

        #region old new calculations        
        int exp_res = 0;
        public int neues = 0;
        public static bool insert_exp = false;        
        public string file_name = "";
        public bool calc_resolution = true;
        public bool recalc = true;

        public static List<ChemiForm> ChemFormulas = new List<ChemiForm>();
        public string Peptide = String.Empty;
        public string heavy_chain = String.Empty;
        public string light_chain = String.Empty;
        public bool heavy_present = false;
        public bool light_present = false;
        public bool ms_heavy_chain = false;
        public bool ms_light_chain = false;
        public string ms_extension = String.Empty;
        public string ms_sequence = String.Empty;        
       
        List<ChemiForm> selectedIons = new List<ChemiForm>();                 
        public static List<FragForm> Fragments2 = new List<FragForm>();
        public static List<FragForm> Fragments5 = new List<FragForm>();
        bool frag_types_save = false;
        public List<int> selectedFragments = new List<int>();
        public List<int> selectedFragments_fragTypes = new List<int>();
        public static double max_exp = 0.0;       

        private ListViewItemComparer _lvwItemComparer;
        #region colours     
        OxyColor[] data_colors = new OxyColor[21] { OxyColors.Black, OxyColors.Green, OxyColors.IndianRed, OxyColors.Turquoise, OxyColors.DarkViolet, OxyColors.SlateGray, OxyColors.DarkRed, OxyColors.DarkOliveGreen, OxyColors.DarkSlateBlue,
            OxyColors.DarkKhaki, OxyColors.DimGray, OxyColors.DeepPink, OxyColors.Ivory, OxyColors.Tan, OxyColors.Orange, OxyColors.Olive, OxyColors.MistyRose, OxyColors.Moccasin, OxyColors.MediumOrchid, OxyColors.LimeGreen, OxyColors.LightGoldenrodYellow};
        OxyColor[] charge_colors = new OxyColor[21] { OxyColors.Black, OxyColors.Green, OxyColors.IndianRed, OxyColors.Turquoise, OxyColors.DarkViolet, OxyColors.SlateGray, OxyColors.DarkRed, OxyColors.DarkOliveGreen, OxyColors.DarkSlateBlue,
            OxyColors.DarkKhaki, OxyColors.DimGray, OxyColors.DeepPink, OxyColors.Ivory, OxyColors.Tan, OxyColors.Orange, OxyColors.Olive, OxyColors.MistyRose, OxyColors.Moccasin, OxyColors.MediumOrchid, OxyColors.LimeGreen, OxyColors.LightGoldenrodYellow};

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

        List<double[]> experimental = new List<double[]>();
        List<double[]> current_experimental = new List<double[]>();

        List<double[]> all_data_aligned = new List<double[]>();
        public static List<List<double[]>> selected_all_data = new List<List<double[]>>();

        List<double[]> aligned_intensities = new List<double[]>();
        List<double[]> fitted_results = new List<double[]>();
        List<int[]> powerSet = new List<int[]>();
        List<int[]> powerSet_distroIdx = new List<int[]>();
        List<int> last_ploted_iso = new List<int>();
        List<double[]> summation = new List<double[]>();
        List<double[]> residual = new List<double[]>();
        public static List<int> custom_colors = new List<int>();

        const double H_mass = 1.008;
        bool is_loading = false; //indicates if loading is active
        bool is_applying_fit = false;
        private bool is_calc = false;
                
        /// <summary> [0]index , [1]experimental mz , [2]experimental height , [3]resolution , [4]adjusted relative mz , [5]adjusted height , [6]FWHM dt [bins] </summary>
        public static List<double[]> peak_points = new List<double[]>();
        bool count_distance = false;

        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        Stopwatch sw3 = new Stopwatch();       
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
        MyTreeView frag_tree = new MyTreeView()
        {
            BackColor = Color.GhostWhite,
            Dock = DockStyle.Fill
            /*Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right*/,
            BorderStyle = BorderStyle.FixedSingle,
            CheckBoxes = true,
            HideSelection = false,
            Location = new System.Drawing.Point(2, 134),
            Name = "frag_tree",
            Size = new System.Drawing.Size(341, 323),
            TabIndex = 1000000,
            Visible = false, ShowNodeToolTips = false
        };
        string root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();

        string loaded_lists = "";
        List<string> loaded_MSproducts = new List<string>();

        #endregion

        #region parameters

        public bool entire_spectrum = true;
        public List<ppm_area> ppm_regions = new List<ppm_area>();
        /// <summary> max ppm error </summary>
        public double ppmError = 8.0;
        /// <summary> peak detect min intensity </summary>
        public double min_intes = 50.0;
        /// <summary>size of fragments groups </summary>
        public int frag_mzGroups = 40;
        /// <summary> size of fit group </summary>
        static public int fit_bunch = 6;
        /// <summary>  size of fit overlap  </summary>
        static public int fit_cover = 2;
        /// <summary>  [1 most intence,2 most intence,3 most intence,half most intence,half(-) most intence,half(+) most intence]  </summary>
        public bool[] selection_rule = new bool[] { true, false, false, false, false, false };
        /// <summary> when this parameter is set to true it prevents function refresh plot to be multiply called</summary>
        bool block_plot_refresh = false;
        /// <summary> when this parameter is set to true it prevents the Fragment List treeview to expand all nodes when "check all" is selected</summary>
        bool block_expand = false;
        /// <summary> when Fit results control is under processing this parameter is set to true, and prevents functions related with "fit node check changed" to be multiply called</summary>
        bool block_fit_refresh = false;
        /// <summary> max ppm error used in di and ei calculation during fitting </summary>
        static public double ppmDi = 8.0;
        public bool ignore_ppm_refresh = false;
        private TreeNode _currentNode = new TreeNode();
        #endregion

        #region Fit results 
        //sorting parameters
        /// <summary>[Mi sort,M sort,di sort,sse sort, ei sort, dinew sort](6) </summary>
        public static bool[] fit_sort = new bool[] { true, false, false, false, false, false };
        /// <summary>[Mi thres,M thres,di thres,ei thres,dinew thres,sd,sdnew](7) </summary>
        public static double[] fit_thres = new double[] { 100.0, 100.0, 100.0, 100.0, 100.0, 100.0, 100.0 };
        /// <summary>[Mi coef,M coef,di coef,sse coef,ei coef,dinew coef](6)</summary>
        public static double[] a_coef = new double[] { 1.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        public static int visible_results = 100;
        public static int best_num_results = 1;

        /// <summary> list [Mi sort,M sort,di sort,sse sort, ei sort, dinew sort](6)</summary>
        public static List<bool[]> tab_node = new List<bool[]>();
        /// <summary>list [Mi coef,M coef,di coef,sse coef,ei coef,dinew coef](6) </summary>
        public static List<double[]> tab_coef = new List<double[]>();
        /// <summary>list [Mi thres,M thres,di thres,ei thres,dinew thres,sd, sdnew](7) </summary>
        public static List<double[]> tab_thres = new List<double[]>();
        /// <summary>stores the checked nodes of the Fit Results treeview </summary>
        List<string> labels_checked = new List<string>();
        /// <summary>Tooltip used for the Fit Results treeview </summary>
        private ToolTip toolTip_fit = new ToolTip() { InitialDelay = 1, IsBalloon = false, ReshowDelay = 1, UseFading = true, AutoPopDelay = 10000 };
        string tool_text = "";
        #endregion

        #region  Constants for the SendMessage() method.
        private const int WM_HSCROLL = 276;
        private const int SB_LEFT = 6;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg,
                                          int wParam, int lParam);

        #endregion

        #region plot area format 
        /// <summary>Ion types in this application mode </summary>
        public string[] frag = new string[] { "a", "b", "c", "x", "y", "z", "d", "v", "w", "internal a", "internal b", "M" };
        /// <summary>List with the ion types that are allowed to display the fragments labels in the spectrum plot  </summary>
        public string[] label_frag = new string[] { };
        /// <summary>List with the ion types that are allowed to be viewed in the spectrum plot  </summary>
        public string[] view_frag = new string[] { };
        // tab1 line isoplot
        public OxyColor fit_color = OxyColors.Black;
        public int exp_color = OxyColors.Black.ToColor().ToArgb();
        public OxyColor peak_color = OxyColors.Black;
        public LinePattern fit_style = LinePattern.Dot;
        public LinePattern exper_style = LinePattern.Solid;
        public LinePattern frag_style = LinePattern.Solid;
        public double exp_width = 1;
        public double frag_width = 2;
        public double fit_width = 1;
        public double peak_width = 0.5;
        public double cen_width = 0.5;
        // tab2 axis isoplot
        public bool Xmajor_grid = false;
        public bool Xminor_grid = false;
        public bool Ymajor_grid = false;
        public bool Yminor_grid = false;
        public OxyPlot.Axes.TickStyle X_tick = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_tick = OxyPlot.Axes.TickStyle.Outside;
        public double x_interval = 50;
        public double y_interval = 50;
        public string x_format = "G";
        public string y_format = "0.0E+";
        public string x_numformat = "0";
        public string y_numformat = "0";
        public double annotation_size = 9.0;
        #endregion               

        #endregion

        #region PARAMETER SET TAB DIAGRAMS
        bool block_tab_diagrams_refresh = false;
        List<ion> IonDraw = new List<ion>();
        List<ion> IonDrawIndex = new List<ion>();
        List<ion> IonDrawIndexTo = new List<ion>();
       
        //sequence
        Pen p = new Pen(Color.Black);
        public Color highlight_color = Color.SlateGray;
        public bool is_rgb_color_range = true;
        public Int64 seq_min_val = 10;
        public Int64 seq_max_val = 10000000000;
        public int seq_reg = 6;

        PlotView ax_plot;
        PlotView by_plot;
        PlotView cz_plot;
        PlotView dz_plot;
        PlotView axCharge_plot;
        PlotView byCharge_plot;
        PlotView czCharge_plot;
        PlotView dzCharge_plot;
        PlotView index_plot;
        PlotView indexto_plot;
        PlotView indexIntensity_plot;
        PlotView indextoIntensity_plot;
        PlotView ppm_plot;

        #region plot areas format        
        //ppm plot
        public OxyPlot.LineStyle Xmajor_ppm_grid = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Xminor_ppm_grid = OxyPlot.LineStyle.None;
        public OxyPlot.LineStyle Ymajor_ppm_grid = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Yminor_ppm_grid = OxyPlot.LineStyle.None;
        public OxyPlot.Axes.TickStyle X_ppm_tick = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_ppm_tick = OxyPlot.Axes.TickStyle.Outside;
        public double y_ppm_majorStep = 2;
        public double y_ppm_minorStep = 1;
        public double x_ppm_majorStep = 5;
        public double x_ppm_minorStep = 1;
        public double x_ppm_interval = 20;
        public double ppm_bullet_size = 1.0;
        public int ppm_graph_type = 1;
        public double first_m_z = 0.0;
        public double last_m_z = 0.0;
        //primary tab plots        //intensity
        public OxyPlot.LineStyle Xmajor_grid12 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Xminor_grid12 = OxyPlot.LineStyle.None;
        public OxyPlot.LineStyle Ymajor_grid12 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Yminor_grid12 = OxyPlot.LineStyle.None;
        public double y_interval12 = 50;
        public OxyPlot.Axes.TickStyle X_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public string y_format12 = "0.0E+";
        public string y_numformat12 = "0";
        public double x_majorStep12 = 5;
        public double x_minorStep12 = 1;
        public double bar_width = 1;
        //primary tab plots        //charge
        public OxyPlot.LineStyle Xmajor_charge_grid12 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Xminor_charge_grid12 = OxyPlot.LineStyle.None;
        public OxyPlot.LineStyle Ymajor_charge_grid12 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Yminor_charge_grid12 = OxyPlot.LineStyle.None;
        public OxyPlot.Axes.TickStyle X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
        public double y_charge_majorStep12 = 2;
        public double y_charge_minorStep12 = 1;
        public double x_charge_majorStep12 = 5;
        public double x_charge_minorStep12 = 1;
        // primary color
        public OxyColor color_primary = OxyColors.Lavender;
        public List<int[]> color_primary_indexes = new List<int[]>();
        //internal color
        public OxyColor color_internal = OxyColors.Lavender;
        public List<int[]> color_internal_indexes = new List<int[]>();
        //internal tab plots
        public OxyPlot.LineStyle Xint_major_grid13 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Xint_minor_grid13 = OxyPlot.LineStyle.None;
        public OxyPlot.LineStyle Yint_major_grid13 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Yint_minor_grid13 = OxyPlot.LineStyle.None;
        public string x_format13 = "0.0E+";
        public string x_numformat13 = "0";
        public double x_interval13 = 50;
        public OxyPlot.Axes.TickStyle Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;
        public double xINT_majorStep13 = 5;
        public double xINT_minorStep13 = 1;
        public double yINT_majorStep13 = 5;
        public double yINT_minorStep13 = 1;
        public double int_width = 1;
        //Hydrogens tab plots        
        public OxyPlot.LineStyle Xmajor_grid12_2 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Xminor_grid12_2 = OxyPlot.LineStyle.None;
        public OxyPlot.LineStyle Ymajor_grid12_2 = OxyPlot.LineStyle.Solid;
        public OxyPlot.LineStyle Yminor_grid12_2 = OxyPlot.LineStyle.None;
        public double y_interval12_2 = 50;
        public OxyPlot.Axes.TickStyle X_tick12_2 = OxyPlot.Axes.TickStyle.Outside;
        public OxyPlot.Axes.TickStyle Y_tick12_2 = OxyPlot.Axes.TickStyle.Outside;
        public string y_format12_2 = "0.0E+";
        public string y_numformat12_2 = "0";
        public double x_majorStep12_2 = 5;
        public double x_minorStep12_2 = 1;
        public double line_width_2 = 2;
        #endregion

        #endregion
        
        public Form2()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            InitializeComponent();
            Initialize_machine_listboxes();
            // declare event to continue calculations after Fragments2 are complete
            OnEnvelopeCalcCompleted += () => { fragments_and_calculations_sequence_B(); };
            // declare event to plot fit results after fitting calculations are complete
            OnFittingCalcCompleted += () => { update_sorting_parameters_lists(); generate_fit_results(); };
            //declare event to refresh iso plot after recalculation of all data aligned
            OnRecalculate_completed += () => { refresh_iso_plot(); };
            //load saved references and reset UI
            load_preferences();
            reset_all();
            fragTreePanel.Controls.Add(frag_tree);
            Initialize_BW();
            change_application(true);
            //call change state window
            initiate_change_app_mode_form();
            //PatchParameter("", 0);
            //run_cmd("", "");
            //rin_python();
        }

        #region init
        /// <summary> Machine listboxes are the ones that contain the Machines with their default resolution list. </summary>
        private void Initialize_machine_listboxes()
        {
            // 
            // machine_listBox
            // 
            machine_listBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            machine_listBox.FormattingEnabled = true;
            machine_listBox.Items.AddRange(new object[] {
            "Elite_R240000@400",
            "Elite_R120000@400",
            "Elite_R60000@400",
            "Elite_R30000@400",
            "OrbitrapXL,Velos,VelosPro_R120000@400",
            "OrbitrapXL,Velos,VelosPro_R60000@400",
            "OrbitrapXL,Velos,VelosPro_R30000@400",
            "OrbitrapXL,Velos,VelosPro_R15000@400",
            "OrbitrapXL,Velos,VelosPro_R7500@400",
            "Q-Exactive,ExactivePlus_280K@200",
            "Q-Exactive,ExactivePlus_R140000@200",
            "Q-Exactive,ExactivePlus_R70000@200",
            "Q-Exactive,ExactivePlus_R35000@200",
            "Q-Exactive,ExactivePlus_R17500@200",
            "Exactive_R100000@200",
            "Exactive_R50000@200",
            "Exactive_R25000@200",
            "Exactive_R12500@200",
            "OTFusion,QExactiveHF_480000@200",
            "OTFusion,QExactiveHF_240000@200",
            "OTFusion,QExactiveHF_120000@200",
            "OTFusion,QExactiveHF_60000@200",
            "OTFusion,QExactiveHF_30000@200",
            "OTFusion,QExactiveHF_15000@200",
            "TripleTOF5600_R28000@200",
            "QTOF_XevoG2-S_R25000@200",
            "TripleTOF6600_R30000@400             "});
            machine_listBox.Location = new System.Drawing.Point(94, 470);
            machine_listBox.Name = "machine_listBox";
            machine_listBox.Size = new System.Drawing.Size(191, 56);
            machine_listBox.TabIndex = 21;
            machine_listBox.SelectedIndex = machine_sel_index;
            // 
            // machine_listBox1
            // 
            machine_listBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            machine_listBox1.FormattingEnabled = true;
            machine_listBox1.Items.AddRange(new object[] {
            "Elite_R240000@400",
            "Elite_R120000@400",
            "Elite_R60000@400",
            "Elite_R30000@400",
            "OrbitrapXL,Velos,VelosPro_R120000@400",
            "OrbitrapXL,Velos,VelosPro_R60000@400",
            "OrbitrapXL,Velos,VelosPro_R30000@400",
            "OrbitrapXL,Velos,VelosPro_R15000@400",
            "OrbitrapXL,Velos,VelosPro_R7500@400",
            "Q-Exactive,ExactivePlus_280K@200",
            "Q-Exactive,ExactivePlus_R140000@200",
            "Q-Exactive,ExactivePlus_R70000@200",
            "Q-Exactive,ExactivePlus_R35000@200",
            "Q-Exactive,ExactivePlus_R17500@200",
            "Exactive_R100000@200",
            "Exactive_R50000@200",
            "Exactive_R25000@200",
            "Exactive_R12500@200",
            "OTFusion,QExactiveHF_480000@200",
            "OTFusion,QExactiveHF_240000@200",
            "OTFusion,QExactiveHF_120000@200",
            "OTFusion,QExactiveHF_60000@200",
            "OTFusion,QExactiveHF_30000@200",
            "OTFusion,QExactiveHF_15000@200",
            "TripleTOF5600_R28000@200",
            "QTOF_XevoG2-S_R25000@200",
            "TripleTOF6600_R30000@400             "});
            machine_listBox1.Location = new System.Drawing.Point(102, 487);
            machine_listBox1.Name = "machine_listBox1";
            machine_listBox1.Size = new System.Drawing.Size(191, 56);
            machine_listBox1.TabIndex = 21;
            machine_listBox1.SelectedIndex = machine_sel_index;
        }
        /// <summary> Initialize BackgroundWorkers used in several actions noted analytically in the comments</summary>
        private void Initialize_BW()
        {           
            //save .fit file
            _bw_save_envipat.DoWork += new DoWorkEventHandler(Save_frag_envipat);
            _bw_save_envipat.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_save_envipat_RunWorkerCompleted);
            //save project
            _bw_save_project_frag.DoWork += new DoWorkEventHandler(Project_save_fragments);
            _bw_save_project_frag.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_project_frag_RunWorkerCompleted);
            _bw_save_project_peaks.DoWork += new DoWorkEventHandler(Project_save_peaks);
            _bw_save_project_peaks.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_project_peaks_RunWorkerCompleted);
            _bw_save_project_fit_results.DoWork += new DoWorkEventHandler(Project_save_fit_results);
            _bw_save_project_fit_results.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_project_fitResults_RunWorkerCompleted);
            //load project
            _bw_load_project_exp.DoWork += new DoWorkEventHandler(Project_load_experimental);
            _bw_load_project_exp.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_load_project_exp_RunWorkerCompletedAsync);
            _bw_load_project_peaks.DoWork += new DoWorkEventHandler(Project_load_peaks);
            _bw_load_project_peaks.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_load_project_peaks_RunWorkerCompleted);
            _bw_load_project_fragments.DoWork += new DoWorkEventHandler(Project_load_fragments);
            _bw_load_project_fragments.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_load_project_fragments_RunWorkerCompleted);
            _bw_load_project_fit_results.DoWork += new DoWorkEventHandler(Project_load_fit_results);
            _bw_load_project_fit_results.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_load_project_fit_RunWorkerCompleted);
            //deconvolution
            _bw_deconcoluted_exp_resolution.DoWork += new DoWorkEventHandler(find_resolution);
            _bw_deconcoluted_exp_resolution.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_find_exp_resolution_RunWorkerCompleted);
        }
        #region save load bw
        /// <summary> BackgroundWorker used in save Experimental peaks (Save project) completed its task </summary>
        void _bw_project_peaks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            progress_display_update(2 * all);
            if (all == 3)
            {
                progress_display_stop();
                MessageBox.Show("You are ready!! Save project procedure is completed!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        /// <summary> BackgroundWorker used in save Fragment List (Save project) completed its task </summary>
        void _bw_project_frag_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            progress_display_update(2 * all);
            if (all == 3)
            {
                progress_display_stop();
                MessageBox.Show("You are ready!! Save project procedure is completed!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        /// <summary> BackgroundWorker used in save Fit Results (Save project) completed its task </summary>
        void _bw_project_fitResults_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            progress_display_update(2 * all);
            if (all == 3)
            {
                progress_display_stop();
                MessageBox.Show("You are ready!! Save project procedure is completed!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString(); }
        }
        /// <summary> BackgroundWorker used in Load Experimental profile (Load project) completed its task </summary>
        void _bw_load_project_exp_RunWorkerCompletedAsync(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            if (all == 4)
            {
                 Project_after_load();
                MessageBox.Show("Load project procedure is completed! You are all set to start processing!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        /// <summary> BackgroundWorker used in Load Experimental peaks (Load project) completed its task </summary>
        void _bw_load_project_peaks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            if (all == 4)
            {
                 Project_after_load();
                MessageBox.Show("Load project procedure is completed! You are all set to start processing!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        /// <summary> BackgroundWorker used in Load Fragment List (Load project) completed its task </summary>
        void _bw_load_project_fragments_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            if (all == 4)
            {
                 Project_after_load();
                MessageBox.Show("Load project procedure is completed! You are all set to start processing!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        /// <summary> BackgroundWorker used in Load Fit results (Load project) completed its task </summary>
        void _bw_load_project_fit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            all++;
            if (all == 4)
            {
                 Project_after_load();
                MessageBox.Show("Load project procedure is completed! You are all set to start processing!");
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
        }
        #endregion
        private void Form2_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
        /// <summary> In treeview when a node is "Visible" the treeview scrolls to the right and as a result the node's checkbox is not visible. This function prevents that effect </summary>
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
        public class lastElement : IComparer
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare((y as double[]).Last(), (x as double[]).Last()));
            }

        }
        #endregion

        #region Change application mode      
        private void application_proj_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows application mode dialog", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            //if any other form rather than the main is open, it must be closed
            CloseAllOpenForm("Form2");
            initiate_change_app_mode_form();
        }
        private void initiate_change_app_mode_form()
        {
            ChangeStateForm frmC = new ChangeStateForm(this);
            frmC.ShowDialog();
        }
        /// <summary>Clear all the data and changes application mode </summary>
        public void change_application(bool changed = true)
        {
            if (changed)
            {
                Clear_all();
                groupBoxIntensity4.Visible = groupBoxCharge4.Visible = is_riken;
                ppm_toolStrip4.Visible = !is_riken;
                losses_groupBox_d.Visible = is_riken;
                losses_groupBox_w.Visible = is_riken;
                protein_seq_Btn.Visible = !is_riken;
                riken_seq_Btn.Visible = is_riken;
                dvw_chBx.Visible = dvw_chBxCopy1.Visible = dvw_chBxCopy2.Visible = !is_riken;
                foreach (ToolStrip strip in GetControls(panel2_tab2).OfType<ToolStrip>().Where(l => l.Name.Contains("ppm")))
                {
                    foreach (ToolStripButton btn in strip.Items.OfType<ToolStripButton>())
                    {
                        if (btn.Name.Contains("ppm_B_") || btn.Name.Contains("_w") || btn.Name.Contains("_d")) btn.Visible = is_riken;
                        if (is_riken && btn.Text.Contains("NH3")) { btn.Text = btn.Text.Replace("NH3", "B()"); }
                        if (is_riken && btn.Text.Contains("internal a")) { btn.Text = btn.Text.Replace("internal a", "internal"); }
                        if (!is_riken && btn.Text.Contains("internal") && !btn.Text.Contains("internal a") && !btn.Text.Contains("internal b")) { btn.Text = btn.Text.Replace("internal", "internal a"); }
                        if (!is_riken && btn.Visible && btn.Text.Contains("B()")) { btn.Text = btn.Text.Replace("B()", "NH3"); }
                    }
                }
                if (is_riken)
                {
                    frag = new string[] { "a", "b", "c", "d", "w", "x", "y", "z", "internal","B","M" };
                    loadMS_Btn.Text = "Load Riken File";
                    //isoplot display checkboxes
                    /*disp_x.ForeColor =*/ ppm_x.ForeColor = ppm_x_H2O.ForeColor = ppm_x_NH3.ForeColor = Color.DodgerBlue;
                   /* disp_y.ForeColor =*/ ppm_y.ForeColor = ppm_y_H2O.ForeColor = ppm_y_NH3.ForeColor = Color.Tomato;
                   /* disp_z.ForeColor =*/ ppm_z.ForeColor = ppm_z_H2O.ForeColor = ppm_z_NH3.ForeColor = Color.HotPink;
                    //charge diagramms
                    down1_Btn.Text = "w"; down2_Btn.Text = "x"; down3_Btn.Text = "y";
                    ax_chBx.Text = "a - w"; by_chBx.Text = "b - x"; cz_chBx.Text = "c - y"; intA_chBx.Text = "d - z"; intB_chBx.Text = "internal";
                    ax_chBxCopy1.Text = "a - w"; by_chBxCopy1.Text = "b - x"; cz_chBxCopy1.Text = "c - y"; intA_chBxCopy1.Text = "d - z"; intB_chBxCopy1.Text = "internal";
                    ax_chBxCopy2.Text = "a - w"; by_chBxCopy2.Text = "b - x"; cz_chBxCopy2.Text = "c - y"; intA_chBxCopy2.Text = "d - z"; intB_chBxCopy2.Text = "internal";
                    losses_groupBox_w.Visible = losses_groupBox_x.Visible = losses_groupBox_y.Visible = losses_groupBox_z.Visible = false;
                    losses_groupBox_w.Visible = losses_groupBox_x.Visible = losses_groupBox_y.Visible = losses_groupBox_z.Visible = true;
                }
                else
                {
                    frag = new string[] { "a", "b", "c", "x", "y", "z", "d", "v", "w", "internal a", "internal b", "M" };
                    loadMS_Btn.Text = "Load PP MS File";
                    //isoplot display checkboxes
                    /*disp_x.ForeColor =*/ ppm_x.ForeColor = ppm_x_H2O.ForeColor = ppm_x_NH3.ForeColor = Color.LimeGreen;
                   /* disp_y.ForeColor =*/ ppm_y.ForeColor = ppm_y_H2O.ForeColor = ppm_y_NH3.ForeColor = Color.DodgerBlue;
                    /*disp_z.ForeColor =*/ ppm_z.ForeColor = ppm_z_H2O.ForeColor = ppm_z_NH3.ForeColor = Color.Tomato;
                    //charge diagramms
                    down1_Btn.Text = "x"; down2_Btn.Text = "y"; down3_Btn.Text = "z";
                    ax_chBx.Text = "a - x"; by_chBx.Text = "b - y"; cz_chBx.Text = "c - z"; intA_chBx.Text = "internal a"; intB_chBx.Text = "internal b";
                    ax_chBxCopy1.Text = "a - x"; by_chBxCopy1.Text = "b - y"; cz_chBxCopy1.Text = "c - z"; intA_chBxCopy1.Text = "internal a"; intB_chBxCopy1.Text = "internal b";
                    ax_chBxCopy2.Text = "a - x"; by_chBxCopy2.Text = "b - y"; cz_chBxCopy2.Text = "c - z"; intA_chBxCopy2.Text = "internal a"; intB_chBxCopy2.Text = "internal b";
                }
                label_frag = frag.ToArray();
                view_frag = frag.ToArray();
                ppm_d2.Visible = !is_riken; ppm_w2.Visible = !is_riken; ppm_v.Visible = !is_riken;
            }
        }
        #endregion

        #region TAB FIT     

        #region 0. Preferences and params      
        /// <summary>Load user settings from a preferences.txt file. If the application is used for the first time the file is created with default settings. </summary>
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
                    fit_thres[0] = Convert.ToDouble(preferences[24].Split(':')[1]);
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
                    Xmajor_grid = string_to_bool(preferences[35].Split(':')[1]);
                    Xminor_grid = string_to_bool(preferences[36].Split(':')[1]);
                    Ymajor_grid = string_to_bool(preferences[37].Split(':')[1]);
                    Yminor_grid = string_to_bool(preferences[38].Split(':')[1]);                   
                    x_interval = Convert.ToDouble(preferences[39].Split(':')[1]);
                    y_interval = Convert.ToDouble(preferences[40].Split(':')[1]);
                    x_format = preferences[41].Split(':')[1].ToString();
                    y_format = preferences[42].Split(':')[1].ToString();
                    x_numformat = preferences[43].Split(':')[1].ToString();
                    y_numformat = preferences[44].Split(':')[1].ToString();

                    //primary tab plots
                    //intensity
                    if (string_to_bool(preferences[45].Split(':')[1])) { Xmajor_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Xmajor_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[46].Split(':')[1])) { Xminor_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Xminor_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[47].Split(':')[1])) { Ymajor_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Ymajor_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[48].Split(':')[1])) { Yminor_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Yminor_grid12 = OxyPlot.LineStyle.None; }
                    y_interval12 = Convert.ToDouble(preferences[49].Split(':')[1]);                   
                    y_format12 = preferences[50].Split(':')[1].ToString();
                    y_numformat12 = preferences[51].Split(':')[1].ToString();
                    x_majorStep12 = Convert.ToDouble(preferences[52].Split(':')[1]);
                    x_minorStep12 = Convert.ToDouble(preferences[53].Split(':')[1]);
                    bar_width = Convert.ToDouble(preferences[54].Split(':')[1]);

                    //charge
                    if (string_to_bool(preferences[55].Split(':')[1])) { Xmajor_charge_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Xmajor_charge_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[56].Split(':')[1])) { Xminor_charge_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Xminor_charge_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[57].Split(':')[1])) { Ymajor_charge_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Ymajor_charge_grid12 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[58].Split(':')[1])) { Yminor_charge_grid12 = OxyPlot.LineStyle.Solid; }
                    else { Yminor_charge_grid12 = OxyPlot.LineStyle.None; }                    
                    y_charge_majorStep12 = Convert.ToDouble(preferences[59].Split(':')[1]);
                    y_charge_minorStep12 = Convert.ToDouble(preferences[60].Split(':')[1]);
                    x_charge_majorStep12 = Convert.ToDouble(preferences[61].Split(':')[1]);
                    x_charge_minorStep12 = Convert.ToDouble(preferences[62].Split(':')[1]);

                    //internal tab plots
                    if (string_to_bool(preferences[63].Split(':')[1])) { Xint_major_grid13 = OxyPlot.LineStyle.Solid; }
                    else { Xint_major_grid13 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[64].Split(':')[1])) { Xint_minor_grid13 = OxyPlot.LineStyle.Solid; }
                    else { Xint_minor_grid13 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[65].Split(':')[1])) { Yint_major_grid13 = OxyPlot.LineStyle.Solid; }
                    else { Yint_major_grid13 = OxyPlot.LineStyle.None; }
                    if (string_to_bool(preferences[66].Split(':')[1])) { Yint_minor_grid13 = OxyPlot.LineStyle.Solid; }
                    else { Yint_minor_grid13 = OxyPlot.LineStyle.None; }
                    x_format13 = preferences[67].Split(':')[1].ToString();
                    x_numformat13 = preferences[68].Split(':')[1].ToString();
                    x_interval13 = Convert.ToDouble(preferences[69].Split(':')[1]);                  
                    xINT_majorStep13 = Convert.ToDouble(preferences[70].Split(':')[1]);
                    xINT_minorStep13 = Convert.ToDouble(preferences[71].Split(':')[1]);
                    yINT_majorStep13 = Convert.ToDouble(preferences[72].Split(':')[1]);
                    yINT_minorStep13 = Convert.ToDouble(preferences[73].Split(':')[1]);
                    int_width = Convert.ToDouble(preferences[74].Split(':')[1]);

                    fit_thres[5] = Convert.ToDouble(preferences[75].Split(':')[1]);
                    fit_thres[6] = Convert.ToDouble(preferences[76].Split(':')[1]);
                    //ppm regions
                    for (int a = 0; a < 6; a++)
                    {
                        string[] temp = preferences[77 + a].Split(':')[1].Split('\t');
                        ppm_regions.Add(new ppm_area { Chk = string_to_bool(temp[0]), Max = Convert.ToDouble(temp[2]), Min = Convert.ToDouble(temp[1]), Max_ppm = Convert.ToDouble(temp[3]), Rule = Convert.ToInt32(temp[4]) });
                    }
                    entire_spectrum = string_to_bool(preferences[83].Split(':')[1]);

                    threshold = Convert.ToDouble(preferences[84].Split(':')[1]);

                    annotation_size = Convert.ToDouble(preferences[85].Split(':')[1]);
                    is_deconv_const_resolution = string_to_bool(preferences[86].Split(':')[1]);
                    deconv_machine = preferences[87].Split(':')[1].ToString();
                    //ppm plot extra parameters
                    y_ppm_majorStep = Convert.ToDouble(preferences[88].Split(':')[1]);
                    y_ppm_minorStep = Convert.ToDouble(preferences[89].Split(':')[1]);
                    x_ppm_majorStep = Convert.ToDouble(preferences[90].Split(':')[1]);
                    x_ppm_minorStep = Convert.ToDouble(preferences[91].Split(':')[1]);
                    ppm_bullet_size = Convert.ToDouble(preferences[92].Split(':')[1]);
                    ppm_graph_type = Int32.Parse(preferences[93].Split(':')[1]);
                    //new parameters extracted are within a try{} and as a result if the user loads an old preferences.txt without these parameters, only the new parameters are set to default
                    try
                    {
                        //hydrogens rearrangement extra parameters
                        y_interval12_2 = Convert.ToDouble(preferences[94].Split(':')[1]);
                        y_format12_2 = preferences[95].Split(':')[1].ToString();
                        y_numformat12_2 = preferences[96].Split(':')[1].ToString();
                        x_majorStep12_2 = Convert.ToDouble(preferences[97].Split(':')[1]);
                        x_minorStep12_2 = Convert.ToDouble(preferences[98].Split(':')[1]);
                        line_width_2 = Convert.ToDouble(preferences[99].Split(':')[1]);
                        x_ppm_interval = Convert.ToDouble(preferences[100].Split(':')[1]);

                        try
                        {
                            if (UInt32.TryParse(preferences[101].Split(':')[1], out uint result_color)) color_primary = OxyColor.FromUInt32(result_color);
                            if (UInt32.TryParse(preferences[102].Split(':')[1], out uint result_color1)) color_internal = OxyColor.FromUInt32(result_color1);
                        }
                        catch
                        {
                            color_primary = OxyColors.Lavender; color_internal = OxyColors.Lavender;
                            save_preferences();
                        }

                    }
                    catch
                    {
                        y_interval12_2 = 50; y_format12_2 = "0.0E+"; y_numformat12_2 = "0"; x_majorStep12_2 = 5; x_minorStep12_2 = 1; line_width_2 = 2; x_ppm_interval = 20;
                        save_preferences();
                    }
                }
                catch
                {
                    MessageBox.Show("Oops the preferences' file is corrupted! But, don't worry you can start your processing with the default preferences. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    init_preferences();
                    save_preferences();
                }
            }
            else
            {
                init_preferences();
                save_preferences();
            }
        }
        /// <summary>Set user settings to the default settings. </summary>
        public void init_preferences()
        {
            ppmError = 8.0; min_intes = 50.0; frag_mzGroups = 40; fit_bunch = 6; fit_cover = 0; selection_rule = new bool[] { true, false, false, false, false, false };
            fit_sort = new bool[] { false, true, false, false, false, false }; a_coef = new double[] { 0.0, 1.0, 0.0, 0.0, 0.0, 0.0 }; visible_results = 100; fit_thres = new double[] { 100.0, 100.0, 100.0, 100.0, 100.0, 100.0, 100.0 }; ppmDi = 8.0;
            fit_color = OxyColors.Black; exp_color = OxyColors.Black.ToColor().ToArgb(); peak_color = OxyColors.Crimson; fit_style = LinePattern.Dot; exper_style = LinePattern.Solid; frag_style = LinePattern.Solid; exp_width = 1; frag_width = 2; fit_width = 1;
            peak_width = 1; cen_width = 1; Xmajor_grid = false; Xminor_grid = false; Ymajor_grid = false; Yminor_grid = false; X_tick = OxyPlot.Axes.TickStyle.Outside; Y_tick = OxyPlot.Axes.TickStyle.Outside; x_interval = 50;
            y_interval = 50; x_format = "G"; y_format = "0.0E+"; x_numformat = "0"; y_numformat = "0"; Xmajor_grid12 = OxyPlot.LineStyle.Solid; Xminor_grid12 = OxyPlot.LineStyle.None; Ymajor_grid12 = OxyPlot.LineStyle.Solid; Yminor_grid12 = OxyPlot.LineStyle.None; y_interval12 = 50;
            X_tick12 = OxyPlot.Axes.TickStyle.Outside; Y_tick12 = OxyPlot.Axes.TickStyle.Outside; y_format12 = "0.0E+"; y_numformat12 = "0"; x_majorStep12 = 5; x_minorStep12 = 1; bar_width = 1; Xmajor_charge_grid12 = OxyPlot.LineStyle.Solid; Xminor_charge_grid12 = OxyPlot.LineStyle.None;
            Ymajor_charge_grid12 = OxyPlot.LineStyle.Solid; Yminor_charge_grid12 = OxyPlot.LineStyle.None; X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside; Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside; y_charge_majorStep12 = 2; y_charge_minorStep12 = 1; x_charge_majorStep12 = 5;
            x_charge_minorStep12 = 1; Xint_major_grid13 = OxyPlot.LineStyle.Solid; Xint_minor_grid13 = OxyPlot.LineStyle.None; Yint_major_grid13 = OxyPlot.LineStyle.Solid; Yint_minor_grid13 = OxyPlot.LineStyle.None; x_format13 = "0.0E+"; x_numformat13 = "0"; x_interval13 = 50; Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
            Yint_tick13 = OxyPlot.Axes.TickStyle.Outside; xINT_majorStep13 = 5; xINT_minorStep13 = 1; yINT_majorStep13 = 5; yINT_minorStep13 = 1; int_width = 1;
            for (int a = 0; a < 6; a++)
            {
                ppm_regions.Add(new ppm_area { Chk = false, Max = 0.0, Min = 0.0, Max_ppm = 8.0, Rule = 0 });
            }
            entire_spectrum = true; threshold = 0.01; annotation_size = 9.0; deconv_machine = ""; is_deconv_const_resolution = false;
            y_ppm_majorStep = 2; y_ppm_minorStep = 1; x_ppm_majorStep = 5; x_ppm_minorStep = 1; ppm_bullet_size = 1.0; ppm_graph_type = 1; x_ppm_interval = 20;
            y_interval12_2 = 50; y_format12_2 = "0.0E+"; y_numformat12_2 = "0"; x_majorStep12_2 = 5; x_minorStep12_2 = 1; line_width_2 = 2;
            color_primary = OxyColors.Lavender;color_internal = OxyColors.Lavender;
        }
        /// <summary>Save user settings to a preferences.txt file. </summary>
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

            preferences[0] += "fit results sorting by Mi: " + fit_sort[0].ToString() + "\r\n";
            preferences[0] += "fit results sorting by M: " + fit_sort[1].ToString() + "\r\n";
            preferences[0] += "fit results sorting by di: " + fit_sort[2].ToString() + "\r\n";
            preferences[0] += "fit results sorting by sse: " + fit_sort[3].ToString() + "\r\n";
            preferences[0] += "fit results sorting by ei: " + fit_sort[4].ToString() + "\r\n";
            preferences[0] += "fit results sorting by di': " + fit_sort[5].ToString() + "\r\n";

            preferences[0] += "Mi coefficient: " + a_coef[0].ToString() + "\r\n";
            preferences[0] += "M coefficient: " + a_coef[1].ToString() + "\r\n";
            preferences[0] += "di coefficient: " + a_coef[2].ToString() + "\r\n";
            preferences[0] += "sse coefficient: " + a_coef[3].ToString() + "\r\n";
            preferences[0] += "ei coefficient: " + a_coef[4].ToString() + "\r\n";
            preferences[0] += "di' coefficient: " + a_coef[5].ToString() + "\r\n";

            preferences[0] += "Amount of best solutions presented: " + visible_results.ToString() + "\r\n";
            preferences[0] += "Mi score threshold: " + fit_thres[0].ToString() + "\r\n";
            preferences[0] += "M score threshold: " + fit_thres[1].ToString() + "\r\n";
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
            preferences[0] += "Xmajor_grid: " + Xmajor_grid.ToString() + "\r\n";
            preferences[0] += "Xminor_grid: " + Xminor_grid.ToString() + "\r\n";
            preferences[0] += "Ymajor_grid: " + Ymajor_grid.ToString() + "\r\n";
            preferences[0] += "Yminor_grid: " + Yminor_grid.ToString() + "\r\n";
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
            if (Xmajor_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xmajor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xmajor_grid12: " + false + "\r\n"; }
            if (Xminor_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xminor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xminor_grid12: " + false + "\r\n"; }
            if (Ymajor_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Ymajor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Ymajor_grid12: " + false + "\r\n"; }
            if (Yminor_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Yminor_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yminor_grid12: " + false + "\r\n"; }
            preferences[0] += "y interval in primary intensity plot: " + y_interval12.ToString() + "\r\n";
            //preferences[0] += X_tick12 = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "y number1 format in primary intensity plot: " + y_format12.ToString() + "\r\n";
            preferences[0] += "y number2 format in primary intensity plot: " + y_numformat12.ToString() + "\r\n";
            preferences[0] += "x major step in primary intensity plot: " + x_majorStep12.ToString() + "\r\n";
            preferences[0] += "x minor step in primary intensity plot: " + x_minorStep12.ToString() + "\r\n";
            preferences[0] += "bar width in primary intensity plot: " + bar_width.ToString() + "\r\n";
            //charge
            if (Xmajor_charge_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xmajor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xmajor_charge_grid12: " + false + "\r\n"; }
            if (Xminor_charge_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xminor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xminor_charge_grid12: " + false + "\r\n"; }
            if (Ymajor_charge_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Ymajor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Ymajor_charge_grid12: " + false + "\r\n"; }
            if (Yminor_charge_grid12 == OxyPlot.LineStyle.Solid) { preferences[0] += "Yminor_charge_grid12: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yminor_charge_grid12: " + false + "\r\n"; }
            //preferences[0] += X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
            //preferences[0] += Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
            preferences[0] += "y major step in primary charge plot: " + y_charge_majorStep12.ToString() + "\r\n";
            preferences[0] += "y minor step in primary charge plot: " + y_charge_minorStep12.ToString() + "\r\n";
            preferences[0] += "x major step in primary charge plot: " + x_charge_majorStep12.ToString() + "\r\n";
            preferences[0] += "x minor step in primary charge plot: " + x_charge_minorStep12.ToString() + "\r\n";

            //internal tab plots
            if (Xint_major_grid13 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xint_major_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xint_major_grid13: " + false + "\r\n"; }
            if (Xint_minor_grid13 == OxyPlot.LineStyle.Solid) { preferences[0] += "Xint_minor_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Xint_minor_grid13: " + false + "\r\n"; }
            if (Yint_major_grid13 == OxyPlot.LineStyle.Solid) { preferences[0] += "Yint_major_grid13: " + true.ToString() + "\r\n"; }
            else { preferences[0] += "Yint_major_grid13: " + false + "\r\n"; }
            if (Yint_minor_grid13 == OxyPlot.LineStyle.Solid) { preferences[0] += "Yint_minor_grid13: " + true.ToString() + "\r\n"; }
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

            //sd sdnew thresholds
            preferences[0] += "sd score threshold: " + fit_thres[5].ToString() + "\r\n";
            preferences[0] += "sd' score threshold: " + fit_thres[6].ToString() + "\r\n";
            //ppm regions
            for (int a = 0; a < 6; a++)
            {
                preferences[0] += "region " + (a + 1).ToString() + "(checked,min,max,ppm,rule): " + ppm_regions[a].Chk.ToString() + "\t" + ppm_regions[a].Min.ToString() + "\t" + ppm_regions[a].Max.ToString() + "\t" + ppm_regions[a].Max_ppm.ToString() + "\t" + ppm_regions[a].Rule.ToString() + "\r\n";
            }
            preferences[0] += "entire spectum: " + entire_spectrum.ToString() + "\r\n";
            preferences[0] += "threshold: " + threshold.ToString() + "\r\n";
            //annotations size
            preferences[0] += "Annotations size: " + annotation_size.ToString() + "\r\n";
            //deconvoluted spectra
            preferences[0] += "is resolution const: " + is_deconv_const_resolution.ToString() + "\r\n";
            preferences[0] += "deconvoluted resolution: " + deconv_machine.ToString() + "\r\n";

            //ppm plot extra parameters
            preferences[0] += "y_ppm_majorStep: " + y_ppm_majorStep.ToString() + "\r\n";
            preferences[0] += "y_ppm_minorStep: " + y_ppm_minorStep.ToString() + "\r\n";
            preferences[0] += "x_ppm_majorStep: " + x_ppm_majorStep.ToString() + "\r\n";
            preferences[0] += "x_ppm_minorStep: " + x_ppm_minorStep.ToString() + "\r\n";
            preferences[0] += "ppm_bullet_size: " + ppm_bullet_size.ToString() + "\r\n";
            preferences[0] += "ppm_graph_type: " + ppm_graph_type.ToString() + "\r\n";

            //hydrogens rearrangement extra parameters
            preferences[0] += "y_interval12_2: " + y_interval12_2.ToString() + "\r\n";
            preferences[0] += "y_format12_2: " + y_format12_2.ToString() + "\r\n";
            preferences[0] += "y_numformat12_2: " + y_numformat12_2.ToString() + "\r\n";
            preferences[0] += "x_majorStep12_2: " + x_majorStep12_2.ToString() + "\r\n";
            preferences[0] += "x_minorStep12_2: " + x_minorStep12_2.ToString() + "\r\n";
            preferences[0] += "line_width_2: " + line_width_2.ToString() + "\r\n";

            //ppm plot extra parameters
            preferences[0] += "x_ppm_interval: " + x_ppm_interval.ToString() + "\r\n";

            //SS regions colours
            preferences[0] += "color_primary: " + color_primary.ToUint().ToString() + "\r\n";
            preferences[0] += "color_internal: " + color_internal.ToUint().ToString() + "\r\n";

            // save to default file
            File.WriteAllLines(root_path + "\\preferences.txt", preferences);
        }

        #endregion

        #region 1.a Import data
        private void loadExp_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Loads experimental file in .txt file format.\r\nEach line in the file consists of two tab delimited values: m/z and intensity.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            loadExp_Btn.Enabled = false;
            try
            {
                load_experimental_sequence();
            }
            catch
            {
                MessageBox.Show("Are you sure you entered the correct file format?" +
                    "Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading experimental data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            sw1.Stop(); Debug.WriteLine("post_load_actions: " + sw1.ElapsedMilliseconds.ToString());
            Thread peak_detection = new Thread(peakDetect_and_resolutionRef);
            peak_detection.Start();
            try
            {
                post_load_actions();
            }
            catch (Exception l)
            {
                MessageBox.Show(l.ToString(), "Error in loading experimental data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          
        }
        /// <summary> Read experimental file information  </summary>
        private bool load_experimental()
        {
            if (!is_loading && !is_calc)
            {
                OpenFileDialog expData = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Title = "Load experimental data", FileName = "", Filter = "data file|*.dec;*.txt;|All files|*.*" };
                List<string> lista = new List<string>();
                if (expData.ShowDialog() != DialogResult.Cancel)
                {
                    sw1.Reset(); sw1.Start();
                    StreamReader objReader = new StreamReader(expData.FileName);
                    project_experimental = expData.FileName;
                    file_name = expData.SafeFileName.Remove(expData.SafeFileName.Length - 4);
                    string extension = System.IO.Path.GetExtension(expData.FileName);
                    if (extension.Equals(".dec")) { is_exp_deconvoluted = true; }
                    else { is_exp_deconvoluted = false; }
                    do { lista.Add(objReader.ReadLine()); }
                    while (objReader.Peek() != -1);
                    objReader.Close();
                    experimental.Clear();
                    experimental_dec.Clear();
                    //add toolstrip progress bar
                    progress_display_start(lista.Count, "Loading experimental data...");
                    max_exp = 0.0;
                    double mz_prev = 0;
                    //sometimes the experimental is shifted in the Y axis and the minimum intensity is not 0,
                    //in this case we shift it back to 0 on order to have the calculations executed correctly
                    double Y_shift = 0;
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] tmp_str = lista[j].Split('\t');
                            if(tmp_str.Length<2)tmp_str = lista[j].Split(',');
                            double mz = dParser(tmp_str[0]);
                            double y = dParser(tmp_str[1]);
                            if (tmp_str.Length == 2)
                            {
                                if (!Double.IsNaN(mz)&& !Double.IsNaN(y))
                                {
                                    //we don't use Yshift in a deconvoluted spectra input as the measurements are peaks not profiles
                                    if (j == 0 && !is_exp_deconvoluted)
                                    {
                                        Y_shift = y;
                                    }
                                    experimental.Add(new double[] { mz, y- Y_shift });
                                    if (is_exp_deconvoluted)
                                    {                                        
                                        if (experimental_dec.Count == 0) { experimental_dec.Add(new List<double[]>()); }
                                        else if (mz - mz_prev > 2) { experimental_dec.Add(new List<double[]>()); }
                                        if (mz_prev != mz) experimental_dec.Last().Add(new double[] { mz, y });
                                        mz_prev = mz;
                                    }                                   
                                }                                
                            }
                            else
                            {
                                MessageBox.Show("Oops... it seems you have inserted wrong file format.\r\nPlease try again.", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                file_name = ""; experimental.Clear(); experimental_dec.Clear();
                                sw1.Stop(); Debug.WriteLine("load_experimental: failed due to wrong file format");
                                progress_display_stop();
                                return false;
                            }
                            if (max_exp < y) max_exp = y;
                        }
                        catch { MessageBox.Show("Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
                        if (j % 10000 == 0 && j > 0) progress_display_update(j);
                    }
                    sw1.Stop(); Debug.WriteLine("load_experimental: " + sw1.ElapsedMilliseconds.ToString());
                    progress_display_stop();
                    filename_txtBx.Text = file_name;
                    return true;
                }
                else return false;
            }
            else { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return false; }
        }
        /// <summary> Actions taken post experimental data loading or recalculation  </summary>
        public void post_load_actions()
        {
            insert_exp = true;
            recalc = true;

            // post load actions
            enable_UIcontrols("post load");
                        
            filename_txtBx.Text = file_name;//Notify the user for the name of the loaded file

            // set experimental line color to black
            if (custom_colors.Count > 0) custom_colors[0] = exp_color;
            else custom_colors.Add(exp_color);

            statusStrp.Invoke(new Action(() => statusStrp.Visible = true));
            statusStrp.Invoke(new Action(() => progressLabel.Text = "Experimental Data Processing..."));
            _bw_deconcoluted_exp_resolution.RunWorkerAsync();

        }
        /// <summary> Case of a deconvoluted experimental file: Initiated when the Backgroundworker completed the Experimental profile calculation  </summary>
        void _bw_find_exp_resolution_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progress_display_stop();
            // copy experimental to all_data
            experimental_to_all_data();
            recalculate_all_data_aligned();
            // add experimental to plot
            MessageBox.Show("Processing is completed.", "Load experimental data", MessageBoxButtons.OK);
            LC_1.ViewXY.ZoomToFit();
        }
        /// <summary>Peak Detection in case of a mass spectrum or Profile calculation in of a deconvoluted mass spectrum </summary>
        private void peakDetect_and_resolutionRef()
        {
            // run peak detection and add new resolution map from experimental
            if (experimental.Count() > 0 && !is_exp_deconvoluted)
            {
                peak_detect();
                if (peak_points.Count() > 0)
                {
                    //displayPeakList_btn.Invoke(new Action(() => displayPeakList_btn.Enabled = true));   //thread safe call
                    //plotCentr_chkBox.Invoke(new Action(() => plotCentr_chkBox.Enabled = true));   //thread safe call
                    exp_res++;
                    //plot_peak(); 
                    List<double> tmp1 = new List<double>();
                    List<double> tmp2 = new List<double>();
                    foreach (double[] peak in peak_points)
                    {
                        if (peak[5] > 1000)
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
                LC_1.BeginUpdate();
                LC_1.ViewXY.ZoomToFit();
                LC_1.EndUpdate();
            }
            else if (is_exp_deconvoluted && experimental_dec.Count > 0)
            {
                peak_points.Clear();
                for (int exp = 0; exp < experimental_dec.Count; exp++)
                {
                    for (int g = 0; g < experimental_dec[exp].Count; g++)
                    {
                        peak_points.Add(new double[] { exp, experimental_dec[exp][g][0], experimental_dec[exp][g][1], 10000, 0, experimental_dec[exp][g][1] });
                    }
                }               
                LC_1.BeginUpdate();
                LC_1.ViewXY.ZoomToFit();
                LC_1.EndUpdate();
            }
        }
        /// <summary> Case of a deconvoluted experimental file:Create the experimental profile that corresponds to the experimental peaks of the inserted deconvoluted spectra </summary>
        void find_resolution(object sender, DoWorkEventArgs e)
        {
            if (!is_exp_deconvoluted) return;
            double resolution = 0.0;
            double previous_res = 0.0;
            double max_res = 0.0;
            List<double[]> experimental_f = new List<double[]>();
            List<double[]> experimental_f2 = new List<double[]>();
            List<List<double[]>> exp_groups = new List<List<double[]>>();
            List<double> exp_x = new List<double>();
            string machine = deconv_machine;
            if (is_deconv_const_resolution)
            {
                resolution = dParser(machine);
                for (int g = 0; g < peak_points.Count; g++)
                {
                    peak_points[g][3] = resolution;
                }
                Parallel.For(0, experimental_dec.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                {
                    List<double[]> temp_list = Envelope_Experimental(experimental_dec[i], resolution);
                    lock (_locker){experimental_f.AddRange(temp_list);}
                });
                experimental = experimental_f.OrderBy(d => d[0]).ToList();
            }
            else
            {
                machine = deconv_machine;
                if (Resolution_List.L.TryGetValue(machine, out Resolution_List.MachineR data))
                {
                    List<double[]> temp_res = new List<double[]>();
                    int n = 50;
                    double stepSize = (data.m_z[data.m_z.Length - 1] - data.m_z[0]) / (n - 1);
                    double[] x1 = new double[1];
                    double[] x = data.m_z;
                    double[] y = data.R;
                    List<double> xss = new List<double>();
                    xss.Add(x.Last());
                    double[] x_ = Array.ConvertAll(data.m_z, k => (double)k);
                    double[] y_ = Array.ConvertAll(data.R, k => (double)k);
                    double[] w = new double[y_.Count()];
                    for (int u = 0; u < y_.Count(); u++) { w[u] = 1; }
                    int info = new int();
                    alglib.spline1dinterpolant s = new alglib.spline1dinterpolant();
                    alglib.spline1dfitreport rep = new alglib.spline1dfitreport();
                    double rho = 1;
                    alglib.spline1dfitpenalized(x_, y_, 50, rho, out info, out s, out rep);
                    Parallel.For(0, experimental_dec.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                    {
                        List<double[]> initial_entry = new List<double[]>();
                        List<double[]> res = new List<double[]>();
                        List<List<double[]>> temp_exp_groups = new List<List<double[]>>();
                        for (int ii = 0; ii < experimental_dec[i].Count; ii++)
                        {
                            x1 = new double[] { experimental_dec[i][ii][0] };
                            if (data.m_z[data.m_z.Length - 1] <= x1[0])
                            {
                                resolution = data.R[data.m_z.Length - 1];
                            }
                            else if (data.m_z[0] >= x1[0])
                            {
                                resolution = data.R[0];
                            }
                            else
                            {
                                resolution = alglib.spline1dcalc(s, x1[0]);
                            }
                            if (resolution > max_res) max_res = resolution;
                            if (previous_res == resolution) { initial_entry.Add(new double[] { experimental_dec[i][ii][0], experimental_dec[i][ii][1] }); }
                            else if (initial_entry.Count > 0)
                            {
                                temp_exp_groups.Add(Envelope_Experimental(initial_entry, resolution));
                                initial_entry.Clear();
                                previous_res = resolution;
                                initial_entry.Add(new double[] { experimental_dec[i][ii][0], experimental_dec[i][ii][1] });

                            }
                            else
                            {
                                previous_res = resolution;
                                initial_entry.Add(new double[] { experimental_dec[i][ii][0], experimental_dec[i][ii][1] });
                            }
                            res.Add(new double[] { experimental_dec[i][ii][0], resolution });
                        }
                        if (initial_entry.Count > 0)
                        {
                            temp_exp_groups.Add(Envelope_Experimental(initial_entry, resolution));
                        }
                        List<double> temp_exp_x = Range_Final_Exp(temp_exp_groups);

                        List<double[]> temp_list = Envelope_Experimental(experimental_dec[i], resolution);

                        lock (_locker) { exp_groups.AddRange(temp_exp_groups); }
                        lock (_locker) { exp_x.AddRange(temp_exp_x); }
                        lock (_locker) { temp_res.AddRange(res); }
                    });
                    exp_x.Sort(); temp_res.Sort();
                    Parallel.For(0, exp_x.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                    {
                        double one_aligned_point = 0.0;
                        double mz_toInterp = exp_x[i];
                        for (int j = 0; j < exp_groups.Count; j++)
                        {
                            double aligned_value = 0.0;
                            int grp_points = exp_groups[j].Count;
                            for (int k = 0; k < grp_points - 1; k++)
                            {
                                if (k == 0 && mz_toInterp > exp_groups[j][grp_points - 1][0])
                                {
                                    aligned_value = 0.0; break;
                                }
                                if (k == 0 && mz_toInterp < exp_groups[j][k][0])
                                {
                                    aligned_value = 0.0; break;
                                }
                                if (mz_toInterp >= exp_groups[j][k][0] && mz_toInterp <= exp_groups[j][k + 1][0])
                                {
                                    aligned_value = interpolate(exp_groups[j][k][0], exp_groups[j][k][1], exp_groups[j][k + 1][0], exp_groups[j][k + 1][1], mz_toInterp);
                                    break;
                                }
                            }
                            one_aligned_point += aligned_value;
                        }
                        if (i % 2 == 0) lock (_locker) { experimental_f.Add(new double[] { mz_toInterp, one_aligned_point }); }
                        else lock (_locker) { experimental_f2.Add(new double[] { mz_toInterp, one_aligned_point }); }
                    });
                    if (peak_points.Count == temp_res.Count)
                    {
                        for (int g = 0; g < peak_points.Count; g++)
                        {
                            peak_points[g][3] = temp_res[g][1];
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occured in deconvolution, in the resolution region. Some fragments may appear with false resolution.");
                    }
                    experimental_f.AddRange(experimental_f2);
                    // sort by mz the aligned intensities list (global) beause it is mixed by multi-threading
                    experimental = experimental_f.OrderBy(d => d[0]).ToList();
                }
            }

            return;
        }
        /// <summary> Case of a deconvoluted experimental file:Merge all the Experimental profile data in one list and remove the duplicates </summary>
        private List<double> Range_Final_Exp(List<List<double[]>> exp_groups)
        {
            List<double> final = new List<double>();
            foreach (List<double[]> list in exp_groups)
            {
                foreach (double[] num in list) { final.Add(num[0]); }
            }
            final.Sort();
            int k = 0;
            while (k < final.Count - 1)
            {
                if (final[k] == final[k + 1])
                {
                    final.RemoveAt(k + 1);
                }
                else k++;
            }
            return final;
        }
        /// <summary> Case of a deconvoluted experimental file:Creates a list of m/z measurements within an m/z region </summary>
        private IEnumerable<double> Range_Exp(double start, double end, List<double[]> initial, Func<double, double> step)
        {
            if (initial.Count < 2)
            {
                //check parameters
                while (start <= end)
                {
                    yield return start;
                    start = step(start);
                }
            }
            else
            {
                int curr_idx = 0;
                //check parameters
                while (start <= end)
                {
                    yield return start;
                    if (curr_idx < initial.Count && step(start) > initial[curr_idx][0])
                    {
                        start = initial[curr_idx][0];
                        curr_idx++;
                    }
                    else start = step(start);
                }
            }
        }
        /// <summary> Case of a deconvoluted experimental file: Calculate the profile of each group of experimental peaks </summary>
        private List<double[]> Envelope_Experimental(List<double[]> initial, double resolution, double frac = 0.3, int filter = 1)
        {
            //Peak shape function "Gaussian"
            //code as dmz="get" default value. Derive stick discretization from argument resolution. As written in the manual :
            //" the stick discretization is retrieved from (dm/z)*frac, with (dm/z) = (m/z)/R = peak width at half maximum."
            //create stick masses                       
            double extend = 0.5;//default value in code
            int index_prev_m = 0;
            int c = 0;
            List<double[]> final = new List<double[]>();
            //reminder X stands for mass and Y for abundance
            var array = initial.Select(x => x[0]).ToArray();
            //double average = array.Average();
            double dmz2 = initial[0][0] / resolution;
            double a_max = initial[0][1];

            IEnumerable<double> traceit = Range_Exp(initial[0][0] - extend, initial.Last()[0] + extend, initial, x => x + (dmz2 * frac));
            foreach (double tr in traceit)
            {
                double value = 0.0;
                for (int i = index_prev_m; i < initial.Count; i++)
                {
                    double mk = initial[i][0];
                    double ab = initial[i][1];
                    double v = ab * Math.Exp(-1.0 * (Math.Pow(tr - mk, 2.0) * Math.Pow(resolution, 2.0) * Math.Log(256)) / (2.0 * Math.Pow(mk, 2.0)));
                    if (tr < mk)
                    {
                        double threshold = a_max * Math.Exp(-1.0 * (Math.Pow(tr - mk, 2.0) * Math.Pow(resolution, 2.0) * Math.Log(256.0)) / (2.0 * Math.Pow(mk, 2.0)));
                        if (threshold == 0.0){ break; }
                    }
                    if (tr > mk)
                    {
                        double m_prev = initial[index_prev_m][0];
                        double threshold = a_max * Math.Exp(-1.0 * (Math.Pow(tr - m_prev, 2.0) * Math.Pow(resolution, 2.0) * Math.Log(256)) / (2.0 * Math.Pow(m_prev, 2.0)));
                        if (threshold == 0.0)
                        {
                            index_prev_m = i;
                            if (i < initial.Count - 1) a_max = initial[i + 1][1];
                        }
                    }
                    value += v;
                }
                if (c > 0)
                {
                    if (value > 0.0 || (value == 0.0 && final[c - 1][1] > 0.0)){final.Add(new double[] { tr, value });c++;}
                }
                else
                {
                    if (value > 0.0) {  final.Add(new double[] { tr, value }); c++; }
                }
            }
            return final;
        }
        /// <summary> Recalculation of the experimental peaks when the user changes the initial set up</summary>
        public void recalc_peaks()
        {
            Thread peak_detection = new Thread(peakDetect_and_resolutionRef);
            peak_detection.Start();
        }
        #endregion

        #region 1.b Import fragment list
        private void LoadMS_Btn_Click(object sender, EventArgs e)
        {
            if (is_riken) load_RIKEN_product_procedure();
            else load_MS_product_procedure();
        }
        //MS product file load
        private void load_MS_product_procedure()
        {
            if (help_Btn.Checked)
            {
                MessageBox.Show("Load 'MS-Product file', created by the Protein Prospector software.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, "http://msviewer.ucsf.edu/prospector2/cgi-bin/msform.cgi?form=msproduct", "keyword");  return;
            }

            loadMS_Btn.Enabled = false; 
            ms_light_chain = false; ms_heavy_chain = false; ms_extension = ""; ms_sequence = Peptide;
            if (sequenceList == null || sequenceList.Count == 0) { MessageBox.Show("You must first insert Sequence and then load a fragment file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
            DialogResult dialogResult = MessageBox.Show("Last check: are you sure you have introduced the correct AA amino acid sequence?", "Sequence Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                Sequence_Form frm16 = new Sequence_Form(this);
                frm16.ShowDialog();
            }
            if (dialogResult == DialogResult.Cancel)
            {
                loadMS_Btn.Enabled = true; return;
            }
            try
            {
                if (is_exp_deconvoluted)
                {
                    var charge_dialog = this.ShowChargeDialog();
                    if (string.IsNullOrEmpty(charge_dialog.ToString()))
                    {
                        MessageBox.Show("No charge state selected! Therefore, 'Loading fragments' procedure is cancelled.", "Loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return;
                    }
                    else if (charge_dialog.ToString().Equals("Neutral")) { dec_charge = 0; }
                    else { dec_charge = 1; }
                }
                if (sequenceList.Count == 1)
                {
                    ms_sequence = sequenceList[0].Sequence;
                    if (string.IsNullOrEmpty(ms_sequence)) { MessageBox.Show("Oops...the aminoacid sequence corresponding to the selected extension is empty!Please check again your input.", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
                    import_fragments();
                }
                else if (sequenceList.Count == 2)
                {
                    ms_sequence = sequenceList[1].Sequence; ms_extension = "_" + sequenceList[1].Extension;
                    if (sequenceList[1].Type == 1) { ms_heavy_chain = true; ms_light_chain = false; }
                    else { ms_light_chain = true; ms_heavy_chain = false; }
                    if (string.IsNullOrEmpty(ms_sequence)) { MessageBox.Show("Oops...the aminoacid sequence corresponding to the selected extension is empty!Please check again your input.", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
                    import_fragments();
                }
                else
                {
                    var extension_dialog = this.ShowTabModeDialog();
                    if (string.IsNullOrEmpty(extension_dialog.ToString()) && string.IsNullOrEmpty(sequenceList[0].Sequence))
                    {
                        MessageBox.Show("No extension selected!Therefore, Loading fragments procedure is cancelled.", "Loading Fragments"); loadMS_Btn.Enabled = true; return;
                    }
                    else
                    {
                        ms_extension = "_" + extension_dialog.ToString();
                    }                    
                    DialogResult dialogResult1 = MessageBox.Show("The calculation will proceed as for " + ms_extension + " extension AA amino acid sequence.Ready to start?", "Message", MessageBoxButtons.OKCancel);
                    if (dialogResult1 != DialogResult.OK) { loadMS_Btn.Enabled = true; return; }
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (("_" + seq.Extension).Equals(ms_extension))
                        {
                            ms_sequence = seq.Sequence;
                            if (string.IsNullOrEmpty(ms_sequence)) { MessageBox.Show("The aminoacid sequence corresponding to the selected extension is empty!", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
                            if (seq.Type == 1) { ms_heavy_chain = true; ms_light_chain = false; }
                            else { ms_light_chain = true; ms_heavy_chain = false; }
                            import_fragments();
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Oops an error occured! Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loadMS_Btn.Enabled = true; return;
            }
            finally
            {
                loadMS_Btn.Enabled = true;
            }
        }
        public string ShowTabModeDialog()
        {
            Form prompt = new Form() { ShowIcon = false, ShowInTaskbar = false, ControlBox = false, StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog };
            prompt.Width = 275;
            prompt.Height = 180;
            if (is_riken) { prompt.Text = "Riken file type"; }
            else { prompt.Text = "MS file type"; }
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Select extension type", AutoSize = true, BackColor = Color.Transparent };
            ListBox ext_listBox = new ListBox() { Left = 25, Top = 40, Width = 200, Height = 60, ScrollAlwaysVisible = true };
            foreach (SequenceTab ss in sequenceList)
            {
                ext_listBox.Items.Add(ss.Extension.ToString());
            }
            Button confirmation = new Button() { Text = "Done", Left = 175, Width = 50, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(ext_listBox);
            prompt.ShowDialog();
            return ext_listBox.Text;
        }
        private void import_fragments()
        {
             is_ult_fragmentor_file = false;
            string loaded_ms = "";
            if (ms_extension.Equals("_")) { ms_extension = ""; }
            OpenFileDialog fragment_import = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data", Filter = "data file|*.txt;*.csv;|All files|*.*", FilterIndex = 1, RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true };
            List<string> lista = new List<string>();
            x_charged = false;
            if (fragment_import.ShowDialog() != DialogResult.Cancel)
            {
                sw1.Reset(); sw1.Start();
               
                if (fragment_import.FileName.EndsWith(".csv"))
                {
                    is_ult_fragmentor_file = true;
                    read_csv_and_Calculate(fragment_import.FileName,false);                    
                }
                else
                {
                    StreamReader objReader = new StreamReader(fragment_import.FileName);
                    do { lista.Add(objReader.ReadLine()); }
                    while (objReader.Peek() != -1);
                    objReader.Close();
                    lista.RemoveAt(0);
                    if (is_riken) lista.RemoveAt(0);
                    progress_display_start(lista.Count, "Importing fragments list...");
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] tmp_str = lista[j].Split('\t');
                            if (tmp_str.Length < 4) { MessageBox.Show("Oops... it seems you have inserted wrong file format.\r\nPlease try again.", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                            else if (is_riken) assign_riken_fragment(tmp_str);
                            else if (tmp_str.Length == 5) assign_resolve_fragment(tmp_str);
                        }
                        catch (Exception eeeee) { MessageBox.Show(eeeee.ToString() + "\r\n Error in data file in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                        if (j % 1000 == 0 && j > 0) progress_display_update(j);
                    }
                    progress_display_stop();
                }               
                //treeview
                if (string.IsNullOrEmpty(ms_extension)) { loaded_ms = System.IO.Path.GetFileNameWithoutExtension(fragment_import.FileName) + "_"; }
                else { loaded_ms = System.IO.Path.GetFileNameWithoutExtension(fragment_import.FileName) + ms_extension; }
                loaded_MSproducts.Add(loaded_ms);
                string base_node_name = string.Empty;
                if (is_riken) base_node_name = "Loaded Oligonucleotides' fragments files";                
                else base_node_name = "Loaded Peptides' fragments files";
                if (MSproduct_treeView == null || MSproduct_treeView.Nodes.Count == 0) { MSproduct_treeView.Nodes.Add(base_node_name); }
                MSproduct_treeView.Nodes[0].Nodes.Add(loaded_ms);
                MSproduct_treeView.Visible = true;
                post_import_fragments();
                sw1.Stop();
                if (is_riken) Debug.WriteLine("Import frags: " + sw1.ElapsedMilliseconds.ToString());
                else Debug.WriteLine("Import frags and generate X: " + sw1.ElapsedMilliseconds.ToString());
            }
        }
        private void get_precursor_carbons(string last_line)
        {
            string[] tmp_str = last_line.Split('\t');
            if (tmp_str[1] == "MH") precursor_carbons = tmp_str[4].Split(' ').First();
        }
        private void assign_resolve_fragment(string[] frag_info)
        {
            //m/z,ion,index,charge,formula
            int charge = Int32.Parse(frag_info[3]);
            if (is_exp_deconvoluted && charge > 1) { return; }
            bool is_error = false;

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
                Monoisotopic = new CompoundMulti() { Sum = new int[1], Counter = new int[1] },
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
                PrintFormula = frag_info[4],
                Max_man_int = 0,
                Extension = ms_extension,
                Has_adduct = false,
                maxFactor=0.0
            });
            int i = ChemFormulas.Count - 1;
            if (ms_heavy_chain) ChemFormulas[i].Chain_type = 1;
            else if (ms_light_chain) ChemFormulas[i].Chain_type = 2;
            else ChemFormulas[i].Chain_type = 0;

            // Note on formulas
            // InputFormula is the text from MSProduct. It has 1 more H. We remove it, and we store at the same variable ONCE, on loading of the text file.
            // So, we need to add Adduct H. They are exactly the same amount with the charge.
            // PrintFormula is the same and it should be redundant. FinalFormula is all elements together and it is not used outside of enviPat code.
            // Example: a13 +3 Ubiquitin
            // MSProduct -> C67 H117 N16 O16 S1 --- InputFormula (before fix) C67 H117 N16 O16 S1, Adduct 0
            // InputFormula (after fix) C67 H116 N16 O16 S1, Adduct H3 --- FinalFormula C67 H119 N16 O16 S1 Adduct ? (FinalFormula is not used)

            ChemFormulas[i].PrintFormula = ChemFormulas[i].InputFormula = fix_formula(out is_error, ChemFormulas[i].InputFormula);
            if (is_exp_deconvoluted && dec_charge==0)
            {
                //in case of a deconvoluted spectra 
                ChemFormulas[i].Charge = 0;

                // all ions have as many H in Adduct as their charge
                ChemFormulas[i].Adduct = "";
            }
            else
            {
                ChemFormulas[i].Charge = Int32.Parse(frag_info[3]);

                //all ions have as many H in Adduct as their charge
               ChemFormulas[i].Adduct = "H" + ChemFormulas[i].Charge.ToString();
            }

            //check if there are charged x ions
            if (!x_charged && ChemFormulas[i].Ion.Contains("x") && ChemFormulas[i].Charge > 1) { x_charged = true; }

            if (char.IsLower(frag_info[1][0]) && !string.IsNullOrEmpty(frag_info[2]))
            {
                // normal fragment
                ChemFormulas[i].Ion_type = ChemFormulas[i].Ion;
                if (ChemFormulas[i].Ion.StartsWith("d")) ChemFormulas[i].Color = OxyColors.Turquoise;
                if (ChemFormulas[i].Ion.StartsWith("v")) ChemFormulas[i].Color = OxyColors.Turquoise;
                if (ChemFormulas[i].Ion.StartsWith("w")) ChemFormulas[i].Color = OxyColors.Turquoise;
                else if (ChemFormulas[i].Ion.StartsWith("a")) ChemFormulas[i].Color = OxyColors.Green;
                else if (ChemFormulas[i].Ion.StartsWith("b")) ChemFormulas[i].Color = OxyColors.Blue;
                else if (ChemFormulas[i].Ion.StartsWith("c")) ChemFormulas[i].Color = OxyColors.Firebrick;
                else if (ChemFormulas[i].Ion.StartsWith("x")) { ChemFormulas[i].Color = OxyColors.LimeGreen; }
                else if (ChemFormulas[i].Ion.StartsWith("y")) { ChemFormulas[i].Color = OxyColors.DodgerBlue; }
                else if (ChemFormulas[i].Ion.StartsWith("z")) { ChemFormulas[i].Color = OxyColors.Tomato; }
                else ChemFormulas[i].Color = OxyColors.Orange;

                string lbl = "";
                if (ChemFormulas[i].Ion_type.Length == 1) { lbl = ChemFormulas[i].Ion_type + ChemFormulas[i].Index; }
                else { lbl = "(" + ChemFormulas[i].Ion_type + ")" + ChemFormulas[i].Index; }
                
                if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+" + ms_extension;
                else if (ChemFormulas[i].Charge < 0) ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-" + ms_extension;
                else ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + ms_extension;

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
                string lbl = String.Empty;

                if (substring[0].StartsWith("MH") && c_is_precursor(ChemFormulas[i].InputFormula))  // an internal b could be MHQRP for example, so check also carbons
                {
                    ChemFormulas[i].Ion_type = "M" + substring[1];
                    ChemFormulas[i].Ion = ChemFormulas[i].Ion.Replace("MH", "M");;
                    ChemFormulas[i].Color = OxyColors.DarkRed;
                    ChemFormulas[i].Index = 0.ToString();
                    ChemFormulas[i].IndexTo = (ms_sequence.Length - 1).ToString();
                    lbl = ChemFormulas[i].Ion_type;
                }
                else if (substring[1].Contains("-CO"))
                {
                    substring[1] = substring[1].Replace("-CO", "");

                    ChemFormulas[i].Ion_type = "internal a" + substring[1];
                    ChemFormulas[i].Color = OxyColors.DarkViolet;
                    ChemFormulas[i].Index = (ms_sequence.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (ms_sequence.IndexOf(substring[0]) + substring[0].Length).ToString();
                    lbl = "internal_a" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                }
                else
                {
                    ChemFormulas[i].Ion_type = "internal b" + substring[1];
                    ChemFormulas[i].Color = OxyColors.MediumOrchid;
                    ChemFormulas[i].Index = (ms_sequence.IndexOf(substring[0]) + 1).ToString();
                    ChemFormulas[i].IndexTo = (ms_sequence.IndexOf(substring[0]) + substring[0].Length).ToString();
                    lbl = "internal_b" + substring[1] + "[" + ChemFormulas[i].Index + "-" + ChemFormulas[i].IndexTo + "]";
                }                
                if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+" + ms_extension;
                else if (ChemFormulas[i].Charge < 0) ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-" + ms_extension;
                else ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + ms_extension;
            }
            if (ChemFormulas[i].Ion.StartsWith("w") || ChemFormulas[i].Ion.StartsWith("v") || ChemFormulas[i].Ion.StartsWith("x") || ChemFormulas[i].Ion.StartsWith("y") || ChemFormulas[i].Ion.StartsWith("z") || ChemFormulas[i].Ion.StartsWith("(x") || ChemFormulas[i].Ion.StartsWith("(y") || ChemFormulas[i].Ion.StartsWith("(z") || ChemFormulas[i].Ion.StartsWith("(v") || ChemFormulas[i].Ion.StartsWith("(w"))
            {
                ChemFormulas[i].SortIdx = ms_sequence.Length - Int32.Parse(ChemFormulas[i].Index);
            }
            else
            {
                ChemFormulas[i].SortIdx = Int32.Parse(ChemFormulas[i].Index);
            }
        }
        
        private void post_import_fragments()
        {
            // MS-product does not generate charge states for x fragments. We have to calculate and add them and sort by mz
            //If we are using 'Ultimate Fragmentor' we are not calculating extra x fragments
            if (!is_exp_deconvoluted && !is_riken && !is_ult_fragmentor_file) generate_x();
            ChemFormulas = ChemFormulas.OrderBy(o => Double.Parse(o.Mz)).ToList();
            ms_light_chain = false; ms_heavy_chain = false;
            enable_UIcontrols("post import fragments");
        }
        private void generate_x()
        {
            // this adds all x fragments msProduct does not generate (x multiCharged and x with adducts)
            // PROG: Example of deadlock!!! ChemFormulas.Count CANNOT be used in for loop, it is augmented inside the loop and loop will never end if continue to add y_type!!!!!
            int total_fragments_fromFile = ChemFormulas.Count;
            for (int i = 0; i < total_fragments_fromFile; i++)
            {
                if (ChemFormulas[i].Extension.Equals(ms_extension) && ChemFormulas[i].Ion.StartsWith("y"))
                {
                    bool adduct = ChemFormulas[i].Ion.Contains("-");
                    int charge = ChemFormulas[i].Charge;
                    if (adduct || (!adduct && !x_charged && charge > 1))
                    {
                        // x have +CO -2H compared to y. BUT!!!! we have to build the inputFormula as if it was from MSProduct (that has +1H) so we will remove only 1H!!!!
                        //string mz = Math.Round(Convert.ToDouble(ChemFormulas[i].Mz) + (11.99945142 + 15.99436604 - 2 * 1.007276452) / Convert.ToDouble(charge), 4).ToString();
                        string mz = Math.Round(Convert.ToDouble(ChemFormulas[i].Mz) + (12.000000 + 15.994915 - 2 * 1.007825) / Convert.ToDouble(charge), 4).ToString();

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
        //riken file load
        private void assign_riken_fragment(string[] frag_info)
        {
            List<string> other_frag_types = new List<string> { "acp3Y", "dRp" };
            bool is_error = false;
            //m/z	Charge	Chemical Formula	Type
            int charge = Int32.Parse(frag_info[1]);
            if (is_exp_deconvoluted && Math.Abs(charge) > 1) { return; }
            if (is_polarity_negative) charge = charge * (-1);
            ChemFormulas.Add(new ChemiForm
            {
                InputFormula = frag_info[2],
                Adduct = string.Empty,
                Deduct = string.Empty,
                Multiplier = 1,
                Mz = frag_info[0],
                Ion = frag_info[3],
                Index = string.Empty,
                IndexTo = string.Empty,
                Error = false,
                Elements_set = new List<Element_set>(),
                Iso_total_amount = 0,
                Monoisotopic = new CompoundMulti() { Sum = new int[1], Counter = new int[1] },
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
                PrintFormula = frag_info[2],
                Max_man_int = 0,
                Extension = ms_extension,
                Has_adduct = false,
                maxFactor=0.0
            });
            int i = ChemFormulas.Count - 1;
            // Note on formulas
            // InputFormula is the text from Riken.
            ChemFormulas[i].Chain_type = 0;
            // in order to maintain an exclusive way of presenting chemical formulas,the riken chemical formulas are converted to Molecular formulas of charge 0
            ChemFormulas[i].PrintFormula = ChemFormulas[i].InputFormula = fix_formula(out is_error, ChemFormulas[i].InputFormula, true, charge * (-1));
            if (is_error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + " .\r\nThe molecular formula for charge could not be created from the chemical formula : " + ChemFormulas[i].InputFormula + " ,with charge : " + ChemFormulas[i].Charge + " .\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }

            if (charge > 0) { ChemFormulas[i].Adduct = "H" + charge.ToString(); }
            else if (charge < 0) { ChemFormulas[i].Deduct = "H" + (charge * (-1)).ToString(); }

            if (is_exp_deconvoluted && dec_charge==0)
            {
                ChemFormulas[i].Charge = 0; ChemFormulas[i].Adduct = ""; ChemFormulas[i].Deduct = "";
                //ChemFormulas[i].PrintFormula = ChemFormulas[i].InputFormula = fix_formula(ChemFormulas[i].InputFormula, true, charge * (-1));
            }
            else
            {
                ChemFormulas[i].Charge = charge;
            }
            string[] substring = ChemFormulas[i].Ion.Split('-');
            string ion_type = "";
            if (char.IsLower(ChemFormulas[i].Ion[0]))
            {
                // normal fragment
                bool primary_present = false;
                if (ChemFormulas[i].Ion.StartsWith("a") && !ChemFormulas[i].Ion.StartsWith("acp3Y")) { ChemFormulas[i].Color = OxyColors.Green; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("b")) { ChemFormulas[i].Color = OxyColors.Blue; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("c")) { ChemFormulas[i].Color = OxyColors.Firebrick; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("d") && !ChemFormulas[i].Ion.StartsWith("dRp")) { ChemFormulas[i].Color = OxyColors.DeepPink; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("w")) { ChemFormulas[i].Color = OxyColors.LimeGreen; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("x")) { ChemFormulas[i].Color = OxyColors.DodgerBlue; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("y")) { ChemFormulas[i].Color = OxyColors.Tomato; primary_present = true; }
                else if (ChemFormulas[i].Ion.StartsWith("z")) { ChemFormulas[i].Color = OxyColors.HotPink; primary_present = true; }
                else ChemFormulas[i].Color = OxyColors.Orange;
                if (primary_present && (substring.Length == 1 || (substring.Length == 2 && substring[1].StartsWith("B("))/*||(substring.Length > 2 && !char.IsLower(substring[1][0]))*/))
                {
                    ion_type = substring[0][0].ToString();
                    bool is_number = Int32.TryParse(substring[0].Remove(0, 1), out int index);
                    if (is_number)
                    {
                        ChemFormulas[i].Index = index.ToString();
                        if (ChemFormulas[i].Ion.StartsWith("w") || ChemFormulas[i].Ion.StartsWith("x") || ChemFormulas[i].Ion.StartsWith("y") || ChemFormulas[i].Ion.StartsWith("z") || ChemFormulas[i].Ion.StartsWith("(w") || ChemFormulas[i].Ion.StartsWith("(x") || ChemFormulas[i].Ion.StartsWith("(y") || ChemFormulas[i].Ion.StartsWith("(z"))
                        {
                            ChemFormulas[i].SortIdx = ms_sequence.Length - index;
                        }
                        else
                        {
                            ChemFormulas[i].SortIdx = index;
                        }
                        ChemFormulas[i].IndexTo = ChemFormulas[i].Index;
                    }
                    else
                    {
                        MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + " .\r\nDon't worry the remaining calculations will continue normally.");
                        ChemFormulas.RemoveAt(i); return;
                    }

                    for (int c = 1; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                    ChemFormulas[i].Ion_type = ion_type;
                    if (!is_rna)
                    {
                        try
                        {
                            ChemFormulas[i].InputFormula = ChemFormulas[i].PrintFormula = find_index_fix_formula(out is_error, ChemFormulas[i].InputFormula, -index, 'O');
                            if (is_error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + " .\r\nYou are in DNA mode but the Oxygens could not be removed from the chemical formula : " + ChemFormulas[i].InputFormula + " .\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            ChemiForm temp_chem = ChemFormulas[i].DeepCopy();
                            ChemiForm.CheckChem(temp_chem);
                            if (temp_chem.Error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + " , with m/z " + ChemFormulas[i].Mz + " .\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            double emass = 0.00054858;
                            if (charge == 0) { ChemFormulas[i].Mz = Math.Round(temp_chem.Monoisotopic.Mass, 4).ToString(); }
                            else { ChemFormulas[i].Mz = Math.Round((temp_chem.Monoisotopic.Mass - emass * charge) / Math.Abs(charge), 4).ToString(); }
                        }
                        catch { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + " : The amount of Oxygen couldn't be altered.\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                    }
                }
                else if (primary_present)
                {
                    ChemFormulas[i].Color = OxyColors.Violet;
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
                                index_values[c] = (ms_sequence.Length - index_values[c]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ".\r\nDon't worry the remaining calculations will continue normally.");
                            ChemFormulas.RemoveAt(i); return;
                        }
                    }
                    ChemFormulas[i].SortIdx = index_values[0];
                    ChemFormulas[i].Index = index_values[0].ToString();
                    ChemFormulas[i].IndexTo = index_values[1].ToString();
                    for (int c = 2; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                    ChemFormulas[i].Ion_type = ion_type;
                    if (!is_rna)
                    {
                        try
                        {
                            ChemFormulas[i].InputFormula = ChemFormulas[i].PrintFormula = find_index_fix_formula(out is_error, ChemFormulas[i].InputFormula, -index_values[1] + index_values[0], 'O');
                            if (is_error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ".\r\nYou are in DNA mode but the Oxygens could not be removed from the chemical formula : " + ChemFormulas[i].InputFormula + " .\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            ChemiForm temp_chem = ChemFormulas[i].DeepCopy();
                            ChemiForm.CheckChem(temp_chem);
                            if (temp_chem.Error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ".\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            double emass = 0.00054858;
                            if (charge == 0) { ChemFormulas[i].Mz = Math.Round(temp_chem.Monoisotopic.Mass, 4).ToString(); }
                            else { ChemFormulas[i].Mz = Math.Round((temp_chem.Monoisotopic.Mass - emass * charge) / Math.Abs(charge), 4).ToString(); }
                        }
                        catch (Exception eee) { MessageBox.Show(eee.ToString() + " ,Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ": The amount of Oxygen couldn't be altered.\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                    }
                }
                else
                {
                    ion_type = "known MS2";
                    ChemFormulas[i].SortIdx = 0;
                    ChemFormulas[i].Index = "0";
                    ChemFormulas[i].IndexTo = "0";
                    for (int c = 1; c < substring.Length; c++)
                    {
                        if (substring[c].StartsWith("B")) ion_type += "-B()";
                        else ion_type += "-" + substring[c];
                    }
                    ChemFormulas[i].Ion_type = ion_type;
                }
            }
            else if (ChemFormulas[i].Ion.StartsWith("B("))//base fragments are not followed by losses ex B(G) or B(m7G)
            {
                ion_type = "B()";
                ChemFormulas[i].Color = OxyColors.DarkSalmon;
                ChemFormulas[i].SortIdx = 0;
                ChemFormulas[i].Index = "0";
                ChemFormulas[i].IndexTo = "0";
                ChemFormulas[i].Ion_type = ion_type;
            }
            else
            {
                if (substring[0].StartsWith("M") && c_is_precursor(ChemFormulas[i].InputFormula))
                {
                    ion_type = "M";
                    ChemFormulas[i].Color = OxyColors.DarkRed;
                    ChemFormulas[i].SortIdx = 0;
                    ChemFormulas[i].Index = "0";
                    ChemFormulas[i].IndexTo = (ms_sequence.Length - 1).ToString();
                    if (!is_rna)
                    {
                        try
                        {
                            ChemFormulas[i].InputFormula = ChemFormulas[i].PrintFormula = find_index_fix_formula(out is_error, ChemFormulas[i].InputFormula, -ms_sequence.Length, 'O');
                            if (is_error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ".\r\nYou are in DNA mode but the Oxygens could not be removed from the chemical formula : " + ChemFormulas[i].InputFormula + " .\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            ChemiForm temp_chem = ChemFormulas[i].DeepCopy();
                            ChemiForm.CheckChem(temp_chem);
                            if (temp_chem.Error) { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ".\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                            double emass = 0.00054858;
                            if (charge == 0) { ChemFormulas[i].Mz = Math.Round(temp_chem.Monoisotopic.Mass, 4).ToString(); }
                            else { ChemFormulas[i].Mz = Math.Round((temp_chem.Monoisotopic.Mass - emass * charge) / Math.Abs(charge), 4).ToString(); }
                        }
                        catch { MessageBox.Show("Error with fragment " + ChemFormulas[i].Ion + ",with m/z " + ChemFormulas[i].Mz + ": The amount of Oxygen couldn't be altered.\r\nDon't worry the remaining calculations will continue normally."); ChemFormulas.RemoveAt(i); return; }
                    }
                }
                else
                {
                    ion_type = "known MS2";
                    ChemFormulas[i].Color = OxyColors.Orange;
                    ChemFormulas[i].SortIdx = 0;
                    ChemFormulas[i].Index = "0";
                    ChemFormulas[i].IndexTo = "0";

                }
                for (int c = 1; c < substring.Length; c++)
                {
                    if (substring[c].StartsWith("B")) ion_type += "-B()";
                    else ion_type += "-" + substring[c];
                }
                ChemFormulas[i].Ion_type = ion_type;
            }
            string lbl = "";
            lbl = ChemFormulas[i].Ion;            
            if (ChemFormulas[i].Charge > 0) ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + "+" + ms_extension;
            else if (ChemFormulas[i].Charge < 0) ChemFormulas[i].Name = lbl + "_" + Math.Abs(ChemFormulas[i].Charge).ToString() + "-" + ms_extension;
            else ChemFormulas[i].Name = lbl + "_" + ChemFormulas[i].Charge.ToString() + ms_extension;
        }
        private void load_RIKEN_product_procedure()
        {
            if (help_Btn.Checked)
            {
                MessageBox.Show("Load 'Riken file', created by the Ariadne software.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, "https://ariadne.riken.jp/index.html", "keyword"); return;
            }
            loadMS_Btn.Enabled = false;
            ms_light_chain = false; ms_heavy_chain = false;  ms_extension = ""; ms_sequence = Peptide;
            if (sequenceList == null || sequenceList.Count == 0) { MessageBox.Show("You must first insert Sequence and then load a fragment file.", "No sequence found.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
            DialogResult dialogResult = MessageBox.Show("Last check: are you sure you have introduced the correct base sequence?", "Sequence Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                Sequence_Form frm16 = new Sequence_Form(this);
                frm16.ShowDialog();
            }
            if (dialogResult == DialogResult.Cancel)
            {
                loadMS_Btn.Enabled = true; return;
            }
            try
            {
                var polarity_dialog = this.ShowPolarityDialog();
                if (string.IsNullOrEmpty(polarity_dialog.ToString()))
                {
                    MessageBox.Show("No polarity selected! Therefore, 'Loading fragments' procedure is cancelled.", "Loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return;
                }
                else if (polarity_dialog.ToString().Equals("Negative")) is_polarity_negative = true;
                else is_polarity_negative = false;
                if (is_exp_deconvoluted)
                {
                    var charge_dialog = this.ShowChargeDialog();
                    if (string.IsNullOrEmpty(charge_dialog.ToString()))
                    {
                        MessageBox.Show("No charge state selected! Therefore, 'Loading fragments' procedure is cancelled.", "Loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return;
                    }
                    else if (charge_dialog.ToString().Equals("Neutral")) { dec_charge = 0; }
                    else { dec_charge = 1; }
                }               
                if (sequenceList.Count == 1)
                {
                    ms_sequence = sequenceList[0].Sequence;
                    if (string.IsNullOrEmpty(ms_sequence)) { MessageBox.Show("The base sequence corresponding to the selected extension is empty!", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); loadMS_Btn.Enabled = true; return; }
                    import_fragments();
                }
                else
                {
                    var extension_dialog = this.ShowTabModeDialog();
                    if (string.IsNullOrEmpty(extension_dialog.ToString()) && string.IsNullOrEmpty(sequenceList[0].Sequence))
                    {
                        MessageBox.Show("No extension selected!Loading fragments procedure is cancelled.", "Loading Fragments"); loadMS_Btn.Enabled = true; return;
                    }
                    else
                    {
                        ms_extension = "_" + extension_dialog.ToString();
                    }                    
                    DialogResult dialogResult1 = MessageBox.Show("The calculation will proceed as for " + ms_extension + " extension base sequence.", "Message", MessageBoxButtons.OKCancel);
                    if (dialogResult1 != DialogResult.OK) { loadMS_Btn.Enabled = true; return; }
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (("_" + seq.Extension).Equals(ms_extension))
                        {
                            ms_sequence = seq.Sequence;
                            if (string.IsNullOrEmpty(ms_sequence)) { MessageBox.Show("The base sequence corresponding to the selected extension is empty!", "Error in loading Fragments"); loadMS_Btn.Enabled = true; return; }
                            import_fragments();
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Oops an error occured! Please close the program, make sure you load the correct file and restart the procedure.", "Error in loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loadMS_Btn.Enabled = true; return;
            }
            finally
            {
                loadMS_Btn.Enabled = true;
            }
        }
        public string ShowPolarityDialog()
        {
            Form prompt = new Form() { ShowIcon = false, ShowInTaskbar = false, ControlBox = false, StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog };
            prompt.Width = 275;
            prompt.Height = 180;
            prompt.Text = "Polarity";
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Select polarity", AutoSize = true, BackColor = Color.Transparent };
            ListBox ext_listBox = new ListBox() { Left = 25, Top = 40, Width = 200, Height = 60, ScrollAlwaysVisible = true };
            ext_listBox.Items.Add("Positive");
            ext_listBox.Items.Add("Negative");
            Button confirmation = new Button() { Text = "Done", Left = 175, Width = 50, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(ext_listBox);
            prompt.ShowDialog();
            return ext_listBox.Text;
        }
        public string ShowChargeDialog()
        {
            Form prompt = new Form() { ShowIcon = false, ShowInTaskbar = false, ControlBox = false, StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog };
            prompt.Width = 275;
            prompt.Height = 180;
            prompt.Text = "Deconvolution";
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Select fragments' charge state", AutoSize = true, BackColor = Color.Transparent };
            ListBox ext_listBox = new ListBox() { Left = 25, Top = 40, Width = 200, Height = 60, ScrollAlwaysVisible = true };
            ext_listBox.Items.Add("Neutral");
            ext_listBox.Items.Add("Single charged");
            Button confirmation = new Button() { Text = "Done", Left = 175, Width = 50, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(ext_listBox);
            prompt.ShowDialog();
            return ext_listBox.Text;
        }
        #endregion

        #region 2.a Select fragments and calculate their envelopes
        private void ProfCalc_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Opens a Fragment calculator panel.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            string file_type = "an 'MS Product'";
            if(is_riken) file_type = "a 'Riken'";
            if (!help_Btn.Checked && ChemFormulas.Count == 0) { MessageBox.Show("You must first load "+ file_type + " File and then access 'Calculator'.\r\nPlease try again.", "Error in Calculation Box!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            is_help = help_Btn.Checked;
            if (is_riken)
            {
                if (frm24_2 != null)
                {
                    if (!frm24_2.Visible) frm24_2.Show();
                    else frm24_2.BringToFront();
                }
                else
                {
                    frm24_2 = new Form24_2(this);
                    frm24_2.ShowDialog();
                }
            }
            else
            {
                if (frm24 != null)
                {
                    if (!frm24.Visible) frm24.Show();                    
                    else frm24.BringToFront();                   
                }
                else
                {
                    frm24 = new Form24(this);
                    frm24.ShowDialog();
                }
            }
        }
        public void calculate_procedure(List<ChemiForm> selected_fragments)
        {
            if (ChemFormulas.Count == 0) { MessageBox.Show("You must first load an MS Product File and then press 'Calculate'", "Error in calculations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            try
            {
                try
                {
                    clearList();
                    if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0) if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0) { ExtraFragCalculator.last_plotted.Clear(); }
                }
                catch
                {
                    MessageBox.Show("Oops an unexpected error occurred!Please close the program and restart the procedure.", "Error in clear list!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    fragments_and_calculations_sequence_A(selected_fragments);
                }

            }
            catch
            {
                MessageBox.Show("Oops an unexpected error occurred!Please close the program and restart the procedure.", "Error in calculations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }           
        }
        private void fragments_and_calculations_sequence_A(List<ChemiForm> selected_fragments)
        {
            // this the main sequence after loading data
            // 1. select fragments according to UI
            added = 0;
            Fragments2.Clear();
            selectedFragments.Clear();
            custom_colors.Clear();
            custom_colors.Add(exp_color);
            sw1.Reset(); sw1.Start();
            //List<ChemiForm> selected_fragments = select_fragments2();
            if (selected_fragments == null) return;
            sw1.Stop(); Debug.WriteLine("Select frags: " + sw1.ElapsedMilliseconds.ToString());
            sw1.Reset(); sw1.Start();
            // 2. calculate fragments resolution
            //calculate_fragments_resolution(selected_fragments);
            sw1.Stop(); Debug.WriteLine("Resolution from fragments: " + sw1.ElapsedMilliseconds.ToString());
            // 3. calculate fragment properties and keep only those within ppm error from experimental. Store in Fragments2.
            Thread envipat_properties = new Thread(() => calculate_fragment_properties(selected_fragments));
            envipat_properties.Start();
            //plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;
            plotFragProf_chkBox.Checked = true;
        }
        public void fragments_and_calculations_sequence_B()
        {            
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
        
        private void calculate_fragment_properties(List<ChemiForm> selected_fragments)
        {
            // main routine for parallel calculation of fragments properties and filtering by ppm and peak rules
            is_calc = true;
            sw1.Reset(); sw1.Start();
            int progress = 0;
            progress_display_start(selected_fragments.Count, "Calculating fragment isotopic distributions...");
            try
            {
                Parallel.For(0, selected_fragments.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                {
                    Envipat_Calcs_and_filter_byPPM(selected_fragments[i]);
                    // safelly keep track of progress
                    Interlocked.Increment(ref progress);
                    if (progress % 10 == 0 && progress > 0) { progress_display_update(progress); }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Data Format. Check your Fragment File." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            };
            progress_display_stop();
            sw1.Stop(); Debug.WriteLine("Envipat_Calcs_and_filter_byPPM(M): " + sw1.ElapsedMilliseconds.ToString());
            is_calc = false;
            if (selected_fragments.Count > 0 && !selected_fragments[0].Fixed)
            {
                Debug.WriteLine("PPM(): " + sw2.ElapsedMilliseconds.ToString()); sw2.Reset();
                MessageBox.Show("From " + selected_fragments.Count.ToString() + " fragments in total, " + Fragments2.Count.ToString() + " were within ppm filter.", "Fragment selection results");
            }
            else if (selected_fragments.Count > 0 && selected_fragments[0].Fixed)
            {
                MessageBox.Show(added.ToString() + " fragments added from file. " + duplicate_count.ToString() + " duplicates removed from current files.", "Fitted fragments files");

            }
            else if (selected_fragments.Count == 0) { MessageBox.Show("I'm sorry...No fragments match to your research", "Fragment selection results", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            // sort by mz the fragments list (global) beause it is mixed by multi-threading
            Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments2.Count; k++)
            {
                Fragments2[k].Counter = (k + 1);              
            }
            change_name_duplicates();
            // thread safely fire event to continue calculations
            if (selected_fragments.Count > 0) { Invoke(new Action(() => OnEnvelopeCalcCompleted())); }
        }
        private void change_name_duplicates()
        {
            if (Fragments2.Count == 0 || sequenceList == null || sequenceList.Count < 3)
            {
                if (IonDraw.Count > 0) IonDraw.Clear();
                foreach (FragForm fra in Fragments2)
                {
                    if (fra.Fixed)
                    {
                        IonDraw.Add(new ion() { Extension = fra.Extension, SortIdx = fra.SortIdx, Name = fra.Name, Mz = fra.Mz, PPM_Error = fra.PPM_Error, maxPPM_Error = fra.maxPPM_Error, minPPM_Error = fra.minPPM_Error, Charge = fra.Charge, Index = Int32.Parse(fra.Index), IndexTo = Int32.Parse(fra.IndexTo), Ion_type = fra.Ion_type, Max_intensity = fra.Max_intensity * fra.Factor, Color = fra.Color.ToColor(), Chain_type = fra.Chain_type ,Has_adduct=fra.Has_adduct});
                    }
                }
                find_max_min_int();
                return;
            }
            int light_chain_count = 0;//the amount of heavy chain sequences
            int heavy_chain_count = 0;
            foreach (SequenceTab seq in sequenceList)
            {
                if (seq.Type == 1) { heavy_chain_count++; }
                else if (seq.Type == 2) { light_chain_count++; }
            }
            foreach (FragForm fra in Fragments2)
            {
                if (fra.Chain_type == 0) continue;
                string[] extensions = fra.Extension.Split('_');
                int exte_amount = extensions.Length - 1;
                int exte_max = 0;
                string rep = "";
                if (exte_amount == 1) { continue; }
                if (fra.Chain_type == 1) { exte_max = heavy_chain_count; rep = "_H"; }
                else if (fra.Chain_type == 2) { exte_max = light_chain_count; rep = "_L"; }
                else { MessageBox.Show("Error in chain type of fragment " + fra.Name + " with m/z " + fra.Mz, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); continue; }
                if (exte_amount > exte_max) { MessageBox.Show("Error in chain type of fragment " + fra.Name + " with m/z " + fra.Mz, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); continue; }
                else if (exte_amount == exte_max)
                {
                    fra.Name = fra.Name.Replace(fra.Extension, rep);
                }
            }
            if (IonDraw.Count > 0) IonDraw.Clear();
            foreach (FragForm fra in Fragments2)
            {
                if (fra.Fixed)
                {
                    IonDraw.Add(new ion() { Extension = fra.Extension, SortIdx = fra.SortIdx, Name = fra.Name, Mz = fra.Mz, PPM_Error = fra.PPM_Error, maxPPM_Error = fra.maxPPM_Error, minPPM_Error = fra.minPPM_Error, Charge = fra.Charge, Index = Int32.Parse(fra.Index), IndexTo = Int32.Parse(fra.IndexTo), Ion_type = fra.Ion_type, Max_intensity = fra.Max_intensity * fra.Factor, Color = fra.Color.ToColor(), Chain_type = fra.Chain_type,Has_adduct=fra.Has_adduct });
                }
            }
            find_max_min_int();
            return;
        }
        private void Envipat_Calcs_and_filter_byPPM(ChemiForm chem)
        {
            ChemiForm.CheckChem(chem);      // will also generate chem.FinalFormula

            if (chem.Resolution == 0)
            {
                if (String.IsNullOrEmpty(chem.Machine.ToString())) { chem.Error = true; }
                else
                {
                    ChemiForm.Get_R(chem, calc_resolution);

                    if (chem.Resolution == 0) { chem.Error = true; }
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
            ChemiForm.Isopattern(chem, 1000000, algo, 0, threshold);

            ChemiForm.Envelope(chem);
            ChemiForm.Vdetect(chem);
            List<PointPlot> cen = chem.Centroid.OrderByDescending(p => p.Y).ToList();
            chem.Centroid.Clear(); chem.Intensoid.Clear();
            double emass = 0.00054858;
            if (chem.Charge == 0) { chem.Mz = Math.Round(chem.Monoisotopic.Mass, 4).ToString(); }
            else { chem.Mz = Math.Round((chem.Monoisotopic.Mass - emass * chem.Charge) / Math.Abs(chem.Charge), 4).ToString(); }

            // case where there is no experimental data OR fitted list's fragments are inserted with their resolution in order to decrease calculations in half(ptofile is calculated once!!!!)
            if (!insert_exp || (chem.Fixed && !is_recalc_res)) { add_fragment_to_Fragments2(chem, cen); return; }
            // MAIN decision algorithm
            bool fragment_is_canditate = true;
            fragment_is_canditate = decision_algorithm(chem, cen);            
        }
        private bool decision_algorithm(ChemiForm chem, List<PointPlot> cen)
        {
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;
            // decide how many peaks will be involved in the selection process
            // results = {[resol1, ppm1], [resol2, ppm2], ....}
            List<double[]> results = new List<double[]>();
            double temp_pp = ppmError;
            int total_peaks = cen.Count;
            int contrib_peaks = 0;
            int rule_idx = Array.IndexOf(selection_rule, true);
            if (!entire_spectrum)
            {
                double mz = dParser(chem.Mz);
                foreach (ppm_area area in ppm_regions)
                {
                    if (area.Chk)
                    {
                        if (mz > area.Min && mz < area.Max)
                        {
                            temp_pp = area.Max_ppm;
                            rule_idx = area.Rule;
                        }
                    }
                }
            }
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
                if (Math.Abs(tmp[0]) > (temp_pp+1) /*&& is_exp_deconvoluted*/) { fragment_is_canditate = false; break; }
               
            }
            //round 2, with the correct resolution
            if ((fragment_is_canditate || chem.Fixed) /*&& !is_exp_deconvoluted*/)
            {
                fragment_is_canditate = true;
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
                    if (Math.Abs(tmp[0]) > temp_pp) { fragment_is_canditate = false; break; }                                  
                }
            }
            if (!fragment_is_canditate && !chem.Fixed) { chem.Profile.Clear(); chem.Points.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear(); return false; }
            //set PPM error
            chem.PPM_Error = results.Average(p => p[0]);
            if (results.Count > 1) { chem.maxPPM_Error = results.Max(p => p[0]); chem.minPPM_Error = results.Min(p => p[0]); }
            else { chem.maxPPM_Error = 0.0; chem.minPPM_Error = 0.0; }
            add_fragment_to_Fragments2(chem, cen);
            return fragment_is_canditate;
        }
        public static double[] ppm_calculator(double centroid)
        {
            // find the closest experimental peak, and return calculated ppm and resolution
            double exp_cen, ppm;           
            int[] pair = new int[2];
            pair=find_closest(centroid, peak_points, true);
            exp_cen = peak_points[pair[0]][1] + peak_points[pair[0]][4];           
            ppm = (exp_cen - centroid) * 1e6 / (centroid);
            return new double[] { ppm, peak_points[pair[0]][3] };
        }
        private void add_fragment_to_Fragments2(ChemiForm chem, List<PointPlot> cen, bool project = false)
        {
            // adds safely a matched fragment to Fragments2, and releases memory
            lock (_locker)
            {
                if (project || check_duplicates_Fragments2(chem))
                {
                    is_calc = true;
                    FragForm fra = new FragForm()
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
                        Extension = chem.Extension,
                        Chain_type = chem.Chain_type,
                        SortIdx = chem.SortIdx,
                        Candidate = true,
                        Has_adduct = chem.Has_adduct,
                        maxFactor = chem.maxFactor
                    };
                    fra.Centroid = cen.Select(point => point.DeepCopy()).ToList();
                    fra.Profile = chem.Profile.Select(point => point.DeepCopy()).ToList();
                    fra.Counter = Fragments2.Count;
                    fra.Max_intensity = fra.Profile.Max(p => p.Y);
                    //when manually processed data is added sometimes they don't want to fit the data to create the plots in the other tabs,
                    // so factor is calculated based on the input txt the user add that in the last position has the intensity of the fragment
                    if (chem.Max_man_int != 0) { fra.Factor = chem.Max_man_int / fra.Max_intensity; }
                    double pt0 = 0.1 * max_exp;
                    if (peak_points.Count > 0)
                    {
                        double centroid = fra.Centroid[0].X;
                        int[] pair = new int[2];
                        pair = find_closest(centroid, peak_points, true);
                        pt0 = peak_points[pair[0]][5];
                        fra.maxFactor = pt0 / fra.Max_intensity;
                    }                                     
                    if (!fra.Fixed && chem.Max_man_int == 0) fra.Factor = pt0 / fra.Max_intensity;
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments2, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear(); chem.Points.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
                    check_tp(fra);
                    Fragments2.Add(fra);
                }
                else
                {
                    // Prog: Very important memory leak!!! Clear envelope and isopatern of matched fragments to reduce waste of memory DURING calculations! 
                    // Profile is stored already in Fragments2, no reason to keep it also in selected_fragments (which will be Garbage Collected)
                    chem.Profile.Clear(); chem.Points.Clear(); chem.Centroid.Clear(); chem.Intensoid.Clear();
                    duplicate_count++;
                    if (added > 0) added--;
                }
            }
        }
        public bool check_duplicates_Fragments2(ChemiForm chem1)
        {
            if (Fragments2.Count > 0)
            {
                foreach (FragForm fra in Fragments2)
                {
                    if (fra.Mz.Equals(chem1.Mz) && fra.Index.Equals(chem1.Index) && fra.IndexTo.Equals(chem1.IndexTo) && fra.Ion_type.Equals(chem1.Ion_type) && fra.Chain_type.Equals(chem1.Chain_type) && fra.Charge.Equals(chem1.Charge))
                    {
                        if (fra.Extension.Equals(chem1.Extension))
                        {
                            Debug.WriteLine(fra.Name.ToString() + " is considered duplicate with " + chem1.Name.ToString());
                            return false;
                        }
                        int mode = recognise_extension_frag(fra.Extension, chem1.Extension);
                        if (mode == 1 || mode == 2)
                        {
                            Debug.WriteLine(fra.Name.ToString() + " is considered duplicate with" + chem1.Name.ToString());
                            return false;
                        }
                        else if (mode == 3)
                        {
                            Debug.WriteLine(fra.Name.ToString() + " is considered duplicate with" + chem1.Name.ToString());
                            int ext_idx = fra.Name.IndexOf(fra.Extension);
                            if (ext_idx != -1)
                            {
                                fra.Name = fra.Name.Replace(fra.Extension, chem1.Extension);
                                fra.Extension = chem1.Extension;
                                return false;
                            }
                            else
                            {
                                fra.Extension = chem1.Extension;
                                return false;
                            }
                        }
                        else if (mode == 5)
                        {
                            Debug.WriteLine(fra.Name.ToString() + " is considered duplicate with" + chem1.Name.ToString());
                            fra.Extension += chem1.Extension;
                            fra.Name += chem1.Extension;
                            return false;
                        }
                        else
                        {
                            Debug.WriteLine(fra.Name.ToString() + " is considered duplicate with" + chem1.Name.ToString());
                            string new_extension = find_common_extensions(fra.Extension, chem1.Extension);
                            int ext_idx = fra.Name.IndexOf(fra.Extension);
                            if (ext_idx != -1)
                            {
                                fra.Name = fra.Name.Replace(fra.Extension, new_extension);
                                fra.Extension = new_extension;
                                return false;
                            }
                            else
                            {
                                fra.Extension = new_extension;
                                return false;
                            }
                        }
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
            if (frag_tree.Nodes.Count > 0)
            {
                frag_tree.Nodes.Clear();
            }
            else if (frag_tree.ContextMenuStrip == null)
            {
                frag_tree.AfterCheck += (s, e) =>
                {
                    if ((e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard) && !string.IsNullOrEmpty(e.Node.Name))
                    {
                        find_node_and_expand(fragTypes_tree, e.Node.Checked, e.Node.Name);
                    }
                    frag_node_checkChanged(e.Node, e.Node.Checked);
                };
                frag_tree.AfterSelect += (s, e) => { if (!string.IsNullOrEmpty(e.Node.Name)) { singleFrag_manipulation(e.Node); } };
                frag_tree.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
                frag_tree.ContextMenuStrip.Items.Clear();
                frag_tree.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {                
                                                                      new ToolStripMenuItem("Zoom to fragment",null,(s, e) => { if(frag_tree.SelectedNode!=null)zoom_to_fragment(frag_tree.SelectedNode);  }),
                                                                      new ToolStripSeparator (),
                                                                      new ToolStripMenuItem("Copy fragment", null,(s, e) => { copyTree_toClip(frag_tree, false,true); }),
                                                                      new ToolStripMenuItem("Copy Checked",null, (s, e) => { copyTree_toClip(frag_tree, false); }),
                                                                      new ToolStripMenuItem("Copy All",null, (s, e) => { copyTree_toClip(frag_tree, true); }),
                                                                      new ToolStripSeparator (),
                                                                      new ToolStripMenuItem("Fragment color",null, (s, e) => {if(frag_tree.SelectedNode!=null){ colorSelection_frag_tree(frag_tree.SelectedNode); } }),
                                                                      new ToolStripSeparator (),
                                                                      new ToolStripMenuItem("Remove",null, (s, e) => {if(frag_tree.SelectedNode!=null){ remove_node(frag_tree.SelectedNode.Name); } }),
                                                                      new ToolStripMenuItem("Remove Unchecked",null, (s, e) => {remove_node("",true); }),
                                                                      new ToolStripSeparator (),
                                                                      new ToolStripMenuItem("Replace Extension",null, (s, e) => {replace_extension();  }),
                                                                      new ToolStripSeparator (),
                                                                      new ToolStripMenuItem("Edit fragment properties",null, (s, e) => {show_frag_prop(frag_tree);  })
                });

            }
            // interpret fitted results
            frag_tree.BeginUpdate();

            for (int i = 0; i < Fragments2.Count; i++)
            {
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
        private void zoom_to_fragment(TreeNode node)
        {
            if (string.IsNullOrEmpty(node.Name) || Fragments2.Count == 0) return;
            else
            {
                int idx = Convert.ToInt32(node.Name);
                double max_x = Fragments2[idx].Profile.Last().X;
                double min_x = Fragments2[idx].Profile[0].X;
                zoom_to_frag_frm9(min_x, max_x);

            }
        }
        private void colorSelection_frag_tree(TreeNode node)
        {
            if (string.IsNullOrEmpty(node.Name) || Fragments2.Count == 0) return;
            else
            {
                int idx = Convert.ToInt32(node.Name);
                //ColorDialog clrDlg = new ColorDialog();
                if (clrDlg.ShowDialog() == DialogResult.OK)
                {
                    custom_colors[idx + 1] = clrDlg.Color.ToArgb();
                    Fragments2[idx].Color = OxyColor.FromUInt32((uint)custom_colors[idx + 1]);
                    LC_1.BeginUpdate();
                    LC_1.ViewXY.PointLineSeries[idx + 1].LineStyle.Color = clrDlg.Color;
                    LC_1.ViewXY.LineCollections[idx].LineStyle.Color = clrDlg.Color;
                    LC_1.EndUpdate();
                }
            }
        }
        private void replace_extension()
        {
            string[] frag_temp =view_frag.ToArray();
            string[] label_temp = label_frag.ToArray();
            int initial_count = Fragments2.Count;
            if (initial_count == 0) return;
            string previous_exte = "";
            string final_exte = "";
            int previous_chain_type = 0;
            int final_chain_type = 0;
            int present = 0;//if present=2 both extension are present in sequence list and chain types matter
            var showDialog = ShowRenameExtensionDialog();
            previous_exte = remove_empty_spaces(showDialog[0]);
            final_exte = remove_empty_spaces(showDialog[1]);
            if (string.IsNullOrEmpty(previous_exte) || string.IsNullOrEmpty(final_exte)) { return; }
            if (sequenceList == null || sequenceList.Count == 0) return;
            foreach (SequenceTab seq in sequenceList)
            {
                if (seq.Extension.Equals(previous_exte))
                {
                    previous_chain_type = seq.Type; present++;
                }
                if (seq.Extension.Equals(final_exte))
                {
                    final_chain_type = seq.Type; present++;
                }
            }
            //if (selectedFragments != null && selectedFragments.Count > 0) { selectedFragments.Clear(); }
            foreach (FragForm fra in Fragments2)
            {
                if (present == 2) { recognise_extension_and_replace(fra, previous_exte, final_exte, true, final_chain_type); }
                else { recognise_extension_and_replace(fra, previous_exte, final_exte); }
            }
            if (IonDraw.Count > 0)
            {
                IonDraw.Clear();
                foreach (FragForm fra in Fragments2)
                {
                    if (fra.Fixed)
                    {
                        IonDraw.Add(new ion() { Extension = fra.Extension, SortIdx = fra.SortIdx, Name = fra.Name, Mz = fra.Mz, PPM_Error = fra.PPM_Error, maxPPM_Error = fra.maxPPM_Error, minPPM_Error = fra.minPPM_Error, Charge = fra.Charge, Index = Int32.Parse(fra.Index), IndexTo = Int32.Parse(fra.IndexTo), Ion_type = fra.Ion_type, Max_intensity = fra.Max_intensity * fra.Factor, Color = fra.Color.ToColor(), Chain_type = fra.Chain_type,Has_adduct=fra.Has_adduct });
                    }
                }
            }
            populate_frag_treeView();
            populate_fragtypes_treeView();
            LC_1.BeginUpdate();
            reset_names_iso_plot();
            if (selectedFragments.Count > 0)
            {
                if ((frag_lbl_Btn.Checked ) && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked))
                {
                    List<int> to_plot = new List<int>();
                    // add only the desired fragments to to_plot
                    foreach (int idx in selectedFragments)
                    {
                        string ion = Fragments2[idx - 1].Ion_type;
                        if (ion.StartsWith("a") || ion.StartsWith("(a"))
                        {
                            if (frag_temp.Any(p => p.Equals("a")) && label_temp.Any(p => p.Equals("a"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                        {
                            if (frag_temp.Any(p => p.Equals("b")) && label_temp.Any(p => p.Equals("b"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                        {
                            if (frag_temp.Any(p => p.Equals("c")) && label_temp.Any(p => p.Equals("c"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                        {
                            if (frag_temp.Any(p => p.Equals("x")) && label_temp.Any(p => p.Equals("x"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                        {
                            if (frag_temp.Any(p => p.Equals("y")) && label_temp.Any(p => p.Equals("y"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                        {
                            if (frag_temp.Any(p => p.Equals("z")) && label_temp.Any(p => p.Equals("z"))) { to_plot.Add(idx); }
                        }
                        else if (ion.Contains("int") && ion.Contains("b"))
                        {
                            if (frag_temp.Any(p => p.Equals("internal b")) && label_temp.Any(p => p.Equals("internal b"))) { to_plot.Add(idx); }
                        }
                        else if (!is_riken && ion.Contains("int"))
                        {
                            if (frag_temp.Any(p => p.Equals("internal a")) && label_temp.Any(p => p.Equals("internal a"))) { to_plot.Add(idx); }
                        }
                        else if (is_riken && ion.Contains("int"))
                        {
                            if (frag_temp.Any(p => p.Equals("internal")) && label_temp.Any(p => p.Equals("internal"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                        {
                            if (frag_temp.Any(p => p.Equals("d")) && label_temp.Any(p => p.Equals("d"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                        {
                            if (frag_temp.Any(p => p.Equals("w")) && label_temp.Any(p => p.Equals("w"))) { to_plot.Add(idx); }
                        }
                        else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                        {
                            if (frag_temp.Any(p => p.Equals("v")) && label_temp.Any(p => p.Equals("v"))) { to_plot.Add(idx); }
                        }
                        else if (ion.Contains("M"))
                        {
                            if (frag_temp.Any(p => p.Equals("M")) && label_temp.Any(p => p.Equals("M"))) { to_plot.Add(idx); }
                        }
                        else if (ion.Contains("B("))
                        {
                            if (frag_temp.Any(p => p.Equals("B")) && label_temp.Any(p => p.Equals("B"))) { to_plot.Add(idx); }
                        }
                        else
                        {
                            to_plot.Add(idx);
                        }

                    }
                    frag_annotation(to_plot.ToList(), LC_1);
                }
                else
                {
                    DisposeAllAndClear(LC_1.ViewXY.Annotations);
                }
            }
            LC_1.EndUpdate();
        }
        private void reset_names_iso_plot()
        {
            for (int i = 0; i < Fragments2.Count; i++)
            {
                LC_1.ViewXY.LineCollections[i].Title = new SeriesTitle { Text = Fragments2[i].Name };
                LC_1.ViewXY.PointLineSeries[i + 1].Title = new SeriesTitle { Text = Fragments2[i].Name };
            }
        }
        private int recognise_extension_and_replace(FragForm fra, string initial, string final, bool present = false, int f_type = 0)
        {
            int ext_idx = fra.Name.IndexOf(fra.Extension);
            string new_extension = "";
            string[] str = fra.Extension.Split('_');
            bool changed = false;
            for (int k = 1; k < str.Length; k++)
            {
                if (str[k].Equals(initial))
                {
                    str[k] = final;
                    changed = true;
                    break;
                }
            }
            if (changed)
            {
                for (int k = 1; k < str.Length; k++)
                {
                    new_extension += "_" + str[k];
                }
                if (ext_idx != -1)
                {
                    fra.Name = fra.Name.Replace(fra.Extension, new_extension);
                }
                fra.Extension = new_extension;
                if (present) fra.Chain_type = f_type;
                return 1;
            }
            else { return 0; }
        }
        public string[] ShowRenameExtensionDialog()
        {
            Form prompt = new Form() { ShowIcon = false, ShowInTaskbar = false, ControlBox = true, StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog };
            prompt.Width = 300;
            prompt.Height = 200;
            prompt.Text = "Replace the extension";
            Label textLabel1 = new Label() { Left = 25, Top = 20, Text = "Previous Extension", AutoSize = true, BackColor = Color.Transparent };
            TextBox textBox1 = new TextBox() { Left = 25, Top = 40, Width = 200 };
            Label textLabel2 = new Label() { Left = 25, Top = 70, Text = "New Extension", AutoSize = true, BackColor = Color.Transparent };
            TextBox textBox2 = new TextBox() { Left = 25, Top = 90, Width = 200 };
            Button confirmation = new Button() { Text = "Done", Left = 175, Width = 50, Top = 120 };
            textBox1.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) confirmation.Focus(); };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.AddRange(new Control[] { textBox1, textLabel1, textBox2, textLabel2, confirmation });
            prompt.ShowDialog();
            return new string[] { textBox1.Text.Replace("_", ""), textBox2.Text.Replace("_", "") };
        }
        private void remove_node(string node_name, bool Unchecked = false)
        {
            if (is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            else if ((!Unchecked && string.IsNullOrEmpty(node_name)) || Fragments2.Count == 0) return;
            if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0)
            {
                int count = ExtraFragCalculator.last_plotted.Count;
                all_data.RemoveRange(all_data.Count - ExtraFragCalculator.last_plotted.Count, ExtraFragCalculator.last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - ExtraFragCalculator.last_plotted.Count, ExtraFragCalculator.last_plotted.Count);
                ExtraFragCalculator.last_plotted.Clear();
                //recalc_frm9(count, Form9.last_plotted.Count);
            }
            if (Unchecked)
            {
                int initial_count = Fragments2.Count;
                int rr = 0;
                bool first = true;
                if (Fragments2.Count > 0)
                {
                    while (rr < Fragments2.Count)
                    {
                        if (!Fragments2[rr].To_plot)
                        {
                            Fragments2.RemoveAt(rr);
                            if (first && selectedFragments != null && selectedFragments.Count > 0) { first = false; selectedFragments.Clear(); }
                        }
                        else { rr++; }
                    }
                    // also restore indexes to match array position
                    for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
                    // thread safely fire event to continue calculations
                    Invoke(new Action(() => OnEnvelopeCalcCompleted()));
                }
                if (initial_count == Fragments2.Count) { MessageBox.Show("Fragment list hasn't changed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                else
                {
                    factor_panel.Visible = false;
                    bigPanel.Enabled = false;
                    fitted_results.Clear();
                    if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
                    if (fit_tree != null)
                    {
                        fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed. Fit results are disposed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
                }
            }
            else
            {
                int idx = Convert.ToInt32(node_name);
                fitted_results.Clear();
                if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
                //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
                if (fit_tree != null) { selectedFragments.Clear(); fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed! Fit results are disposed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                if (Fragments2.Count > 0)
                {
                    factor_panel.Visible = false;
                    selectedFragments.Remove(idx + 1);
                    for (int s = 0; s < selectedFragments.Count; s++)
                    {
                        if (selectedFragments[s] > idx + 1)
                        {
                            selectedFragments[s] = selectedFragments[s] - 1;
                        }
                    }
                    Fragments2.RemoveAt(idx); // thread safely fire event to continue calculations
                    for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
                    Invoke(new Action(() => OnEnvelopeCalcCompleted()));
                }
            }

        }
        private void singleFrag_manipulation(TreeNode node)
        {
            // will handle the height of frag. Automaticaly by solo fit, or manualy
            int frag_idx = Convert.ToInt32(node.Name);
            double frag_intensity = Fragments2[frag_idx].Factor * Fragments2[frag_idx].Max_intensity;
            factor_panel.Visible = true;
            factor_panel.Controls.Clear();
            Label factor_lbl = new Label { Text = Fragments2[frag_idx].Name, Location = new Point(5, 10), AutoSize = true };
            Button btn_solo = new Button { Text = "fit", Location = new Point(200, 6), Size = new Size(60, 23) };
            NumericUpDown numUD = new NumericUpDown { Minimum = 0, Maximum = 1e12M, Value = (decimal)Math.Round(frag_intensity, 1), Increment = (decimal)Math.Round(frag_intensity) / 50,
                Location = new Point(275, 7), Size = new Size(60, 20) };
            btn_solo.Click += (s, e) =>
            {
                if (experimental.Count == 0) { MessageBox.Show("Oops..it seems you forgot to load an experimental file!\r\nYou have to load the experimental data first in order to adjust fragment's height!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (is_frag_calc_recalc || (statusStrp.Visible && progressLabel.Text == "Preparing data for fit...")) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
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

            factor_panel.Controls.AddRange(new Control[] { factor_lbl, btn_solo, numUD });
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
            if (Fragments2[idx].To_plot) { tr.BackColor = Color.PowderBlue; if (!selectedFragments.Contains(idx + 1)) { selectedFragments.Add(idx + 1); } }
            if (Fragments2[idx].Fixed)
            {
                tr.ForeColor = Color.DarkGreen;
            }            
            if (Fragments2[idx].True_positive)
            {
                tr.ForeColor = Color.HotPink;
            }
            if (!Fragments2[idx].Candidate)
            {
                tr.ForeColor = Color.Red;
            }
            selectedFragments = selectedFragments.OrderBy(p => p).ToList();
            return tr;
        }
        private void copyTree_toClip(TreeView tree, bool all_nodes, bool only_selected = false)
        {
            StringBuilder sb = new StringBuilder();
            if (only_selected && tree.SelectedNode != null)
            {
                TreeNode subNode = tree.SelectedNode;
                if (string.IsNullOrEmpty(subNode.Name))
                {
                    foreach (TreeNode nn in subNode.Nodes)
                    {
                        int i = Convert.ToInt32(nn.Name);
                        if (Fragments2[i].Name.Contains("intern") || Fragments2[i].Ion_type.Contains("intern"))
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
                    if (Fragments2[i].Name.Contains("intern") || Fragments2[i].Ion_type.Contains("intern"))
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
                        if (Fragments2[i].Name.Contains("intern") || Fragments2[i].Ion_type.Contains("intern"))
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].IndexTo + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                        else
                            sb.AppendLine(Fragments2[i].Name + "\t" + Fragments2[i].Index + "\t" + Fragments2[i].Charge.ToString() + "\t" + Fragments2[i].Mz + "\t" + Fragments2[i].InputFormula +
                                                        "\t" + Fragments2[i].PPM_Error.ToString("0.##") + "\t" + (Fragments2[i].Factor * Fragments2[i].Max_intensity).ToString("0"));
                    }
                }
            }
            Clipboard.Clear();
            if(sb!=null && sb.Length>0) Clipboard.SetText(sb.ToString());
        }
        private void show_frag_prop(TreeView tree)
        {
            if (tree.SelectedNode != null)
            {
                TreeNode subNode = tree.SelectedNode;
                if (!string.IsNullOrEmpty(subNode.Name))
                {                    
                    int i = Convert.ToInt32(subNode.Name);
                    Frag_properties frm = new Frag_properties(Fragments2[i],i,this);
                    frm.ShowDialog();
                }
            }
        }
        private void frag_node_checkChanged(TreeNode node, bool is_checked)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            // this event is called from the fragTree directly, but also from the fitTree indirectly

            // if it is a base node, (un)check all subNodes
            if (string.IsNullOrEmpty(node.Name))
            {
                block_plot_refresh = true;
                block_expand = true;
                foreach (TreeNode subNode in node.Nodes)
                {
                    if (subNode.Checked != node.Checked)
                    {
                        subNode.Checked = node.Checked;
                    }
                }
                block_plot_refresh = false;
                block_expand = false;
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
                        node.BackColor = Color.PowderBlue; Fragments2[idx].To_plot = is_checked;
                        // selectedFragments list starts with 1, Fragments2 start with 0. Also first check if it is already checked (avoid entering the same frag multiple times)
                        if (!selectedFragments.Contains(idx + 1)) selectedFragments.Add(idx + 1);
                        if (!block_expand) EnsureVisibleWithoutRightScrolling(node);
                    }
                    else
                    {
                        node.BackColor = Color.GhostWhite; Fragments2[idx].To_plot = is_checked;
                        // selectedFragments list starts with 1, Fragments2 start with 0.
                        selectedFragments.Remove(idx + 1);
                    }
                    //MessageBox.Show(Fragments2[idx].Max_intensity + "    " + Fragments2[idx].maxFactor);
                    selectedFragments = selectedFragments.OrderBy(p => p).ToList();

                    int k = node.Parent.Text.IndexOf('(');
                    if (k > 0) { node.Parent.Text = node.Parent.Text.Remove(k); }
                    int node_count = Find_selected_subnodes(node.Parent);
                    node.Parent.Text += "(" + node_count.ToString() + " / " + node.Parent.Nodes.Count.ToString() + ")";
                    int all_nodes_chk = 0;
                    foreach (TreeNode mz_n in frag_tree.Nodes)
                    {
                        all_nodes_chk += Find_selected_subnodes(mz_n);
                    }
                    int k1 = frag_tree.Nodes[0].Text.IndexOf('[');
                    if (k1 > 0) { frag_tree.Nodes[0].Text = frag_tree.Nodes[0].Text.Remove(k1 - 1); }
                    frag_tree.Nodes[0].Text += " [Total: " + all_nodes_chk.ToString() + " / " + Fragments2.Count.ToString() + "]";
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
            foreach (TreeNode nn in node.Nodes)
            {
                if (nn.Checked) count++;
            }
            return count;
        }

        //fragTypes
        private void populate_fragtypes_treeView()
        {
            if (fragTypes_tree.Nodes.Count > 0) { fragTypes_tree.Nodes.Clear(); }
            if (fragTypes_tree.ContextMenuStrip == null)
            {
                fragTypes_tree.AfterCheck += (s, e) =>
                {
                    if (string.IsNullOrEmpty(e.Node.Name) && e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                    {
                        foreach (TreeNode innerNode in e.Node.Nodes) { if (innerNode.Checked != e.Node.Checked){innerNode.Checked = e.Node.Checked;} }
                    }
                    else if ((e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard) && !string.IsNullOrEmpty(e.Node.Name))
                    {
                        find_node_and_expand(frag_tree, e.Node.Checked, e.Node.Name);
                    }
                };
                fragTypes_tree.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
                fragTypes_tree.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                        new ToolStripMenuItem("Zoom to fragment",null,(s, e) => { if(fragTypes_tree.SelectedNode!=null)zoom_to_fragment(fragTypes_tree.SelectedNode);  }),
                                        new ToolStripSeparator (),
                                        new ToolStripMenuItem("Copy fragment",null, (s, e) => { copyTree_toClip(fragTypes_tree, false,true); }),
                                        new ToolStripMenuItem("Copy Checked",null, (s, e) => { copyTree_toClip(fragTypes_tree, false); }),
                                        new ToolStripMenuItem("Copy All", null,(s, e) => { copyTree_toClip(fragTypes_tree, true); }),
                                        new ToolStripSeparator (),
                                        new ToolStripMenuItem("Edit fragment properties",null, (s, e) => {show_frag_prop(fragTypes_tree);  })
                });
            }
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
            fragTypes_tree.Visible = true; fragStorage_Lbl.Visible = true; fragTypes_toolStrip.Visible = true;
        }
        private void find_node_and_expand(TreeView tree, bool check, string index)
        {
            if (tree == null || tree.Nodes == null) { return; }
            foreach (TreeNode big_node in tree.Nodes)
            {
                if (big_node.Nodes != null)
                {
                    foreach (TreeNode node in big_node.Nodes)
                    {
                        if (node.Name.Equals(index)) { node.EnsureVisible(); if (node.Checked != check) { node.Checked = check; } break; }
                    }
                }
            }
        }
        private void save_FragTypes_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked)
            {
                MessageBox.Show("Save checked fragments to a .fit file.\r\nIn case heavy chain or light chain or both are present the extension is .hfit, .lfit, .hlfit accordingly.\r\n" +
        "For each fragment multiple information are saved, including ppm error in current experimental spectrum and resolution.\r\n" +
        "Moreover,if the Profile and Centroids of each fragment ('Envipat' Calculations) are saved an 'i' is added to the extension, for example .ifit, .hifit, .lifit, .hlifit.\r\n" +
        "Only the saved fragments are presented in the Peak Finder diagrams tabs.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            selectedFragments_fragTypes.Clear();
            foreach (TreeNode baseNode in fragTypes_tree.Nodes)
            {
                if (baseNode.Nodes != null && baseNode.Nodes.Count > 0)
                {
                    foreach (TreeNode innerNode in baseNode.Nodes)
                    {
                        if (!string.IsNullOrEmpty(innerNode.Name) && innerNode.Checked)
                        {
                            int idx = Convert.ToInt32(innerNode.Name);
                            selectedFragments_fragTypes.Add(idx + 1);
                        }
                    }
                }

            }
            if (selectedFragments_fragTypes.Count == 0) { MessageBox.Show("You have to check fragments first and then select save. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            frag_types_save = true;
            saveList();
        }

        private void toggle_FragTypes_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("When ckecked fully expands the tree view to show all nodes.\r\nWhen un-ckecked collapses the tree view to hide sub-nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            if (fragTypes_tree != null)
            {
                if (toggle_FragTypes_Btn.Checked)
                {
                    fragTypes_tree.ExpandAll();
                }
                else
                {
                    fragTypes_tree.CollapseAll();
                }
            }
        }
        private void check_all_fragTypes_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Checks all nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (fragTypes_tree!=null)
            {
                foreach (TreeNode node in fragTypes_tree.Nodes)
                {
                    node.Checked = true;
                }
            }           
        }

        private void uncheck_all_fragTypes_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Un-checks all nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (fragTypes_tree != null)
            {
                foreach (TreeNode node in fragTypes_tree.Nodes)
                {
                    node.Checked = false;
                }
            }                
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
            if (last_ploted_iso.Count > 0) last_ploted_iso.Clear();
            List<int> idxs = new List<int>();
            for (int i = 1; i < all_data.Count; i++) { idxs.Add(i); }

            Thread allign = new Thread(() => align_distros_2(idxs));
            allign.Start();
            recalc = false;
        }

        private List<double[]> align_distros(List<int> distro_fragm_idxs)
        {
            sw1.Reset(); sw1.Start();
            is_frag_calc_recalc = true;

            all_data_aligned.Clear();
            List<double[]> aligned_intensities = new List<double[]>();
            List<int> aux_idx = new List<int>();

            progress_display_start(all_data[0].Count, "Preparing data for fit...");

            // generate alligned (in m/z) isotope distributions at the same step as the experimental
            // pickup each point in experimental and find (interpolate) the intensity of each fragment
            int progress = 0;
            Parallel.For(0, all_data[0].Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
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
                catch (Exception ex)
                {
                    Debug.WriteLine("progress: " + progress.ToString() + "  " + i.ToString() + " X " + all_data[0][i][0].ToString() + " Y " + all_data[0][i][1].ToString() + "  " + ex);
                    is_frag_calc_recalc = false;
                }

            });
            // sort by mz the aligned intensities list (global) because it is mixed by multi-threading
            int sort_idx = 0;
            all_data_aligned = aligned_intensities.OrderBy(d => aux_idx[sort_idx++]).ToList();
            sw1.Stop(); Debug.WriteLine("All data aligned(M): " + sw1.ElapsedMilliseconds.ToString());
            is_frag_calc_recalc = false;
            progress_display_stop();
            Invoke(new Action(() => OnRecalculate_completed()));
            return aligned_intensities;
        }

        private List<double[]> align_distros_2(List<int> distro_fragm_idxs)
        {
            sw1.Reset(); sw1.Start();
            is_frag_calc_recalc = true;

            all_data_aligned.Clear();
            List<double[]> aligned_intensities = new List<double[]>();
            List<int> aux_idx = new List<int>();

            progress_display_start(all_data[0].Count, "Preparing data for fit...");

            // generate alligned (in m/z) isotope distributions at the same step as the experimental
            // pickup each point in experimental and find (interpolate) the intensity of each fragment
            int progress = 0;
            Parallel.For(0, all_data[0].Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
            {
                // one by one for all points
                List<double> one_aligned_point = new List<double>();

                //// when adding new fragments, we dont need to start from the first. Just copy the already aligned frags.                 
                one_aligned_point.Add(all_data[0][i][1]);

                double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo ta experimental ola ta x-->m/z

                for (int j = 0; j < distro_fragm_idxs.Count; j++)
                {
                    int distro_idx = distro_fragm_idxs[j];

                    // interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                    double aligned_value = 0.0;
                    if( ( mz_toInterp > all_data[distro_idx][all_data[distro_idx].Count - 1][0]) || (mz_toInterp < all_data[distro_idx][0][0]))
                    {
                        aligned_value = 0.0; 
                    }                    
                    else
                    {
                        int[] pair = new int[2];
                        pair = find_closest(mz_toInterp, all_data[distro_idx]);
                        if (Math.Abs(pair[0]-pair[1])<=0.000){aligned_value = all_data[distro_idx][pair[0]][1];}
                        else{aligned_value = interpolate(all_data[distro_idx][pair[0]][0], all_data[distro_idx][pair[0]][1], all_data[distro_idx][pair[1]][0], all_data[distro_idx][pair[1]][1], mz_toInterp);}
                    }                    
                    one_aligned_point.Add(aligned_value);
                }
                lock (_locker)
                {
                    try
                    {
                        aligned_intensities.Add(one_aligned_point.ToArray());
                        aux_idx.Add(i);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                try
                {
                    lock (_locker)
                    {
                        Interlocked.Increment(ref progress); if (progress % 5000 == 0 && i > 0) progress_display_update(progress);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("progress: " + progress.ToString() + "  " + i.ToString() + " X " + all_data[0][i][0].ToString() + " Y " + all_data[0][i][1].ToString() + "  " + ex);
                    is_frag_calc_recalc = false;
                }

            });
            // sort by mz the aligned intensities list (global) because it is mixed by multi-threading
            int sort_idx = 0;
            all_data_aligned = aligned_intensities.OrderBy(d => aux_idx[sort_idx++]).ToList();
            sw1.Stop(); Debug.WriteLine("All data aligned(M): " + sw1.ElapsedMilliseconds.ToString());
            is_frag_calc_recalc = false;
            progress_display_stop();
            Invoke(new Action(() => OnRecalculate_completed()));
            return aligned_intensities;
        }
        public static int[] find_closest(double mz_toInterp,List<double[]> data,bool is_peaklist=false)
        {
            int[] result = new int[2];
            double length = data.Count;
            int mi =(int)Math.Floor( length / 2);
            double temp_m = data[mi][0];
            if (is_peaklist) temp_m = data[mi][1] + data[mi][4];
            double min_diff =mz_toInterp - temp_m;
            int minimum = 0;
            int min_mi = mi;
            while (mi<length && mi>=0)
            {
                int temp_mi = 0;                 
                if(is_peaklist) temp_m = data[mi][1]+ data[mi][4];
                else temp_m = data[mi][0];
                double diff = mz_toInterp - temp_m;
                if (Math.Abs(diff) < Math.Abs(min_diff)) { min_diff = diff; min_mi = mi; }
                if (diff == 0.0) break;
                else if (diff < 0)
                {                    
                    length = mi;
                    temp_mi =minimum+ (int)Math.Floor((length-minimum) / 2);
                }
                else
                {
                    minimum = mi;
                    temp_mi = mi+(int)Math.Ceiling((length-mi )/ 2);
                }
                if (temp_mi < minimum)
                {
                    temp_mi = minimum;
                }
                if (mi == temp_mi) break;                
                else { mi = temp_mi; }
            }            
            if (min_diff== 0 || is_peaklist)
            {
                result = new int[] { min_mi, min_mi };
            }
            else if (min_diff>0)
            {
                if(min_mi + 1< data.Count) result = new int[] { min_mi, min_mi + 1 };
                else result = new int[] { min_mi, min_mi };
            }
            else
            {
                if (min_mi - 1 >0) result = new int[] { min_mi - 1, min_mi };
                else result = new int[] { min_mi, min_mi };
            }
            return result;
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
            if (Math.Abs(x_inter - x2)<=0.000 )
            {
                return y2;
            }
            else if (Math.Abs(x_inter - x1) <= 0.000)
            {
                return y1;
            }
            else
            {
                // linear interpolation
                return ((x_inter - x1) * y2 + (x2 - x_inter) * y1) / (x2 - x1);
            }            
        }

        #endregion

        #region 4.Fitting
        private void fit_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked)
            {
                if ((sender as ToolStripButton) == fit_Btn) { MessageBox.Show("Performs fit on all the fragments of the Fragment List.\r\nDuring fitting, fragments are divided into groups of n fragments\r\n" +
                    "and n! combinations of fragments are generated for each group.\r\nEach fragment's intensity in each combination is fitted to match the experimental.\r\nThe basic parameters of this procedure are user defined and can be accessed by the 'Settings' button.  ", "Automatic Fitting", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                else { MessageBox.Show("Performs fit on all the checked fragments of the Fragment List.\r\nDuring fitting, fragments are divided into groups of n fragments\r\n" +
                    "and n! combinations of fragments are generated for each group.\r\nEach fragment's intensity in each combination is fitted to match the experimental.\r\nThe basic parameters of this procedure are user defined and can be accessed by the 'Settings' button.  ", "Fitting of checked fragments", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            }
            if (is_frag_calc_recalc || (statusStrp.Visible && progressLabel.Text== "Preparing data for fit...")) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            if (experimental.Count == 0) { MessageBox.Show("Oops...it seems you forgot to load the experimental file!The basic steps are the following:\r\n1.Load the experimental data\r\n2.create a Fragment list\r\nPerform fit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (Fragments2.Count == 0) { MessageBox.Show("Oops...it seems you forgot to create a Fragment list!The basic steps are the following:\r\n1.Load the experimental data\r\n2.create a Fragment list\r\n3.Perform fit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            DialogResult dialogResult = MessageBox.Show("Ready to perform fit! Are you sure you want to proceed?", "Perform fit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                bigPanel.Enabled = false;

                // initialize a new background thread for fit 
                Thread fit;

                if ((sender as ToolStripButton) == fit_Btn) fit = new Thread(() => main_fit(true));
                else fit = new Thread(() => main_fit(false));

                fit.Start();

                //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = true;
            }
            else
            {
                return;
            }
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
            //if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            if (all_fitted_results != null) all_fitted_results.Clear();
            if (all_fitted_sets != null) all_fitted_sets.Clear();
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
        private List<double> get_UI_intensities(int[] subSet)
        {
            // is called from fit to pass a good starting height to the optimizer
            List<double> UI_intensities = new List<double>();

            for (int i = 0; i < subSet.Length; i++)
            {
                double factor = Fragments2[subSet[i] - 1].maxFactor;
                if (factor != 0) UI_intensities.Add(factor);
                else UI_intensities.Add(0.1 * max_exp);
            }

            return UI_intensities;
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

            Parallel.For(0, set.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
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

        /// <summary>
        /// Calculate di score and ei score
        /// </summary>
        private void centroid_LSE(int[] set_array, double[] tmp)
        {
            double lse = 0.0;
            List<double[]> lse_fragments = new List<double[]>();

            for (int ss = 0; ss < set_array.Length; ss++)
            {
                int frag_index = set_array[ss] - 1;
                double frag_factor = tmp[ss];
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
                        double ee = ee1 * sorted_cen[c].Y;
                        iso_lse_sum += ee; tmp_error[c] = ee1;                                         
                    }
                    else
                    {
                        tmp_error[c] = 1.0;
                        iso_lse_sum += tmp_error[c] * sorted_cen[c].Y; absent_factor += tmp_error[c] * sorted_cen[c].Y; absent_isotope++;
                    }
                }
                lse_fragments.Last()[0] = 100 * absent_isotope / sorted_cen.Count();
                lse_fragments.Last()[1] = iso_lse_sum / summ;
                lse_fragments.Last()[2] = (iso_lse_sum - absent_isotope) / (sorted_cen.Count() - absent_isotope);
                lse += lse_fragments.Last()[1];
                double sd = 0.0;
                for (int d = 0; d < tmp_error.Length; d++)
                {
                    sd += sorted_cen[d].Y * Math.Pow((tmp_error[d] - lse_fragments.Last()[1]), 2);
                }
                tmp[ss + 2 * set_array.Length] = 100.00 * Math.Sqrt(sd / (summ));
                tmp[ss + set_array.Length] = 100.00 * lse_fragments.Last()[1];
                tmp[ss + 3 * set_array.Length] = 100.00 * absent_factor / summ;
            }
            lse = 100.00 * lse / set_array.Length;
            tmp[6 * set_array.Length + 2] = lse;
            return;
        }
        /// <summary>
        /// Calculate di' or dinew score
        /// </summary>
        private void di_aligned(int[] set_array, double[] tmp)
        {
            List<double[]> lse_fragments = new List<double[]>();
            double dinew_average = 0.0; double ei_average = 0.0;
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
                foreach (PointPlot p in sorted_cen) { summ += p.Y; }
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
                        exp_intensity = 0; exp_cen = 0; absent_factor += sorted_cen[c].Y / summ;
                    }
                    double frag_int = sorted_cen[c].Y * frag_factor;
                    frag_info.Add(new double[] { exp_cen, exp_intensity, frag_int, sorted_cen[c].Y / summ, ss, frag_int, sorted_cen[c].Y / summ });
                }
                tmp[ss + 3 * set_array.Length] = 100.00 * absent_factor;
                ei_average += absent_factor;
            }
            frag_info_sorted = frag_info.OrderBy(p => p[0]).ToList(); //sorted by m/z
            for (int a = 0; a < frag_info_sorted.Count; a++)
            {
                if (frag_info_sorted[a][0] != 0)
                {
                    if (a == frag_info_sorted.Count - 1)
                    {
                        frag_info_sorted[a][6] = (Math.Abs(frag_info_sorted[a][1] - frag_info_sorted[a][2]) * frag_info_sorted[a][3]* frag_info_sorted[a][2]) / (Math.Max(frag_info_sorted[a][1], frag_info_sorted[a][2]) * frag_info_sorted[a][5]);
                        break;
                    }
                    for (int b = a + 1; b < frag_info_sorted.Count; b++)
                    {
                        if (a != b)
                        {
                            if (frag_info_sorted[a][0] == frag_info_sorted[b][0])
                            {
                                frag_info_sorted[a][5]+= frag_info_sorted[b][2];
                                frag_info_sorted[b][5]+= frag_info_sorted[a][2];
                            }
                            else if (frag_info_sorted[a][0] < frag_info_sorted[b][0])
                            {
                                frag_info_sorted[a][6] = (Math.Abs(frag_info_sorted[a][1] - frag_info_sorted[a][2]) * frag_info_sorted[a][3] * frag_info_sorted[a][2]) / (Math.Max(frag_info_sorted[a][1], frag_info_sorted[a][2]) * frag_info_sorted[a][5]);
                                break;
                            }
                        }
                    }
                }
            }
            frag_info = frag_info_sorted.OrderBy(p => p[4]).ToList(); //sorted by fragment index in tmp-->ss 
            //di' aka dinew calculation and dinew_average calculation
            for (int a = 0; a < frag_info.Count; a++)
            {
                dinew_average += frag_info[a][6];
                tmp[(int)frag_info[a][4] + 4 * set_array.Length] += frag_info[a][6];
            }
            dinew_average = dinew_average * 100 / set_array.Length;
            ei_average = ei_average * 100 / set_array.Length;
            tmp[6 * set_array.Length] = dinew_average;
            tmp[6 * set_array.Length + 1] = ei_average;

            //sdi' calcalculation
            for (int a = 0; a < frag_info.Count; a++)
            {
                tmp[(int)frag_info[a][4] + 5 * set_array.Length] += frag_info[a][3] * Math.Pow((Math.Abs(frag_info[a][1] - frag_info[a][2]) / Math.Max(frag_info[a][1], frag_info[a][2]) / frag_info[a][5]) - (tmp[(int)frag_info[a][4] + 4 * set_array.Length]/*/ frag_info[a][3]*/), 2);
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
            int start = all_data_aligned.Count() - 1;
            int end = all_data_aligned.Count() - 1;
            for (int i = 0; i < start; i++)
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
            set_index[0] = start; set_index[1] = end;
            return set_index;
        }
        private double calc_surface_area(int[] boundaries)
        {
            double temp = 0;
            for (int i = boundaries[0]; i < boundaries[1] + 1; i++)
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
        private double[] estimate_fragment_height_multiFactor(List<double[]> aligned_intensities_subSet, List<double> UI_intensities, double experimental_sum)
        {
            //check if aligned_intensities_subSet is empty
            if (aligned_intensities_subSet.Count == 0)
            {
                int frag_count = UI_intensities.Count();
                double[] coeficients = new double[frag_count];
                for (int i = 0; i < frag_count; i++) coeficients[i] = 0.0;
                // 2. save result
                // save all the coefficients and last cell is the minimized value of SSE. result = [frag1_int, frag2_int,....,di_new,ei,di, SSE,Mi,M]
                double[] result = new double[6 * frag_count + 6];
                for (int i = 0; i < frag_count; i++) { result[i] = coeficients[i]; result[i + 4 * frag_count] = 0; result[i + 5 * frag_count] = 0; } //initialize di error and sd
                result[6 * frag_count + 3] = 0;
                result[6 * frag_count + 4] = 100; result[6 * frag_count + 5] = 100;
                return result;
            }
            else
            {
                // 1. initialize needed params
                // in coefficients[0] refers to 1st frag, and in aligned_intensities[0] refers to experimental
                // UI_intensities is initial values to make a starting point
                int distros_num = aligned_intensities_subSet[0].Length - 1;//osa kai ta fragments pou einai sto subset

                double[] coeficients = UI_intensities.ToArray();
                double[] bndl = new double[distros_num];
                double[] bndh = new double[distros_num];
                for (int i = 0; i < distros_num; i++) { bndl[i] = coeficients[i] * 1e-5; bndh[i] = coeficients[i]; }
                double max_exp = aligned_intensities_subSet.Max(p=>p[0]);
                double[] max_frag = new double[distros_num];
                //for (int i = 0; i < distros_num; i++) { bndh[i] = max_exp / aligned_intensities_subSet.Max(p => p[i+1]) ; }
               
                double epsx = 0.000001;
                int maxits = 1000000;
                alglib.minlmstate state;
                alglib.minlmreport rep;

                alglib.minlmcreatev(distros_num, coeficients, 0.001, out state);
                alglib.minlmsetbc(state, bndl, bndh);                                            // boundary conditions
                alglib.minlmsetcond(state, epsx, maxits);
                alglib.minlmoptimize(state, sse_multiFactor, null, aligned_intensities_subSet);
                alglib.minlmresults(state, out coeficients, out rep);

                // 2. save result
                // save all the coefficients and last cell is the minimized value of SSE. result = [frag1_int, frag2_int,....,di_new,ei,di, SSE,Mi,M]
                double[] result = new double[6 * distros_num + 6];
                for (int i = 0; i < distros_num; i++) { result[i] = coeficients[i]; result[i + 4 * distros_num] = 0; result[i + 5 * distros_num] = 0; } //initialize di error and sd
                result[6 * distros_num + 3] = state.fi[0];
                (result[6 * distros_num + 4], result[6 * distros_num + 5]) = maxmin_area_ratio(aligned_intensities_subSet, coeficients, experimental_sum);
                              
                return result;
            }
        }
        private (double, double) per_cent_fit_coverage(List<double[]> aligned_intensities_subSet, double[] coeficients, double exp_sum)
        {
            double exp_frag_sum = 0.0, frag_sum = 0.0;

            for (int i = 0; i < aligned_intensities_subSet.Count; i++)
            {
                double tmp = 0.0;
                for (int j = 1; j < aligned_intensities_subSet[0].Length; j++)
                {
                    tmp += aligned_intensities_subSet[i][j] * coeficients[j - 1];
                }

                if (tmp > 1)        // envelopes have a lot of garbage upFront and in tail ( < 1e-2)
                {
                    frag_sum += tmp;
                    exp_frag_sum += aligned_intensities_subSet[i][0];
                }
            }
            double res = exp_sum / frag_sum;
            double res_frag = exp_frag_sum / frag_sum;
            if (res >= 1)
            {
                res = (frag_sum / exp_sum);
            }
            if (res_frag >= 1)
            {
                res_frag = (frag_sum / exp_frag_sum);
            }

            res = (1 - res) * 100; res_frag = (1 - res_frag) * 100;
            return (res_frag, res);
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
             
        private (double, double) maxmin_area_ratio(List<double[]> aligned_intensities_subSet, double[] coeficients,/* int[] set_array, double[] tmp,*/ double exp_sum)
        {            
            double ovrlp_area = 0.0;
            double exp_area = 0.0;            
            for (int i = 0; i < aligned_intensities_subSet.Count; i++)
            {
                double tmp = 0.0;
                for (int j = 1; j < aligned_intensities_subSet[0].Length; j++)
                {
                    double intens = coeficients[j - 1] * aligned_intensities_subSet[i][j];
                    if (intens > 1) { tmp += intens; }                   
                }
                if (tmp > 1)        // envelopes have a lot of garbage upFront and in tail ( < 1e-2)
                {
                    ovrlp_area += Math.Min(aligned_intensities_subSet[i][0], tmp);
                    exp_area += aligned_intensities_subSet[i][0];
                }
            }
            double ratio = (1 - (ovrlp_area / exp_area)) * 100;
            double ratio_all = (1 - (ovrlp_area / exp_sum)) * 100;
            return (ratio, ratio_all);
        }       
      
        private void generate_fit_results(bool project = false)
        {
            if (all_fitted_results == null || all_fitted_results.Count == 0) return;
            else if (all_fitted_results.Count == 1 && all_fitted_results[0].Count == 0) return;
            sw1.Reset(); sw1.Start();
            // clear panel
            bigPanel.Enabled = true;
            foreach (Control ctrl in bigPanel.Controls) { bigPanel.Controls.Remove(ctrl); ctrl.Dispose(); }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            // init tree view
            fit_tree = new MyTreeView() {BackColor=Color.GhostWhite, CheckBoxes = true, Location = new Point(2, 2), Name = "fit_tree", Size = new Size(bigPanel.Size.Width - 10, bigPanel.Size.Height - 10), ShowNodeToolTips = false, HideSelection = false, TreeViewNodeSorter = new NodeSorter(),Anchor=AnchorStyles.Bottom| AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right  };
            bigPanel.Controls.Add(fit_tree);
            fit_tree.AfterCheck += (s, e) => { if (!dont_refresh_frag_tree) fit_node_checkChanged(e.Node); };
            //fit_tree.ContextMenu = new ContextMenu(new MenuItem[1] { new MenuItem("Copy", (s, e) => { copy_fitTree_toClipBoard(); }) });
            fit_tree.BeforeCheck += (s, e) => { if (!dont_refresh_frag_tree) node_beforeCheck(s, e); };
            fit_tree.BeforeSelect += (s, e) => { node_beforeCheck(s, e); };
            fit_tree.AfterSelect += (s, e) => { if (string.IsNullOrEmpty(e.Node.Name)) { toolTip_fit.Hide(fit_tree); fit_set_graph_zoomed(e.Node); } else { select_check(e.Node); } };
            ContextMenu ctxMn_fit_grp = new ContextMenu(new MenuItem[2] { new MenuItem("Sort & Filter node", (s, e) => { fitnode_Re_Sort(fit_tree.SelectedNode); }), new MenuItem("Refresh node", (s, e) => {/*uncheckall_Frag();*/refresh_fitnode_sorting(fit_tree.SelectedNode); }) });
            ContextMenu ctxMn_fit_grp_solution = new ContextMenu(new MenuItem[3] { new MenuItem("Error", (s, e) => { show_error(_currentNode); }), new MenuItem("Copy Solution's Scores", (s, e) => { copy_solution_scorestoClipBoard(_currentNode); }), new MenuItem("Copy Solution Fragments' Scores", (s, e) => { copy_solution_fragments_toClipBoard(_currentNode); }) });
            fit_tree.NodeMouseClick += (s, e) =>
            {
                if (fit_tree != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (string.IsNullOrEmpty(e.Node.Name)) { fit_tree.SelectedNode = e.Node; fit_tree.ContextMenu = ctxMn_fit_grp; }
                        else { _currentNode = e.Node; fit_tree.ContextMenu = ctxMn_fit_grp_solution; }
                    }
                }
            };


            //fit_tree.ContextMenu = new ContextMenu(new MenuItem[3] { new MenuItem("Sort & Filter node", (s, e) => { fitnode_Re_Sort(fit_tree.SelectedNode); }), new MenuItem("Refresh node", (s, e) => {/*uncheckall_Frag();*/refresh_fitnode_sorting(fit_tree.SelectedNode); }), new MenuItem("error", (s, e) => { show_error(fit_tree.SelectedNode); }) });
            fit_tree.NodeMouseHover += (s, e) => { toolTip_fit.Hide(fit_tree); fit_tree_tooltip(e.Node); };
            fit_tree.MouseLeave += (s, e) => { toolTip_fit.Hide(fit_tree); };
            fit_tree.MouseHover += (s, e) => { toolTip_fit.Hide(fit_tree); };

            // interpret fitted results
            fit_tree.BeginUpdate();
            for (int i = 0; i < all_fitted_results.Count; i++)
            {
                if (all_fitted_sets[i].Count == 0) continue;
                // get first and last mz of this fit, from the array that contains all the indexes (the longest)
                int[] longest = all_fitted_sets[i].OrderBy(x => x.Length).Last();
                fit_tree.Nodes.Add(Fragments2[longest.First() - 1].Mz + " - " + Fragments2[longest.Last() - 1].Mz);                                      
                for (int j = 0; j < all_fitted_results[i].Count; j++)
                {
                    if (all_fitted_results[i][j][all_fitted_results[i][j].Length - 2] <=tab_thres[i][0] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 1] <= tab_thres[i][1] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 4] <= tab_thres[i][2] && all_fitted_results[i][j][all_fitted_results[i][j].Length - 5] <= tab_thres[i][3] && (all_fitted_results[i][j][all_fitted_results[i][j].Length - 6] <= tab_thres[i][4] /*|| all_fitted_sets[i][j].Length== 1*/))
                    {
                        bool print = true;                        
                        for (int k = 0; k < all_fitted_sets[i][j].Length; k++)
                        {
                            if (all_fitted_results[i][j][k + all_fitted_sets[i][j].Length] > tab_thres[i][2] || all_fitted_results[i][j][k + 3 * all_fitted_sets[i][j].Length] > tab_thres[i][3] || (all_fitted_results[i][j][k + 4 * all_fitted_sets[i][j].Length] > tab_thres[i][4]/* && all_fitted_sets[i][j].Length>1*/) || all_fitted_results[i][j][k + 2 * all_fitted_sets[i][j].Length] > tab_thres[i][5] || all_fitted_results[i][j][k + 5 * all_fitted_sets[i][j].Length] > tab_thres[i][6] || Fragments2[all_fitted_sets[i][j][k] - 1].Max_intensity * all_fitted_results[i][j][k] < min_intes + 0.1)
                            {
                                print = false;break;
                            }
                        }
                        if (print)
                        {
                            StringBuilder sb = new StringBuilder();

                            string tmp = "";
                            tmp += "SSE:" + all_fitted_results[i][j][all_fitted_results[i][j].Length - 3].ToString("0.###e0" + " ");
                            tmp += "di:" + Math.Round(all_fitted_results[i][j][all_fitted_results[i][j].Length - 4], 3).ToString() + "% ";                            
                            TreeNode tr = new TreeNode
                            {
                                Text = tmp,
                                Name = i.ToString() + " " + j.ToString()
                            };
                            fit_tree.Nodes[i].Nodes.Add(tr);
                        }
                    }
                }               
            }
            fit_tree.EndUpdate();
            remove_child_nodes();
            sw1.Stop(); Debug.WriteLine("Fit treeView populate: " + sw1.ElapsedMilliseconds.ToString());
            if (!project)
            {
                uncheckall_Frag();
                best_checked();
            }
            else checked_labels();
        }
        //***************************************************

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
            sb.AppendLine("M:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 1], 2).ToString() + "%" + "    " + "Mi:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 2], 2).ToString() + "%" + "    " + "ei:" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 5], 2).ToString() + "%" + "    " + "di':" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 6], 2).ToString() + "%");
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
            if (sb != null && sb.Length > 0)
            {
                tool_text = sb.ToString();

                // Node location in treeView coordinates.
                Point loc = fitnode.Bounds.Location;

                // Node location in form client coordinates.
                loc.Offset(fit_tree.Location);

                //if (show_Btn.Visible == true)
                //{
                // Make balloon point to upper left corner of the node.
                loc.Offset(0, fitnode.Bounds.Height + 10);
                //}
                //else
                //{
                //    // Make balloon point to upper right corner of the node.
                //    loc.Offset(fitnode.Bounds.Width, 0);
                //}

                toolTip_fit.Show(tool_text, fit_tree, loc);
            }

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
        /// shows the scores(M,Mi,di,ei,di') of  each fragment in the right clicked solution node in a fit group solution
        /// </summary>
        private void show_error(TreeNode node)
        {
            if (node == null) { MessageBox.Show("Oops... First make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            StringBuilder sb = new StringBuilder();
            double lse = 0.0;
            List<double[]> lse_fragments = new List<double[]>();
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group.\r\nFirst make sure you have selected the desired node and then right-click on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
            {
                string idx_str = node.Name;
                string[] idx_str_arr = idx_str.Split(' ');
                int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
                int set_pos_idx = Convert.ToInt32(idx_str_arr[1]);
                // identifies a fit combination in this set
                string error_string = String.Empty;
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
                            double ee = ee1 * sorted_cen[c].Y / summ;
                            iso_lse_sum += ee; tmp_error[c] = ee1;                                
                            sb.AppendLine("Centroid " + (c + 1).ToString() + " error:" + Math.Round(ee1, 4).ToString() + " , adjusted to:" + Math.Round(ee, 4).ToString());
                        }
                        else
                        {
                            tmp_error[c] = 1.0;
                            iso_lse_sum += tmp_error[c] * sorted_cen[c].Y / summ; absent_factor += tmp_error[c] * sorted_cen[c].Y / summ; absent_isotope++;
                            sb.AppendLine("Centroid " + (c + 1).ToString() + " error: 1.0" + " , adjusted to:" + Math.Round(tmp_error[c] * sorted_cen[c].Y / summ,4).ToString() + " (absent isotope)");
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
                    sb.AppendLine(Math.Round(lse_fragments.Last()[0], 2).ToString() + "% of the centroids were absent |with ei= " + Math.Round(absent_factor, 4).ToString() + " | the average error is " + Math.Round(lse_fragments.Last()[1], 5).ToString() + " | sd: " + Math.Round(sd, 4).ToString());
                    sb.AppendLine();
                }               
                if (sb != null && sb.Length > 0)
                {
                    error_string = sb.ToString();
                    Message_Window_Form frm17 = new Message_Window_Form(error_string);
                    frm17.ShowDialog();
                }
            }
        }
        private void node_beforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if ((e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard) && !string.IsNullOrEmpty(e.Node.Name) && !e.Node.Checked)
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
            Array.Sort(tree_sse, tree_index);
            int best_count = (int)(0.3 * tree_index.Length);
            while (best_count < tree_sse.Length - 2) { if (tree_sse[best_count] == tree_sse[best_count + 1]) { best_count++; } else { break; } }
            for (int n = 0; n < best_count; n++)
            {
                node.Nodes[(int)tree_index[n]].ForeColor = Color.SteelBlue;
            }
        }
        private void copy_solution_fragments_toClipBoard(TreeNode node)
        {
            if (node == null) { MessageBox.Show("Oops... First make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group.\r\nFirst make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            DialogResult dialogResult = MessageBox.Show("Do you want to add headers to the copied data?", "Headers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                sb.AppendLine(Fragments2[curr_idx].Name + "\t" + Fragments2[curr_idx].Mz + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length], 3).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length * 3], 2).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][i + all_fitted_sets[set_idx][set_pos_idx].Length * 4], 3).ToString() + "%" + "\t" + Math.Round(Fragments2[curr_idx].PPM_Error, 2).ToString() + "\t" + intensity);
            }
            Clipboard.Clear();
            if (sb != null && sb.Length > 0) Clipboard.SetText(sb.ToString());
        }
        private void copy_solution_scorestoClipBoard(TreeNode node)
        {
            if (node == null) { MessageBox.Show(" First make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(node.Name)) { MessageBox.Show("'Error' command is implemented on nodes that represent a specific solution of the fit group.\r\nFirst make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            DialogResult dialogResult = MessageBox.Show("Do you want to add headers to the copied data?", "Headers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool header = true;
            if (dialogResult == DialogResult.No) { header = false; }
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
                Name += Fragments2[curr_idx].Name + "   ";
            }
            if (header) sb.AppendLine("Fragments" + "\t" + "M" + "\t" + "Mi" + "\t" + "di" + "\t" + "ei" + "\t" + "di'" + "\t" + "SSE");
            sb.AppendLine(Name + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 1], 2).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 2], 2).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 4], 3).ToString() + "% " + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 5], 2).ToString() + "%" + "\t" + Math.Round(all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 6], 3).ToString() + "%" + "\t" + all_fitted_results[set_idx][set_pos_idx][all_fitted_results[set_idx][set_pos_idx].Length - 3].ToString("0.###e0" + " "));
            Clipboard.Clear();
            if (sb != null && sb.Length > 0) Clipboard.SetText(sb.ToString());
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
                labels_checked[set_idx] = idx_str;
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
            if (!block_fit_refresh) refresh_iso_plot();
        }
        /// <summary>
        /// It was used to recheck the nodes as the user has left them before altering a specific node. Its is currently not used
        /// </summary>
        private void checked_labels()
        {
            if (fit_tree != null && fit_tree.Nodes.Count == labels_checked.Count)
            {
                dont_refresh_frag_tree = true;
                block_plot_refresh = true; block_fit_refresh = true;
                for (int nd = 0; nd < fit_tree.Nodes.Count; nd++)
                {
                    foreach (TreeNode node in fit_tree.Nodes[nd].Nodes) { if (node.Name == labels_checked[nd]) { node.Checked = true; } }
                }
                block_plot_refresh = false; block_fit_refresh = false;
                // because of multiple checked events it was disabled
                // it will be called once, now that all coresponding fragments are checked
            }
            block_plot_refresh = false; block_fit_refresh = false;
            dont_refresh_frag_tree = false;
            refresh_iso_plot();
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
       
        private void sortSettings_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Displays the sort settings panel.\r\n" +
                "During the fitting procedure for each fit group solution and for the fragments that form the solution, specific scores are calculated. \r\n" +
                "The boundaries regarding the accepted score values are user defined.\r\nThe solutions of each fit group are sorted according to their scores and the weight of each score is user defined.\r\n" +
                "These properties are accessed in the sort settings panel.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            sort_fit_results_form(true);
        }
        private void sort_fit_results_form(bool btn = false)
        {
            Fit_Filters_Form sort_fit_results = new Fit_Filters_Form(false, 1);
            sort_fit_results.FormClosed += (s, f) => { save_preferences(); };
            sort_fit_results.ShowDialog();

        }
        private void refresh_fitRes_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Refreshes 'Fit results' based on 'Sort Settings'.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
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
                frag_tree.EndUpdate();
                refresh_iso_plot();
            }
        }
        /// <summary>
        /// Command to Refresh the node sorting in a specific fit group in the fit tree
        /// </summary>
        private void fitnode_Re_Sort(TreeNode node)
        {
            if (node == null) { MessageBox.Show("Oops... First make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrEmpty(node.Name))
            {
                form_sort_fitnode(node.Index);
            }
            else
            {
                MessageBox.Show("'Sort & Filter node' command is implemented on nodes that represent a fit group and not a specific solution of the fit group.\r\nFirst make sure you have selected the desired node and then right-clicked on it.", " None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Refresh the node sorting in a specific fit group in the fit tree
        /// </summary>
        private void refresh_fitnode_sorting(TreeNode node)
        {
            if (node == null) { MessageBox.Show("Oops...First make sure you have selected the desired node and then right-clicked on it.", "None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            int node_index = node.Index;
            foreach (TreeNode tnn in fit_tree.Nodes[node_index].Nodes)
            {
                if (tnn.Checked) tnn.Checked = false;
            }
            if (all_fitted_results != null && string.IsNullOrEmpty(node.Name))
            {
                frag_tree.BeginUpdate();               
                fit_tree.BeginUpdate();
                if (fit_tree.Nodes[node_index].Nodes.Count > 0) fit_tree.Nodes[node_index].Nodes.Clear();
                for (int j = 0; j < all_fitted_results[node_index].Count; j++)
                {
                    if (all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 2] < tab_thres[node_index][0] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 1] < tab_thres[node_index][1] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 4] < tab_thres[node_index][2] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 5] < tab_thres[node_index][3] && all_fitted_results[node_index][j][all_fitted_results[node_index][j].Length - 6] < tab_thres[node_index][4])
                    {
                        bool print = true;
                        for (int k = 0; k < all_fitted_sets[node_index][j].Length; k++)
                        {
                            if (all_fitted_results[node_index][j][k + all_fitted_sets[node_index][j].Length] > tab_thres[node_index][2] || all_fitted_results[node_index][j][k + 3 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][3] || all_fitted_results[node_index][j][k + 4 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][4] || all_fitted_results[node_index][j][k + 2 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][5] || all_fitted_results[node_index][j][k + 5 * all_fitted_sets[node_index][j].Length] > tab_thres[node_index][6] || Fragments2[all_fitted_sets[node_index][j][k] - 1].Max_intensity * all_fitted_results[node_index][j][k] < min_intes + 0.1) { print = false; }
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
                MessageBox.Show("'Refresh node' command is implemented on nodes that represent a fit group and not a specific solution of the fit group.\r\nFirst make sure you have selected the desired node and then right-clicked on it.", " None selected node", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                tab_node.Add(new bool[] { fit_sort[0], fit_sort[1], fit_sort[2], fit_sort[3], fit_sort[4], fit_sort[5] }); tab_coef.Add(new double[] { a_coef[0], a_coef[1], a_coef[2], a_coef[3], a_coef[4], a_coef[5] });
                tab_thres.Add(new double[] { fit_thres[0], fit_thres[1], fit_thres[2], fit_thres[3], fit_thres[4], fit_thres[5], fit_thres[6] }); labels_checked.Add("");
            }
            return;
        }
        private void form_sort_fitnode(int index)
        {
            Fit_Filters_Form sort_node = new Fit_Filters_Form(true, index);
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
                // value to compare--->sse_coef*sse+Ai_coef*Mi+A_coef*M+di_coef*di+ei_coef*ei+dinew_coef+dinew
                double value1 = (tab_coef[tx_set_idx][3] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 3]) + (tab_coef[tx_set_idx][0] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 2]) + (tab_coef[tx_set_idx][1] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 1]) + (tab_coef[tx_set_idx][2] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 4]) + (tab_coef[tx_set_idx][4] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 5]) + (tab_coef[tx_set_idx][5] * all_fitted_results[tx_set_idx][tx_set_pos_idx][tx_compare_item_idx - 6]);
                double value2 = (tab_coef[tx_set_idx][3] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 3]) + (tab_coef[tx_set_idx][0] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 2]) + (tab_coef[tx_set_idx][1] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 1]) + (tab_coef[tx_set_idx][2] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 4]) + (tab_coef[tx_set_idx][4] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 5]) + (tab_coef[tx_set_idx][5] * all_fitted_results[ty_set_idx][ty_set_pos_idx][ty_compare_item_idx - 6]);
                compare_result = Decimal.Compare((decimal)value1, (decimal)value2);
                return compare_result;
            }
        }
        private void select_check(TreeNode node)
        {
            if (node.Checked) { node.Checked = false; }
            else { node.Checked = true; toolTip_fit.Hide(fit_tree); fit_tree_tooltip(node); }
        }
        /// <summary>
        /// ZOOM at the graph region the selected fit tree node is about
        /// </summary>
        private void fit_set_graph_zoomed(TreeNode node)
        {
            if (plotExp_chkBox.Checked || plotCentr_chkBox.Checked || plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked)
            {
                string[] idx_str_arr = new string[2];
                string idx_str = node.Name;
                if (string.IsNullOrEmpty(idx_str)) idx_str_arr = node.Text.Split('-');
                else idx_str_arr = node.Parent.Text.Split('-');
                double min_border = dParser(idx_str_arr[0]);
                double max_border = dParser(idx_str_arr[1]);
                LC_1.BeginUpdate();
                LC_1.ViewXY.XAxes[0].SetRange(min_border - 3, max_border + 3);
                LC_1.EndUpdate();
            }

        }
        /// <summary>
        /// BUTTON unckeck all fit nodes 
        /// </summary>
        private void uncheckFit_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Sets check-state to unchecked in all solutions of each fit group and  all fragments in the Fragment List", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            uncheck_all(fit_tree, false);
        }
        /// <summary>
        /// BUTTON select best fit solution in each fit group 
        /// </summary>
        private void check_bestBtn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Select best n fit solutions in each fit group. The amount n is specified in 'Sort Settings' panel.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
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
                fit_tree.BeginUpdate(); frag_tree.BeginUpdate();
                block_plot_refresh = true; block_fit_refresh = true;
                foreach (TreeNode node in tree.Nodes)
                {
                    if (node.Checked != check) node.Checked = check;
                    foreach (TreeNode nn in node.Nodes)
                    {
                        if (nn.Checked != check) nn.Checked = check;
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
                fit_tree.BeginUpdate(); frag_tree.BeginUpdate();
                if (best_num_results == 1)
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
                    int best1 = best_num_results - 1;
                    if (individual && fit_tree.Nodes.Count > node_index && fit_tree.Nodes[node_index].Nodes.Count > 0)
                    {
                        if (fit_tree.Nodes[node_index].Nodes.Count < best_num_results) { best1 = fit_tree.Nodes[node_index].Nodes.Count - 1; }
                        for (int i = best1; i > -1; i--)
                        {
                            fit_tree.Nodes[node_index].Nodes[i].Checked = true;
                        }
                    }
                    else
                    {
                        foreach (TreeNode node in fit_tree.Nodes)
                        {
                            best1 = best_num_results - 1;
                            if (node.Nodes.Count > 0)
                            {
                                if (node.Nodes.Count < best_num_results) { best1 = node.Nodes.Count - 1; }

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
            if (help_Btn.Checked) { MessageBox.Show("Shows the fitting settings dialog. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            Fit_set_Form fit_settings = new Fit_set_Form();
            fit_settings.FormClosed += (s, f) => { save_preferences(); };
            fit_settings.ShowDialog();
        }
        //FIT CHECKED GROUPS
        /// <summary>
        /// fit checked groups' fragments in a common fit group, the new fit group can contain either all the fragments in the checked fit groups(all_frag=true) or only the checked fragments in the checked fit groups(all_frag=false)
        /// </summary>
        private void fit_checked_groups(bool all_frag = true)
        {
            if (is_frag_calc_recalc || (statusStrp.Visible && progressLabel.Text == "Preparing data for fit...")) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            if (fit_tree== null || experimental.Count==0 ) { MessageBox.Show("Oops...there aren't any fit results to perform fit! Use this button when you want to perform an additional fitting to specific nodes of the 'Fit results'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else
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
                if (frgmts.Count > 12) { MessageBox.Show("Oops...the maximum amount of fragments in each group iteration is 12!\r\nPlease try again with fewer or smaller fit groups.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (frgmts.Count > 11) { DialogResult dialogResult = MessageBox.Show("Hmm...Τhe process takes about 8 minutes to complete.\r\nAre you sure you would like to continue?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand); if (dialogResult != DialogResult.OK) { return; } }
                if (frgmts.Count > 10) { DialogResult dialogResult = MessageBox.Show("Hmm...Τhe process takes about 4 minutes to complete.\r\nAre you sure you would like to continue?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand); if (dialogResult != DialogResult.OK) { return; } }
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
                tab_thres.Insert(grp_nodes[0], new double[] { fit_thres[0], fit_thres[1], fit_thres[2], fit_thres[3], fit_thres[4], fit_thres[5], fit_thres[6] });
                tab_coef.Insert(grp_nodes[0], new double[] { a_coef[0], a_coef[1], a_coef[2], a_coef[3], a_coef[4], a_coef[5] });
                labels_checked.Insert(grp_nodes[0], "");
                int counter = 0;
                foreach (int g in grp_nodes)
                {
                    fit_tree.Nodes.RemoveAt(g - counter); counter++;
                }
                fit_tree.BeginUpdate();
                TreeNode node_new = new TreeNode();
                int[] longest = set.OrderBy(x => x.Length).Last();
                node_new.Text = Fragments2[longest.First() - 1].Mz + " - " + Fragments2[longest.Last() - 1].Mz;

                for (int j = 0; j < res.Count; j++)
                {
                    if (res[j][res[j].Length - 2] < fit_thres[0] && res[j][res[j].Length - 1] < fit_thres[1] && res[j][res[j].Length - 4] < fit_thres[2] && res[j][res[j].Length - 5] < fit_thres[3] && res[j][res[j].Length - 6] < fit_thres[4])
                    {
                        bool print = true;
                        for (int k = 0; k < set[j].Length; k++)
                        {
                            if (res[j][k + set[j].Length] > fit_thres[2] || res[j][k + 3 * set[j].Length] > fit_thres[3] || res[j][k + 4 * set[j].Length] > fit_thres[4] || res[j][k + 2 * set[j].Length] > fit_thres[5] || res[j][k + 5 * set[j].Length] > fit_thres[6]) { print = false; }
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
                for (int k = grp_nodes[0] + 1; k < fit_tree.Nodes.Count; k++)
                {
                    foreach (TreeNode nn in fit_tree.Nodes[k].Nodes)
                    {
                        string[] idx_str_arr = nn.Name.Split(' ');
                        int set_idx = Convert.ToInt32(idx_str_arr[0]);      // identifies the set or group of ions
                        nn.Name = (set_idx - grp_nodes.Count() + 1).ToString() + " " + idx_str_arr[1];
                    }
                }
                fit_tree.EndUpdate();
                remove_child_nodes();
                if (fit_tree.Nodes[grp_nodes[0]].Nodes.Count > 0) { fit_tree.Nodes[grp_nodes[0]].Nodes[0].EnsureVisible(); fit_tree.Nodes[grp_nodes[0]].Nodes[0].Checked = true; }
            }            
        }
        private void fit_chkGrpsBtn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show( "Fits the checked groups of the fit results and creates one merged group with all the fragments that were included in the previous groups.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            fit_checked_groups();
        }
        private void fit_chkGrpsChkFragBtn_Click_1(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Fits the checked Fragments in the checked groups of the fit results and creates one merged group with the checked fragments that were included in the previous groups.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            fit_checked_groups(false);
        }
        
        #endregion       

        #region LICHTNING CHART
        private void init_chart()
        {
            if (LC_1 != null)
            {
                LC_1.Dispose();
            }
            LC_1 = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { Dock = DockStyle.Fill, ColorTheme = ColorTheme.LightGray, BackColor = Color.White };
            LC_1.BeginUpdate();
            ViewXY v = LC_1.ViewXY;
            LC_1.Background = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            v.GraphBackground = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            LC_1.Parent = this;
            LC_1.Title.Visible = false;
            LC_1.ViewXY.LegendBox.Visible = false;
            LC_1.ViewXY.ZoomPanOptions.RightToLeftZoomAction = RightToLeftZoomActionXY.PopFromZoomStack;
            LC_1.ViewXY.ZoomPanOptions.AxisMouseWheelAction = AxisMouseWheelAction.PanAll;
            AxisX axisX_1 = LC_1.ViewXY.XAxes[0];
            AxisY axisY_1 = LC_1.ViewXY.YAxes[0];
            axisX_1.ValueType = AxisValueType.Number;
            axisX_1.AutoFormatLabels = false;
            axisX_1.LabelsNumberFormat = x_format + x_numformat;
            axisX_1.Title.Text = "m/z"; axisY_1.Title.Text = "Intensity";
            axisX_1.Title.MouseInteraction = false; axisY_1.Title.MouseInteraction = false;
            LC_1.Name = "iso_plot1";
            LC_1.ViewXY.LegendBox.Visible = false;
            LC_1.ViewXY.LegendBox.ShowCheckboxes = true;
            LC_1.ViewXY.LegendBox.Layout = LegendBoxLayout.VerticalColumnSpan;
            axisX_1.ScrollMode = XAxisScrollMode.None;
            axisX_1.MajorGrid.Visible = Xmajor_grid; axisX_1.MajorGrid.Pattern = LinePattern.Solid;
            axisX_1.MinorGrid.Visible = Xminor_grid; axisX_1.MinorGrid.Pattern = LinePattern.Solid;
            axisY_1.MajorGrid.Visible = Ymajor_grid; axisY_1.MajorGrid.Pattern = LinePattern.Solid;
            axisY_1.MinorGrid.Visible = Yminor_grid; axisY_1.MinorGrid.Pattern = LinePattern.Solid;
            axisY_1.ValueType = AxisValueType.Number;
            axisY_1.AutoFormatLabels = false;
            //axisY_1.AllowAutoYFit = false;
            //axisY_1.LabelsNumberFormat = "0.0E+0";
            axisY_1.LabelsNumberFormat = y_format + y_numformat;


            //Add a line series cursor 
            LineSeriesCursor cursor_1 = new LineSeriesCursor(LC_1.ViewXY, axisX_1);
            cursor_1.SnapToPoints = false;

            // Create secondary axes, to show cursor intersections on axes by using their CustomAxisTicks with one value only. 
            //The CustomAxisTick gets intersection value, nothing else, and shows a major tick, label and grid line on that position.

            //Disable automatic axis placement, so that the axes are in same positions (Position = 0 for YAxes, Position = 100 for XAxes); 
            v.AxisLayout.YAxisAutoPlacement = YAxisAutoPlacement.LeftThenRight;
            v.AxisLayout.XAxisAutoPlacement = XAxisAutoPlacement.BottomThenTop;

            AxisX secondaryXAxis = new AxisX(v);
            secondaryXAxis.MouseInteraction = false;
            secondaryXAxis.AutoFormatLabels = false;
            secondaryXAxis.CustomTicksEnabled = true;
            secondaryXAxis.AxisColor = Color.Transparent;
            secondaryXAxis.MajorGrid.Color = LC_1.Title.Color;
            secondaryXAxis.LabelsColor = Color.DarkRed;
            secondaryXAxis.Title.Visible = false;
            secondaryXAxis.MajorDivTickStyle.Color = Color.DarkRed;
            secondaryXAxis.LabelsFont = new Font("Segoe UI", 10f, FontStyle.Regular);
            secondaryXAxis.MouseScaling = false;
            v.XAxes.Add(secondaryXAxis);

            AxisY secondaryYAxis = new AxisY(v);
            secondaryYAxis.MouseInteraction = false;
            secondaryYAxis.AutoFormatLabels = false;
            secondaryYAxis.CustomTicksEnabled = true;
            secondaryYAxis.AxisColor = Color.Transparent;
            secondaryYAxis.MajorGrid.Color = LC_1.Title.Color;
            secondaryYAxis.LabelsColor = Color.DarkRed;
            secondaryYAxis.Title.Visible = false;
            secondaryYAxis.MajorDivTickStyle.Color = Color.DarkRed;
            secondaryYAxis.LabelsFont = new Font("Segoe UI", 10f, FontStyle.Regular);
            secondaryYAxis.MouseScaling = false;
            v.YAxes.Add(secondaryYAxis);
            LC_1.EndUpdate();
            fit_grpBox.Controls.Add(LC_1);

            if (LC_2 != null)
            {
                LC_2.Dispose();
            }
            LC_2 = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { Dock = DockStyle.Fill, ColorTheme = ColorTheme.LightGray };
            LC_2.BeginUpdate();
            LC_2.Background = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            LC_2.ViewXY.GraphBackground = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            LC_2.Parent = this;
            LC_2.Title.Visible = false;
            LC_2.ViewXY.LegendBox.Visible = false;
            AxisX axisX_2 = LC_2.ViewXY.XAxes[0];
            AxisY axisY_2 = LC_2.ViewXY.YAxes[0];
            axisX_2.ValueType = AxisValueType.Number;
            axisX_2.AutoFormatLabels = false;
            axisX_2.LabelsNumberFormat = x_format + x_numformat;
            axisX_2.Title.Text = "m/z"; axisY_2.Title.Text = "Intensity";
            axisX_2.Title.MouseInteraction = false; axisY_2.Title.MouseInteraction = false;
            LC_2.Name = "res_plot1";
            LC_2.ViewXY.LegendBox.Visible = false;
            LC_2.ViewXY.LegendBox.ShowCheckboxes = true;
            LC_2.ViewXY.LegendBox.Layout = LegendBoxLayout.Vertical;
            axisX_2.ScrollMode = XAxisScrollMode.None;
            axisX_2.MajorGrid.Visible = Xmajor_grid; axisX_2.MajorGrid.Pattern = LinePattern.Solid;
            axisX_2.MinorGrid.Visible = Xminor_grid; axisX_2.MinorGrid.Pattern = LinePattern.Solid;
            axisY_2.MajorGrid.Visible = Ymajor_grid; axisY_2.MajorGrid.Pattern = LinePattern.Solid;
            axisY_2.MinorGrid.Visible = Yminor_grid; axisY_2.MinorGrid.Pattern = LinePattern.Solid;
            axisX_2.ValueType = AxisValueType.Number;
            axisY_2.AutoFormatLabels = false;
            //axisY_2.LabelsNumberFormat = "0.0E+0";
            axisY_2.LabelsNumberFormat = y_format + y_numformat;
            //axisY_2.AllowAutoYFit = false;

            LineSeriesCursor cursor_2 = new LineSeriesCursor(LC_2.ViewXY, axisX_2);
            cursor_2.SnapToPoints = false;
            LC_2.EndUpdate();
            res_grpBox.Controls.Add(LC_2);

            axisX_1.RangeChanged += xAxis_RangeChanged;
            axisY_1.RangeChanged += yAxis_RangeChanged;
            LC_2.ViewXY.XAxes[0].RangeChanged += LC_2xAxis_RangeChanged;
            LC_1.MouseMove += new MouseEventHandler(_chart_MouseMove);
            LC_1.MouseDoubleClick += (s, e) => { v.ZoomToFit(); if (autoscale_Btn.Checked) { xAxis_fox_yAxis(LC_1.ViewXY.XAxes[0].Minimum, LC_1.ViewXY.XAxes[0].Maximum); } };
            LC_1.MouseDown += new MouseEventHandler(_chart_MouseDown);
        }
        private void LC_2xAxis_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            //Set the same range for secondary Y axis
            e.CancelRendering = true;
            LC_2.BeginUpdate();
            bool scaleChanged = false;
            try
            {
                LC_2.ViewXY.YAxes[0].Fit(10.0, out scaleChanged, true, false);
            }
            catch
            {
                LC_2.EndUpdate();
                return;
            }
            LC_2.EndUpdate();
        }
        private void yAxis_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            //Set the same range for secondary Y axis
            e.CancelRendering = true;
            LC_1.BeginUpdate();
            try
            {
                LC_1.ViewXY.YAxes[1].SetRange(e.NewMin, e.NewMax);
            }
            catch
            {
                LC_1.EndUpdate();
                return;
            }
            LC_1.EndUpdate();
        }
        private void xAxis_RangeChanged(object sender, RangeChangedEventArgs e)
        {
            //Set the same range for secondary X axis
            e.CancelRendering = true;
            double x_min = e.NewMin;
            double x_max = e.NewMax;
            try
            {
                xAxis_fox_yAxis(e.NewMin, e.NewMax);
            }
            catch
            {
                LC_1.EndUpdate();
                LC_2.EndUpdate();
            }
        }
        private void xAxis_fox_yAxis(double x_min, double x_max)
        {
            LC_1.BeginUpdate();
            LC_2.BeginUpdate();
            LC_1.ViewXY.XAxes[1].SetRange(x_min, x_max);
            LC_2.ViewXY.XAxes[0].SetRange(x_min, x_max);
            if (autoscale_Btn.Checked)
            {
                if (all_data.Count > 0 /*&& Fragments2.Count > 0*/)
                {
                    double y_max = return_Yaxis_range(x_min, x_max);
                    if (y_max > 0)
                    {
                        LC_1.ViewXY.YAxes[0].SetRange(-0.2 * y_max, 1.2 * y_max);
                    }
                    else
                    {
                        bool bChanged = false;
                        LC_1.ViewXY.YAxes[0].Fit(10.0, out bChanged, true, false);
                    }
                }
                else
                {
                    bool bChanged = false;
                    LC_1.ViewXY.YAxes[0].Fit(10.0, out bChanged, true, false);
                }
            }
            LC_1.EndUpdate();
            LC_2.EndUpdate();
        }
        private void _chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursor_chkBx.Checked/* && !count_distance*/)
            {
                CreateProjections((int)e.X, (int)e.Y);
                if (count_distance)
                {
                    if (LC_1.ViewXY.Bands.Count > 0)
                    {
                        double x;
                        LC_1.ViewXY.XAxes[0].CoordToValue(e.X, out x, false);
                        LC_1.ViewXY.Bands[0].ValueEnd = x;
                    }
                }                          
            }
        }
        private void _chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (cursor_chkBx.Checked && e.Button == MouseButtons.Left)
            {
                //// Remove exsisting custom x - axis tickmarks
                //DisposeAllAndClear(LC_1.ViewXY.XAxes[1].CustomTicks);
                //LC_1.ViewXY.XAxes[1].InvalidateCustomTicks();

                ////Remove exsisting custom y-axis tickmarks
                //DisposeAllAndClear(LC_1.ViewXY.YAxes[1].CustomTicks);
                //LC_1.ViewXY.YAxes[1].InvalidateCustomTicks();
                LC_1.BeginUpdate();
                count_distance = true;
                cursor_distance(e.X);
                LC_1.EndUpdate();
            }
            else if (e.Button == MouseButtons.Right) { DisposeAllAndClear(LC_1.ViewXY.Bands); count_distance = false; }
        }
        private void CreateProjections(int pX, int pY)
        {
            double x, y;
            LC_1.ViewXY.XAxes[0].CoordToValue(pX, out x, false);
            LC_1.ViewXY.YAxes[0].CoordToValue(pY, out y);
            AxisX secondaryXAxis = LC_1.ViewXY.XAxes[1];
            AxisY secondaryYAxis = LC_1.ViewXY.YAxes[1];
            //Disable rendering
            LC_1.BeginUpdate();
            //Remove exsisting custom x-axis tickmarks
            DisposeAllAndClear(secondaryXAxis.CustomTicks);
            secondaryXAxis.CustomTicks.Add(new CustomAxisTick(secondaryXAxis, x, x.ToString("0.000"), 10, true, Color.DarkRed, CustomTickStyle.TickAndGrid));
            secondaryXAxis.InvalidateCustomTicks();
            //Remove exsisting custom y-axis tickmarks
            DisposeAllAndClear(secondaryYAxis.CustomTicks);
            secondaryYAxis.CustomTicks.Add(new CustomAxisTick(secondaryYAxis, y, y.ToString("0.000"), 10, true, Color.DarkRed, CustomTickStyle.TickAndGrid));
            secondaryYAxis.InvalidateCustomTicks();
            if ((frag_lbl_Btn.Checked ) && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked))
            {
                refresh_frag_annotation(LC_1);
            }
            //Allow rendering
            LC_1.EndUpdate();
        }
        public static void DisposeAllAndClear<T>(List<T> list)
        {
            if (list == null)
                return;

            foreach (IDisposable item in list)
            {
                if (item != null)
                    item.Dispose();
            }

            list.Clear();
        }
        //**********************
        private void refresh_iso_plot()
        {
            if (is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            //Remove existing series
            DisposeAllAndClear(LC_1.ViewXY.PointLineSeries);
            DisposeAllAndClear(LC_1.ViewXY.BarSeries);
            DisposeAllAndClear(LC_1.ViewXY.LineCollections);
            DisposeAllAndClear(LC_2.ViewXY.PointLineSeries);
            DisposeAllAndClear(LC_2.ViewXY.BarSeries);

            LC_1.BeginUpdate();
            LC_2.BeginUpdate();
            //// 0.a gather info on which fragments are selected to plot, and their respective intensities
            //List<int> to_plot = selectedFragments.ToList(); // deep copy, don't mess selectedFragments
            List<int> to_plot = new List<int>();
            List<int> to_plot2 = new List<int>();
            string[] label_temp = label_frag.ToArray();
            string[] frag_temp =view_frag.ToArray();
            //0.a add only the desired fragments to to_plot
            if (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked || Fitting_chkBox.Checked)
            {
                foreach (int idx in selectedFragments)
                {
                    string ion = Fragments2[idx - 1].Ion_type;
                    if (ion.StartsWith("a") || ion.StartsWith("(a"))
                    {
                        if (frag_temp.Any(p => p.Equals("a"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("a"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                    {
                        if (frag_temp.Any(p => p.Equals("b"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("b"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                    {
                        if (frag_temp.Any(p => p.Equals("c"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("c"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                    {
                        if (frag_temp.Any(p => p.Equals("x"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("x"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                    {
                        if (frag_temp.Any(p => p.Equals("y"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("y"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                    {
                        if (frag_temp.Any(p => p.Equals("z"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("z"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("int") && ion.Contains("b"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal b"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal b"))) { to_plot2.Add(idx); } }
                    }
                    else if (!is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal a"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal a"))) { to_plot2.Add(idx); } }
                    }
                    else if (is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                    {
                        if (frag_temp.Any(p => p.Equals("d"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("d"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                    {
                        if (frag_temp.Any(p => p.Equals("w"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("w"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                    {
                        if (frag_temp.Any(p => p.Equals("v"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("v"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("M"))
                    {
                        if (frag_temp.Any(p => p.Equals("M"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("M"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("B("))
                    {
                        if (frag_temp.Any(p => p.Equals("B")) ) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("B"))) { to_plot2.Add(idx); } }
                    }
                    else
                    {
                        to_plot.Add(idx); to_plot2.Add(idx);
                    }

                }
            }

            // 0.b. reset iso plot
            reset_iso_plot();

            // 1.a rerun calculations for fit and residual

            recalculate_fitted_residual(to_plot);

            // 1.b Add the experimental to plot if selected

            if (plotExp_chkBox.Checked && all_data.Count > 0)
            {
                //if (!exp_deconvoluted)
                //{
                double[] mz = all_data[0].Select(a => a[0]).ToArray();
                double[] y = all_data[0].Select(a => a[1]).ToArray();
                PointLine_addSeries(LC_1, 0, mz, y, 1);
                //}
            }

            // 2. replot all isotopes
            if (plotFragProf_chkBox.Checked && all_data.Count > 1)
            {
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count > curr_idx)
                    {
                        double[] mz = all_data[curr_idx].Select(a => a[0]).ToArray();
                        double[] y = all_data[curr_idx].Select(a => a[1]).ToArray();
                        PointLine_addSeries(LC_1, curr_idx, mz, y, Fragments2[curr_idx - 1].Factor);
                    }
                }
                if (ExtraFragCalculator.now)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int curr_idx = Fragments2.Count + f + 1;
                        int frag = ExtraFragCalculator.last_plotted[f];
                        double[] mz = all_data[curr_idx].Select(a => a[0]).ToArray();
                        double[] y = all_data[curr_idx].Select(a => a[1]).ToArray();
                        PointLine_addSeries(LC_1, curr_idx, mz, y, ExtraFragCalculator.Fragments3[frag].Factor);
                    }
                }
            }
            if (plotFragCent_chkBox.Checked && all_data.Count > 1)
            {
                int help = Convert.ToInt32(ExtraFragCalculator.now);
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count > curr_idx)
                    {
                        List<PointPlot> cenn = Fragments2[curr_idx - 1].Centroid.OrderBy(p => p.X).ToList();
                        LineCollection_addLines1(LC_1, curr_idx - 1, cenn, Fragments2[curr_idx - 1].Factor);
                    }
                }
                if (ExtraFragCalculator.now)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int curr_idx = ExtraFragCalculator.last_plotted[f];
                        if (all_data.Count > 1)
                        {
                            // get name of each line to be ploted
                            string name_str = ExtraFragCalculator.Fragments3[curr_idx].Name;
                            List<PointPlot> cenn = ExtraFragCalculator.Fragments3[curr_idx].Centroid.OrderBy(p => p.X).ToList();
                            LineCollection_addLines1(LC_1, Fragments2.Count + f, cenn, ExtraFragCalculator.Fragments3[curr_idx].Factor);
                        }
                    }
                }
            }

            // 3. fitted plot
            if (summation.Count > 0 && Fitting_chkBox.Checked) PointLine_addSeries(LC_1, all_data.Count, summation);

            // 4. residual plot
            if (residual.Count > 0) PointLine_addSeries(LC_2, 0, residual);

            // 5. centroid (bar)
            if (plotCentr_chkBox.Checked /*&& !exp_deconvoluted*/ && peak_points.Count > 0 && all_data.Count > 0)
            {
                int pointCount = peak_points.Count;
                List<double[]> data_decon = new List<double[]>();
                for (int bar = 0; bar < pointCount; bar++)
                {
                    double[] peak = peak_points[bar];
                    double mz = peak[1] + peak[4];
                    double inten = peak[5];
                    data_decon.Add(new double[] { mz, inten });
                }
                LineCollection_addLines(LC_1, all_data.Count - 1, data_decon);
            }

            // 6. fragment annotations
            if (plotFragCent_chkBox.Checked || plotFragProf_chkBox.Checked)
            {
                // add only the desired fragments to to_plot              
                frag_annotation(to_plot2, LC_1);
            }
            else
            {
                DisposeAllAndClear(LC_1.ViewXY.Annotations);
            }
            LC_1.EndUpdate();
            LC_2.EndUpdate();
        }
        private void reset_iso_plot()
        {
            for (int i = 0; i < all_data.Count; i++)
            {
                Color cc;
                string name;
                float width;
                if (ExtraFragCalculator.now == true && i == all_data.Count - ExtraFragCalculator.last_plotted.Count)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int frag = ExtraFragCalculator.last_plotted[f];
                        cc = ExtraFragCalculator.Fragments3[frag].Color.ToColor();
                        name = ExtraFragCalculator.Fragments3[frag].Name;
                        width = (float)frag_width;
                        Init_PointLineSeries(LC_1, name, cc, width, frag_style);
                    }
                    break;
                }
                else
                {
                    cc = get_fragment_color1(i);

                    if (i == 0) // experimental
                    {
                        name = "exp";
                        width = (float)exp_width;
                        Init_PointLineSeries(LC_1, name, cc, width, exper_style);
                    }
                    else
                    {
                        name = Fragments2[i - 1].Name;
                        width = (float)frag_width;
                        Init_PointLineSeries(LC_1, name, cc, width, frag_style);
                    }
                }
            }

            for (int i = 1; i < all_data.Count; i++)
            {
                if (ExtraFragCalculator.now == true && i == all_data.Count - ExtraFragCalculator.last_plotted.Count)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int frag = ExtraFragCalculator.last_plotted[f];
                        Color cc = ExtraFragCalculator.Fragments3[frag].Color.ToColor();                      
                        Init_LineCollection_Plot(LC_1, ExtraFragCalculator.Fragments3[frag].Name, cc, (int)cen_width);
                    }
                    break;
                }
                else
                {
                    Color cc = get_fragment_color1(i);                  
                    Init_LineCollection_Plot(LC_1, Fragments2[i - 1].Name, cc, (int)cen_width);
                }
            }
            if (insert_exp == true)
            {
                Init_PointLineSeries(LC_1, "fit", fit_color.ToColor(), (float)fit_width, fit_style);
                Init_PointLineSeries(LC_2, "res", Color.Black, 1, LinePattern.Solid);
            }
            if (plotCentr_chkBox.Checked)
            {                
                Init_LineCollection_Plot(LC_1, "exp", peak_color.ToColor(), (int)peak_width);
            }
        }
        private void recalculate_fitted_residual(List<int> to_plot)
        {
            // calculate addition of selected fragments, and the respective residual
            // it is always called on every refresh of the plot 
            // if it is called from a selected fit change, no need to seek info from fit results. Results are already on the UI (checkbox.checked, and factor textBox)
            // to_plot and UI_intensities may also contain experimental index that is not necessary for sum or residual and has to be removed for coding brevity

            //sw3.Reset();  sw2.Reset(); sw1.Reset(); 
            List<int> plot_idxs = new List<int>(to_plot);

            // When ONE fragment is checked/unchecked do NOT recalculate ALL fragments. Just add/subtract the checked/uncheked
            if (Math.Abs(last_ploted_iso.Count - to_plot.Count) == 1)
            {
                //sw2.Start();
                int operand = 1;
                int diff = to_plot.Except(last_ploted_iso).ToList().FirstOrDefault();

                if (last_ploted_iso.Count - to_plot.Count == 1)
                {
                    operand = -1;
                    diff = last_ploted_iso.Except(to_plot).ToList().FirstOrDefault();
                }

                for (int i = 0; i < all_data_aligned.Count(); i++)
                {
                    if (all_data_aligned[i][diff] > 0)
                    {
                        double change = operand * all_data_aligned[i][diff] * Fragments2[diff - 1].Factor;
                        summation[i][1] += change;
                        residual[i][1] -= change;
                    }
                }

                last_ploted_iso = new List<int>(to_plot);
                //sw2.Stop(); Console.WriteLine("single frag change: " + sw2.ElapsedMilliseconds.ToString());
                return;
            }

            //sw1.Start();
            // 1. calculate addition of fragments and residual
            // This is the case when MANY fragments are selected/unselected. 
            // a. Major improvement from skiping calculations for zeros (reduce time by 60%). 
            // b. multi-thread (reduce time by 60%)
            summation.Clear();
            residual.Clear();

            double[][] summation_temp = new double[all_data_aligned.Count][];
            double[][] residual_temp = new double[all_data_aligned.Count][];

            Parallel.For(0, all_data_aligned.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
            {
                double intensity = 0.0;
                for (int j = 0; j < plot_idxs.Count; j++)
                    if (all_data_aligned[i][plot_idxs[j]] > 0)
                        intensity += all_data_aligned[i][plot_idxs[j]] * Fragments2[plot_idxs[j] - 1].Factor;       // all_data_alligned contain experimental, Fragments2 are one idx position back

                if (ExtraFragCalculator.now)
                {
                    int count = all_data_aligned[i].Count();
                    int count_last_plot = ExtraFragCalculator.last_plotted.Count;
                    for (int extras = 0; extras < count_last_plot; extras++)
                        if (all_data_aligned[i][count - extras - 1] > 0)
                            intensity += all_data_aligned[i][count - extras - 1] * ExtraFragCalculator.Fragments3[ExtraFragCalculator.last_plotted[count_last_plot - extras - 1]].Factor;
                }

                summation_temp[i] = new double[] { all_data[0][i][0], intensity };
                residual_temp[i] = new double[] { all_data[0][i][0], all_data[0][i][1] - intensity };
            });

            summation = summation_temp.ToList();
            residual = residual_temp.ToList();

            last_ploted_iso = new List<int>(to_plot);
            //sw1.Stop(); Console.WriteLine("Total compute Parallel: " + sw1.ElapsedMilliseconds.ToString()); sw1.Reset();
        }
        //**********************

        private Color get_fragment_color1(int idx)
        {
            //idx is the all_data structure index not the Fragments2 index
            Color clr = Color.FromArgb(custom_colors[idx]);
            return clr;
        }
        private void Init_PointLineSeries(LightningChartUltimate LC, string name, Color color, float width, LinePattern style)
        {
            PointLineSeries pls = new PointLineSeries(LC.ViewXY, LC.ViewXY.XAxes[0], LC.ViewXY.YAxes[0])
            {
                Visible = false,
                PointsVisible = false,
                IndividualPointColoring = PointColoringTarget.Off,
                MouseHighlight = MouseOverHighlight.None,
                MouseInteraction = false,
                Title = new SeriesTitle { Text = name },
                LineStyle = new Arction.WinForms.Charting.LineStyle() { Pattern = style, Color = color, Width = width, AntiAliasing = LineAntialias.None }
            };
            LC.ViewXY.PointLineSeries.Add(pls);
        }
        private void PointLine_addSeries(LightningChartUltimate LC, int index, List<double[]> data)
        {
            try
            {
                int pointCount = data.Count;
                SeriesPoint[] points = new SeriesPoint[pointCount];
                for (int i = 0; i < pointCount; i++)
                    points[i] = new SeriesPoint(data[i][0], data[i][1]);
                if (LC.ViewXY.PointLineSeries.Count> index)
                {
                    LC.ViewXY.PointLineSeries[index].Points = points;
                    LC.ViewXY.PointLineSeries[index].Visible = true;
                }                
            }
            catch(Exception eeee)
            {
                MessageBox.Show("Oops an error occurred while refreshing the basic plot. Please try again.\r\n\r\n Error:\r\n" + eeee.ToString());
            }           
        }
        private void PointLine_addSeries(LightningChartUltimate LC, int index, double[] mz, double[] y, double y_factor)
        {
            try
            {
                int pointCount = mz.Length;
                SeriesPoint[] points = new SeriesPoint[pointCount];
                for (int i = 0; i < pointCount; i++)
                    points[i] = new SeriesPoint(mz[i], y_factor * y[i]);
                if (LC.ViewXY.PointLineSeries.Count > index)
                {
                    LC.ViewXY.PointLineSeries[index].Points = points;
                    LC.ViewXY.PointLineSeries[index].Visible = true;
                }
            }
            catch (Exception eeee)
            {
                MessageBox.Show("Oops an error occurred while refreshing the basic plot. Please try again.\r\n\r\n Error:\r\n" + eeee.ToString());
            }
        }
        private void Init_LineCollection_Plot(LightningChartUltimate LC, string title, Color color, float width)
        {
            LineCollection lineCollection = new LineCollection(LC.ViewXY, LC.ViewXY.XAxes[0], LC.ViewXY.YAxes[0])
            {
                Visible = false,
                MouseHighlight = MouseOverHighlight.None,
                MouseInteraction = false,
                Title = new SeriesTitle { Text = title },
                LineStyle = new Arction.WinForms.Charting.LineStyle { Pattern = LinePattern.Solid, Color = color, Width = width, AntiAliasing = LineAntialias.None }
            };

            LC.ViewXY.LineCollections.Add(lineCollection);
        }
        private void LineCollection_addLines(LightningChartUltimate LC, int index, List<double[]> data)
        {
            SegmentLine[] segmentLines = new SegmentLine[data.Count()];
            for (int i = 0; i < data.Count(); i++)
                segmentLines[i] = new SegmentLine(data[i][0], 0, data[i][0], data[i][1]);
            if (LC.ViewXY.LineCollections.Count>index)
            {
                LC.ViewXY.LineCollections[index].Lines = segmentLines;
                LC.ViewXY.LineCollections[index].Visible = true;
            }            
        }
        private void LineCollection_addLines1(LightningChartUltimate LC, int index, List<PointPlot> data, double factor)
        {
            SegmentLine[] segmentLines = new SegmentLine[data.Count()];

            for (int i = 0; i < data.Count(); i++)
                segmentLines[i] = new SegmentLine(data[i].X, 0, data[i].X, data[i].Y * factor);
            if (LC.ViewXY.LineCollections.Count>index)
            {
                LC.ViewXY.LineCollections[index].Lines = segmentLines;
                LC.ViewXY.LineCollections[index].Visible = true;
            }         
        }
        private void cursor_distance(int pX)
        {
            double x;
            LC_1.ViewXY.XAxes[0].CoordToValue(pX, out x, false);
            if (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked || plotExp_chkBox.Checked || plotCentr_chkBox.Checked)
            {
                DisposeAllAndClear(LC_1.ViewXY.Bands);
                Band band2 = new Band(LC_1.ViewXY, LC_1.ViewXY.XAxes[0], LC_1.ViewXY.YAxes[0]);
                band2.Binding = AxisBinding.XAxis;
                band2.Fill.Color = Color.FromArgb(50, Color.Orange);
                band2.Fill.GradientColor = Color.FromArgb(50, ChartTools.CalcGradient(band2.Fill.Color, Color.White, 50));
                band2.Fill.GradientDirection = 270;
                band2.BorderWidth = 0;
                band2.ValueBegin = x;
                band2.ValueEnd = x;
                band2.Behind = true;
                band2.Title.Text = "Distance: " + Math.Round(Math.Abs(band2.ValueEnd - band2.ValueBegin), 4).ToString();
                band2.Title.Visible = true;
                band2.Title.Angle = 0;
                band2.Title.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                band2.Title.Color = Color.Black;
                band2.Title.HorizontalAlign = AlignmentHorizontal.Center;
                band2.Title.VerticalAlign = AlignmentVertical.Top;
                band2.Visible = true;
                band2.ValuesChanged += (s, e) => { band2.Title.Text = "Distance: " + Math.Round(Math.Abs(band2.ValueEnd - band2.ValueBegin), 4).ToString(); };
                LC_1.ViewXY.Bands.Add(band2);
            }
        }       
        private void frag_annotation(List<int> to_plot, LightningChartUltimate plot)
        {
            if ((frag_lbl_Btn.Checked) && (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked))
            {
                List<int> plot_idxs = new List<int>(to_plot);
                plot.BeginUpdate();
                DisposeAllAndClear(plot.ViewXY.Annotations);
                foreach (int p in plot_idxs)
                {
                    if ((frag_lbl_Btn.Checked && !Fragments2[p - 1].Ion_type.StartsWith("inte")) || (Fragments2[p - 1].Ion_type.StartsWith("inte")))
                    {
                        //Arrow from location to target
                        AnnotationXY annotAxisValues2 = new AnnotationXY(plot.ViewXY, plot.ViewXY.XAxes[0], plot.ViewXY.YAxes[0]) { MouseInteraction = false };
                        annotAxisValues2.Style = AnnotationStyle.Arrow;
                        annotAxisValues2.LocationCoordinateSystem = CoordinateSystem.RelativeCoordinatesToTarget;
                        annotAxisValues2.TargetCoordinateSystem = AnnotationTargetCoordinates.AxisValues;
                        annotAxisValues2.Text = Fragments2[p - 1].Name.ToString();
                        annotAxisValues2.TargetAxisValues.X = Fragments2[p - 1].Centroid[0].X;
                        annotAxisValues2.TargetAxisValues.Y = Fragments2[p - 1].Centroid[0].Y * Fragments2[p - 1].Factor;
                        annotAxisValues2.LocationAxisValues.X = Fragments2[p - 1].Centroid[0].X;
                        annotAxisValues2.LocationAxisValues.Y = Fragments2[p - 1].Centroid[0].Y * Fragments2[p - 1].Factor;
                        annotAxisValues2.TextStyle = new AnnotationTextStyle() { Shadow = new TextShadow() { Style = TextShadowStyle.Off }, Color = Fragments2[p - 1].Color.ToColor(), VerticalAlign = AlignmentVertical.Bottom, HorizAlign = AlignmentHorizontal.Right };
                        annotAxisValues2.ArrowLineStyle = new Arction.WinForms.Charting.LineStyle() { Color = Color.Transparent, Width = (float)0.5 };
                        annotAxisValues2.RotateAngle = 90;
                        annotAxisValues2.TextStyle.Font = new Font(FontFamily.GenericSansSerif, (float)annotation_size, FontStyle.Regular);
                        plot.ViewXY.Annotations.Add(annotAxisValues2);
                    }
                }
                plot.EndUpdate();
            }
        }
        private void refresh_frag_annotation(LightningChartUltimate plot)
        {
            plot.BeginUpdate();
            foreach (AnnotationXY annotAxisValues2 in plot.ViewXY.Annotations)
            {
                //Arrow from location to target                
                annotAxisValues2.TargetAxisValues.X = annotAxisValues2.TargetAxisValues.X;
                annotAxisValues2.LocationAxisValues.X = annotAxisValues2.LocationAxisValues.X;
            }
            plot.EndUpdate();
        }
        private void cursor_chkBx_CheckStateChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Sets mouse tool to label exact points coordinates in the spectrum area.\r\nWith left click sets mouse tool as a ruler to measure distances in a spectrum, with right click the ruler vanishes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            // 
            if (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked || plotExp_chkBox.Checked || plotCentr_chkBox.Checked)
            {
                // Remove exsisting custom x - axis tickmarks
                DisposeAllAndClear(LC_1.ViewXY.XAxes[1].CustomTicks);
                LC_1.ViewXY.XAxes[1].InvalidateCustomTicks();

                //Remove exsisting custom y-axis tickmarks
                DisposeAllAndClear(LC_1.ViewXY.YAxes[1].CustomTicks);
                LC_1.ViewXY.YAxes[1].InvalidateCustomTicks();
                DisposeAllAndClear(LC_1.ViewXY.Bands);
                count_distance = false;
            }
            else cursor_chkBx.Checked = false;
        }
        private double return_Yaxis_range(double x_min, double x_max)
        {
            double Y_max = 0.0;
            string[] frag_temp = view_frag.ToArray();

            //the desired fragments to to_plot
            if (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked)
            {
                foreach (int idx in selectedFragments)
                {
                    FragForm fra = Fragments2[idx - 1];
                    string ion = Fragments2[idx - 1].Ion_type;
                    if (ion.StartsWith("a") || ion.StartsWith("(a"))
                    {
                        if (frag_temp.Any(p => p.Equals("a"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max);  }
                    }
                    else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                    {
                        if (frag_temp.Any(p => p.Equals("b"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                    {
                        if (frag_temp.Any(p => p.Equals("c"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                    {
                        if (frag_temp.Any(p => p.Equals("x"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                    {
                        if (frag_temp.Any(p => p.Equals("y"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                    {
                        if (frag_temp.Any(p => p.Equals("z"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.Contains("int") && ion.Contains("b"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal b"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (!is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal a"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                    {
                        if (frag_temp.Any(p => p.Equals("d"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                    {
                        if (frag_temp.Any(p => p.Equals("w"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                    {
                        if (frag_temp.Any(p => p.Equals("v"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.Contains("M"))
                    {
                        if (frag_temp.Any(p => p.Equals("M"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else if (ion.Contains("B("))
                    {
                        if (frag_temp.Any(p => p.Equals("B"))) { max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max); }
                    }
                    else
                    {
                        max_min_Y_frag(out Y_max, Y_max, fra, x_min, x_max);
                    }

                }
            }
            //the experimental
            if ((plotExp_chkBox.Checked || plotCentr_chkBox.Checked) && peak_points.Count > 0)
            {
                for (int k = 0; k < peak_points.Count; k++)
                {
                    double[] peak = peak_points[k];
                    double mz = peak[1] + peak[4];
                    double inten = peak[5];
                    if (mz < x_min || mz > x_max || inten < Y_max) { continue; }
                    else { Y_max = inten; }
                }
            }
            return Y_max;
        }
        private void max_min_Y_frag(out double Y_max,double y_max, FragForm fra, double x_min, double x_max)
        {
            Y_max = y_max;
            if (fra.Profile.First().X > x_max || fra.Profile.Last().X < x_min) {  return; }
            for (int p = 0; p < fra.Centroid.Count; p++)
            {
                double inten = fra.Factor * fra.Centroid[p].Y;
                double mz = fra.Centroid[p].X;
                if (mz > x_max || mz < x_min || inten < Y_max) { continue; }               
                else { Y_max = inten; break; }
            }
        }
        #endregion

        #region Toolbar control
       
        /// <summary>
        /// Display Progress Bar.
        /// </summary>
        private void progress_display_start(int barMax, string info)
        {
            statusStrp.Invoke(new Action(() => statusStrp.Visible = true));
            statusStrp.Invoke(new Action(() => progressLabel.Text = info));
            statusStrp.Invoke(new Action(() => ProgressBar.Maximum = barMax));
            statusStrp.Invoke(new Action(() => ProgressBar.Value = 0));       
        }

        private void progress_display_stop()
        {
            statusStrp.Invoke(new Action(() => statusStrp.Visible = false));  
        }

        private void progress_display_update(int idx)
        {
            statusStrp.Invoke(new Action(() => progressLabel.Invalidate()));
            statusStrp.Invoke(new Action(() => statusStrp.Visible = true));
            if (!statusStrp.Visible) { statusStrp.Invoke(new Action(() => statusStrp.Visible = true)); }
            if (idx <= ProgressBar.Maximum)
            {
                try
                {
                    statusStrp.Invoke(new Action(() => ProgressBar.Value = idx));
                }
                catch
                {
                    statusStrp.Invoke(new Action(() => ProgressBar.Value = ProgressBar.Maximum));
                }
            }
            else
            {
                Debug.WriteLine("TOOLPROGRESSERROR " + idx + " > " + ProgressBar.Maximum);
            }
            statusStrp.Invoke(new Action(() => statusStrp.Update()));   //thread safe call

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

            int starting_points_to_omit = 1;
            int progress = 0;
            Parallel.For(starting_points_to_omit, len - peak_width - 1, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
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
                        try
                        {
                            for (int j = i - peak_width + 1; j < i; j++)
                            {
                                if (j < 0) { if (diff_y[0] < 0) local_max = false; }
                                else
{
                                    try { if (diff_y[j] < 0) local_max = false; }
                                    catch (Exception e1) { Debug.WriteLine("j " + j + " i " + i + " length " + diff_y.Length + "    " + e1); };
                                }
                                
                            }                               

                            for (int j = i + 2; j < i + peak_width + 1; j++)
                            {
                                if (diff_y[j] > 0) local_max = false;
                            }
                        }
                        catch (Exception e1)
                        {
                            Debug.WriteLine(e1);
                        };

                    }
                    if (local_max)
                    {
                        double[] point = new double[8];
                        point[0] = i + 1;                           // index
                        point[1] = dataX[i + 1];                    // experimental mz
                        point[2] = dataY[i + 1];                    // experimental height

                        var pair = find_centroid(i + 1, dataX, dataY, dataX[i + 1] - dataX[i]);

                        point[3] = pair[0];             // resolution
                        point[4] = pair[1];             // adjusted relative mz
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
                try
                {
                    temp = dataY[idx + (i - 10)] - gauss_point;
                    func[0] += temp * temp;
                }
                catch (Exception e1)
                {
                    Debug.WriteLine("idx " + idx + " i " + i + " length " + dataY.Length + "    " + e1);
                }
            }
        }
        private void displayPeakList_btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Displays the experimental peak list. Peak list is created by detecting the centroids in the experimental bell shaped profiles.\r\nPeak list settings are accessed by the 'Settings' button. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (experimental.Count == 0 ) {  MessageBox.Show("Oops...it seems you forgot to load the experimental file!\r\nYou have to load the experimental data first and then view the experimental peaks!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;  }
            if(peak_points.Count == 0) { MessageBox.Show("The peak list is under construction. Please wait...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            display_peakList();
        }
        private void display_peakList()
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }
        private void settingsPeak_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows the experimental data settings dialog. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            Exp_set_Form frm8 = new Exp_set_Form(this, help_Btn.Checked);
            frm8.FormClosed += (s, f) => { save_preferences(); };
            frm8.ShowDialog();
        }

        #endregion

        #region Data manipulation
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
        private void reset_all()
        {
            //FormWindowState curr_state = this.WindowState;
            //Size curr_size = this.Size;

            //this.WindowState = FormWindowState.Normal;
            //this.Size = new Size(2200, 925);           

            Initialize_data_struct();
            Initialize_UI();
            init_chart();
            //Initialize_Oxy();
            initialize_tabs();

            //this.WindowState = curr_state;
            //this.Size = curr_size;
        }
        private void Initialize_data_struct()
        {
            aligned_intensities.Clear();
            all_data_aligned.Clear();
            //if (last_ploted_iso.Count > 0) last_ploted_iso.Clear();
            fitted_results.Clear();
            powerSet.Clear();
            powerSet_distroIdx.Clear();
            summation.Clear();
            residual.Clear();
            custom_colors.Clear();
            all_data.Clear();
            file_name = "";
            project_experimental = "";
            if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
            //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            fit_color = OxyColors.Black; exp_color = OxyColors.Black.ToColor().ToArgb();
            fit_style = LinePattern.Dot; exper_style = LinePattern.Solid; frag_style = LinePattern.Solid;
            exp_width = 1; frag_width = 2; fit_width = 1;
            //exp deconvoluted
            is_exp_deconvoluted = false;
            deconv_machine = "";
            is_deconv_const_resolution = false;
            experimental_dec = new List<List<double[]>>();
        }
        private void frags_maxFactor()
        {
            if (peak_points.Count > 0)
            {
                Parallel.ForEach<FragForm>(Fragments2, (fra) =>
                {
                    if (fra.maxFactor == 0)
                    {
                        double pt0 = 0.1 * max_exp;
                        double centroid = fra.Centroid[0].X;
                        int[] pair = new int[2];
                        pair = find_closest(centroid, peak_points, true);
                        pt0 = peak_points[pair[0]][5];
                        fra.maxFactor = pt0 / fra.Max_intensity;
                    }
                });
            }
        }

        #endregion

        #region Helpers    

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
                FormCollection fc = Application.OpenForms;
                bool open = false;
                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.Name == "Form21")
                    {
                        open = true; break;
                    }
                }
                // Determine the type being compared  //  Columns: 0:Ion type, 1:m/z, 2:charge ,3:Chemical Formula,4:factor,5:code,6:intensity
                if ((open && ColumnToSort == 3) || ColumnToSort == 0 || ColumnToSort == 4 || (ColumnToSort == 1 && !open))
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
        private void display_objects_memory()
        {
            Debug.WriteLine("Memory of experimental: " + estimate_memory(experimental).ToString());
            Debug.WriteLine("Memory of all_data: " + estimate_memory(all_data).ToString());
            Debug.WriteLine("Memory of all_data_aligned: " + estimate_memory(all_data_aligned).ToString());
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
        public void read_rtf_find_color(SequenceTab seq)
        {
            string rtf = seq.Rtf;
            string sequence = seq.Sequence;
            string color_section = "";
            string text_section = "";
            List<Color> color_table = new List<Color>();
            color_table.Add(Color.Black);
            int[] char_color = new int[sequence.Length];
            string[] str = rtf.Split('{');
            for (int k = 0; k < str.Length; k++)
            {
                if (str[k].Contains("colortbl"))
                {
                    color_section = str[k];
                }
                else if (str[k].Contains("\\pard"))
                {
                    text_section = str[k];
                }
            }
            if (string.IsNullOrEmpty(color_section)) return;
            string[] str2 = color_section.Split(';');
            if (str2.Length < 3) return;
            for (int c = 1; c < str2.Length - 1; c++)
            {
                string[] str3 = str2[c].Split('\\');
                if (str3.Length < 4) return;
                int r = Int32.Parse(str3[1].Substring(3));
                int g = Int32.Parse(str3[2].Substring(5));
                int b = Int32.Parse(str3[3].Substring(4));
                Color color = Color.FromArgb(r, g, b);
                color_table.Add(color);
            }
            string[] str4 = text_section.Split('}');
            //\viewkind4\uc1 \pard\f0\fs17 MQIFVKTLTG  KTITLEVEPS  \cf1 DTIENVKAKI  \cf0 QDKEGIPPDQ  QRLIFAGKQL  \cf2 EDGRTLSDYN  \cf0 IQKESTLHLV  LRLR\cf3 GG\cf0\par
            string[] str5 = str4[str4.Length - 2].Split('\\');
            int str_c = 0;
            foreach (string sub in str5)
            {
                if (sub.StartsWith("f0") || sub.StartsWith("lang") || sub.StartsWith("fs"))
                {
                    string[] str6 = sub.Split(' ');
                    if (str6.Length > 1)
                    {
                        for (int i = 1; i < str6.Length; i++)
                        {
                            for (int h = 0; h < str6[i].Length; h++)
                            {
                                if (sequence[str_c].Equals(str6[i][h]))
                                {
                                    char_color[str_c] = 0; str_c++;
                                }
                                else
                                {
                                    MessageBox.Show("Unfortunately an error occured while reading the sequence rtf.\r\nThis means that the colored letters of the sequence won't be colored as you want.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                }
                            }
                        }
                    }

                }
                else if (sub.StartsWith("cf"))//change color keyword
                {
                    string[] str6 = sub.Split(' ');
                    if (str6.Length > 1)
                    {
                        int color_idx = Int32.Parse(str6[0].Substring(2));

                        for (int i = 1; i < str6.Length; i++)
                        {
                            for (int h = 0; h < str6[i].Length; h++)
                            {
                                if (sequence[str_c].Equals(str6[i][h]))
                                {
                                    char_color[str_c] = color_idx; str_c++;
                                }
                                else
                                {
                                    MessageBox.Show("Unfortunately an error occured while reading the sequence rtf.\r\nThis means that the colored letters of the sequence won't be colored as you want.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                }
                            }
                        }
                    }
                    //else break;//when cf is not followed by a space then the plain text region has ended
                }
            }
            seq.Char_color = char_color;
            seq.Color_table = color_table;
        }

        #endregion

        #region SAVE-LOAD list fragments
        //save
        private void saveList()
        {
            List<int> fragToSave = new List<int>();
            if (frag_types_save) { fragToSave = selectedFragments_fragTypes.ToList(); }
            else { fragToSave = selectedFragments.ToList(); }
            int fragments_count = fragToSave.Count();
            bool mult_extension = true;
            string name_extension = "";
            string exclusion = "";
            foreach (string[] kk in list_21)
            {
                exclusion += "\t" + kk[0] + "," + kk[1] + "," + kk[2] + "," + kk[3];
            }
            if (sequenceList != null && sequenceList.Count > 1)
            {
                for (int s = 1; s < sequenceList.Count; s++)
                {
                    name_extension += "." + sequenceList[s].Extension;
                }
            }
            DialogResult dialogResult = MessageBox.Show("By default 'EnviPat' Calculations are not saved.\r\nDo you want to save 'EnviPat' Calculations ?\r\n['Yes' recommended in case of a large compound]", "'Save' settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save fitted list", FileName = "fragment" + name_extension, Filter = "Data Files (*.fit)|*.fit", DefaultExt = "fit", OverwritePrompt = true, AddExtension = true };
                if (heavy_present && light_present) { save.Filter = "Data Files (*.hlfit)|*.hlfit"; save.DefaultExt = "lhfit"; }
                else if (light_present) { save.Filter = "Data Files (*.lfit)|*.lfit"; save.DefaultExt = "lfit"; }
                else if (heavy_present) { save.Filter = "Data Files (*.hfit)|*.hfit"; save.DefaultExt = "hfit"; }
                if (save.ShowDialog() == DialogResult.OK)
                {
                    foreach (FragForm fra in Fragments2) { fra.Fixed = false; }
                    int progress = 0;
                    is_loading = true;
                    System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.
                    file.WriteLine("Mode:\tFitted List");
                    file.WriteLine("Multiple extensions:\t" + mult_extension.ToString());
                    if (mult_extension)
                    {
                        foreach (SequenceTab seq in sequenceList)
                        {
                            string ss_primary_region = "";
                            string ss_internal_region = "";
                            foreach (int[] region in seq.Index_SS_primary)
                            {
                                ss_primary_region += region[0] + "-" + region[1] + ",";
                            }
                            foreach (int[] region in seq.Index_SS_internal)
                            {
                                ss_internal_region += region[0] + "-" + region[1] + ",";
                            }
                            file.WriteLine("Extension:\t" + seq.Extension + "\t" + seq.Type.ToString() + "\t" + seq.Sequence + "\t" + seq.Rtf + "\t" + ss_primary_region + "\t" + ss_internal_region);
                        }
                    }
                    file.WriteLine("Fitted isotopes:\t" + fragToSave.Count());
                    file.WriteLine("Exclusion List:" + exclusion);
                    file.WriteLine();
                    file.WriteLine("Name\tIon Type\tIndex\t->to Index\tCharge\tm/z\tMax Intensity\tFactor\tPPM Error\tInput Formula\tAdduct\tDeduct\tColor\tResolution\tminPPMerror\tmaxPPMerror\tsortIndex\tchainType\textension\tHasAdduct\tmaxFactor");
                    if (IonDraw.Count > 0) IonDraw.Clear();
                    progress_display_start(fragToSave.Count, "Saving fragments...");
                    foreach (int indexS in fragToSave)
                    {
                        Form2.Fragments2[indexS - 1].Fixed = true;
                        file.WriteLine(Form2.Fragments2[indexS - 1].Name + "\t" + Form2.Fragments2[indexS - 1].Ion_type + "\t" +Form2.Fragments2[indexS - 1].Index + "\t" + Form2.Fragments2[indexS - 1].IndexTo + "\t" + Form2.Fragments2[indexS - 1].Charge+ "\t" + Form2.Fragments2[indexS - 1].Mz + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Max_intensity,6)+ "\t" +Form2.Fragments2[indexS - 1].Factor + "\t" +Math.Round( Form2.Fragments2[indexS - 1].PPM_Error,4)+ "\t" +Form2.Fragments2[indexS - 1].InputFormula + "\t" + Form2.Fragments2[indexS - 1].Adduct + "\t" +Form2.Fragments2[indexS - 1].Deduct + "\t" + Form2.Fragments2[indexS - 1].Color.ToUint() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Resolution,2) + "\t" + Math.Round(Form2.Fragments2[indexS - 1].minPPM_Error,4) + "\t" +Math.Round(Form2.Fragments2[indexS - 1].maxPPM_Error,4) + "\t" + Form2.Fragments2[indexS - 1].SortIdx + "\t" +Form2.Fragments2[indexS - 1].Chain_type + "\t" + Form2.Fragments2[indexS - 1].Extension+ "\t" + Form2.Fragments2[indexS - 1].Has_adduct + "\t" + Form2.Fragments2[indexS - 1].maxFactor);
                        IonDraw.Add(new ion() { Extension = Form2.Fragments2[indexS - 1].Extension, SortIdx = Form2.Fragments2[indexS - 1].SortIdx, Name = Form2.Fragments2[indexS - 1].Name, Mz = Form2.Fragments2[indexS - 1].Mz, PPM_Error = Fragments2[indexS - 1].PPM_Error, maxPPM_Error = Fragments2[indexS - 1].maxPPM_Error, minPPM_Error = Fragments2[indexS - 1].minPPM_Error, Charge = Fragments2[indexS - 1].Charge, Index = Int32.Parse(Fragments2[indexS - 1].Index), IndexTo = Int32.Parse(Fragments2[indexS - 1].IndexTo), Ion_type = Fragments2[indexS - 1].Ion_type, Max_intensity = Fragments2[indexS - 1].Max_intensity * Fragments2[indexS - 1].Factor, Color = Fragments2[indexS - 1].Color.ToColor(), Chain_type = Fragments2[indexS - 1].Chain_type, Has_adduct = Fragments2[indexS-1].Has_adduct });
                        progress++;
                        if (progress % 10 == 0 && progress > 0) { progress_display_update(progress); }
                    }                   
                    populate_fragtypes_treeView();
                    progress_display_stop();
                    file.Flush(); file.Close(); file.Dispose();
                    is_loading = false;
                    refresh_frag_tree_fixed(fragToSave);
                    MessageBox.Show("You are ready!");
                }
            }
            else
            {
                is_loading = true;
                if (IonDraw.Count > 0) IonDraw.Clear();
                foreach (FragForm fra in Fragments2) { fra.Fixed = false; }
                foreach (int indexS in fragToSave)
                {
                    Form2.Fragments2[indexS - 1].Fixed = true;
                    IonDraw.Add(new ion() { Has_adduct = Form2.Fragments2[indexS - 1].Has_adduct, Extension = Form2.Fragments2[indexS - 1].Extension, SortIdx = Form2.Fragments2[indexS - 1].SortIdx, Name = Form2.Fragments2[indexS - 1].Name, Mz = Form2.Fragments2[indexS - 1].Mz, PPM_Error = Fragments2[indexS - 1].PPM_Error, maxPPM_Error = Fragments2[indexS - 1].maxPPM_Error, minPPM_Error = Fragments2[indexS - 1].minPPM_Error, Charge = Fragments2[indexS - 1].Charge, Index = Int32.Parse(Fragments2[indexS - 1].Index), IndexTo = Int32.Parse(Fragments2[indexS - 1].IndexTo), Ion_type = Fragments2[indexS - 1].Ion_type, Max_intensity = Fragments2[indexS - 1].Max_intensity * Fragments2[indexS - 1].Factor, Color = Fragments2[indexS - 1].Color.ToColor(), Chain_type = Fragments2[indexS - 1].Chain_type });
                }
                refresh_frag_tree_fixed(fragToSave);
                populate_fragtypes_treeView();
                is_loading = false;
                SaveFileDialog save = new SaveFileDialog() { Title = "Save fitted list", FileName = "fragment" + name_extension, Filter = "Data Files (*.ifit)|*.ifit", DefaultExt = "ifit", OverwritePrompt = true, AddExtension = true };
                if (heavy_present && light_present) { save.Filter = "Data Files (*.hlifit)|*.hlifit"; save.DefaultExt = "lhifit"; }
                else if (light_present) { save.Filter = "Data Files (*.lifit)|*.lifit"; save.DefaultExt = "lifit"; }
                else if (heavy_present) { save.Filter = "Data Files (*.hifit)|*.hifit"; save.DefaultExt = "hifit"; }
                if (save.ShowDialog() == DialogResult.OK)
                {                    
                    is_loading = true;
                    System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.
                    file.WriteLine("Mode:\tFitted List");
                    file.WriteLine("Multiple extensions:\t" + mult_extension.ToString());
                    if (mult_extension)
                    {
                        foreach (SequenceTab seq in sequenceList)
                        {
                            string ss_primary_region = "";
                            string ss_internal_region = "";
                            foreach (int[] region in seq.Index_SS_primary)
                            {
                                ss_primary_region += region[0] + "-" + region[1] + ",";
                            }
                            foreach (int[] region in seq.Index_SS_internal)
                            {
                                ss_internal_region += region[0] + "-" + region[1] + ",";
                            }
                            file.WriteLine("Extension:\t" + seq.Extension + "\t" + seq.Type.ToString() + "\t" + seq.Sequence + "\t" + seq.Rtf + "\t" + ss_primary_region + "\t" + ss_internal_region);
                        }
                    }
                    file.WriteLine("Fitted isotopes:\t" + fragToSave.Count());
                    file.WriteLine("Exclusion List:" + exclusion);
                    file.WriteLine();
                    file.WriteLine("Name\tIon Type\tIndex\t->to Index\tCharge\tm/z\tMax Intensity\tFactor\tPPM Error\tInput Formula\tAdduct\tDeduct\tColor\tResolution\tminPPMerror\tmaxPPMerror\tsortIndex\tchainType\textension");
                    _bw_save_envipat.RunWorkerAsync(file);
                }
            }
            find_max_min_int();
        }
        private void refresh_frag_tree_fixed(List<int> fragToSave)
        {
            if (frag_tree != null)
            {            
                frag_tree.BeginUpdate();
                foreach (TreeNode big_node in frag_tree.Nodes)
                {
                    foreach (TreeNode node in big_node.Nodes)
                    {
                        int idx = Convert.ToInt32(node.Name);
                        if (fragToSave.Any(p => p.Equals(idx+1))) node.ForeColor = Color.DarkGreen;
                        else { Fragments2[idx].Fixed = false; node.ForeColor = Color.Black; }
                    }                    
                }
                frag_tree.EndUpdate();
            }  
        }
        void _bw_save_envipat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("You are ready!");
        }
        void Save_frag_envipat(object sender, DoWorkEventArgs e)
        {
            List<int> fragToSave = new List<int>();
            if (frag_types_save) { fragToSave = selectedFragments_fragTypes.ToList(); }
            else { fragToSave = selectedFragments.ToList(); }
            StreamWriter file = (StreamWriter)e.Argument;
            int progress = 0;
            progress_display_start(fragToSave.Count, "Saving fragments...");
            foreach (int indexS in fragToSave)
            {
                string profile_string = "Prof:";
                string centroid_string = "Centr:";
                foreach (PointPlot pp in Fragments2[indexS - 1].Profile)
                {
                    profile_string += "\t" + Math.Round(pp.X ,6)+ " " + Math.Round(pp.Y,6);
                }
                foreach (PointPlot pp in Fragments2[indexS - 1].Centroid)
                {
                    centroid_string += "\t" + Math.Round(pp.X,6) + " " + Math.Round(pp.Y,6);
                }
                file.WriteLine(Form2.Fragments2[indexS - 1].Name + "\t" + Form2.Fragments2[indexS - 1].Ion_type + "\t" +Form2.Fragments2[indexS - 1].Index + "\t" + Form2.Fragments2[indexS - 1].IndexTo + "\t" +Form2.Fragments2[indexS - 1].Charge + "\t" + Form2.Fragments2[indexS - 1].Mz + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Max_intensity,6) + "\t" + Form2.Fragments2[indexS - 1].Factor +"\t" + Math.Round(Form2.Fragments2[indexS - 1].PPM_Error,4) + "\t" + Form2.Fragments2[indexS - 1].InputFormula +"\t" + Form2.Fragments2[indexS - 1].Adduct + "\t" + Form2.Fragments2[indexS - 1].Deduct + "\t" +Form2.Fragments2[indexS - 1].Color.ToUint() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Resolution,2) +"\t" + Math.Round(Form2.Fragments2[indexS - 1].minPPM_Error,4) + "\t" + Math.Round(Form2.Fragments2[indexS - 1].maxPPM_Error,4) +"\t" + Form2.Fragments2[indexS - 1].SortIdx + "\t" + Form2.Fragments2[indexS - 1].Chain_type+ "\t" + Form2.Fragments2[indexS - 1].Extension+ "\t" + Form2.Fragments2[indexS - 1].Has_adduct + "\t" + Form2.Fragments2[indexS - 1].maxFactor);
                file.WriteLine(profile_string);
                file.WriteLine(centroid_string);
                progress++;
                if (progress % 50 == 0 && progress > 0) { progress_display_update(progress); }
            }
            progress_display_stop();
            file.Flush(); file.Close(); file.Dispose();
            is_loading = false;
        }
        //load
        private void loadList()
        {
            duplicate_count = 0; added = 0;
            bool mult_extensions = false; bool new_type = false; bool peptide = true;
            bool heavy = false; bool light = false; bool HEAVY_LIGHT_BOTH = false; string extension = "";
            OpenFileDialog loadData = new OpenFileDialog() { Multiselect = true, Title = "Load fitting data", FileName = "", Filter = "data file|*.hlfit;*.lfit;*.hfit;*.fit;*.hlpfit;*.lpfit;*.hpfit;*.pfit*.hlifit;*.lifit;*.hifit;*.ifit;|All files|*.*" };
            string fullPath = "";
            bool envipat = false;
            List<ChemiForm> chem_to_calc = new List<ChemiForm>();
            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";            
            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                if (is_exp_deconvoluted)
                {
                    var charge_dialog = this.ShowChargeDialog();
                    if (string.IsNullOrEmpty(charge_dialog.ToString()))
                    {
                        MessageBox.Show("No charge state selected! Therefore, 'Loading fragments' procedure is cancelled.", "Loading Fragments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                    }
                    else if (charge_dialog.ToString().Equals("Neutral")) { dec_charge = 0; }
                    else { dec_charge = 1; }
                }
                #region UI & data                 
                //fit_Btn.Enabled = true; fit_sel_Btn.Enabled = true;
                //plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;
                loadExp_Btn.Enabled = true;
                #endregion
                int file_count = loadData.FileNames.Length;
                selectedFragments.Clear();
                for (int n = 0; n < file_count; n++)
                {
                    string FileName = loadData.FileNames[n];
                    List<ChemiForm> fitted_chem = new List<ChemiForm>();
                    List<string> lista = new List<string>();
                    mult_extensions = false; new_type = false; peptide = true; envipat = false;
                    heavy = false; light = false; HEAVY_LIGHT_BOTH = false; extension = "";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(loaded_lists);
                    sb.AppendLine(System.IO.Path.GetFileNameWithoutExtension(FileName));
                    extension = System.IO.Path.GetExtension(FileName);
                    if (extension.Equals(".hfit")) { heavy = true; heavy_present = true; }
                    else if (extension.Equals(".lfit")) { light = true; light_present = true; }
                    else if (extension.Equals(".hlfit")) { HEAVY_LIGHT_BOTH = true; light_present = true; heavy_present = true; }
                    else if (extension.Equals(".pfit") || extension.Equals(".ifit")) { envipat = true; }
                    else if (extension.Equals(".hpfit") || extension.Equals(".hifit")) { heavy = true; heavy_present = true; envipat = true; }
                    else if (extension.Equals(".lpfit") || extension.Equals(".lifit")) { light = true; light_present = true; envipat = true; }
                    else if (extension.Equals(".hlpfit") || extension.Equals(".hlifit")) { HEAVY_LIGHT_BOTH = true; light_present = true; heavy_present = true; envipat = true; }
                    if (sb != null && sb.Length > 0) loaded_lists = sb.ToString();
                    show_files_Btn.ToolTipText = loaded_lists;
                    is_loading = true;  // performance
                    fullPath = FileName;
                    string s_chain = string.Empty;
                    string s2_chain = string.Empty;
                    System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);
                    do { lista.Add(objReader.ReadLine()); }
                    while (objReader.Peek() != -1);
                    objReader.Close();
                    bool dec = false;
                    int arrayPositionIndex = 0;
                    int isotope_count = -1;
                    int f = Fragments2.Count();
                    is_calc = true;
                    if (envipat)
                    {
                        progress_display_start(lista.Count, "Receiving fragment isotopic distributions...");
                        for (int j = 0; j != (lista.Count); j++)
                        {
                            //string[] str = new string[15];
                            try
                            {
                                string[] str = lista[j].Split('\t');
                                if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z") || lista[j].StartsWith("Name") || lista[j].StartsWith("Mode")) continue; // comments
                                else if (lista[j].StartsWith("Multiple"))
                                {
                                    mult_extensions = string_to_bool(str[1]); new_type = true;
                                }
                                else if (lista[j].StartsWith("Extension"))
                                {
                                    if (peptide)
                                    {
                                        peptide = false;
                                        Peptide = str[3];
                                        if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }); read_rtf_find_color(sequenceList.Last()); }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(str[3])) continue;
                                            else { sequenceList[0] = new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }; read_rtf_find_color(sequenceList[0]); }
                                        }
                                    }
                                    else
                                    {
                                        bool found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals(str[1]))
                                            {
                                                if (!seq.Sequence.Equals(str[3])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = str[1], Sequence = str[3], Rtf = str[4], Type = Convert.ToInt32(str[2]) }); read_rtf_find_color(sequenceList.Last()); }
                                    }
                                    if (str.Length == 7) { sequenceList.Last().Index_SS_internal = return_regions_SS(str[5]); sequenceList.Last().Index_SS_primary = return_regions_SS(str[6]); }
                                    else { sequenceList.Last().Index_SS_internal = new List<int[]>(); sequenceList.Last().Index_SS_primary = new List<int[]>(); }
                                }
                                else if (lista[j].StartsWith("AA"))
                                {
                                    if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = "", Rtf = "", Type = 0 }); }

                                    if (HEAVY_LIGHT_BOTH)
                                    {
                                        if (str.Count() < 3)
                                        {
                                            MessageBox.Show("You have inserted a .hlfit file without two sequences.\r\nThe heavy chain and the light chain sequences are needed!\r\nPlease close the program and correct the file's extension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                        }
                                        s_chain = str[1];
                                        s2_chain = str[2];
                                        heavy_chain = str[1];
                                        light_chain = str[2];
                                        bool found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals("H"))
                                            {
                                                if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = "H", Sequence = str[1], Rtf = "", Type = 1 }); }
                                        found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals("L"))
                                            {
                                                if (!seq.Sequence.Equals(str[2])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = "L", Sequence = str[2], Rtf = "", Type = 2 }); }
                                    }
                                    else
                                    {
                                        s_chain = str[1];
                                        if (heavy)
                                        {
                                            heavy_chain = str[1];
                                            bool found = false;
                                            foreach (SequenceTab seq in sequenceList)
                                            {
                                                if (seq.Extension.Equals("H"))
                                                {
                                                    if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                    else { found = true; }
                                                    break;
                                                }
                                            }
                                            if (!found) { sequenceList.Add(new SequenceTab() { Extension = "H", Sequence = str[1], Rtf = "", Type = 1 }); }
                                        }
                                        else if (light)
                                        {
                                            light_chain = str[1];
                                            bool found = false;
                                            foreach (SequenceTab seq in sequenceList)
                                            {
                                                if (seq.Extension.Equals("L"))
                                                {
                                                    if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                    else { found = true; }
                                                    break;
                                                }
                                            }
                                            if (!found) { sequenceList.Add(new SequenceTab() { Extension = "L", Sequence = str[1], Rtf = "", Type = 2 }); }
                                        }
                                        else
                                        {
                                            peptide = false;
                                            Peptide = str[1];
                                            if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = str[1], Rtf = "", Type = 0 }); }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(str[1])) continue;
                                                else { sequenceList[0] = new SequenceTab() { Extension = "", Sequence = str[1], Rtf = "", Type = 0 }; }
                                            }
                                        }
                                    }
                                }
                                else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                                else if (lista[j].StartsWith("Exclusion"))
                                {
                                    if (str.Length > 1 && !String.IsNullOrEmpty(str[1]))
                                    {
                                        for (int ss = 1; ss < str.Length; ss++)
                                        {
                                            string[] str2 = str[ss].Split(',');
                                            if (str2.Length == 4)
                                            {
                                                string[] input = new string[] { str2[0], str2[1], str2[2], str2[3] };
                                                if (!list_21.Contains(input)) list_21.Add(input);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool check_mate = check_for_duplicates(str[0], dParser(str[5]));
                                    if (check_mate)
                                    {
                                        added++;
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
                                            InputFormula = str[9],
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
                                            Intensoid = new List<PointPlot>(),
                                            Combinations4 = new List<Combination_4>(),
                                            FinalFormula = string.Empty,
                                            Color = new OxyColor(),
                                            Charge = Int32.Parse(str[4]),
                                            Ion_type = str[1],
                                            PPM_Error = dParser(str[8]),
                                            PrintFormula = str[9],
                                            Name = str[0],                                           
                                            Factor = dParser(str[7]),
                                            Fixed = true,
                                            Max_man_int = 0,
                                            maxPPM_Error = 0,
                                            minPPM_Error = 0,
                                            Has_adduct = false
                                        });
                                        if (UInt32.TryParse(str[12], out uint result_color)) fitted_chem.Last().Color = OxyColor.FromUInt32(result_color);
                                        if (is_exp_deconvoluted && Math.Abs(fitted_chem.Last().Charge) != dec_charge)
                                        {
                                            dec = true;
                                            if (dec_charge==0) { fitted_chem.Last().Adduct = ""; fitted_chem.Last().Deduct = ""; fitted_chem.Last().Charge = 0; }
                                            else  if (fitted_chem.Last().Charge>0) { fitted_chem.Last().Adduct = "H1"; fitted_chem.Last().Deduct = ""; fitted_chem.Last().Charge = 1; }
                                            else { fitted_chem.Last().Adduct = ""; fitted_chem.Last().Deduct = "H1"; fitted_chem.Last().Charge = -1; }
                                            //IonDraw.Last().Charge = 0;
                                        }
                                        if (!new_type)
                                        {
                                            fitted_chem.Last().Extension = ""; fitted_chem.Last().Chain_type = 0;
                                            if (heavy)
                                            {
                                                if (!str[0].EndsWith("_H")) fitted_chem.Last().Name = str[0] + "_H";
                                                fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                                //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                            }
                                            else if (light)
                                            {
                                                if (!str[0].EndsWith("_L")) { fitted_chem.Last().Name = str[0] + "_L"; }
                                                fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                                //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type =2;
                                            }
                                            else if (HEAVY_LIGHT_BOTH)
                                            {
                                                if (fitted_chem.Last().Name.EndsWith("_L") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                                {
                                                    fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                                    //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type = 2;
                                                }
                                                else if (fitted_chem.Last().Name.EndsWith("_H") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                                {
                                                    fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                                    //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                                }
                                            }
                                            if (str[1].StartsWith("w") || str[1].StartsWith("v") || str[1].StartsWith("x") || str[1].StartsWith("y") || str[1].StartsWith("z") || str[1].StartsWith("(x") || str[1].StartsWith("(y") || str[1].StartsWith("(z")|| str[1].StartsWith("(v") || str[1].StartsWith("(w"))
                                            {
                                                if (HEAVY_LIGHT_BOTH)
                                                {
                                                    if (str[0].EndsWith("_H"))
                                                    {
                                                        fitted_chem.Last().SortIdx = s_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                    }
                                                    else if (str[0].EndsWith("_L"))
                                                    {
                                                        fitted_chem.Last().SortIdx = s2_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You have inserted a .hlfit file without _H and _L in the fragments name.\r\nAs a result, the x,y,z indexes will be false.\r\nPlease close the program and correct the file's extension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    }
                                                }
                                                else
                                                {
                                                    fitted_chem.Last().SortIdx = s_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                }
                                            }
                                            else { fitted_chem.Last().SortIdx = Int32.Parse(fitted_chem.Last().Index); }
                                            if (str.Length == 16)
                                            {
                                                fitted_chem.Last().maxPPM_Error = dParser(str[15]);
                                                fitted_chem.Last().minPPM_Error = dParser(str[14]);
                                                //IonDraw.Last().maxPPM_Error = dParser(str[15]);
                                                //IonDraw.Last().minPPM_Error = dParser(str[14]);
                                            }
                                            fitted_chem.Last().Has_adduct = false;
                                            fitted_chem.Last().maxFactor = 0.0;
                                        }
                                        else
                                        {
                                            fitted_chem.Last().Extension = str[18];
                                            fitted_chem.Last().SortIdx = Convert.ToInt32(str[16]);
                                            fitted_chem.Last().Chain_type = Convert.ToInt32(str[17]);
                                            fitted_chem.Last().maxPPM_Error = dParser(str[15]);
                                            fitted_chem.Last().minPPM_Error = dParser(str[14]);
                                            if (str.Length>19) { fitted_chem.Last().Has_adduct = string_to_bool(str[19]); }
                                            else { fitted_chem.Last().Has_adduct = false; }
                                            if (str.Length > 20) { fitted_chem.Last().maxFactor = dParser(str[20]); }
                                            else { fitted_chem.Last().maxFactor = 0.0; }                                               
                                            if ((fitted_chem.Last().Ion_type.StartsWith("w") || fitted_chem.Last().Ion_type.StartsWith("(w") || fitted_chem.Last().Ion_type.StartsWith("v") || fitted_chem.Last().Ion_type.StartsWith("(v"))&& str[16].Equals(str[2]))
                                            {
                                                fitted_chem.Last().SortIdx = 0;
                                            }
                                        }
                                        if (fitted_chem.Last().Name.EndsWith("_L") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                        {
                                            fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                            //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type = 2;
                                        }
                                        else if (fitted_chem.Last().Name.EndsWith("_H") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                        {
                                            fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                            //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                        }
                                        arrayPositionIndex++;
                                        j++;
                                        str = lista[j].Split('\t');
                                        if (lista[j].StartsWith("Prof"))
                                        {
                                            if ((!is_exp_deconvoluted || !dec) && !is_recalc_res)
                                            {
                                                for (int s = 1; s < str.Length; s++)
                                                {
                                                    string[] prof = str[s].Split(' ');
                                                    fitted_chem.Last().Profile.Add(new PointPlot() { X = dParser(prof[0]), Y = dParser(prof[1]) });
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                        }
                                        arrayPositionIndex++;
                                        j++;
                                        str = lista[j].Split('\t');
                                        if (lista[j].StartsWith("Cen"))
                                        {
                                            if ((!is_exp_deconvoluted || !dec) && !is_recalc_res)
                                            {
                                                for (int s = 1; s < str.Length; s++)
                                                {
                                                    string[] cen = str[s].Split(' ');
                                                    fitted_chem.Last().Centroid.Add(new PointPlot() { X = dParser(cen[0]), Y = dParser(cen[1]) });
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                        }

                                        if (fitted_chem.Last().SortIdx == 0 ) { fitted_chem.Last().SortIdx = check_false_sort_idx(fitted_chem.Last()); }
                                    }
                                    else
                                    {
                                        j = j + 2;
                                        duplicate_count++;
                                    }
                                }
                            }
                            catch (Exception ex) { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j] + "\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); is_loading = false; progress_display_stop(); return; }
                            arrayPositionIndex++;
                            if (j % 10 == 0 && j > 0) { progress_display_update(j); }
                        }
                        progress_display_stop();
                        if (!dec && !is_recalc_res)
                        {
                            foreach (ChemiForm chemi in fitted_chem)
                            {
                                List<PointPlot> cen = chemi.Centroid.OrderByDescending(p => p.Y).ToList();
                                add_fragment_to_Fragments2(chemi, cen);
                            }
                            if (n == file_count - 1)
                            {
                                is_calc = false;
                            }
                        }
                        else
                        {
                            chem_to_calc.AddRange(fitted_chem);
                        }
                    }
                    else
                    {
                        for (int j = 0; j != (lista.Count); j++)
                        {
                            try
                            {
                                string[] str = lista[j].Split('\t');

                                if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z") || lista[j].StartsWith("\t")|| lista[j].StartsWith("Name")|| lista[j].StartsWith("Mode")) continue; // comments
                                else if (lista[j].StartsWith("Multiple"))
                                {
                                    mult_extensions = string_to_bool(str[1]); new_type = true;
                                }
                                else if (lista[j].StartsWith("Extension"))
                                {
                                    if (peptide)
                                    {
                                        peptide = false;
                                        Peptide = str[3];
                                        if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }); read_rtf_find_color(sequenceList.Last()); }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(str[3])) continue;
                                            else { sequenceList[0] = new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }; read_rtf_find_color(sequenceList[0]); }
                                        }
                                    }
                                    else
                                    {
                                        bool found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals(str[1]))
                                            {
                                                if (!seq.Sequence.Equals(str[3])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences.\r\nPlease check the Sequence section after the completion of the calculations", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = str[1], Sequence = str[3], Rtf = str[4], Type = Convert.ToInt32(str[2]) }); read_rtf_find_color(sequenceList.Last()); }
                                    }
                                    if (str.Length == 7) { sequenceList.Last().Index_SS_internal = return_regions_SS(str[5]); sequenceList.Last().Index_SS_primary = return_regions_SS(str[6]); }
                                    else { sequenceList.Last().Index_SS_internal = new List<int[]>(); sequenceList.Last().Index_SS_primary = new List<int[]>(); }
                                }
                                else if (lista[j].StartsWith("AA"))
                                {
                                    if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = "", Rtf = "", Type = 0 }); }

                                    if (HEAVY_LIGHT_BOTH)
                                    {
                                        if (str.Count() < 3)
                                        {
                                            MessageBox.Show("You have inserted a .hlfit file without two sequences.\r\nThe heavy chain and the light chain sequences are needed!\r\nPlease close the program and correct the file's extension!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                        }
                                        s_chain = str[1];
                                        s2_chain = str[2];
                                        heavy_chain = str[1];
                                        light_chain = str[2];
                                        bool found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals("H"))
                                            {
                                                if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences. Please check the Sequence section after the completion of the calculations"); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = "H", Sequence = str[1], Rtf = "", Type = 1 }); }
                                        found = false;
                                        foreach (SequenceTab seq in sequenceList)
                                        {
                                            if (seq.Extension.Equals("L"))
                                            {
                                                if (!seq.Sequence.Equals(str[2])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences. Please check the Sequence section after the completion of the calculations"); }
                                                else { found = true; }
                                                break;
                                            }
                                        }
                                        if (!found) { sequenceList.Add(new SequenceTab() { Extension = "L", Sequence = str[2], Rtf = "", Type = 2 }); }
                                    }
                                    else
                                    {
                                        s_chain = str[1];
                                        if (heavy)
                                        {
                                            heavy_chain = str[1];
                                            bool found = false;
                                            foreach (SequenceTab seq in sequenceList)
                                            {
                                                if (seq.Extension.Equals("H"))
                                                {
                                                    if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences. Please check the Sequence section after the completion of the calculations"); }
                                                    else { found = true; }
                                                    break;
                                                }
                                            }
                                            if (!found) { sequenceList.Add(new SequenceTab() { Extension = "H", Sequence = str[1], Rtf = "", Type = 1 }); }
                                        }
                                        else if (light)
                                        {
                                            light_chain = str[1];
                                            bool found = false;
                                            foreach (SequenceTab seq in sequenceList)
                                            {
                                                if (seq.Extension.Equals("L"))
                                                {
                                                    if (!seq.Sequence.Equals(str[1])) { MessageBox.Show("Two identical extensions were identified but with different amino-acid sequences. Please check the Sequence section after the completion of the calculations"); }
                                                    else { found = true; }
                                                    break;
                                                }
                                            }
                                            if (!found) { sequenceList.Add(new SequenceTab() { Extension = "L", Sequence = str[1], Rtf = "", Type = 2 }); }
                                        }
                                        else
                                        {
                                            peptide = false;
                                            Peptide = str[1];
                                            if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = str[1], Rtf = "", Type = 0 }); }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(str[1])) continue;
                                                else { sequenceList[0] = new SequenceTab() { Extension = "", Sequence = str[1], Rtf = "", Type = 0 }; }
                                            }
                                        }
                                    }
                                }
                                else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                                else if (lista[j].StartsWith("Exclusion"))
                                {
                                    if (str.Length > 1 && !String.IsNullOrEmpty(str[1]))
                                    {
                                        for (int ss = 1; ss < str.Length; ss++)
                                        {
                                            string[] str2 = str[ss].Split(',');
                                            if (str2.Length == 4)
                                            {
                                                string[] input = new string[] { str2[0], str2[1], str2[2], str2[3] };
                                                if (!list_21.Contains(input)) list_21.Add(input);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool check_mate = check_for_duplicates(str[0], dParser(str[5]));
                                    if (check_mate)
                                    {
                                        added++;
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
                                            InputFormula = str[9],
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
                                            Intensoid = new List<PointPlot>(),
                                            Combinations4 = new List<Combination_4>(),
                                            FinalFormula = string.Empty,
                                            Color = new OxyColor(),
                                            Charge = Int32.Parse(str[4]),
                                            Ion_type = str[1],
                                            PPM_Error = dParser(str[8]),
                                            PrintFormula = str[9],
                                            Name = str[0],                                           
                                            Factor = dParser(str[7]),
                                            Fixed = true,
                                            Max_man_int = 0,
                                            maxPPM_Error = 0,
                                            minPPM_Error = 0,
                                            Has_adduct = false
                                        });
                                        if (UInt32.TryParse(str[12], out uint result_color)) fitted_chem.Last().Color = OxyColor.FromUInt32(result_color);
                                        if (is_exp_deconvoluted && Math.Abs(fitted_chem.Last().Charge)!=dec_charge)
                                        {
                                            if (dec_charge == 0) { fitted_chem.Last().Adduct = ""; fitted_chem.Last().Deduct = ""; fitted_chem.Last().Charge = 0; }
                                            else if (fitted_chem.Last().Charge > 0) { fitted_chem.Last().Adduct = "H1"; fitted_chem.Last().Deduct = ""; fitted_chem.Last().Charge = 1; }
                                            else { fitted_chem.Last().Adduct = ""; fitted_chem.Last().Deduct = "H1"; fitted_chem.Last().Charge = -1; }
                                        }
                                        if (!new_type)
                                        {
                                            fitted_chem.Last().Has_adduct = false;
                                            fitted_chem.Last().maxFactor = 0.0;
                                            fitted_chem.Last().Extension = ""; fitted_chem.Last().Chain_type = 0;
                                            if (heavy)
                                            {
                                                if (!str[0].EndsWith("_H")) { fitted_chem.Last().Name = str[0] + "_H"; /*IonDraw.Last().Name = str[0] + "_H";*/ }
                                                fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                                //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                            }
                                            else if (light)
                                            {
                                                if (!str[0].EndsWith("_L")) { fitted_chem.Last().Name = str[0] + "_L"; /*IonDraw.Last().Name = str[0] + "_L"; */}
                                                fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                                //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type = 2;
                                            }
                                            else if (HEAVY_LIGHT_BOTH)
                                            {
                                                if (fitted_chem.Last().Name.EndsWith("_L") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                                {
                                                    fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                                    //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type = 2;
                                                }
                                                else if (fitted_chem.Last().Name.EndsWith("_H") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                                {
                                                    fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                                    //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                                }
                                            }
                                            if (str[1].StartsWith("v") || str[1].StartsWith("w") || str[1].StartsWith("x") || str[1].StartsWith("y") || str[1].StartsWith("z") || str[1].StartsWith("(x") || str[1].StartsWith("(y") || str[1].StartsWith("(z") || str[1].StartsWith("(v") || str[1].StartsWith("(w"))
                                            {
                                                if (HEAVY_LIGHT_BOTH)
                                                {
                                                    if (str[0].EndsWith("_H"))
                                                    {
                                                        fitted_chem.Last().SortIdx = s_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                    }
                                                    else if (str[0].EndsWith("_L"))
                                                    {
                                                        fitted_chem.Last().SortIdx = s2_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You have inserted a .hlfit file without _H and _L in the fragments name the x,y,z will be false. Please close the program and correct data type with the correct extension!");
                                                    }
                                                }
                                                else
                                                {
                                                    fitted_chem.Last().SortIdx = s_chain.Length - Int32.Parse(fitted_chem.Last().Index);
                                                }
                                            }
                                            else { fitted_chem.Last().SortIdx = Int32.Parse(fitted_chem.Last().Index); }
                                            if (str.Length == 16)
                                            {
                                                fitted_chem.Last().maxPPM_Error = dParser(str[15]);
                                                fitted_chem.Last().minPPM_Error = dParser(str[14]);                                                
                                            }
                                        }
                                        else
                                        {
                                            fitted_chem.Last().Extension = str[18];
                                            fitted_chem.Last().SortIdx = Convert.ToInt32(str[16]);
                                            fitted_chem.Last().Chain_type = Convert.ToInt32(str[17]);
                                            fitted_chem.Last().maxPPM_Error = dParser(str[15]);
                                            fitted_chem.Last().minPPM_Error = dParser(str[14]);
                                            if (str.Length > 19) { fitted_chem.Last().Has_adduct = string_to_bool(str[19]); }
                                            else
                                            {
                                                fitted_chem.Last().Has_adduct = false;
                                            }
                                            if (str.Length > 20) { fitted_chem.Last().maxFactor = dParser(str[20]); }
                                            else { fitted_chem.Last().maxFactor = 0.0; }
                                            if ((fitted_chem.Last().Ion_type.StartsWith("w") || fitted_chem.Last().Ion_type.StartsWith("(w") || fitted_chem.Last().Ion_type.StartsWith("v") || fitted_chem.Last().Ion_type.StartsWith("(v")) && str[16].Equals(str[2]))
                                            {
                                                fitted_chem.Last().SortIdx = 0;
                                            }                                           
                                        }
                                        if (fitted_chem.Last().Name.EndsWith("_L") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                        {
                                            fitted_chem.Last().Extension = "_L"; fitted_chem.Last().Chain_type = 2;
                                            //IonDraw.Last().Extension = "_L"; IonDraw.Last().Chain_type = 2;
                                        }
                                        else if (fitted_chem.Last().Name.EndsWith("_H") && string.IsNullOrEmpty(fitted_chem.Last().Extension))
                                        {
                                            fitted_chem.Last().Extension = "_H"; fitted_chem.Last().Chain_type = 1;
                                            //IonDraw.Last().Extension = "_H"; IonDraw.Last().Chain_type = 1;
                                        }
                                        if (fitted_chem.Last().SortIdx == 0) { fitted_chem.Last().SortIdx = check_false_sort_idx(fitted_chem.Last()); }
                                        if (fitted_chem.Last().Name.Contains("SH")) {
                                            fitted_chem.Last().Has_adduct = true;
                                        }
                                    }
                                    else duplicate_count++;
                                }
                            }
                            catch (Exception ex) { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j] + "\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); is_loading = false; return; }
                            arrayPositionIndex++;
                        }
                        chem_to_calc.AddRange(fitted_chem);
                    }
                }
            }
            else { return; }
            fitted_results.Clear();
            if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            if (sequenceList.Count == 1) { tab_mode = false; }
            else { tab_mode = true; }
            if (chem_to_calc.Count > 0)
            {
                Thread envipat_fitted = new Thread(() => calculate_fragment_properties(chem_to_calc));
                envipat_fitted.Start();
            }
            else if (Fragments2.Count > 0)
            {
                // sort by mz the fragments list (global) beause it is mixed by multi-threading
                Fragments2 = Fragments2.OrderBy(f => Convert.ToDouble(f.Mz)).ToList();
                change_name_duplicates();
                frags_maxFactor();
                // thread safely fire event to continue calculations
                Invoke(new Action(() => OnEnvelopeCalcCompleted()));
                MessageBox.Show(added.ToString() + " fragments added from file. " + duplicate_count.ToString() + " duplicates removed from current files.", "Fitted fragments files");
            }
            exclude_list_make_lists();
            is_loading = false; is_calc = false;
        }
        private int check_false_sort_idx(object chemInput)
        {            
            try
            {
                ChemiForm chem = chemInput as ChemiForm;
                string s = string.Empty;
                int sort_index = 0;
                if (chem.Ion_type.StartsWith("w") || chem.Ion_type.StartsWith("v") || chem.Ion_type.StartsWith("x") || chem.Ion_type.StartsWith("y") || chem.Ion_type.StartsWith("z") || chem.Ion_type.StartsWith("(v") || chem.Ion_type.StartsWith("(w") || chem.Ion_type.StartsWith("(x") || chem.Ion_type.StartsWith("(y") || chem.Ion_type.StartsWith("(z"))
                {
                    bool found = false;
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if ((seq.Extension != "" && recognise_extension(chem.Extension, seq.Extension)) || (seq.Extension == "" && chem.Extension == ""))
                        {
                            found = true; break;
                        }
                    }
                    if (found) { sort_index = s.Length - Int32.Parse(chem.Index); }
                    else { sort_index = 0; MessageBox.Show("Error in fragment " + chem.Name + " index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    sort_index = Int32.Parse(chem.Index);
                }
                return sort_index;
            }
            catch
            {
                FragForm chem = chemInput as FragForm;
                string s = string.Empty;
                int sort_index = 0;
                if (chem.Ion_type.StartsWith("w") || chem.Ion_type.StartsWith("v") || chem.Ion_type.StartsWith("x") || chem.Ion_type.StartsWith("y") || chem.Ion_type.StartsWith("z") || chem.Ion_type.StartsWith("(v") || chem.Ion_type.StartsWith("(w") || chem.Ion_type.StartsWith("(x") || chem.Ion_type.StartsWith("(y") || chem.Ion_type.StartsWith("(z"))
                {
                    bool found = false;
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if ((seq.Extension != "" && recognise_extension(chem.Extension, seq.Extension)) || (seq.Extension == "" && chem.Extension == ""))
                        {
                            found = true; break;
                        }
                    }
                    if (found) { sort_index = s.Length - Int32.Parse(chem.Index); }
                    else { sort_index = 0; MessageBox.Show("Error in fragment " + chem.Name + " index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    sort_index = Int32.Parse(chem.Index);
                }
                return sort_index;
            }
           
        }
        private void exclude_list_make_lists()
        {
            exclude_a_indexes.Clear();
            exclude_b_indexes.Clear();
            exclude_c_indexes.Clear();
            exclude_x_indexes.Clear();
            exclude_y_indexes.Clear();
            exclude_z_indexes.Clear();
            exclude_d_indexes.Clear();
            exclude_w_indexes.Clear();
            exclude_internal_indexes.Clear();
            foreach (string[] item in list_21)
            {
                if (item[0].Equals("internal"))
                {
                    check_item(item, exclude_internal_indexes, true);
                }
                else if (item[0].Equals("a"))
                {
                    check_item(item, exclude_a_indexes);

                }
                else if (item[0].Equals("b"))
                {
                    check_item(item, exclude_b_indexes);
                }
                else if (item[0].Equals("c"))
                {
                    check_item(item, exclude_c_indexes);
                }
                else if (item[0].Equals("x"))
                {
                    check_item(item, exclude_x_indexes);
                }
                else if (item[0].Equals("y"))
                {
                    check_item(item, exclude_y_indexes);
                }
                else if (item[0].Equals("z"))
                {
                    check_item(item, exclude_z_indexes);
                }
                else if (item[0].Equals("d"))
                {
                    check_item(item, exclude_d_indexes);
                }
                else if (item[0].Equals("w"))
                {
                    check_item(item, exclude_w_indexes);
                }
            }
        }
        private bool check_for_duplicates(string name, double mz)
        {
            int[] a = new int[] { 1, 1 };
            if (Fragments2.Count < 1) return true;
            int count = Fragments2.Count;
            for (int f = 0; f < count; f++)
            {
                FragForm fra = Fragments2[f];
                if (fra.Name.Equals(name) && dParser(fra.Mz) == mz) return false;
            }
            return true;
        }
        //clear
        private void clearList()
        {
            //plotCentr_chkBox.Checked = false; plotFragProf_chkBox.Checked = false; plotFragCent_chkBox.Checked = false;
            loaded_lists = ""; show_files_Btn.ToolTipText = "";
            factor_panel.Controls.Clear();
            if (Fragments2.Count == 0 || all_data.Count < 2) return;
            if (IonDraw.Count > 0) IonDraw.Clear();
            selectedFragments.Clear();
            Fragments2.Clear();
            //plotFragProf_chkBox.Enabled = false; plotFragCent_chkBox.Enabled = false;
            custom_colors.Clear(); custom_colors.Add(exp_color);
            aligned_intensities.Clear();
            all_data_aligned.Clear();
            fitted_results.Clear();
            if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
            //fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;
            powerSet.Clear(); powerSet_distroIdx.Clear();
            summation.Clear(); residual.Clear();
            all_data.RemoveRange(1, all_data.Count - 1);
            if (frag_tree != null)
            {
                frag_tree.Nodes.Clear(); frag_tree.Visible = false;
            }
            if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Visible = false; fragTypes_toolStrip.Visible = false; fragStorage_Lbl.Visible = false; }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            //fit_sel_Btn.Enabled = false; fit_Btn.Enabled = false; fit_chkGrpsBtn.Enabled = fit_chkGrpsChkFragBtn.Enabled = false;            
            recalculate_all_data_aligned();
        }
        #endregion

        #region FILTER list fragments       
        /// <summary>
        /// ppm filter applied when the user refreshes the Fragment List 
        /// </summary>
        private bool decision_algorithm2(FragForm fra)
        {
            if (experimental.Count == 0) return true;
            // all the decisions if a fragment is canidate for fitting
            bool fragment_is_canditate = true;
            double temp_pp = ppmError;
            // decide how many peaks will be involved in the selection process
            // results = {[resol1, ppm1], [resol2, ppm2], ....}
            List<double[]> results = new List<double[]>();

            int total_peaks = fra.Centroid.Count;
            int contrib_peaks = 0;
            int rule_idx = Array.IndexOf(selection_rule, true);

            if (!entire_spectrum)
            {
                double mz = dParser(fra.Mz);
                foreach (ppm_area area in ppm_regions)
                {
                    if (area.Chk)
                    {
                        if (mz > area.Min && mz < area.Max)
                        {
                            temp_pp = area.Max_ppm;
                            rule_idx = area.Rule;
                        }
                    }
                }
            }

            if (rule_idx < 3) contrib_peaks = rule_idx + 1;   // hard limit, one two or three peaks
            else
            {
                if (rule_idx == 3) contrib_peaks = total_peaks / 2;                 // Total 8, use 4. Total 7, use 3
                else if (rule_idx == 4) contrib_peaks = total_peaks / 2 - 1;        // Total 8, use 3. Total 7, use 2
                else if (rule_idx == 5) contrib_peaks = total_peaks / 2 + 1;        // Total 8, use 5. Total 7, use 4
            }

            // sanity check. No matter what, check at least most intense peak!
            if (contrib_peaks == 0) contrib_peaks = 1;
            if (contrib_peaks > fra.Centroid.Count) { contrib_peaks = fra.Centroid.Count; }
            for (int i = 0; i < contrib_peaks; i++)
            {
                double[] tmp = ppm_calculator(fra.Centroid[i].X);

                if (Math.Abs(tmp[0]) < temp_pp) results.Add(tmp);
                else
                {
                    fragment_is_canditate = false;
                    if (results.Count == 0) results.Add(tmp);
                    break;
                }
            }

            // Prog: Very important memory leak!!! Clear envelope and isopatern of unmatched fragments to reduce waste of memory DURING calculations!
            if (!fragment_is_canditate && !ignore_ppm_refresh) { fra.Profile.Clear(); return false; }

            fra.PPM_Error = results.Average(p => p[0]);
            if (results.Count > 1)
            {
                fra.maxPPM_Error = results.Max(p => p[0]);
                fra.minPPM_Error = results.Min(p => p[0]);
            }
            else
            {
                fra.maxPPM_Error = 0.0; fra.minPPM_Error = 0.0;
            }
            return fragment_is_canditate;
        }
        private void refresh_frag_Btn2_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked)
            {
                MessageBox.Show("Refreshes Fragment list based on the 'Filter' settings(ppm and 'Exclusion List').\r\n" +
"Attention:for each fragment ppm is recalculated and if it is not within the new ppm bound the fragment is disposed, unless it is set otherwise on the 'Filter' settings by enabling 'ignore ppm' button.\r\nAnytime fragment list entries change 'Fit Results' are disposed, as they no longer correspond to the new list.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (experimental.Count == 0 && exclude_a_indexes.Count == 0 && exclude_b_indexes.Count == 0 && exclude_c_indexes.Count == 0 && exclude_x_indexes.Count == 0 && exclude_y_indexes.Count == 0 && exclude_z_indexes.Count == 0 && exclude_internal_indexes.Count == 0) { MessageBox.Show("You have to load the experimental data first in order to refresh the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (Fragments2.Count == 0) { return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?", "Refresh Fragment List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK) { return; }
            int initial_count = Fragments2.Count;
            int rr = 0;
            bool first = true;
            if (Fragments2.Count > 0)
            {
                while (rr < Fragments2.Count)
                {
                    Fragments2[rr].Candidate = true;
                    if (is_in_excluded_bounds(Fragments2[rr]))
                    {
                        Fragments2.RemoveAt(rr);
                        if (first && selectedFragments != null && selectedFragments.Count > 0) { first = false; selectedFragments.Clear(); }
                    }
                    else if (!decision_algorithm2(Fragments2[rr]))
                    {
                        if (ignore_ppm_refresh) { Fragments2[rr].Candidate = false; rr++; }
                        else
                        {
                            Fragments2.RemoveAt(rr);
                            if (first && selectedFragments != null && selectedFragments.Count > 0) { first = false; selectedFragments.Clear(); }
                        }
                    }
                    else { rr++; }
                }
                frags_maxFactor();
                // thread safely fire event to continue calculations
                Invoke(new Action(() => OnEnvelopeCalcCompleted()));
            }
            if (initial_count == Fragments2.Count) { MessageBox.Show("Fragment list hasn't changed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            else
            {
                factor_panel.Visible = false;
                bigPanel.Enabled = false;
                uncheckall_Frag();
                fitted_results.Clear(); selectedFragments.Clear();
                if (all_fitted_results != null) { all_fitted_results.Clear(); all_fitted_sets.Clear(); }
                if (fit_tree != null)
                {
                    fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed. Fit results are disposed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (IonDraw.Count > 0) IonDraw.Clear();
            foreach (FragForm fra in Fragments2)
            {
                if (fra.Fixed)
                {
                    IonDraw.Add(new ion() { Has_adduct = fra.Has_adduct, Extension = fra.Extension, SortIdx = fra.SortIdx, Name = fra.Name, Mz = fra.Mz, PPM_Error = fra.PPM_Error, maxPPM_Error = fra.maxPPM_Error, minPPM_Error = fra.minPPM_Error, Charge = fra.Charge, Index = Int32.Parse(fra.Index), IndexTo = Int32.Parse(fra.IndexTo), Ion_type = fra.Ion_type, Max_intensity = fra.Max_intensity * fra.Factor, Color = fra.Color.ToColor(), Chain_type = fra.Chain_type });
                }
            }
        }
        private void frag_sort_Btn2_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked)
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
            Filters_Form frm19 = new Filters_Form(this, help_Btn.Checked);
            frm19.ShowDialog();
        }
        #endregion

        #region FORM 9 fragment calculator
        private void fragCalc_Btn2_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Opens Fragment Calculator Panel.\r\n" +
                "In the areas of the experimental spectrum where the user hasn’t found the suitable fragment," +
                "the Fragment Calculator Panel is used. For a specified m / z range with a" +
                " narrower ppm filter, the user follows the initial calculation procedure to detect fragments" +
                " that were eliminated by the initially applied ppm filter. If a fragment generated by the" +
                "fragment calculator is considered suitable,it is inserted in the Fragment List. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            foreach (Form frm in Application.OpenForms)
                if (frm.Name == "Form9")
                {
                    frm.BringToFront(); return;
                }

            ExtraFragCalculator frag_Calc_form = new ExtraFragCalculator(this, help_Btn.Checked);
            frag_Calc_form.Show();
        }
        public void recalc_frm9(int prev_count, int curr_count)
        {
            //if (!plotFragProf_chkBox.Enabled) { plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true; }
            //recalculate_all_data_aligned();
            Thread recalc = new Thread(() => refresh_all_data_aligned(prev_count, curr_count));
            recalc.Start();
        }
        public void refresh_all_data_aligned(int prev_count, int curr_count)
        {
            if (all_data_aligned.Count == 0) { recalculate_all_data_aligned(); return; }
            is_frag_calc_recalc = true;
            List<double[]> aligned_intensities = new List<double[]>();
            List<int> aux_idx = new List<int>();
            progress_display_start(all_data[0].Count, "Preparing data for fit...");
            // generate alligned (in m/z) isotope distributions at the same step as the experimental
            // pickup each point in experimental and find (interpolate) the intensity of each fragment
            int progress = 0;
            try
            {
                Parallel.For(0, all_data[0].Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                {
                    if (i < all_data_aligned.Count)
                    {
                        // one by one for all points
                        List<double> one_aligned_point = all_data_aligned[i].ToList();

                        //we set the vestor entry to null in order to release memory
                        all_data_aligned[i] = null;
                        if (prev_count != 0) { one_aligned_point.RemoveRange(one_aligned_point.Count - prev_count, prev_count); }

                        double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo ta experimental ola ta x-->m/z
                        for (int j = curr_count; j > 0; j--)
                        {
                            int distro_idx = all_data.Count - j;
                            // interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                            double aligned_value = 0.0;
                            if ((mz_toInterp > all_data[distro_idx][all_data[distro_idx].Count - 1][0]) || (mz_toInterp < all_data[distro_idx][0][0]))
                            {
                                aligned_value = 0.0;
                            }
                            else
                            {
                                int[] pair = new int[2];
                                pair = find_closest(mz_toInterp, all_data[distro_idx]);
                                if (pair[0] - pair[1] == 0.00) { aligned_value = all_data[distro_idx][pair[0]][1]; }
                                else { aligned_value = interpolate(all_data[distro_idx][pair[0]][0], all_data[distro_idx][pair[0]][1], all_data[distro_idx][pair[1]][0], all_data[distro_idx][pair[1]][1], mz_toInterp); }
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
                        catch (Exception ex)
                        {
                            Debug.WriteLine("progress: " + progress.ToString() + "  " + i.ToString() + " X " + all_data[0][i][0].ToString() + " Y " + all_data[0][i][1].ToString() + "  " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occured while processing Data. Save your results and and restart the procedure. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                });
            }
            catch (Exception eeee)
            {
                MessageBox.Show(eeee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // sort by mz the aligned intensities list (global) beause it is mixed by multi-threading
            int sort_idx = 0;
            all_data_aligned.Clear();
            all_data_aligned = aligned_intensities.OrderBy(d => aux_idx[sort_idx++]).ToList();
            progress_display_stop();
            is_frag_calc_recalc = false;
            Invoke(new Action(() => OnRecalculate_completed()));
        }
        public void external_refresh_isoplot()
        {
            refresh_iso_plot();
        }
        public void add_frag_frm9()
        {
            selectedFragments.Clear();
            Invoke(new Action(() => OnEnvelopeCalcCompleted()));
            //plotFragProf_chkBox.Enabled = true; plotFragCent_chkBox.Enabled = true;
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; MessageBox.Show("Fragment list have changed. Fit results are disposed.", "Refresh Fragment List", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        public void zoom_to_frag_frm9(double min_x, double max_x)
        {
            LC_1.BeginUpdate();
            LC_1.ViewXY.XAxes[0].SetRange(min_x - 3, max_x + 3);
            LC_1.EndUpdate();
        }
        public void ending_frm9()
        {
            add_fragments_to_all_data();
            recalculate_all_data_aligned();
        }


        #endregion

        #region FORM 10 plot settings
        private void styleFormatBtn_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10(this);
            frm10.ShowDialog();
        }
        public void oxy_changes()
        {
            LC_1.ViewXY.XAxes[0].MajorGrid.Visible = Xmajor_grid;
            LC_1.ViewXY.XAxes[0].MinorGrid.Visible = Xminor_grid;
            LC_1.ViewXY.XAxes[0].LabelsNumberFormat = x_format + x_numformat;

            LC_1.ViewXY.YAxes[0].MajorGrid.Visible = Ymajor_grid;
            LC_1.ViewXY.YAxes[0].MinorGrid.Visible = Yminor_grid;
            LC_1.ViewXY.YAxes[0].LabelsNumberFormat = y_format + y_numformat;


            LC_2.ViewXY.XAxes[0].MajorGrid.Visible = Xmajor_grid;
            LC_2.ViewXY.XAxes[0].MinorGrid.Visible = Xminor_grid;
            LC_2.ViewXY.XAxes[0].LabelsNumberFormat = x_format + x_numformat;


            LC_2.ViewXY.YAxes[0].MajorGrid.Visible = Ymajor_grid;
            LC_2.ViewXY.YAxes[0].MinorGrid.Visible = Yminor_grid;
            LC_2.ViewXY.YAxes[0].LabelsNumberFormat = y_format + y_numformat;
        }
        #endregion
                

        #region UI
        public void change_Fragment(FragForm fra, int index)
        {
            Fragments2[index].Name = fra.Name;
            Fragments2[index].Ion_type = fra.Ion_type;
            Fragments2[index].IndexTo = fra.IndexTo;
            Fragments2[index].SortIdx = fra.SortIdx;
            Fragments2[index].Index = fra.Index;
            Fragments2[index].Fixed = fra.Fixed;
            Fragments2[index].Has_adduct = fra.Has_adduct;
            List<TreeNode> all_nodes_frag_tree = get_all_nodes(frag_tree);
            TreeNode curr_node1 = all_nodes_frag_tree.FirstOrDefault(n => n.Name == (index).ToString());
            curr_node1.Text = Fragments2[index].Name + "  -  " + Fragments2[index].Mz + "  -  " + Fragments2[index].InputFormula + "  -  " + Fragments2[index].PPM_Error.ToString("0.##") + "  -  " +
                                       (Fragments2[index].Factor * Fragments2[index].Max_intensity).ToString("0");
            List<TreeNode> all_nodes_frag_types = get_all_nodes(fragTypes_tree);
            TreeNode curr_node2 = all_nodes_frag_types.FirstOrDefault(n => n.Name == (index).ToString());
           if(curr_node2!=null) curr_node2.Text = Fragments2[index].Name + "  -  " + Fragments2[index].Mz + "  -  " + Fragments2[index].InputFormula + "  -  " + Fragments2[index].PPM_Error.ToString("0.##") + "  -  " +
                                       (Fragments2[index].Factor * Fragments2[index].Max_intensity).ToString("0");
        }
        private void enable_UIcontrols(string status)
        {
            if (status == "post load")
            {
                //Fitting_chkBox.Enabled = true;
                Fitting_chkBox.Checked = false;
            }
            else if (status == "post import fragments")
            {

            }
            else if (status == "post calculations")
            {
                //fit_Btn.Enabled = fit_sel_Btn.Enabled = true;
            }
        }
        private void Initialize_UI()
        {            
            plotExp_chkBox.CheckedChanged += (s, e) => {  if (/*!exp_deconvoluted &&*/ (!block_plot_refresh)) { refresh_iso_plot(); } /*else if(plotExp_chkBox.Checked) { plotExp_chkBox.Checked = false; }*/ };
            plotCentr_chkBox.CheckedChanged += (s, e) => {  if (!block_plot_refresh) refresh_iso_plot(); };
            plotFragCent_chkBox.CheckedChanged += (s, e) => { if (!block_plot_refresh) refresh_iso_plot(); };
            plotFragProf_chkBox.CheckedChanged += (s, e) => {  if (!block_plot_refresh) refresh_iso_plot(); };
            _lvwItemComparer = new ListViewItemComparer();
            machine_sel_index = 9;
            filename_txtBx.Text = file_name;                  
        }             
        private void export_copy_plot(bool copy, PlotView plot)
        {
            if (copy)
            {
                var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Height, Background = OxyColors.White, Resolution = 200 };
                var bitmap = pngExporter.ExportToBitmap(plot.Model);
                Clipboard.SetImage(bitmap);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("The default image format is png. Do you want svg format?", "File Format", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
            if (help_Btn.Checked) { MessageBox.Show("Save checked fragments to a .fit file.\r\nIn case heavy chain or light chain or both are present the extension is .hfit, .lfit, .hlfit accordingly.\r\n" +
                "For each fragment multiple information are saved, including ppm error in current experimental spectrum and resolution.\r\n" +
                "Moreover,if the Profile and Centroids of each fragment ('Envipat' Calculations) are saved an 'i' is added to the extension, for example .ifit, .hifit, .lifit, .hlifit.\r\n" +
                "Only the saved fragments are presented in the Peak Finder diagrams tabs.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (Fragments2.Count == 0) { MessageBox.Show("Fragment list is empty. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (selectedFragments.Count == 0) { MessageBox.Show("You have to check fragments first and then select save. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            frag_types_save = false;
            saveList();
        }       
        private void loadFragmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Loads fragments from a fit file.\r\nFor each fragment ppm error and resolution are not recalculated based on the experimental file.\r\n" +
                "In case the experimental file is different from the file that these fragments were calculated at, it is suggested to select the button '"+ loadFragmentsAndRecalculateResolutionToolStripMenuItem.Text+"'.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (fitted_results.Count!=0 || all_fitted_results != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?\r\nWhen 'Fragment list' changes 'Fit results' are automatically disposed.", "Load Fragment List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    is_recalc_res = false;
                    loadList();
                }
                else { return; }             
            }
            else
            {
                is_recalc_res = false;
                loadList();
            }           
           
        }
        private void loadFragmentsAndRecalculateResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Loads fragments from a fit file.\r\nFor each fragment ppm error and resolution are recalculated based on the experimental file.\r\n" +
                "In case the experimental file is identified as the file that these fragments were calculated at, it is suggested to select the button '" + loadFragmentsToolStripMenuItem.Text + "' for optimization.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (!insert_exp) { MessageBox.Show("You must first load the experimental data for this action!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (fitted_results.Count != 0 || all_fitted_results != null)
            { 
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed? \r\nWhen 'Fragment list' changes 'Fit results' are automatically disposed.", "Load Fragment List and recalculate resolution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    is_recalc_res = true;
                    loadList();
                }
                else 
                {
                    return;
                }
            }
            else
            {
                is_recalc_res = true;
                loadList();
            }
        }
        private void clearListBtn11_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Deletes all fragments.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (Fragments2.Count==0) {return;}
            if (is_frag_calc_recalc) { MessageBox.Show("Please try again in a few seconds.", "Processing in progress.", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?", "Clear Fragment List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0)
                {
                    int count = ExtraFragCalculator.last_plotted.Count;
                    all_data.RemoveRange(all_data.Count - ExtraFragCalculator.last_plotted.Count, ExtraFragCalculator.last_plotted.Count); custom_colors.RemoveRange(custom_colors.Count - ExtraFragCalculator.last_plotted.Count, ExtraFragCalculator.last_plotted.Count);
                    ExtraFragCalculator.last_plotted.Clear();
                    recalc_frm9(count, ExtraFragCalculator.last_plotted.Count);
                }
                clearList();
            }
            else return;
        }
        private void toggle_toolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("When checked fully expands the tree view to show all nodes. \r\nWhen un-checked collapses the tree view to hide sub-nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);  }

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
            if (help_Btn.Checked) { MessageBox.Show("Checks all nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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
            if (help_Btn.Checked) { MessageBox.Show("Un-checks all nodes.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (fit_tree != null) uncheck_all(fit_tree, false);
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
        private void extractPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked){MessageBox.Show("Exports current spectrum image in a new window.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;}
            plotview_rebuild();
        }
        private void seqBtn_Click(object sender, EventArgs e)
        {
            Sequence_Form frm16 = new Sequence_Form(this, help_Btn.Checked);
            frm16.ShowDialog();
        }
        private void statistics_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Displays the coverage percent of the experimental by the theoretical data.\r\n" +
                "Each ion type's contribution is analytically shown.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            string message_string = String.Empty;
            StringBuilder sb = new StringBuilder();
            List<int> fragstatistics = new List<int>();
            List<int> fragstatistics_a = new List<int>();
            List<int> fragstatistics_b = new List<int>();
            List<int> fragstatistics_c = new List<int>();
            List<int> fragstatistics_x = new List<int>();
            List<int> fragstatistics_y = new List<int>();
            List<int> fragstatistics_z = new List<int>();
            List<int> fragstatistics_d= new List<int>();
            List<int> fragstatistics_v = new List<int>();
            List<int> fragstatistics_w = new List<int>();
            List<int> fragstatistics_inter1 = new List<int>();
            List<int> fragstatistics_inter2 = new List<int>();
            List<int> fragstatistics_M = new List<int>();
            List<int> fragstatistics_B = new List<int>();

            string[] frag_temp = view_frag.ToArray();
            foreach (int idx in selectedFragments)
            {
                string ion = Fragments2[idx - 1].Ion_type;
                if (ion.StartsWith("a") || ion.StartsWith("(a"))
                {
                    if (frag_temp.Any(p => p.Equals("a"))) { fragstatistics.Add(idx); fragstatistics_a.Add(idx); }
                }
                else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                {
                    if (frag_temp.Any(p => p.Equals("b"))) { fragstatistics.Add(idx); fragstatistics_b.Add(idx); }
                }
                else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                {
                    if (frag_temp.Any(p => p.Equals("c"))) { fragstatistics.Add(idx); fragstatistics_c.Add(idx); }
                }
                else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                {
                    if (frag_temp.Any(p => p.Equals("x"))) { fragstatistics.Add(idx); fragstatistics_x.Add(idx); }
                }
                else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                {
                    if (frag_temp.Any(p => p.Equals("y"))) { fragstatistics.Add(idx); fragstatistics_y.Add(idx); }
                }
                else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                {
                    if (frag_temp.Any(p => p.Equals("z"))) { fragstatistics.Add(idx); fragstatistics_z.Add(idx); }
                }
                else if (!is_riken && ion.Contains("int") && ion.Contains("b"))
                {
                    if (frag_temp.Any(p => p.Equals("internal b"))) { fragstatistics.Add(idx); fragstatistics_inter2.Add(idx); }
                }
                else if (!is_riken && ion.Contains("int"))
                {
                    if (frag_temp.Any(p => p.Equals("internal a"))) { fragstatistics.Add(idx); fragstatistics_inter1.Add(idx); }
                }
                else if (is_riken && ion.Contains("int"))
                {
                    if (frag_temp.Any(p => p.Equals("internal"))) { fragstatistics.Add(idx); fragstatistics_inter1.Add(idx); }
                }
                else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                {
                    if (frag_temp.Any(p => p.Equals("d"))) { fragstatistics.Add(idx); fragstatistics_d.Add(idx); }
                }
                else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                {
                    if (frag_temp.Any(p => p.Equals("w"))) { fragstatistics.Add(idx); fragstatistics_w.Add(idx); }
                }
                else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                {
                    if (frag_temp.Any(p => p.Equals("v"))) { fragstatistics.Add(idx); fragstatistics_v.Add(idx); }
                }
                else if (ion.Contains("M"))
                {
                    if (frag_temp.Any(p => p.Equals("M"))) { fragstatistics.Add(idx); fragstatistics_M.Add(idx); }
                }
                else if (ion.Contains("B("))
                {
                    if (frag_temp.Any(p => p.Equals("B"))) { fragstatistics.Add(idx); fragstatistics_B.Add(idx); }
                }
                else
                {
                    fragstatistics.Add(idx); 
                }
            }
            double sumExp = 0.0;
            double sumFrag = 0.0;
            double coverage = 0.0, coverage_a = 0.0, coverage_b = 0.0, coverage_c = 0.0, coverage_x = 0.0, coverage_y = 0.0, coverage_z = 0.0,
                coverage_d = 0.0, coverage_v = 0.0,coverage_w = 0.0,coverage_int1 = 0.0, coverage_int2 = 0.0, coverage_M = 0.0, coverage_B = 0.0;
            double sumFrag_a = 0.0, sumFrag_b = 0.0, sumFrag_c = 0.0, sumFrag_x = 0.0, sumFrag_y = 0.0, sumFrag_z = 0.0, sumFrag_d = 0.0,
                sumFrag_v = 0.0, sumFrag_w = 0.0, sumFrag_int1 = 0.0, sumFrag_int2 = 0.0, sumFrag_B = 0.0, sumFrag_M = 0.0;
            
            try
            {
                Parallel.For(0, 13, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount - 1 }, (i, state) =>
                {
                    if (i == 0)
                    {
                        foreach (double[] metr in all_data_aligned)
                        {
                            double temp = 0.0;
                            foreach (int indexS in fragstatistics)
                            {
                                if (metr[indexS] > 0.0 && Fragments2[indexS - 1].Factor * metr[indexS] > 1)
                                {
                                    temp += Fragments2[indexS - 1].Factor * metr[indexS];
                                }
                            }
                            if (temp > 1.0)
                            {
                                sumFrag += temp; sumExp += metr[0];
                            }
                            else if (metr[0] > min_intes)
                            {
                                sumExp += metr[0];
                            }
                        }
                        fragstatistics.Clear();
                    }
                    else if (i == 1) { sumFrag_a = calc_coverage(fragstatistics_a); fragstatistics_a.Clear(); }
                    else if (i == 2) { sumFrag_b = calc_coverage(fragstatistics_b); fragstatistics_b.Clear(); }
                    else if (i == 3) { sumFrag_c = calc_coverage(fragstatistics_c); fragstatistics_c.Clear(); }
                    else if (i == 4) { sumFrag_x = calc_coverage(fragstatistics_x); fragstatistics_x.Clear(); }
                    else if (i == 5) { sumFrag_y = calc_coverage(fragstatistics_y); fragstatistics_y.Clear(); }
                    else if (i == 6) { sumFrag_z = calc_coverage(fragstatistics_z); fragstatistics_z.Clear(); }
                    else if (i == 7) { sumFrag_d = calc_coverage(fragstatistics_d); fragstatistics_d.Clear(); }
                    else if (i == 8) { sumFrag_v = calc_coverage(fragstatistics_v); fragstatistics_v.Clear(); }
                    else if (i == 9) { sumFrag_w = calc_coverage(fragstatistics_w); fragstatistics_w.Clear(); }
                    else if (i == 10) { sumFrag_int1 = calc_coverage(fragstatistics_inter1); fragstatistics_inter1.Clear(); }
                    else if (i == 11) { sumFrag_int2 = calc_coverage(fragstatistics_inter2); fragstatistics_inter2.Clear(); }
                    else if (i == 12)
                    {
                        sumFrag_M = calc_coverage(fragstatistics_M);
                        sumFrag_B = calc_coverage(fragstatistics_B);
                        fragstatistics_M.Clear(); fragstatistics_B.Clear();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            };          
            coverage = sumFrag / sumExp;
            coverage_a = sumFrag_a / sumExp;
            coverage_b = sumFrag_b / sumExp;
            coverage_c = sumFrag_c / sumExp;
            coverage_d = sumFrag_d / sumExp;
            coverage_v = sumFrag_v / sumExp;
            coverage_w = sumFrag_w / sumExp;
            coverage_x = sumFrag_x / sumExp;
            coverage_y= sumFrag_y / sumExp;
            coverage_z = sumFrag_z / sumExp;
            coverage_int1 = sumFrag_int1 / sumExp;
            coverage_int2 = sumFrag_int2 / sumExp;
            coverage_M = sumFrag_M / sumExp;
            coverage_B = sumFrag_B / sumExp;
            sb.AppendLine("The experimental is covered by " + Math.Round(coverage * 100, 2) + "%");
            sb.AppendLine();
            sb.AppendLine("More specifically:");
            sb.AppendLine();
            if (!is_riken)
            {
                sb.AppendLine("a: " + Math.Round(coverage_a * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("b: " + Math.Round(coverage_b * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("c: " + Math.Round(coverage_c * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("x: " + Math.Round(coverage_x * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("y: " + Math.Round(coverage_y * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("z: " + Math.Round(coverage_z * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("d: " + Math.Round(coverage_d * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("v: " + Math.Round(coverage_v * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("w: " + Math.Round(coverage_w * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("internal a: " + Math.Round(coverage_int1 * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("internal b: " + Math.Round(coverage_int2 * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("M: " + Math.Round(coverage_M * 100, 2) + "%");
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("a: " + Math.Round(coverage_a * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("b: " + Math.Round(coverage_b * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("c: " + Math.Round(coverage_c * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("d: " + Math.Round(coverage_d * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("w: " + Math.Round(coverage_w * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("x: " + Math.Round(coverage_x * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("y: " + Math.Round(coverage_y * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("z: " + Math.Round(coverage_z * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("internal: " + Math.Round(coverage_int1 * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("M: " + Math.Round(coverage_M * 100, 2) + "%");
                sb.AppendLine();
                sb.AppendLine("B: " + Math.Round(coverage_B * 100, 2) + "%");
                sb.AppendLine();
            }
            if (sb != null && sb.Length > 0)
            {
                message_string = sb.ToString();
                Message_Window_Form frm17 = new Message_Window_Form(message_string);
                frm17.Text = "Experimental intensity coverage";
                frm17.ShowDialog();
            }
        }
        private double calc_coverage(List<int> fragstatistics_temp)
        {
            double sumFrag_temp = 0.0;
            foreach (double[] metr in all_data_aligned)
            {
                double temp = 0.0;
                foreach (int indexS in fragstatistics_temp)
                {
                    if (metr[indexS] > 0.0 && Fragments2[indexS - 1].Factor * metr[indexS] > 1)
                    {
                        temp += Fragments2[indexS - 1].Factor * metr[indexS];
                    }
                }
                if (temp > 1.0)
                {
                    sumFrag_temp += temp;
                }
            }
            return sumFrag_temp;
        }        
        private bool is_in_excluded_bounds(FragForm fra)
        {
            if (exclude_internal_indexes.Count==0 && exclude_a_indexes.Count == 0 && exclude_b_indexes.Count == 0 && exclude_c_indexes.Count == 0 && exclude_x_indexes.Count == 0 && exclude_y_indexes.Count == 0 && exclude_z_indexes.Count == 0 && exclude_d_indexes.Count == 0 && exclude_w_indexes.Count == 0 )
            {
                return false;
            }
            if (fra.Ion_type.Contains("int"))
            {
                bool in_bounds = true;
                int index1 = Int32.Parse(fra.Index);
                int index2 = Int32.Parse(fra.IndexTo);
                if (exclude_internal_indexes.Count > 0)
                {
                    foreach (ExcludeTypes ext in exclude_internal_indexes)
                    {
                        if ((ext.Extension != "" && recognise_extension(fra.Extension, ext.Extension)) || (ext.Extension == "" && fra.Extension == ""))
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
                if (!in_bounds) return true;

            }
            else
            {
                int index1 = fra.SortIdx;
                bool in_bounds = true;
                if ((fra.Ion_type.StartsWith("a") || fra.Ion_type.StartsWith("(a")) && exclude_a_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_a_indexes);
                }
                else if ((fra.Ion_type.StartsWith("b") || fra.Ion_type.StartsWith("(b")) && exclude_b_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_b_indexes);
                }
                else if ((fra.Ion_type.StartsWith("c") || fra.Ion_type.StartsWith("(c")) && exclude_c_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_c_indexes);
                }
                else if ((fra.Ion_type.StartsWith("x") || fra.Ion_type.StartsWith("(x")) && exclude_x_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_x_indexes);
                }
                else if ((fra.Ion_type.StartsWith("y") || fra.Ion_type.StartsWith("(y")) && exclude_y_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1,  fra, exclude_y_indexes);                   
                }
                else if ((fra.Ion_type.StartsWith("z") || fra.Ion_type.StartsWith("(z")) && exclude_z_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_z_indexes);                   
                }
                else if (is_riken&&(fra.Ion_type.StartsWith("d") || fra.Ion_type.StartsWith("(d")) && exclude_d_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_d_indexes);
                }
                else if (is_riken && (fra.Ion_type.StartsWith("w") || fra.Ion_type.StartsWith("(w")) && exclude_w_indexes.Count > 0)
                {
                    in_bounds = check_if_frag_included_exclude_list(index1, fra, exclude_w_indexes);
                }
                if (!in_bounds) return true;
            }
            return false;
        }       
       
        private void show_files_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Displays loaded Fragment files' names", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
        //plot     
        private void fragPlotLbl_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows or hides labels for ploted fragments.\r\nRight click opens a new window with all the basic ion types for which the labels are visible.\r\nThe user can check the desired ion types press 'ok' button and create his own list. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);  }
            if (frag_lbl_Btn.Checked)
            {
                //cursor_chkBx.Checked = false; refresh_iso_plot();
                List<int> to_plot = new List<int>();
                string[] frag_temp = view_frag.ToArray();
                string[] label_temp = label_frag.ToArray();

                // add only the desired fragments to to_plot
                foreach (int idx in selectedFragments)
                {
                    string ion = Fragments2[idx - 1].Ion_type;
                    if (ion.StartsWith("a") || ion.StartsWith("(a"))
                    {
                        if (frag_temp.Any(p => p.Equals("a"))&& label_temp.Any(p => p.Equals("a"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                    {
                        if (frag_temp.Any(p => p.Equals("b")) && label_temp.Any(p => p.Equals("b"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                    {
                        if (frag_temp.Any(p => p.Equals("c")) && label_temp.Any(p => p.Equals("c"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                    {
                        if (frag_temp.Any(p => p.Equals("x")) && label_temp.Any(p => p.Equals("x"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                    {
                        if (frag_temp.Any(p => p.Equals("y")) && label_temp.Any(p => p.Equals("y"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                    {
                        if (frag_temp.Any(p => p.Equals("z")) && label_temp.Any(p => p.Equals("z"))) { to_plot.Add(idx); }
                    }
                    else if (ion.Contains("int") && ion.Contains("b"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal b")) && label_temp.Any(p => p.Equals("internal b"))) { to_plot.Add(idx); }
                    }
                    else if (!is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal a")) && label_temp.Any(p => p.Equals("internal a"))) { to_plot.Add(idx); }
                    }
                    else if (is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal")) && label_temp.Any(p => p.Equals("internal"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                    {
                        if (frag_temp.Any(p => p.Equals("d")) && label_temp.Any(p => p.Equals("d"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                    {
                        if (frag_temp.Any(p => p.Equals("w")) && label_temp.Any(p => p.Equals("w"))) { to_plot.Add(idx); }
                    }
                    else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                    {
                        if (frag_temp.Any(p => p.Equals("v")) && label_temp.Any(p => p.Equals("v"))) { to_plot.Add(idx); }
                    }
                    else if (ion.Contains("M"))
                    {
                        if (frag_temp.Any(p => p.Equals("M")) && label_temp.Any(p => p.Equals("M"))) { to_plot.Add(idx); }
                    }
                    else if (ion.Contains("B("))
                    {
                        if (frag_temp.Any(p => p.Equals("B")) && label_temp.Any(p => p.Equals("B"))) { to_plot.Add(idx); }
                    }
                    else
                    {
                        to_plot.Add(idx);
                    }

                }
                frag_annotation(to_plot.ToList(), LC_1);
            }
            else
            {
                DisposeAllAndClear(LC_1.ViewXY.Annotations);
                refresh_iso_plot();
            }
        }
        private void zoomIn_Y_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Zoom In only on Y axis, X axis range is constant.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            //Disable rendering, strongly recommended before updating chart properties
            LC_1.BeginUpdate();
            for (int ii=0;ii< LC_1.ViewXY.YAxes.Count-1; ii++)
            {
                AxisY axisY = LC_1.ViewXY.YAxes[ii];
                axisY.SetRange(axisY.Minimum / 2.0, axisY.Maximum / 2.0);
            }            
            //Allow chart rendering
            LC_1.EndUpdate();
        }
        private void zoomOut_Y_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Zoom Out only on Y axis, X axis range is constant.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            //Disable rendering, strongly recommended before updating chart properties
            LC_1.BeginUpdate();
            for (int ii = 0; ii < LC_1.ViewXY.YAxes.Count - 1; ii++)
            {
                AxisY axisY = LC_1.ViewXY.YAxes[ii];
                axisY.SetRange(axisY.Minimum * 2.0, axisY.Maximum * 2.0);
            }           
            //Allow chart rendering
            LC_1.EndUpdate();
        }
       
        private void displayIonTypesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ion_types_Form f = new Ion_types_Form(this, false);
            f.Location = MousePosition;
            f.ShowDialog();
        }
        private void frag_lbl_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frag_lbl_contextMenuStrip1.Show(toolStrip_plot, toolStrip_plot.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            }
        }
        private void view_fragBtn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Opens a new window with all the basic ion types of the visible fragments.\r\nThe user can check the desired ion types press 'ok' button and create his own list. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            Ion_types_Form f = new Ion_types_Form(this, true);
            f.Location = MousePosition;
            f.ShowDialog();
        }
        //MS product       
        private void deleteAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChemFormulas.Count > 0) { ChemFormulas.Clear(); }
            if (loaded_MSproducts.Count > 0) { loaded_MSproducts.Clear(); }
            if (MSproduct_treeView.Nodes.Count > 0) { MSproduct_treeView.Nodes.Clear(); }
            MSproduct_treeView.Visible = false;
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChemFormulas.Count == 0) return;
            if (MSproduct_treeView.Nodes[0].Nodes.Count == 1)
            {
                ChemFormulas.Clear();
                if (loaded_MSproducts.Count > 0) { loaded_MSproducts.Clear(); }
                MSproduct_treeView.Nodes.Clear();
                MSproduct_treeView.Visible = false;
            }
            else if (MSproduct_treeView.SelectedNode != null)
            {
                string[] str = MSproduct_treeView.SelectedNode.Text.Split('_');
                MSproduct_treeView.Nodes[0].Nodes.Remove(MSproduct_treeView.SelectedNode);
                string exte = "";
                if (str.Length > 1)
                {
                    exte = str.Last();
                    for (int h = 0; h < loaded_MSproducts.Count; h++)
                    {
                        string[] str1 = loaded_MSproducts[h].Split('_');
                        if (str1.Length > 1 && str1.Last().Equals(exte)) { loaded_MSproducts.RemoveAt(h); break; }
                    }
                }
                else
                {
                    for (int h = 0; h < loaded_MSproducts.Count; h++)
                    {
                        string[] str1 = loaded_MSproducts[h].Split('_');
                        if (str1.Length > 1 && str1.Last().Equals(exte)) { loaded_MSproducts.RemoveAt(h); break; }
                        else if (str1.Length == 1) { loaded_MSproducts.RemoveAt(h); break; }
                    }
                }
                int rr = 0;
                while (rr < ChemFormulas.Count)
                {
                    if (ChemFormulas[rr].Extension.Equals(exte) || ChemFormulas[rr].Extension.Equals("_" + exte))
                    {
                        ChemFormulas.RemoveAt(rr);
                    }
                    else { rr++; }
                }
                MessageBox.Show("Extension ' " + exte + " ' removed from MS product files", "MS Product", MessageBoxButtons.OK);
            }

        }
        private void autoscale_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Enables or disables automatic scaling of intensity axis with padding of 10% of the maximum intensity value", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
        //help
        private void losses_check1_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Unless the user enables the 'losses' selection, the fragments' losses are not included in the calculations. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
        private void log_check1_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("When checked, the Y Axis is logarithmic. The default state is checked. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
        private void primary_fragments_plots_Click(object sender, EventArgs e)
        {
            //if (help_Btn.Checked)
            //{
            string t = "amino - acid";
            if (is_riken) t = "base";
            MessageBox.Show("Primary fragments plots’ include :\r\n -An intensity - residue number(index) in the " + t + " sequence plot.If one " +
                "or more fragments share the same index and primary ion type the sum of their " +
                "intensities is displayed to the user.\r\n -A charge state - residue number(index) in the " + t + " sequence plot.If " +
                "one or more fragments share the same index, primary ion type and charge " +
                "state the sum of their intensities is displayed to the user.The size of the charge " +
                "point in the scatter plot is in accordance with the order of magnitude of its " +
                "intensity.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            //}

        }
        private void idxPlotLbl_Click(object sender, EventArgs e)
        {
            //if (help_Btn.Checked)
            //{
            string t = "amino - acid";
            if (is_riken) t = "base";
            MessageBox.Show("Internal fragments’ plots include a diagram with the initial and terminal residue " +
            "number(index) in the " + t + " sequence plot, combined with the intensity of each " +
            "represented number.The same diagram is plotted twice at first by sorting the internal " +
            "fragments in ascending initial index order and secondly in ascending terminal index " +
            "order ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            //}
        }
        private void losses_label_Click(object sender, EventArgs e)
        {
            //if (help_Btn.Checked)
            //{
            string t = "amino - acid";
            if (is_riken) t = "base";
            MessageBox.Show("Intramolecular Hydrogen Atom Rearrangements are represented in a k - residue number(index) in the " + t + " sequence plot." +
                "\r\n\r\nk=𝐼[𝑏±𝑛𝐻]/𝐼[𝑏]\r\n\r\nThe parameters’ references are as followed:\r\n𝐼[]=intensity\r\n𝑏±𝑛𝐻= fragment with Hydrogen add or loss(ex: a + 1)\r\n𝑏= primary fragment of the same index and charge as 𝑏±𝑛𝐻" +
                "\r\n\r\nFor each ion type there are two plot types :\r\nPlus plots, ex: a+1, a+2\r\nMinus plots, ex: a-1, a-2\r\n", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            //}
        }
        #endregion

        #region Fitting-Calculation Options
        private void Fitting_chkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("When checked the summation of the plotted fragments is displayed in spectrum area with a dashed line.\r\nThe type and the color of the line can be changed in Format Plot Area>Style panel", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if(!block_plot_refresh)refresh_iso_plot();
        }                     
        private void Form2_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void add_machine(bool exp_resolution = false)
        {
            string name = "";
            if (exp_resolution == true)  name = "resolution from file" + exp_res.ToString(); 
            else return;
            if (is_riken)
            {
                Helpers.CloseForm("Form24_2");
                for (int i1 = 0; i1 < machine_listBox1.Items.Count; i1++)
                {
                    string m = (string)machine_listBox1.Items[i1];
                    if (m.Equals(name)) { return; }
                }
                machine_listBox1.ClearSelected();
                machine_listBox1.Items.Add(name);  
                machine_listBox1.SelectedItem = name;
                machine_sel_index = machine_listBox1.SelectedIndex;
            }
            else
            {
                Helpers.CloseForm("Form24");
                for (int i1 = 0; i1 < machine_listBox.Items.Count; i1++)
                {
                    string m = (string)machine_listBox.Items[i1];
                    if (m.Equals(name)) { return; }
                }
                machine_listBox.ClearSelected();
                machine_listBox.Items.Add(name);
                machine_listBox.SelectedItem = name;
                machine_sel_index = machine_listBox.SelectedIndex;
            }
        }
        #endregion

        #endregion

        #region TAB DIAGRAMS
        #region class init
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
        public class CustomDataPoint : IScatterPointProvider
        {
            public double X { get; set; }
            public double Y { get; set; }
            public string Xreal { get; set; }
            public string Text { get; set; }
            public string Name { get; set; }
            public ScatterPoint GetScatterPoint() => new ScatterPoint(X, Y);
            public CustomDataPoint(double x, double y, string xreal, string t, string n)
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
            public string Mz { get; set; }



            public DataPoint GetDataPoint() => new DataPoint(X, Y);
            public CustomDataPointIndex(double x, double y, string ionreal, string t, string c, string i,string mz)
            {
                X = x;
                Y = y;
                Ion = ionreal;
                Index = t;
                Charge = c;
                Intensity = i;
                Mz = mz;
            }
        }
        class CI : IComparer<ion>
        {
            public int Compare(ion x, ion y)
            {

                //if (x.Ion_type == y.Ion_type)
                //{
                if (x.SortIdx == y.SortIdx)
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
        class CI_mass : IComparer<ion>
        {
            public int Compare(ion x, ion y)
            {
                decimal x_mass = (decimal)dParser(x.Mz);
                decimal y_mass = (decimal)dParser(y.Mz);
                return Decimal.Compare(x_mass, y_mass);
            }
        }
        #endregion

        #region UI
        private void tabFit_Leave(object sender, EventArgs e)
        {
            if (sequenceList != null && sequenceList.Count > 1)
            {
                seq_extensionBox.Enabled = seq_extensionBoxCopy1.Enabled = seq_extensionBoxCopy2.Enabled = true;
                if (seq_extensionBox.Items == null || seq_extensionBox.Items.Count == 0)
                {
                    foreach (SequenceTab seq in sequenceList)
                    {
                        seq_extensionBox.Items.Add(seq.Extension);
                        seq_extensionBoxCopy1.Items.Add(seq.Extension);
                        seq_extensionBoxCopy2.Items.Add(seq.Extension);
                    }
                }
                else
                {
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (!seq_extensionBox.Items.Contains(seq.Extension))
                        {
                            seq_extensionBox.Items.Add(seq.Extension);
                            seq_extensionBoxCopy1.Items.Add(seq.Extension);
                            seq_extensionBoxCopy2.Items.Add(seq.Extension);

                        }
                    }
                    int k = 0;
                    while (k < seq_extensionBox.Items.Count)
                    {
                        if (!sequenceList.Any(p => p.Extension.Equals(seq_extensionBox.Items[k].ToString())))
                        {
                            seq_extensionBox.Items.RemoveAt(k);
                            seq_extensionBoxCopy1.Items.RemoveAt(k);
                            seq_extensionBoxCopy2.Items.RemoveAt(k);
                        }
                        else k++;
                    }
                }

            }
            else
            {
                seq_extensionBox.Enabled = seq_extensionBoxCopy1.Enabled = seq_extensionBoxCopy2.Enabled = false;
            }
            initialize_ions_todraw(); initialize_plot_tabs();
        }             
        private void internal_style_Btn_Click(object sender, EventArgs e)
        {
            foreach (SequenceTab seq in sequenceList)
            {
                if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                {
                    color_internal_indexes = seq.Index_SS_internal.ToList();
                    break;
                }
            }
            Form13 frm13 = new Form13(this);
            frm13.FormClosed += (s, f) => { save_preferences(); };
            frm13.ShowDialog();
        }
        private void ppm_checkall_Btn_Click(object sender, EventArgs e)
        {
            check_un_check_ppm(true);
        }
        private void ppm_uncheckBtn_Click(object sender, EventArgs e)
        {
            check_un_check_ppm(false);
        }
        private void check_un_check_ppm(bool check=true)
        {
            block_tab_diagrams_refresh = true;
            toolstrip_checkboxes(panel2_tab2, check, "ppm");
            block_tab_diagrams_refresh = false;
            initialize_plot_tabs();
        }
        private void ppm_legend_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows or hides legend", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            ppm_plot.Model.IsLegendVisible = ppm_legend_Btn.Checked;
            ppm_plot.InvalidatePlot(true);
        }
        public void paint_annotations_in_graphs(bool all = true, int code = 1, bool is_style_open=false)
        {
            if (sequenceList == null || sequenceList.Count == 0) return;
            List<int[]> temp_primary = color_primary_indexes.ToList();
            List<int[]> temp_internal = color_internal_indexes.ToList();
            if (is_style_open)
            {
                if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
                {
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                        {
                            seq.Index_SS_primary=temp_primary.ToList();
                            seq.Index_SS_internal=temp_internal.ToList();
                            break;
                        }
                    }
                }
                else
                {
                    sequenceList[0].Index_SS_primary = temp_primary.ToList();
                    sequenceList[0].Index_SS_internal = temp_internal.ToList();
                }
            }
            else
            {
                if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
                {
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                        {
                            temp_primary = seq.Index_SS_primary.ToList();
                            temp_internal = seq.Index_SS_internal.ToList();
                            break;
                        }
                    }
                }
                else
                {
                    sequenceList[0].Index_SS_primary = temp_primary.ToList();
                    sequenceList[0].Index_SS_internal = temp_internal.ToList();
                }
            } 
            List<PlotView> plots = new List<PlotView>();
            if (all || code == 1)
            {
                plots = new List<PlotView>() { ax_plot, axCharge_plot, by_plot, byCharge_plot, cz_plot, czCharge_plot };
                if (is_riken) plots.AddRange(new List<PlotView>() { dz_plot, dzCharge_plot });
                annotations_in_plotview(plots, temp_primary, OxyColor.FromAColor(99, color_primary));
            }
            if (all || code == 2)
            {
                plots = new List<PlotView>() { index_plot, indexto_plot };
                annotations_in_plotview(plots, temp_internal, OxyColor.FromAColor(99, color_internal));
            }
        }
        private void annotations_in_plotview(List<PlotView> plots, List<int[]> indexes, OxyColor clr)
        {
            foreach (PlotView pp in plots)
            {
                pp.Model.Annotations.Clear();
                foreach (int[] region in indexes)
                {
                    pp.Model.Annotations.Add(new RectangleAnnotation { MinimumX = region[0], MaximumX = region[1], Fill = clr });
                }
                pp.InvalidatePlot(true);
            }
        }
        private void ppm_CheckedChanged(object sender, EventArgs e)
        {
            if (!block_tab_diagrams_refresh) initialize_plot_tabs(false, "ppm");
        }
        private void includeModif_Btn_CheckedChanged(object sender, EventArgs e)
        {
            initialize_plot_tabs(false, "a");
            initialize_plot_tabs(false, "b");
            initialize_plot_tabs(false, "c");
            initialize_plot_tabs(false, "d");
            initialize_plot_tabs(false, "aC");
            initialize_plot_tabs(false, "bC");
            initialize_plot_tabs(false, "cC");
            initialize_plot_tabs(false, "dC");
        }
        private void primary_styleBtn_Click(object sender, EventArgs e)
        {
            foreach (SequenceTab seq in sequenceList)
            {
                if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                {
                    color_primary_indexes = seq.Index_SS_primary.ToList();
                    break;
                }
            }
            Form12 frm12 = new Form12(this, 0);
            frm12.FormClosed += (s, f) => { save_preferences(); };
            frm12.ShowDialog();
        }
        private void panel1_tab2_MouseDown(object sender, MouseEventArgs e)
        {
            CloseForm("Form_matrix");
        }

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
        #endregion

        #region sequence
        //sequence toolstrip
        private void highlightProp_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Displays the 'Heatmap options' panel. The user can select the color scale," +
                " the maximum and minimum values of the scale, and the amount of regions between the two intensity bounds. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);  }
            Form23 frm23 = new Form23(this);
            frm23.FormClosed += (s, f) =>
            {
                sequence_Pnl.Refresh(); sequence_PnlCopy1.Refresh(); sequence_PnlCopy2.Refresh();
                color_range_panel.Refresh(); color_range_panelCopy1.Refresh(); color_range_panelCopy2.Refresh();
                seq_lbl_panel.Refresh(); seq_lbl_panelCopy1.Refresh(); seq_lbl_panelCopy2.Refresh();
            };
            frm23.ShowDialog();
        }
        private void seq_coverageBtn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Calculates the statistical sequence coverage by each ion type and in total. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            string message_string = String.Empty;
            bool include_primary = seq_primary_chkBx.Checked;
            bool include_modified = seq_has_adduct_chkBx.Checked;
            StringBuilder sb = new StringBuilder();
            if (sequenceList == null || sequenceList.Count == 0) { MessageBox.Show("Don't hurry.You have to add amino-acid sequence first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            foreach (SequenceTab seq in sequenceList)
            {
                if (string.IsNullOrEmpty(seq.Sequence)) continue;
                int seq_len= seq.Sequence.Length-1;
                List<int> a_cov1 = new List<int>(); List<int> b_cov1 = new List<int>(); List<int> c_cov1 = new List<int>(); List<int> x_cov1 = new List<int>(); List<int> y_cov1 = new List<int>(); List<int> z_cov1 = new List<int>(); List<int> d_cov1 = new List<int>(); List<int> w_cov1 = new List<int>();
                List<int> total_1 = new List<int>();
                double a1 = 0, b1 = 0, c1 = 0, x1 = 0, y1 = 0, z1 = 0, d1 = 0, w1 = 0, t1 = 0;
                foreach (ion nn in IonDraw)
                {
                    if (!include_modified && nn.Has_adduct) { continue; }
                    if (!include_primary && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(seq.Extension) && !recognise_extension(nn.Extension, seq.Extension)) { continue; }
                    else if (string.IsNullOrEmpty(seq.Extension) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (a_cov1.Count == 0 || !a_cov1.Contains(nn.Index)) { a_cov1.Add(nn.Index); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.Index)) { total_1.Add(nn.Index); }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (b_cov1.Count == 0 || !b_cov1.Contains(nn.Index)) { b_cov1.Add(nn.Index); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.Index)) { total_1.Add(nn.Index); }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (c_cov1.Count == 0 || !c_cov1.Contains(nn.Index)) { c_cov1.Add(nn.Index); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.Index)) { total_1.Add(nn.Index); }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (x_cov1.Count == 0 || !x_cov1.Contains(nn.SortIdx)) { x_cov1.Add(nn.SortIdx); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.SortIdx)) { total_1.Add(nn.SortIdx); }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (y_cov1.Count == 0 || !y_cov1.Contains(nn.SortIdx)) { y_cov1.Add(nn.SortIdx); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.SortIdx)) { total_1.Add(nn.SortIdx); }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (z_cov1.Count == 0 || !z_cov1.Contains(nn.SortIdx)) { z_cov1.Add(nn.SortIdx); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.SortIdx)) { total_1.Add(nn.SortIdx); }
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (d_cov1.Count == 0 || !d_cov1.Contains(nn.Index)) { d_cov1.Add(nn.Index); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.Index)) { total_1.Add(nn.Index); }
                        }
                    }
                    else if(is_riken && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")))
                    {
                        if (los_chkBox.Checked || (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")))
                        {
                            if (w_cov1.Count == 0 || !w_cov1.Contains(nn.SortIdx)) { w_cov1.Add(nn.SortIdx); }
                            if (total_1.Count == 0 || !total_1.Contains(nn.SortIdx)) { total_1.Add(nn.SortIdx); }
                        }
                    }
                }
                a1 = 100 * (double)a_cov1.Count / seq_len;
                b1 = 100 * (double)b_cov1.Count / seq_len;
                c1 = 100 * (double)c_cov1.Count / seq_len;
                x1 = 100 * (double)x_cov1.Count / seq_len;
                y1 = 100 * (double)y_cov1.Count / seq_len;
                z1 = 100 * (double)z_cov1.Count / seq_len;
                d1 = 100 * (double)d_cov1.Count / seq_len;
                w1 = 100 * (double)w_cov1.Count / seq_len;               
                t1 = 100 * (double)total_1.Count / seq_len;

                sb.AppendLine("Extension: " + seq.Extension);
                sb.AppendLine();
                if (is_riken)
                {
                    sb.AppendLine("a : " + Math.Round(a1, 0).ToString() + "%" + "\t" + "\t"+ "w : " + Math.Round(w1, 0).ToString() + "%");
                    sb.AppendLine("b : " + Math.Round(b1,0).ToString() + "%" + "\t" + "\t" + "x : " + Math.Round(x1, 0).ToString() + "%");
                    sb.AppendLine("c : " + Math.Round(c1, 0).ToString() + "%" + "\t" + "\t" + "y : " + Math.Round(y1, 0).ToString() + "%");
                    sb.AppendLine("d : " + Math.Round(d1,0).ToString() + "%" + "\t" + "\t" + "z : " + Math.Round(z1, 0).ToString() + "%");
                }
                else
                {
                    sb.AppendLine("a : " + Math.Round(a1, 0).ToString() + "%" + "\t" + "\t" + "x : " + Math.Round(x1, 0).ToString() + "%");
                    sb.AppendLine("b : " + Math.Round(b1, 0).ToString() + "%" + "\t" + "\t" + "y : " + Math.Round(y1, 0).ToString() + "%");
                    sb.AppendLine("c : " + Math.Round(c1, 0).ToString() + "%" + "\t" + "\t" + "z : " + Math.Round(z1, 0).ToString() + "%");
                }                  
                sb.AppendLine();              
                sb.AppendLine("Sequence coverage : " + Math.Round(t1, 1).ToString() + "%");
                sb.AppendLine();
            }
            if (sb != null && sb.Length > 0)
            {
                message_string = sb.ToString();
                Message_Window_Form frm17 = new Message_Window_Form(message_string,true, is_riken);
                frm17.Text = "Sequence coverage";
                frm17.ShowDialog();
            }
        }
        //mouse down
        private void sequence_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            CloseForm("Form_matrix");
            string pattern = @"[a-z][+-][1-9][0-9]?(?![(])";
            List<string[]> frags = new List<string[]>();
            List<ion> temp_iondraw = IonDraw.ToList();
            CI ion_comp = new CI();
            temp_iondraw.Sort(ion_comp);
            int x = e.X;
            int y = e.Y;
            int adduct_step1 = 0;
            Panel sequence_Pnl_temp = sender as Panel;
            Panel draw_sequence_panel_temp = sequence_Pnl_temp.Parent as Panel;
            RadioButton rdBtn50_temp = GetControls(draw_sequence_panel_temp).OfType<RadioButton>().Where(l => l.Name.Contains("rdBtn50")).ToList().FirstOrDefault();
            ComboBox seq_extensionBox_temp = GetControls(draw_sequence_panel_temp).OfType<ComboBox>().Where(l => l.Name.Contains("seq_extensionBox")).ToList().FirstOrDefault();
            Panel legend_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("legend_panel")).ToList().FirstOrDefault();
            CheckBox highlight_ibt_ckBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("highlight_ibt_ckBx")).ToList().FirstOrDefault();
            ToolStrip tsp = GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp, "_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;
            if (merged_prim_modif && is_riken) { adduct_step1 = 16; }
            else if (merged_prim_modif) { adduct_step1 = 12; }
            int temp_x_init = 3;
            int temp_y_init = 20;            
            int step_x = 20;
            int step_y = 50;
            int length_panel =0;
            if (is_riken) { temp_x_init = 5; temp_y_init = 24; step_y = 74; }           
            if(highlight_ibt_ckBx_temp.Checked) {  length_panel = -21 - 50; }
            if (legend_panel_temp.Visible) length_panel = -legend_panel_temp.Width;
             step_y += (2 * adduct_step1);
             temp_y_init += adduct_step1;
            int temp_x = temp_x_init;
            int temp_y = temp_y_init;
            string s = Peptide;
            //StringBuilder sb = new StringBuilder();
            string s_ext = "";//the desired extension
            if (sequenceList == null || sequenceList.Count == 0) return;
            SequenceTab curr_ss = sequenceList[0];
            if (tab_mode && seq_extensionBox_temp.Enabled && seq_extensionBox_temp.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox_temp.SelectedItem))
                    {
                        curr_ss = seq;
                        s = seq.Sequence; s_ext = seq.Extension;
                        break;
                    }
                }
            }
            int grp_num = 25;
            if (rdBtn50_temp.Checked) grp_num = 50;
            for (int idx = 0; idx < s.Length; idx++)
            {
                if (temp_x <= x && temp_x + step_x >= x && temp_y <= y && temp_y + 15 >= y)
                {
                    foreach (ion nn in temp_iondraw)
                    {
                        bool is_present = false;
                        bool is_primary = false;
                        string type = "";
                        string value ="";
                        if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                        else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                        if (nn.Index == idx + 1 && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c") || nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b") || nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a") || (nn.Ion_type.StartsWith("d")&&is_riken) || (nn.Ion_type.StartsWith("(d") && is_riken)))
                        {
                            is_present = true; is_primary = true;
                        }
                        else if (nn.SortIdx == idx && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z") || nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y") || nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x") || (nn.Ion_type.StartsWith("w") && is_riken) || (nn.Ion_type.StartsWith("(w") && is_riken)))
                        {
                            is_present = true; is_primary = true;
                        }
                        else if ((nn.Ion_type.StartsWith("int") || nn.Ion_type.StartsWith("(int")) && (nn.Index == idx+1  || nn.IndexTo == idx + 1))
                        {
                            is_present = true;
                        }
                        if (is_primary)
                        {
                            Match matches = Regex.Match(nn.Ion_type, pattern);
                            if (matches.Success) 
                            //if (nn.Ion_type.Contains("+1")|| nn.Ion_type.Contains("+2") || nn.Ion_type.Contains("-1") || nn.Ion_type.Contains("-2"))
                            {
                                if (nn.Ion_type.StartsWith("(")) { type = nn.Ion_type[1].ToString(); }
                                else { type = nn.Ion_type[0].ToString(); }
                                double primary_int = search_primary_return_intens(type, nn.SortIdx, s_ext, nn.Charge, temp_iondraw);
                                if (primary_int == 0) primary_int = 1.0;
                                value = (nn.Max_intensity / primary_int).ToString();
                            }                           
                        }
                        if (is_present)
                        {                            
                            frags.Add(new string[] { nn.Name, nn.Mz.ToString(), Math.Round(nn.Max_intensity, 4).ToString(), value });
                        }
                    }
                    if (frags.Count == 0)
                    {
                        MessageBox.Show("No ions match to your research", "Aminoacid: " + s[idx] + " with index: " + (idx + 1).ToString() + " (Extension: " + s_ext + ")",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        frags=frags.OrderBy(p=>p[0]).ToList();                       
                    }
                    IndexMatrix_Wnd frm_matrix = new IndexMatrix_Wnd(frags);
                    frm_matrix.Text = "Aminoacid: " + s[idx] + " with index: " + (idx + 1).ToString() + " (Extension: " + s_ext + ")";
                    frm_matrix.Show();
                    return;
                }
                else
                {
                    temp_x = temp_x + step_x;
                    if (temp_x + step_x >= sequence_Pnl.Width + length_panel) { temp_x = temp_x_init; temp_y = temp_y + step_y; }
                    if ((idx + 1) % grp_num == 0) { temp_x = temp_x_init; temp_y = temp_y + step_y; }
                }
            }
        }        
        //draw       
        private void sequence_draw_general(Graphics g,Panel draw_sequence_panel_temp)
        {
            PictureBox color_range_picBox_temp = GetControls(draw_sequence_panel_temp).OfType<PictureBox>().Where(l => l.Name.Contains("color_range_picBox")).ToList().FirstOrDefault();
            Panel color_range_panel_temp= GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("color_range_panel")).ToList().FirstOrDefault();
            Panel seq_lbl_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("seq_lbl_panel")).ToList().FirstOrDefault();
            RadioButton rdBtn50_temp = GetControls(draw_sequence_panel_temp).OfType<RadioButton>().Where(l => l.Name.Contains("rdBtn50")).ToList().FirstOrDefault();
            Panel sequence_Pnl_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("sequence_Pnl")).ToList().FirstOrDefault();
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            ComboBox seq_extensionBox_temp = GetControls(draw_sequence_panel_temp).OfType<ComboBox>().Where(l => l.Name.Contains("seq_extensionBox")).ToList().FirstOrDefault();
            Panel legend_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("legend_panel")).ToList().FirstOrDefault();
            CheckBox dvw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("dvw_chBx")).ToList().FirstOrDefault();
            ToolStrip tsp= GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp,"_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;

            if (color_range_picBox_temp.Visible) { color_range_picBox_temp.Visible = false; }
            if (color_range_panel_temp.Visible) { color_range_panel_temp.Visible = false; }
            if (seq_lbl_panel_temp.Visible){ seq_lbl_panel_temp.Visible = false;}
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            int adduct_step1 = 0;
            int adduct_step2 = 0;
            if (merged_prim_modif && is_riken) { adduct_step1 = 16; adduct_step2 = 8; }
            else if (merged_prim_modif) { adduct_step1 = 12; adduct_step2 = 8; }
            int step_x = 20;
            int step_y = 50 + (2 * adduct_step1);
            int temp_y_init = 20 + adduct_step1;
            int temp_x_init = 3;
            int length_panel = 0;
            if (legend_panel_temp.Visible) length_panel =-legend_panel_temp.Width;
             Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = temp_y_init;
            point_x = temp_x_init;
            double grp_num = 25;
            if (rdBtn50_temp.Checked) grp_num = 50;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            string s_ext = "";//the desired extension
            if (sequenceList == null || sequenceList.Count == 0) return;
            SequenceTab curr_ss = sequenceList[0];
            if (tab_mode && seq_extensionBox_temp.Enabled && seq_extensionBox_temp.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox_temp.SelectedItem))
                    {
                        curr_ss = seq;
                        s = seq.Sequence; s_ext = seq.Extension;
                        break;
                    }
                }
            }
            if (s.Length / grp_num >= (400 / (step_y + 10))) { draw_sequence_panel_temp.Height = (step_y + 10) *(int) Math.Ceiling(s.Length / grp_num); }
            else { draw_sequence_panel_temp.Height = 400; }
            Point pp = new Point(point_x, point_y);
            
            for (int idx = 0; idx < s.Length; idx++)
            {
                if (curr_ss.Char_color != null) sb.Color = curr_ss.Color_table[curr_ss.Char_color[idx]];
                draw_letter(g, s[idx].ToString(), sequence_Pnl_temp, sb, pp);
                foreach (ion nn in IonDraw)
                {
                    if (!include_modified && nn.Has_adduct) { continue; }
                    if (!include_primary && !nn.Has_adduct) { continue; }                    
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    Point temp_p = pp;
                    if (pp.X + (2* step_x) >= sequence_Pnl_temp.Width + length_panel) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = 3 - 18; temp_p.Y = temp_p.Y + step_y; }
                    int safe_dist_up = +adduct_step1, safe_dist_down = -adduct_step2 - adduct_step1;
                    bool up_adduct = false, down_adduct = false;
                    if (merged_prim_modif && nn.Has_adduct)
                    {
                        safe_dist_up = -adduct_step2 - adduct_step1; safe_dist_down = adduct_step1; up_adduct = true;
                    }
                    else if (merged_prim_modif)
                    {
                        down_adduct = true;
                    }
                    if (ax_chBx_temp.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.LimeGreen, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Green, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 0 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (by_chBx_temp.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DodgerBlue, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Blue, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 4 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (cz_chBx_temp.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.Tomato, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Firebrick, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 8 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (ax_chBx_temp.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.LimeGreen, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Green, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 0 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (by_chBx_temp.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DodgerBlue, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Blue, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 4 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (cz_chBx_temp.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.Tomato, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Firebrick, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 8 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }                  
                    else if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 2 || nn.IndexTo == idx + 1) && !los_chkBox_temp.Checked &&( intB_chBx_temp.Checked || intA_chBx_temp.Checked) && (ax_chBx_temp.Checked || by_chBx_temp.Checked || cz_chBx_temp.Checked ))
                    {
                        if (intA_chBx_temp.Checked && !nn.Ion_type.Contains("b"))
                        {
                            draw_line(pp, false, 0, nn.Color, g, true);
                        }
                        else if (intB_chBx_temp.Checked && nn.Ion_type.Contains("b"))
                        {
                            draw_line(pp, false, 0, nn.Color, g, true);
                        }
                    }
                    else if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 2 || nn.IndexTo == idx + 1) && !los_chkBox_temp.Checked &&( intB_chBx_temp.Checked || intA_chBx_temp.Checked))
                    {
                        bool is_left = false;
                        bool is_up = true;
                        bool exist = false;
                        int step = 0;
                        Color clr = Color.Orange;
                        if (intA_chBx_temp.Checked && !nn.Ion_type.Contains("b")){clr = Color.Green;exist = true; }
                        else if (intB_chBx_temp.Checked && nn.Ion_type.Contains("b")){clr = Color.Blue;exist = true; step = 1 * 6; }
                        if (nn.IndexTo == idx + 1) { is_left = true; }
                        
                        if (exist)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3")) { is_up = false; }                           
                            if (is_left) { draw_internal_riken_line(pp, is_left, is_up, step, clr, g); }
                            else { draw_internal_riken_line(temp_p, is_left, is_up, step, clr, g); }
                        }                                            
                    }
                    else if ((nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")) && dvw_chBx_temp.Checked && nn.Index == idx + 1)
                    {
                        draw_line(pp, true, 0 + safe_dist_up, Color.DarkTurquoise, g, adduct: up_adduct);
                    }
                    else if ((nn.Ion_type.StartsWith("v") || nn.Ion_type.StartsWith("(v")) && dvw_chBx_temp.Checked && s.Length - nn.Index == idx + 1)
                    {
                        draw_line(temp_p, false, 0 + safe_dist_down, Color.DarkTurquoise, g, adduct: down_adduct);

                    }
                    else if ((nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")) && dvw_chBx_temp.Checked && s.Length - nn.Index == idx + 1)
                    {
                        draw_line(temp_p, false, 4 + safe_dist_down, Color.DarkCyan, g,adduct: down_adduct);

                    }
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width+ length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
            }
            return;
        }
        private void sequence_draw_general_Riken(Graphics g, Panel draw_sequence_panel_temp)
        {
            PictureBox color_range_picBox_temp = GetControls(draw_sequence_panel_temp).OfType<PictureBox>().Where(l => l.Name.Contains("color_range_picBox")).ToList().FirstOrDefault();
            Panel color_range_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("color_range_panel")).ToList().FirstOrDefault();
            Panel seq_lbl_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("seq_lbl_panel")).ToList().FirstOrDefault();
            RadioButton rdBtn50_temp = GetControls(draw_sequence_panel_temp).OfType<RadioButton>().Where(l => l.Name.Contains("rdBtn50")).ToList().FirstOrDefault();
            Panel sequence_Pnl_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("sequence_Pnl")).ToList().FirstOrDefault();
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            CheckBox aw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox bx_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cy_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox dz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox int_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            ComboBox seq_extensionBox_temp = GetControls(draw_sequence_panel_temp).OfType<ComboBox>().Where(l => l.Name.Contains("seq_extensionBox")).ToList().FirstOrDefault();
            Panel legend_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("legend_panel")).ToList().FirstOrDefault();
            ToolStrip tsp = GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp, "_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;

            if (color_range_picBox_temp.Visible) { color_range_picBox_temp.Visible = false; }
            if (color_range_panel_temp.Visible) { color_range_panel_temp.Visible = false; }
            if (seq_lbl_panel_temp.Visible) { seq_lbl_panel_temp.Visible = false; }       
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            int adduct_step1 = 0;
            int adduct_step2 = 0;
            if (merged_prim_modif && is_riken) { adduct_step1 =16; adduct_step2 = 8; }
            else if (merged_prim_modif) { adduct_step1 = 12; adduct_step2 = 8; }
            int step_x = 20;
            int step_y = 74+(2* adduct_step1);
            int temp_y_init = 24+ adduct_step1;
            int temp_x_init = 5;
            int length_panel =0;
            if (legend_panel_temp.Visible) length_panel = -legend_panel_temp.Width;
            Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = temp_y_init;
            point_x = temp_x_init;
            double grp_num = 25;
            if (rdBtn50_temp.Checked) grp_num = 50;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            string s_ext = "";//the desired extension
            if (sequenceList == null || sequenceList.Count == 0) return;
            SequenceTab curr_ss = sequenceList[0];
            if (tab_mode && seq_extensionBox_temp.Enabled && seq_extensionBox_temp.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox_temp.SelectedItem))
                    {
                        curr_ss = seq;
                        s = seq.Sequence; s_ext = seq.Extension;
                        break;
                    }
                }
            }
            if (s.Length / grp_num >= (400 / (step_y + 10))) { draw_sequence_panel_temp.Height = (step_y + 10) * (int)Math.Ceiling(s.Length / grp_num); }
            else { draw_sequence_panel_temp.Height = 400; }
            Point pp = new Point(point_x, point_y);
           
            for (int idx = 0; idx < s.Length; idx++)
            {
                if (curr_ss.Char_color != null) sb.Color = curr_ss.Color_table[curr_ss.Char_color[idx]];
                //g.DrawString(s[idx].ToString(), sequence_Pnl_temp.Font, sb, pp);
                draw_letter(g, s[idx].ToString(), sequence_Pnl_temp, sb, pp);
                //counts the internal -B() in the current index
                foreach (ion nn in IonDraw)
                {
                    if (!include_modified && nn.Has_adduct) { continue; }
                    if (!include_primary && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    Point temp_p = pp;
                    if (pp.X + (2* step_x) >= sequence_Pnl_temp.Width + length_panel) { temp_p.X = temp_x_init - 18;  temp_p.Y = temp_p.Y + step_y; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    int safe_dist_up = +adduct_step1, safe_dist_down = -adduct_step2 - adduct_step1;
                    bool up_adduct = false, down_adduct = false;
                    if (merged_prim_modif && nn.Has_adduct)
                    {
                        safe_dist_up = -adduct_step2 - adduct_step1; safe_dist_down = adduct_step1; up_adduct = true;
                    }
                    else if (merged_prim_modif)
                    {
                        down_adduct = true;
                    }
                    if (aw_chBx_temp.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.LimeGreen, g,adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Green, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 0 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (bx_chBx_temp.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DodgerBlue, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Blue, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 4 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (cy_chBx_temp.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.Tomato, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Firebrick, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 8 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (dz_chBx_temp.Checked && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DeepPink, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.HotPink, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 12 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (aw_chBx_temp.Checked && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.LimeGreen, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Green, g,adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 0 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (bx_chBx_temp.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DodgerBlue, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Blue, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 4 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (cy_chBx_temp.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.Tomato, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Firebrick, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 8 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (dz_chBx_temp.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DeepPink, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.HotPink, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 12 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }                   
                    else if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1) && !los_chkBox_temp.Checked && int_chBx_temp.Checked && (aw_chBx_temp.Checked || bx_chBx_temp.Checked || cy_chBx_temp.Checked || dz_chBx_temp.Checked))
                    {
                        draw_line(pp, false, 0 , nn.Color, g, true);
                    }
                    else if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1)&& !los_chkBox_temp.Checked && int_chBx_temp.Checked)
                    {
                        bool is_left = true;
                        bool is_up = true;
                        int step = 0;
                        Color clr = Color.Orange;
                        // 4/O,707=5.6
                        if (nn.Index == idx + 1)
                        {
                            is_left = false;
                            if (nn.Name.StartsWith("(w") || nn.Name.StartsWith("w")) { step = 0 * 6; clr = Color.LimeGreen; }
                            if (nn.Name.StartsWith("(x") || nn.Name.StartsWith("x")) { step = 1 * 6; clr = Color.DodgerBlue; }
                            if (nn.Name.StartsWith("(y") || nn.Name.StartsWith("y")) { step = 2 * 6; clr = Color.Tomato; }
                            if (nn.Name.StartsWith("(z") || nn.Name.StartsWith("z")) { step =3 * 6; clr = Color.HotPink; }
                        }
                        else 
                        {
                            string[] str = nn.Name.Split('-');
                            if (str.Length>2)
                            {
                                if (str[1].StartsWith("a")) { step = 0 * 6; clr = Color.Green; }
                                if (str[1].StartsWith("b")) { step = 1 * 6; clr = Color.Blue; }
                                if (str[1].StartsWith("c")) { step = 2 * 6; clr = Color.Firebrick; }
                                if (str[1].StartsWith("d")) { step = 3 * 6; clr = Color.DeepPink; }
                            }                            
                        }
                        if (nn.Ion_type.Contains("B(")){is_up = false; } 
                        if (is_left) { draw_internal_riken_line(pp, is_left, is_up, step, clr, g); }
                        else { draw_internal_riken_line(temp_p, is_left, is_up, step, clr, g); }
                    }
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width + length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }                
            }
            return;
        }
        private void draw_internal_riken_line(Point pf, bool left, bool up, int step, Color color_draw, Graphics g, bool legend = false)
        {
            //0.707 * 10=7.07 
            int triangle_a =6;        
            int x1, x2, x3, y1, y2, y3;
            Pen mypen = new Pen(color_draw, 2F);
            if (!legend)
            {                
                x1 = pf.X + 18; x2 = x1;
                if (left) {   x3 = x2 - triangle_a; }
                else {  x3 = x2 + triangle_a; }
                if (up) { y1 = pf.Y - step + 6; y2 = y1 - 5;  y3 = y2 - triangle_a; }
                else {y1 = pf.Y + 14 + step-3; y2 = y1 + 5; y3 = y2 + triangle_a; }
            }
            else
            {
                triangle_a = 5;
                x1 = pf.X; x2 = x1;
                if (left) { x3 = x2 - triangle_a; }
                else { x3 = x2 + triangle_a; }
                if (up) { y1 = pf.Y ; y2 = y1 - 5; y3 = y2 - triangle_a; }
                else { y1 = pf.Y ; y2 = y1 + 5; y3 = y2 + triangle_a; }
            }
            Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            g.DrawLines(mypen, points);
        }
        private void draw_line(Point pf, bool up, int step, Color color_draw, Graphics g, bool inter = false,bool legend=false, bool adduct = false, int times=0)
        {
            int x1, x2, x3, y1, y2, y3;
            Pen mypen = new Pen(color_draw, 2F);
            if (!legend)
            {
                int y_step = 5;
                if (adduct) y_step = -5;
                if (inter) { x1 = pf.X + 18; x2 = x1; y1 = pf.Y; y2 = y1 + 15; x3 = x2; y3 = y2; }
                else if (up) { x1 = pf.X + 18; x2 = x1; y1 = pf.Y - step + 3; y2 = y1 - y_step; y3 = y2; x3 = x2 - 10; }
                else { x1 = pf.X + 18; x2 = x1; y1 = pf.Y + 14 + step + 2; y2 = y1 + y_step; y3 = y2; x3 = x2 + 10; }
            }
            else
            {
                //int y_step1 =3;int y_init1 = 0;
                //int y_step2 = 3; int y_init2 = 0;
                //if (adduct && times==0) { y_step1 = -3; y_init1 =3; }
                //if (adduct && times == 1) { y_step2 = -3; y_init2 = -3; }
                //if (inter) { x1 = pf.X; x2 = x1; y1 = pf.Y; y2 = y1 + 6; x3 = x2; y3 = y2; }
                //else if (up) { x1 = pf.X; x2 = x1; y1 = pf.Y+ y_init2; y2 = y1 - y_step2; y3 = y2; x3 = x2 - 6; }
                //else { x1 = pf.X; x2 = x1; y1 = pf.Y + y_init1; y2 = y1 + y_step1; y3 = y2; x3 = x2 + 6; }
                int y_step1 = 5; int y_init1 = 0;
                int y_step2 = 5; int y_init2 = 0;
                if (adduct && times == 0) { y_step1 = -5; y_init1 = 3; }
                if (adduct && times == 1) { y_step2 = -5; y_init2 = -3; }
                if (inter) { x1 = pf.X; x2 = x1; y1 = pf.Y; y2 = y1 + 10; x3 = x2; y3 = y2; }
                else if (up) { x1 = pf.X; x2 = x1; y1 = pf.Y + y_init2; y2 = y1 - y_step2; y3 = y2; x3 = x2 - 10; }
                else { x1 = pf.X; x2 = x1; y1 = pf.Y + y_init1; y2 = y1 + y_step1; y3 = y2; x3 = x2 + 10; }
            }            
            Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            g.DrawLines(mypen, points);
        }
        private void sequence_Pnl_Paint(object sender, PaintEventArgs e)
        {
            if (is_riken)
            {
                if (!highlight_ibt_ckBx.Checked) sequence_draw_general_Riken(e.Graphics, draw_sequence_panel);
                else draw_internal_generalRiken(e.Graphics, highlight_color, draw_sequence_panel);
            }
            else
            {
                if (!highlight_ibt_ckBx.Checked) sequence_draw_general(e.Graphics, draw_sequence_panel);
                else draw_internal_general(e.Graphics, highlight_color, draw_sequence_panel);
            }           
        }
        //color internal
        private void draw_internal_general(Graphics g, Color paint_color, Panel draw_sequence_panel_temp)
        {
            PictureBox color_range_picBox_temp = GetControls(draw_sequence_panel_temp).OfType<PictureBox>().Where(l => l.Name.Contains("color_range_picBox")).ToList().FirstOrDefault();
            Panel color_range_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("color_range_panel")).ToList().FirstOrDefault();
            Panel seq_lbl_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("seq_lbl_panel")).ToList().FirstOrDefault();
            RadioButton rdBtn50_temp = GetControls(draw_sequence_panel_temp).OfType<RadioButton>().Where(l => l.Name.Contains("rdBtn50")).ToList().FirstOrDefault();
            Panel sequence_Pnl_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("sequence_Pnl")).ToList().FirstOrDefault();
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            ComboBox seq_extensionBox_temp = GetControls(draw_sequence_panel_temp).OfType<ComboBox>().Where(l => l.Name.Contains("seq_extensionBox")).ToList().FirstOrDefault();
            CheckBox dvw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("dvw_chBx")).ToList().FirstOrDefault();
            ToolStrip tsp = GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp, "_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;

            color_range_picBox_temp.Visible = is_rgb_color_range;
            color_range_panel_temp.Visible = !is_rgb_color_range;
            seq_lbl_panel_temp.Visible = true;
            //g = pnl.CreateGraphics();
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            int adduct_step1 = 0;
            int adduct_step2 = 0;
            if (merged_prim_modif && is_riken) { adduct_step1 = 16; adduct_step2 = 8; }
            else if (merged_prim_modif) { adduct_step1 = 12; adduct_step2 = 8; }
            int step_x = 20;
            int step_y = 50 + (2 * adduct_step1);
            int temp_y_init = 20 + adduct_step1;
            int temp_x_init = 3;
            int length_panel = -21 - 50;
            Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = temp_y_init;
            point_x = temp_x_init;
            
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            string s_ext = "";//the desired extension

            if (sequenceList == null || sequenceList.Count == 0) return;
            SequenceTab curr_ss = sequenceList[0];
            double grp_num = 25;
            if (rdBtn50_temp.Checked) grp_num = 50;
            if (tab_mode && seq_extensionBox_temp.Enabled && seq_extensionBox_temp.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox_temp.SelectedItem))
                    {
                        curr_ss = seq;
                        s = seq.Sequence; s_ext = seq.Extension;
                        break;
                    }
                }
            }
            if (s.Length / grp_num >= (400 / (step_y + 10))) { draw_sequence_panel_temp.Height = (step_y+10) * (int)Math.Ceiling(s.Length / grp_num); }
            else { draw_sequence_panel_temp.Height = 400; }
            Point pp = new Point(point_x, point_y);
           

            //draw the rectangles
            for (int idx = 0; idx < s.Length; idx++)
            {
                double intensity = 0.0;
                foreach (ion nn in IonDraw)
                {
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    //if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                    if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 2 || nn.IndexTo == idx + 1))
                    {
                        if (!los_chkBox_temp.Checked)
                        {
                            if (intA_chBx_temp.Checked && !nn.Ion_type.Contains("b"))
                            {
                                intensity += nn.Max_intensity;
                            }
                            else if (intB_chBx_temp.Checked && nn.Ion_type.Contains("b"))
                            {
                                intensity += nn.Max_intensity;
                            }
                        }
                    }
                }
                if (intensity > 0)
                {
                    draw_rectangle(pp, GetColor(intensity), g);
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width+ length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
            }

            //draw as usual over the rectangles
            pp = new Point(point_x, point_y);

            for (int idx = 0; idx < s.Length; idx++)
            {
                if (curr_ss.Char_color != null) sb.Color = curr_ss.Color_table[curr_ss.Char_color[idx]];
                //g.DrawString(s[idx].ToString(), sequence_Pnl_temp.Font, sb, pp);
                draw_letter(g, s[idx].ToString(), sequence_Pnl_temp, sb, pp);

                foreach (ion nn in IonDraw)
                {
                    if (!include_modified && nn.Has_adduct) { continue; }
                    if (!include_primary && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    Point temp_p = pp;
                    if (pp.X + (2* step_x) >= sequence_Pnl_temp.Width + length_panel) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    int safe_dist_up = +adduct_step1, safe_dist_down = -adduct_step2 - adduct_step1;
                    bool up_adduct = false, down_adduct = false;
                    if (merged_prim_modif && nn.Has_adduct)
                    {
                        safe_dist_up = -adduct_step2 - adduct_step1; safe_dist_down = adduct_step1; up_adduct = true;
                    }
                    else if (merged_prim_modif) { down_adduct = true; }
                    if (ax_chBx_temp.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.LimeGreen, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Green, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 0 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (by_chBx_temp.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DodgerBlue, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Blue, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 4 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (cz_chBx_temp.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.Tomato, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Firebrick, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 8 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (ax_chBx_temp.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.LimeGreen, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Green, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 0 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (by_chBx_temp.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DodgerBlue, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Blue, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 4 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (cz_chBx_temp.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.Tomato, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Firebrick, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 8 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if ((nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")) && dvw_chBx_temp.Checked && nn.Index == idx + 1)
                    {
                        draw_line(pp, true, 0, Color.DarkTurquoise, g);
                    }
                    else if ((nn.Ion_type.StartsWith("v") || nn.Ion_type.StartsWith("(v")) && dvw_chBx_temp.Checked && s.Length - nn.Index == idx + 1)
                    {
                        draw_line(temp_p, false, 0, Color.DarkTurquoise, g);

                    }
                    else if ((nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")) && dvw_chBx_temp.Checked && s.Length - nn.Index == idx + 1)
                    {
                        draw_line(temp_p, false, 4, Color.DarkCyan, g);

                    }
                  
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width + length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
            }

            return;
        }
        private void draw_internal_generalRiken(Graphics g, Color paint_color, Panel draw_sequence_panel_temp)
        {
            PictureBox color_range_picBox_temp = GetControls(draw_sequence_panel_temp).OfType<PictureBox>().Where(l => l.Name.Contains("color_range_picBox")).ToList().FirstOrDefault();
            Panel color_range_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("color_range_panel")).ToList().FirstOrDefault();
            Panel seq_lbl_panel_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("seq_lbl_panel")).ToList().FirstOrDefault();
            RadioButton rdBtn50_temp = GetControls(draw_sequence_panel_temp).OfType<RadioButton>().Where(l => l.Name.Contains("rdBtn50")).ToList().FirstOrDefault();
            Panel sequence_Pnl_temp = GetControls(draw_sequence_panel_temp).OfType<Panel>().Where(l => l.Name.Contains("sequence_Pnl")).ToList().FirstOrDefault();
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            CheckBox aw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox bx_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cy_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox dz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox int_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            ComboBox seq_extensionBox_temp = GetControls(draw_sequence_panel_temp).OfType<ComboBox>().Where(l => l.Name.Contains("seq_extensionBox")).ToList().FirstOrDefault();
            ToolStrip tsp = GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp, "_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;

            color_range_picBox_temp.Visible = is_rgb_color_range;
            color_range_panel_temp.Visible = !is_rgb_color_range;
            seq_lbl_panel_temp.Visible = true;
            //g = pnl.CreateGraphics();
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            int adduct_step1 = 0;
            int adduct_step2 = 0;
            if (merged_prim_modif && is_riken) { adduct_step1 = 16; adduct_step2 = 8; }
            else if (merged_prim_modif) { adduct_step1 = 12; adduct_step2 = 8; }
            int step_x = 20;
            int step_y = 74 + (2 * adduct_step1);
            int temp_y_init = 24 + adduct_step1;
            int temp_x_init =5;
            int length_panel = -21 - 50;
            Pen p = new Pen(Color.Black);
            int point_x, point_y;
            point_y = temp_y_init;
            point_x = temp_x_init;
            SolidBrush sb = new SolidBrush(Color.Black);
            string s = Peptide;
            string s_ext = "";//the desired extension
            double grp_num = 25;
            if (rdBtn50_temp.Checked) grp_num = 50;
            if (sequenceList == null || sequenceList.Count == 0) return;
            SequenceTab curr_ss = sequenceList[0];
            if (tab_mode && seq_extensionBox_temp.Enabled && seq_extensionBox_temp.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox_temp.SelectedItem))
                    {
                        curr_ss = seq;
                        s = seq.Sequence; s_ext = seq.Extension;
                        break;
                    }
                }
            }
            if (s.Length / grp_num >= (400/ (step_y + 10))) { draw_sequence_panel_temp.Height = (step_y+10) * (int)Math.Ceiling(s.Length / grp_num); }
            else { draw_sequence_panel_temp.Height = 400; }
            Point pp = new Point(point_x, point_y);
            //draw the rectangles
            for (int idx = 0; idx < s.Length; idx++)
            {
                double intensity = 0.0;
                foreach (ion nn in IonDraw)
                {
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                     //if (nn.Ion_type.StartsWith("int") && (nn.Index == idx + 1 || nn.IndexTo == idx + 1))
                    {
                        if (!los_chkBox_temp.Checked && int_chBx_temp.Checked){intensity += nn.Max_intensity;}
                    }
                }
                if (intensity > 0)
                {
                    draw_rectangle(pp, GetColor(intensity), g);
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width+ length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
            }

            //draw as usual over the rectangles
            pp = new Point(point_x, point_y);

            for (int idx = 0; idx < s.Length; idx++)
            {
                if (curr_ss.Char_color != null) sb.Color = curr_ss.Color_table[curr_ss.Char_color[idx]];
                //g.DrawString(s[idx].ToString(), sequence_Pnl_temp.Font, sb, pp);
                draw_letter(g, s[idx].ToString(), sequence_Pnl_temp, sb, pp);
                foreach (ion nn in IonDraw)
                {
                    if (!include_modified && nn.Has_adduct) { continue; }
                    if (!include_primary && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    Point temp_p = pp;
                    if (pp.X + (2* step_x) >= sequence_Pnl_temp.Width + length_panel) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    if ((idx + 1) % grp_num == 0) { temp_p.X = temp_x_init - 18; temp_p.Y = temp_p.Y + step_y; }
                    int safe_dist_up = +adduct_step1, safe_dist_down = -adduct_step2 - adduct_step1;
                    bool up_adduct = false, down_adduct = false;
                    if (merged_prim_modif && nn.Has_adduct)
                    {
                        safe_dist_up = -adduct_step2 - adduct_step1; safe_dist_down = adduct_step1; up_adduct = true;
                    }
                    else if (merged_prim_modif) { down_adduct = true; }
                    if (aw_chBx_temp.Checked && (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.LimeGreen, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Green, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 0 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (bx_chBx_temp.Checked && (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DodgerBlue, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Blue, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 4 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (cy_chBx_temp.Checked && (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.Tomato, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.Firebrick, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 8 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (dz_chBx_temp.Checked && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")) && nn.Index == idx + 1)
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(pp, true, 4 + safe_dist_up, Color.DeepPink, g, adduct: up_adduct);
                            }
                            else
                            {
                                draw_line(pp, true, 0 + safe_dist_up, Color.HotPink, g, adduct: up_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(pp, true, 12 + safe_dist_up, nn.Color, g, adduct: up_adduct);
                        }
                    }
                    else if (aw_chBx_temp.Checked && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.LimeGreen, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Green, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 0 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (bx_chBx_temp.Checked && (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DodgerBlue, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Blue, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 4 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (cy_chBx_temp.Checked && (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.Tomato, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.Firebrick, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 8 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }
                    else if (dz_chBx_temp.Checked && (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z")) && (s.Length - nn.Index == idx + 1))
                    {
                        if (los_chkBox_temp.Checked)
                        {
                            if (nn.Ion_type.Contains("H2O") || nn.Ion_type.Contains("NH3") || nn.Ion_type.Contains("CO"))
                            {
                                draw_line(temp_p, false, 4 + safe_dist_down, Color.DeepPink, g, adduct: down_adduct);
                            }
                            else
                            {
                                draw_line(temp_p, false, 0 + safe_dist_down, Color.HotPink, g, adduct: down_adduct);
                            }
                        }
                        else if (!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO"))
                        {
                            draw_line(temp_p, false, 12 + safe_dist_down, nn.Color, g, adduct: down_adduct);
                        }
                    }                   
                }
                pp.X = pp.X + step_x;
                if (pp.X + step_x >= sequence_Pnl_temp.Width + length_panel) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
                if ((idx + 1) % grp_num == 0) { pp.X = temp_x_init; pp.Y = pp.Y + step_y; }
            }

            return;
        }
        private void draw_letter(Graphics g,string letter,Panel sequence_Pnl_temp, SolidBrush sb, Point pp)
        {
            Point pp_final = new Point(pp.X, pp.Y);
            if(letter.Equals("I")) pp_final = new Point(pp.X+4, pp.Y);
            g.DrawString(letter, sequence_Pnl_temp.Font, sb, pp_final);
        }
        private void draw_rectangle(Point pf, Color color_draw, Graphics g)
        {
            //Pen mypen = new Pen(Color.FromArgb(intesity, color_draw), 1F);
            //g.DrawRectangle(mypen, pf.X, pf.Y, 16, 15);
            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(color_draw);

            // Create rectangle.
            //Rectangle rect = new Rectangle(pf.X - 1, pf.Y, 20, 17);
            Rectangle rect = new Rectangle(pf.X+16, pf.Y,6, 17);


            // Fill rectangle to screen.
            g.FillRectangle(blueBrush, rect);
        }
        private void highlight_ibt_ckBx_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("When checked, a heatmap of the internal fragments' intensity is displayed on the sequence based on their fragmentation indexes. ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            CheckBox clr_ckbx = (sender as CheckBox);
            Panel big_pnl = clr_ckbx.Parent as Panel;
            ToolStrip tsp = GetControls(big_pnl).OfType<ToolStrip>().First();
            ToolStripButton tspbtn = tsp.Items.OfType<ToolStripButton>().Where(t=>t.Name.Contains("seqLegend")).First();
            if (clr_ckbx.Checked && tspbtn.Checked) { tspbtn.Checked=false; }
            Panel seq_pnl = GetControls(big_pnl).OfType<Panel>().Where(n => n.Name.Contains("sequence_Pnl")).First();
            Panel color_range_pnl = GetControls(seq_pnl).OfType<Panel>().Where(n => n.Name.Contains("color_range")).First();
            Panel seq_lbl_pnl = GetControls(seq_pnl).OfType<Panel>().Where(n => n.Name.Contains("seq_lbl")).First();
            seq_pnl.Refresh(); color_range_pnl.Refresh(); seq_lbl_pnl.Refresh();
        }
        private Color GetColor(double actualValue)
        {
            //normalize
            Int64 rangeStart = seq_min_val;
            Int64 rangeEnd = seq_max_val;
            if (actualValue >= rangeEnd) actualValue = rangeEnd;
            if (actualValue <= rangeStart) actualValue = rangeStart;
            Int64 max = rangeEnd - rangeStart; // make the scale start from 0
            Int64 mid = max / 2; //mid point
            if (is_rgb_color_range)
            {
                double value = (actualValue - rangeStart) / mid - 1; // adjust the value accordingly                                                                     
                //set color
                return GetColorRGB(value);
            }
            else
            {
                int max_alpha = 200;
                int min_alpha = 50;
                double value = (actualValue - rangeStart) * (max_alpha - min_alpha) / max + min_alpha;
                int temp_alpha = (int)Math.Round(value, 0);
                return Color.FromArgb(temp_alpha, highlight_color);
            }
        }
        private Color GetColorRGB(double x)
        {
            int alpha = 150;
            int blue = 0;
            int red = 0;
            int green = 0;
            if (x < -0.5) { blue = 255; red = 0; green = (int)(2 * (x + 1) * 255); }
            else if (x < 0) { blue = (int)(-2 * (x) * 255); red = 0; green = 255; }
            else if (x < 0.5) { blue = 0; red = (int)(2 * (x) * 255); green = 255; }
            else { blue = 0; red = 255; green = (int)(-2 * (x - 1) * 255); }
            return Color.FromArgb(alpha, (Byte)red, (Byte)green, (Byte)blue);
        }
        private void find_max_min_int()
        {
            if (IonDraw.Count==0) { seq_min_val = 10;seq_max_val = 10000000000;  return; }
            List<ion> temp_iondraw = IonDraw.ToList();
            seq_min_val = 10000000000000000;
            seq_max_val =0;
            bool has_internals = false;
            foreach (ion nn in temp_iondraw)
            {
                if (!nn.Ion_type.Contains("int")) continue;
                if (nn.Max_intensity> seq_max_val) { seq_max_val =(int)Math.Ceiling( nn.Max_intensity); }
                if (nn.Max_intensity < seq_min_val) { seq_min_val = (int)Math.Floor(nn.Max_intensity); }
                has_internals = true;
            }
            if(!has_internals) { seq_min_val = 10; seq_max_val = 10000000000; }
            else { seq_max_val = (int)Math.Ceiling(seq_max_val * 1.1); seq_min_val = (int)Math.Floor(seq_min_val * 0.9); }
        }
        //draw color range panels
        private void color_panel(Graphics g, Panel temp)
        {
            int padding = temp.Padding.Top;
            int width = temp.Size.Width;
            int height = temp.Size.Height - (padding * 2);
            int max_alpha = 200;
            int min_alpha = 50;
            int temp_alpha = max_alpha;
            int step = (int)Math.Ceiling((decimal)height / (max_alpha - min_alpha));
            Color cc = Color.FromArgb(temp_alpha, highlight_color);
            // Create solid brush.
            SolidBrush Brush = new SolidBrush(cc);
            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, width, step);
            int temp_counter = padding;
            while (temp_counter < height + padding)
            {
                cc = Color.FromArgb(temp_alpha, highlight_color);
                Brush.Color = cc;
                rect = new Rectangle(0, temp_counter, width, step);
                // Fill rectangle to screen.
                g.FillRectangle(Brush, rect);
                temp_counter += step;
                temp_alpha--;
            }
            if (temp_counter > height + padding)
            {
                int diff = temp_counter - height + padding;
                temp_counter += height;
                cc = Color.FromArgb(temp_alpha, highlight_color);
                Brush.Color = cc;
                rect = new Rectangle(0, temp_counter, width, diff);
                // Fill rectangle to screen.
                g.FillRectangle(Brush, rect);
            }
        }
        private void label_color_panel(Graphics g, Panel temp)
        {
            int padding = temp.Padding.Top;
            int extra_padding = color_range_panel.Padding.Top;
            int width = temp.Size.Width;
            int height = temp.Size.Height - (2 * extra_padding);
            int fractions = seq_reg;
            int step = (int)Math.Ceiling((decimal)height / fractions);
            Int64 value_step = (seq_max_val - seq_min_val) / fractions;
            Int64 value = seq_max_val;
            int x1 = 0, x2 = 3, y1 = extra_padding;
            Pen mypen = new Pen(Color.Black, 2F);
            SolidBrush sb = new SolidBrush(Color.Black);
            Point[] points = new Point[2];
            while (y1 < height + extra_padding)
            {
                points = new Point[2] { new Point(x1, y1), new Point(x2, y1) };
                g.DrawLines(mypen, points);
                g.DrawString(value.ToString("0.0E+0"), temp.Font, sb, new Point(x2 + 1, y1 - 8));
                y1 += step;
                value -= value_step;
            }
            y1 = height + extra_padding;
            value = seq_min_val;
            points = new Point[2] { new Point(x1, y1), new Point(x2, y1) };
            g.DrawString(value.ToString("0.0E+0"), temp.Font, sb, new Point(x2 + 1, y1 - 8));
            g.DrawLines(mypen, points);
        }
        private void color_range_panel_Paint(object sender, PaintEventArgs e)
        {
            color_panel(e.Graphics, color_range_panel);
        }
        private void seq_lbl_panel_Paint(object sender, PaintEventArgs e)
        {
            label_color_panel(e.Graphics, seq_lbl_panel);
        }
        //refresh, checks etc
        private void ax_chBx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ax_chBx_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = ax_chBx_temp.Parent as Panel;
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            if (ax_chBx_temp.Checked)
            {
                //CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
                CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
                CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
                CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
                ax_chBx_temp.ForeColor = Color.ForestGreen;
                if (los_chkBox_temp.Checked) { by_chBx_temp.Checked = false; cz_chBx_temp.Checked = false; intB_chBx_temp.Checked = false; intA_chBx_temp.Checked = false; }
            }
            else
            {
                ax_chBx_temp.ForeColor = Control.DefaultForeColor;
            }
        }
        private void by_chBx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox by_chBx_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = by_chBx_temp.Parent as Panel;
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            if (by_chBx_temp.Checked)
            {
                CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
                CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
                CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
                by_chBx_temp.ForeColor = Color.Blue;
                if (los_chkBox_temp.Checked) { ax_chBx_temp.Checked = false; cz_chBx_temp.Checked = false; intB_chBx_temp.Checked = false; intA_chBx_temp.Checked = false; }
            }
            else
            {
                by_chBx_temp.ForeColor = Control.DefaultForeColor;
            }
        }
        private void cz_chBx_CheckedChanged(object sender, EventArgs e)
        {            
            CheckBox cz_chBx_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = cz_chBx_temp.Parent as Panel;
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            if (cz_chBx_temp.Checked)
            {
                CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
                CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
                CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
                cz_chBx_temp.ForeColor = Color.Crimson;
                if (los_chkBox_temp.Checked) { ax_chBx_temp.Checked = false; by_chBx_temp.Checked = false; intB_chBx_temp.Checked = false; intA_chBx_temp.Checked = false; }
            }
            else
            {
                cz_chBx_temp.ForeColor = Control.DefaultForeColor;
            }
        }
        private void intA_chBx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox intA_chBx_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = intA_chBx_temp.Parent as Panel;
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            if (intA_chBx_temp.Checked && is_riken)
            {
                CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
                CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
                intA_chBx_temp.ForeColor = Color.HotPink;
                if (los_chkBox_temp.Checked) { ax_chBx_temp.Checked = false; by_chBx_temp.Checked = false; cz_chBx_temp.Checked = false; }
            }
            else intA_chBx_temp.ForeColor = Control.DefaultForeColor;
        }       
        private void draw_Btn_Click(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh(); color_range_panel.Refresh(); seq_lbl_panel.Refresh();
        }
        private void sequence_Pnl_Resize(object sender, EventArgs e)
        {
            sequence_Pnl.Refresh(); color_range_panel.Refresh(); seq_lbl_panel.Refresh();
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
            if (help_Btn.Checked)
            {
                string tt = "a - x or b - y or c - z";
                if (is_riken) tt = "a - w or b - x or c - y or d - z";
                MessageBox.Show("Unless the user makes the appropriate choice, the fragments' losses are not plotted. " +
                "If the 'losses' selection is enabled the user can choose to display either "+tt +
                " fragments.In this case, all the primary fragments are noted with an upper mark while the " +
                "primary with losses with a lower mark.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CheckBox los_chkBox_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = los_chkBox_temp.Parent as Panel;
            CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            CheckBox dvw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("dvw_chBx")).ToList().FirstOrDefault();
            if (los_chkBox_temp.Checked) { ax_chBx_temp.Checked = false; by_chBx_temp.Checked = false; cz_chBx_temp.Checked = false; intB_chBx_temp.Checked = false; intA_chBx_temp.Checked = false; intB_chBx_temp.Enabled = false; dvw_chBx_temp.Enabled = false; dvw_chBx_temp.Checked = false; if (!is_riken) { intA_chBx_temp.Enabled = false; } }
            else { intB_chBx_temp.Enabled = true; intA_chBx_temp.Enabled = true; dvw_chBx_temp.Enabled = true; ax_chBx_temp.Enabled = true; by_chBx_temp.Enabled = true; cz_chBx_temp.Enabled = true; }
        }
        private void dvw_chBx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox dvw_chBx_temp = sender as CheckBox;
            Panel draw_sequence_panel_temp = dvw_chBx_temp.Parent as Panel;
            CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
            CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
            CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
            CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
            CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
            CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
            if (dvw_chBx_temp.Checked)
            {                
                ax_chBx_temp.Checked = false;by_chBx_temp.Checked = false;cz_chBx_temp.Checked = false;intA_chBx_temp.Checked = false;los_chkBox_temp.Checked = false;intB_chBx_temp.Checked = false;
            }
            ax_chBx_temp.Enabled = !dvw_chBx_temp.Checked; by_chBx_temp.Enabled = !dvw_chBx_temp.Checked; cz_chBx_temp.Enabled = !dvw_chBx_temp.Checked; intA_chBx_temp.Enabled = !dvw_chBx_temp.Checked; los_chkBox_temp.Enabled = !dvw_chBx_temp.Checked; intB_chBx_temp.Enabled = !dvw_chBx_temp.Checked;
        }
        private void seq_extensionBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            initialize_ions_todraw(); initialize_plot_tabs();
            sequence_Pnl.Refresh();
        }
        private void seq_primary_chkBx_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton tsp = (sender as ToolStripButton);
            if (help_Btn.Checked) { if (tsp.Name.Contains("adduct")) MessageBox.Show("Display modified primary fragments", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); else MessageBox.Show("Display primary fragments", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            Panel big_pnl = tsp.GetCurrentParent().Parent as Panel;
            Panel seq_pnl = GetControls(big_pnl).OfType<Panel>().Where(n => n.Name.Contains("sequence_Pnl")).First();
            seq_pnl.Invalidate();
        }
        //legend Panel
        private void legend_panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (sender as Panel);
            int padding = pnl.Padding.Top;
            int width = pnl.Size.Width;
            int height = pnl.Size.Height - (padding * 2);
            Panel seq_pnl = pnl.Parent as Panel;
            Panel draw_sequence_panel_temp = seq_pnl.Parent as Panel;
            ToolStrip tsp = GetControls(draw_sequence_panel_temp).OfType<ToolStrip>().First();
            bool include_primary = find_toolstripBtn(tsp, "_primary_").Checked;
            bool include_modified = find_toolstripBtn(tsp, "has_adduct").Checked;
            bool merged_prim_modif = include_primary && include_modified;

            Point pp = new Point(10, padding);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black);
            Pen mypen = new Pen(Color.Black, 2F);
            int y_step =8;
            int y_step_up =12;
            int step_x =10;//when primary are plotted a, b, c,d extend up and left, therefore there is step_x initialized
            int step_x_int = 5;//when internals are plotted alone, they don't need a big initial step_x value, so we use step_x_int to save up space
            int space_small = 8;//for example space between a-x (a extends up, x down)
            int space_large = 22;//for example space between x b (x down, b up)
            int space_groups = 25;//space when the ion type group changes , for example primary and internal
            int space_internal = 20;//space betwwen internal vertical symbols |

            int times_repeated = 1;//when is_modif_enabled=true the legends are printed twice (once for the unmofies primaries(up) and once for the modified primaries(down))
            if (merged_prim_modif) times_repeated = 2;
            if (!is_riken)
            {
                CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
                CheckBox ax_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox by_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
                CheckBox cz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
                CheckBox intA_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
                CheckBox intB_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
                CheckBox dvw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("dvw_chBx")).ToList().FirstOrDefault();
                for (int m=0;m< times_repeated; m++)
                {
                    if (m==1) { pp.Y += 5; g.DrawString("Modified", pnl.Font, sb, new Point(0 , pp.Y - y_step)); pp.Y += space_large; }
                    if (dvw_chBx_temp.Checked)
                    {
                        draw_line(pp, true, 0, Color.DarkTurquoise, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("d", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up));
                        pp.Y += space_small;
                        draw_line(pp, false, 0, Color.Turquoise, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("v", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step));
                        pp.Y += 2*space_small;
                        draw_line(pp, false, 0, Color.DarkCyan, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("w", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step));
                    }
                    else if (los_chkBox_temp.Checked)
                    {
                        Color clr1 = Color.Green;
                        Color clr2 = Color.LimeGreen;
                        string[] str = new string[] { "a-losses", "a", "x", "x-losses" };
                        if (by_chBx_temp.Checked) { clr2 = Color.DodgerBlue; clr1 = Color.Blue; str = new string[] { "b-losses", "b", "y", "y-losses" }; }
                        if (cz_chBx_temp.Checked) { clr2 = Color.Tomato; clr1 = Color.Firebrick; str = new string[] { "c-losses", "c", "z", "z-losses" }; }
                        if (ax_chBx_temp.Checked || by_chBx_temp.Checked || cz_chBx_temp.Checked)
                        {
                            draw_line(pp, true, 0, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[0], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up));
                            pp.Y += 2 * space_small;
                            draw_line(pp, true, 0, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[1], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up));
                            pp.Y += 2 * space_small;
                            draw_line(pp, false, 0, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[2], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step));
                            pp.Y += 2 * space_small;
                            draw_line(pp, false, 0, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[3], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step));
                        }
                    }
                    else
                    {
                        Color clr1 = Color.Green;
                        Color clr2 = Color.LimeGreen;
                        int step = 0;
                        if (ax_chBx_temp.Checked)
                        {
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("a", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("x", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (by_chBx_temp.Checked)
                        {
                            clr1 = Color.Blue; clr2 = Color.DodgerBlue;
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("b", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("y", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (cz_chBx_temp.Checked)
                        {
                            clr2 = Color.Tomato; clr1 = Color.Firebrick;
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("c", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("z", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;

                        }
                        if (m == 0 && (intA_chBx_temp.Checked || intB_chBx_temp.Checked) && (ax_chBx_temp.Checked || by_chBx_temp.Checked || cz_chBx_temp.Checked))
                        {
                            if (intA_chBx_temp.Checked) { clr1 = Color.DarkViolet; draw_line(pp, false, 0, clr1, g, true, true); g.DrawString("int.a", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up / 3)); pp.Y += space_internal; }
                            if (intB_chBx_temp.Checked) { clr1 = Color.MediumOrchid; draw_line(pp, false, 0, clr1, g, true, true); g.DrawString("int.b", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up / 3)); pp.Y += space_internal; }
                        }
                        else if (m == 0 )
                        {
                            pp.X = 1;
                            bool is_left = false;
                            bool is_up = true;
                            step = 6;
                            if (intA_chBx_temp.Checked)
                            {
                                is_up = true;
                                clr1 = Color.Green;
                                draw_internal_riken_line(pp, is_left, is_up, 0 * step, clr1, g, true); g.DrawString("int.a", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                                is_up = false;
                                //draw_internal_riken_line(pp, is_left, is_up, 0 * step, clr1, g, true); g.DrawString("int.a-H20", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += 15;
                                //draw_internal_riken_line(pp, is_left, is_up, 1 * step, clr1, g, true); g.DrawString("int.a-NH3", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += 15;
                                draw_internal_riken_line(pp, is_left, is_up, 2 * step, clr1, g, true); g.DrawString("int.a-losses", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_groups;
                            }
                            if (intB_chBx_temp.Checked)
                            {
                                clr1 = Color.Blue;
                                is_up = true;
                                draw_internal_riken_line(pp, is_left, is_up, 0 * step, clr1, g, true); g.DrawString("int.b", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                                is_up = false;
                                //draw_internal_riken_line(pp, is_left, is_up, 0 * step, clr1, g, true); g.DrawString("int.b-H20", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += 15;
                                //draw_internal_riken_line(pp, is_left, is_up, 1 * step, clr1, g, true); g.DrawString("int.b-NH3", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += 15;
                                draw_internal_riken_line(pp, is_left, is_up, 2 * step, clr1, g, true); g.DrawString("int.b-losses", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_groups;
                            }
                        }
                    }
                }
            }
            else
            {
                CheckBox los_chkBox_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("los_chkBox")).ToList().FirstOrDefault();
                CheckBox aw_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("ax_chBx")).ToList().FirstOrDefault();
                CheckBox bx_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("by_chBx")).ToList().FirstOrDefault();
                CheckBox cy_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("cz_chBx")).ToList().FirstOrDefault();
                CheckBox dz_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intA_chBx")).ToList().FirstOrDefault();
                CheckBox int_chBx_temp = GetControls(draw_sequence_panel_temp).OfType<CheckBox>().Where(l => l.Name.Contains("intB_chBx")).ToList().FirstOrDefault();
                for (int m = 0; m < times_repeated; m++)
                {
                    if (m == 1) { pp.Y += 5; g.DrawString("Modified", pnl.Font, sb, new Point(0, pp.Y - y_step)); pp.Y += space_large; }

                    if (los_chkBox_temp.Checked)
                    {
                        Color clr1 = Color.LimeGreen;
                        Color clr2 = Color.Green;
                        string[] str = new string[] { "a-losses", "a", "w", "w-losses" };
                        if (bx_chBx_temp.Checked) { clr1 = Color.DodgerBlue; clr2 = Color.Blue; str = new string[] { "b-losses", "b", "x", "x-losses" }; }
                        if (cy_chBx_temp.Checked) { clr1 = Color.Tomato; clr2 = Color.Firebrick; str = new string[] { "c-losses", "c", "y", "y-losses" }; }
                        if (dz_chBx_temp.Checked) { clr1 = Color.HotPink; clr2 = Color.DeepPink; str = new string[] { "d-losses", "d", "z", "z-losses" }; }
                        if (aw_chBx_temp.Checked || bx_chBx_temp.Checked || cy_chBx_temp.Checked || dz_chBx_temp.Checked)
                        {
                            draw_line(pp, true, 4, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[0], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += 2*space_small;
                            draw_line(pp, true, 0, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[1], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += 2 * space_small;
                            draw_line(pp, false, 0, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[2], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += 2 * space_small;
                            draw_line(pp, false, 4, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString(str[3], pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step + 4));
                        }
                    }
                    else
                    {
                        Color clr1 = Color.Green;
                        Color clr2 = Color.LimeGreen;
                        int step = 0;
                        if (aw_chBx_temp.Checked)
                        {
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("a", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y +=  space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("w", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (bx_chBx_temp.Checked)
                        {
                            clr1 = Color.Blue; clr2 = Color.DodgerBlue;
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("b", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("x", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (cy_chBx_temp.Checked)
                        {
                            clr2 = Color.Tomato; clr1 = Color.Firebrick;
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("c", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("y", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (dz_chBx_temp.Checked)
                        {
                            step = 0; clr1 = Color.DeepPink; clr2 = Color.HotPink;
                            draw_line(pp, true, step, clr1, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("d", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up)); pp.Y += space_small;
                            draw_line(pp, false, step, clr2, g, false, true, adduct: merged_prim_modif, times: m); g.DrawString("z", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step)); pp.Y += space_large;
                        }
                        if (m == 0 && int_chBx_temp.Checked && (aw_chBx_temp.Checked || bx_chBx_temp.Checked || cy_chBx_temp.Checked || dz_chBx_temp.Checked))
                        {
                            clr1 = Color.DarkViolet; draw_line(pp, false, 0, clr1, g, true, true); g.DrawString("int.", pnl.Font, sb, new Point(pp.X + step_x, pp.Y - y_step_up / 3)); pp.Y += space_internal;
                        }
                        else if (m==0 && int_chBx_temp.Checked)
                        {      
                            pp.X = 5;
                            bool is_left = true;
                            bool is_up = true;
                            step = 0;
                            is_up = true; is_left = true;
                            draw_internal_riken_line(pp, is_left, is_up, 0 * step, Color.Green, g, true); g.DrawString("int[-,a]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 1 * step, Color.Blue, g, true); g.DrawString("int[-,b]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 2 * step, Color.Firebrick, g, true); g.DrawString("int[-,c]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 3 * step, Color.DeepPink, g, true); g.DrawString("int[-,d]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            is_left = false;
                            draw_internal_riken_line(pp, is_left, is_up, 0 * step, Color.LimeGreen, g, true); g.DrawString("int[w,-]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 1 * step, Color.DodgerBlue, g, true); g.DrawString("int[x,-]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 2 * step, Color.Tomato, g, true); g.DrawString("int[y,-]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 3 * step, Color.HotPink, g, true); g.DrawString("int[z,-]", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step_up)); pp.Y += space_groups;
                            is_up = false; is_left = true;
                            draw_internal_riken_line(pp, is_left, is_up, 0 * step, Color.Green, g, true); g.DrawString("int[-,a]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 1 * step, Color.Blue, g, true); g.DrawString("int[-,b]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 2 * step, Color.Firebrick, g, true); g.DrawString("int[-,c]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 3 * step, Color.DeepPink, g, true); g.DrawString("int[-,d]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            is_left = false;
                            draw_internal_riken_line(pp, is_left, is_up, 0 * step, Color.LimeGreen, g, true); g.DrawString("int[w,-]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 1 * step, Color.DodgerBlue, g, true); g.DrawString("int[x,-]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal; ;
                            draw_internal_riken_line(pp, is_left, is_up, 2 * step, Color.Tomato, g, true); g.DrawString("int[y,-]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                            draw_internal_riken_line(pp, is_left, is_up, 3 * step, Color.HotPink, g, true); g.DrawString("int[z,-]-B", pnl.Font, sb, new Point(pp.X + step_x_int, pp.Y - y_step)); pp.Y += space_internal;
                        }
                    }
                }                    
            }
        }
        private void seqLegendBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows or hides legend", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);  }
            ToolStripButton tsp = (sender as ToolStripButton);
            Panel big_pnl = tsp.GetCurrentParent().Parent as Panel;
            CheckBox clr_ckbx = GetControls(big_pnl).OfType<CheckBox>().Where(n => n.Name.Contains("highlight")).First();
            if (clr_ckbx.Checked) { clr_ckbx.Checked = !tsp.Checked; }
            Panel seq_pnl = GetControls(big_pnl).OfType<Panel>().Where(n => n.Name.Contains("sequence_Pnl")).First();
            Panel leg_pnl = GetControls(seq_pnl).OfType<Panel>().Where(n => n.Name.Contains("legend_panel")).First();
            leg_pnl.Visible = tsp.Checked;
            seq_pnl.Invalidate();
        }
        #endregion

        #region sequence panels copies
        #region sequence copy 1 
        private void draw_BtnCopy1_Click(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh(); color_range_panelCopy1.Refresh(); seq_lbl_panelCopy1.Refresh();
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
            if (is_riken)
            {
                if (!highlight_ibt_ckBxCopy1.Checked) sequence_draw_general_Riken(e.Graphics, draw_sequence_panelCopy1);
                else draw_internal_generalRiken(e.Graphics, highlight_color, draw_sequence_panelCopy1);
            }
            else
            {
                if (!highlight_ibt_ckBxCopy1.Checked) sequence_draw_general(e.Graphics, draw_sequence_panelCopy1);
                else draw_internal_general(e.Graphics, highlight_color, draw_sequence_panelCopy1);
            }           
        } 
        private void color_range_panelCopy1_Paint(object sender, PaintEventArgs e)
        {
            color_panel(e.Graphics, color_range_panelCopy1);
        }
        private void seq_lbl_panelCopy1_Paint(object sender, PaintEventArgs e)
        {
            label_color_panel(e.Graphics, seq_lbl_panelCopy1);
        }
        private void sequence_PnlCopy1_Resize(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh(); color_range_panelCopy1.Refresh(); seq_lbl_panelCopy1.Refresh();
        }
        private void delele_sequencePnl1_Click(object sender, EventArgs e)
        {
            draw_sequence_panelCopy1.Visible = false;
        }      
        private void seq_extensionBoxCopy1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sequence_PnlCopy1.Refresh();
        }
        #endregion

        #region sequence copy 2 
        private void draw_BtnCopy2_Click(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh(); color_range_panelCopy2.Refresh(); seq_lbl_panelCopy2.Refresh();
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
            if (is_riken)
            {
                if (!highlight_ibt_ckBxCopy2.Checked) sequence_draw_general_Riken(e.Graphics, draw_sequence_panelCopy2);
                else draw_internal_generalRiken(e.Graphics, highlight_color, draw_sequence_panelCopy2);
            }
            else
            {
                if (!highlight_ibt_ckBxCopy2.Checked) sequence_draw_general(e.Graphics, draw_sequence_panelCopy2);
                else draw_internal_general(e.Graphics, highlight_color, draw_sequence_panelCopy2);
            }           
        }       
        private void color_range_panelCopy2_Paint(object sender, PaintEventArgs e)
        {
            color_panel(e.Graphics, color_range_panelCopy2);
        }
        private void seq_lbl_panelCopy2_Paint(object sender, PaintEventArgs e)
        {
            label_color_panel(e.Graphics, seq_lbl_panelCopy2);
        }
        private void sequence_PnlCopy2_Resize(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh(); color_range_panelCopy2.Refresh(); seq_lbl_panelCopy2.Refresh();
        }
        private void delele_sequencePnl2_Click(object sender, EventArgs e)
        {
            draw_sequence_panelCopy2.Visible = false;
        }
             
        #endregion

        private void add_sequencePanel1_Click(object sender, EventArgs e)
        {
            if (draw_sequence_panelCopy1.Visible != true) { draw_sequence_panelCopy1.Visible = true; }
            else { draw_sequence_panelCopy2.Visible = true; }
        }
        private void seq_extensionBoxCopy2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sequence_PnlCopy2.Refresh();
        }
        private void seq_extensionBox_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked)
            {
                ComboBox btn = sender as ComboBox;
                string s = "";
                if (btn.Name.Equals("seq_extensionBox")) s = ", as well as the other fragments' diagrams,";
                MessageBox.Show("For the sequence representation part" + s + 
                    " the user checks the desired corresponding sequence and automatically the graphs are renewed.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }
        #endregion

        #region fragments' diagrams
        private void initialize_tabs()
        {
            #region plotview initilization
            // ax plot
            if (ax_plot != null) ax_plot.Dispose();
            ax_plot = new PlotView() { Name = "ax_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            ax_Pnl_plot.Controls.Add(ax_plot);
            PlotModel ax_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "a - x  fragments", TitleColor = OxyColors.Green };
            ax_plot.Model = ax_model;
            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            ax_model.Axes.Add(linearAxis1);
            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            ax_model.Axes.Add(linearAxis2);
            //ax_model.Updated += (s, e) => { if (Math.Abs(linearAxis1.ActualMaximum) > Math.Abs(linearAxis1.ActualMinimum)) { linearAxis1.Zoom(-Math.Abs(linearAxis1.ActualMaximum), Math.Abs(linearAxis1.ActualMaximum)); } else { linearAxis1.Zoom(-Math.Abs(linearAxis1.ActualMinimum), Math.Abs(linearAxis1.ActualMinimum)); } ax_plot.InvalidatePlot(true); };
            ax_plot.MouseDoubleClick += (s, e) => { ax_model.ResetAllAxes(); ax_plot.InvalidatePlot(true); };
            ax_plot.Controller = new CustomPlotController();

            // by plot
            if (by_plot != null) by_plot.Dispose();
            by_plot = new PlotView() { Name = "by_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            by_Pnl_plot.Controls.Add(by_plot);
            PlotModel by_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "b - y  fragments", TitleColor = OxyColors.Blue };
            by_plot.Model = by_model;
            var linearAxis3 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            by_model.Axes.Add(linearAxis3);
            var linearAxis4 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            by_model.Axes.Add(linearAxis4);
            //by_model.Updated += (s, e) => { if (Math.Abs(linearAxis3.ActualMaximum) > Math.Abs(linearAxis3.ActualMinimum)) { linearAxis3.Zoom(-Math.Abs(linearAxis3.ActualMaximum), Math.Abs(linearAxis3.ActualMaximum)); } else { linearAxis3.Zoom(-Math.Abs(linearAxis3.ActualMinimum), Math.Abs(linearAxis3.ActualMinimum)); } by_plot.InvalidatePlot(true); };
            by_plot.MouseDoubleClick += (s, e) => { by_model.ResetAllAxes(); by_plot.InvalidatePlot(true); };
            by_plot.Controller = new CustomPlotController();

            // cz plot
            if (cz_plot != null) cz_plot.Dispose();
            cz_plot = new PlotView() { Name = "cz_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            cz_Pnl_plot.Controls.Add(cz_plot);
            PlotModel cz_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "c - z  fragments", TitleColor = OxyColors.Red };
            cz_plot.Model = cz_model;
            var linearAxis5 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            cz_model.Axes.Add(linearAxis5);
            var linearAxis6 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            cz_model.Axes.Add(linearAxis6);
            //cz_model.Updated += (s, e) => { if (Math.Abs(linearAxis5.ActualMaximum) > Math.Abs(linearAxis5.ActualMinimum)) { linearAxis5.Zoom(-Math.Abs(linearAxis5.ActualMaximum), Math.Abs(linearAxis5.ActualMaximum)); } else { linearAxis5.Zoom(-Math.Abs(linearAxis5.ActualMinimum), Math.Abs(linearAxis5.ActualMinimum)); } cz_plot.InvalidatePlot(true); };
            cz_plot.MouseDoubleClick += (s, e) => { cz_model.ResetAllAxes(); cz_plot.InvalidatePlot(true); };
            cz_plot.Controller = new CustomPlotController();

            // dz plot
            if (dz_plot != null) dz_plot.Dispose();
            dz_plot = new PlotView() { Name = "dz_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            dz_Pnl_plot.Controls.Add(dz_plot);
            PlotModel dz_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "d - z  fragments", TitleColor = OxyColors.DeepPink };
            dz_plot.Model = dz_model;
            var linearAxis115 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12, MinorGridlineStyle = Yminor_grid12, TickStyle = Y_tick12, StringFormat = y_format12 + y_numformat12, IntervalLength = y_interval12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity" };
            dz_model.Axes.Add(linearAxis115);
            var linearAxis116 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12, MinorGridlineStyle = Xminor_grid12, TickStyle = X_tick12, MinimumMinorStep = 1.0, MajorStep = x_majorStep12, MinorStep = x_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            dz_model.Axes.Add(linearAxis116);
            dz_plot.MouseDoubleClick += (s, e) => { dz_model.ResetAllAxes(); dz_plot.InvalidatePlot(true); };
            dz_plot.Controller = new CustomPlotController();

            // ax charge plot
            if (axCharge_plot != null) axCharge_plot.Dispose();
            axCharge_plot = new PlotView() { Name = "axCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            axCharge_Pnl_plot.Controls.Add(axCharge_plot);
            PlotModel axCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "a - x  fragments", TitleColor = OxyColors.Green };
            axCharge_plot.Model = axCharge_model;
            var linearAxis15 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            axCharge_model.Axes.Add(linearAxis15);
            var linearAxis16 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            axCharge_model.Axes.Add(linearAxis16);
            axCharge_plot.MouseDoubleClick += (s, e) => { axCharge_model.ResetAllAxes(); axCharge_plot.InvalidatePlot(true); };
            axCharge_plot.Controller = new CustomPlotController();

            // by charge plot
            if (byCharge_plot != null) byCharge_plot.Dispose();
            byCharge_plot = new PlotView() { Name = "byCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            byCharge_Pnl_plot.Controls.Add(byCharge_plot);
            PlotModel byCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "b - y  fragments", TitleColor = OxyColors.Blue };
            byCharge_plot.Model = byCharge_model;
            var linearAxis17 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            byCharge_model.Axes.Add(linearAxis17);
            var linearAxis18 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            byCharge_model.Axes.Add(linearAxis18);
            byCharge_plot.MouseDoubleClick += (s, e) => { byCharge_model.ResetAllAxes(); byCharge_plot.InvalidatePlot(true); };
            byCharge_plot.Controller = new CustomPlotController();

            // cz charge plot
            if (czCharge_plot != null) czCharge_plot.Dispose();
            czCharge_plot = new PlotView() { Name = "czCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            czCharge_Pnl_plot.Controls.Add(czCharge_plot);
            PlotModel czCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "c - z  fragments", TitleColor = OxyColors.Red };
            czCharge_plot.Model = czCharge_model;
            var linearAxis19 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            czCharge_model.Axes.Add(linearAxis19);
            var linearAxis20 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            czCharge_model.Axes.Add(linearAxis20);
            czCharge_plot.MouseDoubleClick += (s, e) => { czCharge_model.ResetAllAxes(); czCharge_plot.InvalidatePlot(true); };
            czCharge_plot.Controller = new CustomPlotController();

            // dz charge plot
            if (dzCharge_plot != null) dzCharge_plot.Dispose();
            dzCharge_plot = new PlotView() { Name = "dzCharge_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            dzCharge_Pnl_plot.Controls.Add(dzCharge_plot);
            PlotModel dzCharge_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "d - z  fragments", TitleColor = OxyColors.DeepPink };
            dzCharge_plot.Model = dzCharge_model;
            var linearAxis119 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_charge_grid12, MinorGridlineStyle = Yminor_charge_grid12, TickStyle = Y_charge_tick12, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, MinimumMinorStep = 1.0, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Charge State [#H+]" };
            dzCharge_model.Axes.Add(linearAxis119);
            var linearAxis210 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_charge_grid12, MinorGridlineStyle = Xminor_charge_grid12, TickStyle = X_charge_tick12, MinimumMinorStep = 1.0, MajorStep = x_charge_majorStep12, MinorStep = x_charge_minorStep12, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            dzCharge_model.Axes.Add(linearAxis210);
            dzCharge_plot.MouseDoubleClick += (s, e) => { dzCharge_model.ResetAllAxes(); dzCharge_plot.InvalidatePlot(true); };
            dzCharge_plot.Controller = new CustomPlotController();
            //internal fragments plots
            // index plot
            if (index_plot != null) index_plot.Dispose();
            index_plot = new PlotView() { Name = "index_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxPnl1.Controls.Add(index_plot);
            PlotModel index_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, LegendFontSize = 13, TitleFontSize = 14, Title = "internal  fragments' plot sorted by #AA initial", TitleColor = OxyColors.Teal };
            index_plot.Model = index_model;
            var linearAxis7 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, AxisTitleDistance = 7, MinimumMinorStep = 1.0, TitleFontSize = 11, Title = " # fragments" };
            index_model.Axes.Add(linearAxis7);
            var linearAxis8 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, MajorStep = xINT_majorStep13, MinorStep = xINT_minorStep13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            index_model.Axes.Add(linearAxis8);
            index_plot.MouseDoubleClick += (s, e) => { index_model.ResetAllAxes(); index_plot.InvalidatePlot(true); };
            index_plot.Controller = new CustomPlotController();

            // index intensity plot
            if (indexIntensity_plot != null) indexIntensity_plot.Dispose();
            indexIntensity_plot = new PlotView() { Name = "indexIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxInt_Pnl1.Controls.Add(indexIntensity_plot);
            PlotModel indexIntensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            indexIntensity_plot.Model = indexIntensity_model;
            var linearAxis11 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0, Position = OxyPlot.Axes.AxisPosition.Left };
            indexIntensity_model.Axes.Add(linearAxis11);
            var linearAxis12 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength = x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            indexIntensity_model.Axes.Add(linearAxis12);
            indexIntensity_plot.MouseDoubleClick += (s, e) => { indexIntensity_model.ResetAllAxes(); indexIntensity_plot.InvalidatePlot(true); };
            indexIntensity_plot.Controller = new CustomPlotController();

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
            indexto_plot.Controller = new CustomPlotController();

            // indexTo intensity plot
            if (indextoIntensity_plot != null) indextoIntensity_plot.Dispose();
            indextoIntensity_plot = new PlotView() { Name = "indextoIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            idxInt_Pnl2.Controls.Add(indextoIntensity_plot);
            PlotModel indextoIntensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            indextoIntensity_plot.Model = indextoIntensity_model;
            var linearAxis13 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0 };
            indextoIntensity_model.Axes.Add(linearAxis13);
            var linearAxis14 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength = x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            indextoIntensity_model.Axes.Add(linearAxis14);
            indextoIntensity_plot.MouseDoubleClick += (s, e) => { indextoIntensity_model.ResetAllAxes(); indextoIntensity_plot.InvalidatePlot(true); };
            indextoIntensity_plot.Controller = new CustomPlotController();

            //bind the 2 axes
            linearAxis9.AxisChanged += (s, e) => { linearAxis13.Zoom(linearAxis9.ActualMinimum, linearAxis9.ActualMaximum); indextoIntensity_plot.InvalidatePlot(true); };
            indexto_model.Updated += (s, e) => { indextoIntensity_plot.Model.Axes[0].Zoom(indexto_plot.Model.Axes[0].ActualMinimum, indexto_plot.Model.Axes[0].ActualMaximum); };


            //PPM plot
            if (ppm_plot != null) ppm_plot.Dispose();
            ppm_plot = new PlotView() { Name = "ppm_plot", BackColor = Color.White, Dock = DockStyle.Fill };
            ppm_panel.Controls.Add(ppm_plot);
            PlotModel ppm_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = ppm_legend_Btn.Checked, LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightBottom, LegendFontSize = 10, TitleFontSize = 14, Title = "ppm Error", TitleColor = OxyColors.Teal, SubtitleFontSize = 10, SubtitleFont = "Arial" };
            ppm_plot.Model = ppm_model;
            var linearAxis21 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_ppm_grid, MinorGridlineStyle = Yminor_ppm_grid, FontSize = 10, TickStyle = Y_ppm_tick, MajorStep = y_ppm_majorStep, MinorStep = y_ppm_minorStep, MinimumMinorStep = 1.0, AxisTitleDistance = 7, TitleFontSize = 11, Title = "ppm Error" };
            ppm_model.Axes.Add(linearAxis21);
            var linearAxis22 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_ppm_grid, MinorGridlineStyle = Xminor_ppm_grid, FontSize = 10, TickStyle = X_ppm_tick,IntervalLength= x_ppm_interval /*MajorStep = x_ppm_majorStep, MinorStep = x_ppm_minorStep*/, AxisTitleDistance = 7, TitleFontSize = 11, Title = "# fragments", Position = OxyPlot.Axes.AxisPosition.Bottom };
            ppm_model.Axes.Add(linearAxis22);
            ppm_plot.MouseDoubleClick += (s, e) => { ppm_model.ResetAllAxes(); ppm_plot.InvalidatePlot(true); };
            ppm_plot.Controller = new CustomPlotController();

            #endregion

            #region toolstrip save-copy etc initiliazation
           
            up1_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "aC"); };
            up2_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "bC"); };
            up3_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "cC"); };
            up4_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "dC"); };
            down1_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "aC"); };
            down2_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "bC"); };
            down3_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "cC"); };
            down4_Btn.CheckedChanged += (s, e) => { initialize_plot_tabs(false, "dC"); };
            
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

            int_IdxToCopy_Btn.Click += (s, e) => { export_panel(true, panel2_intIdxTo); };
            int_IdxToSave_Btn.Click += (s, e) => { export_panel(false, panel2_intIdxTo); };

            ppmSave_Btn.Click += (s, e) => { export_copy_plot(false, ppm_plot); }; ppmCopy_Btn.Click += (s, e) => { export_copy_plot(true, ppm_plot); };
            #endregion
        }
        private void initialize_ions_todraw()
        {
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            check_duplicate_ions();
        }
        private void initialize_plot_tabs(bool all = true,string ion="")
        {
            if ((all || ion.Equals("ppm")) && ppm_plot.Model.Series != null) {ppm_plot.Model.Series.Clear();}
            if ((all || ion.Equals("a")) && ax_plot.Model.Series != null) {ax_plot.Model.Series.Clear();}
            if ((all || ion.Equals("b")) && by_plot.Model.Series != null) {by_plot.Model.Series.Clear();}
            if ((all || ion.Equals("c")) && cz_plot.Model.Series != null) {cz_plot.Model.Series.Clear();}
            if ((all || ion.Equals("d")) && dz_plot.Model.Series != null) { dz_plot.Model.Series.Clear(); }
            if ((all || ion.Equals("aC")) && axCharge_plot.Model.Series != null) {axCharge_plot.Model.Series.Clear();}
            if ((all || ion.Equals("bC")) && byCharge_plot.Model.Series != null) {byCharge_plot.Model.Series.Clear();}
            if ((all || ion.Equals("cC")) && czCharge_plot.Model.Series != null) {czCharge_plot.Model.Series.Clear();}
            if ((all || ion.Equals("index")) && index_plot.Model.Series != null) { index_plot.Model.Series.Clear(); indexto_plot.Model.Series.Clear(); indexIntensity_plot.Model.Series.Clear(); indextoIntensity_plot.Model.Series.Clear(); }
            if ((all || ion.Equals("dC")) && dzCharge_plot.Model.Series != null) {dzCharge_plot.Model.Series.Clear(); }

            if (is_riken)
            {
                if (all || ion.Equals("aC")) charge_plot_init(axCharge_plot, "a", "w", 1, Color.Green, Color.LimeGreen);
                if (all || ion.Equals("bC")) charge_plot_init(byCharge_plot, "b", "x", 2, Color.Blue, Color.DodgerBlue);
                if (all || ion.Equals("cC")) charge_plot_init(czCharge_plot, "c", "y", 3, Color.Firebrick, Color.Tomato);
                if (all || ion.Equals("dC")) charge_plot_init(dzCharge_plot, "d", "z", 4, Color.DeepPink, Color.HotPink);
                if (all || ion.Equals("a")) intensity_plot_init(ax_plot, "a", "w", 1, OxyColors.Green, OxyColors.LimeGreen);
                if (all || ion.Equals("b")) intensity_plot_init(by_plot, "b", "x", 2, OxyColors.Blue, OxyColors.DodgerBlue);
                if (all || ion.Equals("c")) intensity_plot_init(cz_plot, "c", "y", 3, OxyColors.Firebrick, OxyColors.Tomato);
                if (all || ion.Equals("d")) intensity_plot_init(dz_plot, "d", "z", 4, OxyColors.DeepPink, OxyColors.HotPink);
                if(all || ion.Equals("ppm"))ppm_plot_init(ppm_plot);
                if (all || ion.Equals("index"))
                {
                    create_internal_plot(index_plot, indexIntensity_plot, 2, Color.Green, Color.Blue);
                    create_internal_plot(indexto_plot, indextoIntensity_plot, 1, Color.Green, Color.Blue);
                }
            }
            else
            {
                if (all || ion.Equals("aC")) charge_plot_init(axCharge_plot, "a", "x", 1, Color.Green, Color.LimeGreen);
                if (all || ion.Equals("bC")) charge_plot_init(byCharge_plot, "b", "y", 2, Color.Blue, Color.DodgerBlue);
                if (all || ion.Equals("cC")) charge_plot_init(czCharge_plot, "c", "z", 3, Color.Firebrick, Color.Tomato);
                if (all || ion.Equals("a")) intensity_plot_init(ax_plot, "a", "x", 1, OxyColors.Green, OxyColors.LimeGreen);
                if (all || ion.Equals("b")) intensity_plot_init(by_plot, "b", "y", 2, OxyColors.Blue, OxyColors.DodgerBlue);
                if (all || ion.Equals("c")) intensity_plot_init(cz_plot, "c", "z", 3, OxyColors.Firebrick, OxyColors.Tomato);
                if (all || ion.Equals("ppm")) ppm_plot_init(ppm_plot);
                if (all || ion.Equals("index"))
                {
                    create_internal_plot(index_plot, indexIntensity_plot, 2, Color.Green, Color.Blue);
                    create_internal_plot(indexto_plot, indextoIntensity_plot, 1, Color.Green, Color.Blue);
                }
            }
            paint_annotations_in_graphs();
        }
        private bool search_primary(string type, int idx, string s_ext,List<ion> temp_iondraw, bool with_charge = false, int charge=0,bool losses_diagram=false)
        {
            foreach (ion nn in temp_iondraw)
            {
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                if (nn.SortIdx > idx) break;
                else if (!with_charge&&!losses_diagram && nn.SortIdx == idx && !nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO") && (nn.Ion_type.StartsWith(type) || nn.Ion_type.StartsWith("(" + type))) return true;
                else if (with_charge && nn.Charge == charge && !losses_diagram && nn.SortIdx == idx && !nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO") && (nn.Ion_type.StartsWith(type) || nn.Ion_type.StartsWith("(" + type))) return true;
                else if (losses_diagram && nn.SortIdx == idx && nn.Charge == charge && nn.Ion_type.Equals(type)) return true;
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
                    if (IonDraw[i].Name == IonDraw[jj].Name && IonDraw[i].Ion_type == IonDraw[jj].Ion_type && IonDraw[i].Index == IonDraw[jj].Index && IonDraw[i].IndexTo == IonDraw[jj].IndexTo && IonDraw[i].Mz == IonDraw[jj].Mz && IonDraw[i].Charge == IonDraw[jj].Charge)
                    {
                        IonDraw.RemoveAt(jj);
                    }
                    else jj++;
                }
                i++;
            }
        }
        private void ppm_plot_init(PlotView plot)
        {
            string s_ext = "";
            string s_chain = Peptide;
            List<ion> temp_iondraw = IonDraw.ToList();
            List<Color> clr_list = new List<Color>() {  Color.LimeGreen, Color.DodgerBlue, Color.Tomato, Color.HotPink };
            List<Color> clrdvw_list = new List<Color>() { Color.Turquoise, Color.Turquoise, Color.DeepPink, Color.LimeGreen };
            int count = 0;
            int idvw = 0;
            string int_str = "int.a";
            if (is_riken) { count = 1; int_str = "int."; idvw = 2; }
            if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                    {
                        s_chain = seq.Sequence; s_ext = seq.Extension; break;
                    }
                }
            }
            List<ScatterSeries> a = create_scatterseries(Color.Green, "a", "ppm", ppm_bullet_size);
            List<ScatterSeries> b = create_scatterseries(Color.Blue, "b", "ppm", ppm_bullet_size);
            List<ScatterSeries> c = create_scatterseries(Color.Firebrick, "c", "ppm", ppm_bullet_size);
            List<ScatterSeries> d = create_scatterseries(clrdvw_list[idvw++], "d", "ppm", ppm_bullet_size);
            List<ScatterSeries> w = create_scatterseries(clrdvw_list[idvw++], "w", "ppm", ppm_bullet_size);
            List<ScatterSeries> x = create_scatterseries(clr_list[count++], "x", "ppm", ppm_bullet_size);
            List<ScatterSeries> y = create_scatterseries(clr_list[count++], "y", "ppm", ppm_bullet_size);
            List<ScatterSeries> z = create_scatterseries(clr_list[count++], "z", "ppm", ppm_bullet_size);  
            List<ScatterSeries> B = create_scatterseries(Color.Orange, "B", "ppm", ppm_bullet_size);
            List<ScatterSeries> internala = create_scatterseries(Color.DarkViolet, int_str, "ppm", ppm_bullet_size);
            List<ScatterSeries> internalb = create_scatterseries(Color.MediumOrchid, "int.b", "ppm", ppm_bullet_size);
            List<ScatterSeries> M = create_scatterseries(Color.Crimson, "M", "ppm", ppm_bullet_size);
            List<ScatterSeries> v = create_scatterseries(Color.Turquoise, "v", "ppm", ppm_bullet_size);
            List<List<CustomDataPoint>> a_list = create_datapoint_list();
            List<List<CustomDataPoint>> b_list = create_datapoint_list();
            List<List<CustomDataPoint>> c_list = create_datapoint_list();
            List<List<CustomDataPoint>> d_list = create_datapoint_list();
            List<List<CustomDataPoint>> w_list = create_datapoint_list();
            List<List<CustomDataPoint>> x_list = create_datapoint_list();
            List<List<CustomDataPoint>> y_list = create_datapoint_list();
            List<List<CustomDataPoint>> z_list = create_datapoint_list();
            List<List<CustomDataPoint>> B_list = create_datapoint_list();
            List<List<CustomDataPoint>> internala_list = create_datapoint_list();
            List<List<CustomDataPoint>> internalb_list = create_datapoint_list();
            List<List<CustomDataPoint>> M_list = create_datapoint_list();
            List<List<CustomDataPoint>> v_list = create_datapoint_list();

            int iondraw_count = temp_iondraw.Count;
            CI_mass comMass = new CI_mass(); temp_iondraw.Sort(comMass);
            int ppm_points = 0;
            double temp_first_m_z = 0.0;
            double temp_last_m_z = 0.0;
            string ppm_range = "";
            string loss = "NH3";
            if (is_riken) loss = "B()";
            if (ppm_graph_type == 1)
            {
                plot.Model.Axes[1].Title = "# fragments";
                for (int i = 0; i < iondraw_count; i++)
                {
                    int list_index = 0;
                    ion nn = temp_iondraw[i];
                    if (!ppm_includeModif_Btn.Checked && nn.Has_adduct) { continue; }
                    if (!ppm_includePrimary_Btn.Checked && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    if (nn.minPPM_Error == 0 && nn.maxPPM_Error == 0) ppm_range = " -";
                    else ppm_range = "(" + Math.Round(nn.minPPM_Error, 4).ToString() + ") - (" + Math.Round(nn.maxPPM_Error, 4).ToString() + ")";
                    if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_a.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_a_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_a_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            a_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_b.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_b_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_b_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            b_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_c.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_c_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_c_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            c_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (is_riken &&(nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_d.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_d_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_d_B.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            d_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_w.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_w_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_w_B.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            w_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_x.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_x_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_x_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            x_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_y.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_y_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_y_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            y_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_z.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_z_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_z_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            z_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("int"))
                    {
                        if (nn.Ion_type.Contains("b"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_b.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_b_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_internal_b_NH3.Checked))
                            {
                                list_index = return_list_index(nn.Max_intensity);
                                internalb_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                                ppm_points++;
                            }
                        }
                        else
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_a.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_a_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_internal_a_NH3.Checked))
                            {
                                list_index = return_list_index(nn.Max_intensity);
                                internala_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                                ppm_points++;
                            }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("M") || nn.Ion_type.StartsWith("(M"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_M.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_M_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_M_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            M_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("B(") || nn.Ion_type.StartsWith("(B(")))
                    {
                        if (ppm_B_.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            B_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")))
                    {
                        if ( ppm_d2.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            d_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("v") || nn.Ion_type.StartsWith("(v")))
                    {
                        if (ppm_v.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            v_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")))
                    {
                        if (ppm_w2.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            w_list[list_index].Add(new CustomDataPoint(ppm_points + 1, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                        }
                    }
                }
            }
            else
            {
                plot.Model.Axes[1].Title = "m/z";
                for (int i = 0; i < iondraw_count; i++)
                {
                    int list_index = 0;
                    ion nn = temp_iondraw[i];
                    if (!ppm_includeModif_Btn.Checked && nn.Has_adduct) { continue; }
                    if (!ppm_includePrimary_Btn.Checked && !nn.Has_adduct) { continue; }
                    if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                    if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                    double m_z = dParser(nn.Mz);
                    if (nn.minPPM_Error == 0 && nn.maxPPM_Error == 0) ppm_range = " -";
                    else ppm_range = "(" + Math.Round(nn.minPPM_Error, 4).ToString() + ") - (" + Math.Round(nn.maxPPM_Error, 4).ToString() + ")";
                    if (nn.Ion_type.StartsWith("a") || nn.Ion_type.StartsWith("(a"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_a.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_a_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_a_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            a_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("b") || nn.Ion_type.StartsWith("(b"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_b.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_b_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_b_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            b_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("c") || nn.Ion_type.StartsWith("(c"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_c.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_c_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_c_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            c_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_d.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_d_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_d_B.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            d_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_w.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_w_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_w_B.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            w_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("x") || nn.Ion_type.StartsWith("(x"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_x.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_x_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_x_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            x_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("y") || nn.Ion_type.StartsWith("(y"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_y.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_y_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_y_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            y_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("z") || nn.Ion_type.StartsWith("(z"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_z.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_z_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_z_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            z_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (nn.Ion_type.StartsWith("int"))
                    {
                        if (nn.Ion_type.Contains("b"))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_b.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_b_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_internal_b_NH3.Checked))
                            {
                                list_index = return_list_index(nn.Max_intensity);
                                internalb_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                                ppm_points++;
                                if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                                temp_last_m_z = m_z;
                            }
                        }
                        else
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_a.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_internal_a_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_internal_a_NH3.Checked))
                            {
                                list_index = return_list_index(nn.Max_intensity);
                                internala_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                                ppm_points++;
                                if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                                temp_last_m_z = m_z;
                            }
                        }
                    }
                    else if (nn.Ion_type.StartsWith("M") || nn.Ion_type.StartsWith("(M"))
                    {
                        if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_M.Checked) || (nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains(loss) && ppm_M_H2O.Checked) || (nn.Ion_type.Contains(loss) && !nn.Ion_type.Contains("H2O") && ppm_M_NH3.Checked))
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            M_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (is_riken && (nn.Ion_type.StartsWith("B(") || nn.Ion_type.StartsWith("(B(")))
                    {
                        if (ppm_B_.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            B_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("d") || nn.Ion_type.StartsWith("(d")))
                    {
                        if (ppm_d2.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            d_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("v") || nn.Ion_type.StartsWith("(v")))
                    {
                        if (ppm_v.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            v_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                    else if (!is_riken && (nn.Ion_type.StartsWith("w") || nn.Ion_type.StartsWith("(w")))
                    {
                        if (ppm_w2.Checked)
                        {
                            list_index = return_list_index(nn.Max_intensity);
                            w_list[list_index].Add(new CustomDataPoint(m_z, nn.PPM_Error, ppm_range, nn.Mz, nn.Name));
                            ppm_points++;
                            if (temp_first_m_z == 0) { temp_first_m_z = m_z; }
                            temp_last_m_z = m_z;
                        }
                    }
                }
            }
           
            //default TrackerFormatString: "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}"
            // { 0} = Title of Series { 1} = Title of X-Axis { 2} = X Value { 3} = Title of Y-Axis { 4} = Y Value            
            //ppm_series.TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}"+ "\nName:{Name}"; 
            for (int i = 9; i >= 0; i--)
            {
                if (a_list[i].Count>0) { a[i].ItemsSource = a_list[i]; a[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(a[i]); }
                if (b_list[i].Count > 0) { b[i].ItemsSource = b_list[i]; b[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(b[i]); }
                if (c_list[i].Count > 0) { c[i].ItemsSource = c_list[i]; c[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(c[i]); }
                if (d_list[i].Count > 0) { d[i].ItemsSource = d_list[i]; d[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(d[i]); }
                if (w_list[i].Count > 0) { w[i].ItemsSource = w_list[i]; w[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(w[i]); }
                if (x_list[i].Count > 0) { x[i].ItemsSource = x_list[i]; x[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(x[i]); } 
                if (y_list[i].Count > 0) { y[i].ItemsSource = y_list[i]; y[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(y[i]); }
                if (z_list[i].Count > 0) { z[i].ItemsSource = z_list[i]; z[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(z[i]); }
                if (internala_list[i].Count > 0) { internala[i].ItemsSource = internala_list[i]; internala[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(internala[i]); }
                if (internalb_list[i].Count > 0) { internalb[i].ItemsSource = internalb_list[i]; internalb[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(internalb[i]); }
                if (M_list[i].Count > 0) { M[i].ItemsSource = M_list[i]; M[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(M[i]); }
                if (B_list[i].Count > 0) { B[i].ItemsSource =B_list[i]; B[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(B[i]); }
                if (v_list[i].Count > 0) { v[i].ItemsSource = v_list[i]; v[i].TrackerFormatString = "Monoisopic Mass:{Text}" + "\nppm:{4:0.###}" + "\nppm range:{Xreal}" + "\nName:{Name}"; plot.Model.Series.Add(v[i]); }

            }
            if (last_m_z == 0 && first_m_z == 0)
            {
                last_m_z = temp_last_m_z; first_m_z = temp_first_m_z;
            }
            else if (last_m_z == 0)
            {
                last_m_z = temp_last_m_z;
            }
            plot.Model.TrackerChanged += (s, e) =>
            {
                plot.Model.Subtitle = e.HitResult != null ? e.HitResult.Text : null;
                plot.Model.InvalidatePlot(false);
            };
            if (ppm_graph_type == 1) { plot.Model.Axes[1].Maximum = ppm_points + 1; plot.Model.Axes[1].Minimum = 0; }
            else { plot.Model.Axes[1].Maximum = last_m_z + 1; plot.Model.Axes[1].Minimum = first_m_z - 1; }
            plot.InvalidatePlot(true);
            temp_iondraw.Clear();
        }       
        private void charge_plot_init(PlotView plot,string up_type, string down_type, int  t,Color up_clr, Color down_clr)
        {
            string s_ext = "";
            string s_chain = Peptide;
            List<ion> temp_iondraw = IonDraw.ToList();

            int iondraw_count = temp_iondraw.Count;
            double max_ = 5000;
            double maxcharge_ = 0;
            double mincharge_ = 0;
            if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                    {
                        s_chain = seq.Sequence; s_ext = seq.Extension; break;
                    }
                }
            }            
            List<double[]> merged_up = new List<double[]>();
            List<double[]> merged_down = new List<double[]>();
            List<ion> charge_merged_up = new List<ion>();
            List<ion> charge_merged_down = new List<ion>();            
            List<ScatterSeries> up = create_scatterseries(up_clr, up_type, "charge", 1);
            List<ScatterSeries> down = create_scatterseries(down_clr, down_type, "charge", 1);
            List<List<CustomDataPoint>> up_list = create_datapoint_list();
            List<List<CustomDataPoint>> down_list = create_datapoint_list();
            CI ion_comp = new CI();
            temp_iondraw.Sort(ion_comp);
            //fill the list with the correct ions            
            for (int i = 0; i < iondraw_count; i++)
            {
                ion nn = temp_iondraw[i];
                if(!includeModif_Btn.Checked && nn.Has_adduct) { continue; }
                if (!includePrimary_Btn.Checked && !nn.Has_adduct) { continue; }
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                if (nn.Ion_type.StartsWith(up_type) || nn.Ion_type.StartsWith("("+ up_type))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")) || search_primary(up_type, nn.SortIdx, s_ext, temp_iondraw,true,nn.Charge))
                    {
                        if (merged_up.Count == 0 || (int)merged_up.Last()[0] != nn.SortIdx)
                        {
                            merged_up.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                            charge_merged_up.Add(new ion { Extension = nn.Extension, Chain_type = nn.Chain_type, SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name, Has_adduct = nn.Has_adduct });
                        }
                        else
                        {
                            merged_up.Last()[1] += nn.Max_intensity;
                            if (charge_merged_up.Last().Charge == nn.Charge) { charge_merged_up.Last().Max_intensity += nn.Max_intensity; charge_merged_up.Last().Mz += " , " + nn.Mz; charge_merged_up.Last().Name += " , " + nn.Name; }
                            else { charge_merged_up.Add(new ion { Extension = nn.Extension, Chain_type = nn.Chain_type, SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name, Has_adduct=nn.Has_adduct }); }
                        }
                        if (max_ < merged_up.Last()[1]) { max_= merged_up.Last()[1]; }
                        if (maxcharge_ <  nn.Charge) { maxcharge_ =nn.Charge; }
                        if (mincharge_ > nn.Charge) { mincharge_ = nn.Charge; }

                    }
                }
                else if (nn.Ion_type.StartsWith(down_type) || nn.Ion_type.StartsWith("("+ down_type))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")) || search_primary(down_type, nn.SortIdx, s_ext, temp_iondraw, true, nn.Charge))
                    {
                        if (merged_down.Count == 0 || (int)merged_down.Last()[0] != nn.SortIdx)
                        {
                            merged_down.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                            charge_merged_down.Add(new ion { Extension = nn.Extension, Chain_type = nn.Chain_type, SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name, Has_adduct = nn.Has_adduct });
                        }
                        else
                        {
                            merged_down.Last()[1] += nn.Max_intensity;
                            if (charge_merged_down.Last().Charge == nn.Charge) { charge_merged_down.Last().Max_intensity += nn.Max_intensity; charge_merged_down.Last().Mz += " , " + nn.Mz; charge_merged_down.Last().Name += " , " + nn.Name; }
                            else { charge_merged_down.Add(new ion { Extension = nn.Extension, Chain_type = nn.Chain_type, SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name, Has_adduct = nn.Has_adduct }); }
                        }
                        if (max_ < merged_down.Last()[1]) { max_ = merged_down.Last()[1]; }
                        if (maxcharge_ < nn.Charge) { maxcharge_ = nn.Charge; }
                        if (mincharge_ > nn.Charge) { mincharge_ = nn.Charge; }
                    }
                }
            }
            int list_index = 0;
            foreach (ion nn in charge_merged_up)
            {
                list_index = return_list_index(nn.Max_intensity);
                up_list[list_index].Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name));
            }
            foreach (ion nn in charge_merged_down)
            {
                list_index = return_list_index(nn.Max_intensity);
                down_list[list_index].Add(new CustomDataPoint(nn.SortIdx, nn.Charge, nn.Index.ToString(), nn.Mz, nn.Name));
            }
            ToolStrip strip = GetControls(panel2_tab3).OfType<ToolStrip>().Where(l => l.Name.Equals("Charge_toolStrip" + t.ToString())).FirstOrDefault();
            ToolStripButton btn_up =strip.Items.OfType<ToolStripButton>().Where(l => l.Name.Equals("up" + t.ToString() + "_Btn")).FirstOrDefault();
            ToolStripButton btn_down = strip.Items.OfType<ToolStripButton>().Where(l => l.Name.Equals("down" + t.ToString() + "_Btn")).FirstOrDefault() ;
            for (int i = 9; i >= 0; i--)
            {
                if (up_list[i].Count > 0 && btn_up.Checked) { up[i].ItemsSource = up_list[i]; up[i].TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}"; ; plot.Model.Series.Add(up[i]); }
                if (down_list[i].Count > 0 && btn_down.Checked) { down[i].ItemsSource = down_list[i]; down[i].TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nResidue Number: {Xreal}\nMonoisotopic Mass: {Text}\n{Name}"; plot.Model.Series.Add(down[i]); }
            }
            if (btn_up.Checked && btn_down.Checked)plot.Model.Title = up_type+ " - "+ down_type+"  fragments";            
            else if (btn_up.Checked) plot.Model.Title = up_type + " fragments";
            else if (btn_down.Checked) plot.Model.Title = down_type + " fragments";            
            else plot.Model.Title = up_type + " - " + down_type + "  fragments";
            plot.Model.Axes[1].Minimum =  0;
            plot.Model.Axes[1].Maximum = s_chain.Length;
            plot.Model.Axes[0].Minimum = mincharge_ - 1; 
            plot.Model.Axes[0].Maximum = maxcharge_ + 1;
            plot.InvalidatePlot(true);
            temp_iondraw.Clear();
        }
        private void intensity_plot_init(PlotView plot, string up_type, string down_type, int t, OxyColor up_clr, OxyColor down_clr)
        {
            string s_ext = "";
            string s_chain = Peptide;
            List<ion> temp_iondraw = IonDraw.ToList();
            int iondraw_count = temp_iondraw.Count;
            double max_ = 1;
            if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                    {
                        s_chain = seq.Sequence; s_ext = seq.Extension; break;
                    }
                }
            }
            LinearBarSeries up_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = up_clr, FillColor = up_clr, BarWidth = bar_width };
            LinearBarSeries down_bar = new LinearBarSeries() { CanTrackerInterpolatePoints = false, StrokeThickness = 2, StrokeColor = down_clr, FillColor = down_clr, BarWidth = bar_width };
            var s1a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red, }; var s2a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            plot.Model.Title = up_type + " - " + down_type + "  fragments";
            plot.Model.Series.Add(up_bar); plot.Model.Series.Add(down_bar);
            List<double[]> merged_up = new List<double[]>();
            List<double[]> merged_down = new List<double[]>();
            CI ion_comp = new CI();
            temp_iondraw.Sort(ion_comp);
            //fill the list with the correct ions            
            for (int i = 0; i < iondraw_count; i++)
            {
                ion nn = temp_iondraw[i];
                if (!includeModif_Btn.Checked && nn.Has_adduct) { continue; }
                if (!includePrimary_Btn.Checked && !nn.Has_adduct) { continue; }
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                if (nn.Ion_type.StartsWith(up_type) || nn.Ion_type.StartsWith("(" + up_type))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")) || search_primary(up_type, nn.SortIdx, s_ext, temp_iondraw))
                    {
                        if (merged_up.Count == 0 || (int)merged_up.Last()[0] != nn.SortIdx)
                        {
                            merged_up.Add(new double[] { nn.SortIdx, nn.Max_intensity });
                        }
                        else
                        {
                            merged_up.Last()[1] += nn.Max_intensity;
                        }
                        if (max_ < merged_up.Last()[1]) { max_ = merged_up.Last()[1]; }
                    }
                }
                else if (nn.Ion_type.StartsWith(down_type) || nn.Ion_type.StartsWith("(" + down_type))
                {
                    if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")) || search_primary(down_type, nn.SortIdx, s_ext, temp_iondraw))
                    {
                        if (merged_down.Count == 0 || (int)merged_down.Last()[0] != nn.SortIdx)
                        {
                            merged_down.Add(new double[] { nn.SortIdx, -nn.Max_intensity });
                        }
                        else
                        {
                            merged_down.Last()[1] -= nn.Max_intensity;
                        }
                        if (max_ < -merged_down.Last()[1]) { max_ =- merged_down.Last()[1]; }                        
                    }
                }
            }
            foreach (double[] pp in merged_up) { (plot.Model.Series[0] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            foreach (double[] pp in merged_down) { (plot.Model.Series[1] as LinearBarSeries).Points.Add(new DataPoint(pp[0], pp[1])); }
            for (int cc = 0; cc < s_chain.Length; cc++)
            {
                if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                {
                    s1a.Points.Add(new ScatterPoint(cc + 1, -max_ * 1.3 * 0.99));
                }
                else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                {
                    s2a.Points.Add(new ScatterPoint(cc + 1, max_ * 1.3 * 0.99));
                }
            }
            plot.Model.Series.Add(s1a); plot.Model.Series.Add(s2a);
            plot.Model.Axes[0].AxisChanged += (s, e) =>
            {
                s1a.Points.Clear(); s2a.Points.Clear();
                for (int cc = 0; cc < s_chain.Length; cc++)
                {
                    if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                    {
                        s1a.Points.Add(new ScatterPoint(cc + 1, plot.Model.Axes[0].ActualMinimum * 0.99));
                    }
                    else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                    {
                        s2a.Points.Add(new ScatterPoint(cc + 1, plot.Model.Axes[0].ActualMaximum * 0.99));
                    }
                }
                plot.Model.Series[2] = s1a; plot.Model.Series[3] = s2a; plot.InvalidatePlot(true);
            };
            plot.Model.Axes[1].Minimum =  0;
            plot.Model.Axes[1].Maximum =s_chain.Length;
            plot.Model.Axes[0].Minimum =-max_ * 1.3;
            plot.Model.Axes[0].Maximum = max_ * 1.3;

            plot.InvalidatePlot(true);
            temp_iondraw.Clear();
        }        
        private void create_internal_plot(PlotView plot, PlotView plotIntensity, int t, Color clr1, Color clr2)
        {
            //parameter 't' stands for the type of the plot
            //t=1:indexTo plot, t=2:index plot
            if (IonDrawIndexTo.Count > 0) { IonDrawIndexTo.Clear(); }
            string s_ext = "";
            string s_chain = Peptide;
            List<ion> temp_iondraw = IonDraw.ToList();
            int iondraw_count = temp_iondraw.Count;
            double max_i = 0.0;
            List<CustomDataPoint> points_index = new List<CustomDataPoint>();
            List<CustomDataPoint> points_indexTo = new List<CustomDataPoint>();
            if (IonDrawIndexTo.Count > 0) { IonDrawIndexTo.Clear(); }
            CI ion_comp = new CI();
            IonDraw.Sort(ion_comp);
            //fill the list with the correct ions            
            for (int i = 0; i < iondraw_count; i++)
            {
                ion nn = IonDraw[i];
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                if (nn.Ion_type.StartsWith("int"))
                {
                    if (nn.Ion_type.Contains("b"))
                    {
                        IonDrawIndexTo.Add(new ion() {Name=nn.Name, Mz=nn.Mz, Extension = nn.Extension, Chain_type = nn.Chain_type, Ion_type = nn.Ion_type, Index = nn.Index, IndexTo = nn.IndexTo, Charge = nn.Charge, Color = clr2, Max_intensity = nn.Max_intensity, Has_adduct = nn.Has_adduct });
                    }
                    else
                    {
                        IonDrawIndexTo.Add(new ion() { Name = nn.Name, Mz = nn.Mz, Extension = nn.Extension, Chain_type = nn.Chain_type, Ion_type = nn.Ion_type, Index = nn.Index, IndexTo = nn.IndexTo, Color = clr1, Charge = nn.Charge, Max_intensity = nn.Max_intensity, Has_adduct = nn.Has_adduct });
                    }
                }
            }
            if (IonDrawIndexTo.Count() > 0)
            {
                if (t==1)//indexTo plot
                {
                    CI_indexTo com1 = new CI_indexTo(); IonDrawIndexTo.Sort(com1);                    
                }
                else//index plot
                {
                    CI_index com2 = new CI_index(); IonDrawIndexTo.Sort(com2);                   
                }
                int k = 1;
                foreach (ion nn in IonDrawIndexTo)
                {
                    List<CustomDataPointIndex> custom_Index = new List<CustomDataPointIndex>();
                    List<CustomDataPointIndex> custom_IndIntensity = new List<CustomDataPointIndex>();
                    string charge_text = nn.Charge.ToString();
                    string ion_type_text = nn.Ion_type;
                    string tracker_text = "{Ion}\n{Index}\nCharge: {Charge}\nMax Intens.: {Intensity}\nm/z: {Mz}";
                    if (nn.Charge > 0) charge_text = "+" + nn.Charge.ToString();
                    if (is_riken) { ion_type_text = nn.Name; tracker_text = "{Ion}\n{Index}\nMax Intens.: {Intensity}\nm/z: {Mz}"; }
                    custom_Index.Add(new CustomDataPointIndex(nn.Index, k, ion_type_text, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", charge_text, nn.Max_intensity.ToString("0.###"), nn.Mz));
                    custom_Index.Add(new CustomDataPointIndex(nn.IndexTo, k, ion_type_text, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", charge_text, nn.Max_intensity.ToString("0.###"), nn.Mz));
                    LineSeries tmp = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    tmp.ItemsSource = custom_Index;
                    tmp.TrackerFormatString = tracker_text;
                    plot.Model.Series.Add(tmp);
                    custom_IndIntensity.Add(new CustomDataPointIndex(0, k, ion_type_text, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", charge_text, nn.Max_intensity.ToString("0.###"), nn.Mz));
                    custom_IndIntensity.Add(new CustomDataPointIndex(nn.Max_intensity, k, ion_type_text, "[" + nn.Index.ToString() + "-" + nn.IndexTo.ToString() + "]", charge_text, nn.Max_intensity.ToString("0.###"), nn.Mz));
                    LineSeries bar = new LineSeries() { CanTrackerInterpolatePoints = true, StrokeThickness = int_width, Color = nn.Color.ToOxyColor() };
                    bar.ItemsSource = custom_IndIntensity;
                    bar.TrackerFormatString = tracker_text;
                    plotIntensity.Model.Series.Add(bar);
                    k++;
                    if (nn.Max_intensity > max_i) max_i = nn.Max_intensity;
                }
                plotIntensity.Model.Axes[1].Maximum = max_i * 1.2;
                plotIntensity.Model.Axes[0].Minimum = 0;
                plot.Model.Axes[1].Minimum =  0;
                plot.Model.Axes[1].Maximum = s_chain.Length;
                plot.Model.Axes[0].Minimum =  0;
                if (IonDrawIndexTo.Count > 200) { yINT_minorStep13 = 25; yINT_majorStep13 = 50; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count > 150) { yINT_minorStep13 = 15; yINT_majorStep13 = 30; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count > 100) { yINT_minorStep13 = 10; yINT_majorStep13 = 20; internal_plots_refresh(); }
                else if (IonDrawIndexTo.Count > 50) { yINT_minorStep13 = 5; yINT_majorStep13 = 10; internal_plots_refresh(); }
                plot.Model.Axes[0].Maximum =  plotIntensity.Model.Axes[0].Maximum = IonDrawIndexTo.Count + yINT_minorStep13 / 2;
                plot.Model.Axes[0].Minimum =  plotIntensity.Model.Axes[0].Minimum = -yINT_minorStep13 / 2;
            }
            plot.InvalidatePlot(true); plotIntensity.InvalidatePlot(true);
        }
        private List<ScatterSeries> create_scatterseries(Color clr,string frag, string plot_type, double _size,MarkerType shape=MarkerType.Circle)
        {
            ScatterSeries _10 = new ScatterSeries() { MarkerSize = _size * 2, Title = frag+ " 10^1", MarkerType = shape, MarkerFill = Color.FromArgb(255, clr).ToOxyColor() };
            ScatterSeries _100 = new ScatterSeries() { MarkerSize = _size * 3, Title = frag + " 10^2", MarkerType = shape, MarkerFill = Color.FromArgb(230, clr).ToOxyColor() };
            ScatterSeries _1000 = new ScatterSeries() { MarkerSize = _size * 4, Title = frag + " 10^3", MarkerType = shape, MarkerFill = Color.FromArgb(205, clr).ToOxyColor() };
            ScatterSeries _10000 = new ScatterSeries() { MarkerSize = _size * 5, Title = frag + " 10^4", MarkerType = shape, MarkerFill = Color.FromArgb(180, clr).ToOxyColor() };
            ScatterSeries _100000 = new ScatterSeries() { MarkerSize = _size * 6, Title = frag + " 10^5", MarkerType = shape, MarkerFill = Color.FromArgb(155, clr).ToOxyColor() };
            ScatterSeries _1000000 = new ScatterSeries() { MarkerSize = _size * 7, Title = frag + " 10^6", MarkerType = shape, MarkerFill = Color.FromArgb(130, clr).ToOxyColor() };
            ScatterSeries _10000000 = new ScatterSeries() { MarkerSize = _size * 8, Title = frag + " 10^7", MarkerType = shape, MarkerFill = Color.FromArgb(105, clr).ToOxyColor() };
            ScatterSeries _100000000 = new ScatterSeries() { MarkerSize = _size * 9, Title = frag + " 10^8", MarkerType = shape, MarkerFill = Color.FromArgb(80, clr).ToOxyColor() };
            ScatterSeries _1000000000 = new ScatterSeries() { MarkerSize = _size * 10, Title = frag + " 10^9", MarkerType = shape, MarkerFill = Color.FromArgb(55, clr).ToOxyColor() };
            ScatterSeries _10000000000 = new ScatterSeries() { MarkerSize = _size * 11, Title = frag + " 10^10", MarkerType = shape, MarkerFill = Color.FromArgb(30, clr).ToOxyColor() };
            return new List<ScatterSeries>() { _10, _100, _1000, _10000, _100000, _1000000, _10000000, _100000000, _1000000000 , _10000000000 };
        }
        private List<List<CustomDataPoint>> create_datapoint_list()
        {
            List<List<CustomDataPoint>> final = new List<List<CustomDataPoint>>();
            for (int i=0;i<10 ;i++)
            {
                final.Add(new List<CustomDataPoint>());
            }
            return final;
        }
        private int return_list_index(double intens)
        {
            int list_index = 0;
            if (intens / 10 < 10) { list_index = 0; }
            else if (intens / 100 < 10) { list_index = 1; }
            else if (intens / 1000 < 10) { list_index = 2; }
            else if (intens / 10000 < 10) { list_index = 3; }
            else if (intens / 100000 < 10) { list_index = 4; }
            else if (intens / 1000000 < 10) { list_index = 5; }
            else if (intens / 10000000 < 10) { list_index = 6; }
            else if (intens / 100000000 < 10) { list_index = 7; }
            else if (intens / 1000000000 < 10) { list_index = 8; }
            else { list_index = 9; }
            return list_index;
        }

        #endregion

        #region FORM 22 ppm plot settings
        public void ppm_plot_refresh()
        {
            ppm_plot.Model.Axes[0].MajorGridlineStyle = Ymajor_ppm_grid;
            ppm_plot.Model.Axes[0].MinorGridlineStyle = Yminor_ppm_grid;
            ppm_plot.Model.Axes[0].TickStyle = Y_ppm_tick;
            ppm_plot.Model.Axes[0].MajorStep = y_ppm_majorStep;
            ppm_plot.Model.Axes[0].MinorStep = y_ppm_minorStep;
            ppm_plot.Model.Axes[1].MajorGridlineStyle = Xmajor_ppm_grid;
            ppm_plot.Model.Axes[1].MinorGridlineStyle = Xminor_ppm_grid;
            ppm_plot.Model.Axes[1].TickStyle = X_ppm_tick;
            ppm_plot.Model.Axes[1].IntervalLength = x_ppm_interval;
            //ppm_plot.Model.Axes[1].MajorStep = x_ppm_majorStep;
            //ppm_plot.Model.Axes[1].MinorStep = x_ppm_minorStep;
            ppm_plot.InvalidatePlot(true);            
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 frm22 = new Form22(this);
            frm22.FormClosed += (s, f) => { save_preferences(); };
            frm22.ShowDialog();
        }
        #endregion

        #region FORM 12 plot settings
        public void primary_plots_refresh(bool charge =false)
        {
            if (!charge)
            {
                refresh_intensity_plots_settings(ax_plot);
                refresh_intensity_plots_settings(by_plot);
                refresh_intensity_plots_settings(cz_plot);
                refresh_intensity_plots_settings(dz_plot);
            }
            else
            {
                refresh_charge_plots_settings(axCharge_plot);
                refresh_charge_plots_settings(byCharge_plot);
                refresh_charge_plots_settings(czCharge_plot);
                refresh_charge_plots_settings(dzCharge_plot);
            }
           
        }
        private void refresh_charge_plots_settings(PlotView plot)
        {
            plot.Model.Axes[0].MajorGridlineStyle = Ymajor_charge_grid12;
            plot.Model.Axes[0].MinorGridlineStyle = Yminor_charge_grid12;
            plot.Model.Axes[0].TickStyle = Y_charge_tick12;
            plot.Model.Axes[0].MajorStep = y_charge_majorStep12;
            plot.Model.Axes[0].MinorStep = y_charge_minorStep12;
            plot.Model.Axes[1].MajorGridlineStyle = Xmajor_charge_grid12;
            plot.Model.Axes[1].MinorGridlineStyle = Xminor_charge_grid12;
            plot.Model.Axes[1].TickStyle = X_charge_tick12;
            plot.Model.Axes[1].MajorStep = x_charge_majorStep12;
            plot.Model.Axes[1].MinorStep = x_charge_minorStep12;
            plot.InvalidatePlot(true);
        }
        private void refresh_intensity_plots_settings(PlotView plot)
        {
            plot.Model.Axes[0].MajorGridlineStyle = Ymajor_grid12;
            plot.Model.Axes[0].MinorGridlineStyle = Yminor_grid12;
            plot.Model.Axes[0].TickStyle = Y_tick12;
            plot.Model.Axes[0].IntervalLength = y_interval12;
            plot.Model.Axes[0].StringFormat = y_format12 + y_numformat12;
            plot.Model.Axes[1].MajorGridlineStyle = Xmajor_grid12;
            plot.Model.Axes[1].MinorGridlineStyle = Xminor_grid12;
            plot.Model.Axes[1].TickStyle = X_tick12;
            plot.Model.Axes[1].MajorStep = x_majorStep12;
            plot.Model.Axes[1].MinorStep = x_minorStep12;
            plot.InvalidatePlot(true);
        }
        public void tabs_plots_replot(string ion="")
        {
            initialize_plot_tabs(false,ion);
        }

        #endregion

        #region FORM 13 plot settings
        public void internal_plots_refresh()
        {
            refresh_index_plot_settings(index_plot);
            refresh_index_plot_settings(indexto_plot);
            refresh_index_intensity_plot_settings(indexIntensity_plot);
            refresh_index_intensity_plot_settings(indextoIntensity_plot);
        }
        private void refresh_index_plot_settings(PlotView plot)
        {
            plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            plot.Model.Axes[0].TickStyle = Yint_tick13;
            plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            plot.Model.Axes[1].TickStyle = Xint_tick13;
            plot.Model.Axes[1].MajorStep = xINT_majorStep13;
            plot.Model.Axes[1].MinorStep = xINT_minorStep13;
            plot.InvalidatePlot(true);
        }
        private void refresh_index_intensity_plot_settings(PlotView plot)
        {
            plot.Model.Axes[0].MajorGridlineStyle = Yint_major_grid13;
            plot.Model.Axes[0].MinorGridlineStyle = Yint_minor_grid13;
            plot.Model.Axes[0].TickStyle = Yint_tick13;
            plot.Model.Axes[0].MajorStep = yINT_majorStep13;
            plot.Model.Axes[0].MinorStep = yINT_minorStep13;
            plot.Model.Axes[1].MajorGridlineStyle = Xint_major_grid13;
            plot.Model.Axes[1].MinorGridlineStyle = Xint_minor_grid13;
            plot.Model.Axes[1].TickStyle = Xint_tick13;
            plot.Model.Axes[1].StringFormat = x_format13 + x_numformat13;
            plot.Model.Axes[1].IntervalLength = x_interval13;
            plot.InvalidatePlot(true);
        }
        #endregion

        #region Hydrogens Tab
        private void find_plot_ingrp_export(Control grp, bool copy)
        {
            Panel pnl = GetControls(grp).OfType<Panel>().Where(l => l.Name.Contains("plot")).First();
            PlotView plot = GetControls(pnl).OfType<PlotView>().FirstOrDefault();
            export_panel(copy, pnl);
        }
        private void create_plotview(GroupBox grp, string type)
        {
            Panel pnl = GetControls(grp).OfType<Panel>().Where(l=>l.Name.Contains("plot")).First();
            Panel checks_panel = GetControls(grp).OfType<Panel>().Where(k=>k.Name.Contains("check")).First();
            PlotView plus_plot;
            PlotView minus_plot;
            bool is_logarithmic = false;
            bool is_losses = false;
            bool is_legend = false;
            ToolStrip tt = GetControls(grp).OfType<ToolStrip>().First();
            is_logarithmic = tt.Items.OfType<ToolStripButton>().Where(l => l.Name.Contains("log")).First().Checked;
            is_losses = tt.Items.OfType<ToolStripButton>().Where(l => l.Text.Contains("losses")).First().Checked;
            is_legend = tt.Items.OfType<ToolStripButton>().Where(l => l.Name.Contains("legend")).First().Checked;
           

            if (pnl.Controls.Count > 0)
            {
                //refresh Plotviews' settings that might have changed by the style Form
                plus_plot = pnl.Controls[0] as PlotView;
                plus_plot.Height = pnl.Height / 2;
                plus_plot.Model.Axes[0] = new OxyPlot.Axes.LinearAxis() {  MajorGridlineStyle = Ymajor_grid12_2, IntervalLength = y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                plus_plot.Model.Axes[1] = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep = x_minorStep12_2, MajorStep = x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                minus_plot = pnl.Controls[1] as PlotView;
                minus_plot.Height = pnl.Height / 2;
                minus_plot.Model.Axes[0] = new OxyPlot.Axes.LinearAxis() {  MajorGridlineStyle = Ymajor_grid12_2,  IntervalLength = y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                minus_plot.Model.Axes[1] = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep = x_minorStep12_2, MajorStep = x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                //bind the 2 X axes
                plus_plot.Model.Axes[1].AxisChanged += (s, e) => {
                    if (minus_plot.Model.Axes[1].ActualMinimum != plus_plot.Model.Axes[1].ActualMinimum && minus_plot.Model.Axes[1].ActualMaximum != plus_plot.Model.Axes[1].ActualMaximum)
                    {
                        minus_plot.Model.Axes[1].Zoom(plus_plot.Model.Axes[1].ActualMinimum, plus_plot.Model.Axes[1].ActualMaximum); minus_plot.InvalidatePlot(true);
                    }
                };
                minus_plot.Model.Axes[1].AxisChanged += (s, e) => {
                    if (minus_plot.Model.Axes[1].ActualMinimum != plus_plot.Model.Axes[1].ActualMinimum && minus_plot.Model.Axes[1].ActualMaximum != plus_plot.Model.Axes[1].ActualMaximum)
                    {
                        plus_plot.Model.Axes[1].Zoom(minus_plot.Model.Axes[1].ActualMinimum, minus_plot.Model.Axes[1].ActualMaximum); plus_plot.InvalidatePlot(true);
                    }
                };
                plus_plot.Model.IsLegendVisible = is_legend;
                minus_plot.Model.IsLegendVisible = is_legend;
            }
            else
            {
                //create the Plotviews for plus (example:a+1,a+2) and minus(example:a-1,a-2) Hydrogens
                plus_plot = new PlotView() { Name = "plus_plot", BackColor = Color.White,Height=pnl.Height/2, Dock = System.Windows.Forms.DockStyle.Top };
                pnl.Controls.Add(plus_plot);
                PlotModel model1 = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = is_legend, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = type + "  fragments", TitleColor = OxyColors.Green };
                plus_plot.Model = model1;
                var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12_2, IntervalLength=y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat=y_format12_2+ y_numformat12_2,  FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                model1.Axes.Add(linearAxis1);
                var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep=x_minorStep12_2,MajorStep=x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2,  FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                model1.Axes.Add(linearAxis2);
                plus_plot.MouseDoubleClick += (s, e) => { model1.ResetAllAxes(); plus_plot.InvalidatePlot(true); };
                plus_plot.Controller = new CustomPlotController();
                minus_plot = new PlotView() { Name = "minus_plot", BackColor = Color.White, Height = pnl.Height / 2, Dock = System.Windows.Forms.DockStyle.Bottom };
                pnl.Controls.Add(minus_plot);
                PlotModel model2 = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = is_legend, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "  ", TitleColor = OxyColors.Green };
                minus_plot.Model = model2;
                var linearAxis3 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_grid12_2, IntervalLength = y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                model2.Axes.Add(linearAxis3);
                var linearAxis4 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep = x_minorStep12_2, MajorStep = x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
                model2.Axes.Add(linearAxis4);
                minus_plot.MouseDoubleClick += (s, e) => { model2.ResetAllAxes(); minus_plot.InvalidatePlot(true); };
                minus_plot.Controller = new CustomPlotController();
                //bind the 2 X axes
                linearAxis2.AxisChanged += (s, e) => { if (linearAxis4.ActualMinimum!= linearAxis2.ActualMinimum && linearAxis4.ActualMaximum != linearAxis2.ActualMaximum) {
                        linearAxis4.Zoom(linearAxis2.ActualMinimum, linearAxis2.ActualMaximum); minus_plot.InvalidatePlot(true); } };
                linearAxis4.AxisChanged += (s, e) => { if (linearAxis4.ActualMinimum != linearAxis2.ActualMinimum && linearAxis4.ActualMaximum != linearAxis2.ActualMaximum) {
                        linearAxis2.Zoom(linearAxis4.ActualMinimum, linearAxis4.ActualMaximum); plus_plot.InvalidatePlot(true); } };

                //model1.Updated += (s, e) => { minus_plot.Model.Axes[1].Zoom(plus_plot.Model.Axes[1].ActualMinimum, plus_plot.Model.Axes[1].ActualMaximum); };
            }
            Color[] clr =create_check_boxes(type, checks_panel, pnl);
            create_losses_diagram(type, plus_plot,minus_plot, checks_panel,clr,is_logarithmic, is_losses);
            paint_annotations_in_temp_graphs(1, plus_plot);
            paint_annotations_in_temp_graphs(1, minus_plot);
        }
        private void create_export_plotview(GroupBox grp, string type)
        {
            Panel pnl = GetControls(grp).OfType<Panel>().Where(l => l.Name.Contains("plot")).First();
            Panel checks_panel = GetControls(grp).OfType<Panel>().Where(k => k.Name.Contains("check")).First();
            bool is_logarithmic = false;
            bool is_losses = false;
            ToolStrip tt = GetControls(grp).OfType<ToolStrip>().First();
            is_logarithmic = tt.Items.OfType<ToolStripButton>().Where(l => l.Name.Contains("log")).First().Checked;
            is_losses = tt.Items.OfType<ToolStripButton>().Where(l => l.Text.Contains("losses")).First().Checked;
            PlotView plus_plot = new PlotView() { Name = "plus_plot", BackColor = Color.White, /*Dock = System.Windows.Forms.DockStyle.Top,*/Height=100 };
            PlotModel model1 = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true,LegendOrientation=LegendOrientation.Horizontal,LegendPosition=LegendPosition.TopCenter,LegendPlacement=LegendPlacement.Outside, LegendFontSize = 13, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = type + "  fragments", TitleColor = OxyColors.Green };
            plus_plot.Model = model1;
            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { PositionAtZeroCrossing = true, MajorGridlineStyle = Ymajor_grid12_2, IntervalLength = y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
            model1.Axes.Add(linearAxis1);
            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep = x_minorStep12_2, MajorStep = x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            model1.Axes.Add(linearAxis2);
            plus_plot.MouseDoubleClick += (s, e) => { model1.ResetAllAxes(); plus_plot.InvalidatePlot(true); };
            plus_plot.Controller = new CustomPlotController();
            PlotView minus_plot = new PlotView() { Name = "minus_plot", BackColor = Color.White, /*Dock = System.Windows.Forms.DockStyle.Bottom,*/ Height = 100 };
            pnl.Controls.Add(minus_plot);
            PlotModel model2 = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 13, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial", Title = "  ", TitleColor = OxyColors.Green };
            minus_plot.Model = model2;
            var linearAxis3 = new OxyPlot.Axes.LinearAxis() { PositionAtZeroCrossing = true, MajorGridlineStyle = Ymajor_grid12_2, IntervalLength = y_interval12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
            model2.Axes.Add(linearAxis3);
            var linearAxis4 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_grid12_2, MinorStep = x_minorStep12_2, MajorStep = x_majorStep12_2, MinorGridlineStyle = Xminor_grid12_2, TickStyle = X_tick12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Residue Number [#AA]", Position = OxyPlot.Axes.AxisPosition.Bottom };
            model2.Axes.Add(linearAxis4);
            minus_plot.MouseDoubleClick += (s, e) => { model2.ResetAllAxes(); minus_plot.InvalidatePlot(true); };
            minus_plot.Controller = new CustomPlotController();
            //bind the 2 X axes
            linearAxis2.AxisChanged += (s, e) => {
                if (linearAxis4.ActualMinimum != linearAxis2.ActualMinimum && linearAxis4.ActualMaximum != linearAxis2.ActualMaximum)
                {
                    linearAxis4.Zoom(linearAxis2.ActualMinimum, linearAxis2.ActualMaximum); minus_plot.InvalidatePlot(true);
                }
            };
            linearAxis4.AxisChanged += (s, e) => {
                if (linearAxis4.ActualMinimum != linearAxis2.ActualMinimum && linearAxis4.ActualMaximum != linearAxis2.ActualMaximum)
                {
                    linearAxis2.Zoom(linearAxis4.ActualMinimum, linearAxis4.ActualMaximum); plus_plot.InvalidatePlot(true);
                }
            };
            
            Color[] clr = return_check_boxes_colors(type, checks_panel);
            create_losses_diagram(type, plus_plot, minus_plot, checks_panel, clr,is_logarithmic, is_losses);
            PlotView original_plotview_plus = GetControls(pnl).OfType<PlotView>().Where(k=>k.Name.Contains("plus")).First();
            plus_plot.Model.Axes[1].Zoom(original_plotview_plus.Model.Axes[1].ActualMinimum, original_plotview_plus.Model.Axes[1].ActualMaximum);
            plus_plot.Model.Axes[0].Zoom(original_plotview_plus.Model.Axes[0].ActualMinimum, original_plotview_plus.Model.Axes[0].ActualMaximum);
            PlotView original_plotview_minus = GetControls(pnl).OfType<PlotView>().Where(k => k.Name.Contains("minus")).First();
            minus_plot.Model.Axes[1].Zoom(original_plotview_minus.Model.Axes[1].ActualMinimum, original_plotview_minus.Model.Axes[1].ActualMaximum);
            minus_plot.Model.Axes[0].Zoom(original_plotview_minus.Model.Axes[0].ActualMinimum, original_plotview_minus.Model.Axes[0].ActualMaximum);
            paint_annotations_in_temp_graphs(1, plus_plot);
            paint_annotations_in_temp_graphs(1, minus_plot);
            Form11 frm11 = new Form11(plus_plot,minus_plot,true);
            frm11.Show();
        }
        private Color[] return_check_boxes_colors(string type, Panel checks_panel)
        {
            Color[] clr = new Color[4];
            if (type.Equals("a")) { clr = new Color[4] { Color.Green, Color.LightSeaGreen, Color.Chartreuse, Color.DarkSeaGreen }; }
            else if (type.Equals("b")) { clr = new Color[4] { Color.Blue, Color.DarkBlue, Color.SlateBlue, Color.LightSteelBlue }; }
            else if (type.Equals("c")) { clr = new Color[4] { Color.Firebrick, Color.RosyBrown, Color.Red, Color.DarkOrange }; }
            else if (type.Equals("d")) { clr = new Color[4] { Color.DeepPink, Color.DarkMagenta, Color.MediumVioletRed, Color.PaleVioletRed }; }
            else if (type.Equals("w") || (!is_riken && type.Equals("x"))) { clr = new Color[4] { Color.LimeGreen, Color.Lime, Color.MediumSpringGreen, Color.SeaGreen }; }
            else if ((!is_riken && type.Equals("y")) || (is_riken && type.Equals("x"))) { clr = new Color[4] { Color.DodgerBlue, Color.MediumTurquoise, Color.MediumBlue, Color.LightBlue }; }
            else if ((!is_riken && type.Equals("z")) || (is_riken && type.Equals("y"))) { clr = new Color[4] { Color.Tomato, Color.BurlyWood, Color.DarkOrange, Color.Brown }; }
            else if (is_riken && type.Equals("z")) { clr = new Color[4] { Color.HotPink, Color.DarkOrchid, Color.Pink, Color.Plum }; }
            foreach (Control cc in checks_panel.Controls)
            {
                List<CheckBox> list_ = GetControls(cc).OfType<CheckBox>().ToList();
                foreach (CheckBox ckbx in list_)
                {
                    if (ckbx.Text.Contains("-2")) { clr[0] = ckbx.ForeColor; }
                    else if (ckbx.Text.Contains("-1")) { clr[1] = ckbx.ForeColor; }
                    else if (ckbx.Text.Contains("+1")) { clr[2] = ckbx.ForeColor; }
                    else if (ckbx.Text.Contains("+2")) { clr[3] = ckbx.ForeColor; }
                }
            }           
            return clr;
        }
        private void create_losses_diagram(string type, PlotView plus_plot, PlotView minus_plot, Panel checks_panel, Color[] clr,bool is_logarithmic,bool is_losses)
        {
            //string pattern = @"[a-z][+-][1-9][0-9]?(?![(])|[a-z][+-][H][1-9][0-9]?(?!a-zA-Z)";
            string pattern = @"["+type+"][+-][1-9][0-9]?(?![(])";
            string text = "Amino Acid";
            if(is_riken) text = "Base";
            if (plus_plot.Model.Series != null) { plus_plot.Model.Series.Clear(); }
            if (minus_plot.Model.Series != null) { minus_plot.Model.Series.Clear(); }
            plus_plot.Model.Title = type + " fragments";
            plus_plot.Model.TitleColor = clr[0].ToOxyColor();
            List<ion> temp_iondraw = IonDraw.ToList();
            var s1a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red, }; var s2a = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            var s1b = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Red, }; var s2b = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 3, MarkerFill = OxyColors.Blue };
            List<Color> clr1 = new List<Color>();
            List<MarkerType> shape = new List<MarkerType>() { MarkerType.Circle, MarkerType.Square , MarkerType.Diamond , MarkerType.Triangle };
            int iondraw_count = temp_iondraw.Count;
            double maximum = 1.0;
            double minimum = -0.10 * maximum;
            string s_ext = "";
            string s_chain = Peptide;
            List<string> check_names = new List<string>();
            for (int cc = 0; cc < s_chain.Length; cc++)
            {
                if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                {
                    s1a.Points.Add(new ScatterPoint(cc + 1, -1.2 * maximum * 0.99));
                    s1b.Points.Add(new ScatterPoint(cc + 1, -1.2 * maximum * 0.99));
                }
                else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                {
                    s2a.Points.Add(new ScatterPoint(cc + 1, 1.2 * maximum * 0.99));
                    s2b.Points.Add(new ScatterPoint(cc + 1, 1.2 * maximum * 0.99));
                }
            }
            plus_plot.Model.Series.Add(s1a); plus_plot.Model.Series.Add(s2a);
            minus_plot.Model.Series.Add(s1b); minus_plot.Model.Series.Add(s2b);            
            if (iondraw_count >0)
            {
                CI ion_comp = new CI();
                temp_iondraw.Sort(ion_comp);
                List<CheckBox> list = new List<CheckBox>();
                foreach (Control cc in checks_panel.Controls)
                {
                     list.AddRange( GetControls(cc).OfType<CheckBox>().ToList());
                }
                if (list.Count > 0)
                {
                    foreach (CheckBox vv in list) { if (vv.Checked) { check_names.Add(vv.Text); clr1.Add(vv.ForeColor); } }
                }
                if (is_logarithmic)
                {
                    plus_plot.Model.Axes[0] = new LogarithmicAxis { Position = AxisPosition.Left, IntervalLength = y_interval12_2, MajorGridlineStyle = Ymajor_grid12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2,/*MinorTickSize=5,*/ StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                    minus_plot.Model.Axes[0] = new LogarithmicAxis {Position = AxisPosition.Left, IntervalLength = y_interval12_2, MajorGridlineStyle = Ymajor_grid12_2, MinorGridlineStyle = Yminor_grid12_2, TickStyle = Y_tick12_2, /*MinorTickSize = 5,*/ StringFormat = y_format12_2 + y_numformat12_2, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "k" };
                    minimum = 0.1;
                }               
                if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
                {
                    foreach (SequenceTab seq in sequenceList)
                    {
                        if (seq.Extension.Equals(seq_extensionBox.SelectedItem)) { s_chain = seq.Sequence; s_ext = seq.Extension; break; }
                    }
                }
                int count = check_names.Count();
                for (int k = 0; k < count; k++)
                {
                    string name = check_names[k];
                    int ii_s =k;
                    //int ii_c = k;
                    if (ii_s > 3) { ii_s = k % 4;/* while (ii_c > 3) { ii_c =ii_c / 4; }*/ }
                    MarkerType temp_shape = shape[ii_s];
                    Color temp = clr1[k];
                    OxyPlot.LineStyle style = OxyPlot.LineStyle.Solid;
                    //if (name.Contains("-1")) { temp_shape = MarkerType.Square; temp = clr[1]; }
                    //else if (name.Contains("+2")) { temp_shape = MarkerType.Diamond; temp = clr[3]; }
                    //else if (name.Contains("-2")) { temp_shape = MarkerType.Triangle;  temp = clr[0]; }
                    //else { temp_shape = MarkerType.Triangle;  temp = clr[0]; }
                    List<List<CustomDataPoint>> datapoint_list = create_datapoint_list();
                    List<ion> merged_names = new List<ion>();
                    List<ScatterSeries> series_list = create_scatterseries(temp, name, "losses", 1, temp_shape);
                    LineSeries line_ = new LineSeries { StrokeThickness = line_width_2, Color = temp.ToOxyColor(), CanTrackerInterpolatePoints = false, LineStyle = style };
                    List<double[]> points_line_ = new List<double[]>();
                    for (int i = 0; i < iondraw_count; i++)
                    {
                        ion nn = temp_iondraw[i];
                        //if (nn.Has_adduct) { continue; }
                        if (name.Length == 1) { continue; }
                        if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                        if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                        //if (!nn.Ion_type.StartsWith(type) && !nn.Ion_type.StartsWith("(" + type)) { continue; }
                        Match matches = Regex.Match(nn.Ion_type, pattern);
                        if (!matches.Success) {  continue; }
                        if ((nn.Ion_type.StartsWith(name) || nn.Ion_type.StartsWith("(" + name)))
                        {
                            if ((!nn.Ion_type.Contains("H2O") && !nn.Ion_type.Contains("NH3") && !nn.Ion_type.Contains("CO")) || (is_losses && search_primary(type, nn.SortIdx, s_ext, temp_iondraw, true, nn.Charge, true)))
                            {
                                if (merged_names.Count > 0 && merged_names.Last().SortIdx == nn.SortIdx && merged_names.Last().Charge == nn.Charge)
                                {
                                    merged_names.Last().Max_intensity += nn.Max_intensity; merged_names.Last().Mz += " , " + nn.Mz; merged_names.Last().Name += " , " + nn.Name;
                                }
                                else
                                {
                                    merged_names.Add(new ion { Extension = nn.Extension, Chain_type = nn.Chain_type, SortIdx = nn.SortIdx, Charge = nn.Charge, Index = nn.Index, Mz = nn.Mz, Max_intensity = nn.Max_intensity, Name = nn.Name, Has_adduct = nn.Has_adduct });
                                }
                            }
                        }
                    }
                    int list_index = 0;
                    foreach (ion nn in merged_names)
                    {
                        double primary_int = search_primary_return_intens(type, nn.SortIdx, s_ext, nn.Charge, temp_iondraw);
                        double value = 0.0;
                        list_index = return_list_index(nn.Max_intensity);
                        if (nn.Max_intensity == 0 && primary_int == 0) { value = 0.0; }
                        else
                        {
                            if (primary_int == 0) primary_int = 1.0;
                            value = nn.Max_intensity / primary_int;
                            //if (is_logarithmic) value = Math.Log(value);
                            if (value > maximum) maximum = value;
                            if (value < minimum) minimum = value;
                        }
                        if (name.StartsWith("w")|| name.StartsWith("x")|| name.StartsWith("y")|| name.StartsWith("z")) { datapoint_list[list_index].Add(new CustomDataPoint(nn.SortIdx, value, /*nn.Index.ToString() +*/ "(" + s_chain[nn.SortIdx] + ")", nn.Mz, nn.Name)); }
                        else { datapoint_list[list_index].Add(new CustomDataPoint(nn.SortIdx, value, /*nn.Index.ToString() +*/ "(" + s_chain[nn.SortIdx-1] + ")", nn.Mz, nn.Name)); }                        
                        if (points_line_.Count == 0 || points_line_.Last()[0] != nn.SortIdx)
                        {
                            points_line_.Add(new double[] { nn.SortIdx, nn.Max_intensity, primary_int });
                        }
                        else if (points_line_.Last()[1] < nn.Max_intensity) { points_line_.Last()[1] = nn.Max_intensity; points_line_.Last()[2] = primary_int; }
                    }
                    if (points_line_.Count > 0)
                    {
                        double min_add = 0.0;
                        if (is_logarithmic) {  min_add = 0.00000000001; }
                        foreach (double[] dd in points_line_)
                        {
                            double value = 0.0;
                            if (dd[1] == 0 && dd[2] == 0) { value = min_add; }
                            else
                            {
                                if (dd[2] == 0) dd[2] = 1.0;
                                value = dd[1] / dd[2];
                                //if (is_logarithmic) value = Math.Log(value);
                            }
                            if (line_.Points.Count > 0 && dd[0] - line_.Points.Last().X != 1)
                            {
                                double temp_x = line_.Points.Last().X + 1;
                                while (temp_x < dd[0])
                                {
                                    line_.Points.Add(new DataPoint(temp_x, min_add));
                                    temp_x++;
                                }
                            }
                            else if (line_.Points.Count == 0 && dd[0] > 1)
                            {
                                line_.Points.Add(new DataPoint(dd[0] - 1, min_add));
                            }
                            line_.Points.Add(new DataPoint(dd[0], value));
                        }
                        if (line_.Points.Last().X < s_chain.Length) line_.Points.Add(new DataPoint(line_.Points.Last().X + 1, min_add));
                        if(name.Contains("+"))plus_plot.Model.Series.Add(line_);
                        else minus_plot.Model.Series.Add(line_);
                    }
                    for (int i = 9; i >= 0; i--)
                    {
                        if (datapoint_list[i].Count > 0)
                        {
                            series_list[i].ItemsSource = datapoint_list[i]; series_list[i].TrackerFormatString = "{0}\n{1}: {2:0.###}\n{3}: {4:0.###}\nMonoisotopic Mass: {Text}\n{Name}\n"+text+":{Xreal}";
                            if (name.Contains("+")) plus_plot.Model.Series.Add(series_list[i]);
                            else minus_plot.Model.Series.Add(series_list[i]);
                        }
                    }
                }
                if (is_logarithmic) { maximum = Math.Pow(maximum, 1.2); if (minimum<0)minimum = Math.Pow(minimum,1.5); else minimum = Math.Pow(minimum, 0.8); }
                else{ minimum =-0.10*maximum; maximum = 1.2 * maximum; }                
            }
            maximum = round_to_10_power(maximum,false);
            minimum = round_to_10_power(minimum,true);
            plus_plot.Model.Axes[0].AxisChanged += (s, e) =>
            {
                s1a.Points.Clear(); s2a.Points.Clear();
                for (int cc = 0; cc < s_chain.Length; cc++)
                {
                    if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                    {
                        s1a.Points.Add(new ScatterPoint(cc + 1, find_bound_s(plus_plot.Model.Axes[0].ActualMinimum,true,is_logarithmic)));                        
                    }
                    else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                    {
                         s2a.Points.Add(new ScatterPoint(cc + 1, find_bound_s(plus_plot.Model.Axes[0].ActualMaximum, false, is_logarithmic)));                       
                    }
                }
                plus_plot.Model.Series[0] = s1a; plus_plot.Model.Series[1] = s2a; plus_plot.InvalidatePlot(true);
            };
            minus_plot.Model.Axes[0].AxisChanged += (s, e) =>
            {
                s1b.Points.Clear(); s2b.Points.Clear();
                for (int cc = 0; cc < s_chain.Length; cc++)
                {
                    if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                    {
                        s1b.Points.Add(new ScatterPoint(cc + 1, find_bound_s(minus_plot.Model.Axes[0].ActualMinimum,true,is_logarithmic)));                       
                    }
                    else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                    {
                        s2b.Points.Add(new ScatterPoint(cc + 1, find_bound_s(minus_plot.Model.Axes[0].ActualMaximum ,false,is_logarithmic)));                        
                    }
                }
                minus_plot.Model.Series[0] = s1b; minus_plot.Model.Series[1] = s2b; minus_plot.InvalidatePlot(true);
            };
            plus_plot.Model.Axes[1].Minimum =0;minus_plot.Model.Axes[1].Minimum = 0;
            plus_plot.Model.Axes[1].Maximum = s_chain.Length;minus_plot.Model.Axes[1].Maximum = s_chain.Length;
            plus_plot.Model.Axes[0].Minimum = minimum; minus_plot.Model.Axes[0].Minimum = minimum;
            plus_plot.Model.Axes[0].Maximum = maximum; minus_plot.Model.Axes[0].Maximum = maximum;

            ////absolute minimum,absolute maximum
            //plus_plot.Model.Axes[0].AbsoluteMinimum = minimum; minus_plot.Model.Axes[0].AbsoluteMinimum = minimum;
            //plus_plot.Model.Axes[0].AbsoluteMaximum = maximum; minus_plot.Model.Axes[0].AbsoluteMaximum = maximum;

            s1a.Points.Clear(); s2a.Points.Clear();s1b.Points.Clear(); s2b.Points.Clear();               
            minimum = find_bound_s(minimum, true, is_logarithmic);
            maximum = find_bound_s(maximum, false, is_logarithmic);
            for (int cc = 0; cc < s_chain.Length; cc++)
            {
                if (s_chain.ToArray()[cc].Equals('D') || s_chain[cc].Equals('E'))
                {
                    s1a.Points.Add(new ScatterPoint(cc + 1, minimum));
                    s1b.Points.Add(new ScatterPoint(cc + 1, minimum));
                }
                else if (s_chain.ToArray()[cc].Equals('H') || s_chain[cc].Equals('R') || s_chain[cc].Equals('K'))
                {
                    s2a.Points.Add(new ScatterPoint(cc + 1, maximum));
                    s2b.Points.Add(new ScatterPoint(cc + 1, maximum));
                }
            }
            plus_plot.Model.Series[0] = s1a; plus_plot.Model.Series[1] = s2a;
            plus_plot.InvalidatePlot(true);
            minus_plot.Model.Series[0] = s1b; minus_plot.Model.Series[1] = s2b;
            minus_plot.InvalidatePlot(true);
        }
        private Color[] create_check_boxes(string type, Panel checks_panel, Panel pnl)
        {
            string pattern = @"[" + type + "][+-][1-9][0-9]?(?![(])";
            Color[] clr = return_check_boxes_colors(type, checks_panel);
            string s_ext = "";
            string s_chain = Peptide;
            int color_counter = 0;
            List<ion> temp_iondraw = IonDraw.ToList();
            int iondraw_count = temp_iondraw.Count;                      
            //if ion list is empty clear checkboxes and return
            if (iondraw_count == 0) { checks_panel.Controls.Clear(); return clr; }
            List<CheckBox> check_names = new List<CheckBox>();
            foreach (Control cc in checks_panel.Controls)
            {
                check_names.AddRange( GetControls(cc).OfType<CheckBox>().ToList());
            }
            if (check_names.Count > 0) checks_panel.Controls.Clear();
            FlowLayoutPanel flowpnl_1 = new FlowLayoutPanel() { Height= checks_panel.Height/2-20,Width= checks_panel.Width-10,Location=new Point(3,20),AutoScroll=true,AutoScrollMargin=new Size(1,0)};
            FlowLayoutPanel flowpnl_2 = new FlowLayoutPanel() { Height = checks_panel.Height / 2-20, Width = checks_panel.Width-10, Location = new Point(3,20+pnl.Height / 2), AutoScroll = true, AutoScrollMargin = new Size(1, 0) };
            if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox.SelectedItem)) { s_chain = seq.Sequence; s_ext = seq.Extension; break; }
                }
            }
            //fill the list with the correct names            
            for (int i = 0; i < iondraw_count; i++)
            {
                ion nn = temp_iondraw[i];
                if (nn.Ion_type.Count()==1) { continue; }
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                Match matches = Regex.Match(nn.Ion_type, pattern);
                if (!matches.Success) { continue; }
                if (nn.Ion_type.StartsWith(type) || nn.Ion_type.StartsWith("(" + type))
                {
                    string tt = type.ToString();
                    int index = -1;
                    if (nn.Ion_type.Contains(type + "-")) { index = nn.Ion_type.IndexOf(type + "-"); }
                    else if (nn.Ion_type.Contains(type + "+")) { index = nn.Ion_type.IndexOf(type + "+"); }
                    if (index != -1 && iParser(nn.Ion_type[index + type.Length + 1].ToString()) != 0)
                    {
                        tt = nn.Ion_type.Substring(index, type.Length + 2);
                        if (int.TryParse(nn.Ion_type.Substring(index + type.Length + 2), out int i2)) { tt = nn.Ion_type.Substring(index, type.Length + 3); }
                        if (check_names.Count == 0 || !check_names.Any(p => p.Text.Equals(tt)))
                        {
                            CheckBox ckbx = new CheckBox() { Text = tt, Checked = true };
                            if (ckbx.Text.Contains("-2")) { ckbx.ForeColor = clr[0]; }
                            else if (ckbx.Text.Contains("-1")) { ckbx.ForeColor = clr[1]; }
                            else if (ckbx.Text.Contains("+1")) { ckbx.ForeColor = clr[2]; }
                            else if (ckbx.Text.Contains("+2")) { ckbx.ForeColor = clr[3]; }
                            else
                            {
                                if (color_counter>3) {  color_counter = 0; }
                                ckbx.ForeColor = clr[color_counter];
                                color_counter ++ ;
                            }
                            ckbx.CheckedChanged += (s, e) =>
                            {
                                ckbx.Parent.Parent.Parent.Controls.OfType<Panel>().Where(l=>l.Name.Contains("plot")).First().Invalidate();
                            };
                            ckbx.MouseUp += (s, e) =>
                            {
                                if (e.Button == MouseButtons.Right)
                                {
                                    ContextMenu ctxMn = new ContextMenu(new MenuItem[1] {
                                        new MenuItem("Select Color", (ss, ee) =>{                                        
                                        if (clrDlg.ShowDialog() == DialogResult.OK){ckbx.ForeColor = clrDlg.Color; pnl.Invalidate();}
                                        })
                                    });
                                    ckbx.ContextMenu = ctxMn;
                                }
                            };
                            check_names.Add(ckbx);
                        }
                    }
                }
            }
            if (check_names.Count == 0) return clr;
            check_names = check_names.OrderBy(p => p.Text).ToList();
            foreach (CheckBox ckbx in check_names)
            {
                //ckbx.Width = checks_panel.Width - 20;
                ckbx.AutoSize = true;
                if (ckbx.Text.Contains("+"))flowpnl_1.Controls.Add(ckbx);
                else flowpnl_2.Controls.Add(ckbx);
            }
            checks_panel.Controls.AddRange(new Control[] { flowpnl_1 , flowpnl_2});
            temp_iondraw.Clear();
            return clr;
        }
        private double search_primary_return_intens(string type, int idx, string s_ext,int charge, List<ion> temp_iondraw)
        {
            double intensity = 0.0;
            foreach (ion nn in temp_iondraw)
            {
                if (!string.IsNullOrEmpty(s_ext) && !recognise_extension(nn.Extension, s_ext)) { continue; }
                else if (string.IsNullOrEmpty(s_ext) && !string.IsNullOrEmpty(nn.Extension)) { continue; }
                if (nn.SortIdx > idx) break;
                else if (  nn.SortIdx == idx &&nn.Charge==charge && nn.Ion_type.Equals(type)) {intensity += nn.Max_intensity;break; }
            }
            return intensity;
        }
        private void losses_save_copyBtn_Click(object sender, EventArgs e)
        {
            bool copy = false;
            ToolStripButton tsp = (sender as ToolStripButton);
            if (tsp.Text.Contains("Copy")) copy = true;
            find_plot_ingrp_export(tsp.GetCurrentParent().Parent, copy);
        }
        private void plot_Pnl_Resize(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            ToolStrip tsp = GetControls(pnl.Parent).OfType<ToolStrip>().FirstOrDefault();
            ToolStripTextBox X_Box = tsp.Items.OfType<ToolStripTextBox>().Where(l => l.Name.Contains("X_Box")).FirstOrDefault();
            ToolStripTextBox Y_Box = tsp.Items.OfType<ToolStripTextBox>().Where(l => l.Name.Contains("Y_Box")).FirstOrDefault();
            X_Box.Text = pnl.Size.Width.ToString();
            Y_Box.Text = pnl.Size.Height.ToString();
        }
        private void losses_plot_panel_Paint(object sender, PaintEventArgs e)
        {
            GroupBox grp = (sender as Panel).Parent as GroupBox;
            string code = grp.Name.Last().ToString();
            create_plotview(grp, code);
        }
        private void losses_extractBtn_Click(object sender, EventArgs e)
        {
            ToolStripItem tsp = (sender as ToolStripItem);
            ToolStripItem menu = tsp.OwnerItem;
            ToolStrip tt = menu.GetCurrentParent();
            GroupBox grp = tt.Parent as GroupBox;
            string code = grp.Name.Last().ToString();
            create_export_plotview(grp, code);
        }
        private void losses_style_Btn_Click(object sender, EventArgs e)
        {
            foreach (SequenceTab seq in sequenceList)
            {
                if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                {
                    color_primary_indexes = seq.Index_SS_primary.ToList();
                    break;
                }
            }
            Form12_2 frm12_2 = new Form12_2(this);
            frm12_2.FormClosed += (s, f) => { save_preferences(); };
            frm12_2.ShowDialog();
        }
        public void inval_style_Refresh_Btn()
        {
            tabControl1.TabPages["tab_Hydrogens"].Invalidate();
        }
        private double round_to_10_power(double initial, bool is_minimum)
        {
            double final = 0.0;
            final = Math.Abs(initial);
            double num =  10;
            if (is_minimum && initial<0) { is_minimum = false; }
            else if (!is_minimum && initial < 0) { is_minimum = true; }
            if (final<1)
            {
                while (num > 0)
                {
                    if (final * num < 1) { num = num * 10;  }
                    else if(is_minimum){final = 1/(num*10); break;}
                    else { final = 10/num; break; }
                }
            }
            else
            {
                while (num > 0)
                {
                    if (final / num > 1 ||(final / num == 1 && !is_minimum))
                    {
                        num = num * 10;                        
                    }
                    else if (final / num == 1 && is_minimum)
                    {
                        final = num/10; break;
                    }
                    else if(is_minimum)
                    {
                        final = num/100; break;
                    }
                    else
                    {
                        final = num; break;
                    }
                }
            }           
            if (initial < 0) final = final * (-1);
            return final;
        }
        private double find_bound_s(double bound_value,bool is_minimum, bool is_log=false)
        {
            //is_minimum : want greater than bound
            //!is_minimum : want smaller than bound
            double final_value = bound_value;                   
            if (is_log)
            {
                // log bounds are >0, therefore I want final<max, and final>min                
                if ((final_value<1 && is_minimum)||(final_value >= 1 &&!is_minimum))
                {
                    final_value = Math.Pow(final_value, 0.99);
                }
                else
                {
                    final_value = Math.Pow(final_value, 1.01);
                }
            }
            else
            {
                if ((final_value < 0 && is_minimum) || (final_value >= 0 && !is_minimum))
                {
                    final_value =final_value* 0.99;
                }
                else
                {
                    final_value = final_value* 1.01;
                }
            }
            return final_value;
        }
        private void replot_grp_CheckStateChanged(object sender, EventArgs e)
        {
            ToolStripItem tsp = (sender as ToolStripItem);
            ToolStrip tt = tsp.GetCurrentParent();
            GroupBox grp = tt.Parent as GroupBox;
            Panel pnl = GetControls(grp).OfType<Panel>().Where(l => l.Name.Contains("plot")).First();
            pnl.Invalidate();
        }
        private void losses_legendBtn1_CheckStateChanged(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Shows or hides legend", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            ToolStripItem tsp = (sender as ToolStripItem);
            ToolStrip tt = tsp.GetCurrentParent();
            GroupBox grp = tt.Parent as GroupBox;
            Panel pnl = GetControls(grp).OfType<Panel>().Where(l => l.Name.Contains("plot")).First();
            pnl.Invalidate();
        }
        #endregion

        #endregion

        #region EXTRACT PLOTS

        #region extract ppm_plot
        private void extractPlotToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ppm_plotview_rebuild();
        }
        public void ppm_plotview_rebuild()
        {
            PlotView temp_plot = new PlotView() { Name = "temp_plot ", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = ppm_legend_Btn.Checked, LegendPlacement = LegendPlacement.Outside, LegendPosition = LegendPosition.RightBottom, LegendFontSize = 10, TitleFontSize = 14, Title = "ppm Error", TitleColor = OxyColors.Teal, SubtitleFontSize = 10, SubtitleFont = "Arial" };
            temp_plot.Model = temp_model;
            var linearAxis21 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Ymajor_ppm_grid, MinorGridlineStyle = Yminor_ppm_grid, FontSize = 10, TickStyle = Y_ppm_tick, MajorStep = y_ppm_majorStep, MinorStep = y_ppm_minorStep, MinimumMinorStep = 1.0, AxisTitleDistance = 7, TitleFontSize = 11, Title = "ppm Error" };
            temp_model.Axes.Add(linearAxis21);
            var linearAxis22 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Xmajor_ppm_grid, MinorGridlineStyle = Xminor_ppm_grid, FontSize = 10, TickStyle = X_ppm_tick,IntervalLength= x_ppm_interval /*MajorStep = x_ppm_majorStep, MinorStep = x_ppm_minorStep*/, AxisTitleDistance = 7, TitleFontSize = 11, Title = "# fragments", Position = OxyPlot.Axes.AxisPosition.Bottom };
            temp_model.Axes.Add(linearAxis22);
            temp_plot.MouseDoubleClick += (s, e) => { temp_model.ResetAllAxes(); temp_plot.InvalidatePlot(true); };
            temp_plot.Controller = new CustomPlotController();
            ppm_plot_init(temp_plot);
            temp_plot.Model.Axes[1].Zoom(ppm_plot.Model.Axes[1].ActualMinimum, ppm_plot.Model.Axes[1].ActualMaximum);
            temp_plot.Model.Axes[0].Zoom(ppm_plot.Model.Axes[0].ActualMinimum, ppm_plot.Model.Axes[0].ActualMaximum);
            Form11 frm11 = new Form11(temp_plot, temp_plot);
            frm11.Show();
        }
        #endregion

        #region FORM 20 extract plot isoplot
        public void plotview_rebuild()
        {
            LightningChartUltimate temp_plot = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { Dock = DockStyle.Fill, ColorTheme = ColorTheme.LightGray };
            temp_plot.BeginUpdate();           
            //temp_plot.BackColor = Color.White;
            ViewXY v = temp_plot.ViewXY;
            v.ZoomPanOptions.RightToLeftZoomAction = RightToLeftZoomActionXY.PopFromZoomStack;
            v.ZoomPanOptions.AxisMouseWheelAction = AxisMouseWheelAction.PanAll;
            temp_plot.Background = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            v.GraphBackground = new Fill() { Color = Color.White, GradientColor = Color.White, Style = RectFillStyle.ColorOnly };
            temp_plot.Parent = this;
            temp_plot.Title.Visible = false;
            temp_plot.ViewXY.LegendBox.Visible = false;
            temp_plot.Name = "temp_plot1";
            temp_plot.ViewXY.LegendBox.Visible = false;
            temp_plot.ViewXY.LegendBox.ShowCheckboxes = true;
            temp_plot.ViewXY.LegendBox.Layout = LegendBoxLayout.Vertical;
            AxisX axisX_1 = temp_plot.ViewXY.XAxes[0];
            AxisY axisY_1 = temp_plot.ViewXY.YAxes[0];
            axisX_1.Title.Text = "m/z"; axisY_1.Title.Text = "Intensity";
            axisX_1.MajorGrid.Visible = Xmajor_grid; axisX_1.MajorGrid.Pattern = LinePattern.Solid;
            axisX_1.MinorGrid.Visible = Xminor_grid; axisX_1.MinorGrid.Pattern = LinePattern.Solid;
            axisY_1.MajorGrid.Visible = Ymajor_grid; axisY_1.MajorGrid.Pattern = LinePattern.Solid;
            axisY_1.MinorGrid.Visible = Yminor_grid; axisY_1.MinorGrid.Pattern = LinePattern.Solid;
            axisX_1.ScrollMode = XAxisScrollMode.None;
            axisX_1.ValueType = AxisValueType.Number;
            axisX_1.Title.MouseInteraction = false;
            axisX_1.AutoFormatLabels = false; axisX_1.LabelsNumberFormat = x_format + x_numformat;
            axisY_1.Title.MouseInteraction = false;
            axisY_1.AutoFormatLabels = false; axisY_1.LabelsNumberFormat = y_format + y_numformat;

            //Add a line series cursor 
            LineSeriesCursor cursor_1 = new LineSeriesCursor(temp_plot.ViewXY, axisX_1);
            cursor_1.SnapToPoints = false;
            v.AxisLayout.YAxisAutoPlacement = YAxisAutoPlacement.LeftThenRight;
            v.AxisLayout.XAxisAutoPlacement = XAxisAutoPlacement.BottomThenTop;
            temp_plot.EndUpdate();
            refresh_temp_plot(temp_plot);
            temp_plot.MouseDoubleClick += (s, e) => { v.ZoomToFit();  };
            Form20 frm20 = new Form20(temp_plot, LC_1.ViewXY.XAxes[0].Minimum, LC_1.ViewXY.XAxes[0].Maximum, LC_1.ViewXY.YAxes[0].Minimum, LC_1.ViewXY.YAxes[0].Maximum);
            frm20.Show();
        }

        private void refresh_temp_plot(LightningChartUltimate temp_plot)
        {
            //Remove existing series
            DisposeAllAndClear(temp_plot.ViewXY.PointLineSeries);
            DisposeAllAndClear(temp_plot.ViewXY.BarSeries);
            DisposeAllAndClear(temp_plot.ViewXY.LineCollections);
            temp_plot.BeginUpdate();

            //// 0.a gather info on which fragments are selected to plot, and their respective intensities
            //List<int> to_plot = selectedFragments.ToList(); // deep copy, don't mess selectedFragments
            List<int> to_plot = new List<int>();
            List<int> to_plot2 = new List<int>();
            string[] label_temp = label_frag.ToArray();
            string[] frag_temp = view_frag.ToArray();
            //0.a add only the desired fragments to to_plot
            if (plotFragProf_chkBox.Checked || plotFragCent_chkBox.Checked || Fitting_chkBox.Checked)
            {
                foreach (int idx in selectedFragments)
                {
                    string ion = Fragments2[idx - 1].Ion_type;
                    if (ion.StartsWith("a") || ion.StartsWith("(a"))
                    {
                        if (frag_temp.Any(p => p.Equals("a"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("a"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("b") || ion.StartsWith("(b"))
                    {
                        if (frag_temp.Any(p => p.Equals("b"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("b"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("c") || ion.StartsWith("(c"))
                    {
                        if (frag_temp.Any(p => p.Equals("c"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("c"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("x") || ion.StartsWith("(x"))
                    {
                        if (frag_temp.Any(p => p.Equals("x"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("x"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("y") || ion.StartsWith("(y"))
                    {
                        if (frag_temp.Any(p => p.Equals("y"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("y"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("z") || ion.StartsWith("(z"))
                    {
                        if (frag_temp.Any(p => p.Equals("z"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("z"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("int") && ion.Contains("b"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal b"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal b"))) { to_plot2.Add(idx); } }
                    }
                    else if (!is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal a"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal a"))) { to_plot2.Add(idx); } }
                    }
                    else if (is_riken && ion.Contains("int"))
                    {
                        if (frag_temp.Any(p => p.Equals("internal"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("internal"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("d") || ion.StartsWith("(d"))
                    {
                        if (frag_temp.Any(p => p.Equals("d"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("d"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("w") || ion.StartsWith("(w"))
                    {
                        if (frag_temp.Any(p => p.Equals("w"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("w"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.StartsWith("v") || ion.StartsWith("(v"))
                    {
                        if (frag_temp.Any(p => p.Equals("v"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("v"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("M"))
                    {
                        if (frag_temp.Any(p => p.Equals("M"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("M"))) { to_plot2.Add(idx); } }
                    }
                    else if (ion.Contains("B("))
                    {
                        if (frag_temp.Any(p => p.Equals("B"))) { to_plot.Add(idx); if (label_temp.Any(p => p.Equals("B"))) { to_plot2.Add(idx); } }
                    }
                    else
                    {
                        to_plot.Add(idx); to_plot2.Add(idx);
                    }

                }
            }
            // 0.b. reset iso plot
            reset_temp_plot(temp_plot);

            // 1.b Add the experimental to plot if selected
            if (plotExp_chkBox.Checked && all_data.Count > 0)
            {
                double[] mz = all_data[0].Select(a => a[0]).ToArray();
                double[] y = all_data[0].Select(a => a[1]).ToArray();
                PointLine_addSeries(temp_plot, 0, mz, y, 1);
            }

            // 2. replot all isotopes
            if (plotFragProf_chkBox.Checked && all_data.Count > 1)
            {
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count > curr_idx)
                    {
                        double[] mz = all_data[curr_idx].Select(a => a[0]).ToArray();
                        double[] y = all_data[curr_idx].Select(a => a[1]).ToArray();
                        PointLine_addSeries(temp_plot, curr_idx, mz, y, Fragments2[curr_idx - 1].Factor);
                    }
                }
                if (ExtraFragCalculator.now)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int curr_idx = Fragments2.Count + f + 1;
                        int frag = ExtraFragCalculator.last_plotted[f];
                        double[] mz = all_data[curr_idx].Select(a => a[0]).ToArray();
                        double[] y = all_data[curr_idx].Select(a => a[1]).ToArray();
                        PointLine_addSeries(temp_plot, curr_idx, mz, y, ExtraFragCalculator.Fragments3[frag].Factor);
                    }
                }
            }
            if (plotFragCent_chkBox.Checked && all_data.Count > 1)
            {
                int help = Convert.ToInt32(ExtraFragCalculator.now);
                for (int i = 0; i < to_plot.Count; i++)
                {
                    int curr_idx = to_plot[i];
                    if (all_data.Count > curr_idx)
                    {
                        List<PointPlot> cenn = Fragments2[curr_idx - 1].Centroid.OrderBy(p => p.X).ToList();
                        LineCollection_addLines1(temp_plot, curr_idx - 1, cenn, Fragments2[curr_idx - 1].Factor);
                    }
                }
                if (ExtraFragCalculator.now)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int curr_idx = ExtraFragCalculator.last_plotted[f];
                        if (all_data.Count > 1)
                        {
                            // get name of each line to be ploted
                            string name_str = ExtraFragCalculator.Fragments3[curr_idx].Name;
                            List<PointPlot> cenn = ExtraFragCalculator.Fragments3[curr_idx].Centroid.OrderBy(p => p.X).ToList();
                            LineCollection_addLines1(temp_plot, Fragments2.Count + f, cenn, ExtraFragCalculator.Fragments3[curr_idx].Factor);
                        }
                    }
                }
            }

            // 3. fitted plot
            if (summation.Count > 0 && Fitting_chkBox.Checked) PointLine_addSeries(temp_plot, all_data.Count, summation);

            // 5. centroid (bar)
            if (plotCentr_chkBox.Checked /*&& !is_exp_deconvoluted*/ && peak_points.Count > 0)
            {
                int pointCount = peak_points.Count;
                List<double[]> data_decon = new List<double[]>();
                for (int bar = 0; bar < pointCount; bar++)
                {
                    double[] peak = peak_points[bar];
                    double mz = peak[1] + peak[4];
                    double inten = peak[5];
                    data_decon.Add(new double[] { mz, inten });
                }
                LineCollection_addLines(temp_plot, all_data.Count - 1, data_decon);
            }            

            // 6. fragment annotations
            if (plotFragCent_chkBox.Checked || plotFragProf_chkBox.Checked)
            {
                frag_annotation(to_plot2, temp_plot);
            }
            else
            {
                DisposeAllAndClear(temp_plot.ViewXY.Annotations);
            }
            temp_plot.EndUpdate();
        }

        private void reset_temp_plot(LightningChartUltimate temp_plot)
        {
            for (int i = 0; i < all_data.Count; i++)
            {
                Color cc;
                string name;
                float width;
                if (ExtraFragCalculator.now == true && i == all_data.Count - ExtraFragCalculator.last_plotted.Count)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int frag = ExtraFragCalculator.last_plotted[f];
                        cc = ExtraFragCalculator.Fragments3[frag].Color.ToColor();
                        name = ExtraFragCalculator.Fragments3[frag].Name;
                        width = (float)frag_width;
                        Init_PointLineSeries(temp_plot, name, cc, width, frag_style);
                    }
                    break;
                }
                else
                {
                    cc = get_fragment_color1(i);

                    if (i == 0) // experimental
                    {
                        name = "exp";
                        width = (float)exp_width;
                        Init_PointLineSeries(temp_plot, name, cc, width, exper_style);
                    }
                    else
                    {
                        name = Fragments2[i - 1].Name;
                        width = (float)frag_width;
                        Init_PointLineSeries(temp_plot, name, cc, width, frag_style);
                    }
                }
            }
            for (int i = 1; i < all_data.Count; i++)
            {
                if (ExtraFragCalculator.now == true && i == all_data.Count - ExtraFragCalculator.last_plotted.Count)
                {
                    for (int f = 0; f < ExtraFragCalculator.last_plotted.Count; f++)
                    {
                        int frag = ExtraFragCalculator.last_plotted[f];
                        Color cc = ExtraFragCalculator.Fragments3[frag].Color.ToColor();
                        Init_LineCollection_Plot(temp_plot, ExtraFragCalculator.Fragments3[frag].Name, cc, (int)cen_width);
                    }
                    break;
                }
                else
                {
                    Color cc = get_fragment_color1(i);
                    Init_LineCollection_Plot(temp_plot, Fragments2[i - 1].Name, cc, (int)cen_width);
                }
            }
            if (insert_exp == true)
            {
                Init_PointLineSeries(temp_plot, "fit", fit_color.ToColor(), (float)fit_width, fit_style);
            }
            if (plotCentr_chkBox.Checked)
            {
                Init_LineCollection_Plot(temp_plot, "exp", peak_color.ToColor(), (int)peak_width);
            }
        }

        #endregion

        #region FORM 15 extract internal fragments plot
        private void extractPlotToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            internal_panel_plotview_rebuild();
        }
        private void internal_panel_plotview_rebuild(bool indexTo = false)
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
            temp_index_plot.Controller = new CustomPlotController();
            // index intensity plot            
            PlotView tempindex_Intensity_plot = new PlotView() { Name = "tempiIntensity_plot", BackColor = Color.White, Dock = System.Windows.Forms.DockStyle.Fill };
            PlotModel temp_index_Intensity_model = new PlotModel { PlotType = PlotType.XY, TitleFont = "Arial", DefaultFont = "Arial", IsLegendVisible = false, TitleFontSize = 14, Title = "intensity plot", TitleColor = OxyColors.Teal };
            tempindex_Intensity_plot.Model = temp_index_Intensity_model;
            var linearAxis11 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = Yint_major_grid13, MinorGridlineStyle = Yint_minor_grid13, MajorStep = yINT_majorStep13, MinorStep = yINT_minorStep13, TickStyle = Yint_tick13, FontSize = 10, MinimumMinorStep = 1.0, Position = OxyPlot.Axes.AxisPosition.Left };
            temp_index_Intensity_model.Axes.Add(linearAxis11);
            var linearAxis12 = new OxyPlot.Axes.LinearAxis() { StringFormat = x_format13 + x_numformat13, MajorGridlineStyle = Xint_major_grid13, MinorGridlineStyle = Xint_minor_grid13, IntervalLength = x_interval13, TickStyle = Xint_tick13, FontSize = 10, AxisTitleDistance = 7, TitleFontSize = 11, Title = "Intensity", Position = OxyPlot.Axes.AxisPosition.Bottom };
            temp_index_Intensity_model.Axes.Add(linearAxis12);
            tempindex_Intensity_plot.MouseDoubleClick += (s, e) => { temp_index_Intensity_model.ResetAllAxes(); tempindex_Intensity_plot.InvalidatePlot(true); };
            tempindex_Intensity_plot.Controller = new CustomPlotController();

            //bind the 2 axes
            linearAxis7.AxisChanged += (s, e) => { linearAxis11.Zoom(linearAxis7.ActualMinimum, linearAxis7.ActualMaximum); tempindex_Intensity_plot.InvalidatePlot(true); };
            temp_indexModel.Updated += (s, e) => { tempindex_Intensity_plot.Model.Axes[0].Zoom(temp_index_plot.Model.Axes[0].ActualMinimum, temp_index_plot.Model.Axes[0].ActualMaximum); };
            if (indexTo)
            {
                create_internal_plot(temp_index_plot, tempindex_Intensity_plot, 1, Color.Green, Color.Blue);
                temp_indexModel.Title = "internal  fragments' plot sorted by #AA terminal";
                temp_index_plot.Model.Axes[1].Zoom(indexto_plot.Model.Axes[1].ActualMinimum, indexto_plot.Model.Axes[1].ActualMaximum);
                temp_index_plot.Model.Axes[0].Zoom(indexto_plot.Model.Axes[0].ActualMinimum, indexto_plot.Model.Axes[0].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[1].Zoom(indextoIntensity_plot.Model.Axes[1].ActualMinimum, indextoIntensity_plot.Model.Axes[1].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[0].Zoom(indextoIntensity_plot.Model.Axes[0].ActualMinimum, indextoIntensity_plot.Model.Axes[0].ActualMaximum);
            }
            else
            {
                create_internal_plot(temp_index_plot, tempindex_Intensity_plot, 2, Color.Green, Color.Blue);
                temp_index_plot.Model.Axes[1].Zoom(index_plot.Model.Axes[1].ActualMinimum, index_plot.Model.Axes[1].ActualMaximum);
                temp_index_plot.Model.Axes[0].Zoom(index_plot.Model.Axes[0].ActualMinimum, index_plot.Model.Axes[0].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[1].Zoom(indexIntensity_plot.Model.Axes[1].ActualMinimum, indexIntensity_plot.Model.Axes[1].ActualMaximum);
                tempindex_Intensity_plot.Model.Axes[0].Zoom(indexIntensity_plot.Model.Axes[0].ActualMinimum, indexIntensity_plot.Model.Axes[0].ActualMaximum);
            }
            paint_annotations_in_temp_graphs(2, temp_index_plot);
            //refresh_temp_internal(temp_index_plot, tempindex_Intensity_plot);
            Form15 frm15 = new Form15(temp_index_plot, tempindex_Intensity_plot);
            frm15.Show();
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
            if (fplot_type > 4)
            {
                temp_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendOrientation = LegendOrientation.Horizontal, LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendFontSize = 10, TitleFontSize = 14, TitleFont = "Arial", DefaultFont = "Arial" };
            }
            if (fplot_type == 1 || fplot_type == 5) { temp_model.Title = "a - x  fragments"; temp_model.TitleColor = OxyColors.Green; }
            else if (fplot_type == 2 || fplot_type == 6) { temp_model.Title = "b - y  fragments"; temp_model.TitleColor = OxyColors.Blue; }
            else if (fplot_type == 3 || fplot_type == 7) { temp_model.Title = "c - z  fragments"; temp_model.TitleColor = OxyColors.Red; }
            else { temp_model.Title = "d - z  fragments"; temp_model.TitleColor = OxyColors.DeepPink; }
            temp_plot.Model = temp_model;
            if (fplot_type < 5)
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
            temp_plot.Controller = new CustomPlotController();
            if (is_riken)
            {
                if (fplot_type == 1) intensity_plot_init(temp_plot, "a", "w", 1, OxyColors.Green, OxyColors.LimeGreen);
                else if (fplot_type == 2) intensity_plot_init(temp_plot, "b", "x", 2, OxyColors.Blue, OxyColors.DodgerBlue);
                else if (fplot_type == 3) intensity_plot_init(temp_plot, "c", "y", 3, OxyColors.Firebrick, OxyColors.Tomato);
                else if (fplot_type == 4) intensity_plot_init(temp_plot, "d", "z", 4, OxyColors.DeepPink, OxyColors.HotPink);
                else if (fplot_type == 5) charge_plot_init(temp_plot, "a", "w", 1, Color.Green, Color.LimeGreen);
                else if (fplot_type == 6) charge_plot_init(temp_plot, "b", "x", 2, Color.Blue, Color.DodgerBlue);
                else if (fplot_type == 7) charge_plot_init(temp_plot, "c", "y", 3, Color.Firebrick, Color.Tomato);
                else if (fplot_type == 8) charge_plot_init(temp_plot, "d", "z", 4, Color.DeepPink, Color.HotPink);
            }
            else
            {
                if (fplot_type == 1) intensity_plot_init(temp_plot, "a", "x", 1, OxyColors.Green, OxyColors.LimeGreen);
                else if (fplot_type == 2) intensity_plot_init(temp_plot, "b", "y", 2, OxyColors.Blue, OxyColors.DodgerBlue);
                else if (fplot_type == 3) intensity_plot_init(temp_plot, "c", "z", 3, OxyColors.Firebrick, OxyColors.Tomato);
                else if (fplot_type == 5) charge_plot_init(temp_plot, "a", "x", 1, Color.Green, Color.LimeGreen);
                else if (fplot_type == 6) charge_plot_init(temp_plot, "b", "y", 2, Color.Blue, Color.DodgerBlue);
                else if (fplot_type == 7) charge_plot_init(temp_plot, "c", "z", 3, Color.Firebrick, Color.Tomato);
            }
            //refresh_temp_primary_plots(temp_plot, fplot_type);
            temp_plot.Model.Axes[1].Zoom(original_plotview.Model.Axes[1].ActualMinimum, original_plotview.Model.Axes[1].ActualMaximum);
            temp_plot.Model.Axes[0].Zoom(original_plotview.Model.Axes[0].ActualMinimum, original_plotview.Model.Axes[0].ActualMaximum);
            paint_annotations_in_temp_graphs(1, temp_plot);
            Form11 frm11 = new Form11(temp_plot, temp_plot);
            frm11.Show();
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
            primary_plotview_rebuild(5, axCharge_plot);
        }

        private void extractPlotToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(6, byCharge_plot);
        }

        private void extractPlotToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(7, czCharge_plot);
        }
        private void extractPlotToolStripMenuItem_charge_dz_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(8, dzCharge_plot);
        }

        private void extractPlotToolStripMenuItem_dz_Click(object sender, EventArgs e)
        {
            primary_plotview_rebuild(4, dz_plot);
        }

        #endregion

        public void paint_annotations_in_temp_graphs(int code, PlotView temp)
        {
            if (sequenceList == null || sequenceList.Count == 0) return;
            List<int[]> temp_primary = color_primary_indexes.ToList();
            List<int[]> temp_internal = color_internal_indexes.ToList();
            if (tab_mode && seq_extensionBox.Enabled && seq_extensionBox.SelectedIndex != -1)
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    if (seq.Extension.Equals(seq_extensionBox.SelectedItem))
                    {
                        temp_primary = seq.Index_SS_primary.ToList();
                        temp_internal = seq.Index_SS_internal.ToList();
                        break;
                    }
                }
            }
            if (code == 1)//primary
            {
                temp.Model.Annotations.Clear();

                foreach (int[] region in temp_primary)
                {
                    temp.Model.Annotations.Add(new RectangleAnnotation { MinimumX = region[0], MaximumX = region[1], Fill = OxyColor.FromAColor(99, color_primary) });
                }
                temp.InvalidatePlot(true);
            }
            if (code == 2)//internal
            {
                temp.Model.Annotations.Clear();
                foreach (int[] region in temp_internal)
                {
                    temp.Model.Annotations.Add(new RectangleAnnotation { MinimumX = region[0], MaximumX = region[1], Fill = OxyColor.FromAColor(99, color_internal) });
                }
                temp.InvalidatePlot(true);
            }
        }
        #endregion

        #region PROJECT SAVE LOAD CLEAR
        #region clear
        private void clear_proj_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Clears all data inserted from the user.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?", "Clear all data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK) Clear_all();
        }
        /// <summary>Clear all the data (loaded & calculated) </summary>
        private bool Clear_all()
        {
            block_plot_refresh = true;
            root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            CloseAllOpenForm("Form2");
            if (frm24_2 != null) { frm24_2 = null; }
            if (frm24 != null) { frm24 = null; }            
            MSproduct_treeView.Visible = false;
            is_exp_deconvoluted = false;
            labels_checked.Clear();
            if (MSproduct_treeView.Nodes.Count > 0) { MSproduct_treeView.Nodes.Clear(); }
            if (loaded_MSproducts.Count > 0) { loaded_MSproducts.Clear(); }
            tab_mode = false;
            loaded_lists = ""; show_files_Btn.ToolTipText = "";
            file_name = ""; filename_txtBx.Text = file_name;
            Peptide = String.Empty;
            heavy_chain = String.Empty; light_chain = String.Empty; light_present = false; heavy_present = false;
            if (sequenceList != null) { sequenceList.Clear(); }
            insert_exp = false;            
            Fitting_chkBox.Checked = false;
            Fragments2.Clear(); ChemFormulas.Clear();
            selectedFragments.Clear();
            machine_sel_index = 9;
            loadExp_Btn.Enabled = true;           
            bigPanel.Controls.Clear();
            candidate_fragments = 1;
            neues = 0;
            if (frag_tree != null) { frag_tree.Nodes.Clear(); frag_tree.Visible = false; }
            if (fragTypes_tree != null) { fragTypes_tree.Nodes.Clear(); fragTypes_tree.Visible = false; fragTypes_toolStrip.Visible = false; fragStorage_Lbl.Visible = false; }
            if (fit_tree != null) { fit_tree.Nodes.Clear(); fit_tree.Dispose(); fit_tree = null; }
            factor_panel.Controls.Clear();
            //other tabs
            if (IonDraw.Count > 0) IonDraw.Clear();
            if (IonDrawIndex.Count > 0) IonDrawIndex.Clear();
            if (IonDrawIndexTo.Count > 0) IonDrawIndexTo.Clear();
            color_primary_indexes = new List<int[]>();
            color_internal_indexes = new List<int[]>();
            //exclusion lists
            exclude_a_indexes.Clear();
            exclude_b_indexes.Clear();
            exclude_c_indexes.Clear();
            exclude_x_indexes.Clear();
            exclude_y_indexes.Clear();
            exclude_z_indexes.Clear();
            exclude_internal_indexes.Clear();
            list_21.Clear();
            //reset_all();
            Initialize_data_struct();
            block_plot_refresh = false;
            refresh_iso_plot(); 
            clear_sequence_panel_info();
            return true;
        }
        /// <summary>Clear the UI user selection from the sequence panel (used when user selects clear all option)   </summary>
        private void clear_sequence_panel_info()
        {
            List<Panel> seq_pnls = new List<Panel>();
            seq_pnls = GetControls(panel1_tab2).OfType<Panel>().Where<Panel>(p => p.Name.Contains("draw_sequence_panel")).ToList();
            foreach (Panel pnl in seq_pnls)
            {
                un_check_all_checkboxes(pnl,false);
                ComboBox temp_seq_box= GetControls(pnl).OfType<ComboBox>().First();
                if (temp_seq_box.Items!=null && temp_seq_box.Items.Count != 0) { temp_seq_box.Items.Clear(); }
            }
            draw_sequence_panelCopy1.Visible = false;
            draw_sequence_panelCopy2.Visible = false;
        }
        #endregion

        #region load
        private void load_proj_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Loads a project folder into Peak Finder's format.\r\nThe project consists of the preferences file, the experimental data, the fragment list and the fit results.\r\nJust select the project's folder.", "Help", MessageBoxButtons.OK,MessageBoxIcon.Information); return; }
            project_load();
        }
        /// <summary> Load project: load a project folder which contains 4 files (settings, Fragments List, Experimental profile, Experimental peaks, Fit Results(if there are any)) </summary>
        private void project_load()
        {
            all = 0;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!Clear_all()) return;
                // The user selected a folder and pressed the OK button.                
                string folderName = folderBrowserDialog1.SelectedPath;
                root_path = folderName;                
                load_preferences();//for the settings file
                string path_experimental = System.IO.Path.Combine(folderName, "Experimental Data.txt");
                string path_peaks = System.IO.Path.Combine(folderName, "Peak Data.txt");
                string path_fragments = System.IO.Path.Combine(folderName, "Fragment Data.txt");
                string path_fit = System.IO.Path.Combine(folderName, "Fit Data.txt");
                if (!File.Exists(path_peaks) || !File.Exists(path_fragments) ) { MessageBox.Show("Oops...the selected folder is not in the correct format.\r\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
                if (!File.Exists(path_experimental))
                {
                    path_experimental = System.IO.Path.Combine(folderName, "Experimental Data.dec");
                    if (File.Exists(path_experimental)) { is_exp_deconvoluted = true; }
                    else { MessageBox.Show("Oops...the selected folder is not in the correct format.\r\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
                }
                else { is_exp_deconvoluted = false; }  
                _bw_load_project_exp.RunWorkerAsync(path_experimental);
                _bw_load_project_peaks.RunWorkerAsync(path_peaks);
                _bw_load_project_fragments.RunWorkerAsync(path_fragments);
               _bw_load_project_fit_results.RunWorkerAsync(path_fit);

            }

        }
        /// <summary> Load project part 1 of 5: load Experimental profile </summary>
        void Project_load_experimental(object sender, DoWorkEventArgs e)
        {
            string filename = (string)e.Argument;
            string[] fl = filename.Split('/');
            file_name = fl[fl.Length - 1];
            file_name = file_name.Remove(file_name.Length - 4, 4);
            //sw1.Reset(); sw1.Start();
            List<string> lista = new List<string>();
            StreamReader objReader = new StreamReader(filename);
            project_experimental = filename;
            //file_name = expData.SafeFileName.Remove(expData.SafeFileName.Length - 4);           
            do { lista.Add(objReader.ReadLine()); }
            while (objReader.Peek() != -1);
            objReader.Close();
            max_exp = 0.0;
            experimental.Clear();
            for (int j = 0; j != (lista.Count); j++)
            {
                try
                {
                    string[] tmp_str = lista[j].Split('\t');
                    double mz = dParser(tmp_str[0]);
                    double y = dParser(tmp_str[1]);
                    if (tmp_str.Length == 2)
                    {
                        if (!Double.IsNaN(mz) && !Double.IsNaN(y))
                        {
                            experimental.Add(new double[] { mz, y });
                        }
                    }
                    if (max_exp < y) max_exp = y;
                }
                catch { MessageBox.Show("Error in data file " + filename + " in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }

        }
        /// <summary>Load project part 1 of 5: load Experimental peaks </summary>
        void Project_load_peaks(object sender, DoWorkEventArgs e)
        {
            string filename = (string)e.Argument;
            double mz_prev = 0;
            List<string> lista = new List<string>();
            StreamReader objReader = new StreamReader(filename);
            do { lista.Add(objReader.ReadLine()); }
            while (objReader.Peek() != -1);
            objReader.Close();
            experimental_dec.Clear();
            peak_points.Clear();
            if (is_exp_deconvoluted)
            {
                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');
                        if (tmp_str.Length == 6)
                        {
                            double mz = dParser(tmp_str[1]);
                            double y = dParser(tmp_str[2]);
                            peak_points.Add(new double[] { dParser(tmp_str[0]), mz, y, dParser(tmp_str[3]), dParser(tmp_str[4]), dParser(tmp_str[5]) });
                            if (experimental_dec.Count == 0) { experimental_dec.Add(new List<double[]>()); }
                            else if (mz - mz_prev > 2) { experimental_dec.Add(new List<double[]>()); }
                            experimental_dec.Last().Add(new double[] { mz, y });
                            mz_prev = mz;
                        }
                        else { MessageBox.Show("Wrong format in data file " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    }
                    catch { MessageBox.Show("Error in data file " + filename + " in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                }                
            }
            else
            {
                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');
                        if (tmp_str.Length == 6)
                        {
                            peak_points.Add(new double[] { dParser(tmp_str[0]), dParser(tmp_str[1]), dParser(tmp_str[2]), dParser(tmp_str[3]), dParser(tmp_str[4]), dParser(tmp_str[5]) });


                        }
                        else { MessageBox.Show("Wrong format in data file " + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    }
                    catch { MessageBox.Show("Error in data file " + filename + " in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                }
            }           
        }
        /// <summary> Load project part 1 of 5: load Fit Results </summary>
        void Project_load_fit_results(object sender, DoWorkEventArgs e)
        {
            string filename = (string)e.Argument;
            if (!File.Exists(filename)) return;//the case when the loaded project does not include the fit results
            int mode = 0;
            List<string> lista = new List<string>();
            StreamReader objReader = new StreamReader(filename);
            do { lista.Add(objReader.ReadLine()); }
            while (objReader.Peek() != -1);
            if (lista.Count == 0) return;
            objReader.Close();
            if (all_fitted_results != null) all_fitted_results.Clear();
            if (all_fitted_sets != null) all_fitted_sets.Clear();
            all_fitted_results = new List<List<double[]>>();
            all_fitted_sets = new List<List<int[]>>();
            for (int j = 0; j != (lista.Count); j++)
            {
                if (lista[j] == "") { continue; }
                else if (lista[j].StartsWith("results")) { mode = 1; continue; }
                else if (lista[j].StartsWith("sets")) { mode = 2; continue; }
                else if (lista[j].StartsWith("tab_node")) { mode = 3; continue; }
                else if (lista[j].StartsWith("tab_coef")) { mode = 4; continue; }
                else if (lista[j].StartsWith("tab_thres")) { mode = 5; continue; }
                else if (lista[j].StartsWith("labels_checked")) { mode = 6; continue; }
                try
                {
                    string[] tmp_str = lista[j].Split('\t');
                    if (mode == 1)
                    {
                        List<double[]> region = new List<double[]>();
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            string[] sol = tmp_str[s].Split(' ');
                            region.Add(new double[sol.Length - 1]);
                            for (int v = 1; v < sol.Length; v++)
                            {
                                region.Last()[v - 1] = dParser(sol[v]);
                            }
                        }
                        all_fitted_results.Add(region);
                    }
                    else if (mode == 2)
                    {
                        List<int[]> region = new List<int[]>();
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            string[] sol = tmp_str[s].Split(' ');
                            region.Add(new int[sol.Length - 1]);
                            for (int v = 1; v < sol.Length; v++)
                            {
                                region.Last()[v - 1] = Int32.Parse(sol[v]);
                            }
                        }
                        all_fitted_sets.Add(region);
                    }
                    else if (mode == 3)
                    {
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            string[] sol = tmp_str[s].Split(' ');
                            tab_node.Add(new bool[] { string_to_bool(sol[0]), string_to_bool(sol[1]), string_to_bool(sol[2]), string_to_bool(sol[3]), string_to_bool(sol[4]), string_to_bool(sol[5]) });
                        }
                    }
                    else if (mode == 4)
                    {
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            string[] sol = tmp_str[s].Split(' ');
                            tab_coef.Add(new double[] { dParser(sol[0]), dParser(sol[1]), dParser(sol[2]), dParser(sol[3]), dParser(sol[4]), dParser(sol[5]) });
                        }
                    }
                    else if (mode == 5)
                    {
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            string[] sol = tmp_str[s].Split(' ');
                            tab_thres.Add(new double[] { dParser(sol[0]), dParser(sol[1]), dParser(sol[2]), dParser(sol[3]), dParser(sol[4]), dParser(sol[5]), dParser(sol[6]) });
                        }
                    }
                    else if (mode == 6)
                    {
                        for (int s = 1; s < tmp_str.Length; s++)
                        {
                            labels_checked.Add(tmp_str[s].ToString());
                        }
                    }
                }
                catch { MessageBox.Show("Error in data file " + filename + " in line: " + j.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            }
        }
        /// <summary> Load project part 1 of 5: load Fragment List</summary>
        void Project_load_fragments(object sender, DoWorkEventArgs e)
        {
            string filename = (string)e.Argument;
            duplicate_count = 0; added = 0;
            bool mult_extensions = false; bool peptide = true;

            List<string> lista = new List<string>();
            loaded_lists = "";
            is_loading = true;  // performance            
            string s_chain = string.Empty;
            string s2_chain = string.Empty;
            System.IO.StreamReader objReader = new System.IO.StreamReader(filename);
            do { lista.Add(objReader.ReadLine()); }
            while (objReader.Peek() != -1);
            objReader.Close();
            int arrayPositionIndex = 0;
            int isotope_count = -1;
            int f = Fragments2.Count();
            for (int j = 0; j != (lista.Count); j++)
            {
                try
                {
                    string[] str = lista[j].Split('\t');
                    if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z")) continue; // comments
                    else if (lista[j].StartsWith("Mode")) continue; // to be implemented
                    else if (lista[j].StartsWith("Multiple"))
                    {
                        mult_extensions = string_to_bool(str[1]);
                    }
                    else if (lista[j].StartsWith("Extension"))
                    {
                        if (peptide)
                        {
                            peptide = false;
                            Peptide = str[3];
                            if (sequenceList == null || sequenceList.Count == 0) { sequenceList.Add(new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }); read_rtf_find_color(sequenceList.Last()); }
                            else
                            {
                                if (string.IsNullOrEmpty(str[3])) continue;
                                else { sequenceList[0] = new SequenceTab() { Extension = "", Sequence = str[3], Rtf = str[4], Type = 0 }; read_rtf_find_color(sequenceList[0]); }
                            }
                        }
                        else
                        {
                            int type = Convert.ToInt32(str[2]);
                            sequenceList.Add(new SequenceTab() { Extension = str[1], Sequence = str[3], Rtf = str[4], Type = type });
                            read_rtf_find_color(sequenceList.Last());
                            if (type==1) {heavy_present = true; }
                            else if (type==2) {light_present = true; }
                        }
                    }
                    else if (lista[j].StartsWith("Fitted")) candidate_fragments = f + Convert.ToInt32(str[1]) - 2;
                    else if (lista[j].StartsWith("Name")) continue;
                    else if (lista[j].StartsWith("Exclusion"))
                    {
                        if (str.Length > 1 && !String.IsNullOrEmpty(str[1]))
                        {
                            for (int ss = 1; ss < str.Length; ss++)
                            {
                                string[] str2 = str[ss].Split(',');
                                if (str2.Length == 4)
                                {
                                    string[] input = new string[] { str2[0], str2[1], str2[2], str2[3] };
                                    if (!list_21.Contains(input)) list_21.Add(input);
                                }
                            }
                        }
                    }
                    else if (lista[j].StartsWith("Loaded"))
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int a = 1; a < str.Length; a++)
                        {
                            sb.AppendLine(str[a]);
                        }
                        if (sb != null && sb.Length > 0) loaded_lists = sb.ToString();
                    }
                    else
                    {
                        added++;
                        // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                        isotope_count++;
                        f++;
                        bool has_adduct = false;
                        if (str.Length > 21) { has_adduct = string_to_bool(str[21]); }
                        Fragments2.Add(new FragForm
                        {
                            InputFormula = str[9],
                            Adduct = str[10],
                            Deduct = str[11],
                            Multiplier = 1,
                            Mz = str[5],
                            Ion = string.Empty,
                            Index = str[2],
                            IndexTo = str[3],
                            Error = false,
                            Machine = string.Empty,
                            Resolution = double.Parse(str[13]),
                            Profile = new List<PointPlot>(),
                            Centroid = new List<PointPlot>(),
                            FinalFormula = string.Empty,
                            Color = new OxyColor(),
                            Charge = Int32.Parse(str[4]),
                            Ion_type = str[1],
                            PPM_Error = dParser(str[8]),
                            Name = str[0],
                            Radio_label = string.Empty,
                            Factor = dParser(str[7]),
                            Fixed = string_to_bool(str[20]),
                            maxPPM_Error = 0,
                            minPPM_Error = 0,
                            Extension = str[18],
                            To_plot = string_to_bool(str[19]),
                            Max_intensity = dParser(str[6]),
                            Candidate = true,
                            Has_adduct=has_adduct
                        });
                        if (str.Length > 22) { Fragments2.Last().maxFactor = dParser(str[22]); }
                        else { Fragments2.Last().maxFactor = 0.0; }
                        if (UInt32.TryParse(str[12], out uint result_color)) Fragments2.Last().Color = OxyColor.FromUInt32(result_color);
                        IonDraw.Add(new ion() { Extension = str[18], Name = Fragments2.Last().Name, Mz = str[5], PPM_Error = dParser(str[8]), Charge = Int32.Parse(str[4]), Index = Int32.Parse(str[2]), IndexTo = Int32.Parse(str[3]), Ion_type = str[1], Max_intensity = dParser(str[6]) * dParser(str[7]), Color = Fragments2.Last().Color.ToColor(), maxPPM_Error = 0, minPPM_Error = 0, Has_adduct = has_adduct });
                        if ((Fragments2.Last().Ion_type.StartsWith("w") || Fragments2.Last().Ion_type.StartsWith("(w") || Fragments2.Last().Ion_type.StartsWith("v") || Fragments2.Last().Ion_type.StartsWith("(v")) && str[16].Equals(str[2]))
                        {
                            Fragments2.Last().SortIdx = check_false_sort_idxFragform(Fragments2.Last());
                        }
                        else { Fragments2.Last().SortIdx = Convert.ToInt32(str[16]); }                        
                        Fragments2.Last().Chain_type = Convert.ToInt32(str[17]);
                        Fragments2.Last().maxPPM_Error = dParser(str[15]);
                        Fragments2.Last().minPPM_Error = dParser(str[14]);
                        IonDraw.Last().maxPPM_Error = dParser(str[15]);
                        IonDraw.Last().minPPM_Error = dParser(str[14]);
                        IonDraw.Last().SortIdx = Fragments2.Last().SortIdx;
                        IonDraw.Last().Chain_type = Convert.ToInt32(str[17]);                        
                        arrayPositionIndex++;
                        j++;
                        str = lista[j].Split('\t');
                        if (lista[j].StartsWith("Prof"))
                        {
                            for (int s = 1; s < str.Length; s++)
                            {
                                string[] prof = str[s].Split(' ');
                                Fragments2.Last().Profile.Add(new PointPlot() { X = dParser(prof[0]), Y = dParser(prof[1]) });
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                        }
                        arrayPositionIndex++;
                        j++;
                        str = lista[j].Split('\t');
                        if (lista[j].StartsWith("Cen"))
                        {
                            for (int s = 1; s < str.Length; s++)
                            {
                                string[] cen = str[s].Split(' ');
                                Fragments2.Last().Centroid.Add(new PointPlot() { X = dParser(cen[0]), Y = dParser(cen[1]) });
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                        }
                        check_tp(Fragments2.Last());
                    }
                }
                catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); is_loading = false; return; }
                arrayPositionIndex++;
            }
            // sort by mz the fragments list (global) beause it is mixed by multi-threading
            Fragments2 = Fragments2.OrderBy(fr => Convert.ToDouble(fr.Mz)).ToList();
            // also restore indexes to match array position
            for (int k = 0; k < Fragments2.Count; k++) { Fragments2[k].Counter = (k + 1); }
            // thread safely fire event to continue calculations                       
            if (sequenceList.Count == 1) { tab_mode = false; }
            else { tab_mode = true; }
            is_loading = false; is_calc = false;
            exclude_list_make_lists();
            return;
        }
        /// <summary> Function created to fix an error to previously saved project folders, more specifically in the Fragments List file</summary>
        private int check_false_sort_idxFragform(FragForm fra)
        {
            string s = string.Empty;
            int sort_index = 0;
            bool found = false;
            foreach (SequenceTab seq in sequenceList)
            {
                if ((seq.Extension != "" && recognise_extension(fra.Extension, seq.Extension)) || (seq.Extension == "" && fra.Extension == ""))
                {
                    found = true; break;
                }
            }
            if (found) { sort_index = s.Length - Int32.Parse(fra.Index); }
            else { sort_index = 0; MessageBox.Show("Error in fragment " + fra.Name + " index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            return sort_index;
        }
        /// <summary> After Load project --> actions to fill the relevant fields, refresh plots, create treeviews etc</summary>
        private void Project_after_load()
        {
            block_plot_refresh = true;
            //exp
            insert_exp = true;
            recalc = true;
            // post load actions
            enable_UIcontrols("post load");
            filename_txtBx.Text = file_name;
            // set experimental line color to black
            if (custom_colors.Count > 0) custom_colors[0] = exp_color;
            else custom_colors.Add(exp_color);
            // copy experimental to all_data
            experimental_to_all_data();
            if (!is_exp_deconvoluted)
            {
                //displayPeakList_btn.Enabled = true;
                exp_res++;
                List<double> tmp1 = new List<double>();
                List<double> tmp2 = new List<double>();
                foreach (double[] peak in peak_points)
                {
                    if (peak[5] > 1000)
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
            else
            {
                plotCentr_chkBox.Checked = true; 
            }
            //frag            
            show_files_Btn.ToolTipText = loaded_lists;           
            loadExp_Btn.Enabled = true;
            plotFragProf_chkBox.Checked = true;            
             frags_maxFactor();
            if (Fragments2.Count > 0) { Invoke(new Action(() => OnEnvelopeCalcCompleted())); find_max_min_int(); }
            block_plot_refresh = false;
            //fit
            generate_fit_results(true);
        }
        #endregion

        # region save
        private void save_proj_Btn_Click(object sender, EventArgs e)
        {
            if (help_Btn.Checked) { MessageBox.Show("Saves the current project into Peak Finder's format.. \r\nThe project consists of the preferences file, the experimental data, the fragment list and the fit results.\r\nJust select a new or an already existing folder.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            project_save();
        }
        /// <summary> Save project: Save settings, Fragments List , Experimental profile, Experimental peaks, Fit Results(if there are any) --> as 5 files in a project folder  </summary>
        private void project_save()
        {
            save_preferences();
            if (!insert_exp) { MessageBox.Show("Sorry...No project available.\r\nThere is not any experimental file loaded.\r\nYou can save Fragment List in a .fit file instead.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            else if (Fragments2.Count == 0) { MessageBox.Show("Sorry...No project available.\r\nThere is not any Fragment List loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!Directory.Exists(folderBrowserDialog1.SelectedPath)) { MessageBox.Show("Oops...No folder selected.\r\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
                progress_display_start(7, "Saving project...");
                all = 0;
                // The user selected a folder and pressed the OK button.                
                string folderName = folderBrowserDialog1.SelectedPath;
                string path_experimental = System.IO.Path.Combine(folderName, "Experimental Data.txt");
                if (is_exp_deconvoluted)
                {
                    if (File.Exists(path_experimental)) { File.Delete(path_experimental); }
                    path_experimental = System.IO.Path.Combine(folderName, "Experimental Data.dec");
                }
                string path_peaks = System.IO.Path.Combine(folderName, "Peak Data.txt");
                string path_fragments = System.IO.Path.Combine(folderName, "Fragment Data.txt");
                string path_fit = System.IO.Path.Combine(folderName, "Fit Data.txt");
                string path_pref = System.IO.Path.Combine(folderName, "preferences.txt");
                if (!is_exp_deconvoluted && !project_experimental.Equals(path_experimental)) System.IO.File.Copy(project_experimental, path_experimental, true);
                if (is_exp_deconvoluted) { Project_save_experimental(path_experimental); }
                if (!path_pref.Equals(root_path + "\\preferences.txt")) System.IO.File.Copy(root_path + "\\preferences.txt", path_pref, true);
                _bw_save_project_peaks.RunWorkerAsync(path_peaks);
                _bw_save_project_frag.RunWorkerAsync(path_fragments);
                _bw_save_project_fit_results.RunWorkerAsync(path_fit);                             
            }
        }
        void Project_save_fit_results(object sender, DoWorkEventArgs e)
        {
            string path = e.Argument.ToString();
            if (all_fitted_results.Count == 0) return;
            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                writer.WriteLine("results");
                foreach (List<double[]> region in all_fitted_results)
                {
                    string line = "";
                    for (int solution = 0; solution < region.Count(); solution++)
                    {
                        line += "\t";
                        int length = region[solution].Length;
                        for (int kk = 0; kk < length; kk++)
                        {
                            line += " " + region[solution][kk].ToString();
                        }
                    }
                    writer.WriteLine(line);
                }
                writer.WriteLine();
                writer.WriteLine("sets");
                foreach (List<int[]> region in all_fitted_sets)
                {
                    string line = "";
                    for (int solution = 0; solution < region.Count(); solution++)
                    {
                        line += "\t";
                        int length = region[solution].Length;
                        for (int kk = 0; kk < length; kk++)
                        {
                            line += " " + region[solution][kk];
                        }
                    }
                    writer.WriteLine(line);
                }
                writer.WriteLine();
                writer.WriteLine("tab_node");
                string line_write = "";
                for (int n = 0; n < tab_node.Count; n++)
                {
                    line_write += "\t";
                    line_write += tab_node[n][0].ToString() + " " + tab_node[n][1].ToString() + " " + tab_node[n][2].ToString() + " " + tab_node[n][3].ToString() + " " + tab_node[n][4].ToString() + " " + tab_node[n][5].ToString();
                }
                writer.WriteLine(line_write);
                writer.WriteLine();
                writer.WriteLine("tab_coef");
                line_write = "";
                for (int n = 0; n < tab_coef.Count; n++)
                {
                    line_write += "\t";
                    line_write += tab_coef[n][0].ToString() + " " + tab_coef[n][1].ToString() + " " + tab_coef[n][2].ToString() + " " + tab_coef[n][3].ToString() + " " + tab_coef[n][4].ToString() + " " + tab_coef[n][5].ToString();
                }
                writer.WriteLine(line_write);
                writer.WriteLine();
                writer.WriteLine("tab_thres");
                line_write = "";
                for (int n = 0; n < tab_thres.Count; n++)
                {
                    line_write += "\t";
                    line_write += tab_thres[n][0].ToString() + " " + tab_thres[n][1].ToString() + " " + tab_thres[n][2].ToString() + " " + tab_thres[n][3].ToString() + " " + tab_thres[n][4].ToString() + " " + tab_thres[n][5].ToString() + " " + tab_thres[n][6].ToString();
                }
                writer.WriteLine(line_write);
                writer.WriteLine();
                writer.WriteLine("labels_checked");
                line_write = "";
                for (int n = 0; n < labels_checked.Count; n++)
                {
                    line_write += "\t";
                    line_write += labels_checked[n];
                }
                writer.WriteLine(line_write);
            }
        }
        /// <summary>  Save project part 1 of 5: Save the experimental peaks </summary>
        void Project_save_peaks(object sender, DoWorkEventArgs e)
        {
            string path = e.Argument.ToString();
            if (peak_points.Count == 0 ) { return; }
            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                foreach (double[] peak in peak_points)
                {
                    writer.WriteLine(peak[0] + "\t" + Math.Round(peak[1],6) + "\t" + Math.Round(peak[2],6) + "\t" + Math.Round(peak[3],2) + "\t" + peak[4] + "\t" + peak[5]);
                }
            }
        }
        /// <summary>   Save project part 1 of 5: Save the experimental profile </summary>
        public void Project_save_experimental(string path)
        {
            if (!is_exp_deconvoluted) { return; }

            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                foreach (double[] exp in experimental)
                {
                    writer.WriteLine(Math.Round(exp[0],6) + "\t" + Math.Round(exp[1],6));
                }
            }
        }
        /// <summary> Save project part 1 of 5: Save all the fragments in the Fragments List (Fragments2) </summary>
        void Project_save_fragments(object sender, DoWorkEventArgs e)
        {
            string path = e.Argument.ToString();
            string exclusion = "";
            foreach (string[] kk in list_21)
            {
                exclusion += "\t" + kk[0] + "," + kk[1] + "," + kk[2] + "," + kk[3];
            }
            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                foreach (SequenceTab seq in sequenceList)
                {
                    writer.WriteLine("Extension:\t" + seq.Extension + "\t" + seq.Type.ToString() + "\t" + seq.Sequence + "\t" + seq.Rtf);
                }
                writer.WriteLine();
                writer.WriteLine("Exclusion List:" + exclusion);
                writer.WriteLine();
                writer.WriteLine("Loaded Fitted Files:\t" + loaded_lists.Replace("\r\n", "\t"));
                writer.WriteLine("Name\tIon Type\tIndex\t->to Index\tCharge\tm/z\tMax Intensity\tFactor\tPPM Error\tInput Formula\tAdduct\tDeduct\tColor\tResolution\tminPPMerror\tmaxPPMerror\tsortIndex\tchainType\textension\tToPlot\tFitted\tHasAdduct\tmaxFactor");
                for (int indexS = 1; indexS <= Fragments2.Count; indexS++)
                {
                    string profile_string = "Prof:";
                    string centroid_string = "Centr:";
                    foreach (PointPlot pp in Fragments2[indexS - 1].Profile)
                    {
                        profile_string += "\t" + Math.Round(pp.X,6) + " " + Math.Round(pp.Y,6);
                    }
                    foreach (PointPlot pp in Fragments2[indexS - 1].Centroid)
                    {
                        centroid_string += "\t" + Math.Round(pp.X ,6)+ " " + Math.Round(pp.Y,6);
                    }
                    writer.WriteLine(Form2.Fragments2[indexS - 1].Name + "\t" + Form2.Fragments2[indexS - 1].Ion_type + "\t" + Form2.Fragments2[indexS - 1].Index + "\t" + Form2.Fragments2[indexS - 1].IndexTo + "\t" + Form2.Fragments2[indexS - 1].Charge + "\t" + Form2.Fragments2[indexS - 1].Mz + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Max_intensity,6).ToString() + "\t" + Form2.Fragments2[indexS - 1].Factor.ToString() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].PPM_Error,4).ToString() + "\t" + Form2.Fragments2[indexS - 1].InputFormula + "\t" + Form2.Fragments2[indexS - 1].Adduct + "\t" + Form2.Fragments2[indexS - 1].Deduct + "\t" + Form2.Fragments2[indexS - 1].Color.ToUint() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].Resolution,2).ToString() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].minPPM_Error,4).ToString() + "\t" + Math.Round(Form2.Fragments2[indexS - 1].maxPPM_Error,4).ToString() + "\t" + Form2.Fragments2[indexS - 1].SortIdx.ToString() + "\t" + Form2.Fragments2[indexS - 1].Chain_type + "\t" + Form2.Fragments2[indexS - 1].Extension + "\t" + Form2.Fragments2[indexS - 1].To_plot.ToString()+ "\t" + Form2.Fragments2[indexS - 1].Fixed.ToString()+ "\t" + Form2.Fragments2[indexS - 1].Has_adduct.ToString() + "\t" + Form2.Fragments2[indexS - 1].maxFactor.ToString());
                    writer.WriteLine(profile_string);
                    writer.WriteLine(centroid_string);
                }
            }
        }
        #endregion
        #endregion

        #region fixed list 
        //Fixed List refers to a .fit of fragments that the user is sure that are present in the experimental spectra. So when conducting a case study:
        //(1)the user loads the .fit file from the "fixed_listBtn_Click", and this list is saved in Fragments5 list (only the fragments'names in order to save up space).
        //This list is not present to the user
        //(2)Then the user follows the usual steps to see how well the program works(load experimental file, load fragment file, conduct isotopic distribution calculation and fitting process and so on)
        //(3)Then the user can click the button "fixed_statistics_Btn_Click" and the algorithm detects how many fragments from the Fragments5 list have equal name with the checked fragments in Fragments2 list. And displays this number.
        /// <summary> loads the .fit file with the correct fragments, and this list is saved in Fragments5 list (only the fragments'names in order to save up space).This list is not present to the user </summary>
        private void fixed_listBtn_Click(object sender, EventArgs e)
        {
            duplicate_count = 0; added = 0;
            string extension = "";
            OpenFileDialog loadData = new OpenFileDialog() { Multiselect = false, Title = "Load fitting data", FileName = "", Filter = "data file|*.hlfit;*.lfit;*.hfit;*.fit;*.hlpfit;*.lpfit;*.hpfit;*.pfit*.hlifit;*.lifit;*.hifit;*.ifit;|All files|*.*" };
            string fullPath = "";
            bool envipat = false;
            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                //Fragments5.Clear();
                string FileName = loadData.FileName;
                List<string> lista = new List<string>();
                envipat = false; extension = "";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(loaded_lists);
                sb.AppendLine(System.IO.Path.GetFileNameWithoutExtension(FileName));
                extension = System.IO.Path.GetExtension(FileName);
                if (extension.Equals(".pfit") || extension.Equals(".ifit") || extension.Equals(".hpfit") || extension.Equals(".hlpfit") || extension.Equals(".hlifit") || extension.Equals(".hifit") || extension.Equals(".lpfit") || extension.Equals(".lifit")) { envipat = true; }
                fullPath = FileName;
                string s_chain = string.Empty;
                string s2_chain = string.Empty;
                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);
                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();
                int arrayPositionIndex = 0;
                int isotope_count = -1;
                int f = Fragments5.Count();
                if (envipat)
                {
                    progress_display_start(lista.Count, "Receiving fragment isotopic distributions...");
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] str = lista[j].Split('\t');
                            if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z")|| lista[j].StartsWith("Mode") || lista[j].StartsWith("Multiple") || lista[j].StartsWith("Extension") || lista[j].StartsWith("AA") || lista[j].StartsWith("Fitted") || lista[j].StartsWith("Exclusion") || lista[j].StartsWith("Name")) continue; // comments
                            else
                            {
                                // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                                isotope_count++;
                                f++;
                                string letter = "";
                                string type = "";
                                if (!str[1].Contains("H2O") && !str[1].Contains("NH3") && !str[1].Contains("CO") && (str[1].Contains("+") || str[1].Contains("-")))
                                {
                                    if (str[0].StartsWith("(a")) letter = "a";
                                    else if (str[0].StartsWith("(b")) letter = "b";
                                    else if (str[0].StartsWith("(c")) letter = "c";
                                    else if (str[0].StartsWith("(x")) letter = "x";
                                    else if (str[0].StartsWith("(y")) letter = "y";
                                    else if (str[0].StartsWith("(z")) letter = "z";
                                }

                                if (letter != "" && (str[1].Contains(letter + "-1") || str[1].Contains(letter + "-2") || str[1].Contains(letter + "+1") || str[1].Contains(letter + "+2")))
                                {
                                    type = letter + str[0].Remove(0, 5);
                                }
                                if (type == "") { type = str[0]; }
                                Fragments5.Add(new FragForm{Name = type});
                                arrayPositionIndex++;
                                j++;
                                str = lista[j].Split('\t');
                                if (!lista[j].StartsWith("Prof"))
                                {
                                    MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                }
                                arrayPositionIndex++;
                                j++;
                                str = lista[j].Split('\t');
                                if (!lista[j].StartsWith("Cen")) 
                                {
                                    MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                                }
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j] + "\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); is_loading = false; progress_display_stop(); return; }
                        arrayPositionIndex++;
                        if (j % 10 == 0 && j > 0) { progress_display_update(j); }
                    }
                    progress_display_stop();
                }
                else
                {
                    for (int j = 0; j != (lista.Count); j++)
                    {
                        try
                        {
                            string[] str = lista[j].Split('\t');
                            if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("[m/z") || lista[j].StartsWith("Mode") || lista[j].StartsWith("Multiple") || lista[j].StartsWith("Extension") || lista[j].StartsWith("AA") || lista[j].StartsWith("Fitted") || lista[j].StartsWith("Exclusion") || lista[j].StartsWith("Name")) continue; // comments
                            else
                            {
                                added++;
                                // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                                isotope_count++;
                                f++;
                                string letter = "";
                                string type = "";
                                if (!str[1].Contains("H2O") && !str[1].Contains("NH3") && !str[1].Contains("CO") && (str[1].Contains("+") || str[1].Contains("-")))
                                {
                                    if (str[0].StartsWith("(a")) letter = "a";
                                    else if (str[0].StartsWith("(b")) letter = "b";
                                    else if (str[0].StartsWith("(c")) letter = "c";
                                    else if (str[0].StartsWith("(x")) letter = "x";
                                    else if (str[0].StartsWith("(y")) letter = "y";
                                    else if (str[0].StartsWith("(z")) letter = "z";
                                }

                                if (letter != "" && (str[1].Contains(letter + "-1") || str[1].Contains(letter + "-2") || str[1].Contains(letter + "+1") || str[1].Contains(letter + "+2")))
                                {
                                    type = letter + str[0].Remove(0, 5);
                                }
                                if (type == "") { type = str[0]; }
                                Fragments5.Add(new FragForm{Name = type});
                            }
                        }
                        catch (Exception ex) { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j] + "\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); is_loading = false; return; }
                        arrayPositionIndex++;
                    }
                }
            }
            else { return; }
        }
        /// <summary> Check if the fragment's name is present in Fragment5 list.If yes this means that the fragment is true positive. (Fragments5 list contains fragments that the user has found in a previous spectrum analysis and is sure of their presence)  </summary>
        private void check_tp(FragForm fra)
        {
            if (Fragments5.Count == 0) return;
           
            foreach (FragForm basic_fra in Fragments5)
            {
                if (fra.Name.Equals(basic_fra.Name)) { fra.True_positive = true; return; }               
            }
            fra.True_positive = false;
        }
        /// <summary>Detects how many fragments from the Fragments5 list have equal name with the checked fragments in Fragments2 list. And displays this number. </summary>
        private void fixed_statistics_Btn_Click(object sender, EventArgs e)
        {
            if (Fragments5.Count == 0) return;
            int counter = 0;
            foreach (FragForm fra in Fragments2)
            {
                if (fra.True_positive && fra.To_plot) { counter++; }
            }
            MessageBox.Show("Found "+ counter.ToString() + " out of "+ Fragments5.Count.ToString());
        }

        #endregion

        #region Ultimate Fragment Calculator Manipulation
        /// <summary> Write the user defined parameters for the Ultimate Fragmentor algorithm in a json file. </summary>
        /// <param name="path">The "path" in which the output json file will be created or overwritten </param>
        private void write_params_input_json(string path="")
        {
            if (path == "")
            {
                root_path = AppDomain.CurrentDomain.BaseDirectory.ToString();
                path = root_path + "\\input.json";
            }           
            if (_data == null) return;
            //open file stream
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, _data);
            }
        }
        /// <summary>Read Utimate Fragmentor File (csv) and load the fragments.</summary>
        /// <param name="is_calculation">If is false then the loaded fragments are inserted in Chemformulas List and the isotopic distributions of the fragments are not calculated.If true then the loaded fragments are inserted in Fragments2 List and the isotopic distributions of the fragments are calculated as if the user had inserted a .fit file. </param>
        /// <param name="file">The path to the csv file </param> 
        public void read_csv_and_Calculate(string file,bool is_calculation=false)
        {            
            //csv example 
            //[0]ion type,[1]name,[2]charge,[3]sequence,[4]mass,[5]modification,[6]formula,[7]bond digested,[8]seq_start,[9]seq_end
            //[0]y,[1]y9,[2]1,[3]QIFVKTLYT,[4]1112.6350229193602,[5],[6]C54H85N11O14,[7]1,[8]2,[9]10
            if (file.EndsWith(".csv"))
            {
                is_ult_fragmentor_file = true;
                List<ChemiForm> selected_fragments = new List<ChemiForm>();
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var line_csv = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line_csv) && !line_csv.StartsWith("ion type"))
                        {
                            var values_csv = line_csv.Split(',');
                            try
                            {
                                if (values_csv.Length < 4) { MessageBox.Show("Oops... it seems you have inserted wrong file format.\r\nPlease try again.", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                                assign_Ultimate_Fragmentor_fragment(values_csv, selected_fragments);
                            }
                            catch (Exception eeeee) { MessageBox.Show(eeeee.ToString() + "\r\n Error in data file in line: " + line_csv.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                        }

                    }
                }
                if (is_calculation)
                {
                    try
                    {
                        try
                        {
                            clearList();
                            if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0) if (ExtraFragCalculator.now && ExtraFragCalculator.last_plotted.Count > 0) { ExtraFragCalculator.last_plotted.Clear(); }
                        }
                        catch
                        {
                            MessageBox.Show("Oops an unexpected error occurred!Please close the program and restart the procedure.", "Error in clear list!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally
                        {
                            fragments_and_calculations_sequence_A(selected_fragments);
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Oops an unexpected error occurred!Please close the program and restart the procedure.", "Error in calculations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else { ChemFormulas.AddRange(selected_fragments); }
            }
        }
        /// <summary>Assign the info in each line of the csv file to a ChemiForm fragment</summary>
        /// <param name="Utimate_Frag_List">The list in which the ChemiForm fragment will be inserted </param>
        /// <param name="frag_info">Information in a line in the Utimate Fragmentor output csv file </param>       
        private void assign_Ultimate_Fragmentor_fragment(string[] frag_info,List<ChemiForm> Utimate_Frag_List)
        {
            //[0]ion type,[1]name,[2]charge,[3]sequence,[4]mass,[5]modification,[6]formula,[7]bond digested,[8]seq_start,[9]seq_end
            int charge = Int32.Parse(frag_info[2]);
            if (is_exp_deconvoluted && charge > 1) { return; }
            bool is_error = false;
            Utimate_Frag_List.Add(new ChemiForm
            {
                InputFormula = frag_info[6],
                Adduct = string.Empty,
                Deduct = string.Empty,
                Multiplier = 1,
                Mz = frag_info[4],
                Ion = frag_info[0],
                Index = frag_info[7],
                IndexTo = frag_info[7],
                Error = false,
                Elements_set = new List<Element_set>(),
                Iso_total_amount = 0,
                Monoisotopic = new CompoundMulti() { Sum = new int[1], Counter = new int[1] },
                Points = new List<PointPlot>(),
                Machine = string.Empty,
                Resolution = 100000,
                Combinations = new List<Combination_1>(),
                Profile = new List<PointPlot>(),
                Centroid = new List<PointPlot>(),
                Intensoid = new List<PointPlot>(),
                Combinations4 = new List<Combination_4>(),
                FinalFormula = string.Empty,
                Factor = 1.0,
                Fixed = false,
                PrintFormula = frag_info[6],
                Max_man_int = 0,
                Extension = ms_extension,
                Has_adduct = false,
                maxFactor = 0.0,
                Modif_formula="",
                Modif_name = frag_info[5]
            });
            int i = Utimate_Frag_List.Count - 1;
            if (!string.IsNullOrEmpty(frag_info[5])) { Utimate_Frag_List[i].Has_adduct = true; }
            if (!frag_info[9].EndsWith(frag_info[7]))
            {
                //in case of w,x,y,z
                string index = frag_info[1].Replace(frag_info[0], "");
                Utimate_Frag_List[i].Index = index;
                Utimate_Frag_List[i].IndexTo = index;
            }
            if (ms_heavy_chain) Utimate_Frag_List[i].Chain_type = 1;
            else if (ms_light_chain) Utimate_Frag_List[i].Chain_type = 2;
            else Utimate_Frag_List[i].Chain_type = 0;
            Utimate_Frag_List[i].SortIdx = Int32.Parse(frag_info[7]);
            //remove the extra Hydrogen from the chemical Formula
            Utimate_Frag_List[i].PrintFormula = Utimate_Frag_List[i].InputFormula = fix_formula(out is_error, Utimate_Frag_List[i].InputFormula);
            if (is_exp_deconvoluted && dec_charge == 0)
            {
                //in case of a deconvoluted spectra 
                Utimate_Frag_List[i].Charge = 0;
                // all ions have as many H in Adduct as their charge
                Utimate_Frag_List[i].Adduct = "";
            }
            else
            {
                Utimate_Frag_List[i].Charge = Int32.Parse(frag_info[2]);
                //all ions have as many H in Adduct as their charge
                Utimate_Frag_List[i].Adduct = "H" + Utimate_Frag_List[i].Charge.ToString();
            }
            // normal fragment
            Utimate_Frag_List[i].Ion_type = Utimate_Frag_List[i].Ion;
            if (Utimate_Frag_List[i].Ion.StartsWith("d")) Utimate_Frag_List[i].Color = OxyColors.Turquoise;
            if (Utimate_Frag_List[i].Ion.StartsWith("v")) Utimate_Frag_List[i].Color = OxyColors.Turquoise;
            if (Utimate_Frag_List[i].Ion.StartsWith("w")) Utimate_Frag_List[i].Color = OxyColors.Turquoise;
            else if (Utimate_Frag_List[i].Ion.StartsWith("a")) Utimate_Frag_List[i].Color = OxyColors.Green;
            else if (Utimate_Frag_List[i].Ion.StartsWith("b")) Utimate_Frag_List[i].Color = OxyColors.Blue;
            else if (Utimate_Frag_List[i].Ion.StartsWith("c")) Utimate_Frag_List[i].Color = OxyColors.Firebrick;
            else if (Utimate_Frag_List[i].Ion.StartsWith("x")) { Utimate_Frag_List[i].Color = OxyColors.LimeGreen; }
            else if (Utimate_Frag_List[i].Ion.StartsWith("y")) { Utimate_Frag_List[i].Color = OxyColors.DodgerBlue; }
            else if (Utimate_Frag_List[i].Ion.StartsWith("z")) { Utimate_Frag_List[i].Color = OxyColors.Tomato; }
            else Utimate_Frag_List[i].Color = OxyColors.Orange;
            string lbl = "";
            if (Utimate_Frag_List[i].Ion_type.Length == 1) { lbl = frag_info[1]; }
            else { lbl = "(" + Utimate_Frag_List[i].Ion_type + ")" + Utimate_Frag_List[i].Index; }
            if (Utimate_Frag_List[i].Charge > 0) Utimate_Frag_List[i].Name = lbl + "_" + Utimate_Frag_List[i].Charge.ToString() + "+" + ms_extension;
            else if (Utimate_Frag_List[i].Charge < 0) Utimate_Frag_List[i].Name = lbl + "_" + Math.Abs(Utimate_Frag_List[i].Charge).ToString() + "-" + ms_extension;
            else Utimate_Frag_List[i].Name = lbl + "_" + Utimate_Frag_List[i].Charge.ToString() + ms_extension;          
        }
        /// <summary>Assign the info in each line of the csv file to a ChemiForm fragment </summary>       
        private void loadUltimateFragmentorFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadData = new OpenFileDialog() { Multiselect = false, Title = "Load Ultimate Fragmentor data", FileName = "", Filter = "data file|*.csv;|All files|*.*" };

            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                selectedFragments.Clear();
                string FileName = loadData.FileName;
                read_csv_and_Calculate(FileName, true);
            }
            else { return; }
        }

        //public void PatchParameter(string parameter, int serviceid)
        //{
        //    // 1) Create engine
        //    ScriptEngine engine = Python.CreateEngine();
        //    var paths = engine.GetSearchPaths();
        //    paths.Add(@"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\");
        //    paths.Add(@"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\.idea");
        //    paths.Add(@"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\fragment_lib");
        //    paths.Add(@"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\params");

        //    engine.SetSearchPaths(paths);
        //    // 2) Provide script and arguments
        //    var script = @"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\ultimate_fragmentor.py";
        //    ScriptSource source = engine.CreateScriptSourceFromFile(script);

        //    var argv = new List<string>();
        //    argv.Add("");
        //    //argv.Add("input.json");
        //    argv.Add(@"C:\\Users\\Maro\\Utlimate_Fragment\\Utlimate_Fragment\\input.json");

        //    engine.GetSysModule().SetVariable("argv", argv);

        //    // 3) Output redirect
        //    var eIO = engine.Runtime.IO;

        //    var errors = new MemoryStream();
        //    eIO.SetErrorOutput(errors, Encoding.Default);

        //    var results = new MemoryStream();
        //    eIO.SetOutput(results, Encoding.Default);

        //    // 4) Execute script
        //    //engine.ExecuteFile(script);
        //    //var scope = engine.CreateScope();
        //    //source.Execute(scope);
        //    source.Execute();

        //    //// 5) Display output
        //    //string str(byte[] x) => Encoding.Default.GetString(x);

        //    //Console.WriteLine("ERRORS:");
        //    //Console.WriteLine(str(errors.ToArray()));
        //    //Console.WriteLine();
        //    //Console.WriteLine("Results:");
        //    //Console.WriteLine(str(results.ToArray()));
        //}
        //private void run_cmd(string cmd, string args)
        //{
        //    ProcessStartInfo start = new ProcessStartInfo();
        //    start.FileName = "my/full/path/to/python.exe";
        //    start.Arguments = string.Format("{0} {1}", cmd, args);
        //    start.UseShellExecute = false;
        //    start.RedirectStandardOutput = true;
        //    using (Process process = Process.Start(start))
        //    {
        //        using (StreamReader reader = process.StandardOutput)
        //        {
        //            string result = reader.ReadToEnd();
        //            Console.Write(result);
        //        }
        //    }
        //}
        //public void rin_python()
        //{
        //    string progToRun = "C:\\Users\\Maro\\Utlimate_Fragment\\setup.py";
        //    Process proc = new Process();
        //    proc.StartInfo.FileName = "C:\\Users\\Maro\\anaconda3\\python.exe";
        //    proc.StartInfo.RedirectStandardOutput = true;
        //    proc.StartInfo.UseShellExecute = false;
        //    proc.StartInfo.WorkingDirectory = "C:\\Users\\Maro\\Utlimate_Fragment";
        //    proc.StartInfo.Arguments = progToRun;

        //    proc.Start();

        //    //StreamReader sReader = proc.StandardOutput;
        //    //string[] output = sReader.ReadToEnd().Split('\r');

        //    //foreach (string s in output)
        //    //    Console.WriteLine(s);

        //    proc.WaitForExit();
        //}

        #endregion

    }
}
