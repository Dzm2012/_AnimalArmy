using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalArmy.GameObjects
{
    class Image : Microsoft.Xna.Framework.Game
    {
        public Vector2 imageVector = new Vector2();
        public Texture2D texTure;

        public Image()
        {

        }
        public Image(ContentManager content, string resourceName)
        {
            texTure = content.Load<Texture2D>(resourceName);
        }
        
    }
}
