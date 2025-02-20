<a name='assembly'></a>
# CommunityToolkit.Roslyn

## Contents

- [CodeBlockInfo](#T-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo')
  - [Code](#P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Code 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo.Code')
  - [Description](#P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Description 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo.Description')
  - [Filename](#P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Filename 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo.Filename')
  - [Language](#P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Language 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo.Language')
  - [Type](#P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Type 'CommunityToolkit.Roslyn.Tooling.CodeBlockInfo.Type')
- [CommentBlock](#T-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock')
  - [#ctor()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-#ctor 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock.#ctor')
  - [Comment](#P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-Comment 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock.Comment')
  - [Guid](#P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-Guid 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock.Guid')
  - [IndentationLevel](#P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-IndentationLevel 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock.IndentationLevel')
- [DocumentExtensions](#T-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions')
  - [GetAllCommentBlocks(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetAllCommentBlocks-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetAllCommentBlocks(Microsoft.CodeAnalysis.Document)')
  - [GetClassCountAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassCountAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetClassCountAsync(Microsoft.CodeAnalysis.Document)')
  - [GetClassesAndNestedClassesAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassesAndNestedClassesAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetClassesAndNestedClassesAsync(Microsoft.CodeAnalysis.Document)')
  - [GetClassesAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassesAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetClassesAsync(Microsoft.CodeAnalysis.Document)')
  - [GetDocumentIntroduction()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetDocumentIntroduction-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetDocumentIntroduction(Microsoft.CodeAnalysis.Document)')
  - [GetFirstClassAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstClassAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstClassAsync(Microsoft.CodeAnalysis.Document)')
  - [GetFirstClassOrDefaultAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstClassOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstClassOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetFirstStructAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstStructAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstStructAsync(Microsoft.CodeAnalysis.Document)')
  - [GetFirstStructOrDefaultAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstStructOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstStructOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetFirstTypeAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstTypeAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstTypeAsync(Microsoft.CodeAnalysis.Document)')
  - [GetFirstTypeOrDefaultAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstTypeOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetFirstTypeOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleClassAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleClassAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleClassAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleClassOrDefaultAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleClassOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleClassOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleStructAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleStructAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleStructAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleStructOrDefaultAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleStructOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleStructOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleTypeAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleTypeAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleTypeAsync(Microsoft.CodeAnalysis.Document)')
  - [GetSingleTypeOrDefaultAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleTypeOrDefaultAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetSingleTypeOrDefaultAsync(Microsoft.CodeAnalysis.Document)')
  - [GetStructCountAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetStructCountAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetStructCountAsync(Microsoft.CodeAnalysis.Document)')
  - [GetStructsAndNestedStructsAsync(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetStructsAndNestedStructsAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetStructsAndNestedStructsAsync(Microsoft.CodeAnalysis.Document)')
  - [GetTypeCountAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetTypeCountAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetTypeCountAsync(Microsoft.CodeAnalysis.Document)')
  - [GetTypesAndNestedTypesAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetTypesAndNestedTypesAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetTypesAndNestedTypesAsync(Microsoft.CodeAnalysis.Document)')
  - [NormalizeDocumentStartAsync(document,CopyrightText)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-NormalizeDocumentStartAsync-Microsoft-CodeAnalysis-Document,System-String- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.NormalizeDocumentStartAsync(Microsoft.CodeAnalysis.Document,System.String)')
  - [ReplaceCommentsByGuids(document)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceCommentsByGuids-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.ReplaceCommentsByGuids(Microsoft.CodeAnalysis.Document)')
  - [ReplaceDocumentIntroductionAsync()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceDocumentIntroductionAsync-Microsoft-CodeAnalysis-Document,System-String- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.ReplaceDocumentIntroductionAsync(Microsoft.CodeAnalysis.Document,System.String)')
  - [ReplaceGuidsByComments(document,commentBlocks)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceGuidsByComments-Microsoft-CodeAnalysis-Document,System-Collections-Generic-List{CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock}- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.ReplaceGuidsByComments(Microsoft.CodeAnalysis.Document,System.Collections.Generic.List{CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock})')
  - [ValidateSingleTypeDeclaration()](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ValidateSingleTypeDeclaration-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.ValidateSingleTypeDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax)')
- [MemberDeclarationExtensions](#T-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions')
  - [GetCodeLines(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetCodeLines-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.GetCodeLines(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [GetNameOrDefault(member,defaultName)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetNameOrDefault-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax,System-String- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.GetNameOrDefault(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax,System.String)')
  - [GetNextSourceCodeSegment(members,startIndex,maxCodeLines)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetNextSourceCodeSegment-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax[],System-Int32,System-Int32- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.GetNextSourceCodeSegment(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax[],System.Int32,System.Int32)')
  - [IsAbstract(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsAbstract-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsAbstract(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsClass(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsClass-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsClass(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsConst(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConst-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsConst(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsConstructor(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConstructor-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsConstructor(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsConversionOperator(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConversionOperator-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsConversionOperator(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsDelegate(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsDelegate-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsDestructor(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsDestructor-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsDestructor(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsEnum(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsEnum-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsEnum(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsEvent(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsEvent-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsEvent(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsField(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsField-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsField(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsIndexer(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsIndexer-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsIndexer(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsInterface(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsInterface-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsInterface(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsInternal(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsInternal-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsInternal(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsMethod(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsMethod-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsMethod(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsNamespace(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsNamespace-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsNamespace(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsOperator(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsOperator-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsOperator(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsOverride(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsOverride-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsOverride(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsPrivate(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsPrivate-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsPrivate(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsProperty(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsProperty-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsProperty(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsProtected(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsProtected-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsProtected(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsPublic(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsPublic-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsPublic(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsReadOnly(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsReadOnly-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsReadOnly(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsSealed(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsSealed-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsSealed(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsStatic(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsStatic-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsStatic(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsStruct(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsStruct-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsStruct(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [IsVirtual(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsVirtual-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.MemberDeclarationExtensions.IsVirtual(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
- [TreeNode\`2](#T-CommunityToolkit-Collections-Generic-TreeNode`2 'CommunityToolkit.Collections.Generic.TreeNode`2')
  - [#ctor(key,value)](#M-CommunityToolkit-Collections-Generic-TreeNode`2-#ctor-`0,`1- 'CommunityToolkit.Collections.Generic.TreeNode`2.#ctor(`0,`1)')
  - [Children](#P-CommunityToolkit-Collections-Generic-TreeNode`2-Children 'CommunityToolkit.Collections.Generic.TreeNode`2.Children')
  - [Key](#P-CommunityToolkit-Collections-Generic-TreeNode`2-Key 'CommunityToolkit.Collections.Generic.TreeNode`2.Key')
  - [Parent](#P-CommunityToolkit-Collections-Generic-TreeNode`2-Parent 'CommunityToolkit.Collections.Generic.TreeNode`2.Parent')
  - [Value](#P-CommunityToolkit-Collections-Generic-TreeNode`2-Value 'CommunityToolkit.Collections.Generic.TreeNode`2.Value')
  - [AddChild(child)](#M-CommunityToolkit-Collections-Generic-TreeNode`2-AddChild-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}- 'CommunityToolkit.Collections.Generic.TreeNode`2.AddChild(CommunityToolkit.Collections.Generic.TreeNode{`0,`1})')
  - [GetDeepestLeaf()](#M-CommunityToolkit-Collections-Generic-TreeNode`2-GetDeepestLeaf 'CommunityToolkit.Collections.Generic.TreeNode`2.GetDeepestLeaf')
  - [TryGetChild(key,child)](#M-CommunityToolkit-Collections-Generic-TreeNode`2-TryGetChild-`0,CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@- 'CommunityToolkit.Collections.Generic.TreeNode`2.TryGetChild(`0,CommunityToolkit.Collections.Generic.TreeNode{`0,`1}@)')
- [Tree\`2](#T-CommunityToolkit-Collections-Generic-Tree`2 'CommunityToolkit.Collections.Generic.Tree`2')
  - [#ctor(rootKey,rootValue)](#M-CommunityToolkit-Collections-Generic-Tree`2-#ctor-`0,`1- 'CommunityToolkit.Collections.Generic.Tree`2.#ctor(`0,`1)')
  - [Root](#P-CommunityToolkit-Collections-Generic-Tree`2-Root 'CommunityToolkit.Collections.Generic.Tree`2.Root')
  - [AddChild(parentKey,childKey,childValue)](#M-CommunityToolkit-Collections-Generic-Tree`2-AddChild-`0,`0,`1- 'CommunityToolkit.Collections.Generic.Tree`2.AddChild(`0,`0,`1)')
  - [GetDeepestLeaf()](#M-CommunityToolkit-Collections-Generic-Tree`2-GetDeepestLeaf 'CommunityToolkit.Collections.Generic.Tree`2.GetDeepestLeaf')
  - [TraverseAll()](#M-CommunityToolkit-Collections-Generic-Tree`2-TraverseAll 'CommunityToolkit.Collections.Generic.Tree`2.TraverseAll')
  - [TraverseDown(key)](#M-CommunityToolkit-Collections-Generic-Tree`2-TraverseDown-`0- 'CommunityToolkit.Collections.Generic.Tree`2.TraverseDown(`0)')
  - [TraverseDown(node)](#M-CommunityToolkit-Collections-Generic-Tree`2-TraverseDown-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}- 'CommunityToolkit.Collections.Generic.Tree`2.TraverseDown(CommunityToolkit.Collections.Generic.TreeNode{`0,`1})')
  - [TraverseUp(key)](#M-CommunityToolkit-Collections-Generic-Tree`2-TraverseUp-`0- 'CommunityToolkit.Collections.Generic.Tree`2.TraverseUp(`0)')
  - [TraverseUp(node)](#M-CommunityToolkit-Collections-Generic-Tree`2-TraverseUp-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}- 'CommunityToolkit.Collections.Generic.Tree`2.TraverseUp(CommunityToolkit.Collections.Generic.TreeNode{`0,`1})')
  - [TryGetNode(key,node)](#M-CommunityToolkit-Collections-Generic-Tree`2-TryGetNode-`0,CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@- 'CommunityToolkit.Collections.Generic.Tree`2.TryGetNode(`0,CommunityToolkit.Collections.Generic.TreeNode{`0,`1}@)')
- [TypeDeclarationExtensions](#T-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions 'CommunityToolkit.Roslyn.CSharp.Extensions.TypeDeclarationExtensions')
  - [FlattenKindsToMembers(memberDict)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-FlattenKindsToMembers-System-Collections-Generic-Dictionary{Microsoft-CodeAnalysis-CSharp-SyntaxKind,System-Collections-Generic-Dictionary{System-String,Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax}}- 'CommunityToolkit.Roslyn.CSharp.Extensions.TypeDeclarationExtensions.FlattenKindsToMembers(System.Collections.Generic.Dictionary{Microsoft.CodeAnalysis.CSharp.SyntaxKind,System.Collections.Generic.Dictionary{System.String,Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax}})')
  - [GetMemberDictionary(typeDeclaration)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-GetMemberDictionary-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.TypeDeclarationExtensions.GetMemberDictionary(Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax)')
  - [GetMemberKey(member)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-GetMemberKey-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.TypeDeclarationExtensions.GetMemberKey(Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax)')
  - [PartitionMembers(typeDeclaration)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-PartitionMembers-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax- 'CommunityToolkit.Roslyn.CSharp.Extensions.TypeDeclarationExtensions.PartitionMembers(Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax)')
- [WorkspaceExtensions](#T-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions')
  - [CreateWorkspaceFromSourceFiles(workspace,sourceCodeFiles,defaultName,defaultProjectName)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-CreateWorkspaceFromSourceFiles-Microsoft-CodeAnalysis-AdhocWorkspace,System-Collections-Generic-IEnumerable{System-String},System-String,System-String- 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions.CreateWorkspaceFromSourceFiles(Microsoft.CodeAnalysis.AdhocWorkspace,System.Collections.Generic.IEnumerable{System.String},System.String,System.String)')
  - [GetFirstDocument(workspace)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstDocument-Microsoft-CodeAnalysis-AdhocWorkspace- 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions.GetFirstDocument(Microsoft.CodeAnalysis.AdhocWorkspace)')
  - [GetFirstDocumentOrDefault(workspace)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstDocumentOrDefault-Microsoft-CodeAnalysis-AdhocWorkspace- 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions.GetFirstDocumentOrDefault(Microsoft.CodeAnalysis.AdhocWorkspace)')
  - [GetFirstProject(workspace)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstProject-Microsoft-CodeAnalysis-AdhocWorkspace- 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions.GetFirstProject(Microsoft.CodeAnalysis.AdhocWorkspace)')
  - [GetFirstProjectOrDefault(workspace)](#M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstProjectOrDefault-Microsoft-CodeAnalysis-AdhocWorkspace- 'CommunityToolkit.Roslyn.CSharp.Extensions.WorkspaceExtensions.GetFirstProjectOrDefault(Microsoft.CodeAnalysis.AdhocWorkspace)')

<a name='T-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo'></a>
## CodeBlockInfo `type`

##### Namespace

CommunityToolkit.Roslyn.Tooling

##### Summary

Represents information about a code block.

<a name='P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Code'></a>
### Code `property`

##### Summary

Gets or sets the code of the code block.

<a name='P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Description'></a>
### Description `property`

##### Summary

Gets or sets the description of the code block.

<a name='P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Filename'></a>
### Filename `property`

##### Summary

Gets or sets the filename associated with the code block.

<a name='P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Language'></a>
### Language `property`

##### Summary

Gets or sets the language of the code block.

<a name='P-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of the code block.

<a name='T-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock'></a>
## CommentBlock `type`

##### Namespace

CommunityToolkit.Roslyn.CSharp.Extensions

##### Summary

Represents a block of comments in the code.

##### Remarks

This class is used to maintain a comment section in trivias in code, and be later able to 
  back-assign it to the (most likely new) respective syntax node. This is a work in process.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [CommentBlock](#T-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock 'CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock') class.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-Comment'></a>
### Comment `property`

##### Summary

Gets or sets the list of syntax trivia representing the comments.

<a name='P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-Guid'></a>
### Guid `property`

##### Summary

Gets or sets the unique identifier for the comment block.

<a name='P-CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock-IndentationLevel'></a>
### IndentationLevel `property`

##### Summary

Gets or sets the indentation level of the comment block.

<a name='T-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions'></a>
## DocumentExtensions `type`

##### Namespace

CommunityToolkit.Roslyn.CSharp.Extensions

##### Summary

Provides extension methods for working with Roslyn documents.

##### Remarks

This class contains methods to retrieve class declarations from a Roslyn document.
  It includes methods to get all classes, nested classes, and specific class declarations.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetAllCommentBlocks-Microsoft-CodeAnalysis-Document-'></a>
### GetAllCommentBlocks(document) `method`

##### Summary

Retrieves all comment blocks from the specified document.

##### Returns

An asynchronous enumerable of lists of comment blocks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to extract comment blocks from. |

##### Remarks

This method traverses the syntax tree of the provided document and collects all
  single-line and multi-line comments into blocks. Each block is a contiguous sequence
  of comments.

The method yields a list of comment blocks, where each block contains the comments
  and their associated trivia.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassCountAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetClassCountAsync(document) `method`

##### Summary

Gets the count of class declarations in the document.

##### Returns

The count of class declarations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method returns the total number of class declarations in the provided document,
  including nested classes.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassesAndNestedClassesAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetClassesAndNestedClassesAsync(document) `method`

##### Summary

Gets all class declarations, including nested classes, in the document.

##### Returns

An enumerable of all class declarations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves all class declarations in the provided document, including
  nested classes. It searches through all descendant nodes to find class declarations.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetClassesAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetClassesAsync(document) `method`

##### Summary

Gets all top-level class declarations in the document.

##### Returns

An enumerable of top-level class declarations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves all top-level class declarations in the provided document.
  It first finds the first class declaration and then retrieves all class declarations
  at the same level as the first one.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetDocumentIntroduction-Microsoft-CodeAnalysis-Document-'></a>
### GetDocumentIntroduction() `method`

##### Summary

Returns the source code as string of the document until the first curly brace of the first type declaration.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the source code of the document up to the first curly brace of the first type
  declaration. It is useful for extracting the initial part of the document, such as the using directives
  and namespace declarations.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstClassAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstClassAsync(document) `method`

##### Summary

Gets the first class declaration in the document.

##### Returns

The first class declaration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves the first class declaration in the provided document. If no
  class declarations are found, it throws an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstClassOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstClassOrDefaultAsync(document) `method`

##### Summary

Gets the first class declaration in the document or null if none exist.

##### Returns

The first class declaration or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves the first class declaration in the provided document. If no
  class declarations are found, it returns null.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstStructAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstStructAsync(document) `method`

##### Summary

Gets the first struct declaration in the document.
 Throws if none exist.

##### Returns

The first struct declaration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to search for the first struct declaration. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if no struct declarations are found. |

##### Remarks

This method retrieves the first struct declaration from the provided document. If no struct declarations
  are found, it throws an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstStructOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstStructOrDefaultAsync(document) `method`

##### Summary

Gets the first struct declaration in the document or null if none exist.

##### Returns

The first struct declaration or null if none exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to search for the first struct declaration. |

##### Remarks

This method retrieves the first struct declaration from the provided document. If no struct declarations
  are found, it returns null.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstTypeAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstTypeAsync() `method`

##### Summary

Gets the first type declaration in the document.
 Throws if none exist.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the first type declaration in the document. If no type declarations exist, it throws
  an InvalidOperationException. It is useful for accessing the first type defined within the document.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetFirstTypeOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetFirstTypeOrDefaultAsync() `method`

##### Summary

Gets the first type declaration in the document or null if none exist.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the first type declaration in the document or null if no type declarations exist. It
  is useful for accessing the first type defined within the document without throwing an exception.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleClassAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleClassAsync(document) `method`

##### Summary

Gets the single top-level class declaration in the document.

##### Returns

The single top-level class declaration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves the single top-level class declaration in the provided document.
  If no class declarations are found or if there is more than one, it throws an
  [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleClassOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleClassOrDefaultAsync(document) `method`

##### Summary

Gets the single top-level class declaration in the document or null if none exist.

##### Returns

The single top-level class declaration or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The Roslyn document to search. |

##### Remarks

This method retrieves the single top-level class declaration in the provided document.
  If no class declarations are found, it returns null. If more than one class declaration
  is found, it throws an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleStructAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleStructAsync(document) `method`

##### Summary

Gets the single top-level struct declaration in the document.
 Throws if none exist or if there is more than one.

##### Returns

The single top-level struct declaration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to search for the single struct declaration. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if no struct declarations are found or if there is more than one. |

##### Remarks

This method retrieves the single top-level struct declaration from the provided document. If no struct
  declarations are found or if there is more than one, it throws an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleStructOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleStructOrDefaultAsync(document) `method`

##### Summary

Gets the single top-level struct declaration in the document or null if none exist.
 Throws if more than one struct declaration is found.

##### Returns

The single top-level struct declaration or null if none exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to search for the single struct declaration. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if more than one struct declaration is found. |

##### Remarks

This method retrieves the single top-level struct declaration from the provided document. If no struct
  declarations are found, it returns null. If more than one struct declaration is found, it throws an
  [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleTypeAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleTypeAsync() `method`

##### Summary

Gets the single top-level type declaration in the document.
 Throws if none exist or if there is more than one.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the single top-level type declaration in the document. If no type declarations exist
  or if there is more than one, it throws an InvalidOperationException. It is useful for accessing the single
  top-level type defined within the document.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetSingleTypeOrDefaultAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetSingleTypeOrDefaultAsync() `method`

##### Summary

Gets the single top-level type declaration in the document or null if none exist.
 Throws if more than one type declaration is found.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the single top-level type declaration in the document or null if no type declarations
  exist. If there is more than one type declaration, it throws an InvalidOperationException. It is useful for
  accessing the single top-level type defined within the document without throwing an exception if none exist.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetStructCountAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetStructCountAsync(document) `method`

##### Summary

Gets the count of struct declarations in the document.

##### Returns

The count of struct declarations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to count struct declarations in. |

##### Remarks

This method counts all struct declarations, including nested ones, in the provided document.
  It uses the [GetStructsAndNestedStructsAsync](#M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetStructsAndNestedStructsAsync-Microsoft-CodeAnalysis-Document- 'CommunityToolkit.Roslyn.CSharp.Extensions.DocumentExtensions.GetStructsAndNestedStructsAsync(Microsoft.CodeAnalysis.Document)') method to retrieve the struct declarations
  and then returns the count.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetStructsAndNestedStructsAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetStructsAndNestedStructsAsync(document) `method`

##### Summary

Gets all struct declarations and nested struct declarations in the document.

##### Returns

An enumerable collection of struct declarations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to search for struct declarations. |

##### Remarks

This method retrieves all struct declarations, including nested ones, from the syntax tree of the
  provided document. It returns an enumerable collection of [StructDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-StructDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetTypeCountAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetTypeCountAsync() `method`

##### Summary

Gets the count of type declarations in the document.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves the count of type declarations in the document. It is useful for determining the
  number of types defined within the document.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-GetTypesAndNestedTypesAsync-Microsoft-CodeAnalysis-Document-'></a>
### GetTypesAndNestedTypesAsync() `method`

##### Summary

Gets all type declarations and nested type declarations in the document.

##### Parameters

This method has no parameters.

##### Remarks

This method retrieves all type declarations and nested type declarations in the document. It is useful for
  analyzing the structure of the document and identifying all types defined within it.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-NormalizeDocumentStartAsync-Microsoft-CodeAnalysis-Document,System-String-'></a>
### NormalizeDocumentStartAsync(document,CopyrightText) `method`

##### Summary

Normalizes the start of the document by adding a copyright comment and sorting using directives.

##### Returns

The updated document.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to normalize. |
| CopyrightText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The copyright text to add as a comment at the start of the document. |

##### Remarks

This method adds a copyright comment at the start of the document if the provided
  copyright text is not empty. It also sorts the using directives in alphabetical
  order and converts the namespace declaration to a file-scoped namespace if applicable.

The method returns the updated document with the normalized start, ensuring a
  consistent structure and style.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceCommentsByGuids-Microsoft-CodeAnalysis-Document-'></a>
### ReplaceCommentsByGuids(document) `method`

##### Summary

Replaces all comments in the document with GUIDs.

##### Returns

A tuple containing the updated document and a list of comment blocks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to process. |

##### Remarks

This method traverses the syntax tree of the provided document and replaces each
  comment with a unique GUID. The original comments are stored in a list of comment
  blocks, each associated with the corresponding GUID.

The method returns the updated document and the list of comment blocks, which can
  be used to restore the original comments if needed.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceDocumentIntroductionAsync-Microsoft-CodeAnalysis-Document,System-String-'></a>
### ReplaceDocumentIntroductionAsync() `method`

##### Summary

Replaces the source code of the document until the first curly brace of the first type declaration with the provided code.

##### Parameters

This method has no parameters.

##### Remarks

This method replaces the initial part of the document, up to the first curly brace of the first type
  declaration, with the provided code. It is useful for modifying the initial part of the document, such as
  the using directives and namespace declarations.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ReplaceGuidsByComments-Microsoft-CodeAnalysis-Document,System-Collections-Generic-List{CommunityToolkit-Roslyn-CSharp-Extensions-CommentBlock}-'></a>
### ReplaceGuidsByComments(document,commentBlocks) `method`

##### Summary

Replaces GUIDs in the document with the original comments.

##### Returns

A tuple containing the updated document and the list of comment blocks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [Microsoft.CodeAnalysis.Document](#T-Microsoft-CodeAnalysis-Document 'Microsoft.CodeAnalysis.Document') | The document to process. |
| commentBlocks | [System.Collections.Generic.List{CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{CommunityToolkit.Roslyn.CSharp.Extensions.CommentBlock}') | The list of comment blocks containing the original comments. |

##### Remarks

This method traverses the syntax tree of the provided document and replaces each
  GUID with the corresponding original comment from the list of comment blocks.

The method returns the updated document and the list of comment blocks, which can
  be used to verify the restoration of the original comments.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-DocumentExtensions-ValidateSingleTypeDeclaration-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax-'></a>
### ValidateSingleTypeDeclaration() `method`

##### Summary

Validates that the type is the only top-level type under its parent.

##### Parameters

This method has no parameters.

##### Remarks

This method validates that the provided type declaration is the only top-level type under its parent. If
  there are multiple top-level types, it throws an InvalidOperationException. It is useful for ensuring that
  the document contains a single top-level type declaration.

<a name='T-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions'></a>
## MemberDeclarationExtensions `type`

##### Namespace

CommunityToolkit.Roslyn.CSharp.Extensions

##### Summary

Provides extension methods for [MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax').

##### Remarks

This class contains various extension methods to work with member declarations in C# syntax trees.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetCodeLines-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### GetCodeLines(member) `method`

##### Summary

Gets the code lines of the member.

##### Returns

An array of code lines.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

This method converts the member to a full string and splits it into lines.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetNameOrDefault-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax,System-String-'></a>
### GetNameOrDefault(member,defaultName) `method`

##### Summary

Gets the name of the member or a default name if the member does not have a name.

##### Returns

The name of the member or the default name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |
| defaultName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The default name to return if the member does not have a name. |

##### Remarks

This method uses pattern matching to determine the type of the member and retrieve its name.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-GetNextSourceCodeSegment-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax[],System-Int32,System-Int32-'></a>
### GetNextSourceCodeSegment(members,startIndex,maxCodeLines) `method`

##### Summary

Gets the next segment of source code members starting from the specified index.

##### Returns

An array of member declarations in the next segment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| members | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax[]](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax[] 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax[]') | The array of member declarations. |
| startIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The starting index. |
| maxCodeLines | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum number of code lines for the segment. |

##### Remarks

This method gathers members until the total number of code lines reaches the specified maximum.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsAbstract-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsAbstract(member) `method`

##### Summary

Determines whether the member is abstract.

##### Returns

`true` if the member is abstract; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the abstract modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsClass-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsClass(member) `method`

##### Summary

Determines whether the member is a class.

##### Returns

`true` if the member is a class; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a class declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConst-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsConst(member) `method`

##### Summary

Determines whether the member is a constant.

##### Returns

`true` if the member is a constant; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the const modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConstructor-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsConstructor(member) `method`

##### Summary

Determines whether the member is a constructor.

##### Returns

`true` if the member is a constructor; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a constructor declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsConversionOperator-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsConversionOperator(member) `method`

##### Summary

Determines whether the member is a conversion operator.

##### Returns

`true` if the member is a conversion operator; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a conversion operator declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsDelegate-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsDelegate(member) `method`

##### Summary

Determines whether the member is a delegate.

##### Returns

`true` if the member is a delegate; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a delegate declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsDestructor-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsDestructor(member) `method`

##### Summary

Determines whether the member is a destructor.

##### Returns

`true` if the member is a destructor; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a destructor declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsEnum-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsEnum(member) `method`

##### Summary

Determines whether the member is an enum.

##### Returns

`true` if the member is an enum; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is an enum declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsEvent-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsEvent(member) `method`

##### Summary

Determines whether the member is an event.

##### Returns

`true` if the member is an event; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is an event declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsField-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsField(member) `method`

##### Summary

Determines whether the member is a field.

##### Returns

`true` if the member is a field; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a field declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsIndexer-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsIndexer(member) `method`

##### Summary

Determines whether the member is an indexer.

##### Returns

`true` if the member is an indexer; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is an indexer declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsInterface-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsInterface(member) `method`

##### Summary

Determines whether the member is an interface.

##### Returns

`true` if the member is an interface; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is an interface declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsInternal-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsInternal(member) `method`

##### Summary

Determines whether the member is internal.

##### Returns

`true` if the member is internal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the internal modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsMethod-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsMethod(member) `method`

##### Summary

Determines whether the member is a method.

##### Returns

`true` if the member is a method; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a method declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsNamespace-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsNamespace(member) `method`

##### Summary

Determines whether the member is a namespace.

##### Returns

`true` if the member is a namespace; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a namespace declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsOperator-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsOperator(member) `method`

##### Summary

Determines whether the member is an operator.

##### Returns

`true` if the member is an operator; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is an operator declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsOverride-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsOverride(member) `method`

##### Summary

Determines whether the member is an override.

##### Returns

`true` if the member is an override; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the override modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsPrivate-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsPrivate(member) `method`

##### Summary

Determines whether the member is private.

##### Returns

`true` if the member is private; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the private modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsProperty-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsProperty(member) `method`

##### Summary

Determines whether the member is a property.

##### Returns

`true` if the member is a property; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a property declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsProtected-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsProtected(member) `method`

##### Summary

Determines whether the member is protected.

##### Returns

`true` if the member is protected; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the protected modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsPublic-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsPublic(member) `method`

##### Summary

Determines whether the member is public.

##### Returns

`true` if the member is public; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the public modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsReadOnly-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsReadOnly(member) `method`

##### Summary

Determines whether the member is read-only.

##### Returns

`true` if the member is read-only; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the read-only modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsSealed-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsSealed(member) `method`

##### Summary

Determines whether the member is sealed.

##### Returns

`true` if the member is sealed; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the sealed modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsStatic-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsStatic(member) `method`

##### Summary

Determines whether the member is static.

##### Returns

`true` if the member is static; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the static modifier.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsStruct-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsStruct(member) `method`

##### Summary

Determines whether the member is a struct.

##### Returns

`true` if the member is a struct; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member is a struct declaration.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-MemberDeclarationExtensions-IsVirtual-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### IsVirtual(member) `method`

##### Summary

Determines whether the member is virtual.

##### Returns

`true` if the member is virtual; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration syntax. |

##### Remarks

Checks if the member has the virtual modifier.

<a name='T-CommunityToolkit-Collections-Generic-TreeNode`2'></a>
## TreeNode\`2 `type`

##### Namespace

CommunityToolkit.Collections.Generic

##### Summary

Represents a generic tree node with a key/value pair and fast child lookup.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey | The type of the node key. |
| TValue | The type of the node value. |

<a name='M-CommunityToolkit-Collections-Generic-TreeNode`2-#ctor-`0,`1-'></a>
### #ctor(key,value) `constructor`

##### Summary

Initializes a new instance of the [TreeNode\`2](#T-CommunityToolkit-Collections-Generic-TreeNode`2 'CommunityToolkit.Collections.Generic.TreeNode`2') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`0](#T-`0 '`0') | The key of the node. |
| value | [\`1](#T-`1 '`1') | The value of the node. |

<a name='P-CommunityToolkit-Collections-Generic-TreeNode`2-Children'></a>
### Children `property`

##### Summary

Gets the dictionary of child nodes keyed by their keys.

<a name='P-CommunityToolkit-Collections-Generic-TreeNode`2-Key'></a>
### Key `property`

##### Summary

Gets the key for this node.

<a name='P-CommunityToolkit-Collections-Generic-TreeNode`2-Parent'></a>
### Parent `property`

##### Summary

Gets or sets the parent node.

<a name='P-CommunityToolkit-Collections-Generic-TreeNode`2-Value'></a>
### Value `property`

##### Summary

Gets or sets the value for this node.

<a name='M-CommunityToolkit-Collections-Generic-TreeNode`2-AddChild-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}-'></a>
### AddChild(child) `method`

##### Summary

Adds a child node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| child | [CommunityToolkit.Collections.Generic.TreeNode{\`0,\`1}](#T-CommunityToolkit-Collections-Generic-TreeNode{`0,`1} 'CommunityToolkit.Collections.Generic.TreeNode{`0,`1}') | The child node to add. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when `child` is null. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown when a child with the same key already exists. |

<a name='M-CommunityToolkit-Collections-Generic-TreeNode`2-GetDeepestLeaf'></a>
### GetDeepestLeaf() `method`

##### Summary

Gets the deepest (farthest) leaf node from this node.

##### Returns

The deepest leaf node.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-Collections-Generic-TreeNode`2-TryGetChild-`0,CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@-'></a>
### TryGetChild(key,child) `method`

##### Summary

Tries to get a child node by key.

##### Returns

`true` if the child exists; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`0](#T-`0 '`0') | The key of the child node. |
| child | [CommunityToolkit.Collections.Generic.TreeNode{\`0,\`1}@](#T-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@ 'CommunityToolkit.Collections.Generic.TreeNode{`0,`1}@') | When this method returns, contains the child node if found. |

<a name='T-CommunityToolkit-Collections-Generic-Tree`2'></a>
## Tree\`2 `type`

##### Namespace

CommunityToolkit.Collections.Generic

##### Summary

Represents a generic tree data structure.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey | The type of the key in each node. |
| TValue | The type of the value in each node. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-#ctor-`0,`1-'></a>
### #ctor(rootKey,rootValue) `constructor`

##### Summary

Initializes a new instance of the [Tree\`2](#T-CommunityToolkit-Collections-Generic-Tree`2 'CommunityToolkit.Collections.Generic.Tree`2') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rootKey | [\`0](#T-`0 '`0') | The key for the root node. |
| rootValue | [\`1](#T-`1 '`1') | The value for the root node. |

<a name='P-CommunityToolkit-Collections-Generic-Tree`2-Root'></a>
### Root `property`

##### Summary

Gets the root node of the tree.

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-AddChild-`0,`0,`1-'></a>
### AddChild(parentKey,childKey,childValue) `method`

##### Summary

Adds a child node under the node identified by `parentKey`.

##### Returns

The newly created child node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parentKey | [\`0](#T-`0 '`0') | The key of the parent node. |
| childKey | [\`0](#T-`0 '`0') | The key for the new child node. |
| childValue | [\`1](#T-`1 '`1') | The value for the new child node. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | Thrown if no node with the specified `parentKey` is found. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-GetDeepestLeaf'></a>
### GetDeepestLeaf() `method`

##### Summary

Gets the deepest leaf node in the tree.

##### Returns

The deepest leaf node.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TraverseAll'></a>
### TraverseAll() `method`

##### Summary

Recursively traverses all nodes in the tree.

##### Returns

An enumerable collection of all nodes in the tree.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TraverseDown-`0-'></a>
### TraverseDown(key) `method`

##### Summary

Traverses downward starting at the node identified by `key`.

##### Returns

An enumerable collection of nodes from the specified node down through its descendants.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`0](#T-`0 '`0') | The key of the starting node. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | Thrown if no node with the specified `key` is found. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TraverseDown-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}-'></a>
### TraverseDown(node) `method`

##### Summary

Traverses downward starting from the specified `node`.

##### Returns

An enumerable collection of nodes from the specified node down through its descendants.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [CommunityToolkit.Collections.Generic.TreeNode{\`0,\`1}](#T-CommunityToolkit-Collections-Generic-TreeNode{`0,`1} 'CommunityToolkit.Collections.Generic.TreeNode{`0,`1}') | The starting node. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TraverseUp-`0-'></a>
### TraverseUp(key) `method`

##### Summary

Traverses upward starting at the node identified by `key`.

##### Returns

An enumerable collection of nodes from the specified node up to the root.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`0](#T-`0 '`0') | The key of the starting node. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | Thrown if no node with the specified `key` is found. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TraverseUp-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}-'></a>
### TraverseUp(node) `method`

##### Summary

Traverses upward starting from the specified `node`.

##### Returns

An enumerable collection of nodes from the specified node up to the root.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [CommunityToolkit.Collections.Generic.TreeNode{\`0,\`1}](#T-CommunityToolkit-Collections-Generic-TreeNode{`0,`1} 'CommunityToolkit.Collections.Generic.TreeNode{`0,`1}') | The starting node. |

<a name='M-CommunityToolkit-Collections-Generic-Tree`2-TryGetNode-`0,CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@-'></a>
### TryGetNode(key,node) `method`

##### Summary

Attempts to retrieve a node with the specified key.

##### Returns

`true` if the node was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [\`0](#T-`0 '`0') | The key to locate. |
| node | [CommunityToolkit.Collections.Generic.TreeNode{\`0,\`1}@](#T-CommunityToolkit-Collections-Generic-TreeNode{`0,`1}@ 'CommunityToolkit.Collections.Generic.TreeNode{`0,`1}@') | When this method returns, contains the node associated with the specified key, if found. |

<a name='T-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions'></a>
## TypeDeclarationExtensions `type`

##### Namespace

CommunityToolkit.Roslyn.CSharp.Extensions

##### Summary

Provides extension methods for [TypeDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax').

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-FlattenKindsToMembers-System-Collections-Generic-Dictionary{Microsoft-CodeAnalysis-CSharp-SyntaxKind,System-Collections-Generic-Dictionary{System-String,Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax}}-'></a>
### FlattenKindsToMembers(memberDict) `method`

##### Summary

Flattens a dictionary of grouped type members into a single enumerable.

##### Returns

An enumerable of all [MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberDict | [System.Collections.Generic.Dictionary{Microsoft.CodeAnalysis.CSharp.SyntaxKind,System.Collections.Generic.Dictionary{System.String,Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{Microsoft.CodeAnalysis.CSharp.SyntaxKind,System.Collections.Generic.Dictionary{System.String,Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax}}') | The dictionary grouping members by [SyntaxKind](#T-Microsoft-CodeAnalysis-CSharp-SyntaxKind 'Microsoft.CodeAnalysis.CSharp.SyntaxKind'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `memberDict` is null. |

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-GetMemberDictionary-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax-'></a>
### GetMemberDictionary(typeDeclaration) `method`

##### Summary

Gets all members of a type grouped by their [SyntaxKind](#T-Microsoft-CodeAnalysis-CSharp-SyntaxKind 'Microsoft.CodeAnalysis.CSharp.SyntaxKind').
 Each inner dictionary is keyed by a member “name” (or a fallback key)
to ensure uniqueness.

##### Returns

A dictionary mapping [SyntaxKind](#T-Microsoft-CodeAnalysis-CSharp-SyntaxKind 'Microsoft.CodeAnalysis.CSharp.SyntaxKind') to a dictionary that maps a string key
 to the [MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| typeDeclaration | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax') | The class or struct declaration. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `typeDeclaration` is null. |

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-GetMemberKey-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax-'></a>
### GetMemberKey(member) `method`

##### Summary

Attempts to retrieve a “name” for the member.
 For known types (methods, properties, etc.) the identifier is used.
 Otherwise, a fallback key is created.

##### Returns

A string key representing the member.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-MemberDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax') | The member declaration. |

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-TypeDeclarationExtensions-PartitionMembers-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax-'></a>
### PartitionMembers(typeDeclaration) `method`

##### Summary

Splits a type declaration into two parts:

##### Returns

A tuple where the first element is the new type declaration with only non-code members,
and the second element is an array of members with executable code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| typeDeclaration | [Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax](#T-Microsoft-CodeAnalysis-CSharp-Syntax-TypeDeclarationSyntax 'Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax') | The original type declaration. |

<a name='T-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions'></a>
## WorkspaceExtensions `type`

##### Namespace

CommunityToolkit.Roslyn.CSharp.Extensions

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-CreateWorkspaceFromSourceFiles-Microsoft-CodeAnalysis-AdhocWorkspace,System-Collections-Generic-IEnumerable{System-String},System-String,System-String-'></a>
### CreateWorkspaceFromSourceFiles(workspace,sourceCodeFiles,defaultName,defaultProjectName) `method`

##### Summary

Creates an AdhocWorkspace from a collection of source files.

##### Returns

The created AdhocWorkspace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workspace | [Microsoft.CodeAnalysis.AdhocWorkspace](#T-Microsoft-CodeAnalysis-AdhocWorkspace 'Microsoft.CodeAnalysis.AdhocWorkspace') | The workspace to add the project to. |
| sourceCodeFiles | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | The source code files to add to the project. |
| defaultName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The default name for the solution. |
| defaultProjectName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The default name for the project. |

##### Remarks

This method initializes an AdhocWorkspace if one is not provided, and creates a new project
  within that workspace. It then adds documents to the project from the provided source code files.

The method also attempts to apply changes to the workspace and returns the modified workspace.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstDocument-Microsoft-CodeAnalysis-AdhocWorkspace-'></a>
### GetFirstDocument(workspace) `method`

##### Summary

Gets the first document in the first project of the workspace.

##### Returns

The first document in the first project of the workspace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workspace | [Microsoft.CodeAnalysis.AdhocWorkspace](#T-Microsoft-CodeAnalysis-AdhocWorkspace 'Microsoft.CodeAnalysis.AdhocWorkspace') | The workspace to search for documents. |

##### Remarks

This method retrieves the first document from the first project in the current solution of the
  provided workspace. If no documents are found, it throws an InvalidOperationException.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstDocumentOrDefault-Microsoft-CodeAnalysis-AdhocWorkspace-'></a>
### GetFirstDocumentOrDefault(workspace) `method`

##### Summary

Gets the first document in the first project of the workspace or returns null if no documents exist.

##### Returns

The first document in the first project of the workspace or null if no documents exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workspace | [Microsoft.CodeAnalysis.AdhocWorkspace](#T-Microsoft-CodeAnalysis-AdhocWorkspace 'Microsoft.CodeAnalysis.AdhocWorkspace') | The workspace to search for documents. |

##### Remarks

This method retrieves the first document from the first project in the current solution of the
  provided workspace. If no documents are found, it returns null.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstProject-Microsoft-CodeAnalysis-AdhocWorkspace-'></a>
### GetFirstProject(workspace) `method`

##### Summary

Gets the first project in the workspace.

##### Returns

The first project in the workspace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workspace | [Microsoft.CodeAnalysis.AdhocWorkspace](#T-Microsoft-CodeAnalysis-AdhocWorkspace 'Microsoft.CodeAnalysis.AdhocWorkspace') | The workspace to search for projects. |

##### Remarks

This method retrieves the first project from the current solution in the provided workspace.
  If no projects are found, it throws an InvalidOperationException.

<a name='M-CommunityToolkit-Roslyn-CSharp-Extensions-WorkspaceExtensions-GetFirstProjectOrDefault-Microsoft-CodeAnalysis-AdhocWorkspace-'></a>
### GetFirstProjectOrDefault(workspace) `method`

##### Summary

Gets the first project in the workspace or returns null if no projects exist.

##### Returns

The first project in the workspace or null if no projects exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workspace | [Microsoft.CodeAnalysis.AdhocWorkspace](#T-Microsoft-CodeAnalysis-AdhocWorkspace 'Microsoft.CodeAnalysis.AdhocWorkspace') | The workspace to search for projects. |

##### Remarks

This method retrieves the first project from the current solution in the provided workspace.
  If no projects are found, it returns null.
