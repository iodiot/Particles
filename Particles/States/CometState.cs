using System;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class CometState : State
  {
    private const byte Comet = 1;
    private const byte Tail = 2;
    private const byte Bang = 3;

    public CometState(Core core) : base(core, 0.1f)
    {
    }

    public override void OnSpawn(Particle particle)
    {
      var startPosition = new Vector2(50, 200);

      particle.Position.X = startPosition.X;;
      particle.Position.Y = startPosition.Y + (float)random.NextDouble() * 50.0f;

      particle.Velocity.X = 3.0f + (float)random.NextDouble();
      particle.Velocity.Y = 2.0f * (float)random.NextDouble() - 1.0f;

      particle.Color = new Color(
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f
      );

      particle.Scale = new Vector2(0.6f, 0.6f);
      particle.Sprite = core.CircleSprite;
      particle.Ttl = 75 + random.Next() % 25;
      particle.Tag = Comet;
    }

    private void SpawnTail(Particle comet)
    {
      var particle = new Particle();

      particle.Position = comet.Position;

      particle.Position.X += ((float)random.NextDouble() * 2.0f - 1.0f) * 5.0f + 10.0f;
      particle.Position.Y += ((float)random.NextDouble() * 2.0f - 1.0f) * 5.0f + 10.0f;

      particle.Velocity.X = ((float)random.NextDouble() * 2.0f - 1.0f) * 0.5f;
      particle.Velocity.Y = (float)random.NextDouble() * -1.0f;

      particle.Color = new Color(
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f
      );

      particle.Sprite = core.CircleSprite;
      particle.Scale = new Vector2(0.05f, 0.05f);
      particle.Ttl = 25 + random.Next() % 25;
      particle.Tag = Tail;

      pm.Spawn(particle);
    }

    private void SpawnBang(Particle comet)
    {
      var particle = new Particle();

      particle.Position = comet.Position;

      particle.Position.X += ((float)random.NextDouble() * 2.0f - 1.0f) * 5.0f + 10.0f;
      particle.Position.Y += ((float)random.NextDouble() * 2.0f - 1.0f) * 5.0f + 10.0f;

      particle.Velocity.X = ((float)random.NextDouble() * 2.0f - 1.0f) * 3.0f;
      particle.Velocity.Y = ((float)random.NextDouble() * 2.0f - 1.0f) * 3.0f;

      particle.Color = new Color(
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f, 
        (float)random.NextDouble() * 0.25f + 0.75f
      );

      particle.Sprite = core.CircleSprite;
      particle.Scale = new Vector2(0.05f, 0.05f);
      particle.Ttl = 25 + random.Next() % 25;
      particle.Tag = Bang;

      pm.Spawn(particle);
    }

    public override void OnPreUpdate(Particle particle)
    {
      if (particle.Tag == Comet)
      {
        particle.Scale *= 0.99f;
      }

      particle.Color *= 0.99f;

      if (particle.Tag == Comet && particle.Ttl > 1)
      {
        SpawnTail(particle);
      }

      if (particle.Tag == Comet && particle.Ttl == 1)
      {
        for (var i = 0; i < 100; ++i)
        {
          SpawnBang(particle);
        }
      }
    }
  }
}

