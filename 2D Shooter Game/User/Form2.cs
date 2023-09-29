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
    public partial class Form2 : Form
    {
        Game g;
        Point boundary;
        int firelatency, firecurrentlatency;
        PictureBox boss,leftprojectile;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            shooter.Visible = false;
            shooter_prg.Visible = false;
            leftprojectile = new PictureBox();
            leftprojectile.Image = User.Properties.Resources.projectile_left_c;
            leftprojectile.Top = 650;
            leftprojectile.Left = 395;

            boss = new PictureBox();
            boss.Image = User.Properties.Resources.drone;
            boss.Top = 20;
            boss.Left = 10;
            firelatency = 25;
            firecurrentlatency = 0;
            g = new Game(10);
            g.obj_added += new EventHandler(addincontrol);
            Player.fire_added += new EventHandler(addincontrol);
            Player.player_added += new EventHandler(addincontrol);
            Diagonal.fire_added += new EventHandler(addincontrol);
            boundary = new Point(this.Width, this.Height);
            g.add(player.Image, player.Top, player.Left, new Player(6,boundary,player,shooter,boss,shooter_prg,boss_prg,player_prg,score_lbl));
            g.add(boss.Image,boss.Top,boss.Left,new Diagonal(1,boundary,"left",boss,boss_prg));
            //g.add(leftprojectile.Image, leftprojectile.Top, leftprojectile.Left, new Fireleft(7, boundary, player, leftprojectile, player_prg));

        }

        private void addincontrol(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            g.down(e.KeyCode);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            firecurrentlatency++;
            if (firecurrentlatency == firelatency)
            {
                if (Player.Turretfire)
                {
                   // g.add(User.Properties.Resources.projectile_left_c, 650, 395, new Fireleft(7, boundary, player, leftprojectile, player_prg));
                   // g.fireleft();
                    firecurrentlatency = 0;
                }
            }
            Player.moveupprojectile();
            Player.moveleftprojectile();
            Player.moverightprojectile();
            Player.detectcollisionforstage2();
           // Fireleft.moveshooterenemyprojectile();
            //Fireleft.collisionofshooterenemyprojectiles();
            g.update();
            g.fall();
            g.wave();
            
            if (Player.Gameover)
            {
                stage2timer.Enabled = false;
                this.Hide();
                gameover f1 = new gameover();
                f1.ShowDialog();
            }
            if (Player.Dronelife == false)
            {
                stage2timer.Enabled = false;
                this.Hide();
                gameover f1 = new gameover();
                f1.ShowDialog();
            }

        }
    }
}
