using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Bulk_File_Cleaver
{
    class FileInfoList
    {
        private DirectoryInfo currentDir { get; set; }
        private FileInfo[] fileList { get; set; }
        private int listSize { get; set; }

        public FileInfoList(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                currentDir = new DirectoryInfo(folderPath);
                fileList = currentDir.GetFiles("*", SearchOption.TopDirectoryOnly);
                listSize = fileList.Length;
            }
        }

        public void DisplayFiles(ref ListView view, ref ProgressBar progressView)
        {
            view.Clear();

            // Progress Bar setup
            progressView.Maximum = listSize;
            progressView.Step = 1;

            view.Columns.Add("Name", -2, HorizontalAlignment.Left);
            view.Columns.Add("Date", -2, HorizontalAlignment.Left);

            for (int i = 0; i < listSize; i++)
            {
                // Create new List Item with sub item 'date'
                ListViewItem Item = new ListViewItem(fileList[i].Name);
                Item.SubItems.Add(fileList[i].CreationTime.ToLongDateString());
                view.Items.Add(Item);

                progressView.PerformStep();
                progressView.Update();
            }

            // Resize columns
            foreach (ColumnHeader column in view.Columns)
            {
                column.Width = -2;
            }
        }

        public void RefreshData()
        {
            foreach (FileInfo file in fileList)
            {
                file.Refresh();
            }
        }

        public void RenameTo(FileInfoList newFiles)
        {
            for (int i = 0; i < listSize; i++)
            {
                fileList[i].MoveTo(newFiles.fileList[i].FullName);
            }
        }

        public void Sanitize(char[] removables)
        {
            // To convert to TitleCase
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < listSize; i++)
            {
                // Trim file name
                int extLen = fileList[i].Extension.Length;
                int namLen = fileList[i].Name.Length;
                string deconBuffer = fileList[i].Name.Remove(namLen - extLen);
                string conBuffer = "";

                string[] splitted = deconBuffer.Split(removables);
                foreach (string s in splitted)
                {
                    // Add the cleaned strings to a buffer
                    conBuffer += myTI.ToTitleCase(s) + " ";
                }
                // Remove the trailing whitespace and assign
                FileInfo newFileInfo = new FileInfo(currentDir.FullName + "\\" + conBuffer.Remove(conBuffer.Length - 1) + fileList[i].Extension);

                fileList[i] = newFileInfo;
            }
        }
    }
}
