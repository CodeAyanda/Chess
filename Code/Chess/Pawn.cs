using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(int x, int y, bool white)
        {
            this.x = x;
            this.y = y;
            if (white)
            {
                this.white = true;
                this.image = new Bitmap("images/w_pawn.png");
            }
            else
            {
                this.white = false;
                this.image = new Bitmap("images/b_pawn.png");
            }
            this.cell = new Cell(x, y);
        }
        
    }
}
