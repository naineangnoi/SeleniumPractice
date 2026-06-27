using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By CheckoutButton => By.CssSelector("[data-test='checkout']");
        private By CartItem => By.ClassName("cart_item");

        public CartPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
        }

        public int GetCartItemCount()
        {
            return driver.FindElements(CartItem).Count;
        }

        public void ProceedToCheckout()
        {
            wait.Until(d => d.FindElement(CheckoutButton)).Click();
        }
    }
}