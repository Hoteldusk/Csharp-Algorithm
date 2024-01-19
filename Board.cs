using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{   
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

        // O(1) 예외케이스 : 이사 비용은 무시한다 (항상 크기가 부족하여 반복문이 실행되지는 않기 때문에)
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아있는지 확인
            if(Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보한다
                T[] newArray = new T[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
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
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            for(int i = index; i < Count - 1;  i++)
            {
                _data[i] = _data[i + 1];
            }

            // T타입의 초기값으로 대입 (값타입이면 0, 참조타입이면 null)
            _data[Count - 1] = default(T);
            Count--;
        }
    }



    class Board
    {
        public int[] _data = new int[25]; //배열
        //public List<int> _data2 = new List<int>(); //동적배열
        public MyList<int> _data2 = new MyList<int>();

        public LinkedList<int> _data3 = new LinkedList<int>(); //연결리스트

        public void Initalize()
        {
           
        }
    }
}
