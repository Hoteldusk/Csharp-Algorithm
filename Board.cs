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
        public TileType[,]? Tile { get; private set; } // 배열
        public int Size { get; private set; }

        Player? _player;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initalize(int size, Player player)
        {
            if (size % 2 == 0)
                return;


            _player = player;
            Tile = new TileType[size, size];
            Size = size;

            // 길을 막는 부분
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            GeneratedBySideWinder();
        }

        private void GeneratedBySideWinder()
        {
            // 랜덤으로 우측 혹은 아래로 길을 뚫는 부분
            // SideWinder Algorithm
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;

                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile![y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile![y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 차이점 : 뚫어놓은 x들중에서 랜덤으로 선택해 아래로 뚫는다
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile![y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile![y + 1, x - randomIndex * 2] = TileType.Empty;
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
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile![y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile![y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile![y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile![y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 플레이어 좌표를 갖고와서, 그 좌표와 현재 x, y가 일치하면 플레이어 전용색상으로 표시
                    if(y == _player!.PosY && x == _player!.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = GetTileColor(Tile![y, x]);

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
