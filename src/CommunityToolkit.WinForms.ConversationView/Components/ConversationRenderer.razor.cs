using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;

namespace CommunityToolkit.WinForms.ChatUI.Components;

/// <summary>
///  MarkDown renderer component - based on Alexander Mutel's MarkDig, 
///  Copyright by Alexander Mutel.
/// </summary>
public partial class ConversationRenderer : ComponentBase
{
    private Conversation _viewModel = null!;
    private ObservableCollection<ConversationItem>? _conversationItems;

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    [Parameter]
    public Conversation ConversationVm
    {
        get => _viewModel;
        set
        {
            _viewModel = value;
        }
    }

    [Parameter]
    public string BackColor { get; set; } = null!;

    [Parameter]
    public bool DarkMode { get; set; }

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        if (ConversationVm is not null)
        {
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            SetConversationItems(_viewModel.ConversationItems);
        }

        // Set the background color of the root HTML element:
        if (JSRuntime is not null)
        {
            await JSRuntime.InvokeVoidAsync("setRootBackgroundColor", BackColor);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (JSRuntime is null)
        {
            return;
        }

        await JSRuntime.InvokeVoidAsync("scrollToBottom");
    }

    private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ChatUI.Conversation.ConversationItems))
        {
            SetConversationItems(_viewModel.ConversationItems);
        }

        // We need to make sure, that we can suspend the updates to avoid flickering.
        // The property `ViewUpdatesSuspended` is itself an observable property.
        // So, when we're changing it back to `false`, we need to call `StateHasChanged`.
        // But since it fires PropertyChanged, when it becomes false, we end up here,
        // and then invoke the changes.
        if (!ConversationVm.ViewUpdatesSuspended)
        {
            InvokeAsync(StateHasChanged);
        }
    }

    private void SetConversationItems(ObservableCollection<ConversationItem>? conversationItems)
    {
        if (_conversationItems is not null)
        {
            _conversationItems.CollectionChanged -= ConversationItems_CollectionChanged;
        }

        _conversationItems = conversationItems;

        if (_conversationItems is not null)
        {
            _conversationItems.CollectionChanged += ConversationItems_CollectionChanged;
        }
    }

    private void ConversationItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
