using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class King : Piece
    {
        public King(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if (color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_king");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_king");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            

            #region Movement
            // Returns false if the king is moving right or left (x coordinate changes) and the move isn't one space.
            if (newPos.X != oldPos.X && Math.Abs(newPos.X - oldPos.X) != 1)
            {
                return false;
            }

            // Returns false if the king is moving up or down (y coordinate changes) and the move isn't one space.
            if (newPos.Y != oldPos.Y && Math.Abs(newPos.Y - oldPos.Y) != 1)
            {
                return false;
            }
            #endregion

            #region Path Checking
            // Returns false if the new tile has a piece with the same color as the moving piece
            if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
            {
                if (board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == board.Grid[(int)oldPos.X][(int)oldPos.Y].TilePiece.PieceColor)
                {
                    return false;
                }
            }
            #endregion
            return true;
        }
    }
}
