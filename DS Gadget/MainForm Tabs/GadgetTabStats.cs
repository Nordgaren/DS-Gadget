﻿using System;
using System.Linq;

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
                nudVit.Value = Hook.Vitality;
                nudAtt.Value = Hook.Attunement;
                nudEnd.Value = Hook.Endurance;
                nudStr.Value = Hook.Strength;
                nudDex.Value = Hook.Dexterity;
                nudRes.Value = Hook.Resistance;
                nudInt.Value = Hook.Intelligence;
                nudFth.Value = Hook.Faith;
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

            Hook.LevelUp(vitality, attunement, endurance, strength, dexterity, resistance, intelligence, faith, sl);
        }

        //Useless for now.
        //internal void EnableStats(bool enable)
        //{
        //    txtName.Enabled = enable;
        //    cmbClass.Enabled = enable;
        //    cmbSex.Enabled = enable;
        //    cmbPhysique.Enabled = enable;
        //    nudHumanity.Enabled = enable;
        //    nudSouls.Enabled = enable;
        //    nudVit.Enabled = enable;
        //    nudAtt.Enabled = enable;
        //    nudEnd.Enabled = enable;
        //    nudStr.Enabled = enable;
        //    nudDex.Enabled = enable;
        //    nudRes.Enabled = enable;
        //    nudInt.Enabled = enable;
        //    nudFth.Enabled = enable;
        //    nudCovChaos.Enabled = enable;
        //    nudCovDarkmoon.Enabled = enable;
        //    nudCovDarkwraith.Enabled = enable;
        //    nudCovForest.Enabled = enable;
        //    nudCovGravelord.Enabled = enable;
        //    nudCovDragon.Enabled = enable;
        //    nudCovSunlight.Enabled = enable;
        //}

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.CharName = txtName.Text;
        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Sex = (cmbSex.SelectedItem as DSSex).ID;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSClass charClass = cmbClass.SelectedItem as DSClass;
            nudVit.Minimum = charClass.Vitality;
            nudAtt.Minimum = charClass.Attunement;
            nudEnd.Minimum = charClass.Endurance;
            nudStr.Minimum = charClass.Strength;
            nudDex.Minimum = charClass.Dexterity;
            nudRes.Minimum = charClass.Resistance;
            nudInt.Minimum = charClass.Intelligence;
            nudFth.Minimum = charClass.Faith;
            if (!Reading)
            {
                Hook.Class = charClass.ID;
                RecalculateStats();
            }
        }

        private void cmbPhysique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Physique = (cmbPhysique.SelectedItem as DSPhysique).ID;
        }

        private void nudHumanity_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Humanity = (int)nudHumanity.Value;
        }

        private void nudSouls_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Souls = (int)nudSouls.Value;
        }

        private void nudStat_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                RecalculateStats();
        }

        private void cmbCovenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Covenant = ((DSCovenant)cmbCovenant.SelectedItem).ID;
        }

        private void nudCovChaos_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.ChaosServantPoints = (byte)nudCovChaos.Value;
        }

        private void nudCovDarkmoon_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.DarkmoonBladePoints = (byte)nudCovDarkmoon.Value;
        }

        private void nudCovDarkwraith_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.DarkwraithPoints = (byte)nudCovDarkwraith.Value;
        }

        private void nudCovForest_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.ForestHunterPoints = (byte)nudCovForest.Value;
        }

        private void nudCovGravelord_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.GravelordServantPoints = (byte)nudCovGravelord.Value;
        }

        private void nudCovDragon_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.PathOfTheDragonPoints = (byte)nudCovDragon.Value;
        }

        private void nudCovSunlight_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.WarriorOfSunlightPoints = (byte)nudCovSunlight.Value;
        }
    }
}
