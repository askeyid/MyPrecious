using MyPrecious.AT.Framework.Configuration.Model;
using MyPrecious.AT.Framework.Configuration;

namespace MyPrecious.AT.Framework.WebDriver
{
    public static class DriverSettings
    {
        public static DriverInfo DriverInfo => ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration") ?? new DriverInfo();
    }
}