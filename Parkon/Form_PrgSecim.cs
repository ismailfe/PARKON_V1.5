using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Parkon
{
    public partial class Form_PrgSecim : Form
    {
        public CLS CLS;
        public Form_PrgSecim()
        {
            InitializeComponent();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(CLS.ProgramData_Path))
                {
                    Directory.CreateDirectory(CLS.ProgramData_Path);
                }

                if (RB_Elektronik.Checked)
                {
                    File.Create(CLS.PrgSecim_Elektronik);
                    File.Create(CLS.PrgSecim_Config);
                }
                else if (RB_Otomasyon.Checked)
                {
                    File.Create(CLS.PrgSecim_Otomasyon);
                    File.Create(CLS.PrgSecim_Config);
                }
                else
                {
                    MessageBox.Show("Herhangi bir seçim yapılmadı! Lütfen seçim yapınız.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CLS.PrgSecimi.Secim();
                CLS.Form_Main.Tab_Main.Refresh();
                this.Close();
            }
            catch (Exception HATA)
            {
                CLS.Log.ERR_LOGS(HATA.ToString());
            }
         

        }
    }
}
