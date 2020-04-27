using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.WindowsForms;


using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Input;



namespace Isotope_fitting
{
    public partial class Form1 : Form
    {
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

        List<List<double[]>> all_data = new List<List<double[]>>();
        //List<double[]> fragments_factors = new List<double[]>();
        int candidate_fragments = 10;
        double keyStep = 0.5;

        List<double[]> experimental = new List<double[]>();
        List<double[]> all_data_aligned = new List<double[]>();


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

        Stopwatch s1 = new Stopwatch();
        Stopwatch s2 = new Stopwatch();
        Stopwatch s3 = new Stopwatch();
        Stopwatch s4 = new Stopwatch();
        Stopwatch s5 = new Stopwatch();
        public Form1()
        {
            #region Code to embed DLLs
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            #endregion

            InitializeComponent();

            reset_all();
        }

        #region init, plot
        
        private void Initialize_option_control()
        {
            //ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //SuspendLayout();
            ////initialize new options groupbox
            //var existing_options_grpBox = GetControls(this).OfType<GroupBox>().FirstOrDefault(n => n.Name == "Options_grpBox");
            //if (existing_options_grpBox != null) existing_options_grpBox.Dispose();

            //GroupBox options_grpBox = new GroupBox() { Name = "Options_grpBox", Text = "Options", Location = new Point(1250, 30), Size = new Size(500, 700), Anchor = AnchorStyles.Left | AnchorStyles.Top };
            //Label pepLabel = new Label() { AutoSize = true,Location = new Point(16, 13),Name = "peplabel", Size = new Size(95, 13),TabIndex = 0,Text = "Peptide Sequence"};
            //TextBox pepBox = new TextBox() { Name = "pepTextBox", Location = new Point(118, 13), Size = new Size(279, 20), TabIndex = 1};
            //Button loadSpecBtn = new Button { Text = "Load Spec" , Location = new Point(485, 13), Size = new Size(74, 20), Name = "loadSpecBtn", TabIndex = 2 };
            //Button loadMSBtn = new Button { Text = "Load MS", Location = new Point(404, 13), Size = new Size(74, 20), TabIndex = 3, Name = "loadMSBtn" };

            //GroupBox boundariesBox = new GroupBox() { Name = "boundariesBox" , Text = "Boundaries" , Location = new Point(16, 53), TabIndex = 4 };
            //boundariesBox.SuspendLayout();
            //CheckBox windowCheck = new CheckBox() { AutoSize = true , Location = new Point(10, 33) , Name = "windowCheck" , Size = new Size(65, 17) , TabIndex = 0 , Text = "Window" };
            //CheckBox spectrumCheck = new CheckBox() { AutoSize = true, Location = new Point(10, 77), Name = "spectrumCheck", Size = new Size(71, 17), TabIndex = 1, Text = "Spectrum" };
            //Label mzminLabel = new Label() { AutoSize = true, Location = new Point(100, 16), Name = "mzminLabel", Size = new Size(44, 13), TabIndex = 2, Text = "m/z min" };
            //Label mzmaxLabel = new Label() { AutoSize = true, Location = new Point(223, 16), Name = "mzmaxLabel", Size = new Size(47, 13), TabIndex = 3, Text = "m/z max" };
            //TextBox windowMinBox = new TextBox() { Name = "windowMinBox", Location = new Point(100, 33), Size = new Size(100, 20), TabIndex = 4 };
            //TextBox windowMaxBox = new TextBox() { Name = "windowMaxBox", Location = new Point(223, 33), Size = new Size(100, 20), TabIndex = 5 };
            //TextBox spectrumMinBox = new TextBox() { Name = "spectrumMinBox", Location = new Point(100, 77), Size = new Size(100, 20), TabIndex = 6};
            //TextBox spectrumMaxBox = new TextBox() { Name = "spectrumMaxBox", Location = new Point(223, 77), Size = new Size(100, 20), TabIndex = 7 };
            //TextBox stepBox = new TextBox() { Name = "stepBox", Location = new Point(346, 77), Size = new Size(100, 20), TabIndex = 8 };
            //Label stepLabel = new Label() { AutoSize = true, Location = new Point(346, 58), Name = "stepLabel", Size = new Size(29, 13), TabIndex = 9, Text = "Step" };
            //boundariesBox.Controls.AddRange(new Control[] { windowCheck , spectrumCheck , mzminLabel , mzmaxLabel,windowMinBox,windowMaxBox,spectrumMinBox, windowMaxBox,spectrumMinBox,spectrumMaxBox,stepBox,stepLabel});

            //GroupBox fragmentsBox = new GroupBox() { Location = new Point(16, 183), Name = "fragmentsBox" , Size = new Size(375, 230) , TabIndex = 5,  Text = "Fragments" };
            //fragmentsBox.SuspendLayout();
            //CheckedListBox checkedListFragments = new CheckedListBox() { FormattingEnabled = true, Location = new Point(10, 20), Name = "checkedListFragments", Size = new Size(359, 199) , TabIndex = 0 };
            //fragmentsBox.Controls.AddRange(new Control[] { checkedListFragments });
                      

            //GroupBox chargestateBox = new GroupBox() { Location = new Point(404, 183), Name = "chargestateBox", Size = new Size(155, 230), TabIndex = 6, Text = "Charge state" };
            //chargestateBox.SuspendLayout();
            //ListBox charge_lstBox = new ListBox() { FormattingEnabled = true, Location = new System.Drawing.Point(10, 20) , Name = "charge_lstBox" , Size = new System.Drawing.Size(120, 160) , TabIndex = 5 };
            //Button all_chargeBtn = new Button { Location = new System.Drawing.Point(10, 193), Name = "all_chargeBtn", Size = new System.Drawing.Size(95, 20), TabIndex = 4, Text = "All" };
            //Button charge_clearBtn = new Button { BackColor = System.Drawing.SystemColors.ButtonHighlight, ForeColor = System.Drawing.SystemColors.ControlText, Image = ((System.Drawing.Image)(resources.GetObject("charge_clearBtn.Image")), Location = new System.Drawing.Point(111, 193), Name = "charge_clearBtn", Size = new System.Drawing.Size(19, 20), TabIndex = 11};
            //chargestateBox.Controls.AddRange(new Control[] { charge_lstBox, all_chargeBtn, charge_clearBtn });

            //GroupBox indexBox = new GroupBox() { Location = new System.Drawing.Point(16, 437), Name = "indexBox" , Size = new System.Drawing.Size(543, 147) , TabIndex = 8 , Text = "Indeces" };
            //indexBox.SuspendLayout();
            //Button removeIndexBtn = new Button() { BackColor = System.Drawing.SystemColors.ButtonHighlight , Image = ((System.Drawing.Image)(resources.GetObject("removeIndexBtn.Image"))) , Location = new System.Drawing.Point(502, 13) , Name = "removeIndexBtn" , Size = new System.Drawing.Size(19, 20), TabIndex = 15, UseVisualStyleBackColor = false };
            //ListBox selected_IndexLstBox = new ListBox() { AccessibleDescription = "", FormattingEnabled = true , Location = new System.Drawing.Point(405, 36) , Name = "selected_IndexLstBox" , ScrollAlwaysVisible = true , SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended , Size = new System.Drawing.Size(116, 95) , TabIndex = 14 };
            //Button pr_index_addBtn = new Button() { BackColor = System.Drawing.SystemColors.ButtonHighlight, Image = ((System.Drawing.Image)(resources.GetObject("pr_index_addBtn.Image"))), Location = new System.Drawing.Point(122, 40) , Name = "pr_index_addBtn" , Size = new System.Drawing.Size(19, 20) , TabIndex = 13, UseVisualStyleBackColor = false };
            //Label selected_IndexLbl = new Label() { AutoSize = true, Location = new System.Drawing.Point(405, 13), Name = "selected_IndexLbl", Size = new System.Drawing.Size(87, 13) , TabIndex = 12 , Text = "Selected Internal" };
            //Button pr_index_clearBtn = new Button { BackColor = System.Drawing.SystemColors.ButtonHighlight , ForeColor = System.Drawing.SystemColors.ControlText , Image = ((System.Drawing.Image)(resources.GetObject("pr_index_clearBtn.Image"))) , Location = new System.Drawing.Point(99, 40) , Name = "pr_index_clearBtn" , Size = new System.Drawing.Size(19, 20) , TabIndex = 10 , UseVisualStyleBackColor = false };
            //Button intern_index_addBtn = new Button { BackColor = System.Drawing.SystemColors.ButtonHighlight , Image = ((System.Drawing.Image)(resources.GetObject("intern_index_addBtn.Image"))) , Location = new System.Drawing.Point(292, 90) , Name = "intern_index_addBtn" , Size = new System.Drawing.Size(19, 20) , TabIndex = 8 , UseVisualStyleBackColor = false };
            //Button intern_index_clearBtn = new Button { BackColor = System.Drawing.SystemColors.ButtonHighlight , ForeColor = System.Drawing.SystemColors.ControlText , Image = ((System.Drawing.Image)(resources.GetObject("intern_index_clearBtn.Image"))) , Location = new System.Drawing.Point(265, 90) , Name = "intern_index_clearBtn" , Size = new System.Drawing.Size(19, 20) , TabIndex = 7 , UseVisualStyleBackColor = false };
            //TextBox to_IndexBox = new TextBox { Location = new System.Drawing.Point(169, 90), Name = "to_IndexBox", Size = new System.Drawing.Size(88, 20), TabIndex = 6 };
            //TextBox  = new TextBox { };

            //indexBox.Controls.AddRange(new Control[] { removeIndexBtn, selected_IndexLstBox, pr_index_addBtn , selected_IndexLbl , pr_index_clearBtn , intern_index_addBtn, intern_index_clearBtn , to_IndexBox ,});


            //options_grpBox.Controls.AddRange(new Control[] { pepLabel, pepBox , loadSpecBtn , loadMSBtn , boundariesBox, fragmentsBox, chargestateBox, indexBox, });
            //this.Controls.Add(options_grpBox);
        }
        private void reset_all()
        {
            FormWindowState curr_state = this.WindowState;
            Size curr_size = this.Size;

            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(2200, 925);

            Initialize_data_struct();
            Initialize_UI();
            Initialize_Oxy();
            Initialize_fit_UI();
            //Initialize_option_control();

            this.WindowState = curr_state;
            this.Size = curr_size;
        }

