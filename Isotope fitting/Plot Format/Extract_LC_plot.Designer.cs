namespace Isotope_fitting
{
    partial class Extract_LC_plot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Extract_LC_plot));
            this.toolStrip_frm11 = new System.Windows.Forms.ToolStrip();
            this.Save_Btn = new System.Windows.Forms.ToolStripButton();
            this.Copy_Btn = new System.Windows.Forms.ToolStripButton();
            this.x_Box = new System.Windows.Forms.ToolStripTextBox();
            this.y_Box = new System.Windows.Forms.ToolStripTextBox();
            this.panel_frm20 = new System.Windows.Forms.Panel();
            this.toolStrip_frm11.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_frm11
            // 
            this.toolStrip_frm11.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip_frm11.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_frm11.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip_frm11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save_Btn,
            this.Copy_Btn,
            this.x_Box,
            this.y_Box});
            this.toolStrip_frm11.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip_frm11.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_frm11.Name = "toolStrip_frm11";
            this.toolStrip_frm11.Size = new System.Drawing.Size(43, 450);
            this.toolStrip_frm11.TabIndex = 28;
            // 
            // Save_Btn
            // 
            this.Save_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Save_Btn.Image")));
            this.Save_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(40, 22);
            this.Save_Btn.Text = "Save";
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Copy_Btn
            // 
            this.Copy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Copy_Btn.Image")));
            this.Copy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy_Btn.Name = "Copy_Btn";
            this.Copy_Btn.Size = new System.Drawing.Size(40, 22);
            this.Copy_Btn.Text = "Copy";
            this.Copy_Btn.Click += new System.EventHandler(this.Copy_Btn_Click);
            // 
            // x_Box
            // 
            this.x_Box.AutoSize = false;
            this.x_Box.Name = "x_Box";
            this.x_Box.Size = new System.Drawing.Size(40, 22);
            this.x_Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.x_Box_KeyUp);
            // 
            // y_Box
            // 
            this.y_Box.AutoSize = false;
            this.y_Box.Name = "y_Box";
            this.y_Box.Size = new System.Drawing.Size(40, 22);
            this.y_Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.y_Box_KeyUp);
            // 
            // panel_frm20
            // 
            this.panel_frm20.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_frm20.BackColor = System.Drawing.Color.Transparent;
            this.panel_frm20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_frm20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_frm20.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_frm20.Location = new System.Drawing.Point(43, 0);
            this.panel_frm20.Name = "panel_frm20";
            this.panel_frm20.Size = new System.Drawing.Size(757, 450);
            this.panel_frm20.TabIndex = 29;
            // 
            // Extract_LC_plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_frm20);
            this.Controls.Add(this.toolStrip_frm11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Extract_LC_plot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract Plot";
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Extract_LC_plot_DpiChanged);
            this.Resize += new System.EventHandler(this.Extract_LC_plot_Resize);
            this.toolStrip_frm11.ResumeLayout(false);
            this.toolStrip_frm11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_frm11;
        private System.Windows.Forms.ToolStripButton Save_Btn;
        private System.Windows.Forms.ToolStripButton Copy_Btn;
        private System.Windows.Forms.ToolStripTextBox x_Box;
        private System.Windows.Forms.ToolStripTextBox y_Box;
        private System.Windows.Forms.Panel panel_frm20;
    }
}