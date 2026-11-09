using System;
using System.Collections;
using System.Collections.Generic;

namespace OopLab2.Core;

public class BinaryTree<T> : IEnumerable<T> where T : class
{
    public BinaryTreeNode<T>? Root { get; private set; }
    private readonly IComparer<T> _comparer;

    public int Count { get; private set; }

    public BinaryTree(IComparer<T>? comparer = null)
    {
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(item);
            Count++;
            return;
        }

        InsertRecursive(Root, item);
    }

    private void InsertRecursive(BinaryTreeNode<T> current, T item)
    {
        int comparison = _comparer.Compare(item, current.Data);

        if (comparison < 0)
        {
            if (current.Left == null)
            {
                current.Left = new BinaryTreeNode<T>(item);
                Count++;
            }
            else
            {
                InsertRecursive(current.Left, item);
            }
        }
        else
        {
            if (current.Right == null)
            {
                current.Right = new BinaryTreeNode<T>(item);
                Count++;
            }
            else
            {
                InsertRecursive(current.Right, item);
            }
        }
    }

    public bool Contains(T item)
    {
        if (item == null || Root == null) return false;

        BinaryTreeNode<T>? current = Root;
        while (current != null)
        {
            int comparison = _comparer.Compare(item, current.Data);
            if (comparison == 0) return true;
            current = comparison < 0 ? current.Left : current.Right;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new TreePreorderEnumerator<T>(Root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
