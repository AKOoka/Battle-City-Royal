using System;
using Microsoft.Xna.Framework;

namespace BattleCityRoyalJS_v2.Desktop
{
    public class TankStupidAIController : TankController
    {
        private static Random random;
        private float time;

        public TankStupidAIController()
        {
            random = new Random();
            time = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            if ((float)gameTime.TotalGameTime.TotalSeconds > time + (float)random.NextDouble() * 3.5f + 0.5f)
            {
                int randomNumber = random.Next(0, 4);

                time = (float)gameTime.TotalGameTime.TotalSeconds;

                switch (randomNumber)
                {
                    case 0:
                        direction = Orientation.East;
                        break;
                    case 1:
                        direction = Orientation.South;
                        break;
                    case 2:
                        direction = Orientation.West;
                        break;
                    case 3:
                        direction = Orientation.North;
                        break;
                }
            }
        }
    }
}
