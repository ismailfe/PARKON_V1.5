using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class ProjeSorgulamaGecmisi
    {
        public CLS CLS;

        string[] ProjeAramaGecmisi_LogText = new string[14];
        string ProjeAramaGecmisi_LogText2;

        public int IndexNoSilme;

        char[] delimiterChars = { '#' };
        UC_ProjeAramaGecmisi[] UC_ProjeAramaGecmisi;

             

        public string ProjeGecmisKaydet()
        {
            try
            {

                if (CLS.Form_Main.RTB_ProjeAramaGecmisi.Text.Contains(CLS.Form_Main.TB_Sorgu_ProjeKodu.Text))
                {

                }
                else
                {
                    ProjeAramaGecmisi_LogText[0] = "#";
                    ProjeAramaGecmisi_LogText[1] = CLS.Form_Main.CB_Sorgu_MusteriAdi.Text;
                    ProjeAramaGecmisi_LogText[2] = " - ";
                    ProjeAramaGecmisi_LogText[3] = CLS.Form_Main.CB_Sorgu_BolumAdi.Text;
                    ProjeAramaGecmisi_LogText[4] = " - ";
                    ProjeAramaGecmisi_LogText[5] = CLS.Form_Main.CB_Sorgu_ProjeAdi.Text;
                    ProjeAramaGecmisi_LogText[6] = " // ";
                    ProjeAramaGecmisi_LogText[7] = CLS.Form_Main.CB_Sorgu_RevAdi.Text;
                    ProjeAramaGecmisi_LogText[8] = " (R";
                    ProjeAramaGecmisi_LogText[9] = CLS.Form_Main.CB_Sorgu_RevNo.Text;
                    ProjeAramaGecmisi_LogText[10] = ") #";
                    ProjeAramaGecmisi_LogText[11] = CLS.Form_Main.TB_Sorgu_ProjeKodu.Text;
                    ProjeAramaGecmisi_LogText[12] = " # ";
                    ProjeAramaGecmisi_LogText[13] = CLS.Form_Main.TB_Sorgu_ProjeYolu.Text;

                    ProjeAramaGecmisi_LogText2 = "";
                    for (int i = 0; i < ProjeAramaGecmisi_LogText.Length; i++)
                    {
                        ProjeAramaGecmisi_LogText2 += ProjeAramaGecmisi_LogText[i];
                    }

                    CLS.Log.LOGYAZ("Log_ProjeAramaGecmisi", CLS.Form_Main.RTB_ProjeAramaGecmisi, ProjeAramaGecmisi_LogText2, Color.Black, true, false);

                }
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }
        }
        public string ProjeGecmisGoster()
        {
            try
            {
                CLS.Form_Main.FP_ProjeAramaGecmisi.Controls.Clear();
                CLS.Log.LogFileRead(CLS.Form_Main.RTB_ProjeAramaGecmisi, CLS.Log_ProjeAramaGecmisi);
                int idx = CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines.Count();
                UC_ProjeAramaGecmisi = new UC_ProjeAramaGecmisi[idx];
                for (int i = 0; i < CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines.Count(); i++)
                {
                    if (CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines[i].ToString() != "")
                    {
                        UC_ProjeAramaGecmisi[i] = new UC_ProjeAramaGecmisi();
                        UC_ProjeAramaGecmisi[i].XID_B_GecmistenSil_Click += new System.EventHandler(UC_ProjeAramaGecmisi_XID_B_GecmistenSil_Click);
                        UC_ProjeAramaGecmisi[i].CLS = CLS;
                        UC_ProjeAramaGecmisi[i].XID_TB_ProjeIndex.Text = i.ToString();
                        string[] ProjeInfo = CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines[i].ToString().Split(delimiterChars);


                        UC_ProjeAramaGecmisi[i].XID_TB_ProjeInfo.Text = ProjeInfo[1];
                        UC_ProjeAramaGecmisi[i].XID_TB_ProjeKodu.Text = ProjeInfo[2];
                        UC_ProjeAramaGecmisi[i].XID_TB_ProjePath.Text = ProjeInfo[3];
                        UC_ProjeAramaGecmisi[i].XID_TB_ProjeIndex.Text = i.ToString();

                        CLS.Form_Main.FP_ProjeAramaGecmisi.Controls.Add(UC_ProjeAramaGecmisi[i]);
                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }
        }



        public void UC_ProjeAramaGecmisi_XID_B_GecmistenSil_Click(object sender, EventArgs e)
        {
            ProjeGecmisSil(IndexNoSilme);
        }



        public string ProjeGecmisSil(int SatirIndexNo)
        {
            try
            {
                CLS.Log.LogFileRead(CLS.Form_Main.RTB_ProjeAramaGecmisi, CLS.Log_ProjeAramaGecmisi);
                int idx = CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines.Count();

                RichTextBox RTB_Temp = new RichTextBox();
                
                for (int i = 0; i < idx; i++)
                {
                    if (i != SatirIndexNo && i != SatirIndexNo+1)
                    {
                        RTB_Temp.Text += CLS.Form_Main.RTB_ProjeAramaGecmisi.Lines[i] + "\n";
                    }
                   
                }

                CLS.Log.Log_Save("Log_ProjeAramaGecmisi", RTB_Temp);
                CLS.Log.LogFileRead(CLS.Form_Main.RTB_ProjeAramaGecmisi, CLS.Log_ProjeAramaGecmisi);

                if (CLS.Form_Main.RTB_ProjeAramaGecmisi.Text.Trim() == "")
                {
                    CLS.Log.Log_Temizle("Log_ProjeAramaGecmisi");
                }

                ProjeGecmisGoster();
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }
        }
    }
}
