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
            this.peptide_state_Lbl = new System.Windows.Forms.Label();
            this.oligonoucl_state_Lbl = new System.Windows.Forms.Label();
            this.peptide_state_Btn = new System.Windows.Forms.PictureBox();
            this.oligonoucl_state_Btn = new System.Windows.Forms.PictureBox();
            this.save_stateBtn = new System.Windows.Forms.Button();
            this.RNA_Btn = new System.Windows.Forms.RadioButton();
            this.DNA_Btn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.peptide_state_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oligonoucl_state_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // peptide_state_Lbl
            // 
            this.peptide_state_Lbl.AutoSize = true;
            this.peptide_state_Lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peptide_state_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peptide_state_Lbl.Location = new System.Drawing.Point(75, 233);
            this.peptide_state_Lbl.Name = "peptide_state_Lbl";
            this.peptide_state_Lbl.Size = new System.Drawing.Size(150, 17);
            this.peptide_state_Lbl.TabIndex = 2;
            this.peptide_state_Lbl.Text = "Proteins && peptides";
            this.peptide_state_Lbl.Click += new System.EventHandler(this.peptide_state_Lbl_Click);
            // 
            // oligonoucl_state_Lbl
            // 
            this.oligonoucl_state_Lbl.AutoSize = true;
            this.oligonoucl_state_Lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oligonoucl_state_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oligonoucl_state_Lbl.Location = new System.Drawing.Point(326, 233);
            this.oligonoucl_state_Lbl.Name = "oligonoucl_state_Lbl";
            this.oligonoucl_state_Lbl.Size = new System.Drawing.Size(129, 17);
            this.oligonoucl_state_Lbl.TabIndex = 3;
            this.oligonoucl_state_Lbl.Text = "Oligonucleotides";
            this.oligonoucl_state_Lbl.Click += new System.EventHandler(this.oligonoucl_state_Lbl_Click);
            // 
            // peptide_state_Btn
            // 
            this.peptide_state_Btn.BackColor = System.Drawing.Color.Transparent;
            this.peptide_state_Btn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.peptide_state_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peptide_state_Btn.Image = ((System.Drawing.Image)(resources.GetObject("peptide_state_Btn.Image")));
            this.peptide_state_Btn.Location = new System.Drawing.Point(60, 40);
            this.peptide_state_Btn.Name = "peptide_state_Btn";
            this.peptide_state_Btn.Size = new System.Drawing.Size(180, 180);
            this.peptide_state_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.peptide_state_Btn.TabIndex = 1;
            this.peptide_state_Btn.TabStop = false;
            this.peptide_state_Btn.Click += new System.EventHandler(this.peptide_state_Btn_Click);
            // 
            // oligonoucl_state_Btn
            // 
            this.oligonoucl_state_Btn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.oligonoucl_state_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oligonoucl_state_Btn.Image = ((System.Drawing.Image)(resources.GetObject("oligonoucl_state_Btn.Image")));
            this.oligonoucl_state_Btn.Location = new System.Drawing.Point(300, 40);
            this.oligonoucl_state_Btn.Name = "oligonoucl_state_Btn";
            this.oligonoucl_state_Btn.Size = new System.Drawing.Size(180, 180);
            this.oligonoucl_state_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oligonoucl_state_Btn.TabIndex = 0;
            this.oligonoucl_state_Btn.TabStop = false;
            this.oligonoucl_state_Btn.Click += new System.EventHandler(this.oligonoucl_state_Btn_Click);
            // 
            // save_stateBtn
            // 
            this.save_stateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_stateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_stateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_stateBtn.Location = new System.Drawing.Point(405, 293);
            this.save_stateBtn.Name = "save_stateBtn";
            this.save_stateBtn.Size = new System.Drawing.Size(75, 25);
            this.save_stateBtn.TabIndex = 6;
            this.save_stateBtn.Text = "Run";
            this.save_stateBtn.UseVisualStyleBackColor = true;
            this.save_stateBtn.Click += new System.EventHandler(this.save_stateBtn_Click);
            // 
            // RNA_Btn
            // 
            this.RNA_Btn.AutoSize = true;
            this.RNA_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RNA_Btn.Location = new System.Drawing.Point(342, 253);
            this.RNA_Btn.Name = "RNA_Btn";
            this.RNA_Btn.Size = new System.Drawing.Size(48, 17);
            this.RNA_Btn.TabIndex = 4;
            this.RNA_Btn.TabStop = true;
            this.RNA_Btn.Text = "RNA";
            this.RNA_Btn.UseVisualStyleBackColor = true;
            // 
            // DNA_Btn
            // 
            this.DNA_Btn.AutoSize = true;
            this.DNA_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DNA_Btn.Location = new System.Drawing.Point(396, 253);
            this.DNA_Btn.Name = "DNA_Btn";
            this.DNA_Btn.Size = new System.Drawing.Size(48, 17);
            this.DNA_Btn.TabIndex = 5;
            this.DNA_Btn.TabStop = true;
            this.DNA_Btn.Text = "DNA";
            this.DNA_Btn.UseVisualStyleBackColor = true;
            // 
            // ChangeStateForm
            // 
            this.AcceptButton = this.save_stateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(540, 355);
            this.Controls.Add(this.DNA_Btn);
            this.Controls.Add(this.RNA_Btn);
            this.Controls.Add(this.save_stateBtn);
            this.Controls.Add(this.oligonoucl_state_Lbl);
            this.Controls.Add(this.peptide_state_Lbl);
            this.Controls.Add(this.peptide_state_Btn);
            this.Controls.Add(this.oligonoucl_state_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeStateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change State";
            ((System.ComponentModel.ISupportInitialize)(this.peptide_state_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oligonoucl_state_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox oligonoucl_state_Btn;
        private System.Windows.Forms.PictureBox peptide_state_Btn;
        private System.Windows.Forms.Label peptide_state_Lbl;
        private System.Windows.Forms.Label oligonoucl_state_Lbl;
        private System.Windows.Forms.Button save_stateBtn;
        private System.Windows.Forms.RadioButton RNA_Btn;
        private System.Windows.Forms.RadioButton DNA_Btn;
    }
}