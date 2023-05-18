# Data-structure-docs

# 목차
* [1. 개요][1.]
  + [1.1. 추상적 자료형과의 관계][1.1.]

[1.]: #1-개요
[1.1.]: #11-추상적-자료형과의-관계

# 1. 개요
컴퓨터과학에서 데이터를 구조적으로 표현하는 방식과 이를 구현하는 데 필요한 알고리즘에 대해 논하는 기초이론, 혹은 과목이다.  
컴퓨터과학에서 알고리즘과 함께 가장 중요한 기초이론이다.  

컴퓨터의 메모리는 1차원 구조이기 때문에(메모리 하드웨어는 2차원 또는 3차원 구조이지만 CPU에서 논리적으로 바라보는 메모리 공간은 1차원이다.) 현실 세계의 다차원 데이터를 다루기 위해서는 이것을 1차원인 선 형태로 바꾸는 것이 필요하다.  

## 1.1. 추상적 자료형과의 관계
추상적 자료형은 알고리즘이 문제를 해결하는데 필요한 자료의 형태와 자료를 사용한 연산들을 수학적으로 정의한 모델이다.  
그리고 자료구조는 추상적 자료형이 정의한 연산들을 구현한 구현체를 가리키는 말이다.  
스택의 예를 들면, 함수 호출을 관리하기 위해 후입선출의 성질을 가진 추상적 자료형이 필요하니 pop과 push를 가지도록 스택이라는 추상적 자료형을 정의하고, 그것을 구현해서 함수 호출을 관리하는데 사용하는 구현체, 즉 자료구조를 콜 스택이라고 부른다.

# 2. 리스트
추상적 자료형, 자료구조의 하나.   
순열(Sequence)이라고도 불리며, 순서를 가지고('정해진 순서'를 가지기 때문에 선형구조라고도 하며, 선형구조에는 리스트(List), 스택(Stack), 큐(Queue), 덱(Deque)가 있다. 선형구조가 아닌 것은 비선형 구조로써, 트리(Tree)와 그래프(Graph)가 있다.) 일렬로 나열한 원소들의 모임으로 정의한다.  
순서가 있다는 점에서 집합과는 구별되며, 갈림길 없이 일렬로 나열되어 처음과 끝이 각각 하나씩만 있다는 점에서 그래프와도 구별된다.

리스트는 보통 다음 연산들을 가지고 있다.

* 빈 리스트를 만드는 연산 (Constructor, 생성자)
* 리스트가 비어있는지 확인하는 연산 (is Empty?)
* 리스트의 앞에 원소를 삽입하는 연산 (add Head 또는 add First)
* 리스트의 뒤에 원소를 삽입하는 연산 (add Tail 또는 add Last)
* 리스트의 제일 첫 원소를 알아보는 연산 (peek)
* 리스트의 첫 원소를 제외한 나머지 리스트를 알아보는 연산

리스트를 컴퓨터에서 사용할 수 있게 구현한 것이 연결 리스트다.

리스트의 각 원소에 순서대로 번호를 붙일 수도 있으며, 이 번호를 사용해서 임의의 원소를 찾을 수 있는 연산을 추가할 수도 있다.   
때문에 배열을 리스트의 일종으로 볼 수도 있다.

## 2.1. 배열
순서대로 번호가 붙은 원소들이 연속적인 형태로 구성된 구조를 뜻하며, 이때 각 원소에 붙은 번호를 흔히 첨자(인덱스, index)라고 부른다.   
원소들이 연속적으로 배치되어 있기에, 임의의 첨자로 각 원소를 접근하는 데에 드는 시간복잡도는 O(1)이다.  
따라서 임의 접근(random access)이 가능한 자료구조에 속한다.   
메모리 주소가 연속될 것을 요구하기 때문에 배열의 크기를 늘리는 것은 절대 불가능하며, 배열의 크기를 늘릴 필요가 있을 때에는 크기가 큰 새 배열을 만들고 기존 내용을 복사하거나, 배열의 일부를 연결 리스트 등으로 다른 곳과 연결하는 등의 방법이 쓰인다.

배열에서 사용할 수 있는 연산은 보통 다음과 같다.

* 일정한 길이의 빈 배열을 만든다.
* 배열의 길이를 알아본다.
* 주어진 위치에 있는 원소를 알아본다. 원소를 찾는 데에 드는 시간은 O(1).
* 주어진 위치에 새로운 원소를 대입한다. 마찬가지로 위치를 찾는 데에 걸리는 시간은 O(1).
* 주어진 위치에 있는 원소를 삭제한다. 이때 배열의 길이가 하나 줄어들며 O(n)만큼의 시간이 걸린다.

연결 리스트와 비교하면 임의 접근이 가능하지만 요소의 삽입/삭제가 느린 단점이 있다.  
반면 연결 리스트는 순차 접근만 가능하기 때문에 임의의 위치에 있는 원소를 찾는 것은 느리지만 일단 위치를 알면 삽입/삭제는 배열에 비해 빠르다.

