using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDExcel;

namespace Parkon
{

    public class ProjeSorgulama
    {
        public CLS CLS;
        public bool OnlineCalismaModu;
        void CalismaModSecimi()
        {
            try
            {
                if (CLS.Form_Main.CHB_OnlineDataBase.Checked)
                {
                    OnlineCalismaModu = true;
                }
                else
                {
                    OnlineCalismaModu = false;
                }
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }


        }

        #region MÜŞTERİ SEÇİMİ

        #region MÜŞTERİ ADI İLE SEÇİM
        public string Listele_MusteriAdi(ComboBox Liste)
        {
            try
            {
                CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteri, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        item        = new ComboboxItem();
                        item.Text   = DTable.Rows[i][5].ToString(); //MusteriAdi
                        item.Value  = DTable.Rows[i][0].ToString();
                        Liste.Items.Add(item);
                    }

                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteri.RowCount - 1; i++)
                    {
                        item = new ComboboxItem();
                        item.Text = CLS.Form_Main.DGVMusteri.Rows[i].Cells[5].Value.ToString();
                        item.Value = CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString();
                        Liste.Items.Add(item);
                    }
                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string MusteriAdiSecildi(int Index, out string MusteriNo, out string MusteriBolge, out string MusteriAdres, out string MapsLink, out string MusteriTel, out string notlar, out string INFO)
        {
            MusteriNo = "";
            MusteriBolge = "";
            MusteriAdres = "";
            MapsLink = "";
            MusteriTel = "";
            notlar = "";
            INFO = "";
            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) // ONLİNE ÇALIŞMA
                {

                    string[] RData = new string[10];
                if (Index >= 0)
                {
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBMusteri, CLS.MySQLVar.ColumnName_DBMusteri, RData, "ID", Index.ToString());
                }

