using crmcloud.BrowserControls;
using crmcloud.PageObjects.Components;
using OpenQA.Selenium;

namespace crmcloud.PageObjects.Pages
{
    public class ContactsPage
    {
        private IWebDriver driver;

        private readonly By contactsDashboard = By.XPath("//form[@name='TabForm']");
        private readonly By createContactButton = By.XPath("//button[@name='SubPanel_create']");

        public ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(contactsDashboard);
        }

        public ContactForm ClickCreateNewContact()
        {
            driver.WaitForElementToAppear(createContactButton).Click();

            return new ContactForm(driver);
        }
    }
}