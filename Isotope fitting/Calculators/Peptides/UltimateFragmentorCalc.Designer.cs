namespace Isotope_fitting._2.Calculators._2.a.Peptides
{
    partial class UltimateFragmentorCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UltimateFragmentorCalc));
            this.calc_Btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.input_Tab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadUltfrag = new System.Windows.Forms.Button();
            this.seqTxt = new System.Windows.Forms.TextBox();
            this.xChkBox = new System.Windows.Forms.CheckBox();
            this.yChkBox = new System.Windows.Forms.CheckBox();
            this.zChkBox = new System.Windows.Forms.CheckBox();
            this.cChkBox = new System.Windows.Forms.CheckBox();
            this.bChkBox = new System.Windows.Forms.CheckBox();
            this.aChkBox = new System.Windows.Forms.CheckBox();
            this.cMinTxt = new System.Windows.Forms.TextBox();
            this.cMaxTxt = new System.Windows.Forms.TextBox();
            this.modsList = new System.Windows.Forms.CheckedListBox();
            this.mods = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seq = new System.Windows.Forms.Label();
            this.mods_Tab = new System.Windows.Forms.TabPage();
            this.delModBtn = new System.Windows.Forms.Button();
            this.editModBtn = new System.Windows.Forms.Button();
            this.addModBtn = new System.Windows.Forms.Button();
            this.clrModsList = new System.Windows.Forms.Button();
            this.loadModsJSON = new System.Windows.Forms.Button();
            this.allMods = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aIon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.elem_Tab = new System.Windows.Forms.TabPage();
            this.delElemBtn = new System.Windows.Forms.Button();
            this.editElemBtn = new System.Windows.Forms.Button();
            this.addElemBtn = new System.Windows.Forms.Button();
            this.clrElemBtn = new System.Windows.Forms.Button();
            this.loadElemBtn = new System.Windows.Forms.Button();
            this.elemList = new System.Windows.Forms.ListView();
            this.elem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sidec_Tab = new System.Windows.Forms.TabPage();
            this.clrSC = new System.Windows.Forms.Button();
            this.loadScJSON = new System.Windows.Forms.Button();
            this.scList = new System.Windows.Forms.ListView();
            this.nameSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.single_let = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.three_let = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.elemental = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.massMono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.massAvg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.betaSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gammaSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deltaSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.epsSC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.input_Tab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mods_Tab.SuspendLayout();
            this.elem_Tab.SuspendLayout();
            this.sidec_Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // calc_Btn
            // 
            this.calc_Btn.Location = new System.Drawing.Point(619, 407);
            this.calc_Btn.Name = "calc_Btn";
            this.calc_Btn.Size = new System.Drawing.Size(75, 23);
            this.calc_Btn.TabIndex = 1;
            this.calc_Btn.Text = "Calculate";
            this.calc_Btn.UseVisualStyleBackColor = true;
            this.calc_Btn.Click += new System.EventHandler(this.calc_Btn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.input_Tab);
            this.tabControl1.Controls.Add(this.mods_Tab);
            this.tabControl1.Controls.Add(this.elem_Tab);
            this.tabControl1.Controls.Add(this.sidec_Tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 469);
            this.tabControl1.TabIndex = 2;
            // 
            // input_Tab
            // 
            this.input_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.input_Tab.Controls.Add(this.groupBox1);
            this.input_Tab.Location = new System.Drawing.Point(4, 22);
            this.input_Tab.Name = "input_Tab";
            this.input_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.input_Tab.Size = new System.Drawing.Size(712, 443);
            this.input_Tab.TabIndex = 0;
            this.input_Tab.Text = "Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.loadUltfrag);
            this.groupBox1.Controls.Add(this.seqTxt);
            this.groupBox1.Controls.Add(this.xChkBox);
            this.groupBox1.Controls.Add(this.yChkBox);
            this.groupBox1.Controls.Add(this.zChkBox);
            this.groupBox1.Controls.Add(this.cChkBox);
            this.groupBox1.Controls.Add(this.bChkBox);
            this.groupBox1.Controls.Add(this.aChkBox);
            this.groupBox1.Controls.Add(this.cMinTxt);
            this.groupBox1.Controls.Add(this.cMaxTxt);
            this.groupBox1.Controls.Add(this.modsList);
            this.groupBox1.Controls.Add(this.calc_Btn);
            this.groupBox1.Controls.Add(this.mods);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.seq);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 434);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fields for the Ultimate Fragmentor input.json";
            // 
            // loadUltfrag
            // 
            this.loadUltfrag.Location = new System.Drawing.Point(466, 408);
            this.loadUltfrag.Name = "loadUltfrag";
            this.loadUltfrag.Size = new System.Drawing.Size(147, 23);
            this.loadUltfrag.TabIndex = 20;
            this.loadUltfrag.Text = "Load Ultimate Fragmentor";
            this.loadUltfrag.UseVisualStyleBackColor = true;
            this.loadUltfrag.Click += new System.EventHandler(this.button1_Click);
            // 
            // seqTxt
            // 
            this.seqTxt.Location = new System.Drawing.Point(116, 38);
            this.seqTxt.Multiline = true;
            this.seqTxt.Name = "seqTxt";
            this.seqTxt.Size = new System.Drawing.Size(497, 48);
            this.seqTxt.TabIndex = 19;
            // 
            // xChkBox
            // 
            this.xChkBox.AutoSize = true;
            this.xChkBox.Location = new System.Drawing.Point(116, 363);
            this.xChkBox.Name = "xChkBox";
            this.xChkBox.Size = new System.Drawing.Size(31, 17);
            this.xChkBox.TabIndex = 18;
            this.xChkBox.Text = "x";
            this.xChkBox.UseVisualStyleBackColor = true;
            // 
            // yChkBox
            // 
            this.yChkBox.AutoSize = true;
            this.yChkBox.Location = new System.Drawing.Point(184, 363);
            this.yChkBox.Name = "yChkBox";
            this.yChkBox.Size = new System.Drawing.Size(31, 17);
            this.yChkBox.TabIndex = 17;
            this.yChkBox.Text = "y";
            this.yChkBox.UseVisualStyleBackColor = true;
            // 
            // zChkBox
            // 
            this.zChkBox.AutoSize = true;
            this.zChkBox.Location = new System.Drawing.Point(250, 363);
            this.zChkBox.Name = "zChkBox";
            this.zChkBox.Size = new System.Drawing.Size(31, 17);
            this.zChkBox.TabIndex = 16;
            this.zChkBox.Text = "z";
            this.zChkBox.UseVisualStyleBackColor = true;
            // 
            // cChkBox
            // 
            this.cChkBox.AutoSize = true;
            this.cChkBox.Location = new System.Drawing.Point(250, 317);
            this.cChkBox.Name = "cChkBox";
            this.cChkBox.Size = new System.Drawing.Size(32, 17);
            this.cChkBox.TabIndex = 15;
            this.cChkBox.Text = "c";
            this.cChkBox.UseVisualStyleBackColor = true;
            // 
            // bChkBox
            // 
            this.bChkBox.AutoSize = true;
            this.bChkBox.Location = new System.Drawing.Point(184, 317);
            this.bChkBox.Name = "bChkBox";
            this.bChkBox.Size = new System.Drawing.Size(32, 17);
            this.bChkBox.TabIndex = 14;
            this.bChkBox.Text = "b";
            this.bChkBox.UseVisualStyleBackColor = true;
            // 
            // aChkBox
            // 
            this.aChkBox.AutoSize = true;
            this.aChkBox.Location = new System.Drawing.Point(116, 317);
            this.aChkBox.Name = "aChkBox";
            this.aChkBox.Size = new System.Drawing.Size(32, 17);
            this.aChkBox.TabIndex = 13;
            this.aChkBox.Text = "a";
            this.aChkBox.UseVisualStyleBackColor = true;
            // 
            // cMinTxt
            // 
            this.cMinTxt.Location = new System.Drawing.Point(116, 256);
            this.cMinTxt.Name = "cMinTxt";
            this.cMinTxt.Size = new System.Drawing.Size(100, 20);
            this.cMinTxt.TabIndex = 12;
            // 
            // cMaxTxt
            // 
            this.cMaxTxt.Location = new System.Drawing.Point(116, 223);
            this.cMaxTxt.Name = "cMaxTxt";
            this.cMaxTxt.Size = new System.Drawing.Size(100, 20);
            this.cMaxTxt.TabIndex = 11;
            // 
            // modsList
            // 
            this.modsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modsList.FormattingEnabled = true;
            this.modsList.Location = new System.Drawing.Point(116, 95);
            this.modsList.Name = "modsList";
            this.modsList.ScrollAlwaysVisible = true;
            this.modsList.Size = new System.Drawing.Size(497, 109);
            this.modsList.TabIndex = 10;
            // 
            // mods
            // 
            this.mods.AutoSize = true;
            this.mods.ForeColor = System.Drawing.Color.DarkRed;
            this.mods.Location = new System.Drawing.Point(20, 95);
            this.mods.Name = "mods";
            this.mods.Size = new System.Drawing.Size(75, 13);
            this.mods.TabIndex = 4;
            this.mods.Text = "Modifications: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(20, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Charge Max: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(20, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Charge Min: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(20, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ions: ";
            // 
            // seq
            // 
            this.seq.AutoSize = true;
            this.seq.ForeColor = System.Drawing.Color.DarkRed;
            this.seq.Location = new System.Drawing.Point(20, 41);
            this.seq.Name = "seq";
            this.seq.Size = new System.Drawing.Size(62, 13);
            this.seq.TabIndex = 0;
            this.seq.Text = "Sequence: ";
            // 
            // mods_Tab
            // 
            this.mods_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.mods_Tab.Controls.Add(this.delModBtn);
            this.mods_Tab.Controls.Add(this.editModBtn);
            this.mods_Tab.Controls.Add(this.addModBtn);
            this.mods_Tab.Controls.Add(this.clrModsList);
            this.mods_Tab.Controls.Add(this.loadModsJSON);
            this.mods_Tab.Controls.Add(this.allMods);
            this.mods_Tab.Location = new System.Drawing.Point(4, 22);
            this.mods_Tab.Name = "mods_Tab";
            this.mods_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.mods_Tab.Size = new System.Drawing.Size(712, 443);
            this.mods_Tab.TabIndex = 1;
            this.mods_Tab.Text = "Modifications";
            // 
            // delModBtn
            // 
            this.delModBtn.Location = new System.Drawing.Point(168, 404);
            this.delModBtn.Name = "delModBtn";
            this.delModBtn.Size = new System.Drawing.Size(75, 23);
            this.delModBtn.TabIndex = 5;
            this.delModBtn.Text = "Remove";
            this.delModBtn.UseVisualStyleBackColor = true;
            this.delModBtn.Click += new System.EventHandler(this.delModBtn_Click);
            // 
            // editModBtn
            // 
            this.editModBtn.Location = new System.Drawing.Point(87, 404);
            this.editModBtn.Name = "editModBtn";
            this.editModBtn.Size = new System.Drawing.Size(75, 23);
            this.editModBtn.TabIndex = 4;
            this.editModBtn.Text = "Edit";
            this.editModBtn.UseVisualStyleBackColor = true;
            this.editModBtn.Click += new System.EventHandler(this.editModBtn_Click);
            // 
            // addModBtn
            // 
            this.addModBtn.Location = new System.Drawing.Point(6, 404);
            this.addModBtn.Name = "addModBtn";
            this.addModBtn.Size = new System.Drawing.Size(75, 23);
            this.addModBtn.TabIndex = 3;
            this.addModBtn.Text = "Add";
            this.addModBtn.UseVisualStyleBackColor = true;
            this.addModBtn.Click += new System.EventHandler(this.addModBtn_Click);
            // 
            // clrModsList
            // 
            this.clrModsList.Location = new System.Drawing.Point(631, 404);
            this.clrModsList.Name = "clrModsList";
            this.clrModsList.Size = new System.Drawing.Size(75, 23);
            this.clrModsList.TabIndex = 2;
            this.clrModsList.Text = "Clear List";
            this.clrModsList.UseVisualStyleBackColor = true;
            // 
            // loadModsJSON
            // 
            this.loadModsJSON.Location = new System.Drawing.Point(484, 404);
            this.loadModsJSON.Name = "loadModsJSON";
            this.loadModsJSON.Size = new System.Drawing.Size(141, 23);
            this.loadModsJSON.TabIndex = 1;
            this.loadModsJSON.Text = "Load Modifications JSON File";
            this.loadModsJSON.UseVisualStyleBackColor = true;
            this.loadModsJSON.Click += new System.EventHandler(this.loadModsJSON_Click);
            // 
            // allMods
            // 
            this.allMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.gain,
            this.loss,
            this.aRes,
            this.aIon,
            this.aPos,
            this.desc});
            this.allMods.GridLines = true;
            this.allMods.HideSelection = false;
            this.allMods.Location = new System.Drawing.Point(0, 0);
            this.allMods.Name = "allMods";
            this.allMods.Size = new System.Drawing.Size(709, 398);
            this.allMods.TabIndex = 0;
            this.allMods.UseCompatibleStateImageBehavior = false;
            this.allMods.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 79;
            // 
            // gain
            // 
            this.gain.DisplayIndex = 2;
            this.gain.Text = "Formula Gain";
            this.gain.Width = 113;
            // 
            // loss
            // 
            this.loss.DisplayIndex = 1;
            this.loss.Text = "Formula Loss";
            this.loss.Width = 110;
            // 
            // aRes
            // 
            this.aRes.Text = "Affects Residues";
            this.aRes.Width = 124;
            // 
            // aIon
            // 
            this.aIon.Text = "Affects Ions";
            this.aIon.Width = 99;
            // 
            // aPos
            // 
            this.aPos.Text = "Affect Position";
            this.aPos.Width = 84;
            // 
            // desc
            // 
            this.desc.Text = "Description";
            this.desc.Width = 92;
            // 
            // elem_Tab
            // 
            this.elem_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.elem_Tab.Controls.Add(this.delElemBtn);
            this.elem_Tab.Controls.Add(this.editElemBtn);
            this.elem_Tab.Controls.Add(this.addElemBtn);
            this.elem_Tab.Controls.Add(this.clrElemBtn);
            this.elem_Tab.Controls.Add(this.loadElemBtn);
            this.elem_Tab.Controls.Add(this.elemList);
            this.elem_Tab.Location = new System.Drawing.Point(4, 22);
            this.elem_Tab.Name = "elem_Tab";
            this.elem_Tab.Size = new System.Drawing.Size(712, 443);
            this.elem_Tab.TabIndex = 2;
            this.elem_Tab.Text = "Elements";
            // 
            // delElemBtn
            // 
            this.delElemBtn.Location = new System.Drawing.Point(165, 411);
            this.delElemBtn.Name = "delElemBtn";
            this.delElemBtn.Size = new System.Drawing.Size(75, 23);
            this.delElemBtn.TabIndex = 8;
            this.delElemBtn.Text = "Remove";
            this.delElemBtn.UseVisualStyleBackColor = true;
            // 
            // editElemBtn
            // 
            this.editElemBtn.Location = new System.Drawing.Point(84, 411);
            this.editElemBtn.Name = "editElemBtn";
            this.editElemBtn.Size = new System.Drawing.Size(75, 23);
            this.editElemBtn.TabIndex = 7;
            this.editElemBtn.Text = "Edit";
            this.editElemBtn.UseVisualStyleBackColor = true;
            // 
            // addElemBtn
            // 
            this.addElemBtn.Location = new System.Drawing.Point(3, 411);
            this.addElemBtn.Name = "addElemBtn";
            this.addElemBtn.Size = new System.Drawing.Size(75, 23);
            this.addElemBtn.TabIndex = 6;
            this.addElemBtn.Text = "Add";
            this.addElemBtn.UseVisualStyleBackColor = true;
            // 
            // clrElemBtn
            // 
            this.clrElemBtn.Location = new System.Drawing.Point(627, 411);
            this.clrElemBtn.Name = "clrElemBtn";
            this.clrElemBtn.Size = new System.Drawing.Size(75, 23);
            this.clrElemBtn.TabIndex = 2;
            this.clrElemBtn.Text = "Clear";
            this.clrElemBtn.UseVisualStyleBackColor = true;
            // 
            // loadElemBtn
            // 
            this.loadElemBtn.Location = new System.Drawing.Point(494, 411);
            this.loadElemBtn.Name = "loadElemBtn";
            this.loadElemBtn.Size = new System.Drawing.Size(127, 23);
            this.loadElemBtn.TabIndex = 1;
            this.loadElemBtn.Text = "Load Elements JSON";
            this.loadElemBtn.UseVisualStyleBackColor = true;
            this.loadElemBtn.Click += new System.EventHandler(this.loadElemBtn_Click);
            // 
            // elemList
            // 
            this.elemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.elem,
            this.mass});
            this.elemList.GridLines = true;
            this.elemList.HideSelection = false;
            this.elemList.Location = new System.Drawing.Point(3, 3);
            this.elemList.Name = "elemList";
            this.elemList.Size = new System.Drawing.Size(699, 402);
            this.elemList.TabIndex = 0;
            this.elemList.UseCompatibleStateImageBehavior = false;
            this.elemList.View = System.Windows.Forms.View.Details;
            // 
            // elem
            // 
            this.elem.Text = "Element";
            this.elem.Width = 318;
            // 
            // mass
            // 
            this.mass.Text = "Mass";
            this.mass.Width = 482;
            // 
            // sidec_Tab
            // 
            this.sidec_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.sidec_Tab.Controls.Add(this.clrSC);
            this.sidec_Tab.Controls.Add(this.loadScJSON);
            this.sidec_Tab.Controls.Add(this.scList);
            this.sidec_Tab.Location = new System.Drawing.Point(4, 22);
            this.sidec_Tab.Name = "sidec_Tab";
            this.sidec_Tab.Size = new System.Drawing.Size(712, 443);
            this.sidec_Tab.TabIndex = 3;
            this.sidec_Tab.Text = "Side Chains";
            // 
            // clrSC
            // 
            this.clrSC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clrSC.Location = new System.Drawing.Point(627, 413);
            this.clrSC.Name = "clrSC";
            this.clrSC.Size = new System.Drawing.Size(75, 23);
            this.clrSC.TabIndex = 4;
            this.clrSC.Text = "Clear";
            this.clrSC.UseVisualStyleBackColor = true;
            // 
            // loadScJSON
            // 
            this.loadScJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadScJSON.Location = new System.Drawing.Point(472, 413);
            this.loadScJSON.Name = "loadScJSON";
            this.loadScJSON.Size = new System.Drawing.Size(149, 23);
            this.loadScJSON.TabIndex = 3;
            this.loadScJSON.Text = "Load Side Chains JSON";
            this.loadScJSON.UseVisualStyleBackColor = true;
            this.loadScJSON.Click += new System.EventHandler(this.loadScJSON_Click);
            // 
            // scList
            // 
            this.scList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameSC,
            this.single_let,
            this.three_let,
            this.elemental,
            this.massMono,
            this.massAvg,
            this.fullSC,
            this.betaSC,
            this.gammaSC,
            this.deltaSC,
            this.epsSC});
            this.scList.GridLines = true;
            this.scList.HideSelection = false;
            this.scList.Location = new System.Drawing.Point(0, 3);
            this.scList.Name = "scList";
            this.scList.Size = new System.Drawing.Size(706, 404);
            this.scList.TabIndex = 0;
            this.scList.UseCompatibleStateImageBehavior = false;
            this.scList.View = System.Windows.Forms.View.Details;
            // 
            // nameSC
            // 
            this.nameSC.Text = "Name";
            // 
            // single_let
            // 
            this.single_let.Text = "Single Letter";
            this.single_let.Width = 85;
            // 
            // three_let
            // 
            this.three_let.Text = "Three Letter";
            this.three_let.Width = 91;
            // 
            // elemental
            // 
            this.elemental.Text = "Elemental";
            this.elemental.Width = 79;
            // 
            // massMono
            // 
            this.massMono.Text = "Mass Mono";
            this.massMono.Width = 81;
            // 
            // massAvg
            // 
            this.massAvg.Text = "Mass Average";
            // 
            // fullSC
            // 
            this.fullSC.Text = "Full Side Chain";
            // 
            // betaSC
            // 
            this.betaSC.Text = "Side Chain Beta";
            // 
            // gammaSC
            // 
            this.gammaSC.DisplayIndex = 9;
            this.gammaSC.Text = "Gamma Side Chain";
            this.gammaSC.Width = 84;
            // 
            // deltaSC
            // 
            this.deltaSC.DisplayIndex = 8;
            this.deltaSC.Text = "Delta Side Chain";
            // 
            // epsSC
            // 
            this.epsSC.Text = "Epsilon Side Chain";
            // 
            // UltimateFragmentorCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 472);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UltimateFragmentorCalc";
            this.Text = "Ultimate Fragmentor ";
            this.tabControl1.ResumeLayout(false);
            this.input_Tab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mods_Tab.ResumeLayout(false);
            this.elem_Tab.ResumeLayout(false);
            this.sidec_Tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button calc_Btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage input_Tab;
        private System.Windows.Forms.TabPage mods_Tab;
        private System.Windows.Forms.TabPage sidec_Tab;
        private System.Windows.Forms.TabPage elem_Tab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label mods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label seq;
        private System.Windows.Forms.CheckedListBox modsList;
        private System.Windows.Forms.TextBox cMinTxt;
        private System.Windows.Forms.TextBox cMaxTxt;
        private System.Windows.Forms.Button clrModsList;
        private System.Windows.Forms.Button loadModsJSON;
        private System.Windows.Forms.ListView allMods;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader gain;
        private System.Windows.Forms.ColumnHeader loss;
        private System.Windows.Forms.ColumnHeader aRes;
        private System.Windows.Forms.ColumnHeader aIon;
        private System.Windows.Forms.ColumnHeader aPos;
        private System.Windows.Forms.ColumnHeader desc;
        private System.Windows.Forms.Button delModBtn;
        private System.Windows.Forms.Button editModBtn;
        private System.Windows.Forms.Button addModBtn;
        private System.Windows.Forms.Button clrElemBtn;
        private System.Windows.Forms.Button loadElemBtn;
        private System.Windows.Forms.ListView elemList;
        private System.Windows.Forms.ColumnHeader elem;
        private System.Windows.Forms.ColumnHeader mass;
        private System.Windows.Forms.Button delElemBtn;
        private System.Windows.Forms.Button editElemBtn;
        private System.Windows.Forms.Button addElemBtn;
        private System.Windows.Forms.Button clrSC;
        private System.Windows.Forms.Button loadScJSON;
        private System.Windows.Forms.ListView scList;
        private System.Windows.Forms.ColumnHeader nameSC;
        private System.Windows.Forms.ColumnHeader single_let;
        private System.Windows.Forms.ColumnHeader three_let;
        private System.Windows.Forms.ColumnHeader elemental;
        private System.Windows.Forms.ColumnHeader massMono;
        private System.Windows.Forms.ColumnHeader massAvg;
        private System.Windows.Forms.ColumnHeader fullSC;
        private System.Windows.Forms.ColumnHeader betaSC;
        private System.Windows.Forms.ColumnHeader gammaSC;
        private System.Windows.Forms.ColumnHeader deltaSC;
        private System.Windows.Forms.ColumnHeader epsSC;
        private System.Windows.Forms.TextBox seqTxt;
        private System.Windows.Forms.CheckBox xChkBox;
        private System.Windows.Forms.CheckBox yChkBox;
        private System.Windows.Forms.CheckBox zChkBox;
        private System.Windows.Forms.CheckBox cChkBox;
        private System.Windows.Forms.CheckBox bChkBox;
        private System.Windows.Forms.CheckBox aChkBox;
        private System.Windows.Forms.Button loadUltfrag;
    }
}