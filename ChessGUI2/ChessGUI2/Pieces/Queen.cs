using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class Queen : Piece
    {
        private static int value = 9;

        public Queen(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if (color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_queen");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_queen");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            #region Path Checking
            // Returns false if the new tile has a piece with the same color as the Queen
            if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
            {
                if (board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == board.Grid[(int)oldPos.X][(int)oldPos.Y].TilePiece.PieceColor)
                {
                    return false;
                }
            }

            // When moving right, returns false if any space between the old location and new location are occupied
            if (newPos.X > oldPos.X && newPos.Y == oldPos.Y)
            {
                for (int i = (int)oldPos.X + 1; i < newPos.X; i++)
                {
                    if (board.Grid[i][(int)oldPos.Y].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }

            // When moving left, returns false if any space between the old location and the new location are occupied
            if (newPos.X < oldPos.X && newPos.Y == oldPos.Y)
            {
                for (int i = (int)oldPos.X - 1; i > newPos.X; i--)
                {
                    if (board.Grid[i][(int)oldPos.Y].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }

            // When moving down, returns false if any space between the old location and the new location are occupied
            if (newPos.Y > oldPos.Y && newPos.X == oldPos.X)
            {
                for (int i = (int)oldPos.Y + 1; i < newPos.Y; i++)
                {
                    if (board.Grid[(int)oldPos.X][i].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }

            // When moving up, returns false if any space between the old location and the new location are occupied
            if (newPos.Y < oldPos.Y && newPos.X == oldPos.X)
            {
                for (int i = (int)oldPos.Y - 1; i > newPos.Y; i--)
                {
                    if (board.Grid[(int)oldPos.X][i].TileIsOccupied)
                    {
                        return false;
                    }
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
            // Return true if the Queen is trying to move vertically or horizontally
            if (Math.Abs(oldPos.X - newPos.X) == Math.Abs(oldPos.Y - newPos.Y) || oldPos.X == newPos.X || oldPos.Y == newPos.Y)
            {
                return true;
            }
            #endregion

            return false;
        }
    }
}
