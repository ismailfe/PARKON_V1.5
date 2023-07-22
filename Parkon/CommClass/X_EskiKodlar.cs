using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parkon
{
    class X_EskiKodlar
    {

        public void CheckForUpdates()
        {
            //WebRequest webRequest = HttpWebRequest.Create("YOUR LINK HERE");
            //WebResponse webResponse = webRequest.GetResponse();

            //string newestVersion = string.Empty;
            //string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
            //{
            //    newestVersion = streamReader.ReadToEnd();
            //    streamReader.Close();
            //}

            //if (newestVersion == currentVersion)
            //{
            //    // Your software is up to date.
            //}
            //else
            //{
            //    // There is a new update, it will begin to download.
            //}
        }

        #region Kapatma ve Notifly
        //if (!CHB_SystemTray.Checked && false) // X ile kapatmayı iptal ettik.
        //{
        //    DialogResult Soru = MessageBox.Show("Parkon'u kapatmak istediğinizden emin misiniz?", "Parkon Kapatılacak!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    if (Soru == DialogResult.Yes)
        //    {
        //        APPCLOSE();
        //    }
        //    else
        //    {
        //        e.Cancel = (Soru == DialogResult.No);
        //    }
        //}else
        //{
        //    e.Cancel = true;
        //    this.WindowState = FormWindowState.Minimized;
        //}
        //this.WindowState    = FormWindowState.Minimized;

        //if (WindowState == FormWindowState.Minimized && CHB_SystemTray.Checked)
        //{
        //    if(!CLS.FirstStart.FirstStart_Basladi)
        //    {
        //        //// Backround Work
        //        Notify_Parkon.BalloonTipText = "Parkon is still running";
        //        Notify_Parkon.BalloonTipTitle = "Parkon - Proje Arşivleme ve Kontrol";
        //        ShowInTaskbar = false;
        //        Notify_Parkon.Visible = true;
        //        Notify_Parkon.ShowBalloonTip(1000);
        //    }
        //}

        #endregion

        void AcilistaCalistir(bool SET)
        {
            //string ProgramAdi = "PARKON";
            //if (SET)
            //{ //işaretlendi ise Regedit e açılışta çalıştır olarak ekle
            //    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //    key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");
            //    CHB_Acilista_Calistir.Checked = true;
            //}
            //else
            //{  //işaret kaldırıldı ise Regeditten açılışta çalıştırılacaklardan kaldır
            //    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //    key.DeleteValue(ProgramAdi);
            //    CHB_Acilista_Calistir.Checked = false;
            //}
        }

        public void XInternetKontrol()
        {
            //try
            //{
            //    System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
            //    kontrol_client.Close();
            //    //if (CheckForInternetConnection())
            //    //{
            //    //    InternetDurumunaGoreGostergeler(true);
            //    //    return "OK!";
            //    //}else
            //    //{
            //    //    InternetBaglantiERR_OK = MessageBox.Show("Bilgisayarda internet bağlantısı olmadığı algılandı. Program çalışmaya ''Local Database'' ile devam edecek.",
            //    //                                    "PARKON - Internet bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //    return "ERR!";
            //    //}
            //    // return (reply.Status == IPStatus.Success).ToString();


            //    //if (CheckForInternetConnection())
            //    //{

            //    //    InternetDurumunaGoreGostergeler(true);
            //    //    return "OK!";
            //    //}else
            //    //{
            //    //    if (!internetBaglantisiERR)
            //    //    {
            //    //        //InternetBaglantiERR_OK = MessageBox.Show("Bilgisayarda internet bağlantısı olmadığı algılandı. Program çalışmaya ''Local Database'' ile devam edecek.",
            //    //        //                                         "PARKON - Internet bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    //        CLS.Bildirimler.Notify_Internet_Durumu(true);
            //    //    }

            //    //    InternetDurumunaGoreGostergeler(false);
            //    //    if (InternetBaglantiERR_OK == DialogResult.OK) { internetBaglantisiERR = true; }
            //    //    return "ERR!";
            //    //}



            //    //Ping myPing = new Ping();
            //    //String host = "google.com";
            //    //byte[] buffer = new byte[32];
            //    //int timeout = 5;
            //    //PingOptions pingOptions = new PingOptions();
            //    //pingOptions.Ttl = 2;
            //    //PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

            //    InternetDurumunaGoreGostergeler(true);
            //    return "OK!";
            //}
            //catch
            //{
            //    InternetDurumunaGoreGostergeler(false);

            //    if (!internetBaglantisiERR)
            //    {
            //        //InternetBaglantiERR_OK = MessageBox.Show("Bilgisayarda internet bağlantısı olmadığı algılandı. Program çalışmaya ''Local Database'' ile devam edecek.",
            //        //                                         "PARKON - Internet bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        CLS.Bildirimler.Notify_Internet_Durumu(true);
            //    }

            //    if (InternetBaglantiERR_OK == DialogResult.OK) { internetBaglantisiERR = true; }
            //    return "ERR!";
            //}
        }
        public static bool CheckForInternetConnection()
        {
            //try
            //{
            //    using (var client = new WebClient())
            //    using (client.OpenRead("http://clients3.google.com/generate_204"))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
            try
            {
                //WebRequest wr = WebRequest.Create(new Uri("  http://xxx.com/parkon/conn.txt"));
                //WebResponse ws = wr.GetResponse();
                //StreamReader sr = new StreamReader(ws.GetResponseStream());

                //string NewVersion = sr.ReadToEnd();
                //return true;
                //  using (var client = new WebClient())
                //using (client.OpenRead("http://clients3.google.com/generate_204"))
                //{
                //    return true;
                //}
                return true;

            }
            catch (Exception )
            {
            //    CLS.Log.ERR_LOGS(HATA.ToString());
                return false;
            }

        }

        #region EXCEL_TEST

        // ID_DB.EXCELS PrgEXCEL = new ID_DB.EXCELS();
        //ID_DB.SQL ASD = new ID_DB.SQL();



        //void READ_EXCEL(string ExcelFilePath, DataGridView DGV, out string Status)
        //{
        //    //Status = "";
        //    //int KomutDurumu = PrgEXCEL.Read_FillingDGV_FromExel(ExcelFilePath, DGV);

        //    //if (KomutDurumu == 1)
        //    //{
        //    //    Status = "OK";
        //    //}
        //    //else if (KomutDurumu == -1)
        //    //{
        //    //    Status = "ERROR";
        //    //}
        //}

        //  void SAVE_EXCEL(string ExcelFilePath, string ExcelFileName, string ExcelFileExtention, DataGridView DGV, bool SheckSaveAs, out string Status)
        //  {
        //      //Status = "";
        //      //int KomutDurumu = PrgEXCEL.Write_ExcelFile_FromDGV(ExcelFilePath, ExcelFileName, ExcelFileExtention, DGV, SheckSaveAs);

        //      //if (KomutDurumu == 1)
        //      //{
        //      //    Status = "OK";
        //      //}
        //      //else if (KomutDurumu == -1)
        //      //{
        //      //    Status = "ERROR";
        //      //}
        //      //else if (KomutDurumu == 2)
        //      //{
        //      //    Status = "DataRead ERROR";
        //      //}
        //      //else if (KomutDurumu == 3)
        //      //{
        //      //    Status = "AYNI DOSYA VAR";
        //      //}
        //  }



        //  private void B_EXL_NewCreate_Click(object sender, EventArgs e)
        //  {
        //      DataTable TempDT = new DataTable();
        //      TempDT.Columns.Clear();
        //      TempDT.Columns.Add("NO");
        //      TempDT.Columns.Add("TARIH");
        //      TempDT.Columns.Add("YETKILI");
        //      TempDT.Columns.Add("ISLEM");
        //      TempDT.Columns.Add("ACIKLAMA");

        //      DataRow rowlar = TempDT.NewRow();
        //      rowlar[0] = "1";
        //      rowlar[1] = DateTime.Now.ToLongDateString();
        //    //  rowlar[2] = TB_Kullanici.Text;
        //      rowlar[3] = "Yeni Proje Oluşturma";
        //      rowlar[4] = "Yeni Proje Oluşturuldu. Proje için gereken klasörler hazırlandı.";
        //      TempDT.Rows.Add(rowlar);

        //      DataGridView TempDGV = new DataGridView();

        //      TempDGV.DataSource = TempDT;
        //      string Status = "";

        ////      SAVE_EXCEL(TB_EXL_KayitYolu.Text, TB_EXL_FileName.Text, CB_EXL_FileExtention.Text, TempDGV, false, out Status);
        ////      LB_EXL_NewCreate.Text = Status;
        //  }







        #endregion

        #region PROJE_OLUSTURMA

        //private void CB_MusteriFirma_PrjOlusturma_MouseDown(object sender, MouseEventArgs e)
        //{

        //    CB_Proje_Olustur_Musteri_Firma.Items.Clear();

        //    string[] dosya = Directory.GetDirectories(Anadizin);
        //    for (int a = 0; a < dosya.Length; a++)
        //    {
        //        string MusteriFirma_Klasorleri = dosya[a];
        //        MusteriFirma_Klasorleri = MusteriFirma_Klasorleri.Replace(Anadizin, "");
        //        CB_Proje_Olustur_Musteri_Firma.Items.Add(MusteriFirma_Klasorleri);
        //    }
        //}

        //private void B_Yeni_Musteri_Ekle_Prj_Olusturma_Click(object sender, EventArgs e)
        //{
        //    Form_Yeni_Musteri.ShowDialog();
        //}

        //private void B_Proje_Olustur_Click(object sender, EventArgs e)
        //{
        //    if (CB_Proje_Olustur_Musteri_Firma.Text == "")
        //    {
        //        DialogResult result = MessageBox.Show("Müşteri Firma seçimi yapılmadı! Lütfen seçim yapınız. " +
        //             "Eğer listede aradığınız müşteri firmayı bulamadıysanız yöneticinize danışarak yeni " +
        //             "'Müşteri Firma Klasörü' oluşturabilirsiniz.",
        //             "Uyarı! Eksik Parametre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        Karakter_TRtoENG();
        //        CreateFolder();
        //    }


        //}

        //private void B_Proje_Olustur_Temizle_Click(object sender, EventArgs e)
        //{
        //    ProjeOlusturTemizle();
        //}

        //private void CB_Proje_Olustur_Musteri_Firma_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(Lb_Uyari.Text != "") { ProjeOlusturTemizle(); }
        //}

        //public void ProjeOlusturTemizle()
        //{
        //    TB_Proje_Olustur_Proje_Adi.Text = "";
        //    TB_Proje_Olustur_Proje_Donemi.Text = "";
        //    //TB_Proje_Olustur_Proje_Kodu_Simgesi.Text = "";
        //    TB_Proje_Olustur_Bölüm.Text = "";
        //    CHB_Proje_Olustur_Proje_Donemi_Degistir.Checked = false;
        //    CHB_Proje_Olustur_Proje_Kodu_Degistir.Checked = false;
        //    CB_Proje_Olustur_Musteri_Firma.Text = "";
        //    Lb_Uyari.Text = "";
        //}

        //public void CreateFolder()
        //{

        //    Dizin_Musteri_Firma = Anadizin + CB_Proje_Olustur_Musteri_Firma.Text;

        //    string Proje_Olustur_Bolum_Knt;
        //    if (TB_Proje_Olustur_Bölüm.Text != "")
        //    { Proje_Olustur_Bolum_Knt = TB_Proje_Olustur_Bölüm.Text + " "; }
        //    else { Proje_Olustur_Bolum_Knt = TB_Proje_Olustur_Bölüm.Text; }

        //    Dizin_Proje = Dizin_Musteri_Firma + "\\" + TB_Proje_Olustur_Proje_Kodu_Simgesi.Text + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + CB_Proje_Olustur_Musteri_Firma.Text + " - " + Proje_Olustur_Bolum_Knt + TB_Proje_Olustur_Proje_Adi.Text;

        //    if (!Directory.Exists(Dizin_Proje))
        //    {
        //        Directory.CreateDirectory(Dizin_Proje);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri); //P1 Musteriden Gelenler
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\E-Mailler");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteri Talebi ve Degisiklikleri");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteriden Gelen Belgeler");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteriden Gelen Belgeler");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri + "\\Musteriden Alinan Teklif Onayi");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri + "\\Musteriye Verilen Teklifler");

        //        Directory.CreateDirectory(Dizin_Proje + Dizin_IsZaman_Plani);

        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Elektrik_Projesi);

        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\00 Guncel");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\01 Yedek");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\02 IO Listesi");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\00 Guncel");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\01 Yedek");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\02 Inport-Export");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\00 Guncel");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\01 Yedek");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\02 Inport-Export");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\00 Guncel");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\01 Yedek");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\02 Dokumanlar Ornekler");
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_Yardimci_Program);

        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Servis_Egitim_Formlari);

        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizim_Kullanim_Kilavuzlari);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Cizim);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Diger_Dokumanlar);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_FotografVideo);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Malzeme_Listesi);
        //        Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizim_Toplanti_Notlari);


        //        Lb_Uyari.Text = "Oluşturulan Yeni Proje Dizini: " + Dizin_Proje;


        //        //if (XLComm == null)
        //        //{
        //        //    MessageBox.Show("Galiba Excel yüklü değil. Proje Künyesi 'Excel' dosyasına kaydedilir. Bilgisayarınıza 'Excel' yükledikten sonra işlemi tekrar deneyiniz.");
        //        //    return;
        //        //}

        //        //Excel.Workbook xlWorkBook;
        //        //Excel.Worksheet xlWorkSheet;
        //        //object misValue = System.Reflection.Missing.Value;

        //        //xlWorkBook = XLComm.Workbooks.Add(misValue);
        //        //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //        //xlWorkSheet.Cells[1, 1] = "NO"; xlWorkSheet.Cells[2, 1] = "1";
        //        //xlWorkSheet.Cells[1, 2] = "TARİH"; xlWorkSheet.Cells[2, 2] = DateTime.Now.ToLongDateString();
        //        //xlWorkSheet.Cells[1, 3] = "YETKİLİ"; xlWorkSheet.Cells[2, 3] = TB_Kullanici.Text;
        //        //xlWorkSheet.Cells[1, 4] = "İŞLEM"; xlWorkSheet.Cells[2, 4] = "Yeni Proje Oluşturma";
        //        //xlWorkSheet.Cells[1, 5] = "AÇIKLAMA"; xlWorkSheet.Cells[2, 5] = "Yeni Proje Oluşturuldu. Proje için gereken klasörler hazırlandı.";

        //        //xlWorkBook.SaveAs(Dizin_Proje + "\\" + "PROJE KUNYESI - " + "P" + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + TB_Proje_Olustur_Proje_Adi.Text + ".xls",
        //        //                 Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
        //        //                 Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //        //xlWorkBook.Close(true, misValue, misValue);
        //        //XLComm.Quit();

        //        //try
        //        //{
        //        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(XLComm);
        //        //    XLComm = null;
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    XLComm = null;
        //        //    MessageBox.Show("Hata " + ex.ToString());
        //        //}
        //        //finally
        //        //{
        //        //    GC.Collect();
        //        //}
        //        YeniExcelDosyasiOlustur();

        //    }
        //    else
        //    {
        //        Lb_Uyari.Text = "Yazdığınız Proje adı kullanılıyor. \nLütfen kontrol ederek tekrar deneyiniz.";
        //    }

        //}


        //void YeniExcelDosyasiOlustur()
        //{
        //    DataTable TempDT = new DataTable();
        //    TempDT.Columns.Clear();
        //    TempDT.Columns.Add("NO");
        //    TempDT.Columns.Add("TARIH");
        //    TempDT.Columns.Add("YETKILI");
        //    TempDT.Columns.Add("ISLEM");
        //    TempDT.Columns.Add("ACIKLAMA");

        //    DataRow rowlar = TempDT.NewRow();
        //    rowlar[0] = "1";
        //    rowlar[1] = DateTime.Now.ToLongDateString();
        //    rowlar[2] = TB_Kullanici.Text;
        //    rowlar[3] = "Yeni Proje Oluşturma";
        //    rowlar[4] = "Yeni Proje Oluşturuldu. Proje için gereken klasörler hazırlandı.";
        //    TempDT.Rows.Add(rowlar);

        //    DataGridView TempDGV = new DataGridView();

        //    TempDGV.DataSource = TempDT;
        //    string Status = "";

        //    string KayitYolu = Dizin_Proje + "\\";
        //    string ExcelFileName = "PROJE KUNYESI - " + TB_Proje_Olustur_Proje_Kodu_Simgesi.Text + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + TB_Proje_Olustur_Bölüm.Text + " " + TB_Proje_Olustur_Proje_Adi.Text;

        //    SAVE_EXCEL(KayitYolu, ExcelFileName, "xls", TempDGV, false, out Status);
        //}





        void Karakter_TRtoENG()
        {
            //TB_Proje_Olustur_Bölüm.Text = ingilizcelestir(TB_Proje_Olustur_Bölüm.Text);
            //TB_Proje_Olustur_Proje_Adi.Text = ingilizcelestir(TB_Proje_Olustur_Proje_Adi.Text);
        }


        //private void TB_Proje_Olustur_Bölüm_TextChanged(object sender, EventArgs e)
        //{
        //    TB_Proje_Olustur_Bölüm.CharacterCasing = CharacterCasing.Upper;

        //}

        //private void TB_Proje_Olustur_Proje_Adi_TextChanged(object sender, EventArgs e)
        //{
        //    TB_Proje_Olustur_Proje_Adi.CharacterCasing = CharacterCasing.Upper;


        //    if (CHB_Proje_Olustur_Proje_Donemi_Degistir.Checked == false)
        //    {
        //        if (DateTime.Now.Month.ToString().Length < 2)
        //        { TB_Proje_Olustur_Proje_Donemi.Text = DateTime.Now.Year.ToString().Substring(2) + ".0" + DateTime.Now.Month.ToString(); }
        //        else
        //        { TB_Proje_Olustur_Proje_Donemi.Text = DateTime.Now.Year.ToString().Substring(2) + "." + DateTime.Now.Month.ToString(); }
        //    }

        //}

        //private void CHB_Proje_Olustur_Proje_Donemi_Degistir_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CHB_Proje_Olustur_Proje_Donemi_Degistir.Checked == true)
        //    {
        //        TB_Proje_Olustur_Proje_Donemi.ReadOnly = false;
        //        CHB_Proje_Olustur_Proje_Donemi_Degistir.Text = "Değiştir - DİKKAT!";
        //    }
        //    else
        //    {
        //        TB_Proje_Olustur_Proje_Donemi.ReadOnly = true;
        //        CHB_Proje_Olustur_Proje_Donemi_Degistir.Text = "Değiştir";
        //    }
        //}

        //private void CHB_Proje_Olustur_Proje_Kodu_Degistir_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CHB_Proje_Olustur_Proje_Kodu_Degistir.Checked == true)
        //    {
        //        Num_Proje_Olustur_Proje_Kodu_NO.ReadOnly = false;
        //        Num_Proje_Olustur_Proje_Kodu_NO.Enabled = true;
        //        CHB_Proje_Olustur_Proje_Kodu_Degistir.Text = "Değiştir - DİKKAT!";
        //    }
        //    else
        //    {
        //        Num_Proje_Olustur_Proje_Kodu_NO.ReadOnly = true;
        //        Num_Proje_Olustur_Proje_Kodu_NO.Enabled = false;
        //        CHB_Proje_Olustur_Proje_Kodu_Degistir.Text = "Değiştir";
        //    }

        //}

        //private void B_Proje_Olustur_Internet_Knt_Click(object sender, EventArgs e)
        //{
        //    InternetKontrol();
        //}

        #endregion

        #region KLAVYE DINLEME
        //globalKeyboardHook klavyeDinleyicisi = new globalKeyboardHook();
        //public void DinlenecekTuslariAyarla()
        //{
        //    // hangi tuşları dinlemek istiyorsak burada ekliyoruz
        //    // Ben burada F,K ve M harflerine basılınca tetiklenecek şekilde ayarladım
        //    klavyeDinleyicisi.HookedKeys.Add(Keys.F9);

        //    //basıldığında ilk burası çalışır
        //    klavyeDinleyicisi.KeyDown += new KeyEventHandler(islem1);
        //    //basıldıktan sonra ikinci olarak burası çalışır
        //    klavyeDinleyicisi.KeyUp += new KeyEventHandler(islem2);
        //}

        //  void islem1(object sender, KeyEventArgs e)
        //  {
        ////Yapılmasını istediğiniz kodlar burada yer alacak
        ////Burası tuşa basıldığı an çalışır



        ////Eğer buraya gelecek olan tuşa basıldığında
        ////o tuşun normal işlevi yine çalışsın istiyorsanız
        ////e.Handled değeri false olmalı
        ////eğer ilgili tuşa basıldığında burada yakalansın
        //// ve devamında tuş başka bir işlev gerçekleştirmesin
        ////istiyorsanız bu değeri true yapmalısınız
        //e.Handled = false;
        //}

        // void islem2(object sender, KeyEventArgs e)
        // {
        ////Yapılmasını istediğiniz kodlar burada yer alacak
        //// Burası ilgili tuşlara basılıp çekildikten sonra çalışır
        //     if (WindowState == FormWindowState.Minimized)
        //     {
        //         WindowState = FormWindowState.Normal;
        //     }


        ////Eğer buraya gelecek olan tuşa basıldığında
        ////o tuşun normal işlevi yine çalışsın istiyorsanız
        ////e.Handled değeri false olmalı
        ////eğer ilgili tuşa basıldığında burada yakalansın
        //// ve devamında tuş başka bir işlev gerçekleştirmesin
        ////istiyorsanız bu değeri true yapmalısınız
        //e.Handled = true;
        //}
        #endregion

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    CLS.CreateFolder.Create_Yeni_Musteri_Klasor("0001", "AKSA");
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    CLS.CreateFolder.Create_Yeni_Proje_Klasor("0001", "AKSA", "P0010118002");
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    CLS.CreateFolder.Create_YeniRevizyon("0001", "AKSA", "P0010118002", "R01", out string a);
        //}


        #region PUBLIC VARIABLE


        //public string ProjeDonemi;

        //public string Dizin_ProjeRoot;
        //public string Dizin_Musteri_Firma;
        //public string Dizin_Proje;

        //public string Dizin_Musteri_Iliskileri      = "\\P1 Musteri Iliskileri";
        //public string Dizin_Teklif_Belgeleri        = "\\Teklif ve Ilgili Belgeler";
        //public string Dizin_IsZaman_Plani           = "\\P2 Proje Is-Zaman Plani";
        //public string Dizin_Elektrik_Projesi        = "\\P3 Elektrik Projesi";

        //public string Dizin_Yazilim                 = "\\P4 Yazilim";
        //public string Dizin_PLC_Program             = "\\00 PLC";
        //public string Dizin_HMI_Program             = "\\01 HMI";
        //public string Dizin_SCADA_Program           = "\\02 SCADA";
        //public string Dizin_PC_Program              = "\\03 PC";
        //public string Dizin_Yardimci_Program        = "\\04 Yardimci Programlar";

        //public string Dizin_Servis_Egitim_Formlari  = "\\P5 Proje Teslim Egitim Servis Formlari";
        //public string Dizin_Dokumanlar              = "\\P6 Dokumanlar";
        //public string Dizin_Cizim                   = "\\Cizim";
        //public string Dizin_Malzeme_Listesi         = "\\Malzeme Listesi";
        //public string Dizim_Toplanti_Notlari        = "\\Toplanti Notlari";
        //public string Dizim_Kullanim_Kilavuzlari    = "\\Cihaz Kullanim Kilavuzlari";
        //public string Dizin_Diger_Dokumanlar        = "\\Diger";
        //public string Dizin_FotografVideo           = "\\Fotograf Video";


        //public string Klasor_PLC_Program;
        //public string Klasor_HMI_Program;
        //public string Klasor_SCADA_Program;
        //public string Klasor_YARD_Program;
        //public string Klasor_PC_Program;
        //public string Klasor_Malzeme_Listesi;
        //public string Klasor_Elektrik_Projesi;
        //public string Klasor_Cizimler;
        //public string Klasor_Musteri_Iliskileri;
        //public string Klasor_Teklif_Belgeleri;
        //public string Klasor_Servis_Egitim_Formlari;
        //public string Klasor_Dokumanlar;
        //public string Klasor_Diger_Dokumanlar;
        //public string Klasor_FotografVideo;
        //public string Klasor_Tum_Dokumanlar;
        //public string Klasor_Is_Zaman_Plani;

        #endregion


        public void Create()
        {

            //Dizin_Musteri_Firma = Anadizin + CB_Proje_Olustur_Musteri_Firma.Text;

            //string Proje_Olustur_Bolum_Knt;
            //if (TB_Proje_Olustur_Bölüm.Text != "")
            //{ Proje_Olustur_Bolum_Knt = TB_Proje_Olustur_Bölüm.Text + " "; }
            //else { Proje_Olustur_Bolum_Knt = TB_Proje_Olustur_Bölüm.Text; }

            //Dizin_Proje = Dizin_Musteri_Firma + "\\" + TB_Proje_Olustur_Proje_Kodu_Simgesi.Text + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + CB_Proje_Olustur_Musteri_Firma.Text + " - " + Proje_Olustur_Bolum_Knt + TB_Proje_Olustur_Proje_Adi.Text;
            //Dizin_Proje = Dizin_ProjeRoot + "\\" + MusteriNo;


            //if (!Directory.Exists(Dizin_Proje))
            //{

            //    Dizin_Proje = Dizin_ProjeRoot;

            //    Directory.CreateDirectory(Dizin_Proje);

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri); //P1 Musteriden Gelenler
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\E-Mailler");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteri Talebi ve Degisiklikleri");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteriden Gelen Belgeler");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + "\\Musteriden Gelen Belgeler");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri + "\\Musteriden Alinan Teklif Onayi");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri + "\\Musteriye Verilen Teklifler");

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_IsZaman_Plani);

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Elektrik_Projesi);

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\00 Guncel");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\01 Yedek");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PLC_Program + "\\02 IO Listesi");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\00 Guncel");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\01 Yedek");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_HMI_Program + "\\02 Inport-Export");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\00 Guncel");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\01 Yedek");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_SCADA_Program + "\\02 Inport-Export");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\00 Guncel");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\01 Yedek");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_PC_Program + "\\02 Dokumanlar Ornekler");
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Yazilim + Dizin_Yardimci_Program);

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Servis_Egitim_Formlari);

            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizim_Kullanim_Kilavuzlari);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Cizim);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Diger_Dokumanlar);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_FotografVideo);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizin_Malzeme_Listesi);
            //    Directory.CreateDirectory(Dizin_Proje + Dizin_Dokumanlar + Dizim_Toplanti_Notlari);


            //  Lb_Uyari.Text = "Oluşturulan Yeni Proje Dizini: " + Dizin_Proje;


            //if (XLComm == null)
            //{
            //    MessageBox.Show("Galiba Excel yüklü değil. Proje Künyesi 'Excel' dosyasına kaydedilir. Bilgisayarınıza 'Excel' yükledikten sonra işlemi tekrar deneyiniz.");
            //    return;
            //}

            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlWorkBook = XLComm.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //xlWorkSheet.Cells[1, 1] = "NO"; xlWorkSheet.Cells[2, 1] = "1";
            //xlWorkSheet.Cells[1, 2] = "TARİH"; xlWorkSheet.Cells[2, 2] = DateTime.Now.ToLongDateString();
            //xlWorkSheet.Cells[1, 3] = "YETKİLİ"; xlWorkSheet.Cells[2, 3] = TB_Kullanici.Text;
            //xlWorkSheet.Cells[1, 4] = "İŞLEM"; xlWorkSheet.Cells[2, 4] = "Yeni Proje Oluşturma";
            //xlWorkSheet.Cells[1, 5] = "AÇIKLAMA"; xlWorkSheet.Cells[2, 5] = "Yeni Proje Oluşturuldu. Proje için gereken klasörler hazırlandı.";

            //xlWorkBook.SaveAs(Dizin_Proje + "\\" + "PROJE KUNYESI - " + "P" + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + TB_Proje_Olustur_Proje_Adi.Text + ".xls",
            //                 Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
            //                 Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.Close(true, misValue, misValue);
            //XLComm.Quit();

            //try
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(XLComm);
            //    XLComm = null;
            //}
            //catch (Exception ex)
            //{
            //    XLComm = null;
            //    MessageBox.Show("Hata " + ex.ToString());
            //}
            //finally
            //{
            //    GC.Collect();
            //}
            //YeniExcelDosyasiOlustur();

            //}
            //else
            //{
            //  //  Lb_Uyari.Text = "Yazdığınız Proje adı kullanılıyor. \nLütfen kontrol ederek tekrar deneyiniz.";
            //}

        }


        void YeniExcelDosyasiOlustur()
        {
            //DataTable TempDT = new DataTable();
            //TempDT.Columns.Clear();
            //TempDT.Columns.Add("NO");
            //TempDT.Columns.Add("TARIH");
            //TempDT.Columns.Add("YETKILI");
            //TempDT.Columns.Add("ISLEM");
            //TempDT.Columns.Add("ACIKLAMA");

            //DataRow rowlar = TempDT.NewRow();
            //rowlar[0] = "1";
            //rowlar[1] = DateTime.Now.ToLongDateString();
            //rowlar[2] = TB_Kullanici.Text;
            //rowlar[3] = "Yeni Proje Oluşturma";
            //rowlar[4] = "Yeni Proje Oluşturuldu. Proje için gereken klasörler hazırlandı.";
            //TempDT.Rows.Add(rowlar);

            //DataGridView TempDGV = new DataGridView();

            //TempDGV.DataSource = TempDT;
            //string Status = "";

            //string KayitYolu = Dizin_Proje + "\\";
            //string ExcelFileName = "PROJE KUNYESI - " + TB_Proje_Olustur_Proje_Kodu_Simgesi.Text + Num_Proje_Olustur_Proje_Kodu_NO.Text + " " + TB_Proje_Olustur_Bölüm.Text + " " + TB_Proje_Olustur_Proje_Adi.Text;

            //SAVE_EXCEL(KayitYolu, ExcelFileName, "xls", TempDGV, false, out Status);
        }


        #region PROJE SORGULAMA




        #endregion



        //      private void B_UzantiSecimTemizle_Click(object sender, EventArgs e)
        //      {

        //      }

        //      private void B_PLC_Program_DizinGeri_Click(object sender, EventArgs e)
        //      {
        ////          if (WB_PLC_Program.CanGoBack) { WB_PLC_Program.GoBack(); }
        //      }

        //private void B_PLC_Program_DizinLinkCopy_Click(object sender, EventArgs e)
        //{
        //    Clipboard.SetText(Klasor_PLC_Program);
        //}

        //private void B_HMI_Program_DizinGeri_Click(object sender, EventArgs e)
        //{
        //    if (WB_HMI_Program.CanGoBack) { WB_HMI_Program.GoBack(); }
        //}

        //private void CB_Proje_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}


        #region   PROJE GECMİSİ OLUTUR ESKİ ÇALIŞMALAR

        //public DataGridView DGV_ProjeAramaGecmisi = new DataGridView();

        //public string ProjeGecmisDGVKontrol()
        //{
        //    DGV_ProjeAramaGecmisi.RowHeadersVisible = false;
        //    try
        //    {
        //        CLS.EXL.READ_ExcelFile(DGV_ProjeAramaGecmisi, CLS.ProjeAramaGecmisi_ExcelFiles, false, CLS.Form_Main.CB_ProjeAramaGecmisiExlSayfasi);

        //        if (DGV_ProjeAramaGecmisi.RowCount < 2)
        //        {
        //            DataGridView Temp = new DataGridView();
        //            Temp.RowHeadersVisible = false;

        //            Temp.Columns.Add("ID", "ID");
        //            Temp.Columns.Add("MusteriAdi", "MusteriAdi");
        //            Temp.Columns.Add("MusteriBolum", "MusteriBolum");
        //            Temp.Columns.Add("ProjeAdi", "ProjeAdi");
        //            Temp.Columns.Add("RevizyonAdi", "RevizyonAdi");
        //            Temp.Columns.Add("RevizyonNo", "RevizyonNo");
        //            Temp.Columns.Add("ProjeKodu", "ProjeKodu");
        //            Temp.Columns.Add("ProjePath", "ProjePath");

        //            Temp.Rows.Add();
        //            Temp.Rows[0].Cells[0].Value = "ID";
        //            Temp.Rows[0].Cells[1].Value = "MusteriAdi";
        //            Temp.Rows[0].Cells[2].Value = "MusteriBolum";
        //            Temp.Rows[0].Cells[3].Value = "ProjeAdi";
        //            Temp.Rows[0].Cells[4].Value = "RevizyonAdi";
        //            Temp.Rows[0].Cells[5].Value = "RevizyonNo";
        //            Temp.Rows[0].Cells[6].Value = "ProjeKodu";
        //            Temp.Rows[0].Cells[7].Value = "ProjePath";

        //            string a = CLS.EXL.WRITE_DGVToExcelSave(Temp, CLS.ProjeAramaGecmisi_ExcelFiles, false);

        //            Temp.Columns.Clear();
        //        }

        //        DGV_ProjeAramaGecmisi.Columns.Clear();
        //        string b = CLS.EXL.READ_ExcelFile(DGV_ProjeAramaGecmisi, CLS.ProjeAramaGecmisi_ExcelFiles, true, CLS.Form_Main.CB_ProjeAramaGecmisiExlSayfasi);

        //        return "OK!";
        //    }
        //    catch (Exception HATA)
        //    {

        //        return "ERR!" + HATA.ToString();
        //    }

        //}

        //public string ProjeGecmisiKaydet()
        //{
        //    try
        //    {

        //        bool Kayit_Izin = true;
        //        int sw = 0;
        //        switch (sw)
        //        {
        //            case 0:
        //                ProjeGecmisDGVKontrol();

        //                goto case 1;
        //            case 1:
        //                for (int i = 0; i < DGV_ProjeAramaGecmisi.RowCount - 1; i++)
        //                {
        //                    if (DGV_ProjeAramaGecmisi.Rows[i].Cells[6].Value.ToString() == CLS.Form_Main.TB_Sorgu_ProjeKodu.Text)
        //                    {
        //                        Kayit_Izin = false;
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        Kayit_Izin = true;
        //                    }
        //                }

        //                goto case 2;
        //            case 2:
        //                if (Kayit_Izin)
        //                {
        //                    DataGridView DGVTemp = new DataGridView();
        //                    DGVTemp.Columns.Add("ID", "ID");
        //                    DGVTemp.Columns.Add("MusteriAdi", "MusteriAdi");
        //                    DGVTemp.Columns.Add("MusteriBolum", "MusteriBolum");
        //                    DGVTemp.Columns.Add("ProjeAdi", "ProjeAdi");
        //                    DGVTemp.Columns.Add("RevizyonAdi", "RevizyonAdi");
        //                    DGVTemp.Columns.Add("RevizyonNo", "RevizyonNo");
        //                    DGVTemp.Columns.Add("ProjeKodu", "ProjeKodu");
        //                    DGVTemp.Columns.Add("ProjePath", "ProjePath");
        //                    DGVTemp.RowHeadersVisible = false;


        //                    DataGridViewRow rows = (DataGridViewRow)DGVTemp.Rows[0].Clone();
        //                    rows.Cells[0].Value = "";
        //                    rows.Cells[1].Value = CLS.Form_Main.CB_Sorgu_MusteriAdi.Text;
        //                    rows.Cells[2].Value = CLS.Form_Main.CB_Sorgu_BolumAdi.Text;
        //                    rows.Cells[3].Value = CLS.Form_Main.CB_Sorgu_ProjeAdi.Text;
        //                    rows.Cells[4].Value = CLS.Form_Main.CB_Sorgu_RevAdi.Text;
        //                    rows.Cells[5].Value = CLS.Form_Main.CB_Sorgu_RevNo.Text;
        //                    rows.Cells[6].Value = CLS.Form_Main.TB_Sorgu_ProjeKodu.Text;
        //                    rows.Cells[7].Value = CLS.Form_Main.TB_Sorgu_ProjeYolu.Text;




        //                    if (DGV_ProjeAramaGecmisi.RowCount > 1)
        //                    {
        //                        for (int i = 0; i < DGV_ProjeAramaGecmisi.RowCount - 1; i++)
        //                        {
        //                            for (int K = 0; K < DGV_ProjeAramaGecmisi.ColumnCount; K++)
        //                            {
        //                                DGVTemp.Rows[i].Cells[K].Value = DGV_ProjeAramaGecmisi.Rows[i].Cells[K].Value;
        //                            }

        //                        }
        //                    }
        //                    else
        //                    {
        //                        DGVTemp.Rows.Add();
        //                        DGVTemp.Rows[0].Cells[0].Value = "ID";
        //                        DGVTemp.Rows[0].Cells[1].Value = "MusteriAdi";
        //                        DGVTemp.Rows[0].Cells[2].Value = "MusteriBolum";
        //                        DGVTemp.Rows[0].Cells[3].Value = "ProjeAdi";
        //                        DGVTemp.Rows[0].Cells[4].Value = "RevizyonAdi";
        //                        DGVTemp.Rows[0].Cells[5].Value = "RevizyonNo";
        //                        DGVTemp.Rows[0].Cells[6].Value = "ProjeKodu";
        //                        DGVTemp.Rows[0].Cells[7].Value = "ProjePath";
        //                    }



        //                    DGVTemp.Rows.Add(rows);

        //                    string Status = CLS.EXL.WRITE_DGVToExcelSave(DGVTemp, CLS.ProjeAramaGecmisi_ExcelFiles, false);
        //                }

        //                CLS.EXL.WRITE_NewRows(CLS.ProjeAramaGecmisi_ExcelFiles, false);
        //                break;

        //        }

        //        return "OK!";
        //    }
        //    catch (Exception HATA)
        //    {


        //        return "ERR!";
        //    }
        //}


        //public string MusteriFirma_ExcelDosyasiOlustur(string MusteriKlasorPath, string müsteriNo, string MusteriAdi, string Notlar, string Detaylar)
        //{
        //    try
        //    {
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("ID", "ID");
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("KayitTarih", "KayitTarih");
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("KayitUser", "KayitUser");
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("Notlar", "Notlar");
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("Islem", "Islem");
        //        CLS.Form_Main.DGV_TempForExl.Columns.Add("Detaylar", "Detaylar");
        //        CLS.Form_Main.DGV_TempForExl.Rows.Add();

        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[0].Value = 1;
        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[1].Value = DateTime.Now.ToString();
        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[2].Value = CLS.Form_Main.LB_UserName.Text;
        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[3].Value = Notlar;
        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[4].Value = "Yeni bir müşteri firma oluşturuldu.";
        //        CLS.Form_Main.DGV_TempForExl.Rows[0].Cells[5].Value = Detaylar;
        //        string ProjeKuneyesiYolu = MusteriKlasorPath + "\\" + müsteriNo + " " + MusteriAdi + " - MÜŞTERİ KUNYESI.xls";

        //        string a = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGV_TempForExl, ProjeKuneyesiYolu, false);

        //        CLS.Form_Main.DGV_TempForExl.Columns.Clear();

        //        return "OK!";
        //    }
        //    catch (Exception HATA)
        //    {
        //        CLS.Log.ERR_LOGS(HATA.ToString());
        //        return "ERR!";
        //    }

        //}

        #endregion


        #region ESKİ Main CLASS KODLARI

        // FORMLAR
        //CLS.Form_Main = this;
        //CLS.Form_VersiyonYukle = Form_VersiyonYukle;
        //CLS.Form_Starting = Form_Starting;
        //CLS.Form_Yeni_Musteri = Form_Yeni_Musteri;
        //CLS.Form_Yeni_MusteriBolum = Form_Yeni_MusteriBolum;
        //CLS.Form_Yeni_Yetkili = Form_Yeni_Yetkili;
        //CLS.Form_Yeni_User = Form_Yeni_User;
        //CLS.Form_Yeni_Proje = Form_Yeni_Proje;
        //CLS.Form_Yeni_Revizyon = Form_Yeni_Revizyon;
        //CLS.Form_PrgSecim = Form_PrgSecim;

        //CLS.FirstStart = FirstStart;
        //CLS.Crypto = Crypto;
        //CLS.Log = Log;
        //CLS.PrgSettings = PrgSettings;
        //CLS.TextCheck = TextCheck;
        //CLS.UserLogin = UserLogin;
        //CLS.Bildirimler = Bildirimler;
        //CLS.ProjeSorgulama = ProjeSorgulama;
        //CLS.AutoUpdate = AutoUpdate;

        //CLS.CreateAuthorized = CreateAuthorized;
        //CLS.CreateCustomer = CreateCustomer;
        //CLS.CreateDepartment = CreateDepartment;
        //CLS.CreateFolder = CreateFolder;
        //CLS.CreateProject = CreateProject;

        //CLS.ID_MySQL = ID_MySQL;
        //CLS.MySQL = MySQL;
        //CLS.MySQLVar = MySQLVar;

        //CLS.TaskSchedulerCtrl = TaskSchedulerCtrl;
        //CLS.NetworkAdapter = NetworkAdapter;
        //CLS.ProjeSorgulamaGecmisi = ProjeSorgulamaGecmisi;
        //CLS.PrgSecimi = PrgSecimi;



        //public PrgSettings PrgSettings = new PrgSettings();
        //public TextCheck TextCheck = new TextCheck();

        //public CreateAuthorized CreateAuthorized = new CreateAuthorized();
        //public CreateCustomer CreateCustomer = new CreateCustomer();
        //public CreateDepartment CreateDepartment = new CreateDepartment();
        //public CreateFolder CreateFolder = new CreateFolder();
        //public CreateProject CreateProject = new CreateProject();

        //public ID_MySQL ID_MySQL = new ID_MySQL();
        //public MySQL MySQL = new MySQL();
        //public MySQLVar MySQLVar = new MySQLVar();

        //public Form_VersiyonYukle           Form_VersiyonYukle;
        //public Form_Starting                Form_Starting;
        //public Form_Main                    Form_Main;
        //public Form_Yeni_Musteri            Form_Yeni_Musteri;
        //public Form_Yeni_MusteriBolum       Form_Yeni_MusteriBolum;
        //public Form_Yeni_Yetkili            Form_Yeni_Yetkili;
        //public Form_Yeni_User               Form_Yeni_User;
        //public Form_Yeni_Proje              Form_Yeni_Proje;
        //public Form_Yeni_Revizyon           Form_Yeni_Revizyon;
        //public Form_PrgSecim                Form_PrgSecim;

        //public FirstStart                   FirstStart;
        //public Crypto                       Crypto;
        //public Log                          Log;
        //public PrgSettings                  PrgSettings;
        //public TextCheck                    TextCheck;
        //public UserLogin                    UserLogin;
        //public Bildirimler                  Bildirimler;
        //public ProjeSorgulama               ProjeSorgulama;
        //public AutoUpdate                   AutoUpdate;

        //public CreateAuthorized             CreateAuthorized;
        //public CreateCustomer               CreateCustomer;
        //public CreateDepartment             CreateDepartment;
        //public CreateFolder                 CreateFolder;
        //public CreateProject                CreateProject;

        //public ID_MySQL                     ID_MySQL;
        //public MySQL                        MySQL;
        //public MySQLVar                     MySQLVar;

        //public TaskSchedulerCtrl            TaskSchedulerCtrl;
        //public NetworkAdapter               NetworkAdapter;
        //public ProjeSorgulamaGecmisi        ProjeSorgulamaGecmisi;
        //public PrgSecimi                    PrgSecimi;



        #endregion


        #region ESKİ ARAMA SONUCU KLASOR GOSTERME METODU


        //GroupBox Grp_Sorgu_PrgHMI = new GroupBox();
        //WebBrowser WB_Sorgu_PrgHMI = new WebBrowser();
        //Button B_Geri_Sorgu_PrgHMI = new Button();
        //Button B_Ac_Sorgu_PrgHMI = new Button();
        //Button B_CopyLink_Sorgu_PrgHMI = new Button();
        //PictureBox Pic_Sorgu_PrgHMI = new PictureBox();

        //GroupBox Grp_Sorgu_PrgPLC = new GroupBox();
        //WebBrowser WB_Sorgu_PrgPLC = new WebBrowser();
        //Button B_Geri_Sorgu_PrgPLC = new Button();
        //Button B_Ac_Sorgu_PrgPLC = new Button();
        //Button B_CopyLink_Sorgu_PrgPLC = new Button();
        //PictureBox Pic_Sorgu_PrgPLC = new PictureBox();

        //GroupBox Grp_Sorgu_Programlar = new GroupBox();
        //WebBrowser WB_Sorgu_Programlar = new WebBrowser();
        //Button B_Geri_Sorgu_Programlar = new Button();
        //Button B_Ac_Sorgu_Programlar = new Button();
        //Button B_CopyLink_Sorgu_Programlar = new Button();
        //PictureBox Pic_Sorgu_Programlar = new PictureBox();

        //GroupBox Grp_Sorgu_PrgDiger = new GroupBox();
        //WebBrowser WB_Sorgu_PrgDiger = new WebBrowser();
        //Button B_Geri_Sorgu_PrgDiger = new Button();
        //Button B_Ac_Sorgu_PrgDiger = new Button();
        //Button B_CopyLink_Sorgu_PrgDiger = new Button();
        //PictureBox Pic_Sorgu_PrgDiger = new PictureBox();

        //GroupBox Grp_Sorgu_Cizimler = new GroupBox();
        //WebBrowser WB_Sorgu_Cizimler = new WebBrowser();
        //Button B_Geri_Sorgu_Cizimler = new Button();
        //Button B_Ac_Sorgu_Cizimler = new Button();
        //Button B_CopyLink_Sorgu_Cizimler = new Button();
        //PictureBox Pic_Sorgu_Cizimler = new PictureBox();

        //GroupBox Grp_Sorgu_ElektrikPrj = new GroupBox();
        //WebBrowser WB_Sorgu_ElektrikPrj = new WebBrowser();
        //Button B_Geri_Sorgu_ElektrikPrj = new Button();
        //Button B_Ac_Sorgu_ElektrikPrj = new Button();
        //Button B_CopyLink_Sorgu_ElektrikPrj = new Button();
        //PictureBox Pic_Sorgu_ElektrikPrj = new PictureBox();

        //GroupBox Grp_Sorgu_MalzemeListesi = new GroupBox();
        //WebBrowser WB_Sorgu_MalzemeListesi = new WebBrowser();
        //Button B_Geri_Sorgu_MalzemeListesi = new Button();
        //Button B_Ac_Sorgu_MalzemeListesi = new Button();
        //Button B_CopyLink_Sorgu_MalzemeListesi = new Button();
        //PictureBox Pic_Sorgu_MalzemeListesi = new PictureBox();


        //GroupBox Grp_Sorgu_PrgPC = new GroupBox();
        //WebBrowser WB_Sorgu_PrgPC = new WebBrowser();
        //Button B_Geri_Sorgu_PrgPC = new Button();
        //Button B_Ac_Sorgu_PrgPC = new Button();
        //Button B_CopyLink_Sorgu_PrgPC = new Button();
        //PictureBox Pic_Sorgu_PrgPC = new PictureBox();

        //GroupBox Grp_Sorgu_Dokumanlar = new GroupBox();
        //WebBrowser WB_Sorgu_Dokumanlar = new WebBrowser();
        //Button B_Geri_Sorgu_Dokumanlar = new Button();
        //Button B_Ac_Sorgu_Dokumanlar = new Button();
        //Button B_CopyLink_Sorgu_Dokumanlar = new Button();
        //PictureBox Pic_Sorgu_Dokumanlar = new PictureBox();

        //GroupBox Grp_Sorgu_CihazDokumanlari = new GroupBox();
        //WebBrowser WB_Sorgu_CihazDokumanlari = new WebBrowser();
        //Button B_Geri_Sorgu_CihazDokumanlari = new Button();
        //Button B_Ac_Sorgu_CihazDokumanlari = new Button();
        //Button B_CopyLink_Sorgu_CihazDokumanlari = new Button();
        //PictureBox Pic_Sorgu_CihazDokumanlari = new PictureBox();

        //GroupBox Grp_Sorgu_DigerDokumanlar = new GroupBox();
        //WebBrowser WB_Sorgu_DigerDokumanlar = new WebBrowser();
        //Button B_Geri_Sorgu_DigerDokumanlar = new Button();
        //Button B_Ac_Sorgu_DigerDokumanlar = new Button();
        //Button B_CopyLink_Sorgu_DigerDokumanlar = new Button();
        //PictureBox Pic_Sorgu_DigerDokumanlar = new PictureBox();

        //GroupBox Grp_Sorgu_Formlar = new GroupBox();
        //WebBrowser WB_Sorgu_Formlar = new WebBrowser();
        //Button B_Geri_Sorgu_Formlar = new Button();
        //Button B_Ac_Sorgu_Formlar = new Button();
        //Button B_CopyLink_Sorgu_Formlar = new Button();
        //PictureBox Pic_Sorgu_Formlar = new PictureBox();

        //GroupBox Grp_Sorgu_MusteriIliskileri = new GroupBox();
        //WebBrowser WB_Sorgu_MusteriIliskileri = new WebBrowser();
        //Button B_Geri_Sorgu_MusteriIliskileri = new Button();
        //Button B_Ac_Sorgu_MusteriIliskileri = new Button();
        //Button B_CopyLink_Sorgu_MusteriIliskileri = new Button();
        //PictureBox Pic_Sorgu_MusteriIliskileri = new PictureBox();

        //GroupBox Grp_Sorgu_IsZamanPlani = new GroupBox();
        //WebBrowser WB_Sorgu_IsZamanPlani = new WebBrowser();
        //Button B_Geri_Sorgu_IsZamanPlani = new Button();
        //Button B_Ac_Sorgu_IsZamanPlani = new Button();
        //Button B_CopyLink_Sorgu_IsZamanPlani = new Button();
        //PictureBox Pic_Sorgu_IsZamanPlani = new PictureBox();


        //GroupBox Grp_Sorgu_FotografVideo = new GroupBox();
        //WebBrowser WB_Sorgu_FotografVideo = new WebBrowser();
        //Button B_Geri_Sorgu_FotografVideo = new Button();
        //Button B_Ac_Sorgu_FotografVideo = new Button();
        //Button B_CopyLink_Sorgu_FotografVideo = new Button();
        //PictureBox Pic_Sorgu_FotografVideo = new PictureBox();
        //public void KlasorSorguCevabiListele(GroupBox Grup, WebBrowser WBrowser, Button BGeri, Button BAc, Button LinkCpy, PictureBox Pic, Image Img, string[] Textler) //  string URL, string GrupAdi,  )
        //{
        //    try
        //    {
        //        //Textler[0] Grup ADI
        //        //Textler[1] Klasör URL
        //        //Textler[2] Buton Geri Name
        //        //Textler[3] Buton Ac Name
        //        //Textler[4] Buton Link Copy Name
        //        //Textler[5] Web Browser Name
        //        //Textler[6] 
        //        //Textler[7] 
        //        //Textler[8] 
        //        //Textler[9] 

        //        // // GRUP
        //        // // System.Windows.Forms.GroupBox g = new System.Windows.Forms.GroupBox();
        //        // Grup.Name = "Grp";
        //        // Grup.Text = Textler[0];
        //        // Grup.Size = new Size(470, 175); //(502, 165);
        //        // Grup.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        //        // // BROWSER
        //        // // System.Windows.Forms.WebBrowser Wb = new System.Windows.Forms.WebBrowser();
        //        // WBrowser.Name = Textler[5];
        //        // WBrowser.Location = new Point(2, 20);
        //        // WBrowser.Size = new Size(445, 143);
        //        // WBrowser.Url = new Uri(Textler[1]);
        //        // Grup.Controls.Add(WBrowser);

        //        // // BUTON - AÇ
        //        // // System.Windows.Forms.Button BtnGeri = new System.Windows.Forms.Button();
        //        // BAc.Name = Textler[3];
        //        // BAc.Text = "Aç";
        //        // BAc.Location = new Point(446, 75);
        //        // BAc.Size = new Size(54, 25);
        //        // BAc.Click += new EventHandler(ButonAc); // dinamik olarak oluşturulan butonu kontrol etmek için her oluşturulan butonun clik olayına atıyoruz.
        //        // Grup.Controls.Add(BAc);

        //        // // BUTON - GERİ
        //        // // System.Windows.Forms.Button BtnGeri = new System.Windows.Forms.Button();
        //        // BGeri.Name = Textler[2];
        //        // BGeri.Text = "Geri";
        //        // BGeri.Location = new Point(446, 100);
        //        // BGeri.Size = new Size(54, 25);
        //        // BGeri.Click += new EventHandler(ButonGeri); // dinamik olarak oluşturulan butonu kontrol etmek için her oluşturulan butonun clik olayına atıyoruz.
        //        // Grup.Controls.Add(BGeri);

        //        // // BUTON - LİNK COPY
        //        //// System.Windows.Forms.Button BLinkCpy = new System.Windows.Forms.Button();
        //        // LinkCpy.Name = Textler[4];
        //        // LinkCpy.Text = " Link\nAl"; //\nCopy";
        //        // LinkCpy.Location = new Point(446, 125);
        //        // LinkCpy.Size = new Size(54, 38);
        //        // LinkCpy.Click += ButonLinkCopy; // new EventHandler(ButonLinkCopy); // dinamik olarak oluşturulan butonu kontrol etmek için her oluşturulan butonun clik olayına atıyoruz.
        //        // Grup.Controls.Add(LinkCpy);

        //        // Pic.Name = Textler[5];
        //        // Pic.Location = new Point(456, 10);
        //        // Pic.Size = new Size(38, 38);
        //        // Pic.SizeMode = PictureBoxSizeMode.StretchImage;
        //        // Pic.Image = Img;
        //        // Grup.Controls.Add(Pic);

        //        // CLS.Form_Main.FP_SorguCevaplari.Controls.Add(Grup);
        //    }
        //    catch (Exception HATA)
        //    {
        //        CLS.Log.ERR_LOGS(HATA.ToString());
        //    }

        //}
        //public void ButonGeri(object sender, EventArgs e)
        //{
        //    Button DinamikButon = (sender as Button);
        //    if (DinamikButon.Name == "B_Geri_Sorgu_PrgPLC" && WB_Sorgu_PrgPLC.CanGoBack == true) { WB_Sorgu_PrgPLC.Navigate(KlasorYolu_PLC); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_PrgHMI" && WB_Sorgu_PrgHMI.CanGoBack == true) { WB_Sorgu_PrgHMI.Navigate(KlasorYolu_HMI); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_PrgPC" && WB_Sorgu_PrgPC.CanGoBack == true) { WB_Sorgu_PrgPC.Navigate(KlasorYolu_PC); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_PrgDiger" && WB_Sorgu_PrgDiger.CanGoBack == true) { WB_Sorgu_PrgDiger.Navigate(KlasorYolu_PrgDiger); }

        //    if (DinamikButon.Name == "B_Geri_Sorgu_MusteriIliskileri" && WB_Sorgu_MusteriIliskileri.CanGoBack == true) { WB_Sorgu_MusteriIliskileri.Navigate(KlasorYolu_MusteriIliskileri); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_MalzemeListesi" && WB_Sorgu_MalzemeListesi.CanGoBack == true) { WB_Sorgu_MalzemeListesi.Navigate(KlasorYolu_MalzemeListesi); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_ElektrikPrj" && WB_Sorgu_ElektrikPrj.CanGoBack == true) { WB_Sorgu_ElektrikPrj.Navigate(KlasorYolu_ElektrikProjesi); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_Programlar" && WB_Sorgu_Programlar.CanGoBack == true) { WB_Sorgu_Programlar.Navigate(KlasorYolu_Programlar); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_Dokumanlar" && WB_Sorgu_Dokumanlar.CanGoBack == true) { WB_Sorgu_Dokumanlar.Navigate(KlasorYolu_Dokumanlar); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_FotografVideo" && WB_Sorgu_FotografVideo.CanGoBack == true) { WB_Sorgu_FotografVideo.Navigate(KlasorYolu_FotografVideo); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_IsZamanPlani" && WB_Sorgu_IsZamanPlani.CanGoBack == true) { WB_Sorgu_IsZamanPlani.Navigate(KlasorYolu_IsZamanPlani); }

        //    if (DinamikButon.Name == "B_Geri_Sorgu_CihazDokumanlari" && WB_Sorgu_CihazDokumanlari.CanGoBack == true) { WB_Sorgu_CihazDokumanlari.Navigate(KlasorYolu_Cihazlar); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_Cizimler" && WB_Sorgu_Cizimler.CanGoBack == true) { WB_Sorgu_Cizimler.Navigate(KlasorYolu_Cizimler); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_DigerDokumanlar" && WB_Sorgu_DigerDokumanlar.CanGoBack == true) { WB_Sorgu_DigerDokumanlar.Navigate(KlasorYolu_DigerDokumanlar); }
        //    if (DinamikButon.Name == "B_Geri_Sorgu_Formlar" && WB_Sorgu_Formlar.CanGoBack == true) { WB_Sorgu_Formlar.Navigate(KlasorYolu_Formlar); }

        //    //if (DinamikButon.Name == "B_Geri_Is_Zaman_Plani" && WB_Is_Zaman_Plani.CanGoBack == true) { WB_Is_Zaman_Plani.GoBack(); }
        //}
        //public void ButonAc(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //   Button DinamikButon =  (sender as Button);

        //        string Name = ((Button)sender).Name;
        //        string myDocspath = "";// = TreeView_SeciliDizin; // Buraya istediğimiz dosyanın yolunu yazıyorz

        //        if (Name == "B_Ac_Sorgu_PrgPLC") { myDocspath = KlasorYolu_PLC; }
        //        if (Name == "B_Ac_Sorgu_PrgHMI") { myDocspath = KlasorYolu_HMI; }
        //        if (Name == "B_Ac_Sorgu_PrgPC") { myDocspath = KlasorYolu_PC; }
        //        if (Name == "B_Ac_Sorgu_PrgDiger") { myDocspath = KlasorYolu_PrgDiger; }

        //        if (Name == "B_Ac_Sorgu_MusteriIliskileri") { myDocspath = KlasorYolu_MusteriIliskileri; }
        //        if (Name == "B_Ac_Sorgu_MalzemeListesi") { myDocspath = KlasorYolu_MalzemeListesi; }
        //        if (Name == "B_Ac_Sorgu_ElektrikPrj") { myDocspath = KlasorYolu_ElektrikProjesi; }
        //        if (Name == "B_Ac_Sorgu_Programlar") { myDocspath = KlasorYolu_Programlar; }
        //        if (Name == "B_Ac_Sorgu_Dokumanlar") { myDocspath = KlasorYolu_Dokumanlar; }
        //        if (Name == "B_Ac_Sorgu_FotografVideo") { myDocspath = KlasorYolu_FotografVideo; }
        //        if (Name == "B_Ac_Sorgu_IsZamanPlani") { myDocspath = KlasorYolu_IsZamanPlani; }

        //        if (Name == "B_Ac_Sorgu_CihazDokumanlari") { myDocspath = KlasorYolu_Cihazlar; }
        //        if (Name == "B_Ac_Sorgu_Cizimler") { myDocspath = KlasorYolu_Cizimler; }
        //        if (Name == "B_Ac_Sorgu_DigerDokumanlar") { myDocspath = KlasorYolu_DigerDokumanlar; }
        //        if (Name == "B_Ac_Sorgu_Formlar") { myDocspath = KlasorYolu_Formlar; }

        //        //string myDocspath = TreeView_SeciliDizin; // Buraya istediğimiz dosyanın yolunu yazıyorz
        //        string windir = Environment.GetEnvironmentVariable("WINDIR");
        //        System.Diagnostics.Process prc = new System.Diagnostics.Process();
        //        prc.StartInfo.FileName = windir + @"\explorer.exe";
        //        prc.StartInfo.Arguments = myDocspath;
        //        prc.Start();
        //    }
        //    catch (Exception HATA)
        //    {
        //        string a = HATA.ToString();
        //    }



        //    //if (DinamikButon.Name == "B_Geri_Is_Zaman_Plani" && WB_Is_Zaman_Plani.CanGoBack == true) { WB_Is_Zaman_Plani.GoBack(); }
        //}
        //public void ButonLinkCopy(object sender, EventArgs e)
        //{
        //    Button DinamikButon = (sender as Button);
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_PrgPLC") { Clipboard.SetText(KlasorYolu_PLC); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_PrgHMI") { Clipboard.SetText(KlasorYolu_HMI); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_Programlar") { Clipboard.SetText(KlasorYolu_Programlar); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_PrgDiger") { Clipboard.SetText(KlasorYolu_PrgDiger); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_Cizimler") { Clipboard.SetText(KlasorYolu_Cizimler); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_ElektrikPrj") { Clipboard.SetText(KlasorYolu_ElektrikProjesi); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_MalzemeListesi") { Clipboard.SetText(KlasorYolu_MalzemeListesi); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_PrgPC") { Clipboard.SetText(KlasorYolu_PC); }

        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_Dokumanlar") { Clipboard.SetText(KlasorYolu_Dokumanlar); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_CihazDokumanlari") { Clipboard.SetText(KlasorYolu_Cihazlar); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_DigerDokumanlar") { Clipboard.SetText(KlasorYolu_DigerDokumanlar); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_Formlar") { Clipboard.SetText(KlasorYolu_Formlar); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_MusteriIliskileri") { Clipboard.SetText(KlasorYolu_MusteriIliskileri); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_IsZamanPlani") { Clipboard.SetText(KlasorYolu_IsZamanPlani); }
        //    if (DinamikButon.Name == "B_LinkCopy_Sorgu_FotografVideo") { Clipboard.SetText(KlasorYolu_FotografVideo); }
        //    //if (DinamikButon.Name == "B_LinkCopy_Is_Zaman_Plani") { Clipboard.SetText(Klasor_Is_Zaman_Plani); }
        //}
        #endregion
    }
}
