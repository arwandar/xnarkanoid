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
        public Barre Barre { get; set; }
        public LinkedList<Ball> Balls { get; set; }
        public Brick[,] Bricks { get; set; }
        private int width;
        private int height;
        public int LevelId { get; set; }
        private ContentManager content;

        public Level(ContentManager content, int levelId)
        {
            int BarreSpeed = 10;

            this.LevelId = levelId;
            this.content = content;
            this.Barre= new Barre(new Rectangle(150, 700, 80, 10), BarreSpeed);
            this.Balls=new LinkedList<Ball>();
            this.Balls.AddFirst(new Ball(new Rectangle(175, 680, 20, 20)));
            this.LoadLevel();
        }

        private bool LoadLevel()
        {
            String levelPath = String.Format("levels/level{0}/level{0}.txt", this.LevelId);
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
                            tmpBrick.visible = false;
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


    }
}
