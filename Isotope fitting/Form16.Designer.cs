namespace Isotope_fitting
{
    partial class Form16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form16));
            this.seq_Btn = new System.Windows.Forms.Button();
            this.seq_BoxFrm16 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // seq_Btn
            // 
            this.seq_Btn.BackColor = System.Drawing.Color.ForestGreen;
            this.seq_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seq_Btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.seq_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seq_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_Btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seq_Btn.Location = new System.Drawing.Point(0, 180);
            this.seq_Btn.Name = "seq_Btn";
            this.seq_Btn.Size = new System.Drawing.Size(553, 32);
            this.seq_Btn.TabIndex = 1;
            this.seq_Btn.Text = "Save Sequence ";
            this.seq_Btn.UseVisualStyleBackColor = false;
            this.seq_Btn.Click += new System.EventHandler(this.seq_Btn_Click);
            // 
            // seq_BoxFrm16
            // 
            this.seq_BoxFrm16.AllowDrop = true;
            this.seq_BoxFrm16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.seq_BoxFrm16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seq_BoxFrm16.Location = new System.Drawing.Point(0, 0);
            this.seq_BoxFrm16.Multiline = true;
            this.seq_BoxFrm16.Name = "seq_BoxFrm16";
            this.seq_BoxFrm16.Size = new System.Drawing.Size(553, 180);
            this.seq_BoxFrm16.TabIndex = 2;
            this.seq_BoxFrm16.TextChanged += new System.EventHandler(this.seq_BoxFrm16_TextChanged);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 212);
            this.Controls.Add(this.seq_BoxFrm16);
            this.Controls.Add(this.seq_Btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form16";
            this.Text = "Sequence Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seq_Btn;
        private System.Windows.Forms.TextBox seq_BoxFrm16;
    }
}