                INFO = "ID:" + RData[0] + " Date:" + RData[1] + " Creator:" + RData[2] + "\n" + "\n";
                notlar = RData[3];
                MusteriNo = RData[4].Trim();
                MusteriBolge = RData[6];
                MusteriAdres = RData[7];
                MapsLink = RData[8];
                MusteriTel = RData[9];
           

                }
                else //LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteri.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString().Trim() == Index.ToString().Trim() )
                        {
                            string rID = CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString();
                            string rDate = CLS.Form_Main.DGVMusteri.Rows[i].Cells[1].Value.ToString();
                            string rCreator = CLS.Form_Main.DGVMusteri.Rows[i].Cells[2].Value.ToString();


                            INFO = "ID:" + rID + " Date:" + rDate + " Creator:" + rCreator + "\n" + "\n";
                            notlar = CLS.Form_Main.DGVMusteri.Rows[i].Cells[3].Value.ToString();
                            MusteriNo = CLS.Form_Main.DGVMusteri.Rows[i].Cells[4].Value.ToString();
                            MusteriBolge = CLS.Form_Main.DGVMusteri.Rows[i].Cells[6].Value.ToString();
                            MusteriAdres = CLS.Form_Main.DGVMusteri.Rows[i].Cells[7].Value.ToString();
                            MapsLink = CLS.Form_Main.DGVMusteri.Rows[i].Cells[8].Value.ToString();
                            MusteriTel = CLS.Form_Main.DGVMusteri.Rows[i].Cells[9].Value.ToString();



                        }
                    }



                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #region MÜŞTERİ NO İLE SEÇİM
        public string Listele_MusteriNo(ComboBox Liste)
        {
            try
            {
                CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteri, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        item = new ComboboxItem();
                        item.Text = DTable.Rows[i][4].ToString(); //MusteriNo
                        item.Value = DTable.Rows[i][0].ToString();
                        Liste.Items.Add(item);
                    }
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteri.RowCount - 1; i++)
                    {
                        item = new ComboboxItem();
                        item.Text = CLS.Form_Main.DGVMusteri.Rows[i].Cells[4].Value.ToString();
                        item.Value = CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString();
                        Liste.Items.Add(item);
                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string MusteriNoSecildi(int ID, out string MusteriAdi, out string MusteriBolge, out string MusteriAdres, out string MapsLink, out string MusteriTel, out string notlar, out string INFO)
        {
            MusteriAdi = "";
            MusteriBolge = "";
            MusteriAdres = "";
            MapsLink = "";
            MusteriTel = "";
            notlar = "";
            INFO = "";
            try
            {
                CalismaModSecimi();
                //ComboboxItem item;

                if (OnlineCalismaModu) // ONLİNE ÇALIŞMA
                {

                    string[] RData = new string[10];
                    if (ID >= 0)
                    {
                        CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBMusteri, CLS.MySQLVar.ColumnName_DBMusteri, RData, "ID", ID.ToString());
                    }

                    INFO            = "ID:" + RData[0] + " Date:" + RData[1] + " Creator:" + RData[2] + "\n" + "\n";
                    notlar          = RData[3];
                    MusteriAdi      = RData[5];
                    MusteriBolge    = RData[6];
                    MusteriAdres    = RData[7];
                    MapsLink        = RData[8];
                    MusteriTel      = RData[9];


                }
                else //LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteri.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString() == ID.ToString())
                        {

                            INFO            =  "ID:" + CLS.Form_Main.DGVMusteri.Rows[i].Cells[0].Value.ToString() +
                                               " Date:" + CLS.Form_Main.DGVMusteri.Rows[i].Cells[1].Value.ToString() +
                                               " Creator:" + CLS.Form_Main.DGVMusteri.Rows[i].Cells[2].Value.ToString() + "\n" + "\n";
                            notlar          = CLS.Form_Main.DGVMusteri.Rows[i].Cells[3].Value.ToString();
                            MusteriAdi      = CLS.Form_Main.DGVMusteri.Rows[i].Cells[5].Value.ToString();
                            MusteriBolge    = CLS.Form_Main.DGVMusteri.Rows[i].Cells[6].Value.ToString();
                            MusteriAdres    = CLS.Form_Main.DGVMusteri.Rows[i].Cells[7].Value.ToString();
                            MapsLink        = CLS.Form_Main.DGVMusteri.Rows[i].Cells[8].Value.ToString();
                            MusteriTel      = CLS.Form_Main.DGVMusteri.Rows[i].Cells[9].Value.ToString();
                            break;
                        }
                    }

                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #endregion

        #region BÖLÜM SEÇİMİ

        #region BÖLÜM ADI İLE SEÇİM
        public string Listele_BolumAdi(ComboBox Liste, string MusteriNo)
        {
            try
            {
                CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteriBolum, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        if (DTable.Rows[i][4].ToString() == MusteriNo.Trim())
                        {
                            item        = new ComboboxItem();
                            item.Text   = DTable.Rows[i][7].ToString(); //BölümAdı
                            item.Value  = DTable.Rows[i][0].ToString();
                            Liste.Items.Add(item);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteriBolum.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim())
                        {
                            
                                item = new ComboboxItem();
                                item.Text = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[7].Value.ToString();
                                item.Value = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[0].Value.ToString();
                                Liste.Items.Add(item);
                        }
                       
                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string BolumAdiSecildi(int Index, string MusteriNo, string BolumAdi, out string BolumNo, out string BolumNot)
        {
            BolumNo = "";
            BolumNot = "";
            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    string[] RData = new string[9];
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBMusteriBolum, CLS.MySQLVar.ColumnName_DBMusteriBolum, RData, "ID", Index.ToString());
        
                    BolumNo = RData[6];
                    BolumNot = RData[3];
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteriBolum.RowCount -1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim() && CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[7].Value.ToString().Trim() == BolumAdi.Trim())
                        {
                            BolumNo = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[6].Value.ToString();
                            BolumNot = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[3].Value.ToString();
                        }
                    }

                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #region BÖLÜM NO İLE SEÇİM
        public string Listele_BolumNo(ComboBox Liste, string MusteriNo)
        {
            try
            {
                CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteriBolum, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        if (DTable.Rows[i][4].ToString() == MusteriNo.Trim())
                        {
                            item        = new ComboboxItem();
                            item.Text   = DTable.Rows[i][6].ToString(); 
                            item.Value  = DTable.Rows[i][0].ToString();
                            Liste.Items.Add(item);
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteriBolum.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim())
                        {

                            item = new ComboboxItem();
                            item.Text = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[6].Value.ToString();
                            item.Value = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[0].Value.ToString();
                            Liste.Items.Add(item);
                        }

                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string BolumNoSecildi(int ID, string MusteriNo, string BolumNo, out string BolumAdi, out string BolumNot)
        {
            BolumAdi = "";
            BolumNot = "";
            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    string[] RData = new string[9];
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBMusteriBolum, CLS.MySQLVar.ColumnName_DBMusteriBolum, RData, "ID", ID.ToString());

                    BolumAdi = RData[7];
                    BolumNot = RData[3];
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVMusteriBolum.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[0].Value.ToString() == ID.ToString())
                        {
                            BolumAdi = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[7].Value.ToString();
                            BolumNot = CLS.Form_Main.DGVMusteriBolum.Rows[i].Cells[3].Value.ToString();
                            break;
                        }
                    }

                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #endregion

        #region PROJE SEÇİMİ

        #region PROJE ADI İLE SEÇİM
        public string Listele_Projeler(ComboBox Liste, string MusteriNo, string BolumNo)
        {
            try
            {
                CalismaModSecimi();
                Liste.Items.Clear();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBProje, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        //MusteriNo && BölümNo
                        if (DTable.Rows[i][4].ToString() == MusteriNo.Trim() && DTable.Rows[i][6].ToString() == BolumNo.Trim())
                        {
                            item        = new ComboboxItem();
                            item.Text   = DTable.Rows[i][10].ToString();
                            item.Value  = DTable.Rows[i][0].ToString();
                            Liste.Items.Add(item);
                        }
                    }
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVProje.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVProje.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim() && CLS.Form_Main.DGVProje.Rows[i].Cells[6].Value.ToString().Trim() == BolumNo.Trim())
                        {
                            item = new ComboboxItem();
                            item.Text = CLS.Form_Main.DGVProje.Rows[i].Cells[10].Value.ToString();
                            item.Value = CLS.Form_Main.DGVProje.Rows[i].Cells[0].Value.ToString();
                            Liste.Items.Add(item);
                        }

                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string ProjeSecildi(int Index, string MusteriNo, string BolumNo, string ProjeAdi, out string ProjeNo, out string ProjeKodu, out string ProjeBasTarih, out string ProjeDonem, out string ProjeNot, out string INFO)
        {
            ProjeNo = "";
            ProjeKodu = "";
            ProjeBasTarih = "";
            ProjeDonem = "";
            ProjeNot = "";
            INFO = "";
            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    string[] RData = new string[26];
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBProje, CLS.MySQLVar.ColumnName_DBProje, RData, "ID", Index.ToString());

                    ProjeNo = RData[8];
                    ProjeKodu = RData[9];
                    ProjeBasTarih = RData[11];
                    ProjeDonem = RData[12] + "." + RData[13];
                    ProjeNot = RData[3];
                    INFO = "ID:" + RData[0] + " Date:" + RData[1] + " Creator:" + RData[2] + "\n" + "\n";
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVProje.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVProje.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim() &&
                            CLS.Form_Main.DGVProje.Rows[i].Cells[6].Value.ToString().Trim() == BolumNo.Trim() &&
                            CLS.Form_Main.DGVProje.Rows[i].Cells[10].Value.ToString().Trim() == ProjeAdi.Trim())
                        {
                            ProjeNo         = CLS.Form_Main.DGVProje.Rows[i].Cells[8].Value.ToString();
                            ProjeKodu       = CLS.Form_Main.DGVProje.Rows[i].Cells[9].Value.ToString();
                            ProjeBasTarih   = CLS.Form_Main.DGVProje.Rows[i].Cells[11].Value.ToString();
                            ProjeDonem      = CLS.Form_Main.DGVProje.Rows[i].Cells[12].Value.ToString() + "." + CLS.Form_Main.DGVProje.Rows[i].Cells[12].Value.ToString();
                            ProjeNot        = CLS.Form_Main.DGVProje.Rows[i].Cells[3].Value.ToString();
                            INFO            = "ID:" + CLS.Form_Main.DGVProje.Rows[i].Cells[0].Value.ToString() + " Date: " + CLS.Form_Main.DGVProje.Rows[i].Cells[1].Value.ToString() +
                                              " Creator: " + CLS.Form_Main.DGVProje.Rows[i].Cells[2].Value.ToString();
                        }

                    }

                }


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #region PROJE KODU İLE SEÇİM
        public string Listele_ProjeKodu(ComboBox Liste, string MusteriNo, string BolumNo)
        {
            try
            {
                Liste.Items.Clear();
                CalismaModSecimi();
                ComboboxItem item;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBProje, null, DTable);

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        //MusteriNo && BölümNo
                        if (DTable.Rows[i][4].ToString() == MusteriNo.Trim() && DTable.Rows[i][6].ToString() == BolumNo.Trim())
                        {
                            item = new ComboboxItem();
                            item.Text = DTable.Rows[i][9].ToString();
                            item.Value = DTable.Rows[i][0].ToString();
                            Liste.Items.Add(item);
                        }
                    }
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVProje.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVProje.Rows[i].Cells[4].Value.ToString().Trim() == MusteriNo.Trim() && CLS.Form_Main.DGVProje.Rows[i].Cells[6].Value.ToString().Trim() == BolumNo.Trim())
                        {
                            item = new ComboboxItem();
                            item.Text = CLS.Form_Main.DGVProje.Rows[i].Cells[9].Value.ToString();
                            item.Value = CLS.Form_Main.DGVProje.Rows[i].Cells[0].Value.ToString();
                            Liste.Items.Add(item);
                        }
                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string ProjeKoduSecildi(string ID, out string ProjeNo, out string ProjeAdi, out string ProjeBasTarih, out string ProjeDonem, out string ProjeNot, out string INFO)
        {
            ProjeNo = "";
            ProjeAdi = "";
            ProjeBasTarih = "";
            ProjeDonem = "";
            ProjeNot = "";
            INFO = "";

            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    string[] RData = new string[26];
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBProje, CLS.MySQLVar.ColumnName_DBProje, RData, "ID", ID);

                    ProjeNo = RData[8];
                    ProjeAdi = RData[10];
                    ProjeBasTarih = RData[11];
                    ProjeDonem = RData[12] + "." + RData[13];
                    ProjeNot = RData[3];
                    INFO = "ID:" + RData[0] + " Date:" + RData[1] + " Creator:" + RData[2] + "\n" + "\n";
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVProje.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVProje.Rows[i].Cells[0].Value.ToString().Trim() == ID.Trim())
                        {
                            ProjeNo         = CLS.Form_Main.DGVProje.Rows[i].Cells[8].Value.ToString();
                            ProjeAdi        = CLS.Form_Main.DGVProje.Rows[i].Cells[10].Value.ToString();
                            ProjeBasTarih   = CLS.Form_Main.DGVProje.Rows[i].Cells[11].Value.ToString();
                            ProjeDonem      = CLS.Form_Main.DGVProje.Rows[i].Cells[12].Value.ToString() + "." + CLS.Form_Main.DGVProje.Rows[i].Cells[12].Value.ToString();
                            ProjeNot        = CLS.Form_Main.DGVProje.Rows[i].Cells[3].Value.ToString();
                            INFO            = "ID:" + CLS.Form_Main.DGVProje.Rows[i].Cells[0].Value.ToString() + " Date: " + CLS.Form_Main.DGVProje.Rows[i].Cells[1].Value.ToString() +
                                              " Creator: " + CLS.Form_Main.DGVProje.Rows[i].Cells[2].Value.ToString();
                            break;
                        }
                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion

        #endregion

        #region REVİZYON SEÇİMİ
        public string Listele_Revizyonlar(ComboBox Liste_Ad, ComboBox Liste_No, string ProjeKodu)
        {
            try
            {
                CalismaModSecimi();
                Liste_Ad.Items.Clear();
                Liste_No.Items.Clear();
                ComboboxItem item;
                ComboboxItem item2;

                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    DataTable DTable = new DataTable();
                    CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBRev, null, DTable);

                    Liste_Ad.Items.Add("Revizyon yok");
                    Liste_No.Items.Add("00");

                    for (int i = 0; i < DTable.Rows.Count; i++)
                    {
                        if (DTable.Rows[i][9].ToString() == ProjeKodu.Trim() )
                        {
                            item        = new ComboboxItem();
                            item.Text   = DTable.Rows[i][25].ToString();
                            item.Value  = DTable.Rows[i][0].ToString();
                            Liste_Ad.Items.Add(item);

                            item2       = new ComboboxItem();
                            item2.Text  = DTable.Rows[i][24].ToString();
                            item2.Value = DTable.Rows[i][0].ToString();
                            Liste_No.Items.Add(item2);
                        }
                    }
                }
                else //LOCAL ÇALIŞMA
                {
                    Liste_Ad.Items.Clear();
                    Liste_No.Items.Clear();

                    Liste_Ad.Items.Add("Revizyon yok");
                    Liste_No.Items.Add("00");

                    for (int i = 0; i < CLS.Form_Main.DGVRev.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVRev.Rows[i].Cells[9].Value.ToString().Trim() == ProjeKodu.Trim() )
                        {
                            item = new ComboboxItem();
                            item.Text = CLS.Form_Main.DGVRev.Rows[i].Cells[25].Value.ToString();
                            item.Value = CLS.Form_Main.DGVRev.Rows[i].Cells[0].Value.ToString();
                            Liste_Ad.Items.Add(item);

                            item2 = new ComboboxItem();
                            item2.Text = CLS.Form_Main.DGVRev.Rows[i].Cells[24].Value.ToString();
                            item2.Value = CLS.Form_Main.DGVRev.Rows[i].Cells[0].Value.ToString();
                            Liste_No.Items.Add(item2);
                        }

                    }
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        public string RevSecildi(int Index, string ProjeKod, string RevNo, out string RevBasTarih, out string RevDonem, out string RevNot, out string INFO)
        {
            RevBasTarih = "";
            RevDonem = "";
            RevNot = "";
            INFO = "";
            try
            {
                CalismaModSecimi();
                if (OnlineCalismaModu) //ONLİNE ÇALIŞMA
                {
                    string[] RData = new string[26];
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBRev, CLS.MySQLVar.ColumnName_DBRev, RData, "ID", Index.ToString());

                    RevBasTarih = RData[21];
                    RevDonem = RData[22] + "." + RData[23];
                    RevNot = RData[3];
                    INFO = "ID:" + RData[0] + " Date:" + RData[1] + " Creator:" + RData[2] + "\n" + "\n";
                }
                else // LOCAL ÇALIŞMA
                {
                    for (int i = 0; i < CLS.Form_Main.DGVRev.RowCount - 1; i++)
                    {
                        if (CLS.Form_Main.DGVRev.Rows[i].Cells[9].Value.ToString().Trim() == ProjeKod.Trim() &&
                            CLS.Form_Main.DGVRev.Rows[i].Cells[24].Value.ToString().Trim() == RevNo.Trim()
                            )
                        {

                            RevBasTarih     = CLS.Form_Main.DGVRev.Rows[i].Cells[21].Value.ToString();
                            RevDonem        = CLS.Form_Main.DGVRev.Rows[i].Cells[22].Value.ToString() + "." + CLS.Form_Main.DGVRev.Rows[i].Cells[23].Value.ToString();
                            RevNot          = CLS.Form_Main.DGVRev.Rows[i].Cells[3].Value.ToString();
                            INFO            = "ID:" + CLS.Form_Main.DGVRev.Rows[i].Cells[0].Value.ToString() + " Date: " + CLS.Form_Main.DGVRev.Rows[i].Cells[1].Value.ToString() +
                                              " Creator: " + CLS.Form_Main.DGVRev.Rows[i].Cells[2].Value.ToString();
                        }

                    }

                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }

        #endregion

        #region SORGULAMA İŞLEMLERİ

        #region VARIABLES

        UC_DosyaBrowser DosyaBrowser_PLC                = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_HMI                = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_PrgDiger           = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_PC                 = new UC_DosyaBrowser();

        UC_DosyaBrowser DosyaBrowser_Cihazlar           = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_Cizimler           = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_DigerDokumanlar    = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_Formlar            = new UC_DosyaBrowser();

        UC_DosyaBrowser DosyaBrowser_Gelenler           = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_Teklifler          = new UC_DosyaBrowser();

        UC_DosyaBrowser DosyaBrowser_TeklifOnaylanan    = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_TeklifVerilen      = new UC_DosyaBrowser();

        UC_DosyaBrowser DosyaBrowser_MusteriIliskileri  = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_MalzemeListesi     = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_ElektrikProjesi    = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_Programlar         = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_Dokumanlar         = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_FotografVideo      = new UC_DosyaBrowser();
        UC_DosyaBrowser DosyaBrowser_IsZamanPlani       = new UC_DosyaBrowser();

        string KlasorYolu_MusteriIliskileri;
        string KlasorYolu_MalzemeListesi;
        string KlasorYolu_ElektrikProjesi;
        string KlasorYolu_Programlar;
        string KlasorYolu_Dokumanlar;
        string KlasorYolu_FotografVideo;
        string KlasorYolu_IsZamanPlani;
        //D4 Alt Klasorleri
        string KlasorYolu_PLC;
        string KlasorYolu_HMI;
        string KlasorYolu_PrgDiger;
        string KlasorYolu_PC;
        //D5 Alt Klasorleri
        string KlasorYolu_Cihazlar;
        string KlasorYolu_Cizimler;
        string KlasorYolu_DigerDokumanlar;
        string KlasorYolu_Formlar;
        //D1 Alt Klasorleri
        string KlasorYolu_Gelenler;
        string KlasorYolu_Teklifler;
        //D1-Teklifler Alt Klasörleri
        string KlasorYolu_TeklifOnaylanan;
        string KlasorYolu_TeklifVerilen;

        string AnaDizin;
        string MusteriNo;
        string MusteriAdi;
        string ProjeKodu;
        string RevizyonNo;

        public string KlasorYolu_MusteriKlasoru;
        public string KlasorYolu_ProjeKlasoru;
        public string KlasorYolu_HedefProjeKlasoru;

        #endregion
        public static long KlasorBoyutKontrol(DirectoryInfo yol)
        {
            return yol.GetFiles().Sum(fi => fi.Length) +
            yol.GetDirectories().Sum(di => KlasorBoyutKontrol(di));

        }
        public static bool KlasorDoluBosKontrol(string KlasorYolu)
        {
            DirectoryInfo Yol = new DirectoryInfo(KlasorYolu);
            if (Yol.GetFiles().Sum(fi => fi.Length) + Yol.GetDirectories().Sum(di => KlasorBoyutKontrol(di)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        

      

        }

        public void AdresTanimlamalari(bool ProjeKoduIleArama)
        {
            if (ProjeKoduIleArama)
            {
                AnaDizin = CLS.Form_Main.TB_SecilenAnaDizin.Text;
                MusteriNo = CLS.Form_Main.TB_Sorgu_MusteriNo.Text;
                MusteriAdi = CLS.Form_Main.CB_Sorgu_MusteriAdi.Text;
                ProjeKodu = CLS.Form_Main.TB_Sorgu_ProjeKodu.Text;
                RevizyonNo = "R" + CLS.Form_Main.CB_Sorgu_RevNo.Text;
            }
            else
            { 
                AnaDizin         = CLS.Form_Main.TB_SecilenAnaDizin.Text;
                MusteriNo        = CLS.Form_Main.TB_Sorgu_MusteriNo.Text;
                MusteriAdi       = CLS.Form_Main.CB_Sorgu_MusteriAdi.Text;
                ProjeKodu        = CLS.Form_Main.TB_Sorgu_ProjeKodu.Text;
                RevizyonNo       = "R" + CLS.Form_Main.CB_Sorgu_RevNo.Text;
            }

            KlasorYolu_MusteriKlasoru       = AnaDizin + MusteriNo      + " " + MusteriAdi;
            KlasorYolu_ProjeKlasoru         = KlasorYolu_MusteriKlasoru + "\\" + ProjeKodu;
            KlasorYolu_HedefProjeKlasoru    = KlasorYolu_ProjeKlasoru   + "\\" + RevizyonNo;

            KlasorYolu_MusteriIliskileri    = KlasorYolu_HedefProjeKlasoru + "\\" + "D1";
            KlasorYolu_MalzemeListesi       = KlasorYolu_HedefProjeKlasoru + "\\" + "D2";
            KlasorYolu_ElektrikProjesi      = KlasorYolu_HedefProjeKlasoru + "\\" + "D3";
            KlasorYolu_Programlar           = KlasorYolu_HedefProjeKlasoru + "\\" + "D4";
            KlasorYolu_Dokumanlar           = KlasorYolu_HedefProjeKlasoru + "\\" + "D5";
            KlasorYolu_FotografVideo        = KlasorYolu_HedefProjeKlasoru + "\\" + "D6";
            KlasorYolu_IsZamanPlani         = KlasorYolu_HedefProjeKlasoru + "\\" + "D7";

            KlasorYolu_Gelenler             = KlasorYolu_HedefProjeKlasoru + "\\" + "D1" + "\\" + "Gelenler";
            KlasorYolu_Teklifler            = KlasorYolu_HedefProjeKlasoru + "\\" + "D1" + "\\" + "Teklifler";
            KlasorYolu_TeklifOnaylanan      = KlasorYolu_HedefProjeKlasoru + "\\" + "D1" + "\\" + "Teklifler" + "\\" + "Teklif - Onaylanan";
            KlasorYolu_TeklifVerilen        = KlasorYolu_HedefProjeKlasoru + "\\" + "D1" + "\\" + "Teklifler" + "\\" + "Teklif - Verilen";

            KlasorYolu_PLC                  = KlasorYolu_HedefProjeKlasoru + "\\" + "D4" + "\\" + "PLC";
            KlasorYolu_HMI                  = KlasorYolu_HedefProjeKlasoru + "\\" + "D4" + "\\" + "HMI";
            KlasorYolu_PC                   = KlasorYolu_HedefProjeKlasoru + "\\" + "D4" + "\\" + "PC";
            KlasorYolu_PrgDiger             = KlasorYolu_HedefProjeKlasoru + "\\" + "D4" + "\\" + "Diger";

            KlasorYolu_Cihazlar             = KlasorYolu_HedefProjeKlasoru + "\\" + "D5" + "\\" + "Cihazlar";
            KlasorYolu_Cizimler             = KlasorYolu_HedefProjeKlasoru + "\\" + "D5" + "\\" + "Cizimler";
            KlasorYolu_DigerDokumanlar      = KlasorYolu_HedefProjeKlasoru + "\\" + "D5" + "\\" + "Diger";
            KlasorYolu_Formlar              = KlasorYolu_HedefProjeKlasoru + "\\" + "D5" + "\\" + "Formlar";


            //Klasor_Musteri_Iliskileri = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Musteri_Iliskileri;
            //Klasor_Teklif_Belgeleri = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Musteri_Iliskileri + Dizin_Teklif_Belgeleri;
            //Klasor_Servis_Egitim_Formlari = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Servis_Egitim_Formlari;

            //Klasor_PLC_Program = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Yazilim + Dizin_PLC_Program;
            //Klasor_HMI_Program = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Yazilim + Dizin_HMI_Program;
            //Klasor_SCADA_Program = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Yazilim + Dizin_SCADA_Program;
            //Klasor_YARD_Program = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Yazilim + Dizin_Yardimci_Program;
            //Klasor_PC_Program = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Yazilim + Dizin_PC_Program;

            //Klasor_Elektrik_Projesi = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Elektrik_Projesi;

            //Klasor_Malzeme_Listesi = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Dokumanlar + Dizin_Malzeme_Listesi;

            //Klasor_Dokumanlar = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Dokumanlar;
            //Klasor_Cizimler = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Dokumanlar + Dizin_Cizim;
            //Klasor_Diger_Dokumanlar = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Dokumanlar + Dizin_Diger_Dokumanlar;
            //Klasor_FotografVideo = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_Dokumanlar + Dizin_FotografVideo;
            //Klasor_Is_Zaman_Plani = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text + Dizin_IsZaman_Plani; ;
            //Klasor_Tum_Dokumanlar = Anadizin + CB_MusteriFirma.Text + "\\" + CB_Proje.Text;


            #region Variables
            //Grp_Sorgu_PrgHMI = new GroupBox();
            //WB_Sorgu_PrgHMI = new WebBrowser();
            //B_Geri_Sorgu_PrgHMI = new Button();
            //B_Ac_Sorgu_PrgHMI = new Button();
            //B_CopyLink_Sorgu_PrgHMI = new Button();

            //Grp_Sorgu_PrgPLC = new GroupBox();
            //WB_Sorgu_PrgPLC = new WebBrowser();
            //B_Geri_Sorgu_PrgPLC = new Button();
            //B_Ac_Sorgu_PrgPLC = new Button();
            //B_CopyLink_Sorgu_PrgPLC = new Button();

            //Grp_Sorgu_Programlar = new GroupBox();
            //WB_Sorgu_Programlar = new WebBrowser();
            //B_Geri_Sorgu_Programlar = new Button();
            //B_Ac_Sorgu_Programlar = new Button();
            //B_CopyLink_Sorgu_Programlar = new Button();

            //Grp_Sorgu_PrgDiger = new GroupBox();
            //WB_Sorgu_PrgDiger = new WebBrowser();
            //B_Geri_Sorgu_PrgDiger = new Button();
            //B_Ac_Sorgu_PrgDiger = new Button();
            //B_CopyLink_Sorgu_PrgDiger = new Button();

            //Grp_Sorgu_Cizimler = new GroupBox();
            //WB_Sorgu_Cizimler = new WebBrowser();
            //B_Geri_Sorgu_Cizimler = new Button();
            //B_Ac_Sorgu_Cizimler = new Button();
            //B_CopyLink_Sorgu_Cizimler = new Button();

            //Grp_Sorgu_ElektrikPrj = new GroupBox();
            //WB_Sorgu_ElektrikPrj = new WebBrowser();
            //B_Geri_Sorgu_ElektrikPrj = new Button();
            //B_Ac_Sorgu_ElektrikPrj = new Button();
            //B_CopyLink_Sorgu_ElektrikPrj = new Button();

            //Grp_Sorgu_MalzemeListesi = new GroupBox();
            //WB_Sorgu_MalzemeListesi = new WebBrowser();
            //B_Geri_Sorgu_MalzemeListesi = new Button();
            //B_Ac_Sorgu_MalzemeListesi = new Button();
            //B_CopyLink_Sorgu_MalzemeListesi = new Button();

            //Grp_Sorgu_PrgPC = new GroupBox();
            //WB_Sorgu_PrgPC = new WebBrowser();
            //B_Geri_Sorgu_PrgPC = new Button();
            //B_Ac_Sorgu_PrgPC = new Button();
            //B_CopyLink_Sorgu_PrgPC = new Button();

            //Grp_Sorgu_Dokumanlar = new GroupBox();
            //WB_Sorgu_Dokumanlar = new WebBrowser();
            //B_Geri_Sorgu_Dokumanlar = new Button();
            //B_Ac_Sorgu_Dokumanlar = new Button();
            //B_CopyLink_Sorgu_Dokumanlar = new Button();

            //Grp_Sorgu_CihazDokumanlari = new GroupBox();
            //WB_Sorgu_CihazDokumanlari = new WebBrowser();
            //B_Geri_Sorgu_CihazDokumanlari = new Button();
            //B_Ac_Sorgu_CihazDokumanlari = new Button();
            //B_CopyLink_Sorgu_CihazDokumanlari = new Button();


            //Grp_Sorgu_DigerDokumanlar = new GroupBox();
            //WB_Sorgu_DigerDokumanlar = new WebBrowser();
            //B_Geri_Sorgu_DigerDokumanlar = new Button();
            //B_Ac_Sorgu_DigerDokumanlar = new Button();
            //B_CopyLink_Sorgu_DigerDokumanlar = new Button();

            //Grp_Sorgu_Formlar = new GroupBox();
            //WB_Sorgu_Formlar = new WebBrowser();
            //B_Geri_Sorgu_Formlar = new Button();
            //B_Ac_Sorgu_Formlar = new Button();
            //B_CopyLink_Sorgu_Formlar = new Button();

            //Grp_Sorgu_MusteriIliskileri = new GroupBox();
            //WB_Sorgu_MusteriIliskileri = new WebBrowser();
            //B_Geri_Sorgu_MusteriIliskileri = new Button();
            //B_Ac_Sorgu_MusteriIliskileri = new Button();
            //B_CopyLink_Sorgu_MusteriIliskileri = new Button();

            //Grp_Sorgu_IsZamanPlani = new GroupBox();
            //WB_Sorgu_IsZamanPlani = new WebBrowser();
            //B_Geri_Sorgu_IsZamanPlani = new Button();
            //B_Ac_Sorgu_IsZamanPlani = new Button();
            //B_CopyLink_Sorgu_IsZamanPlani = new Button();

            //Grp_Sorgu_FotografVideo = new GroupBox();
            //WB_Sorgu_FotografVideo = new WebBrowser();
            //B_Geri_Sorgu_FotografVideo = new Button();
            //B_Ac_Sorgu_FotografVideo = new Button();
            //B_CopyLink_Sorgu_FotografVideo = new Button();


            #endregion

        }
        public string Sorgulama_On_Kontrol()
        {
            if (CLS.Form_Main.CHB_Sorgu_CihazDokumanlari.Checked        || CLS.Form_Main.CHB_Sorgu_Cizimler.Checked     || CLS.Form_Main.CHB_Sorgu_DigerDokumanlar.Checked  ||
                    CLS.Form_Main.CHB_Sorgu_Dokumanlar.Checked          || CLS.Form_Main.CHB_Sorgu_ElektrikPrj.Checked  || CLS.Form_Main.CHB_Sorgu_Formlar.Checked          ||
                    CLS.Form_Main.CHB_Sorgu_FotografVideo.Checked       || CLS.Form_Main.CHB_Sorgu_PrgHMI.Checked       || CLS.Form_Main.CHB_Sorgu_MalzemeListesi.Checked   ||
                    CLS.Form_Main.CHB_Sorgu_MusteriIliskileri.Checked   || CLS.Form_Main.CHB_Sorgu_PrgPLC.Checked       || CLS.Form_Main.CHB_Sorgu_Programlar.Checked       || 
                    CLS.Form_Main.CHB_Sorgu_PrgPC.Checked               || CLS.Form_Main.CHB_Sorgu_PrgDiger.Checked     || CLS.Form_Main.CHB_Sorgu_IsZamanPlani.Checked)
            {
                CLS.Form_Main.LB_Dosya_NitelikSecilmedi.Visible = false;

                if (Directory.Exists(KlasorYolu_MusteriKlasoru))
                {
                    if (Directory.Exists(KlasorYolu_ProjeKlasoru))
                    {
                        if (Directory.Exists(KlasorYolu_HedefProjeKlasoru))
                        {
                            if (Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D1") && Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D2") &&
                                Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D3") && Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D4") &&
                                Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D5") && Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D6") &&
                                Directory.Exists(KlasorYolu_HedefProjeKlasoru + "\\D7"))
                            {
                                CLS.Form_Main.TB_Sorgu_ProjeYolu.Text = KlasorYolu_HedefProjeKlasoru;
                                return "OK!";
                            }
                            else
                            {
                                if (File.Exists(KlasorYolu_HedefProjeKlasoru + "\\" + RevizyonNo + ".zip") )
                                {
                                    CLS.Form_Main.TB_Sorgu_ProjeYolu.Text = KlasorYolu_HedefProjeKlasoru;
                                    return "Seçilen Revizyon dosyaları arşivlenmiş gözüküyor! Dosya ve klasörleri manuel olarak kontrol edin. \nDosya Yolu:\n" + KlasorYolu_HedefProjeKlasoru; 
                                }
                                else
                                {
                                    CLS.Form_Main.TB_Sorgu_ProjeYolu.Text = KlasorYolu_HedefProjeKlasoru;
                                    return "Seçilen Revizyon dosyaları ya da klasör yapısı değiştirilmiş! Dosya ve klasörleri manuel olarak kontrol edin. \nDosya Yolu:\n" + KlasorYolu_HedefProjeKlasoru;
                                }

                            }

                        }
                        else { return "Projeler dizini içinde seçilen revizyon klasörü bulunamadı."; }
                    }
                    else { return "Projeler dizini içinde seçilen proje klasörü bulunamadı."; }
                }
                else { return "Projeler dizini içinde seçilen müşteri klasörü bulunamadı."; }
            }
            else
            {
                return "Arama Kriteri Seçilmedi. Dosyalar neye göre getirilecek? Lütfen 'Dosya Niteliği' bölümünden bir seçim yapınız.";
            }



         

        }
        public void Sorgulama()
        {
            try
            {
                CLS.Form_Main.FP_SorguCevaplari.Controls.Clear();
                CLS.Form_Main.FP_SorguCevaplari.Update();
                CLS.Form_Main.FP_SorguCevaplari.Refresh();
                GC.Collect();

                CLS.Form_Main.TB_Sorgu_Hata_Bildirimi.Text = "";

                if (Sorgulama_On_Kontrol() == "OK!")
                {
                    CLS.Form_Main.LB_Dosya_NitelikSecilmedi.Visible = false;
                    string[] NesneTextleri = new string[10];
                    bool DolulukKnt_OK = false;
                    try
                    {

                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_PrgPLC.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_PLC))
                            {
                                DosyaBrowser_PLC.XID_LB_Baslik.Text = "Programlar - PLC";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_PLC.XID_LB_Baslik.Text = "Programlar - PLC - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            
                            DosyaBrowser_PLC.Name = "DosyaBrowser_PLC";
                            DosyaBrowser_PLC.BrowserYol = KlasorYolu_PLC;
                            DosyaBrowser_PLC.XID_WBrowser.Url = new Uri(KlasorYolu_PLC);
                            DosyaBrowser_PLC.XID_Picture.Image = Properties.Resources.i103;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_PLC);
                            }

                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_PrgHMI.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_HMI))
                            {
                                DosyaBrowser_HMI.XID_LB_Baslik.Text = "Programlar - HMI";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_HMI.XID_LB_Baslik.Text = "Programlar - HMI - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_HMI.Name = "DosyaBrowser_HMI";
                            DosyaBrowser_HMI.BrowserYol = KlasorYolu_HMI;
                            DosyaBrowser_HMI.XID_WBrowser.Url = new Uri(KlasorYolu_HMI);
                            DosyaBrowser_HMI.XID_Picture.Image = Properties.Resources.i88;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_HMI);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_Programlar.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_Programlar))
                            {
                                DosyaBrowser_Programlar.XID_LB_Baslik.Text = "Programlar";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_Programlar.XID_LB_Baslik.Text = "Programlar - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_Programlar.Name = "DosyaBrowser_Programlar";
                            DosyaBrowser_Programlar.BrowserYol = KlasorYolu_Programlar;
                            DosyaBrowser_Programlar.XID_WBrowser.Url = new Uri(KlasorYolu_Programlar);
                            DosyaBrowser_Programlar.XID_Picture.Image = Properties.Resources.i91;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {

                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_Programlar);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_PrgDiger.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_PrgDiger))
                            {
                                DosyaBrowser_PrgDiger.XID_LB_Baslik.Text = "Diğer Programlar";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_PrgDiger.XID_LB_Baslik.Text = "Diğer Programlar - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_PrgDiger.Name = "DosyaBrowser_PrgDiger";
                            DosyaBrowser_PrgDiger.BrowserYol = KlasorYolu_PrgDiger;
                            DosyaBrowser_PrgDiger.XID_WBrowser.Url = new Uri(KlasorYolu_PrgDiger);
                            DosyaBrowser_PrgDiger.XID_Picture.Image = Properties.Resources.i105;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {

                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_PrgDiger);
                            }

                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_Cizimler.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_Cizimler))
                            {
                                DosyaBrowser_Cizimler.XID_LB_Baslik.Text = "Cizimler";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_Cizimler.XID_LB_Baslik.Text = "Cizimler - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_Cizimler.Name = "DosyaBrowser_Cizimler";
                            DosyaBrowser_Cizimler.BrowserYol = KlasorYolu_Cizimler;
                            DosyaBrowser_Cizimler.XID_WBrowser.Url = new Uri(KlasorYolu_Cizimler);
                            DosyaBrowser_Cizimler.XID_Picture.Image = Properties.Resources.i94;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_Cizimler);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_ElektrikPrj.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_ElektrikProjesi))
                            {
                                DosyaBrowser_ElektrikProjesi.XID_LB_Baslik.Text = "Elektrik Projesi";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_ElektrikProjesi.XID_LB_Baslik.Text = "Elektrik Projesi - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_ElektrikProjesi.Name = "DosyaBrowser_ElektrikProjesi";
                            DosyaBrowser_ElektrikProjesi.BrowserYol = KlasorYolu_ElektrikProjesi;
                            DosyaBrowser_ElektrikProjesi.XID_WBrowser.Url = new Uri(KlasorYolu_ElektrikProjesi);
                            DosyaBrowser_ElektrikProjesi.XID_Picture.Image = Properties.Resources.i92;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_ElektrikProjesi);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_MalzemeListesi.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_MalzemeListesi))
                            {
                                DosyaBrowser_MalzemeListesi.XID_LB_Baslik.Text = "Malzeme Listesi";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_MalzemeListesi.XID_LB_Baslik.Text = "Malzeme Listesi - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_MalzemeListesi.Name = "DosyaBrowser_MalzemeListesi";
                            DosyaBrowser_MalzemeListesi.BrowserYol = KlasorYolu_MalzemeListesi;
                            DosyaBrowser_MalzemeListesi.XID_WBrowser.Url = new Uri(KlasorYolu_MalzemeListesi);
                            DosyaBrowser_MalzemeListesi.XID_Picture.Image = Properties.Resources.i101;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_MalzemeListesi);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_PrgPC.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_PC))
                            {
                                DosyaBrowser_PC.XID_LB_Baslik.Text = "Programlar - PC";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_PC.XID_LB_Baslik.Text = "Programlar - PC - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_PC.Name = "DosyaBrowser_PC";
                            DosyaBrowser_PC.BrowserYol = KlasorYolu_PC;
                            DosyaBrowser_PC.XID_WBrowser.Url = new Uri(KlasorYolu_PC);
                            DosyaBrowser_PC.XID_Picture.Image = Properties.Resources.i90;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_PC);
                            }

                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_Dokumanlar.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_Dokumanlar))
                            {
                                DosyaBrowser_Dokumanlar.XID_LB_Baslik.Text = "Dökümanlar";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_Dokumanlar.XID_LB_Baslik.Text = "Dökümanlar - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_Dokumanlar.Name = "DosyaBrowser_Dokumanlar";
                            DosyaBrowser_Dokumanlar.BrowserYol = KlasorYolu_Dokumanlar;
                            DosyaBrowser_Dokumanlar.XID_WBrowser.Url = new Uri(KlasorYolu_Dokumanlar);
                            DosyaBrowser_Dokumanlar.XID_Picture.Image = Properties.Resources.i142;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                        {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_Dokumanlar);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_CihazDokumanlari.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_Cihazlar))
                            {
                                DosyaBrowser_Cihazlar.XID_LB_Baslik.Text = "Cihaz Dökümanları";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_Cihazlar.XID_LB_Baslik.Text = "Cihaz Dökümanları - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_Cihazlar.Name = "DosyaBrowser_Cihazlar";
                            DosyaBrowser_Cihazlar.BrowserYol = KlasorYolu_Cihazlar;
                            DosyaBrowser_Cihazlar.XID_WBrowser.Url = new Uri(KlasorYolu_Cihazlar);
                            DosyaBrowser_Cihazlar.XID_Picture.Image = Properties.Resources.i127;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                        {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_Cihazlar);
                            }
                        }
                        
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_DigerDokumanlar.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_DigerDokumanlar))
                            {
                                DosyaBrowser_DigerDokumanlar.XID_LB_Baslik.Text = "Diğer Dökümanlar";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_DigerDokumanlar.XID_LB_Baslik.Text = "Diğer Dökümanlar - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_DigerDokumanlar.Name = "DosyaBrowser_DigerDokumanlar";
                            DosyaBrowser_DigerDokumanlar.BrowserYol = KlasorYolu_DigerDokumanlar;
                            DosyaBrowser_DigerDokumanlar.XID_WBrowser.Url = new Uri(KlasorYolu_DigerDokumanlar);
                            DosyaBrowser_DigerDokumanlar.XID_Picture.Image = Properties.Resources.i150;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_DigerDokumanlar);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_Formlar.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_Formlar))
                            {
                                DosyaBrowser_Formlar.XID_LB_Baslik.Text = "Formlar";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_Formlar.XID_LB_Baslik.Text = "Formlar - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_Formlar.Name = "DosyaBrowser_Formlar";
                            DosyaBrowser_Formlar.BrowserYol = KlasorYolu_Formlar;
                            DosyaBrowser_Formlar.XID_WBrowser.Url = new Uri(KlasorYolu_Formlar);
                            DosyaBrowser_Formlar.XID_Picture.Image = Properties.Resources.i149;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_Formlar);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_MusteriIliskileri.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_MusteriIliskileri))
                            {
                                DosyaBrowser_MusteriIliskileri.XID_LB_Baslik.Text = "Müşteri İlişkileri";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_MusteriIliskileri.XID_LB_Baslik.Text = "Müşteri İlişkileri - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_MusteriIliskileri.Name = "DosyaBrowser_MusteriIliskileri";
                            DosyaBrowser_MusteriIliskileri.BrowserYol = KlasorYolu_MusteriIliskileri;
                            DosyaBrowser_MusteriIliskileri.XID_WBrowser.Url = new Uri(KlasorYolu_MusteriIliskileri);
                            DosyaBrowser_MusteriIliskileri.XID_Picture.Image = Properties.Resources.i116;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_MusteriIliskileri);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_IsZamanPlani.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_IsZamanPlani))
                            {
                                DosyaBrowser_IsZamanPlani.XID_LB_Baslik.Text = "İş Zaman Planı";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_IsZamanPlani.XID_LB_Baslik.Text = "İş Zaman Planı - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_IsZamanPlani.Name = "DosyaBrowser_IsZamanPlani";
                            DosyaBrowser_IsZamanPlani.BrowserYol = KlasorYolu_IsZamanPlani;
                            DosyaBrowser_IsZamanPlani.XID_WBrowser.Url = new Uri(KlasorYolu_IsZamanPlani);
                            DosyaBrowser_IsZamanPlani.XID_Picture.Image = Properties.Resources.i112;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_IsZamanPlani);
                            }
                        }
                        ////=================================================================
                        ////=================================================================
                        if (CLS.Form_Main.CHB_Sorgu_FotografVideo.Checked)
                        {
                            if (KlasorDoluBosKontrol(KlasorYolu_FotografVideo))
                            {
                                DosyaBrowser_FotografVideo.XID_LB_Baslik.Text = "Fotoğraf Video";
                                DolulukKnt_OK = true;
                            }
                            else
                            {
                                DosyaBrowser_FotografVideo.XID_LB_Baslik.Text = "Fotoğraf Video - Dosya Yok!";
                                DolulukKnt_OK = false;
                            }

                            DosyaBrowser_FotografVideo.Name = "DosyaBrowser_FotografVideo";
                            DosyaBrowser_FotografVideo.BrowserYol = KlasorYolu_FotografVideo;
                            DosyaBrowser_FotografVideo.XID_WBrowser.Url = new Uri(KlasorYolu_FotografVideo);
                            DosyaBrowser_FotografVideo.XID_Picture.Image = Properties.Resources.i96;

                            if (!CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked || (DolulukKnt_OK && CLS.Form_Main.CHB_Sorgu_SadeceDoluGetir.Checked))
                            {
                                CLS.Form_Main.FP_SorguCevaplari.Controls.Add(DosyaBrowser_FotografVideo);
                            }
   
                        }



                        CLS.ProjeSorgulamaGecmisi.ProjeGecmisKaydet();
                        CLS.ProjeSorgulamaGecmisi.ProjeGecmisGoster();
                    }
                    catch
                    {
                        CLS.Form_Main.TB_Sorgu_Hata_Bildirimi.ForeColor = Color.Red;
                        CLS.Form_Main.TB_Sorgu_Hata_Bildirimi.Text = " Hay Aksi! Arama yapılan dizinde bir problem var gibi gözüküyor. Kontrol edilmesi gerekir." +
                            "Bir klasör silinmiş, taşınmış olabilir ya da bir klasör adı standart dışı.";
                    }


                }
                else
                {
                    CLS.Form_Main.LB_Dosya_NitelikSecilmedi.Visible = true;
                    CLS.Form_Main.TB_Sorgu_Hata_Bildirimi.ForeColor = Color.Red;
                    CLS.Form_Main.TB_Sorgu_Hata_Bildirimi.Text = Sorgulama_On_Kontrol();
                }
            }
            catch (Exception HATA)
            {

                CLS.Log.ERR_LOGS(HATA.ToString());
            }

        }
        public void SecimliSorgulama()
        {
            AdresTanimlamalari(CLS.Form_Main.CHB_Sorgu_ProjeKoduGir.Checked); // Proje kodu ile giriş cb seçili ise adres tanımlarını değiştir.
            Sorgulama();
        }
        public void ProjeKoduIleSorgula(string PrjKod, string RevKod)
        {
            string ProjeKODU        = "P" + PrjKod;
            string MusteriNo        = PrjKod.Substring(0, 4);
            string MusteriBolumNo   = PrjKod.Substring(4, 2);
            string ProjeDonemYili   = PrjKod.Substring(6, 2);
            string ProjeNo          = PrjKod.Substring(8, 3);
            string RevNo            = RevKod;

            string cmdDurum = "";

            ComboBox CB_PrjKodListesi = new ComboBox();
            ComboBox CB_BolumListesi = new ComboBox();
            ComboBox CB_MusteriListesi = new ComboBox();

            int sw = 0;

            switch (sw)
            {
                case 0:
                    cmdDurum = Listele_ProjeKodu(CB_PrjKodListesi, MusteriNo, MusteriBolumNo);
                    CB_PrjKodListesi.SelectedIndex = CB_PrjKodListesi.FindString(ProjeKODU);
                    if (CB_PrjKodListesi.FindString(ProjeKODU) >= 0)
                    {
                        goto case 1;
                    }else
                    {
                        goto case 49;
                    }
               
                case 1:
                    if (cmdDurum == "OK!")
                    {
                        int selectedIndex = CB_PrjKodListesi.SelectedIndex;
                        string selectedValue = (CB_PrjKodListesi.SelectedItem as dynamic).Value.ToString();

                        ProjeKoduSecildi(selectedValue, out string PrjNo, out string PrjAdi, out string PrjBasTarih, out string PrjDonem, out string PrjNot, out string INFO);

                        CLS.Form_Main.CB_Sorgu_ProjeAdi.Items.Clear();

                        ComboboxItem item = new ComboboxItem();
                        item.Text = PrjAdi;
                        item.Value = selectedValue;
                        CLS.Form_Main.CB_Sorgu_ProjeAdi.Items.Add(item);
                        CLS.Form_Main.CB_Sorgu_ProjeAdi.SelectedIndex = 0;
                        CLS.Form_Main.TB_Sorgu_ProjeKodu.Text = ProjeKODU;
                    }

                    goto case 2;
                case 2:
                    cmdDurum = Listele_Revizyonlar(CLS.Form_Main.CB_Sorgu_RevAdi, CLS.Form_Main.CB_Sorgu_RevNo, ProjeKODU);
                    CLS.Form_Main.CB_Sorgu_RevNo.SelectedItem = RevNo;

                    CLS.Form_Main.CB_Sorgu_RevNo.SelectedIndex  = CLS.Form_Main.CB_Sorgu_RevNo.FindString(RevNo);
                    CLS.Form_Main.CB_Sorgu_RevAdi.SelectedIndex = CLS.Form_Main.CB_Sorgu_RevNo.SelectedIndex;

                    if (CLS.Form_Main.CB_Sorgu_RevNo.FindString(RevNo) >= 0)
                    {
                        goto case 3;
                    }
                    else
                    {
                        goto case 48;
                    }

                    //goto case 3;
                case 3:
                    if (cmdDurum == "OK!")
                    {
                        cmdDurum = Listele_BolumNo(CB_BolumListesi, MusteriNo);
                        CB_BolumListesi.SelectedIndex = CB_BolumListesi.FindString(MusteriBolumNo);

                        int selectedIndex = CB_BolumListesi.SelectedIndex;
                        string selectedValue = (CB_BolumListesi.SelectedItem as dynamic).Value.ToString();

                        BolumNoSecildi(int.Parse(selectedValue), MusteriNo, MusteriBolumNo, out string BolumAd, out string BolumNot);

                        CLS.Form_Main.CB_Sorgu_BolumAdi.Items.Clear();
                        ComboboxItem item = new ComboboxItem();
                        item.Text = BolumAd;
                        item.Value = selectedValue;
                        CLS.Form_Main.CB_Sorgu_BolumAdi.Items.Add(item);
                        CLS.Form_Main.CB_Sorgu_BolumAdi.SelectedIndex = 0;

                        CLS.Form_Main.TB_Sorgu_BolumNo.Text = MusteriBolumNo;
                    }
                    goto case 4;
                case 4:
                    if (cmdDurum == "OK!")
                    {
                        cmdDurum = Listele_MusteriNo(CB_MusteriListesi);
                        CB_MusteriListesi.SelectedIndex = CB_MusteriListesi.FindString(MusteriNo);

                        int selectedIndex = CB_MusteriListesi.SelectedIndex;
                        string selectedValue = (CB_MusteriListesi.SelectedItem as dynamic).Value.ToString();

                        MusteriNoSecildi(int.Parse(selectedValue), out string MusteriAdi, out string MBolge, out string Madres, out string Maps, out string MTel, out string not, out string INFO);

                        CLS.Form_Main.CB_Sorgu_MusteriAdi.Items.Clear();

                        CLS.Form_Main.CB_Sorgu_MusteriAdi.Items.Add(MusteriAdi);
                        ComboboxItem item = new ComboboxItem();
                        item.Text = MusteriAdi;
                        item.Value = selectedValue;
                        CLS.Form_Main.CB_Sorgu_MusteriAdi.Items.Add(item);
                        CLS.Form_Main.CB_Sorgu_MusteriAdi.SelectedIndex = 0;

                        CLS.Form_Main.TB_Sorgu_MusteriNo.Text = MusteriNo;
                    }
                    goto case 5;
                case 5:

                    goto case 6;
                case 6:

                    goto case 7;
                case 7:

                    goto case 8;
                case 8:

                    goto case 9;
                case 9:

                    goto case 10;

                  
                case 10:


                    goto case 50;
                case 48:
                    MessageBox.Show("Girmiş olduğunuz revizyon numarası veritabanında herhangi bir kayıt ile eşleşmedi. Lütfen girdğiniz revizyon numaarasını tekrar kontrol edin.",
                                   "Parkon - Proje kodu ile sorgulama hatası!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CLS.Form_Main.TB_Sorgu_RevKoduGiris.BackColor = Color.Red;
                    goto case 50;
                case 49:
                    MessageBox.Show("Girmiş olduğunuz proje numarası veritabanında herhangi bir kayıt ile eşleşmedi. Lütfen girdğiniz proje kodunu tekrar kontrol edin.", 
                                    "Parkon - Proje kodu ile sorgulama hatası!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CLS.Form_Main.TB_Sorgu_ProjeKoduGiris.BackColor = Color.Red;
                    goto case 50;
                case 50:

                    break;
            }





          

            //Müşteri Seçimi
            //CLS.ProjeSorgulama.Listele_MusteriAdi(CLS.Form_Main.CB_Sorgu_MusteriAdi);

            //CLS.ProjeSorgulama.MusteriAdiSecildi(CLS.Form_Main.CB_Sorgu_MusteriAdi.SelectedIndex, out string MNo, out string MBolge, out string MAdres, out string Maps, out string MTel, out string Mnot, out string Info);
            //CLS.Form_Main.TTip_Info.SetToolTip(CLS.Form_Main.CB_Sorgu_MusteriAdi, "Musteri No: " + MNo + " \n" + "Müşteri Bölgesi: " + MBolge + " \n" + "Adres: " + MAdres + " \n" + "Telefon: " + MTel);
            //CLS.Form_Main.TB_Sorgu_MusteriNo.Text = MNo;


            //Bölüm Listele
          //  CLS.ProjeSorgulama.Listele_BolumAdi(CLS.Form_Main.CB_Sorgu_BolumAdi, CLS.Form_Main.TB_Sorgu_MusteriNo.Text);

            AdresTanimlamalari(CLS.Form_Main.CHB_Sorgu_ProjeKoduGir.Checked); // Proje kodu ile giriş cb seçili ise adres tanımlarını değiştir.
            Sorgulama();

        }
        #endregion

        public void LocalDataUpdate()
        {
            try
            {
                if (CLS.Form_Main.LB_Gosterge_Internet.BackColor == Color.Lime)
                {
                    try
                    {
                        CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteri, CLS.Form_Main.DGVMusteri);
                        CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBMusteriBolum, CLS.Form_Main.DGVMusteriBolum);
                        CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBProje, CLS.Form_Main.DGVProje);
                        CLS.ID_MySQL.READ_FillDGV(CLS.MySQLVar.TableName_DBRev, CLS.Form_Main.DGVRev);

                        string a = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGVMusteri, CLS.SavePath_DBM, false);
                        string b = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGVMusteriBolum, CLS.SavePath_DBMB, false);
                        string c = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGVProje, CLS.SavePath_DBP, false);
                        string d = CLS.EXL.WRITE_DGVToExcelSave(CLS.Form_Main.DGVRev, CLS.SavePath_DBR, false);

                        CLS.PrgSettings.KAYDET_DBGuncellemeSonTarih();
                        CLS.PrgSettings.YUKLE_DBGuncellemeSonTarih();

                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    Fill_DGV_FromLocalDB();
                }

            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
        }
        public void Fill_DGV_FromLocalDB()
        {
            try
            {
                string a = CLS.EXL.READ_ExcelFile(CLS.Form_Main.DGVMusteri, CLS.SavePath_DBM, true, CLS.Form_Main.CB_Page_DBMusteri);
                CLS.Form_Main.DGVMusteri.Columns.RemoveAt(0);
                string b = CLS.EXL.READ_ExcelFile(CLS.Form_Main.DGVMusteriBolum, CLS.SavePath_DBMB, true, CLS.Form_Main.CB_Page_DBMusteriBolum);
                CLS.Form_Main.DGVMusteriBolum.Columns.RemoveAt(0);
                string c = CLS.EXL.READ_ExcelFile(CLS.Form_Main.DGVProje, CLS.SavePath_DBP, true, CLS.Form_Main.CB_Page_DBProje);
                CLS.Form_Main.DGVProje.Columns.RemoveAt(0);
                string d = CLS.EXL.READ_ExcelFile(CLS.Form_Main.DGVRev, CLS.SavePath_DBR, true, CLS.Form_Main.CB_Page_DBRev);
                CLS.Form_Main.DGVRev.Columns.RemoveAt(0);
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }

        }
        public void KlasorNitelik_Temizle()
        {
            CLS.Form_Main.CHB_Sorgu_CihazDokumanlari.Checked        = false;
            CLS.Form_Main.CHB_Sorgu_Cizimler.Checked                = false;
            CLS.Form_Main.CHB_Sorgu_DigerDokumanlar.Checked         = false;
            CLS.Form_Main.CHB_Sorgu_Dokumanlar.Checked              = false;
            CLS.Form_Main.CHB_Sorgu_ElektrikPrj.Checked             = false;
            CLS.Form_Main.CHB_Sorgu_Formlar.Checked                 = false;
            CLS.Form_Main.CHB_Sorgu_FotografVideo.Checked           = false;
            CLS.Form_Main.CHB_Sorgu_PrgHMI.Checked                  = false;
            CLS.Form_Main.CHB_Sorgu_MalzemeListesi.Checked          = false;
            CLS.Form_Main.CHB_Sorgu_MusteriIliskileri.Checked       = false;
            CLS.Form_Main.CHB_Sorgu_PrgPLC.Checked                  = false;
            CLS.Form_Main.CHB_Sorgu_Programlar.Checked              = false;
            CLS.Form_Main.CHB_Sorgu_PrgPC.Checked                   = false;
            CLS.Form_Main.CHB_Sorgu_IsZamanPlani.Checked            = false;
            CLS.Form_Main.CHB_Sorgu_PrgDiger.Checked                = false;
        }
        public void KlasorNitelik_HepsiniSec()
        {
            CLS.Form_Main.CHB_Sorgu_CihazDokumanlari.Checked        = true;
            CLS.Form_Main.CHB_Sorgu_Cizimler.Checked                = true;
            CLS.Form_Main.CHB_Sorgu_DigerDokumanlar.Checked         = true;
            CLS.Form_Main.CHB_Sorgu_Dokumanlar.Checked              = true;
            CLS.Form_Main.CHB_Sorgu_ElektrikPrj.Checked             = true;
            CLS.Form_Main.CHB_Sorgu_Formlar.Checked                 = true;
            CLS.Form_Main.CHB_Sorgu_FotografVideo.Checked           = true;
            CLS.Form_Main.CHB_Sorgu_PrgHMI.Checked                  = true;
            CLS.Form_Main.CHB_Sorgu_MalzemeListesi.Checked          = true;
            CLS.Form_Main.CHB_Sorgu_MusteriIliskileri.Checked       = true;
            CLS.Form_Main.CHB_Sorgu_PrgPLC.Checked                  = true;
            CLS.Form_Main.CHB_Sorgu_Programlar.Checked              = true;
            CLS.Form_Main.CHB_Sorgu_PrgPC.Checked                   = true;
            CLS.Form_Main.CHB_Sorgu_IsZamanPlani.Checked            = true;
            CLS.Form_Main.CHB_Sorgu_PrgDiger.Checked                = true;
        }




    }
}
