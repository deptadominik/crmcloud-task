using crmcloud.Configuration;
using crmcloud.Infrastructure;
using crmcloud.Infrastructure.Constants;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using TechTalk.SpecFlow;

namespace crmcloud.Hooks
{
    [Binding]
    public sealed class Initialization
    {
        private readonly ScenarioContext _scenarioContext;
        private static readonly string configFilePath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/configuration.json";
        public static Config config;

        public Initialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            config = ReadConfiguration();

            var driver = new Driver(_scenarioContext).Setup(config.BrowserType);
            driver.Manage().Window.Maximize();

            // SendLoginRequest(); Request was sent correctly, but after navigating to required page
            // the login form was still present. I decided to implement login via GUI.
            driver
                .GoToLoginPage()
                .FillLoginForm()
                .Login();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>(config.BrowserType).Quit();
        }

        private void SendLoginRequest()
        {
            var client = new HttpClient();
            var message = new HttpRequestMessage(HttpMethod.Post, Urls.loginRequest);
            message.Content = JsonContent.Create(new
            {
                gmto = -60,
                language = "en_us",
                login_action = "index",
                login_layout = "",
                login_module = "Home",
                login_record = "",
                mobile = "0",
                password = "admin",
                remember = "",
                res_heigh = 845,
                res_width = 1745,
                theme = "Claro",
                username = "admin",
            });

            var response = client.Send(message);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private Config ReadConfiguration()
        {
            config = new Config();
            new ConfigurationBuilder()
                .AddJsonFile(configFilePath)
                .Build()
                .Bind(config);

            return config;
        }
    }
}