Feature: Login
	In oder to use login function
	As user
	I want to login to website 
	
Scenario: Successful Login
	Given I go to website https://www.saucedemo.com
	And I fill in form username as standard_user
	And I fill in form password as secret_sauce
	And I click on button login
	When I login to website
	Then I see label products
