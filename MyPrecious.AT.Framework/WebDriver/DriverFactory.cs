using MyPrecious.AT.Framework.WebDriver.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyPrecious.AT.Framework.WebDriver
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver(DriverType type) 
        {
            switch (type)
            {
                case DriverType.Chrome:
                    return CreateChromeDriver(headless: false);
                case DriverType.ChromeHeadless:
                    return CreateChromeDriver(headless: true);
                case DriverType.Firefox:
                    return CreateFirefoxDriver(headless: false);
                case DriverType.FirefoxHeadless:
                    return CreateFirefoxDriver(headless: true);
                case DriverType.Edge:
                    return CreateEdgeDriver(headless: false);
                case DriverType.EdgeHeadless:
                    return CreateEdgeDriver(headless: true);
                default:
                    throw new NotImplementedException(message: $"'{type} is not implemented yet!");
            }
        }

        #region Drivers

        public IWebDriver CreateChromeDriver(bool headless)
        {
            /// https://www.ghacks.net/2013/10/06/list-useful-google-chrome-command-line-switches/
            var options = new ChromeOptions();

            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            return new ChromeDriver(options);
        }

        private IWebDriver CreateFirefoxDriver(bool headless)
        {
            var options = new FirefoxOptions();
            options.AddArgument("-start-maximized");
            options.AddArgument("-disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);

            if (headless)
            {
                options.AddArgument("-headless");
            }

            var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            return new FirefoxDriver(driverService, options);
        }

        private IWebDriver CreateEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-extensions");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            options.AddUserProfilePreference("download.prompt_for_download", false);

            if (headless)
            {
                options.AddArgument("headless");
                options.AddArgument("disable-gpu");
            }

            return new EdgeDriver(options);
        }

        #endregion
    }
}
