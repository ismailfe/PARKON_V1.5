using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Parkon
{
    public partial class Form_Ayarlar : Form
    {

        #region PUBLIC_VARIABLE
        public CLS CLS;
        #endregion



        public Form_Ayarlar()
        {
            InitializeComponent();
        }


        #region SAYFA - AYARLAR
        private void B_AnaDizinSec_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FbWDialog = new FolderBrowserDialog();
            FbWDialog.ShowDialog();
            TB_SecilenAnaDizin.Text = FbWDialog.SelectedPath + "\\";
            CLS.PrgSettings.KAYDET_AnaDizin();
            MessageBox.Show("Projelerin yer aldığı ana dizin; ''" + TB_SecilenAnaDizin.Text + "'' olarak değiştirildi. ", "Ana dizin seçimi");
        }


     
        private void B_KaydetAyarlar_Click(object sender, EventArgs e)
        {
            CLS.PrgSettings.KAYDET_SistemAyarlari();
            MessageBox.Show("Ayarlar Kaydedildi.", "Kayıt");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion






        private void BUYUK_HARF_YAZ(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void BUYUK_HARF_YAZ_ENG(object sender, EventArgs e)
        {

            ((TextBox)sender).Text = CLS.TextCheck.StringENG(((TextBox)sender).Text).ToUpper();
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }
        private void SADECE_RAKAM_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void SADECE_HARF_YAZ(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                        && !char.IsSeparator(e.KeyChar);
        }





    }
}
