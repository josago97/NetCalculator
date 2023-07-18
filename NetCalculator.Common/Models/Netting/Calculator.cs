namespace NetCalculator.Common.Models.Netting;

public class Calculator : BaseCalculator
{
    public Response Calculate(Request request)
    {
        Response result = new Response(request.NetAddress);

        return result;
    }
}
