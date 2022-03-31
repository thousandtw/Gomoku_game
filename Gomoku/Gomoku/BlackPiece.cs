﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class BlackPiece : Piece
    {
        //繼承於基底類別,所以必須以BlackPiece建構子將(x,y)傳回-基底類別的Piece建構子

        public BlackPiece(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }
    }
}
