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
    public partial class Form6 : Form
    {
        bool is_node = false;
        int idx ;
        /// <summary>
        /// [Ai sort,A sort,di sort,sse sort]
        /// </summary>
       bool[] sort = new bool[] { false, false, false, false };
        /// <summary>
        /// [Ai thres,A thres,di thres,ci thres]
        /// </summary>
        double[] thres = new double[4] { 100,100,100,100};
        double[] coeff_matrix=new double[4] {0,0,0,0 };
        int vis_res;
       

        public Form6(bool node,int node_idx)
        {
            InitializeComponent();
            numericUpDown1.Value = (decimal)Form2.visible_results;
            vis_res= Form2.visible_results;
            if (node)
            {
                is_node = true;idx = node_idx;
                Ai_coef_numUD.Value = (decimal)Form2.tab_coef[idx][0];
                A_coef_numUD.Value = (decimal)Form2.tab_coef[idx][1];                                
                di_coef_numUD.Value =  (decimal)Form2.tab_coef[idx][2];
                sse_coef_numUD.Value = (decimal)Form2.tab_coef[idx][3];

                Ai_checkBox.Checked = Form2.tab_node[idx][0];
                A_checkBox.Checked = Form2.tab_node[idx][1] ;
                di_checkBox.Checked = Form2.tab_node[idx][2];
                sse_checkBox.Checked = Form2.tab_node[idx][3];
                Ai_numUD.Value = (decimal)Form2.tab_thres[idx][0];
                A_numUD.Value = (decimal)Form2.tab_thres[idx][1];
                di_numUD.Value = (decimal)Form2.tab_thres[idx][2];
                ci_numUD.Value = (decimal)Form2.tab_thres[idx][3];

                coeff_matrix[0]= Form2.tab_coef[idx][0];
                coeff_matrix[1] = Form2.tab_coef[idx][1];
                coeff_matrix[2] = Form2.tab_coef[idx][2];
                coeff_matrix[3] = Form2.tab_coef[idx][3];

                sort[0] = Form2.tab_node[idx][0];
                sort[1] = Form2.tab_node[idx][1];
                sort[2] = Form2.tab_node[idx][2];
                sort[3] = Form2.tab_node[idx][3];
                thres[0] = Form2.tab_thres[idx][0];
                thres[1] = Form2.tab_thres[idx][1];
                thres[2] = Form2.tab_thres[idx][2];
                thres[3] = Form2.tab_thres[idx][3];

            }
            else
            {
                Ai_coef_numUD.Value = (decimal)Form2.a_coef[0];
                A_coef_numUD.Value = (decimal)Form2.a_coef[1];
                di_coef_numUD.Value = (decimal)Form2.a_coef[2];
                sse_coef_numUD.Value = (decimal)Form2.a_coef[3];
                Ai_checkBox.Checked = Form2.fit_sort[0];
                A_checkBox.Checked= Form2.fit_sort[1];
                di_checkBox.Checked= Form2.fit_sort[2];
                sse_checkBox.Checked = Form2.fit_sort[3];
                Ai_numUD.Value= (decimal)Form2.fit_thres[0];
                A_numUD.Value =  (decimal)Form2.fit_thres[1];
                di_numUD.Value =  (decimal)Form2.fit_thres[2];
                ci_numUD.Value = (decimal)Form2.fit_thres[3];

                coeff_matrix[0]= Form2.a_coef[0];
                coeff_matrix[1] = Form2.a_coef[1];
                coeff_matrix[2] = Form2.a_coef[2];
                coeff_matrix[3] = Form2.a_coef[3];

                sort[0] = Form2.fit_sort[0];
                sort[1] = Form2.fit_sort[1];
                sort[2] = Form2.fit_sort[2];
                sort[3] = Form2.fit_sort[3];
                thres[0] = Form2.fit_thres[0];
                thres[1] = Form2.fit_thres[1];
                thres[2] = Form2.fit_thres[2];
                thres[3] = Form2.fit_thres[3];

            }
            vital_refresh();
        }
       
        private void Ai_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Ai_checkBox.Checked==true) { labelAi.Enabled = true; Ai_coef_numUD.Enabled = true; Ai_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }           
            else { labelAi.Enabled = false; Ai_coef_numUD.Enabled = false; Ai_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; Ai_coef_numUD.Value = 0; }
            sort[0]= Ai_checkBox.Checked;
        }

        private void A_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (A_checkBox.Checked == true) { labelA.Enabled = true; A_coef_numUD.Enabled = true; A_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labelA.Enabled = false; A_coef_numUD.Enabled = false; A_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; A_coef_numUD.Value = 0; }
            sort[1] = A_checkBox.Checked;
        }

        private void di_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (di_checkBox.Checked == true) { labeldi.Enabled = true; di_coef_numUD.Enabled = true; di_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labeldi.Enabled = false; di_coef_numUD.Enabled = false; di_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; di_coef_numUD.Value = 0; }
            sort[2] = di_checkBox.Checked;
        }
        private void sse_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sse_checkBox.Checked == true) { labelsse.Enabled = true; sse_coef_numUD.Enabled = true; sse_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labelsse.Enabled = false; sse_coef_numUD.Enabled = false; sse_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; sse_coef_numUD.Value = 0; }
            sort[3] = sse_checkBox.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            vis_res = (int)numericUpDown1.Value;
        }
        private void Ai_coef_numUD_ValueChanged(object sender, EventArgs e)
        {
            coeff_matrix[0] = (double)Ai_coef_numUD.Value;
        }
        private void A_coef_numUD_ValueChanged(object sender, EventArgs e)
        {
            coeff_matrix[1] = (double)A_coef_numUD.Value;
        }
        private void di_coef_numUD_ValueChanged(object sender, EventArgs e)
        {
            coeff_matrix[2] = (double)di_coef_numUD.Value;
        }
        private void sse_coef_numUD_ValueChanged(object sender, EventArgs e)
        {
            coeff_matrix[3] = (double)sse_coef_numUD.Value;
        }
        private void Ai_numUD_ValueChanged(object sender, EventArgs e)
        {
            thres[0] = (double)Ai_numUD.Value;
        }
        private void A_numUD_ValueChanged(object sender, EventArgs e)
        {
            thres[1] = (double)A_numUD.Value;
        }
        private void di_numUD_ValueChanged(object sender, EventArgs e)
        {
           thres[2] = (double)di_numUD.Value;
        }
        private void vital_refresh()
        {
            for (int i=0;i<4 ;i++)
            {
                if (sort[i] == false) { coeff_matrix[i] = 0; }
                else if (coeff_matrix[i] == 0) { sort[i] = false; }
            }
        }
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            vital_refresh();
            if (is_node)
            {
                Form2.tab_coef[idx] = coeff_matrix;
                Form2.tab_node[idx][0] = sort[0];
                Form2.tab_node[idx][1] = sort[1];
                Form2.tab_node[idx][2] = sort[2];
                Form2.tab_node[idx][3] = sort[3];
               
                Form2.tab_thres[idx][0] = thres[0];
                Form2.tab_thres[idx][1] = thres[1];
                Form2.tab_thres[idx][2] = thres[2];  
                Form2.tab_thres[idx][3] = thres[3];

            }
            else
            {
                Form2.a_coef=coeff_matrix;
                Form2.fit_sort[0]=sort[0];
                Form2.fit_sort[1]= sort[1];
                Form2.fit_sort[2]= sort[2];
                Form2.fit_sort[3] = sort[3];

                Form2.fit_thres[0]=thres[0];
                Form2.fit_thres[1]= thres[1];
                Form2.fit_thres[2]= thres[2];
                Form2.fit_thres[3] = thres[3];

                Form2.visible_results = vis_res;
            }
        }

        private void ci_numUD_ValueChanged(object sender, EventArgs e)
        {
            thres[3] = (double)ci_numUD.Value;
        }
    }
}
