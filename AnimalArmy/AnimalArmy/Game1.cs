using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AnimalArmy
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameTime GT;
        GameObjects.Image banana;
        GameObjects.Sprites spriteBirds;
        List<GameObjects.Image> objectsImages = new List<GameObjects.Image>();
        List<GameObjects.Sprites> objectsSprites = new List<GameObjects.Sprites>();

        public Game1()
        {
            this.IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            // /\ set game screen
            Content.RootDirectory = "Content";

        }
        
        protected override void Initialize()
        {

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            banana = new GameObjects.Image(Content, "FAGNANA");
            spriteBirds = new GameObjects.Sprites(Content, "birdPeople", 45, 50);
            spriteBirds.SetUpdateSpeed(0, 0, 2);
            objectsImages.Add(banana);
            objectsSprites.Add(spriteBirds);
            
        }
        

        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            KeyboardState ob = Keyboard.GetState();

            if(ob.IsKeyDown(Keys.W))
            {
                banana.imageVector.X += 20;
                banana.imageVector.Y += 10;
            } 

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GT = gameTime;
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (GameObjects.Image item in objectsImages)
            {
                spriteBatch.Draw(item.texTure, item.imageVector, Color.White);
            }

            foreach (GameObjects.Sprites item in objectsSprites)
            {
                spriteBatch.Draw(item.GetTexture2D(), item.imageVector, item.rec, Color.White);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
