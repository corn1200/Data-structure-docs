using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값, 다음 노드, 이전 노드
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생서앚
  public Node(T data)
  {
    Data = data;
  }
}

// 덱 클래스
public class Deque<T>
{
  // 최상단 노드, 최하단 노드, 덱 크기
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Deque()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // Enumerable 객체를 덱으로 변환하는 생성자
  public Deque(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      EnqueueTail(item);
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

  // 덱이 비어 있는지 확인
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

  // 최상단에 데이터 삽입
  public void EnqueueHead(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 덱이 비어 있을 경우 실행
    if (IsEmpty())
    {
      // 새 노드는 최상단, 최하단 노드가 됨
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      // 새 노드와 현재 최상단 노드를 교체
      Head.PrevNode = newNode;
      newNode.NextNode = Head;
      Head = newNode;
    }

    Count++;
  }

  // 최하단에 데이터 삽입
  public void EnqueueTail(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 덱이 비어 있을 경우 실행
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

  // 최상단 데이터 제거 및 반환
  public T DequeueHead()
  {
    // 덱에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최상단 노드 데이터 저장
      T data = Head.Data;

      // 덱에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 덱 내부 초기화
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

  // 최하단 데이터 제거 및 반환
  public T DequeueTail()
  {
    // 덱에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최하단 노드 데이터 저장
      T data = Tail.Data;

      // 덱에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 덱 내부 초기화
        Clear();
      }
      else
      {
        // 최하단 노드와 이전 노드를 교체
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  // 다음 제거될 최상단 데이터 조회
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

  // 다음 제거될 최하단 데이터 조회
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

  // 덱 내부 초기화
  public void Clear()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // 덱을 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 덱 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 덱 데이터 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 덱 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}