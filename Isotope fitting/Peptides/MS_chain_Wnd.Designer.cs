namespace Isotope_fitting
{
    partial class MS_chain_Wnd
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
            this.HeavyradioButton = new System.Windows.Forms.RadioButton();
            this.LightradioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeavyradioButton
            // 
            this.HeavyradioButton.AutoSize = true;
            this.HeavyradioButton.Location = new System.Drawing.Point(12, 12);
            this.HeavyradioButton.Name = "HeavyradioButton";
            this.HeavyradioButton.Size = new System.Drawing.Size(86, 17);
            this.HeavyradioButton.TabIndex = 0;
            this.HeavyradioButton.TabStop = true;
            this.HeavyradioButton.Text = "Heavy Chain";
            this.HeavyradioButton.UseVisualStyleBackColor = true;
            this.HeavyradioButton.CheckedChanged += new System.EventHandler(this.HeavyradioButton_CheckedChanged);
            // 
            // LightradioButton2
            // 
            this.LightradioButton2.AutoSize = true;
            this.LightradioButton2.Location = new System.Drawing.Point(12, 35);
            this.LightradioButton2.Name = "LightradioButton2";
            this.LightradioButton2.Size = new System.Drawing.Size(78, 17);
            this.LightradioButton2.TabIndex = 1;
            this.LightradioButton2.TabStop = true;
            this.LightradioButton2.Text = "Light Chain";
            this.LightradioButton2.UseVisualStyleBackColor = true;
            this.LightradioButton2.CheckedChanged += new System.EventHandler(this.LightradioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(12, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selection Completed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ForeColor = System.Drawing.Color.Crimson;
            this.button2.Location = new System.Drawing.Point(96, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            //  MS_chain_Wnd
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(188, 104);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LightradioButton2);
            this.Controls.Add(this.HeavyradioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = " MS_chain_Wnd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS file type";
            this.TopMost = true;
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.MS_chain_Wnd_DpiChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton HeavyradioButton;
        private System.Windows.Forms.RadioButton LightradioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}