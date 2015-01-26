using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    class Menu
    {
        #region Déclarations
        protected int hauteurEcran, largeurEcran;
        private List<Btn> listeBtn;
        #endregion

        #region Constructeur
        public Menu(int hauteurEcran, int largeurEcran)
        {
            this.hauteurEcran = hauteurEcran;
            this.largeurEcran = largeurEcran;

            this.listeBtn = new List<Btn>();

            //btn pour demarrer une partie
            Btn demarrerPartie = new Btn(this, typeBtn.btnJouer, new Vector2(100, 100));
            Btn quitter = new Btn(this, typeBtn.btnExit, new Vector2(200, 200));
            this.listeBtn.Add(quitter);
            this.listeBtn.Add(demarrerPartie);
        }
        #endregion

        #region Méthodes de gestion
        /// <summary>
        /// Ecrit le texte sur le menu principal
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            foreach (Btn btn in listeBtn)
            {
                btn.Draw(spriteBatch);
            }

            spriteBatch.DrawString(font, "Bouger la souris pour", new Vector2(400, 100), Color.Black);
            spriteBatch.DrawString(font, "Faire bouger la barre", new Vector2(420, 150), Color.Black);

            spriteBatch.DrawString(font, "A la fin d'un niveau", new Vector2(460, 250), Color.Black);
            spriteBatch.DrawString(font, "Cliquer pour passer", new Vector2(480, 300), Color.Black);
            spriteBatch.DrawString(font, "Au niveau suivant", new Vector2(500, 350), Color.Black);
        }

        /// <summary>
        /// Affecte la texture associée aux boutons en fonction de leur type
        /// </summary>
        /// <param name="listeTexture"></param>
        public void setTextureBtn(List<Texture2D> listeTexture)
        {
            foreach (Btn btn in this.listeBtn)
            {
                foreach (Texture2D texture in listeTexture)
                {
                    if (texture.Tag.ToString() == "btn")
                    {
                        switch (texture.Name)
                        {
                            case "btnJouer":
                                if (btn.getType() == typeBtn.btnJouer)
                                {
                                    btn.setTexture(texture);
                                }
                                break;
                            case "btnQuitter":
                                if (btn.getType() == typeBtn.btnExit)
                                {
                                    btn.setTexture(texture);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet de savoir quel bouton a été cliqué
        /// </summary>
        /// <param name="mouseState"></param>
        /// <returns></returns>
        public typeBtn getBtnClick(Microsoft.Xna.Framework.Input.MouseState mouseState)
        {
            typeBtn type = typeBtn.nul;

            foreach (Btn btn in this.listeBtn)
            {
                type = btn.isMouseIn(mouseState) ? btn.getType() : type;
            }

            return type;
        }
        #endregion
    }
}
