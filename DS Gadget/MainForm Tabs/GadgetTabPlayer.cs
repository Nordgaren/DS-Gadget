using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabPlayer : GadgetTab
    {
        
        private State.PlayerState playerState;

        public GadgetTabPlayer()
        {
            InitializeComponent();
        }

        private List<SavedPos> Positions = new List<SavedPos>();

        private List<TeamConfig> SavedConfigs;

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            playerState.Set = false;
            cbxStoreState.Checked = Settings.StoreHP;
            foreach (DSBonfire bonfire in DSBonfire.All)
                cbxBonfire.Items.Add(bonfire);
            nudSpeed.Value = Settings.Speed;
            Positions = SavedPos.GetSavedPositions();
            UpdatePositions();
            SavedConfigs = TeamConfig.GetConfigs();
            foreach (var item in SavedConfigs)
            {
                cmbTeamConfig.Items.Add(item);
            }

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            FilterBonfires();

            //if no items in bonfire list, add "None -1" to list and select
            if (cbxBonfire.Items.Count < 1) 
                cbxBonfire.Items.Add(DSBonfire.All[0]);
            cbxBonfire.SelectedIndex = 0; //select first index in bonfire list
            if (searchBox.Text == "")
                lblSearch.Visible = true;
            else
                lblSearch.Visible = false;
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.SelectAll();
            searchBox.Focus();
        }

        private void KeyDownListbox(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;

                if (cbxBonfire.SelectedIndex < cbxBonfire.Items.Count - 1)
                {
                    cbxBonfire.SelectedIndex += 1;
                    return;
                }

                if (cbxBonfire.SelectedIndex >= cbxBonfire.Items.Count - 1)
                {
                    return;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;

                if (cbxBonfire.SelectedIndex == 0)
                {
                    
                    return;
                }

                if (cbxBonfire.SelectedIndex != 0)
                {
                    cbxBonfire.SelectedIndex -= 1;
                    return;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnBonfireWarp_Click(null, null);
                return;
            }
        }

        private async Task ChangeColor(Color new_color)
        {
            btnBonfireWarp.BackColor = new_color;

            await Task.Delay(TimeSpan.FromSeconds(.25));

            btnBonfireWarp.BackColor = default(Color);
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                searchBox.Clear();

            if (cbxBonfire.Items.Count > 0)
                KeyDownListbox(e);

            if (cbxBonfire.Items.Count == 0)
            {
                if (e.KeyCode == Keys.Up)
                    e.Handled = true;
                if (e.KeyCode == Keys.Down)
                    e.Handled = true;
            }
        }

        

        public void EnableStats(bool enable)
        {
            nudHealth.Enabled = enable;
            nudStamina.Enabled = enable;
            nudChrType.Enabled = enable;
            nudTeamType.Enabled = enable;
            nudPlayRegion.Enabled = enable;
            btnBonfireWarp.Enabled = enable;
            btnPosRestore.Enabled = enable;
            btnPosStore.Enabled = enable;
        }

        private void UpdatePositions()
        {
            if (storedPositions.SelectedItem != new SavedPos())
            {
                storedPositions.Items.Clear();
                storedPositions.Items.Add(new SavedPos());
                foreach (var item in Positions)
                {
                    storedPositions.Items.Add(item);
                }
            }

        }

        public override void ResetTab()
        {
            if (Hook.Hooked)
            {
                if (cbxPosLock.Checked)
                    Hook.SetPosLock(false);
                if (Loaded)
                {
                    if (!cbxGravity.Checked)
                        Hook.SetGravity(true);
                    if (!cbxCollision.Checked)
                        Hook.SetCollision(true);
                    if (cbxSpeed.Checked)
                        Hook.SetSpeed(1);
                }
            }
        }

        public override void SaveTab()
        {
            Settings.StoreHP = cbxStoreState.Checked;
            Settings.Speed = nudSpeed.Value;
        }

        public override void ReloadTab()
        {
            if (cbxPosLock.Checked)
                Hook.SetPosLock(true);
            if (!cbxGravity.Checked)
                Hook.SetGravity(false);
            if (!cbxCollision.Checked)
                Hook.SetCollision(false);
            if (cbxSpeed.Checked)
                Hook.SetSpeed((float)nudSpeed.Value);
        }


        private void FilterBonfires()
        {
            ClearLastCurrentBonfire();
            cbxBonfire.Items.Clear();
            cbxBonfire.SelectedItem = null;
            foreach (DSBonfire bonfire in DSBonfire.All)
            {
                if (bonfire.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    cbxBonfire.Items.Add(bonfire);
                }
            }
        }

        private DSBonfire lastCurrentBonfire;

        private void ClearLastCurrentBonfire()
        {
            //remove "Current: " from last current bonfire
            if (lastCurrentBonfire != null)
            {
                if (lastCurrentBonfire.Name.Contains("Current: "))
                {
                    lastCurrentBonfire.Name = lastCurrentBonfire.Name.Remove(0, 9); //remove "Current: " from label
                }
                lastCurrentBonfire = null;
            }
        }

        public override void UpdateTab()
        {
            nudHealth.Value = Hook.Health;
            nudHealthMax.Value = Hook.HealthMax;
            nudHealthModMax.Value = Hook.HealthModMax;
            nudStamina.Value = Hook.Stamina;
            nudStaminaMax.Value = Hook.StaminaMax;
            nudStaminaModMax.Value = Hook.StaminaModMax;
            nudChrType.Value = Hook.ChrType;
            nudTeamType.Value = Hook.TeamType;

            if (cbxForcePlayRegion.Checked)
                Hook.PlayRegion = (int)nudPlayRegion.Value;
            else
                nudPlayRegion.Value = Hook.PlayRegion;

            txtWorld.Text = Hook.World.ToString();
            txtArea.Text = Hook.Area.ToString();
            nudPosX.Value = (decimal)Hook.PosX;
            nudPosY.Value = (decimal)Hook.PosY;
            nudPosZ.Value = (decimal)Hook.PosZ;
            nudPosAngle.Value = (decimal)((Hook.PosAngle + Math.PI) / (Math.PI * 2) * 360);
            nudPosStableX.Value = (decimal)Hook.PosStableX;
            nudPosStableY.Value = (decimal)Hook.PosStableY;
            nudPosStableZ.Value = (decimal)Hook.PosStableZ;
            nudPosStableAngle.Value = (decimal)((Hook.PosStableAngle + Math.PI) / (Math.PI * 2) * 360);

            cbxDeathCam.Checked = Hook.DeathCam;


            //manage unknown warps and current warps that are not in filter
            //
            int bonfireID = Hook.LastBonfire;
            if (!cbxBonfire.DroppedDown && bonfireID != (cbxBonfire.SelectedItem as DSBonfire)?.ID) //check if dropdown not active AND last bonfire is not selected bonfire
            {

                FilterBonfires();

                DSBonfire result = cbxBonfire.Items.Cast<DSBonfire>().FirstOrDefault(b => b.ID == bonfireID); //check if bonfire in filtered list
                if (result == null)
                {
                    //target warp is not in filter
                    result = DSBonfire.All.FirstOrDefault(b => b.ID == bonfireID); //check if warp is in bonfire resource
                    if (result == null)
                    {
                        //bonfire not in filter. Add to filter as unknown
                        result = new DSBonfire(bonfireID, $"Unknown {bonfireID}");
                        cbxBonfire.Items.Add(result);
                        DSBonfire.All.Add(result);
                    }
                    else
                    {
                        //bonfire in list, but not in filter. add "Current: " to label and add to filter
                        result.Name = "Current: " + result.Name;
                        cbxBonfire.Items.Add(result);
                        lastCurrentBonfire = result; //set last current bonfire
                    }
                }
                cbxBonfire.SelectedItem = result;
            }
            //


            // Backstabbing resets speed, so reapply it 24/7
            if (cbxSpeed.Checked)
                Hook.SetSpeed((float)nudSpeed.Value);
        }

        public void StorePosition()
        {
            if (btnPosStore.Enabled)
            {
                var pos = new SavedPos();
                pos.Name = storedPositions.Text;
                pos.X = nudPosStoredX.Value = nudPosX.Value;
                pos.Y = nudPosStoredY.Value = nudPosY.Value;
                pos.Z = nudPosStoredZ.Value = nudPosZ.Value;
                pos.Angle = nudPosStoredAngle.Value = nudPosAngle.Value;
                playerState.HP = (int)nudHealth.Value;
                playerState.Stamina = (int)nudStamina.Value;
                playerState.FollowCam = Hook.DumpFollowCam();
                playerState.DeathCam = Hook.DeathCam;
                playerState.Set = true;
                pos.PlayerState = playerState;
                ProcessSavedPos(pos);
                UpdatePositions();
                SavedPos.Save(Positions);
            }
            
        }

        public void ProcessSavedPos(SavedPos pos)
        {
            if (!string.IsNullOrWhiteSpace(storedPositions.Text))
            {
                if (Positions.Any(n => n.Name == storedPositions.Text))
                {
                    var old = Positions.Single(n => n.Name == storedPositions.Text);
                    Positions.Remove(old);
                    Positions.Add(pos);
                    return;
                }

                Positions.Add(pos);
            }

        }

        public void RemoveSavedPos()
        {
            if (Positions.Any(n => n.Name == storedPositions.Text))
            {
                if (MessageBox.Show("Are you sure you want to delete this positon?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var old = Positions.Single(n => n.Name == storedPositions.Text);
                    Positions.Remove(old);
                    storedPositions.SelectedIndex = 0;
                    UpdatePositions();
                    SavedPos.Save(Positions);
                }
                    
            }

        }

        public void RestorePosition()
        {
            if (btnPosRestore.Enabled)
            {
                float x = (float)nudPosStoredX.Value;
                float y = (float)nudPosStoredY.Value;
                float z = (float)nudPosStoredZ.Value;
                float angle = (float)((double)nudPosStoredAngle.Value / 360 * (Math.PI * 2) - Math.PI);

                Hook.PosWarp(x, y, z, angle);
                if (playerState.Set)
                {
                    // Two frames for safety, wait until after warp
                    System.Threading.Thread.Sleep(1000 / 15);
                    Hook.UndumpFollowCam(playerState.FollowCam);

                    if (cbxStoreState.Checked)
                    {
                        nudHealth.Value = playerState.HP;
                        nudStamina.Value = playerState.Stamina;
                        cbxDeathCam.Checked = playerState.DeathCam;
                    }
                }
            }
               
        }

        public void FlipGravity()
        {
            cbxGravity.Checked = !cbxGravity.Checked;
        }

        public void FlipCollision()
        {
            cbxCollision.Checked = !cbxCollision.Checked;
        }

        public void FlipSpeed()
        {
            cbxSpeed.Checked = !cbxSpeed.Checked;
        }

        private void nudHealth_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Health = (int)nudHealth.Value;
        }

        private void nudStamina_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Stamina = (int)nudStamina.Value;
        }

        private void nudChrType_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.ChrType = (int)nudChrType.Value;
        }

        private void nudTeamType_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.TeamType = (int)nudTeamType.Value;
        }

        private void nudPlayRegion_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.PlayRegion = (int)nudPlayRegion.Value;
        }

        private void cbxPosLock_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPosLock(cbxPosLock.Checked);
            nudPosX.Enabled = cbxPosLock.Checked;
            nudPosY.Enabled = cbxPosLock.Checked;
            nudPosZ.Enabled = cbxPosLock.Checked;
        }

        private void nudPos_ValueChanged(object sender, EventArgs e)
        {
            if (cbxPosLock.Checked)
            {
                float x = (float)nudPosX.Value;
                float y = (float)nudPosY.Value;
                float z = (float)nudPosZ.Value;
                Hook.SetPos(x, y, z);
            }
        }

        private void btnPosStore_Click(object sender, EventArgs e)
        {
            StorePosition();
        }

        private void btnPosRestore_Click(object sender, EventArgs e)
        {
            RestorePosition();
        }

        private void cbxGravity_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetGravity(cbxGravity.Checked);
        }

        private void cbxCollision_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetCollision(cbxCollision.Checked);
        }

        private void cbxDeathCam_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DeathCam = cbxDeathCam.Checked;
        }

        private void cbxBonfire_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if no items in bonfire list, add "None -1" to list and select
            if (cbxBonfire.Items.Count < 1)
            {
                cbxBonfire.Items.Add(DSBonfire.All[0]);
                cbxBonfire.SelectedIndex = 0;
            }

            DSBonfire bonfire = cbxBonfire.SelectedItem as DSBonfire;

            //re-filter bonfire list if lastCurrentBonfire was set and it is not currently selected bonfire
            if (lastCurrentBonfire != null && lastCurrentBonfire != bonfire)
            {
                FilterBonfires();
            };

            //hook warp entityID
            Hook.LastBonfire = bonfire.ID;
        }

        private void btnBonfireWarp_Click(object sender, EventArgs e)
        {
            if (btnBonfireWarp.Enabled == true)
            {
                _ = ChangeColor(Color.DarkGray);
                Hook.BonfireWarp();
            }
        }

        private void cbxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            nudSpeed.Enabled = cbxSpeed.Checked;
            Hook.SetSpeed(cbxSpeed.Checked ? (float)nudSpeed.Value : 1);
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetSpeed((float)nudSpeed.Value);
        }

        private void savedPos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StorePosition();
            }

            if (e.KeyCode == Keys.Delete && e.Shift == true)
            {
                deleteButton_Click(sender, e);
            }
        }

        private void storedPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var savedPos = storedPositions.SelectedItem as SavedPos;
            nudPosStoredX.Value = savedPos.X;
            nudPosStoredY.Value = savedPos.Y;
            nudPosStoredZ.Value = savedPos.Z;
            nudPosStoredAngle.Value = savedPos.Angle;
            playerState = savedPos.PlayerState;
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            RemoveSavedPos();
        }

        private void cmbTeamConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = cmbTeamConfig.SelectedItem as TeamConfig;
            if (!string.IsNullOrWhiteSpace(config.Name))
            {
                Hook.ChrType = config.ChrType;
                Hook.TeamType = config.TeamType;
            }
        }
    }
}
