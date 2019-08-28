using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Isotope_fitting
{
    public partial class Form5 : Form
    {
        ListViewColumnSorter lvwColumnSorter;

        public Form5()
        {
            InitializeComponent();
            init_peak_listView();
            fill_peak_listView();

            // event on RightClick to copy peaks to clipboard 
            peak_listView.MouseClick += (s, e) => { if (e.Button == MouseButtons.Right) peaks_toClipboard(); };
        }

        private void init_peak_listView()
        {
            lvwColumnSorter = new ListViewColumnSorter();
            peak_listView.ListViewItemSorter = lvwColumnSorter;
            peak_listView.ColumnClick += (s, e) => { sort_column(e.Column); };
        }

        private void fill_peak_listView()
        {
            peak_listView.BeginUpdate();
            peak_listView.Items.Clear();
            foreach (double[] peak in Form2.peak_points)
            {
                ListViewItem listviewitem = new ListViewItem(new string[] { Math.Round((peak[1] + peak[4]), 6).ToString(), Math.Round((peak[5]), 2).ToString(), Math.Round((peak[3]), 0).ToString() });
                peak_listView.Items.Add(listviewitem);
            }
            this.Text += " :" + Form2.peak_points.Count + " peaks";
            peak_listView.EndUpdate();
        }

        private void sort_column(int column)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            peak_listView.Sort();
        }

        private void peaks_toClipboard()
        {
            StringBuilder sb = new StringBuilder();

            foreach (double[] peak in Form2.peak_points)
            {
                foreach(double peak_data in peak)
                {
                    sb.Append(peak_data.ToString() + "\t");
                }
                sb.Append("\r\n");
            }
            Clipboard.SetText(sb.ToString());
        }
    }

    #region Comparer class
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(Convert.ToDouble(listviewX.SubItems[ColumnToSort].Text), Convert.ToDouble(listviewY.SubItems[ColumnToSort].Text));
            
            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
        #endregion

    }
}
