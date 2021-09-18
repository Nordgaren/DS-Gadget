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
    public partial class ColorSelector : Form
    {
        public ColorSelector(DSHook hook)
        {
            InitializeComponent();
            PixelData = (Bitmap)pbxColorSelector.Image;
            Hook = hook;
            R = Hook.HairColorRed;
            G = Hook.HairColorGreen;
            B = Hook.HairColorBlue;
        }

        Bitmap PixelData;
        private DSHook Hook;
        private float R;
        private float G;
        private float B;


        private void pbxColorSelector_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var clr = PixelData.GetPixel(e.X, e.Y);
                lblsmallScreen.BackColor = clr;
                lblHexValue.Text = $"{clr.R.ToString("X2")}{clr.G.ToString("X2")}{clr.B.ToString("X2")}";

                if (e.Button == MouseButtons.Left)
                {
                    nudRed.Value = clr.R;
                    nudGreen.Value = clr.G;
                    nudBlue.Value = clr.B;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            
        }

        private void pbxColorSelector_MouseDown(object sender, MouseEventArgs e)
        {
            var clr = PixelData.GetPixel(e.X, e.Y);
            nudRed.Value = clr.R;
            nudGreen.Value = clr.G;
            nudBlue.Value = clr.B;
        }



        private void nudRed_ValueChanged(object sender, EventArgs e)
        {
            Hook.HairColorRed = GadgetTabInternals.Check ? (float)((nudRed.Value / 255) * 10) : (float)(nudRed.Value / 255);
        }

        private void nudGreen_ValueChanged(object sender, EventArgs e)
        {
            Hook.HairColorGreen = GadgetTabInternals.Check ? (float)((nudGreen.Value / 255) * 10) : (float)(nudGreen.Value / 255);
        }

        private void nudBlue_ValueChanged(object sender, EventArgs e)
        {
            Hook.HairColorBlue = GadgetTabInternals.Check ? (float)((nudBlue.Value / 255) * 10) : (float)(nudBlue.Value / 255);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hook.HairColorRed = R;
            Hook.HairColorGreen = G;
            Hook.HairColorBlue = B;
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
