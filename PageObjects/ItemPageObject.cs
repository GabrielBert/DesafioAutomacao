using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacao.PageObjects
{
    public static class ItemPageObjects
    {
        public static By addToCartButton = By.Id("add_to_cart");
        public static By layerCart = By.Id("layer_cart");
        public static By goToCheckouButton = By.PartialLinkText("Proceed to checkout");
    }

    public class ItemMethods
    {
        IWebDriver webDriver;


        public ItemMethods(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void AddToCart()
        {
            webDriver.FindElement(ItemPageObjects.addToCartButton).Click();
        }

        public void GoToCheckout()
        {

            if (webDriver.FindElement(ItemPageObjects.layerCart).Displayed)
            {
                webDriver.FindElement(ItemPageObjects.goToCheckouButton).Click();
            }
        }
    }
}
