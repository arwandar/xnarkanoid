﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNArkanoid.Entites
{
    class Menu
    {
        protected int hauteurEcran, largeurEcran;
        private List<Btn> listeBtn;

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

        #region Méthode
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Btn btn in listeBtn)
            {
                btn.Draw(spriteBatch);
            }
        }

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
