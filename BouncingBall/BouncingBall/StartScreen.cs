using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BouncingBall {
    public class StartScreen : Screen {

        public StartScreen(Game1 game, Texture2D texture, int pX, int pY)
            : base(game, pX, pY) {
            this.setTexture(texture);
        }

        public StartScreen() { }

        public void Update() {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter) && getLastState().IsKeyUp(Keys.Enter))
                this.getGame().StartGame();

            this.setLastState(keyboardState);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.getTexture(), position, Color.White);
        }
    }
}
