namespace Parkon
{
    partial class Form_Stok_MarkaDuzelt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Stok_Olustur_MarkaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Stok_Olustur_MarkaAdi = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Iptal = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_MarkaNot = new System.Windows.Forms.TextBox();
            this.DGV_Veri = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Veri)).BeginInit();
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
            // DGV_Veri
            // 
            this.DGV_Veri.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Veri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Veri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Veri.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Veri.Location = new System.Drawing.Point(8, 195);
            this.DGV_Veri.Name = "DGV_Veri";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Veri.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Veri.RowHeadersVisible = false;
            this.DGV_Veri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Veri.Size = new System.Drawing.Size(397, 305);
            this.DGV_Veri.TabIndex = 17;
            this.DGV_Veri.SelectionChanged += new System.EventHandler(this.DGV_Veri_SelectionChanged);
            // 
            // Form_Stok_MarkaDuzelt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.B_Iptal;
            this.ClientSize = new System.Drawing.Size(417, 512);
            this.Controls.Add(this.DGV_Veri);
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
            this.Name = "Form_Stok_MarkaDuzelt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MARKA DÜZELT";
            this.Load += new System.EventHandler(this.Form_Stok_MarkaDuzelt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Veri)).EndInit();
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
        public System.Windows.Forms.DataGridView DGV_Veri;
    }
}