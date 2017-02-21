Feature: SpecFlow
	In order login to website
	As a user
	I want to be able to fill in login form

Scenario: Successfull login
	Given I'm on login website
		And I have entered username
		And I have entered password
	When I click login button
	Then I should be logged in