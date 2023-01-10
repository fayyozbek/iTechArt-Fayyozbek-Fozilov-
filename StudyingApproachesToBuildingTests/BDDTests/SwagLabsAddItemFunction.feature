Feature: Add item
In oder to use add item to cart function
As user
I want to add item to cart 
	
    Scenario: Successful Add Item To Cart
        Given I go to website https://www.saucedemo.com
        And I fill in form username as standard_user
        And I fill in form password as secret_sauce
        And I click on button login
        And I click on button add to cart
        When I go to cart
        Then I see one item added to cart