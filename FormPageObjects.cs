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
        public static By firstNameForm = By.Id("customer_firstname");
        public static By lastNameForm = By.Id("customer_lastname");
        public static By passwordForm = By.Id("passwd");
        public static By birthDay = By.Id("days");
        public static By birthMonth = By.Id("months");
        public static By birthYear = By.Id("years");
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

        public void InsertName(string firstName, string lastName)
        {
            webDriver.FindElement(FormPageObjects.firstNameForm).SendKeys(firstName);
            webDriver.FindElement(FormPageObjects.lastNameForm).SendKeys(lastName);
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

            selectBirthDay.SelectByText(birthDay);
            selectBirthMonth.SelectByText(birthMonth);
            selectBirthYear.SelectByText(birthYear);
        }

        public void InsertAlias(string alias)
        {
            webDriver.FindElement(FormPageObjects.aliasForm).SendKeys(alias);
        }
        public void InsertPhone(string number)
        {
            webDriver.FindElement(FormPageObjects.mobileForm).SendKeys(number);
        }

        public void fillSigninForm(string firstName, string lastName, string password, string birthDay, string birthMonth, string birthYear,string address, string city, string state,string country, string number, string alias) { }
    }
}
