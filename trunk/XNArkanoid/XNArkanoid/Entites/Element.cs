﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    abstract class Element
    {
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected Level level;

        public Element()
        {
            this.rectangle = new Rectangle(0, 0, 0, 0);
        }

        public Element(Level level)
        {
            this.rectangle = new Rectangle(0, 0, 0, 0);
            this.level = level;
        }


        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            //mise à jour de la taille initiale du rectangle
            this.rectangle.Width = texture.Width;
            this.rectangle.Height = texture.Height;
        }

        public Rectangle getRectangle()
        {
            return this.rectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }

    }
}
