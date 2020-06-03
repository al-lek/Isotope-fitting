using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Isotope_fitting
{
    public class Helpers
    {
        /// <summary>
        /// Get the controls that are in the control c
        /// </summary>
        public static IEnumerable<Control> GetControls(Control c)
        {
            return new[] { c }.Concat(c.Controls.OfType<Control>().SelectMany(x => GetControls(x)));
        }
        /// <summary>
        /// Turn a string into a double
        /// </summary>
        public static double dParser(string t)
        {
            if (double.TryParse(t, out double d)) return d;

            return double.NaN;
        }
        /// <summary>
        /// Turn a string into an integer
        /// </summary>
        public static int iParser(string t)
        {
            // will reurn 0 on error
            if (int.TryParse(t, out int i)) return i;
            return i;
        }
        /// <summary>
        /// Turn the text into a textbox into a double
        /// </summary>
        public static double txt_to_d(TextBox txtBox)
        {
            if (double.TryParse(txtBox.Text, out double d)) return d;

            return double.NaN;
        }

        /// <summary>
        /// Turn a string into a bool
        /// </summary>
        public static bool string_to_bool(string str)
        {
            if (str == "True") return true;
            else return false;
        }

        /// <summary>
        /// Estimates memory size of objects. Returns size in MB
        /// </summary>
        public static long estimate_memory(object o)
        {
            // estimates memory size of objects. Returns size in MB
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }
            return size / 1048576;
        }

        /// <summary>
        /// Fix chemical formula, add or subduct 'H' 'H2O' 'NH3'
        /// </summary>
        public static string fix_formula(string input, bool simple = true, int h = -1, int h2o = 0, int nh3 = 0)
        {
            string formula = "";
            if (simple == true) { formula = find_index_fix_formula(input, h); return formula; }
            if (h2o != 0)
            {
                input = find_index_fix_formula(input, 2 * h2o, 'H');
                input = find_index_fix_formula(input, h2o, 'O');
            }
            if (nh3 != 0)
            {
                input = find_index_fix_formula(input, 3 * nh3, 'H');
                input = find_index_fix_formula(input, nh3, 'N');
            }
            formula = input;
            return formula;
        }

        /// <summary>
        /// Find the element's index in the chemical formula
        /// </summary>
        public static string find_index_fix_formula(string input, int amount = -1, char element = 'H')
        {
            int idx = input.IndexOf(element);
            if (idx < 0) return input;
            var theString = input;
            var aStringBuilder = new StringBuilder(theString);
            if (Char.IsNumber(input[idx + 2]))
            {
                if (input.Length > idx + 3 && Char.IsNumber(input[idx + 3]))
                {
                    if (input.Length > idx + 4 && Char.IsNumber(input[idx + 4]))
                    {
                        if (input.Length > idx + 5 && Char.IsNumber(input[idx + 5]))
                        {
                            input = replace_number_fix_formula(input, amount, idx + 1, 5);
                        }
                        else
                        {
                            input = replace_number_fix_formula(input, amount, idx + 1, 4);
                        }
                    }
                    else
                    {
                        input = replace_number_fix_formula(input, amount, idx + 1, 3);
                    }
                }
                else
                {
                    input = replace_number_fix_formula(input, amount, idx + 1, 2);
                }
            }
            else
            {
                input = replace_number_fix_formula(input, amount, idx + 1, 1);
            }
            return input;
        }

        /// <summary>
        ///Given the index of the number that indicates the amount of an element in the chemical formula, set the desired amount
        /// </summary>
        public static string replace_number_fix_formula(string input, int amount, int sub_index, int sub_length)
        {
            var theString = input;
            var aStringBuilder = new StringBuilder(theString);
            Int32.TryParse(theString.Substring(sub_index, sub_length), out int result);
            aStringBuilder.Remove(sub_index, sub_length);
            aStringBuilder.Insert(sub_index, (result + amount).ToString());
            if (result+amount<0)
            {
                MessageBox.Show(" ");
            }
            theString = aStringBuilder.ToString();
            input = theString;
            return input;
        }

        /// <summary>
        /// check the input of the desired indexes range in the textbox and create the indexes Lists with the desired indexes for the selected fragments
        /// </summary>
        public static void add_to_indexes_list(string textboxText, List<int[]> indexes)
        {
            string text = textboxText.Replace(" ", "");
            string[] str = text.Split(',');
            for (int a = 0; a < str.Length; a++)
            {
                string[] str2 = str[a].Split('-');
                if (str2.Length == 2) { indexes.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                if (str2.Length == 1) { indexes.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
            }
        }

        /// <summary>
        /// Uncheck all checked Lists in the calculation filter areas
        /// </summary>
        public static void un_check_all_checkboxes(Control container, bool check = false)
        {
            if (check)
            {
                foreach (CheckedListBox lstBox in GetControls(container).OfType<CheckedListBox>())
                {
                    for (int i = 0; i < lstBox.Items.Count; i++)
                    {
                        lstBox.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
            else
            {
                foreach (CheckedListBox lstBox in GetControls(container).OfType<CheckedListBox>())
                {
                    lstBox.ClearSelected();
                    foreach (int i in lstBox.CheckedIndices)
                    {
                        lstBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }

        /// <summary>
        /// check if the the textbox entry is a number
        /// </summary>
        public static void check_textBox_entry(TextBox box, bool is_integer = true, bool accept_negative = true)
        {
            if (!string.IsNullOrEmpty(box.Text))
            {
                if (!accept_negative || box.Text != "-")
                {
                    try
                    {
                        if (is_integer) { double.Parse(box.Text, NumberStyles.Integer); }
                        else { }
                    }
                    catch
                    {
                        MessageBox.Show("Please enter only numbers.");
                        box.Text = box.Text.Remove(box.Text.Length - 1);
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Empty textboxes and uncheck checkboxes in the container
        /// </summary>
        public static void set_textboxes_checks_empty(Control container)
        {            
            foreach (TextBox Box in GetControls(container).OfType<TextBox>())
            {
                Box.Text = string.Empty;
            }
            foreach (CheckBox Box in GetControls(container).OfType<CheckBox>())
            {
                Box.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// Check and uncheck checkboxes in the toolstrip container
        /// </summary>
        public static void toolstrip_checkboxes(Control container, bool check=true,string key_word="")
        {
            foreach (ToolStrip strip in GetControls(container).OfType<ToolStrip>().Where(l => l.Name.Contains(key_word)))
            {
                if (strip.Visible && !strip.Name.Equals("ppm_toolStrip"))
                {
                    foreach (ToolStripButton btn in strip.Items.OfType<ToolStripButton>().ToList())
                    {
                        if ( btn.CheckOnClick == true && btn.Checked!=check ) { btn.Checked = check; }
                    }
                }
            }
        }

        /// <summary>
        /// Temporary for riken check, will delete it later
        /// </summary>
        public static string fix_formula_temporary_only_O(string input,int h2o )
        {
            string formula = "";
            input = find_index_fix_formula(input, -h2o, 'O');

            formula = input;
            return formula;
        }

        /// <summary>
        /// For Exclude types feature, checks each input and add it in the list
        /// </summary>
        public static void check_item(Object item, List<ExcludeTypes> list, bool is_internal = false)
        {
            int index = -1;
            string exte = "", text = "", text1 = "", text2 = "";
            if (item is ListViewItem)
            {
                exte = (item as ListViewItem).SubItems[3].Text.ToString();
                text = (item as ListViewItem).SubItems[1].Text.ToString();
                text1 = (item as ListViewItem).SubItems[1].Text.ToString();
                text2 = (item as ListViewItem).SubItems[2].Text.ToString();
            }
            else if (item is string[])
            {
                text1 = (item as string[])[1];
                text2 = (item as string[])[2];
                text = (item as string[])[1];
                exte = (item as string[])[3];
            }
            else
            {
                MessageBox.Show("Error in exclude list"); return;
            }
            for (int t = 0; t < list.Count; t++)
            {
                if (list[t].Extension.Equals(exte)) { index = t; break; }
            }
            if (is_internal)
            {
                if (index < 0) { list.Add(new ExcludeTypes() { Extension = exte, Index2 = new List<int[]>(), Index1 = new List<int[]>() }); index = list.Count - 1; }
                if (!string.IsNullOrEmpty(text1))
                {
                    check_text_add_to_list(text1, list[index].Index1, index);
                }
                if (!string.IsNullOrEmpty(text2))
                {
                    check_text_add_to_list(text2, list[index].Index2, index);
                }
            }
            else
            {
                if (index < 0) { list.Add(new ExcludeTypes() { Extension = exte, Index1 = new List<int[]>() }); index = list.Count - 1; }
                if (!string.IsNullOrEmpty(text))
                {
                    check_text_add_to_list(text, list[index].Index1, index);
                }
            }
        }

        /// <summary>
        /// For Exclude types feature, checks each input and add it in the list
        /// </summary>
        public static void check_text_add_to_list(string text, List<int[]> list, int index, bool index2 = false)
        {
            text = text.Replace(" ", "");
            string[] str = text.Split(',');
            for (int a = 0; a < str.Length; a++)
            {
                string[] str2 = str[a].Split('-');
                if (str2.Length == 2) { list.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                if (str2.Length == 1) { list.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[0]) }); }
            }
        }

        /// <summary>
        /// For Exclude types feature, checks if an ion is in the exlusion list
        /// </summary>
        public static bool check_if_frag_included_exclude_list(int index1, FragForm fra, List<ExcludeTypes> list)
        {
            bool in_bounds = true;
            foreach (ExcludeTypes ext in list)
            {
                if ((ext.Extension != "" && recognise_extension(fra.Extension, ext.Extension)) || (ext.Extension == "" && fra.Extension == ""))
                {
                    for (int k = 0; k < ext.Index1.Count; k++)
                    {
                        if (index1 >= ext.Index1[k][0] && index1 <= ext.Index1[k][1])
                        {
                            in_bounds = false; break;
                        }
                    }
                    break;
                }
            }
            return in_bounds;
        }

        /// <summary>
        /// Closes all open forms except the (parameter)
        /// </summary>
        public static void CloseAllOpenForm(string currentForm)
        {
            // temp list
            var list = new List<Form>();

            // fill list
            foreach (Form form in Application.OpenForms)
                if (!currentForm.Equals(form.Name))
                    list.Add(form);

            // close selected forms
            foreach (Form form in list)
                form.Close();
        }
       
        #region extension
        public static bool recognise_extension(string fra_exte, string Extension)
        {
            string[] str = fra_exte.Split('_');
            for (int k = 1; k < str.Length; k++)
            {
                if (str[k].Equals(Extension)) { return true; }
            }
            return false;
        }
        public static int recognise_extension_frag(string fra_exte, string Extension)
        {
            string[] exte_str = Extension.Split('_');
            string[] str = fra_exte.Split('_');
            int length1 = str.Length;
            int length2 = exte_str.Length;
            int count = 0;
            string name_exte = fra_exte;

            for (int k = 1; k < length1; k++)
            {
                for (int m = 1; m < length2; m++)
                {
                    if (str[k].Equals(exte_str[m])) { count++; }
                }
            }
            if (count == 0) return 5;
            else if (length1 == length2 && length1 == count) return 1;
            else if (length1 > length2 && length2 == count) return 2;
            else if (length1 < length2 && length1 == count) return 3;
            else return 4;
        }
        public static string find_common_extensions(string fra_exte, string Extension)
        {
            string[] str = fra_exte.Split('_');
            string[] exte_str = Extension.Split('_');
            int count = 0;
            string name_exte = Extension;
            for (int k = 1; k < str.Length; k++)
            {
                count = 0;
                for (int m = 1; m < exte_str.Length; m++)
                {
                    if (str[k].Equals(exte_str[m])) { count++; }
                }
                if (count == 0) { name_exte += "_" + str[k]; }
            }
            return name_exte;
        }
        #endregion

        /// <summary>
        /// Find the amount of C in the input formula, if >12 then it is a precursor ion
        /// </summary>
        public static bool c_is_precursor(string initial_formula)
        {
            bool is_precursor = false;
            List<string> element1 = new List<string>();
            List<int> number1 = new List<int>();
            int i = 0;
            do
            { //check for elements with their atomic number in []
                int startIndex = 0;
                int endIndex = 0;
                int length = 0;
                if (initial_formula[i] == '[')
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (initial_formula[i] != ']'));

                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) != true));
                    endIndex = i - 1;
                    length = endIndex - startIndex + 1;
                    element1.Add(initial_formula.Substring(startIndex, length));
                }
                if (Char.IsNumber(initial_formula[i]) != true)
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) != true));
                    i = i - 1;
                    endIndex = i;
                    length = endIndex - startIndex + 1;
                    element1.Add(initial_formula.Substring(startIndex, length));
                }
                if (Char.IsNumber(initial_formula[i]))
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) == true));
                    i = i - 1;
                    endIndex = i;
                    length = endIndex - startIndex + 1;
                    number1.Add(Int32.Parse(initial_formula.Substring(startIndex, length)));
                }
                if (element1.Count > 1)
                {
                    break;
                }
                i++;
            } while (i < initial_formula.Length);
            //end while loop
            if (number1.Count == 0)
            {
                MessageBox.Show("Couldn't read chemical formula in fragment of ion type 'MH'"); return is_precursor;
            }
            if (number1[0] > 12)
            {
                is_precursor = true;
            }
            return is_precursor;
        }
    }
}
