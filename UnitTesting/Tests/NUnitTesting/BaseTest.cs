using NUnit.Framework;

namespace UnitTesting.Tests.NUnitTesting;

[TestFixture]
[SetUpFixture]
[Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]
public abstract class BaseTest
{
    protected Memory memory;


    protected ICalculator Calculator { get; private set; }

    [SetUp]
    public void Setup()
    {
        Calculator = new Calculator();
    }
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        memory = new Memory();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        memory.ClearMemory();
    }
}