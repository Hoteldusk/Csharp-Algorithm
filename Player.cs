using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Player
    {
        public int PosY { get; private set; }
        public int PosX {  get; private set; }
        Random _random = new Random();
        Board? _board;

        public void Initalize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                // 0.1 초마다 실행될 로직
                int randomValue = _random.Next(0, 5);
                switch(randomValue)
                {
                    case 0: // 상
                        if (_board!.Tile![PosY - 1, PosX] == Board.TileType.Empty)
                            PosY -= 1;
                        break;

                    case 1: // 하
                        if (_board!.Tile![PosY + 1, PosX] == Board.TileType.Empty)
                            PosY += 1;
                        break;

                    case 2: // 좌
                        if (_board!.Tile![PosY, PosX - 1] == Board.TileType.Empty)
                            PosX -= 1;
                        break;

                    case 3: // 우
                        if (_board!.Tile![PosY, PosX + 1] == Board.TileType.Empty)
                            PosX += 1;
                        break;
                }
            }
        }
    }
}
