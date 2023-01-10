Feature: CalculatorMultiplication
In order to use multiplication function
As user
I want to multiply 2 numbers

    Scenario: Multiply two numbers
        Given I have the first number 3
        And I have the second number 2
        When I want to multiply this numbers
        Then the result should be 6