using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using TesteAutomacao.PageObjects;

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
            OpenQA.Selenium.Support.UI.WebDriverWait webDriverWait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void AcessProduct()
        {
            HomePageMethods homePageMethods = new HomePageMethods(Webdriver);
            homePageMethods.SelectProduct("Faded Short Sleeve T-shirts");
        }

        [TearDown]
        public void EndTest()
        {
            Webdriver.Close();
        }

    }
}
