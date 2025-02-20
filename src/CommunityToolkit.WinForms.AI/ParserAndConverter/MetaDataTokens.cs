namespace CommunityToolkit.WinForms.AI.ConverterLogic;

/// <summary>
///  Holds metadata parsed from the input.
/// </summary>
/// <param name="Key">  Gets the key of the metadata. </param>
/// <param name="Value">  Gets the value of the metadata. </param>
/// <param name="Position">  Gets the absolute position in the text where the metadata appeared. </param>
/// <param name="WasDedicatedLine">  Gets a value indicating whether the metadata was on a dedicated line. </param>
public sealed record ReturnStreamMetaData(string Key, string Value, int Position, bool WasDedicatedLine);
