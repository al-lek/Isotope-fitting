﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Isotope_fitting.Form2;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form21 : Form
    {
        Form2 frm2;
        private ListViewItemComparer _lvwItemComparer;
        public Form21(Form2 f)
        {
            frm2 = f;
            InitializeComponent();
            _lvwItemComparer = new ListViewItemComparer();
            Initialize_listviewComparer();

            sequence_box_init();
            list_21_init();
        }
        private void Initialize_listviewComparer()
        {
            listView_21.ListViewItemSorter = _lvwItemComparer;
        }
        private void sequence_box_init()
        {
            if (frm2.sequenceList != null && frm2.sequenceList.Count > 1)
            {
                if (seq_extensionBox.Items == null || seq_extensionBox.Items.Count == 0)
                {
                    foreach (SequenceTab seq in frm2.sequenceList)
                    {
                        seq_extensionBox.Items.Add(seq.Extension);
                    }
                }
                else
                {
                    foreach (SequenceTab seq in frm2.sequenceList)
                    {
                        if (!seq_extensionBox.Items.Contains(seq.Extension))
                        {
                            seq_extensionBox.Items.Add(seq.Extension);
                        }
                    }
                    int k = 0;
                    while (k < seq_extensionBox.Items.Count)
                    {
                        if (!frm2.sequenceList.Any(p => p.Extension.Equals(seq_extensionBox.Items[k].ToString())))
                        {
                            seq_extensionBox.Items.RemoveAt(k);
                        }
                        else k++;
                    }
                }

            }
        }
        private void list_21_init()
        {
            listView_21.BeginUpdate();
            foreach (string[] kk in frm2.list_21)
            {
                var listviewitem = new ListViewItem(kk[0]);
                listviewitem.SubItems.Add(kk[1]);
                listviewitem.SubItems.Add(kk[2]);
                listviewitem.SubItems.Add(kk[3]);
                listView_21.Items.Add(listviewitem);
            }           
            listView_21.EndUpdate();
        }
        private void add_Btn_Click(object sender, EventArgs e)
        {
            if (seq_extensionBox.SelectedIndex == -1) { MessageBox.Show("First select extension and then press 'add button'!"); return; }
            if (ionType_box.SelectedIndex == -1) { MessageBox.Show("First select ion type and then press 'add button'!"); return; }
            if (ionType_box.SelectedIndex == 0 &&(string.IsNullOrEmpty(start_box.Text)|| string.IsNullOrEmpty(end_box.Text))) { MessageBox.Show("For internal fragments you have to complete both 'Start' and 'End' regions!"); return; }

            listView_21.BeginUpdate();
            var listviewitem = new ListViewItem(ionType_box.SelectedItem.ToString());
            listviewitem.SubItems.Add(start_box.Text.ToString());
            listviewitem.SubItems.Add(end_box.Text.ToString());
            listviewitem.SubItems.Add(seq_extensionBox.SelectedItem.ToString());
            listView_21.Items.Add(listviewitem);
            listView_21.EndUpdate();
        }

        private void clear_Btn_Click(object sender, EventArgs e)
        {
            start_box.Text = "";
            end_box.Text = "";
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView_21.BeginUpdate();
            listView_21.Items.Clear();
            listView_21.EndUpdate();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_21.SelectedItems.Count==0) { MessageBox.Show("First select the desired items and then press 'Remove'!"); return; }            
            ListView.SelectedListViewItemCollection selectedItems = listView_21.SelectedItems;
            listView_21.BeginUpdate();
            foreach (ListViewItem item in selectedItems)
            {
                listView_21.Items.Remove(item);
            }
            listView_21.EndUpdate();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            frm2.exclude_a_indexes.Clear();
            frm2.exclude_b_indexes.Clear();
            frm2.exclude_c_indexes.Clear();
            frm2.exclude_x_indexes.Clear();
            frm2.exclude_y_indexes.Clear();
            frm2.exclude_z_indexes.Clear();
            frm2.exclude_internal_indexes.Clear();
            frm2.list_21.Clear();

            foreach (ListViewItem item in listView_21.Items)
            {
                frm2.list_21.Add(new string[] { item.SubItems[0].Text.ToString(), item.SubItems[1].Text.ToString(), item.SubItems[2].Text.ToString(), item.SubItems[3].Text.ToString() });
                if (item.SubItems[0].Text.ToString().Equals("internal"))
                {                   
                    string text1 = item.SubItems[1].Text.ToString();
                    string text2 = item.SubItems[2].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t= 0;t< frm2.exclude_internal_indexes.Count; t++)
                    {
                        if (frm2.exclude_internal_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index<0) { frm2.exclude_internal_indexes.Add(new ExcludeTypes() {Extension=exte, Index2 = new List<int[]>(), Index1 = new List<int[]>() }); index = frm2.exclude_internal_indexes.Count-1; }
                    if (!string.IsNullOrEmpty(text1))
                    {
                        text1 = text1.Replace(" ", "");
                        string[] str = text1.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');                            
                            if (str2.Length == 2) { frm2.exclude_internal_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_internal_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) });}
                           
                        }
                    }
                    if (!string.IsNullOrEmpty(text2))
                    {
                        text2 = text2.Replace(" ", "");
                        string[] str = text2.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_internal_indexes[index].Index2.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_internal_indexes[index].Index2.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if(item.SubItems[0].Text.ToString().Equals("a"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_a_indexes.Count; t++)
                    {
                        if (frm2.exclude_a_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_a_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_a_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_a_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_a_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if (item.SubItems[0].Text.ToString().Equals("b"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_b_indexes.Count; t++)
                    {
                        if (frm2.exclude_b_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_b_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_b_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_b_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_b_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if (item.SubItems[0].Text.ToString().Equals("c"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_c_indexes.Count; t++)
                    {
                        if (frm2.exclude_c_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_c_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_c_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_c_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_c_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if (item.SubItems[0].Text.ToString().Equals("x"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_x_indexes.Count; t++)
                    {
                        if (frm2.exclude_x_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_x_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_x_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_x_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_x_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if (item.SubItems[0].Text.ToString().Equals("y"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_y_indexes.Count; t++)
                    {
                        if (frm2.exclude_y_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_y_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_y_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_y_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_y_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
                else if (item.SubItems[0].Text.ToString().Equals("z"))
                {
                    string text = item.SubItems[1].Text.ToString();
                    int index = -1;
                    string exte = item.SubItems[3].Text.ToString();
                    for (int t = 0; t < frm2.exclude_z_indexes.Count; t++)
                    {
                        if (frm2.exclude_z_indexes[t].Extension.Equals(exte)) { index = t; break; }
                    }
                    if (index < 0) { frm2.exclude_z_indexes.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = frm2.exclude_z_indexes.Count - 1; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        text = text.Replace(" ", "");
                        string[] str = text.Split(',');
                        for (int a = 0; a < str.Length; a++)
                        {
                            string[] str2 = str[a].Split('-');
                            if (str2.Length == 2) { frm2.exclude_z_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                            if (str2.Length == 1) { frm2.exclude_z_indexes[index].Index1.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
                        }
                    }
                }
            }
            
        }

        private void listView_21_ColumnClick(object sender, ColumnClickEventArgs e)
        {            
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == SortOrder.Ascending)
                {
                    _lvwItemComparer.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwItemComparer.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView_21.Sort();
        }

        private void start_box_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ionType_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ionType_box.SelectedIndex == 0) return;
            else { end_box.Text = ""; }
        }

        private void end_box_TextChanged(object sender, EventArgs e)
        {
            if (ionType_box.SelectedIndex == 0) return;
            else { end_box.Text = ""; }
        }
    }
}
