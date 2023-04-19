using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(int x, int y, bool white)
        {
            this.x = x;
            this.y = y;
            if (white)
            {
                this.white = true;
                this.image = new Bitmap("images/w_rook.png");
            }
            else
            {
                this.white = false;
                this.image = new Bitmap("images/b_rook.png");
            }
            this.cell = new Cell(x, y);
        }
    }
}
