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
    public partial class Form_Stok_UrunDuzelt : Form
    {
        public CLS CLS;
        string ID;
        bool SelectDGV_ENB;
        public Form_Stok_UrunDuzelt()
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
            CLS.StokCreateUrun.Listele_MarkaAdi(CB_Marka);
        }

        private void TB_UrunAdi_Validating(object sender, CancelEventArgs e)
        {
            //if (CB_Marka.Text != "")
            //{
            //    CLS.StokCreateUrun.UrunNoSorgula(CB_Marka.Text, out string No);
            //    TB_UrunNo.Text = No;
            //}
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

            string Baslik = "DÜZENLEME!";
            string Mesaj = "Marka No: "         + TB_MarkaNo.Text               + "\n" +
                           "Marka Adı: "        + CB_Marka.Text                 + "\n" +
                           "Ürün No: "          + TB_UrunNo.Text                + "\n" +
                           "Ürün Kodu: "        + TB_UrunKodu.Text              + "\n" +
                           "Ürün Adı: "         + TB_UrunAdi.Text               + "\n" +
                           "Ürün Açıklaması: "  + TB_UrunAciklamasi.Text        + "\n" +
                           "Birim Fiyat: "      + NUD_BirimFiyat.Value          + " "  + CB_ParaBirimi.Text + "\n" +
                           "İskonto Mikarı: %"  + NUD_Iskonto.Value             + "\n" +
                           "Yukarıdaki bilgilere göre düzenleme yapmak istiyor musunuz?";

            DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Soru == DialogResult.OK)
            {
     
                string[] WData = new string[19];
                WData[0] = "";
                WData[1] = DateTime.Now.ToString();
                WData[2] = CLS.Form_Main.LB_UserName.Text;
                WData[3] = "";
                WData[4] = TB_MarkaNo.Text;
                WData[5] = CB_Marka.Text;
                WData[6] = TB_Stok_Olustur_BarkodString.Text;
                WData[7] = NUD_UrunKodFirstChar.Value.ToString();
                WData[8] = NUD_UrunKodEndChar.Value.ToString();
                WData[9] = NUD_UrunIDFirstChar.Value.ToString();
                WData[10] = NUD_UrunIDEndChar.Value.ToString();
                WData[11] = TB_UrunNo.Text;
                WData[12] = TB_UrunKodu.Text;
                WData[13] = TB_UrunAdi.Text;
                WData[14] = TB_UrunAciklamasi.Text;
                WData[15] = TB_UrunID.Text;
                WData[16] = Crypto.Encrypt(NUD_BirimFiyat.Value.ToString(), CLS.Str_StokCrypto);
                WData[17] = Crypto.Encrypt(CB_ParaBirimi.Text.ToString(), CLS.Str_StokCrypto);
                WData[18] = Crypto.Encrypt(NUD_Iskonto.Value.ToString(), CLS.Str_StokCrypto);

                string Status = CLS.ID_MySQL.UPDATE_WithRefText_FromSQLRow(CLS.MySQLVar.TableName_DBStokUrun, CLS.MySQLVar.ColumnName_DBStokUrun, WData, "ID", ID, 0);
                MessageBox.Show("İşlem Durumu:" + Status, "DURUM");
                VeriYenile();
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

        private void DGV_Veri_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectDGV_ENB)
            {
                foreach (DataGridViewRow row in DGV_Veri.SelectedRows)
                {
                    if (row.Cells[0].Value.ToString() != "" && row.Cells[0].Value.ToString() != null)
                    {
                        ID = row.Cells[0].Value.ToString();
                        TB_MarkaNo.Text = row.Cells[4].Value.ToString();
                        CB_Marka.Text = row.Cells[5].Value.ToString();
                        TB_Stok_Olustur_BarkodString.Text = row.Cells[6].Value.ToString();
                        int.TryParse(row.Cells[7].Value.ToString(), out int Res10);
                        NUD_UrunKodFirstChar.Value = Res10;
                        int.TryParse(row.Cells[8].Value.ToString(), out int Res11);
                        NUD_UrunKodEndChar.Value = Res11;
                        int.TryParse(row.Cells[9].Value.ToString(), out int Res12);
                        NUD_UrunIDFirstChar.Value = Res12;
                        int.TryParse(row.Cells[10].Value.ToString(), out int Res13);
                        NUD_UrunIDEndChar.Value = Res13;
                        TB_UrunNo.Text = row.Cells[11].Value.ToString();
                        TB_UrunKodu.Text = row.Cells[12].Value.ToString();
                        TB_UrunAdi.Text = row.Cells[13].Value.ToString();
                        TB_UrunAciklamasi.Text = row.Cells[14].Value.ToString();
                        TB_UrunID.Text = row.Cells[15].Value.ToString();

                        if (int.TryParse(Crypto.Decrypt(row.Cells[16].Value.ToString(), CLS.Str_StokCrypto), out int Res1))
                        {
                            NUD_BirimFiyat.Value = Res1;
                        }

                        if (row.Cells[17].Value.ToString() != "")
                        {
                            CB_ParaBirimi.Text = Crypto.Decrypt(row.Cells[17].Value.ToString(), CLS.Str_StokCrypto);
                        }

                        if (int.TryParse(Crypto.Decrypt(row.Cells[18].Value.ToString(), CLS.Str_StokCrypto), out int Res3))
                        {
                            NUD_Iskonto.Value = Res3;
                        }




                        if (NUD_UrunIDFirstChar.Value == -1)
                        {
                            CHB_UrunIDGirisiManualSecim.Checked = true;
                        }
                        else
                        {
                            CHB_UrunIDGirisiManualSecim.Checked = false;
                        }

                        TB_SeciliKarakterFirst.Text = "";
                        TB_SeciliKarakterEnd.Text = "";
                    }
                   
                }
            }
        
        }

        private void Form_Stok_UrunDuzelt_Load(object sender, EventArgs e)
        {
            VeriYenile();
        }

        void VeriYenile()
        {
            SelectDGV_ENB = false;
            string status = CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBStokUrun, DGV_Veri);
            SelectDGV_ENB = true;
        }


    }
}
