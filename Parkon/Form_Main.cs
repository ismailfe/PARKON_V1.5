using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Parkon
{
    public partial class Form_Main : Form
    {

        #region PUBLIC VARIABLE
        CLS CLS = new CLS();

        public Thread TH_FirsStart;
        public string CrtPrj_SecilenMusteriNo;
        public string CrtPrj_SecilenMusteriAdi;
        public string CrtPrj_SecilenBolumNo;
        public string CrtPrj_SecilenBolumAdi;

        #endregion

        #region FORM KONTROLLERİ
 
        public Form_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // thread kullanmak için gerekli. Multithreading hatasını engeller.
            CLS.assembly                    = System.Reflection.Assembly.GetExecutingAssembly();
            CLS.fvi                         = FileVersionInfo.GetVersionInfo(CLS.assembly.Location);

            CLS.Class();
            CLS.Form_Main = this;

            CLS.PrgSecimi.Secim();
            CLS.Form_Starting.Show();
            CLS.TaskSchedulerCtrl.Start();
            CLS.FirstStart.DizinKontrolleri();
            this.Hide();
            this.Visible                    = false;
            user_Login1.Location            = new Point(1100, 58);
            Timer_FirstStart.Interval       = 3000;
            Timer_FirstStart.Enabled        = true;
            TH_FirsStart                    = new Thread(CLS.FirstStart.Baslangic);
            TH_FirsStart.Start();
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            //this.Hide();
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            e.Cancel = true;
            Notify_Parkon.Visible = true;
            ShowInTaskbar = false;
        }
        private void B_Cikis_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Parkon'u kapatmak istediğinizden emin misiniz?", "Parkon Kapatılacak!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                APPCLOSE();
            }
        }
        public void APPCLOSE()
        {
            CLS.ProjeSorgulama.LocalDataUpdate();
            CLS.ID_MySQL.Disconnect();
            Environment.Exit(1);
        }
        private void Notify_Parkon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            ShowInTaskbar = true;
            Notify_Parkon.Visible = false;

            //this.Show();
        }
        private void Panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Panel_Top_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void B_KullaniciOturum_Click(object sender, EventArgs e)
        {
            if (user_Login1.Visible == true)
            {
                user_Login1.Visible = false;
            }
            else
            {
                //  996; 36
                int ButonLocationX = B_KullaniciOturum.Location.X;
                user_Login1.Location = new Point(ButonLocationX - 124, 58);
                user_Login1.Visible = true;
            }
        }
        private void B_YeniVerBulundu_Click(object sender, EventArgs e)
        {
            CLS.Form_VersiyonYukle.Show();
        }
        private void B_System_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B_System_DownToTask_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void B_SurumNotlari_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Rdata;
                CLS.AutoUpdate.VerCheck(out Rdata);
                string baslik = "Parkon - " + CLS.Version;

                CLS.Form_WhatsNew.Show();
                CLS.Form_WhatsNew.RTB_Detaylar.Text = Rdata[6];
                CLS.Form_WhatsNew.LB_Version.Text = "Parkon - " + CLS.Version;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
           
        }
        private void user_Login1_Leave(object sender, EventArgs e)
        {
            user_Login1.Visible = false;
        }
        private void RTB_AppStart_TextChanged(object sender, EventArgs e)
        {
            CLS.Form_Starting.RTB_AppStart.Text = RTB_AppStart.Text;
        }
        private void B_TamEkran_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void Tab_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TabPage_ProjeSorgula
            //TabPage_ProjeYeni
            //TabPage_Servis
            //TabPage_Teklif
            //TabPage_Rapor
            //TabPage_Otomasyon
            //TabPage_Ayarlar

            //TabPage_OtomasyonDokuman
            //TabPage_KisiselAyarlar
            //TabPage_Logs
            //TabPage_NetworkProfil
            //TabPage_Tablolar

            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_ProjeSorgula"])
            {

            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_ProjeYeni"])
            {

            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Servis"])
            {

            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Teklif"])
            {

            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Rapor"])
            {

            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Otomasyon"])
            {
                CLS.NetworkAdapter.NetworkAdapterListele(DGV_NetworkAdapter);
                CLS.NetworkAdapter.ProfilListele(DGV_NetworkProfil);
            }
            if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Ayarlar"])
            {

            }


        }
        #endregion

        #region ORTAK KULLANILAN PROSEDÜRLER
        private void BUYUK_HARF_YAZ(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void BUYUK_HARF_YAZ_ENG(object sender, EventArgs e)
        {

            ((TextBox)sender).Text = CLS.TextCheck.StringENG(((TextBox)sender).Text).ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void SADECE_RAKAM_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void SADECE_HARF_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                        && !char.IsSeparator(e.KeyChar);
        }
        public void InternetDurumunaGoreGostergeler(bool InternetVar)
        {
            if (InternetVar)
            {
                LB_Gosterge_Internet.BackColor = Color.Lime;

                Panel_ProjeYeni.Enabled = true;
                B_DBOku_Server.Enabled = true;
                //B_CrtPrj_YeniMusteriEkle.Enabled        = true;
                //CHB_OnlineDataBase.Enabled              = true;
                //CHB_OnlineDataBase.Checked              = true;
                //CLS.Bildirimler.internetBaglantisiERR   = false;

                //if (TB_User_UserAd.Text != "")
                //{
                //    TableLayout_ProjeOlusturma.Enabled = true;
                //}

            }
            else
            {
                LB_Gosterge_Internet.BackColor = Color.Red;

                Panel_ProjeYeni.Enabled = false;
                B_DBOku_Server.Enabled = false;
                //B_Proje_Olustur.Enabled                 = false;
                //B_CrtPrj_YeniMusteriEkle.Enabled        = false;
                //CHB_OnlineDataBase.Checked              = false;
                //CHB_OnlineDataBase.Enabled              = false;
                //TableLayout_ProjeOlusturma.Enabled      = false;
            }



        }
        public string BeniHatirlaKullaniciGirisi()
        {

            string yükle = CLS.PrgSettings.YUKLE_BeniHatirla();
            string giris = "";

            if (yükle == "OK!")
            {
                giris = CLS.UserLogin.KullaniciGiris();
            }
            return yükle + " " + giris;
        }
        public void InternetKnt_withTH()
        {
            CLS.Bildirimler.NetKontrol();
        }

        // CTRL TUŞU BASILI / DEĞİL KONTROLÜ
        public static bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }
        private void CHB_OnlineDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (!CHB_OnlineDataBase.Checked)
            {
                CLS.ProjeSorgulama.Fill_DGV_FromLocalDB();
            }
        }
        #endregion

        #region TIMERLAR
        private void Timer_FirstStart_Tick(object sender, EventArgs e)
        {
            if (!CLS.FirstStart.FirstStart_Basladi)
            {

            }

            if (CLS.FirstStart.FirstStart_Tamamlandi)
            {
             
                CLS.UserLogin.Listele_UserName(user_Login1.XID_CB_USERNAME);
                BeniHatirlaKullaniciGirisi();

                CLS.Form_Main.Refresh();
                //CLS.Form_Main.Update();
                Timer_FirstStart.Enabled = false;
            }
        }
        private void Timer_1sec_Tick(object sender, EventArgs e)
        {
            CLS.Bildirimler.Notify_Bilgi_Uyari();
            //Kullanıcı Girişi yapılmışsa ve internet varsa Proje Oluşturmaya izin ver
            if (Panel_UserInfo.Visible && LB_Gosterge_Internet.BackColor != Color.Red) 
            {
                Panel_ProjeYeni.Enabled = true;
            }
            else
            {
                Panel_ProjeYeni.Enabled = false;
            }
        }
        private void Timer_1min_Tick(object sender, EventArgs e)
        {
            if (CLS.FirstStart.FirstStart_Tamamlandi)
            { Thread TH = new Thread(InternetKnt_withTH); TH.Start(); }
            CLS.Bildirimler.SelamMesaji();

            //if (toolStripL_LocalDataUpdate.ForeColor == Color.Green)
            //{
            //    toolStripL_LocalDataUpdate.ForeColor = Color.Black;
            //}

            //DBUpdateSayici = DBUpdateSayici + 1;

            //if (LB_Gosterge_Internet.BackColor == Color.Lime && DBUpdateSayici == 180)
            //{
            //    CLS.ProjeSorgulama.LocalDataUpdate();
            //    DBUpdateSayici = 0;
            //}

        }
        #endregion

        #region FORM MOVE CODE
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        //##########################################################################################
        //##########################################################################################

        #region SAYFA - KULLANICI PANELİ

        private void user_Login1_XID_ComboBox_UserName_MouseDown(object sender, EventArgs e)
        {
            // CLS.UserLogin.Listele_UserName(CB_User_SecUserName);
            CLS.UserLogin.Listele_UserName(user_Login1.XID_CB_USERNAME);
        }
        private void user_Login1_XID_ComboBox_UserName_SelectedIndex(object sender, EventArgs e)
        {
            ////TB_SecilenUserNameID.Text = CB_User_SecUserName.SelectedIndex.ToString();
            //TB_SecilenUserNameID.Text = user_Login1.XID_CB_USERNAME.SelectedIndex.ToString();
            //CHB_BeniHatirla.Checked = false;
            //CLS.PrgSettings.KAYDET_BeniUnut();
        }
        private void user_Login1_XID_B_LOGIN_Click(object sender, EventArgs e)
        {
            CLS.UserLogin.KullaniciGiris();

        }
        private void user_Login1_XID_B_LOGOUT_Click(object sender, EventArgs e)
        {
            CLS.UserLogin.KullaniciCikis();
            CLS.PrgSettings.KAYDET_BeniUnut();
        }
        private void user_Login1_XID_CHB_BENIHATIRLA_Checked(object sender, EventArgs e)
        {
            if (!user_Login1.XID_CHB_BENIHATIRLA.Checked)
            {
                CLS.PrgSettings.KAYDET_BeniUnut();
            }
        }
        private void B_YeniUserEkle_Click(object sender, EventArgs e)
        {
            CLS.Form_Yeni_User.Show();
        }

        #endregion

        #region SAYFA - AYARLAR
        private void B_AnaDizinSec_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FbWDialog = new FolderBrowserDialog();
            DialogResult dr = FbWDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                TB_SecilenAnaDizin.Text = FbWDialog.SelectedPath + "\\";
                CLS.PrgSettings.KAYDET_AnaDizin();
                MessageBox.Show("Projelerin yer aldığı ana dizin; ''" + TB_SecilenAnaDizin.Text + "'' olarak değiştirildi. ", "Ana dizin seçimi");
            }
         
        }
        private void InternetKnt_DoubleClick(object sender, EventArgs e)
        {
            LB_Gosterge_Internet.BackColor = Color.DarkBlue;
            Thread TH = new Thread(InternetKnt_withTH);
            TH.Start(); ;
        }
        private void LB_Gosterge_Internet_MouseHover(object sender, EventArgs e)
        {
            if (LB_Gosterge_Internet.BackColor == Color.Lime)
            {
                TTip_Info.SetToolTip(LB_Gosterge_Internet, "Internet Bağlantısı OK!\n IP:" + CLS.Bildirimler.InternetIP);
            }
            else
            {
                TTip_Info.SetToolTip(LB_Gosterge_Internet, "Hay Aksi! Internet Bağlantısı Yok.\n Yine de proje sorgulama yapabilirsin.");
            }


        }
        private void B_KaydetAyarlar_Click(object sender, EventArgs e)
        {
            CLS.PrgSettings.KAYDET_SistemAyarlari();
            MessageBox.Show("Ayarlar Kaydedildi.", "Kayıt");
        }
        private void B_DBOku_Server_Click(object sender, EventArgs e)
        {
            CLS.ProjeSorgulama.LocalDataUpdate();
        }
        private void B_DBOkuLocal_Click(object sender, EventArgs e)
        {
            CLS.ProjeSorgulama.Fill_DGV_FromLocalDB();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region SAYFA - PROJE OLUŞTUR

        #region MÜŞTERİ SEÇİMİ İÇİN KULLANILAN NESNELER
        // ##### COMBOBOX BUTTON - MÜŞTERİ ADI  ##### //
        private void CB_CrtPrj_MusteriSecim_Ad_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.CreateProject.Temizle_Musteri();
            CLS.CreateProject.Temizle_MusteriBolum();
            CLS.CreateProject.Temizle_ProjeBilgileri();
            CLS.CreateProject.Temizle_YetkiliKisi();
            CLS.CreateProject.Listele_MusteriAdi(CB_CrtPrj_MusteriSecim_Ad);
        }
        private void CB_CrtPrj_MusteriSecim_Ad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.CreateProject.MusteriAdiSecildi(int.Parse(selectedValue), out string MusteriNo, out string MBolge, out string MAdres, out string MMapslink, out string MTel, out string Mnot, out string INFO);

            TB_CrtPrj_MusteriSecim_No.Text = MusteriNo;
            TB_CrtPrj_MusteriBolge.Text = MBolge;
            TB_CrtPrj_MusteriAdres.Text = MAdres;
            TB_CrtPrj_MusteriMapsLink.Text = MMapslink;
            TB_CrtPrj_MusteriTel.Text = MTel;
            RTB_CrtPrj_MusteriNot.Text = INFO + Mnot;

            CrtPrj_SecilenMusteriNo = MusteriNo;
            CrtPrj_SecilenMusteriAdi = CB_CrtPrj_MusteriSecim_Ad.Text;

        }
        private void CrtPrj_MusteriFirmaSecildi(object sender, EventArgs e)
        {
            if (TB_CrtPrj_MusteriSecim_No.Text != "")
            {
                LB_CrtPtj_MusteriFirmaSecimiOK.Text = "✓";
                LB_CrtPtj_MusteriFirmaSecimiOK.BackColor = Color.LawnGreen;
                CB_CrtPrj_BolumSecim_Ad.Enabled = true;
                CB_CrtPrj_YetkiliSecim.Enabled = true;
            }
            else
            {
                LB_CrtPtj_MusteriFirmaSecimiOK.Text = " -";
                LB_CrtPtj_MusteriFirmaSecimiOK.BackColor = Color.Transparent;
                CB_CrtPrj_BolumSecim_Ad.Enabled = false;
                CB_CrtPrj_YetkiliSecim.Enabled = false;
            }
        }

        #endregion

        #region BÖLÜM SEÇİMİ İÇİN KULLANILAN NESNELER

        // ##### COMBOBOX BUTTON - BÖLÜM ADI  ##### //
        private void CB_CrtPrj_BolumSecim_Ad_MouseDown(object sender, MouseEventArgs e)
        {
            if (CrtPrj_SecilenMusteriNo != "")
            {
                CLS.CreateProject.Temizle_MusteriBolum();
                CLS.CreateProject.Temizle_ProjeBilgileri();
                CLS.CreateProject.Listele_BolumAdi(CB_CrtPrj_BolumSecim_Ad, CrtPrj_SecilenMusteriNo);
            }
            else
            {
                MessageBox.Show("Hay aksi! Birşeyler yanlış gitti. ''Müşteri Seçimi'' yapılmadan bölüm seçilemez. Önce ''Müşteri Seçimi'' yapın. ", "UYARI!");
            }

        }
        private void CB_CrtPrj_BolumSecim_Ad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.CreateProject.BolumAdiSecildi(int.Parse(selectedValue), out string BolumNo, out string BolumNot, out string INFO);
            RTB_CrtPrj_BolumNot.Text = INFO + "  // " + BolumNot;
            TB_CrtPrj_BolumSecim_No.Text = BolumNo;
            CrtPrj_SecilenBolumNo = BolumNo;
            CrtPrj_SecilenBolumAdi = CB_CrtPrj_BolumSecim_Ad.Text;
        }
        private void CrtPrj_BolümSecildi(object sender, EventArgs e)
        {
            if (TB_CrtPrj_BolumSecim_No.Text != "")
            {
                LB_CrtPtj_BolumSecimiOK.Text = "✓";
                LB_CrtPtj_BolumSecimiOK.BackColor = Color.LawnGreen;
                CB_CrtPrj_Secim_ProjeAdi.Enabled = true;
                TB_CrtPrj_ProjeAdi.Enabled = true;
                Panel_ProjeTipSecimi.Enabled = true;

                if (!RB_CrtPrj_RevProje.Checked)
                {
                    CHB_CrtPrj_ProjeDonemDegistir.Enabled = true;
                    DTP_CrtPrj_ProjeBaslangic.Enabled = true;
                }
            }
            else
            {
                LB_CrtPtj_BolumSecimiOK.Text = " -";
                LB_CrtPtj_BolumSecimiOK.BackColor = Color.Transparent;
                CB_CrtPrj_Secim_ProjeAdi.Enabled = false;
                TB_CrtPrj_ProjeAdi.Enabled = false;
                CHB_CrtPrj_ProjeDonemDegistir.Enabled = false;
                DTP_CrtPrj_ProjeBaslangic.Enabled = false;
                Panel_ProjeTipSecimi.Enabled = false;
            }
        }

        #endregion

        #region PROJE SEÇİMİ İÇİN KULLANILAN NESNELER

        private void RB_CrtPrj_RevProje_CheckedChanged(object sender, EventArgs e)
        {

            if (RB_CrtPrj_RevProje.Checked)
            {
                CB_CrtPrj_Secim_ProjeAdi.Visible = true;

                TB_CrtPrj_RevAdi.Enabled = true;
                TB_CrtPrj_RevNo.Enabled = true;
                DTP_CrtPrj_RevBaslangic.Enabled = true;
                CHB_CrtPrj_RevDonemDegistir.Enabled = true;

                DTP_CrtPrj_ProjeBaslangic.Enabled = false;
                DTP_CrtPrj_ProjeDonem.Enabled = false;
                CHB_CrtPrj_ProjeDonemDegistir.Enabled = false;

                TB_CrtPrj_ProjeAdi.Text = "";
                TB_CrtPrj_ProjeNo.Text = "";
                TB_CrtPrj_ProjeKodu.Text = "";

                TB_CrtPrj_RevAdi.Text = "";
                TB_CrtPrj_RevNo.Text = "";

                CB_CrtPrj_Secim_ProjeAdi.Text = "";
                CB_CrtPrj_Secim_ProjeAdi.Items.Clear();
            }
            else
            {
                CB_CrtPrj_Secim_ProjeAdi.Visible = false;
                DTP_CrtPrj_ProjeBaslangic.Enabled = true;
                CHB_CrtPrj_ProjeDonemDegistir.Enabled = true;
                if (CHB_CrtPrj_ProjeDonemDegistir.Checked)
                {
                    DTP_CrtPrj_ProjeDonem.Enabled = true;
                }

                TB_CrtPrj_RevAdi.Enabled = false;
                TB_CrtPrj_RevNo.Enabled = false;
                DTP_CrtPrj_RevBaslangic.Enabled = false;
                DTP_CrtPrj_RevDonem.Enabled = false;
                CHB_CrtPrj_RevDonemDegistir.Enabled = false;
                CHB_CrtPrj_RevDonemDegistir.Checked = false;

                TB_CrtPrj_ProjeAdi.Text = "";
                TB_CrtPrj_ProjeNo.Text = "";
                TB_CrtPrj_ProjeKodu.Text = "";
                TB_CrtPrj_RevAdi.Text = "";
                TB_CrtPrj_RevNo.Text = "";

                CB_CrtPrj_Secim_ProjeAdi.Text = "";
                CB_CrtPrj_Secim_ProjeAdi.Items.Clear();

            }
        }
        private void TB_CrtPrj_ProjeAdi_Validating(object sender, CancelEventArgs e)
        {
            if (!CHB_CrtPrj_ProjeDonemDegistir.Checked)
            {
                ProjeNoSorgula_Olustur(DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Day);
            }
            else
            {
                ProjeNoSorgula_Olustur(DTP_CrtPrj_ProjeDonem.Value.Month, DTP_CrtPrj_ProjeDonem.Value.Year, DTP_CrtPrj_ProjeDonem.Value.Day);
            }
        }
        public void ProjeNoSorgula_Olustur(int DonemAy, int DonemYil, int DonemGun)
        {
            if (CrtPrj_SecilenMusteriNo != "" && CrtPrj_SecilenBolumNo != "" && TB_CrtPrj_ProjeAdi.Text != "")
            {
                DateTime Donem = new DateTime(DonemYil, DonemAy, DonemGun);

                DTP_CrtPrj_ProjeDonem.Value = Donem;
                string DonemYili = DonemYil.ToString();//.Remove(0,2);
                CLS.CreateProject.ProjeNoOlusturma(CrtPrj_SecilenMusteriNo, CrtPrj_SecilenBolumNo, DonemYili, out string PRJNo, out string PRJKOD);
                TB_CrtPrj_ProjeNo.Text = PRJNo;
                TB_CrtPrj_ProjeKodu.Text = PRJKOD;
                RTB_CrtPrj_ProjeNot.ReadOnly = false;
                RTB_CrtPrj_ProjeNot.BackColor = Color.White;
            }

        }
        private void CrtPrj_ProjeNoOlusturuldu(object sender, EventArgs e)
        {
            if ((TB_CrtPrj_ProjeKodu.Text != "" && TB_CrtPrj_ProjeAdi.Text != "") || (RB_CrtPrj_RevProje.Checked && CB_CrtPrj_Secim_ProjeAdi.Text != "" && TB_CrtPrj_ProjeKodu.Text != ""))
            {
                LB_CrtPtj_ProjeBilgileriOK.Text = "✓";
                LB_CrtPtj_ProjeBilgileriOK.BackColor = Color.LawnGreen;
            }
            else
            {
                LB_CrtPtj_ProjeBilgileriOK.Text = " -";
                LB_CrtPtj_ProjeBilgileriOK.BackColor = Color.Transparent;
            }
        }
        private void CHB_CrtPrj_ProjeDonemDegistir_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_CrtPrj_ProjeDonemDegistir.Checked)
            {
                DTP_CrtPrj_ProjeDonem.Enabled = true;
            }
            else
            {
                DTP_CrtPrj_ProjeDonem.Enabled = false;
                DTP_CrtPrj_ProjeDonem.Value = DateTime.Now;
                ProjeNoSorgula_Olustur(DTP_CrtPrj_ProjeDonem.Value.Month, DTP_CrtPrj_ProjeDonem.Value.Year, DTP_CrtPrj_ProjeDonem.Value.Day);
            }
        }
        private void TB_CrtPrj_ProjeDonem_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //DateTimePicker Tpicker = new DateTimePicker();
                // Tpicker.Text = DTP_CrtPrj_ProjeDonem.Text;

                if (CHB_CrtPrj_ProjeDonemDegistir.Checked)
                {
                    ProjeNoSorgula_Olustur(DTP_CrtPrj_ProjeDonem.Value.Month, DTP_CrtPrj_ProjeDonem.Value.Year, DTP_CrtPrj_ProjeDonem.Value.Day);
                }
                else
                {

                }


            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                MessageBox.Show("Hatalı ya da eksik dönem yazıldı. /n " +
                        "Proje Dönemi ''01.18'' şeklinde araya nokta ekleyerek yazılmalıdır. ", "Dönem yazım hatası!");

            }

        }
        private void CB_CrtPrj_Secim_ProjeAdi_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.CreateProject.Listele_RevIcinProjeler(CB_CrtPrj_Secim_ProjeAdi, CrtPrj_SecilenMusteriNo, CrtPrj_SecilenBolumNo);
        }
        private void CB_CrtPrj_Secim_ProjeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.CreateProject.RevIcinProjeSecildi(int.Parse(selectedValue), out string Pno, out string PKod, out string BasTarih, out string PrjDonem, out string Not);

            TB_CrtPrj_ProjeNo.Text = Pno;
            TB_CrtPrj_ProjeKodu.Text = PKod;
            DTP_CrtPrj_ProjeBaslangic.Value = DateTime.Parse(BasTarih);
            DTP_CrtPrj_ProjeDonem.Value = DateTime.Parse("01." + PrjDonem);
            RTB_CrtPrj_ProjeNot.Text = Not;
        }
        private void TB_CrtPrj_RevAdi_Validating(object sender, CancelEventArgs e)
        {
            RevNoSorgula_Olustur();
        }
        private void CHB_CrtPrj_RevDonemDegistir_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_CrtPrj_RevDonemDegistir.Checked)
            {
                DTP_CrtPrj_RevDonem.Enabled = true;
            }
            else
            {
                DTP_CrtPrj_RevDonem.Enabled = false;
                DTP_CrtPrj_RevDonem.Value = DateTime.Now;
                RevNoSorgula_Olustur();// (DTP_CrtPrj_RevDonem.Value.Month, DTP_CrtPrj_RevDonem.Value.Year, DTP_CrtPrj_RevDonem.Value.Day);
            }
        }
        public void RevNoSorgula_Olustur()
        {
            if (CrtPrj_SecilenMusteriNo != "" && CrtPrj_SecilenBolumNo != "" && CB_CrtPrj_Secim_ProjeAdi.Text != "" && TB_CrtPrj_ProjeNo.Text != "")
            {
                CLS.CreateProject.RevNoOlusturma(CrtPrj_SecilenMusteriNo, CrtPrj_SecilenBolumNo, TB_CrtPrj_ProjeNo.Text, out string RevNo);
                TB_CrtPrj_RevNo.Text = RevNo;
                RTB_CrtPrj_ProjeNot.ReadOnly = false;
                RTB_CrtPrj_ProjeNot.BackColor = Color.White;
            }

        }
        private void PROJE_OLUSTURMA_ICIN_SECIMLER_OK(object sender, EventArgs e)
        {
            if (LB_CrtPtj_MusteriFirmaSecimiOK.Text == "✓" && LB_CrtPtj_ProjeBilgileriOK.Text == "✓" && LB_CrtPtj_BolumSecimiOK.Text == "✓")
            {
                B_Proje_Olustur.Enabled = true;
            }
            else
            {
                B_Proje_Olustur.Enabled = false;
            }
        }
        private void B_Proje_Olustur_Click(object sender, EventArgs e)
        {
            Proje_Olustur_ON_Kontrol();
        }
        public string Proje_Olustur_ON_Kontrol()
        {
            try
            {
                string Baslik = "HATA!";
                if(CLS.Bildirimler.NetKontrol() == "OK!")
                {
                    if (CrtPrj_SecilenMusteriNo != "")
                    {
                        if (CrtPrj_SecilenMusteriAdi != "")
                        {
                            if (CrtPrj_SecilenBolumNo != "")
                            {
                                if (CrtPrj_SecilenBolumAdi != "")
                                {
                                    if (TB_CrtPrj_ProjeNo.Text != "")
                                    {
                                        if (TB_CrtPrj_ProjeAdi.Text != "" || (RB_CrtPrj_RevProje.Checked && CB_CrtPrj_Secim_ProjeAdi.Text != "" && TB_CrtPrj_RevAdi.Text != "")) // Revizyon Seciliyle Proje Adına bakma
                                        {
                                            if (RB_CrtPrj_RevProje.Checked == false)
                                            {
                                                CLS.Form_Yeni_Proje.ShowDialog();
                                            }
                                            else
                                            {
                                                CLS.Form_Yeni_Revizyon.ShowDialog();
                                            }

                                        }
                                        else { MessageBox.Show("Proje Adı/Revizyon adı Oluşturulmadı!", Baslik); }
                                    }
                                    else { MessageBox.Show("Proje No Oluşturulmadı!", Baslik); }
                                }
                                else { MessageBox.Show("Bölüm Adı Oluşturulmadı!", Baslik); }
                            }
                            else { MessageBox.Show("Bölüm No Oluşturulmadı!", Baslik); }
                        }
                        else { MessageBox.Show("Müşteri aAdı Oluşturulmadı!", Baslik); }
                    }
                    else { MessageBox.Show("Müşteri No Oluşturulmadı!", Baslik); }
                }
                else { MessageBox.Show("INTERNET BAĞLANTI HATASI!", Baslik); }
                return "OK!";
            }
            catch (Exception HATA)
            {
                return "ERR! - " + HATA.ToString();
            }
        }
        private void B_Proje_Olustur_Temizle_Click(object sender, EventArgs e)
        {
            CLS.CreateProject.Temizle_Musteri();
            CLS.CreateProject.Temizle_MusteriBolum();
            CLS.CreateProject.Temizle_ProjeBilgileri();
            CLS.CreateProject.Temizle_YetkiliKisi();
        }
        #endregion

        #region YETKİLİ KİŞİ SEÇİMİ İÇİN KULLANILAN NESNELER
        private void CB_CrtPrj_YetkiliSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLS.CreateProject.YetkiliAdiSecildi(CB_CrtPrj_YetkiliSecim.SelectedIndex, out string YNot, out string YNo, out string YUnvan,
                out string YTel1, out string YTel2, out string YMail, out string YInfo);

            RTB_CrtPrj_YetkiliNot.Text = Crypto.Decrypt(YNot, "xxx");
            TB_CrtPrj_YetkiliNo.Text = YNo; // Crypto.Decrypt(, "xxx"); 
            TB_CrtPrj_YetkiliUnvan.Text = Crypto.Decrypt(YUnvan, "xxx");
            TB_CrtPrj_YetkiliTel1.Text = Crypto.Decrypt(YTel1, "xxx");
            TB_CrtPrj_YetkiliTel2.Text = Crypto.Decrypt(YTel2, "xxx");
            TB_CrtPrj_YetkiliMail.Text = Crypto.Decrypt(YMail, "xxx");
        }
        private void CB_CrtPrj_YetkiliSecim_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.CreateProject.Listele_YetkiliAdi(CB_CrtPrj_YetkiliSecim, CrtPrj_SecilenMusteriNo);
        }
        private void CB_CrtPrj_YetkiliSecim_TextChanged(object sender, EventArgs e)
        {
            if (CB_CrtPrj_YetkiliSecim.Text != "")
            {
                LB_CrtPtj_YetkiliOK.Text = "✓";
                LB_CrtPtj_YetkiliOK.BackColor = Color.LawnGreen;
            }
            else
            {
                LB_CrtPtj_YetkiliOK.Text = " -";
                LB_CrtPtj_YetkiliOK.BackColor = Color.Transparent;
            }
        }
        #endregion

        ContextMenuStrip MenuYeniEkle = new ContextMenuStrip();
        private void LB_Baslik_MusteriFirmaSecim_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        MenuYeniEkle.Items.Clear();
                        MenuYeniEkle.Items.Add("Yeni Müşteri Ekle", Properties.Resources.i47, YeniMusteriEkle);
                        MenuYeniEkle.Show(Panel_ProjeYeni, new Point(e.X, LB_Baslik_MusteriFirmaSecim.Location.Y));//places the menu at the pointer position)
                    }
                    break;
            }
        }
        private void LB_Baslik_BolumSecim_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        MenuYeniEkle.Items.Clear();
                        MenuYeniEkle.Items.Add("Yeni Bölüm Ekle", Properties.Resources.i47, YeniBolumEkle);
                        MenuYeniEkle.Show(Panel_ProjeYeni, new Point(e.X, LB_Baslik_BolumSecim.Location.Y));//places the menu at the pointer position)
                    }
                    break;
            }
        }
        private void LB_Baslik_YetkiliSecim_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        MenuYeniEkle.Items.Clear();
                        MenuYeniEkle.Items.Add("Yeni Yetkili Kişi Ekle", Properties.Resources.i47, YeniKisiEkle);
                        MenuYeniEkle.Show(Panel_ProjeYeni, new Point(e.X, LB_Baslik_YetkiliSecim.Location.Y));//places the menu at the pointer position)
                    }
                    break;
            }
        }

        private void YeniMusteriEkle(object sender, EventArgs e)
        {
            CLS.Form_Yeni_Musteri.ShowDialog();
        }
        private void YeniBolumEkle(object sender, EventArgs e)
        {
            CLS.Form_Yeni_MusteriBolum.ShowDialog();

        }
        private void YeniKisiEkle(object sender, EventArgs e)
        {
            CLS.Form_Yeni_Yetkili.ShowDialog();
        }

        #endregion

        #region SAYFA - PROJE SORGULAMA
        private void B_Sorgu_ProjeKlasoruAc_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TB_Sorgu_ProjeYolu.Text))
            {
                string myDocspath = TB_Sorgu_ProjeYolu.Text; // Buraya istediğimiz dosyanın yolunu yazıyorz
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = windir + @"\explorer.exe";
                prc.StartInfo.Arguments = myDocspath;
                prc.Start();
            }
            else
            {
                DialogResult sorgu = MessageBox.Show("Seçilen projenin lokal klasörü bulunamadı! Proje bilgilerinden kontrol ederek, projeyi oluşturan kişiyle iletişime geçin.",
                    "Parkon Proje klasörü hatası!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        // Müşteri Adı Seçimi
        private void CB_Sorgu_MusteriAdi_MouseDown(object sender, MouseEventArgs e)
        {
            if (!CHB_OnlineDataBase.Checked)
            {
                CLS.ProjeSorgulama.Fill_DGV_FromLocalDB();
            }
            CLS.ProjeSorgulama.Listele_MusteriAdi(CB_Sorgu_MusteriAdi);
            TB_Sorgu_MusteriNo.Text = "";
            Sorgu_Temizle_BolumBilgileri();
            Sorgu_Temizle_ProjeBilgileri();
            Sorgu_Temizle_RevBilgileri();
        }
        private void CB_Sorgu_MusteriAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();
            CLS.ProjeSorgulama.MusteriAdiSecildi(int.Parse(selectedValue), out string MNo, out string MBolge, out string MAdres, out string Maps, out string MTel, out string Mnot, out string Info);

            TTip_Info.SetToolTip(CB_Sorgu_MusteriAdi, "Musteri No: " + MNo + " \n" + "Müşteri Bölgesi: " + MBolge + " \n" + "Adres: " + MAdres + " \n" + "Telefon: " + MTel);
            TB_Sorgu_MusteriNo.Text = MNo;
            if (MNo != "" && !CHB_Sorgu_ProjeKoduGir.Checked)
            {
                CB_Sorgu_BolumAdi.Enabled = true;
            }
        }
        // Bölüm Seçimi
        private void CB_Sorgu_BolumAdi_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.ProjeSorgulama.Listele_BolumAdi(CB_Sorgu_BolumAdi, TB_Sorgu_MusteriNo.Text);
            TB_Sorgu_BolumNo.Text = "";
            Sorgu_Temizle_ProjeBilgileri();
            Sorgu_Temizle_RevBilgileri();
        }
        private void CB_Sorgu_BolumAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();


            CLS.ProjeSorgulama.BolumAdiSecildi(int.Parse(selectedValue), TB_Sorgu_MusteriNo.Text, CB_Sorgu_BolumAdi.Text, out string BolumNo, out string BolumNot);
            TB_Sorgu_BolumNo.Text = BolumNo;
            if (TB_Sorgu_BolumNo.Text != "" && !CHB_Sorgu_ProjeKoduGir.Checked)
            {
                CB_Sorgu_ProjeAdi.Enabled = true;
            }
        }
        // Proje Seçimi
        private void CB_Sorgu_ProjeAdi_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.ProjeSorgulama.Listele_Projeler(CB_Sorgu_ProjeAdi, TB_Sorgu_MusteriNo.Text, TB_Sorgu_BolumNo.Text);
            TB_Sorgu_ProjeKodu.Text = "";
            Sorgu_Temizle_RevBilgileri();
        }
        private void CB_Sorgu_ProjeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.ProjeSorgulama.ProjeSecildi(int.Parse(selectedValue), TB_Sorgu_MusteriNo.Text, TB_Sorgu_BolumNo.Text, CB_Sorgu_ProjeAdi.Text,
                                            out string PrjNo, out string PrjKodu, out string PrjBasTarih, out string PrjDonem, out string PrjNot, out string INFO);

            TTip_Info.SetToolTip(CB_Sorgu_ProjeAdi, "Proje Kodu No: " + PrjKodu + " \n" + "Proje Adı: " + CB_Sorgu_ProjeAdi.Text + " \n" +
                                                    "Proje Donemi: " + PrjDonem + " \n" + "Proje Başlangıç Tarihi: " + PrjBasTarih + " \n" + "Proje Info: " + INFO);

            TB_Sorgu_ProjeKodu.Text = PrjKodu;

            //##################################################################
            //##################################################################
            // Proje Seçiminden sonra Rev No büyük olan otomatik seçilsin.
            TTip_Info.SetToolTip(CB_Sorgu_RevNo, "");
            TTip_Info.SetToolTip(CB_Sorgu_RevAdi, "");
            CLS.ProjeSorgulama.Listele_Revizyonlar(CB_Sorgu_RevAdi, CB_Sorgu_RevNo, TB_Sorgu_ProjeKodu.Text);
            int indexSelect = 0;
            for (int i = 0; i < CB_Sorgu_RevNo.Items.Count; i++)
            {

                if (indexSelect < int.Parse(CB_Sorgu_RevNo.Items[i].ToString()))
                {
                    indexSelect = int.Parse(CB_Sorgu_RevNo.Items[i].ToString());
                }

                if (i == CB_Sorgu_RevNo.Items.Count - 1)
                {
                    CB_Sorgu_RevNo.SelectedIndex = indexSelect;
                }
            }
            TB_Sorgu_ProjeYolu.Text = CLS.ProjeSorgulama.KlasorYolu_HedefProjeKlasoru;
            //##################################################################
            //##################################################################


            if (TB_Sorgu_ProjeKodu.Text != "" && !CHB_Sorgu_ProjeKoduGir.Checked)
            {
                CB_Sorgu_RevAdi.Enabled = true;
                CB_Sorgu_RevNo.Enabled = true;
            }
        }
        // Revizyon Seçimi
        private void CB_Sorgu_RevNo_MouseDown(object sender, MouseEventArgs e)
        {
            TTip_Info.SetToolTip(CB_Sorgu_RevNo, "");
            TTip_Info.SetToolTip(CB_Sorgu_RevAdi, "");
            CLS.ProjeSorgulama.Listele_Revizyonlar(CB_Sorgu_RevAdi, CB_Sorgu_RevNo, TB_Sorgu_ProjeKodu.Text);
        }
        private void CB_Sorgu_RevAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Sorgu_RevNo.SelectedIndex = CB_Sorgu_RevAdi.SelectedIndex;
            TB_Sorgu_ProjeYolu.Text = CLS.ProjeSorgulama.KlasorYolu_HedefProjeKlasoru;
        }
        private void CB_Sorgu_RevNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Sorgu_RevAdi.SelectedIndex = CB_Sorgu_RevNo.SelectedIndex;
            CB_Sorgu_RevAdi.SelectedValue = CB_Sorgu_RevNo.SelectedValue;

            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = 0;
            string selectedValue = "";

            if (CB_Sorgu_RevNo.Text != "00")
            {
                selectedIndex = cmb.SelectedIndex;
                selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();
                CLS.ProjeSorgulama.RevSecildi(int.Parse(selectedValue), TB_Sorgu_ProjeKodu.Text, CB_Sorgu_RevNo.Text, out string RBasTarih, out string RDonem, out string RNot, out string INFO);

                TTip_Info.SetToolTip(CB_Sorgu_RevNo, "Revizyon No: " + CB_Sorgu_RevNo.Text + " \n" + "Revizyon Adı: " + CB_Sorgu_RevAdi.Text + " \n" +
                                                     "Revizyon Donemi: " + RDonem + " \n" + "Revizyon Başlangıç Tarihi: " + RBasTarih + " \n" + "Revizyon Info: " + INFO);

                TTip_Info.SetToolTip(CB_Sorgu_RevAdi, "Revizyon No: " + CB_Sorgu_RevNo.Text + " \n" + "Revizyon Adı: " + CB_Sorgu_RevAdi.Text + " \n" +
                                                   "Revizyon Donemi: " + RDonem + " \n" + "Revizyon Başlangıç Tarihi: " + RBasTarih + " \n" + "Revizyon Info: " + INFO);

            }


            CLS.ProjeSorgulama.AdresTanimlamalari(false);
        }
        private void B_Sorgu_NitelikSecimTemizle_Click(object sender, EventArgs e)
        {
            CLS.ProjeSorgulama.KlasorNitelik_Temizle();
        }
        private void B_Sorgu_NitelikSecimHepsiniSec_Click(object sender, EventArgs e)
        {
            CLS.ProjeSorgulama.KlasorNitelik_HepsiniSec();
        }
        private void CB_Sorgu_RevNo_TextChanged(object sender, EventArgs e)
        {
            if (CB_Sorgu_RevNo.Text != "")
            {
                B_Sorgu_Ara.Enabled = true;
                B_Sorgu_AramayiTemizle.Enabled = true;
                B_Sorgu_ProjeKlasoruAc.Enabled = true;
            }
            else
            {
                B_Sorgu_Ara.Enabled = false;
                B_Sorgu_AramayiTemizle.Enabled = false;
                B_Sorgu_ProjeKlasoruAc.Enabled = false;
            }
        }
        private void B_Sorgu_AramayiTemizle_Click(object sender, EventArgs e)
        {
            Sorgu_Temizle_RevBilgileri();
            Sorgu_Temizle_ProjeBilgileri();
            Sorgu_Temizle_BolumBilgileri();
            Sorgu_Temizle_MusteriBilgileri();
        }
        private void CHB_Sorgu_ProjeKoduGir_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_Sorgu_ProjeKoduGir.Checked)
            {
                TB_Sorgu_ProjeKoduGiris.Enabled = true;
                TB_Sorgu_RevKoduGiris.Enabled = true;

                Sorgu_Temizle_RevBilgileri();
                Sorgu_Temizle_ProjeBilgileri();
                Sorgu_Temizle_BolumBilgileri();
                Sorgu_Temizle_MusteriBilgileri();
                CB_Sorgu_MusteriAdi.Enabled = false;
                CB_Sorgu_MusteriAdi.Items.Clear();

            }
            else
            {
                TB_Sorgu_ProjeKoduGiris.Enabled = false;
                TB_Sorgu_RevKoduGiris.Enabled = false;

                TB_Sorgu_ProjeKoduGiris.Text = "";
                TB_Sorgu_RevKoduGiris.Text = "";

                CB_Sorgu_MusteriAdi.Enabled = true;

                Sorgu_Temizle_RevBilgileri();
                Sorgu_Temizle_ProjeBilgileri();
                Sorgu_Temizle_BolumBilgileri();
                Sorgu_Temizle_MusteriBilgileri();
                CB_Sorgu_MusteriAdi.Enabled = true;
                CB_Sorgu_MusteriAdi.Items.Clear();


            }
        }
        private void TB_Sorgu_RevKoduGiris_TextChanged(object sender, EventArgs e)
        {
            ProjeKoduGiris_Kontrol();
        }
        private void TB_Sorgu_ProjeKoduGiris_TextChanged(object sender, EventArgs e)
        {
            ProjeKoduGiris_Kontrol();
        }
        void ProjeKoduGiris_Kontrol()
        {
            CLS.Form_Main.TB_Sorgu_RevKoduGiris.BackColor = SystemColors.Window;
            CLS.Form_Main.TB_Sorgu_ProjeKoduGiris.BackColor = SystemColors.Window;
            string YapistrilanTxt = Clipboard.GetText();

            if (YapistrilanTxt.Length == 12 && (YapistrilanTxt.Substring(0, 1) == "P" || YapistrilanTxt.Substring(0, 1) == "p"))
            {
                TB_Sorgu_ProjeKoduGiris.Text = YapistrilanTxt.Substring(1, 11);
                Clipboard.Clear();
            }

            if (TB_Sorgu_RevKoduGiris.TextLength == 2 && TB_Sorgu_ProjeKoduGiris.TextLength == 11)
            {
                B_Sorgu_Ara.Enabled = true;
                B_Sorgu_AramayiTemizle.Enabled = true;
            }
            else
            {
                B_Sorgu_Ara.Enabled = false;
                B_Sorgu_AramayiTemizle.Enabled = false;
            }



        }
        private void B_Ara_Click(object sender, EventArgs e)
        {
            TB_Sorgu_Hata_Bildirimi.Text = "";

            if (CHB_Sorgu_ProjeKoduGir.Checked)
            {
                TB_Sorgu_ProjeKoduGiris.Enabled = true;
                TB_Sorgu_RevKoduGiris.Enabled = true;

                Sorgu_Temizle_RevBilgileri();
                Sorgu_Temizle_ProjeBilgileri();
                Sorgu_Temizle_BolumBilgileri();
                Sorgu_Temizle_MusteriBilgileri();
                CB_Sorgu_MusteriAdi.Enabled = false;
                CB_Sorgu_MusteriAdi.Items.Clear();

                CLS.ProjeSorgulama.ProjeKoduIleSorgula(TB_Sorgu_ProjeKoduGiris.Text, TB_Sorgu_RevKoduGiris.Text);
            }
            else
            {
                CLS.ProjeSorgulama.SecimliSorgulama();
            }

        }
        private void HIZLI_SORGULA_ARA_CheckedChanged(object sender, EventArgs e)
        {
            if (IsControlDown() && Directory.Exists(TB_Sorgu_ProjeYolu.Text))
            {
                CLS.ProjeSorgulama.SecimliSorgulama();
            }
        }
        private void Tab_ProjeSorgulama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_ProjeSorgulama.SelectedTab == Tab_ProjeSorgulama.TabPages["TabPage_OncedenAranmisProjeler"])
            {
                CLS.ProjeSorgulamaGecmisi.ProjeGecmisGoster();
            }
        }
        // TEMIZLEME İŞLEMLERİ
        public void Sorgu_Temizle_RevBilgileri()
        {
            TB_Sorgu_ProjeYolu.Text = "";
            CB_Sorgu_RevAdi.Text = "";
            CB_Sorgu_RevAdi.Items.Clear();
            CB_Sorgu_RevNo.Text = "";
            CB_Sorgu_RevNo.Items.Clear();

            B_Sorgu_ProjeKlasoruAc.Enabled = false;
            CB_Sorgu_RevAdi.Enabled = false;
            CB_Sorgu_RevNo.Enabled = false;
            B_Sorgu_Ara.Enabled = false;
            B_Sorgu_AramayiTemizle.Enabled = false;

            TTip_Info.SetToolTip(CB_Sorgu_RevAdi, "");
            TTip_Info.SetToolTip(CB_Sorgu_RevNo, "");

        }
        public void Sorgu_Temizle_ProjeBilgileri()
        {
            CB_Sorgu_ProjeAdi.Text = "";
            CB_Sorgu_ProjeAdi.Items.Clear();
            TB_Sorgu_ProjeKodu.Text = "";
            CB_Sorgu_ProjeAdi.Enabled = false;

            TTip_Info.SetToolTip(CB_Sorgu_ProjeAdi, "");
        }
        public void Sorgu_Temizle_BolumBilgileri()
        {
            CB_Sorgu_BolumAdi.Text = "";
            CB_Sorgu_BolumAdi.Items.Clear();
            CB_Sorgu_BolumAdi.Enabled = false;
            TB_Sorgu_BolumNo.Text = "";

            TTip_Info.SetToolTip(CB_Sorgu_BolumAdi, "");
        }
        public void Sorgu_Temizle_MusteriBilgileri()
        {
            //CB_CrtPrj_MusteriSecim_Ad.Text = "";
            //CB_CrtPrj_MusteriSecim_Ad.Items.Clear();
            //TB_Sorgu_MusteriNo.Text = "";

            //TTip_Info.SetToolTip(CB_CrtPrj_MusteriSecim_Ad, "");
        }
        #endregion
    
        #region NETWORK PROFİL SAYFASI
        private void button9_Click(object sender, EventArgs e)
        {
            CLS.NetworkAdapter.fillList(listBox1);
            CLS.NetworkAdapter.NetworkAdapterListele(DGV_NetworkAdapter);
            CLS.NetworkAdapter.ProfilListele(DGV_NetworkProfil);
        }
        private void B_IPChange_Click(object sender, EventArgs e)
        {
            CLS.NetworkAdapter.SetIpAddress(TB_AdapterName_Set.Text, TB_LocalIP_Set.Text, TB_SubnetMask_Set.Text, CHB_DHCP_Set.Checked, TB_Gateway_Set.Text, TB_DNS1_Set.Text, TB_DNS2_Set.Text);
            CLS.NetworkAdapter.NetworkAdapterListele(DGV_NetworkAdapter);
        }
        private void DGV_NetworkAdapter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DGV_NetworkAdapter.RowCount > 1)
                {
                    if (DGV_NetworkAdapter.CurrentRow.Cells[0].Value != null)
                    {
                        TB_AdapterName_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[0].Value.ToString();
                        TB_AdapterName_Set.Text = DGV_NetworkAdapter.CurrentRow.Cells[0].Value.ToString();
                    }
                    else
                    {
                        TB_AdapterName_Act.Text = "";
                    }

                    if (DGV_NetworkAdapter.CurrentRow.Cells[1].Value != null)
                    {
                        TB_LocalIP_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        TB_LocalIP_Act.Text = "";
                    }
                    if (DGV_NetworkAdapter.CurrentRow.Cells[2].Value != null)
                    {
                        TB_SubnetMask_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[2].Value.ToString();
                    }
                    else
                    {
                        TB_SubnetMask_Act.Text = "";
                    }
                    if (DGV_NetworkAdapter.CurrentRow.Cells[3].Value != null)
                    {
                        TB_Gateway_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[3].Value.ToString();
                    }else
                    {
                        TB_Gateway_Act.Text = "";
                    }

                    if (DGV_NetworkAdapter.CurrentRow.Cells[4].Value != null)
                    {
                        TB_DNS1_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[4].Value.ToString();
                    }else
                    {
                        TB_DNS1_Act.Text = "";
                    }

                    if (DGV_NetworkAdapter.CurrentRow.Cells[5].Value != null)
                    {
                        TB_DNS2_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[5].Value.ToString();
                    }else
                    {
                        TB_DNS2_Act.Text = "";
                    }

                    if (DGV_NetworkAdapter.CurrentRow.Cells[6].Value != null)
                    {
                        TB_DHCP_Act.Text = DGV_NetworkAdapter.CurrentRow.Cells[6].Value.ToString();
                    }else
                    {
                        TB_DHCP_Act.Text = "";
                    }
                  
                }
            }
            catch (Exception)
            {
            }
        
        
        }

        private void CB_IPProfil_MouseDown(object sender, MouseEventArgs e)
        {
            CB_IPProfil.Items.Clear();

            for (int i = 0; i < DGV_NetworkProfil.RowCount - 1; i++)
            {
                CB_IPProfil.Items.Add(DGV_NetworkProfil.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void CB_IPProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLS.NetworkAdapter.ProfilSecimi(CB_IPProfil);
        }

        private void CB_AdapterName_Set_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CB_AdapterName_Set_MouseDown(object sender, MouseEventArgs e)
        {
            CB_AdapterName_Yeni.Items.Clear();

            for (int i = 0; i < DGV_NetworkAdapter.RowCount - 1; i++)
            {
                CB_AdapterName_Yeni.Items.Add(DGV_NetworkAdapter.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void B_YeniProfilOlustur_Click(object sender, EventArgs e)
        {
            Grup_YeniProfilOlustur.Visible = true;
        }

        private void B_YeniNetworkProfil_Iptal_Click(object sender, EventArgs e)
        {
            Grup_YeniProfilOlustur.Visible = false;
        }

        private void B_YeniNetworkProfil_Kaydet_Click(object sender, EventArgs e)
        {
            CLS.NetworkAdapter.ProfilKaydet();
        }

        private void CHB_DHCP_Yeni_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_DHCP_Yeni.Checked)
            {
                TB_LocalIP_Yeni.Enabled     = false;
                TB_Gateway_Yeni.Enabled     = false;
                TB_SubnetMask_Yeni.Enabled  = false;
                TB_DNS1_Yeni.Enabled        = false;
                TB_DNS2_Yeni.Enabled        = false;
            }else
            {
                TB_LocalIP_Yeni.Enabled     = true;
                TB_Gateway_Yeni.Enabled     = true;
                TB_SubnetMask_Yeni.Enabled  = true;
                TB_DNS1_Yeni.Enabled        = true;
                TB_DNS2_Yeni.Enabled        = true;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string a = "https://www.google.com/search?q=" + comboBox1.Text + "+–filetype%3Apdf";

            webBrowser1.Navigate(a);
            //
        }

        private void B_NetwrokProfilTablosu_Ac_Click(object sender, EventArgs e)
        {
            if (File.Exists(CLS.NetworkProfil_ExcelFies) )
            {
                System.Diagnostics.Process.Start(CLS.NetworkProfil_ExcelFies);
            }
            
        }

        #endregion

        #region STOK YONETİMİ

        #region DIYALOG FORMLARINI AÇMA BUTONLARI
        private void B_Stok_MarkaOlustur_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_MarkaYeni.ShowDialog();
        }
        private void B_Stok_UrunOlustur_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_YeniUrun.ShowDialog();
        }
        private void B_Stok_MusteriOlustur_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_YeniMusteri.ShowDialog();
        }
        private void B_Stok_MYetkiliOlustur_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_YeniYetkili.ShowDialog();
        }
        #endregion

        #region STOK ÜRÜN GİRİŞİ
        private void CB_StokUrunGiris_Marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.StokCreateUrun.MarkaAdiSecildi(int.Parse(selectedValue), out string MarkaNo);
            TB_StokUrunGiris_MarkaNo.Text = MarkaNo;

            CLS.Stok_UrunGiris.StokGiris_UrunBilgileriTemizle();
            CB_StokUrunGiris_UrunSecimListe.Items.Clear();

            if (RB_StokUrunGiris_BarkodOku.Checked)
            {
                B_StokUrunGiris_YenidenBarkodOku.Enabled    = true;
                TB_StokUrunGiris_Barkod.Enabled             = true;
                TB_StokUrunGiris_Barkod.BackColor           = Color.Yellow;
                TB_StokUrunGiris_Barkod.Clear();
         
            }

        }
        private void CB_StokUrunGiris_Marka_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.StokCreateUrun.Listele_MarkaAdi(CB_StokUrunGiris_Marka);
            TB_StokUrunGiris_Barkod.BackColor = Color.White;
        }
        private void TB_StokUrunGiris_Barkod_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void TB_StokUrunGiris_Barkod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CLS.Stok_UrunGiris.BUL_Urun_Barkod(CB_StokUrunGiris_Marka.Text, TB_StokUrunGiris_MarkaNo.Text, TB_StokUrunGiris_Barkod.Text.TrimStart());
            }
        }
        private void TB_StokUrunGiris_Barkod_TextChanged(object sender, EventArgs e)
        {
        }
        private void B_StokUrunGiris_YenidenBarkodOku_Click(object sender, EventArgs e)
        {
            TB_StokUrunGiris_Barkod.Clear();
            TB_StokUrunGiris_Barkod.Focus();
        }
        private void CB_StokUrunGiris_UrunSecimListe_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.Stok_UrunGiris.MarkayaGoreUrunleriGetir(CB_StokUrunGiris_Marka.Text, DGV_StokUrunGiris_SecilenMarkaUrunleri);
            CB_StokUrunGiris_UrunSecimListe.Items.Clear();
            for (int i = 0; i < DGV_StokUrunGiris_SecilenMarkaUrunleri.RowCount -1 ; i++)
            {
                string UrunKodu     = DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString();
                string UrunAdi      = DGV_StokUrunGiris_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                string CB_Items = UrunKodu + " # " + UrunAdi;
                CB_StokUrunGiris_UrunSecimListe.Items.Add(CB_Items);
            }
        }
        private void CB_StokUrunGiris_UrunSecimListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLS.Stok_UrunGiris.BUL_Urun_ComboBox(CB_StokUrunGiris_Marka.Text, TB_StokUrunGiris_MarkaNo.Text, CB_StokUrunGiris_UrunSecimListe, DGV_StokUrunGiris_SecilenMarkaUrunleri);
        }
        private void RB_StokUrunGiris_BarkodOku_CheckedChanged(object sender, EventArgs e)
        {
            if (!RB_StokUrunGiris_BarkodOku.Checked)
            {
                TB_StokUrunGiris_Barkod.Visible = false;
                B_StokUrunGiris_YenidenBarkodOku.Visible = false;
                CB_StokUrunGiris_UrunSecimListe.Visible = true;

            }
            else
            {
                CB_StokUrunGiris_UrunSecimListe.Visible     = false;
                TB_StokUrunGiris_Barkod.Visible             = true;
                B_StokUrunGiris_YenidenBarkodOku.Visible    = true;

                TB_StokUrunGiris_Barkod.Enabled = true;
                TB_StokUrunGiris_Barkod.BackColor = Color.Yellow;
                TB_StokUrunGiris_Barkod.Clear();
                TB_StokUrunGiris_Barkod.Focus();
            }
        }
        private void B_StokUrunGiris_IslemOnay_Click(object sender, EventArgs e)
        {
            CLS.Stok_UrunGiris.DepoyaUrunEkle();
        }
        #endregion

        #region STOK SORGULAMA
        private void B_Stok_UrunSorgulama_Yenile_Click(object sender, EventArgs e)
        {
            CLS.Stok_Sorgulama.TumUrunleriGetir(DGV_Stok_Depo);
        }
        private void CB_StokSorgulama_Marka_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.StokCreateUrun.Listele_MarkaAdi(CB_StokSorgulama_Marka);
        }
        private void CB_StokSorgulama_Marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();


            CLS.StokCreateUrun.MarkaAdiSecildi(int.Parse(selectedValue), out string MarkaNo);
            CLS.Stok_UrunGiris.MarkayaGoreUrunleriGetir(CB_StokSorgulama_Marka.Text, DGV_StokTemp);

            TB_StokSorgulama_MarkaNo.Text = MarkaNo;
            TB_StokSorgulama_StokAdeti.Text = "";
            CB_StokSorgulama_UrunAdi.Text = "";
            CB_StokSorgulama_UrunKodu.Text = "";
            StokSorgulamaButonENB();
            DGV_Stok_Depo.Columns.Clear();
        }
        private void CB_StokSorgulama_UrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_StokSorgulama_UrunKodu.SelectedIndex = CB_StokSorgulama_UrunAdi.SelectedIndex;
            TB_StokSorgulama_StokAdeti.Text = "";
            StokSorgulamaButonENB();
        }
        private void CB_StokSorgulama_UrunAdi_MouseDown(object sender, MouseEventArgs e)
        {
            CB_StokSorgulama_UrunAdi.AutoCompleteMode = AutoCompleteMode.None;
            CB_StokSorgulama_UrunKodu.Items.Clear();
            CB_StokSorgulama_UrunAdi.Items.Clear();

            for (int i = 0; i < DGV_StokTemp.RowCount - 1; i++)
            {
                string UrunKodu = DGV_StokTemp.Rows[i].Cells[12].Value.ToString();
                string UrunAdi = DGV_StokTemp.Rows[i].Cells[13].Value.ToString();
                //string CB_Items1 = UrunKodu + " # " + UrunAdi;


                CB_StokSorgulama_UrunKodu.Items.Add(UrunKodu);
                CB_StokSorgulama_UrunAdi.Items.Add(UrunAdi);
            }
        }
        private void CB_StokSorgulama_UrunAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (CB_StokSorgulama_UrunAdi.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            {
                CB_StokSorgulama_UrunAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

        }
        private void CB_StokSorgulama_UrunKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_StokSorgulama_UrunAdi.SelectedIndex = CB_StokSorgulama_UrunKodu.SelectedIndex;
            TB_StokSorgulama_StokAdeti.Text = "";
            StokSorgulamaButonENB();
        }
        private void CB_StokSorgulama_UrunKodu_MouseDown(object sender, MouseEventArgs e)
        {
            CB_StokSorgulama_UrunKodu.AutoCompleteMode = AutoCompleteMode.None;
            CB_StokSorgulama_UrunKodu.Items.Clear();
            CB_StokSorgulama_UrunAdi.Items.Clear();

            for (int i = 0; i < DGV_StokTemp.RowCount - 1; i++)
            {
                string UrunKodu = DGV_StokTemp.Rows[i].Cells[12].Value.ToString();
                string UrunAdi = DGV_StokTemp.Rows[i].Cells[13].Value.ToString();
                //string CB_Items1 = UrunKodu + " # " + UrunAdi;


                CB_StokSorgulama_UrunKodu.Items.Add(UrunKodu);
                CB_StokSorgulama_UrunAdi.Items.Add(UrunAdi);
            }

        }
        private void CB_StokSorgulama_UrunKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (CB_StokSorgulama_UrunKodu.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            {
                CB_StokSorgulama_UrunKodu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void B_StokSorgulama_UrunBul_Click(object sender, EventArgs e)
        {
            if (CB_StokSorgulama_UrunKodu.Text != "" && CB_StokSorgulama_UrunAdi.Text != "" && CB_StokSorgulama_Marka.Text != "")
            {
                CLS.Stok_Sorgulama.UrunBul(CB_StokSorgulama_Marka.Text, CB_StokSorgulama_UrunKodu.Text, DGV_Stok_Depo, out string Adet);
                TB_StokSorgulama_StokAdeti.Text = Adet;
            }
            else
            {
                StokSorgulamaButonENB();
                
            }
         
        }
        private void TB_StokSorgulama_StokAdeti_TextChanged(object sender, EventArgs e)
        {
            if (TB_StokSorgulama_StokAdeti.Text != "")
            {
                if (int.Parse(TB_StokSorgulama_StokAdeti.Text) == 0)
                {
                    TB_StokSorgulama_StokAdeti.BackColor = Color.Red;
                    TB_StokSorgulama_StokAdeti.ForeColor = Color.White;
                }

                if (int.Parse(TB_StokSorgulama_StokAdeti.Text) > 0)
                {
                    TB_StokSorgulama_StokAdeti.BackColor = Color.Lime;
                    TB_StokSorgulama_StokAdeti.ForeColor = Color.Black;
                }

            }
            else
            {
                TB_StokSorgulama_StokAdeti.BackColor = SystemColors.Control;
                TB_StokSorgulama_StokAdeti.ForeColor = Color.Black;
            }

        }
        private void B_StokSorgulama_Export_Click(object sender, EventArgs e)
        {
            CLS.EXL.DGV_ExcelExport(DGV_Stok_Depo);
        }
        void StokSorgulamaButonENB()
        {
            if (CB_StokSorgulama_UrunKodu.Text != "" && CB_StokSorgulama_UrunAdi.Text != "" && CB_StokSorgulama_Marka.Text != "")
            {
                B_StokSorgulama_UrunBul.Enabled = true;
            }else
            {
                B_StokSorgulama_UrunBul.Enabled = false;
            }
           
        }
        #endregion

        #region ÜRÜN ÇIKIŞI
        private void CB_StokUrunCikis_Marka_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.StokCreateUrun.Listele_MarkaAdi(CB_StokUrunCikis_Marka);
            TB_StokUrunCikis_Barkod.BackColor = Color.White;
        }
        private void CB_StokUrunCikis_Marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.StokCreateUrun.MarkaAdiSecildi(int.Parse(selectedValue), out string MarkaNo);
            TB_StokUrunCikis_MarkaNo.Text = MarkaNo;

            CLS.Stok_UrunCikis.StokCikis_UrunBilgileriTemizle();
            CB_StokUrunCikis_UrunSecimListe.Items.Clear();
            if (RB_StokUrunCikis_BarkodOku.Checked)
            {
                B_StokUrunCikis_YenidenBarkodOku.Enabled = true;
                TB_StokUrunCikis_Barkod.Enabled = true;
                TB_StokUrunCikis_Barkod.BackColor = Color.Yellow;
                TB_StokUrunCikis_Barkod.Clear();
                TB_StokUrunCikis_Barkod.Focus();

            }
        }
        private void RB_StokUrunCikis_BarkodOku_CheckedChanged(object sender, EventArgs e)
        {
            if (!RB_StokUrunCikis_BarkodOku.Checked)
            {
                TB_StokUrunCikis_Barkod.Visible = false;
                B_StokUrunCikis_YenidenBarkodOku.Visible = false;
                CB_StokUrunCikis_UrunSecimListe.Visible = true;


            }
            else
            {
                CB_StokUrunCikis_UrunSecimListe.Visible = false;
                TB_StokUrunCikis_Barkod.Visible = true;
                B_StokUrunCikis_YenidenBarkodOku.Visible = true;

                TB_StokUrunCikis_Barkod.Enabled = true;
                TB_StokUrunCikis_Barkod.BackColor = Color.Yellow;
                TB_StokUrunCikis_Barkod.Clear();
                TB_StokUrunCikis_Barkod.Focus();
            }
        }
        private void CB_StokUrunCikis_UrunSecimListe_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.Stok_UrunCikis.MarkayaGoreUrunleriGetir(CB_StokUrunCikis_Marka.Text, DGV_StokUrunCikis_SecilenMarkaUrunleri);
            CB_StokUrunCikis_UrunSecimListe.Items.Clear();
            for (int i = 0; i < DGV_StokUrunCikis_SecilenMarkaUrunleri.RowCount - 1; i++)
            {
                string UrunKodu = DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[12].Value.ToString();
                string UrunAdi = DGV_StokUrunCikis_SecilenMarkaUrunleri.Rows[i].Cells[13].Value.ToString();
                string CB_Items = UrunKodu + " # " + UrunAdi;
                CB_StokUrunCikis_UrunSecimListe.Items.Add(CB_Items);
            }
        }
        private void CB_StokUrunCikis_UrunSecimListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLS.Stok_UrunCikis.BUL_Urun_ComboBox(CB_StokUrunCikis_Marka.Text, TB_StokUrunCikis_MarkaNo.Text, CB_StokUrunCikis_UrunSecimListe, DGV_StokUrunCikis_SecilenMarkaUrunleri);
        }
        private void TB_StokUrunCikis_Barkod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CLS.Stok_UrunCikis.BUL_Urun_Barkod(CB_StokUrunCikis_Marka.Text, TB_StokUrunCikis_MarkaNo.Text, TB_StokUrunCikis_Barkod.Text.TrimStart());
            }
        }
        private void B_StokUrunCikis_YenidenBarkodOku_Click(object sender, EventArgs e)
        {
            TB_StokUrunCikis_Barkod.Clear();
            TB_StokUrunCikis_Barkod.Focus();
        }
        private void CB_StokUrunCikis_Musteri_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.Stok_UrunCikis.Listele_MusteriAdi(CB_StokUrunCikis_Musteri);
        }
        private void CB_StokUrunCikis_Musteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.Stok_UrunCikis.MusteriAdiSecildi(int.Parse(selectedValue), out string MusteriNo);
        }
        private void CB_StokUrunCikis_MYetkili_MouseDown(object sender, MouseEventArgs e)
        {
            CLS.Stok_UrunCikis.Listele_MYetkili(CB_StokUrunCikis_MYetkili);
        }
        private void CB_StokUrunCikis_MYetkili_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            string selectedValue = (cmb.SelectedItem as dynamic).Value.ToString();

            CLS.Stok_UrunCikis.MYetkiliSecildi(int.Parse(selectedValue), out string YetkiliNp);
        }
        private void CB_StokUrunCikis_Aksiyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_StokUrunCikis_Aksiyon.Text == "Diğer")
            {
                TB_StokUrunCikis_AksiyonDiger.Visible = true;
                LB_StokUrunCikis_AksiyonDiger.Visible = true;
            }else
            {
                TB_StokUrunCikis_AksiyonDiger.Visible = false;
                LB_StokUrunCikis_AksiyonDiger.Visible = false;
            }
        }
        private void CHB_StokUrunCikis_FaturaNo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_StokUrunCikis_FaturaNo.Checked)
            {
                TB_StokUrunCikis_FaturaNo.Enabled = true;
            }else
            {
                TB_StokUrunCikis_FaturaNo.Clear();
                TB_StokUrunCikis_FaturaNo.Enabled = false;
            }
        }
        private void CHB_StokUrunCikis_IrsaliyeNo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_StokUrunCikis_IrsaliyeNo.Checked)
            {
                TB_StokUrunCikis_IrsaliyeNo.Enabled = true;
            }
            else
            {
                TB_StokUrunCikis_IrsaliyeNo.Clear();
                TB_StokUrunCikis_IrsaliyeNo.Enabled = false;

            }
        }
        private void CHB_StokUrunCikis_KargoTakipNo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_StokUrunCikis_KargoTakipNo.Checked)
            {
                TB_StokUrunCikis_KargoTakipNo.Enabled = true;
            }
            else
            {
                TB_StokUrunCikis_KargoTakipNo.Clear();
                TB_StokUrunCikis_KargoTakipNo.Enabled = false;
            }
        }
        private void CHB_StokUrunCikis_YeniFiyatIskonto_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_StokUrunCikis_YeniFiyatIskonto.Checked)
            {
                NUD_StokUrunCikis_Fiyat.Enabled = true;
                CB_StokUrunCikis_FiyatBirimi.Enabled = true;
                NUD_StokUrunCikis_Iskonto.Enabled = true;
            }
            else
            {
                NUD_StokUrunCikis_Fiyat.Enabled = false;
                CB_StokUrunCikis_FiyatBirimi.Enabled = false;
                NUD_StokUrunCikis_Iskonto.Enabled = false;
            }
        }




        #endregion

        #endregion

        private void B_StokUrunCikis_IslemOnay_Click(object sender, EventArgs e)
        {
            CLS.Stok_UrunCikis.KontrolEt();
        }

        private void B_StokCikisSorgulama_VeriGetir_Click(object sender, EventArgs e)
        {
            CLS.Stok_SorgulamaCikis.TumUrunleriGetir(DGV_Stok_Cikis);
        }

        private void B_StokCikisSorgulama_Export_Click(object sender, EventArgs e)
        {
            CLS.EXL.DGV_ExcelExport(DGV_Stok_Cikis);
        }

        private void B_Stok_MarkaDuzelt_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_MarkaDuzelt.ShowDialog();
        }

        private void B_Stok_UrunDuzelt_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_UrunDuzelt.ShowDialog();
        }

        private void B_Stok_MusteriDuzelt_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_MusteriDuzelt.ShowDialog();
        }

        private void B_Stok_MYetkiliDuzelt_Click(object sender, EventArgs e)
        {
            CLS.Form_Stok_YetkiliDuzelt.ShowDialog();
        }

        int a;
        private void Panel_Main_DragDrop(object sender, DragEventArgs e)
        {
            a++;
            label80.Text = a.ToString();
        }


    }
}
