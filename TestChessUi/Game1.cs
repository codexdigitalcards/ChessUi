using ChessUi;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestChessUi
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : ChessUi.Game1
    {
        private KeyboardState oldState;

        public Game1() : base()
        {
            Properties = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText("Content/properties.json"));
            TextureSize = float.Parse(Properties["TextureSize"]);
        }

        protected override void Initialize()
        {
            base.Initialize();

            MouseInput.BoardClicked += TestClick;
            MouseInput.PromotionClicked += TestClick2;
            oldState = Keyboard.GetState();
        }

        public void TestClick(object sender, BoardClickedArgs args)
        {
            if (BoardUi.IsSquareLit(args.Rank, args.File))
            {
                BoardUi.UnHighlightSquare(args.Rank, args.File);
            }
            else
            {
                BoardUi.HighlightSquare(args.Rank, args.File);
            }
        }
        public void TestClick2(object sender, PromotionClickedArgs args)
        {
            System.Console.WriteLine(args.RowClicked);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            
            int rank = 1;
            int file = 0;
            foreach (Texture2D texture in PieceTexture.PieceTextures)
            {

                BoardUi.Pieces.Add(new PieceUi(texture, new Coordinate(rank, file)));
                if (rank < 8)
                {
                    rank++;
                }
                else
                {
                    rank = 1;
                    file++;
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                BoardUi.UnHighlightAllSquares();
            }
            if (oldState.IsKeyUp(Keys.P) && Keyboard.GetState().IsKeyDown(Keys.P))
            {
                if (BoardUi.ArePromotionPiecesShown)
                {
                    BoardUi.HidePromotionPieces();
                }
                else
                {
                    BoardUi.ShowPromotionPieces(new List<Texture2D>() {
                        PieceTexture.BlackQueen, PieceTexture.BlackKnight, PieceTexture.BlackRook
                    });
                }
            }
            oldState = Keyboard.GetState();

            base.Update(gameTime);
        }
    }
}
