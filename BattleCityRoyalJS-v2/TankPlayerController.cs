using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BattleCityRoyalJS_v2.Desktop
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
        }
    }
}
