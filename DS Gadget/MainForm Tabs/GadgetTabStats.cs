using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabStats : GadgetTab
    {
        public GadgetTabStats()
        {
            InitializeComponent();
        }

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            MakeDicts();
            foreach (DSSex sex in DSSex.All)
                cmbSex.Items.Add(sex);
            foreach (DSClass charClass in DSClass.All)
                cmbClass.Items.Add(charClass);
            foreach (DSPhysique physique in DSPhysique.All)
                cmbPhysique.Items.Add(physique);
            nudHumanity.Maximum = int.MaxValue;
            nudHumanity.Minimum = int.MinValue;

            foreach (DSCovenant covenant in DSCovenant.All)
                cmbCovenant.Items.Add(covenant);
            ResetPage();
        }

        
        /// <summary>
        /// One init function to make all of the dictionaries
        /// </summary>
        private void MakeDicts()
        {
            //StatsDict entries
            StatsDict.Add(nudHumanity.Name, val => { SavedStats.Humanity = (decimal)val; });
            StatsDict.Add(nudSouls.Name, val => { SavedStats.Souls = (decimal)val; });
            StatsDict.Add(nudVit.Name, val => { SavedStats.Vit = (decimal)val; });
            StatsDict.Add(nudAtt.Name, val => { SavedStats.Att = (decimal)val; });
            StatsDict.Add(nudEnd.Name, val => { SavedStats.End = (decimal)val; });
            StatsDict.Add(nudStr.Name, val => { SavedStats.Str = (decimal)val; });
            StatsDict.Add(nudDex.Name, val => { SavedStats.Dex = (decimal)val; });
            StatsDict.Add(nudRes.Name, val => { SavedStats.Res = (decimal)val; });
            StatsDict.Add(nudInt.Name, val => { SavedStats.Int = (decimal)val; });
            StatsDict.Add(nudFth.Name, val => { SavedStats.Fth = (decimal)val; });
            StatsDict.Add(nudCovChaos.Name, val => { SavedStats.CovChaos = (decimal)val; });
            StatsDict.Add(nudCovDarkmoon.Name, val => { SavedStats.CovDarkmoon = (decimal)val; });
            StatsDict.Add(nudCovDarkwraith.Name, val => { SavedStats.CovDarkwraith = (decimal)val; });
            StatsDict.Add(nudCovForest.Name, val => { SavedStats.CovForest = (decimal)val; });
            StatsDict.Add(nudCovGravelord.Name, val => { SavedStats.CovGravelord = (decimal)val; });
            StatsDict.Add(nudCovDragon.Name, val => { SavedStats.CovDragon = (decimal)val; });
            StatsDict.Add(nudCovSunlight.Name, val => { SavedStats.CovSunlight = (decimal)val; });

            //NudDict entries
            NudDict.Add(nudHumanity.Name, val => { Hook.Humanity = val; });
            NudDict.Add(nudSouls.Name, val => { Hook.Souls = val; });
            NudDict.Add(nudCovChaos.Name, val => { Hook.ChaosServantPoints = (byte)val; });
            NudDict.Add(nudCovDarkmoon.Name, val => { Hook.DarkmoonBladePoints = (byte)val; });
            NudDict.Add(nudCovDarkwraith.Name, val => { Hook.DarkwraithPoints = (byte)val; });
            NudDict.Add(nudCovForest.Name, val => { Hook.ForestHunterPoints = (byte)val; });
            NudDict.Add(nudCovGravelord.Name, val => { Hook.GravelordServantPoints = (byte)val; });
            NudDict.Add(nudCovDragon.Name, val => { Hook.PathOfTheDragonPoints = (byte)val; });
            NudDict.Add(nudCovSunlight.Name, val => { Hook.WarriorOfSunlightPoints = (byte)val; });
        }

        internal void LoadSavedStatsIf(SavedStats savedStats)
        {
            SavedStats = savedStats;
            LoadSavedStats();
        }

        public override void ReloadTab()
        {
            txtName.Text = Hook.CharName;
            cmbSex.SelectedItem = cmbSex.Items.Cast<DSSex>().FirstOrDefault(s => s.ID == Hook.Sex);
            cmbClass.SelectedItem = cmbClass.Items.Cast<DSClass>().FirstOrDefault(c => c.ID == Hook.Class);
            cmbPhysique.SelectedItem = cmbPhysique.Items.Cast<DSPhysique>().FirstOrDefault(p => p.ID == Hook.Physique);
        }

        public override void UpdateTab()
        {
            txtSoulLevel.Text = Hook.SoulLevel.ToString();
            nudHumanity.Value = Hook.Humanity;
            nudSouls.Value = Hook.Souls;
            try
            {
                Updating = true;
                nudVit.Value = Hook.Vitality;
                nudAtt.Value = Hook.Attunement;
                nudEnd.Value = Hook.Endurance;
                nudStr.Value = Hook.Strength;
                nudDex.Value = Hook.Dexterity;
                nudRes.Value = Hook.Resistance;
                nudInt.Value = Hook.Intelligence;
                nudFth.Value = Hook.Faith;
                Updating = false;

            }
            // Race condition when checking if the game is still loaded; doesn't really matter
            catch (ArgumentOutOfRangeException) { }

            if (!cmbCovenant.DroppedDown)
            {
                cmbCovenant.SelectedItem = cmbCovenant.Items.Cast<DSCovenant>()
                    .FirstOrDefault(c => c.ID == Hook.Covenant);
            }
            nudCovChaos.Value = Hook.ChaosServantPoints;
            nudCovDarkmoon.Value = Hook.DarkmoonBladePoints;
            nudCovDarkwraith.Value = Hook.DarkwraithPoints;
            nudCovDragon.Value = Hook.PathOfTheDragonPoints;
            nudCovForest.Value = Hook.ForestHunterPoints;
            nudCovGravelord.Value = Hook.GravelordServantPoints;
            nudCovSunlight.Value = Hook.WarriorOfSunlightPoints;
        }

        private void RecalculateStats()
        {
            int vitality = (int)nudVit.Value;
            int attunement = (int)nudAtt.Value;
            int endurance = (int)nudEnd.Value;
            int strength = (int)nudStr.Value;
            int dexterity = (int)nudDex.Value;
            int resistance = (int)nudRes.Value;
            int intelligence = (int)nudInt.Value;
            int faith = (int)nudFth.Value;
            int sl = CalculateSL(vitality, attunement, endurance, strength, dexterity, resistance, intelligence, faith);

            Hook.LevelUp(vitality, attunement, endurance, strength, dexterity, resistance, intelligence, faith, sl);
        }

        private int CalculateSL(int vitality, int attunement, int endurance, int strength, int dexterity, int resistance, int intelligence, int faith)
        {
            DSClass charClass = cmbClass.SelectedItem as DSClass;
            int sl = charClass.SoulLevel;
            sl += vitality - charClass.Vitality;
            sl += attunement - charClass.Attunement;
            sl += endurance - charClass.Endurance;
            sl += strength - charClass.Strength;
            sl += dexterity - charClass.Dexterity;
            sl += resistance - charClass.Resistance;
            sl += intelligence - charClass.Intelligence;
            sl += faith - charClass.Faith;
            return sl;
        }

        internal void EnabledStats(bool enable)
        {
            if (enable)
            {
                CheckTextChange();

                if (cbxLoad.Checked)
                {
                    if (SavedStats.GetType().GetProperties().Select(pi => pi.GetValue(SavedStats)).Any(value => value != null))
                    {
                        UpdateTab();
                        LoadSavedStats();
                    }
                }
            }
            else
            {
                if (Main != null)
                {
                    ResetPage();
                }
            }
        }

        /// <summary>
        /// Checks if the nuds value is null or not. Loads correct value if it is, and saves correct value if it isn't. Prevents numbers not showing up and not saving
        /// </summary>
        private void CheckTextChange()
        {
            if (nudHumanity.Text == "")
                nudHumanity.Text = Hook.Humanity.ToString();
            else
                SavedStats.Humanity = nudHumanity.Value;

            if (nudSouls.Text == "")
                nudSouls.Text = Hook.Souls.ToString();
            else
                SavedStats.Souls = nudSouls.Value;

            if (nudCovChaos.Text == "")
                nudCovChaos.Text = Hook.ChaosServantPoints.ToString();
            else
                SavedStats.CovChaos = nudCovChaos.Value;

            if (nudCovDarkmoon.Text == "")
                nudCovDarkmoon.Text = Hook.DarkmoonBladePoints.ToString();
            else
                SavedStats.CovDarkmoon = nudCovDarkmoon.Value;

            if (nudCovDarkwraith.Text == "")
                nudCovDarkwraith.Text = Hook.DarkwraithPoints.ToString();
            else
                SavedStats.CovDarkwraith = nudCovDarkwraith.Value;

            if (nudCovForest.Text == "")
                nudCovForest.Text = Hook.ForestHunterPoints.ToString();
            else
                SavedStats.CovForest = nudCovForest.Value;

            if (nudCovGravelord.Text == "")
                nudCovGravelord.Text = Hook.GravelordServantPoints.ToString();
            else
                SavedStats.CovGravelord = nudCovGravelord.Value;

            if (nudCovDragon.Text == "")
                nudCovDragon.Text = Hook.PathOfTheDragonPoints.ToString();
            else
                SavedStats.CovDragon = nudCovDragon.Value;

            if (nudCovSunlight.Text == "")
                nudCovSunlight.Text = Hook.WarriorOfSunlightPoints.ToString();
            else
                SavedStats.CovSunlight = nudCovSunlight.Value;

            if (nudVit.Text != "")
                SavedStats.Vit = nudVit.Value;
            if (nudAtt.Text != "")
                SavedStats.Att = nudAtt.Value;
            if (nudEnd.Text != "")
                SavedStats.End = nudEnd.Value;
            if (nudStr.Text != "")
                SavedStats.Str = nudStr.Value;
            if (nudDex.Text != "")
                SavedStats.Dex = nudDex.Value;
            if (nudRes.Text != "")
                SavedStats.Res = nudRes.Value;
            if (nudInt.Text != "")
                SavedStats.Int = nudInt.Value;
            if (nudFth.Text != "")
                SavedStats.Fth = nudFth.Value;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!Reading)
            {
                if (Hook.Loaded)
                {
                    Hook.CharName = txtName.Text;
                }
                else
                {
                    SavedStats.Name = txtName.Text;
                }
            }

        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSex.SelectedIndex != -1)
            {
                if (!Reading)
                {
                    if (Hook.Loaded)
                    {
                        Hook.Sex = (cmbSex.SelectedItem as DSSex).ID;
                    }
                    else
                    {
                        SavedStats.Sex = cmbSex.SelectedIndex;
                    }
                }
            }
            
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex != -1)
            {
                DSClass charClass = cmbClass.SelectedItem as DSClass;
                if (Hook.Loaded)
                {
                    nudVit.Minimum = charClass.Vitality;
                    nudAtt.Minimum = charClass.Attunement;
                    nudEnd.Minimum = charClass.Endurance;
                    nudStr.Minimum = charClass.Strength;
                    nudDex.Minimum = charClass.Dexterity;
                    nudRes.Minimum = charClass.Resistance;
                    nudInt.Minimum = charClass.Intelligence;
                    nudFth.Minimum = charClass.Faith;
                }

                if (!Reading)
                {
                    if (Hook.Loaded)
                    {
                        Hook.Class = charClass.ID;
                        RecalculateStats();
                    }
                    else
                    {
                        SavedStats.Class = cmbClass.SelectedIndex;
                    }

                }
            }
        }

        private void cmbPhysique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhysique.SelectedIndex != -1)
            {
                if (!Reading)
                {
                    if (Hook.Loaded)
                    {
                        Hook.Physique = (cmbPhysique.SelectedItem as DSPhysique).ID;
                    }
                    else
                    {
                        SavedStats.Physique = cmbPhysique.SelectedIndex;
                    }
                }
            }
            
        }

        private SavedStats SavedStats = new SavedStats();

        public bool Updating { get; private set; }

        private void nudStat_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
            {
                if(Hook.Loaded)
                {
                    if (!Updating)
                    {
                        RecalculateStats();
                    }
                }
                else
                {
                    SaveStats(sender);

                    if (cmbClass.SelectedIndex == -1)
                    {
                        txtSoulLevel.Text = (nudVit.Value + nudAtt.Value + nudEnd.Value + nudStr.Value + nudDex.Value + nudRes.Value + nudInt.Value + nudFth.Value).ToString();
                    }
                    else
                    {
                        txtSoulLevel.Text = CalculateSL((int)nudVit.Value, (int)nudAtt.Value, (int)nudEnd.Value, (int)nudStr.Value, (int)nudDex.Value, (int)nudRes.Value, (int)nudInt.Value, (int)nudFth.Value).ToString();
                    }
                }
            }
        }

        private Dictionary<string, Action<decimal?>> StatsDict = new Dictionary<string, Action<decimal?>>();
        
        /// <summary>
        /// Takes Sender as NumericUpDown and retrieves set Action from StatsDict
        /// </summary>
        /// <param name="sender"></param>
        private void SaveStats(object sender)
        {
            var nud = sender as NumericUpDown;
            StatsDict[nud.Name].Invoke(nud.Value); //Invoke takes nud.Value and sets it via the function in the dictionary using nud.Name
            nud.Text = nud.Value.ToString(); //Update the text incase the value was the same as the previous value
        }

        internal void SaveStatsSwitch(NumericUpDown numericUpDown)
        {
            SaveStatsOld(numericUpDown);
        }


        private void SaveStatsOld(object sender)
        {
            var stat = sender as NumericUpDown;
            switch (stat.Name)
            {
                case "nudHumanity":
                    SavedStats.Humanity = nudHumanity.Value;
                    nudHumanity.Text = nudHumanity.Value.ToString();
                    break;
                case "nudSouls":
                    SavedStats.Souls = nudSouls.Value;
                    nudSouls.Text = nudSouls.Value.ToString();
                    break;
                case "nudVit":
                    SavedStats.Vit = Clamp(nudVit.Value, 1, 99);
                    nudVit.Text = SavedStats.Vit.Value.ToString();
                    break;
                case "nudAtt":
                    SavedStats.Att = Clamp(nudAtt.Value, 1, 99);
                    nudAtt.Text = SavedStats.Att.Value.ToString();
                    break;
                case "nudEnd":
                    SavedStats.End = Clamp(nudEnd.Value, 1, 99);
                    nudEnd.Text = SavedStats.End.Value.ToString();
                    break;
                case "nudStr":
                    SavedStats.Str = Clamp(nudStr.Value, 1, 99);
                    nudStr.Text = SavedStats.Str.Value.ToString();
                    break;
                case "nudDex":
                    SavedStats.Dex = Clamp(nudDex.Value, 1, 99);
                    nudDex.Text = SavedStats.Dex.Value.ToString();
                    break;
                case "nudRes":
                    SavedStats.Res = Clamp(nudRes.Value, 1, 99);
                    nudRes.Text = SavedStats.Res.Value.ToString();
                    break;
                case "nudInt":
                    SavedStats.Int = Clamp(nudInt.Value, 1, 99);
                    nudInt.Text = SavedStats.Int.Value.ToString();
                    break;
                case "nudFth":
                    SavedStats.Fth = Clamp(nudFth.Value, 1, 99);
                    nudFth.Text = SavedStats.Fth.Value.ToString();
                    break;
                case "nudCovChaos":
                    SavedStats.CovChaos = nudCovChaos.Value;
                    nudCovChaos.Text = nudCovChaos.Value.ToString();
                    break;
                case "nudCovDarkmoon":
                    SavedStats.CovDarkmoon = nudCovDarkmoon.Value;
                    nudCovDarkmoon.Text = nudCovDarkmoon.Value.ToString();
                    break;
                case "nudCovDarkwraith":
                    SavedStats.CovDarkwraith = nudCovDarkwraith.Value;
                    nudCovDarkwraith.Text = nudCovDarkwraith.Value.ToString();
                    break;
                case "nudCovForest":
                    SavedStats.CovForest = nudCovForest.Value;
                    nudCovForest.Text = nudCovForest.Value.ToString();
                    break;
                case "nudCovGravelord":
                    SavedStats.CovGravelord = nudCovGravelord.Value;
                    nudCovGravelord.Text = nudCovGravelord.Value.ToString();
                    break;
                case "nudCovDragon":
                    SavedStats.CovDragon = nudCovDragon.Value;
                    nudCovDragon.Text = nudCovDragon.Value.ToString();
                    break;
                case "nudCovSunlight":
                    SavedStats.CovSunlight = nudCovSunlight.Value;
                    nudCovSunlight.Text = nudCovSunlight.Value.ToString();
                    break;
                default:
                    break;
            }
        }

        private void cmbCovenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCovenant.SelectedIndex != -1)
            {
                if (!Reading)
                {
                    if (Hook.Loaded)
                    {
                        Hook.Covenant = ((DSCovenant)cmbCovenant.SelectedItem).ID;
                    }
                    else
                    {
                        SavedStats.Covenant = cmbCovenant.SelectedIndex;
                    }
                }
            }
        }

        private Dictionary<string, Action<int>> NudDict = new Dictionary<string, Action<int>>();

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
            {
                var nud = sender as NumericUpDown;
                if (Hook.Loaded)
                {
                    NudDict[nud.Name].Invoke((int)nud.Value);
                }
                else
                {
                    SaveStats(sender);
                }
            }
        }

        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void LoadSavedStats()
        {
            if (Hook.Loaded)
            {
                if (!string.IsNullOrWhiteSpace(SavedStats.Name))
                {
                    txtName.Text = SavedStats.Name;
                }

                if (SavedStats.Sex.HasValue)
                {
                    cmbSex.SelectedIndex = SavedStats.Sex.Value;
                    cmbSex_SelectedIndexChanged(null, null);
                }

                if (SavedStats.Class.HasValue)
                {
                    cmbClass.SelectedIndex = SavedStats.Class.Value;
                    cmbClass_SelectedIndexChanged(null, null);
                }

                if (SavedStats.Physique.HasValue)
                {
                    cmbPhysique.SelectedIndex = SavedStats.Physique.Value;
                    cmbPhysique_SelectedIndexChanged(null, null);
                }

                if (SavedStats.Humanity.HasValue)
                {
                    nudHumanity.Value = SavedStats.Humanity.Value;
                    nud_ValueChanged(nudHumanity, null);
                }

                if (SavedStats.Souls.HasValue)
                {
                    nudSouls.Value = SavedStats.Souls.Value;
                    nud_ValueChanged(nudSouls, null);
                }

                if (SavedStats.Vit.HasValue)
                {
                    nudVit.Value = Clamp(SavedStats.Vit.Value, nudVit.Minimum, nudVit.Maximum);
                }

                if (SavedStats.Att.HasValue)
                {
                    nudAtt.Value = Clamp(SavedStats.Att.Value, nudAtt.Minimum, nudAtt.Maximum);
                }

                if (SavedStats.End.HasValue)
                {
                    nudEnd.Value = Clamp(SavedStats.End.Value, nudEnd.Minimum, nudEnd.Maximum);
                }

                if (SavedStats.Str.HasValue)
                {
                    nudStr.Value = Clamp(SavedStats.Str.Value, nudStr.Minimum, nudStr.Maximum);
                }

                if (SavedStats.Dex.HasValue)
                {
                    nudDex.Value = Clamp(SavedStats.Dex.Value, nudDex.Minimum, nudDex.Maximum);
                }

                if (SavedStats.Res.HasValue)
                {
                    nudRes.Value = Clamp(SavedStats.Res.Value, nudRes.Minimum, nudRes.Maximum);
                }

                if (SavedStats.Int.HasValue)
                {
                    nudInt.Value = Clamp(SavedStats.Int.Value, nudInt.Minimum, nudInt.Maximum);
                }

                if (SavedStats.Fth.HasValue)
                {
                    nudFth.Value = Clamp(SavedStats.Fth.Value, nudFth.Minimum, nudFth.Maximum);
                }

                RecalculateStats();

                if (SavedStats.Covenant.HasValue)
                {
                    cmbCovenant.SelectedIndex = SavedStats.Covenant.Value;
                    cmbCovenant_SelectedIndexChanged(null, null);
                }

                if (SavedStats.CovChaos.HasValue)
                {
                    nudCovChaos.Value = SavedStats.CovChaos.Value;
                    nud_ValueChanged(nudCovChaos, null);
                }

                if (SavedStats.CovDarkmoon.HasValue)
                {
                    nudCovDarkmoon.Value = SavedStats.CovDarkmoon.Value;
                    nud_ValueChanged(nudCovDarkmoon, null);

                }

                if (SavedStats.CovDarkwraith.HasValue)
                {
                    nudCovDarkwraith.Value = SavedStats.CovDarkwraith.Value;
                    nud_ValueChanged(nudCovDarkwraith, null);

                }

                if (SavedStats.CovForest.HasValue)
                {
                    nudCovForest.Value = SavedStats.CovForest.Value;
                    nud_ValueChanged(nudCovForest, null);
                }

                if (SavedStats.CovGravelord.HasValue)
                {
                    nudCovGravelord.Value = SavedStats.CovGravelord.Value;
                    nud_ValueChanged(nudCovGravelord, null);
                }

                if (SavedStats.CovDragon.HasValue)
                {
                    nudCovDragon.Value = SavedStats.CovDragon.Value;
                    nud_ValueChanged(nudCovDragon, null);
                }

                if (SavedStats.CovSunlight.HasValue)
                {
                    nudCovSunlight.Value = SavedStats.CovSunlight.Value;
                    nud_ValueChanged(nudCovSunlight, null);
                }
            }

        }

        /// <summary>
        /// Resets all values on page to a blank state
        /// </summary>
        private void ResetPage()
        {
            txtName.Text = null;
            SavedStats.Name = null;
            NullCMB(cmbSex);
            NullCMB(cmbClass);
            NullCMB(cmbPhysique);
            NullStat(nudHumanity);
            NullStat(nudSouls);
            NullStat(nudVit);
            NullStat(nudAtt);
            NullStat(nudEnd);
            NullStat(nudStr);
            NullStat(nudDex);
            NullStat(nudRes);
            NullStat(nudInt);
            NullStat(nudFth);
            NullCMB(cmbCovenant);
            NullStat(nudCovChaos);
            NullStat(nudCovDarkmoon);
            NullStat(nudCovDarkwraith);
            NullStat(nudCovForest);
            NullStat(nudCovGravelord);
            NullStat(nudCovDragon);
            NullStat(nudCovSunlight);
        }

        
        private void nudKeyDown(object sender, KeyEventArgs e)
        {
            if (!Hook.Loaded)
            {
                //If Enter Save stats
                if (e.KeyCode == Keys.Enter)
                {
                    SaveStats(sender);
                }

                //If Escape Null stats
                if (e.KeyCode == Keys.Escape)
                {
                    NullStat(sender);
                }
            }

        }

        /// <summary>
        /// Null Stats based on sender name
        /// </summary>
        /// <param name="sender"></param>
        private void NullStat(object sender)
        {
            var stat = sender as NumericUpDown;
            switch (stat.Name)
            {
                case "nudHumanity":
                    nudHumanity.Value = 0;
                    nudHumanity.Text = "";
                    SavedStats.Humanity = null;
                    break;
                case "nudSouls":
                    nudSouls.Value = 0;
                    nudSouls.Text = "";
                    SavedStats.Souls = null;
                    break;
                case "nudVit":
                    nudVit.Minimum = 0;
                    nudVit.Value = 0;
                    nudVit.Text = "";
                    SavedStats.Vit = null;
                    break;
                case "nudAtt":
                    nudAtt.Minimum = 0;
                    nudAtt.Value = 0;
                    nudAtt.Text = "";
                    SavedStats.Att = null;
                    break;
                case "nudEnd":
                    nudEnd.Minimum = 0;
                    nudEnd.Value = 0;
                    nudEnd.Text = "";
                    SavedStats.End = null;
                    break;
                case "nudStr":
                    nudStr.Minimum = 0;
                    nudStr.Value = 0;
                    nudStr.Text = "";
                    SavedStats.Str = null;
                    break;
                case "nudDex":
                    nudDex.Minimum = 0;
                    nudDex.Value = 0;
                    nudDex.Text = "";
                    SavedStats.Dex = null;
                    break;
                case "nudRes":
                    nudRes.Minimum = 0;
                    nudRes.Value = 0;
                    nudRes.Text = "";
                    SavedStats.Res = null;
                    break;
                case "nudInt":
                    nudInt.Minimum = 0;
                    nudInt.Value = 0;
                    nudInt.Text = "";
                    SavedStats.Int = null;
                    break;
                case "nudFth":
                    nudFth.Minimum = 0;
                    nudFth.Value = 0;
                    nudFth.Text = "";
                    SavedStats.Fth = null;
                    break;
                case "nudCovChaos":
                    nudCovChaos.Text = "";
                    SavedStats.CovChaos = null;
                    break;
                case "nudCovDarkmoon":
                    nudCovDarkmoon.Text = "";
                    SavedStats.CovDarkmoon = null;
                    break;
                case "nudCovDarkwraith":
                    nudCovDarkwraith.Text = "";
                    SavedStats.CovDarkwraith = null;
                    break;
                case "nudCovForest":
                    nudCovForest.Text = "";
                    SavedStats.CovForest = null;
                    break;
                case "nudCovGravelord":
                    nudCovGravelord.Text = "";
                    SavedStats.CovGravelord = null;
                    break;
                case "nudCovDragon":
                    nudCovDragon.Text = "";
                    SavedStats.CovDragon = null;
                    break;
                case "nudCovSunlight":
                    nudCovSunlight.Text = "";
                    SavedStats.CovSunlight = null;
                    break;
                default:
                    break;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Hook.Loaded)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    txtName.Text = null;
                    SavedStats.Name = null;
                }
            }

        }

        private void cmbKeyDown(object sender, KeyEventArgs e)
        {
            if (!Hook.Loaded)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    NullCMB(sender);
                }
            }
        }

        private void NullCMB(object sender)
        {
            var cmb = sender as ComboBox;
            switch (cmb.Name)
            {
                case "cmbSex":
                    cmbSex.SelectedIndex = -1;
                    SavedStats.Sex = null;
                    break;
                case "cmbClass":
                    cmbClass.SelectedIndex = -1;
                    SavedStats.Class = null;
                    break;
                case "cmbPhysique":
                    cmbPhysique.SelectedIndex = -1;
                    SavedStats.Physique = null;
                    break;
                case "cmbCovenant":
                    cmbCovenant.SelectedIndex = -1;
                    SavedStats.Covenant = null;
                    break;
                default:
                    break;
            }
        }
    }
}
