using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    public class ppm_area
    {
        private double max;
        private double min;
        private bool chk;
        private int rule;
        private double max_ppm;

        public bool Chk
        {
            get { return this.chk; }
            set { this.chk = value; }
        }

        public int Rule
        {
            get { return this.rule; }
            set { this.rule = value; }
        }

        public double Max
        {
            get { return this.max; }
            set { this.max = value; }
        }
        public double Min
        {
            get { return this.min; }
            set { this.min = value; }
        }
        public double Max_ppm
        {
            get { return this.max_ppm; }
            set { this.max_ppm = value; }
        }
    }
}
