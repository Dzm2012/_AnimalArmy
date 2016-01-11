using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalArmy.GameObjects
{

    class Sprites : Image
    {
        public enum Action
        {
            Standing,
            Walking
        };

        public enum Direction
        {
            Up,
            Right,
            Down,
            Left

        };

        public Action action = Action.Standing;
        public Direction direction = Direction.Down;

        public int Width;
        public int Height;

        public Rectangle rec;

        public int currentImageRow;
        public int currentImageColumn;

        public int firstImageColumn;

        public TimeSpan updateSpeed;
        public DateTime nextUpdate;
        bool step = false;
        
        public Sprites(ContentManager content, string resourceName, int width, int height, int firstImageColumn)
        {
            currentImageRow = 0;
            currentImageColumn = 0;
            texTure = content.Load<Texture2D>(resourceName);
            Width = width;
            Height = height;
            this.firstImageColumn = firstImageColumn;
            rec = new Rectangle(0, 0, Width, Height);
        }
        public void updateRectangle(int column,int row)
        {
            currentImageRow = row;
            currentImageColumn = column;
            rec = new Rectangle(Width * column, Height * row, Width, Height);
        }
        public void SetUpdateSpeed(int days, int hours, int minutes, int seconds, int millaseconds)
        {
            updateSpeed = new TimeSpan(days, hours, minutes, seconds, millaseconds);
        }
        public Texture2D GetTexture2D()
        {
            Texture2D textureReturned = texTure;
            GetImage();
            return textureReturned;
        }
        public void SetKeyboardState(KeyboardState ob)
        {
            if(ob.GetPressedKeys().Length>0)
                switch (ob.GetPressedKeys()[0])
                {
                        case Keys.W:
                            direction = GameObjects.Sprites.Direction.Up;
                            action = GameObjects.Sprites.Action.Walking;
                            break;
                        case Keys.A:
                            direction = GameObjects.Sprites.Direction.Left;
                            action = GameObjects.Sprites.Action.Walking;
                            break;
                        case Keys.S:
                            direction = GameObjects.Sprites.Direction.Down;
                            action = GameObjects.Sprites.Action.Walking;
                            break;
                        case Keys.D:
                            direction = GameObjects.Sprites.Direction.Right;
                            action = GameObjects.Sprites.Action.Walking;
                            break;
                        default:
                            action = GameObjects.Sprites.Action.Standing;
                            break;
                }
            if (!ob.GetPressedKeys().Contains(Keys.W) &&
                !ob.GetPressedKeys().Contains(Keys.A) &&
                !ob.GetPressedKeys().Contains(Keys.S) &&
                !ob.GetPressedKeys().Contains(Keys.D))
            {
                action = GameObjects.Sprites.Action.Standing;
            }
        }
        private void GetImage()
        {
            int row = 0;
            int column = currentImageColumn;
            switch (direction)
            {
                case Direction.Down:
                    row = 0;
                    break;
                case Direction.Right:
                    row = 2;
                    break;
                case Direction.Up:
                    row = 3;
                    break;
                case Direction.Left:
                    row = 1;
                    break;
            }
            switch(action)
            {
                case Action.Standing:
                    column = 1;
                    break;
                case Action.Walking:
                    if (DateTime.Now > nextUpdate)
                    {
                        nextUpdate = DateTime.Now.Add(updateSpeed);
                        //updated image
                        if (step)
                        {
                            column = 2;
                            step = false;
                        }
                        else
                        {
                            column = 0;
                            step = true;
                        }
                    }
                    else
                    {
                        //image
                        if (step)
                            column = 2;
                        else
                            column = 0;
                    }
                    break;
            }
            updateRectangle(column, row);

        }
    }
}
