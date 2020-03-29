using Microsoft.Xna.Framework;

namespace BattleCityRoyalJS_v2.Desktop
{
    public enum TileFormat
    {
        Format_1x1,
        Format_1x05,
        Format_05x1,
        Format_05x05,
        Format_05x025,
        Format_025x05,
        Format_025x025
    }

    public class Tile
    {
        private const int width = 16;
        private const int height = 16;
        private int row;
        private int column;
        private TileFormat format;

        public Tile(int row, int column, TileFormat format = TileFormat.Format_1x1)
        {
            this.row = row;
            this.column = column;
            this.format = format;
        }

        public Rectangle GetSourceRectangle()
        {
            Rectangle sourceRectangle = new Rectangle();

            switch (format)
            {
                case TileFormat.Format_1x1:
                    sourceRectangle = new Rectangle(row * width, column * height, width, height);
                    break;
                case TileFormat.Format_1x05:
                    break;
                case TileFormat.Format_05x1:
                    break;
                case TileFormat.Format_05x05:
                    break;
                case TileFormat.Format_05x025:
                    break;
                case TileFormat.Format_025x05:
                    break;
                case TileFormat.Format_025x025:
                    break;
            }

            return sourceRectangle;
        }
    }
}