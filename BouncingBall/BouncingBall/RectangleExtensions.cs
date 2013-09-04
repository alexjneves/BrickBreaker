using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BouncingBall {
    public static class RectangleExtensions {
        public static Rectangle MoveHorizontally(this Rectangle rect, int d) {
            rect.X += d;
            return rect;
        }

    }
}
