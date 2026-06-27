using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private By PageTitle => By.ClassName("title");
        private By AddToCartButton => By.CssSelector("[data-test='add-to-cart-sauce-labs-backpack']");
        private By CartBadge => By.ClassName("shopping_cart_badge");

        public ProductsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public string GetPageTitle()
        {
            return wait.Until(d => d.FindElement(PageTitle)).Text;
        }

        public void AddBackpackToCart()
        {
            wait.Until(d => d.FindElement(AddToCartButton)).Click();
        }

        public string GetCartCount()
        {
            return wait.Until(d => d.FindElement(CartBadge)).Text;
        }
    }
}