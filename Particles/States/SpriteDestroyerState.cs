using System;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class SpriteDestroyerState : State
  {
    public SpriteDestroyerState(Core core) : base(core, 0.0f)
    {
      var startPosition = new Vector2(250, 100);
      var colors = new Color[core.ScreamSprite.Width * core.ScreamSprite.Height];

      core.ScreamSprite.GetData(colors, 0, colors.Length);

      for (var x = 0; x < core.ScreamSprite.Width; ++x)
      {
        for (var y = 0; y < core.ScreamSprite.Height; ++y)
        {
          if (random.Next() % 10 > 0)
          {
            continue;
          }

          var p = new Particle();

          p.Position = startPosition + new Vector2(x, y);
          p.Color = colors[x + y * core.ScreamSprite.Width];
          p.Ttl = 500 + random.Next() % 100 + y * 2;
          p.Sprite = core.OnePixel;
          p.Scale = new Vector2(5.0f, 5.0f);

          pm.Spawn(p);
        }
      }
    }

    public override void OnPreUpdate(Particle particle)
    {
      if (particle.Ttl == 400)
      {
        particle.Velocity.X = ((float)random.NextDouble() * 2.0f - 1.0f) * 1.0f;
        particle.Velocity.Y = (float)random.NextDouble() * -3.0f;

        particle.RotationSpeed = ((float)random.NextDouble() * 2.0f - 1.0f) * 0.1f;
      }

      if (particle.Ttl < 350)
      {
        particle.Color *= 0.99f;
      }

      // add gravity
      if (particle.Ttl < 400)
      {
        if (particle.Position.Y < 450)
        {
          particle.Velocity.Y += 0.05f;
        }
        else
        {
          particle.Velocity = Vector2.Zero;
        }
      }
    }
  }
}

