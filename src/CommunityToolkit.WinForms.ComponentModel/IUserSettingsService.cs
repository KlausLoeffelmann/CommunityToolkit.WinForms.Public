namespace CommunityToolkit.WinForms.ComponentModel;

public interface IUserSettingsService
{
    /// <summary>
    ///  Gets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    T Get<T>(string key, T defaultValue) where T : IParsable<T>;

    /// <summary>
    ///  Gets the array value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="key">The key of the array value.</param>
    /// <param name="defaultValue">The default array value to return if the key is not found.</param>
    /// <returns>The array value associated with the specified key, or the default array value if the key is not found.</returns>
    T[] GetArray<T>(string key, T[] defaultValue) where T : IParsable<T>;

    /// <summary>
    ///  Gets the instance value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="key">The key of the instance value.</param>
    /// <param name="defaultValue">The default instance value to return if the key is not found.</param>
    /// <returns>The instance value associated with the specified key, or the default instance value if the key is not found.</returns>
    T GetInstance<T>(string key, T defaultValue);

    /// <summary>
    ///  Sets the instance value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the instance.</typeparam>
    /// <param name="key">The key of the instance value.</param>
    /// <param name="value">The instance value to set.</param>
    void SetInstance<T>(string key, T value);

    /// <summary>
    ///  Sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The key of the value.</param>
    /// <param name="value">The value to set.</param>
    void Set<T>(string key, T value) where T : IParsable<T>;

    /// <summary>
    ///  Sets the array value associated with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="key">The key of the array value.</param>
    /// <param name="value">The array value to set.</param>
    void SetArray<T>(string key, T[] value) where T : IParsable<T>;

    /// <summary>
    ///  Removes the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key of the value to remove.</param>
    void Remove(string key);

    /// <summary>
    ///  Determines whether the specified key exists.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the key exists; otherwise, false.</returns>
    bool Contains(string key);

    /// <summary>
    ///  Clears all the key-value pairs.
    /// </summary>
    void Clear();

    /// <summary>
    ///  Saves the changes made to the user settings.
    /// </summary>
    void Save();

    /// <summary>
    ///  Loads the user settings.
    /// </summary>
    void Load();
}
