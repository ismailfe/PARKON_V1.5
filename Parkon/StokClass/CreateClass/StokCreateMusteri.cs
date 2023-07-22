﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkon
{
    public class StokCreateMusteri
    {
        public CLS CLS;

        public string MusteriNoSorgula(out string SiradakiNo)
        {
            SiradakiNo = "";
            try
            {
                string[] refColumnName = new string[0];
                string[] refValue = new string[0];
                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBStokMusteri, "MusteriNo", false, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    SiradakiNo = "000" + LastNumber;
                }
                else if (LastNumber.Length == 2)
                {
                    SiradakiNo = "00" + LastNumber;
                }
                else if (LastNumber.Length == 3)
                {
                    SiradakiNo = "0" + LastNumber;
                }
                else if (LastNumber.Length == 4)
                {
                    SiradakiNo = "" + LastNumber;
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }
        public string YeniMusteriOlustur(string MusteriNot, string MusteriAdi, string MusteriBolge, string MusteriAdres, string MusteriMapLink, string MusteriTel)
        {
            try
            {
                string[] WriteData = new string[10];

                MusteriNoSorgula(out string MusteriNo);

                WriteData[0] = ""; //PrimaryKey
                WriteData[1] = DateTime.Now.ToString();
                WriteData[2] = CLS.Form_Main.LB_UserName.Text;
                WriteData[3] = MusteriNot;
                WriteData[4] = MusteriNo;
                WriteData[5] = MusteriAdi;
                WriteData[6] = MusteriBolge;
                WriteData[7] = MusteriAdres;
                WriteData[8] = MusteriMapLink;
                WriteData[9] = MusteriTel;

                CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokMusteri, CLS.MySQLVar.ColumnName_DBStokMusteri, WriteData, 0);

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        public string MusteriBolumNoSorgula(string MusteriNo, out string SiradakiMusteriBolumNo)
        {
            SiradakiMusteriBolumNo = "";
            try
            {
                string[] refColumnName = new string[1];
                string[] refValue = new string[1];

                refColumnName[0] = "MusteriNo";
                refValue[0] = MusteriNo.Trim();

                CLS.ID_MySQL.FindLastNumber(CLS.MySQLVar.TableName_DBStokMusteriBolum, "BolumNo", true, refColumnName, refValue, out string LastNumber);

                if (LastNumber.Length < 2)
                {
                    SiradakiMusteriBolumNo = "0" + LastNumber;
                }
                else
                {
                    SiradakiMusteriBolumNo = LastNumber;
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

        public string YeniMusteriBolumOlustur(string BolumNot, string MusteriNo, string MusteriAdi, string BolumNo, string BolumAdi)
        {
            try
            {
                string KullanilacakBolumNo = "";
                string[] WriteData = new string[8];

                string[] refColumnName = new string[1];
                string[] refValue = new string[1];

                MusteriBolumNoSorgula(MusteriNo, out KullanilacakBolumNo);


                WriteData[0] = ""; //PrimaryKey
                WriteData[1] = DateTime.Now.ToString();
                WriteData[2] = CLS.Form_Main.LB_UserName.Text;
                WriteData[3] = BolumNot;
                WriteData[4] = MusteriNo;
                WriteData[5] = MusteriAdi;
                WriteData[6] = KullanilacakBolumNo;
                WriteData[7] = BolumAdi;


                CLS.ID_MySQL.WRITE_ToSQLRow(CLS.MySQLVar.TableName_DBStokMusteriBolum, CLS.MySQLVar.ColumnName_DBStokMusteriBolum, WriteData, 0);

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
