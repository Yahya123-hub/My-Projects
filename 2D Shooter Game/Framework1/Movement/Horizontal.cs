using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework1.Movement
{
    public class Horizontal:Imove
    {
        private int speed;
        private Point Boundary;
        private string direction;
        private PictureBox pb;
        private int offset;
        private static ProgressBar spaceship_health;
        public static event EventHandler obj_added;
        private Random rng;
        public Horizontal(int speed,Point Boundary,string direction,PictureBox pb,ProgressBar spaceshiphealth)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            this.direction = direction;
            this.pb = pb;
            spaceship_health=spaceshiphealth;
            offset =140;   
        }      

        public Point move(Point location)
        {
            // pb.Location = location;
            location.Y -= 100;
            if (direction == "left")
            {
                pb.Left -= speed;
                spaceship_health.Left -= speed; 
            }
            else if (direction == "right")
            {
                pb.Left += speed;
                spaceship_health.Left += speed;
            }
            if (pb.Left  <=0)
            {
                pb.Image = Properties.Resources.Ship6;
                direction = "right";
            }
            else if((pb.Left+ pb.Width) + 10 >= Boundary.X)
            {
                pb.Image = Properties.Resources.Ship6inverted;
                direction = "left";
            }
            return location;
        }

        
    }
}
