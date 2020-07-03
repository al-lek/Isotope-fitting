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
    public partial class Form6 : Form
    {
        bool is_node = false;
        int idx ;
        /// <summary>
        /// [Ai sort,A sort,di sort,sse sort, ei sort, dinew sort](6)
        /// </summary>
        bool[] sort = new bool[6] { false, false, false, false,false,false };
        /// <summary>
        /// [Ai thres,A thres,di thres,ei thres,dinew thres, sd, sdnew](7)
        /// </summary>
        double[] thres = new double[7] { 100,100,100,100,100, 100, 100 };
        double[] coeff_matrix=new double[6] {0.0,0.0,0.0,0.0,0.0,0.0 };
        int vis_res;
        int best_num;
       

        public Form6(bool node,int node_idx)
        {
            InitializeComponent();
            numericUpDown1.TextChanged += new EventHandler(numericUpDown1_TextChanged);
            best_num_UD.TextChanged += new EventHandler(best_num_UD_TextChanged);
            Ai_coef_numUD.TextChanged += new EventHandler(Ai_coef_numUD_TextChanged);
            A_coef_numUD.TextChanged += new EventHandler(A_coef_numUD_TextChanged);
            di_coef_numUD.TextChanged += new EventHandler(di_coef_numUD_TextChanged);
            sse_coef_numUD.TextChanged += new EventHandler(sse_coef_numUD_TextChanged);
            ei_coef_numUD.TextChanged += new EventHandler(ei_coef_numUD_TextChanged);
            dinew_coef_numUD.TextChanged += new EventHandler(dinew_coef_numUD_TextChanged);
            Ai_numUD.TextChanged += new EventHandler(Ai_numUD_TextChanged);
            A_numUD.TextChanged += new EventHandler(A_numUD_TextChanged);
            di_numUD.TextChanged += new EventHandler(di_numUD_TextChanged);
            ei_numUD.TextChanged += new EventHandler(ei_numUD_TextChanged);
            dinew_numUD.TextChanged += new EventHandler(dinew_numUD_TextChanged);
            sd_numUD.TextChanged += new EventHandler(sd_numUD_TextChanged);
            sdnew_numUD.TextChanged += new EventHandler(sdnew_numUD_TextChanged);

            numericUpDown1.Value = (decimal)Form2.visible_results;
            best_num_UD.Value = (decimal)Form2.best_num_results;

            vis_res = Form2.visible_results;
            best_num = Form2.best_num_results;

            if (node)
            {
                is_node = true;idx = node_idx;
                Ai_coef_numUD.Value = (decimal)Form2.tab_coef[idx][0];
                A_coef_numUD.Value = (decimal)Form2.tab_coef[idx][1];                                
                di_coef_numUD.Value =  (decimal)Form2.tab_coef[idx][2];
                sse_coef_numUD.Value = (decimal)Form2.tab_coef[idx][3];
                ei_coef_numUD.Value = (decimal)Form2.tab_coef[idx][4];
                dinew_coef_numUD.Value = (decimal)Form2.tab_coef[idx][5];


                Ai_checkBox.Checked = Form2.tab_node[idx][0];
                A_checkBox.Checked = Form2.tab_node[idx][1] ;
                di_checkBox.Checked = Form2.tab_node[idx][2];
                sse_checkBox.Checked = Form2.tab_node[idx][3];
                ei_checkBox.Checked = Form2.tab_node[idx][4];
                dinew_checkBox.Checked = Form2.tab_node[idx][5];



                Ai_numUD.Value = (decimal)Form2.tab_thres[idx][0];
                A_numUD.Value = (decimal)Form2.tab_thres[idx][1];
                di_numUD.Value = (decimal)Form2.tab_thres[idx][2];
                ei_numUD.Value = (decimal)Form2.tab_thres[idx][3];
                dinew_numUD.Value = (decimal)Form2.tab_thres[idx][4];
                sd_numUD.Value = (decimal)Form2.tab_thres[idx][5];
                sdnew_numUD.Value = (decimal)Form2.tab_thres[idx][6];


                coeff_matrix[0]= Form2.tab_coef[idx][0];
                coeff_matrix[1] = Form2.tab_coef[idx][1];
                coeff_matrix[2] = Form2.tab_coef[idx][2];
                coeff_matrix[3] = Form2.tab_coef[idx][3];
                coeff_matrix[4] = Form2.tab_coef[idx][4];
                coeff_matrix[5] = Form2.tab_coef[idx][5];


                sort[0] = Form2.tab_node[idx][0];
                sort[1] = Form2.tab_node[idx][1];
                sort[2] = Form2.tab_node[idx][2];
                sort[3] = Form2.tab_node[idx][3];
                sort[4] = Form2.tab_node[idx][4];
                sort[5] = Form2.tab_node[idx][5];

                thres[0] = Form2.tab_thres[idx][0];
                thres[1] = Form2.tab_thres[idx][1];
                thres[2] = Form2.tab_thres[idx][2];
                thres[3] = Form2.tab_thres[idx][3];
                thres[4] = Form2.tab_thres[idx][4];
                thres[5] = Form2.tab_thres[idx][5];
                thres[6] = Form2.tab_thres[idx][6];



            }
            else
            {
                Ai_coef_numUD.Value = (decimal)Form2.a_coef[0];
                A_coef_numUD.Value = (decimal)Form2.a_coef[1];
                di_coef_numUD.Value = (decimal)Form2.a_coef[2];
                sse_coef_numUD.Value = (decimal)Form2.a_coef[3];
                ei_coef_numUD.Value = (decimal)Form2.a_coef[4];
                dinew_coef_numUD.Value = (decimal)Form2.a_coef[5];


                Ai_checkBox.Checked = Form2.fit_sort[0];
                A_checkBox.Checked= Form2.fit_sort[1];
                di_checkBox.Checked= Form2.fit_sort[2];
                sse_checkBox.Checked = Form2.fit_sort[3];
                ei_checkBox.Checked = Form2.fit_sort[4];
                dinew_checkBox.Checked = Form2.fit_sort[5];

                Ai_numUD.Value= (decimal)Form2.fit_thres[0];
                A_numUD.Value =  (decimal)Form2.fit_thres[1];
                di_numUD.Value =  (decimal)Form2.fit_thres[2];
                ei_numUD.Value = (decimal)Form2.fit_thres[3];
                dinew_numUD.Value = (decimal)Form2.fit_thres[4];
                sd_numUD.Value = (decimal)Form2.fit_thres[5];
                sdnew_numUD.Value = (decimal)Form2.fit_thres[6];



                coeff_matrix[0]= Form2.a_coef[0];
                coeff_matrix[1] = Form2.a_coef[1];
                coeff_matrix[2] = Form2.a_coef[2];
                coeff_matrix[3] = Form2.a_coef[3];
                coeff_matrix[4] = Form2.a_coef[4];
                coeff_matrix[5] = Form2.a_coef[5];



                sort[0] = Form2.fit_sort[0];
                sort[1] = Form2.fit_sort[1];
                sort[2] = Form2.fit_sort[2];
                sort[3] = Form2.fit_sort[3];
                sort[4] = Form2.fit_sort[4];
                sort[5] = Form2.fit_sort[5];

                thres[0] = Form2.fit_thres[0];
                thres[1] = Form2.fit_thres[1];
                thres[2] = Form2.fit_thres[2];
                thres[3] = Form2.fit_thres[3];
                thres[4] = Form2.fit_thres[4];
                thres[5] = Form2.fit_thres[5];
                thres[6] = Form2.fit_thres[6];

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
        private void ei_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ei_checkBox.Checked == true) { labelei.Enabled = true; ei_coef_numUD.Enabled = true; ei_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labelei.Enabled = false; ei_coef_numUD.Enabled = false; ei_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; ei_coef_numUD.Value = 0; }
            sort[4] = ei_checkBox.Checked;
        }
        private void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
            //vis_res = (int)numericUpDown1.Value;
            if (numericUpDown1.ActiveControl != null && !string.IsNullOrEmpty(numericUpDown1.ActiveControl.Text))
            {
                if (string.IsNullOrEmpty(numericUpDown1.ActiveControl.Text)) vis_res = 0;
                int[] temp = numUD_to_int_number(numericUpDown1);
                if (temp[1] == 1) vis_res = temp[0];
            }
        }
        private void Ai_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[0] = (double)Ai_coef_numUD.Value;
            if (Ai_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(Ai_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[0] = double.Parse(Ai_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(Ai_coef_numUD);
                if(temp[1]==1) coeff_matrix[0] = temp[0];               
            }
        }
        private void A_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[1] = (double)A_coef_numUD.Value;
            if (A_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(A_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[1] = double.Parse(A_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(A_coef_numUD);
                if (temp[1] == 1) coeff_matrix[1] = temp[0];
            }
        }
        private void di_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[2] = (double)di_coef_numUD.Value;
            if (di_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(di_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[2] = double.Parse(di_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(di_coef_numUD);
                if (temp[1] == 1) coeff_matrix[2] = temp[0];
            }
        }
        private void sse_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[3] = (double)sse_coef_numUD.Value;
            if (sse_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(sse_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[3] = double.Parse(sse_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(sse_coef_numUD);
                if (temp[1] == 1) coeff_matrix[3] = temp[0];
            }
        }
        private void ei_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[4] = (double)ei_coef_numUD.Value;
            if (ei_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(ei_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[4] = double.Parse(ei_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(ei_coef_numUD);
                if (temp[1] == 1) coeff_matrix[4] = temp[0]; 
            }
        }
        private void dinew_coef_numUD_TextChanged(object sender, EventArgs e)
        {
            //coeff_matrix[5] = (double)dinew_coef_numUD.Value;
            if (dinew_coef_numUD.ActiveControl != null && !string.IsNullOrEmpty(dinew_coef_numUD.ActiveControl.Text))
            {
                //coeff_matrix[5] = double.Parse(dinew_coef_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(dinew_coef_numUD);
                if (temp[1] == 1) coeff_matrix[5] = temp[0];
            }
        }
        private void Ai_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[0] = (double)Ai_numUD.Value;
            if (Ai_numUD.ActiveControl != null && !string.IsNullOrEmpty(Ai_numUD.ActiveControl.Text))
            {
                //thres[0] = double.Parse(Ai_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(Ai_numUD);
                if (temp[1] == 1) thres[0] = temp[0];
            }
        }
        private void A_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[1] = (double)A_numUD.Value;
            if (A_numUD.ActiveControl != null && !string.IsNullOrEmpty(A_numUD.ActiveControl.Text))
            {
                //thres[1] = double.Parse(A_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(A_numUD);
                if (temp[1] == 1) thres[1] = temp[0];
            }
        }
        private void di_numUD_TextChanged(object sender, EventArgs e)
        {
           //thres[2] = (double)di_numUD.Value;
            if (di_numUD.ActiveControl != null && !string.IsNullOrEmpty(di_numUD.ActiveControl.Text))
            {
                //thres[2] = double.Parse(di_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(di_numUD);
                if (temp[1] == 1) thres[2] = temp[0];
            }
        }
        private void ei_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[3] = (double)ei_numUD.Value;
            if (ei_numUD.ActiveControl != null && !string.IsNullOrEmpty(ei_numUD.ActiveControl.Text))
            {
                //thres[3] = double.Parse(ei_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(ei_numUD);
                if (temp[1] == 1) thres[3] = temp[0];
            }
        }
        private void dinew_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[4] = (double)dinew_numUD.Value;
            if (dinew_numUD.ActiveControl != null && !string.IsNullOrEmpty(dinew_numUD.ActiveControl.Text))
            {
                //thres[4] = double.Parse(dinew_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(dinew_numUD);
                if (temp[1] == 1) thres[4] = temp[0];
            }
        }
        private void vital_refresh()
        {
            for (int i=0;i<6 ;i++)
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
                Form2.tab_node[idx][4] = sort[4];
                Form2.tab_node[idx][5] = sort[5];


                Form2.tab_thres[idx][0] = thres[0];
                Form2.tab_thres[idx][1] = thres[1];
                Form2.tab_thres[idx][2] = thres[2];  
                Form2.tab_thres[idx][3] = thres[3];
                Form2.tab_thres[idx][4] = thres[4];
                Form2.tab_thres[idx][5] = thres[5];
                Form2.tab_thres[idx][6] = thres[6];

                Form2.visible_results = vis_res;
                Form2.best_num_results = best_num;
            }
            else
            {
                Form2.a_coef=coeff_matrix;
                Form2.fit_sort[0]=sort[0];
                Form2.fit_sort[1]= sort[1];
                Form2.fit_sort[2]= sort[2];
                Form2.fit_sort[3] = sort[3];
                Form2.fit_sort[4] = sort[4];
                Form2.fit_sort[5] = sort[5];


                Form2.fit_thres[0]=thres[0];
                Form2.fit_thres[1]= thres[1];
                Form2.fit_thres[2]= thres[2];
                Form2.fit_thres[3] = thres[3];
                Form2.fit_thres[4] = thres[4];
                Form2.fit_thres[5] = thres[5];
                Form2.fit_thres[6] = thres[6];

                Form2.visible_results = vis_res;
                Form2.best_num_results = best_num;
            }
        }

        private void dinew_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dinew_checkBox.Checked == true) { labeldinew.Enabled = true; dinew_coef_numUD.Enabled = true; dinew_coef_numUD.BackColor = Color.Teal; ObjLbl.Enabled = true; }
            else { labeldinew.Enabled = false; dinew_coef_numUD.Enabled = false; dinew_coef_numUD.BackColor = DefaultBackColor; ObjLbl.Enabled = false; dinew_coef_numUD.Value = 0; }
            sort[5] = dinew_checkBox.Checked;
        }

        private void best_num_UD_TextChanged(object sender, EventArgs e)
        {
            //best_num = (int)best_num_UD.Value;
            if (best_num_UD.ActiveControl != null && !string.IsNullOrEmpty(best_num_UD.ActiveControl.Text))
            {
                //best_num = int.Parse(best_num_UD.ActiveControl.Text);
                int[] temp = numUD_to_int_number(best_num_UD);
                if (temp[1] == 1) best_num = temp[0];                
            }
        }

        private void sd_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[5] = (double)sd_numUD.Value;
            if (sd_numUD.ActiveControl != null && !string.IsNullOrEmpty(sd_numUD.ActiveControl.Text))
            {
                //thres[5] = double.Parse(sd_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(sd_numUD);
                if (temp[1] == 1) thres[5] = temp[0];
            }
        }

        private void sdnew_numUD_TextChanged(object sender, EventArgs e)
        {
            //thres[6] = (double)sdnew_numUD.Value;
            if (sdnew_numUD.ActiveControl != null && !string.IsNullOrEmpty(sdnew_numUD.ActiveControl.Text))
            {
                //thres[6] = double.Parse(sdnew_numUD.ActiveControl.Text);
                double[] temp = numUD_to_double_number(sdnew_numUD);
                if (temp[1] == 1) thres[6] = temp[0];
            }
        }

        private void Form6_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
