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
    public partial class Form_WhatsNew : Form
    {
        public Form_WhatsNew()
        {
            InitializeComponent();
        }

        private void Form_WhatsNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }
    }
}
