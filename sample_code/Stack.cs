using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }

  // 생성자
  public Node(T data)
  {
    this.Data = data;
  }
}

// 스택 클래스
public class Stack<T>
{
  // 최상단 노드, 스택 크기
  private Node<T> Head { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Stack()
  {
    Head = null;
    Count = 0;
  }

  // Enumerable 객체를 스택으로 변환하는 생성자
  public Stack(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      Push(item);
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

  // 데이터 삽입
  public void Push(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 스택 최상단에 데이터 추가
    newNode.NextNode = Head;
    Head = newNode;

    Count++;
  }

  // 데이터 제거
  public T Pop()
  {
    // 최상단 노드 참조
    Node<T> headNode = Head;

    // 반환할 데이터 저장 후 최상단 갱신
    // 이전 최상단 노드의 참조 해제
    T data = headNode.Data;
    Head = headNode.NextNode;
    headNode = null;

    Count--;
    return data;
  }

  // 다음 제거될 데이터 조회
  public T Peek()
  {
    return Head.Data;
  }

  // 모든 데이터 삭제
  public void Clear()
  {
    // 최상단 노드 참조 해제 및 크기 0으로 초기화
    Head = null;
    Count = 0;
  }

  // 스택을 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 스택 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 스택 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 스택 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}