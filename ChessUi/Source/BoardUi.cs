using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ChessUi
{
    public class BoardUi
    {
        public static readonly int BoardWidth = 8;
        public static readonly int BoardHeight = 8;

        private readonly Texture2D blackSquare;
        private readonly Texture2D whiteSquare;
        private readonly Texture2D litBlackSquare;
        private readonly Texture2D litWhiteSquare;
        private readonly bool[,] highlightMatrix = new bool[BoardHeight, BoardWidth];
        private readonly List<Coordinate> litSquares = new List<Coordinate>(BoardHeight * BoardWidth);

        public List<Texture2D> PromotionPieceTextures { get; private set; }
        public bool ArePromotionPiecesShown { get; set; } = false;
        public List<PieceUi> Pieces { get; } = new List<PieceUi>();

        public BoardUi(Texture2D blackSquare, Texture2D whiteSquare, Texture2D litBlackSquare, Texture2D litWhiteSquare)
        {
            this.blackSquare = blackSquare;
            this.whiteSquare = whiteSquare;
            this.litBlackSquare = litBlackSquare;
            this.litWhiteSquare = litWhiteSquare;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int rank = 1; rank <= BoardHeight; rank++)
            {
                for (int file = 0; file < BoardWidth; file++)
                {
                    Texture2D currentTexture;
                    if ((rank + file) % 2 == 0)
                    {
                        if (litSquares.Contains(new Coordinate(rank, file)))
                        {
                            currentTexture = litWhiteSquare;
                        }
                        else
                        {
                            currentTexture = whiteSquare;
                        }
                    }
                    else
                    {
                        if (litSquares.Contains(new Coordinate(rank, file)))
                        {
                            currentTexture = litBlackSquare;
                        }
                        else
                        {
                            currentTexture = blackSquare;
                        }
                    }
                    
                    spriteBatch.Draw(
                        currentTexture, 
                        new Vector2(file * Game1.TextureSize, RankToRow(rank) * Game1.TextureSize), 
                        Color.White
                    );
                }
            }

            if (ArePromotionPiecesShown)
            {
                for (int x = 0; x < PromotionPieceTextures.Count; x++)
                {
                    spriteBatch.Draw(PromotionPieceTextures[x], new Vector2(BoardWidth * Game1.TextureSize, x * Game1.TextureSize), Color.White);
                }
            }
        }

        public void HighlightSquare(int rank, int file)
        {
            if (!IsSquareLit(rank, file))
            {
                litSquares.Add(new Coordinate(rank, file));
            }
        }
        
        public void UnHighlightSquare(int rank, int file)
        {
            if (IsSquareLit(rank, file))
            {
                litSquares.Remove(new Coordinate(rank, file));
            }
        }

        public bool IsSquareLit(int rank, int file)
        {
            return litSquares.Contains(new Coordinate(rank, file));
        }

        public void UnHighlightAllSquares()
        {
            litSquares.Clear();
        }

        public void ShowPromotionPieces(List<Texture2D> pieceTextures)
        {
            PromotionPieceTextures = new List<Texture2D>(pieceTextures);
            ArePromotionPiecesShown = true;
        }

        public void HidePromotionPieces()
        {
            ArePromotionPiecesShown = false;
        }

        public static int RowToRank(int row)
        {
            return Math.Abs(row - BoardUi.BoardHeight);
        }

        public static int RankToRow(int rank)
        {
            return Math.Abs(rank - BoardHeight);
        }
    }
}
