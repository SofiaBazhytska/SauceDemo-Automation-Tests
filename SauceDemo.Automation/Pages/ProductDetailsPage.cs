using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class ProductDetailsPage(IWebDriver driver) : BasePage(driver)
    {
        private static readonly By AddToCartButtonLocator = By.CssSelector("button[data-test^='add-to-cart']");

        // <summary>
        /// Clicks the 'Add to cart' button for the current product.
        /// </summary>
        public void ClickAddToCart() => Click(AddToCartButtonLocator);
    }
}
