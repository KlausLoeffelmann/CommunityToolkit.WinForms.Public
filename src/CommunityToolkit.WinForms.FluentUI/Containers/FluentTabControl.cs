using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Containers;

public partial class FluentTabControl : Panel
{
    private readonly MenuStrip _menuStrip;   // Tab bar
    private readonly List<Panel> _tabPages;  // Tab pages
    private ToolStripMenuItem? _currentItem;

    public event EventHandler? TabChanged;

    public FluentTabControl()
    {
        _menuStrip = new MenuStrip
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            Renderer = new RoundedCornersRenderer(),
            Font = new Font("Segoe UI", 12, FontStyle.Regular)
        };

        _tabPages = [];

        Controls.Add(_menuStrip);
    }

    protected override void OnLayout(LayoutEventArgs layoutEventArgs)
    {
        base.OnLayout(layoutEventArgs);

        foreach (var page in _tabPages)
        {
            page.Width = ClientSize.Width;
            page.Height = ClientSize.Height - _menuStrip.Height;
            page.Location = new Point(0, _menuStrip.Height);
            page.Padding = new Padding(3, 25, 3, 3);
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CurrentTabIndex
    {
        get => _menuStrip
            .Items
            .IndexOf(_menuStrip.Items
            .OfType<ToolStripMenuItem>()
            .First(i => i.Checked));

        set
        {
            SuspendLayout();

            foreach (var item in _menuStrip.Items.OfType<ToolStripMenuItem>())
            {
                item.Checked = item == _menuStrip.Items[value];
            }

            foreach (var page in _tabPages)
            {
                page.Visible = page == _tabPages[value];
            }

            ResumeLayout();
        }
    }

    public Control? CurrentTab
    {
        get => _tabPages is null || _tabPages.Count == 0
            ? null
            : _tabPages[CurrentTabIndex].Controls[0];
    }

    public void AddTab(string tabPageTitle, ContainerControl tabContent)
    {
        var tabPage = new Panel
        {
            Dock = DockStyle.Fill,
            Visible = false,
            BorderStyle = BorderStyle.None
        };

        tabContent.Dock = DockStyle.Fill;
        tabPage.Controls.Add(tabContent);
        _tabPages.Add(tabPage);

        var tabMenueItem = new ToolStripMenuItem(tabPageTitle)
        {
            CheckOnClick = true,
            AutoSize = true,
            Padding = new Padding(20, 5, 10, 5),
            Tag = tabPage
        };

        tabMenueItem.Click += TabItem_Clicked;

        _menuStrip.Items.Add(tabMenueItem);
        Controls.Add(tabPage);

        // Select the first tab by default if this is the first tab added
        if (_menuStrip.Items.Count == 1)
        {
            CurrentTabIndex = 0;
            _currentItem = tabMenueItem;
        }
    }

    public IEnumerable<Panel> Tabs => _tabPages;

    private void TabItem_Clicked(object? sender, EventArgs e)
    {
        // If the clicked item is selected, nothing changes.
        if (sender is not ToolStripMenuItem senderItem
            || senderItem == _currentItem)
        {
            return;
        }

        ScrollableControl? previousPage = null;
        ScrollableControl currentPage;

        if (_currentItem is not null)
        {
            _currentItem.Checked = false;
            previousPage = (ScrollableControl)_currentItem.Tag!;
        }

        _currentItem = (ToolStripMenuItem)sender;
        _currentItem.Checked = true;

        currentPage = (ScrollableControl)_currentItem.Tag! ?? throw new NullReferenceException();
        currentPage.BringToFront();
        currentPage.Visible = true;

        if (previousPage is not null)
        {
            previousPage.SendToBack();
            previousPage.Visible = false;
        }

        OnTabChanged(EventArgs.Empty);
    }

    protected virtual void OnTabChanged(EventArgs empty) 
        => TabChanged?.Invoke(this, empty);
}
