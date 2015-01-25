using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Ball : Element
    {
        private Vector2 ballDirection;
        private float speed;
        private Boolean isMoving;


        #region Getters & Setters
        public float getSpeed()
        {
            return this.speed;
        }
        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public Boolean getIsMoving()
        {
            return this.isMoving;
        }
        public void setIsMoving(Boolean isMoving)
        {
            this.isMoving = isMoving;
        }
        new public void setTexture(Texture2D texture)
        {
            base.setTexture(texture);
            this.rectangle.X = this.level.getLargeurEcran() / 2 - texture.Width;// / 2;
            this.rectangle.Y = this.level.getBarre().getRectangle().Height - texture.Height;
        }
        #endregion


        #region Constructeur
        public Ball(Level level)
            : base(level)
        {

        }
        #endregion


        #region Méthodes de gestion
        public bool Collision(Barre barre)
        {
            if (barre.getRectangle().Intersects(this.rectangle))
            {
                this.ballDirection.Y = -this.ballDirection.Y;
                return true;
            }
            return false;
        }

        public bool Collision(Brick brick)
        {
            if (brick.getRectangle().Intersects(this.rectangle))
            {
                this.ballDirection.Y = -this.ballDirection.Y;
                brick.setPdv(brick.getPdv() - 1);
                if(brick.getPdv()==0)
                {
                    this.level.getBricks().Remove(brick);
                }                
                return true;
            }
            return false;
        }
        #endregion

    }
}
