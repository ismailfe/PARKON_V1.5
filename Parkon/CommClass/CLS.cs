using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDExcel;

namespace Parkon
{
    /// <summary>
    /// Classlar arası Bağlantı sınıfı
    /// </summary>
    public class CLS
    {
        // FORMLAR
        public static Form_Main Form_Main;// = new Form_Main();
        public static Form_VersiyonYukle Form_VersiyonYukle                = new Form_VersiyonYukle();
        public static Form_Starting Form_Starting                          = new Form_Starting();
        public static Form_Yeni_Musteri Form_Yeni_Musteri                  = new Form_Yeni_Musteri();
        public static Form_Yeni_MusteriBolum Form_Yeni_MusteriBolum        = new Form_Yeni_MusteriBolum();
        public static Form_Yeni_Yetkili Form_Yeni_Yetkili                  = new Form_Yeni_Yetkili();
        public static Form_Yeni_User Form_Yeni_User                        = new Form_Yeni_User();
        public static Form_Yeni_Proje Form_Yeni_Proje                      = new Form_Yeni_Proje();
        public static Form_Yeni_Revizyon Form_Yeni_Revizyon                = new Form_Yeni_Revizyon();
        public static Form_WhatsNew Form_WhatsNew                          = new Form_WhatsNew();
        public static Form_PrgSecim Form_PrgSecim                          = new Form_PrgSecim();
        // STOK PROGRAMI FORMLAR
        public static Form_Stok_MarkaYeni Form_Stok_MarkaYeni              = new Form_Stok_MarkaYeni();
        public static Form_Stok_UrunYeni Form_Stok_YeniUrun                = new Form_Stok_UrunYeni();
        public static Form_Stok_MusteriYeni Form_Stok_YeniMusteri          = new Form_Stok_MusteriYeni();
        public static Form_Stok_YetkiliYeni Form_Stok_YeniYetkili          = new Form_Stok_YetkiliYeni();
        public static Form_Stok_MarkaDuzelt Form_Stok_MarkaDuzelt          = new Form_Stok_MarkaDuzelt();
        public static Form_Stok_MusteriDuzelt Form_Stok_MusteriDuzelt      = new Form_Stok_MusteriDuzelt();
        public static Form_Stok_UrunDuzelt Form_Stok_UrunDuzelt            = new Form_Stok_UrunDuzelt();
        public static Form_Stok_YetkiliDuzelt Form_Stok_YetkiliDuzelt      = new Form_Stok_YetkiliDuzelt();

        // PROGRAM CLASS
        public static FirstStart FirstStart                                = new FirstStart();
        public static Crypto Crypto                                        = new Crypto();     
        public static Log Log                                              = new Log();
        public static PrgSettings PrgSettings                              = new PrgSettings();
        public static TextCheck TextCheck                                  = new TextCheck();
        public static UserLogin UserLogin                                  = new UserLogin();
        public static Bildirimler Bildirimler                              = new Bildirimler();
        public static ProjeSorgulama ProjeSorgulama                        = new ProjeSorgulama();
        public static AutoUpdate AutoUpdate                                = new AutoUpdate();
              
        public static CreateAuthorized CreateAuthorized                    = new CreateAuthorized();
        public static CreateCustomer CreateCustomer                        = new CreateCustomer();
        public static CreateDepartment CreateDepartment                    = new CreateDepartment();
        public static CreateFolder CreateFolder                            = new CreateFolder();
        public static CreateProject CreateProject                          = new CreateProject();

        public static EXL EXL                                              = new EXL();
        public static ID_MySQL ID_MySQL                                    = new ID_MySQL();
        public static MySQL MySQL                                          = new MySQL();
        public static MySQLVar MySQLVar                                    = new MySQLVar();

