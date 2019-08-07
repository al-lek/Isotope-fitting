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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.ppm_Lbl = new System.Windows.Forms.Label();
            this.ppm_txtBox = new System.Windows.Forms.TextBox();
            this.saveppmBtn = new System.Windows.Forms.Button();
            this.min_intLbl = new System.Windows.Forms.Label();
            this.minInt_TxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ppm_Lbl
            // 
            this.ppm_Lbl.AutoSize = true;
            this.ppm_Lbl.Location = new System.Drawing.Point(13, 13);
            this.ppm_Lbl.Name = "ppm_Lbl";
            this.ppm_Lbl.Size = new System.Drawing.Size(51, 13);
            this.ppm_Lbl.TabIndex = 0;
            this.ppm_Lbl.Text = "ppm error";
            // 
            // ppm_txtBox
            // 
            this.ppm_txtBox.Location = new System.Drawing.Point(117, 13);
            this.ppm_txtBox.Name = "ppm_txtBox";
            this.ppm_txtBox.Size = new System.Drawing.Size(100, 20);
            this.ppm_txtBox.TabIndex = 1;
            this.ppm_txtBox.TextChanged += new System.EventHandler(this.ppm_txtBox_TextChanged);
            // 
            // saveppmBtn
            // 
            this.saveppmBtn.Location = new System.Drawing.Point(70, 174);
            this.saveppmBtn.Name = "saveppmBtn";
            this.saveppmBtn.Size = new System.Drawing.Size(75, 23);
            this.saveppmBtn.TabIndex = 2;
            this.saveppmBtn.Text = "Save";
            this.saveppmBtn.UseVisualStyleBackColor = true;
            this.saveppmBtn.Click += new System.EventHandler(this.saveppmBtn_Click);
            // 
            // min_intLbl
            // 
            this.min_intLbl.AutoSize = true;
            this.min_intLbl.Location = new System.Drawing.Point(12, 48);
            this.min_intLbl.Name = "min_intLbl";
            this.min_intLbl.Size = new System.Drawing.Size(89, 13);
            this.min_intLbl.TabIndex = 3;
            this.min_intLbl.Text = "Minimum intensity";
            // 
            // minInt_TxtBox
            // 
            this.minInt_TxtBox.Location = new System.Drawing.Point(117, 48);
            this.minInt_TxtBox.Name = "minInt_TxtBox";
            this.minInt_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.minInt_TxtBox.TabIndex = 4;
            this.minInt_TxtBox.TextChanged += new System.EventHandler(this.minInt_TxtBox_TextChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 221);
            this.Controls.Add(this.minInt_TxtBox);
            this.Controls.Add(this.min_intLbl);
            this.Controls.Add(this.saveppmBtn);
            this.Controls.Add(this.ppm_txtBox);
            this.Controls.Add(this.ppm_Lbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ppm_Lbl;
        private System.Windows.Forms.TextBox ppm_txtBox;
        private System.Windows.Forms.Button saveppmBtn;
        private System.Windows.Forms.Label min_intLbl;
        private System.Windows.Forms.TextBox minInt_TxtBox;
    }
}