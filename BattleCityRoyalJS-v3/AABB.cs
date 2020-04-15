using System;
using Microsoft.Xna.Framework;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class AABB
    {
        private Vector2 min;
        private Vector2 max;

        public Vector2 Min { get => min; set => min = value; }
        public Vector2 Max { get => max; set => max = value; }

        public AABB(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }

        public AABB(Rectangle rectangle)
        {
            this.min = rectangle.Location.ToVector2();
            this.max = new Vector2(rectangle.Width, rectangle.Height) + this.min;
        }

        public bool CollideAABB(AABB target)
        {
            return CollideAABB(this, target);
        }

        public static bool CollideAABB(AABB first, AABB second)
        {
            bool collizionHor = false;
            bool collizionVer = false;

            if (first.min.X <= second.min.X && first.max.X >= second.min.X)
            {
                collizionHor = true;
            }
            else if (first.min.X <= second.max.X && first.max.X >= second.max.X)
            {
                collizionHor = true;
            }

            if (first.min.Y <= second.min.Y && first.max.Y >= second.min.Y)
            {
                collizionVer = true;
            }
            else if (first.min.Y <= second.max.Y && first.max.Y >= second.max.Y)
            {
                collizionVer = true;
            }

            return collizionHor && collizionVer;
        }
    }
}
