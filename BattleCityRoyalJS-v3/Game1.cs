using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sprite;
        Texture2D texture1x1;
        SpriteFont font;
        Tank playerTank;
        Tank[] stupidEnemies;
        Projectile testProjectile;
        ProjectilePool projectilePool;
        Map map;
        Matrix transformMatrix;
        MouseState mouseState;
        float scaleFactor;
        DebugDrawer debug;
        MM mm;

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

        protected override void Initialize()
        {
            PoolManager poolManager = new PoolManager();
            SystemManager systemManger = new SystemManager();

            systemManger.AddSystem(new CollisionDetectionSystem());

            mm = MM.Instance;

            mm.AddManager(poolManager);
            mm.AddManager(systemManger);

            debug = new DebugDrawer();

            Random random = new Random();

            Color randomColor = new Color(
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255)
            );

            projectilePool = new ProjectilePool(10000);

            playerTank = new Tank(new TankPlayerController(), projectilePool, TankType.Tank1, new Vector2(400, 400), randomColor);
            stupidEnemies = new Tank[5000];

            testProjectile = new Projectile();
            testProjectile.IsEnable = true;
            testProjectile.Position = new Vector2(100.0f, 100.0f);
            testProjectile.Direction = Orientation.East;

            for (int i = 0; i < stupidEnemies.Length; i++)
            {
                randomColor = new Color(
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255)
                );

                stupidEnemies[i] = new Tank(new TankStupidAIController(), projectilePool, (TankType)random.Next(0, 8), new Vector2(400, 400), randomColor);
            }

            map = new Map(10, 24);

            mouseState = Mouse.GetState();
            scaleFactor = 2.0f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite = Content.Load<Texture2D>("sprite");
            texture1x1 = Content.Load<Texture2D>("texture1x1");
            font = Content.Load<SpriteFont>("font");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerTank.Update(gameTime);

            foreach(var tank in stupidEnemies)
            {
                tank.Update(gameTime);
                // debug.DrawDebugAABB(tank.Aabb, 2, Color.Black);
            }

            // debug.DrawDebugLine(new Vector2(100, 150), new Vector2(300, 300), 5, Color.Red);
            // debug.DrawDebugAABB(playerTank.Aabb, 2, Color.Plum);

            projectilePool.Update(gameTime);
            testProjectile.Update(gameTime);

            MouseState currentMouseState = Mouse.GetState();
            int valueDifference = mouseState.ScrollWheelValue - currentMouseState.ScrollWheelValue;

            scaleFactor += (float)(valueDifference * 0.02f * gameTime.ElapsedGameTime.TotalSeconds);

            mouseState = currentMouseState;

            //transformMatrix = Matrix.Multiply(Matrix.CreateScale(2.0f), transformMatrix);
            transformMatrix = Matrix.CreateScale(scaleFactor);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, transformMatrix);

            map.Draw(gameTime, spriteBatch, sprite);

            playerTank.Draw(gameTime, spriteBatch, sprite, font);

            foreach (var tank in stupidEnemies)
            {
                tank.Draw(gameTime, spriteBatch, sprite, font);
            }

            projectilePool.Draw(gameTime, spriteBatch, sprite);
            testProjectile.Draw(gameTime, spriteBatch, sprite);

            spriteBatch.End();

            //debug.Draw(gameTime, texture1x1, spriteBatch, font, transformMatrix);

            base.Draw(gameTime);
        }
    }
}
