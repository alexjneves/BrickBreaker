using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class Brick : Sprite {
        public Brick(int px, int py, Texture2D texture, Game game1)
            : base(px, py, texture, game1) { }

    }
}
