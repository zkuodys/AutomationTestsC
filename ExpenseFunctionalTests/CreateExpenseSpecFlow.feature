Feature: Application
	In order to create expense form
	As a user
	I want to be able to fill in form

Scenario: Expense creted successfully
	Given I'm logged in as a user
		And I'm on create expense screen
		And I have set date on receipt
		And I have set currency
		And I have set expense type
		And I have set amount of money i've spent
		And I have filled the description
	When I press send button
	Then Expense should be created