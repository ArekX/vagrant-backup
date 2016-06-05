using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VagrantBackup
{
    public partial class RestoreForm : Form
    {
        protected string _vBoxManagePath;
        protected string _tempPath;

        public RestoreForm(string vBoxManagePath)
        {
            InitializeComponent();
            _vBoxManagePath = vBoxManagePath;
            _tempPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "restoreTemp");
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

        private void SetControlsEnabled(bool isEnabled)
        {
            btnBackupFile.Enabled = isEnabled;
            btnBrowseProjectFolder.Enabled = isEnabled;
            btnRestore.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
            txtBackupFile.Enabled = isEnabled;
            txtProjectFolder.Enabled = isEnabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            SetControlsEnabled(false);
            ClearTempFolder();
            bwRestore.RunWorkerAsync();
        }

        private void CheckCanRestore()
        {
            btnRestore.Enabled =
                File.Exists(txtBackupFile.Text) &&
                Directory.Exists(txtProjectFolder.Text);
        }

        private void btnBackupFile_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK) {
                txtBackupFile.Text = dlgOpen.FileName;
                CheckCanRestore();
            }
        }

        private void btnBrowseProjectFolder_Click(object sender, EventArgs e)
        {
            if (dlgBrowse.ShowDialog() == DialogResult.OK) {
                txtProjectFolder.Text = dlgBrowse.SelectedPath;
                CheckCanRestore();
            }
        }

        public void ExtractZipFile(string archiveFilenameIn, string outFolder)
        {
            ZipFile zf = null;
            try {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                long counter = 0;

                foreach (ZipEntry zipEntry in zf) {
                    if (!zipEntry.IsFile) {
                        continue;
                    }
                    string entryFileName = zipEntry.Name;

                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    string fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);

                    bwRestore.ReportProgress((int)(60 * counter++ / zf.Count), "Extract - " + fullZipToPath.Replace(_tempPath, ""));

                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    using (FileStream streamWriter = File.Create(fullZipToPath)) {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            } finally {
                if (zf != null) {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
            }
        }

        private void bwRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            bwRestore.ReportProgress(0, "Extracting files...");
            ExtractZipFile(txtBackupFile.Text, _tempPath);

           
            string jsonConfig = File.ReadAllText(Path.Combine(_tempPath, "provisioner.settings"));
            ProvisionerSettings settings = ProvisionerSettings.ReadFromJson(jsonConfig);
            IProvisionerRestore provisioner = ProvisionRestoreResolver.GetRestoreProvisioner(settings);

            provisioner.SetProjectFolder(txtProjectFolder.Text);
            provisioner.SetSettings(settings);
            provisioner.SetSourceFolder(_tempPath);

            bwRestore.ReportProgress(60, "Importing VM...");
            VirtualBox box = new VirtualBox(_vBoxManagePath, _tempPath);
            box.ImportBox();


            bwRestore.ReportProgress(90, "Copying data...");
            DirectoryExtension.CopyRecursive(Path.Combine(_tempPath, "files"), txtProjectFolder.Text);

            provisioner.Restore(box.ImportedUUID);
            bwRestore.ReportProgress(100, "Done.");
        }

        private void bwRestore_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
            lblStatus.Text = "Status: " + e.UserState.ToString();
        }

        private void bwRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Backup imported successfully.", "Import successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblStatus.Text = "Status: Ready.";
            pbProgress.Value = 0;
            SetControlsEnabled(true);
        }
    }
}
