using crmcloud.Hooks;
using crmcloud.Infrastructure.Constants;
using crmcloud.PageObjects.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace crmcloud.Steps
{
    [Binding]
    public class ReportStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ReportsPage reportsPage;
        private ReportManagementPage reportManagementPage;
        private IWebDriver driver;

        public ReportStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>(Initialization.config.BrowserType);
        }

        [Given(@"I login and navigate to Reports & Settings -> Reports")]
        public void GivenILoginAndNavigateToReportsSettings_Reports()
        {
            reportsPage = new HomeDashboardPage(driver).GoToReportsModule();
        }

        [When(@"I insert '([^']*)' into search bar and click the report")]
        public void WhenIInsertIntoSearchBarAndClickTheReport(string name)
        {
            reportManagementPage = reportsPage
                .InsertIntoSearchBar(name)
                .ClickReport(name);
        }

        [When(@"I run the report")]
        public void WhenIRunTheReport()
        {
            reportManagementPage.ClickRunReport();
        }

        [Then(@"report is executed and results appear below")]
        public void ThenReportIsExecutedAndResultsAppearBelow()
        {
            reportManagementPage.AreAnyResultsReturned().Should().BeTrue();
        }
    }
}