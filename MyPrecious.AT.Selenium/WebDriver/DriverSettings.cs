using MyPrecious.AT.Selenium.WebDriver.ConfModel;
using MyPrecious.AT.Framework.Helpers;

namespace MyPrecious.AT.Selenium.WebDriver
{
    public static class DriverSettings
    {
        public static DriverInfo DriverInfo => ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration") ?? new DriverInfo();
    }
}