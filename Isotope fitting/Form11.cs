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
    public partial class Form11 : Form
    {
        PlotView plot = new PlotView();
        public Form11(PlotView p)
        {
            InitializeComponent();
            plot = p;
            plot.Dock = DockStyle.Fill;
            panel_frm11.Controls.Add(plot);
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            export_copy_plot(false);
        }

        private void Copy_Btn_Click(object sender, EventArgs e)
        {
            export_copy_plot(true);
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
    }
}
