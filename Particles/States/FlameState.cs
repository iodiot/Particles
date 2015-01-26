using System;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class FlameState : State
  {
    protected Vector2 startPosition = new Vector2(400, 300);

    public FlameState(Core core) : base(core, 3.14f)
    {
    }

    public override void OnSpawn(Particle particle)
    {
      float radius = 10;

      particle.Position.X = ((float)random.NextDouble() * radius * 2.0f - radius) + startPosition.X;
      particle.Position.Y = ((float)random.NextDouble() * radius * 2.0f - radius) + startPosition.Y;

      particle.Velocity.X = 0.5f * ((float)random.NextDouble() * 2.0f - 1.0f);
      particle.Velocity.Y = -2.0f * (float)random.NextDouble();

      particle.RotationSpeed = 0.5f * ((float)random.NextDouble() * 2.0f - 1.0f);
      particle.Color = new Color(
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.5f + 0.5f
      );
      particle.Sprite = core.OnePixel;
      particle.Scale = new Vector2(5.0f, 5.0f);
      particle.Ttl = 100 + random.Next() % 50;
    }

    public override void OnPostUpdate(Particle particle)
    {
      if (particle.Color.B > 0)
      {
        particle.Color.B -= 1;
      }

      particle.Scale *= 0.99f;
      particle.Color *= 0.995f;
    }
  }
}

