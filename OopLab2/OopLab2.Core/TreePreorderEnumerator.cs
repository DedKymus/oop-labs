using System;
using System.Collections;
using System.Collections.Generic;

namespace OopLab2.Core;

public class TreePreorderEnumerator<T> : IEnumerator<T> where T : class
{
    private readonly BinaryTreeNode<T>? _root;
    private Stack<BinaryTreeNode<T>> _stack;
    private T? _current;

    public TreePreorderEnumerator(BinaryTreeNode<T>? root)
    {
        _root = root;
        _stack = new Stack<BinaryTreeNode<T>>();
        Reset();
    }

    public T Current
    {
        get
        {
            if (_current == null)
            {
                throw new InvalidOperationException();
            }
            return _current;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_stack.Count == 0)
        {
            _current = null;
            return false;
        }

        BinaryTreeNode<T> node = _stack.Pop();
        _current = node.Data;

        if (node.Right != null)
        {
            _stack.Push(node.Right);
        }

        if (node.Left != null)
        {
            _stack.Push(node.Left);
        }

        return true;
    }

    public void Reset()
    {
        _stack = new Stack<BinaryTreeNode<T>>();
        _current = null;
        if (_root != null)
        {
            _stack.Push(_root);
        }
    }

    public void Dispose()
    {
        _stack.Clear();
        _current = null;
    }
}
