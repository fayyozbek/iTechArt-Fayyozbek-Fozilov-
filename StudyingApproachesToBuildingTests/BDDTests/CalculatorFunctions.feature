Feature: CalculatorSum
In order to use sum function
As user
I want to sum 2 numbers

    Scenario: Add two numbers
        Given I start calculator
        And I have the first number 3
        And I have the second number 2
        When I want to sum this numbers
        Then the result should be 5
        
Feature: CalculatorSubtraction
In order to use subtraction function
As user
I want to subtract 2 numbers

    Scenario: Subtract two numbers
        Given I start calculator
        And I have the first number 3
        And I have the second number 2
        When I want to subtraction this numbers
        Then the result should be 1
        
Feature: CalculatorMultiplication
In order to use multiplication function
As user
I want to multiply 2 numbers

    Scenario: Multiply two numbers
        Given I start calculator
        And I have the first number 3
        And I have the second number 2
        When I want to multiply this numbers
        Then the result should be 6
        
Feature: CalculatorDivision
In order to use divide function
As user
I want to divide 2 numbers

    Scenario: Divide two numbers
        Given I start calculator
        And I have the first number 6
        And I have the second number 2
        When I want to divide this numbers 
        Then the result should be 3