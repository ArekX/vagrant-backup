using System.Collections.Generic;
using System.Windows.Forms;

namespace VagrantBackup
{
    public interface IProvisionerControl
    {
        string GetProvisionerName();

        void ConfigureFromParent(Control parent);

        List<BackupItem> GetBackupItems();

        ProvisionerSettings GetProvisionerSettings();

        string GetBoxUUID();

        bool CanPerformBackup();

        void SetEnabled(bool isEnabled);
    }
}
