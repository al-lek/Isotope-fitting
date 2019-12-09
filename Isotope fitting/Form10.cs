﻿using OxyPlot;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form10 : Form
    {
        Form2 frm2;
        public Form10(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            expW1_numUD.Value = (decimal)frm2.exp_width;
            fitW1_numUD.Value = (decimal)frm2.fit_width;
            fragW1_numUD.Value = (decimal)frm2.frag_width;

        }

        private void expW1_Btn_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();            
            if (clrDlg.ShowDialog() == DialogResult.OK) { frm2.exp_color = clrDlg.Color.ToArgb(); if (Form2.custom_colors.Count > 0) { Form2.custom_colors[0] = clrDlg.Color.ToArgb(); } }
        }

        private void fitW1_Btn_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK) { frm2.fit_color = OxyColor.FromUInt32((uint)clrDlg.Color.ToArgb());  }
        }

        private void refresh10_Btn_Click(object sender, EventArgs e)
        {
            frm2.refresh_frm9();
        }

        private void expW1_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.exp_width = (double)expW1_numUD.Value; 
        }

        private void fitW1_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.fit_width = (double)fitW1_numUD.Value;
        }

        private void fragW1_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.frag_width = (double)fragW1_numUD.Value;
        }

        private void exp10_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (exp10_UD.SelectedIndex)
            {
                case 0:
                    frm2.exper_style = LineStyle.Solid;
                    break;
                case 1:
                    frm2.exper_style = LineStyle.Dot;
                    break;
                case 2:
                    frm2.exper_style = LineStyle.Dash;
                    break;
                case 3:
                    frm2.exper_style = LineStyle.LongDash;
                    break;
                case 4:
                    frm2.exper_style = LineStyle.DashDot;
                    break;
                case 5:
                    frm2.exper_style = LineStyle.LongDashDot;
                    break;
            }
        }

        private void fit10_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (fit10_UD.SelectedIndex)
            {
                case 0:
                    frm2.fit_style = LineStyle.Solid;
                    break;
                case 1:
                    frm2.fit_style = LineStyle.Dot;
                    break;
                case 2:
                    frm2.fit_style = LineStyle.Dash;
                    break;
                case 3:
                    frm2.fit_style = LineStyle.LongDash;
                    break;
                case 4:
                    frm2.fit_style = LineStyle.DashDot;
                    break;
                case 5:
                    frm2.fit_style = LineStyle.LongDashDot;
                    break;
            }
        }

        private void frag10_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (frag10_UD.SelectedIndex)
            {
                case 0:
                    frm2.frag_style = LineStyle.Solid;
                    break;
                case 1:
                    frm2.frag_style = LineStyle.Dot;
                    break;
                case 2:
                    frm2.frag_style = LineStyle.Dash;
                    break;
                case 3:
                    frm2.frag_style = LineStyle.LongDash;
                    break;
                case 4:
                    frm2.frag_style = LineStyle.DashDot;
                    break;
                case 5:
                    frm2.frag_style = LineStyle.LongDashDot;
                    break;
            }
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            frm2.fit_color = OxyColors.Black; frm2.exp_color = OxyColors.Black.ToColor().ToArgb(); if (Form2.custom_colors.Count>0) { Form2.custom_colors[0] = OxyColors.Black.ToColor().ToArgb(); }
            frm2.fit_style = LineStyle.Dot; frm2.exper_style = LineStyle.Solid; frm2.frag_style = LineStyle.Solid;
            frm2.exp_width = 1; frm2.frag_width = 2; frm2.fit_width = 1;
            expW1_numUD.Value = 1;
            fitW1_numUD.Value = 1;
            fragW1_numUD.Value = 2;
        }
    }
}
