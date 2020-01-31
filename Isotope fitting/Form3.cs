using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Isotope_fitting
{
    public partial class Form3 : Form
    {
        public static HashSet<int> selected_windows_to_save = new HashSet<int>();
        public Form3()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            InitializeComponent();
            selected_windows_to_save.Clear();
            selected_windows_to_save.TrimExcess();
            sw_txtBox.KeyPress += (s, e) => { if (e.KeyChar == (char)13) { if (Find_selected_windows_to_save() == true) { Save_selected_windows(); this.Hide(); } } };

        }


        private bool Find_selected_windows_to_save()
         {
            if (!string.IsNullOrEmpty(sw_txtBox.Text))
            {
                selected_windows_to_save.Clear();
                selected_windows_to_save.TrimExcess();
                string[] inputs = Regex.Split(sw_txtBox.Text, ",");
                foreach (string word in inputs)
                {
                    if (word.Contains("-"))
                    {
                        string[] word_b = Regex.Split(word, "-");
                        try
                        {
                            int w_1 = int.Parse(word_b[0], NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat);
                            int w_2 = int.Parse(word_b[1], NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat);
                            if (w_1>Form2.window_count || w_2> Form2.window_count) { MessageBox.Show("The selected windows don't exist");return false;}
                            int to_ = w_1;
                            while (to_ <= w_2)
                            {
                                selected_windows_to_save.Add(to_-1);
                                to_++;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Please enter only integer numbers.");
                            sw_txtBox.Text =null;
                            return false;
                        }                        
                    }
                    else
                    {
                        try
                        {
                            int w_3 = int.Parse(word, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat);
                            if (w_3>Form2.window_count) {MessageBox.Show("The selected windows don't exist"); return false;}
                            selected_windows_to_save.Add(w_3-1);                            
                        }
                        catch
                        {
                            MessageBox.Show("Please enter only integer numbers.");
                            sw_txtBox.Text = null;
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
         }
        private void Sa_Btn_Click(object sender, EventArgs e)
        {
            sw_txtBox.Visible = false;
            if (Form2.window_count>1)
            {
                for (int w = 0; w < Form2.windowList.Count; w++)
                {
                    selected_windows_to_save.Add(w);
                }
                Save_selected_windows();
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = Form2.file_name, Filter = "Data Files (*.fit)|*.fit", DefaultExt = "fit", OverwritePrompt = true, AddExtension = true };

                //save.InitialDirectory = Application.StartupPath + "\\Data";
                //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
                //if (di.Exists != true) di.Create();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                    file.WriteLine("Mode:\texternal data");
                    file.WriteLine("AA Sequence:\t" );
                    file.WriteLine("Fitted isotopes:\t" + Form2.candidate_fragments.ToString());
                    file.WriteLine("m/z[Da]\tIntensity");
                    file.WriteLine();
                    file.WriteLine("Name:\tExp");
                    foreach (double[] p in Form2.all_data[0]) file.WriteLine(p[0] + "\t" + p[1]);
                    file.WriteLine();
                    foreach (FragForm fra in Form2.Fragments2)
                    {
                        file.WriteLine("Name:\t" + fra.Name);
                        file.WriteLine("Factor:\t" + fra.Factor);
                        file.WriteLine("Fix:\t" + fra.Fix);
                        file.WriteLine("Centroid:\t" + fra.Centroid[0].X + "\t" + fra.Centroid[0].Y);
                        file.WriteLine("ListViewItems:\t" + fra.ListName[0].ToString() + "\t" + fra.ListName[1].ToString() + "\t" + fra.ListName[2].ToString() + "\t" + fra.ListName[3].ToString());
                        file.WriteLine("Selected:\t" + fra.To_plot.ToString());
                        file.WriteLine("Color:\t" + fra.Color.ToColor().ToArgb());
                        foreach (double[] p in Form2.all_data[fra.Counter]) file.WriteLine(p[0] + "\t" + p[1]);
                        file.WriteLine();
                    }
                    file.Flush(); file.Close(); file.Dispose();
                }
            }
            this.Hide();
        }
        
        private void Save_selected_windows()
        {
            SaveFileDialog save = new SaveFileDialog() { Title = "Save fittng data", FileName = Form2.file_name , Filter = "Data Files (*.wf)|*.wf", DefaultExt = "wf", OverwritePrompt = true, AddExtension = true };

            //save.InitialDirectory = Application.StartupPath + "\\Data";
            //DirectoryInfo di = new DirectoryInfo(save.InitialDirectory);
            //if (di.Exists != true) di.Create();

            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.

                file.WriteLine("Mode:\texternal data");
                file.WriteLine("AA Sequence:\t" );
                file.WriteLine("Fitted isotopes:\t" + Form2.candidate_fragments.ToString());
                file.WriteLine("m/z[Da]\tIntensity");
                file.WriteLine();
                file.WriteLine("Name:\tExp");
                foreach (double[] p in Form2.selected_all_data[0]) file.WriteLine(p[0] + "\t" + p[1]);
                file.WriteLine();
                foreach (int w in selected_windows_to_save.OrderBy(p => p).ToList())
                {
                    file.WriteLine("Window:\t" + Form2.windowList[w].Code.ToString().ToString());
                    file.WriteLine("Starting:\t" + Form2.windowList[w].Starting);
                    file.WriteLine("Ending:\t" + Form2.windowList[w].Ending);                   
                    for (int i = 0; i < Form2.windowList[w].Mono_fragments.Count; i++)
                    {
                        int indexS = Form2.windowList[w].Mono_fragments[i];
                        file.WriteLine("Name:\t" + Form2.Fragments2[indexS - 1].Name);
                        file.WriteLine("Factor:\t" + Form2.Fragments2[indexS - 1].Factor);
                        file.WriteLine("Fix:\t" + Form2.Fragments2[indexS - 1].Fix);
                        file.WriteLine("Centroid:\t" + Form2.Fragments2[indexS - 1].Centroid[0].X + "\t" + Form2.Fragments2[indexS - 1].Centroid[0].Y);
                        file.WriteLine("ListViewItems:\t" + Form2.Fragments2[indexS - 1].ListName[0].ToString() + "\t" + Form2.Fragments2[indexS - 1].ListName[1].ToString() + "\t" + Form2.Fragments2[indexS - 1].ListName[2].ToString() + "\t" + Form2.Fragments2[indexS - 1].ListName[3].ToString());
                        file.WriteLine("Selected:\t" + Form2.Fragments2[indexS - 1].To_plot.ToString());
                        file.WriteLine("Color:\t" + Form2.Fragments2[indexS - 1].Color.ToColor().ToArgb());
                        foreach (double[] p in Form2.all_data[indexS]) file.WriteLine(p[0] + "\t" + p[1]);
                        file.WriteLine();
                    }
                }
                
                file.Flush(); file.Close(); file.Dispose();
            }
        }
        private void Sw_Btn_Click(object sender, EventArgs e)
        {
            sw_txtBox.Visible = true;
        }

        private void Ss_Btn_Click(object sender, EventArgs e)
        {
            sw_txtBox.Visible = false;
            selected_windows_to_save.Clear();
            selected_windows_to_save.TrimExcess();
            selected_windows_to_save.Add(Form2.selected_window);
            Save_selected_windows();
            this.Hide();
        }
    }
}
