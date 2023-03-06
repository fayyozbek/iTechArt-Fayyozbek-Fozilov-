using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using static UnitTesting.Utilities.Logger;


namespace UnitTesting;

public class Memory : IMemory
{
    private readonly ILogger _logger;
    private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;

    private  ITestOutputHelper OutputHelper =>_testOutputHelperAccessor.Output;
    
    public double MemoryValue { get; set; }
    
    public Memory(ITestOutputHelperAccessor testOutputHelperAccessor)
    {
        MemoryValue = 0;
        _testOutputHelperAccessor = testOutputHelperAccessor; 
        _logger =OutputHelper.ToLogger<IMemory>();
    }

    public Memory()
    {
        MemoryValue = 0;
        _logger = new Logger<Calculator>(new LoggerFactory());

    }

    public void AddToMemory(double value)
    {
        Instance.Info($" Add value : {value} to memory" );
        _logger.LogInformation($" Add value : {value} to memory" );
        MemoryValue += value;
        
        Instance.Info($" Now memory is {MemoryValue} " );
        _logger.LogInformation($" Now memory is {MemoryValue}" );
    }

    public void MinusFromMemory(double value)
    {
        Instance.Info($" Minus value : {value} from memory" );
        _logger.LogInformation($" Minus value : {value} from memory" );
        MemoryValue -= value;
        
        Instance.Info($" Now memory is {MemoryValue} " );
        _logger.LogInformation($" Now memory is {MemoryValue}" );
    }

    public void ClearMemory()
    {
        MemoryValue = 0;
        Instance.Info($" Clear memory, now memory is {MemoryValue}" );
        _logger.LogInformation($" Clear memory, now memory is {MemoryValue}" );
        
    }
}