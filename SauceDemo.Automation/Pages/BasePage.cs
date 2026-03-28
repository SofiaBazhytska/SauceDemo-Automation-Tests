using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Automation.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void Log(string message)
        {
            TestContext.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        protected IWebElement WaitUntilVisible(By locator)
        {
            Log($"Waiting for visibility of element: {locator}");
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            Log($"Clicking on element: {locator}");
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            Log($"Entering text into {locator}");

            var element = WaitUntilVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}
