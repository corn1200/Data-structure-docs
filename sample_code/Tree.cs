using System;
using System.Collections;

public class Node<T>
{
  public T Data { get; set; }
  public List<Node<T>> Children { get; set; }

  public Node(T data)
  {
    Data = data;
    Children = new List<Node<T>>();
  }
}
public class Tree<T>
{
  public Node<T> Root { get; set; }
  private string AllTreeString { get; set; }

  public Tree(T data)
  {
    Root = new Node<T>(data);
    AllTreeString = "";
  }

  public Node<T> Add(Node<T> parent, T data)
  {
    Node<T> newNode = new Node<T>(data);
    parent.Children.Add(newNode);
    return newNode;
  }

  public void Remove(Node<T> parent, Node<T> child)
  {
    parent.Children.Remove(child);
  }

  public void TreeToString(Node<T> parent)
  {
    AllTreeString += $"{parent.Data}\n";

    foreach (Node<T> child in parent.Children)
    {
      TreeToString(child);
    }
  }

  public override string ToString()
  {
    AllTreeString = "";
    TreeToString(Root);
    return AllTreeString;
  }
}