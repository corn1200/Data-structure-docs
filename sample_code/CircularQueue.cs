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

      // 전방 인덱스 위치의 데이터를 변수에 저장 및 출력
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