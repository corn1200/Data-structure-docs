using System;
using System.Collections;

public class Node<T>
{
  public T Data { get; set; }
  public Node<T> Left { get; set; }
  public Node<T> Right { get; set; }

  public Node(T data)
  {
    Data = data;
  }
}

public class BinarySearchTree<T>
{
  public Node<T> Root { get; set; }
  public Comparer<T> Comparer { get; set; }

  public BinarySearchTree()
  {
    Comparer = Comparer<T>.Default;
  }

  public void Add(T data)
  {
    Node<T> node = Root;

    if (node == null)
    {
      Root = new Node<T>(data);
    }
    else
    {
      while (node != null)
      {
        int compareResult = Comparer.Compare(node.Data, data);
        if (compareResult == 0)
        {
          Console.WriteLine("중복된 값 존재");
          return;
        }
        else if (compareResult > 0)
        {
          if (node.Left == null)
          {
            node.Left = new Node<T>(data);
            return;
          }
          node = node.Left;
        }
        else if (compareResult < 0)
        {
          if (node.Right == null)
          {
            node.Right = new Node<T>(data);
            return;
          }
          node = node.Right;
        }
      }
    }
  }

  public void Remove(T data)
  {
    Node<T> node = Root;

    if (Comparer.Compare(node.Data, data) == 0)
    {
      Root = null;
    }

    while (node != null)
    {
      int compareResult = Comparer.Compare(node.Data, data);

      if (compareResult > 0)
      {
        if (node.Left == null)
        {
          return;
        }
        compareResult = Comparer.Compare(node.Left.Data, data);
        if (compareResult == 0)
        {
          node.Left = null;
        }
        node = node.Left;
      }
      else if (compareResult < 0)
      {
        if (node.Right == null)
        {
          return;
        }
        compareResult = Comparer.Compare(node.Right.Data, data);
        if (compareResult == 0)
        {
          node.Right = null;
        }
        node = node.Right;
      }
    }
  }

  public Node<T> Get(T data)
  {
    Node<T> node = Root;

    while (node != null)
    {
      int compareResult = Comparer.Compare(node.Data, data);

      if (compareResult == 0)
      {
        return node;
      }
      else if (compareResult > 0)
      {
        node = node.Left;
      }
      else if (compareResult < 0)
      {
        node = node.Right;
      }
    }

    return null;
  }

  public bool Contains(T data)
  {
    Node<T> node = Get(data);
    return node != null;
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