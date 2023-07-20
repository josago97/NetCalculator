namespace NetCalculator.Common;

public abstract class SettingsManager
{
    private const string DARK_MODE_KEY = "darkMode";
    private const bool DARK_MODE_DEFAULT = false;

    private const string LAST_PAGE_KEY = "lastPage";
    private const string LAST_PAGE_DEFAULT = "/net";

    public async Task<bool> GetDarkModeAsync()
    {
        return await GetValueAsync(DARK_MODE_KEY, DARK_MODE_DEFAULT);
    }

    public async Task SetDarkModeAsync(bool darkModeEnabled)
    {
        await SetValueAsync(DARK_MODE_KEY, darkModeEnabled);
    }

    public async Task<string> GetLastPageAsync()
    {
        return await GetValueAsync(LAST_PAGE_KEY, LAST_PAGE_DEFAULT);
    }

    public async Task SetLastPageAsync(string lastPage)
    {
        await SetValueAsync(LAST_PAGE_KEY, lastPage);
    }

    protected abstract Task<T> GetValueAsync<T>(string key, T defaultValue);

    protected abstract Task SetValueAsync<T>(string key, T value);
}
