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
        //用於強制黑白交替
       private bool isblack = true;

        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new BlackPiece(125, 125));
            //this.Controls.Add(new WhitePiece(200, 200));
        }

        // MouseEventArgs 紀錄滑鼠按下時的資訊
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isblack)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                isblack = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                isblack = true;
            }
            
        }
    }
}