        private void Initialize_data_struct()
        {
            //aligned_intensities.Clear();
            all_data_aligned.Clear();
            fitted_results.Clear();
            powerSet.Clear();
            powerSet_distroIdx.Clear();
            summation.Clear();
            residual.Clear();
            custom_colors.Clear();

            all_data.Clear();
            for (int i = 0; i < candidate_fragments; i++)
            {
                all_data.Add(new List<double[]>());
                custom_colors.Add(Color.White.ToArgb());
            }
        }
        private void Initialize_UI()
        {
            int off_h = 35, space_h = 180;

            // initiallize tool strip only once!!
            var existing_tlStrip = GetControls(this).OfType<ToolStrip>().FirstOrDefault();
            if (existing_tlStrip == null)
            {
                ToolStrip tmp_tlStrp = new ToolStrip() { Name = "tmp_tlStrp" };
                ToolStripButton tlBtnN = new ToolStripButton() { Text = "New" };
                ToolStripButton tlBtnL = new ToolStripButton() { Text = "Load exp." };
                ToolStripButton tlBtnO = new ToolStripButton() { Text = "Open fit" };
                ToolStripButton tlBtnS = new ToolStripButton() { Text = "Save fit" };
                ToolStripButton tlBtnA = new ToolStripButton() { Text = "Add zeros" };
                
                tlBtnN.Click += (s, e) => { clear_data(); };
                tlBtnL.Click += (s, e) => { load_experimental(); };
                tlBtnO.Click += (s, e) => { load_data(); };
                tlBtnS.Click += (s, e) => { save_data(); };
                tlBtnA.Click += (s, e) => { add_zeros(); };

                tmp_tlStrp.Items.AddRange(new ToolStripItem[] { tlBtnN, tlBtnL, tlBtnO, tlBtnS, tlBtnA });
                this.Controls.Add(tmp_tlStrp);
            }

            // initiallize panel only once!!
            var existing_tmp_pnl = GetControls(this).OfType<Panel>().FirstOrDefault(c => c.Name == "candidate_fragments_panel");
            if (existing_tmp_pnl != null) existing_tmp_pnl.Dispose();

            Panel tmp_pnl = new Panel() { Name = "candidate_fragments_panel", Location = new Point(5, 30), Size = new Size(1300, 155), AutoScroll = true, Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left};
            this.Controls.Add(tmp_pnl);

            // initiallize combobox only once!!
            ComboBox tmp_cmbBox = new ComboBox() { Name = "candidate_fragments_cmbBox", Location = new Point(2, 5), Size = new Size(35, 20) };
            tmp_cmbBox.Items.AddRange(new object[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 });
            tmp_cmbBox.SelectedIndex = candidate_fragments - 2;
            tmp_cmbBox.SelectedIndexChanged += (s, e) => { candidate_fragments = tmp_cmbBox.SelectedIndex + 2; tmp_pnl.Dispose(); reset_all(); };
            tmp_pnl.Controls.Add(tmp_cmbBox);

            Label tmp_start_lbl = new Label() { Text = "exp.Start", Name = "exp_start_lbl", Location = new Point(0, 30), AutoSize = true };
            TextBox tmp_start_txtBox = new TextBox() { Name = "exp_start_txtBox", Location = new Point(2, 50), Size = new Size(40, 20) };
            Label tmp_stop_lbl = new Label() { Text = "exp.Stop", Name = "exp_stop_lbl", Location = new Point(0, 80), AutoSize = true };
            TextBox tmp_stop_txtBox = new TextBox() { Name = "exp_stop_txtBox", Location = new Point(2, 100), Size = new Size(40, 20) };
            tmp_start_txtBox.Click += (s, e) => { tmp_start_txtBox.SelectAll(); };
            tmp_stop_txtBox.Click += (s, e) => { tmp_stop_txtBox.SelectAll(); };
            tmp_start_txtBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(tmp_start_txtBox, tmp_stop_txtBox); };
            tmp_stop_txtBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) select_from_experimental(tmp_start_txtBox, tmp_stop_txtBox); };
            tmp_pnl.Controls.AddRange(new Control[] { tmp_start_lbl, tmp_start_txtBox, tmp_stop_lbl, tmp_stop_txtBox });
            
            // re-init all other ctrls
            for (int i = 0; i < candidate_fragments; i++)
            {
                Label tmp_lbl = new Label() { Location = new Point(i * space_h + off_h + 10, 7), Text = "distr. " + i.ToString(), AutoSize = true, TabIndex = i };
                TextBox tmp_name = new TextBox() { Name = i.ToString() + "name", Location = new Point(i * space_h + off_h + 50, 5), Size = new Size(60, 20), Text = i.ToString(), TextAlign = System.Windows.Forms.HorizontalAlignment.Center, Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold), TabIndex = i };
                TextBox tmp_factor = new TextBox() { Name = i.ToString() + "factor", Location = new Point(i * space_h + off_h + 115, 5), Size = new Size(45, 20), Text = "1", TextAlign = System.Windows.Forms.HorizontalAlignment.Center, TabIndex = i };
                TextBox tmp_data = new TextBox() { Name = i.ToString() + "data", Location = new Point(i * space_h + off_h + 12, 30), Size = new Size(170, 100), Multiline = true, ScrollBars = ScrollBars.Vertical, WordWrap = false, MaxLength = 1048576, TabIndex = i };
                CheckBox tmp_chkBox = new CheckBox() { Name = i.ToString() + "chkBox", Location = new Point(i * space_h + off_h + 165, 8), Checked = false, AutoSize = true, TabIndex = i  };

                //(M)tha m xreiastoun ta textbox allou?
                //(M)einai praktika o elegxos gia thn allagh twn dedomenvn opote o,ti allo control valw sth thesh tou tha to valw na kalei auta
                tmp_data.TextChanged += (s, e) => 
                { 
                    if (!is_loading) 
                    { 
                        parse_data(tmp_data);
                        recalculate_all_data_aligned();
                        refresh_iso_plot(); 
                    } 
                };

                tmp_factor.TextChanged += (s, e) => { if (!is_loading && !is_applying_fit) { if (!double.IsNaN(dParser(tmp_factor.Text))) refresh_iso_plot(tmp_data); } };                
                tmp_name.TextChanged += (s, e) => { if (!is_loading) { tmp_name.Text = string.Concat(tmp_name.Text.Where(c => !char.IsWhiteSpace(c))); refresh_iso_plot(); } };//TextBox tmp_name doesn't accept white space
                tmp_name.DoubleClick += (s, e) => { change_color(tmp_name); };
                tmp_factor.KeyDown += (s, e) => 
                { 
                    // step change intensity with arrows for lazy people
                    if (e.KeyData == Keys.Up) tmp_factor.Text = (dParser(tmp_factor.Text) + keyStep).ToString();
                    else if (e.KeyData == Keys.Down) tmp_factor.Text = (dParser(tmp_factor.Text) - keyStep).ToString(); 
                };
                tmp_chkBox.CheckedChanged += (s, e) =>
                {
                    if (!is_loading)
                    {
                        // disable 
                        int idx = tmp_chkBox.TabIndex;

                        if (tmp_chkBox.Checked)
                            if (all_data[idx].Count < 10)
                                tmp_chkBox.Checked = false;

                        refresh_iso_plot();
                    }
                };                

                tmp_pnl.Controls.AddRange(new Control[] { tmp_lbl, tmp_name, tmp_factor, tmp_data, tmp_chkBox });
            }
        }

        private void change_color(TextBox txtBox)
        {
            ColorDialog clrDlg = new ColorDialog();

            if (clrDlg.ShowDialog() == DialogResult.OK) { custom_colors[txtBox.TabIndex] = clrDlg.Color.ToArgb(); refresh_iso_plot(); }
        }

        private void Initialize_Oxy()
        {
            // isotopes plot
            if (iso_plot != null) iso_plot.Dispose();

            iso_plot = new OxyPlot.WindowsForms.PlotView() { Name = "iso_plot", Location = new Point(5, 185), Size = new Size(1310, 570), BackColor = Color.WhiteSmoke, Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom };
            this.Controls.Add(iso_plot);

            //(M)create a view model--> iso_model
            PlotModel iso_model = new PlotModel { PlotType = PlotType.XY, IsLegendVisible = true, LegendPosition = LegendPosition.TopRight, LegendFontSize = 13, TitleFontSize = 11 }; // Title = "",
            iso_plot.Model = iso_model;

            //iso_model.TrackerChanged += (s, e) => { e.HitResult.Position.X };
            //iso_model.MouseDown += (s, e) => {
            //    OxyPlot.Axes.Axis x; OxyPlot.Axes.Axis y;
            //    iso_model.GetAxesFromPoint(e.Position, out x, out y);
            //    DataPoint p = OxyPlot.Axes.Axis.InverseTransform(e.Position, x, y);
            //};

            iso_plot.Controller = new CustomPlotController();

            ContextMenu ctxMn = new ContextMenu() { };
            MenuItem showPoints = new MenuItem("Show charge ruler", manage_charge_points);
            MenuItem clearPoints = new MenuItem("Clear charge ruler", manage_charge_points);
            MenuItem copyImage = new MenuItem("Copy image", export_chartImage);
            MenuItem exportImage = new MenuItem("Export image to file", export_chartImage);
            ctxMn.MenuItems.AddRange(new MenuItem[] { showPoints, clearPoints, copyImage, exportImage });
            iso_model.MouseDown += (s, e) => { if (e.ChangedButton == OxyMouseButton.Right) { charge_center = e.Position; ContextMenu = ctxMn; } };

            //iso_plot.MouseWheel += (s, e) => { if (e.Delta > 0 && e.ToMouseEventArgs(OxyModifierKeys.Control).IsControlDown) iso_model.DefaultXAxis.ZoomAtCenter(2) ; };
            //bool isControlDown = System.Windows.Input Keyboard.IsKeyDown(Key.LeftCtrl);
            //var m = new ZoomStepManipulator(this, e.Delta * 0.001, isControlDown);
            //iso_plot.MouseWheel += (s, e) => 
            //{
            //    if (e.Delta > 0) iso_plot.Model.DefaultXAxis.ZoomAtCenter(1);
            //    };

            var linearAxis1 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "intensity" };
            iso_model.Axes.Add(linearAxis1);

            var linearAxis2 = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, Title = "m/z", Position = OxyPlot.Axes.AxisPosition.Bottom };
            iso_model.Axes.Add(linearAxis2);

            // residual plot
            if (res_plot != null) res_plot.Dispose();
            res_plot = new OxyPlot.WindowsForms.PlotView() { Name = "res_plot", Location = new Point(5, 760), Size = new Size(1310, 150), BackColor = Color.WhiteSmoke, Anchor = AnchorStyles.Bottom | AnchorStyles.Right  | AnchorStyles.Left };
            this.Controls.Add(res_plot);

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

        private void manage_charge_points(object sender, EventArgs e)
        {
            double chargeMin = 1;
            double chargeMax = 10;
            double[] range = new double[2] {-1, 1};

            iso_plot.Model.Annotations.Clear();

            if ((sender as MenuItem).Text == "Show charge ruler")
            {
                double mz = iso_plot.Model.DefaultXAxis.InverseTransform(charge_center.X);
                double h = iso_plot.Model.DefaultYAxis.InverseTransform(charge_center.Y);

                for (double i = chargeMin; i < chargeMax + 1; i++)
                    foreach (double j in range)
                        iso_plot.Model.Annotations.Add(new PointAnnotation() { X = (j * H_mass / i) + mz, Y = h, Size = 2, Text = Math.Round((j * H_mass / i) + mz, 4).ToString() + "(" + i.ToString() +")", Fill = charge_colors[(int)i], TextRotation = -45, TextVerticalAlignment = VerticalAlignment.Top });
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

        private void refresh_iso_plot(TextBox data_txtBox = null) 
        {
            //(M) to text box pou dexetai einai ekeino pou tou exoun ginei paste ta data pou tha plotaroume

            // 0. gather info on which fragments are selected to plot, and their respective intensities
            List<int> to_plot = get_selected_distros();//(M) vriskei poia indexes tou all_data einai checked
            List<double> UI_intensities = get_UI_intensities(to_plot.ToArray()); //(M)epistrefei list me tous factors

            // to_plot and UI_intensities contain ONLY the selected indexes and intensities

            // 1b. reset iso plot
            reset_iso_plot();//(M)ftiaxnei series gia OLA ta stoixeia tou all_data , to fit kai to residual

            if (to_plot.Count == 0) return;

            // 1a. rerun calculations for fit and residual
            recalculate_fitted_residual(to_plot, UI_intensities);
            
            // 2. replot all isotopes
            for (int i = 0; i < to_plot.Count; i++)
            {
                int curr_idx = to_plot[i];//to curr_idx antistoixei ston antistoixo index to selected fragment
                if (all_data_aligned.Count != 0)
                {
                    // get name of each line to be ploted
                    string name_str = GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name == curr_idx.ToString() + "name").Text;
                    (iso_plot.Model.Series[curr_idx] as LineSeries).Title = name_str;

                    for (int j = 0; j < all_data_aligned.Count; j++)
                        (iso_plot.Model.Series[curr_idx] as LineSeries).Points.Add(new OxyPlot.DataPoint(all_data[0][j][0], UI_intensities[i] * all_data_aligned[j][curr_idx]));
                }
            }

            // 3. fitted plot (if more than 2 fragments)
            if (summation.Count > 0)//(M)to summation ypologizetai mono otan to_plot.Count>=2
                if (GetControls(this).OfType<CheckBox>().FirstOrDefault(c => c.Name == "Fitting_chkBox").Checked)
                    for (int j = 0; j < summation.Count; j++)
                        (iso_plot.Model.Series[all_data.Count] as LineSeries).Points.Add(new OxyPlot.DataPoint(summation[j][0], summation[j][1]));

            // 4. residual plot
            if (residual.Count > 0)
                for (int j = 0; j < residual.Count; j++)
                    (res_plot.Model.Series[0] as LineSeries).Points.Add(new OxyPlot.DataPoint(residual[j][0], residual[j][1]));

            invalidate_all();
        }

        private void recalculate_fitted_residual(List<int> to_plot, List<double> UI_intensities)
        {
            // calculate addition of selected fragments, and the respective residual
            // it is always called on every refresh of the plot 
            // if it is called from a selected fit change, no need to seek info from fit results. Results are already on the UI (checkbox.checked, and factor textBox)
            // to_plot and UI_intensities may also contain experimental index that is not necessary for sum or residual and has to be removed for coding brevity
            // shallow copy to_plot and UI_intensities so as not to fuck up original Lists

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

        private void reset_iso_plot()
        {
            iso_plot.Model.Series.Clear();

            for (int i = 0; i < all_data.Count; i++)
            {
                LineSeries tmp = new LineSeries() { StrokeThickness = 2, Color = get_fragment_color(i) };
                if (i == 0) tmp.StrokeThickness = 1;
                iso_plot.Model.Series.Add(tmp);
            }
            LineSeries fit = new LineSeries() { StrokeThickness = 2, Color = OxyColors.Black, LineStyle = LineStyle.Dot };
            iso_plot.Model.Series.Add(fit);

            res_plot.Model.Series.Clear();
            LineSeries res = new LineSeries() { StrokeThickness = 2, Color = OxyColors.Black };
            res_plot.Model.Series.Add(res);
        }

        private OxyColor get_fragment_color(int idx)
        {
            // decide proper color according to fragment type
            IEnumerable<TextBox> distro_names = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("name"));
            TextBox distro_txtBox = distro_names.FirstOrDefault(t => t.TabIndex == idx);
            string distro_name = distro_names.FirstOrDefault(t => t.TabIndex == idx).Text;

            // fisrt check if custom color is desired and set
            if (custom_colors[idx] != Color.White.ToArgb())
            {
                OxyColor clr = OxyColor.FromUInt32((uint)custom_colors[idx]);
                distro_txtBox.ForeColor = clr.ToColor();
                return clr;
            }
            if (distro_name == "") return data_colors[idx];
            
            // find if it belongs to a group
            OxyColor[] group_color;

            if (distro_name[0] == 'b') group_color = b_colors;
            else if (distro_name[0] == 'y') group_color = y_colors;
            else if (distro_name[0] == 'c') group_color = c_colors;
            else if (distro_name[0] == 'z') group_color = z_colors;
            else if (distro_name[0] == 'a') group_color = a_colors;
            else if (distro_name[0] == 'x') group_color = x_colors;
            else group_color = data_colors;

            // find the position of the current fragment in his family 
            int pos = 0;
            foreach (TextBox distro in distro_names)
                if (distro.TabIndex < idx && distro.Text[0] == distro_name[0]) pos++;

            // set the color to the name textBox and return the color to the chart
            distro_txtBox.ForeColor = group_color[pos % 3].ToColor();
            custom_colors[idx] = group_color[pos % 3].ToColor().ToArgb();
            return group_color[pos % 3];
        }

        #endregion

        #region menu items
        private void clear_data()
        {
            reset_all();
        }

        private void load_experimental()
        {
            OpenFileDialog expData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            expData.InitialDirectory = Application.StartupPath + "\\Data";
            expData.Title = "Load experimental data"; expData.FileName = "";
            expData.Filter = "data file|*.txt|All files|*.*";

            if (expData.ShowDialog() != DialogResult.Cancel)
            {
                fullPath = expData.FileName;
                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);

                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                int arrayPositionIndex = 0;
                experimental.Clear();

                ToolStrip tmp_tlStrp = GetControls(this).OfType<ToolStrip>().FirstOrDefault();
                ToolStripProgressBar tlPrgBr = new ToolStripProgressBar() { Name = "tlPrgBr", Alignment = ToolStripItemAlignment.Right, Minimum = 0, Value = 0, Maximum = lista.Count, Size = new Size(150, 15), AutoSize = false };
                tmp_tlStrp.Items.Add(tlPrgBr);

                for (int j = 0; j != (lista.Count); j++)
                {
                    try
                    {
                        string[] tmp_str = lista[j].Split('\t');
                        if (tmp_str.Length == 2) experimental.Add(new double[] { dParser(tmp_str[0]), dParser(tmp_str[1]) });
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                    arrayPositionIndex++;
                    tlPrgBr.Value++;
                }
                tlPrgBr.Dispose();

                // post load actions
                GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name.EndsWith("factor") && t.TabIndex == 0).Text = "1.0"; 
                GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name == "exp_start_txtBox").Text = experimental[0][0].ToString();
                GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name == "exp_stop_txtBox").Text = experimental[experimental.Count - 1][0].ToString();
            }
        }

        private void save_data()
        {
            SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = "", Filter = "data file|*.txt|all files|*.*", OverwritePrompt = true, AddExtension = true };
            
            //save.InitialDirectory = Application.StartupPath + "\\Data";
            //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
            //if (di.Exists != true) di.Create();

            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                file.WriteLine("Mode:\texternal data");
                file.WriteLine("Fitted isotopes:\t" + candidate_fragments.ToString());
                file.WriteLine("m/z[Da]\tIntensity");
                file.WriteLine();

                List<TextBox> data_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("data")).ToList();
                List<TextBox> name_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("name")).ToList();
                List<CheckBox> selected_chkBoxs = GetControls(this).OfType<CheckBox>().Where(t => t.Name.EndsWith("chkBox")).ToList();
                List<TextBox> fact_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("factor")).ToList();

                foreach (TextBox txtBox in data_txtBoxs)
                {
                    // also do not save anything if there are no data
                    if (txtBox.Lines.Count() < 1) continue;
                    
                    // save name and factor, then data
                    file.WriteLine("Name:\t" + name_txtBoxs.FirstOrDefault(t => t.TabIndex == txtBox.TabIndex).Text);
                    file.WriteLine("Factor:\t" + fact_txtBoxs.FirstOrDefault(t => t.TabIndex == txtBox.TabIndex).Text);
                    file.WriteLine("Selected:\t" + selected_chkBoxs.FirstOrDefault(c => c.TabIndex == txtBox.TabIndex).Checked.ToString());
                    file.WriteLine("Color:\t" + custom_colors[txtBox.TabIndex].ToString());  
                    foreach (string line in txtBox.Lines) file.WriteLine(line);
                    file.WriteLine();
                }
                file.Flush(); file.Close(); file.Dispose();
            }
        }

        private void load_data()
        {
            OpenFileDialog loadData = new OpenFileDialog();
            List<string> lista = new List<string>();
            string fullPath = "";

            // Open dialogue properties
            //loadData.InitialDirectory = Application.StartupPath + "\\Data";
            loadData.Title = "Load fitting data"; loadData.FileName = "";
            loadData.Filter = "data file|*.txt|All files|*.*";

            if (loadData.ShowDialog() != DialogResult.Cancel)
            {
                is_loading = true;  // performance
                fullPath = loadData.FileName;

                reset_all();

                System.IO.StreamReader objReader = new System.IO.StreamReader(fullPath);

                do { lista.Add(objReader.ReadLine()); }
                while (objReader.Peek() != -1);
                objReader.Close();

                int arrayPositionIndex = 0;
                int isotope_count = -1;
                List<TextBox> data_txtBoxs = new List<TextBox>();//ta koutakia me ta data
                List<TextBox> name_txtBoxs = new List<TextBox>();//ta koutakia me ta onomata
                List<TextBox> fact_txtBoxs = new List<TextBox>();//ta koutakia me tous factors
                List<CheckBox> iso_chkBoxs = new List<CheckBox>();

                string tmp = "";

                for (int j = 0; j != (lista.Count); j++)
                {
                    string[] str = new string[3];
                    try
                    {
                        str = lista[j].Split('\t');

                        if (lista[j] == "" || lista[j].StartsWith("-") || lista[j].StartsWith("m/z")) continue; // comments
                        else if (lista[j].StartsWith("Mode")) ; // to be implemented
                        else if (lista[j].StartsWith("Fitted"))
                        {
                            // get the number of isotopes and refresh all UI and get a grip on the new dynamic controls
                            ComboBox tmp_cmbBox = GetControls(this).OfType<ComboBox>().FirstOrDefault(c => c.Name == "candidate_fragments_cmbBox");
                            tmp_cmbBox.SelectedIndex = Convert.ToInt32(str[str.Count() - 1]) - 2;
                            //candidate_fragments = Convert.ToInt32(str[1]);
                            //reset_all();

                            data_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("data")).ToList();
                            name_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("name")).ToList();
                            fact_txtBoxs = GetControls(this).OfType<TextBox>().Where(t => t.Name.EndsWith("factor")).ToList();
                            iso_chkBoxs = GetControls(this).OfType<CheckBox>().Where(t => t.Name.EndsWith("chkBox")).ToList();
                        }
                        else if (lista[j].StartsWith("Name"))
                        {
                            // when there is a new name, all the data accumulated at tmp holder has to be assigned to textBox and all_data[] and reset
                            isotope_count++;
                            name_txtBoxs[isotope_count].Text = str[1];
                            if (tmp != "") { data_txtBoxs[isotope_count - 1].Text = tmp; parse_data_txt(tmp, isotope_count - 1); tmp = ""; }
                        }
                        else if (lista[j].StartsWith("Factor")) fact_txtBoxs[isotope_count].Text = str[1];
                        else if (lista[j].StartsWith("Selected")) iso_chkBoxs[isotope_count].Checked = str[1] == "True";
                        else if (lista[j].StartsWith("Color")) custom_colors[isotope_count] = Convert.ToInt32(str[1]);
                        else tmp += lista[j] + "\r\n";
                    }
                    catch { MessageBox.Show("Error in data file in line: " + arrayPositionIndex.ToString() + "\r\n" + lista[j], "Error!"); return; }
                    arrayPositionIndex++;
                }
                // the assignement to textBox and all_data[] has to be repeated one last time manualy for the last distro.
                // assignement is done every time a new name is foune in the lista. After the last one there is no new name.
                data_txtBoxs[isotope_count].Text = tmp; parse_data_txt(tmp, isotope_count); iso_chkBoxs[isotope_count].Checked = true;
            }
            else { return; }
            is_loading = false;

            // post load actions
            recalculate_all_data_aligned();
            refresh_iso_plot();
        }

        private void add_zeros()
        {
            List<double[]> data = new List<double[]>();
            List<double[]> data_with_zeros = new List<double[]>();
            string export = "";

            Form popUp = new Form() { Text = "Add zeros to list.", FormBorderStyle = FormBorderStyle.FixedToolWindow, MaximizeBox = false, MinimizeBox = false, StartPosition = FormStartPosition.Manual, TopMost = true,
                Location = Control.MousePosition, Size = new Size(280, 280), AutoSize = true };
            Label lbl = new Label() { Text = "Insert single point list.", AutoSize = true, Location = new Point(10, 5) };
            TextBox txtBox = new TextBox() { Name = "data", Location = new Point(10, 30), Size = new Size(250, 200), Multiline = true, ScrollBars = ScrollBars.Vertical, WordWrap = false, MaxLength = 1048576 };
            Button btn = new Button() { Location = new Point(100, 240), Text = "Add zeros" };

            btn.Click += (s, e) =>
            {
                string[] temp = txtBox.Lines;
                int points = temp.Length;

                if (points == 0) return;

                for (int i = 0; i < points; i++)
                {
                    string[] tmp;
                    if (temp[i].Contains("\t")) tmp = temp[i].Split('\t');
                    else if (temp[i].Contains(" ")) tmp = temp[i].Split(' ');
                    else { lbl.Text = "Unknown text delimeter. Use tabs or space."; return; }

                    if (tmp.Length > 1)
                    {
                        // first generate original line with tabs
                        string point = string.Join("\t", tmp);

                        // then create line with zeros and tab
                        string[] tmp_zero = tmp;
                        tmp_zero[1] = "0";                        
                        string point_zero = string.Join("\t", tmp_zero);

                        // generate full full set (3 points)
                        export += point_zero + "\r\n" + point + "\r\n" + point_zero + "\r\n";
                    }
                }

                Clipboard.Clear();
                Clipboard.SetText(export);
                lbl.Text = "Extended list with zeros is copied to clipboard.";
                export = "";
            };

            popUp.Controls.AddRange(new Control[] { lbl, txtBox, btn });
            popUp.Show(); popUp.BringToFront();
        }

        #endregion

        #region Operations on data

        private void select_from_experimental(TextBox start_txtBox, TextBox stop_txtBox)
        {
            // will seach for the closest exeprimental mass to the input value and refresh distribution 0.
            double start = dParser(start_txtBox.Text);
            double end = dParser(stop_txtBox.Text);

            // check validity
            if (double.IsNaN(start) || double.IsNaN(end)) { MessageBox.Show("Input value is not a number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start <= 0 || end <= 0) { MessageBox.Show("Negative values detected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start >= end) { MessageBox.Show("Start value is larger than the end value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (start < experimental[0][0]) { MessageBox.Show("Value out of range!\r\nStart value is smaller than the experimental start m/z!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (end > experimental[experimental.Count - 1][0]) { MessageBox.Show("Value out of range!\r\nEnd value is larger than the experimental end m/z!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; };

            // find closest experimental m/z
            int start_idx = 0;
            for (int i = 1; i < experimental.Count; i++)
                if (start < experimental[i][0]) { start_txtBox.Text = experimental[i - 1][0].ToString(); start_idx = i - 1; break; }

            int end_idx = 0;
            for (int i = experimental.Count - 1; i > 1; i--)
                if (end > experimental[i][0]) { stop_txtBox.Text = experimental[i + 1][0].ToString(); end_idx = i + 1; break; }

            // copy experimental data range to distribution 0
            StringBuilder strBldr = new StringBuilder();
            for (int i = start_idx; i < end_idx + 1; i++)
                strBldr.Append(experimental[i][0].ToString() + "\t" + experimental[i][1].ToString() + "\r\n");

            //GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name.EndsWith("data") && t.TabIndex == 0).Text = "";
            GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name.EndsWith("data") && t.TabIndex == 0).Text = strBldr.ToString();
        }

        private void parse_data(TextBox txtBox)
        {
            //gia kathe textbox vriskei to tab index poy tou antistoixei kai meta ta vazei sth lista all data
            //all_data[arithmos fragment][arithmos metrhshs][X or Y]
            int idx = txtBox.TabIndex;
            
            // reset data
            all_data[idx].Clear();

            // txtBox.Lines call, COSTS A LOT!!!! take it outside of loop!!!
            string[] temp = txtBox.Lines;//(M) de m xreiazetai--> tha exv th list profile edw
            int points = temp.Length;//(M) de m xreiazetai--> isws gia elegxo mono

            if (points == 0) return;
            for (int i = 0; i < points; i++)
            {
                //(M) edw tha valw na eisagei ta stoixeia apo to profile pou exw ypologisei egw
                string[] tmp = temp[i].Split('\t');
                if (tmp.Length == 2) all_data[idx].Add(new double[] { dParser(tmp[0]), dParser(tmp[1]) });//(M)elegxos gia to an kathe grammh exei 2 noumera, de m xreiazetai
                //(M)to dParser ha mporousa na to xrhsimopoihsw
                //(M)to profile to exw se float number na to elegksw
            }
        }

        private void parse_data_txt(string data, int idx)
        {
            all_data[idx].Clear();
            string[] tmp = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split('\t');
                if (tmp2.Length == 2) all_data[idx].Add(new double[] { dParser(tmp2[0]), dParser(tmp2[1]) });
            }
        }

        private double dParser(string t)
        {
            double d;
            if (double.TryParse(t, out d)) return d;

            return double.NaN;
        }

        private void recalculate_all_data_aligned()
        {
            //kaleitai kathe fora pou prostithetai neo stoixeio sto all_data
            List<int> idxs = new List<int>();//einai mia lista 0 1 2 3..osa kai ta stoixeia tou all data


            // will recalculate all data aligned
            for (int i = 0; i < all_data.Count; i++) idxs.Add(i);
            
            all_data_aligned = align_distros(idxs);
            //(M)praktika einai lista me pinakes kai seires osa ta peiramatika dedomena 
            //(M)kathe pinakas exei to arxiko peiramatiko dedomeno kai to interpolated tou kathe fragment, an den yphrxe exei 0
        }

        private List<int> get_selected_distros()
        {
            //apo ta dedomena poia einai checked-->to all_data exei tosa stoixeia osa einai kai ta checkboxes
            // will return all checked distros
            // enumerate all checkBoxes once, outside loop
            List<int> distros = new List<int>();
            IEnumerable<CheckBox> tmp = GetControls(this).OfType<CheckBox>();

            for (int i = 0; i < all_data.Count; i++)
                if (tmp.FirstOrDefault(c => c.TabIndex == i).Checked)
                    distros.Add(i);

            return distros;
        }

        private List<double[]> align_distros(List<int> distro_fragm_idxs)
        {
            List<double[]> aligned_intensities = new List<double[]>();//(M)praktika einai lista me pinakes kai seires osa ta peiramatika dedomena 
            //(M)kathe pinakas exei to arxiko peiramatiko dedomeno kai to interpolated tou kathe fragment, an den yphrxe exei 0

            // generate alligned (in m/z) isotope distributions at the same step as the experimental
            // pickup each point in experimental and find (interpolate) the intensity of each fragment
            for (int i = 0; i < all_data[0].Count; i++) //(M)loop for all the experimental points count
            {
                // one by one for all points
                List<double> one_aligned_point = new List<double>();
                // add experimental
                one_aligned_point.Add(all_data[0][i][1]);//(M)prosthetei apo ta experimental data ola ta y-->intensity

                double mz_toInterp = all_data[0][i][0];//(M)prosthetei apo ola ta experimental ola ta x-->m/z

                for (int j = 1; j < distro_fragm_idxs.Count; j++)
                {
                    int distro_idx = distro_fragm_idxs[j];

                    // interpolate to find the proper intensity. Intensity will be zero outside of the fragment envelope.
                    double aligned_value = 0.0;

                    for (int k = 0; k < all_data[distro_idx].Count - 1; k++)
                    {
                        if (mz_toInterp >= all_data[distro_idx][k][0] && mz_toInterp <= all_data[distro_idx][k + 1][0])
                        {
                            aligned_value = interpolate(all_data[distro_idx][k][0], all_data[distro_idx][k][1], all_data[distro_idx][k + 1][0], all_data[distro_idx][k + 1][1], mz_toInterp);
                            break;
                        }
                    }
                    one_aligned_point.Add(aligned_value);
                }
                aligned_intensities.Add(one_aligned_point.ToArray());
            }

            return aligned_intensities;
        }

        private double interpolate(double x1, double y1, double x2, double y2, double x_inter)
        {
            return ((x_inter - x1) * y2 + (x2 - x_inter) * y1) / (x2 - x1);
        }

        public IEnumerable<Control> GetControls(Control c)
        {
            return new[] { c }.Concat(c.Controls.OfType<Control>().SelectMany(x => GetControls(x)));
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

        #region fit
        private void Initialize_fit_UI()
        {
            var existing_tmp_grpBox = GetControls(this).OfType<GroupBox>().FirstOrDefault(n => n.Name == "Fitting_grpBox");
            if (existing_tmp_grpBox != null) existing_tmp_grpBox.Dispose();

            GroupBox tmp_grpBox = new GroupBox() { Name = "Fitting_grpBox", Text = "Fitting", Location = new Point(1320, 30), Size = new Size(250, 700), Anchor = AnchorStyles.Right | AnchorStyles.Top};
            CheckBox tmp_chkBox = new CheckBox() { Name = "Fitting_chkBox", Text = "Plot fit", Location = new Point(130, 15), AutoSize = true, Checked = true };
            Button tmp_btn = new Button() { Text = "Fit", Location = new Point(50, 12), Size = new Size(60, 23) };
            tmp_chkBox.CheckedChanged += (s, e) => { refresh_iso_plot(); };
            tmp_btn.Click += (s, e) => { start_fit(); };


            tmp_grpBox.Controls.AddRange(new Control[] { tmp_btn, tmp_chkBox });
            this.Controls.AddRange(new Control[] { tmp_grpBox });
        }

        private void refresh_fit_results(List<double[]> fitted_results)
        {
            // 1. clear previous results (UI ctrls and chart)
            GroupBox grpBox = GetControls(this).OfType<GroupBox>().FirstOrDefault(g => g.Name == "Fitting_grpBox");
            try { grpBox.Controls.OfType<Panel>().FirstOrDefault().Dispose(); }
            catch { }

            Panel pnl = new Panel() { Location = new Point(5, 40), Size = new Size(240, 600), AutoScroll = true };
            pnl.MouseEnter += (s, e) => { pnl.Focus(); };   // wheel mouse scroll
            //grpBox.Controls.Add(pnl);

            // header
            Label header_lbl = new Label() { Text = "Fragment   adj.height     SSE", Location = new Point(5, 0), AutoSize = true, TabIndex = 100 };
            pnl.Controls.Add(header_lbl);

            // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities
            // we have to convert powerSet to the actual index number of each fragment!!!
            powerSet_to_distroIdx();

            for (int i = 0; i < fitted_results.Count; i++)
            {
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
            
            grpBox.Controls.Add(pnl);
            
            // mark with blue the best fit
            Label minSSE_lbl = GetControls(pnl).OfType<Label>().FirstOrDefault(l => l.TabIndex == 0);
            //moy petakse error edw
            minSSE_lbl.ForeColor = Color.Blue;

            plot_selected_fit(minSSE_lbl);
        }

        private void reset_fit_lbl_colors(Panel pnl)
        {
            // reset all to black and paint best fit to blue
            Label[] tmp_lbl = GetControls(pnl).OfType<Label>().ToArray();
            foreach (Label lbl in tmp_lbl) lbl.ForeColor = Color.Black;
            tmp_lbl.FirstOrDefault(l => l.TabIndex == 0).ForeColor = Color.Blue;
        }

        private void plot_selected_fit(Label tmp_lbl)
        {
            // 1. adjust corresponding fragment heights
            double[] intensities = fitted_results[tmp_lbl.TabIndex];
            int[] distroIdxs = powerSet_distroIdx[tmp_lbl.TabIndex];
            int[] powerSetIdxs = powerSet[tmp_lbl.TabIndex];

            // Performance: flag to disable refresh_plot multiple calls from factors_textChanged
            is_applying_fit = true;
            for (int i = 1; i < candidate_fragments; i++)
            {
                // run all fragments. If a frag exists in fit then adjust, else set to zero.
                int idx = Array.IndexOf(distroIdxs, i);
                if (idx > -1) GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name == distroIdxs[idx].ToString() + "factor").Text = intensities[idx].ToString();
                else GetControls(this).OfType<TextBox>().FirstOrDefault(t => t.Name == i.ToString() + "factor").Text = "0.0";
            }
            is_applying_fit = false;

            // enable disable plot  ???

            refresh_iso_plot();
        }

        private void start_fit()
        {
            //generateAlphaNumeric();
            //return;
            // 0. Clear globals
            powerSet.Clear();
            powerSet_distroIdx.Clear();

            // 1. check data integrity
            if (!validate_data()) return;

            // 2. find selected distros for fitting
            List<int> distro_idxs = get_selected_distros();
            distro_idxs.RemoveAt(0);

            // 3. align all data to the experimental all_data[0]
            // [m/z point 0] {exp, frag1, grag2, frag3, ... }
            // will be also needed later for plot
            aligned_intensities.Clear();
            aligned_intensities = align_distros(distro_idxs);

            // 4. initiate fitting procedure
            fitted_results.Clear();
            fitted_results = fit_distros(aligned_intensities);

            // 5. display results
            refresh_fit_results(fitted_results);
        }

        private List<double[]> fit_distros(List<double[]> aligned_intensities)
        {
            List<double[]> res = new List<double[]>();

            // this is all the logic of how many time the fitting should run
            // we want to fit every possible combination to get the best result (minimum SSE)

            // 1. generate the powerSet. It contains only fragment permutations
            powerSet.Clear();
            //powerSet = generatePowerSet(aligned_intensities[0].Length);

            // build list with numbers
            int total = aligned_intensities[0].Length - 1;
            int[] seq = new int[total];
            for (int i = 0; i < total; i++) seq[i] = i + 1;
            powerSet = FastPowerSet(seq).ToList();
            powerSet.RemoveAt(0);

            // powerSet is [1,2,3...] which means [1st, 2nd, 3rd,...] SELECTED (checked) fragment. They are in accordance with aligned_intensities

            ToolStrip tmp_tlStrp = GetControls(this).OfType<ToolStrip>().FirstOrDefault();
            ToolStripProgressBar tlPrgBr = new ToolStripProgressBar() { Name = "tlPrgBr", Alignment = ToolStripItemAlignment.Right, Minimum = 0, Value = 0, Maximum = powerSet.Count, Size = new Size(150, 15), AutoSize = false };
            tmp_tlStrp.Items.Add(tlPrgBr);

            double experimental_max = aligned_intensities.Max(element => element[0]);

            foreach (int[] subSet in powerSet)
            {
                tlPrgBr.Value++;
                // generate a new list containing only the fragments intensities of the subSet, and the experimental
                List<double[]> aligned_intensities_subSet = new List<double[]>();

                for (int i = 0; i < aligned_intensities.Count; i++)//i --> number of measurements
                {
                    // first add experimental
                    double[] tmp = new double[subSet.Length + 1];
                    tmp[0] = aligned_intensities[i][0];

                    // then all respective fragments
                    for (int j = 0; j < subSet.Length; j++) tmp[j + 1] = aligned_intensities[i][subSet[j]];

                    aligned_intensities_subSet.Add(tmp);//{exp subset[0]...subset[n-1]}
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

            return res;
        }

        private List<double> get_UI_intensities(int[] subSet, double max = 1.0, bool optimizer_default = false)
        {
            //(Μ)to subset einai to to_plot se array to opoio perieei touw indexes tvn epilegmenvn fragments

            // optimizer_default = true is for the optimizer
            // will return some default values in case factor textbox is empty or wrong

            // optimizer_default = false is for the normal replot
            // will return whatever is on textBox or 0.0 on wrong value

            List<double> UI_intensities = new List<double>();

            Panel tmp_pnl = GetControls(this).OfType<Panel>().FirstOrDefault(p => p.Name == "candidate_fragments_panel");
            List<TextBox> txtBoxes = GetControls(tmp_pnl).OfType<TextBox>().ToList();

            for (int i = 0; i < subSet.Length; i++)
            {
                string tmp = txtBoxes.FirstOrDefault(l => l.Name.EndsWith("factor") && l.TabIndex == subSet[i]).Text; 
                //(M) pairnei th timh tou ekastote factor pou oristhke gia kathe fragment
                double tmpD = dParser(tmp);

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

        public class lastElement : IComparer
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare((x as double[]).Last(), (y as double[]).Last()));
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

        private void powerSet_to_distroIdx()
        {
            List<int> distro_idxs = get_selected_distros();

            for (int i = 0; i < powerSet.Count; i++)
            {
                powerSet_distroIdx.Add(new int[powerSet[i].Length]);

                for (int j = 0; j < powerSet[i].Length; j++)
                    powerSet_distroIdx[i][j] = distro_idxs[powerSet[i][j] - 1];
            }
        }

        private double[] estimate_fragment_height(List<double[]> aligned_intensities)
        {
            // 1. initialize needed params
            double[] coeficients = new double[] { 100.0, 0.0 };
            double epsx = 0.0001;
            int maxits = 10000;
            alglib.minlmstate state;
            alglib.minlmreport rep;

            alglib.minlmcreatev(2, coeficients, 0.001, out state);
            alglib.minlmsetcond(state, epsx, maxits);
            alglib.minlmoptimize(state, sse, null, aligned_intensities);
            alglib.minlmresults(state, out coeficients, out rep);

            // 2. save result
            double[] minimum = new double[3] { coeficients[0], coeficients[1], state.fi[0] };
            return minimum;
        }

        private double[] estimate_fragment_height_multiFactor(List<double[]> aligned_intensities, List<double> UI_intensities)
        {
            // 1. initialize needed params
            // in coeficients[0] refers to 1st frag, and in aligned_intensities[0] refers to experimental
            // UI_intensities is initial values to make a starting point
            int distros_num = aligned_intensities[0].Length - 1;//number of fragments in this subset

            double[] coeficients = UI_intensities.ToArray();
            double[] bndl = new double[distros_num];
            double[] bndh = new double[distros_num];
            for (int i = 0; i < distros_num; i++) { bndl[i] = coeficients[i] * 0.01; bndh[i] = coeficients[i] * 100.0; }

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

        public void sse(double[] x, double[] func, object aligned_intensities)
        {
            func[0] = 0;

            List<double[]> two_series = aligned_intensities as List<double[]>;

            for (int i = 0; i < two_series.Count; i++)
            {
                func[0] += Math.Pow((two_series[i][0] - x[0] * two_series[i][1]), 2);
            }
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

        private bool validate_data()
        {
            // validity controls

            // 1. empty experimental
            if (all_data[0].Count < 10) { MessageBox.Show("Not enough experimental points! (distribution 0)", "Error!"); return false; };

            // 2. none selected or selected is empty distribution to fit
            bool any_selected = false, selected_is_empty = false;
            for (int i = 1; i < all_data.Count; i++)
            {
                if (GetControls(this).OfType<CheckBox>().FirstOrDefault(c => c.TabIndex == i).Checked)
                {
                    any_selected = true;
                    if (all_data[i].Count < 10) selected_is_empty = true;
                }
            }

            if (!any_selected) { MessageBox.Show("No distribution selected to perform fit!", "Error!"); return false; };
            if (selected_is_empty) { MessageBox.Show("Selected distribution has inadequate data points to perform fit!", "Error!"); return false; };

            return true;
        }


        #endregion

        #region debug
        private void generateAlphaNumeric()
        {
            char[] chars = new char[62];
            char[] Chars = new char[62];
            string fix = "ack";
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\pass_back4.txt");
            //chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            Chars = "Bb".ToCharArray();
            chars = "SsKk1234567890!@#$%^&*()".ToCharArray();


            //for (int i = 0; i < Chars.Length; i++)
            //    file.WriteLine(Chars[i].ToString() + fix);

            //for (int i = 0; i < Chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        file.WriteLine(Chars[i].ToString() + fix + chars[j].ToString());


            //for (int i = 0; i < Chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            file.WriteLine(Chars[i].ToString() + fix + chars[j].ToString() + chars[k].ToString());

            //for (int i = 0; i < Chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            for (int l = 0; l < chars.Length; l++)
            //                file.WriteLine(Chars[i].ToString() + fix + chars[j].ToString() + chars[k].ToString() + chars[l].ToString());

            for (int i = 0; i < Chars.Length; i++)
                for (int j = 0; j < chars.Length; j++)
                    for (int k = 0; k < chars.Length; k++)
                        for (int l = 0; l < chars.Length; l++)
                            for (int m = 0; m < chars.Length; m++)
                                file.WriteLine(Chars[i].ToString() + fix + chars[j].ToString() + chars[k].ToString() + chars[l].ToString() + chars[m].ToString());






            //for (int i = 0; i < chars.Length; i++)
            //    file.WriteLine(chars[i].ToString());

            //for (int i = 0; i < chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        file.WriteLine(chars[i].ToString() + chars[j].ToString());

            //for (int i = 0; i < chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            file.WriteLine(chars[i].ToString() + chars[j].ToString() + chars[k].ToString());

            //for (int i = 0; i < chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            for (int l = 0; l < chars.Length; l++)
            //                file.WriteLine(chars[i].ToString() + chars[j].ToString() + chars[k].ToString() + chars[l].ToString());

            //for (int i = 0; i < chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            for (int l = 0; l < chars.Length; l++)
            //                for (int m = 0; m < chars.Length; m++)
            //                    file.WriteLine(chars[i].ToString() + chars[j].ToString() + chars[k].ToString() + chars[l].ToString() + chars[m].ToString());

            //for (int i = 0; i < chars.Length; i++)
            //    for (int j = 0; j < chars.Length; j++)
            //        for (int k = 0; k < chars.Length; k++)
            //            for (int l = 0; l < chars.Length; l++)
            //                for (int m = 0; m < chars.Length; m++)
            //                    for (int n = 0; n < chars.Length; n++)
            //                        file.WriteLine(chars[i].ToString() + chars[j].ToString() + chars[k].ToString() + chars[l].ToString() + chars[m].ToString() + chars[n].ToString());




            file.Flush(); file.Close(); file.Dispose();
        }


        private void recur(char[] chars, System.IO.StreamWriter file, int max, int curr)
        {
            if (curr == max) return;

            for (int i = 0; i < chars.Length; i++)
            {
                file.WriteLine(chars[i].ToString());
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.WriteLine(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

        #endregion

    }

}
