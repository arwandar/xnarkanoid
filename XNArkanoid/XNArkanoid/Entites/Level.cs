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
        public Brick[,] Bricks { get; set; }
        private int width;
        private int height;
        private int levelId;
        private ContentManager content;


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
        #endregion

        #region Constructeur
        public Level(ContentManager content, int levelId)
        {
            int BarreSpeed = 10;
            this.levelId = levelId;
            this.content = content;
            this.barre = new Barre(new Rectangle(150, 700, 80, 10), BarreSpeed);
            this.balls = 3;
            this.LoadLevel();
        }
        #endregion


        #region Méthodes de Gestion
        private bool LoadLevel()
        {
            String levelPath = String.Format("levels/level{0}/level{0}.txt", this.levelId);
            levelPath = "Content/" + levelPath;

            try
            {
                StreamReader sr = new StreamReader(TitleContainer.OpenStream(levelPath));
                String[] infos = sr.ReadLine().Split(' ');
                this.height = Int16.Parse(infos[0]);
                this.width = Int16.Parse(infos[1]);
                this.Bricks = new Brick[height, width];
                String line;
                int row = 0;
                int brickwidth = 488 / width;
                //int brickHeight = 40;
                while ((line = sr.ReadLine()) != null)
                {
                    Char[] b = line.ToCharArray();
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (b[i].Equals(' '))
                        {
                            Brick tmpBrick = new Brick(new Rectangle(50 + (i * 32), 70 + (row * 32), 32, 32));
                            tmpBrick.setVisible(false);
                            this.Bricks[row, i] = tmpBrick;
                        }
                        else
                        {
                            if (!b[i].Equals('#'))
                                //this.nbBricks++;
                                this.Bricks[row, i] = new Brick(new Rectangle(50 + (i * 32), 70 + (row * 32), 32, 32));
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
            //TODO
            spriteBatch.Draw(this.barre.getTexture(), this.barre.Rectangle, Color.Black);
        }
        
        #endregion



    }
}
