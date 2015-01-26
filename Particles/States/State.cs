using System;

namespace Particles
{
  public class State
  {
    protected readonly Core core;
    protected readonly Random random;
    protected ParticleManager pm;

    public State(Core core, float spawnRate)
    {
      this.core = core;
     
      random = new Random();
      pm = new ParticleManager(core, spawnRate);

      pm.OnSpawn = OnSpawn;
      pm.OnPreUpdate = OnPreUpdate;
      pm.OnPostUpdate = OnPostUpdate;
    }

    public virtual void Update(int ticks)
    {
      pm.Update(ticks);
    }

    public virtual void Draw()
    {
      pm.Draw();
    }

    public virtual void OnSpawn(Particle particle)
    {
    }

    public virtual void OnPreUpdate(Particle particle)
    {
    }

    public virtual void OnPostUpdate(Particle particle)
    {
    }
  }
}

