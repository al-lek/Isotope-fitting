using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    public class ExcludeTypes
    {
        private List<int[]> index1;
        private List<int[]> index2;
        private string extension;
        public List<int[]> Index1
        {
            get { return this.index1; }
            set { this.index1 = value; }
        }
        public List<int[]> Index2
        {
            get { return this.index2; }
            set { this.index2 = value; }
        }
        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }
    }
}
