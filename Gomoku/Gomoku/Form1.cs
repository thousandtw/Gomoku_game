using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        //宣告自行建立的棋盤變數
        private Board board = new Board();

        //用於強制黑白交替
        private PieceType nextPieceType = PieceType.Black;


        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new BlackPiece(125, 125));
            //this.Controls.Add(new WhitePiece(200, 200));
        }

        // MouseEventArgs 紀錄滑鼠按下時的資訊
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = board.PlaceAPiece(e.X, e.Y, nextPieceType);

            //判斷點上有無棋子
            if (piece != null)
            {
                this.Controls.Add(piece);

                //如果為白棋,下個棋則黑(反之)
                if (nextPieceType == PieceType.Black)
                {
                    nextPieceType = PieceType.White;
                }
                else if (nextPieceType == PieceType.White)
                {
                    nextPieceType = PieceType.Black;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            //判斷游標是否在能感應區域,即為能放棋子處
            if (board.CanBePlaced(e.X, e.Y))
            {
                //如果為能放棋子處,即改變游標圖案
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
