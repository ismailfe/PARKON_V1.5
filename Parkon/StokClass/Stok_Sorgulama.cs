using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class Stok_Sorgulama
    {
        public CLS CLS;
        DataSet StokAdetHesap_DSet = new DataSet();

        public string TumUrunleriGetir(DataGridView DGV)
        {
            try
            {
                DialogResult Soru = MessageBox.Show("Depodaki tüm ürünlerin listelenmesini istiyor musunuz?", "DEPODAKİ TÜM ÜRÜNLER LİSTELENECEK", MessageBoxButtons.OKCancel);

                if (Soru == DialogResult.OK)
                {
                    string Str_Cmd = "SELECT ID, KayitTarih, KayitUser, Notlar, MarkaNo, MarkaAd, Barkod, UrunNo, UrunKod, UrunAd, UrunInfo, UrunID, UrunFiyat, UrunFiyatBirim, UrunIskonto FROM " +
                                     CLS.MySQLVar.TableName_DBStokDepo;

                    string status = CLS.ID_MySQL.Open_CMD_ResultinDGV(Str_Cmd, DGV);

                    for (int i = 0; i < DGV.RowCount - 1; i++)
                    {
                        //Fiyat Çöz
                        string FiyatValue1 = DGV.Rows[i].Cells["UrunFiyat"].Value.ToString();
                        string FiyatValue2 = Crypto.Decrypt(FiyatValue1, CLS.Str_StokCrypto);
                        DGV.Rows[i].Cells["UrunFiyat"].Value = FiyatValue2;

                        //Fiyat Birim Çöz
                        string FiyatBirimValue1 = DGV.Rows[i].Cells["UrunFiyatBirim"].Value.ToString();
                        string FiyatBirimValue2 = Crypto.Decrypt(FiyatBirimValue1, CLS.Str_StokCrypto);
                        DGV.Rows[i].Cells["UrunFiyatBirim"].Value = FiyatBirimValue2;

                        //Iskonto Çöz
                        string UrunIskontoValue1 = DGV.Rows[i].Cells["UrunIskonto"].Value.ToString();
                        string UrunIskontoValue2 = Crypto.Decrypt(UrunIskontoValue1, CLS.Str_StokCrypto);
                        DGV.Rows[i].Cells["UrunIskonto"].Value = UrunIskontoValue2;
                    }
                }
               


                return "OK!";
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        public string StokAdetiHesapla(string Marka, string UrunKodu, out string Adet )
        {
            Adet = "";
            if (StokAdetHesap_DSet.Tables.Count > 0)
            {
                StokAdetHesap_DSet.Tables[0].Clear();
            }
        
            try
            { 
                //ID, KayitTarih, KayitUser, Notlar, MarkaNo, MarkaAd, Barkod, UrunNo,UrunAd, UrunInfo, UrunID, UrunFiyat, UrunFiyatBirim, UrunIskonto
                string Str_Cmd  = "SELECT  UrunKod  FROM " + CLS.MySQLVar.TableName_DBStokDepo +" WHERE UrunKod " + " Like '" + UrunKodu + "'";
                string status   = CLS.ID_MySQL.Open_CMD_ResultinDGV(Str_Cmd, null, StokAdetHesap_DSet);
                Adet = StokAdetHesap_DSet.Tables[0].Rows.Count.ToString();
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        public string UrunBul(string Marka, string UrunKodu, DataGridView DGV, out string Adet )
        {
            Adet = "";
            try
            {
                string Str_Cmd = "SELECT ID, KayitTarih, KayitUser, Notlar, MarkaNo, MarkaAd, Barkod, UrunNo, UrunKod, UrunAd, UrunInfo, UrunID, UrunFiyat, UrunFiyatBirim, UrunIskonto FROM " +
                CLS.MySQLVar.TableName_DBStokDepo +
                 " WHERE UrunKod " + " Like '" + UrunKodu + "'";

                string status = CLS.ID_MySQL.Open_CMD_ResultinDGV(Str_Cmd, DGV);

                if ((DGV.RowCount - 1).ToString() == "-1")
                {
                    Adet = "0";
                }
                else
                {
                    Adet = (DGV.RowCount - 1).ToString();
                }

                for (int i = 0; i < DGV.RowCount - 1; i++)
                {
                    //Fiyat Çöz
                    string FiyatValue1 = DGV.Rows[i].Cells["UrunFiyat"].Value.ToString();
                    string FiyatValue2 = Crypto.Decrypt(FiyatValue1, CLS.Str_StokCrypto);
                    DGV.Rows[i].Cells["UrunFiyat"].Value = FiyatValue2;

                    //Fiyat Birim Çöz
                    string FiyatBirimValue1 = DGV.Rows[i].Cells["UrunFiyatBirim"].Value.ToString();
                    string FiyatBirimValue2 = Crypto.Decrypt(FiyatBirimValue1, CLS.Str_StokCrypto);
                    DGV.Rows[i].Cells["UrunFiyatBirim"].Value = FiyatBirimValue2;

                    //Iskonto Çöz
                    string UrunIskontoValue1 = DGV.Rows[i].Cells["UrunIskonto"].Value.ToString();
                    string UrunIskontoValue2 = Crypto.Decrypt(UrunIskontoValue1, CLS.Str_StokCrypto);
                    DGV.Rows[i].Cells["UrunIskonto"].Value = UrunIskontoValue2;
                }


                return "OK!";
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

    }
}
