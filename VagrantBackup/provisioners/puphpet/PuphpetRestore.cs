using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagrantBackup
{
    public class PuphpetRestore : IProvisionerRestore
    {
        public const string Name = "puphpet";

        protected string _newProjectPath;
        protected ProvisionerSettings _settings;
        protected string _sourceFolder;

        public void Restore(string newUUID)
        {
            File.WriteAllText(Path.Combine(_newProjectPath, _settings.Get("idPath", "unknown-").ToString()), newUUID);
            File.WriteAllText(Path.Combine(_newProjectPath, _settings.Get("actionProvisionPath", "unknown-").ToString()), "1.5:" + newUUID);


            string projectPath = _settings.Get("projectPath", "").ToString();

            if (string.IsNullOrWhiteSpace(projectPath)) {
                return;
            }


            string syncedFoldersJson = File.ReadAllText(Path.Combine(_newProjectPath, _settings.Get("syncedFoldersPath", "unknown-").ToString()));
            string sourceNewLinuxSlashes = _newProjectPath.Replace("\\", "/");
            string sourceOldLinuxSlashes = projectPath.Replace("\\", "/");
            syncedFoldersJson = syncedFoldersJson.Replace(projectPath, _newProjectPath);
            syncedFoldersJson = syncedFoldersJson.Replace(sourceOldLinuxSlashes, sourceNewLinuxSlashes);

            File.WriteAllText(Path.Combine(_newProjectPath, _settings.Get("syncedFoldersPath", "unknown-").ToString()), syncedFoldersJson);
        }

        public void SetProjectFolder(string projectFolder)
        {
            _newProjectPath = projectFolder;
        }

        public void SetSettings(ProvisionerSettings settings)
        {
            _settings = settings;
        }

        public void SetSourceFolder(string sourceFolder)
        {
            _sourceFolder = sourceFolder;
        }
    }
}
