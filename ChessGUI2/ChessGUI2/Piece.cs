using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2
{
    abstract class Piece
    {
        public Vector2 PiecePosition { get; set; }
        public string PieceColor { get; }
        public Texture2D PieceTexture { get; set; }
        public List<Vector2> PiecesValidMoves { get; set; } = new List<Vector2>();
        public bool IsFirstMove { get; set; } = true;

        public Piece(string color, Board board, Player player, Vector2 position, ContentManager Content)
        {
            PieceColor = color;
            PiecePosition = position;
            player.PlayersPieces.Add(this);
            board.SetPiece(this, position);
        }

        // Each piece has this method that checks if the piece can move
        // from the old position to the new position.
        public abstract bool IsValidMove(Board board, Vector2 oldPos, Vector2 newPos);

        // Checks if the piece can move from the old position to the new position
        // using the IsValidMove method and moves the piece if true is returned.
        // Returns true if the piece was moved and false if it wasnt.
        public bool MovePiece(Board board, Vector2 oldPos, Vector2 newPos)
        {
            if (board.Grid[(int)oldPos.X][(int)oldPos.Y].TileIsOccupied)
            {
                if(IsValidMove(board, oldPos, newPos))
                {
                    if (board.Grid[(int)newPos.X][(int)newPos.Y].TileIsOccupied)
                    {
                        board.RemovePiece(newPos);
                    }
                    board.SetPiece(this, newPos);
                    board.RemovePiece(oldPos);
                    IsFirstMove = false;
                    return true;
                }
            }
            return false;
        }



        public void DrawPiece(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PieceTexture, new Vector2(PiecePosition.X * 100, PiecePosition.Y * 100), Color.White);
        }
    }
}
