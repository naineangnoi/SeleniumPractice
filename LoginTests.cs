using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice.Pages;

[TestFixture]
public class LoginTests
{
    private IWebDriver? driver;
    private WebDriverWait? wait;
    private LoginPage? loginPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        loginPage = new LoginPage(driver, wait);
    }

    [Test]
    public void Login_WithValidCredentials_ShouldSucceed()
    {
        loginPage!.GoTo();
        loginPage.Login("standard_user", "secret_sauce");
        Assert.That(loginPage.GetPageTitle(), Is.EqualTo("Products"));
    }

    [Test]
    public void Login_WithWrongUsername_ShouldShowError()
    {
        loginPage!.GoTo();
        loginPage.Login("wrong_user", "secret_sauce");
        Assert.That(loginPage.IsErrorDisplayed(), Is.True);
    }

    [Test]
    public void Login_WithWrongPassword_ShouldShowError()
    {
        loginPage!.GoTo();
        loginPage.Login("standard_user", "wrong_password");
        Assert.That(loginPage.IsErrorDisplayed(), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}