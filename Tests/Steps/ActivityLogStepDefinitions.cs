using crmcloud.Hooks;
using crmcloud.Infrastructure.Constants;
using crmcloud.PageObjects;
using crmcloud.PageObjects.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace crmcloud.Steps
{
    [Binding]
    public class ActivityLogStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ActivityLogPage activityLogPage;
        private string[] initialVisibleEntries;
        private IWebDriver driver;

        public ActivityLogStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>(Initialization.config.BrowserType);
        }

        [Given(@"I login and navigate to Reports & Settings -> Activity Log")]
        public void GivenILoginAndNavigateToReportsSettings_ActivityLog()
        {
            activityLogPage = new HomeDashboardPage(driver).GoToActivityLogModule();
        }

        [When(@"I select (.*) items in the table")]
        public void WhenISelectItemsInTheTable(int itemsAmount)
        {
            initialVisibleEntries = activityLogPage.GetAllEntriesFromFirstPage();
            activityLogPage.SelectItemsFromTable(itemsAmount);
        }

        [When(@"I click the Delete button from Actions dropdown")]
        public void WhenIClickTheDeleteButtonFromActionsDropdown()
        {
            activityLogPage.DeleteSelectedItems();
        }

        [Then(@"(.*) items are deleted")]
        public void ThenItemsAreDeleted(int itemsAmount)
        {
            activityLogPage
                .GetAllEntriesFromFirstPage()
                .Should()
                .NotBeEquivalentTo(initialVisibleEntries);
        }
    }
}