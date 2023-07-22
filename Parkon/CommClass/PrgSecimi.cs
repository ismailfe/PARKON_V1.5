using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class PrgSecimi
    {
        public CLS CLS;

        public TabControl TabTemp = new TabControl();



        public string SayfaDuzen_Kontrolleri()
        {
            try
            {

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
                ImgList_TabMain.ImageSize = new Size(38, 38);
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
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR: " + HATA.ToString();
            }
        }


        public string Secim()
        {
            SayfaDuzen_Kontrolleri();

            if (File.Exists(CLS.PrgSecim_Config))
            {
                if (!File.Exists(CLS.PrgSecim_Admin))
                {    //Admin dosyası yok
                    if (!File.Exists(CLS.PrgSecim_Otomasyon))
                    {    //Otomasyon dosyası yok
                        if (!File.Exists(CLS.PrgSecim_Elektronik))
                        {    //Elektronik dosyası yok

                        }
                        else
                        {    //Elektronik dosyası var
                            Elektronik();
                        }

                    }
                    else    //Otomasyon dosyası var
                    {
                        Otomasyon();
                    }

                }
                else // Admin dosyası var
                {
                    Admin();
                }
            }
            else
            {
                IlkCalistirma();
            }
           
           

            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_ProjeSorgula"])
            //{

            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_ProjeYeni"])
            //{

            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Servis"])
            //{

            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Teklif"])
            //{

            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Rapor"])
            //{

            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Otomasyon"])
            //{
            //    CLS.NetworkAdapter.NetworkAdapterListele(DGV_NetworkAdapter);
            //    CLS.NetworkAdapter.ProfilListele(DGV_NetworkProfil);
            //}
            //if (Tab_Main.SelectedTab == Tab_Main.TabPages["TabPage_Ayarlar"])
            //{

            //}


            return "OK!";
        }


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

        public string Otomasyon()
        {
            //SayfaDuzen_Kontrolleri();
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeSorgula);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeYeni);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Servis);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Teklif);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Rapor);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Stok);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Otomasyon);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Ayarlar);

            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_ProjeSorgula);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_ProjeYeni);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Servis);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Teklif);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Rapor);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Stok);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Otomasyon);
            TabTemp.TabPages.Add(CLS.Form_Main.TabPage_Ayarlar);



            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Stok);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Ayarlar);

            return "OK!";
        }

        public string Elektronik()
        {
            //SayfaDuzen_Kontrolleri();

            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeSorgula);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeYeni);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Servis);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Teklif);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Rapor);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Stok);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Otomasyon);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Ayarlar);

            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_ProjeSorgula);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_ProjeYeni);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Servis);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Teklif);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Rapor);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Stok);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Otomasyon);
            CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Ayarlar);

            return "OK!";
        }
        public string Admin()
        {
            //SayfaDuzen_Kontrolleri();
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_ProjeSorgula);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Otomasyon);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_ProjeYeni);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Servis);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Teklif);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Rapor);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Stok);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Otomasyon);
            //CLS.Form_Main.Tab_Main.TabPages.Add(CLS.Form_Main.TabPage_Ayarlar);
            return "OK!";
        }

        public string IlkCalistirma()
        {
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeSorgula);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_ProjeYeni);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Servis);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Teklif);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Rapor);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Stok);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Otomasyon);
            CLS.Form_Main.Tab_Main.TabPages.Remove(CLS.Form_Main.TabPage_Ayarlar);

            CLS.Form_PrgSecim.ShowDialog();
            return "OK!";
        }

    }
}
