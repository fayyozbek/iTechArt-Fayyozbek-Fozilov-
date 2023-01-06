namespace UnitTesting;

public class Memory
{
    public double memoryValue { get; set; }

    public Memory()
    {
        this.memoryValue = 0;
    }


    public void AddToMemory(double value)
    {
        this.memoryValue += value;
    }

    public void MinusFromMemory(double value)
    {
        this.memoryValue -= value;
    }

    public void ClearMemory()
    {
        this.memoryValue = 0;
    }
}