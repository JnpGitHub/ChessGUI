using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI2
{
    class Tile
    {
        public Vector2 TilePosition { get; }

        public bool TileIsOccupied { get; set; } = false;
        public Piece TilePiece { get; set; } = null;

        private Texture2D tileTexture;

        public Tile(Vector2 position, ContentManager Content)
        {
            TilePosition = position;

            // If the tiles X and Y are both even or both odd, it is a white tile.
            if ((TilePosition.X % 2 == 0 && TilePosition.Y % 2 == 0) || (TilePosition.X % 2 != 0 && TilePosition.Y % 2 != 0))
            {
                tileTexture = Content.Load<Texture2D>("Tiles/white_tile");
            }
            else
            {
                tileTexture = Content.Load<Texture2D>("Tiles/black_tile");
            }
        }

        public void DrawTile(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.Draw(tileTexture, new Vector2(TilePosition.X * 100, TilePosition.Y * 100), Color.White);
            if(TilePiece != null) TilePiece.DrawPiece(spriteBatch);
        }
    }
}
