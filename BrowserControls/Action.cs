using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace crmcloud.BrowserControls
{
    public static class Action
    {
        public static void Hover(IWebElement element)
        {
            new Actions((element as IWrapsDriver).WrappedDriver)
                .MoveToElement(element)
                .Perform();
        }

        public static void JavaScriptClick(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}