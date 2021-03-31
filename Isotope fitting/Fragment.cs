using System;

namespace Isotope_fitting
{
	[Serializable]
	public class FittedFrag
	{

		private int charge;
		private int idx_from;
		private int idx_to;
		private int aa_count;

		private char amino_acid;

		private string name;
		private string formula;
		private string sequence;
		private string ion_type;

		private double mz;
		private double max_int;
		private double curr_max;

		public int Charge
        {
			get { return charge; }
			set { this.charge = value; }
        }

		public int Idx
        {
			get { return idx_from; }
			set { this.idx_from = value; }
        }

		public int IdxTo
		{
			get { return idx_to; }
			set { this.idx_to = value; }
		}

		public int AA_Count
        {
			get { return aa_count; }
			set { this.aa_count = value; }
        }

		public char AminoAcid
        {
			get { return amino_acid; }
			set { this.amino_acid = value; }
        }

		public string IonType
		{
			get { return ion_type; }
			set { this.ion_type = value; }
		}

		public string Formula
        {
            get { return formula; }
			set { this.formula = value; }
        }

		public string Sequence
        {
			get { return sequence; }
			set { this.sequence = value; }
        }

		public string Name
		{
			get { return name; }
			set { this.name = value; }
		}

		public double Mz
		{
			get { return mz; }
			set { this.mz = value; }
		}

		public double Intensity
		{
			get { return max_int; }
			set { this.max_int = value; }
		}

		public double CurrentMax
        {
			get { return curr_max; }
			set { this.curr_max = value; }
        }

	}
}
