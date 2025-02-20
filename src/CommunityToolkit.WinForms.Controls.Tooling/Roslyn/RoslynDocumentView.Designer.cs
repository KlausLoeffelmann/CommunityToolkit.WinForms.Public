using CommunityToolkit.WinForms.FluentUI.Containers;

namespace CommunityToolkit.WinForms.Controls.Tooling.Roslyn;

partial class RoslynDocumentView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _sourceCodeViewer = new RoslynSourceView();
        _splitterMain = new SplitContainer();
        _lblListingTitel = new Label();
        diagnosticsListView1 = new DiagnosticsListView();
        ((System.ComponentModel.ISupportInitialize)_splitterMain).BeginInit();
        _splitterMain.Panel1.SuspendLayout();
        _splitterMain.Panel2.SuspendLayout();
        _splitterMain.SuspendLayout();
        SuspendLayout();
        // 
        // _sourceCodeViewer
        // 
        _sourceCodeViewer.Dock = DockStyle.Fill;
        _sourceCodeViewer.Location = new Point(8, 46);
        _sourceCodeViewer.Margin = new Padding(2);
        _sourceCodeViewer.Name = "_sourceCodeViewer";
        _sourceCodeViewer.ReadOnly = true;
        _sourceCodeViewer.Size = new Size(802, 350);
        _sourceCodeViewer.TabIndex = 0;
        // 
        // _splitterMain
        // 
        _splitterMain.Dock = DockStyle.Fill;
        _splitterMain.Location = new Point(8, 8);
        _splitterMain.Margin = new Padding(2);
        _splitterMain.Name = "_splitterMain";
        _splitterMain.Orientation = Orientation.Horizontal;
        // 
        // _splitterMain.Panel1
        // 
        _splitterMain.Panel1.Controls.Add(_sourceCodeViewer);
        _splitterMain.Panel1.Controls.Add(_lblListingTitel);
        _splitterMain.Panel1.Padding = new Padding(8);
        // 
        // _splitterMain.Panel2
        // 
        _splitterMain.Panel2.Controls.Add(diagnosticsListView1);
        _splitterMain.Panel2.Padding = new Padding(8);
        _splitterMain.Size = new Size(818, 586);
        _splitterMain.SplitterDistance = 404;
        _splitterMain.SplitterWidth = 3;
        _splitterMain.TabIndex = 1;
        // 
        // _lblListingTitel
        // 
        _lblListingTitel.BorderStyle = BorderStyle.FixedSingle;
        _lblListingTitel.Dock = DockStyle.Top;
        _lblListingTitel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        _lblListingTitel.Location = new Point(8, 8);
        _lblListingTitel.Name = "_lblListingTitel";
        _lblListingTitel.Padding = new Padding(3);
        _lblListingTitel.Size = new Size(802, 38);
        _lblListingTitel.TabIndex = 1;
        _lblListingTitel.Text = "- untitled -";
        _lblListingTitel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // diagnosticsListView1
        // 
        diagnosticsListView1.AllowColumnReorder = true;
        diagnosticsListView1.CheckBoxes = true;
        diagnosticsListView1.Dock = DockStyle.Fill;
        diagnosticsListView1.FullRowSelect = true;
        diagnosticsListView1.GridLines = true;
        diagnosticsListView1.LabelEdit = true;
        diagnosticsListView1.Location = new Point(8, 8);
        diagnosticsListView1.Name = "diagnosticsListView1";
        diagnosticsListView1.Size = new Size(802, 163);
        diagnosticsListView1.Sorting = SortOrder.Ascending;
        diagnosticsListView1.TabIndex = 0;
        diagnosticsListView1.UseCompatibleStateImageBehavior = false;
        diagnosticsListView1.View = View.Details;
        // 
        // RoslynDocumentView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_splitterMain);
        Margin = new Padding(2);
        Name = "RoslynDocumentView";
        Padding = new Padding(8);
        Size = new Size(834, 602);
        _splitterMain.Panel1.ResumeLayout(false);
        _splitterMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_splitterMain).EndInit();
        _splitterMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private RoslynSourceView _sourceCodeViewer;
    private SplitContainer _splitterMain;
    private Label _lblListingTitel;
    private DiagnosticsListView diagnosticsListView1;
}
