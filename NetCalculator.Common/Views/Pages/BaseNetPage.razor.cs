using Microsoft.AspNetCore.Components;
using NetCalculator.Common.Models;
using NetCalculator.Common.Utilities;

namespace NetCalculator.Common.Views.Pages;

public abstract partial class BaseNetPage
{
    protected const string RESULT_ID = "result";
    protected static readonly NetAddress DEFAULT_NET_ADDRESS = new NetAddress("192.168.1.0", 24);

    [Inject]
    protected JSInterop JSInterop { get; set; }

    protected NetAddress? NetAddress { get; set; } = DEFAULT_NET_ADDRESS;

    protected async void GoToResults()
    {
        await JSInterop.GoToAnchorLink('#' + RESULT_ID);
    }
}