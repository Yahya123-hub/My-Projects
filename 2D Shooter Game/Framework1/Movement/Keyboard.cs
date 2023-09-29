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

    public class Keyboard:Imove
    {
        private int speed;
        private Point Boundary;
        private int offset;
        private string action;
        private static List<PictureBox> upprojectiles = new List<PictureBox>();
        private static List<PictureBox> leftprojectiles = new List<PictureBox>();
        private static List<PictureBox> rightprojectiles = new List<PictureBox>();
        PictureBox upfire, leftfire, rightfire,pb;
        private static ProgressBar health1;
        public static event EventHandler fire_added;
        public static event EventHandler player_added;

        public Keyboard(int speed, Point Boundary,PictureBox pb,ProgressBar health)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 20;
            action = null;
            this.pb = pb;
            health1 = health;
        }

        private void upperBullet()
        {
            upfire = new PictureBox();
            Image img6 = Framework1.Properties.Resources.projectile_up_c;
            upfire.Image = img6;
            upfire.Height = img6.Height;
            upfire.Width = img6.Width;
            upfire.BackColor = Color.Transparent;
            upfire.Left = pb.Left+42;
            upfire.Top = pb.Top-20;
            upprojectiles.Add(upfire);
            fire_added?.Invoke(upfire, EventArgs.Empty);
        }
        public static void moveupprojectile()
        {
            
            foreach (PictureBox upfire in upprojectiles)
            {
                fire_added?.Invoke(upfire, EventArgs.Empty);
                upfire.Top = upfire.Top - 15;
            }

            for (int i = 0; i < upprojectiles.Count; i++)
            {
                if (upprojectiles[i].Bottom <= 0)
                {
                    upprojectiles.Remove(upprojectiles[i]);
                }
            }
        }

        private void leftbullet()
        {
            leftfire = new PictureBox();
            Image img7 = Framework1.Properties.Resources.projectile_left_c;
            leftfire.Image = img7;
            leftfire.Height = img7.Height;
            leftfire.Width = img7.Width;
            leftfire.BackColor = Color.Transparent;
            leftfire.Left = pb.Left + (-5);
            leftfire.Top = pb.Top + 13;
            leftprojectiles.Add(leftfire);
            fire_added?.Invoke(leftfire, EventArgs.Empty);
        }


        public static void moveleftprojectile()
        {
            foreach (PictureBox leftprojectile in leftprojectiles)
            {
                fire_added?.Invoke(leftprojectile, EventArgs.Empty);
                leftprojectile.Left = leftprojectile.Left - 15;
            }

            for (int i = 0; i < leftprojectiles.Count; i++)
            {
                if (leftprojectiles[i].Right <= 0)
                {
                    leftprojectiles.Remove(leftprojectiles[i]);
                }
            }
        }

        private void rightbullet()
        {
            rightfire = new PictureBox();
            Image img8 = Framework1.Properties.Resources.projectile_right_v2_c;
            rightfire.Image = img8;
            rightfire.Height = img8.Height;
            rightfire.Width = img8.Width;
            rightfire.BackColor = Color.Transparent;
            rightfire.Left = pb.Left -(-5);
            rightfire.Top = pb.Top + 13;
            rightprojectiles.Add(rightfire);
            fire_added?.Invoke(rightfire, EventArgs.Empty);
        }

        public static void moverightprojectile()
        {
            foreach (PictureBox rightprojectile in rightprojectiles)
            {
                fire_added?.Invoke(rightprojectile, EventArgs.Empty);
                rightprojectile.Left = rightprojectile.Left + 15;
            }

            for (int i = 0; i < rightprojectiles.Count; i++)
            {
                if (rightprojectiles[i].Left <= 0)
                {
                    rightprojectiles.Remove(rightprojectiles[i]);
                }
            }

        }



        public void keypressedbyuser(Keys keycode)
        {
            if(keycode==Keys.Up)
            {
                action = "up";
            }
            else if (keycode == Keys.Down)
            {
                action = "down";
            }
            else if (keycode == Keys.Left)
            {
                action = "left";
            }
            else if (keycode == Keys.Right)
            {
                action = "right";
            }
            else if (keycode == Keys.W)
            {
                action = "fireup";

            }
            else if (keycode == Keys.A)
            {
                action = "fireleft";
            }
            else if (keycode == Keys.D)
            {
                action = "fireright";
            }
            else if (keycode == Keys.ControlKey)
            {
                action = "idle";
            }
        }


        public Point move(Point location)
        {

            if (action != null)
            {

                if (action == "left")
                {
                    if (pb.Left > 0)
                    {
                        pb.Image = Properties.Resources.right_run_v3;
                        pb.Left -= speed;
                        health1.Left = pb.Left;
                        player_added?.Invoke(upfire, EventArgs.Empty);
                    }
                }
                else if (action == "right")
                {
                    if (pb.Left + pb.Width + offset < Boundary.X)
                    {
                        pb.Image = Properties.Resources.left_run_v3;
                        pb.Left += speed;
                        health1.Left = pb.Left;
                        player_added?.Invoke(upfire, EventArgs.Empty);
                    }
                }
                else if (action == "fireup")
                {
                    pb.Image = Properties.Resources.shoot_up_v3;
                    upperBullet();

                }
                else if (action == "fireleft")
                {
                    pb.Image = Properties.Resources.right_attack_v3_c;
                    leftbullet();
                }
                else if (action == "fireright")
                {
                    pb.Image = Properties.Resources.left_attack_v3_c;
                    rightbullet();
                }
                else if (action == "idle")
                {
                    pb.Image = Properties.Resources.IDLE_F;
                    rightbullet();
                }
               action = null;
            }   
            return location;
        }

    }
}
