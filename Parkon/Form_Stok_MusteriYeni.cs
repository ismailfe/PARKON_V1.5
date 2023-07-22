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
    public partial class Form_Stok_MusteriYeni : Form
    {

        #region PUBLIC_VARIABLE
        public CLS CLS;
        #endregion
        public Form_Stok_MusteriYeni()
        {
            InitializeComponent();
        }
        private void Form_Yeni_Musteri_Load(object sender, EventArgs e)
        {

        }

        private void B_Iptal_Click(object sender, EventArgs e)
        {
            Temizle();
            this.Hide();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }

        public void KontrolEt()
        {
            string Baslik = "Yeni müşteri ekleme hatası";
            if (TB_MusteriFirma_Adi.Text != "")
            {
                if (TB_MusteriFirma_No.Text != "")
                {
                    if (CB_MusteriFirma_Bolge.Text != "")
                    {
                        if (TB_MusteriFirma_Adres.Text != "")
                        {
                            if (TB_MusteriBolum_No.Text != "")
                            {
                                if (TB_MusteriBolum_Adi.Text != "")
                                {
                                    Ekle();
                                } else {  MessageBox.Show("Müşteri firma bölüm adı yazılmadı!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            } else { MessageBox.Show("Müşteri firma bölüm no oluşturulmadı!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }else { MessageBox.Show("Müşteri firma adresi yazılmadı!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }else { MessageBox.Show("Müşteri firma bölgesi seçilmedi!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }else { MessageBox.Show("Müşteri firma No oluşturulmadı!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            } else {  MessageBox.Show("Müşteri firma adı girilmedi!", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        public void Ekle()
        {
            string baslik = "Yeni Müşteri Ekle - Onay";
            string mesaj = "Aşağıdaki bilgilere göre yeni bir müşteri firma eklemeyi kabul ediyor musunuz?" + "\n" + "\n" +
                "Müşteri firma no: "        + TB_MusteriFirma_No.Text       + "\n" +
                "Müşteri firma adı: "       + TB_MusteriFirma_Adi.Text      + "\n" + "\n" +
                "Müşteri firma bölgesi: "   + CB_MusteriFirma_Bolge.Text    + "\n" +
                "Müşteri firma adresi: "    + TB_MusteriFirma_Adres.Text    + "\n" +
                "Müşteri firma maps link: " + TB_MusteriFirma_MapsLink.Text + "\n" +
                "Müşteri firma tel: "       + TB_MusteriFirma_Tel.Text      + "\n" +
                "Müşteri firma Notları: "   + TB_MusteriFirma_Not.Text      + "\n" + "\n" +
                "Müşteri firma bölüm no: "  + TB_MusteriBolum_No.Text       + "\n" +
                "Müşteri firma bölüm adi: " + TB_MusteriBolum_Adi.Text      + "\n" + "";

            DialogResult Soru = MessageBox.Show(mesaj, baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Soru == DialogResult.OK)
            {
                string mfirmaolustur        = CLS.StokCreateMusteri.YeniMusteriOlustur(TB_MusteriFirma_Not.Text, TB_MusteriFirma_Adi.Text, CB_MusteriFirma_Bolge.Text, TB_MusteriFirma_Adres.Text, TB_MusteriFirma_MapsLink.Text, TB_MusteriFirma_Tel.Text);
                string mfirmaBolumolustur   = CLS.StokCreateMusteri.YeniMusteriBolumOlustur("", TB_MusteriFirma_No.Text, TB_MusteriFirma_Adi.Text, TB_MusteriBolum_No.Text, TB_MusteriBolum_Adi.Text);
                //string mfirmaKlasorOlustur = CLS.CreateFolder.Create_Yeni_Musteri_Klasor(TB_MusteriFirma_No.Text, TB_MusteriFirma_Adi.Text);

                string baslik2 = "İşlem tamamlandı";
                string mesaj2 = "Yeni Müşteri firma oluşturma işlemi "          + mfirmaolustur + "\n" + "\n" +
                                "Yeni Müşteri firma Bölümü oluşturma işlemi "   + mfirmaBolumolustur + "\n" + "\n";

                DialogResult islemOnay = MessageBox.Show(mesaj2, baslik2, MessageBoxButtons.OK);

                if (islemOnay == DialogResult.OK)
                {
                    Temizle();
                    this.Hide();
                }

            }

             



        }
        
 
 

        public void Temizle()
        {
            TB_MusteriFirma_No.Text = "";
            TB_MusteriFirma_Adi.Text = "";
            CB_MusteriFirma_Bolge.Text = "";
            CB_MusteriFirma_Bolge.SelectedIndex = 0;
            TB_MusteriFirma_Adres.Text = "";
            TB_MusteriFirma_MapsLink.Text = "";
            TB_MusteriFirma_Tel.Text = "";
            TB_MusteriFirma_Not.Text = "";
            TB_MusteriBolum_No.Text = "";
            TB_MusteriBolum_Adi.Text = "";
            CHB_MuseriBolum_Adi_Degistir.Checked = false;
        }

        private void CHB_MuseriBolum_Adi_Degistir_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_MuseriBolum_Adi_Degistir.Checked)
            {
                TB_MusteriBolum_Adi.ReadOnly = false;

            }else
            {
                TB_MusteriBolum_Adi.ReadOnly = true;
            }
        }

        private void TB_MusteriBolum_Adi_TextChanged(object sender, EventArgs e)
        {
            if (TB_MusteriBolum_Adi.Text == "")
            {
                TB_MusteriBolum_Adi.Text = "MERKEZ";
            }
        }

        private void TB_MusteriFirma_Adi_Validating(object sender, CancelEventArgs e)
        {
            
            if (TB_MusteriFirma_Adi.Text != "")
            {
                CLS.StokCreateMusteri.MusteriNoSorgula(out string No);
                TB_MusteriFirma_No.Text = No;
                CLS.StokCreateMusteri.MusteriBolumNoSorgula(TB_MusteriFirma_No.Text, out string No2);
                TB_MusteriBolum_No.Text = No2;
            }
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




    }
}
