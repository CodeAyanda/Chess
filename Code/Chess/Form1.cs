using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        Pawn pawn;
        Rook rook;
        Knight knight;
        Bishop bishop;
        Queen queen;
        King king;
        //ArrayList blacks = new ArrayList();
        //ArrayList whites = new ArrayList();
        public static ArrayList pieces = new ArrayList();
        public static ArrayList whitePiecesOut = new ArrayList();
        public static ArrayList blackPiecesOut = new ArrayList();
        int minutes = 0;
        int seconds = 0;
        bool whitesTurn = true;

        public Form1()
        {
            InitializeComponent();
            Start();

        }

        public void Start()
        {
            //Add Pawns
            for (int i = 0; i < 8; i++)
            {
                int y = 1;
                pawn = new Pawn(i, y, true);
                pieces.Add(pawn);
                int y2 = 6;
                pawn = new Pawn(i, y2, false);
                pieces.Add(pawn);
            }

            //Add Rooks
            for (int i = 0; i < 2; i++)
            {
                int y = 0;
                rook = new Rook(i * 7, y, true);
                pieces.Add(rook);
                int y2 = 7;
                rook = new Rook(i * 7, y2, false);
                pieces.Add(rook);
            }

            //Add Knights
            for (int i = 1; i < 7; i+=5)
            {
                int y = 0;
                knight = new Knight(i, y, true);
                pieces.Add(knight);
                int y2 = 7;
                knight = new Knight(i, y2, false);
                pieces.Add(knight);
            }

            //Add Bishops
            for (int i = 2; i < 6; i += 3)
            {
                int y = 0;
                bishop = new Bishop(i, y, true);
                pieces.Add(bishop);
                int y2 = 7;
                bishop = new Bishop(i, y2, false);
                pieces.Add(bishop);
            }

            //Add Queens
            queen = new Queen(3, 0, true);
            pieces.Add(queen);
            queen = new Queen(3, 7, false);
            pieces.Add(queen);

            //Add Kings
            king = new King(4, 0, true);
            pieces.Add(king);
            king = new King(4, 7, false);
            pieces.Add(king);

        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Board.Show(g);
            //Show Pieces
            for (int i = 0; i < pieces.Count; i++)
            {
                Piece currentPawn = (Piece)pieces[i];
                currentPawn.Show(g);
            }
            //Show moves
            for (int i = 0; i < pieces.Count; i++)
            {
                Piece currentPawn = (Piece)pieces[i];
                currentPawn.ShowMoves(g);

            }

            Pen mypen = new Pen(Color.BurlyWood, 5);
            SolidBrush myfill = new SolidBrush(Color.DimGray);
            g.DrawRectangle(mypen, 850, 30, 660, 220);
            g.FillRectangle(myfill, 853, 33, 655, 215);
            g.DrawRectangle(mypen, 850, 600, 660, 220);
            g.FillRectangle(myfill, 853, 603, 655, 215);

            PiecesOut(g);

            //1552
            //880
            whitesTurnText.Location = new Point(850, 270);
            if (whitesTurn)
            {
                whitesTurnText.Visible = true;
                whitesTurnText.Text = "WHITE'S TURN";

            }
            else
            {
                whitesTurnText.Visible = false;
            }

            blacksTurnText.Location = new Point(850, 520);
            if (!whitesTurn)
            {
                blacksTurnText.Visible = true;
                blacksTurnText.Text = "BLACK'S TURN";

            }
            else
            {
                blacksTurnText.Visible = false;
            }

            label1.Text = $"{minutes.ToString("D2")} : {seconds.ToString("D2")}";

        }

        public void PiecesOut(Graphics g)
        {
            int bStartX = 850;
            int bStartY = 35;
            for (int i = 0; i < blackPiecesOut.Count; i++)
            {
                Piece current = (Piece)blackPiecesOut[i];
                current.x = bStartX;
                current.y = bStartY;
                current.ShowPiecesOut(g);
                Console.WriteLine(current.x);
                Console.WriteLine(current.y);
                
                bStartX += 80;
                if(bStartX >= 1420)
                {
                    bStartY += 100;
                    bStartX = 850;
                }
            }

            int wStartX = 850;
            int wStartY = 605;
            for (int i = 0; i < whitePiecesOut.Count; i++)
            {
                Piece current = (Piece)whitePiecesOut[i];
                current.x = wStartX;
                current.y = wStartY;
                current.ShowPiecesOut(g);
                Console.WriteLine(current.x);
                Console.WriteLine(current.y);

                wStartX += 80;
                if (wStartX >= 1420)
                {
                    wStartY += 100;
                    wStartX = 850;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        Piece selectedP;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var mouse = this.PointToClient(Cursor.Position);
            
            if(selectedP == null)
            {
                foreach (Piece item in pieces)
                {
                    //item.selected = false;
                    //item.readyToMove = false;
                    if (item.img.Contains(mouse) && item.white == whitesTurn)
                    {
                        item.selected = true;
                        selectedP = item;
                        selectedP.FindPossibleMoves(selectedP.white, selectedP.GetType());
                        selectedP.readyToMove = true;
                        
                    }
                    else
                    {
                        item.selected = false;
                    }
                }
            }
            else
            {
                if (selectedP.readyToMove)
                {
                    foreach (Point p in selectedP.possibleMoves)
                    {
                        Rectangle moveTo = new Rectangle(p.X * Piece.size + Board.offset, p.Y * Piece.size + Board.offset, 100, 100);
                        if (moveTo.Contains(mouse))
                        {
                            //CHOW PIECE 1st and then move
                            Piece chowedPiece = null;
                            for (int i = 0; i < pieces.Count; i++)
                            {
                                Piece current = (Piece)pieces[i];
                                if (current.x == p.X && current.y == p.Y)
                                {
                                    chowedPiece = current;
                                    selectedP.EatPiece(p.X, p.Y);
                                }
                            }

                            selectedP.x = p.X;
                            selectedP.y = p.Y;
                            selectedP.firstMove = false;
                            selectedP.readyToMove = false;
                            whitesTurn = !whitesTurn;

                            //Crown Pawn
                            if(selectedP.GetType() == typeof(Pawn) && selectedP.y == 7 && selectedP.white == true)
                            {
                                selectedP.CrownPawn(selectedP.x, selectedP.y, selectedP.white);
                            }
                            if (selectedP.GetType() == typeof(Pawn) && selectedP.y == 0 && selectedP.white == false)
                            {
                                selectedP.CrownPawn(selectedP.x, selectedP.y, selectedP.white);
                            }


                        }
                        
                    }
                    selectedP.possibleMoves.Clear();
                    selectedP.selected = false;
                    selectedP = null;
                }
                

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            if(seconds > 59)
            {
                minutes++;
                seconds = 0;
            }
        }
    }
}
