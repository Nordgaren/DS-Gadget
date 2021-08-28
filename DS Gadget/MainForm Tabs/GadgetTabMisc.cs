using System;
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

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            DSFashionCategory.GetItemCategories();
            foreach (DSFashionCategory category in DSFashionCategory.All)
                cmbCategory.Items.Add(category);
            cmbCategory.SelectedIndex = 0;
        }

        public override void UpdateTab()
        {
            nudNewGame.Value = Hook.NewGame;
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
            ApplyHair();
        }

        //Apply hair to currently loaded character
        private void ApplyHair()
        {
            //Check if the button is enabled and the selected item isn't null
            if (btnApplyHair.Enabled == true && lbxItems.SelectedItem != null)
            {
                _ = ChangeColor(Color.DarkGray);
                DSItem item = lbxItems.SelectedItem as DSItem;
                int id = item.ID;
                Hook.EquipHairID = id;
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
                ApplyHair();
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
    }
}
