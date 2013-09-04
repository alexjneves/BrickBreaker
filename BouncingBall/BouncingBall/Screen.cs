using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BouncingBall {
    public class Screen {
        private Game1 game;
        private Texture2D texture;
        private KeyboardState lastState;
        protected Vector2 position;

        public Screen(Game1 game) {
            this.game = game;
            lastState = Keyboard.GetState();
            position.X = 0; //(game.getScreenWidth() - texture.Width) / 2;
            position.Y = 0;
        }

        public Screen() { }

        public KeyboardState getLastState() {
            return lastState;
        }

        public void setLastState(KeyboardState keyboardState) {
            lastState = keyboardState;
        }

        public Game1 getGame() {
            return game;
        }

        public Texture2D getTexture() {
            return texture;
        }

        public void setTexture(Texture2D texture) {
            this.texture = texture;
        }

    }
}
