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

        //用於強制黑白交替
        private PieceType currentPlayer = PieceType.Black;

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
                //如果為白棋,下個棋則黑(反之)
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

        }
    }
}
