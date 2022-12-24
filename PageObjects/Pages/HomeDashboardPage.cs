using crmcloud.BrowserControls;
using crmcloud.PageObjects.Components;
using OpenQA.Selenium;

namespace crmcloud.PageObjects.Pages
{
    public class HomeDashboardPage
    {
        private IWebDriver driver;
        private By homeDashboardSelector = By.Id("main-title");

        public HomeDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(homeDashboardSelector);
        }

        public ContactsPage GoToContactsModule() => new NavBar(driver).SelectContactsFromSalesAndMarketingSection();

        public ReportsPage GoToReportsModule() => new NavBar(driver).SelectReportsFromReportsAndSettingsSection();

        public ActivityLogPage GoToActivityLogModule() => new NavBar(driver).SelectActivityLogFromReportsAndSettingsSection();
    }
}