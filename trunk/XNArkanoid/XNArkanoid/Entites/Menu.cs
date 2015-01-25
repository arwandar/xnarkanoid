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
        public Menu(int hauteurEcran, int largeurEcran)
        {
            this.hauteurEcran = hauteurEcran;
            this.largeurEcran = largeurEcran;

            this.listeBtn = new List<Btn>();

            //btn pour demarrer une partie
            //Btn demarrerPartie = new Btn(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Btn btn in listeBtn)
            {
                btn.Draw(spriteBatch);
            }
        }



        public void setTextureBtn(List<Texture2D> listeTexture)
        {
            foreach (Btn btn in listeBtn)
            {
                foreach (Texture2D texture in listeTexture)
                {
                    if (texture.Tag.ToString() == "btn")
                    {
                        switch (texture.Name)
                        {
                            case "btnJouer":
                                if (btn.getType() == typeBtn.btnJouer){
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
    }
}
