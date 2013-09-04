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
    public class GameOverScreenLost : Screen {
        GamePlayScreen gamePlayScreen;

        public GameOverScreenLost(Game1 game, Texture2D texture, GamePlayScreen gamePlayScreen)
            : base(game) {
            this.setTexture(texture);
            this.gamePlayScreen = gamePlayScreen;
        }

        public void Update() {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter) && getLastState().IsKeyUp(Keys.Enter))
                this.getGame().StartGame();
            else if (keyboardState.IsKeyDown(Keys.Escape) && getLastState().IsKeyUp(Keys.Escape))
                this.getGame().Exit();

            this.setLastState(keyboardState);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.getTexture(), new Vector2(0f, 0f), Color.White);
            gamePlayScreen.getScoreHUD().DrawFinalScore(spriteBatch);
        }

    }
}
