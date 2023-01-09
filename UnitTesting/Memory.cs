namespace UnitTesting;

public class Memory
{
    public double MemoryValue { get; set; }

    public Memory()
    {
        this.MemoryValue = 0;
    }

    public void AddToMemory(double value)
    {
        this.MemoryValue += value;
    }

    public void MinusFromMemory(double value)
    {
        this.MemoryValue -= value;
    }

    public void ClearMemory()
    {
        this.MemoryValue = 0;
    }
}