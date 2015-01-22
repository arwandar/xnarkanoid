using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Brick
    {
        public Rectangle rectangle;
        private Boolean visible;
        private Texture2D texture;


        #region Getters & Setters
        public Boolean getVisible()
        {
            return this.visible;
        }
        public void setVisible(Boolean visible)
        {
            this.visible = visible;
        }

        public Texture2D getTexture()
        {
            return this.texture;
        }
        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        #endregion


        #region Constructeur
        public Brick(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.visible = true;
        }
        #endregion

    }
}
