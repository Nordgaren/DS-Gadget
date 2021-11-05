using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DS_Gadget
{
    internal partial class GadgetTabCheats : GadgetTab
    {
        public GadgetTabCheats()
        {
            InitializeComponent();
            Timer.Elapsed += RefillHP; // Timer elapsed method to call when triggered
            Timer.AutoReset = false; // Do not reset the timer when it is finished
            nudHealInterval.Value = Settings.HealInterval;
        }

        public override void ResetTab()
        {
            if (Hook.Hooked)
            {
                if (cbxAllNoMagic.Checked)
                    Hook.SetAllNoMagic(false);
                if (cbxPlayerNoDead.Checked)
                    Hook.SetNoDead(false);
                if (cbxPlayerExterminate.Checked)
                    Hook.SetExterminate(false);
                if (cbxAllNoStamina.Checked)
                    Hook.SetAllStamina(false);
                if (cbxAllNoArrow.Checked)
                    Hook.SetAllAmmo(false);
                if (cbxPlayerHide.Checked)
                    Hook.SetHide(false);
                if (cbxPlayerSilence.Checked)
                    Hook.SetSilence(false);
                if (cbxAllNoDead.Checked)
                    Hook.SetAllNoDead(false);
                if (cbxAllNoDamage.Checked)
                    Hook.SetAllNoDamage(false);
                if (cbxAllNoHit.Checked)
                    Hook.SetAllNoHit(false);
                if (cbxAllNoAttack.Checked)
                    Hook.SetAllNoAttack(false);
                if (cbxAllNoMove.Checked)
                    Hook.SetAllNoMove(false);
                if (cbxAllNoUpdateAI.Checked)
                    Hook.SetAllNoUpdateAI(false);

                if (Loaded)
                {
                    if (cbxPlayerDeadMode.Checked)
                        Hook.PlayerDeadMode = false;
                    if (cbxPlayerNoDamage.Checked)
                        Hook.SetPlayerNoDamage(false);
                    if (cbxPlayerNoHit.Checked)
                        Hook.SetPlayerNoHit(false);
                    if (cbxPlayerNoStamina.Checked)
                        Hook.SetPlayerNoStamina(false);
                    if (cbxPlayerSuperArmor.Checked)
                        Hook.SetPlayerSuperArmor(false);
                    if (cbxPlayerNoGoods.Checked)
                        Hook.SetPlayerNoGoods(false);
                }
            }
        }

        public override void ReloadTab()
        {
            if (cbxPlayerDeadMode.Checked)
                Hook.PlayerDeadMode = true;
            if (cbxPlayerNoDamage.Checked)
                Hook.SetPlayerNoDamage(true);
            if (cbxPlayerNoHit.Checked)
                Hook.SetPlayerNoHit(true);
            if (cbxPlayerNoStamina.Checked)
                Hook.SetPlayerNoStamina(true);
            if (cbxPlayerSuperArmor.Checked)
                Hook.SetPlayerSuperArmor(true);
            if (cbxPlayerNoGoods.Checked)
                Hook.SetPlayerNoGoods(true);
            if (cbxAllNoMagic.Checked)
                Hook.SetAllNoMagic(true);
            if (cbxPlayerNoDead.Checked)
                Hook.SetNoDead(true);
            if (cbxPlayerExterminate.Checked)
                Hook.SetExterminate(true);
            if (cbxAllNoStamina.Checked)
                Hook.SetAllStamina(true);
            if (cbxAllNoArrow.Checked)
                Hook.SetAllAmmo(true);
            if (cbxPlayerHide.Checked)
                Hook.SetHide(true);
            if (cbxPlayerSilence.Checked)
                Hook.SetSilence(true);
            if (cbxAllNoDead.Checked)
                Hook.SetAllNoDead(true);
            if (cbxAllNoDamage.Checked)
                Hook.SetAllNoDamage(true);
            if (cbxAllNoHit.Checked)
                Hook.SetAllNoHit(true);
            if (cbxAllNoAttack.Checked)
                Hook.SetAllNoAttack(true);
            if (cbxAllNoMove.Checked)
                Hook.SetAllNoMove(true);
            if (cbxAllNoUpdateAI.Checked)
                Hook.SetAllNoUpdateAI(true);
        }

        internal void ToggleAI()
        {
            cbxAllNoUpdateAI.Checked = !cbxAllNoUpdateAI.Checked;
        }

        public override void UpdateTab()
        {
            // The game sometimes sets and unsets this, for instance when dropping into Manus' or BoC's arena
            // However for reasons I don't understand, constantly setting it causes issues with bow aiming for some users
            // So only re-set it when it has actually been unset
            if (cbxPlayerDeadMode.Checked && !Hook.PlayerDeadMode)
                Hook.PlayerDeadMode = true;

            if (Hook.Process.MainWindowTitle == "DARK SOULS - PHANTOM BREAK")
                cbxAllNoArrow.Checked = false;

            if (cbxAmmo.Checked)
                Hook.GetItem(0x00000000, 2200000, 99);

            if (cbxBolts.Checked)
                SpawnBolts();

            if (cbxArrows.Checked)
                SpawnArrows();

            if (cbxGreatArrrows.Checked)
                SpawnGreatArrows();

            // Only start refill timer if enabled, health is lower than max and the timer isn't already going
            if (cbxRefill.Checked && (Hook.Health < Hook.HealthModMax) && !Timer.Enabled)
            {
                _ = Task.Run(() => RefillTimer());
            }
        }

        System.Timers.Timer Timer = new System.Timers.Timer();

        private void RefillTimer()
        {
            double time = (double)nudHealInterval.Value;

            //Set interval in ms, record hp and start the timer
            Timer.Interval = time * 1000;
            var hp = Hook.Health;
            Timer.Start();

            while (Timer.Enabled)
            {
                // If the recorded hp variable is over Hook.Health, set the timer interval again (resetting it) and set the recorded hp value
                if (hp > Hook.Health)
                {
                    Timer.Interval = time * 1000;
                    hp = Hook.Health;
                }
            }
        }

        private void RefillHP(object sender, ElapsedEventArgs e)
        {
            Hook.Health = Hook.HealthModMax;
        }

        public void FlipPlayerDeadMode()
        {
            cbxPlayerDeadMode.Checked = !cbxPlayerDeadMode.Checked;
        }

        private void cbxPlayerDeadMode_CheckedChanged(object sender, EventArgs e)
        {
            Hook.PlayerDeadMode = cbxPlayerDeadMode.Checked;
        }

        private void cbxPlayerNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoDamage(cbxPlayerNoDamage.Checked);
        }

        private void cbxPlayerNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoStamina(cbxPlayerNoStamina.Checked);
        }

        private void cbxPlayerHide_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetHide(cbxPlayerHide.Checked);
        }

        private void cbxPlayerExterminate_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetExterminate(cbxPlayerExterminate.Checked);
        }

        private void cbxAllNoArrow_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllAmmo(cbxAllNoArrow.Checked);
        }

        private void cbxPlayerNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetNoDead(cbxPlayerNoDead.Checked);
        }

        private void cbxPlayerNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoHit(cbxPlayerNoHit.Checked);
        }

        private void cbxPlayerSuperArmor_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerSuperArmor(cbxPlayerSuperArmor.Checked);
        }

        private void cbxPlayerSilence_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetSilence(cbxPlayerSilence.Checked);
        }

        private void cbxPlayerNoGoods_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoGoods(cbxPlayerNoGoods.Checked);
        }

        private void cbxAllNoMagic_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMagic(cbxAllNoMagic.Checked);
        }

        private void cbxAllNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDead(cbxAllNoDead.Checked);
        }

        private void cbxAllNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoHit(cbxAllNoHit.Checked);
        }

        private void cbxAllNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDamage(cbxAllNoDamage.Checked);
        }

        private void cbxAllNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllStamina(cbxAllNoStamina.Checked);
        }

        private void cbxAllNoAttack_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoAttack(cbxAllNoAttack.Checked);
        }

        private void cbxAllNoUpdateAI_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoUpdateAI(cbxAllNoUpdateAI.Checked);
        }

        private void cbxAllNoMove_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMove(cbxAllNoMove.Checked);
        }

        private void nudHealInterval_ValueChanged(object sender, EventArgs e)
        {
            Settings.HealInterval = nudHealInterval.Value;
        }

        private void SpawnGreatArrows()
        {
            Hook.GetItem(0x00000000, 2007000, 99);
            Hook.GetItem(0x00000000, 2008000, 99);
        }

        private void SpawnArrows()
        {
            Hook.GetItem(0x00000000, 2000000, 99);
            Hook.GetItem(0x00000000, 2001000, 99);
            Hook.GetItem(0x00000000, 2002000, 99);
            Hook.GetItem(0x00000000, 2003000, 99);
            Hook.GetItem(0x00000000, 2004000, 99);
            Hook.GetItem(0x00000000, 2005000, 99);
            Hook.GetItem(0x00000000, 2006000, 99);
            Hook.GetItem(0x00000000, 2202000, 99);
            Hook.GetItem(0x00000000, 2302000, 99);
        }

        private void SpawnBolts()
        {
            Hook.GetItem(0x00000000, 2008000, 99);
            Hook.GetItem(0x00000000, 2100000, 99);
            Hook.GetItem(0x00000000, 2101000, 99);
            Hook.GetItem(0x00000000, 2102000, 99);
            Hook.GetItem(0x00000000, 2103000, 99);
            Hook.GetItem(0x00000000, 2104000, 99);
            Hook.GetItem(0x00000000, 2106000, 99);
            Hook.GetItem(0x00000000, 2108000, 99);
        }
    }
}
