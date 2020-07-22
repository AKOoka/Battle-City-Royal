using System;
using Microsoft.Xna.Framework;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class CollisionDetectionSystem : ISystem, IUpdateable
    {
        public CollisionDetectionSystem()
        {
        }

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void Dispose()
        {
        }

        public void Init()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
