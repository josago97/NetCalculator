using System.Net;

namespace NetCalculator.Common.Utilities;

internal static class Utils
{
    public static string MaskIntToString(int mask)
    {
        uint maskBits = uint.MaxValue << (32 - mask);
        byte[] maskBytes = BitConverter.GetBytes(maskBits).Reverse().ToArray();
        IPAddress maskIp = new IPAddress(maskBytes);

        return maskIp.ToString();
    }
}
