namespace Isotope_fitting
{
    partial class Form23
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form23));
            this.hightlight_clr_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rgb_rdBtn = new System.Windows.Forms.RadioButton();
            this.hightColor_rdBtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.min_numUD = new System.Windows.Forms.NumericUpDown();
            this.max_numUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.seq_reg_numUD = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.save_Btn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.min_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_numUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seq_reg_numUD)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hightlight_clr_Btn
            // 
            this.hightlight_clr_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hightlight_clr_Btn.Location = new System.Drawing.Point(285, 48);
            this.hightlight_clr_Btn.Name = "hightlight_clr_Btn";
            this.hightlight_clr_Btn.Size = new System.Drawing.Size(64, 24);
            this.hightlight_clr_Btn.TabIndex = 18;
            this.hightlight_clr_Btn.Text = "Color";
            this.hightlight_clr_Btn.UseVisualStyleBackColor = true;
            this.hightlight_clr_Btn.Click += new System.EventHandler(this.hightlight_clr_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select the color scale:";
            // 
            // rgb_rdBtn
            // 
            this.rgb_rdBtn.AutoSize = true;
            this.rgb_rdBtn.Location = new System.Drawing.Point(161, 18);
            this.rgb_rdBtn.Name = "rgb_rdBtn";
            this.rgb_rdBtn.Size = new System.Drawing.Size(93, 17);
            this.rgb_rdBtn.TabIndex = 20;
            this.rgb_rdBtn.TabStop = true;
            this.rgb_rdBtn.Text = "blue green red";
            this.rgb_rdBtn.UseVisualStyleBackColor = true;
            // 
            // hightColor_rdBtn
            // 
            this.hightColor_rdBtn.AutoSize = true;
            this.hightColor_rdBtn.Location = new System.Drawing.Point(161, 52);
            this.hightColor_rdBtn.Name = "hightColor_rdBtn";
            this.hightColor_rdBtn.Size = new System.Drawing.Size(91, 17);
            this.hightColor_rdBtn.TabIndex = 21;
            this.hightColor_rdBtn.TabStop = true;
            this.hightColor_rdBtn.Text = "selected color";
            this.hightColor_rdBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Minimum value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Maximum value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Set the value range:";
            // 
            // min_numUD
            // 
            this.min_numUD.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.min_numUD.Location = new System.Drawing.Point(161, 123);
            this.min_numUD.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.min_numUD.Name = "min_numUD";
            this.min_numUD.Size = new System.Drawing.Size(120, 20);
            this.min_numUD.TabIndex = 25;
            // 
            // max_numUD
            // 
            this.max_numUD.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.max_numUD.Location = new System.Drawing.Point(161, 153);
            this.max_numUD.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.max_numUD.Name = "max_numUD";
            this.max_numUD.Size = new System.Drawing.Size(120, 20);
            this.max_numUD.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Format color scale legend:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Regions:";
            // 
            // seq_reg_numUD
            // 
            this.seq_reg_numUD.Location = new System.Drawing.Point(161, 227);
            this.seq_reg_numUD.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.seq_reg_numUD.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seq_reg_numUD.Name = "seq_reg_numUD";
            this.seq_reg_numUD.Size = new System.Drawing.Size(66, 20);
            this.seq_reg_numUD.TabIndex = 30;
            this.seq_reg_numUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_Btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 260);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 37);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // save_Btn
            // 
            this.save_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.save_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_Btn.Image = ((System.Drawing.Image)(resources.GetObject("save_Btn.Image")));
            this.save_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(34, 34);
            this.save_Btn.Text = "Save";
            this.save_Btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // Form23
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 297);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.seq_reg_numUD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.max_numUD);
            this.Controls.Add(this.min_numUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hightColor_rdBtn);
            this.Controls.Add(this.rgb_rdBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hightlight_clr_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form23";
            this.ShowInTaskbar = false;
            this.Text = "Highlight options";
            ((System.ComponentModel.ISupportInitialize)(this.min_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_numUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seq_reg_numUD)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hightlight_clr_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rgb_rdBtn;
        private System.Windows.Forms.RadioButton hightColor_rdBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown min_numUD;
        private System.Windows.Forms.NumericUpDown max_numUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown seq_reg_numUD;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save_Btn;
    }
}