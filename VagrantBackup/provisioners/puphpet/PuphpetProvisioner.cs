using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VagrantBackup
{
    public partial class PuphpetProvisioner : UserControl, IProvisionerControl
    {
        protected string _projectPath;
        protected string _dotFolder;

        public PuphpetProvisioner(string projectPath)
        {
            InitializeComponent();

            _projectPath = projectPath;
            _dotFolder = Path.Combine(_projectPath, ".vagrant");

            btnSelectIdPath.Tag = txtIDFilePath;
            btnSelectProvision.Tag = txtActionProvisionPath;
            btnSyncedFolders.Tag = txtSyncedFoldersPath;

            txtIDFilePath.Text = FindPathOf("id");
            txtActionProvisionPath.Text = FindPathOf("action_provision");
            txtSyncedFoldersPath.Text = FindPathOf("synced_folders");
        }

        protected string FindPathOf(string fileName)
        {
            FileInfo[] fileList = new DirectoryInfo(_dotFolder).GetFiles(fileName, SearchOption.AllDirectories);

            if (fileList.Length > 0) {
                return fileList[0].FullName;
            }

            return "";
        }

        private void SelectPath(object sender, EventArgs e)
        {
            Button button = (Button)(sender);
            TextBox box = (TextBox)button.Tag;

            dlgOpen.InitialDirectory = _dotFolder;

            if (dlgOpen.ShowDialog() == DialogResult.OK) {
                box.Text = dlgOpen.FileName;
            }
        }

        public ProvisionerSettings GetProvisionerSettings()
        {
            ProvisionerSettings settings = new ProvisionerSettings();

            settings.provisionerName = "puphpet";

            string replacePath = _projectPath + "\\";

            settings.Set("idPath", txtIDFilePath.Text.Replace(replacePath, ""));
            settings.Set("actionProvisionPath", txtActionProvisionPath.Text.Replace(replacePath, ""));
            settings.Set("syncedFoldersPath", txtSyncedFoldersPath.Text.Replace(replacePath, ""));
            settings.Set("projectPath", _projectPath);

            return settings;
        }

        public string GetProvisionerName()
        {
            return "Puphpet";
        }

        public void ConfigureFromParent(Control parent)
        {
            Parent = parent;
            Top = 20;
            Left = 20;
            Width = parent.Width - 40;
            Height = parent.Height - 40;
            parent.Invalidate();
        }

        public List<BackupItem> GetBackupItems()
        {
            List<BackupItem> items = new List<BackupItem>();

            items.Add(new BackupItem() {
                path = Path.Combine(_projectPath, ".vagrant"),
                type = BackupItemType.Folder
            });

            string sshPath = Path.Combine(_projectPath, @"puphpet\files\dot\ssh");

            if (Directory.Exists(sshPath)) {
                items.Add(new BackupItem() {
                    path = sshPath,
                    type = BackupItemType.Folder
                });
            }

            return items;
        }

        public string GetBoxUUID()
        {
            if (File.Exists(txtIDFilePath.Text)) {
                return File.ReadAllText(txtIDFilePath.Text);
            }

            return "";
        }

        public bool CanPerformBackup()
        {
            return
                File.Exists(txtIDFilePath.Text) &&
                File.Exists(txtSyncedFoldersPath.Text) &&
                File.Exists(txtActionProvisionPath.Text);
        }

        public void SetEnabled(bool isEnabled)
        {
            txtIDFilePath.Enabled = isEnabled;
            txtSyncedFoldersPath.Enabled = isEnabled;
            txtActionProvisionPath.Enabled = isEnabled;
            btnSelectIdPath.Enabled = isEnabled;
            btnSelectProvision.Enabled = isEnabled;
            btnSyncedFolders.Enabled = isEnabled;
        }
    }
}
