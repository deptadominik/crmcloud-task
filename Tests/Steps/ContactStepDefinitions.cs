using crmcloud.Hooks;
using crmcloud.Infrastructure.Constants;
using crmcloud.PageObjects.Components;
using crmcloud.PageObjects.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace crmcloud.Steps
{
    [Binding]
    public class ContactStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ContactForm contactForm;
        private IWebDriver driver;

        public ContactStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>(Initialization.config.BrowserType);
        }

        [Given(@"I login and navigate to Sales & Marketing -> Contacts")]
        public void GivenILoginAndNavigateToSalesMarketing_Contacts()
        {
            contactForm = new HomeDashboardPage(driver)
                .GoToContactsModule()
                .ClickCreateNewContact();
        }

        [Given(@"I insert the following data")]
        public void GivenIInsertTheFollowingData(Table table)
        {
            var user = table.CreateDynamicSet().First();
            contactForm
                .SelectCategory(user.category1)
                .SelectBusinessRole(user.role)
                .FillFirstName(user.firstName)
                .FillLastName(user.lastName)
                .SelectCategory(user.category2);
        }

        [When(@"I click the save button")]
        public void WhenIClickTheSaveButton()
        {
            contactForm.SaveContact();
        }

        [Then(@"contact will be created with this data")]
        public void ThenContactWillBeCreatedWithThisData(Table table)
        {
            var user = table.CreateDynamicSet().First();
            contactForm.GetFirstAndLastName().Should().Contain($"{user.firstName} {user.lastName}");
            contactForm.GetBusinessRole().Should().Be(user.role);
            contactForm.GetCategory().Should().Contain($"{user.category1}, {user.category2}");

            // Contact is deleted via GUI
            // Database cleanup should always be done in hooks, but for this application there is no way to send HTTP requests
            contactForm.DeleteContact();
        }

    }
}