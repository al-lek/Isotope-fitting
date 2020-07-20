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
    public partial class Form22 : Form
    {
        Form2 frm2;
        public Form22(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            x_ppm_stepminor_UD.Value = (decimal)frm2.x_ppm_interval;
            y_ppm_stepminor_UD.Value = (decimal)frm2.y_ppm_minorStep;
            y_ppm_stepmajor_UD.Value = (decimal)frm2.y_ppm_majorStep;
            bullet_size_numUD.Value = (decimal)frm2.ppm_bullet_size;
            end_valUD.Value = (decimal)frm2.last_m_z;
            start_valUD.Value = (decimal)frm2.first_m_z;

            if (frm2.ppm_graph_type == 2) mz_rdBtn.Checked = true;
            else number_rdBtn.Checked = true;
        }

        private void mz_rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (mz_rdBtn.Checked) { mz_rdBtn.ForeColor = Color.SlateBlue; frm2.ppm_graph_type = 2; }
            else mz_rdBtn.ForeColor = Color.Black;
        }

        private void number_rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (number_rdBtn.Checked) { number_rdBtn.ForeColor = Color.SlateBlue; frm2.ppm_graph_type = 1; }
            else number_rdBtn.ForeColor = Color.Black;
        }

        private void x_ppm_tickUD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_ppm_tickUD.SelectedIndex)
            {
                case 0:
                    frm2.X_ppm_tick = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.X_ppm_tick = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.X_ppm_tick = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.X_ppm_tick = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.ppm_plot_refresh();
        }

        private void y_ppm_tickUD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_ppm_tickUD.SelectedIndex)
            {
                case 0:
                    frm2.Y_ppm_tick = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Y_ppm_tick = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Y_ppm_tick = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Y_ppm_tick = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
            frm2.ppm_plot_refresh();

        }

        private void x_ppm_stepminor_UD_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_ppm_interval = (double)x_ppm_stepminor_UD.Value;
            frm2.ppm_plot_refresh();
        }

       

        private void y_ppm_stepminor_UD_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_ppm_minorStep = (double)y_ppm_stepminor_UD.Value;
            frm2.ppm_plot_refresh();
        }

        private void y_ppm_stepmajor_UD_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_ppm_majorStep = (double)y_ppm_stepmajor_UD.Value;
            frm2.ppm_plot_refresh();
        }

        private void x_ppm_majorGrid_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_ppm_majorGrid_UD.SelectedIndex)
            {
                case 0:
                    frm2.Xmajor_ppm_grid = LineStyle.None;
                    break;
                case 1:
                    frm2.Xmajor_ppm_grid = LineStyle.Solid;
                    break;
            }
            frm2.ppm_plot_refresh();
        }

        private void x_ppm_minorGrid_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_ppm_minorGrid_UD.SelectedIndex)
            {
                case 0:
                    frm2.Xminor_ppm_grid = LineStyle.None;
                    break;
                case 1:
                    frm2.Xminor_ppm_grid = LineStyle.Solid;
                    break;
            }
            frm2.ppm_plot_refresh();
        }

        private void y_ppm_majorGrid_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_ppm_majorGrid_UD.SelectedIndex)
            {
                case 0:
                    frm2.Ymajor_ppm_grid = LineStyle.None;
                    break;
                case 1:
                    frm2.Ymajor_ppm_grid = LineStyle.Solid;
                    break;
            }
            frm2.ppm_plot_refresh();
        }

        private void y_ppm_minorGrid_UD_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_ppm_minorGrid_UD.SelectedIndex)
            {
                case 0:
                    frm2.Yminor_ppm_grid = LineStyle.None;
                    break;
                case 1:
                    frm2.Yminor_ppm_grid = LineStyle.Solid;
                    break;
            }
            frm2.ppm_plot_refresh();
        }

        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            frm2.tabs_plots_replot();
        }

        private void bullet_size_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.ppm_bullet_size= (double)bullet_size_numUD.Value;
        }

        private void start_valUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.first_m_z = (double)start_valUD.Value;

        }

        private void end_valUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.last_m_z = (double)end_valUD.Value;
        }
    }
}
