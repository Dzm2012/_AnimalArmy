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
        Camera m_camera;
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
            spriteBirds = new GameObjects.Sprites(Content, "birdPeople", 45, 50,0,45/2,50/2);
            spriteBirds.SetUpdateSpeed(0, 0, 0, 0, 250);
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
            spriteBirds.SetKeyboardState(ob);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GT = gameTime;
            GraphicsDevice.Clear(Color.Black);
            m_camera = new Camera(new Rectangle(0,0,1600,900));
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, m_camera.viewMatrix);
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
    public class Camera
    {
        public Matrix viewMatrix;
        private Vector2 m_position;
        private Vector2 m_halfViewSize;

        public Camera(Rectangle clientRect)
        {
            m_halfViewSize = new Vector2(clientRect.Width * 0.5f, clientRect.Height * 0.5f);
            UpdateViewMatrix();
        }

        public Vector2 Pos
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
                UpdateViewMatrix();
            }
        }

        private void UpdateViewMatrix()
        {
            viewMatrix = Matrix.CreateTranslation(m_halfViewSize.X - m_position.X, m_halfViewSize.Y - m_position.Y, 0.0f);
        }
    }
}
