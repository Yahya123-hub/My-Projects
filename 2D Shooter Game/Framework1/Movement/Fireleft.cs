using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework1.Movement
{
    public class Fireleft:Imove
    {
        private int speed;
        private Point Boundary;
        private int offset;
        private static PictureBox pplayer, pleftprojectile,enemyleftfire;
        private static List<PictureBox> enemyleftprojetiles = new List<PictureBox>();
        private static ProgressBar health1;
        public static event EventHandler fire_added;

        public Fireleft(int speed, Point Boundary,PictureBox player,PictureBox leftprojectile,ProgressBar playerhealth)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 50;
            pplayer = player;
            pleftprojectile = leftprojectile;
            health1 = playerhealth;
            generate_enemybullet2();
        }

        public static void collisionofshooterenemyprojectiles()
        {
            foreach (PictureBox enemyleftfire in enemyleftprojetiles)
            {
                if (enemyleftfire.Bounds.IntersectsWith(pplayer.Bounds))
                {
                    enemyleftfire.Dispose();
                   // leftprojectile.Dispose();
                    pleftprojectile.Dispose(); 
                    if (health1.Value > 0)
                    {
                        pplayer.Image = Properties.Resources.taking_damage_v3;
                        health1.Value -= 1;
                    }
                }
            }
        }


        private void generate_enemybullet2()
        {
            enemyleftfire = new PictureBox();
            Image img7 = Framework1.Properties.Resources.enemybullet_v3;
            enemyleftfire.Image = img7;
            enemyleftfire.Height = img7.Height;
            enemyleftfire.Width = img7.Width;
            enemyleftfire.BackColor = Color.Transparent;
            enemyleftfire.Left = pleftprojectile.Left;
            enemyleftfire.Top = pleftprojectile.Top;
            enemyleftprojetiles.Add(enemyleftfire);
            fire_added?.Invoke(enemyleftfire, EventArgs.Empty);
        }

        public static void moveshooterenemyprojectile()
        {
            //  if (turretfire)
            //  {


            foreach (PictureBox enemyleftfire in enemyleftprojetiles)
            {
                fire_added?.Invoke(enemyleftfire, EventArgs.Empty);
                enemyleftfire.Left -= 7;
            }

            for (int i = 0; i < enemyleftprojetiles.Count; i++)
            {
                if (enemyleftprojetiles[i].Bottom <= 0)
                {
                    enemyleftprojetiles.Remove(enemyleftprojetiles[i]);
                }
            }

            for (int i = 0; i < enemyleftprojetiles.Count; i++)
            {
                if (enemyleftprojetiles[i].Visible == false)
                {
                    enemyleftprojetiles.Remove(enemyleftprojetiles[i]);
                }
            }

            //}
        }



        public Point move(Point location)
        {
            location.X -= 7;

            return location;

        }
    }
}
