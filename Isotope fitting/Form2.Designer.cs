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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.contextMenuStrip_MSproduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ionTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mzHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formulaHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.factorHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeNoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intensityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fit_chkGrpsBtn = new System.Windows.Forms.Button();
            this.fit_chkGrpsChkFragBtn = new System.Windows.Forms.Button();
            this.loadFF_Btn = new System.Windows.Forms.Button();
            this.deleteMSProd_Btn = new System.Windows.Forms.Button();
            this.fragStorage_Lbl = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
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
            this.panel2_intIdxTo = new System.Windows.Forms.Panel();
            this.idxPnl2 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.idxInt_Pnl2 = new System.Windows.Forms.Panel();
            this.int_IdxTo_toolStrip = new System.Windows.Forms.ToolStrip();
            this.int_IdxToSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.int_IdxToCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPrimary = new System.Windows.Forms.TabPage();
            this.panel2_tab3 = new System.Windows.Forms.Panel();
            this.groupBoxCharge4 = new System.Windows.Forms.GroupBox();
            this.dzCharge_Pnl = new System.Windows.Forms.Panel();
            this.Charge_toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.dzChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.dzChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem_charge_dz = new System.Windows.Forms.ToolStripMenuItem();
            this.up4_Btn = new System.Windows.Forms.ToolStripButton();
            this.down4_Btn = new System.Windows.Forms.ToolStripButton();
            this.dzcharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.dzcharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxCharge3 = new System.Windows.Forms.GroupBox();
            this.czCharge_Pnl = new System.Windows.Forms.Panel();
            this.Charge_toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.czChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.up3_Btn = new System.Windows.Forms.ToolStripButton();
            this.down3_Btn = new System.Windows.Forms.ToolStripButton();
            this.czcharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.czcharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxCharge2 = new System.Windows.Forms.GroupBox();
            this.byCharge_Pnl = new System.Windows.Forms.Panel();
            this.Charge_toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.byChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.byChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripSplitButton();
            this.extractPlotToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.up2_Btn = new System.Windows.Forms.ToolStripButton();
            this.down2_Btn = new System.Windows.Forms.ToolStripButton();
            this.bycharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.bycharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxCharge1 = new System.Windows.Forms.GroupBox();
            this.axCharge_Pnl = new System.Windows.Forms.Panel();
            this.Charge_toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.axChargeSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axChargeCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.form_primCharge_Btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.style_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.up1_Btn = new System.Windows.Forms.ToolStripButton();
            this.down1_Btn = new System.Windows.Forms.ToolStripButton();
            this.axcharge_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.axcharge_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1_tab3 = new System.Windows.Forms.Panel();
            this.groupBoxIntensity4 = new System.Windows.Forms.GroupBox();
            this.dz_Pnl = new System.Windows.Forms.Panel();
            this.intensity_toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.dzSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.dzCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem_dz = new System.Windows.Forms.ToolStripMenuItem();
            this.dz_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.dz_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxIntensity3 = new System.Windows.Forms.GroupBox();
            this.cz_Pnl = new System.Windows.Forms.Panel();
            this.intensity_toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.czSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.czCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cz_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.cz_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxIntensity2 = new System.Windows.Forms.GroupBox();
            this.by_Pnl = new System.Windows.Forms.Panel();
            this.intensity_toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.byCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.bySave_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.by_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.by_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxIntensity1 = new System.Windows.Forms.GroupBox();
            this.ax_Pnl = new System.Windows.Forms.Panel();
            this.intensity_toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.axSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.axCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.form_prim_Btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ax_X_Box = new System.Windows.Forms.ToolStripTextBox();
            this.ax_Y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.tabDiagram = new System.Windows.Forms.TabPage();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel2_tab2 = new System.Windows.Forms.Panel();
            this.ppm_toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.ppm_M = new System.Windows.Forms.ToolStripButton();
            this.ppm_M_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_M_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_uncheckBtn = new System.Windows.Forms.ToolStripButton();
            this.ppm_checkall_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppm_B_ = new System.Windows.Forms.ToolStripButton();
            this.ppm_toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.ppm_internal_b = new System.Windows.Forms.ToolStripButton();
            this.ppm_internal_b_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_internal_b_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.ppm_internal_a = new System.Windows.Forms.ToolStripButton();
            this.ppm_internal_a_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_internal_a_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.ppm_w = new System.Windows.Forms.ToolStripButton();
            this.ppm_w_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_w_B = new System.Windows.Forms.ToolStripButton();
            this.ppm_x = new System.Windows.Forms.ToolStripButton();
            this.ppm_x_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_x_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_y = new System.Windows.Forms.ToolStripButton();
            this.ppm_y_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_y_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_z = new System.Windows.Forms.ToolStripButton();
            this.ppm_z_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_z_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ppm_a = new System.Windows.Forms.ToolStripButton();
            this.ppm_a_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_a_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_b = new System.Windows.Forms.ToolStripButton();
            this.ppm_b_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_b_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_c = new System.Windows.Forms.ToolStripButton();
            this.ppm_c_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_c_NH3 = new System.Windows.Forms.ToolStripButton();
            this.ppm_d = new System.Windows.Forms.ToolStripButton();
            this.ppm_d_H2O = new System.Windows.Forms.ToolStripButton();
            this.ppm_d_B = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ppm_panel = new System.Windows.Forms.Panel();
            this.ppm_toolStrip = new System.Windows.Forms.ToolStrip();
            this.ppmSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppmCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppm_legend_Btn = new System.Windows.Forms.ToolStripButton();
            this.ppm_extract_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.extractPlotToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1_tab2 = new System.Windows.Forms.Panel();
            this.draw_sequence_panelCopy2 = new System.Windows.Forms.Panel();
            this.seq_LblCopy2 = new System.Windows.Forms.Label();
            this.highlight_ibt_ckBxCopy2 = new System.Windows.Forms.CheckBox();
            this.seq_extensionBoxCopy2 = new System.Windows.Forms.ComboBox();
            this.los_chkBoxCopy2 = new System.Windows.Forms.CheckBox();
            this.delele_sequencePnl2 = new System.Windows.Forms.Button();
            this.rdBtn50Copy2 = new System.Windows.Forms.RadioButton();
            this.rdBtn25Copy2 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStripCopy2 = new System.Windows.Forms.ToolStrip();
            this.seqSave_BtnCopy2 = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_BtnCopy2 = new System.Windows.Forms.ToolStripButton();
            this.ax_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.by_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.cz_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.intA_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.intB_chBxCopy2 = new System.Windows.Forms.CheckBox();
            this.sequence_PnlCopy2 = new System.Windows.Forms.Panel();
            this.color_range_panelCopy2 = new System.Windows.Forms.Panel();
            this.color_range_picBoxCopy2 = new System.Windows.Forms.PictureBox();
            this.seq_lbl_panelCopy2 = new System.Windows.Forms.Panel();
            this.draw_BtnCopy2 = new System.Windows.Forms.Button();
            this.draw_sequence_panelCopy1 = new System.Windows.Forms.Panel();
            this.seq_LblCopy1 = new System.Windows.Forms.Label();
            this.highlight_ibt_ckBxCopy1 = new System.Windows.Forms.CheckBox();
            this.seq_extensionBoxCopy1 = new System.Windows.Forms.ComboBox();
            this.los_chkBoxCopy1 = new System.Windows.Forms.CheckBox();
            this.delele_sequencePnl1 = new System.Windows.Forms.Button();
            this.rdBtn50Copy1 = new System.Windows.Forms.RadioButton();
            this.rdBtn25Copy1 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStripCopy1 = new System.Windows.Forms.ToolStrip();
            this.seqSave_BtnCopy1 = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_BtnCopy1 = new System.Windows.Forms.ToolStripButton();
            this.ax_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.by_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.cz_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.intA_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.intB_chBxCopy1 = new System.Windows.Forms.CheckBox();
            this.sequence_PnlCopy1 = new System.Windows.Forms.Panel();
            this.color_range_panelCopy1 = new System.Windows.Forms.Panel();
            this.color_range_picBoxCopy1 = new System.Windows.Forms.PictureBox();
            this.seq_lbl_panelCopy1 = new System.Windows.Forms.Panel();
            this.draw_BtnCopy1 = new System.Windows.Forms.Button();
            this.draw_sequence_panel = new System.Windows.Forms.Panel();
            this.seq_Lbl = new System.Windows.Forms.Label();
            this.highlight_ibt_ckBx = new System.Windows.Forms.CheckBox();
            this.seq_extensionBox = new System.Windows.Forms.ComboBox();
            this.los_chkBox = new System.Windows.Forms.CheckBox();
            this.add_sequencePanel1 = new System.Windows.Forms.Button();
            this.rdBtn50 = new System.Windows.Forms.RadioButton();
            this.rdBtn25 = new System.Windows.Forms.RadioButton();
            this.sequence_toolStrip = new System.Windows.Forms.ToolStrip();
            this.seqSave_Btn = new System.Windows.Forms.ToolStripButton();
            this.seqCopy_Btn = new System.Windows.Forms.ToolStripButton();
            this.seq_coverageBtn = new System.Windows.Forms.ToolStripButton();
            this.highlightProp_Btn = new System.Windows.Forms.ToolStripButton();
            this.ax_chBx = new System.Windows.Forms.CheckBox();
            this.by_chBx = new System.Windows.Forms.CheckBox();
            this.cz_chBx = new System.Windows.Forms.CheckBox();
            this.intA_chBx = new System.Windows.Forms.CheckBox();
            this.intB_chBx = new System.Windows.Forms.CheckBox();
            this.sequence_Pnl = new System.Windows.Forms.Panel();
            this.color_range_panel = new System.Windows.Forms.Panel();
            this.color_range_picBox = new System.Windows.Forms.PictureBox();
            this.seq_lbl_panel = new System.Windows.Forms.Panel();
            this.draw_Btn = new System.Windows.Forms.Button();
            this.tabFit = new System.Windows.Forms.TabPage();
            this.plots_grpBox = new System.Windows.Forms.Panel();
            this.fit_grpBox = new System.Windows.Forms.GroupBox();
            this.toolStrip_plot = new System.Windows.Forms.ToolStrip();
            this.chartFormatBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.styleFormatBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.extractPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.autoscale_Btn = new System.Windows.Forms.ToolStripButton();
            this.cursor_chkBx = new System.Windows.Forms.ToolStripButton();
            this.copyImage_Btn = new System.Windows.Forms.ToolStripButton();
            this.zoomIn_Y_Btn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut_Y_Btn = new System.Windows.Forms.ToolStripButton();
            this.legend_chkBx = new System.Windows.Forms.ToolStripButton();
            this.fragPlotLbl_chkBx = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.fragPlotLbl_chkBx2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSeparator();
            this.disp_a = new System.Windows.Forms.ToolStripButton();
            this.disp_b = new System.Windows.Forms.ToolStripButton();
            this.disp_c = new System.Windows.Forms.ToolStripButton();
            this.disp_d = new System.Windows.Forms.ToolStripButton();
            this.disp_w = new System.Windows.Forms.ToolStripButton();
            this.disp_x = new System.Windows.Forms.ToolStripButton();
            this.disp_y = new System.Windows.Forms.ToolStripButton();
            this.disp_z = new System.Windows.Forms.ToolStripButton();
            this.disp_internal = new System.Windows.Forms.ToolStripButton();
            this.project_options_toolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chageStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.res_grpBox = new System.Windows.Forms.GroupBox();
            this.user_grpBox = new System.Windows.Forms.Panel();
            this.Fit_results_groupBox = new System.Windows.Forms.GroupBox();
            this.bigPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip_fit_sort = new System.Windows.Forms.ToolStrip();
            this.check_bestBtn = new System.Windows.Forms.ToolStripButton();
            this.uncheckFit_Btn = new System.Windows.Forms.ToolStripButton();
            this.sortSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.refresh_fitRes_Btn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip_fragList = new System.Windows.Forms.ToolStrip();
            this.saveListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.loadListBtn11 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadFragmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListBtn11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripSeparator();
            this.checkall_Frag_Btn = new System.Windows.Forms.ToolStripButton();
            this.uncheckall_Frag_Btn = new System.Windows.Forms.ToolStripButton();
            this.toggle_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.show_files_Btn = new System.Windows.Forms.ToolStripButton();
            this.statistics_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripSeparator();
            this.fragCalc_Btn2 = new System.Windows.Forms.ToolStripButton();
            this.refresh_frag_Btn2 = new System.Windows.Forms.ToolStripButton();
            this.frag_sort_Btn2 = new System.Windows.Forms.ToolStripButton();
            this.factor_panel = new System.Windows.Forms.Panel();
            this.fragTypes_toolStrip = new System.Windows.Forms.ToolStrip();
            this.save_FragTypes_Btn = new System.Windows.Forms.ToolStripButton();
            this.toggle_FragTypes_Btn = new System.Windows.Forms.ToolStripButton();
            this.fragTypes_tree = new System.Windows.Forms.TreeView();
            this.theorData_grpBx = new System.Windows.Forms.GroupBox();
            this.ProfCalc_Btn = new System.Windows.Forms.Button();
            this.MSproduct_treeView = new System.Windows.Forms.TreeView();
            this.seqBtn = new System.Windows.Forms.Button();
            this.loadMS_Btn = new System.Windows.Forms.Button();
            this.plotFragProf_chkBox = new System.Windows.Forms.CheckBox();
            this.plotFragCent_chkBox = new System.Windows.Forms.CheckBox();
            this.expData_grpBx = new System.Windows.Forms.GroupBox();
            this.filename_txtBx = new System.Windows.Forms.TextBox();
            this.displayPeakList_btn = new System.Windows.Forms.Button();
            this.exp_Settings_toolStrip = new System.Windows.Forms.ToolStrip();
            this.settingsPeak_Btn = new System.Windows.Forms.ToolStripButton();
            this.plotCentr_chkBox = new System.Windows.Forms.CheckBox();
            this.plotExp_chkBox = new System.Windows.Forms.CheckBox();
            this.loadExp_Btn = new System.Windows.Forms.Button();
            this.fitOptions_grpBox = new System.Windows.Forms.GroupBox();
            this.fiToolStrip = new System.Windows.Forms.ToolStrip();
            this.Fitting_chkBox = new System.Windows.Forms.ToolStripButton();
            this.fitSettings_Btn = new System.Windows.Forms.ToolStripButton();
            this.fit_Btn = new System.Windows.Forms.Button();
            this.fit_sel_Btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_losses = new System.Windows.Forms.TabPage();
            this.losses_splitContainer = new System.Windows.Forms.SplitContainer();
            this.losses_groupBox7 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel7 = new System.Windows.Forms.Panel();
            this.checkboxes_panel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn7 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn7 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn7 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn7 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn7 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box7 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box7 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox5 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel5 = new System.Windows.Forms.Panel();
            this.checkboxes_panel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn5 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn5 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn5 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn5 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box5 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box5 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox3 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel3 = new System.Windows.Forms.Panel();
            this.checkboxes_panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn3 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn3 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn3 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn3 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box3 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box3 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox1 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel1 = new System.Windows.Forms.Panel();
            this.checkboxes_panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn1 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn1 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn1 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn1 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box1 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box1 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox8 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel8 = new System.Windows.Forms.Panel();
            this.checkboxes_panel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn8 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn8 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn8 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn8 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn8 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box8 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box8 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox6 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel6 = new System.Windows.Forms.Panel();
            this.checkboxes_panel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn6 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn6 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn6 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn6 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn6 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box6 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box6 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox4 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel4 = new System.Windows.Forms.Panel();
            this.checkboxes_panel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn4 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn4 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box4 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box4 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_groupBox2 = new System.Windows.Forms.GroupBox();
            this.losses_plot_panel2 = new System.Windows.Forms.Panel();
            this.checkboxes_panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.losses_toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.losses_saveBtn2 = new System.Windows.Forms.ToolStripButton();
            this.losses_copyBtn2 = new System.Windows.Forms.ToolStripButton();
            this.losses_DropBtn2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.losses_styleBtn2 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_extractBtn2 = new System.Windows.Forms.ToolStripMenuItem();
            this.losses_X_Box2 = new System.Windows.Forms.ToolStripTextBox();
            this.losses_Y_Box2 = new System.Windows.Forms.ToolStripTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.losses_label = new System.Windows.Forms.Label();
            this.contextMenuStrip_MSproduct.SuspendLayout();
            this.tabInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1_intIdx.SuspendLayout();
            this.int_Idx_toolStrip.SuspendLayout();
            this.panel2_intIdxTo.SuspendLayout();
            this.int_IdxTo_toolStrip.SuspendLayout();
            this.tabPrimary.SuspendLayout();
            this.panel2_tab3.SuspendLayout();
            this.groupBoxCharge4.SuspendLayout();
            this.Charge_toolStrip4.SuspendLayout();
            this.groupBoxCharge3.SuspendLayout();
            this.Charge_toolStrip3.SuspendLayout();
            this.groupBoxCharge2.SuspendLayout();
            this.Charge_toolStrip2.SuspendLayout();
            this.groupBoxCharge1.SuspendLayout();
            this.Charge_toolStrip1.SuspendLayout();
            this.panel1_tab3.SuspendLayout();
            this.groupBoxIntensity4.SuspendLayout();
            this.intensity_toolStrip4.SuspendLayout();
            this.groupBoxIntensity3.SuspendLayout();
            this.intensity_toolStrip3.SuspendLayout();
            this.groupBoxIntensity2.SuspendLayout();
            this.intensity_toolStrip2.SuspendLayout();
            this.groupBoxIntensity1.SuspendLayout();
            this.intensity_toolStrip1.SuspendLayout();
            this.tabDiagram.SuspendLayout();
            this.panel2_tab2.SuspendLayout();
            this.ppm_toolStrip6.SuspendLayout();
            this.ppm_toolStrip4.SuspendLayout();
            this.ppm_toolStrip5.SuspendLayout();
            this.ppm_toolStrip3.SuspendLayout();
            this.ppm_toolStrip2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.ppm_toolStrip.SuspendLayout();
            this.panel1_tab2.SuspendLayout();
            this.draw_sequence_panelCopy2.SuspendLayout();
            this.sequence_toolStripCopy2.SuspendLayout();
            this.sequence_PnlCopy2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBoxCopy2)).BeginInit();
            this.draw_sequence_panelCopy1.SuspendLayout();
            this.sequence_toolStripCopy1.SuspendLayout();
            this.sequence_PnlCopy1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBoxCopy1)).BeginInit();
            this.draw_sequence_panel.SuspendLayout();
            this.sequence_toolStrip.SuspendLayout();
            this.sequence_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBox)).BeginInit();
            this.tabFit.SuspendLayout();
            this.plots_grpBox.SuspendLayout();
            this.toolStrip_plot.SuspendLayout();
            this.user_grpBox.SuspendLayout();
            this.Fit_results_groupBox.SuspendLayout();
            this.toolStrip_fit_sort.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip_fragList.SuspendLayout();
            this.fragTypes_toolStrip.SuspendLayout();
            this.theorData_grpBx.SuspendLayout();
            this.expData_grpBx.SuspendLayout();
            this.exp_Settings_toolStrip.SuspendLayout();
            this.fitOptions_grpBox.SuspendLayout();
            this.fiToolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_losses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.losses_splitContainer)).BeginInit();
            this.losses_splitContainer.Panel1.SuspendLayout();
            this.losses_splitContainer.Panel2.SuspendLayout();
            this.losses_splitContainer.SuspendLayout();
            this.losses_groupBox7.SuspendLayout();
            this.losses_toolStrip7.SuspendLayout();
            this.losses_groupBox5.SuspendLayout();
            this.losses_toolStrip5.SuspendLayout();
            this.losses_groupBox3.SuspendLayout();
            this.losses_toolStrip3.SuspendLayout();
            this.losses_groupBox1.SuspendLayout();
            this.losses_toolStrip1.SuspendLayout();
            this.losses_groupBox8.SuspendLayout();
            this.losses_toolStrip8.SuspendLayout();
            this.losses_groupBox6.SuspendLayout();
            this.losses_toolStrip6.SuspendLayout();
            this.losses_groupBox4.SuspendLayout();
            this.losses_toolStrip4.SuspendLayout();
            this.losses_groupBox2.SuspendLayout();
            this.losses_toolStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_MSproduct
            // 
            this.contextMenuStrip_MSproduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip_MSproduct.Name = "contextMenuStrip_MSproduct";
            this.contextMenuStrip_MSproduct.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
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
            // loadFF_Btn
            // 
            this.loadFF_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFF_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadFF_Btn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.loadFF_Btn.Enabled = false;
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
            // deleteMSProd_Btn
            // 
            this.deleteMSProd_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteMSProd_Btn.BackColor = System.Drawing.Color.Transparent;
            this.deleteMSProd_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteMSProd_Btn.BackgroundImage")));
            this.deleteMSProd_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteMSProd_Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deleteMSProd_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteMSProd_Btn.Location = new System.Drawing.Point(191, 137);
            this.deleteMSProd_Btn.Name = "deleteMSProd_Btn";
            this.deleteMSProd_Btn.Size = new System.Drawing.Size(25, 25);
            this.deleteMSProd_Btn.TabIndex = 121;
            this.toolTip1.SetToolTip(this.deleteMSProd_Btn, "Delete MS Product lists");
            this.deleteMSProd_Btn.UseVisualStyleBackColor = false;
            this.deleteMSProd_Btn.Click += new System.EventHandler(this.deleteMSProd_Btn_Click);
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
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton4.Text = "toolStripButton4";
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
            this.splitContainer1.Panel2.Controls.Add(this.panel2_intIdxTo);
            this.splitContainer1.Panel2.Controls.Add(this.int_IdxTo_toolStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1356, 717);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 29;
            // 
            // panel1_intIdx
            // 
            this.panel1_intIdx.Controls.Add(this.idxPnl1);
            this.panel1_intIdx.Controls.Add(this.splitter2);
            this.panel1_intIdx.Controls.Add(this.idxInt_Pnl1);
            this.panel1_intIdx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1_intIdx.Location = new System.Drawing.Point(32, 20);
            this.panel1_intIdx.Name = "panel1_intIdx";
            this.panel1_intIdx.Size = new System.Drawing.Size(1324, 325);
            this.panel1_intIdx.TabIndex = 27;
            // 
            // idxPnl1
            // 
            this.idxPnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl1.Location = new System.Drawing.Point(0, 0);
            this.idxPnl1.Name = "idxPnl1";
            this.idxPnl1.Size = new System.Drawing.Size(1086, 325);
            this.idxPnl1.TabIndex = 28;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(1086, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 325);
            this.splitter2.TabIndex = 27;
            this.splitter2.TabStop = false;
            // 
            // idxInt_Pnl1
            // 
            this.idxInt_Pnl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl1.Location = new System.Drawing.Point(1089, 0);
            this.idxInt_Pnl1.Name = "idxInt_Pnl1";
            this.idxInt_Pnl1.Size = new System.Drawing.Size(235, 325);
            this.idxInt_Pnl1.TabIndex = 25;
            // 
            // idxPlotLbl
            // 
            this.idxPlotLbl.AutoSize = true;
            this.idxPlotLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.idxPlotLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPlotLbl.ForeColor = System.Drawing.Color.DarkCyan;
            this.idxPlotLbl.Location = new System.Drawing.Point(32, 0);
            this.idxPlotLbl.Name = "idxPlotLbl";
            this.idxPlotLbl.Size = new System.Drawing.Size(172, 20);
            this.idxPlotLbl.TabIndex = 20;
            this.idxPlotLbl.Text = "Internal fragments\' plot";
            // 
            // int_Idx_toolStrip
            // 
            this.int_Idx_toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.int_Idx_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_Idx_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_Idx_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxSave_Btn,
            this.int_IdxCopy_Btn,
            this.toolStripDropDownButton1});
            this.int_Idx_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_Idx_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.int_Idx_toolStrip.Name = "int_Idx_toolStrip";
            this.int_Idx_toolStrip.Padding = new System.Windows.Forms.Padding(0, 20, 1, 0);
            this.int_Idx_toolStrip.Size = new System.Drawing.Size(32, 345);
            this.int_Idx_toolStrip.TabIndex = 25;
            // 
            // int_IdxSave_Btn
            // 
            this.int_IdxSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxSave_Btn.Image")));
            this.int_IdxSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxSave_Btn.Name = "int_IdxSave_Btn";
            this.int_IdxSave_Btn.Size = new System.Drawing.Size(29, 22);
            this.int_IdxSave_Btn.Text = "Save";
            // 
            // int_IdxCopy_Btn
            // 
            this.int_IdxCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxCopy_Btn.Image")));
            this.int_IdxCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxCopy_Btn.Name = "int_IdxCopy_Btn";
            this.int_IdxCopy_Btn.Size = new System.Drawing.Size(29, 22);
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            // 
            // styleToolStripMenuItem3
            // 
            this.styleToolStripMenuItem3.Name = "styleToolStripMenuItem3";
            this.styleToolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.styleToolStripMenuItem3.Text = "Style";
            this.styleToolStripMenuItem3.ToolTipText = "Format the style of the plots in this tab";
            this.styleToolStripMenuItem3.Click += new System.EventHandler(this.styleToolStripMenuItem3_Click);
            // 
            // extractPlotToolStripMenuItem1
            // 
            this.extractPlotToolStripMenuItem1.Name = "extractPlotToolStripMenuItem1";
            this.extractPlotToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem1.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem1.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem1.Click += new System.EventHandler(this.extractPlotToolStripMenuItem1_Click);
            // 
            // panel2_intIdxTo
            // 
            this.panel2_intIdxTo.Controls.Add(this.idxPnl2);
            this.panel2_intIdxTo.Controls.Add(this.splitter3);
            this.panel2_intIdxTo.Controls.Add(this.idxInt_Pnl2);
            this.panel2_intIdxTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_intIdxTo.Location = new System.Drawing.Point(32, 0);
            this.panel2_intIdxTo.Name = "panel2_intIdxTo";
            this.panel2_intIdxTo.Size = new System.Drawing.Size(1324, 367);
            this.panel2_intIdxTo.TabIndex = 28;
            // 
            // idxPnl2
            // 
            this.idxPnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxPnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idxPnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxPnl2.Location = new System.Drawing.Point(0, 0);
            this.idxPnl2.Name = "idxPnl2";
            this.idxPnl2.Size = new System.Drawing.Size(1086, 367);
            this.idxPnl2.TabIndex = 29;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(1086, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 367);
            this.splitter3.TabIndex = 28;
            this.splitter3.TabStop = false;
            // 
            // idxInt_Pnl2
            // 
            this.idxInt_Pnl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.idxInt_Pnl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.idxInt_Pnl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idxInt_Pnl2.Location = new System.Drawing.Point(1089, 0);
            this.idxInt_Pnl2.Name = "idxInt_Pnl2";
            this.idxInt_Pnl2.Size = new System.Drawing.Size(235, 367);
            this.idxInt_Pnl2.TabIndex = 26;
            // 
            // int_IdxTo_toolStrip
            // 
            this.int_IdxTo_toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.int_IdxTo_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.int_IdxTo_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.int_IdxTo_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.int_IdxToSave_Btn,
            this.int_IdxToCopy_Btn,
            this.toolStripButton8});
            this.int_IdxTo_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.int_IdxTo_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.int_IdxTo_toolStrip.Name = "int_IdxTo_toolStrip";
            this.int_IdxTo_toolStrip.Size = new System.Drawing.Size(32, 367);
            this.int_IdxTo_toolStrip.TabIndex = 26;
            // 
            // int_IdxToSave_Btn
            // 
            this.int_IdxToSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToSave_Btn.Image")));
            this.int_IdxToSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToSave_Btn.Name = "int_IdxToSave_Btn";
            this.int_IdxToSave_Btn.Size = new System.Drawing.Size(29, 22);
            this.int_IdxToSave_Btn.Text = "Save";
            // 
            // int_IdxToCopy_Btn
            // 
            this.int_IdxToCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.int_IdxToCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("int_IdxToCopy_Btn.Image")));
            this.int_IdxToCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.int_IdxToCopy_Btn.Name = "int_IdxToCopy_Btn";
            this.int_IdxToCopy_Btn.Size = new System.Drawing.Size(29, 22);
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
            this.toolStripButton8.Size = new System.Drawing.Size(29, 22);
            // 
            // extractPlotToolStripMenuItem2
            // 
            this.extractPlotToolStripMenuItem2.Name = "extractPlotToolStripMenuItem2";
            this.extractPlotToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem2.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem2.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem2.Click += new System.EventHandler(this.extractPlotToolStripMenuItem2_Click);
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
            this.panel2_tab3.Controls.Add(this.groupBoxCharge4);
            this.panel2_tab3.Controls.Add(this.groupBoxCharge3);
            this.panel2_tab3.Controls.Add(this.groupBoxCharge2);
            this.panel2_tab3.Controls.Add(this.groupBoxCharge1);
            this.panel2_tab3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab3.Location = new System.Drawing.Point(751, 3);
            this.panel2_tab3.Name = "panel2_tab3";
            this.panel2_tab3.Size = new System.Drawing.Size(608, 717);
            this.panel2_tab3.TabIndex = 26;
            // 
            // groupBoxCharge4
            // 
            this.groupBoxCharge4.Controls.Add(this.dzCharge_Pnl);
            this.groupBoxCharge4.Controls.Add(this.Charge_toolStrip4);
            this.groupBoxCharge4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCharge4.Location = new System.Drawing.Point(0, 768);
            this.groupBoxCharge4.Name = "groupBoxCharge4";
            this.groupBoxCharge4.Size = new System.Drawing.Size(591, 256);
            this.groupBoxCharge4.TabIndex = 33;
            this.groupBoxCharge4.TabStop = false;
            // 
            // dzCharge_Pnl
            // 
            this.dzCharge_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dzCharge_Pnl.Location = new System.Drawing.Point(3, 16);
            this.dzCharge_Pnl.Name = "dzCharge_Pnl";
            this.dzCharge_Pnl.Size = new System.Drawing.Size(542, 237);
            this.dzCharge_Pnl.TabIndex = 29;
            this.dzCharge_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // Charge_toolStrip4
            // 
            this.Charge_toolStrip4.Dock = System.Windows.Forms.DockStyle.Right;
            this.Charge_toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Charge_toolStrip4.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Charge_toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dzChargeSave_Btn,
            this.dzChargeCopy_Btn,
            this.toolStripDropDownButton2,
            this.up4_Btn,
            this.down4_Btn,
            this.dzcharge_X_Box,
            this.dzcharge_Y_Box});
            this.Charge_toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Charge_toolStrip4.Location = new System.Drawing.Point(545, 16);
            this.Charge_toolStrip4.Name = "Charge_toolStrip4";
            this.Charge_toolStrip4.Size = new System.Drawing.Size(43, 237);
            this.Charge_toolStrip4.TabIndex = 24;
            // 
            // dzChargeSave_Btn
            // 
            this.dzChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dzChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("dzChargeSave_Btn.Image")));
            this.dzChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dzChargeSave_Btn.Name = "dzChargeSave_Btn";
            this.dzChargeSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.dzChargeSave_Btn.Text = "Save";
            this.dzChargeSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // dzChargeCopy_Btn
            // 
            this.dzChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dzChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("dzChargeCopy_Btn.Image")));
            this.dzChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dzChargeCopy_Btn.Name = "dzChargeCopy_Btn";
            this.dzChargeCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.dzChargeCopy_Btn.Text = "Copy";
            this.dzChargeCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem_charge_dz});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem_charge_dz
            // 
            this.extractPlotToolStripMenuItem_charge_dz.Name = "extractPlotToolStripMenuItem_charge_dz";
            this.extractPlotToolStripMenuItem_charge_dz.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem_charge_dz.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem_charge_dz.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem_charge_dz.Click += new System.EventHandler(this.extractPlotToolStripMenuItem_charge_dz_Click);
            // 
            // up4_Btn
            // 
            this.up4_Btn.Checked = true;
            this.up4_Btn.CheckOnClick = true;
            this.up4_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.up4_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.up4_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.up4_Btn.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.up4_Btn.Image = ((System.Drawing.Image)(resources.GetObject("up4_Btn.Image")));
            this.up4_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.up4_Btn.Name = "up4_Btn";
            this.up4_Btn.Size = new System.Drawing.Size(40, 24);
            this.up4_Btn.Text = "d";
            // 
            // down4_Btn
            // 
            this.down4_Btn.Checked = true;
            this.down4_Btn.CheckOnClick = true;
            this.down4_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.down4_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.down4_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.down4_Btn.ForeColor = System.Drawing.Color.HotPink;
            this.down4_Btn.Image = ((System.Drawing.Image)(resources.GetObject("down4_Btn.Image")));
            this.down4_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.down4_Btn.Name = "down4_Btn";
            this.down4_Btn.Size = new System.Drawing.Size(40, 24);
            this.down4_Btn.Text = "z";
            // 
            // dzcharge_X_Box
            // 
            this.dzcharge_X_Box.AutoSize = false;
            this.dzcharge_X_Box.Name = "dzcharge_X_Box";
            this.dzcharge_X_Box.ReadOnly = true;
            this.dzcharge_X_Box.Size = new System.Drawing.Size(40, 22);
            this.dzcharge_X_Box.ToolTipText = "Width";
            // 
            // dzcharge_Y_Box
            // 
            this.dzcharge_Y_Box.AutoSize = false;
            this.dzcharge_Y_Box.Name = "dzcharge_Y_Box";
            this.dzcharge_Y_Box.ReadOnly = true;
            this.dzcharge_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.dzcharge_Y_Box.ToolTipText = "Height";
            // 
            // groupBoxCharge3
            // 
            this.groupBoxCharge3.Controls.Add(this.czCharge_Pnl);
            this.groupBoxCharge3.Controls.Add(this.Charge_toolStrip3);
            this.groupBoxCharge3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCharge3.Location = new System.Drawing.Point(0, 512);
            this.groupBoxCharge3.Name = "groupBoxCharge3";
            this.groupBoxCharge3.Size = new System.Drawing.Size(591, 256);
            this.groupBoxCharge3.TabIndex = 32;
            this.groupBoxCharge3.TabStop = false;
            // 
            // czCharge_Pnl
            // 
            this.czCharge_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.czCharge_Pnl.Location = new System.Drawing.Point(3, 16);
            this.czCharge_Pnl.Name = "czCharge_Pnl";
            this.czCharge_Pnl.Size = new System.Drawing.Size(542, 237);
            this.czCharge_Pnl.TabIndex = 29;
            this.czCharge_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // Charge_toolStrip3
            // 
            this.Charge_toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.Charge_toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Charge_toolStrip3.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Charge_toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czChargeSave_Btn,
            this.czChargeCopy_Btn,
            this.toolStripButton9,
            this.up3_Btn,
            this.down3_Btn,
            this.czcharge_X_Box,
            this.czcharge_Y_Box});
            this.Charge_toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Charge_toolStrip3.Location = new System.Drawing.Point(545, 16);
            this.Charge_toolStrip3.Name = "Charge_toolStrip3";
            this.Charge_toolStrip3.Size = new System.Drawing.Size(43, 237);
            this.Charge_toolStrip3.TabIndex = 24;
            // 
            // czChargeSave_Btn
            // 
            this.czChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeSave_Btn.Image")));
            this.czChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeSave_Btn.Name = "czChargeSave_Btn";
            this.czChargeSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.czChargeSave_Btn.Text = "Save";
            this.czChargeSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // czChargeCopy_Btn
            // 
            this.czChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czChargeCopy_Btn.Image")));
            this.czChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czChargeCopy_Btn.Name = "czChargeCopy_Btn";
            this.czChargeCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.czChargeCopy_Btn.Text = "Copy";
            this.czChargeCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem6});
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem6
            // 
            this.extractPlotToolStripMenuItem6.Name = "extractPlotToolStripMenuItem6";
            this.extractPlotToolStripMenuItem6.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem6.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem6.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem6.Click += new System.EventHandler(this.extractPlotToolStripMenuItem6_Click);
            // 
            // up3_Btn
            // 
            this.up3_Btn.Checked = true;
            this.up3_Btn.CheckOnClick = true;
            this.up3_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.up3_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.up3_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.up3_Btn.ForeColor = System.Drawing.Color.Firebrick;
            this.up3_Btn.Image = ((System.Drawing.Image)(resources.GetObject("up3_Btn.Image")));
            this.up3_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.up3_Btn.Name = "up3_Btn";
            this.up3_Btn.Size = new System.Drawing.Size(40, 24);
            this.up3_Btn.Text = "c";
            // 
            // down3_Btn
            // 
            this.down3_Btn.Checked = true;
            this.down3_Btn.CheckOnClick = true;
            this.down3_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.down3_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.down3_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.down3_Btn.ForeColor = System.Drawing.Color.Tomato;
            this.down3_Btn.Image = ((System.Drawing.Image)(resources.GetObject("down3_Btn.Image")));
            this.down3_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.down3_Btn.Name = "down3_Btn";
            this.down3_Btn.Size = new System.Drawing.Size(40, 24);
            this.down3_Btn.Text = "z";
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
            // groupBoxCharge2
            // 
            this.groupBoxCharge2.Controls.Add(this.byCharge_Pnl);
            this.groupBoxCharge2.Controls.Add(this.Charge_toolStrip2);
            this.groupBoxCharge2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCharge2.Location = new System.Drawing.Point(0, 256);
            this.groupBoxCharge2.Name = "groupBoxCharge2";
            this.groupBoxCharge2.Size = new System.Drawing.Size(591, 256);
            this.groupBoxCharge2.TabIndex = 31;
            this.groupBoxCharge2.TabStop = false;
            // 
            // byCharge_Pnl
            // 
            this.byCharge_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byCharge_Pnl.Location = new System.Drawing.Point(3, 16);
            this.byCharge_Pnl.Name = "byCharge_Pnl";
            this.byCharge_Pnl.Size = new System.Drawing.Size(542, 237);
            this.byCharge_Pnl.TabIndex = 28;
            this.byCharge_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // Charge_toolStrip2
            // 
            this.Charge_toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Charge_toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Charge_toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Charge_toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byChargeSave_Btn,
            this.byChargeCopy_Btn,
            this.toolStripButton7,
            this.up2_Btn,
            this.down2_Btn,
            this.bycharge_X_Box,
            this.bycharge_Y_Box});
            this.Charge_toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Charge_toolStrip2.Location = new System.Drawing.Point(545, 16);
            this.Charge_toolStrip2.Name = "Charge_toolStrip2";
            this.Charge_toolStrip2.Size = new System.Drawing.Size(43, 237);
            this.Charge_toolStrip2.TabIndex = 25;
            // 
            // byChargeSave_Btn
            // 
            this.byChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeSave_Btn.Image")));
            this.byChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeSave_Btn.Name = "byChargeSave_Btn";
            this.byChargeSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.byChargeSave_Btn.Text = "Save";
            this.byChargeSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // byChargeCopy_Btn
            // 
            this.byChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byChargeCopy_Btn.Image")));
            this.byChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byChargeCopy_Btn.Name = "byChargeCopy_Btn";
            this.byChargeCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.byChargeCopy_Btn.Text = "Copy";
            this.byChargeCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem5});
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem5
            // 
            this.extractPlotToolStripMenuItem5.Name = "extractPlotToolStripMenuItem5";
            this.extractPlotToolStripMenuItem5.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem5.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem5.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem5.Click += new System.EventHandler(this.extractPlotToolStripMenuItem5_Click);
            // 
            // up2_Btn
            // 
            this.up2_Btn.Checked = true;
            this.up2_Btn.CheckOnClick = true;
            this.up2_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.up2_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.up2_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.up2_Btn.ForeColor = System.Drawing.Color.Blue;
            this.up2_Btn.Image = ((System.Drawing.Image)(resources.GetObject("up2_Btn.Image")));
            this.up2_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.up2_Btn.Name = "up2_Btn";
            this.up2_Btn.Size = new System.Drawing.Size(40, 24);
            this.up2_Btn.Text = "b";
            // 
            // down2_Btn
            // 
            this.down2_Btn.Checked = true;
            this.down2_Btn.CheckOnClick = true;
            this.down2_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.down2_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.down2_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.down2_Btn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.down2_Btn.Image = ((System.Drawing.Image)(resources.GetObject("down2_Btn.Image")));
            this.down2_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.down2_Btn.Name = "down2_Btn";
            this.down2_Btn.Size = new System.Drawing.Size(40, 24);
            this.down2_Btn.Text = "y";
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
            // groupBoxCharge1
            // 
            this.groupBoxCharge1.Controls.Add(this.axCharge_Pnl);
            this.groupBoxCharge1.Controls.Add(this.Charge_toolStrip1);
            this.groupBoxCharge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCharge1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCharge1.Name = "groupBoxCharge1";
            this.groupBoxCharge1.Size = new System.Drawing.Size(591, 256);
            this.groupBoxCharge1.TabIndex = 30;
            this.groupBoxCharge1.TabStop = false;
            // 
            // axCharge_Pnl
            // 
            this.axCharge_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axCharge_Pnl.Location = new System.Drawing.Point(3, 16);
            this.axCharge_Pnl.Name = "axCharge_Pnl";
            this.axCharge_Pnl.Size = new System.Drawing.Size(542, 237);
            this.axCharge_Pnl.TabIndex = 27;
            this.axCharge_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // Charge_toolStrip1
            // 
            this.Charge_toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Charge_toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Charge_toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Charge_toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axChargeSave_Btn,
            this.axChargeCopy_Btn,
            this.form_primCharge_Btn,
            this.up1_Btn,
            this.down1_Btn,
            this.axcharge_X_Box,
            this.axcharge_Y_Box});
            this.Charge_toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Charge_toolStrip1.Location = new System.Drawing.Point(545, 16);
            this.Charge_toolStrip1.Name = "Charge_toolStrip1";
            this.Charge_toolStrip1.Size = new System.Drawing.Size(43, 237);
            this.Charge_toolStrip1.TabIndex = 26;
            // 
            // axChargeSave_Btn
            // 
            this.axChargeSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeSave_Btn.Image")));
            this.axChargeSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeSave_Btn.Name = "axChargeSave_Btn";
            this.axChargeSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.axChargeSave_Btn.Text = "Save";
            this.axChargeSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // axChargeCopy_Btn
            // 
            this.axChargeCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axChargeCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axChargeCopy_Btn.Image")));
            this.axChargeCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axChargeCopy_Btn.Name = "axChargeCopy_Btn";
            this.axChargeCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.axChargeCopy_Btn.Text = "Copy";
            this.axChargeCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
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
            this.form_primCharge_Btn.Size = new System.Drawing.Size(40, 22);
            this.form_primCharge_Btn.Text = " ";
            // 
            // style_toolStripMenuItem
            // 
            this.style_toolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.style_toolStripMenuItem.Name = "style_toolStripMenuItem";
            this.style_toolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.style_toolStripMenuItem.Text = "Style";
            this.style_toolStripMenuItem.ToolTipText = "Format the style of the plots in this tab";
            this.style_toolStripMenuItem.Click += new System.EventHandler(this.style_toolStripMenuItem_Click);
            // 
            // extractPlotToolStripMenuItem7
            // 
            this.extractPlotToolStripMenuItem7.Name = "extractPlotToolStripMenuItem7";
            this.extractPlotToolStripMenuItem7.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem7.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem7.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem7.Click += new System.EventHandler(this.extractPlotToolStripMenuItem7_Click);
            // 
            // up1_Btn
            // 
            this.up1_Btn.Checked = true;
            this.up1_Btn.CheckOnClick = true;
            this.up1_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.up1_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.up1_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.up1_Btn.ForeColor = System.Drawing.Color.Green;
            this.up1_Btn.Image = ((System.Drawing.Image)(resources.GetObject("up1_Btn.Image")));
            this.up1_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.up1_Btn.Name = "up1_Btn";
            this.up1_Btn.Size = new System.Drawing.Size(40, 24);
            this.up1_Btn.Text = "a";
            // 
            // down1_Btn
            // 
            this.down1_Btn.Checked = true;
            this.down1_Btn.CheckOnClick = true;
            this.down1_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.down1_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.down1_Btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.down1_Btn.ForeColor = System.Drawing.Color.Lime;
            this.down1_Btn.Image = ((System.Drawing.Image)(resources.GetObject("down1_Btn.Image")));
            this.down1_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.down1_Btn.Name = "down1_Btn";
            this.down1_Btn.Size = new System.Drawing.Size(40, 24);
            this.down1_Btn.Text = "x";
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(746, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 717);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // panel1_tab3
            // 
            this.panel1_tab3.AutoScroll = true;
            this.panel1_tab3.Controls.Add(this.groupBoxIntensity4);
            this.panel1_tab3.Controls.Add(this.groupBoxIntensity3);
            this.panel1_tab3.Controls.Add(this.groupBoxIntensity2);
            this.panel1_tab3.Controls.Add(this.groupBoxIntensity1);
            this.panel1_tab3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1_tab3.Location = new System.Drawing.Point(3, 3);
            this.panel1_tab3.Name = "panel1_tab3";
            this.panel1_tab3.Size = new System.Drawing.Size(743, 717);
            this.panel1_tab3.TabIndex = 24;
            // 
            // groupBoxIntensity4
            // 
            this.groupBoxIntensity4.Controls.Add(this.dz_Pnl);
            this.groupBoxIntensity4.Controls.Add(this.intensity_toolStrip4);
            this.groupBoxIntensity4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxIntensity4.Location = new System.Drawing.Point(0, 768);
            this.groupBoxIntensity4.Name = "groupBoxIntensity4";
            this.groupBoxIntensity4.Size = new System.Drawing.Size(726, 256);
            this.groupBoxIntensity4.TabIndex = 33;
            this.groupBoxIntensity4.TabStop = false;
            // 
            // dz_Pnl
            // 
            this.dz_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dz_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dz_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dz_Pnl.Location = new System.Drawing.Point(46, 16);
            this.dz_Pnl.Name = "dz_Pnl";
            this.dz_Pnl.Size = new System.Drawing.Size(677, 237);
            this.dz_Pnl.TabIndex = 23;
            this.dz_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // intensity_toolStrip4
            // 
            this.intensity_toolStrip4.Dock = System.Windows.Forms.DockStyle.Left;
            this.intensity_toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.intensity_toolStrip4.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.intensity_toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dzSave_Btn,
            this.dzCopy_Btn,
            this.toolStripDropDownButton3,
            this.dz_X_Box,
            this.dz_Y_Box});
            this.intensity_toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.intensity_toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.intensity_toolStrip4.Name = "intensity_toolStrip4";
            this.intensity_toolStrip4.Size = new System.Drawing.Size(43, 237);
            this.intensity_toolStrip4.TabIndex = 25;
            // 
            // dzSave_Btn
            // 
            this.dzSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dzSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("dzSave_Btn.Image")));
            this.dzSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dzSave_Btn.Name = "dzSave_Btn";
            this.dzSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.dzSave_Btn.Text = "Save";
            this.dzSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // dzCopy_Btn
            // 
            this.dzCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dzCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("dzCopy_Btn.Image")));
            this.dzCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dzCopy_Btn.Name = "dzCopy_Btn";
            this.dzCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.dzCopy_Btn.Text = "Copy";
            this.dzCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem_dz});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem_dz
            // 
            this.extractPlotToolStripMenuItem_dz.Name = "extractPlotToolStripMenuItem_dz";
            this.extractPlotToolStripMenuItem_dz.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem_dz.Text = "Extract Plot";
            this.extractPlotToolStripMenuItem_dz.ToolTipText = "Extract plot and edit its shape";
            this.extractPlotToolStripMenuItem_dz.Click += new System.EventHandler(this.extractPlotToolStripMenuItem_dz_Click);
            // 
            // dz_X_Box
            // 
            this.dz_X_Box.AutoSize = false;
            this.dz_X_Box.Name = "dz_X_Box";
            this.dz_X_Box.ReadOnly = true;
            this.dz_X_Box.Size = new System.Drawing.Size(40, 22);
            this.dz_X_Box.ToolTipText = "Width";
            // 
            // dz_Y_Box
            // 
            this.dz_Y_Box.AutoSize = false;
            this.dz_Y_Box.Name = "dz_Y_Box";
            this.dz_Y_Box.ReadOnly = true;
            this.dz_Y_Box.Size = new System.Drawing.Size(40, 22);
            this.dz_Y_Box.ToolTipText = "Height";
            // 
            // groupBoxIntensity3
            // 
            this.groupBoxIntensity3.Controls.Add(this.cz_Pnl);
            this.groupBoxIntensity3.Controls.Add(this.intensity_toolStrip3);
            this.groupBoxIntensity3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxIntensity3.Location = new System.Drawing.Point(0, 512);
            this.groupBoxIntensity3.Name = "groupBoxIntensity3";
            this.groupBoxIntensity3.Size = new System.Drawing.Size(726, 256);
            this.groupBoxIntensity3.TabIndex = 32;
            this.groupBoxIntensity3.TabStop = false;
            // 
            // cz_Pnl
            // 
            this.cz_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cz_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cz_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cz_Pnl.Location = new System.Drawing.Point(46, 16);
            this.cz_Pnl.Name = "cz_Pnl";
            this.cz_Pnl.Size = new System.Drawing.Size(677, 237);
            this.cz_Pnl.TabIndex = 23;
            this.cz_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // intensity_toolStrip3
            // 
            this.intensity_toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.intensity_toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.intensity_toolStrip3.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.intensity_toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czSave_Btn,
            this.czCopy_Btn,
            this.toolStripButton6,
            this.cz_X_Box,
            this.cz_Y_Box});
            this.intensity_toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.intensity_toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.intensity_toolStrip3.Name = "intensity_toolStrip3";
            this.intensity_toolStrip3.Size = new System.Drawing.Size(43, 237);
            this.intensity_toolStrip3.TabIndex = 25;
            // 
            // czSave_Btn
            // 
            this.czSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czSave_Btn.Image")));
            this.czSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czSave_Btn.Name = "czSave_Btn";
            this.czSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.czSave_Btn.Text = "Save";
            this.czSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // czCopy_Btn
            // 
            this.czCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.czCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("czCopy_Btn.Image")));
            this.czCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.czCopy_Btn.Name = "czCopy_Btn";
            this.czCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.czCopy_Btn.Text = "Copy";
            this.czCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem8});
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem8
            // 
            this.extractPlotToolStripMenuItem8.Name = "extractPlotToolStripMenuItem8";
            this.extractPlotToolStripMenuItem8.Size = new System.Drawing.Size(133, 22);
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
            // groupBoxIntensity2
            // 
            this.groupBoxIntensity2.Controls.Add(this.by_Pnl);
            this.groupBoxIntensity2.Controls.Add(this.intensity_toolStrip2);
            this.groupBoxIntensity2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxIntensity2.Location = new System.Drawing.Point(0, 256);
            this.groupBoxIntensity2.Name = "groupBoxIntensity2";
            this.groupBoxIntensity2.Size = new System.Drawing.Size(726, 256);
            this.groupBoxIntensity2.TabIndex = 31;
            this.groupBoxIntensity2.TabStop = false;
            // 
            // by_Pnl
            // 
            this.by_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.by_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.by_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.by_Pnl.Location = new System.Drawing.Point(46, 16);
            this.by_Pnl.Name = "by_Pnl";
            this.by_Pnl.Size = new System.Drawing.Size(677, 237);
            this.by_Pnl.TabIndex = 22;
            this.by_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // intensity_toolStrip2
            // 
            this.intensity_toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.intensity_toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.intensity_toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.intensity_toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byCopy_Btn,
            this.bySave_Btn,
            this.toolStripButton5,
            this.by_X_Box,
            this.by_Y_Box});
            this.intensity_toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.intensity_toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.intensity_toolStrip2.Name = "intensity_toolStrip2";
            this.intensity_toolStrip2.Size = new System.Drawing.Size(43, 237);
            this.intensity_toolStrip2.TabIndex = 26;
            // 
            // byCopy_Btn
            // 
            this.byCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.byCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("byCopy_Btn.Image")));
            this.byCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.byCopy_Btn.Name = "byCopy_Btn";
            this.byCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.byCopy_Btn.Text = "Copy";
            this.byCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // bySave_Btn
            // 
            this.bySave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bySave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("bySave_Btn.Image")));
            this.bySave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bySave_Btn.Name = "bySave_Btn";
            this.bySave_Btn.Size = new System.Drawing.Size(40, 22);
            this.bySave_Btn.Text = "Save";
            this.bySave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem4});
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(40, 22);
            // 
            // extractPlotToolStripMenuItem4
            // 
            this.extractPlotToolStripMenuItem4.Name = "extractPlotToolStripMenuItem4";
            this.extractPlotToolStripMenuItem4.Size = new System.Drawing.Size(133, 22);
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
            // groupBoxIntensity1
            // 
            this.groupBoxIntensity1.Controls.Add(this.ax_Pnl);
            this.groupBoxIntensity1.Controls.Add(this.intensity_toolStrip1);
            this.groupBoxIntensity1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxIntensity1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxIntensity1.Name = "groupBoxIntensity1";
            this.groupBoxIntensity1.Size = new System.Drawing.Size(726, 256);
            this.groupBoxIntensity1.TabIndex = 30;
            this.groupBoxIntensity1.TabStop = false;
            // 
            // ax_Pnl
            // 
            this.ax_Pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ax_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ax_Pnl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ax_Pnl.Location = new System.Drawing.Point(46, 16);
            this.ax_Pnl.Name = "ax_Pnl";
            this.ax_Pnl.Size = new System.Drawing.Size(677, 237);
            this.ax_Pnl.TabIndex = 21;
            this.ax_Pnl.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // intensity_toolStrip1
            // 
            this.intensity_toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.intensity_toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.intensity_toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.intensity_toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.axSave_Btn,
            this.axCopy_Btn,
            this.form_prim_Btn,
            this.ax_X_Box,
            this.ax_Y_Box});
            this.intensity_toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.intensity_toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.intensity_toolStrip1.Name = "intensity_toolStrip1";
            this.intensity_toolStrip1.Size = new System.Drawing.Size(43, 237);
            this.intensity_toolStrip1.TabIndex = 24;
            // 
            // axSave_Btn
            // 
            this.axSave_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axSave_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axSave_Btn.Image")));
            this.axSave_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axSave_Btn.Name = "axSave_Btn";
            this.axSave_Btn.Size = new System.Drawing.Size(40, 22);
            this.axSave_Btn.Text = "Save";
            this.axSave_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // axCopy_Btn
            // 
            this.axCopy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.axCopy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("axCopy_Btn.Image")));
            this.axCopy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.axCopy_Btn.Name = "axCopy_Btn";
            this.axCopy_Btn.Size = new System.Drawing.Size(40, 22);
            this.axCopy_Btn.Text = "Copy";
            this.axCopy_Btn.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
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
            this.form_prim_Btn.Size = new System.Drawing.Size(40, 22);
            this.form_prim_Btn.Text = " ";
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.styleToolStripMenuItem.Text = "Style";
            this.styleToolStripMenuItem.ToolTipText = "Format the style of the plots in this tab";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.styleToolStripMenuItem_Click);
            // 
            // extractPlotToolStripMenuItem3
            // 
            this.extractPlotToolStripMenuItem3.Name = "extractPlotToolStripMenuItem3";
            this.extractPlotToolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
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
            this.splitter4.Size = new System.Drawing.Size(5, 717);
            this.splitter4.TabIndex = 25;
            this.splitter4.TabStop = false;
            // 
            // panel2_tab2
            // 
            this.panel2_tab2.AutoScroll = true;
            this.panel2_tab2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip6);
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip4);
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip5);
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip3);
            this.panel2_tab2.Controls.Add(this.ppm_toolStrip2);
            this.panel2_tab2.Controls.Add(this.toolStripContainer1);
            this.panel2_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2_tab2.Location = new System.Drawing.Point(780, 3);
            this.panel2_tab2.Name = "panel2_tab2";
            this.panel2_tab2.Size = new System.Drawing.Size(579, 717);
            this.panel2_tab2.TabIndex = 1;
            // 
            // ppm_toolStrip6
            // 
            this.ppm_toolStrip6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppm_toolStrip6.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ppm_toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_M,
            this.ppm_M_H2O,
            this.ppm_M_NH3,
            this.ppm_uncheckBtn,
            this.ppm_checkall_Btn,
            this.ppm_B_});
            this.ppm_toolStrip6.Location = new System.Drawing.Point(0, 476);
            this.ppm_toolStrip6.Name = "ppm_toolStrip6";
            this.ppm_toolStrip6.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.ppm_toolStrip6.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ppm_toolStrip6.Size = new System.Drawing.Size(579, 27);
            this.ppm_toolStrip6.TabIndex = 8;
            // 
            // ppm_M
            // 
            this.ppm_M.Checked = true;
            this.ppm_M.CheckOnClick = true;
            this.ppm_M.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_M.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_M.ForeColor = System.Drawing.Color.Maroon;
            this.ppm_M.Image = ((System.Drawing.Image)(resources.GetObject("ppm_M.Image")));
            this.ppm_M.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_M.Name = "ppm_M";
            this.ppm_M.Size = new System.Drawing.Size(24, 24);
            this.ppm_M.Text = "M";
            this.ppm_M.ToolTipText = "M";
            // 
            // ppm_M_H2O
            // 
            this.ppm_M_H2O.Checked = true;
            this.ppm_M_H2O.CheckOnClick = true;
            this.ppm_M_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_M_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_M_H2O.ForeColor = System.Drawing.Color.Maroon;
            this.ppm_M_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_M_H2O.Image")));
            this.ppm_M_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_M_H2O.Name = "ppm_M_H2O";
            this.ppm_M_H2O.Size = new System.Drawing.Size(59, 24);
            this.ppm_M_H2O.Text = "M-H2O";
            // 
            // ppm_M_NH3
            // 
            this.ppm_M_NH3.Checked = true;
            this.ppm_M_NH3.CheckOnClick = true;
            this.ppm_M_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_M_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_M_NH3.ForeColor = System.Drawing.Color.Maroon;
            this.ppm_M_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_M_NH3.Image")));
            this.ppm_M_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_M_NH3.Name = "ppm_M_NH3";
            this.ppm_M_NH3.Size = new System.Drawing.Size(59, 24);
            this.ppm_M_NH3.Text = "M-NH3";
            // 
            // ppm_uncheckBtn
            // 
            this.ppm_uncheckBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ppm_uncheckBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ppm_uncheckBtn.Image = ((System.Drawing.Image)(resources.GetObject("ppm_uncheckBtn.Image")));
            this.ppm_uncheckBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_uncheckBtn.Name = "ppm_uncheckBtn";
            this.ppm_uncheckBtn.Size = new System.Drawing.Size(102, 24);
            this.ppm_uncheckBtn.Text = "Uncheck all";
            this.ppm_uncheckBtn.ToolTipText = "Uncheck all";
            this.ppm_uncheckBtn.Click += new System.EventHandler(this.ppm_uncheckBtn_Click);
            // 
            // ppm_checkall_Btn
            // 
            this.ppm_checkall_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ppm_checkall_Btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ppm_checkall_Btn.Image = ((System.Drawing.Image)(resources.GetObject("ppm_checkall_Btn.Image")));
            this.ppm_checkall_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_checkall_Btn.Name = "ppm_checkall_Btn";
            this.ppm_checkall_Btn.Size = new System.Drawing.Size(87, 24);
            this.ppm_checkall_Btn.Text = "Check all";
            this.ppm_checkall_Btn.ToolTipText = "Check all";
            this.ppm_checkall_Btn.Click += new System.EventHandler(this.ppm_checkall_Btn_Click);
            // 
            // ppm_B_
            // 
            this.ppm_B_.Checked = true;
            this.ppm_B_.CheckOnClick = true;
            this.ppm_B_.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_B_.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_B_.ForeColor = System.Drawing.Color.Maroon;
            this.ppm_B_.Image = ((System.Drawing.Image)(resources.GetObject("ppm_B_.Image")));
            this.ppm_B_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_B_.Name = "ppm_B_";
            this.ppm_B_.Size = new System.Drawing.Size(32, 24);
            this.ppm_B_.Text = "B()";
            // 
            // ppm_toolStrip4
            // 
            this.ppm_toolStrip4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppm_toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_internal_b,
            this.ppm_internal_b_H2O,
            this.ppm_internal_b_NH3});
            this.ppm_toolStrip4.Location = new System.Drawing.Point(0, 451);
            this.ppm_toolStrip4.Name = "ppm_toolStrip4";
            this.ppm_toolStrip4.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.ppm_toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ppm_toolStrip4.Size = new System.Drawing.Size(579, 25);
            this.ppm_toolStrip4.TabIndex = 7;
            // 
            // ppm_internal_b
            // 
            this.ppm_internal_b.Checked = true;
            this.ppm_internal_b.CheckOnClick = true;
            this.ppm_internal_b.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_b.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_b.ForeColor = System.Drawing.Color.MediumOrchid;
            this.ppm_internal_b.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_b.Image")));
            this.ppm_internal_b.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_b.Name = "ppm_internal_b";
            this.ppm_internal_b.Size = new System.Drawing.Size(76, 22);
            this.ppm_internal_b.Text = "internal b";
            // 
            // ppm_internal_b_H2O
            // 
            this.ppm_internal_b_H2O.Checked = true;
            this.ppm_internal_b_H2O.CheckOnClick = true;
            this.ppm_internal_b_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_b_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_b_H2O.ForeColor = System.Drawing.Color.MediumOrchid;
            this.ppm_internal_b_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_b_H2O.Image")));
            this.ppm_internal_b_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_b_H2O.Name = "ppm_internal_b_H2O";
            this.ppm_internal_b_H2O.Size = new System.Drawing.Size(111, 22);
            this.ppm_internal_b_H2O.Text = "internal b-H2O";
            // 
            // ppm_internal_b_NH3
            // 
            this.ppm_internal_b_NH3.Checked = true;
            this.ppm_internal_b_NH3.CheckOnClick = true;
            this.ppm_internal_b_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_b_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_b_NH3.ForeColor = System.Drawing.Color.MediumOrchid;
            this.ppm_internal_b_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_b_NH3.Image")));
            this.ppm_internal_b_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_b_NH3.Name = "ppm_internal_b_NH3";
            this.ppm_internal_b_NH3.Size = new System.Drawing.Size(111, 22);
            this.ppm_internal_b_NH3.Text = "internal b-NH3";
            // 
            // ppm_toolStrip5
            // 
            this.ppm_toolStrip5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppm_toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_internal_a,
            this.ppm_internal_a_H2O,
            this.ppm_internal_a_NH3});
            this.ppm_toolStrip5.Location = new System.Drawing.Point(0, 426);
            this.ppm_toolStrip5.Name = "ppm_toolStrip5";
            this.ppm_toolStrip5.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.ppm_toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ppm_toolStrip5.Size = new System.Drawing.Size(579, 25);
            this.ppm_toolStrip5.TabIndex = 6;
            // 
            // ppm_internal_a
            // 
            this.ppm_internal_a.Checked = true;
            this.ppm_internal_a.CheckOnClick = true;
            this.ppm_internal_a.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_a.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_a.ForeColor = System.Drawing.Color.DarkViolet;
            this.ppm_internal_a.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_a.Image")));
            this.ppm_internal_a.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_a.Name = "ppm_internal_a";
            this.ppm_internal_a.Size = new System.Drawing.Size(76, 22);
            this.ppm_internal_a.Text = "internal a";
            // 
            // ppm_internal_a_H2O
            // 
            this.ppm_internal_a_H2O.Checked = true;
            this.ppm_internal_a_H2O.CheckOnClick = true;
            this.ppm_internal_a_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_a_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_a_H2O.ForeColor = System.Drawing.Color.DarkViolet;
            this.ppm_internal_a_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_a_H2O.Image")));
            this.ppm_internal_a_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_a_H2O.Name = "ppm_internal_a_H2O";
            this.ppm_internal_a_H2O.Size = new System.Drawing.Size(111, 22);
            this.ppm_internal_a_H2O.Text = "internal a-H2O";
            // 
            // ppm_internal_a_NH3
            // 
            this.ppm_internal_a_NH3.Checked = true;
            this.ppm_internal_a_NH3.CheckOnClick = true;
            this.ppm_internal_a_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_internal_a_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_internal_a_NH3.ForeColor = System.Drawing.Color.DarkViolet;
            this.ppm_internal_a_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_internal_a_NH3.Image")));
            this.ppm_internal_a_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_internal_a_NH3.Name = "ppm_internal_a_NH3";
            this.ppm_internal_a_NH3.Size = new System.Drawing.Size(111, 22);
            this.ppm_internal_a_NH3.Text = "internal a-NH3";
            // 
            // ppm_toolStrip3
            // 
            this.ppm_toolStrip3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppm_toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_w,
            this.ppm_w_H2O,
            this.ppm_w_B,
            this.ppm_x,
            this.ppm_x_H2O,
            this.ppm_x_NH3,
            this.ppm_y,
            this.ppm_y_H2O,
            this.ppm_y_NH3,
            this.ppm_z,
            this.ppm_z_H2O,
            this.ppm_z_NH3});
            this.ppm_toolStrip3.Location = new System.Drawing.Point(0, 401);
            this.ppm_toolStrip3.Name = "ppm_toolStrip3";
            this.ppm_toolStrip3.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.ppm_toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ppm_toolStrip3.Size = new System.Drawing.Size(579, 25);
            this.ppm_toolStrip3.TabIndex = 5;
            // 
            // ppm_w
            // 
            this.ppm_w.Checked = true;
            this.ppm_w.CheckOnClick = true;
            this.ppm_w.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_w.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_w.ForeColor = System.Drawing.Color.Lime;
            this.ppm_w.Image = ((System.Drawing.Image)(resources.GetObject("ppm_w.Image")));
            this.ppm_w.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_w.Name = "ppm_w";
            this.ppm_w.Size = new System.Drawing.Size(23, 22);
            this.ppm_w.Text = "w";
            // 
            // ppm_w_H2O
            // 
            this.ppm_w_H2O.Checked = true;
            this.ppm_w_H2O.CheckOnClick = true;
            this.ppm_w_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_w_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_w_H2O.ForeColor = System.Drawing.Color.Lime;
            this.ppm_w_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_w_H2O.Image")));
            this.ppm_w_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_w_H2O.Name = "ppm_w_H2O";
            this.ppm_w_H2O.Size = new System.Drawing.Size(57, 22);
            this.ppm_w_H2O.Text = "w-H2O";
            // 
            // ppm_w_B
            // 
            this.ppm_w_B.Checked = true;
            this.ppm_w_B.CheckOnClick = true;
            this.ppm_w_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_w_B.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_w_B.ForeColor = System.Drawing.Color.Lime;
            this.ppm_w_B.Image = ((System.Drawing.Image)(resources.GetObject("ppm_w_B.Image")));
            this.ppm_w_B.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_w_B.Name = "ppm_w_B";
            this.ppm_w_B.Size = new System.Drawing.Size(47, 22);
            this.ppm_w_B.Text = "w-B()";
            // 
            // ppm_x
            // 
            this.ppm_x.Checked = true;
            this.ppm_x.CheckOnClick = true;
            this.ppm_x.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_x.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_x.ForeColor = System.Drawing.Color.Lime;
            this.ppm_x.Image = ((System.Drawing.Image)(resources.GetObject("ppm_x.Image")));
            this.ppm_x.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_x.Name = "ppm_x";
            this.ppm_x.Size = new System.Drawing.Size(23, 22);
            this.ppm_x.Text = "x";
            // 
            // ppm_x_H2O
            // 
            this.ppm_x_H2O.Checked = true;
            this.ppm_x_H2O.CheckOnClick = true;
            this.ppm_x_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_x_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_x_H2O.ForeColor = System.Drawing.Color.Lime;
            this.ppm_x_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_x_H2O.Image")));
            this.ppm_x_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_x_H2O.Name = "ppm_x_H2O";
            this.ppm_x_H2O.Size = new System.Drawing.Size(54, 22);
            this.ppm_x_H2O.Text = "x-H2O";
            // 
            // ppm_x_NH3
            // 
            this.ppm_x_NH3.Checked = true;
            this.ppm_x_NH3.CheckOnClick = true;
            this.ppm_x_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_x_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_x_NH3.ForeColor = System.Drawing.Color.Lime;
            this.ppm_x_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_x_NH3.Image")));
            this.ppm_x_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_x_NH3.Name = "ppm_x_NH3";
            this.ppm_x_NH3.Size = new System.Drawing.Size(54, 22);
            this.ppm_x_NH3.Text = "x-NH3";
            // 
            // ppm_y
            // 
            this.ppm_y.Checked = true;
            this.ppm_y.CheckOnClick = true;
            this.ppm_y.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_y.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ppm_y.Image = ((System.Drawing.Image)(resources.GetObject("ppm_y.Image")));
            this.ppm_y.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_y.Name = "ppm_y";
            this.ppm_y.Size = new System.Drawing.Size(23, 22);
            this.ppm_y.Text = "y";
            // 
            // ppm_y_H2O
            // 
            this.ppm_y_H2O.Checked = true;
            this.ppm_y_H2O.CheckOnClick = true;
            this.ppm_y_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_y_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_y_H2O.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ppm_y_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_y_H2O.Image")));
            this.ppm_y_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_y_H2O.Name = "ppm_y_H2O";
            this.ppm_y_H2O.Size = new System.Drawing.Size(55, 22);
            this.ppm_y_H2O.Text = "y-H2O";
            // 
            // ppm_y_NH3
            // 
            this.ppm_y_NH3.Checked = true;
            this.ppm_y_NH3.CheckOnClick = true;
            this.ppm_y_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_y_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_y_NH3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ppm_y_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_y_NH3.Image")));
            this.ppm_y_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_y_NH3.Name = "ppm_y_NH3";
            this.ppm_y_NH3.Size = new System.Drawing.Size(55, 22);
            this.ppm_y_NH3.Text = "y-NH3";
            // 
            // ppm_z
            // 
            this.ppm_z.Checked = true;
            this.ppm_z.CheckOnClick = true;
            this.ppm_z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_z.ForeColor = System.Drawing.Color.Tomato;
            this.ppm_z.Image = ((System.Drawing.Image)(resources.GetObject("ppm_z.Image")));
            this.ppm_z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_z.Name = "ppm_z";
            this.ppm_z.Size = new System.Drawing.Size(23, 22);
            this.ppm_z.Text = "z";
            // 
            // ppm_z_H2O
            // 
            this.ppm_z_H2O.Checked = true;
            this.ppm_z_H2O.CheckOnClick = true;
            this.ppm_z_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_z_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_z_H2O.ForeColor = System.Drawing.Color.Tomato;
            this.ppm_z_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_z_H2O.Image")));
            this.ppm_z_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_z_H2O.Name = "ppm_z_H2O";
            this.ppm_z_H2O.Size = new System.Drawing.Size(54, 22);
            this.ppm_z_H2O.Text = "z-H2O";
            // 
            // ppm_z_NH3
            // 
            this.ppm_z_NH3.Checked = true;
            this.ppm_z_NH3.CheckOnClick = true;
            this.ppm_z_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_z_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_z_NH3.ForeColor = System.Drawing.Color.Tomato;
            this.ppm_z_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_z_NH3.Image")));
            this.ppm_z_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_z_NH3.Name = "ppm_z_NH3";
            this.ppm_z_NH3.Size = new System.Drawing.Size(54, 22);
            this.ppm_z_NH3.Text = "z-NH3";
            // 
            // ppm_toolStrip2
            // 
            this.ppm_toolStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppm_toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppm_a,
            this.ppm_a_H2O,
            this.ppm_a_NH3,
            this.ppm_b,
            this.ppm_b_H2O,
            this.ppm_b_NH3,
            this.ppm_c,
            this.ppm_c_H2O,
            this.ppm_c_NH3,
            this.ppm_d,
            this.ppm_d_H2O,
            this.ppm_d_B});
            this.ppm_toolStrip2.Location = new System.Drawing.Point(0, 376);
            this.ppm_toolStrip2.Name = "ppm_toolStrip2";
            this.ppm_toolStrip2.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.ppm_toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ppm_toolStrip2.Size = new System.Drawing.Size(579, 25);
            this.ppm_toolStrip2.TabIndex = 4;
            // 
            // ppm_a
            // 
            this.ppm_a.Checked = true;
            this.ppm_a.CheckOnClick = true;
            this.ppm_a.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_a.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_a.ForeColor = System.Drawing.Color.Green;
            this.ppm_a.Image = ((System.Drawing.Image)(resources.GetObject("ppm_a.Image")));
            this.ppm_a.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_a.Name = "ppm_a";
            this.ppm_a.Size = new System.Drawing.Size(23, 22);
            this.ppm_a.Text = "a";
            // 
            // ppm_a_H2O
            // 
            this.ppm_a_H2O.Checked = true;
            this.ppm_a_H2O.CheckOnClick = true;
            this.ppm_a_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_a_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_a_H2O.ForeColor = System.Drawing.Color.Green;
            this.ppm_a_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_a_H2O.Image")));
            this.ppm_a_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_a_H2O.Name = "ppm_a_H2O";
            this.ppm_a_H2O.Size = new System.Drawing.Size(56, 22);
            this.ppm_a_H2O.Text = "a-H2O";
            // 
            // ppm_a_NH3
            // 
            this.ppm_a_NH3.Checked = true;
            this.ppm_a_NH3.CheckOnClick = true;
            this.ppm_a_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_a_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_a_NH3.ForeColor = System.Drawing.Color.Green;
            this.ppm_a_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_a_NH3.Image")));
            this.ppm_a_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_a_NH3.Name = "ppm_a_NH3";
            this.ppm_a_NH3.Size = new System.Drawing.Size(56, 22);
            this.ppm_a_NH3.Text = "a-NH3";
            // 
            // ppm_b
            // 
            this.ppm_b.Checked = true;
            this.ppm_b.CheckOnClick = true;
            this.ppm_b.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_b.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_b.ForeColor = System.Drawing.Color.Blue;
            this.ppm_b.Image = ((System.Drawing.Image)(resources.GetObject("ppm_b.Image")));
            this.ppm_b.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_b.Name = "ppm_b";
            this.ppm_b.Size = new System.Drawing.Size(23, 22);
            this.ppm_b.Text = "b";
            // 
            // ppm_b_H2O
            // 
            this.ppm_b_H2O.Checked = true;
            this.ppm_b_H2O.CheckOnClick = true;
            this.ppm_b_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_b_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_b_H2O.ForeColor = System.Drawing.Color.Blue;
            this.ppm_b_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_b_H2O.Image")));
            this.ppm_b_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_b_H2O.Name = "ppm_b_H2O";
            this.ppm_b_H2O.Size = new System.Drawing.Size(56, 22);
            this.ppm_b_H2O.Text = "b-H2O";
            // 
            // ppm_b_NH3
            // 
            this.ppm_b_NH3.Checked = true;
            this.ppm_b_NH3.CheckOnClick = true;
            this.ppm_b_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_b_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_b_NH3.ForeColor = System.Drawing.Color.Blue;
            this.ppm_b_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_b_NH3.Image")));
            this.ppm_b_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_b_NH3.Name = "ppm_b_NH3";
            this.ppm_b_NH3.Size = new System.Drawing.Size(56, 22);
            this.ppm_b_NH3.Text = "b-NH3";
            // 
            // ppm_c
            // 
            this.ppm_c.Checked = true;
            this.ppm_c.CheckOnClick = true;
            this.ppm_c.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_c.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_c.ForeColor = System.Drawing.Color.Firebrick;
            this.ppm_c.Image = ((System.Drawing.Image)(resources.GetObject("ppm_c.Image")));
            this.ppm_c.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_c.Name = "ppm_c";
            this.ppm_c.Size = new System.Drawing.Size(23, 22);
            this.ppm_c.Text = "c";
            // 
            // ppm_c_H2O
            // 
            this.ppm_c_H2O.Checked = true;
            this.ppm_c_H2O.CheckOnClick = true;
            this.ppm_c_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_c_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_c_H2O.ForeColor = System.Drawing.Color.Firebrick;
            this.ppm_c_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_c_H2O.Image")));
            this.ppm_c_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_c_H2O.Name = "ppm_c_H2O";
            this.ppm_c_H2O.Size = new System.Drawing.Size(55, 22);
            this.ppm_c_H2O.Text = "c-H2O";
            // 
            // ppm_c_NH3
            // 
            this.ppm_c_NH3.Checked = true;
            this.ppm_c_NH3.CheckOnClick = true;
            this.ppm_c_NH3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_c_NH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_c_NH3.ForeColor = System.Drawing.Color.Firebrick;
            this.ppm_c_NH3.Image = ((System.Drawing.Image)(resources.GetObject("ppm_c_NH3.Image")));
            this.ppm_c_NH3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_c_NH3.Name = "ppm_c_NH3";
            this.ppm_c_NH3.Size = new System.Drawing.Size(55, 22);
            this.ppm_c_NH3.Text = "c-NH3";
            // 
            // ppm_d
            // 
            this.ppm_d.Checked = true;
            this.ppm_d.CheckOnClick = true;
            this.ppm_d.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_d.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_d.ForeColor = System.Drawing.Color.DeepPink;
            this.ppm_d.Image = ((System.Drawing.Image)(resources.GetObject("ppm_d.Image")));
            this.ppm_d.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_d.Name = "ppm_d";
            this.ppm_d.Size = new System.Drawing.Size(23, 22);
            this.ppm_d.Text = "d";
            // 
            // ppm_d_H2O
            // 
            this.ppm_d_H2O.Checked = true;
            this.ppm_d_H2O.CheckOnClick = true;
            this.ppm_d_H2O.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_d_H2O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_d_H2O.ForeColor = System.Drawing.Color.DeepPink;
            this.ppm_d_H2O.Image = ((System.Drawing.Image)(resources.GetObject("ppm_d_H2O.Image")));
            this.ppm_d_H2O.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_d_H2O.Name = "ppm_d_H2O";
            this.ppm_d_H2O.Size = new System.Drawing.Size(56, 22);
            this.ppm_d_H2O.Text = "d-H2O";
            // 
            // ppm_d_B
            // 
            this.ppm_d_B.Checked = true;
            this.ppm_d_B.CheckOnClick = true;
            this.ppm_d_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ppm_d_B.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ppm_d_B.ForeColor = System.Drawing.Color.DeepPink;
            this.ppm_d_B.Image = ((System.Drawing.Image)(resources.GetObject("ppm_d_B.Image")));
            this.ppm_d_B.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_d_B.Name = "ppm_d_B";
            this.ppm_d_B.Size = new System.Drawing.Size(46, 22);
            this.ppm_d_B.Text = "d-B()";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ppm_panel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(537, 351);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.ppm_toolStrip);
            this.toolStripContainer1.Size = new System.Drawing.Size(579, 376);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
            // 
            // ppm_panel
            // 
            this.ppm_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppm_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppm_panel.Location = new System.Drawing.Point(0, 0);
            this.ppm_panel.Name = "ppm_panel";
            this.ppm_panel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.ppm_panel.Size = new System.Drawing.Size(537, 351);
            this.ppm_panel.TabIndex = 3;
            // 
            // ppm_toolStrip
            // 
            this.ppm_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ppm_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ppm_toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ppm_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ppmSave_Btn,
            this.ppmCopy_Btn,
            this.ppm_legend_Btn,
            this.ppm_extract_btn});
            this.ppm_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ppm_toolStrip.Location = new System.Drawing.Point(0, 8);
            this.ppm_toolStrip.Name = "ppm_toolStrip";
            this.ppm_toolStrip.Size = new System.Drawing.Size(32, 102);
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
            // ppm_legend_Btn
            // 
            this.ppm_legend_Btn.CheckOnClick = true;
            this.ppm_legend_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ppm_legend_Btn.Image = ((System.Drawing.Image)(resources.GetObject("ppm_legend_Btn.Image")));
            this.ppm_legend_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_legend_Btn.Name = "ppm_legend_Btn";
            this.ppm_legend_Btn.Size = new System.Drawing.Size(30, 22);
            this.ppm_legend_Btn.CheckedChanged += new System.EventHandler(this.ppm_legend_Btn_CheckedChanged);
            // 
            // ppm_extract_btn
            // 
            this.ppm_extract_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ppm_extract_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractPlotToolStripMenuItem9,
            this.settingsToolStripMenuItem});
            this.ppm_extract_btn.Image = ((System.Drawing.Image)(resources.GetObject("ppm_extract_btn.Image")));
            this.ppm_extract_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ppm_extract_btn.Name = "ppm_extract_btn";
            this.ppm_extract_btn.Size = new System.Drawing.Size(30, 22);
            // 
            // extractPlotToolStripMenuItem9
            // 
            this.extractPlotToolStripMenuItem9.Name = "extractPlotToolStripMenuItem9";
            this.extractPlotToolStripMenuItem9.Size = new System.Drawing.Size(133, 22);
            this.extractPlotToolStripMenuItem9.Text = "Extract plot";
            this.extractPlotToolStripMenuItem9.Click += new System.EventHandler(this.extractPlotToolStripMenuItem9_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.settingsToolStripMenuItem.Text = "Properties";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            this.draw_sequence_panelCopy2.Controls.Add(this.seq_LblCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.highlight_ibt_ckBxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.seq_extensionBoxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.los_chkBoxCopy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.delele_sequencePnl2);
            this.draw_sequence_panelCopy2.Controls.Add(this.rdBtn50Copy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.rdBtn25Copy2);
            this.draw_sequence_panelCopy2.Controls.Add(this.sequence_toolStripCopy2);
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
            // highlight_ibt_ckBxCopy2
            // 
            this.highlight_ibt_ckBxCopy2.AutoSize = true;
            this.highlight_ibt_ckBxCopy2.Location = new System.Drawing.Point(7, 235);
            this.highlight_ibt_ckBxCopy2.Name = "highlight_ibt_ckBxCopy2";
            this.highlight_ibt_ckBxCopy2.Size = new System.Drawing.Size(50, 17);
            this.highlight_ibt_ckBxCopy2.TabIndex = 20;
            this.highlight_ibt_ckBxCopy2.Text = "Color";
            this.highlight_ibt_ckBxCopy2.UseVisualStyleBackColor = true;
            this.highlight_ibt_ckBxCopy2.CheckedChanged += new System.EventHandler(this.highlight_ibt_ckBxCopy2_CheckedChanged);
            // 
            // seq_extensionBoxCopy2
            // 
            this.seq_extensionBoxCopy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seq_extensionBoxCopy2.Enabled = false;
            this.seq_extensionBoxCopy2.FormattingEnabled = true;
            this.seq_extensionBoxCopy2.Location = new System.Drawing.Point(7, 199);
            this.seq_extensionBoxCopy2.Name = "seq_extensionBoxCopy2";
            this.seq_extensionBoxCopy2.Size = new System.Drawing.Size(87, 21);
            this.seq_extensionBoxCopy2.TabIndex = 19;
            this.seq_extensionBoxCopy2.SelectionChangeCommitted += new System.EventHandler(this.seq_extensionBoxCopy2_SelectionChangeCommitted);
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
            this.rdBtn50Copy2.Location = new System.Drawing.Point(7, 299);
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
            this.rdBtn25Copy2.Location = new System.Drawing.Point(7, 277);
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
            this.intA_chBxCopy2.CheckedChanged += new System.EventHandler(this.intA_chBxCopy2_CheckedChanged);
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
            this.sequence_PnlCopy2.Controls.Add(this.color_range_panelCopy2);
            this.sequence_PnlCopy2.Controls.Add(this.color_range_picBoxCopy2);
            this.sequence_PnlCopy2.Controls.Add(this.seq_lbl_panelCopy2);
            this.sequence_PnlCopy2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_PnlCopy2.Location = new System.Drawing.Point(103, 27);
            this.sequence_PnlCopy2.Name = "sequence_PnlCopy2";
            this.sequence_PnlCopy2.Size = new System.Drawing.Size(614, 455);
            this.sequence_PnlCopy2.TabIndex = 7;
            this.sequence_PnlCopy2.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_PnlCopy2_Paint);
            this.sequence_PnlCopy2.Resize += new System.EventHandler(this.sequence_PnlCopy2_Resize);
            // 
            // color_range_panelCopy2
            // 
            this.color_range_panelCopy2.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_panelCopy2.Location = new System.Drawing.Point(522, 0);
            this.color_range_panelCopy2.Name = "color_range_panelCopy2";
            this.color_range_panelCopy2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_panelCopy2.Size = new System.Drawing.Size(21, 455);
            this.color_range_panelCopy2.TabIndex = 22;
            this.color_range_panelCopy2.Visible = false;
            this.color_range_panelCopy2.Paint += new System.Windows.Forms.PaintEventHandler(this.color_range_panelCopy2_Paint);
            // 
            // color_range_picBoxCopy2
            // 
            this.color_range_picBoxCopy2.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_picBoxCopy2.Image = ((System.Drawing.Image)(resources.GetObject("color_range_picBoxCopy2.Image")));
            this.color_range_picBoxCopy2.Location = new System.Drawing.Point(543, 0);
            this.color_range_picBoxCopy2.Name = "color_range_picBoxCopy2";
            this.color_range_picBoxCopy2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_picBoxCopy2.Size = new System.Drawing.Size(21, 455);
            this.color_range_picBoxCopy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_range_picBoxCopy2.TabIndex = 21;
            this.color_range_picBoxCopy2.TabStop = false;
            this.color_range_picBoxCopy2.Visible = false;
            // 
            // seq_lbl_panelCopy2
            // 
            this.seq_lbl_panelCopy2.Dock = System.Windows.Forms.DockStyle.Right;
            this.seq_lbl_panelCopy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_lbl_panelCopy2.Location = new System.Drawing.Point(564, 0);
            this.seq_lbl_panelCopy2.Name = "seq_lbl_panelCopy2";
            this.seq_lbl_panelCopy2.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.seq_lbl_panelCopy2.Size = new System.Drawing.Size(50, 455);
            this.seq_lbl_panelCopy2.TabIndex = 23;
            this.seq_lbl_panelCopy2.Visible = false;
            this.seq_lbl_panelCopy2.Paint += new System.Windows.Forms.PaintEventHandler(this.seq_lbl_panelCopy2_Paint);
            // 
            // draw_BtnCopy2
            // 
            this.draw_BtnCopy2.BackColor = System.Drawing.Color.Teal;
            this.draw_BtnCopy2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_BtnCopy2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_BtnCopy2.Location = new System.Drawing.Point(7, 163);
            this.draw_BtnCopy2.Name = "draw_BtnCopy2";
            this.draw_BtnCopy2.Size = new System.Drawing.Size(87, 21);
            this.draw_BtnCopy2.TabIndex = 6;
            this.draw_BtnCopy2.Text = "Draw";
            this.draw_BtnCopy2.UseVisualStyleBackColor = false;
            this.draw_BtnCopy2.Click += new System.EventHandler(this.draw_BtnCopy2_Click);
            // 
            // draw_sequence_panelCopy1
            // 
            this.draw_sequence_panelCopy1.AutoScroll = true;
            this.draw_sequence_panelCopy1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_sequence_panelCopy1.Controls.Add(this.seq_LblCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.highlight_ibt_ckBxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.seq_extensionBoxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.los_chkBoxCopy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.delele_sequencePnl1);
            this.draw_sequence_panelCopy1.Controls.Add(this.rdBtn50Copy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.rdBtn25Copy1);
            this.draw_sequence_panelCopy1.Controls.Add(this.sequence_toolStripCopy1);
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
            // highlight_ibt_ckBxCopy1
            // 
            this.highlight_ibt_ckBxCopy1.AutoSize = true;
            this.highlight_ibt_ckBxCopy1.Location = new System.Drawing.Point(5, 235);
            this.highlight_ibt_ckBxCopy1.Name = "highlight_ibt_ckBxCopy1";
            this.highlight_ibt_ckBxCopy1.Size = new System.Drawing.Size(50, 17);
            this.highlight_ibt_ckBxCopy1.TabIndex = 19;
            this.highlight_ibt_ckBxCopy1.Text = "Color";
            this.highlight_ibt_ckBxCopy1.UseVisualStyleBackColor = true;
            this.highlight_ibt_ckBxCopy1.CheckedChanged += new System.EventHandler(this.highlight_ibt_ckBxCopy1_CheckedChanged);
            // 
            // seq_extensionBoxCopy1
            // 
            this.seq_extensionBoxCopy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seq_extensionBoxCopy1.Enabled = false;
            this.seq_extensionBoxCopy1.FormattingEnabled = true;
            this.seq_extensionBoxCopy1.Location = new System.Drawing.Point(5, 199);
            this.seq_extensionBoxCopy1.Name = "seq_extensionBoxCopy1";
            this.seq_extensionBoxCopy1.Size = new System.Drawing.Size(87, 21);
            this.seq_extensionBoxCopy1.TabIndex = 18;
            this.seq_extensionBoxCopy1.SelectionChangeCommitted += new System.EventHandler(this.seq_extensionBoxCopy1_SelectionChangeCommitted);
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
            this.rdBtn50Copy1.Location = new System.Drawing.Point(5, 299);
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
            this.rdBtn25Copy1.Location = new System.Drawing.Point(5, 274);
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
            this.intA_chBxCopy1.CheckedChanged += new System.EventHandler(this.intA_chBxCopy1_CheckedChanged);
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
            this.sequence_PnlCopy1.Controls.Add(this.color_range_panelCopy1);
            this.sequence_PnlCopy1.Controls.Add(this.color_range_picBoxCopy1);
            this.sequence_PnlCopy1.Controls.Add(this.seq_lbl_panelCopy1);
            this.sequence_PnlCopy1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_PnlCopy1.Location = new System.Drawing.Point(103, 27);
            this.sequence_PnlCopy1.Name = "sequence_PnlCopy1";
            this.sequence_PnlCopy1.Size = new System.Drawing.Size(614, 455);
            this.sequence_PnlCopy1.TabIndex = 7;
            this.sequence_PnlCopy1.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_PnlCopy1_Paint);
            this.sequence_PnlCopy1.Resize += new System.EventHandler(this.sequence_PnlCopy1_Resize);
            // 
            // color_range_panelCopy1
            // 
            this.color_range_panelCopy1.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_panelCopy1.Location = new System.Drawing.Point(522, 0);
            this.color_range_panelCopy1.Name = "color_range_panelCopy1";
            this.color_range_panelCopy1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_panelCopy1.Size = new System.Drawing.Size(21, 455);
            this.color_range_panelCopy1.TabIndex = 21;
            this.color_range_panelCopy1.Visible = false;
            this.color_range_panelCopy1.Paint += new System.Windows.Forms.PaintEventHandler(this.color_range_panelCopy1_Paint);
            // 
            // color_range_picBoxCopy1
            // 
            this.color_range_picBoxCopy1.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_picBoxCopy1.Image = ((System.Drawing.Image)(resources.GetObject("color_range_picBoxCopy1.Image")));
            this.color_range_picBoxCopy1.Location = new System.Drawing.Point(543, 0);
            this.color_range_picBoxCopy1.Name = "color_range_picBoxCopy1";
            this.color_range_picBoxCopy1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_picBoxCopy1.Size = new System.Drawing.Size(21, 455);
            this.color_range_picBoxCopy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_range_picBoxCopy1.TabIndex = 20;
            this.color_range_picBoxCopy1.TabStop = false;
            this.color_range_picBoxCopy1.Visible = false;
            // 
            // seq_lbl_panelCopy1
            // 
            this.seq_lbl_panelCopy1.Dock = System.Windows.Forms.DockStyle.Right;
            this.seq_lbl_panelCopy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_lbl_panelCopy1.Location = new System.Drawing.Point(564, 0);
            this.seq_lbl_panelCopy1.Name = "seq_lbl_panelCopy1";
            this.seq_lbl_panelCopy1.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.seq_lbl_panelCopy1.Size = new System.Drawing.Size(50, 455);
            this.seq_lbl_panelCopy1.TabIndex = 22;
            this.seq_lbl_panelCopy1.Visible = false;
            this.seq_lbl_panelCopy1.Paint += new System.Windows.Forms.PaintEventHandler(this.seq_lbl_panelCopy1_Paint);
            // 
            // draw_BtnCopy1
            // 
            this.draw_BtnCopy1.BackColor = System.Drawing.Color.Teal;
            this.draw_BtnCopy1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_BtnCopy1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_BtnCopy1.Location = new System.Drawing.Point(5, 163);
            this.draw_BtnCopy1.Name = "draw_BtnCopy1";
            this.draw_BtnCopy1.Size = new System.Drawing.Size(87, 21);
            this.draw_BtnCopy1.TabIndex = 6;
            this.draw_BtnCopy1.Text = "Draw";
            this.draw_BtnCopy1.UseVisualStyleBackColor = false;
            this.draw_BtnCopy1.Click += new System.EventHandler(this.draw_BtnCopy1_Click);
            // 
            // draw_sequence_panel
            // 
            this.draw_sequence_panel.AutoScroll = true;
            this.draw_sequence_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_sequence_panel.Controls.Add(this.seq_Lbl);
            this.draw_sequence_panel.Controls.Add(this.highlight_ibt_ckBx);
            this.draw_sequence_panel.Controls.Add(this.seq_extensionBox);
            this.draw_sequence_panel.Controls.Add(this.los_chkBox);
            this.draw_sequence_panel.Controls.Add(this.add_sequencePanel1);
            this.draw_sequence_panel.Controls.Add(this.rdBtn50);
            this.draw_sequence_panel.Controls.Add(this.rdBtn25);
            this.draw_sequence_panel.Controls.Add(this.sequence_toolStrip);
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
            // highlight_ibt_ckBx
            // 
            this.highlight_ibt_ckBx.AutoSize = true;
            this.highlight_ibt_ckBx.Location = new System.Drawing.Point(7, 227);
            this.highlight_ibt_ckBx.Name = "highlight_ibt_ckBx";
            this.highlight_ibt_ckBx.Size = new System.Drawing.Size(50, 17);
            this.highlight_ibt_ckBx.TabIndex = 16;
            this.highlight_ibt_ckBx.Text = "Color";
            this.highlight_ibt_ckBx.UseVisualStyleBackColor = true;
            this.highlight_ibt_ckBx.CheckedChanged += new System.EventHandler(this.highlight_ibt_ckBx_CheckedChanged);
            // 
            // seq_extensionBox
            // 
            this.seq_extensionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seq_extensionBox.Enabled = false;
            this.seq_extensionBox.FormattingEnabled = true;
            this.seq_extensionBox.Location = new System.Drawing.Point(4, 193);
            this.seq_extensionBox.Name = "seq_extensionBox";
            this.seq_extensionBox.Size = new System.Drawing.Size(87, 21);
            this.seq_extensionBox.TabIndex = 15;
            this.seq_extensionBox.SelectionChangeCommitted += new System.EventHandler(this.seq_extensionBox_SelectionChangeCommitted);
            // 
            // los_chkBox
            // 
            this.los_chkBox.AutoSize = true;
            this.los_chkBox.Location = new System.Drawing.Point(10, 143);
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
            this.add_sequencePanel1.Location = new System.Drawing.Point(7, 317);
            this.add_sequencePanel1.Name = "add_sequencePanel1";
            this.add_sequencePanel1.Size = new System.Drawing.Size(29, 28);
            this.add_sequencePanel1.TabIndex = 11;
            this.add_sequencePanel1.UseVisualStyleBackColor = true;
            this.add_sequencePanel1.Click += new System.EventHandler(this.add_sequencePanel1_Click);
            // 
            // rdBtn50
            // 
            this.rdBtn50.AutoSize = true;
            this.rdBtn50.Location = new System.Drawing.Point(7, 287);
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
            this.rdBtn25.Location = new System.Drawing.Point(7, 266);
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
            this.seq_coverageBtn,
            this.highlightProp_Btn});
            this.sequence_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sequence_toolStrip.Location = new System.Drawing.Point(728, 27);
            this.sequence_toolStrip.Name = "sequence_toolStrip";
            this.sequence_toolStrip.Size = new System.Drawing.Size(24, 102);
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
            this.seq_coverageBtn.ToolTipText = "Sequence coverage statistics";
            this.seq_coverageBtn.Click += new System.EventHandler(this.seq_coverageBtn_Click);
            // 
            // highlightProp_Btn
            // 
            this.highlightProp_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.highlightProp_Btn.Image = ((System.Drawing.Image)(resources.GetObject("highlightProp_Btn.Image")));
            this.highlightProp_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.highlightProp_Btn.Name = "highlightProp_Btn";
            this.highlightProp_Btn.Size = new System.Drawing.Size(22, 22);
            this.highlightProp_Btn.Text = "Highlight properties";
            this.highlightProp_Btn.Click += new System.EventHandler(this.highlightProp_Btn_Click);
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
            this.intA_chBx.CheckedChanged += new System.EventHandler(this.intA_chBx_CheckedChanged);
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
            this.sequence_Pnl.Controls.Add(this.color_range_panel);
            this.sequence_Pnl.Controls.Add(this.color_range_picBox);
            this.sequence_Pnl.Controls.Add(this.seq_lbl_panel);
            this.sequence_Pnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequence_Pnl.Location = new System.Drawing.Point(103, 27);
            this.sequence_Pnl.Name = "sequence_Pnl";
            this.sequence_Pnl.Size = new System.Drawing.Size(614, 444);
            this.sequence_Pnl.TabIndex = 7;
            this.sequence_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.sequence_Pnl_Paint);
            this.sequence_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sequence_Pnl_MouseDown);
            this.sequence_Pnl.Resize += new System.EventHandler(this.sequence_Pnl_Resize);
            // 
            // color_range_panel
            // 
            this.color_range_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_panel.Location = new System.Drawing.Point(522, 0);
            this.color_range_panel.Name = "color_range_panel";
            this.color_range_panel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_panel.Size = new System.Drawing.Size(21, 444);
            this.color_range_panel.TabIndex = 17;
            this.color_range_panel.Visible = false;
            this.color_range_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.color_range_panel_Paint);
            // 
            // color_range_picBox
            // 
            this.color_range_picBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_range_picBox.Image = ((System.Drawing.Image)(resources.GetObject("color_range_picBox.Image")));
            this.color_range_picBox.Location = new System.Drawing.Point(543, 0);
            this.color_range_picBox.Name = "color_range_picBox";
            this.color_range_picBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.color_range_picBox.Size = new System.Drawing.Size(21, 444);
            this.color_range_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_range_picBox.TabIndex = 0;
            this.color_range_picBox.TabStop = false;
            this.color_range_picBox.Visible = false;
            // 
            // seq_lbl_panel
            // 
            this.seq_lbl_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.seq_lbl_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_lbl_panel.Location = new System.Drawing.Point(564, 0);
            this.seq_lbl_panel.Name = "seq_lbl_panel";
            this.seq_lbl_panel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.seq_lbl_panel.Size = new System.Drawing.Size(50, 444);
            this.seq_lbl_panel.TabIndex = 18;
            this.seq_lbl_panel.Visible = false;
            this.seq_lbl_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.seq_lbl_panel_Paint);
            // 
            // draw_Btn
            // 
            this.draw_Btn.BackColor = System.Drawing.Color.Teal;
            this.draw_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.draw_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.draw_Btn.Location = new System.Drawing.Point(4, 163);
            this.draw_Btn.Name = "draw_Btn";
            this.draw_Btn.Size = new System.Drawing.Size(87, 21);
            this.draw_Btn.TabIndex = 6;
            this.draw_Btn.Text = "Draw";
            this.draw_Btn.UseVisualStyleBackColor = false;
            this.draw_Btn.Click += new System.EventHandler(this.draw_Btn_Click);
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
            this.plots_grpBox.Size = new System.Drawing.Size(743, 717);
            this.plots_grpBox.TabIndex = 2;
            // 
            // fit_grpBox
            // 
            this.fit_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fit_grpBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.fit_grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fit_grpBox.Location = new System.Drawing.Point(0, 27);
            this.fit_grpBox.Name = "fit_grpBox";
            this.fit_grpBox.Size = new System.Drawing.Size(743, 423);
            this.fit_grpBox.TabIndex = 4;
            this.fit_grpBox.TabStop = false;
            // 
            // toolStrip_plot
            // 
            this.toolStrip_plot.AutoSize = false;
            this.toolStrip_plot.BackColor = System.Drawing.Color.Lavender;
            this.toolStrip_plot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_plot.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_plot.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_plot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartFormatBtn,
            this.exportImage_Btn,
            this.autoscale_Btn,
            this.cursor_chkBx,
            this.copyImage_Btn,
            this.zoomIn_Y_Btn,
            this.zoomOut_Y_Btn,
            this.legend_chkBx,
            this.fragPlotLbl_chkBx,
            this.toolStripButton1,
            this.fragPlotLbl_chkBx2,
            this.toolStripButton2,
            this.toolStripButton3,
            this.disp_a,
            this.disp_b,
            this.disp_c,
            this.disp_d,
            this.disp_w,
            this.disp_x,
            this.disp_y,
            this.disp_z,
            this.disp_internal,
            this.project_options_toolStripButton});
            this.toolStrip_plot.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_plot.Name = "toolStrip_plot";
            this.toolStrip_plot.Size = new System.Drawing.Size(743, 27);
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
            // autoscale_Btn
            // 
            this.autoscale_Btn.Checked = true;
            this.autoscale_Btn.CheckOnClick = true;
            this.autoscale_Btn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoscale_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoscale_Btn.Image = ((System.Drawing.Image)(resources.GetObject("autoscale_Btn.Image")));
            this.autoscale_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoscale_Btn.Name = "autoscale_Btn";
            this.autoscale_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.autoscale_Btn.Size = new System.Drawing.Size(24, 24);
            this.autoscale_Btn.Text = "Autoscale";
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
            this.cursor_chkBx.CheckStateChanged += new System.EventHandler(this.cursor_chkBx_CheckStateChanged);
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
            // zoomIn_Y_Btn
            // 
            this.zoomIn_Y_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomIn_Y_Btn.Image = ((System.Drawing.Image)(resources.GetObject("zoomIn_Y_Btn.Image")));
            this.zoomIn_Y_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn_Y_Btn.Name = "zoomIn_Y_Btn";
            this.zoomIn_Y_Btn.Size = new System.Drawing.Size(24, 24);
            this.zoomIn_Y_Btn.ToolTipText = "Zoom In Y Axis";
            this.zoomIn_Y_Btn.Click += new System.EventHandler(this.zoomIn_Y_Btn_Click);
            // 
            // zoomOut_Y_Btn
            // 
            this.zoomOut_Y_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut_Y_Btn.Image = ((System.Drawing.Image)(resources.GetObject("zoomOut_Y_Btn.Image")));
            this.zoomOut_Y_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut_Y_Btn.Name = "zoomOut_Y_Btn";
            this.zoomOut_Y_Btn.Size = new System.Drawing.Size(24, 24);
            this.zoomOut_Y_Btn.ToolTipText = "Zoom Out Y Axis";
            this.zoomOut_Y_Btn.Click += new System.EventHandler(this.zoomOut_Y_Btn_Click);
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
            // fragPlotLbl_chkBx
            // 
            this.fragPlotLbl_chkBx.CheckOnClick = true;
            this.fragPlotLbl_chkBx.Image = ((System.Drawing.Image)(resources.GetObject("fragPlotLbl_chkBx.Image")));
            this.fragPlotLbl_chkBx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragPlotLbl_chkBx.Name = "fragPlotLbl_chkBx";
            this.fragPlotLbl_chkBx.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.fragPlotLbl_chkBx.Size = new System.Drawing.Size(73, 24);
            this.fragPlotLbl_chkBx.Text = "Primary";
            this.fragPlotLbl_chkBx.ToolTipText = "Show primary fragments label";
            this.fragPlotLbl_chkBx.CheckedChanged += new System.EventHandler(this.fragPlotLbl_chkBx_CheckedChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 27);
            // 
            // fragPlotLbl_chkBx2
            // 
            this.fragPlotLbl_chkBx2.CheckOnClick = true;
            this.fragPlotLbl_chkBx2.Image = ((System.Drawing.Image)(resources.GetObject("fragPlotLbl_chkBx2.Image")));
            this.fragPlotLbl_chkBx2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragPlotLbl_chkBx2.Name = "fragPlotLbl_chkBx2";
            this.fragPlotLbl_chkBx2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.fragPlotLbl_chkBx2.Size = new System.Drawing.Size(72, 24);
            this.fragPlotLbl_chkBx2.Text = "Internal";
            this.fragPlotLbl_chkBx2.ToolTipText = "Show internal fragments label";
            this.fragPlotLbl_chkBx2.CheckedChanged += new System.EventHandler(this.fragPlotLbl_chkBx2_CheckedChanged);
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
            this.toolStripButton3.Visible = false;
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
            // disp_d
            // 
            this.disp_d.Checked = true;
            this.disp_d.CheckOnClick = true;
            this.disp_d.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_d.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_d.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_d.ForeColor = System.Drawing.Color.DeepPink;
            this.disp_d.Image = ((System.Drawing.Image)(resources.GetObject("disp_d.Image")));
            this.disp_d.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_d.Name = "disp_d";
            this.disp_d.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_d.Size = new System.Drawing.Size(23, 24);
            this.disp_d.Text = "d";
            this.disp_d.ToolTipText = "Control whether this primary fragment will appear to plot";
            // 
            // disp_w
            // 
            this.disp_w.Checked = true;
            this.disp_w.CheckOnClick = true;
            this.disp_w.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disp_w.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disp_w.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.disp_w.ForeColor = System.Drawing.Color.LimeGreen;
            this.disp_w.Image = ((System.Drawing.Image)(resources.GetObject("disp_w.Image")));
            this.disp_w.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disp_w.Name = "disp_w";
            this.disp_w.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.disp_w.Size = new System.Drawing.Size(24, 24);
            this.disp_w.Text = "w";
            this.disp_w.ToolTipText = "Control whether this primary fragment will appear to plot";
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
            this.disp_internal.ToolTipText = "Control whether internal fragments will appear to plot";
            // 
            // project_options_toolStripButton
            // 
            this.project_options_toolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.project_options_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.project_options_toolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.chageStateToolStripMenuItem});
            this.project_options_toolStripButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.project_options_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("project_options_toolStripButton.Image")));
            this.project_options_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.project_options_toolStripButton.Name = "project_options_toolStripButton";
            this.project_options_toolStripButton.Size = new System.Drawing.Size(60, 24);
            this.project_options_toolStripButton.Text = "Project";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearAllToolStripMenuItem.Image")));
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // chageStateToolStripMenuItem
            // 
            this.chageStateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chageStateToolStripMenuItem.Image")));
            this.chageStateToolStripMenuItem.Name = "chageStateToolStripMenuItem";
            this.chageStateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.chageStateToolStripMenuItem.Text = "Chage State";
            this.chageStateToolStripMenuItem.Click += new System.EventHandler(this.chageStateToolStripMenuItem_Click);
            // 
            // res_grpBox
            // 
            this.res_grpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.res_grpBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.res_grpBox.Location = new System.Drawing.Point(0, 450);
            this.res_grpBox.Name = "res_grpBox";
            this.res_grpBox.Size = new System.Drawing.Size(743, 267);
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
            this.user_grpBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.user_grpBox.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_grpBox.Location = new System.Drawing.Point(749, 3);
            this.user_grpBox.Name = "user_grpBox";
            this.user_grpBox.Size = new System.Drawing.Size(610, 717);
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
            this.Fit_results_groupBox.Location = new System.Drawing.Point(3, 382);
            this.Fit_results_groupBox.Name = "Fit_results_groupBox";
            this.Fit_results_groupBox.Size = new System.Drawing.Size(219, 332);
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
            this.bigPanel.Size = new System.Drawing.Size(217, 286);
            this.bigPanel.TabIndex = 10000000;
            this.bigPanel.WrapContents = false;
            // 
            // toolStrip_fit_sort
            // 
            this.toolStrip_fit_sort.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_fit_sort.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fit_sort.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.toolStrip_fit_sort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check_bestBtn,
            this.uncheckFit_Btn,
            this.sortSettings_Btn,
            this.refresh_fitRes_Btn});
            this.toolStrip_fit_sort.Location = new System.Drawing.Point(3, 18);
            this.toolStrip_fit_sort.Name = "toolStrip_fit_sort";
            this.toolStrip_fit_sort.Size = new System.Drawing.Size(213, 25);
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
            this.splitContainer2.Controls.Add(this.panel2);
            this.splitContainer2.Controls.Add(this.panel1);
            this.splitContainer2.Controls.Add(this.factor_panel);
            this.splitContainer2.Controls.Add(this.fragStorage_Lbl);
            this.splitContainer2.Controls.Add(this.fragTypes_toolStrip);
            this.splitContainer2.Controls.Add(this.fragTypes_tree);
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer2.Location = new System.Drawing.Point(228, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(382, 717);
            this.splitContainer2.TabIndex = 10000018;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 340);
            this.panel2.TabIndex = 116;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.toolStrip_fragList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 106);
            this.panel1.TabIndex = 115;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.pictureBox1.Size = new System.Drawing.Size(382, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 120;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip_fragList
            // 
            this.toolStrip_fragList.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_fragList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_fragList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_fragList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_fragList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveListBtn11,
            this.loadListBtn11,
            this.clearListBtn11,
            this.toolStripButton10,
            this.checkall_Frag_Btn,
            this.uncheckall_Frag_Btn,
            this.toggle_toolStripButton,
            this.toolStripSeparator1,
            this.show_files_Btn,
            this.statistics_Btn,
            this.toolStripButton14,
            this.fragCalc_Btn2,
            this.refresh_frag_Btn2,
            this.frag_sort_Btn2});
            this.toolStrip_fragList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_fragList.Location = new System.Drawing.Point(0, 79);
            this.toolStrip_fragList.Name = "toolStrip_fragList";
            this.toolStrip_fragList.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip_fragList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip_fragList.Size = new System.Drawing.Size(382, 27);
            this.toolStrip_fragList.TabIndex = 119;
            // 
            // saveListBtn11
            // 
            this.saveListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("saveListBtn11.Image")));
            this.saveListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveListBtn11.Name = "saveListBtn11";
            this.saveListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.saveListBtn11.Size = new System.Drawing.Size(24, 24);
            this.saveListBtn11.Text = "Save checked fragments";
            this.saveListBtn11.Click += new System.EventHandler(this.saveListBtn11_Click);
            // 
            // loadListBtn11
            // 
            this.loadListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadListBtn11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFragmentsToolStripMenuItem,
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem});
            this.loadListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("loadListBtn11.Image")));
            this.loadListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadListBtn11.Name = "loadListBtn11";
            this.loadListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.loadListBtn11.Size = new System.Drawing.Size(33, 24);
            this.loadListBtn11.Text = "Load fragments from a \' .fit \' file";
            this.loadListBtn11.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.loadListBtn11.Click += new System.EventHandler(this.loadListBtn11_Click);
            // 
            // loadFragmentsToolStripMenuItem
            // 
            this.loadFragmentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadFragmentsToolStripMenuItem.Image")));
            this.loadFragmentsToolStripMenuItem.Name = "loadFragmentsToolStripMenuItem";
            this.loadFragmentsToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.loadFragmentsToolStripMenuItem.Text = "Load Frag.";
            this.loadFragmentsToolStripMenuItem.Click += new System.EventHandler(this.loadFragmentsToolStripMenuItem_Click);
            // 
            // loadFragmentsAndRecalculateResolutionToolStripMenuItem
            // 
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadFragmentsAndRecalculateResolutionToolStripMenuItem.Image")));
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem.Name = "loadFragmentsAndRecalculateResolutionToolStripMenuItem";
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem.Text = "Load Frag. and recalc. Res.";
            this.loadFragmentsAndRecalculateResolutionToolStripMenuItem.Click += new System.EventHandler(this.loadFragmentsAndRecalculateResolutionToolStripMenuItem_Click);
            // 
            // clearListBtn11
            // 
            this.clearListBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearListBtn11.Image = ((System.Drawing.Image)(resources.GetObject("clearListBtn11.Image")));
            this.clearListBtn11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearListBtn11.Name = "clearListBtn11";
            this.clearListBtn11.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.clearListBtn11.Size = new System.Drawing.Size(24, 24);
            this.clearListBtn11.Text = "Clear Fragment List , keep experimental data";
            this.clearListBtn11.Click += new System.EventHandler(this.clearListBtn11_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.AutoSize = false;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(4, 27);
            // 
            // checkall_Frag_Btn
            // 
            this.checkall_Frag_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkall_Frag_Btn.Image = ((System.Drawing.Image)(resources.GetObject("checkall_Frag_Btn.Image")));
            this.checkall_Frag_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkall_Frag_Btn.Name = "checkall_Frag_Btn";
            this.checkall_Frag_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.checkall_Frag_Btn.Size = new System.Drawing.Size(24, 24);
            this.checkall_Frag_Btn.Text = "Check all";
            this.checkall_Frag_Btn.Click += new System.EventHandler(this.checkall_Frag_Btn_Click);
            // 
            // uncheckall_Frag_Btn
            // 
            this.uncheckall_Frag_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheckall_Frag_Btn.Image = ((System.Drawing.Image)(resources.GetObject("uncheckall_Frag_Btn.Image")));
            this.uncheckall_Frag_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheckall_Frag_Btn.Name = "uncheckall_Frag_Btn";
            this.uncheckall_Frag_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.uncheckall_Frag_Btn.Size = new System.Drawing.Size(24, 24);
            this.uncheckall_Frag_Btn.Text = "Uncheck all";
            this.uncheckall_Frag_Btn.Click += new System.EventHandler(this.uncheckall_Frag_Btn_Click);
            // 
            // toggle_toolStripButton
            // 
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(4, 27);
            // 
            // show_files_Btn
            // 
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
            this.statistics_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statistics_Btn.Image = ((System.Drawing.Image)(resources.GetObject("statistics_Btn.Image")));
            this.statistics_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statistics_Btn.Name = "statistics_Btn";
            this.statistics_Btn.Size = new System.Drawing.Size(24, 24);
            this.statistics_Btn.Text = "Statistics";
            this.statistics_Btn.Click += new System.EventHandler(this.statistics_Btn_Click);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.AutoSize = false;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(4, 27);
            // 
            // fragCalc_Btn2
            // 
            this.fragCalc_Btn2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.fragCalc_Btn2.Image = ((System.Drawing.Image)(resources.GetObject("fragCalc_Btn2.Image")));
            this.fragCalc_Btn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fragCalc_Btn2.Name = "fragCalc_Btn2";
            this.fragCalc_Btn2.Size = new System.Drawing.Size(78, 24);
            this.fragCalc_Btn2.Text = "Frag.Calc";
            this.fragCalc_Btn2.Click += new System.EventHandler(this.fragCalc_Btn2_Click);
            // 
            // refresh_frag_Btn2
            // 
            this.refresh_frag_Btn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh_frag_Btn2.Image = ((System.Drawing.Image)(resources.GetObject("refresh_frag_Btn2.Image")));
            this.refresh_frag_Btn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh_frag_Btn2.Name = "refresh_frag_Btn2";
            this.refresh_frag_Btn2.Size = new System.Drawing.Size(24, 24);
            this.refresh_frag_Btn2.Click += new System.EventHandler(this.refresh_frag_Btn2_Click);
            // 
            // frag_sort_Btn2
            // 
            this.frag_sort_Btn2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.frag_sort_Btn2.Image = ((System.Drawing.Image)(resources.GetObject("frag_sort_Btn2.Image")));
            this.frag_sort_Btn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frag_sort_Btn2.Name = "frag_sort_Btn2";
            this.frag_sort_Btn2.Size = new System.Drawing.Size(57, 24);
            this.frag_sort_Btn2.Text = "Filter";
            this.frag_sort_Btn2.Click += new System.EventHandler(this.frag_sort_Btn2_Click);
            // 
            // factor_panel
            // 
            this.factor_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.factor_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.factor_panel.Location = new System.Drawing.Point(0, 446);
            this.factor_panel.Name = "factor_panel";
            this.factor_panel.Size = new System.Drawing.Size(382, 30);
            this.factor_panel.TabIndex = 114;
            // 
            // fragTypes_toolStrip
            // 
            this.fragTypes_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.fragTypes_toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fragTypes_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fragTypes_toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fragTypes_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_FragTypes_Btn,
            this.toggle_FragTypes_Btn});
            this.fragTypes_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.fragTypes_toolStrip.Location = new System.Drawing.Point(0, 466);
            this.fragTypes_toolStrip.Name = "fragTypes_toolStrip";
            this.fragTypes_toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.fragTypes_toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fragTypes_toolStrip.Size = new System.Drawing.Size(369, 27);
            this.fragTypes_toolStrip.TabIndex = 120;
            this.fragTypes_toolStrip.Visible = false;
            // 
            // save_FragTypes_Btn
            // 
            this.save_FragTypes_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_FragTypes_Btn.Image = ((System.Drawing.Image)(resources.GetObject("save_FragTypes_Btn.Image")));
            this.save_FragTypes_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_FragTypes_Btn.Name = "save_FragTypes_Btn";
            this.save_FragTypes_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.save_FragTypes_Btn.Size = new System.Drawing.Size(24, 24);
            this.save_FragTypes_Btn.Text = "Save checked fragments";
            this.save_FragTypes_Btn.Click += new System.EventHandler(this.save_FragTypes_Btn_Click);
            // 
            // toggle_FragTypes_Btn
            // 
            this.toggle_FragTypes_Btn.CheckOnClick = true;
            this.toggle_FragTypes_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggle_FragTypes_Btn.Image = ((System.Drawing.Image)(resources.GetObject("toggle_FragTypes_Btn.Image")));
            this.toggle_FragTypes_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggle_FragTypes_Btn.Name = "toggle_FragTypes_Btn";
            this.toggle_FragTypes_Btn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toggle_FragTypes_Btn.Size = new System.Drawing.Size(24, 24);
            this.toggle_FragTypes_Btn.Text = "Toggle All Outlining";
            this.toggle_FragTypes_Btn.CheckedChanged += new System.EventHandler(this.toggle_FragTypes_Btn_CheckedChanged);
            // 
            // fragTypes_tree
            // 
            this.fragTypes_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fragTypes_tree.CheckBoxes = true;
            this.fragTypes_tree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fragTypes_tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragTypes_tree.Location = new System.Drawing.Point(0, 493);
            this.fragTypes_tree.Name = "fragTypes_tree";
            this.fragTypes_tree.Size = new System.Drawing.Size(382, 224);
            this.fragTypes_tree.TabIndex = 112;
            this.fragTypes_tree.Visible = false;
            // 
            // theorData_grpBx
            // 
            this.theorData_grpBx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.theorData_grpBx.Controls.Add(this.ProfCalc_Btn);
            this.theorData_grpBx.Controls.Add(this.MSproduct_treeView);
            this.theorData_grpBx.Controls.Add(this.deleteMSProd_Btn);
            this.theorData_grpBx.Controls.Add(this.seqBtn);
            this.theorData_grpBx.Controls.Add(this.loadFF_Btn);
            this.theorData_grpBx.Controls.Add(this.loadMS_Btn);
            this.theorData_grpBx.Controls.Add(this.plotFragProf_chkBox);
            this.theorData_grpBx.Controls.Add(this.plotFragCent_chkBox);
            this.theorData_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theorData_grpBx.ForeColor = System.Drawing.Color.SteelBlue;
            this.theorData_grpBx.Location = new System.Drawing.Point(6, 115);
            this.theorData_grpBx.Name = "theorData_grpBx";
            this.theorData_grpBx.Size = new System.Drawing.Size(219, 167);
            this.theorData_grpBx.TabIndex = 2;
            this.theorData_grpBx.TabStop = false;
            this.theorData_grpBx.Text = "Theoretical Data";
            // 
            // ProfCalc_Btn
            // 
            this.ProfCalc_Btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProfCalc_Btn.BackColor = System.Drawing.Color.MidnightBlue;
            this.ProfCalc_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProfCalc_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfCalc_Btn.ForeColor = System.Drawing.Color.White;
            this.ProfCalc_Btn.Location = new System.Drawing.Point(0, 112);
            this.ProfCalc_Btn.Name = "ProfCalc_Btn";
            this.ProfCalc_Btn.Size = new System.Drawing.Size(219, 23);
            this.ProfCalc_Btn.TabIndex = 123;
            this.ProfCalc_Btn.Text = "Calculation Box";
            this.ProfCalc_Btn.UseVisualStyleBackColor = false;
            this.ProfCalc_Btn.Click += new System.EventHandler(this.ProfCalc_Btn_Click);
            // 
            // MSproduct_treeView
            // 
            this.MSproduct_treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MSproduct_treeView.ContextMenuStrip = this.contextMenuStrip_MSproduct;
            this.MSproduct_treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSproduct_treeView.Location = new System.Drawing.Point(0, 50);
            this.MSproduct_treeView.Name = "MSproduct_treeView";
            this.MSproduct_treeView.Size = new System.Drawing.Size(219, 56);
            this.MSproduct_treeView.TabIndex = 122;
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
            // plotFragProf_chkBox
            // 
            this.plotFragProf_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotFragProf_chkBox.AutoSize = true;
            this.plotFragProf_chkBox.Enabled = false;
            this.plotFragProf_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragProf_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragProf_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragProf_chkBox.Location = new System.Drawing.Point(3, 141);
            this.plotFragProf_chkBox.Name = "plotFragProf_chkBox";
            this.plotFragProf_chkBox.Size = new System.Drawing.Size(58, 17);
            this.plotFragProf_chkBox.TabIndex = 2;
            this.plotFragProf_chkBox.Text = "Profiles";
            this.plotFragProf_chkBox.UseVisualStyleBackColor = true;
            // 
            // plotFragCent_chkBox
            // 
            this.plotFragCent_chkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plotFragCent_chkBox.AutoSize = true;
            this.plotFragCent_chkBox.Enabled = false;
            this.plotFragCent_chkBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.plotFragCent_chkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plotFragCent_chkBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plotFragCent_chkBox.Location = new System.Drawing.Point(75, 141);
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
            this.expData_grpBx.Controls.Add(this.exp_Settings_toolStrip);
            this.expData_grpBx.Controls.Add(this.plotCentr_chkBox);
            this.expData_grpBx.Controls.Add(this.plotExp_chkBox);
            this.expData_grpBx.Controls.Add(this.loadExp_Btn);
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
            // exp_Settings_toolStrip
            // 
            this.exp_Settings_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.exp_Settings_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.exp_Settings_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsPeak_Btn});
            this.exp_Settings_toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.exp_Settings_toolStrip.Location = new System.Drawing.Point(144, 45);
            this.exp_Settings_toolStrip.Name = "exp_Settings_toolStrip";
            this.exp_Settings_toolStrip.Size = new System.Drawing.Size(72, 25);
            this.exp_Settings_toolStrip.TabIndex = 0;
            this.exp_Settings_toolStrip.Text = "toolStrip1";
            // 
            // settingsPeak_Btn
            // 
            this.settingsPeak_Btn.BackColor = System.Drawing.Color.Transparent;
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
            // fitOptions_grpBox
            // 
            this.fitOptions_grpBox.Controls.Add(this.fit_chkGrpsChkFragBtn);
            this.fitOptions_grpBox.Controls.Add(this.fit_chkGrpsBtn);
            this.fitOptions_grpBox.Controls.Add(this.fiToolStrip);
            this.fitOptions_grpBox.Controls.Add(this.fit_Btn);
            this.fitOptions_grpBox.Controls.Add(this.fit_sel_Btn);
            this.fitOptions_grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitOptions_grpBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.fitOptions_grpBox.Location = new System.Drawing.Point(6, 281);
            this.fitOptions_grpBox.Name = "fitOptions_grpBox";
            this.fitOptions_grpBox.Size = new System.Drawing.Size(219, 102);
            this.fitOptions_grpBox.TabIndex = 4;
            this.fitOptions_grpBox.TabStop = false;
            this.fitOptions_grpBox.Text = "Fitting";
            // 
            // fiToolStrip
            // 
            this.fiToolStrip.BackColor = System.Drawing.Color.Transparent;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFit);
            this.tabControl1.Controls.Add(this.tabDiagram);
            this.tabControl1.Controls.Add(this.tabPrimary);
            this.tabControl1.Controls.Add(this.tabInternal);
            this.tabControl1.Controls.Add(this.tab_losses);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1370, 749);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_losses
            // 
            this.tab_losses.Controls.Add(this.losses_splitContainer);
            this.tab_losses.Controls.Add(this.panel3);
            this.tab_losses.Location = new System.Drawing.Point(4, 22);
            this.tab_losses.Name = "tab_losses";
            this.tab_losses.Padding = new System.Windows.Forms.Padding(3);
            this.tab_losses.Size = new System.Drawing.Size(1362, 723);
            this.tab_losses.TabIndex = 5;
            this.tab_losses.Text = "Losses";
            this.tab_losses.UseVisualStyleBackColor = true;
            // 
            // losses_splitContainer
            // 
            this.losses_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_splitContainer.Location = new System.Drawing.Point(3, 37);
            this.losses_splitContainer.Name = "losses_splitContainer";
            // 
            // losses_splitContainer.Panel1
            // 
            this.losses_splitContainer.Panel1.AutoScroll = true;
            this.losses_splitContainer.Panel1.Controls.Add(this.losses_groupBox7);
            this.losses_splitContainer.Panel1.Controls.Add(this.losses_groupBox5);
            this.losses_splitContainer.Panel1.Controls.Add(this.losses_groupBox3);
            this.losses_splitContainer.Panel1.Controls.Add(this.losses_groupBox1);
            // 
            // losses_splitContainer.Panel2
            // 
            this.losses_splitContainer.Panel2.AutoScroll = true;
            this.losses_splitContainer.Panel2.Controls.Add(this.losses_groupBox8);
            this.losses_splitContainer.Panel2.Controls.Add(this.losses_groupBox6);
            this.losses_splitContainer.Panel2.Controls.Add(this.losses_groupBox4);
            this.losses_splitContainer.Panel2.Controls.Add(this.losses_groupBox2);
            this.losses_splitContainer.Size = new System.Drawing.Size(1356, 683);
            this.losses_splitContainer.SplitterDistance = 709;
            this.losses_splitContainer.TabIndex = 33;
            // 
            // losses_groupBox7
            // 
            this.losses_groupBox7.Controls.Add(this.losses_plot_panel7);
            this.losses_groupBox7.Controls.Add(this.checkboxes_panel7);
            this.losses_groupBox7.Controls.Add(this.losses_toolStrip7);
            this.losses_groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox7.Location = new System.Drawing.Point(0, 837);
            this.losses_groupBox7.Name = "losses_groupBox7";
            this.losses_groupBox7.Size = new System.Drawing.Size(692, 279);
            this.losses_groupBox7.TabIndex = 34;
            this.losses_groupBox7.TabStop = false;
            // 
            // losses_plot_panel7
            // 
            this.losses_plot_panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel7.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel7.Name = "losses_plot_panel7";
            this.losses_plot_panel7.Size = new System.Drawing.Size(569, 260);
            this.losses_plot_panel7.TabIndex = 21;
            this.losses_plot_panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel7_Paint);
            this.losses_plot_panel7.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel7
            // 
            this.checkboxes_panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel7.Location = new System.Drawing.Point(615, 16);
            this.checkboxes_panel7.Name = "checkboxes_panel7";
            this.checkboxes_panel7.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel7.TabIndex = 22;
            // 
            // losses_toolStrip7
            // 
            this.losses_toolStrip7.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip7.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn7,
            this.losses_copyBtn7,
            this.losses_DropBtn7,
            this.losses_X_Box7,
            this.losses_Y_Box7});
            this.losses_toolStrip7.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip7.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip7.Name = "losses_toolStrip7";
            this.losses_toolStrip7.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip7.TabIndex = 24;
            // 
            // losses_saveBtn7
            // 
            this.losses_saveBtn7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn7.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn7.Image")));
            this.losses_saveBtn7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn7.Name = "losses_saveBtn7";
            this.losses_saveBtn7.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn7.Text = "Save";
            this.losses_saveBtn7.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn7
            // 
            this.losses_copyBtn7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn7.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn7.Image")));
            this.losses_copyBtn7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn7.Name = "losses_copyBtn7";
            this.losses_copyBtn7.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn7.Text = "Copy";
            this.losses_copyBtn7.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn7
            // 
            this.losses_DropBtn7.AutoToolTip = false;
            this.losses_DropBtn7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn7,
            this.losses_extractBtn7});
            this.losses_DropBtn7.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn7.Image")));
            this.losses_DropBtn7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn7.Name = "losses_DropBtn7";
            this.losses_DropBtn7.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn7.Text = " ";
            // 
            // losses_styleBtn7
            // 
            this.losses_styleBtn7.Name = "losses_styleBtn7";
            this.losses_styleBtn7.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn7.Text = "Style";
            this.losses_styleBtn7.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn7
            // 
            this.losses_extractBtn7.Name = "losses_extractBtn7";
            this.losses_extractBtn7.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn7.Text = "Extract Plot";
            this.losses_extractBtn7.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box7
            // 
            this.losses_X_Box7.AutoSize = false;
            this.losses_X_Box7.Name = "losses_X_Box7";
            this.losses_X_Box7.ReadOnly = true;
            this.losses_X_Box7.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box7.ToolTipText = "Width";
            // 
            // losses_Y_Box7
            // 
            this.losses_Y_Box7.AutoSize = false;
            this.losses_Y_Box7.Name = "losses_Y_Box7";
            this.losses_Y_Box7.ReadOnly = true;
            this.losses_Y_Box7.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box7.ToolTipText = "Height";
            // 
            // losses_groupBox5
            // 
            this.losses_groupBox5.Controls.Add(this.losses_plot_panel5);
            this.losses_groupBox5.Controls.Add(this.checkboxes_panel5);
            this.losses_groupBox5.Controls.Add(this.losses_toolStrip5);
            this.losses_groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox5.Location = new System.Drawing.Point(0, 558);
            this.losses_groupBox5.Name = "losses_groupBox5";
            this.losses_groupBox5.Size = new System.Drawing.Size(692, 279);
            this.losses_groupBox5.TabIndex = 33;
            this.losses_groupBox5.TabStop = false;
            // 
            // losses_plot_panel5
            // 
            this.losses_plot_panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel5.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel5.Name = "losses_plot_panel5";
            this.losses_plot_panel5.Size = new System.Drawing.Size(569, 260);
            this.losses_plot_panel5.TabIndex = 21;
            this.losses_plot_panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel5_Paint);
            this.losses_plot_panel5.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel5
            // 
            this.checkboxes_panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel5.Location = new System.Drawing.Point(615, 16);
            this.checkboxes_panel5.Name = "checkboxes_panel5";
            this.checkboxes_panel5.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel5.TabIndex = 22;
            // 
            // losses_toolStrip5
            // 
            this.losses_toolStrip5.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip5.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn5,
            this.losses_copyBtn5,
            this.losses_DropBtn5,
            this.losses_X_Box5,
            this.losses_Y_Box5});
            this.losses_toolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip5.Name = "losses_toolStrip5";
            this.losses_toolStrip5.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip5.TabIndex = 24;
            // 
            // losses_saveBtn5
            // 
            this.losses_saveBtn5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn5.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn5.Image")));
            this.losses_saveBtn5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn5.Name = "losses_saveBtn5";
            this.losses_saveBtn5.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn5.Text = "Save";
            this.losses_saveBtn5.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn5
            // 
            this.losses_copyBtn5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn5.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn5.Image")));
            this.losses_copyBtn5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn5.Name = "losses_copyBtn5";
            this.losses_copyBtn5.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn5.Text = "Copy";
            this.losses_copyBtn5.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn5
            // 
            this.losses_DropBtn5.AutoToolTip = false;
            this.losses_DropBtn5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn5,
            this.losses_extractBtn5});
            this.losses_DropBtn5.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn5.Image")));
            this.losses_DropBtn5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn5.Name = "losses_DropBtn5";
            this.losses_DropBtn5.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn5.Text = " ";
            // 
            // losses_styleBtn5
            // 
            this.losses_styleBtn5.Name = "losses_styleBtn5";
            this.losses_styleBtn5.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn5.Text = "Style";
            this.losses_styleBtn5.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn5
            // 
            this.losses_extractBtn5.Name = "losses_extractBtn5";
            this.losses_extractBtn5.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn5.Text = "Extract Plot";
            this.losses_extractBtn5.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box5
            // 
            this.losses_X_Box5.AutoSize = false;
            this.losses_X_Box5.Name = "losses_X_Box5";
            this.losses_X_Box5.ReadOnly = true;
            this.losses_X_Box5.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box5.ToolTipText = "Width";
            // 
            // losses_Y_Box5
            // 
            this.losses_Y_Box5.AutoSize = false;
            this.losses_Y_Box5.Name = "losses_Y_Box5";
            this.losses_Y_Box5.ReadOnly = true;
            this.losses_Y_Box5.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box5.ToolTipText = "Height";
            // 
            // losses_groupBox3
            // 
            this.losses_groupBox3.Controls.Add(this.losses_plot_panel3);
            this.losses_groupBox3.Controls.Add(this.checkboxes_panel3);
            this.losses_groupBox3.Controls.Add(this.losses_toolStrip3);
            this.losses_groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox3.Location = new System.Drawing.Point(0, 279);
            this.losses_groupBox3.Name = "losses_groupBox3";
            this.losses_groupBox3.Size = new System.Drawing.Size(692, 279);
            this.losses_groupBox3.TabIndex = 32;
            this.losses_groupBox3.TabStop = false;
            // 
            // losses_plot_panel3
            // 
            this.losses_plot_panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel3.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel3.Name = "losses_plot_panel3";
            this.losses_plot_panel3.Size = new System.Drawing.Size(569, 260);
            this.losses_plot_panel3.TabIndex = 21;
            this.losses_plot_panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel3_Paint);
            this.losses_plot_panel3.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel3
            // 
            this.checkboxes_panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel3.Location = new System.Drawing.Point(615, 16);
            this.checkboxes_panel3.Name = "checkboxes_panel3";
            this.checkboxes_panel3.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel3.TabIndex = 22;
            // 
            // losses_toolStrip3
            // 
            this.losses_toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip3.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn3,
            this.losses_copyBtn3,
            this.losses_DropBtn3,
            this.losses_X_Box3,
            this.losses_Y_Box3});
            this.losses_toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip3.Name = "losses_toolStrip3";
            this.losses_toolStrip3.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip3.TabIndex = 24;
            // 
            // losses_saveBtn3
            // 
            this.losses_saveBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn3.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn3.Image")));
            this.losses_saveBtn3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn3.Name = "losses_saveBtn3";
            this.losses_saveBtn3.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn3.Text = "Save";
            this.losses_saveBtn3.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn3
            // 
            this.losses_copyBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn3.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn3.Image")));
            this.losses_copyBtn3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn3.Name = "losses_copyBtn3";
            this.losses_copyBtn3.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn3.Text = "Copy";
            this.losses_copyBtn3.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn3
            // 
            this.losses_DropBtn3.AutoToolTip = false;
            this.losses_DropBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn3,
            this.losses_extractBtn3});
            this.losses_DropBtn3.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn3.Image")));
            this.losses_DropBtn3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn3.Name = "losses_DropBtn3";
            this.losses_DropBtn3.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn3.Text = " ";
            // 
            // losses_styleBtn3
            // 
            this.losses_styleBtn3.Name = "losses_styleBtn3";
            this.losses_styleBtn3.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn3.Text = "Style";
            this.losses_styleBtn3.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn3
            // 
            this.losses_extractBtn3.Name = "losses_extractBtn3";
            this.losses_extractBtn3.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn3.Text = "Extract Plot";
            this.losses_extractBtn3.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box3
            // 
            this.losses_X_Box3.AutoSize = false;
            this.losses_X_Box3.Name = "losses_X_Box3";
            this.losses_X_Box3.ReadOnly = true;
            this.losses_X_Box3.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box3.ToolTipText = "Width";
            // 
            // losses_Y_Box3
            // 
            this.losses_Y_Box3.AutoSize = false;
            this.losses_Y_Box3.Name = "losses_Y_Box3";
            this.losses_Y_Box3.ReadOnly = true;
            this.losses_Y_Box3.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box3.ToolTipText = "Height";
            // 
            // losses_groupBox1
            // 
            this.losses_groupBox1.Controls.Add(this.losses_plot_panel1);
            this.losses_groupBox1.Controls.Add(this.checkboxes_panel1);
            this.losses_groupBox1.Controls.Add(this.losses_toolStrip1);
            this.losses_groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox1.Location = new System.Drawing.Point(0, 0);
            this.losses_groupBox1.Name = "losses_groupBox1";
            this.losses_groupBox1.Size = new System.Drawing.Size(692, 279);
            this.losses_groupBox1.TabIndex = 31;
            this.losses_groupBox1.TabStop = false;
            // 
            // losses_plot_panel1
            // 
            this.losses_plot_panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel1.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel1.Name = "losses_plot_panel1";
            this.losses_plot_panel1.Size = new System.Drawing.Size(569, 260);
            this.losses_plot_panel1.TabIndex = 21;
            this.losses_plot_panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel1_Paint);
            this.losses_plot_panel1.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel1
            // 
            this.checkboxes_panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel1.Location = new System.Drawing.Point(615, 16);
            this.checkboxes_panel1.Name = "checkboxes_panel1";
            this.checkboxes_panel1.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel1.TabIndex = 22;
            // 
            // losses_toolStrip1
            // 
            this.losses_toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn1,
            this.losses_copyBtn1,
            this.losses_DropBtn1,
            this.losses_X_Box1,
            this.losses_Y_Box1});
            this.losses_toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip1.Name = "losses_toolStrip1";
            this.losses_toolStrip1.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip1.TabIndex = 24;
            // 
            // losses_saveBtn1
            // 
            this.losses_saveBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn1.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn1.Image")));
            this.losses_saveBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn1.Name = "losses_saveBtn1";
            this.losses_saveBtn1.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn1.Text = "Save";
            this.losses_saveBtn1.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn1
            // 
            this.losses_copyBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn1.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn1.Image")));
            this.losses_copyBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn1.Name = "losses_copyBtn1";
            this.losses_copyBtn1.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn1.Text = "Copy";
            this.losses_copyBtn1.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn1
            // 
            this.losses_DropBtn1.AutoToolTip = false;
            this.losses_DropBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn1,
            this.losses_extractBtn1});
            this.losses_DropBtn1.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn1.Image")));
            this.losses_DropBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn1.Name = "losses_DropBtn1";
            this.losses_DropBtn1.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn1.Text = " ";
            // 
            // losses_styleBtn1
            // 
            this.losses_styleBtn1.Name = "losses_styleBtn1";
            this.losses_styleBtn1.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn1.Text = "Style";
            this.losses_styleBtn1.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn1
            // 
            this.losses_extractBtn1.Name = "losses_extractBtn1";
            this.losses_extractBtn1.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn1.Text = "Extract Plot";
            this.losses_extractBtn1.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box1
            // 
            this.losses_X_Box1.AutoSize = false;
            this.losses_X_Box1.Name = "losses_X_Box1";
            this.losses_X_Box1.ReadOnly = true;
            this.losses_X_Box1.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box1.ToolTipText = "Width";
            // 
            // losses_Y_Box1
            // 
            this.losses_Y_Box1.AutoSize = false;
            this.losses_Y_Box1.Name = "losses_Y_Box1";
            this.losses_Y_Box1.ReadOnly = true;
            this.losses_Y_Box1.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box1.ToolTipText = "Height";
            // 
            // losses_groupBox8
            // 
            this.losses_groupBox8.Controls.Add(this.losses_plot_panel8);
            this.losses_groupBox8.Controls.Add(this.checkboxes_panel8);
            this.losses_groupBox8.Controls.Add(this.losses_toolStrip8);
            this.losses_groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox8.Location = new System.Drawing.Point(0, 837);
            this.losses_groupBox8.Name = "losses_groupBox8";
            this.losses_groupBox8.Size = new System.Drawing.Size(626, 279);
            this.losses_groupBox8.TabIndex = 35;
            this.losses_groupBox8.TabStop = false;
            // 
            // losses_plot_panel8
            // 
            this.losses_plot_panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel8.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel8.Name = "losses_plot_panel8";
            this.losses_plot_panel8.Size = new System.Drawing.Size(503, 260);
            this.losses_plot_panel8.TabIndex = 21;
            this.losses_plot_panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel8_Paint);
            this.losses_plot_panel8.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel8
            // 
            this.checkboxes_panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel8.Location = new System.Drawing.Point(549, 16);
            this.checkboxes_panel8.Name = "checkboxes_panel8";
            this.checkboxes_panel8.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel8.TabIndex = 22;
            // 
            // losses_toolStrip8
            // 
            this.losses_toolStrip8.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip8.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip8.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn8,
            this.losses_copyBtn8,
            this.losses_DropBtn8,
            this.losses_X_Box8,
            this.losses_Y_Box8});
            this.losses_toolStrip8.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip8.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip8.Name = "losses_toolStrip8";
            this.losses_toolStrip8.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip8.TabIndex = 24;
            // 
            // losses_saveBtn8
            // 
            this.losses_saveBtn8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn8.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn8.Image")));
            this.losses_saveBtn8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn8.Name = "losses_saveBtn8";
            this.losses_saveBtn8.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn8.Text = "Save";
            this.losses_saveBtn8.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn8
            // 
            this.losses_copyBtn8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn8.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn8.Image")));
            this.losses_copyBtn8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn8.Name = "losses_copyBtn8";
            this.losses_copyBtn8.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn8.Text = "Copy";
            this.losses_copyBtn8.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn8
            // 
            this.losses_DropBtn8.AutoToolTip = false;
            this.losses_DropBtn8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn8,
            this.losses_extractBtn8});
            this.losses_DropBtn8.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn8.Image")));
            this.losses_DropBtn8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn8.Name = "losses_DropBtn8";
            this.losses_DropBtn8.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn8.Text = " ";
            // 
            // losses_styleBtn8
            // 
            this.losses_styleBtn8.Name = "losses_styleBtn8";
            this.losses_styleBtn8.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn8.Text = "Style";
            this.losses_styleBtn8.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn8
            // 
            this.losses_extractBtn8.Name = "losses_extractBtn8";
            this.losses_extractBtn8.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn8.Text = "Extract Plot";
            this.losses_extractBtn8.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box8
            // 
            this.losses_X_Box8.AutoSize = false;
            this.losses_X_Box8.Name = "losses_X_Box8";
            this.losses_X_Box8.ReadOnly = true;
            this.losses_X_Box8.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box8.ToolTipText = "Width";
            // 
            // losses_Y_Box8
            // 
            this.losses_Y_Box8.AutoSize = false;
            this.losses_Y_Box8.Name = "losses_Y_Box8";
            this.losses_Y_Box8.ReadOnly = true;
            this.losses_Y_Box8.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box8.ToolTipText = "Height";
            // 
            // losses_groupBox6
            // 
            this.losses_groupBox6.Controls.Add(this.losses_plot_panel6);
            this.losses_groupBox6.Controls.Add(this.checkboxes_panel6);
            this.losses_groupBox6.Controls.Add(this.losses_toolStrip6);
            this.losses_groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox6.Location = new System.Drawing.Point(0, 558);
            this.losses_groupBox6.Name = "losses_groupBox6";
            this.losses_groupBox6.Size = new System.Drawing.Size(626, 279);
            this.losses_groupBox6.TabIndex = 34;
            this.losses_groupBox6.TabStop = false;
            // 
            // losses_plot_panel6
            // 
            this.losses_plot_panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel6.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel6.Name = "losses_plot_panel6";
            this.losses_plot_panel6.Size = new System.Drawing.Size(503, 260);
            this.losses_plot_panel6.TabIndex = 21;
            this.losses_plot_panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel6_Paint);
            this.losses_plot_panel6.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel6
            // 
            this.checkboxes_panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel6.Location = new System.Drawing.Point(549, 16);
            this.checkboxes_panel6.Name = "checkboxes_panel6";
            this.checkboxes_panel6.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel6.TabIndex = 22;
            // 
            // losses_toolStrip6
            // 
            this.losses_toolStrip6.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip6.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn6,
            this.losses_copyBtn6,
            this.losses_DropBtn6,
            this.losses_X_Box6,
            this.losses_Y_Box6});
            this.losses_toolStrip6.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip6.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip6.Name = "losses_toolStrip6";
            this.losses_toolStrip6.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip6.TabIndex = 24;
            // 
            // losses_saveBtn6
            // 
            this.losses_saveBtn6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn6.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn6.Image")));
            this.losses_saveBtn6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn6.Name = "losses_saveBtn6";
            this.losses_saveBtn6.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn6.Text = "Save";
            this.losses_saveBtn6.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn6
            // 
            this.losses_copyBtn6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn6.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn6.Image")));
            this.losses_copyBtn6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn6.Name = "losses_copyBtn6";
            this.losses_copyBtn6.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn6.Text = "Copy";
            this.losses_copyBtn6.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn6
            // 
            this.losses_DropBtn6.AutoToolTip = false;
            this.losses_DropBtn6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn6,
            this.losses_extractBtn6});
            this.losses_DropBtn6.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn6.Image")));
            this.losses_DropBtn6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn6.Name = "losses_DropBtn6";
            this.losses_DropBtn6.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn6.Text = " ";
            // 
            // losses_styleBtn6
            // 
            this.losses_styleBtn6.Name = "losses_styleBtn6";
            this.losses_styleBtn6.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn6.Text = "Style";
            this.losses_styleBtn6.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn6
            // 
            this.losses_extractBtn6.Name = "losses_extractBtn6";
            this.losses_extractBtn6.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn6.Text = "Extract Plot";
            this.losses_extractBtn6.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box6
            // 
            this.losses_X_Box6.AutoSize = false;
            this.losses_X_Box6.Name = "losses_X_Box6";
            this.losses_X_Box6.ReadOnly = true;
            this.losses_X_Box6.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box6.ToolTipText = "Width";
            // 
            // losses_Y_Box6
            // 
            this.losses_Y_Box6.AutoSize = false;
            this.losses_Y_Box6.Name = "losses_Y_Box6";
            this.losses_Y_Box6.ReadOnly = true;
            this.losses_Y_Box6.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box6.ToolTipText = "Height";
            // 
            // losses_groupBox4
            // 
            this.losses_groupBox4.Controls.Add(this.losses_plot_panel4);
            this.losses_groupBox4.Controls.Add(this.checkboxes_panel4);
            this.losses_groupBox4.Controls.Add(this.losses_toolStrip4);
            this.losses_groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox4.Location = new System.Drawing.Point(0, 279);
            this.losses_groupBox4.Name = "losses_groupBox4";
            this.losses_groupBox4.Size = new System.Drawing.Size(626, 279);
            this.losses_groupBox4.TabIndex = 33;
            this.losses_groupBox4.TabStop = false;
            // 
            // losses_plot_panel4
            // 
            this.losses_plot_panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel4.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel4.Name = "losses_plot_panel4";
            this.losses_plot_panel4.Size = new System.Drawing.Size(503, 260);
            this.losses_plot_panel4.TabIndex = 21;
            this.losses_plot_panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel4_Paint);
            this.losses_plot_panel4.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel4
            // 
            this.checkboxes_panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel4.Location = new System.Drawing.Point(549, 16);
            this.checkboxes_panel4.Name = "checkboxes_panel4";
            this.checkboxes_panel4.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel4.TabIndex = 22;
            // 
            // losses_toolStrip4
            // 
            this.losses_toolStrip4.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip4.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn4,
            this.losses_copyBtn4,
            this.losses_DropBtn4,
            this.losses_X_Box4,
            this.losses_Y_Box4});
            this.losses_toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip4.Name = "losses_toolStrip4";
            this.losses_toolStrip4.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip4.TabIndex = 24;
            // 
            // losses_saveBtn4
            // 
            this.losses_saveBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn4.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn4.Image")));
            this.losses_saveBtn4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn4.Name = "losses_saveBtn4";
            this.losses_saveBtn4.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn4.Text = "Save";
            this.losses_saveBtn4.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn4
            // 
            this.losses_copyBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn4.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn4.Image")));
            this.losses_copyBtn4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn4.Name = "losses_copyBtn4";
            this.losses_copyBtn4.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn4.Text = "Copy";
            this.losses_copyBtn4.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn4
            // 
            this.losses_DropBtn4.AutoToolTip = false;
            this.losses_DropBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn4,
            this.losses_extractBtn4});
            this.losses_DropBtn4.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn4.Image")));
            this.losses_DropBtn4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn4.Name = "losses_DropBtn4";
            this.losses_DropBtn4.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn4.Text = " ";
            // 
            // losses_styleBtn4
            // 
            this.losses_styleBtn4.Name = "losses_styleBtn4";
            this.losses_styleBtn4.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn4.Text = "Style";
            this.losses_styleBtn4.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn4
            // 
            this.losses_extractBtn4.Name = "losses_extractBtn4";
            this.losses_extractBtn4.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn4.Text = "Extract Plot";
            this.losses_extractBtn4.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box4
            // 
            this.losses_X_Box4.AutoSize = false;
            this.losses_X_Box4.Name = "losses_X_Box4";
            this.losses_X_Box4.ReadOnly = true;
            this.losses_X_Box4.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box4.ToolTipText = "Width";
            // 
            // losses_Y_Box4
            // 
            this.losses_Y_Box4.AutoSize = false;
            this.losses_Y_Box4.Name = "losses_Y_Box4";
            this.losses_Y_Box4.ReadOnly = true;
            this.losses_Y_Box4.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box4.ToolTipText = "Height";
            // 
            // losses_groupBox2
            // 
            this.losses_groupBox2.Controls.Add(this.losses_plot_panel2);
            this.losses_groupBox2.Controls.Add(this.checkboxes_panel2);
            this.losses_groupBox2.Controls.Add(this.losses_toolStrip2);
            this.losses_groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.losses_groupBox2.Location = new System.Drawing.Point(0, 0);
            this.losses_groupBox2.Name = "losses_groupBox2";
            this.losses_groupBox2.Size = new System.Drawing.Size(626, 279);
            this.losses_groupBox2.TabIndex = 32;
            this.losses_groupBox2.TabStop = false;
            // 
            // losses_plot_panel2
            // 
            this.losses_plot_panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.losses_plot_panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.losses_plot_panel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_plot_panel2.Location = new System.Drawing.Point(46, 16);
            this.losses_plot_panel2.Name = "losses_plot_panel2";
            this.losses_plot_panel2.Size = new System.Drawing.Size(503, 260);
            this.losses_plot_panel2.TabIndex = 21;
            this.losses_plot_panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.losses_plot_panel2_Paint);
            this.losses_plot_panel2.Resize += new System.EventHandler(this.plot_Pnl_Resize);
            // 
            // checkboxes_panel2
            // 
            this.checkboxes_panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkboxes_panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkboxes_panel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.checkboxes_panel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxes_panel2.Location = new System.Drawing.Point(549, 16);
            this.checkboxes_panel2.Name = "checkboxes_panel2";
            this.checkboxes_panel2.Size = new System.Drawing.Size(74, 260);
            this.checkboxes_panel2.TabIndex = 22;
            // 
            // losses_toolStrip2
            // 
            this.losses_toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.losses_toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.losses_toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_saveBtn2,
            this.losses_copyBtn2,
            this.losses_DropBtn2,
            this.losses_X_Box2,
            this.losses_Y_Box2});
            this.losses_toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.losses_toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.losses_toolStrip2.Name = "losses_toolStrip2";
            this.losses_toolStrip2.Size = new System.Drawing.Size(43, 260);
            this.losses_toolStrip2.TabIndex = 24;
            // 
            // losses_saveBtn2
            // 
            this.losses_saveBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_saveBtn2.Image = ((System.Drawing.Image)(resources.GetObject("losses_saveBtn2.Image")));
            this.losses_saveBtn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_saveBtn2.Name = "losses_saveBtn2";
            this.losses_saveBtn2.Size = new System.Drawing.Size(40, 22);
            this.losses_saveBtn2.Text = "Save";
            this.losses_saveBtn2.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_copyBtn2
            // 
            this.losses_copyBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_copyBtn2.Image = ((System.Drawing.Image)(resources.GetObject("losses_copyBtn2.Image")));
            this.losses_copyBtn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_copyBtn2.Name = "losses_copyBtn2";
            this.losses_copyBtn2.Size = new System.Drawing.Size(40, 22);
            this.losses_copyBtn2.Text = "Copy";
            this.losses_copyBtn2.Click += new System.EventHandler(this.losses_save_copyBtn_Click);
            // 
            // losses_DropBtn2
            // 
            this.losses_DropBtn2.AutoToolTip = false;
            this.losses_DropBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.losses_DropBtn2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losses_styleBtn2,
            this.losses_extractBtn2});
            this.losses_DropBtn2.Image = ((System.Drawing.Image)(resources.GetObject("losses_DropBtn2.Image")));
            this.losses_DropBtn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.losses_DropBtn2.Name = "losses_DropBtn2";
            this.losses_DropBtn2.Size = new System.Drawing.Size(40, 22);
            this.losses_DropBtn2.Text = " ";
            // 
            // losses_styleBtn2
            // 
            this.losses_styleBtn2.Name = "losses_styleBtn2";
            this.losses_styleBtn2.Size = new System.Drawing.Size(133, 22);
            this.losses_styleBtn2.Text = "Style";
            this.losses_styleBtn2.ToolTipText = "Format the style of the plots in this tab";
            // 
            // losses_extractBtn2
            // 
            this.losses_extractBtn2.Name = "losses_extractBtn2";
            this.losses_extractBtn2.Size = new System.Drawing.Size(133, 22);
            this.losses_extractBtn2.Text = "Extract Plot";
            this.losses_extractBtn2.ToolTipText = "Extract plot and edit its shape";
            // 
            // losses_X_Box2
            // 
            this.losses_X_Box2.AutoSize = false;
            this.losses_X_Box2.Name = "losses_X_Box2";
            this.losses_X_Box2.ReadOnly = true;
            this.losses_X_Box2.Size = new System.Drawing.Size(40, 22);
            this.losses_X_Box2.ToolTipText = "Width";
            // 
            // losses_Y_Box2
            // 
            this.losses_Y_Box2.AutoSize = false;
            this.losses_Y_Box2.Name = "losses_Y_Box2";
            this.losses_Y_Box2.ReadOnly = true;
            this.losses_Y_Box2.Size = new System.Drawing.Size(40, 22);
            this.losses_Y_Box2.ToolTipText = "Height";
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.losses_label);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1356, 34);
            this.panel3.TabIndex = 32;
            // 
            // losses_label
            // 
            this.losses_label.AutoSize = true;
            this.losses_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.losses_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losses_label.ForeColor = System.Drawing.Color.Crimson;
            this.losses_label.Location = new System.Drawing.Point(0, 0);
            this.losses_label.Name = "losses_label";
            this.losses_label.Size = new System.Drawing.Size(196, 20);
            this.losses_label.TabIndex = 2;
            this.losses_label.Text = "Radical Migration Mapping";
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
            this.Text = "Peak Finder v25.1.2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form2_DpiChanged);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.contextMenuStrip_MSproduct.ResumeLayout(false);
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
            this.panel2_intIdxTo.ResumeLayout(false);
            this.int_IdxTo_toolStrip.ResumeLayout(false);
            this.int_IdxTo_toolStrip.PerformLayout();
            this.tabPrimary.ResumeLayout(false);
            this.panel2_tab3.ResumeLayout(false);
            this.groupBoxCharge4.ResumeLayout(false);
            this.groupBoxCharge4.PerformLayout();
            this.Charge_toolStrip4.ResumeLayout(false);
            this.Charge_toolStrip4.PerformLayout();
            this.groupBoxCharge3.ResumeLayout(false);
            this.groupBoxCharge3.PerformLayout();
            this.Charge_toolStrip3.ResumeLayout(false);
            this.Charge_toolStrip3.PerformLayout();
            this.groupBoxCharge2.ResumeLayout(false);
            this.groupBoxCharge2.PerformLayout();
            this.Charge_toolStrip2.ResumeLayout(false);
            this.Charge_toolStrip2.PerformLayout();
            this.groupBoxCharge1.ResumeLayout(false);
            this.groupBoxCharge1.PerformLayout();
            this.Charge_toolStrip1.ResumeLayout(false);
            this.Charge_toolStrip1.PerformLayout();
            this.panel1_tab3.ResumeLayout(false);
            this.groupBoxIntensity4.ResumeLayout(false);
            this.groupBoxIntensity4.PerformLayout();
            this.intensity_toolStrip4.ResumeLayout(false);
            this.intensity_toolStrip4.PerformLayout();
            this.groupBoxIntensity3.ResumeLayout(false);
            this.groupBoxIntensity3.PerformLayout();
            this.intensity_toolStrip3.ResumeLayout(false);
            this.intensity_toolStrip3.PerformLayout();
            this.groupBoxIntensity2.ResumeLayout(false);
            this.groupBoxIntensity2.PerformLayout();
            this.intensity_toolStrip2.ResumeLayout(false);
            this.intensity_toolStrip2.PerformLayout();
            this.groupBoxIntensity1.ResumeLayout(false);
            this.groupBoxIntensity1.PerformLayout();
            this.intensity_toolStrip1.ResumeLayout(false);
            this.intensity_toolStrip1.PerformLayout();
            this.tabDiagram.ResumeLayout(false);
            this.panel2_tab2.ResumeLayout(false);
            this.panel2_tab2.PerformLayout();
            this.ppm_toolStrip6.ResumeLayout(false);
            this.ppm_toolStrip6.PerformLayout();
            this.ppm_toolStrip4.ResumeLayout(false);
            this.ppm_toolStrip4.PerformLayout();
            this.ppm_toolStrip5.ResumeLayout(false);
            this.ppm_toolStrip5.PerformLayout();
            this.ppm_toolStrip3.ResumeLayout(false);
            this.ppm_toolStrip3.PerformLayout();
            this.ppm_toolStrip2.ResumeLayout(false);
            this.ppm_toolStrip2.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ppm_toolStrip.ResumeLayout(false);
            this.ppm_toolStrip.PerformLayout();
            this.panel1_tab2.ResumeLayout(false);
            this.draw_sequence_panelCopy2.ResumeLayout(false);
            this.draw_sequence_panelCopy2.PerformLayout();
            this.sequence_toolStripCopy2.ResumeLayout(false);
            this.sequence_toolStripCopy2.PerformLayout();
            this.sequence_PnlCopy2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBoxCopy2)).EndInit();
            this.draw_sequence_panelCopy1.ResumeLayout(false);
            this.draw_sequence_panelCopy1.PerformLayout();
            this.sequence_toolStripCopy1.ResumeLayout(false);
            this.sequence_toolStripCopy1.PerformLayout();
            this.sequence_PnlCopy1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBoxCopy1)).EndInit();
            this.draw_sequence_panel.ResumeLayout(false);
            this.draw_sequence_panel.PerformLayout();
            this.sequence_toolStrip.ResumeLayout(false);
            this.sequence_toolStrip.PerformLayout();
            this.sequence_Pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.color_range_picBox)).EndInit();
            this.tabFit.ResumeLayout(false);
            this.plots_grpBox.ResumeLayout(false);
            this.toolStrip_plot.ResumeLayout(false);
            this.toolStrip_plot.PerformLayout();
            this.user_grpBox.ResumeLayout(false);
            this.Fit_results_groupBox.ResumeLayout(false);
            this.Fit_results_groupBox.PerformLayout();
            this.toolStrip_fit_sort.ResumeLayout(false);
            this.toolStrip_fit_sort.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip_fragList.ResumeLayout(false);
            this.toolStrip_fragList.PerformLayout();
            this.fragTypes_toolStrip.ResumeLayout(false);
            this.fragTypes_toolStrip.PerformLayout();
            this.theorData_grpBx.ResumeLayout(false);
            this.theorData_grpBx.PerformLayout();
            this.expData_grpBx.ResumeLayout(false);
            this.expData_grpBx.PerformLayout();
            this.exp_Settings_toolStrip.ResumeLayout(false);
            this.exp_Settings_toolStrip.PerformLayout();
            this.fitOptions_grpBox.ResumeLayout(false);
            this.fitOptions_grpBox.PerformLayout();
            this.fiToolStrip.ResumeLayout(false);
            this.fiToolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_losses.ResumeLayout(false);
            this.losses_splitContainer.Panel1.ResumeLayout(false);
            this.losses_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.losses_splitContainer)).EndInit();
            this.losses_splitContainer.ResumeLayout(false);
            this.losses_groupBox7.ResumeLayout(false);
            this.losses_groupBox7.PerformLayout();
            this.losses_toolStrip7.ResumeLayout(false);
            this.losses_toolStrip7.PerformLayout();
            this.losses_groupBox5.ResumeLayout(false);
            this.losses_groupBox5.PerformLayout();
            this.losses_toolStrip5.ResumeLayout(false);
            this.losses_toolStrip5.PerformLayout();
            this.losses_groupBox3.ResumeLayout(false);
            this.losses_groupBox3.PerformLayout();
            this.losses_toolStrip3.ResumeLayout(false);
            this.losses_toolStrip3.PerformLayout();
            this.losses_groupBox1.ResumeLayout(false);
            this.losses_groupBox1.PerformLayout();
            this.losses_toolStrip1.ResumeLayout(false);
            this.losses_toolStrip1.PerformLayout();
            this.losses_groupBox8.ResumeLayout(false);
            this.losses_groupBox8.PerformLayout();
            this.losses_toolStrip8.ResumeLayout(false);
            this.losses_toolStrip8.PerformLayout();
            this.losses_groupBox6.ResumeLayout(false);
            this.losses_groupBox6.PerformLayout();
            this.losses_toolStrip6.ResumeLayout(false);
            this.losses_toolStrip6.PerformLayout();
            this.losses_groupBox4.ResumeLayout(false);
            this.losses_groupBox4.PerformLayout();
            this.losses_toolStrip4.ResumeLayout(false);
            this.losses_toolStrip4.PerformLayout();
            this.losses_groupBox2.ResumeLayout(false);
            this.losses_groupBox2.PerformLayout();
            this.losses_toolStrip2.ResumeLayout(false);
            this.losses_toolStrip2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader ionTypeHeader;
        private System.Windows.Forms.ColumnHeader mzHeader;
        private System.Windows.Forms.ColumnHeader zHeader;
        private System.Windows.Forms.ColumnHeader formulaHeader;
        private System.Windows.Forms.ColumnHeader codeNoHeader;
        private System.Windows.Forms.ColumnHeader factorHeader;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader intensityHeader;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MSproduct;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.TabPage tabInternal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1_intIdx;
        private System.Windows.Forms.Panel idxPnl1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel idxInt_Pnl1;
        private System.Windows.Forms.Label idxPlotLbl;
        private System.Windows.Forms.ToolStrip int_Idx_toolStrip;
        private System.Windows.Forms.ToolStripButton int_IdxSave_Btn;
        private System.Windows.Forms.ToolStripButton int_IdxCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2_intIdxTo;
        private System.Windows.Forms.Panel idxPnl2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel idxInt_Pnl2;
        private System.Windows.Forms.ToolStrip int_IdxTo_toolStrip;
        private System.Windows.Forms.ToolStripButton int_IdxToSave_Btn;
        private System.Windows.Forms.ToolStripButton int_IdxToCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem2;
        private System.Windows.Forms.TabPage tabPrimary;
        private System.Windows.Forms.Panel panel2_tab3;
        private System.Windows.Forms.GroupBox groupBoxCharge4;
        private System.Windows.Forms.Panel dzCharge_Pnl;
        private System.Windows.Forms.ToolStrip Charge_toolStrip4;
        private System.Windows.Forms.ToolStripButton dzChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton dzChargeCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem_charge_dz;
        private System.Windows.Forms.ToolStripButton up4_Btn;
        private System.Windows.Forms.ToolStripButton down4_Btn;
        private System.Windows.Forms.ToolStripTextBox dzcharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox dzcharge_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxCharge3;
        private System.Windows.Forms.Panel czCharge_Pnl;
        private System.Windows.Forms.ToolStrip Charge_toolStrip3;
        private System.Windows.Forms.ToolStripButton czChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton czChargeCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton9;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem6;
        private System.Windows.Forms.ToolStripButton up3_Btn;
        private System.Windows.Forms.ToolStripButton down3_Btn;
        private System.Windows.Forms.ToolStripTextBox czcharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox czcharge_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxCharge2;
        private System.Windows.Forms.Panel byCharge_Pnl;
        private System.Windows.Forms.ToolStrip Charge_toolStrip2;
        private System.Windows.Forms.ToolStripButton byChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton byChargeCopy_Btn;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton up2_Btn;
        private System.Windows.Forms.ToolStripButton down2_Btn;
        private System.Windows.Forms.ToolStripTextBox bycharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox bycharge_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxCharge1;
        private System.Windows.Forms.Panel axCharge_Pnl;
        private System.Windows.Forms.ToolStrip Charge_toolStrip1;
        private System.Windows.Forms.ToolStripButton axChargeSave_Btn;
        private System.Windows.Forms.ToolStripButton axChargeCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton form_primCharge_Btn;
        private System.Windows.Forms.ToolStripMenuItem style_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem7;
        private System.Windows.Forms.ToolStripButton up1_Btn;
        private System.Windows.Forms.ToolStripButton down1_Btn;
        private System.Windows.Forms.ToolStripTextBox axcharge_X_Box;
        private System.Windows.Forms.ToolStripTextBox axcharge_Y_Box;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1_tab3;
        private System.Windows.Forms.GroupBox groupBoxIntensity4;
        private System.Windows.Forms.Panel dz_Pnl;
        private System.Windows.Forms.ToolStrip intensity_toolStrip4;
        private System.Windows.Forms.ToolStripButton dzSave_Btn;
        private System.Windows.Forms.ToolStripButton dzCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem_dz;
        private System.Windows.Forms.ToolStripTextBox dz_X_Box;
        private System.Windows.Forms.ToolStripTextBox dz_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxIntensity3;
        private System.Windows.Forms.Panel cz_Pnl;
        private System.Windows.Forms.ToolStrip intensity_toolStrip3;
        private System.Windows.Forms.ToolStripButton czSave_Btn;
        private System.Windows.Forms.ToolStripButton czCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem8;
        private System.Windows.Forms.ToolStripTextBox cz_X_Box;
        private System.Windows.Forms.ToolStripTextBox cz_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxIntensity2;
        private System.Windows.Forms.Panel by_Pnl;
        private System.Windows.Forms.ToolStrip intensity_toolStrip2;
        private System.Windows.Forms.ToolStripButton byCopy_Btn;
        private System.Windows.Forms.ToolStripButton bySave_Btn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox by_X_Box;
        private System.Windows.Forms.ToolStripTextBox by_Y_Box;
        private System.Windows.Forms.GroupBox groupBoxIntensity1;
        private System.Windows.Forms.Panel ax_Pnl;
        private System.Windows.Forms.ToolStrip intensity_toolStrip1;
        private System.Windows.Forms.ToolStripButton axSave_Btn;
        private System.Windows.Forms.ToolStripButton axCopy_Btn;
        private System.Windows.Forms.ToolStripDropDownButton form_prim_Btn;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox ax_X_Box;
        private System.Windows.Forms.ToolStripTextBox ax_Y_Box;
        private System.Windows.Forms.TabPage tabDiagram;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel2_tab2;
        private System.Windows.Forms.ToolStrip ppm_toolStrip6;
        private System.Windows.Forms.ToolStripButton ppm_M;
        private System.Windows.Forms.ToolStripButton ppm_M_H2O;
        private System.Windows.Forms.ToolStripButton ppm_M_NH3;
        private System.Windows.Forms.ToolStripButton ppm_uncheckBtn;
        private System.Windows.Forms.ToolStripButton ppm_checkall_Btn;
        private System.Windows.Forms.ToolStripButton ppm_B_;
        private System.Windows.Forms.ToolStrip ppm_toolStrip4;
        private System.Windows.Forms.ToolStripButton ppm_internal_b;
        private System.Windows.Forms.ToolStripButton ppm_internal_b_H2O;
        private System.Windows.Forms.ToolStripButton ppm_internal_b_NH3;
        private System.Windows.Forms.ToolStrip ppm_toolStrip5;
        private System.Windows.Forms.ToolStripButton ppm_internal_a;
        private System.Windows.Forms.ToolStripButton ppm_internal_a_H2O;
        private System.Windows.Forms.ToolStripButton ppm_internal_a_NH3;
        private System.Windows.Forms.ToolStrip ppm_toolStrip3;
        private System.Windows.Forms.ToolStripButton ppm_w;
        private System.Windows.Forms.ToolStripButton ppm_w_H2O;
        private System.Windows.Forms.ToolStripButton ppm_w_B;
        private System.Windows.Forms.ToolStripButton ppm_x;
        private System.Windows.Forms.ToolStripButton ppm_x_H2O;
        private System.Windows.Forms.ToolStripButton ppm_x_NH3;
        private System.Windows.Forms.ToolStripButton ppm_y;
        private System.Windows.Forms.ToolStripButton ppm_y_H2O;
        private System.Windows.Forms.ToolStripButton ppm_y_NH3;
        private System.Windows.Forms.ToolStripButton ppm_z;
        private System.Windows.Forms.ToolStripButton ppm_z_H2O;
        private System.Windows.Forms.ToolStripButton ppm_z_NH3;
        private System.Windows.Forms.ToolStrip ppm_toolStrip2;
        private System.Windows.Forms.ToolStripButton ppm_a;
        private System.Windows.Forms.ToolStripButton ppm_a_H2O;
        private System.Windows.Forms.ToolStripButton ppm_a_NH3;
        private System.Windows.Forms.ToolStripButton ppm_b;
        private System.Windows.Forms.ToolStripButton ppm_b_H2O;
        private System.Windows.Forms.ToolStripButton ppm_b_NH3;
        private System.Windows.Forms.ToolStripButton ppm_c;
        private System.Windows.Forms.ToolStripButton ppm_c_H2O;
        private System.Windows.Forms.ToolStripButton ppm_c_NH3;
        private System.Windows.Forms.ToolStripButton ppm_d;
        private System.Windows.Forms.ToolStripButton ppm_d_H2O;
        private System.Windows.Forms.ToolStripButton ppm_d_B;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel ppm_panel;
        private System.Windows.Forms.ToolStrip ppm_toolStrip;
        private System.Windows.Forms.ToolStripButton ppmSave_Btn;
        private System.Windows.Forms.ToolStripButton ppmCopy_Btn;
        private System.Windows.Forms.ToolStripButton ppm_legend_Btn;
        private System.Windows.Forms.ToolStripDropDownButton ppm_extract_btn;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1_tab2;
        private System.Windows.Forms.Panel draw_sequence_panelCopy2;
        private System.Windows.Forms.Label seq_LblCopy2;
        private System.Windows.Forms.CheckBox highlight_ibt_ckBxCopy2;
        private System.Windows.Forms.ComboBox seq_extensionBoxCopy2;
        private System.Windows.Forms.CheckBox los_chkBoxCopy2;
        private System.Windows.Forms.Button delele_sequencePnl2;
        private System.Windows.Forms.RadioButton rdBtn50Copy2;
        private System.Windows.Forms.RadioButton rdBtn25Copy2;
        private System.Windows.Forms.ToolStrip sequence_toolStripCopy2;
        private System.Windows.Forms.ToolStripButton seqSave_BtnCopy2;
        private System.Windows.Forms.ToolStripButton seqCopy_BtnCopy2;
        private System.Windows.Forms.CheckBox ax_chBxCopy2;
        private System.Windows.Forms.CheckBox by_chBxCopy2;
        private System.Windows.Forms.CheckBox cz_chBxCopy2;
        private System.Windows.Forms.CheckBox intA_chBxCopy2;
        private System.Windows.Forms.CheckBox intB_chBxCopy2;
        private System.Windows.Forms.Panel sequence_PnlCopy2;
        private System.Windows.Forms.Panel color_range_panelCopy2;
        private System.Windows.Forms.PictureBox color_range_picBoxCopy2;
        private System.Windows.Forms.Panel seq_lbl_panelCopy2;
        private System.Windows.Forms.Button draw_BtnCopy2;
        private System.Windows.Forms.Panel draw_sequence_panelCopy1;
        private System.Windows.Forms.Label seq_LblCopy1;
        private System.Windows.Forms.CheckBox highlight_ibt_ckBxCopy1;
        private System.Windows.Forms.ComboBox seq_extensionBoxCopy1;
        private System.Windows.Forms.CheckBox los_chkBoxCopy1;
        private System.Windows.Forms.Button delele_sequencePnl1;
        private System.Windows.Forms.RadioButton rdBtn50Copy1;
        private System.Windows.Forms.RadioButton rdBtn25Copy1;
        private System.Windows.Forms.ToolStrip sequence_toolStripCopy1;
        private System.Windows.Forms.ToolStripButton seqSave_BtnCopy1;
        private System.Windows.Forms.ToolStripButton seqCopy_BtnCopy1;
        private System.Windows.Forms.CheckBox ax_chBxCopy1;
        private System.Windows.Forms.CheckBox by_chBxCopy1;
        private System.Windows.Forms.CheckBox cz_chBxCopy1;
        private System.Windows.Forms.CheckBox intA_chBxCopy1;
        private System.Windows.Forms.CheckBox intB_chBxCopy1;
        private System.Windows.Forms.Panel sequence_PnlCopy1;
        private System.Windows.Forms.Panel color_range_panelCopy1;
        private System.Windows.Forms.PictureBox color_range_picBoxCopy1;
        private System.Windows.Forms.Panel seq_lbl_panelCopy1;
        private System.Windows.Forms.Button draw_BtnCopy1;
        private System.Windows.Forms.Panel draw_sequence_panel;
        private System.Windows.Forms.Label seq_Lbl;
        private System.Windows.Forms.CheckBox highlight_ibt_ckBx;
        private System.Windows.Forms.ComboBox seq_extensionBox;
        private System.Windows.Forms.CheckBox los_chkBox;
        private System.Windows.Forms.Button add_sequencePanel1;
        private System.Windows.Forms.RadioButton rdBtn50;
        private System.Windows.Forms.RadioButton rdBtn25;
        private System.Windows.Forms.ToolStrip sequence_toolStrip;
        private System.Windows.Forms.ToolStripButton seqSave_Btn;
        private System.Windows.Forms.ToolStripButton seqCopy_Btn;
        private System.Windows.Forms.ToolStripButton seq_coverageBtn;
        private System.Windows.Forms.ToolStripButton highlightProp_Btn;
        private System.Windows.Forms.CheckBox ax_chBx;
        private System.Windows.Forms.CheckBox by_chBx;
        private System.Windows.Forms.CheckBox cz_chBx;
        private System.Windows.Forms.CheckBox intA_chBx;
        private System.Windows.Forms.CheckBox intB_chBx;
        private System.Windows.Forms.Panel sequence_Pnl;
        private System.Windows.Forms.Panel color_range_panel;
        private System.Windows.Forms.PictureBox color_range_picBox;
        private System.Windows.Forms.Panel seq_lbl_panel;
        private System.Windows.Forms.Button draw_Btn;
        private System.Windows.Forms.TabPage tabFit;
        private System.Windows.Forms.Panel plots_grpBox;
        private System.Windows.Forms.GroupBox fit_grpBox;
        private System.Windows.Forms.ToolStrip toolStrip_plot;
        private System.Windows.Forms.ToolStripDropDownButton chartFormatBtn;
        private System.Windows.Forms.ToolStripMenuItem styleFormatBtn;
        private System.Windows.Forms.ToolStripMenuItem extractPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton exportImage_Btn;
        private System.Windows.Forms.ToolStripButton autoscale_Btn;
        private System.Windows.Forms.ToolStripButton cursor_chkBx;
        private System.Windows.Forms.ToolStripButton copyImage_Btn;
        private System.Windows.Forms.ToolStripButton zoomIn_Y_Btn;
        private System.Windows.Forms.ToolStripButton zoomOut_Y_Btn;
        private System.Windows.Forms.ToolStripButton legend_chkBx;
        private System.Windows.Forms.ToolStripButton fragPlotLbl_chkBx;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton fragPlotLbl_chkBx2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton3;
        private System.Windows.Forms.ToolStripButton disp_a;
        private System.Windows.Forms.ToolStripButton disp_b;
        private System.Windows.Forms.ToolStripButton disp_c;
        private System.Windows.Forms.ToolStripButton disp_d;
        private System.Windows.Forms.ToolStripButton disp_w;
        private System.Windows.Forms.ToolStripButton disp_x;
        private System.Windows.Forms.ToolStripButton disp_y;
        private System.Windows.Forms.ToolStripButton disp_z;
        private System.Windows.Forms.ToolStripButton disp_internal;
        private System.Windows.Forms.ToolStripDropDownButton project_options_toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chageStateToolStripMenuItem;
        private System.Windows.Forms.GroupBox res_grpBox;
        private System.Windows.Forms.Panel user_grpBox;
        private System.Windows.Forms.GroupBox Fit_results_groupBox;
        private System.Windows.Forms.FlowLayoutPanel bigPanel;
        private System.Windows.Forms.ToolStrip toolStrip_fit_sort;
        private System.Windows.Forms.ToolStripButton check_bestBtn;
        private System.Windows.Forms.ToolStripButton uncheckFit_Btn;
        private System.Windows.Forms.ToolStripButton sortSettings_Btn;
        private System.Windows.Forms.ToolStripButton refresh_fitRes_Btn;
        private System.Windows.Forms.Panel splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip_fragList;
        private System.Windows.Forms.ToolStripButton saveListBtn11;
        private System.Windows.Forms.ToolStripDropDownButton loadListBtn11;
        private System.Windows.Forms.ToolStripMenuItem loadFragmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFragmentsAndRecalculateResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton clearListBtn11;
        private System.Windows.Forms.ToolStripSeparator toolStripButton10;
        private System.Windows.Forms.ToolStripButton checkall_Frag_Btn;
        private System.Windows.Forms.ToolStripButton uncheckall_Frag_Btn;
        private System.Windows.Forms.ToolStripButton toggle_toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton show_files_Btn;
        private System.Windows.Forms.ToolStripButton statistics_Btn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton14;
        private System.Windows.Forms.ToolStripButton fragCalc_Btn2;
        private System.Windows.Forms.ToolStripButton refresh_frag_Btn2;
        private System.Windows.Forms.ToolStripButton frag_sort_Btn2;
        private System.Windows.Forms.Panel factor_panel;
        private System.Windows.Forms.Label fragStorage_Lbl;
        private System.Windows.Forms.ToolStrip fragTypes_toolStrip;
        private System.Windows.Forms.ToolStripButton save_FragTypes_Btn;
        private System.Windows.Forms.ToolStripButton toggle_FragTypes_Btn;
        private System.Windows.Forms.TreeView fragTypes_tree;
        private System.Windows.Forms.GroupBox theorData_grpBx;
        private System.Windows.Forms.Button ProfCalc_Btn;
        private System.Windows.Forms.TreeView MSproduct_treeView;
        private System.Windows.Forms.Button deleteMSProd_Btn;
        private System.Windows.Forms.Button seqBtn;
        private System.Windows.Forms.Button loadFF_Btn;
        private System.Windows.Forms.Button loadMS_Btn;
        private System.Windows.Forms.CheckBox plotFragProf_chkBox;
        private System.Windows.Forms.CheckBox plotFragCent_chkBox;
        private System.Windows.Forms.GroupBox expData_grpBx;
        private System.Windows.Forms.TextBox filename_txtBx;
        private System.Windows.Forms.Button displayPeakList_btn;
        private System.Windows.Forms.ToolStrip exp_Settings_toolStrip;
        private System.Windows.Forms.ToolStripButton settingsPeak_Btn;
        private System.Windows.Forms.CheckBox plotCentr_chkBox;
        private System.Windows.Forms.CheckBox plotExp_chkBox;
        private System.Windows.Forms.Button loadExp_Btn;
        private System.Windows.Forms.GroupBox fitOptions_grpBox;
        private System.Windows.Forms.Button fit_chkGrpsChkFragBtn;
        private System.Windows.Forms.Button fit_chkGrpsBtn;
        private System.Windows.Forms.ToolStrip fiToolStrip;
        private System.Windows.Forms.ToolStripButton Fitting_chkBox;
        private System.Windows.Forms.ToolStripButton fitSettings_Btn;
        private System.Windows.Forms.Button fit_Btn;
        private System.Windows.Forms.Button fit_sel_Btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_losses;
        private System.Windows.Forms.GroupBox losses_groupBox1;
        private System.Windows.Forms.Panel losses_plot_panel1;
        private System.Windows.Forms.ToolStrip losses_toolStrip1;
        private System.Windows.Forms.ToolStripButton losses_saveBtn1;
        private System.Windows.Forms.ToolStripButton losses_copyBtn1;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn1;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn1;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn1;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box1;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box1;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label losses_label;
        private System.Windows.Forms.SplitContainer losses_splitContainer;
        private System.Windows.Forms.GroupBox losses_groupBox5;
        private System.Windows.Forms.Panel losses_plot_panel5;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel5;
        private System.Windows.Forms.ToolStrip losses_toolStrip5;
        private System.Windows.Forms.ToolStripButton losses_saveBtn5;
        private System.Windows.Forms.ToolStripButton losses_copyBtn5;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn5;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn5;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn5;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box5;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box5;
        private System.Windows.Forms.GroupBox losses_groupBox3;
        private System.Windows.Forms.Panel losses_plot_panel3;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel3;
        private System.Windows.Forms.ToolStrip losses_toolStrip3;
        private System.Windows.Forms.ToolStripButton losses_saveBtn3;
        private System.Windows.Forms.ToolStripButton losses_copyBtn3;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn3;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn3;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn3;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box3;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box3;
        private System.Windows.Forms.GroupBox losses_groupBox6;
        private System.Windows.Forms.Panel losses_plot_panel6;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel6;
        private System.Windows.Forms.ToolStrip losses_toolStrip6;
        private System.Windows.Forms.ToolStripButton losses_saveBtn6;
        private System.Windows.Forms.ToolStripButton losses_copyBtn6;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn6;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn6;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn6;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box6;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box6;
        private System.Windows.Forms.GroupBox losses_groupBox4;
        private System.Windows.Forms.Panel losses_plot_panel4;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel4;
        private System.Windows.Forms.ToolStrip losses_toolStrip4;
        private System.Windows.Forms.ToolStripButton losses_saveBtn4;
        private System.Windows.Forms.ToolStripButton losses_copyBtn4;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn4;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn4;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn4;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box4;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box4;
        private System.Windows.Forms.GroupBox losses_groupBox2;
        private System.Windows.Forms.Panel losses_plot_panel2;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel2;
        private System.Windows.Forms.ToolStrip losses_toolStrip2;
        private System.Windows.Forms.ToolStripButton losses_saveBtn2;
        private System.Windows.Forms.ToolStripButton losses_copyBtn2;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn2;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn2;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn2;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box2;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box2;
        private System.Windows.Forms.GroupBox losses_groupBox7;
        private System.Windows.Forms.Panel losses_plot_panel7;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel7;
        private System.Windows.Forms.ToolStrip losses_toolStrip7;
        private System.Windows.Forms.ToolStripButton losses_saveBtn7;
        private System.Windows.Forms.ToolStripButton losses_copyBtn7;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn7;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn7;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn7;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box7;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box7;
        private System.Windows.Forms.GroupBox losses_groupBox8;
        private System.Windows.Forms.Panel losses_plot_panel8;
        private System.Windows.Forms.FlowLayoutPanel checkboxes_panel8;
        private System.Windows.Forms.ToolStrip losses_toolStrip8;
        private System.Windows.Forms.ToolStripButton losses_saveBtn8;
        private System.Windows.Forms.ToolStripButton losses_copyBtn8;
        private System.Windows.Forms.ToolStripDropDownButton losses_DropBtn8;
        private System.Windows.Forms.ToolStripMenuItem losses_styleBtn8;
        private System.Windows.Forms.ToolStripMenuItem losses_extractBtn8;
        private System.Windows.Forms.ToolStripTextBox losses_X_Box8;
        private System.Windows.Forms.ToolStripTextBox losses_Y_Box8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}