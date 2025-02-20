namespace CommunityToolkit.WinForms.Mvvm;

internal partial class WinFormsDialogService
{
    private class SelectionForm<T> : Form
    {
        private readonly string _message;
        private readonly IEnumerable<T> _options;
        private readonly T? _defaultOption = default;
        private readonly TaskCompletionSource<T> _completion = new();

        public SelectionForm(string title, string message, IEnumerable<T> options, T? defaultOption = default)
        {
            InitializeComponent();
            Text = title;
            _message = message;
            _options = options;
            _defaultOption = defaultOption;
        }

        private void InitializeComponent()
        {
            // Initialize the form
            var form = new Form
            {
                AutoScaleDimensions = new SizeF(6F, 13F),
                AutoScaleMode = AutoScaleMode.Font,
                ClientSize = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent
            };

            // Create a panel to enable scrolling if there are many options
            var scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Create a TableLayoutPanel to layout buttons in a grid
            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 3, // Adjust the number of columns as needed
                Padding = new Padding(10)
            };

            // Create and configure the message label
            var messageLabel = new Label
            {
                Text = _message,
                Dock = DockStyle.Top,
                Margin = new Padding(5, 10, 20, 10)
            };

            // Add the message label to the first row of the TableLayoutPanel
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayout.Controls.Add(messageLabel, 0, 0);

            // Add option buttons to the TableLayoutPanel
            int index = 0;
            foreach (var option in _options)
            {
                var button = new RadioButton
                {
                    Text = option?.ToString() ?? "- - -",
                    AutoSize = true,
                    Tag = option,
                    Margin = new Padding(20, 5, 5, 15)
                };

                if (object.Equals(option, _defaultOption))
                {
                    button.Checked = true;
                }

                // Add event handler to set the result and close the form
                button.Click += (sender, e) =>
                {
                    _completion.SetResult((T)((RadioButton)sender!).Tag!);
                    form.Close();
                };

                // Add button to the TableLayoutPanel
                tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayout.Controls.Add(button, index % tableLayout.ColumnCount, index / tableLayout.ColumnCount);
                index++;
            }

            // Add controls to the panel and form
            scrollPanel.Controls.Add(tableLayout);
            form.Controls.Add(scrollPanel);
            form.Controls.Add(messageLabel);
        }

        public new async Task<T> ShowDialogAsync()
        {
            // Show the form as a dialog
            await ShowDialogAsync();
            return await _completion.Task;
        }
    }
}
