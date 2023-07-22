using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Parkon
{
    public partial class Form_Yeni_Revizyon : Form
    {

        #region PUBLIC_VARIABLE
        public CLS CLS;
        #endregion



        public Form_Yeni_Revizyon()
        {
            InitializeComponent();
        }





        private void B_Iptal_Click(object sender, EventArgs e)
        {
            Temizle();
            this.Hide();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            OLUSTUR();
        }

        public void OLUSTUR()
        {
                string[] ProjeVerileri = new string[26];

                ProjeVerileri[0] = "";
                ProjeVerileri[1] = DateTime.Now.ToString();
                ProjeVerileri[2] = CLS.Form_Main.LB_UserName.Text;
                ProjeVerileri[3] = TB_ProjeNot.Text;
                ProjeVerileri[4] = TB_MusteriFirma_No.Text;
                ProjeVerileri[5] = TB_MusteriFirma_Adi.Text;
                ProjeVerileri[6] = TB_BolumNo.Text;
                ProjeVerileri[7] = TB_BolumAdi.Text;
                ProjeVerileri[8] = TB_ProjeNo.Text;
                ProjeVerileri[9] = TB_ProjeKodu.Text;
                ProjeVerileri[10] = TB_ProjeAdi.Text;
                ProjeVerileri[11] = TB_ProjeBaslangicTarih.Text;
                ProjeVerileri[12] = TB_ProjeDonem.Text.Remove(2, 3);
                ProjeVerileri[13] = TB_ProjeDonem.Text.Remove(0, 3);
                ProjeVerileri[14] = TB_YetkiliNo.Text; 
                ProjeVerileri[15] = Crypto.Encrypt(TB_YetkiliAdi.Text, "xxx");
                ProjeVerileri[16] = Crypto.Encrypt(TB_YetkiliUnvan.Text, "xxx");
                ProjeVerileri[17] = Crypto.Encrypt(TB_YetkiliTel1.Text, "xxx");
                ProjeVerileri[18] = Crypto.Encrypt(TB_YetkiliTel2.Text, "xxx");
                ProjeVerileri[19] = Crypto.Encrypt(TB_YetkiliMail.Text, "xxx");
                ProjeVerileri[20] = Crypto.Encrypt("", "xxx");
                ProjeVerileri[21] = TB_RevBaslangicTarih.Text;
                ProjeVerileri[22] = TB_RevDonem.Text.Remove(2, 3);
                ProjeVerileri[23] = TB_RevDonem.Text.Remove(0, 3);
                ProjeVerileri[24] = TB_RevNo.Text;
                ProjeVerileri[25] = TB_RevAdi.Text;


            string KlasorOlustur = CLS.CreateFolder.Create_YeniRevizyon(TB_MusteriFirma_No.Text, TB_MusteriFirma_Adi.Text, TB_ProjeKodu.Text, TB_RevNo.Text, out string status);
            string Olustur = "";
            if (KlasorOlustur == "OK!")
            {
                Olustur = CLS.CreateProject.Revizyon_Olustur(ProjeVerileri);
            }
      

            

                string baslik2 = "İşlem tamamlandı";
                string mesaj2 = "Yeni revizyon oluşturma işlemi " + Olustur + "\n " +
                "Yeni revizyon klasörü oluşturma işlemi " + KlasorOlustur;
         
                DialogResult islemOnay = new DialogResult();
                islemOnay = MessageBox.Show(mesaj2, baslik2, MessageBoxButtons.OK);

                if (islemOnay == DialogResult.OK)
                {
                    Temizle();
                    this.Hide();
                }
        }


        private void Form_Yeni_Musteri_Load(object sender, EventArgs e)
        {
            
        }


        public void Temizle()
        {
        }







        private void BUYUK_HARF_YAZ(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void BUYUK_HARF_YAZ_ENG(object sender, EventArgs e)
        {

            ((TextBox)sender).Text = CLS.TextCheck.StringENG(((TextBox)sender).Text).ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void SADECE_RAKAM_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void SADECE_HARF_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                        && !char.IsSeparator(e.KeyChar);
        }

        private void Form_Yeni_Proje_Shown(object sender, EventArgs e)
        {
            TB_MusteriFirma_No.Text     = CLS.Form_Main.CrtPrj_SecilenMusteriNo;
            TB_MusteriFirma_Adi.Text    = CLS.Form_Main.CrtPrj_SecilenMusteriAdi;
            TB_BolumNo.Text             = CLS.Form_Main.CrtPrj_SecilenBolumNo;
            TB_BolumAdi.Text            = CLS.Form_Main.CrtPrj_SecilenBolumAdi;

            TB_ProjeNo.Text = CLS.Form_Main.TB_CrtPrj_ProjeNo.Text;
            TB_ProjeKodu.Text = CLS.Form_Main.TB_CrtPrj_ProjeKodu.Text;
            TB_ProjeAdi.Text = CLS.Form_Main.TB_CrtPrj_ProjeAdi.Text;
            TB_ProjeKodu.Text = CLS.Form_Main.TB_CrtPrj_ProjeKodu.Text;
            TB_ProjeBaslangicTarih.Text = CLS.Form_Main.DTP_CrtPrj_ProjeBaslangic.Text;
            TB_ProjeDonem.Text = CLS.Form_Main.DTP_CrtPrj_ProjeDonem.Text;
            TB_ProjeNot.Text = CLS.Form_Main.RTB_CrtPrj_ProjeNot.Text;
            TB_YetkiliNo.Text = CLS.Form_Main.TB_CrtPrj_YetkiliNo.Text;
            TB_YetkiliUnvan.Text = CLS.Form_Main.TB_CrtPrj_YetkiliUnvan.Text;
            TB_YetkiliAdi.Text = CLS.Form_Main.CB_CrtPrj_YetkiliSecim.Text;
            TB_YetkiliTel1.Text = CLS.Form_Main.TB_CrtPrj_YetkiliTel1.Text;
            TB_YetkiliTel2.Text = CLS.Form_Main.TB_CrtPrj_YetkiliTel2.Text;
            TB_YetkiliMail.Text = CLS.Form_Main.TB_CrtPrj_YetkiliMail.Text;
            TB_YetkiliNot.Text = CLS.Form_Main.RTB_CrtPrj_YetkiliNot.Text;

            TB_RevAdi.Text = CLS.Form_Main.TB_CrtPrj_RevAdi.Text;
            TB_RevBaslangicTarih.Text = CLS.Form_Main.DTP_CrtPrj_RevBaslangic.Text;
            TB_RevDonem.Text = CLS.Form_Main.DTP_CrtPrj_RevDonem.Text;
            TB_RevNo.Text = CLS.Form_Main.TB_CrtPrj_RevNo.Text;
        }




    }
}