현대 컴퓨터 구조의 특성상(메모리 모델 자체가 일종의 커다란 배열이며 메모리 주소가 곧 인덱스나 다름없다.) 하드웨어적인 이점을 상당히 많이 갖고 있는 자료구조로(대부분의 CPU가 캐시를 적용하는 기준이 일정 크기의 연속된 메모리 영역이다.), 다른 자료구조를 구현할 때도 이런 특성을 활용해서 최적화를 하는 경우가 있다.(예: 연결 리스트를 그냥 구현하면 사용하는 메모리 영역이 사방에 흩어지는데, 메모리 풀을 구현해서 접근하는 메모리 영역의 범위를 좁혀 캐시 적중률을 높일 수 있다.)

배열의 첨자는 보통 주어진 범위 사이의 연속적인 숫자로 제한되는데, 이 제한을 없애고 임의의 값을 첨자로 쓸 수 있게 하는 대신 순서성을 포기하면 연관 배열이 된다.

### C# 예제
1차원 배열
```c#
int[] i = new int[5] { 1, 2, 3, 4, 5 };
i[2] = 5;
Console.WriteLine(i[2]);

string[] arr = new string[5];
arr[3] = "hello";
Console.WriteLine(arr[3]);
```
```
5
hello
```

2차원 배열
```c#
int[,] i = new int[3, 5];
i[1, 2] = 20;
Console.WriteLine(i[1, 2])
```
```
20
```

3차원 배열
```c#
int[,,] i = new int[3, 5, 7];
i[0, 4, 2] = 30;
Console.WriteLine(i[0, 4, 2]);
```
```
30
```

## 2.2. 연결 리스트
추상적 자료형인 리스트를 구현한 자료구조로, 어떤 데이터 덩어리(이하 노드Node)를 저장할 때 그 다음 순서의 자료가 있는 위치를 데이터에 포함시키는 방식으로 자료를 저장한다.   

### 설명
![연결 리스트 설명](/img/linked_list.webp)

배열이 A 1번, B 2번, C 3번, D 4번...식으로 자료의 순번을 맞춘다면, 연결 리스트는 A 다음 B, B 다음, C, C 다음 D...식으로 자료를 연결해놓는다.  
따라서 배열과는 달리 새로운 자료, 즉 노드를 뒤에 연결하거나 중간에 노드 몇개를 껴놓는 것이 쉽다.  
그러나 배열에서는 자료마다 번호가 있어서 특정한 자료를 불러내기가 편리한 반면, 연결 리스트는 자료 번호가 없이 그저 연결 관계만 있기 때문에 특정한 노드를 불러내기 어려운 단점이 있다.

배열에 비해 데이터의 추가/삽입 및 삭제가 용이하나 순차적으로 탐색하지 않으면 특정 위치의 요소에 접근할 수 없어 일반적으로 탐색 속도가 떨어진다.   
즉 탐색 또는 정렬을 자주 하면 배열을, 추가/삭제가 많으면 연결 리스트를 사용하는 것이 유리하다.  
단, 연결 리스트라고 해서 반드시 순차 탐색만 해야 한다는 법은 없다.  
B+tree 자료구조는 연결 리스트에 힙을 더한 것 같은 모양새를 갖고 있는데 이 자료구조는 데이터의 추가/삭제/정렬/조회 모두에 유리하다.  
단점은 그 구현의 복잡도.

또한 배열은 크기를 크게 키우기가 어려운 단점이 있다.  
연속된 메모리 공간을 할당 받아야 하는데 크기가 커지면 그만한 '연속된' 공간을 할당하기가 어려워진다.   
요즘 컴퓨터는 페이징 개념을 도입해서 메모리를 관리하기 떄문에 연속된 큰 공간을 할당하는 작업도 무리 없이 해내긴 하지만 그렇다 하더라도 배열은 자기가 안 쓰는 공간까지 전부 예약해두고 있어야 하기 떄문에 공간 낭비가 생긴다.

### 구현 방법
일반적으로 구조체와 그 포인터로 구성된다.

### 2.2.1. 단순 연결 리스트
![단순 연결 리스트](/img/singly_linked_list.webp)

다음 노드에 대한 참조만을 가진 가장 단순한 형태의 연결 리스트이다.  
가장 마지막 원소를 찾으려면 얄짤없이 리스트 끝까지 찾아가야 하기 때문에(O(n)), 마지막 원소를 가리키는 참조를 따로 가지는 형태의 변형도 있다.  
보통 큐를 구현할 때 이런 방법을 쓴다.

이 자료구조는 Head노드를 참조하는 주소를 잃어버릴 경우 데이터 전체를 못 쓰게 되는 단점이 있다.  
다음 노드를 참조하는 주소 중 하나가 잘못되는 경우에도 체인이 끊어진 거 처럼 거기부터 뒤쪽 자료들을 유실한다.  
따라서 안정적인 자료구조는 아니다.

파일 시스템 중 FAT 파일 시스템이 이 단순 연결 리스트로 파일 청크를 연결하는데 그래서 FAT 파일 시스템은 파일 내용 일부가 손상될 경우 파일의 상당 부분을 유실할 수 있고 랜던 액세스 성능도 낮다.

### 예제
```c#
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
```