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
    public partial class Extract_int : Form
    {
        PlotView plot = new PlotView();
        PlotView plotInt = new PlotView();
        bool text = false;

        public Extract_int(PlotView p,PlotView pint)
        {
            InitializeComponent();
            plot = p;  plotInt = pint;
            plot.Dock = DockStyle.Fill;  pint.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(plot);   splitContainer1.Panel2.Controls.Add(pint);
            x_Box.Text = panel_frm11.Size.Width.ToString();
            y_Box.Text = panel_frm11.Size.Height.ToString();

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


        private void Extract_int_Resize(object sender, EventArgs e)
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

        private void Extract_int_DpiChanged(object sender, DpiChangedEventArgs e)
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
            if (e.KeyCode == Keys.Enter)
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
    }
}
