using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Brick
    {
        public Rectangle Rectangle;
        public int Width { get; set; }

        public Brick(Rectangle rectangle, int Width)
        {
            this.Rectangle = rectangle;
            this.Width = Width;
        }

    }
}
