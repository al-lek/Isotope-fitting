﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Remove", new EventHandler(rmv_click));
            cm.MenuItems.Add("Rename", new EventHandler(rename_click));
            seq_tabControl.ContextMenu = cm;
            if (!String.IsNullOrEmpty(frm2.Peptide)) { seq_BoxFrm16.Text = frm2.Peptide.ToString(); }
            if (!String.IsNullOrEmpty(frm2.heavy_chain)) { heavy_BoxFrm16.Text = frm2.heavy_chain.ToString(); }
            if (!String.IsNullOrEmpty(frm2.light_chain)) { light_BoxFrm16.Text = frm2.light_chain.ToString(); }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 20;
        private void tabControl1_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.seq_tabControl.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }
        private void seq_Btn_Click(object sender, EventArgs e)
        {
            frm2.Peptide = seq_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.Peptide= frm2.Peptide.Replace("\t", "");
            frm2.Peptide = frm2.Peptide.Replace(" ", "");
            frm2.heavy_chain = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.heavy_chain = frm2.heavy_chain.Replace("\t", "");
            frm2.heavy_chain = frm2.heavy_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.heavy_chain)) { frm2.heavy_present = false; }
            else { frm2.heavy_present = true; }
            frm2.light_chain = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.light_chain = frm2.light_chain.Replace("\t", "");
            frm2.light_chain = frm2.light_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.light_chain)) { frm2.light_present = false; }
            else { frm2.light_present = true; }




            this.Close();
        }

        private void seq_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (seq_BoxFrm16.Text.Length>10 && !active_txt)
            {
                active_txt = true;
                user_txt = seq_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt =Regex.Replace(user_txt, @".{10}(?!$)", "$0  "); 

                seq_BoxFrm16.Text= output_txt;
                seq_BoxFrm16.SelectionStart = seq_BoxFrm16.Text.Length;
                seq_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        private void heavy_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (heavy_BoxFrm16.Text.Length > 10 && !active_txt)
            {
                active_txt = true;
                user_txt = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                heavy_BoxFrm16.Text = output_txt;
                heavy_BoxFrm16.SelectionStart = heavy_BoxFrm16.Text.Length;
                heavy_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        private void heavy_Btn_Click(object sender, EventArgs e)
        {
            frm2.heavy_chain = heavy_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.heavy_chain = frm2.heavy_chain.Replace("\t", "");
            frm2.heavy_chain = frm2.heavy_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.heavy_chain)) { frm2.heavy_present = false; }
            else { frm2.heavy_present = true; }
            this.Close();
        }

        private void light_BoxFrm16_TextChanged(object sender, EventArgs e)
        {

            if (light_BoxFrm16.Text.Length > 10 && !active_txt)
            {
                active_txt = true;
                user_txt = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace(" ", "");
                output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");

                light_BoxFrm16.Text = output_txt;
                light_BoxFrm16.SelectionStart = light_BoxFrm16.Text.Length;
                light_BoxFrm16.SelectionLength = 0;
            }
            active_txt = false;
        }

        private void light_Btn_Click(object sender, EventArgs e)
        {
            frm2.light_chain = light_BoxFrm16.Text.Replace(Environment.NewLine, " ").ToString();
            frm2.light_chain = frm2.light_chain.Replace("\t", "");
            frm2.light_chain = frm2.light_chain.Replace(" ", "");
            if (string.IsNullOrEmpty(frm2.light_chain)) { frm2.light_present = false; }
            else { frm2.light_present = true; }
            this.Close();
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
                this.seq_tabControl.TabPages.Insert(lastIndex, "New Tab");
                this.seq_tabControl.SelectedIndex = lastIndex;
                RadioButton bH = new RadioButton() { Text = "Heavy",Location=new Point(9, 280),TabIndex=1,Checked=true,AutoSize=true };
                RadioButton bL = new RadioButton() { Text = "Light", Location = new Point(101,280), TabIndex = 2, AutoSize = true };
                RichTextBox box = new RichTextBox() { TabIndex =3,Dock=DockStyle.Top, Size=new Size(692,271)};
                this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { bH, bL , box });
                foreach (RadioButton rdBtn in seq_tabControl.TabPages[lastIndex].Controls.OfType<RadioButton>()) rdBtn.CheckedChanged += (s, e1) => { if (rdBtn.Checked) frm2.sequenceList[lastIndex-1].Type= rdBtn.TabIndex; };

            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < this.seq_tabControl.TabCount-1; ++i)
                {
                    if (this.seq_tabControl.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        this.seq_tabControl.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        //remove selected tab
        private void rmv_click(object sender, System.EventArgs e)
        {
            if (seq_tabControl.SelectedIndex == 0) return;
            frm2.sequenceList.RemoveAt(seq_tabControl.SelectedIndex-0);
            seq_tabControl.TabPages.Remove(seq_tabControl.SelectedTab);
        }

        //rename selected tab
        private void rename_click(object sender, System.EventArgs e)
        {
            if (seq_tabControl.SelectedIndex==0) return;
            var showDialog = this.ShowDialog("Tab Name", "Rename the selected tab");
            seq_tabControl.SelectedTab.Text = showDialog;
            frm2.sequenceList[seq_tabControl.SelectedIndex - 0].Extension="."+ seq_tabControl.SelectedTab.Text.ToString();
        }

        public string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}
