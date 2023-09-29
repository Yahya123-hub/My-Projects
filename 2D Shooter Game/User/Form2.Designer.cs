
namespace User
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.stage2timer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.player_prg = new System.Windows.Forms.ProgressBar();
            this.boss_prg = new System.Windows.Forms.ProgressBar();
            this.dscore_lbl = new System.Windows.Forms.Label();
            this.scoreshow_lbl = new System.Windows.Forms.Label();
            this.score_lbl = new System.Windows.Forms.Label();
            this.shooter_prg = new System.Windows.Forms.ProgressBar();
            this.shooter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shooter)).BeginInit();
            this.SuspendLayout();
            // 
            // stage2timer
            // 
            this.stage2timer.Enabled = true;
            this.stage2timer.Interval = 30;
            this.stage2timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(101, 369);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(36, 56);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 7;
            this.player.TabStop = false;
            // 
            // player_prg
            // 
            this.player_prg.Location = new System.Drawing.Point(86, 431);
            this.player_prg.Name = "player_prg";
            this.player_prg.Size = new System.Drawing.Size(72, 10);
            this.player_prg.TabIndex = 10;
            this.player_prg.Value = 100;
            // 
            // boss_prg
            // 
            this.boss_prg.Location = new System.Drawing.Point(12, 21);
            this.boss_prg.Name = "boss_prg";
            this.boss_prg.Size = new System.Drawing.Size(72, 10);
            this.boss_prg.TabIndex = 11;
            this.boss_prg.Value = 100;
            // 
            // dscore_lbl
            // 
            this.dscore_lbl.AutoSize = true;
            this.dscore_lbl.BackColor = System.Drawing.Color.Transparent;
            this.dscore_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dscore_lbl.Location = new System.Drawing.Point(676, 21);
            this.dscore_lbl.Name = "dscore_lbl";
            this.dscore_lbl.Size = new System.Drawing.Size(61, 20);
            this.dscore_lbl.TabIndex = 17;
            this.dscore_lbl.Text = "Score:";
            // 
            // scoreshow_lbl
            // 
            this.scoreshow_lbl.AutoSize = true;
            this.scoreshow_lbl.BackColor = System.Drawing.Color.Transparent;
            this.scoreshow_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreshow_lbl.Location = new System.Drawing.Point(743, 21);
            this.scoreshow_lbl.Name = "scoreshow_lbl";
            this.scoreshow_lbl.Size = new System.Drawing.Size(0, 20);
            this.scoreshow_lbl.TabIndex = 16;
            // 
            // score_lbl
            // 
            this.score_lbl.AutoSize = true;
            this.score_lbl.BackColor = System.Drawing.Color.Transparent;
            this.score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_lbl.Location = new System.Drawing.Point(734, 21);
            this.score_lbl.Name = "score_lbl";
            this.score_lbl.Size = new System.Drawing.Size(0, 20);
            this.score_lbl.TabIndex = 15;
            // 
            // shooter_prg
            // 
            this.shooter_prg.Location = new System.Drawing.Point(642, 431);
            this.shooter_prg.Name = "shooter_prg";
            this.shooter_prg.Size = new System.Drawing.Size(72, 10);
            this.shooter_prg.TabIndex = 12;
            this.shooter_prg.Value = 100;
            // 
            // shooter
            // 
            this.shooter.BackColor = System.Drawing.Color.Transparent;
            this.shooter.Image = global::User.Properties.Resources.right_shooter;
            this.shooter.Location = new System.Drawing.Point(642, 372);
            this.shooter.Name = "shooter";
            this.shooter.Size = new System.Drawing.Size(59, 53);
            this.shooter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.shooter.TabIndex = 0;
            this.shooter.TabStop = false;
            this.shooter.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dscore_lbl);
            this.Controls.Add(this.scoreshow_lbl);
            this.Controls.Add(this.score_lbl);
            this.Controls.Add(this.shooter_prg);
            this.Controls.Add(this.boss_prg);
            this.Controls.Add(this.player_prg);
            this.Controls.Add(this.player);
            this.Controls.Add(this.shooter);
            this.DoubleBuffered = true;
            this.Name = "Form2";
            this.Text = "stage 2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shooter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer stage2timer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.ProgressBar player_prg;
        private System.Windows.Forms.ProgressBar boss_prg;
        private System.Windows.Forms.Label dscore_lbl;
        private System.Windows.Forms.Label scoreshow_lbl;
        private System.Windows.Forms.Label score_lbl;
        private System.Windows.Forms.ProgressBar shooter_prg;
        private System.Windows.Forms.PictureBox shooter;
    }
}