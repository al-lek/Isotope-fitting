using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    public class SequenceTab
    {
        private string sequence;
        private string extension;
        private int type;
        private string rtf;
        private List<Color> color_table = new List<Color>();
        private int[] char_color;
        private List<int[]> index_SS_primary = new List<int[]>();
        private List<int[]> index_SS_internal = new List<int[]>();

        public int[] Char_color
        {
            get { return this.char_color; }
            set { this.char_color = value; }
        }
        public List<Color> Color_table
        {
            get { return this.color_table; }
            set { this.color_table = value; }
        }
        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }
        public string Rtf
        {
            get { return this.rtf; }
            set { this.rtf = value; }
        }
        public string Sequence
        {
            get { return this.sequence; }
            set { this.sequence = value; }
        }
        public List<int[]> Index_SS_primary
        {
            get { return this.index_SS_primary; }
            set { this.index_SS_primary = value; }
        }
        public List<int[]> Index_SS_internal
        {
            get { return this.index_SS_internal; }
            set { this.index_SS_internal = value; }
        }
    }
}
