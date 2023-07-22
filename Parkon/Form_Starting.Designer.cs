namespace Parkon
{
    partial class Form_Starting
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarFirstStart = new System.Windows.Forms.ProgressBar();
            this.LB_FirstStartVersiyon = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.RTB_AppStart = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Parkon.Properties.Resources.Logo_WebBanner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.progressBarFirstStart);
            this.panel1.Controls.Add(this.LB_FirstStartVersiyon);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.RTB_AppStart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 229);
            this.panel1.TabIndex = 1;
            // 
            // progressBarFirstStart
            // 
            this.progressBarFirstStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarFirstStart.Location = new System.Drawing.Point(0, 219);
            this.progressBarFirstStart.Name = "progressBarFirstStart";
            this.progressBarFirstStart.Size = new System.Drawing.Size(614, 8);
            this.progressBarFirstStart.TabIndex = 36;
            // 
            // LB_FirstStartVersiyon
            // 
            this.LB_FirstStartVersiyon.AutoSize = true;
            this.LB_FirstStartVersiyon.BackColor = System.Drawing.Color.Transparent;
            this.LB_FirstStartVersiyon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LB_FirstStartVersiyon.ForeColor = System.Drawing.SystemColors.Control;
            this.LB_FirstStartVersiyon.Location = new System.Drawing.Point(497, 200);
            this.LB_FirstStartVersiyon.Name = "LB_FirstStartVersiyon";
            this.LB_FirstStartVersiyon.Size = new System.Drawing.Size(45, 16);
            this.LB_FirstStartVersiyon.TabIndex = 34;
            this.LB_FirstStartVersiyon.Text = "1.0.0.0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(436, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 16);
            this.label16.TabIndex = 35;
            this.label16.Text = "Versiyon :";
            // 
            // RTB_AppStart
            // 
            this.RTB_AppStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_AppStart.BackColor = System.Drawing.Color.Black;
            this.RTB_AppStart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_AppStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RTB_AppStart.ForeColor = System.Drawing.SystemColors.Control;
            this.RTB_AppStart.Location = new System.Drawing.Point(0, 141);
            this.RTB_AppStart.Name = "RTB_AppStart";
            this.RTB_AppStart.ReadOnly = true;
            this.RTB_AppStart.Size = new System.Drawing.Size(614, 50);
            this.RTB_AppStart.TabIndex = 33;
            this.RTB_AppStart.Text = "";
            this.RTB_AppStart.TextChanged += new System.EventHandler(this.RTB_AppStart_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(94, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parkon Başlıyor...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROJE ARŞİVLEME VE KONTROL SİSTEMİ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Parkon.Properties.Resources.loader;
            this.pictureBox2.Location = new System.Drawing.Point(591, 197);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_Starting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(622, 237);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Starting";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parkon";
            this.Load += new System.EventHandler(this.Form_Starting_Load);
            this.Shown += new System.EventHandler(this.Form_Starting_Shown);
            this.Leave += new System.EventHandler(this.Form_Starting_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ProgressBar progressBarFirstStart;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.RichTextBox RTB_AppStart;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label LB_FirstStartVersiyon;
    }
}