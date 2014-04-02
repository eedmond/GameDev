using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xbox360Game1
{
    public abstract class GameObject
    {
        public Vector2 position;
        protected Texture2D sprite;

        GamePadState gamePadState;
        KeyboardState keyboardState;

        public abstract void Update(GameTime gameTime, GraphicsDeviceManager graphics);
        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
