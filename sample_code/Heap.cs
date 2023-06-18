using System;
using System.Collections;

// 힙 인터페이스
public interface Heap<T>
{
  // Enumerator 구현
  IEnumerator GetEnumerator();
  // 노드 삽입, 삭제 함수
  void Add(T data);
  T Remove();
}