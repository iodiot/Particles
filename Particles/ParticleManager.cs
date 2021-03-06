﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Particles
{
  public class ParticleManager
  {
    public float SpawnRate;

    private readonly Core core;
    private readonly Random random;

    public Action<Particle> OnSpawn;
    public Action<Particle> OnPreUpdate;
    public Action<Particle> OnPostUpdate;

    private List<Particle> particles, particlesToAdd;

    private int deadCounter;

    public ParticleManager(Core core, float spawnRate)
    {
      this.core = core;
      SpawnRate = spawnRate;

      particles = new List<Particle>();
      particlesToAdd = new List<Particle>();

      random = new Random();
    }

    public void Spawn()
    {
      var particle = new Particle();

      if (OnSpawn != null)
      {
        OnSpawn(particle);
      }

      particlesToAdd.Add(particle);
    }

    public void Spawn(Particle particle)
    {
      particlesToAdd.Add(particle);
    }

    public void Update(int ticks)
    {
      deadCounter = 0;

      for (var i = 0; i < (int)Math.Floor(SpawnRate); ++i)
      {
        Spawn();
      }

      if (SpawnRate - Math.Floor(SpawnRate) >= random.NextDouble())
      {
        Spawn();
      }

      particles.AddRange(particlesToAdd);
      particlesToAdd.Clear();

      if (OnPreUpdate != null)
      {
        foreach (var p in particles)
        {
          if (p.Ttl > 0)
          {
            OnPreUpdate(p);
          }
        }
      }

      foreach (var p in particles)
      {
        if (p.Ttl > 0)
        {
          p.Position += p.Velocity;
          p.Rotation += p.RotationSpeed;
          p.Ttl -= 1;
        }
        else
        {
          ++deadCounter;
        }
      }

      if (OnPostUpdate != null)
      {
        foreach (var p in particles)
        {
          if (p.Ttl > 0)
          {
            OnPostUpdate(p);
          }
        }
      }

      if (deadCounter > 100 || ticks % 1000 == 0)
      {
        RemoveDeadParticles();
      }

      Console.WriteLine(particles.Count.ToString());
    }

    private void RemoveDeadParticles()
    {
      var newParticles = new List<Particle>();

      foreach (var p in particles)
      {
        if (p.Ttl > 0)
        {
          newParticles.Add(p);
        }
      }

      particles = newParticles;
    }

    public void Draw()
    {
      foreach (var p in particles)
      {
        if (p.Ttl > 0)
        {
          core.Draw(
            p.Sprite,
            p.Position,
            p.Scale,
            p.Color,
            p.Rotation
          );
        }
      }
    }
  }
}

