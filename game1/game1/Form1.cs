using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        int HP = 100;
        card initcard = new card(0);
        List<card> mydeck = new List<card>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loadmydeck();
            timer1.Enabled = true;
            label1.Text = HP.ToString();
        }

        private void Loadmydeck()
        {
            Addcard(0);
            Addcard(1);
            Addcard(2);
            Addcard(3);
        }

        private void Addcard(int id)
        {
            mydeck.Add(new card(id));
            Redraw();
        }

        private void Redraw()
        {
            int X = 50;
            int Y = this.Height - initcard.Size.Height - 50;
            foreach (card mycard in mydeck)
            {
                mycard.Location = new Point(X, Y);
                X = X + mycard.Size.Width + 10;
                Controls.Add(mycard);  
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.myqueue.Count == 0)
            {
                return;
            }
            timer1.Enabled = false;
            Cmd mycmd = new Cmd();
            mycmd = Global.myqueue.Dequeue();
            switch(mycmd.maincmd)
            {
                case (int)maincmds.移動卡片:
                    if(mycmd.data < this.Height - 400)
                    {
                        foreach (card mycard in mydeck)
                        {
                            if(mycard.ID == mycmd.subcmd)
                            {
                                mydeck.Remove(mycard);
                                Controls.Remove(mycard);
                                mycmd.maincmd = (int)maincmds.打出卡片;
                                mycmd.data = 0;
                                Global.myqueue.Enqueue(mycmd);
                                break;
                            }
                        }
                    }
                    Redraw();
                    break;
                case (int)maincmds.打出卡片:
                    HP = HP - 10;
                    label1.Text = HP.ToString();
                    break;
            }
            timer1.Enabled = true;
        }
    }
}
