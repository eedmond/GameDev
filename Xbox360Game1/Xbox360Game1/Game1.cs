using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Xbox360Game1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        // This is a texture we can render.
        Texture2D myTexture;

        // Set the coordinates to draw the sprite at.
        Vector2 spritePosition = Vector2.Zero;
        SoundEffect BounceSound;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("profile_pic");
            BounceSound = Content.Load<SoundEffect>("sound/bounceSound");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        // Store some information about the sprite's motion.
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed)
                this.Exit();

            // Move the sprite around.
            UpdateSprite(gameTime);

            base.Update(gameTime);
        }

        void UpdateSprite(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time.
            spritePosition +=
                spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            int MinY = 0;

            // Check for bounce.
            if (spritePosition.X > MaxX)
            {
                BounceSound.Play();
                spriteSpeed.X *= -1;
                spritePosition.X = MaxX;
            }

            else if (spritePosition.X < MinX)
            {
                BounceSound.Play();
                spriteSpeed.X *= -1;
                spritePosition.X = MinX;
            }

            if (spritePosition.Y > MaxY)
            {
                BounceSound.Play();
                spriteSpeed.Y *= -1;
                spritePosition.Y = MaxY;
            }

            else if (spritePosition.Y < MinY)
            {
                BounceSound.Play();
                spriteSpeed.Y *= -1;
                spritePosition.Y = MinY;
            }
            // Get the current gamepad state.
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            // Process input only if connected and button A is pressed.
            if (currentState.IsConnected && currentState.Buttons.A ==
                ButtonState.Pressed)
            {
                // Button A is currently being pressed;
                if (Math.Abs(spriteSpeed.Y) == 50) spriteSpeed.Y *= -2;
            }
            else
            {
                // Button A is not being pressed;
                if (spriteSpeed.Y > 0) spriteSpeed.Y = 50;
                else spriteSpeed.Y *= -50;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the sprite.
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spriteBatch.Draw(myTexture, spritePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
