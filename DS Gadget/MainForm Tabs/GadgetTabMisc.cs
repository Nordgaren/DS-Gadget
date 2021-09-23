using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabMisc : GadgetTab
    {
        public GadgetTabMisc()
        {
            InitializeComponent();
        }

        private void btnEventFlagRead_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEventFlagID.Text, out int id))
                cbxEventFlagValue.Checked = Hook.ReadEventFlag(id);
        }

        private void btnEventFlagWrite_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEventFlagID.Text, out int id))
                Hook.WriteEventFlag(id, cbxEventFlagValue.Checked);
        }

        private void btnUnlockGestures_Click(object sender, EventArgs e)
        {
            Hook.UnlockAllGestures();
        }
        List<DSFashionCategory> Armor = new List<DSFashionCategory>();
        List<DSFashionCategory> Weapons = new List<DSFashionCategory>();

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            DSFashionCategory.GetItemCategories();
            foreach (DSFashionCategory category in DSFashionCategory.All)
            {
                if (category.ID == 0x10000000)
                {
                    Armor.Add(category);
                }
                else if (category.ID == 0x00000000)
                {
                    Weapons.Add(category);
                }
            }


            cmbSlot.Items.Add("Hair");
            cmbSlot.Items.Add("Bolt 1");
            cmbSlot.Items.Add("Arrow 1");

            cmbSlot.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
        }

        public override void UpdateTab()
        {
            nudNewGame.Value = Hook.NewGame;
            SetPanelColor();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxItems.Items.Clear();
            DSFashionCategory category = cmbCategory.SelectedItem as DSFashionCategory;
            foreach (DSItem item in category.Items)
                lbxItems.Items.Add(item);
            lbxItems.SelectedIndex = 0;
            searchBox.Text = "";
            lblSearch.Visible = true;
        }

        //Clear items and add the ones that match text in search box
        private void FilterItems()
        {

            lbxItems.Items.Clear();

            if (SearchAllCheckbox.Checked && searchBox.Text != "")
            {
                //search every item category
                foreach (DSFashionCategory category in cmbCategory.Items)
                {
                    foreach (DSItem item in category.Items)
                    {
                        if (item.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                            lbxItems.Items.Add(item);
                    }
                }
            }
            else
            {
                //only search selected item category
                DSFashionCategory category = cmbCategory.SelectedItem as DSFashionCategory;
                foreach (DSItem item in category.Items)
                {
                    if (item.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                        lbxItems.Items.Add(item);
                }
            }


            /*
            //original code
            DSItemCategory category = cmbCategory.SelectedItem as DSItemCategory;
            foreach (DSItem item in category.Items)
            {
                if (item.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    lbxItems.Items.Add(item);
                }
            }
            */

            if (lbxItems.Items.Count > 0)
                lbxItems.SelectedIndex = 0;

            HandleSearchLabel();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            FilterItems();
        }

        //Handles the "Searching..." label on the text box
        private void HandleSearchLabel()
        {
            if (searchBox.Text == "")
                lblSearch.Visible = true;
            else
                lblSearch.Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _ = ChangeColor(Color.DarkGray);
            ApplyItem();
            SetIdLabel();
        }

        private void ApplyItem()
        {
            switch (cmbSlot.SelectedIndex)
            {
                case 0:
                    ApplyHair();
                    break;
                case 1:
                    ApplyBoltOne();
                    break;
                case 2:
                    ApplyArrowOne();
                    break;
                default:
                    break;
            }
        }

        //Apply hair to currently loaded character
        private void ApplyHair()
        {
            //Check if the button is enabled and the selected item isn't null
            if (btnApplyHair.Enabled == true && lbxItems.SelectedItem != null)
            {
                DSItem item = lbxItems.SelectedItem as DSItem;
                int id = item.ID;
                Hook.EquipHairID = id;
            }
        }

        private void ApplyBoltOne()
        {
            if (btnApplyHair.Enabled == true && lbxItems.SelectedItem != null)
            {
                DSItem item = lbxItems.SelectedItem as DSItem;
                int id = item.ID;
                Hook.EquipBolt1ID = id;
            }
        }

        private void ApplyArrowOne()
        {
            if (btnApplyHair.Enabled == true && lbxItems.SelectedItem != null)
            {
                DSItem item = lbxItems.SelectedItem as DSItem;
                int id = item.ID;
                Hook.EquipArrow1ID = id;
            }
        }

        //Give focus and select all
        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.SelectAll();
            searchBox.Focus();
        }

        //handles up down and enter
        private void KeyDownListbox(KeyEventArgs e)
        {
            //Scroll down through Items listbox and go back to bottom at end
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;//Do not pass keypress along
                //Check is there's still items to go through
                if (lbxItems.SelectedIndex > 0)
                {
                    lbxItems.SelectedIndex -= 1;
                    return;
                }

                //Check if last item or "over" for safety
                if (lbxItems.SelectedIndex <= 0)
                {
                    lbxItems.SelectedIndex = lbxItems.Items.Count - 1; //-1 because Selected Index is 0 based and Count isn't
                    return;
                }
            }

            //Scroll down through Items listbox and go back to top at end
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//Do not pass keypress along
                //Check is there's still items to go through
                if (lbxItems.SelectedIndex < lbxItems.Items.Count - 1) //-1 because Selected Index is 0 based and Count isn't
                {
                    lbxItems.SelectedIndex += 1;
                    return;
                }

                //Check if last item or "over" for safety
                if (lbxItems.SelectedIndex >= lbxItems.Items.Count - 1) //-1 because Selected Index is 0 based and Count isn't
                {
                    lbxItems.SelectedIndex = 0;
                    return;
                }
            }

            
        }

        internal void EnableStats(bool enable)
        {
            btnApplyHair.Enabled = enable;
            btnEventFlagRead.Enabled = enable;
            btnEventFlagWrite.Enabled = enable;
            pnlHairColor.Enabled = enable;
            pnlEyeColor.Enabled = enable;



            if (enable)
            {
                SetIdLabel();
                SetPanelColor();
                pnlEyeColor.BorderStyle = BorderStyle.FixedSingle;
                pnlHairColor.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pnlEyeColor.BorderStyle = BorderStyle.None;
                pnlHairColor.BorderStyle = BorderStyle.None;
            }
        }

        //Changes the color of the Apply button
        private async Task ChangeColor(Color new_color)
        {
            btnApplyHair.BackColor = new_color;

            await Task.Delay(TimeSpan.FromSeconds(.25));

            btnApplyHair.BackColor = default(Color);
        }

        //handles escape
        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                searchBox.Clear();
                return;
            }

            //Create selected index as item
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; //Do not pass keypress along
                _ = ChangeColor(Color.DarkGray);
                ApplyItem();
                return;
            }

            if (lbxItems.Items.Count == 0)
            {
                if (e.KeyCode == Keys.Up)
                    e.Handled = true;
                if (e.KeyCode == Keys.Down)
                    e.Handled = true;
                return;
            }

            KeyDownListbox(e);

        }

        private void SearchAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox changed, refresh search filter (if searchBox is not empty)
            if (searchBox.Text != "")
                FilterItems();
        }

        private void nudNewGame_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.NewGame = (int)nudNewGame.Value;
        }

        private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSlot.SelectedIndex)
            {
                case 0:
                    LoadCategory(Armor);
                    break;
                case 1:
                case 2:
                    LoadCategory(Weapons);
                    break;
                default:
                    break;
            }

            SetIdLabel();
        }

        private void SetIdLabel()
        {
            if (Hook.Loaded)
            {
                switch (cmbSlot.SelectedIndex)
                {
                    case 0:
                        lblID.Text = $"ID = {Hook.EquipHairID}";
                        break;
                    case 1:
                        lblID.Text = $"ID = {Hook.EquipBolt1ID}";
                        break;
                    case 2:
                        lblID.Text = $"ID = {Hook.EquipArrow1ID}";
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadCategory(List<DSFashionCategory> list)
        {
            cmbCategory.Items.Clear();
            foreach (var category in list)
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0;
        }

        

        private bool SelectorOpen;

        private void pnlHairColor_Click(object sender, EventArgs e)
        {
            if (! SelectorOpen)
            {
                var colorSelector = new ColorSelectorHair(Hook);
                colorSelector.Disposed += OnHairColorSelectorDisposed;
                colorSelector.Show();
                SelectorOpen = true;
            }
        }

        private void OnHairColorSelectorDisposed(object sender, EventArgs e)
        {
            SelectorOpen = false;
        }

        private void pnlEyeColor_Click(object sender, EventArgs e)
        {
            if (!SelectorOpen)
            {
                var colorSelector = new ColorSelectorEye(Hook);
                colorSelector.Disposed += OnEyeColorSelectorDisposed;
                colorSelector.Show();
                SelectorOpen = true;
            }
        }

        private void OnEyeColorSelectorDisposed(object sender, EventArgs e)
        {
            SelectorOpen = false;
        }

        
        private void SetPanelColor()
        {
            if (Hook.Loaded)
            {
                var red = Hook.HairColorRed > 1 ? (byte)(((Hook.HairColorRed / 10) * 255)) : (byte)(Hook.HairColorRed * 255);
                var green = Hook.HairColorGreen > 1 ? (byte)(((Hook.HairColorGreen / 10) * 255)) : (byte)(Hook.HairColorGreen * 255);
                var blue = Hook.HairColorBlue > 1 ? (byte)(((Hook.HairColorBlue / 10) * 255)) : (byte)(Hook.HairColorBlue * 255);

                pnlHairColor.BackColor = Color.FromArgb(red, green, blue);

                red = Hook.EyeColorRed > 1 ? (byte)(((Hook.EyeColorRed / 10) * 255)) : (byte)(Hook.EyeColorRed * 255);
                green = Hook.EyeColorGreen > 1 ? (byte)(((Hook.EyeColorGreen / 10) * 255)) : (byte)(Hook.EyeColorGreen * 255);
                blue = Hook.EyeColorBlue > 1 ? (byte)(((Hook.EyeColorBlue / 10) * 255)) : (byte)(Hook.EyeColorBlue * 255);

                pnlEyeColor.BackColor = Color.FromArgb(red, green, blue);
            }
        }
    }
}
