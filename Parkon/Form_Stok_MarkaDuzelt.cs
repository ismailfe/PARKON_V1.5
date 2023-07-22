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
    public partial class Form_Stok_MarkaDuzelt : Form
    {
        public CLS  CLS;
        string ID;
        public Form_Stok_MarkaDuzelt()
        {
            InitializeComponent();
        }
        private void TB_Stok_Olustur_MarkaAdi_Validating(object sender, CancelEventArgs e)
        {
            //CLS.StokCreateMarka.MarkaNoSorgula(out string MarkaNo);
            //TB_Stok_Olustur_MarkaNo.Text = MarkaNo;
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

        void VeriYenile()
        {
            CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBStokMarka, DGV_Veri);
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
            string Baslik = "DÜZENLEME!";
            string Mesaj = "Marka No: " + TB_Stok_Olustur_MarkaNo.Text + "\n" +
                           "Marka Adı: " + TB_Stok_Olustur_MarkaAdi.Text + "\n" +
                           "Marka Notu: " + TB_MarkaNot.Text + "\n" +
                           "Yukarıdaki bilgilere düzenlemek istiyor musunuz?";
            DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Soru == DialogResult.OK)
            {
                string[] WData  = new string[CLS.MySQLVar.ColumnName_DBStokMarka.Length];
                WData[0]        = "";
                WData[1]        = DateTime.Now.ToString();
                WData[2]        = CLS.Form_Main.LB_UserName.Text;
                WData[3]        = TB_MarkaNot.Text;
                WData[4]        = TB_Stok_Olustur_MarkaNo.Text;
                WData[5]        = TB_Stok_Olustur_MarkaAdi.Text;
             
                string Status = CLS.ID_MySQL.UPDATE_WithRefText_FromSQLRow(CLS.MySQLVar.TableName_DBStokMarka, CLS.MySQLVar.ColumnName_DBStokMarka, WData, "ID", ID, 0);
                MessageBox.Show("İşlem Durumu:" + Status, "DURUM");
                VeriYenile();
            }

        }
        void Temizle()
        {
            TB_Stok_Olustur_MarkaNo.Text            = "";
            TB_Stok_Olustur_MarkaAdi.Text           = "";
            TB_MarkaNot.Text                        = "";
        }

      
        private void DGV_Veri_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_Veri.SelectedRows)
            { 
                ID                              = row.Cells[0].Value.ToString();
                TB_MarkaNot.Text                = row.Cells[3].Value.ToString();
                TB_Stok_Olustur_MarkaNo.Text    = row.Cells[4].Value.ToString();
                TB_Stok_Olustur_MarkaAdi.Text   = row.Cells[5].Value.ToString();
            }
        }

        private void Form_Stok_MarkaDuzelt_Load(object sender, EventArgs e)
        {

            VeriYenile();
        }
    }
}
