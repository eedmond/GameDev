using Microsoft.Xna.Framework;
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

        void Update(GameTime gameTime)
        {
            UpdateObject(gameTime);

            position.X += speed.X;
            position.Y += speed.Y;
        }

        abstract void UpdateObject(GameTime gameTime);
        abstract void Draw(GameTime gameTime);
    }
}
