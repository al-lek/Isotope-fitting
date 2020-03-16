namespace Isotope_fitting
{
    partial class Form14
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
            this.ppm_Lbl14 = new System.Windows.Forms.Label();
            this.ppmUD14 = new System.Windows.Forms.NumericUpDown();
            this.calcBtn14 = new System.Windows.Forms.Button();
            this.ignore_ppm_ChkBx = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ppmUD14)).BeginInit();
            this.SuspendLayout();
            // 
            // ppm_Lbl14
            // 
            this.ppm_Lbl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ppm_Lbl14.AutoSize = true;
            this.ppm_Lbl14.Location = new System.Drawing.Point(2, 15);
            this.ppm_Lbl14.Name = "ppm_Lbl14";
            this.ppm_Lbl14.Size = new System.Drawing.Size(74, 13);
            this.ppm_Lbl14.TabIndex = 0;
            this.ppm_Lbl14.Text = "max ppm Error";
            // 
            // ppmUD14
            // 
            this.ppmUD14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ppmUD14.DecimalPlaces = 1;
            this.ppmUD14.Location = new System.Drawing.Point(85, 11);
            this.ppmUD14.Maximum = new decimal(new int[] {
            -559939584,
            902409669,
            54,
            0});
            this.ppmUD14.Name = "ppmUD14";
            this.ppmUD14.Size = new System.Drawing.Size(76, 20);
            this.ppmUD14.TabIndex = 1;
            this.ppmUD14.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ppmUD14.ValueChanged += new System.EventHandler(this.ppmUD14_ValueChanged);
            // 
            // calcBtn14
            // 
            this.calcBtn14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcBtn14.BackColor = System.Drawing.Color.PaleVioletRed;
            this.calcBtn14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calcBtn14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcBtn14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.calcBtn14.Location = new System.Drawing.Point(5, 63);
            this.calcBtn14.Name = "calcBtn14";
            this.calcBtn14.Size = new System.Drawing.Size(156, 23);
            this.calcBtn14.TabIndex = 2;
            this.calcBtn14.Text = "Calculate";
            this.calcBtn14.UseVisualStyleBackColor = false;
            this.calcBtn14.Click += new System.EventHandler(this.calcBtn14_Click);
            // 
            // ignore_ppm_ChkBx
            // 
            this.ignore_ppm_ChkBx.AutoSize = true;
            this.ignore_ppm_ChkBx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ignore_ppm_ChkBx.Location = new System.Drawing.Point(5, 37);
            this.ignore_ppm_ChkBx.Name = "ignore_ppm_ChkBx";
            this.ignore_ppm_ChkBx.Size = new System.Drawing.Size(79, 17);
            this.ignore_ppm_ChkBx.TabIndex = 3;
            this.ignore_ppm_ChkBx.Text = "Ignore ppm";
            this.ignore_ppm_ChkBx.UseVisualStyleBackColor = true;
            this.ignore_ppm_ChkBx.CheckedChanged += new System.EventHandler(this.ignore_ppm_ChkBx_CheckedChanged);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(173, 101);
            this.Controls.Add(this.ignore_ppm_ChkBx);
            this.Controls.Add(this.calcBtn14);
            this.Controls.Add(this.ppmUD14);
            this.Controls.Add(this.ppm_Lbl14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form14";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Fragments File ";
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form14_DpiChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ppmUD14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ppm_Lbl14;
        private System.Windows.Forms.NumericUpDown ppmUD14;
        private System.Windows.Forms.Button calcBtn14;
        private System.Windows.Forms.CheckBox ignore_ppm_ChkBx;
    }
}