using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomacao.PageObjects
{
    public static class HomepagePageObjects
    {
        public static By signInButton = By.ClassName("login");
        public static By productContainer = By.ClassName("product-container");
    }

    public class HomePageMethods
    {
        IWebDriver webDriver;
        public HomePageMethods(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void SelectProduct(string productName)
        {         
            try
            {                
                webDriver.FindElement(By.PartialLinkText(productName)).Click();                
            }
            catch (Exception)
            {

                throw new Exception(string.Format("product not found"));
            }
            
        }



    }
}
