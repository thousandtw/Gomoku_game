using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    //負責遊戲邏輯程式碼 (規矩)
    class GameMaster
    {
        //宣告自行建立的棋盤變數
        private Board board = new Board();

        //正在下棋之人(用於強制黑白交替)
        private PieceType currentPlayer = PieceType.Black;

        //宣告贏家(顏色)變數
        private PieceType winner = PieceType.None;
        public PieceType Winner
        {
            get
            {
                return winner;
            }
        }

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);

            //判斷點上有無棋子
            if (piece != null)
            {
                //檢查是否現在下棋者為贏家
                CheckVinner();

                //交換選手(如果為白棋,下個棋則黑(反之))
                if (currentPlayer == PieceType.Black)
                {
                    currentPlayer = PieceType.White;
                }
                else if (currentPlayer == PieceType.White)
                {
                    currentPlayer = PieceType.Black;
                }
                return piece;
            }
            return null;
        }

        //判斷遊戲贏家
        private void CheckVinner()
        {
            //宣告當前棋子(x,y)
            int centerX = board.LastPlacenode.X;
            int centerY = board.LastPlacenode.Y;

            //檢查八個不同方向 (X) (Y)   
            //xDir (x的變量)  
            //yDir (y的變量)
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //排除X,Y無加減情況(無動作)
                    if (xDir == 0 && yDir == 0)
                    {
                        //發現即跳除迴圈,檢查下一個
                        continue;
                    }

                    //紀錄現在看到幾顆相同的棋子
                    int count = 1;
                    while (count < 5)
                    {
                        //宣告單方向的下顆棋子(x,y)
                        //int targetX = centerX + count;
                        //int targetY = centerY;

                        //宣告多方向的下顆棋子(x,y)
                        // G9圖解釋
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        //檢查 ( 1.X/Y是否超出邊界 || 2.顏色是否相同 )
                        //(使用||好處為任一即成立(先後順序重要))
                        if (
                            targetX < 0 ||
                            targetX >= Board.NODE_COUNT ||
                            targetY < 0 ||
                            targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer
                            )
                            break;

                        count++;
                    }

                    //檢查是否看到五顆棋子,是即將贏家顏色指向winner
                    if (count == 5)
                    {
                        winner = currentPlayer;
                    }

                }
            }
        }
    }
}
