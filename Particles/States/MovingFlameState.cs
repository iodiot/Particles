using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class MovingFlameState : FlameState
  {
    private MouseState prevMouseState;

    public MovingFlameState(Core core) : base(core)
    {
    }

    public override void Update(int ticks)
    {
      var mouseState = Mouse.GetState();

      if (mouseState.X != prevMouseState.X || mouseState.Y != prevMouseState.Y)
      {
        pm.SpawnRate = 10.0f;
        startPosition = new Vector2(mouseState.X, mouseState.Y);
      }
      else
      {
        pm.SpawnRate = 0;
      }

      prevMouseState = mouseState;

      base.Update(ticks);
    }
  }
}

