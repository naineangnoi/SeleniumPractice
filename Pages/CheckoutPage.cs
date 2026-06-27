using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By FirstName => By.CssSelector("[data-test='firstName']");
        private By LastName => By.CssSelector("[data-test='lastName']");
        private By PostalCode => By.CssSelector("[data-test='postalCode']");
        private By ContinueButton => By.CssSelector("[data-test='continue']");
        private By FinishButton => By.CssSelector("[data-test='finish']");
        private By ConfirmationMessage => By.ClassName("complete-header");

        public CheckoutPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void FillShippingInfo(string firstName, string lastName, string postalCode)
        {
            wait.Until(d => d.FindElement(FirstName)).SendKeys(firstName);
            driver.FindElement(LastName).SendKeys(lastName);
            driver.FindElement(PostalCode).SendKeys(postalCode);
            driver.FindElement(ContinueButton).Click();
        }

        public void FinishCheckout()
        {
            wait.Until(d => d.FindElement(FinishButton)).Click();
        }

        public string GetConfirmationMessage()
        {
            return wait.Until(d => d.FindElement(ConfirmationMessage)).Text;
        }
    }
}