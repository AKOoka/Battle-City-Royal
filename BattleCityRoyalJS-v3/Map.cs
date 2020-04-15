using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v3.Desktop
{
    public enum Block
    {
        Forest,
        Wall,
        SteelWall,
        Water,
        Ice,
        Flag
    }

    public class Map
    {
        // TerrainTile[] map;
        Block[] blocks;
        int width;
        int height;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            //map = new Tile[width * height];
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
