﻿using System;
using System.Diagnostics;
using MyPrecious.AT.Framework.Configuration;
using MyPrecious.AT.Framework.Configuration.Model;
using MyPrecious.AT.Framework.WebDriver.Enum;
using MyPrecious.AT.Framework.WebDriver;
using OpenQA.Selenium;

namespace MyPrecious.AT.Framework.WebDriver
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
            _driver.Close();
            _driver.Quit();

            _driver = null;
        }

        public static void KillAllDriverProcess(DriverType type = DriverType.Chrome)
        {
            string driverName;

            switch (type)
            {
                case DriverType.Chrome:
                case DriverType.ChromeHeadless:
                    driverName = "chromedriver";
                    break;
                case DriverType.Firefox:
                case DriverType.FirefoxHeadless:
                    driverName = "firefox";
                    break;
                case DriverType.Edge:
                case DriverType.EdgeHeadless:
                    driverName = "edge";
                    break;
                case DriverType.InternetExplorer:
                    driverName = "internetExplorer";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            foreach (var chromeDriverProcess in Process.GetProcessesByName(driverName))
            {
                chromeDriverProcess.Kill();
            }
        }
    }
}