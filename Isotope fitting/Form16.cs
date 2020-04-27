﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form16 : Form
    {
        Form2 frm2;
        string user_txt;
        string output_txt;
        bool active_txt = false;
        public Form16(Form2 f)
        {
            frm2 =f;
            InitializeComponent();     

            IntPtr h = this.seq_tabControl.Handle;
            if (frm2.sequenceList != null && frm2.sequenceList.Count==1)
            {
                if (string.IsNullOrEmpty(frm2.sequenceList[0].Rtf))seq_BoxFrm16.Text =  Regex.Replace(frm2.sequenceList[0].Sequence, @".{10}(?!$)", "$0  ");
                else seq_BoxFrm16.Rtf = frm2.sequenceList[0].Rtf;               
            }
            else if (frm2.sequenceList != null && frm2.sequenceList.Count >1)
            {
                if (string.IsNullOrEmpty(frm2.sequenceList[0].Rtf)) seq_BoxFrm16.Text = Regex.Replace(frm2.sequenceList[0].Sequence, @".{10}(?!$)", "$0  ");
                else seq_BoxFrm16.Rtf = frm2.sequenceList[0].Rtf;                
                create_tabPages();
            }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 20;
        
        private void tabControl1_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.seq_tabControl.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }
        private void create_tabPages()
        {           
            int lastIndex = 0;
            for (int k = 1; k < frm2.sequenceList.Count; k++)
            {
                SequenceTab seq = frm2.sequenceList[k];
                lastIndex = seq_tabControl.TabCount - 1;
                seq_tabControl.TabPages.Insert(lastIndex, seq.Extension.ToString());
                seq_tabControl.SelectedIndex = lastIndex;
                RadioButton bH = new RadioButton() { Text = "Heavy", Location = new Point(9, 280), TabIndex = 1,  AutoSize = true };
                RadioButton bL = new RadioButton() { Text = "Light", Location = new Point(101, 280), TabIndex = 2, AutoSize = true };
                if (seq.Type == 1) { bH.Checked = true; }
                else { bL.Checked = true; }                
                RichTextBox box = new RichTextBox() { TabIndex = 3, Dock = DockStyle.Top, Size = new Size(692, 271), ShowSelectionMargin = true, ScrollBars=RichTextBoxScrollBars.Vertical,
                   Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))};
                if (string.IsNullOrEmpty(seq.Rtf)) box.Text = Regex.Replace(seq.Sequence, @".{10}(?!$)", "$0  ");
                else box.Rtf = seq.Rtf;
                box.TextChanged += (s, e1) =>
                {
                    if (box.Text.Length > 10 && !active_txt)
                    {
                        active_txt = true;
                        user_txt = box.Text.Replace(Environment.NewLine, " ").ToString();
                        user_txt = user_txt.Replace("\t", "");
                        user_txt = user_txt.Replace("\n", "");
                        user_txt = user_txt.Replace(" ", "");
                        output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                        box.Text = output_txt;
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                    active_txt = false;
                };
                box.MouseDown += (s, e2) =>
                {
                    if (e2.Button == MouseButtons.Right)
                    {
                        try
                        {
                            if (!box.Visible) { box.Visible = true; }
                            ContextMenu cm_box = new ContextMenu();
                            cm_box.MenuItems.Add("Color", new EventHandler(colorSelection));
                            box.ContextMenu = cm_box;
                        }
                        catch (Exception eee)
                        {
                            Debug.WriteLine(eee.ToString());
                        }                        
                    }
                };
                
                this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { bH, bL, box });       
            }            
            if (frm2.sequenceList.Count > 0) { seq_tabControl.SelectedIndex = 1; }
        }
        private void seq_Btn_Click(object sender, EventArgs e)
        {
            frm2.Peptide = seq_BoxFrm16.Text.Replace(Environment.NewLine, "").ToString();
            frm2.Peptide = frm2.Peptide.Replace("\n", "");
            frm2.Peptide = frm2.Peptide.Replace("\t", "");
            frm2.Peptide = frm2.Peptide.Replace(" ", "");
            for (int k = 1; k < seq_tabControl.TabPages.Count - 1; k++)
            {
                RichTextBox txtbox = seq_tabControl.TabPages[k].Controls.OfType<RichTextBox>().First();
                string s = txtbox.Text.Replace(Environment.NewLine, " ").ToString();
                s = s.Replace("\t", "");
                s = s.Replace("\n", "");
                s = s.Replace(" ", "");
                if (string.IsNullOrEmpty(s)) { MessageBox.Show("You have to insert the aminoacid sequence for each extra tab you add."); return; }
            }
            if (frm2.sequenceList.Count > 0) { frm2.sequenceList.Clear(); }
            frm2.heavy_present = false; frm2.light_present = false;
            for (int k = 0; k < seq_tabControl.TabPages.Count - 1; k++)
            {
                RichTextBox txtbox = seq_tabControl.TabPages[k].Controls.OfType<RichTextBox>().First();
                string s = txtbox.Text.Replace(Environment.NewLine, "").ToString();
                s = s.Replace("\t", "");
                s = s.Replace("\n", "");
                s = s.Replace(" ", "");
                string rtf_s = txtbox.Rtf.Replace(Environment.NewLine, "").ToString();
                rtf_s = rtf_s.Replace("\t", "");
                if (k == 0) frm2.sequenceList.Add(new SequenceTab() { Sequence = s, Extension = "", Type = 0, Rtf = rtf_s });
                else
                {
                    frm2.sequenceList.Add(new SequenceTab() { Sequence = s, Extension = seq_tabControl.TabPages[k].Text, Type = 0, Rtf = rtf_s });
                    foreach (RadioButton rdBtn in seq_tabControl.TabPages[k].Controls.OfType<RadioButton>())
                    {
                        if (rdBtn.Checked)
                        {
                            frm2.sequenceList.Last().Type = rdBtn.TabIndex;
                            if (rdBtn.TabIndex == 1) { frm2.heavy_present = true; }
                            else { frm2.light_present = true; }
                        }
                    }
                }
                frm2.read_rtf_find_color(frm2.sequenceList.Last());
            }
            if (frm2.sequenceList.Count == 1) { frm2.tab_mode = false; }
            else { frm2.tab_mode = true; }        
            this.Close();
        }

        private void seq_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (seq_BoxFrm16.Text.Length>10 && !active_txt)
            {
                active_txt = true;
                user_txt = seq_BoxFrm16.Text.Replace(Environment.NewLine, "").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace("\n", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt =Regex.Replace(user_txt, @".{10}(?!$)", "$0  "); 

                seq_BoxFrm16.Text= output_txt;
                seq_BoxFrm16.SelectionStart = seq_BoxFrm16.Text.Length;
                seq_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        
        private void Form16_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void seq_tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == this.seq_tabControl.TabCount - 1)
                e.Cancel = true;
        }

        private void seq_tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            var lastIndex = this.seq_tabControl.TabCount - 1;
            if (this.seq_tabControl.GetTabRect(lastIndex).Contains(e.Location))
            {
                insert_tab(lastIndex);
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < this.seq_tabControl.TabCount-1; ++i)
                {
                    if (this.seq_tabControl.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        if (seq_tabControl.ContextMenu!=null && seq_tabControl.ContextMenu.MenuItems.Count>0)
                        {
                            seq_tabControl.ContextMenu.MenuItems.Clear();
                        }
                        if ( i == 0 ) {  return; }
                        this.seq_tabControl.SelectedIndex = i;
                        ContextMenu cm = new ContextMenu();
                        cm.MenuItems.Add("Remove", new EventHandler(rmv_click));
                        cm.MenuItems.Add("Rename", new EventHandler(rename_click));
                        seq_tabControl.ContextMenu = cm;
                        break;
                    }
                }
            }
        }
        private void insert_tab(int lastIndex)
        {
            this.seq_tabControl.TabPages.Insert(lastIndex, "New Tab");
            this.seq_tabControl.SelectedIndex = lastIndex;
            RadioButton bH = new RadioButton() { Text = "Heavy", Location = new Point(9, 280), TabIndex = 1, Checked = true, AutoSize = true };
            RadioButton bL = new RadioButton() { Text = "Light", Location = new Point(101, 280), TabIndex = 2, AutoSize = true };
            RichTextBox box = new RichTextBox() { TabIndex = 3, Dock = DockStyle.Top, Size = new Size(692, 271), ShowSelectionMargin = true, ScrollBars = RichTextBoxScrollBars.Vertical,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            box.TextChanged += (s, e1) =>
            {
                if (box.Text.Length > 10 && !active_txt)
                {
                    active_txt = true;
                    user_txt = box.Text.Replace(Environment.NewLine, " ").ToString();
                    user_txt = user_txt.Replace("\n", "");
                    user_txt = user_txt.Replace("\t", "");
                    user_txt = user_txt.Replace(" ", "");
                    output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                    box.Text = output_txt;
                    box.SelectionStart = box.Text.Length;
                    box.SelectionLength = 0;
                }
                active_txt = false;
            };
            box.MouseDown += (s, e2) =>
            {
                if (e2.Button == MouseButtons.Right)
                {
                    ContextMenu cm_box = new ContextMenu();
                    cm_box.MenuItems.Add("Color", new EventHandler(colorSelection));
                    box.ContextMenu = cm_box;
                }
            };
            this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { bH, bL, box });
            //foreach (RadioButton rdBtn in seq_tabControl.TabPages[lastIndex].Controls.OfType<RadioButton>()) rdBtn.CheckedChanged += (s, e1) => { if (rdBtn.Checked) frm2.sequenceList[lastIndex-1].Type= rdBtn.TabIndex; };

        }
        private void colorSelection(object sender, EventArgs e)
        {
            RichTextBox box = seq_tabControl.SelectedTab.Controls.OfType<RichTextBox>().First();
            int start = box.SelectionStart;
            int length = box.SelectionLength;
            ColorDialog clrDlg = new ColorDialog();
            clrDlg.Color = box.SelectionColor;
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                active_txt = true;
                box.Select(start,length);
                box.SelectionColor = clrDlg.Color;
            }
        }
        //remove selected tab
        private void rmv_click(object sender, System.EventArgs e)
        {
            if (seq_tabControl.SelectedIndex == 0) { MessageBox.Show("You can't remove the first tab"); return; }
            //frm2.sequenceList.RemoveAt(seq_tabControl.SelectedIndex-0);
            seq_tabControl.TabPages.Remove(seq_tabControl.SelectedTab);
        }

        //rename selected tab
        private void rename_click(object sender, System.EventArgs e)
        {
            if (seq_tabControl.SelectedIndex==0) return;
            var showDialog = this.ShowRenameDialog();
            seq_tabControl.SelectedTab.Text = showDialog;
            //frm2.sequenceList[seq_tabControl.SelectedIndex - 0].Extension="."+ seq_tabControl.SelectedTab.Text.ToString();
        }

        public string ShowRenameDialog()
        {
            Point loc =MousePosition ;
            Form prompt = new Form() { ShowIcon=false,ShowInTaskbar=false,ControlBox=false,StartPosition=FormStartPosition.Manual,DesktopLocation=loc};
            prompt.Width =275;
            prompt.Height = 150;
            prompt.Text = "Rename the selected tab";
            Label textLabel = new Label() { Left = 25, Top = 20, Text = "Tab Name", AutoSize =true,BackColor=Color.Transparent };
            TextBox textBox = new TextBox() { Left =25, Top =40, Width =200};            
            Button confirmation = new Button() { Text = "Done", Left = 175, Width = 50, Top = 70 };
            textBox.KeyDown += (sender, e) => {if(e.KeyCode==Keys.Enter) confirmation.Focus(); };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return textBox.Text;
        }

    }
}
