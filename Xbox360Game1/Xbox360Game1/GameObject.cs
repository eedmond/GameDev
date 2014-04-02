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
        /// <summary>
        /// This will be set by the owning map... do not modify this in Update!
        /// </summary>
        public GameMap map;

        public Vector2 position;
        protected Texture2D sprite;

        protected GamePadState gamePadState;
        protected KeyboardState keyboardState;

        public abstract void Update(GameTime gameTime, GraphicsDeviceManager graphics);
        public abstract void LoadContent(ContentManager content);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
