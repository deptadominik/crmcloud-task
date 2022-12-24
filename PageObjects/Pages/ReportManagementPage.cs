using crmcloud.BrowserControls;
using OpenQA.Selenium;

namespace crmcloud.PageObjects.Pages
{
    public class ReportManagementPage
    {
        private readonly IWebDriver driver;
        private readonly By runReportButton = By.XPath("//button[@name='FilterForm_applyButton']");
        private readonly By resultTable = By.XPath("//table[@class='listView']");
        private readonly By resultEntry = By.XPath("//div[@class='input-check']");

        public ReportManagementPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(runReportButton);
        }

        public ReportManagementPage ClickRunReport()
        {
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption("Not Pursued"));
            driver.FindElement(runReportButton).Click();
            driver.WaitForElementToAppear(resultTable);
            driver.WaitForElementToAppear(resultEntry);

            return this;
        }

        public bool AreAnyResultsReturned() => driver.FindElements(resultEntry).Count > 0;
    }
}