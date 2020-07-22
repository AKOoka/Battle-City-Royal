using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class Projectile
    {
        private bool isEnable;
        private ProjectileType type;
        private Vector2 direction;
        private Vector2 position;

        public bool IsEnable { get => isEnable; set => isEnable = value; }
        public ProjectileType Type { get => type; set => type = value; }
        public Vector2 Direction { get => direction; set => direction = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Projectile()
        {
            isEnable = false;
            type = ProjectileType.lvl1;
            direction = Orientation.North;
            position = new Vector2(0.0f, 0.0f);
        }

        public void OnCollide()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {
            float rotation = 0.0f;

            if (direction == Orientation.East)
                rotation = 0.0f;
            if (direction == Orientation.South)
                rotation = (float)(Math.PI * 0.5);
            if (direction == Orientation.West)
                rotation = (float)(Math.PI);
            if (direction == Orientation.North)
                rotation = (float)(Math.PI * 1.5);

            spriteBatch.Draw(sprite, position - new Vector2(2.0f, 1.5f), new Rectangle(346, 102, 4, 3), Color.Black, rotation, new Vector2(2.0f, 1.5f), 1.0f, SpriteEffects.None, 0.0f);
        }

        public void Update(GameTime gameTime)
        {
            Vector2 delta = direction * GetVelocityByProjectileType(type) * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += delta;
        }

        private static float GetVelocityByProjectileType(ProjectileType type)
        {
            switch (type)
            {
                case ProjectileType.lvl1:
                    return 20.0f;
                case ProjectileType.lvl2:
                    return 30.0f;
                case ProjectileType.lvl3:
                    return 40.0f;
            }

            return 0.0f;
        }

        private static int GetDamageByProjectileType(ProjectileType type)
        {
            switch (type)
            {
                case ProjectileType.lvl1:
                    return 1;
                case ProjectileType.lvl2:
                    return 2;
                case ProjectileType.lvl3:
                    return 3;
            }

            return 0;
        }
    }
}
