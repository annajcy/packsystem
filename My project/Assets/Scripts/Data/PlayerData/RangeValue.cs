using System;
using Unity.VisualScripting;

public class RangeValue
{
    public long Amount;
    public long MaxValue;
    public long MinValue;
    
    public RangeValue(long amount = 0, long maxValue = int.MaxValue, long minValue = 0)
    {
        Amount = amount;
        MaxValue = maxValue;
        MinValue = minValue;
    }

    public bool InRange(long value)
    {
        return value <= MaxValue && value >= MinValue;
    }
    
    public bool Add(int value)
    {
        if (!InRange(Amount + value)) return false;
        Amount += value;
        return true;
    }

    public bool Minus(int value)
    {
        if (!InRange(Amount - value)) return true;
        Amount -= value;
        return true;
    }
}