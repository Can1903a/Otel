namespace Otel
{
    partial class Anasayfa
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
            this.BtnYonetici = new System.Windows.Forms.Button();
            this.BtnGiris = new System.Windows.Forms.Button();
            this.BtnKayit = new System.Windows.Forms.Button();
            this.BtnPersonel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnYonetici
            // 
            this.BtnYonetici.Location = new System.Drawing.Point(461, 116);
            this.BtnYonetici.Name = "BtnYonetici";
            this.BtnYonetici.Size = new System.Drawing.Size(129, 84);
            this.BtnYonetici.TabIndex = 0;
            this.BtnYonetici.Text = "Yönetici";
            this.BtnYonetici.UseVisualStyleBackColor = true;
            this.BtnYonetici.Click += new System.EventHandler(this.BtnYonetici_Click);
            // 
            // BtnGiris
            // 
            this.BtnGiris.Location = new System.Drawing.Point(195, 116);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(129, 84);
            this.BtnGiris.TabIndex = 1;
            this.BtnGiris.Text = "Giriş Yap";
            this.BtnGiris.UseVisualStyleBackColor = true;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // BtnKayit
            // 
            this.BtnKayit.Location = new System.Drawing.Point(195, 216);
            this.BtnKayit.Name = "BtnKayit";
            this.BtnKayit.Size = new System.Drawing.Size(129, 84);
            this.BtnKayit.TabIndex = 2;
            this.BtnKayit.Text = "Kayıt Yap";
            this.BtnKayit.UseVisualStyleBackColor = true;
            this.BtnKayit.Click += new System.EventHandler(this.BtnKayit_Click);
            // 
            // BtnPersonel
            // 
            this.BtnPersonel.Location = new System.Drawing.Point(461, 216);
            this.BtnPersonel.Name = "BtnPersonel";
            this.BtnPersonel.Size = new System.Drawing.Size(129, 84);
            this.BtnPersonel.TabIndex = 0;
            this.BtnPersonel.Text = "Personel";
            this.BtnPersonel.UseVisualStyleBackColor = true;
            this.BtnPersonel.Click += new System.EventHandler(this.BtnPersonel_Click);
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnKayit);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.BtnPersonel);
            this.Controls.Add(this.BtnYonetici);
            this.Name = "Anasayfa";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnYonetici;
        private System.Windows.Forms.Button BtnGiris;
        private System.Windows.Forms.Button BtnKayit;
        private System.Windows.Forms.Button BtnPersonel;
    }
}

