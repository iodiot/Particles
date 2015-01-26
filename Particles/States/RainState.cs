using System;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class RainState : State
  {
    public RainState(Core core) : base(core, 3.0f)
    {
    }

    public override void OnSpawn(Particle particle)
    {
      var startRectangle = new Rectangle(-100, -25, 800, 25);

      particle.Position.X = random.Next() % (startRectangle.Width - startRectangle.X) + startRectangle.X;
      particle.Position.Y = random.Next() % (startRectangle.Height - startRectangle.Y) + startRectangle.Y;

      particle.Velocity.X = (float)random.NextDouble() * 1.0f + 2.0f;
      particle.Velocity.Y = 8.0f;

      particle.Color = Color.LightBlue;
      particle.Sprite = core.OnePixel;
      particle.Scale = new Vector2(10.0f, 1.0f);
      particle.Rotation = MathHelper.ToRadians(60.0f);
      particle.Ttl = 55;
    }

    public override void OnPreUpdate(Particle particle)
    {
      if (particle.Ttl == 1 && particle.Velocity.Y > 0.1f)
      {
        particle.Ttl = 25;
        particle.Rotation = 0;
        particle.Scale = new Vector2(3.0f, 3.0f);
        particle.Velocity = Vector2.Zero;
      }
    }
  }
}

