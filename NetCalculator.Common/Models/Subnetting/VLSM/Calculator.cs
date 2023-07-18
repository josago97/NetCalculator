namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class Calculator : BaseCalculator
{
    public Response Calculate(Request request)
    {
        IPv4Address startIp = request.NetAddress.Ip;
        SubnetRequest[] subnetRequests = request.Subnets.OrderByDescending(s => s.Hosts).ToArray();
        List<SubnetResponse> subnets = new List<SubnetResponse>();

        foreach (SubnetRequest subnetRequest in subnetRequests)
        {
            uint size = subnetRequest.Hosts + RESERVED_ADDRESS_COUNT;
            int bytesNeeded = (int)Math.Log2(size) + 1;
            int mask = 32 - bytesNeeded;

            NetAddress subnetAddress = new NetAddress(startIp, mask);
            SubnetResponse subnet = new SubnetResponse(subnetAddress)
            {
                Name = subnetRequest.Name,
                NeededSize = subnetRequest.Hosts
            };

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
