namespace UnitTesting;

public interface IMemory
{
    public double MemoryValue { get; set; }

    public void AddToMemory(double value);
    public void MinusFromMemory(double value);
    public void ClearMemory();



}