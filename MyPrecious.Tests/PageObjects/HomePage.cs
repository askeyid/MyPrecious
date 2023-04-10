using MyPrecious.AT.Selenium.WebElement.BaseElements;
using OpenQA.Selenium;

namespace MyPrecious.Tests.PageObjects
{
    public class HomePage
    {
        public HtmlElement ProfileFirstName => new HtmlElement(By.Id("ctl00_CPHContainer_spFirstName"))
        { ExpectedTitle = "Name" };
    }
}
