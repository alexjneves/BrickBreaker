using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBall {
    public class Bat : Sprite {
        private const int batVelocity = 15;
        private const int batLeftWidth = 11;
        private const int batCentreWidth = 173;
        private const int batRightWidth = 11;
        public bool hasMoved = false;

        Circle batLeft, batRight;
        Rectangle batCentre;

        public Bat(int x, int y, Texture2D texture, Game game1)
            : base(x, y, texture, game1) {
            int height = texture.Height;

            batLeft = new Circle(x + batLeftWidth, y + height / 2, height / 2);
            batCentre = new Rectangle(x + batLeftWidth, y, batCentreWidth, height);
            batRight = new Circle(x + batLeftWidth + batCentreWidth, y + height / 2, height / 2);
        }

        public void moveLeft() {
            if (exceedBoundariesLeft()) {
                hasMoved = false;
                return;
            }

            setRectangleX(getRectangle().MoveHorizontally(-batVelocity).X);
            batCentre.X = batCentre.MoveHorizontally(-batVelocity).X;
            batLeft.moveHorizontally(-batVelocity);
            batRight.moveHorizontally(-batVelocity);
            hasMoved = true;
        }

        public void moveRight() {
            if (exceedBoundariesRight()) {
                hasMoved = false;
                return;
            }

            setRectangleX(getRectangle().MoveHorizontally(batVelocity).X);
            batCentre.X = batCentre.MoveHorizontally(batVelocity).X;
            batLeft.moveHorizontally(batVelocity);
            batRight.moveHorizontally(batVelocity);
            hasMoved = true;
        }

        public void move(KeyboardState keyboardState) {
            if (keyboardState.IsKeyDown(Keys.Left))
                moveLeft();
            else if (keyboardState.IsKeyDown(Keys.Right))
                moveRight();
            else
                hasMoved = false;
        }



        public List<Circle> getCircles() {
            List<Circle> circles = new List<Circle>() { batLeft, batRight };

            return circles;
        }

        private bool exceedBoundariesRight() {
            if (batRight.getCentre().X + batRight.getRadius() + batVelocity > viewportWidth) {
                setRectangleX(viewportWidth - getTexture().Width);
                batCentre.X = getRectangle().X + batLeftWidth;
                batLeft.setCentreX(getRectangle().X + (int)batLeft.getRadius());
                batRight.setCentreX(viewportWidth - (int)batRight.getRadius());
                return true;
            }

            return false;
        }

        private bool exceedBoundariesLeft() {
            if (batLeft.getCentre().X - batLeft.getRadius() - batVelocity < 0) {
                setRectangleX(0);
                batCentre.X = batLeftWidth;
                batLeft.setCentreX((int)batLeft.getRadius());
                batRight.setCentreX(batLeftWidth + batCentreWidth);
                return true;
            }
            
            return false;
        }
     
    }
}
