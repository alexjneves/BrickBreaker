using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    public class Circle {
        private double radius;
        private Vector2 centre;

        public Circle(int centreX, int centreY, double radius) {
                this.radius = radius;
                centre.X = centreX;
                centre.Y = centreY;
        }

        public double getRadius() {
            return radius;
        }

        public Vector2 getCentre() {
            return centre;
        }

        public void setCentreX(int px) {
            centre.X = px;
        }

        public void setCentreY(int py) {
            centre.Y = py;
        }

        public void moveHorizontally(int x) {
            this.centre.X += x;
        }

        /*public Vector2 getCircleCentre() {
            Vector2 circleCentre;
            circleCentre.X = this.getRectangle().X + (int)this.getRadius();
            circleCentre.Y = this.getRectangle().Y + (int)this.getRadius();

            return circleCentre;
        }*/

        

    }
}
