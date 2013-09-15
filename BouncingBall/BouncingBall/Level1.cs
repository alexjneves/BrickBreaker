using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBall {
    public class Level1 : Level {
        private static int level = 1;

        public Level1(Game1 game) : base(level) { 
            List<Brick> bricks = new List<Brick>();

            Point layer1, layer2, layer3;

            int topLeft = game.getScreenWidth() / 3;

            layer1 = new Point(topLeft, 20);
            layer2 = new Point(topLeft + 75, layer1.Y + brickHeight);
            layer3 = new Point(topLeft + 150, layer2.Y + brickHeight);

            // layer 1
            bricks.Add(new NormalBrick(layer1.X, layer1.Y,  game));
            bricks.Add(new NormalBrick(layer1.X + brickWidth, layer1.Y,  game));
            bricks.Add(new NormalBrick(layer1.X + brickWidth * 2, layer1.Y, game));

            // layer 2
            bricks.Add(new NormalBrick(layer2.X, layer2.Y, game));
            bricks.Add(new NormalBrick(layer2.X + brickWidth, layer2.Y, game));

            // layer 3
            bricks.Add(new NormalBrick(layer3.X, layer3.Y, game));

            setBricks(bricks);
        }
    
    }
}
