namespace Isotope_fitting
{
    partial class Form12_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12_2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refresh_Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bar_grpBox = new System.Windows.Forms.GroupBox();
            this.line_numUD = new System.Windows.Forms.NumericUpDown();
            this.line_Lbl = new System.Windows.Forms.Label();
            this.tickmark_grpBx12 = new System.Windows.Forms.GroupBox();
            this.xstepmajor_UD12 = new System.Windows.Forms.NumericUpDown();
            this.xstepminor_UD12 = new System.Windows.Forms.NumericUpDown();
            this.stepX_Lbl12 = new System.Windows.Forms.Label();
            this.x_minorGrid_UD12 = new System.Windows.Forms.DomainUpDown();
            this.x_minorGrid_Lbl12 = new System.Windows.Forms.Label();
            this.x_majorGrid_UD12 = new System.Windows.Forms.DomainUpDown();
            this.x_majorGrid_Lbl12 = new System.Windows.Forms.Label();
            this.xtickUD12 = new System.Windows.Forms.DomainUpDown();
            this.axisxtick_Lbl12 = new System.Windows.Forms.Label();
            this.units_grpBx12 = new System.Windows.Forms.GroupBox();
            this.formatY_numUD12 = new System.Windows.Forms.NumericUpDown();
            this.formatY_UD12 = new System.Windows.Forms.DomainUpDown();
            this.formatY_Lbl12 = new System.Windows.Forms.Label();
            this.yInterval_UD12 = new System.Windows.Forms.NumericUpDown();
            this.intervalY_Lbl12 = new System.Windows.Forms.Label();
            this.y_minorGrid_UD12 = new System.Windows.Forms.DomainUpDown();
            this.y_minorGrid_Lbl12 = new System.Windows.Forms.Label();
            this.y_majorGrid_UD12 = new System.Windows.Forms.DomainUpDown();
            this.y_majorGrid_Lbl12 = new System.Windows.Forms.Label();
            this.ytickUD12 = new System.Windows.Forms.DomainUpDown();
            this.axisytick_Lbl12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.bar_grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line_numUD)).BeginInit();
            this.tickmark_grpBx12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xstepmajor_UD12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xstepminor_UD12)).BeginInit();
            this.units_grpBx12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formatY_numUD12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInterval_UD12)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "S-S regions";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refresh_Btn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(502, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 74);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refresh_Btn
            // 
            this.refresh_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh_Btn.Image = ((System.Drawing.Image)(resources.GetObject("refresh_Btn.Image")));
            this.refresh_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh_Btn.Name = "refresh_Btn";
            this.refresh_Btn.Size = new System.Drawing.Size(34, 71);
            this.refresh_Btn.Text = "Refresh plot";
            this.refresh_Btn.Click += new System.EventHandler(this.refresh_Btn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(290, 31);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(37, 37);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 34);
            this.toolStripButton1.Text = "Color";
            this.toolStripButton1.Click += new System.EventHandler(this.color_Btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 21);
            this.textBox1.TabIndex = 0;
            // 
            // bar_grpBox
            // 
            this.bar_grpBox.Controls.Add(this.line_numUD);
            this.bar_grpBox.Controls.Add(this.line_Lbl);
            this.bar_grpBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar_grpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar_grpBox.ForeColor = System.Drawing.Color.SlateBlue;
            this.bar_grpBox.Location = new System.Drawing.Point(0, 0);
            this.bar_grpBox.Name = "bar_grpBox";
            this.bar_grpBox.Size = new System.Drawing.Size(290, 51);
            this.bar_grpBox.TabIndex = 7;
            this.bar_grpBox.TabStop = false;
            this.bar_grpBox.Text = "Data";
            // 
            // line_numUD
            // 
            this.line_numUD.DecimalPlaces = 1;
            this.line_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line_numUD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.line_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.line_numUD.Location = new System.Drawing.Point(137, 20);
            this.line_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.line_numUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.line_numUD.Name = "line_numUD";
            this.line_numUD.ReadOnly = true;
            this.line_numUD.Size = new System.Drawing.Size(41, 20);
            this.line_numUD.TabIndex = 26;
            this.line_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.line_numUD.ValueChanged += new System.EventHandler(this.line_numUD_ValueChanged);
            // 
            // line_Lbl
            // 
            this.line_Lbl.AutoSize = true;
            this.line_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line_Lbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.line_Lbl.Location = new System.Drawing.Point(63, 22);
            this.line_Lbl.Name = "line_Lbl";
            this.line_Lbl.Size = new System.Drawing.Size(58, 13);
            this.line_Lbl.TabIndex = 27;
            this.line_Lbl.Text = "Line Width";
            // 
            // tickmark_grpBx12
            // 
            this.tickmark_grpBx12.Controls.Add(this.xstepmajor_UD12);
            this.tickmark_grpBx12.Controls.Add(this.xstepminor_UD12);
            this.tickmark_grpBx12.Controls.Add(this.stepX_Lbl12);
            this.tickmark_grpBx12.Controls.Add(this.x_minorGrid_UD12);
            this.tickmark_grpBx12.Controls.Add(this.x_minorGrid_Lbl12);
            this.tickmark_grpBx12.Controls.Add(this.x_majorGrid_UD12);
            this.tickmark_grpBx12.Controls.Add(this.x_majorGrid_Lbl12);
            this.tickmark_grpBx12.Controls.Add(this.xtickUD12);
            this.tickmark_grpBx12.Controls.Add(this.axisxtick_Lbl12);
            this.tickmark_grpBx12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tickmark_grpBx12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickmark_grpBx12.ForeColor = System.Drawing.Color.SlateBlue;
            this.tickmark_grpBx12.Location = new System.Drawing.Point(0, 51);
            this.tickmark_grpBx12.Name = "tickmark_grpBx12";
            this.tickmark_grpBx12.Size = new System.Drawing.Size(290, 201);
            this.tickmark_grpBx12.TabIndex = 28;
            this.tickmark_grpBx12.TabStop = false;
            this.tickmark_grpBx12.Text = "Axis X";
            // 
            // xstepmajor_UD12
            // 
            this.xstepmajor_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xstepmajor_UD12.Location = new System.Drawing.Point(209, 70);
            this.xstepmajor_UD12.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.xstepmajor_UD12.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xstepmajor_UD12.Name = "xstepmajor_UD12";
            this.xstepmajor_UD12.Size = new System.Drawing.Size(48, 20);
            this.xstepmajor_UD12.TabIndex = 14;
            this.xstepmajor_UD12.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.xstepmajor_UD12.ValueChanged += new System.EventHandler(this.xstepmajor_UD12_ValueChanged);
            // 
            // xstepminor_UD12
            // 
            this.xstepminor_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xstepminor_UD12.Location = new System.Drawing.Point(137, 70);
            this.xstepminor_UD12.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.xstepminor_UD12.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xstepminor_UD12.Name = "xstepminor_UD12";
            this.xstepminor_UD12.Size = new System.Drawing.Size(48, 20);
            this.xstepminor_UD12.TabIndex = 13;
            this.xstepminor_UD12.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xstepminor_UD12.ValueChanged += new System.EventHandler(this.xstepminor_UD12_ValueChanged);
            // 
            // stepX_Lbl12
            // 
            this.stepX_Lbl12.AutoSize = true;
            this.stepX_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepX_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stepX_Lbl12.Location = new System.Drawing.Point(5, 73);
            this.stepX_Lbl12.Name = "stepX_Lbl12";
            this.stepX_Lbl12.Size = new System.Drawing.Size(116, 15);
            this.stepX_Lbl12.TabIndex = 12;
            this.stepX_Lbl12.Text = "Step (minor , major)";
            // 
            // x_minorGrid_UD12
            // 
            this.x_minorGrid_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_minorGrid_UD12.Items.Add("None");
            this.x_minorGrid_UD12.Items.Add("Solid");
            this.x_minorGrid_UD12.Location = new System.Drawing.Point(137, 144);
            this.x_minorGrid_UD12.Name = "x_minorGrid_UD12";
            this.x_minorGrid_UD12.Size = new System.Drawing.Size(120, 20);
            this.x_minorGrid_UD12.TabIndex = 11;
            this.x_minorGrid_UD12.Wrap = true;
            this.x_minorGrid_UD12.SelectedItemChanged += new System.EventHandler(this.x_minorGrid_UD12_SelectedItemChanged);
            // 
            // x_minorGrid_Lbl12
            // 
            this.x_minorGrid_Lbl12.AutoSize = true;
            this.x_minorGrid_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_minorGrid_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.x_minorGrid_Lbl12.Location = new System.Drawing.Point(36, 147);
            this.x_minorGrid_Lbl12.Name = "x_minorGrid_Lbl12";
            this.x_minorGrid_Lbl12.Size = new System.Drawing.Size(85, 15);
            this.x_minorGrid_Lbl12.TabIndex = 10;
            this.x_minorGrid_Lbl12.Text = "Minor Gridline";
            // 
            // x_majorGrid_UD12
            // 
            this.x_majorGrid_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_majorGrid_UD12.Items.Add("None");
            this.x_majorGrid_UD12.Items.Add("Solid");
            this.x_majorGrid_UD12.Location = new System.Drawing.Point(137, 107);
            this.x_majorGrid_UD12.Name = "x_majorGrid_UD12";
            this.x_majorGrid_UD12.Size = new System.Drawing.Size(120, 20);
            this.x_majorGrid_UD12.TabIndex = 9;
            this.x_majorGrid_UD12.Wrap = true;
            this.x_majorGrid_UD12.SelectedItemChanged += new System.EventHandler(this.x_majorGrid_UD12_SelectedItemChanged);
            // 
            // x_majorGrid_Lbl12
            // 
            this.x_majorGrid_Lbl12.AutoSize = true;
            this.x_majorGrid_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_majorGrid_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.x_majorGrid_Lbl12.Location = new System.Drawing.Point(36, 110);
            this.x_majorGrid_Lbl12.Name = "x_majorGrid_Lbl12";
            this.x_majorGrid_Lbl12.Size = new System.Drawing.Size(85, 15);
            this.x_majorGrid_Lbl12.TabIndex = 8;
            this.x_majorGrid_Lbl12.Text = "Major Gridline";
            // 
            // xtickUD12
            // 
            this.xtickUD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtickUD12.Items.Add("None");
            this.xtickUD12.Items.Add("Outside");
            this.xtickUD12.Items.Add("Inside");
            this.xtickUD12.Items.Add("Cross");
            this.xtickUD12.Location = new System.Drawing.Point(137, 33);
            this.xtickUD12.Name = "xtickUD12";
            this.xtickUD12.Size = new System.Drawing.Size(120, 20);
            this.xtickUD12.TabIndex = 2;
            this.xtickUD12.Wrap = true;
            this.xtickUD12.SelectedItemChanged += new System.EventHandler(this.xtickUD12_SelectedItemChanged);
            // 
            // axisxtick_Lbl12
            // 
            this.axisxtick_Lbl12.AutoSize = true;
            this.axisxtick_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisxtick_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.axisxtick_Lbl12.Location = new System.Drawing.Point(55, 36);
            this.axisxtick_Lbl12.Name = "axisxtick_Lbl12";
            this.axisxtick_Lbl12.Size = new System.Drawing.Size(66, 15);
            this.axisxtick_Lbl12.TabIndex = 0;
            this.axisxtick_Lbl12.Text = "Tick Marks";
            // 
            // units_grpBx12
            // 
            this.units_grpBx12.Controls.Add(this.formatY_numUD12);
            this.units_grpBx12.Controls.Add(this.formatY_UD12);
            this.units_grpBx12.Controls.Add(this.formatY_Lbl12);
            this.units_grpBx12.Controls.Add(this.yInterval_UD12);
            this.units_grpBx12.Controls.Add(this.intervalY_Lbl12);
            this.units_grpBx12.Controls.Add(this.y_minorGrid_UD12);
            this.units_grpBx12.Controls.Add(this.y_minorGrid_Lbl12);
            this.units_grpBx12.Controls.Add(this.y_majorGrid_UD12);
            this.units_grpBx12.Controls.Add(this.y_majorGrid_Lbl12);
            this.units_grpBx12.Controls.Add(this.ytickUD12);
            this.units_grpBx12.Controls.Add(this.axisytick_Lbl12);
            this.units_grpBx12.Dock = System.Windows.Forms.DockStyle.Right;
            this.units_grpBx12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.units_grpBx12.ForeColor = System.Drawing.Color.SlateBlue;
            this.units_grpBx12.Location = new System.Drawing.Point(290, 0);
            this.units_grpBx12.Name = "units_grpBx12";
            this.units_grpBx12.Size = new System.Drawing.Size(252, 252);
            this.units_grpBx12.TabIndex = 15;
            this.units_grpBx12.TabStop = false;
            this.units_grpBx12.Text = "Axis Y";
            // 
            // formatY_numUD12
            // 
            this.formatY_numUD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatY_numUD12.Location = new System.Drawing.Point(202, 180);
            this.formatY_numUD12.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.formatY_numUD12.Name = "formatY_numUD12";
            this.formatY_numUD12.Size = new System.Drawing.Size(32, 20);
            this.formatY_numUD12.TabIndex = 22;
            this.formatY_numUD12.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.formatY_numUD12.ValueChanged += new System.EventHandler(this.formatY_numUD12_ValueChanged);
            // 
            // formatY_UD12
            // 
            this.formatY_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatY_UD12.Items.Add("General");
            this.formatY_UD12.Items.Add("Scientific");
            this.formatY_UD12.Location = new System.Drawing.Point(114, 180);
            this.formatY_UD12.Name = "formatY_UD12";
            this.formatY_UD12.Size = new System.Drawing.Size(85, 20);
            this.formatY_UD12.TabIndex = 19;
            this.formatY_UD12.Wrap = true;
            this.formatY_UD12.SelectedItemChanged += new System.EventHandler(this.formatY_UD12_SelectedItemChanged);
            // 
            // formatY_Lbl12
            // 
            this.formatY_Lbl12.AutoSize = true;
            this.formatY_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatY_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.formatY_Lbl12.Location = new System.Drawing.Point(4, 185);
            this.formatY_Lbl12.Name = "formatY_Lbl12";
            this.formatY_Lbl12.Size = new System.Drawing.Size(94, 15);
            this.formatY_Lbl12.TabIndex = 18;
            this.formatY_Lbl12.Text = "Number Format";
            // 
            // yInterval_UD12
            // 
            this.yInterval_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yInterval_UD12.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.yInterval_UD12.Location = new System.Drawing.Point(114, 71);
            this.yInterval_UD12.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.yInterval_UD12.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.yInterval_UD12.Name = "yInterval_UD12";
            this.yInterval_UD12.Size = new System.Drawing.Size(82, 20);
            this.yInterval_UD12.TabIndex = 17;
            this.yInterval_UD12.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yInterval_UD12.ValueChanged += new System.EventHandler(this.yInterval_UD12_ValueChanged);
            // 
            // intervalY_Lbl12
            // 
            this.intervalY_Lbl12.AutoSize = true;
            this.intervalY_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalY_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.intervalY_Lbl12.Location = new System.Drawing.Point(11, 74);
            this.intervalY_Lbl12.Name = "intervalY_Lbl12";
            this.intervalY_Lbl12.Size = new System.Drawing.Size(87, 15);
            this.intervalY_Lbl12.TabIndex = 16;
            this.intervalY_Lbl12.Text = "Interval Length";
            // 
            // y_minorGrid_UD12
            // 
            this.y_minorGrid_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_minorGrid_UD12.Items.Add("None");
            this.y_minorGrid_UD12.Items.Add("Solid");
            this.y_minorGrid_UD12.Location = new System.Drawing.Point(114, 145);
            this.y_minorGrid_UD12.Name = "y_minorGrid_UD12";
            this.y_minorGrid_UD12.Size = new System.Drawing.Size(120, 20);
            this.y_minorGrid_UD12.TabIndex = 15;
            this.y_minorGrid_UD12.Wrap = true;
            this.y_minorGrid_UD12.SelectedItemChanged += new System.EventHandler(this.y_minorGrid_UD12_SelectedItemChanged);
            // 
            // y_minorGrid_Lbl12
            // 
            this.y_minorGrid_Lbl12.AutoSize = true;
            this.y_minorGrid_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_minorGrid_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.y_minorGrid_Lbl12.Location = new System.Drawing.Point(13, 148);
            this.y_minorGrid_Lbl12.Name = "y_minorGrid_Lbl12";
            this.y_minorGrid_Lbl12.Size = new System.Drawing.Size(85, 15);
            this.y_minorGrid_Lbl12.TabIndex = 14;
            this.y_minorGrid_Lbl12.Text = "Minor Gridline";
            // 
            // y_majorGrid_UD12
            // 
            this.y_majorGrid_UD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_majorGrid_UD12.Items.Add("None");
            this.y_majorGrid_UD12.Items.Add("Solid");
            this.y_majorGrid_UD12.Location = new System.Drawing.Point(114, 108);
            this.y_majorGrid_UD12.Name = "y_majorGrid_UD12";
            this.y_majorGrid_UD12.Size = new System.Drawing.Size(120, 20);
            this.y_majorGrid_UD12.TabIndex = 13;
            this.y_majorGrid_UD12.Wrap = true;
            this.y_majorGrid_UD12.SelectedItemChanged += new System.EventHandler(this.y_majorGrid_UD12_SelectedItemChanged);
            // 
            // y_majorGrid_Lbl12
            // 
            this.y_majorGrid_Lbl12.AutoSize = true;
            this.y_majorGrid_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_majorGrid_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.y_majorGrid_Lbl12.Location = new System.Drawing.Point(13, 111);
            this.y_majorGrid_Lbl12.Name = "y_majorGrid_Lbl12";
            this.y_majorGrid_Lbl12.Size = new System.Drawing.Size(85, 15);
            this.y_majorGrid_Lbl12.TabIndex = 12;
            this.y_majorGrid_Lbl12.Text = "Major Gridline";
            // 
            // ytickUD12
            // 
            this.ytickUD12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ytickUD12.Items.Add("None");
            this.ytickUD12.Items.Add("Outside");
            this.ytickUD12.Items.Add("Inside");
            this.ytickUD12.Items.Add("Cross");
            this.ytickUD12.Location = new System.Drawing.Point(114, 34);
            this.ytickUD12.Name = "ytickUD12";
            this.ytickUD12.Size = new System.Drawing.Size(120, 20);
            this.ytickUD12.TabIndex = 3;
            this.ytickUD12.Wrap = true;
            this.ytickUD12.SelectedItemChanged += new System.EventHandler(this.ytickUD12_SelectedItemChanged);
            // 
            // axisytick_Lbl12
            // 
            this.axisytick_Lbl12.AutoSize = true;
            this.axisytick_Lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.axisytick_Lbl12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.axisytick_Lbl12.Location = new System.Drawing.Point(32, 37);
            this.axisytick_Lbl12.Name = "axisytick_Lbl12";
            this.axisytick_Lbl12.Size = new System.Drawing.Size(66, 15);
            this.axisytick_Lbl12.TabIndex = 1;
            this.axisytick_Lbl12.Text = "Tick Marks";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tickmark_grpBx12);
            this.panel1.Controls.Add(this.bar_grpBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 252);
            this.panel1.TabIndex = 29;
            // 
            // Form12_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 346);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.units_grpBx12);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form12_2";
            this.Text = "Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.bar_grpBox.ResumeLayout(false);
            this.bar_grpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line_numUD)).EndInit();
            this.tickmark_grpBx12.ResumeLayout(false);
            this.tickmark_grpBx12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xstepmajor_UD12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xstepminor_UD12)).EndInit();
            this.units_grpBx12.ResumeLayout(false);
            this.units_grpBx12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formatY_numUD12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yInterval_UD12)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox bar_grpBox;
        private System.Windows.Forms.NumericUpDown line_numUD;
        private System.Windows.Forms.Label line_Lbl;
        private System.Windows.Forms.GroupBox tickmark_grpBx12;
        private System.Windows.Forms.NumericUpDown xstepmajor_UD12;
        private System.Windows.Forms.NumericUpDown xstepminor_UD12;
        private System.Windows.Forms.Label stepX_Lbl12;
        private System.Windows.Forms.DomainUpDown x_minorGrid_UD12;
        private System.Windows.Forms.Label x_minorGrid_Lbl12;
        private System.Windows.Forms.DomainUpDown x_majorGrid_UD12;
        private System.Windows.Forms.Label x_majorGrid_Lbl12;
        private System.Windows.Forms.DomainUpDown xtickUD12;
        private System.Windows.Forms.Label axisxtick_Lbl12;
        private System.Windows.Forms.GroupBox units_grpBx12;
        private System.Windows.Forms.NumericUpDown formatY_numUD12;
        private System.Windows.Forms.DomainUpDown formatY_UD12;
        private System.Windows.Forms.Label formatY_Lbl12;
        private System.Windows.Forms.NumericUpDown yInterval_UD12;
        private System.Windows.Forms.Label intervalY_Lbl12;
        private System.Windows.Forms.DomainUpDown y_minorGrid_UD12;
        private System.Windows.Forms.Label y_minorGrid_Lbl12;
        private System.Windows.Forms.DomainUpDown y_majorGrid_UD12;
        private System.Windows.Forms.Label y_majorGrid_Lbl12;
        private System.Windows.Forms.DomainUpDown ytickUD12;
        private System.Windows.Forms.Label axisytick_Lbl12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refresh_Btn;
    }
}