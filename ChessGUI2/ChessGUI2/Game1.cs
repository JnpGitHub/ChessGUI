using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ChessGUI2.Pieces;

namespace ChessGUI2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D pixel;
        MouseState mouseState;
        MouseState lastMouseState;

        #region Game Objects
        Board board1;

        Player whitePlayer, blackPlayer;

        Pawn whitePawn1, whitePawn2, whitePawn3, whitePawn4, whitePawn5, whitePawn6, whitePawn7, whitePawn8,
            blackPawn1, blackPawn2, blackPawn3, blackPawn4, blackPawn5, blackPawn6, blackPawn7, blackPawn8;

        Rook whiteRook1, whiteRook2, 
            blackRook1, blackRook2;

        Knight whiteKnight1, whiteKnight2, 
            blackKnight1, blackKnight2;

        Bishop whiteBishop1, whiteBishop2, 
            blackBishop1, blackBishop2;

        King whiteKing, blackKing;

        Queen whiteQueen, blackQueen;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            board1 = new Board(Content);
            whitePlayer = new Player("white", true);
            blackPlayer = new Player("black", false);

            #region Init Pawns
            whitePawn1 = new Pawn("white", board1, whitePlayer, new Vector2(0, 6), Content);
            whitePawn2 = new Pawn("white", board1, whitePlayer, new Vector2(1, 6), Content);
            whitePawn3 = new Pawn("white", board1, whitePlayer, new Vector2(2, 6), Content);
            whitePawn4 = new Pawn("white", board1, whitePlayer, new Vector2(3, 6), Content);
            whitePawn5 = new Pawn("white", board1, whitePlayer, new Vector2(4, 6), Content);
            whitePawn6 = new Pawn("white", board1, whitePlayer, new Vector2(5, 6), Content);
            whitePawn7 = new Pawn("white", board1, whitePlayer, new Vector2(6, 6), Content);
            whitePawn8 = new Pawn("white", board1, whitePlayer, new Vector2(7, 6), Content);

            blackPawn1 = new Pawn("black", board1, blackPlayer, new Vector2(0, 1), Content);
            blackPawn2 = new Pawn("black", board1, blackPlayer, new Vector2(1, 1), Content);
            blackPawn3 = new Pawn("black", board1, blackPlayer, new Vector2(2, 1), Content);
            blackPawn4 = new Pawn("black", board1, blackPlayer, new Vector2(3, 1), Content);
            blackPawn5 = new Pawn("black", board1, blackPlayer, new Vector2(4, 1), Content);
            blackPawn6 = new Pawn("black", board1, blackPlayer, new Vector2(5, 1), Content);
            blackPawn7 = new Pawn("black", board1, blackPlayer, new Vector2(6, 1), Content);
            blackPawn8 = new Pawn("black", board1, blackPlayer, new Vector2(7, 1), Content);
            #endregion
            #region Init Rooks
            whiteRook1 = new Rook("white", board1, whitePlayer, new Vector2(0, 7), Content);
            whiteRook2 = new Rook("white", board1, whitePlayer, new Vector2(7, 7), Content);
            blackRook1 = new Rook("black", board1, blackPlayer, new Vector2(0, 0), Content);
            blackRook2 = new Rook("black", board1, blackPlayer, new Vector2(7, 0), Content);
            #endregion
            #region Init Knights
            whiteKnight1 = new Knight("white", board1, whitePlayer, new Vector2(1, 7), Content);
            whiteKnight2 = new Knight("white", board1, whitePlayer, new Vector2(6, 7), Content);
            blackKnight1 = new Knight("black", board1, blackPlayer, new Vector2(1, 0), Content);
            blackKnight2 = new Knight("black", board1, blackPlayer, new Vector2(6, 0), Content);
            #endregion
            #region Init Bishops
            whiteBishop1 = new Bishop("white", board1, whitePlayer, new Vector2(2, 7), Content);
            whiteBishop2 = new Bishop("white", board1, whitePlayer, new Vector2(5, 7), Content);
            blackBishop1 = new Bishop("black", board1, blackPlayer, new Vector2(4, 3), Content);
            blackBishop2 = new Bishop("black", board1, blackPlayer, new Vector2(5, 0), Content);
            #endregion
            #region Init Kings
            whiteKing = new King("white", board1, whitePlayer, new Vector2(4, 7), Content);
            blackKing = new King("black", board1, blackPlayer, new Vector2(4, 0), Content);
            #endregion
            #region Init Queens
            whiteQueen = new Queen("white", board1, whitePlayer, new Vector2(3, 3), Content);
            blackQueen = new Queen("black", board1, blackPlayer, new Vector2(3, 0), Content);
            #endregion

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            // TODO: use this.Content to load your game content here
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
            int x = mouseState.X / 100, y = mouseState.Y / 100;
            Console.WriteLine("X: {0}, Y: {1}", x, y);

            // Checks if the left mouse button is clicked and that the click happened within the board boundaries.
            // If there is not already a selected piece and the piece's color matches the turn color, select the piece at the mouse position.
            // If a piece is already selected, check if the selected piece can move to the clicked position.
            // If the piece is moved to that position, deselect the piece, change turns, and regenerate each players valid moves.
            // If the piece doesn't move, deselect the piece and attempt to select the piece at the new position.
            if(mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released
                && mouseState.X >= 0 && mouseState.Y >= 0 && mouseState.X < 800 && mouseState.Y < 800)
            {
                if(Input.Selection == null)
                {
                    if (board1.Grid[x][y].TileIsOccupied && 
                    ((board1.Grid[x][y].TilePiece.PieceColor == "white" && whitePlayer.IsTurn) ||
                    (board1.Grid[x][y].TilePiece.PieceColor == "black" && blackPlayer.IsTurn)))
                    {
                        Input.Selection = board1.Grid[x][y].TilePiece;
                    }
                }
                else
                {
                    if(Input.Selection.MovePiece(board1, Input.Selection.PiecePosition, new Vector2(x, y)))
                    {
                        Input.Selection = null;
                        Player.ChangeTurns(whitePlayer, blackPlayer);
                        Player.GenerateAllValidMoves(board1, whitePlayer, blackPlayer);
                        Console.WriteLine();
                    }
                    else
                    {
                        Input.Selection = null;
                        Input.SelectPiece(board1, whitePlayer, blackPlayer);
                    }
                }
            }
            Console.WriteLine("Selection: " + Input.Selection);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            // TODO: Add your drawing code here

            board1.DrawBoard(spriteBatch, spriteFont);
            Input.DrawSelection(spriteBatch, pixel);
            //Input.DrawMousePosition(spriteBatch, pixel);
            Player.DrawTurn(spriteBatch, spriteFont, whitePlayer, blackPlayer);
            DrawCheck();

            spriteBatch.End();
            base.Draw(gameTime);
        }

        // Checks if either king is in the other players valid move list and draws a message informing the players
        public void DrawCheck()
        {
            if (blackPlayer.PlayersValidMoves.Contains(whiteKing.PiecePosition))
                spriteBatch.DrawString(spriteFont, "White in Check", new Vector2(820, 75), Color.Black);
            if (whitePlayer.PlayersValidMoves.Contains(blackKing.PiecePosition))
                spriteBatch.DrawString(spriteFont, "Black in Check", new Vector2(820, 75), Color.Black);
        }
    }
}
