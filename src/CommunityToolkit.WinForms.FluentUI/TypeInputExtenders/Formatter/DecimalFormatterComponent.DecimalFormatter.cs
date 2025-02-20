using System.ComponentModel;
using System.Text;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

public partial class DecimalFormatterComponent
{
    private const string DefaultCurrencySymbol = "";

    public class DecimalFormatter : TypedFormatter<decimal?>
    {
        // Backing fields. We implement INotifyPropertyChanged, so we can't use AutoProperties.
        private string? _currencySymbol;
        private int _decimalPlaces;
        private bool _hasThousandsSeparator;
        private bool _placeCurrencySymbolUpFront;
        private bool _allowFormular;
        private int _leadingZeros;

        /// <summary>
        /// Sets or gets the currency sign that should be placed before or after the amount.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or gets the currency sign that should be placed before or after the amount."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(DefaultCurrencySymbol)]
        public string? CurrencySymbol
        {
            get => _currencySymbol;
            set => SetProperty(ref _currencySymbol, value);
        }

        /// <summary>
        /// Sets or gets the number of decimal places to be displayed for fractions.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or gets the number of decimal places to be displayed for fractions."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(-1)]
        public int DecimalPlaces
        {
            get => _decimalPlaces;
            set => SetProperty(ref _decimalPlaces, value);
        }

        /// <summary>
        /// Sets or sets whether the thousands separator should be displayed for numbers above 999 (<-999).
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or sets whether the thousands separator should be displayed for numbers above 999 (<-999)."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(false)]
        public bool HasThousandsSeparator
        {
            get => _hasThousandsSeparator;
            set => SetProperty(ref _hasThousandsSeparator, value);
        }

        /// <summary>
        /// Sets or gets whether the currency sign should be placed in front (true) or behind.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or gets whether the currency sign should be placed in front (true) or behind."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(false)]
        public bool PlaceCurrencySymbolUpFront
        {
            get => _placeCurrencySymbolUpFront;
            set => SetProperty(ref _placeCurrencySymbolUpFront, value);
        }

        /// <summary>
        /// Sets or gets whether mathematical, calculable expressions (formulars) can be entered instead of values.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or gets whether mathematical, calculable expressions (formulars) can be entered instead of values."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(false)]
        public bool AllowFormular
        {
            get => _allowFormular;
            set => SetProperty(ref _allowFormular, value);
        }

        /// <summary>
        /// Sets or gets whether the formatted value to be displayed is padded with the appropriate number of leading zeros.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Description("Sets or gets whether the formatted value to be displayed is padded with the appropriate number of leading zeros."),
        Category("Behavior"),
        EditorBrowsable(EditorBrowsableState.Advanced),
        Browsable(true), DefaultValue(0)]
        public int LeadingZeros
        {
            get => _leadingZeros;
            set => SetProperty(ref _leadingZeros, value);
        }

        public string? GetFormatString()
        {
            var formatString = new StringBuilder();

            if (LeadingZeros > 0)
            {
                formatString.Append('0', LeadingZeros);
            }
            else
            {
                if (HasThousandsSeparator)
                {
                    formatString.Append("#,##0");
                }
                else
                {
                    formatString.Append("###0");
                }
            }

            if (DecimalPlaces == -1)
            {
                formatString.Append(".########################");
            }
            else if (DecimalPlaces > 0)
            {
                formatString.Append('.');
                formatString.Append('0', DecimalPlaces);
            }

            if (string.IsNullOrEmpty(CurrencySymbol))
            {
                return formatString.ToString();
            }

            if (PlaceCurrencySymbolUpFront)
            {
                formatString.Insert(0, CurrencySymbol);
            }
            else
            {
                formatString.Append(CurrencySymbol);
            }

            return formatString.ToString();
        }

        /// <summary>
        ///  Converts the value to a displayable string.
        /// </summary>
        public override Task<string?> ConvertToDisplayAsync(
            decimal? value, 
            CancellationToken token)
        {
            return Task.FromResult<string?>(
                value is null 
                    ? NullFormatString 
                    : value.Value.ToString(GetFormatString()));
        }

        /// <summary>
        /// Converts the string value to a decimal value.
        /// </summary>
        public override async Task<decimal?> ConvertToValueAsync(
            string? stringValue,
            CancellationToken token)
        {
            await Task.Delay(2000, token);

            decimal? result = stringValue is null
                    ? null
                    : decimal.Parse(stringValue);

            return result;
        }

        /// <summary>
        /// Provides the initial value for the edited value.
        /// </summary>
        public override Task<string?> InitializeEditedValueAsync(
            decimal? value, 
            CancellationToken token) => 
            Task.FromResult<string?>(value.ToString());
    }
}
