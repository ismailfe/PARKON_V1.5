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
    public partial class Form_Stok_MarkaYeni : Form
    {
        public CLS  CLS;

        public Form_Stok_MarkaYeni()
        {
            InitializeComponent();
        }
        private void TB_Stok_Olustur_MarkaAdi_Validating(object sender, CancelEventArgs e)
        {
            CLS.StokCreateMarka.MarkaNoSorgula(out string MarkaNo);
            TB_Stok_Olustur_MarkaNo.Text = MarkaNo;
        }
            private void B_OK_Click(object sender, EventArgs e)
        {
            KontrolEt(); // Kontrol Ok ise Ekleme işlemine geçer;
        }
        private void B_Iptal_Click(object sender, EventArgs e)
        {
            Temizle();
            //this.Hide();
        }

        void KontrolEt()
        {
            string Baslik = "Hay Aksi! Ters bir şey oldu";
            if (TB_Stok_Olustur_MarkaNo.Text != "")
            {
                if (TB_Stok_Olustur_MarkaAdi.Text != "")
                {
                    Ekle();
                }  else { MessageBox.Show("Marka adı boş gözüküyor! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }  else { MessageBox.Show("Marka Numarası oluşturulamadı! Lütfen verileri tekrar girin.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
          
        }
        void Ekle()
        {
            string Baslik = "Yeni bir marka sisteme ekleniyor!";
            string Mesaj = "Marka No: " + TB_Stok_Olustur_MarkaNo.Text + "\n" +
                           "Marka Adı: " + TB_Stok_Olustur_MarkaAdi.Text + "\n" +
                           "Marka Notu: " + TB_MarkaNot.Text + "\n" +
                           "Yukarıdaki bilgilere göre yeni bir marka eklemek istiyor musunuz?";
            DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Soru == DialogResult.OK)
            {
                CLS.StokCreateMarka.YeniMarka(TB_MarkaNot.Text, TB_Stok_Olustur_MarkaAdi.Text);
                Temizle();
                this.Hide();
            }

        }
        void Temizle()
        {
            TB_Stok_Olustur_MarkaNo.Text            = "";
            TB_Stok_Olustur_MarkaAdi.Text           = "";
            TB_MarkaNot.Text                        = "";
        }

        
    }
}
