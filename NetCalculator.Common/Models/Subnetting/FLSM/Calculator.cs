namespace NetCalculator.Common.Models.Subnetting.FLSM;

public class Calculator : BaseCalculator
{
    public Response Calculate(Request request)
    {
        IPv4Address startIp = request.NetAddress.Ip;
        int subnetBits = (int)Math.Ceiling(Math.Log2(request.SubnetCount));
        int mask = request.NetAddress.Mask + subnetBits;
        List<Subnet> subnets = new List<Subnet>(request.SubnetCount);

        for (int i = 0; i < subnets.Capacity; i++)
        {
            NetAddress subnetAddress = new NetAddress(startIp, mask);

            Subnet subnet = new Subnet(subnetAddress);
            startIp = startIp.Add(subnet.Size);
            subnets.Add(subnet);
        }

        return new Response()
        {
            NetAddress = request.NetAddress,
            Subnets = subnets
        };
    }
}
