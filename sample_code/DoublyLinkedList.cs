using System;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  public Node(T data)
  {
    this.Data = data;
  }
}

public class DoubleLinkedList<T>
{
  public Node<T> Head { get; set; }
  public Node<T> Tail { get; set; }
  public int Length = 0;

  private bool IsInvalidIndex(int index)
  {
    if (0 > index || GetLength() - 1 < index)
    {
      return false;
    }
    else
    {
      return true;
    }
  }

  public bool IsEmpty()
  {
    if (Head == null || Tail == null || Length <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public void Add(T data)
  {
    Node<T> newNode = new Node<T>(data);

    if (IsEmpty())
    {
      Head = newNode;
      Tail = newNode;
      Length = 1;
    }
    else
    {
      if (Length == 1)
      {
        Tail = newNode;
        Head.NextNode = Tail;
        Tail.PrevNode = Head;
      }
      else
      {
        Tail.NextNode = newNode;
        newNode.PrevNode = Tail;
        Tail = newNode;
      }
      Length++;
    }
  }

  public bool AddBefore(int index, T data)
  {
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      if (targetNode == Head)
      {
        newNode.NextNode = Head;
        Head.PrevNode = newNode;
        Head = newNode;
      }
      else
      {
        targetNode.PrevNode.NextNode = newNode;
        newNode.NextNode = targetNode;
        newNode.PrevNode = targetNode.PrevNode;
      }
    }
    Length++;
    return true;
  }

  public bool AddAfter(int index, T data)
  {
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      if (targetNode == Tail)
      {
        newNode.PrevNode = Tail;
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      else
      {
        newNode.PrevNode = targetNode;
        newNode.NextNode = targetNode.NextNode;
        targetNode.NextNode = newNode;
      }
      Length++;
      return true;
    }
  }

  public bool Remove(int index)
  {
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      Node<T> targetNode = Head;

      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      if (Length == 1)
      {
        Head = null;
        Tail = null;
      }
      else if (targetNode == Head)
      {
        Head = Head.NextNode;
        Head.PrevNode = null;
        targetNode = null;
      }
      else if (targetNode == Tail)
      {
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        targetNode = null;
      }
      else
      {
        targetNode.PrevNode.NextNode = targetNode.NextNode;
        targetNode.NextNode.PrevNode = targetNode.PrevNode;
        targetNode = null;
      }
      Length--;
      return true;
    }
  }

  public Node<T> Peek()
  {
    return Head;
  }

  public int GetLength()
  {
    return Length;
  }

  public Node<T> GetNode(int index)
  {
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return null;
    }
    else
    {
      Node<T> targetNode = Head;

      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      return targetNode;
    }
  }

}