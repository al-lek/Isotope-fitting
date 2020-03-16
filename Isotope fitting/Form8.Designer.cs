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
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity_numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // minIntensity_lbl
            // 
            this.minIntensity_lbl.AutoSize = true;
            this.minIntensity_lbl.Location = new System.Drawing.Point(6, 15);
            this.minIntensity_lbl.Name = "minIntensity_lbl";
            this.minIntensity_lbl.Size = new System.Drawing.Size(130, 13);
            this.minIntensity_lbl.TabIndex = 0;
            this.minIntensity_lbl.Text = "peak detect min intensity: ";
            // 
            // minIntensity_numUD
            // 
            this.minIntensity_numUD.Location = new System.Drawing.Point(150, 13);
            this.minIntensity_numUD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minIntensity_numUD.Name = "minIntensity_numUD";
            this.minIntensity_numUD.Size = new System.Drawing.Size(40, 20);
            this.minIntensity_numUD.TabIndex = 1;
            this.minIntensity_numUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(196, 45);
            this.Controls.Add(this.minIntensity_numUD);
            this.Controls.Add(this.minIntensity_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form8";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peak Detection Settings";
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form8_DpiChanged);
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity_numUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minIntensity_lbl;
        private System.Windows.Forms.NumericUpDown minIntensity_numUD;
    }
}