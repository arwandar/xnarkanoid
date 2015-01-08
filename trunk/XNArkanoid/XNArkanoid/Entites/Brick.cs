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
        public Boolean visible { get; set; }

        public Brick(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
            this.visible = true;
        }

    }
}
