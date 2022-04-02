using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    //白棋子類別
    class WhitePiece :Piece
    {
        //繼承於基底類別,所以必須以WhitePiece建構子將(x,y)傳回-基底類別的Piece建構子

        public WhitePiece(int x,int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }

        //繼承於基底類別,實作abstract類的行為
        public override PieceType GetPieceType()
        {
            return PieceType.White;
        }
    }
}
