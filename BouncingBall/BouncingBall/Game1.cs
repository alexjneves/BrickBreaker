using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BouncingBall {

    enum Screens {
        StartScreen,
        GamePlayScreen,
        GameOverScreen
    }

    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState keyboardState;
        KeyboardState prevkeyboardState;

        Texture2D rectTexture;

        Song song;

        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        GameOverScreenLost gameOverScreen;
        Screens currentScreen;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 200;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 200;
        }

        protected override void Initialize() {
            base.Initialize();
            prevkeyboardState = keyboardState = Keyboard.GetState();
            rectTexture = new Texture2D(graphics.GraphicsDevice, 80, 30);
            Color[] data = new Color[80 * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rectTexture.SetData(data);
      }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            song = Content.Load<Song>("calm");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);

            startScreen = new StartScreen(this, Content.Load<Texture2D>("StartScreen"));
            currentScreen = Screens.StartScreen;

            base.LoadContent();
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) {
            if (isPaused())
                return;

            // Allows the game to exit
            if (keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

            switch (currentScreen) {
                case Screens.StartScreen:
                    if (startScreen != null)
                        startScreen.Update();
                    break;
                case Screens.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Update(gameTime);
                    break;
                case Screens.GameOverScreen:
                    if (gameOverScreen != null)
                        gameOverScreen.Update();
                    break;
            }

            //if (gamePlayScreen != null) {
            //    if (gamePlayScreen.IsEndOfLevel()) {
            //        currentLevel++;
            //        gamePlayScreen.SetUpLevel(this, levels.getLevel(currentLevel));
            //    }
            //}

            base.Update(gameTime);
        }

        private bool isPaused() {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Q))
                return true;
            else
                return false;
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (currentScreen) {
                case Screens.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screens.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Draw(spriteBatch);
                    break;
                case Screens.GameOverScreen:
                    if (gameOverScreen != null)
                        gameOverScreen.Draw(spriteBatch);
                    break;
            }

            //DrawRectangle(bat.getRectangle());
            //DrawRectangle(ball.getRectangle());
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void StartGame() {
            gamePlayScreen = new GamePlayScreen(this);
            currentScreen = Screens.GamePlayScreen;

            startScreen = null;
            gameOverScreen = null;
        }

        public void EndGame(GamePlayScreen gamePlayScreen) {
            gameOverScreen = new GameOverScreenLost(this, Content.Load<Texture2D>("GameOverScreen"), gamePlayScreen);
            currentScreen = Screens.GameOverScreen;
            
            gamePlayScreen = null;
        }

        void DrawRectangle(Rectangle rect) {
            spriteBatch.Draw(rectTexture, rect, new Color(0,0,0,50));
        }

        public GraphicsDeviceManager getGraphicsDeviceManager() {
            return graphics;
        }

        public int getScreenHeight() {
            return GraphicsDevice.Viewport.Height;
        }

        public int getScreenWidth() {
            return GraphicsDevice.Viewport.Width;
        }

    }
}
