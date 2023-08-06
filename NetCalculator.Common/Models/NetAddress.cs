namespace NetCalculator.Common.Models;

public struct NetAddress
{
    private const int RESERVED_ADDRESS_COUNT = BaseCalculator.RESERVED_ADDRESS_COUNT;

    public IPv4Address Ip { get; init; }
    public int Mask { get; init; }
    public ulong Size { get; init; }
    public uint Hosts { get; init; }

    public static NetAddress Parse(string cidr)
    {
        string[] ipAndMask = cidr.Split('/');
        string ip = ipAndMask[0];
        int mask = int.Parse(ipAndMask[1]);

        return new NetAddress(ip, mask);
    }

    public static NetAddress Parse(string ip, string mask)
    {
        int maskNumber = mask.Split('.').Select(octet =>
        {
            int decimalValue = int.Parse(octet);
            string binaryValue = Convert.ToString(decimalValue, 2);

            return binaryValue;
        })
        .Sum(binary => binary.Count(c => c == '1'));

        return new NetAddress(ip, maskNumber);
    }

    public NetAddress(IPv4Address ip, int mask)
    {
        Ip = ip;
        Mask = mask;

        Size = (ulong)Math.Pow(2, 32 - Mask);
        Hosts = (uint)(Size - RESERVED_ADDRESS_COUNT);
    }

    public NetAddress(string ip, int mask) : this(new IPv4Address(ip), mask)
    {
    }
}
