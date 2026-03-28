using OpenQA.Selenium;

namespace SauceDemo.Automation.Pages
{
    public class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver) { }

        private By AddToCartButtonLocator => By.CssSelector("button[data-test^='add-to-cart']");

        public void ClickAddToCart()
        {
            Click(AddToCartButtonLocator);
        }
    }
}
