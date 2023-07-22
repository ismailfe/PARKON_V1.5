using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Reflection;
using System.Deployment.Application;
using System.Windows.Forms;
using System.ComponentModel;

namespace Parkon
{
    public class AutoUpdate
    {
        public CLS CLS;

        public string VerCheck(out string[] OkunanBilgi)
        {
            OkunanBilgi = new string[9];
            try
            {
                string[] Rdata = new string[9];
                CLS.ID_MySQL.READ_FirstSingleRow(CLS.MySQLVar.TableName_DBParkon, CLS.MySQLVar.ColumnName_DBParkon, Rdata);

                for (int i = 0; i < Rdata.Length; i++)
                {
                    OkunanBilgi[i] = Rdata[i];
                }

                CLS.Form_VersiyonYukle.LB_KullanilanVersion.Text = CLS.fvi.FileVersion;
                CLS.Form_VersiyonYukle.LB_GuncelVersiyon.Text = VersiyonOku();// Rdata[5].ToString();
                int KVer =  int.Parse(CLS.fvi.FileVersion.Replace(".", ""));
                int GVer = int.Parse(VersiyonOku().Replace(".", "")); //int.Parse(Rdata[5].ToString().Replace(".", ""));
                if (KVer < GVer)
                {
                    CLS.Form_Main.B_YeniVerBulundu.Visible = true;
                    CLS.Bildirimler.Notify_VersiyonBilgi(Rdata[7], Rdata[8]);
                    CLS.Form_VersiyonYukle.ShowDialog();
                }
                else
                {
                    CLS.Form_Main.B_YeniVerBulundu.Visible = false;
                }

                return "OK!";
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }
        }

        public string VersiyonOku()
        {
            try
            {
                WebRequest wr = WebRequest.Create(new Uri("http://xxx.com/parkon/ver.txt"));
                WebResponse ws = wr.GetResponse();
                StreamReader sr = new StreamReader(ws.GetResponseStream());

                string NewVersion = sr.ReadToEnd();
                return NewVersion;
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
                return "ERR!";
            }

        }

        ProgressBar progressBar1 = new ProgressBar();
        string DownloadAdd;
        string SaveAdd;
        public string indir()
        {
            try
            {

                DownloadAdd     = "http://xxx.com/parkon/setup/Parkon_Setup.msi";
                SaveAdd         = CLS.ProgramData_Path  + "Update" + "\\" + "Parkon_Setup.msi";

                if (!Directory.Exists(Application.StartupPath + "\\" + "Update"))
                {
                    Directory.CreateDirectory(CLS.ProgramData_Path + "\\" + "Update");
                }

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(DownloadAdd, SaveAdd);
                    wc.DownloadProgressChanged  += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted    += comp;
                    wc.DownloadFileAsync(new System.Uri(DownloadAdd), SaveAdd);
                }

                return "OK!";
            }
            catch (Exception HATA)
            {

                return "ERR! "+ HATA.ToString();
            }
        }

        void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            CLS.Form_VersiyonYukle.progressBar1.Visible     = true;
            CLS.Form_VersiyonYukle.progressBar1.Value       = e.ProgressPercentage;
            progressBar1.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
        }

        void comp(object sender, AsyncCompletedEventArgs e)
        {
            System.Diagnostics.Process.Start(SaveAdd);
            CLS.Form_Main.APPCLOSE();
            // this.Close();
        }

        #region ESKİ KONTROL FONKSİYONLARI

        public void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info;// = null;

            if (true) //ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }


        #endregion


    }
}
