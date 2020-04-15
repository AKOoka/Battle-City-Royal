using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public interface ICollidable
    {
        void Collide(CollideData data);
    }
}
