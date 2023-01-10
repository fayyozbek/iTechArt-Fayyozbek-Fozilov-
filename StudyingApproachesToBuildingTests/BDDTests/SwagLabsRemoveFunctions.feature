Feature: Remove item
In oder to use remove item to cart function
As user
I want to remove item from cart 
	
	Scenario: Successful Add Item To Cart
		Given I go to website https://www.saucedemo.com
		And I fill in form username as standard_user
		And I fill in form password as secret_sauce
		And I click on button login
		And I click on button add to cart
		When I go to cart
		And I click on button remove
		Then I see empty cart