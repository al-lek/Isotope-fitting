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
            this.add_tab_page = new System.Windows.Forms.TabPage();
            this.seq_tabControl = new System.Windows.Forms.TabControl();
            this.seq_tab = new System.Windows.Forms.TabPage();
            this.seq_BoxFrm16 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seq_tabControl.SuspendLayout();
            this.seq_tab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seq_Btn
            // 
            this.seq_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.seq_Btn.BackColor = System.Drawing.Color.ForestGreen;
            this.seq_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seq_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seq_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_Btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seq_Btn.Location = new System.Drawing.Point(546, 19);
            this.seq_Btn.Name = "seq_Btn";
            this.seq_Btn.Size = new System.Drawing.Size(119, 32);
            this.seq_Btn.TabIndex = 1;
            this.seq_Btn.Text = "Save Sequence ";
            this.seq_Btn.UseVisualStyleBackColor = false;
            this.seq_Btn.Click += new System.EventHandler(this.seq_Btn_Click);
            // 
            // add_tab_page
            // 
            this.add_tab_page.Location = new System.Drawing.Point(4, 22);
            this.add_tab_page.Name = "add_tab_page";
            this.add_tab_page.Padding = new System.Windows.Forms.Padding(3);
            this.add_tab_page.Size = new System.Drawing.Size(698, 353);
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
            this.seq_tabControl.Size = new System.Drawing.Size(681, 339);
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
            this.seq_tab.Size = new System.Drawing.Size(673, 313);
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
            this.seq_BoxFrm16.Size = new System.Drawing.Size(667, 307);
            this.seq_BoxFrm16.TabIndex = 2;
            this.seq_BoxFrm16.Text = "";
            this.seq_BoxFrm16.TextChanged += new System.EventHandler(this.seq_BoxFrm16_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seq_Btn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(681, 406);
            this.Controls.Add(this.seq_tabControl);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button seq_Btn;
        private System.Windows.Forms.TabPage add_tab_page;
        private System.Windows.Forms.TabControl seq_tabControl;
        private System.Windows.Forms.TabPage seq_tab;
        private System.Windows.Forms.RichTextBox seq_BoxFrm16;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}