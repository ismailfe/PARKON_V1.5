namespace Parkon
{
    partial class Form_PrgSecim
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
            this.RB_Elektronik = new System.Windows.Forms.RadioButton();
            this.RB_Otomasyon = new System.Windows.Forms.RadioButton();
            this.B_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aşağıdaki seçeneklerden çalıştığınız departmanı seçiniz.";
            // 
            // RB_Elektronik
            // 
            this.RB_Elektronik.AutoSize = true;
            this.RB_Elektronik.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RB_Elektronik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.RB_Elektronik.Location = new System.Drawing.Point(12, 28);
            this.RB_Elektronik.Name = "RB_Elektronik";
            this.RB_Elektronik.Size = new System.Drawing.Size(154, 22);
            this.RB_Elektronik.TabIndex = 1;
            this.RB_Elektronik.Text = "Elektronik";
            this.RB_Elektronik.UseVisualStyleBackColor = false;
            // 
            // RB_Otomasyon
            // 
            this.RB_Otomasyon.AutoSize = true;
            this.RB_Otomasyon.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RB_Otomasyon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RB_Otomasyon.Location = new System.Drawing.Point(12, 57);
            this.RB_Otomasyon.Name = "RB_Otomasyon";
            this.RB_Otomasyon.Size = new System.Drawing.Size(161, 22);
            this.RB_Otomasyon.TabIndex = 1;
            this.RB_Otomasyon.Text = "Otomasyon";
            this.RB_Otomasyon.UseVisualStyleBackColor = true;
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(207, 58);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // Form_PrgSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 84);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.RB_Otomasyon);
            this.Controls.Add(this.RB_Elektronik);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_PrgSecim";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departman Seçimi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RB_Elektronik;
        private System.Windows.Forms.RadioButton RB_Otomasyon;
        private System.Windows.Forms.Button B_OK;
    }
}