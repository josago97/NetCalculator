namespace NetCalculator.Common.Models.Netting;

public class Response : Subnet
{
    public IPv4Address? DefaultGatewayAddress { get; private set; }

    public Response(NetAddress address) : base(address)
    {
    }

    protected override void CalculateAddresses()
    {
        base.CalculateAddresses();

        if (Hosts > 0)
        {
            DefaultGatewayAddress = FirstAssignableAddress;
            FirstAssignableAddress = FirstAssignableAddress?.Add(1);
        }
    }
}
