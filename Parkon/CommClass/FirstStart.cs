using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Parkon
{
    public class FirstStart
    {
        public CLS CLS;
        public System.Timers.Timer Tmr = new System.Timers.Timer();
        public bool FirstStart_Tamamlandi;
        public bool FirstStart_Basladi;
        public string FirstStart_InternetKontrol;

        //public string APPpath               = Application.ExecutablePath;               // App. exe yolu
        //public string APPFolderpath         = Application.StartupPath;                  // App. exe klasör yolu
        //public string APPFolderIMGpath      = Application.StartupPath + "\\img";        // App. exe klasör yolu IMAGE


        List<Bitmap> Orj_img                = new List<Bitmap>();
        public  List<Bitmap> img            = new List<Bitmap>();


        public void Baslangic()
        {
            try
            {
                int sw = 0;
                string bilgi;
                string status;
                string msj;

                CLS.Form_Starting.progressBarFirstStart.Maximum = 20;
     
                switch (sw)
                {
                    case 0:
                        // ########## First Start Başladı ########## //
                        FirstStart_Basladi      = true;
                        FirstStart_Tamamlandi   = false;
                        CLS.Form_Starting.Hide();

                        CLS.Form_Starting.progressBarFirstStart.Value = 0;
                        goto case 1;
                    case 1:
                        // ########## Programın Versiyonunu Oku ########## //
                        status = Program_Versiyon_Bilgilerini_Oku();
                        bilgi = "- Program Versiyon Kontrolleri: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 1;
                        goto case 2;
                    case 2:
                        // ########## Dizin Kontrolleri Yapılıyor ########## //
                        status = DizinKontrolleri();
                        bilgi = "**** Gereken dizin kontrolleri: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 2;
                        goto case 3;
                    case 3:
                        // ########## Dizin Ayarları Yükle ########## //
                        status = CLS.PrgSettings.YUKLE_AnaDizin();
                        bilgi = "- Ana Dizin kontrol: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 3;
                        goto case 4;
                    case 4:
                        // ########## Kullanıcı Ayarları Yükle ########## //
                        status = CLS.PrgSettings.YUKLE_SistemAyarlari();
                        bilgi = "- Kaydedilen kullanıcı ayarları: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 4;
                        goto case 5;
                    case 5:
                        // ######### FORM BİLDİRİLMLERİ VE SAYFA DÜZENİ OLUŞTUR ######### //
                        CLS.Bildirimler.SelamMesaji();
                        SayfaDuzen_Kontrolleri();
                      
                        status = "OK!";
                        bilgi = "- Bildirim ve sistem mesaj ayarları: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 5;
                        goto case 6;
                    case 6: 
                        // ######### DB DEĞİŞKENLERİNİ OLUŞTUR ######### //
                        status = CLS.MySQLVar.FirstStart();
                        bilgi = "- Database ayarları: ";
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        Thread.Sleep(300);
                        CLS.Form_Starting.progressBarFirstStart.Value = 6;
                        goto case 7;
                    case 7: 
                        // ######### INTERNET KONTROLÜ ######### //
                        status = CLS.Bildirimler.NetKontrol();
                        bilgi = "- Makine internet kontrol: ";
                        FirstStart_InternetKontrol = status;
                        msj = bilgi + status;
                        CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);
                        Thread.Sleep(500);

                        CLS.Form_Starting.progressBarFirstStart.Value = 7;
                        goto case 8;
                    case 8: 
                        // ######### MYSQL SERVER BAĞLANTISI OLUŞTUR ######### //
                        if (FirstStart_InternetKontrol == "OK!")
                        {
                            status = CLS.ID_MySQL.Connect();
                            bilgi = "- Server ile bağlantı: ";
                            msj = bilgi + status;
                            CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);
                        }

                        CLS.Form_Starting.progressBarFirstStart.Value = 8;
                        goto case 9;
                    case 9:

                        CLS.Form_Starting.progressBarFirstStart.Value = 9;
                        goto case 10;
                    case 10:
                        // ######### INTERNETTEN MEVCUT DATALARI AL ######### //
                        //if (FirstStart_InternetKontrol != "OK!")
                        //{
                        //    CLS.ProjeSorgulama.LocalDataUpdate();
                        //}

                        //CLS.ProjeSorgulama.Fill_DGV_FromLocalDB();
                        //status = CLS.PrgSettings.YUKLE_DBGuncellemeSonTarih();
                        //bilgi = "- Son DB güncelleme tarih ve ayarları: ";
                        //msj = bilgi + status;
                        //CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);

                        CLS.Form_Starting.progressBarFirstStart.Value = 10;
                        goto case 11;
                    case 11:
                        // ######### INTERNETTEN GÜNCEL VERSİYON KONTROLÜ YAP ######### //
                        if (FirstStart_InternetKontrol == "OK!")
                        {
                            string[] Rdata;
                            status = CLS.AutoUpdate.VerCheck(out Rdata);
                            bilgi = "- Yeni verisyon kontrolü: ";
                            msj = bilgi + status;
                            CLS.Log.LOGYAZ("Log_AppStart", CLS.Form_Starting.RTB_AppStart, msj, Color.White, true, false);
                        }

                        CLS.Form_Starting.progressBarFirstStart.Value = 11;
                        goto case 12;
                    case 12:
                        LogFileOku();
                        CLS.Form_Starting.progressBarFirstStart.Value = 12;
                        goto case 13;
                    case 13:

                        CLS.Form_Starting.progressBarFirstStart.Value = 13;
                        goto case 14;
                    case 14:

                        CLS.Form_Starting.progressBarFirstStart.Value = 14;
                        goto case 15;
                    case 15:

                        CLS.Form_Starting.progressBarFirstStart.Value = 15;
                        goto case 16;
                    case 16:

                        CLS.Form_Starting.progressBarFirstStart.Value = 16;
                        goto case 17;
                    case 17:

                        CLS.Form_Starting.progressBarFirstStart.Value = 17;
                        goto case 18;
                    case 18:

                        CLS.Form_Starting.progressBarFirstStart.Value = 18;
                        goto case 19;
                    case 19:

                        CLS.Form_Starting.progressBarFirstStart.Value = 19;
                        goto case 20;
                    case 20:

                        CLS.Form_Starting.progressBarFirstStart.Value = 20;
                        goto case 50;
                    case 50:

                        FirstStart_Tamamlandi   = true;
                        FirstStart_Basladi      = false;

                        Thread.Sleep(1000);
                       // CLS.Form_Main.Opacity       = 1.0;
                        
                         CLS.Form_Starting.Hide();
                        break;
                }

            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
        }

        public string DizinKontrolleri()
        {
            if (!Directory.Exists(CLS.ProgramData_Path))
            {
                Directory.CreateDirectory(CLS.ProgramData_Path);
            }
            if (!File.Exists(CLS.ProgramData_Path + "Settings.ini"))
            {
                File.Create(CLS.ProgramData_Path + "Settings.ini");
            }
            if (!File.Exists(CLS.ProgramData_Path + "RemMe.ini"))
            {
                File.Create(CLS.ProgramData_Path + "RemMe.ini");
            }
            if (!File.Exists(CLS.ProgramData_Path + "Log_Op.txt"))
            {
                File.Create(CLS.ProgramData_Path + "Log_Op.txt");
            }
            if (!File.Exists(CLS.ProgramData_Path  + "Log_Error.txt"))
            {
                File.Create(CLS.ProgramData_Path  + "Log_Error.txt");
            }
            if (!File.Exists(CLS.ProgramData_Path  + "Log_AppStart.txt"))
            {
                File.Create(CLS.ProgramData_Path  + "Log_AppStart.txt");
            }
            if (!File.Exists(CLS.ProgramData_Path  + "DBR.xls"))
            {
                File.Create(CLS.ProgramData_Path  + "DBR.xls");
            }
            if (!File.Exists(CLS.ProgramData_Path  + "DBMB.xls"))
            {
                File.Create(CLS.ProgramData_Path  + "DBMB.xls");
            }
            if (!File.Exists(CLS.ProgramData_Path  + "DBP.xls"))
            {
                File.Create(CLS.ProgramData_Path  + "DBP.xls");
            }
            if (!File.Exists(CLS.ProgramData_Path + "DBM.xls"))
            {
                File.Create(CLS.ProgramData_Path  + "DBM.xls");
            }
            if (!File.Exists(CLS.NetworkProfil_ExcelFies))
            {
                File.Create(CLS.NetworkProfil_ExcelFies);
            }
            if (!File.Exists(CLS.Log_ProjeAramaGecmisi ))
            {
                File.Create(CLS.Log_ProjeAramaGecmisi);
            }
    
            return "OK!";
        }
        public string Program_Versiyon_Bilgilerini_Oku()
        {
            try
            {
                CLS.Form_Main.Text = "Proje Arşivleme ve Kontrol Sistemi V" + CLS.fvi.FileVersion;
                CLS.Form_Starting.LB_FirstStartVersiyon.Text = CLS.fvi.FileVersion;
                CLS.Version                                  = CLS.fvi.FileVersion;
                CLS.Form_Main.LB_Version.Text   = "Ver: " + CLS.fvi.FileVersion;
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR: " +  HATA.ToString();
            }
        }
        public string SayfaDuzen_Kontrolleri()
        {
            try
            {

                //for (int i = 0; i < 114; i++)
                //{
                //    if (i < 10)
                //    {
                //        Orj_img.Add(Bitmap.FromFile(APPFolderIMGpath + "\\i0" + i.ToString() + ".png") as Bitmap);
                //    }
                //    else
                //    {
                //        Orj_img.Add(Bitmap.FromFile(APPFolderIMGpath + "\\i" + i.ToString() + ".png") as Bitmap);
                //    }

                //    img.Add(new Bitmap(Orj_img[i], new Size(38, 38)));
                //}
                //CLS.Form_Main.B_Cikis.Image = Properties.Resources.i85;
                //CLS.Form_Main.B_Cikis.ImageAlign = ContentAlignment.MiddleLeft;
                //CLS.Form_Main.B_Cikis.TextImageRelation = TextImageRelation.ImageBeforeText;
                //CLS.Form_Main.B_Cikis.TextAlign = ContentAlignment.MiddleLeft;

                #region ANA SAYFA

                #endregion

                #region MAIN TAB
                string Page0 = "TabPage_ProjeSorgula";
                string Page1 = "TabPage_ProjeYeni";
                string Page2 = "TabPage_Servis";
                string Page3 = "TabPage_Teklif";
                string Page4 = "TabPage_Rapor";
                string Page5 = "TabPage_Otomasyon";
                string Page6 = "TabPage_Stok";
                string Page7 = "TabPage_Ayarlar";

                //CLS.Form_Main.Tab_Main.ShowToolTips = true;
                CLS.Form_Main.Tab_Main.TabPages[Page0].ToolTipText = "Proje Sorgulama";
                CLS.Form_Main.Tab_Main.TabPages[Page1].ToolTipText = "Yeni Proje Oluşturma";
                CLS.Form_Main.Tab_Main.TabPages[Page2].ToolTipText = "Servis, Bakım, Eğitim Hizmetleri";
                CLS.Form_Main.Tab_Main.TabPages[Page3].ToolTipText = "Fiyat Listeleri ve Teklif Oluşturma";
                CLS.Form_Main.Tab_Main.TabPages[Page4].ToolTipText = "Çalışma ve Proje Raporları";
                CLS.Form_Main.Tab_Main.TabPages[Page5].ToolTipText = "Otomasyoncunun Beslenme Çantası";
                CLS.Form_Main.Tab_Main.TabPages[Page6].ToolTipText = "STOK KONTROL SİSTEMİ";
                CLS.Form_Main.Tab_Main.TabPages[Page7].ToolTipText = "Extra Bilgiler ve Ayarlar";


                CLS.Form_Main.Tab_Main.TabPages[Page0].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page1].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page2].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page3].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page4].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page5].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page6].Text = "";
                CLS.Form_Main.Tab_Main.TabPages[Page7].Text = "";

                ImageList ImgList_TabMain = new ImageList();
                ImgList_TabMain.ImageSize = new Size(40, 40);
                CLS.Form_Main.Tab_Main.ImageList = ImgList_TabMain;


                ImgList_TabMain.Images.Add("key0", Properties.Resources.i119);
                ImgList_TabMain.Images.Add("key1", Properties.Resources.i118);
                ImgList_TabMain.Images.Add("key2", Properties.Resources.i114);
                ImgList_TabMain.Images.Add("key3", Properties.Resources.i116);
                ImgList_TabMain.Images.Add("key4", Properties.Resources.i131);
                ImgList_TabMain.Images.Add("key5", Properties.Resources.i129);
                ImgList_TabMain.Images.Add("key6", Properties.Resources.i160);
                ImgList_TabMain.Images.Add("key7", Properties.Resources.i120);

                CLS.Form_Main.Tab_Main.TabPages[Page0].ImageIndex = 0;
                CLS.Form_Main.Tab_Main.TabPages[Page1].ImageIndex = 1;
                CLS.Form_Main.Tab_Main.TabPages[Page2].ImageIndex = 2;
                CLS.Form_Main.Tab_Main.TabPages[Page3].ImageIndex = 3;
                CLS.Form_Main.Tab_Main.TabPages[Page4].ImageIndex = 4;
                CLS.Form_Main.Tab_Main.TabPages[Page5].ImageIndex = 5;
                CLS.Form_Main.Tab_Main.TabPages[Page6].ImageIndex = 6;
                CLS.Form_Main.Tab_Main.TabPages[Page7].ImageIndex = 7;





                #endregion

                //#region SORGULAMA PANELİ

                //Bitmap Rimg_02 = new Bitmap(Properties.Resources.i02, new Size(25, 25));
                //CLS.Form_Main.B_Sorgu_Ara.Image = Rimg_02;
                //CLS.Form_Main.B_Sorgu_Ara.ImageAlign = ContentAlignment.MiddleLeft;
                //CLS.Form_Main.B_Sorgu_Ara.TextImageRelation = TextImageRelation.ImageBeforeText;
                //CLS.Form_Main.B_Sorgu_Ara.TextAlign = ContentAlignment.MiddleLeft;

                //Bitmap Rimg_74 = new Bitmap(Properties.Resources.i74, new Size(18, 18));
                //CLS.Form_Main.B_Sorgu_AramayiTemizle.Image = Rimg_74;
                //CLS.Form_Main.B_Sorgu_AramayiTemizle.ImageAlign = ContentAlignment.MiddleLeft;
                //CLS.Form_Main.B_Sorgu_AramayiTemizle.TextImageRelation = TextImageRelation.ImageBeforeText;
                //CLS.Form_Main.B_Sorgu_AramayiTemizle.TextAlign = ContentAlignment.MiddleLeft;

                //Bitmap Rimg_75 = new Bitmap(Properties.Resources.i75, new Size(18, 18));
                //CLS.Form_Main.B_Sorgu_ProjeKlasoruAc.Image = Rimg_75;
                //CLS.Form_Main.B_Sorgu_ProjeKlasoruAc.ImageAlign = ContentAlignment.MiddleLeft;
                //CLS.Form_Main.B_Sorgu_ProjeKlasoruAc.TextImageRelation = TextImageRelation.ImageBeforeText;
                //CLS.Form_Main.B_Sorgu_ProjeKlasoruAc.TextAlign = ContentAlignment.MiddleLeft;

                //#endregion
                //CLS.Form_Main.Refresh();
                //CLS.Form_Main.Update();
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR: " + HATA.ToString();
            }
        }
        public string LogFileOku()
        {
            try
            {
               string cmd1 = CLS.Log.LogFileRead(CLS.Form_Main.RTB_LogsOp, CLS.ProgramData_Path + "Log_Op.txt");
               string cmd2 = CLS.Log.LogFileRead(CLS.Form_Main.RTB_LogsHata, CLS.ProgramData_Path + "Log_Error.txt");
               string cmd3 = CLS.Log.LogFileRead(CLS.Form_Main.RTB_AppStart, CLS.ProgramData_Path + "Log_AppStart.txt");
               CLS.Form_Main.RTB_LogsOp.Visible = true;
                CLS.Form_Main.RTB_LogsHata.Visible = true;
                CLS.Form_Main.RTB_AppStart.Visible = true;

                return cmd1 + " " + cmd2 + " " + cmd3;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }
        
        }





    }
}
