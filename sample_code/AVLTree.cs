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

  // 왼쪽 노드를 오른쪽으로 회전
  private Node<T> RotateRight(Node<T> c)
  {
    // 회전의 기준이 되는 세 노드 x, y, z를 in-order로 나열한 a, b, c
    // a는 오른쪽으로 회전 중 유실되지 않기 때문에 저장 생략
    Node<T> b = c.Left;
    // a, b, c의 부분 트리를 in-order로 나열한 T0, T1, T2, T3
    // T0, T1, T3는 오른쪽으로 회전 중 유실되지 않기 때문에 저장 생략
    Node<T> t2 = b.Right;

    // z=c가 루트인 부분 트리를 b를 루트로 하는 새로운 부분 트리로 변경
    // c가 b의 오른쪽 자식이 된다
    // a가 b의 왼쪽 자식이 되는 동작 생략
    b.Right = c;
    // T2가 c의 왼쪽 자식이 된다
    // T0, T1이 a의 왼쪽, 오른쪽 자식이 되는 동작 &
    // T3이 c의 오른쪽 자식이 되는 동작 생략
    c.Left = t2;

    // 위치=레벨 변경된 노드들의 높이 업데이트
    c.Height = Math.Max(GetHeight(c.Left),
        GetHeight(c.Right)) + 1;
    b.Height = Math.Max(GetHeight(b.Left),
        GetHeight(b.Right)) + 1;

    // 위치=루트 변경된 트리 반환
    return b;
  }

  // 오른쪽 노드를 왼쪽으로 회전
  private Node<T> RotateLeft(Node<T> a)
  {
    // 회전의 기준이 되는 세 노드 x, y, z를 in-order로 나열한 a, b, c
    // c는 왼쪽으로 회전 중 유실되지 않기 때문에 저장 생략
    Node<T> b = a.Right;
    // a, b, c의 부분 트리를 in-order로 나열한 T0, T1, T2, T3
    // T0, T2, T3는 왼쪽으로 회전 중 유실되지 않기 때문에 저장 생략
    Node<T> t1 = b.Left;

    // z=a가 루트인 부분 트리를 b를 루트로 하는 새로운 부분 트리로 변경
    // a가 b의 왼쪽 자식이 된다
    // c가 b의 오른쪽 자식이 되는 동작 생략
    b.Left = a;
    // T1가 a의 오른쪽 자식이 된다
    // T0이 a의 왼쪽 자식이 되는 동작 &
    // T2, T3이 c의 왼쪽, 오른쪽 자식이 되는 동작 생략
    a.Right = t1;

    // 위치=레벨 변경된 노드들의 높이 업데이트
    a.Height = Math.Max(GetHeight(a.Left),
        GetHeight(a.Right)) + 1;
    b.Height = Math.Max(GetHeight(b.Left), GetHeight(b.Right)) + 1;

    // 위치=루트 변경된 트리 반환
    return b;
  }

  // 노드 삽입을 위한 재귀적 탐색 및 회전
  private Node<T> InsertRecursive(Node<T> node, T data)
  {
    // 노드가 유효하지 않을 경우 실행
    if (node == null)
    {
      // 더 이상 탐색 가능한 노드가 없는 경우 새로운 노드 선언 및 반환
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
      // 아무 작업도 하지 않고 현재 노드 반환
      Console.WriteLine("중복된 값 존재");
      return node;
    }

    // 탐색 및 회전 후 현재 노드의 높이 초기화
    node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    // 좌우 자식의 높이차 계산
    int heightDifference = GetHeightDifference(node);

    // 불균형 노드 z의 자식 중 가장 큰 높이인 y, y의 자식 중 가장 큰 높이인 x
    // x, y, z 의 불균형 배치를 네 가지 경우로 나눈다

    // Left-Left case: y가 z의 왼쪽 노드, x가 y의 왼쪽 노드일 경우 실행
    if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) < 0)
    {
      // single rotation
      // z를 y의 오른쪽으로 회전 시킨 트리를 반환
      return RotateRight(node);
    }
    // Right-Right case: y가 z의 오른쪽 노드, x가 y의 오른쪽 노드일 경우 실행
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) > 0)
    {
      // single rotation
      // z를 y의 왼쪽으로 회전 시킨 트리를 반환
      return RotateLeft(node);
    }
    // Left-Right case: y가 z의 왼쪽 노드, x가 y의 오른쪽 노드일 경우 실행
    else if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) > 0)
    {
      // double rotation
      // 왼쪽 노드=y를 y를 x의 왼쪽으로 회전 시킨 트리로 초기화
      // x, y, z의 배치가 Left-Left case가 됨
      node.Left = RotateLeft(node.Left);
      // z를 y의 오른쪽으로 회전 시킨 트리를 반환
      return RotateRight(node);
    }
    // Right-Left case: y가 z의 오른쪽 노드, x가 y의 왼쪽 노드일 경우 실행
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) < 0)
    {
      // double rotation
      // 오른쪽 노드=y를 y를 x의 오른쪽으로 회전 시킨 트리로 초기화
      // x, y, z의 배치가 Right-Right case가 됨
      node.Right = RotateRight(node.Right);
      // z를 y의 왼쪽으로 회전 시킨 트리를 반환
      return RotateLeft(node);
    }

    // 회전이 필요하지 않은 노드 반환
    return node;
  }

  // 노드 제거를 위한 재귀적 탐색 및 회전
  private Node<T> DeleteRecursive(Node<T> node, T data)
  {
    // 노드가 유효하지 않을 경우 실행
    if (node == null)
    {
      // 더 이상 탐색 가능한 노드가 없는 경우 삭제할 노드가 없다고 출력
      Console.WriteLine("삭제할 노드가 없음");
      return null;
    }

    // 현재 노드의 왼쪽 자식이 삭제할 노드일 경우 실행
    if (node.Left != null && Comparer.Compare(data, node.Left.Data) == 0)
    {
      // 왼쪽 자식 삭제
      node.Left = null;
    }
    // 현재 노드의 오른쪽 자식이 삭제할 노드일 경우 실행
    else if (node.Right != null && Comparer.Compare(data, node.Right.Data) == 0)
    {
      // 오른쪽 자식 삭제
      node.Right = null;
    }
    // 현재 노드의 자식 중 삭제할 값에 해당하는 노드가 없을 경우 실행
    else
    {
      // 입력 값이 현재 노드 값보다 작을 경우 실행
      if (Comparer.Compare(data, node.Data) < 0)
      {
        // 왼쪽 노드로 이동 후 회전된 트리로 초기화
        node.Left = DeleteRecursive(node.Left, data);
      }
      // 입력 값이 현재 노드 값보다 클 경우 실행
      else if (Comparer.Compare(data, node.Data) > 0)
      {
        // 오른쪽 노드로 이동 후 회전된 트리로 초기화
        node.Right = DeleteRecursive(node.Right, data);
      }
    }

    // 탐색, 회전, 노드 삭제 후 현재 노드의 높이 초기화
    node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    // 좌우 자식의 높이차 계산
    int heightDifference = GetHeightDifference(node);

    // 불균형 노드 z의 자식 중 가장 큰 높이인 y, y의 자식 중 가장 큰 높이인 x
    // x, y, z 의 불균형 배치를 네 가지 경우로 나눈다

    // Left-Left case: y가 z의 왼쪽 노드, x가 y의 왼쪽 노드일 경우 실행
    if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) < 0)
    {
      // single rotation
      // z를 y의 오른쪽으로 회전 시킨 트리를 반환
      return RotateRight(node);
    }
    // Right-Right case: y가 z의 오른쪽 노드, x가 y의 오른쪽 노드일 경우 실행
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) > 0)
    {
      // single rotation
      // z를 y의 왼쪽으로 회전 시킨 트리를 반환
      return RotateLeft(node);
    }
    // Left-Right case: y가 z의 왼쪽 노드, x가 y의 오른쪽 노드일 경우 실행
    else if (heightDifference > 1 && Comparer.Compare(data, node.Left.Data) > 0)
    {
      // double rotation
      // 왼쪽 노드=y를 y를 x의 왼쪽으로 회전 시킨 트리로 초기화
      // x, y, z의 배치가 Left-Left case가 됨
      node.Left = RotateLeft(node.Left);
      // z를 y의 오른쪽으로 회전 시킨 트리를 반환
      return RotateRight(node);
    }
    // Right-Left case: y가 z의 오른쪽 노드, x가 y의 왼쪽 노드일 경우 실행
    else if (heightDifference < -1 && Comparer.Compare(data, node.Right.Data) < 0)
    {
      // double rotation
      // 오른쪽 노드=y를 y를 x의 오른쪽으로 회전 시킨 트리로 초기화
      // x, y, z의 배치가 Right-Right case가 됨
      node.Right = RotateRight(node.Right);
      // z를 y의 왼쪽으로 회전 시킨 트리를 반환
      return RotateLeft(node);
    }

    // 회전이 필요하지 않은 노드 반환
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

  // 노드 제거
  public void Remove(T data)
  {
    // 현재 루트 노드가 없을 경우 실행
    if (Root == null)
    {
      // 삭제할 노드가 없다고 출력
      Console.WriteLine("삭제할 노드가 없음");
      return;
    }
    else
    {
      // 루트 노드를 회전 후 트리로 초기화
      Root = DeleteRecursive(Root, data);
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