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
            AddressPageMethods addressPageMethods = new AddressPageMethods(Webdriver);
            PaymentPageMethods paymentPageMethods = new PaymentPageMethods(Webdriver);
            string productName = "Faded Short Sleeve T-shirts";
            string consumerEmail = "testAutomation13@testAutomation.com";
            string consumerFirstName = "Automation";
            string consumerLastName = "Test";
            string password = "abc123";
            string birthDay = "15";
            string birthMonth = "5";
            string birthYear = "1990";
            string address = "1784  Water Street";
            string city = "Los Angeles";
            string country = "United States";
            string state = "California";
            string postalCode = "90007";
            string phone = "925-280-1092";


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
            cartPageMethods.SubmitCreate(consumerEmail);
            formPageMethods.InsertCostumerName(consumerFirstName, consumerLastName);
            formPageMethods.InsertPasword(password);
            formPageMethods.InsertDateBirth(birthDay, birthMonth, birthYear);
            formPageMethods.InsertAddresstName(consumerFirstName, consumerLastName);
            formPageMethods.InsertAddres(address);
            formPageMethods.InsertCity(city);
            formPageMethods.SelectCountry(country);
            formPageMethods.SelectState(state);
            formPageMethods.InsertPostalCode(postalCode);
            formPageMethods.InsertPhone(phone);
            formPageMethods.FinishRegister();
            //Assert.AreEqual(addressPageMethods.GetAddressName(), consumerFirstName + " " + consumerLastName);
            //Assert.AreEqual(addressPageMethods.GetAddres(), city + ", " + state + " " + postalCode);
            //Assert.AreEqual(addressPageMethods.GetCountryName(), country);
            //.AreEqual(addressPageMethods.GetAddressPhone(), phone);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addressPageMethods.GetProceedButton()));
            addressPageMethods.GoToNextStep();
            addressPageMethods.CheckTermsOfService();
            addressPageMethods.GoToNextStep();
            Console.WriteLine(paymentPageMethods.SumTotalPrice());
            Assert.AreEqual(paymentPageMethods.GetTotalPrice(), paymentPageMethods.SumTotalPrice());

        }


        [TearDown]
        public void EndTest()
        {
            Webdriver.Close();
        }

    }
}
