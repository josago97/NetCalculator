namespace NetCalculator.Maui;

internal class SettingsManager : Common.SettingsManager
{
    protected override Task<T> GetValueAsync<T>(string key, T defaultValue)
    {
        return Task.FromResult(Preferences.Default.Get(key, defaultValue));
    }

    protected override Task SetValueAsync<T>(string key, T value)
    {
        Preferences.Default.Set(key, value);

        return Task.CompletedTask;
    }
}
