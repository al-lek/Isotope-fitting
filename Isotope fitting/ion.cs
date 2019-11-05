using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    class ion
    {
        private Color color;
        private int index;
        private int indexTo;
        private string ion_type;
        private int sort_idx;
        private int charge;

        private double max_intensity;

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public double Max_intensity
        {
            get { return this.max_intensity; }
            set { this.max_intensity = value; }
        }
        public string Ion_type
        {
            get { return this.ion_type; }
            set { this.ion_type = value; }
        }
        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }
        public int IndexTo
        {
            get { return this.indexTo; }
            set { this.indexTo = value; }
        }
        public int SortIdx
        {
            get { return this.sort_idx; }
            set { this.sort_idx = value; }
        }
        public int Charge
        {
            get { return this.charge; }
            set { this.charge = value; }
        }
    }
}
