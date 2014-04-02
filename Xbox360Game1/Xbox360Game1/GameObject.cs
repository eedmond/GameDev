using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xbox360Game1
{
    public interface GameObject
    {
        public Vector2 position;
        protected Texture2D sprite;

        GamePadState gamePadState;
        KeyboardState keyboardState;

        public abstract void Update(GameTime gameTime, GraphicsDeviceManager graphics);
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
