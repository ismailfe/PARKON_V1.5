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
    public class Log
    {

        public CLS CLS;
        public string LogFileRead(RichTextBox RTB, string logfilePath)
        {
            try
            {
                RTB.Text = File.ReadAllText(logfilePath); // (@"path.txt");

                return "OK!";
            }
            catch (Exception HATA)
            {

                return HATA.ToString();
            }
          
        }
        public string LOGYAZ(string FileName, RichTextBox box, string text, Color color, bool addNewLine, bool Bold)
        {
            try
            {
                string Tarih = DateTime.Now.ToShortDateString();
                string Saat = DateTime.Now.ToLongTimeString();
                string mesaj;

                if (addNewLine)
                { mesaj = "\n" + Tarih + " " + Saat + ": " + text; }
                else
                { mesaj = text; }

                if (Bold)
                { box.SelectionFont = new Font(box.Font, FontStyle.Bold); }
                else
                { box.SelectionFont = new Font(box.Font, FontStyle.Regular); }

                box.SuspendLayout();
                box.SelectionColor = color;
                box.AppendText(mesaj);
                box.ScrollToCaret();
                box.ResumeLayout();

                //string path = Application.ExecutablePath;   // App. exe yolu
                //string path2 = Application.StartupPath;     // App. exe klasör yolu
                string path3 = CLS.ProgramData_Path + FileName + ".txt";
                StreamWriter Dosya = File.AppendText(path3);
                Dosya.WriteLine(mesaj, RichTextBoxStreamType.PlainText);
                Dosya.Close();

                return "OK!";
            }
            catch (Exception HATA)
            {
                ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }


        }
        public string Log_Save(string FileName, RichTextBox RTB)
        {
            try
            {
                //string path = Application.ExecutablePath;   // App. exe yolu
                //string path2 = Application.StartupPath;     // App. exe klasör yolu
                //string path3 = path2 + "\\" + RTB_FilesName + ".txt";

                string path3 = CLS.ProgramData_Path + FileName + ".txt";

                RTB.SaveFile(path3, RichTextBoxStreamType.PlainText);
                StreamWriter Dosya = File.AppendText(path3);
                Dosya.WriteLine(RTB.Text, RichTextBoxStreamType.PlainText);
                Dosya.Close();
                return "OK!";
            }
            catch (Exception HATA)
            {
                ERR_LOGS(HATA.ToString());
                return "ERR! " +  HATA.ToString();
            }

        }

        public string ERR_LOGS(string HataMesaji)
        {
            try
            {
                if (HataMesaji == null)
                {
                    HataMesaji = "";
                }

              RichTextBox RTB_LogsError = new RichTextBox();
              string cmd = LOGYAZ("Log_Error", RTB_LogsError, " HATA: " + HataMesaji, Color.Black, true, false);

                return cmd;

            }
            catch (Exception HATA)
            {
                return HATA.ToString();
            }

          
        }

          public string Log_Temizle(string FileName)
        {
            try
            {
                string path3 = CLS.ProgramData_Path + FileName + ".txt";
                TextWriter tw = new StreamWriter(path3);
                tw.Write("");
                tw.Close();
                return "OK!";
            }
            catch (Exception HATA)
            {
                ERR_LOGS(HATA.ToString());
                return HATA.ToString();
            }


        }

    }
}
