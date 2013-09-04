﻿using System;
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
    public class GamePlayScreen : Screen {
        Ball ball, ball2;
        Bat bat;
        List<Brick> bricks;
        HUDLives livesHUD;
        HUDScore scoreHUD;
        HUDLevel levelHUD;
        KeyboardState keyboardState;
        SoundEffect pop;
        int levelNum;

        public GamePlayScreen(Game1 game, int level, List<Brick> bricks)
            : base(game) {
            levelNum = level;
            this.bricks = bricks;

            ball = new Ball(0, 0, game.Content.Load<Texture2D>("ball"), 0.7f, 0.5f, 7.0f, 0.99f, this.getGame());
            ball2 = new Ball(400, 0, game.Content.Load<Texture2D>("ball"), 0.7f, 0.5f, 7.0f, 0.99f, this.getGame());
            bat = new Bat(game.getScreenWidth() / 2 - game.Content.Load<Texture2D>("bat").Width / 2, game.getScreenHeight() - 50, game.Content.Load<Texture2D>("bat"), this.getGame());

            scoreHUD = new HUDScore(new Vector2(10, 10), game.Content.Load<SpriteFont>("Arial"), 0);
            livesHUD = new HUDLives(new Vector2(10, 30), game.Content.Load<SpriteFont>("Arial"), 3);
            levelHUD = new HUDLevel(new Vector2(10, 50), game.Content.Load<SpriteFont>("Arial"), level);

            pop = game.Content.Load<SoundEffect>("pop");
        }

        public GamePlayScreen() { }

        public void Update(GameTime gameTime) {
            keyboardState = Keyboard.GetState();

            // Ball Movement & Position Detection
            if (ball.move()) {
                livesHUD.decreaseLives();
                if (livesHUD.getLives() <= 0)
                    this.getGame().EndGame(this);
            }

            // Bat Movement
            bat.move(keyboardState);

            // Collision Detection With Bat
            if (ball.checkCollision(bat.getRectangle())) {
                if (bat.hasMoved)
                    ball.tempSpeedChange(2.0f);
                collisionBat();
            } else if(ball.checkCollision(bat.getCircles())) {
                if (bat.hasMoved)
                    ball.tempSpeedChange(2.0f);
                collisionBat();
            }

            // Collision Detection With Bricks
            List<Brick> toRemove = new List<Brick>();

            foreach (var brick in bricks) {
                if (ball.checkCollision(brick.getRectangle())) {
                    toRemove.Add(brick);
                    collisionSound();
                }
            }

            removeBricks(toRemove);
        }

        private void removeBricks(List<Brick> toRemove) {
            foreach (var brickToRemove in toRemove) {
                bricks.Remove(brickToRemove);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            ball.Draw(spriteBatch);
            bat.Draw(spriteBatch);
            scoreHUD.Draw(spriteBatch);
            livesHUD.Draw(spriteBatch);
            levelHUD.Draw(spriteBatch);

            foreach (var brick in bricks) {
                brick.Draw(spriteBatch);
            }
        }

        public HUDScore getScoreHUD() {
            return scoreHUD;
        }

        private void collisionBat() {
            pop.Play();
            scoreHUD.incrementScore();
        }

        private void collisionSound() {
            pop.Play();
        }
    }
}
