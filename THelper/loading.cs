using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THelper
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += .10;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            panel1.Width += 8;
            if(panel1.Width == 456)
            {
                timer2.Enabled = false;
            }
        }
    }
}
