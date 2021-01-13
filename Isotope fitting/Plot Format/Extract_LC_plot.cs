using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Arction.WinForms.Charting;
using Arction.WinForms.Charting.Axes;
using Arction.WinForms.Charting.SeriesXY;
using Arction.WinForms.Charting.EventMarkers;
using Arction.WinForms.Charting.Titles;
using Arction.WinForms.Charting.Views.ViewXY;
using Arction.WinForms.Charting.Annotations;
using System.Diagnostics;

namespace Isotope_fitting
{
    public partial class Extract_LC_plot : Form
    {
        bool text = false;
        LightningChartUltimate plot =new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { };
        public Extract_LC_plot(LightningChartUltimate p,double minx, double maxx, double miny, double maxy)
        {
            InitializeComponent();
            plot = p as LightningChartUltimate;            
            plot.Dock = DockStyle.Fill;
            plot.ViewXY.XAxes[0].SetRange(minx, maxx);
            plot.ViewXY.YAxes[0].SetRange(miny, maxy);
            panel_frm20.Controls.Add(plot);
            x_Box.Text = panel_frm20.Size.Width.ToString();
            y_Box.Text = panel_frm20.Size.Height.ToString();
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
            if (plot is LightningChartUltimate)
            {
                LightningChartUltimate chart = new LightningChartUltimate("Licensed User/LightningChart Ultimate SDK Full Version/LightningChartUltimate/5V2D2K3JP7Y4CL32Q68CYZ5JFS25LWSZA3W3") { };
                chart = plot as LightningChartUltimate;
                if (copy)
                {
                    try
                    {
                        chart.CopyToClipboard(ClipboardImageFormat.Png, null);
                        //chart.CopyToClipboard(ClipboardImageFormat.Emf, null);
                        //chart.CopyToClipboardAsEmf();
                    }
                    catch (Exception ex)
                    {
                        int width = panel_frm20.Size.Width;
                        int height = panel_frm20.Size.Height;
                        Bitmap bm = new Bitmap(width, height);
                        panel_frm20.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
                        Clipboard.SetImage(bm);
                        MessageBox.Show(ex.Message + " " + ex.InnerException);
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    SaveFileDialog ofd = new SaveFileDialog();
                    ofd.Filter = "Image files (*.gif;*.bmp;*.png;*.jpg;*.tif;*.emf;*.svg;*.wmf)|*.gif;*.bmp;*.png;*.jpg;*.tif;*.emf;*.svg;*.wmf|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (chart.SaveToFile(ofd.FileName) == false)
                            {
                                MessageBox.Show(this, "Save to file failed.", "Peak Finder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " " + ex.InnerException);
                        }
                    }
                }
            }
        
        }

        private void Extract_LC_plot_Resize(object sender, EventArgs e)
        {
            if (!text)
            {
                x_Box.Text = panel_frm20.Size.Width.ToString();
                y_Box.Text = panel_frm20.Size.Height.ToString();
            }
            else
            {
                text = false;
            }
        }

        private void Extract_LC_plot_DpiChanged(object sender, DpiChangedEventArgs e)
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
                    y_Box.Text = "";
                }
            }
        }
    }
}

