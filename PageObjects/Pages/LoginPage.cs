using crmcloud.BrowserControls;
using OpenQA.Selenium;

namespace crmcloud.PageObjects.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private IWebElement form;
        private By formSelector = By.XPath("//form[@name='LoginForm']");
        private By userNameInput = By.Id("login_user");
        private By passwordInput = By.Id("login_pass");
        private By languageSelect = By.Id("login_lang");
        private By englishOption = By.XPath("//option[@value='en_us']");
        private By themeSelect = By.Id("login_theme");
        private By themeOption = By.XPath("//option[@value='Claro']");
        private By loginButton = By.Id("login_button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            form = driver.WaitForElementToAppear(formSelector);
        }

        public LoginPage FillLoginForm()
        {
            form.FindElement(userNameInput).SendKeys("admin");
            form.FindElement(passwordInput).SendKeys("admin");
            form.FindElement(languageSelect).Click();
            form.FindElement(englishOption).Click();
            form.FindElement(themeSelect).Click();
            form.FindElement(themeOption).Click();

            return this;
        }

        public HomeDashboardPage Login()
        {
            form.FindElement(loginButton).Click();

            return new HomeDashboardPage(driver);
        }
    }
}