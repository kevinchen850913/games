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
    public partial class enemy : UserControl
    {
        BasicUnit BasicUnit1 = new BasicUnit();

        public enemy()
        {
            InitializeComponent();
        }

        private void enemy_Load(object sender, EventArgs e)
        {
            BasicUnit1.hp = 100;
            label1.Text = "HP : " + BasicUnit1.hp.ToString();
        }

        public void Injuried(int n)
        {
            BasicUnit1.hp -= n;
            label1.Text = "HP : " + BasicUnit1.hp.ToString();
        }
    }
}
