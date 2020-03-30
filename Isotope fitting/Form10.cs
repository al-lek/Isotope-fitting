using OxyPlot;
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
            cenW1_numUD.Value = (decimal)frm2.cen_width;
            annotSize_numUD.Value = (decimal)frm2.annotation_size;
            peakW1_numUD.Value = (decimal)frm2.peak_width;
            xInterval_UD.Value= (decimal)frm2.x_interval;
            yInterval_UD.Value = (decimal)frm2.y_interval;
            x_major_grid.Checked = frm2.Xmajor_grid;
            x_minor_grid.Checked = frm2.Xminor_grid;
            y_major_grid.Checked = frm2.Ymajor_grid;
            y_minor_grid.Checked = frm2.Yminor_grid;
        }

        #region tab1 Line Style
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
        private void peakW1_Btn_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK) { frm2.peak_color = OxyColor.FromUInt32((uint)clrDlg.Color.ToArgb()); }
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
        private void peakW1_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.peak_width = (double)peakW1_numUD.Value;
        }
        private void cenW1_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.cen_width = (double)cenW1_numUD.Value;
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
            frm2.fit_color = OxyColors.Black; frm2.peak_color = OxyColors.Crimson; frm2.exp_color = OxyColors.Black.ToColor().ToArgb(); if (Form2.custom_colors.Count>0) { Form2.custom_colors[0] = OxyColors.Black.ToColor().ToArgb(); }
            frm2.fit_style = LineStyle.Dot; frm2.exper_style = LineStyle.Solid; frm2.frag_style = LineStyle.Solid;
            frm2.exp_width = 1; frm2.frag_width = 2; frm2.fit_width = 1; frm2.peak_width = 1; frm2.cen_width = 1;
            expW1_numUD.Value = 1;fitW1_numUD.Value = 1;fragW1_numUD.Value = 2;cenW1_numUD.Value = 1;peakW1_numUD.Value = 1; annotSize_numUD.Value = 9;
        }
        private void refresh10_Btn_Click(object sender, EventArgs e)
        {
            frm2.refresh_frm9();
        }



        #endregion

        #region tab2 Plot step etc
               
        private void axisxtickUD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (xtickUD.SelectedIndex)
            {
                case 0:
                    frm2.X_tick = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.X_tick = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.X_tick = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.X_tick = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.oxy_changes();
        }

        private void axisytickUD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (ytickUD.SelectedIndex)
            {
                case 0:
                    frm2.Y_tick = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Y_tick = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Y_tick = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Y_tick = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.oxy_changes();
        }
        private void xInterval_UD_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_interval = (double)xInterval_UD.Value; frm2.oxy_changes();
        }

        private void yInterval_UD_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_interval = (double)yInterval_UD.Value; frm2.oxy_changes();
        }

        private void formatX_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (formatX_UD.SelectedIndex)
            {
                case 0:
                    frm2.x_format = "0.0G";
                    break;
                case 1:
                    frm2.x_format = "0.0E";
                    break;
            }
            frm2.oxy_changes();
        }

        private void formatY_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (formatY_UD.SelectedIndex)
            {
                case 0:
                    frm2.y_format = "0.0G";
                    break;
                case 1:
                    frm2.y_format = "0.0E";
                    break;
            }
            frm2.oxy_changes();
        }

        private void formatX_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_numformat = formatX_numUD.Value.ToString(); frm2.oxy_changes();
        }

        private void formatY_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_numformat = formatY_numUD.Value.ToString(); frm2.oxy_changes();
        }

        #endregion

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm2.save_preferences();
        }

        private void x_major_grid_CheckedChanged(object sender, EventArgs e)
        {
           frm2.Xmajor_grid = x_major_grid.Checked;            
            frm2.oxy_changes();
        }

        private void x_minor_grid_CheckedChanged(object sender, EventArgs e)
        {
            frm2.Xminor_grid = x_minor_grid.Checked;
            frm2.oxy_changes();
        }

        private void y_major_grid_CheckedChanged(object sender, EventArgs e)
        {
            frm2.Ymajor_grid = y_major_grid.Checked;
            frm2.oxy_changes();
        }

        private void y_minor_grid_CheckedChanged(object sender, EventArgs e)
        {
            frm2.Yminor_grid = y_minor_grid.Checked;
            frm2.oxy_changes();
        }

        private void Form10_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void annotSize_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.annotation_size = (double)annotSize_numUD.Value;
        }
    }
}
