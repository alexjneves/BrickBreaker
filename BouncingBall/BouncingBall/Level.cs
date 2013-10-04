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
        public static int brickWidth = 107;
        public static int brickHeight = 50;
        

        public Level(int levelNumber) {
            this.levelNumber = levelNumber;
        }

        public List<Brick> getBricks() {
            return bricks;
        }

        public int getLevelNum() {
            return levelNumber;
        }

        public void setBricks(List<Brick> bricks) {
            this.bricks = bricks;
        }

    }
}
