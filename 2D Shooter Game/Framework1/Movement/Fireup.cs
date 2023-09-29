using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Framework1.Movement
{
    public class Fireup:Imove
    {
        private int speed;
        private Point Boundary;
        private int offset;

        public Fireup(int speed, Point Boundary)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 50;
        }

        public Point move(Point location)
        {
            location.Y -= speed;
            return location;
        }
    }
}
