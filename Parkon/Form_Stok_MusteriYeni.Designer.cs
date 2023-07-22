namespace Parkon
{
    partial class Form_Stok_MusteriYeni
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
            this.TB_MusteriFirma_Adi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_No = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Iptal = new System.Windows.Forms.Button();
            this.TB_MusteriBolum_No = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_MusteriBolum_Adi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CHB_MuseriBolum_Adi_Degistir = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_Tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_Adres = new System.Windows.Forms.TextBox();
            this.CB_MusteriFirma_Bolge = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_MapsLink = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_MusteriFirma_Not = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TB_MusteriFirma_Adi
            // 
            this.TB_MusteriFirma_Adi.Location = new System.Drawing.Point(114, 5);
            this.TB_MusteriFirma_Adi.Name = "TB_MusteriFirma_Adi";
            this.TB_MusteriFirma_Adi.Size = new System.Drawing.Size(349, 20);
            this.TB_MusteriFirma_Adi.TabIndex = 0;
            this.TB_MusteriFirma_Adi.TextChanged += new System.EventHandler(this.BUYUK_HARF_YAZ_ENG);
            this.TB_MusteriFirma_Adi.Validating += new System.ComponentModel.CancelEventHandler(this.TB_MusteriFirma_Adi_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Müşteri Firma Adı:";
            // 
            // TB_MusteriFirma_No
            // 
            this.TB_MusteriFirma_No.Location = new System.Drawing.Point(114, 27);
            this.TB_MusteriFirma_No.Name = "TB_MusteriFirma_No";
            this.TB_MusteriFirma_No.ReadOnly = true;
            this.TB_MusteriFirma_No.Size = new System.Drawing.Size(349, 20);
            this.TB_MusteriFirma_No.TabIndex = 23;
            this.TB_MusteriFirma_No.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Müşteri Firma No:";
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(343, 257);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(58, 22);
            this.B_OK.TabIndex = 9;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Iptal
            // 
            this.B_Iptal.Location = new System.Drawing.Point(406, 257);
            this.B_Iptal.Name = "B_Iptal";
            this.B_Iptal.Size = new System.Drawing.Size(58, 22);
            this.B_Iptal.TabIndex = 8;
            this.B_Iptal.Text = "İptal";
            this.B_Iptal.UseVisualStyleBackColor = true;
            this.B_Iptal.Click += new System.EventHandler(this.B_Iptal_Click);
            // 
            // TB_MusteriBolum_No
            // 
            this.TB_MusteriBolum_No.Location = new System.Drawing.Point(114, 234);
            this.TB_MusteriBolum_No.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_MusteriBolum_No.Name = "TB_MusteriBolum_No";
            this.TB_MusteriBolum_No.ReadOnly = true;
            this.TB_MusteriBolum_No.Size = new System.Drawing.Size(350, 20);
            this.TB_MusteriBolum_No.TabIndex = 29;
            this.TB_MusteriBolum_No.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Bölüm No:";
            // 
            // TB_MusteriBolum_Adi
            // 
            this.TB_MusteriBolum_Adi.Location = new System.Drawing.Point(114, 211);
            this.TB_MusteriBolum_Adi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TB_MusteriBolum_Adi.Name = "TB_MusteriBolum_Adi";
            this.TB_MusteriBolum_Adi.ReadOnly = true;
            this.TB_MusteriBolum_Adi.Size = new System.Drawing.Size(286, 20);
            this.TB_MusteriBolum_Adi.TabIndex = 7;
            this.TB_MusteriBolum_Adi.TabStop = false;
            this.TB_MusteriBolum_Adi.Text = "MERKEZ";
            this.TB_MusteriBolum_Adi.TextChanged += new System.EventHandler(this.TB_MusteriBolum_Adi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Bölüm Adı:";
            // 
            // CHB_MuseriBolum_Adi_Degistir
            // 
            this.CHB_MuseriBolum_Adi_Degistir.AutoSize = true;
            this.CHB_MuseriBolum_Adi_Degistir.Enabled = false;
            this.CHB_MuseriBolum_Adi_Degistir.Location = new System.Drawing.Point(406, 213);
            this.CHB_MuseriBolum_Adi_Degistir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CHB_MuseriBolum_Adi_Degistir.Name = "CHB_MuseriBolum_Adi_Degistir";
            this.CHB_MuseriBolum_Adi_Degistir.Size = new System.Drawing.Size(61, 17);
            this.CHB_MuseriBolum_Adi_Degistir.TabIndex = 6;
            this.CHB_MuseriBolum_Adi_Degistir.Text = "Değiştir";
            this.CHB_MuseriBolum_Adi_Degistir.UseVisualStyleBackColor = true;
            this.CHB_MuseriBolum_Adi_Degistir.CheckedChanged += new System.EventHandler(this.CHB_MuseriBolum_Adi_Degistir_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Müşteri Firma Bölge:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Müşteri Firma Tel:";
            // 
            // TB_MusteriFirma_Tel
            // 
            this.TB_MusteriFirma_Tel.Location = new System.Drawing.Point(114, 152);
            this.TB_MusteriFirma_Tel.Name = "TB_MusteriFirma_Tel";
            this.TB_MusteriFirma_Tel.Size = new System.Drawing.Size(349, 20);
            this.TB_MusteriFirma_Tel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Müşteri Firma Adres:";
            // 
            // TB_MusteriFirma_Adres
            // 
            this.TB_MusteriFirma_Adres.Location = new System.Drawing.Point(114, 49);
            this.TB_MusteriFirma_Adres.Multiline = true;
            this.TB_MusteriFirma_Adres.Name = "TB_MusteriFirma_Adres";
            this.TB_MusteriFirma_Adres.Size = new System.Drawing.Size(349, 51);
            this.TB_MusteriFirma_Adres.TabIndex = 1;
            // 
            // CB_MusteriFirma_Bolge
            // 
            this.CB_MusteriFirma_Bolge.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_MusteriFirma_Bolge.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_MusteriFirma_Bolge.FormattingEnabled = true;
            this.CB_MusteriFirma_Bolge.Items.AddRange(new object[] {
            "",
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Amasya",
            "Ankara",
            "Antalya",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkâri",
            "Hatay",
            "Isparta",
            "İçel (Mersin)",
            "İstanbul",
            "İzmir",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kırklareli",
            "Kırşehir",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Kahramanmaraş",
            "Mardin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Rize",
            "Sakarya",
            "Samsun",
            "Siirt",
            "Sinop",
            "Sivas",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Şanlıurfa",
            "Uşak",
            "Van",
            "Yozgat",
            "Zonguldak",
            "Aksaray",
            "Bayburt",
            "Karaman",
            "Kırıkkale",
            "Batman",
            "Şırnak",
            "Bartın",
            "Ardahan",
            "Iğdır",
            "Yalova",
            "Karabük",
            "Kilis",
            "Osmaniye",
            "Düzce",
            "YURTDIŞI"});
            this.CB_MusteriFirma_Bolge.Location = new System.Drawing.Point(114, 105);
            this.CB_MusteriFirma_Bolge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_MusteriFirma_Bolge.Name = "CB_MusteriFirma_Bolge";
            this.CB_MusteriFirma_Bolge.Size = new System.Drawing.Size(348, 21);
            this.CB_MusteriFirma_Bolge.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(4, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Maps Link:";
            // 
            // TB_MusteriFirma_MapsLink
            // 
            this.TB_MusteriFirma_MapsLink.Location = new System.Drawing.Point(114, 129);
            this.TB_MusteriFirma_MapsLink.Name = "TB_MusteriFirma_MapsLink";
            this.TB_MusteriFirma_MapsLink.Size = new System.Drawing.Size(349, 20);
            this.TB_MusteriFirma_MapsLink.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Müşteri Firma Notlar:";
            // 
            // TB_MusteriFirma_Not
            // 
            this.TB_MusteriFirma_Not.Location = new System.Drawing.Point(114, 174);
            this.TB_MusteriFirma_Not.Multiline = true;
            this.TB_MusteriFirma_Not.Name = "TB_MusteriFirma_Not";
            this.TB_MusteriFirma_Not.Size = new System.Drawing.Size(349, 35);
            this.TB_MusteriFirma_Not.TabIndex = 5;
            // 
            // Form_Stok_YeniMusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 283);
            this.Controls.Add(this.CB_MusteriFirma_Bolge);
            this.Controls.Add(this.CHB_MuseriBolum_Adi_Degistir);
            this.Controls.Add(this.TB_MusteriBolum_No);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_MusteriBolum_Adi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B_Iptal);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.TB_MusteriFirma_No);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TB_MusteriFirma_MapsLink);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_MusteriFirma_Tel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_MusteriFirma_Not);
            this.Controls.Add(this.TB_MusteriFirma_Adres);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_MusteriFirma_Adi);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Stok_YeniMusteri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YENİ MÜŞTERİ FİRMA EKLE";
            this.Load += new System.EventHandler(this.Form_Yeni_Musteri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TB_MusteriFirma_Adi;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox TB_MusteriFirma_No;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button B_OK;
        public System.Windows.Forms.Button B_Iptal;
        public System.Windows.Forms.TextBox TB_MusteriBolum_No;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TB_MusteriBolum_Adi;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CHB_MuseriBolum_Adi_Degistir;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TB_MusteriFirma_Tel;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TB_MusteriFirma_Adres;
        private System.Windows.Forms.ComboBox CB_MusteriFirma_Bolge;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TB_MusteriFirma_MapsLink;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TB_MusteriFirma_Not;
    }
}