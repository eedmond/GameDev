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
        //Running = normal, PAUSED = no update, still draws, DISABLED = no update or draw
        public enum STATUS { RUNNING, PAUSED, DISABLED };


        List<GameObject> objects;
        Texture2D background;
        ContentManager content;

        public STATUS status = STATUS.RUNNING;

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
            go.map = this;
        }

        public void AddMultiple(IEnumerable<GameObject> objs)
        {
            foreach (GameObject go in objs)
                AddObject(go);
        }

        public void RemoveObject(GameObject go)
        {
            objects.Remove(go);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (status != STATUS.RUNNING)
                return;

            foreach (GameObject go in objects)
                go.Update(gameTime, graphics);
        }

        public void Draw(GameTime gameTime, GraphicsDevice device)
        {
            if (status == STATUS.DISABLED)
                return; //Don't draw anything

            SpriteBatch spriteBatch = new SpriteBatch(device);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            foreach(GameObject go in objects)
            {
                go.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }
        
        /// <summary>
        /// If you are not using the map, and will not for a long time, then call this to unload all content.
        /// By default this sets the status to disabled. Be sure to re-enable it before you use it again.
        /// If this gets called, you MUST call ReloadAll before using the map again.
        /// </summary>
        public void UnloadAll()
        {
            status = STATUS.DISABLED;
            content.Unload();
        }

        /// <summary>
        /// Loads all content. 
        /// </summary>
        public void ReloadAll()
        {
            foreach (GameObject go in objects)
                go.LoadContent(content);
        }



    }
}
