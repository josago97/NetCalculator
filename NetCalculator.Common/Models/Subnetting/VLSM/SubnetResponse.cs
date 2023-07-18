namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class SubnetResponse : Subnet
{
    public string Name { get; init; }
    public uint NeededSize { get; init; }

    public SubnetResponse(NetAddress address) : base(address)
    {
    }
}
