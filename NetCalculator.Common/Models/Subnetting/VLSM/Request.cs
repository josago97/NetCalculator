namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class Request
{
    public NetAddress NetAddress { get; set; }
    public IList<SubnetRequest> Subnets { get; set; }
}
