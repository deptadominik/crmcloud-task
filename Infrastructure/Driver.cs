using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using crmcloud.Infrastructure.Constants;
using OpenQA.Selenium;
using System;

namespace crmcloud.Infrastructure
{
    public class Driver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public Driver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    driver = new ChromeDriver(new ChromeOptions());
                    _scenarioContext.Set(driver, "Chrome");
                    return driver;
                case "Edge":
                    driver = new EdgeDriver(new EdgeOptions());
                    _scenarioContext.Set(driver, "Edge");
                    return driver;
                default:
                    throw new ArgumentException($"The browser type {browserType} is currently not supported. " +
                        "Check configuration file.");
            }
        }
    }
}