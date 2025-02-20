using System.Collections;
using System.ComponentModel;

namespace CommunityToolbox.WinForms.Mvvm.Controls;

public class BindableComboBox : ComboBox
{
    public event EventHandler? BindingValueChanged;

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object? SelectedBindingValue
    {
        get => Invoke(() => SelectedIndex == -1 ? null : Items[SelectedIndex]);
        set
        {
            if (value is null || value is DBNull)
            {
                Invoke(() => SelectedIndex = -1);
                return;
            }

            for (var i = 0; i < Items.Count; i++)
            {
                if (value.Equals(Items[i]))
                {
                    Invoke(() => SelectedIndex = i);
                    return;
                }
            }
        }
    }

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        BindingValueChanged?.Invoke(this, e);
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);
        if (IsAncestorSiteInDesignMode || DataContext is not IList)
        {
            return;
        }

        DataSource = DataContext;
    }
}
