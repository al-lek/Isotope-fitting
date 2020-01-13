namespace Isotope_fitting
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            this.panel_frm11 = new System.Windows.Forms.Panel();
            this.toolStrip_frm11 = new System.Windows.Forms.ToolStrip();
            this.Save_Btn = new System.Windows.Forms.ToolStripButton();
            this.Copy_Btn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_frm11.SuspendLayout();
            this.toolStrip_frm11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_frm11
            // 
            this.panel_frm11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_frm11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_frm11.Controls.Add(this.splitContainer1);
            this.panel_frm11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_frm11.Location = new System.Drawing.Point(24, 0);
            this.panel_frm11.Name = "panel_frm11";
            this.panel_frm11.Size = new System.Drawing.Size(1261, 530);
            this.panel_frm11.TabIndex = 30;
            // 
            // toolStrip_frm11
            // 
            this.toolStrip_frm11.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip_frm11.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_frm11.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip_frm11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save_Btn,
            this.Copy_Btn});
            this.toolStrip_frm11.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip_frm11.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_frm11.Name = "toolStrip_frm11";
            this.toolStrip_frm11.Size = new System.Drawing.Size(24, 530);
            this.toolStrip_frm11.TabIndex = 29;
            // 
            // Save_Btn
            // 
            this.Save_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Save_Btn.Image")));
            this.Save_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(21, 22);
            this.Save_Btn.Text = "Save";
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Copy_Btn
            // 
            this.Copy_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Copy_Btn.Image")));
            this.Copy_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy_Btn.Name = "Copy_Btn";
            this.Copy_Btn.Size = new System.Drawing.Size(29, 22);
            this.Copy_Btn.Text = "Copy";
            this.Copy_Btn.Click += new System.EventHandler(this.Copy_Btn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1257, 526);
            this.splitContainer1.SplitterDistance = 817;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 530);
            this.Controls.Add(this.panel_frm11);
            this.Controls.Add(this.toolStrip_frm11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form15";
            this.Text = "Form15";
            this.panel_frm11.ResumeLayout(false);
            this.toolStrip_frm11.ResumeLayout(false);
            this.toolStrip_frm11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_frm11;
        private System.Windows.Forms.ToolStrip toolStrip_frm11;
        private System.Windows.Forms.ToolStripButton Save_Btn;
        private System.Windows.Forms.ToolStripButton Copy_Btn;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}