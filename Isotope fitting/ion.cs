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
        private double ppm_error;
        private string mz;
        private double max_intensity;
        private string name;
        private double maxppm_error;
        private double minppm_error;
        private string extension;
        private int chain_type;
        private bool has_adduct;

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public bool Has_adduct
        {
            get { return this.has_adduct; }
            set { this.has_adduct = value; }
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
        public int Chain_type
        {
            get { return this.chain_type; }
            set { this.chain_type = value; }
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
        public string Mz
        {
            get { return this.mz; }
            set { this.mz = value; }
        }
        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double PPM_Error
        {
            get { return this.ppm_error; }
            set { this.ppm_error = value; }
        }
        public double maxPPM_Error
        {
            get { return this.maxppm_error; }
            set { this.maxppm_error = value; }
        }
        public double minPPM_Error
        {
            get { return this.minppm_error; }
            set { this.minppm_error = value; }
        }
    }
}
