using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class Rook : Piece
    {
        private static int value = 5;

        public Rook(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if (color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_rook");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_rook");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            // Returns false if the new tile has a piece with the same color as the Rook
            if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
            {
                if (board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == board.Grid[(int)oldPos.X][(int)oldPos.Y].TilePiece.PieceColor)
                {
                    return false;
                }
            }

            // When moving right, returns false if any space between the old location and new location are occupied
            if (newPos.X > oldPos.X)
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
            if (newPos.X < oldPos.X)
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
            if (newPos.Y > oldPos.Y)
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
            if (newPos.Y < oldPos.Y)
            {
                for (int i = (int)oldPos.Y - 1; i > newPos.Y; i--)
                {
                    if (board.Grid[(int)oldPos.X][i].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }

            // Returns true if the new space is horizontal or vertical from the old space
            if (oldPos.X == newPos.X || oldPos.Y == newPos.Y)
            {
                return true;
            }

            return false;
        }
    }
}
