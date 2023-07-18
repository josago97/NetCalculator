using Microsoft.JSInterop;

namespace NetCalculator.Common.Views;

public class JSInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public JSInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/NetCalculator.Common/js/app.js").AsTask());
    }

    public async ValueTask<string> ChangeThemeAsync(bool darkModeEnabled)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("changeTheme", darkModeEnabled);
    }

    public async Task GoToAnchorLink(string elementId)
    {
        var module = await moduleTask.Value;
        await module.InvokeAsync<string>("goToAnchorLink", elementId);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
