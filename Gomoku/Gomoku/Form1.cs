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
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new BlackPiece(125, 125));
            this.Controls.Add(new WhitePiece(200, 200));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
