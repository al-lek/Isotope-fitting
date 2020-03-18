using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    class SequenceTab
    {
        private string sequence;
        private string extension;
        private int type;
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
        public string Sequence
        {
            get { return this.sequence; }
            set { this.sequence = value; }
        }
    }
}
