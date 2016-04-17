using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2
{
    abstract class Input
    {
        public static Vector2 MousePosition { get; set; }
        private static Vector2 MouseTexturePosition;

        public static Piece Selection { get; set; } = null;

        public static Vector2 GetMousePosition(Board board)
        {
            if (MousePosition.X < 8 && MousePosition.Y < 8 && MousePosition.X >= 0 && MousePosition.Y >= 0)
            {
                MouseTexturePosition = board.Grid[(int)MousePosition.X][(int)MousePosition.Y].TilePosition * 100; 
            }
            return MouseTexturePosition;
        }

        // If the tile clicked has a piece and if that piece's color matches the player whos turn it is,
        // set the selected piece to the piece clicked.
        public static void SelectPiece(Board board, Player whitePlayer, Player blackPlayer)
        {
            if (board.Grid[(int)MousePosition.X][(int)MousePosition.Y].TilePiece != null && 
                ((board.Grid[(int)MousePosition.X][(int)MousePosition.Y].TilePiece.PieceColor == "white" &&
                whitePlayer.IsTurn) ||
                (board.Grid[(int)MousePosition.X][(int)MousePosition.Y].TilePiece.PieceColor == "black" &&
                blackPlayer.IsTurn)))
            {
                Selection = board.Grid[(int)MousePosition.X][(int)MousePosition.Y].TilePiece;
                Console.WriteLine("Selection: " + Selection);
            }
        }

        public static void DrawMousePosition(SpriteBatch spriteBatch, Texture2D pixel)
        {
            int x = (int)MouseTexturePosition.X;
            int y = (int)MouseTexturePosition.Y;
            spriteBatch.Draw(pixel, new Rectangle(x, y, 100, 2), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(x, y, 2, 100), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(x + 98, y, 2, 100), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(x, y + 98, 100, 2), Color.Red);
        }

        public static void DrawSelection(SpriteBatch spriteBatch, Texture2D pixel)
        {
            if(Selection != null)
            {
                int x = (int)Selection.PiecePosition.X * 100;
                int y = (int)Selection.PiecePosition.Y * 100;
                spriteBatch.Draw(pixel, new Rectangle(x, y, 98, 2), Color.Blue);
                spriteBatch.Draw(pixel, new Rectangle(x, y, 2, 100), Color.Blue);
                spriteBatch.Draw(pixel, new Rectangle(x + 98, y, 2, 100), Color.Blue);
                spriteBatch.Draw(pixel, new Rectangle(x, y + 98, 100, 2), Color.Blue);
            }
        }
    }
}
