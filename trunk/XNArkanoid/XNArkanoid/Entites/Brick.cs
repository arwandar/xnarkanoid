using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Brick : Element
    {
        private Boolean visible;


        #region Getters & Setters
        public Boolean getVisible()
        {
            return this.visible;
        }
        public void setVisible(Boolean visible)
        {
            this.visible = visible;
        }

        new public void setTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        #endregion


        #region Constructeur
        public Brick(Rectangle rectangle, Level level) :base(level)
        {
            this.visible = true;
            this.rectangle = rectangle;
        }
        #endregion

    }
}
