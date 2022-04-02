using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    //棋盤類別
    class Board
    {
        //宣告一個沒有在棋盤上的點
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        //棋盤邊距
        private static readonly int OPPSET = 75;
        //點能感應距離(半徑)
        private static readonly int NODE_RADIUS = 10;
        //點與點的距離
        private static readonly int NODE_DISTRANCE = 75;
        //棋子的資料結構
        private Piece[,] pieces = new Piece[9,9];

        //軸心程式
        public bool CanBePlaced(int x,int y)
        {
            //找出最近的節點 (NODE)
            Point nodeld = FindTheCloseNode(x, y);

            //如果沒有的話,回傳 false
            if(nodeld== NO_MATCH_NODE)
            {
                return false;
            }

            //檢查棋子是否存在點上,有則回傳false
            if (pieces[nodeld.X, nodeld.Y] != null)
            {
                return false;
            }

            return true;
        }

        //使棋子按照點放置,並檢查
        public Piece PlaceAPiece(int x,int y,PieceType type)
        {
            //找出最近的節點 (NODE)
            Point nodeld = FindTheCloseNode(x, y);

            //如果沒有的話,回傳 false
            if (nodeld == NO_MATCH_NODE)
            {
                return null;
            }

            //檢查棋子是否存在點上,有則回傳null
            if (pieces[nodeld.X, nodeld.Y] != null)
            {
                return null;
            }

            //TODO:根據TYPE產生對應的棋子
            if (type == PieceType.Black)
            {
                pieces[nodeld.X, nodeld.Y] = new BlackPiece(x, y);
            }
            else if (type == PieceType.White)
            {
                pieces[nodeld.X, nodeld.Y] = new WhitePiece(x, y);
            }

            //回傳棋子位置
            return pieces[nodeld.X, nodeld.Y];

        }

        //二維判斷方法
        private Point FindTheCloseNode(int x,int y)
        {
            //判斷X靠近哪個點,有則存入位置,無則回傳不存在的點
            int nodeldX = FindTheCloseNode(x);
            if (nodeldX == -1)
            {
                return NO_MATCH_NODE;
            }

            //判斷Y靠近哪個點,有則存入位置,無則回傳不存在的點
            int nodeldY = FindTheCloseNode(y);
            if (nodeldY == -1)
            {
                return NO_MATCH_NODE;
            }

            //回傳存入的座標
            return new Point(nodeldX, nodeldY);
        }

        //一維判斷方法 // (pos為點到棋盤邊的距離)
        private int FindTheCloseNode(int pos) 
        {
            //判斷如果游標下棋位置在棋盤線外,則回傳負值
            if (pos < OPPSET - NODE_RADIUS)
            {
                return -1;
            }

            //扣除棋盤邊距
            pos -= OPPSET;

            //取出商數 (可得知為第幾個點)
            int quotite = pos / NODE_DISTRANCE;

            //取出餘數 (可得知與哪個點能感應(相近))
            int remainder = pos % NODE_DISTRANCE;

            //判斷與哪個點相近
            
            if(remainder <= NODE_RADIUS) //如果能被感應,回傳點位置
            {
                return quotite;
            }
            else if(remainder>= NODE_DISTRANCE - NODE_RADIUS) //或是靠近另一個點
            {
                return quotite + 1;
            }
            else //無靠近任何點
            {
                return -1;
            }

        }
    }
}
