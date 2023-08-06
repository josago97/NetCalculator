namespace NetCalculator.Common.Models.Subnetting.VLSM;

public class Calculator : BaseCalculator
{
    public Response Calculate(Request request)
    {
        NetAddress netAddress = request.NetAddress;
        IEnumerable<SubnetRequest> subnetRequests = request.Subnets.OrderByDescending(s => s.Hosts);

        return new Response(netAddress, CalculateSubnets(netAddress, subnetRequests));
    }

    private IReadOnlyList<SubnetResponse> CalculateSubnets(NetAddress netAddress, IEnumerable<SubnetRequest> subnetRequests)
    {
        List<SubnetResponse> result = new List<SubnetResponse>();
        IPv4Address startIp = netAddress.Ip;
        ulong addressesCount = 0;

        foreach (SubnetRequest subnetRequest in subnetRequests)
        {
            // Gets the total addresses required
            ulong size = (ulong)subnetRequest.Hosts + RESERVED_ADDRESS_COUNT;
            // Amount of bits that we need to store all addresses
            int bytesNeeded = (int)Math.Log2(size) + 1;
            // Bits of subnet mask 
            int mask = Math.Max(0, BITS_PER_ADDRESS - bytesNeeded);

            // Gets the subnet from the current Ip and the mask
            NetAddress subnetAddress = new NetAddress(startIp, mask);
            addressesCount += subnetAddress.Size;
            SubnetResponse subnet = new SubnetResponse(subnetAddress)
            {
                Name = subnetRequest.Name,
                // Amount of host required by user
                NeededSize = subnetRequest.Hosts,
                // If the current amount of address is greater than the max size in the major network then there is overflow
                Overflow = addressesCount > netAddress.Size
            };

            startIp = startIp.Add(subnet.Size);
            result.Add(subnet);
        }

        return result; 
    }
}
