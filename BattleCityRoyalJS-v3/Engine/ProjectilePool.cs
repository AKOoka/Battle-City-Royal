using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class ProjectilePool
    {
        Projectile[] pool;
        private int index;

        public ProjectilePool(int poolSize)
        {
            pool = new Projectile[poolSize];
            index = 0;

            for (int i = 0; i < poolSize; i++)
            {
                pool[i] = new Projectile();
            }
        }

        public Projectile GetProjectile()
        {
            Projectile selectedProjectile = pool[index];

            index = (index + 1) % pool.Length;

            return selectedProjectile;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {
            foreach (var p in pool)
            {
                if (p.IsEnable)
                    p.Draw(gameTime, spriteBatch, sprite);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var p in pool)
            {
                if (p.IsEnable)
                    p.Update(gameTime);
            }
        }
    }
}
