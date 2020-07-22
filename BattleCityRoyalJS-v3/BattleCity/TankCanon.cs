using System;
using Microsoft.Xna.Framework;

namespace BattleCityRoyalJS_v3.Desktop
{
    public enum ProjectileType
    {
        lvl1 = 0,
        lvl2,
        lvl3
    }

    public class TankCanon
    {
        private float cooldown;
        private double shotTime;
        private Vector2 position;
        private Vector2 direction;
        private ProjectilePool projectilePool;
        private ProjectileType projectileLevel;
        private TankController tankController;

        public float Cooldown { get => cooldown; set => cooldown = value; }
        public ProjectileType ProjectileLevel { get => projectileLevel; set => projectileLevel = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Direction { get => direction; set => direction = value; }

        public TankCanon(TankController tankController, ProjectilePool projectilePool)
        {
            cooldown = 500.0f;
            shotTime = 0.0;
            this.projectilePool = projectilePool;
            projectileLevel = ProjectileType.lvl1;
            position = new Vector2(0.0f, 0.0f);
            direction = new Vector2(0.0f, 0.0f);
            this.tankController = tankController;
        }

        public void Update(GameTime gameTime)
        {
            if (tankController.Fire && (gameTime.TotalGameTime.TotalMilliseconds - shotTime) >= cooldown)
            {
                shotTime = gameTime.TotalGameTime.TotalMilliseconds;

                Projectile projectile = projectilePool.GetProjectile();

                projectile.IsEnable = true;
                projectile.Position = position;
                projectile.Direction = direction;
                projectile.Type = projectileLevel;
            }
        }
    }
}
