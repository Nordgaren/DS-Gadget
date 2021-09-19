using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class ColorSelectorEye : Form
    {
        Bitmap PixelData;
        private DSHook Hook;
        private float R;
        private float G;
        private float B;

        public ColorSelectorEye(DSHook hook)
        {
            InitializeComponent();
            PixelData = (Bitmap)pbxColorSelector.Image;
            Hook = hook;
            R = Hook.EyeColorRed;
            G = Hook.EyeColorGreen;
            B = Hook.EyeColorBlue;

            //Returns wether or not the hair was glowy or not and sets the RGB values accordingly
            var glow = SetGlowStatus();
            nudRed.Value = glow ? (byte)(((R / 10) * 255)) : (byte)(R * 255);
            nudGreen.Value = glow ? (byte)(((G / 10) * 255)) : (byte)(G * 255);
            nudBlue.Value = glow ? (byte)(((B / 10) * 255)) : (byte)(B * 255);

            CenterGBXLabel();
        }

        private void CenterGBXLabel()
        {
            Label label = new Label();
            label.Text = gbxColorSelector.Text;
            gbxColorSelector.Text = "";
            label.Left = gbxColorSelector.Left + (gbxColorSelector.Width - label.Width) / 2;
            label.Top = gbxColorSelector.Top + 2;
            label.Parent = gbxColorSelector.Parent;
            label.BringToFront();
        }

        private bool SetGlowStatus()
        {
            //If any of the eye color values are over 1, set the glow checkbox to checked
            if (Hook.EyeColorRed > 1 || Hook.EyeColorGreen > 1 || Hook.EyeColorBlue > 1)
                return cbxGlow.Checked = true;
            else
                return cbxGlow.Checked = false;
        }

        private void pbxColorSelector_MouseMove(object sender, MouseEventArgs e)
        {
            //Get the color data of the pixel under the mouse.
            try
            {
                var clr = PixelData.GetPixel(e.X, e.Y);
                txtHexColor.Text = $"{clr.R.ToString("X2")}{clr.G.ToString("X2")}{clr.B.ToString("X2")}";
                lblsmallScreen.BackColor = clr;

                if (e.Button == MouseButtons.Left)
                {
                    SetEyeColor(clr);
                }
            }
            catch (ArgumentOutOfRangeException) { return; } //Prevents Gadget from crashing if you go outside of the color selector with mouse button down.
        }


        //Set selected color panel BG color and RGB value of the nuds to the color passed to the method.
        private void SetEyeColor(Color clr)
        {
            pnlSelectedScreen.BackColor = clr;
            nudRed.Value = clr.R;
            nudGreen.Value = clr.G;
            nudBlue.Value = clr.B;
        }

        //Turn the nud values into the hex avlues seen in txtHexColor
        private void UpdateTextBox()
        {
            var red = ((byte)nudRed.Value).ToString("X2");
            var green = ((byte)nudGreen.Value).ToString("X2");
            var blue = ((byte)nudBlue.Value).ToString("X2");
            txtHexColor.Text = $"{red}{green}{blue}";
            SetEyeColor(Color.FromArgb((byte)nudRed.Value, (byte)nudGreen.Value, (byte)nudBlue.Value));
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            RecalulateColors();
            UpdateTextBox();
        }

        //Recalculate all colors based on the checkbox status
        private void RecalulateColors()
        {
            Hook.EyeColorRed = cbxGlow.Checked ? (float)((nudRed.Value / 255) * 10) : (float)(nudRed.Value / 255);
            Hook.EyeColorGreen = cbxGlow.Checked ? (float)((nudGreen.Value / 255) * 10) : (float)(nudGreen.Value / 255);
            Hook.EyeColorBlue = cbxGlow.Checked ? (float)((nudBlue.Value / 255) * 10) : (float)(nudBlue.Value / 255);
        }

        //Set the eye color back to the color the eyes were when this form opened
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hook.EyeColorRed = R;
            Hook.EyeColorGreen = G;
            Hook.EyeColorBlue = B;
            Close();
        }

        //Close the form
        private void btnApply_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Convert the hex number typed into txtHexColor
        private void txtHexColor_TextChanged(object sender, EventArgs e)
        {
            var color = txtHexColor.Text.PadRight(6, '0'); //Pad the hex number

            var red = byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var green = byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var blue = byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            if (ActiveControl == sender) //Only recalculate if the event sender is the active control (txtHexColor)
            {
                var clr = Color.FromArgb(red, green, blue);
                SetEyeColor(clr);
            }
        }

        //Might be unecessary
        private void nud_Leave(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        //Recalculate colors if the checkbox changed.
        private void cbxGlow_CheckedChanged(object sender, EventArgs e)
        {
            RecalulateColors();
        }
    }
}
