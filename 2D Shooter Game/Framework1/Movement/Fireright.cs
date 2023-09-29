using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Framework1.Core;


namespace Framework1.Movement
{
    public class Fireright : Imove
    {
        private int speed;
        private Point Boundary;
        private int offset;
        private static PictureBox pplayer,prightprojectile,enemyrightfire;
        private static List<PictureBox> enemyrightprojetiles = new List<PictureBox>();
        private static ProgressBar health1;
        public static event EventHandler fire_added;

        public Fireright(int speed, Point Boundary,PictureBox player,PictureBox rightprojectile,ProgressBar health)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            pplayer = player;
            prightprojectile = rightprojectile;
            health1 = health;
            offset = 50;
            generate_enemybullet2();
        }

        public static void collisionofenemyprojectiles()
        {
            foreach (PictureBox rightprojectile in enemyrightprojetiles)
            {
                if (rightprojectile.Bounds.IntersectsWith(pplayer.Bounds))
                {
                    enemyrightfire.Visible = false;
                    rightprojectile.Visible = false;
                    prightprojectile.Visible = false;
                    if (health1.Value > 0)
                    {
                        pplayer.Image = Properties.Resources.taking_damage_v3;
                        health1.Value -= 5;
                    }
                }
            }
        }

        private void generate_enemybullet2()
        {
            enemyrightfire = new PictureBox();
            Image img7 = Framework1.Properties.Resources.enemybullet_v3;
            enemyrightfire.Image = img7;
            enemyrightfire.Height = img7.Height;
            enemyrightfire.Width = img7.Width;
            enemyrightfire.BackColor = Color.Transparent;
            enemyrightfire.Left = prightprojectile.Left;
            enemyrightfire.Top = prightprojectile.Top;
            enemyrightprojetiles.Add(enemyrightfire);
            fire_added?.Invoke(enemyrightfire, EventArgs.Empty);
        }


        public static void moveturretenemyprojectile()
        {
          //  if (turretfire)
          //  {

                
                foreach (PictureBox enemyrightfire in enemyrightprojetiles)
                {
                fire_added?.Invoke(enemyrightfire, EventArgs.Empty);
                enemyrightfire.Left += 7;
                }

                for (int i = 0; i < enemyrightprojetiles.Count; i++)
                {
                    if (enemyrightprojetiles[i].Bottom <= 0)
                    {
                        enemyrightprojetiles.Remove(enemyrightprojetiles[i]);
                    }
                }

                for (int i = 0; i < enemyrightprojetiles.Count; i++)
                {
                    if ( enemyrightprojetiles[i].Visible == false)
                    {
                        enemyrightprojetiles.Remove(enemyrightprojetiles[i]);
                    }
                }

            //}
        }



        public Point move(Point location)
        {
            enemyrightfire.Location = location;
            location.X += 7;

            return location;

        }

        



    }
}
