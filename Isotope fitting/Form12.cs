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
    public partial class Form12 : Form
    {
        Form2 frm2;
        public Form12(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            yInterval_UD12.Value = (decimal)frm2.y_interval12;
            xstepminor_UD12.Value = (decimal)frm2.x_minorStep12;
            xstepmajor_UD12.Value = (decimal)frm2.x_majorStep12;
            x_charge_stepminor_UD12.Value = (decimal)frm2.x_charge_minorStep12;
            x_charge_stepmajor_UD12.Value = (decimal)frm2.x_charge_majorStep12;
        }

        #region tab format intensity plot

        private void xtickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (xtickUD12.SelectedIndex)
            {
                case 0:
                    frm2.X_tick12 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.X_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.X_tick12 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.X_tick12 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.primary_plots_refresh();
        }

        private void ytickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (ytickUD12.SelectedIndex)
            {
                case 0:
                    frm2.Y_tick12 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Y_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Y_tick12 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Y_tick12 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.primary_plots_refresh();
        }

        private void yInterval_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_interval12 = (double)yInterval_UD12.Value; frm2.primary_plots_refresh();
        }

        private void x_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xmajor_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xmajor_grid12 = LineStyle.Solid;
                    break;
            }
            frm2.primary_plots_refresh();
        }

        private void x_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xminor_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xminor_grid12 = LineStyle.Solid;
                    break;

            }
            frm2.primary_plots_refresh();
        }

        private void y_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Ymajor_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Ymajor_grid12 = LineStyle.Solid;
                    break;

            }
            frm2.primary_plots_refresh();
        }

        private void y_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Yminor_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Yminor_grid12 = LineStyle.Solid;
                    break;

            }
            frm2.primary_plots_refresh();
        }

        private void formatY_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (formatY_UD12.SelectedIndex)
            {
                case 0:
                    frm2.y_format12 = "G";
                    break;
                case 1:
                    frm2.y_format12 = "E";
                    break;
            }
            frm2.primary_plots_refresh();
        }

        private void formatY_numUD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_numformat12 = formatY_numUD12.Value.ToString(); frm2.primary_plots_refresh();
        }

        private void xstepminor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_minorStep12 = (double)xstepminor_UD12.Value; frm2.primary_plots_refresh();
        }

        private void xstepmajor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_majorStep12 = (double)xstepmajor_UD12.Value; frm2.primary_plots_refresh();
        }

        private void bar_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.bar_width = (double)bar_numUD.Value; frm2.primary_plots_refresh();
        }

        #endregion

        #region tab format charge plot
        private void x_charge_tickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_charge_tickUD12.SelectedIndex)
            {
                case 0:
                    frm2.X_charge_tick12 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.X_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.X_charge_tick12 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.X_charge_tick12 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }

        private void y_charge_tickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_charge_tickUD12.SelectedIndex)
            {
                case 0:
                    frm2.Y_charge_tick12 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Y_charge_tick12 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Y_charge_tick12 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Y_charge_tick12 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }

        private void x_charge_stepminor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_charge_minorStep12 = (double)x_charge_stepminor_UD12.Value;frm2.primary_plots_refresh(true);
        }

        private void x_charge_stepmajor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_charge_majorStep12 = (double)x_charge_stepmajor_UD12.Value;frm2.primary_plots_refresh(true);
        }

        private void y_charge_stepminor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_charge_minorStep12 = (double)y_charge_stepminor_UD12.Value;frm2.primary_plots_refresh(true);
        }

        private void y_charge_stepmajor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_charge_majorStep12 = (double)y_charge_stepmajor_UD12.Value;frm2.primary_plots_refresh(true);
        }

        private void x_charge_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_charge_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xmajor_charge_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xmajor_charge_grid12 = LineStyle.Solid;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }

        private void x_charge_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_charge_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xminor_charge_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xminor_charge_grid12 = LineStyle.Solid;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }

        private void y_charge_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_charge_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Ymajor_charge_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Ymajor_charge_grid12 = LineStyle.Solid;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }

        private void y_charge_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_charge_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Yminor_charge_grid12 = LineStyle.None;
                    break;
                case 1:
                    frm2.Yminor_charge_grid12 = LineStyle.Solid;
                    break;
            }
            frm2.primary_plots_refresh(true);
        }
        #endregion
    }
}
