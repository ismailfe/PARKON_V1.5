using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;
using System.Drawing;

namespace Parkon
{
    public class ID_MySQL
    {
        public CLS CLS;
    
        MySqlConnection Connection;
        MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder();
        string Baglan;
        public string UserID = "";
        public string Password = "";
        public string Database = "Parkon";
        public string Server = "";
        public uint Port = 3306;             //Default Value:3306

        public string ConnectionStatus = "";

        #region VERSION READ
        /// <summary>
        /// Kullanılan DLL Versiyonu okumak için kullanılır.
        /// </summary>
        /// <returns>
        /// Version
        /// </returns>
        public string VersiyonRead()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo Version = FileVersionInfo.GetVersionInfo(assembly.Location);
            return Version.FileVersion;
        }
        #endregion

        #region CONNECT - DISCONNECT

        /// <summary>
        /// MYSQL Server bağlantı fonksiyonu
        /// 
        /// </summary>
        /// <returns>
        /// OK! - Open = Bağlantı sağlandı.
        /// ERR! - Hata Acilmalasi= Bağlantı kurulurken hata oluştu.
        /// </returns>
        public string Connect()
        {
            try
            {
                //if ("Open" != Connection.State.ToString())
                //{
                    build.UserID = UserID;    
                    build.Password = Password;  
                    build.Database = Database;  
                    build.Server = Server;    
                    build.Port = Port;     

                    Baglan = build.ToString();
                    Connection = new MySqlConnection(Baglan);

                    Connection.Open();
                ConnectionStatus = Connection.State.ToString();
                //}

         //       CLS.Form_Main.toolStrip_ServerConn.BackColor = Color.Lime;
                return "OK! - " + ConnectionStatus;
            }
            catch (Exception HATA)
            {
        //        CLS.Form_Main.toolStrip_ServerConn.BackColor = Color.Red;
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        /// <summary>
        /// MYSQL Server bağlantı kesme fonksiyonu
        /// 
        /// </summary>
        /// <returns>
        /// OK! - Closed = Bağlantı sağlıklı bir şekilde kesildi.
        /// ERR! - Hata Acilmalasi= Bağlantı kesilirken hata oluştu.
        /// </returns>
        public string Disconnect()
        {
            string Status = "";
            try
            {
                if ("Open" == Connection.State.ToString())
                {
                    Connection.Close();
                    Status = Connection.State.ToString();
                }

                return "OK! - " + Status;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }

        }

        private MySqlConnection Con()
        {

            //if ("Open" != Connection.State.ToString())
            //{
            build.UserID = UserID;    
            build.Password = Password;  
            build.Database = Database;  
            build.Server = Server;    
            build.Port = Port;     

            Baglan = build.ToString();
            Connection = new MySqlConnection(Baglan);

            if (Connection.State != ConnectionState.Open)
            {
                 Connection.Open();
            }

            ConnectionStatus = Connection.State.ToString();
            //     }

            return Connection;

        }
        #endregion


        #region READ : Single Row From MySQL         - DB Belirtilen Sütun miktarı kadar ilk satırı oku
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Tablonun ilk saıtırındaki verileri okur.
        /// TableColumn adetine göre veri okur. 
        /// Read Data ile TableColumn aynı index adetine sahip olmalıdır.
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="TableColumn">Tablo sütunlarını içeren string array</param>
        /// <param name="ReadData">Okunan verinin yazıldığı string array</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_FirstSingleRow(string TableName, string[] TableColumn, string[] ReadData)
        {
            // Tek Satırlık veri içeren tablonun verilerini okur.
            // Kaç sütun veri alınmak isteniyorsa 'ColumnCount' bölümüne yazılır.
            try
            {
                MySqlCommand DBCommand = new MySqlCommand("Select * From " + TableName, Con());
                MySqlDataReader DBRead = DBCommand.ExecuteReader();

                while (DBRead.Read())
                {
                    for (int i = 0; i < TableColumn.LongLength; i++)
                    {
                        ReadData[i] = DBRead[TableColumn[i]].ToString();
                    }
                }
                DBRead.Close();
                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }


        }
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region READ : En Büyük Değere göre sırala ve ilk satırı oku          - DB Belirtilen Sütun miktarı kadar ilk satırı oku
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Belirtilen Sütuna göre büyükten küçüğe doğru sıralama yapar
        /// Sıralamadaki ilk satırı okur ReadData içine yazar.
        /// ReadData ile TableColumn aynı index adetine sahip olmalıdır.
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="TableColumn">Tablo sütunlarını içeren string array</param>
        /// <param name="ReadData">Okunan verinin yazıldığı string array</param>
        /// <param name="SiralananColumn">Sıralama yapılacak olan sütun adı</param>
        /// <param name="siralamaYonu">0: Önce Büyük, 1:Önce Küçük</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_FirstRow_OrderBy(string TableName, string[] TableColumn, string[] ReadData, string SiralananColumn, int siralamaYonu)
        {
            // Tek Satırlık veri içeren tablonun verilerini okur.
            // Kaç sütun veri alınmak isteniyorsa 'ColumnCount' bölümüne yazılır.
            try
            {
                string Str_Cmd = "";
                if (siralamaYonu == 0) // Önce Büyük
                {
                    Str_Cmd = " SELECT* FROM " + TableName + " ORDER BY " + SiralananColumn + "DESC";
                }
                if (siralamaYonu == 1) // Önce Küçük
                {
                    Str_Cmd = " SELECT* FROM " + TableName + " ORDER BY " + SiralananColumn + "ASC";
                }

                MySqlCommand DBCommand = new MySqlCommand(Str_Cmd, Con());
                MySqlDataReader DBRead = DBCommand.ExecuteReader();

                while (DBRead.Read())
                {
                    for (int i = 0; i < TableColumn.LongLength; i++)
                    {
                        ReadData[i] = DBRead[TableColumn[i]].ToString();
                    }
                }
                DBRead.Close();
                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }


        }
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region READ : All Data of Select Column    - DB Belirtilen Sütunun tüm verilerini oku
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Belirtilen Sütunun tüm verileri ListBox ya da ComboBox içine doldurur.
        /// 
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="ColumnName">Verileri okunacak sütun adı</param>
        ///  <param name="ResultData">Veri yazılacak string array</param>
        /// <param name="LSTB_ResultData">Veri yazılacak ListBox</param>
        /// <param name="CB_ResultData">Veri yazılacak ComboBox</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_SelectColumn(string TableName, string ColumnName, string[] ResultData = null, ListBox LSTB_ResultData = null, ComboBox CB_ResultData = null)
        {
            // Tablo içinde seçilen sütunun verilerini listbox içine yerleştirir.
            // SelectedColumnName hangi sütunun seçileceğini ifade eder.
            try
            {
                MySqlDataAdapter DAdapter = new MySqlDataAdapter("Select * From " + TableName, Con());
                DataSet DSet = new DataSet();
                //int Index = 0;

                DSet.Clear();
                DAdapter.Fill(DSet);

                if (LSTB_ResultData != null)
                {
                    LSTB_ResultData.Items.Clear();
                }
                if (CB_ResultData != null)
                {
                    CB_ResultData.Items.Clear();
                }

                ResultData = new string[DSet.Tables[0].Rows.Count];

                for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
                {
                    if (LSTB_ResultData != null)
                    {
                        LSTB_ResultData.Items.Add(DSet.Tables[0].Rows[i][ColumnName].ToString().TrimEnd());
                    }
                    if (CB_ResultData != null)
                    {
                        CB_ResultData.Items.Add(DSet.Tables[0].Rows[i][ColumnName].ToString().TrimEnd());
                    }

                    if (ResultData != null)
                    {
                        ResultData[i] = DSet.Tables[0].Rows[i][ColumnName].ToString().TrimEnd();
                    }

                    //Index = i;
                }


                return " 1 OK";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString();
            }

        }





        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region READ : FROM TABLE TO FILL DATAGRIDVIEW                  - DB Belirtilen Tabloyu DataGridView içine aktarır

        /// <summary>
        /// MySQL Server içindeki berlirtilen tabloyu, DGV içine aktarır.
        /// </summary>
        /// <param name="TableName">Tablo Adı</param>
        /// <param name="DataGView">Tablonun içeriğinin yazılacağı DataGridView</param>
        ///  <param name="DTable">Tablonun içeriğinin yazılacağı DataGridView</param>
        /// <returns></returns>
        public string READ_FillDGV(string TableName, DataGridView DataGView = null, DataTable DTable = null)
        {
            try
            {
                string Str_Cmd = "SELECT * from " + TableName;
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                MySqlDataAdapter da = new MySqlDataAdapter(Str_Cmd, Con());
                //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                if (DataGView != null)
                {
                    DataGView.DataSource = dt;
                }
                if (DTable != null)
                {
                    da.Fill(DTable);
                }

                return " 1 OK";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString();
            }
        }
        #endregion

        #region READ : FROM TABLE TO FILL DATAGRIDVIEW ORDER BY           - DB Belirtilen Tabloyu Sıralama Koşuluna göre DataGridView içine aktarır
        /// <summary>
        /// Belirtilen tablodaki verileri DataGridView e aktarır. Sıralama Koşulu ile DGV doldurulur.
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="SiralananColumn">Sıralama yapılacak olan sütun adı</param>
        /// <param name="siralamaYonu">0: Önce Büyük, 1:Önce Küçük</param>
        /// <param name="DataGView">Verilerin aktarılacağı DataGridView</param>
        /// <param name="DTable">Verilerin aktarılacağı Data Table</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_FillDGV_OrderBy(string TableName, string SiralananColumn, int siralamaYonu, DataGridView DataGView = null, DataTable DTable = null)
        {
            try
            {
                string Str_Cmd = "";
                if (siralamaYonu == 0) // Önce Büyük
                {
                    Str_Cmd = " SELECT* FROM " + TableName + " ORDER BY " + SiralananColumn + "DESC";
                }
                if (siralamaYonu == 1) // Önce Küçük
                {
                    Str_Cmd = " SELECT* FROM " + TableName + " ORDER BY " + SiralananColumn + "ASC";
                }

                MySqlCommand DBCommand = new MySqlCommand(Str_Cmd, Con());
                MySqlDataReader DBRead = DBCommand.ExecuteReader();


                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                MySqlDataAdapter da = new MySqlDataAdapter(Str_Cmd, Con());
                //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                if (DataGView != null)
                {
                    DataGView.DataSource = dt;
                }
                if (DTable != null)
                {
                    da.Fill(DTable);
                }

                return " 1 OK";
            }
            catch (Exception HATA)
            {
                return "-1 ERR: " + HATA.ToString();
            }
        }

        #endregion

        #region READ : SEARCH REFERANCE TEXT              - Ref.Text Belirtilen Column içinde bulup O satırdaki Verileri oku.
        /// <summary>
        /// RefText verisini RefColumn içinde arar. Bulduğu satırları DataGridView içine aktarır.
        /// Aranan stringin LikeMode biti ile benzer ya da tam karşılığının bulunması sağlanabilir.
        /// LikeMode Exmp: serachText:"ada" Bulunanlar: "adana, ada, adam".
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="SearchRefColumn">Referans Sütun Adı</param>
        /// <param name="SearchRefText">Aranacak Referans String</param>
        /// <param name="SearchINLikeMode">TRUE: Benzer içerikleri bul, FALSE: Bire bir aynı içeriği bul</param>
        /// <param name="DGV">Sonuç verilerinin yazılacağı DataGridView</param>
        /// <param name="DS">Sonuç verilerinin yazılacağı DataSet</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_SearchRefText(string TableName, string SearchRefColumn, string SearchRefText, int SearchIN_LikeMode, DataGridView DataGView = null, DataSet DS = null)
        {
            DataTable Table = new DataTable();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand Cmd = new MySqlCommand();
            //bool LikeFindMode = true; // False yapınca MySql bağlantısı Hata veriyor. Sürekli 
            string SorguCmd = "";
            try
            {
                if (SearchIN_LikeMode == 0)
                {
                    SorguCmd = "Select * From " + TableName + " Where " + SearchRefColumn + " Like '%" + SearchRefText + "%'";
                }
                if (SearchIN_LikeMode == 1)
                {
                    SorguCmd = "Select * From " + TableName + " Where " + SearchRefColumn + " Like '" + SearchRefText + "'";
                }
                if (SearchIN_LikeMode == 2)
                {
                    SorguCmd = "Select * From " + TableName + " Where " + SearchRefColumn + " Like '%" + SearchRefText + "'";
                }
                if (SearchIN_LikeMode == 3)
                {
                    SorguCmd = "Select * From " + TableName + " Where " + SearchRefColumn + " Like '" + SearchRefText + "%'";
                }
                MySqlDataAdapter DAdapter = new MySqlDataAdapter(SorguCmd, Con());
                DataSet DSet = new DataSet();
                DAdapter.Fill(DSet);
                if (DataGView != null)
                {
                    DataGView.DataSource = DSet.Tables[0];
                }

                if (DS != null)
                {
                    DAdapter.Fill(DS);
                }
                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }
        }

        #endregion

        #region READ : Select Row(with index Number) on Column         - Belirtilen tablodaki Row indexine bakarak Seçili kolonların verilerini okur
        /// <summary>
        /// RowIndex verisine bakarak seçilen satırdaki veriler ReadData içine yazılır.
        /// TableColumn index adeti ile ReadData index adeti aynı olmalıdır. 
        /// </summary>
        /// <param name="TableName">Tablo adı</param>
        /// <param name="TableColumn">Tablo sütunlarını içeren string array</param>
        /// <param name="ReadData">Okunan verinin yazıldığı string array</param>
        /// <param name="RowIndex">Verisi getirilecek Row Indexi</param>
        /// <returns>" 1 OK ": Sorgulama Başarılı, "-1 ERR: " HATA </returns>
        public string READ_SelectRowIndex(string TableName, string[] TableColumn, string[] ReadData, int RowIndex)
        {
            // Satır index'i ile belirlenen satırdaki verileri ReadData string Arrayi içine yazar.
            // Sütun arrayi içinde kaç adet yazılıysa o adette data okunur.
            try
            {
                //     MySqlCommand DBCommand = new MySqlCommand("Select * From " + TableName, MySQLConnect());
                string Str_Cmd = "SELECT * from " + TableName;
                MySqlDataAdapter DAdapter = new MySqlDataAdapter(Str_Cmd, Con());
                DataSet DSet = new DataSet();

                DSet.Clear();
                DAdapter.Fill(DSet);

                for (int i = 0; i < TableColumn.LongLength; i++)
                {
                    ReadData[i] = DSet.Tables[0].Rows[RowIndex][TableColumn[i]].ToString();
                }

                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }

        }

        #endregion

        #region READ : Select Row(with Row Content) on Column         - Belirtilen tablodaki Benzersiz Row içeriğine bakarak Seçili kolonların verilerini okur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName">Tablo Adı</param>
        /// <param name="TableColumn">Tablo Sütunu</param>
        /// <param name="ReadData">Okunan Veriler</param>
        /// <param name="RowIndex">Okunacak index numarası</param>
        /// <returns></returns>
        public string READ_SelectID(string TableName, string[] TableColumn, string[] ReadData, string RefColumn, string RefRowContent)
        {
            // Satır index'i ile belirlenen satırdaki verileri ReadData string Arrayi içine yazar.
            // Sütun arrayi içinde kaç adet yazılıysa o adette data okunur.
            try
            {
                //    MySqlCommand DBCommand = new MySqlCommand("Select * From " + TableName + " Where " + RefColumn + "=" + RefRowContent , MySQLConnect());
                string Str_Cmd              = "SELECT * from " + TableName + " Where " + RefColumn + "=" + RefRowContent;
                MySqlDataAdapter DAdapter   = new MySqlDataAdapter(Str_Cmd, Con());
                DataSet DSet                = new DataSet();

                DSet.Clear();
                DAdapter.Fill(DSet);

                for (int i = 0; i < TableColumn.LongLength; i++)
                {
                    ReadData[i] = DSet.Tables[0].Rows[0][TableColumn[i]].ToString();
                }

                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }

        }

        #endregion



        //################################################################
        //################################################################
        //################################################################
        //################################################################
        //################################################################





        #region READ : SORGULAMA
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        public string READ_QueryFillDGV_FromSQL(string TableName, DataGridView DataGView, string[] TableColumn, string[] SelectData)
        {
            DataTable Table = new DataTable();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand Cmd = new MySqlCommand();
            string TmpCmd1 = "";
            string TmpCmd2 = "";

            try
            {
                for (int i = 0; i < TableColumn.LongLength; i++)
                {
                    if (TableColumn[i] != null && SelectData[i] != null && TableColumn[i] != "" && SelectData[i] != "")
                    {
                        if (TmpCmd2 == "")
                        {
                            TmpCmd2 = TableColumn[i] + " = '" + SelectData[i] + "'";
                        }
                        else
                        {
                            TmpCmd2 = TmpCmd2 + " and " + TableColumn[i] + " = '" + SelectData[i] + "'";
                        }
                    }
                }

                TmpCmd1 = "Select * from " + TableName + " Where " + TmpCmd2;  //+" Where ID = '3' and Name = 'b' "; //
                MySqlDataAdapter DAdapter = new MySqlDataAdapter(TmpCmd1, Con());
                DataSet DSet = new DataSet();
                DAdapter.Fill(DSet);
                DataGView.DataSource = DSet.Tables[0];

                if (DSet.Tables[0].Rows.Count < 1)
                {
                    return " 2 OK! Sonuç Bulunamadı";
                }
                else
                {
                    return " 1 OK!";
                }
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }


        }
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region READ : SORGULAMA Tarih Sorgula & Grid doldur
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        public string READ_DateQueryFillDGV_FromSQL(string TableName, DataGridView DataGView, DateTime Tarih1, DateTime Tarih2, string[] TableColumn, string[] SelectData)
        {
            DataTable Table = new DataTable();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            MySqlCommand Cmd = new MySqlCommand();

            string TmpCmd1 = "";
            string TmpCmd2 = "";

            try
            {
                Cmd.Connection = Con();
                // Diğer Parametreleri Belirle
                for (int i = 0; i < TableColumn.LongLength; i++)
                {
                    if (TableColumn[i] != null && SelectData[i] != null)
                    {
                        TmpCmd2 = TmpCmd2 + " and " + TableColumn[i] + "= @SorguStr" + i.ToString();
                        Cmd.Parameters.AddWithValue("@SorguStr" + i.ToString(), SelectData[i]);
                    }
                }

                // Tarih aralığı sorgula
                if (Tarih1 != Tarih2)
                {
                    TmpCmd1 = "Select * from " + TableName + " Where Tarih >= @Tarih1 and Tarih <= @Tarih2";
                    if (TmpCmd2 != "")
                        Cmd.CommandText = TmpCmd1 + TmpCmd2;
                    else
                        Cmd.CommandText = TmpCmd1;

                    Cmd.Parameters.AddWithValue("@Tarih1", Tarih1);
                    Cmd.Parameters.AddWithValue("@Tarih2", Tarih2);

                    Adapter.SelectCommand = Cmd;

                    Table.Clear();
                    Adapter.Fill(Table);
                    DataGView.DataSource = Table;
                }
                // Tek Tarih sorgula
                else if (Tarih1 == Tarih2)
                {
                    TmpCmd1 = "Select * from " + TableName + " Where Tarih = @Tarih1";

                    if (TmpCmd2 != "")
                    { Cmd.CommandText = TmpCmd1 + TmpCmd2; }
                    else
                    { Cmd.CommandText = TmpCmd1; }

                    Cmd.Parameters.AddWithValue("@Tarih1", Convert.ToDateTime(Tarih1.ToShortDateString()));

                    Adapter.SelectCommand = Cmd;
                    Table.Clear();
                    Adapter.Fill(Table);
                    DataGView.DataSource = Table;
                }
                return " 1 OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString();
            }


        }
        // ---------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region UPDATE - Kayıt Güncelle                     - Referans Kolonunda referans texti bulup o satırdaki verileri günceller
        public string UPDATE_WithRefText_FromSQLRow(string TableName, string[] TableColumn, string[] WriteData, string RefColumn, string RefText, int PrimaryKey)
        {
            string TmpStr = "";
            try
            {
                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = Con();
                long ColumnAdet = TableColumn.LongLength;

                for (int i = 0; i < ColumnAdet; i++)
                {
                    if (PrimaryKey == -1 || PrimaryKey != i)
                    {
                        TmpStr = TmpStr + TableColumn[i] + "=@" + TableColumn[i];
                        Cmd.Parameters.AddWithValue("@" + TableColumn[i], WriteData[i]);
                    }

                    if (i < (TableColumn.LongLength - 1) && PrimaryKey != i)
                    {
                        TmpStr = TmpStr + ", ";
                    }
                }

                Cmd.CommandText = "UPDATE " + TableName + " Set " + TmpStr + " Where " + RefColumn + "=" + RefText;
                Cmd.ExecuteNonQuery();

                return " 1 OK"; // Yazma İşlemi OK
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }
        }
        #endregion

        #region WRITE : Row                                             - Belirtilen tablodaki TableColumn içine writeDataları doldurur
        public string WRITE_ToSQLRow(string TableName, string[] TableColumn, string[] WriteData, int PrimaryKey)
        {
            string TempTableColumn1 = "";
            string TempTableColumn2 = "";
            try
            {
                MySqlCommand DBCommand = new MySqlCommand(); //("Select * From " + TableName, Connect());
                DBCommand.Connection = Con();
                long ColumnAdet = TableColumn.LongLength;
                for (int i = 0; i < ColumnAdet; i++)
                {
                    if (PrimaryKey == -1 || PrimaryKey != i)
                    {
                        TempTableColumn1 = TempTableColumn1 + TableColumn[i];
                        TempTableColumn2 = TempTableColumn2 + "@" + TableColumn[i];

                        DBCommand.Parameters.AddWithValue("@" + TableColumn[i], WriteData[i]);
                    }

                    if (i < (ColumnAdet - 1) && (PrimaryKey != i))
                    {
                        TempTableColumn1 = TempTableColumn1 + ",";
                        TempTableColumn2 = TempTableColumn2 + ",";
                    }
                }
                if (ConnectionStatus != "Open" )
                { 
                    Connection.Open();
                }
                DBCommand.CommandText = "Insert into " + TableName + "(" + TempTableColumn1 + ") Values (" + TempTableColumn2 + ")";
                DBCommand.ExecuteNonQuery();
                return "OK"; // Yazma İşlemi OK
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }
        }
        #endregion

        #region WRITE : Row with Unique Ref.Text                              - Belirtilen Tablodaki belirtilen sütun içinde Ref.Text yoksa yeni oluşturur.

        public string WRITE_WithRefText_ToSQLRow(string TableName, string[] TableColumn, string[] WriteData, string RefColumn, string RefText, int PrimaryKey)
        {
            // Önce RefText verisi RefColumn içinde aranır. Aynı veri yoksa kayıt işlemi yapılır.
            // Aynı veri varsa return 99 gerçekleşir. Kayıt try işlem görmez.
            string TempTableColumn1 = "";
            string TempTableColumn2 = "";
            ListBox LBox = new ListBox();
            string RText = "";
            bool HataliRef = false;
            long ColumnAdet = TableColumn.LongLength;
            try
            {
                MySqlDataAdapter DAdapter = new MySqlDataAdapter("Select * From " + TableName, Con());
                DataSet DSet = new DataSet();
                //int Index = 0;

                DSet.Clear();
                DAdapter.Fill(DSet);
                LBox.Items.Clear();

                for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
                {
                    LBox.Items.Add(DSet.Tables[0].Rows[i][RefColumn].ToString().TrimEnd());
                    //Index = i;

                    RText = RefText;
                    if (DSet.Tables[0].Rows[i][RefColumn].ToString() == RText) { HataliRef = true; }
                    //  if (((i-1) >= DSet.Tables[0].Rows.Count))                       { Write_ENB = true; }
                }


                if (!HataliRef)
                {
                    MySqlCommand DBCommand = new MySqlCommand();
                    DBCommand.Connection = Con();

                    for (int j = 0; j < ColumnAdet; j++)
                    {
                        if (PrimaryKey == -1 || PrimaryKey != j)
                        {
                            TempTableColumn1 = TempTableColumn1 + TableColumn[j];
                            TempTableColumn2 = TempTableColumn2 + "@" + TableColumn[j];

                            DBCommand.Parameters.AddWithValue("@" + TableColumn[j], WriteData[j]);
                        }
                        if (j < (ColumnAdet - 1) && PrimaryKey != j)
                        {
                            TempTableColumn1 = TempTableColumn1 + ",";
                            TempTableColumn2 = TempTableColumn2 + ",";
                        }
                    }
                    DBCommand.CommandText = "Insert into " + TableName + "(" + TempTableColumn1 + ") Values (" + TempTableColumn2 + ")";
                    DBCommand.ExecuteNonQuery();
                    HataliRef = false;
                    return " 1 OK!"; // Ref.Text Ref.column içinde yok ref text ref column içine eklendi.
                }
                else
                {

                    return " 2 OK! Aynı Referans Var"; // Ref.Text Ref.column içinde bulundu.
                }

            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR! - " + HATA.ToString(); // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }
        }

        #endregion

        #region WRITE : IMAGE Unique Ref.Text                                 - Belirtilen Tablodaki belirtilen sütun içinde Ref.Text yoksa yeni oluşturur.
        public string WRITE_ImageToMySQL(string TableName, string PicColumnName, PictureBox SETPictureBox , string RefColumn, string RefText)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                SETPictureBox.Image.Save(ms, SETPictureBox.Image.RawFormat);
                byte[] PicData = ms.ToArray(); ;

                MySqlCommand command = new MySqlCommand("UPDATE "+ TableName + " SET "+ PicColumnName + "=@img WHERE " + RefColumn + "=" + RefText, Con());
                command.Parameters.Add("@img",  MySqlDbType.Blob).Value = PicData;
                if (ConnectionStatus != "Open")
                {
                    Connection.Open();
                }
           
                command.ExecuteNonQuery();     

                return " 1 OK"; // Yazma İşlemi OK
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }
        }

        public string READ_ImageFormMySQL(string TableName, string PicColumnName, PictureBox ShowPictureBox, string RefColumn, string RefText)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + TableName + " WHERE " +RefColumn + "=" + RefText, Con());
      

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                byte[] img = (byte[])table.Rows[0][PicColumnName];
                MemoryStream ms = new MemoryStream(img);
                ShowPictureBox.Image = Image.FromStream(ms);

