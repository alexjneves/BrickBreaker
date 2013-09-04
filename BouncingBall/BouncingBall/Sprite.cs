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
    public class Sprite {
        private Texture2D texture;
        public Rectangle rect;
        public Game game1;

        public Sprite (int x, int y, Texture2D texture, Game game1) {
            this.texture = texture;
            rect = new Rectangle(x, y, texture.Width, texture.Height);
            this.game1 = game1;
        }

        public Sprite(int x, int y, int x2, int y2) {
            rect = new Rectangle(x, y, x2, y2);
        }

        public Sprite() { }

        public Texture2D getTexture() {
            return texture;
        }

        public Rectangle getRectangle() {
            return rect;
        }

        public void setRectangleX(int px) {
            rect.X = px;
        }

        public void setRectangleY(int py) {
            rect.Y = py;
        }

        public int viewportWidth {
            get {
                return game1.GraphicsDevice.Viewport.Width;
            }
        }

        public int viewportHeight {
            get {
                return game1.GraphicsDevice.Viewport.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
