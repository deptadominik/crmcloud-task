Feature: Contact

User is able to create a new contact

@contactTest
Scenario: Verify creating a new contact
	Given I login and navigate to Sales & Marketing -> Contacts
	And I insert the following data
		| firstName | lastName | role | category1 | category2 |
		| Dominik   | Depta    | CEO  | Customers | Suppliers |
	When I click the save button
	Then contact will be created with this data
		| firstName | lastName | role | category1 | category2 |
		| Dominik   | Depta    | CEO  | Customers | Suppliers |