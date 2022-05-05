using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
            SearchAllCheckbox.Checked = Settings.SearchAllFashion;
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

        public override void SaveTab()
        {
            Settings.SearchAllFashion = SearchAllCheckbox.Checked;
        }

        public override void UpdateTab()
        {
            nudNewGame.Value = Hook.NewGame;
            SetPanelColor();
        }

        public override void ReloadTab()
        {
            if (cbxHairRandom.Checked)
                Task.Run(RandomizeHair);

            if (cbxEyeRandom.Checked)
                Task.Run(RandomizeEye);
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

        Random Rand = new Random();

        private void cbxHairRandom_CheckedChanged(object sender, EventArgs e)
        {
            _ = Task.Run(RandomizeHair);
        }


        double HairSpeedMultiplier = 1;

        private async Task RandomizeHair()
        {
            if (!Hook.Loaded)
                return;
            var neon = Hook.HairColorRed > 1 || Hook.HairColorGreen > 1 || Hook.HairColorBlue > 1;

            var red = neon ? (byte)(((Hook.HairColorRed / 10) * 255)) : (byte)(Hook.HairColorRed * 255);
            var green = neon ? (byte)(((Hook.HairColorGreen / 10) * 255)) : (byte)(Hook.HairColorGreen * 255);
            var blue = neon ? (byte)(((Hook.HairColorBlue / 10) * 255)) : (byte)(Hook.HairColorBlue * 255);

            var color = Color.FromArgb(red, green, blue);

            while (cbxHairRandom.Checked && Hook.Loaded)
            {
                var hsl = RgbaToHsl(color);
                hsl.H += 0.01f;
                color = HslToRgba(hsl);
                Hook.HairColorRed = neon ? (float)((color.R / 255f) * 10) : (float)(color.R / 255f);
                Hook.HairColorGreen = neon ? (float)((color.G / 255f) * 10) : (float)(color.G / 255f);
                Hook.HairColorBlue = neon ? (float)((color.B / 255f) * 10) : (float)(color.B / 255f);
                Thread.Sleep((int)(100 / HairSpeedMultiplier));

                //var red = neon ? (byte)(((Hook.HairColorRed / 10) * 255)) : (byte)(Hook.HairColorRed * 255);
                //var green = neon ? (byte)(((Hook.HairColorGreen / 10) * 255)) : (byte)(Hook.HairColorGreen * 255);
                //var blue = neon ? (byte)(((Hook.HairColorBlue / 10) * 255)) : (byte)(Hook.HairColorBlue * 255);

                //var color = Color.FromArgb(red, green, blue);
                //var target = Color.FromArgb(Rand.Next(255), Rand.Next(255), Rand.Next(255));

                //var amount = 0.0;
                //while (amount < 1f)
                //{
                //    if (!cbxHairRandom.Checked && Hook.Loaded)
                //        break;
                //    var lColor = Lerp(color, target, (float)amount);
                //    Hook.HairColorRed = neon ? (float)((lColor.R / 255f) * 10) : (float)(lColor.R / 255f);
                //    Hook.HairColorGreen = neon ? (float)((lColor.G / 255f) * 10) : (float)(lColor.G / 255f);
                //    Hook.HairColorBlue = neon ? (float)((lColor.B / 255f) * 10) : (float)(lColor.B / 255f);
                //    amount += 0.00003 * HairSpeedMultiplier;
                //}
            }
        }

        private void cbxEyeRandom_CheckedChanged(object sender, EventArgs e)
        {
            _ = Task.Run(RandomizeEye);
        }

        double EyeSpeedMultiplier = 1;

        private async Task RandomizeEye()
        {
            if (!Hook.Loaded)
                return;
            var neon = Hook.EyeColorRed > 1 || Hook.EyeColorGreen > 1 || Hook.EyeColorBlue > 1;

            var red = neon ? (byte)(((Hook.EyeColorRed / 10) * 255)) : (byte)(Hook.EyeColorRed * 255);
            var green = neon ? (byte)(((Hook.EyeColorGreen / 10) * 255)) : (byte)(Hook.EyeColorGreen * 255);
            var blue = neon ? (byte)(((Hook.EyeColorBlue / 10) * 255)) : (byte)(Hook.EyeColorBlue * 255);

            var color = Color.FromArgb(red, green, blue);

            while (cbxEyeRandom.Checked && Hook.Loaded)
            {
                var hsl = RgbaToHsl(color);
                hsl.H += 0.01f;
                color = HslToRgba(hsl);
                Hook.EyeColorRed = neon ? (float)((color.R / 255f) * 10) : (float)(color.R / 255f);
                Hook.EyeColorGreen = neon ? (float)((color.G / 255f) * 10) : (float)(color.G / 255f);
                Hook.EyeColorBlue = neon ? (float)((color.B / 255f) * 10) : (float)(color.B / 255f);
                Thread.Sleep((int)(100 / EyeSpeedMultiplier));
                //var red = neon ? (byte)(((Hook.EyeColorRed / 10) * 255)) : (byte)(Hook.EyeColorRed * 255);
                //var green = neon ? (byte)(((Hook.EyeColorGreen / 10) * 255)) : (byte)(Hook.EyeColorGreen * 255);
                //var blue = neon ? (byte)(((Hook.EyeColorBlue / 10) * 255)) : (byte)(Hook.EyeColorBlue * 255);

                //var color = Color.FromArgb(red, green, blue);
                //var target = Color.FromArgb(Rand.Next(255), Rand.Next(255), Rand.Next(255));

                //var amount = 0.0;
                //while (amount < 1f)
                //{
                //    if (!cbxEyeRandom.Checked && Hook.Loaded)
                //        break;
                //    var lColor = Lerp(color, target, (float)amount);
                //    Hook.EyeColorRed = neon ? (float)((lColor.R / 255f) * 10) : (float)(lColor.R / 255f);
                //    Hook.EyeColorGreen = neon ? (float)((lColor.G / 255f) * 10) : (float)(lColor.G / 255f);
                //    Hook.EyeColorBlue = neon ? (float)((lColor.B / 255f) * 10) : (float)(lColor.B / 255f);
                //    amount += 0.00003 * EyeSpeedMultiplier;
                //}
            }
        }
        public static Color Lerp(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t)
             );
           
        }

        public struct HSLAColor
        {
            public float H;
            public float S;
            public float L;
            public float A;
            public HSLAColor(float h, float s, float l, float a)
            {
                H = h;
                S = s;
                L = l;
                A = a;
            }
        }
        public static HSLAColor RgbaToHsl(Color rgba)
        {
            float r = rgba.R / 255.0f;
            float g = rgba.G / 255.0f;
            float b = rgba.B / 255.0f;

            float max = (r > g && r > b) ? r : (g > b) ? g : b;
            float min = (r < g && r < b) ? r : (g < b) ? g : b;

            float h, s, l;
            h = s = l = (max + min) / 2.0f;

            if (max == min)
                h = s = 0.0f;

            else
            {
                float d = max - min;
                s = (l > 0.5f) ? d / (2.0f - max - min) : d / (max + min);

                if (r > g && r > b)
                    h = (g - b) / d + (g < b ? 6.0f : 0.0f);

                else if (g > b)
                    h = (b - r) / d + 2.0f;

                else
                    h = (r - g) / d + 4.0f;

                h /= 6.0f;
            }

            return new HSLAColor(h, s, l, rgba.A / 255.0f);
        }

        public static Color HslToRgba(HSLAColor hsl)
        {
            float r, g, b;

            if (hsl.S == 0.0f)
                r = g = b = hsl.L;

            else
            {
                var q = hsl.L < 0.5f ? hsl.L * (1.0f + hsl.S) : hsl.L + hsl.S - hsl.L * hsl.S;
                var p = 2.0f * hsl.L - q;
                r = HueToRgb(p, q, hsl.H + 1.0f / 3.0f);
                g = HueToRgb(p, q, hsl.H);
                b = HueToRgb(p, q, hsl.H - 1.0f / 3.0f);
            }

            return Color.FromArgb((int)(hsl.A * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        // Helper for HslToRgba
        private static float HueToRgb(float p, float q, float t)
        {
            if (t < 0.0f) t += 1.0f;
            if (t > 1.0f) t -= 1.0f;
            if (t < 1.0f / 6.0f) return p + (q - p) * 6.0f * t;
            if (t < 1.0f / 2.0f) return q;
            if (t < 2.0f / 3.0f) return p + (q - p) * (2.0f / 3.0f - t) * 6.0f;
            return p;
        }

        private void nudHairSpeed_ValueChanged(object sender, EventArgs e)
        {
            HairSpeedMultiplier = (double)nudHairSpeed.Value;
        }

        private void nudEyeSpeed_ValueChanged(object sender, EventArgs e)
        {
            EyeSpeedMultiplier = (double)nudEyeSpeed.Value;
        }

      
    }
}
