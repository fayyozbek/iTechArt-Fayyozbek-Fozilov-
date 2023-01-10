Feature: CalculatorSubtraction
In order to use subtraction function
As user
I want to subtract 2 numbers

    Scenario: Subtract two numbers
        Given I have the first number 3
        And I have the second number 2
        When I want to subtraction this numbers
        Then the result should be 1