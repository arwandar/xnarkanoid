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
            this.rectangle.Y = this.level.getBarre().getRectangle().Y - this.texture.Height - 1;
        }
        #endregion

        #region Constructeur
        public Ball(Level level)
            : base(level)
        {
            //Paramètres de la balle (vitesse et direction)
            this.speed = 3F;
            this.ballDirection.X = 1;
            this.ballDirection.Y = -1;
            this.isMoving = false;
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
                //Renvoie la balle vers le haut
                this.ballDirection.Y = -this.ballDirection.Y;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gère la collision entre la balle et une brique
        /// </summary>
        /// <param name="brick"></param>
        /// <returns>Un booleen qui permet de savoir si la collision a ou non eu lieu</returns>
        public bool Collision(Brick brick)
        {
            if (brick.getRectangle().Intersects(this.rectangle))
            {
                //Fait en sorte que la balle ne s'incruste pas dans la brique
                while (brick.getRectangle().Intersects(this.rectangle))
                {
                    this.rectangle.X -= (int)this.ballDirection.X;
                    this.rectangle.Y -= (int)this.ballDirection.Y;
                }
                //Renvoie la balle dans l'autre sens
                this.ballDirection.Y = -this.ballDirection.Y;
                //Enlève un pv à la brique et la supprime si elle n'a plus de vie
                brick.setPdv(brick.getPdv() - 1);
                if (brick.getPdv() == 0)
                {
                    if (brick.getType() == typeBrick.bonus)
                    {
                        Random r = new Random();
                        switch(r.Next(0, 4)){
                            case 1:
                                this.level.setBalls(this.level.getBalls() + 1);
                                break;
                            case 2:
                                Console.WriteLine(this.level.getScore());
                                this.level.setScore(this.level.getScore() + r.Next(1, 200));
                                Console.WriteLine(this.level.getScore());
                                break;
                        }
                    }
                    this.level.getBricks().Remove(brick);
                    //Augmente le score
                    this.level.setScore(this.level.getScore() + 10);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gère le déplacement de la balle
        /// </summary>
        /// <returns>Renvoie un booleen indiquant si la partie est en cours ou non</returns>
        public Boolean deplacementBalle()
        {
            if (this.isMoving)
            {
                //Calcule la nouvelle position de la balle
                int newX = this.rectangle.X + (int)(this.ballDirection.X * this.speed);
                int newY = this.rectangle.Y + (int)(this.ballDirection.Y * this.speed);
                //Déplace la balle
                this.rectangle.X = newX; this.rectangle.Y = newY;
                //Gère une possile collision avec la barre
                Collision(this.level.getBarre());
                //Gère une possile collision avec une brique
                foreach (Brick brick in this.level.getBricks())
                {
                    if (Collision(brick))
                    {
                        break;
                    }
                }
                //Gère une possible collision avec le côté gauche
                if (newX < 0)
                {
                    this.ballDirection.X = -this.ballDirection.X;
                }
                //Gère une possible collision avec le côté droit
                if (newX + texture.Width > this.level.getLargeurEcran())
                {
                    this.ballDirection.X = -this.ballDirection.X;
                }
                //Gère une possible collision avec le côté haut
                if (newY < 0)
                {
                    this.ballDirection.Y = -this.ballDirection.Y;
                }
                //Gère une possible collision avec le côté bas
                if (newY > this.level.getHauteurEcran())
                {
                    //Enlève une balle au joueur et indique la fin de partie s'il n'en a plus
                    this.level.setBalls(this.level.getBalls() - 1);
                    if (this.level.getBalls() == 0)
                    {
                        return false;
                    }
                    //Replace la barre et la balle dans leur position initiale
                    this.rectangle.X = this.level.getLargeurEcran() / 2 - texture.Width / 2;
                    this.rectangle.Y = this.level.getBarre().getRectangle().Y - this.texture.Height - 1;
                    this.level.getBarre().reInitPosition();
                    this.isMoving = false;
                }
                return true;
            }
            else
            {
                this.rectangle.X = this.level.getBarre().getRectangle().X + this.level.getBarre().getRectangle().Width / 2 - this.texture.Width / 2;
                return true;
            }
        }
        #endregion
    }
}