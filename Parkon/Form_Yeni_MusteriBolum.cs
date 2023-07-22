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
    public partial class Form_Yeni_MusteriBolum : Form
    {

        #region PUBLIC_VARIABLE
        public CLS CLS;
        public Form_Main Form_Main;

        #endregion

        #region FORM NESNELERİ
        public Form_Yeni_MusteriBolum()
        {
            InitializeComponent();
        }
        private void Form_Yeni_Musteri_Load(object sender, EventArgs e)
        {
  
        }
        private void Form_Yeni_MusteriBolum_Shown(object sender, EventArgs e)
        {
            Temizle(true);
        }


        private void B_Iptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void B_OK_Click(object sender, EventArgs e)
        {
            MUSTERIBOLUM_OLUSTUR_ON_KONTROL();
            //CLS.CreateDepartment.MusteriBolumNoSorgula(TB_MusteriFirma_No.Text, out string BolumNo);
            //CLS.CreateDepartment.YeniMusteriBolumOlustur(TB_MusteriBolum_Not.Text, TB_MusteriFirma_No.Text, CB_MusteriFirma_Adi.Text, BolumNo, TB_MusteriBolum_Adi.Text);

            //TB_Durum.Text = DateTime.Now.ToString() + " - " + TB_MusteriFirma_No.Text.Trim() + " " + CB_MusteriFirma_Adi.Text + " adlı müşteri için " + 
            //                BolumNo + " " + TB_MusteriBolum_Adi.Text + " bölümü oluşturuldu.";
        }

        public void MUSTERIBOLUM_OLUSTUR_ON_KONTROL()
        {
            string Baslik = "Hata";
            if (CB_MusteriFirma_Adi.Text != "")
            {
                if (TB_MusteriFirma_No.Text != "")
                {
                    if (TB_MusteriBolum_No.Text != "")
                    {
                        if (TB_MusteriBolum_Adi.Text != "")
                        {
                            MUSTERIBOLUM_OLUSTUR();
                        }
                        else { MessageBox.Show("Müşteri firma bölüm adı yazılmadı!", Baslik); }
                    }
                    else { MessageBox.Show("Müşteri firma bölüm no oluşturulmadı!", Baslik); }
                }
                else { MessageBox.Show("Müşteri firma No oluşturulmadı!", Baslik); }
            }
            else { MessageBox.Show("Müşteri firma adı girilmedi!", Baslik); }

        }

        public void MUSTERIBOLUM_OLUSTUR()
        {
            DialogResult a = new DialogResult();
            string baslik = "Yeni Müşteri Bölümü Ekle - Onay";
            string mesaj = "Aşağıdaki bilgilere göre yeni bir müşteri firma bölümü eklemeyi kabul ediyor musunuz?" + "\n" + "\n" +
                "Müşteri firma no: "        + TB_MusteriFirma_No.Text + "\n" +
                "Müşteri firma adı: "       + CB_MusteriFirma_Adi.Text + "\n" + "\n" +
                "Müşteri firma bölüm no: "  + TB_MusteriBolum_No.Text + "\n" +
                "Müşteri firma bölüm adi: " + TB_MusteriBolum_Adi.Text + "\n" + "";


            a = MessageBox.Show(mesaj, baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (a == DialogResult.OK)
            {
                CLS.CreateDepartment.MusteriBolumNoSorgula(TB_MusteriFirma_No.Text, out string BolumNo);
                string mfirmaBolumolustur = CLS.CreateDepartment.YeniMusteriBolumOlustur(TB_MusteriBolum_Not.Text, TB_MusteriFirma_No.Text, CB_MusteriFirma_Adi.Text, BolumNo, TB_MusteriBolum_Adi.Text);

                string baslik2 = "İşlem tamamlandı";
                string mesaj2  = "Yeni Müşteri firma Bölümü oluşturma işlemi " + mfirmaBolumolustur;

                DialogResult islemOnay = new DialogResult();
                islemOnay = MessageBox.Show(mesaj2, baslik2, MessageBoxButtons.OK);

                if (islemOnay == DialogResult.OK)
                {
                    Temizle(true);
                    this.Hide();
                }

            }

        }


        #endregion


        #region MÜŞTERİ FİRMA SEÇİMİ
        private void CB_MusteriFirma_Adi_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.CreateProject.Listele_MusteriAdi(CB_MusteriFirma_Adi);
        }

        private void CB_MusteriFirma_Adi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.CreateProject.MusteriAdiSecildi(int.Parse(selectedValue), out string MusteriNo, out string MBolge, out string MAdres, out string MMapslink, out string MTel, out string Mnot, out string INFO);

            //TB_CrtPrj_MusteriSecim_No.Text = MusteriNo;
            //TB_CrtPrj_MusteriBolge.Text = MBolge;
            //TB_CrtPrj_MusteriAdres.Text = MAdres;
            //TB_CrtPrj_MusteriMapsLink.Text = MMapslink;
            //TB_CrtPrj_MusteriTel.Text = MTel;
            //RTB_CrtPrj_MusteriNot.Text = Mnot;

            TB_MusteriFirma_No.Text = MusteriNo;
            Temizle(false);
        }
        #endregion

        #region BÖLÜM BİLGİLERİ
        private void TB_Bolum_Adi_Validating(object sender, CancelEventArgs e)
        {
            if (TB_MusteriBolum_Adi.Text != "")
            {
                CLS.CreateDepartment.MusteriBolumNoSorgula(TB_MusteriFirma_No.Text, out string No2);
                TB_MusteriBolum_No.Text = No2;
            }

        }

        #endregion
        void Temizle(bool Hepsi)
        {
            if (Hepsi)
            {
                TB_MusteriBolum_Adi.Text = "";
                TB_MusteriBolum_No.Text = "";
                TB_MusteriBolum_Not.Text = "";
                CB_MusteriFirma_Adi.Text = "";
                CB_MusteriFirma_Adi.Items.Clear();
                TB_MusteriFirma_No.Text = "";
            }
            else
            {
                TB_MusteriBolum_Adi.Text = "";
                TB_MusteriBolum_No.Text = "";
                TB_MusteriBolum_Not.Text = "";
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
