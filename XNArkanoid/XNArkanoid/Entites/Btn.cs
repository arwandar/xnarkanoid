using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    class Btn
    {
        Rectangle rectangle;
        Menu menu;
        Texture2D texture;

        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            this.rectangle.Width = texture.Width;
            this.rectangle.Height = texture.Height;
        }

        public Btn(Menu menu)
        {
            this.menu = menu;
            this.rectangle = new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }
    }
}
