using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using NLog;

namespace SauceDemo.Automation.Drivers
{
    public static class BrowserFactory
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Returns a configured WebDriver instance for the specified browser.
        /// </summary>
        public static IWebDriver GetDriver(string browserType)
        {
            Log.Info("Initializing WebDriver for browser: {0}", browserType);
            IWebDriver instance = browserType.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                _ => throw new ArgumentException($"Browser '{browserType}' is not supported")
            };

            instance.Manage().Window.Maximize();
            return instance;
        }

        private static ChromeDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-search-engine-choice-screen");
            return new ChromeDriver(options);
        }

        private static FirefoxDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            return new FirefoxDriver(options);
        }
    }
}
