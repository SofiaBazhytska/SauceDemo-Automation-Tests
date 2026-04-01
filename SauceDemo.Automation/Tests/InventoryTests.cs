using Shouldly;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTest
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-3: Test adding products to shopping cart")]
        public void UC3_AddProductToCart_ShouldUpdateBadge(string user, string pass)
        {
            LoginPage.Login(user, pass);
            InventoryPage.ClickFirstProductTitle();
            ProductDetailsPage.ClickAddToCart();

            InventoryPage.GetCartBadgeCount().ShouldBe("1");
        }
    }
}
