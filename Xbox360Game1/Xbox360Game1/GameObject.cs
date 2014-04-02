using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xbox360Game1
{
    public abstract class GameObject
    {
        public Vector2 speed;
        public Vector2 position;

        protected Texture2D sprite;

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            UpdateObject(gameTime, graphics);

            position.X += speed.X;
            position.Y += speed.Y;
        }

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        protected abstract void UpdateObject(GameTime gameTime, GraphicsDeviceManager graphics);
    }
}
