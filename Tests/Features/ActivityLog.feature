Feature: ActivityLog

User is able to delete items from Activity Log

@activityLogTest
Scenario: Verify deleting items from Activity Log
	Given I login and navigate to Reports & Settings -> Activity Log
	When I select 3 items in the table
	And I click the Delete button from Actions dropdown
	Then 3 items are deleted
