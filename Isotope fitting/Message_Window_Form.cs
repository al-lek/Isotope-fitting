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
    public partial class Message_Window_Form : Form
    {
        string message ="";      
        public Message_Window_Form(string m,bool is_seq=false, bool is_rik=false)
        {
            InitializeComponent();            
            message = m;
            textBox1.Text = message;
            if (is_seq) color_primay_frag(is_rik);
        }
         private void color_primay_frag(bool is_riken)
         {
            int counter = 3;
            if (is_riken) counter = 4;
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                string text = textBox1.Lines[i];
                if (text.StartsWith("a"))
                {
                    color_char(i, counter);
                    i = i + counter + 1;
                }                
            }
         }
        private void color_char(int i,int counter)
        {
            List<Color> clr1 = new List<Color>() { Color.Green, Color.Blue, Color.Firebrick, Color.DeepPink };
            List<Color> clr2 = new List<Color>() { Color.LimeGreen, Color.DodgerBlue, Color.Tomato, Color.HotPink };          
            
            for (int c=0;c<counter ;c++)
            {
                bool first = true;
                string text = textBox1.Lines[i+c];
                int curr_index = textBox1.GetFirstCharIndexFromLine(i+c);
                textBox1.Select(curr_index, text.Length);
                for (int t=0;t<text.Length ;t++)
                {
                    if (Char.IsLetter(text,t))
                    {
                        textBox1.Select(curr_index,1);
                        if (first) { textBox1.SelectionColor = clr1[c]; first = false; } else { textBox1.SelectionColor = clr2[c]; break; }
                    }
                    curr_index++;
                }
            }           
        }
        private void Form17_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            this.PerformAutoScale();
        }
    }
}
