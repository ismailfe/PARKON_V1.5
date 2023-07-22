using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkon
{
    public class StokCreateMarka
    {
        public CLS CLS;


        public string MarkaNoSorgula(out string SiradakiNo)
        {
            SiradakiNo = "";
            try
            {
                string No = "";
                string[] WriteData = new string[10];

                string[] refColumnName = new string[0];
                string[] refValue = new string[0];

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBStokMarka, "MarkaNo", false, refColumnName, refValue, out string LastNumber);

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


        public string YeniMarka(string MarkaNot, string MarkaAdi)
        {
            try
            {   //ColumnName_DBStokMarka[0] = "ID";
                //ColumnName_DBStokMarka[1] = "KayitTarih";
                //ColumnName_DBStokMarka[2] = "KayitUser";
                //ColumnName_DBStokMarka[3] = "Notlar";
                //ColumnName_DBStokMarka[4] = "MarkaKod";
                //ColumnName_DBStokMarka[5] = "MarkaAd";
                //ColumnName_DBStokMarka[6] = "MarkaBarkod";
                //ColumnName_DBStokMarka[7] = "UrunKodFirstChar";
                //ColumnName_DBStokMarka[8] = "UrunKodEndChar";
                //ColumnName_DBStokMarka[9] = "UrunIDFirstChar";
                //ColumnName_DBStokMarka[10] = "UrunIDEndChar";

                MarkaNoSorgula(out string MarkaNo);

                string[] WriteData  = new string[11];
                WriteData[0]        = ""; //PrimaryKey
                WriteData[1]        = DateTime.Now.ToString();
                WriteData[2]        = CLS.Form_Main.LB_UserName.Text;
                WriteData[3]        = MarkaNot;
                WriteData[4]        = MarkaNo;
                WriteData[5]        = MarkaAdi;

                CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokMarka, CLS.MySQLVar.ColumnName_DBStokMarka, WriteData, 0);

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
