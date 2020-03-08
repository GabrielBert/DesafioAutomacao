using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacao.PageObjects
{

    public static class CartPageObjects
    {
        public static By cartTitle = By.Id("cart_title");
        public static By productName = By.ClassName("product-name");
        public static By checkoutButton = By.PartialLinkText("Proceed to checkout");
        public static By createAccountButton = By.Id("SubmitCreate");
        public static By breadcrumb = By.ClassName("breadcrumb");
        public static By emailInput = By.Id("email_create");
    }

    public class CartPageMethods
    {
        IWebDriver webDriver;

        public CartPageMethods(IWebDriver driver)
        {
            this.webDriver = driver;
        }


        public void CheckoutNextStep()
        {
            webDriver.FindElement(CartPageObjects.checkoutButton).Click();
        }

        public String GetBreadcrumb()
        {
            string title = webDriver.FindElement(CartPageObjects.breadcrumb).Text;
            return title;
        }

        public String GetProductName()
        {
            string productName = webDriver.FindElement(CartPageObjects.productName).Text;
            return productName;
        }

        public void InsertEmail(string email)
        {
            webDriver.FindElement(CartPageObjects.emailInput).SendKeys(email);
        }

        public void SubmitCreate(String email)
        {
            InsertEmail(email);
            webDriver.FindElement(CartPageObjects.createAccountButton).Click();
        }


    }
}
