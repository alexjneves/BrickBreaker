using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class HUDScore : HUD {
        private int score;

        public HUDScore(Vector2 position, SpriteFont font, int score) 
            : base(position, font) {
            this.score = score;
        }

        public HUDScore() { }

        public void incrementScore() {
            score += 10;
        }

        public int getScore() {
            return score;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(
                this.getFont(),
                "Score: " + score.ToString(),
                this.getPosition(),
                Color.White);
        }

        public void DrawFinalScore(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(
                this.getFont(),
                "Final Score: " + score.ToString(),
                this.getPosition(),
                Color.White);
        }


    }
}
