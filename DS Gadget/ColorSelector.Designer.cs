
namespace DS_Gadget
{
    partial class ColorSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSelector));
            this.lblColorSelector = new System.Windows.Forms.Label();
            this.pbxColorSelector = new System.Windows.Forms.PictureBox();
            this.gbxColorSelector = new System.Windows.Forms.GroupBox();
            this.pnlSelectedScreen = new System.Windows.Forms.Panel();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGren = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.nudBlue = new System.Windows.Forms.NumericUpDown();
            this.nudGreen = new System.Windows.Forms.NumericUpDown();
            this.nudRed = new System.Windows.Forms.NumericUpDown();
            this.lblHexValue = new System.Windows.Forms.Label();
            this.lblsmallScreen = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorSelector)).BeginInit();
            this.gbxColorSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblColorSelector
            // 
            this.lblColorSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblColorSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorSelector.Location = new System.Drawing.Point(0, 0);
            this.lblColorSelector.Name = "lblColorSelector";
            this.lblColorSelector.Size = new System.Drawing.Size(507, 51);
            this.lblColorSelector.TabIndex = 0;
            this.lblColorSelector.Text = "Color Selector";
            this.lblColorSelector.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbxColorSelector
            // 
            this.pbxColorSelector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbxColorSelector.ErrorImage = null;
            this.pbxColorSelector.Image = global::DS_Gadget.Properties.Resources.rgbSpectrum;
            this.pbxColorSelector.InitialImage = global::DS_Gadget.Properties.Resources.rgbSpectrum;
            this.pbxColorSelector.Location = new System.Drawing.Point(75, 25);
            this.pbxColorSelector.Name = "pbxColorSelector";
            this.pbxColorSelector.Size = new System.Drawing.Size(226, 156);
            this.pbxColorSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxColorSelector.TabIndex = 1;
            this.pbxColorSelector.TabStop = false;
            this.pbxColorSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxColorSelector_MouseDown);
            this.pbxColorSelector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxColorSelector_MouseMove);
            // 
            // gbxColorSelector
            // 
            this.gbxColorSelector.Controls.Add(this.pnlSelectedScreen);
            this.gbxColorSelector.Controls.Add(this.lblBlue);
            this.gbxColorSelector.Controls.Add(this.lblGren);
            this.gbxColorSelector.Controls.Add(this.lblRed);
            this.gbxColorSelector.Controls.Add(this.nudBlue);
            this.gbxColorSelector.Controls.Add(this.nudGreen);
            this.gbxColorSelector.Controls.Add(this.nudRed);
            this.gbxColorSelector.Location = new System.Drawing.Point(8, 385);
            this.gbxColorSelector.Name = "gbxColorSelector";
            this.gbxColorSelector.Size = new System.Drawing.Size(499, 144);
            this.gbxColorSelector.TabIndex = 2;
            this.gbxColorSelector.TabStop = false;
            this.gbxColorSelector.Text = "7";
            // 
            // pnlSelectedScreen
            // 
            this.pnlSelectedScreen.Location = new System.Drawing.Point(293, 36);
            this.pnlSelectedScreen.Name = "pnlSelectedScreen";
            this.pnlSelectedScreen.Size = new System.Drawing.Size(183, 100);
            this.pnlSelectedScreen.TabIndex = 6;
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(15, 104);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(41, 20);
            this.lblBlue.TabIndex = 5;
            this.lblBlue.Text = "Blue";
            // 
            // lblGren
            // 
            this.lblGren.AutoSize = true;
            this.lblGren.Location = new System.Drawing.Point(15, 72);
            this.lblGren.Name = "lblGren";
            this.lblGren.Size = new System.Drawing.Size(54, 20);
            this.lblGren.TabIndex = 4;
            this.lblGren.Text = "Green";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(15, 40);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(39, 20);
            this.lblRed.TabIndex = 3;
            this.lblRed.Text = "Red";
            // 
            // nudBlue
            // 
            this.nudBlue.Location = new System.Drawing.Point(75, 98);
            this.nudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBlue.Name = "nudBlue";
            this.nudBlue.Size = new System.Drawing.Size(120, 26);
            this.nudBlue.TabIndex = 2;
            this.nudBlue.ValueChanged += new System.EventHandler(this.nudBlue_ValueChanged);
            // 
            // nudGreen
            // 
            this.nudGreen.Location = new System.Drawing.Point(75, 66);
            this.nudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudGreen.Name = "nudGreen";
            this.nudGreen.Size = new System.Drawing.Size(120, 26);
            this.nudGreen.TabIndex = 1;
            this.nudGreen.ValueChanged += new System.EventHandler(this.nudGreen_ValueChanged);
            // 
            // nudRed
            // 
            this.nudRed.Location = new System.Drawing.Point(75, 34);
            this.nudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRed.Name = "nudRed";
            this.nudRed.Size = new System.Drawing.Size(120, 26);
            this.nudRed.TabIndex = 0;
            this.nudRed.ValueChanged += new System.EventHandler(this.nudRed_ValueChanged);
            // 
            // lblHexValue
            // 
            this.lblHexValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHexValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHexValue.Location = new System.Drawing.Point(75, 295);
            this.lblHexValue.Name = "lblHexValue";
            this.lblHexValue.Size = new System.Drawing.Size(176, 30);
            this.lblHexValue.TabIndex = 3;
            // 
            // lblsmallScreen
            // 
            this.lblsmallScreen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblsmallScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblsmallScreen.Location = new System.Drawing.Point(311, 295);
            this.lblsmallScreen.Name = "lblsmallScreen";
            this.lblsmallScreen.Size = new System.Drawing.Size(83, 30);
            this.lblsmallScreen.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblsmallScreen);
            this.groupBox1.Controls.Add(this.pbxColorSelector);
            this.groupBox1.Controls.Add(this.lblHexValue);
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 348);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(128, 535);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 45);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 535);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 586);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.gbxColorSelector);
            this.Controls.Add(this.lblColorSelector);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorSelector";
            this.Text = "Color Selector";
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorSelector)).EndInit();
            this.gbxColorSelector.ResumeLayout(false);
            this.gbxColorSelector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblColorSelector;
        private System.Windows.Forms.PictureBox pbxColorSelector;
        private System.Windows.Forms.GroupBox gbxColorSelector;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblGren;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.NumericUpDown nudBlue;
        private System.Windows.Forms.NumericUpDown nudGreen;
        private System.Windows.Forms.NumericUpDown nudRed;
        private System.Windows.Forms.Panel pnlSelectedScreen;
        private System.Windows.Forms.Label lblHexValue;
        private System.Windows.Forms.Label lblsmallScreen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}