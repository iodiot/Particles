using System;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class CustomShapeState : State
  {
    public CustomShapeState(Core core) : base(core, 1.0f)
    {
    }

    public override void OnSpawn(Particle particle)
    {
      var startPosition = new Vector2(400, 250);
      var radius = 10.0f;

      particle.Position.X = ((float)random.NextDouble() * radius * 2.0f - radius) + startPosition.X;
      particle.Position.Y = ((float)random.NextDouble() * radius * 2.0f - radius) + startPosition.Y;

      particle.Velocity.X = 2.0f * ((float)random.NextDouble() * 2.0f - 1.0f);
      particle.Velocity.Y = 2.0f * ((float)random.NextDouble() * 2.0f - 1.0f);

      particle.RotationSpeed = 0.1f * ((float)random.NextDouble() * 2.0f - 1.0f);
      particle.Color = new Color(
        (float)random.NextDouble() * 0.5f + 0.5f, 
        (float)random.NextDouble() * 0.5f + 0.5f, 
        (float)random.NextDouble() * 0.5f + 0.5f
      );
      particle.Sprite = core.StarSprite;
      particle.Scale = new Vector2(1.0f, 1.0f);
      particle.Ttl = 100 + random.Next() % 50;
    }

    public override void OnPostUpdate(Particle particle)
    {
      if (particle.Ttl < 50)
      {
        particle.Color *= 0.9f;
      }
    }
  }
}

