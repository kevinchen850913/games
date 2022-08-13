using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{    
    public partial class card : UserControl
    {
        public int ID;
        private int xPos;
        private int yPos;
        private bool MoveFlag;
        //在picturebox的滑鼠按下事件裡,記錄三個變數.

        public card(int id)
        {
            InitializeComponent();
            ID = id;
            label1.Text = ID.ToString();
        }

        private void card_Load(object sender, EventArgs e)
        {

        }

        private void RealPlayWnd_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MoveFlag = true;//已經按下.
            xPos = e.X;//當前x座標.
            yPos = e.Y;//當前y座標.
        }

        //在picturebox的滑鼠按下事件裡.
        private void RealPlayWnd_MouseUp(object sender, MouseEventArgs e)
        {
            Cmd cmd1 = new Cmd();
            cmd1.maincmd = (int)maincmds.移動卡片;
            cmd1.subcmd = ID;
            cmd1.data = this.Top;
            Global.myqueue.Enqueue(cmd1);
            MoveFlag = false;
        }

        //在picturebox滑鼠移動
        private void RealPlayWnd_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveFlag)
            {
                this.Left += Convert.ToInt16(e.X - xPos);//設定x座標.
                this.Top += Convert.ToInt16(e.Y - yPos);//設定y座標.
            }
        }
    }
}
