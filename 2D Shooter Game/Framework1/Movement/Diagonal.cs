using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework1.Movement
{
    public class Diagonal:Imove
    {
        private int speed;
        private Point Boundary;
        private string direction;
        private int offset;
        private PictureBox enemydownfire, boss;
        private static PictureBox pplayer;
        private static List<PictureBox> enemydownprojetiles = new List<PictureBox>();
        public static event EventHandler fire_added;
        private static ProgressBar health1;
        public Diagonal(int speed, Point Boundary, string direction,PictureBox Boss,ProgressBar health)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            this.direction = direction;

            boss = Boss;

            health1 = health;
            offset = 130;
           
        }

        public Point move(Point location)
        {
            boss.Image = Framework1.Properties.Resources.drone;
            boss.BackColor = Color.Transparent;
            location.Y -= 100;
            fire_added?.Invoke(boss, EventArgs.Empty);
            if (boss.Left <= 0)
            {
                direction = "right";
            }
            else if ((boss.Left + boss.Width) + 10 >= Boundary.X)
            {
                direction = "left";
            }

            if (direction == "left")
            {
                boss.Left -= speed;
                boss.Top  -= speed;
                boss.Left -= speed;
                boss.Left -= speed;
                health1.Left-=speed;
                health1.Top -= speed;
                health1.Left -= speed;
                health1.Left -= speed;
                /*  location.X -= speed;
                  location.Y -= speed;
                  location.X -= speed;
                  location.X -= speed;*/
            }
            else if (direction == "right")
            {
                boss.Left += speed;
                boss.Top  += speed;
                boss.Left += speed;
                boss.Left += speed;
                health1.Left += speed;
                health1.Top  += speed;
                health1.Left += speed;
                health1.Left += speed;

            }
            return location;

        }

     
      




    }
}
