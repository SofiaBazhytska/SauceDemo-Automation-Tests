using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver) { }

        private By BurgerMenuLocator => By.CssSelector("#react-burger-menu-btn");
        private By AppLogoLocator => By.CssSelector(".app_logo");
        private By ShoppingCartLocator => By.CssSelector(".shopping_cart_link");
        private By SortDropdownLocator => By.CssSelector(".product_sort_container");
        private By InventoryListLocator => By.CssSelector(".inventory_list");
        private By FirstProductNameLocator => By.CssSelector(".inventory_item_name");
        private By CartBadgeLocator => By.CssSelector(".shopping_cart_badge");

        public IWebElement BurgerMenu => WaitUntilVisible(BurgerMenuLocator);
        public IWebElement AppLogo => WaitUntilVisible(AppLogoLocator);
        public IWebElement ShoppingCart => WaitUntilVisible(ShoppingCartLocator);
        public IWebElement SortDropdown => WaitUntilVisible(SortDropdownLocator);
        public IWebElement InventoryList => WaitUntilVisible(InventoryListLocator);

        public void ClickFirstProductTitle()
        {
            Click(FirstProductNameLocator);
        }

        public string GetCartBadgeCount()
        {
            try
            {
                return WaitUntilVisible(CartBadgeLocator).Text;
            }
            catch (WebDriverTimeoutException)
            {
                return "0";
            }
        }
    }
}
