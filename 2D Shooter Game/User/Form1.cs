using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework1.Core;
using Framework1.Movement;


namespace User
{
    
    public partial class Form1 : Form
    {
        Game g;
        Point boundary;
        int firelatency,firecurrentlatency,downfirelatency,downfirecurrentlatency;
        PictureBox rightprojectile,downprojectile;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rightprojectile = new PictureBox();
            rightprojectile.Image = User.Properties.Resources.enemybullet_v3;
            rightprojectile.Top = 40;
            rightprojectile.Left = 395;

            downprojectile = new PictureBox();
            downprojectile.Image = User.Properties.Resources.gollemprojectile;
            downprojectile.Top = 435;
            downprojectile.Left = 150;

            firelatency = 25;
            firecurrentlatency =0;
            downfirelatency = 25;
            downfirecurrentlatency = 0;

            g = new Game(10);
            g.obj_added += new EventHandler(addincontrol);
            Player.fire_added += new EventHandler(addincontrol);
            Player.player_added += new EventHandler(addincontrol);
            Player.remove += new EventHandler(removefromcontrol);
            Horizontal.obj_added += new EventHandler(addincontrol);
            Fireright.fire_added += new EventHandler(addincontrol);
            Firedown.fire_added += new EventHandler(addincontrol);
            boundary = new Point(this.Width, this.Height);
            g.add(spaceship_pb.Image,spaceship_pb.Top,spaceship_pb.Left,new Horizontal(2,boundary,"right",spaceship_pb,spaceship_prg));
            g.add(player.Image,player.Top,player.Left,new Player(6,boundary,player,gollem,turret,spaceship_pb,player_prg,gollem_prgbar,turret_prgbar,spaceship_prg,score_lbl));
            g.add(rightprojectile.Image,rightprojectile.Top,rightprojectile.Left, new Fireright(7,boundary,player,rightprojectile, player_prg));
            g.add(downprojectile.Image, downprojectile.Top, downprojectile.Left,new Firedown(7, boundary, player, downprojectile, player_prg));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { 
        }

        private void addincontrol(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }
        private void removefromcontrol(object sender, EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void score_lbl_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
            firecurrentlatency++;
            downfirecurrentlatency++;
            Player.moveupprojectile();
            Player.moveleftprojectile();
            Player.moverightprojectile();
            Player.detectcollision();
            Fireright.moveturretenemyprojectile();
            Fireright.collisionofenemyprojectiles();
            Firedown.movegollemenemyprojectile();
            Firedown.collisionofenemyprojectiles();
            g.update();
            g.fall();
            g.wave();
            if (firecurrentlatency == firelatency)
            {
                if (Player.Turretfire)
                {
                    g.add(rightprojectile.Image, rightprojectile.Top, rightprojectile.Left, new Fireright(7, boundary, player, rightprojectile, player_prg));
                    g.fireright();
                    firecurrentlatency = 0;
                }
            }
            if (downfirecurrentlatency == downfirelatency)
            {
                if (Player.Gollemfire)
                {
                    g.add(downprojectile.Image, downprojectile.Top, downprojectile.Left, new Firedown(7, boundary, player, downprojectile, player_prg));
                    g.firedown();
                    downfirecurrentlatency = 0;
                }
            }
            if(Player.Gameover)
            {
                stage1timer.Enabled = false;
                this.Hide();
                gameover f1 = new gameover();
                f1.ShowDialog();
            }
            if (Player.Gollemlife == false && Player.Turretlife == false && Player.Spaceshiplife == false)
            {
                stage1timer.Enabled = false;
                this.Hide();
                Form2 f1 = new Form2();
                f1.ShowDialog();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g.down(e.KeyCode);
            
        }
    }
}
