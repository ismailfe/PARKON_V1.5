using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class Stok_UrunCikis
    {
        public CLS CLS;

        int UrunKodFirstChar;
        int UrunKodEndChar;
        int UrunKodCharAdet;

        int UrunIDFirstChar;
        int UrunIDEndChar;
        int UrunIDCharAdet;

        string Temp_UrunKodu1 = "";
        string Temp_UrunKodu2 = "";
        string Temp_UrunID1 = "";
        string Temp_UrunID2 = "";

        public string[] UrunVerisi  = new string[19];
        public string[] CikisVerisi = new string[34];
        public string[] MusteriVerisi = new string[10];
        public string[] MYetkiliVerisi = new string[13];


        #region BARKOD BUL
        public string MarkayaGoreUrunleriGetir(string MarkaAdi, DataGridView DGV)
        {
            try
            {
                // Markaya ait ürünleri DGV içine listele
                if (MarkaAdi != "")
                {
                    CLS.ID_MySQL.READ_SearchRefText(CLS.MySQLVar.TableName_DBStokDepo, "MarkaAd", MarkaAdi, 1, DGV);
                }
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }


        }
        public string BUL_Urun_ComboBox(string MarkaAdi, string MarkaNo, ComboBox ComboBoxTxt, DataGridView DGV)
        {
            try
            {

                char Ayrim      = '#';
                var SecilenUrun = ComboBoxTxt.Text.Split(Ayrim);
                CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text = SecilenUrun[0];
                int ComboBoxIdx = ComboBoxTxt.SelectedIndex;
                for (int i = ComboBoxIdx; i < DGV.RowCount - 1; i++)
                {
                    if (DGV.Rows[i].Cells[12].Value.ToString().Trim() == SecilenUrun[0].Trim())
                    {
                        //CLS.Stok_UrunCikis.SeriNoManuelCikisSecim(true);
                  

                        CLS.Form_Main.TB_StokUrunCikis_UrunNo.Text          = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
                        CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text        = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString();
                        CLS.Form_Main.TB_StokUrunCikis_UrunAdi.Text         = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                        CLS.Form_Main.TB_StokUrunCikis_UrunAciklama.Text    = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
                        CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text      = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[15].Value.ToString(); 
                        CLS.Form_Main.TB_StokUrunCikis_UrunFiyat.Text       = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString(), CLS.Str_StokCrypto);
                        CLS.Form_Main.TB_StokUrunCikis_FiyatBirim.Text      = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString(), CLS.Str_StokCrypto);
                        CLS.Form_Main.TB_StokUrunCikis_Iskonto.Text         = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString(), CLS.Str_StokCrypto);

                        UrunVerileriniYakalaYaz(i, CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text, CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text);
                        break;
                    }
                }

                //StokCikis_UrunBilgileriTemizle();

                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string BUL_Urun_Barkod(string MarkaAdi, string MarkaNo, string Barkod)
        {
            try
            {
                MarkayaGoreUrunleriGetir(MarkaAdi, CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri);
                StokCikis_UrunBilgileriTemizle();

                if (CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.RowCount > 1)
                {
                    // Markaya ait ürünleri DGV içinden okuyarak Karakter sayılarına göre barkoddan bilgileri Al
                    for (int i = 0; i < CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.RowCount - 1; i++)
                    {
                        BUL_UrunKodu(i);
                        BUL_UrunID(i, out bool UrunBulmaOK);

                        if (UrunBulmaOK)
                        {
                            break;
                        }

                    }

                }


                StokCikis_BarkodAlaniTemizle();
                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }


        }
        void BUL_UrunKodu(int i)
        {
            UrunKodFirstChar = int.Parse(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[7].Value.ToString());
            UrunKodEndChar = int.Parse(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[8].Value.ToString());
            UrunKodCharAdet = UrunKodEndChar - UrunKodFirstChar;

            if (UrunKodFirstChar != 0)
            {
                Temp_UrunKodu1 = CLS.Form_Main.TB_StokUrunCikis_Barkod.Text.Remove(0, UrunKodFirstChar);
                Temp_UrunKodu2 = Temp_UrunKodu1.Remove(UrunKodCharAdet, Temp_UrunKodu1.Length - UrunKodCharAdet);
            }
            else
            {
                Temp_UrunKodu2 = CLS.Form_Main.TB_StokUrunCikis_Barkod.Text.Remove(UrunKodEndChar, CLS.Form_Main.TB_StokUrunCikis_Barkod.Text.Length - UrunKodCharAdet);
            }

        }
        void BUL_UrunID(int i, out bool UrunBulundu)
        {
            UrunBulundu = false;

            if (Temp_UrunKodu2.Trim() == CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString().Trim())
            {
                if (CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString() != "-1" && CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString() != "-1")
                {
                    UrunIDFirstChar = int.Parse(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString());
                    UrunIDEndChar = int.Parse(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString());
                    UrunIDCharAdet = UrunIDEndChar - UrunIDFirstChar;

                    Temp_UrunID1 = CLS.Form_Main.TB_StokUrunCikis_Barkod.Text.Remove(0, UrunIDFirstChar);
                    Temp_UrunID2 = Temp_UrunID1.Remove(UrunIDCharAdet, Temp_UrunID1.Length - UrunIDCharAdet);
                    SeriNoManuelCikisSecim(false);

                    UrunBulundu = true;

                }
                else
                {
                    Temp_UrunID1 = "";
                    Temp_UrunID2 = "";
                    SeriNoManuelCikisSecim(true);
                }

                CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text        = Temp_UrunKodu2;
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text      = Temp_UrunID2;
                CLS.Form_Main.TB_StokUrunCikis_UrunNo.Text          = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
                CLS.Form_Main.TB_StokUrunCikis_UrunAdi.Text         = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                CLS.Form_Main.TB_StokUrunCikis_UrunAciklama.Text    = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
                CLS.Form_Main.TB_StokUrunCikis_UrunFiyat.Text       = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString(), CLS.Str_StokCrypto);
                CLS.Form_Main.TB_StokUrunCikis_FiyatBirim.Text      = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString(), CLS.Str_StokCrypto);
                CLS.Form_Main.TB_StokUrunCikis_Iskonto.Text         = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString(), CLS.Str_StokCrypto);
                UrunVerileriniYakalaYaz(i, Temp_UrunKodu2, Temp_UrunID2);
            }
        }
        public void SeriNoManuelCikisSecim(bool MANUEL)
        {
            if (MANUEL)
            {
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Clear();
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.BackColor = Color.Yellow;
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.ReadOnly = false;
            }
            else
            {
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Clear();
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.BackColor = SystemColors.Control;
                CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.ReadOnly = true;
            }

        }
        public void StokCikis_BarkodAlaniTemizle()
        {
            CLS.Form_Main.TB_StokUrunCikis_Barkod.Clear();
            CLS.Form_Main.TB_StokUrunCikis_Barkod.Focus();

            if (CLS.Form_Main.TB_StokUrunCikis_Barkod.Text != "")
            {
                CLS.Form_Main.TB_StokUrunCikis_Barkod.Clear();
            }
        }
        public void StokCikis_UrunBilgileriTemizle()
        {
            CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text      = "";
            CLS.Form_Main.TB_StokUrunCikis_UrunNo.Text          = "";
            CLS.Form_Main.TB_StokUrunCikis_UrunAdi.Text         = "";
            CLS.Form_Main.TB_StokUrunCikis_UrunAciklama.Text    = "";
            CLS.Form_Main.TB_StokUrunCikis_UrunFiyat.Text       = "";
            CLS.Form_Main.TB_StokUrunCikis_FiyatBirim.Text      = "";
            CLS.Form_Main.TB_StokUrunCikis_Iskonto.Text         = "";
            CLS.Form_Main.TB_StokUrunCikis_MevcutStok.Text      = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text        = "";
        }
        #endregion

        void UrunVerileriniYakalaYaz(int i, string UrunKodu, string UrunID)
        {
            UrunVerisi[0] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[0].Value.ToString();
            UrunVerisi[1] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[1].Value.ToString();
            UrunVerisi[2] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[2].Value.ToString();
            UrunVerisi[3] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[3].Value.ToString();
            UrunVerisi[4] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[4].Value.ToString();
            UrunVerisi[5] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[5].Value.ToString();
            UrunVerisi[6] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[6].Value.ToString();
            UrunVerisi[7] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[7].Value.ToString();
            UrunVerisi[8] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[8].Value.ToString();
            UrunVerisi[9] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString();
            UrunVerisi[10] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString();
            UrunVerisi[11] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
            UrunVerisi[12] = UrunKodu; // CLS.Form_Main.DGV_1.Rows[i].Cells[12].Value.ToString();
            UrunVerisi[13] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
            UrunVerisi[14] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
            UrunVerisi[15] = UrunID;// CLS.Form_Main.DGV_1.Rows[i].Cells[15].Value.ToString();
            UrunVerisi[16] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString();
            UrunVerisi[17] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString();
            UrunVerisi[18] = CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString();

            if (true)
            {
                CLS.Stok_Sorgulama.StokAdetiHesapla(CLS.Form_Main.DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[5].Value.ToString(), UrunKodu, out string Adet);
                CLS.Form_Main.TB_StokUrunCikis_MevcutStok.Text = Adet;
            }




        }

        #region DEPOYA URUN EKLE
        public string DepoyaUrunEkle()
        {
            try
            {

                string Baslik = "YENİ ÜRÜN DEPOYA EKLENİYOR";
                string Mesaj = "Marka: " + CLS.Form_Main.TB_StokUrunCikis_MarkaNo.Text + " " + CLS.Form_Main.CB_StokUrunCikis_Marka.Text + "\n" +
                                "Ürün No: " + CLS.Form_Main.TB_StokUrunCikis_UrunNo.Text + "\n" +
                                "Ürün Kodu: " + CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text + "\n" +
                                "Ürün Adı: " + CLS.Form_Main.TB_StokUrunCikis_UrunAdi.Text + "\n" +
                                "Ürün Açıklama: " + CLS.Form_Main.TB_StokUrunCikis_UrunAciklama.Text + "\n" +
                                "Ürün Seri No: " + CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text + "\n" +
                                "Ürün Fiyat: " + CLS.Form_Main.TB_StokUrunCikis_UrunFiyat.Text + " " + CLS.Form_Main.TB_StokUrunCikis_FiyatBirim.Text + "\n" +
                                "Ürün İskonto: %" + CLS.Form_Main.TB_StokUrunCikis_Iskonto.Text + "\n" +
                                "Yukarıdaki bilgilere göre yeni ürünü depoya eklemek istediğinizden emin misiniz?";

                DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (Soru == DialogResult.OK)
                {
                    if (CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text != "")
                    {
                        //Manuel girilen seri no tanımlama
                        UrunVerisi[12] = CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text;
                        UrunVerisi[15] = CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text;
                        DepoSeriNoKontrol(CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text, out bool UrunOK);

                        if (UrunOK)
                        {
                            string Status = CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokDepo, CLS.MySQLVar.ColumnName_DBStokDepo, UrunVerisi, 0);

                            MessageBox.Show("Depoya ürün girişi : " + Status, "DEPOYA ÜRÜN GİRİŞİ", MessageBoxButtons.OK);

                            StokCikis_UrunBilgileriTemizle();


                        }
                        else { MessageBox.Show("Ürün Seri No Depoda varolan başka bir ürünle aynı gözüküyor. Seri Noları kontrol ederek tekrar deneyin.", "ÜRÜN SERİ NO HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else { MessageBox.Show("Ürün Seri No'su boş gözüküyor. Seri No'yu kontrol ederek tekrar deneyin.", "ÜRÜN SERİ NO HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string DepoSeriNoKontrol(string UrunSeriNo, out bool UrunOK)
        {
            UrunOK = false;
            try
            {
                if (CLS.Form_Main.DGV_StokTemp.ColumnCount > 1)
                {
                    CLS.Form_Main.DGV_StokTemp.Columns.Clear();
                }


                string Status = CLS.ID_MySQL.READ_SearchRefText(CLS.MySQLVar.TableName_DBStokDepo, "UrunID", UrunSeriNo, 1, CLS.Form_Main.DGV_StokTemp);

                if (CLS.Form_Main.DGV_StokTemp.RowCount < 2)
                {
                    UrunOK = true;
                }
                else
                {
                    UrunOK = false;
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion


        #region DEOPODAN ÜRÜN ÇIKIŞI


        public string KontrolEt()
        {
            try
            {
                string Baslik = "DEPODAN ÜRÜN ÇIKIŞI - HATA!";
                if (CLS.Form_Main.TB_StokUrunCikis_MarkaNo.Text != "")
                {
                    if (CLS.Form_Main.CB_StokUrunCikis_Marka.Text != "")
                    {
                        if (CLS.Form_Main.TB_StokUrunCikis_UrunNo.Text != "" && CLS.Form_Main.TB_StokUrunCikis_UrunKodu.Text != "")
                        {
                            if (CLS.Form_Main.TB_StokUrunCikis_UrunSeriNo.Text != "" )
                            {
                                if (CLS.Form_Main.TB_StokUrunCikis_UrunAdi.Text != "")
                                {
                                    if (CLS.Form_Main.TB_StokUrunCikis_MevcutStok.Text != "")
                                    {
                                        if (CLS.Form_Main.CB_StokUrunCikis_Musteri.Text != "")
                                        {
                                            if (CLS.Form_Main.CB_StokUrunCikis_MYetkili.Text != "")
                                            {
                                                if (CLS.Form_Main.CB_StokUrunCikis_Aksiyon.Text != "")
                                                {
                                                    if (CLS.Form_Main.TB_StokUrunCikis_FaturaNo.Text != "" || !CLS.Form_Main.CHB_StokUrunCikis_FaturaNo.Checked)
                                                    {
                                                        if (CLS.Form_Main.TB_StokUrunCikis_IrsaliyeNo.Text != "" || !CLS.Form_Main.CHB_StokUrunCikis_IrsaliyeNo.Checked)
                                                        {
                                                            if (CLS.Form_Main.TB_StokUrunCikis_KargoTakipNo.Text != "" || !CLS.Form_Main.CHB_StokUrunCikis_KargoTakipNo.Checked)
                                                            {
                                                                if (CLS.Form_Main.TB_StokUrunCikis_AksiyonDiger.Text != "" || CLS.Form_Main.TB_StokUrunCikis_AksiyonDiger.Visible == false)
                                                                {
                                                                    if ( CLS.Form_Main.NUD_StokUrunCikis_Fiyat.Value != 0 || !CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
                                                                    {
                                                                        if (CLS.Form_Main.CB_StokUrunCikis_FiyatBirimi.Text != "" || !CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
                                                                        {
                                                                            if (CLS.Form_Main.NUD_StokUrunCikis_Iskonto.Value != 0 || !CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
                                                                            {
                                                                                UrunCikisYap();
                                                                            }
                                                                            else { MessageBox.Show("Ürün Çıkış fiyatı değiştir seçeneği seçili fakat Iskonto sıfır! Lütfen gereken bilgiyi giriniz. Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                                        }else { MessageBox.Show("Ürün Çıkış fiyatı değiştir seçeneği seçili fakat para birimi seçili değil! Lütfen gereken bilgiyi giriniz. Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                                    }else { MessageBox.Show("Ürün Çıkış fiyatı değiştir seçeneği seçili fakat fiyat sıfır! Lütfen gereken bilgiyi giriniz. Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                                }else { MessageBox.Show("Ürün Çıkış Aksiyonu diğer seçenek açıklaması yazılmadı!Lütfen gereken bilgiyi giriniz.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                            }else { MessageBox.Show("Ürün Kargo Takip No girilmedi!Lütfen gereken bilgiyi giriniz.Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                        }else { MessageBox.Show("Ürün İrsaliye No girilmedi!Lütfen gereken bilgiyi giriniz.Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                    }else { MessageBox.Show("Ürün Fatura No girilmedi! Lütfen gereken bilgiyi giriniz. Eğer girmek istemiyorsanız tanım kutusundaki onayı kaldırınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                                }else { MessageBox.Show("Ürün çıkış aksiyonu seçimi yapılmadı. Lütfen seçim yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                            }else { MessageBox.Show("Yetkili kişi seçimi yapılmadı. Lütfen seçim yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                        }else { MessageBox.Show("Müşteri Seçimi yapılmadı! Lütfen seçim yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    }else { MessageBox.Show("Mevcut Stokta belirtilen ürün bulunamadı.Stok adeti sıfır! Lütfen Depodaki stok ürünlerden seçim yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                }else { MessageBox.Show("", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            }else { MessageBox.Show("Ürün Seri No Yok! Lütfen yeniden ürün tanımlayınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }else { MessageBox.Show("Ürün No Yok! Lütfen Yeniden ürün tanımlayınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }else { MessageBox.Show("Ürün Markası seçilmedi! Lütfen seçim yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }else { MessageBox.Show("Ürün Marka No yok! Lütfen marka seçimini tekrar yapınız.", Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning); }



                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        public string CikisAksiyon()
        {
            if (CLS.Form_Main.CB_StokUrunCikis_Aksiyon.Text == "Diğer")
            {
               return CLS.Form_Main.TB_StokUrunCikis_AksiyonDiger.Text;
            }else
            {
                return CLS.Form_Main.CB_StokUrunCikis_Aksiyon.Text;
            }
        }

        public string UrunFiyat()
        {
            if (CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
            {
                return Crypto.Encrypt(CLS.Form_Main.NUD_StokUrunCikis_Fiyat.Value.ToString(), CLS.Str_StokCrypto);
            }
            else
            {
                return UrunVerisi[16];
            }
        }

        public string UrunFiyatBirim()
        {
            if (CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
            {
                return Crypto.Encrypt(CLS.Form_Main.CB_StokUrunCikis_FiyatBirimi.Text, CLS.Str_StokCrypto);
            }
            else
            {
                return UrunVerisi[17];
            }
        }

        public string UrunIskonto()
        {
            if (CLS.Form_Main.CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
            {
                return Crypto.Encrypt(CLS.Form_Main.NUD_StokUrunCikis_Iskonto.Value.ToString(), CLS.Str_StokCrypto);
            }
            else
            {
                return UrunVerisi[18];
            }
        }
        public string UrunCikisYap()
        {
            try
            {
                CikisVerisi[0] = ""; //ID Primary Key
                CikisVerisi[1] = DateTime.Now.ToString(); //Tarih
                CikisVerisi[2] = CLS.Form_Main.LB_UserName.Text; //User
                CikisVerisi[3] = ""; //Notlar
                CikisVerisi[4] = UrunVerisi[4]; //MarkaNo
                CikisVerisi[5] = UrunVerisi[5]; //MarkaAd
                CikisVerisi[6] = UrunVerisi[6]; //Barkod
                CikisVerisi[7] = UrunVerisi[7]; //UrunKodFirstChar
                CikisVerisi[8] = UrunVerisi[8]; //UrunKodEndChar
                CikisVerisi[9] = UrunVerisi[9]; //UrunIDFirstChar 
                CikisVerisi[10] = UrunVerisi[10]; //UrunIDEndChar
                CikisVerisi[11] = UrunVerisi[11]; //UrunNo
                CikisVerisi[12] = UrunVerisi[12]; //UrunKod
                CikisVerisi[13] = UrunVerisi[13]; //UrunAd
                CikisVerisi[14] = UrunVerisi[14]; //UrunInfo
                CikisVerisi[15] = UrunVerisi[15]; //UrunID
                CikisVerisi[16] = UrunFiyat();      //UrunFiyat
                CikisVerisi[17] = UrunFiyatBirim(); //UrunFiyatBirim
                CikisVerisi[18] = UrunIskonto();    //UrunIskonto
                CikisVerisi[19] = MusteriVerisi[4]; //MusteriNo
                CikisVerisi[20] = MusteriVerisi[5]; //MusteriAdi
                CikisVerisi[21] = MYetkiliVerisi[6] ; //MYetkiliNo
                CikisVerisi[22] = MYetkiliVerisi[7] ; //MYetkiliAdi
                CikisVerisi[23] = MYetkiliVerisi[8] ; //MYetkiliTitle
                CikisVerisi[24] = MYetkiliVerisi[9] ; //MYetkiliTel1
                CikisVerisi[25] = MYetkiliVerisi[10]; //MYetkiliTel2
                CikisVerisi[26] = MYetkiliVerisi[11]; //MYetkiliMail
                CikisVerisi[27] = MYetkiliVerisi[12]; //MYetkiliInfo
                CikisVerisi[28] = Crypto.Encrypt( CikisAksiyon(), CLS.Str_StokCrypto); //CikisAksiyon
                CikisVerisi[29] = Crypto.Encrypt( CLS.Form_Main.TB_StokUrunCikis_Aciklama.Text, CLS.Str_StokCrypto); //CikisEkAciklama
                CikisVerisi[30] = Crypto.Encrypt( CLS.Form_Main.TB_StokUrunCikis_FaturaNo.Text, CLS.Str_StokCrypto); //FatruraNo
                CikisVerisi[31] = Crypto.Encrypt( CLS.Form_Main.TB_StokUrunCikis_IrsaliyeNo.Text, CLS.Str_StokCrypto); //IrsaliyeNo
                CikisVerisi[32] = Crypto.Encrypt( CLS.Form_Main.TB_StokUrunCikis_KargoTakipNo.Text, CLS.Str_StokCrypto); //KargoNo
                CikisVerisi[33] = ""; //CikisKodu

                string Baslik = "DEPODAN ÜRÜN ÇIKIŞ ONAYI";
                string Mesaj =  "Ürün Marka: "      + CikisVerisi[4] + " " + CikisVerisi[5] + "\n" +
                                "Ürün Kodu: "       + CikisVerisi[12] + "\n" +
                                "Ürün ID: "         + CikisVerisi[15] + "\n" +
                                "Ürün Adı: "        + CikisVerisi[13] + "\n" +
                                "Fiyat / İskonto: " + Crypto.Decrypt( CikisVerisi[16], CLS.Str_StokCrypto) + " " + Crypto.Decrypt(CikisVerisi[17], CLS.Str_StokCrypto) + 
                                                        " / %" + Crypto.Decrypt(CikisVerisi[18], CLS.Str_StokCrypto) + "\n" +
                                "Müşteri Firma: "   + CikisVerisi[20] + "\n" +
                                "Yetkili Kişi: "    + Crypto.Decrypt(CikisVerisi[23], CLS.Str_StokCrypto) + " - " + Crypto.Decrypt(CikisVerisi[22], CLS.Str_StokCrypto) + "\n" +
                                "Çıkış Aksiyonu: "  + Crypto.Decrypt(CikisVerisi[28], CLS.Str_StokCrypto) + "\n" +
                                "Çıkış Açıklama: "  + CLS.Form_Main.TB_StokUrunCikis_Aciklama.Text + "\n" +
                                "Fatura No: "       + CLS.Form_Main.TB_StokUrunCikis_FaturaNo.Text + "\n" +
                                "Irsaliye No: "     + CLS.Form_Main.TB_StokUrunCikis_IrsaliyeNo.Text + "\n" +
                                "Kargo Takip No: "  + CLS.Form_Main.TB_StokUrunCikis_KargoTakipNo.Text + "\n" + "\n" +
                                "Yukarıdaki bilgilerin doğruluğunu onaylarak depodan ürün çıkışı yapmak istediğinizden emin misiniz?";

                DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Soru == DialogResult.OK)
                {
                    string Status = CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokCikis, CLS.MySQLVar.ColumnName_DBStokCikis, CikisVerisi, 0);
                    string Status2 = "";
                    if (Status == "OK")
                    {
                        Status2 = CLS.ID_MySQL.DELETE_RowWithRefText(CLS.MySQLVar.TableName_DBStokDepo, "ID", UrunVerisi[0]);
                    }


                    MessageBox.Show("Çıkış İşlemi : " + Status + " - " + Status2, "İşlem Durumu", MessageBoxButtons.OK);
                }




                return "OK!";
            }
            catch (Exception HATA)
            {
                //BarkodAlaniTemizle();
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        #endregion

        #region MÜŞTERİ FİRMA ve ÇIKIŞ BİLGİLERİNİ İŞLEME

        public string Listele_MusteriAdi(ComboBox Liste)
        {
            try
            {
                // CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (true) //ONLİNE ÇALIŞMA OnlineCalismaModu
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBStokMusteri, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        item = new ComboboxItem();
                        item.Text = DTable.Rows[i][5].ToString(); //MusteriAdi
                        item.Value = DTable.Rows[i][0].ToString();
                        Liste.Items.Add(item);
                    }
                }
                else // LOCAL ÇALIŞMA
                {
                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string MusteriAdiSecildi(int Index, out string MusteriNo)
        {
            MusteriNo = "";

            try
            {
                string[] RData = new string[11];
                if (Index >= 0)
                {
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBStokMusteri, CLS.MySQLVar.ColumnName_DBStokMusteri, RData, "ID", Index.ToString());
                }


                MusteriVerisi[0] = RData[0];
                MusteriVerisi[1] = RData[1];
                MusteriVerisi[2] = RData[2];
                MusteriVerisi[3] = RData[3];
                MusteriVerisi[4] = RData[4];
                MusteriVerisi[5] = RData[5];
                MusteriVerisi[6] = RData[6];
                MusteriVerisi[7] = RData[7];
                MusteriVerisi[8] = RData[8];
                MusteriVerisi[9] = RData[9];
         

                MusteriNo = RData[4];


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string Listele_MYetkili(ComboBox Liste)
        {
            try
            {
                // CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (true) //ONLİNE ÇALIŞMA OnlineCalismaModu
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBStokMYetkili, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        string unvan = Crypto.Decrypt(DTable.Rows[i][8].ToString(), CLS.Str_StokCrypto);
                        string Ad = Crypto.Decrypt(DTable.Rows[i][7].ToString(), CLS.Str_StokCrypto);
                        item = new ComboboxItem();
                        item.Text = unvan + " - " +Ad; 
                        item.Value = DTable.Rows[i][0].ToString();
                        Liste.Items.Add(item);
                    }
                }
                else // LOCAL ÇALIŞMA
                {
                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string MYetkiliSecildi(int Index, out string YetkiliNo)
        {
            YetkiliNo = "";

            try
            {
                string[] RData = new string[13];
                if (Index >= 0)
                {
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBStokMYetkili, CLS.MySQLVar.ColumnName_DBStokMYetkili, RData, "ID", Index.ToString());
                }


                MYetkiliVerisi[0] = RData[0];
                MYetkiliVerisi[1] = RData[1];
                MYetkiliVerisi[2] = RData[2];
                MYetkiliVerisi[3] = RData[3];
                MYetkiliVerisi[4] = RData[4];
                MYetkiliVerisi[5] = RData[5];
                MYetkiliVerisi[6] = RData[6];
                MYetkiliVerisi[7] = RData[7];
                MYetkiliVerisi[8] = RData[8];
                MYetkiliVerisi[9] = RData[9];
                MYetkiliVerisi[10] = RData[10];
                MYetkiliVerisi[11] = RData[11];
                MYetkiliVerisi[12] = RData[12];

                YetkiliNo = RData[6];


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        #endregion
    }
}
