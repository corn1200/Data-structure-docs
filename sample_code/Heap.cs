using System;
using System.Collections;

public interface Heap<T>
{
  IEnumerator<T> GetEnumerator();
  void Add(T data);
  T Remove();
}