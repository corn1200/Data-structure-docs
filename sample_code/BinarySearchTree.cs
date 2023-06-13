using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드 데이터, 왼쪽 노드, 오른쪽 노드
  public T Data { get; set; }
  public Node<T> Left { get; set; }
  public Node<T> Right { get; set; }

  // 생성자
  public Node(T data)
  {
    Data = data;
  }
}

// 이진 탐색 트리 클래스
public class BinarySearchTree<T>
{
  // 루트 노드, 노드 비교자
  public Node<T> Root { get; set; }
  private Comparer<T> Comparer { get; set; }

  // 기본 생성자
  public BinarySearchTree()
  {
    Comparer = Comparer<T>.Default;
  }

  // 노드 추가
  public void Add(T data)
  {
    // 현재 노드
    Node<T> current = Root;

    // 현재 노드가 없을 경우 실행
    if (current == null)
    {
      // 새로운 노드를 루트 노드로 지정
      Root = new Node<T>(data);
    }
    else
    {
      // 탐색할 수 없을 때까지 반복
      while (current != null)
      {
        // 비교자를 통해 현재 노드 값과 입력 값을 비교
        int compareResult = Comparer.Compare(current.Data, data);

        // 현재 노드 값과 입력 값이 동일할 경우 실행
        if (compareResult == 0)
        {
          Console.WriteLine("중복된 값 존재");
          return;
        }
        // 입력 값이 현재 노드 값 보다 작을 경우 실행
        else if (compareResult > 0)
        {
          // 현재 노드의 왼쪽이 비어 있을 경우 실행
          if (current.Left == null)
          {
            // 현재 노드의 왼쪽에 새로운 노드 추가
            current.Left = new Node<T>(data);
            return;
          }
          // 왼쪽 노드로 이동
          current = current.Left;
        }
        // 입력 값이 현재 노드 값 보다 클 경우 실행
        else if (compareResult < 0)
        {
          // 현재 노드의 오른쪽이 비어 있을 경우 실행
          if (current.Right == null)
          {
            // 현재 노드의 오른쪽에 새로운 노드 추가
            current.Right = new Node<T>(data);
            return;
          }
          // 오른쪽 노드로 이동
          current = current.Right;
        }
      }
    }
  }

  // 노드 제거
  public void Remove(T data)
  {
    // 현재 노드
    Node<T> current = Root;

    // 삭제할 노드가 루트인 경우 실행
    if (Comparer.Compare(current.Data, data) == 0)
    {
      // 루트 노드 제거
      Root = null;
    }

    // 탐색할 수 없을 때까지 반복
    while (current != null)
    {
      // 비교자를 통해 현재 노드 값과 입력 값을 비교
      int compareResult = Comparer.Compare(current.Data, data);

      // 입력 값이 현재 노드 보다 작을 경우 실행
      if (compareResult > 0)
      {
        // 왼쪽 노드가 없을 경우 실행
        if (current.Left == null)
        {
          return;
        }

        // 비교자를 통해 왼쪽 노드 값과 입력 값을 비교
        compareResult = Comparer.Compare(current.Left.Data, data);
        // 왼쪽 노드 값과 입력 값이 동일할 경우 실행
        if (compareResult == 0)
        {
          // 왼쪽 노드 제거
          current.Left = null;
          return;
        }
        // 왼쪽 노드로 이동
        current = current.Left;
      }
      // 입력 값이 현재 노드 보다 클 경우 실행
      else if (compareResult < 0)
      {
        // 오른쪽 노드가 없을 경우 실행
        if (current.Right == null)
        {
          return;
        }

        // 비교자를 통해 왼쪽 노드 값과 입력 값을 비교
        compareResult = Comparer.Compare(current.Right.Data, data);
        // 오른쪽 노드 값과 입력 값이 동일할 경우 실행
        if (compareResult == 0)
        {
          // 오른쪽 노드 제거
          current.Right = null;
          return;
        }
        // 오른쪽 노드로 이동
        current = current.Right;
      }
    }
  }

  // 노드 검색
  public Node<T> Get(T data)
  {
    // 현재 노드
    Node<T> current = Root;

    // 탐색할 수 없을 때까지 반복
    while (current != null)
    {
      // 비교자를 통해 현재 노드 값과 입력 값을 비교
      int compareResult = Comparer.Compare(current.Data, data);

      // 현재 노드 값과 입력 값이 동일할 경우 실행
      if (compareResult == 0)
      {
        // 현재 노드 반환
        return current;
      }
      // 입력 값이 현재 노드 보다 작을 경우 실행
      else if (compareResult > 0)
      {
        // 왼쪽 노드로 이동
        current = current.Left;
      }
      // 입력 값이 현재 노드 보다 클 경우 실행
      else if (compareResult < 0)
      {
        // 오른쪽 노드로 이동
        current = current.Right;
      }
    }

    return null;
  }

