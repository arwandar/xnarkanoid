using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    enum typeBtn {nul = 0, btnJouer, btnFaq, btnExit };
    class Btn
    {
        Rectangle rectangle;
        Menu menu;
        Texture2D texture;
        typeBtn type;

        #region Getters & Setters
        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            this.rectangle.Width = texture.Width;
            this.rectangle.Height = texture.Height;
        }
        
        public typeBtn getType()
        {
            return this.type;
        }

        public Rectangle getRectangle()
        {
            return this.rectangle;
        }
        #endregion

        #region Constructeurs
        public Btn(Menu menu, typeBtn type, Vector2 position)
        {
            this.menu = menu;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 0, 0);
            this.type = type;
        }
        #endregion

        #region Methodes
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }

        public Boolean isMouseIn(MouseState mouseState)
        {
            if (mouseState.X < this.rectangle.X || mouseState.X > this.rectangle.X + this.rectangle.Width || mouseState.Y < this.rectangle.Y || mouseState.X > this.rectangle.Y + this.rectangle.Height)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
