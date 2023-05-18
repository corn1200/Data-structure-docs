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
    public int Count = 0;

    public bool IsEmpty()
    {
        if (Head == null || Tail == null || Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (IsEmpty())
        {
            Head = newNode;
            Tail = Head;
            Count = 1;
        }
        else
        {
            if (Count == 1)
            {
                Tail = newNode;
                Head.NextNode = Tail;
            }
            else
            {
                Tail.NextNode = newNode;
                Tail = newNode;
            }
            Count++;
        }
    }

    public bool AddBefore(int index, T value)
    {
        if(!IsInvalidIndex(index))
        {
            return false;
        } else
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> beforeNode = null;
            Node<T> targetNode = Head;

            for (int i = 0; i < index; i++)
            {
                beforeNode = targetNode;
                targetNode = targetNode.NextNode;
            }

            if(targetNode == Head)
            {
                newNode.NextNode = Head;
                Head = newNode;
            } else
            {
                beforeNode.NextNode = newNode;
                newNode.NextNode = targetNode;
            }
            Count++;
            return true;
        }
    }

    public bool AddAfter(int index, T value)
    {
        if (!IsInvalidIndex(index))
        {
            return false;
        }
        else
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> targetNode = Head;

            for (int i = 0; i < index; i++)
            {
                targetNode = targetNode.NextNode;
            }

            if (targetNode == Tail)
            {
                Tail.NextNode = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.NextNode = targetNode.NextNode;
                targetNode.NextNode = newNode;
            }
            Count++;
            return true;
        }
    }

    public bool Remove(int index)
    {
        if (IsEmpty())
        {
            return false;
        }
        else
        {
            Node<T> beforeNode = null;
            Node<T> removeNode = Head;
            for (int i = 0; i < index; i++)
            {
                beforeNode = removeNode;
                removeNode = removeNode.NextNode;
            }

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else if (removeNode == Head)
            {
                Head = Head.NextNode;
                removeNode = null;
            }
            else
            {
                beforeNode.NextNode = removeNode.NextNode;
                removeNode = null;
            }
            Count--;
            return true;
        }
    }

    public Node<T> Peek()
    {
        return Head;
    }

    public int getCount()
    {
        return Count;
    }

    public Node<T> getNode(int index)
    {
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            Node<T> selectedNode = Head;
            for (int i = 0; i < index; i++)
            {
                selectedNode = selectedNode.NextNode;
            }
            return selectedNode;
        }
    }

    private bool IsInvalidIndex(int index)
    {
        if(0 > index || getCount() - 1 < index)
        {
            return false;
        } else
        {
            return true;
        }
    }
}