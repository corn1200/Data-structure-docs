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

public class Deque<T>
{
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  public Deque()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  public Deque(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      EnqueueTail(item);
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

  private bool IsEmpty()
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

  public void EnqueueHead(T data)
  {
    Node<T> newNode = new Node<T>(data);

    if (IsEmpty())
    {
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      Head.PrevNode = newNode;
      newNode.NextNode = Head;
      Head = newNode;
    }

    Count++;
  }

  public void EnqueueTail(T data)
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

  public T DequeueHead()
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

  public T DequeueTail()
  {
    if (Count > 0)
    {
      T data = Tail.Data;

      if (Count == 1)
      {
        Clear();
      }
      else
      {
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  public T PeekHead()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Deque에 제거할 데이터가 없음");
      return default(T);
    }
    else
    {
      return Head.Data;
    }
  }

  public T PeekTail()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Deque에 제거할 데이터가 없음");
      return default(T);
    }
    else
    {
      return Tail.Data;
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
}