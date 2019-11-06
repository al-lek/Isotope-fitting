namespace Isotope_fitting
{
    partial class Form6
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
            this.Ai_checkBox = new System.Windows.Forms.CheckBox();
            this.A_checkBox = new System.Windows.Forms.CheckBox();
            this.di_checkBox = new System.Windows.Forms.CheckBox();
            this.labelA = new System.Windows.Forms.Label();
            this.labelAi = new System.Windows.Forms.Label();
            this.Ai_coef_numUD = new System.Windows.Forms.NumericUpDown();
            this.A_coef_numUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjLbl = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ai_numUD = new System.Windows.Forms.NumericUpDown();
            this.di_numUD = new System.Windows.Forms.NumericUpDown();
            this.A_numUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Ai_coef_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_coef_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ai_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.di_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // Ai_checkBox
            // 
            this.Ai_checkBox.AutoSize = true;
            this.Ai_checkBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Ai_checkBox.Location = new System.Drawing.Point(10, 198);
            this.Ai_checkBox.Name = "Ai_checkBox";
            this.Ai_checkBox.Size = new System.Drawing.Size(36, 19);
            this.Ai_checkBox.TabIndex = 0;
            this.Ai_checkBox.Text = "Ai";
            this.Ai_checkBox.UseVisualStyleBackColor = true;
            this.Ai_checkBox.CheckedChanged += new System.EventHandler(this.Ai_checkBox_CheckedChanged);
            // 
            // A_checkBox
            // 
            this.A_checkBox.AutoSize = true;
            this.A_checkBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.A_checkBox.Location = new System.Drawing.Point(10, 223);
            this.A_checkBox.Name = "A_checkBox";
            this.A_checkBox.Size = new System.Drawing.Size(33, 19);
            this.A_checkBox.TabIndex = 1;
            this.A_checkBox.Text = "A";
            this.A_checkBox.UseVisualStyleBackColor = true;
            this.A_checkBox.CheckedChanged += new System.EventHandler(this.A_checkBox_CheckedChanged);
            // 
            // di_checkBox
            // 
            this.di_checkBox.AutoSize = true;
            this.di_checkBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.di_checkBox.Location = new System.Drawing.Point(10, 248);
            this.di_checkBox.Name = "di_checkBox";
            this.di_checkBox.Size = new System.Drawing.Size(36, 19);
            this.di_checkBox.TabIndex = 2;
            this.di_checkBox.Text = "di";
            this.di_checkBox.UseVisualStyleBackColor = true;
            this.di_checkBox.CheckedChanged += new System.EventHandler(this.di_checkBox_CheckedChanged);
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Enabled = false;
            this.labelA.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelA.Location = new System.Drawing.Point(81, 223);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(134, 15);
            this.labelA.TabIndex = 3;
            this.labelA.Text = "a*A+(a-1)*di , where a=";
            // 
            // labelAi
            // 
            this.labelAi.AutoSize = true;
            this.labelAi.Enabled = false;
            this.labelAi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelAi.Location = new System.Drawing.Point(81, 198);
            this.labelAi.Name = "labelAi";
            this.labelAi.Size = new System.Drawing.Size(137, 15);
            this.labelAi.TabIndex = 4;
            this.labelAi.Text = "a*Ai+(a-1)*di , where a=";
            // 
            // Ai_coef_numUD
            // 
            this.Ai_coef_numUD.BackColor = System.Drawing.SystemColors.Window;
            this.Ai_coef_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ai_coef_numUD.DecimalPlaces = 1;
            this.Ai_coef_numUD.Enabled = false;
            this.Ai_coef_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ai_coef_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.Ai_coef_numUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Ai_coef_numUD.Location = new System.Drawing.Point(219, 200);
            this.Ai_coef_numUD.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Ai_coef_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Ai_coef_numUD.Name = "Ai_coef_numUD";
            this.Ai_coef_numUD.Size = new System.Drawing.Size(39, 16);
            this.Ai_coef_numUD.TabIndex = 5;
            this.Ai_coef_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Ai_coef_numUD.ValueChanged += new System.EventHandler(this.numericUpDownAi_ValueChanged);
            // 
            // A_coef_numUD
            // 
            this.A_coef_numUD.BackColor = System.Drawing.SystemColors.Window;
            this.A_coef_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.A_coef_numUD.DecimalPlaces = 1;
            this.A_coef_numUD.Enabled = false;
            this.A_coef_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_coef_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.A_coef_numUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.A_coef_numUD.Location = new System.Drawing.Point(219, 224);
            this.A_coef_numUD.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.A_coef_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.A_coef_numUD.Name = "A_coef_numUD";
            this.A_coef_numUD.Size = new System.Drawing.Size(39, 16);
            this.A_coef_numUD.TabIndex = 6;
            this.A_coef_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.A_coef_numUD.ValueChanged += new System.EventHandler(this.numericUpDownA_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "For each fitting group:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Maximum number of visible results:";
            // 
            // ObjLbl
            // 
            this.ObjLbl.AutoSize = true;
            this.ObjLbl.Enabled = false;
            this.ObjLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjLbl.ForeColor = System.Drawing.Color.Teal;
            this.ObjLbl.Location = new System.Drawing.Point(81, 174);
            this.ObjLbl.Name = "ObjLbl";
            this.ObjLbl.Size = new System.Drawing.Size(170, 15);
            this.ObjLbl.TabIndex = 10;
            this.ObjLbl.Text = "Objective function to minimize";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Teal;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.Transparent;
            this.numericUpDown1.Location = new System.Drawing.Point(219, 46);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 16);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(6, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sort By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(74, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Score threshold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(176, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ai >";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(176, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "A  >";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(176, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "di >";
            // 
            // Ai_numUD
            // 
            this.Ai_numUD.BackColor = System.Drawing.Color.Teal;
            this.Ai_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ai_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ai_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.Ai_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Ai_numUD.Location = new System.Drawing.Point(219, 79);
            this.Ai_numUD.Name = "Ai_numUD";
            this.Ai_numUD.Size = new System.Drawing.Size(39, 16);
            this.Ai_numUD.TabIndex = 16;
            this.Ai_numUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Ai_numUD.ValueChanged += new System.EventHandler(this.Ai_numUD_ValueChanged);
            // 
            // di_numUD
            // 
            this.di_numUD.BackColor = System.Drawing.Color.Teal;
            this.di_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.di_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.di_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.di_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.di_numUD.Location = new System.Drawing.Point(219, 133);
            this.di_numUD.Name = "di_numUD";
            this.di_numUD.Size = new System.Drawing.Size(39, 16);
            this.di_numUD.TabIndex = 17;
            this.di_numUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.di_numUD.ValueChanged += new System.EventHandler(this.di_numUD_ValueChanged);
            // 
            // A_numUD
            // 
            this.A_numUD.BackColor = System.Drawing.Color.Teal;
            this.A_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.A_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.A_numUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.A_numUD.Location = new System.Drawing.Point(219, 106);
            this.A_numUD.Name = "A_numUD";
            this.A_numUD.Size = new System.Drawing.Size(39, 16);
            this.A_numUD.TabIndex = 18;
            this.A_numUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.A_numUD.ValueChanged += new System.EventHandler(this.A_numUD_ValueChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 289);
            this.Controls.Add(this.A_numUD);
            this.Controls.Add(this.di_numUD);
            this.Controls.Add(this.Ai_numUD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ObjLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.A_coef_numUD);
            this.Controls.Add(this.Ai_coef_numUD);
            this.Controls.Add(this.labelAi);
            this.Controls.Add(this.Ai_checkBox);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.A_checkBox);
            this.Controls.Add(this.di_checkBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form6";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sort fitting results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Ai_coef_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_coef_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ai_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.di_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_numUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Ai_checkBox;
        private System.Windows.Forms.NumericUpDown A_coef_numUD;
        private System.Windows.Forms.NumericUpDown Ai_coef_numUD;
        private System.Windows.Forms.Label labelAi;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.CheckBox di_checkBox;
        private System.Windows.Forms.CheckBox A_checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ObjLbl;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Ai_numUD;
        private System.Windows.Forms.NumericUpDown di_numUD;
        private System.Windows.Forms.NumericUpDown A_numUD;
    }
}