using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBall {
    public class Level {
        private List<Brick> bricks;
        private int levelNumber;
        protected static int brickWidth = 150;
        protected static int brickHeight = 44;
        

        public Level(int levelNumber) {
            this.levelNumber = levelNumber;
        }

        public List<Brick> getBricks() {
            return bricks;
        }

        public int getLevelNum() {
            return levelNumber;
        }

        protected void setBricks(List<Brick> bricks) {
            this.bricks = bricks;
        }

    }
}
