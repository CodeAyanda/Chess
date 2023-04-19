using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Piece
    {
        public int x;
        public int y;
        public Cell cell;
        public Bitmap image;
        public Rectangle img;
        public bool white;
        public static int size = 100;
        public List<Point> possibleMoves = new List<Point>();
        //public List<Cell> possibleMoves = new List<Cell>();

        public bool selected = false;
        public bool firstMove = true;
        public bool readyToMove = false;



        public Piece()
        {

        }

        public void Show(Graphics g)
        {
            img = new Rectangle(x * size + Board.offset, y * size + Board.offset, size, size);
            g.DrawImage(image, img);
            if (selected)
            {
                Pen moves = new Pen(Color.Red, 3);
                g.DrawRectangle(moves, x * size + Board.offset+3, y * size + Board.offset+3, 95, 95);

            }
        }

        public void ShowPiecesOut(Graphics g)
        {
            img = new Rectangle(x, y, size, size);
            g.DrawImage(image, img);

        }

        public void ShowMoves(Graphics g)
        {
            Pen moves = new Pen(Color.Black, 7);
            SolidBrush movesBrush = new SolidBrush(Color.LimeGreen);
            int moveOffset = 25;
            foreach (var point in possibleMoves)
            {
                if (selected)
                {
                    g.DrawEllipse(moves, point.X * size + Board.offset + moveOffset, point.Y * size + Board.offset + moveOffset, 50, 50);
                    g.FillEllipse(movesBrush, point.X * size + Board.offset + moveOffset, point.Y * size + Board.offset + moveOffset, 50, 50);
                }
            }
        }

        public bool isValidMove(int x, int y, bool white)
        {
            if(x < 0 || y < 0)
            {
                return false;
            }else if(x > 7 || y > 7)
            {
                return false;
            }else if (white)
            {
                for (int i = 0; i < Form1.pieces.Count; i++)
                {
                    Piece thisPiece = (Piece)Form1.pieces[i];
                    if(thisPiece.x == x && thisPiece.y == y && thisPiece.white)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (white == false)
            {
                for (int i = 0; i < Form1.pieces.Count; i++)
                {
                    Piece thisPiece = (Piece)Form1.pieces[i];
                    if (thisPiece.x == x && thisPiece.y == y && thisPiece.white == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool? isPieceWhite(int x, int y)
        {
            Piece thisPiece = null;

            for (int i = 0; i < Form1.pieces.Count; i++)
            {
                thisPiece = (Piece)Form1.pieces[i];
                if (thisPiece.x == x && thisPiece.y == y)
                {
                    return thisPiece.white;
                }

            }
            return null;
            
        }

        public void EatPiece(int x, int y)
        {
            for (int i = 0; i < Form1.pieces.Count; i++)
            {
                Piece toRemove = (Piece)Form1.pieces[i];
                if(toRemove.x == x && toRemove.y == y)
                {
                    if (toRemove.white)
                    {
                        Form1.whitePiecesOut.Add(toRemove);
                    }
                    else
                    {
                        Form1.blackPiecesOut.Add(toRemove);
                    }
                    Form1.pieces.RemoveAt(i);
                }
            }
        }

        public void CrownPawn(int x, int y, bool white)
        {
            for (int i = 0; i < Form1.pieces.Count; i++)
            {
                Piece current = (Piece)Form1.pieces[i];
                if(current.x == x && current.y == y)
                {
                    Form1.pieces.RemoveAt(i);
                    Form1.pieces.Add(new Queen(x, y, white));
                }

            }


        }

        public void FindPossibleMoves(bool white, Type mytype)
        {
            if(mytype == typeof(Pawn))
            {
                if (firstMove && selected)
                {
                    int sign;
                    if (white)
                    {
                        sign = 1;
                    }
                    else
                    {
                        sign = -1;
                    }
                    possibleMoves.Clear();
                    Point move = new Point(this.x, this.y + 1*sign);
                    if(isValidMove(this.x, this.y + 1 * sign, white))
                    {
                        if(isPieceWhite(this.x, this.y + 1 * sign) == null)
                        {
                            possibleMoves.Add(move);

                        }

                    }
                    move = new Point(this.x, this.y + 2*sign);
                    if(isValidMove(this.x, this.y + 2 * sign, white))
                    {
                        if(isPieceWhite(this.x, this.y + 1 * sign) == null && isPieceWhite(this.x, this.y + 2 * sign) == null)
                        {
                            possibleMoves.Add(move);

                        }

                    }
                    //firstMove = false;



                    //Pawn Eats Diagonals
                    if (white && isPieceWhite(this.x - 1, this.y + 1) == false)
                    {
                        move = new Point(this.x - 1, this.y + 1);
                        possibleMoves.Add(move);
                    }
                    if (white && isPieceWhite(this.x + 1, this.y + 1) == false)
                    {
                        move = new Point(this.x + 1, this.y + 1);
                        possibleMoves.Add(move);
                    }
                    if (white == false && isPieceWhite(this.x + 1, this.y - 1) == true)
                    {
                        move = new Point(this.x + 1, this.y - 1);
                        possibleMoves.Add(move);
                    }
                    if (white == false && isPieceWhite(this.x - 1, this.y - 1) == true)
                    {
                        move = new Point(this.x - 1, this.y - 1);
                        possibleMoves.Add(move);
                    }




                }
                else if (!firstMove && selected)
                {
                    int sign;
                    if (white)
                    {
                        sign = 1;
                    }
                    else
                    {
                        sign = -1;
                    }
                    possibleMoves.Clear();
                    Point move = new Point(this.x, this.y + 1*sign);
                    if(isValidMove(this.x, this.y + 1 * sign, white))
                    {
                        if (isPieceWhite(this.x, this.y + 1 * sign)==null)
                        {
                            possibleMoves.Add(move);
                        }

                    }


                    //Pawn Eats Diagonals
                    if (white && isPieceWhite(this.x - 1, this.y + 1) == false)
                    {
                        move = new Point(this.x - 1, this.y + 1);
                        possibleMoves.Add(move);
                    }
                    if (white && isPieceWhite(this.x + 1, this.y + 1) == false)
                    {
                        move = new Point(this.x + 1, this.y + 1);
                        possibleMoves.Add(move);
                    }
                    if (white == false && isPieceWhite(this.x + 1, this.y - 1) == true)
                    {
                        move = new Point(this.x + 1, this.y - 1);
                        possibleMoves.Add(move);
                    }
                    if (white == false && isPieceWhite(this.x - 1, this.y - 1) == true)
                    {
                        move = new Point(this.x - 1, this.y - 1);
                        possibleMoves.Add(move);
                    }

                }
                else
                {
                    possibleMoves.Clear();
                }
                
            }

            if(mytype == typeof(Knight))
            {
                if (selected)
                {
                    possibleMoves.Clear();
                    Point move = new Point(this.x+1, this.y + 2);
                    Point move2 = new Point(this.x + 1, this.y - 2);
                    if(isValidMove(move.X, move.Y, white))
                    {
                        possibleMoves.Add(move);
                    }
                    if(isValidMove(move2.X, move2.Y, white))
                    {
                        possibleMoves.Add(move2);
                    }

                    move = new Point(this.x - 1, this.y + 2);
                    move2 = new Point(this.x - 1, this.y - 2);
                    if (isValidMove(move.X, move.Y, white))
                    {
                        possibleMoves.Add(move);
                    }
                    if (isValidMove(move2.X, move2.Y, white))
                    {
                        possibleMoves.Add(move2);
                    }

                    move = new Point(this.x + 2, this.y - 1);
                    move2 = new Point(this.x - 2, this.y - 1);
                    if (isValidMove(move.X, move.Y, white))
                    {
                        possibleMoves.Add(move);
                    }
                    if (isValidMove(move2.X, move2.Y, white))
                    {
                        possibleMoves.Add(move2);
                    }

                    move = new Point(this.x + 2, this.y + 1);
                    move2 = new Point(this.x - 2, this.y + 1);
                    if (isValidMove(move.X, move.Y, white))
                    {
                        possibleMoves.Add(move);
                    }
                    if (isValidMove(move2.X, move2.Y, white))
                    {
                        possibleMoves.Add(move2);
                    }
                }
            }

            if(mytype == typeof(Rook))
            {
                if (selected)
                {
                    //straight down
                    possibleMoves.Clear();
                    for (int i = this.y+1; i < 8; i++)
                    {
                        Point move = new Point(this.x, i);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if(!canAdd)
                        {
                            break;
                        }
                    }

                    //straight up
                    for (int i = this.y - 1; i >= 0; i--)
                    {
                        Point move = new Point(this.x, i);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //straight right
                    for (int i = this.x + 1; i < 8; i++)
                    {
                        Point move = new Point(i, this.y);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //straight left
                    for (int i = this.x - 1; i >= 0; i--)
                    {
                        Point move = new Point(i, this.y);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                }

            }

            if(mytype == typeof(Bishop))
            {
                
                if (selected)
                {
                    possibleMoves.Clear();
                    //Top Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if(i == j)
                            {
                                Point move = new Point(this.x-i, this.y-j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    //continue;
                                    goto GETOUT;

                                }
                            }
                        }
                        
                    }
                    GETOUT:
                    //Top right
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x + i, this.y - j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT2;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    goto GETOUT2;
                                }
                            }
                        }

                    }
                    GETOUT2:
                    //Bottom Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x - i, this.y + j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT3;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    goto GETOUT3;
                                }
                            }
                        }

                    }
                    GETOUT3:
                    //Bottom Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x + i, this.y + j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    return;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    return;
                                }
                            }
                        }

                    }


                }
            }

            if(mytype == typeof(Queen))
            {
                if (selected)
                {
                    possibleMoves.Clear();
                    for (int i = this.y + 1; i < 8; i++)
                    {
                        Point move = new Point(this.x, i);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //straight up
                    for (int i = this.y - 1; i >= 0; i--)
                    {
                        Point move = new Point(this.x, i);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //straight right
                    for (int i = this.x + 1; i < 8; i++)
                    {
                        Point move = new Point(i, this.y);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //straight left
                    for (int i = this.x - 1; i >= 0; i--)
                    {
                        Point move = new Point(i, this.y);
                        bool canAdd = isValidMove(move.X, move.Y, white);
                        if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                        {
                            possibleMoves.Add(move);
                            break;
                        }
                        else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                        {
                            possibleMoves.Add(move);

                        }
                        else if (!canAdd)
                        {
                            break;
                        }
                    }

                    //Top Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x - i, this.y - j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    //continue;
                                    goto GETOUT;

                                }
                            }
                        }

                    }
                    GETOUT:
                    //Top right
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x + i, this.y - j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT2;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    goto GETOUT2;
                                }
                            }
                        }

                    }
                    GETOUT2:
                    //Bottom Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x - i, this.y + j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    goto GETOUT3;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    goto GETOUT3;
                                }
                            }
                        }

                    }
                    GETOUT3:
                    //Bottom Left
                    for (int i = 1; i < 8; i++)
                    {
                        for (int j = 1; j < 8; j++)
                        {
                            if (i == j)
                            {
                                Point move = new Point(this.x + i, this.y + j);

                                bool canAdd = isValidMove(move.X, move.Y, white);
                                if (canAdd && isPieceWhite(move.X, move.Y) == !white)
                                {
                                    possibleMoves.Add(move);
                                    return;
                                }
                                else if (canAdd && isPieceWhite(move.X, move.Y) == null)
                                {
                                    possibleMoves.Add(move);

                                }
                                else if (!canAdd)
                                {
                                    return;
                                }
                            }
                        }

                    }
                }
            }

            if(mytype == typeof(King))
            {
                if (selected)
                {
                    possibleMoves.Clear();
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            Point move = new Point(this.x + i, this.y + j);
                            bool canAdd = isValidMove(move.X, move.Y, white);
                            if (canAdd)
                            {
                                possibleMoves.Add(move);
                            }

                        }

                    }
                }
            }

        }
    }

    
}
