using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Parkon
{
    public partial class Form_VersiyonYukle : Form
    {
        public CLS CLS;

        public Form_VersiyonYukle()
        {
            InitializeComponent();
        }

        private void Form_Starting_Load(object sender, EventArgs e)
        {
         //LB_GuncelVersiyon.Text =   CLS.AutoUpdate.VersionChek();

         //   int KVer = int.Parse(LB_KullanilanVersion.Text.Replace(".", ""));
         //   int GVer = int.Parse(LB_GuncelVersiyon.Text.Replace(".", ""));
         //   if (KVer < GVer && LB_GuncelVersiyon.Text != "ERR!")
         //   {
         //       LB_GuncelSurum.Visible = true;
         //       B_Indir.Visible = true;
         //       B_Gizle.Visible = true;
         //       CLS.Form_Main.toolStripB_YeniVerBulundu.Visible = true;
         //   }else
         //   {
         //       LB_GuncelSurum.Visible = false;
         //       B_Indir.Visible = false;
         //       B_Gizle.Visible = false;
         //       CLS.Form_Main.toolStripB_YeniVerBulundu.Visible = false;
         //   }
        }

        //int a = 0;
        //private void T_1sec_Tick(object sender, EventArgs e)
        //{

        //    a = a + 1;


        //    if (a < 2)
        //    {
        //        LB_Durum.Text = "Versiyon Kontrol Ediliyor...";
        //    }
        //    if (a >= 2)
        //    {
        //        LB_Durum.Text = "Program Hazırlanıyor...";
        //    }
        //    if (a > 2 && (LB_GuncelSurum.Visible == false))
        //    {
        //        T_1sec.Enabled = false;
        //        this.Hide();
        //    }

        //}

        //string DownloadAdd;
        //string SaveAdd;
        private void B_Indir_Click(object sender, EventArgs e)
        {

            B_Indir.Enabled = false;
            B_Gizle.Enabled = false;
            LB_GuncelSurum.Text = "indirme ve kurulum işlemi başlatılıyor...";
            CLS.AutoUpdate.indir();

        }

      


        private void B_Gizle_Click(object sender, EventArgs e)
        {
            B_Indir.Enabled = true;
            this.Hide();
        }



    }
}
