using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public partial class Form_Starting : Form
    {
        public Form_Starting()
        {
            InitializeComponent();
        }

        private void Form_Starting_Load(object sender, EventArgs e)
        {


          
        }

        private void Form_Starting_Leave(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }

        private void Form_Starting_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Opacity = this.Opacity + 0.015;

            if (this.Opacity >= 100)
            {
                timer1.Enabled = false;
            }
        }

        private void RTB_AppStart_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            RTB_AppStart.SelectionStart = RTB_AppStart.Text.Length;
            // scroll it automatically
            RTB_AppStart.ScrollToCaret();
        }


    }
}
