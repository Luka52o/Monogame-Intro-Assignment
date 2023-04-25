using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Intro_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D windowsXPBliss, asteroidTexture, manRunning, geeseFlying, apocolypse;
        Random generator1 = new Random();
        Random generator2 = new Random();
        int runningManxPos, geeseFlyingxPos;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 964;
            _graphics.ApplyChanges();
            runningManxPos = generator1.Next(1, 1001);
            geeseFlyingxPos = generator2.Next(1, 1001);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            asteroidTexture = Content.Load<Texture2D>("asteroid (1)");
            windowsXPBliss = Content.Load<Texture2D>("windowsXPBliss");
            manRunning = Content.Load<Texture2D>("manRunning");
            geeseFlying = Content.Load<Texture2D>("geeseFlying");
            apocolypse = Content.Load<Texture2D>("apocolypse");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            if (geeseFlyingxPos % 2 == 0)
            {
                _spriteBatch.Draw(windowsXPBliss, new Vector2(0, 0), Color.White);
            }
            else
            {
                _spriteBatch.Draw(apocolypse, new Vector2(0, 0), Color.White);
            }
            _spriteBatch.Draw(asteroidTexture, new Vector2(731, 0), Color.White);
            _spriteBatch.Draw(manRunning, new Vector2(runningManxPos, 600), Color.White);
            _spriteBatch.Draw(geeseFlying, new Vector2(geeseFlyingxPos, 10), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}