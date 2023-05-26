using System;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }

  public Node(T data)
  {
    this.Data = data;
  }
}

public class Stack<T>
{
  private Node<T> _head;
  public Node<T> Head { get { return _head; } set { _head = value; } }
  public int Count { get; set; } = 0;

  public void Push(T data)
  {
    Node<T> newNode = new Node<T>(data);
    if (Count > 0)
    {
      newNode.NextNode = Head;
    }
    Head = newNode;
    Count++;
  }

  public Node<T> Pop()
  {
    if (Count > 0)
    {
      Node<T> headNode = Head;
      Head = headNode.NextNode;
      Count--;
      return headNode;
    }
    else
    {
      return null;
    }
  }

  public Node<T> Peek()
  {
    return Head;
  }
}