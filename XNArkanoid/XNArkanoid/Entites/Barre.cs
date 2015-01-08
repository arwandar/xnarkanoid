using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Barre
    {
        public Rectangle Rectangle;
        public int Speed { get; set; }
        public int Width
        {
            get;
            set
            {
                this.Width = value;
                this.Rectangle.Width = value;
            }
        }

        public Barre(Rectangle rectangle, int speed)
        {
            this.Rectangle = rectangle;
            this.Speed = speed;
        }
    }
}
