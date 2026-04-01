using Shouldly;
using SauceDemo.Automation.Pages;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SauceDemo.Automation.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-1: Test Login form with only Username provided")]
        public void UC1_LoginWithOnlyUsername_ShouldShowPasswordRequiredError(string user, string pass)
        {
            LoginPage.EnterUsername(user);
            LoginPage.EnterPassword(pass);
            LoginPage.ClearPassword();
            LoginPage.ClickLogin();

            LoginPage.GetErrorMessage().ShouldContain("Password is required");
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-2: Test Login form with valid credentials")]
        public void UC2_ValidLogin_ShouldShowAllMainElements(string user, string pass)
        {
            LoginPage.Login(user, pass);

            InventoryPage.BurgerMenu.Displayed.ShouldBeTrue();
            InventoryPage.AppLogo.Text.ShouldBe("Swag Labs");
            InventoryPage.ShoppingCart.Displayed.ShouldBeTrue();
            InventoryPage.SortDropdown.Displayed.ShouldBeTrue();
            InventoryPage.InventoryList.Displayed.ShouldBeTrue();
        }
    }
}
