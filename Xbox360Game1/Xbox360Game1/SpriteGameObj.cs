using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace Xbox360Game1
{
    public class SpriteGameObj : GameObject
    {

        SoundEffect bounceSound;

        SpriteGameObj()
        {
            position = Vector2.Zero;
            speed = new Vector2(50, 50);
        }

        SpriteGameObj(float x, float y)
        {
            position = new Vector2(x, y);
            speed = new Vector2(50, 50);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("profile_pic");
            bounceSound = content.Load<SoundEffect>("sound/bounceSound");
        }

        public override void UnloadContent()
        {
            //Should something go here?
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }

        protected override void UpdateObject(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - sprite.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - sprite.Height;
            int MinY = 0;

            // Check for bounce.
            if (position.X > MaxX)
            {
                bounceSound.Play();
                speed.X *= -1;
                position.X = MaxX;
            }

            else if (position.X < MinX)
            {
                bounceSound.Play();
                speed.X *= -1;
                position.X = MinX;
            }

            if (position.Y > MaxY)
            {
                bounceSound.Play();
                speed.Y *= -1;
                position.Y = MaxY;
            }

            else if (position.Y < MinY)
            {
                bounceSound.Play();
                speed.Y *= -1;
                position.Y = MinY;
            }

            // Get the current gamepad state.
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            // Process input only if connected and button A is pressed.
            if (currentState.IsConnected && currentState.Buttons.A ==
                ButtonState.Pressed)
            {
                // Button A is currently being pressed;
                if (Math.Abs(speed.Y) == 50) speed.Y *= -2;
            }
            else
            {
                // Button A is not being pressed;
                if (speed.Y > 0) speed.Y = 50;
                else speed.Y *= -50;
            }
        }
    }
}
