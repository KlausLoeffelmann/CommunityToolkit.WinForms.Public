namespace CommunityToolkit.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Represents a generic tree node with a key/value pair and fast child lookup.
/// </summary>
/// <typeparam name="TKey">The type of the node key.</typeparam>
/// <typeparam name="TValue">The type of the node value.</typeparam>
public class TreeNode<TKey, TValue> where TKey : notnull
{
    /// <summary>
    /// Gets the key for this node.
    /// </summary>
    public TKey Key { get; }

    /// <summary>
    /// Gets or sets the value for this node.
    /// </summary>
    public TValue Value { get; set; }

    /// <summary>
    /// Gets the dictionary of child nodes keyed by their keys.
    /// </summary>
    public IDictionary<TKey, TreeNode<TKey, TValue>> Children { get; }

    /// <summary>
    /// Gets or sets the parent node.
    /// </summary>
    public TreeNode<TKey, TValue>? Parent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeNode{TKey, TValue}"/> class.
    /// </summary>
    /// <param name="key">The key of the node.</param>
    /// <param name="value">The value of the node.</param>
    public TreeNode(TKey key, TValue value) 
    {
        Key = key;
        Value = value;
        Children = new Dictionary<TKey, TreeNode<TKey, TValue>>();
    }

    /// <summary>
    /// Adds a child node.
    /// </summary>
    /// <param name="child">The child node to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="child"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when a child with the same key already exists.
    /// </exception>
    public void AddChild(TreeNode<TKey, TValue> child)
    {
        ArgumentNullException.ThrowIfNull(child);

        if (Children.ContainsKey(child.Key))
        {
            throw new ArgumentException(
                $"A child with the key '{child.Key}' already exists.", nameof(child));
        }

        child.Parent = this;
        Children.Add(child.Key, child);
    }

    /// <summary>
    /// Tries to get a child node by key.
    /// </summary>
    /// <param name="key">The key of the child node.</param>
    /// <param name="child">When this method returns, contains the child node if found.</param>
    /// <returns><see langword="true"/> if the child exists; otherwise, <see langword="false"/>.</returns>
    public bool TryGetChild(TKey key, [NotNullWhen(true)] out TreeNode<TKey, TValue>? child)
        => Children.TryGetValue(key, out child);

    /// <summary>
    /// Gets the deepest (farthest) leaf node from this node.
    /// </summary>
    /// <returns>The deepest leaf node.</returns>
    public TreeNode<TKey, TValue> GetDeepestLeaf() => GetDeepestLeafInternal().leaf;

    // Returns a tuple with the deepest leaf from this node and the corresponding depth.
    private (TreeNode<TKey, TValue> leaf, int depth) GetDeepestLeafInternal()
    {
        if (Children.Count == 0)
        {
            return (this, 0);
        }

        var deepest = (leaf: this, depth: 0);
        foreach (var child in Children.Values)
        {
            var childResult = child.GetDeepestLeafInternal();
            if (childResult.depth > deepest.depth)
            {
                deepest = childResult;
            }
        }
        // Increase depth to account for the current node.
        return (deepest.leaf, deepest.depth + 1);
    }

    public IEnumerable<TreeNode<TKey, TValue>> TraverseUp()
    {
        var current = this;
        while (current != null)
        {
            yield return current;
            current = current.Parent;
        }
    }

    public IEnumerable<TreeNode<TKey, TValue>> TraverseDown()
    {
        yield return this;
        foreach (var child in Children.Values)
        {
            foreach (var grandChild in child.TraverseDown())
            {
                yield return grandChild;
            }
        }
    }
}
