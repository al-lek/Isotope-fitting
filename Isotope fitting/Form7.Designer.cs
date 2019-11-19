namespace Isotope_fitting
{
    partial class Form7
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
            this.fitCover_numUD = new System.Windows.Forms.NumericUpDown();
            this.fitBunch_numUD = new System.Windows.Forms.NumericUpDown();
            this.fitCover_lbl = new System.Windows.Forms.Label();
            this.fitBunch_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fitCover_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitBunch_numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // fitCover_numUD
            // 
            this.fitCover_numUD.BackColor = System.Drawing.Color.Teal;
            this.fitCover_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fitCover_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitCover_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.fitCover_numUD.Location = new System.Drawing.Point(276, 72);
            this.fitCover_numUD.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fitCover_numUD.Name = "fitCover_numUD";
            this.fitCover_numUD.Size = new System.Drawing.Size(39, 16);
            this.fitCover_numUD.TabIndex = 18;
            this.fitCover_numUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fitCover_numUD.ValueChanged += new System.EventHandler(this.fitCover_numUD_ValueChanged);
            // 
            // fitBunch_numUD
            // 
            this.fitBunch_numUD.BackColor = System.Drawing.Color.Teal;
            this.fitBunch_numUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fitBunch_numUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitBunch_numUD.ForeColor = System.Drawing.Color.Transparent;
            this.fitBunch_numUD.Location = new System.Drawing.Point(276, 41);
            this.fitBunch_numUD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fitBunch_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fitBunch_numUD.Name = "fitBunch_numUD";
            this.fitBunch_numUD.Size = new System.Drawing.Size(39, 16);
            this.fitBunch_numUD.TabIndex = 17;
            this.fitBunch_numUD.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fitBunch_numUD.ValueChanged += new System.EventHandler(this.fitBunch_numUD_ValueChanged);
            // 
            // fitCover_lbl
            // 
            this.fitCover_lbl.AutoSize = true;
            this.fitCover_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitCover_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.fitCover_lbl.Location = new System.Drawing.Point(12, 72);
            this.fitCover_lbl.Name = "fitCover_lbl";
            this.fitCover_lbl.Size = new System.Drawing.Size(203, 15);
            this.fitCover_lbl.TabIndex = 10;
            this.fitCover_lbl.Text = "Isotopic distribution window overlap:";
            // 
            // fitBunch_lbl
            // 
            this.fitBunch_lbl.AutoSize = true;
            this.fitBunch_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitBunch_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.fitBunch_lbl.Location = new System.Drawing.Point(12, 41);
            this.fitBunch_lbl.Name = "fitBunch_lbl";
            this.fitBunch_lbl.Size = new System.Drawing.Size(207, 15);
            this.fitBunch_lbl.TabIndex = 9;
            this.fitBunch_lbl.Text = "Number of isotopic distributions to fit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Theoritical isotopic distributions :";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(331, 102);
            this.Controls.Add(this.fitCover_numUD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fitBunch_numUD);
            this.Controls.Add(this.fitCover_lbl);
            this.Controls.Add(this.fitBunch_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form7";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fitting calculations";
            ((System.ComponentModel.ISupportInitialize)(this.fitCover_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fitBunch_numUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown fitCover_numUD;
        private System.Windows.Forms.NumericUpDown fitBunch_numUD;
        private System.Windows.Forms.Label fitCover_lbl;
        private System.Windows.Forms.Label fitBunch_lbl;
        private System.Windows.Forms.Label label1;
    }
}