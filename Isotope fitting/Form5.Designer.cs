namespace Isotope_fitting
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.peak_listView = new System.Windows.Forms.ListView();
            this.peak_xClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.peak_yClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.peak_resClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // peak_listView
            // 
            this.peak_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.peak_xClmn,
            this.peak_yClmn,
            this.peak_resClmn});
            this.peak_listView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.peak_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peak_listView.FullRowSelect = true;
            this.peak_listView.GridLines = true;
            this.peak_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.peak_listView.HoverSelection = true;
            this.peak_listView.Location = new System.Drawing.Point(0, 0);
            this.peak_listView.Name = "peak_listView";
            this.peak_listView.Size = new System.Drawing.Size(334, 628);
            this.peak_listView.TabIndex = 0;
            this.peak_listView.UseCompatibleStateImageBehavior = false;
            this.peak_listView.View = System.Windows.Forms.View.Details;
            // 
            // peak_xClmn
            // 
            this.peak_xClmn.Text = "Centroid";
            this.peak_xClmn.Width = 110;
            // 
            // peak_yClmn
            // 
            this.peak_yClmn.Text = "Intensity";
            this.peak_yClmn.Width = 110;
            // 
            // peak_resClmn
            // 
            this.peak_resClmn.Text = "Resolution";
            this.peak_resClmn.Width = 110;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 628);
            this.Controls.Add(this.peak_listView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 1000);
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "Form5";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Peak Detection";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView peak_listView;
        private System.Windows.Forms.ColumnHeader peak_xClmn;
        private System.Windows.Forms.ColumnHeader peak_yClmn;
        private System.Windows.Forms.ColumnHeader peak_resClmn;
    }
}