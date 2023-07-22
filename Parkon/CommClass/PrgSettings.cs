using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Parkon
{
   public class PrgSettings
    {
        public CLS CLS;
        public class INIKaydet
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            //public INIKaydet(string dosyaYolu)
            //{
            //    DOSYAYOLU = dosyaYolu;
            //}
            private string DOSYAYOLU = String.Empty;
            public string Varsayilan { get; set; }
            public string Oku(string bolum, string ayaradi,string FilePath)
            {
                Varsayilan = Varsayilan ?? String.Empty;
                StringBuilder StrBuild = new StringBuilder(256);
                GetPrivateProfileString(bolum, ayaradi, Varsayilan, StrBuild, 512, FilePath);
                return StrBuild.ToString();
            }
            public long Yaz(string bolum, string ayaradi, string deger, string FilePath)
            {
                return WritePrivateProfileString(bolum, ayaradi, deger, FilePath);
            }
        }

        INIKaydet INI               = new INIKaydet();
        string INI_Grup             = "Main";

        public void KAYDET_SistemAyarlari()
        {
            try
            {
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_HerZamanUstte", CLS.Form_Main.CHB_HerZamanUstte.Checked.ToString(), CLS.Settings_Path);
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_BildirimENB", CLS.Form_Main.CHB_BildirimENB.Checked.ToString(), CLS.Settings_Path);
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
        }
        public string YUKLE_SistemAyarlari()
        {
            try
            {
                if (File.Exists(CLS.Settings_Path))
                {
                    CLS.Form_Main.CHB_HerZamanUstte.Checked = Boolean.Parse(INI.Oku(INI_Grup, "CLS.Form_Main.CHB_HerZamanUstte",CLS.Settings_Path));
                    CLS.Form_Main.CHB_BildirimENB.Checked = Boolean.Parse(INI.Oku(INI_Grup, "CLS.Form_Main.CHB_BildirimENB", CLS.Settings_Path));
                    return "OK!";
                }else
                {
                    return "Settings dosyası bulunamadı!";
                }
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }

        }
        public void KAYDET_AnaDizin()
        {
            try
            {
                INI.Yaz(INI_Grup, "CLS.Form_Main.TB_SecilenAnaDizin", CLS.Form_Main.TB_SecilenAnaDizin.Text, CLS.Settings_Path);
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
            }

        }
        public string YUKLE_AnaDizin()
        {
            try
            {
                if (File.Exists(CLS.ProgramData_Path + "Settings.ini"))
                {
                CLS.Form_Main.TB_SecilenAnaDizin.Text = INI.Oku(INI_Grup, "CLS.Form_Main.TB_SecilenAnaDizin", CLS.Settings_Path);
                return "OK!";
                }
                else
                {
                    return "Settings dosyası bulunamadı!";
                }
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }

        }
        public string KAYDET_DBGuncellemeSonTarih()
        {
            try
            {
                INI.Yaz(INI_Grup, "CLS.Form_Main.toolStripL_LocalDataUpdate", DateTime.Now.ToString(), CLS.UpdateDate_Path);

                return "OK!";
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }

        }
        public string YUKLE_DBGuncellemeSonTarih()
        {
            try
            {
                CLS.Form_Main.TB_LocalDataUpdate.Text = INI.Oku(INI_Grup, "CLS.Form_Main.toolStripL_LocalDataUpdate", CLS.UpdateDate_Path);
                return "OK!";
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }

        }

        #region KULLANICI GİRİŞİ - BENI HATIRLA
        public void KAYDET_BeniHatirla()
        {
            try
            {
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMe", CLS.Form_Main.user_Login1.XID_CHB_BENIHATIRLA.Checked.ToString(), CLS.RemMe_Path);
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt1", Crypto.Encrypt(CLS.Form_Main.user_Login1.XID_CB_USERNAME.Text, "xxx"), CLS.RemMe_Path);
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt2", Crypto.Encrypt(CLS.Form_Main.user_Login1.XID_TB_PASSWORD.Text, "xxx"), CLS.RemMe_Path);
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }


        }
        public void KAYDET_BeniUnut()
        {
            try
            {
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMe", "false", CLS.RemMe_Path);
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt1", "", CLS.RemMe_Path);
                INI.Yaz(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt2", "", CLS.RemMe_Path);
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
        }

        string tx1 = "";
        string tx2 = "";
        public string YUKLE_BeniHatirla()
        {
            try
            {
                if (File.Exists(CLS.ProgramData_Path + "RemMe.ini"))
                {
                    CLS.Form_Main.user_Login1.XID_CHB_BENIHATIRLA.Checked = Boolean.Parse(INI.Oku(INI_Grup, "CLS.Form_Main.CHB_RemMe", CLS.RemMe_Path));

                    if (CLS.Form_Main.user_Login1.XID_CHB_BENIHATIRLA.Checked)
                    {
                        string txt1 = INI.Oku(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt1", CLS.RemMe_Path);
                        string txt2 = INI.Oku(INI_Grup, "CLS.Form_Main.CHB_RemMeTxt2", CLS.RemMe_Path);
                        if (txt1 != "") { tx1 = Crypto.Decrypt(txt1, "xxx"); }
                        if (txt2 != "") { tx2 = Crypto.Decrypt(txt2, "xxx"); }
                        CLS.UserLogin.Listele_UserName(CLS.Form_Main.user_Login1.XID_CB_USERNAME);
                        CLS.Form_Main.user_Login1.XID_TB_PASSWORD.Text = "";

                        CLS.Form_Main.user_Login1.XID_CB_USERNAME.Text = tx1;
                        CLS.Form_Main.user_Login1.XID_TB_PASSWORD.Text = tx2;
                    }
                    else
                    {
                        KAYDET_BeniUnut();
                    }

                    return "OK!";
                }
                else
                {
                    return "RemMe dosyası bulunamadı!";
                }
              


            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }
          
        }

        #endregion

    }
}
