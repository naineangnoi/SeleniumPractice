using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By UsernameField => By.Id("user-name");
        private By PasswordField => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("[data-test='error']");
        private By PageTitle => By.ClassName("title");

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        public void Login(string username, string password)
        {
            wait.Until(d => d.FindElement(UsernameField)).SendKeys(username);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButton).Click();
        }

        public string GetPageTitle()
        {
            return wait.Until(d => d.FindElement(PageTitle)).Text;
        }

        public bool IsErrorDisplayed()
        {
            return wait.Until(d => d.FindElement(ErrorMessage)).Displayed;
        }
    }
}