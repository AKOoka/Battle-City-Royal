using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class CollidableTerrainComponent : ITerrainComponent, ICollidable
    {
        private AABB aabb;
        private List<ICollidable> components;

        public CollidableTerrainComponent()
        {
            components = new List<ICollidable>();
        }

        public void Subscribe(ICollidable component)
        {
            components.Add(component);
        }

        public void Unsubscribe(ICollidable component)
        {
            components.Remove(component);
        }

        public void Collide(CollideData data)
        {
            foreach(var component in components)
            {
                component.Collide(data);
            }
        }
    }
}
