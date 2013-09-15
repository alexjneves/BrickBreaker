using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace BouncingBall {
    public class Levels {
        List<Level> levelList = new List<Level>();
        int xOffset, yOffset;
        Game1 game;

        public Levels(Game1 game) {
            this.game = game;
            this.xOffset = game.getScreenWidth() / 3;
            this.yOffset = 20;
            CreateLevels();
        }

        public Level getLevel(int levelNumber) {

            foreach (var l in levelList) {
                if (l.getLevelNum() == levelNumber)
                    return l;
            }

            throw new Exception("Can't find level " + levelNumber);
        }

        private void CreateLevels() {
            XElement levelElements = XElement.Load("Levels.xml");

            foreach (var levelElement in levelElements.Elements()) {
                processLevel(levelElement);
            }
        }

        private void processLevel(XElement levelElement) {
            var levelNumber = int.Parse(levelElement.Attribute("number").Value);

            var level = new Level(levelNumber);

            List<Brick> bricks = new List<Brick>();
            foreach (var layerElement in levelElement.Elements()) {
                var layerNumber = int.Parse(layerElement.Attribute("layerNumber").Value);
                foreach (var brickElement in layerElement.Elements()) {
                    var brickPos = int.Parse(brickElement.Attribute("position").Value);
                    bricks.Add(new NormalBrick(brickPos * Level.brickWidth+xOffset, layerNumber*Level.brickHeight+ yOffset, game));
                }
            }
            level.setBricks(bricks);

            levelList.Add(level);
        }

        public int numLevels() {
            return levelList.Count();
        }
    }
}
