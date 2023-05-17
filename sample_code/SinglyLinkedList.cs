using System;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> NextNode { get; set; }

    public Node(T value)
    {
        this.Value = value;
    }
}

public class SinglyLinkedList<T>
{
    public Node<T> Head;
    public Node<T> Tail;
    public int Count;

    public void Add(T Value)
    {
        Node<T> newNode = new Node<T>(Value);
        if (Head == null)
        {
            Head = newNode;
            Tail = Head;
            Count = 1;
        }
        else
        {
            if(Count == 1)
            {
                Tail = newNode;
                Head.NextNode = Tail;
            } else
            {
                Tail.NextNode = newNode;
                Tail = newNode;
            }
            Count++;
        }
    }
}