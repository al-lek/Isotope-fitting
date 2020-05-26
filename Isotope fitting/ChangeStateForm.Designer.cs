namespace Isotope_fitting
{
    partial class ChangeStateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeStateForm));
            this.oligonoucl_state_Btn = new System.Windows.Forms.PictureBox();
            this.peptide_state_Btn = new System.Windows.Forms.PictureBox();
            this.peptide_state_Lbl = new System.Windows.Forms.Label();
            this.oligonoucl_state_Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oligonoucl_state_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peptide_state_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // oligonoucl_state_Btn
            // 
            this.oligonoucl_state_Btn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.oligonoucl_state_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oligonoucl_state_Btn.Image = ((System.Drawing.Image)(resources.GetObject("oligonoucl_state_Btn.Image")));
            this.oligonoucl_state_Btn.Location = new System.Drawing.Point(293, 29);
            this.oligonoucl_state_Btn.Name = "oligonoucl_state_Btn";
            this.oligonoucl_state_Btn.Size = new System.Drawing.Size(150, 150);
            this.oligonoucl_state_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oligonoucl_state_Btn.TabIndex = 0;
            this.oligonoucl_state_Btn.TabStop = false;
            this.oligonoucl_state_Btn.Click += new System.EventHandler(this.oligonoucl_state_Btn_Click);
            // 
            // peptide_state_Btn
            // 
            this.peptide_state_Btn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.peptide_state_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peptide_state_Btn.Image = ((System.Drawing.Image)(resources.GetObject("peptide_state_Btn.Image")));
            this.peptide_state_Btn.Location = new System.Drawing.Point(59, 29);
            this.peptide_state_Btn.Name = "peptide_state_Btn";
            this.peptide_state_Btn.Size = new System.Drawing.Size(150, 150);
            this.peptide_state_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.peptide_state_Btn.TabIndex = 1;
            this.peptide_state_Btn.TabStop = false;
            this.peptide_state_Btn.Click += new System.EventHandler(this.peptide_state_Btn_Click);
            // 
            // peptide_state_Lbl
            // 
            this.peptide_state_Lbl.AutoSize = true;
            this.peptide_state_Lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peptide_state_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peptide_state_Lbl.Location = new System.Drawing.Point(36, 191);
            this.peptide_state_Lbl.Name = "peptide_state_Lbl";
            this.peptide_state_Lbl.Size = new System.Drawing.Size(206, 17);
            this.peptide_state_Lbl.TabIndex = 2;
            this.peptide_state_Lbl.Text = "Protein && peptides analysis";
            this.peptide_state_Lbl.Click += new System.EventHandler(this.peptide_state_Lbl_Click);
            // 
            // oligonoucl_state_Lbl
            // 
            this.oligonoucl_state_Lbl.AutoSize = true;
            this.oligonoucl_state_Lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oligonoucl_state_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oligonoucl_state_Lbl.Location = new System.Drawing.Point(272, 191);
            this.oligonoucl_state_Lbl.Name = "oligonoucl_state_Lbl";
            this.oligonoucl_state_Lbl.Size = new System.Drawing.Size(193, 17);
            this.oligonoucl_state_Lbl.TabIndex = 3;
            this.oligonoucl_state_Lbl.Text = "Oligonucleotides analysis";
            this.oligonoucl_state_Lbl.Click += new System.EventHandler(this.oligonoucl_state_Lbl_Click);
            // 
            // ChangeStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 236);
            this.ControlBox = false;
            this.Controls.Add(this.oligonoucl_state_Lbl);
            this.Controls.Add(this.peptide_state_Lbl);
            this.Controls.Add(this.peptide_state_Btn);
            this.Controls.Add(this.oligonoucl_state_Btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeStateForm";
            this.Text = "Change State";
            ((System.ComponentModel.ISupportInitialize)(this.oligonoucl_state_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peptide_state_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox oligonoucl_state_Btn;
        private System.Windows.Forms.PictureBox peptide_state_Btn;
        private System.Windows.Forms.Label peptide_state_Lbl;
        private System.Windows.Forms.Label oligonoucl_state_Lbl;
    }
}