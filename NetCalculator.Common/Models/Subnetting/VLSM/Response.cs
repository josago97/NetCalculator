namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class Response
{
    public NetAddress NetAddress { get; private init; }
    public IReadOnlyList<SubnetResponse> Subnets { get; private init; }
    public bool Failed { get; private init; }
    public long NeededAddresses { get; private init; }
    public long AvailableAddresses { get; private init; }

    public Response(NetAddress netAddress, IReadOnlyList<SubnetResponse> subnets)
    {
        NetAddress = netAddress;
        Subnets = subnets;
        Failed = subnets.Any(subnet => subnet.Overflow);
        NeededAddresses = subnets.Sum(subnet => subnet.NeededSize);
        AvailableAddresses = subnets.Sum(subnet => subnet.Hosts);
    }
}
