namespace UnitTesting;

public class Calculator
{
    

   

    public static double Calculations(char charOperator , double a ,double b)
    {
        double total = 0;
        switch (charOperator)
        {
            case '+':
                total = a + b;
                break;
            case '-':
                total = a - b;
                break;
            case '/':
                total = a / b;
                break;
            case '*':
                total = a * b;
                break;
        }

        return total;
    }

    public static double Percentage(double a, double b)
    {
        double total = a * (b / 100);
        return total;
    }
    
}