using MyPrecious.AT.Selenium.WebDriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
#nullable disable

namespace MyPrecious.AT.Selenium.Helpers
{
    public static class WaitUtilities
    {
        public static TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition, TimeSpan? timeout = null /*ElementTimeout*/, string message = "")
        {
            timeout ??= DriverSettings.DriverInfo.TimeoutsInfo.ElementTimeout;

            var wait = new WebDriverWait(Driver.GetDriver(), timeout.Value);
            wait.Message = string.IsNullOrEmpty(message) ? $"Wait condition not met after {wait.Timeout.TotalSeconds} seconds." : message;
            var element = wait.Until(condition);

            return element;
        }

        public static void ConditionIsMet(Func<IWebDriver, bool> condition, TimeSpan? timeout = null, string message = "")
        {
            timeout ??= DriverSettings.DriverInfo.TimeoutsInfo.ElementTimeout;

            var wait = new WebDriverWait(Driver.GetDriver(), timeout.Value);
            wait.Message = string.IsNullOrEmpty(message) ? $"Wait condition not met after {wait.Timeout.TotalSeconds} seconds." : message;

            wait.Until(condition);
        }

        public static void PageLoadIsComplete()
        {
            WaitUntil(x => JsExecutor.ExecuteScript("return document.readyState").Equals("complete"), DriverSettings.DriverInfo.TimeoutsInfo.PageLoadTimeout);
        }
    }
}
