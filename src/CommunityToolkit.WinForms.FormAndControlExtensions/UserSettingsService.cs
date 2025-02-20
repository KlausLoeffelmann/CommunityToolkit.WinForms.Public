using CommunityToolkit.WinForms.ComponentModel;
using System.Reflection;

using System.Text.Json;

namespace CommunityToolkit.WinForms.Extensions;

/// <summary>
///  Provides a service for managing user settings in a WinForms application.
/// </summary>
public class WinFormsUserSettingsService : IUserSettingsService
{
    private const string _settingsFileName = "UserSettings.json";
    private Dictionary<string, string> _settings = [];
    private static IUserSettingsService? s_settings;
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        WriteIndented = true
    };

    /// <summary>
    ///  Gets the path to the user's application data folder.
    /// </summary>
    /// <returns>A <see cref="FileInfo"/> object representing the settings file.</returns>
    private static FileInfo GetUserApplicationPath()
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        Assembly assembly = Assembly.GetEntryAssembly()
            ?? throw new InvalidOperationException("The entry assembly is null.");

        string assemblyName = assembly.GetName().Name!;
        string version = assembly.GetName().Version!.ToString();
        string appFolder = Path.Combine(appDataPath, assemblyName, version);
        Directory.CreateDirectory(appFolder);
        return new FileInfo(Path.Combine(appFolder, _settingsFileName));
    }

    /// <summary>
    ///  Clears all settings.
    /// </summary>
    public void Clear() => _settings.Clear();

    /// <summary>
    ///  Determines whether the specified key exists in the settings.
    /// </summary>
    /// <param name="key">The key to locate in the settings.</param>
    /// <returns><c>true</c> if the key exists; otherwise, <c>false</c>.</returns>
    public bool Contains(string key) => _settings.ContainsKey(key);

    /// <summary>
    ///  Gets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value to get.</param>
    /// <param name="defaultValue">The default value to return if the key does not exist.</param>
    /// <returns>The value associated with the specified key, or the default value if the key does not exist.</returns>
    public T Get<T>(string key, T defaultValue) where T : IParsable<T>
    {
        if (_settings.TryGetValue(key, out string? value))
        {
            return JsonSerializer.Deserialize<T>(value!)!;
        }
        return defaultValue;
    }

    /// <summary>
    ///  Gets the array associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="key">The key of the array to get.</param>
    /// <param name="defaultValue">The default array to return if the key does not exist.</param>
    /// <returns>The array associated with the specified key, or the default array if the key does not exist.</returns>
    public T[] GetArray<T>(string key, T[] defaultValue) where T : IParsable<T>
    {
        if (_settings.TryGetValue(key, out string? value))
        {
            return JsonSerializer.Deserialize<T[]>(value!)!;
        }
        return defaultValue;
    }

    /// <summary>
    ///  Gets the instance associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="key">The key of the instance to get.</param>
    /// <param name="defaultValue">The default instance to return if the key does not exist.</param>
    /// <returns>The instance associated with the specified key, or the default instance if the key does not exist.</returns>
    public T GetInstance<T>(string key, T defaultValue)
    {
        if (_settings.TryGetValue(key, out string? value))
        {
            return JsonSerializer.Deserialize<T>(value!)!;
        }
        return defaultValue;
    }

    /// <summary>
    ///  Sets the instance associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="key">The key of the instance to set.</param>
    /// <param name="value">The instance to set.</param>
    public void SetInstance<T>(string key, T value)
    {
        _settings[key] = JsonSerializer.Serialize(value);
    }

    /// <summary>
    ///  Creates and loads a new instance of the <see cref="WinFormsUserSettingsService"/> class.
    /// </summary>
    /// <returns>A new instance of the <see cref="WinFormsUserSettingsService"/> class.</returns>
    public static IUserSettingsService CreateAndLoad()
    {
        s_settings = (IUserSettingsService)new WinFormsUserSettingsService();
        s_settings.Load();
        return s_settings;
    }

    /// <summary>
    ///  Removes the value with the specified key.
    /// </summary>
    /// <param name="key">The key of the value to remove.</param>
    public void Remove(string key) => _settings.Remove(key);

    /// <summary>
    ///  Saves the settings to a file.
    /// </summary>
    public void Save()
    {
        string json = JsonSerializer.Serialize(_settings, s_jsonOptions);
        FileInfo settingsFile = GetUserApplicationPath();
        File.WriteAllText(settingsFile.FullName, json);
    }

    /// <summary>
    ///  Sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value to set.</param>
    /// <param name="value">The value to set.</param>
    public void Set<T>(string key, T value) where T : IParsable<T>
    {
        _settings[key] = JsonSerializer.Serialize(value);
    }

    /// <summary>
    ///  Sets the array associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="key">The key of the array to set.</param>
    /// <param name="value">The array to set.</param>
    public void SetArray<T>(string key, T[] value) where T : IParsable<T>
    {
        _settings[key] = JsonSerializer.Serialize(value);
    }

    /// <summary>
    ///  Loads the settings from a file.
    /// </summary>
    void IUserSettingsService.Load()
    {
        FileInfo settingsFile = GetUserApplicationPath();
        if (settingsFile.Exists)
        {
            string json = File.ReadAllText(settingsFile.FullName);
            _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
        }
    }

    public static IUserSettingsService GetOrThrow()
    {
        if (s_settings is null)
        {
            throw new InvalidOperationException("The settings service has not been created.");
        }

        return s_settings;
    }
}
