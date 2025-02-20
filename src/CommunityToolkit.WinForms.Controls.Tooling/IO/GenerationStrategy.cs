namespace CommunityToolkit.WinForms.Controls.Tooling.IO;

/// <summary>
/// Specifies the auto‑generation strategy for the filename.
/// </summary>
public enum GenerationStrategy
{
    /// <summary>No auto‑generation. Use Title as provided.</summary>
    None,
    /// <summary>
    /// Generate filename based on current date and time.
    /// Only works if Title is not provided.
    /// </summary>
    DateBased,
    /// <summary>
    /// Generate filename as a GUID.
    /// Only works if Title is not provided.
    /// </summary>
    GuidBase,
    /// <summary>
    /// Generate filename by combining Title and current date/time.
    /// Only works if Title is provided.
    /// </summary>
    DateAmended
}
