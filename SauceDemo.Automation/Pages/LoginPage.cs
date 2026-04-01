using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SauceDemo.Automation.Pages
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        private static readonly By UsernameLocator = By.CssSelector("#user-name");
        private static readonly By PasswordLocator = By.CssSelector("#password");
        private static readonly By LoginButtonLocator = By.CssSelector("#login-button");
        private static readonly By ErrorContainerLocator = By.CssSelector("h3[data-test='error']");

        /// <summary>
        /// Enters the username into the corresponding input field.
        /// </summary>
        public void EnterUsername(string username) => SendKeys(UsernameLocator, username);

        /// <summary>
        /// Enters the password into the corresponding input field.
        /// </summary>
        public void EnterPassword(string password) => SendKeys(PasswordLocator, password);

        /// <summary>
        /// Clears the password field using keyboard actions (Ctrl+A -> Backspace).
        /// </summary>
        public void ClearPassword()
        {
            Log.Info("Clearing password field using keyboard actions (Ctrl+A -> Backspace)");

            var passwordField = WaitUntilVisible(PasswordLocator);

            new Actions(Driver)
                .Click(passwordField)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Backspace)
                .Perform();
        }

        /// <summary>
        /// Clicks the Login button.
        /// </summary>
        public void ClickLogin() => Click(LoginButtonLocator);

        /// <summary>
        /// Gets the error message text displayed on the login page.
        /// </summary>
        public string GetErrorMessage() => WaitUntilVisible(ErrorContainerLocator).Text;

        /// <summary>
        /// Performs a complete login flow.
        /// </summary>
        public void Login(string user, string pass)
        {
            Log.Info("Attempting login for user: {0}", user);

            EnterUsername(user);
            EnterPassword(pass);
            ClickLogin();
        }
    }
}
