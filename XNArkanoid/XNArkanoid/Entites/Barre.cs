using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Barre
    {
        public Rectangle Rectangle;
        private float speed;
        private int width;


        #region Getters & Setters
        public float getSpeed()
        {
            return this.speed;
        }
        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public int getWidth()
        {
            return this.width;
        }
        public void setWidth(int width)
        {
            this.width = width;
        }
        #endregion


        #region Constructeur
        public Barre(Rectangle rectangle, int speed)
        {
            this.Rectangle = rectangle;
            this.speed = speed;
        }
        #endregion
    }
}
