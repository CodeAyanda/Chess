using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Board
    {
        static int cols = 8; 
        static int rows = 8;
        static int cellSize = 100;
        public static int offset = 25;
        static int fillOffset = 3;
        static Cell[,] cells = new Cell[cols * rows, cols * rows];

        public static void Show(Graphics g)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Cell newCell = new Cell(i, j);
                    cells[i, j] = newCell;
                    cells[i, j].Show(g);

                }
            }
        }
    }

    class Cell
    {
        public int x;
        public int y;
        static int cellSize = 100;
        public static int offset = 25;
        static int fillOffset = 3;
        Piece pieceOnCell = null;


        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(Color.FromArgb(81, 42, 42));
            SolidBrush brush2 = new SolidBrush(Color.FromArgb(124, 76, 42));

            //g.DrawRectangle(pen, (x * cellSize) + offset, (y * cellSize) + offset, cellSize, cellSize);
            if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
            {
                g.FillRectangle(brush, (y * cellSize) + offset + fillOffset, (x * cellSize) + offset + fillOffset, cellSize - fillOffset - 2, cellSize - fillOffset - 2);
            }
            else
            {
                g.FillRectangle(brush2, (y * cellSize) + offset + fillOffset, (x * cellSize) + offset + fillOffset, cellSize - fillOffset - 2, cellSize - fillOffset - 2);

            }
        }
    }
}
