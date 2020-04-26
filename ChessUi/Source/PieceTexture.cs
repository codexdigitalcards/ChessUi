using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ChessUi
{
    public static class PieceTexture
    {
        public static Texture2D BlackPawn { get; private set; }
        public static Texture2D BlackKnight { get; private set; }
        public static Texture2D BlackBishop { get; private set; }
        public static Texture2D BlackRook { get; private set; }
        public static Texture2D BlackQueen { get; private set; }
        public static Texture2D BlackKing { get; private set; }
        public static Texture2D WhitePawn { get; private set; }
        public static Texture2D WhiteKnight { get; private set; }
        public static Texture2D WhiteBishop { get; private set; }
        public static Texture2D WhiteRook { get; private set; }
        public static Texture2D WhiteQueen { get; private set; }
        public static Texture2D WhiteKing { get; private set; }

        private static List<Texture2D> pieceTextures = new List<Texture2D>(12);
        public static List<Texture2D> PieceTextures
        {
            get
            {
                return new List<Texture2D>(pieceTextures);
            }
        }

        public static void Initialize(ContentManager content, Dictionary<string, string> properties)
        {
            BlackPawn = Initialize(content, properties, "BlackPawn");
            BlackKnight = Initialize(content, properties, "BlackKnight");
            BlackBishop = Initialize(content, properties, "BlackBishop");
            BlackRook = Initialize(content, properties, "BlackRook");
            BlackQueen = Initialize(content, properties, "BlackQueen");
            BlackKing = Initialize(content, properties, "BlackKing");
            WhitePawn = Initialize(content, properties, "WhitePawn");
            WhiteKnight = Initialize(content, properties, "WhiteKnight");
            WhiteBishop = Initialize(content, properties, "WhiteBishop");
            WhiteRook = Initialize(content, properties, "WhiteRook");
            WhiteQueen = Initialize(content, properties, "WhiteQueen");
            WhiteKing = Initialize(content, properties, "WhiteKing");
        }

        private static Texture2D Initialize(ContentManager content, Dictionary<string, string> properties, string textureName)
        {
            Texture2D texture = content.Load<Texture2D>(properties[textureName]);
            pieceTextures.Add(texture);
            return texture;
        }
    }
}
