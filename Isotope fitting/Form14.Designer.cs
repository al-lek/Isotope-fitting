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
            ((System.ComponentModel.ISupportInitialize)(this.ppmUD14)).BeginInit();
            this.SuspendLayout();
            // 
            // ppm_Lbl14
            // 
            this.ppm_Lbl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ppm_Lbl14.AutoSize = true;
            this.ppm_Lbl14.Location = new System.Drawing.Point(2, 20);
            this.ppm_Lbl14.Name = "ppm_Lbl14";
            this.ppm_Lbl14.Size = new System.Drawing.Size(74, 13);
            this.ppm_Lbl14.TabIndex = 0;
            this.ppm_Lbl14.Text = "max ppm Error";
            // 
            // ppmUD14
            // 
            this.ppmUD14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ppmUD14.DecimalPlaces = 1;
            this.ppmUD14.Location = new System.Drawing.Point(85, 16);
            this.ppmUD14.Name = "ppmUD14";
            this.ppmUD14.Size = new System.Drawing.Size(76, 20);
            this.ppmUD14.TabIndex = 1;
            this.ppmUD14.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // calcBtn14
            // 
            this.calcBtn14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcBtn14.BackColor = System.Drawing.Color.PaleVioletRed;
            this.calcBtn14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calcBtn14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcBtn14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.calcBtn14.Location = new System.Drawing.Point(5, 49);
            this.calcBtn14.Name = "calcBtn14";
            this.calcBtn14.Size = new System.Drawing.Size(156, 23);
            this.calcBtn14.TabIndex = 2;
            this.calcBtn14.Text = "Calculate";
            this.calcBtn14.UseVisualStyleBackColor = false;
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(173, 87);
            this.Controls.Add(this.calcBtn14);
            this.Controls.Add(this.ppmUD14);
            this.Controls.Add(this.ppm_Lbl14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form14";
            this.Text = "Load Fragments File ";
            ((System.ComponentModel.ISupportInitialize)(this.ppmUD14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ppm_Lbl14;
        private System.Windows.Forms.NumericUpDown ppmUD14;
        private System.Windows.Forms.Button calcBtn14;
    }
}