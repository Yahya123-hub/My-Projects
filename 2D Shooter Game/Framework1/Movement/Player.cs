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

    public class Player:Imove
    {
        private int speed;
        private static int dscore;
        private Point Boundary;
        private int offset;
        private string action;
        private static List<PictureBox> upprojectiles = new List<PictureBox>();
        private static List<PictureBox> leftprojectiles = new List<PictureBox>();
        private static List<PictureBox> rightprojectiles = new List<PictureBox>();
        private PictureBox upfire, leftfire, rightfire;
        private static PictureBox gollem1, turret1, spaceship1, pb,health,pplayer,pshooter,pboss,coin;
        private static ProgressBar health1,gollem_health,turret_health,spaceship_health,shooter_health,boss_health,player_health;
        public static event EventHandler fire_added,player_added,remove;
        private static bool gollemfire, turretfire,gameover;
        private static bool gollemlife, turretlife, spaceshiplife, dronelife;
        private static Label Score;
        private Random rng;

        public static bool Gollemfire { get => gollemfire; set => gollemfire = value; }
        public static bool Turretfire { get => turretfire; set => turretfire = value; }
        public static bool Gameover { get => gameover; set => gameover = value; }
        public static bool Gollemlife { get => gollemlife; set => gollemlife = value; }
        public static bool Turretlife { get => turretlife; set => turretlife = value; }
        public static bool Spaceshiplife { get => spaceshiplife; set => spaceshiplife = value; }
        public static bool Dronelife { get => dronelife; set => dronelife = value; }

        public Player(int speed, Point Boundary,PictureBox pb1,PictureBox gollem, PictureBox turret,PictureBox spaceship,ProgressBar health, ProgressBar gollemhealth, ProgressBar turrethealth,ProgressBar spaceshiphealth,Label score)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 20;
            action = null;
            pb = pb1;
            gollem1 = gollem;
            turret1 = turret;
            spaceship1 = spaceship;
            health1 = health;
            gollem_health = gollemhealth;
            turret_health = turrethealth;
            spaceship_health = spaceshiphealth;
            Gollemfire = true;
            Turretfire = true;
            Gameover = false;
            gollemlife = true;
            turretlife = true;
            spaceshiplife = true;
            Score=score;
            dscore = 0;
            rng = new Random();
            generate_health();
        }

        public Player(int speed, Point Boundary, PictureBox player, PictureBox shooter, PictureBox boss,ProgressBar shooterhealth, ProgressBar bosshealth, ProgressBar playerhealth,Label score)
        {
            this.Boundary = Boundary;
            this.speed = speed;
            offset = 20;
            action = null;
            pb = player;
            pshooter = shooter;
            pboss = boss;
            shooter_health = shooterhealth;
            boss_health = bosshealth;
            health1 = playerhealth;
            Turretfire = true;
            dronelife = true;
            Gameover = false;
            Score = score;
            dscore = 0;
            rng = new Random();
            generate_score();
        }

        public static void detectcollisionforstage2()
        {
            foreach (PictureBox upprojectile in upprojectiles)
            {
                if (upprojectile.Bounds.IntersectsWith(pboss.Bounds))
                {
                    if (dscore <= 750)
                    {
                        dscore += 10;
                    }
                    upprojectile.Dispose();
                    if (boss_health.Value > 0)
                    {
                        boss_health.Value -= 5;
                    }

                    if (boss_health.Value <= 0)
                    {
                        pboss.Dispose();
                        boss_health.Dispose();
                        remove?.Invoke(pboss, EventArgs.Empty);
                        Gollemfire = false;
                        dronelife = false;

                    }

                }
            }

            
            if (pb.Bounds.IntersectsWith(coin.Bounds))
            {
                if (dscore <= 750)
                {
                    dscore += 10;
                }
                coin.Dispose();
                remove?.Invoke(coin, EventArgs.Empty);
            }

            if (coin.Bounds.IntersectsWith(pshooter.Bounds))
            {
                coin.Dispose();
                remove?.Invoke(coin, EventArgs.Empty);
            }

            if (pb.Bounds.IntersectsWith(pshooter.Bounds))
            {
                if (health1.Value > 0)
                {
                    pb.Image = Properties.Resources.taking_damage_v3;
                    health1.Value -= 1;
                }
            }

            foreach (PictureBox rightprojectile in rightprojectiles)
            {
                if (rightprojectile.Bounds.IntersectsWith(pshooter.Bounds))
                {
                    if (dscore <= 750)
                    {
                        dscore += 10;
                    }
                    rightprojectile.Visible = false;
                    if (shooter_health.Value > 0)
                    {
                        shooter_health.Value -= 5;
                    }

                    if (shooter_health.Value <= 0)
                    {
                        pshooter.Dispose();
                        shooter_health.Dispose();
                        remove?.Invoke(pshooter, EventArgs.Empty);
                        Turretfire = false;
                    }
                }
            }
            Score.Text = dscore.ToString();
            if(health1.Value<=0)
            {
                Gameover = true;
            }
        }





        public static void detectcollision()
        {
            foreach (PictureBox upprojectile in upprojectiles)
            {
               
                if (upprojectile.Bounds.IntersectsWith(gollem1.Bounds))
                {
                    if (dscore <= 750)
                    {
                        dscore += 10;
                    }
                    upprojectile.Dispose();
                    if (gollem_health.Value > 0)
                    {
                        gollem_health.Value -= 5;
                    }
                    if (gollem_health.Value <= 40)
                    {
                        gollem1.Image = Properties.Resources.gollemhurt__2_;
                    }
                    if (gollem_health.Value <= 0)
                    {
                        gollem1.Dispose();
                        gollem_health.Dispose();
                        remove?.Invoke(gollem1, EventArgs.Empty);
                        Gollemfire = false;
                        gollemlife = false;

                    }

                }
                if (upprojectile.Bounds.IntersectsWith(spaceship1.Bounds))
                {
                    if (dscore <= 750)
                    {
                        dscore += 10;
                    }
                    upprojectile.Visible = false;
                    if (spaceship_health.Value > 0)
                    {
                        spaceship_health.Value -= 5;
                    }
                    if (spaceship_health.Value <= 0)
                    {
                        spaceship1.Dispose();
                        spaceship_health.Dispose();
                        remove?.Invoke(spaceship1, EventArgs.Empty);
                        spaceshiplife = false;

                    }
                }
            }


            if (pb.Bounds.IntersectsWith(turret1.Bounds))
            {
                if (health1.Value > 0)
                {
                    pb.Image = Properties.Resources.taking_damage_v3;
                    health1.Value -= 1;
                }
            }

            if (pb.Bounds.IntersectsWith(health.Bounds))
            {

                if (health1.Value < 99)
                {

                    health1.Value += 1;
                }
                health.Dispose();
                remove?.Invoke(health, EventArgs.Empty);
            }
            if (health.Bounds.IntersectsWith(turret1.Bounds))
            {
                health.Dispose();
                remove?.Invoke(health, EventArgs.Empty);
            }
            


            foreach (PictureBox leftprojectile in leftprojectiles)
            {

                if (leftprojectile.Bounds.IntersectsWith(turret1.Bounds))
                {
                    if (dscore <= 750)
                    {
                        dscore += 10;
                    }
                    leftprojectile.Visible = false;
                    if (turret_health.Value > 0)
                    {
                        turret_health.Value -= 5;
                    }
                    if (turret_health.Value <= 40)
                    {
                        turret1.Image = Properties.Resources.turretdmg;
                    }
                    if (turret_health.Value <= 0)
                    {
                        turret1.Dispose();
                        turret_health.Dispose();
                        remove?.Invoke(turret1, EventArgs.Empty);
                        Turretfire = false;
                        turretlife = false;


                    }
                }
            }
            Score.Text = dscore.ToString();
            if (health1.Value <= 0)
            {
                Gameover = true;
            }

        }


        

        private void generate_health()
        {
            health = new PictureBox();
            Image img2 = Framework1.Properties.Resources.heart;
            health.Image = img2;
            health.Height = img2.Height;
            health.Width = img2.Width;
            health.BackColor = Color.Transparent;
            health.Left = rng.Next(0, Boundary.X - img2.Width);
            health.Top = pb.Top;
            fire_added?.Invoke(health,EventArgs.Empty);
        }

        private void generate_score()
        {
            coin = new PictureBox();
            Image img2 = Framework1.Properties.Resources.coin;
            coin.Image = img2;
            coin.Height = img2.Height;
            coin.Width = img2.Width;
            coin.BackColor = Color.Transparent;
            coin.Left = rng.Next(0, Boundary.X - img2.Width);
            coin.Top = pb.Top;
            fire_added?.Invoke(coin, EventArgs.Empty);
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
            location.Y += 400;
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
