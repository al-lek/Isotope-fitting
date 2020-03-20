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
            this.seq_BoxFrm16 = new System.Windows.Forms.RichTextBox();
            this.seq_tabControl = new System.Windows.Forms.TabControl();
            this.seq_tab = new System.Windows.Forms.TabPage();
            this.heavy_chain_tab = new System.Windows.Forms.TabPage();
            this.heavy_BoxFrm16 = new System.Windows.Forms.RichTextBox();
            this.light_chain_tab = new System.Windows.Forms.TabPage();
            this.light_BoxFrm16 = new System.Windows.Forms.RichTextBox();
            this.add_tab_page = new System.Windows.Forms.TabPage();
            this.tab_mode_checkBox1 = new System.Windows.Forms.CheckBox();
            this.seq_tabControl.SuspendLayout();
            this.seq_tab.SuspendLayout();
            this.heavy_chain_tab.SuspendLayout();
            this.light_chain_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // seq_Btn
            // 
            this.seq_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.seq_Btn.BackColor = System.Drawing.Color.ForestGreen;
            this.seq_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seq_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seq_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seq_Btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seq_Btn.Location = new System.Drawing.Point(575, 335);
            this.seq_Btn.Name = "seq_Btn";
            this.seq_Btn.Size = new System.Drawing.Size(119, 32);
            this.seq_Btn.TabIndex = 1;
            this.seq_Btn.Text = "Save Sequence ";
            this.seq_Btn.UseVisualStyleBackColor = false;
            this.seq_Btn.Click += new System.EventHandler(this.seq_Btn_Click);
            // 
            // seq_BoxFrm16
            // 
            this.seq_BoxFrm16.AllowDrop = true;
            this.seq_BoxFrm16.DetectUrls = false;
            this.seq_BoxFrm16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seq_BoxFrm16.Location = new System.Drawing.Point(3, 3);
            this.seq_BoxFrm16.Name = "seq_BoxFrm16";
            this.seq_BoxFrm16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.seq_BoxFrm16.ShowSelectionMargin = true;
            this.seq_BoxFrm16.Size = new System.Drawing.Size(692, 297);
            this.seq_BoxFrm16.TabIndex = 2;
            this.seq_BoxFrm16.Text = "";
            this.seq_BoxFrm16.TextChanged += new System.EventHandler(this.seq_BoxFrm16_TextChanged);
            // 
            // seq_tabControl
            // 
            this.seq_tabControl.Controls.Add(this.seq_tab);
            this.seq_tabControl.Controls.Add(this.heavy_chain_tab);
            this.seq_tabControl.Controls.Add(this.light_chain_tab);
            this.seq_tabControl.Controls.Add(this.add_tab_page);
            this.seq_tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.seq_tabControl.Location = new System.Drawing.Point(0, 0);
            this.seq_tabControl.Name = "seq_tabControl";
            this.seq_tabControl.SelectedIndex = 0;
            this.seq_tabControl.Size = new System.Drawing.Size(706, 329);
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
            this.seq_tab.Size = new System.Drawing.Size(698, 303);
            this.seq_tab.TabIndex = 0;
            this.seq_tab.Text = "General Sequence";
            this.seq_tab.UseVisualStyleBackColor = true;
            // 
            // heavy_chain_tab
            // 
            this.heavy_chain_tab.Controls.Add(this.heavy_BoxFrm16);
            this.heavy_chain_tab.Location = new System.Drawing.Point(4, 22);
            this.heavy_chain_tab.Name = "heavy_chain_tab";
            this.heavy_chain_tab.Padding = new System.Windows.Forms.Padding(3);
            this.heavy_chain_tab.Size = new System.Drawing.Size(698, 303);
            this.heavy_chain_tab.TabIndex = 1;
            this.heavy_chain_tab.Text = "H";
            this.heavy_chain_tab.UseVisualStyleBackColor = true;
            // 
            // heavy_BoxFrm16
            // 
            this.heavy_BoxFrm16.AllowDrop = true;
            this.heavy_BoxFrm16.DetectUrls = false;
            this.heavy_BoxFrm16.Dock = System.Windows.Forms.DockStyle.Top;
            this.heavy_BoxFrm16.Location = new System.Drawing.Point(3, 3);
            this.heavy_BoxFrm16.Name = "heavy_BoxFrm16";
            this.heavy_BoxFrm16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.heavy_BoxFrm16.ShowSelectionMargin = true;
            this.heavy_BoxFrm16.Size = new System.Drawing.Size(692, 294);
            this.heavy_BoxFrm16.TabIndex = 3;
            this.heavy_BoxFrm16.Text = "";
            this.heavy_BoxFrm16.TextChanged += new System.EventHandler(this.heavy_BoxFrm16_TextChanged);
            // 
            // light_chain_tab
            // 
            this.light_chain_tab.Controls.Add(this.light_BoxFrm16);
            this.light_chain_tab.Location = new System.Drawing.Point(4, 22);
            this.light_chain_tab.Name = "light_chain_tab";
            this.light_chain_tab.Padding = new System.Windows.Forms.Padding(3);
            this.light_chain_tab.Size = new System.Drawing.Size(698, 303);
            this.light_chain_tab.TabIndex = 2;
            this.light_chain_tab.Text = "L";
            this.light_chain_tab.UseVisualStyleBackColor = true;
            // 
            // light_BoxFrm16
            // 
            this.light_BoxFrm16.AllowDrop = true;
            this.light_BoxFrm16.DetectUrls = false;
            this.light_BoxFrm16.Dock = System.Windows.Forms.DockStyle.Top;
            this.light_BoxFrm16.Location = new System.Drawing.Point(3, 3);
            this.light_BoxFrm16.Name = "light_BoxFrm16";
            this.light_BoxFrm16.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.light_BoxFrm16.ShowSelectionMargin = true;
            this.light_BoxFrm16.Size = new System.Drawing.Size(692, 297);
            this.light_BoxFrm16.TabIndex = 3;
            this.light_BoxFrm16.Text = "";
            this.light_BoxFrm16.TextChanged += new System.EventHandler(this.light_BoxFrm16_TextChanged);
            // 
            // add_tab_page
            // 
            this.add_tab_page.Location = new System.Drawing.Point(4, 22);
            this.add_tab_page.Name = "add_tab_page";
            this.add_tab_page.Padding = new System.Windows.Forms.Padding(3);
            this.add_tab_page.Size = new System.Drawing.Size(698, 303);
            this.add_tab_page.TabIndex = 3;
            this.add_tab_page.Text = "+";
            this.add_tab_page.UseVisualStyleBackColor = true;
            // 
            // tab_mode_checkBox1
            // 
            this.tab_mode_checkBox1.AutoSize = true;
            this.tab_mode_checkBox1.Location = new System.Drawing.Point(7, 350);
            this.tab_mode_checkBox1.Name = "tab_mode_checkBox1";
            this.tab_mode_checkBox1.Size = new System.Drawing.Size(70, 17);
            this.tab_mode_checkBox1.TabIndex = 4;
            this.tab_mode_checkBox1.Text = "tab mode";
            this.tab_mode_checkBox1.UseVisualStyleBackColor = true;
            this.tab_mode_checkBox1.CheckedChanged += new System.EventHandler(this.tab_mode_checkBox1_CheckedChanged);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(706, 379);
            this.Controls.Add(this.tab_mode_checkBox1);
            this.Controls.Add(this.seq_tabControl);
            this.Controls.Add(this.seq_Btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AA amino acid sequence Editor";
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.Form16_DpiChanged);
            this.seq_tabControl.ResumeLayout(false);
            this.seq_tab.ResumeLayout(false);
            this.heavy_chain_tab.ResumeLayout(false);
            this.light_chain_tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seq_Btn;
        private System.Windows.Forms.RichTextBox seq_BoxFrm16;
        private System.Windows.Forms.TabControl seq_tabControl;
        private System.Windows.Forms.TabPage seq_tab;
        private System.Windows.Forms.TabPage heavy_chain_tab;
        private System.Windows.Forms.TabPage light_chain_tab;
        private System.Windows.Forms.RichTextBox heavy_BoxFrm16;
        private System.Windows.Forms.RichTextBox light_BoxFrm16;
        private System.Windows.Forms.TabPage add_tab_page;
        private System.Windows.Forms.CheckBox tab_mode_checkBox1;
    }
}