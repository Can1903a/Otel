namespace Otel
{
    partial class PersonelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelForm));
            this.dataGridViewOda = new System.Windows.Forms.DataGridView();
            this.txtOdaTuru = new System.Windows.Forms.TextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.txtDurum = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dataGridViewMusteri = new System.Windows.Forms.DataGridView();
            this.lblOdaID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            pictureboxGeri = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteri)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureboxGeri
            // 
            pictureboxGeri.Image = ((System.Drawing.Image)(resources.GetObject("pictureboxGeri.Image")));
            pictureboxGeri.Location = new System.Drawing.Point(12, 12);
            pictureboxGeri.Name = "pictureboxGeri";
            pictureboxGeri.Size = new System.Drawing.Size(68, 65);
            pictureboxGeri.TabIndex = 2;
            pictureboxGeri.TabStop = false;
            pictureboxGeri.Click += new System.EventHandler(this.pictureboxGeri_Click);
            // 
            // dataGridViewOda
            // 
            this.dataGridViewOda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOda.Location = new System.Drawing.Point(80, 94);
            this.dataGridViewOda.Name = "dataGridViewOda";
            this.dataGridViewOda.Size = new System.Drawing.Size(536, 237);
            this.dataGridViewOda.TabIndex = 3;
            this.dataGridViewOda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOda_CellClick);
            // 
            // txtOdaTuru
            // 
            this.txtOdaTuru.Location = new System.Drawing.Point(729, 142);
            this.txtOdaTuru.Name = "txtOdaTuru";
            this.txtOdaTuru.Size = new System.Drawing.Size(100, 20);
            this.txtOdaTuru.TabIndex = 4;
            // 
            // txtUcret
            // 
            this.txtUcret.Location = new System.Drawing.Point(729, 178);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(100, 20);
            this.txtUcret.TabIndex = 4;
            // 
            // txtDurum
            // 
            this.txtDurum.Location = new System.Drawing.Point(729, 223);
            this.txtDurum.Name = "txtDurum";
            this.txtDurum.Size = new System.Drawing.Size(100, 20);
            this.txtDurum.TabIndex = 4;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.SeaShell;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(729, 277);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 54);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Oda Güncelle";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dataGridViewMusteri
            // 
            this.dataGridViewMusteri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMusteri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMusteri.Location = new System.Drawing.Point(80, 365);
            this.dataGridViewMusteri.Name = "dataGridViewMusteri";
            this.dataGridViewMusteri.Size = new System.Drawing.Size(536, 237);
            this.dataGridViewMusteri.TabIndex = 3;
            this.dataGridViewMusteri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMusteri_CellClick);
            this.dataGridViewMusteri.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMusteri_CellDoubleClick);
            // 
            // lblOdaID
            // 
            this.lblOdaID.AutoSize = true;
            this.lblOdaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaID.ForeColor = System.Drawing.Color.Red;
            this.lblOdaID.Location = new System.Drawing.Point(750, 110);
            this.lblOdaID.Name = "lblOdaID";
            this.lblOdaID.Size = new System.Drawing.Size(56, 20);
            this.lblOdaID.TabIndex = 6;
            this.lblOdaID.Text = "OdaID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(637, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Oda Türü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(637, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Oda Ücreti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(637, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Oda Durumu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(637, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Oda Numarası";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(251, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Müşteriyi Silmek için Çift Tıklayınız..";
            // 
            // PersonelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(915, 661);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOdaID);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtDurum);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.txtOdaTuru);
            this.Controls.Add(this.dataGridViewMusteri);
            this.Controls.Add(this.dataGridViewOda);
            this.Controls.Add(pictureboxGeri);
            this.Name = "PersonelForm";
            this.Text = "PersonelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonelForm_FormClosing);
            this.Load += new System.EventHandler(this.PersonelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOda;
        private System.Windows.Forms.TextBox txtOdaTuru;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.TextBox txtDurum;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dataGridViewMusteri;
        private System.Windows.Forms.Label lblOdaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}