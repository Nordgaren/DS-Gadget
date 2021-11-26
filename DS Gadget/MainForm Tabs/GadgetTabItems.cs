using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabItems : GadgetTab
    {
        public GadgetTabItems()
        {
            InitializeComponent();
        }

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            DSItemCategory.GetItemCategories();
            foreach (DSItemCategory category in DSItemCategory.All)
                cmbCategory.Items.Add(category);
            cmbCategory.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterItems();
            /*
            lbxItems.Items.Clear();
            DSItemCategory category = cmbCategory.SelectedItem as DSItemCategory;
            foreach (DSItem item in category.Items)
                lbxItems.Items.Add(item);
            lbxItems.SelectedIndex = 0;
            searchBox.Text = "";
            lblSearch.Visible = true;
            */
        }

        //Clear items and add the ones that match text in search box
        private void FilterItems()
        {

            lbxItems.Items.Clear();

            if (SearchAllCheckbox.Checked && searchBox.Text != "")
            {
                //search every item category
                foreach (DSItemCategory category in cmbCategory.Items)
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
                DSItemCategory category = cmbCategory.SelectedItem as DSItemCategory;
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

        private void cbxQuantityRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxQuantityRestrict.Checked)
            {
                nudQuantity.Enabled = true;
                nudQuantity.Maximum = int.MaxValue;
            }
            else if (lbxItems.SelectedIndex != -1)
            {
                DSItem item = lbxItems.SelectedItem as DSItem;
                nudQuantity.Maximum = item.StackLimit;
                if (item.StackLimit == 1)
                    nudQuantity.Enabled = false;
            }
        }

        private void cmbInfusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSInfusion infusion = cmbInfusion.SelectedItem as DSInfusion;
            nudUpgrade.Maximum = infusion.MaxUpgrade;
            //Checks if maxUpgrade is checked and sets the value to max value
            HandleMaxItemCheckbox();

        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSItem item = lbxItems.SelectedItem as DSItem;
            if (cbxQuantityRestrict.Checked)
            {
                if (item.StackLimit == 1)
                    nudQuantity.Enabled = false;
                else
                    nudQuantity.Enabled = true;
                nudQuantity.Maximum = item.StackLimit;
            }
            switch (item.UpgradeType)
            {
                case DSItem.Upgrade.None:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Enabled = false;
                    nudUpgrade.Maximum = 0;
                    break;
                case DSItem.Upgrade.Unique:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 5;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.Armor:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 10;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.Infusable:
                    cmbInfusion.Items.Clear();
                    foreach (DSInfusion infusion in DSInfusion.All)
                        cmbInfusion.Items.Add(infusion);
                    cmbInfusion.SelectedIndex = 0;
                    cmbInfusion.Enabled = true;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.InfusableRestricted:
                    cmbInfusion.Items.Clear();
                    foreach (DSInfusion infusion in DSInfusion.All)
                        if (!infusion.Restricted)
                            cmbInfusion.Items.Add(infusion);
                    cmbInfusion.SelectedIndex = 0;
                    cmbInfusion.Enabled = true;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.PyroFlame:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 15;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.PyroFlameAscended:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 5;
                    nudUpgrade.Enabled = true;
                    break;
            }

            HandleMaxItemCheckbox();
        }

        internal void EnableStats(bool enable)
        {
            btnCreate.Enabled = enable;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _ = ChangeColor(Color.DarkGray);
            CreateItem();
            
            //Mule Meme
            //foreach (DSItemCategory category in cmbCategory.Items)
            //{
            //    cmbCategory.SelectedItem = category;

            //    foreach (DSItem item in category.Items)
            //    {
            //        lbxItems.SelectedItem = item;
            //        int id = item.ID;
            //        if (item.UpgradeType == DSItem.Upgrade.PyroFlame || item.UpgradeType == DSItem.Upgrade.PyroFlameAscended)
            //            id += (int)nudUpgrade.Value * 100;
            //        else
            //            id += (int)nudUpgrade.Value;
            //        if (item.UpgradeType == DSItem.Upgrade.Infusable || item.UpgradeType == DSItem.Upgrade.InfusableRestricted)
            //        {
            //            DSInfusion infusion = cmbInfusion.SelectedItem as DSInfusion;
            //            id += infusion.Value;
            //        }
            //        Hook.GetItem(item.CategoryID, id, (int)nudQuantity.Value);
            //    }
            //}
        }

        //I think this is for safety so you don't spawn two items (not my code) - Nord
        private void lbxItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _ = ChangeColor(Color.DarkGray);
            CreateItem();
        }

        //Apply hair to currently loaded character
        public void CreateItem()
        {
            
            //Check if the button is enabled and the selected item isn't null
            if (btnCreate.Enabled && lbxItems.SelectedItem != null)
            {
                _ = ChangeColor(Color.DarkGray);
                DSItem item = lbxItems.SelectedItem as DSItem;
                
                int id = item.ID;

                if (item.UpgradeType == DSItem.Upgrade.PyroFlame || item.UpgradeType == DSItem.Upgrade.PyroFlameAscended)
                    id += (int)nudUpgrade.Value * 100;
                else
                    id += (int)nudUpgrade.Value;
                if (item.UpgradeType == DSItem.Upgrade.Infusable || item.UpgradeType == DSItem.Upgrade.InfusableRestricted)
                {
                    DSInfusion infusion = cmbInfusion.SelectedItem as DSInfusion;
                    id += infusion.Value;
                }
                Hook.GetItem(item.CategoryID, id, (int)nudQuantity.Value);
            }
        }

        //Give focus and select all
        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.SelectAll();
            searchBox.Focus();
        }

        //handles up and down scrolling
        private void ScrollListbox(KeyEventArgs e)
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

                //One liner meme that does the exact same thing as the code above
                //lbxItems.SelectedIndex = ((lbxItems.SelectedIndex - 1) + lbxItems.Items.Count) % lbxItems.Items.Count;
                //return;
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

                //One liner meme that does the exact same thing as the code above
                //lbxItems.SelectedIndex = (lbxItems.SelectedIndex + 1) % lbxItems.Items.Count;
                //return;

            }


        }

        //Changes the color of the Apply button
        private async Task ChangeColor(Color new_color)
        {
            btnCreate.BackColor = new_color;

            await Task.Delay(TimeSpan.FromSeconds(.25));

            btnCreate.BackColor = default(Color);
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
                CreateItem();
                return;
            }

            //Return if sender is cmbInfusion so that arrow keys are handled correctly
            if (sender == cmbInfusion)
                return;
            //Prevents up and down keys from moving the cursor left and right when nothing in item box
            if (lbxItems.Items.Count == 0)
            {
                if (e.KeyCode == Keys.Up)
                    e.Handled = true; //Do not pass keypress along
                if (e.KeyCode == Keys.Down)
                    e.Handled = true; //Do not pass keypress along
                return;
            }

            ScrollListbox(e);
        }

        //Select number in nud
        private void nudUpgrade_Click(object sender, EventArgs e)
        {
            nudUpgrade.Select(0, nudUpgrade.Text.Length);
            nudUpgrade.Focus();
        }

        private void SearchAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox changed, refresh search filter (if searchBox is not empty)
            if (searchBox.Text != "")
                FilterItems();
        }

        private void maxUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            //HandleMaxItemCheckbox()
            if (maxUpgrade.Checked)
            {
                nudUpgrade.Value = nudUpgrade.Maximum;
                nudQuantity.Value = nudQuantity.Maximum;
            }
            else
            {
                nudUpgrade.Value = nudUpgrade.Minimum;
                nudQuantity.Value = nudQuantity.Minimum;
            }
        }

        private void HandleMaxItemCheckbox()
        {
            //Set upgrade nud to max if max checkbox is ticked
            if (maxUpgrade.Checked)
            {
                nudUpgrade.Value = nudUpgrade.Maximum;
                nudQuantity.Value = nudQuantity.Maximum;
            }
        }

        private void cmbInfusion_KeyDown(object sender, KeyEventArgs e)
        {
            //Create selected index as item
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; //Do not pass keypress along
                CreateItem();
                return;
            }
        }
    }
}
