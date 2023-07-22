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
    public partial class Form_Stok_UrunYeni : Form
    {
        public CLS CLS;

        public Form_Stok_UrunYeni()
        {
            InitializeComponent();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }

        private void B_Iptal_Click(object sender, EventArgs e)
        {
            Temizle();
           // this.Hide();
        }

        private void CB_Marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();
 
            CLS.StokCreateUrun.MarkaAdiSecildi(int.Parse(selectedValue), out string MarkaNo);

            TB_MarkaNo.Text = MarkaNo;
        }

        private void CB_Marka_MouseDown(object sender, MouseEventArgs e)
        {
            Temizle();
            CLS.StokCreateUrun.Listele_MarkaAdi(CB_Marka);
        }

        private void TB_UrunAdi_Validating(object sender, CancelEventArgs e)
        {
            if (CB_Marka.Text != "")
            {
                CLS.StokCreateUrun.UrunNoSorgula(CB_Marka.Text, out string No);
                TB_UrunNo.Text = No;
            }
           
        }

        void KontrolEt()
        {
            string Baslik = "Hay Aksi! Ters bir şey oldu";
            if (CB_Marka.Text != "")
            {
                if (TB_MarkaNo.Text != "")
                {
                    if (TB_UrunNo.Text != "")
                    {
                        if (TB_UrunAdi.Text != "")
                        {
                            if (NUD_BirimFiyat.Value != 0 || CHB_FiyatIptal.Checked)
                            {
                                if (CB_ParaBirimi.Text != "" || CHB_FiyatIptal.Checked)
                                {
                                    if (NUD_Iskonto.Value != 0 || CHB_IskontoIptal.Checked)
                                    {
                                        if ( NUD_UrunKodEndChar.Value != 0)
                                        {
                                            if (NUD_UrunKodEndChar.Value > NUD_UrunKodFirstChar.Value)
                                            {
                                                if (NUD_UrunIDEndChar.Value != 0 || CHB_UrunIDGirisiManualSecim.Checked)
                                                {
                                                    if ((NUD_UrunIDEndChar.Value > NUD_UrunIDFirstChar.Value) || CHB_UrunIDGirisiManualSecim.Checked)
                                                    {
                                                        Ekle();
                                                    } else { MessageBox.Show("Ürün ID karakter seçiminde bitiş değeri başlangıç değerinden büyük olmalı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                } else { MessageBox.Show("Ürün ID karakter seçiminde sıfır değeri olmamalı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                            } else { MessageBox.Show("Ürün kodu karakter seçiminde bitiş değeri başlangıç değerinden büyük olmalı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                        } else { MessageBox.Show("Ürün kodu karakter seçiminde sıfır değeri olmamalı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    } else { MessageBox.Show("Ürün için iskonto sıfır! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                } else { MessageBox.Show("Ürün Birim fiyatı için para birimi seçilmemiş! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            } else { MessageBox.Show("Ürün Birim fiyatı sıfır! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        } else { MessageBox.Show("Ürün Adı boş gözüküyor! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    } else { MessageBox.Show("Ürün No boş gözüküyor! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                } else { MessageBox.Show("Marka No boş gözüküyor! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            } else { MessageBox.Show("Marka Seçimi yapılmadı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }


        }
        void Ekle()
        {

            string Baslik = "Yeni bir ürün sisteme ekleniyor!";
            string Mesaj = "Marka No: "         + TB_MarkaNo.Text               + "\n" +
                           "Marka Adı: "        + CB_Marka.Text                 + "\n" +
                           "Ürün No: "          + TB_UrunNo.Text                + "\n" +
                           "Ürün Kodu: "        + TB_UrunKodu.Text              + "\n" +
                           "Ürün Adı: "         + TB_UrunAdi.Text               + "\n" +
                           "Ürün Açıklaması: "  + TB_UrunAciklamasi.Text        + "\n" +
                           "Birim Fiyat: "      + NUD_BirimFiyat.Value          + " "  + CB_ParaBirimi.Text + "\n" +
                           "İskonto Mikarı: %"  + NUD_Iskonto.Value             + "\n" +
                           "Yukarıdaki bilgilere göre yeni bir ürün eklemek istiyor musunuz?";

            DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Soru == DialogResult.OK)
            {
     
                string UrunNot                  = "";
                string MarkaNo                  = TB_MarkaNo.Text;
                string MarkaAdi                 = CB_Marka.Text;
                string Barkod                   = TB_Stok_Olustur_BarkodString.Text;
                string UrunKodFirstChar         = NUD_UrunKodFirstChar.Value.ToString();
                string UrunKodEndChar           = NUD_UrunKodEndChar.Value.ToString();
                string UrunIDFirstChar          = NUD_UrunIDFirstChar.Value.ToString();
                string UrunIDEndChar            = NUD_UrunIDEndChar.Value.ToString();
                string UrunKodu                 = TB_UrunKodu.Text;
                string UrunAdi                  = TB_UrunAdi.Text;
                string UrunInfo                 = TB_UrunAciklamasi.Text;
                string UrunID                   = "";
                string UrunFiyat                = Crypto.Encrypt(NUD_BirimFiyat.Value.ToString(), CLS.Str_StokCrypto) ;
                string UrunFiyatBirim           = Crypto.Encrypt(CB_ParaBirimi.Text.ToString(), CLS.Str_StokCrypto);
                string UrunIskonto              = Crypto.Encrypt(NUD_Iskonto.Value.ToString(), CLS.Str_StokCrypto);

                CLS.StokCreateUrun.YeniUrun(UrunNot, MarkaNo, MarkaAdi, Barkod, UrunKodFirstChar, UrunKodEndChar, UrunIDFirstChar, UrunIDEndChar,  UrunKodu, UrunAdi, UrunInfo, UrunID, UrunFiyat, UrunFiyatBirim, UrunIskonto);

               Temizle();
               this.Hide();
            }
        }
        void Temizle()
        {
            TB_MarkaNo.Text                     = "";
            CB_Marka.Text                       = "";
            TB_UrunNo.Text                      = "";
            TB_UrunKodu.Text                    = "";
            TB_UrunAdi.Text                     = "";
            TB_UrunAciklamasi.Text              = "";
            TB_Stok_Olustur_BarkodString.Text   = "";
            TB_SeciliKarakterFirst.Text         = "";
            TB_SeciliKarakterEnd.Text           = "";
            NUD_BirimFiyat.Value                = 0;
            NUD_Iskonto.Value                   = 0;
            NUD_UrunKodFirstChar.Value          = 0;
            NUD_UrunKodEndChar.Value            = 0;
            NUD_UrunIDFirstChar.Value           = 0;
            NUD_UrunIDEndChar.Value             = 0;
            //CB_ParaBirimi.Items.Clear();
            CB_Marka.Items.Clear();
            CB_Marka.Text                       = "";
            CB_ParaBirimi.Text                  = "";
            CHB_UrunIDGirisiManualSecim.Checked = false;
        }

        private void CHB_UrunIDGirisiManualSecim_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_UrunIDGirisiManualSecim.Checked)
            {
                NUD_UrunIDFirstChar.Value = -1;
                NUD_UrunIDEndChar.Value = -1;
                NUD_UrunIDFirstChar.Enabled = false;
                NUD_UrunIDEndChar.Enabled = false;
            }
            else
            {
                NUD_UrunIDFirstChar.Value = 0;
                NUD_UrunIDEndChar.Value = 0;
                NUD_UrunIDFirstChar.Enabled = true;
                NUD_UrunIDEndChar.Enabled = true;
            }
        }

        private void CHB_FiyatIptal_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_FiyatIptal.Checked)
            {
                NUD_BirimFiyat.Enabled = false;
                CB_ParaBirimi.Enabled = false;
                NUD_BirimFiyat.Value = 0;
            }
            else
            {
                NUD_BirimFiyat.Enabled = true;
                CB_ParaBirimi.Enabled = true;
            }
        }

        private void CHB_IskontoIptal_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_IskontoIptal.Checked)
            {
                NUD_Iskonto.Enabled = false;
                NUD_Iskonto.Value = 0;
            }
            else
            {
                NUD_Iskonto.Enabled = true;
            }
        }


        private void B_KarakterAraligiBul_Click(object sender, EventArgs e)
        {
            TB_SeciliKarakterFirst.Text = TB_Stok_Olustur_BarkodString.SelectionStart.ToString();
            TB_SeciliKarakterEnd.Text = (TB_Stok_Olustur_BarkodString.SelectionLength + TB_Stok_Olustur_BarkodString.SelectionStart).ToString();
        }

        private void B_SeciliKarakterAraligi_SecimKod_Click(object sender, EventArgs e)
        {
            TB_SeciliKarakterFirst.Text = TB_Stok_Olustur_BarkodString.SelectionStart.ToString();
            TB_SeciliKarakterEnd.Text = (TB_Stok_Olustur_BarkodString.SelectionLength + TB_Stok_Olustur_BarkodString.SelectionStart).ToString();

            if (TB_SeciliKarakterFirst.Text != "" && TB_SeciliKarakterEnd.Text != "")
            {
                NUD_UrunKodFirstChar.Value = int.Parse(TB_SeciliKarakterFirst.Text);
                NUD_UrunKodEndChar.Value = int.Parse(TB_SeciliKarakterEnd.Text);
            }
     
        }

        private void B_SeciliKarakterAraligi_SecimID_Click(object sender, EventArgs e)
        {
            TB_SeciliKarakterFirst.Text = TB_Stok_Olustur_BarkodString.SelectionStart.ToString();
            TB_SeciliKarakterEnd.Text = (TB_Stok_Olustur_BarkodString.SelectionLength + TB_Stok_Olustur_BarkodString.SelectionStart).ToString();

            if (TB_SeciliKarakterFirst.Text != "" && TB_SeciliKarakterEnd.Text != "")
            {
                NUD_UrunIDFirstChar.Value = int.Parse(TB_SeciliKarakterFirst.Text);
                NUD_UrunIDEndChar.Value = int.Parse(TB_SeciliKarakterEnd.Text);
            }
        }



    }
}
