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
    public class Game
    {
        private List<Gameobject> assets;
        private int overall_gravity;
        public event EventHandler obj_added;
        public Game(int overall_gravity)
        {
            assets = new List<Gameobject>();
            this.overall_gravity = overall_gravity;

        }

        public void add(Image img,int top,int left,Imove movement)
        {
            
            Gameobject g = new Gameobject(img, top, left,movement);
            assets.Add(g);
            obj_added?.Invoke(g.Pb,EventArgs.Empty);
        }

        public void update()
        {
            foreach(Gameobject g in assets)
            {
                g.update();
            }
        }

        public void fall()
        {
            foreach (Gameobject g in assets)
            {
                g.fall();
            }

        }

        public void wave()
        {
            foreach (Gameobject g in assets)
            {
                g.wave();
            }
        }

        public void fireright()
        {
            foreach (Gameobject g in assets)
            {
                g.fireright();
            }
        }

        public void firedown()
        {
            foreach (Gameobject g in assets)
            {
                g.firedown();
            }
        }

        public void fireup()
        {
            foreach (Gameobject g in assets)
            {
                g.fireup();
            }
        }

        public void fireleft()
        {
            foreach (Gameobject g in assets)
            {
                g.fireleft ();
            }
        }

        public void down(Keys keycode)
        {
            foreach(Gameobject g in assets)
            {
                if(g.Movement.GetType()==typeof(Player))
                {
                    Player keyhandler = (Player)g.Movement;
                    keyhandler.keypressedbyuser(keycode);
                }
            }
        }





    }
}
