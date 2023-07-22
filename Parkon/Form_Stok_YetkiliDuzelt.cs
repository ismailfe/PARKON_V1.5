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
    public partial class Form_Stok_YetkiliDuzelt : Form
    {

        #region PUBLIC_VARIABLE
        public CLS CLS;
        string ID;
        bool SelectDGV_ENB;
        #endregion

        public Form_Stok_YetkiliDuzelt()
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

            Kontrol_Et();
        }

        public void Kontrol_Et()
        {
            string Baslik = "Hata";
            if (CB_MusteriFirma_Adi.Text != "")
            {
                if (TB_YetkiliAd.Text != "")
                {
                        if (TB_YetkiliUnvan.Text != "")
                        {
                            if (TB_YetkiliTel1.Text != "" || TB_YetkiliTel1.Text != "")
                            {
                                if (TB_YetkiliMail.Text != "")
                                {
                                    if (TB_YetkiliNo.Text != "")
                                    {
                                        EKle();
                                    }
                                    else { MessageBox.Show("Yetkili No getirmedi!", Baslik); }
                                } else {  MessageBox.Show("Yetkili mail adresi girilmedi!", Baslik); }
                            } else { MessageBox.Show("Yetkili telefon numarası girilmedi!", Baslik); }
                        }else { MessageBox.Show("Yetkili ünvanı girilmedi!", Baslik); }
                }else { MessageBox.Show("Yetkili adı Girilmedi!", Baslik); }
            } else {  MessageBox.Show("Müşteri firma seçilmedi!", Baslik); }

        }

        public void EKle()
        {
            DialogResult a = new DialogResult();
            string baslik = "Yeni Müşteri Ekle - Onay";
            string mesaj = "Aşağıdaki bilgilere göre yeni bir yetkili eklemeyi kabul ediyor musunuz?" + "\n" + "\n" +
                "Müşteri firma no: " + TB_MusteriFirma_No.Text + "\n" +
                "Müşteri firma adı: " + CB_MusteriFirma_Adi.Text + "\n" + "\n" +

                "Yetkili Ad Soyad: " + TB_YetkiliAd.Text + "\n" +
                "Yetkili Ünvan: " + TB_YetkiliUnvan.Text + "\n" +
                "Yetkili Tel1 : " + TB_YetkiliTel1.Text + "\n" +
                "Yetkili Tel2 : " + TB_YetkiliTel2.Text + "\n" +
                "Yetkili Mail : " + TB_YetkiliMail.Text + "\n" +
                "Yetkili Notlar: " + TB_YetkiliNot.Text + "\n" + "";

            a = MessageBox.Show(mesaj, baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (a == DialogResult.OK)
            {
                //    TB_MusteriBolum_No.Text = "01";
                //string mfirmaolustur = CLS.CreateCustomer.YeniMusteriOlustur(TB_MusteriFirma_Not.Text, TB_MusteriFirma_Adi.Text, CB_MusteriFirma_Bolge.Text, TB_MusteriFirma_Adres.Text, TB_MusteriFirma_MapsLink.Text, TB_MusteriFirma_Tel.Text);
                //string mfirmaBolumolustur = CLS.CreateDepartment.YeniMusteriBolumOlustur("", TB_MusteriFirma_No.Text, TB_MusteriFirma_Adi.Text, TB_MusteriBolum_No.Text, TB_MusteriBolum_Adi.Text);

                //string YetkiliNot       = Crypto.Encrypt(TB_YetkiliNot.Text, CLS.Str_StokCrypto);
                //string YetkiliAdSoyad   = Crypto.Encrypt(TB_YetkiliAd.Text + " " + TB_YetkiliSoyad.Text, CLS.Str_StokCrypto);
                //string YetkiliUnvan     = Crypto.Encrypt(TB_YetkiliUnvan.Text, CLS.Str_StokCrypto);
                //string YetkiliTel1      = Crypto.Encrypt(TB_YetkiliTel1.Text, CLS.Str_StokCrypto);
                //string YetkiliTel2      = Crypto.Encrypt(TB_YetkiliTel2.Text, CLS.Str_StokCrypto);
                //string YetkiliMail      = Crypto.Encrypt(TB_YetkiliMail.Text, CLS.Str_StokCrypto);

                //string YetkiliOlustur = CLS.StokCreateYetkili.YeniYetkiliOlustur(
                //    "", 
                //    TB_MusteriFirma_No.Text, 
                //    CB_MusteriFirma_Adi.Text, 
                //    YetkiliAdSoyad,
                //    YetkiliUnvan,
                //    YetkiliTel1,
                //    YetkiliTel2,
                //    YetkiliMail, YetkiliNot);

                string[] WData = new string[13];
                WData[0] = "";
                WData[1] = DateTime.Now.ToString();
                WData[2] = CLS.Form_Main.LB_UserName.Text;
                WData[3] = "";
                WData[4] = TB_MusteriFirma_No.Text;
                WData[5] = CB_MusteriFirma_Adi.Text;
                WData[6] = TB_YetkiliNo.Text;
                WData[7] = Crypto.Encrypt(TB_YetkiliAd.Text, CLS.Str_StokCrypto);
                WData[8] = Crypto.Encrypt(TB_YetkiliUnvan.Text, CLS.Str_StokCrypto);
                WData[9] = Crypto.Encrypt(TB_YetkiliTel1.Text, CLS.Str_StokCrypto);
                WData[10] = Crypto.Encrypt(TB_YetkiliTel2.Text, CLS.Str_StokCrypto);
                WData[11] = Crypto.Encrypt(TB_YetkiliMail.Text, CLS.Str_StokCrypto);
                WData[12] = Crypto.Encrypt(TB_YetkiliNot.Text, CLS.Str_StokCrypto);

                string Status = CLS.ID_MySQL.UPDATE_WithRefText_FromSQLRow(CLS.MySQLVar.TableName_DBStokMYetkili, CLS.MySQLVar.ColumnName_DBStokMYetkili, WData, "ID", ID, 0);
                MessageBox.Show("İşlem Durumu:" + Status, "DURUM");
                VeriYenile();




            }

        }


        #region MÜŞTERİ FİRMA SEÇİMİ
        private void CB_MusteriFirma_Adi_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.Stok_UrunCikis.Listele_MusteriAdi(CB_MusteriFirma_Adi);
        }

        private void CB_MusteriFirma_Adi_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_MusteriFirma_No.Text = "";
            CB_MusteriFirma_Adi.Text = "";


            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.Stok_UrunCikis.MusteriAdiSecildi(int.Parse(selectedValue), out string MusteriNo);
               
            //TB_CrtPrj_MusteriSecim_No.Text = MusteriNo;
            //TB_CrtPrj_MusteriBolge.Text = MBolge;
            //TB_CrtPrj_MusteriAdres.Text = MAdres;
            //TB_CrtPrj_MusteriMapsLink.Text = MMapslink;
            //TB_CrtPrj_MusteriTel.Text = MTel;
            //RTB_CrtPrj_MusteriNot.Text = Mnot;

            TB_MusteriFirma_No.Text = MusteriNo;
         
        }
        #endregion


        private void Form_Yeni_Musteri_Load(object sender, EventArgs e)
        {
            VeriYenile();
        }


        public void Temizle()
        {
            TB_MusteriFirma_No.Text = "";
            CB_MusteriFirma_Adi.Text = "";
            CB_MusteriFirma_Adi.Items.Clear();
        }


        void VeriYenile()
        {
            SelectDGV_ENB = false;
            string status = CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBStokMYetkili, DGV_Veri);
            SelectDGV_ENB = true;
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

        private void YetkiliNO_Sorgula(object sender, CancelEventArgs e)
        {
            //if (TB_YetkiliAd.Text != "")
            //{
            //    CLS.CreateAuthorized.YetkikiNoSorgula(TB_MusteriFirma_No.Text, out string YetkiliNo);
            //    TB_YetkiliNo.Text = YetkiliNo;
            //}
           
        }

        private void DGV_Veri_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectDGV_ENB)
            {
                foreach (DataGridViewRow row in DGV_Veri.SelectedRows)
                {
                    if (row.Cells[0].Value.ToString() != "" && row.Cells[0].Value.ToString() != null)
                    {
                        ID                          = row.Cells[0].Value.ToString();
                        TB_MusteriFirma_No.Text     = row.Cells[4].Value.ToString();
                        CB_MusteriFirma_Adi.Text    = row.Cells[5].Value.ToString();
                        TB_YetkiliNo.Text           = row.Cells[6].Value.ToString();
                        TB_YetkiliAd.Text           = Crypto.Decrypt(row.Cells[7].Value.ToString(), CLS.Str_StokCrypto);
                        TB_YetkiliUnvan.Text        = Crypto.Decrypt(row.Cells[8].Value.ToString(), CLS.Str_StokCrypto);
                        TB_YetkiliTel1.Text         = Crypto.Decrypt(row.Cells[9].Value.ToString(), CLS.Str_StokCrypto);
                        TB_YetkiliTel2.Text         = Crypto.Decrypt(row.Cells[10].Value.ToString(), CLS.Str_StokCrypto);
                        TB_YetkiliMail.Text         = Crypto.Decrypt(row.Cells[11].Value.ToString(), CLS.Str_StokCrypto);
                        TB_YetkiliNot.Text          = Crypto.Decrypt(row.Cells[12].Value.ToString(), CLS.Str_StokCrypto);
                    }

                }
            }
        }














    }
}
