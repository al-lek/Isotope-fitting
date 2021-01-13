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
    public partial class Format_H_plot : Form
    {
        Form2 frm2;
        public Format_H_plot(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            yInterval_UD12.Value = (decimal)frm2.y_interval12_2;
            xstepminor_UD12.Value = (decimal)frm2.x_minorStep12_2;
            xstepmajor_UD12.Value = (decimal)frm2.x_majorStep12_2;
            line_numUD.Value = (decimal)frm2.line_width_2;
            foreach (int[] region in frm2.color_primary_indexes)
            {
                textBox1.Text += region[0] + "-" + region[1] + ",";
            }
            if (!String.IsNullOrEmpty(textBox1.Text)) { textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); }
        }

        private void color_Btn_Click(object sender, EventArgs e)
        {
            //ColorDialog clrDlg = new ColorDialog();
            if (Form2.clrDlg.ShowDialog() == DialogResult.OK)
            {
                frm2.color_primary = OxyColor.FromUInt32((uint)Form2.clrDlg.Color.ToArgb());
            }
        }

        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            frm2.color_primary_indexes.Clear();
            try
            {
                frm2.color_primary_indexes = return_regions_SS(textBox1.Text.ToString());
            }
            catch
            {
                MessageBox.Show("Please check your input. Fill the box with the numbers of the areas you want to be colored  e.g.1-3,6-8");
            }
            frm2.paint_annotations_in_graphs(false, 1, true);
            frm2.inval_style_Refresh_Btn();
        }

        private void xtickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (xtickUD12.SelectedIndex)
            {
                case 0:
                    frm2.X_tick12_2 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.X_tick12_2 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.X_tick12_2 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.X_tick12_2 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
        }

        private void xstepminor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_minorStep12_2 = (double)xstepminor_UD12.Value; 
        }

        private void xstepmajor_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.x_majorStep12_2 = (double)xstepmajor_UD12.Value;
        }

        private void x_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xmajor_grid12_2 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xmajor_grid12_2 = LineStyle.Solid;
                    break;
            }
        }

        private void x_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (x_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Xminor_grid12_2 = LineStyle.None;
                    break;
                case 1:
                    frm2.Xminor_grid12_2 = LineStyle.Solid;
                    break;

            }
        }

        private void ytickUD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (ytickUD12.SelectedIndex)
            {
                case 0:
                    frm2.Y_tick12_2 = OxyPlot.Axes.TickStyle.None;
                    break;
                case 1:
                    frm2.Y_tick12_2 = OxyPlot.Axes.TickStyle.Outside;
                    break;
                case 2:
                    frm2.Y_tick12_2 = OxyPlot.Axes.TickStyle.Inside;
                    break;
                case 3:
                    frm2.Y_tick12_2 = OxyPlot.Axes.TickStyle.Crossing;
                    break;
            }
        }

        private void yInterval_UD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_interval12_2 = (double)yInterval_UD12.Value;
        }

        private void y_majorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_majorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Ymajor_grid12_2 = LineStyle.None;
                    break;
                case 1:
                    frm2.Ymajor_grid12_2 = LineStyle.Solid;
                    break;

            }
        }

        private void y_minorGrid_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (y_minorGrid_UD12.SelectedIndex)
            {
                case 0:
                    frm2.Yminor_grid12_2 = LineStyle.None;
                    break;
                case 1:
                    frm2.Yminor_grid12_2 = LineStyle.Solid;
                    break;

            }
        }

        private void formatY_UD12_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (formatY_UD12.SelectedIndex)
            {
                case 0:
                    frm2.y_format12_2 = "G";
                    break;
                case 1:
                    frm2.y_format12_2 = "0.0E+";
                    break;
            }
        }

        private void formatY_numUD12_ValueChanged(object sender, EventArgs e)
        {
            frm2.y_numformat12_2 = formatY_numUD12.Value.ToString();
        }

        private void line_numUD_ValueChanged(object sender, EventArgs e)
        {
            frm2.line_width_2 = (double)line_numUD.Value;
        }
    }
}
