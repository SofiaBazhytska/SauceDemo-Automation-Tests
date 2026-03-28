using OpenQA.Selenium;
using SauceDemo.Automation.Drivers;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected LoginPage LoginPage;
        protected InventoryPage InventoryPage;
        protected ProductDetailsPage ProductDetailsPage;
        private readonly string _browser;
        public BaseTest(string browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            Driver = BrowserFactory.GetDriver(_browser);
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");

            LoginPage = new LoginPage(Driver);
            InventoryPage = new InventoryPage(Driver);
            ProductDetailsPage = new ProductDetailsPage(Driver);
        }

        [TearDown]
        public void Teardown()
        {
            BrowserFactory.QuitDriver();
        }
    }
}
