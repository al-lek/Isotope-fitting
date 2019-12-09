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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.expW1_Lbl = new System.Windows.Forms.Label();
            this.expW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.expS1_Lbl = new System.Windows.Forms.Label();
            this.exp10_UD = new System.Windows.Forms.DomainUpDown();
            this.expC1_Lbl = new System.Windows.Forms.Label();
            this.exp1_Lbl = new System.Windows.Forms.Label();
            this.fit1_Lbl = new System.Windows.Forms.Label();
            this.fitC1_Lbl = new System.Windows.Forms.Label();
            this.fit10_UD = new System.Windows.Forms.DomainUpDown();
            this.fitS1_Lbl = new System.Windows.Forms.Label();
            this.fitW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.fitW1_Lbl = new System.Windows.Forms.Label();
            this.frag1_Lbl = new System.Windows.Forms.Label();
            this.frag10_UD = new System.Windows.Forms.DomainUpDown();
            this.fragS1_Lbl = new System.Windows.Forms.Label();
            this.fragW1_numUD = new System.Windows.Forms.NumericUpDown();
            this.fragW1_Lbl = new System.Windows.Forms.Label();
            this.expW1_Btn = new System.Windows.Forms.Button();
            this.fitW1_Btn = new System.Windows.Forms.Button();
            this.refresh10_Btn = new System.Windows.Forms.Button();
            this.reset_Btn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitW1_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragW1_numUD)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(295, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reset_Btn);
            this.tabPage1.Controls.Add(this.refresh10_Btn);
            this.tabPage1.Controls.Add(this.fitW1_Btn);
            this.tabPage1.Controls.Add(this.expW1_Btn);
            this.tabPage1.Controls.Add(this.frag1_Lbl);
            this.tabPage1.Controls.Add(this.frag10_UD);
            this.tabPage1.Controls.Add(this.fragS1_Lbl);
            this.tabPage1.Controls.Add(this.fragW1_numUD);
            this.tabPage1.Controls.Add(this.fragW1_Lbl);
            this.tabPage1.Controls.Add(this.fit1_Lbl);
            this.tabPage1.Controls.Add(this.fitC1_Lbl);
            this.tabPage1.Controls.Add(this.fit10_UD);
            this.tabPage1.Controls.Add(this.fitS1_Lbl);
            this.tabPage1.Controls.Add(this.fitW1_numUD);
            this.tabPage1.Controls.Add(this.fitW1_Lbl);
            this.tabPage1.Controls.Add(this.exp1_Lbl);
            this.tabPage1.Controls.Add(this.expC1_Lbl);
            this.tabPage1.Controls.Add(this.exp10_UD);
            this.tabPage1.Controls.Add(this.expS1_Lbl);
            this.tabPage1.Controls.Add(this.expW1_numUD);
            this.tabPage1.Controls.Add(this.expW1_Lbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(301, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // expW1_Lbl
            // 
            this.expW1_Lbl.AutoSize = true;
            this.expW1_Lbl.Location = new System.Drawing.Point(112, 17);
            this.expW1_Lbl.Name = "expW1_Lbl";
            this.expW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.expW1_Lbl.TabIndex = 31;
            this.expW1_Lbl.Text = "Width";
            // 
            // expW1_numUD
            // 
            this.expW1_numUD.DecimalPlaces = 1;
            this.expW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.expW1_numUD.Location = new System.Drawing.Point(154, 15);
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
            // expS1_Lbl
            // 
            this.expS1_Lbl.AutoSize = true;
            this.expS1_Lbl.Location = new System.Drawing.Point(112, 59);
            this.expS1_Lbl.Name = "expS1_Lbl";
            this.expS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.expS1_Lbl.TabIndex = 32;
            this.expS1_Lbl.Text = "Style";
            // 
            // exp10_UD
            // 
            this.exp10_UD.Items.Add("Solid");
            this.exp10_UD.Items.Add("Dot");
            this.exp10_UD.Items.Add("Dash");
            this.exp10_UD.Items.Add("LongDash");
            this.exp10_UD.Items.Add("DashDot");
            this.exp10_UD.Items.Add("LongDashDot");
            this.exp10_UD.Location = new System.Drawing.Point(154, 57);
            this.exp10_UD.Name = "exp10_UD";
            this.exp10_UD.Size = new System.Drawing.Size(120, 20);
            this.exp10_UD.TabIndex = 2;
            this.exp10_UD.SelectedItemChanged += new System.EventHandler(this.exp10_UD_SelectedItemChanged);
            // 
            // expC1_Lbl
            // 
            this.expC1_Lbl.AutoSize = true;
            this.expC1_Lbl.Location = new System.Drawing.Point(112, 101);
            this.expC1_Lbl.Name = "expC1_Lbl";
            this.expC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.expC1_Lbl.TabIndex = 33;
            this.expC1_Lbl.Text = "Color";
            // 
            // exp1_Lbl
            // 
            this.exp1_Lbl.AutoSize = true;
            this.exp1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp1_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.exp1_Lbl.Location = new System.Drawing.Point(9, 13);
            this.exp1_Lbl.Name = "exp1_Lbl";
            this.exp1_Lbl.Size = new System.Drawing.Size(101, 17);
            this.exp1_Lbl.TabIndex = 30;
            this.exp1_Lbl.Text = "Experimental";
            // 
            // fit1_Lbl
            // 
            this.fit1_Lbl.AutoSize = true;
            this.fit1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fit1_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fit1_Lbl.Location = new System.Drawing.Point(84, 142);
            this.fit1_Lbl.Name = "fit1_Lbl";
            this.fit1_Lbl.Size = new System.Drawing.Size(26, 17);
            this.fit1_Lbl.TabIndex = 34;
            this.fit1_Lbl.Text = "Fit";
            // 
            // fitC1_Lbl
            // 
            this.fitC1_Lbl.AutoSize = true;
            this.fitC1_Lbl.Location = new System.Drawing.Point(112, 230);
            this.fitC1_Lbl.Name = "fitC1_Lbl";
            this.fitC1_Lbl.Size = new System.Drawing.Size(31, 13);
            this.fitC1_Lbl.TabIndex = 37;
            this.fitC1_Lbl.Text = "Color";
            // 
            // fit10_UD
            // 
            this.fit10_UD.Items.Add("Solid");
            this.fit10_UD.Items.Add("Dot");
            this.fit10_UD.Items.Add("Dash");
            this.fit10_UD.Items.Add("LongDash");
            this.fit10_UD.Items.Add("DashDot");
            this.fit10_UD.Items.Add("LongDashDot");
            this.fit10_UD.Location = new System.Drawing.Point(154, 186);
            this.fit10_UD.Name = "fit10_UD";
            this.fit10_UD.Size = new System.Drawing.Size(120, 20);
            this.fit10_UD.TabIndex = 5;
            this.fit10_UD.SelectedItemChanged += new System.EventHandler(this.fit10_UD_SelectedItemChanged);
            // 
            // fitS1_Lbl
            // 
            this.fitS1_Lbl.AutoSize = true;
            this.fitS1_Lbl.Location = new System.Drawing.Point(112, 188);
            this.fitS1_Lbl.Name = "fitS1_Lbl";
            this.fitS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.fitS1_Lbl.TabIndex = 36;
            this.fitS1_Lbl.Text = "Style";
            // 
            // fitW1_numUD
            // 
            this.fitW1_numUD.DecimalPlaces = 1;
            this.fitW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fitW1_numUD.Location = new System.Drawing.Point(154, 144);
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
            this.fitW1_Lbl.Location = new System.Drawing.Point(112, 146);
            this.fitW1_Lbl.Name = "fitW1_Lbl";
            this.fitW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.fitW1_Lbl.TabIndex = 35;
            this.fitW1_Lbl.Text = "Width";
            // 
            // frag1_Lbl
            // 
            this.frag1_Lbl.AutoSize = true;
            this.frag1_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frag1_Lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.frag1_Lbl.Location = new System.Drawing.Point(23, 271);
            this.frag1_Lbl.Name = "frag1_Lbl";
            this.frag1_Lbl.Size = new System.Drawing.Size(84, 17);
            this.frag1_Lbl.TabIndex = 38;
            this.frag1_Lbl.Text = "Fragments";
            // 
            // frag10_UD
            // 
            this.frag10_UD.Items.Add("Solid");
            this.frag10_UD.Items.Add("Dot");
            this.frag10_UD.Items.Add("Dash");
            this.frag10_UD.Items.Add("LongDash");
            this.frag10_UD.Items.Add("DashDot");
            this.frag10_UD.Items.Add("LongDashDot");
            this.frag10_UD.Location = new System.Drawing.Point(154, 315);
            this.frag10_UD.Name = "frag10_UD";
            this.frag10_UD.Size = new System.Drawing.Size(120, 20);
            this.frag10_UD.TabIndex = 8;
            this.frag10_UD.SelectedItemChanged += new System.EventHandler(this.frag10_UD_SelectedItemChanged);
            // 
            // fragS1_Lbl
            // 
            this.fragS1_Lbl.AutoSize = true;
            this.fragS1_Lbl.Location = new System.Drawing.Point(112, 317);
            this.fragS1_Lbl.Name = "fragS1_Lbl";
            this.fragS1_Lbl.Size = new System.Drawing.Size(30, 13);
            this.fragS1_Lbl.TabIndex = 40;
            this.fragS1_Lbl.Text = "Style";
            // 
            // fragW1_numUD
            // 
            this.fragW1_numUD.DecimalPlaces = 1;
            this.fragW1_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fragW1_numUD.Location = new System.Drawing.Point(154, 273);
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
            this.fragW1_Lbl.Location = new System.Drawing.Point(112, 275);
            this.fragW1_Lbl.Name = "fragW1_Lbl";
            this.fragW1_Lbl.Size = new System.Drawing.Size(35, 13);
            this.fragW1_Lbl.TabIndex = 39;
            this.fragW1_Lbl.Text = "Width";
            // 
            // expW1_Btn
            // 
            this.expW1_Btn.Location = new System.Drawing.Point(154, 96);
            this.expW1_Btn.Name = "expW1_Btn";
            this.expW1_Btn.Size = new System.Drawing.Size(120, 20);
            this.expW1_Btn.TabIndex = 41;
            this.expW1_Btn.Text = "Set Color";
            this.expW1_Btn.UseVisualStyleBackColor = true;
            this.expW1_Btn.Click += new System.EventHandler(this.expW1_Btn_Click);
            // 
            // fitW1_Btn
            // 
            this.fitW1_Btn.Location = new System.Drawing.Point(154, 225);
            this.fitW1_Btn.Name = "fitW1_Btn";
            this.fitW1_Btn.Size = new System.Drawing.Size(120, 20);
            this.fitW1_Btn.TabIndex = 42;
            this.fitW1_Btn.Text = "Set Color";
            this.fitW1_Btn.UseVisualStyleBackColor = true;
            this.fitW1_Btn.Click += new System.EventHandler(this.fitW1_Btn_Click);
            // 
            // refresh10_Btn
            // 
            this.refresh10_Btn.Location = new System.Drawing.Point(115, 373);
            this.refresh10_Btn.Name = "refresh10_Btn";
            this.refresh10_Btn.Size = new System.Drawing.Size(159, 23);
            this.refresh10_Btn.TabIndex = 43;
            this.refresh10_Btn.Text = "Refresh Plot";
            this.refresh10_Btn.UseVisualStyleBackColor = true;
            this.refresh10_Btn.Click += new System.EventHandler(this.refresh10_Btn_Click);
            // 
            // reset_Btn
            // 
            this.reset_Btn.Location = new System.Drawing.Point(12, 373);
            this.reset_Btn.Name = "reset_Btn";
            this.reset_Btn.Size = new System.Drawing.Size(95, 23);
            this.reset_Btn.TabIndex = 44;
            this.reset_Btn.Text = "Reset";
            this.reset_Btn.UseVisualStyleBackColor = true;
            this.reset_Btn.Click += new System.EventHandler(this.reset_Btn_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 441);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form10";
            this.Text = "Format Plot Area : Style";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expW1_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitW1_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragW1_numUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label expW1_Lbl;
        private System.Windows.Forms.Label frag1_Lbl;
        private System.Windows.Forms.DomainUpDown frag10_UD;
        private System.Windows.Forms.Label fragS1_Lbl;
        private System.Windows.Forms.NumericUpDown fragW1_numUD;
        private System.Windows.Forms.Label fragW1_Lbl;
        private System.Windows.Forms.Label fit1_Lbl;
        private System.Windows.Forms.Label fitC1_Lbl;
        private System.Windows.Forms.DomainUpDown fit10_UD;
        private System.Windows.Forms.Label fitS1_Lbl;
        private System.Windows.Forms.NumericUpDown fitW1_numUD;
        private System.Windows.Forms.Label fitW1_Lbl;
        private System.Windows.Forms.Label exp1_Lbl;
        private System.Windows.Forms.Label expC1_Lbl;
        private System.Windows.Forms.DomainUpDown exp10_UD;
        private System.Windows.Forms.Label expS1_Lbl;
        private System.Windows.Forms.NumericUpDown expW1_numUD;
        private System.Windows.Forms.Button fitW1_Btn;
        private System.Windows.Forms.Button expW1_Btn;
        private System.Windows.Forms.Button refresh10_Btn;
        private System.Windows.Forms.Button reset_Btn;
    }
}