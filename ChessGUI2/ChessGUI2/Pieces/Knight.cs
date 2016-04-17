using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class Knight : Piece
    {
        private static int value = 3;

        public Knight(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if (color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_knight");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_knight");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            #region Path Checking
            // Returns false if the Knight tries to move to a space with a piece of the same color.
            if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
            {
                if (board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == board.Grid[(int)oldPos.X][(int)oldPos.Y].TilePiece.PieceColor)
                {
                    return false;
                }
            }
            #endregion

            #region Movement
            // Returns false if the Knight tries to move horizontally or vertically.
            if (oldPos.X == newPos.X || oldPos.Y == newPos.Y)
            {
                return false;
            }

            // Returns false if the Knight tries to move more than two spaces.
            if (Math.Abs(oldPos.X - newPos.X) > 2 || Math.Abs(oldPos.Y - newPos.Y) > 2)
            {
                return false;
            }

            // Returns true if the Knight isn't trying to move diagonally.
            if (Math.Abs(oldPos.X - newPos.X) - Math.Abs(oldPos.Y - newPos.Y) == 1 || Math.Abs(oldPos.X - newPos.X) - Math.Abs(oldPos.Y - newPos.Y) == -1)
            {
                return true;
            }
            #endregion

            return false;
        }
    }
}
