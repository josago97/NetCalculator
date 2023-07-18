namespace NetCalculator.Common.Models.Subnetting.FLSM;

public class Response
{
    public NetAddress NetAddress { get; set; }
    public IReadOnlyList<Subnet> Subnets { get; set; }
}
