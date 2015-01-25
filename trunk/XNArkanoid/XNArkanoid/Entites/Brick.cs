using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNArkanoid.Entites
{
    enum typeBrick { normale, incassable, bonus, plusieursvies };
    class Brick : Element
    {
        private int pdv;
        typeBrick type;

        #region Getters & Setters
        public int getPdv()
        {
            return this.pdv;
        }
        public void setPdv(int pdv)
        {
            this.pdv = pdv;
        }

        new public void setTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public typeBrick getType()
        {
            return this.type;
        }
        #endregion


        #region Constructeur
        public Brick(Rectangle rectangle, Level level, int pdv)
            : base(level)
        {
            this.rectangle = rectangle;
            this.pdv = pdv;
            switch (pdv)
            {
                case -2:
                    this.type = typeBrick.bonus;
                    this.pdv = 1;
                    break;
                case -1:
                    this.type = typeBrick.incassable;
                    break;
                case 1:
                    this.type = typeBrick.normale;
                    break;
                default:
                    this.type = typeBrick.plusieursvies;
                    break;
            }

        }
        #endregion

    }
}
