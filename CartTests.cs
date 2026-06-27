using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Pages;

[TestFixture]
public class CartTests
{
    private IWebDriver? driver;
    private WebDriverWait? wait;
    private LoginPage? loginPage;
    private ProductsPage? productsPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        loginPage = new LoginPage(driver, wait);
        productsPage = new ProductsPage(driver, wait);
    }

    [Test]
    public void AddToCart_ShouldUpdateCartCount()
    {
        loginPage!.GoTo();
        loginPage.Login("standard_user", "secret_sauce");
        productsPage!.AddBackpackToCart();
        Assert.That(productsPage.GetCartCount(), Is.EqualTo("1"));
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}