namespace Isotope_fitting
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.minIntensity_lbl = new System.Windows.Forms.Label();
            this.minIntensity_numUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.listRes_radBtn = new System.Windows.Forms.RadioButton();
            this.constRes_radBtn = new System.Windows.Forms.RadioButton();
            this.resolution_list_combBox = new System.Windows.Forms.ComboBox();
            this.selection_list_1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.save_peakBtn = new System.Windows.Forms.ToolStripButton();
            this.recalc_peakBtn = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.save_btn = new System.Windows.Forms.ToolStripButton();
            this.recalc_Exp_Btn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity_numUD)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // minIntensity_lbl
            // 
            this.minIntensity_lbl.AutoSize = true;
            this.minIntensity_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minIntensity_lbl.Location = new System.Drawing.Point(20, 11);
            this.minIntensity_lbl.Name = "minIntensity_lbl";
            this.minIntensity_lbl.Size = new System.Drawing.Size(131, 13);
            this.minIntensity_lbl.TabIndex = 0;
            this.minIntensity_lbl.Text = "Peak detect min intensity: ";
            this.minIntensity_lbl.Click += new System.EventHandler(this.minIntensity_lbl_Click);
            // 
            // minIntensity_numUD
            // 
            this.minIntensity_numUD.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minIntensity_numUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minIntensity_numUD.Location = new System.Drawing.Point(160, 7);
            this.minIntensity_numUD.Maximum = new decimal(new int[] {
            1241513984,
            370409800,
            542101,
            0});
            this.minIntensity_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minIntensity_numUD.Name = "minIntensity_numUD";
            this.minIntensity_numUD.Size = new System.Drawing.Size(73, 21);
            this.minIntensity_numUD.TabIndex = 1;
            this.minIntensity_numUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Resolution";
            // 
            // listRes_radBtn
            // 
            this.listRes_radBtn.AutoSize = true;
            this.listRes_radBtn.Location = new System.Drawing.Point(6, 82);
            this.listRes_radBtn.Name = "listRes_radBtn";
            this.listRes_radBtn.Size = new System.Drawing.Size(85, 17);
            this.listRes_radBtn.TabIndex = 8;
            this.listRes_radBtn.Text = "Machine List";
            this.listRes_radBtn.UseVisualStyleBackColor = true;
            this.listRes_radBtn.CheckedChanged += new System.EventHandler(this.listRes_radBtn_CheckedChanged);
            // 
            // constRes_radBtn
            // 
            this.constRes_radBtn.AutoSize = true;
            this.constRes_radBtn.Location = new System.Drawing.Point(6, 38);
            this.constRes_radBtn.Name = "constRes_radBtn";
            this.constRes_radBtn.Size = new System.Drawing.Size(70, 17);
            this.constRes_radBtn.TabIndex = 7;
            this.constRes_radBtn.Text = "Constant ";
            this.constRes_radBtn.UseVisualStyleBackColor = true;
            this.constRes_radBtn.CheckedChanged += new System.EventHandler(this.constRes_radBtn_CheckedChanged);
            // 
            // resolution_list_combBox
            // 
            this.resolution_list_combBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolution_list_combBox.DropDownWidth = 250;
            this.resolution_list_combBox.Enabled = false;
            this.resolution_list_combBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolution_list_combBox.FormattingEnabled = true;
            this.resolution_list_combBox.Items.AddRange(new object[] {
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
            this.resolution_list_combBox.Location = new System.Drawing.Point(102, 80);
            this.resolution_list_combBox.Name = "resolution_list_combBox";
            this.resolution_list_combBox.Size = new System.Drawing.Size(122, 21);
            this.resolution_list_combBox.TabIndex = 6;
            // 
            // selection_list_1
            // 
            this.selection_list_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selection_list_1.Enabled = false;
            this.selection_list_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selection_list_1.FormattingEnabled = true;
            this.selection_list_1.Items.AddRange(new object[] {
            "17500",
            "35000",
            "70000",
            "140000",
            "280000"});
            this.selection_list_1.Location = new System.Drawing.Point(102, 36);
            this.selection_list_1.Name = "selection_list_1";
            this.selection_list_1.Size = new System.Drawing.Size(122, 21);
            this.selection_list_1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(249, 187);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.minIntensity_numUD);
            this.tabPage1.Controls.Add(this.minIntensity_lbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 161);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Peak Detection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_peakBtn,
            this.recalc_peakBtn});
            this.toolStrip1.Location = new System.Drawing.Point(3, 121);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(235, 37);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // save_peakBtn
            // 
            this.save_peakBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_peakBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_peakBtn.Image = ((System.Drawing.Image)(resources.GetObject("save_peakBtn.Image")));
            this.save_peakBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_peakBtn.Name = "save_peakBtn";
            this.save_peakBtn.Size = new System.Drawing.Size(34, 34);
            this.save_peakBtn.Text = "Save";
            this.save_peakBtn.Click += new System.EventHandler(this.save_peak_btn_Click);
            // 
            // recalc_peakBtn
            // 
            this.recalc_peakBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.recalc_peakBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recalc_peakBtn.Image = ((System.Drawing.Image)(resources.GetObject("recalc_peakBtn.Image")));
            this.recalc_peakBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recalc_peakBtn.Name = "recalc_peakBtn";
            this.recalc_peakBtn.Size = new System.Drawing.Size(34, 34);
            this.recalc_peakBtn.Text = "Recalculate peak list";
            this.recalc_peakBtn.Click += new System.EventHandler(this.recalc_peakBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.listRes_radBtn);
            this.tabPage2.Controls.Add(this.resolution_list_combBox);
            this.tabPage2.Controls.Add(this.constRes_radBtn);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.selection_list_1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(241, 161);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deconvolution";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_btn,
            this.recalc_Exp_Btn});
            this.toolStrip2.Location = new System.Drawing.Point(3, 121);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(235, 37);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // save_btn
            // 
            this.save_btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_btn.Image = ((System.Drawing.Image)(resources.GetObject("save_btn.Image")));
            this.save_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(34, 34);
            this.save_btn.Text = "Save";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // recalc_Exp_Btn
            // 
            this.recalc_Exp_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.recalc_Exp_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recalc_Exp_Btn.Image = ((System.Drawing.Image)(resources.GetObject("recalc_Exp_Btn.Image")));
            this.recalc_Exp_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recalc_Exp_Btn.Name = "recalc_Exp_Btn";
            this.recalc_Exp_Btn.Size = new System.Drawing.Size(34, 34);
            this.recalc_Exp_Btn.Text = "Recalculate profile";
            this.recalc_Exp_Btn.Click += new System.EventHandler(this.recalc_Exp_Btn_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(249, 187);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form8";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experimental Data Settings";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form8_DpiChanged);
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity_numUD)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label minIntensity_lbl;
        private System.Windows.Forms.NumericUpDown minIntensity_numUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selection_list_1;
        private System.Windows.Forms.RadioButton listRes_radBtn;
        private System.Windows.Forms.RadioButton constRes_radBtn;
        private System.Windows.Forms.ComboBox resolution_list_combBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save_peakBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton save_btn;
        private System.Windows.Forms.ToolStripButton recalc_Exp_Btn;
        private System.Windows.Forms.ToolStripButton recalc_peakBtn;
    }
}