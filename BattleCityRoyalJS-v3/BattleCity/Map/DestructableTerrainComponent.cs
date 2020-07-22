using System;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class DestructableTerrainComponent : ICollidable
    {
        private CollidableTerrainComponent component;

        public DestructableTerrainComponent(CollidableTerrainComponent collidableTerrainComponent)
        {
            component = collidableTerrainComponent;
            component.Subscribe(this);
        }

        public void Collide(CollideData data)
        {
            throw new NotImplementedException();
        }

        ~DestructableTerrainComponent()
        {
            component.Unsubscribe(this);
        }
    }
}
