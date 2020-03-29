using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattleCityRoyalJS_v2.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sprite;
        Texture2D texture1x1;
        SpriteFont font;
        Tank playerTank;
        Tank[] stupidEnemies;
        Matrix transformMatrix;
        MouseState mouseState;
        float scaleFactor;
        DebugDrawer debug;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;

            Window.IsBorderless = true;
            IsMouseVisible = true;
            Window.AllowAltF4 = true;

            transformMatrix = Matrix.Identity;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            debug = new DebugDrawer();

            Random random = new Random();

            Color randomColor = new Color(
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255)
            );

            playerTank = new Tank(new TankPlayerController(), TankType.Tank1, new Vector2(400, 400), randomColor);
            stupidEnemies = new Tank[10000];

            for (int i = 0; i < stupidEnemies.Length; i++)
            {
                randomColor = new Color(
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255)
                );

                stupidEnemies[i] = new Tank(new TankStupidAIController(), (TankType)random.Next(0, 8), new Vector2(400, 400), randomColor);
            }

            mouseState = Mouse.GetState();
            scaleFactor = 1.0f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite = Content.Load<Texture2D>("sprite");
            texture1x1 = Content.Load<Texture2D>("texture1x1");
            font = Content.Load<SpriteFont>("font");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerTank.Update(gameTime);

            foreach(var tank in stupidEnemies)
            {
                tank.Update(gameTime);
                debug.DrawDebugAABB(tank.Aabb, 2, Color.Black);
            }

            debug.DrawDebugLine(new Vector2(100, 150), new Vector2(300, 300), 5, Color.Red);
            debug.DrawDebugAABB(playerTank.Aabb, 2, Color.Plum);

            MouseState currentMouseState = Mouse.GetState();
            int valueDifference = mouseState.ScrollWheelValue - currentMouseState.ScrollWheelValue;

            scaleFactor += (float)(valueDifference * 0.02f * gameTime.ElapsedGameTime.TotalSeconds);

            mouseState = currentMouseState;

            //transformMatrix = Matrix.Multiply(Matrix.CreateScale(2.0f), transformMatrix);
            transformMatrix = Matrix.CreateScale(scaleFactor);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix);
            playerTank.Draw(gameTime, spriteBatch, sprite, font);

            foreach (var tank in stupidEnemies)
            {
                tank.Draw(gameTime, spriteBatch, sprite, font);
            }

            spriteBatch.End();

            debug.Draw(gameTime, texture1x1, spriteBatch, font, transformMatrix);

            base.Draw(gameTime);
        }
    }
}
