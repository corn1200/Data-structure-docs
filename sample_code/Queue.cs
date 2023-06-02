using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값, 다음 노드, 이전 노드
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생성자
  public Node(T data)
  {
    Data = data;
  }
}

// 큐 클래스
public class Queue<T>
{
  // 최상단 노드, 최하단 노드, 큐 크기
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Queue()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // Enumerable 객체를 스택으로 변환하는 생성자
  public Queue(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      Enqueue(item);
    }
  }

  // IEnumerator 구현
  public IEnumerator GetEnumerator()
  {
    Node<T> currNode = Head;
    while (currNode != null)
    {
      yield return currNode.Data;
      currNode = currNode.NextNode;
    }
  }

  // 큐가 비어 있는지 확인
  private bool IsEmpty()
  {
    // 최상단, 최하단 노드가 존재하지 않거나 크기가 0일시 true 반환
    if (Head == null || Tail == null || Count <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 데이터 삽입
  public void Enqueue(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 큐가 비어 있을 경우 실행
    if (IsEmpty())
    {
      // 새 노드는 최상단, 최하단 노드가 됨
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      // 새 노드와 현재 최하단 노드를 교체
      Tail.NextNode = newNode;
      newNode.PrevNode = Tail;
      Tail = newNode;
    }

    Count++;
  }

  // 데이터 제거
  public T Dequeue()
  {
    // 큐에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최상단 노드 데이터 저장
      T data = Head.Data;

      // 큐에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 큐 내부 정리
        Clear();
      }
      else
      {
        // 최상단 노드와 다음 노드를 교체
        Head = Head.NextNode;
        Head.PrevNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  // 다음 제거될 데이터 조회
  public T Peek()
  {
    // 큐가 비어 있을 경우 실행
    if (IsEmpty())
    {
      return default(T);
    }
    else
    {
      return Head.Data;
    }
  }

  // 모든 데이터 삭제
  public void Clear()
  {
    // 최상단, 최하단 노드 참조 해제 및 크기 0으로 초기화
    Head = null;
    Tail = null;
    Count = 0;
  }

  // 큐를 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 큐 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 큐 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 큐 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}