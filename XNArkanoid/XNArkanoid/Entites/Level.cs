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
        private Barre barre;
        private int balls;
        private Ball ball;
        public List<Brick> Bricks { get; set; }
        private int width;
        private int height;
        private int levelId;
        protected int hauteurEcran, largeurEcran;
        private int score;
        private Boolean isGamePlaying;


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
        public Level(int levelId, int largeurEcran, int hauteurEcran)
        {
            this.hauteurEcran = hauteurEcran;
            this.largeurEcran = largeurEcran;
            int BarreSpeed = 1;
            this.levelId = levelId;
            this.barre = new Barre(BarreSpeed, this);
            this.balls = 3;
            this.ball = new Ball(this);
            this.Bricks = new List<Brick>();
            this.LoadLevel(hauteurEcran);
        }
        #endregion


        #region Méthodes de Gestion
        private bool LoadLevel(int hauteurEcran)
        {
            String levelPath = String.Format("Content/levels/level{0}/level{0}.txt", this.levelId);
            try
            {
                StreamReader sr = new StreamReader(TitleContainer.OpenStream(levelPath));
                String line;
                int row = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    Char[] b = line.ToCharArray();
                    for (int i = 0; i < b.Length; i++)
                    {
                        int pdv = -3;
                        pdv = b[i].Equals('b') ? -2 : pdv;
                        pdv = b[i].Equals('i') ? -1 : pdv;
                        pdv = pdv == -3 ? (int)Char.GetNumericValue(b[i]) : pdv;
                        if (b[i].Equals(' '))
                        {


                        }
                        else if (!b[i].Equals('#'))
                        {
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

        public void Draw(SpriteBatch spriteBatch)
        {
            this.barre.Draw(spriteBatch);
            foreach (Brick brick in this.Bricks)
            {
                brick.Draw(spriteBatch);
            }
            this.ball.Draw(spriteBatch);
        }

        public void Update(int deplacementSouris)
        {
            this.barre.deplacer(deplacementSouris);

        }

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
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
