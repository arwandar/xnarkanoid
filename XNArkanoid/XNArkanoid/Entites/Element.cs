using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    abstract class Element
    {
        #region Déclarations
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected Level level;
        #endregion

        #region Getters & Setters
        public Rectangle getRectangle()
        {
            return this.rectangle;
        }
        public void setRectangle(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            //mise à jour de la taille initiale du rectangle
            this.rectangle.Width = texture.Width;
            this.rectangle.Height = texture.Height;
        }
        #endregion

        #region Constructeur
        public Element()
        {
            this.rectangle = new Rectangle(0, 0, 0, 0);
        }

        public Element(Level level)
        {
            this.rectangle = new Rectangle(0, 0, 0, 0);
            this.level = level;
        }
        #endregion

        #region Méthodes de gestion
        /// <summary>
        /// Dessine l'élement avec sa texture et sa couleur
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }
        #endregion
    }
}
