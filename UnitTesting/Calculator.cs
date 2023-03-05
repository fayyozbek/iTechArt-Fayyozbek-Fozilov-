using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using static UnitTesting.Utilities.Logger;

namespace UnitTesting;

public class Calculator : ICalculator
{
    private readonly ILogger _logger;
    private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;

    private  ITestOutputHelper OutputHelper =>_testOutputHelperAccessor.Output;

    public Calculator()
    {
        _logger = new Logger<Calculator>(new LoggerFactory());
    }
    public Calculator(ITestOutputHelperAccessor testOutputHelperAccessor)
    {
        _testOutputHelperAccessor = testOutputHelperAccessor; 
        _logger =OutputHelper.ToLogger<ICalculator>();
    }
    
    public double Calculations(char charOperator , double a ,double b)
    {
        double total = 0;
        
        Instance.Info($" There are two numbers a : {a} and b : {b} " );
        _logger.LogInformation($" There are two numbers a : {a} and b : {b} " );
        switch (charOperator)
        {
            case '+':
                 Instance.Info("Sum up of this numbers");
                _logger.LogInformation("Sum up of this numbers");
                total = a + b;
                break;
            case '-':
                 Instance.Info("a minus b ");
                _logger.LogInformation("a minus b ");
                total = a - b;
                break;
            case '/':
                 Instance.Info("a divide b");
                _logger.LogInformation("a divide b");
                total = a / b;
                break;
            case '*':
                 Instance.Info("Multiplication of this numbers");
                _logger.LogInformation("Multiplication of this numbers");
                total = a * b;
                break;
        }
         Instance.Info($"The result is {total}");
        _logger.LogInformation($"The result is {total}");
        return total;
    }

    public  double Percentage(double a, double b)
    {
        Instance.Info($"{b}% in {a}");
        _logger.LogInformation($"{b}% in {a}");
        double total = a * (b / 100);
        
        Instance.Info($"The result is {total}");
        _logger.LogInformation($"The result is {total}");
        return total;
    }
}