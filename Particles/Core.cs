using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Particles
{
  public class Core
  {
    private readonly SpriteBatch spriteBatch;
    private int ticks;

    public Texture2D OnePixel;
    public Texture2D StarSprite;
    public Texture2D CircleSprite;
    public Texture2D ScreamSprite;

    private State currentState;
    private KeyboardState prevKeyaboardState;

    public Core(SpriteBatch spriteBatch)
    {
      this.spriteBatch = spriteBatch;
    }

    public void Load(ContentManager content)
    {
      OnePixel = content.Load<Texture2D>("one");
      StarSprite = content.Load<Texture2D>("star");
      CircleSprite = content.Load<Texture2D>("circle");
      ScreamSprite = content.Load<Texture2D>("scream");

      currentState = new SpriteDestroyerState(this);
    }

    public void HandleInput()
    {
      var keyboardState = Keyboard.GetState();

      if (prevKeyaboardState.IsKeyDown(Keys.Space) && keyboardState.IsKeyUp(Keys.Space))
      {
        if (currentState is FlameState && !(currentState is MovingFlameState))
        {
          currentState = new MovingFlameState(this);
        }
        else if (currentState is MovingFlameState)
        {
          currentState = new RainState(this);
        }
        else if (currentState is RainState)
        {
          currentState = new CustomShapeState(this);
        }
        else if (currentState is CustomShapeState)
        {
          currentState = new CometState(this);
        }
        else if (currentState is CometState)
        {
          currentState = new SpriteDestroyerState(this);
        }
        else if (currentState is SpriteDestroyerState)
        {
          currentState = new FlameState(this);
        }
      }

      prevKeyaboardState = keyboardState;
    }

    public void Update()
    {
      HandleInput();

      if (currentState != null)
      {
        currentState.Update(ticks);
      }
      
      ++ticks;
    }

    public void Draw()
    {
      if (currentState != null)
      {
        currentState.Draw();
      }
    }

    public void DrawRectangle(Vector2 position, float width, float height, Color color, float rotation)
    {
      spriteBatch.Draw(OnePixel, position, null, color, rotation, Vector2.Zero, new Vector2(width, height), SpriteEffects.None, 0);
    }

    public void Draw(Texture2D texture, Vector2 position, Vector2 scale, Color color, float rotation)
    {
      spriteBatch.Draw(texture, position, null, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 0);
    }
  }
}

