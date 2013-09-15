using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    class NormalBrick : Brick
    {
        static Texture2D texture;

        public NormalBrick(int px, int py, Game game) {
            if (texture == null)
                texture = game.Content.Load<Texture2D>("brick");

            sprite = new Sprite(px, py, texture, game);
        }
    }
}
