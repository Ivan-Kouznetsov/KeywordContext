namespace NalpMark
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.DateType = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFrom = new System.Windows.Forms.Label();
            this.checkedListBoxClasses = new System.Windows.Forms.CheckedListBox();
            this.groupBoxClasses = new System.Windows.Forms.GroupBox();
            this.buttonSelectNoClasses = new System.Windows.Forms.Button();
            this.buttonSelectAllClasses = new System.Windows.Forms.Button();
            this.labelSearchKeyword = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listViewWords = new System.Windows.Forms.ListView();
            this.columnWords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.listViewExampleFragments = new System.Windows.Forms.ListView();
            this.columnHeaderFragments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelMaxNearWords = new System.Windows.Forms.Label();
            this.labelMaxResultsShow = new System.Windows.Forms.Label();
            this.labelMaximumRecordsToSearch = new System.Windows.Forms.Label();
            this.numericUpDownMaxWordsAround = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxRecordsShow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSelectLimit = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatusLabelFilename = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxClasses.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWordsAround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecordsShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(874, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(193, 65);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(139, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(386, 65);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(141, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(349, 69);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(20, 13);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "To";
            // 
            // DateType
            // 
            this.DateType.FormattingEnabled = true;
            this.DateType.Items.AddRange(new object[] {
            "Filing Date",
            "Registration Date"});
            this.DateType.Location = new System.Drawing.Point(10, 64);
            this.DateType.MaxDropDownItems = 2;
            this.DateType.Name = "DateType";
            this.DateType.Size = new System.Drawing.Size(129, 21);
            this.DateType.TabIndex = 5;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelFilename});
            this.statusStrip.Location = new System.Drawing.Point(0, 501);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(874, 22);
            this.statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(150, 69);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(30, 13);
            this.labelFrom.TabIndex = 7;
            this.labelFrom.Text = "From";
            // 
            // checkedListBoxClasses
            // 
            this.checkedListBoxClasses.CheckOnClick = true;
            this.checkedListBoxClasses.FormattingEnabled = true;
            this.checkedListBoxClasses.Items.AddRange(new object[] {
            "01 Chemicals",
            "02 Paints",
            "03 Cleaning Substances",
            "04 Industrial Oils",
            "05 Pharmaceuticals",
            "06 Common Metals",
            "07 Machines",
            "08 Hand Tools",
            "09 Computers and Scientific Devices",
            "10 Medical Supplies",
            "11 Appliances",
            "12 Vehicles",
            "13 Firearms",
            "14 Precious Metals",
            "15 Musical Instruments",
            "16 Paper Goods",
            "17 Rubber Products",
            "18 Leather Goods",
            "19 Building Materials",
            "20 Furniture",
            "21 Household Utensils",
            "22 Ropes and Textile Products",
            "23 Yarns and Threads",
            "24 Textiles",
            "25 Clothing",
            "26 Lace and Embroidery",
            "27 Carpets",
            "28 Games and Sporting Goods",
            "29 Meat, Fish, Poultry",
            "30 Coffee, Flour, Rice",
            "31 Grains, Agriculture",
            "32 Beers and Beverages",
            "33 Alcoholic Beverages",
            "34 Tobacco Products",
            "35 Advertising and Business Services",
            "36 Insurance and Finance Services",
            "37 Construction and Repair Services",
            "38 Telecommunications Services",
            "39 Shipping and Travel Services",
            "40 Material Treatment Services",
            "41 Education and Entertainment Services",
            "42 Science and Technology Services",
            "43 Food Services",
            "44 Medical and Vet Services",
            "45 Legal and Security Services"});
            this.checkedListBoxClasses.Location = new System.Drawing.Point(6, 49);
            this.checkedListBoxClasses.Name = "checkedListBoxClasses";
            this.checkedListBoxClasses.Size = new System.Drawing.Size(241, 419);
            this.checkedListBoxClasses.TabIndex = 8;
            // 
            // groupBoxClasses
            // 
            this.groupBoxClasses.Controls.Add(this.buttonSelectNoClasses);
            this.groupBoxClasses.Controls.Add(this.buttonSelectAllClasses);
            this.groupBoxClasses.Controls.Add(this.checkedListBoxClasses);
            this.groupBoxClasses.Location = new System.Drawing.Point(620, 33);
            this.groupBoxClasses.Name = "groupBoxClasses";
            this.groupBoxClasses.Size = new System.Drawing.Size(253, 465);
            this.groupBoxClasses.TabIndex = 9;
            this.groupBoxClasses.TabStop = false;
            this.groupBoxClasses.Text = "Classes";
            // 
            // buttonSelectNoClasses
            // 
            this.buttonSelectNoClasses.Location = new System.Drawing.Point(88, 20);
            this.buttonSelectNoClasses.Name = "buttonSelectNoClasses";
            this.buttonSelectNoClasses.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectNoClasses.TabIndex = 10;
            this.buttonSelectNoClasses.Text = "Select None";
            this.buttonSelectNoClasses.UseVisualStyleBackColor = true;
            this.buttonSelectNoClasses.Click += new System.EventHandler(this.ButtonSelectNoClasses_Click);
            // 
            // buttonSelectAllClasses
            // 
            this.buttonSelectAllClasses.Location = new System.Drawing.Point(6, 20);
            this.buttonSelectAllClasses.Name = "buttonSelectAllClasses";
            this.buttonSelectAllClasses.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAllClasses.TabIndex = 9;
            this.buttonSelectAllClasses.Text = "Select All";
            this.buttonSelectAllClasses.UseVisualStyleBackColor = true;
            this.buttonSelectAllClasses.Click += new System.EventHandler(this.ButtonSelectAllClasses_Click);
            // 
            // labelSearchKeyword
            // 
            this.labelSearchKeyword.AutoSize = true;
            this.labelSearchKeyword.Location = new System.Drawing.Point(8, 42);
            this.labelSearchKeyword.Name = "labelSearchKeyword";
            this.labelSearchKeyword.Size = new System.Drawing.Size(88, 13);
            this.labelSearchKeyword.TabIndex = 10;
            this.labelSearchKeyword.Text = "Search Keyword:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(102, 39);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(425, 20);
            this.textBoxSearch.TabIndex = 11;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(533, 38);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // listViewWords
            // 
            this.listViewWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWords});
            this.listViewWords.Location = new System.Drawing.Point(6, 18);
            this.listViewWords.Name = "listViewWords";
            this.listViewWords.Size = new System.Drawing.Size(589, 163);
            this.listViewWords.TabIndex = 13;
            this.listViewWords.UseCompatibleStateImageBehavior = false;
            this.listViewWords.View = System.Windows.Forms.View.Details;
            // 
            // columnWords
            // 
            this.columnWords.Text = "Words That Appear Frequently Near Keyword";
            this.columnWords.Width = 587;
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.listViewExampleFragments);
            this.groupBoxResults.Controls.Add(this.listViewWords);
            this.groupBoxResults.Location = new System.Drawing.Point(7, 119);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(601, 379);
            this.groupBoxResults.TabIndex = 14;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Search Results";
            // 
            // listViewExampleFragments
            // 
            this.listViewExampleFragments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFragments});
            this.listViewExampleFragments.Location = new System.Drawing.Point(7, 188);
            this.listViewExampleFragments.Name = "listViewExampleFragments";
            this.listViewExampleFragments.Size = new System.Drawing.Size(588, 184);
            this.listViewExampleFragments.TabIndex = 14;
            this.listViewExampleFragments.UseCompatibleStateImageBehavior = false;
            this.listViewExampleFragments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFragments
            // 
            this.columnHeaderFragments.Text = "Common Usage Examples";
            this.columnHeaderFragments.Width = 587;
            // 
            // labelMaxNearWords
            // 
            this.labelMaxNearWords.AutoSize = true;
            this.labelMaxNearWords.Location = new System.Drawing.Point(7, 95);
            this.labelMaxNearWords.Name = "labelMaxNearWords";
            this.labelMaxNearWords.Size = new System.Drawing.Size(125, 13);
            this.labelMaxNearWords.TabIndex = 15;
            this.labelMaxNearWords.Text = "Maximum Words Around:";
            // 
            // labelMaxResultsShow
            // 
            this.labelMaxResultsShow.AutoSize = true;
            this.labelMaxResultsShow.Location = new System.Drawing.Point(424, 97);
            this.labelMaxResultsShow.Name = "labelMaxResultsShow";
            this.labelMaxResultsShow.Size = new System.Drawing.Size(92, 13);
            this.labelMaxResultsShow.TabIndex = 16;
            this.labelMaxResultsShow.Text = "Maximum Results:";
            // 
            // labelMaximumRecordsToSearch
            // 
            this.labelMaximumRecordsToSearch.AutoSize = true;
            this.labelMaximumRecordsToSearch.Location = new System.Drawing.Point(207, 97);
            this.labelMaximumRecordsToSearch.Name = "labelMaximumRecordsToSearch";
            this.labelMaximumRecordsToSearch.Size = new System.Drawing.Size(139, 13);
            this.labelMaximumRecordsToSearch.TabIndex = 17;
            this.labelMaximumRecordsToSearch.Text = "Maximum Records To View:";
            // 
            // numericUpDownMaxWordsAround
            // 
            this.numericUpDownMaxWordsAround.Location = new System.Drawing.Point(142, 93);
            this.numericUpDownMaxWordsAround.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownMaxWordsAround.Name = "numericUpDownMaxWordsAround";
            this.numericUpDownMaxWordsAround.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownMaxWordsAround.TabIndex = 14;
            this.numericUpDownMaxWordsAround.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownMaxRecordsShow
            // 
            this.numericUpDownMaxRecordsShow.Location = new System.Drawing.Point(363, 94);
            this.numericUpDownMaxRecordsShow.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaxRecordsShow.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMaxRecordsShow.Name = "numericUpDownMaxRecordsShow";
            this.numericUpDownMaxRecordsShow.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownMaxRecordsShow.TabIndex = 18;
            this.numericUpDownMaxRecordsShow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownSelectLimit
            // 
            this.numericUpDownSelectLimit.Location = new System.Drawing.Point(522, 95);
            this.numericUpDownSelectLimit.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDownSelectLimit.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSelectLimit.Name = "numericUpDownSelectLimit";
            this.numericUpDownSelectLimit.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownSelectLimit.TabIndex = 19;
            this.numericUpDownSelectLimit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "uspto_archive_2019.sqlite";
            this.openFileDialog.Filter = "SQLite Database|*sqlite|All files|*.*";
            this.openFileDialog.InitialDirectory = @"SampleData\";
            // 
            // toolStripStatusLabelFilename
            // 
            this.toolStripStatusLabelFilename.Name = "toolStripStatusLabelFilename";
            this.toolStripStatusLabelFilename.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 523);
            this.Controls.Add(this.numericUpDownSelectLimit);
            this.Controls.Add(this.numericUpDownMaxRecordsShow);
            this.Controls.Add(this.numericUpDownMaxWordsAround);
            this.Controls.Add(this.labelMaximumRecordsToSearch);
            this.Controls.Add(this.labelMaxResultsShow);
            this.Controls.Add(this.labelMaxNearWords);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearchKeyword);
            this.Controls.Add(this.groupBoxClasses);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.DateType);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NalpMark";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxClasses.ResumeLayout(false);
            this.groupBoxResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWordsAround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecordsShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.ComboBox DateType;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.CheckedListBox checkedListBoxClasses;
        private System.Windows.Forms.GroupBox groupBoxClasses;
        private System.Windows.Forms.Button buttonSelectNoClasses;
        private System.Windows.Forms.Button buttonSelectAllClasses;
        private System.Windows.Forms.Label labelSearchKeyword;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView listViewWords;
        private System.Windows.Forms.ColumnHeader columnWords;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelMaxNearWords;
        private System.Windows.Forms.Label labelMaxResultsShow;
        private System.Windows.Forms.Label labelMaximumRecordsToSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxWordsAround;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRecordsShow;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectLimit;
        private System.Windows.Forms.ListView listViewExampleFragments;
        private System.Windows.Forms.ColumnHeader columnHeaderFragments;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilename;
    }
}

