﻿namespace Parkon
{
    partial class Form_Yeni_Yetkili
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_No = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Iptal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_YetkiliUnvan = new System.Windows.Forms.TextBox();
            this.TB_YetkiliSoyad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_YetkiliNo = new System.Windows.Forms.TextBox();
            this.TB_YetkiliAd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_YetkiliTel1 = new System.Windows.Forms.TextBox();
            this.TB_YetkiliTel2 = new System.Windows.Forms.TextBox();
            this.TB_YetkiliMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_YetkiliNot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_MusteriFirma_Adi = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Müşteri Firma Adı :";
            // 
            // TB_MusteriFirma_No
            // 
            this.TB_MusteriFirma_No.Location = new System.Drawing.Point(109, 28);
            this.TB_MusteriFirma_No.Name = "TB_MusteriFirma_No";
            this.TB_MusteriFirma_No.ReadOnly = true;
            this.TB_MusteriFirma_No.Size = new System.Drawing.Size(355, 20);
            this.TB_MusteriFirma_No.TabIndex = 2;
            this.TB_MusteriFirma_No.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Müşteri Firma No :";
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(345, 197);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(58, 22);
            this.B_OK.TabIndex = 12;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Iptal
            // 
            this.B_Iptal.Location = new System.Drawing.Point(405, 197);
            this.B_Iptal.Name = "B_Iptal";
            this.B_Iptal.Size = new System.Drawing.Size(58, 22);
            this.B_Iptal.TabIndex = 11;
            this.B_Iptal.Text = "İptal";
            this.B_Iptal.UseVisualStyleBackColor = true;
            this.B_Iptal.Click += new System.EventHandler(this.B_Iptal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Yetkili Kişi No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Yetkili Kişi Ünvanı :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Yetkili Kişi Ad :";
            // 
            // TB_YetkiliUnvan
            // 
            this.TB_YetkiliUnvan.Location = new System.Drawing.Point(109, 90);
            this.TB_YetkiliUnvan.Name = "TB_YetkiliUnvan";
            this.TB_YetkiliUnvan.Size = new System.Drawing.Size(355, 20);
            this.TB_YetkiliUnvan.TabIndex = 6;
            this.TB_YetkiliUnvan.TextChanged += new System.EventHandler(this.BUYUK_HARF_YAZ_ENG);
            // 
            // TB_YetkiliSoyad
            // 
            this.TB_YetkiliSoyad.Location = new System.Drawing.Point(332, 50);
            this.TB_YetkiliSoyad.Name = "TB_YetkiliSoyad";
            this.TB_YetkiliSoyad.Size = new System.Drawing.Size(132, 20);
            this.TB_YetkiliSoyad.TabIndex = 4;
            this.TB_YetkiliSoyad.TextChanged += new System.EventHandler(this.BUYUK_HARF_YAZ_ENG);
            this.TB_YetkiliSoyad.Validating += new System.ComponentModel.CancelEventHandler(this.YetkiliNO_Sorgula);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Yetkili Kişi Soyad :";
            // 
            // TB_YetkiliNo
            // 
            this.TB_YetkiliNo.Location = new System.Drawing.Point(109, 70);
            this.TB_YetkiliNo.Name = "TB_YetkiliNo";
            this.TB_YetkiliNo.ReadOnly = true;
            this.TB_YetkiliNo.Size = new System.Drawing.Size(355, 20);
            this.TB_YetkiliNo.TabIndex = 5;
            this.TB_YetkiliNo.TabStop = false;
            // 
            // TB_YetkiliAd
            // 
            this.TB_YetkiliAd.Location = new System.Drawing.Point(109, 50);
            this.TB_YetkiliAd.Name = "TB_YetkiliAd";
            this.TB_YetkiliAd.Size = new System.Drawing.Size(132, 20);
            this.TB_YetkiliAd.TabIndex = 3;
            this.TB_YetkiliAd.TextChanged += new System.EventHandler(this.BUYUK_HARF_YAZ_ENG);
            this.TB_YetkiliAd.Validating += new System.ComponentModel.CancelEventHandler(this.YetkiliNO_Sorgula);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Yetkili Kişi Tel 1 / 2 :";
            // 
            // TB_YetkiliTel1
            // 
            this.TB_YetkiliTel1.Location = new System.Drawing.Point(109, 110);
            this.TB_YetkiliTel1.Name = "TB_YetkiliTel1";
            this.TB_YetkiliTel1.Size = new System.Drawing.Size(176, 20);
            this.TB_YetkiliTel1.TabIndex = 7;
            // 
            // TB_YetkiliTel2
            // 
            this.TB_YetkiliTel2.Location = new System.Drawing.Point(288, 110);
            this.TB_YetkiliTel2.Name = "TB_YetkiliTel2";
            this.TB_YetkiliTel2.Size = new System.Drawing.Size(176, 20);
            this.TB_YetkiliTel2.TabIndex = 8;
            // 
            // TB_YetkiliMail
            // 
            this.TB_YetkiliMail.Location = new System.Drawing.Point(109, 131);
            this.TB_YetkiliMail.Name = "TB_YetkiliMail";
            this.TB_YetkiliMail.Size = new System.Drawing.Size(355, 20);
            this.TB_YetkiliMail.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Yetkili Kişi Mail :";
            // 
            // TB_YetkiliNot
            // 
            this.TB_YetkiliNot.Location = new System.Drawing.Point(109, 151);
            this.TB_YetkiliNot.Multiline = true;
            this.TB_YetkiliNot.Name = "TB_YetkiliNot";
            this.TB_YetkiliNot.Size = new System.Drawing.Size(355, 45);
            this.TB_YetkiliNot.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Yetkili Kişi Not :";
            // 
            // CB_MusteriFirma_Adi
            // 
            this.CB_MusteriFirma_Adi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MusteriFirma_Adi.FormattingEnabled = true;
            this.CB_MusteriFirma_Adi.Location = new System.Drawing.Point(109, 5);
            this.CB_MusteriFirma_Adi.Name = "CB_MusteriFirma_Adi";
            this.CB_MusteriFirma_Adi.Size = new System.Drawing.Size(355, 21);
            this.CB_MusteriFirma_Adi.Sorted = true;
            this.CB_MusteriFirma_Adi.TabIndex = 1;
            this.CB_MusteriFirma_Adi.SelectedIndexChanged += new System.EventHandler(this.CB_MusteriFirma_Adi_SelectedIndexChanged);
            this.CB_MusteriFirma_Adi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CB_MusteriFirma_Adi_MouseDown);
            // 
            // Form_Yeni_Yetkili
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 222);
            this.Controls.Add(this.CB_MusteriFirma_Adi);
            this.Controls.Add(this.B_Iptal);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.TB_YetkiliNo);
            this.Controls.Add(this.TB_MusteriFirma_No);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_YetkiliTel2);
            this.Controls.Add(this.TB_YetkiliTel1);
            this.Controls.Add(this.TB_YetkiliSoyad);
            this.Controls.Add(this.TB_YetkiliAd);
            this.Controls.Add(this.TB_YetkiliNot);
            this.Controls.Add(this.TB_YetkiliMail);
            this.Controls.Add(this.TB_YetkiliUnvan);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Yeni_Yetkili";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YENİ YETKİLİ KİŞİ EKLE";
            this.Load += new System.EventHandler(this.Form_Yeni_Musteri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox TB_MusteriFirma_No;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button B_OK;
        public System.Windows.Forms.Button B_Iptal;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TB_YetkiliUnvan;
        public System.Windows.Forms.TextBox TB_YetkiliSoyad;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox TB_YetkiliNo;
        public System.Windows.Forms.TextBox TB_YetkiliAd;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TB_YetkiliTel1;
        public System.Windows.Forms.TextBox TB_YetkiliTel2;
        public System.Windows.Forms.TextBox TB_YetkiliMail;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TB_YetkiliNot;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_MusteriFirma_Adi;
    }
}