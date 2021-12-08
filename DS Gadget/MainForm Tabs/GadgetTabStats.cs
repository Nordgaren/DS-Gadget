using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            MakeLists();
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

        // One init function to make all of the lists
        private void MakeLists()
        {
            //NudList
            NudList.Add(nudHumanity);
            NudList.Add(nudSouls);
            NudList.Add(nudVit);
            NudList.Add(nudAtt);
            NudList.Add(nudEnd);
            NudList.Add(nudStr);
            NudList.Add(nudDex);
            NudList.Add(nudRes);
            NudList.Add(nudInt);
            NudList.Add(nudFth);
            NudList.Add(nudCovChaos);
            NudList.Add(nudCovDarkmoon);
            NudList.Add(nudCovDarkwraith);
            NudList.Add(nudCovForest);
            NudList.Add(nudCovGravelord);
            NudList.Add(nudCovDragon);
            NudList.Add(nudCovSunlight);

            //CmbList
            CmbList.Add(cmbSex);
            CmbList.Add(cmbClass);
            CmbList.Add(cmbPhysique);
            CmbList.Add(cmbCovenant);

        }

        public override void ReloadTab()
        {
            CheckStatsChange(); // This has to be called before any nud values get set.
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
            catch (ArgumentOutOfRangeException) 
            {
                //Try recalculating stats. Putting in a try catch block just in case catch block triggered for purpose of comment above
                try { RecalculateStats(); } catch { }
            }

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

            DSClass charClass = cmbClass.SelectedItem as DSClass;
            if (charClass == null)
                return;

            int sl = charClass.SoulLevel;
            sl += vitality - charClass.Vitality;
            sl += attunement - charClass.Attunement;
            sl += endurance - charClass.Endurance;
            sl += strength - charClass.Strength;
            sl += dexterity - charClass.Dexterity;
            sl += resistance - charClass.Resistance;
            sl += intelligence - charClass.Intelligence;
            sl += faith - charClass.Faith;

            Hook.LevelUp(vitality, attunement, endurance, strength, dexterity, resistance, intelligence, faith, sl);

        }

        private int CalculateSL(int vitality, int attunement, int endurance, int strength, int dexterity, int resistance, int intelligence, int faith)
        {
            DSClass charClass = cmbClass.SelectedItem as DSClass;
            if (charClass == null)
                return 0;

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

        //Get's run from MainForm when character is loaded and unloaded
        internal void EnabledStats(bool enable)
        {
            if (enable)
            {
                UpdateTab();
                if (cbxLoad.Checked)
                {
                    if (SavedStats.GetType().GetProperties().Where(pi => pi.CustomAttributes.Count() > 0).Select(pi => pi.GetValue(SavedStats)).Any(value => value != null) || !string.IsNullOrWhiteSpace(SavedStats.Name))
                    {
                        LoadSavedStats();
                    }
                }
                CheckTextChange();
                //RecalculateStats();
            }
            else
            {
                if (Main != null)
                {
                    ResetPage();
                }
            }
        }

        //Checks if the nuds value is blank or not. Loads correct value if it is. Prevents numbers not showing if the value entered happened to be the same as the blank nud value (usually 0)
        private void CheckTextChange()
        {
            //Check if each nud has empty text, if it does, set the text to the Hook value.
            foreach (var nud in NudList)
            {
                if (nud.Text == "")
                {
                    nud.Text = Hook[nud.Name].ToString();
                }
            }
        }

        //checks if the stats was changed from "". This is to make sure stats save if the value entered happened to be the same as the blank nud value (usually 0)
        private void CheckStatsChange()
        {
            //Check if each nud in the nudlist as empty text, and save if necessary
            foreach (var nud in NudList)
            {
                if (nud.Text != "")
                    SavedStats[nud.Name] = (int)nud.Value;//Save stat if it's not ""
            }
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

        //Combobox selected index changed. Might be able to simplify later, but right now they cast to their own class. (Also sex uses a short instead of a byte like the other 2.
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
                        SaveStatsCmb(sender);
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
                        SaveStatsCmb(sender);
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
                        var dsPhysique = cmbPhysique.SelectedItem as DSPhysique;
                        Hook.Physique = dsPhysique.ID;
                        Hook.ChangePhysique(dsPhysique.Head, dsPhysique.Chest, dsPhysique.Waist, dsPhysique.Hands, dsPhysique.Legs);
                    }
                    else
                    {
                        SaveStatsCmb(sender);
                    }
                }
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
                        SaveStatsCmb(sender);
                    }
                }
            }
        }

        private SavedStats SavedStats = new SavedStats();

        public bool Updating { get; private set; }

        //Hand stat nud changes
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
                    SaveStatsNud(sender);

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
        
        //Takes Sender as NumericUpDown and sets Value via SavedStats[nud.Name] indexer
        private void SaveStatsNud(object sender)
        {
            var nud = sender as NumericUpDown;
            SavedStats[nud.Name] = (int)nud.Value;
            nud.Text = nud.Value.ToString(); //Update the text incase the value was the same as the previous value
        }

        //Takes Sender as ComboBox and sets SelectedIndex via SavedStats[cmb.Name] indexer
        private void SaveStatsCmb(object sender)
        {
            var cmb = sender as ComboBox;
            SavedStats[cmb.Name] = cmb.SelectedIndex;
        }

        //handle all Cov, Humanity and Souls nud changes
        private void nud_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
            {
                var nud = sender as NumericUpDown;
                if (Hook.Loaded)
                {
                    Hook[nud.Name] = (int)nud.Value;
                }
                else
                {
                    SaveStatsNud(sender);
                }
            }
        }

        //Returns a value between the min and max, even if value is below or above
        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        //List of nuds for enumeration
        private List<NumericUpDown> NudList = new List<NumericUpDown>();

        //list of cmbs for enumeration
        private List<ComboBox> CmbList = new List<ComboBox>();

        //Check each saved stat if it's null and load them if they aren't
        private void LoadSavedStats()
        {
            if (Hook.Loaded)
            {
                //Check if Name is null and set name
                if (!string.IsNullOrWhiteSpace(SavedStats.Name))
                {
                    txtName.Text = SavedStats.Name;
                }

                //Check each nud to see if it's null or not and then set value
                foreach (var nud in NudList)
                {
                    var stat = (int?)SavedStats[nud.Name];
                    if (stat.HasValue)
                    {
                        nud.Value = Clamp(stat.Value, nud.Minimum, nud.Maximum);
                    }
                }

                //Check each cmb to see if it's null or not and then set index
                foreach (var cmb in CmbList)
                {
                    var index = (int?)SavedStats[cmb.Name];
                    if (index.HasValue)
                    {
                        cmb.SelectedIndex = index.Value;
                    }
                }
            }
        }

        // Resets all values on page to a blank state in order of the SavedStats class
        private void ResetPage()
        {
            txtName.Text = null;
            SavedStats.Name = null;
            NullCMB(cmbSex);
            NullCMB(cmbClass);
            NullCMB(cmbPhysique);
            NullNUD(nudHumanity);
            NullNUD(nudSouls);
            NullNUD(nudVit);
            NullNUD(nudAtt);
            NullNUD(nudEnd);
            NullNUD(nudStr);
            NullNUD(nudDex);
            NullNUD(nudRes);
            NullNUD(nudInt);
            NullNUD(nudFth);
            NullCMB(cmbCovenant);
            NullNUD(nudCovChaos);
            NullNUD(nudCovDarkmoon);
            NullNUD(nudCovDarkwraith);
            NullNUD(nudCovForest);
            NullNUD(nudCovGravelord);
            NullNUD(nudCovDragon);
            NullNUD(nudCovSunlight);
        }
        
        private void nudKeyDown(object sender, KeyEventArgs e)
        {
            if (!Hook.Loaded)
            {
                //If Enter Save stats
                if (e.KeyCode == Keys.Enter)
                {
                    SaveStatsNud(sender);
                }

                //If Escape Null stats
                if (e.KeyCode == Keys.Escape)
                {
                    NullNUD(sender);
                }
            }
        }

        //Switch that nulls out nuds and their associated SavedStat
        private void NullNUD(object sender)
        {
            var stat = sender as NumericUpDown;
            if (stat.Minimum > 0)
                stat.Minimum = 0;
            stat.Value = 0;
            stat.Text = "";
            SavedStats[stat.Name] = null;
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

        //Switch that nulls out combo boxes and their associated SavedStat
        private void NullCMB(object sender)
        {
            var cmb = sender as ComboBox;
            cmb.SelectedIndex = -1;
            SavedStats[cmb.Name] = null;
        }
    }
}