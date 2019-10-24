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
        /// [Ai sort,A sort,di sort]
        /// </summary>
        public static bool[] sort = new bool[3];
        /// <summary>
        /// [Ai thres,A thres,di thres]
        /// </summary>
        public static double[] thres = new double[3];
        public static double a;
        public static int vis_res;
       

        public Form6(bool node,int node_idx)
        {
            InitializeComponent();
            numericUpDown1.Value = (decimal)Form2.visible_results;
            vis_res= Form2.visible_results;
            if (node)
            {
                is_node = true;idx = node_idx;
                Ai_coef_numUD.Value = A_coef_numUD.Value =(decimal) Form2.tab_coef[idx] ;
                Ai_checkBox.Checked = Form2.tab_node[idx][0];
                A_checkBox.Checked = Form2.tab_node[idx][1] ;
                di_checkBox.Checked = Form2.tab_node[idx][2];
                Ai_numUD.Value = (decimal)Form2.tab_thres[idx][0];
                A_numUD.Value = (decimal)Form2.tab_thres[idx][1];
                di_numUD.Value = (decimal)Form2.tab_thres[idx][2];
                a= Form2.tab_coef[idx];
                sort[0] = Form2.tab_node[idx][0];
                sort[1] = Form2.tab_node[idx][1];
                sort[2] = Form2.tab_node[idx][2];
                thres[0] = Form2.tab_thres[idx][0];
                thres[1] = Form2.tab_thres[idx][1];
                thres[2] = Form2.tab_thres[idx][2];
            }
            else
            {
                Ai_coef_numUD.Value=A_coef_numUD.Value = (decimal)Form2.a_coef;
                Ai_checkBox.Checked = Form2.fit_sort[0];
                A_checkBox.Checked= Form2.fit_sort[1];
                di_checkBox.Checked= Form2.fit_sort[2];
                Ai_numUD.Value= (decimal)Form2.fit_thres[0];
                A_numUD.Value =  (decimal)Form2.fit_thres[1];
                di_numUD.Value =  (decimal)Form2.fit_thres[2];
                a= Form2.a_coef;
                sort[0] = Form2.fit_sort[0];
                sort[1] = Form2.fit_sort[1];
                sort[2] = Form2.fit_sort[2];
                thres[0] = Form2.fit_thres[0];
                thres[1] = Form2.fit_thres[1];
                thres[2] = Form2.fit_thres[2];
            }
        }
       
        private void Ai_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (A_checkBox.Checked==true)Ai_checkBox.Checked = false;
            else if (Ai_checkBox.Checked == true && di_checkBox.Checked == true) { labelAi.Enabled = true; Ai_coef_numUD.Enabled = true; Ai_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labelAi.Enabled = false; Ai_coef_numUD.Enabled = false; Ai_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; }
            sort[0]= Ai_checkBox.Checked;
        }

        private void A_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Ai_checkBox.Checked == true) A_checkBox.Checked = false;            
            else if(A_checkBox.Checked == true && di_checkBox.Checked==true){labelA.Enabled = true;A_coef_numUD.Enabled = true; A_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else {labelA.Enabled = false; A_coef_numUD.Enabled = false; A_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; }
            sort[1] = A_checkBox.Checked;
        }

        private void di_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(di_checkBox.Checked == true && Ai_checkBox.Checked == true) { labelAi.Enabled = true; Ai_coef_numUD.Enabled = true; Ai_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else if(di_checkBox.Checked == true && A_checkBox.Checked == true) { labelA.Enabled = true; A_coef_numUD.Enabled = true; A_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labelA.Enabled = false; A_coef_numUD.Enabled = false; A_coef_numUD.BackColor = DefaultBackColor; labelAi.Enabled = false; Ai_coef_numUD.Enabled = false; Ai_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; }
            sort[2] = di_checkBox.Checked;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            vis_res = (int)numericUpDown1.Value;
        }

        private void numericUpDownAi_ValueChanged(object sender, EventArgs e)
        {
            a = (double)Ai_coef_numUD.Value;
        }

        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            a = (double)A_coef_numUD.Value;
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

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_node)
            {
                Form2.tab_coef[idx] = a;
                Form2.tab_node[idx][0] = sort[0];
                Form2.tab_node[idx][1] = sort[1];
                Form2.tab_node[idx][2] = sort[2];
                Form2.tab_thres[idx][0] = thres[0];
                Form2.tab_thres[idx][1] = thres[1];
                Form2.tab_thres[idx][2] = thres[2];                
            }
            else
            {
                Form2.a_coef=a;
                Form2.fit_sort[0]=sort[0];
                Form2.fit_sort[1]= sort[1];
                Form2.fit_sort[2]= sort[2];
                Form2.fit_thres[0]=thres[0];
                Form2.fit_thres[1]= thres[1];
                Form2.fit_thres[2]= thres[2];
                Form2.visible_results = vis_res;
            }
        }
    }
}
