using Microsoft.Xna.Framework.Graphics;

namespace ChessUi
{
    public class PieceUi
    {
        public Texture2D Texture { get; private set; }
        public Coordinate Coordinate { get; private set; }

        public PieceUi(Texture2D texture, Coordinate coordinate)
        {
            Texture = texture;
            Coordinate = coordinate;
        }
    }
}
