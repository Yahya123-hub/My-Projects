
namespace User
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.stage1timer = new System.Windows.Forms.Timer(this.components);
            this.gollem = new System.Windows.Forms.PictureBox();
            this.turret = new System.Windows.Forms.PictureBox();
            this.gollem_prgbar = new System.Windows.Forms.ProgressBar();
            this.turret_prgbar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.spaceship_pb = new System.Windows.Forms.PictureBox();
            this.player_prg = new System.Windows.Forms.ProgressBar();
            this.spaceship_prg = new System.Windows.Forms.ProgressBar();
            this.score_lbl = new System.Windows.Forms.Label();
            this.scoreshow_lbl = new System.Windows.Forms.Label();
            this.dscore_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gollem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceship_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // stage1timer
            // 
            this.stage1timer.Enabled = true;
            this.stage1timer.Interval = 30;
            this.stage1timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gollem
            // 
            this.gollem.BackColor = System.Drawing.Color.Transparent;
            this.gollem.Image = ((System.Drawing.Image)(resources.GetObject("gollem.Image")));
            this.gollem.Location = new System.Drawing.Point(405, 142);
            this.gollem.Name = "gollem";
            this.gollem.Size = new System.Drawing.Size(72, 67);
            this.gollem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gollem.TabIndex = 1;
            this.gollem.TabStop = false;
            this.gollem.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // turret
            // 
            this.turret.BackColor = System.Drawing.Color.Transparent;
            this.turret.Image = ((System.Drawing.Image)(resources.GetObject("turret.Image")));
            this.turret.Location = new System.Drawing.Point(38, 372);
            this.turret.Name = "turret";
            this.turret.Size = new System.Drawing.Size(78, 57);
            this.turret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.turret.TabIndex = 2;
            this.turret.TabStop = false;
            // 
            // gollem_prgbar
            // 
            this.gollem_prgbar.Location = new System.Drawing.Point(405, 142);
            this.gollem_prgbar.Name = "gollem_prgbar";
            this.gollem_prgbar.Size = new System.Drawing.Size(72, 10);
            this.gollem_prgbar.TabIndex = 3;
            this.gollem_prgbar.Value = 100;
            // 
            // turret_prgbar
            // 
            this.turret_prgbar.Location = new System.Drawing.Point(44, 356);
            this.turret_prgbar.Name = "turret_prgbar";
            this.turret_prgbar.Size = new System.Drawing.Size(72, 10);
            this.turret_prgbar.TabIndex = 4;
            this.turret_prgbar.Value = 100;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(633, 373);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(36, 56);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // spaceship_pb
            // 
            this.spaceship_pb.BackColor = System.Drawing.Color.Transparent;
            this.spaceship_pb.Image = global::User.Properties.Resources.Ship6;
            this.spaceship_pb.Location = new System.Drawing.Point(-2, -2);
            this.spaceship_pb.Name = "spaceship_pb";
            this.spaceship_pb.Size = new System.Drawing.Size(128, 128);
            this.spaceship_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.spaceship_pb.TabIndex = 7;
            this.spaceship_pb.TabStop = false;
            // 
            // player_prg
            // 
            this.player_prg.Location = new System.Drawing.Point(618, 435);
            this.player_prg.Name = "player_prg";
            this.player_prg.Size = new System.Drawing.Size(72, 10);
            this.player_prg.TabIndex = 9;
            this.player_prg.Value = 100;
            // 
            // spaceship_prg
            // 
            this.spaceship_prg.Location = new System.Drawing.Point(27, 12);
            this.spaceship_prg.Name = "spaceship_prg";
            this.spaceship_prg.Size = new System.Drawing.Size(72, 10);
            this.spaceship_prg.TabIndex = 10;
            this.spaceship_prg.Value = 100;
            // 
            // score_lbl
            // 
            this.score_lbl.AutoSize = true;
            this.score_lbl.BackColor = System.Drawing.Color.Transparent;
            this.score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_lbl.Location = new System.Drawing.Point(712, 189);
            this.score_lbl.Name = "score_lbl";
            this.score_lbl.Size = new System.Drawing.Size(0, 20);
            this.score_lbl.TabIndex = 12;
            this.score_lbl.Click += new System.EventHandler(this.score_lbl_Click);
            // 
            // scoreshow_lbl
            // 
            this.scoreshow_lbl.AutoSize = true;
            this.scoreshow_lbl.BackColor = System.Drawing.Color.Transparent;
            this.scoreshow_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreshow_lbl.Location = new System.Drawing.Point(721, 189);
            this.scoreshow_lbl.Name = "scoreshow_lbl";
            this.scoreshow_lbl.Size = new System.Drawing.Size(0, 20);
            this.scoreshow_lbl.TabIndex = 13;
            // 
            // dscore_lbl
            // 
            this.dscore_lbl.AutoSize = true;
            this.dscore_lbl.BackColor = System.Drawing.Color.Transparent;
            this.dscore_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dscore_lbl.Location = new System.Drawing.Point(654, 189);
            this.dscore_lbl.Name = "dscore_lbl";
            this.dscore_lbl.Size = new System.Drawing.Size(61, 20);
            this.dscore_lbl.TabIndex = 14;
            this.dscore_lbl.Text = "Score:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dscore_lbl);
            this.Controls.Add(this.scoreshow_lbl);
            this.Controls.Add(this.score_lbl);
            this.Controls.Add(this.spaceship_prg);
            this.Controls.Add(this.player_prg);
            this.Controls.Add(this.spaceship_pb);
            this.Controls.Add(this.player);
            this.Controls.Add(this.turret_prgbar);
            this.Controls.Add(this.gollem_prgbar);
            this.Controls.Add(this.turret);
            this.Controls.Add(this.gollem);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Stage 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gollem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceship_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer stage1timer;
        private System.Windows.Forms.PictureBox gollem;
        private System.Windows.Forms.PictureBox turret;
        private System.Windows.Forms.ProgressBar gollem_prgbar;
        private System.Windows.Forms.ProgressBar turret_prgbar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox spaceship_pb;
        private System.Windows.Forms.ProgressBar player_prg;
        private System.Windows.Forms.ProgressBar spaceship_prg;
        private System.Windows.Forms.Label score_lbl;
        private System.Windows.Forms.Label scoreshow_lbl;
        private System.Windows.Forms.Label dscore_lbl;
    }
}

