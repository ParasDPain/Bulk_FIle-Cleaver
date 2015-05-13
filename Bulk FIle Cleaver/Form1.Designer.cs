namespace Bulk_FIle_Cleaver
{
    partial class homeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(homeForm));
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lbl_FolderPath = new System.Windows.Forms.Label();
            this.lstFilesList = new System.Windows.Forms.ListView();
            this.barPathLoading = new System.Windows.Forms.ProgressBar();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.AlgoDropDown = new System.Windows.Forms.ComboBox();
            this.lbl_AlgoSelecter = new System.Windows.Forms.Label();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.lbl_ValidityMsg = new System.Windows.Forms.Label();
            this.btn_Undo = new System.Windows.Forms.Button();
            this.btn_Redo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFolderPath.Location = new System.Drawing.Point(79, 30);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(310, 20);
            this.txtFolderPath.TabIndex = 0;
            this.txtFolderPath.TextChanged += new System.EventHandler(this.txtFolderPath_TextChanged);
            // 
            // lbl_FolderPath
            // 
            this.lbl_FolderPath.AutoSize = true;
            this.lbl_FolderPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_FolderPath.Location = new System.Drawing.Point(12, 33);
            this.lbl_FolderPath.Name = "lbl_FolderPath";
            this.lbl_FolderPath.Size = new System.Drawing.Size(61, 13);
            this.lbl_FolderPath.TabIndex = 1;
            this.lbl_FolderPath.Text = "Folder Path";
            // 
            // lstFilesList
            // 
            this.lstFilesList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstFilesList.GridLines = true;
            this.lstFilesList.Location = new System.Drawing.Point(79, 59);
            this.lstFilesList.MultiSelect = false;
            this.lstFilesList.Name = "lstFilesList";
            this.lstFilesList.Size = new System.Drawing.Size(310, 248);
            this.lstFilesList.TabIndex = 2;
            this.lstFilesList.UseCompatibleStateImageBehavior = false;
            // 
            // barPathLoading
            // 
            this.barPathLoading.Cursor = System.Windows.Forms.Cursors.Default;
            this.barPathLoading.Location = new System.Drawing.Point(79, 33);
            this.barPathLoading.Name = "barPathLoading";
            this.barPathLoading.Size = new System.Drawing.Size(310, 30);
            this.barPathLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barPathLoading.TabIndex = 3;
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.AutoSize = true;
            this.lbl_Msg.Location = new System.Drawing.Point(76, 310);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(86, 13);
            this.lbl_Msg.TabIndex = 4;
            this.lbl_Msg.Text = "Operation Status";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(412, 60);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(33, 13);
            this.lbl_Name.TabIndex = 5;
            this.lbl_Name.Text = "Prefix";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(451, 58);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(121, 20);
            this.txtPrefix.TabIndex = 6;
            this.txtPrefix.TextChanged += new System.EventHandler(this.txtPrefix_TextChanged);
            // 
            // AlgoDropDown
            // 
            this.AlgoDropDown.FormattingEnabled = true;
            this.AlgoDropDown.Location = new System.Drawing.Point(451, 31);
            this.AlgoDropDown.Name = "AlgoDropDown";
            this.AlgoDropDown.Size = new System.Drawing.Size(121, 21);
            this.AlgoDropDown.TabIndex = 7;
            this.AlgoDropDown.SelectedIndexChanged += new System.EventHandler(this.AlgoDropDown_SelectedIndexChanged);
            // 
            // lbl_AlgoSelecter
            // 
            this.lbl_AlgoSelecter.AutoSize = true;
            this.lbl_AlgoSelecter.Location = new System.Drawing.Point(405, 34);
            this.lbl_AlgoSelecter.Name = "lbl_AlgoSelecter";
            this.lbl_AlgoSelecter.Size = new System.Drawing.Size(42, 13);
            this.lbl_AlgoSelecter.TabIndex = 8;
            this.lbl_AlgoSelecter.Text = "Module";
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(472, 247);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(100, 27);
            this.btn_Preview.TabIndex = 9;
            this.btn_Preview.Text = "Preview";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(472, 280);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(100, 27);
            this.btn_Apply.TabIndex = 10;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // lbl_ValidityMsg
            // 
            this.lbl_ValidityMsg.AutoSize = true;
            this.lbl_ValidityMsg.Location = new System.Drawing.Point(451, 85);
            this.lbl_ValidityMsg.Name = "lbl_ValidityMsg";
            this.lbl_ValidityMsg.Size = new System.Drawing.Size(86, 13);
            this.lbl_ValidityMsg.TabIndex = 11;
            this.lbl_ValidityMsg.Text = "Validity Message";
            // 
            // btn_Undo
            // 
            this.btn_Undo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Undo.BackgroundImage")));
            this.btn_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Undo.FlatAppearance.BorderSize = 0;
            this.btn_Undo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Undo.Location = new System.Drawing.Point(35, 148);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(22, 23);
            this.btn_Undo.TabIndex = 12;
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_Redo
            // 
            this.btn_Redo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Redo.BackgroundImage")));
            this.btn_Redo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Redo.FlatAppearance.BorderSize = 0;
            this.btn_Redo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Redo.Location = new System.Drawing.Point(35, 188);
            this.btn_Redo.Name = "btn_Redo";
            this.btn_Redo.Size = new System.Drawing.Size(22, 23);
            this.btn_Redo.TabIndex = 13;
            this.btn_Redo.UseVisualStyleBackColor = true;
            this.btn_Redo.Click += new System.EventHandler(this.btn_Redo_Click);
            // 
            // homeForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 351);
            this.Controls.Add(this.btn_Redo);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_ValidityMsg);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.lbl_AlgoSelecter);
            this.Controls.Add(this.AlgoDropDown);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Msg);
            this.Controls.Add(this.lstFilesList);
            this.Controls.Add(this.lbl_FolderPath);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.barPathLoading);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.Name = "homeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Cleaver 2.0";
            this.Load += new System.EventHandler(this.homeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lbl_FolderPath;
        private System.Windows.Forms.ListView lstFilesList;
        private System.Windows.Forms.ProgressBar barPathLoading;
        private System.Windows.Forms.Label lbl_Msg;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.ComboBox AlgoDropDown;
        private System.Windows.Forms.Label lbl_AlgoSelecter;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Label lbl_ValidityMsg;
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Button btn_Redo;
    }
}

