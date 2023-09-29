using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework1.Movement
{
    public class Firedown : Imove
    {
        private int speed;
        private Point Boundary;
        private int offset;
        private static PictureBox pplayer, pdownprojectile, enemydownfire;
        private static List<PictureBox> enemydownprojetiles = new List<PictureBox>();
        private static ProgressBar health1;
        public static event EventHandler fire_added;

        public Firedown(int speed, Point Boundary, PictureBox player, PictureBox downprojectile, ProgressBar health)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 50;
            pplayer = player;
            pdownprojectile = downprojectile;
            health1 = health;
            generate_enemybullet2();
        }

        public Point move(Point location)
        {
            enemydownfire.Location = location;
            location.Y += 7;

            return location;

        }


        public static void collisionofenemyprojectiles()
        {
            foreach (PictureBox enemydownfire in enemydownprojetiles)
            {
                if (enemydownfire.Bounds.IntersectsWith(pplayer.Bounds))
                {
                    enemydownfire.Visible = false;
                    pdownprojectile.Visible = false;
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
            enemydownfire = new PictureBox();
            Image img7 = Framework1.Properties.Resources.gollemprojectile;
            enemydownfire.Image = img7;
            enemydownfire.Height = img7.Height;
            enemydownfire.Width = img7.Width;
            enemydownfire.BackColor = Color.Transparent;
            enemydownfire.Left = pdownprojectile.Left;
            enemydownfire.Top = pdownprojectile.Top;
            enemydownprojetiles.Add(enemydownfire);
            fire_added?.Invoke(enemydownfire, EventArgs.Empty);
        }

        public static void movegollemenemyprojectile()
        {
            //  if (turretfire)
            //  {


            foreach (PictureBox enemydownfire in enemydownprojetiles)
            {
                fire_added?.Invoke(enemydownfire, EventArgs.Empty);
                enemydownfire.Top += 7;
            }

            for (int i = 0; i < enemydownprojetiles.Count; i++)
            {
                if (enemydownprojetiles[i].Bottom <= 0)
                {
                    enemydownprojetiles.Remove(enemydownprojetiles[i]);
                }
            }

            for (int i = 0; i < enemydownprojetiles.Count; i++)
            {
                if (enemydownprojetiles[i].Visible == false)
                {
                    enemydownprojetiles.Remove(enemydownprojetiles[i]);
                }
            }

            //}
        }





    }
}
