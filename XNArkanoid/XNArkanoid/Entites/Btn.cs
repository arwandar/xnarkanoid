using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        #endregion

        #region Constructeurs
        public Btn(Menu menu, typeBtn type)
        {
            this.menu = menu;
            this.rectangle = new Rectangle(0, 0, 0, 0);
            this.type = type;
        }
        #endregion

        #region Methodes
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }
        #endregion
    }
}
