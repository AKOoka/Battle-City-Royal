using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class TankPlayerController : TankController
    {
        public TankPlayerController()
        {

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                direction = Orientation.North;
            }
            else if (state.IsKeyDown(Keys.D))
            {
                direction = Orientation.East;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                direction = Orientation.South;
            }
            else if (state.IsKeyDown(Keys.A))
            {
                direction = Orientation.West;
            }
            else
            {
                direction = Orientation.None;
            }

            if (state.IsKeyDown(Keys.Space))
            {
                fire = true;
            }
            else
            {
                fire = false;
            }
        }
    }
}