                return " 1 OK"; // Yazma İşlemi OK
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }

    
        }
        #endregion

        #region WRITE : DataGridView to SQL                                  - 
        public string WRITE_DGVToSQL(string TableName, DataGridView DataGView, bool SonBosSatiriEkle)
        {
            string TempTableColumn1 = "";
            string TempTableColumn2 = "";
            string[] TableColumn = new string[DataGView.ColumnCount];
            string[] WriteData = new string[DataGView.ColumnCount];
            try
            {
                MySqlCommand DBCommand = new MySqlCommand(); //("Select * From " + TableName, Connect());
                DBCommand.Connection = Con();

                for (int i = 0; i < DataGView.Columns.Count; i++)
                {
                    TableColumn[i] = DataGView.Columns[i].HeaderText;

                    TempTableColumn1 = TempTableColumn1 + TableColumn[i];
                    TempTableColumn2 = TempTableColumn2 + "@" + TableColumn[i];

                    if (i < (DataGView.Columns.Count - 1))
                    {
                        TempTableColumn1 = TempTableColumn1 + ",";
                        TempTableColumn2 = TempTableColumn2 + ",";
                    }
                }

                int RowsCount;
                if (SonBosSatiriEkle) { RowsCount = DataGView.Rows.Count; } else { RowsCount = (DataGView.Rows.Count - 1); }

                for (int i = 0; i < RowsCount; i++)
                {
                    DBCommand.Parameters.Clear();
                    for (int j = 0; j < DataGView.Columns.Count; j++)
                    {
                        if (DataGView.Rows[i].Cells[j].Value != null)
                        {
                            WriteData[j] = DataGView.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            WriteData[j] = "";
                        }

                        DBCommand.Parameters.AddWithValue("@" + TableColumn[j], WriteData[j]);
                    }

                    DBCommand.CommandText = "Insert into " + TableName + "(" + TempTableColumn1 + ") Values (" + TempTableColumn2 + ")";
                    DBCommand.ExecuteNonQuery();

                }

                return " 1 OK"; // Yazma İşlemi OK
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString();  // Yazma işleminde ya da DB bağlantısında problem oluştu.
            }


        }

        #endregion

        #region DELETE : Row Delete                                     - Belirtilen tablodaki belirtilen Sütundaki ref Text i bulup o sarıtı siler.

        public string DELETE_RowWithRefText(string TableName, string TableColumn, string RefDeteleText)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = Con();
                Cmd.CommandText = "Delete From " + TableName + " Where " + TableColumn + "= '" + RefDeteleText + "'";
                Cmd.ExecuteNonQuery();
                return " 1 OK";  //Silme işlemi tamamlandı.
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); //Silme işleminde ya da DB bağlantısında problem oluştu.
            }
        }

        #endregion

        #region DELETE : ALL Delete                                     - Belirtilen tablodaki tüm satırları siler.

        public string DELETE_AllOfRows(string TableName)
        {
            try
            {
                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = Con();
                Cmd.CommandText = "Delete From " + TableName;
                Cmd.ExecuteNonQuery();
                return " 1 OK";  //Silme işlemi tamamlandı.
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "-1 ERR: " + HATA.ToString(); //Silme işleminde ya da DB bağlantısında problem oluştu.
            }
        }

        #endregion

        #region FIND LAST NUMBER
        /// <summary>
        /// Daha önce verilmiş numaraları kontrol ederek kullanılabilir son numarayı
        /// bulmak için kullanılır. </summary>
        /// <param name="MySQLTableName">   MySQL tablo adı</param>
        /// <param name="ColumnName">       Tablodaki listelenmesi istenilen Sütun adı</param>
        /// <param name="ReferansKullanimi">6 adet'e kadar referans kullanılabilir</param>
        /// <param name="RefColumnName">    Referans Sütun Adı</param>
        /// <param name="RefValue">         Referans Sütun'larda bulunacak gereken Değer</param>
        /// <param name="TargetLastNo">     Kullanılabilir olan son numara</param>
        /// <returns></returns>
        public string FindLastNumber(string MySQLTableName, string ColumnName, bool ReferansKullanimi, string[] RefColumnName, string[] RefValue, out string TargetLastNo)
        {
            TargetLastNo            = "0";
            ListBox NumberLBox      = new ListBox();
            ListBox[] RefValLBox    = new ListBox[RefColumnName.Length]; // Referans Sütun adeti kadar Referans Value Listbox'u oluştur

            try
            {
    
                if (ReferansKullanimi)
                {
                    for (int i = 0; i < RefColumnName.Length; i++)
                    {
                        RefValLBox[i] = new ListBox();
                        READ_SelectColumn(MySQLTableName, RefColumnName[i], null, RefValLBox[i]); 
                    }

                    READ_SelectColumn(MySQLTableName, ColumnName, null, NumberLBox);

                    int[] NumberItems = new int[NumberLBox.Items.Count];
                    for (int i = 0; i < NumberLBox.Items.Count; i++)
                    {
                        if (RefColumnName.Length == 1)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                        else if(RefColumnName.Length == 2)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim() && RefValLBox[1].Items[i].ToString() == RefValue[1].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                        else if (RefColumnName.Length == 3)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim() && RefValLBox[1].Items[i].ToString() == RefValue[1].Trim() &&
                                RefValLBox[2].Items[i].ToString() == RefValue[2].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                        else if (RefColumnName.Length == 4)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim() && RefValLBox[1].Items[i].ToString() == RefValue[1].Trim() &&
                                RefValLBox[2].Items[i].ToString() == RefValue[2].Trim() && RefValLBox[3].Items[i].ToString() == RefValue[3].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                        else if (RefColumnName.Length == 5)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim() && RefValLBox[1].Items[i].ToString() == RefValue[1].Trim() &&
                                RefValLBox[2].Items[i].ToString() == RefValue[2].Trim() && RefValLBox[3].Items[i].ToString() == RefValue[3].Trim() &&
                                RefValLBox[4].Items[i].ToString() == RefValue[4].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                        else if (RefColumnName.Length == 6)
                        {
                            if (RefValLBox[0].Items[i].ToString() == RefValue[0].Trim() && RefValLBox[1].Items[i].ToString() == RefValue[1].Trim() &&
                                RefValLBox[2].Items[i].ToString() == RefValue[2].Trim() && RefValLBox[3].Items[i].ToString() == RefValue[3].Trim() &&
                                RefValLBox[4].Items[i].ToString() == RefValue[4].Trim() && RefValLBox[5].Items[i].ToString() == RefValue[5].Trim())
                            {
                                NumberItems[i] = int.Parse(NumberLBox.Items[i].ToString());
                            }
                        }
                    }

                    int EnbuyukItems = 0;
                    if (NumberLBox.Items.Count > 0)
                    {
                        EnbuyukItems = NumberItems.Max();
                    }

                    TargetLastNo = (EnbuyukItems + 1).ToString();

                }
                else
                { 
                    READ_SelectColumn(MySQLTableName, ColumnName, null, NumberLBox);


                    int[] Items = new int[NumberLBox.Items.Count];

                    for (int i = 0; i < NumberLBox.Items.Count; i++)
                    {
                        Items[i] = int.Parse(NumberLBox.Items[i].ToString());
                    }

                    int EnbuyukItems = 0;
                    if (NumberLBox.Items.Count > 0)
                    {
                        EnbuyukItems = Items.Max();
                    }

                    TargetLastNo = (EnbuyukItems + 1).ToString();
                }

                return "OK! - " + TargetLastNo;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR! - " + HATA.ToString();
            }
        }
        #endregion


        /// <summary>
        /// Açık SQL Sorgusu yapmak için kullanılır.
        /// Command String girilmesi ve sorgu sonucu için DGV girilmesi gereklidir.
        /// </summary>
        /// <param name="StringCMD">Komutun yer aldığı string</param>
        ///  <param name="DGV">Sounuçların yer aldığı DGV</param>
        /// <returns></returns>
        public string Open_CMD_ResultinDGV(string StringCMD, DataGridView DGV = null, DataSet DSet = null)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(StringCMD, Con());
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (DGV != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DGV.DataSource = ds.Tables[0];
                    }
                }

                if (DSet != null)
                {
                    da.Fill(DSet);
                }

                return " 1 OK";
            }
            catch (Exception Hata)
            {
                return "-1 ERR: " + Hata.ToString();
            }
        }

    }
}
