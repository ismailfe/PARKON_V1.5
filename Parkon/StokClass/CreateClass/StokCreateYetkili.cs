using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkon
{
    public class StokCreateYetkili
    {
        public CLS CLS;

        public string YetkikiNoSorgula(string MusteriNo, out string SiradakiYetkiliNo)
        {
            SiradakiYetkiliNo = "";
            try
            {
                string[] refColumnName = new string[1];
                string[] refValue = new string[1];

                refColumnName[0] = "MusteriNo";
                refValue[0] = MusteriNo.Trim();

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBStokMYetkili, "MYetkiliNo", true, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    SiradakiYetkiliNo = "0" + LastNumber;
                }
                //else if (LastNumber.Length == 2)
                //{
                //    SiradakiMusteriBolumNo = "00" + LastNumber;
                //}
                //else if (LastNumber.Length == 3
                //{
                //    SiradakiMusteriBolumNo = "0" + LastNumber;
                //}
                //else if (LastNumber.Length == 4)
                //{
                //    SiradakiMusteriBolumNo = "" + LastNumber;
                //}

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string YeniYetkiliOlustur(string Not, string MusteriNo, string MusteriAdi, string YetkiliAd, string YetkiliUnvan, string YetkiliTel1, string YetkiliTel2, string YetkiliMail, string YetkiliInfo)
        {
            try
            {
                string KullanilacakYetkiliNo = "";
                string[] WriteData = new string[13];

                YetkikiNoSorgula(MusteriNo, out KullanilacakYetkiliNo);


                WriteData[0] = ""; //PrimaryKey
                WriteData[1] = DateTime.Now.ToString();
                WriteData[2] = CLS.Form_Main.LB_UserName.Text;
                WriteData[3] = Not;
                WriteData[4] = MusteriNo;
                WriteData[5] = MusteriAdi;
                WriteData[6] = KullanilacakYetkiliNo;
                WriteData[7] = YetkiliAd;
                WriteData[8] = YetkiliUnvan;
                WriteData[9] = YetkiliTel1;
                WriteData[10] = YetkiliTel2;
                WriteData[11] = YetkiliMail;
                WriteData[12] = YetkiliInfo;


                string cmd = CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokMYetkili, CLS.MySQLVar.ColumnName_DBStokMYetkili, WriteData, 0);

                return "OK! - " + cmd;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }


    }
}
