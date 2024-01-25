using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{   
    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,]? _tile; // 배열
        public int _size;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initalize(int size)
        {
            if (size % 2 == 0)
                return;

            _tile = new TileType[size, size];
            _size = size;


            // 길을 막는 부분
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            GeneratedBySideWinder();
        }

        private void GeneratedBySideWinder()
        {
            // 랜덤으로 우측 혹은 아래로 길을 뚫는 부분
            // SideWinder Algorithm
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                int count = 1;

                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                    {
                        continue;
                    }

                    if (y == _size - 2)
                    {
                        _tile![y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile![y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 차이점 : 뚫어놓은 x들중에서 랜덤으로 선택해 아래로 뚫는다
                    if (rand.Next(0, 2) == 0)
                    {
                        _tile![y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        _tile![y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        private void GeneratedByBinaryTree()
        {
            // 랜덤으로 우측 혹은 아래로 길을 뚫는 부분
            // Binary Tree Algorithm
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                    {
                        continue;
                    }

                    if (y == _size - 2)
                    {
                        _tile![y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile![y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        _tile![y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile![y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile![y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor= prevColor;
        }

        private ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;

                case TileType.Wall:
                    return ConsoleColor.Red;

                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
