using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initalize(25);

            //Console.SetWindowSize(25, 25);
            Console.CursorVisible = false;
            Console.Clear();

            const int WAIT_TICK = 1000 / 30;
            

            int lastTick = 0;

            while (true)
            {
                #region 프레임관리
                // FPS 프레임 (60 프레임 OK, 30프레임 이하로 NO)
                int currentTick = System.Environment.TickCount;
                
                // 만약 경과한 시간이 1/30 보다 적다면 (currentTick 단위는 현재 ms임)
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;
                #endregion

                // 입력

                // 로직

                // 렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
           }
        }
    }
}