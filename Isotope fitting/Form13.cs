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

namespace Isotope_fitting
{
    public partial class Form13 : Form
    {
        Form2 frm2;
        public Form13(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
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
                    frm2.x_format13 = "E";
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
            frm2.int_width = (double)intLine_numUD13.Value;frm2.internal_plots_refresh();
        }
    }
}
