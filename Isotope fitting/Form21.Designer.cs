namespace Isotope_fitting
{
    partial class Form21
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form21));
            this.listView_21 = new System.Windows.Forms.ListView();
            this.ionType_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.end_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extension_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.add_Btn = new System.Windows.Forms.Button();
            this.clear_Btn = new System.Windows.Forms.Button();
            this.groupBox_frm21 = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ionType_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.seq_extensionBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.end_box = new System.Windows.Forms.TextBox();
            this.start_box = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox_frm21.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_21
            // 
            this.listView_21.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ionType_clmn,
            this.start_clmn,
            this.end_clmn,
            this.extension_clmn});
            this.listView_21.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_21.HideSelection = false;
            this.listView_21.Location = new System.Drawing.Point(0, 0);
            this.listView_21.Name = "listView_21";
            this.listView_21.Size = new System.Drawing.Size(432, 322);
            this.listView_21.TabIndex = 0;
            this.listView_21.UseCompatibleStateImageBehavior = false;
            this.listView_21.View = System.Windows.Forms.View.Details;
            // 
            // ionType_clmn
            // 
            this.ionType_clmn.Text = "Ion Type";
            this.ionType_clmn.Width = 98;
            // 
            // start_clmn
            // 
            this.start_clmn.Text = "Start";
            this.start_clmn.Width = 67;
            // 
            // end_clmn
            // 
            this.end_clmn.Text = "End";
            this.end_clmn.Width = 76;
            // 
            // extension_clmn
            // 
            this.extension_clmn.Text = "Extension";
            this.extension_clmn.Width = 73;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // add_Btn
            // 
            this.add_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("add_Btn.BackgroundImage")));
            this.add_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.add_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_Btn.Location = new System.Drawing.Point(356, 34);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(29, 28);
            this.add_Btn.TabIndex = 12;
            this.toolTip1.SetToolTip(this.add_Btn, "Add entries to Exclusion List");
            this.add_Btn.UseVisualStyleBackColor = true;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // clear_Btn
            // 
            this.clear_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clear_Btn.BackgroundImage")));
            this.clear_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clear_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_Btn.Location = new System.Drawing.Point(391, 34);
            this.clear_Btn.Name = "clear_Btn";
            this.clear_Btn.Size = new System.Drawing.Size(29, 28);
            this.clear_Btn.TabIndex = 21;
            this.toolTip1.SetToolTip(this.clear_Btn, "Clear entries");
            this.clear_Btn.UseVisualStyleBackColor = true;
            this.clear_Btn.Click += new System.EventHandler(this.clear_Btn_Click);
            // 
            // groupBox_frm21
            // 
            this.groupBox_frm21.Controls.Add(this.btn);
            this.groupBox_frm21.Controls.Add(this.label1);
            this.groupBox_frm21.Controls.Add(this.add_Btn);
            this.groupBox_frm21.Controls.Add(this.clear_Btn);
            this.groupBox_frm21.Controls.Add(this.label2);
            this.groupBox_frm21.Controls.Add(this.ionType_box);
            this.groupBox_frm21.Controls.Add(this.label3);
            this.groupBox_frm21.Controls.Add(this.seq_extensionBox);
            this.groupBox_frm21.Controls.Add(this.label4);
            this.groupBox_frm21.Controls.Add(this.end_box);
            this.groupBox_frm21.Controls.Add(this.start_box);
            this.groupBox_frm21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_frm21.Location = new System.Drawing.Point(0, 322);
            this.groupBox_frm21.Name = "groupBox_frm21";
            this.groupBox_frm21.Size = new System.Drawing.Size(432, 111);
            this.groupBox_frm21.TabIndex = 22;
            this.groupBox_frm21.TabStop = false;
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.BackColor = System.Drawing.Color.Green;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn.Location = new System.Drawing.Point(356, 72);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(64, 27);
            this.btn.TabIndex = 22;
            this.btn.Text = "Save";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ion Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Start";
            // 
            // ionType_box
            // 
            this.ionType_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ionType_box.FormattingEnabled = true;
            this.ionType_box.Items.AddRange(new object[] {
            "internal",
            "a",
            "b",
            "c",
            "x",
            "y",
            "z"});
            this.ionType_box.Location = new System.Drawing.Point(6, 39);
            this.ionType_box.Name = "ionType_box";
            this.ionType_box.Size = new System.Drawing.Size(81, 21);
            this.ionType_box.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "End";
            // 
            // seq_extensionBox
            // 
            this.seq_extensionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seq_extensionBox.FormattingEnabled = true;
            this.seq_extensionBox.Location = new System.Drawing.Point(267, 38);
            this.seq_extensionBox.Name = "seq_extensionBox";
            this.seq_extensionBox.Size = new System.Drawing.Size(81, 21);
            this.seq_extensionBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Extension";
            // 
            // end_box
            // 
            this.end_box.Location = new System.Drawing.Point(180, 39);
            this.end_box.Name = "end_box";
            this.end_box.Size = new System.Drawing.Size(81, 20);
            this.end_box.TabIndex = 18;
            // 
            // start_box
            // 
            this.start_box.Location = new System.Drawing.Point(93, 39);
            this.start_box.Name = "start_box";
            this.start_box.Size = new System.Drawing.Size(81, 20);
            this.start_box.TabIndex = 17;
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 433);
            this.Controls.Add(this.listView_21);
            this.Controls.Add(this.groupBox_frm21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form21";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Exclusion List";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox_frm21.ResumeLayout(false);
            this.groupBox_frm21.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_21;
        private System.Windows.Forms.ColumnHeader ionType_clmn;
        private System.Windows.Forms.ColumnHeader start_clmn;
        private System.Windows.Forms.ColumnHeader end_clmn;
        private System.Windows.Forms.ColumnHeader extension_clmn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox_frm21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_Btn;
        private System.Windows.Forms.Button clear_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ionType_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox seq_extensionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox end_box;
        private System.Windows.Forms.TextBox start_box;
        private System.Windows.Forms.Button btn;
    }
}