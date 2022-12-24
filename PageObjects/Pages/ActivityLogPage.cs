using crmcloud.BrowserControls;
using OpenQA.Selenium;
using System.Linq;
using System.Threading;

namespace crmcloud.PageObjects.Pages
{
    public class ActivityLogPage
    {
        private readonly IWebDriver driver;

        private By actionsButton = By.XPath("//div[contains(@class,'panel-subheader')]//button[contains(@class,'input-button') and contains(@class,'menu-source')]");
        private By entry = By.XPath("//td[@class='listViewTd']");
        private By checkbox = By.XPath("//div[@class='input-check']/input");

        public ActivityLogPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.WaitForElementToAppear(actionsButton);
        }

        public string[] GetAllEntriesFromFirstPage() => driver.FindElements(entry).Select(x => x.Text).ToArray();

        public ActivityLogPage SelectItemsFromTable(int amount)
        {
            Thread.Sleep(500);
            driver.FindElements(checkbox).Take(amount + 1).Skip(1).ToList().ForEach(x => x.Click());

            return this;
        }

        public ActivityLogPage DeleteSelectedItems()
        {
            driver.FindElement(actionsButton).Click();
            driver.WaitForElementToAppear(SeleniumBy.DropdownOption("Delete")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(500);

            return this;
        }
    }
}