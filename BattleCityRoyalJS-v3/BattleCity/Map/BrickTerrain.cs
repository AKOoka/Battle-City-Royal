using System;
namespace BattleCityRoyalJS_v3.Desktop
{
    public class BrickTerrain : TerrainEntitiy
    {
        private CollidableTerrainComponent collidable;
        private DestructableTerrainComponent destructable;

        public BrickTerrain()
        {
            collidable = new CollidableTerrainComponent();
            destructable = new DestructableTerrainComponent(collidable);
        }
    }
}
