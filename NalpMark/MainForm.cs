using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KeywordContext.Models;
using NalpMark.Sevices;
using NalpMark.Models;

namespace NalpMark
{
    public partial class MainForm : Form
    {
        private string databaseFilepath = "";
        const int ColumnWidth = 567;
        private (List<CountedWord> ImportantWords, List<SentenceFragment> ExampleFragments) results = (new List<CountedWord>(), new List<SentenceFragment>());
        public MainForm()
        {
            InitializeComponent();
        }

        private void ListViewWords_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ColumnWidth;
        }

        private void ListViewExampleFragments_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ColumnWidth;
        }

        private void SelectAllClasses()
        {
            for (int i = 0; i < checkedListBoxClasses.Items.Count; i++)
            {
                checkedListBoxClasses.SetItemChecked(i, true);
            }
        }

        private void ButtonSelectAllClasses_Click(object sender, EventArgs e)
        {
            SelectAllClasses();
        }

        private void ButtonSelectNoClasses_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxClasses.Items.Count; i++)
            {
                checkedListBoxClasses.SetItemChecked(i, false);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.ShowDialog();
        }

        private void OpenDatabaseFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                databaseFilepath = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Please select a database", "Select a file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabaseFile();
        }

        private List<int> GetSelectedClasses()
        {
            List<int> results = new List<int>();

            for (int i = 0; i < checkedListBoxClasses.Items.Count; i++)
            {
                if (checkedListBoxClasses.CheckedItems.Contains(checkedListBoxClasses.Items[i]))
                {
                    results.Add(i + 1);
                }
            }

            return results;
        }

        private void ToggleForm(bool working)
        {
            toolStripStatusLabel.Text = working ? "Working..." : "Ready";
            dateTimePickerFrom.Enabled = !working;
            dateTimePickerTo.Enabled = !working;
            DateType.Enabled = !working;
            checkedListBoxClasses.Enabled = !working;
            buttonSelectNoClasses.Enabled = !working;
            buttonSelectAllClasses.Enabled = !working;
            textBoxSearch.Enabled = !working;
            buttonSearch.Enabled = !working;
            listViewWords.Enabled = !working;
            listViewExampleFragments.Enabled = !working;

            numericUpDownMaxRecordsShow.Enabled = !working;
            numericUpDownMaxWordsAround.Enabled = !working;
            numericUpDownSelectLimit.Enabled = !working;
        }

        private bool ValidateInputs()
        {

            if (databaseFilepath == "")
            {
                MessageBox.Show("Please select a database file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (GetSelectedClasses().Count == 0)
            {
                MessageBox.Show("Please select at least one class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxSearch.Text.Length == 0)
            {
                MessageBox.Show("Please enter a keyword", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            listViewWords.Items.Clear();
            listViewExampleFragments.Items.Clear();

            ToggleForm(true);

            string keyword = textBoxSearch.Text;
            int maxWordsAround = (int)numericUpDownMaxWordsAround.Value;
            int resultsLimit = (int)numericUpDownMaxRecordsShow.Value;
            bool useFilingDate = DateType.SelectedItem.ToString() == "Filing Date";
            DateTime from = dateTimePickerFrom.Value;
            DateTime to = dateTimePickerTo.Value;
            List<int> classes = GetSelectedClasses();
            string fileLocation = databaseFilepath;
            int limit = (int)numericUpDownSelectLimit.Value;
           


            try
            {
                await Task.Run(() => {results = SearchService.Search(databaseFilepath,from,to,classes,keyword,limit, useFilingDate,maxWordsAround,resultsLimit);});

                for (int i = 0; i < results.ImportantWords.Count; i++)
                {
                    listViewWords.Items.Add(results.ImportantWords[i].Word.FullWord);
                }

                for (int i = 0; i < results.ExampleFragments.Count; i++)
                {
                    listViewExampleFragments.Items.Add(results.ExampleFragments[i].ToString());
                }

                if ((results.ImportantWords.Count + results.ExampleFragments.Count) == 0)
                {
                    MessageBox.Show("No results found");
                }

                listViewWords.Columns[0].Width = ColumnWidth;
                listViewExampleFragments.Columns[0].Width = ColumnWidth;
            }
            catch
            {
                MessageBox.Show("Error reading from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ToggleForm(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateType.DropDownStyle = ComboBoxStyle.DropDownList;
            DateType.SelectedIndex = 0;

            listViewExampleFragments.ColumnWidthChanging += ListViewExampleFragments_ColumnWidthChanging;
            listViewWords.ColumnWidthChanging += ListViewWords_ColumnWidthChanging;
            SelectAllClasses();
            dateTimePickerFrom.Value = DateTime.Parse("Jan 1 1800");
            dateTimePickerTo.Value = DateTime.Now;
        }

        private void ExportWordCloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (results.ImportantWords.Count == 0) {
                MessageBox.Show("There are no results to export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            WordCloud wordCloud = new WordCloud();

            foreach (CountedWord countedWord in results.ImportantWords)
            {
                wordCloud.AddWord(countedWord.Word.FullWord, countedWord.Count);
            }
            
            WordCloudExportService.Show(wordCloud, textBoxSearch.Text);           
        }
    }
}
