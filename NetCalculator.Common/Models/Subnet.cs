namespace NetCalculator.Common.Models;

public class Subnet
{
    private const int RESERVED_ADDRESS_COUNT = BaseCalculator.RESERVED_ADDRESS_COUNT;

    public NetAddress Address { get; init; }
    public uint Size => Address.Size;
    public uint Hosts => Address.Hosts;
    public IPv4Address? FirstAssignableAddress { get; protected set; }
    public IPv4Address? LastAssignableAddress { get; protected set; }
    public IPv4Address? Broadcast { get; protected set; }

    public Subnet(NetAddress address) 
    {
        Address = address;

        CalculateAddresses();
    }

    protected virtual void CalculateAddresses()
    {
        if (Size >= RESERVED_ADDRESS_COUNT)
        {
            IPv4Address ip = Address.Ip;

            if (Hosts > 0)
            {
                FirstAssignableAddress = ip = ip.Add(1);
                LastAssignableAddress = ip = ip.Add(Hosts - 1);
            }

            Broadcast = ip.Add(1);
        }
    }
}
