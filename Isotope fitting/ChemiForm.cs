using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using System.IO;

namespace Isotope_fitting
{
    #region Classes and parameters set   
    public class Element_sort
    {
        private ChemForm.Isotopes2 isotopes;
        private string name;
        private int number;
        private int all_iso_calc_amount;
        private int iso_amount;

        public ChemForm.Isotopes2 Isotopes
        {
            get
            {
                return this.isotopes;
            }
            set
            {
                this.isotopes = value;
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
        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
        public int All_iso_calc_amount
        {
            get
            {
                return this.all_iso_calc_amount;
            }
            set
            {
                this.all_iso_calc_amount = value;
            }
        }
        public int Iso_amount
        {
            get
            {
                return this.iso_amount;
            }
            set
            {
                this.iso_amount = value;
            }
        }
    }
    public class Element_set
    {
        private List<ChemForm.Isotopes2> isotopes = new List<ChemForm.Isotopes2>();
        private string name;
        private int number;
        private int all_iso_calc_amount;
        private int iso_amount;
        private List<ChemForm.Isotopes2> isotopes_single = new List<ChemForm.Isotopes2>();

        public List<ChemForm.Isotopes2> Isotopes
        {
            get
            {
                return this.isotopes;
            }
            set
            {
                this.isotopes = value;
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
        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
        public int All_iso_calc_amount
        {
            get
            {
                return this.all_iso_calc_amount;
            }
            set
            {
                this.all_iso_calc_amount = value;
            }
        }
        public int Iso_amount
        {
            get
            {
                return this.iso_amount;
            }
            set
            {
                this.iso_amount = value;
            }
        }
        public List<ChemForm.Isotopes2> Isotopes_single
        {
            get
            {
                return this.isotopes_single;
            }
            set
            {
                this.isotopes_single = value;
            }
        }
        public Element_set DeepCopy()
        {
            Element_set deepcopy = new Element_set() { Isotopes=this.Isotopes ,Name=this.Name, All_iso_calc_amount=this.All_iso_calc_amount, Isotopes_single=this.Isotopes_single, Iso_amount=this.Iso_amount, Number=this.Number};
            return deepcopy;
        }
    }
    public class CompoundMulti
    {
        private int[] sum;
        private int[] counter;
        private double abundance;
        private double mass;
        private Int16 indicator_iso;

        public int[] Sum
        {
            get
            {
                return this.sum;
            }
            set
            {
                this.sum = value;
            }
        }
        public int[] Counter
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
        public double Abundance
        {
            get
            {
                return this.abundance;
            }
            set
            {
                this.abundance = value;
            }
        }
        public double Mass
        {
            get
            {
                return this.mass;
            }
            set
            {
                this.mass = value;
            }
        }
        public short Indicator_iso
        {
            get
            {
                return this.indicator_iso;
            }
            set
            {
                this.indicator_iso = value;
            }
        }

        public CompoundMulti DeepCopy()
        {
            CompoundMulti deepcopy = new CompoundMulti() { Sum = (int[])this.Sum.Clone(), Abundance = this.Abundance, Mass = this.Mass, Counter = (int[])this.Counter.Clone(), Indicator_iso = this.Indicator_iso };
            return deepcopy;
        }
    }
    public class Compound
    {
        private int[] sum;
        private double abundance;
        private double mass;
        private int counter;
        private Int16 indicator_iso;

        public int[] Sum
        {
            get
            {
                return this.sum;
            }
            set
            {
                this.sum = value;
            }
            
        }
        public double Abundance
        {
            get
            {
                return this.abundance;
            }
            set
            {
                this.abundance = value;
            }
        }
        public double Mass
        {
            get
            {
                return this.mass;
            }
            set
            {
                this.mass = value;
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
        public short Indicator_iso
        {
            get
            {
                return this.indicator_iso;
            }
            set
            {
                this.indicator_iso = value;
            }
        }

        public Compound DeepCopy()
        {
            Compound deepcopy = new Compound() { Sum =(int[]) this.Sum.Clone(), Abundance = this.Abundance ,Mass=this.Mass,Counter=this.Counter,Indicator_iso=this.Indicator_iso};
            return deepcopy;
        }
    }
   
    public class Combination_4
    {
        private List<Compound> compounds = new List<Compound>();
        private Element_set element = new Element_set();
        private double max_abundance;
        private int amount;
        private int tracking;
        private List<Compound> combGroup = new List<Compound>();

        public List<Compound> Compounds
        {
            get
            {
                return this.compounds;
            }
            set
            {
                this.compounds = value;
            }
        }
        public Element_set Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }
        public double Max_abundance
        {
            get
            {
                return this.max_abundance;
            }
            set
            {
                this.max_abundance = value;
            }
        }
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
        public int Tracking
        {
            get
            {
                return this.tracking;
            }
            set
            {
                this.tracking = value;
            }
        }
        public List<Compound> CombGroup
        {
            get
            {
                return this.combGroup;
            }
            set
            {
                this.combGroup = value;
            }
        }

        public Combination_4 DeepCopy()
        {
            Combination_4 deepcopy = new Combination_4() { Tracking = this.Tracking, Amount=this.Amount, Element=(Element_set)this.Element.DeepCopy(), Max_abundance=this.Max_abundance, CombGroup= (List < Compound > )this.CombGroup.ConvertAll(item => item.DeepCopy()), Compounds= (List<Compound>)this.Compounds.ConvertAll(item => item.DeepCopy()) };
            return deepcopy;
        }

    }
    public class Combination_1
    {
        private List<Compound> compounds = new List<Compound>();
        private List<Compound> combGroup = new List<Compound>();
        private List<Compound> a2_list = new List<Compound>();
        private Element_set element = new Element_set();
        private double max_abundance;
        private int amount;
        private int a2_amount;
        private int tracking;

        public List<Compound> Compounds
        {
            get
            {
                return this.compounds;
            }
            set
            {
                this.compounds = value;
            }
        }
        public List<Compound> CombGroup
        {
            get
            {
                return this.combGroup;
            }
            set
            {
                this.combGroup = value;
            }
        }
        public List<Compound> A2_list
        {
            get
            {
                return this.a2_list;
            }
            set
            {
                this.a2_list = value;
            }
        }
        public Element_set Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }
        public double Max_abundance
        {
            get
            {
                return this.max_abundance;
            }
            set
            {
                this.max_abundance = value;
            }
        }
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
        public int A2_amount
        {
            get
            {
                return this.a2_amount;
            }
            set
            {
                this.a2_amount = value;
            }
        }
        public int Tracking
        {
            get
            {
                return this.tracking;
            }
            set
            {
                this.tracking = value;
            }
        }

        public Combination_1 DeepCopy()
        {
            Combination_1 deepcopy = new Combination_1() { Tracking = this.Tracking,A2_amount=this.A2_amount, Amount = this.Amount, Element = (Element_set)this.Element.DeepCopy(), Max_abundance = this.Max_abundance, A2_list = (List<Compound>)this.A2_list.ConvertAll(item => item.DeepCopy()), CombGroup = (List<Compound>)this.CombGroup.ConvertAll(item => item.DeepCopy()), Compounds = (List<Compound>)this.Compounds.ConvertAll(item => item.DeepCopy()) };
            return deepcopy;
        }
    }
    public class CombinationMulti2
    {
        private List<CompoundMulti> compounds = new List<CompoundMulti>();
        private double max_abundance;
        private int amount;

        public List<CompoundMulti> Compounds
        {
            get
            {
                return this.compounds;
            }
            set
            {
                this.compounds = value;
            }
        }
        public double Max_abundance
        {
            get
            {
                return this.max_abundance;
            }
            set
            {
                this.max_abundance = value;
            }
        }
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
    }
    public class CombinationMulti
    {
        private List<Compound> compounds = new List<Compound>();
        private double max_abundance;
        private int amount;

        public List<Compound> Compounds
        {
            get
            {
                return this.compounds;
            }
            set
            {
                this.compounds = value;
            }
        }
        public double Max_abundance
        {
            get
            {
                return this.max_abundance;
            }
            set
            {
                this.max_abundance = value;
            }
        }
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
    }
    #endregion

    #region old code
    //public class Element_set
    //{
    //    private List<ChemForm.Isotopes2> isotopes=new List<ChemForm.Isotopes2>();
    //    private string name;
    //    private int number;
    //    private int all_iso_calc_amount;
    //    private int iso_amount;

    //    public List<ChemForm.Isotopes2> Isotopes { get => isotopes; set => isotopes = value; }
    //    public string Name { get => name; set => name = value; }
    //    public int Number { get => number; set => number = value; }
    //    public int All_iso_calc_amount { get => all_iso_calc_amount; set => all_iso_calc_amount = value; }
    //    public int Iso_amount { get => iso_amount; set => iso_amount = value; }
    //}
    //public class CompoundMulti
    //{
    //    private int[] sum;
    //    private List<int> counter;
    //    private double abundance;
    //    private double mass;
    //    private Int16 indicator_iso;

    //    public int[] Sum { get => sum; set => sum = value; }
    //    public List<int> Counter { get => counter; set => counter = value; }
    //    public double Abundance { get => abundance; set => abundance = value; }
    //    public double Mass { get => mass; set => mass = value; }
    //    public short Indicator_iso { get => indicator_iso; set => indicator_iso = value; }
    //}
    //public class Compound
    //{
    //    private int[] sum;
    //    private double abundance;
    //    private double mass;
    //    private int counter;
    //    private Int16 indicator_iso;

    //    public int[] Sum { get => sum; set => sum = value; }
    //    public double Abundance { get => abundance; set => abundance = value; }
    //    public double Mass { get => mass; set => mass = value; }
    //    public int Counter { get => counter; set => counter = value; }
    //    public short Indicator_iso { get => indicator_iso; set => indicator_iso = value; }
    //}
    //public class Combination_1
    //{
    //    private List<Compound> compounds;
    //    private List<Compound> combGroup;
    //    private List<Compound> a2_list;
    //    private Element_set element;
    //    private double max_abundance;
    //    private int amount;
    //    private int a2_amount;
    //    private int tracking;

    //    public List<Compound> Compounds { get => compounds; set => compounds = value; }
    //    public List<Compound> CombGroup { get => combGroup; set => combGroup = value; }
    //    public List<Compound> A2_list { get => a2_list; set => a2_list = value; }
    //    public Element_set Element { get => element; set => element = value; }
    //    public double Max_abundance { get => max_abundance; set => max_abundance = value; }
    //    public int Amount { get => amount; set => amount = value; }
    //    public int A2_amount { get => a2_amount; set => a2_amount = value; }
    //    public int Tracking { get => tracking; set => tracking = value; }
    //}
    #endregion

    public class PointPlot
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointPlot DeepCopy()
        {
            PointPlot deepcopy = new PointPlot() { X=this.X, Y=this.Y };
            return deepcopy;
        }
    }
    public class ChemiForm
    {
        public static List<double> xs = new List<double>();
        public static List<double> ys = new List<double>();

        #region ChemiForm class parameters set
        private List<Element_set> elements_set = new List<Element_set>();
        private int charge;
        private string mz;
        private string inputFormula;
        private string finalFormula;
        private string printFormula;
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
        private OxyColor color;
        private CompoundMulti monoisotopic;
        private int iso_total_amount;
        private List<PointPlot> points = new List<PointPlot>();
        private List<Combination_1> combinations = new List<Combination_1>();
        private List<Combination_4> combinations4 = new List<Combination_4>();
        private string machine;
        private float resolution;
        private List<PointPlot> profile = new List<PointPlot>();
        private List<PointPlot> centroid = new List<PointPlot>();
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
        public List<PointPlot> Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
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
        public string PrintFormula
        {
            get
            {
                return this.printFormula;
            }
            set
            {
                this.printFormula = value;
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

        public CompoundMulti Monoisotopic
        {
            get
            {
                return this.monoisotopic;
            }
            set
            {
                this.monoisotopic = value;
            }
        }
        public int Iso_total_amount
        {
            get
            {
                return this.iso_total_amount;
            }
            set
            {
                this.iso_total_amount = value;
            }
        }
        public List<Element_set> Elements_set
        {
            get
            {
                return this.elements_set;
            }
            set
            {
                this.elements_set = value;
            }
        }

        public List<Combination_1> Combinations
        {
            get
            {
                return this.combinations;
            }
            set
            {
                this.combinations = value;
            }
        }
        public List<Combination_4> Combinations4
        {
            get
            {
                return this.combinations4;
            }
            set
            {
                this.combinations4 = value;
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


        public ChemiForm DeepCopy()
        {
            ChemiForm deepcopyChemiform = new ChemiForm() { Adduct = this.Adduct, Centroid = this.Centroid.ConvertAll(item => item.DeepCopy()), Charge = this.Charge, Color= this.Color, Combinations= (List<Combination_1>)this.Combinations.ConvertAll(item => item.DeepCopy()), Combinations4 = (List<Combination_4>)this.Combinations4.ConvertAll(item => item.DeepCopy()), Deduct=this.Deduct, Elements_set= (List<Element_set>)this.Elements_set.ConvertAll(item => item.DeepCopy()),
                Error =this.Error, FinalFormula=this.FinalFormula, Index=this.Index, IndexTo=this.IndexTo, InputFormula=this.InputFormula, Ion=this.Ion, Ion_type=this.Ion_type, Iso_total_amount=this.Iso_total_amount, Machine= this.Machine, Monoisotopic=this.Monoisotopic, Multiplier=this.Multiplier, Mz=this.Mz, Name=this.Name, Points=this.Points.ConvertAll(item => item.DeepCopy()), PrintFormula=this.PrintFormula, Profile=this.Profile.ConvertAll(item => item.DeepCopy()),
                Radio_label=this.Radio_label, Resolution=this.Resolution };

            return deepcopyChemiform;
        }
        #endregion

        #region Centroid Intersoid detection
        public static void Vdetect(ChemiForm chem, string detect = "centroid")
        {

            double centroid = 0.0;
            double sum_sticks = 0.0;
            double upper_sum_a = 0.0;
            double lower_sum_a = 0.0;
            double max_centroid = 0.0;
            double max_intensoid = 0.0;
            //int centroid_count = 0;
            int j = 0;
            int step = 1;

            if (detect != "centroid" && detect != "intensoid" && detect != "valley")
            {
                //error
                MessageBox.Show("WARNING: invalid detect argument");
                return;
            }

            for (int i = step; i < (chem.Profile.Count - step); i++)
            {
                if (detect == "intensoid")
                {
                    //reminder X stands for mass and Y for abundance
                    if ((chem.Profile[i].Y > chem.Profile[i + step].Y && chem.Profile[i].Y > chem.Profile[i - step].Y) &&
                        (chem.Profile[i - step].X < chem.Profile[i].X && chem.Profile[i].X < chem.Profile[i + step].X))
                    {
                        chem.centroid.Add(new PointPlot { X = chem.Profile[i].X, Y = chem.Profile[i].Y });
                        //Envipat code :
                        // j++;
                        //due to "index out of range error" "j++;" is added after the if statement
                        if (chem.centroid[j].Y > max_intensoid)
                        {
                            max_intensoid = chem.centroid[j].Y;
                        }
                        j++;
                    }
                }
                else
                {
                    centroid += chem.Profile[i].Y * chem.Profile[i].X;
                    sum_sticks += chem.Profile[i].Y;

                    double diff_mass = chem.Profile[i].X - chem.Profile[i - 1].X;
                    upper_sum_a += diff_mass * chem.Profile[i].Y;
                    lower_sum_a += diff_mass * chem.Profile[i - 1].Y;

                    if ((chem.Profile[i].Y <= chem.Profile[i + step].Y && chem.Profile[i].Y < chem.Profile[i - step].Y) || i == chem.Profile.Count - step - 1)
                    {
                        double centroid_temp = (upper_sum_a + lower_sum_a) / 2.0;
                        if (detect == "valley")
                        {
                            chem.Centroid.Add(new PointPlot { X = chem.Profile[i].X, Y = chem.Profile[i].Y });
                            j++;
                        }
                        if (max_centroid < centroid_temp)
                        {
                            max_centroid = centroid_temp;
                        }
                        if (detect == "centroid")
                        {
                            if (sum_sticks > 0.0 && centroid_temp > 0.0)
                            {
                                chem.Centroid.Add(new PointPlot { X = (centroid / sum_sticks), Y = centroid_temp });
                                j++;
                                //centroid_count++;
                            }
                        }
                        centroid = 0.0;
                        sum_sticks = 0.0;
                        upper_sum_a = 0.0;
                        lower_sum_a = 0.0;
                    }
                }
            }
            if (detect == "centroid")
            {
                foreach (PointPlot t in chem.Centroid)
                {
                    double temp = t.Y * (100 / max_centroid);
                    t.Y = temp;
                }
            }
            return;
        }
        #endregion

        #region Envelope calculation for profile
        public static IEnumerable<double> Range(double start, double end, Func<double, double> step)
        {
            //check parameters
            while (start <= end)
            {
                yield return start;
                start = step(start);
            }
        }
        public static void Envelope(ChemiForm chem, double frac = 0.1, int filter = 1, double thres_profile = 0.0)
        {
            //Peak shape function "Gaussian"-->profile_type = 0 
            //code as dmz="get" default value. Derive stick discretization from argument resolution. As written in the manual :
            //" the stick discretization is retrieved from (dm/z)*frac, with (dm/z) = (m/z)/R = peak width at half maximum."

            if (chem.Error == false)
            {
                //create stick masses                       
                double extend = 0.5;//default value in code
                int index_prev_m = 0;
                int c = 0;                
                //reminder X stands for mass and Y for abundance
                var array = chem.Points.Select(x => x.X).ToArray();
                double average = array.Average();
                double dmz2 = average / (double)chem.Resolution;
                double a_max = chem.Points.Max(x => x.Y);

                IEnumerable<double> traceit = ChemiForm.Range(chem.Points.Min(x => x.X) - 1, chem.Points.Max(x => x.X) + extend, x => x + (dmz2 * frac));
                foreach (double tr in traceit)
                {
                    //in C++ Envipat<profile.c< calc_profile_with_trace "tr" is equivalent with "m"( = *(trace + i);)
                    double value = 0.0;
                    for (int i = index_prev_m; i < chem.Points.Count; i++)
                    {
                        double mk = chem.Points[i].X;
                        double ab = chem.Points[i].Y;
                        double v = ab * Math.Exp(-1.0 * (Math.Pow(tr - mk, 2.0) * Math.Pow(chem.Resolution, 2.0) * Math.Log(256)) / (2.0 * Math.Pow(mk, 2.0)));
                        if (thres_profile == 0.0)
                        {
                            if (tr < mk)
                            {
                                double threshold = a_max * Math.Exp(-1.0 * (Math.Pow(tr - mk, 2.0) * Math.Pow((double)chem.Resolution, 2.0) * Math.Log(256.0)) / (2.0 * Math.Pow(mk, 2.0)));
                                if (threshold == 0.0)
                                {
                                    break;
                                }
                            }
                            if (tr > mk)
                            {
                                double m_prev = chem.Points[index_prev_m].X;
                                double threshold = a_max * Math.Exp(-1.0 * (Math.Pow(tr - m_prev, 2.0) * Math.Pow((double)chem.Resolution, 2.0) * Math.Log(256)) / (2.0 * Math.Pow(m_prev, 2.0)));
                                if (threshold == 0.0)
                                {
                                    index_prev_m = i;
                                }
                            }
                        }
                        else if (filter == 0)
                        {
                            if (Math.Abs(tr - mk) > thres_profile)
                            {
                                if (tr < mk)
                                {
                                    break;
                                }
                                else
                                {
                                    index_prev_m = i;
                                }
                            }
                        }
                        value += v;
                    }
                    if (filter == 0)
                    {
                        if (c > 0)
                        {
                            if (value > 0.0 || (value == 0.0 && chem.Profile[c - 1].Y > 0.0))
                            {
                                chem.Profile.Add(new PointPlot { X = tr, Y = value });
                                c++;
                            }
                        }
                        else
                        {
                            if (value > 0.0)
                            {
                                chem.Profile.Add(new PointPlot { X = tr, Y = value });
                                c++;
                            }
                        }
                    }
                    else
                    {
                        chem.Profile.Add(new PointPlot { X = tr, Y = value });
                        c++;
                    }
                }

            }


        }
        #endregion

        #region Resolution Calculation
        public static void Get_R(ChemiForm l,bool calculate_matrix=false)
        {
            if (l.Error == false)
            {                
                if (Resolution_List.L.TryGetValue(l.Machine, out Resolution_List.MachineR data))
                {
                    int n = 50;
                    float stepSize = (data.m_z[data.m_z.Length - 1] - data.m_z[0]) / (n - 1);
                    float[] x1 = new float[1];
                    if (l.Charge == 0 || l.Charge == 1)
                    {
                        x1 = new float[] { (float)l.Monoisotopic.Mass };
                    }
                    else
                    {
                        x1 = new float[] { (float)l.Monoisotopic.Mass / Math.Abs(l.Charge) };
                    }
                    if (data.m_z[data.m_z.Length - 1] <= x1[0])
                    {
                        l.Resolution = data.R[data.m_z.Length - 1]; return;
                    }
                    if (data.m_z[0] >= x1[0])
                    {
                        l.Resolution = data.R[0]; return;
                    }
                    //if (l.Machine.Contains("resolution from file"))
                    //{
                    //    for (int kx = 0; kx < x.Count(); kx++)
                    //    {
                    //        if (x[kx] >= x1[0])
                    //        {
                    //            if (kx == 0) { l.Resolution = y[kx]; break; }
                    //            l.Resolution = Math.Abs(y[kx] + y[kx - 1]) / 2; break;
                    //        }                           
                    //    }                       
                    //}
                    //else
                    //{
                    // Create the upsampled X values to interpolate
                    //if (calculate_matrix == true)
                    //{
                    
                        float[] x = data.m_z;
                        float[] y = data.R;
                        List<float> xss = new List<float>();
                        float step = new float();
                        for (int i = 0; i < n; i++)
                        {
                            xs.Add( x[0] + i * stepSize);
                        }
                        xss.Add( x.Last());
                        double[] x_ = Array.ConvertAll(data.m_z, k => (double)k);
                        double[] y_ = Array.ConvertAll(data.R, k => (double)k);
                        double[] w = new double[y_.Count()];
                        double v = 0.0;
                        for (int u=0;u< y_.Count(); u++){ w[u] = 1; }
                        int info = new int();
                        alglib.spline1dinterpolant s = new alglib.spline1dinterpolant();
                        alglib.spline1dfitreport rep = new alglib.spline1dfitreport();
                        double rho = 1;
                        alglib.spline1dfitpenalized(x_,y_, 50,rho,out info,out s,out rep);
                        v = alglib.spline1dcalc(s, x1[0]);
                        l.Resolution = (float)v;
                        //for (int h=0; h< xs.Count(); h++)
                        //{
                        //    v = alglib.spline1dcalc(s, xs[h]);
                        //    ys.Add(v);
                        //}
                        // Fit and eval
                        //CubicSpline spline = new CubicSpline();
                        //float[] yss = spline.FitAndEval(x, y, xss.ToArray(), Single.NaN, Single.NaN);
                        //xs = xss.ToList();
                        //ys = yss.ToList();
                        #region in case of saving resolution results
                        //SaveFileDialog save = new SaveFileDialog() { Title = "Resolution", FileName = "Resolution", Filter = "Data Files (*.txt)|*.txt", DefaultExt = "txt", OverwritePrompt = true, AddExtension = true };

                        //if (save.ShowDialog() == DialogResult.OK)
                        //{
                        //    System.IO.StreamWriter file = new System.IO.StreamWriter(save.OpenFile());  // Create the path and filename.


                        //    for (int r = 0; r < ys.Count(); r++) file.WriteLine(xs[r] + "\t" + ys[r]);
                        //    file.Flush(); file.Close(); file.Dispose();
                        //}
                        #endregion   
                    //}

                    
                    //for (int kx = 1; kx < xs.Count(); kx++)
                    //{
                    //    if (xs[kx] >= x1[0])
                    //    {
                    //        if (kx == 0) { l.Resolution = ys[kx]; break; }
                    //        l.Resolution = Math.Abs(ys[kx] + ys[kx - 1]) / 2;
                    //        break;
                    //    }
                    //    //else if (xs[kx] < x1[0] - 100 * stepSize && (kx + 100) < xs.Count()) kx = kx + 99;
                    //    //else if (xs[kx] < x1[0] - 50 * stepSize && (kx + 50) < xs.Count()) kx = kx + 48;
                    //    //else if (xs[kx] < x1[0] - 10 * stepSize && (kx + 10) < xs.Count()) kx = kx + 6;
                    //}
                    //}


                }
                else
                {
                    l.Error = true;
                }
            }
        }
        #endregion

        #region Pattern calculation
        public static void Isopattern(ChemiForm chem, Int64 peak_limit, Int16 algo = 1, Int16 rtm = 0, double threshold = 0.01)
        {

            //rtm...0,1,2,3 or 4
            if (rtm != 0 && rtm != 1 && rtm != 2 && rtm != 3 && rtm != 4)
            {
                MessageBox.Show("Default option rel_to=0 prunes and returns probabilities relative to " +
                    "the most intense isotope peak; threshold states a percentage of the intensity of" +
                    " this latter peak. Similarly, option rel_to = 1 normalizes relative to the peak" +
                    " consisting of the most abundant isotopes for each element, which is often the" +
                    " monoisotopic one.Option rel_to = 2 prunes and returns absolute probabilities;" +
                    " threshold is not a percentage but an abolute cutoff.Options rel_to = 3 and " +
                    "rel_to = 4 prune relative to the most intense and monoisotopic peak, respectively." +
                    "Although threshold is a percentage, both options return absolut probabilities.");
            }
            if (peak_limit < 1)
            {
                MessageBox.Show("peak limit is an integer>=1");
            }



            if (chem.Error == false)
            {
                if (algo == 1)
                {
                    Calc_pattern_algo1(chem, threshold, rtm, peak_limit);
                }
                else if (algo == 2)
                {
                    Calc_pattern_algo4(chem, threshold, rtm, peak_limit);
                }
                else
                {
                    //error
                    MessageBox.Show("error in algo input");
                    return;
                }
            }
            else
            {
                MessageBox.Show("The input formula is not correct");
                Application.Exit();
            }

        }
        public static void Calc_pattern_algo4(ChemiForm chem, double threshold, Int16 rtm, Int64 peak_limit, int ALGO4_BLOCK_SIZE = 2)
        {
            Int64 peak_amount = 0;
            //double mono_abundance = -1.0;
            double max_abundance = 1.0;
            Int16 container_border = 0;
            Int16 container_amount = 0;
            Int16 container_amount_tmp = 0;
            int element_index = 0;
            double div = 0.0;
            //int pos = 0;
            int container_factor = ALGO4_BLOCK_SIZE;
            List<Element_set> element_set = chem.Elements_set;
            int element_amount = element_set.Count();

            chem.Monoisotopic.Sum = Enumerable.Repeat(0, chem.Iso_total_amount).ToArray();
            chem.Monoisotopic.Counter = Enumerable.Repeat(0, element_amount).ToArray();

            CombinationMulti2 A = new CombinationMulti2();
            CombinationMulti2 A2 = new CombinationMulti2();
            CombinationMulti2 C = new CombinationMulti2();

            if (ALGO4_BLOCK_SIZE <= 0)
            {
                container_factor = 1;
            }
            if (ALGO4_BLOCK_SIZE > element_amount)
            {
                container_factor = element_amount;
            }


            //// take the first elements with 3 or less isotopes into a single element container, the other elements into "container_factor" containers
            ////calc_pattern_algo_4
            container_border = 3;
            foreach (Element_set el in element_set)
            {
                //mono_abundance *=Math.Pow(el.Isotopes[0].abundance,el.Number);
                //chem.Monoisotopic.Sum[pos] = el.Number;
                //pos += el.Iso_amount;
                if (el.Iso_amount <= container_border)
                {
                    container_amount++;
                }
                else
                {
                    container_amount_tmp++;
                }
            }
            div = (double)container_amount_tmp / (double)container_factor;
            container_amount += (Int16)Math.Ceiling(div);
            chem.Monoisotopic = Calc_moinoisotopic(element_set, 0, element_amount, chem.Iso_total_amount);
            //mono_abundance = chem.Monoisotopic.Abundance;
            for (int j = 0; j < container_amount; j++)
            {
                if (element_set[element_index].Iso_amount > container_border)
                {
                    container_factor = ALGO4_BLOCK_SIZE;
                }
                else
                {
                    container_factor = 1;
                }
                if (j == container_amount - 1)
                {
                    int element_range = element_amount - element_index;

                    //call create combination algo4
                    chem.Combinations4.Add(Create_combination_algo4(ref element_set, element_index, element_range, ref A, ref A2, ref C, threshold, rtm, chem.Monoisotopic.Abundance));
                    if (element_range == 0)
                    {
                        container_amount--;
                        break;
                    }
                }
                else
                {
                    int element_range = container_factor;
                    if (element_index + container_factor >= element_amount)
                    {
                        element_range = element_amount - element_index;
                    }
                    if (element_range == 0)
                    {
                        container_amount--;
                        break;
                    }
                    chem.Combinations4.Add(Create_combination_algo4(ref element_set, element_index, element_range, ref A, ref A2, ref C, threshold, rtm, chem.Monoisotopic.Abundance));
                }
                max_abundance *= chem.Combinations4[j].Max_abundance;
                element_index += container_factor;
            }
            double max_a = max_abundance;
            if (rtm == 1 || rtm == 4)
            {
                max_abundance = chem.Monoisotopic.Abundance;
            }
            else if (rtm == 2)
            {
                max_abundance = 100.0;
            }
            if (container_amount == 0)
            {
                //error:  amount of compounds within container is zero
                return;

            }
            if (rtm != 2)
            {
                chem.Combinations4 = Clean_combination_algo4(chem.Combinations4, threshold * max_abundance / 100.0, container_amount);
            }
            else
            {
                chem.Combinations4 = Clean_combination_algo4(chem.Combinations4, threshold, container_amount);
            }
            //call combine combinations
            Combine_combinations_algo4(chem, container_amount, threshold, ref peak_amount, peak_limit, max_abundance, rtm);
            //chem.Elements_set = element_set;
        }
        public static void Combine_combinations_algo4(ChemiForm chem, Int16 container_amount, double threshold, ref Int64 peak_amount, Int64 peak_limit, double max_abundance, Int16 rtm)
        {
            List<PointPlot> Data = new List<PointPlot>();
            double emass = 0.00054858;
            double mass = 0.0;
            double abundance = 1.0;
            int v = 0;
            chem.Combinations4[0].Tracking = 0;

            //CombGroup includes all the combination's compounds except the one's excluded by clean_combination_algo4
            foreach (Combination_4 comb in chem.Combinations4)
            {
                for (int i = 0; i < comb.Amount; i++)
                {
                    comb.CombGroup.Add(CompCopy(comb.Compounds[i]));
                }
                comb.Tracking = 0;

                //comb.CombGroup = comb.CombGroup.OrderByDescending(x => x.Abundance).ToList();
                comb.CombGroup.Sort((a, b) => b.Abundance.CompareTo(a.Abundance));
                comb.CombGroup = RemoveDuplicates(comb.CombGroup);
            }

            while (chem.Combinations4[0].Tracking < chem.Combinations4[0].Amount)
            {

                mass = 0.0;
                abundance = 1.0;
                List<int> cc_tmp = new List<int>();
                foreach (Combination_4 comb in chem.Combinations4)
                {
                    int e_a = comb.Element.Iso_amount;
                    //v: counts the peak number

                    // the last combination container
                    if (comb == chem.Combinations4[chem.Combinations4.Count - 1])
                    {
                        double tmp_mass = 0.0;
                        double tmp_abundance = 1.0;
                        for (int h = 0; h < comb.Amount; h++)
                        {
                            tmp_mass = mass;
                            tmp_abundance = abundance;
                            tmp_mass += comb.CombGroup[comb.Tracking].Mass;
                            tmp_abundance *= comb.CombGroup[comb.Tracking].Abundance;
                            if ((100 / max_abundance) * tmp_abundance >= threshold)
                            {
                                if (rtm == 3 || rtm == 4)
                                {
                                    //a=tmp_abundance;
                                    if (chem.Charge == 0)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass, Y = tmp_abundance });

                                    }
                                    else if (chem.Charge == 1)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass - emass, Y = tmp_abundance });
                                    }
                                    else
                                    {
                                        Data.Add(new PointPlot { X = ((tmp_mass - chem.Charge * emass) / Math.Abs(chem.Charge)), Y = tmp_abundance });
                                    }

                                }
                                else
                                {
                                    //a=(100/max_abundance)*tmp_abundance;
                                    if (chem.Charge == 0)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass, Y = (100 / max_abundance) * tmp_abundance });

                                    }
                                    else if (chem.Charge == 1)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass - emass, Y = (100 / max_abundance) * tmp_abundance });
                                    }
                                    else
                                    {
                                        Data.Add(new PointPlot { X = (tmp_mass - chem.Charge * emass) / Math.Abs(chem.Charge), Y = (100 / max_abundance) * tmp_abundance });
                                    }

                                }
                                for (int s = 0; s < comb.Compounds[comb.Tracking].Sum.Length; s++)
                                {
                                    cc_tmp.Add(comb.CombGroup[comb.Tracking].Sum[s]);
                                }
                                //
                                //

                                v++;
                                if (v >= peak_limit)
                                {
                                    //exceeded amount of peaks 
                                    peak_amount = v;
                                    return;

                                }
                                comb.Tracking++;
                            }
                            else
                            {
                                comb.Tracking++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (comb.Tracking < comb.Amount)
                        {
                            mass += comb.CombGroup[comb.Tracking].Mass;
                            abundance *= comb.CombGroup[comb.Tracking].Abundance;

                            for (int s = 0; s < comb.CombGroup[comb.Tracking].Sum.Length; s++)
                            {
                                cc_tmp.Add(comb.CombGroup[comb.Tracking].Sum[s]);
                                if (cc_tmp.Count >= chem.Iso_total_amount)
                                {
                                    peak_amount = v;
                                    return;
                                    //error
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                for (int k = container_amount - 2; k >= 0; k--)
                {
                    if (chem.Combinations4[k].Tracking < chem.Combinations4[k].Amount)
                    {
                        chem.Combinations4[k].Tracking++;
                        for (int l = k + 1; l < container_amount; l++)
                        {
                            chem.Combinations4[l].Tracking = 0;
                        }
                        break;
                    }
                }

            }
            peak_amount = v;

            //IEnumerable<PointPlot> Pattern_Points = Data.OrderBy(p => p.X);
            //foreach (PointPlot p in Pattern_Points)
            //{
            //    chem.Points.Add(new PointPlot { X = p.X, Y = p.Y });
            //}

            List<PointPlot> DataSort = Data.OrderBy(p => p.X).ToList();
            chem.Points = RemoveDuplicatesPoint(DataSort);
            if (chem.Points.Count > 0)
            {
                return;
            }
            else
            {
                // error
                return;
            }
        }
        public static List<Combination_4> Clean_combination_algo4(List<Combination_4> combinations, double threshold, int container_amount)
        {
            //container_amount  in the Envipat code clean_combination_algo_4 is "element_amount"(only in "clean_combination_algo_4" section)

            double clean_abundance = 1.0;
            double clean_abundance_other = 1.0;
            for (int b = 0; b < container_amount; b++)
            {
                clean_abundance_other = 1.0;
                for (int d = 0; d < container_amount; d++)
                {
                    if (d != b)
                    {
                        clean_abundance_other *= combinations[d].Max_abundance;
                    }
                }
                for (int c = combinations[b].Amount - 1; c >= 0; c--)
                {
                    clean_abundance = 1.0;
                    clean_abundance *= combinations[b].Compounds[c].Abundance * clean_abundance_other;

                    if (clean_abundance < threshold)
                    {
                        //if c is index to the last combination we only decrease C.Amount
                        if (c == combinations[b].Amount - 1)
                        {
                            combinations[b].Amount--;
                        }
                        //in the other case we put the "last" combination in its place and then decrease C.Amount
                        else
                        {
                            combinations[b].Compounds[c] = CompCopy(combinations[b].Compounds[combinations[b].Amount - 1]);
                            combinations[b].Amount--;
                        }
                    }
                }
            }
            return combinations;
        }
        public static Combination_4 Create_combination_algo4(ref List<Element_set> element_set, int element_index, int element_range, ref CombinationMulti2 A, ref CombinationMulti2 A2, ref CombinationMulti2 C, double threshold, int rtm, double mono_a)
        {
            //element_range in the Envipat code create_combination_algo_4 is "element_amount"(only in "create_combination_algo_4" section)
            Combination_4 combination = new Combination_4();
            CompoundMulti current_highest = new CompoundMulti();
            CompoundMulti monoisotopic = new CompoundMulti();
            CompoundMulti current = new CompoundMulti();
            List<ChemForm.Isotopes2> Isotopes_List = new List<ChemForm.Isotopes2>();
            Int16 iso_c = 0;
            //int iso_total = 0;
            int iso_nr_max = 0;
            int c = 0;
            int h = 0;
            A.Amount = 0;
            A.Max_abundance = 1.0;
            A2.Amount = 0;
            A2.Max_abundance = 1.0;
            C.Amount = 0;
            C.Max_abundance = 1.0;
            double max_a = mono_a;
            double comb_max_a = max_a;
            int[] iso_pos = Enumerable.Repeat(0, element_range).ToArray();

            //for (int i = 0; i < element_range; i++)
            //{
            //    iso_total += element_set[element_index + i].Iso_amount;
            //}
            Isotopes_List = Create_isotope_list(element_set, element_index, element_range, ref iso_c);
            int iso_amount = iso_c + element_range;
            monoisotopic = Calc_moinoisotopic(element_set, element_index, element_range, iso_amount);
            current = CompMultiCopy(monoisotopic);


            if (iso_amount < 1)
            {
                //error  empty isotope list for container
                return combination;
            }
            combination.Compounds.Add(CompMultiCopyToComp(current));
            c++;
            element_set[element_index].All_iso_calc_amount++;

            for (Int16 d = 0; d < element_range; d++)
            {
                iso_pos[d] = 0;
                for (Int16 b = 0; b < d; b++)
                {
                    iso_pos[d] += element_set[element_index + b].Iso_amount;
                }
            }

            while (current.Abundance != -1.0)
            {
                current_highest = CompMultiCopy(current);
                //current_highest = current;
                C.Amount = 0;
                iso_nr_max = 0;

                for (Int16 j = current.Indicator_iso; j < iso_c; j++)
                {
                    h = Isotopes_List[j].element_nr;

                    if (current.Counter[h] < element_set[element_index + h].Number)
                    {
                        List<ChemForm.Isotopes2> isotope = element_set[element_index + h].Isotopes;
                        Int16 iso_e_nr = Isotopes_List[j].iso_e_nr;
                        if (C.Compounds.Count > C.Amount)
                        {
                            C.Compounds[C.Amount] = CompMultiCopy(current);
                        }
                        else
                        {
                            C.Compounds.Add(CompMultiCopy(current));
                        }
                        CompoundMulti comp = C.Compounds[C.Amount];
                        comp.Counter[h]++;
                        comp.Indicator_iso = j;
                        comp.Sum[iso_pos[h] + iso_e_nr]++;
                        comp.Mass -= isotope[0].mass;
                        comp.Mass += isotope[iso_e_nr].mass;
                        comp.Abundance *= isotope[iso_e_nr].abundance * comp.Sum[iso_pos[h]];
                        comp.Abundance /= isotope[0].abundance * comp.Sum[iso_pos[h] + iso_e_nr];
                        comp.Sum[iso_pos[h]]--;

                        if (current_highest.Abundance < comp.Abundance)
                        {
                            //current_highest =CompMultiCopy(comp);
                            current_highest = comp;

                        }
                        if (comp.Abundance >= current.Abundance)
                        {
                            iso_nr_max = j;
                        }
                        element_set[element_index].All_iso_calc_amount++;
                        //if (element_set[element_index].All_iso_calc_amount> ALGO4_BLOCK_SIZE * 2E8)
                        //{
                        //    //error
                        //}

                        //dikh m prosthiki gt o kodikas paizei me pointer
                        C.Compounds[C.Amount] = comp;

                        C.Amount++;

                    }
                }

                if (comb_max_a < current_highest.Abundance)
                {
                    comb_max_a = current_highest.Abundance;
                    if (rtm == 0 || rtm == 3)
                    {
                        max_a = current_highest.Abundance;
                    }
                }
                else if (rtm == 2)
                {
                    max_a = 100;
                }

                if (current_highest.Abundance > current.Abundance)
                {
                    for (int v = C.Amount - 1; v >= 0; v--)
                    {
                        if (C.Compounds[v].Abundance != current_highest.Abundance)
                        {
                            if (C.Compounds[v].Indicator_iso <= iso_nr_max)
                            {
                                A.Compounds.Add(CompMultiCopy(C.Compounds[v]));
                                //A.Compounds.Add((C.Compounds[v]));

                                A.Amount++;

                                //elegxos gia A.amount??
                            }
                            else
                            {
                                if ((100 / max_a) * C.Compounds[v].Abundance >= threshold)
                                {
                                    if (A2.Compounds.Count > A2.Amount)
                                    {
                                        A2.Compounds[A2.Amount] = CompMultiCopy(C.Compounds[v]);
                                    }
                                    else
                                    {
                                        A2.Compounds.Add(CompMultiCopy(C.Compounds[v]));
                                    }
                                    A2.Amount++;
                                    //elegxos gia A2.amount??
                                }
                            }
                        }
                        else
                        {
                            if (C.Compounds.Count > C.Amount)
                            {
                                C.Compounds[C.Amount] = CompMultiCopy(C.Compounds[v]);
                            }
                            else
                            {
                                C.Compounds.Add(CompMultiCopy(C.Compounds[v]));

                            }
                            current_highest = CompMultiCopy(C.Compounds[C.Amount]);
                        }
                    }
                    current = CompMultiCopy(current_highest);
                    if ((100 / max_a) * current_highest.Abundance >= threshold)
                    {
                        if (combination.Compounds.Count > c)
                        {
                            combination.Compounds[c] = CompMultiCopyToComp(current_highest);
                        }
                        else
                        {
                            combination.Compounds.Add(CompMultiCopyToComp(current_highest));
                        }
                        c++;
                    }
                }
                else
                {
                    for (int v = 0; v < C.Amount; v++)
                    {
                        if ((100 / max_a) * C.Compounds[v].Abundance >= threshold)
                        {
                            if (A2.Compounds.Count > A2.Amount)
                            {
                                A2.Compounds[A2.Amount] = CompMultiCopy(C.Compounds[v]);
                            }
                            else
                            {
                                A2.Compounds.Add(CompMultiCopy(CompMultiCopy(C.Compounds[v])));
                            }
                            A2.Amount++;
                        }
                    }

                    if (A.Amount > 0)
                    {
                        CompoundMulti a_c = A.Compounds[A.Amount - 1];
                        current = CompMultiCopy(a_c);
                        A.Amount--;

                        if ((100 / max_a) * a_c.Abundance >= threshold)
                        {
                            if (combination.Compounds.Count > c)
                            {
                                combination.Compounds[c] = CompMultiCopyToComp(a_c);

                            }
                            else
                            {
                                combination.Compounds.Add(CompMultiCopyToComp(a_c));
                            }
                            c++;
                        }
                    }
                    else if (A.Amount == 0 && A2.Amount > 0)
                    {
                        CompoundMulti a2 = A2.Compounds[A2.Amount - 1];
                        current = CompMultiCopy(a2);
                        A2.Amount--;

                        if ((100 / max_a) * a2.Abundance >= threshold)
                        {
                            if (combination.Compounds.Count > c)
                            {
                                combination.Compounds[c] = CompMultiCopyToComp(a2);
                            }
                            else
                            {
                                combination.Compounds.Add(CompMultiCopyToComp(a2));
                            }
                            c++;
                        }
                    }
                    else
                    {
                        current.Abundance = -1.0;
                    }
                }
            }
            combination.Amount = c;
            combination.Max_abundance = comb_max_a;
            combination.Element.Iso_amount = iso_amount;
            combination.Element.Name = element_set[element_index].Name;

            for (int i = 1; i < element_range; i++)
            {
                combination.Element.Name = combination.Element.Name + element_set[element_index + i].Name;
            }

            return combination;
        }

        public static List<ChemForm.Isotopes2> Create_isotope_list(List<Element_set> element_set, int element_index, int element_range, ref Int16 iso_c)
        {
            iso_c = 0;
            List<ChemForm.Isotopes2> List = new List<ChemForm.Isotopes2>();
            for (Int16 i = 0; i < element_range; i++)
            {
                if (element_set[element_index + i].Iso_amount > 1)
                {
                    for (Int16 j = 1; j < element_set[element_index + i].Iso_amount; j++)
                    {
                        List.Add(new ChemForm.Isotopes2
                        {
                            element_nr = i,
                            iso_e_nr = j,
                            number = element_set[element_index + i].Number,
                            abundance = element_set[element_index + i].Isotopes[j].abundance,
                            mass = element_set[element_index + i].Isotopes[j].mass,
                            element = element_set[element_index + i].Isotopes[j].element,
                            isotope = element_set[element_index + i].Isotopes[j].isotope
                        });
                        iso_c++;
                    }
                }
            }
            //List<ChemForm.Isotopes2> ListA=List.OrderByDescending(x => x.number * x.abundance).ToList();
            List.Sort((a, b) => (b.abundance * b.number).CompareTo(a.abundance * a.number));
            return List;
        }
        public static CompoundMulti Calc_moinoisotopic(List<Element_set> element_set, int element_index, int element_range, int iso_total)
        {

            CompoundMulti monoisotopic = new CompoundMulti()
            {
                Sum = Enumerable.Repeat(0, iso_total).ToArray(),
                Counter = Enumerable.Repeat(0, element_range).ToArray(),
                Indicator_iso = 0
            };
            double abundance = 1.0;
            double mass = 0.0;
            int pos = 0;
            for (int i = 0; i < element_range; i++)
            {
                for (int n = 0; n < element_set[element_index + i].Number; n++)
                {
                    mass += element_set[element_index + i].Isotopes[0].mass;
                    abundance *= element_set[element_index + i].Isotopes[0].abundance;
                    monoisotopic.Sum[pos]++;
                }
                pos += element_set[element_index + i].Iso_amount;
            }
            monoisotopic.Mass = mass;
            monoisotopic.Abundance = abundance;

            return monoisotopic;
        }

        public static Compound CompMultiCopyToComp(CompoundMulti original)
        {
            //create a value copy of a compound class object
            Compound copy = new Compound()
            {
                Abundance = original.Abundance,
                Mass = original.Mass
            };
            copy.Sum = Enumerable.Repeat(0, original.Sum.Count()).ToArray();
            for (int s = 0; s < original.Sum.Count(); s++)
            {
                copy.Sum[s] = original.Sum[s];
            }
            return copy;

        }
        public static CompoundMulti CompMultiCopy(CompoundMulti original)
        {
            //create a value copy of a compound class object
            CompoundMulti copy = new CompoundMulti()
            {
                Abundance = original.Abundance,
                Indicator_iso = original.Indicator_iso,
                Mass = original.Mass
            };
            copy.Sum = Enumerable.Repeat(0, original.Sum.Count()).ToArray();
            for (int s = 0; s < original.Sum.Count(); s++)
            {
                copy.Sum[s] = original.Sum[s];
            }
            copy.Counter = Enumerable.Repeat(0, original.Counter.Count()).ToArray();
            for (int s = 0; s < original.Counter.Count(); s++)
            {
                copy.Counter[s] = original.Counter[s];

            }
            return copy;

        }
        public static void Calc_pattern_algo1(ChemiForm chem, double threshold, Int16 rtm, Int64 peak_limit)
        {
            Int64 peak_amount = 0;
            double a_max = 1.0;
            CombinationMulti A = new CombinationMulti();

            //List<Combination_1> combinations = new List<Combination_1>();
            foreach (Element_set els in chem.Elements_set)
            {
                chem.Combinations.Add(new Combination_1 { Element = els });
            }

            for (int i = 0; i < chem.Combinations.Count; i++)
            {
                Combination_1 combination = chem.Combinations[i];
                chem.Combinations[i] = Calc_max_abundance(ref combination, ref A, threshold, rtm);
                a_max *= chem.Combinations[i].Max_abundance;
            }

            if (rtm == 1 || rtm == 4)
            {
                double clean_abundance = 1.0;

                for (int i = 0; i < chem.Combinations.Count; i++)
                {
                    Combination_1 combination = chem.Combinations[i];
                    double combination_mono_abundance = 1.0;
                    for (int n = 0; n < chem.Combinations[i].Element.Number; n++)
                    {
                        combination_mono_abundance *= chem.Combinations[i].Element.Isotopes[0].abundance;
                    }
                    clean_abundance = a_max / chem.Monoisotopic.Abundance;
                    chem.Combinations[i] = Create_combination_algo1(ref combination, clean_abundance, (threshold * chem.Monoisotopic.Abundance) / 100.0, peak_limit, ref A);
                }
                a_max = chem.Monoisotopic.Abundance;
            }
            else if (rtm == 0 || rtm == 3)
            {
                for (int i = 0; i < chem.Combinations.Count; i++)
                {
                    Combination_1 combination = chem.Combinations[i];
                    double clean_abundance = a_max / chem.Combinations[i].Max_abundance;
                    chem.Combinations[i] = Create_combination_algo1(ref combination, clean_abundance, (threshold * a_max) / 100.0, peak_limit, ref A);
                }
            }
            else if (rtm == 2)
            {
                for (int i = 0; i < chem.Combinations.Count; i++)
                {
                    Combination_1 combination = chem.Combinations[i];
                    double clean_abundance = a_max / chem.Combinations[i].Max_abundance;
                    chem.Combinations[i] = Create_combination_algo1(ref combination, clean_abundance, threshold, peak_limit, ref A);
                }
                a_max = 100.0;
            }
            else
            {
                return;
            }

            for (int i = 0; i < chem.Combinations.Count; i++)
            {
                //chem.Combinations[i].CombGroup = chem.Combinations[i].Compounds.OrderByDescending(o => o.Abundance).ToList();
                chem.Combinations[i].Compounds.Sort((a, b) => b.Abundance.CompareTo(a.Abundance));
                chem.Combinations[i].CombGroup = RemoveDuplicates(chem.Combinations[i].Compounds);
            }

            Combine_combinations_algo1(chem, threshold, chem.Iso_total_amount, ref peak_amount, peak_limit, rtm, a_max);

        }
        public static List<Compound> RemoveDuplicates(List<Compound> initial)
        {
            int d = 0;
            int count = 0;
            List<Compound> final = new List<Compound>();
            foreach (Compound cp in initial)
            {
                if (final.Count == 0)
                {
                    final.Add(cp);
                    count++;
                }
                else if (final[count - 1].Mass == cp.Mass && final[count - 1].Abundance == cp.Abundance && final[count - 1].Counter == cp.Counter)
                {
                    d++;
                    continue;
                }
                else
                {
                    final.Add(cp);
                    count++;
                }
            }
            return final;
        }
        public static List<PointPlot> RemoveDuplicatesPoint(List<PointPlot> initial)
        {
            int d = 0;
            int count = 0;
            List<PointPlot> final = new List<PointPlot>();
            foreach (PointPlot cp in initial)
            {
                if (final.Count == 0)
                {
                    final.Add(cp);
                    count++;
                }
                else if (final[count - 1].X == cp.X && final[count - 1].Y == cp.Y)
                {
                    d++;
                    continue;
                }
                else
                {
                    final.Add(cp);
                    count++;
                }
            }
            return final;
        }
        public static Combination_1 Create_combination_algo1(ref Combination_1 combination, double clean_abundance, double threshold, Int64 peak_limit, ref CombinationMulti A)
        {
            Compound current = new Compound();
            A.Amount = 0;
            A.Max_abundance = 1.0;
            int c = combination.Amount;
            if (combination.A2_amount > 0)
            {
                current = CompCopy(combination.A2_list[combination.A2_amount - 1]);
                //current = combination.A2_list[combination.A2_amount - 1];
                combination.A2_amount--;
            }
            else
            {
                if (c == 0 || combination.Max_abundance == 1.0)
                {
                    //error
                    return combination;
                }
                return combination;
            }

            if (clean_abundance * current.Abundance >= threshold && current.Mass > 1.0)
            {
                if (combination.Compounds.Count > c)
                {
                    combination.Compounds[c] = CompCopy(current, 2);
                }
                else
                {
                    combination.Compounds.Add(CompCopy(current, 2));
                }
                c++;

                //element_set.all_iso_calc_amount++;
                /////exei afairethei kai apo to prototypo
            }
            Compound comp = new Compound();
            while (current.Abundance != -1.0)
            {
                for (Int16 j = current.Indicator_iso; j < combination.Element.Isotopes_single.Count; j++)
                {
                    if (current.Counter < combination.Element.Number)
                    {
                        Int16 iso_e_nr = combination.Element.Isotopes_single[j].iso_e_nr;
                        comp = CompCopy(current);
                        comp.Counter++;
                        comp.Indicator_iso = j;
                        comp.Sum[iso_e_nr]++;
                        comp.Mass -= combination.Element.Isotopes[0].mass;
                        comp.Mass += combination.Element.Isotopes[iso_e_nr].mass;
                        comp.Abundance *= combination.Element.Isotopes[iso_e_nr].abundance * (comp.Sum[0]);
                        comp.Abundance /= combination.Element.Isotopes[0].abundance * comp.Sum[iso_e_nr];
                        comp.Sum[0]--;
                        //element_set.all_iso_calc_amount++;
                        //////exei afairethei kai apo to prototypo

                        if (comp.Abundance > current.Abundance)
                        {
                            if (A.Compounds.Count > A.Amount)
                            {
                                A.Compounds[A.Amount] = CompCopy(comp);
                            }
                            else
                            {
                                A.Compounds.Add(CompCopy(comp));
                            }
                            A.Amount++;
                        }
                        else
                        {
                            if (clean_abundance * comp.Abundance >= threshold)
                            {
                                if (combination.A2_list.Count > combination.A2_amount)
                                {
                                    combination.A2_list[combination.A2_amount] = CompCopy(comp);
                                }
                                else
                                {
                                    combination.A2_list.Add(CompCopy(comp));
                                }
                                combination.A2_amount++;
                            }
                        }

                        combination.Element.All_iso_calc_amount++;
                        if (combination.Max_abundance < comp.Abundance)
                        {
                            combination.Max_abundance = comp.Abundance;
                        }
                    }
                }

                if (A.Amount > 0)
                {
                    Compound a_c = A.Compounds[A.Amount - 1];
                    current = CompCopy(a_c);
                    if (clean_abundance * a_c.Abundance >= threshold)
                    {
                        if (combination.Compounds.Count > c)
                        {
                            combination.Compounds[c] = CompCopy(a_c, 2);
                        }
                        else
                        {
                            combination.Compounds.Add(CompCopy(a_c, 2));
                        }
                        c++;
                    }
                    A.Amount--;
                }
                else if (A.Amount == 0 && combination.A2_amount > 0)
                {
                    Compound a2 = combination.A2_list[combination.A2_amount - 1];
                    current = CompCopy(a2);
                    if (clean_abundance * a2.Abundance >= threshold)
                    {
                        if (combination.Compounds.Count > c)
                        {
                            combination.Compounds[c] = CompCopy(a2, 2);

                        }
                        else
                        {
                            combination.Compounds.Add(CompCopy(a2, 2));
                        }
                        c++;
                    }
                    combination.A2_amount--;
                }
                else
                {
                    current.Abundance = -1.0;
                }
            }
            combination.Amount = c;
            return combination;
        }
        public static Compound Calc_monoisotopic_single(Element_set element_set)
        {
            Compound monoisotopic = new Compound();
            double abundance = 1.0;
            double mass = 0.0;
            int pos = 0;
            //monoisotopic.Sum = new int[element_set.Iso_amount];
            //for (int a = 0; a < element_set.Iso_amount; a++)
            //{
            //    monoisotopic.Sum[a] = 0;
            //}

            monoisotopic.Sum = Enumerable.Repeat(0, element_set.Iso_amount).ToArray();

            for (int i = 0; i < element_set.Number; i++)
            {
                mass += element_set.Isotopes[0].mass;
                abundance *= element_set.Isotopes[0].abundance;
                monoisotopic.Sum[pos]++;
            }
            monoisotopic.Counter = 0;
            monoisotopic.Indicator_iso = 0;
            monoisotopic.Mass = mass;
            monoisotopic.Abundance = abundance;

            return monoisotopic;
        }

        public static Compound CompCopy(Compound original, int all = 1)
        {
            //create a value copy of a compound class object
            if (all == 1)
            {
                Compound copy = new Compound()
                {
                    Abundance = original.Abundance,
                    Counter = original.Counter,
                    Indicator_iso = original.Indicator_iso,
                    Mass = original.Mass
                };
                copy.Sum = Enumerable.Repeat(0, original.Sum.Count()).ToArray();
                for (int s = 0; s < original.Sum.Count(); s++)
                {
                    copy.Sum[s] = original.Sum[s];

                }
                return copy;
            }
            else
            {
                Compound copy = new Compound()
                {
                    Abundance = original.Abundance,
                    Mass = original.Mass
                };
                copy.Sum = Enumerable.Repeat(0, original.Sum.Count()).ToArray();
                for (int s = 0; s < original.Sum.Count(); s++)
                {
                    copy.Sum[s] = original.Sum[s];

                }
                return copy;
            }

        }
        public static Combination_1 Calc_max_abundance(ref Combination_1 combination, ref CombinationMulti A, double threshold, Int16 rtm)
        {
            Compound monoisotopic = new Compound();
            Compound current = new Compound();
            Compound current_highest = new Compound();
            CombinationMulti C = new CombinationMulti();
            A.Amount = 0;
            A.Max_abundance = 1.0;
            C.Amount = 0;
            C.Max_abundance = 1.0;
            Int16 iso_nr_max = 0;
            int c = 0;

            monoisotopic = Calc_monoisotopic_single(combination.Element);
            current = CompCopy(monoisotopic);
            //athough it is already initialized
            combination.Element.All_iso_calc_amount = 0;
            double max_a = monoisotopic.Abundance;
            double comb_max_a = max_a;


            combination.Tracking = 0;
            combination.Compounds.Add(new Compound { Mass = monoisotopic.Mass, Abundance = monoisotopic.Abundance, Sum = monoisotopic.Sum });
            combination.A2_amount = 0;
            combination.Element.All_iso_calc_amount++;
            c++;

            while (current.Abundance != -1.0)
            {
                current_highest = CompCopy(current);

                C.Amount = 0;
                iso_nr_max = 0;
                for (Int16 i = current.Indicator_iso; i < combination.Element.Isotopes_single.Count; i++)
                {
                    //In case : number of different elements for an isotope > amount of the element in the chemical formula
                    //there is no need to search for combinations where the most abundant isotope is not present
                    if (current.Counter < combination.Element.Number)
                    {
                        if (C.Compounds.Count > C.Amount)
                        {
                            C.Compounds[C.Amount] = CompCopy(current);
                        }
                        else
                        {
                            C.Compounds.Add(CompCopy(current));
                        }

                        Compound comp = C.Compounds[C.Amount];
                        Int16 iso_e_nr = combination.Element.Isotopes_single[i].iso_e_nr;
                        comp.Counter++;
                        comp.Indicator_iso = i;
                        comp.Sum[iso_e_nr]++;
                        comp.Mass -= combination.Element.Isotopes[0].mass;
                        comp.Mass += combination.Element.Isotopes[iso_e_nr].mass;
                        comp.Abundance *= combination.Element.Isotopes[iso_e_nr].abundance;
                        comp.Abundance *= comp.Sum[0];
                        comp.Abundance /= combination.Element.Isotopes[0].abundance * comp.Sum[iso_e_nr];

                        comp.Sum[0]--;

                        if (current_highest.Abundance < comp.Abundance)
                        {
                            current_highest = CompCopy(comp);
                        }

                        if (comp.Abundance >= current.Abundance)
                        {
                            iso_nr_max = i;
                        }
                        combination.Element.All_iso_calc_amount++;
                        ///dikh m prosthiki >
                        C.Compounds[C.Amount] = comp;

                        C.Amount++;
                    }
                }

                if (comb_max_a < current_highest.Abundance)
                {
                    if (!(rtm == 1 || rtm == 4))
                    {
                        max_a = current_highest.Abundance;
                    }
                    comb_max_a = current_highest.Abundance;
                }

                if (current_highest.Abundance > current.Abundance)
                {
                    for (int v = C.Amount - 1; v >= 0; v--)
                    {
                        if (C.Compounds[v].Abundance != current_highest.Abundance)
                        {
                            if (C.Compounds[v].Indicator_iso <= iso_nr_max)
                            {
                                A.Compounds.Add(CompCopy(C.Compounds[v]));
                                A.Amount++;
                                //C.Compounds[v].Abundance = 1000;

                                //////////////prosthiki elegxou gia to A.amount??
                            }
                            else
                            {
                                if ((100 / max_a) * C.Compounds[v].Abundance >= threshold)
                                {
                                    combination.A2_list.Add(CompCopy(C.Compounds[v]));
                                    combination.A2_amount++;
                                    //C.Compounds[v].Abundance = 1000;
                                    /////////elegxos gia a2_amount??????
                                }
                            }
                        }
                    }
                    current = CompCopy(current_highest);
                    if ((100 / max_a) * current_highest.Abundance >= threshold)
                    {
                        combination.Compounds.Add(CompCopy(current_highest, 2));
                        c++;
                    }
                }
                else
                {
                    for (int v = 0; v < C.Amount; v++)
                    {
                        if ((100 / max_a) * C.Compounds[v].Abundance >= threshold)
                        {
                            combination.A2_list.Add(CompCopy(C.Compounds[v], 2));
                            combination.A2_amount++;
                            /////////elegxos gia a2_amount?????
                        }
                    }
                    if (A.Amount > 0)
                    {
                        Compound a_c = A.Compounds[A.Amount - 1];
                        current = CompCopy(a_c);
                        if ((100 / max_a) * a_c.Abundance >= threshold)
                        {
                            combination.Compounds.Add(CompCopy(a_c, 2));
                            c++;
                        }
                        A.Amount--;
                    }
                    else if (A.Amount == 0)
                    {
                        break;
                        ////continue;
                    }
                    else
                    {
                        current.Abundance = -1.0;
                    }
                }
            }
            combination.Max_abundance = comb_max_a;
            combination.Amount = c;
            return combination;
        }

        public static void Combine_combinations_algo1(ChemiForm chem, double threshold, int iso_total_amount, ref Int64 peak_amount, Int64 peak_limit, Int16 rtm, double max_abundance)
        {
            List<PointPlot> Data = new List<PointPlot>();
            double emass = 0.00054858;
            int v = 0;
            double mass = 0.0;
            double abundance = 1.0;
            if (chem.Combinations.Count < 1)
            {
                chem.Error = true;
                //error message
                return;
            }

            chem.Combinations[0].Tracking = 0;

            while (chem.Combinations[0].Tracking < chem.Combinations[0].CombGroup.Count)
            {
                mass = 0.0;
                abundance = 1.0;
                List<int> cc_tmp = new List<int>();

                foreach (Combination_1 comb in chem.Combinations)
                {
                    int e_a = comb.Element.Iso_amount;
                    //v: counts the peak number

                    //the last element
                    if (comb == chem.Combinations[chem.Combinations.Count - 1])
                    {
                        double tmp_mass = 0.0;
                        double tmp_abundance = 1.0;
                        for (int h = 0; h < comb.CombGroup.Count; h++)
                        {
                            tmp_mass = mass;
                            tmp_abundance = abundance;
                            tmp_mass += comb.CombGroup[comb.Tracking].Mass;
                            tmp_abundance *= comb.CombGroup[comb.Tracking].Abundance;
                            if ((100 / max_abundance) * tmp_abundance >= threshold)
                            {
                                //m=tmp_mass;
                                if (rtm == 3 || rtm == 4)
                                {
                                    //a=tmp_abundance;
                                    if (chem.Charge == 0)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass, Y = tmp_abundance });

                                    }
                                    else if (chem.Charge == 1)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass - emass, Y = tmp_abundance });
                                    }
                                    else
                                    {
                                        Data.Add(new PointPlot { X = ((tmp_mass - chem.Charge * emass) / Math.Abs(chem.Charge)), Y = tmp_abundance });
                                    }

                                }
                                else
                                {
                                    //a=(100/max_abundance)*tmp_abundance;
                                    if (chem.Charge == 0)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass, Y = (100 / max_abundance) * tmp_abundance });
                                    }
                                    else if (chem.Charge == 1)
                                    {
                                        Data.Add(new PointPlot { X = tmp_mass - emass, Y = (100 / max_abundance) * tmp_abundance });
                                    }
                                    else
                                    {
                                        Data.Add(new PointPlot { X = (tmp_mass - chem.Charge * emass) / Math.Abs(chem.Charge), Y = (100 / max_abundance) * tmp_abundance });
                                    }

                                }
                                for (int s = 0; s < comb.CombGroup[comb.Tracking].Sum.Length; s++)
                                {
                                    cc_tmp.Add(comb.CombGroup[comb.Tracking].Sum[s]);
                                }
                                //
                                //

