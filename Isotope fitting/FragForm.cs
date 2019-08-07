using System.Collections.Generic;
using OxyPlot;


namespace Isotope_fitting
{
    public class FragForm
    {
        private int charge;
        private string mz;
        private string inputFormula;       
        private string finalFormula;
        private int multiplier;
        private string index;
        private string radio_label;
        private string indexTo;
        private string ion;
        private string ion_type;
        private string adduct;
        private string deduct;
        private string name;
        private bool error;
        private string machine;
        private float resolution;
        private List<PointPlot> profile = new List<PointPlot>();
        private List<PointPlot> centroid = new List<PointPlot>();
        private double factor;
        private bool to_plot;
        private int counter;
        private OxyColor color;
        private string[] listName;
        private double fix;
        private double max_intensity;

        
        public OxyColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public List<PointPlot> Profile
        {
            get
            {
                return this.profile;
            }
            set
            {
                this.profile = value;
            }
        }
        public List<PointPlot> Centroid
        {
            get
            {
                return this.centroid;
            }
            set
            {
                this.centroid = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Counter
        {
            get
            {
                return this.counter;
            }
            set
            {
                this.counter = value;
            }
        }
        public int Charge
        {
            get
            {
                return this.charge;
            }
            set
            {
                this.charge = value;
            }
        }
        public bool To_plot
        {
            get
            {
                return this.to_plot;
            }
            set
            {
                this.to_plot = value;
            }
        }
        public double Factor
        {
            get
            {
                return this.factor;
            }
            set
            {
                this.factor = value;                
            }
        }
        public double Fix
        {
            get
            {
                return this.fix;
            }
            set
            {
                this.fix = value;
            }
        }
        public double Max_intensity
        {
            get
            {
                return this.max_intensity;
            }
            set
            {
                this.max_intensity = value;
            }
        }
        public string Mz
        {
            get
            {
                return this.mz;
            }
            set
            {
                this.mz = value;
            }
        }
        public string Radio_label
        {
            get
            {
                return this.radio_label;
            }
            set
            {
                this.radio_label = value;
            }
        }
        public string InputFormula
        {
            get
            {
                return this.inputFormula;
            }
            set
            {
                this.inputFormula = value;
            }
        }
        public string[] ListName
        {
            get
            {
                return this.listName;
            }
            set
            {
                this.listName = value;
            }
        }
        public string FinalFormula
        {
            get
            {
                return this.finalFormula;
            }
            set
            {
                this.finalFormula = value;
            }
        }
        public string Ion
        {
            get
            {
                return this.ion;
            }
            set
            {
                this.ion = value;
            }
        }
        public string Ion_type
        {
            get
            {
                return this.ion_type;
            }
            set
            {
                this.ion_type = value;
            }
        }
        public string Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
        public string IndexTo
        {
            get
            {
                return this.indexTo;
            }
            set
            {
                this.indexTo = value;
            }
        }
        public string Machine
        {
            get
            {
                return this.machine;
            }
            set
            {
                this.machine = value;
            }
        }
        public float Resolution
        {
            get
            {
                return this.resolution;
            }
            set
            {
                this.resolution = value;
            }
        }

        public int Multiplier
        {
            get
            {
                return this.multiplier;
            }
            set
            {
                this.multiplier = value;
            }
        }
        public string Adduct
        {
            get
            {
                return this.adduct;
            }
            set
            {
                this.adduct = value;
            }
        }
        public string Deduct
        {
            get
            {
                return this.deduct;
            }
            set
            {
                this.deduct = value;
            }
        }
        public bool Error
        {
            get
            {
                return this.error;
            }
            set
            {
                this.error = value;
            }
        }


    }
}