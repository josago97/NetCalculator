using Microsoft.Extensions.DependencyInjection;
using NetCalculator.Common.Views;

namespace NetCalculator.Common;

public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<JSInterop>();
    }
}
