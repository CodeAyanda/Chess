using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(int x, int y, bool white)
        {
            this.x = x;
            this.y = y;
            if (white)
            {
                this.white = true;
                this.image = new Bitmap("images/w_bishop.png");
            }
            else
            {
                this.white = false;
                this.image = new Bitmap("images/b_bishop.png");
            }
            this.cell = new Cell(x, y);
        }
    }
}
