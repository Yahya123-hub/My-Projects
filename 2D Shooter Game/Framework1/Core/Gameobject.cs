using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework1.Movement;

namespace Framework1.Core
{
    public class Gameobject
    {
        private PictureBox pb;
        private Imove movement;
        public Gameobject(Image img,int left,int top, Imove movement)
        {
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.Height = img.Height;
            Pb.Width = img.Width;
            Pb.BackColor = Color.Transparent;
            Pb.Top = top;
            Pb.Left = left;
            this.Movement = movement;
            
        }

        public PictureBox Pb { get => pb; set => pb = value; }
        public Imove Movement { get => movement; set => movement = value; }

        public void update()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public Point givelocation()
        {
            return Pb.Location;
        }

        public void fall()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public void wave()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public void fireright()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public void firedown()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public void fireup()
        {
            Pb.Location = Movement.move(Pb.Location);
        }

        public void fireleft()
        {
            Pb.Location = Movement.move(Pb.Location);
        }
    }

}
