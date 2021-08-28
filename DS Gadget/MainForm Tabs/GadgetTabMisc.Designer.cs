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
            this.btnEventFlagRead = new System.Windows.Forms.Button();
            this.btnEventFlagWrite = new System.Windows.Forms.Button();
            this.cbxEventFlagValue = new System.Windows.Forms.CheckBox();
            this.txtEventFlagID = new System.Windows.Forms.TextBox();
            this.btnUnlockGestures = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnApplyHair = new System.Windows.Forms.Button();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.groupBoxHair = new System.Windows.Forms.GroupBox();
            this.SearchAllCheckbox = new System.Windows.Forms.CheckBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.nudNewGame = new System.Windows.Forms.NumericUpDown();
            this.lblNewGame = new System.Windows.Forms.Label();
            gbxEventFlags = new System.Windows.Forms.GroupBox();
            lblEventFlagsID = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            gbxEventFlags.SuspendLayout();
            this.groupBoxHair.SuspendLayout();
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
            label1.Location = new System.Drawing.Point(12, 28);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 20);
            label1.TabIndex = 29;
            label1.Text = "Category";
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
            this.cmbCategory.Location = new System.Drawing.Point(12, 49);
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
            this.btnApplyHair.Location = new System.Drawing.Point(362, 48);
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
            this.lbxItems.Location = new System.Drawing.Point(12, 122);
            this.lbxItems.Margin = new System.Windows.Forms.Padding(4);
            this.lbxItems.MinimumSize = new System.Drawing.Size(0, 24);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.ScrollAlwaysVisible = true;
            this.lbxItems.Size = new System.Drawing.Size(450, 309);
            this.lbxItems.TabIndex = 35;
            this.lbxItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // groupBoxHair
            // 
            this.groupBoxHair.Controls.Add(this.SearchAllCheckbox);
            this.groupBoxHair.Controls.Add(this.lblSearch);
            this.groupBoxHair.Controls.Add(this.searchBox);
            this.groupBoxHair.Controls.Add(this.lbxItems);
            this.groupBoxHair.Controls.Add(this.btnApplyHair);
            this.groupBoxHair.Controls.Add(this.cmbCategory);
            this.groupBoxHair.Controls.Add(label1);
            this.groupBoxHair.Location = new System.Drawing.Point(4, 167);
            this.groupBoxHair.Name = "groupBoxHair";
            this.groupBoxHair.Size = new System.Drawing.Size(480, 450);
            this.groupBoxHair.TabIndex = 29;
            this.groupBoxHair.TabStop = false;
            this.groupBoxHair.Text = "Hair";
            // 
            // SearchAllCheckbox
            // 
            this.SearchAllCheckbox.AutoSize = true;
            this.SearchAllCheckbox.Location = new System.Drawing.Point(364, 88);
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
            this.lblSearch.Location = new System.Drawing.Point(17, 92);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(72, 20);
            this.lblSearch.TabIndex = 36;
            this.lblSearch.Text = "Search...";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(12, 88);
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
            this.Controls.Add(this.groupBoxHair);
            this.Controls.Add(this.btnUnlockGestures);
            this.Controls.Add(gbxEventFlags);
            this.Name = "GadgetTabMisc";
            this.Size = new System.Drawing.Size(496, 631);
            gbxEventFlags.ResumeLayout(false);
            gbxEventFlags.PerformLayout();
            this.groupBoxHair.ResumeLayout(false);
            this.groupBoxHair.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxHair;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox SearchAllCheckbox;
        private System.Windows.Forms.NumericUpDown nudNewGame;
        private System.Windows.Forms.Label lblNewGame;
    }
}
