using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public abstract class TerrainEntitiy
    {
        List<ITerrainComponent> components;

        public TerrainEntitiy()
        {
            components = new List<ITerrainComponent>();
        }
    }
}
