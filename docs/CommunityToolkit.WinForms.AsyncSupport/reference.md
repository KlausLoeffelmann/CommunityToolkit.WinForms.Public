<a name='assembly'></a>
# CommunityToolkit.WinForms.AsyncSupport

## Contents

- [AsyncEventHandler](#T-CommunityToolkit-WinForms-AsyncSupport-AsyncEventHandler 'CommunityToolkit.WinForms.AsyncSupport.AsyncEventHandler')
- [AsyncTaskQueue](#T-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue')
  - [#ctor()](#M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-#ctor-System-Int32- 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue.#ctor(System.Int32)')
  - [Dispose()](#M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-Dispose 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue.Dispose')
  - [EnqueueAsync(asyncMethod)](#M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-EnqueueAsync-System-Func{System-Threading-Tasks-Task}- 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue.EnqueueAsync(System.Func{System.Threading.Tasks.Task})')
  - [ProcessQueueAsync()](#M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-ProcessQueueAsync 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue.ProcessQueueAsync')
  - [WaitProcessedAsync()](#M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-WaitProcessedAsync 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue.WaitProcessedAsync')
- [AwaitableComponentExtensions](#T-CommunityToolkit-WinForms-AsyncSupport-AwaitableComponentExtensions 'CommunityToolkit.WinForms.AsyncSupport.AwaitableComponentExtensions')
  - [WhenAny(controlAwaitables,additionalAwaitables)](#M-CommunityToolkit-WinForms-AsyncSupport-AwaitableComponentExtensions-WhenAny-System-Collections-Generic-IEnumerable{CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent},System-Collections-Generic-IEnumerable{CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent}- 'CommunityToolkit.WinForms.AsyncSupport.AwaitableComponentExtensions.WhenAny(System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent},System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent})')
- [AwaitableEvent\`1](#T-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1')
  - [#ctor()](#M-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-#ctor 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1.#ctor')
  - [EventAction](#P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-EventAction 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1.EventAction')
  - [EventCompletion](#P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-EventCompletion 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1.EventCompletion')
  - [Sender](#P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-Sender 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1.Sender')
  - [CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter()](#M-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1.CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter')
- [AwaitableForm](#T-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm 'CommunityToolkit.WinForms.AsyncSupport.AwaitableForm')
  - [#ctor()](#M-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-#ctor-System-Windows-Forms-Form- 'CommunityToolkit.WinForms.AsyncSupport.AwaitableForm.#ctor(System.Windows.Forms.Form)')
  - [Form](#P-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-Form 'CommunityToolkit.WinForms.AsyncSupport.AwaitableForm.Form')
  - [CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter()](#M-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter 'CommunityToolkit.WinForms.AsyncSupport.AwaitableForm.CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter')
- [IAwaitableComponent](#T-CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent 'CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent')
  - [GetAwaiter()](#M-CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent-GetAwaiter 'CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent.GetAwaiter')

<a name='T-CommunityToolkit-WinForms-AsyncSupport-AsyncEventHandler'></a>
## AsyncEventHandler `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

##### Summary

Represents the method that will handle the asynchronous click event of the [](#!-AsyncButton 'AsyncButton') control.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:CommunityToolkit.WinForms.AsyncSupport.AsyncEventHandler](#T-T-CommunityToolkit-WinForms-AsyncSupport-AsyncEventHandler 'T:CommunityToolkit.WinForms.AsyncSupport.AsyncEventHandler') | The source of the event. |

<a name='T-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue'></a>
## AsyncTaskQueue `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

##### Summary

Represents a queue for managing asynchronous tasks.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-#ctor-System-Int32-'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [AsyncTaskQueue](#T-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue') class.

##### Parameters

This constructor has no parameters.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-Dispose'></a>
### Dispose() `method`

##### Summary

Releases all resources used by the [AsyncTaskQueue](#T-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue 'CommunityToolkit.WinForms.AsyncSupport.AsyncTaskQueue').

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-EnqueueAsync-System-Func{System-Threading-Tasks-Task}-'></a>
### EnqueueAsync(asyncMethod) `method`

##### Summary

Enqueues an asynchronous method to be executed and waits if the queue is full.

##### Returns

A task that completes when the method is enqueued.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| asyncMethod | [System.Func{System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Threading.Tasks.Task}') | The asynchronous method to enqueue. |

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-ProcessQueueAsync'></a>
### ProcessQueueAsync() `method`

##### Summary

Processes the queue of tasks asynchronously.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AsyncTaskQueue-WaitProcessedAsync'></a>
### WaitProcessedAsync() `method`

##### Summary

Returns a task that completes when all tasks in the queue have been processed.

##### Parameters

This method has no parameters.

<a name='T-CommunityToolkit-WinForms-AsyncSupport-AwaitableComponentExtensions'></a>
## AwaitableComponentExtensions `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AwaitableComponentExtensions-WhenAny-System-Collections-Generic-IEnumerable{CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent},System-Collections-Generic-IEnumerable{CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent}-'></a>
### WhenAny(controlAwaitables,additionalAwaitables) `method`

##### Summary

Waits for any of the specified awaitable components to complete.

##### Returns

A task that represents the first completed awaitable component.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| controlAwaitables | [System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent}') | The collection of awaitable components to wait for. |
| additionalAwaitables | [System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{CommunityToolkit.WinForms.AsyncSupport.IAwaitableComponent}') | Additional collections of awaitable components to wait for. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when `controlAwaitables` is null. |

<a name='T-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1'></a>
## AwaitableEvent\`1 `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

##### Summary

Represents an awaitable event that can be used with the await keyword.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the event arguments. |

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [AwaitableEvent\`1](#T-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1 'CommunityToolkit.WinForms.AsyncSupport.AwaitableEvent`1') class.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-EventAction'></a>
### EventAction `property`

##### Summary

Gets the action to be executed when the event is raised.

<a name='P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-EventCompletion'></a>
### EventCompletion `property`

##### Summary

Gets the task completion source for the event.

<a name='P-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-Sender'></a>
### Sender `property`

##### Summary

Gets the sender of the event.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AwaitableEvent`1-CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter'></a>
### CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter() `method`

##### Summary

Gets the awaiter for the component.

##### Returns

An object that implements the [INotifyCompletion](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.CompilerServices.INotifyCompletion 'System.Runtime.CompilerServices.INotifyCompletion') interface.

##### Parameters

This method has no parameters.

<a name='T-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm'></a>
## AwaitableForm `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

##### Summary

Represents a form that can be awaited asynchronously.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-#ctor-System-Windows-Forms-Form-'></a>
### #ctor() `constructor`

##### Summary

Represents a form that can be awaited asynchronously.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-Form'></a>
### Form `property`

##### Summary

Gets the underlying form.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-AwaitableForm-CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter'></a>
### CommunityToolkit#WinForms#AsyncSupport#IAwaitableComponent#GetAwaiter() `method`

##### Summary

Gets the awaiter for the form, allowing it to be awaited.

##### Returns

An object that implements the [INotifyCompletion](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.CompilerServices.INotifyCompletion 'System.Runtime.CompilerServices.INotifyCompletion') interface.

##### Parameters

This method has no parameters.

<a name='T-CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent'></a>
## IAwaitableComponent `type`

##### Namespace

CommunityToolkit.WinForms.AsyncSupport

##### Summary

Represents an awaitable component that can be used with the await keyword.

<a name='M-CommunityToolkit-WinForms-AsyncSupport-IAwaitableComponent-GetAwaiter'></a>
### GetAwaiter() `method`

##### Summary

Gets the awaiter for the component.

##### Returns

An object that implements the [INotifyCompletion](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.CompilerServices.INotifyCompletion 'System.Runtime.CompilerServices.INotifyCompletion') interface.

##### Parameters

This method has no parameters.
