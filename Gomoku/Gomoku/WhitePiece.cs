using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class WhitePiece :Piece
    {
        //繼承於基底類別,所以必須以WhitePiece建構子將(x,y)傳回-基底類別的Piece建構子

        public WhitePiece(int x,int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
    }
}
