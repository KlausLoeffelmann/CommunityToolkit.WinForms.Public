namespace CommunityToolkit.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents a generic tree data structure.
/// </summary>
/// <typeparam name="TKey">The type of the key in each node.</typeparam>
/// <typeparam name="TValue">The type of the value in each node.</typeparam>
public class Tree<TKey, TValue> where TKey : notnull
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tree{TKey, TValue}"/> class.
    /// </summary>
    /// <param name="rootKey">The key for the root node.</param>
    /// <param name="rootValue">The value for the root node.</param>
    public Tree(TKey rootKey, TValue rootValue)
    {
        Root = new TreeNode<TKey, TValue>(rootKey, rootValue);
    }

    /// <summary>
    /// Gets the root node of the tree.
    /// </summary>
    public TreeNode<TKey, TValue> Root { get; }

    /// <summary>
    /// Adds a child node under the node identified by <paramref name="parentKey"/>.
    /// </summary>
    /// <param name="parentKey">The key of the parent node.</param>
    /// <param name="childKey">The key for the new child node.</param>
    /// <param name="childValue">The value for the new child node.</param>
    /// <returns>The newly created child node.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no node with the specified <paramref name="parentKey"/> is found.
    /// </exception>
    public TreeNode<TKey, TValue> AddChild(TKey parentKey, TKey childKey, TValue childValue)
    {
        if (!TryGetNode(parentKey, out var parent))
        {
            throw new KeyNotFoundException(
                $"Node with key '{parentKey}' not found.");
        }

        var child = new TreeNode<TKey, TValue>(childKey, childValue);
        parent.AddChild(child);
        return child;
    }

    /// <summary>
    /// Attempts to retrieve a node with the specified key.
    /// </summary>
    /// <param name="key">The key to locate.</param>
    /// <param name="node">
    /// When this method returns, contains the node associated with the specified key, if found.
    /// </param>
    /// <returns><see langword="true"/> if the node was found; otherwise, <see langword="false"/>.</returns>
    public bool TryGetNode(TKey key, [NotNullWhen(true)] out TreeNode<TKey, TValue>? node)
        => Root.TryGetChild(key, out node);

    /// <summary>
    /// Gets the deepest leaf node in the tree.
    /// </summary>
    /// <returns>The deepest leaf node.</returns>
    public TreeNode<TKey, TValue> GetDeepestLeaf() => Root.GetDeepestLeaf();

    /// <summary>
    /// Traverses upward starting at the node identified by <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key of the starting node.</param>
    /// <returns>
    /// An enumerable collection of nodes from the specified node up to the root.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no node with the specified <paramref name="key"/> is found.
    /// </exception>
    public IEnumerable<TreeNode<TKey, TValue>> TraverseUp(TKey key)
    {
        if (!TryGetNode(key, out var node))
        {
            throw new KeyNotFoundException(
                $"Node with key '{key}' not found.");
        }

        return TraverseUp(node);
    }

    /// <summary>
    /// Traverses upward starting from the specified <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The starting node.</param>
    /// <returns>
    /// An enumerable collection of nodes from the specified node up to the root.
    /// </returns>
    public IEnumerable<TreeNode<TKey, TValue>> TraverseUp(TreeNode<TKey, TValue> node)
        => node.TraverseUp();

    /// <summary>
    /// Traverses downward starting at the node identified by <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key of the starting node.</param>
    /// <returns>
    /// An enumerable collection of nodes from the specified node down through its descendants.
    /// </returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown if no node with the specified <paramref name="key"/> is found.
    /// </exception>
    public IEnumerable<TreeNode<TKey, TValue>> TraverseDown(TKey key)
    {
        if (!TryGetNode(key, out var node))
        {
            throw new KeyNotFoundException(
                $"Node with key '{key}' not found.");
        }

        return TraverseDown(node);
    }

    /// <summary>
    /// Traverses downward starting from the specified <paramref name="node"/>.
    /// </summary>
    /// <param name="node">The starting node.</param>
    /// <returns>
    /// An enumerable collection of nodes from the specified node down through its descendants.
    /// </returns>
    public IEnumerable<TreeNode<TKey, TValue>> TraverseDown(TreeNode<TKey, TValue> node)
        => node.TraverseDown();

    /// <summary>
    /// Recursively traverses all nodes in the tree.
    /// </summary>
    /// <returns>An enumerable collection of all nodes in the tree.</returns>
    public IEnumerable<TreeNode<TKey, TValue>> TraverseAll() => TraverseAll(Root);

    // Recursively yields the node and all its descendants.
    private static IEnumerable<TreeNode<TKey, TValue>> TraverseAll(TreeNode<TKey, TValue> node)
    {
        yield return node;
        foreach (var child in node.Children.Values)
        {
            foreach (var descendant in TraverseAll(child))
            {
                yield return descendant;
            }
        }
    }
}
