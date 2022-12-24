using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace crmcloud.BrowserControls
{
    public static class Wait
    {
        public static IWebElement WaitForClickableElement(this IWebDriver driver, IWebElement element)
            => new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ElementToBeClickable(element));

        public static IWebElement WaitForElementToAppear(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(x => x.FindElement(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        private static Func<ISearchContext, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return (searchContext) =>
            {
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }
    }
}