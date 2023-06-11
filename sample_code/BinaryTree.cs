using System;
using System.Collections;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> Left { get; set; }
  public Node<T> Right { get; set; }

  public Node(T data)
  {
    Data = data;
  }
}

public class BinaryTree<T>
{
  public Node<T> Root { get; set; }

  public BinaryTree(T data)
  {
    Root = new Node<T>(data);
  }

  public Node<T> AddLeft(Node<T> parent, T data)
  {
    Node<T> newNode = new Node<T>(data);
    parent.Left = newNode;
    return newNode;
  }

  public Node<T> AddRight(Node<T> parent, T data)
  {
    Node<T> newNode = new Node<T>(data);
    parent.Right = newNode;
    return newNode;
  }

  public void RemoveLeft(Node<T> parent)
  {
    parent.Left = null;
  }

  public void RemoveRight(Node<T> parent)
  {
    parent.Right = null;
  }

  public void InOrderTraversal()
  {
    Stack<Node<T>> stack = new Stack<Node<T>>();
    HashSet<Node<T>> visited = new HashSet<Node<T>>();
    stack.Push(Root);

    while (stack.Count > 0)
    {
      Node<T> current = stack.Peek();
      Node<T> left = current.Left;

      while (left != null && !visited.Contains(left))
      {
        stack.Push(left);
        left = left.Left;
      }

      Node<T> visit = stack.Pop();
      Console.Write($"{visit.Data} ");
      visited.Add(visit);

      if (visit.Right != null)
      {
        stack.Push(visit.Right);
      }
    }
  }

  public void PreOrderTraversal()
  {
    Stack<Node<T>> stack = new Stack<Node<T>>();
    stack.Push(Root);

    while (stack.Count > 0)
    {
      Node<T> current = stack.Pop();
      Node<T> left = current.Left;
      Node<T> right = current.Right;

      Console.Write($"{current.Data} ");

      if (right != null)
      {
        stack.Push(right);
      }
      if (left != null)
      {
        stack.Push(left);
      }
    }
  }

  public void PostOrderTraversal()
  {
    Stack<Node<T>> stack = new Stack<Node<T>>();
    string result = "";
    stack.Push(Root);

    while (stack.Count > 0)
    {
      Node<T> current = stack.Pop();
      Node<T> left = current.Left;
      Node<T> right = current.Right;

      result = $"{current.Data} " + result;

      if (left != null)
      {
        stack.Push(left);
      }
      if (right != null)
      {
        stack.Push(right);
      }
    }
    Console.Write(result);
  }

  public void LevelOrderTraversal()
  {
    Queue<Node<T>> queue = new Queue<Node<T>>();
    queue.Enqueue(Root);

    while (queue.Count > 0)
    {
      Node<T> current = queue.Dequeue();
      Node<T> left = current.Left;
      Node<T> right = current.Right;

      Console.Write($"{current.Data} ");

      if (left != null)
      {
        queue.Enqueue(left);
      }
      if (right != null)
      {
        queue.Enqueue(right);
      }
    }
  }
}