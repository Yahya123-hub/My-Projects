using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework1.Movement
{
    public class Vertical:Imove
    {
        private int speed;
        private Point Boundary;
        private string direction;
        private PictureBox pb;
        private int offset;
        public event EventHandler direction_changed;

        public Vertical(int speed, Point Boundary, string direction)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            this.direction = direction;
            offset = 135;

        }

        public Point move(Point location)
        {
            if(location.Y<=0)
            {
                direction = "down";
                
            }
            else if(location.Y + offset>=Boundary.Y)
            {
                direction = "up";
            }

            if(direction=="up")
            {   
                location.Y -= speed;
            }
            else if(direction=="down")
            {
                location.Y += speed;
            }

            return location;
        }
    }
}