  // 노드 존재하는지 확인
  public bool Contains(T data)
  {
    // 노드 검색 후 null이 아니라면 true 반환
    Node<T> getNode = Get(data);
    return getNode != null;
  }

  // 중위 순회(In-order) 출력
  public void InOrderTraversal()
  {
    // 노드 이동 경로를 저장할 스택
    // 방문 완료한 노드를 저장할 HashSet
    Stack<Node<T>> stack = new Stack<Node<T>>();
    HashSet<Node<T>> visited = new HashSet<Node<T>>();

    // 이동 경로에 루트 노드 추가
    stack.Push(Root);

    // 모든 노드를 순회할 때까지 반복
    while (stack.Count > 0)
    {
      // 현재 위치 노드, 현재 노드의 왼쪽 노드
      Node<T> current = stack.Peek();
      Node<T> left = current.Left;

      // 왼쪽 노드가 없거나 이미 방문한 노드일 때 까지 반복
      while (left != null && !visited.Contains(left))
      {
        // 이동 경로에 왼쪽 노드 추가
        stack.Push(left);
        // 왼쪽 노드를 이동한 노드의 왼쪽 노드로 교체
        left = left.Left;
      }

      // 이동 경로 중 가장 최근 노드를 방문
      Node<T> visit = stack.Pop();
      // 방문한 노드 출력
      Console.Write($"{visit.Data} ");
      // 노드 집합에 방문한 노드 저장
      visited.Add(visit);

      // 방문한 노드에 오른쪽 노드가 있을 경우 실행
      if (visit.Right != null)
      {
        // 이동 경로에 오른쪽 노드 추가
        stack.Push(visit.Right);
      }
    }
  }

  // 전위 순회(Pre-order) 출력
  public void PreOrderTraversal()
  {
    // 노드 이동 경로를 저장할 스택
    Stack<Node<T>> stack = new Stack<Node<T>>();

    // 이동 경로에 루트 노드 추가
    stack.Push(Root);

    // 모든 노드를 순회할 때까지 반복
    while (stack.Count > 0)
    {
      // 이동 경로 중 가장 최근 노드를 방문
      Node<T> visit = stack.Pop();
      // 방문한 노드의 왼쪽, 오른쪽 노드
      Node<T> left = visit.Left;
      Node<T> right = visit.Right;

      // 방문한 노드 출력
      Console.Write($"{visit.Data} ");

      // 오른쪽 노드가 있을 경우 실행
      if (right != null)
      {
        // 이동 경로에 오른쪽 노드 추가
        stack.Push(right);
      }
      // 왼쪽 노드가 있을 경우 실행
      if (left != null)
      {
        // 이동 경로에 왼쪽 노드 추가
        stack.Push(left);
      }
    }
  }

  // 후위 순회(Post-order) 출력
  public void PostOrderTraversal()
  {
    // 노드 이동 경로를 저장할 스택
    Stack<Node<T>> stack = new Stack<Node<T>>();
    // 방문한 노드를 저장할 문자열
    string result = "";

    // 이동 경로에 루트 노드 추가
    stack.Push(Root);

    // 모든 노드를 순회할 때까지 반복
    while (stack.Count > 0)
    {
      // 이동 경로 중 가장 최근 노드를 방문
      Node<T> visit = stack.Pop();
      // 방문한 노드의 왼쪽, 오른쪽 노드
      Node<T> left = visit.Left;
      Node<T> right = visit.Right;

      // 방문한 노드를 거꾸로 저장
      result = $"{visit.Data} " + result;

      // 왼쪽 노드가 있을 경우 실행
      if (left != null)
      {
        // 이동 경로에 왼쪽 노드 추가
        stack.Push(left);
      }
      // 오른쪽 노드가 있을 경우 실행
      if (right != null)
      {
        // 이동 경로에 오른쪽 노드 추가
        stack.Push(right);
      }
    }

    // 방문한 노드 출력
    Console.Write(result);
  }

  // 레벨 순서 순회(Level-order) 출력
  public void LevelOrderTraversal()
  {
    // 노드 이동 경로를 저장할 큐
    Queue<Node<T>> queue = new Queue<Node<T>>();

    // 이동 경로에 루트 노드 추가
    queue.Enqueue(Root);

    // 모든 노드를 순회할 때까지 반복
    while (queue.Count > 0)
    {
      // 이동 경로 중 가장 과거 노드를 방문
      Node<T> visit = queue.Dequeue();
      // 방문한 노드의 왼쪽, 오른쪽 노드
      Node<T> left = visit.Left;
      Node<T> right = visit.Right;

      // 방문한 노드 출력
      Console.Write($"{visit.Data} ");

      // 왼쪽 노드가 있을 경우 실행
      if (left != null)
      {
        // 이동 경로에 왼쪽 노드 추가
        queue.Enqueue(left);
      }
      // 오른쪽 노드가 있을 경우 실행
      if (right != null)
      {
        // 이동 경로에 오른쪽 노드 추가
        queue.Enqueue(right);
      }
    }
  }
}