        public static TaskSchedulerCtrl TaskSchedulerCtrl                  = new TaskSchedulerCtrl();
        public static NetworkAdapter NetworkAdapter                        = new NetworkAdapter();
        public static ProjeSorgulamaGecmisi ProjeSorgulamaGecmisi          = new ProjeSorgulamaGecmisi();
        public static PrgSecimi PrgSecimi                                  = new PrgSecimi();

        //STOK PROGRAMI CLASS
        public static StokCreateMarka StokCreateMarka                       = new StokCreateMarka();
        public static StokCreateUrun StokCreateUrun                         = new StokCreateUrun();
        public static StokCreateMusteri StokCreateMusteri                   = new StokCreateMusteri();
        public static StokCreateYetkili StokCreateYetkili                   = new StokCreateYetkili();
        public static Stok_Sorgulama Stok_Sorgulama                         = new Stok_Sorgulama();
        public static Stok_UrunGiris Stok_UrunGiris                         = new Stok_UrunGiris();
        public static Stok_UrunCikis Stok_UrunCikis                         = new Stok_UrunCikis();
        public static Stok_SorgulamaCikis Stok_SorgulamaCikis               = new Stok_SorgulamaCikis();


        #region Dosya ve Klasör Dizinleri
        // STANDART PROGRAM DOSYASI YOLLARI
        public static string ProgramData_Path                  = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)  + "\\Parkon\\";          //        +  "C:\\ProgramData"
        public static string App_Path                          = Application.ExecutablePath;   // App. exe yolu
        public static string AppFolder_Path                    = Application.StartupPath;      // App. exe klasör yolu

        // AYARLAR INI DOSYA YOLLARI
        public static string Settings_Path                     = ProgramData_Path + "Settings.ini";
        public static string RemMe_Path                        = ProgramData_Path + "RemMe.ini";
        public static string UpdateDate_Path                   = ProgramData_Path + "UpdateDate.ini";

        // PROJE ARAMA GEÇMİŞİ LOG DOSYASI YOLU
        public static string Log_ProjeAramaGecmisi             = ProgramData_Path + "Log_ProjeAramaGecmisi.txt";

        // PROGRAM SEÇİM DOSYA YOLLARI
        public static string PrgSecim_Otomasyon                = ProgramData_Path + "prg_otomasyon.ini";
        public static string PrgSecim_Elektronik               = ProgramData_Path + "prg_elektronik.ini";
        public static string PrgSecim_Admin                    = ProgramData_Path + "prg_admin.ini";
        public static string PrgSecim_Config                   = ProgramData_Path + "prg_config.ini";

        // EXCEL DOSYALARI YOLLARI
        public static string SavePath_DBM                       = ProgramData_Path + "DBM.xls";
        public static string SavePath_DBMB                      = ProgramData_Path + "DBMB.xls";
        public static string SavePath_DBP                       = ProgramData_Path + "DBP.xls";
        public static string SavePath_DBR                       = ProgramData_Path + "DBR.xls";
        public static string NetworkProfil_ExcelFies            = ProgramData_Path + "NetworkProfil.xls";

        public static string Str_ProjeCrypto                    = "xxx";
        public static string Str_StokCrypto                     = "Stokxxx";

        public FileVersionInfo fvi;
        public System.Reflection.Assembly assembly;
        public string Version;
        #endregion

        #region PROJE KLASÖR YAPISI ve KLASÖRLERİ

        public string ProjeAnadizin;
        public string ProjeIcerik_D1 = "D1";                       // Müşteri İlişkileri Gelenler/Teklifler=> Onaylanan/Verilen
        public string ProjeIcerik_D2 = "D2";                       // Malzeme listesi
        public string ProjeIcerik_D3 = "D3";                       // Elektrik Projesi ve Malzeme listesi
        public string ProjeIcerik_D4 = "D4";                       // PLC, HMI-SCADA, Diger
        public string ProjeIcerik_D5 = "D5";                       // Cihaz, Cizim, Form, Diger
        public string ProjeIcerik_D6 = "D6";                       // Fotograf Video
        public string ProjeIcerik_D7 = "D7";                       // İş Zaman Planı

