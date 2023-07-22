namespace Parkon
{
    partial class Form_VersiyonYukle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VersiyonYukle));
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Durum = new System.Windows.Forms.Label();
            this.T_1sec = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.LB_KullanilanVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LB_GuncelVersiyon = new System.Windows.Forms.Label();
            this.LB_GuncelSurum = new System.Windows.Forms.Label();
            this.B_Indir = new System.Windows.Forms.Button();
            this.B_Gizle = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(5, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROJE ARŞİVLEME VE KONTROL SİSTEMİ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_Durum
            // 
            this.LB_Durum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LB_Durum.Location = new System.Drawing.Point(7, 219);
            this.LB_Durum.Name = "LB_Durum";
            this.LB_Durum.Size = new System.Drawing.Size(294, 29);
            this.LB_Durum.TabIndex = 1;
            this.LB_Durum.Text = "Versiyon Kontrol Ediliyor...";
            this.LB_Durum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // T_1sec
            // 
            this.T_1sec.Interval = 1000;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kullanılan Versiyon :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_KullanilanVersion
            // 
            this.LB_KullanilanVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LB_KullanilanVersion.Location = new System.Drawing.Point(155, 110);
            this.LB_KullanilanVersion.Name = "LB_KullanilanVersion";
            this.LB_KullanilanVersion.Size = new System.Drawing.Size(132, 25);
            this.LB_KullanilanVersion.TabIndex = 1;
            this.LB_KullanilanVersion.Text = "1.0.0.0";
            this.LB_KullanilanVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(56, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Güncel Versiyon :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_GuncelVersiyon
            // 
            this.LB_GuncelVersiyon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LB_GuncelVersiyon.Location = new System.Drawing.Point(155, 134);
            this.LB_GuncelVersiyon.Name = "LB_GuncelVersiyon";
            this.LB_GuncelVersiyon.Size = new System.Drawing.Size(132, 25);
            this.LB_GuncelVersiyon.TabIndex = 1;
            this.LB_GuncelVersiyon.Text = "1.0.0.0";
            this.LB_GuncelVersiyon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_GuncelSurum
            // 
            this.LB_GuncelSurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LB_GuncelSurum.ForeColor = System.Drawing.Color.Red;
            this.LB_GuncelSurum.Location = new System.Drawing.Point(5, 218);
            this.LB_GuncelSurum.Name = "LB_GuncelSurum";
            this.LB_GuncelSurum.Size = new System.Drawing.Size(299, 29);
            this.LB_GuncelSurum.TabIndex = 1;
            this.LB_GuncelSurum.Text = "Güncel Sürüm Bulundu!";
            this.LB_GuncelSurum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B_Indir
            // 
            this.B_Indir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Indir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.B_Indir.Location = new System.Drawing.Point(7, 167);
            this.B_Indir.Name = "B_Indir";
            this.B_Indir.Size = new System.Drawing.Size(142, 28);
            this.B_Indir.TabIndex = 2;
            this.B_Indir.Text = "Şimdi İndir";
            this.B_Indir.UseVisualStyleBackColor = true;
            this.B_Indir.Click += new System.EventHandler(this.B_Indir_Click);
            // 
            // B_Gizle
            // 
            this.B_Gizle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Gizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.B_Gizle.Location = new System.Drawing.Point(159, 167);
            this.B_Gizle.Name = "B_Gizle";
            this.B_Gizle.Size = new System.Drawing.Size(142, 28);
            this.B_Gizle.TabIndex = 2;
            this.B_Gizle.Text = "Daha Sonra";
            this.B_Gizle.UseVisualStyleBackColor = true;
            this.B_Gizle.Click += new System.EventHandler(this.B_Gizle_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 198);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(293, 19);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // Form_VersiyonYukle
            // 
            this.AcceptButton = this.B_Indir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.B_Gizle;
            this.ClientSize = new System.Drawing.Size(307, 242);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.B_Gizle);
            this.Controls.Add(this.B_Indir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LB_GuncelSurum);
            this.Controls.Add(this.LB_Durum);
            this.Controls.Add(this.LB_GuncelVersiyon);
            this.Controls.Add(this.LB_KullanilanVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_VersiyonYukle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PARKON Versiyon Kontrol";
            this.Load += new System.EventHandler(this.Form_Starting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Durum;
        private System.Windows.Forms.Timer T_1sec;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label LB_KullanilanVersion;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label LB_GuncelVersiyon;
        private System.Windows.Forms.Label LB_GuncelSurum;
        private System.Windows.Forms.Button B_Indir;
        private System.Windows.Forms.Button B_Gizle;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}