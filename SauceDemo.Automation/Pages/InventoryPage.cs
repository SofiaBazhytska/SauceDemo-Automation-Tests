using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class InventoryPage(IWebDriver driver) : BasePage(driver)
    {
        private static readonly By BurgerMenuLocator = By.CssSelector("#react-burger-menu-btn");
        private static readonly By AppLogoLocator = By.CssSelector(".app_logo");
        private static readonly By ShoppingCartLocator = By.CssSelector(".shopping_cart_link");
        private static readonly By SortDropdownLocator = By.CssSelector(".product_sort_container");
        private static readonly By InventoryListLocator = By.CssSelector(".inventory_list");
        private static readonly By FirstProductNameLocator = By.CssSelector(".inventory_item_name");
        private static readonly By CartBadgeLocator = By.CssSelector(".shopping_cart_badge");

        /// <summary>
        /// Gets the burger menu button element, waiting until it is visible.
        /// </summary>
        public IWebElement BurgerMenu => WaitUntilVisible(BurgerMenuLocator);

        /// <summary>
        /// Gets the main application logo element.
        /// </summary>
        public IWebElement AppLogo => WaitUntilVisible(AppLogoLocator);

        /// <summary>
        /// Gets the shopping cart icon/link element.
        /// </summary>
        public IWebElement ShoppingCart => WaitUntilVisible(ShoppingCartLocator);

        /// <summary>
        /// Gets the product sorting dropdown element.
        /// </summary>
        public IWebElement SortDropdown => WaitUntilVisible(SortDropdownLocator);

        /// <summary>
        /// Gets the container element that holds the list of inventory items.
        /// </summary>
        public IWebElement InventoryList => WaitUntilVisible(InventoryListLocator);

        /// <summary>
        /// Clicks on the title of the first product displayed in the inventory list.
        /// </summary>
        public void ClickFirstProductTitle() => Click(FirstProductNameLocator);

        /// <summary>
        /// Retrieves the number of items displayed on the shopping cart badge.
        /// </summary>
        public string GetCartBadgeCount() => WaitUntilVisible(CartBadgeLocator).Text;
    }
}
