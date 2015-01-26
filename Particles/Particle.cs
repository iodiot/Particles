using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Particles
{
  public class Particle
  {
    public Texture2D Sprite;
    public Vector2 Position;
    public Vector2 Velocity;
    public Color Color;
    public Vector2 Scale;
    public float Rotation;
    public int Ttl;
    public float RotationSpeed;
    public byte Tag;
  }
}

