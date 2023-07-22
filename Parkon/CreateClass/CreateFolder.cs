using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;


namespace Parkon
{
    public class CreateFolder
    {
        public CLS CLS;



        public void KlasorYapisi()
        {
            //MusteriAdi;  //BSH
            //MusteriKodu; //0013
            //ProjeAdi;    //
            //ProjeKodu;   //P00130118002

            //ProjeSimge;  //P
            //MusteriNo;   //0013
            //BolumNo;     //01
            //DonemYili;   //18
            //ProjeNo;     //002
            //RevizyonNo;  //R00

            //ProjeIcerik_D1 = "D1";  //Müşteri İlişkileri Gelenler/Teklifler=> Onaylanan/Verilen
            //ProjeIcerik_D2 = "D2";  //İş Zaman Planı
            //ProjeIcerik_D3 = "D3";  //Elektrik Projesi ve Malzeme listesi
            //ProjeIcerik_D4 = "D4";  //PLC, HMI-SCADA, Diger
            //ProjeIcerik_D5 = "D5";  //Cihaz, Cizim, Form, Diger
            //ProjeIcerik_D6 = "D6";  //Fotograf Video

            //// D1 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
            //AltKlasor_D1_1 = "Gelenler";
            //AltKlasor_D1_2 = "Teklifler";
            //AltKlasor_D1_2_1 = "Teklif Verilenler";
            //AltKlasor_D1_2_2 = "Teklif Onaylanan";

            //// D4 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
            //AltKlasor_D4_1 = "PLC";
            //AltKlasor_D4_2 = "HMI SCADA";
            //AltKlasor_D4_3 = "Diger";

            //// D5 İÇİN OLUŞTURULACAK ALT KLASÖRLER //
            //AltKlasor_D5_1 = "Cihazlar";
            //AltKlasor_D5_2 = "Cizim";
            //AltKlasor_D5_3 = "Diger";
            //AltKlasor_D5_4 = "Formlar";
        }
        public string Create_Yeni_Musteri_Klasor(string MusteriNo, string MusteriAdi)
        {

            try
            {
                CLS.ProjeAnadizin = CLS.Form_Main.TB_SecilenAnaDizin.Text;

                string MusteriKlasor_Adi = MusteriNo + " " + MusteriAdi;
                string MusteriKlasoru_Yolu = CLS.ProjeAnadizin + MusteriKlasor_Adi;

                if (!Directory.Exists(MusteriKlasoru_Yolu))
                {
                    Directory.CreateDirectory(MusteriKlasoru_Yolu);

                    MusteriFirma_ExcelDosyasiOlustur(MusteriKlasoru_Yolu, MusteriNo, MusteriAdi, "", "");
                }
                    return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string Create_Yeni_Proje_Klasor(string MusteriNo, string MusteriAdi, string ProjeKodu)
        {
            try
            {
                CLS.ProjeAnadizin = CLS.Form_Main.TB_SecilenAnaDizin.Text;

                string MusteriKlasor_Adi    = MusteriNo + " " + MusteriAdi;
                string MusteriKlasoru_Yolu  = CLS.ProjeAnadizin +  MusteriKlasor_Adi;
                string ProjeKlasoru_Yolu    = CLS.ProjeAnadizin +  MusteriKlasor_Adi + "\\" + ProjeKodu;

                if (!Directory.Exists(ProjeKlasoru_Yolu))
                {
                    Directory.CreateDirectory(ProjeKlasoru_Yolu);
                    Create_Bos_ProjeIcerik_Klasor(ProjeKlasoru_Yolu);
                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string Create_Bos_ProjeIcerik_Klasor(string ProjeKlasoru_Yolu)
        {
            string ProjeKlasoruIcindeBosIcerik_Yolu = ProjeKlasoru_Yolu + "\\" + "R00";
            try
            {
                CLS.ProjeAnadizin = CLS.Form_Main.TB_SecilenAnaDizin.Text;

                if (!Directory.Exists(ProjeKlasoruIcindeBosIcerik_Yolu))
                {
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D1);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D2);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D3);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D4);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D5);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D6);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D7);

                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D1 + "\\" + CLS.AltKlasor_D1_1);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D1 + "\\" + CLS.AltKlasor_D1_2);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D1 + "\\" + CLS.AltKlasor_D1_2 + "\\" + CLS.AltKlasor_D1_2_1);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D1 + "\\" + CLS.AltKlasor_D1_2 + "\\" + CLS.AltKlasor_D1_2_2);

                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D4 + "\\" + CLS.AltKlasor_D4_1);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D4 + "\\" + CLS.AltKlasor_D4_2);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D4 + "\\" + CLS.AltKlasor_D4_3);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D4 + "\\" + CLS.AltKlasor_D4_4);

                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D5 + "\\" + CLS.AltKlasor_D5_1);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D5 + "\\" + CLS.AltKlasor_D5_2);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D5 + "\\" + CLS.AltKlasor_D5_3);
                    Directory.CreateDirectory(ProjeKlasoruIcindeBosIcerik_Yolu + "\\" + CLS.ProjeIcerik_D5 + "\\" + CLS.AltKlasor_D5_4);

                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                MessageBox.Show(HATA.Message.ToString(), "HATA");
                return "ERR! - " + HATA.ToString();
            }
}
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        public string Create_YeniRevizyon(string MusteriNo, string MusteriAdi, string ProjeKodu, string RevizyonNo, out string Status)
        {
                  Status                    = "";
           string OncekiRevKlasor_Yolu      = "";
           string YeniRevKlasor_Yolu        = "";
           string ArsivKayit_Yolu           = "";
           string ProjeKlasor_Yolu          = "";
           string CopKlasoru_Yolu           = "";
           string Str_OncekiRevNo           = "";
           string YeniRevNo                 = "";
           string RevNo                     = "";
           int    value                     = 0;
            try
            {
                CLS.ProjeAnadizin = CLS.Form_Main.TB_SecilenAnaDizin.Text;

                switch (value)
                {
                    case 0:
                        Status = "Yeni Revizyon oluşturma işlemi Başladı. Önceki Revizyon No'u aranıyor...";

                        // Önceki Revizyon No'su Hesapla
                        RevNo = RevizyonNo; //.Substring(1, 2);
                        YeniRevNo = "R" + RevizyonNo;
                        int OncekiRevNo = int.Parse(RevNo) - 1;
                       
                        if (OncekiRevNo < 10)
                        {
                            Str_OncekiRevNo = "R0" + OncekiRevNo.ToString();
                        }
                        else
                        {
                            Str_OncekiRevNo = "R" + OncekiRevNo.ToString();
                        }


                        goto case 1;
                    case 1:
                        Status = "Gerekli değişkenler oluşturuluyor.";
                        ProjeKlasor_Yolu        = CLS.ProjeAnadizin + MusteriNo + " " + MusteriAdi + "\\" + ProjeKodu;
                        OncekiRevKlasor_Yolu    = CLS.ProjeAnadizin + MusteriNo + " " + MusteriAdi + "\\" + ProjeKodu + "\\" + Str_OncekiRevNo.ToString();
                        YeniRevKlasor_Yolu      = CLS.ProjeAnadizin + MusteriNo + " " + MusteriAdi + "\\" + ProjeKodu + "\\" + YeniRevNo;
                        ArsivKayit_Yolu         = CLS.ProjeAnadizin + MusteriNo + " " + MusteriAdi + "\\" + ProjeKodu + "\\" + Str_OncekiRevNo.ToString() + ".zip";
                        CopKlasoru_Yolu         = CLS.ProjeAnadizin + "9999 COP\\" + ProjeKodu + " - " + Str_OncekiRevNo.ToString() + "\\" + Str_OncekiRevNo.ToString();

                        goto case 2;
                    case 2:
                        if (!Directory.Exists(YeniRevKlasor_Yolu))
                        {
                            Directory.CreateDirectory(YeniRevKlasor_Yolu);
                            
                            DirectoryCopy(OncekiRevKlasor_Yolu, YeniRevKlasor_Yolu, true);
                            Status = "Yeni Revizyon klasörü oluşturuldu. İşlem tamamlandı.";
                        }


                        goto case 3;
                    case 3:
                        Status = "Bir önceki revizyon dosyaları arşivleniyor.";
                        ZipFile.CreateFromDirectory(OncekiRevKlasor_Yolu, ArsivKayit_Yolu, CompressionLevel.Optimal, true);//, CompressionLevel.Optimal, false);
                        Status = "Arşivleme işlemi tamamlandı. Dosyalar kaldırılıyor.";

                   


                        goto case 4;
                    case 4:

                        FileSystem.DeleteDirectory(OncekiRevKlasor_Yolu, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);

                        //if (!Directory.Exists(ProjeAnadizin + "9999 COP"))
                        //{
                        //    //Directory.CreateDirectory(ProjeAnadizin + "9999 COP");
                        //    //Directory.Move(OncekiRevKlasor_Yolu, CopKlasoru_Yolu);
                        //}
                        //else
                        //{
                        // if (!Directory.Exists(ProjeAnadizin + ProjeKodu + " - " + Str_OncekiRevNo.ToString()))
                        // {
                        //Directory.CreateDirectory(ProjeAnadizin +  "9999 COP\\" + ProjeKodu + " - " + Str_OncekiRevNo.ToString());
                        //Directory.Move(OncekiRevKlasor_Yolu, CopKlasoru_Yolu);
                        //    Directory.Delete(OncekiRevKlasor_Yolu, false);
                        //}
                        //else
                        //{
                        //    Directory.Move(OncekiRevKlasor_Yolu, CopKlasoru_Yolu);
                        //}
                        //}

                        // DeleteDirectoryOption.DeleteAllContents);// RecycleOption.SendToRecycleBin); //DeleteDirectoryOption.DeleteAllContents, RecycleOption.SendToRecycleBin);// RecycleOption.SendToRecycleBin);

                        //     Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(OncekiRevKlasor_Yolu, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);// Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                        goto case 5;
                    case 5:
                      Directory.CreateDirectory(OncekiRevKlasor_Yolu);
                     


                        goto case 6;
                    case 6:
                     File.Move(ArsivKayit_Yolu, OncekiRevKlasor_Yolu + "\\" + Str_OncekiRevNo.ToString() + ".zip");
                        Status = "Arşivleme işlemi tamamlandı";

                        goto case 7;
                    case 7:
                        if (!Directory.Exists(YeniRevKlasor_Yolu))
                        {
                            Directory.CreateDirectory(YeniRevKlasor_Yolu);
                            Status = "Yeni Revizyon klasörü oluşturuldu. İşlem tamamlandı.";
                        }

                        goto case 8;
                    case 8:


                        goto case 50;
                    case 50:
                        break;
                }



                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                MessageBox.Show(HATA.Message.ToString(), "HATA");
                return "ERR! - " + HATA.ToString();
            }
        }


        public string MusteriFirma_ExcelDosyasiOlustur(string MusteriKlasorPath, string müsteriNo, string MusteriAdi, string Notlar, string Detaylar)
        {
            try
            {
                CLS.Form_Main.DGV_TempForExl.Columns.Add("ID", "ID");
                CLS.Form_Main.DGV_TempForExl.Columns.Add("KayitTarih", "KayitTarih");
                CLS.Form_Main.DGV_TempForExl.Columns.Add("KayitUser", "KayitUser");
                CLS.Form_Main.DGV_TempForExl.Columns.Add("Notlar", "Notlar");
                CLS.Form_Main.DGV_TempForExl.Columns.Add("Islem", "Islem");
                CLS.Form_Main.DGV_TempForExl.Columns.Add("Detaylar", "Detaylar");
                CLS.Form_Main.DGV_TempForExl.Rows.Add();

                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[0].Value = 1;
                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[1].Value = DateTime.Now.ToString();
                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[2].Value = CLS.Form_Main.LB_UserName.Text;
                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[3].Value = Notlar;
                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[4].Value = "Yeni bir müşteri firma oluşturuldu.";
                CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[5].Value = Detaylar;
                string ProjeKuneyesiYolu = MusteriKlasorPath + "\\" + müsteriNo + " " + MusteriAdi + " - MÜŞTERİ KUNYESI.xls";
     
                string a = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGV_TempForExl, ProjeKuneyesiYolu, false);

                CLS.Form_Main.DGV_TempForExl.Columns.Clear();

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }

        }

        public string ingilizcelestir(string kelimecik)
        {
            kelimecik = kelimecik.Replace('ö', 'o');
            kelimecik = kelimecik.Replace('ü', 'u');
            kelimecik = kelimecik.Replace('ğ', 'g');
            kelimecik = kelimecik.Replace('ş', 's');
            kelimecik = kelimecik.Replace('ı', 'i');
            kelimecik = kelimecik.Replace('ç', 'c');
            kelimecik = kelimecik.Replace('Ö', 'O');
            kelimecik = kelimecik.Replace('Ü', 'U');
            kelimecik = kelimecik.Replace('Ğ', 'G');
            kelimecik = kelimecik.Replace('Ş', 'S');
            kelimecik = kelimecik.Replace('İ', 'I');
            kelimecik = kelimecik.Replace('Ç', 'C');

            return kelimecik;
        }




    }
}
