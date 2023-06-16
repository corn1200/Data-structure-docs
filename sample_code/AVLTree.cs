using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드 데이터, 노드 높이, 왼쪽 노드, 오른쪽 노드
  public T Data { get; set; }
  public int Height { get; set; }
  public Node<T> Left { get; set; }
  public Node<T> Right { get; set; }

  // 생성자
  public Node(T data)
  {
    // 노드 데이터, 기본 높이 초기화
    Data = data;
    Height = 1;
  }
}

// AVL 트리 클래스
public class AVLTree<T>
{
  // 루트 노드, 비교자
  private Node<T> Root { get; set; }
  private Comparer<T> Comparer { get; set; }

  // 기본 생성자
  public AVLTree()
  {
    Comparer = Comparer<T>.Default;
  }

  // 노드 높이 반환
  private int GetHeight(Node<T> node)
  {
    // 노드가 유효하지 않을 경우 0 반환
    if (node == null)
    {
      return 0;
    }
    return node.Height;
  }

  // 노드 높이차 반환
  private int GetHeightDifference(Node<T> node)
  {
    // 노드가 유효하지 않을 경우 0 반환
    if (node == null)
    {
      return 0;
    }
    // 노드의 왼쪽, 오른쪽 높이차 반환
    return GetHeight(node.Left) - GetHeight(node.Right);
  }

  // 왼쪽으로 편향된 노드를 회전
  private Node<T> RotateRight(Node<T> y)
  {
    // 불균형한 노드의 왼쪽 노드, 왼쪽 노드의 오른쪽 부분 트리 저장
    Node<T> x = y.Left;
    Node<T> t2 = x.Right;

    // 왼쪽 노드의 오른쪽에 불균형 노드 위치
    x.Right = y;
    // 불균형 노드의 왼쪽에 부분 트리 위치
    y.Left = t2;

    // 위치 변경된 노드들의 높이 업데이트
    y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
    x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

    // 변경된 위치의 루트 노드를 반환
    return x;
  }

  // 오른쪽으로 편향된 노드를 회전
  private Node<T> RotateLeft(Node<T> x)
  {
    // 불균형한 노드의 오른쪽 노드, 오른쪽 노드의 왼쪽 부분 트리 저장
    Node<T> y = x.Right;
    Node<T> t2 = y.Left;

    // 오른쪽 노드의 왼쪽에 불균형 노드 위치
    y.Left = x;
    // 불균형 노드의 오른쪽에 부분 트리 위치
    x.Right = t2;

    // 위치 변경된 노드들의 높이 업데이트
    x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
    y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

    // 변경된 위치의 루트 노드를 반환
    return y;
  }

  // 노드 삽입을 위한 재귀적 탐색 및 회전
  private Node<T> InsertRecursive(Node<T> node, T data)
  {
    // 노드가 유효하지 않을 경우 실행
    if (node == null)
    {
      // 해당 위치에 더 이상 탐색 가능한 노드가 없는 경우 새로운 노드 선언
      return new Node<T>(data);
    }

    // 입력 값이 현재 노드 값보다 작을 경우 실행
    if (Comparer.Compare(data, node.Data) < 0)
    {
      // 왼쪽 노드로 이동 후 회전된 트리로 초기화
      node.Left = InsertRecursive(node.Left, data);
    }
    // 입력 값이 현재 노드 값보다 클 경우 실행
    else if (Comparer.Compare(data, node.Data) > 0)
    {
      // 오른쪽 노드로 이동 후 회전된 트리로 초기화
      node.Right = InsertRecursive(node.Right, data);
    }
    // 입력 값이 현재 노드 값과 같을 경우 실행
    else
    {
      // 이진 탐색 트리에선 중복 값을 취급하지 않음
      // 아무 작업도 하지 않고 현재 노드 반환
      return node;
    }

    // 회전 후 현재 노드의 높이 초기화
    node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    // 높이차 저장
    int heightDifference = GetHeightDifference(node);

    // LL 경우
    if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) < 0)
    {
      // single rotation
      return RotateRight(node);
    }
    // RR 경우
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) > 0)
    {
      // single rotation
      return RotateLeft(node);
    }
    // LR 경우
    else if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) > 0)
    {
      // double rotation
      node.Left = RotateLeft(node.Left);
      return RotateRight(node);
    }
    // RL 경우
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) < 0)
    {
      // double rotation
      node.Right = RotateRight(node.Right);
      return RotateLeft(node);
    }

    return node;
  }

  // 노드 삽입
  public void Add(T data)
  {
    // 현재 루트 노드가 없을 경우 실행
    if (Root == null)
    {
      // 루트 노드 초기화
      Root = new Node<T>(data);
    }
    else
    {
      // 루트 노드를 회전 후 트리로 초기화
      Root = InsertRecursive(Root, data);
    }
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