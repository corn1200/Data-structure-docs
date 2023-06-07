using System;
using System.Collections;

public class Node<T>
{
  public List<Node<T>> Neighbors { get; set; }
  public List<int> Weights { get; set; }
  public T Data { get; set; }

  public Node(T data)
  {
    Neighbors = new List<Node<T>>();
    Weights = new List<int>();
    Data = data;
  }
}

public class Graph<T>
{
  private List<Node<T>> NodeList { get; set; }

  public Graph()
  {
    NodeList = new List<Node<T>>();
  }

  public Node<T> AddNode(T data)
  {
    Node<T> newNode = new Node<T>(data);
    NodeList.Add(newNode);
    return newNode;
  }

  public void AddEdge(Node<T> from, Node<T> to,
      bool isDirected = true, int weight = 0)
  {
    from.Neighbors.Add(to);
    from.Weights.Add(weight);

    if (!isDirected)
    {
      to.Neighbors.Add(from);
      to.Weights.Add(weight);
    }
  }

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