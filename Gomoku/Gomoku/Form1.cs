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
        private GameMaster game = new GameMaster();

        public Form1()
        {
            InitializeComponent();
        }

        // MouseEventArgs 紀錄滑鼠按下時的資訊
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            //判斷點上有無棋子
            if (piece != null)
            {
                this.Controls.Add(piece);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //判斷游標是否在能感應區域,即為能放棋子處
            if (game.CanBePlaced(e.X, e.Y))
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
