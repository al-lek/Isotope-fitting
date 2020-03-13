namespace Isotope_fitting
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.resListView = new System.Windows.Forms.ListView();
            this.mzResHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addR_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_Box = new System.Windows.Forms.TextBox();
            this.Dm_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.centBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.complete_Btn = new System.Windows.Forms.Button();
            this.mDm_Box = new System.Windows.Forms.TextBox();
            this.loadRes_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resListView
            // 
            resources.ApplyResources(this.resListView, "resListView");
            this.resListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mzResHeader,
            this.resHeader});
            this.resListView.FullRowSelect = true;
            this.resListView.GridLines = true;
            this.resListView.HideSelection = false;
            this.resListView.Name = "resListView";
            this.resListView.UseCompatibleStateImageBehavior = false;
            this.resListView.View = System.Windows.Forms.View.Details;
            // 
            // mzResHeader
            // 
            resources.ApplyResources(this.mzResHeader, "mzResHeader");
            // 
            // resHeader
            // 
            resources.ApplyResources(this.resHeader, "resHeader");
            // 
            // addR_button
            // 
            resources.ApplyResources(this.addR_button, "addR_button");
            this.addR_button.Name = "addR_button";
            this.addR_button.UseVisualStyleBackColor = true;
            this.addR_button.Click += new System.EventHandler(this.AddR_button_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // m_Box
            // 
            resources.ApplyResources(this.m_Box, "m_Box");
            this.m_Box.Name = "m_Box";
            this.m_Box.TextChanged += new System.EventHandler(this.MBox_TextChanged);
            // 
            // Dm_Box
            // 
            resources.ApplyResources(this.Dm_Box, "Dm_Box");
            this.Dm_Box.Name = "Dm_Box";
            this.Dm_Box.TextChanged += new System.EventHandler(this.DmBox_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // centBox
            // 
            resources.ApplyResources(this.centBox, "centBox");
            this.centBox.Name = "centBox";
            this.centBox.TextChanged += new System.EventHandler(this.CentBox_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // complete_Btn
            // 
            resources.ApplyResources(this.complete_Btn, "complete_Btn");
            this.complete_Btn.Name = "complete_Btn";
            this.complete_Btn.UseVisualStyleBackColor = true;
            this.complete_Btn.Click += new System.EventHandler(this.Complete_Btn_Click);
            // 
            // mDm_Box
            // 
            resources.ApplyResources(this.mDm_Box, "mDm_Box");
            this.mDm_Box.Name = "mDm_Box";
            this.mDm_Box.TextChanged += new System.EventHandler(this.MDmBox_TextChanged);
            // 
            // loadRes_Btn
            // 
            resources.ApplyResources(this.loadRes_Btn, "loadRes_Btn");
            this.loadRes_Btn.BackColor = System.Drawing.Color.PowderBlue;
            this.loadRes_Btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loadRes_Btn.FlatAppearance.BorderSize = 2;
            this.loadRes_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.loadRes_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.loadRes_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadRes_Btn.Name = "loadRes_Btn";
            this.loadRes_Btn.UseVisualStyleBackColor = false;
            this.loadRes_Btn.Click += new System.EventHandler(this.loadRes_Btn_Click);
            // 
            // Form4
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.loadRes_Btn);
            this.Controls.Add(this.complete_Btn);
            this.Controls.Add(this.centBox);
            this.Controls.Add(this.resListView);
            this.Controls.Add(this.Dm_Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mDm_Box);
            this.Controls.Add(this.m_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addR_button);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.TopMost = true;
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form4_DpiChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resListView;
        private System.Windows.Forms.ColumnHeader mzResHeader;
        private System.Windows.Forms.ColumnHeader resHeader;
        private System.Windows.Forms.Button addR_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_Box;
        private System.Windows.Forms.TextBox Dm_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox centBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button complete_Btn;
        private System.Windows.Forms.TextBox mDm_Box;
        private System.Windows.Forms.Button loadRes_Btn;
    }
}