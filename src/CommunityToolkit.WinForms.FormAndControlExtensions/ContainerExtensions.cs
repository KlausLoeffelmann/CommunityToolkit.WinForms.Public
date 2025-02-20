namespace CommunityToolkit.WinForms.Extensions.FormAndControlExtensions;

public static class ContainerExtensions
{
    /// <summary>
    ///  Suspends the layout logic for the control and all its child controls recursively.
    /// </summary>
    /// <param name="control">The container control whose layout logic to suspend.</param>
    /// <remarks>
    ///  <para>
    ///   This method suspends the layout logic for the specified control and all its child controls
    ///   recursively. This is useful when you need to perform multiple layout changes and want to
    ///   avoid unnecessary layout recalculations.
    ///  </para>
    /// </remarks>
    public static void SuspendLayoutRecursively(this ScrollableControl control)
    {
        foreach (Control child in control.Controls)
        {
            if (child is ScrollableControl scrollableControl)
            {
                scrollableControl.SuspendLayoutRecursively();
            }
        }
    }

    /// <summary>
    ///  Resumes usual layout logic for the control and all its child controls recursively.
    /// </summary>
    /// <param name="control">The container control whose layout logic to resume.</param>
    /// <remarks>
    ///  <para>
    ///   This method resumes the layout logic for the specified control and all its child controls
    ///   recursively. This should be called after SuspendLayoutRecursively to apply the layout changes.
    ///  </para>
    /// </remarks>
    public static void ResumeLayoutRecursively(this ScrollableControl control)
    {
        foreach (Control child in control.Controls)
        {
            if (child is ScrollableControl scrollableControl)
            {
                scrollableControl.ResumeLayoutRecursively();
            }
        }
    }

    /// <summary>
    ///  Embeds the control into a new container of type T.
    /// </summary>
    /// <typeparam name="T">The type of the container control.</typeparam>
    /// <param name="control">The control to embed.</param>
    /// <param name="embedderDockStyle">The dock style of the container.</param>
    /// <param name="embedeeDockStyle">The dock style of the embedded control.</param>
    /// <param name="padding">The padding for the container.</param>
    /// <returns>The newly created container of type T.</returns>
    /// <remarks>
    ///  <para>
    ///   This method creates a new container of type T, sets its dock style, and embeds the specified
    ///   control into it. The embedded control's dock style and the container's padding can also be set.
    ///  </para>
    /// </remarks>
    public static T EmbedIn<T>(
        this Control control,
        DockStyle embedderDockStyle = DockStyle.Fill,
        DockStyle embedeeDockStyle = DockStyle.Fill,
        Padding? padding = default)
        where T : Control, new()
    {
        T container = new()
        {
            Dock = embedderDockStyle
        };

        container.SuspendLayout();

        if (padding.HasValue)
        {
            container.Padding = padding.Value;
        }

        control.Controls.Add(container);
        control.Dock = embedeeDockStyle;
        container.ResumeLayout();

        return container;
    }

    /// <summary>
    ///  Embeds the control into a new container of type T with specified padding.
    /// </summary>
    /// <typeparam name="T">The type of the container control.</typeparam>
    /// <param name="control">The control to embed.</param>
    /// <param name="embedderDockStyle">The dock style of the container.</param>
    /// <param name="embedeeDockStyle">The dock style of the embedded control.</param>
    /// <param name="allPadding">The padding for the container.</param>
    /// <returns>The newly created container of type T.</returns>
    /// <remarks>
    ///  <para>
    ///   This method creates a new container of type T, sets its dock style, and embeds the specified
    ///   control into it. The embedded control's dock style and the container's padding can also be set.
    ///  </para>
    /// </remarks>
    public static T EmbedIn<T>(
        this Control control,
        DockStyle embedderDockStyle = DockStyle.Fill,
        DockStyle embedeeDockStyle = DockStyle.Fill,
        int? allPadding = default)
        where T : Control, new()
            => control.EmbedIn<T>(
                embedderDockStyle: embedderDockStyle,
                embedeeDockStyle: embedeeDockStyle,
                padding: new Padding(allPadding ?? 0));
}
