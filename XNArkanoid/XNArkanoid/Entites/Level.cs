using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace XNArkanoid.Entites
{
    class Level
    {
        #region Déclarations
        private Barre barre;
        private int balls;
        private Ball ball;
        public List<Brick> Bricks;
        private int width;
        private int height;
        private int levelId;
        protected int hauteurEcran, largeurEcran;
        private int score;
        private Boolean isGamePlaying;
        #endregion

        #region Getters & Setters
        public Barre getBarre()
        {
            return this.barre;
        }
        public void setBarre(Barre barre)
        {
            this.barre = barre;
        }

        public int getBalls()
        {
            return this.balls;
        }
        public void setBalls(int balls)
        {
            this.balls = balls;
        }

        public List<Brick> getBricks()
        {
            return this.Bricks;
        }

        public int getWidth()
        {
            return this.width;
        }
        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getHeight()
        {
            return this.height;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getLevelId()
        {
            return this.levelId;
        }
        public void setLevelId(int levelId)
        {
            this.levelId = levelId;
        }

        public Ball getBall()
        {
            return this.ball;
        }
        public int getHauteurEcran()
        {
            return this.hauteurEcran;
        }

        public int getLargeurEcran()
        {
            return this.largeurEcran;
        }

        public int getScore()
        {
            return this.score;
        }
        public void setScore(int score)
        {
            this.score = score;
        }

        public Boolean getIsGamePlaying()
        {
            return this.isGamePlaying;
        }
        public void setIsGamePlaying(Boolean isGamePlaying)
        {
            this.isGamePlaying = isGamePlaying;
        }
        #endregion

        #region Constructeur
        public Level(int levelId, int largeurEcran, int hauteurEcran, List<Texture2D> listeTexture)
        {
            this.hauteurEcran = hauteurEcran;
            this.largeurEcran = largeurEcran;
            int BarreSpeed = 1;
            this.levelId = levelId;
            this.barre = new Barre(BarreSpeed, this);
            //Le nombre de balles du joueur
            this.balls = 3;
            this.ball = new Ball(this);
            this.Bricks = new List<Brick>();
            this.LoadLevel(hauteurEcran);
            this.initTexture(listeTexture);
        }
        #endregion

        #region Méthodes de Gestion
        /// <summary>
        /// Charge un niveau en lisant un fichier externe
        /// </summary>
        /// <param name="hauteurEcran"></param>
        /// <returns></returns>
        private bool LoadLevel(int hauteurEcran)
        {
            //Récupère le chemin du fichier qu'on va lire
            String levelPath = String.Format("Content/levels/level{0}/level{0}.txt", this.levelId);
            try
            {
                StreamReader sr = new StreamReader(TitleContainer.OpenStream(levelPath));
                String line;
                int row = 0;
                //Tant qu'on a une ligne a lire
                while ((line = sr.ReadLine()) != null)
                {
                    Char[] b = line.ToCharArray();
                    //Parcourt la ligne
                    for (int i = 0; i < b.Length; i++)
                    {
                        //Lit le caractère et vérifie qu'on va mettre une brique
                        if (!b[i].Equals(' '))
                        {
                            //Détermine les points de vie de la future brique
                            int pdv = -3;
                            pdv = b[i].Equals('b') ? -2 : pdv;
                            pdv = b[i].Equals('i') ? -1 : pdv;
                            pdv = pdv == -3 ? (int)Char.GetNumericValue(b[i]) : pdv;
                            //Crée la brique
                            Brick elseTmpBrick = new Brick(new Rectangle(50 + (i * 32), 70 + (row * 32), 32, 32), this, pdv);
                            this.Bricks.Add(elseTmpBrick);
                        }
                    }
                    row++;
                }
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Dessine les éléments du niveau
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            this.barre.Draw(spriteBatch);
            foreach (Brick brick in this.Bricks)
            {
                brick.Draw(spriteBatch);
            }
            this.ball.Draw(spriteBatch);

            String texteG = "Level: " + this.levelId;
            int positionG = this.largeurEcran / 4 - (int)font.MeasureString(texteG).X / 2;
            spriteBatch.DrawString(font, texteG, new Vector2(positionG, 2), Color.Black);
            String texte = "Balles: " + this.getBalls();
            int position = 2 * this.largeurEcran / 4 - (int)font.MeasureString(texteG).X / 2;
            spriteBatch.DrawString(font, texte, new Vector2(position, 2), Color.Black);
            String texteD = "Score: " + this.score;
            int positionD = 3 * this.largeurEcran / 4 - (int)font.MeasureString(texteD).X / 2;
            spriteBatch.DrawString(font, texteD, new Vector2(positionD, 2), Color.Black);
        }

        /// <summary>
        /// Lance les fonctions pour gérer les déplacements et les conditions d'arrêt de la partie
        /// </summary>
        /// <param name="deplacementSouris"></param>
        /// <returns>Les différents cas de fin de partie possible</returns>
        public int Update(int deplacementSouris)
        {
            //Gère le déplacement de la souris
            this.barre.deplacer(deplacementSouris);
            //Gère le déplacement de la balle
            bool partieEnCours = this.ball.deplacementBalle();
            //Calcule le nombre de briques cassables encore en jeu
            int nbBrickACasser = 0;
            foreach (Brick brick in this.Bricks)
            {
                nbBrickACasser += brick.getType() == typeBrick.incassable ? 0 : 1;
            }
            //Renvoi des valeurs
            if (!partieEnCours)
            {
                //Si le joueur a perdu (plus de balles)
                return -1;
            }
            else if (nbBrickACasser == 0)
            {
                //Si le joueur a gagné (plus de briques)
                return 0;
            }
            //Si la partie continue
            return 1;
        }

        /// <summary>
        /// Initialise les textures de la balle et de la balle, puis lance la fonction d'initialisation des textures des briques
        /// </summary>
        /// <param name="listeTexture"></param>
        public void initTexture(List<Texture2D> listeTexture)
        {

            foreach (Texture2D texture in listeTexture)
            {
                switch (texture.Tag.ToString())
                {
                    case "balle":
                        this.ball.setTexture(texture);
                        break;
                    case "barre":
                        this.barre.setTexture(texture);
                        break;
                    case "brick":
                        this.initTextureBrick(texture);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Initialise les textures des briques en fonction de leur type
        /// </summary>
        /// <param name="texture"></param>
        private void initTextureBrick(Texture2D texture)
        {
            Console.WriteLine(this.Bricks.Count);
            foreach (Brick brick in this.Bricks)
            {
                switch (brick.getType())
                {
                    case typeBrick.normale:
                        if (texture.Name == "brickNormale")
                        {
                            brick.setTexture(texture);
                        }
                        break;
                    case typeBrick.bonus:
                        if (texture.Name == "brickBonus")
                        {
                            brick.setTexture(texture);
                        }
                        break;
                    case typeBrick.incassable:
                        if (texture.Name == "brickIncassable")
                        {
                            brick.setTexture(texture);
                        }
                        break;
                    case typeBrick.plusieursvies:
                        if (texture.Name == "brickVies")
                        {
                            brick.setTexture(texture);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}
