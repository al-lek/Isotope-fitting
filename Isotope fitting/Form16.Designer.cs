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
            this.add_tab_page = new System.Windows.Forms.TabPage();
            this.seq_tabControl = new System.Windows.Forms.TabControl();
            this.seq_tab = new System.Windows.Forms.TabPage();
            this.seq_BoxFrm16 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seq_Btn = new System.Windows.Forms.ToolStripButton();
            this.seq_tabControl.SuspendLayout();
            this.seq_tab.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_tab_page
            // 
            this.add_tab_page.Location = new System.Drawing.Point(4, 22);
            this.add_tab_page.Name = "add_tab_page";
            this.add_tab_page.Padding = new System.Windows.Forms.Padding(3);
            this.add_tab_page.Size = new System.Drawing.Size(673, 313);
            this.add_tab_page.TabIndex = 3;
            this.add_tab_page.Text = "+";
            this.add_tab_page.UseVisualStyleBackColor = true;
            // 
            // seq_tabControl
            // 
            this.seq_tabControl.Controls.Add(this.seq_tab);
            this.seq_tabControl.Controls.Add(this.add_tab_page);
            this.seq_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seq_tabControl.Location = new System.Drawing.Point(0, 0);
            this.seq_tabControl.Name = "seq_tabControl";
            this.seq_tabControl.SelectedIndex = 0;
            this.seq_tabControl.Size = new System.Drawing.Size(681, 369);
            this.seq_tabControl.TabIndex = 3;
            this.seq_tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.seq_tabControl_Selecting);
            this.seq_tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.seq_tabControl_MouseDown);
            // 
            // seq_tab
            // 
            this.seq_tab.Controls.Add(this.seq_BoxFrm16);
            this.seq_tab.Location = new System.Drawing.Point(4, 22);
            this.seq_tab.Name = "seq_tab";
            this.seq_tab.Padding = new System.Windows.Forms.Padding(3);
            this.seq_tab.Size = new System.Drawing.Size(673, 343);
            this.seq_tab.TabIndex = 0;
            this.seq_tab.Text = "General Sequence";
            this.seq_tab.UseVisualStyleBackColor = true;
            // 
            // seq_BoxFrm16
            // 
            this.seq_BoxFrm16.AllowDrop = true;
            this.seq_BoxFrm16.DetectUrls = false;
            this.seq_BoxFrm16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seq_BoxFrm16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_BoxFrm16.Location = new System.Drawing.Point(3, 3);
            this.seq_BoxFrm16.Name = "seq_BoxFrm16";
            this.seq_BoxFrm16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.seq_BoxFrm16.ShowSelectionMargin = true;
            this.seq_BoxFrm16.Size = new System.Drawing.Size(667, 337);
            this.seq_BoxFrm16.TabIndex = 2;
            this.seq_BoxFrm16.Text = "";
            this.seq_BoxFrm16.TextChanged += new System.EventHandler(this.seq_BoxFrm16_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seq_Btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 369);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 37);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seq_Btn
            // 
            this.seq_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.seq_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.seq_Btn.Image = ((System.Drawing.Image)(resources.GetObject("seq_Btn.Image")));
            this.seq_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seq_Btn.Name = "seq_Btn";
            this.seq_Btn.Size = new System.Drawing.Size(34, 34);
            this.seq_Btn.Text = "Save Sequence";
            this.seq_Btn.Click += new System.EventHandler(this.seq_Btn_Click);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(681, 406);
            this.Controls.Add(this.seq_tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 445);
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AA amino acid sequence Editor";
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form16_DpiChanged);
            this.seq_tabControl.ResumeLayout(false);
            this.seq_tab.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage add_tab_page;
        private System.Windows.Forms.TabControl seq_tabControl;
        private System.Windows.Forms.TabPage seq_tab;
        private System.Windows.Forms.RichTextBox seq_BoxFrm16;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seq_Btn;
    }
}