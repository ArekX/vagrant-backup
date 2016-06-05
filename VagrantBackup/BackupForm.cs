using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VagrantBackup
{
    public enum BackupItemType
    {
        File,
        Folder
    }

    public struct BackupItem
    {
        public string path;
        public BackupItemType type;

        public override string ToString()
        {
            return ((type == BackupItemType.File) ? "File: " : "Folder: ") + path;
        }
    }

    struct ProgressUpdate
    {
        public string action;
        public ProgressBarStyle progressStyle;
    }

    struct WorkerConfig
    {
        public string vboxManagePath;
        public string outputPath;
        public string projectPath;
        public string tempPath;
        public List<BackupItem> backupItems;
    }


    public partial class BackupForm : Form
    {
        protected IProvisionerControl _provisioner;
        protected string _vBoxManagePath;
        protected string _tempPath;

        public BackupForm(string vBoxMangePath)
        {
            _vBoxManagePath = vBoxMangePath;
            InitializeComponent();

            _tempPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "backupTemp");

            ClearTempFolder();
        }

        private void ClearTempFolder()
        {

            if (Directory.Exists(_tempPath)) {
                Directory.Delete(_tempPath, true);
                while (Directory.Exists(_tempPath)) {
                    Thread.Sleep(100); // Wait until directory is cleared.
                };
            }

            Directory.CreateDirectory(_tempPath);
        }

        private void clbFileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseProjectFolder_Click(object sender, EventArgs e)
        {
            if (dlgBrowseFolders.ShowDialog() == DialogResult.OK) {
                txtProjectFolder.Text = dlgBrowseFolders.SelectedPath;

                _provisioner = GetProvisionerObject(txtProjectFolder.Text);
              
                if (_provisioner == null) {
                    MessageBox.Show("No supported provisioner found. Please check your folder path.", "No provisioner found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                gbProvisioner.Text = "Provisioner: " + _provisioner.GetProvisionerName();
                _provisioner.ConfigureFromParent(gbProvisioner);
                clbFileList.Items.Clear();

                List<BackupItem> items = _provisioner.GetBackupItems();

                foreach(BackupItem item in items) {
                    clbFileList.Items.Add(item, true);
                }

                dlgOpen.InitialDirectory = txtProjectFolder.Text;
                dlgBrowseFolders.SelectedPath = txtProjectFolder.Text;
                btnAddFile.Enabled = true;
                btnBackup.Enabled = true;
                btnAddFolder.Enabled = true;
                btnClearSelected.Enabled = true;
                lblProvisioner.Hide();
                clbFileList.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK) {
                txtDestination.Text = dlgSave.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (_provisioner == null) {
                return;
            }

            if (!_provisioner.CanPerformBackup()) {
                MessageBox.Show("Please fill out all provisioner settings.", "Cannot perform backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestination.Text)) {
                MessageBox.Show("Please fill out backup file destination.", "Cannot perform backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetControlsEnabled(false);

            ProvisionerSettings settings = _provisioner.GetProvisionerSettings();

            File.WriteAllText(Path.Combine(_tempPath, "provisioner.settings"), settings.ToJson());

            List<BackupItem> backupItems = new List<BackupItem>();
            
            foreach(BackupItem item in clbFileList.CheckedItems) {
                backupItems.Add(item);
            }

            bwBackup.RunWorkerAsync(new WorkerConfig() {
                vboxManagePath = _vBoxManagePath,
                outputPath = txtDestination.Text,
                tempPath = _tempPath,
                backupItems = backupItems,
                projectPath = txtProjectFolder.Text
            });
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK) {

                if (!dlgOpen.FileName.Contains(txtProjectFolder.Text)) {
                    MessageBox.Show("Selected file must be inside project folder.", "Cannot add file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                clbFileList.Items.Add(new BackupItem() {
                    path = dlgOpen.FileName,
                    type = BackupItemType.File
                }, true);
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (dlgBrowseFolders.ShowDialog() == DialogResult.OK) {

                if (!dlgBrowseFolders.SelectedPath.Contains(txtProjectFolder.Text)) {
                    MessageBox.Show("Selected path must be inside project folder.", "Cannot add path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clbFileList.Items.Add(new BackupItem() {
                    path = dlgBrowseFolders.SelectedPath,
                    type = BackupItemType.Folder
                }, true);
            }
        }

        protected IProvisionerControl GetProvisionerObject(string projectPath)
        {
            if (File.Exists(Path.Combine(projectPath, @"puphpet\config.yaml"))) {
                return new PuphpetProvisioner(projectPath);
            }

            return null;
        }

        private void bwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressUpdate updater = new ProgressUpdate();
            WorkerConfig config = (WorkerConfig)e.Argument;

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = config.vboxManagePath;

            p.StartInfo.Arguments = "export \"" + _provisioner.GetBoxUUID() + "\" -o \"box.ovf\"";
            p.StartInfo.WorkingDirectory = config.tempPath;
            p.StartInfo.CreateNoWindow = true;

            updater.action = "Exporting VM...";
            updater.progressStyle = ProgressBarStyle.Marquee;
            bwBackup.ReportProgress(20, updater);

            p.Start();
            p.WaitForExit();

            if (!File.Exists(Path.Combine(config.tempPath, "box.ovf"))) {
                MessageBox.Show("Virtual box failed to export VM. Please check that your VM exists in virtual box and that you are running in admin mode.", "VirtualBox VM export failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Result = false;
                return;
            }
            
            BackupFile bf = new BackupFile(config.outputPath);

            foreach(BackupItem item in config.backupItems) {

                switch(item.type) {
                    case BackupItemType.Folder:
                        bf.AppendFolder(item.path);
                        break;
                    case BackupItemType.File:
                        bf.AppendFile(item.path);
                        break;
                }
                
            }

            updater.action = "Compressing package...";
            updater.progressStyle = ProgressBarStyle.Blocks;
            bwBackup.ReportProgress(60, updater);

            bf.backupProgressChanged += Bf_backupProgressChanged;
            bf.SaveBackupToFile(config.projectPath, config.tempPath);
            e.Result = true;
        }

        private void Bf_backupProgressChanged(BackupState state, float progressFloat)
        {
            bwBackup.ReportProgress(60 + (int)Math.Ceiling(progressFloat / 100.0 * 40), new ProgressUpdate() {
                action = "Compression in progress...",
                progressStyle = ProgressBarStyle.Blocks
            });
        }

        private void bwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressUpdate updater = (ProgressUpdate)e.UserState;
            lblProgress.Text = "Status: " + updater.action;
            pbProgress.Value = e.ProgressPercentage;
            pbProgress.Style = updater.progressStyle;
        }

        protected void SetControlsEnabled(bool isEnabled)
        {
            txtDestination.Enabled = isEnabled;
            txtProjectFolder.Enabled = isEnabled;
            btnAddFile.Enabled = isEnabled;
            btnAddFolder.Enabled = isEnabled;
            btnClearSelected.Enabled = isEnabled;
            clbFileList.Enabled = isEnabled;
            btnBackup.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
            btnBrowseProjectFolder.Enabled = isEnabled;
            btnBrowseDestination.Enabled = isEnabled;
            _provisioner.SetEnabled(isEnabled);
        }

        private void bwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlsEnabled(true);
            ClearTempFolder();

            if ((bool)e.Result) {
                MessageBox.Show("Backup successfully exported to: " + txtDestination.Text, "Box exported successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lblProgress.Text = "Status: Ready.";
            pbProgress.Value = 0;
            pbProgress.Style = ProgressBarStyle.Blocks;
        }

        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            clbFileList.Items.Clear();
        }

    }
}
