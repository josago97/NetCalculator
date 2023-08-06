namespace NetCalculator.Common.Models;

public abstract class BaseCalculator
{
    // Net and broadcast address
    public const int RESERVED_ADDRESS_COUNT = 2;
    public const int BITS_PER_ADDRESS = 32;
    
    public static long MaxNetSize(int bitsAddress)
    {
        return (long)Math.Pow(2, bitsAddress);
    }
}
