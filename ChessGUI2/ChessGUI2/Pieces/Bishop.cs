using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class Bishop : Piece
    {
        private static int value = 3;

        public Bishop(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if (color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_bishop");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_bishop");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            #region Path Checking
            // Returns false if the new tile has a piece with the same color as the Bishop
            if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
            {
                if (board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == board.Grid[(int)oldPos.X][(int)oldPos.Y].TilePiece.PieceColor)
                {
                    return false;
                }
            }


            // When moving down right, returns false if any space between the old spot and new spot are occupied
            if (newPos.X > oldPos.X && newPos.Y > oldPos.Y)
            {
                int y = (int)oldPos.Y + 1;
                for (int x = (int)oldPos.X + 1; x < newPos.X; x++)
                {
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        if (board.Grid[x][y].TileIsOccupied)
                        {
                            return false;
                        }
                    }
                    y++;
                }
            }

            // When moving down left, returns false if any space between the old spot and new spot are occupied
            if (newPos.X < oldPos.X && newPos.Y > oldPos.Y)
            {
                int x = (int)oldPos.X - 1;
                for (int y = (int)oldPos.Y + 1; y < newPos.Y; y++)
                {
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        if (board.Grid[x][y].TileIsOccupied)
                        {
                            return false;
                        }
                    }
                    x--;
                }
            }

            // When moving up right, returns false if any space between the old spot and new spot are occupied
            if (newPos.X > oldPos.X && newPos.Y < oldPos.Y)
            {
                int y = (int)oldPos.Y - 1;
                for (int x = (int)oldPos.X + 1; x < newPos.X; x++)
                {
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        if (board.Grid[x][y].TileIsOccupied)
                        {
                            return false;
                        }
                    }
                    y--;
                }
            }

            // When moving up left, returns false if any space between the old spot and new spot are occupied
            if (newPos.X < oldPos.X && newPos.Y < oldPos.Y)
            {
                int y = (int)oldPos.Y - 1;
                for (int x = (int)oldPos.X - 1; x > newPos.X; x--)
                {
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        if (board.Grid[x][y].TileIsOccupied)
                        {
                            return false;
                        }
                    }
                    y--;
                }
            }
            #endregion

            #region Movement
            // Checks if the new spot is diagonal to the old spot
            if (Math.Abs(oldPos.X - newPos.X) == Math.Abs(oldPos.Y - newPos.Y))
            {
                return true;
            }
            #endregion

            return false;
        }
    }
}