                                v++;
                                if (v >= peak_limit)
                                {
                                    //exceeded amount of peaks 
                                    peak_amount = v;
                                    return;
                                    //return
                                }
                                comb.Tracking++;
                            }
                            else
                            {
                                comb.Tracking++;
                                break;
                            }
                        }

                    }
                    else
                    {
                        if (comb.Tracking < comb.CombGroup.Count)
                        {
                            mass += comb.CombGroup[comb.Tracking].Mass;
                            abundance *= comb.CombGroup[comb.Tracking].Abundance;

                            for (int s = 0; s < comb.CombGroup[comb.Tracking].Sum.Length; s++)
                            {
                                cc_tmp.Add(comb.CombGroup[comb.Tracking].Sum[s]);
                            }

                            if (cc_tmp.Count > iso_total_amount)
                            {
                                peak_amount = v;
                                return;
                                //return
                                //error
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                for (int k = chem.Combinations.Count - 2; k >= 0; k--)
                {
                    if (chem.Combinations[k].Tracking < chem.Combinations[k].CombGroup.Count)
                    {
                        chem.Combinations[k].Tracking++;
                        for (int l = k + 1; l < chem.Combinations.Count; l++)
                        {
                            chem.Combinations[l].Tracking = 0;
                        }
                        break;
                    }
                }

            }
            peak_amount = v;
            //var Pattern_Points = Data.OrderBy(p => p.X).ThenBy(p => p);
            //There aren't duplicate points as the combinations of each element are checked for duplicate inputs
            List<PointPlot> DataSort = Data.OrderBy(p => p.X).ToList();
            chem.Points = RemoveDuplicatesPoint(DataSort);
            if (chem.Points.Count > 0)
            {
                return;
            }
            else
            {
                // error
                return;
            }

        }

        #endregion

        #region Create the final formula pass values to class parameters
        public static void CheckChem(ChemiForm chem)
        {
            string f ="";
            for (int g=0;g<chem.InputFormula.Length ;g++)
            {
                if (Char.IsWhiteSpace(chem.InputFormula,g) && Char.IsNumber(chem.InputFormula,g+1))
                {
                    f +="[";                    
                    do
                    {
                        g++;
                        f += chem.InputFormula[g];
                    } while ((g+1 < chem.InputFormula.Length) && (Char.IsNumber(chem.InputFormula[g+1])));
                    f += "]";
                }
                else if (g==0 && Char.IsNumber(chem.InputFormula, g))
                {
                    f += "[";
                    f += chem.InputFormula[g];
                    do
                    {
                        g++;
                        f += chem.InputFormula[g];
                    } while ((g + 1 < chem.InputFormula.Length) && (Char.IsNumber(chem.InputFormula[g + 1])));
                    f += "]";
                }
                else
                {
                    f+= chem.InputFormula[g];
                }
            }
            chem.InputFormula = f.Replace(" ", "");
            string[] elem = new string[ChemForm.isoTable.Length];
            Regex rgx = new Regex("[A-Z]");
            chem.FinalFormula = "";
            if (chem.Error == false && String.IsNullOrEmpty(chem.Adduct) == false)
            {
                //multiply each number with the multiplier
                if (String.IsNullOrEmpty(chem.Multiplier.ToString()) == false && chem.Multiplier != 0)
                {
                    chem.InputFormula = Multif(chem.InputFormula, chem.Multiplier);
                }
                chem.InputFormula = chem.InputFormula + chem.Adduct;

            }

            for (int k = 0; k < ChemForm.isoTable.Length; k++)
            {
                elem[k] = ChemForm.isoTable[k].element;
            }

            //group isoTable list according to each element and sort each element isotope in descending abundance order
            var elementGroup = ChemForm.isoTable.GroupBy(el => el.element, el => el)
                .Select(grp => new {
                    grp.Key,
                    sorted_Ab = grp.OrderByDescending(x => x.abundance).TakeWhile(x => x.abundance > 0)
                }).ToList();
            //keep from isoTable for each element isotope only the most abundant one
            var elementGroupMax = ChemForm.isoTable.GroupBy(el => el.element, el => el)
                   .Select(grp => new
                   {
                       grp.Key,
                       maxAb = grp.OrderByDescending(x => x.abundance).FirstOrDefault()
                   }).ToList();


            List<string> Element = new List<string>();
            List<int> Number = new List<int>();
            List<string> Element1 = new List<string>();
            List<int> Number1 = new List<int>();

            chem.Monoisotopic.Abundance = 1.0;
            chem.Monoisotopic.Mass = 0.0;
            chem.Iso_total_amount = 0;

            if (chem.InputFormula != null)
            {
                chem.Error = false;
                //all characters possible?
                if (chem.InputFormula.IndexOfAny("*{}&#$@!`-_,.+^".ToCharArray()) != -1)
                {
                    chem.Error = true;
                }


                //do all bracket types close and [] only contain numbers?
                if (chem.Error == false && chem.InputFormula.IndexOfAny("()[]".ToCharArray()) != -1)
                {
                    int getit1 = 0;
                    int getit2 = 0;
                    foreach (char c in chem.InputFormula)
                    {
                        if (c == '[') { getit1++; }
                        if (c == ']') { getit1--; }
                        if (c == '(') { getit2++; }
                        if (c == ')') { getit2--; }
                        if (getit1 > 0 && (Char.IsNumber(c) == false && c != '[' && c != ']')) { chem.Error = true; }
                        if (getit1 < 0 || getit2 < 0) { chem.Error = true; }
                    }
                    if (getit1 != 0 || getit2 != 0)
                    {
                        chem.Error = true;
                    }
                }

                //start correct?
                if (chem.Error == false && char.IsUpper(chem.InputFormula[0]) != true && chem.InputFormula[0] != '(' && chem.InputFormula[0] != '[')
                {
                    chem.Error = true;
                }
                if (chem.InputFormula.Length == 1)
                {
                    chem.InputFormula = chem.InputFormula + "1";
                }

                //empty brackets?
                if (chem.Error == false)
                {
                    for (int a = 1; a < chem.InputFormula.Length; a++)
                    {
                        if (chem.InputFormula[a - 1] == '(' && chem.InputFormula[a] == ')')
                        {
                            chem.Error = true;
                        }
                    }
                }

                //insert 1 where missing
                if (chem.Error == false)
                {
                    if (chem.InputFormula.Any(item => item == '('))
                    {
                        for (int a = 0; a < chem.InputFormula.Length - 1; a++)
                        {
                            if (chem.InputFormula[a] == ')' && Char.IsNumber(chem.InputFormula[a + 1]) == false)
                            {
                                var aStringBuilder = new StringBuilder(chem.InputFormula);
                                aStringBuilder.Insert(a + 1, "1");
                                chem.InputFormula = aStringBuilder.ToString();
                            }
                        }
                        if (chem.InputFormula[chem.InputFormula.Length - 1] == ')')
                        {
                            chem.InputFormula = chem.InputFormula + "1";
                        }
                    }
                    //for all other cases
                    for (int a = 1; a < chem.InputFormula.Length; a++)
                    {
                        if ((char.IsUpper(chem.InputFormula[a]) || chem.InputFormula[a] == ')' || chem.InputFormula[a] == '(')
                            && char.IsNumber(chem.InputFormula[a - 1]) == false && chem.InputFormula[a - 1] != '(' && chem.InputFormula[a - 1] != ']')
                        {
                            var aStringBuilder = new StringBuilder(chem.InputFormula);
                            aStringBuilder.Insert(a, "1");
                            chem.InputFormula = aStringBuilder.ToString();
                            a++;
                        }

                    }
                    if (char.IsNumber(chem.InputFormula[chem.InputFormula.Length - 1]) == false)
                    {
                        chem.InputFormula = chem.InputFormula + "1";
                    }
                }
                //multiply for square brackets, with nesting
                if (chem.Error == false)
                {
                    if (chem.InputFormula.Any(item => item == '('))
                    {
                        int getit1 = 1;
                        int getit2 = 1;
                        List<int> from = new List<int>();
                        int to = -1;
                        List<int> factor = new List<int>();
                        List<string> formula = new List<string>();
                        List<string> final = new List<string>();
                        List<int> length_r = new List<int>();
                        int a = 0;
                        int i = -1;

                        while (a < chem.InputFormula.Length && getit1 != 0 && getit2 != 0)
                        {
                            if (chem.InputFormula[a] == '(')
                            {
                                getit1 = 2;
                                from.Add(a);
                            }
                            if (chem.InputFormula[a] == ')')
                            {
                                getit2 = 2;
                                to = a;
                            }
                            if (getit1 == 2 && getit2 == 2)
                            {
                                i++;
                                int b1 = a + 1;
                                int b2 = a + 1;
                                while (b2 < chem.InputFormula.Length && char.IsNumber(chem.InputFormula[b2]))
                                {
                                    b2++;
                                }
                                length_r.Add(b2 - from[i]);

                                try
                                {
                                    try
                                    {
                                        factor.Add(Int32.Parse(chem.InputFormula.Substring(b1, b2 - b1)));

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                catch (FormatException e)
                                {
                                    MessageBox.Show(e.Message);
                                }
                                //call Multif  
                                formula.Add(chem.InputFormula.Substring(from[i] + 1, to - 1));
                                final.Add(Multif(formula[i], factor[i]));
                                //ston allo kvdika exei getit1=0,getit2=0,alla etsi elegxei gia mia parenthesi mono                                                  
                                getit1 = 1;
                                getit2 = 1;
                            }
                            a++;
                        }

                        var aStringBuilder = new StringBuilder(chem.InputFormula);
                        for (int k = 0; k < formula.Count; k++)
                        {
                            //InputFormula = InputFormula.Replace(formula[i], final[i]);

                            aStringBuilder.Remove(from[i], length_r[i]);
                            aStringBuilder.Insert(from[i], final[i]);
                            chem.InputFormula = aStringBuilder.ToString();
                        }

                    }
                }

                //dissasemble-->chem.InputFormula:chem.Element,chem.Number
                if (chem.Error == false)
                {
                    int i = 0;
                    do
                    {
                        int startIndex = 0;
                        int endIndex = 0;
                        int length = 0;
                        //check for elements with their atomic number in [] an add them to the elements' character list
                        if (chem.InputFormula[i] == '[')
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < chem.InputFormula.Length) && (chem.InputFormula[i] != ']'));

                            do
                            {
                                i++;
                            } while ((i < chem.InputFormula.Length) && (Char.IsNumber(chem.InputFormula[i]) != true));
                            endIndex = i - 1;
                            length = endIndex - startIndex + 1;
                            Element.Add(chem.InputFormula.Substring(startIndex, length));
                        }
                        //Create elements' character list for deduct chemical formula
                        if (Char.IsNumber(chem.InputFormula[i]) != true)
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < chem.InputFormula.Length) && (Char.IsNumber(chem.InputFormula[i]) != true));
                            i = i - 1;
                            endIndex = i;
                            length = endIndex - startIndex + 1;
                            Element.Add(chem.InputFormula.Substring(startIndex, length));

                        }
                        //Create elements' number list for deduct chemical formula
                        if (Char.IsNumber(chem.InputFormula[i]))
                        {
                            startIndex = i;
                            do
                            {
                                i++;
                            } while ((i < chem.InputFormula.Length) && (Char.IsNumber(chem.InputFormula[i]) == true));
                            i = i - 1;
                            endIndex = i;
                            length = endIndex - startIndex + 1;
                            Number.Add(Int32.Parse(chem.InputFormula.Substring(startIndex, length)));

                        }
                        i++;
                    } while (i < chem.InputFormula.Length);

                }


                //check if all elements present in isotopes list
                if (chem.Error == false)
                {
                    if (Element.Except(elem).Any())
                    {
                        chem.Error = true;
                    }
                    if (Element.Count != Number.Count)
                    {
                        chem.Error = true;
                    }
                }

                //merge non-unique elements
                if (chem.Error == false)
                {
                    //elements merged
                    //dictionary contains each element(Key) and the number of times it is presented in formula(Value)
                    IDictionary<string, int> dictionary = new Dictionary<string, int>();
                    dictionary = Element.Zip(Number, (k, v) => new { Key = k, Value = v })
                   .GroupBy(d => d.Key)
                   .Select(g => new { Key = g.Key, Value = g.Sum(s => s.Value) }).ToDictionary(y => y.Key, y => y.Value);


                    //Deduct calculation 
                    //insert the elements and their numbers in the Element1 and Number1 lists
                    if (chem.Error == false && String.IsNullOrEmpty(chem.Deduct) == false)
                    {
                        int i = 0;
                        do
                        {
                            int startIndex = 0;
                            int endIndex = 0;
                            int length = 0;
                            //check for elements with their atomic number in [] an add them to the elements' character list for deduct chemical formula
                            if (chem.Deduct[i] == '[')
                            {
                                startIndex = i;
                                do
                                {
                                    i++;
                                } while ((i < chem.Deduct.Length) && (chem.Deduct[i] != ']'));

                                do
                                {
                                    i++;
                                } while ((i < chem.Deduct.Length) && (Char.IsNumber(chem.Deduct[i]) != true));
                                endIndex = i - 1;
                                length = endIndex - startIndex + 1;
                                Element1.Add(chem.Deduct.Substring(startIndex, length));
                            }
                            //Create elements' character list for deduct chemical formula
                            if (Char.IsNumber(chem.Deduct[i]) != true)
                            {
                                startIndex = i;
                                do
                                {
                                    i++;
                                } while ((i < chem.Deduct.Length) && (Char.IsNumber(chem.Deduct[i]) != true));
                                i = i - 1;
                                endIndex = i;
                                length = endIndex - startIndex + 1;
                                Element1.Add(chem.Deduct.Substring(startIndex, length));
                            }
                            //Create elements' number list for deduct chemical formula
                            if (Char.IsNumber(chem.Deduct[i]))
                            {
                                startIndex = i;
                                do
                                {
                                    i++;
                                } while ((i < chem.Deduct.Length) && (Char.IsNumber(chem.Deduct[i]) == true));
                                i = i - 1;
                                endIndex = i;
                                length = endIndex - startIndex + 1;
                                Number1.Add(Int32.Parse(chem.Deduct.Substring(startIndex, length)));
                            }
                            i++;
                        } while (i < chem.Deduct.Length);
                        //check if the elements in the deduct formula are present in the initial chemical formula
                        if (Element1.Except(Element).Any())
                        {
                            chem.Error = true;
                        }
                        else
                        {
                            if (Element1.Count != Number1.Count)
                            {
                                chem.Error = true;
                            }
                            else
                            {
                                //if there isn't any error substract the deduct from the chemical formula
                                IDictionary<string, int> deduct = new Dictionary<string, int>();
                                deduct = Element1.Zip(Number1, (k, v) => new { Key = k, Value = v })
                                   .GroupBy(d => d.Key)
                                   .Select(g => new { Key = g.Key, Value = g.Sum(s => s.Value) }).ToDictionary(y => y.Key, y => y.Value);
                                foreach (string d in deduct.Keys)
                                {
                                    dictionary[d] -= deduct[d];
                                }
                            }
                        }
                    }

                    //check if each element's amount in the deduct is larger than the corresponding element in the chemical formula
                    if (dictionary.Any(item => item.Value < 0))
                    {
                        chem.Error = true;
                    }

                    //check if each element's amount in the deduct is larger than the corresponding element in the chemical formula
                    //in this case the element is "deleted" from the chemical formula
                    if (dictionary.Any(item => item.Value == 0))
                    {
                        dictionary = dictionary.Where(kvp => kvp.Value >= 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    }

                    if (chem.Error == false)
                    {
                        //create the final chemical formula that will be used for the calculations
                        foreach (var p in dictionary)
                        {
                            chem.FinalFormula = (chem.FinalFormula + p.Key + p.Value).ToString();
                        }

                        //sorted_Ab connected to each of the elements found in the formula
                        var Info_el = from d in dictionary
                                      orderby d.Key
                                      join l in elementGroup on d.Key equals l.Key
                                      select new
                                      {
                                          Elements = d.Key,
                                          Clues = l.sorted_Ab,
                                          Number = d.Value
                                      };

                        //elements sorted in INCREASING order of the number of isotopes they have
                        var Info_iso_amount_sorted = Info_el.OrderBy(x => x.Clues.Count());
                        //maxAb connected to each of the elements found in the formula
                        var Info_elMax = from d in dictionary
                                         orderby d.Key
                                         join l in elementGroupMax on d.Key equals l.Key
                                         select new
                                         {
                                             Elements = d.Key,
                                             abundance = l.maxAb.abundance,
                                             mass = l.maxAb.mass,
                                             Number = d.Value
                                         };


                        //monoisotopic mass calculation for each chemical formula's elements
                        foreach (var el in Info_elMax)
                        {
                            //create a loop for the calculations between the double type parameters
                            for (int i = 0; i < el.Number; i++)
                            {
                                chem.Monoisotopic.Mass += el.mass;
                                chem.Monoisotopic.Abundance *= el.abundance;
                            }
                        }

                        chem.Monoisotopic.Indicator_iso = 0;

                        //pass the grouped values of Info_el in accessible variables
                        int b = 0;
                        foreach (var l in Info_iso_amount_sorted)
                        {
                            Int16 i = 0;

                            chem.Elements_set.Add(new Element_set
                            {
                                Name = l.Elements,
                                Number = l.Number,
                                Iso_amount = l.Clues.Count(),
                                All_iso_calc_amount = 0,
                                Isotopes = new List<ChemForm.Isotopes2>(),
                                Isotopes_single = new List<ChemForm.Isotopes2>()
                            }
                            );
                            for (int a = 0; a < l.Clues.Count(); a++)
                            {
                                chem.Elements_set[b].Isotopes.Add(new ChemForm.Isotopes2
                                {
                                    isotope = l.Clues.ElementAt(a).isotope,
                                    abundance = l.Clues.ElementAt(a).abundance,
                                    mass = l.Clues.ElementAt(a).mass,
                                    element_nr = i,
                                    iso_e_nr = i,
                                    element = l.Elements,
                                    number = l.Number
                                }
                                );
                                i++;
                            }
                            chem.Iso_total_amount += l.Clues.Count();
                            b++;
                        }
                        //Isotopes_single contains only the isotopes of the elements that have more than one isotope, except the most abundant isotopes ones

                        foreach (Element_set el in chem.Elements_set)
                        {
                            if (el.Iso_amount > 1)
                            {
                                for (Int16 i = 1; i < el.Isotopes.Count; i++)
                                {
                                    el.Isotopes_single.Add(new ChemForm.Isotopes2 { isotope = el.Isotopes[i].isotope, abundance = el.Isotopes[i].abundance, mass = el.Isotopes[i].mass, element_nr = i, iso_e_nr = i, element = el.Name, number = el.Number });
                                }
                            }
                            //isotopes(except the most abundant ones) of each element ordered in DESCENDING order
                            el.Isotopes_single = el.Isotopes_single.OrderByDescending(x => x.number * x.abundance).ToList();
                        }
                    }

                }
            }
            else
            {
                //error message on each formula
                chem.Error = true;
            }

        }

        public static string Multif(string initial_formula, int factor)
        {
            initial_formula = initial_formula.Replace("D", "[2]H");
            List<string> element1 = new List<string>();
            List<int> number1 = new List<int>();
            int i = 0;
            string final_formula = "";
            int counter = 0;
            do

            { //check for elements with their atomic number in []
                int startIndex = 0;
                int endIndex = 0;
                int length = 0;
                if (initial_formula[i] == '[')
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (initial_formula[i] != ']'));

                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) != true));
                    endIndex = i - 1;
                    length = endIndex - startIndex + 1;
                    element1.Add(initial_formula.Substring(startIndex, length));
                }


                if (Char.IsNumber(initial_formula[i]) != true)
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) != true));
                    i = i - 1;
                    endIndex = i;
                    length = endIndex - startIndex + 1;
                    element1.Add(initial_formula.Substring(startIndex, length));
                }

                if (Char.IsNumber(initial_formula[i]))
                {
                    startIndex = i;
                    do
                    {
                        i++;
                    } while ((i < initial_formula.Length) && (Char.IsNumber(initial_formula[i]) == true));
                    i = i - 1;
                    endIndex = i;
                    length = endIndex - startIndex + 1;
                    number1.Add(Int32.Parse(initial_formula.Substring(startIndex, length)));
                }
                i++;
            } while (i < initial_formula.Length);
            //end while loop

            if (!number1.Any() || !element1.Any())
            {
                MessageBox.Show("Please enter the formula as so:element1 number1 element2 number2 etc ");
                return initial_formula;
            }
            else
            {
                //multiply each number with the multiplier
                for (int index = 0; index < number1.Count; index++)
                {
                    number1[index] = number1[index] * factor;
                }
                //Rewrite the formula

                foreach (string p in element1)
                {
                    final_formula = final_formula + p + number1[counter];
                    counter++;
                }

                return final_formula;
            }


        }

        #endregion

        
    }

}

