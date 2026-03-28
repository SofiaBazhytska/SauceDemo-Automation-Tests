using FluentAssertions;
using SauceDemo.Automation.Pages;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SauceDemo.Automation.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class LoginTests : BaseTest
    {
        public LoginTests(string browser) : base(browser) { }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-1: Test Login form with only Username provided")]
        public void UC1_LoginWithOnlyUsername_ShouldShowPasswordRequiredError(string user, string pass)
        {
            LoginPage.EnterUsername(user);
            LoginPage.EnterPassword(pass);
            LoginPage.ClearPassword();
            LoginPage.ClickLogin();

            LoginPage.GetErrorMessage().Should().Contain("Password is required");
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        [Description("UC-2: Test Login form with valid credentials")]
        public void UC2_ValidLogin_ShouldShowAllMainElements(string user, string pass)
        {
            LoginPage.Login(user, pass);

            InventoryPage.BurgerMenu.Displayed.Should().BeTrue();
            InventoryPage.AppLogo.Text.Should().Be("Swag Labs");
            InventoryPage.ShoppingCart.Displayed.Should().BeTrue();
            InventoryPage.SortDropdown.Displayed.Should().BeTrue();
            InventoryPage.InventoryList.Displayed.Should().BeTrue();
        }
    }
}
