namespace Parkon
{
    partial class Form_Stok_MarkaYeni
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Stok_Olustur_MarkaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Stok_Olustur_MarkaAdi = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Iptal = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_MarkaNot = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marka No";
            // 
            // TB_Stok_Olustur_MarkaNo
            // 
            this.TB_Stok_Olustur_MarkaNo.Location = new System.Drawing.Point(81, 6);
            this.TB_Stok_Olustur_MarkaNo.Name = "TB_Stok_Olustur_MarkaNo";
            this.TB_Stok_Olustur_MarkaNo.ReadOnly = true;
            this.TB_Stok_Olustur_MarkaNo.Size = new System.Drawing.Size(328, 20);
            this.TB_Stok_Olustur_MarkaNo.TabIndex = 1;
            this.TB_Stok_Olustur_MarkaNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Marka Adı";
            // 
            // TB_Stok_Olustur_MarkaAdi
            // 
            this.TB_Stok_Olustur_MarkaAdi.Location = new System.Drawing.Point(81, 28);
            this.TB_Stok_Olustur_MarkaAdi.Name = "TB_Stok_Olustur_MarkaAdi";
            this.TB_Stok_Olustur_MarkaAdi.Size = new System.Drawing.Size(328, 20);
            this.TB_Stok_Olustur_MarkaAdi.TabIndex = 1;
            this.TB_Stok_Olustur_MarkaAdi.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Stok_Olustur_MarkaAdi_Validating);
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(249, 161);
            this.B_OK.Margin = new System.Windows.Forms.Padding(4);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(77, 27);
            this.B_OK.TabIndex = 15;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Iptal
            // 
            this.B_Iptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Iptal.Location = new System.Drawing.Point(332, 161);
            this.B_Iptal.Margin = new System.Windows.Forms.Padding(4);
            this.B_Iptal.Name = "B_Iptal";
            this.B_Iptal.Size = new System.Drawing.Size(77, 27);
            this.B_Iptal.TabIndex = 16;
            this.B_Iptal.Text = "İptal";
            this.B_Iptal.UseVisualStyleBackColor = true;
            this.B_Iptal.Click += new System.EventHandler(this.B_Iptal_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Marka\r\nAçıklaması";
            // 
            // TB_MarkaNot
            // 
            this.TB_MarkaNot.Location = new System.Drawing.Point(81, 50);
            this.TB_MarkaNot.Multiline = true;
            this.TB_MarkaNot.Name = "TB_MarkaNot";
            this.TB_MarkaNot.Size = new System.Drawing.Size(328, 104);
            this.TB_MarkaNot.TabIndex = 2;
            // 
            // Form_Stok_YeniMarka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.B_Iptal;
            this.ClientSize = new System.Drawing.Size(417, 192);
            this.Controls.Add(this.B_Iptal);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.TB_MarkaNot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_Stok_Olustur_MarkaAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Stok_Olustur_MarkaNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Stok_YeniMarka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YENİ MARKA OLUŞTUR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Stok_Olustur_MarkaNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Stok_Olustur_MarkaAdi;
        public System.Windows.Forms.Button B_OK;
        public System.Windows.Forms.Button B_Iptal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_MarkaNot;
    }
}