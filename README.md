# crmcloud-task

Automated tests written for CRM platform: https://demo.1crmcloud.com/

Tech stack: C# + SpecFlow + Selenium + NUnit + LivingDoc

In order to generate HTML report after test execution, simply navigate to `crmcloud-task` folder and execute the following line in CLI:

`livingdoc test-assembly bin/Debug/net5.0/crmcloud.dll -t TestExecution.json`

This will generate the `LivingDoc.html` file, which you can open in any browser.
