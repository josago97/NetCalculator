namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class Response
{
    public NetAddress NetAddress { get; set; }
    public IReadOnlyList<SubnetResponse> Subnets { get; set; }
}
