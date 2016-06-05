using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagrantBackup
{
    interface IProvisionerRestore
    {
        void SetSettings(ProvisionerSettings settings);

        void SetProjectFolder(string projectFolder);

        void SetSourceFolder(string sourceFolder);

        void Restore(string newUUID);
    }
}
