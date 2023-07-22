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
    public partial class UC_ProjeAramaGecmisi : UserControl
    {
        public CLS CLS;
        public event EventHandler XID_B_GecmistenSil_Click;


        public UC_ProjeAramaGecmisi()
        {
            InitializeComponent();
        }

        public Button XID_B_Ac_Programlar
        {
            get { return B_Ac_Programlar; }
            set { B_Ac_Programlar = value; }
        }

        public Button XID_B_Ac_Dokumanlar
        {
            get { return B_Ac_Dokumanlar; }
            set { B_Ac_Dokumanlar = value; }
        }

        public Button XID_B_Ac_FotografVideo
        {
            get { return B_Ac_FotografVideo; }
            set { B_Ac_FotografVideo = value; }
        }

        public Button XID_B_Ac_MusteriIliskileri
        {
            get { return B_Ac_MusteriIliskileri; }
            set { B_Ac_MusteriIliskileri = value; }
        }

        public TextBox XID_TB_ProjeKodu
        {
            get { return TB_ProjeKodu; }
            set { TB_ProjeKodu = value; }
        }

        public TextBox XID_TB_ProjeInfo
        {
            get { return TB_ProjeInfo; }
            set { TB_ProjeInfo = value; }
        }

        public TextBox XID_TB_ProjeIndex
        {
            get { return TB_ProjeIndex; }
            set { TB_ProjeIndex = value; }
        }

        public TextBox XID_TB_ProjePath
        {
            get { return TB_ProjePath; }
            set { TB_ProjePath = value; }
        }

        
        private void B_GecmistenSil_Click(object sender, EventArgs e )
        {
            try
            {
               CLS.ProjeSorgulamaGecmisi.IndexNoSilme = int.Parse(TB_ProjeIndex.Text);
               XID_B_GecmistenSil_Click(this, e);
            }
            catch (Exception)
            {

            }
        }


        public void OpenWindow(string Path)
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windir + @"\explorer.exe";
            prc.StartInfo.Arguments = Path;
            prc.Start();
        }
        private void B_Ac_MusteriIliskileri_Click(object sender, EventArgs e)
        {
            OpenWindow(XID_TB_ProjePath.Text + "\\" + CLS.ProjeIcerik_D1);
        }
        private void B_Ac_ElektrikProjesi_Click(object sender, EventArgs e)
        {
            OpenWindow(XID_TB_ProjePath.Text + "\\" + CLS.ProjeIcerik_D3);
        }

        private void B_Ac_Programlar_Click(object sender, EventArgs e)
        {
            OpenWindow(XID_TB_ProjePath.Text + "\\" + CLS.ProjeIcerik_D4);
        }

        private void B_Ac_Dokumanlar_Click(object sender, EventArgs e)
        {
            OpenWindow(XID_TB_ProjePath.Text + "\\" + CLS.ProjeIcerik_D5);
        }

        private void B_Ac_FotografVideo_Click(object sender, EventArgs e)
        {
            OpenWindow(XID_TB_ProjePath.Text + "\\" + CLS.ProjeIcerik_D6);
        }











    }
}