        // D1 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
        public string AltKlasor_D1_1 = "Gelenler";                 // = "Gelenler";
        public string AltKlasor_D1_2 = "Teklifler";                // = "Teklifler";
        public string AltKlasor_D1_2_1 = "Teklif - Verilen";       // = "Teklif Verilenler";
        public string AltKlasor_D1_2_2 = "Teklif - Onaylanan";     // = "Teklif Onaylanan";

        // D4 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
        public string AltKlasor_D4_1 = "PLC";                      // = "PLC";
        public string AltKlasor_D4_2 = "HMI";                      // = "HMI SCADA";
        public string AltKlasor_D4_3 = "PC";                       // = "PC";
        public string AltKlasor_D4_4 = "Diger";                    // = "Diger";

        // D5 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
        public string AltKlasor_D5_1 = "Cihazlar";                 // = "Cihazlar";
        public string AltKlasor_D5_2 = "Cizimler";                 // = "Cizim";
        public string AltKlasor_D5_3 = "Diger";                    // = "Diger";
        public string AltKlasor_D5_4 = "Formlar";                  // = "Formlar";

        #endregion

        public void Class()
        {
            //FORMLAR
            Form_VersiyonYukle.CLS          = this;
            Form_Yeni_Yetkili.CLS           = this;
            Form_Yeni_Musteri.CLS           = this;
            Form_Yeni_MusteriBolum.CLS      = this;
            Form_Yeni_User.CLS              = this;
            Form_Yeni_Proje.CLS             = this;
            Form_Yeni_Revizyon.CLS          = this;
            Form_PrgSecim.CLS               = this;

            //STOK FORMLAR
            Form_Stok_MarkaYeni.CLS     = this;
            Form_Stok_YeniUrun.CLS      = this;
            Form_Stok_YeniMusteri.CLS   = this;
            Form_Stok_YeniYetkili.CLS   = this;
            Form_Stok_MarkaDuzelt.CLS   = this;
            Form_Stok_MusteriDuzelt.CLS = this;
            Form_Stok_UrunDuzelt.CLS    = this;
            Form_Stok_YetkiliDuzelt.CLS = this;

            //STOK CLASS
            StokCreateMarka.CLS         = this;
            StokCreateUrun.CLS          = this;
            StokCreateMusteri.CLS       = this;
            StokCreateYetkili.CLS       = this;
            Stok_UrunGiris.CLS          = this;
            Stok_Sorgulama.CLS          = this;
            Stok_UrunCikis.CLS          = this;
            Stok_SorgulamaCikis.CLS     = this;
           

            FirstStart.CLS                  = this;
            Crypto.CLS                      = this;
            Log.CLS                         = this;
            PrgSettings.CLS                 = this;
            TextCheck.CLS                   = this;
            UserLogin.CLS                   = this;
            Bildirimler.CLS                 = this;
            ProjeSorgulama.CLS              = this;
            AutoUpdate.CLS                  = this;

            CreateAuthorized.CLS            = this;
            CreateCustomer.CLS              = this;
            CreateDepartment.CLS            = this;
            CreateFolder.CLS                = this;
            CreateProject.CLS               = this;

            ID_MySQL.CLS                    = this;
            MySQL.CLS                       = this;
            MySQLVar.CLS                    = this;

            TaskSchedulerCtrl.CLS           = this;

            NetworkAdapter.CLS              = this;

            ProjeSorgulamaGecmisi.CLS       = this;
            PrgSecimi.CLS                   = this;

        


        }




        public string Coz(int i, string ColumnName, DataGridView DGV)
        {
            try
            {
                string Val1 = DGV.Rows[i].Cells[ColumnName].Value.ToString();
                string Val2 = Crypto.Decrypt(Val1, CLS.Str_StokCrypto);
                DGV.Rows[i].Cells[ColumnName].Value = Val2;
                return "OK!";
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }



    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
