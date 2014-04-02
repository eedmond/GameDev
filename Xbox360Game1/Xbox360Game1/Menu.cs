using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;


namespace Xbox360Game1
{
    class Menu : GameObject
    {
        List<String> menuOptions;
        String menuName;

        /* Constructors (you can't use optional arguments in here...) */
        public Menu(List<String> menuOptions) : this(menuOptions, "Menu", null) {}
        public Menu(List<String> menuOptions, String menuName) : this(menuOptions, menuName, null) {}
        public Menu(List<String> menuOptions, Texture2D background) : this(menuOptions, "Menu", background) {}
        public Menu(List<String> menuOptions, String menuName, Texture2D background)
        {
            this.menuOptions = menuOptions;
            this.menuName = menuName;
            this.sprite = background;
        }
        /**/


        public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
