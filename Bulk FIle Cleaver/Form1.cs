using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DejaVu;

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
        public char[] removables = new char[] { '.', '_', '-', ' ', '^', '!', '@', '#', '$', '%', '&', '*', '~', '`', '?' };

        private readonly UndoRedo<FileInfoList> mainFileList = new UndoRedo<FileInfoList>();
        internal FileInfoList MainFileList
        {
            get { return mainFileList.Value; }
            set { mainFileList.Value = value; }
        }


        public string folderPath;
        public char[] invalidSet = Path.GetInvalidFileNameChars();

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
                using (UndoRedoManager.Start("Rename"))
                {
                    // Check files
                    MainFileList = new FileInfoList(folderPath);
                    MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);

                    UndoRedoManager.Commit();
                } 
                
                using (UndoRedoManager.Start("Rename"))
                {
                    // Record data point
                    FileInfoList oldFiles = new FileInfoList(folderPath);

                    // Sanitize
                    MainFileList.Sanitize(removables);

                    // Rename and assign
                    oldFiles.RenameTo(MainFileList);
                    MainFileList = oldFiles;

                    MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);

                    UndoRedoManager.Commit();
                }

                lstFilesList.BackColor = Color.White;
                lbl_Msg.Text = "Operation Successful";
            }
        }

        // Invalid state exception for some reason :/
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (AlgoDropDown.SelectedIndex == 0)
            {
                // ML module
            }
            else if (AlgoDropDown.SelectedIndex == 1)
            {
                using (UndoRedoManager.StartInvisible("Rename"))
                {
                    // Check data
                    MainFileList = new FileInfoList(folderPath);
                    MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);

                    UndoRedoManager.Commit();
                }

                using (UndoRedoManager.StartInvisible("Rename"))
                {
                    // Sanitize and display
                    MainFileList.Sanitize(removables);
                    MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);
                    
                    UndoRedoManager.Commit();
                }

                lstFilesList.BackColor = Color.LightSteelBlue;
            }
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            // Record data point
            FileInfoList oldFiles = new FileInfoList(folderPath);

            if (UndoRedoManager.CanRedo)
            {
                UndoRedoManager.Redo();
                oldFiles.RenameTo(MainFileList);
                MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);
            }
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            // Record data point
            FileInfoList oldFiles = new FileInfoList(folderPath);

            if (UndoRedoManager.CanUndo)
            {
                UndoRedoManager.Undo();
                oldFiles.RenameTo(MainFileList);
                MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);
            }
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

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {
            folderPath = txtFolderPath.Text;
            if (Directory.Exists(folderPath))
            {
                using (UndoRedoManager.StartInvisible("Rename"))
                {
                    MainFileList = new FileInfoList(folderPath);
                    UndoRedoManager.Commit();
                }
                MainFileList.DisplayFiles(ref lstFilesList, ref barPathLoading);

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
    }
}