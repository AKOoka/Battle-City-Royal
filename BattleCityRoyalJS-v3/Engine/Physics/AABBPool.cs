using System;

namespace BattleCityRoyalJS_v3.Desktop.Engine.Physics
{
    public class AABBPool : SimplePool<AABB>
    {
        public AABBPool(int size) : base(size)
        {
        }
    }
}
