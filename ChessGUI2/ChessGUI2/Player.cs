using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2
{
    class Player
    {
        public bool IsTurn { get; set; }
        public string PlayerColor { get; }
        public List<Piece> PlayersPieces { get; set; } = new List<Piece>();
        public List<Piece> CapturedPieces { get; set; } = new List<Piece>();
        public List<Vector2> PlayersValidMoves { get; set; } = new List<Vector2>();

        public Player(string color, bool turn)
        {
            PlayerColor = color;
            IsTurn = turn;
        }

        public static void ChangeTurns(Player player1, Player player2)
        {
            if (player1.IsTurn)
            {
                player1.IsTurn = false;
                player2.IsTurn = true;
            }
            else
            {
                player2.IsTurn = false;
                player1.IsTurn = true;
            }
        }

        // Generates each players valid moves by checking if each piece in each player's piece list
        // can move to every spot on the board. If the piece can move to that spot, add it to the player's
        // valid move list as well as that pieces valid move list.
        public static void GenerateAllValidMoves(Board board, Player player1, Player player2)
        {
            // Clear valid move lists before generating.
            foreach(Piece piece in player1.PlayersPieces)
                piece.PiecesValidMoves.Clear();
            foreach (Piece piece in player2.PlayersPieces)
                piece.PiecesValidMoves.Clear();
            player1.PlayersValidMoves.Clear();
            player2.PlayersValidMoves.Clear();

            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    // Player 1 pieces
                    foreach(Piece piece in player1.PlayersPieces)
                    {
                        if (piece.IsValidMove(board, piece.PiecePosition, new Vector2(x, y)))
                        {
                            piece.PiecesValidMoves.Add(new Vector2(x, y));
                            player1.PlayersValidMoves.Add(new Vector2(x, y));
                        }
                    }
                    // Player 2 pieces
                    foreach(Piece piece in player2.PlayersPieces)
                    {
                        if(piece.IsValidMove(board, piece.PiecePosition, new Vector2(x, y)))
                        {
                            piece.PiecesValidMoves.Add(new Vector2(x, y));
                            player2.PlayersValidMoves.Add(new Vector2(x, y));
                        }
                    }
                }
            }
        }

        public static void DrawTurn(SpriteBatch spriteBatch, SpriteFont spriteFont, Player whitePlayer, Player blackPlayer)
        {
            if (whitePlayer.IsTurn)
            {
                spriteBatch.DrawString(spriteFont, "White to move", new Vector2(820, 50), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, "Black to move", new Vector2(820, 50), Color.Black);
            }
            spriteBatch.DrawString(spriteFont, "Test", new Vector2(50, 850), Color.Black);
        }
    }
}
