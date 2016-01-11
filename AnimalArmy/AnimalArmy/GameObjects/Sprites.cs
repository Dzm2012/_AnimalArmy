using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalArmy.GameObjects
{

    class Sprites : Image
    {
        enum Action
        {
            Standing,
            Walking
        };

        enum Direction
        {
            Up,
            Right,
            Down,
            Left

        };

        Action action = Action.Standing;
        Direction direction = Direction.Down;

        public int Width;
        public int Height;

        public Rectangle rec;

        public int currentImageRow;
        public int currentImageColumn;

        public TimeSpan updateSpeed;
        public DateTime nextUpdate;
        
        public Sprites(ContentManager content, string resourceName, int width, int height)
        {
            currentImageRow = 0;
            currentImageColumn = 0;
            texTure = content.Load<Texture2D>(resourceName);
            Width = width;
            Height = height;
            rec = new Rectangle(0, 0, Width, Height);
        }
        public void updateRectangle(int column,int row)
        {
            currentImageRow = row;
            currentImageColumn = column;
            rec = new Rectangle(Width * column, Height * row, Width, Height);
        }
        public void SetUpdateSpeed(int hours, int minutes, int seconds)
        {

            updateSpeed = new TimeSpan(hours, minutes, seconds);
        }
        public Texture2D GetTexture2D()
        {
            Texture2D textureReturned = texTure;
            if (DateTime.Now > nextUpdate)
            {
                nextUpdate = DateTime.Now.Add(updateSpeed);
            }
            return textureReturned;
        }
    }
}
