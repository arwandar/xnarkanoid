using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Barre : Element
    {
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

        new public void setTexture(Texture2D texture)
        {
            base.setTexture(texture);
            this.rectangle.X = this.level.getLargeurEcran() / 2 - texture.Width / 2;
            this.rectangle.Y = this.level.getHauteurEcran() - texture.Height;
        }
        #endregion


        #region Constructeur
        public Barre(int speed, Level level)
            : base(level)
        {
            this.speed = speed;
        }
        #endregion

        #region Méthode
        public void reInitPosition()
        {
            this.rectangle.X = this.level.getLargeurEcran() / 2 - this.texture.Width / 2;
            this.rectangle.Y = this.level.getHauteurEcran() - this.texture.Height;
        }

        public void deplacer(int deplacement)
        {
            float depAcVitesse = ((float)deplacement) * this.speed;
            this.rectangle.X = this.rectangle.X - (int)depAcVitesse;

            this.rectangle.X = (this.rectangle.X < 0) ? 0 : this.rectangle.X;
            this.rectangle.X = (this.rectangle.X + this.rectangle.Width > this.level.getLargeurEcran()) ? this.level.getLargeurEcran() - this.rectangle.Width : this.rectangle.X;
        }
        #endregion
    }
}
