namespace NetCalculator.Common.Models;

public struct IPv4Address
{
    // Last byte is the most significant
    private byte[] _address;

    public IPv4Address(byte[] address, bool firstByteMostSignificant = true)
    {
        if (address.Length != 4)
            throw new ArgumentException("An Ipv4 address needs 4 bytes");

        if (firstByteMostSignificant)
            address = address.Reverse().ToArray();

        _address = address;
    }

    public IPv4Address(string address)
        : this(address.Split(".").Select(byte.Parse).ToArray())
    {
    }

    public IPv4Address Add(uint amount)
    {
        uint address = BitConverter.ToUInt32(_address, 0);
        address = address + amount;
        byte[] resultAddress = BitConverter.GetBytes(address);

        return new IPv4Address(resultAddress, false);
    }

    public override string ToString()
    {
        return string.Join('.', _address.Reverse());
    }
}
