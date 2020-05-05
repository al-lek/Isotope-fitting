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
    public partial class Form23 : Form
    {
        Form2 frm2;
        Color temp_highlight_color ;
        public Form23(Form2 f)
        {
            InitializeComponent();
            frm2 = f;
            temp_highlight_color = frm2.highlight_color;
            hightlight_clr_Btn.BackColor = temp_highlight_color;
            rgb_rdBtn.Checked = frm2.is_rgb_color_range;
            hightColor_rdBtn.Checked = !frm2.is_rgb_color_range;
            max_numUD.Value = (decimal)frm2.seq_max_val;
            min_numUD.Value = (decimal)frm2.seq_min_val;
        }


        private void hightlight_clr_Btn_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                temp_highlight_color = clrDlg.Color;
                hightlight_clr_Btn.BackColor= temp_highlight_color;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            frm2.highlight_color = temp_highlight_color;
            frm2.seq_max_val = (Int64)max_numUD.Value; 
            frm2.seq_min_val = (Int64)min_numUD.Value;
            frm2.is_rgb_color_range = rgb_rdBtn.Checked;
        }
    }
}
