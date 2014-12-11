using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    class Ball
    {
        public Rectangle Rectangle;
        public float Speed { get; set; }
        //public Vector2 spriteSpeed;
        public Vector2 BallDirection;


        public Ball(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
        }


        public bool Collision (Barre barre)
        {
            if (barre.Rectangle.Intersects(this.Rectangle))
            {
                this.BallDirection.Y = -this.BallDirection.Y;
                return true;
            }
            return false;
        }

        public bool Collision(Brick brick)
        {
            if (brick.Rectangle.Intersects(this.Rectangle))
            {
                this.BallDirection.Y = -this.BallDirection.Y;
                return true;
            }
            return false;
        }

    }
}
