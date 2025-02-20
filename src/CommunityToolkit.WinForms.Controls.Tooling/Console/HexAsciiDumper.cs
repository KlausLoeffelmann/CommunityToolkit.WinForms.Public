using System.Text;

namespace CommunityToolkit.WinForms.Controls.Tooling.Console;

/// <summary>
/// Provides functionality to convert byte arrays or strings into formatted hexadecimal, octal, or decimal representations with optional ASCII or Unicode text display.
/// </summary>
/// <remarks>
/// <para>
/// The <see cref="HexAsciiDumper"/> class allows you to convert byte arrays or strings into a formatted string representation. You can specify the number of bytes per row, the data format (hexadecimal, octal, or decimal), and whether to show the text representation (ASCII or Unicode).
/// </para>
/// <para>
/// Example usage:
/// <code>
/// var dumper = new HexAsciiDumper
/// {
///     BytesPerRow = 16,
///     DataFormat = DataFormat.Hex,
///     ShowText = ShowText.ASCII
/// };
/// 
/// byte[] data = { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
/// if (dumper.TryGetString(data, out string? result))
/// {
///     Console.WriteLine(result);
/// }
/// </code>
/// </para>
/// </remarks>
public class HexAsciiDumper
{
    private const int DefaultBytesPerRow = 8;
    private const DataFormat DefaultDataFormat = DataFormat.Hex;
    private const ShowText DefaultShowText = ShowText.ASCII;

    private readonly List<byte> _buffer = [];
    private readonly StringBuilder _textBuffer = new();

    private int _bytesPerRow;
    private DataFormat _dataFormat;
    private ShowText _showText;

    /// <summary>
    /// Initializes a new instance of the <see cref="HexAsciiDumper"/> class with default settings.
    /// </summary>
    public HexAsciiDumper()
    {
        _bytesPerRow = DefaultBytesPerRow;
        _dataFormat = DefaultDataFormat;
        _showText = DefaultShowText;
    }

    /// <summary>
    /// Gets or sets the number of bytes per row in the output.
    /// </summary>
    /// <value>
    /// The number of bytes per row. Valid values are 4, 8, 16, or 32.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value is not 4, 8, 16, or 32.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The <see cref="BytesPerRow"/> property determines how many bytes are displayed in each row of the output.
    /// </para>
    /// </remarks>
    public int BytesPerRow
    {
        get => _bytesPerRow;
        set
        {
            if (value != 4 && value != 8 && value != 16 && value != 32)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "BytesPerRow must be 4, 8, 16, or 32.");
            }

