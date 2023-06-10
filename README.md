# Data-structure-docs

# 목차
* [1. 개요](#1-개요)
  * [1.1. 추상적 자료형과의 관계](#11-추상적-자료형과의-관계)
* [2. 리스트](#2-리스트)
  * [2.1. 배열](#21-배열)
  * [2.2. 연결 리스트](#22-연결-리스트)
    * [2.2.1. 단순 연결 리스트](#221-단순-연결-리스트)
    * [2.2.2. 이중 연결 리스트](#222-이중-연결-리스트)
    * [2.2.3. 순환 연결 리스트](#223-순환-연결-리스트)
* [3. 스택](#3-스택)
* [4. 큐](#4-큐)
  * [4.1. 단순 큐](#41-단순-큐)
  * [4.2. 원형 큐](#42-원형-큐)
  * [4.3. 덱](#43-덱)
  * [4.4. 우선순위 큐](#44-우선순위-큐)
* [5. 그래프](#5-그래프)
  * [5.1. 무향 그래프](#51-무향-그래프)
  * [5.2. 유향 그래프](#52-유향-그래프)
  * [5.3. 가중 그래프](#53-가중-그래프)
  * [5.4. 완전 그래프](#54-완전-그래프)

# 1. 개요
컴퓨터과학에서 데이터를 구조적으로 표현하는 방식과 이를 구현하는 데 필요한 알고리즘에 대해 논하는 기초이론, 혹은 과목이다.  
컴퓨터과학에서 알고리즘과 함께 가장 중요한 기초이론이다.  

컴퓨터의 메모리는 1차원 구조이기 때문에(메모리 하드웨어는 2차원 또는 3차원 구조이지만 CPU에서 논리적으로 바라보는 메모리 공간은 1차원이다.) 현실 세계의 다차원 데이터를 다루기 위해서는 이것을 1차원인 선 형태로 바꾸는 것이 필요하다.  

# 1.1. 추상적 자료형과의 관계
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

# 2.1. 배열
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

## C# 예제
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

# 2.2. 연결 리스트
추상적 자료형인 리스트를 구현한 자료구조로, 어떤 데이터 덩어리(이하 노드Node)를 저장할 때 그 다음 순서의 자료가 있는 위치를 데이터에 포함시키는 방식으로 자료를 저장한다.   

## 설명
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

## 구현 방법
일반적으로 구조체와 그 포인터로 구성된다.

# 2.2.1. 단순 연결 리스트
![단순 연결 리스트](/img/singly_linked_list.webp)

다음 노드에 대한 참조만을 가진 가장 단순한 형태의 연결 리스트이다.  
가장 마지막 원소를 찾으려면 얄짤없이 리스트 끝까지 찾아가야 하기 때문에(O(n)), 마지막 원소를 가리키는 참조를 따로 가지는 형태의 변형도 있다.  
보통 큐를 구현할 때 이런 방법을 쓴다.

이 자료구조는 Head노드를 참조하는 주소를 잃어버릴 경우 데이터 전체를 못 쓰게 되는 단점이 있다.  
다음 노드를 참조하는 주소 중 하나가 잘못되는 경우에도 체인이 끊어진 거 처럼 거기부터 뒤쪽 자료들을 유실한다.  
따라서 안정적인 자료구조는 아니다.

파일 시스템 중 FAT 파일 시스템이 이 단순 연결 리스트로 파일 청크를 연결하는데 그래서 FAT 파일 시스템은 파일 내용 일부가 손상될 경우 파일의 상당 부분을 유실할 수 있고 랜던 액세스 성능도 낮다.

## 구현
```c#
public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }

  public Node(T data)
  {
    this.Data = data;
  }
}
```
노드 클래스는 제네릭 타입의 데이터와 다음 노드를 참조하는 변수를 필드로 가진다.   
생성자를 통해 노드 객체 생성 시 매개변수로 받은 data를 Data로 가지고, 다음 노드를 참조하는 변수는 null인 상태가 된다.

```c#
public class SinglyLinkedList<T>
{
  public Node<T> Head;
  public Node<T> Tail;
  public int Length = 0;
  // ...
}
```
연결 리스트 클래스는 머리 노드와 꼬리 노드, 연결 리스트의 길이를 저장하는 변수를 필드로 가진다.     
머리 노드는 연결 리스트의 시작 노드를, 꼬리 노드는 연결 리스트의 마지막 노드를 참조한다.    
길이 변수는 index 값 유효 검증, 노드가 한 개일 경우(Head = Tail)의 예외 처리, 노드의 길이 출력 등에 쓰인다.

```c#
// ...
private bool IsInvalidIndex(int index)
{
  if (0 > index || getLength() - 1 < index)
  {
    return false;
  }
  else
  {
    return true;
  }
}
// ...
```
연결 리스트 클래스 내부에서만 사용할 인덱스 유효 확인 함수를 작성한다.  
매개변수 index의 값이 0보다 미만이거나, 현재 연결 리스트 길이(0부터 번호 매김)를 초과하는지 확인 후 index 값이 유효하지 않을 경우 false를 반환한다.

```c#
// ...
public bool IsEmpty()
{
  if (Head == null || Tail == null || Length == 0)
  {
    return true;
  }
  else
  {
    return false;
  }
}
// ...
```
연결 리스트의 비어 있는지 확인하는 함수를 작성한다.     
머리 노드, 꼬리 노드가 아무 노드도 참조하고 있지 않거나 연결 리스트의 길이가 0이면 노드가 존재하지 않는 것으로 취급하여 true를 반환하고 그렇지 않을 경우 노드가 한 개 이상 존재하는 것으로 취급하고 false를 반환한다.     
노드 추가, 노드 삭제, 노드 검색 등 함수에서 비어 있는 연결 리스트 예외처리에 사용된다.

```c#
// ...
public void Add(T data)
{
  Node<T> newNode = new Node<T>(data);

  if (IsEmpty())
  {
    Head = newNode;
    Tail = newNode;
    Length = 1;
  }
  else
  {
    if (Length == 1)
    {
      Tail = newNode;
      Head.NextNode = Tail;
    }
    else
    {
      Tail.NextNode = newNode;
      Tail = newNode;
    }
    Length++;
  }
}
// ...
```
연결 리스트의 가장 마지막에 새 노드를 추가하는 함수를 작성한다.     
매개변수 data로 새로운 노드 객체를 생성하고 현재 리스트가 비어 있으면 새로운 노드는 머리이자 꼬리 노드가 된다(Head, Tail 둘 다 새 노드 객체를 참조).  
현재 노드가 한 개일 경우(Head = Tail) 새로 삽입한 노드가 꼬리 노드가 되고, 머리 노드의 다음 노드는 꼬리 노드가 된다.    
일반적인 경우엔 현재 꼬리 노드는 다음 노드로 새 노드를 참조하고, 리스트의 꼬리 노드를 가리키는 Tail은 새 노드를 참조하게 된다.

```c#
// ...
public bool AddBefore(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    return false;
  }
  else
  {
    Node<T> newNode = new Node<T>(data);
    Node<T> beforeNode = null;
    Node<T> targetNode = Head;

    for (int i = 0; i < index; i++)
    {
      beforeNode = targetNode;
      targetNode = targetNode.NextNode;
    }

    if (targetNode == Head)
    {
      newNode.NextNode = Head;
      Head = newNode;
    }
    else
    {
      beforeNode.NextNode = newNode;
      newNode.NextNode = targetNode;
    }
    Length++;
    return true;
  }
}
// ...
```
원하는 노드 위치의 이전에 새 노드를 추가하는 함수를 작성한다.   
매개변수 index가 유효한지 검사 후 유효한 하지 않은 경우 동작을 실행할 수 없다는 의미의 false를 반환한다.    
유효한 경우 매개변수 data로 새 노드 객체를 생성하고 타겟 노드와 이전 노드를 검색한다.   
만약 타겟 노드가 머리 노드라면 새 노드를 머리 노드로 교체하는 작업이 필요하기 때문에 새 노드의 다음 노드가 현재 머리 노드를 참조하도록 하고, 연결 리스트의 머리 노드는 새 노드를 참조하도록 한다.     
일반적인 경우엔 이전 노드가 다음 노드로 새 노드를 참조하도록 하고, 새 노드가 다음 노드로 타겟 노드를 참조하도록 한다.

```c#
// ...
public bool AddAfter(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    return false;
  }
  else
  {
    Node<T> newNode = new Node<T>(data);
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
    Length++;
    return true;
  }
}
// ...
```
원하는 노드 위치의 다음에 새 노드를 추가하는 함수를 작성한다.   
매개변수 index가 유효한지 검사 후 유효한 하지 않은 경우 동작을 실행할 수 없다는 의미의 false를 반환한다.    
유효한 경우 매개변수 data로 새 노드 객체를 생성하고 타겟 노드를 검색한다.   
만약 타겟 노드가 꼬리 노드라면 새 노드를 꼬리 노드로 교체하는 작업이 필요하기 때문에 꼬리 노드의 다음 노드가 새 노드를 참조하도록 하고, 연결 리스트의 꼬리 노드는 새 노드를 참조하도록 한다.     
일반적인 경우엔 새 노드가 다음 노드로 타겟 노드의 다음 노드를 참조하도록 하고, 타겟 노드가 다음 노드로 새 노드를 참조하도록 한다.

```c#
// ...
public bool Remove(int index)
{
  if (IsEmpty() || !IsInvalidIndex(index))
  {
    return false;
  }
  else
  {
    Node<T> beforeNode = null;
    Node<T> targetNode = Head;

    for (int i = 0; i < index; i++)
    {
      beforeNode = targetNode;
      targetNode = targetNode.NextNode;
    }

    if (Length == 1)
    {
      Head = null;
      Tail = null;
    }
    else if (targetNode == Head)
    {
      Head = Head.NextNode;
      targetNode = null;
    }
    else if (targetNode == Tail)
    {
      Tail = beforeNode;
      Tail.NextNode = null;
      targetNode = null;
    }
    else
    {
      beforeNode.NextNode = targetNode.NextNode;
      targetNode = null;
    }
    Length--;
    return true;
  }
}
// ...
```
원하는 위치의 노드를 삭제하는 함수를 작성한다.  
노드가 비어 있는지, 유효한 index인지 확인 후 Remove 작업을 실행할 수 없을 경우 false를 반환한다.    
타겟 노드와 이전 노드를 검색하고 노드가 한 개 뿐일 경우 머리 노드와 꼬리 노드의 참조를 없앰으로써 연결 리스트를 비운다.     
타겟 노드가 머리 노드일 경우 연결 리스트의 머리 노드 변수는 현재 머리 노드의 다음 노드를 참조하도록 변경하고, 타겟 노드의 참조를 해제함으로써 가비지컬렉터가 메모리 할당을 해제할 기회를 제공한다.
타겟 노드가 꼬리 노드일 경우 연결 리스트의 꼬리 노드 변수는 현재 꼬리 노드의 이전 노드를 참조하도록 변경하고, 타겟 노드와 꼬리 노드의 다음 노드 참조를 해제함으로써 가비지컬렉터가 메모리 할당을 해제할 기회를 제공한다.  
일반적인 경우엔 이전 노드의 다음 노드 변수가 타겟 노드의 다음 노드를 참조하도록 하고, 마찬가지로 타겟 노드의 참조를 해제한다.

```c#
// ...
public Node<T> Peek()
{
  return Head;
}

public int GetLength()
{
  return Length;
}

public Node<T> GetNode(int index)
{
  if (IsEmpty() || !IsInvalidIndex(index))
  {
    return null;
  }
  else
  {
    Node<T> targetNode = Head;

    for (int i = 0; i < index; i++)
    {
      targetNode = targetNode.NextNode;
    }

    return targetNode;
  }
}
// ...
```
연결 리스트의 첫 번째 노드를 반환하는 함수와 연결 리스트의 길이를 반환하는 함수, 특정 노드를 검색하고 반환하는 함수를 작성한다.     
노드 검색 전 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인한다.  
머리 노드부터 시작해서 현재 노드의 다음 노드 참조로 변수 값을 업데이트 하면서 검색 후 반환한다.

[파일](/sample_code/SinglyLinkedList.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체
  public T Value { get; set; }
  public Node<T> NextNode { get; set; }

  // 생성자
  public Node(T value)
  {
    this.Value = value;
  }
}

// 연결 리스트 클래스
public class SinglyLinkedList<T>
{
  // 머리 노드, 꼬리 노드, 연결 리스트 길이
  public Node<T> Head;
  public Node<T> Tail;
  public int Length = 0;

  // 인덱스 값이 유효한지 확인
  private bool IsInvalidIndex(int index)
  {
    // 인덱스가 0 미만이거나,
    // 연결 리스트 길이를 초과할 경우 false 반환
    if (0 > index || getLength() - 1 < index)
    {
      return false;
    }
    else
    {
      return true;
    }
  }

  // 연결 리스트가 비어 있는지 확인
  public bool IsEmpty()
  {
    // 머리 노드가 존재하지 않거나,
    // 꼬리 노드가 존재하지 않거나,
    // 연결 리스트에 노드가 존재하지 않을 시 true 반환
    if (Head == null || Tail == null || Length == 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 꼬리 노드 다음에 새로운 노드 추가
  public void Add(T value)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(value);

    // 연결 리스트가 비어 있는지 확인
    if (IsEmpty())
    {
      // 새로운 노드는 머리 노드이자 꼬리 노드가 된다
      Head = newNode;
      Tail = newNode;
      Length = 1;
    }
    else
    {
      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 새로운 노드는 꼬리 노드가 되고,
        // 머리 노드의 다음 노드는 꼬리 노드가 된다
        Tail = newNode;
        Head.NextNode = Tail;
      }
      else
      {
        // 새로운 노드는 꼬리 노드의 다음 노드가 되고,
        // 새로운 노드는 꼬리 노드가 된다
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      Length++;
    }
  }

  // 지정한 노드 다음에 새로운 노드 추가
  public bool AddBefore(int index, T value)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 이전 노드, 지정한 노드
      Node<T> newNode = new Node<T>(value);
      Node<T> beforeNode = null;
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        beforeNode = targetNode;
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 머리 노드일 경우 실행
      if (targetNode == Head)
      {
        // 머리 노드는 새로운 노드의 다음 노드가 되고,
        // 새로운 노드는 머리 노드가 된다
        newNode.NextNode = Head;
        Head = newNode;
      }
      else
      {
        // 새로운 노드는 이전 노드의 다음 노드가 되고,
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        beforeNode.NextNode = newNode;
        newNode.NextNode = targetNode;
      }
      Length++;
      return true;
    }
  }

  // 지정한 노드 이전에 새로운 노드 추가
  public bool AddAfter(int index, T value)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드
      Node<T> newNode = new Node<T>(value);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 꼬리 노드일 경우 실행
      if (targetNode == Tail)
      {
        // 새로운 노드는 꼬리 노드의 다음 노드가 되고,
        // 새로운 노드는 꼬리가 된다
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      else
      {
        // 지정한 노드의 다음 노드는 새로운 노드의 다음 노드가 되고,
        // 새로운 노드는 지정한 노드의 다음 노드가 된다
        newNode.NextNode = targetNode.NextNode;
        targetNode.NextNode = newNode;
      }
      Length++;
      return true;
    }
  }

  // 지정한 노드 삭제
  public bool Remove(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 이전 노드, 지정한 노드
      Node<T> beforeNode = null;
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        beforeNode = targetNode;
        targetNode = targetNode.NextNode;
      }

      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 머리 노드, 꼬리 노드 참조 해제
        Head = null;
        Tail = null;
      }
      // 지정한 노드가 머리 노드일 경우 실행
      else if (targetNode == Head)
      {
        // 머리 노드의 다음 노드는 머리 노드가 되고,
        // 지정한 노드의 참조를 해제한다
        Head = Head.NextNode;
        targetNode = null;
      }
      else if (targetNode == Tail)
      {
        // 꼬리 노드의 이전 노드는 꼬리 노드가 되고,
        // 꼬리 노드의 다음 노드와 지정 노드의 참조를 해제한다
        Tail = beforeNode;
        Tail.NextNode = null;
        targetNode = null;
      }
      else
      {
        // 지정한 노드의 다음 노드는 이전 노드의 다음 노드가 되고,
        // 지정한 노드의 참조를 해제한다
        beforeNode.NextNode = targetNode.NextNode;
        targetNode = null;
      }
      Length--;
      return true;
    }
  }

  // 첫 노드를 반환
  public Node<T> Peek()
  {
    return Head;
  }

  // 연결 리스트의 길이를 반환
  public int getLength()
  {
    return Length;
  }

  // 지정한 노드를 반환
  public Node<T> getNode(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return null;
    }
    else
    {
      // 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드 반환
      return targetNode;
    }
  }
}
```
</details>

# 2.2.2. 이중 연결 리스트
![이중 연결 리스트](/img/doubly_linked_list.webp)

다음 노드의 참조뿐만 아니라 이전 노드의 참조도 같이 가리키게 하면 이중 연결 리스트가 된다.  
뒤로 탐색하는 게 빠르다는 단순한 장점 이외에도 한 가지 장점이 더 있는데, 단순 연결 리스트는 현재 가리키고 있는 노드를 삭제하는 게 한 번에 안 되고 O(n)이 될 수밖에 없는데 비해('현재' 노드를 삭제하기 위해서는 '이전' 노드가 가리키는 다음 공간이 '다음' 노드가 되도록 설정해야 한다. 즉, '현재' 노드를 삭제하면서 '현재' 노드의 위치에 '다음' 노드를 위치시켜야 된다는 의미다.) 이중 연결 리스트에서 현재 노드를 삭제하는 것은 훨씬 간단하다.  
대신 관리해야 할 참조가 두 개나 있기 때문에 삽입이나 정렬의 경우 작업량이 더 많고 자료구조의 크기가 약간 더 커진다.

단일 연결 리스트보다는 손상에 강한 편이다.  
Head와 Tail노드를 갖고 있다면 둘 중 하나를 가지고 전체 리스트를 순회할 수 있기 때문에 끊어진 체인을 복구하는 게 가능하다.   
단일 연결 리스트는 Tail노드로는 리스트 순회가 불가능하고 Head노드 유실시 전체 자료를 다 잃어버린다.     
단점은 이런 보정 알고리즘을 구현하지 않았을 경우에는 오히려 손상에 더 취약해진다는 것이다.
예를 들어 next포인터는 갱신을 했는데 prev포인터는 갱신하지 않았을 경우 prev포인터를 따라가는 순회에서 도달 불가능한 '잃어버린' 노드가 발생한다.

## 구현
```c#
public class Node<T>
{
  // ...
  public Node<T> PrevNode { get; set; }
  // ...
}
```
기존 노드 클래스에서 이전 노드 참조를 위한 변수인 PrevNode 필드를 추가한다.

```c#
// ...
public void Add(T data)
{
  // ...
  if (IsEmpty())
  {
    // ...
  }
  else
  {
    if (Length == 1)
    {
      // ...
      Tail.PrevNode = Head;
    }
    else
    {
      // ...
      newNode.PrevNode = Tail;
      // ...
    }
    // ...
  }
}
// ...
```
단일 연결 리스트의 Add 함수에서 노드가 실제로 추가될 경우 이전 노드 참조 동작을 수행하도록 변경한다.

```c#
// ...
public bool AddBefore(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    Node<T> newNode = new Node<T>(data);
    Node<T> targetNode = Head;

    for (int i = 0; i < index; i++)
    {
      targetNode = targetNode.NextNode;
    }

    if (targetNode == Head)
    {
      newNode.NextNode = Head;
      Head.PrevNode = newNode;
      Head = newNode;
    }
    else
    {
      targetNode.PrevNode.NextNode = newNode;
      newNode.NextNode = targetNode;
      newNode.PrevNode = targetNode.PrevNode;
    }
  }
  Length++;
  return true;
}
// ...
```
이전 노드 참조 변수를 따로 저장하지 않아도 PrevNode 멤버 변수로 이전 노드를 참조할 수 있기 때문에 기존 AddBefore 함수에서 지정 노드와 이전 노드를 둘 다 저장하던 방식을 지정 노드만 검색하는 방식으로 변경한다.   
노드 추가 작업을 할 경우 새 노드의 이전 노드 필드가 지정 노드의 이전 노드를 참조하는 기능을 추가한다.

```c#
// ...
public bool AddAfter(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    // ...

    if (targetNode == Tail)
    {
      newNode.PrevNode = Tail;
      // ...
    }
    else
    {
      newNode.PrevNode = targetNode;
      // ...
    }
    // ...
  }
}
// ...
```
기존 AddAfter 함수에서 노드를 추가할 때 새 노드의 이전 노드가 지정 노드를 참조하는 기능을 추가한다.

```c#
// ...
public bool Remove(int index)
{
  if (IsEmpty() || !IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    Node<T> targetNode = Head;

    for (int i = 0; i < index; i++)
    {
      targetNode = targetNode.NextNode;
    }

    if (Length == 1)
    {
      // ...
    }
    else if (targetNode == Head)
    {
      Head = Head.NextNode;
      Head.PrevNode = null;
      targetNode = null;
    }
    else if (targetNode == Tail)
    {
      Tail = Tail.PrevNode;
      Tail.NextNode = null;
      targetNode = null;
    }
    else
    {
      targetNode.PrevNode.NextNode = targetNode.NextNode;
      targetNode.NextNode.PrevNode = targetNode.PrevNode;
      targetNode = null;
    }
    Length--;
    return true;
  }
}
// ...
```
PrevNode 의 존재로 이전 노드를 검색할 필요가 없으므로 beforeNode 변수를 삭제하고 대신 targetNode.PrevNode 가 기존 기능을 수행한다.  
머리 노드와 꼬리 노드를 삭제할 때 각각 노드를 두 번째, 마지막 전 노드로 교체한 후 이전, 다음 노드의 참조를 null로 변경한다.   
일반적인 경우 지정 노드의 이전 노드가 다음 노드로 지정 노드의 다음 노드를 참조하도록 하고, 지정 노드의 다음 노드가 이전 노드로 지정 노드의 이전 노드를 참조한 후 지정 노드의 참조를 해제하여 메모리에서 지정 노드를 삭제하는 동시에 지정 노드 앞 뒤 노드를 연결한다.

[파일](/sample_code/DoublyLinkedList.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체, 이전 노드 객체
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생성자
  public Node(T data)
  {
    this.Data = data;
  }
}

// 연결 리스트 클래스
public class DoubleLinkedList<T>
{
  // 머리 노드, 꼬리 노드, 연결 리스트 길이
  public Node<T> Head { get; set; }
  public Node<T> Tail { get; set; }
  public int Length = 0;

  // 인덱스 값이 유효한지 확인
  private bool IsInvalidIndex(int index)
  {
    // 인덱스가 0 미만이거나,
    // 연결 리스트 길이를 초과할 경우 false 반환
    if (0 > index || GetLength() - 1 < index)
    {
      return false;
    }
    else
    {
      return true;
    }
  }


  // 연결 리스트가 비어 있는지 확인
  public bool IsEmpty()
  {
    // 머리 노드가 존재하지 않거나,
    // 꼬리 노드가 존재하지 않거나,
    // 연결 리스트에 노드가 존재하지 않을 시 true 반환
    if (Head == null || Tail == null || Length <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 꼬리 노드 다음에 새로운 노드 추가
  public void Add(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 연결 리스트가 비어 있는지 확인
    if (IsEmpty())
    {
      // 새로운 노드는 머리 노드이자 꼬리 노드가 된다
      Head = newNode;
      Tail = newNode;
      Length = 1;
    }
    else
    {
      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 새로운 노드는 꼬리 노드가 된다
        // 머리 노드의 다음 노드는 꼬리 노드가 된다
        // 꼬리 노드의 이전 노드는 머리 노드가 된다
        Tail = newNode;
        Head.NextNode = Tail;
        Tail.PrevNode = Head;
      }
      else
      {
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드의 이전 노드는 꼬리 노드가 된다
        // 새로운 노드는 꼬리 노드가 된다
        Tail.NextNode = newNode;
        newNode.PrevNode = Tail;
        Tail = newNode;
      }
      Length++;
    }
  }

  // 지정한 노드 다음에 새로운 노드 추가
  public bool AddBefore(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드 생성
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 머리 노드일 경우 실행
      if (targetNode == Head)
      {
        // 머리 노드는 새로운 노드의 다음 노드가 된다
        // 새로운 노드는 머리 노드의 이전 노드가 된다
        // 새로운 노드는 머리 노드가 된다
        newNode.NextNode = Head;
        Head.PrevNode = newNode;
        Head = newNode;
      }
      else
      {
        // 새로운 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 새로운 노드의 이전 노드가 된다
        targetNode.PrevNode.NextNode = newNode;
        newNode.NextNode = targetNode;
        newNode.PrevNode = targetNode.PrevNode;
      }
    }
    Length++;
    return true;
  }

  // 지정한 노드 이전에 새로운 노드 추가
  public bool AddAfter(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 꼬리 노드일 경우 실행
      if (targetNode == Tail)
      {
        // 꼬리 노드는 새로운 노드의 이전 노드가 된다
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드는 꼬리가 된다
        newNode.PrevNode = Tail;
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      else
      {
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 다음 노드는 새로운 노드의 다음 노드가 된다
        // 새로운 노드는 지정한 노드의 다음 노드가 된다
        newNode.PrevNode = targetNode;
        newNode.NextNode = targetNode.NextNode;
        targetNode.NextNode = newNode;
      }
      Length++;
      return true;
    }
  }

  // 지정한 노드 삭제
  public bool Remove(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 이전 노드, 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 머리 노드, 꼬리 노드 참조 해제
        Head = null;
        Tail = null;
      }
      // 지정한 노드가 머리 노드일 경우 실행
      else if (targetNode == Head)
      {
        // 머리 노드의 다음 노드는 머리 노드가 된다
        // 머리 노드의 이전 노드 참조를 해제한다
        // 지정한 노드의 참조를 해제한다
        Head = Head.NextNode;
        Head.PrevNode = null;
        targetNode = null;
      }
      // 지정한 노드가 꼬리 노드일 경우 실행
      else if (targetNode == Tail)
      {
        // 꼬리 노드의 이전 노드는 꼬리 노드가 된다
        // 꼬리 노드의 다음 노드 참조를 해제한다
        // 지정한 노드의 참조를 해제한다
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        targetNode = null;
      }
      else
      {
        // 지정한 노드의 다음 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 다음 노드의 이전 노드가 된다
        // 지정한 노드의 참조를 해제한다
        targetNode.PrevNode.NextNode = targetNode.NextNode;
        targetNode.NextNode.PrevNode = targetNode.PrevNode;
        targetNode = null;
      }
      Length--;
      return true;
    }
  }

  // 첫 노드를 반환
  public Node<T> Peek()
  {
    return Head;
  }

  // 연결 리스트의 길이를 반환
  public int GetLength()
  {
    return Length;
  }

  // 지정한 노드를 반환
  public Node<T> GetNode(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return null;
    }
    else
    {
      // 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드 반환
      return targetNode;
    }
  }
}
```
</details>

# 2.2.3. 순환 연결 리스트
![순환 연결 리스트](/img/circular_linked_list.webp)

단순 연결 리스트에서 마지막 원소가 null 대신 처음 원소를 가리키게 하면 순환 연결 리스트가 된다.   
이와 비슷하게, 순환 연결 리스트의 처음과 끝을 서로 이으면 이중 순환 연결 리스트를 만들 수 있다.

스트림 버퍼의 구현에 많이 사용한다.   
이미 할당된 메모리 공간을 삭제하고 재할당하는 부담이 없기 때문에 큐를 구현하는 데에도 적합하다.

## 구현
```c#
// ...
public void Add(T data)
{
  // ...

  if (IsEmpty())
  {
    newNode.NextNode = newNode;
    newNode.PrevNode = newNode;
    // ...
  }
  else
  {
    if (Length == 1)
    {
      // ...
      Head.PrevNode = Tail;
      Tail.NextNode = Head;
      // ...
    }
    else
    {
      // ...
      newNode.NextNode = Head;
      // ...
    }
    Length++;
  }
}
// ...
```
기존 이중 연결 리스트의 Add 함수에서 Head와 Tail의 연결 동작을 추가한다.   
첫 번째 노드 생성의 경우 새 노드의 이전, 다음 노드로 자기 자신을 참조하도록 한다.   
두 번째 노드 생성의 경우 기존의 Head와 Tail 분리 작업 동시에 Head는 이전 노드로 Tail을 참조하고, Tail은 다음 노드로 Head를 참조하도록 한다.   
일반적인 경우엔 Tail이 될 새 노드의 다음 노드로 Head를 참조하도록 한다.

```c#
// ...
public bool AddBefore(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    // ...

    for (int i = 0; i < index; i++)
    {
      // ...
    }

    if (targetNode == Head)
    {
      // ...
      newNode.PrevNode = Tail;
      // ...
    }
    else
    {
      // ...
    }
  }
  // ...
}
// ...
```
기존 이중 연결 리스트의 AddBefore 함수에서 지정 노드가 Head일 경우, 새로 추가될 노드(Head가 될 노드)가 이전 노드로 Tail을 참조하도록 한다.

```c#
// ...
public bool AddAfter(int index, T data)
{
  if (!IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    // ...

    for (int i = 0; i < index; i++)
    {
      // ...
    }

    if (targetNode == Tail)
    {
      // ...
      newNode.NextNode = Head;
      // ...
    }
    else
    {
      // ...
    }
    // ...
  }
}
// ...
```
기존 이중 연결 리스트의 AddAfter 함수에서 지정 노드가 Tail일 경우, 새로 추가될 노드(Tail이 될 노드)가 다음 노드로 Head를 참조하도록 한다.

```c#
// ...
public bool Remove(int index)
{
  if (IsEmpty() || !IsInvalidIndex(index))
  {
    // ...
  }
  else
  {
    // ...

    for (int i = 0; i < index; i++)
    {
      // ...
    }

    if (Length == 1)
    {
      // ...
    }
    else if (targetNode == Head)
    {
      Head = Head.NextNode;
      Head.PrevNode = Tail;
      targetNode = null;
    }
    else if (targetNode == Tail)
    {
      Tail = Tail.PrevNode;
      Tail.NextNode = Head;
      targetNode = null;
    }
    else
    {
      // ...
    }
    // ...
  }
}
// ...
```
기존 이중 연결 리스트의 Remove 함수에서 지정 노드가 Head, Tail일 경우의 동작을 수정한다.  
기존에 새로 Head, Tail이 된 노드의 이전, 다음 노드 참조를 해제하던 동작을 Head일 경우 이전 노드로 Tail을 참조하고 Tail일 경우 다음 노드로 Head를 참조하도록 수정한다.

[파일](/sample_code/CircularLinkedList.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체, 이전 노드 객체
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생성자
  public Node(T data)
  {
    this.Data = data;
  }
}

// 연결 리스트 클래스
public class CircularLinkedList<T>
{
  // 머리 노드, 꼬리 노드, 연결 리스트 길이
  public Node<T> Head { get; set; }
  public Node<T> Tail { get; set; }
  public int Length = 0;

  // 인덱스 값이 유효한지 확인
  private bool IsInvalidIndex(int index)
  {
    // 인덱스가 0 미만이거나,
    // 연결 리스트 길이를 초과할 경우 false 반환
    if (0 > index || GetLength() - 1 < index)
    {
      return false;
    }
    else
    {
      return true;
    }
  }


  // 연결 리스트가 비어 있는지 확인
  public bool IsEmpty()
  {
    // 머리 노드가 존재하지 않거나,
    // 꼬리 노드가 존재하지 않거나,
    // 연결 리스트에 노드가 존재하지 않을 시 true 반환
    if (Head == null || Tail == null || Length <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 꼬리 노드 다음에 새로운 노드 추가
  public void Add(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 연결 리스트가 비어 있는지 확인
    if (IsEmpty())
    {
      // 새로운 노드는 이전, 다음 노드로 자기 자신을 참조한다
      // 새로운 노드는 머리 노드이자 꼬리 노드가 된다
      newNode.NextNode = newNode;
      newNode.PrevNode = newNode;
      Head = newNode;
      Tail = newNode;
      Length = 1;
    }
    else
    {
      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 새로운 노드는 꼬리 노드가 된다
        // 머리 노드의 다음, 이전 노드는 꼬리 노드가 된다
        // 꼬리 노드의 다음, 이전 노드는 머리 노드가 된다
        Tail = newNode;
        Head.NextNode = Tail;
        Head.PrevNode = Tail;
        Tail.NextNode = Head;
        Tail.PrevNode = Head;
      }
      else
      {
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드의 다음 노드는 머리 노드가 된다
        // 새로운 노드의 이전 노드는 꼬리 노드가 된다
        // 새로운 노드는 꼬리 노드가 된다
        Tail.NextNode = newNode;
        newNode.NextNode = Head;
        newNode.PrevNode = Tail;
        Tail = newNode;
      }
      Length++;
    }
  }

  // 지정한 노드 다음에 새로운 노드 추가
  public bool AddBefore(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드 생성
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 머리 노드일 경우 실행
      if (targetNode == Head)
      {
        // 머리 노드는 새로운 노드의 다음 노드가 된다
        // 꼬리 노드는 새로운 노드의 이전 노드가 된다
        // 새로운 노드는 머리 노드의 이전 노드가 된다
        // 새로운 노드는 머리 노드가 된다
        newNode.NextNode = Head;
        newNode.PrevNode = Tail;
        Head.PrevNode = newNode;
        Head = newNode;
      }
      else
      {
        // 새로운 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 새로운 노드의 이전 노드가 된다
        targetNode.PrevNode.NextNode = newNode;
        newNode.NextNode = targetNode;
        newNode.PrevNode = targetNode.PrevNode;
      }
    }
    Length++;
    return true;
  }

  // 지정한 노드 이전에 새로운 노드 추가
  public bool AddAfter(int index, T data)
  {
    // 인덱스 값이 유효한지 확인
    if (!IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 새로운 노드 생성
      // 지정한 노드
      Node<T> newNode = new Node<T>(data);
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드가 꼬리 노드일 경우 실행
      if (targetNode == Tail)
      {
        // 머리 노드는 새로운 노드의 다음 노드가 된다
        // 꼬리 노드는 새로운 노드의 이전 노드가 된다
        // 새로운 노드는 꼬리 노드의 다음 노드가 된다
        // 새로운 노드는 꼬리가 된다
        newNode.NextNode = Head;
        newNode.PrevNode = Tail;
        Tail.NextNode = newNode;
        Tail = newNode;
      }
      else
      {
        // 지정한 노드는 새로운 노드의 다음 노드가 된다
        // 지정한 노드의 다음 노드는 새로운 노드의 다음 노드가 된다
        // 새로운 노드는 지정한 노드의 다음 노드가 된다
        newNode.PrevNode = targetNode;
        newNode.NextNode = targetNode.NextNode;
        targetNode.NextNode = newNode;
      }
      Length++;
      return true;
    }
  }

  // 지정한 노드 삭제
  public bool Remove(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return false;
    }
    else
    {
      // 이전 노드, 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 연결 리스트에 노드가 한 개일 경우 실행
      if (Length == 1)
      {
        // 머리 노드, 꼬리 노드 참조 해제
        Head = null;
        Tail = null;
      }
      // 지정한 노드가 머리 노드일 경우 실행
      else if (targetNode == Head)
      {
        // 머리 노드의 다음 노드는 머리 노드가 된다
        // 머리 노드는 꼬리 노드를 이전 노드로 참조한다
        // 지정한 노드의 참조를 해제한다
        Head = Head.NextNode;
        Head.PrevNode = Tail;
        targetNode = null;
      }
      // 지정한 노드가 꼬리 노드일 경우 실행
      else if (targetNode == Tail)
      {
        // 꼬리 노드의 이전 노드는 꼬리 노드가 된다
        // 꼬리 노드의 머리 노드를 다음 노드로 참조한다
        // 지정한 노드의 참조를 해제한다
        Tail = Tail.PrevNode;
        Tail.NextNode = Head;
        targetNode = null;
      }
      else
      {
        // 지정한 노드의 다음 노드는 이전 노드의 다음 노드가 된다
        // 지정한 노드의 이전 노드는 다음 노드의 이전 노드가 된다
        // 지정한 노드의 참조를 해제한다
        targetNode.PrevNode.NextNode = targetNode.NextNode;
        targetNode.NextNode.PrevNode = targetNode.PrevNode;
        targetNode = null;
      }
      Length--;
      return true;
    }
  }

  // 첫 노드를 반환
  public Node<T> Peek()
  {
    return Head;
  }

  // 연결 리스트의 길이를 반환
  public int GetLength()
  {
    return Length;
  }

  // 지정한 노드를 반환
  public Node<T> GetNode(int index)
  {
    // 연결 리스트가 비어 있는지, 인덱스 값이 유효한지 확인
    if (IsEmpty() || !IsInvalidIndex(index))
    {
      return null;
    }
    else
    {
      // 지정한 노드
      Node<T> targetNode = Head;

      // 노드 검색
      for (int i = 0; i < index; i++)
      {
        targetNode = targetNode.NextNode;
      }

      // 지정한 노드 반환
      return targetNode;
    }
  }
}
```
</details>

# 3. 스택
![스택](/img/stack.webp)

후입선출(Last In First Out, LIFO) 특성을 가지는 자료구조(Data Structure)를 일컫는다.   
메모리에 새로 들어오는 데이터의 위치가 메모리 말단(일명 '탑 포인터')이고, 써먹기 위해 내보내는 데이터 역시 메모리 말단을 거친다.  
스택의 추상자료형(Abstract Data Type-ADT)을 살펴보면, 입력 연산은 푸시(Push), 출력 연산은 팝(Pop)이라고 부른다.   
조회 연산은 피크(Peek)라고 하는데, 탑 포인터가 가리키는 데이터를 조회(확인)만 할 뿐, 탑의 순번(인덱스-Index)은 변화시키지 않는 연산을 의미한다.

스택의 역사를 짚어 보면 1946년 앨런 튜링(Alan Turing)까지 거슬러 올라간다.  
당시 앨런 튜링은 서브루틴을 호출하는 과정을 베리(bury), 되돌아오는 과정을 언베리(unbury)라고 불렀는데, 이것을 스택의 기원이라고도 한다.   
스택은 콜 스택(Call Stack)이라 하여 컴퓨터 프로그램의 서브루틴에 대한 정보를 저장하는 자료구조에도 널리 활용된다.   
컴파일러가 출력하는 에러도 스택처럼 맨 마지막 에러가 가장 먼저 출력되는 순서를 보인다.  
또한 스택은 메모리 영역에서 LIFO 형태로 할당하고 접근하는 구조인 아키텍처 레벨의 하드웨어 스택의 이름으로도 널리 사용된다.  
이외에도 꽉 찬 스택에 요소를 삽입하고자 할 때 스택에 요소가 넘쳐서 에러가 발생하는 것을 스택 버퍼 오버플로우(Stack Buffer Overflow)라고 부른다.

스택은 힙 영역 메모리에서 일반적인 데이터를 저장하는 스택과 스택 영역 메모리에서 프로그램의 각 분기점에 변수와 같은 정보를 저장하기 위한 스택이라는 두 가지 의미로 사용될 수 있으므로 유의해야 한다.

## 구현 방법
스택은 후입선출(Last In First Out) 개념이다.  
선입후출인 큐와 비교된다.   
구현은 큐나 연결 리스트와 같은 다른 자료형에 비해 쉬운편이다.

배열을 이용해서 구현할 때를 예롤 들면, 처음으로 스택을 위한 배열을 선언하고, index 변수를 0으로 초기화한다. (변수 이름을 top이라고 설정하기도 하고, 초기값을 -1로 잡은 후 전위연산을 통해 구조를 만들 수도 있다.)   
index가 0이면 스택이 비어 있는 것이고, 스택에 뭔가를 집어넣을 때는 index의 자리에 집어넣고 index 값을 1 올리면 된다.  
index가 초기 배열 크기 이상이면 스택이 꽉 찬 것이다.  
스택에서 뭔가를 뺄 때는 index에 있던 값을 돌려주고 index 값을 1 뺀다.

연결 리스트로 구현하는 방법은 보다 단순하다.  
메모리 상에 아이템을 위한 공간을 할당하고 새로운 아이템이 추가될 때 마다 포인터로 연결하기만 하면 된다.   
아래 그림에서 좌측 ADT는 스택의 연산을 지원하기 위해 1부터 5까지 각 요소가 접시 쌓듯 차곡차곡 놓여있지만, 실제로 연결 리스트로 구현하게 된다면 물리 메모리 상에는 순서와 관계 없이 여기저기에 무작위로 배치되고 포인터로 가리키게 될 것이다.

## 구현
```c#
public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }

  public Node(T data)
  {
    this.Data = data;
  }
}
```
스택 구현 및 데이터 연결을 위한 노드 클래스

```c#
public class Stack<T>
{
  private Node<T> Head { get; set; }
  public int Count { get; set; }
  // ...
}
```
최상단 노드는 외부에서 접근하지 못하도록 private로 선언하고, 스택 크기 저장을 위한 Count 필드를 선언한다.

```c#
// ...
public Stack()
{
  Head = null;
  Count = 0;
}

public Stack(IEnumerable<T> items) : this()
{
  foreach (var item in items)
  {
    Push(item);
  }
}
// ...
```
기본 생성자와 Enumerable 객체를 파라미터로 받는 생성자를 추가한다.  
Enumerable 객체를 받아서 foreach 후 데이터를 하나씩 스택에 삽입한다.

```c#
// ...
public IEnumerator GetEnumerator()
{
  Node<T> currNode = Head;
  while (currNode != null)
  {
    yield return currNode.Data;
    currNode = currNode.NextNode;
  }
}
// ...
```
IEnumerator 인터페이스를 구현하여 Stack 인스턴스를 foreach문으로 반복시킬 수 있도록 한다.

```c#
// ...
public void Push(T data)
{
  Node<T> newNode = new Node<T>(data);

  newNode.NextNode = Head;
  Head = newNode;

  Count++;
}
// ...
```
스택에 새 데이터를 삽입하기 위해 새 노드를 생성하고 최상단 노드를 교체한다.

```c#
// ...
public T Pop()
{
  Node<T> headNode = Head;

  T data = headNode.Data;
  Head = headNode.NextNode;
  headNode = null;

  Count--;
  return data;
}
// ...
```
스택에서 데이터를 제거하는 동시에 제거한 데이터를 반환한다.   
최상단 노드 데이터 저장 및 최상단 노드 교체 후 이전 최상단 노드의 참조를 해제한다.

```c#
// ...
public T Peek()
{
  return Head.Data;
}

public void Clear()
{
  Head = null;
  Count = 0;
}
// ...
```
다음번에 제거 될 최상단 노드의 데이터를 조회하는 함수와 스택 내 데이터를 모두 삭제하는 함수를 작성한다.

```c#
// ...
public T[] ToArray()
{
  T[] newArray = new T[Count];

  int i = 0;
  foreach (T t in this)
  {
    newArray[i] = t;
    i++;
  }
  return newArray;
}
// ...
```
현재 스택을 배열로 변화 후 반환한다.  
새 배열을 선언한 뒤 현재 객체를 foreach로 반복하여 배열에 값을 추가한 후 배열을 반환한다.

```c#
// ...
public void CopyTo(T[] array, int arrayIndex)
{
  foreach (T t in this)
  {
    array[arrayIndex] = t;
    arrayIndex++;
  }
}
// ...
```
지정한 배열의 지정한 인덱스부터 스택 값을 복사한다.   
현재 객체를 foreach로 반복하며 지정한 배열에 데이터를 추가한다.

[파일](/sample_code/Stack.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값과 다음 노드 객체
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }

  // 생성자
  public Node(T data)
  {
    this.Data = data;
  }
}

// 스택 클래스
public class Stack<T>
{
  // 최상단 노드, 스택 크기
  private Node<T> Head { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Stack()
  {
    Head = null;
    Count = 0;
  }

  // Enumerable 객체를 스택으로 변환하는 생성자
  public Stack(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      Push(item);
    }
  }

  // IEnumerator 구현
  public IEnumerator GetEnumerator()
  {
    Node<T> currNode = Head;
    while (currNode != null)
    {
      yield return currNode.Data;
      currNode = currNode.NextNode;
    }
  }

  // 데이터 삽입
  public void Push(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 스택 최상단에 데이터 추가
    newNode.NextNode = Head;
    Head = newNode;

    Count++;
  }

  // 데이터 제거
  public T Pop()
  {
    // 최상단 노드 참조
    Node<T> headNode = Head;

    // 반환할 데이터 저장 후 최상단 갱신
    // 이전 최상단 노드의 참조 해제
    T data = headNode.Data;
    Head = headNode.NextNode;
    headNode = null;

    Count--;
    return data;
  }

  // 다음 제거될 데이터 조회
  public T Peek()
  {
    return Head.Data;
  }

  // 모든 데이터 삭제
  public void Clear()
  {
    // 최상단 노드 참조 해제 및 크기 0으로 초기화
    Head = null;
    Count = 0;
  }

  // 스택을 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 스택 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 스택 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 스택 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}
```
</details>

# 4. 큐
![큐](/img/queue.webp)

선입선출(First In First Out, FIFO)의 자료구조.  
대기열이라고도 한다.

스택과 비슷하지만 조금 다르다.  
데이터가 들어오는 위치는 가장 뒤(Rear 또는 Back이라고도 한다.)에 있고, 데이터가 나가는 위치는 가장 앞(Front라고 한다.)에 있어서, 먼저 들어오는 데이터가 먼저 나가게 된다.   
우선순위 큐, 원형 큐 등의 베리에이션이 존재한다.  
입력 동작은 Enqueue, 출력 동작은 Dequeue라고 한다(간혹 스택과 동일하게 Push와 Pop을 쓰기도 하고, Push와 Pull을 사용하는 경우도 있다).

## 구현 방법
보통의 배열을 사용해서 큐를 구현하면 Enqueue와 Dequeue를 할 때마다 계속 데이터가 앞으로 밀려나는 문제가 생기는데(앞쪽은 채워지고 뒤쪽은 빠져나가므로), 이를 해결하기 위해 원형 버퍼를 사용한다.   
시작 부분과 끝 부분을 포인터로 지정한 뒤 Enqueue와 Dequeue를 하는 형태.   
대신 가득찰 때와 비어있을 때 포인터가 같은 위치를 지정하기 때문에 이를 해결하기 위해 한 공간을 비워놓는다.

연결 리스트를 사용하면 배열에 비해 매우 쉽게 구현이 가능하다.

# 4.1. 단순 큐
## 구현
```c#
public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  public Node(T data)
  {
    Data = data;
  }
}
```
큐에 삽입된 데이터를 저장하고 앞뒤 노드와 연결된 노드 클래스

```c#
public class Queue<T>
{
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }
  // ...
}
```
큐 클래스는 데이터를 제거할 때 참조할 최상단 노드와 데이터를 삽입할 때 참조할 최하단 노드, 큐의 크기를 저장하는 필드를 가진다.

```c#
// ...
public Queue()
{
  Head = null;
  Tail = null;
  Count = 0;
}

public Queue(IEnumerable<T> items) : this()
{
  foreach (var item in items)
  {
    Enqueue(item);
  }
}
// ...
```
기본 생성자와 Enumerable 객체를 파라미터로 받는 생성자를 작성한다.  
기본 생성자는 단순히 필드를 초기화한다.   
Enumerable 객체를 받는 생성자는 기본 생성자를 상속하고, Enumerable 객체의 값을 순차적으로 큐에 삽입한다.

```c#
// ...
public IEnumerator GetEnumerator()
{
  Node<T> currNode = Head;
  while (currNode != null)
  {
    yield return currNode.Data;
    currNode = currNode.NextNode;
  }
}
// ...
```
큐 객체에 foreach문을 이용한 반복 접근을 가능하게 하기 위해 GetEnumerator 함수를 구현한다.   
큐의 삽입, 출력 규칙에 맞춰 최상단 노드부터 삽입한 순서대로 데이터를 반환한다.

```c#
// ...
private bool IsEmpty()
{
  if (Head == null || Tail == null || Count <= 0)
  {
    return true;
  }
  else
  {
    return false;
  }
}
// ...
```
현재 큐가 비어 있는지 확인하는 함수를 작성한다.

```c#
// ...
public void Enqueue(T data)
{
  Node<T> newNode = new Node<T>(data);

  if (IsEmpty())
  {
    Head = newNode;
    Tail = newNode;
  }
  else
  {
    Tail.NextNode = newNode;
    newNode.PrevNode = Tail;
    Tail = newNode;
  }

  Count++;
}
// ...
```
큐에 데이터를 삽입하는 함수를 작성한다.   
큐가 비어 있을 경우 새 노드는 최상단인 동시에 최하단 노드가 된다.   
일반적인 경우엔 데이터가 삽입되는 최하단 노드와 새 노드를 연결하고, 새 노드가 최하단 노드에 위치하도록 Tail을 교체한다.

```c#
// ...
public T Dequeue()
{
  if (Count > 0)
  {
    T data = Head.Data;

    if (Count == 1)
    {
      Clear();
    }
    else
    {
      Head = Head.NextNode;
      Head.PrevNode = null;
      Count--;
    }
    return data;
  }
  return default(T);
}
// ...
```
큐에서 데이터를 제거하고 제거한 데이터를 반환하는 함수를 작성한다.  
최상단 노드의 데이터를 저장하고 다음 노드를 최상단 노드로 교체한다.   
만약 큐에 데이터가 1개일 경우 최상단 노드 데이터만 저장 및 반환하고 큐 내부를 정리한다.

```c#
// ...
public T Peek()
{
  if (IsEmpty())
  {
    return default(T);
  }
  else
  {
    return Head.Data;
  }
}

public void Clear()
{
  Head = null;
  Tail = null;
  Count = 0;
}
// ...
```
다음 제거될 데이터를 조회하는 함수와 모든 데이터를 삭제하는 함수를 작성한다.

```c#
public T[] ToArray()
{
  T[] newArray = new T[Count];

  int i = 0;
  foreach (T t in this)
  {
    newArray[i] = t;
    i++;
  }
  return newArray;
}

public void CopyTo(T[] array, int arrayIndex)
{
  foreach (T t in this)
  {
    array[arrayIndex] = t;
    arrayIndex++;
  }
}
```
큐 객체를 배열로 변환하는 함수와 큐 데이터를 배열에 복사하는 함수를 작성한다.   
큐 인스턴스를 foreach문으로 반복 시켜 큐 데이터를 조회하는 방식을 사용한다.

[파일](/sample_code/Queue.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값, 다음 노드, 이전 노드
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생성자
  public Node(T data)
  {
    Data = data;
  }
}

// 큐 클래스
public class Queue<T>
{
  // 최상단 노드, 최하단 노드, 큐 크기
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Queue()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // Enumerable 객체를 스택으로 변환하는 생성자
  public Queue(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      Enqueue(item);
    }
  }

  // IEnumerator 구현
  public IEnumerator GetEnumerator()
  {
    Node<T> currNode = Head;
    while (currNode != null)
    {
      yield return currNode.Data;
      currNode = currNode.NextNode;
    }
  }

  // 큐가 비어 있는지 확인
  private bool IsEmpty()
  {
    // 최상단, 최하단 노드가 존재하지 않거나 크기가 0일시 true 반환
    if (Head == null || Tail == null || Count <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 데이터 삽입
  public void Enqueue(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 큐가 비어 있을 경우 실행
    if (IsEmpty())
    {
      // 새 노드는 최상단, 최하단 노드가 됨
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      // 새 노드와 현재 최하단 노드를 교체
      Tail.NextNode = newNode;
      newNode.PrevNode = Tail;
      Tail = newNode;
    }

    Count++;
  }

  // 데이터 제거
  public T Dequeue()
  {
    // 큐에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최상단 노드 데이터 저장
      T data = Head.Data;

      // 큐에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 큐 내부 정리
        Clear();
      }
      else
      {
        // 최상단 노드와 다음 노드를 교체
        Head = Head.NextNode;
        Head.PrevNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  // 다음 제거될 데이터 조회
  public T Peek()
  {
    // 큐가 비어 있을 경우 실행
    if (IsEmpty())
    {
      return default(T);
    }
    else
    {
      return Head.Data;
    }
  }

  // 모든 데이터 삭제
  public void Clear()
  {
    // 최상단, 최하단 노드 참조 해제 및 크기 0으로 초기화
    Head = null;
    Tail = null;
    Count = 0;
  }

  // 큐를 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 큐 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 큐 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 큐 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}
```
</details>

# 4.2. 원형 큐
큐를 위해 배열을 지정해 놓고 큐를 쓰다보면 배열의 앞부분이 비게된다는 점을 활용해서 배열의 맨 마지막 부분을 쓰면 다시 제일 처음부터 큐를 채우기 시작하는 형태의 큐이다.   
원형 큐는 FIFO 구조를 지닌다는 점에서 기존의 큐와 동일하다.   
그러나 마지막 위치가 시작 위치와 연결되는 원형구조를 띠기 때문에, 링 버퍼(Ring Buffer)라고도 부른다.

기존의 큐는 공간이 꽉 차게 되면 더 이상 요소를 추가할 수 없었다.  
심지어 앞쪽에 요소들이 Deueue()로 모두 빠져서 충분한 공간이 남게 돼도 그쪽으로는 추가할 수 있는 방법이 없다.  
그래서 앞쪽에 공간이 남아 있다면 다음 그림과 같이 동그랗게 연결해 앞쪽으로 추가할 수 있도록 재활용 가능한 구조가 바로 원형 큐다.

![원형 큐](/img/circular_queue.webp)

동작하는 원리는 투 포인터와도 비슷하다.   
그림과 같이 마지막 위치와 시작 위치를 연결하는 원형 구조를 만들고, 요소의 시작점과 끝점을 따라 투 포인터가 움직인다.  
Enqueue()를 하게 되면 rear 포인터가 앞으로 이동하고, Dequeue()를 하게 되면 front 포인터가 앞으로 이동한다.  
이렇게 Enqueue()와 Dequeue()를 반복하게 되면 서로 동그랗게 연결되어 있기 때문에 투 포인터가 빙글빙글 돌면서 이동하는 구조가 된다.   
이 그림의 Enqueue(60) 이후에는 rear 포인터가 원래의 front 포인터 자리까지 도달해 빙글빙글 돌고 있는 모습을 확인할 수 있다.  
만약 rear 포인터가 front 포인터와 같은 위치에서 서로 만나게 된다면, 다시 말해 만나는 위치까지 이동헀다면, 그때는 정말로 여유 공간이 하나도 없다는 얘기가 되므로 공간 부족 에러를 발생시킨다.

## 구현
```c#
public class CircularQueue<T>
{
  private T[] DataArray { get; set; }
  private int FrontIndex { get; set; }
  private int RearIndex { get; set; }
  private int MaxCount { get; set; }
  public int Count { get; set; }
  // ...
}
```
원형 큐는 고정 크기 배열에 데이터를 저장한다.   
삽입, 제거 위치를 가리키는 인덱스 필드와 큐가 가질 수 있는 데이터의 총 개수, 현재 개수를 저장하는 필드를 작성한다.

```c#
// ...
public CircularQueue(int length)
{
  DataArray = new T[length];
  FrontIndex = 0;
  RearIndex = 0;
  MaxCount = length;
  Count = 0;
}

public CircularQueue(IEnumerable<T> items, int length) : this(length)
{
  foreach (var item in items)
  {
    Enqueue(item);
  }
}
// ...
```
첫 번째 생성자는 큐의 크기를 파라미터로 받고 필드를 초기화한다.   
두 번째 생성자는 첫 번째 생성자를 상속하고 파라미터로 전달 받은 Enumerable 객체를 큐에 저장한다.

```c#
// ...
public IEnumerator GetEnumerator()
{
  ResetOverFrontIndex();
  ResetOverRearIndex();

  if (FrontIndex >= RearIndex)
  {
    for (int i = FrontIndex; i < MaxCount; i++)
    {
      yield return DataArray[i];
    }
    for (int i = 0; i < RearIndex; i++)
    {
      yield return DataArray[i];
    }
  }
  else
  {
    for (int i = FrontIndex; i < RearIndex; i++)
    {
      yield return DataArray[i];
    }
  }
}
// ...
```
GetEnumerator 함수를 구현한다.  
만약 front나 rear 인덱스가 배열 크기보다 클 시 0으로 초기화한다.  
front 인덱스가 rear 인덱스보다 크거나 같을 경우 front 인덱스 ~ 배열 마지막 인덱스까지 데이터 출력 후 0번 인덱스 ~ rear 인덱스까지 데이터를 출력한다.  
그 외의 경우엔 front 인덱스 ~ rear 인덱스 데이터를 출력한다.

```c#
// ...
private void ResetOverFrontIndex()
{
  if (FrontIndex == MaxCount)
  {
    FrontIndex = 0;
  }
}

private void ResetOverRearIndex()
{
  if (RearIndex == MaxCount)
  {
    RearIndex = 0;
  }
}
// ...
```
front, rear 인덱스가 배열 크기를 초과했을 경우 0으로 초기화하는 함수를 작성한다.

```c#
// ...
public bool IsEmpty()
{
  if (Count == 0)
  {
    return true;
  }
  else
  {
    return false;
  }
}

public bool IsFull()
{
  if (Count == MaxCount)
  {
    return true;
  }
  else
  {
    return false;
  }
}
// ...
```
큐가 비어있는지, 꽉 찼는지 확인하는 함수를 작성한다.

```c#
// ...
public void Enqueue(T data)
{
  if (IsFull())
  {
    Console.WriteLine("CircularQueue 공간 부족");
  }
  else
  {
    ResetOverRearIndex();

    DataArray[RearIndex] = data;
    RearIndex++;
    Count++;
  }
}
// ...
```
큐에 데이터를 삽입하는 함수를 작성한다.   
데이터를 삽입하기 전에 rear 인덱스가 배열 크기를 넘어선 위치를 가리키면 0으로 초기화한다.   
rear 인덱스 위치에 데이터를 삽입하고 rear 인덱스를 1 이동 시킨다.

```c#
// ...
public T Dequeue()
{
  if (IsEmpty())
  {
    Console.WriteLine("CircularQueue 데이터 없음");
    return default(T);
  }
  else
  {
    ResetOverFrontIndex();

    T data = DataArray[FrontIndex];
    DataArray[FrontIndex] = default(T);
    FrontIndex++;
    Count--;
    return data;
  }
}
// ...
```
큐에서 데이터를 제거하고 반환하는 함수를 작성한다.  
데이터를 제거하기 전에 front 인덱스가 배열 크기를 넘어선 위치를 가리키면 0으로 초기화한다.  
front 인덱스 위치의 데이터를 변수에 저장하고, front 인덱스 위치의 데이터를 제거한다.  
front 인덱스를 1 이동 시키고 저장한 변수를 반환한다.

```c#
// ...
public T Peek()
{
  if (IsEmpty())
  {
    return default(T);
  }
  else
  {
    ResetOverFrontIndex();
    return DataArray[FrontIndex];
  }
}

public void Clear()
{
  DataArray = new T[MaxCount];
  FrontIndex = 0;
  RearIndex = 0;
  Count = 0;
}
// ...
```
다음 제거할 데이터를 조회하는 함수와 큐 내부를 초기화하는 함수를 작성한다.

```c#
// ...
public T[] ToArray()
{
  return (T[])DataArray.Clone();
}

public void CopyTo(T[] array, int arrayIndex)
{
  array.CopyTo(DataArray, arrayIndex);
}
// ...
```
큐 데이터를 배열로 반환하는 함수와 배열에 큐 데이터를 복사하는 함수를 작성한다.

[파일](/sample_code/CircularQueue.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 원형 큐 클래스
public class CircularQueue<T>
{
  // 데이터를 저장할 고정 크기 배열
  private T[] DataArray { get; set; }

  // 전방 인덱스, 후방 인덱스
  private int FrontIndex { get; set; }
  private int RearIndex { get; set; }

  // 원형 큐 최대 데이터 개수, 현재 데이터 개수
  private int MaxCount { get; set; }
  public int Count { get; set; }

  // 파라미터로 큐의 크기를 받는 생성자
  public CircularQueue(int length)
  {
    // 필드 초기화
    DataArray = new T[length];
    FrontIndex = 0;
    RearIndex = 0;
    MaxCount = length;
    Count = 0;
  }

  // Enumerable 객체를 원형 큐로 변환하는 생성자
  public CircularQueue(IEnumerable<T> items, int length) : this(length)
  {
    foreach (var item in items)
    {
      Enqueue(item);
    }
  }

  // IEnumerator 구현
  public IEnumerator GetEnumerator()
  {
    // 넘친 인덱스를 0으로 초기화
    ResetOverFrontIndex();
    ResetOverRearIndex();

    // 전방 인덱스가 후방 인덱스 보다 크거나 같을 경우 실행
    if (FrontIndex >= RearIndex)
    {
      // 전방 인덱스부터 배열의 마지막 인덱스까지 출력
      for (int i = FrontIndex; i < MaxCount; i++)
      {
        yield return DataArray[i];
      }
      // 0번 인덱스부터 후방 인덱스까지 출력
      for (int i = 0; i < RearIndex; i++)
      {
        yield return DataArray[i];
      }
    }
    else
    {
      // 전방 인덱스부터 후방 인덱스까지 출력
      for (int i = FrontIndex; i < RearIndex; i++)
      {
        yield return DataArray[i];
      }
    }
  }

  // 넘쳐난 전방 인덱스 초기화
  private void ResetOverFrontIndex()
  {
    if (FrontIndex == MaxCount)
    {
      FrontIndex = 0;
    }
  }

  // 넘쳐난 후방 인덱스 초기화
  private void ResetOverRearIndex()
  {
    if (RearIndex == MaxCount)
    {
      RearIndex = 0;
    }
  }

  // 큐가 비어 있는지 확인
  public bool IsEmpty()
  {
    if (Count == 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 큐가 꽉 찼는지 확인
  public bool IsFull()
  {
    if (Count == MaxCount)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 큐에 데이터를 삽입
  public void Enqueue(T data)
  {
    // 큐가 꽉 찼을 경우 실행
    if (IsFull())
    {
      Console.WriteLine("CircularQueue 공간 부족");
    }
    else
    {
      // 후방 인덱스 넘쳐났을 경우 초기화
      ResetOverRearIndex();

      // 후방 인덱스 위치에 데이터를 삽입 후 인덱스 위치 이동
      DataArray[RearIndex] = data;
      RearIndex++;
      Count++;
    }
  }

  // 큐에서 데이터를 제거
  public T Dequeue()
  {
    // 큐가 비어 있을 경우 실행
    if (IsEmpty())
    {
      Console.WriteLine("CircularQueue 데이터 없음");
      return default(T);
    }
    else
    {
      // 전방 인덱스 넘쳐났을 경우 초기화
      ResetOverFrontIndex();

      // 전방 인덱스 위치의 데이터를 변수에 저장 및 반환
      // 전방 인덱스 위치에서 데이터를 제거 후 인덱스 위치 이동
      T data = DataArray[FrontIndex];
      DataArray[FrontIndex] = default(T);
      FrontIndex++;
      Count--;
      return data;
    }
  }

  // 다음 제거될 데이터를 조회
  public T Peek()
  {
    if (IsEmpty())
    {
      return default(T);
    }
    else
    {
      ResetOverFrontIndex();
      return DataArray[FrontIndex];
    }
  }

  // 큐 내부 초기화
  public void Clear()
  {
    DataArray = new T[MaxCount];
    FrontIndex = 0;
    RearIndex = 0;
    Count = 0;
  }

  // 큐를 배열로 전환
  public T[] ToArray()
  {
    return (T[])DataArray.Clone();
  }

  // 배열에 큐 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    array.CopyTo(DataArray, arrayIndex);
  }
}
```
</details>

# 4.3. 덱
![덱](/img/deque.webp)

일반적인 큐는 뒤에서만 삽입이 이루어지고 앞에서만 인출이 가능한 데 비해, 덱은 양쪽에서 모두 삽입/인출이 가능한 스택과 큐의 특징을 모두 갖고 있다. 
이 추상 자료형(ADT)의 구현은 배열이나 연결 리스트 모두 가능하지만, 특별히 그림과 같이 이중 연결 리스트(Doubly Linked List)로 구현하는 편이 가장 잘 어울린다.  
이중 연결 리스트로 구현하게 되면, 그림처럼 양쪽으로 head와 tail이라는 이름의 투 포인터를 갖고 있다가 새로운 아이템이 추가될 때 마다 앞쪽 또는 뒤쪽으로 연결시켜 주기만 하면 된다.   
당연히 연결 후에는 포인터를 이동하면 된다.

## 구현
```c#
public class Node<T>
{
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  public Node(T data)
  {
    Data = data;
  }
}
```
덱 데이터를 저장하고 앞뒤로 데이터를 연결할 노드 클래스를 작성한다.

```c#
public class Deque<T>
{
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }
  // ...
}
```
덱 클래스는 최상단, 최하단 노드와 덱 크기를 저장하는 변수를 필드로 가진다.  

```c#
// ...
public Deque()
{
  Head = null;
  Tail = null;
  Count = 0;
}

public Deque(IEnumerable<T> items) : this()
{
  foreach (var item in items)
  {
    EnqueueTail(item);
  }
}
// ...
```
기본 생성자와 기본 생성자를 상속 받고 Enumerable 객체를 파라미터로 받는 생성자를 작성한다.  
기본 생성자는 덱 내 데이터를 초기화하고, Enumerable 객체를 받는 생성자는 전달 받은 데이터를 차례로 덱에 삽입한다.

```c#
// ...
public IEnumerator GetEnumerator()
{
  Node<T> currNode = Head;
  while (currNode != null)
  {
    yield return currNode.Data;
    currNode = currNode.NextNode;
  }
}
// ...
```
덱 객체가 foreach문에 사용할 수 있도록 GetEnumerator 함수를 구현한다.

```c#
// ...
private bool IsEmpty()
{
  if (Head == null || Tail == null || Count <= 0)
  {
    return true;
  }
  else
  {
    return false;
  }
}
// ...
```
덱이 비어 있는지 확인하는 함수를 작성한다.

```c#
// ...
public void EnqueueHead(T data)
{
  Node<T> newNode = new Node<T>(data);

  if (IsEmpty())
  {
    Head = newNode;
    Tail = newNode;
  }
  else
  {
    Head.PrevNode = newNode;
    newNode.NextNode = Head;
    Head = newNode;
  }

  Count++;
}

public void EnqueueTail(T data)
{
  Node<T> newNode = new Node<T>(data);

  if (IsEmpty())
  {
    Head = newNode;
    Tail = newNode;
  }
  else
  {
    Tail.NextNode = newNode;
    newNode.PrevNode = Tail;
    Tail = newNode;
  }

  Count++;
}
// ...
```
최상단, 최하단에 데이터를 삽입하는 함수를 작성한다.   
두 함수 모두 덱이 비어 있을 경우 새 노드를 최상단이자 최하단 노드로 선정한다.  
일반적인 경우엔 각각 최상단, 최하단 노드에 새 노드를 연결 후 최상단, 최하단 노드를 교체한다.

```c#
// ...
public T DequeueHead()
{
  if (Count > 0)
  {
    T data = Head.Data;

    if (Count == 1)
    {
      Clear();
    }
    else
    {
      Head = Head.NextNode;
      Head.PrevNode = null;
      Count--;
    }
    return data;
  }
  return default(T);
}

public T DequeueTail()
{
  if (Count > 0)
  {
    T data = Tail.Data;

    if (Count == 1)
    {
      Clear();
    }
    else
    {
      Tail = Tail.PrevNode;
      Tail.NextNode = null;
      Count--;
    }
    return data;
  }
  return default(T);
}
// ...
```
최상단, 최하단 데이터 제거 및 반환하는 함수를 작성한다.   
두 함수 모두 덱에 데이터가 1개 남았을 경우 내부를 초기화 후 마지막 데이터를 반환한다.   
일반적인 경우엔 각각 최상단, 최하단 노드 데이터를 저장 후 최상단, 최하단 노드를 인접 노드로 교체한다.   
교체된 최상단, 최하단 노드는 이전, 다음 노드 참조를 해제하고 저장한 데이터를 반환한다.

```c#
// ...
public T PeekHead()
{
  if (IsEmpty())
  {
    Console.WriteLine("Deque에 제거할 데이터가 없음");
    return default(T);
  }
  else
  {
    return Head.Data;
  }
}

public T PeekTail()
{
  if (IsEmpty())
  {
    Console.WriteLine("Deque에 제거할 데이터가 없음");
    return default(T);
  }
  else
  {
    return Tail.Data;
  }
}
// ...
```
최상단, 최하단 데이터를 반환하는 함수를 작성한다.   

```c#
// ...
public void Clear()
{
  Head = null;
  Tail = null;
  Count = 0;
}
// ...
```
덱 내부를 초기화하는 함수를 작성한다.

```c#
// ...
public T[] ToArray()
{
  T[] newArray = new T[Count];

  int i = 0;
  foreach (T t in this)
  {
    newArray[i] = t;
    i++;
  }
  return newArray;
}

public void CopyTo(T[] array, int arrayIndex)
{
  foreach (T t in this)
  {
    array[arrayIndex] = t;
    arrayIndex++;
  }
}
// ...
```
덱 데이터를 배열로 반환하는 함수와 덱 데이터를 배열에 복사하는 함수를 작성한다.

[파일](/sample_code/Deque.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
using System;
using System.Collections;

// 노드 클래스
public class Node<T>
{
  // 노드의 값, 다음 노드, 이전 노드
  public T Data { get; set; }
  public Node<T> NextNode { get; set; }
  public Node<T> PrevNode { get; set; }

  // 생서앚
  public Node(T data)
  {
    Data = data;
  }
}

// 덱 클래스
public class Deque<T>
{
  // 최상단 노드, 최하단 노드, 덱 크기
  private Node<T> Head { get; set; }
  private Node<T> Tail { get; set; }
  public int Count { get; set; }

  // 기본 생성자
  public Deque()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // Enumerable 객체를 덱으로 변환하는 생성자
  public Deque(IEnumerable<T> items) : this()
  {
    foreach (var item in items)
    {
      EnqueueTail(item);
    }
  }

  // IEnumerator 구현
  public IEnumerator GetEnumerator()
  {
    Node<T> currNode = Head;
    while (currNode != null)
    {
      yield return currNode.Data;
      currNode = currNode.NextNode;
    }
  }

  // 덱이 비어 있는지 확인
  private bool IsEmpty()
  {
    if (Head == null || Tail == null || Count <= 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  // 최상단에 데이터 삽입
  public void EnqueueHead(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 덱이 비어 있을 경우 실행
    if (IsEmpty())
    {
      // 새 노드는 최상단, 최하단 노드가 됨
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      // 새 노드와 현재 최상단 노드를 교체
      Head.PrevNode = newNode;
      newNode.NextNode = Head;
      Head = newNode;
    }

    Count++;
  }

  // 최하단에 데이터 삽입
  public void EnqueueTail(T data)
  {
    // 새로운 노드 생성
    Node<T> newNode = new Node<T>(data);

    // 덱이 비어 있을 경우 실행
    if (IsEmpty())
    {
      // 새 노드는 최상단, 최하단 노드가 됨
      Head = newNode;
      Tail = newNode;
    }
    else
    {
      // 새 노드와 현재 최하단 노드를 교체
      Tail.NextNode = newNode;
      newNode.PrevNode = Tail;
      Tail = newNode;
    }

    Count++;
  }

  // 최상단 데이터 제거 및 반환
  public T DequeueHead()
  {
    // 덱에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최상단 노드 데이터 저장
      T data = Head.Data;

      // 덱에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 덱 내부 초기화
        Clear();
      }
      else
      {
        // 최상단 노드와 다음 노드를 교체
        Head = Head.NextNode;
        Head.PrevNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  // 최하단 데이터 제거 및 반환
  public T DequeueTail()
  {
    // 덱에 데이터가 1개라도 있을 경우 실행
    if (Count > 0)
    {
      // 최하단 노드 데이터 저장
      T data = Tail.Data;

      // 덱에 데이터가 1개일 경우 실행
      if (Count == 1)
      {
        // 덱 내부 초기화
        Clear();
      }
      else
      {
        // 최하단 노드와 이전 노드를 교체
        Tail = Tail.PrevNode;
        Tail.NextNode = null;
        Count--;
      }
      return data;
    }
    return default(T);
  }

  // 다음 제거될 최상단 데이터 조회
  public T PeekHead()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Deque에 제거할 데이터가 없음");
      return default(T);
    }
    else
    {
      return Head.Data;
    }
  }

  // 다음 제거될 최하단 데이터 조회
  public T PeekTail()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Deque에 제거할 데이터가 없음");
      return default(T);
    }
    else
    {
      return Tail.Data;
    }
  }

  // 덱 내부 초기화
  public void Clear()
  {
    Head = null;
    Tail = null;
    Count = 0;
  }

  // 덱을 배열로 전환
  public T[] ToArray()
  {
    // 새 배열 생성
    T[] newArray = new T[Count];

    // 배열에 덱 데이터 추가
    int i = 0;
    foreach (T t in this)
    {
      newArray[i] = t;
      i++;
    }
    return newArray;
  }

  // 배열에 덱 데이터 복사
  public void CopyTo(T[] array, int arrayIndex)
  {
    // 지정한 인덱스부터 배열에 덱 데이터 추가
    foreach (T t in this)
    {
      array[arrayIndex] = t;
      arrayIndex++;
    }
  }
}
```
</details>

# 4.4. 우선순위 큐
우선순위 큐는 말 그대로 원소들에게 우선순위를 매겨서 넣을 때의 순서와 상관없이 뺄 때에는 우선순위가 높은 원소부터 빼내는 것이다.  
이 경우에 만약 우선순위가 낮은 원소가 들어간다면(Enqueue) 빼낼 때에는(Dequeue) 기존 큐 구조에서 예상할 수 있는 값과 다른 상황이 된다.   
대표적인 예로 힙이 있다.

# 5. 그래프
![그래프](/img/graph0.webp)

그래프는 정점과 간선으로 이루어진 자료구조이다.   
정확히는 정점(Vertex)간의 관계를 표현하는 조직도라고 볼수도 있다.   
그런 면에서 트리는 그래프의 일종인 셈이다.  
다만 트리와는 달리 그래프는 정점마다 간선이 없을수도 있고 있을수도 있으며 루트 노드, 부모와 자식이라는 개념이 존재하지 않는다.  
또한 그래프는 네트워크 모델 즉, 객체와 이에 대한 관계를 나타내는 유연한 방식으로 이해할 수 있다.  
실생활에서 다양한 예를 그래프로 표현할 수 있다.   
대표적으로 지하철 노선도, 도심의 도로 등이 있다.

![그래프 트리 차이](/img/graph_tree.png)

## 용어
![그래프 용어](/img/graph1.png)

* 정점(vertex): 노드(node)라고도 하며 정점에는 데이터가 저장된다.
* 간선(edge): 정점(노드)를 연결하는 선으로 link, branch 라고도 부른다.
* 인접 정점(adjacent vertex): 간선에 의해 직접 연결된 정점 (0과 2는 인접 정점)
* 단순 경로(simple path): 경로 중에서 반복되는 정점이 없는 경우. 한붓그리기와 같이 같은 간선을 지나가지 않는 경로 (0->3->2->1 은 단순 경로)
* 차수(degree): 무방향 그래프에서 하나의 정점에 인접한 정점의 수 (0의 차수는 3)
* 진출 차수(in-degree): 방향 그래프에서 외부로 향하는 간선의 수
* 진입 차수(out-degree): 방향 그래프에서 외부에서 들어오는 간선의 수
* 경로 길이(path length): 경로를 구성하는데 사용된 간선의 수
* 사이클(cycle): 단순 경로의 시작 정점과 종료 정점이 동일한 경우

## 구현 방법
그래프를 구현하는 방법에는 인접행렬(adjacency matrix)와 인접리스트(adjacency list)방식이 있다.  
각각의 구현 방식은 상반된 장단점을 가지고 있는데 대부분 인접리스트 형식을 사용한다.

## 인접행렬 방식
![인접행렬](/img/adjacency_matrix.png)

인접행렬은 그래프의 노드를 2차원 배열로 만든 구현한 것이다.   
완성된 배열의 모양은 1, 2, 3, 4, 5, 6의 정점을 연결하는 노드에 다른 노드들이 인접 정점이라면 1, 아니면 0을 넣어준다.

### 인접행렬 장점
1. 2차원 배열 안에 모든 정점들의 간선 정보를 담기 때문에 배열의 위치를 확인하면 두 점에 대한 연결 정보를 0(1)의 시간복잡도로 조회 가능하다.
2. 구현이 비교적 간편하다.

### 인접행렬 단점
1. 모든 정점에 대해 간선 정보를 대입해야 하므로 O(n^2)의 시간복잡도가 소요된다.
2. 무조건 2차원 배열이 필요하기에 필요 이상의 공간이 낭비된다.

## 인접리스트 방식
![인접리스트](/img/adjacency_list.png)

인접리스트란 그래프의 노드들을 리스트로 표현한 것이다.  
주로 정점의 리스트 배열을 만들어 관계를 설정해줌으로써 구현한다.

### 인접리스트 장점
1. 정점들의 연결 정보를 탐색할 때 O(n)의 시간이면 가능하다. (n: 간선의 개수)
2. 필요한 만큼의 공간만 사용하기 때문에 공간의 낭비가 적다.

### 인접리스트의 단점
1. 특정 두 점이 연결되었는지 확인하려면 인접행렬에 비해 시간이 오래 걸린다. (배열보다 search 속도 느림)
2. 구현이 비교적 어렵다.

## 구현
```c#
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
```
그래프의 노드 데이터를 저장할 클래스를 작성한다.  
인접 노드 목록, 간선 이동 비용, 노드 데이터 필드를 가진다.

```c#
public class Graph<T>
{
  private List<Node<T>> NodeList { get; set; }

  public Graph()
  {
    NodeList = new List<Node<T>>();
  }
  // ...
}
```
그래프 자료구조를 표현할 클래스를 작성한다.   
노드 목록 필드를 가지고, 기본 생성자로 노드 목록을 초기화한다.

```c#
// ...
public Node<T> AddNode(T data)
{
  Node<T> newNode = new Node<T>(data);
  NodeList.Add(newNode);
  return newNode;
}
// ...
```
노드를 추가하는 함수를 작성한다.  
새로운 노드 생성 후 그래프의 노드 목록에 추가한 후 추가한 노드를 반환한다.

```c#
// ...
public void AddEdge(Node<T> from, Node<T> to, bool isDirected = true, int weight = 0)
{
  from.Neighbors.Add(to);
  from.Weights.Add(weight);

  if (!isDirected)
  {
    to.Neighbors.Add(from);
    to.Weights.Add(weight);
  }
}
// ...
```
간선을 추가하는 함수를 작성한다.  
기본적으로 유향 그래프, 가중치 없음으로 설정한다.   
출발 노드의 인접 노드 목록에 목표 노드를 추가하고, 간선 이동 가중치 목록에 가중치 값을 추가한다.    
만약 무향 그래프일 경우 똑같이 목표 노드의 인접 노드 목록에 출발 노드를 추가하고, 간선 이동 가중치 목록에 가중치 값을 추가한다.

```c#
// ...
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
// ...
```
전체 노드와 노드의 간선을 출력하는 함수를 작성한다.

[파일](/sample_code/Graph.cs)
<details>
<summary>C# 예제 코드</summary>

```c#
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
```
</details>

# 5.1. 무향 그래프
![무향 그래프](/img/undirected_graph.png)

무향 그래프는 두 정점을 연결하는 간선에 방향이 없는 그래프다.

# 5.2. 유향 그래프
![유향 그래프](/img/directed_graph.png)

유향 그래프는 두 정점을 연결하는 간선에 방향이 존재하는 그래프이다.   
간선의 방향으로만 이동할 수 있다.

# 5.3. 가중 그래프
![가중 그래프](/img/weighted_graph.png)

가중치 그래픈느 두 정점을 이동할 때 비용이 드는 그래프이다.

# 5.4. 완전 그래프
![완전 그래프](/img/complete_graph.png)

완전 그래프는 모든 정점이 간선으로 연결되어 있는 그래프다.

# 6. 트리
![그래프 트리](/img/graph_tree.png)

트리란 그래프의 일종으로, 한 노드에서 시작해서 다른 정점들을 순회하여 자기 자신에게 돌아오는 사이클이 없는 연결 그래프를 트리라고 한다.

부모 노드 밑에 여러 자식 노드가 연결되고, 자식 노드 각각에 다시 자식 노드가 연결되는 재귀적 형태의 자료구조다.    
단, 자식 노드의 자식이 부모로 연결되는 경우는 보통 트리로 인정하지 않는다.  

자식 노드에서 부모 쪽으로 계속해서 타고 올라가다 보면 결국 부모가 없는 하나의 노드로 이어지게 되는데, 이 노드를 루트 노드(root node)라고 부르며, 루트 노드를 중심으로 뻗어나가는 모습이 나무의 구조와 비슷하여 '트리'라는 이름이 붙었다.

## 용어
![트리 용어](/img/tree0.webp)

트리 각 부분의 명칭과 용어는 위 그림과 같다.

트리는 항상 루트(root)에서부터 시작된다.  
루트는 자식(child) 노드를 가지며, 간선(edge)으로 연결되어 있다.   
자식 노드의 개수는 차수(degree)라고 하며, 크기(size)는 자신을 포함한 모든 자식 노드의 개수다.   
높이(height)는 현재 위치에서부터 리프(leaf)까지의 거리, 깊이(depth)는 루트에서부터 현재 노드까지의 거리다.  
트리는 그 자식도 트리인 서브트리(subtree) 구성을 띤다.  
레벨(level)은 0부터 시작한다.   
트리는 항상 단방향(uni-directional)이기 때문에(그렇지 않으면 순환참조가 되어 오류가 발생한다.) 간선의 화살표는 생략 가능하다.   
일반적으로 방향은 위에서 아래로 향한다.

* 노드(node): 트리를 구성하는 기본 원소
  * 루트 노드(root node/root): 트리에서 부모가 없는 최상위 노드, 트리의 시작점
  * 부모 노드(parent node): 루트 노드 방향으로 직접 연결된 노드
  * 자식 노드(child node): 루트 노드 반대방향으로 직접 연결된 노드
  * 형제 노드(siblings node): 같은 부모 노드를 갖는 노드들
  * 리프 노드(leaf node/leaf): 루트 노드를 제외한 차수가 1인 정점을 뜻한다. 쉽게 말해 자식이 없는 노드, 단말 노드라 부르기도 한다.
* 경로(path): 한 노드에서 다른 한 노드에 이르는 길 사이에 있는 노드들의 순서
* 길이(length): 출발 노드에서 도착 노드까지 거치는 간선의 개수
* 깊이(depth): 루트 경로의 길이
* 레벨(level): 루트 노드(level=0)부터 노드까지 연결된 간선 수의 합
* 높이(height): 가장 긴 루트 경로의 길이
* 차수(degree): 각 노드의 자식의 개수(이진 트리에서는 이것의 최댓값이 2로 제한된다.)
* 트리의 차수(degree of tree): 트리의 최대 차수
* 크기(size): 노드의 개수
* 너비(width): 가장 많은 노드를 갖고 있는 레벨의 크기
* 내부 정점(internal vertex): 차수가 2 이상인 정점을 뜻한다.
* 포레스트(forest): 서로 독립인 트리들의 모임이다.

# 6.1. 이진 트리
![이진 트리](/img/binary_tree0.webp)

부모 노드 밑의 자식 노드 개수(=차수, degree)를 최대 2개로 제한하는, 트리의 가장 간단한 형태다.   
두 자식 노드를 보통 왼쪽 자식과 오른쪽 자식으로 구분지으며, 하나의 값과 왼쪽, 오른쪽 자식 노드를 각각 가리킬 두 개의 포인터를 가진 구조로 구현할 수 있다.

일반적으로 n개의 자식을 가질 수 있는 트리 구조에서, 1개를 초과한 자식 하나마다 노드를 하나 추가해 추가된 새 노드의 왼쪽에 원래의 자식 노드, 오른쪽에 형제 노드를 배치하는 이진 트리 구조로 변환할 수 있으며(left-child, right-sibling), 이 방법으로 모든 트리를 이진 트리 형태로 재구성할 수 있다(좌우를 바꾸어도 동일).  
때문에 특별한 이유가 없는 이상 트리는 보통 이진 트리로 구현된다.

이진 트리에는 다음과 같은 종류가 있다.
* 정 이진 트리(full binary tree): 모든 트리의 자식은 0개나 2개다.
* 포화 이진 트리(perfect binary tree): 모든 리프 노드의 높이가 같고 리프 노드가 아닌 노드는 모두 2개의 자식을 갖는다.   
이진 트리에서 리프 높이의 최대치가 n일 때 가장 많이 존재할 수 있는 노드의 수는 2^n - 1개인데 포화 이진 트리는 이 개수를 모두 채운 이진 트리라고도 볼 수 있다.   
또한, 모든 포화 이진 트리는 정 이진 트리다.
* 완전 이진 트리(complete binary tree): 모든 리프 노드의 높이가 최대 1 차이가 나고, 모든 노드의 오른쪽 자식이 있으면 왼쪽 자식이 있는 이진 트리이다.  
다시 말해 트리의 원소를 왼쪽에서 오른쪽으로 하나씩 빠짐없이 채워나간 형태이다.  
포화 이진 트리는 완전 이진 트리의 부분집합이다.   
단, 포화 이진 트리가 아닌 완전 이진 트리는 정 이진 트리일 수도 있고 아닐 수도 있다.

일반적으로 비선형 구조인 이진 트리는 각각의 노드가 자식들의 포인터를 갖도록 구현되지만, 완전 이진 트리의 경우 왼쪽부터 빠짐없이 채워져있다는 성질을 이용해 배열을 사용하여 구현 하기도 한다.  
1번부터 시작하는 배열을 생각하면 n번째 원소의 왼쪽 자식은 2n, 오른쪽 자식은 2n + 1번째 원소로 구성하면 된다.  
또, n번째 원소의 부모 노드는 n/2 번째 원소가 된다.

## 이진 트리 순회 방법
* 중위 순회(in-order traversal): 왼쪽 자손, 자신, 오른쪽 자손 순서로 방문하는 순회 방법.  
이진 탐색 트리를 중위 순회하면 정렬된 결과를 얻을 수 있다.
* 전위 순회(pre-order traversal): 자신, 왼쪽 자손, 오른쪽 자손 순서로 방문하는 순회 방법.
* 후위 순회(post-order traversal): 왼쪽 자손, 오른쪽 자손, 자신 순서로 방문하는 순회 방법.
* 레벨 순서 순회(level-order traversal): 너비 우선 순회(Breadth-First traversal)라고도 한다.   
노드를 레벨 순서로 방문하는 순회 방법.  
위의 세 가지 방법은 스택을 활용하여 구현할 수 있는 반면 레벨 순서 순회는 큐를 활용해 구현할 수 있다.

![이진 트리 순회 방법](/img/binary_tree1.gif)

위의 트리를 순회하면 다음과 같다.

* In-order: 1 3 4 6 7 8 10 13 14
* Pre-order: 8 3 1 6 4 7 10 14 13
* Post-order: 1 4 7 6 3 13 14 10 8
* Level-order: 8 3 10 1 6 14 4 7 13

# 6.1.1. 이진 탐색 트리
![이진 탐색 트리](/img/binary_search_tree0.webp)

이진 트리의 일종으로, 노드의 왼쪽 가지에는 노드의 값보다 작은 값들만 있고, 오른쪽 가지에는 큰 값들만 있도록 구성되었다.   
자식 노드들도 동일한 방법으로 정렬되어 노드의 왼쪽 자식의 왼쪽 가지에는 왼쪽 자식이 가진 값보다 작은 값만 있고, 왼쪽 자식의 오른쪽 가지에는 왼쪽 자식의 값보다 큰 값들만 있고, 오른쪽 자식의 왼쪽 가지에는... 이런 식으로 이진 탐색 트리의 어느 노드를 확인해도 동일한 규칙으로 정렬 되어 있다.

이렇게 구성해 두면 어떤 값 n을 찾을 때, 루트 노드와 비교해서 n이 더 작다면 루트 노드보다 큰 값들만 모여 있는 오른쪽 가지는 전혀 탐색할 필요가 없다.   
마찬가지로 루트 노드의 왼쪽 자식보다 n이 크다면 왼쪽 자식의 왼쪽 가지는 탐색할 필요가 없고... 다시 말해 트리 자체가 이진 탐색을 하기에 적합한 구성이 되는 것이다.   
또한 값을 찾을 때 뿐만이 아니라 값을 삽입하거나 삭제할 때도 똑같은 과정을 거치므로, 이상적인 상황에서 탐색/삽입/삭제 모두 시간복잡도가 O(log N)이 된다.

![이진 탐색 트리 탐색](/img/binary_search_tree1.webp)

이진 탐색 트리를 이용해 원하는 값(여기서는 8)을 찾는(탐색하는) 과정은 위 그림과 같다.   
이 그림에서 먼저, 루트는 15이며, 8은 15보다 작다.   
따라서 왼쪽 자식 노드를 탐색한다.   
10 또한 마찬가지로 8보다 크므로, 왼쪽을 택한다.   
5는 8보다 작으므로, 오른쪽으로 탐색한다.  
그 다음, 7은 8보다 작으므로 마지막으로 오른쪽을 탐색해 정답 8을 찾아낸다.   
이처럼 단 4번 만에 정답을 찾을 수 있다.   
만약 6을 찾는다면(여기서는 정답이 없는) 5 이후에 오른쪽을 탐색하게 될 것이고, 그 다음에는 7, 이후에 다시 왼쪽을 탐색하려 하는데, 더 이상 왼쪽 노드가 없으므로 탐색을 중단하고 '정답 없음'을 출력하게 될 것이다.

다만 단점이 있는데, 값이 삽입되거나 삭제되는 경우에 따라서 운이 안 좋으면 최악의 경우에 O(N)의 시간이 걸리게 된다.  
예를 들어, 비어 있는 이진 탐색 트리에 1부터 100까지 순서대로 삽입한다면 처음 루트 노드는 1이 되고, 2는 1보다 크니 1의 오른쪽 자식이 되고, 3은 1보다 크니 1의 오른쪽, 2보다 크니 2의 오른쪽... 이런 식으로 트리의 오른쪽 끝으로만 계속 성장하게 된다.  
이 상태로 50을 찾는다고 하면 결국 1부터 순서대로 오른쪽으로 쭈욱 내려가는 선형 탐색이나 다를게 없게 된다.   
이러한 경우를 트리가 편향(skew)되었다고 한다.

# 6.1.2. AVL 트리
![AVL 트리](/img/AVL_tree0.svg.png)

가장 처음으로 나온 자가 균형 이진 탐색 트리로, 이진 탐색 트리가 운이 안 좋을 경우 O(N)의 시간이 걸리는 것을 보완한 트리이다.  
이상적인 상황에서나 최악의 상황에서 탐색/삽입/삭제 모두 시간 복잡도가 O(log N)이다.   
만족해야 하는 조건은 모든 노드에서 오른쪽 트리와 왼쪽 트리의 높이(height)의 차이가 1 이하로만 나는 것.  
삽입/삭제를 할 때마다 균형이 안 맞는 것을 맞추기 위해 트리의 일부를 왼쪽 혹은 오른쪽으로 회전시켜야 한다.

균형은 레드-블랙 트리보다 훨씬 잘 잡히지만, 그렇기 때문에 레드-블랙 트리보다 삽입과 제거가 느리고 탐색 자체는 빠르다.   
그래서 보통 자가 균형 이진 탐색 트리가 필요한 경우 레드-블랙 트리를 쓰는 경우가 많다.

## 정의와 성질
* 높이 균형 성질(height-balance property): 트리 T의 모든 내부 노드(internal node) v에 대하여 v의 자식 노드들의 높이 차이가 최대 1이다.
* 임의의 이진 탐색 트리 T가 높이 균형 성질을 만족할 때 AVL 트리라고 한다.

높이 균형 성질(height-balance property)로부터 n개의 원소를 갖는 AVL 트리의 높이는 log n이라는 사실을 알 수 있다.

이진 탐색 트리에서의 검색 시간복잡도는 트리의 높이이므로 AVL 트리의 검색 시간이 O(log n) 임을 알 수 있다.

## 동작
AVL 트리에서 노드를 일반적인 이진 탐색 트리처럼 삽입, 삭제 시키면 높이 균형 성질을 만족하지 않게 된다.  
노드가 삽입, 삭제될 때 회전(rotation)을 통해 트리를 재구성하여 높이 균형 성질을 유지시킨다.

### 삽입
AVL 트리 T에 새로운 노드 d를 삽입(Insertion)하는 방법은 T에서 d가 단말 노드(leaf node)로 삽입될 수 있도록 하는 노드 w를 찾고 w의 자식으로 d를 삽입한다.

d를 삽입하면 불균형해질 수 있는데 새 노드를 기준으로 회전(rotation)시킴으로써 균형을 맞춘다.

### 회전
트리 T의 재구성 작업을 회전(rotation)이라 한다.

회전의 기준이 되는 세 노드 x, y, z는 다음과 같다.   
z는 w로부터 root로 가는 경로상에 가장 처음으로 위치한 불균형한 노드이다.  
y는 z의 자식 중에서 가장 큰 높이를 갖는 노드이다.   
x는 y의 자식 중에서 가장 큰 높이를 갖는 노드이다.

x가 이진 탐색 트리 T의 노드이고 y가 부모, z가 할아버지 노드일 때 다음과 같이 재구성한다.

1. x, y, z를 왼쪽-오른쪽 순서(inorder)로 나열 한 순서대로 a, b, c 라고 하고, x, y, z의 4개의 부분 트리들을 왼쪽-오른쪽 순서(inorder)로 나열한 것을 T0, T1, T2, T3 라고 가정한다.
2. z가 root인 부분 트리를 b를 root로 하는 새로운 부분 트리로 바꾼다.
3. a가 b의 왼쪽 자식이 되고 T0, T1은 각각 a의 왼쪽, 오른쪽 자식이 된다.
4. c가 b의 오른쪽 자식이 되고, T2, T3는 각각 c의 왼쪽, 오른쪽 자식이 된다.

이 작업을 구상화하면 b = y 일 때 y를 z와 회전시키는 것처럼 보인다.  
이 작업을 single rotation이라고 한다.

b = x 일 때 x를 y와 회전시키고 다시 z와 회전시키는 것처럼 보인다.   
이 작업을 double rotation이라고 한다.

이 재구성 방법은 T의 부모-자식 관계만을 바꾸는 것이기 때문에 O(1) 시간이 걸린다.

### 삭제
AVL 트리 T에서 노드 d를 삭제(removal)하는 방법은 root부터 d를 검색한다.   
d가 단말 노드가 아니라면 자신의 왼쪽 부분 트리 중에서 최댓값을 갖는 노드나 오른쪽 부분 트리 중에서 최솟값을 갖는 노드를 d와 바꾼다.   
이 작업을 d가 단말 노드가 될 때까지 반복하여 단말 노드 d를 삭제한다.

삭제 역시 트리가 불균형해질 수 있는데 삽입과 동일한 방법으로 d의 부모를 w라고 한 뒤 회전시켜 균형을 맞춘다.

