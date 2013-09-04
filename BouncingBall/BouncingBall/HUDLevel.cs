using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class HUDLevel : HUD {
        private int level;

        public HUDLevel(Vector2 position, SpriteFont font, int level)
            : base(position, font) {
            this.level = level;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(
                this.getFont(),
                "Level " + level.ToString(),
                this.getPosition(),
                Color.White);
        }
    }

}
