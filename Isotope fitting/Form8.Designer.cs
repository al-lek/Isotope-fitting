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
            this.minIntensity_lbl = new System.Windows.Forms.Label();
            this.minIntensity_numUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.listRes_radBtn = new System.Windows.Forms.RadioButton();
            this.constRes_radBtn = new System.Windows.Forms.RadioButton();
            this.resolution_list_combBox = new System.Windows.Forms.ComboBox();
            this.selection_list_1 = new System.Windows.Forms.ComboBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.save_peak_btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.recalc_Exp_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity_numUD)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            10,
            0,
            0,
            0});
            this.minIntensity_numUD.Name = "minIntensity_numUD";
            this.minIntensity_numUD.Size = new System.Drawing.Size(41, 21);
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
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.BackColor = System.Drawing.Color.Green;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.save_btn.Location = new System.Drawing.Point(160, 117);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(64, 27);
            this.save_btn.TabIndex = 23;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // save_peak_btn
            // 
            this.save_peak_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_peak_btn.BackColor = System.Drawing.Color.Green;
            this.save_peak_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_peak_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_peak_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.save_peak_btn.Location = new System.Drawing.Point(160, 117);
            this.save_peak_btn.Name = "save_peak_btn";
            this.save_peak_btn.Size = new System.Drawing.Size(64, 27);
            this.save_peak_btn.TabIndex = 24;
            this.save_peak_btn.Text = "Save";
            this.save_peak_btn.UseVisualStyleBackColor = false;
            this.save_peak_btn.Click += new System.EventHandler(this.save_peak_btn_Click);
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
            this.tabPage1.Controls.Add(this.save_peak_btn);
            this.tabPage1.Controls.Add(this.minIntensity_numUD);
            this.tabPage1.Controls.Add(this.minIntensity_lbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 161);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Peak Detection Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.recalc_Exp_Btn);
            this.tabPage2.Controls.Add(this.listRes_radBtn);
            this.tabPage2.Controls.Add(this.save_btn);
            this.tabPage2.Controls.Add(this.resolution_list_combBox);
            this.tabPage2.Controls.Add(this.constRes_radBtn);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.selection_list_1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(241, 161);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deconvoluted spectra";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // recalc_Exp_Btn
            // 
            this.recalc_Exp_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.recalc_Exp_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.recalc_Exp_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recalc_Exp_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recalc_Exp_Btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.recalc_Exp_Btn.Location = new System.Drawing.Point(8, 117);
            this.recalc_Exp_Btn.Name = "recalc_Exp_Btn";
            this.recalc_Exp_Btn.Size = new System.Drawing.Size(146, 27);
            this.recalc_Exp_Btn.TabIndex = 24;
            this.recalc_Exp_Btn.Text = "Recalculate Exp. Profile";
            this.recalc_Exp_Btn.UseVisualStyleBackColor = false;
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button save_peak_btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button recalc_Exp_Btn;
    }
}