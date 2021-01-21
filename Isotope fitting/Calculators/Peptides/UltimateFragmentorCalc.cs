﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Isotope_fitting.Form2;
using static Isotope_fitting.Helpers;
using static Isotope_fitting._2.Calculators._2.a.Peptides.ModEditForm;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Isotope_fitting._2.Calculators._2.a.Peptides
{
    public partial class UltimateFragmentorCalc : Form
    {
        Form2 frm2;
        public UltimateFragmentorCalc(Form2 f)
        {
            frm2 = f;
            InitializeComponent();

            //seqLabel.Text = frm2.sequenceList[0].Sequence;
            seqTxt.Text = frm2.sequenceList[0].Sequence;

            List<CheckBox> ionBoxes = new List<CheckBox>
            {
                aChkBox,
                bChkBox,
                cChkBox,
                xChkBox,
                yChkBox,
                zChkBox
            };
        }

        private void UltimateFragmentorCalc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                this.Parent = null;
                e.Cancel = true;
            }
        }

        #region UI Events

        private void addModBtn_Click(object sender, EventArgs e)
        {
            ModEditForm meAddForm = new ModEditForm();

            meAddForm.ShowDialog();

            if (meAddForm.inputVals[0] != null)
            {
                ListViewItem newItem = new ListViewItem(meAddForm.inputVals[0]);
                newItem.SubItems.Add(meAddForm.inputVals[1]);
                newItem.SubItems.Add(meAddForm.inputVals[2]);
                newItem.SubItems.Add(meAddForm.inputVals[3]);
                newItem.SubItems.Add(meAddForm.inputVals[4]);
                newItem.SubItems.Add(meAddForm.inputVals[5]);
                newItem.SubItems.Add(meAddForm.inputVals[6]);

                allMods.Items.Add(newItem);
                modsList.Items.Add(meAddForm.inputVals[meAddForm.inputVals.Count-1]);
            }
        }

        private void editModBtn_Click(object sender, EventArgs e)
        {
            ModEditForm meEditForm = new ModEditForm();

            meEditForm.ShowDialog();
        }

        private void delModBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in allMods.SelectedItems)
            {
                allMods.Items.Remove(eachItem);
            }
        }

        #endregion

        #region JSON I/O

        private void loadModsJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog modsJSONDialog = new OpenFileDialog() { InitialDirectory = Application.StartupPath + "\\Data",
                Filter = "data file|*.json;|All files|*.*",
                FilterIndex = 1, RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true };

            Dictionary<string, Mod> modDict = new Dictionary<string, Mod>();
            
            System.Diagnostics.Debug.Write(modsJSONDialog.FileName);

            if (modsJSONDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    if (modsJSONDialog.FileName.EndsWith(".json")){

                        modDict = parseModJSON(modsJSONDialog.FileName);

                        foreach(var kv in modDict)
                        {
                            ListViewItem item = new ListViewItem(kv.Key);
                            item.SubItems.Add(kv.Value.formula_gain);
                            item.SubItems.Add(kv.Value.formula_loss);
                            item.SubItems.Add(kv.Value.affects_residues);
                            item.SubItems.Add(kv.Value.affects_ions);
                            item.SubItems.Add(kv.Value.affect_position);
                            item.SubItems.Add(kv.Value.description);

                            allMods.Items.Add(item);

                            modsList.Items.Add(kv.Value.description);
                                                       
                        }
                       
                    }

                    allMods.Sorting = SortOrder.Ascending;
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.Write("The following occured: " + ex.Message);
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Dictionary<string, Mod> parseModJSON(string filename)
        {
            Dictionary<string, Mod> modDict = new Dictionary<string, Mod>();
            JObject whole = new JObject();
            JArray modArray = new JArray();

            string json = File.ReadAllText(filename);
            whole = JObject.Parse(json);

            foreach (var name in whole)
            {
                modArray = JArray.Parse(name.Value.ToString());

                IList<Mod> mods = modArray.Select(p => new Mod
                {
                    formula_gain = (string)p["formula_gain"],
                    formula_loss = (string)p["formula_loss"],
                    affects_residues = (string)p["affects_residues"],
                    affects_ions = (string)p["affects_ions"],
                    affect_position = (string)p["affect_position"],
                    description = (string)p["description"],
                }).ToList();

                // System.Diagnostics.Debug.WriteLine(mods[0].description);
                bool found = false;
                foreach (ListViewItem it in allMods.Items)
                {
                    System.Diagnostics.Debug.Write("Item: " + name.Key + "\n");
                    System.Diagnostics.Debug.Write("Item already:  " + it.SubItems[0].Text + "\n");
                    if (it.SubItems[0].Text == name.Key)
                    {
                        found = true;
                        System.Diagnostics.Debug.Write("Item " + name.Key + " already exists in list!");
                        break;
                    }

                }

                if (!found)
                {
                    modDict.Add(name.Key, mods[0]);
                }

            }

            return modDict;
        }

        private void loadElemBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog elemJSONDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath + "\\Data",
                Filter = "data file|*.json;|All files|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (elemJSONDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    if (elemJSONDialog.FileName.EndsWith("elements.json"))
                    {
                        JObject elemFile = new JObject();

                        string json = File.ReadAllText(elemJSONDialog.FileName);
                        elemFile = JObject.Parse(json);

                        foreach (var obj in elemFile)
                        {
                            ListViewItem item = new ListViewItem(obj.Key);
                            item.SubItems.Add((string)obj.Value);
                            System.Diagnostics.Debug.Write(obj.Key + " " + (string)obj.Value + "\n");

                            elemList.Items.Add(item);
                        }
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("An error occured: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadScJSON_Click(object sender, EventArgs e)
        {
            Dictionary<string, SideChain> chainDict = new Dictionary<string, SideChain>();
            OpenFileDialog scJSONDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath + "\\Data",
                Filter = "data file|*.json;|All files|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (scJSONDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    if (scJSONDialog.FileName.EndsWith("side_chains.json"))
                    {
                        chainDict = parseScJSON(scJSONDialog.FileName);

                        foreach (var kv in chainDict)
                        {
                            ListViewItem item = new ListViewItem(kv.Value.name);
                            item.SubItems.Add(kv.Value.single_letter);
                            item.SubItems.Add(kv.Value.three_letter);
                            item.SubItems.Add(kv.Value.elemental);
                            item.SubItems.Add(kv.Value.mass_mono);
                            item.SubItems.Add(kv.Value.mass_avg);
                            item.SubItems.Add(kv.Value.scDet.full);
                            item.SubItems.Add(kv.Value.scDet.beta);
                            item.SubItems.Add(kv.Value.scDet.gamma);
                            item.SubItems.Add(kv.Value.scDet.delta);
                            item.SubItems.Add(kv.Value.scDet.epsilon);

                            scList.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong JSON file. Please load the side_chains.json file from the Ultimate Fragmentor params folder.",
                            "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("The following error occured: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Dictionary<string, SideChain> parseScJSON(string filename)
        {
            Dictionary<string, SideChain> chain = new Dictionary<string, SideChain>();
            JObject whole = new JObject();
            JObject sc = new JObject();

            JArray scdet = new JArray();

            string json = File.ReadAllText(filename);
            whole = JObject.Parse(json);

            foreach(KeyValuePair<string, JToken> name in whole)
            {
                sc = JObject.Parse(name.Value.ToString());
                SideChain c = new SideChain
                {
                    name = (string)sc["name"],
                    single_letter = (string)sc["single_letter"],
                    three_letter = (string)sc["three_letter"],
                    elemental = (string)sc["elemental"],
                    mass_mono = (string)sc["mass_mono"],
                    mass_avg = (string)sc["mass_avg"],
                    side_chains = (JArray)sc["side_chains"],

                    scDet = new SCDet
                    {
                        full = String.Empty,
                        beta = String.Empty,
                        gamma = String.Empty,
                        epsilon = String.Empty,
                        delta = String.Empty
                    }

                };

                scdet = c.side_chains;

                if (scdet == null)
                {
                    c.scDet.full = String.Empty;
                    c.scDet.beta = String.Empty;
                    c.scDet.gamma = String.Empty;
                    c.scDet.epsilon = String.Empty;
                    c.scDet.delta = String.Empty;
                }
                else
                {
                    IList<SCDet> scDetails = c.side_chains.Select(p => new SCDet
                    {
                        full = (string)p["full"],
                        beta = (string)p["beta"],
                        gamma = (string)p["gamma"],
                        delta = (string)p["delta"],
                        epsilon = (string)p["epsilon"]
                    }).ToList();

                    int count = scDetails.Count;

                    c.scDet.full = scDetails[0].full;

                    if (count > 1) { c.scDet.beta = scDetails[1].beta; }
                    if (count > 2) { c.scDet.gamma = scDetails[2].gamma; }
                    if (count > 3) { c.scDet.delta = scDetails[3].delta; }
                    if (count > 4) { c.scDet.epsilon = scDetails[4].epsilon; }

                    // System.Diagnostics.Debug.WriteLine(scDetails.Count);
                }

                System.Diagnostics.Debug.WriteLine(c.name + ' ' + c.scDet.full + ' ' + c.scDet.beta + ' ' + c.scDet.gamma);
                chain.Add(name.Key, c);
            }

            return chain;
        }
        #endregion

        #region Modifications Base Class

        public class Mod
        {
            public string formula_gain { get; set; }
            public string formula_loss { get; set; }
            public string affects_residues { get; set; }
            public string affects_ions { get; set; }
            public string affect_position { get; set; }
            public string description { get; set; }

        }

        #endregion

        #region Elements Base Class

        public class Element
        {
            public double mass { get; set; }
        }
        #endregion

        #region Side Chains Base Classes
        public class SideChain
        {
            public string name { get; set; }
            public string single_letter { get; set; }
            public string three_letter { get; set; }
            public string elemental { get; set; }
            public string mass_mono { get; set; }
            public string mass_avg { get; set; }
            public JArray side_chains { get; set; }
            public SCDet scDet { get; set; }
        }

        public class SCDet
        {
            public string full { get; set; }
            public string beta { get; set; }
            public string gamma { get; set; }
            public string delta { get; set; }
            public string epsilon { get; set; }
        }
        #endregion

    }



}
