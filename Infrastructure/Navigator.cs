using crmcloud.Infrastructure.Constants;
using crmcloud.PageObjects.Pages;
using OpenQA.Selenium;

namespace crmcloud.Infrastructure
{
    public static class Navigator
    {
        public static LoginPage GoToLoginPage(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Urls.loginPage);

            return new LoginPage(driver);
        }

        public static ContactsPage GoToContactsModule(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Urls.contactsModule);

            return new ContactsPage(driver);
        }
    }
}