using FluentAssertions;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class InventoryTests : BaseTest
    {
        public InventoryTests(string browser) : base(browser) { }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-3: Test adding products to shopping cart")]
        public void UC3_AddProductToCart_ShouldUpdateBadge(string user, string pass)
        {
            LoginPage.Login(user, pass);
            InventoryPage.ClickFirstProductTitle();
            ProductDetailsPage.ClickAddToCart();

            InventoryPage.GetCartBadgeCount().Should().Be("1");
        }
    }
}
