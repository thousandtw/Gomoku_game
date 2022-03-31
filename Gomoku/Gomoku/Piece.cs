using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
   abstract class Piece : PictureBox
    {
        //指定邊長常數(更改圖片大小不用更改下方值) (static readonly確保為常數)
        private static readonly int IMAGE_WIDTH =50;

        //基底類別的建構子
        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            //使座標依圖片大小橫移.達到點下位置正確
            this.Location = new Point(x-IMAGE_WIDTH/2, y-IMAGE_WIDTH / 2);
            this.Size = new Size (IMAGE_WIDTH, IMAGE_WIDTH);
        }
    }
}
