using MyPrecious.AT.Framework.WebDriver.Enum;
using OpenQA.Selenium;

namespace MyPrecious.AT.Framework.WebDriver
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver != null) return _driver;

            _driver = new DriverFactory().CreateDriver(DriverType.Edge);

            return _driver;
        }

        public static void QuiteDriver()
        {
            _driver.Close();
            _driver.Quit();

            _driver = null;
        }
    }
}