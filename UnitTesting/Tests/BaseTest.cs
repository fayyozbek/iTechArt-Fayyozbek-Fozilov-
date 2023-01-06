namespace UnitTesting.Tests;

[TestFixture]
[SetUpFixture]
[Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]
public abstract class BaseTest
{
    protected Memory memory;
    
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