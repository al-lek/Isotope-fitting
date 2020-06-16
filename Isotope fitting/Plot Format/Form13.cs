using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Helpers;


namespace Isotope_fitting
{
    public partial class Form13 : Form
    {
        Form2 frm2;
        public Form13(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            xstepminor_UD13.Value= (decimal)frm2.xINT_minorStep13;
            xstepmajor_UD13.Value= (decimal)frm2.xINT_majorStep13 ;
            ystepminor_UD13.Value = (decimal)frm2.yINT_minorStep13;
            ystepmajor_UD13.Value = (decimal)frm2.yINT_majorStep13 ;
            xInterval_UD13.Value = (decimal)frm2.x_interval13;
            intLine_numUD13.Value = (decimal)frm2.int_width;
            formatY_numUD13.Value= Decimal.Parse(frm2.x_numformat13);
            foreach (int[] region in frm2.color_internal_indexes)
            {
                textBox1.Text +=region[0]+"-"+region[1]+",";
            }
            if (!String.IsNullOrEmpty(textBox1.Text)) { textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); }
        }

        private void xtickUD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (xtickUD13.SelectedIndex)
            {
                case 0:
                    frm2.Xint_tick13 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Xint_tick13 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Xint_tick13 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Xint_tick13 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void ytickUD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (ytickUD13.SelectedIndex)
            {
                case 0:
                    frm2.Yint_tick13 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Yint_tick13 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Yint_tick13 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Yint_tick13 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.internal_plots_refresh();

        }

        private void xstepminor_UD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.xINT_minorStep13 = (double)xstepminor_UD13.Value;frm2.internal_plots_refresh();
        }

        private void xstepmajor_UD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.xINT_majorStep13 = (double)xstepmajor_UD13.Value;frm2.internal_plots_refresh();
        }

        private void ystepminor_UD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.yINT_minorStep13 = (double)ystepminor_UD13.Value;frm2.internal_plots_refresh();
        }

        private void ystepmajor_UD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.yINT_majorStep13 = (double)ystepmajor_UD13.Value;frm2.internal_plots_refresh();
        }

        private void x_majorGrid_UD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_majorGrid_UD13.SelectedIndex)
            {
                case 0:
                    frm2.Xint_major_grid13 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xint_major_grid13 = LineStyle.Solid;
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void x_minorGrid_UD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_minorGrid_UD13.SelectedIndex)
            {
                case 0:
                    frm2.Xint_major_grid13 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xint_major_grid13 = LineStyle.Solid;
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void y_majorGrid_UD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_majorGrid_UD13.SelectedIndex)
            {
                case 0:
                    frm2.Yint_major_grid13 = LineStyle.None;
                    break;
                case 1:
                    frm2.Yint_major_grid13 = LineStyle.Solid;
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void y_minorGrid_UD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_minorGrid_UD13.SelectedIndex)
            {
                case 0:
                    frm2.Yint_minor_grid13 = LineStyle.None;
                    break;
                case 1:
                    frm2.Yint_minor_grid13 = LineStyle.Solid;
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void xInterval_UD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_interval13 = (double)xInterval_UD13.Value; frm2.internal_plots_refresh();
        }

        private void formatY_UD13_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (formatY_UD13.SelectedIndex)
            {
                case 0:
                    frm2.x_format13 = "G";
                    break;
                case 1:
                    frm2.x_format13 = "0.0E+";
                    break;
            }
            frm2.internal_plots_refresh();
        }

        private void formatY_numUD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_numformat13 = formatY_numUD13.Value.ToString();frm2.internal_plots_refresh();
        }

        private void intLine_numUD13_ValueChanged(object sender, EventArgs e)
        {
            frm2.int_width = (double)intLine_numUD13.Value;frm2.internal_plots_refresh(); frm2.tabs_plots_replot();
        }

        private void Form13_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void color_Btn_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                frm2.color_internal = OxyColor.FromUInt32((uint)clrDlg.Color.ToArgb());
            }
        }

        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            frm2.color_internal_indexes.Clear();
            try
            {
                frm2.color_internal_indexes = return_regions_SS(textBox1.Text.ToString());
            }
            catch
            {
                MessageBox.Show("Please check your input. Fill the box with the numbers of the areas you want to be colored  e.g.1-3,6-8");
            }
            frm2.paint_annotations_in_graphs(false, 2);
        }
    }
}
