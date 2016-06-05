using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace VagrantBackup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"Software\Oracle\VirtualBox");

            if (key == null) {
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"Software\Oracle\VirtualBox");
            }
            
            if (key != null) {
                txtVBoxManagePath.Text = (string)key.GetValue("InstallDir", "") + "VBoxManage.exe";
            }

            if (!File.Exists(txtVBoxManagePath.Text)) {
                MessageBox.Show("Could not find location of VBoxManage.exe. Please locate it manually.");
                SetControlsEnabled(false);
            }
        }

        private void btnBrowseManage_Click(object sender, EventArgs e)
        {
            dlgOpen.InitialDirectory = Directory.GetParent(txtVBoxManagePath.Text).ToString();
            dlgOpen.FileName = "VBoxManage.exe";
            dlgOpen.Filter = "VBoxManage.exe|VBoxManage.exe";
            dlgOpen.CheckFileExists = true;

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtVBoxManagePath.Text = dlgOpen.FileName;
                SetControlsEnabled(true);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            (new RestoreForm(txtVBoxManagePath.Text)).ShowDialog();
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnBackup.Enabled = enabled;
            btnRestore.Enabled = enabled;
            txtVBoxManagePath.Enabled = enabled;
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            (new BackupForm(txtVBoxManagePath.Text)).ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string backupTemp = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "backupTemp");
            string restoreTemp = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "restoreTemp");

            if (Directory.Exists(backupTemp)) {
                Directory.Delete(backupTemp, true);
            }

            if (Directory.Exists(restoreTemp)) {
                Directory.Delete(restoreTemp, true);
            }
        }
    }
}
