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
        #region Déclarations
        private Vector2 ballDirection;
        private float speed;
        private Boolean isMoving;
        #endregion

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
            this.rectangle.X = this.level.getLargeurEcran() / 2 - texture.Width / 2;
            this.rectangle.Y = this.level.getBarre().getRectangle().Y - 1;
        }
        #endregion


        #region Constructeur
        public Ball(Level level)
            : base(level)
        {
            this.speed = 3F;
            this.ballDirection.X = 1;
            this.ballDirection.Y = -1;
        }
        #endregion


        #region Méthodes de gestion
        /// <summary>
        /// Gère la collision entre la balle et la barre
        /// </summary>
        /// <param name="barre"></param>
        /// <returns>Un booleen qui permet de savoir si la collision a ou non eu lieu</returns>
        public bool Collision(Barre barre)
        {
            if (barre.getRectangle().Intersects(this.rectangle))
            {
                //Fait en sorte que la balle ne s'incruste pas dans la barre
                while (barre.getRectangle().Intersects(this.rectangle))
                {
                    this.rectangle.X -= (int)this.ballDirection.X;
                    this.rectangle.Y -= (int)this.ballDirection.Y;
                }
                //Calcule le point d'impact pour en tirer un coefficient permettant de renvoyer la balle dans l'angle voulu
                float milieuBarre = this.level.getBarre().getRectangle().X + this.level.getBarre().getRectangle().Width / 2;
                float milieuBall = this.rectangle.X + this.texture.Width / 2;
                float différenceImpact = (milieuBall - milieuBarre) / this.level.getBarre().getRectangle().Width / 2;
                this.ballDirection.X = 10 * différenceImpact;
                //
                this.ballDirection.Y = -this.ballDirection.Y;
                return true;
            }
            return false;
        }

        public bool Collision(Brick brick)
        {
            if (brick.getRectangle().Intersects(this.rectangle))
            {
                while (brick.getRectangle().Intersects(this.rectangle))
                {
                    this.rectangle.X -= (int)this.ballDirection.X;
                    this.rectangle.Y -= (int)this.ballDirection.Y;
                }
                this.ballDirection.Y = -this.ballDirection.Y;
                brick.setPdv(brick.getPdv() - 1);
                if (brick.getPdv() == 0)
                {
                    this.level.getBricks().Remove(brick);
                }
                this.level.setScore(this.level.getScore() + 10);
                return true;
            }
            return false;
        }

        public Boolean deplacer()
        {
            int newX = this.rectangle.X + (int)(this.ballDirection.X * this.speed);
            int newY = this.rectangle.Y + (int)(this.ballDirection.Y * this.speed);

            this.rectangle.X = newX; this.rectangle.Y = newY;
            Collision(this.level.getBarre());
            foreach (Brick brick in this.level.getBricks())
            {
                if (Collision(brick))
                {
                    break;
                }
            }
            if (newX < 0)
            {
                this.ballDirection.X = -this.ballDirection.X;
            }
            if (newX + texture.Width > this.level.getLargeurEcran())
            {
                this.ballDirection.X = -this.ballDirection.X;
            }
            if (newY < 0)
            {
                this.ballDirection.Y = -this.ballDirection.Y;
            }
            if (newY > this.level.getHauteurEcran())
            {
                this.level.setBalls(this.level.getBalls() - 1);
                if (this.level.getBalls() == 0)
                {
                    return false;
                }
                this.rectangle.X = this.level.getLargeurEcran() / 2 - texture.Width / 2;
                this.rectangle.Y = this.level.getBarre().getRectangle().Y - this.texture.Height - 1;
                this.level.getBarre().reInitPosition();

            }
            return true;
        }
        #endregion

    }
}
