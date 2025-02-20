using CommunityToolkit.WinForms.FluentUI.Containers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Chatty.Controls;

internal class FluentModelPicker : FluentDecoratorPanel
{
    private readonly ComboBox _comboBox;

    public FluentModelPicker()
    {
        _comboBox = new()
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            FlatStyle = FlatStyle.Flat
        };

        Padding = new(10);
        Controls.Add(_comboBox);
    }

    /// <summary>
    /// Gets the items in the ComboBox.
    /// </summary>
    [Category("Data")]
    [Description("Specifies the items in the ComboBox.")]
    public ComboBox.ObjectCollection Items => _comboBox.Items;

    /// <summary>
    /// Gets or sets the index specifying the currently selected item.
    /// </summary>
    [Category("Behavior")]
    [Description("Specifies the index specifying the currently selected item.")]
    [DefaultValue(-1)]
    public int SelectedIndex
    {
        get => _comboBox.SelectedIndex;
        set => _comboBox.SelectedIndex = value;
    }

    private bool ShouldSerializeSelectedIndex() => SelectedIndex != -1;

    /// <summary>
    /// Gets or sets the currently selected item.
    /// </summary>
    [Category("Behavior")]
    [Description("Specifies the currently selected item.")]
    public object? SelectedItem
    {
        get => _comboBox.SelectedItem;
        set => _comboBox.SelectedItem = value;
    }

    private bool ShouldSerializeSelectedItem() 
        => SelectedItem != null;

    /// <summary>
    /// Gets or sets the text of the currently selected item.
    /// </summary>
    [Category("Behavior")]
    [Description("Specifies the text of the currently selected item.")]
    public string SelectedText
    {
        get => _comboBox.SelectedText;
        set => _comboBox.SelectedText = value;
    }

    private bool ShouldSerializeSelectedText() 
        => !string.IsNullOrEmpty(SelectedText);

    /// <summary>
    /// Gets or sets the text associated with this control.
    /// </summary>
    [Category("Appearance")]
    [Description("Specifies the text associated with this control.")]
    [AllowNull]
    public override string Text
    {
        get => _comboBox.Text;
        set => _comboBox.Text = value;
    }

    private bool ShouldSerializeText() 
        => !string.IsNullOrEmpty(Text);
}
