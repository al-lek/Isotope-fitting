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
            this.chartFormatBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.styleFormatBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.copyImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.legend_chkBx = new System.Windows.Forms.ToolStripButton();
            this.cursor_chkBx = new System.Windows.Forms.ToolStripButton();
            this.fragPlotLbl_chkBx = new System.Windows.Forms.ToolStripButton();
            this.autoscale_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.clear_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fragPlotLbl_chkBx2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSeparator();
            this.rel_res_chkBx = new System.Windows.Forms.ToolStripButton();
            this.disp_a = new System.Windows.Forms.ToolStripButton();
            this.disp_b = new System.Windows.Forms.ToolStripButton();
            this.disp_c = new System.Windows.Forms.ToolStripButton();
            this.disp_x = new System.Windows.Forms.ToolStripButton();
            this.disp_y = new System.Windows.Forms.ToolStripButton();
            this.disp_z = new System.Windows.Forms.ToolStripButton();
            this.disp_internal = new System.Windows.Forms.ToolStripButton();
            this.res_grpBox = new System.Windows.Forms.GroupBox();
            this.user_grpBox = new System.Windows.Forms.Panel();
            this.Fit_results_groupBox = new System.Windows.Forms.GroupBox();
            this.bigPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip_fit_sort = new System.Windows.Forms.ToolStrip();
            this.check_bestBtn = new System.Windows.Forms.ToolStripButton();
            this.uncheckFit_Btn = new System.Windows.Forms.ToolStripButton();
            this.sortSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.refresh_fitRes_Btn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel_calc = new System.Windows.Forms.Panel();
            this.dvw_lstBox = new System.Windows.Forms.CheckedListBox();
            this.hide_Btn = new System.Windows.Forms.Button();
            this.optionBtn = new System.Windows.Forms.Button();
            this.chargeMax_Box = new System.Windows.Forms.TextBox();
            this.internal_lstBox = new System.Windows.Forms.CheckedListBox();
            this.addin_lstBox = new System.Windows.Forms.CheckedListBox();
            this.machine_listBox = new System.Windows.Forms.ListBox();
            this.frag_Label = new System.Windows.Forms.Label();
            this.M_lstBox = new System.Windows.Forms.CheckedListBox();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.frag_listView = new System.Windows.Forms.ListView();
            this.ionTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mzHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formulaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.factorHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intensityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip_fragList = new System.Windows.Forms.ToolStrip();
            this.show_files_Btn = new System.Windows.Forms.ToolStripButton();
            this.statistics_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripSeparator();
            this.toggle_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uncheckall_Frag_Btn = new System.Windows.Forms.ToolStripButton();
            this.checkall_Frag_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.loadListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.saveListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.show_Btn = new System.Windows.Forms.Button();
            this.fragList_toolStrip = new System.Windows.Forms.ToolStrip();
            this.frag_sort_Btn1 = new System.Windows.Forms.ToolStripButton();
            this.refresh_frag_Btn1 = new System.Windows.Forms.ToolStripButton();
            this.fragCalc_Btn1 = new System.Windows.Forms.ToolStripButton();
            this.selFrag_Label = new System.Windows.Forms.Label();
            this.factor_panel = new System.Windows.Forms.Panel();
            this.fragStorage_Lbl = new System.Windows.Forms.Label();
            this.fragTypes_tree = new System.Windows.Forms.TreeView();
            this.remPlot_Btn = new System.Windows.Forms.Button();
            this.plot_Btn = new System.Windows.Forms.Button();
            this.theorData_grpBx = new System.Windows.Forms.GroupBox();
            this.seqBtn = new System.Windows.Forms.Button();
            this.loadFF_Btn = new System.Windows.Forms.Button();
            this.loadMS_Btn = new System.Windows.Forms.Button();
            this.peptide_textBox1 = new System.Windows.Forms.TextBox();
            this.plotFragProf_chkBox = new System.Windows.Forms.CheckBox();
            this.plotFragCent_chkBox = new System.Windows.Forms.CheckBox();
            this.expData_grpBx = new System.Windows.Forms.GroupBox();
            this.filename_txtBx = new System.Windows.Forms.TextBox();
            this.displayPeakList_btn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.settingsPeak_Btn = new System.Windows.Forms.ToolStripButton();
            this.plotCentr_chkBox = new System.Windows.Forms.CheckBox();
            this.plotExp_chkBox = new System.Windows.Forms.CheckBox();
            this.loadExp_Btn = new System.Windows.Forms.Button();
            this.fitMin_Label = new System.Windows.Forms.Label();
            this.fitMax_Box = new System.Windows.Forms.TextBox();
            this.fitMax_Label = new System.Windows.Forms.Label();
            this.fitMin_Box = new System.Windows.Forms.TextBox();
            this.fitOptions_grpBox = new System.Windows.Forms.GroupBox();
            this.fit_chkGrpsChkFragBtn = new System.Windows.Forms.Button();
            this.fit_chkGrpsBtn = new System.Windows.Forms.Button();
            this.fiToolStrip = new System.Windows.Forms.ToolStrip();
            this.Fitting_chkBox = new System.Windows.Forms.ToolStripButton();
            this.fitSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.fit_Btn = new System.Windows.Forms.Button();
            this.fit_sel_Btn = new System.Windows.Forms.Button();
            this.stepRange_Lbl = new System.Windows.Forms.Label();
            this.step_rangeBox = new System.Windows.Forms.TextBox();
            this.fitStep_Box = new System.Windows.Forms.TextBox();
            this.fitStep_Label = new System.Windows.Forms.Label();
            this.loadFit_Btn = new System.Windows.Forms.Button();
            this.loadWd_Btn = new System.Windows.Forms.Button();
            this.saveWd_Btn = new System.Windows.Forms.Button();
            this.saveFit_Btn = new System.Windows.Forms.Button();
            this.tabDiagram = new System.Windows.Forms.TabPage();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel2_tab2 = new System.Windows.Forms.Panel();
            this.ppm_toolStrip = new System.Windows.Forms.ToolStrip();
            this.ppmSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppmCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppm_extract_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.ppm_panel = new System.Windows.Forms.Panel();
            this.panel1_tab2 = new System.Windows.Forms.Panel();
            this.draw_sequence_panelCopy2 = new System.Windows.Forms.Panel();
            this.light_chkBoxCopy2 = new System.Windows.Forms.CheckBox();
            this.heavy_chkBoxCopy2 = new System.Windows.Forms.CheckBox();
            this.los_chkBoxCopy2 = new System.Windows.Forms.CheckBox();
            this.delele_sequencePnl2 = new System.Windows.Forms.Button();
            this.rdBtn50Copy2 = new System.Windows.Forms.RadioButton();
            this.rdBtn25Copy2 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStripCopy2 = new System.Windows.Forms.ToolStrip();
            this.seqSave_BtnCopy2 = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_BtnCopy2 = new System.Windows.Forms.ToolStripButton();
            this.seq_LblCopy2 = new System.Windows.Forms.Label();
            this.ax_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.by_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.cz_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.intA_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.intB_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.sequence_PnlCopy2 = new System.Windows.Forms.Panel();
            this.draw_BtnCopy2 = new System.Windows.Forms.Button();
            this.draw_sequence_panelCopy1 = new System.Windows.Forms.Panel();
            this.light_chkBoxCopy1 = new System.Windows.Forms.CheckBox();
            this.heavy_chkBoxCopy1 = new System.Windows.Forms.CheckBox();
            this.los_chkBoxCopy1 = new System.Windows.Forms.CheckBox();
            this.delele_sequencePnl1 = new System.Windows.Forms.Button();
            this.rdBtn50Copy1 = new System.Windows.Forms.RadioButton();
            this.rdBtn25Copy1 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStripCopy1 = new System.Windows.Forms.ToolStrip();
            this.seqSave_BtnCopy1 = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_BtnCopy1 = new System.Windows.Forms.ToolStripButton();
            this.seq_LblCopy1 = new System.Windows.Forms.Label();
            this.ax_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.by_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.cz_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.intA_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.intB_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.sequence_PnlCopy1 = new System.Windows.Forms.Panel();
            this.draw_BtnCopy1 = new System.Windows.Forms.Button();
            this.draw_sequence_panel = new System.Windows.Forms.Panel();
            this.light_chkBox = new System.Windows.Forms.CheckBox();
            this.heavy_chkBox = new System.Windows.Forms.CheckBox();
            this.los_chkBox = new System.Windows.Forms.CheckBox();
            this.add_sequencePanel1 = new System.Windows.Forms.Button();
            this.rdBtn50 = new System.Windows.Forms.RadioButton();
            this.rdBtn25 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStrip = new System.Windows.Forms.ToolStrip();
            this.seqSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.seq_coverageBtn = new System.Windows.Forms.ToolStripButton();
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
            this.czChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_Btn = new System.Windows.Forms.ToolStripButton();
            this.z_Btn = new System.Windows.Forms.ToolStripButton();
            this.czcharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.czcharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.byCharge_toolStrip = new System.Windows.Forms.ToolStrip();
            this.byChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.byChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripSplitButton();
            this.extractPlotToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.b_Btn = new System.Windows.Forms.ToolStripButton();
            this.y_Btn = new System.Windows.Forms.ToolStripButton();
            this.bycharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.bycharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.axCharge_toolStrip = new System.Windows.Forms.ToolStrip();
            this.axChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.form_primCharge_Btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.style_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.a_Btn = new System.Windows.Forms.ToolStripButton();
            this.x_Btn = new System.Windows.Forms.ToolStripButton();
            this.axcharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.axcharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.czCharge_Pnl = new System.Windows.Forms.Panel();
            this.byCharge_Pnl = new System.Windows.Forms.Panel();
            this.axCharge_Pnl = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1_tab3 = new System.Windows.Forms.Panel();
            this.by_toolStrip = new System.Windows.Forms.ToolStrip();
            this.byCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.bySave_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.by_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.by_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.cz_toolStrip = new System.Windows.Forms.ToolStrip();
            this.czSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cz_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.cz_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.ax_toolStrip = new System.Windows.Forms.ToolStrip();
            this.axSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.form_prim_Btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ax_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.ax_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.ax_Pnl = new System.Windows.Forms.Panel();
            this.by_Pnl = new System.Windows.Forms.Panel();
            this.cz_Pnl = new System.Windows.Forms.Panel();
            this.tabInternal = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1_intIdx = new System.Windows.Forms.Panel();
            this.idxPnl1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.idxInt_Pnl1 = new System.Windows.Forms.Panel();
            this.idxPlotLbl = new System.Windows.Forms.Label();
            this.int_Idx_toolStrip = new System.Windows.Forms.ToolStrip();
            this.int_IdxSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.styleToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.int_IdxTo_toolStrip = new System.Windows.Forms.ToolStrip();
            this.int_IdxToSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxToCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2_intIdxTo = new System.Windows.Forms.Panel();
            this.idxPnl2 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.idxInt_Pnl2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            customRes_Btn = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabFit.SuspendLayout();
            this.plots_grpBox.SuspendLayout();
            this.toolStrip_plot.SuspendLayout();
            this.user_grpBox.SuspendLayout();
            this.Fit_results_groupBox.SuspendLayout();
            this.toolStrip_fit_sort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel_calc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip_fragList.SuspendLayout();
            this.fragList_toolStrip.SuspendLayout();
            this.theorData_grpBx.SuspendLayout();
            this.expData_grpBx.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.fitOptions_grpBox.SuspendLayout();
            this.fiToolStrip.SuspendLayout();
            this.tabDiagram.SuspendLayout();
            this.panel2_tab2.SuspendLayout();
            this.ppm_toolStrip.SuspendLayout();
            this.panel1_tab2.SuspendLayout();
            this.draw_sequence_panelCopy2.SuspendLayout();
            this.sequence_toolStripCopy2.SuspendLayout();
            this.draw_sequence_panelCopy1.SuspendLayout();
            this.sequence_toolStripCopy1.SuspendLayout();
            this.draw_sequence_panel.SuspendLayout();
            this.sequence_toolStrip.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1_intIdx.SuspendLayout();
            this.int_Idx_toolStrip.SuspendLayout();
            this.int_IdxTo_toolStrip.SuspendLayout();
            this.panel2_intIdxTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // customRes_Btn
            // 
            customRes_Btn.AutoSize = true;
            customRes_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            customRes_Btn.ForeColor = System.Drawing.Color.SlateGray;
            customRes_Btn.Location = new System.Drawing.Point(192, 485);
            customRes_Btn.Name = "customRes_Btn";
            customRes_Btn.Size = new System.Drawing.Size(94, 13);
            customRes_Btn.TabIndex = 22;
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
            this.tabControl1.Size = new System.Drawing.Size(1370, 749);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFit
            // 
            this.tabFit.Controls.Add(this.plots_grpBox);
            this.tabFit.Controls.Add(this.user_grpBox);
            this.tabFit.Location = new System.Drawing.Point(4, 22);
            this.tabFit.Name = "tabFit";
            this.tabFit.Padding = new System.Windows.Forms.Padding(3);
            this.tabFit.Size = new System.Drawing.Size(1362, 723);
            this.tabFit.TabIndex = 1;
            this.tabFit.Text = "Fit";
            this.tabFit.UseVisualStyleBackColor = true;
            this.tabFit.Leave += new System.EventHandler(this.tabFit_Leave);
            // 
            // plots_grpBox
            // 
            this.plots_grpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plots_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plots_grpBox.Controls.Add(this.fit_grpBox);
            this.plots_grpBox.Controls.Add(this.toolStrip_plot);
            this.plots_grpBox.Controls.Add(this.res_grpBox);
            this.plots_grpBox.Location = new System.Drawing.Point(3, 3);
            this.plots_grpBox.Name = "plots_grpBox";
            this.plots_grpBox.Size = new System.Drawing.Size(458, 717);
            this.plots_grpBox.TabIndex = 2;
            // 
            // fit_grpBox
            // 
            this.fit_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fit_grpBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.fit_grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fit_grpBox.Location = new System.Drawing.Point(0, 27);
            this.fit_grpBox.Name = "fit_grpBox";
            this.fit_grpBox.Size = new System.Drawing.Size(458, 423);
            this.fit_grpBox.TabIndex = 4;
            this.fit_grpBox.TabStop = false;
            // 
            // toolStrip_plot
            // 
            this.toolStrip_plot.AutoSize = false;
            this.toolStrip_plot.BackColor = System.Drawing.Color.Lavender;
            this.toolStrip_plot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_plot.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_plot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartFormatBtn,
            this.exportImage_Btn,
            this.cursor_chkBx,
            this.copyImage_Btn,
            this.legend_chkBx,
            this.fragPlotLbl_chkBx,
            this.autoscale_Btn,
            this.toolStripButton1,
            this.clear_toolStripButton,
            this.fragPlotLbl_chkBx2,
            this.toolStripButton2,
            this.toolStripButton3,
            this.rel_res_chkBx,
            this.disp_a,
            this.disp_b,
            this.disp_c,
            this.disp_x,
            this.disp_y,
            this.disp_z,
            this.disp_internal});
            this.toolStrip_plot.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_plot.Name = "toolStrip_plot";
            this.toolStrip_plot.Size = new System.Drawing.Size(458, 27);
            this.toolStrip_plot.TabIndex = 3;
            this.toolStrip_plot.Text = "Graph Tools";
            // 
            // chartFormatBtn
            // 
            this.chartFormatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chartFormatBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleFormatBtn,
            this.extractPlotToolStripMenuItem});
            this.chartFormatBtn.Image = ((System.Drawing.Image)(resources.GetObject("chartFormatBtn.Image")));
            this.chartFormatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chartFormatBtn.Name = "chartFormatBtn";
            this.chartFormatBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.chartFormatBtn.Size = new System.Drawing.Size(33, 24);
            this.chartFormatBtn.Text = "Format Plot Area";
            // 
            // styleFormatBtn
            // 
            this.styleFormatBtn.Name = "styleFormatBtn";
            this.styleFormatBtn.Size = new System.Drawing.Size(134, 22);
            this.styleFormatBtn.Text = "Style";
            this.styleFormatBtn.Click += new System.EventHandler(this.styleFormatBtn_Click);
            // 
            // extractPlotToolStripMenuItem
            // 
            this.extractPlotToolStripMenuItem.Name = "extractPlotToolStripMenuItem";
            this.extractPlotToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem.Text = "Extract plot";
            this.extractPlotToolStripMenuItem.Click += new System.EventHandler(this.extractPlotToolStripMenuItem_Click);
            // 
            // exportImage_Btn
            // 
            this.exportImage_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportImage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("exportImage_Btn.Image")));
            this.exportImage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportImage_Btn.Name = "exportImage_Btn";
            this.exportImage_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.exportImage_Btn.Size = new System.Drawing.Size(24, 24);
            this.exportImage_Btn.ToolTipText = "Export Image";
            this.exportImage_Btn.Visible = false;
            this.exportImage_Btn.Click += new System.EventHandler(this.exportImage_Btn_Click);
            // 
            // copyImage_Btn
            // 
            this.copyImage_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyImage_Btn.Image = ((System.Drawing.Image)(resources.GetObject("copyImage_Btn.Image")));
            this.copyImage_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyImage_Btn.Name = "copyImage_Btn";
            this.copyImage_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.copyImage_Btn.Size = new System.Drawing.Size(24, 24);
            this.copyImage_Btn.ToolTipText = "Copy Image";
            this.copyImage_Btn.Visible = false;
            this.copyImage_Btn.Click += new System.EventHandler(this.copyImage_Btn_Click);
            // 
            // legend_chkBx
            // 
            this.legend_chkBx.CheckOnClick = true;
            this.legend_chkBx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.legend_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("legend_chkBx.Image")));
            this.legend_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.legend_chkBx.Name = "legend_chkBx";
            this.legend_chkBx.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
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
            this.cursor_chkBx.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.cursor_chkBx.Size = new System.Drawing.Size(24, 24);
            this.cursor_chkBx.Text = "Show Cursor";
            this.cursor_chkBx.Click += new System.EventHandler(this.cursor_chkBx_Click);
            // 
            // fragPlotLbl_chkBx
            // 
            this.fragPlotLbl_chkBx.CheckOnClick = true;
            this.fragPlotLbl_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("fragPlotLbl_chkBx.Image")));
            this.fragPlotLbl_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragPlotLbl_chkBx.Name = "fragPlotLbl_chkBx";
            this.fragPlotLbl_chkBx.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.fragPlotLbl_chkBx.Size = new System.Drawing.Size(72, 24);
            this.fragPlotLbl_chkBx.Text = "Primary";
            this.fragPlotLbl_chkBx.ToolTipText = "Show Primary Fragment Label";
            this.fragPlotLbl_chkBx.Click += new System.EventHandler(this.fragPlotLbl_chkBx_Click);
            // 
            // autoscale_Btn
            // 
            this.autoscale_Btn.CheckOnClick = true;
            this.autoscale_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoscale_Btn.Image = ((System.Drawing.Image)(resources.GetObject("autoscale_Btn.Image")));
            this.autoscale_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoscale_Btn.Name = "autoscale_Btn";
            this.autoscale_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.autoscale_Btn.Size = new System.Drawing.Size(24, 24);
            this.autoscale_Btn.Text = "Autoscale";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 27);
            // 
            // clear_toolStripButton
            // 
            this.clear_toolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clear_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clear_toolStripButton.Image")));
            this.clear_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear_toolStripButton.Name = "clear_toolStripButton";
            this.clear_toolStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.clear_toolStripButton.Size = new System.Drawing.Size(73, 24);
            this.clear_toolStripButton.Text = "Clear all";
            this.clear_toolStripButton.Click += new System.EventHandler(this.clear_toolStripButton_Click);
            // 
            // fragPlotLbl_chkBx2
            // 
            this.fragPlotLbl_chkBx2.CheckOnClick = true;
            this.fragPlotLbl_chkBx2.Image = ((System.Drawing.Image)(resources.GetObject("fragPlotLbl_chkBx2.Image")));
            this.fragPlotLbl_chkBx2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragPlotLbl_chkBx2.Name = "fragPlotLbl_chkBx2";
            this.fragPlotLbl_chkBx2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.fragPlotLbl_chkBx2.Size = new System.Drawing.Size(71, 24);
            this.fragPlotLbl_chkBx2.Text = "Internal";
            this.fragPlotLbl_chkBx2.ToolTipText = "Show Internal Fragments Label";
            this.fragPlotLbl_chkBx2.Click += new System.EventHandler(this.fragPlotLbl_chkBx2_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(6, 27);
            // 
            // rel_res_chkBx
            // 
            this.rel_res_chkBx.CheckOnClick = true;
            this.rel_res_chkBx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rel_res_chkBx.Enabled = false;
            this.rel_res_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("rel_res_chkBx.Image")));
            this.rel_res_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rel_res_chkBx.Name = "rel_res_chkBx";
            this.rel_res_chkBx.Size = new System.Drawing.Size(23, 19);
            this.rel_res_chkBx.Text = "%";
            this.rel_res_chkBx.ToolTipText = "display % relative residual";
            this.rel_res_chkBx.CheckedChanged += new System.EventHandler(this.rel_res_chkBx_CheckedChanged);
            // 
            // disp_a
            // 
            this.disp_a.Checked = true;
            this.disp_a.CheckOnClick = true;
            this.disp_a.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_a.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_a.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_a.ForeColor = System.Drawing.Color.Green;
            this.disp_a.Image = ((System.Drawing.Image)(resources.GetObject("disp_a.Image")));
            this.disp_a.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_a.Name = "disp_a";
            this.disp_a.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_a.Size = new System.Drawing.Size(23, 24);
            this.disp_a.Text = "a";
            this.disp_a.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_b
            // 
            this.disp_b.Checked = true;
            this.disp_b.CheckOnClick = true;
            this.disp_b.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_b.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_b.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_b.ForeColor = System.Drawing.Color.Blue;
            this.disp_b.Image = ((System.Drawing.Image)(resources.GetObject("disp_b.Image")));
            this.disp_b.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_b.Name = "disp_b";
            this.disp_b.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_b.Size = new System.Drawing.Size(23, 24);
            this.disp_b.Text = "b";
            this.disp_b.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_c
            // 
            this.disp_c.Checked = true;
            this.disp_c.CheckOnClick = true;
            this.disp_c.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_c.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_c.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_c.ForeColor = System.Drawing.Color.Firebrick;
            this.disp_c.Image = ((System.Drawing.Image)(resources.GetObject("disp_c.Image")));
            this.disp_c.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_c.Name = "disp_c";
            this.disp_c.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_c.Size = new System.Drawing.Size(23, 24);
            this.disp_c.Text = "c";
            this.disp_c.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_x
            // 
            this.disp_x.Checked = true;
            this.disp_x.CheckOnClick = true;
            this.disp_x.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_x.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_x.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_x.ForeColor = System.Drawing.Color.LimeGreen;
            this.disp_x.Image = ((System.Drawing.Image)(resources.GetObject("disp_x.Image")));
            this.disp_x.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_x.Name = "disp_x";
            this.disp_x.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_x.Size = new System.Drawing.Size(23, 24);
            this.disp_x.Text = "x";
            this.disp_x.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_y
            // 
            this.disp_y.Checked = true;
            this.disp_y.CheckOnClick = true;
            this.disp_y.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_y.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_y.ForeColor = System.Drawing.Color.DodgerBlue;
            this.disp_y.Image = ((System.Drawing.Image)(resources.GetObject("disp_y.Image")));
            this.disp_y.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_y.Name = "disp_y";
            this.disp_y.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_y.Size = new System.Drawing.Size(23, 24);
            this.disp_y.Text = "y";
            this.disp_y.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_z
            // 
            this.disp_z.Checked = true;
            this.disp_z.CheckOnClick = true;
            this.disp_z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_z.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_z.ForeColor = System.Drawing.Color.Tomato;
            this.disp_z.Image = ((System.Drawing.Image)(resources.GetObject("disp_z.Image")));
            this.disp_z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_z.Name = "disp_z";
            this.disp_z.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_z.Size = new System.Drawing.Size(23, 24);
            this.disp_z.Text = "z";
            this.disp_z.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_internal
            // 
            this.disp_internal.Checked = true;
            this.disp_internal.CheckOnClick = true;
            this.disp_internal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_internal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_internal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_internal.ForeColor = System.Drawing.Color.Violet;
            this.disp_internal.Image = ((System.Drawing.Image)(resources.GetObject("disp_internal.Image")));
            this.disp_internal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_internal.Name = "disp_internal";
            this.disp_internal.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_internal.Size = new System.Drawing.Size(47, 24);
            this.disp_internal.Text = "inter.";
            // 
            // res_grpBox
            // 
            this.res_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.res_grpBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.res_grpBox.Location = new System.Drawing.Point(0, 450);
            this.res_grpBox.Name = "res_grpBox";
            this.res_grpBox.Size = new System.Drawing.Size(458, 267);
            this.res_grpBox.TabIndex = 1;
            this.res_grpBox.TabStop = false;
            // 
            // user_grpBox
            // 
            this.user_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.user_grpBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.user_grpBox.Controls.Add(this.Fit_results_groupBox);
            this.user_grpBox.Controls.Add(this.splitContainer2);
            this.user_grpBox.Controls.Add(this.theorData_grpBx);
            this.user_grpBox.Controls.Add(this.expData_grpBx);
            this.user_grpBox.Controls.Add(this.fitOptions_grpBox);
            this.user_grpBox.Controls.Add(this.loadFit_Btn);
            this.user_grpBox.Controls.Add(this.loadWd_Btn);
            this.user_grpBox.Controls.Add(this.saveWd_Btn);
            this.user_grpBox.Controls.Add(this.saveFit_Btn);
            this.user_grpBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.user_grpBox.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_grpBox.Location = new System.Drawing.Point(464, 3);
            this.user_grpBox.Name = "user_grpBox";
            this.user_grpBox.Size = new System.Drawing.Size(895, 717);
            this.user_grpBox.TabIndex = 1;
            // 
            // Fit_results_groupBox
            // 
            this.Fit_results_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Fit_results_groupBox.Controls.Add(this.bigPanel);
            this.Fit_results_groupBox.Controls.Add(this.toolStrip_fit_sort);
            this.Fit_results_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fit_results_groupBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.Fit_results_groupBox.Location = new System.Drawing.Point(3, 310);
            this.Fit_results_groupBox.Name = "Fit_results_groupBox";
            this.Fit_results_groupBox.Size = new System.Drawing.Size(226, 404);
            this.Fit_results_groupBox.TabIndex = 10000019;
            this.Fit_results_groupBox.TabStop = false;
            this.Fit_results_groupBox.Text = "Fit results";
            // 
            // bigPanel
            // 
            this.bigPanel.AutoScroll = true;
            this.bigPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bigPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bigPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bigPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bigPanel.Location = new System.Drawing.Point(3, 43);
            this.bigPanel.MinimumSize = new System.Drawing.Size(217, 217);
            this.bigPanel.Name = "bigPanel";
            this.bigPanel.Size = new System.Drawing.Size(220, 358);
            this.bigPanel.TabIndex = 10000000;
            this.bigPanel.WrapContents = false;
            // 
            // toolStrip_fit_sort
            // 
            this.toolStrip_fit_sort.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fit_sort.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.toolStrip_fit_sort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check_bestBtn,
            this.uncheckFit_Btn,
            this.sortSettings_Btn,
            this.refresh_fitRes_Btn});
            this.toolStrip_fit_sort.Location = new System.Drawing.Point(3, 18);
            this.toolStrip_fit_sort.Name = "toolStrip_fit_sort";
            this.toolStrip_fit_sort.Size = new System.Drawing.Size(220, 25);
            this.toolStrip_fit_sort.TabIndex = 10000016;
            this.toolStrip_fit_sort.Text = "toolStrip1";
            // 
            // check_bestBtn
            // 
            this.check_bestBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.check_bestBtn.Image = ((System.Drawing.Image)(resources.GetObject("check_bestBtn.Image")));
            this.check_bestBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.check_bestBtn.Name = "check_bestBtn";
            this.check_bestBtn.Size = new System.Drawing.Size(23, 22);
            this.check_bestBtn.Text = "Select best fit";
            this.check_bestBtn.Click += new System.EventHandler(this.check_bestBtn_Click);
            // 
            // uncheckFit_Btn
            // 
            this.uncheckFit_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheckFit_Btn.Image = ((System.Drawing.Image)(resources.GetObject("uncheckFit_Btn.Image")));
            this.uncheckFit_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheckFit_Btn.Name = "uncheckFit_Btn";
            this.uncheckFit_Btn.Size = new System.Drawing.Size(23, 22);
            this.uncheckFit_Btn.Text = "Uncheck all";
            this.uncheckFit_Btn.Click += new System.EventHandler(this.uncheckFit_Btn_Click);
            // 
            // sortSettings_Btn
            // 
            this.sortSettings_Btn.Image = ((System.Drawing.Image)(resources.GetObject("sortSettings_Btn.Image")));
            this.sortSettings_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortSettings_Btn.Name = "sortSettings_Btn";
            this.sortSettings_Btn.Size = new System.Drawing.Size(97, 22);
            this.sortSettings_Btn.Text = " Sort Settings";
            this.sortSettings_Btn.ToolTipText = "Filter & Sort";
            this.sortSettings_Btn.Click += new System.EventHandler(this.sortSettings_Btn_Click);
            // 
            // refresh_fitRes_Btn
            // 
            this.refresh_fitRes_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh_fitRes_Btn.Image = ((System.Drawing.Image)(resources.GetObject("refresh_fitRes_Btn.Image")));
            this.refresh_fitRes_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh_fitRes_Btn.Name = "refresh_fitRes_Btn";
            this.refresh_fitRes_Btn.Size = new System.Drawing.Size(23, 22);
            this.refresh_fitRes_Btn.Text = "Refresh \'Fit results\'";
            this.refresh_fitRes_Btn.Click += new System.EventHandler(this.refresh_fitRes_Btn_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(227, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel_calc);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.frag_listView);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.factor_panel);
            this.splitContainer2.Panel2.Controls.Add(this.fragStorage_Lbl);
            this.splitContainer2.Panel2.Controls.Add(this.fragTypes_tree);
            this.splitContainer2.Panel2.Controls.Add(this.remPlot_Btn);
            this.splitContainer2.Panel2.Controls.Add(this.plot_Btn);
            this.splitContainer2.Panel2MinSize = 353;
            this.splitContainer2.Size = new System.Drawing.Size(668, 717);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 10000018;
            // 
            // panel_calc
            // 
            this.panel_calc.AutoScroll = true;
            this.panel_calc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_calc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_calc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_calc.Controls.Add(this.dvw_lstBox);
            this.panel_calc.Controls.Add(this.hide_Btn);
            this.panel_calc.Controls.Add(this.optionBtn);
            this.panel_calc.Controls.Add(customRes_Btn);
            this.panel_calc.Controls.Add(this.chargeMax_Box);
            this.panel_calc.Controls.Add(this.internal_lstBox);
            this.panel_calc.Controls.Add(this.addin_lstBox);
            this.panel_calc.Controls.Add(this.machine_listBox);
            this.panel_calc.Controls.Add(this.frag_Label);
            this.panel_calc.Controls.Add(this.M_lstBox);
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
            this.panel_calc.Location = new System.Drawing.Point(3, 3);
            this.panel_calc.MaximumSize = new System.Drawing.Size(318, 700);
            this.panel_calc.MinimumSize = new System.Drawing.Size(300, 620);
            this.panel_calc.Name = "panel_calc";
            this.panel_calc.Size = new System.Drawing.Size(300, 620);
            this.panel_calc.TabIndex = 3;
            // 
            // dvw_lstBox
            // 
            this.dvw_lstBox.CheckOnClick = true;
            this.dvw_lstBox.ColumnWidth = 40;
            this.dvw_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dvw_lstBox.FormattingEnabled = true;
            this.dvw_lstBox.IntegralHeight = false;
            this.dvw_lstBox.Items.AddRange(new object[] {
            "da",
            "wa",
            "db",
            "wb",
            "v"});
            this.dvw_lstBox.Location = new System.Drawing.Point(72, 210);
            this.dvw_lstBox.MultiColumn = true;
            this.dvw_lstBox.Name = "dvw_lstBox";
            this.dvw_lstBox.Size = new System.Drawing.Size(86, 50);
            this.dvw_lstBox.TabIndex = 11;
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
            this.hide_Btn.Location = new System.Drawing.Point(258, -2);
            this.hide_Btn.Name = "hide_Btn";
            this.hide_Btn.Size = new System.Drawing.Size(35, 31);
            this.hide_Btn.TabIndex = 40;
            this.toolTip1.SetToolTip(this.hide_Btn, "Hide calculation box");
            this.hide_Btn.UseVisualStyleBackColor = false;
            this.hide_Btn.Click += new System.EventHandler(this.hide_Btn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.optionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Thistle;
            this.optionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionBtn.Location = new System.Drawing.Point(55, 582);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(119, 23);
            this.optionBtn.TabIndex = 23;
            this.optionBtn.Text = "Calculation Settings";
            this.optionBtn.UseVisualStyleBackColor = false;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // chargeMax_Box
            // 
            this.chargeMax_Box.Enabled = false;
            this.chargeMax_Box.ForeColor = System.Drawing.Color.Black;
            this.chargeMax_Box.Location = new System.Drawing.Point(52, 379);
            this.chargeMax_Box.Name = "chargeMax_Box";
            this.chargeMax_Box.Size = new System.Drawing.Size(38, 20);
            this.chargeMax_Box.TabIndex = 15;
            this.chargeMax_Box.TextChanged += new System.EventHandler(this.ChargeMax_Box_TextChanged);
            // 
            // internal_lstBox
            // 
            this.internal_lstBox.CheckOnClick = true;
            this.internal_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.internal_lstBox.FormattingEnabled = true;
            this.internal_lstBox.Items.AddRange(new object[] {
            "internal a",
            "internal b",
            "internal b-H2O",
            "internal b-NH3",
            "internal b-2H2O",
            "internal b-2NH3"});
            this.internal_lstBox.Location = new System.Drawing.Point(165, 29);
            this.internal_lstBox.Name = "internal_lstBox";
            this.internal_lstBox.Size = new System.Drawing.Size(120, 94);
            this.internal_lstBox.TabIndex = 5;
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
            "y-H2O-NH3",
            "x-H2O"});
            this.addin_lstBox.Location = new System.Drawing.Point(165, 129);
            this.addin_lstBox.Name = "addin_lstBox";
            this.addin_lstBox.Size = new System.Drawing.Size(120, 199);
            this.addin_lstBox.TabIndex = 10;
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
            this.machine_listBox.Location = new System.Drawing.Point(94, 504);
            this.machine_listBox.Name = "machine_listBox";
            this.machine_listBox.Size = new System.Drawing.Size(191, 56);
            this.machine_listBox.TabIndex = 21;
            this.machine_listBox.SelectedIndexChanged += new System.EventHandler(this.Machine_listBox_SelectedIndexChanged);
            // 
            // frag_Label
            // 
            this.frag_Label.AutoSize = true;
            this.frag_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frag_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.frag_Label.Location = new System.Drawing.Point(3, 8);
            this.frag_Label.Name = "frag_Label";
            this.frag_Label.Size = new System.Drawing.Size(56, 13);
            this.frag_Label.TabIndex = 1;
            this.frag_Label.Text = "Fragments";
            // 
            // M_lstBox
            // 
            this.M_lstBox.CheckOnClick = true;
            this.M_lstBox.ColumnWidth = 57;
            this.M_lstBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.M_lstBox.FormattingEnabled = true;
            this.M_lstBox.IntegralHeight = false;
            this.M_lstBox.Items.AddRange(new object[] {
            "M",
            "M-H2O",
            "M-NH3"});
            this.M_lstBox.Location = new System.Drawing.Point(3, 210);
            this.M_lstBox.Name = "M_lstBox";
            this.M_lstBox.Size = new System.Drawing.Size(65, 50);
            this.M_lstBox.TabIndex = 9;
            // 
            // charge_Label
            // 
            this.charge_Label.AutoSize = true;
            this.charge_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charge_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.charge_Label.Location = new System.Drawing.Point(3, 341);
            this.charge_Label.Name = "charge_Label";
            this.charge_Label.Size = new System.Drawing.Size(41, 13);
            this.charge_Label.TabIndex = 28;
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
            this.z_lstBox.Location = new System.Drawing.Point(111, 119);
            this.z_lstBox.Name = "z_lstBox";
            this.z_lstBox.Size = new System.Drawing.Size(47, 79);
            this.z_lstBox.TabIndex = 8;
            // 
            // chargeAll_Btn
            // 
            this.chargeAll_Btn.BackColor = System.Drawing.Color.Gainsboro;
            this.chargeAll_Btn.Enabled = false;
            this.chargeAll_Btn.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.chargeAll_Btn.Location = new System.Drawing.Point(101, 377);
            this.chargeAll_Btn.Name = "chargeAll_Btn";
            this.chargeAll_Btn.Size = new System.Drawing.Size(37, 23);
            this.chargeAll_Btn.TabIndex = 16;
            this.chargeAll_Btn.Text = "All";
            this.chargeAll_Btn.UseVisualStyleBackColor = false;
            this.chargeAll_Btn.Click += new System.EventHandler(this.chargeAll_Btn_Click);
            // 
            // machine_Label
            // 
            this.machine_Label.AutoSize = true;
            this.machine_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machine_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.machine_Label.Location = new System.Drawing.Point(94, 485);
            this.machine_Label.Name = "machine_Label";
            this.machine_Label.Size = new System.Drawing.Size(48, 13);
            this.machine_Label.TabIndex = 37;
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
            this.calc_Btn.Location = new System.Drawing.Point(180, 582);
            this.calc_Btn.Name = "calc_Btn";
            this.calc_Btn.Size = new System.Drawing.Size(105, 23);
            this.calc_Btn.TabIndex = 24;
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
            "y-2",
            "y+1",
            "y+2"});
            this.y_lstBox.Location = new System.Drawing.Point(57, 119);
            this.y_lstBox.Name = "y_lstBox";
            this.y_lstBox.Size = new System.Drawing.Size(47, 79);
            this.y_lstBox.TabIndex = 7;
            // 
            // mz_Label
            // 
            this.mz_Label.AutoSize = true;
            this.mz_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mz_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.mz_Label.Location = new System.Drawing.Point(3, 276);
            this.mz_Label.Name = "mz_Label";
            this.mz_Label.Size = new System.Drawing.Size(81, 13);
            this.mz_Label.TabIndex = 25;
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
            this.c_lstBox.Location = new System.Drawing.Point(111, 29);
            this.c_lstBox.Name = "c_lstBox";
            this.c_lstBox.Size = new System.Drawing.Size(47, 79);
            this.c_lstBox.TabIndex = 4;
            // 
            // mzMax_Label
            // 
            this.mzMax_Label.AutoSize = true;
            this.mzMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mzMax_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.mzMax_Label.Location = new System.Drawing.Point(67, 294);
            this.mzMax_Label.Name = "mzMax_Label";
            this.mzMax_Label.Size = new System.Drawing.Size(26, 13);
            this.mzMax_Label.TabIndex = 27;
            this.mzMax_Label.Text = "max";
            this.mzMax_Label.Click += new System.EventHandler(this.mzMax_Label_Click);
            // 
            // resolution_Box
            // 
            this.resolution_Box.Enabled = false;
            this.resolution_Box.ForeColor = System.Drawing.Color.Black;
            this.resolution_Box.Location = new System.Drawing.Point(4, 504);
            this.resolution_Box.Name = "resolution_Box";
            this.resolution_Box.Size = new System.Drawing.Size(81, 20);
            this.resolution_Box.TabIndex = 20;
            this.resolution_Box.TextChanged += new System.EventHandler(this.Resolution_Box_TextChanged);
            // 
            // mzMin_Label
            // 
            this.mzMin_Label.AutoSize = true;
            this.mzMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mzMin_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.mzMin_Label.Location = new System.Drawing.Point(3, 294);
            this.mzMin_Label.Name = "mzMin_Label";
            this.mzMin_Label.Size = new System.Drawing.Size(23, 13);
            this.mzMin_Label.TabIndex = 26;
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
            "x-2",
            "x+1",
            "x+2"});
            this.x_lstBox.Location = new System.Drawing.Point(3, 119);
            this.x_lstBox.Name = "x_lstBox";
            this.x_lstBox.Size = new System.Drawing.Size(47, 79);
            this.x_lstBox.TabIndex = 6;
            // 
            // mzMax_Box
            // 
            this.mzMax_Box.Enabled = false;
            this.mzMax_Box.ForeColor = System.Drawing.Color.Black;
            this.mzMax_Box.Location = new System.Drawing.Point(67, 310);
            this.mzMax_Box.Name = "mzMax_Box";
            this.mzMax_Box.Size = new System.Drawing.Size(56, 20);
            this.mzMax_Box.TabIndex = 13;
            this.mzMax_Box.Click += new System.EventHandler(this.mzMax_Box_Click);
            this.mzMax_Box.TextChanged += new System.EventHandler(this.MzMax_Box_TextChanged);
            // 
            // resolution_Label
            // 
            this.resolution_Label.AutoSize = true;
            this.resolution_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolution_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.resolution_Label.Location = new System.Drawing.Point(4, 485);
            this.resolution_Label.Name = "resolution_Label";
            this.resolution_Label.Size = new System.Drawing.Size(57, 13);
            this.resolution_Label.TabIndex = 36;
            this.resolution_Label.Text = "Resolution";
            // 
            // mzMin_Box
            // 
            this.mzMin_Box.Enabled = false;
            this.mzMin_Box.ForeColor = System.Drawing.Color.Black;
            this.mzMin_Box.Location = new System.Drawing.Point(3, 310);
            this.mzMin_Box.Name = "mzMin_Box";
            this.mzMin_Box.Size = new System.Drawing.Size(56, 20);
            this.mzMin_Box.TabIndex = 12;
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
            "b-2",
            "b+1",
            "b+2"});
            this.b_lstBox.Location = new System.Drawing.Point(57, 29);
            this.b_lstBox.Name = "b_lstBox";
            this.b_lstBox.Size = new System.Drawing.Size(47, 79);
            this.b_lstBox.TabIndex = 3;
            // 
            // saveCalc_Btn
            // 
            this.saveCalc_Btn.Enabled = false;
            this.saveCalc_Btn.Location = new System.Drawing.Point(7, 537);
            this.saveCalc_Btn.Name = "saveCalc_Btn";
            this.saveCalc_Btn.Size = new System.Drawing.Size(43, 23);
            this.saveCalc_Btn.TabIndex = 38;
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
            this.idxTo_Label.Location = new System.Drawing.Point(249, 431);
            this.idxTo_Label.Name = "idxTo_Label";
            this.idxTo_Label.Size = new System.Drawing.Size(16, 13);
            this.idxTo_Label.TabIndex = 35;
            this.idxTo_Label.Text = "to";
            // 
            // clearCalc_Btn
            // 
            this.clearCalc_Btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clearCalc_Btn.Enabled = false;
            this.clearCalc_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearCalc_Btn.ForeColor = System.Drawing.Color.White;
            this.clearCalc_Btn.Location = new System.Drawing.Point(4, 582);
            this.clearCalc_Btn.Name = "clearCalc_Btn";
            this.clearCalc_Btn.Size = new System.Drawing.Size(46, 23);
            this.clearCalc_Btn.TabIndex = 24;
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
            this.idxFrom_Label.Location = new System.Drawing.Point(148, 431);
            this.idxFrom_Label.Name = "idxFrom_Label";
            this.idxFrom_Label.Size = new System.Drawing.Size(27, 13);
            this.idxFrom_Label.TabIndex = 34;
            this.idxFrom_Label.Text = "from";
            // 
            // chargeMax_Label
            // 
            this.chargeMax_Label.AutoSize = true;
            this.chargeMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeMax_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.chargeMax_Label.Location = new System.Drawing.Point(52, 362);
            this.chargeMax_Label.Name = "chargeMax_Label";
            this.chargeMax_Label.Size = new System.Drawing.Size(26, 13);
            this.chargeMax_Label.TabIndex = 30;
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
            "a-2",
            "a+1",
            "a+2"});
            this.a_lstBox.Location = new System.Drawing.Point(3, 29);
            this.a_lstBox.Name = "a_lstBox";
            this.a_lstBox.Size = new System.Drawing.Size(47, 79);
            this.a_lstBox.TabIndex = 2;
            // 
            // chargeMin_Label
            // 
            this.chargeMin_Label.AutoSize = true;
            this.chargeMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeMin_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.chargeMin_Label.Location = new System.Drawing.Point(3, 362);
            this.chargeMin_Label.Name = "chargeMin_Label";
            this.chargeMin_Label.Size = new System.Drawing.Size(23, 13);
            this.chargeMin_Label.TabIndex = 29;
            this.chargeMin_Label.Text = "min";
            // 
            // idxTo_Box
            // 
            this.idxTo_Box.Enabled = false;
            this.idxTo_Box.ForeColor = System.Drawing.Color.Black;
            this.idxTo_Box.Location = new System.Drawing.Point(184, 447);
            this.idxTo_Box.Name = "idxTo_Box";
            this.idxTo_Box.Size = new System.Drawing.Size(81, 20);
            this.idxTo_Box.TabIndex = 19;
            this.idxTo_Box.TextChanged += new System.EventHandler(this.IdxTo_Box_TextChanged);
            // 
            // chargeMin_Box
            // 
            this.chargeMin_Box.Enabled = false;
            this.chargeMin_Box.ForeColor = System.Drawing.Color.Black;
            this.chargeMin_Box.Location = new System.Drawing.Point(3, 379);
            this.chargeMin_Box.Name = "chargeMin_Box";
            this.chargeMin_Box.Size = new System.Drawing.Size(38, 20);
            this.chargeMin_Box.TabIndex = 14;
            this.chargeMin_Box.TextChanged += new System.EventHandler(this.ChargeMin_Box_TextChanged);
            // 
            // idxFrom_Box
            // 
            this.idxFrom_Box.Enabled = false;
            this.idxFrom_Box.ForeColor = System.Drawing.Color.Black;
            this.idxFrom_Box.Location = new System.Drawing.Point(94, 447);
            this.idxFrom_Box.Name = "idxFrom_Box";
            this.idxFrom_Box.Size = new System.Drawing.Size(81, 20);
            this.idxFrom_Box.TabIndex = 18;
            this.idxFrom_Box.TextChanged += new System.EventHandler(this.IdxFrom_Box_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(3, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Index";
            // 
            // idxPr_Box
            // 
            this.idxPr_Box.Enabled = false;
            this.idxPr_Box.ForeColor = System.Drawing.Color.Black;
            this.idxPr_Box.Location = new System.Drawing.Point(3, 447);
            this.idxPr_Box.Name = "idxPr_Box";
            this.idxPr_Box.Size = new System.Drawing.Size(81, 20);
            this.idxPr_Box.TabIndex = 17;
            this.idxPr_Box.TextChanged += new System.EventHandler(this.IdxPr_Box_TextChanged);
            // 
            // primary_Label
            // 
            this.primary_Label.AutoSize = true;
            this.primary_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primary_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.primary_Label.Location = new System.Drawing.Point(3, 431);
            this.primary_Label.Name = "primary_Label";
            this.primary_Label.Size = new System.Drawing.Size(43, 13);
            this.primary_Label.TabIndex = 32;
            this.primary_Label.Text = "primary ";
            // 
            // internal_Label
            // 
            this.internal_Label.AutoSize = true;
            this.internal_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internal_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.internal_Label.Location = new System.Drawing.Point(94, 431);
            this.internal_Label.Name = "internal_Label";
            this.internal_Label.Size = new System.Drawing.Size(41, 13);
            this.internal_Label.TabIndex = 33;
            this.internal_Label.Text = "internal";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 318);
            this.panel2.TabIndex = 116;
            // 
            // frag_listView
            // 
            this.frag_listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
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
            this.frag_listView.Location = new System.Drawing.Point(19, 153);
            this.frag_listView.Name = "frag_listView";
            this.frag_listView.Size = new System.Drawing.Size(320, 215);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip_fragList);
            this.panel1.Controls.Add(this.show_Btn);
            this.panel1.Controls.Add(this.fragList_toolStrip);
            this.panel1.Controls.Add(this.selFrag_Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 128);
            this.panel1.TabIndex = 115;
            // 
            // toolStrip_fragList
            // 
            this.toolStrip_fragList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip_fragList.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_fragList.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_fragList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fragList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_fragList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show_files_Btn,
            this.statistics_Btn,
            this.toolStripButton10,
            this.toggle_toolStripButton,
            this.uncheckall_Frag_Btn,
            this.checkall_Frag_Btn,
            this.toolStripSeparator1,
            this.clearListBtn11,
            this.loadListBtn11,
            this.saveListBtn11});
            this.toolStrip_fragList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_fragList.Location = new System.Drawing.Point(122, 90);
            this.toolStrip_fragList.Name = "toolStrip_fragList";
            this.toolStrip_fragList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip_fragList.Size = new System.Drawing.Size(207, 27);
            this.toolStrip_fragList.TabIndex = 119;
            // 
            // show_files_Btn
            // 
            this.show_files_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.show_files_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.show_files_Btn.Image = ((System.Drawing.Image)(resources.GetObject("show_files_Btn.Image")));
            this.show_files_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.show_files_Btn.Name = "show_files_Btn";
            this.show_files_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.show_files_Btn.Size = new System.Drawing.Size(24, 24);
            this.show_files_Btn.Text = "Display loaded Fragment lists";
            // 
            // statistics_Btn
            // 
            this.statistics_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statistics_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statistics_Btn.Image = ((System.Drawing.Image)(resources.GetObject("statistics_Btn.Image")));
            this.statistics_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statistics_Btn.Name = "statistics_Btn";
            this.statistics_Btn.Size = new System.Drawing.Size(24, 24);
            this.statistics_Btn.Text = "Statistics";
            this.statistics_Btn.Click += new System.EventHandler(this.statistics_Btn_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(6, 27);
            // 
            // toggle_toolStripButton
            // 
            this.toggle_toolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toggle_toolStripButton.CheckOnClick = true;
            this.toggle_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggle_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggle_toolStripButton.Image")));
            this.toggle_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggle_toolStripButton.Name = "toggle_toolStripButton";
            this.toggle_toolStripButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toggle_toolStripButton.Size = new System.Drawing.Size(24, 24);
            this.toggle_toolStripButton.Text = "Toggle All Outlining";
            this.toggle_toolStripButton.CheckedChanged += new System.EventHandler(this.toggle_toolStripButton_CheckedChanged);
            // 
            // uncheckall_Frag_Btn
            // 
            this.uncheckall_Frag_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uncheckall_Frag_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheckall_Frag_Btn.Image = ((System.Drawing.Image)(resources.GetObject("uncheckall_Frag_Btn.Image")));
            this.uncheckall_Frag_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheckall_Frag_Btn.Name = "uncheckall_Frag_Btn";
            this.uncheckall_Frag_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.uncheckall_Frag_Btn.Size = new System.Drawing.Size(24, 24);
            this.uncheckall_Frag_Btn.Text = "Uncheck all";
            this.uncheckall_Frag_Btn.Click += new System.EventHandler(this.uncheckall_Frag_Btn_Click);
            // 
            // checkall_Frag_Btn
            // 
            this.checkall_Frag_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.checkall_Frag_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkall_Frag_Btn.Image = ((System.Drawing.Image)(resources.GetObject("checkall_Frag_Btn.Image")));
            this.checkall_Frag_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkall_Frag_Btn.Name = "checkall_Frag_Btn";
            this.checkall_Frag_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.checkall_Frag_Btn.Size = new System.Drawing.Size(24, 24);
            this.checkall_Frag_Btn.Text = "Check all";
            this.checkall_Frag_Btn.Click += new System.EventHandler(this.checkall_Frag_Btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // clearListBtn11
            // 
            this.clearListBtn11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("clearListBtn11.Image")));
            this.clearListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearListBtn11.Name = "clearListBtn11";
            this.clearListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.clearListBtn11.Size = new System.Drawing.Size(24, 24);
            this.clearListBtn11.Text = "Clear Fragment List , keep experimental data";
            this.clearListBtn11.Click += new System.EventHandler(this.clearListBtn11_Click);
            // 
            // loadListBtn11
            // 
            this.loadListBtn11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loadListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("loadListBtn11.Image")));
            this.loadListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadListBtn11.Name = "loadListBtn11";
            this.loadListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.loadListBtn11.Size = new System.Drawing.Size(24, 24);
            this.loadListBtn11.Text = "Load fragments from a \' .fit \' file";
            this.loadListBtn11.Click += new System.EventHandler(this.loadListBtn11_Click);
            // 
            // saveListBtn11
            // 
            this.saveListBtn11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("saveListBtn11.Image")));
            this.saveListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveListBtn11.Name = "saveListBtn11";
            this.saveListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.saveListBtn11.Size = new System.Drawing.Size(24, 24);
            this.saveListBtn11.Text = "Save checked fragments";
            this.saveListBtn11.Click += new System.EventHandler(this.saveListBtn11_Click);
            // 
            // show_Btn
            // 
            this.show_Btn.BackColor = System.Drawing.Color.White;
            this.show_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("show_Btn.BackgroundImage")));
            this.show_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.show_Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.show_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_Btn.Location = new System.Drawing.Point(3, 5);
            this.show_Btn.Name = "show_Btn";
            this.show_Btn.Size = new System.Drawing.Size(35, 31);
            this.show_Btn.TabIndex = 41;
            this.toolTip1.SetToolTip(this.show_Btn, "Show calculation box");
            this.show_Btn.UseVisualStyleBackColor = false;
            this.show_Btn.Visible = false;
            this.show_Btn.Click += new System.EventHandler(this.show_Btn_Click);
            // 
            // fragList_toolStrip
            // 
            this.fragList_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fragList_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fragList_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fragList_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frag_sort_Btn1,
            this.refresh_frag_Btn1,
            this.fragCalc_Btn1});
            this.fragList_toolStrip.Location = new System.Drawing.Point(143, 63);
            this.fragList_toolStrip.Name = "fragList_toolStrip";
            this.fragList_toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fragList_toolStrip.Size = new System.Drawing.Size(186, 25);
            this.fragList_toolStrip.TabIndex = 118;
            this.fragList_toolStrip.Text = "Frag.Calculator";
            // 
            // frag_sort_Btn1
            // 
            this.frag_sort_Btn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.frag_sort_Btn1.Image = ((System.Drawing.Image)(resources.GetObject("frag_sort_Btn1.Image")));
            this.frag_sort_Btn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frag_sort_Btn1.Name = "frag_sort_Btn1";
            this.frag_sort_Btn1.Size = new System.Drawing.Size(53, 22);
            this.frag_sort_Btn1.Text = "Filter";
            this.frag_sort_Btn1.ToolTipText = "Filter Fragment List entries";
            this.frag_sort_Btn1.Click += new System.EventHandler(this.frag_sort_Btn1_Click);
            // 
            // refresh_frag_Btn1
            // 
            this.refresh_frag_Btn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refresh_frag_Btn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh_frag_Btn1.Image = ((System.Drawing.Image)(resources.GetObject("refresh_frag_Btn1.Image")));
            this.refresh_frag_Btn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh_frag_Btn1.Name = "refresh_frag_Btn1";
            this.refresh_frag_Btn1.Size = new System.Drawing.Size(23, 22);
            this.refresh_frag_Btn1.Text = "Refresh Fragment List entries";
            this.refresh_frag_Btn1.Click += new System.EventHandler(this.refresh_frag_Btn1_Click);
            // 
            // fragCalc_Btn1
            // 
            this.fragCalc_Btn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.fragCalc_Btn1.Image = ((System.Drawing.Image)(resources.GetObject("fragCalc_Btn1.Image")));
            this.fragCalc_Btn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragCalc_Btn1.Name = "fragCalc_Btn1";
            this.fragCalc_Btn1.Size = new System.Drawing.Size(107, 22);
            this.fragCalc_Btn1.Text = "Frag.Calculator";
            this.fragCalc_Btn1.ToolTipText = "Fragment Calculator";
            this.fragCalc_Btn1.Click += new System.EventHandler(this.fragCalc_Btn1_Click);
            // 
            // selFrag_Label
            // 
            this.selFrag_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selFrag_Label.AutoSize = true;
            this.selFrag_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selFrag_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.selFrag_Label.Location = new System.Drawing.Point(4, 99);
            this.selFrag_Label.Name = "selFrag_Label";
            this.selFrag_Label.Size = new System.Drawing.Size(89, 17);
            this.selFrag_Label.TabIndex = 38;
            this.selFrag_Label.Text = "Fragment list";
            this.toolTip1.SetToolTip(this.selFrag_Label, "Select all fragments presented in the list");
            this.selFrag_Label.Click += new System.EventHandler(this.selFrag_Label_Click);
            // 
            // factor_panel
            // 
            this.factor_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.factor_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.factor_panel.Location = new System.Drawing.Point(0, 446);
            this.factor_panel.Name = "factor_panel";
            this.factor_panel.Size = new System.Drawing.Size(361, 30);
            this.factor_panel.TabIndex = 114;
            // 
            // fragStorage_Lbl
            // 
            this.fragStorage_Lbl.AutoSize = true;
            this.fragStorage_Lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fragStorage_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragStorage_Lbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.fragStorage_Lbl.Location = new System.Drawing.Point(0, 476);
            this.fragStorage_Lbl.Name = "fragStorage_Lbl";
            this.fragStorage_Lbl.Size = new System.Drawing.Size(122, 17);
            this.fragStorage_Lbl.TabIndex = 113;
            this.fragStorage_Lbl.Text = "Fragment Storage";
            this.toolTip1.SetToolTip(this.fragStorage_Lbl, "Select all fragments presented in the list");
            this.fragStorage_Lbl.Visible = false;
            // 
            // fragTypes_tree
            // 
            this.fragTypes_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragTypes_tree.CheckBoxes = true;
            this.fragTypes_tree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fragTypes_tree.Location = new System.Drawing.Point(0, 493);
            this.fragTypes_tree.Name = "fragTypes_tree";
            this.fragTypes_tree.Size = new System.Drawing.Size(361, 224);
            this.fragTypes_tree.TabIndex = 112;
            this.fragTypes_tree.Visible = false;
            // 
            // remPlot_Btn
            // 
            this.remPlot_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remPlot_Btn.Location = new System.Drawing.Point(114, 664);
            this.remPlot_Btn.Name = "remPlot_Btn";
            this.remPlot_Btn.Size = new System.Drawing.Size(75, 23);
            this.remPlot_Btn.TabIndex = 43;
            this.remPlot_Btn.Text = "Remove";
            this.remPlot_Btn.UseVisualStyleBackColor = true;
            this.remPlot_Btn.Visible = false;
            this.remPlot_Btn.Click += new System.EventHandler(this.remPlot_Btn_Click);
            // 
            // plot_Btn
            // 
            this.plot_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.plot_Btn.Location = new System.Drawing.Point(204, 664);
            this.plot_Btn.Name = "plot_Btn";
            this.plot_Btn.Size = new System.Drawing.Size(75, 23);
            this.plot_Btn.TabIndex = 42;
            this.plot_Btn.Text = "Plot";
            this.plot_Btn.UseVisualStyleBackColor = true;
            this.plot_Btn.Visible = false;
            this.plot_Btn.Click += new System.EventHandler(this.plot_Btn_Click);
            // 
            // theorData_grpBx
            // 
            this.theorData_grpBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.theorData_grpBx.Controls.Add(this.seqBtn);
            this.theorData_grpBx.Controls.Add(this.loadFF_Btn);
            this.theorData_grpBx.Controls.Add(this.loadMS_Btn);
            this.theorData_grpBx.Controls.Add(this.peptide_textBox1);
            this.theorData_grpBx.Controls.Add(this.plotFragProf_chkBox);
            this.theorData_grpBx.Controls.Add(this.plotFragCent_chkBox);
            this.theorData_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theorData_grpBx.ForeColor = System.Drawing.Color.SteelBlue;
            this.theorData_grpBx.Location = new System.Drawing.Point(6, 115);
            this.theorData_grpBx.Name = "theorData_grpBx";
            this.theorData_grpBx.Size = new System.Drawing.Size(219, 92);
            this.theorData_grpBx.TabIndex = 2;
            this.theorData_grpBx.TabStop = false;
            this.theorData_grpBx.Text = "Theoretical Data";
            // 
            // seqBtn
            // 
            this.seqBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.seqBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.seqBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seqBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqBtn.ForeColor = System.Drawing.Color.White;
            this.seqBtn.Location = new System.Drawing.Point(3, 22);
            this.seqBtn.Name = "seqBtn";
            this.seqBtn.Size = new System.Drawing.Size(66, 22);
            this.seqBtn.TabIndex = 44;
            this.seqBtn.Text = "Sequence";
            this.seqBtn.UseVisualStyleBackColor = false;
            this.seqBtn.Click += new System.EventHandler(this.seqBtn_Click);
            // 
            // loadFF_Btn
            // 
            this.loadFF_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFF_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadFF_Btn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.loadFF_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadFF_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFF_Btn.ForeColor = System.Drawing.Color.White;
            this.loadFF_Btn.Location = new System.Drawing.Point(144, 22);
            this.loadFF_Btn.Name = "loadFF_Btn";
            this.loadFF_Btn.Size = new System.Drawing.Size(72, 22);
            this.loadFF_Btn.TabIndex = 43;
            this.loadFF_Btn.Text = "MS/MS File";
            this.toolTip1.SetToolTip(this.loadFF_Btn, "Load Fragments without filters and peak detection");
            this.loadFF_Btn.UseVisualStyleBackColor = false;
            this.loadFF_Btn.Click += new System.EventHandler(this.loadFF_Btn_Click);
            // 
            // loadMS_Btn
            // 
            this.loadMS_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadMS_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.loadMS_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadMS_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadMS_Btn.ForeColor = System.Drawing.Color.White;
            this.loadMS_Btn.Location = new System.Drawing.Point(70, 22);
            this.loadMS_Btn.Name = "loadMS_Btn";
            this.loadMS_Btn.Size = new System.Drawing.Size(73, 22);
            this.loadMS_Btn.TabIndex = 1;
            this.loadMS_Btn.Text = " PP MS/MS";
            this.loadMS_Btn.UseVisualStyleBackColor = false;
            this.loadMS_Btn.Click += new System.EventHandler(this.LoadMS_Btn_Click);
            // 
            // peptide_textBox1
            // 
            this.peptide_textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.peptide_textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.peptide_textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.peptide_textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peptide_textBox1.Location = new System.Drawing.Point(3, 48);
            this.peptide_textBox1.Name = "peptide_textBox1";
            this.peptide_textBox1.ReadOnly = true;
            this.peptide_textBox1.Size = new System.Drawing.Size(213, 11);
            this.peptide_textBox1.TabIndex = 42;
            // 
            // plotFragProf_chkBox
            // 
            this.plotFragProf_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotFragProf_chkBox.AutoSize = true;
            this.plotFragProf_chkBox.Enabled = false;
            this.plotFragProf_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragProf_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragProf_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragProf_chkBox.Location = new System.Drawing.Point(3, 66);
            this.plotFragProf_chkBox.Name = "plotFragProf_chkBox";
            this.plotFragProf_chkBox.Size = new System.Drawing.Size(58, 17);
            this.plotFragProf_chkBox.TabIndex = 2;
            this.plotFragProf_chkBox.Text = "Profiles";
            this.plotFragProf_chkBox.UseVisualStyleBackColor = true;
            this.plotFragProf_chkBox.CheckedChanged += new System.EventHandler(this.plotFragProf_chkBox_CheckedChanged);
            // 
            // plotFragCent_chkBox
            // 
            this.plotFragCent_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotFragCent_chkBox.AutoSize = true;
            this.plotFragCent_chkBox.Enabled = false;
            this.plotFragCent_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragCent_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragCent_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragCent_chkBox.Location = new System.Drawing.Point(75, 66);
            this.plotFragCent_chkBox.Name = "plotFragCent_chkBox";
            this.plotFragCent_chkBox.Size = new System.Drawing.Size(68, 17);
            this.plotFragCent_chkBox.TabIndex = 3;
            this.plotFragCent_chkBox.Text = "Centroids";
            this.plotFragCent_chkBox.UseVisualStyleBackColor = true;
            // 
            // expData_grpBx
            // 
            this.expData_grpBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.expData_grpBx.Controls.Add(this.filename_txtBx);
            this.expData_grpBx.Controls.Add(this.displayPeakList_btn);
            this.expData_grpBx.Controls.Add(this.toolStrip1);
            this.expData_grpBx.Controls.Add(this.plotCentr_chkBox);
            this.expData_grpBx.Controls.Add(this.plotExp_chkBox);
            this.expData_grpBx.Controls.Add(this.loadExp_Btn);
            this.expData_grpBx.Controls.Add(this.fitMin_Label);
            this.expData_grpBx.Controls.Add(this.fitMax_Box);
            this.expData_grpBx.Controls.Add(this.fitMax_Label);
            this.expData_grpBx.Controls.Add(this.fitMin_Box);
            this.expData_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expData_grpBx.ForeColor = System.Drawing.Color.SteelBlue;
            this.expData_grpBx.Location = new System.Drawing.Point(6, 5);
            this.expData_grpBx.Name = "expData_grpBx";
            this.expData_grpBx.Size = new System.Drawing.Size(219, 108);
            this.expData_grpBx.TabIndex = 0;
            this.expData_grpBx.TabStop = false;
            this.expData_grpBx.Text = "Experimental Data";
            // 
            // filename_txtBx
            // 
            this.filename_txtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filename_txtBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.filename_txtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filename_txtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filename_txtBx.Location = new System.Drawing.Point(2, 71);
            this.filename_txtBx.Name = "filename_txtBx";
            this.filename_txtBx.ReadOnly = true;
            this.filename_txtBx.Size = new System.Drawing.Size(213, 11);
            this.filename_txtBx.TabIndex = 41;
            // 
            // displayPeakList_btn
            // 
            this.displayPeakList_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.displayPeakList_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.displayPeakList_btn.Enabled = false;
            this.displayPeakList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.displayPeakList_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPeakList_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.displayPeakList_btn.Location = new System.Drawing.Point(2, 45);
            this.displayPeakList_btn.Name = "displayPeakList_btn";
            this.displayPeakList_btn.Size = new System.Drawing.Size(103, 21);
            this.displayPeakList_btn.TabIndex = 2;
            this.displayPeakList_btn.Text = "peak list";
            this.displayPeakList_btn.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsPeak_Btn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(144, 45);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(72, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // settingsPeak_Btn
            // 
            this.settingsPeak_Btn.Image = ((System.Drawing.Image)(resources.GetObject("settingsPeak_Btn.Image")));
            this.settingsPeak_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsPeak_Btn.Name = "settingsPeak_Btn";
            this.settingsPeak_Btn.Size = new System.Drawing.Size(69, 22);
            this.settingsPeak_Btn.Text = "Settings";
            this.settingsPeak_Btn.Click += new System.EventHandler(this.settingsPeak_Btn_Click);
            // 
            // plotCentr_chkBox
            // 
            this.plotCentr_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotCentr_chkBox.AutoSize = true;
            this.plotCentr_chkBox.Enabled = false;
            this.plotCentr_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotCentr_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotCentr_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotCentr_chkBox.Location = new System.Drawing.Point(78, 84);
            this.plotCentr_chkBox.Name = "plotCentr_chkBox";
            this.plotCentr_chkBox.Size = new System.Drawing.Size(68, 17);
            this.plotCentr_chkBox.TabIndex = 4;
            this.plotCentr_chkBox.Text = "Centroids";
            this.plotCentr_chkBox.UseVisualStyleBackColor = true;
            // 
            // plotExp_chkBox
            // 
            this.plotExp_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotExp_chkBox.AutoSize = true;
            this.plotExp_chkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plotExp_chkBox.Enabled = false;
            this.plotExp_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotExp_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotExp_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotExp_chkBox.Location = new System.Drawing.Point(3, 84);
            this.plotExp_chkBox.Name = "plotExp_chkBox";
            this.plotExp_chkBox.Size = new System.Drawing.Size(69, 17);
            this.plotExp_chkBox.TabIndex = 3;
            this.plotExp_chkBox.Text = "Spectrum";
            this.plotExp_chkBox.UseVisualStyleBackColor = true;
            // 
            // loadExp_Btn
            // 
            this.loadExp_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadExp_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.loadExp_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadExp_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadExp_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadExp_Btn.ForeColor = System.Drawing.Color.White;
            this.loadExp_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadExp_Btn.Location = new System.Drawing.Point(3, 19);
            this.loadExp_Btn.Name = "loadExp_Btn";
            this.loadExp_Btn.Size = new System.Drawing.Size(213, 21);
            this.loadExp_Btn.TabIndex = 1;
            this.loadExp_Btn.Text = "Load Experiment";
            this.loadExp_Btn.UseVisualStyleBackColor = false;
            this.loadExp_Btn.Click += new System.EventHandler(this.loadExp_Btn_Click);
            // 
            // fitMin_Label
            // 
            this.fitMin_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fitMin_Label.AutoSize = true;
            this.fitMin_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMin_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.fitMin_Label.Location = new System.Drawing.Point(160, 62);
            this.fitMin_Label.Name = "fitMin_Label";
            this.fitMin_Label.Size = new System.Drawing.Size(23, 13);
            this.fitMin_Label.TabIndex = 34;
            this.fitMin_Label.Text = "min";
            this.fitMin_Label.Visible = false;
            // 
            // fitMax_Box
            // 
            this.fitMax_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fitMax_Box.Enabled = false;
            this.fitMax_Box.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMax_Box.ForeColor = System.Drawing.Color.Black;
            this.fitMax_Box.Location = new System.Drawing.Point(163, 80);
            this.fitMax_Box.Name = "fitMax_Box";
            this.fitMax_Box.Size = new System.Drawing.Size(50, 19);
            this.fitMax_Box.TabIndex = 35;
            this.fitMax_Box.Visible = false;
            this.fitMax_Box.TextChanged += new System.EventHandler(this.FitMax_Box_TextChanged);
            // 
            // fitMax_Label
            // 
            this.fitMax_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fitMax_Label.AutoSize = true;
            this.fitMax_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMax_Label.ForeColor = System.Drawing.Color.SlateGray;
            this.fitMax_Label.Location = new System.Drawing.Point(185, 58);
            this.fitMax_Label.Name = "fitMax_Label";
            this.fitMax_Label.Size = new System.Drawing.Size(26, 13);
            this.fitMax_Label.TabIndex = 33;
            this.fitMax_Label.Text = "max";
            this.fitMax_Label.Visible = false;
            // 
            // fitMin_Box
            // 
            this.fitMin_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fitMin_Box.Enabled = false;
            this.fitMin_Box.Font = new System.Drawing.Font("Microsoft Tai Le", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitMin_Box.ForeColor = System.Drawing.Color.Black;
            this.fitMin_Box.Location = new System.Drawing.Point(163, 74);
            this.fitMin_Box.Name = "fitMin_Box";
            this.fitMin_Box.Size = new System.Drawing.Size(50, 19);
            this.fitMin_Box.TabIndex = 36;
            this.fitMin_Box.Visible = false;
            this.fitMin_Box.TextChanged += new System.EventHandler(this.FitMin_Box_TextChanged);
            // 
            // fitOptions_grpBox
            // 
            this.fitOptions_grpBox.Controls.Add(this.fit_chkGrpsChkFragBtn);
            this.fitOptions_grpBox.Controls.Add(this.fit_chkGrpsBtn);
            this.fitOptions_grpBox.Controls.Add(this.fiToolStrip);
            this.fitOptions_grpBox.Controls.Add(this.fit_Btn);
            this.fitOptions_grpBox.Controls.Add(this.fit_sel_Btn);
            this.fitOptions_grpBox.Controls.Add(this.stepRange_Lbl);
            this.fitOptions_grpBox.Controls.Add(this.step_rangeBox);
            this.fitOptions_grpBox.Controls.Add(this.fitStep_Box);
            this.fitOptions_grpBox.Controls.Add(this.fitStep_Label);
            this.fitOptions_grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitOptions_grpBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.fitOptions_grpBox.Location = new System.Drawing.Point(6, 208);
            this.fitOptions_grpBox.Name = "fitOptions_grpBox";
            this.fitOptions_grpBox.Size = new System.Drawing.Size(219, 102);
            this.fitOptions_grpBox.TabIndex = 4;
            this.fitOptions_grpBox.TabStop = false;
            this.fitOptions_grpBox.Text = "Fitting";
            // 
            // fit_chkGrpsChkFragBtn
            // 
            this.fit_chkGrpsChkFragBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fit_chkGrpsChkFragBtn.BackColor = System.Drawing.Color.Coral;
            this.fit_chkGrpsChkFragBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_chkGrpsChkFragBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit_chkGrpsChkFragBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fit_chkGrpsChkFragBtn.Location = new System.Drawing.Point(113, 44);
            this.fit_chkGrpsChkFragBtn.Name = "fit_chkGrpsChkFragBtn";
            this.fit_chkGrpsChkFragBtn.Size = new System.Drawing.Size(103, 21);
            this.fit_chkGrpsChkFragBtn.TabIndex = 46;
            this.fit_chkGrpsChkFragBtn.Text = "Fit checked Frag.";
            this.fit_chkGrpsChkFragBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.fit_chkGrpsChkFragBtn, "Fit the checked groups as one united fit groups. But take into account only the c" +
        "hecked fragments of each group");
            this.fit_chkGrpsChkFragBtn.UseVisualStyleBackColor = false;
            this.fit_chkGrpsChkFragBtn.Click += new System.EventHandler(this.fit_chkGrpsChkFragBtn_Click_1);
            // 
            // fit_chkGrpsBtn
            // 
            this.fit_chkGrpsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fit_chkGrpsBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.fit_chkGrpsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_chkGrpsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit_chkGrpsBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fit_chkGrpsBtn.Location = new System.Drawing.Point(3, 44);
            this.fit_chkGrpsBtn.Name = "fit_chkGrpsBtn";
            this.fit_chkGrpsBtn.Size = new System.Drawing.Size(103, 21);
            this.fit_chkGrpsBtn.TabIndex = 45;
            this.fit_chkGrpsBtn.Text = "Fit checked groups";
            this.fit_chkGrpsBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.fit_chkGrpsBtn, "Fit the checked groups as one united fit groups");
            this.fit_chkGrpsBtn.UseVisualStyleBackColor = false;
            this.fit_chkGrpsBtn.Click += new System.EventHandler(this.fit_chkGrpsBtn_Click);
            // 
            // fiToolStrip
            // 
            this.fiToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fiToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fiToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fiToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Fitting_chkBox,
            this.fitSettings_Btn});
            this.fiToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.fiToolStrip.Location = new System.Drawing.Point(3, 72);
            this.fiToolStrip.Name = "fiToolStrip";
            this.fiToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.fiToolStrip.Size = new System.Drawing.Size(213, 27);
            this.fiToolStrip.TabIndex = 0;
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
            // fitSettings_Btn
            // 
            this.fitSettings_Btn.Image = ((System.Drawing.Image)(resources.GetObject("fitSettings_Btn.Image")));
            this.fitSettings_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitSettings_Btn.Name = "fitSettings_Btn";
            this.fitSettings_Btn.Size = new System.Drawing.Size(89, 24);
            this.fitSettings_Btn.Text = "Fit Settings";
            this.fitSettings_Btn.Click += new System.EventHandler(this.fitSettings_Btn_Click);
            // 
            // fit_Btn
            // 
            this.fit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fit_Btn.BackColor = System.Drawing.Color.Teal;
            this.fit_Btn.Enabled = false;
            this.fit_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.fit_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit_Btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.fit_Btn.Location = new System.Drawing.Point(3, 20);
            this.fit_Btn.Name = "fit_Btn";
            this.fit_Btn.Size = new System.Drawing.Size(103, 21);
            this.fit_Btn.TabIndex = 1;
            this.fit_Btn.Text = "Auto fit";
            this.fit_Btn.UseVisualStyleBackColor = false;
            this.fit_Btn.Click += new System.EventHandler(this.fit_Btn_Click);
            // 
            // fit_sel_Btn
            // 
            this.fit_sel_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fit_sel_Btn.BackColor = System.Drawing.Color.CadetBlue;
            this.fit_sel_Btn.Enabled = false;
            this.fit_sel_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fit_sel_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit_sel_Btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.fit_sel_Btn.Location = new System.Drawing.Point(113, 20);
            this.fit_sel_Btn.Name = "fit_sel_Btn";
            this.fit_sel_Btn.Size = new System.Drawing.Size(103, 21);
            this.fit_sel_Btn.TabIndex = 5;
            this.fit_sel_Btn.Text = "Fit select";
            this.fit_sel_Btn.UseVisualStyleBackColor = false;
            this.fit_sel_Btn.Click += new System.EventHandler(this.fit_Btn_Click);
            // 
            // stepRange_Lbl
            // 
            this.stepRange_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stepRange_Lbl.AutoSize = true;
            this.stepRange_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepRange_Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stepRange_Lbl.Location = new System.Drawing.Point(24, 54);
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
            this.step_rangeBox.Location = new System.Drawing.Point(50, 32);
            this.step_rangeBox.Name = "step_rangeBox";
            this.step_rangeBox.Size = new System.Drawing.Size(13, 23);
            this.step_rangeBox.TabIndex = 43;
            this.step_rangeBox.Visible = false;
            this.step_rangeBox.TextChanged += new System.EventHandler(this.step_rangeBox_TextChanged);
            // 
            // fitStep_Box
            // 
            this.fitStep_Box.Enabled = false;
            this.fitStep_Box.ForeColor = System.Drawing.Color.Black;
            this.fitStep_Box.Location = new System.Drawing.Point(8, 31);
            this.fitStep_Box.Name = "fitStep_Box";
            this.fitStep_Box.Size = new System.Drawing.Size(13, 23);
            this.fitStep_Box.TabIndex = 38;
            this.fitStep_Box.Visible = false;
            this.fitStep_Box.TextChanged += new System.EventHandler(this.FitStep_Box_TextChanged);
            // 
            // fitStep_Label
            // 
            this.fitStep_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fitStep_Label.AutoSize = true;
            this.fitStep_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitStep_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fitStep_Label.Location = new System.Drawing.Point(1, 53);
            this.fitStep_Label.Name = "fitStep_Label";
            this.fitStep_Label.Size = new System.Drawing.Size(27, 13);
            this.fitStep_Label.TabIndex = 37;
            this.fitStep_Label.Text = "step";
            this.fitStep_Label.Visible = false;
            // 
            // loadFit_Btn
            // 
            this.loadFit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadFit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFit_Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadFit_Btn.Location = new System.Drawing.Point(9, 472);
            this.loadFit_Btn.Name = "loadFit_Btn";
            this.loadFit_Btn.Size = new System.Drawing.Size(68, 27);
            this.loadFit_Btn.TabIndex = 40;
            this.loadFit_Btn.Text = "Load Fit";
            this.loadFit_Btn.UseVisualStyleBackColor = true;
            this.loadFit_Btn.Visible = false;
            this.loadFit_Btn.Click += new System.EventHandler(this.loadFit_Btn_Click);
            // 
            // loadWd_Btn
            // 
            this.loadWd_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadWd_Btn.Location = new System.Drawing.Point(115, 524);
            this.loadWd_Btn.Name = "loadWd_Btn";
            this.loadWd_Btn.Size = new System.Drawing.Size(102, 23);
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
            this.saveWd_Btn.Location = new System.Drawing.Point(6, 524);
            this.saveWd_Btn.Name = "saveWd_Btn";
            this.saveWd_Btn.Size = new System.Drawing.Size(102, 23);
            this.saveWd_Btn.TabIndex = 45;
            this.saveWd_Btn.Text = "Save window";
            this.saveWd_Btn.UseVisualStyleBackColor = true;
            this.saveWd_Btn.Visible = false;
            this.saveWd_Btn.Click += new System.EventHandler(this.saveWd_Btn_Click);
            // 
            // saveFit_Btn
            // 
            this.saveFit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFit_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveFit_Btn.Enabled = false;
            this.saveFit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFit_Btn.Location = new System.Drawing.Point(7, 497);
            this.saveFit_Btn.Name = "saveFit_Btn";
            this.saveFit_Btn.Size = new System.Drawing.Size(210, 23);
            this.saveFit_Btn.TabIndex = 20;
            this.saveFit_Btn.Text = "Save Fit";
            this.saveFit_Btn.UseVisualStyleBackColor = true;
            this.saveFit_Btn.Visible = false;
            this.saveFit_Btn.Click += new System.EventHandler(this.saveFit_Btn_Click);
            // 
            // tabDiagram
            // 
            this.tabDiagram.Controls.Add(this.splitter4);
            this.tabDiagram.Controls.Add(this.panel2_tab2);
            this.tabDiagram.Controls.Add(this.panel1_tab2);
            this.tabDiagram.Location = new System.Drawing.Point(4, 22);
            this.tabDiagram.Name = "tabDiagram";
            this.tabDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagram.Size = new System.Drawing.Size(1362, 723);
            this.tabDiagram.TabIndex = 2;
            this.tabDiagram.Text = "Diagrams";
            this.tabDiagram.UseVisualStyleBackColor = true;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(780, 3);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(10, 717);
            this.splitter4.TabIndex = 25;
            this.splitter4.TabStop = false;
            // 
            // panel2_tab2
            // 
            this.panel2_tab2.AutoScroll = true;
            this.panel2_tab2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip);
            this.panel2_tab2.Controls.Add(this.ppm_panel);
            this.panel2_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab2.Location = new System.Drawing.Point(780, 3);
            this.panel2_tab2.Name = "panel2_tab2";
            this.panel2_tab2.Size = new System.Drawing.Size(579, 717);
            this.panel2_tab2.TabIndex = 1;
            // 
            // ppm_toolStrip
            // 
            this.ppm_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ppm_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ppm_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ppm_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ppm_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppmSave_Btn,
            this.ppmCopy_Btn,
            this.ppm_extract_btn});
            this.ppm_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ppm_toolStrip.Location = new System.Drawing.Point(542, 30);
            this.ppm_toolStrip.Name = "ppm_toolStrip";
            this.ppm_toolStrip.Size = new System.Drawing.Size(32, 77);
            this.ppm_toolStrip.TabIndex = 1;
            // 
            // ppmSave_Btn
            // 
            this.ppmSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ppmSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("ppmSave_Btn.Image")));
            this.ppmSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppmSave_Btn.Name = "ppmSave_Btn";
            this.ppmSave_Btn.Size = new System.Drawing.Size(30, 22);
            this.ppmSave_Btn.Text = "Save";
            // 
            // ppmCopy_Btn
            // 
            this.ppmCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ppmCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("ppmCopy_Btn.Image")));
            this.ppmCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppmCopy_Btn.Name = "ppmCopy_Btn";
            this.ppmCopy_Btn.Size = new System.Drawing.Size(30, 22);
            this.ppmCopy_Btn.Text = "Copy";
            // 
            // ppm_extract_btn
            // 
            this.ppm_extract_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ppm_extract_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem9});
            this.ppm_extract_btn.Image = ((System.Drawing.Image)(resources.GetObject("ppm_extract_btn.Image")));
            this.ppm_extract_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_extract_btn.Name = "ppm_extract_btn";
            this.ppm_extract_btn.Size = new System.Drawing.Size(30, 22);
            this.ppm_extract_btn.Text = "toolStripButton10";
            // 
            // extractPlotToolStripMenuItem9
            // 
            this.extractPlotToolStripMenuItem9.Name = "extractPlotToolStripMenuItem9";
            this.extractPlotToolStripMenuItem9.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem9.Text = "Extract plot";
            this.extractPlotToolStripMenuItem9.Click += new System.EventHandler(this.extractPlotToolStripMenuItem9_Click);
            // 
            // ppm_panel
            // 
            this.ppm_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppm_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppm_panel.Location = new System.Drawing.Point(16, 30);
            this.ppm_panel.Name = "ppm_panel";
            this.ppm_panel.Size = new System.Drawing.Size(531, 276);
            this.ppm_panel.TabIndex = 3;
            // 
            // panel1_tab2
            // 
            this.panel1_tab2.AutoScroll = true;
            this.panel1_tab2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1_tab2.Controls.Add(this.draw_sequence_panelCopy2);
            this.panel1_tab2.Controls.Add(this.draw_sequence_panelCopy1);
            this.panel1_tab2.Controls.Add(this.draw_sequence_panel);
            this.panel1_tab2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1_tab2.Location = new System.Drawing.Point(3, 3);
            this.panel1_tab2.Name = "panel1_tab2";
            this.panel1_tab2.Size = new System.Drawing.Size(777, 717);
            this.panel1_tab2.TabIndex = 0;
            // 
            // draw_sequence_panelCopy2
            // 
            this.draw_sequence_panelCopy2.AutoScroll = true;
            this.draw_sequence_panelCopy2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_sequence_panelCopy2.Controls.Add(this.light_chkBoxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.heavy_chkBoxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.los_chkBoxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.delele_sequencePnl2);
            this.draw_sequence_panelCopy2.Controls.Add(this.rdBtn50Copy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.rdBtn25Copy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.sequence_toolStripCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.seq_LblCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.ax_chBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.by_chBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.cz_chBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.intA_chBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.intB_chBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.sequence_PnlCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.draw_BtnCopy2);
            this.draw_sequence_panelCopy2.Dock = System.Windows.Forms.DockStyle.Top;
            this.draw_sequence_panelCopy2.Location = new System.Drawing.Point(0, 1000);
            this.draw_sequence_panelCopy2.Name = "draw_sequence_panelCopy2";
            this.draw_sequence_panelCopy2.Size = new System.Drawing.Size(760, 500);
            this.draw_sequence_panelCopy2.TabIndex = 12;
            this.draw_sequence_panelCopy2.Visible = false;
            // 
            // light_chkBoxCopy2
            // 
            this.light_chkBoxCopy2.AutoSize = true;
            this.light_chkBoxCopy2.Location = new System.Drawing.Point(10, 234);
            this.light_chkBoxCopy2.Name = "light_chkBoxCopy2";
            this.light_chkBoxCopy2.Size = new System.Drawing.Size(79, 17);
            this.light_chkBoxCopy2.TabIndex = 18;
            this.light_chkBoxCopy2.Text = "Light Chain";
            this.light_chkBoxCopy2.UseVisualStyleBackColor = true;
            this.light_chkBoxCopy2.CheckedChanged += new System.EventHandler(this.light_chkBoxCopy2_CheckedChanged);
            // 
            // heavy_chkBoxCopy2
            // 
            this.heavy_chkBoxCopy2.AutoSize = true;
            this.heavy_chkBoxCopy2.Location = new System.Drawing.Point(10, 211);
            this.heavy_chkBoxCopy2.Name = "heavy_chkBoxCopy2";
            this.heavy_chkBoxCopy2.Size = new System.Drawing.Size(87, 17);
            this.heavy_chkBoxCopy2.TabIndex = 17;
            this.heavy_chkBoxCopy2.Text = "Heavy Chain";
            this.heavy_chkBoxCopy2.UseVisualStyleBackColor = true;
            this.heavy_chkBoxCopy2.CheckedChanged += new System.EventHandler(this.heavy_chkBoxCopy2_CheckedChanged);
            // 
            // los_chkBoxCopy2
            // 
            this.los_chkBoxCopy2.AutoSize = true;
            this.los_chkBoxCopy2.Location = new System.Drawing.Point(10, 142);
            this.los_chkBoxCopy2.Name = "los_chkBoxCopy2";
            this.los_chkBoxCopy2.Size = new System.Drawing.Size(55, 17);
            this.los_chkBoxCopy2.TabIndex = 16;
            this.los_chkBoxCopy2.Text = "losses";
            this.los_chkBoxCopy2.UseVisualStyleBackColor = true;
            this.los_chkBoxCopy2.CheckedChanged += new System.EventHandler(this.los_chkBoxCopy2_CheckedChanged);
            // 
            // delele_sequencePnl2
            // 
            this.delele_sequencePnl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delele_sequencePnl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delele_sequencePnl2.BackgroundImage")));
            this.delele_sequencePnl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delele_sequencePnl2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delele_sequencePnl2.Location = new System.Drawing.Point(723, 467);
            this.delele_sequencePnl2.Name = "delele_sequencePnl2";
            this.delele_sequencePnl2.Size = new System.Drawing.Size(29, 28);
            this.delele_sequencePnl2.TabIndex = 13;
            this.delele_sequencePnl2.UseVisualStyleBackColor = true;
            this.delele_sequencePnl2.Click += new System.EventHandler(this.delele_sequencePnl2_Click);
            // 
            // rdBtn50Copy2
            // 
            this.rdBtn50Copy2.AutoSize = true;
            this.rdBtn50Copy2.Location = new System.Drawing.Point(7, 318);
            this.rdBtn50Copy2.Name = "rdBtn50Copy2";
            this.rdBtn50Copy2.Size = new System.Drawing.Size(37, 17);
            this.rdBtn50Copy2.TabIndex = 10;
            this.rdBtn50Copy2.Text = "50";
            this.rdBtn50Copy2.UseVisualStyleBackColor = true;
            this.rdBtn50Copy2.CheckedChanged += new System.EventHandler(this.rdBtn50Copy2_CheckedChanged);
            // 
            // rdBtn25Copy2
            // 
            this.rdBtn25Copy2.AutoSize = true;
            this.rdBtn25Copy2.Checked = true;
            this.rdBtn25Copy2.Location = new System.Drawing.Point(7, 295);
            this.rdBtn25Copy2.Name = "rdBtn25Copy2";
            this.rdBtn25Copy2.Size = new System.Drawing.Size(37, 17);
            this.rdBtn25Copy2.TabIndex = 9;
            this.rdBtn25Copy2.TabStop = true;
            this.rdBtn25Copy2.Text = "25";
            this.rdBtn25Copy2.UseVisualStyleBackColor = true;
            this.rdBtn25Copy2.CheckedChanged += new System.EventHandler(this.rdBtn25Copy2_CheckedChanged);
            // 
            // sequence_toolStripCopy2
            // 
            this.sequence_toolStripCopy2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_toolStripCopy2.Dock = System.Windows.Forms.DockStyle.None;
            this.sequence_toolStripCopy2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sequence_toolStripCopy2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.sequence_toolStripCopy2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seqSave_BtnCopy2,
            this.seqCopy_BtnCopy2});
            this.sequence_toolStripCopy2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sequence_toolStripCopy2.Location = new System.Drawing.Point(728, 27);
            this.sequence_toolStripCopy2.Name = "sequence_toolStripCopy2";
            this.sequence_toolStripCopy2.Size = new System.Drawing.Size(24, 52);
            this.sequence_toolStripCopy2.TabIndex = 8;
            // 
            // seqSave_BtnCopy2
            // 
            this.seqSave_BtnCopy2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqSave_BtnCopy2.Image = ((System.Drawing.Image)(resources.GetObject("seqSave_BtnCopy2.Image")));
            this.seqSave_BtnCopy2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqSave_BtnCopy2.Name = "seqSave_BtnCopy2";
            this.seqSave_BtnCopy2.Size = new System.Drawing.Size(22, 22);
            this.seqSave_BtnCopy2.Text = "Save";
            // 
            // seqCopy_BtnCopy2
            // 
            this.seqCopy_BtnCopy2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqCopy_BtnCopy2.Image = ((System.Drawing.Image)(resources.GetObject("seqCopy_BtnCopy2.Image")));
            this.seqCopy_BtnCopy2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqCopy_BtnCopy2.Name = "seqCopy_BtnCopy2";
            this.seqCopy_BtnCopy2.Size = new System.Drawing.Size(22, 22);
            this.seqCopy_BtnCopy2.Text = "Copy";
            // 
            // seq_LblCopy2
            // 
            this.seq_LblCopy2.AutoSize = true;
            this.seq_LblCopy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_LblCopy2.ForeColor = System.Drawing.Color.DarkCyan;
            this.seq_LblCopy2.Location = new System.Drawing.Point(6, 13);
            this.seq_LblCopy2.Name = "seq_LblCopy2";
            this.seq_LblCopy2.Size = new System.Drawing.Size(82, 20);
            this.seq_LblCopy2.TabIndex = 0;
            this.seq_LblCopy2.Text = "Sequence";
            // 
            // ax_chBxCopy2
            // 
            this.ax_chBxCopy2.AutoSize = true;
            this.ax_chBxCopy2.Location = new System.Drawing.Point(10, 37);
            this.ax_chBxCopy2.Name = "ax_chBxCopy2";
            this.ax_chBxCopy2.Size = new System.Drawing.Size(46, 17);
            this.ax_chBxCopy2.TabIndex = 1;
            this.ax_chBxCopy2.Text = "a - x";
            this.ax_chBxCopy2.UseVisualStyleBackColor = true;
            this.ax_chBxCopy2.CheckedChanged += new System.EventHandler(this.ax_chBxCopy2_CheckedChanged);
            // 
            // by_chBxCopy2
            // 
            this.by_chBxCopy2.AutoSize = true;
            this.by_chBxCopy2.Location = new System.Drawing.Point(10, 58);
            this.by_chBxCopy2.Name = "by_chBxCopy2";
            this.by_chBxCopy2.Size = new System.Drawing.Size(46, 17);
            this.by_chBxCopy2.TabIndex = 2;
            this.by_chBxCopy2.Text = "b - y";
            this.by_chBxCopy2.UseVisualStyleBackColor = true;
            this.by_chBxCopy2.CheckedChanged += new System.EventHandler(this.by_chBxCopy2_CheckedChanged);
            // 
            // cz_chBxCopy2
            // 
            this.cz_chBxCopy2.AutoSize = true;
            this.cz_chBxCopy2.Location = new System.Drawing.Point(10, 79);
            this.cz_chBxCopy2.Name = "cz_chBxCopy2";
            this.cz_chBxCopy2.Size = new System.Drawing.Size(46, 17);
            this.cz_chBxCopy2.TabIndex = 3;
            this.cz_chBxCopy2.Text = "c - z";
            this.cz_chBxCopy2.UseVisualStyleBackColor = true;
            this.cz_chBxCopy2.CheckedChanged += new System.EventHandler(this.cz_chBxCopy2_CheckedChanged);
            // 
            // intA_chBxCopy2
            // 
            this.intA_chBxCopy2.AutoSize = true;
            this.intA_chBxCopy2.Location = new System.Drawing.Point(10, 100);
            this.intA_chBxCopy2.Name = "intA_chBxCopy2";
            this.intA_chBxCopy2.Size = new System.Drawing.Size(69, 17);
            this.intA_chBxCopy2.TabIndex = 4;
            this.intA_chBxCopy2.Text = "internal a";
            this.intA_chBxCopy2.UseVisualStyleBackColor = true;
            // 
            // intB_chBxCopy2
            // 
            this.intB_chBxCopy2.AutoSize = true;
            this.intB_chBxCopy2.Location = new System.Drawing.Point(10, 121);
            this.intB_chBxCopy2.Name = "intB_chBxCopy2";
            this.intB_chBxCopy2.Size = new System.Drawing.Size(69, 17);
            this.intB_chBxCopy2.TabIndex = 5;
            this.intB_chBxCopy2.Text = "internal b";
            this.intB_chBxCopy2.UseVisualStyleBackColor = true;
            // 
            // sequence_PnlCopy2
            // 
            this.sequence_PnlCopy2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_PnlCopy2.AutoScroll = true;
            this.sequence_PnlCopy2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sequence_PnlCopy2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_PnlCopy2.Location = new System.Drawing.Point(103, 27);
            this.sequence_PnlCopy2.Name = "sequence_PnlCopy2";
            this.sequence_PnlCopy2.Size = new System.Drawing.Size(614, 455);
            this.sequence_PnlCopy2.TabIndex = 7;
            this.sequence_PnlCopy2.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_PnlCopy2_Paint);
            this.sequence_PnlCopy2.Resize += new System.EventHandler(this.sequence_PnlCopy2_Resize);
            // 
            // draw_BtnCopy2
            // 
            this.draw_BtnCopy2.BackColor = System.Drawing.Color.Teal;
            this.draw_BtnCopy2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_BtnCopy2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_BtnCopy2.Location = new System.Drawing.Point(10, 163);
            this.draw_BtnCopy2.Name = "draw_BtnCopy2";
            this.draw_BtnCopy2.Size = new System.Drawing.Size(69, 20);
            this.draw_BtnCopy2.TabIndex = 6;
            this.draw_BtnCopy2.Text = "Draw";
            this.draw_BtnCopy2.UseVisualStyleBackColor = false;
            this.draw_BtnCopy2.Click += new System.EventHandler(this.draw_BtnCopy2_Click);
            // 
            // draw_sequence_panelCopy1
            // 
            this.draw_sequence_panelCopy1.AutoScroll = true;
            this.draw_sequence_panelCopy1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_sequence_panelCopy1.Controls.Add(this.light_chkBoxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.heavy_chkBoxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.los_chkBoxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.delele_sequencePnl1);
            this.draw_sequence_panelCopy1.Controls.Add(this.rdBtn50Copy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.rdBtn25Copy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.sequence_toolStripCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.seq_LblCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.ax_chBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.by_chBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.cz_chBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.intA_chBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.intB_chBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.sequence_PnlCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.draw_BtnCopy1);
            this.draw_sequence_panelCopy1.Dock = System.Windows.Forms.DockStyle.Top;
            this.draw_sequence_panelCopy1.Location = new System.Drawing.Point(0, 500);
            this.draw_sequence_panelCopy1.Name = "draw_sequence_panelCopy1";
            this.draw_sequence_panelCopy1.Size = new System.Drawing.Size(760, 500);
            this.draw_sequence_panelCopy1.TabIndex = 11;
            this.draw_sequence_panelCopy1.Visible = false;
            this.draw_sequence_panelCopy1.DpiChangedAfterParent += new System.EventHandler(this.draw_sequence_panelCopy1_DpiChangedAfterParent);
            // 
            // light_chkBoxCopy1
            // 
            this.light_chkBoxCopy1.AutoSize = true;
            this.light_chkBoxCopy1.Location = new System.Drawing.Point(10, 232);
            this.light_chkBoxCopy1.Name = "light_chkBoxCopy1";
            this.light_chkBoxCopy1.Size = new System.Drawing.Size(79, 17);
            this.light_chkBoxCopy1.TabIndex = 17;
            this.light_chkBoxCopy1.Text = "Light Chain";
            this.light_chkBoxCopy1.UseVisualStyleBackColor = true;
            this.light_chkBoxCopy1.CheckedChanged += new System.EventHandler(this.light_chkBoxCopy1_CheckedChanged);
            // 
            // heavy_chkBoxCopy1
            // 
            this.heavy_chkBoxCopy1.AutoSize = true;
            this.heavy_chkBoxCopy1.Location = new System.Drawing.Point(10, 209);
            this.heavy_chkBoxCopy1.Name = "heavy_chkBoxCopy1";
            this.heavy_chkBoxCopy1.Size = new System.Drawing.Size(87, 17);
            this.heavy_chkBoxCopy1.TabIndex = 16;
            this.heavy_chkBoxCopy1.Text = "Heavy Chain";
            this.heavy_chkBoxCopy1.UseVisualStyleBackColor = true;
            this.heavy_chkBoxCopy1.CheckedChanged += new System.EventHandler(this.heavy_chkBoxCopy1_CheckedChanged);
            // 
            // los_chkBoxCopy1
            // 
            this.los_chkBoxCopy1.AutoSize = true;
            this.los_chkBoxCopy1.Location = new System.Drawing.Point(10, 142);
            this.los_chkBoxCopy1.Name = "los_chkBoxCopy1";
            this.los_chkBoxCopy1.Size = new System.Drawing.Size(55, 17);
            this.los_chkBoxCopy1.TabIndex = 15;
            this.los_chkBoxCopy1.Text = "losses";
            this.los_chkBoxCopy1.UseVisualStyleBackColor = true;
            this.los_chkBoxCopy1.CheckedChanged += new System.EventHandler(this.los_chkBoxCopy1_CheckedChanged);
            // 
            // delele_sequencePnl1
            // 
            this.delele_sequencePnl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delele_sequencePnl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delele_sequencePnl1.BackgroundImage")));
            this.delele_sequencePnl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delele_sequencePnl1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delele_sequencePnl1.Location = new System.Drawing.Point(723, 466);
            this.delele_sequencePnl1.Name = "delele_sequencePnl1";
            this.delele_sequencePnl1.Size = new System.Drawing.Size(29, 28);
            this.delele_sequencePnl1.TabIndex = 14;
            this.delele_sequencePnl1.UseVisualStyleBackColor = true;
            this.delele_sequencePnl1.Click += new System.EventHandler(this.delele_sequencePnl1_Click);
            // 
            // rdBtn50Copy1
            // 
            this.rdBtn50Copy1.AutoSize = true;
            this.rdBtn50Copy1.Location = new System.Drawing.Point(7, 305);
            this.rdBtn50Copy1.Name = "rdBtn50Copy1";
            this.rdBtn50Copy1.Size = new System.Drawing.Size(37, 17);
            this.rdBtn50Copy1.TabIndex = 10;
            this.rdBtn50Copy1.Text = "50";
            this.rdBtn50Copy1.UseVisualStyleBackColor = true;
            this.rdBtn50Copy1.CheckedChanged += new System.EventHandler(this.rdBtn50Copy1_CheckedChanged);
            // 
            // rdBtn25Copy1
            // 
            this.rdBtn25Copy1.AutoSize = true;
            this.rdBtn25Copy1.Checked = true;
            this.rdBtn25Copy1.Location = new System.Drawing.Point(7, 282);
            this.rdBtn25Copy1.Name = "rdBtn25Copy1";
            this.rdBtn25Copy1.Size = new System.Drawing.Size(37, 17);
            this.rdBtn25Copy1.TabIndex = 9;
            this.rdBtn25Copy1.TabStop = true;
            this.rdBtn25Copy1.Text = "25";
            this.rdBtn25Copy1.UseVisualStyleBackColor = true;
            this.rdBtn25Copy1.CheckedChanged += new System.EventHandler(this.rdBtn25Copy1_CheckedChanged);
            // 
            // sequence_toolStripCopy1
            // 
            this.sequence_toolStripCopy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_toolStripCopy1.Dock = System.Windows.Forms.DockStyle.None;
            this.sequence_toolStripCopy1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sequence_toolStripCopy1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.sequence_toolStripCopy1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seqSave_BtnCopy1,
            this.seqCopy_BtnCopy1});
            this.sequence_toolStripCopy1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sequence_toolStripCopy1.Location = new System.Drawing.Point(728, 27);
            this.sequence_toolStripCopy1.Name = "sequence_toolStripCopy1";
            this.sequence_toolStripCopy1.Size = new System.Drawing.Size(24, 52);
            this.sequence_toolStripCopy1.TabIndex = 8;
            // 
            // seqSave_BtnCopy1
            // 
            this.seqSave_BtnCopy1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqSave_BtnCopy1.Image = ((System.Drawing.Image)(resources.GetObject("seqSave_BtnCopy1.Image")));
            this.seqSave_BtnCopy1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqSave_BtnCopy1.Name = "seqSave_BtnCopy1";
            this.seqSave_BtnCopy1.Size = new System.Drawing.Size(22, 22);
            this.seqSave_BtnCopy1.Text = "Save";
            // 
            // seqCopy_BtnCopy1
            // 
            this.seqCopy_BtnCopy1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqCopy_BtnCopy1.Image = ((System.Drawing.Image)(resources.GetObject("seqCopy_BtnCopy1.Image")));
            this.seqCopy_BtnCopy1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqCopy_BtnCopy1.Name = "seqCopy_BtnCopy1";
            this.seqCopy_BtnCopy1.Size = new System.Drawing.Size(22, 22);
            this.seqCopy_BtnCopy1.Text = "Copy";
            // 
            // seq_LblCopy1
            // 
            this.seq_LblCopy1.AutoSize = true;
            this.seq_LblCopy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_LblCopy1.ForeColor = System.Drawing.Color.DarkCyan;
            this.seq_LblCopy1.Location = new System.Drawing.Point(6, 13);
            this.seq_LblCopy1.Name = "seq_LblCopy1";
            this.seq_LblCopy1.Size = new System.Drawing.Size(82, 20);
            this.seq_LblCopy1.TabIndex = 0;
            this.seq_LblCopy1.Text = "Sequence";
            // 
            // ax_chBxCopy1
            // 
            this.ax_chBxCopy1.AutoSize = true;
            this.ax_chBxCopy1.Location = new System.Drawing.Point(10, 37);
            this.ax_chBxCopy1.Name = "ax_chBxCopy1";
            this.ax_chBxCopy1.Size = new System.Drawing.Size(46, 17);
            this.ax_chBxCopy1.TabIndex = 1;
            this.ax_chBxCopy1.Text = "a - x";
            this.ax_chBxCopy1.UseVisualStyleBackColor = true;
            this.ax_chBxCopy1.CheckedChanged += new System.EventHandler(this.ax_chBxCopy1_CheckedChanged);
            // 
            // by_chBxCopy1
            // 
            this.by_chBxCopy1.AutoSize = true;
            this.by_chBxCopy1.Location = new System.Drawing.Point(10, 58);
            this.by_chBxCopy1.Name = "by_chBxCopy1";
            this.by_chBxCopy1.Size = new System.Drawing.Size(46, 17);
            this.by_chBxCopy1.TabIndex = 2;
            this.by_chBxCopy1.Text = "b - y";
            this.by_chBxCopy1.UseVisualStyleBackColor = true;
            this.by_chBxCopy1.CheckedChanged += new System.EventHandler(this.by_chBxCopy1_CheckedChanged);
            // 
            // cz_chBxCopy1
            // 
            this.cz_chBxCopy1.AutoSize = true;
            this.cz_chBxCopy1.Location = new System.Drawing.Point(10, 79);
            this.cz_chBxCopy1.Name = "cz_chBxCopy1";
            this.cz_chBxCopy1.Size = new System.Drawing.Size(46, 17);
            this.cz_chBxCopy1.TabIndex = 3;
            this.cz_chBxCopy1.Text = "c - z";
            this.cz_chBxCopy1.UseVisualStyleBackColor = true;
            this.cz_chBxCopy1.CheckedChanged += new System.EventHandler(this.cz_chBxCopy1_CheckedChanged);
            // 
            // intA_chBxCopy1
            // 
            this.intA_chBxCopy1.AutoSize = true;
            this.intA_chBxCopy1.Location = new System.Drawing.Point(10, 100);
            this.intA_chBxCopy1.Name = "intA_chBxCopy1";
            this.intA_chBxCopy1.Size = new System.Drawing.Size(69, 17);
            this.intA_chBxCopy1.TabIndex = 4;
            this.intA_chBxCopy1.Text = "internal a";
            this.intA_chBxCopy1.UseVisualStyleBackColor = true;
            // 
            // intB_chBxCopy1
            // 
            this.intB_chBxCopy1.AutoSize = true;
            this.intB_chBxCopy1.Location = new System.Drawing.Point(10, 121);
            this.intB_chBxCopy1.Name = "intB_chBxCopy1";
            this.intB_chBxCopy1.Size = new System.Drawing.Size(69, 17);
            this.intB_chBxCopy1.TabIndex = 5;
            this.intB_chBxCopy1.Text = "internal b";
            this.intB_chBxCopy1.UseVisualStyleBackColor = true;
            // 
            // sequence_PnlCopy1
            // 
            this.sequence_PnlCopy1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_PnlCopy1.AutoScroll = true;
            this.sequence_PnlCopy1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sequence_PnlCopy1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_PnlCopy1.Location = new System.Drawing.Point(103, 27);
            this.sequence_PnlCopy1.Name = "sequence_PnlCopy1";
            this.sequence_PnlCopy1.Size = new System.Drawing.Size(614, 455);
            this.sequence_PnlCopy1.TabIndex = 7;
            this.sequence_PnlCopy1.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_PnlCopy1_Paint);
            this.sequence_PnlCopy1.Resize += new System.EventHandler(this.sequence_PnlCopy1_Resize);
            // 
            // draw_BtnCopy1
            // 
            this.draw_BtnCopy1.BackColor = System.Drawing.Color.Teal;
            this.draw_BtnCopy1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_BtnCopy1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_BtnCopy1.Location = new System.Drawing.Point(10, 163);
            this.draw_BtnCopy1.Name = "draw_BtnCopy1";
            this.draw_BtnCopy1.Size = new System.Drawing.Size(69, 20);
            this.draw_BtnCopy1.TabIndex = 6;
            this.draw_BtnCopy1.Text = "Draw";
            this.draw_BtnCopy1.UseVisualStyleBackColor = false;
            this.draw_BtnCopy1.Click += new System.EventHandler(this.draw_BtnCopy1_Click);
            // 
            // draw_sequence_panel
            // 
            this.draw_sequence_panel.AutoScroll = true;
            this.draw_sequence_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_sequence_panel.Controls.Add(this.light_chkBox);
            this.draw_sequence_panel.Controls.Add(this.heavy_chkBox);
            this.draw_sequence_panel.Controls.Add(this.los_chkBox);
            this.draw_sequence_panel.Controls.Add(this.add_sequencePanel1);
            this.draw_sequence_panel.Controls.Add(this.rdBtn50);
            this.draw_sequence_panel.Controls.Add(this.rdBtn25);
            this.draw_sequence_panel.Controls.Add(this.sequence_toolStrip);
            this.draw_sequence_panel.Controls.Add(this.seq_Lbl);
            this.draw_sequence_panel.Controls.Add(this.ax_chBx);
            this.draw_sequence_panel.Controls.Add(this.by_chBx);
            this.draw_sequence_panel.Controls.Add(this.cz_chBx);
            this.draw_sequence_panel.Controls.Add(this.intA_chBx);
            this.draw_sequence_panel.Controls.Add(this.intB_chBx);
            this.draw_sequence_panel.Controls.Add(this.sequence_Pnl);
            this.draw_sequence_panel.Controls.Add(this.draw_Btn);
            this.draw_sequence_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.draw_sequence_panel.Location = new System.Drawing.Point(0, 0);
            this.draw_sequence_panel.Name = "draw_sequence_panel";
            this.draw_sequence_panel.Size = new System.Drawing.Size(760, 500);
            this.draw_sequence_panel.TabIndex = 10;
            // 
            // light_chkBox
            // 
            this.light_chkBox.AutoSize = true;
            this.light_chkBox.Location = new System.Drawing.Point(10, 227);
            this.light_chkBox.Name = "light_chkBox";
            this.light_chkBox.Size = new System.Drawing.Size(79, 17);
            this.light_chkBox.TabIndex = 14;
            this.light_chkBox.Text = "Light Chain";
            this.light_chkBox.UseVisualStyleBackColor = true;
            this.light_chkBox.CheckedChanged += new System.EventHandler(this.light_chkBox_CheckedChanged);
            // 
            // heavy_chkBox
            // 
            this.heavy_chkBox.AutoSize = true;
            this.heavy_chkBox.Location = new System.Drawing.Point(10, 204);
            this.heavy_chkBox.Name = "heavy_chkBox";
            this.heavy_chkBox.Size = new System.Drawing.Size(87, 17);
            this.heavy_chkBox.TabIndex = 13;
            this.heavy_chkBox.Text = "Heavy Chain";
            this.heavy_chkBox.UseVisualStyleBackColor = true;
            this.heavy_chkBox.CheckedChanged += new System.EventHandler(this.heavy_chkBox_CheckedChanged);
            // 
            // los_chkBox
            // 
            this.los_chkBox.AutoSize = true;
            this.los_chkBox.Location = new System.Drawing.Point(10, 142);
            this.los_chkBox.Name = "los_chkBox";
            this.los_chkBox.Size = new System.Drawing.Size(55, 17);
            this.los_chkBox.TabIndex = 12;
            this.los_chkBox.Text = "losses";
            this.los_chkBox.UseVisualStyleBackColor = true;
            this.los_chkBox.CheckedChanged += new System.EventHandler(this.los_chkBox_CheckedChanged);
            // 
            // add_sequencePanel1
            // 
            this.add_sequencePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("add_sequencePanel1.BackgroundImage")));
            this.add_sequencePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.add_sequencePanel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_sequencePanel1.Location = new System.Drawing.Point(7, 343);
            this.add_sequencePanel1.Name = "add_sequencePanel1";
            this.add_sequencePanel1.Size = new System.Drawing.Size(29, 28);
            this.add_sequencePanel1.TabIndex = 11;
            this.add_sequencePanel1.UseVisualStyleBackColor = true;
            this.add_sequencePanel1.Click += new System.EventHandler(this.add_sequencePanel1_Click);
            // 
            // rdBtn50
            // 
            this.rdBtn50.AutoSize = true;
            this.rdBtn50.Location = new System.Drawing.Point(7, 309);
            this.rdBtn50.Name = "rdBtn50";
            this.rdBtn50.Size = new System.Drawing.Size(37, 17);
            this.rdBtn50.TabIndex = 10;
            this.rdBtn50.Text = "50";
            this.rdBtn50.UseVisualStyleBackColor = true;
            this.rdBtn50.CheckedChanged += new System.EventHandler(this.rdBtn50_CheckedChanged);
            // 
            // rdBtn25
            // 
            this.rdBtn25.AutoSize = true;
            this.rdBtn25.Checked = true;
            this.rdBtn25.Location = new System.Drawing.Point(7, 286);
            this.rdBtn25.Name = "rdBtn25";
            this.rdBtn25.Size = new System.Drawing.Size(37, 17);
            this.rdBtn25.TabIndex = 9;
            this.rdBtn25.TabStop = true;
            this.rdBtn25.Text = "25";
            this.rdBtn25.UseVisualStyleBackColor = true;
            this.rdBtn25.CheckedChanged += new System.EventHandler(this.rdBtn25_CheckedChanged);
            // 
            // sequence_toolStrip
            // 
            this.sequence_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequence_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.sequence_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sequence_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.sequence_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seqSave_Btn,
            this.seqCopy_Btn,
            this.seq_coverageBtn});
            this.sequence_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sequence_toolStrip.Location = new System.Drawing.Point(728, 27);
            this.sequence_toolStrip.Name = "sequence_toolStrip";
            this.sequence_toolStrip.Size = new System.Drawing.Size(24, 77);
            this.sequence_toolStrip.TabIndex = 8;
            // 
            // seqSave_Btn
            // 
            this.seqSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("seqSave_Btn.Image")));
            this.seqSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqSave_Btn.Name = "seqSave_Btn";
            this.seqSave_Btn.Size = new System.Drawing.Size(22, 22);
            this.seqSave_Btn.Text = "Save";
            // 
            // seqCopy_Btn
            // 
            this.seqCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seqCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("seqCopy_Btn.Image")));
            this.seqCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seqCopy_Btn.Name = "seqCopy_Btn";
            this.seqCopy_Btn.Size = new System.Drawing.Size(22, 22);
            this.seqCopy_Btn.Text = "Copy";
            // 
            // seq_coverageBtn
            // 
            this.seq_coverageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seq_coverageBtn.Image = ((System.Drawing.Image)(resources.GetObject("seq_coverageBtn.Image")));
            this.seq_coverageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seq_coverageBtn.Name = "seq_coverageBtn";
            this.seq_coverageBtn.Size = new System.Drawing.Size(22, 22);
            this.seq_coverageBtn.Text = "toolStripButton10";
            this.seq_coverageBtn.Click += new System.EventHandler(this.seq_coverageBtn_Click);
            // 
            // seq_Lbl
            // 
            this.seq_Lbl.AutoSize = true;
            this.seq_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_Lbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.seq_Lbl.Location = new System.Drawing.Point(6, 13);
            this.seq_Lbl.Name = "seq_Lbl";
            this.seq_Lbl.Size = new System.Drawing.Size(82, 20);
            this.seq_Lbl.TabIndex = 0;
            this.seq_Lbl.Text = "Sequence";
            // 
            // ax_chBx
            // 
            this.ax_chBx.AutoSize = true;
            this.ax_chBx.Location = new System.Drawing.Point(10, 37);
            this.ax_chBx.Name = "ax_chBx";
            this.ax_chBx.Size = new System.Drawing.Size(46, 17);
            this.ax_chBx.TabIndex = 1;
            this.ax_chBx.Text = "a - x";
            this.ax_chBx.UseVisualStyleBackColor = true;
            this.ax_chBx.CheckedChanged += new System.EventHandler(this.ax_chBx_CheckedChanged);
            // 
            // by_chBx
            // 
            this.by_chBx.AutoSize = true;
            this.by_chBx.Location = new System.Drawing.Point(10, 58);
            this.by_chBx.Name = "by_chBx";
            this.by_chBx.Size = new System.Drawing.Size(46, 17);
            this.by_chBx.TabIndex = 2;
            this.by_chBx.Text = "b - y";
            this.by_chBx.UseVisualStyleBackColor = true;
            this.by_chBx.CheckedChanged += new System.EventHandler(this.by_chBx_CheckedChanged);
            // 
            // cz_chBx
            // 
            this.cz_chBx.AutoSize = true;
            this.cz_chBx.Location = new System.Drawing.Point(10, 79);
            this.cz_chBx.Name = "cz_chBx";
            this.cz_chBx.Size = new System.Drawing.Size(46, 17);
            this.cz_chBx.TabIndex = 3;
            this.cz_chBx.Text = "c - z";
            this.cz_chBx.UseVisualStyleBackColor = true;
            this.cz_chBx.CheckedChanged += new System.EventHandler(this.cz_chBx_CheckedChanged);
            // 
            // intA_chBx
            // 
            this.intA_chBx.AutoSize = true;
            this.intA_chBx.Location = new System.Drawing.Point(10, 100);
            this.intA_chBx.Name = "intA_chBx";
            this.intA_chBx.Size = new System.Drawing.Size(69, 17);
            this.intA_chBx.TabIndex = 4;
            this.intA_chBx.Text = "internal a";
            this.intA_chBx.UseVisualStyleBackColor = true;
            // 
            // intB_chBx
            // 
            this.intB_chBx.AutoSize = true;
            this.intB_chBx.Location = new System.Drawing.Point(10, 121);
            this.intB_chBx.Name = "intB_chBx";
            this.intB_chBx.Size = new System.Drawing.Size(69, 17);
            this.intB_chBx.TabIndex = 5;
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
            this.sequence_Pnl.Location = new System.Drawing.Point(103, 27);
            this.sequence_Pnl.Name = "sequence_Pnl";
            this.sequence_Pnl.Size = new System.Drawing.Size(614, 455);
            this.sequence_Pnl.TabIndex = 7;
            this.sequence_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_Pnl_Paint);
            this.sequence_Pnl.Resize += new System.EventHandler(this.sequence_Pnl_Resize);
            // 
            // draw_Btn
            // 
            this.draw_Btn.BackColor = System.Drawing.Color.Teal;
            this.draw_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_Btn.Location = new System.Drawing.Point(10, 163);
            this.draw_Btn.Name = "draw_Btn";
            this.draw_Btn.Size = new System.Drawing.Size(69, 20);
            this.draw_Btn.TabIndex = 6;
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
            this.tabPrimary.Size = new System.Drawing.Size(1362, 723);
            this.tabPrimary.TabIndex = 3;
            this.tabPrimary.Text = "Primary Fragments";
            this.tabPrimary.UseVisualStyleBackColor = true;
            // 
            // panel2_tab3
            // 
            this.panel2_tab3.AutoScroll = true;
            this.panel2_tab3.Controls.Add(this.czCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.byCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.axCharge_toolStrip);
            this.panel2_tab3.Controls.Add(this.czCharge_Pnl);
            this.panel2_tab3.Controls.Add(this.byCharge_Pnl);
            this.panel2_tab3.Controls.Add(this.axCharge_Pnl);
            this.panel2_tab3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab3.Location = new System.Drawing.Point(756, 3);
            this.panel2_tab3.Name = "panel2_tab3";
            this.panel2_tab3.Size = new System.Drawing.Size(603, 717);
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
            this.toolStripButton9,
            this.c_Btn,
            this.z_Btn,
            this.czcharge_X_Box,
            this.czcharge_Y_Box});
            this.czCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.czCharge_toolStrip.Location = new System.Drawing.Point(407, 531);
            this.czCharge_toolStrip.Name = "czCharge_toolStrip";
            this.czCharge_toolStrip.Size = new System.Drawing.Size(43, 175);
            this.czCharge_toolStrip.TabIndex = 24;
            // 
            // czChargeSave_Btn
            // 
            this.czChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeSave_Btn.Image")));
            this.czChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeSave_Btn.Name = "czChargeSave_Btn";
            this.czChargeSave_Btn.Size = new System.Drawing.Size(41, 22);
            this.czChargeSave_Btn.Text = "Save";
            // 
            // czChargeCopy_Btn
            // 
            this.czChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeCopy_Btn.Image")));
            this.czChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeCopy_Btn.Name = "czChargeCopy_Btn";
            this.czChargeCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.czChargeCopy_Btn.Text = "Copy";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem6});
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton9.Text = "toolStripButton9";
            // 
            // extractPlotToolStripMenuItem6
            // 
            this.extractPlotToolStripMenuItem6.Name = "extractPlotToolStripMenuItem6";
            this.extractPlotToolStripMenuItem6.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem6.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem6.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem6.Click += new System.EventHandler(this.extractPlotToolStripMenuItem6_Click);
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
            this.c_Btn.Size = new System.Drawing.Size(41, 24);
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
            this.z_Btn.Size = new System.Drawing.Size(41, 24);
            this.z_Btn.Text = "z";
            // 
            // czcharge_X_Box
            // 
            this.czcharge_X_Box.AutoSize = false;
            this.czcharge_X_Box.Name = "czcharge_X_Box";
            this.czcharge_X_Box.ReadOnly = true;
            this.czcharge_X_Box.Size = new System.Drawing.Size(40, 22);
            this.czcharge_X_Box.ToolTipText = "Width";
            // 
            // czcharge_Y_Box
            // 
            this.czcharge_Y_Box.AutoSize = false;
            this.czcharge_Y_Box.Name = "czcharge_Y_Box";
            this.czcharge_Y_Box.ReadOnly = true;
            this.czcharge_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.czcharge_Y_Box.ToolTipText = "Height";
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
            this.toolStripButton7,
            this.b_Btn,
            this.y_Btn,
            this.bycharge_X_Box,
            this.bycharge_Y_Box});
            this.byCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.byCharge_toolStrip.Location = new System.Drawing.Point(407, 269);
            this.byCharge_toolStrip.Name = "byCharge_toolStrip";
            this.byCharge_toolStrip.Size = new System.Drawing.Size(43, 175);
            this.byCharge_toolStrip.TabIndex = 25;
            // 
            // byChargeSave_Btn
            // 
            this.byChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeSave_Btn.Image")));
            this.byChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeSave_Btn.Name = "byChargeSave_Btn";
            this.byChargeSave_Btn.Size = new System.Drawing.Size(41, 22);
            this.byChargeSave_Btn.Text = "Save";
            // 
            // byChargeCopy_Btn
            // 
            this.byChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeCopy_Btn.Image")));
            this.byChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeCopy_Btn.Name = "byChargeCopy_Btn";
            this.byChargeCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.byChargeCopy_Btn.Text = "Copy";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem5});
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // extractPlotToolStripMenuItem5
            // 
            this.extractPlotToolStripMenuItem5.Name = "extractPlotToolStripMenuItem5";
            this.extractPlotToolStripMenuItem5.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem5.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem5.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem5.Click += new System.EventHandler(this.extractPlotToolStripMenuItem5_Click);
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
            this.b_Btn.Size = new System.Drawing.Size(41, 24);
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
            this.y_Btn.Size = new System.Drawing.Size(41, 24);
            this.y_Btn.Text = "y";
            // 
            // bycharge_X_Box
            // 
            this.bycharge_X_Box.AutoSize = false;
            this.bycharge_X_Box.Name = "bycharge_X_Box";
            this.bycharge_X_Box.ReadOnly = true;
            this.bycharge_X_Box.Size = new System.Drawing.Size(40, 22);
            this.bycharge_X_Box.ToolTipText = "Width";
            // 
            // bycharge_Y_Box
            // 
            this.bycharge_Y_Box.AutoSize = false;
            this.bycharge_Y_Box.Name = "bycharge_Y_Box";
            this.bycharge_Y_Box.ReadOnly = true;
            this.bycharge_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.bycharge_Y_Box.ToolTipText = "Height";
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
            this.form_primCharge_Btn,
            this.a_Btn,
            this.x_Btn,
            this.axcharge_X_Box,
            this.axcharge_Y_Box});
            this.axCharge_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.axCharge_toolStrip.Location = new System.Drawing.Point(407, 5);
            this.axCharge_toolStrip.Name = "axCharge_toolStrip";
            this.axCharge_toolStrip.Size = new System.Drawing.Size(43, 175);
            this.axCharge_toolStrip.TabIndex = 26;
            // 
            // axChargeSave_Btn
            // 
            this.axChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeSave_Btn.Image")));
            this.axChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeSave_Btn.Name = "axChargeSave_Btn";
            this.axChargeSave_Btn.Size = new System.Drawing.Size(41, 22);
            this.axChargeSave_Btn.Text = "Save";
            // 
            // axChargeCopy_Btn
            // 
            this.axChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeCopy_Btn.Image")));
            this.axChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeCopy_Btn.Name = "axChargeCopy_Btn";
            this.axChargeCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.axChargeCopy_Btn.Text = "Copy";
            // 
            // form_primCharge_Btn
            // 
            this.form_primCharge_Btn.AutoToolTip = false;
            this.form_primCharge_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.form_primCharge_Btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.style_toolStripMenuItem,
            this.extractPlotToolStripMenuItem7});
            this.form_primCharge_Btn.Image = ((System.Drawing.Image)(resources.GetObject("form_primCharge_Btn.Image")));
            this.form_primCharge_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.form_primCharge_Btn.Name = "form_primCharge_Btn";
            this.form_primCharge_Btn.RightToLeftAutoMirrorImage = true;
            this.form_primCharge_Btn.Size = new System.Drawing.Size(41, 22);
            this.form_primCharge_Btn.Text = " ";
            // 
            // style_toolStripMenuItem
            // 
            this.style_toolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.style_toolStripMenuItem.Name = "style_toolStripMenuItem";
            this.style_toolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.style_toolStripMenuItem.Text = "Style";
            this.style_toolStripMenuItem.ToolTipText = "Format the style of the plots in this tab";
            this.style_toolStripMenuItem.Click += new System.EventHandler(this.style_toolStripMenuItem_Click);
            // 
            // extractPlotToolStripMenuItem7
            // 
            this.extractPlotToolStripMenuItem7.Name = "extractPlotToolStripMenuItem7";
            this.extractPlotToolStripMenuItem7.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem7.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem7.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem7.Click += new System.EventHandler(this.extractPlotToolStripMenuItem7_Click);
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
            this.a_Btn.Size = new System.Drawing.Size(41, 24);
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
            this.x_Btn.Size = new System.Drawing.Size(41, 24);
            this.x_Btn.Text = "x";
            // 
            // axcharge_X_Box
            // 
            this.axcharge_X_Box.AutoSize = false;
            this.axcharge_X_Box.Name = "axcharge_X_Box";
            this.axcharge_X_Box.ReadOnly = true;
            this.axcharge_X_Box.Size = new System.Drawing.Size(40, 22);
            this.axcharge_X_Box.ToolTipText = "Width";
            // 
            // axcharge_Y_Box
            // 
            this.axcharge_Y_Box.AutoSize = false;
            this.axcharge_Y_Box.Name = "axcharge_Y_Box";
            this.axcharge_Y_Box.ReadOnly = true;
            this.axcharge_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.axcharge_Y_Box.ToolTipText = "Height";
            // 
            // czCharge_Pnl
            // 
            this.czCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.czCharge_Pnl.Location = new System.Drawing.Point(6, 530);
            this.czCharge_Pnl.Name = "czCharge_Pnl";
            this.czCharge_Pnl.Size = new System.Drawing.Size(398, 251);
            this.czCharge_Pnl.TabIndex = 29;
            this.czCharge_Pnl.Resize += new System.EventHandler(this.czCharge_Pnl_Resize);
            // 
            // byCharge_Pnl
            // 
            this.byCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byCharge_Pnl.Location = new System.Drawing.Point(6, 267);
            this.byCharge_Pnl.Name = "byCharge_Pnl";
            this.byCharge_Pnl.Size = new System.Drawing.Size(398, 251);
            this.byCharge_Pnl.TabIndex = 28;
            this.byCharge_Pnl.Resize += new System.EventHandler(this.byCharge_Pnl_Resize);
            // 
            // axCharge_Pnl
            // 
            this.axCharge_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axCharge_Pnl.Location = new System.Drawing.Point(6, 4);
            this.axCharge_Pnl.Name = "axCharge_Pnl";
            this.axCharge_Pnl.Size = new System.Drawing.Size(398, 251);
            this.axCharge_Pnl.TabIndex = 27;
            this.axCharge_Pnl.Resize += new System.EventHandler(this.axCharge_Pnl_Resize);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(746, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 717);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // panel1_tab3
            // 
            this.panel1_tab3.AutoScroll = true;
            this.panel1_tab3.Controls.Add(this.by_toolStrip);
            this.panel1_tab3.Controls.Add(this.cz_toolStrip);
            this.panel1_tab3.Controls.Add(this.ax_toolStrip);
            this.panel1_tab3.Controls.Add(this.ax_Pnl);
            this.panel1_tab3.Controls.Add(this.by_Pnl);
            this.panel1_tab3.Controls.Add(this.cz_Pnl);
            this.panel1_tab3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1_tab3.Location = new System.Drawing.Point(3, 3);
            this.panel1_tab3.Name = "panel1_tab3";
            this.panel1_tab3.Size = new System.Drawing.Size(743, 717);
            this.panel1_tab3.TabIndex = 24;
            // 
            // by_toolStrip
            // 
            this.by_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.by_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.by_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.by_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byCopy_Btn,
            this.bySave_Btn,
            this.toolStripButton5,
            this.by_X_Box,
            this.by_Y_Box});
            this.by_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.by_toolStrip.Location = new System.Drawing.Point(2, 269);
            this.by_toolStrip.Name = "by_toolStrip";
            this.by_toolStrip.Size = new System.Drawing.Size(43, 121);
            this.by_toolStrip.TabIndex = 26;
            // 
            // byCopy_Btn
            // 
            this.byCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byCopy_Btn.Image")));
            this.byCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byCopy_Btn.Name = "byCopy_Btn";
            this.byCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.byCopy_Btn.Text = "Copy";
            // 
            // bySave_Btn
            // 
            this.bySave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bySave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("bySave_Btn.Image")));
            this.bySave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bySave_Btn.Name = "bySave_Btn";
            this.bySave_Btn.Size = new System.Drawing.Size(41, 22);
            this.bySave_Btn.Text = "Save";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem4});
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // extractPlotToolStripMenuItem4
            // 
            this.extractPlotToolStripMenuItem4.Name = "extractPlotToolStripMenuItem4";
            this.extractPlotToolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem4.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem4.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem4.Click += new System.EventHandler(this.extractPlotToolStripMenuItem4_Click);
            // 
            // by_X_Box
            // 
            this.by_X_Box.AutoSize = false;
            this.by_X_Box.Name = "by_X_Box";
            this.by_X_Box.ReadOnly = true;
            this.by_X_Box.Size = new System.Drawing.Size(40, 22);
            this.by_X_Box.ToolTipText = "Width";
            // 
            // by_Y_Box
            // 
            this.by_Y_Box.AutoSize = false;
            this.by_Y_Box.Name = "by_Y_Box";
            this.by_Y_Box.ReadOnly = true;
            this.by_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.by_Y_Box.ToolTipText = "Height";
            // 
            // cz_toolStrip
            // 
            this.cz_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.cz_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.cz_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.cz_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czSave_Btn,
            this.czCopy_Btn,
            this.toolStripButton6,
            this.cz_X_Box,
            this.cz_Y_Box});
            this.cz_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.cz_toolStrip.Location = new System.Drawing.Point(2, 531);
            this.cz_toolStrip.Name = "cz_toolStrip";
            this.cz_toolStrip.Size = new System.Drawing.Size(43, 121);
            this.cz_toolStrip.TabIndex = 25;
            // 
            // czSave_Btn
            // 
            this.czSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czSave_Btn.Image")));
            this.czSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czSave_Btn.Name = "czSave_Btn";
            this.czSave_Btn.Size = new System.Drawing.Size(41, 22);
            this.czSave_Btn.Text = "Save";
            // 
            // czCopy_Btn
            // 
            this.czCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czCopy_Btn.Image")));
            this.czCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czCopy_Btn.Name = "czCopy_Btn";
            this.czCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.czCopy_Btn.Text = "Copy";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem8});
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(41, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // extractPlotToolStripMenuItem8
            // 
            this.extractPlotToolStripMenuItem8.Name = "extractPlotToolStripMenuItem8";
            this.extractPlotToolStripMenuItem8.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem8.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem8.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem8.Click += new System.EventHandler(this.extractPlotToolStripMenuItem8_Click);
            // 
            // cz_X_Box
            // 
            this.cz_X_Box.AutoSize = false;
            this.cz_X_Box.Name = "cz_X_Box";
            this.cz_X_Box.ReadOnly = true;
            this.cz_X_Box.Size = new System.Drawing.Size(40, 22);
            this.cz_X_Box.ToolTipText = "Width";
            // 
            // cz_Y_Box
            // 
            this.cz_Y_Box.AutoSize = false;
            this.cz_Y_Box.Name = "cz_Y_Box";
            this.cz_Y_Box.ReadOnly = true;
            this.cz_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.cz_Y_Box.ToolTipText = "Height";
            // 
            // ax_toolStrip
            // 
            this.ax_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ax_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ax_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ax_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axSave_Btn,
            this.axCopy_Btn,
            this.form_prim_Btn,
            this.ax_X_Box,
            this.ax_Y_Box});
            this.ax_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ax_toolStrip.Location = new System.Drawing.Point(2, 5);
            this.ax_toolStrip.Name = "ax_toolStrip";
            this.ax_toolStrip.Size = new System.Drawing.Size(43, 121);
            this.ax_toolStrip.TabIndex = 24;
            // 
            // axSave_Btn
            // 
            this.axSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axSave_Btn.Image")));
            this.axSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axSave_Btn.Name = "axSave_Btn";
            this.axSave_Btn.Size = new System.Drawing.Size(41, 22);
            this.axSave_Btn.Text = "Save";
            // 
            // axCopy_Btn
            // 
            this.axCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axCopy_Btn.Image")));
            this.axCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axCopy_Btn.Name = "axCopy_Btn";
            this.axCopy_Btn.Size = new System.Drawing.Size(41, 22);
            this.axCopy_Btn.Text = "Copy";
            // 
            // form_prim_Btn
            // 
            this.form_prim_Btn.AutoToolTip = false;
            this.form_prim_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.form_prim_Btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleToolStripMenuItem,
            this.extractPlotToolStripMenuItem3});
            this.form_prim_Btn.Image = ((System.Drawing.Image)(resources.GetObject("form_prim_Btn.Image")));
            this.form_prim_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.form_prim_Btn.Name = "form_prim_Btn";
            this.form_prim_Btn.Size = new System.Drawing.Size(41, 22);
            this.form_prim_Btn.Text = " ";
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.styleToolStripMenuItem.Text = "Style";
            this.styleToolStripMenuItem.ToolTipText = "Format the style of the plots in this tab";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.styleToolStripMenuItem_Click);
            // 
            // extractPlotToolStripMenuItem3
            // 
            this.extractPlotToolStripMenuItem3.Name = "extractPlotToolStripMenuItem3";
            this.extractPlotToolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem3.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem3.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem3.Click += new System.EventHandler(this.extractPlotToolStripMenuItem3_Click);
            // 
            // ax_X_Box
            // 
            this.ax_X_Box.AutoSize = false;
            this.ax_X_Box.Name = "ax_X_Box";
            this.ax_X_Box.ReadOnly = true;
            this.ax_X_Box.Size = new System.Drawing.Size(40, 22);
            this.ax_X_Box.ToolTipText = "Width";
            // 
            // ax_Y_Box
            // 
            this.ax_Y_Box.AutoSize = false;
            this.ax_Y_Box.Name = "ax_Y_Box";
            this.ax_Y_Box.ReadOnly = true;
            this.ax_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.ax_Y_Box.ToolTipText = "Height";
            // 
            // ax_Pnl
            // 
            this.ax_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ax_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ax_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ax_Pnl.Location = new System.Drawing.Point(48, 4);
            this.ax_Pnl.Name = "ax_Pnl";
            this.ax_Pnl.Size = new System.Drawing.Size(525, 251);
            this.ax_Pnl.TabIndex = 21;
            this.ax_Pnl.Resize += new System.EventHandler(this.ax_Pnl_Resize);
            // 
            // by_Pnl
            // 
            this.by_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.by_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.by_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_Pnl.Location = new System.Drawing.Point(48, 267);
            this.by_Pnl.Name = "by_Pnl";
            this.by_Pnl.Size = new System.Drawing.Size(525, 251);
            this.by_Pnl.TabIndex = 22;
            this.by_Pnl.Resize += new System.EventHandler(this.by_Pnl_Resize);
            // 
            // cz_Pnl
            // 
            this.cz_Pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cz_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cz_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cz_Pnl.Location = new System.Drawing.Point(48, 530);
            this.cz_Pnl.Name = "cz_Pnl";
            this.cz_Pnl.Size = new System.Drawing.Size(525, 251);
            this.cz_Pnl.TabIndex = 23;
            this.cz_Pnl.Resize += new System.EventHandler(this.cz_Pnl_Resize);
            // 
            // tabInternal
            // 
            this.tabInternal.AutoScroll = true;
            this.tabInternal.Controls.Add(this.splitContainer1);
            this.tabInternal.Location = new System.Drawing.Point(4, 22);
            this.tabInternal.Name = "tabInternal";
            this.tabInternal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternal.Size = new System.Drawing.Size(1362, 723);
            this.tabInternal.TabIndex = 4;
            this.tabInternal.Text = "Internal Fragments";
            this.tabInternal.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1_intIdx);
            this.splitContainer1.Panel1.Controls.Add(this.idxPlotLbl);
            this.splitContainer1.Panel1.Controls.Add(this.int_Idx_toolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.int_IdxTo_toolStrip);
            this.splitContainer1.Panel2.Controls.Add(this.panel2_intIdxTo);
            this.splitContainer1.Size = new System.Drawing.Size(1356, 717);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 29;
            // 
            // panel1_intIdx
            // 
            this.panel1_intIdx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1_intIdx.Controls.Add(this.idxPnl1);
            this.panel1_intIdx.Controls.Add(this.splitter2);
            this.panel1_intIdx.Controls.Add(this.idxInt_Pnl1);
            this.panel1_intIdx.Location = new System.Drawing.Point(31, 30);
            this.panel1_intIdx.Name = "panel1_intIdx";
            this.panel1_intIdx.Size = new System.Drawing.Size(1322, 312);
            this.panel1_intIdx.TabIndex = 27;
            // 
            // idxPnl1
            // 
            this.idxPnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl1.Location = new System.Drawing.Point(0, 0);
            this.idxPnl1.Name = "idxPnl1";
            this.idxPnl1.Size = new System.Drawing.Size(1084, 312);
            this.idxPnl1.TabIndex = 28;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(1084, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 312);
            this.splitter2.TabIndex = 27;
            this.splitter2.TabStop = false;
            // 
            // idxInt_Pnl1
            // 
            this.idxInt_Pnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl1.Location = new System.Drawing.Point(1087, 0);
            this.idxInt_Pnl1.Name = "idxInt_Pnl1";
            this.idxInt_Pnl1.Size = new System.Drawing.Size(235, 312);
            this.idxInt_Pnl1.TabIndex = 25;
            // 
            // idxPlotLbl
            // 
            this.idxPlotLbl.AutoSize = true;
            this.idxPlotLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPlotLbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.idxPlotLbl.Location = new System.Drawing.Point(27, 7);
            this.idxPlotLbl.Name = "idxPlotLbl";
            this.idxPlotLbl.Size = new System.Drawing.Size(172, 20);
            this.idxPlotLbl.TabIndex = 20;
            this.idxPlotLbl.Text = "Internal fragments\' plot";
            // 
            // int_Idx_toolStrip
            // 
            this.int_Idx_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.int_Idx_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_Idx_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_Idx_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxSave_Btn,
            this.int_IdxCopy_Btn,
            this.toolStripDropDownButton1});
            this.int_Idx_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_Idx_toolStrip.Location = new System.Drawing.Point(5, 30);
            this.int_Idx_toolStrip.Name = "int_Idx_toolStrip";
            this.int_Idx_toolStrip.Size = new System.Drawing.Size(32, 77);
            this.int_Idx_toolStrip.TabIndex = 25;
            // 
            // int_IdxSave_Btn
            // 
            this.int_IdxSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxSave_Btn.Image")));
            this.int_IdxSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxSave_Btn.Name = "int_IdxSave_Btn";
            this.int_IdxSave_Btn.Size = new System.Drawing.Size(30, 22);
            this.int_IdxSave_Btn.Text = "Save";
            // 
            // int_IdxCopy_Btn
            // 
            this.int_IdxCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxCopy_Btn.Image")));
            this.int_IdxCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxCopy_Btn.Name = "int_IdxCopy_Btn";
            this.int_IdxCopy_Btn.Size = new System.Drawing.Size(30, 22);
            this.int_IdxCopy_Btn.Text = "Copy";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleToolStripMenuItem3,
            this.extractPlotToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(30, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // styleToolStripMenuItem3
            // 
            this.styleToolStripMenuItem3.Name = "styleToolStripMenuItem3";
            this.styleToolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
            this.styleToolStripMenuItem3.Text = "Style";
            this.styleToolStripMenuItem3.ToolTipText = "Format the style of the plots in this tab";
            this.styleToolStripMenuItem3.Click += new System.EventHandler(this.styleToolStripMenuItem3_Click);
            // 
            // extractPlotToolStripMenuItem1
            // 
            this.extractPlotToolStripMenuItem1.Name = "extractPlotToolStripMenuItem1";
            this.extractPlotToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem1.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem1.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem1.Click += new System.EventHandler(this.extractPlotToolStripMenuItem1_Click);
            // 
            // int_IdxTo_toolStrip
            // 
            this.int_IdxTo_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.int_IdxTo_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_IdxTo_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_IdxTo_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxToSave_Btn,
            this.int_IdxToCopy_Btn,
            this.toolStripButton8});
            this.int_IdxTo_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_IdxTo_toolStrip.Location = new System.Drawing.Point(5, 9);
            this.int_IdxTo_toolStrip.Name = "int_IdxTo_toolStrip";
            this.int_IdxTo_toolStrip.Size = new System.Drawing.Size(32, 77);
            this.int_IdxTo_toolStrip.TabIndex = 26;
            // 
            // int_IdxToSave_Btn
            // 
            this.int_IdxToSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToSave_Btn.Image")));
            this.int_IdxToSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToSave_Btn.Name = "int_IdxToSave_Btn";
            this.int_IdxToSave_Btn.Size = new System.Drawing.Size(30, 22);
            this.int_IdxToSave_Btn.Text = "Save";
            // 
            // int_IdxToCopy_Btn
            // 
            this.int_IdxToCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToCopy_Btn.Image")));
            this.int_IdxToCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToCopy_Btn.Name = "int_IdxToCopy_Btn";
            this.int_IdxToCopy_Btn.Size = new System.Drawing.Size(30, 22);
            this.int_IdxToCopy_Btn.Text = "Copy";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem2});
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(30, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // extractPlotToolStripMenuItem2
            // 
            this.extractPlotToolStripMenuItem2.Name = "extractPlotToolStripMenuItem2";
            this.extractPlotToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.extractPlotToolStripMenuItem2.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem2.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem2.Click += new System.EventHandler(this.extractPlotToolStripMenuItem2_Click);
            // 
            // panel2_intIdxTo
            // 
            this.panel2_intIdxTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2_intIdxTo.Controls.Add(this.idxPnl2);
            this.panel2_intIdxTo.Controls.Add(this.splitter3);
            this.panel2_intIdxTo.Controls.Add(this.idxInt_Pnl2);
            this.panel2_intIdxTo.Location = new System.Drawing.Point(31, 3);
            this.panel2_intIdxTo.Name = "panel2_intIdxTo";
            this.panel2_intIdxTo.Size = new System.Drawing.Size(1322, 280);
            this.panel2_intIdxTo.TabIndex = 28;
            // 
            // idxPnl2
            // 
            this.idxPnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl2.Location = new System.Drawing.Point(0, 0);
            this.idxPnl2.Name = "idxPnl2";
            this.idxPnl2.Size = new System.Drawing.Size(1084, 280);
            this.idxPnl2.TabIndex = 29;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(1084, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 280);
            this.splitter3.TabIndex = 28;
            this.splitter3.TabStop = false;
            // 
            // idxInt_Pnl2
            // 
            this.idxInt_Pnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl2.Location = new System.Drawing.Point(1087, 0);
            this.idxInt_Pnl2.Name = "idxInt_Pnl2";
            this.idxInt_Pnl2.Size = new System.Drawing.Size(235, 280);
            this.idxInt_Pnl2.TabIndex = 26;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peak Finder v22.7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form2_DpiChanged);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabFit.ResumeLayout(false);
            this.plots_grpBox.ResumeLayout(false);
            this.toolStrip_plot.ResumeLayout(false);
            this.toolStrip_plot.PerformLayout();
            this.user_grpBox.ResumeLayout(false);
            this.Fit_results_groupBox.ResumeLayout(false);
            this.Fit_results_groupBox.PerformLayout();
            this.toolStrip_fit_sort.ResumeLayout(false);
            this.toolStrip_fit_sort.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel_calc.ResumeLayout(false);
            this.panel_calc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip_fragList.ResumeLayout(false);
            this.toolStrip_fragList.PerformLayout();
            this.fragList_toolStrip.ResumeLayout(false);
            this.fragList_toolStrip.PerformLayout();
            this.theorData_grpBx.ResumeLayout(false);
            this.theorData_grpBx.PerformLayout();
            this.expData_grpBx.ResumeLayout(false);
            this.expData_grpBx.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.fitOptions_grpBox.ResumeLayout(false);
            this.fitOptions_grpBox.PerformLayout();
            this.fiToolStrip.ResumeLayout(false);
            this.fiToolStrip.PerformLayout();
            this.tabDiagram.ResumeLayout(false);
            this.panel2_tab2.ResumeLayout(false);
            this.panel2_tab2.PerformLayout();
            this.ppm_toolStrip.ResumeLayout(false);
            this.ppm_toolStrip.PerformLayout();
            this.panel1_tab2.ResumeLayout(false);
            this.draw_sequence_panelCopy2.ResumeLayout(false);
            this.draw_sequence_panelCopy2.PerformLayout();
            this.sequence_toolStripCopy2.ResumeLayout(false);
            this.sequence_toolStripCopy2.PerformLayout();
            this.draw_sequence_panelCopy1.ResumeLayout(false);
            this.draw_sequence_panelCopy1.PerformLayout();
            this.sequence_toolStripCopy1.ResumeLayout(false);
            this.sequence_toolStripCopy1.PerformLayout();
            this.draw_sequence_panel.ResumeLayout(false);
            this.draw_sequence_panel.PerformLayout();
            this.sequence_toolStrip.ResumeLayout(false);
            this.sequence_toolStrip.PerformLayout();
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1_intIdx.ResumeLayout(false);
            this.int_Idx_toolStrip.ResumeLayout(false);
            this.int_Idx_toolStrip.PerformLayout();
            this.int_IdxTo_toolStrip.ResumeLayout(false);
            this.int_IdxTo_toolStrip.PerformLayout();
            this.panel2_intIdxTo.ResumeLayout(false);
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
        private System.Windows.Forms.Button loadMS_Btn;
        private System.Windows.Forms.ListBox machine_listBox;
        private System.Windows.Forms.Label machine_Label;
        private System.Windows.Forms.TextBox resolution_Box;
        private System.Windows.Forms.Label resolution_Label;
        private System.Windows.Forms.CheckedListBox addin_lstBox;
        private System.Windows.Forms.CheckedListBox M_lstBox;
        private System.Windows.Forms.CheckedListBox z_lstBox;
        private System.Windows.Forms.CheckedListBox y_lstBox;
        private System.Windows.Forms.CheckedListBox c_lstBox;
        private System.Windows.Forms.CheckedListBox x_lstBox;
        private System.Windows.Forms.CheckedListBox b_lstBox;
        private System.Windows.Forms.CheckedListBox a_lstBox;
        private System.Windows.Forms.CheckedListBox internal_lstBox;
        private System.Windows.Forms.Button loadFit_Btn;
        private System.Windows.Forms.Button loadExp_Btn;
        private System.Windows.Forms.Label selFrag_Label;
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
        private System.Windows.Forms.Panel panel_calc;
        private System.Windows.Forms.ColumnHeader codeNoHeader;
        private System.Windows.Forms.ColumnHeader factorHeader;
        private System.Windows.Forms.Button loadWd_Btn;
        private System.Windows.Forms.Button saveWd_Btn;
        private System.Windows.Forms.Button fit_sel_Btn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.ColumnHeader intensityHeader;
        private System.Windows.Forms.Button displayPeakList_btn;
        private System.Windows.Forms.CheckBox plotExp_chkBox;
        private System.Windows.Forms.CheckBox plotCentr_chkBox;
        private System.Windows.Forms.CheckBox plotFragCent_chkBox;
        private System.Windows.Forms.CheckBox plotFragProf_chkBox;
        private System.Windows.Forms.Button hide_Btn;
        private System.Windows.Forms.TabPage tabDiagram;
        private System.Windows.Forms.Button show_Btn;
        private System.Windows.Forms.Panel factor_panel;
        private System.Windows.Forms.TreeView fragTypes_tree;
        //private MyTreeView frag_tree;
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
        private System.Windows.Forms.Panel idxInt_Pnl1;
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
        private System.Windows.Forms.ToolStrip fiToolStrip;
        private System.Windows.Forms.ToolStripButton fitSettings_Btn;
        private System.Windows.Forms.ToolStripButton Fitting_chkBox;
        private System.Windows.Forms.ToolStripButton toggle_toolStripButton;
        private System.Windows.Forms.ToolStripButton checkall_Frag_Btn;
        private System.Windows.Forms.ToolStripButton uncheckall_Frag_Btn;
        private System.Windows.Forms.GroupBox theorData_grpBx;
        private System.Windows.Forms.GroupBox expData_grpBx;
        private System.Windows.Forms.ToolStripButton refresh_fitRes_Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton clear_toolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton settingsPeak_Btn;
        private System.Windows.Forms.TextBox filename_txtBx;
        private System.Windows.Forms.Panel panel1_intIdx;
        private System.Windows.Forms.TextBox peptide_textBox1;
        private System.Windows.Forms.ToolStripButton fragPlotLbl_chkBx;
        private System.Windows.Forms.ToolStripButton fragPlotLbl_chkBx2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton3;
        private System.Windows.Forms.ToolStripButton rel_res_chkBx;
        private System.Windows.Forms.ToolStripButton show_files_Btn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel idxPnl1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel idxPnl2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton disp_a;
        private System.Windows.Forms.ToolStripButton disp_b;
        private System.Windows.Forms.ToolStripButton disp_c;
        private System.Windows.Forms.ToolStripButton disp_x;
        private System.Windows.Forms.ToolStripButton disp_y;
        private System.Windows.Forms.ToolStripButton disp_z;
        private System.Windows.Forms.ToolStripButton disp_internal;
        private System.Windows.Forms.CheckedListBox dvw_lstBox;
        private System.Windows.Forms.ToolStripDropDownButton chartFormatBtn;
        private System.Windows.Forms.ToolStripMenuItem styleFormatBtn;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton autoscale_Btn;
        private System.Windows.Forms.ToolStripDropDownButton form_prim_Btn;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton form_primCharge_Btn;
        private System.Windows.Forms.ToolStripMenuItem style_toolStripMenuItem;
        private System.Windows.Forms.Panel panel2_tab2;
        private System.Windows.Forms.ToolStrip ppm_toolStrip;
        private System.Windows.Forms.ToolStripButton ppmSave_Btn;
        private System.Windows.Forms.ToolStripButton ppmCopy_Btn;
        private System.Windows.Forms.Panel ppm_panel;
        private System.Windows.Forms.Panel panel1_tab2;
        private System.Windows.Forms.ToolStrip sequence_toolStrip;
        private System.Windows.Forms.ToolStripButton seqSave_Btn;
        private System.Windows.Forms.ToolStripButton seqCopy_Btn;
        private System.Windows.Forms.Label seq_Lbl;
        private System.Windows.Forms.CheckBox ax_chBx;
        private System.Windows.Forms.CheckBox by_chBx;
        private System.Windows.Forms.CheckBox cz_chBx;
        private System.Windows.Forms.CheckBox intA_chBx;
        private System.Windows.Forms.CheckBox intB_chBx;
        private System.Windows.Forms.Panel sequence_Pnl;
        private System.Windows.Forms.Button draw_Btn;
        private System.Windows.Forms.Panel draw_sequence_panel;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Button loadFF_Btn;
        private System.Windows.Forms.RadioButton rdBtn50;
        private System.Windows.Forms.RadioButton rdBtn25;
        private System.Windows.Forms.Panel draw_sequence_panelCopy2;
        private System.Windows.Forms.RadioButton rdBtn50Copy2;
        private System.Windows.Forms.RadioButton rdBtn25Copy2;
        private System.Windows.Forms.ToolStrip sequence_toolStripCopy2;
        private System.Windows.Forms.ToolStripButton seqSave_BtnCopy2;
        private System.Windows.Forms.ToolStripButton seqCopy_BtnCopy2;
        private System.Windows.Forms.Label seq_LblCopy2;
        private System.Windows.Forms.CheckBox ax_chBxCopy2;
        private System.Windows.Forms.CheckBox by_chBxCopy2;
        private System.Windows.Forms.CheckBox cz_chBxCopy2;
        private System.Windows.Forms.CheckBox intA_chBxCopy2;
        private System.Windows.Forms.CheckBox intB_chBxCopy2;
        private System.Windows.Forms.Panel sequence_PnlCopy2;
        private System.Windows.Forms.Button draw_BtnCopy2;
        private System.Windows.Forms.Panel draw_sequence_panelCopy1;
        private System.Windows.Forms.RadioButton rdBtn50Copy1;
        private System.Windows.Forms.RadioButton rdBtn25Copy1;
        private System.Windows.Forms.ToolStrip sequence_toolStripCopy1;
        private System.Windows.Forms.ToolStripButton seqSave_BtnCopy1;
        private System.Windows.Forms.ToolStripButton seqCopy_BtnCopy1;
        private System.Windows.Forms.Label seq_LblCopy1;
        private System.Windows.Forms.CheckBox ax_chBxCopy1;
        private System.Windows.Forms.CheckBox by_chBxCopy1;
        private System.Windows.Forms.CheckBox cz_chBxCopy1;
        private System.Windows.Forms.CheckBox intA_chBxCopy1;
        private System.Windows.Forms.CheckBox intB_chBxCopy1;
        private System.Windows.Forms.Panel sequence_PnlCopy1;
        private System.Windows.Forms.Button draw_BtnCopy1;
        private System.Windows.Forms.Button add_sequencePanel1;
        private System.Windows.Forms.Button delele_sequencePnl2;
        private System.Windows.Forms.Button delele_sequencePnl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox czcharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox czcharge_Y_Box;
        private System.Windows.Forms.ToolStripTextBox bycharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox bycharge_Y_Box;
        private System.Windows.Forms.ToolStripTextBox axcharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox axcharge_Y_Box;
        private System.Windows.Forms.ToolStripTextBox by_X_Box;
        private System.Windows.Forms.ToolStripTextBox by_Y_Box;
        private System.Windows.Forms.ToolStripTextBox cz_X_Box;
        private System.Windows.Forms.ToolStripTextBox cz_Y_Box;
        private System.Windows.Forms.ToolStripTextBox ax_X_Box;
        private System.Windows.Forms.ToolStripTextBox ax_Y_Box;
        private System.Windows.Forms.CheckBox los_chkBoxCopy2;
        private System.Windows.Forms.CheckBox los_chkBoxCopy1;
        private System.Windows.Forms.CheckBox los_chkBox;
        private System.Windows.Forms.Button fit_chkGrpsBtn;
        private System.Windows.Forms.Button fit_chkGrpsChkFragBtn;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton9;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem6;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem7;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem8;
        private System.Windows.Forms.Button seqBtn;
        private System.Windows.Forms.CheckBox light_chkBox;
        private System.Windows.Forms.CheckBox heavy_chkBox;
        private System.Windows.Forms.CheckBox light_chkBoxCopy2;
        private System.Windows.Forms.CheckBox heavy_chkBoxCopy2;
        private System.Windows.Forms.CheckBox light_chkBoxCopy1;
        private System.Windows.Forms.CheckBox heavy_chkBoxCopy1;
        private System.Windows.Forms.ToolStrip fragList_toolStrip;
        private System.Windows.Forms.ToolStripButton frag_sort_Btn1;
        private System.Windows.Forms.ToolStripButton fragCalc_Btn1;
        private System.Windows.Forms.ToolStripButton refresh_frag_Btn1;
        private System.Windows.Forms.ToolStripButton statistics_Btn;
        private System.Windows.Forms.ToolStripButton seq_coverageBtn;
        private System.Windows.Forms.ToolStripDropDownButton ppm_extract_btn;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem9;
        private System.Windows.Forms.GroupBox Fit_results_groupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripButton10;
        private System.Windows.Forms.Panel panel2;
    }
}