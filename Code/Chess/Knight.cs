using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(int x, int y, bool white)
        {
            this.x = x;
            this.y = y;
            if (white)
            {
                this.white = true;
                this.image = new Bitmap("images/w_knight.png");
            }
            else
            {
                this.white = false;
                this.image = new Bitmap("images/b_knight.png");
            }
            this.cell = new Cell(x, y);
        }
    }
}
