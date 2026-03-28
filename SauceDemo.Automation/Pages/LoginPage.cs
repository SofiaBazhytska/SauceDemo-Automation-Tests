using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SauceDemo.Automation.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private By UsernameLocator => By.CssSelector("#user-name");
        private By PasswordLocator => By.CssSelector("#password");
        private By LoginButtonLocator => By.CssSelector("#login-button");
        private By ErrorContainerLocator => By.CssSelector("h3[data-test='error']");

        public void EnterUsername(string username) => SendKeys(UsernameLocator, username);

        public void EnterPassword(string password) => SendKeys(PasswordLocator, password);

        public void ClearPassword()
        {
            var passwordField = WaitUntilVisible(PasswordLocator);

            new Actions(Driver)
                .Click(passwordField)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Backspace)
                .Perform();
        }

        public void ClickLogin() => Click(LoginButtonLocator);

        public string GetErrorMessage() => WaitUntilVisible(ErrorContainerLocator).Text;

        public void Login(string user, string pass)
        {
            EnterUsername(user);
            EnterPassword(pass);
            ClickLogin();
        }
    }
}
