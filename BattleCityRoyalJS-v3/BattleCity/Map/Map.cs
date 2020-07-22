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
        Flag,
        EmptyBlock
    }

    public class Map
    {
        // TerrainTile[] map;
        private static readonly Rectangle[] blockToRect = 
        {
            new Rectangle(272, 32, 16, 16),
            new Rectangle(256, 0, 16, 16),
            new Rectangle(256, 16, 16, 16),
            new Rectangle(256, 32, 16, 16),
            new Rectangle(288, 32, 16, 16),
            new Rectangle(304, 32, 16, 16),
            new Rectangle(272, 26, 1, 1)
        };
        Block[] blocks;
        int width;
        int height;
        Random random;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            random = new Random();

            blocks = new Block[width * height];

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = (Block)random.Next(blockToRect.Length);
            }

            //blocks[3] = Block.Wall;
            //blocks[7] = Block.Water;
            //blocks[22] = Block.SteelWall;

            //map = new Tile[width * height];
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {
            for (int i = 0; i < height; i++)
            {
                for (int l = 0; l < width; l++)
                {
                    spriteBatch.Draw(sprite, new Rectangle(i * 16, l * 16, 16, 16), blockToRect[(int)blocks[i * width + l]], Color.White);
                
                    if (i == 0 || l == 0 || l == width - 1 || i == height - 1)
                    {
                        spriteBatch.Draw(sprite, new Rectangle(i * 16, l * 16, 16, 16), blockToRect[(int)Block.SteelWall], Color.White);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
