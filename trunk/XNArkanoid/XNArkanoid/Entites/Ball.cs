using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Ball
    {
        public Rectangle rectangle;
        public Vector2 ballDirection;
        private float speed;


        #region Getters & Setters
        public float getSpeed()
        {
            return this.speed;
        }
        public void setSpeed(float speed)
        {
            this.speed = speed;
        }
        #endregion


        #region Constructeur
        public Ball(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }
        #endregion


        #region Méthodes de gestion
        public bool Collision(Barre barre)
        {
            if (barre.Rectangle.Intersects(this.rectangle))
            {
                this.ballDirection.Y = -this.ballDirection.Y;
                return true;
            }
            return false;
        }

        public bool Collision(Brick brick)
        {
            if (brick.getVisible() && brick.rectangle.Intersects(this.rectangle))
            {
                this.ballDirection.Y = -this.ballDirection.Y;
                brick.setVisible(false);
                return true;
            }
            return false;
        }
        #endregion

    }
}
