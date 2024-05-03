namespace Otel
{
    partial class YoneticiGiris
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
            System.Windows.Forms.PictureBox pictureboxGeri;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoneticiGiris));
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnYonetici = new System.Windows.Forms.Button();
            pictureboxGeri = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureboxGeri
            // 
            pictureboxGeri.Image = ((System.Drawing.Image)(resources.GetObject("pictureboxGeri.Image")));
            pictureboxGeri.Location = new System.Drawing.Point(12, 12);
            pictureboxGeri.Name = "pictureboxGeri";
            pictureboxGeri.Size = new System.Drawing.Size(68, 65);
            pictureboxGeri.TabIndex = 0;
            pictureboxGeri.TabStop = false;
            pictureboxGeri.Click += new System.EventHandler(this.pictureboxGeri_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(140, 100);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(140, 158);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 1;
            // 
            // btnYonetici
            // 
            this.btnYonetici.Location = new System.Drawing.Point(140, 220);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(100, 40);
            this.btnYonetici.TabIndex = 2;
            this.btnYonetici.Text = "Giriş Yap";
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // YoneticiGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnYonetici);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(pictureboxGeri);
            this.Name = "YoneticiGiris";
            this.Text = "YoneticiGiris";
            this.Load += new System.EventHandler(this.YoneticiGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnYonetici;
    }
}