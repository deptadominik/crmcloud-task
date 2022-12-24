using OpenQA.Selenium;

namespace crmcloud.BrowserControls
{
	public class SeleniumBy : By
	{
		protected SeleniumBy() : base()
		{
		}

		public static By DataTabId(string selector)
		{
			return CssSelector($"[data-tab-id='{selector}']");
		}

		public static By DropdownOption(string option)
		{
			return XPath($"//div[contains(@class,'option-cell') and contains(@class,'input-label') and text()='{option}']");
		}
	}
}