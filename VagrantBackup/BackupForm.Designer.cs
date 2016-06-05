namespace VagrantBackup
{
    partial class BackupForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupForm));
            this.btnClearSelected = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgBrowseFolders = new System.Windows.Forms.FolderBrowserDialog();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.txtProjectFolder = new System.Windows.Forms.TextBox();
            this.lblProjectFolder = new System.Windows.Forms.Label();
            this.btnBrowseProjectFolder = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.clbFileList = new System.Windows.Forms.CheckedListBox();
            this.lblAdditional = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbProvisioner = new System.Windows.Forms.GroupBox();
            this.lblProvisioner = new System.Windows.Forms.Label();
            this.bwBackup = new System.ComponentModel.BackgroundWorker();
            this.gbGeneral.SuspendLayout();
            this.gbProvisioner.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearSelected
            // 
            this.btnClearSelected.Enabled = false;
            this.btnClearSelected.Location = new System.Drawing.Point(290, 320);
            this.btnClearSelected.Name = "btnClearSelected";
            this.btnClearSelected.Size = new System.Drawing.Size(95, 23);
            this.btnClearSelected.TabIndex = 1;
            this.btnClearSelected.Text = "Clear selected";
            this.btnClearSelected.UseVisualStyleBackColor = true;
            this.btnClearSelected.Click += new System.EventHandler(this.btnClearSelected_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Backup files|*.backup";
            this.dlgSave.Title = "Select destination for your backup file...";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 528);
            this.pbProgress.MarqueeAnimationSpeed = 25;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(879, 34);
            this.pbProgress.TabIndex = 3;
            // 
            // txtProjectFolder
            // 
            this.txtProjectFolder.Location = new System.Drawing.Point(12, 29);
            this.txtProjectFolder.Name = "txtProjectFolder";
            this.txtProjectFolder.ReadOnly = true;
            this.txtProjectFolder.Size = new System.Drawing.Size(830, 22);
            this.txtProjectFolder.TabIndex = 5;
            // 
            // lblProjectFolder
            // 
            this.lblProjectFolder.AutoSize = true;
            this.lblProjectFolder.Location = new System.Drawing.Point(9, 9);
            this.lblProjectFolder.Name = "lblProjectFolder";
            this.lblProjectFolder.Size = new System.Drawing.Size(100, 17);
            this.lblProjectFolder.TabIndex = 6;
            this.lblProjectFolder.Text = "Project Folder:";
            // 
            // btnBrowseProjectFolder
            // 
            this.btnBrowseProjectFolder.Location = new System.Drawing.Point(848, 29);
            this.btnBrowseProjectFolder.Name = "btnBrowseProjectFolder";
            this.btnBrowseProjectFolder.Size = new System.Drawing.Size(43, 23);
            this.btnBrowseProjectFolder.TabIndex = 7;
            this.btnBrowseProjectFolder.Text = "...";
            this.btnBrowseProjectFolder.UseVisualStyleBackColor = true;
            this.btnBrowseProjectFolder.Click += new System.EventHandler(this.btnBrowseProjectFolder_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Enabled = false;
            this.btnBackup.Location = new System.Drawing.Point(12, 582);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(234, 49);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(712, 582);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(179, 49);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // clbFileList
            // 
            this.clbFileList.Enabled = false;
            this.clbFileList.FormattingEnabled = true;
            this.clbFileList.Location = new System.Drawing.Point(6, 21);
            this.clbFileList.Name = "clbFileList";
            this.clbFileList.Size = new System.Drawing.Size(379, 293);
            this.clbFileList.TabIndex = 10;
            this.clbFileList.SelectedIndexChanged += new System.EventHandler(this.clbFileList_SelectedIndexChanged);
            // 
            // lblAdditional
            // 
            this.lblAdditional.AutoSize = true;
            this.lblAdditional.Location = new System.Drawing.Point(12, 142);
            this.lblAdditional.Name = "lblAdditional";
            this.lblAdditional.Size = new System.Drawing.Size(162, 17);
            this.lblAdditional.TabIndex = 11;
            this.lblAdditional.Text = "Additional Backup Items:";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Enabled = false;
            this.btnAddFile.Location = new System.Drawing.Point(6, 320);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(95, 23);
            this.btnAddFile.TabIndex = 12;
            this.btnAddFile.Text = "Add File...";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Enabled = false;
            this.btnAddFolder.Location = new System.Drawing.Point(111, 320);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(120, 23);
            this.btnAddFolder.TabIndex = 13;
            this.btnAddFolder.Text = "Add Folder...";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(10, 508);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(101, 17);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.Text = "Status: Ready.";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.clbFileList);
            this.gbGeneral.Controls.Add(this.btnClearSelected);
            this.gbGeneral.Controls.Add(this.btnAddFolder);
            this.gbGeneral.Controls.Add(this.btnAddFile);
            this.gbGeneral.Location = new System.Drawing.Point(15, 72);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(404, 349);
            this.gbGeneral.TabIndex = 16;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Additional Files";
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(848, 462);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(43, 23);
            this.btnBrowseDestination.TabIndex = 19;
            this.btnBrowseDestination.Text = "...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(15, 462);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(827, 22);
            this.txtDestination.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Destination Backup File";
            // 
            // gbProvisioner
            // 
            this.gbProvisioner.Controls.Add(this.lblProvisioner);
            this.gbProvisioner.Location = new System.Drawing.Point(436, 72);
            this.gbProvisioner.Name = "gbProvisioner";
            this.gbProvisioner.Size = new System.Drawing.Size(455, 349);
            this.gbProvisioner.TabIndex = 20;
            this.gbProvisioner.TabStop = false;
            this.gbProvisioner.Text = "Provisioner";
            // 
            // lblProvisioner
            // 
            this.lblProvisioner.AutoSize = true;
            this.lblProvisioner.Location = new System.Drawing.Point(18, 35);
            this.lblProvisioner.Name = "lblProvisioner";
            this.lblProvisioner.Size = new System.Drawing.Size(167, 17);
            this.lblProvisioner.TabIndex = 0;
            this.lblProvisioner.Text = "Waiting for project data...";
            // 
            // bwBackup
            // 
            this.bwBackup.WorkerReportsProgress = true;
            this.bwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwBackup_DoWork);
            this.bwBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwBackup_ProgressChanged);
            this.bwBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwBackup_RunWorkerCompleted);
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 643);
            this.Controls.Add(this.gbProvisioner);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblAdditional);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnBrowseProjectFolder);
            this.Controls.Add(this.lblProjectFolder);
            this.Controls.Add(this.txtProjectFolder);
            this.Controls.Add(this.pbProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup Vagrant";
            this.gbGeneral.ResumeLayout(false);
            this.gbProvisioner.ResumeLayout(false);
            this.gbProvisioner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearSelected;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowseFolders;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.TextBox txtProjectFolder;
        private System.Windows.Forms.Label lblProjectFolder;
        private System.Windows.Forms.Button btnBrowseProjectFolder;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckedListBox clbFileList;
        private System.Windows.Forms.Label lblAdditional;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbProvisioner;
        private System.ComponentModel.BackgroundWorker bwBackup;
        private System.Windows.Forms.Label lblProvisioner;
    }
}