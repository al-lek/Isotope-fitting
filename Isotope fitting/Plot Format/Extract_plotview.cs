using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;


namespace Isotope_fitting
{
    public partial class Extract_plotview : Form
    {
        bool text = false;
        PlotView plot = new PlotView();
        PlotView b_plot = new PlotView();
        bool is_double_plot = false;

        public Extract_plotview(PlotView p, PlotView p1,bool is_d=false)
        {
            InitializeComponent();
            plot = p;
            is_double_plot = is_d;
            if (is_double_plot)
            {
                b_plot = p1;
                plot.Height = panel_frm11.Height / 2;
                b_plot.Height = panel_frm11.Height / 2;
                plot.Dock = DockStyle.Top;
                b_plot.Dock = DockStyle.Bottom;
                panel_frm11.Controls.AddRange(new Control[] { plot, b_plot });
            }
            else
            {
                plot.Dock = DockStyle.Fill;
                panel_frm11.Controls.Add(plot);
            }
            x_Box.Text = panel_frm11.Size.Width.ToString();
            y_Box.Text = panel_frm11.Size.Height.ToString();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            if (is_double_plot) export_panel(false, panel_frm11);
            else export_copy_plot(false);
        }

        private void Copy_Btn_Click(object sender, EventArgs e)
        {
            if (is_double_plot)  export_panel(true, panel_frm11);
            else export_copy_plot(true);
        }
        private void export_copy_plot(bool copy)
        {
            var pngExporter = new PngExporter { Width = plot.Width, Height = plot.Height, Background = OxyColors.White };
            if (copy)
            {
                var bitmap = pngExporter.ExportToBitmap(plot.Model);
                Clipboard.SetImage(bitmap);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save plot image", FileName = "", Filter = "image file|*.png|all files|*.*", OverwritePrompt = true, AddExtension = true };
                if (save.ShowDialog() == DialogResult.OK) { pngExporter.ExportToFile(plot.Model, save.FileName); }
            }
        }
        private void export_panel(bool copy, Panel pnl)
        {
            int width = pnl.Size.Width;
            int height = pnl.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            pnl.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            if (copy)
            {
                Clipboard.SetImage(bm);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save image", FileName = "", Filter = "image file|*.png|all files|*.*", OverwritePrompt = true, AddExtension = true };
                if (save.ShowDialog() == DialogResult.OK) { bm.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png); }
            }
        }
        private void Form11_Resize(object sender, EventArgs e)
        {
            if (!text)
            {
                x_Box.Text = panel_frm11.Size.Width.ToString();
                y_Box.Text = panel_frm11.Size.Height.ToString();
            }
            else
            {
                text = false;
            }
        }

        private void Form11_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }

        private void x_Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double size_x = Double.Parse(x_Box.Text);
                    this.Width = (int)size_x + 59; text = true;
                }
                catch
                {
                    x_Box.Text = "";
                }
            }
              
        }

        private void y_Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {
                    double size_y = Double.Parse(y_Box.Text);
                    this.Height = (int)size_y + 39; text = true;

                }
                catch
                {
                    x_Box.Text = "";
                }
            }
          
        }

        private void panel_frm11_Resize(object sender, EventArgs e)
        {
            if (is_double_plot)
            {
                foreach (PlotView pp in panel_frm11.Controls)
                {
                    pp.Height = panel_frm11.Height / 2;
                }
            }           
        }
    }
}
