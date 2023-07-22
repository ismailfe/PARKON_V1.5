using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public partial class UC_DosyaBrowser : UserControl
    {
        public string BrowserYol;


        public UC_DosyaBrowser()
        {
            InitializeComponent();
        }

        public Button XID_B_Ac
        {
            get { return B_Ac; }
            set { B_Ac = value; }
        }

        public WebBrowser XID_WBrowser
        {
            get { return WebBrowser; }
            set { WebBrowser = value; }
        }

        public PictureBox XID_Picture
        {
            get { return Pic_Sembol; }
            set { Pic_Sembol = value; }
        }

        public Button XID_B_Geri
        {
            get { return B_Geri; }
            set { B_Geri = value; }
        }

        public Button XID_B_LinkCopy
        {
            get { return B_Link; }
            set { B_Link = value; }
        }

        public Label XID_LB_Baslik
        {
            get { return LB_Baslik; }
            set { LB_Baslik = value; }
        }

        public Panel PanelBackGround
        {
            get { return Panel; }
            set { Panel = value; }
        }

        private void B_Link_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BrowserYol);
        }


        private void B_Ac_Click(object sender, EventArgs e)
        {
            OpenWindow(BrowserYol);
        }

        public void OpenWindow(string Path)
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windir + @"\explorer.exe";
            prc.StartInfo.Arguments = Path;
            prc.Start();
        }
        private void B_Geri_Click(object sender, EventArgs e)
        {
            if (WebBrowser.CanGoBack)
            {
                WebBrowser.GoBack();
            }
        }

        private void LB_Baslik_TextChanged(object sender, EventArgs e)
        {
            if (LB_Baslik.Text.EndsWith("!"))
            {
                Panel.BackColor = Color.Silver;
            }
            else
            {
                Panel.BackColor = Color.Transparent;
            }
        }
    }
}
