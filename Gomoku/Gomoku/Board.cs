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
        //棋盤單方向最大格數 
        public static readonly int NODE_COUNT = 9;
        //宣告一個沒有在棋盤上的點
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        //棋盤邊距
        private static readonly int OFFSET = 75;
        //點能感應距離(半徑)
        private static readonly int NODE_RADIUS = 10;
        //點與點的距離
        private static readonly int NODE_DISTRANCE = 75;
        //棋子的資料結構
        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];
        
        //判斷最後下棋
        private Point lastPlacenode = NO_MATCH_NODE;
        public Point LastPlacenode
        {
            get { return lastPlacenode ;} 
        }

        //判斷已在點上的棋子顏色
        public PieceType GetPieceType(int nodeldX, int nodeldY)
        {
            if(pieces[nodeldX, nodeldY] == null)
            {
                return PieceType.None;
            }
            else
            {
                return pieces[nodeldX, nodeldY].GetPieceType();
            }
        }

        //使棋子按照點放置,並檢查
        public bool CanBePlaced(int x, int y)
        {
            //找出最近的節點 (NODE)
            Point nodeld = findTheCloseNode(x, y);

            //如果沒有的話,回傳 false
            if (nodeld == NO_MATCH_NODE)
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

        //檢查點後,放黑或白棋
        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            //找出最近的節點 (NODE)
            Point nodeld = findTheCloseNode(x, y);

            //如果沒有的話,回傳 null
            if (nodeld == NO_MATCH_NODE)
            {
                return null;
            }

            //檢查棋子是否存在點上,有則回傳null
            if (pieces[nodeld.X, nodeld.Y] != null)
            {
                return null;
            }

            //根據TYPE產生對應的棋子
            Point formPos = convertToPosition(nodeld);//換成精準的視窗位置
            if (type == PieceType.Black)
            {
                pieces[nodeld.X, nodeld.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else if (type == PieceType.White)
            {
                pieces[nodeld.X, nodeld.Y] = new WhitePiece(formPos.X, formPos.Y);
            }

            //紀錄最後下棋的位置
             lastPlacenode = nodeld;

            //回傳棋子位置
            return pieces[nodeld.X, nodeld.Y];

        }

        //將回傳的棋盤位置轉換成精準的視窗位置
        private Point convertToPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTRANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTRANCE + OFFSET;
            return formPosition;
        }

        //二維判斷方法
        private Point findTheCloseNode(int x, int y)
        {
            //判斷X靠近哪個點,有則存入位置,無則回傳不存在的點
            int nodeldX = findTheCloseNode(x);
            if (nodeldX == -1 || nodeldX >= NODE_COUNT) //需求0~8(第一個為0)
            {
                return NO_MATCH_NODE;
            }

            //判斷Y靠近哪個點,有則存入位置,無則回傳不存在的點
            int nodeldY = findTheCloseNode(y);
            if (nodeldY == -1 || nodeldY >= NODE_COUNT) //需求0~8(第一個為0)
            {
                return NO_MATCH_NODE;
            }

            //回傳存入的座標
            return new Point(nodeldX, nodeldY);
        }

        //一維判斷方法 // (pos為點到棋盤邊的距離)
        private int findTheCloseNode(int pos)
        {
            //判斷如果游標下棋位置在棋盤線外,則回傳負值
            if (pos < OFFSET - NODE_RADIUS)
            {
                return -1;
            }

            //扣除棋盤邊距
            pos -= OFFSET;

            //取出商數 (可得知為第幾個點)
            int quotite = pos / NODE_DISTRANCE;

            //取出餘數 (可得知與哪個點能感應(相近))
            int remainder = pos % NODE_DISTRANCE;

            //判斷與哪個點相近

            if (remainder <= NODE_RADIUS) //如果能被感應,回傳點位置
            {
                return quotite;
            }
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS) //或是靠近另一個點
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
