using Microsoft.Xna.Framework.Input;
using System;

namespace ChessUi
{
    public class MouseInput
    {
        private ButtonState previousLeftButonState = ButtonState.Released;
        public event EventHandler<BoardClickedArgs> BoardClicked;
        public event EventHandler<PromotionClickedArgs> PromotionClicked;

        public void Update(MouseState state, BoardUi boardUi)
        {
            ButtonState currentLeftButtonState = state.LeftButton;

            if (previousLeftButonState == ButtonState.Released && currentLeftButtonState == ButtonState.Pressed)
            {
                float textureSize = Game1.TextureSize;
                int columnClicked = (int) (state.X / textureSize);
                int rowClicked = (int) (state.Y / textureSize);

                if (columnClicked >= 0 && columnClicked < BoardUi.BoardWidth 
                    && rowClicked >= 0 && rowClicked < BoardUi.BoardHeight)
                {
                    BoardClicked?.Invoke(this, new BoardClickedArgs(columnClicked, rowClicked));
                }

                if (boardUi.ArePromotionPiecesShown 
                    && columnClicked == BoardUi.BoardWidth 
                    && rowClicked < boardUi.PromotionPieceTextures.Count)
                {
                    PromotionClicked?.Invoke(this, new PromotionClickedArgs(rowClicked));
                }
            }

            previousLeftButonState = currentLeftButtonState;
        }
    }

    public class BoardClickedArgs : EventArgs
    {
        public int Rank { get; set; }
        public int File { get; set; }

        public BoardClickedArgs(int columnClicked, int rowClicked)
        {
            Rank = BoardUi.RowToRank(rowClicked);
            File = columnClicked;
        }
    }

    public class PromotionClickedArgs : EventArgs
    {
        public int RowClicked { get; set; }

        public PromotionClickedArgs(int rowClicked)
        {
            RowClicked = rowClicked;
        }
    }
}
