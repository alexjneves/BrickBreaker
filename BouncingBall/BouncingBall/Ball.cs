using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall {
    enum Region {
        TopLeft,
        TopCentre,
        TopRight,
        BottomLeft,
        BottomCentre,
        BottomRight,
        MiddleLeft,
        MiddleRight
    }

    public class Ball : Sprite {
        private Vector2 direction;
        private Vector2 position;
        private float speed;
        private float originalSpeed;
        private double radius;
        private float decay;

        public Ball(int x, int y, Texture2D texture, float px, float py, float speed, float decay, Game game1)
            : base(x, y, texture, game1) {
            direction.X = px;
            direction.Y = py;
            this.speed = speed;
            originalSpeed = speed;
            radius = texture.Height / 2;
            position.X = x;
            position.Y = y;
            this.decay = decay;
        }

        public Vector2 getVelocity() {
            return direction;
        }

        public void setVelocityX(float px) {
            direction.X = px;
        }

        public void setVelocityY(float py) {
            direction.Y = py;
        }


        private bool collisionHorizontalLine(int py, Vector2 ballCentre) {
            Vector2 rectPoint;
            rectPoint.X = ballCentre.X;
            rectPoint.Y = py;

            double distance = ballCentre.DistanceFrom(rectPoint);

            if (distance <= radius) {
                setVelocityY(-getVelocity().Y);
                return true;
            }

            return false;
        }

        private bool collisionVerticalLine(int px, Vector2 ballCentre) {
            Vector2 rectPoint;
            rectPoint.X = px;
            rectPoint.Y = ballCentre.Y;

            double distance = ballCentre.DistanceFrom(rectPoint);

            if (distance <= this.radius) {
                this.setVelocityX(-this.getVelocity().X);
                return true;
            }

            return false;
        }

        public bool checkCollision(Rectangle rect) {
            Vector2 ballCentre = getBallCentre();
            int py = rect.Y;
            int px = rect.X;

            Region ballRegion = region(ballCentre, rect);

            //if (ballRegion == Region.TopCentre) {
            //    if (direction.Y > 0) {
            //        return collisionHorizontalLine(py, ballCentre);
            //    }
            //}

            switch (ballRegion) {
                case Region.TopCentre: if (direction.Y > 0)
                        return collisionHorizontalLine(py, ballCentre);
                    break;
                case Region.BottomCentre: if (direction.Y < 0)
                        return collisionHorizontalLine(py + rect.Height, ballCentre);
                    break;
                case Region.MiddleLeft: if (direction.X > 0)
                        return collisionVerticalLine(px, ballCentre);
                     break;
                case Region.MiddleRight: if (direction.X < 0)
                        return collisionVerticalLine(px + rect.Width, ballCentre);
                     break;
                case Region.TopLeft: return checkCollision(px, py, ballCentre);
                     break;
                case Region.TopRight: return checkCollision(px + rect.Width, py, ballCentre);
                     break;
                case Region.BottomLeft: return checkCollision(px, py + rect.Height, ballCentre);
                     break;
                case Region.BottomRight: return checkCollision(px + rect.Width, py + rect.Height, ballCentre);
                     break;
            }
                
            return false;
        }

        public bool checkCollision(int px, int py, Vector2 ballCentre) {
            Vector2 rectPoint;
            rectPoint.X = px;
            rectPoint.Y = py;

            double distance = ballCentre.DistanceFrom(rectPoint);

            if (distance <= this.radius) {
                this.setVelocityX(-this.getVelocity().X);
                this.setVelocityY(-this.getVelocity().Y);
                tempSpeedChange(2.0f);
                return true;
            }

            return false;
        }

        public bool checkCollision(List<Rectangle> rectangles) {
            foreach (var rect in rectangles) {
                if (checkCollision(rect))
                    return true;
            }

            return false;
        }

        private Vector2 getBallCentre() {
            Vector2 ballCentre;
            ballCentre.X = this.getRectangle().Center.X;
            ballCentre.Y = this.getRectangle().Center.Y;

            return ballCentre;
        }

        private bool checkCollision(Circle circle) {
            Vector2 ballCentre = getBallCentre();
            Vector2 circleCentre = circle.getCentre();
            double combinedRadius = radius + circle.getRadius();
            float hypotenuse = (float)ballCentre.DistanceFrom(circleCentre);

            if (hypotenuse < combinedRadius) {
                float opposite = ballCentre.Y - circleCentre.Y;
                float adjacent = ballCentre.X - circleCentre.X;

                float sin = opposite / hypotenuse;
                float cos = adjacent / hypotenuse;

                direction.X = cos;
                direction.Y = sin;

                return true;
            }
            
            return false;
        }

        public bool checkCollision(List<Circle> circles) {
            foreach (var circle in circles) {
                if(checkCollision(circle))
                    return true;
            }

            return false;
        }

        public bool move() {
            if (speed > originalSpeed) {                        // slow to original speed
                if (speed * decay < originalSpeed) {
                    speed = originalSpeed;
                }
                else {
                    speed *= decay;
                }
            }

            position.X += (direction.X * speed);
            position.Y += (direction.Y * speed);

            setRectangleX((int)position.X);
            setRectangleY((int)position.Y);

            return exceedBoundaries();
        }

        public void tempSpeedChange(float multiplier) {
            speed *= multiplier;
        }

        private bool exceedBoundaries() {
            if (getRectangle().Y < 0 && getVelocity().Y < 0)
               setVelocityY(-getVelocity().Y);

            if (getRectangle().X < 0 && getVelocity().X < 0)
                setVelocityX(-getVelocity().X);

            if (getRectangle().X > viewportWidth - getTexture().Width && getVelocity().X > 0)
                setVelocityX(-getVelocity().X);

            if (getRectangle().Y + radius * 2 > viewportHeight) {
                setRectangleY(0);
                setRectangleX(0);
                position.X = 0;
                position.Y = 0;
                direction.X = 0.5f;
                direction.Y = 0.5f;
                speed = originalSpeed;
                return true;
            }

            return false;
        }

        private Region region(Vector2 ballCentre, Rectangle rect) {
            if (ballCentre.X < rect.X) {
                if (ballCentre.Y < rect.Y)
                    return Region.TopLeft;
                else if (ballCentre.Y > rect.Y + rect.Height)
                    return Region.BottomLeft;
                else
                    return Region.MiddleLeft;
            }

            else if (ballCentre.X > rect.X + rect.Width) {
                if (ballCentre.Y < rect.Y)
                    return Region.TopRight;
                else if (ballCentre.Y > rect.Y + rect.Height)
                    return Region.BottomRight;
                else
                    return Region.MiddleRight;
            }

            else if (ballCentre.Y < rect.Y)
                return Region.TopCentre;
            else
                return Region.BottomCentre;
        }
    }
}
