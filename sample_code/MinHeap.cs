using System;
using System.Collections;

public class MinHeap<T> : Heap<T>
{
  private List<T> Tree { get; set; }
  private Comparer<T> Comparer { get; set; }

  public MinHeap()
  {
    Tree = new List<T>();
    Comparer = Comparer<T>.Default;
  }

  public IEnumerator<T> GetEnumerator()
  {
    for (int i = 1; i < Tree.Count; i++)
    {
      yield return Tree[i];
    }
  }

  private void Swap(int a, int b)
  {
    T temp = Tree[a];
    Tree[a] = Tree[b];
    Tree[b] = temp;
  }

  public void Add(T data)
  {
    if (Tree.Count == 0)
    {
      Tree.Add(default);
      Tree.Add(data);
    }
    else
    {
      Tree.Add(data);
      int currIndex = Tree.Count - 1;
      int compareResult;
      while (currIndex > 1)
      {
        int parentIndex = currIndex / 2;
        compareResult = Comparer.Compare(data, Tree[parentIndex]);

        if (compareResult < 0)
        {
          Swap(currIndex, parentIndex);
          currIndex = parentIndex;
        }
        else
        {
          break;
        }
      }
    }
  }

  public T Remove()
  {
    if (Tree.Count == 0)
    {
      Console.WriteLine("힙이 비어있음.");
      return default;
    }
    else
    {
      T rootData = Tree[1];

      int maxIndex = Tree.Count - 1;
      Tree[1] = Tree[maxIndex];
      Tree.RemoveAt(maxIndex);
      maxIndex = Tree.Count - 1;

      int currIndex = 1;
      int leftComparerResult;
      int rightComparerResult;
      while (currIndex < maxIndex)
      {
        int leftIndex = currIndex * 2;
        int rightIndex = currIndex * 2 + 1;
        leftComparerResult = Comparer.Compare(Tree[currIndex],
            Tree[leftIndex]);
        rightComparerResult = Comparer.Compare(Tree[currIndex],
            Tree[rightIndex]);
        if (leftComparerResult > 0)
        {
          Swap(currIndex, leftIndex);
          currIndex = leftIndex;
        }
        else if (rightComparerResult > 0)
        {
          Swap(currIndex, rightIndex);
          currIndex = rightIndex;
        }
        else
        {
          break;
        }
      }

      return rootData;
    }
  }
}