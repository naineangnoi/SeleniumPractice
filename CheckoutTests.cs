using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Pages;

[TestFixture]
public class CheckoutTests
{
    private IWebDriver? driver;
    private WebDriverWait? wait;
    private LoginPage? loginPage;
    private ProductsPage? productsPage;
    private CartPage? cartPage;
    private CheckoutPage? checkoutPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        loginPage = new LoginPage(driver, wait);
        productsPage = new ProductsPage(driver, wait);
        cartPage = new CartPage(driver, wait);
        checkoutPage = new CheckoutPage(driver, wait);
    }

    [Test]
    public void Checkout_WithValidInfo_ShouldShowConfirmation()
    {
        // Login
        loginPage!.GoTo();
        loginPage.Login("standard_user", "secret_sauce");

        // Add to cart
        productsPage!.AddBackpackToCart();

        // Go to cart
        cartPage!.GoTo();
        Assert.That(cartPage.GetCartItemCount(), Is.EqualTo(1));

        // Checkout
        cartPage.ProceedToCheckout();
        checkoutPage!.FillShippingInfo("John", "Doe", "12345");
        checkoutPage.FinishCheckout();

        // Confirm
        Assert.That(checkoutPage.GetConfirmationMessage(), 
            Is.EqualTo("Thank you for your order!"));
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}