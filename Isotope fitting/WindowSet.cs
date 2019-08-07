using System.Collections.Generic;

namespace Isotope_fitting
{
    public class WindowSet
    {
        private int starting;
        private int ending;
        private List<List<double[]>> all_data;
        private List<int> fragments;
        private List<int> checked_mono_fragments;
        private double max_exp;
        private List<int> mono_fragments;
        private int code;

        private List<int[]> powerSet;
        private List<int[]> powerSetTodistro;        
        private List<double[]> aligned;
        private List<double[]> fitted;

        public double Max_exp
        {
            get
            {
                return this.max_exp;
            }
            set
            {
                this.max_exp = value;
            }
        }
        public int Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }
        public int Starting
        {
            get
            {
                return this.starting;
            }
            set
            {
                this.starting = value;
            }
        }
        public int Ending
        {
            get
            {
                return this.ending;
            }
            set
            {
                this.ending = value;
            }
        }
        public List<int> Fragments
        {
            get
            {
                return this.fragments;
            }
            set
            {
                this.fragments = value;
            }
        }
        public List<int> Checked_mono_fragments
        {
            get
            {
                return this.checked_mono_fragments;
            }
            set
            {
                this.checked_mono_fragments = value;
            }
        }
        public List<int> Mono_fragments
        {
            get
            {
                return this.mono_fragments;
            }
            set
            {
                this.mono_fragments = value;
            }
        }
        public List<int[]> PowerSet
        {
            get
            {
                return this.powerSet;
            }
            set
            {
                this.powerSet = value;
            }
        }        
        public List<List<double[]>> All_data
        {
            get
            {
                return this.all_data;
            }
            set
            {
                this.all_data = value;
            }
        }
        public List<int[]> PowerSetTodistro
        {
            get
            {
                return this.powerSetTodistro;
            }
            set
            {
                this.powerSetTodistro = value;
            }
        }
        public List<double[]> Aligned
        {
            get
            {
                return this.aligned;
            }
            set
            {
                this.aligned = value;
            }
        }
        public List<double[]> Fitted
        {
            get
            {
                return this.fitted;
            }
            set
            {
                this.fitted = value;
            }
        }

    }
}