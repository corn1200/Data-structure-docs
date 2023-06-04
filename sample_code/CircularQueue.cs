using System;
using System.Collections;

public class CircularQueue<T>
{
  private T[] DataArray { get; set; }
  private int FrontIndex { get; set; }
  private int RearIndex { get; set; }
  private int MaxCount { get; set; }
  public int Count { get; set; }

  public CircularQueue(int length)
  {
    DataArray = new T[length];
    FrontIndex = 0;
    RearIndex = 0;
    MaxCount = length;
    Count = 0;
  }

  public CircularQueue(IEnumerable<T> items)
  {
    foreach (var item in items)
    {
      Enqueue(item);
    }
  }

  public IEnumerator GetEnumerator()
  {
    ResetOverFrontIndex();
    ResetOverRearIndex();

    if (FrontIndex >= RearIndex)
    {
      for (int i = FrontIndex; i < MaxCount; i++)
      {
        yield return DataArray[i];
      }
      for (int i = 0; i < RearIndex; i++)
      {
        yield return DataArray[i];
      }
    }
    else
    {
      for (int i = FrontIndex; i < RearIndex; i++)
      {
        yield return DataArray[i];
      }
    }
  }

  private void ResetOverFrontIndex()
  {
    if (FrontIndex == MaxCount)
    {
      FrontIndex = 0;
    }
  }

  private void ResetOverRearIndex()
  {
    if (RearIndex == MaxCount)
    {
      RearIndex = 0;
    }
  }

  public bool IsEmpty()
  {
    if (Count == 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public bool IsFull()
  {
    if (Count == MaxCount)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public void Enqueue(T data)
  {
    if (IsFull())
    {
      Console.WriteLine("CircularQueue 공간 부족");
    }
    else
    {
      ResetOverRearIndex();
      DataArray[RearIndex] = data;
      RearIndex++;
      Count++;
    }
  }

  public T Dequeue()
  {
    if (IsEmpty())
    {
      Console.WriteLine("CircularQueue 데이터 없음");
      return default(T);
    }
    else
    {
      ResetOverFrontIndex();
      T data = DataArray[FrontIndex];
      DataArray[FrontIndex] = default(T);
      FrontIndex++;
      Count--;
      return data;
    }
  }

  public T Peek()
  {
    if (IsEmpty())
    {
      return default(T);
    }
    else
    {
      ResetOverFrontIndex();
      return DataArray[FrontIndex];
    }
  }

  public void Clear()
  {
    DataArray = new T[MaxCount];
    FrontIndex = 0;
    RearIndex = 0;
    Count = 0;
  }

  public T[] ToArray()
  {
    return (T[])DataArray.Clone();
  }

  public void CopyTo(T[] array, int arrayIndex)
  {
    array.CopyTo(DataArray, arrayIndex);
  }
}