using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SauceDemo.Automation.Drivers
{
    public class BrowserFactory
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver(string browserType)
        {
            if (_driver.Value == null)
            {
                IWebDriver instance = browserType.ToLower() switch
                {
                    "chrome" => CreateChromeDriver(),
                    "firefox" => CreateFirefoxDriver(),
                    _ => throw new ArgumentException($"Browser '{browserType}' is not supported")
                };

                instance.Manage().Window.Maximize();
                _driver.Value = instance;
            }
            return _driver.Value;
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-search-engine-choice-screen");

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();

            options.PageLoadStrategy = PageLoadStrategy.Normal;

            return new FirefoxDriver(options);
        }

        public static void QuitDriver()
        {
            if (_driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value = null;
            }
        }
    }
}
