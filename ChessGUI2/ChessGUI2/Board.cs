using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2
{
    class Board
    {
        public List<List<Tile>> Grid { get; } = new List<List<Tile>>();

        public Board(ContentManager Content)
        {
            for(int x = 0; x < 8; x++)
            {
                Grid.Add(new List<Tile>());
                for(int y = 0; y < 8; y++)
                {
                    Grid[x].Add(new Tile(new Vector2(x, y), Content));
                }
            }
        }

        public void SetPiece(Piece piece, Vector2 position)
        {
            Grid[(int)position.X][(int)position.Y].TilePiece = piece;
            Grid[(int)position.X][(int)position.Y].TileIsOccupied = true;
            Grid[(int)position.X][(int)position.Y].TilePiece.PiecePosition = position;
        }

        public void RemovePiece(Vector2 position)
        {
            Grid[(int)position.X][(int)position.Y].TilePiece = null;
            Grid[(int)position.X][(int)position.Y].TileIsOccupied = false;
        }

        public void DrawBoard(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    Grid[x][y].DrawTile(spriteBatch, spriteFont);
                }
            }
        }
    }
}
