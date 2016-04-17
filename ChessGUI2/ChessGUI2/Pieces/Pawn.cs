using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2.Pieces
{
    class Pawn : Piece
    {
        private static int value = 1;

        public Pawn(string color, Board board, Player player, Vector2 position, ContentManager Content) : base(color, board, player, position, Content)
        {
            if(color == "white")
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/white_pawn");
            }
            else
            {
                PieceTexture = Content.Load<Texture2D>("Pieces/black_pawn");
            }
        }

        public override bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos)
        {
            #region Capturing
            //A pawn can move diagonally one tile forward if that new tile has an enemy piece
            if (PieceColor == "white")
            {
                if (oldPos.Y - newPos.Y == 1 && Math.Abs(oldPos.X - newPos.X) == 1 && 
                    board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied && board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == "black")
                {
                    return true;
                }
            }
            else
            {
                if (newPos.Y - oldPos.Y == 1 && Math.Abs(newPos.X - oldPos.X) == 1 && board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied && 
                    board.Grid[(int)newPos.X][(int)newPos.Y].TilePiece.PieceColor == "white")
                {
                    return true;
                }
            }
            #endregion

            #region Movement
            if (IsFirstMove)
            {
                if (PieceColor == "white")
                {
                    //If the white pawn has a different x, moved more than 2 spaces, or has a piece in front of it return false
                    if (oldPos.X != newPos.X || oldPos.Y - newPos.Y != 1 && oldPos.Y - newPos.Y != 2 || board.Grid[(int)oldPos.X][(int)oldPos.Y - 1].TileIsOccupied ||
                        board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
                    {
                        return false;
                    }
                }
                else
                {
                    //If the black pawn has a different x, moved more than 2 spaces, or has a piece in front of it return false
                    if (oldPos.X != newPos.X || newPos.Y - oldPos.Y != 1 && newPos.Y - oldPos.Y != 2 || board.Grid[(int)oldPos.X][(int)oldPos.Y + 1].TileIsOccupied ||
                        board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (PieceColor == "white")
                {
                    //If the white pawn has a different x, moved more than 1 space, or has a piece in front of it return false
                    if (oldPos.X != newPos.X || oldPos.Y - newPos.Y != 1 || board.Grid[(int)oldPos.X][(int)oldPos.Y - 1].TileIsOccupied)
                    {
                        return false;
                    }
                }
                else
                {
                    //If the black pawn has a different x, moved more than 1 space, or has a piece in front of it return false
                    if (oldPos.X != newPos.X || newPos.Y - oldPos.Y != 1 || board.Grid[(int)oldPos.X][(int)oldPos.Y + 1].TileIsOccupied)
                    {
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }
    }
}
