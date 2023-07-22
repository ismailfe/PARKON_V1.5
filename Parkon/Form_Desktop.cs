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
    public partial class Form_Desktop : Form
    {
        public Form_Desktop()
        {
            InitializeComponent();
            this.BackColor = Color.Lime;
            TransparencyKey = Color.Lime;
        }
    }
}
