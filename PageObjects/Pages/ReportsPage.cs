using crmcloud.BrowserControls;
using OpenQA.Selenium;
using System.Threading;

namespace crmcloud.PageObjects.Pages
{
    public class ReportsPage
    {
        private readonly IWebDriver driver;

        private readonly By reportsDashboard = By.XPath("//form[@name='TabForm']");
        private readonly By reportsSearchBarInput = By.Id("filter_text");
        private By Report(string name) => By.XPath($"//*[@class='listViewNameLink' and text()='{name}']");

        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(reportsDashboard);
        }

        public ReportsPage InsertIntoSearchBar(string text)
        {
            var input = driver.FindElement(reportsSearchBarInput);
            input.Clear();
            input.SendKeys(text);
            Thread.Sleep(1000); // in order to handle flicker behaviour
            input.SendKeys(Keys.Enter);
            return this;
        }

        public ReportManagementPage ClickReport(string text)
        {
            driver.WaitForElementToAppear(Report(text)).Click();

            return new ReportManagementPage(driver);
        }
    }
}