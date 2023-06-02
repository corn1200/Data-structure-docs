using System;
using System.Collections;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  public Node(T data)
  {
    Data = data;
  }
}

public class Queue<T>
{
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  public Queue()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  public Queue(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      Enqueue(item);
    }
  }

  public IEnumerator GetEnumerator()
  {
    Node<T> currNode = Head;
    while (currNode != null)
    {
      yield return currNode.Data;
      currNode = currNode.NextNode;
    }
  }

  public void Enqueue(T data)
  {
    Node<T> newNode = new Node<T>(data);

    if (IsEmpty())
    {
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      Tail.NextNode = newNode;
      newNode.PrevNode = Tail;
      Tail = newNode;
    }

    Count++;
  }

  public T Dequeue()
  {
    if (Count > 0)
    {
      T data = Head.Data;
      if (Count == 1)
      {
        Clear();
      }
      else
      {
        Head = Head.NextNode;
        Head.PrevNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  public T Peek()
  {
    if (IsEmpty())
    {
      return default(T);
    }
    else
    {
      return Head.Data;
    }
  }

  public void Clear()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  public T[] ToArray()
  {
    T[] newArray = new T[Count];

    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  public void CopyTo(T[] array, int arrayIndex)
  {
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }

  public bool IsEmpty()
  {
    if (Head == null || Tail == null || Count <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}