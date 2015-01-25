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
        private Boolean visible;
        
        typeBrick type;

        #region Getters & Setters
        public Boolean getVisible()
        {
            return this.visible;
        }
        public void setVisible(Boolean visible)
        {
            this.visible = visible;
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
        public Brick(Rectangle rectangle, Level level)
            : base(level)
        {
            this.visible = true;
            this.rectangle = rectangle;
            this.type = typeBrick.normale;
        }
        #endregion

    }
}
