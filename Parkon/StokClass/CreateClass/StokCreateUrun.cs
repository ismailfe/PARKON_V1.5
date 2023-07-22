using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkon
{
    public class StokCreateUrun
    {
        public CLS CLS;

        public string UrunNoSorgula(string MarkaAd, out string SiradakiNo)
        {
            SiradakiNo = "";
            try
            {
                string No = "";
                string[] WriteData = new string[10];

                string[] refColumnName; 
                string[] refValue;
                if (MarkaAd != "")
                {
                  refColumnName = new string[1];
                  refValue      = new string[1];

                    refColumnName[0]        = "MarkaAd";
                    refValue[0]             = MarkaAd;
                }
                else
                {
                    refColumnName           = new string[0];
                    refValue                = new string[0];
                }

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBStokUrun, "UrunNo", true, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    No = "000" + LastNumber;
                }
                else if (LastNumber.Length == 2)
                {
                    No = "00" + LastNumber;
                }
                else if (LastNumber.Length == 3)
                {
                    No = "0" + LastNumber;
                }
                else if (LastNumber.Length == 4)
                {
                    No = "" + LastNumber;
                }

                SiradakiNo = No;
                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string YeniUrun(string UrunNot, string MarkaNo, string MarkaAdi, string Barkod, string UrunKodFirstChar, string UrunKodEndChar, string UrunIDFirstChar, string UrunIDEndChar, string UrunKod, string UrunAdi, string UrunInfo, string UrunID, string UrunFiyat, string UrunFiyatBirim, string UrunIskonto)
        {
            try
            {
                UrunNoSorgula(MarkaAdi, out string UrunNo);

                string[] WriteData  = new string[19];
                WriteData[0]        = ""; //PrimaryKey
                WriteData[1]        = DateTime.Now.ToString();
                WriteData[2]        = CLS.Form_Main.LB_UserName.Text;
                WriteData[3]        = UrunNot;
                WriteData[4]        = MarkaNo;
                WriteData[5]        = MarkaAdi;
                WriteData[6]        = Barkod;
                WriteData[7]        = UrunKodFirstChar;
                WriteData[8]        = UrunKodEndChar;
                WriteData[9]        = UrunIDFirstChar;
                WriteData[10]       = UrunIDEndChar;
                WriteData[11]       = UrunNo;   // OTO HESAP
                WriteData[12]       = UrunKod;
                WriteData[13]       = UrunAdi;
                WriteData[14]       = UrunInfo;
                WriteData[15]       = UrunID;
                WriteData[16]       = UrunFiyat;
                WriteData[17]       = UrunFiyatBirim;
                WriteData[18]       = UrunIskonto;

                string Status = CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokUrun, CLS.MySQLVar.ColumnName_DBStokUrun, WriteData, 0);

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string Listele_MarkaAdi(ComboBox Liste)
        {
            try
            {
                Liste.Items.Clear();
                ComboboxItem item;

                ListBox LBox = new ListBox();
                ListBox LBox_BolumID = new ListBox();

                CLS.ID_MySQL.READ_SelectColumn(CLS.MySQLVar.TableName_DBStokMarka, "MarkaAd", null, LBox);
                CLS.ID_MySQL.READ_SelectColumn(CLS.MySQLVar.TableName_DBStokMarka, "ID", null, LBox_BolumID);

                for (int i = 0; i < LBox.Items.Count; i++)
                {
                    item = new ComboboxItem();
                    item.Text = LBox.Items[i].ToString();
                    item.Value = LBox_BolumID.Items[i].ToString();
                    Liste.Items.Add(item);
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string MarkaAdiSecildi(int Index, out string MarkaNo)
        {
            MarkaNo = "";

            try
            {
                string[] RData = new string[11];
                if (Index >= 0)
                {
                    CLS.ID_MySQL.READ_SelectID(CLS.MySQLVar.TableName_DBStokMarka, CLS.MySQLVar.ColumnName_DBStokMarka, RData, "ID", Index.ToString());
                }

                MarkaNo = RData[4];


                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }




    }
}