            _bytesPerRow = value;
        }
    }

    /// <summary>
    /// Gets or sets the data format for the output.
    /// </summary>
    /// <value>
    /// The data format. Valid values are <see cref="DataFormat.Hex"/>, <see cref="DataFormat.Oct"/>, or <see cref="DataFormat.Decimal"/>.
    /// </value>
    /// <remarks>
    /// <para>
    /// The <see cref="DataFormat"/> property determines how the byte values are formatted in the output.
    /// </para>
    /// </remarks>
    public DataFormat DataFormat
    {
        get => _dataFormat;
        set => _dataFormat = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to show the text representation of the data.
    /// </summary>
    /// <value>
    /// The text representation format. Valid values are <see cref="ShowText.None"/>, <see cref="ShowText.ASCII"/>, or <see cref="ShowText.Unicode"/>.
    /// </value>
    /// <remarks>
    /// <para>
    /// The <see cref="ShowText"/> property determines whether and how the text representation of the byte values is displayed in the output.
    /// </para>
    /// </remarks>
    public ShowText ShowText
    {
        get => _showText;
        set => _showText = value;
    }

    /// <summary>
    /// Tries to get a formatted string representation of the provided byte array.
    /// </summary>
    /// <param name="newData">The byte array to format.</param>
    /// <param name="result">When this method returns, contains the formatted string representation if the conversion succeeded, or <c>null</c> if it failed.</param>
    /// <returns>
    /// <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The <see cref="TryGetString(byte[], out string?)"/> method appends the provided byte array to the internal buffer and attempts to convert it to a formatted string representation.
    /// </para>
    /// </remarks>
    public bool TryGetString(byte[] newData, out string? result)
    {
        _buffer.AddRange(newData);
        return TryGetFullLine(out result);
    }

    /// <summary>
    /// Tries to get a formatted string representation of the provided string.
    /// </summary>
    /// <param name="newData">The string to format.</param>
    /// <param name="result">When this method returns, contains the formatted string representation if the conversion succeeded, or <c>null</c> if it failed.</param>
    /// <returns>
    /// <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The <see cref="TryGetString(string, out string?)"/> method appends the provided string to the internal buffer and attempts to convert it to a formatted string representation.
    /// </para>
    /// </remarks>
    public bool TryGetString(string newData, out string? result)
    {
        // Convert the string to a byte array using the default encoding
        byte[] newDataBytes = Encoding.Default.GetBytes(newData);
        return TryGetString(newDataBytes, out result);
    }

    /// <summary>
    /// Gets the remaining unprocessed data in the buffer.
    /// </summary>
    /// <returns>
    /// A string containing the remaining unprocessed data.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The <see cref="GetRemaining"/> method returns the remaining unprocessed data in the buffer and clears the buffer.
    /// </para>
    /// </remarks>
    public string GetRemaining()
    {
        try
        {
            return _textBuffer.ToString();
        }
        finally
        {
            _buffer.Clear();
            _textBuffer.Clear();
        }
    }

    /// <summary>
    /// Clears the internal buffer.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="Flush"/> method clears the internal buffer, discarding any unprocessed data.
    /// </para>
    /// </remarks>
    public void Flush()
    {
        _buffer.Clear();
    }

    private string ConvertData(byte[] data)
    {
        StringBuilder sb = new();

        foreach (byte b in data.Take(_bytesPerRow))
        {
            sb.Append(_dataFormat switch
            {
                DataFormat.Hex => b.ToString("X2"),
                DataFormat.Oct => Convert.ToString(b, 8).PadLeft(3, '0'),
                DataFormat.Decimal => b.ToString("D3"),
                _ => throw new ArgumentOutOfRangeException()
            });

            sb.Append(' ');
        }

        if (_showText != ShowText.None)
        {
            sb.Append("  ");
            foreach (byte b in data.Take(_bytesPerRow))
            {
                _ = sb.Append(_showText switch
                {
                    ShowText.ASCII => b >= 32 && b <= 126 ? (char)b : '.',
                    ShowText.Unicode => char.IsControl((char)b) ? '.' : (char)b,
                    _ => throw new ArgumentOutOfRangeException()
                });
            }
        }

        return sb.ToString();
    }

    private bool TryGetFullLine(out string? result)
    {
        if (_buffer.Count >= _bytesPerRow)
        {
            result = ConvertData([.. _buffer]);
            _buffer.RemoveRange(0, _bytesPerRow);

            return true;
        }

        result = null;
        return false;
    }
}

/// <summary>
/// Specifies the data format for the <see cref="HexAsciiDumper"/> class.
/// </summary>
public enum DataFormat
{
    /// <summary>
    /// Hexadecimal format.
    /// </summary>
    Hex,
    /// <summary>
    /// Octal format.
    /// </summary>
    Oct,
    /// <summary>
    /// Decimal format.
    /// </summary>
    Decimal
}

/// <summary>
/// Specifies whether and how to show the text representation of the data in the <see cref="HexAsciiDumper"/> class.
/// </summary>
public enum ShowText
{
    /// <summary>
    /// Do not show text representation.
    /// </summary>
    None,
    /// <summary>
    /// Show ASCII text representation.
    /// </summary>
    ASCII,
    /// <summary>
    /// Show Unicode text representation.
    /// </summary>
    Unicode
}
