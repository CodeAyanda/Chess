using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        public King(int x, int y, bool white)
        {
            this.x = x;
            this.y = y;
            if (white)
            {
                this.white = true;
                this.image = new Bitmap("images/w_king.png");
            }
            else
            {
                this.white = false;
                this.image = new Bitmap("images/b_king.png");
            }
            this.cell = new Cell(x, y);
        }
    }
}
