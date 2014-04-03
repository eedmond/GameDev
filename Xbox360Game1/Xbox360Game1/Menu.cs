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
        int selectedIndex;

        Color unselected = Color.WhiteSmoke;
        Color selected = Color.Red;

        SpriteFont font;

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

        protected int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                selectedIndex = value;
            }
        }

        public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsButtonDown(Buttons.DPadDown) || gamePadState.IsButtonDown(Buttons.LeftThumbstickDown))
            {
                selectedIndex++;
                if (selectedIndex == menuOptions.Count())
                    selectedIndex = 0;
            }

            if (gamePadState.IsButtonDown(Buttons.DPadUp) || gamePadState.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuOptions.Count() - 1;
            }
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            // nothing to load unless we use textures
            return;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 location = position;
            Color tint;

            for (int i = 0; i < menuOptions.Count(); i++)
            {
                if (i == selectedIndex)
                    tint = selected;
                else
                    tint = unselected;

                spriteBatch.DrawString(font, menuOptions[i], location, tint);
                location.Y += font.LineSpacing + 5;
            }
        }

        private void MeasureMenu()
        {
            float height = 0;
            float width = 0;

            foreach (String option in menuOptions)
            {
                Vector2 stringSize = font.MeasureString(option);
                if (stringSize.X > width)
                    width = stringSize.X;
                height += font.LineSpacing + 5;
            }

            position = new Vector2((screenBounds.Width - width) / 2, (screenBounds.Height - height) / 2);
        }
    }
}
