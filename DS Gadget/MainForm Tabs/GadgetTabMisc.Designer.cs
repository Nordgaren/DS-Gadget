namespace DS_Gadget
{
    partial class GadgetTabMisc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox gbxEventFlags;
            System.Windows.Forms.Label lblEventFlagsID;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblSlot;
            this.btnEventFlagRead = new System.Windows.Forms.Button();
            this.btnEventFlagWrite = new System.Windows.Forms.Button();
            this.cbxEventFlagValue = new System.Windows.Forms.CheckBox();
            this.txtEventFlagID = new System.Windows.Forms.TextBox();
            this.btnUnlockGestures = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnApplyHair = new System.Windows.Forms.Button();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.groupBoxFashion = new System.Windows.Forms.GroupBox();
            this.nudEyeSpeed = new System.Windows.Forms.NumericUpDown();
            this.cbxEyeRandom = new System.Windows.Forms.CheckBox();
            this.nudHairSpeed = new System.Windows.Forms.NumericUpDown();
            this.cbxHairRandom = new System.Windows.Forms.CheckBox();
            this.pnlEyeColor = new System.Windows.Forms.Panel();
            this.lblEye = new System.Windows.Forms.Label();
            this.pnlHairColor = new System.Windows.Forms.Panel();
            this.lblHair = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbSlot = new System.Windows.Forms.ComboBox();
            this.SearchAllCheckbox = new System.Windows.Forms.CheckBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.nudNewGame = new System.Windows.Forms.NumericUpDown();
            this.lblNewGame = new System.Windows.Forms.Label();
            gbxEventFlags = new System.Windows.Forms.GroupBox();
            lblEventFlagsID = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblSlot = new System.Windows.Forms.Label();
            gbxEventFlags.SuspendLayout();
            this.groupBoxFashion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEyeSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHairSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewGame)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxEventFlags
            // 
            gbxEventFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxEventFlags.Controls.Add(this.btnEventFlagRead);
            gbxEventFlags.Controls.Add(this.btnEventFlagWrite);
            gbxEventFlags.Controls.Add(this.cbxEventFlagValue);
            gbxEventFlags.Controls.Add(this.txtEventFlagID);
            gbxEventFlags.Controls.Add(lblEventFlagsID);
            gbxEventFlags.Location = new System.Drawing.Point(4, 4);
            gbxEventFlags.Margin = new System.Windows.Forms.Padding(4);
            gbxEventFlags.Name = "gbxEventFlags";
            gbxEventFlags.Padding = new System.Windows.Forms.Padding(4);
            gbxEventFlags.Size = new System.Drawing.Size(488, 120);
            gbxEventFlags.TabIndex = 2;
            gbxEventFlags.TabStop = false;
            gbxEventFlags.Text = "Event Flags";
            // 
            // btnEventFlagRead
            // 
            this.btnEventFlagRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventFlagRead.Location = new System.Drawing.Point(272, 69);
            this.btnEventFlagRead.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventFlagRead.Name = "btnEventFlagRead";
            this.btnEventFlagRead.Size = new System.Drawing.Size(100, 28);
            this.btnEventFlagRead.TabIndex = 4;
            this.btnEventFlagRead.Text = "Read";
            this.btnEventFlagRead.UseVisualStyleBackColor = true;
            this.btnEventFlagRead.Click += new System.EventHandler(this.btnEventFlagRead_Click);
            // 
            // btnEventFlagWrite
            // 
            this.btnEventFlagWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventFlagWrite.Location = new System.Drawing.Point(380, 69);
            this.btnEventFlagWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventFlagWrite.Name = "btnEventFlagWrite";
            this.btnEventFlagWrite.Size = new System.Drawing.Size(100, 28);
            this.btnEventFlagWrite.TabIndex = 3;
            this.btnEventFlagWrite.Text = "Write";
            this.btnEventFlagWrite.UseVisualStyleBackColor = true;
            this.btnEventFlagWrite.Click += new System.EventHandler(this.btnEventFlagWrite_Click);
            // 
            // cbxEventFlagValue
            // 
            this.cbxEventFlagValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEventFlagValue.AutoSize = true;
            this.cbxEventFlagValue.Location = new System.Drawing.Point(368, 41);
            this.cbxEventFlagValue.Margin = new System.Windows.Forms.Padding(4);
            this.cbxEventFlagValue.Name = "cbxEventFlagValue";
            this.cbxEventFlagValue.Size = new System.Drawing.Size(94, 24);
            this.cbxEventFlagValue.TabIndex = 2;
            this.cbxEventFlagValue.Text = "Enabled";
            this.cbxEventFlagValue.UseVisualStyleBackColor = true;
            // 
            // txtEventFlagID
            // 
            this.txtEventFlagID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventFlagID.Location = new System.Drawing.Point(8, 39);
            this.txtEventFlagID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventFlagID.Name = "txtEventFlagID";
            this.txtEventFlagID.Size = new System.Drawing.Size(364, 26);
            this.txtEventFlagID.TabIndex = 1;
            // 
            // lblEventFlagsID
            // 
            lblEventFlagsID.AutoSize = true;
            lblEventFlagsID.Location = new System.Drawing.Point(8, 20);
            lblEventFlagsID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEventFlagsID.Name = "lblEventFlagsID";
            lblEventFlagsID.Size = new System.Drawing.Size(26, 20);
            lblEventFlagsID.TabIndex = 0;
            lblEventFlagsID.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 26);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 20);
            label1.TabIndex = 29;
            label1.Text = "Category";
            // 
            // lblSlot
            // 
            lblSlot.AutoSize = true;
            lblSlot.Location = new System.Drawing.Point(240, 17);
            lblSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSlot.Name = "lblSlot";
            lblSlot.Size = new System.Drawing.Size(37, 20);
            lblSlot.TabIndex = 39;
            lblSlot.Text = "Slot";
            // 
            // btnUnlockGestures
            // 
            this.btnUnlockGestures.Location = new System.Drawing.Point(4, 132);
            this.btnUnlockGestures.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnlockGestures.Name = "btnUnlockGestures";
            this.btnUnlockGestures.Size = new System.Drawing.Size(144, 28);
            this.btnUnlockGestures.TabIndex = 3;
            this.btnUnlockGestures.Text = "Unlock Gestures";
            this.btnUnlockGestures.UseVisualStyleBackColor = true;
            this.btnUnlockGestures.Click += new System.EventHandler(this.btnUnlockGestures_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(8, 47);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.MaxDropDownItems = 100;
            this.cmbCategory.MinimumSize = new System.Drawing.Size(84, 0);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(342, 28);
            this.cmbCategory.TabIndex = 33;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnApplyHair
            // 
            this.btnApplyHair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyHair.Location = new System.Drawing.Point(358, 46);
            this.btnApplyHair.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplyHair.Name = "btnApplyHair";
            this.btnApplyHair.Size = new System.Drawing.Size(100, 28);
            this.btnApplyHair.TabIndex = 35;
            this.btnApplyHair.Text = "Apply";
            this.btnApplyHair.UseVisualStyleBackColor = true;
            this.btnApplyHair.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnApplyHair.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // lbxItems
            // 
            this.lbxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.IntegralHeight = false;
            this.lbxItems.ItemHeight = 20;
            this.lbxItems.Location = new System.Drawing.Point(8, 123);
            this.lbxItems.Margin = new System.Windows.Forms.Padding(4);
            this.lbxItems.MinimumSize = new System.Drawing.Size(0, 24);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.ScrollAlwaysVisible = true;
            this.lbxItems.Size = new System.Drawing.Size(450, 271);
            this.lbxItems.TabIndex = 35;
            this.lbxItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // groupBoxFashion
            // 
            this.groupBoxFashion.Controls.Add(this.nudEyeSpeed);
            this.groupBoxFashion.Controls.Add(this.cbxEyeRandom);
            this.groupBoxFashion.Controls.Add(this.nudHairSpeed);
            this.groupBoxFashion.Controls.Add(this.cbxHairRandom);
            this.groupBoxFashion.Controls.Add(this.pnlEyeColor);
            this.groupBoxFashion.Controls.Add(this.lblEye);
            this.groupBoxFashion.Controls.Add(this.pnlHairColor);
            this.groupBoxFashion.Controls.Add(this.lblHair);
            this.groupBoxFashion.Controls.Add(this.lblID);
            this.groupBoxFashion.Controls.Add(lblSlot);
            this.groupBoxFashion.Controls.Add(this.cmbSlot);
            this.groupBoxFashion.Controls.Add(this.SearchAllCheckbox);
            this.groupBoxFashion.Controls.Add(this.lblSearch);
            this.groupBoxFashion.Controls.Add(this.searchBox);
            this.groupBoxFashion.Controls.Add(this.lbxItems);
            this.groupBoxFashion.Controls.Add(this.btnApplyHair);
            this.groupBoxFashion.Controls.Add(this.cmbCategory);
            this.groupBoxFashion.Controls.Add(label1);
            this.groupBoxFashion.Location = new System.Drawing.Point(4, 167);
            this.groupBoxFashion.Name = "groupBoxFashion";
            this.groupBoxFashion.Size = new System.Drawing.Size(480, 458);
            this.groupBoxFashion.TabIndex = 29;
            this.groupBoxFashion.TabStop = false;
            this.groupBoxFashion.Text = "Fashion";
            // 
            // nudEyeSpeed
            // 
            this.nudEyeSpeed.DecimalPlaces = 2;
            this.nudEyeSpeed.Location = new System.Drawing.Point(282, 426);
            this.nudEyeSpeed.Name = "nudEyeSpeed";
            this.nudEyeSpeed.Size = new System.Drawing.Size(96, 26);
            this.nudEyeSpeed.TabIndex = 49;
            this.nudEyeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEyeSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEyeSpeed.ValueChanged += new System.EventHandler(this.nudEyeSpeed_ValueChanged);
            // 
            // cbxEyeRandom
            // 
            this.cbxEyeRandom.AutoSize = true;
            this.cbxEyeRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxEyeRandom.Location = new System.Drawing.Point(297, 404);
            this.cbxEyeRandom.Name = "cbxEyeRandom";
            this.cbxEyeRandom.Size = new System.Drawing.Size(96, 24);
            this.cbxEyeRandom.TabIndex = 48;
            this.cbxEyeRandom.Text = "Random";
            this.cbxEyeRandom.UseVisualStyleBackColor = true;
            this.cbxEyeRandom.CheckedChanged += new System.EventHandler(this.cbxEyeRandom_CheckedChanged);
            // 
            // nudHairSpeed
            // 
            this.nudHairSpeed.DecimalPlaces = 2;
            this.nudHairSpeed.Location = new System.Drawing.Point(87, 425);
            this.nudHairSpeed.Name = "nudHairSpeed";
            this.nudHairSpeed.Size = new System.Drawing.Size(96, 26);
            this.nudHairSpeed.TabIndex = 47;
            this.nudHairSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHairSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHairSpeed.ValueChanged += new System.EventHandler(this.nudHairSpeed_ValueChanged);
            // 
            // cbxHairRandom
            // 
            this.cbxHairRandom.AutoSize = true;
            this.cbxHairRandom.Location = new System.Drawing.Point(87, 404);
            this.cbxHairRandom.Name = "cbxHairRandom";
            this.cbxHairRandom.Size = new System.Drawing.Size(96, 24);
            this.cbxHairRandom.TabIndex = 46;
            this.cbxHairRandom.Text = "Random";
            this.cbxHairRandom.UseVisualStyleBackColor = true;
            this.cbxHairRandom.CheckedChanged += new System.EventHandler(this.cbxHairRandom_CheckedChanged);
            // 
            // pnlEyeColor
            // 
            this.pnlEyeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEyeColor.Location = new System.Drawing.Point(384, 421);
            this.pnlEyeColor.Name = "pnlEyeColor";
            this.pnlEyeColor.Size = new System.Drawing.Size(74, 31);
            this.pnlEyeColor.TabIndex = 45;
            this.pnlEyeColor.Click += new System.EventHandler(this.pnlEyeColor_Click);
            // 
            // lblEye
            // 
            this.lblEye.AutoSize = true;
            this.lblEye.Location = new System.Drawing.Point(388, 403);
            this.lblEye.Name = "lblEye";
            this.lblEye.Size = new System.Drawing.Size(77, 20);
            this.lblEye.TabIndex = 44;
            this.lblEye.Text = "Eye Color";
            // 
            // pnlHairColor
            // 
            this.pnlHairColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHairColor.Location = new System.Drawing.Point(6, 421);
            this.pnlHairColor.Name = "pnlHairColor";
            this.pnlHairColor.Size = new System.Drawing.Size(74, 31);
            this.pnlHairColor.TabIndex = 42;
            this.pnlHairColor.Click += new System.EventHandler(this.pnlHairColor_Click);
            // 
            // lblHair
            // 
            this.lblHair.AutoSize = true;
            this.lblHair.Location = new System.Drawing.Point(10, 403);
            this.lblHair.Name = "lblHair";
            this.lblHair.Size = new System.Drawing.Size(79, 20);
            this.lblHair.TabIndex = 41;
            this.lblHair.Text = "Hair Color";
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Location = new System.Drawing.Point(358, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(100, 25);
            this.lblID.TabIndex = 40;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSlot
            // 
            this.cmbSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlot.FormattingEnabled = true;
            this.cmbSlot.Location = new System.Drawing.Point(279, 12);
            this.cmbSlot.Name = "cmbSlot";
            this.cmbSlot.Size = new System.Drawing.Size(71, 28);
            this.cmbSlot.TabIndex = 38;
            this.cmbSlot.SelectedIndexChanged += new System.EventHandler(this.cmbSlot_SelectedIndexChanged);
            // 
            // SearchAllCheckbox
            // 
            this.SearchAllCheckbox.AutoSize = true;
            this.SearchAllCheckbox.Location = new System.Drawing.Point(360, 86);
            this.SearchAllCheckbox.Name = "SearchAllCheckbox";
            this.SearchAllCheckbox.Size = new System.Drawing.Size(107, 24);
            this.SearchAllCheckbox.TabIndex = 37;
            this.SearchAllCheckbox.Text = "Search All";
            this.SearchAllCheckbox.UseVisualStyleBackColor = true;
            this.SearchAllCheckbox.CheckedChanged += new System.EventHandler(this.SearchAllCheckbox_CheckedChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Enabled = false;
            this.lblSearch.Location = new System.Drawing.Point(13, 90);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(72, 20);
            this.lblSearch.TabIndex = 36;
            this.lblSearch.Text = "Search...";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(8, 86);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(342, 26);
            this.searchBox.TabIndex = 34;
            this.searchBox.Click += new System.EventHandler(this.searchBox_Click);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // nudNewGame
            // 
            this.nudNewGame.Location = new System.Drawing.Point(420, 132);
            this.nudNewGame.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudNewGame.Name = "nudNewGame";
            this.nudNewGame.Size = new System.Drawing.Size(50, 26);
            this.nudNewGame.TabIndex = 30;
            this.nudNewGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNewGame.ValueChanged += new System.EventHandler(this.nudNewGame_ValueChanged);
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.Location = new System.Drawing.Point(378, 136);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(42, 20);
            this.lblNewGame.TabIndex = 31;
            this.lblNewGame.Text = "NG+";
            // 
            // GadgetTabMisc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(this.lblNewGame);
            this.Controls.Add(this.nudNewGame);
            this.Controls.Add(this.groupBoxFashion);
            this.Controls.Add(this.btnUnlockGestures);
            this.Controls.Add(gbxEventFlags);
            this.Name = "GadgetTabMisc";
            this.Size = new System.Drawing.Size(496, 631);
            gbxEventFlags.ResumeLayout(false);
            gbxEventFlags.PerformLayout();
            this.groupBoxFashion.ResumeLayout(false);
            this.groupBoxFashion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEyeSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHairSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnlockGestures;
        private System.Windows.Forms.Button btnEventFlagRead;
        private System.Windows.Forms.Button btnEventFlagWrite;
        private System.Windows.Forms.CheckBox cbxEventFlagValue;
        private System.Windows.Forms.TextBox txtEventFlagID;
        private System.Windows.Forms.ListBox lbxItems;
        private System.Windows.Forms.Button btnApplyHair;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.GroupBox groupBoxFashion;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox SearchAllCheckbox;
        private System.Windows.Forms.NumericUpDown nudNewGame;
        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.ComboBox cmbSlot;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblHair;
        private System.Windows.Forms.Panel pnlHairColor;
        private System.Windows.Forms.Panel pnlEyeColor;
        private System.Windows.Forms.Label lblEye;
        private System.Windows.Forms.CheckBox cbxHairRandom;
        private System.Windows.Forms.NumericUpDown nudHairSpeed;
        private System.Windows.Forms.NumericUpDown nudEyeSpeed;
        private System.Windows.Forms.CheckBox cbxEyeRandom;
    }
}
