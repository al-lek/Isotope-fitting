using System;
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
        bool initial_set = true;
        bool help = false;
        public Form16(Form2 f, bool hlp = false)
        {
            frm2 =f;
            InitializeComponent();
            help = hlp;
            IntPtr h = this.seq_tabControl.Handle;
            if (frm2.sequenceList != null && frm2.sequenceList.Count==1)
            {
                active_txt = true;
                if (string.IsNullOrEmpty(frm2.sequenceList[0].Rtf)) seq_BoxFrm16.Text = Regex.Replace(frm2.sequenceList[0].Sequence, @".{10}(?!$)", "$0  ");
                else { seq_BoxFrm16.Rtf = frm2.sequenceList[0].Rtf;  }
                seq_BoxFrm16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else if (frm2.sequenceList != null && frm2.sequenceList.Count >1)
            {
                if (string.IsNullOrEmpty(frm2.sequenceList[0].Rtf)) seq_BoxFrm16.Text = Regex.Replace(frm2.sequenceList[0].Sequence, @".{10}(?!$)", "$0  ");
                else seq_BoxFrm16.Rtf = frm2.sequenceList[0].Rtf;
                seq_BoxFrm16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                create_tabPages();
            }
            initial_set = false;
            if (frm2.is_riken && frm2.is_rna) { this.Text = "RNA base sequence Editor"; }
            if (frm2.is_riken && !frm2.is_rna) { this.Text = "DNA base sequence Editor"; }
            if (help) { MessageBox.Show("Shows sequence editor with inserted sequences. Multiple sequences can be added.\r\nIn order to succeed the distinction of the fragments of the different sequences from each other,\r\nan extension is defined for each sequence and is equivalent to the name of each new tab.\r\nThis extension is added to the fragment name.\r\nFor the General Sequence no extension is defined.\r\nIn the following tabs for the sequence representation part and also for the other fragments' diagrams the user checks the desired corresponding sequence and automatically the graphs are renewed.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);  }
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
                RichTextBox box = new RichTextBox() { TabIndex = 3, Dock = DockStyle.Fill, Size = new Size(692, 271), ShowSelectionMargin = true, ScrollBars=RichTextBoxScrollBars.Vertical,
                   Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))};
                if (string.IsNullOrEmpty(seq.Rtf)) box.Text = Regex.Replace(seq.Sequence, @".{10}(?!$)", "$0  ");
                else box.Rtf = seq.Rtf;
                box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                box.TextChanged += (s, e1) =>
                {
                    if (box.Text.Length > 10 && !active_txt && !initial_set)
                    {
                        active_txt = true;
                        string old = box.Rtf.ToString().Replace("\r\n", "");
                        user_txt = box.Text.Replace(Environment.NewLine, " ").ToString();
                        user_txt = user_txt.Replace("\t", "");
                        user_txt = user_txt.Replace("\n", "");
                        user_txt = user_txt.Replace(" ", "");
                        //output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");
                        //box.Text = output_txt;
                        output_txt = add_space_to_rtf(old, user_txt);
                        box.Rtf = output_txt;
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                        box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                if (frm2.is_riken)
                {
                    this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { box });
                }
                else
                {
                    GroupBox grp = new GroupBox() { Text = "", Dock = DockStyle.Bottom, Size = new Size(600, 40) };
                    RadioButton bH = new RadioButton() { Text = "Heavy", Location = new Point(9, 10)/*new Point(9, 280)*/, TabIndex = 1, AutoSize = true };
                    RadioButton bL = new RadioButton() { Text = "Light", Location = new Point(101, 10)/*new Point(101, 280)*/, TabIndex = 2, AutoSize = true };
                    if (seq.Type == 1) { bH.Checked = true; }
                    else if (!frm2.is_riken) { bL.Checked = true; }
                    grp.Controls.AddRange(new Control[] { bH, bL });
                    this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { grp, box });
                }
            }            
            if (frm2.sequenceList.Count > 0) { seq_tabControl.SelectedIndex = 1; }
        }
        private void seq_Btn_Click(object sender, EventArgs e)
        {
            if (help) { MessageBox.Show("Save the input sequences.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);return; }

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
                if (string.IsNullOrEmpty(s)) { MessageBox.Show("You have to insert the sequence for each extra tab you add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                for (int m = k+1;m < seq_tabControl.TabPages.Count - 1; m++)
                {
                    if (seq_tabControl.TabPages[k].Text.Equals(seq_tabControl.TabPages[m].Text)) { MessageBox.Show("Two identical extensions are detected.","Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                }
            }
            //if (frm2.sequenceList.Count > 0) { frm2.sequenceList.Clear(); }
            frm2.heavy_present = false; frm2.light_present = false;
            for (int k = 0; k < seq_tabControl.TabPages.Count - 1; k++)
            {
                RichTextBox txtbox = seq_tabControl.TabPages[k].Controls.OfType<RichTextBox>().First();
                string tab_name = seq_tabControl.TabPages[k].Text;
                string s = txtbox.Text.Replace(Environment.NewLine, "").ToString();
                s = s.Replace("\t", "");
                s = s.Replace("\n", "");
                s = s.Replace(" ", "");
                string rtf_s = txtbox.Rtf.Replace(Environment.NewLine, "").ToString();
                rtf_s = rtf_s.Replace("\t", "");
                int[] check = new int[2];
                if (k == 0)
                {                    
                    if (frm2.sequenceList.Count==0) { frm2.sequenceList.Add(new SequenceTab() { Sequence = s, Extension = "", Type = 0, Rtf = rtf_s }); }
                    else
                    {
                        check = check_if_sequence_exists("", s, 0, true);
                        if (check[0] == 0) frm2.sequenceList[0] = new SequenceTab() { Sequence = s, Extension = "", Type = 0, Rtf = rtf_s };
                        else frm2.sequenceList[0].Rtf = rtf_s;
                    }                    
                }
                else if (frm2.is_riken)
                {
                    check = check_if_sequence_exists(tab_name, s,0);
                    if (check[0] == 0) { frm2.sequenceList.Add(new SequenceTab() { Sequence = s, Extension = tab_name, Type = 0, Rtf = rtf_s }); check[1] = frm2.sequenceList.Count - 1; }
                    else { frm2.sequenceList[check[1]].Rtf = rtf_s; frm2.sequenceList[check[1]].Type = 0; }
                }
                else
                {
                    int type = 0;
                    foreach (RadioButton rdBtn in seq_tabControl.TabPages[k].Controls.OfType<GroupBox>().First().Controls.OfType<RadioButton>())
                    {
                        if (rdBtn.Checked)
                        {
                            type = rdBtn.TabIndex;
                            if (rdBtn.TabIndex == 1) { frm2.heavy_present = true; }
                            else { frm2.light_present = true; }
                        }
                    }
                    check = check_if_sequence_exists(tab_name, s,type);
                    if (check[0] == 0) { frm2.sequenceList.Add(new SequenceTab() { Sequence = s, Extension = tab_name, Type = type, Rtf = rtf_s }); check[1] = frm2.sequenceList.Count - 1; }
                    else { frm2.sequenceList[check[1]].Rtf = rtf_s; frm2.sequenceList[check[1]].Type = type; }                    
                }
                frm2.read_rtf_find_color(frm2.sequenceList[check[1]]);
            }
            remove_seq_from_list();
            if (frm2.sequenceList.Count == 1) { frm2.tab_mode = false; }
            else { frm2.tab_mode = true; }
            this.Close();
        }
        private int[] check_if_sequence_exists(string tab_name, string tab_sequence,int type, bool general=false)
        {
            int[] result = new int[] {0,0};
            int amount = frm2.sequenceList.Count;
            if(amount==0) return result;
            if (general) { amount = 1; }
            for (int s=0;s< amount; s++ )
            {
                SequenceTab seq = frm2.sequenceList[s];
                if (seq.Sequence.Equals(tab_sequence)&& seq.Extension.Equals(tab_name) && seq.Type == type)
                {
                    result= new int[] { 1, s };
                }
            }
            return result;
        }
        private void remove_seq_from_list()
        {
            if (frm2.sequenceList.Count<2) return;
            int s = 1;
            while (s< frm2.sequenceList.Count)
            {
                SequenceTab seq = frm2.sequenceList[s];
                bool is_present = false;
                for (int k = 1; k < seq_tabControl.TabPages.Count - 1; k++)
                {
                    int type = 0;
                    RichTextBox txtbox = seq_tabControl.TabPages[k].Controls.OfType<RichTextBox>().First();
                    string tab_name = seq_tabControl.TabPages[k].Text;
                    string tab_sequence = txtbox.Text.Replace(Environment.NewLine, "").ToString();
                    tab_sequence = tab_sequence.Replace("\t", "").Replace("\n", "").Replace(" ", "");                   
                    if (!frm2.is_riken)                   
                    {
                        foreach (RadioButton rdBtn in seq_tabControl.TabPages[k].Controls.OfType<GroupBox>().First().Controls.OfType<RadioButton>())
                        {
                            if (rdBtn.Checked){type = rdBtn.TabIndex;}
                        }
                       
                    }
                    if (seq.Sequence.Equals(tab_sequence) && seq.Extension.Equals(tab_name) && seq.Type == type)
                    {
                        is_present = true; break;
                    }
                }
                if (!is_present) frm2.sequenceList.RemoveAt(s);
                else s++;
            }
        }
        #region general sequence        
        private void seq_BoxFrm16_TextChanged(object sender, EventArgs e)
        {
            if (seq_BoxFrm16.Text.Length>10 && !active_txt &&!initial_set)
            {                
                active_txt = true;
                string old = seq_BoxFrm16.Rtf.ToString().Replace("\r\n", "");
                user_txt = seq_BoxFrm16.Text.Replace(Environment.NewLine, "").ToString();
                user_txt = user_txt.Replace("\t", "");
                user_txt = user_txt.Replace("\n", "");
                user_txt = user_txt.Replace(" ", "");
                //output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");
                //seq_BoxFrm16.Text = output_txt;
                
                output_txt = add_space_to_rtf(old, user_txt);
                seq_BoxFrm16.Rtf = output_txt;
                seq_BoxFrm16.SelectionStart = seq_BoxFrm16.Text.Length;
                seq_BoxFrm16.SelectionLength = 0;
                seq_BoxFrm16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            active_txt = false;
        }
        #endregion

        #region tab options
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
                for (int i = 0; i < this.seq_tabControl.TabCount - 1; ++i)
                {
                    if (this.seq_tabControl.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        if (seq_tabControl.ContextMenu != null && seq_tabControl.ContextMenu.MenuItems.Count > 0)
                        {
                            seq_tabControl.ContextMenu.MenuItems.Clear();
                        }
                        if (i == 0) { return; }
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
           RichTextBox box = new RichTextBox()
            {
                TabIndex = 3,
                Dock = DockStyle.Fill,
                Size = new Size(692, 271),
                ShowSelectionMargin = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            };
            box.TextChanged += (s, e1) =>
            {
                if (box.Text.Length > 10 && !active_txt && !initial_set)
                {
                    active_txt = true;
                    string old = box.Rtf.ToString().Replace("\r\n", "");
                    user_txt = box.Text.Replace(Environment.NewLine, " ").ToString();
                    user_txt = user_txt.Replace("\n", "");
                    user_txt = user_txt.Replace("\t", "");
                    user_txt = user_txt.Replace(" ", "");
                    //output_txt = Regex.Replace(user_txt, @".{10}(?!$)", "$0  ");
                    //box.Text = output_txt;
                    output_txt = add_space_to_rtf(old, user_txt);
                    box.Rtf = output_txt;
                    box.SelectionStart = box.Text.Length;
                    box.SelectionLength = 0;
                    box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            if (frm2.is_riken) this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { box });
            else
            {
                GroupBox grp = new GroupBox() { Text = "", Dock = DockStyle.Bottom, Size = new Size(600, 40) };
                RadioButton bH = new RadioButton() { Text = "Heavy", Location = new Point(9, 10)/*new Point(9, 280)*/, Checked = true, TabIndex = 1, AutoSize = true };
                RadioButton bL = new RadioButton() { Text = "Light", Location = new Point(101, 10)/*new Point(101, 280)*/, TabIndex = 2, AutoSize = true };
                grp.Controls.AddRange(new Control[] { bH, bL });
                this.seq_tabControl.TabPages[lastIndex].Controls.AddRange(new Control[] { grp, box });
            }
           
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
            if (seq_tabControl.SelectedIndex == 0) { MessageBox.Show("You can't remove the first tab", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
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
        #endregion
               
        private void Form16_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
        
        private string add_space_to_rtf(string initial,string sequence)
        {
            string final = "";            
            string text_section = "";           
            string[] str = initial.Split('{');
            for (int k = 1; k < str.Length; k++)
            {
                if (str[k].Contains("\\pard"))
                {
                    text_section = str[k];break;
                }
                else
                {
                    final += "{" + str[k];
                }
            }           
            final += "{";
            string[] str4 = text_section.Split('}');
            for (int k = 0; k < str4.Length - 2; k++)
            {
                final +=  str4[k]+"}";
            }
            //\viewkind4\uc1 \pard\f0\fs17 MQIFVKTLTG  KTITLEVEPS  \cf1 DTIENVKAKI  \cf0 QDKEGIPPDQ  QRLIFAGKQL  \cf2 EDGRTLSDYN  \cf0 IQKESTLHLV  LRLR\cf3 GG\cf0\par
            string[] str5 = str4[str4.Length - 2].Split('\\');
            int str_c = 0;
            for (int s=1;s< str5.Length ; s++)
            {
                string sub = str5[s];
                if (sub.StartsWith("f0") || sub.StartsWith("lang") || sub.StartsWith("fs"))
                {
                    string[] str6 = sub.Split(' ');
                    if (str6.Length > 1)
                    {
                        final += '\\' + str6[0] + " ";
                        for (int i = 1; i < str6.Length; i++)
                        {
                            for (int h = 0; h < str6[i].Length; h++)
                            {
                                char letter = str6[i][h];
                                if (sequence[str_c].Equals(letter))
                                {
                                    final += letter; str_c++;
                                    if (str_c % 10 == 0) { final += " "; }
                                }
                                else
                                {
                                    MessageBox.Show("Error in sequence rtf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);return initial;
                                }
                            }
                        }
                    }
                    else
                    {
                        final += '\\' + sub;
                    }
                }
                else if (sub.StartsWith("cf"))
                {
                    string[] str6 = sub.Split(' ');
                    if (str6.Length > 1)
                    {
                        final += '\\' + str6[0]+" ";
                        for (int i = 1; i < str6.Length; i++)
                        {
                            for (int h = 0; h < str6[i].Length; h++)
                            {
                                char letter = str6[i][h];
                                if (sequence[str_c].Equals(letter))
                                {
                                    final += letter; str_c++;
                                    if (str_c%10==0) { final +=  " "; }
                                }
                                else
                                {
                                    MessageBox.Show("Error in sequence rtf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return initial;
                                }
                            }
                        }
                    }
                    else//when cf is not followed by a space then the plain text region has ended
                    {
                        final += '\\' + sub;
                    }
                }                
                else if(!sub.Equals("n"))
                {
                    final += '\\' + sub;
                }
            }
            final += "}";
            return final;
        }
    }
}
