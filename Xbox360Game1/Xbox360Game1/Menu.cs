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
        public Menu(List<String> menuOptions)
        {
            this.menuOptions = menuOptions;
        }

        public Menu(List<String> menuOptions, String menuName)
        {
            this.menuOptions = menuOptions;
            this.menuName = menuName;
        }

        public Menu(List<String> menuOptions, Texture2D background)
        {
            this.menuOptions = menuOptions;
            this.sprite = background;
        }

        public Menu(List<String> menuOptions, String menuName, Texture2D background)
        {
            this.menuOptions = menuOptions;
            this.menuName = menuName;
            this.sprite = background;
        }
        /**/
    }
}