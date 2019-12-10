namespace Isotope_fitting
{
    partial class Form10
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.refresh10_Btn = new System.Windows.Forms.Button();
            this.fitW1_Btn = new System.Windows.Forms.Button();
            this.frag10_UD = new System.Windows.Forms.DomainUpDown();
            this.fragS1_Lbl = new System.Windows.Forms.Label();
            this.fragW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.fragW1_Lbl = new System.Windows.Forms.Label();
            this.fitC1_Lbl = new System.Windows.Forms.Label();
            this.fit10_UD = new System.Windows.Forms.DomainUpDown();
            this.fitS1_Lbl = new System.Windows.Forms.Label();
            this.fitW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.fitW1_Lbl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cenW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.cenW1_Lbl = new System.Windows.Forms.Label();
            this.Centroids_Lbl = new System.Windows.Forms.Label();
            this.Profile_Lbl = new System.Windows.Forms.Label();
            this.exp1_grpBx = new System.Windows.Forms.GroupBox();
            this.Spectrum_Lbl = new System.Windows.Forms.Label();
            this.Peaks_Lbl = new System.Windows.Forms.Label();
            this.peakW1_Btn = new System.Windows.Forms.Button();
            this.peakC1_Lbl = new System.Windows.Forms.Label();
            this.peakW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.peakW1_Lbl = new System.Windows.Forms.Label();
            this.expW1_Btn = new System.Windows.Forms.Button();
            this.expC1_Lbl = new System.Windows.Forms.Label();
            this.exp10_UD = new System.Windows.Forms.DomainUpDown();
            this.expS1_Lbl = new System.Windows.Forms.Label();
            this.expW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.expW1_Lbl = new System.Windows.Forms.Label();
            this.Theor_grpBx = new System.Windows.Forms.GroupBox();
            this.fit_grpBx = new System.Windows.Forms.GroupBox();
            this.tickmark_grpBx = new System.Windows.Forms.GroupBox();
            this.axisxtick_Lbl = new System.Windows.Forms.Label();
            this.axisytick_Lbl = new System.Windows.Forms.Label();
            this.xtickUD = new System.Windows.Forms.DomainUpDown();
            this.ytickUD = new System.Windows.Forms.DomainUpDown();
            this.units_grpBx = new System.Windows.Forms.GroupBox();
            this.x_majorGrid_UD = new System.Windows.Forms.DomainUpDown();
            this.x_majorGrid_Lbl = new System.Windows.Forms.Label();
            this.x_minorGrid_Lbl = new System.Windows.Forms.Label();
            this.x_minorGrid_UD = new System.Windows.Forms.DomainUpDown();
            this.y_minorGrid_UD = new System.Windows.Forms.DomainUpDown();
            this.y_minorGrid_Lbl = new System.Windows.Forms.Label();
            this.y_majorGrid_UD = new System.Windows.Forms.DomainUpDown();
            this.y_majorGrid_Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xInterval_UD = new System.Windows.Forms.NumericUpDown();
            this.yInterval_UD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitW1_numUD)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cenW1_numUD)).BeginInit();
            this.exp1_grpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).BeginInit();
            this.Theor_grpBx.SuspendLayout();
            this.fit_grpBx.SuspendLayout();
            this.tickmark_grpBx.SuspendLayout();
            this.units_grpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xInterval_UD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInterval_UD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 290);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fit_grpBx);
            this.tabPage1.Controls.Add(this.Theor_grpBx);
            this.tabPage1.Controls.Add(this.exp1_grpBx);
            this.tabPage1.Controls.Add(this.reset_Btn);
            this.tabPage1.Controls.Add(this.refresh10_Btn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reset_Btn
            // 
            this.reset_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reset_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_Btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.reset_Btn.Location = new System.Drawing.Point(279, 219);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(257, 34);
            this.reset_Btn.TabIndex = 13;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // refresh10_Btn
            // 
            this.refresh10_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh10_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh10_Btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.refresh10_Btn.Location = new System.Drawing.Point(555, 219);
            this.refresh10_Btn.Name = "refresh10_Btn";
            this.refresh10_Btn.Size = new System.Drawing.Size(257, 34);
            this.refresh10_Btn.TabIndex = 12;
            this.refresh10_Btn.Text = "Refresh Plot";
            this.refresh10_Btn.UseVisualStyleBackColor = true;
            this.refresh10_Btn.Click += new System.EventHandler(this.refresh10_Btn_Click);
            // 
            // fitW1_Btn
            // 
            this.fitW1_Btn.BackColor = System.Drawing.Color.Lavender;
            this.fitW1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fitW1_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitW1_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fitW1_Btn.Location = new System.Drawing.Point(116, 107);
            this.fitW1_Btn.Name = "fitW1_Btn";
            this.fitW1_Btn.Size = new System.Drawing.Size(120, 20);
            this.fitW1_Btn.TabIndex = 11;
            this.fitW1_Btn.Text = "Set Color";
            this.fitW1_Btn.UseVisualStyleBackColor = false;
            this.fitW1_Btn.Click += new System.EventHandler(this.fitW1_Btn_Click);
            // 
            // frag10_UD
            // 
            this.frag10_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frag10_UD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frag10_UD.Items.Add("Solid");
            this.frag10_UD.Items.Add("Dot");
            this.frag10_UD.Items.Add("Dash");
            this.frag10_UD.Items.Add("LongDash");
            this.frag10_UD.Items.Add("DashDot");
            this.frag10_UD.Items.Add("LongDashDot");
            this.frag10_UD.Location = new System.Drawing.Point(119, 70);
            this.frag10_UD.Name = "frag10_UD";
            this.frag10_UD.Size = new System.Drawing.Size(120, 20);
            this.frag10_UD.TabIndex = 7;
            this.frag10_UD.SelectedItemChanged += new System.EventHandler(this.frag10_UD_SelectedItemChanged);
            // 
            // fragS1_Lbl
            // 
            this.fragS1_Lbl.AutoSize = true;
            this.fragS1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragS1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fragS1_Lbl.Location = new System.Drawing.Point(80, 74);
            this.fragS1_Lbl.Name = "fragS1_Lbl";
            this.fragS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.fragS1_Lbl.TabIndex = 29;
            this.fragS1_Lbl.Text = "Style";
            // 
            // fragW1_numUD
            // 
            this.fragW1_numUD.DecimalPlaces = 1;
            this.fragW1_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragW1_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fragW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fragW1_numUD.Location = new System.Drawing.Point(119, 27);
            this.fragW1_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fragW1_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fragW1_numUD.Name = "fragW1_numUD";
            this.fragW1_numUD.ReadOnly = true;
            this.fragW1_numUD.Size = new System.Drawing.Size(41, 20);
            this.fragW1_numUD.TabIndex = 6;
            this.fragW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fragW1_numUD.ValueChanged += new System.EventHandler(this.fragW1_numUD_ValueChanged);
            // 
            // fragW1_Lbl
            // 
            this.fragW1_Lbl.AutoSize = true;
            this.fragW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fragW1_Lbl.Location = new System.Drawing.Point(75, 31);
            this.fragW1_Lbl.Name = "fragW1_Lbl";
            this.fragW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.fragW1_Lbl.TabIndex = 28;
            this.fragW1_Lbl.Text = "Width";
            // 
            // fitC1_Lbl
            // 
            this.fitC1_Lbl.AutoSize = true;
            this.fitC1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitC1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fitC1_Lbl.Location = new System.Drawing.Point(74, 110);
            this.fitC1_Lbl.Name = "fitC1_Lbl";
            this.fitC1_Lbl.Size = new System.Drawing.Size(36, 15);
            this.fitC1_Lbl.TabIndex = 34;
            this.fitC1_Lbl.Text = "Color";
            // 
            // fit10_UD
            // 
            this.fit10_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit10_UD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fit10_UD.Items.Add("Solid");
            this.fit10_UD.Items.Add("Dot");
            this.fit10_UD.Items.Add("Dash");
            this.fit10_UD.Items.Add("LongDash");
            this.fit10_UD.Items.Add("DashDot");
            this.fit10_UD.Items.Add("LongDashDot");
            this.fit10_UD.Location = new System.Drawing.Point(116, 64);
            this.fit10_UD.Name = "fit10_UD";
            this.fit10_UD.Size = new System.Drawing.Size(120, 20);
            this.fit10_UD.TabIndex = 10;
            this.fit10_UD.SelectedItemChanged += new System.EventHandler(this.fit10_UD_SelectedItemChanged);
            // 
            // fitS1_Lbl
            // 
            this.fitS1_Lbl.AutoSize = true;
            this.fitS1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitS1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fitS1_Lbl.Location = new System.Drawing.Point(77, 67);
            this.fitS1_Lbl.Name = "fitS1_Lbl";
            this.fitS1_Lbl.Size = new System.Drawing.Size(33, 15);
            this.fitS1_Lbl.TabIndex = 33;
            this.fitS1_Lbl.Text = "Style";
            // 
            // fitW1_numUD
            // 
            this.fitW1_numUD.DecimalPlaces = 1;
            this.fitW1_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitW1_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fitW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fitW1_numUD.Location = new System.Drawing.Point(116, 21);
            this.fitW1_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fitW1_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fitW1_numUD.Name = "fitW1_numUD";
            this.fitW1_numUD.ReadOnly = true;
            this.fitW1_numUD.Size = new System.Drawing.Size(41, 20);
            this.fitW1_numUD.TabIndex = 9;
            this.fitW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fitW1_numUD.ValueChanged += new System.EventHandler(this.fitW1_numUD_ValueChanged);
            // 
            // fitW1_Lbl
            // 
            this.fitW1_Lbl.AutoSize = true;
            this.fitW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fitW1_Lbl.Location = new System.Drawing.Point(72, 24);
            this.fitW1_Lbl.Name = "fitW1_Lbl";
            this.fitW1_Lbl.Size = new System.Drawing.Size(38, 15);
            this.fitW1_Lbl.TabIndex = 32;
            this.fitW1_Lbl.Text = "Width";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.units_grpBx);
            this.tabPage2.Controls.Add(this.tickmark_grpBx);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Axis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cenW1_numUD
            // 
            this.cenW1_numUD.DecimalPlaces = 1;
            this.cenW1_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cenW1_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cenW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.cenW1_numUD.Location = new System.Drawing.Point(119, 113);
            this.cenW1_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cenW1_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.cenW1_numUD.Name = "cenW1_numUD";
            this.cenW1_numUD.ReadOnly = true;
            this.cenW1_numUD.Size = new System.Drawing.Size(41, 20);
            this.cenW1_numUD.TabIndex = 8;
            this.cenW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cenW1_numUD.ValueChanged += new System.EventHandler(this.cenW1_numUD_ValueChanged);
            // 
            // cenW1_Lbl
            // 
            this.cenW1_Lbl.AutoSize = true;
            this.cenW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cenW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cenW1_Lbl.Location = new System.Drawing.Point(75, 117);
            this.cenW1_Lbl.Name = "cenW1_Lbl";
            this.cenW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.cenW1_Lbl.TabIndex = 31;
            this.cenW1_Lbl.Text = "Width";
            // 
            // Centroids_Lbl
            // 
            this.Centroids_Lbl.AutoSize = true;
            this.Centroids_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Centroids_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Centroids_Lbl.Location = new System.Drawing.Point(10, 115);
            this.Centroids_Lbl.Name = "Centroids_Lbl";
            this.Centroids_Lbl.Size = new System.Drawing.Size(59, 15);
            this.Centroids_Lbl.TabIndex = 30;
            this.Centroids_Lbl.Text = "Centroids";
            // 
            // Profile_Lbl
            // 
            this.Profile_Lbl.AutoSize = true;
            this.Profile_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profile_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Profile_Lbl.Location = new System.Drawing.Point(27, 29);
            this.Profile_Lbl.Name = "Profile_Lbl";
            this.Profile_Lbl.Size = new System.Drawing.Size(42, 15);
            this.Profile_Lbl.TabIndex = 27;
            this.Profile_Lbl.Text = "Profile";
            // 
            // exp1_grpBx
            // 
            this.exp1_grpBx.Controls.Add(this.Spectrum_Lbl);
            this.exp1_grpBx.Controls.Add(this.Peaks_Lbl);
            this.exp1_grpBx.Controls.Add(this.peakW1_Btn);
            this.exp1_grpBx.Controls.Add(this.peakC1_Lbl);
            this.exp1_grpBx.Controls.Add(this.peakW1_numUD);
            this.exp1_grpBx.Controls.Add(this.peakW1_Lbl);
            this.exp1_grpBx.Controls.Add(this.expW1_Btn);
            this.exp1_grpBx.Controls.Add(this.expC1_Lbl);
            this.exp1_grpBx.Controls.Add(this.exp10_UD);
            this.exp1_grpBx.Controls.Add(this.expS1_Lbl);
            this.exp1_grpBx.Controls.Add(this.expW1_numUD);
            this.exp1_grpBx.Controls.Add(this.expW1_Lbl);
            this.exp1_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp1_grpBx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.exp1_grpBx.Location = new System.Drawing.Point(3, 16);
            this.exp1_grpBx.Name = "exp1_grpBx";
            this.exp1_grpBx.Size = new System.Drawing.Size(257, 237);
            this.exp1_grpBx.TabIndex = 0;
            this.exp1_grpBx.TabStop = false;
            this.exp1_grpBx.Text = "Experimental Data";
            // 
            // Spectrum_Lbl
            // 
            this.Spectrum_Lbl.AutoSize = true;
            this.Spectrum_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spectrum_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Spectrum_Lbl.Location = new System.Drawing.Point(11, 29);
            this.Spectrum_Lbl.Name = "Spectrum_Lbl";
            this.Spectrum_Lbl.Size = new System.Drawing.Size(60, 15);
            this.Spectrum_Lbl.TabIndex = 20;
            this.Spectrum_Lbl.Text = "Spectrum";
            // 
            // Peaks_Lbl
            // 
            this.Peaks_Lbl.AutoSize = true;
            this.Peaks_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Peaks_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Peaks_Lbl.Location = new System.Drawing.Point(30, 158);
            this.Peaks_Lbl.Name = "Peaks_Lbl";
            this.Peaks_Lbl.Size = new System.Drawing.Size(41, 15);
            this.Peaks_Lbl.TabIndex = 24;
            this.Peaks_Lbl.Text = "Peaks";
            // 
            // peakW1_Btn
            // 
            this.peakW1_Btn.BackColor = System.Drawing.Color.Lavender;
            this.peakW1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.peakW1_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakW1_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakW1_Btn.Location = new System.Drawing.Point(121, 199);
            this.peakW1_Btn.Name = "peakW1_Btn";
            this.peakW1_Btn.Size = new System.Drawing.Size(120, 20);
            this.peakW1_Btn.TabIndex = 5;
            this.peakW1_Btn.Text = "Set Color";
            this.peakW1_Btn.UseVisualStyleBackColor = false;
            this.peakW1_Btn.Click += new System.EventHandler(this.peakW1_Btn_Click);
            // 
            // peakC1_Lbl
            // 
            this.peakC1_Lbl.AutoSize = true;
            this.peakC1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakC1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakC1_Lbl.Location = new System.Drawing.Point(81, 203);
            this.peakC1_Lbl.Name = "peakC1_Lbl";
            this.peakC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.peakC1_Lbl.TabIndex = 26;
            this.peakC1_Lbl.Text = "Color";
            // 
            // peakW1_numUD
            // 
            this.peakW1_numUD.DecimalPlaces = 1;
            this.peakW1_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakW1_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.peakW1_numUD.Location = new System.Drawing.Point(121, 156);
            this.peakW1_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.peakW1_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.peakW1_numUD.Name = "peakW1_numUD";
            this.peakW1_numUD.ReadOnly = true;
            this.peakW1_numUD.Size = new System.Drawing.Size(41, 20);
            this.peakW1_numUD.TabIndex = 4;
            this.peakW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.peakW1_numUD.ValueChanged += new System.EventHandler(this.peakW1_numUD_ValueChanged);
            // 
            // peakW1_Lbl
            // 
            this.peakW1_Lbl.AutoSize = true;
            this.peakW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakW1_Lbl.Location = new System.Drawing.Point(77, 160);
            this.peakW1_Lbl.Name = "peakW1_Lbl";
            this.peakW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.peakW1_Lbl.TabIndex = 25;
            this.peakW1_Lbl.Text = "Width";
            // 
            // expW1_Btn
            // 
            this.expW1_Btn.BackColor = System.Drawing.Color.Lavender;
            this.expW1_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.expW1_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expW1_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expW1_Btn.Location = new System.Drawing.Point(121, 113);
            this.expW1_Btn.Name = "expW1_Btn";
            this.expW1_Btn.Size = new System.Drawing.Size(120, 20);
            this.expW1_Btn.TabIndex = 3;
            this.expW1_Btn.Text = "Set Color";
            this.expW1_Btn.UseVisualStyleBackColor = false;
            this.expW1_Btn.Click += new System.EventHandler(this.expW1_Btn_Click);
            // 
            // expC1_Lbl
            // 
            this.expC1_Lbl.AutoSize = true;
            this.expC1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expC1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expC1_Lbl.Location = new System.Drawing.Point(81, 117);
            this.expC1_Lbl.Name = "expC1_Lbl";
            this.expC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.expC1_Lbl.TabIndex = 23;
            this.expC1_Lbl.Text = "Color";
            // 
            // exp10_UD
            // 
            this.exp10_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp10_UD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exp10_UD.Items.Add("Solid");
            this.exp10_UD.Items.Add("Dot");
            this.exp10_UD.Items.Add("Dash");
            this.exp10_UD.Items.Add("LongDash");
            this.exp10_UD.Items.Add("DashDot");
            this.exp10_UD.Items.Add("LongDashDot");
            this.exp10_UD.Location = new System.Drawing.Point(121, 70);
            this.exp10_UD.Name = "exp10_UD";
            this.exp10_UD.Size = new System.Drawing.Size(120, 20);
            this.exp10_UD.TabIndex = 2;
            this.exp10_UD.SelectedItemChanged += new System.EventHandler(this.exp10_UD_SelectedItemChanged);
            // 
            // expS1_Lbl
            // 
            this.expS1_Lbl.AutoSize = true;
            this.expS1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expS1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expS1_Lbl.Location = new System.Drawing.Point(82, 74);
            this.expS1_Lbl.Name = "expS1_Lbl";
            this.expS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.expS1_Lbl.TabIndex = 22;
            this.expS1_Lbl.Text = "Style";
            // 
            // expW1_numUD
            // 
            this.expW1_numUD.DecimalPlaces = 1;
            this.expW1_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expW1_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.expW1_numUD.Location = new System.Drawing.Point(121, 27);
            this.expW1_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.expW1_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.expW1_numUD.Name = "expW1_numUD";
            this.expW1_numUD.ReadOnly = true;
            this.expW1_numUD.Size = new System.Drawing.Size(41, 20);
            this.expW1_numUD.TabIndex = 1;
            this.expW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.expW1_numUD.ValueChanged += new System.EventHandler(this.expW1_numUD_ValueChanged);
            // 
            // expW1_Lbl
            // 
            this.expW1_Lbl.AutoSize = true;
            this.expW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expW1_Lbl.Location = new System.Drawing.Point(77, 31);
            this.expW1_Lbl.Name = "expW1_Lbl";
            this.expW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.expW1_Lbl.TabIndex = 21;
            this.expW1_Lbl.Text = "Width";
            // 
            // Theor_grpBx
            // 
            this.Theor_grpBx.Controls.Add(this.frag10_UD);
            this.Theor_grpBx.Controls.Add(this.fragW1_Lbl);
            this.Theor_grpBx.Controls.Add(this.Profile_Lbl);
            this.Theor_grpBx.Controls.Add(this.fragW1_numUD);
            this.Theor_grpBx.Controls.Add(this.Centroids_Lbl);
            this.Theor_grpBx.Controls.Add(this.fragS1_Lbl);
            this.Theor_grpBx.Controls.Add(this.cenW1_numUD);
            this.Theor_grpBx.Controls.Add(this.cenW1_Lbl);
            this.Theor_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theor_grpBx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Theor_grpBx.Location = new System.Drawing.Point(279, 16);
            this.Theor_grpBx.Name = "Theor_grpBx";
            this.Theor_grpBx.Size = new System.Drawing.Size(257, 144);
            this.Theor_grpBx.TabIndex = 1;
            this.Theor_grpBx.TabStop = false;
            this.Theor_grpBx.Text = "Theoretical Data";
            // 
            // fit_grpBx
            // 
            this.fit_grpBx.Controls.Add(this.fitW1_Lbl);
            this.fit_grpBx.Controls.Add(this.fitW1_numUD);
            this.fit_grpBx.Controls.Add(this.fitS1_Lbl);
            this.fit_grpBx.Controls.Add(this.fit10_UD);
            this.fit_grpBx.Controls.Add(this.fitC1_Lbl);
            this.fit_grpBx.Controls.Add(this.fitW1_Btn);
            this.fit_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit_grpBx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fit_grpBx.Location = new System.Drawing.Point(555, 16);
            this.fit_grpBx.Name = "fit_grpBx";
            this.fit_grpBx.Size = new System.Drawing.Size(257, 144);
            this.fit_grpBx.TabIndex = 2;
            this.fit_grpBx.TabStop = false;
            this.fit_grpBx.Text = "Fit";
            // 
            // tickmark_grpBx
            // 
            this.tickmark_grpBx.Controls.Add(this.xInterval_UD);
            this.tickmark_grpBx.Controls.Add(this.label1);
            this.tickmark_grpBx.Controls.Add(this.x_minorGrid_UD);
            this.tickmark_grpBx.Controls.Add(this.x_minorGrid_Lbl);
            this.tickmark_grpBx.Controls.Add(this.x_majorGrid_UD);
            this.tickmark_grpBx.Controls.Add(this.x_majorGrid_Lbl);
            this.tickmark_grpBx.Controls.Add(this.xtickUD);
            this.tickmark_grpBx.Controls.Add(this.axisxtick_Lbl);
            this.tickmark_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickmark_grpBx.ForeColor = System.Drawing.Color.SlateBlue;
            this.tickmark_grpBx.Location = new System.Drawing.Point(8, 17);
            this.tickmark_grpBx.Name = "tickmark_grpBx";
            this.tickmark_grpBx.Size = new System.Drawing.Size(252, 198);
            this.tickmark_grpBx.TabIndex = 0;
            this.tickmark_grpBx.TabStop = false;
            this.tickmark_grpBx.Text = "Axis X";
            // 
            // axisxtick_Lbl
            // 
            this.axisxtick_Lbl.AutoSize = true;
            this.axisxtick_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisxtick_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.axisxtick_Lbl.Location = new System.Drawing.Point(28, 37);
            this.axisxtick_Lbl.Name = "axisxtick_Lbl";
            this.axisxtick_Lbl.Size = new System.Drawing.Size(66, 15);
            this.axisxtick_Lbl.TabIndex = 0;
            this.axisxtick_Lbl.Text = "Tick Marks";
            // 
            // axisytick_Lbl
            // 
            this.axisytick_Lbl.AutoSize = true;
            this.axisytick_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisytick_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.axisytick_Lbl.Location = new System.Drawing.Point(24, 37);
            this.axisytick_Lbl.Name = "axisytick_Lbl";
            this.axisytick_Lbl.Size = new System.Drawing.Size(66, 15);
            this.axisytick_Lbl.TabIndex = 1;
            this.axisytick_Lbl.Text = "Tick Marks";
            // 
            // xtickUD
            // 
            this.xtickUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtickUD.Items.Add("None");
            this.xtickUD.Items.Add("Outside");
            this.xtickUD.Items.Add("Inside");
            this.xtickUD.Items.Add("Cross");
            this.xtickUD.Location = new System.Drawing.Point(110, 34);
            this.xtickUD.Name = "xtickUD";
            this.xtickUD.Size = new System.Drawing.Size(120, 20);
            this.xtickUD.TabIndex = 2;
            this.xtickUD.SelectedItemChanged += new System.EventHandler(this.axisxtickUD_SelectedItemChanged);
            // 
            // ytickUD
            // 
            this.ytickUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytickUD.Items.Add("None");
            this.ytickUD.Items.Add("Outside");
            this.ytickUD.Items.Add("Inside");
            this.ytickUD.Items.Add("Cross");
            this.ytickUD.Location = new System.Drawing.Point(106, 34);
            this.ytickUD.Name = "ytickUD";
            this.ytickUD.Size = new System.Drawing.Size(120, 20);
            this.ytickUD.TabIndex = 3;
            this.ytickUD.SelectedItemChanged += new System.EventHandler(this.axisytickUD_SelectedItemChanged);
            // 
            // units_grpBx
            // 
            this.units_grpBx.Controls.Add(this.yInterval_UD);
            this.units_grpBx.Controls.Add(this.label2);
            this.units_grpBx.Controls.Add(this.y_minorGrid_UD);
            this.units_grpBx.Controls.Add(this.y_minorGrid_Lbl);
            this.units_grpBx.Controls.Add(this.y_majorGrid_UD);
            this.units_grpBx.Controls.Add(this.y_majorGrid_Lbl);
            this.units_grpBx.Controls.Add(this.ytickUD);
            this.units_grpBx.Controls.Add(this.axisytick_Lbl);
            this.units_grpBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.units_grpBx.ForeColor = System.Drawing.Color.SlateBlue;
            this.units_grpBx.Location = new System.Drawing.Point(275, 17);
            this.units_grpBx.Name = "units_grpBx";
            this.units_grpBx.Size = new System.Drawing.Size(252, 198);
            this.units_grpBx.TabIndex = 1;
            this.units_grpBx.TabStop = false;
            this.units_grpBx.Text = "Axis Y";
            // 
            // x_majorGrid_UD
            // 
            this.x_majorGrid_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_majorGrid_UD.Items.Add("None");
            this.x_majorGrid_UD.Items.Add("Solid");
            this.x_majorGrid_UD.Location = new System.Drawing.Point(110, 106);
            this.x_majorGrid_UD.Name = "x_majorGrid_UD";
            this.x_majorGrid_UD.Size = new System.Drawing.Size(120, 20);
            this.x_majorGrid_UD.TabIndex = 9;
            this.x_majorGrid_UD.SelectedItemChanged += new System.EventHandler(this.x_majorGrid_UD_SelectedItemChanged);
            // 
            // x_majorGrid_Lbl
            // 
            this.x_majorGrid_Lbl.AutoSize = true;
            this.x_majorGrid_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_majorGrid_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.x_majorGrid_Lbl.Location = new System.Drawing.Point(9, 109);
            this.x_majorGrid_Lbl.Name = "x_majorGrid_Lbl";
            this.x_majorGrid_Lbl.Size = new System.Drawing.Size(85, 15);
            this.x_majorGrid_Lbl.TabIndex = 8;
            this.x_majorGrid_Lbl.Text = "Major Gridline";
            // 
            // x_minorGrid_Lbl
            // 
            this.x_minorGrid_Lbl.AutoSize = true;
            this.x_minorGrid_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_minorGrid_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.x_minorGrid_Lbl.Location = new System.Drawing.Point(9, 145);
            this.x_minorGrid_Lbl.Name = "x_minorGrid_Lbl";
            this.x_minorGrid_Lbl.Size = new System.Drawing.Size(85, 15);
            this.x_minorGrid_Lbl.TabIndex = 10;
            this.x_minorGrid_Lbl.Text = "Minor Gridline";
            // 
            // x_minorGrid_UD
            // 
            this.x_minorGrid_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_minorGrid_UD.Items.Add("None");
            this.x_minorGrid_UD.Items.Add("Solid");
            this.x_minorGrid_UD.Location = new System.Drawing.Point(110, 142);
            this.x_minorGrid_UD.Name = "x_minorGrid_UD";
            this.x_minorGrid_UD.Size = new System.Drawing.Size(120, 20);
            this.x_minorGrid_UD.TabIndex = 11;
            this.x_minorGrid_UD.SelectedItemChanged += new System.EventHandler(this.x_minorGrid_UD_SelectedItemChanged);
            // 
            // y_minorGrid_UD
            // 
            this.y_minorGrid_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_minorGrid_UD.Items.Add("None");
            this.y_minorGrid_UD.Items.Add("Solid");
            this.y_minorGrid_UD.Location = new System.Drawing.Point(106, 142);
            this.y_minorGrid_UD.Name = "y_minorGrid_UD";
            this.y_minorGrid_UD.Size = new System.Drawing.Size(120, 20);
            this.y_minorGrid_UD.TabIndex = 15;
            this.y_minorGrid_UD.SelectedItemChanged += new System.EventHandler(this.y_minorGrid_UD_SelectedItemChanged);
            // 
            // y_minorGrid_Lbl
            // 
            this.y_minorGrid_Lbl.AutoSize = true;
            this.y_minorGrid_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_minorGrid_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.y_minorGrid_Lbl.Location = new System.Drawing.Point(5, 145);
            this.y_minorGrid_Lbl.Name = "y_minorGrid_Lbl";
            this.y_minorGrid_Lbl.Size = new System.Drawing.Size(85, 15);
            this.y_minorGrid_Lbl.TabIndex = 14;
            this.y_minorGrid_Lbl.Text = "Minor Gridline";
            // 
            // y_majorGrid_UD
            // 
            this.y_majorGrid_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_majorGrid_UD.Items.Add("None");
            this.y_majorGrid_UD.Items.Add("Solid");
            this.y_majorGrid_UD.Location = new System.Drawing.Point(106, 106);
            this.y_majorGrid_UD.Name = "y_majorGrid_UD";
            this.y_majorGrid_UD.Size = new System.Drawing.Size(120, 20);
            this.y_majorGrid_UD.TabIndex = 13;
            this.y_majorGrid_UD.SelectedItemChanged += new System.EventHandler(this.y_majorGrid_UD_SelectedItemChanged);
            // 
            // y_majorGrid_Lbl
            // 
            this.y_majorGrid_Lbl.AutoSize = true;
            this.y_majorGrid_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_majorGrid_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.y_majorGrid_Lbl.Location = new System.Drawing.Point(5, 109);
            this.y_majorGrid_Lbl.Name = "y_majorGrid_Lbl";
            this.y_majorGrid_Lbl.Size = new System.Drawing.Size(85, 15);
            this.y_majorGrid_Lbl.TabIndex = 12;
            this.y_majorGrid_Lbl.Text = "Major Gridline";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Interval Length";
            // 
            // xInterval_UD
            // 
            this.xInterval_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xInterval_UD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.xInterval_UD.Location = new System.Drawing.Point(110, 70);
            this.xInterval_UD.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.xInterval_UD.Name = "xInterval_UD";
            this.xInterval_UD.Size = new System.Drawing.Size(82, 20);
            this.xInterval_UD.TabIndex = 13;
            this.xInterval_UD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.xInterval_UD.ValueChanged += new System.EventHandler(this.xInterval_UD_ValueChanged);
            // 
            // yInterval_UD
            // 
            this.yInterval_UD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yInterval_UD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yInterval_UD.Location = new System.Drawing.Point(106, 70);
            this.yInterval_UD.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.yInterval_UD.Name = "yInterval_UD";
            this.yInterval_UD.Size = new System.Drawing.Size(82, 20);
            this.yInterval_UD.TabIndex = 17;
            this.yInterval_UD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.yInterval_UD.ValueChanged += new System.EventHandler(this.yInterval_UD_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Interval Length";
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(831, 290);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form10";
            this.Text = "Format Plot Area : Style";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fragW1_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitW1_numUD)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cenW1_numUD)).EndInit();
            this.exp1_grpBx.ResumeLayout(false);
            this.exp1_grpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakW1_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).EndInit();
            this.Theor_grpBx.ResumeLayout(false);
            this.Theor_grpBx.PerformLayout();
            this.fit_grpBx.ResumeLayout(false);
            this.fit_grpBx.PerformLayout();
            this.tickmark_grpBx.ResumeLayout(false);
            this.tickmark_grpBx.PerformLayout();
            this.units_grpBx.ResumeLayout(false);
            this.units_grpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xInterval_UD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInterval_UD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DomainUpDown frag10_UD;
        private System.Windows.Forms.Label fragS1_Lbl;
        private System.Windows.Forms.NumericUpDown fragW1_numUD;
        private System.Windows.Forms.Label fragW1_Lbl;
        private System.Windows.Forms.Label fitC1_Lbl;
        private System.Windows.Forms.DomainUpDown fit10_UD;
        private System.Windows.Forms.Label fitS1_Lbl;
        private System.Windows.Forms.NumericUpDown fitW1_numUD;
        private System.Windows.Forms.Label fitW1_Lbl;
        private System.Windows.Forms.Button fitW1_Btn;
        private System.Windows.Forms.Button refresh10_Btn;
        private System.Windows.Forms.Button reset_Btn;
        private System.Windows.Forms.Label Centroids_Lbl;
        private System.Windows.Forms.NumericUpDown cenW1_numUD;
        private System.Windows.Forms.Label cenW1_Lbl;
        private System.Windows.Forms.GroupBox fit_grpBx;
        private System.Windows.Forms.GroupBox Theor_grpBx;
        private System.Windows.Forms.Label Profile_Lbl;
        private System.Windows.Forms.GroupBox exp1_grpBx;
        private System.Windows.Forms.Label Spectrum_Lbl;
        private System.Windows.Forms.Label Peaks_Lbl;
        private System.Windows.Forms.Button peakW1_Btn;
        private System.Windows.Forms.Label peakC1_Lbl;
        private System.Windows.Forms.NumericUpDown peakW1_numUD;
        private System.Windows.Forms.Label peakW1_Lbl;
        private System.Windows.Forms.Button expW1_Btn;
        private System.Windows.Forms.Label expC1_Lbl;
        private System.Windows.Forms.DomainUpDown exp10_UD;
        private System.Windows.Forms.Label expS1_Lbl;
        private System.Windows.Forms.NumericUpDown expW1_numUD;
        private System.Windows.Forms.Label expW1_Lbl;
        private System.Windows.Forms.GroupBox units_grpBx;
        private System.Windows.Forms.GroupBox tickmark_grpBx;
        private System.Windows.Forms.DomainUpDown ytickUD;
        private System.Windows.Forms.DomainUpDown xtickUD;
        private System.Windows.Forms.Label axisytick_Lbl;
        private System.Windows.Forms.Label axisxtick_Lbl;
        private System.Windows.Forms.DomainUpDown y_minorGrid_UD;
        private System.Windows.Forms.Label y_minorGrid_Lbl;
        private System.Windows.Forms.DomainUpDown y_majorGrid_UD;
        private System.Windows.Forms.Label y_majorGrid_Lbl;
        private System.Windows.Forms.DomainUpDown x_minorGrid_UD;
        private System.Windows.Forms.Label x_minorGrid_Lbl;
        private System.Windows.Forms.DomainUpDown x_majorGrid_UD;
        private System.Windows.Forms.Label x_majorGrid_Lbl;
        private System.Windows.Forms.NumericUpDown yInterval_UD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown xInterval_UD;
        private System.Windows.Forms.Label label1;
    }
}