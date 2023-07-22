using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class UserLogin
    {
        public CLS CLS;
        public bool KullaniciGirisBasarili;
        public bool KullaniciCikisBasarili;
        public string FirstStart()
        {
            try
            {

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        ComboBox CBSecilenUserID = new ComboBox();
       // ListBox LBox_SecilenUserID = new ListBox();
        public string Listele_UserName(ComboBox Liste)
        {
            Liste.Items.Clear();
            try
            {
                DataTable DTable = new DataTable();
                CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBUser, null, DTable);
                ComboboxItem item;

                for (int i = 0; i < DTable.Rows.Count; i++)
                {
                    item = new ComboboxItem();

                    string txtOpn = DTable.Rows[i][6].ToString();
                    string txt = Crypto.Decrypt(txtOpn, "xxx");
                    item.Text = txt;
                    item.Value = DTable.Rows[i][0].ToString();
                    Liste.Items.Add(item);
                }


                //ListBox LBox = new ListBox();
                //ListBox LBoxID = new ListBox();
                //CLS.ID_MySQL.READ_SelectColumn(CLS.MySQLVar.TableName_DBUser, "UserName", LBox);
                //CLS.ID_MySQL.READ_SelectColumn(CLS.MySQLVar.TableName_DBUser, "ID", LBoxID);
                //Liste.Items.Clear();

                //for (int i = 0; i < LBox.Items.Count; i++)
                //{
                //    string txtOpn = LBox.Items[i].ToString();
                //    string txt = Crypto.Decrypt(txtOpn, "xxx");
                //    Liste.Items.Add(txt);
                //    CBSecilenUserID.Items.Add(LBoxID.Items[i].ToString());


                //}

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        public string KullaniciNoSorgula(out string SiradakiKullaniciNo)
        {
            SiradakiKullaniciNo = "";
            try
            {
                string[] refColumnName = new string[1];
                string[] refValue = new string[1];

                refColumnName[0] = "";
                refValue[0] = "";

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBUser, "UserNo", false, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    SiradakiKullaniciNo = "0" + LastNumber;
                }else
                {
                    SiradakiKullaniciNo = LastNumber;
                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string YeniKullaniciOlustur(string UsrNot, string UsrName, string UsrPass, string UsrLevel, string UsrAd, string UsrTitle,
                                           string UsrBolum, string UsrTel, string UsrTel2, string UsrMail, string UsrDTarih, string UsrKan)
        {

            try
            {
                string UserNo = "";
                string[] WriteData = new string[17];

                string[] refColumnName = new string[1];
                string[] refValue = new string[1];

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBUser, "UserNo", false, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    UserNo = "0" + LastNumber;
                }
                else
                {
                    UserNo = LastNumber;
                }





                WriteData[0] = ""; // ID Primary Key
                WriteData[1] = DateTime.Now.ToString();
                WriteData[2] = CLS.Form_Main.LB_UserName.Text;
                WriteData[3] = UsrNot;
                WriteData[4] = UserNo;
                WriteData[5] = "";
                WriteData[6] = UsrName;
                WriteData[7] = UsrPass;
                WriteData[8] = UsrLevel;
                WriteData[9] = UsrAd;
                WriteData[10] = UsrTitle;
                WriteData[11] = UsrBolum;
                WriteData[12] = UsrTel;
                WriteData[13] = UsrTel2;
                WriteData[14] = UsrMail;
                WriteData[15] = UsrDTarih;
                WriteData[16] = UsrKan;



                CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBUser, CLS.MySQLVar.ColumnName_DBUser, WriteData, 0);

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        public string SifreKarsilastir(int UserNameIndex, string UserName, string Pass, string[] KullaniciBilgileri, PictureBox UserPic)
        {

            try
            {
                string[] RData = new string[17];

                int KullaniciAdiIndex = UserNameIndex; /// CmbIdxFindByValue(UserName, CLS.Form_Main.CB_User_SecUserName);

                CLS.ID_MySQL.READ_SelectRowIndex(CLS.MySQLVar.TableName_DBUser, CLS.MySQLVar.ColumnName_DBUser, RData, KullaniciAdiIndex);


                string RefColumn = "UserName";
                string RefText = Crypto.Encrypt(UserName, "xxx").Trim();
                CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBUser, CLS.MySQLVar.ColumnName_DBUser, RData, RefColumn, RefText);

                string SecilenKullaniciSifre = Crypto.Decrypt(RData[7].ToString(), "xxx");

                if (SecilenKullaniciSifre == Pass)
                {

                    KullaniciGirisBasarili = true;
                    //  KullaniciBilgileri;// = new string[17];

                    KullaniciBilgileri[0] = RData[0];
                    KullaniciBilgileri[1] = RData[1];
                    KullaniciBilgileri[2] = RData[2];
                    KullaniciBilgileri[3] = RData[3];
                    KullaniciBilgileri[4] = RData[4];
                    KullaniciBilgileri[5] = RData[5];
                    KullaniciBilgileri[6] = Crypto.Decrypt(RData[6].ToString(), "xxx");
                    KullaniciBilgileri[7] = Crypto.Decrypt(RData[7].ToString(), "xxx");
                    KullaniciBilgileri[8] = RData[8];
                    KullaniciBilgileri[9] = RData[9];
                    KullaniciBilgileri[10] = Crypto.Decrypt(RData[10].ToString(), "xxx");
                    KullaniciBilgileri[11] = Crypto.Decrypt(RData[11].ToString(), "xxx");
                    KullaniciBilgileri[12] = Crypto.Decrypt(RData[12].ToString(), "xxx");
                    KullaniciBilgileri[13] = Crypto.Decrypt(RData[13].ToString(), "xxx");
                    KullaniciBilgileri[14] = Crypto.Decrypt(RData[14].ToString(), "xxx");
                    KullaniciBilgileri[15] = Crypto.Decrypt(RData[15].ToString(), "xxx");
                    KullaniciBilgileri[16] = RData[16];



                    CLS.ID_MySQL.READ_ImageFormMySQL(CLS.MySQLVar.TableName_DBUser, "UserPic", UserPic, "ID", RData[0].ToString());
                    //byte img = (byte)RData[5].ToString();
                    //MemoryStream ms = new MemoryStream(img);
                    //pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    KullaniciGirisBasarili = false;
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }



        }

        //int usernameindex;
        public string KullaniciGiris()
        {
            string[] UsrInfo = new string[17];
            if (CLS.Form_Main.user_Login1.XID_CB_USERNAME.Text != "" && CLS.Form_Main.user_Login1.XID_TB_PASSWORD.Text != "")
            {
                CLS.UserLogin.SifreKarsilastir(CLS.Form_Main.user_Login1.XID_CB_USERNAME.SelectedIndex, CLS.Form_Main.user_Login1.XID_CB_USERNAME.Text, CLS.Form_Main.user_Login1.XID_TB_PASSWORD.Text, UsrInfo, CLS.Form_Main.Pic_User);

                if (KullaniciGirisBasarili)
                {
                    CLS.Form_Main.user_Login1.GirisBasarili();
                    CLS.Bildirimler.SelamMesaji();
                    CLS.Form_Main.Panel_UserInfo.Visible    = true;
                    CLS.Form_Main.B_KullaniciOturum.Text    = "Oturum Kapat";
                    CLS.Form_Main.TB_User_ID.Text           = UsrInfo[0];
                    CLS.Form_Main.TB_User_UserNo.Text       = UsrInfo[4];
                    CLS.Form_Main.TB_User_UserLevel.Text    = UsrInfo[8];
                    CLS.Form_Main.LB_UserName.Text          = UsrInfo[9];
                    CLS.Form_Main.TB_User_Unvan.Text        = UsrInfo[10];
                    CLS.Form_Main.TB_User_Bolum.Text        = UsrInfo[11];
                    CLS.Form_Main.TB_User_Tel1.Text         = UsrInfo[12];
                    CLS.Form_Main.TB_User_Tel2.Text         = UsrInfo[13];
                    CLS.Form_Main.TB_User_Mail.Text         = UsrInfo[14];
                    CLS.Form_Main.TB_User_DogumTarih.Text   = UsrInfo[15];
                    CLS.Form_Main.TB_User_KanGrubu.Text     = UsrInfo[16];

                    if (CLS.Form_Main.user_Login1.XID_CHB_BENIHATIRLA.Checked)
                    {
                        CLS.PrgSettings.KAYDET_BeniHatirla();
                    }else
                    {
                        CLS.PrgSettings.KAYDET_BeniUnut();
                    }

                    if (CLS.Form_Main.LB_UserName.Text == "Ismail Demir")
                    {
                        CLS.Form_Main.B_YeniUserEkle.Enabled = true;
                    }else
                    {
                        CLS.Form_Main.B_YeniUserEkle.Enabled = false;
                    }

                    CLS.Form_Main.CB_KullaniciModu.SelectedIndex = 2;
                    return "OK!";
                }
                else
                {
                    CLS.Form_Main.user_Login1.GirisHata_Password();
                    CLS.PrgSettings.KAYDET_BeniUnut();
                    return "Hatalı şifre ya da kullanıcı adı!";
                }

            }
            else
            {
                return "Giris yapılamadı!";
            }
        }

        public void KullaniciCikis()
        {
            KullaniciGirisBasarili = false;
            CLS.CreateProject.Temizle_Musteri();
            CLS.CreateProject.Temizle_MusteriBolum();
            CLS.CreateProject.Temizle_ProjeBilgileri();
            CLS.CreateProject.Temizle_YetkiliKisi();
            CLS.Form_Main.user_Login1.Cikis();
            CLS.Form_Main.Panel_UserInfo.Visible    = false;
            CLS.Form_Main.B_KullaniciOturum.Text    = "Oturum Aç";
            CLS.Form_Main.TB_User_ID.Text           = "";
            CLS.Form_Main.TB_User_UserNo.Text       = "";
            CLS.Form_Main.TB_User_UserLevel.Text    = "";
            CLS.Form_Main.LB_UserName.Text          = "";
            CLS.Form_Main.TB_User_Unvan.Text        = "";
            CLS.Form_Main.TB_User_Bolum.Text        = "";
            CLS.Form_Main.TB_User_Tel1.Text         = "";
            CLS.Form_Main.TB_User_Tel2.Text         = "";
            CLS.Form_Main.TB_User_Mail.Text         = "";
            CLS.Form_Main.TB_User_DogumTarih.Text   = "";
            CLS.Form_Main.TB_User_KanGrubu.Text     = "";
        }




    }
}
