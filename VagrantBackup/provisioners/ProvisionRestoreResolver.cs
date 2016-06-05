using System;
namespace VagrantBackup
{
    static class ProvisionRestoreResolver
    {
        public static IProvisionerRestore GetRestoreProvisioner(ProvisionerSettings settings)
        {
            switch(settings.provisionerName) {
                case PuphpetRestore.Name:
                    return new PuphpetRestore();
            }

            return null;
        }
    }
}
