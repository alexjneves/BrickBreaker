using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class HUD {
        private Vector2 position;
        private SpriteFont font;

        public HUD(Vector2 position, SpriteFont font) {
            this.position = position;
            this.font = font;
        }

        public HUD() { }

        public SpriteFont getFont() {
            return font;
        }

        public Vector2 getPosition() {
            return position;
        }
    }
}
