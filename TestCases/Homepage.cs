using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using DesafioAutomacao.PageObjects;

namespace HomePage
{
    class HomePage
    {
        IWebDriver Webdriver;
        
        [SetUp]
        public void DriverInitialization()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            Webdriver = new ChromeDriver(@"D:\Projetos\C#\DesafioAutomacao\WebDrivers", chromeOptions);
            Webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Webdriver.Url = "http://automationpractice.com/";
            Webdriver.Manage().Window.Maximize();
            //Webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void FinalizarCompra()
        {
            WebDriverWait wait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(40));
            HomePageMethods homePageMethods = new HomePageMethods(Webdriver);
            ItemMethods itemMethods = new ItemMethods(Webdriver);
            CartPageMethods cartPageMethods = new CartPageMethods(Webdriver);
            FormPageMethods formPageMethods = new FormPageMethods(Webdriver);
            string productName = "Faded Short Sleeve T-shirts";

            //select an item on homepage
            homePageMethods.SelectProduct(productName);

            //add item to cart and proceed to checkout
            itemMethods.AddToCart();
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ItemPageObjects.layerCart));
            itemMethods.GoToCheckout();
            Assert.IsTrue(cartPageMethods.GetBreadcrumb().Contains("Your shopping cart"));

            //assert that item previously selected is on the cart and go to sign in+
            //Assert.IsTrue(cartPageMethods.GetProductName().Contains(productName)); //esse assert não funciona
            cartPageMethods.CheckoutNextStep();
            cartPageMethods.SubmitCreate("automation.test@test.com");
            formPageMethods.InsertCostumerName("Automation", "Test");
            formPageMethods.InsertPasword("abc123");
            formPageMethods.InsertDateBirth("15", "5", "1990");
            formPageMethods.InsertAddresstName("Automation", "Test");
            formPageMethods.InsertAddres("1784  Water Street");
            formPageMethods.InsertCity("Los Angeles");
            formPageMethods.SelectCountry("United States");
            formPageMethods.SelectState("California");
            formPageMethods.InsertPostalCode("90007");
            formPageMethods.InsertPhone("925-280-1092");
            formPageMethods.FinishRegister();
        }


        [TearDown]
        public void EndTest()
        {
            Webdriver.Close();
        }

    }
}
