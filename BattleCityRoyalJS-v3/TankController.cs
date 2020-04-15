using System;
using Microsoft.Xna.Framework;
namespace BattleCityRoyalJS_v3.Desktop
{
    public abstract class TankController
    {
        protected Vector2 direction;
        protected Boolean fire;

        public TankController()
        {
            direction = Vector2.Zero;
            fire = false;
        }

        public abstract void Update(GameTime gameTime);

        public bool Fire { get => fire; }
        public Vector2 Direction { get => direction; }
    }
}
