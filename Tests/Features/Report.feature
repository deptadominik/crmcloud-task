Feature: Report

User is able to run Project Profitability report

@reportTest
Scenario: Verify running Project Profitability report
	Given I login and navigate to Reports & Settings -> Reports
	When I insert 'Project Profitability' into search bar and click the report
	And I run the report
	Then report is executed and results appear below
