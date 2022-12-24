using crmcloud.BrowserControls;
using OpenQA.Selenium;
using Polly;
using System;
using System.Threading;

namespace crmcloud.PageObjects.Components
{
    public class ContactForm
    {
        private IWebDriver driver;
        private readonly IWebElement form;

        private readonly By formSelector = By.Id("DetailForm");
        private readonly By firstNameInput = By.Id("DetailFormfirst_name-input");
        private readonly By lastNameInput = By.Id("DetailFormlast_name-input");
        private readonly By businessRoleDropdown = By.XPath("//*[@id='DetailFormbusiness_role-input']/div");
        private readonly By categoryDropdown = By.XPath("//*[@id='DetailFormcategories-input']");
        private readonly By categorySearchInput = By.XPath("//*[@id='DetailFormcategories-input-search-text']//input");
        private readonly By teamsDropdown = By.XPath("//*[@aria-label='teams']");
        private readonly By saveButton = By.Id("DetailForm_save");
        private readonly By deleteButton = By.Id("DetailForm_delete");
        private readonly By contactFormHeader = By.XPath("//*[@id='_form_header']/h3");
        private readonly By businessRole = By.XPath("//p[@class='form-label' and text()='Business Role']/following-sibling::div");
        private readonly By category = By.XPath("//p[@class='form-label' and text()='Category']/parent::li");

        public ContactForm(IWebDriver driver)
        {
            this.driver = driver;
            form = driver.WaitForElementToAppear(formSelector);

            //wait until form will be loaded
            Policy
                .HandleResult<string>(x => x != "(none)")
                .WaitAndRetry(retryCount: 10, sleepDurationProvider: _ => TimeSpan.FromSeconds(1))
                .Execute(() => driver.FindElement(teamsDropdown).GetAttribute("innerHTML"));
        }

        public ContactForm FillFirstName(string firstName)
        {
            var input = form.FindElement(firstNameInput);
            input.Clear();
            input.SendKeys(firstName);

            return this;
        }

        public ContactForm FillLastName(string lastName)
        {
            var input = form.FindElement(lastNameInput);
            input.Clear();
            input.SendKeys(lastName);

            return this;
        }

        public ContactForm SelectBusinessRole(string businessRole)
        {
            var dropdown = driver.WaitForElementToAppear(businessRoleDropdown);
            driver.JavaScriptClick(dropdown);
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption(businessRole)).Click();

            return this;
        }

        public ContactForm SelectCategory(string category)
        {
            var dropdown = driver.WaitForClickableElement(driver.FindElement(categoryDropdown));
            driver.JavaScriptClick(dropdown);
            driver.WaitForElementToAppear(categorySearchInput).SendKeys(category);
            driver.WaitForClickableElement(driver
                .FindElement(SeleniumBy.DropdownOption(category))).Click();

            return this;
        }

        public ContactForm SaveContact()
        {
            driver.FindElement(saveButton).Click();
            driver.WaitForElementToAppear(contactFormHeader);

            return this;
        }

        public ContactForm DeleteContact()
        {
            driver.WaitForElementToAppear(deleteButton).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(500);

            return this;
        }

        public string GetFirstAndLastName()
            => driver.FindElement(contactFormHeader).Text;

        public string GetBusinessRole()
            => driver.FindElement(businessRole).Text;

        public string GetCategory()
            => driver.FindElement(category).Text;
    }
}