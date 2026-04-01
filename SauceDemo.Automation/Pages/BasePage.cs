using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using NLog;

namespace SauceDemo.Automation.Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver Driver = driver;
        protected readonly WebDriverWait Wait = new(driver, TimeSpan.FromSeconds(10));

        protected static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Waits until the element located by the specified locator is visible.
        /// </summary>
        protected IWebElement WaitUntilVisible(By locator)
        {
            Log.Debug("Waiting for element visibility: {0}", locator);

            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be clickable and performs a click.
        /// </summary>
        protected void Click(By locator)
        {
            Log.Info("Clicking on element: {0}", locator);

            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        /// <summary>
        /// Clears the field and enters the specified text into the element.
        /// </summary>
        protected void SendKeys(By locator, string text)
        {
            Log.Info("Entering text into {0}", locator);

            var element = WaitUntilVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}
