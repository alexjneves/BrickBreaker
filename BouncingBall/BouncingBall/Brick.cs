using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class Brick {

        protected Sprite sprite;

        public Brick() {
        }

        public Brick(int px, int py, Texture2D texture, Game game1)
        {
            sprite = new Sprite(px, py, texture, game1);
        }


        public void Draw(SpriteBatch spriteBatch) {
            sprite.Draw(spriteBatch);
        }

        public Rectangle getRectangle() {
            return sprite.getRectangle();
        }

    }
}
