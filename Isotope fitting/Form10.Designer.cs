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
            this.components = new System.ComponentModel.Container();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cenW1_numUD)).BeginInit();
            this.exp1_grpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).BeginInit();
            this.Theor_grpBx.SuspendLayout();
            this.fit_grpBx.SuspendLayout();
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
            this.reset_Btn.TabIndex = 44;
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
            this.refresh10_Btn.TabIndex = 43;
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
            this.fitW1_Btn.TabIndex = 42;
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
            this.frag10_UD.TabIndex = 8;
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
            this.fragS1_Lbl.TabIndex = 40;
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
            this.fragW1_numUD.TabIndex = 7;
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
            this.fragW1_Lbl.TabIndex = 39;
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
            this.fitC1_Lbl.TabIndex = 37;
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
            this.fit10_UD.TabIndex = 5;
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
            this.fitS1_Lbl.TabIndex = 36;
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
            this.fitW1_numUD.TabIndex = 4;
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
            this.fitW1_Lbl.TabIndex = 35;
            this.fitW1_Lbl.Text = "Width";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(287, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
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
            this.cenW1_numUD.TabIndex = 51;
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
            this.cenW1_Lbl.TabIndex = 52;
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
            this.Centroids_Lbl.TabIndex = 56;
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
            this.Profile_Lbl.TabIndex = 57;
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
            this.exp1_grpBx.TabIndex = 59;
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
            this.Spectrum_Lbl.TabIndex = 70;
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
            this.Peaks_Lbl.TabIndex = 69;
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
            this.peakW1_Btn.TabIndex = 68;
            this.peakW1_Btn.Text = "Set Color";
            this.peakW1_Btn.UseVisualStyleBackColor = false;
            // 
            // peakC1_Lbl
            // 
            this.peakC1_Lbl.AutoSize = true;
            this.peakC1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakC1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakC1_Lbl.Location = new System.Drawing.Point(81, 203);
            this.peakC1_Lbl.Name = "peakC1_Lbl";
            this.peakC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.peakC1_Lbl.TabIndex = 67;
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
            this.peakW1_numUD.TabIndex = 65;
            this.peakW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // peakW1_Lbl
            // 
            this.peakW1_Lbl.AutoSize = true;
            this.peakW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peakW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peakW1_Lbl.Location = new System.Drawing.Point(77, 160);
            this.peakW1_Lbl.Name = "peakW1_Lbl";
            this.peakW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.peakW1_Lbl.TabIndex = 66;
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
            this.expW1_Btn.TabIndex = 64;
            this.expW1_Btn.Text = "Set Color";
            this.expW1_Btn.UseVisualStyleBackColor = false;
            // 
            // expC1_Lbl
            // 
            this.expC1_Lbl.AutoSize = true;
            this.expC1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expC1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expC1_Lbl.Location = new System.Drawing.Point(81, 117);
            this.expC1_Lbl.Name = "expC1_Lbl";
            this.expC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.expC1_Lbl.TabIndex = 63;
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
            this.exp10_UD.TabIndex = 60;
            // 
            // expS1_Lbl
            // 
            this.expS1_Lbl.AutoSize = true;
            this.expS1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expS1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expS1_Lbl.Location = new System.Drawing.Point(82, 74);
            this.expS1_Lbl.Name = "expS1_Lbl";
            this.expS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.expS1_Lbl.TabIndex = 62;
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
            this.expW1_numUD.TabIndex = 59;
            this.expW1_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // expW1_Lbl
            // 
            this.expW1_Lbl.AutoSize = true;
            this.expW1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expW1_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.expW1_Lbl.Location = new System.Drawing.Point(77, 31);
            this.expW1_Lbl.Name = "expW1_Lbl";
            this.expW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.expW1_Lbl.TabIndex = 61;
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
            this.Theor_grpBx.TabIndex = 60;
            this.Theor_grpBx.TabStop = false;
            this.Theor_grpBx.Text = "Theoretical Data";
            this.Theor_grpBx.Enter += new System.EventHandler(this.Theor_grpBx_Enter);
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
            this.fit_grpBx.TabIndex = 61;
            this.fit_grpBx.TabStop = false;
            this.fit_grpBx.Text = "Fit";
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
            ((System.ComponentModel.ISupportInitialize)(this.cenW1_numUD)).EndInit();
            this.exp1_grpBx.ResumeLayout(false);
            this.exp1_grpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peakW1_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).EndInit();
            this.Theor_grpBx.ResumeLayout(false);
            this.Theor_grpBx.PerformLayout();
            this.fit_grpBx.ResumeLayout(false);
            this.fit_grpBx.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip1;
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
    }
}