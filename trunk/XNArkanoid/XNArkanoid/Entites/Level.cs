using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Level
    {
        public Barre Barre { get; set; }
        public Ball Ball { get; set; }
        public Brick[,] Bricks { get; set; }
    }
}
