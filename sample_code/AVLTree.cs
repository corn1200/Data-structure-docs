using System;
using System.Collections;

public class Node<T>
{
  public T Data { get; set; }
  public int Height { get; set; }
  public Node<T> Left { get; set; }
  public Node<T> Right { get; set; }

  public Node(T data)
  {
    Data = data;
    Height = 1;
  }
}

public class AVLTree<T>
{
  private Node<T> Root { get; set; }
  private Comparer<T> Comparer { get; set; }

  public AVLTree()
  {
    Comparer = Comparer<T>.Default;
  }

  private int GetHeight(Node<T> node)
  {
    if (node == null)
    {
      return 0;
    }
    return node.Height;
  }

  private int GetHeightDifference(Node<T> node)
  {
    if (node == null)
    {
      return 0;
    }
    return GetHeight(node.Left) - GetHeight(node.Right);
  }

  private Node<T> RotateRight(Node<T> y)
  {
    Node<T> x = y.Left;
    Node<T> t2 = x.Right;

    x.Right = y;
    y.Left = t2;

    y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
    x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

    return x;
  }

  private Node<T> RotateLeft(Node<T> x)
  {
    Node<T> y = x.Right;
    Node<T> t2 = y.Left;

    y.Left = x;
    x.Right = t2;

    x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
    y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

    return y;
  }

  public void Add(T data)
  {
    if (Root == null)
    {
      Root = new Node<T>(data);
    }
    else
    {
      Root = InsertRecursive(Root, data);
    }
  }

  private Node<T> InsertRecursive(Node<T> node, T data)
  {
    if (node == null)
    {
      return new Node<T>(data);
    }

    int compareResult = Comparer.Compare(data, node.Data);

    if (compareResult < 0)
    {
      node.Left = InsertRecursive(node.Left, data);
    }
    else if (compareResult > 0)
    {
      node.Right = InsertRecursive(node.Right, data);
    }
    else
    {
      return node;
    }

    node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    int heightDifference = GetHeightDifference(node);

    if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) < 0)
    {
      return RotateRight(node);
    }
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) > 0)
    {
      return RotateLeft(node);
    }
    else if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) > 0)
    {
      node.Left = RotateLeft(node.Left);
      return RotateRight(node);
    }
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) < 0)
    {
      node.Right = RotateRight(node.Right);
      return RotateLeft(node);
    }

    return node;
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