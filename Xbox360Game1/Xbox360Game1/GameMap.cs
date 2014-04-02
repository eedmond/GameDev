using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Xbox360Game1
{
    public class GameMap
    {
        
        List<GameObject> objects;
        Texture2D background;
        ContentManager content;

        /// <summary>
        /// Create a new Map. Only should be used from the main Game class.
        /// </summary>
        /// <param name="serviceProvider">Get this by doing: Content.ServiceProvider</param>
        /// <param name="backgroundName">The path to the content to be used for a background. Use null if there is none.</param>
        public GameMap(IServiceProvider serviceProvider, string backgroundName)
        {
            content = new ContentManager(serviceProvider);
            if (backgroundName != null)
                background = content.Load<Texture2D>(backgroundName);
        }

        /// <summary>
        /// Use this to add objects after the first initialization of the map. 
        /// Mainly for things that are created on the fly (i.e. projectiles)
        /// </summary>
        public void AddObject(GameObject go)
        {
            objects.Add(go);
            go.LoadContent(content);
        }

        public void RemoveObject(GameObject go)
        {
            objects.Remove(go);
        }

        public void Draw(GameTime gameTime, GraphicsDevice device)
        {
            SpriteBatch spriteBatch = new SpriteBatch(device);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            foreach(GameObject go in objects)
            {
                go.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

    }
}
