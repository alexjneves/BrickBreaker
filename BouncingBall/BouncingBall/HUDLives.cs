using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class HUDLives : HUD {
        private int lives;

        public HUDLives(Vector2 position, SpriteFont font, int lives) 
            : base(position, font) {
            this.lives = lives;
        }

        public HUDLives() { }

        public void decreaseLives() {
            lives--;
        }

        public int getLives() {
            return lives;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(
                this.getFont(),
                "Lives: " + lives.ToString(),
                this.getPosition(),
                Color.White);
        }
    }
}
