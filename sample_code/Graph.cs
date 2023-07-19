using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 인접 노드, 간선 이동 비용, 노드 데이터
  public List<Node<T>> Neighbors { get; set; }
  public List<int> Weights { get; set; }
  public T Data { get; set; }

  // 생성자
  public Node(T data)
  {
    Neighbors = new List<Node<T>>();
    Weights = new List<int>();
    Data = data;
  }
}

// 그래프 클래스
public class Graph<T>
{
  // 노드 목록
  private List<Node<T>> NodeList { get; set; }

  // 기본 생성자
  public Graph()
  {
    NodeList = new List<Node<T>>();
  }

  // 노드 목록 반환
  public List<Node<T>> GetNodeList()
  {
    return NodeList;
  }

  // 노드 추가
  public Node<T> AddNode(T data)
  {
    // 새 노드 생성, 노드 목록에 추가
    Node<T> newNode = new Node<T>(data);
    NodeList.Add(newNode);
    return newNode;
  }

  // 노드 사이 간선 추가
  // 기본값으로 유향 그래프, 간선 이동 비용 0으로 취급
  public void AddEdge(Node<T> from, Node<T> to,
      bool isDirected = true, int weight = 0)
  {
    // 인접 노드, 간선 이동 비용 추가
    from.Neighbors.Add(to);
    from.Weights.Add(weight);

    // 무향 그래프일 경우 실행
    if (!isDirected)
    {
      // 목표 노드에 현재 노드를 인접 노드로 추가
      // 목표 노드 간선 이동 비용 추가
      to.Neighbors.Add(from);
      to.Weights.Add(weight);
    }
  }

  // 모든 노드의 모든 간선 조회
  public void WriteToString()
  {
    foreach (Node<T> node in NodeList)
    {
      int i = 0;
      foreach (var n in node.Neighbors)
      {
        string s = node.Data + " -> " + n.Data + " : " + node.Weights[i];
        Console.WriteLine(s);
        i++;
      }
    }
  }
}