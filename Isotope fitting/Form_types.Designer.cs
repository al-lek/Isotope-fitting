namespace Isotope_fitting
{
    partial class Form_types
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_types));
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.reset_btn = new System.Windows.Forms.ToolStripButton();
            this.ok_btn = new System.Windows.Forms.ToolStripButton();
            this.check_allBtn = new System.Windows.Forms.ToolStripButton();
            this.uncheck_allBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(100, 362);
            this.flowPanel.TabIndex = 0;
            this.flowPanel.WrapContents = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reset_btn,
            this.ok_btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 362);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(135, 37);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // reset_btn
            // 
            this.reset_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reset_btn.Image = ((System.Drawing.Image)(resources.GetObject("reset_btn.Image")));
            this.reset_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(34, 34);
            this.reset_btn.Text = "Reset";
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ok_btn.Image = ((System.Drawing.Image)(resources.GetObject("ok_btn.Image")));
            this.ok_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(34, 34);
            this.ok_btn.Text = "Ok";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // check_allBtn
            // 
            this.check_allBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.check_allBtn.Image = ((System.Drawing.Image)(resources.GetObject("check_allBtn.Image")));
            this.check_allBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.check_allBtn.Name = "check_allBtn";
            this.check_allBtn.Size = new System.Drawing.Size(32, 34);
            this.check_allBtn.Text = "Ok";
            this.check_allBtn.Click += new System.EventHandler(this.check_allBtn_Click);
            // 
            // uncheck_allBtn
            // 
            this.uncheck_allBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheck_allBtn.Image = ((System.Drawing.Image)(resources.GetObject("uncheck_allBtn.Image")));
            this.uncheck_allBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheck_allBtn.Name = "uncheck_allBtn";
            this.uncheck_allBtn.Size = new System.Drawing.Size(32, 34);
            this.uncheck_allBtn.Text = "Reset";
            this.uncheck_allBtn.Click += new System.EventHandler(this.uncheck_allBtn_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check_allBtn,
            this.uncheck_allBtn});
            this.toolStrip3.Location = new System.Drawing.Point(100, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(35, 362);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // Form_types
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(135, 399);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_types";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ok_btn;
        private System.Windows.Forms.ToolStripButton reset_btn;
        private System.Windows.Forms.ToolStripButton check_allBtn;
        private System.Windows.Forms.ToolStripButton uncheck_allBtn;
        private System.Windows.Forms.ToolStrip toolStrip3;
    }
}