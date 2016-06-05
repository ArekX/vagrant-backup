namespace VagrantBackup
{
    partial class PuphpetProvisioner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIdFile = new System.Windows.Forms.Label();
            this.txtIDFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectIdPath = new System.Windows.Forms.Button();
            this.lblVagrantProvisionPath = new System.Windows.Forms.Label();
            this.btnSelectProvision = new System.Windows.Forms.Button();
            this.txtActionProvisionPath = new System.Windows.Forms.TextBox();
            this.lblSyncedFoldersPath = new System.Windows.Forms.Label();
            this.txtSyncedFoldersPath = new System.Windows.Forms.TextBox();
            this.btnSyncedFolders = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblIdFile
            // 
            this.lblIdFile.AutoSize = true;
            this.lblIdFile.Location = new System.Drawing.Point(7, 14);
            this.lblIdFile.Name = "lblIdFile";
            this.lblIdFile.Size = new System.Drawing.Size(135, 17);
            this.lblIdFile.TabIndex = 0;
            this.lblIdFile.Text = ".vagrant \'id\' file path";
            // 
            // txtIDFilePath
            // 
            this.txtIDFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDFilePath.Location = new System.Drawing.Point(10, 34);
            this.txtIDFilePath.Name = "txtIDFilePath";
            this.txtIDFilePath.Size = new System.Drawing.Size(340, 22);
            this.txtIDFilePath.TabIndex = 1;
            // 
            // btnSelectIdPath
            // 
            this.btnSelectIdPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectIdPath.Location = new System.Drawing.Point(357, 33);
            this.btnSelectIdPath.Name = "btnSelectIdPath";
            this.btnSelectIdPath.Size = new System.Drawing.Size(40, 23);
            this.btnSelectIdPath.TabIndex = 2;
            this.btnSelectIdPath.Text = "...";
            this.btnSelectIdPath.UseVisualStyleBackColor = true;
            this.btnSelectIdPath.Click += new System.EventHandler(this.SelectPath);
            // 
            // lblVagrantProvisionPath
            // 
            this.lblVagrantProvisionPath.AutoSize = true;
            this.lblVagrantProvisionPath.Location = new System.Drawing.Point(7, 74);
            this.lblVagrantProvisionPath.Name = "lblVagrantProvisionPath";
            this.lblVagrantProvisionPath.Size = new System.Drawing.Size(227, 17);
            this.lblVagrantProvisionPath.TabIndex = 3;
            this.lblVagrantProvisionPath.Text = ".vagrant \'action_provision\' file path";
            // 
            // btnSelectProvision
            // 
            this.btnSelectProvision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectProvision.Location = new System.Drawing.Point(357, 93);
            this.btnSelectProvision.Name = "btnSelectProvision";
            this.btnSelectProvision.Size = new System.Drawing.Size(40, 23);
            this.btnSelectProvision.TabIndex = 5;
            this.btnSelectProvision.Text = "...";
            this.btnSelectProvision.UseVisualStyleBackColor = true;
            this.btnSelectProvision.Click += new System.EventHandler(this.SelectPath);
            // 
            // txtActionProvisionPath
            // 
            this.txtActionProvisionPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActionProvisionPath.Location = new System.Drawing.Point(10, 94);
            this.txtActionProvisionPath.Name = "txtActionProvisionPath";
            this.txtActionProvisionPath.Size = new System.Drawing.Size(340, 22);
            this.txtActionProvisionPath.TabIndex = 4;
            // 
            // lblSyncedFoldersPath
            // 
            this.lblSyncedFoldersPath.AutoSize = true;
            this.lblSyncedFoldersPath.Location = new System.Drawing.Point(7, 139);
            this.lblSyncedFoldersPath.Name = "lblSyncedFoldersPath";
            this.lblSyncedFoldersPath.Size = new System.Drawing.Size(220, 17);
            this.lblSyncedFoldersPath.TabIndex = 6;
            this.lblSyncedFoldersPath.Text = ".vagrant \'synced_folders\' file path";
            // 
            // txtSyncedFoldersPath
            // 
            this.txtSyncedFoldersPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSyncedFoldersPath.Location = new System.Drawing.Point(10, 159);
            this.txtSyncedFoldersPath.Name = "txtSyncedFoldersPath";
            this.txtSyncedFoldersPath.Size = new System.Drawing.Size(340, 22);
            this.txtSyncedFoldersPath.TabIndex = 7;
            this.txtSyncedFoldersPath.Tag = "";
            // 
            // btnSyncedFolders
            // 
            this.btnSyncedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncedFolders.Location = new System.Drawing.Point(357, 159);
            this.btnSyncedFolders.Name = "btnSyncedFolders";
            this.btnSyncedFolders.Size = new System.Drawing.Size(40, 23);
            this.btnSyncedFolders.TabIndex = 8;
            this.btnSyncedFolders.Text = "...";
            this.btnSyncedFolders.UseVisualStyleBackColor = true;
            this.btnSyncedFolders.Click += new System.EventHandler(this.SelectPath);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Any File|*.*";
            this.dlgOpen.Title = "Find File...";
            // 
            // PuphpetProvisioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSyncedFolders);
            this.Controls.Add(this.txtSyncedFoldersPath);
            this.Controls.Add(this.lblSyncedFoldersPath);
            this.Controls.Add(this.btnSelectProvision);
            this.Controls.Add(this.txtActionProvisionPath);
            this.Controls.Add(this.lblVagrantProvisionPath);
            this.Controls.Add(this.btnSelectIdPath);
            this.Controls.Add(this.txtIDFilePath);
            this.Controls.Add(this.lblIdFile);
            this.Name = "PuphpetProvisioner";
            this.Size = new System.Drawing.Size(415, 212);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdFile;
        private System.Windows.Forms.TextBox txtIDFilePath;
        private System.Windows.Forms.Button btnSelectIdPath;
        private System.Windows.Forms.Label lblVagrantProvisionPath;
        private System.Windows.Forms.Button btnSelectProvision;
        private System.Windows.Forms.TextBox txtActionProvisionPath;
        private System.Windows.Forms.Label lblSyncedFoldersPath;
        private System.Windows.Forms.TextBox txtSyncedFoldersPath;
        private System.Windows.Forms.Button btnSyncedFolders;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}
