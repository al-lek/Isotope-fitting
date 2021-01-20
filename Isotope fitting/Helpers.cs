using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Isotope_fitting
{
    public static class Helpers
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
            // will return 0 on error
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
            if (str == "True" || str == "TRUE") return true;
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
        public static string fix_formula(out bool is_error,string input, bool simple = true, int h = -1, int h2o = 0, int nh3 = 0)
        {
            string formula = "";
            bool error = false;
            is_error = error;
            if (simple == true) { formula = find_index_fix_formula(out error  ,input, h);  }
            else
            {
                if (h2o != 0)
                {
                    input = find_index_fix_formula(out error, input, 2 * h2o, 'H');
                    input = find_index_fix_formula(out error, input, h2o, 'O');
                }
                if (nh3 != 0)
                {
                    input = find_index_fix_formula(out error, input, 3 * nh3, 'H');
                    input = find_index_fix_formula(out error, input, nh3, 'N');
                }
                formula = input;
            }            
            is_error = error;
            return formula;
        }

        /// <summary>
        /// Find the element's index in the chemical formula
        /// </summary>
        public static string find_index_fix_formula( out bool error,string input, int amount = -1, char element = 'H')
        {
            error = false;
            bool error2 = false;
            int idx = input.IndexOf(element);
            if (idx < 0 && amount<0){
                error = true; return input;}
            else if (idx < 0)
            {
                int idx_c = input.IndexOf('C');
                bool stop = false;
                while (!stop)
                {
                    idx_c++;
                    if(input.Length <= idx_c || !Char.IsNumber(input[idx_c])) { stop = true; }
                }
                if (!stop) input = element + amount.ToString() + input;
                else input = input.Insert(idx_c, element + amount.ToString() );
                return input;
            }
            var theString = input;
            var aStringBuilder = new StringBuilder(theString);
            if (input.Length > idx + 2 && Char.IsNumber(input[idx + 2]))
            {
                if (input.Length > idx + 3 && Char.IsNumber(input[idx + 3]))
                {
                    if (input.Length > idx + 4 && Char.IsNumber(input[idx + 4]))
                    {
                        if (input.Length > idx + 5 && Char.IsNumber(input[idx + 5]))
                        {
                            input = replace_number_fix_formula(out error2,input, amount, idx + 1, 5);
                        }
                        else
                        {
                            input = replace_number_fix_formula(out error2, input, amount, idx + 1, 4);
                        }
                    }
                    else
                    {
                        input = replace_number_fix_formula(out error2, input, amount, idx + 1, 3);
                    }
                }
                else
                {
                    input = replace_number_fix_formula(out error2, input, amount, idx + 1, 2);
                }
            }
            else
            {
                input = replace_number_fix_formula(out error2, input, amount, idx + 1, 1);
            }
            error = error2;
            return input;
        }

        /// <summary>
        ///Given the index of the number that indicates the amount of an element in the chemical formula, set the desired amount
        /// </summary>
        public static string replace_number_fix_formula(out bool error,string input, int amount, int sub_index, int sub_length)
        {
            var theString = input;
            error = false;
            var aStringBuilder = new StringBuilder(theString);
            Int32.TryParse(theString.Substring(sub_index, sub_length), out int result);
            aStringBuilder.Remove(sub_index, sub_length);
            aStringBuilder.Insert(sub_index, (result + amount).ToString());
            if (result+amount<0)
            {
                error = true;
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
        public static void un_check_all_checkboxes_ListBx(Control container, bool check = false)
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
        /// Uncheck all checkboxes
        /// </summary>
        public static void un_check_all_checkboxes(Control container, bool check = false)
        {
            if (check)
            {               
                foreach (CheckBox box in GetControls(container).OfType<CheckBox>())
                {
                    box.Checked = true;
                }
            }
            else
            {               
                foreach (CheckBox box in GetControls(container).OfType<CheckBox>())
                {
                    box.Checked = false;
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
        public static ToolStripButton find_toolstripBtn(ToolStrip strip, string key_word = "")
        {
            ToolStripButton btn = new ToolStripButton() ;
            foreach (ToolStripButton btn1 in strip.Items.OfType<ToolStripButton>().ToList())
            {
                if (btn1.CheckOnClick == true && btn1.Name.Contains(key_word)) { return btn1; }
            }
            return btn;
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
            if (list.Count>0)
            {
                // close selected forms
                foreach (Form form in list)
                    form.Close();
            }          
        }
        /// <summary>
        /// Closes all open forms that are equal to the (parameter)
        /// </summary>
        public static void CloseForm(string currentForm)
        {
            // temp list
            var list = new List<Form>();

            // fill list
            foreach (Form form in Application.OpenForms)
                if (currentForm.Equals(form.Name))
                    list.Add(form);
            if (list.Count > 0)
            {
                // close selected forms
                foreach (Form form in list)
                    form.Close();
            }
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

        /// <summary>
        /// retirn List<int[]> with the indexes that are colored
        /// </summary>
        public static List<int[]> return_regions_SS(string text_input)
        {
            List<int[]> index_list = new List<int[]>();
            if (!string.IsNullOrEmpty(text_input))
            {
                string text = text_input.Replace(" ", "");
                string[] str = text.Split(',');
                for (int a = 0; a < str.Length; a++)
                {
                    string[] str2 = str[a].Split('-');
                    try
                    {
                        if (str2.Length == 2) { index_list.Add(new int[] { Int32.Parse(str2[0]), Int32.Parse(str2[1]) }); }
                    }
                    catch
                    {
                        return new List<int[]>();
                    }
                }
            }
            return index_list;
        }
        /// <summary>
        ///return the double number in the numeric Up Down or an error message if the user enters the wrong format
        /// </summary>
        public static double[] numUD_to_double_number(NumericUpDown numUD)
        {
            double[] value =new double[] { 0.0,1.0};
            try
            {
                double temp = double.Parse(numUD.ActiveControl.Text);
                value[0] = temp;
            }
            catch
            {
                value[1] = 0.0;
                MessageBox.Show("Ooops...This control accepts numbers only. ", "Wrong format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return value;
        }
        /// <summary>
        ///return the integer number in the numeric Up Down or an error message if the user enters the wrong format
        /// </summary>
        public static int[] numUD_to_int_number(NumericUpDown numUD)
        {
            int[] value = new int[] { 0, 1 };
            try
            {
                int temp = int.Parse(numUD.ActiveControl.Text);
                value[0] = temp;
            }
            catch
            {
                value[1] = 0;
                MessageBox.Show("Ooops...This control accepts integer numbers only. ", "Wrong format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return value;
        }

        /// <summary>
        ///return the focused control in a container
        /// </summary>
        public static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        /// <summary>
        ///Calculate monoisotopic mass of a chemican formula and return 'out' 'error'=true in case something goes wrong
        /// </summary>
        public static double calc_m(out bool Error, string FORMULA)
        {
            Error = false;
            if (string.IsNullOrEmpty(FORMULA)) return 0.0;
            string f = "";
            string FinalFormula = "";
            double mono_abundance = 1.0;
            double mono_mass = 0.0;
            double iso_total_amount = 0;            
            List<Element_set> Elements_set = new List<Element_set>();
            
            for (int g = 0; g < FORMULA.Length; g++)
            {
                if (Char.IsWhiteSpace(FORMULA, g) && Char.IsNumber(FORMULA, g + 1))
                {
                    f += "[";
                    do
                    {
                        g++;
                        f += FORMULA[g];
                    } while ((g + 1 < FORMULA.Length) && (Char.IsNumber(FORMULA[g + 1])));
                    f += "]";
                }
                else if (g == 0 && Char.IsNumber(FORMULA, g))
                {
                    f += "[";
                    f += FORMULA[g];
                    do
                    {
                        g++;
                        f += FORMULA[g];
                    } while ((g + 1 < FORMULA.Length) && (Char.IsNumber(FORMULA[g + 1])));
                    f += "]";
                }
                else
                {
                    f += FORMULA[g];
                }
            }
            FORMULA = f.Replace(" ", "");
            string[] elem = new string[IsotopesInfo.isoTable.Length];
            Regex rgx = new Regex("[A-Z]");          

            for (int k = 0; k < IsotopesInfo.isoTable.Length; k++)
            {
                elem[k] = IsotopesInfo.isoTable[k].element;
            }
            //group isoTable list according to each element and sort each element isotope in descending abundance order
            var elementGroup = IsotopesInfo.isoTable.GroupBy(el => el.element, el => el)
                .Select(grp => new {
                    grp.Key,
                    sorted_Ab = grp.OrderByDescending(x => x.abundance).TakeWhile(x => x.abundance > 0)
                }).ToList();
            //keep from isoTable for each element isotope only the most abundant one
            var elementGroupMax = IsotopesInfo.isoTable.GroupBy(el => el.element, el => el)
                   .Select(grp => new
                   {
                       grp.Key,
                       maxAb = grp.OrderByDescending(x => x.abundance).FirstOrDefault()
                   }).ToList();


            List<string> Element = new List<string>();
            List<int> Number = new List<int>();
            List<string> Element1 = new List<string>();
            List<int> Number1 = new List<int>();

        
            if (FORMULA != null)
            {
                Error = false;
                //all characters possible?
                if (FORMULA.IndexOfAny("*{}&#$@!`-_,.+^".ToCharArray()) != -1)
                {
                    Error = true;
                }
                //do all bracket types close and [] only contain numbers?
                if (Error == false && FORMULA.IndexOfAny("()[]".ToCharArray()) != -1)
                {
                    int getit1 = 0;
                    int getit2 = 0;
                    foreach (char c in FORMULA)
                    {
                        if (c == '[') { getit1++; }
                        if (c == ']') { getit1--; }
                        if (c == '(') { getit2++; }
                        if (c == ')') { getit2--; }
                        if (getit1 > 0 && (Char.IsNumber(c) == false && c != '[' && c != ']')) { Error = true; }
                        if (getit1 < 0 || getit2 < 0) { Error = true; }
                    }
                    if (getit1 != 0 || getit2 != 0)
                    {
                        Error = true;
                    }
                }

                //start correct?
                if (Error == false && char.IsUpper(FORMULA[0]) != true && FORMULA[0] != '(' && FORMULA[0] != '[')
                {
                    Error = true;
                }
                if (FORMULA.Length == 1)
                {
                    FORMULA = FORMULA + "1";
                }

                //empty brackets?
                if (Error == false)
                {
                    for (int a = 1; a < FORMULA.Length; a++)
                    {
                        if (FORMULA[a - 1] == '(' && FORMULA[a] == ')')
                        {
                            Error = true;
                        }
                    }
                }

                //insert 1 where missing
                if (Error == false)
                {
                    if (FORMULA.Any(item => item == '('))
                    {
                        for (int a = 0; a < FORMULA.Length - 1; a++)
                        {
                            if (FORMULA[a] == ')' && Char.IsNumber(FORMULA[a + 1]) == false)
                            {
                                var aStringBuilder = new StringBuilder(FORMULA);
                                aStringBuilder.Insert(a + 1, "1");
                                FORMULA = aStringBuilder.ToString();
                            }
                        }
                        if (FORMULA[FORMULA.Length - 1] == ')')
                        {
                            FORMULA = FORMULA + "1";
                        }
                    }
                    //for all other cases
                    for (int a = 1; a < FORMULA.Length; a++)
                    {
                        if ((char.IsUpper(FORMULA[a]) || FORMULA[a] == ')' || FORMULA[a] == '(')
                            && char.IsNumber(FORMULA[a - 1]) == false && FORMULA[a - 1] != '(' && FORMULA[a - 1] != ']')
                        {
                            var aStringBuilder = new StringBuilder(FORMULA);
                            aStringBuilder.Insert(a, "1");
                            FORMULA = aStringBuilder.ToString();
                            a++;
                        }

                    }
                    if (char.IsNumber(FORMULA[FORMULA.Length - 1]) == false)
                    {
                        FORMULA = FORMULA + "1";
                    }
                }
                
                //dissasemble-->chem.InputFormula:chem.Element,chem.Number
                if (Error == false)
                {
                    int i = 0;
                    do
                    {
                        int startIndex = 0;
                        int endIndex = 0;
                        int length = 0;
                        //check for elements with their atomic number in [] an add them to the elements' character list
                        if (FORMULA[i] == '[')
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < FORMULA.Length) && (FORMULA[i] != ']'));

                            do
                            {
                                i++;
                            } while ((i < FORMULA.Length) && (Char.IsNumber(FORMULA[i]) != true));
                            endIndex = i - 1;
                            length = endIndex - startIndex + 1;
                            Element.Add(FORMULA.Substring(startIndex, length));
                        }
                        //Create elements' character list for deduct chemical formula
                        if (Char.IsNumber(FORMULA[i]) != true)
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < FORMULA.Length) && (Char.IsNumber(FORMULA[i]) != true));
                            i = i - 1;
                            endIndex = i;
                            length = endIndex - startIndex + 1;
                            Element.Add(FORMULA.Substring(startIndex, length));

                        }
                        //Create elements' number list for deduct chemical formula
                        if (Char.IsNumber(FORMULA[i]))
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < FORMULA.Length) && (Char.IsNumber(FORMULA[i]) == true));
                            i = i - 1;
                            endIndex = i;
                            length = endIndex - startIndex + 1;
                            Number.Add(Int32.Parse(FORMULA.Substring(startIndex, length)));

                        }
                        i++;
                    } while (i < FORMULA.Length);

                }


                //check if all elements present in isotopes list
                if (Error == false)
                {
                    if (Element.Except(elem).Any())
                    {
                        Error = true;
                    }
                    if (Element.Count != Number.Count)
                    {
                        Error = true;
                    }
                }

                //merge non-unique elements
                if (Error == false)
                {
                    //elements merged
                    //dictionary contains each element(Key) and the number of times it is presented in formula(Value)
                    IDictionary<string, int> dictionary = new Dictionary<string, int>();
                    dictionary = Element.Zip(Number, (k, v) => new { Key = k, Value = v })
                   .GroupBy(d => d.Key)
                   .Select(g => new { Key = g.Key, Value = g.Sum(s => s.Value) }).ToDictionary(y => y.Key, y => y.Value);

                    
                    //check if each element's amount in the deduct is larger than the corresponding element in the chemical formula
                    //in this case the element is "deleted" from the chemical formula
                    if (dictionary.Any(item => item.Value == 0))
                    {
                        dictionary = dictionary.Where(kvp => kvp.Value >= 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    }

                    if (Error == false)
                    {
                        //create the final chemical formula that will be used for the calculations
                        foreach (var p in dictionary)
                        {
                            FinalFormula = (FinalFormula + p.Key + p.Value).ToString();
                        }

                        //sorted_Ab connected to each of the elements found in the formula
                        var Info_el = from d in dictionary
                                      orderby d.Key
                                      join l in elementGroup on d.Key equals l.Key
                                      select new
                                      {
                                          Elements = d.Key,
                                          Clues = l.sorted_Ab,
                                          Number = d.Value
                                      };

                        //elements sorted in INCREASING order of the number of isotopes they have
                        var Info_iso_amount_sorted = Info_el.OrderBy(x => x.Clues.Count());
                        //maxAb connected to each of the elements found in the formula
                        var Info_elMax = from d in dictionary
                                         orderby d.Key
                                         join l in elementGroupMax on d.Key equals l.Key
                                         select new
                                         {
                                             Elements = d.Key,
                                             abundance = l.maxAb.abundance,
                                             mass = l.maxAb.mass,
                                             Number = d.Value
                                         };


                        //monoisotopic mass calculation for each chemical formula's elements
                        foreach (var el in Info_elMax)
                        {
                            //create a loop for the calculations between the double type parameters
                            for (int i = 0; i < el.Number; i++)
                            {
                                mono_mass += el.mass;
                                mono_abundance *= el.abundance;
                            }
                        }

                        //pass the grouped values of Info_el in accessible variables
                        int b = 0;
                        foreach (var l in Info_iso_amount_sorted)
                        {
                            Int16 i = 0;

                            Elements_set.Add(new Element_set
                            {
                                Name = l.Elements,
                                Number = l.Number,
                                Iso_amount = l.Clues.Count(),
                                All_iso_calc_amount = 0,
                                Isotopes = new List<IsotopesInfo.Isotopes2>(),
                                Isotopes_single = new List<IsotopesInfo.Isotopes2>()
                            }
                            );
                            for (int a = 0; a < l.Clues.Count(); a++)
                            {
                                Elements_set[b].Isotopes.Add(new IsotopesInfo.Isotopes2
                                {
                                    isotope = l.Clues.ElementAt(a).isotope,
                                    abundance = l.Clues.ElementAt(a).abundance,
                                    mass = l.Clues.ElementAt(a).mass,
                                    element_nr = i,
                                    iso_e_nr = i,
                                    element = l.Elements,
                                    number = l.Number
                                }
                                );
                                i++;
                            }
                           iso_total_amount += l.Clues.Count();
                            b++;
                        }
                        //Isotopes_single contains only the isotopes of the elements that have more than one isotope, except the most abundant isotopes ones

                        foreach (Element_set el in Elements_set)
                        {
                            if (el.Iso_amount > 1)
                            {
                                for (Int16 i = 1; i < el.Isotopes.Count; i++)
                                {
                                    el.Isotopes_single.Add(new IsotopesInfo.Isotopes2 { isotope = el.Isotopes[i].isotope, abundance = el.Isotopes[i].abundance, mass = el.Isotopes[i].mass, element_nr = i, iso_e_nr = i, element = el.Name, number = el.Number });
                                }
                            }
                            //isotopes(except the most abundant ones) of each element ordered in DESCENDING order
                            el.Isotopes_single = el.Isotopes_single.OrderByDescending(x => x.number * x.abundance).ToList();
                        }
                    }

                }
            }
            else
            {
                //error message on each formula
                Error = true;
            }
            return mono_mass;
        }
        /// <summary>
        ///Multiply the elements within () of a chemical formula. For example (CH)2 --> C2H2
        /// </summary>
        public static string square_brackets_formula(string FORMULA)
        {
            if (FORMULA.Length == 0) { return FORMULA; }            
            if (FORMULA.Any(item => item == '('))
            {
                for (int a = 0; a < FORMULA.Length - 1; a++)
                {
                    if (FORMULA[a] == ')' && Char.IsNumber(FORMULA[a + 1]) == false)
                    {
                        var aStringBuilder = new StringBuilder(FORMULA);
                        aStringBuilder.Insert(a + 1, "1");
                        FORMULA = aStringBuilder.ToString();
                    }
                }
                if (FORMULA[FORMULA.Length - 1] == ')')
                {
                    FORMULA = FORMULA + "1";
                }
            }
            //for all other cases
            for (int a = 1; a < FORMULA.Length; a++)
            {
                if ((char.IsUpper(FORMULA[a]) || FORMULA[a] == ')' || FORMULA[a] == '(')
                    && char.IsNumber(FORMULA[a - 1]) == false && FORMULA[a - 1] != '(' && FORMULA[a - 1] != ']')
                {
                    var aStringBuilder = new StringBuilder(FORMULA);
                    aStringBuilder.Insert(a, "1");
                    FORMULA = aStringBuilder.ToString();
                    a++;
                }

            }
            if (char.IsNumber(FORMULA[FORMULA.Length - 1]) == false)
            {
                FORMULA = FORMULA + "1";
            }
            //multiply for square brackets, with nesting
            if (FORMULA.Any(item => item == '('))
            {
                int getit1 = 1;
                int getit2 = 1;
                List<int> from = new List<int>();
                int to = -1;
                List<int> factor = new List<int>();
                List<string> formula = new List<string>();
                List<string> final = new List<string>();
                List<int> length_r = new List<int>();
                int a = 0;
                int i = -1;

                while (a < FORMULA.Length && getit1 != 0 && getit2 != 0)
                {
                    if (FORMULA[a] == '(')
                    {
                        getit1 = 2;
                        from.Add(a);
                    }
                    if (FORMULA[a] == ')')
                    {
                        getit2 = 2;
                        to = a;
                    }
                    if (getit1 == 2 && getit2 == 2)
                    {
                        i++;
                        int b1 = a + 1;
                        int b2 = a + 1;
                        while (b2 < FORMULA.Length && char.IsNumber(FORMULA[b2]))
                        {
                            b2++;
                        }
                        length_r.Add(b2 - from[i]);

                        try
                        {
                            try
                            {
                                factor.Add(Int32.Parse(FORMULA.Substring(b1, b2 - b1)));

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        catch (FormatException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        //call Multif  
                        formula.Add(FORMULA.Substring(from[i] + 1, to - 1));
                        final.Add(ChemiForm.Multif(formula[i], factor[i]));
                        //ston allo kvdika exei getit1=0,getit2=0,alla etsi elegxei gia mia parenthesi mono                                                  
                        getit1 = 1;
                        getit2 = 1;
                    }
                    a++;
                }

                var aStringBuilder = new StringBuilder(FORMULA);
                for (int k = 0; k < formula.Count; k++)
                {
                    //InputFormula = InputFormula.Replace(formula[i], final[i]);
                    aStringBuilder.Remove(from[i], length_r[i]);
                    aStringBuilder.Insert(from[i], final[i]);
                    FORMULA = aStringBuilder.ToString();
                }

            }
            return FORMULA;
        }

        /// <summary>
        ///Find all occurences of a substring within a string
        /// </summary>
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        /// <summary>
        ///Find the count of occurences of a substring within a string
        /// </summary>
        public static int CountOccurenceswWithinString( string str, string value)
        {            
            int wordCount = 0;
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                wordCount++;
            }           
            return wordCount;
        }
        /// <summary>
        ///Check if a base loss -B() is possible for a certain ion. For example if an ion does not contain the base A it is not possoble to have a loss -B(A) 
        /// </summary>
        public static bool check_ion_for_base(ChemiForm chem, string adduct, List<SequenceTab> TEMP_sequenceList)
        {
            if (TEMP_sequenceList == null || TEMP_sequenceList.Count == 0 || chem.Ion_type.Equals("B()") || chem.Ion_type.Contains("known MS2")) return false;
            bool base_present = false;
            bool proceed = Int32.TryParse(chem.Index, out int index);
            if (!proceed) return base_present;
            proceed = Int32.TryParse(chem.IndexTo, out int indexTo);
            if (!proceed) return base_present;
            string curr_ss = "";
            string sub_ss = "";
            foreach (SequenceTab seq in TEMP_sequenceList)
            {
                if (seq.Extension.Equals(chem.Extension) && seq.Type.Equals(chem.Chain_type)) { curr_ss = seq.Sequence; break; }
            }
            if (curr_ss == "") return base_present;
            if (chem.Ion_type.Contains("internal")) sub_ss = curr_ss.Substring(index - 1, indexTo - index + 1);
            else if (chem.Ion_type.StartsWith("M") || chem.Ion_type.StartsWith("(M") || chem.Ion_type.StartsWith("[M")) sub_ss = curr_ss.ToString();
            else if (index == indexTo)
            {
                if (chem.Ion_type.StartsWith("a") || chem.Ion_type.StartsWith("(a") || chem.Ion_type.StartsWith("b") || chem.Ion_type.StartsWith("(b") || chem.Ion_type.StartsWith("c") || chem.Ion_type.StartsWith("(c") || chem.Ion_type.StartsWith("d") || chem.Ion_type.StartsWith("(d"))
                {
                    sub_ss = curr_ss.Substring(0, index);
                }
                else if (chem.Ion_type.StartsWith("w") || chem.Ion_type.StartsWith("(w") || chem.Ion_type.StartsWith("x") || chem.Ion_type.StartsWith("(x") || chem.Ion_type.StartsWith("y") || chem.Ion_type.StartsWith("(y") || chem.Ion_type.StartsWith("z") || chem.Ion_type.StartsWith("(z"))
                {
                    sub_ss = curr_ss.Substring(chem.SortIdx);
                }
                else return base_present;
            }
            else return base_present;
            if (check_base_presence(sub_ss, "A", chem.Ion_type, adduct) && check_base_presence(sub_ss, "G", chem.Ion_type, adduct) && check_base_presence(sub_ss, "T", chem.Ion_type, adduct)) base_present = true;
            return base_present;
        }
        /// <summary>
        ///Check if a base is present in an ion's sequence 
        /// </summary>
        public static bool check_base_presence(string sub_ss, string base_s, string ion_type, string adduct)
        {
            int count = 0;
            int count_B = CountOccurenceswWithinString(sub_ss, base_s);
            count = CountOccurenceswWithinString(adduct, "B(" + base_s);
            if (count == 0) return true;
            count += CountOccurenceswWithinString(ion_type, "B(" + base_s);
            if (count > count_B) return false;
            else return true;
        }
        /// <summary>
        ///Check if a ChemiForm chem1 fragment exists in the selRes list
        /// </summary>
        public static bool check_duplicates_SelectedFragments(ChemiForm chem1, List<ChemiForm> selRes)
        {
            if (selRes.Count > 0)
            {
                foreach (ChemiForm fra in selRes)
                {
                    if (fra.Extension.Equals(chem1.Extension)&& fra.Name.Equals(chem1.Name) && fra.Index.Equals(chem1.Index) && fra.IndexTo.Equals(chem1.IndexTo) && fra.Ion_type.Equals(chem1.Ion_type) && fra.Chain_type.Equals(chem1.Chain_type) && fra.Charge.Equals(chem1.Charge))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        ///Check if it is possible and calculate the modified ion 
        /// </summary>
        public static ChemiForm check_adduct(out bool is_error, ChemiForm chem, string adduct, string deduct, string extra_name, bool has_Adduct, bool name = false,bool is_riken=false)
        {
            is_error = true;
            ChemiForm temp_chem = chem.DeepCopy();
            try
            {
                temp_chem.Adduct = adduct; temp_chem.Deduct = deduct;
                ChemiForm.CheckChem(temp_chem);
            }
            catch (Exception e) { return null; }
            if (!temp_chem.Error)
            {
                List<string> ion_adducts = new List<string>() {"a-NH3","b-NH3","b-H2O","b+H2O","y-NH3","y-H2O","b-2NH3","b-2H2O","y-2NH3","y-2H2O","b-N2H6","b-H4O2","y-N2H6","y-H4O2","b-2(NH3)","b-2(H2O)","y-2(NH3)","y-2(H2O)","b-(NH3)2","b-(H2O)2","y-(NH3)2","y-(H2O)2","b-H2O-NH3","b-NH3-H2O",
            "y-H2O-NH3","y-NH3-H2O","x-H2O", "internal b-H2O","internal b-NH3","internal b-2H2O","internal b-2(H2O)","internal b-2(NH3)","internal b-(H2O)2","internal b-(NH3)2","internal b-2NH3" ,"internal b-N2H6","internal b-H4O2", "M-H2O","M-NH3"};
                if(is_riken)ion_adducts = new List<string>() { "a-H2O", "b-H2O", "c-H2O", "d-H2O", "w-H2O", "x-H2O", "y-H2O", "z-H2O" ,"known MS2-H2O","known MS2-2(H2O)","M-H2O","M-B()","M-H2O-B()"};
                is_error = false;
                ChemiForm last_chem = chem.DeepCopy();
                last_chem.InputFormula = last_chem.PrintFormula = temp_chem.FinalFormula;
                last_chem.Has_adduct = has_Adduct;
                if (ion_adducts.Contains(last_chem.Ion_type)) { last_chem.Has_adduct = false; }
                if (name)
                {
                    string new_type = temp_chem.Ion_type;
                    string add_type = "";
                    new_type += extra_name; add_type = extra_name;
                    string[] str = temp_chem.Name.Split('_');
                    int s = temp_chem.Name.IndexOf('_');
                    if (last_chem.Ion.Contains("(")) { last_chem.Ion = str[0].Replace(temp_chem.Ion, temp_chem.Ion + add_type); }
                    else { last_chem.Ion = str[0].Replace(temp_chem.Ion,"("+ temp_chem.Ion + add_type+")"); }                                  
                    last_chem.Name = last_chem.Ion + temp_chem.Name.Remove(0, s);
                    last_chem.Ion_type = new_type;
                    last_chem.Has_adduct = has_Adduct;
                    if (extra_name.Contains("B(A)")) { last_chem.Ion_type = last_chem.Ion_type.Replace("B(A)", "B()"); }
                    if (extra_name.Contains("B(G)")) { last_chem.Ion_type = last_chem.Ion_type.Replace("B(G)", "B()"); }
                    if (extra_name.Contains("B(T)")) { last_chem.Ion_type = last_chem.Ion_type.Replace("B(T)", "B()"); }
                    if (ion_adducts.Contains(last_chem.Ion_type)) { last_chem.Has_adduct = false; }
                }
                return last_chem;
            }
            return null;
        }
        /// <summary>
        ///Remove empty spaces from the beginning and the ending of a string 
        /// </summary>
        public static string remove_empty_spaces(string initial)
        {
            string final = "";            
            int start = 0;int finish = 0;
            for (int k=0;k< initial.Length; k++)
            {
                if(! Char.IsWhiteSpace(initial[k]))
                {
                    start = k;break;
                }               
            }
            for (int k = initial.Length-1; k>-1; k--)
            {
                if (!Char.IsWhiteSpace(initial[k]))
                {
                    finish = k; break;
                }
            }
            final = initial.Substring(start, finish-start+1);
           return final;
        }
    }
}
