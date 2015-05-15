using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Bulk_File_Cleaver
{
    public partial class homeForm : Form
    {
        /* Algorithmic Modules
         * RECOGNIZE NUMBERS: Adds recognized numerical value after the prefix value
         * SANITIZE: Removes underscores, brackets, etc and capitalizes each word
         *
         * */

        #region Global Vars

        public string[] AlgoList = new string[] { "Recognize Numbers", "Sanitize" };
        public int commitCount = -1;
        public DirectoryInfo dir;
        public string[] filesNameArray;
        public string folderPath;
        public char[] invalidSet = Path.GetInvalidFileNameChars();
        public FileInfo[] mainFileInfo;
        public int undoCount = 0;

        #endregion Global Vars

        public homeForm()
        {
            InitializeComponent();
        }

        private void AlgoDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AlgoDropDown.SelectedIndex)
            {
                case 0:
                    txtPrefix.Enabled = true;
                    btn_Preview.Enabled = false;
                    btn_Apply.Enabled = false;
                    break;

                case 1:

                    lbl_ValidityMsg.Text = "";
                    txtPrefix.Enabled = false;
                    btn_Preview.Enabled = true;
                    btn_Apply.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (AlgoDropDown.SelectedIndex == 0)
            {
                // ML module
            }
            else if (AlgoDropDown.SelectedIndex == 1)
            {
                ValidatePath();
                FileInfo[] newFileInfo = SanitizeFiles(mainFileInfo);
                Rename(newFileInfo);
                ValidatePath();

                lstFilesList.BackColor = Color.White;
                lbl_Msg.Text = "Operation Successful";
            }
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (AlgoDropDown.SelectedIndex == 0)
            {
                // ML module
            }
            else if (AlgoDropDown.SelectedIndex == 1)
            {
                FileInfo[] newFileInfo = SanitizeFiles(mainFileInfo);
                UpdateListView(newFileInfo);

                lstFilesList.BackColor = Color.LightSteelBlue;
            }
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
                    }

        private void homeForm_Load(object sender, EventArgs e)
        {
            // Configure objects
            lstFilesList.View = View.Details;
            lbl_Msg.Text = "";
            lbl_ValidityMsg.Text = "";
            AlgoDropDown.Items.AddRange(AlgoList);
            AlgoDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            AlgoDropDown.SelectedIndex = 0;

            // Disable components
            txtPrefix.Enabled = false;
            AlgoDropDown.Enabled = false;
            btn_Preview.Enabled = false;
            btn_Apply.Enabled = false;
        }

        private void Rename(FileInfo[] currentFileInfo)
        {
            for (int i = 0; i < currentFileInfo.Length; i++)
            {
                mainFileInfo[i].MoveTo(currentFileInfo[i].FullName);
            }
        }

        // Method updates ListView column size
        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        // Removes certain chars from the file name and converts to TitleCase
        private FileInfo[] SanitizeFiles(FileInfo[] currentFileInfo)
        {
            FileInfo[] newFileInfo = new FileInfo[currentFileInfo.Length];

            // Characters to remove
            char[] removables = new char[] { '.', '_', '-', ' ', '^','!','@','#','$','%','&','*','~','`','?'};

            // To convert to TitleCase
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < newFileInfo.Length; i++)
            {
                // Trim file name
                int extLen = currentFileInfo[i].Extension.Length;
                int namLen = currentFileInfo[i].Name.Length;
                string deconBuffer = currentFileInfo[i].Name.Remove(namLen - extLen);
                string conBuffer = "";

                string[] splitted = deconBuffer.Split(removables);
                foreach (string s in splitted)
                {
                    // Add the cleaned strings to a buffer
                    conBuffer += myTI.ToTitleCase(s) + " ";
                }
                // Remove the trailing whitespace and assign
                newFileInfo[i] = new FileInfo(folderPath + "\\" + conBuffer.Remove(conBuffer.Length - 1) + currentFileInfo[i].Extension);
            }
            return newFileInfo;
        }

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {
            folderPath = txtFolderPath.Text;
            ValidatePath();
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            int count = txtPrefix.Text.IndexOfAny(invalidSet);
            if (count > -1)
            {
                lbl_ValidityMsg.Text = "Invalid Name!";
                btn_Preview.Enabled = false;
                btn_Apply.Enabled = false;
            }
            else
            {
                lbl_ValidityMsg.Text = "";
                btn_Preview.Enabled = true;
                btn_Apply.Enabled = true;
            }
        }

        private void btn_BrowserDialog_Click(object sender, EventArgs e)
        {
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = browserDialog.SelectedPath;
            }
        }

        // Method update the listView with the current files
        private void UpdateListView(FileInfo[] currentFileInfo)
        {
            lstFilesList.Clear();

            // Progress Bar setup
            barPathLoading.Maximum = currentFileInfo.Length;
            barPathLoading.Step = 1;

            lstFilesList.Columns.Add("Name", -2, HorizontalAlignment.Left);
            lstFilesList.Columns.Add("Date", -2, HorizontalAlignment.Left);

            for (int i = 0; i < currentFileInfo.Length; i++)
            {
                // Create new List Item with sub item 'date'
                ListViewItem ItemName = new ListViewItem(currentFileInfo[i].Name);
                ItemName.SubItems.Add(currentFileInfo[i].CreationTime.ToLongDateString());

                // Add into listView
                lstFilesList.Items.Add(ItemName);

                // Update Progress Bar
                barPathLoading.PerformStep();
                barPathLoading.Update();
            }
            ResizeListViewColumns(lstFilesList);
        }

        // Validates folder path and loads file structure into vars
        private void ValidatePath()
        {
            if (Directory.Exists(folderPath))
            {
                // Loads mainFileInfo from the actual directory
                dir = new DirectoryInfo(folderPath);
                mainFileInfo = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

                // Update the listView
                UpdateListView(mainFileInfo);

                // Update components
                lbl_Msg.Text = "Files found";
                AlgoDropDown.Enabled = true;
                txtPrefix.Enabled = true;
                btn_Preview.Enabled = true;
                btn_Apply.Enabled = true;
            }
            else
            {
                lbl_Msg.Text = "";
                AlgoDropDown.Enabled = false;
                txtPrefix.Enabled = false;
                btn_Apply.Enabled = false;
                btn_Preview.Enabled = false;
            }
        }

    }
}