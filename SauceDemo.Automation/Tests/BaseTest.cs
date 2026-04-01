using NLog;
using OpenQA.Selenium;
using SauceDemo.Automation.Drivers;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver? Driver;
        protected LoginPage LoginPage;
        protected InventoryPage InventoryPage;
        protected ProductDetailsPage ProductDetailsPage;

        protected static readonly Logger Log = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            var browser = TestContext.Parameters.Get("Browser", "chrome");
            var url = TestContext.Parameters.Get("BaseUrl", "https://www.saucedemo.com");

            Log.Info("------ STARTING TEST: {0} ------", TestContext.CurrentContext.Test.Name);

            Driver = BrowserFactory.GetDriver(browser);
            Driver.Navigate().GoToUrl(url);

            LoginPage = new LoginPage(Driver);
            InventoryPage = new InventoryPage(Driver);
            ProductDetailsPage = new ProductDetailsPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Log.Info("TEST FINISHED: {0} | STATUS: {1}",
                TestContext.CurrentContext.Test.Name,
                TestContext.CurrentContext.Result.Outcome.Status);

            if (Driver != null)
            {
                try { Driver.Quit(); }
                catch (Exception ex) { Log.Error(ex, "Error during Quit"); }
                finally { Driver.Dispose(); }
            }
        }
    }
}