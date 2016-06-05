using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace VagrantBackup
{
    public enum BackupState
    {
        CopyingFiles,
        Compressing,
        Done
    }

    class BackupFile
    {
        protected string _backupPath;
        protected List<string> _foldersToAdd;
        protected List<string> _filesToAdd;

        public delegate void BackupProgressChanged(BackupState state, float progressFloat);
        public event BackupProgressChanged backupProgressChanged;

        protected FastZipEvents _fastZipEvents;

        public BackupFile(string vagrantBackupPath)
        {
            _backupPath = vagrantBackupPath;
            _foldersToAdd = new List<string>();
            _filesToAdd = new List<string>();
        }

        public void AppendFolder(string folderPath)
        {
            _foldersToAdd.Add(folderPath);
        }

        public void AppendFile(string filePath)
        {
            _filesToAdd.Add(filePath);
        }

        public void SaveBackupToFile(string projectPath, string tempPath)
        {
            _fastZipEvents = new FastZipEvents();
            _fastZipEvents.Progress = new ProgressHandler(ProcessProgressChange);


            backupProgressChanged.Invoke(BackupState.CopyingFiles, 0);
            foreach (string path in _foldersToAdd) {
                string relativePath = path.Replace(projectPath + "\\", "");
                string destinationPath = Path.Combine(tempPath, "files", relativePath);

                if (!Directory.Exists(destinationPath)) {
                    Directory.CreateDirectory(destinationPath);
                }

                DirectoryExtension.CopyRecursive(path, destinationPath);
            }

            foreach (string path in _filesToAdd) {
                File.Copy(path, Path.Combine(tempPath, "files", Path.GetFileName(path)), true);
            }

            FastZip fz = new FastZip(_fastZipEvents);
            fz.CreateZip(_backupPath, tempPath, true, "");
        }

        void ProcessProgressChange(object sender, ProgressEventArgs e)
        {
            backupProgressChanged.Invoke(BackupState.Compressing, e.PercentComplete);
        }
    }

}
