using System;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체, 이전 노드 객체
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생성자
  public Node(T data)
  {
    this.Data = data;
  }
}

// 연결 리스트 클래스
public class DoubleLinkedList<T>
{
  // 머리 노드, 꼬리 노드, 연결 리스트 길이
  public Node<T> Head { get; set; }
  public Node<T> Tail { get; set; }
  public int Length = 0;

  // 인덱스 값이 유효한지 확인
  private bool IsInvalidIndex(int index)
  {
    // 인덱스가 0 미만이거나,
    // 연결 리스트 길이를 초과할 경우 false 반환
    if (0 > index || GetLength() - 1 < index)
    {
      return false;
    }
    else
    {
      return true;
    }
  }


  // 연결 리스트가 비어 있는지 확인
  public bool IsEmpty()
  {
    // 머리 노드가 존재하지 않거나,
    // 꼬리 노드가 존재하지 않거나,
    // 연결 리스트에 노드가 존재하지 않을 시 true 반환
    if (Head == null || Tail == null || Length <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 꼬리 노드 다음에 새로운 노드 추가
  public void Add(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 연결 리스트가 비어 있는지 확인
    if (IsEmpty())
    {
      // 새로운 노드는 머리 노드이자 꼬리 노드가 된다
      Head = newNode;
      Tail = newNode;
      Length = 1;
    }
    else
    {
      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 새로운 노드는 꼬리 노드가 된다
        // 머리 노드의 다음 노드는 꼬리 노드가 된다
        // 꼬리 노드의 이전 노드는 머리 노드가 된다
        Tail = newNode;
        Head.NextNode = Tail;
        Tail.PrevNode = Head;
      }
      else
      {
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드의 이전 노드는 꼬리 노드가 된다
        // 새로운 노드는 꼬리 노드가 된다
        Tail.NextNode = newNode;
        newNode.PrevNode = Tail;
        Tail = newNode;
      }
      Length++;
    }
  }

  // 지정한 노드 다음에 새로운 노드 추가
  public bool AddBefore(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드 생성
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 머리 노드일 경우 실행
      if (targetNode == Head)
      {
        // 머리 노드는 새로운 노드의 다음 노드가 된다
        // 새로운 노드는 머리 노드의 이전 노드가 된다
        // 새로운 노드는 머리 노드가 된다
        newNode.NextNode = Head;
        Head.PrevNode = newNode;
        Head = newNode;
      }
      else
      {
        // 새로운 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 새로운 노드의 이전 노드가 된다
        targetNode.PrevNode.NextNode = newNode;
        newNode.NextNode = targetNode;
        newNode.PrevNode = targetNode.PrevNode;
      }
    }
    Length++;
    return true;
  }

  // 지정한 노드 이전에 새로운 노드 추가
  public bool AddAfter(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 꼬리 노드일 경우 실행
      if (targetNode == Tail)
      {
        // 꼬리 노드는 새로운 노드의 이전 노드가 된다
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드는 꼬리가 된다
        newNode.PrevNode = Tail;
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      else
      {
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 다음 노드는 새로운 노드의 다음 노드가 된다
        // 새로운 노드는 지정한 노드의 다음 노드가 된다
        newNode.PrevNode = targetNode;
        newNode.NextNode = targetNode.NextNode;
        targetNode.NextNode = newNode;
      }
      Length++;
      return true;
    }
  }

  // 지정한 노드 삭제
  public bool Remove(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 이전 노드, 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 머리 노드, 꼬리 노드 참조 해제
        Head = null;
        Tail = null;
      }
      // 지정한 노드가 머리 노드일 경우 실행
      else if (targetNode == Head)
      {
        // 머리 노드의 다음 노드는 머리 노드가 된다
        // 머리 노드의 이전 노드 참조를 해제한다
        // 지정한 노드의 참조를 해제한다
        Head = Head.NextNode;
        Head.PrevNode = null;
        targetNode = null;
      }
      // 지정한 노드가 꼬리 노드일 경우 실행
      else if (targetNode == Tail)
      {
        // 꼬리 노드의 다음 노드는 머리 노드가 된다
        // 꼬리 노드의 다음 노드 참조를 해제한다
        // 지정한 노드의 참조를 해제한다
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        targetNode = null;
      }
      else
      {
        // 지정한 노드의 다음 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 다음 노드의 이전 노드가 된다
        // 지정한 노드의 참조를 해제한다
        targetNode.PrevNode.NextNode = targetNode.NextNode;
        targetNode.NextNode.PrevNode = targetNode.PrevNode;
        targetNode = null;
      }
      Length--;
      return true;
    }
  }

  // 첫 노드를 반환
  public Node<T> Peek()
  {
    return Head;
  }

  // 연결 리스트의 길이를 반환
  public int GetLength()
  {
    return Length;
  }

  // 지정한 노드를 반환
  public Node<T> GetNode(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return null;
    }
    else
    {
      // 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드 반환
      return targetNode;
    }
  }
}