using Blazored.LocalStorage;

namespace NetCalculator.Wasm;

internal class SettingsManager : Common.SettingsManager
{
    private readonly ILocalStorageService _localStorage;

    public SettingsManager(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    protected override async Task<T> GetValueAsync<T>(string key, T defaultValue)
    {
        return await _localStorage.ContainKeyAsync(key)
            ? await _localStorage.GetItemAsync<T>(key)
            : defaultValue;
    }

    protected override async Task SetValueAsync<T>(string key, T value)
    {
        await _localStorage.SetItemAsync(key, value);
    }
}
