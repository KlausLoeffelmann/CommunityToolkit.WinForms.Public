<a name='assembly'></a>
# CommunityToolkit.WinForms.Controls.Tooling

## Contents

- [ConsoleControl](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl')
  - [#ctor()](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-#ctor 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.#ctor')
  - [ResetAsync()](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-ResetAsync 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.ResetAsync')
  - [ResetStylesAsync(resetStyles)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-ResetStylesAsync 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.ResetStylesAsync')
  - [SetStyleAsync(textColor,style,size,keepSetting)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-SetStyleAsync-System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.SetStyleAsync(System.Nullable{System.Drawing.Color},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize},System.Boolean)')
  - [WriteAsync(text,textColor,style,size,keepStyles)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-WriteAsync-System-String,System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.WriteAsync(System.String,System.Nullable{System.Drawing.Color},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize},System.Boolean)')
  - [WriteLineAsync(text,textColor,style,size,keepStyles)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-WriteLineAsync-System-String,System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.WriteLineAsync(System.String,System.Nullable{System.Drawing.Color},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle},System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize},System.Boolean)')
- [CustomFontStyle](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle')
  - [Bold](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Bold 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle.Bold')
  - [Italic](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Italic 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle.Italic')
  - [Normal](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Normal 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle.Normal')
  - [StrikeThrough](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-StrikeThrough 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle.StrikeThrough')
  - [Underline](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Underline 'CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle.Underline')
- [DataFormat](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat 'CommunityToolkit.WinForms.Controls.Tooling.Console.DataFormat')
  - [Decimal](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Decimal 'CommunityToolkit.WinForms.Controls.Tooling.Console.DataFormat.Decimal')
  - [Hex](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Hex 'CommunityToolkit.WinForms.Controls.Tooling.Console.DataFormat.Hex')
  - [Oct](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Oct 'CommunityToolkit.WinForms.Controls.Tooling.Console.DataFormat.Oct')
- [FilenameDisambiguator](#T-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator')
  - [#ctor()](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor')
  - [#ctor(title,extension,combineUniquePath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor(System.String,System.String,System.Boolean)')
  - [#ctor(title,basePath,extension,combineUniquePath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-String,System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor(System.String,System.String,System.String,System.Boolean)')
  - [#ctor(generationStrategy,extension,combineUniquePath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-String,System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor(CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy,System.String,System.Boolean)')
  - [#ctor(title,extension,generationStrategy,combineUniquePath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor(System.String,System.String,CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy,System.Boolean)')
  - [#ctor(title,basePath,extension,generationStrategy,combineUniquePath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-String,CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.#ctor(System.String,System.String,System.String,CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy,System.Boolean)')
  - [BasePath](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-BasePath 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.BasePath')
  - [CombineUniquePath](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-CombineUniquePath 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.CombineUniquePath')
  - [DateFilenameAmendmentFormat](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-DateFilenameAmendmentFormat 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.DateFilenameAmendmentFormat')
  - [Extension](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Extension 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.Extension')
  - [FilenameCandidate](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-FilenameCandidate 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.FilenameCandidate')
  - [FolderCandidate](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-FolderCandidate 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.FolderCandidate')
  - [GenerationStrategy](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GenerationStrategy 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.GenerationStrategy')
  - [MaxLengthFilename](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-MaxLengthFilename 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.MaxLengthFilename')
  - [MaxLengthFolder](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-MaxLengthFolder 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.MaxLengthFolder')
  - [Title](#P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Title 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.Title')
  - [ExpandPath(path)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-ExpandPath-System-String- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.ExpandPath(System.String)')
  - [GetResultingFilename()](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GetResultingFilename 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.GetResultingFilename')
  - [GetResultingFoldername()](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GetResultingFoldername 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.GetResultingFoldername')
  - [Sanitize(input)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Sanitize-System-String- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.Sanitize(System.String)')
  - [ShrinkPath(fullPath)](#M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-ShrinkPath-System-String- 'CommunityToolkit.WinForms.Controls.Tooling.IO.FilenameDisambiguator.ShrinkPath(System.String)')
- [FontSize](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize')
  - [Large](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Large 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize.Large')
  - [Larger](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Larger 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize.Larger')
  - [Normal](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Normal 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize.Normal')
  - [Small](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Small 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize.Small')
  - [Smaller](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Smaller 'CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize.Smaller')
- [GenerationStrategy](#T-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy')
  - [DateAmended](#F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-DateAmended 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy.DateAmended')
  - [DateBased](#F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-DateBased 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy.DateBased')
  - [GuidBase](#F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-GuidBase 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy.GuidBase')
  - [None](#F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-None 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy.None')
- [HexAsciiDumper](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper')
  - [#ctor()](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-#ctor 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.#ctor')
  - [BytesPerRow](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-BytesPerRow 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.BytesPerRow')
  - [DataFormat](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-DataFormat 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.DataFormat')
  - [ShowText](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-ShowText 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.ShowText')
  - [Flush()](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-Flush 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.Flush')
  - [GetRemaining()](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-GetRemaining 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.GetRemaining')
  - [TryGetString(newData,result)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-Byte[],System-String@- 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.TryGetString(System.Byte[],System.String@)')
  - [TryGetString(newData,result)](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-String,System-String@- 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.TryGetString(System.String,System.String@)')
- [MergingClassifier](#T-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-MergingClassifier 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.MergingClassifier')
- [RoslynDocumentView](#T-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView')
  - [#ctor()](#M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-#ctor 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.#ctor')
  - [components](#F-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-components 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.components')
  - [CodeBlockInfo](#P-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-CodeBlockInfo 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.CodeBlockInfo')
  - [RoslynSourceView](#P-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-RoslynSourceView 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.RoslynSourceView')
  - [Dispose(disposing)](#M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-Dispose-System-Boolean- 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-InitializeComponent 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.InitializeComponent')
  - [SaveFileAsync()](#M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-SaveFileAsync-System-String- 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.SaveFileAsync(System.String)')
  - [SetCodeBlockInfoAsync(codeBlockInfo)](#M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-SetCodeBlockInfoAsync-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo- 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView.SetCodeBlockInfoAsync(CommunityToolkit.Roslyn.Tooling.CodeBlockInfo)')
- [ShowText](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText 'CommunityToolkit.WinForms.Controls.Tooling.Console.ShowText')
  - [ASCII](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-ASCII 'CommunityToolkit.WinForms.Controls.Tooling.Console.ShowText.ASCII')
  - [None](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-None 'CommunityToolkit.WinForms.Controls.Tooling.Console.ShowText.None')
  - [Unicode](#F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-Unicode 'CommunityToolkit.WinForms.Controls.Tooling.Console.ShowText.Unicode')

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl'></a>
## ConsoleControl `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

##### Summary

Represents a custom control that provides a console-like interface.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ConsoleControl](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl 'CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl') class.

##### Parameters

This constructor has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-ResetAsync'></a>
### ResetAsync() `method`

##### Summary

Cancels all pending Write/WriteLine/Style tasks and clears the console control.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-ResetStylesAsync'></a>
### ResetStylesAsync(resetStyles) `method`

##### Summary

Resets the styles.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| resetStyles | [M:CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.ResetStylesAsync](#T-M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-ResetStylesAsync 'M:CommunityToolkit.WinForms.Controls.Tooling.Console.ConsoleControl.ResetStylesAsync') | Indicates whether to reset the text styles. (Optional) |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-SetStyleAsync-System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean-'></a>
### SetStyleAsync(textColor,style,size,keepSetting) `method`

##### Summary

Sets the text styles for the console control.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| textColor | [System.Nullable{System.Drawing.Color}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Drawing.Color}') | The color of the text. (Optional) |
| style | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}') | The font style of the text. (Optional) |
| size | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}') | The font size of the text. (Optional) |
| keepSetting | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to keep the current text styles. (Optional) |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-WriteAsync-System-String,System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean-'></a>
### WriteAsync(text,textColor,style,size,keepStyles) `method`

##### Summary

Writes the specified text asynchronously to the console control.

##### Returns

A task representing the asynchronous operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to write. |
| textColor | [System.Nullable{System.Drawing.Color}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Drawing.Color}') | The color of the text. (Optional) |
| style | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}') | The font style of the text. (Optional) |
| size | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}') | The font size of the text. (Optional) |
| keepStyles | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to keep the current text styles. (Optional) |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-ConsoleControl-WriteLineAsync-System-String,System-Nullable{System-Drawing-Color},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle},System-Nullable{CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize},System-Boolean-'></a>
### WriteLineAsync(text,textColor,style,size,keepStyles) `method`

##### Summary

Writes the specified text followed by a new line asynchronously to the console control.

##### Returns

A task representing the asynchronous operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to write. (Optional) |
| textColor | [System.Nullable{System.Drawing.Color}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Drawing.Color}') | The color of the text. (Optional) |
| style | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.CustomFontStyle}') | The font style of the text. (Optional) |
| size | [System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{CommunityToolkit.WinForms.Controls.Tooling.Console.FontSize}') | The font size of the text. (Optional) |
| keepStyles | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to keep the current text styles. (Optional) |

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle'></a>
## CustomFontStyle `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Bold'></a>
### Bold `constants`

##### Summary

Represents bold font style.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Italic'></a>
### Italic `constants`

##### Summary

Represents italic font style.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Normal'></a>
### Normal `constants`

##### Summary

Represents normal font style.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-StrikeThrough'></a>
### StrikeThrough `constants`

##### Summary

Represents strikethrough font style.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-CustomFontStyle-Underline'></a>
### Underline `constants`

##### Summary

Represents underline font style.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat'></a>
## DataFormat `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

##### Summary

Specifies the data format for the [HexAsciiDumper](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper') class.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Decimal'></a>
### Decimal `constants`

##### Summary

Decimal format.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Hex'></a>
### Hex `constants`

##### Summary

Hexadecimal format.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-DataFormat-Oct'></a>
### Oct `constants`

##### Summary

Octal format.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator'></a>
## FilenameDisambiguator `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.IO

##### Summary

Provides methods to generate and disambiguate filenames and folders based on various strategies.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Parameterless constructor.

##### Parameters

This constructor has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-Boolean-'></a>
### #ctor(title,extension,combineUniquePath) `constructor`

##### Summary

Initializes a new instance with the specified title and extension.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title used to generate the filename and folder. |
| extension | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file extension including the leading dot. |
| combineUniquePath | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, a unique folder (derived from the Title) will be generated. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-String,System-Boolean-'></a>
### #ctor(title,basePath,extension,combineUniquePath) `constructor`

##### Summary

Initializes a new instance with the specified title, base path, and extension.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title used to generate the filename and folder. |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base folder path. |
| extension | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file extension including the leading dot. |
| combineUniquePath | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, a unique folder (derived from the Title) will be generated. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-String,System-Boolean-'></a>
### #ctor(generationStrategy,extension,combineUniquePath) `constructor`

##### Summary

Initializes a new instance with the specified generation strategy and extension.
Title is not provided so only DateBased or GuidBase are allowed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| generationStrategy | [CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy](#T-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy') | The generation strategy. Must be DateBased or GuidBase. |
| extension | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file extension including the leading dot. |
| combineUniquePath | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, a unique folder (using a default FolderCandidate) will be generated. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if an invalid generation strategy is provided. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-Boolean-'></a>
### #ctor(title,extension,generationStrategy,combineUniquePath) `constructor`

##### Summary

Initializes a new instance with the specified title, extension, and generation strategy.
When a Title is provided, only DateAmended is allowed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title used to generate the filename and folder. |
| extension | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file extension including the leading dot. |
| generationStrategy | [CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy](#T-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy') | The generation strategy. Must be DateAmended. |
| combineUniquePath | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, a unique folder (derived from the Title) will be generated. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if generationStrategy is not DateAmended. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-#ctor-System-String,System-String,System-String,CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy,System-Boolean-'></a>
### #ctor(title,basePath,extension,generationStrategy,combineUniquePath) `constructor`

##### Summary

Initializes a new instance with the specified title, base path, extension, and generation strategy.
When a Title is provided, only DateAmended is allowed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The title used to generate the filename and folder. |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base folder path. |
| extension | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The file extension including the leading dot. |
| generationStrategy | [CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy](#T-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy 'CommunityToolkit.WinForms.Controls.Tooling.IO.GenerationStrategy') | The generation strategy. Must be DateAmended. |
| combineUniquePath | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, a unique folder (derived from the Title) will be generated. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if generationStrategy is not DateAmended. |

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-BasePath'></a>
### BasePath `property`

##### Summary

Gets or sets the base folder path.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-CombineUniquePath'></a>
### CombineUniquePath `property`

##### Summary

Gets or sets a value indicating whether both a unique folder and file should be generated.
When true, the file will be placed in a unique folder derived from the Title.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-DateFilenameAmendmentFormat'></a>
### DateFilenameAmendmentFormat `property`

##### Summary

Gets or sets the date format used when generating a filename based on date.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Extension'></a>
### Extension `property`

##### Summary

Gets or sets the file extension, including the leading dot.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if set to null. |

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-FilenameCandidate'></a>
### FilenameCandidate `property`

##### Summary

Gets the candidate filename (without extension) based on the provided parameters.
This value is computed but is not necessarily unique until disambiguation.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-FolderCandidate'></a>
### FolderCandidate `property`

##### Summary

Gets the candidate folder name based on the Title.
This value is computed but is not necessarily unique until disambiguation.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GenerationStrategy'></a>
### GenerationStrategy `property`

##### Summary

Gets or sets the auto‑generation strategy for the filename.
Changing this property will validate against the current Title.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if an implausible value is set based on Title. |

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-MaxLengthFilename'></a>
### MaxLengthFilename `property`

##### Summary

Gets or sets the maximum allowed length for the generated filename.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-MaxLengthFolder'></a>
### MaxLengthFolder `property`

##### Summary

Gets or sets the maximum allowed length for the generated folder name.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Title'></a>
### Title `property`

##### Summary

Gets or sets the title used to generate the filename and folder.
Setting the Title resets GenerationStrategy to None unless it is already DateAmended.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-ExpandPath-System-String-'></a>
### ExpandPath(path) `method`

##### Summary

Expands the given path by replacing environment variables with their values.

##### Returns

The expanded path.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path containing environment variables to expand. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GetResultingFilename'></a>
### GetResultingFilename() `method`

##### Summary

Returns the resulting filename tuple after disambiguation.
The tuple contains the folder, filename (without extension), and extension.

##### Returns

A tuple of (folder, filename, extension).

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-GetResultingFoldername'></a>
### GetResultingFoldername() `method`

##### Summary

Returns the resulting folder name after disambiguation.
If CombineUniquePath is false, returns BasePath.

##### Returns

The resulting unique folder name.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-Sanitize-System-String-'></a>
### Sanitize(input) `method`

##### Summary

Sanitizes the input string by removing invalid filename characters.

##### Returns

A sanitized string safe for use in filenames and folder names.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input string to sanitize. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-IO-FilenameDisambiguator-ShrinkPath-System-String-'></a>
### ShrinkPath(fullPath) `method`

##### Summary

Shrinks the given full path by replacing known environment variable values with their names.

##### Returns

The shrunk path with environment variable names.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fullPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The full path to shrink. |

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize'></a>
## FontSize `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

##### Summary

Represents the font size options for the console control.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Large'></a>
### Large `constants`

##### Summary

Large font size.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Larger'></a>
### Larger `constants`

##### Summary

Larger font size.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Normal'></a>
### Normal `constants`

##### Summary

Normal font size.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Small'></a>
### Small `constants`

##### Summary

Small font size.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-FontSize-Smaller'></a>
### Smaller `constants`

##### Summary

Smaller font size.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy'></a>
## GenerationStrategy `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.IO

##### Summary

Specifies the auto‑generation strategy for the filename.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-DateAmended'></a>
### DateAmended `constants`

##### Summary

Generate filename by combining Title and current date/time.
Only works if Title is provided.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-DateBased'></a>
### DateBased `constants`

##### Summary

Generate filename based on current date and time.
Only works if Title is not provided.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-GuidBase'></a>
### GuidBase `constants`

##### Summary

Generate filename as a GUID.
Only works if Title is not provided.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-IO-GenerationStrategy-None'></a>
### None `constants`

##### Summary

No auto‑generation. Use Title as provided.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper'></a>
## HexAsciiDumper `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

##### Summary

Provides functionality to convert byte arrays or strings into formatted hexadecimal, octal, or decimal representations with optional ASCII or Unicode text display.

##### Remarks

The [HexAsciiDumper](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper') class allows you to convert byte arrays or strings into a formatted string representation. You can specify the number of bytes per row, the data format (hexadecimal, octal, or decimal), and whether to show the text representation (ASCII or Unicode).

Example usage:

```
var dumper = new HexAsciiDumper
{
    BytesPerRow = 16,
    DataFormat = DataFormat.Hex,
    ShowText = ShowText.ASCII
};
byte[] data = { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
if (dumper.TryGetString(data, out string? result))
{
    Console.WriteLine(result);
}
```

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [HexAsciiDumper](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper') class with default settings.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-BytesPerRow'></a>
### BytesPerRow `property`

##### Summary

Gets or sets the number of bytes per row in the output.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown when the value is not 4, 8, 16, or 32. |

##### Remarks

The [BytesPerRow](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-BytesPerRow 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.BytesPerRow') property determines how many bytes are displayed in each row of the output.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-DataFormat'></a>
### DataFormat `property`

##### Summary

Gets or sets the data format for the output.

##### Remarks

The [DataFormat](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-DataFormat 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.DataFormat') property determines how the byte values are formatted in the output.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-ShowText'></a>
### ShowText `property`

##### Summary

Gets or sets a value indicating whether to show the text representation of the data.

##### Remarks

The [ShowText](#P-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-ShowText 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.ShowText') property determines whether and how the text representation of the byte values is displayed in the output.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-Flush'></a>
### Flush() `method`

##### Summary

Clears the internal buffer.

##### Parameters

This method has no parameters.

##### Remarks

The [Flush](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-Flush 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.Flush') method clears the internal buffer, discarding any unprocessed data.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-GetRemaining'></a>
### GetRemaining() `method`

##### Summary

Gets the remaining unprocessed data in the buffer.

##### Returns

A string containing the remaining unprocessed data.

##### Parameters

This method has no parameters.

##### Remarks

The [GetRemaining](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-GetRemaining 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.GetRemaining') method returns the remaining unprocessed data in the buffer and clears the buffer.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-Byte[],System-String@-'></a>
### TryGetString(newData,result) `method`

##### Summary

Tries to get a formatted string representation of the provided byte array.

##### Returns

`true` if the conversion succeeded; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newData | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | The byte array to format. |
| result | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | When this method returns, contains the formatted string representation if the conversion succeeded, or `null` if it failed. |

##### Remarks

The [TryGetString](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-Byte[],System-String@- 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.TryGetString(System.Byte[],System.String@)') method appends the provided byte array to the internal buffer and attempts to convert it to a formatted string representation.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-String,System-String@-'></a>
### TryGetString(newData,result) `method`

##### Summary

Tries to get a formatted string representation of the provided string.

##### Returns

`true` if the conversion succeeded; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newData | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string to format. |
| result | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | When this method returns, contains the formatted string representation if the conversion succeeded, or `null` if it failed. |

##### Remarks

The [TryGetString](#M-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper-TryGetString-System-String,System-String@- 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper.TryGetString(System.String,System.String@)') method appends the provided string to the internal buffer and attempts to convert it to a formatted string representation.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-MergingClassifier'></a>
## MergingClassifier `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Roslyn

##### Summary

Provide a way to iterate through classified and unclassified text spans
 to include white spaces and complete other trivia in the return stream.

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView'></a>
## RoslynDocumentView `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Roslyn

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [RoslynDocumentView](#T-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView 'CommunityToolkit.WinForms.Controls.Tooling.Roslyn.RoslynDocumentView') class.

##### Parameters

This constructor has no parameters.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-CodeBlockInfo'></a>
### CodeBlockInfo `property`

##### Summary

Gets the listing file.

<a name='P-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-RoslynSourceView'></a>
### RoslynSourceView `property`

##### Summary

Gets the source code viewer.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-SaveFileAsync-System-String-'></a>
### SaveFileAsync() `method`

##### Summary

Saves the listing file asynchronously.

##### Returns

A task that represents the asynchronous save operation.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when no listing file is set. |

<a name='M-CommunityToolkit-WinForms-Controls-Tooling-Roslyn-RoslynDocumentView-SetCodeBlockInfoAsync-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-'></a>
### SetCodeBlockInfoAsync(codeBlockInfo) `method`

##### Summary

Sets the listing file asynchronously.

##### Returns

A task that represents the asynchronous set operation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| codeBlockInfo | [CommunityToolkit.Roslyn.Tooling.CodeBlockInfo](#T-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo') | The listing file to set. |

<a name='T-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText'></a>
## ShowText `type`

##### Namespace

CommunityToolkit.WinForms.Controls.Tooling.Console

##### Summary

Specifies whether and how to show the text representation of the data in the [HexAsciiDumper](#T-CommunityToolkit-WinForms-Controls-Tooling-Console-HexAsciiDumper 'CommunityToolkit.WinForms.Controls.Tooling.Console.HexAsciiDumper') class.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-ASCII'></a>
### ASCII `constants`

##### Summary

Show ASCII text representation.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-None'></a>
### None `constants`

##### Summary

Do not show text representation.

<a name='F-CommunityToolkit-WinForms-Controls-Tooling-Console-ShowText-Unicode'></a>
### Unicode `constants`

##### Summary

Show Unicode text representation.
