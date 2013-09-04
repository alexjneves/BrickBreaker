using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    class GameOverScreenWon : Screen {
        GamePlayScreen gamePlayScreen;

        public GameOverScreenWon(Game1 game, Texture2D texture, GamePlayScreen gamePlayScreen)
            : base(game) {
            this.setTexture(texture);
            this.gamePlayScreen = gamePlayScreen;
        }

    }
}
