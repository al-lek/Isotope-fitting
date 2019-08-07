namespace Isotope_fitting
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.sa_Btn = new System.Windows.Forms.Button();
            this.ss_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sw_Btn = new System.Windows.Forms.Button();
            this.sw_txtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sa_Btn
            // 
            this.sa_Btn.Location = new System.Drawing.Point(10, 32);
            this.sa_Btn.Name = "sa_Btn";
            this.sa_Btn.Size = new System.Drawing.Size(98, 23);
            this.sa_Btn.TabIndex = 0;
            this.sa_Btn.Text = "Save all";
            this.sa_Btn.UseVisualStyleBackColor = true;
            this.sa_Btn.Click += new System.EventHandler(this.Sa_Btn_Click);
            // 
            // ss_Btn
            // 
            this.ss_Btn.Location = new System.Drawing.Point(10, 65);
            this.ss_Btn.Name = "ss_Btn";
            this.ss_Btn.Size = new System.Drawing.Size(98, 23);
            this.ss_Btn.TabIndex = 1;
            this.ss_Btn.Text = "Save current";
            this.ss_Btn.UseVisualStyleBackColor = true;
            this.ss_Btn.Click += new System.EventHandler(this.Ss_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please choose which sections you want to save.";
            // 
            // sw_Btn
            // 
            this.sw_Btn.Location = new System.Drawing.Point(10, 98);
            this.sw_Btn.Name = "sw_Btn";
            this.sw_Btn.Size = new System.Drawing.Size(98, 23);
            this.sw_Btn.TabIndex = 3;
            this.sw_Btn.Text = "Select windows";
            this.sw_Btn.UseVisualStyleBackColor = true;
            this.sw_Btn.Click += new System.EventHandler(this.Sw_Btn_Click);
            // 
            // sw_txtBox
            // 
            this.sw_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sw_txtBox.Location = new System.Drawing.Point(123, 99);
            this.sw_txtBox.Name = "sw_txtBox";
            this.sw_txtBox.Size = new System.Drawing.Size(98, 20);
            this.sw_txtBox.TabIndex = 4;
            this.sw_txtBox.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 144);
            this.Controls.Add(this.sw_txtBox);
            this.Controls.Add(this.sw_Btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ss_Btn);
            this.Controls.Add(this.sa_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saving options";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sa_Btn;
        private System.Windows.Forms.Button ss_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sw_Btn;
        private System.Windows.Forms.TextBox sw_txtBox;
    }
}