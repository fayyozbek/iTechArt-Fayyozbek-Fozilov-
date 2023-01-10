Feature: CalculatorSum
In order to use sum function
As user
I want to sum 2 numbers

    Scenario: Add two numbers
        Given I have the first number 3
        And I have the second number 2
        When I want to sum this numbers
        Then the result should be 5