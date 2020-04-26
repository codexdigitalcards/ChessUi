using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ChessUi
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static float TextureSize;

        protected GraphicsDeviceManager Graphics { get; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected BoardUi BoardUi { get; private set; }
        protected Dictionary<string, string> Properties { get; set; }
        protected MouseInput MouseInput { get; } = new MouseInput();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Graphics.PreferredBackBufferWidth = (int)TextureSize * (BoardUi.BoardWidth + 1);
            Graphics.PreferredBackBufferHeight = (int)TextureSize * BoardUi.BoardHeight;
            Graphics.ApplyChanges();

            BoardUi = new BoardUi(
                    Content.Load<Texture2D>(Properties["BlackSquare"]),
                    Content.Load<Texture2D>(Properties["WhiteSquare"]),
                    Content.Load<Texture2D>(Properties["BlackSquareLit"]),
                    Content.Load<Texture2D>(Properties["WhiteSquareLit"])
                );

            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            PieceTexture.Initialize(Content, Properties);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseInput.Update(Mouse.GetState(), BoardUi);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected sealed override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();
            Draw();
            SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected virtual void Draw()
        {
            BoardUi.Draw(SpriteBatch);
            foreach (PieceUi pieceUi in BoardUi.Pieces)
            {
                float column = (float)pieceUi.Coordinate.File;
                float row = BoardUi.RankToRow(pieceUi.Coordinate.Rank);
                SpriteBatch.Draw(
                    pieceUi.Texture, 
                    new Vector2(column * TextureSize, row * TextureSize), 
                    Color.White
                );
            }
        }
    }

    
}