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
    public partial class Form15 : Form
    {
        PlotView plot = new PlotView();
        PlotView plotInt = new PlotView();
        public Form15(PlotView p,PlotView pint)
        {
            InitializeComponent();
            plot = p;  plotInt = pint;
            plot.Dock = DockStyle.Fill;  pint.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(plot);   splitContainer1.Panel2.Controls.Add(pint);
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            export_panel(false, panel_frm11);
        }

        private void Copy_Btn_Click(object sender, EventArgs e)
        {
            export_panel(true, panel_frm11);
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
    }
}
