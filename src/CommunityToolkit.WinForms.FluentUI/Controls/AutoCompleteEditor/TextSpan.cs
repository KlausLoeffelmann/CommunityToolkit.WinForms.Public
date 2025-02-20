namespace CommunityToolkit.WinForms.FluentUI.Controls;

public readonly struct TextSpan(int start, int length, ReadOnlyMemory<char> text)
{
    private const char TabSymbol = '\u21E5';

    public static string SymbolText { get; } = $"{TabSymbol} ";

    // Important: The space after the tab symbol is necessary to have the current
    // selection never pick up the prediction font.
    public static string EffectiveSymbolText { get; } = $" {SymbolText}";

    public static int SymbolLength { get; } = EffectiveSymbolText.Length;

    public int Start { get; } = start;
    public int Length { get; } = length;

    public int StartIncludingSymbol 
        => Start - EffectiveSymbolText.Length;

    public int LengthIncludingSymbol 
        => Length + EffectiveSymbolText.Length;

    public readonly bool IsEmpty 
        => Length == 0;

    public ReadOnlyMemory<char> Text { get; } = text;
}
