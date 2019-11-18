using System.Collections;

namespace Isotope_fitting
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label customRes_Btn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFit = new System.Windows.Forms.TabPage();
            this.plots_grpBox = new System.Windows.Forms.Panel();
            this.fit_grpBox = new System.Windows.Forms.GroupBox();
            this.toolStrip_plot = new System.Windows.Forms.ToolStrip();
            this.res_grpBox = new System.Windows.Forms.GroupBox();
            this.user_grpBox = new System.Windows.Forms.Panel();
            this.fragStorage_Lbl = new System.Windows.Forms.Label();
            this.toolStrip_fragList = new System.Windows.Forms.ToolStrip();
            this.toolStrip_fit_sort = new System.Windows.Forms.ToolStrip();
            this.factor_panel = new System.Windows.Forms.Panel();
            this.fragTypes_tree = new System.Windows.Forms.TreeView();
            this.frag_tree = new System.Windows.Forms.TreeView();
            this.fitOptions_grpBox = new System.Windows.Forms.GroupBox();
            this.fit_sel_Btn = new System.Windows.Forms.Button();
            this.fit_Btn = new System.Windows.Forms.Button();
            this.fitMax_Label = new System.Windows.Forms.Label();
            this.fitMin_Label = new System.Windows.Forms.Label();
            this.fitMax_Box = new System.Windows.Forms.TextBox();
            this.fitMin_Box = new System.Windows.Forms.TextBox();
            this.stepRange_Lbl = new System.Windows.Forms.Label();
            this.step_rangeBox = new System.Windows.Forms.TextBox();
            this.fitStep_Box = new System.Windows.Forms.TextBox();
            this.fitStep_Label = new System.Windows.Forms.Label();
            this.bigPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_calc = new System.Windows.Forms.Panel();
            this.new_Btn = new System.Windows.Forms.Button();
            this.displayPeakList_btn = new System.Windows.Forms.Button();
            this.optionBtn = new System.Windows.Forms.Button();
            this.loadExp_Btn = new System.Windows.Forms.Button();
            this.chargeMax_Box = new System.Windows.Forms.TextBox();
            this.pep_Label = new System.Windows.Forms.Label();
            this.internal_lstBox = new System.Windows.Forms.CheckedListBox();
            this.loadMS_Btn = new System.Windows.Forms.Button();
            this.addin_lstBox = new System.Windows.Forms.CheckedListBox();
            this.pep_Box = new System.Windows.Forms.TextBox();
            this.machine_listBox = new System.Windows.Forms.ListBox();
            this.frag_Label = new System.Windows.Forms.Label();
            this.Mdvw_lstBox = new System.Windows.Forms.CheckedListBox();
            this.charge_Label = new System.Windows.Forms.Label();
            this.z_lstBox = new System.Windows.Forms.CheckedListBox();
            this.chargeAll_Btn = new System.Windows.Forms.Button();
            this.machine_Label = new System.Windows.Forms.Label();
            this.calc_Btn = new System.Windows.Forms.Button();
            this.y_lstBox = new System.Windows.Forms.CheckedListBox();
            this.mz_Label = new System.Windows.Forms.Label();
            this.c_lstBox = new System.Windows.Forms.CheckedListBox();
            this.mzMax_Label = new System.Windows.Forms.Label();
            this.resolution_Box = new System.Windows.Forms.TextBox();
            this.mzMin_Label = new System.Windows.Forms.Label();
            this.x_lstBox = new System.Windows.Forms.CheckedListBox();
            this.mzMax_Box = new System.Windows.Forms.TextBox();
            this.resolution_Label = new System.Windows.Forms.Label();
            this.mzMin_Box = new System.Windows.Forms.TextBox();
            this.b_lstBox = new System.Windows.Forms.CheckedListBox();
            this.saveCalc_Btn = new System.Windows.Forms.Button();
            this.idxTo_Label = new System.Windows.Forms.Label();
            this.clearCalc_Btn = new System.Windows.Forms.Button();
            this.idxFrom_Label = new System.Windows.Forms.Label();
            this.chargeMax_Label = new System.Windows.Forms.Label();
            this.a_lstBox = new System.Windows.Forms.CheckedListBox();
            this.chargeMin_Label = new System.Windows.Forms.Label();
            this.idxTo_Box = new System.Windows.Forms.TextBox();
            this.chargeMin_Box = new System.Windows.Forms.TextBox();
            this.idxFrom_Box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.idxPr_Box = new System.Windows.Forms.TextBox();
            this.primary_Label = new System.Windows.Forms.Label();
            this.internal_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plotFragProf_chkBox = new System.Windows.Forms.CheckBox();
            this.plotFragCent_chkBox = new System.Windows.Forms.CheckBox();
            this.plotCentr_chkBox = new System.Windows.Forms.CheckBox();
            this.plotExp_chkBox = new System.Windows.Forms.CheckBox();
            this.clearListBtn1 = new System.Windows.Forms.Button();
            this.loadFit_Btn = new System.Windows.Forms.Button();
            this.loadListBtn1 = new System.Windows.Forms.Button();
            this.saveListBtn1 = new System.Windows.Forms.Button();
            this.mark_label = new System.Windows.Forms.Label();
            this.loadWd_Btn = new System.Windows.Forms.Button();
            this.saveWd_Btn = new System.Windows.Forms.Button();
            this.fitResults_lbl = new System.Windows.Forms.Label();
            this.remPlot_Btn = new System.Windows.Forms.Button();
            this.saveFit_Btn = new System.Windows.Forms.Button();
            this.plot_Btn = new System.Windows.Forms.Button();
            this.frag_listView = new System.Windows.Forms.ListView();
            this.ionTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mzHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formulaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.factorHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intensityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selFrag_Label = new System.Windows.Forms.Label();
            this.factor_label = new System.Windows.Forms.Label();
            this.factor_Box = new System.Windows.Forms.TextBox();
            this.tabDiagram = new System.Windows.Forms.TabPage();
            this.panel2_tab2 = new System.Windows.Forms.Panel();
            this.splitterTab1 = new System.Windows.Forms.Splitter();
            this.panel1_tab2 = new System.Windows.Forms.Panel();
            this.seq_Lbl = new System.Windows.Forms.Label();
            this.ax_chBx = new System.Windows.Forms.CheckBox();
            this.by_chBx = new System.Windows.Forms.CheckBox();
            this.cz_chBx = new System.Windows.Forms.CheckBox();
            this.intA_chBx = new System.Windows.Forms.CheckBox();
            this.intB_chBx = new System.Windows.Forms.CheckBox();
            this.sequence_Pnl = new System.Windows.Forms.Panel();
            this.draw_Btn = new System.Windows.Forms.Button();
            this.tabPrimary = new System.Windows.Forms.TabPage();
            this.panel2_tab3 = new System.Windows.Forms.Panel();
            this.czCharge_toolStrip = new System.Windows.Forms.ToolStrip();
            this.byCharge_toolStrip = new System.Windows.Forms.ToolStrip();
            this.axCharge_toolStrip = new System.Windows.Forms.ToolStrip();
            this.czCharge_Pnl = new System.Windows.Forms.Panel();
            this.byCharge_Pnl = new System.Windows.Forms.Panel();
            this.axCharge_Pnl = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1_tab3 = new System.Windows.Forms.Panel();
            this.by_toolStrip = new System.Windows.Forms.ToolStrip();
            this.cz_toolStrip = new System.Windows.Forms.ToolStrip();
            this.ax_toolStrip = new System.Windows.Forms.ToolStrip();
            this.ax_Pnl = new System.Windows.Forms.Panel();
            this.by_Pnl = new System.Windows.Forms.Panel();
            this.cz_Pnl = new System.Windows.Forms.Panel();
            this.tabInternal = new System.Windows.Forms.TabPage();
            this.panel2_intIdxTo = new System.Windows.Forms.Panel();
            this.idxPnl2 = new System.Windows.Forms.Panel();
            this.idxInt_Pnl2 = new System.Windows.Forms.Panel();
            this.panel1_intIdx = new System.Windows.Forms.Panel();
            this.idxPnl1 = new System.Windows.Forms.Panel();
            this.idxInt_Pnl1 = new System.Windows.Forms.Panel();
            this.int_IdxTo_toolStrip = new System.Windows.Forms.ToolStrip();
            this.int_Idx_toolStrip = new System.Windows.Forms.ToolStrip();
            this.idxPlotLbl = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.exportImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.copyImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.legend_chkBx = new System.Windows.Forms.ToolStripButton();
            this.cursor_chkBx = new System.Windows.Forms.ToolStripButton();
            this.saveListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.loadListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.clearListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.check_bestBtn = new System.Windows.Forms.ToolStripButton();
            this.uncheckFit_Btn = new System.Windows.Forms.ToolStripButton();
            this.sortSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.hide_Btn = new System.Windows.Forms.Button();
            this.show_Btn = new System.Windows.Forms.Button();
            this.czChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.c_Btn = new System.Windows.Forms.ToolStripButton();
            this.z_Btn = new System.Windows.Forms.ToolStripButton();
            this.byChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.byChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.b_Btn = new System.Windows.Forms.ToolStripButton();
            this.y_Btn = new System.Windows.Forms.ToolStripButton();
            this.axChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.a_Btn = new System.Windows.Forms.ToolStripButton();
            this.x_Btn = new System.Windows.Forms.ToolStripButton();
            this.bySave_Btn = new System.Windows.Forms.ToolStripButton();
            this.byCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.czSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.axSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxToSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxToCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.fitSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.Fitting_chkBox = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            customRes_Btn = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabFit.SuspendLayout();
            this.plots_grpBox.SuspendLayout();
            this.toolStrip_plot.SuspendLayout();
            this.user_grpBox.SuspendLayout();
            this.toolStrip_fragList.SuspendLayout();
            this.toolStrip_fit_sort.SuspendLayout();
            this.fitOptions_grpBox.SuspendLayout();
            this.panel_calc.SuspendLayout();
            this.tabDiagram.SuspendLayout();
            this.panel1_tab2.SuspendLayout();
            this.tabPrimary.SuspendLayout();
            this.panel2_tab3.SuspendLayout();
            this.czCharge_toolStrip.SuspendLayout();
            this.byCharge_toolStrip.SuspendLayout();
            this.axCharge_toolStrip.SuspendLayout();
            this.panel1_tab3.SuspendLayout();
            this.by_toolStrip.SuspendLayout();
            this.cz_toolStrip.SuspendLayout();
            this.ax_toolStrip.SuspendLayout();
            this.tabInternal.SuspendLayout();
            this.panel2_intIdxTo.SuspendLayout();
            this.panel1_intIdx.SuspendLayout();
            this.int_IdxTo_toolStrip.SuspendLayout();
            this.int_Idx_toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRes_Btn
            // 
            customRes_Btn.AutoSize = true;
            customRes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            customRes_Btn.ForeColor = System.Drawing.Color.SlateGray;
            customRes_Btn.Location = new System.Drawing.Point(207, 523);
            customRes_Btn.Name = "customRes_Btn";
            customRes_Btn.Size = new System.Drawing.Size(94, 13);
            customRes_Btn.TabIndex = 38;
            customRes_Btn.Text = "Custom Resolution";
            customRes_Btn.Click += new System.EventHandler(this.customRes_Btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFit);
            this.tabControl1.Controls.Add(this.tabDiagram);
            this.tabControl1.Controls.Add(this.tabPrimary);
            this.tabControl1.Controls.Add(this.tabInternal);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1515, 888);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFit
            // 
            this.tabFit.Controls.Add(this.plots_grpBox);
            this.tabFit.Controls.Add(this.user_grpBox);
            this.tabFit.Location = new System.Drawing.Point(4, 22);
            this.tabFit.Name = "tabFit";
            this.tabFit.Padding = new System.Windows.Forms.Padding(3);
            this.tabFit.Size = new System.Drawing.Size(1507, 862);
            this.tabFit.TabIndex = 1;
            this.tabFit.Text = "Fit";
            this.tabFit.UseVisualStyleBackColor = true;
            this.tabFit.Leave += new System.EventHandler(this.tabFit_Leave);
            // 
            // plots_grpBox
            // 
            this.plots_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plots_grpBox.Controls.Add(this.fit_grpBox);
            this.plots_grpBox.Controls.Add(this.toolStrip_plot);
            this.plots_grpBox.Controls.Add(this.res_grpBox);
            this.plots_grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plots_grpBox.Location = new System.Drawing.Point(3, 3);
            this.plots_grpBox.Name = "plots_grpBox";
            this.plots_grpBox.Size = new System.Drawing.Size(605, 856);
            this.plots_grpBox.TabIndex = 2;
            // 
            // fit_grpBox
            // 
            this.fit_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fit_grpBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.fit_grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fit_grpBox.Location = new System.Drawing.Point(0, 27);
            this.fit_grpBox.Name = "fit_grpBox";
            this.fit_grpBox.Size = new System.Drawing.Size(605, 562);
            this.fit_grpBox.TabIndex = 4;
            this.fit_grpBox.TabStop = false;
            // 
            // toolStrip_plot
            // 
            this.toolStrip_plot.BackColor = System.Drawing.Color.Lavender;
            this.toolStrip_plot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_plot.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_plot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImage_Btn,
            this.copyImage_Btn,
            this.legend_chkBx,
            this.cursor_chkBx});
            this.toolStrip_plot.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_plot.Name = "toolStrip_plot";
            this.toolStrip_plot.Size = new System.Drawing.Size(605, 27);
            this.toolStrip_plot.TabIndex = 3;
            this.toolStrip_plot.Text = "Graph Tools";
            // 
            // res_grpBox
            // 
            this.res_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.res_grpBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.res_grpBox.Location = new System.Drawing.Point(0, 589);
            this.res_grpBox.Name = "res_grpBox";
            this.res_grpBox.Size = new System.Drawing.Size(605, 267);
            this.res_grpBox.TabIndex = 1;
            this.res_grpBox.TabStop = false;
            // 
            // user_grpBox
            // 
            this.user_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.user_grpBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.user_grpBox.Controls.Add(this.fragStorage_Lbl);
            this.user_grpBox.Controls.Add(this.toolStrip_fragList);
            this.user_grpBox.Controls.Add(this.toolStrip_fit_sort);
            this.user_grpBox.Controls.Add(this.factor_panel);
            this.user_grpBox.Controls.Add(this.fragTypes_tree);
            this.user_grpBox.Controls.Add(this.frag_tree);
            this.user_grpBox.Controls.Add(this.fitOptions_grpBox);
            this.user_grpBox.Controls.Add(this.bigPanel);
            this.user_grpBox.Controls.Add(this.panel_calc);
            this.user_grpBox.Controls.Add(this.show_Btn);
            this.user_grpBox.Controls.Add(this.label3);
            this.user_grpBox.Controls.Add(this.label2);
            this.user_grpBox.Controls.Add(this.plotFragProf_chkBox);
            this.user_grpBox.Controls.Add(this.plotFragCent_chkBox);
            this.user_grpBox.Controls.Add(this.plotCentr_chkBox);
            this.user_grpBox.Controls.Add(this.plotExp_chkBox);
            this.user_grpBox.Controls.Add(this.clearListBtn1);
            this.user_grpBox.Controls.Add(this.loadFit_Btn);
            this.user_grpBox.Controls.Add(this.loadListBtn1);
            this.user_grpBox.Controls.Add(this.saveListBtn1);
            this.user_grpBox.Controls.Add(this.mark_label);
            this.user_grpBox.Controls.Add(this.loadWd_Btn);
            this.user_grpBox.Controls.Add(this.saveWd_Btn);
            this.user_grpBox.Controls.Add(this.fitResults_lbl);
            this.user_grpBox.Controls.Add(this.remPlot_Btn);
            this.user_grpBox.Controls.Add(this.saveFit_Btn);
            this.user_grpBox.Controls.Add(this.plot_Btn);
            this.user_grpBox.Controls.Add(this.frag_listView);
            this.user_grpBox.Controls.Add(this.selFrag_Label);
            this.user_grpBox.Controls.Add(this.factor_label);
            this.user_grpBox.Controls.Add(this.factor_Box);
            this.user_grpBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.user_grpBox.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_grpBox.Location = new System.Drawing.Point(608, 3);
            this.user_grpBox.Name = "user_grpBox";
            this.user_grpBox.Size = new System.Drawing.Size(896, 856);
            this.user_grpBox.TabIndex = 1;
            // 
            // fragStorage_Lbl
            // 
            this.fragStorage_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fragStorage_Lbl.AutoSize = true;
            this.fragStorage_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragStorage_Lbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.fragStorage_Lbl.Location = new System.Drawing.Point(555, 505);
            this.fragStorage_Lbl.Name = "fragStorage_Lbl";
            this.fragStorage_Lbl.Size = new System.Drawing.Size(155, 20);
            this.fragStorage_Lbl.TabIndex = 10000017;
            this.fragStorage_Lbl.Text = "Fragment Storage";
            this.toolTip1.SetToolTip(this.fragStorage_Lbl, "Select all fragments presented in the list");
            this.fragStorage_Lbl.Visible = false;
            // 
            // toolStrip_fragList
            // 
            this.toolStrip_fragList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip_fragList.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_fragList.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_fragList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fragList.ImageScalingSize = new System.Drawing.Size(27, 27);
            this.toolStrip_fragList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveListBtn11,
            this.loadListBtn11,
            this.clearListBtn11});
            this.toolStrip_fragList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_fragList.Location = new System.Drawing.Point(797, 42);
            this.toolStrip_fragList.Name = "toolStrip_fragList";
            this.toolStrip_fragList.Size = new System.Drawing.Size(96, 34);
            this.toolStrip_fragList.TabIndex = 10000014;
            // 
            // toolStrip_fit_sort
            // 
            this.toolStrip_fit_sort.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_fit_sort.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fit_sort.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_fit_sort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check_bestBtn,
            this.uncheckFit_Btn,
            this.sortSettings_Btn});
            this.toolStrip_fit_sort.Location = new System.Drawing.Point(97, 170);
            this.toolStrip_fit_sort.Name = "toolStrip_fit_sort";
            this.toolStrip_fit_sort.Size = new System.Drawing.Size(124, 27);
            this.toolStrip_fit_sort.TabIndex = 10000016;
            this.toolStrip_fit_sort.Text = "toolStrip1";
            // 
            // factor_panel
            // 
            this.factor_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.factor_panel.Location = new System.Drawing.Point(555, 459);
            this.factor_panel.Name = "factor_panel";
            this.factor_panel.Size = new System.Drawing.Size(337, 39);
            this.factor_panel.TabIndex = 10000013;
            // 
            // fragTypes_tree
            // 
            this.fragTypes_tree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fragTypes_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragTypes_tree.CheckBoxes = true;
            this.fragTypes_tree.Location = new System.Drawing.Point(555, 528);
            this.fragTypes_tree.Name = "fragTypes_tree";
            this.fragTypes_tree.Size = new System.Drawing.Size(337, 323);
            this.fragTypes_tree.TabIndex = 10000012;
            this.fragTypes_tree.Visible = false;
            // 
            // frag_tree
            // 
            this.frag_tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frag_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frag_tree.CheckBoxes = true;
            this.frag_tree.Location = new System.Drawing.Point(555, 76);
            this.frag_tree.Name = "frag_tree";
            this.frag_tree.Size = new System.Drawing.Size(337, 381);
            this.frag_tree.TabIndex = 10000011;
            this.frag_tree.Visible = false;
            // 
            // fitOptions_grpBox
            // 
            this.fitOptions_grpBox.Controls.Add(this.toolStrip1);
            this.fitOptions_grpBox.Controls.Add(this.fit_Btn);
            this.fitOptions_grpBox.Controls.Add(this.fit_sel_Btn);
            this.fitOptions_grpBox.Controls.Add(this.fitMax_Label);
            this.fitOptions_grpBox.Controls.Add(this.fitMin_Label);
            this.fitOptions_grpBox.Controls.Add(this.fitMax_Box);
            this.fitOptions_grpBox.Controls.Add(this.fitMin_Box);
            this.fitOptions_grpBox.Controls.Add(this.stepRange_Lbl);
            this.fitOptions_grpBox.Controls.Add(this.step_rangeBox);
            this.fitOptions_grpBox.Controls.Add(this.fitStep_Box);
            this.fitOptions_grpBox.Controls.Add(this.fitStep_Label);
            this.fitOptions_grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitOptions_grpBox.ForeColor = System.Drawing.Color.Teal;
            this.fitOptions_grpBox.Location = new System.Drawing.Point(5, 56);
            this.fitOptions_grpBox.Name = "fitOptions_grpBox";
            this.fitOptions_grpBox.Size = new System.Drawing.Size(219, 96);
            this.fitOptions_grpBox.TabIndex = 3;
            this.fitOptions_grpBox.TabStop = false;
            this.fitOptions_grpBox.Text = "Fitting Options";
            // 
            // fit_sel_Btn
            // 
            this.fit_sel_Btn.BackColor = System.Drawing.Color.Teal;
            this.fit_sel_Btn.Enabled = false;
            this.fit_sel_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_sel_Btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.fit_sel_Btn.Location = new System.Drawing.Point(3, 69);
            this.fit_sel_Btn.Name = "fit_sel_Btn";
            this.fit_sel_Btn.Size = new System.Drawing.Size(104, 21);
            this.fit_sel_Btn.TabIndex = 47;
            this.fit_sel_Btn.Text = "Fit select";
            this.fit_sel_Btn.UseVisualStyleBackColor = false;
            this.fit_sel_Btn.Click += new System.EventHandler(this.fit_Btn_Click);
            // 
            // fit_Btn
            // 
            this.fit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fit_Btn.BackColor = System.Drawing.Color.Teal;
            this.fit_Btn.Enabled = false;
            this.fit_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.fit_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_Btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.fit_Btn.Location = new System.Drawing.Point(109, 69);
            this.fit_Btn.Name = "fit_Btn";
            this.fit_Btn.Size = new System.Drawing.Size(104, 21);
            this.fit_Btn.TabIndex = 39;
            this.fit_Btn.Text = "Auto fit";
            this.fit_Btn.UseVisualStyleBackColor = false;
            this.fit_Btn.Click += new System.EventHandler(this.fit_Btn_Click);
            // 
            // fitMax_Label
            // 
            this.fitMax_Label.AutoSize = true;
            this.fitMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMax_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fitMax_Label.Location = new System.Drawing.Point(72, 27);
            this.fitMax_Label.Name = "fitMax_Label";
            this.fitMax_Label.Size = new System.Drawing.Size(26, 13);
            this.fitMax_Label.TabIndex = 33;
            this.fitMax_Label.Text = "max";
            // 
            // fitMin_Label
            // 
            this.fitMin_Label.AutoSize = true;
            this.fitMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMin_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fitMin_Label.Location = new System.Drawing.Point(3, 27);
            this.fitMin_Label.Name = "fitMin_Label";
            this.fitMin_Label.Size = new System.Drawing.Size(23, 13);
            this.fitMin_Label.TabIndex = 34;
            this.fitMin_Label.Text = "min";
            // 
            // fitMax_Box
            // 
            this.fitMax_Box.Enabled = false;
            this.fitMax_Box.ForeColor = System.Drawing.Color.Black;
            this.fitMax_Box.Location = new System.Drawing.Point(72, 43);
            this.fitMax_Box.Name = "fitMax_Box";
            this.fitMax_Box.Size = new System.Drawing.Size(62, 20);
            this.fitMax_Box.TabIndex = 35;
            this.fitMax_Box.TextChanged += new System.EventHandler(this.FitMax_Box_TextChanged);
            // 
            // fitMin_Box
            // 
            this.fitMin_Box.Enabled = false;
            this.fitMin_Box.ForeColor = System.Drawing.Color.Black;
            this.fitMin_Box.Location = new System.Drawing.Point(3, 43);
            this.fitMin_Box.Name = "fitMin_Box";
            this.fitMin_Box.Size = new System.Drawing.Size(62, 20);
            this.fitMin_Box.TabIndex = 36;
            this.fitMin_Box.TextChanged += new System.EventHandler(this.FitMin_Box_TextChanged);
            // 
            // stepRange_Lbl
            // 
            this.stepRange_Lbl.AutoSize = true;
            this.stepRange_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepRange_Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stepRange_Lbl.Location = new System.Drawing.Point(70, 39);
            this.stepRange_Lbl.Name = "stepRange_Lbl";
            this.stepRange_Lbl.Size = new System.Drawing.Size(50, 13);
            this.stepRange_Lbl.TabIndex = 44;
            this.stepRange_Lbl.Text = "tolerance";
            this.stepRange_Lbl.Visible = false;
            // 
            // step_rangeBox
            // 
            this.step_rangeBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.step_rangeBox.ForeColor = System.Drawing.Color.Black;
            this.step_rangeBox.Location = new System.Drawing.Point(95, 46);
            this.step_rangeBox.Name = "step_rangeBox";
            this.step_rangeBox.Size = new System.Drawing.Size(13, 20);
            this.step_rangeBox.TabIndex = 43;
            this.step_rangeBox.Visible = false;
            this.step_rangeBox.TextChanged += new System.EventHandler(this.step_rangeBox_TextChanged);
            // 
            // fitStep_Box
            // 
            this.fitStep_Box.Enabled = false;
            this.fitStep_Box.ForeColor = System.Drawing.Color.Black;
            this.fitStep_Box.Location = new System.Drawing.Point(53, 45);
            this.fitStep_Box.Name = "fitStep_Box";
            this.fitStep_Box.Size = new System.Drawing.Size(13, 20);
            this.fitStep_Box.TabIndex = 38;
            this.fitStep_Box.Visible = false;
            this.fitStep_Box.TextChanged += new System.EventHandler(this.FitStep_Box_TextChanged);
            // 
            // fitStep_Label
            // 
            this.fitStep_Label.AutoSize = true;
            this.fitStep_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitStep_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fitStep_Label.Location = new System.Drawing.Point(47, 38);
            this.fitStep_Label.Name = "fitStep_Label";
            this.fitStep_Label.Size = new System.Drawing.Size(27, 13);
            this.fitStep_Label.TabIndex = 37;
            this.fitStep_Label.Text = "step";
            this.fitStep_Label.Visible = false;
            // 
            // bigPanel
            // 
            this.bigPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bigPanel.AutoScroll = true;
            this.bigPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bigPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bigPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bigPanel.Location = new System.Drawing.Point(7, 197);
            this.bigPanel.MinimumSize = new System.Drawing.Size(217, 217);
            this.bigPanel.Name = "bigPanel";
            this.bigPanel.Size = new System.Drawing.Size(217, 654);
            this.bigPanel.TabIndex = 10000000;
            this.bigPanel.WrapContents = false;
            // 
            // panel_calc
            // 
            this.panel_calc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_calc.AutoScroll = true;
            this.panel_calc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_calc.BackColor = System.Drawing.Color.Transparent;
            this.panel_calc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_calc.Controls.Add(this.new_Btn);
            this.panel_calc.Controls.Add(this.hide_Btn);
            this.panel_calc.Controls.Add(this.displayPeakList_btn);
            this.panel_calc.Controls.Add(this.optionBtn);
            this.panel_calc.Controls.Add(customRes_Btn);
            this.panel_calc.Controls.Add(this.loadExp_Btn);
            this.panel_calc.Controls.Add(this.chargeMax_Box);
            this.panel_calc.Controls.Add(this.pep_Label);
            this.panel_calc.Controls.Add(this.internal_lstBox);
            this.panel_calc.Controls.Add(this.loadMS_Btn);
            this.panel_calc.Controls.Add(this.addin_lstBox);
            this.panel_calc.Controls.Add(this.pep_Box);
            this.panel_calc.Controls.Add(this.machine_listBox);
            this.panel_calc.Controls.Add(this.frag_Label);
            this.panel_calc.Controls.Add(this.Mdvw_lstBox);
            this.panel_calc.Controls.Add(this.charge_Label);
            this.panel_calc.Controls.Add(this.z_lstBox);
            this.panel_calc.Controls.Add(this.chargeAll_Btn);
            this.panel_calc.Controls.Add(this.machine_Label);
            this.panel_calc.Controls.Add(this.calc_Btn);
            this.panel_calc.Controls.Add(this.y_lstBox);
            this.panel_calc.Controls.Add(this.mz_Label);
            this.panel_calc.Controls.Add(this.c_lstBox);
            this.panel_calc.Controls.Add(this.mzMax_Label);
            this.panel_calc.Controls.Add(this.resolution_Box);
            this.panel_calc.Controls.Add(this.mzMin_Label);
            this.panel_calc.Controls.Add(this.x_lstBox);
            this.panel_calc.Controls.Add(this.mzMax_Box);
            this.panel_calc.Controls.Add(this.resolution_Label);
            this.panel_calc.Controls.Add(this.mzMin_Box);
            this.panel_calc.Controls.Add(this.b_lstBox);
            this.panel_calc.Controls.Add(this.saveCalc_Btn);
            this.panel_calc.Controls.Add(this.idxTo_Label);
            this.panel_calc.Controls.Add(this.clearCalc_Btn);
            this.panel_calc.Controls.Add(this.idxFrom_Label);
            this.panel_calc.Controls.Add(this.chargeMax_Label);
            this.panel_calc.Controls.Add(this.a_lstBox);
            this.panel_calc.Controls.Add(this.chargeMin_Label);
            this.panel_calc.Controls.Add(this.idxTo_Box);
            this.panel_calc.Controls.Add(this.chargeMin_Box);
            this.panel_calc.Controls.Add(this.idxFrom_Box);
            this.panel_calc.Controls.Add(this.label7);
            this.panel_calc.Controls.Add(this.idxPr_Box);
            this.panel_calc.Controls.Add(this.primary_Label);
            this.panel_calc.Controls.Add(this.internal_Label);
            this.panel_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_calc.Location = new System.Drawing.Point(231, 14);
            this.panel_calc.MaximumSize = new System.Drawing.Size(318, 665);
            this.panel_calc.MinimumSize = new System.Drawing.Size(318, 656);
            this.panel_calc.Name = "panel_calc";
            this.panel_calc.Size = new System.Drawing.Size(318, 665);
            this.panel_calc.TabIndex = 0;
            // 
            // new_Btn
            // 
            this.new_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.new_Btn.BackColor = System.Drawing.Color.White;
            this.new_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.new_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_Btn.ForeColor = System.Drawing.Color.SteelBlue;
            this.new_Btn.Location = new System.Drawing.Point(225, 2);
            this.new_Btn.Name = "new_Btn";
            this.new_Btn.Size = new System.Drawing.Size(46, 38);
            this.new_Btn.TabIndex = 41;
            this.new_Btn.Text = "New";
            this.toolTip1.SetToolTip(this.new_Btn, "Delete all and create new project");
            this.new_Btn.UseVisualStyleBackColor = false;
            this.new_Btn.Click += new System.EventHandler(this.new_Btn_Click);
            // 
            // displayPeakList_btn
            // 
            this.displayPeakList_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayPeakList_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.displayPeakList_btn.Enabled = false;
            this.displayPeakList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.displayPeakList_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPeakList_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.displayPeakList_btn.Location = new System.Drawing.Point(175, 2);
            this.displayPeakList_btn.Name = "displayPeakList_btn";
            this.displayPeakList_btn.Size = new System.Drawing.Size(46, 38);
            this.displayPeakList_btn.TabIndex = 40;
            this.displayPeakList_btn.Text = "peak list";
            this.displayPeakList_btn.UseVisualStyleBackColor = false;
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.optionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Thistle;
            this.optionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionBtn.Location = new System.Drawing.Point(72, 623);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(119, 23);
            this.optionBtn.TabIndex = 39;
            this.optionBtn.Text = "Calculation Settings";
            this.optionBtn.UseVisualStyleBackColor = false;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // loadExp_Btn
            // 
            this.loadExp_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadExp_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.loadExp_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadExp_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadExp_Btn.ForeColor = System.Drawing.Color.White;
            this.loadExp_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadExp_Btn.Location = new System.Drawing.Point(5, 2);
            this.loadExp_Btn.Name = "loadExp_Btn";
            this.loadExp_Btn.Size = new System.Drawing.Size(90, 38);
            this.loadExp_Btn.TabIndex = 37;
            this.loadExp_Btn.Text = "Load Experimental";
            this.loadExp_Btn.UseVisualStyleBackColor = false;
            this.loadExp_Btn.Click += new System.EventHandler(this.loadExp_Btn_Click);
            // 
            // chargeMax_Box
            // 
            this.chargeMax_Box.Enabled = false;
            this.chargeMax_Box.ForeColor = System.Drawing.Color.Black;
            this.chargeMax_Box.Location = new System.Drawing.Point(54, 417);
            this.chargeMax_Box.Name = "chargeMax_Box";
            this.chargeMax_Box.Size = new System.Drawing.Size(38, 20);
            this.chargeMax_Box.TabIndex = 23;
            this.chargeMax_Box.TextChanged += new System.EventHandler(this.ChargeMax_Box_TextChanged);
            // 
            // pep_Label
            // 
            this.pep_Label.AutoSize = true;
            this.pep_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pep_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.pep_Label.Location = new System.Drawing.Point(0, 6);
            this.pep_Label.Name = "pep_Label";
            this.pep_Label.Size = new System.Drawing.Size(95, 13);
            this.pep_Label.TabIndex = 0;
            this.pep_Label.Text = "Peptide Sequence";
            this.pep_Label.Visible = false;
            // 
            // internal_lstBox
            // 
            this.internal_lstBox.CheckOnClick = true;
            this.internal_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.internal_lstBox.FormattingEnabled = true;
            this.internal_lstBox.Items.AddRange(new object[] {
            "internal a",
            "internal a-H2O",
            "internal a-NH3",
            "internal a-2H2O",
            "internal a-2NH3",
            "internal a-H2O-NH3",
            "internal b",
            "internal b-H2O",
            "internal b-NH3",
            "internal b-2H2O",
            "internal b-2NH3",
            "internal b-H2O-NH3"});
            this.internal_lstBox.Location = new System.Drawing.Point(181, 67);
            this.internal_lstBox.Name = "internal_lstBox";
            this.internal_lstBox.Size = new System.Drawing.Size(120, 184);
            this.internal_lstBox.TabIndex = 5;
            // 
            // loadMS_Btn
            // 
            this.loadMS_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadMS_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.loadMS_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadMS_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadMS_Btn.ForeColor = System.Drawing.Color.White;
            this.loadMS_Btn.Location = new System.Drawing.Point(99, 2);
            this.loadMS_Btn.Name = "loadMS_Btn";
            this.loadMS_Btn.Size = new System.Drawing.Size(72, 38);
            this.loadMS_Btn.TabIndex = 1;
            this.loadMS_Btn.Text = "Load Frag.List";
            this.loadMS_Btn.UseVisualStyleBackColor = false;
            this.loadMS_Btn.Click += new System.EventHandler(this.LoadMS_Btn_Click);
            // 
            // addin_lstBox
            // 
            this.addin_lstBox.CheckOnClick = true;
            this.addin_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.addin_lstBox.FormattingEnabled = true;
            this.addin_lstBox.Items.AddRange(new object[] {
            "a-NH3",
            "b-NH3",
            "b-H2O",
            "b+H2O",
            "y-NH3",
            "y-H2O",
            "b-2NH3",
            "b-2H2O",
            "y-2NH3",
            "y-2H2O",
            "b-H2O-NH3",
            "y-H2O-NH3"});
            this.addin_lstBox.Location = new System.Drawing.Point(181, 257);
            this.addin_lstBox.Name = "addin_lstBox";
            this.addin_lstBox.Size = new System.Drawing.Size(120, 184);
            this.addin_lstBox.TabIndex = 10;
            // 
            // pep_Box
            // 
            this.pep_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pep_Box.Location = new System.Drawing.Point(3, 24);
            this.pep_Box.Name = "pep_Box";
            this.pep_Box.Size = new System.Drawing.Size(226, 20);
            this.pep_Box.TabIndex = 3;
            this.pep_Box.Visible = false;
            // 
            // machine_listBox
            // 
            this.machine_listBox.Enabled = false;
            this.machine_listBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.machine_listBox.FormattingEnabled = true;
            this.machine_listBox.Items.AddRange(new object[] {
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
            this.machine_listBox.Location = new System.Drawing.Point(96, 542);
            this.machine_listBox.Name = "machine_listBox";
            this.machine_listBox.Size = new System.Drawing.Size(206, 56);
            this.machine_listBox.TabIndex = 36;
            this.machine_listBox.SelectedIndexChanged += new System.EventHandler(this.Machine_listBox_SelectedIndexChanged);
            // 
            // frag_Label
            // 
            this.frag_Label.AutoSize = true;
            this.frag_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frag_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.frag_Label.Location = new System.Drawing.Point(5, 46);
            this.frag_Label.Name = "frag_Label";
            this.frag_Label.Size = new System.Drawing.Size(56, 13);
            this.frag_Label.TabIndex = 5;
            this.frag_Label.Text = "Fragments";
            // 
            // Mdvw_lstBox
            // 
            this.Mdvw_lstBox.CheckOnClick = true;
            this.Mdvw_lstBox.ColumnWidth = 57;
            this.Mdvw_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Mdvw_lstBox.FormattingEnabled = true;
            this.Mdvw_lstBox.IntegralHeight = false;
            this.Mdvw_lstBox.Items.AddRange(new object[] {
            "M",
            "M-H2O",
            "M-NH3",
            "da",
            "wa",
            "db",
            "wb",
            "v"});
            this.Mdvw_lstBox.Location = new System.Drawing.Point(3, 248);
            this.Mdvw_lstBox.MultiColumn = true;
            this.Mdvw_lstBox.Name = "Mdvw_lstBox";
            this.Mdvw_lstBox.Size = new System.Drawing.Size(175, 60);
            this.Mdvw_lstBox.TabIndex = 9;
            // 
            // charge_Label
            // 
            this.charge_Label.AutoSize = true;
            this.charge_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charge_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.charge_Label.Location = new System.Drawing.Point(5, 379);
            this.charge_Label.Name = "charge_Label";
            this.charge_Label.Size = new System.Drawing.Size(41, 13);
            this.charge_Label.TabIndex = 6;
            this.charge_Label.Text = "Charge";
            // 
            // z_lstBox
            // 
            this.z_lstBox.CheckOnClick = true;
            this.z_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.z_lstBox.FormattingEnabled = true;
            this.z_lstBox.Items.AddRange(new object[] {
            "z",
            "z-1",
            "z-2",
            "z+1",
            "z+2"});
            this.z_lstBox.Location = new System.Drawing.Point(121, 159);
            this.z_lstBox.Name = "z_lstBox";
            this.z_lstBox.Size = new System.Drawing.Size(47, 79);
            this.z_lstBox.TabIndex = 8;
            // 
            // chargeAll_Btn
            // 
            this.chargeAll_Btn.BackColor = System.Drawing.Color.Gainsboro;
            this.chargeAll_Btn.Enabled = false;
            this.chargeAll_Btn.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.chargeAll_Btn.Location = new System.Drawing.Point(103, 415);
            this.chargeAll_Btn.Name = "chargeAll_Btn";
            this.chargeAll_Btn.Size = new System.Drawing.Size(37, 23);
            this.chargeAll_Btn.TabIndex = 8;
            this.chargeAll_Btn.Text = "All";
            this.chargeAll_Btn.UseVisualStyleBackColor = false;
            this.chargeAll_Btn.Click += new System.EventHandler(this.chargeAll_Btn_Click);
            // 
            // machine_Label
            // 
            this.machine_Label.AutoSize = true;
            this.machine_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machine_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.machine_Label.Location = new System.Drawing.Point(96, 523);
            this.machine_Label.Name = "machine_Label";
            this.machine_Label.Size = new System.Drawing.Size(48, 13);
            this.machine_Label.TabIndex = 35;
            this.machine_Label.Text = "Machine";
            // 
            // calc_Btn
            // 
            this.calc_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.calc_Btn.Enabled = false;
            this.calc_Btn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.calc_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calc_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calc_Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.calc_Btn.Location = new System.Drawing.Point(197, 623);
            this.calc_Btn.Name = "calc_Btn";
            this.calc_Btn.Size = new System.Drawing.Size(105, 23);
            this.calc_Btn.TabIndex = 10;
            this.calc_Btn.Text = "Calculate";
            this.calc_Btn.UseVisualStyleBackColor = false;
            this.calc_Btn.Click += new System.EventHandler(this.Calc_Btn_Click);
            // 
            // y_lstBox
            // 
            this.y_lstBox.CheckOnClick = true;
            this.y_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.y_lstBox.FormattingEnabled = true;
            this.y_lstBox.Items.AddRange(new object[] {
            "y",
            "y-1",
            "y+1"});
            this.y_lstBox.Location = new System.Drawing.Point(63, 159);
            this.y_lstBox.Name = "y_lstBox";
            this.y_lstBox.Size = new System.Drawing.Size(47, 49);
            this.y_lstBox.TabIndex = 7;
            // 
            // mz_Label
            // 
            this.mz_Label.AutoSize = true;
            this.mz_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mz_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.mz_Label.Location = new System.Drawing.Point(5, 314);
            this.mz_Label.Name = "mz_Label";
            this.mz_Label.Size = new System.Drawing.Size(81, 13);
            this.mz_Label.TabIndex = 11;
            this.mz_Label.Text = "M/z boundaries";
            // 
            // c_lstBox
            // 
            this.c_lstBox.CheckOnClick = true;
            this.c_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.c_lstBox.FormattingEnabled = true;
            this.c_lstBox.Items.AddRange(new object[] {
            "c",
            "c-1",
            "c-2",
            "c+1",
            "c+2"});
            this.c_lstBox.Location = new System.Drawing.Point(121, 67);
            this.c_lstBox.Name = "c_lstBox";
            this.c_lstBox.Size = new System.Drawing.Size(47, 79);
            this.c_lstBox.TabIndex = 4;
            // 
            // mzMax_Label
            // 
            this.mzMax_Label.AutoSize = true;
            this.mzMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mzMax_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.mzMax_Label.Location = new System.Drawing.Point(69, 332);
            this.mzMax_Label.Name = "mzMax_Label";
            this.mzMax_Label.Size = new System.Drawing.Size(26, 13);
            this.mzMax_Label.TabIndex = 12;
            this.mzMax_Label.Text = "max";
            this.mzMax_Label.Click += new System.EventHandler(this.mzMax_Label_Click);
            // 
            // resolution_Box
            // 
            this.resolution_Box.Enabled = false;
            this.resolution_Box.ForeColor = System.Drawing.Color.Black;
            this.resolution_Box.Location = new System.Drawing.Point(6, 542);
            this.resolution_Box.Name = "resolution_Box";
            this.resolution_Box.Size = new System.Drawing.Size(81, 20);
            this.resolution_Box.TabIndex = 34;
            this.resolution_Box.TextChanged += new System.EventHandler(this.Resolution_Box_TextChanged);
            // 
            // mzMin_Label
            // 
            this.mzMin_Label.AutoSize = true;
            this.mzMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mzMin_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.mzMin_Label.Location = new System.Drawing.Point(5, 332);
            this.mzMin_Label.Name = "mzMin_Label";
            this.mzMin_Label.Size = new System.Drawing.Size(23, 13);
            this.mzMin_Label.TabIndex = 13;
            this.mzMin_Label.Text = "min";
            this.mzMin_Label.Click += new System.EventHandler(this.mzMin_Label_Click);
            // 
            // x_lstBox
            // 
            this.x_lstBox.CheckOnClick = true;
            this.x_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.x_lstBox.FormattingEnabled = true;
            this.x_lstBox.Items.AddRange(new object[] {
            "x",
            "x-1",
            "x+1"});
            this.x_lstBox.Location = new System.Drawing.Point(5, 159);
            this.x_lstBox.Name = "x_lstBox";
            this.x_lstBox.Size = new System.Drawing.Size(47, 49);
            this.x_lstBox.TabIndex = 6;
            // 
            // mzMax_Box
            // 
            this.mzMax_Box.Enabled = false;
            this.mzMax_Box.ForeColor = System.Drawing.Color.Black;
            this.mzMax_Box.Location = new System.Drawing.Point(69, 348);
            this.mzMax_Box.Name = "mzMax_Box";
            this.mzMax_Box.Size = new System.Drawing.Size(56, 20);
            this.mzMax_Box.TabIndex = 14;
            this.mzMax_Box.Click += new System.EventHandler(this.mzMax_Box_Click);
            this.mzMax_Box.TextChanged += new System.EventHandler(this.MzMax_Box_TextChanged);
            // 
            // resolution_Label
            // 
            this.resolution_Label.AutoSize = true;
            this.resolution_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolution_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.resolution_Label.Location = new System.Drawing.Point(6, 523);
            this.resolution_Label.Name = "resolution_Label";
            this.resolution_Label.Size = new System.Drawing.Size(57, 13);
            this.resolution_Label.TabIndex = 33;
            this.resolution_Label.Text = "Resolution";
            // 
            // mzMin_Box
            // 
            this.mzMin_Box.Enabled = false;
            this.mzMin_Box.ForeColor = System.Drawing.Color.Black;
            this.mzMin_Box.Location = new System.Drawing.Point(5, 348);
            this.mzMin_Box.Name = "mzMin_Box";
            this.mzMin_Box.Size = new System.Drawing.Size(56, 20);
            this.mzMin_Box.TabIndex = 15;
            this.mzMin_Box.Click += new System.EventHandler(this.mzMin_Box_Click);
            this.mzMin_Box.TextChanged += new System.EventHandler(this.MzMin_Box_TextChanged);
            // 
            // b_lstBox
            // 
            this.b_lstBox.CheckOnClick = true;
            this.b_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.b_lstBox.FormattingEnabled = true;
            this.b_lstBox.Items.AddRange(new object[] {
            "b",
            "b-1",
            "b+1"});
            this.b_lstBox.Location = new System.Drawing.Point(63, 67);
            this.b_lstBox.Name = "b_lstBox";
            this.b_lstBox.Size = new System.Drawing.Size(47, 49);
            this.b_lstBox.TabIndex = 3;
            // 
            // saveCalc_Btn
            // 
            this.saveCalc_Btn.Enabled = false;
            this.saveCalc_Btn.Location = new System.Drawing.Point(9, 575);
            this.saveCalc_Btn.Name = "saveCalc_Btn";
            this.saveCalc_Btn.Size = new System.Drawing.Size(43, 23);
            this.saveCalc_Btn.TabIndex = 18;
            this.saveCalc_Btn.Text = "Save ";
            this.saveCalc_Btn.UseVisualStyleBackColor = true;
            this.saveCalc_Btn.Visible = false;
            this.saveCalc_Btn.Click += new System.EventHandler(this.SaveCalc_Btn_Click);
            // 
            // idxTo_Label
            // 
            this.idxTo_Label.AutoSize = true;
            this.idxTo_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxTo_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.idxTo_Label.Location = new System.Drawing.Point(251, 469);
            this.idxTo_Label.Name = "idxTo_Label";
            this.idxTo_Label.Size = new System.Drawing.Size(16, 13);
            this.idxTo_Label.TabIndex = 32;
            this.idxTo_Label.Text = "to";
            // 
            // clearCalc_Btn
            // 
            this.clearCalc_Btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clearCalc_Btn.Enabled = false;
            this.clearCalc_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearCalc_Btn.ForeColor = System.Drawing.Color.White;
            this.clearCalc_Btn.Location = new System.Drawing.Point(6, 623);
            this.clearCalc_Btn.Name = "clearCalc_Btn";
            this.clearCalc_Btn.Size = new System.Drawing.Size(60, 23);
            this.clearCalc_Btn.TabIndex = 19;
            this.clearCalc_Btn.Text = "Clear ";
            this.toolTip1.SetToolTip(this.clearCalc_Btn, "Clear calculation options");
            this.clearCalc_Btn.UseVisualStyleBackColor = false;
            this.clearCalc_Btn.Click += new System.EventHandler(this.ClearCalc_Btn_Click);
            // 
            // idxFrom_Label
            // 
            this.idxFrom_Label.AutoSize = true;
            this.idxFrom_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxFrom_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.idxFrom_Label.Location = new System.Drawing.Point(150, 469);
            this.idxFrom_Label.Name = "idxFrom_Label";
            this.idxFrom_Label.Size = new System.Drawing.Size(27, 13);
            this.idxFrom_Label.TabIndex = 31;
            this.idxFrom_Label.Text = "from";
            // 
            // chargeMax_Label
            // 
            this.chargeMax_Label.AutoSize = true;
            this.chargeMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeMax_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.chargeMax_Label.Location = new System.Drawing.Point(54, 400);
            this.chargeMax_Label.Name = "chargeMax_Label";
            this.chargeMax_Label.Size = new System.Drawing.Size(26, 13);
            this.chargeMax_Label.TabIndex = 21;
            this.chargeMax_Label.Text = "max";
            // 
            // a_lstBox
            // 
            this.a_lstBox.CheckOnClick = true;
            this.a_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.a_lstBox.FormattingEnabled = true;
            this.a_lstBox.Items.AddRange(new object[] {
            "a",
            "a-1",
            "a+1"});
            this.a_lstBox.Location = new System.Drawing.Point(5, 67);
            this.a_lstBox.Name = "a_lstBox";
            this.a_lstBox.Size = new System.Drawing.Size(47, 49);
            this.a_lstBox.TabIndex = 2;
            // 
            // chargeMin_Label
            // 
            this.chargeMin_Label.AutoSize = true;
            this.chargeMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeMin_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.chargeMin_Label.Location = new System.Drawing.Point(5, 400);
            this.chargeMin_Label.Name = "chargeMin_Label";
            this.chargeMin_Label.Size = new System.Drawing.Size(23, 13);
            this.chargeMin_Label.TabIndex = 22;
            this.chargeMin_Label.Text = "min";
            // 
            // idxTo_Box
            // 
            this.idxTo_Box.Enabled = false;
            this.idxTo_Box.ForeColor = System.Drawing.Color.Black;
            this.idxTo_Box.Location = new System.Drawing.Point(186, 485);
            this.idxTo_Box.Name = "idxTo_Box";
            this.idxTo_Box.Size = new System.Drawing.Size(81, 20);
            this.idxTo_Box.TabIndex = 30;
            this.idxTo_Box.TextChanged += new System.EventHandler(this.IdxTo_Box_TextChanged);
            // 
            // chargeMin_Box
            // 
            this.chargeMin_Box.Enabled = false;
            this.chargeMin_Box.ForeColor = System.Drawing.Color.Black;
            this.chargeMin_Box.Location = new System.Drawing.Point(5, 417);
            this.chargeMin_Box.Name = "chargeMin_Box";
            this.chargeMin_Box.Size = new System.Drawing.Size(38, 20);
            this.chargeMin_Box.TabIndex = 24;
            this.chargeMin_Box.TextChanged += new System.EventHandler(this.ChargeMin_Box_TextChanged);
            // 
            // idxFrom_Box
            // 
            this.idxFrom_Box.Enabled = false;
            this.idxFrom_Box.ForeColor = System.Drawing.Color.Black;
            this.idxFrom_Box.Location = new System.Drawing.Point(96, 485);
            this.idxFrom_Box.Name = "idxFrom_Box";
            this.idxFrom_Box.Size = new System.Drawing.Size(81, 20);
            this.idxFrom_Box.TabIndex = 29;
            this.idxFrom_Box.TextChanged += new System.EventHandler(this.IdxFrom_Box_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(5, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Index";
            // 
            // idxPr_Box
            // 
            this.idxPr_Box.Enabled = false;
            this.idxPr_Box.ForeColor = System.Drawing.Color.Black;
            this.idxPr_Box.Location = new System.Drawing.Point(5, 485);
            this.idxPr_Box.Name = "idxPr_Box";
            this.idxPr_Box.Size = new System.Drawing.Size(81, 20);
            this.idxPr_Box.TabIndex = 28;
            this.idxPr_Box.TextChanged += new System.EventHandler(this.IdxPr_Box_TextChanged);
            // 
            // primary_Label
            // 
            this.primary_Label.AutoSize = true;
            this.primary_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primary_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.primary_Label.Location = new System.Drawing.Point(5, 469);
            this.primary_Label.Name = "primary_Label";
            this.primary_Label.Size = new System.Drawing.Size(43, 13);
            this.primary_Label.TabIndex = 26;
            this.primary_Label.Text = "primary ";
            // 
            // internal_Label
            // 
            this.internal_Label.AutoSize = true;
            this.internal_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internal_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.internal_Label.Location = new System.Drawing.Point(96, 469);
            this.internal_Label.Name = "internal_Label";
            this.internal_Label.Size = new System.Drawing.Size(41, 13);
            this.internal_Label.TabIndex = 27;
            this.internal_Label.Text = "internal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 10000008;
            this.label3.Text = "Theor.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 10000007;
            this.label2.Text = "Exp. ";
            // 
            // plotFragProf_chkBox
            // 
            this.plotFragProf_chkBox.AutoSize = true;
            this.plotFragProf_chkBox.Enabled = false;
            this.plotFragProf_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragProf_chkBox.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragProf_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragProf_chkBox.Location = new System.Drawing.Point(63, 35);
            this.plotFragProf_chkBox.Name = "plotFragProf_chkBox";
            this.plotFragProf_chkBox.Size = new System.Drawing.Size(66, 18);
            this.plotFragProf_chkBox.TabIndex = 2;
            this.plotFragProf_chkBox.Text = "Profiles";
            this.plotFragProf_chkBox.UseVisualStyleBackColor = true;
            // 
            // plotFragCent_chkBox
            // 
            this.plotFragCent_chkBox.AutoSize = true;
            this.plotFragCent_chkBox.Enabled = false;
            this.plotFragCent_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragCent_chkBox.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragCent_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragCent_chkBox.Location = new System.Drawing.Point(143, 35);
            this.plotFragCent_chkBox.Name = "plotFragCent_chkBox";
            this.plotFragCent_chkBox.Size = new System.Drawing.Size(78, 18);
            this.plotFragCent_chkBox.TabIndex = 1;
            this.plotFragCent_chkBox.Text = "Centroids";
            this.plotFragCent_chkBox.UseVisualStyleBackColor = true;
            // 
            // plotCentr_chkBox
            // 
            this.plotCentr_chkBox.AutoSize = true;
            this.plotCentr_chkBox.Enabled = false;
            this.plotCentr_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotCentr_chkBox.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotCentr_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotCentr_chkBox.Location = new System.Drawing.Point(143, 17);
            this.plotCentr_chkBox.Name = "plotCentr_chkBox";
            this.plotCentr_chkBox.Size = new System.Drawing.Size(78, 18);
            this.plotCentr_chkBox.TabIndex = 0;
            this.plotCentr_chkBox.Text = "Centroids";
            this.plotCentr_chkBox.UseVisualStyleBackColor = true;
            // 
            // plotExp_chkBox
            // 
            this.plotExp_chkBox.AutoSize = true;
            this.plotExp_chkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plotExp_chkBox.Enabled = false;
            this.plotExp_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotExp_chkBox.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotExp_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotExp_chkBox.Location = new System.Drawing.Point(63, 17);
            this.plotExp_chkBox.Name = "plotExp_chkBox";
            this.plotExp_chkBox.Size = new System.Drawing.Size(78, 18);
            this.plotExp_chkBox.TabIndex = 0;
            this.plotExp_chkBox.Text = "Spectrum";
            this.plotExp_chkBox.UseVisualStyleBackColor = true;
            // 
            // clearListBtn1
            // 
            this.clearListBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearListBtn1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clearListBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.clearListBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearListBtn1.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearListBtn1.ForeColor = System.Drawing.Color.White;
            this.clearListBtn1.Location = new System.Drawing.Point(833, 3);
            this.clearListBtn1.Name = "clearListBtn1";
            this.clearListBtn1.Size = new System.Drawing.Size(60, 22);
            this.clearListBtn1.TabIndex = 10000006;
            this.clearListBtn1.Text = "Clear";
            this.toolTip1.SetToolTip(this.clearListBtn1, "Clear Fragment List , keep experimental data");
            this.clearListBtn1.UseVisualStyleBackColor = false;
            this.clearListBtn1.Visible = false;
            this.clearListBtn1.Click += new System.EventHandler(this.clearListBtn1_Click);
            // 
            // loadFit_Btn
            // 
            this.loadFit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadFit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFit_Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadFit_Btn.Location = new System.Drawing.Point(9, 611);
            this.loadFit_Btn.Name = "loadFit_Btn";
            this.loadFit_Btn.Size = new System.Drawing.Size(69, 27);
            this.loadFit_Btn.TabIndex = 40;
            this.loadFit_Btn.Text = "Load Fit";
            this.loadFit_Btn.UseVisualStyleBackColor = true;
            this.loadFit_Btn.Visible = false;
            this.loadFit_Btn.Click += new System.EventHandler(this.loadFit_Btn_Click);
            // 
            // loadListBtn1
            // 
            this.loadListBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadListBtn1.BackColor = System.Drawing.Color.SteelBlue;
            this.loadListBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.loadListBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadListBtn1.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadListBtn1.ForeColor = System.Drawing.Color.White;
            this.loadListBtn1.Location = new System.Drawing.Point(767, 3);
            this.loadListBtn1.Name = "loadListBtn1";
            this.loadListBtn1.Size = new System.Drawing.Size(60, 22);
            this.loadListBtn1.TabIndex = 10000005;
            this.loadListBtn1.Text = "Load";
            this.toolTip1.SetToolTip(this.loadListBtn1, "Load fragments from a \' .fit \' file");
            this.loadListBtn1.UseVisualStyleBackColor = false;
            this.loadListBtn1.Visible = false;
            this.loadListBtn1.Click += new System.EventHandler(this.loadListBtn1_Click);
            // 
            // saveListBtn1
            // 
            this.saveListBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveListBtn1.BackColor = System.Drawing.Color.CadetBlue;
            this.saveListBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.saveListBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveListBtn1.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveListBtn1.ForeColor = System.Drawing.Color.White;
            this.saveListBtn1.Location = new System.Drawing.Point(701, 3);
            this.saveListBtn1.Name = "saveListBtn1";
            this.saveListBtn1.Size = new System.Drawing.Size(60, 22);
            this.saveListBtn1.TabIndex = 10000004;
            this.saveListBtn1.Text = "Save";
            this.toolTip1.SetToolTip(this.saveListBtn1, "Save checked fragments");
            this.saveListBtn1.UseVisualStyleBackColor = false;
            this.saveListBtn1.Visible = false;
            this.saveListBtn1.Click += new System.EventHandler(this.saveListBtn1_Click);
            // 
            // mark_label
            // 
            this.mark_label.AutoSize = true;
            this.mark_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mark_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.mark_label.Location = new System.Drawing.Point(807, 16);
            this.mark_label.Name = "mark_label";
            this.mark_label.Size = new System.Drawing.Size(86, 13);
            this.mark_label.TabIndex = 47;
            this.mark_label.Text = "mark new entries";
            this.toolTip1.SetToolTip(this.mark_label, "Marks the new entries of the list");
            this.mark_label.Visible = false;
            this.mark_label.Click += new System.EventHandler(this.mark_label_Click);
            // 
            // loadWd_Btn
            // 
            this.loadWd_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadWd_Btn.Location = new System.Drawing.Point(115, 663);
            this.loadWd_Btn.Name = "loadWd_Btn";
            this.loadWd_Btn.Size = new System.Drawing.Size(103, 23);
            this.loadWd_Btn.TabIndex = 46;
            this.loadWd_Btn.Text = "Load window";
            this.loadWd_Btn.UseVisualStyleBackColor = true;
            this.loadWd_Btn.Visible = false;
            this.loadWd_Btn.Click += new System.EventHandler(this.loadWd_Btn_Click);
            // 
            // saveWd_Btn
            // 
            this.saveWd_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveWd_Btn.Enabled = false;
            this.saveWd_Btn.Location = new System.Drawing.Point(6, 663);
            this.saveWd_Btn.Name = "saveWd_Btn";
            this.saveWd_Btn.Size = new System.Drawing.Size(103, 23);
            this.saveWd_Btn.TabIndex = 45;
            this.saveWd_Btn.Text = "Save window";
            this.saveWd_Btn.UseVisualStyleBackColor = true;
            this.saveWd_Btn.Visible = false;
            this.saveWd_Btn.Click += new System.EventHandler(this.saveWd_Btn_Click);
            // 
            // fitResults_lbl
            // 
            this.fitResults_lbl.AutoSize = true;
            this.fitResults_lbl.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitResults_lbl.ForeColor = System.Drawing.Color.Teal;
            this.fitResults_lbl.Location = new System.Drawing.Point(7, 180);
            this.fitResults_lbl.Name = "fitResults_lbl";
            this.fitResults_lbl.Size = new System.Drawing.Size(63, 14);
            this.fitResults_lbl.TabIndex = 0;
            this.fitResults_lbl.Text = "Fit results";
            // 
            // remPlot_Btn
            // 
            this.remPlot_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remPlot_Btn.Location = new System.Drawing.Point(736, 798);
            this.remPlot_Btn.Name = "remPlot_Btn";
            this.remPlot_Btn.Size = new System.Drawing.Size(75, 23);
            this.remPlot_Btn.TabIndex = 43;
            this.remPlot_Btn.Text = "Remove";
            this.remPlot_Btn.UseVisualStyleBackColor = true;
            this.remPlot_Btn.Visible = false;
            this.remPlot_Btn.Click += new System.EventHandler(this.remPlot_Btn_Click);
            // 
            // saveFit_Btn
            // 
            this.saveFit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveFit_Btn.Enabled = false;
            this.saveFit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFit_Btn.Location = new System.Drawing.Point(7, 636);
            this.saveFit_Btn.Name = "saveFit_Btn";
            this.saveFit_Btn.Size = new System.Drawing.Size(211, 23);
            this.saveFit_Btn.TabIndex = 20;
            this.saveFit_Btn.Text = "Save Fit";
            this.saveFit_Btn.UseVisualStyleBackColor = true;
            this.saveFit_Btn.Visible = false;
            this.saveFit_Btn.Click += new System.EventHandler(this.saveFit_Btn_Click);
            // 
            // plot_Btn
            // 
            this.plot_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.plot_Btn.Location = new System.Drawing.Point(816, 798);
            this.plot_Btn.Name = "plot_Btn";
            this.plot_Btn.Size = new System.Drawing.Size(75, 23);
            this.plot_Btn.TabIndex = 42;
            this.plot_Btn.Text = "Plot";
            this.plot_Btn.UseVisualStyleBackColor = true;
            this.plot_Btn.Visible = false;
            this.plot_Btn.Click += new System.EventHandler(this.plot_Btn_Click);
            // 
            // frag_listView
            // 
            this.frag_listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.frag_listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frag_listView.CheckBoxes = true;
            this.frag_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ionTypeHeader,
            this.mzHeader,
            this.zHeader,
            this.formulaHeader,
            this.factorHeader,
            this.codeNoHeader,
            this.intensityHeader});
            this.frag_listView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frag_listView.FullRowSelect = true;
            this.frag_listView.GridLines = true;
            this.frag_listView.HideSelection = false;
            this.frag_listView.LabelEdit = true;
            this.frag_listView.Location = new System.Drawing.Point(559, 76);
            this.frag_listView.Name = "frag_listView";
            this.frag_listView.Size = new System.Drawing.Size(334, 381);
            this.frag_listView.TabIndex = 41;
            this.frag_listView.UseCompatibleStateImageBehavior = false;
            this.frag_listView.View = System.Windows.Forms.View.Details;
            this.frag_listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.frag_listView_ColumnClick);
            this.frag_listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.frag_listView_ItemChecked);
            this.frag_listView.SelectedIndexChanged += new System.EventHandler(this.frag_listView_SelectedIndexChanged);
            // 
            // ionTypeHeader
            // 
            this.ionTypeHeader.Text = "Ion Type";
            this.ionTypeHeader.Width = 58;
            // 
            // mzHeader
            // 
            this.mzHeader.Text = "m/z";
            // 
            // zHeader
            // 
            this.zHeader.Text = "z";
            this.zHeader.Width = 28;
            // 
            // formulaHeader
            // 
            this.formulaHeader.Text = "Elem. Formula";
            this.formulaHeader.Width = 109;
            // 
            // factorHeader
            // 
            this.factorHeader.Text = "Factor";
            this.factorHeader.Width = 42;
            // 
            // codeNoHeader
            // 
            this.codeNoHeader.Text = "No";
            this.codeNoHeader.Width = 30;
            // 
            // intensityHeader
            // 
            this.intensityHeader.Text = "Intensity";
            // 
            // selFrag_Label
            // 
            this.selFrag_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selFrag_Label.AutoSize = true;
            this.selFrag_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selFrag_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.selFrag_Label.Location = new System.Drawing.Point(555, 53);
            this.selFrag_Label.Name = "selFrag_Label";
            this.selFrag_Label.Size = new System.Drawing.Size(114, 20);
            this.selFrag_Label.TabIndex = 38;
            this.selFrag_Label.Text = "Fragment list";
            this.toolTip1.SetToolTip(this.selFrag_Label, "Select all fragments presented in the list");
            this.selFrag_Label.Click += new System.EventHandler(this.selFrag_Label_Click);
            // 
            // factor_label
            // 
            this.factor_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.factor_label.AutoSize = true;
            this.factor_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factor_label.Location = new System.Drawing.Point(551, 25);
            this.factor_label.Name = "factor_label";
            this.factor_label.Size = new System.Drawing.Size(37, 13);
            this.factor_label.TabIndex = 36;
            this.factor_label.Text = "Factor";
            this.toolTip1.SetToolTip(this.factor_label, "Change or view the factor of the selected fragment.");
            this.factor_label.Visible = false;
            // 
            // factor_Box
            // 
            this.factor_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.factor_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.factor_Box.Location = new System.Drawing.Point(609, 20);
            this.factor_Box.Name = "factor_Box";
            this.factor_Box.Size = new System.Drawing.Size(59, 21);
            this.factor_Box.TabIndex = 35;
            this.factor_Box.Visible = false;
            this.factor_Box.TextChanged += new System.EventHandler(this.factor_Box_TextChanged);
            this.factor_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.factor_Box_KeyDown);
            this.factor_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.factor_Box_KeyPress);
            // 
            // tabDiagram
            // 
            this.tabDiagram.Controls.Add(this.panel2_tab2);
            this.tabDiagram.Controls.Add(this.splitterTab1);
            this.tabDiagram.Controls.Add(this.panel1_tab2);
            this.tabDiagram.Location = new System.Drawing.Point(4, 22);
            this.tabDiagram.Name = "tabDiagram";
            this.tabDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagram.Size = new System.Drawing.Size(1507, 862);
            this.tabDiagram.TabIndex = 2;
            this.tabDiagram.Text = "Diagrams";
            this.tabDiagram.UseVisualStyleBackColor = true;
            // 
            // panel2_tab2
            // 
            this.panel2_tab2.AutoScroll = true;
            this.panel2_tab2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab2.Location = new System.Drawing.Point(847, 3);
            this.panel2_tab2.Name = "panel2_tab2";
            this.panel2_tab2.Size = new System.Drawing.Size(657, 856);
            this.panel2_tab2.TabIndex = 24;
            // 
            // splitterTab1
            // 
            this.splitterTab1.Location = new System.Drawing.Point(837, 3);
            this.splitterTab1.Margin = new System.Windows.Forms.Padding(0);
            this.splitterTab1.MinExtra = 1;
            this.splitterTab1.MinSize = 1;
            this.splitterTab1.Name = "splitterTab1";
            this.splitterTab1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitterTab1.Size = new System.Drawing.Size(10, 856);
            this.splitterTab1.TabIndex = 22;
            this.splitterTab1.TabStop = false;
            // 
            // panel1_tab2
            // 
            this.panel1_tab2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1_tab2.Controls.Add(this.seq_Lbl);
            this.panel1_tab2.Controls.Add(this.ax_chBx);
            this.panel1_tab2.Controls.Add(this.by_chBx);
            this.panel1_tab2.Controls.Add(this.cz_chBx);
            this.panel1_tab2.Controls.Add(this.intA_chBx);
            this.panel1_tab2.Controls.Add(this.intB_chBx);
            this.panel1_tab2.Controls.Add(this.sequence_Pnl);
            this.panel1_tab2.Controls.Add(this.draw_Btn);
            this.panel1_tab2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1_tab2.Location = new System.Drawing.Point(3, 3);
            this.panel1_tab2.Name = "panel1_tab2";
            this.panel1_tab2.Size = new System.Drawing.Size(834, 856);
            this.panel1_tab2.TabIndex = 21;
            // 
            // seq_Lbl
            // 
            this.seq_Lbl.AutoSize = true;
            this.seq_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_Lbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.seq_Lbl.Location = new System.Drawing.Point(6, 13);
            this.seq_Lbl.Name = "seq_Lbl";
            this.seq_Lbl.Size = new System.Drawing.Size(82, 20);
            this.seq_Lbl.TabIndex = 6;
            this.seq_Lbl.Text = "Sequence";
            // 
            // ax_chBx
            // 
            this.ax_chBx.AutoSize = true;
            this.ax_chBx.Location = new System.Drawing.Point(10, 37);
            this.ax_chBx.Name = "ax_chBx";
            this.ax_chBx.Size = new System.Drawing.Size(46, 17);
            this.ax_chBx.TabIndex = 0;
            this.ax_chBx.Text = "a - x";
            this.ax_chBx.UseVisualStyleBackColor = true;
            this.ax_chBx.CheckedChanged += new System.EventHandler(this.ax_chBx_CheckedChanged);
            // 
            // by_chBx
            // 
            this.by_chBx.AutoSize = true;
            this.by_chBx.Location = new System.Drawing.Point(10, 59);
            this.by_chBx.Name = "by_chBx";
            this.by_chBx.Size = new System.Drawing.Size(46, 17);
            this.by_chBx.TabIndex = 1;
            this.by_chBx.Text = "b - y";
            this.by_chBx.UseVisualStyleBackColor = true;
            this.by_chBx.CheckedChanged += new System.EventHandler(this.by_chBx_CheckedChanged);
            // 
            // cz_chBx
            // 
            this.cz_chBx.AutoSize = true;
            this.cz_chBx.Location = new System.Drawing.Point(10, 81);
            this.cz_chBx.Name = "cz_chBx";
            this.cz_chBx.Size = new System.Drawing.Size(46, 17);
            this.cz_chBx.TabIndex = 2;
            this.cz_chBx.Text = "c - z";
            this.cz_chBx.UseVisualStyleBackColor = true;
            this.cz_chBx.CheckedChanged += new System.EventHandler(this.cz_chBx_CheckedChanged);
            // 
            // intA_chBx
            // 
            this.intA_chBx.AutoSize = true;
            this.intA_chBx.Location = new System.Drawing.Point(10, 103);
            this.intA_chBx.Name = "intA_chBx";
            this.intA_chBx.Size = new System.Drawing.Size(69, 17);
            this.intA_chBx.TabIndex = 3;
            this.intA_chBx.Text = "internal a";
            this.intA_chBx.UseVisualStyleBackColor = true;
            // 
            // intB_chBx
            // 
            this.intB_chBx.AutoSize = true;
            this.intB_chBx.Location = new System.Drawing.Point(10, 125);
            this.intB_chBx.Name = "intB_chBx";
            this.intB_chBx.Size = new System.Drawing.Size(69, 17);
            this.intB_chBx.TabIndex = 4;
            this.intB_chBx.Text = "internal b";
            this.intB_chBx.UseVisualStyleBackColor = true;
            // 
            // sequence_Pnl
            // 
            this.sequence_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_Pnl.AutoScroll = true;
            this.sequence_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sequence_Pnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_Pnl.Location = new System.Drawing.Point(109, 37);
            this.sequence_Pnl.Name = "sequence_Pnl";
            this.sequence_Pnl.Size = new System.Drawing.Size(703, 298);
            this.sequence_Pnl.TabIndex = 7;
            this.sequence_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_Pnl_Paint);
            this.sequence_Pnl.Resize += new System.EventHandler(this.sequence_Pnl_Resize);
            // 
            // draw_Btn
            // 
            this.draw_Btn.BackColor = System.Drawing.Color.Teal;
            this.draw_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_Btn.Location = new System.Drawing.Point(10, 147);
            this.draw_Btn.Name = "draw_Btn";
            this.draw_Btn.Size = new System.Drawing.Size(69, 20);
            this.draw_Btn.TabIndex = 8;
            this.draw_Btn.Text = "Draw";
            this.draw_Btn.UseVisualStyleBackColor = false;
            this.draw_Btn.Click += new System.EventHandler(this.draw_Btn_Click);
            // 
            // tabPrimary
            // 
            this.tabPrimary.Controls.Add(this.panel2_tab3);
            this.tabPrimary.Controls.Add(this.splitter1);
            this.tabPrimary.Controls.Add(this.panel1_tab3);
            this.tabPrimary.Location = new System.Drawing.Point(4, 22);
            this.tabPrimary.Name = "tabPrimary";
            this.tabPrimary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrimary.Size = new System.Drawing.Size(1507, 862);
            this.tabPrimary.TabIndex = 3;
            this.tabPrimary.Text = "Primary Fragments";
            this.tabPrimary.UseVisualStyleBackColor = true;
            // 
            // panel2_tab3
            // 
            this.panel2_tab3.Controls.Add(this.czCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.byCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.axCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.czCharge_Pnl);
            this.panel2_tab3.Controls.Add(this.byCharge_Pnl);
            this.panel2_tab3.Controls.Add(this.axCharge_Pnl);
            this.panel2_tab3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab3.Location = new System.Drawing.Point(756, 3);
            this.panel2_tab3.Name = "panel2_tab3";
            this.panel2_tab3.Size = new System.Drawing.Size(748, 856);
            this.panel2_tab3.TabIndex = 26;
            // 
            // czCharge_toolStrip
            // 
            this.czCharge_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.czCharge_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.czCharge_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.czCharge_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.czCharge_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czChargeSave_Btn,
            this.czChargeCopy_Btn,
            this.c_Btn,
            this.z_Btn});
            this.czCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.czCharge_toolStrip.Location = new System.Drawing.Point(722, 530);
            this.czCharge_toolStrip.Name = "czCharge_toolStrip";
            this.czCharge_toolStrip.Size = new System.Drawing.Size(24, 106);
            this.czCharge_toolStrip.TabIndex = 24;
            // 
            // byCharge_toolStrip
            // 
            this.byCharge_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.byCharge_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.byCharge_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.byCharge_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.byCharge_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byChargeSave_Btn,
            this.byChargeCopy_Btn,
            this.b_Btn,
            this.y_Btn});
            this.byCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.byCharge_toolStrip.Location = new System.Drawing.Point(722, 267);
            this.byCharge_toolStrip.Name = "byCharge_toolStrip";
            this.byCharge_toolStrip.Size = new System.Drawing.Size(24, 106);
            this.byCharge_toolStrip.TabIndex = 25;
            // 
            // axCharge_toolStrip
            // 
            this.axCharge_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axCharge_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.axCharge_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.axCharge_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.axCharge_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axChargeSave_Btn,
            this.axChargeCopy_Btn,
            this.a_Btn,
            this.x_Btn});
            this.axCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.axCharge_toolStrip.Location = new System.Drawing.Point(722, 4);
            this.axCharge_toolStrip.Name = "axCharge_toolStrip";
            this.axCharge_toolStrip.Size = new System.Drawing.Size(24, 106);
            this.axCharge_toolStrip.TabIndex = 26;
            // 
            // czCharge_Pnl
            // 
            this.czCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.czCharge_Pnl.Location = new System.Drawing.Point(6, 530);
            this.czCharge_Pnl.Name = "czCharge_Pnl";
            this.czCharge_Pnl.Size = new System.Drawing.Size(713, 251);
            this.czCharge_Pnl.TabIndex = 29;
            // 
            // byCharge_Pnl
            // 
            this.byCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byCharge_Pnl.Location = new System.Drawing.Point(6, 267);
            this.byCharge_Pnl.Name = "byCharge_Pnl";
            this.byCharge_Pnl.Size = new System.Drawing.Size(713, 251);
            this.byCharge_Pnl.TabIndex = 28;
            // 
            // axCharge_Pnl
            // 
            this.axCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axCharge_Pnl.Location = new System.Drawing.Point(6, 4);
            this.axCharge_Pnl.Name = "axCharge_Pnl";
            this.axCharge_Pnl.Size = new System.Drawing.Size(713, 251);
            this.axCharge_Pnl.TabIndex = 27;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(746, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 856);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // panel1_tab3
            // 
            this.panel1_tab3.Controls.Add(this.by_toolStrip);
            this.panel1_tab3.Controls.Add(this.cz_toolStrip);
            this.panel1_tab3.Controls.Add(this.ax_toolStrip);
            this.panel1_tab3.Controls.Add(this.ax_Pnl);
            this.panel1_tab3.Controls.Add(this.by_Pnl);
            this.panel1_tab3.Controls.Add(this.cz_Pnl);
            this.panel1_tab3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1_tab3.Location = new System.Drawing.Point(3, 3);
            this.panel1_tab3.Name = "panel1_tab3";
            this.panel1_tab3.Size = new System.Drawing.Size(743, 856);
            this.panel1_tab3.TabIndex = 24;
            // 
            // by_toolStrip
            // 
            this.by_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.by_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.by_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.by_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bySave_Btn,
            this.byCopy_Btn});
            this.by_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.by_toolStrip.Location = new System.Drawing.Point(2, 263);
            this.by_toolStrip.Name = "by_toolStrip";
            this.by_toolStrip.Size = new System.Drawing.Size(24, 52);
            this.by_toolStrip.TabIndex = 26;
            // 
            // cz_toolStrip
            // 
            this.cz_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.cz_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.cz_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.cz_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czSave_Btn,
            this.czCopy_Btn});
            this.cz_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.cz_toolStrip.Location = new System.Drawing.Point(2, 526);
            this.cz_toolStrip.Name = "cz_toolStrip";
            this.cz_toolStrip.Size = new System.Drawing.Size(24, 52);
            this.cz_toolStrip.TabIndex = 25;
            // 
            // ax_toolStrip
            // 
            this.ax_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ax_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ax_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ax_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axSave_Btn,
            this.axCopy_Btn});
            this.ax_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ax_toolStrip.Location = new System.Drawing.Point(2, 0);
            this.ax_toolStrip.Name = "ax_toolStrip";
            this.ax_toolStrip.Size = new System.Drawing.Size(24, 52);
            this.ax_toolStrip.TabIndex = 24;
            // 
            // ax_Pnl
            // 
            this.ax_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ax_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ax_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ax_Pnl.Location = new System.Drawing.Point(29, 4);
            this.ax_Pnl.Name = "ax_Pnl";
            this.ax_Pnl.Size = new System.Drawing.Size(708, 251);
            this.ax_Pnl.TabIndex = 21;
            // 
            // by_Pnl
            // 
            this.by_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.by_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.by_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_Pnl.Location = new System.Drawing.Point(29, 267);
            this.by_Pnl.Name = "by_Pnl";
            this.by_Pnl.Size = new System.Drawing.Size(708, 251);
            this.by_Pnl.TabIndex = 22;
            // 
            // cz_Pnl
            // 
            this.cz_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cz_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cz_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cz_Pnl.Location = new System.Drawing.Point(29, 530);
            this.cz_Pnl.Name = "cz_Pnl";
            this.cz_Pnl.Size = new System.Drawing.Size(708, 251);
            this.cz_Pnl.TabIndex = 23;
            // 
            // tabInternal
            // 
            this.tabInternal.Controls.Add(this.panel2_intIdxTo);
            this.tabInternal.Controls.Add(this.panel1_intIdx);
            this.tabInternal.Controls.Add(this.int_IdxTo_toolStrip);
            this.tabInternal.Controls.Add(this.int_Idx_toolStrip);
            this.tabInternal.Controls.Add(this.idxPlotLbl);
            this.tabInternal.Location = new System.Drawing.Point(4, 22);
            this.tabInternal.Name = "tabInternal";
            this.tabInternal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternal.Size = new System.Drawing.Size(1507, 862);
            this.tabInternal.TabIndex = 4;
            this.tabInternal.Text = "Internal Fragments";
            this.tabInternal.UseVisualStyleBackColor = true;
            // 
            // panel2_intIdxTo
            // 
            this.panel2_intIdxTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2_intIdxTo.Controls.Add(this.idxPnl2);
            this.panel2_intIdxTo.Controls.Add(this.idxInt_Pnl2);
            this.panel2_intIdxTo.Location = new System.Drawing.Point(30, 412);
            this.panel2_intIdxTo.Name = "panel2_intIdxTo";
            this.panel2_intIdxTo.Size = new System.Drawing.Size(930, 350);
            this.panel2_intIdxTo.TabIndex = 28;
            // 
            // idxPnl2
            // 
            this.idxPnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl2.Location = new System.Drawing.Point(0, 0);
            this.idxPnl2.Name = "idxPnl2";
            this.idxPnl2.Size = new System.Drawing.Size(753, 350);
            this.idxPnl2.TabIndex = 27;
            // 
            // idxInt_Pnl2
            // 
            this.idxInt_Pnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl2.Location = new System.Drawing.Point(753, 0);
            this.idxInt_Pnl2.MinimumSize = new System.Drawing.Size(100, 251);
            this.idxInt_Pnl2.Name = "idxInt_Pnl2";
            this.idxInt_Pnl2.Size = new System.Drawing.Size(177, 350);
            this.idxInt_Pnl2.TabIndex = 26;
            // 
            // panel1_intIdx
            // 
            this.panel1_intIdx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1_intIdx.Controls.Add(this.idxPnl1);
            this.panel1_intIdx.Controls.Add(this.idxInt_Pnl1);
            this.panel1_intIdx.Location = new System.Drawing.Point(30, 56);
            this.panel1_intIdx.Name = "panel1_intIdx";
            this.panel1_intIdx.Size = new System.Drawing.Size(930, 350);
            this.panel1_intIdx.TabIndex = 27;
            // 
            // idxPnl1
            // 
            this.idxPnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl1.Location = new System.Drawing.Point(0, 0);
            this.idxPnl1.Name = "idxPnl1";
            this.idxPnl1.Size = new System.Drawing.Size(753, 350);
            this.idxPnl1.TabIndex = 26;
            // 
            // idxInt_Pnl1
            // 
            this.idxInt_Pnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl1.Location = new System.Drawing.Point(753, 0);
            this.idxInt_Pnl1.MinimumSize = new System.Drawing.Size(100, 251);
            this.idxInt_Pnl1.Name = "idxInt_Pnl1";
            this.idxInt_Pnl1.Size = new System.Drawing.Size(177, 350);
            this.idxInt_Pnl1.TabIndex = 25;
            // 
            // int_IdxTo_toolStrip
            // 
            this.int_IdxTo_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.int_IdxTo_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_IdxTo_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_IdxTo_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxToSave_Btn,
            this.int_IdxToCopy_Btn});
            this.int_IdxTo_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_IdxTo_toolStrip.Location = new System.Drawing.Point(3, 412);
            this.int_IdxTo_toolStrip.Name = "int_IdxTo_toolStrip";
            this.int_IdxTo_toolStrip.Size = new System.Drawing.Size(24, 52);
            this.int_IdxTo_toolStrip.TabIndex = 26;
            // 
            // int_Idx_toolStrip
            // 
            this.int_Idx_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.int_Idx_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_Idx_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_Idx_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxSave_Btn,
            this.int_IdxCopy_Btn});
            this.int_Idx_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_Idx_toolStrip.Location = new System.Drawing.Point(3, 56);
            this.int_Idx_toolStrip.Name = "int_Idx_toolStrip";
            this.int_Idx_toolStrip.Size = new System.Drawing.Size(24, 52);
            this.int_Idx_toolStrip.TabIndex = 25;
            // 
            // idxPlotLbl
            // 
            this.idxPlotLbl.AutoSize = true;
            this.idxPlotLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPlotLbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.idxPlotLbl.Location = new System.Drawing.Point(19, 23);
            this.idxPlotLbl.Name = "idxPlotLbl";
            this.idxPlotLbl.Size = new System.Drawing.Size(172, 20);
            this.idxPlotLbl.TabIndex = 20;
            this.idxPlotLbl.Text = "Internal fragments\' plot";
            // 
            // exportImage_Btn
            // 
            this.exportImage_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportImage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("exportImage_Btn.Image")));
            this.exportImage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportImage_Btn.Name = "exportImage_Btn";
            this.exportImage_Btn.Size = new System.Drawing.Size(24, 24);
            this.exportImage_Btn.ToolTipText = "Export Image";
            this.exportImage_Btn.Click += new System.EventHandler(this.exportImage_Btn_Click);
            // 
            // copyImage_Btn
            // 
            this.copyImage_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyImage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("copyImage_Btn.Image")));
            this.copyImage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyImage_Btn.Name = "copyImage_Btn";
            this.copyImage_Btn.Size = new System.Drawing.Size(24, 24);
            this.copyImage_Btn.ToolTipText = "Copy Image";
            this.copyImage_Btn.Click += new System.EventHandler(this.copyImage_Btn_Click);
            // 
            // legend_chkBx
            // 
            this.legend_chkBx.CheckOnClick = true;
            this.legend_chkBx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.legend_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("legend_chkBx.Image")));
            this.legend_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.legend_chkBx.Name = "legend_chkBx";
            this.legend_chkBx.Size = new System.Drawing.Size(24, 24);
            this.legend_chkBx.Text = "Show Legends";
            this.legend_chkBx.CheckedChanged += new System.EventHandler(this.legend_chkBx_CheckedChanged);
            // 
            // cursor_chkBx
            // 
            this.cursor_chkBx.CheckOnClick = true;
            this.cursor_chkBx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cursor_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("cursor_chkBx.Image")));
            this.cursor_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cursor_chkBx.Name = "cursor_chkBx";
            this.cursor_chkBx.Size = new System.Drawing.Size(24, 24);
            this.cursor_chkBx.Text = "Show Cursor";
            this.cursor_chkBx.Click += new System.EventHandler(this.cursor_chkBx_Click);
            // 
            // saveListBtn11
            // 
            this.saveListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("saveListBtn11.Image")));
            this.saveListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveListBtn11.Name = "saveListBtn11";
            this.saveListBtn11.Size = new System.Drawing.Size(31, 31);
            this.saveListBtn11.Text = "Save checked fragments";
            this.saveListBtn11.Click += new System.EventHandler(this.saveListBtn11_Click);
            // 
            // loadListBtn11
            // 
            this.loadListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("loadListBtn11.Image")));
            this.loadListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadListBtn11.Name = "loadListBtn11";
            this.loadListBtn11.Size = new System.Drawing.Size(31, 31);
            this.loadListBtn11.Text = "Load fragments from a \' .fit \' file";
            this.loadListBtn11.Click += new System.EventHandler(this.loadListBtn11_Click);
            // 
            // clearListBtn11
            // 
            this.clearListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("clearListBtn11.Image")));
            this.clearListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearListBtn11.Name = "clearListBtn11";
            this.clearListBtn11.Size = new System.Drawing.Size(31, 31);
            this.clearListBtn11.Text = "Clear Fragment List , keep experimental data";
            this.clearListBtn11.Click += new System.EventHandler(this.clearListBtn11_Click);
            // 
            // check_bestBtn
            // 
            this.check_bestBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.check_bestBtn.Image = ((System.Drawing.Image)(resources.GetObject("check_bestBtn.Image")));
            this.check_bestBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.check_bestBtn.Name = "check_bestBtn";
            this.check_bestBtn.Size = new System.Drawing.Size(24, 24);
            this.check_bestBtn.Text = "Select best fit";
            this.check_bestBtn.Click += new System.EventHandler(this.check_bestBtn_Click);
            // 
            // uncheckFit_Btn
            // 
            this.uncheckFit_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheckFit_Btn.Image = ((System.Drawing.Image)(resources.GetObject("uncheckFit_Btn.Image")));
            this.uncheckFit_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheckFit_Btn.Name = "uncheckFit_Btn";
            this.uncheckFit_Btn.Size = new System.Drawing.Size(24, 24);
            this.uncheckFit_Btn.Text = "Uncheck all";
            this.uncheckFit_Btn.Click += new System.EventHandler(this.uncheckFit_Btn_Click);
            // 
            // sortSettings_Btn
            // 
            this.sortSettings_Btn.Image = ((System.Drawing.Image)(resources.GetObject("sortSettings_Btn.Image")));
            this.sortSettings_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortSettings_Btn.Name = "sortSettings_Btn";
            this.sortSettings_Btn.Size = new System.Drawing.Size(73, 24);
            this.sortSettings_Btn.Text = "Settings";
            this.sortSettings_Btn.Click += new System.EventHandler(this.sortSettings_Btn_Click);
            // 
            // hide_Btn
            // 
            this.hide_Btn.BackColor = System.Drawing.Color.White;
            this.hide_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hide_Btn.BackgroundImage")));
            this.hide_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hide_Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.hide_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.hide_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hide_Btn.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hide_Btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hide_Btn.Location = new System.Drawing.Point(275, 4);
            this.hide_Btn.Name = "hide_Btn";
            this.hide_Btn.Size = new System.Drawing.Size(35, 31);
            this.hide_Btn.TabIndex = 10000010;
            this.toolTip1.SetToolTip(this.hide_Btn, "Hide calculation box");
            this.hide_Btn.UseVisualStyleBackColor = false;
            this.hide_Btn.Click += new System.EventHandler(this.hide_Btn_Click);
            // 
            // show_Btn
            // 
            this.show_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.show_Btn.BackColor = System.Drawing.Color.White;
            this.show_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("show_Btn.BackgroundImage")));
            this.show_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.show_Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.show_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_Btn.Location = new System.Drawing.Point(555, 20);
            this.show_Btn.Name = "show_Btn";
            this.show_Btn.Size = new System.Drawing.Size(35, 31);
            this.show_Btn.TabIndex = 10000010;
            this.toolTip1.SetToolTip(this.show_Btn, "Show calculation box");
            this.show_Btn.UseVisualStyleBackColor = false;
            this.show_Btn.Visible = false;
            this.show_Btn.Click += new System.EventHandler(this.show_Btn_Click);
            // 
            // czChargeSave_Btn
            // 
            this.czChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeSave_Btn.Image")));
            this.czChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeSave_Btn.Name = "czChargeSave_Btn";
            this.czChargeSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.czChargeSave_Btn.Text = "Save";
            // 
            // czChargeCopy_Btn
            // 
            this.czChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeCopy_Btn.Image")));
            this.czChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeCopy_Btn.Name = "czChargeCopy_Btn";
            this.czChargeCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.czChargeCopy_Btn.Text = "Copy";
            // 
            // c_Btn
            // 
            this.c_Btn.Checked = true;
            this.c_Btn.CheckOnClick = true;
            this.c_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.c_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.c_Btn.ForeColor = System.Drawing.Color.Firebrick;
            this.c_Btn.Image = ((System.Drawing.Image)(resources.GetObject("c_Btn.Image")));
            this.c_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c_Btn.Name = "c_Btn";
            this.c_Btn.Size = new System.Drawing.Size(22, 24);
            this.c_Btn.Text = "c";
            // 
            // z_Btn
            // 
            this.z_Btn.Checked = true;
            this.z_Btn.CheckOnClick = true;
            this.z_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.z_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.z_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.z_Btn.ForeColor = System.Drawing.Color.Tomato;
            this.z_Btn.Image = ((System.Drawing.Image)(resources.GetObject("z_Btn.Image")));
            this.z_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.z_Btn.Name = "z_Btn";
            this.z_Btn.Size = new System.Drawing.Size(22, 24);
            this.z_Btn.Text = "z";
            // 
            // byChargeSave_Btn
            // 
            this.byChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeSave_Btn.Image")));
            this.byChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeSave_Btn.Name = "byChargeSave_Btn";
            this.byChargeSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.byChargeSave_Btn.Text = "Save";
            // 
            // byChargeCopy_Btn
            // 
            this.byChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeCopy_Btn.Image")));
            this.byChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeCopy_Btn.Name = "byChargeCopy_Btn";
            this.byChargeCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.byChargeCopy_Btn.Text = "Copy";
            // 
            // b_Btn
            // 
            this.b_Btn.Checked = true;
            this.b_Btn.CheckOnClick = true;
            this.b_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.b_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.b_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.b_Btn.ForeColor = System.Drawing.Color.Blue;
            this.b_Btn.Image = ((System.Drawing.Image)(resources.GetObject("b_Btn.Image")));
            this.b_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_Btn.Name = "b_Btn";
            this.b_Btn.Size = new System.Drawing.Size(22, 24);
            this.b_Btn.Text = "b";
            // 
            // y_Btn
            // 
            this.y_Btn.Checked = true;
            this.y_Btn.CheckOnClick = true;
            this.y_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.y_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.y_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.y_Btn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.y_Btn.Image = ((System.Drawing.Image)(resources.GetObject("y_Btn.Image")));
            this.y_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.y_Btn.Name = "y_Btn";
            this.y_Btn.Size = new System.Drawing.Size(22, 24);
            this.y_Btn.Text = "y";
            // 
            // axChargeSave_Btn
            // 
            this.axChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeSave_Btn.Image")));
            this.axChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeSave_Btn.Name = "axChargeSave_Btn";
            this.axChargeSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.axChargeSave_Btn.Text = "Save";
            // 
            // axChargeCopy_Btn
            // 
            this.axChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeCopy_Btn.Image")));
            this.axChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeCopy_Btn.Name = "axChargeCopy_Btn";
            this.axChargeCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.axChargeCopy_Btn.Text = "Copy";
            // 
            // a_Btn
            // 
            this.a_Btn.Checked = true;
            this.a_Btn.CheckOnClick = true;
            this.a_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.a_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.a_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.a_Btn.ForeColor = System.Drawing.Color.Green;
            this.a_Btn.Image = ((System.Drawing.Image)(resources.GetObject("a_Btn.Image")));
            this.a_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.a_Btn.Name = "a_Btn";
            this.a_Btn.Size = new System.Drawing.Size(22, 24);
            this.a_Btn.Text = "a";
            // 
            // x_Btn
            // 
            this.x_Btn.Checked = true;
            this.x_Btn.CheckOnClick = true;
            this.x_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.x_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.x_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.x_Btn.ForeColor = System.Drawing.Color.Lime;
            this.x_Btn.Image = ((System.Drawing.Image)(resources.GetObject("x_Btn.Image")));
            this.x_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.x_Btn.Name = "x_Btn";
            this.x_Btn.Size = new System.Drawing.Size(22, 24);
            this.x_Btn.Text = "x";
            // 
            // bySave_Btn
            // 
            this.bySave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bySave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("bySave_Btn.Image")));
            this.bySave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bySave_Btn.Name = "bySave_Btn";
            this.bySave_Btn.Size = new System.Drawing.Size(22, 22);
            this.bySave_Btn.Text = "Save";
            // 
            // byCopy_Btn
            // 
            this.byCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byCopy_Btn.Image")));
            this.byCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byCopy_Btn.Name = "byCopy_Btn";
            this.byCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.byCopy_Btn.Text = "Copy";
            // 
            // czSave_Btn
            // 
            this.czSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czSave_Btn.Image")));
            this.czSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czSave_Btn.Name = "czSave_Btn";
            this.czSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.czSave_Btn.Text = "Save";
            // 
            // czCopy_Btn
            // 
            this.czCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czCopy_Btn.Image")));
            this.czCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czCopy_Btn.Name = "czCopy_Btn";
            this.czCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.czCopy_Btn.Text = "Copy";
            // 
            // axSave_Btn
            // 
            this.axSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axSave_Btn.Image")));
            this.axSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axSave_Btn.Name = "axSave_Btn";
            this.axSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.axSave_Btn.Text = "Save";
            // 
            // axCopy_Btn
            // 
            this.axCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axCopy_Btn.Image")));
            this.axCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axCopy_Btn.Name = "axCopy_Btn";
            this.axCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.axCopy_Btn.Text = "Copy";
            // 
            // int_IdxToSave_Btn
            // 
            this.int_IdxToSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToSave_Btn.Image")));
            this.int_IdxToSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToSave_Btn.Name = "int_IdxToSave_Btn";
            this.int_IdxToSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.int_IdxToSave_Btn.Text = "Save";
            // 
            // int_IdxToCopy_Btn
            // 
            this.int_IdxToCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToCopy_Btn.Image")));
            this.int_IdxToCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToCopy_Btn.Name = "int_IdxToCopy_Btn";
            this.int_IdxToCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.int_IdxToCopy_Btn.Text = "Copy";
            // 
            // int_IdxSave_Btn
            // 
            this.int_IdxSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxSave_Btn.Image")));
            this.int_IdxSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxSave_Btn.Name = "int_IdxSave_Btn";
            this.int_IdxSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.int_IdxSave_Btn.Text = "Save";
            // 
            // int_IdxCopy_Btn
            // 
            this.int_IdxCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxCopy_Btn.Image")));
            this.int_IdxCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxCopy_Btn.Name = "int_IdxCopy_Btn";
            this.int_IdxCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.int_IdxCopy_Btn.Text = "Copy";
            // 
            // fitSettings_Btn
            // 
            this.fitSettings_Btn.Image = ((System.Drawing.Image)(resources.GetObject("fitSettings_Btn.Image")));
            this.fitSettings_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitSettings_Btn.Name = "fitSettings_Btn";
            this.fitSettings_Btn.Size = new System.Drawing.Size(73, 24);
            this.fitSettings_Btn.Text = "Settings";
            this.fitSettings_Btn.Click += new System.EventHandler(this.fitSettings_Btn_Click);
            // 
            // Fitting_chkBox
            // 
            this.Fitting_chkBox.CheckOnClick = true;
            this.Fitting_chkBox.Image = ((System.Drawing.Image)(resources.GetObject("Fitting_chkBox.Image")));
            this.Fitting_chkBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Fitting_chkBox.Name = "Fitting_chkBox";
            this.Fitting_chkBox.Size = new System.Drawing.Size(66, 24);
            this.Fitting_chkBox.Text = "Plot fit";
            this.Fitting_chkBox.CheckedChanged += new System.EventHandler(this.Fitting_chkBox_CheckedChanged_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Fitting_chkBox,
            this.fitSettings_Btn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(141, 12);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(74, 73);
            this.toolStrip1.TabIndex = 48;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1515, 888);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1450, 850);
            this.Name = "Form2";
            this.Text = "Fragment fitting v11";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabFit.ResumeLayout(false);
            this.plots_grpBox.ResumeLayout(false);
            this.plots_grpBox.PerformLayout();
            this.toolStrip_plot.ResumeLayout(false);
            this.toolStrip_plot.PerformLayout();
            this.user_grpBox.ResumeLayout(false);
            this.user_grpBox.PerformLayout();
            this.toolStrip_fragList.ResumeLayout(false);
            this.toolStrip_fragList.PerformLayout();
            this.toolStrip_fit_sort.ResumeLayout(false);
            this.toolStrip_fit_sort.PerformLayout();
            this.fitOptions_grpBox.ResumeLayout(false);
            this.fitOptions_grpBox.PerformLayout();
            this.panel_calc.ResumeLayout(false);
            this.panel_calc.PerformLayout();
            this.tabDiagram.ResumeLayout(false);
            this.panel1_tab2.ResumeLayout(false);
            this.panel1_tab2.PerformLayout();
            this.tabPrimary.ResumeLayout(false);
            this.panel2_tab3.ResumeLayout(false);
            this.panel2_tab3.PerformLayout();
            this.czCharge_toolStrip.ResumeLayout(false);
            this.czCharge_toolStrip.PerformLayout();
            this.byCharge_toolStrip.ResumeLayout(false);
            this.byCharge_toolStrip.PerformLayout();
            this.axCharge_toolStrip.ResumeLayout(false);
            this.axCharge_toolStrip.PerformLayout();
            this.panel1_tab3.ResumeLayout(false);
            this.panel1_tab3.PerformLayout();
            this.by_toolStrip.ResumeLayout(false);
            this.by_toolStrip.PerformLayout();
            this.cz_toolStrip.ResumeLayout(false);
            this.cz_toolStrip.PerformLayout();
            this.ax_toolStrip.ResumeLayout(false);
            this.ax_toolStrip.PerformLayout();
            this.tabInternal.ResumeLayout(false);
            this.tabInternal.PerformLayout();
            this.panel2_intIdxTo.ResumeLayout(false);
            this.panel1_intIdx.ResumeLayout(false);
            this.int_IdxTo_toolStrip.ResumeLayout(false);
            this.int_IdxTo_toolStrip.PerformLayout();
            this.int_Idx_toolStrip.ResumeLayout(false);
            this.int_Idx_toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFit;
        private System.Windows.Forms.Panel user_grpBox;
        private System.Windows.Forms.GroupBox fitOptions_grpBox;
        private System.Windows.Forms.Button fit_Btn;
        private System.Windows.Forms.Button saveFit_Btn;
        private System.Windows.Forms.Label fitMax_Label;
        private System.Windows.Forms.Label fitMin_Label;
        private System.Windows.Forms.TextBox fitStep_Box;
        private System.Windows.Forms.TextBox fitMax_Box;
        private System.Windows.Forms.Label fitStep_Label;
        private System.Windows.Forms.TextBox fitMin_Box;
        private System.Windows.Forms.Label idxTo_Label;
        private System.Windows.Forms.Label idxFrom_Label;
        private System.Windows.Forms.TextBox idxTo_Box;
        private System.Windows.Forms.TextBox idxFrom_Box;
        private System.Windows.Forms.TextBox idxPr_Box;
        private System.Windows.Forms.Label internal_Label;
        private System.Windows.Forms.Label primary_Label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox chargeMin_Box;
        private System.Windows.Forms.TextBox chargeMax_Box;
        private System.Windows.Forms.Label chargeMin_Label;
        private System.Windows.Forms.Label chargeMax_Label;
        private System.Windows.Forms.Button clearCalc_Btn;
        private System.Windows.Forms.Button saveCalc_Btn;
        private System.Windows.Forms.TextBox mzMin_Box;
        private System.Windows.Forms.TextBox mzMax_Box;
        private System.Windows.Forms.Label mzMin_Label;
        private System.Windows.Forms.Label mzMax_Label;
        private System.Windows.Forms.Label mz_Label;
        private System.Windows.Forms.Button calc_Btn;
        private System.Windows.Forms.Button chargeAll_Btn;
        private System.Windows.Forms.Label charge_Label;
        private System.Windows.Forms.Label frag_Label;
        private System.Windows.Forms.TextBox pep_Box;
        private System.Windows.Forms.Button loadMS_Btn;
        private System.Windows.Forms.Label pep_Label;
        private System.Windows.Forms.ListBox machine_listBox;
        private System.Windows.Forms.Label machine_Label;
        private System.Windows.Forms.TextBox resolution_Box;
        private System.Windows.Forms.Label resolution_Label;
        private System.Windows.Forms.CheckedListBox addin_lstBox;
        private System.Windows.Forms.CheckedListBox Mdvw_lstBox;
        private System.Windows.Forms.CheckedListBox z_lstBox;
        private System.Windows.Forms.CheckedListBox y_lstBox;
        private System.Windows.Forms.CheckedListBox c_lstBox;
        private System.Windows.Forms.CheckedListBox x_lstBox;
        private System.Windows.Forms.CheckedListBox b_lstBox;
        private System.Windows.Forms.CheckedListBox a_lstBox;
        private System.Windows.Forms.CheckedListBox internal_lstBox;
        private System.Windows.Forms.Button new_Btn;
        private System.Windows.Forms.Button loadFit_Btn;
        private System.Windows.Forms.Button loadExp_Btn;
        private System.Windows.Forms.Label selFrag_Label;
        private System.Windows.Forms.Label factor_label;
        private System.Windows.Forms.TextBox factor_Box;
        private System.Windows.Forms.ListView frag_listView;
        private System.Windows.Forms.Button remPlot_Btn;
        private System.Windows.Forms.Button plot_Btn;
        private System.Windows.Forms.ColumnHeader ionTypeHeader;
        private System.Windows.Forms.ColumnHeader mzHeader;
        private System.Windows.Forms.ColumnHeader zHeader;
        private System.Windows.Forms.ColumnHeader formulaHeader;
        private System.Windows.Forms.Label stepRange_Lbl;
        private System.Windows.Forms.TextBox step_rangeBox;
        private System.Windows.Forms.FlowLayoutPanel bigPanel;
        private System.Windows.Forms.Label fitResults_lbl;
        private System.Windows.Forms.Panel panel_calc;
        private System.Windows.Forms.ColumnHeader codeNoHeader;
        private System.Windows.Forms.ColumnHeader factorHeader;
        private System.Windows.Forms.Button loadWd_Btn;
        private System.Windows.Forms.Button saveWd_Btn;
        private System.Windows.Forms.Button fit_sel_Btn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label mark_label;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.ColumnHeader intensityHeader;
        private System.Windows.Forms.Button displayPeakList_btn;
        private System.Windows.Forms.CheckBox plotExp_chkBox;
        private System.Windows.Forms.CheckBox plotCentr_chkBox;
        private System.Windows.Forms.Button clearListBtn1;
        private System.Windows.Forms.Button loadListBtn1;
        private System.Windows.Forms.Button saveListBtn1;
        private System.Windows.Forms.CheckBox plotFragCent_chkBox;
        private System.Windows.Forms.CheckBox plotFragProf_chkBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hide_Btn;
        private System.Windows.Forms.TabPage tabDiagram;
        private System.Windows.Forms.Button show_Btn;
        private System.Windows.Forms.CheckBox intB_chBx;
        private System.Windows.Forms.CheckBox intA_chBx;
        private System.Windows.Forms.CheckBox cz_chBx;
        private System.Windows.Forms.CheckBox by_chBx;
        private System.Windows.Forms.CheckBox ax_chBx;
        private System.Windows.Forms.Label seq_Lbl;
        private System.Windows.Forms.Panel sequence_Pnl;
        private System.Windows.Forms.Button draw_Btn;
        private System.Windows.Forms.Panel panel2_tab2;
        private System.Windows.Forms.Splitter splitterTab1;
        private System.Windows.Forms.Panel panel1_tab2;
        private System.Windows.Forms.Panel factor_panel;
        private System.Windows.Forms.TreeView fragTypes_tree;
        private System.Windows.Forms.TreeView frag_tree;
        private System.Windows.Forms.TabPage tabPrimary;
        private System.Windows.Forms.Panel plots_grpBox;
        private System.Windows.Forms.ToolStrip toolStrip_plot;
        private System.Windows.Forms.GroupBox res_grpBox;
        private System.Windows.Forms.GroupBox fit_grpBox;
        private System.Windows.Forms.ToolStripButton exportImage_Btn;
        private System.Windows.Forms.ToolStripButton copyImage_Btn;
        private System.Windows.Forms.ToolStripButton legend_chkBx;
        private System.Windows.Forms.ToolStripButton cursor_chkBx;
        private System.Windows.Forms.ToolStrip toolStrip_fragList;
        private System.Windows.Forms.ToolStripButton saveListBtn11;
        private System.Windows.Forms.ToolStripButton loadListBtn11;
        private System.Windows.Forms.ToolStripButton clearListBtn11;
        private System.Windows.Forms.TabPage tabInternal;
        private System.Windows.Forms.Label idxPlotLbl;
        private System.Windows.Forms.ToolStrip int_Idx_toolStrip;
        private System.Windows.Forms.ToolStripButton int_IdxSave_Btn;
        private System.Windows.Forms.ToolStripButton int_IdxCopy_Btn;
        private System.Windows.Forms.ToolStrip int_IdxTo_toolStrip;
        private System.Windows.Forms.ToolStripButton int_IdxToSave_Btn;
        private System.Windows.Forms.ToolStripButton int_IdxToCopy_Btn;
        private System.Windows.Forms.Panel panel2_intIdxTo;
        private System.Windows.Forms.Panel idxInt_Pnl2;
        private System.Windows.Forms.Panel panel1_intIdx;
        private System.Windows.Forms.Panel idxInt_Pnl1;
        private System.Windows.Forms.Panel idxPnl2;
        private System.Windows.Forms.Panel idxPnl1;
        private System.Windows.Forms.Panel panel2_tab3;
        private System.Windows.Forms.ToolStrip czCharge_toolStrip;
        private System.Windows.Forms.ToolStripButton czChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton czChargeCopy_Btn;
        private System.Windows.Forms.ToolStrip byCharge_toolStrip;
        private System.Windows.Forms.ToolStripButton byChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton byChargeCopy_Btn;
        private System.Windows.Forms.ToolStrip axCharge_toolStrip;
        private System.Windows.Forms.ToolStripButton axChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton axChargeCopy_Btn;
        private System.Windows.Forms.Panel czCharge_Pnl;
        private System.Windows.Forms.Panel byCharge_Pnl;
        private System.Windows.Forms.Panel axCharge_Pnl;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1_tab3;
        private System.Windows.Forms.ToolStrip by_toolStrip;
        private System.Windows.Forms.ToolStripButton bySave_Btn;
        private System.Windows.Forms.ToolStripButton byCopy_Btn;
        private System.Windows.Forms.ToolStrip cz_toolStrip;
        private System.Windows.Forms.ToolStripButton czSave_Btn;
        private System.Windows.Forms.ToolStripButton czCopy_Btn;
        private System.Windows.Forms.ToolStrip ax_toolStrip;
        private System.Windows.Forms.ToolStripButton axSave_Btn;
        private System.Windows.Forms.ToolStripButton axCopy_Btn;
        private System.Windows.Forms.Panel ax_Pnl;
        private System.Windows.Forms.Panel by_Pnl;
        private System.Windows.Forms.Panel cz_Pnl;
        private System.Windows.Forms.ToolStrip toolStrip_fit_sort;
        private System.Windows.Forms.ToolStripButton check_bestBtn;
        private System.Windows.Forms.ToolStripButton uncheckFit_Btn;
        private System.Windows.Forms.ToolStripButton sortSettings_Btn;
        private System.Windows.Forms.Label fragStorage_Lbl;
        private System.Windows.Forms.ToolStripButton c_Btn;
        private System.Windows.Forms.ToolStripButton z_Btn;
        private System.Windows.Forms.ToolStripButton b_Btn;
        private System.Windows.Forms.ToolStripButton y_Btn;
        private System.Windows.Forms.ToolStripButton a_Btn;
        private System.Windows.Forms.ToolStripButton x_Btn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton fitSettings_Btn;
        private System.Windows.Forms.ToolStripButton Fitting_chkBox;
    }
}