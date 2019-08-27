using System.Configuration.Install;
using System.Reflection;

namespace HybridSvx
{
    public class SelfInstaller
    {
        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
        public static bool InstallMe()
        {
            bool result;
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { _exePath });
            }
            catch
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        public static bool UninstallMe()
        {
            bool result;
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", _exePath });
            }
            catch
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

    }
}
