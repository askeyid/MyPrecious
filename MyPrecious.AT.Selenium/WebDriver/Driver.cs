﻿using System.Diagnostics;
using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Selenium.WebDriver.Enum;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyPrecious.AT.Selenium.WebDriver
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver _driver;
        public static IWebDriver GetDriver()
        {
            if (_driver != null) return _driver;

            _driver = new DriverFactory(DriverSettings.DriverInfo).CreateDriver();

            return _driver;
        }

        public static void QuiteDriver()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();

                _driver = null;
            }
        }

        public static void KillAllDriverProcesses(DriverType type = DriverType.Chrome)
        {
            string driverName;

            if (DriverSettings.DriverInfo.RunRemote)
                return; 
            
            switch (type)
            {
                case DriverType.Chrome:
                case DriverType.ChromeHeadless:
                    driverName = "chromedriver";
                    break;
                case DriverType.Firefox:
                case DriverType.FirefoxHeadless:
                    driverName = "geckodriver";
                    break;
                case DriverType.Edge:
                case DriverType.EdgeHeadless:
                    driverName = "msedgewebview2";
                    break;
                case DriverType.InternetExplorer:
                    throw new NotImplementedException($"'{type}' is not implemented yet!");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            foreach (var chromeDriverProcess in Process.GetProcessesByName(driverName))
            {
                chromeDriverProcess.Kill();
            }
        }

        public static string MakeScreenShot(string name = null)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var imagePath = $"{WriteLog.GetTestDirectoryPath().FullName}\\{name ?? TestContext.CurrentContext.Test.Name}_{DateTime.Now.Ticks}.png";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            var image = ((ITakesScreenshot)GetDriver()).GetScreenshot();
            image.SaveAsFile(imagePath);

            return imagePath;
        }

        public static string SaveBrowserLog(string type)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var browserLogPath =
                $"{WriteLog.GetTestDirectoryPath().FullName}\\SELENIUM_LOG_{type.ToUpperInvariant()}_{DateTime.Now.Ticks}.txt";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            var logs = GetDriver().Manage().Logs.GetLog(type);

            using var file = new StreamWriter(browserLogPath);

            foreach (var log in logs)
            {
                var message = log.Message;
                //WriteLog.Debug(message); NOTE: SHOULD WE PRINT THIS? 

                file.WriteLine(message);
            }

            return browserLogPath;
        }
    }
}