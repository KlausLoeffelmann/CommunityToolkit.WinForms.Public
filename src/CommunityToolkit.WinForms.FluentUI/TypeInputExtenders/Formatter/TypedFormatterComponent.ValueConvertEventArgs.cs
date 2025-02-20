

using CommunityToolkit.WinForms.FluentUI;
using CommunityToolkit.WinForms.FluentUI.Controls;

namespace CommunityToolkit.WinForms.FluentUI.Controls.TypedInputExtenders;

public abstract partial class TypedFormatterComponent<T>
{
    public class ValueConvertEventArgs : EventArgs
    {
        internal ValueConvertEventArgs(TextBox textBox, CancellationToken token)
        {
            TextBox = textBox;
            IndicateBusy = true;
            PreventChangesWhileBusy = true;
            CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
        }

        public TextBox TextBox { get; }
        public bool IndicateBusy { get; set; }
        public bool PreventChangesWhileBusy { get; set; }

        internal CancellationTokenSource CancellationTokenSource { get; }
        internal SpinnerControl? Spinner { get; set; }
        internal Task? SpinnerTask { get; set; }
    }
}
