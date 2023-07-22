using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class Stok_UrunGiris
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

        public string[] UrunVerisi = new string[19];


        #region BARKOD BUL
        public string MarkayaGoreUrunleriGetir(string MarkaAdi, DataGridView DGV)
        {
            try
            {
                // Markaya ait ürünleri DGV içine listele
                if (MarkaAdi != "")
                {
                    CLS.ID_MySQL.READ_SearchRefText(CLS.MySQLVar.TableName_DBStokUrun, "MarkaAd", MarkaAdi,1, DGV);
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
               
                char Ayrim = '#';
                var SecilenUrun = ComboBoxTxt.Text.Split(Ayrim);

                for (int i = 0; i < DGV.RowCount - 1; i++)
                {
                    if (DGV.Rows[i].Cells[12].Value.ToString().Trim() == SecilenUrun[0].Trim())
                    {
                        CLS.Stok_UrunGiris.SeriNoManuelGirisSecim(true);
                        UrunVerileriniYakalaYaz(i, CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text, CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text);

                        //CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text    = CLS.Form_Main.DGV_1.Rows[i].Cells[11].Value.ToString(); 
                        CLS.Form_Main.TB_StokUrunGiris_UrunNo.Text          = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
                        CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text        = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString();
                        CLS.Form_Main.TB_StokUrunGiris_UrunAdi.Text         = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                        CLS.Form_Main.TB_StokUrunGiris_UrunAciklama.Text    = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
                        CLS.Form_Main.TB_StokUrunGiris_UrunFiyat.Text       = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString(), CLS.Str_StokCrypto);
                        CLS.Form_Main.TB_StokUrunGiris_FiyatBirim.Text      = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString(), CLS.Str_StokCrypto);
                        CLS.Form_Main.TB_StokUrunGiris_Iskonto.Text         = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString(), CLS.Str_StokCrypto);
                        break;
                    }
                }

                //StokGiris_UrunBilgileriTemizle();

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
                MarkayaGoreUrunleriGetir(MarkaAdi, CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri);
                StokGiris_UrunBilgileriTemizle();

                if (CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.RowCount > 1)
                {
                    // Markaya ait ürünleri DGV içinden okuyarak Karakter sayılarına göre barkoddan bilgileri Al
                    for (int i = 0; i < CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.RowCount - 1; i++)
                    {
                        BUL_UrunKodu(i);
                        BUL_UrunID(i, out bool UrunBulmaOK);

                        if (UrunBulmaOK)
                        {
                            break;
                        }

                    }

                }


                StokGiris_BarkodAlaniTemizle();
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
            UrunKodFirstChar = int.Parse(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[7].Value.ToString());
            UrunKodEndChar = int.Parse(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[8].Value.ToString());
            UrunKodCharAdet = UrunKodEndChar - UrunKodFirstChar;

            if (UrunKodFirstChar != 0)
            {
                Temp_UrunKodu1 = CLS.Form_Main.TB_StokUrunGiris_Barkod.Text.Remove(0, UrunKodFirstChar);
                Temp_UrunKodu2 = Temp_UrunKodu1.Remove(UrunKodCharAdet, Temp_UrunKodu1.Length - UrunKodCharAdet);
            }
            else
            {
                Temp_UrunKodu2 = CLS.Form_Main.TB_StokUrunGiris_Barkod.Text.Remove(UrunKodEndChar, CLS.Form_Main.TB_StokUrunGiris_Barkod.Text.Length - UrunKodCharAdet);
            }

        }
        void BUL_UrunID(int i, out bool UrunBulundu)
        {
            UrunBulundu = false;

            if (Temp_UrunKodu2.Trim() == CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString().Trim())
            {
                if (CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString() != "-1" && CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString() != "-1")
                {
                    UrunIDFirstChar = int.Parse(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString());
                    UrunIDEndChar = int.Parse(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString());
                    UrunIDCharAdet = UrunIDEndChar - UrunIDFirstChar;

                    Temp_UrunID1 = CLS.Form_Main.TB_StokUrunGiris_Barkod.Text.Remove(0, UrunIDFirstChar);
                    Temp_UrunID2 = Temp_UrunID1.Remove(UrunIDCharAdet, Temp_UrunID1.Length - UrunIDCharAdet);
                    SeriNoManuelGirisSecim(false);

                    UrunBulundu = true;

                }
                else
                {
                    Temp_UrunID1 = "";
                    Temp_UrunID2 = "";
                    SeriNoManuelGirisSecim(true);
                }

                UrunVerileriniYakalaYaz(i, Temp_UrunKodu2, Temp_UrunID2);

                CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text        = Temp_UrunKodu2;
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text      = Temp_UrunID2;
                CLS.Form_Main.TB_StokUrunGiris_UrunNo.Text          = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
                CLS.Form_Main.TB_StokUrunGiris_UrunAdi.Text         = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                CLS.Form_Main.TB_StokUrunGiris_UrunAciklama.Text    = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
                CLS.Form_Main.TB_StokUrunGiris_UrunFiyat.Text       = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString(), CLS.Str_StokCrypto);
                CLS.Form_Main.TB_StokUrunGiris_FiyatBirim.Text      = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString(), CLS.Str_StokCrypto);
                CLS.Form_Main.TB_StokUrunGiris_Iskonto.Text         = Crypto.Decrypt(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString(), CLS.Str_StokCrypto);

            }
        }
        public void SeriNoManuelGirisSecim(bool MANUEL)
        {
            if (MANUEL)
            {
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Clear();
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.BackColor = Color.Yellow;
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.ReadOnly = false;
            }
            else
            {
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Clear();
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.BackColor = SystemColors.Control;
                CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.ReadOnly = true;
            }

        }
        public void StokGiris_BarkodAlaniTemizle()
        {
            CLS.Form_Main.TB_StokUrunGiris_Barkod.Clear();
            CLS.Form_Main.TB_StokUrunGiris_Barkod.Focus();

            if (CLS.Form_Main.TB_StokUrunGiris_Barkod.Text != "")
            {
                CLS.Form_Main.TB_StokUrunGiris_Barkod.Clear();
            }
        }
        public void StokGiris_UrunBilgileriTemizle()
        {
            CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text      = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunNo.Text          = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunAdi.Text         = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunAciklama.Text    = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunFiyat.Text       = "";
            CLS.Form_Main.TB_StokUrunGiris_FiyatBirim.Text      = "";
            CLS.Form_Main.TB_StokUrunGiris_Iskonto.Text         = "";
            CLS.Form_Main.TB_StokUrunGiris_MevcutStok.Text      = "";
            CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text        = "";
        }
        #endregion

        void UrunVerileriniYakalaYaz(int i, string UrunKodu, string UrunID)
        {
            UrunVerisi[0] = CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[0].Value.ToString();
            UrunVerisi[1] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[1].Value.ToString();
            UrunVerisi[2] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[2].Value.ToString();
            UrunVerisi[3] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[3].Value.ToString();
            UrunVerisi[4] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[4].Value.ToString();
            UrunVerisi[5] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[5].Value.ToString();
            UrunVerisi[6] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[6].Value.ToString();
            UrunVerisi[7] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[7].Value.ToString();
            UrunVerisi[8] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[8].Value.ToString();
            UrunVerisi[9] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[9].Value.ToString();
            UrunVerisi[10] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[10].Value.ToString();
            UrunVerisi[11] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[11].Value.ToString();
            UrunVerisi[12] = UrunKodu; // CLS.Form_Main.DGV_1.Rows[i].Cells[12].Value.ToString();
            UrunVerisi[13] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
            UrunVerisi[14] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[14].Value.ToString();
            UrunVerisi[15] = UrunID;// CLS.Form_Main.DGV_1.Rows[i].Cells[15].Value.ToString();
            UrunVerisi[16] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[16].Value.ToString();
            UrunVerisi[17] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[17].Value.ToString();
            UrunVerisi[18] =  CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[18].Value.ToString();

            CLS.Stok_Sorgulama.StokAdetiHesapla(CLS.Form_Main.DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[5].Value.ToString(), UrunKodu, out string Adet);
            CLS.Form_Main.TB_StokUrunGiris_MevcutStok.Text = Adet;


        }


        #region DEPOYA URUN EKLE
        public string DepoyaUrunEkle()
        {
            try
            {

                string Baslik = "YENİ ÜRÜN DEPOYA EKLENİYOR";
                string Mesaj =  "Marka: "           + CLS.Form_Main.TB_StokUrunGiris_MarkaNo.Text       + " " + CLS.Form_Main.CB_StokUrunGiris_Marka.Text +   "\n" +
                                "Ürün No: "         + CLS.Form_Main.TB_StokUrunGiris_UrunNo.Text        + "\n" +
                                "Ürün Kodu: "       + CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text      + "\n" +
                                "Ürün Adı: "        + CLS.Form_Main.TB_StokUrunGiris_UrunAdi.Text       + "\n" +
                                "Ürün Açıklama: "   + CLS.Form_Main.TB_StokUrunGiris_UrunAciklama.Text  + "\n" +
                                "Ürün Seri No: "    + CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text    + "\n" +
                                "Ürün Fiyat: "      + CLS.Form_Main.TB_StokUrunGiris_UrunFiyat.Text     + " " + CLS.Form_Main.TB_StokUrunGiris_FiyatBirim.Text + "\n" +
                                "Ürün İskonto: %"   + CLS.Form_Main.TB_StokUrunGiris_Iskonto.Text       + "\n" +
                                "Yukarıdaki bilgilere göre yeni ürünü depoya eklemek istediğinizden emin misiniz?";

                DialogResult Soru = MessageBox.Show(Mesaj, Baslik, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if(Soru == DialogResult.OK)
                {
                    if (CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text != "")
                    {
                        //Manuel girilen seri no tanımlama
                        UrunVerisi[12] = CLS.Form_Main.TB_StokUrunGiris_UrunKodu.Text;
                        UrunVerisi[15] = CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text;
                        DepoSeriNoKontrol(CLS.Form_Main.TB_StokUrunGiris_UrunSeriNo.Text, out bool UrunOK);

                        if (UrunOK)
                        {
                            string Status = CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokDepo, CLS.MySQLVar.ColumnName_DBStokDepo, UrunVerisi, 0);

                            MessageBox.Show("Depoya ürün girişi : " + Status, "DEPOYA ÜRÜN GİRİŞİ", MessageBoxButtons.OK);

                            StokGiris_UrunBilgileriTemizle();


                        } else  { MessageBox.Show("Ürün Seri No Depoda varolan başka bir ürünle aynı gözüküyor. Seri Noları kontrol ederek tekrar deneyin.", "ÜRÜN SERİ NO HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    } else { MessageBox.Show("Ürün Seri No'su boş gözüküyor. Seri No'yu kontrol ederek tekrar deneyin.", "ÜRÜN SERİ NO HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                 
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



    }
}
