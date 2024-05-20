namespace Otel
{
    partial class MusteriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriForm));
            this.button1 = new System.Windows.Forms.Button();
            this.labelHoşgeldiniz = new System.Windows.Forms.Label();
            this.lblsfr = new System.Windows.Forms.Label();
            this.lblsfr2 = new System.Windows.Forms.Label();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtYeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.btnSifreDegistir = new System.Windows.Forms.Button();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEskiSifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.btnEkstraTemizlik = new System.Windows.Forms.Button();
            this.btnOdayaYemek = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Location = new System.Drawing.Point(31, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 116);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rezervasyon ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHoşgeldiniz
            // 
            this.labelHoşgeldiniz.AutoSize = true;
            this.labelHoşgeldiniz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelHoşgeldiniz.ForeColor = System.Drawing.Color.Turquoise;
            this.labelHoşgeldiniz.Location = new System.Drawing.Point(245, 42);
            this.labelHoşgeldiniz.Name = "labelHoşgeldiniz";
            this.labelHoşgeldiniz.Size = new System.Drawing.Size(120, 31);
            this.labelHoşgeldiniz.TabIndex = 3;
            this.labelHoşgeldiniz.Text = "Merhaba";
            // 
            // lblsfr
            // 
            this.lblsfr.AutoSize = true;
            this.lblsfr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsfr.Location = new System.Drawing.Point(827, 435);
            this.lblsfr.Name = "lblsfr";
            this.lblsfr.Size = new System.Drawing.Size(67, 17);
            this.lblsfr.TabIndex = 4;
            this.lblsfr.Text = "Eski Şifre";
            // 
            // lblsfr2
            // 
            this.lblsfr2.AutoSize = true;
            this.lblsfr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsfr2.Location = new System.Drawing.Point(828, 491);
            this.lblsfr2.Name = "lblsfr2";
            this.lblsfr2.Size = new System.Drawing.Size(73, 17);
            this.lblsfr2.TabIndex = 4;
            this.lblsfr2.Text = "Yeni Şifre ";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(966, 489);
            this.txtYeniSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(119, 21);
            this.txtYeniSifre.TabIndex = 5;
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(966, 544);
            this.txtYeniSifreTekrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(119, 21);
            this.txtYeniSifreTekrar.TabIndex = 5;
            // 
            // btnSifreDegistir
            // 
            this.btnSifreDegistir.BackColor = System.Drawing.Color.SeaShell;
            this.btnSifreDegistir.Location = new System.Drawing.Point(830, 587);
            this.btnSifreDegistir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSifreDegistir.Name = "btnSifreDegistir";
            this.btnSifreDegistir.Size = new System.Drawing.Size(255, 48);
            this.btnSifreDegistir.TabIndex = 6;
            this.btnSifreDegistir.Text = "Şifremi Güncelle";
            this.btnSifreDegistir.UseVisualStyleBackColor = false;
            this.btnSifreDegistir.Click += new System.EventHandler(this.btnSifreDegistir_Click);
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.ForeColor = System.Drawing.Color.Red;
            this.lblAd.Location = new System.Drawing.Point(462, 439);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(25, 17);
            this.lblAd.TabIndex = 7;
            this.lblAd.Text = "Ad";
            this.lblAd.Click += new System.EventHandler(this.lblAd_Click);
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.ForeColor = System.Drawing.Color.Red;
            this.lblSoyad.Location = new System.Drawing.Point(462, 495);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(48, 17);
            this.lblSoyad.TabIndex = 7;
            this.lblSoyad.Text = "Soyad";
            this.lblSoyad.Click += new System.EventHandler(this.lblAd_Click);
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTC.ForeColor = System.Drawing.Color.Red;
            this.lblTC.Location = new System.Drawing.Point(462, 548);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(26, 17);
            this.lblTC.TabIndex = 7;
            this.lblTC.Text = "TC";
            this.lblTC.Click += new System.EventHandler(this.lblAd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(517, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bilgilerim";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.Location = new System.Drawing.Point(966, 433);
            this.txtEskiSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Size = new System.Drawing.Size(119, 21);
            this.txtEskiSifre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(827, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Yeni Şifre Tekrar";
            // 
            // dgvRezervasyonlar
            // 
            this.dgvRezervasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRezervasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervasyonlar.Location = new System.Drawing.Point(340, 146);
            this.dgvRezervasyonlar.Name = "dgvRezervasyonlar";
            this.dgvRezervasyonlar.ReadOnly = true;
            this.dgvRezervasyonlar.Size = new System.Drawing.Size(745, 202);
            this.dgvRezervasyonlar.TabIndex = 9;
            // 
            // btnEkstraTemizlik
            // 
            this.btnEkstraTemizlik.BackColor = System.Drawing.Color.SeaShell;
            this.btnEkstraTemizlik.Location = new System.Drawing.Point(71, 344);
            this.btnEkstraTemizlik.Name = "btnEkstraTemizlik";
            this.btnEkstraTemizlik.Size = new System.Drawing.Size(163, 90);
            this.btnEkstraTemizlik.TabIndex = 10;
            this.btnEkstraTemizlik.Text = "Ekstra Temizlik Söyle";
            this.btnEkstraTemizlik.UseVisualStyleBackColor = false;
            this.btnEkstraTemizlik.Click += new System.EventHandler(this.btnEkstraTemizlik_Click);
            // 
            // btnOdayaYemek
            // 
            this.btnOdayaYemek.BackColor = System.Drawing.Color.SeaShell;
            this.btnOdayaYemek.Location = new System.Drawing.Point(71, 453);
            this.btnOdayaYemek.Name = "btnOdayaYemek";
            this.btnOdayaYemek.Size = new System.Drawing.Size(163, 90);
            this.btnOdayaYemek.TabIndex = 10;
            this.btnOdayaYemek.Text = "Odaya Yemek Söyle";
            this.btnOdayaYemek.UseVisualStyleBackColor = false;
            this.btnOdayaYemek.Click += new System.EventHandler(this.btnOdayaYemek_Click_1);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(808, 381);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(314, 18);
            this.label22.TabIndex = 11;
            this.label22.Text = "Şifre Değiştirmek için Alanları Doldurabilirsiniz..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Honeydew;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(40, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lütfen İlk Önce Rezervasyon Butonu ile Rezervasyon Yapınız..";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Otel.Properties.Resources.cleaning_sign_caution_warning_wet_floor_svgrepo_com;
            this.pictureBox3.Location = new System.Drawing.Point(251, 353);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(103, 72);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Otel.Properties.Resources.sandwich_svgrepo_com;
            this.pictureBox2.Location = new System.Drawing.Point(240, 453);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 75);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MusteriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnOdayaYemek);
            this.Controls.Add(this.btnEkstraTemizlik);
            this.Controls.Add(this.dgvRezervasyonlar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTC);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.btnSifreDegistir);
            this.Controls.Add(this.txtYeniSifreTekrar);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblsfr2);
            this.Controls.Add(this.lblsfr);
            this.Controls.Add(this.labelHoşgeldiniz);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MusteriForm";
            this.Text = "MusteriForm";
            this.Load += new System.EventHandler(this.MusteriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHoşgeldiniz;
        private System.Windows.Forms.Label lblsfr;
        private System.Windows.Forms.Label lblsfr2;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Button btnSifreDegistir;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEskiSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRezervasyonlar;
        private System.Windows.Forms.Button btnEkstraTemizlik;
        private System.Windows.Forms.Button btnOdayaYemek;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}