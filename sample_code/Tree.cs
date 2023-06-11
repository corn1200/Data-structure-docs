using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드 데이터, 자식 노드
  public T Data { get; set; }
  public List<Node<T>> Children { get; set; }

  // 생성자
  public Node(T data)
  {
    Data = data;
    Children = new List<Node<T>>();
  }
}

// 트리 클래스
public class Tree<T>
{
  // 루트 노드, 트리 구조 문자열 반환용 변수
  public Node<T> Root { get; set; }
  private string AllTreeString { get; set; }

  // 생성자
  public Tree(T data)
  {
    // 루트 노드와 문자열 변환용 변수를 초기화한다
    Root = new Node<T>(data);
    AllTreeString = "";
  }

  // 트리 구조를 문자열로 변환
  private void TreeToString(Node<T> parent)
  {
    // 현재 노드를 문자열에 저장
    AllTreeString += $"{parent.Data}\n";

    // 현재 노드의 자식 노드에 재귀적으로 접근
    foreach (Node<T> child in parent.Children)
    {
      TreeToString(child);
    }
  }

  // 트리 구조를 문자열로 반환
  public override string ToString()
  {
    AllTreeString = "";
    TreeToString(Root);
    return AllTreeString;
  }

  // 자식 노드 추가
  public Node<T> Add(Node<T> parent, T data)
  {
    // 새 노드 생성 후 부모 노드의 자식 노드로 추가한다
    Node<T> newNode = new Node<T>(data);
    parent.Children.Add(newNode);
    return newNode;
  }

  // 자식 노드 삭제
  public void Remove(Node<T> parent, Node<T> child)
  {
    // 부모 노드의 자식 노드를 삭제한다
    parent.Children.Remove(child);
  }
}