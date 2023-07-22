using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class Stok_SorgulamaCikis
    {
        public CLS CLS;

        public string TumUrunleriGetir(DataGridView DGV)
        {
            try
            {
                DialogResult Soru = MessageBox.Show("Depodan çıkış yapılan ürünlerin listelenmesini istiyor musunuz?", "ÇIKIŞI YAPILAN TÜM ÜRÜNLER LİSTELENECEK", MessageBoxButtons.OKCancel);

                if (Soru == DialogResult.OK)
                {
                    string Str_Cmd = "SELECT ID, KayitTarih, KayitUser, Notlar, MarkaNo, MarkaAd, Barkod, UrunNo, UrunKod, UrunAd, UrunInfo, UrunID, UrunFiyat, UrunFiyatBirim, UrunIskonto, " +
                        "MusteriNo,	MusteriAdi,	MYetkiliNo,	MYetkiliAdi, MYetkiliTitle,	MYetkiliTel	MYetkiliTel2, MYetkiliMail,	MYetkiliInfo, CikisAksiyon,CikisEkAciklama,FaturaNo, IrsaliyeNo, KargoNo, CikisKodu " +
                        "FROM " +  CLS.MySQLVar.TableName_DBStokCikis;

                    string status = CLS.ID_MySQL.Open_CMD_ResultinDGV(Str_Cmd, DGV);

                    for (int i = 0; i < DGV.RowCount - 1; i++)
                    {
                        //Fiyat Çöz
                        CLS.Coz(i, "UrunFiyat", DGV);

                        //Fiyat Birim Çöz
                        CLS.Coz(i, "UrunFiyatBirim", DGV);

                        //Iskonto Çöz
                        CLS.Coz(i, "UrunIskonto", DGV);

                        //YetkiliAdı Çöz
                        CLS.Coz(i, "MYetkiliAdi", DGV);

                        //YetkiliTitle Çöz
                        CLS.Coz(i, "MYetkiliTitle", DGV);

                        //YetkiliTel Çöz
                        CLS.Coz(i, "MYetkiliTel", DGV);

                        //YetkiliTel2 Çöz
                        CLS.Coz(i, "MYetkiliTel2", DGV);

                        //YetkiliMail Çöz
                        CLS.Coz(i, "MYetkiliMail", DGV);

                        //YetkiliInfo Çöz
                        CLS.Coz(i, "MYetkiliInfo", DGV);

                        //CikisAksiyon Çöz
                        CLS.Coz(i, "CikisAksiyon", DGV);

                        //CikisEkAciklama Çöz
                        CLS.Coz(i, "CikisEkAciklama", DGV);

                        //FaturaNo Çöz
                        CLS.Coz(i, "FaturaNo", DGV);

                        //IrsaliyeNo Çöz
                        CLS.Coz(i, "IrsaliyeNo", DGV);

                        //KargoNo Çöz
                        CLS.Coz(i, "KargoNo", DGV);

                        //CikisNo Çöz
                        CLS.Coz(i, "CikisNo", DGV);

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





    }
}
