using crmcloud.BrowserControls;
using crmcloud.PageObjects.Pages;
using OpenQA.Selenium;
using Action = crmcloud.BrowserControls.Action;

namespace crmcloud.PageObjects.Components
{
    public class NavBar
    {
        private IWebDriver driver;
        private By navBarSelector = By.ClassName("menubar-main");
        private By salesAndMarketingSection = SeleniumBy.DataTabId("LBL_TABGROUP_SALES_MARKETING");
        private By reportsAndSettingsSection = SeleniumBy.DataTabId("LBL_TABGROUP_REPORTS_SETTINGS");

        public NavBar(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(navBarSelector);
        }

        public ContactsPage SelectContactsFromSalesAndMarketingSection()
        {
            Action.Hover(driver.WaitForElementToAppear(salesAndMarketingSection));
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption("Contacts")).Click();

            return new ContactsPage(driver);
        }

        public ReportsPage SelectReportsFromReportsAndSettingsSection()
        {
            Action.Hover(driver.WaitForElementToAppear(reportsAndSettingsSection));
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption("Reports")).Click();

            return new ReportsPage(driver);
        }

        public ActivityLogPage SelectActivityLogFromReportsAndSettingsSection()
        {
            Action.Hover(driver.WaitForElementToAppear(reportsAndSettingsSection));
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption("Activity Log")).Click();

            return new ActivityLogPage(driver);
        }
    }
}