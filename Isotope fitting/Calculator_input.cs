using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotope_fitting
{
    public class Calculator_input
    {
        //for Ultimate Fragmentor
        private string sequence;       
        private string output_csv_file;
        private string output_excel_file;
        private List<string> modifications;
        private List<string> ions_series;
        private int charge_min;
        private int charge_max;
        
        public string Sequence
        {
            get { return this.sequence; }
            set { this.sequence = value; }
        }

        public string Output_csv_file
        {
            get { return this.output_csv_file; }
            set { this.output_csv_file = value; }
        }
        public string Output_excel_file
        {
            get { return this.output_excel_file; }
            set { this.output_excel_file = value; }
        }
        public List<string> Modifications
        {
            get { return this.modifications; }
            set { this.modifications = value; }
        }
        public List<string> Ions_series
        {
            get { return this.ions_series; }
            set { this.ions_series = value; }
        }
        public int Charge_min
        {
            get { return this.charge_min; }
            set { this.charge_min = value; }
        }
        public int Charge_max
        {
            get { return this.charge_max; }
            set { this.charge_max = value; }
        }
    }
}
