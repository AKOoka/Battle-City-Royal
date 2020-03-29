using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityRoyalJS_v2.Desktop
{
    public struct Line
    {
        public Vector2 p1;
        public Vector2 p2;
        public int lineWidth;
        public Color color;

        public Line(Vector2 p1, Vector2 p2, int lineWidth, Color color)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.lineWidth = lineWidth;
            this.color = color;
        }
    }

    public class DebugDrawer
    {
        private Line[] lines;
        private int lineIndex;
        private bool isActive;

        public bool IsActive { get => isActive; set => isActive = value; }

        public DebugDrawer()
        {
            lines = new Line[10000];
            isActive = true;
            lineIndex = 0;
        }

        public void DrawDebugLine(Vector2 p1, Vector2 p2, int lineWidth, Color color)
        {
            lines[lineIndex] = new Line(p1, p2, lineWidth, color);

            lineIndex = (lineIndex + 1) % lines.Length;
        }

        public void DrawDebugAABB(AABB aabb, int lineWidth, Color color)
        {
            Vector2 v1 = aabb.Min;
            Vector2 v2 = aabb.Max;
            Vector2 v3 = new Vector2(v1.X, v2.Y);
            Vector2 v4 = new Vector2(v2.X, v1.Y);

            DrawDebugLine(v3, v1, lineWidth, color);
            DrawDebugLine(v4, v1, lineWidth, color);
            DrawDebugLine(v3, v2, lineWidth, color);
            DrawDebugLine(v4, v2, lineWidth, color);
        }

        public void Draw(GameTime gameTime, Texture2D texture1x1, SpriteBatch spriteBatch, SpriteFont font, Matrix transformMatrix)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.Identity);

            for(int i = 0; i < lineIndex; i++)
            {
                Line l = lines[i];
                Vector2 v1 = l.p2 - l.p1;
                Vector2 v2 = new Vector2(1, 0);

                v1.Normalize();

                float halfWidth = l.lineWidth / 2.0f;
                float rotation = (float)Math.Acos(Vector2.Dot(v1, v2));

                if (v1.Y - v2.Y < 0)
                    rotation = -rotation;

                Rectangle rect = new Rectangle((int)l.p1.X, (int)(l.p1.Y - halfWidth), (int)((l.p2 - l.p1).Length()), l.lineWidth);

                spriteBatch.Draw(texture1x1, rect, null, l.color, rotation, new Vector2(0, 0), SpriteEffects.None, 1);

                //spriteBatch.Draw(texture1x1, new Rectangle((int)l.p1.X, (int)l.p1.Y, 10, 10), Color.Black);
                //spriteBatch.Draw(texture1x1, new Rectangle((int)l.p2.X, (int)l.p2.Y, 10, 10), Color.Black);
            }

            spriteBatch.End();

            lineIndex = 0;
        }
    }
}
