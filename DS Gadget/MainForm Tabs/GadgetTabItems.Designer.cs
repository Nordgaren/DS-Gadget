namespace DS_Gadget
{
    partial class GadgetTabItems
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
            System.Windows.Forms.Label lblUpgrade;
            System.Windows.Forms.Label lblInfusion;
            System.Windows.Forms.Label lblQuantity;
            System.Windows.Forms.Label lblCategory;
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.maxUpgrade = new System.Windows.Forms.CheckBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.nudUpgrade = new System.Windows.Forms.NumericUpDown();
            this.cmbInfusion = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbxQuantityRestrict = new System.Windows.Forms.CheckBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.SearchAllCheckbox = new System.Windows.Forms.CheckBox();
            lblUpgrade = new System.Windows.Forms.Label();
            lblInfusion = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();
            lblCategory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpgrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUpgrade
            // 
            lblUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblUpgrade.AutoSize = true;
            lblUpgrade.Location = new System.Drawing.Point(395, 50);
            lblUpgrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUpgrade.Name = "lblUpgrade";
            lblUpgrade.Size = new System.Drawing.Size(71, 20);
            lblUpgrade.TabIndex = 21;
            lblUpgrade.Text = "Upgrade";
            // 
            // lblInfusion
            // 
            lblInfusion.AutoSize = true;
            lblInfusion.Location = new System.Drawing.Point(4, 49);
            lblInfusion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInfusion.Name = "lblInfusion";
            lblInfusion.Size = new System.Drawing.Size(66, 20);
            lblInfusion.TabIndex = 19;
            lblInfusion.Text = "Infusion";
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(395, 1);
            lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(68, 20);
            lblQuantity.TabIndex = 16;
            lblQuantity.Text = "Quantity";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new System.Drawing.Point(4, 0);
            lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(73, 20);
            lblCategory.TabIndex = 14;
            lblCategory.Text = "Category";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Enabled = false;
            this.lblSearch.Location = new System.Drawing.Point(9, 104);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(72, 20);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "Search...";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(502, 99);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 28);
            this.btnCreate.TabIndex = 23;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // maxUpgrade
            // 
            this.maxUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxUpgrade.Checked = true;
            this.maxUpgrade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maxUpgrade.Location = new System.Drawing.Point(490, 50);
            this.maxUpgrade.Margin = new System.Windows.Forms.Padding(4);
            this.maxUpgrade.Name = "maxUpgrade";
            this.maxUpgrade.Size = new System.Drawing.Size(96, 21);
            this.maxUpgrade.TabIndex = 26;
            this.maxUpgrade.Text = "Max";
            this.maxUpgrade.UseVisualStyleBackColor = true;
            this.maxUpgrade.CheckedChanged += new System.EventHandler(this.maxUpgrade_CheckedChanged);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(4, 100);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(386, 26);
            this.searchBox.TabIndex = 16;
            this.searchBox.Click += new System.EventHandler(this.txtBonfireSearch_Click);
            this.searchBox.TextChanged += new System.EventHandler(this.txtBonfireSearch_TextChanged);
            this.searchBox.Enter += new System.EventHandler(this.txtBonfireSearch_Click);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // lbxItems
            // 
            this.lbxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.IntegralHeight = false;
            this.lbxItems.ItemHeight = 20;
            this.lbxItems.Location = new System.Drawing.Point(4, 132);
            this.lbxItems.Margin = new System.Windows.Forms.Padding(4);
            this.lbxItems.MinimumSize = new System.Drawing.Size(0, 24);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.ScrollAlwaysVisible = true;
            this.lbxItems.Size = new System.Drawing.Size(598, 304);
            this.lbxItems.TabIndex = 23;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
            this.lbxItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.lbxItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxItems_MouseDoubleClick);
            // 
            // nudUpgrade
            // 
            this.nudUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudUpgrade.Enabled = false;
            this.nudUpgrade.Location = new System.Drawing.Point(398, 71);
            this.nudUpgrade.Margin = new System.Windows.Forms.Padding(4);
            this.nudUpgrade.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudUpgrade.Name = "nudUpgrade";
            this.nudUpgrade.Size = new System.Drawing.Size(84, 26);
            this.nudUpgrade.TabIndex = 22;
            this.nudUpgrade.Click += new System.EventHandler(this.nudUpgrade_Click);
            this.nudUpgrade.Enter += new System.EventHandler(this.nudUpgrade_Click);
            // 
            // cmbInfusion
            // 
            this.cmbInfusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInfusion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfusion.DropDownWidth = 85;
            this.cmbInfusion.Enabled = false;
            this.cmbInfusion.FormattingEnabled = true;
            this.cmbInfusion.Location = new System.Drawing.Point(4, 70);
            this.cmbInfusion.Margin = new System.Windows.Forms.Padding(4);
            this.cmbInfusion.MaxDropDownItems = 100;
            this.cmbInfusion.MinimumSize = new System.Drawing.Size(90, 0);
            this.cmbInfusion.Name = "cmbInfusion";
            this.cmbInfusion.Size = new System.Drawing.Size(386, 28);
            this.cmbInfusion.TabIndex = 20;
            this.cmbInfusion.SelectedIndexChanged += new System.EventHandler(this.cmbInfusion_SelectedIndexChanged);
            this.cmbInfusion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.Enabled = false;
            this.nudQuantity.Location = new System.Drawing.Point(398, 22);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.nudQuantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(84, 26);
            this.nudQuantity.TabIndex = 18;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxQuantityRestrict
            // 
            this.cbxQuantityRestrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxQuantityRestrict.Checked = true;
            this.cbxQuantityRestrict.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxQuantityRestrict.Location = new System.Drawing.Point(490, 22);
            this.cbxQuantityRestrict.Margin = new System.Windows.Forms.Padding(4);
            this.cbxQuantityRestrict.Name = "cbxQuantityRestrict";
            this.cbxQuantityRestrict.Size = new System.Drawing.Size(96, 21);
            this.cbxQuantityRestrict.TabIndex = 25;
            this.cbxQuantityRestrict.Text = "Restrict";
            this.cbxQuantityRestrict.UseVisualStyleBackColor = true;
            this.cbxQuantityRestrict.CheckedChanged += new System.EventHandler(this.cbxQuantityRestrict_CheckedChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 85;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(4, 21);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.MaxDropDownItems = 100;
            this.cmbCategory.MinimumSize = new System.Drawing.Size(90, 0);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(386, 28);
            this.cmbCategory.TabIndex = 15;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // SearchAllCheckbox
            // 
            this.SearchAllCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchAllCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.SearchAllCheckbox.Location = new System.Drawing.Point(398, 100);
            this.SearchAllCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.SearchAllCheckbox.Name = "SearchAllCheckbox";
            this.SearchAllCheckbox.Size = new System.Drawing.Size(96, 21);
            this.SearchAllCheckbox.TabIndex = 29;
            this.SearchAllCheckbox.Text = "Search All";
            this.SearchAllCheckbox.UseVisualStyleBackColor = true;
            this.SearchAllCheckbox.CheckedChanged += new System.EventHandler(this.SearchAllCheckbox_CheckedChanged);
            // 
            // GadgetTabItems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(this.SearchAllCheckbox);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.maxUpgrade);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.lbxItems);
            this.Controls.Add(this.nudUpgrade);
            this.Controls.Add(lblUpgrade);
            this.Controls.Add(this.cmbInfusion);
            this.Controls.Add(lblInfusion);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.cbxQuantityRestrict);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(lblCategory);
            this.Name = "GadgetTabItems";
            this.Size = new System.Drawing.Size(606, 440);
            ((System.ComponentModel.ISupportInitialize)(this.nudUpgrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxItems;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown nudUpgrade;
        private System.Windows.Forms.ComboBox cmbInfusion;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.CheckBox cbxQuantityRestrict;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.CheckBox maxUpgrade;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox SearchAllCheckbox;
    }
}
