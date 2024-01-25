using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class LinearDataStructure
    {
        class MyList<T>
        {
            const int DEFAULT_SIZE = 1;
            T?[] _data = new T[DEFAULT_SIZE];

            public int Count = 0; // 실제로 사용중인 데이터 개수
            public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

            // O(1) 예외케이스 : 이사 비용은 무시한다 (항상 크기가 부족하여 반복문이 실행되지는 않기 때문에)
            public void Add(T item)
            {
                // 1. 공간이 충분히 남아있는지 확인
                if (Count >= Capacity)
                {
                    // 공간을 다시 늘려서 확보한다
                    T[] newArray = new T[Count * 2];

                    for (int i = 0; i < Count; i++)
                    {
                        newArray[i] = _data[i]!;
                    }
                    _data = newArray;
                }

                // 2. 공간에 데이터를 넣어준다
                _data[Count] = item;
                Count++;
            }


            // 인덱서
            // O(1)
            public T this[int index]
            {
                get { return _data[index]!; }
                set { _data[index] = value; }
            }

            // O(N)
            public void RemoveAt(int index)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _data[i] = _data[i + 1];
                }

                // T타입의 초기값으로 대입 (값타입이면 0, 참조타입이면 null)
                _data[Count - 1] = default(T);

                Count--;
            }
        }
        class MyLinkedList<T>
        {
            public MyNode<T>? Head;
            public MyNode<T>? Tail;
            public int Count;

            // O(1)
            public MyNode<T> AddLast(T data)
            {
                MyNode<T> newNode = new MyNode<T>();
                newNode.Data = data;

                // Head 없을 경우
                if (Head == null)
                    Head = newNode;

                // Tail 존재할 경우
                if (Tail != null)
                {
                    Tail.Next = newNode;
                    newNode.Prev = Tail;
                }

                Tail = newNode;
                Count++;

                return newNode;
            }

            // O(1)
            public void Remove(MyNode<T> node)
            {
                // 삭제할 노드가 Head일 경우
                if (Head == node)
                    Head = Head.Next;

                // 삭제할 노드가 Tail일 경우
                if (Tail == node)
                    Tail = Tail.Prev;

                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }

                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }

                Count--;
            }
        }
        class MyNode<T>
        {
            public T? Data;
            public MyNode<T>? Next;
            public MyNode<T>? Prev;
        }
    }
}
