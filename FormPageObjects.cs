using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacao.PageObjects
{
    public static class FormPageObjects
    {
        public static By costumerFirstNameForm = By.Id("customer_firstname");
        public static By costumerLastNameForm = By.Id("customer_lastname");
        public static By passwordForm = By.Id("passwd");
        public static By birthDay = By.Id("days");
        public static By birthMonth = By.Id("months");
        public static By birthYear = By.Id("years");
        public static By addressFirstNameForm = By.Id("firstname");
        public static By addressLastNameForm = By.Id("lastname");
        public static By addressForm = By.Id("address1");
        public static By cityForm = By.Id("city");
        public static By stateDropdown = By.Id("id_state");
        public static By postalCodeForm = By.Id("postcode");
        public static By countryDropDown = By.Id("id_country");
        public static By mobileForm = By.Id("phone_mobile");
        public static By aliasForm = By.Id("alias");
        public static By registerButton = By.Id("submitAccount");
    }

    public class FormPageMethods
    {
        IWebDriver webDriver;

        public FormPageMethods(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void InsertCostumerName(string firstName, string lastName)
        {
            webDriver.FindElement(FormPageObjects.costumerFirstNameForm).SendKeys(firstName);
            webDriver.FindElement(FormPageObjects.costumerLastNameForm).SendKeys(lastName);
        }

        public void InsertPasword(string password)
        {
            webDriver.FindElement(FormPageObjects.passwordForm).SendKeys(password);
        }

        public void InsertDateBirth(string birthDay, string birthMonth, string birthYear)
        {
            var selectBirthDay = new SelectElement(webDriver.FindElement(FormPageObjects.birthDay));
            var selectBirthMonth = new SelectElement(webDriver.FindElement(FormPageObjects.birthMonth));
            var selectBirthYear = new SelectElement(webDriver.FindElement(FormPageObjects.birthYear));

            selectBirthDay.SelectByValue(birthDay);
            selectBirthMonth.SelectByValue(birthMonth);
            selectBirthYear.SelectByValue(birthYear);
        }

        public void InsertAddresstName(string firstName, string lastName)
        {
            webDriver.FindElement(FormPageObjects.addressFirstNameForm).SendKeys(firstName);
            webDriver.FindElement(FormPageObjects.addressLastNameForm).SendKeys(lastName);
        }

        public void InsertAddres(string address)
        {
            webDriver.FindElement(FormPageObjects.addressForm).SendKeys(address);
        }

        public void InsertCity(string cityName)
        {
            webDriver.FindElement(FormPageObjects.cityForm).SendKeys(cityName);
        }

        public void SelectCountry(string countryName)
        {
            var selectCountry = new SelectElement(webDriver.FindElement(FormPageObjects.countryDropDown));

            selectCountry.SelectByText(countryName);
        }

        public void SelectState(string stateName)
        {
            var selectState = new SelectElement(webDriver.FindElement(FormPageObjects.stateDropdown));

            selectState.SelectByText(stateName);
        }

        public void InsertPostalCode(string postalcode)
        {
            webDriver.FindElement(FormPageObjects.postalCodeForm).SendKeys(postalcode);
        }

        public void InsertAlias(string alias)
        {
            webDriver.FindElement(FormPageObjects.aliasForm).SendKeys(alias);
        }
        public void InsertPhone(string number)
        {
            webDriver.FindElement(FormPageObjects.mobileForm).SendKeys(number);
        }

        public void FinishRegister()
        {
            webDriver.FindElement(FormPageObjects.registerButton).Click();
        }
    }
}
