using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parkon
{
    public class MySQLVar
    {
        #region PUBLIC VARIABLE
        public CLS CLS;

        public string TableName_DBMusteri                   = "DBMusteri";
        public string TableName_DBMusteriBolum              = "DBMusteriBolum";
        public string TableName_DBMYetkili                  = "DBMYetkili";
        public string TableName_DBProje                     = "DBProje";
        public string TableName_DBRev                       = "DBRev";
        public string TableName_DBAksiyon                   = "DBAksiyon";
        public string TableName_DBUser                      = "DBUser";
        public string TableName_DBParkon                    = "DBParkon";

        public string[] ColumnName_DBMusteri                = new string[10];
        public string[] ColumnName_DBMusteriBolum           = new string[8];
        public string[] ColumnName_DBMYetkili               = new string[13];
        public string[] ColumnName_DBProje                  = new string[21];
        public string[] ColumnName_DBRev                    = new string[26];
        public string[] ColumnName_DBAksiyon                = new string[22];
        public string[] ColumnName_DBUser                   = new string[17];
        public string[] ColumnName_DBParkon                 = new string[9];

        //--- STOK YÖNETİMİ ---//
        public string TableName_DBStokMarka             = "DBStokMarka";
        public string TableName_DBStokUrun              = "DBStokUrun";
        public string TableName_DBStokDepo              = "DBStokDepo";
        public string TableName_DBStokCikis             = "DBStokCikis";
        public string TableName_DBStokMusteri           = "DBStokMusteri";
        public string TableName_DBStokMusteriBolum      = "DBStokMusteriBolum";
        public string TableName_DBStokMYetkili          = "DBStokMYetkili";

        public string[] ColumnName_DBStokMarka          = new string[6];
        public string[] ColumnName_DBStokUrun           = new string[19];
        public string[] ColumnName_DBStokDepo           = new string[19];
        public string[] ColumnName_DBStokCikis          = new string[34];
        public string[] ColumnName_DBStokMusteri        = new string[10];
        public string[] ColumnName_DBStokMusteriBolum   = new string[8];
        public string[] ColumnName_DBStokMYetkili       = new string[13];
        //-------------------//

        #endregion
        public string FirstStart()
        {
            return ColumnName_Write();
        }


        string ColumnName_Write()
        {
            try
            {
                ColumnName_DBMusteri[0] = "ID";
                ColumnName_DBMusteri[1] = "KayitTarih";
                ColumnName_DBMusteri[2] = "KayitUser";
                ColumnName_DBMusteri[3] = "Notlar";
                ColumnName_DBMusteri[4] = "MusteriNo";
                ColumnName_DBMusteri[5] = "MusteriAdi";
                ColumnName_DBMusteri[6] = "MusteriBolge";
                ColumnName_DBMusteri[7] = "MusteriAdres";
                ColumnName_DBMusteri[8] = "MapsLink";
                ColumnName_DBMusteri[9] = "MusteriTel";

                ColumnName_DBMusteriBolum[0] = "ID";
                ColumnName_DBMusteriBolum[1] = "KayitTarih";
                ColumnName_DBMusteriBolum[2] = "KayitUser";
                ColumnName_DBMusteriBolum[3] = "Notlar";
                ColumnName_DBMusteriBolum[4] = "MusteriNo";
                ColumnName_DBMusteriBolum[5] = "MusteriAdi";
                ColumnName_DBMusteriBolum[6] = "BolumNo";
                ColumnName_DBMusteriBolum[7] = "BolumAdi";

                ColumnName_DBMYetkili[0] = "ID";
                ColumnName_DBMYetkili[1] = "KayitTarih";
                ColumnName_DBMYetkili[2] = "KayitUser";
                ColumnName_DBMYetkili[3] = "Notlar";
                ColumnName_DBMYetkili[4] = "MusteriNo";
                ColumnName_DBMYetkili[5] = "MusteriAdi";
                ColumnName_DBMYetkili[6] = "MYetkiliNo";
                ColumnName_DBMYetkili[7] = "MYetkiliAdi";
                ColumnName_DBMYetkili[8] = "MYetkiliTitle";
                ColumnName_DBMYetkili[9] = "MYetkiliTel";
                ColumnName_DBMYetkili[10] = "MYetkiliTel2";
                ColumnName_DBMYetkili[11] = "MYetkiliMail";
                ColumnName_DBMYetkili[12] = "MYetkiliInfo";

                ColumnName_DBProje[0] = "ID";
                ColumnName_DBProje[1] = "KayitTarih";
                ColumnName_DBProje[2] = "KayitUser";
                ColumnName_DBProje[3] = "Notlar";
                ColumnName_DBProje[4] = "MusteriNo";
                ColumnName_DBProje[5] = "MusteriAdi";
                ColumnName_DBProje[6] = "BolumNo";
                ColumnName_DBProje[7] = "BolumAdi";
                ColumnName_DBProje[8] = "ProjeNo";
                ColumnName_DBProje[9] = "ProjeKodu";
                ColumnName_DBProje[10] = "ProjeAdi";
                ColumnName_DBProje[11] = "ProjeBaslamaTarih";
                ColumnName_DBProje[12] = "ProjeDonemAy";
                ColumnName_DBProje[13] = "ProjeDonemYil";
                ColumnName_DBProje[14] = "MYetkiliNo";
                ColumnName_DBProje[15] = "MYetkiliAdi";
                ColumnName_DBProje[16] = "MYetkiliTitle";
                ColumnName_DBProje[17] = "MYetkiliTel";
                ColumnName_DBProje[18] = "MYetkiliTel2";
                ColumnName_DBProje[19] = "MYetkiliMail";
                ColumnName_DBProje[20] = "MYetkiliInfo";

                ColumnName_DBRev[0] = "ID";
                ColumnName_DBRev[1] = "KayitTarih";
                ColumnName_DBRev[2] = "KayitUser";
                ColumnName_DBRev[3] = "Notlar";
                ColumnName_DBRev[4] = "MusteriNo";
                ColumnName_DBRev[5] = "MusteriAdi";
                ColumnName_DBRev[6] = "BolumNo";
                ColumnName_DBRev[7] = "BolumAdi";
                ColumnName_DBRev[8] = "ProjeNo";
                ColumnName_DBRev[9] = "ProjeKodu";
                ColumnName_DBRev[10] = "ProjeAdi";
                ColumnName_DBRev[11] = "ProjeBaslamaTarih";
                ColumnName_DBRev[12] = "ProjeDonemAy";
                ColumnName_DBRev[13] = "ProjeDonemYil";
                ColumnName_DBRev[14] = "MYetkiliNo";
                ColumnName_DBRev[15] = "MYetkiliAdi";
                ColumnName_DBRev[16] = "MYetkiliTitle";
                ColumnName_DBRev[17] = "MYetkiliTel";
                ColumnName_DBRev[18] = "MYetkiliTel2";
                ColumnName_DBRev[19] = "MYetkiliMail";
                ColumnName_DBRev[20] = "MYetkiliInfo";
                ColumnName_DBRev[21] = "RevBaslamaTarih";
                ColumnName_DBRev[22] = "RevDonemAy";
                ColumnName_DBRev[23] = "RevDonemYil";
                ColumnName_DBRev[24] = "RevNo";
                ColumnName_DBRev[25] = "RevAdi";

                ColumnName_DBAksiyon[0] = "ID";
                ColumnName_DBAksiyon[1] = "KayitTarih";
                ColumnName_DBAksiyon[2] = "KayitUser";
                ColumnName_DBAksiyon[3] = "Notlar";
                ColumnName_DBAksiyon[4] = "MusteriNo";
                ColumnName_DBAksiyon[5] = "MusteriAdi";
                ColumnName_DBAksiyon[6] = "BolumNo";
                ColumnName_DBAksiyon[7] = "BolumAdi";
                ColumnName_DBAksiyon[8] = "ProjeNo";
                ColumnName_DBAksiyon[9] = "ProjeAdi";
                ColumnName_DBAksiyon[10] = "IslemBaslamaTarih";
                ColumnName_DBAksiyon[11] = "IslemBitirmeTarih";
                ColumnName_DBAksiyon[12] = "Islem";
                ColumnName_DBAksiyon[13] = "Aciklama";
                ColumnName_DBAksiyon[14] = "Sorumlu";
                ColumnName_DBAksiyon[15] = "MYetkiliNo";
                ColumnName_DBAksiyon[16] = "MYetkiliAdi";
                ColumnName_DBAksiyon[17] = "MYetkiliTitle";
                ColumnName_DBAksiyon[18] = "MYetkiliTel";
                ColumnName_DBAksiyon[19] = "MYetkiliTel2";
                ColumnName_DBAksiyon[20] = "MYetkiliMail";
                ColumnName_DBAksiyon[21] = "MYetkiliInfo";

                ColumnName_DBUser[0] = "ID";
                ColumnName_DBUser[1] = "KayitTarih";
                ColumnName_DBUser[2] = "KayitUser";
                ColumnName_DBUser[3] = "Notlar";
                ColumnName_DBUser[4] = "UserNo";
                ColumnName_DBUser[5] = "UserPic";
                ColumnName_DBUser[6] = "UserName";
                ColumnName_DBUser[7] = "UserPass";
                ColumnName_DBUser[8] = "UserLevel";
                ColumnName_DBUser[9] = "UserAd";
                ColumnName_DBUser[10] = "UserTitle";
                ColumnName_DBUser[11] = "UserBolum";
                ColumnName_DBUser[12] = "UserTel";
                ColumnName_DBUser[13] = "UserTel2";
                ColumnName_DBUser[14] = "UserMail";
                ColumnName_DBUser[15] = "UserDTarih";
                ColumnName_DBUser[16] = "UserKan";
                
                ColumnName_DBParkon[0] = "ID";
                ColumnName_DBParkon[1] = "KayitTarih";
                ColumnName_DBParkon[2] = "KayitUser";
                ColumnName_DBParkon[3] = "Notlar";
                ColumnName_DBParkon[4] = "VerNew";
                ColumnName_DBParkon[5] = "VerNo";
                ColumnName_DBParkon[6] = "Yenilikler";
                ColumnName_DBParkon[7] = "VerTitle";
                ColumnName_DBParkon[8] = "VerComment";
    
                // ------- STOK YÖNETİMİ -------- //
                ColumnName_DBStokMarka[0] = "ID";
                ColumnName_DBStokMarka[1] = "KayitTarih";
                ColumnName_DBStokMarka[2] = "KayitUser";
                ColumnName_DBStokMarka[3] = "Notlar";
                ColumnName_DBStokMarka[4] = "MarkaNo";
                ColumnName_DBStokMarka[5] = "MarkaAd";

                ColumnName_DBStokUrun[0] = "ID";
                ColumnName_DBStokUrun[1] = "KayitTarih";
                ColumnName_DBStokUrun[2] = "KayitUser";
                ColumnName_DBStokUrun[3] = "Notlar";
                ColumnName_DBStokUrun[4] = "MarkaNo";
                ColumnName_DBStokUrun[5] = "MarkaAd";
                ColumnName_DBStokUrun[6] = "Barkod";
                ColumnName_DBStokUrun[7] = "UrunKodFirstChar";
                ColumnName_DBStokUrun[8] = "UrunKodEndChar";
                ColumnName_DBStokUrun[9] = "UrunIDFirstChar";
                ColumnName_DBStokUrun[10] = "UrunIDEndChar";
                ColumnName_DBStokUrun[11] = "UrunNo";
                ColumnName_DBStokUrun[12] = "UrunKod";
                ColumnName_DBStokUrun[13] = "UrunAd";
                ColumnName_DBStokUrun[14] = "UrunInfo";
                ColumnName_DBStokUrun[15] = "UrunID";
                ColumnName_DBStokUrun[16] = "UrunFiyat";
                ColumnName_DBStokUrun[17] = "UrunFiyatBirim";
                ColumnName_DBStokUrun[18] = "UrunIskonto";

                ColumnName_DBStokDepo[0] = "ID";
                ColumnName_DBStokDepo[1] = "KayitTarih";
                ColumnName_DBStokDepo[2] = "KayitUser";
                ColumnName_DBStokDepo[3] = "Notlar";
                ColumnName_DBStokDepo[4] = "MarkaNo";
                ColumnName_DBStokDepo[5] = "MarkaAd";
                ColumnName_DBStokDepo[6] = "Barkod";
                ColumnName_DBStokDepo[7] = "UrunKodFirstChar";
                ColumnName_DBStokDepo[8] = "UrunKodEndChar";
                ColumnName_DBStokDepo[9] = "UrunIDFirstChar";
                ColumnName_DBStokDepo[10] = "UrunIDEndChar";
                ColumnName_DBStokDepo[11] = "UrunNo";
                ColumnName_DBStokDepo[12] = "UrunKod";
                ColumnName_DBStokDepo[13] = "UrunAd";
                ColumnName_DBStokDepo[14] = "UrunInfo";
                ColumnName_DBStokDepo[15] = "UrunID";
                ColumnName_DBStokDepo[16] = "UrunFiyat";
                ColumnName_DBStokDepo[17] = "UrunFiyatBirim";
                ColumnName_DBStokDepo[18] = "UrunIskonto";

                ColumnName_DBStokCikis[0] = "ID";
                ColumnName_DBStokCikis[1] = "KayitTarih";
                ColumnName_DBStokCikis[2] = "KayitUser";
                ColumnName_DBStokCikis[3] = "Notlar";
                ColumnName_DBStokCikis[4] = "MarkaNo";
                ColumnName_DBStokCikis[5] = "MarkaAd";
                ColumnName_DBStokCikis[6] = "Barkod";
                ColumnName_DBStokCikis[7] = "UrunKodFirstChar";
                ColumnName_DBStokCikis[8] = "UrunKodEndChar";
                ColumnName_DBStokCikis[9] = "UrunIDFirstChar";
                ColumnName_DBStokCikis[10] = "UrunIDEndChar";
                ColumnName_DBStokCikis[11] = "UrunNo";
                ColumnName_DBStokCikis[12] = "UrunKod";
                ColumnName_DBStokCikis[13] = "UrunAd";
                ColumnName_DBStokCikis[14] = "UrunInfo";
                ColumnName_DBStokCikis[15] = "UrunID";
                ColumnName_DBStokCikis[16] = "UrunFiyat";
                ColumnName_DBStokCikis[17] = "UrunFiyatBirim";
                ColumnName_DBStokCikis[18] = "UrunIskonto";
                ColumnName_DBStokCikis[19] = "MusteriNo";
                ColumnName_DBStokCikis[20] = "MusteriAdi";
                ColumnName_DBStokCikis[21] = "MYetkiliNo";
                ColumnName_DBStokCikis[22] = "MYetkiliAdi";
                ColumnName_DBStokCikis[23] = "MYetkiliTitle";
                ColumnName_DBStokCikis[24] = "MYetkiliTel";
                ColumnName_DBStokCikis[25] = "MYetkiliTel2";
                ColumnName_DBStokCikis[26] = "MYetkiliMail";
                ColumnName_DBStokCikis[27] = "MYetkiliInfo";
                ColumnName_DBStokCikis[28] = "CikisAksiyon";
                ColumnName_DBStokCikis[29] = "CikisEkAciklama";
                ColumnName_DBStokCikis[30] = "FaturaNo";
                ColumnName_DBStokCikis[31] = "IrsaliyeNo";
                ColumnName_DBStokCikis[32] = "KargoNo";
                ColumnName_DBStokCikis[33] = "CikisKodu";

                ColumnName_DBStokMusteri[0] = "ID";
                ColumnName_DBStokMusteri[1] = "KayitTarih";
                ColumnName_DBStokMusteri[2] = "KayitUser";
                ColumnName_DBStokMusteri[3] = "Notlar";
                ColumnName_DBStokMusteri[4] = "MusteriNo";
                ColumnName_DBStokMusteri[5] = "MusteriAdi";
                ColumnName_DBStokMusteri[6] = "MusteriBolge";
                ColumnName_DBStokMusteri[7] = "MusteriAdres";
                ColumnName_DBStokMusteri[8] = "MapsLink";
                ColumnName_DBStokMusteri[9] = "MusteriTel";

                ColumnName_DBStokMusteriBolum[0] = "ID";
                ColumnName_DBStokMusteriBolum[1] = "KayitTarih";
                ColumnName_DBStokMusteriBolum[2] = "KayitUser";
                ColumnName_DBStokMusteriBolum[3] = "Notlar";
                ColumnName_DBStokMusteriBolum[4] = "MusteriNo";
                ColumnName_DBStokMusteriBolum[5] = "MusteriAdi";
                ColumnName_DBStokMusteriBolum[6] = "BolumNo";
                ColumnName_DBStokMusteriBolum[7] = "BolumAdi";

                ColumnName_DBStokMYetkili[0] = "ID";
                ColumnName_DBStokMYetkili[1] = "KayitTarih";
                ColumnName_DBStokMYetkili[2] = "KayitUser";
                ColumnName_DBStokMYetkili[3] = "Notlar";
                ColumnName_DBStokMYetkili[4] = "MusteriNo";
                ColumnName_DBStokMYetkili[5] = "MusteriAdi";
                ColumnName_DBStokMYetkili[6] = "MYetkiliNo";
                ColumnName_DBStokMYetkili[7] = "MYetkiliAdi";
                ColumnName_DBStokMYetkili[8] = "MYetkiliTitle";
                ColumnName_DBStokMYetkili[9] = "MYetkiliTel";
                ColumnName_DBStokMYetkili[10] = "MYetkiliTel2";
                ColumnName_DBStokMYetkili[11] = "MYetkiliMail";
                ColumnName_DBStokMYetkili[12] = "MYetkiliInfo";
                // -------------------------------- //

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }
         

        }




    }
}
