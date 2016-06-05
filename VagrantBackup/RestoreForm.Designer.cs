namespace VagrantBackup
{
    partial class RestoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackupFile = new System.Windows.Forms.Button();
            this.txtProjectFolder = new System.Windows.Forms.TextBox();
            this.lblProjectFolder = new System.Windows.Forms.Label();
            this.btnBrowseProjectFolder = new System.Windows.Forms.Button();
            this.bwRestore = new System.ComponentModel.BackgroundWorker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup File";
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Location = new System.Drawing.Point(21, 28);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.ReadOnly = true;
            this.txtBackupFile.Size = new System.Drawing.Size(415, 22);
            this.txtBackupFile.TabIndex = 1;
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(21, 260);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(171, 50);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackupFile
            // 
            this.btnBackupFile.Location = new System.Drawing.Point(442, 27);
            this.btnBackupFile.Name = "btnBackupFile";
            this.btnBackupFile.Size = new System.Drawing.Size(43, 23);
            this.btnBackupFile.TabIndex = 3;
            this.btnBackupFile.Text = "...";
            this.btnBackupFile.UseVisualStyleBackColor = true;
            this.btnBackupFile.Click += new System.EventHandler(this.btnBackupFile_Click);
            // 
            // txtProjectFolder
            // 
            this.txtProjectFolder.Location = new System.Drawing.Point(21, 97);
            this.txtProjectFolder.Name = "txtProjectFolder";
            this.txtProjectFolder.ReadOnly = true;
            this.txtProjectFolder.Size = new System.Drawing.Size(415, 22);
            this.txtProjectFolder.TabIndex = 5;
            // 
            // lblProjectFolder
            // 
            this.lblProjectFolder.AutoSize = true;
            this.lblProjectFolder.Location = new System.Drawing.Point(18, 77);
            this.lblProjectFolder.Name = "lblProjectFolder";
            this.lblProjectFolder.Size = new System.Drawing.Size(96, 17);
            this.lblProjectFolder.TabIndex = 4;
            this.lblProjectFolder.Text = "Project Folder";
            // 
            // btnBrowseProjectFolder
            // 
            this.btnBrowseProjectFolder.Location = new System.Drawing.Point(442, 97);
            this.btnBrowseProjectFolder.Name = "btnBrowseProjectFolder";
            this.btnBrowseProjectFolder.Size = new System.Drawing.Size(43, 23);
            this.btnBrowseProjectFolder.TabIndex = 6;
            this.btnBrowseProjectFolder.Text = "...";
            this.btnBrowseProjectFolder.UseVisualStyleBackColor = true;
            this.btnBrowseProjectFolder.Click += new System.EventHandler(this.btnBrowseProjectFolder_Click);
            // 
            // bwRestore
            // 
            this.bwRestore.WorkerReportsProgress = true;
            this.bwRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRestore_DoWork);
            this.bwRestore.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRestore_ProgressChanged);
            this.bwRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRestore_RunWorkerCompleted);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(21, 181);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(464, 36);
            this.pbProgress.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 161);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(101, 17);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: Ready.";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(314, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 50);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Backup Files|*.backup";
            this.dlgOpen.Title = "Open backup file";
            // 
            // RestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnBrowseProjectFolder);
            this.Controls.Add(this.txtProjectFolder);
            this.Controls.Add(this.lblProjectFolder);
            this.Controls.Add(this.btnBackupFile);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.txtBackupFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Vagrant Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackupFile;
        private System.Windows.Forms.TextBox txtProjectFolder;
        private System.Windows.Forms.Label lblProjectFolder;
        private System.Windows.Forms.Button btnBrowseProjectFolder;
        private System.ComponentModel.BackgroundWorker bwRestore;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowse;
    }
}